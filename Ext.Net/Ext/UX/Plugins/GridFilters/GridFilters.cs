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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// GridFilter is a plugin for grids that allow for a slightly more robust representation of filtering than what is provided by the default store.
    /// Filtering is adjusted by the user using the grid's column header menu (this menu can be disabled through configuration). Through this menu users can configure, enable, and disable filters for each column.
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(GridFilters), "Build.ToolboxIcons.GridFilters.bmp")]
    [ToolboxData("<{0}:GridFilters runat=\"server\" />")]
    [Description("GridFilters plugin used for filter by columns")]
    public partial class GridFilters : Plugin
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 2;

                baseList.Add(new ClientStyleItem(typeof(GridFilters), "Ext.Net.Build.Ext.Net.ux.plugins.gridfilters.css.gridfilters-embedded.css", "/ux/plugins/gridfilters/css/gridfilters.css"));
                baseList.Add(new ClientScriptItem(typeof(GridFilters), "Ext.Net.Build.Ext.Net.ux.plugins.gridfilters.gridfilters.js", "/ux/plugins/gridfilters/gridfilters.js"));

                return baseList;
            }
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
                return "Ext.ux.grid.GridFilters";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!this.DesignMode)
            {
                this.Page.LoadComplete += Page_LoadComplete;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            GridPanel grid = this.ParentComponent as GridPanel;

            if (!RequestManager.IsAjaxRequest && grid != null)
            {
                PagingToolbar pBar = null;

                if (grid.BottomBar.Count > 0 && grid.BottomBar[0] is PagingToolbar)
                {
                    pBar = grid.BottomBar[0] as PagingToolbar;
                }
                else if (grid.TopBar.Count > 0 && grid.TopBar[0] is PagingToolbar)
                {
                    pBar = grid.TopBar[0] as PagingToolbar;
                }

                if ((grid.StoreID.IsNotEmpty() || grid.Store.Primary != null) && pBar != null)
                {
                    Store store = grid.Store.Primary ?? (ControlUtils.FindControl(this, grid.StoreID) as Store);
                    if (store != null && store.Proxy.Count != 0 && store.RemotePaging && this.ViewState["Local"] == null)
                    {
                        this.Local = false;
                    }
                }
            }
        }

        /// <summary>
        /// Number of milisecond to defer store updates since the last filter change.
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(500)]
        [NotifyParentProperty(true)]
        [Description("Number of milisecond to defer store updates since the last filter change.")]
        public int UpdateBuffer
        {
            get
            {
                object obj = this.ViewState["UpdateBuffer"];
                return obj == null ? 500 : (int)obj;
            }
            set
            {
                this.ViewState["UpdateBuffer"] = value;
            }
        }

        /// <summary>
        /// The url parameter prefix for the filters.
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("gridfilters")]
        [NotifyParentProperty(true)]
        [Description("The url parameter prefix for the filters.")]
        public string ParamPrefix
        {
            get
            {
                object obj = this.ViewState["ParamPrefix"];
                return obj == null ? "gridfilters" : (string)obj;
            }
            set
            {
                this.ViewState["ParamPrefix"] = value;
            }
        }

        /// <summary>
        /// The css class to be applied to column headers that active filters. Defaults to 'ux-filterd-column'.
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("ux-filtered-column")]
        [NotifyParentProperty(true)]
        [Description("The css class to be applied to column headers that active filters. Defaults to 'ux-filterd-column'.")]
        public string FilterCls
        {
            get
            {
                object obj = this.ViewState["FilterCls"];
                return obj == null ? "ux-filtered-column" : (string)obj;
            }
            set
            {
                this.ViewState["FilterCls"] = value;
            }
        }

        /// <summary>
        /// True to use Ext.data.Store filter functions instead of server side filtering.
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to use Ext.data.Store filter functions instead of server side filtering.")]
        public bool Local
        {
            get
            {
                object obj = this.ViewState["Local"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Local"] = value;
            }
        }

        /// <summary>
        /// True to automagicly reload the datasource when a filter change happens.
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to automagicly reload the datasource when a filter change happens.")]
        public bool AutoReload
        {
            get
            {
                object obj = this.ViewState["AutoReload"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AutoReload"] = value;
            }
        }

        /// <summary>
        /// True to show the filter menus.
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to show the filter menus.")]
        public bool ShowMenu
        {
            get
            {
                object obj = this.ViewState["ShowMenu"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ShowMenu"] = value;
            }
        }

        /// <summary>
        /// The text displayed for the 'Filters' menu item.
        /// </summary>
        [ConfigOption("menuFilterText")]
        [Category("Config Options")]
        [DefaultValue("Filters")]
        [NotifyParentProperty(true)]
        [Description("The text displayed for the 'Filters' menu item.")]
        public string FiltersText
        {
            get
            {
                object obj = this.ViewState["FiltersText"];
                return obj == null ? "Filters" : (string)obj;
            }
            set
            {
                this.ViewState["FiltersText"] = value;
            }
        }

        private GridFilterCollection filters;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("filters", JsonMode.AlwaysArray)]
        [Category("Config Options")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual GridFilterCollection Filters
        {
            get
            {
                if (this.filters == null)
                {
                    this.filters = new GridFilterCollection();
                    this.filters.AfterItemAdd += Filters_AfterItemAdd;
                }

                return this.filters;
            }
        }

        private GridFiltersListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public GridFiltersListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new GridFiltersListeners();
                }

                return this.listeners;
            }
        }

        private GridFiltersDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public GridFiltersDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new GridFiltersDirectEvents();
                }

                return this.directEvents;
            }
        }

        void Filters_AfterItemAdd(GridFilter item)
        {
            item.Plugin = this;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void ClearFilters()
        {
            RequestManager.EnsureDirectEvent();
            GridPanel grid = this.ParentComponent as GridPanel;

            if (grid != null)
            {
                grid.AddScript("{0}.getFilterPlugin().clearFilters();", grid.ClientID);
            }
        }
    }
}
