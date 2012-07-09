/******** 
 * This file is part of Ext.Net UX.

 * Ext.Net UX is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * Ext.Net UX is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.

 * You should have received a copy of the GNU Lesser General Public License
 * along with the Ext.Net.  If not, see <http://www.gnu.org/licenses/>.
 */

/*
* @version:		1.2.0
* @author:		Ext.NET, Inc. http://www.ext.net/
* @date:		2011-09-12
* @copyright:	Copyright (c) 2006-2011, Ext.NET, Inc. or as noted within each 
* 				applicable file LICENSE.txt file
* @license:		LGPL 3.0 License
* @website:		http://www.ext.net/
 ********/

using System;
using System.Reflection;
using System.Text;

using Ext.Net;
using Ext.Net.Utilities;
using Newtonsoft.Json;
using JsonNetReader = Newtonsoft.Json.JsonReader;

namespace Ext.Net.UX
{
    public partial class MapPropertiesJsonConverter : ExtJsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
            {
                bool isControls = value is MapControls;
                PropertyInfo[] properties = value.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                StringBuilder sb = new StringBuilder();

                foreach (PropertyInfo property in properties)
                {
                    ConfigOptionAttribute attr = ClientConfig.GetClientConfigAttribute(property);

                    if (attr != null && property.PropertyType == typeof(bool))
                    {
                        object prValue = property.GetValue(value, null);
                        object defaultValue = ReflectionUtils.GetDefaultValue(property);
                        if ((bool)prValue)
                        {
                            if (!isControls)
                            {
                                if (!(bool)defaultValue)
                                {
                                    sb.Append(string.Concat("'enable", property.Name, "',")); 
                                }
                            }
                            else
                            {
                                sb.Append(string.Concat("'", property.Name,"',"));
                            }
                        }
                        else
                        {
                            if (!isControls)
                            {
                                if ((bool)defaultValue)
                                {
                                    sb.Append(string.Concat("'disable", property.Name, "',"));
                                }
                            }
                        }
                    }
                }

                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                    writer.WriteStartArray();
                    writer.WriteRaw(sb.ToString());
                    writer.WriteEndArray();
                    return;
                }
            }
            writer.WriteStartArray();
            writer.WriteEndArray();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(MapConfiguration).IsAssignableFrom(objectType) || typeof(MapControls).IsAssignableFrom(objectType);
        }

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}