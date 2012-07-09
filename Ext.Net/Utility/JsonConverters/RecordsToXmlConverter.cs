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
using System.Collections.Generic;
using System.Xml;

using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class RecordsToXmlConverter : ExtJsonConverter
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType != typeof(XmlDocument))
                throw new JsonSerializationException("XmlNodeConverter only supports deserializing XmlDocuments");

            XmlDocument document = new XmlDocument();
            XmlNamespaceManager manager = new XmlNamespaceManager(document.NameTable);

            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonSerializationException("XmlNodeConverter can only convert JSON that begins with an object.");

            reader.Read();

            DeserializeNode(reader, document, manager, document);

            return document;
        }

        private void DeserializeValue(Newtonsoft.Json.JsonReader reader, XmlDocument document, XmlNamespaceManager manager, string propertyName, XmlNode currentNode)
        {
            // deserialize xml element
            bool finishedAttributes = false;
            bool finishedElement = false;
            Dictionary<string, string> attributeNameValues = new Dictionary<string, string>();

            // a string token means the element only has a single text child
            if (reader.TokenType != JsonToken.String
              && reader.TokenType != JsonToken.Null
              && reader.TokenType != JsonToken.Boolean
              && reader.TokenType != JsonToken.Integer
              && reader.TokenType != JsonToken.Float
              && reader.TokenType != JsonToken.Date
              && reader.TokenType != JsonToken.StartConstructor)
            {
                // read properties until first non-attribute is encountered
                while (!finishedAttributes && !finishedElement && reader.Read())
                {
                    switch (reader.TokenType)
                    {
                        case JsonToken.PropertyName:
                            string attributeName = reader.Value.ToString();

                            if (attributeName[0] == '@')
                            {
                                attributeName = attributeName.Substring(1);
                                reader.Read();
                                string attributeValue = reader.Value.ToString();
                                attributeNameValues.Add(attributeName, attributeValue);
                            }
                            else
                            {
                                finishedAttributes = true;
                            }
                            break;
                        case JsonToken.EndObject:
                            finishedElement = true;
                            break;
                        default:
                            throw new JsonSerializationException("Unexpected JsonToken: " + reader.TokenType);
                    }
                }
            }

            // have to wait until attributes have been parsed before creating element
            // attributes may contain namespace info used by the element
            XmlElement element = document.CreateElement(propertyName);

            currentNode.AppendChild(element);

            // add attributes to newly created element
            foreach (KeyValuePair<string, string> nameValue in attributeNameValues)
            {
                XmlAttribute attribute = document.CreateAttribute(nameValue.Key);

                attribute.Value = nameValue.Value;

                element.SetAttributeNode(attribute);
            }

            if (reader.TokenType == JsonToken.String)
            {
                element.AppendChild(document.CreateTextNode(reader.Value.ToString()));
            }
            else if (reader.TokenType == JsonToken.Integer)
            {
                element.AppendChild(document.CreateTextNode(XmlConvert.ToString((long)reader.Value)));
            }
            else if (reader.TokenType == JsonToken.Float)
            {
                element.AppendChild(document.CreateTextNode(XmlConvert.ToString((double)reader.Value)));
            }
            else if (reader.TokenType == JsonToken.Boolean)
            {
                element.AppendChild(document.CreateTextNode(XmlConvert.ToString((bool)reader.Value)));
            }
            else if (reader.TokenType == JsonToken.Date)
            {
                DateTime d = (DateTime)reader.Value;
                element.AppendChild(document.CreateTextNode(XmlConvert.ToString(d, ToSerializationMode(d.Kind))));
            }
            else if (reader.TokenType == JsonToken.Null)
            {
                // empty element. do nothing
            }
            else
            {
                // finished element will have no children to deserialize
                if (!finishedElement)
                {
                    manager.PushScope();

                    DeserializeNode(reader, document, manager, element);

                    manager.PopScope();
                }
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public XmlDateTimeSerializationMode ToSerializationMode(DateTimeKind kind)
        {
            switch (kind)
            {
                case DateTimeKind.Local:
                    return XmlDateTimeSerializationMode.Local;
                case DateTimeKind.Unspecified:
                    return XmlDateTimeSerializationMode.Unspecified;
                case DateTimeKind.Utc:
                    return XmlDateTimeSerializationMode.Utc;
                default:
                    throw new ArgumentOutOfRangeException("kind", kind, "Unexpected DateTimeKind value.");
            }
        }

        private void DeserializeNode(Newtonsoft.Json.JsonReader reader, XmlDocument document, XmlNamespaceManager manager, XmlNode currentNode)
        {
            if (currentNode.NodeType == XmlNodeType.Document)
            {
                XmlElement root = document.CreateElement("records");
                document.AppendChild(root);
                currentNode = root;
            }

            XmlNode savedNode = currentNode;
            do
            {
                if (savedNode.Name == "records" && savedNode.ParentNode.NodeType == XmlNodeType.Document)
                {
                    currentNode = savedNode;
                }
                
                switch (reader.TokenType)
                {
                    case JsonToken.PropertyName:
                        if (currentNode.NodeType == XmlNodeType.Document && document.DocumentElement != null)
                            throw new JsonSerializationException("JSON root object has multiple properties. The root object must have a single property in order to create a valid XML document.");

                        string propertyName = reader.Value.ToString();
                        reader.Read();

                        if (reader.TokenType == JsonToken.StartArray)
                        {
                            while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                            {
                                if (reader.TokenType == JsonToken.StartObject)
                                {
                                    if (currentNode.Name == "records" && currentNode.ParentNode.NodeType == XmlNodeType.Document &&
                                       (propertyName == "Updated" || propertyName == "Created" || propertyName == "Deleted"))
                                    {
                                        XmlNode tempNode = currentNode.SelectSingleNode(propertyName);
                                        if (tempNode != null)
                                        {
                                            currentNode = tempNode;
                                            propertyName = "record";
                                        }
                                    }
                                }
                                DeserializeValue(reader, document, manager, propertyName, currentNode);
                            }
                        }
                        else
                        {
                            bool addRecord = currentNode.ParentNode != null && currentNode.ParentNode.ParentNode != null &&
                                                    currentNode.ParentNode.Name == "records" && currentNode.ParentNode.ParentNode.NodeType == XmlNodeType.Document;

                            if ((currentNode.Name == "Updated" || currentNode.Name == "Created" || currentNode.Name == "Deleted") && addRecord)
                            {
                                XmlElement record = document.CreateElement("record");
                                currentNode.AppendChild(record);
                                currentNode = record;
                            }
                            DeserializeValue(reader, document, manager, propertyName, currentNode);
                        }
                        break;
                    case JsonToken.StartConstructor:
                        string constructorName = reader.Value.ToString();

                        while (reader.Read() && reader.TokenType != JsonToken.EndConstructor)
                        {
                            DeserializeValue(reader, document, manager, "-" + constructorName, currentNode);
                        }
                        break;
                    case JsonToken.EndObject:
                    case JsonToken.EndArray:
                        return;
                    default:
                        throw new JsonSerializationException("Unexpected JsonToken when deserializing node: " + reader.TokenType);
                }
            } while (reader.TokenType == JsonToken.PropertyName || reader.Read());
            // don't read if current token is a property. token was already read when parsing element attributes
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool CanConvert(Type valueType)
        {
            return typeof(XmlNode).IsAssignableFrom(valueType);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
