/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 1.2.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2011-09-12
 * @copyright : Copyright (c) 2006-2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ClientConfig
    {
        StringBuilder sb;
        StringWriter sw;
        JsonTextWriter writer;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientConfig() { }

        private Control owner = null;

        private List<string> exclude = new List<string>();

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Serialize(object obj)
        {
            return this.Serialize(obj, false);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Serialize(object obj, bool ignoreCustomSerialization)
        {
            if (this.owner == null)
            {
                if (obj is Control)
                {
                    this.owner = ((Control)obj);

                    if (obj is Observable)
                    {
                        foreach (ConfigItem item in ((Observable)obj).CustomConfig)
                        {
                            this.exclude.Add(item.Name);
                        }
                    }
                }
                else if (obj is StateManagedItem)
                {
                    this.owner = ((StateManagedItem)obj).Owner;
                }
            }

            if (obj is ICustomConfigSerialization && !ignoreCustomSerialization)
            {
                return (obj as ICustomConfigSerialization).ToScript(owner);
            }

            this.sb = new StringBuilder();
            this.sw = new StringWriter(sb);
            this.writer = new JsonTextWriter(sw);

            // PG Change - this makes the JSON to standards
            this.writer.QuoteName = true;

            if (this.owner is XControl)
            {
                XControl wc = (XControl)this.owner;

                if (wc != null)
                {
                    ResourceManager sm = null;

                    sm = wc.SafeResourceManager;

                    if (sm != null && sm.SourceFormatting)
                    {
                        this.writer.Formatting = Formatting.Indented;
                    }
                }
            }

            this.writer.WriteStartObject();

            this.Process(obj);

            this.writer.WriteEndObject();
            this.writer.Flush();

            return sw.GetStringBuilder().ToString();
        }

        internal string SerializeInternal(object obj, Control owner)
        {
            this.owner = owner;
            StateManagedItem smi = obj as StateManagedItem;

            if (smi != null)
            {
                smi.Owner = owner;
            }
            
            return this.Serialize(obj);
        }

        private static ConfigProperties GetProperties(object obj)
        {
            string key = obj.GetType().FullName;
            ConfigProperties cahcheProperties = null;

            HttpContext context = HttpContext.Current;

            if (context != null)
            {
                cahcheProperties = context.Cache[key] as ConfigProperties;
            }


            if (cahcheProperties != null)
            {
                return cahcheProperties;
            }
            else
            {
                PropertyInfo[] result = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                ConfigProperties list = new ConfigProperties();

                foreach (PropertyInfo propertyInfo in result)
                {
                    ConfigOptionAttribute attr = ClientConfig.GetClientConfigAttribute(propertyInfo);

                    if (attr != null)
                    {
                        list.Add(new ConfigObject(propertyInfo, attr, ReflectionUtils.GetDefaultValue(propertyInfo)));
                    }
                }

                list.Reverse();

                if (context != null)
                {
                    context.Cache.Insert(key, list);
                }

                return list;
            }
        }

        private void Process(object obj)
        {
            IXObject extObj = obj as IXObject;

            if (extObj != null && extObj.ConfigOptionsExtraction == ConfigOptionsExtraction.List)
            {
                ConfigOptionsCollection configOptions = extObj.ConfigOptions;

                foreach (KeyValuePair<int, ConfigOption> configOption in configOptions.PriorityProperties)
                {
                    try
                    {
                        this.ToExtConfig(obj, configOption.Value);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error during ClientConfig initialization. "
                                            + configOption.Value.PropertyName.ToTitleCase()
                                            + " - "
                                            + ex.Message, ex);
                    }
                }
                
                foreach (KeyValuePair<string, ConfigOption> configOption in configOptions)
                {
                    try
                    {
                        this.ToExtConfig(obj, configOption.Value);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error during ClientConfig initialization. "
                                            + configOption.Value.PropertyName.ToTitleCase()
                                            + " - "
                                            + ex.Message, ex);
                    }
                }
            }
            else
            {
                foreach (ConfigObject property in GetProperties(obj))
                {
                    try
                    {
                        this.ToExtConfig(obj, new ConfigOption(property.PropertyInfo.Name, this.ConfigOptionAttr2SerializationOptions(property.Attribute), property.DefaultValue, property.PropertyInfo.GetValue(obj, null)));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error during ClientConfig initialization. "
                                            + property.PropertyInfo.Name
                                            + " - "
                                            + ex.Message, ex);
                    }
                }
            }
        }

        private SerializationOptions ConfigOptionAttr2SerializationOptions(ConfigOptionAttribute attr)
        {
            if (attr.JsonConverter != null)
            {
                return new SerializationOptions(attr.Name, attr.JsonConverter);
            }

            return new SerializationOptions(attr.Name, attr.Mode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static ConfigOptionAttribute GetClientConfigAttribute(PropertyInfo property)
        {
            object[] attrs = property.GetCustomAttributes(typeof(ConfigOptionAttribute), true);

            if (attrs.Length == 1)
            {
                return (ConfigOptionAttribute)attrs[0];
            }

            return null;
        }

        private void ToExtConfig(object obj, ConfigOption configOption)
        {
            if (configOption.Serialization.Mode != JsonMode.Ignore)
            {
                object originalValue = configOption.Value;
                object defaultValue = configOption.DefaultValue;

                if (!IsNullEmptyOrDefault(ref defaultValue, ref originalValue, configOption))
                {
                    if (originalValue.Equals("NULL"))
                    {
                        originalValue = null;
                    }

                    string name = configOption.PropertyName.ToLowerCamelCase();

                    if (configOption.Serialization.Name.IsNotEmpty())
                    {
                        if (configOption.Serialization.Name.Contains(">"))
                        {
                            string[] parts = configOption.Serialization.Name.Split('>');
                            name = parts[0];
                            PropertyInfo subProp = originalValue.GetType().GetProperty(parts[1]);
                            ConfigOptionAttribute subAttr = ClientConfig.GetClientConfigAttribute(subProp);

                            if (subAttr != null)
                            {
                                configOption.Serialization = this.ConfigOptionAttr2SerializationOptions(subAttr);
                                originalValue = subProp.GetValue(originalValue, null);
                            }
                        }
                        else
                        {
                            name = configOption.Serialization.Name;
                        }
                    }

                    if (this.exclude.Contains(name))
                    {
                        return;
                    }

                    StringBuilder temp = new StringBuilder(128);

                    switch (configOption.Serialization.Mode)
                    {
                        case JsonMode.ToLower:
                            this.WriteValue(name, originalValue.ToString().ToLowerInvariant());
                            break;
                        case JsonMode.ToCamelLower:
                            this.WriteValue(name, originalValue.ToString().ToLowerCamelCase());
                            break;
                        case JsonMode.Raw:
                            this.WriteRawValue(name, originalValue);
                            break;
                        case JsonMode.ObjectAllowEmpty:
                        case JsonMode.Object:
                            temp.Append(new ClientConfig().SerializeInternal(originalValue, this.owner));

                            if (!IsEmptyObject(temp.ToString()) || configOption.Serialization.Mode == JsonMode.ObjectAllowEmpty)
                            {
                                string type = this.GetInstanceOf(originalValue);

                                if (type.IsNotEmpty())
                                {
                                    this.WriteRawValue(name, "new {0}({1})".FormatWith(type, temp.ToString()));
                                }
                                else
                                {
                                    this.WriteRawValue(name, temp.ToString());
                                }
                            }
                            break;
                        case JsonMode.UnrollCollection:
                            IEnumerable si = (IEnumerable)originalValue;

                            foreach (object unrollingObject in si)
                            {
                                if (unrollingObject != null)
                                {
                                    this.Process(unrollingObject);
                                }
                            }
                            break;
                        case JsonMode.UnrollObject:
                            this.Process(originalValue);
                            break;
                        case JsonMode.Array:
                        case JsonMode.AlwaysArray:
                            if (originalValue is IEnumerable)
                            {
                                IList list = (IList)originalValue;

                                if (list.Count == 1 && configOption.Serialization.Mode != JsonMode.AlwaysArray)
                                {
                                    temp.Append(new ClientConfig().SerializeInternal(list[0], this.owner));

                                    if (!IsEmptyObject(temp.ToString()))
                                    {
                                        this.WriteRawValue(name, temp.ToString());
                                    }
                                }
                                else
                                {
                                    bool comma = false;
                                    temp.Append("[");

                                    foreach (object o in list)
                                    {
                                        if (comma)
                                        {
                                            temp.Append(",");
                                        }

                                        if (o.GetType().IsPrimitive || o is string)
                                        {
                                            temp.Append(JSON.Serialize(o));
                                        }
                                        else
                                        {
                                            temp.Append(new ClientConfig().SerializeInternal(o, this.owner));
                                        }

                                        comma = true;
                                    }
                                    temp.Append("]");

                                    string type = this.GetInstanceOf(originalValue);

                                    if (type.IsNotEmpty())
                                    {
                                        this.WriteRawValue(name, "new {0}({1})".FormatWith(type, temp.ToString()));
                                    }
                                    else
                                    {
                                        this.WriteRawValue(name, temp.ToString());
                                    }
                                }
                            }
                            break;
                        case JsonMode.ArrayToObject:
                            if (originalValue is IEnumerable)
                            {
                                IList list = (IList)originalValue;

                                temp.Append("{");
                                bool comma = false;

                                foreach (object o in list)
                                {
                                    if (comma)
                                    {
                                        temp.Append(",");
                                    }
                                    temp.Append(o.ToString());
                                    comma = true;
                                }
                                temp.Append("}");

                                if (!IsEmptyObject(temp.ToString()))
                                {
                                    this.WriteRawValue(name, temp.ToString());
                                }
                            }
                            break;
                        case JsonMode.Custom:
                            if (originalValue != null)
                            {
                                if (originalValue is IList && ((IList)originalValue).Count == 0)
                                {
                                    break;
                                }

                                if (name != "-")
                                {
                                    this.writer.WritePropertyName(name);
                                }

                                ExtJsonConverter converter = (ExtJsonConverter)Activator.CreateInstance(configOption.Serialization.JsonConverter);
                                converter.Name = name;
                                converter.PropertyName = configOption.PropertyName.ToTitleCase(CultureInfo.InvariantCulture);
                                converter.Owner = obj;

                                converter.WriteJson(this.writer, originalValue, null);
                            }
                            break;
                        case JsonMode.ToClientID:
                            Control control = null;
                            string controlID = "";
                            bool rawID = false;

                            if (originalValue is Control)
                            {
                                control = (Control)originalValue;
                            }
                            else
                            {
                                controlID = originalValue.ToString() ?? "";
                                
                                if (controlID.StartsWith("{raw}"))
                                {
                                    controlID = controlID.Substring(5);
                                    rawID = true;
                                }
                                else
                                {
                                    control = ControlUtils.FindControl(this.owner, controlID, true);
                                }
                            }                            

                            if (control != null || rawID)
                            {
                                if (name.StartsWith("{raw}"))
                                {
                                    name = name.Substring(5);
                                    this.WriteValue(name, control != null ? control.ClientID : controlID);
                                }
                                else
                                {
                                    this.WriteRawValue(name, control != null ? control.ClientID : controlID);
                                }
                            }
                            else
                            {
                                this.WriteRawValue(name, controlID);
                            }

                            break;
                        case JsonMode.ToString:
                            this.WriteValue(name, originalValue.ToString());
                            break;
                        case JsonMode.Url:
                            string url = originalValue.ToString();

                            this.WriteValue(name, this.owner == null ? url : this.owner.ResolveClientUrl(url));
                            break;
                        case JsonMode.Value:
                        default:
                            this.WriteValue(name, originalValue);
                            break;
                    }
                }
            }
        }

        private string GetInstanceOf(object originalValue)
        {
            if (originalValue is XControl)
            {
                return ((XControl)originalValue).InstanceOf;
            }

            if (originalValue is StateManagedItem)
            {
                return ((StateManagedItem)originalValue).InstanceOf;
            }

            return "";
        }

        private void WriteRawValue(string name, object value)
        {
            this.WriteRawValue(name, value, true);
        }

        private void WriteRawValue(string name, object value, bool parseTokens)
        {
            this.writer.WritePropertyName(name);

            if (value is string)
            {
                if (value.ToString().StartsWith("<!token>"))
                {
                    value = value.ToString().Substring(8);
                }
                else
                {
                    value = TokenUtils.ParseTokens(value.ToString(), this.owner);
                }

                if (value.ToString().StartsWith("<raw>"))
                {
                    value = value.ToString().Substring(5);
                }
            }
            else
            {
                if (value is IScriptable)
                {
                    value = ((IScriptable)value).ToScript();
                }
            }

            this.writer.WriteRawValue(value.ToString());
        }

        private void WriteValue(string name, object value)
        {
            if (value is string)
            {
                if (value.ToString().StartsWith("<!token>"))
                {
                    value = value.ToString().Substring(8);
                }
                else
                {
                    value = TokenUtils.ParseTokens(value.ToString(), this.owner);
                }

                string temp = value.ToString();

                if (temp.StartsWith("<string>"))
                {
                    int count = 8;

                    if (temp.StartsWith("<string><raw>"))
                    {
                        count = 13;
                    }

                    this.writer.WritePropertyName(name);
                    this.writer.WriteValue(temp.Substring(count));
                    return;
                }

                if (temp.StartsWith("<raw>"))
                {
                    this.WriteRawValue(name, temp.Substring(5));
                    return;
                }
            }

            this.writer.WritePropertyName(name);

            if (value is Unit)
            {
                Unit unit = (Unit)value;

                if (unit.Type == UnitType.Pixel)
                {
                    this.writer.WriteValue(Convert.ToInt32(((Unit)value).Value));
                }
                else if (unit.Type == UnitType.Percentage)
                {
                    this.writer.WriteValue(unit.Value.ToString() + "%");
                }

            }
            else if (value is Enum)
            {
                this.writer.WriteValue(value.ToString());
            }
            else if (value is IScriptable)
            {
                this.writer.WriteValue(((IScriptable)value).ToScript());
            }
            else
            {
                this.writer.WriteValue(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <param name="originalValue"></param>
        /// <returns></returns>
        public bool IsNullEmptyOrDefault(ref object defaultValue, ref object originalValue, ConfigOption configOption)
        {
            if (defaultValue == null)
            {
                defaultValue = "NULL";
            }

            if (originalValue == null)
            {
                originalValue = "NULL";
            }
            else if(configOption.Serialization.Mode == JsonMode.Custom && 
                    configOption.Serialization.JsonConverter == typeof(LazyControlJsonConverter) &&
                    originalValue is Control &&
                    !((Control)originalValue).Visible)
            {
                return true;
            }
            else if (!(originalValue is string) && originalValue is IEnumerable)
            {
                if (!((IEnumerable)originalValue).GetEnumerator().MoveNext())
                {
                    originalValue = "NULL";
                }
            }
            else if (originalValue is DateTime)
            {
                DateTime t = (DateTime)originalValue;

                if (t.Equals(DateTime.MinValue) || t.Equals(DateTime.MaxValue))
                {
                    return true;
                }
            }
            else if (originalValue is Unit)
            {
                Unit defaultVal = (Unit)defaultValue;
                Unit originalVal = (Unit)originalValue;

                if (originalVal.IsEmpty || defaultVal.Equals(originalValue))
                {
                    return true;
                }
            }
            else if (originalValue is XControl)
            {
                return ((XControl)originalValue).IsDefault;
            }
            else if (originalValue is StateManagedItem)
            {
                return ((StateManagedItem)originalValue).IsDefault;
            }
            else if (originalValue is Margins)
            {
                return ((Margins)originalValue).IsDefault;
            }

            return defaultValue.Equals(originalValue);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static bool IsEmptyObject(string value)
        {
            return (value.IsEmpty() || value.Equals("{}") || value.Equals("[]"));
        }
    }

    internal class ConfigObject
    {
        private PropertyInfo propertyInfo;
        private ConfigOptionAttribute attr;
        private object defaultValue;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigObject(PropertyInfo propertyInfo, ConfigOptionAttribute attr, object defValue)
        {
            this.propertyInfo = propertyInfo;
            this.attr = attr;
            this.defaultValue = defValue;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public PropertyInfo PropertyInfo
        {
            get { return propertyInfo; }
            set { propertyInfo = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOptionAttribute Attribute
        {
            get { return attr; }
            set { attr = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public object DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }
    }

    internal class ConfigProperties : List<ConfigObject> { }
}