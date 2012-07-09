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
    [Meta]
    [ToolboxItem(false)]
    [Description("")]
    public partial class RowExpander : Plugin
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public RowExpander() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.RowExpander";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("proxyId")]
        [Description("")]
        protected override string ConfigIDProxy
        {
            get { return base.ConfigIDProxy; }
        }

        private XTemplate template;

        /// <summary>
        /// The template string to use to display each item in the dropdown list.
        /// </summary>
        [Meta]
        [Category("3. RowExpander")]
        [ConfigOption("tpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The template string to use to display each item in the dropdown list.")]
        public virtual XTemplate Template
        {
            get
            {
                if (this.template == null)
                {
                    this.template = new XTemplate();
                }

                return this.template;
            }
        }

        ItemsCollection<Component> component;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("component", typeof(ItemCollectionJsonConverter))]
        [Description("")]
        public virtual ItemsCollection<Component> Component
        {
            get
            {
                if (this.component == null)
                {
                    this.component = new ItemsCollection<Component>();
                    this.component.SingleItemMode = true;
                }

                return this.component;
            }
        }

        /// <summary>
        /// Recreate component on each row expand
        /// </summary>
        [Meta]
        [DefaultValue(false)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("Recreate component on each row expand")]
        public bool RecreateComponent
        {
            get
            {
                object obj = this.ViewState["RecreateComponent"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["RecreateComponent"] = value;
            }
        }

        /// <summary>
        /// Swallow row body's events
        /// </summary>
        [Meta]
        [DefaultValue(false)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("Swallow row body's events")]
        public bool SwallowBodyEvents
        {
            get
            {
                object obj = this.ViewState["SwallowBodyEvents"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["SwallowBodyEvents"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(0)]
        [Category("3. RowExpander")]
        [Description("")]
        public int ColumnPosition
        {
            get
            {
                object obj = this.ViewState["ColumnPosition"];
                return obj != null ? (int) obj : 0;
            }
            set
            {
                this.ViewState["ColumnPosition"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(true)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("")]
        public bool EnableCaching
        {
            get
            {
                object obj = this.ViewState["EnableCaching"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["EnableCaching"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(true)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("")]
        public bool ExpandOnEnter
        {
            get
            {
                object obj = this.ViewState["ExpandOnEnter"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["ExpandOnEnter"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(true)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("")]
        public bool ExpandOnDblClick
        {
            get
            {
                object obj = this.ViewState["ExpandOnDblClick"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["ExpandOnDblClick"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(true)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("")]
        public bool LazyRender
        {
            get
            {
                object obj = this.ViewState["LazyRender"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["LazyRender"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(false)]
        [ConfigOption]
        [Category("3. RowExpander")]
        [NotifyParentProperty(true)]
        [Description("")]
        public bool SingleExpand
        {
            get
            {
                object obj = this.ViewState["SingleExpand"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["SingleExpand"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal override void PluginAdded()
        {
            base.PluginAdded();

            GridPanel grid = this.PluginOwner as GridPanel;

            if (grid == null)
            {
                throw new InvalidOperationException("The RowExpander plugin can only be added to the GridPanel Control or a Control which inherits from GridPanel.");
            }

            if (!this.PluginOwner.Controls.Contains(this.Template))
            {
                this.PluginOwner.Controls.Add(this.Template);
            }

            if (!this.PluginOwner.LazyItems.Contains(this.Template))
            {
                this.PluginOwner.LazyItems.Add(this.Template);
            }

            if (this.Component.Count > 0)
            {
                if (!this.PluginOwner.Controls.Contains(this.Component[0]))
                {
                    this.PluginOwner.Controls.Add(this.Component[0]);
                }

                if (!this.PluginOwner.LazyItems.Contains(this.Component[0]))
                {
                    this.PluginOwner.LazyItems.Add(this.Component[0]);
                }
            }

            if(this.Page == null)
            {
                this.Init += new EventHandler(RowExpander_Init);
                return;
            }

            this.InitRowExpanderColumn(grid);
        }

        void RowExpander_Init(object sender, EventArgs e)
        {
            this.InitRowExpanderColumn(this.PluginOwner as GridPanel);
        }

        public void InitRowExpanderColumn(GridPanel grid)
        {
            grid.ColumnModel.Columns.Insert(this.ColumnPosition, new ReferenceColumn(this.ClientID));
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal override void PluginRemoved()
        {
            base.PluginRemoved();

            if (this.PluginOwner.Controls.Contains(this.Template))
            {
                this.PluginOwner.Controls.Remove(this.Template);
            }

            if (this.PluginOwner.LazyItems.Contains(this.Template))
            {
                this.PluginOwner.LazyItems.Remove(this.Template);
            }

            if (this.Component.Count > 0)
            {
                if (this.PluginOwner.Controls.Contains(this.Component[0]))
                {
                    this.PluginOwner.Controls.Remove(this.Component[0]);
                }

                if (this.PluginOwner.LazyItems.Contains(this.Component[0]))
                {
                    this.PluginOwner.LazyItems.Remove(this.Component[0]);
                }
            }
        }

        private RowExpanderListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public RowExpanderListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new RowExpanderListeners();
                }

                return this.listeners;
            }
        }

        private RowExpanderDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side DirectEventHandlers")]
        public RowExpanderDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new RowExpanderDirectEvents();
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Toggle (expand/collapse) row
        /// </summary>
        [Meta]
        [Description("Toggle (expand/collapse) row")]
        public virtual void ToggleRow(int row)
        {
            this.Call("toggleRow", row);
        }

        /// <summary>
        /// Expand all rows
        /// </summary>
        [Meta]
        [Description("Expand all rows")]
        public virtual void ExpandAll()
        {
            this.Call("expandAll");
        }

        /// <summary>
        /// Collapse all rows
        /// </summary>
        [Meta]
        [Description("Collapse all rows")]
        public virtual void CollapseAll()
        {
            this.Call("collapseAll");
        }

        /// <summary>
        /// Expand row
        /// </summary>
        [Meta]
        [Description("Expand row")]
        public virtual void ExpandRow(int row)
        {
            this.Call("expandRow", row);
        }

        /// <summary>
        /// Collapse row
        /// </summary>
        [Meta]
        [Description("Collapse row")]
        public virtual void CollapseRow(int row)
        {
            this.Call("collapseRow", row);
        }
    }
}