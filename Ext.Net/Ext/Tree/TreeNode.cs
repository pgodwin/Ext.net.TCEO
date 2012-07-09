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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    [Description("")]
    public partial class TreeNode : TreeNodeBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TreeNode() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        [Description("")]
        public TreeNode(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="icon"></param>
        [Description("")]
        public TreeNode(string text, Icon icon)
        {
            this.Text = text;
            this.Icon = icon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="icon"></param>
        [Description("")]
        public TreeNode(string id, string text, Icon icon)
        {
            this.NodeID = id;
            this.Text = text;
            this.Icon = icon;
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.tree.TreeNode";
            }
        }

        private TreeNodeCollection nodes;

        /// <summary>
        /// The root node for the tree.
        /// </summary>
        [Category("3. TreeNode")]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The root node for the tree.")]
        public virtual TreeNodeCollection Nodes
        {
            get
            {
                if (this.nodes == null)
                {
                    this.nodes = new TreeNodeCollection(false);
                    this.nodes.AfterItemAdd += Nodes_AfterItemAdd;
                }

                return this.nodes;
            }
        }

        void Nodes_AfterItemAdd(TreeNodeBase item)
        {
            item.ParentNode = this;
        }
        
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [Description("")]
        protected virtual string NodeType
        {
            get
            {
                return this.EnforceNodeType ? "node" : "";
            }
        }

        private TreeNodeListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public TreeNodeListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new TreeNodeListeners();
                }

                return this.listeners;
            }
        }
    }
}