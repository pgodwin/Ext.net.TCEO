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
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Web.UI;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [XmlSchemaProvider("MySchema")]
    [Description("")]
    public partial class TreeNodeCollection : StateManagedCollection<TreeNodeBase>, IXmlSerializable, ISerializable
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]        
        public TreeNodeBase Primary
        {
            get
            {
                if (this.Count > 0)
                {
                    return this[0];
                }
                
                return null;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TreeNodeCollection() : this(false) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TreeNodeCollection(bool single)
        {
            this.SingleItemMode = single;
        }

        private void AddChildes(TreeNode parent, StringBuilder sb, Control owner)
        {
            string cfg = new ClientConfig().Serialize(parent);

            if (parent.Nodes.Count > 0)
            {
                int index = cfg.LastIndexOf("}");
                sb.Append(cfg.Substring(0, index));

                sb.Append(",children:[");

                foreach (TreeNodeBase node in parent.Nodes)
                {
                    node.Owner = owner;

                    if (node is TreeNode)
                    {
                        TreeNode treeNode = (TreeNode)node;
                        this.AddChildes(treeNode, sb, owner);
                    }
                    else
                    {
                        sb.Append(new ClientConfig().Serialize(node));
                    }

                    sb.Append(",");
                }

                if (sb[sb.Length - 1] == ',')
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                sb.Append("");
                sb.Append("]}");
            }
            else
            {
                sb.Append(cfg);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToJson()
        {
            StringBuilder sb = new StringBuilder(256);
            bool comma = false;
            sb.Append("[");

            foreach (TreeNodeBase node in this)
            {
                if (comma)
                {
                    sb.Append(",");
                }

                TreeNode treeNode = node as TreeNode;

                if (treeNode == null)
                {
                    sb.Append(new ClientConfig().SerializeInternal(node, this.Owner));     
                }
                else
                {
                    this.AddChildes(treeNode, sb, this.Owner);
                }

                comma = true;
            }
            sb.Append("]");

            return sb.ToString();
        }

        #region Implementation of IXmlSerializable

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {
            //no operation
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("json");
            writer.WriteCData(this.ToJson());
            writer.WriteEndElement();
        }

        #endregion

        #region Implementation of ISerializable

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("json", this.ToJson());
        }

        #endregion

        private const string ns = "http://tempuri.org/";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static XmlQualifiedName MySchema(XmlSchemaSet xs)
        {
            // This method is called by the framework to get the schema for this type.
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            var xw = new XmlTextWriter(sw);

            // generate the schema for type T
            xw.WriteStartDocument();
            xw.WriteStartElement("schema");
            xw.WriteAttributeString("targetNamespace", "http://tempuri.org/");
            xw.WriteAttributeString("xmlns", "http://www.w3.org/2001/XMLSchema");
            xw.WriteStartElement("complexType");
            xw.WriteAttributeString("name", "TreeNodeCollection");
            xw.WriteStartElement("sequence");

            xw.WriteStartElement("element");
            xw.WriteAttributeString("name", "json");
            xw.WriteAttributeString("type", "string");
            xw.WriteEndElement();

            xw.WriteEndElement();
            xw.WriteEndElement();
            xw.WriteEndElement();
            xw.WriteEndDocument();
            xw.Close();

            var schemaSerializer = new XmlSerializer(typeof(XmlSchema));
            var sr = new StringReader(sb.ToString());
            var s = (XmlSchema)schemaSerializer.Deserialize(sr);
            xs.XmlResolver = new XmlUrlResolver();
            xs.Add(s);

            return new XmlQualifiedName("TreeNodeCollection", ns);
        }
    }
}