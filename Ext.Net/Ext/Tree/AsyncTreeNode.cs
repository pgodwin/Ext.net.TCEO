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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class AsyncTreeNode : TreeNodeBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public AsyncTreeNode() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        [Description("")]
        public AsyncTreeNode(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        [Description("")]
        public AsyncTreeNode(string id, string text)
        {
            this.NodeID = id;
            this.Text = text;
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
                return "Ext.tree.AsyncTreeNode";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public override bool EnforceNodeType
        {
            get
            {
                object obj = this.ViewState["EnforceNodeType"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["EnforceNodeType"] = value;
            }
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
                return this.EnforceNodeType ? "async" : "";
            }
        }

        private AsyncTreeNodeListeners listeners;

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
        public AsyncTreeNodeListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new AsyncTreeNodeListeners();
                }

                return this.listeners;
            }
        }

        private TreeLoaderCollection treeLoader;

        /// <summary>
        /// The root node for the tree.
        /// </summary>
        [ConfigOption("loader>Primary")]
        [Category("7. TreePanel")]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The root node for the tree.")]
        public virtual TreeLoaderCollection Loader
        {
            get
            {
                if (this.treeLoader == null)
                {
                    this.treeLoader = new TreeLoaderCollection();
                    this.treeLoader.AfterItemAdd += TreeLoader_AfterItemAdd;
                }

                return this.treeLoader;
            }
        }

        void TreeLoader_AfterItemAdd(TreeLoaderBase item)
        {
            if (item is PageTreeLoader)
            {
                throw new Exception("PageTreeLoader cannot be a loader of AsyncTreeNode");
            }
        }
    }
}