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
using System.Reflection;
using System.Text;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false)]
    [Description("")]
    public sealed class MetaAttribute : Attribute
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public MetaAttribute() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public MetaAttribute(string template)
        {
            this.template = template;
        }

        private string template = "";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Template
        {
            get { return this.template; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Enum | AttributeTargets.Class, AllowMultiple = false)]
    [Description("")]
    public sealed class ConfigOptionAttribute : System.Attribute
    {
        private readonly JsonMode mode = JsonMode.Value;
        private readonly string name = "";
        private readonly Type jsonConverter;
        private readonly int priority;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOptionAttribute() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOptionAttribute(string name)
        {
            this.name = name;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOptionAttribute(string name, int priority)
        {
            this.name = name;
            this.priority = priority;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOptionAttribute(JsonMode mode)
        {
            this.mode = mode;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOptionAttribute(JsonMode mode, int priority)
        {
            this.mode = mode;
            this.priority = priority;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOptionAttribute(string name, JsonMode mode)
        {
            this.name = name;
            this.mode = mode;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOptionAttribute(string name, JsonMode mode, int priority)
        {
            this.name = name;
            this.mode = mode;
            this.priority = priority;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOptionAttribute(Type jsonConverter)
        {
            this.name = "";

            if (!jsonConverter.IsSubclassOf(typeof(ExtJsonConverter)))
            {
                throw new ArgumentException("Parameter must be subclass of ExtJsonConverter", "jsonConverter");
            }

            this.jsonConverter = jsonConverter;
            this.mode = JsonMode.Custom;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOptionAttribute(Type jsonConverter, int priority) : this(jsonConverter)
        {
            this.priority = priority;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOptionAttribute(string name, Type jsonConverter)
        {
            this.name = name;

            if (!jsonConverter.IsSubclassOf(typeof(ExtJsonConverter)))
            {
                throw new ArgumentException("Parameter must be subclass of ExtJsonConverter", "jsonConverter");
            }

            this.jsonConverter = jsonConverter;
            this.mode = JsonMode.Custom;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOptionAttribute(string name, Type jsonConverter, int priority) : this(name, jsonConverter)
        {
            this.priority = priority;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Type JsonConverter
        {
            get { return jsonConverter; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public JsonMode Mode
        {
            get { return this.mode; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Name
        {
            get { return this.name; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int Priority
        {
            get
            {
                return priority;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    [Description("")]
    public sealed class ListenerArgumentAttribute : System.Attribute
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ListenerArgumentAttribute(int index, string name)
        {
            this.index = index;
            this.name = name;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ListenerArgumentAttribute(int index, string name, Type type)
        {
            this.index = index;
            this.name = name;
            this.type = type;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ListenerArgumentAttribute(int index, string name, Type type, string description)
        {
            this.index = index;
            this.name = name;
            this.type = type;
            this.description = description;
        }

        private int index = 0;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int Index
        {
            get
            {
                return this.index;
            }
        }

        private string name = "el";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        private Type type = typeof(object);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Type Type
        {
            get
            {
                return this.type;
            }
        }

        private string description = "";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Description
        {
            get
            {
                return this.description;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    [Description("")]
    public sealed class DirectEventUpdateAttribute : System.Attribute
    {
        private string script;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Script
        {
            get { return this.script; }
            set { this.script = value; }
        }

        private string methodName;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string MethodName
        {
            get { return this.methodName; }
            set { this.methodName = value; }
        }

        private AutoGeneratingScript generateMode = AutoGeneratingScript.Simple;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public AutoGeneratingScript GenerateMode
        {
            get { return this.generateMode; }
            set { this.generateMode = value; }
        }

        //if no Script or Method then simple script generating - {0}.set[MethodName]({1})
        //{0} - control ID
        //{1} - value
        /// <summary>
        /// 
        /// </summary>
        public const string AutoGenerateFormat = "{0}.{2}={1};";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string GetScript(XControl c, PropertyInfo property)
        {
            StringBuilder sb = new StringBuilder();

            if (!c.CallbackValues.ContainsKey(property.Name))
            {
                return null;
            }

            object value = c.CallbackValues[property.Name];

            if (this.Script.IsNotEmpty())
            {
                sb.AppendFormat(this.Script, c.ClientID, JSON.Serialize(value));
            }
            else if (this.MethodName.IsNotEmpty())
            {
                MethodInfo method = c.GetType().GetMethod(this.MethodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { property.PropertyType }, null);

                if (method != null)
                {
                    method.Invoke(c, new object[] { value });
                }
            }
            else //simple script generating
            {
                switch (this.GenerateMode)
                {
                    case AutoGeneratingScript.Simple:
                        sb.AppendFormat(DirectEventUpdateAttribute.AutoGenerateFormat, c.ClientID, JSON.Serialize(value), property.Name.ToLowerCamelCase());
                        break;
                    case AutoGeneratingScript.WithSet:
                        sb.AppendFormat("{0}.set{2}({1});", c.ClientID, JSON.Serialize(value), property.Name);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return sb.ToString();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void RegisterScript(XControl c, PropertyInfo property)
        {
            c.AddScript(this.GetScript(c, property));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum AutoGeneratingScript
    {
        /// <summary>
        /// 
        /// </summary>
        Simple,

        /// <summary>
        /// 
        /// </summary>
        WithSet
    }

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    [Description("")]
    public sealed class DeferredRenderAttribute : System.Attribute { }

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    [Description("")]
    public sealed class ViewStateMemberAttribute : System.Attribute { }

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    [Description("")]
    public sealed class DirectMethodProxyIDAttribute : System.Attribute
    {
        private DirectMethodProxyIDMode idMode = DirectMethodProxyIDMode.ClientID;
        private string alias;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DirectMethodProxyIDMode IDMode
        {
            get 
            { 
                return this.idMode; 
            }
            set 
            { 
                this.idMode = value; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Alias
        {
            get 
            { 
                return this.alias; 
            }
            set 
            { 
                this.alias = value; 
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum DirectMethodProxyIDMode
    {
        /// <summary>
        /// 
        /// </summary>
        None,

        /// <summary>
        /// 
        /// </summary>
        ClientID,

        /// <summary>
        /// 
        /// </summary>
        ID,

        /// <summary>
        /// 
        /// </summary>
        Alias,

        /// <summary>
        /// 
        /// </summary>
        AliasPlusID
    }
}