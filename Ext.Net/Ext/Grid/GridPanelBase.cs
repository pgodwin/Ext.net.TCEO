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
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class GridPanelBase : PanelBase, IStore, INoneContentable
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
                baseList.Capacity += 1;

                baseList.Add(XControl.ExtNetDataItem);

                return baseList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            if (this.AutoExpandColumn.IsNotEmpty())
            {
                bool found = false;
                ColumnBase foundColumn = null;

                foreach (ColumnBase column in this.ColumnModel.Columns)
                {
                    if (column.ColumnID == this.AutoExpandColumn)
                    {
                        found = true;
                        break;
                    }

                    if (column.DataIndex == this.AutoExpandColumn)
                    {
                        foundColumn = column;
                    }
                }

                if (!found && foundColumn != null)
                {
                    foundColumn.ColumnID = this.AutoExpandColumn;
                }
            }

            // TODO: Ask Geoffrey: Is it still required??? At this moment comment out
            //if (!this.DesignMode && RequestManager.IsIE6)
            //{
            //    this.ResourceManager.RegisterClientStyleBlock("grid-header-offset-fix", ".x-grid3-header-offset {width: auto;}");
            //}

            this.CheckStore();

            base.OnPreRender(e);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void CheckStore()
        {
            if (this.IsDynamic && !string.IsNullOrEmpty(this.StoreID))
            {
                return;
            }

            if (this.GetStore() == null)
            {
                throw new StoreNotFoundException("Please define a store for the GridPanel with ID='" + this.ID + "'");
            }
        }

        /// <summary>
        /// The id of a column in this grid that should expand to fill unused space. This id can not be 0.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue("")]
        [Description("The id of a column in this grid that should expand to fill unused space. This id can not be 0.")]
        public virtual string AutoExpandColumn
        {
            get
            {
                return (string)this.ViewState["AutoExpandColumn"] ?? "";
            }
            set
            {
                this.ViewState["AutoExpandColumn"] = value;
            }
        }

        /// <summary>
        /// The maximum width the autoExpandColumn can have (if enabled). Defaults to 1000.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(1000)]
        [Description("The maximum width the autoExpandColumn can have (if enabled). Defaults to 1000.")]
        public virtual int AutoExpandMax
        {
            get
            {
                object obj = this.ViewState["AutoExpandMax"];
                return (obj == null) ? 1000 : (int)obj;
            }
            set
            {
                this.ViewState["AutoExpandMax"] = value;
            }
        }

        /// <summary>
        /// The minimum width the autoExpandColumn can have (if enabled). defaults to 50.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(50)]
        [Description("The minimum width the autoExpandColumn can have (if enabled). defaults to 50.")]
        public virtual int AutoExpandMin
        {
            get
            {
                object obj = this.ViewState["AutoExpandMin"];
                return (obj == null) ? 50 : (int)obj;
            }
            set
            {
                this.ViewState["AutoExpandMin"] = value;
            }
        }

        /// <summary>
        /// True to clear editor filter before start editing. Default is true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(true)]
        [Description("True to clear editor filter before start editing. Default is true.")]
        public virtual bool ClearEditorFilter
        {
            get
            {
                object obj = this.ViewState["ClearEditorFilter"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ClearEditorFilter"] = value;
            }
        }

        /// <summary>
        /// true to add css for column separation lines. Default is false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(false)]
        [Description("true to add css for column separation lines. Default is false.")]
        public virtual bool ColumnLines
        {
            get
            {
                object obj = this.ViewState["ColumnLines"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ColumnLines"] = value;
            }
        }

        /// <summary>
        /// The DD group this GridPanel belongs to. Defaults to 'GridDD' if not specified.
        /// </summary>
        [Meta]
        [ConfigOption("ddGroup")]
        [Category("7. GridPanel")]
        [DefaultValue("GridDD")]
        [Description("The DD group this GridPanel belongs to. Defaults to 'GridDD' if not specified.")]
        public virtual string DDGroup
        {
            get
            {
                return (string)this.ViewState["DDGroup"] ?? "GridDD";
            }
            set
            {
                this.ViewState["DDGroup"] = value;
            }
        }

        /// <summary>
        /// Configures the text in the drag proxy. Defaults to: '{0} selected row{1}' {0} is replaced with the number of selected rows.
        /// </summary>
        [Meta]
        [ConfigOption("ddText")]
        [Category("7. GridPanel")]
        [DefaultValue("{0} selected row{1}")]
        [Description("Configures the text in the drag proxy. Defaults to: '{0} selected row{1}' {0} is replaced with the number of selected rows.")]
        public virtual string DDText
        {
            get
            {
                return (string)this.ViewState["DDText"] ?? "{0} selected row{1}";
            }
            set
            {
                this.ViewState["DDText"] = value;
            }
        }

        /// <summary>
        /// True to enable deferred row rendering. Default is true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(true)]
        [Description("True to enable deferred row rendering. Default is true.")]
        public virtual bool DeferRowRender
        {
            get
            {
                object obj = this.ViewState["DeferRowRender"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["DeferRowRender"] = value;
            }
        }

        /// <summary>
        /// True to disable selections in the grid (defaults to false). - ignored a SelectionModel is specified.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(false)]
        [Description("True to disable selections in the grid (defaults to false). - ignored a SelectionModel is specified.")]
        public virtual bool DisableSelection
        {
            get
            {
                object obj = this.ViewState["DisableSelection"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["DisableSelection"] = value;
            }
        }

        /// <summary>
        /// True to enable hiding of columns with the header context menu.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(true)]
        [Description("True to enable hiding of columns with the header context menu.")]
        public virtual bool EnableColumnHide
        {
            get
            {
                object obj = this.ViewState["EnableColumnHide"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["EnableColumnHide"] = value;
            }
        }

        /// <summary>
        /// True to enable drag and drop reorder of columns.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(true)]
        [Description("True to enable drag and drop reorder of columns.")]
        public virtual bool EnableColumnMove
        {
            get
            {
                object obj = this.ViewState["EnableColumnMove"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["EnableColumnMove"] = value;
            }
        }

        /// <summary>
        /// False to turn off column resizing for the whole grid (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(true)]
        [Description("False to turn off column resizing for the whole grid (defaults to true).")]
        public virtual bool EnableColumnResize
        {
            get
            {
                object obj = this.ViewState["EnableColumnResize"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["EnableColumnResize"] = value;
            }
        }

        /// <summary>
        /// True to enable drag and drop of rows.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(false)]
        [Description("True to enable drag and drop of rows.")]
        public virtual bool EnableDragDrop
        {
            get
            {
                object obj = this.ViewState["EnableDragDrop"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["EnableDragDrop"] = value;
            }
        }

        /// <summary>
        /// True to enable the drop down button for menu in the headers.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(true)]
        [Description("True to enable the drop down button for menu in the headers.")]
        public virtual bool EnableHdMenu
        {
            get
            {
                object obj = this.ViewState["EnableHdMenu"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["EnableHdMenu"] = value;
            }
        }

        /// <summary>
        /// True to hide the grid's header (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetHideHeaders")]
        [Category("7. GridPanel")]
        [DefaultValue(false)]
        [Description("True to hide the grid's header (defaults to false).")]
        public virtual bool HideHeaders
        {
            get
            {
                object obj = this.ViewState["HideHeaders"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideHeaders"] = value;
            }
        }

        private LoadMask loadMask;

        /// <summary>
        /// An Ext.LoadMask to mask the grid while loading (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption("loadMask", typeof(LoadMaskJsonConverter))]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An Ext.LoadMask to mask the grid while loading (defaults to false).")]
        public override LoadMask LoadMask
        {
            get
            {
                if (this.loadMask == null)
                {
                    this.loadMask = new LoadMask();
                    this.loadMask.TrackViewState();
                }

                return this.loadMask;
            }
        }

        private SaveMask saveMask;

        /// <summary>
        /// An Ext.SaveMask to mask the grid while saving (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption("saveMask", typeof(LoadMaskJsonConverter))]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An Ext.SaveMask to mask the grid while saving (defaults to false).")]
        public SaveMask SaveMask
        {
            get
            {
                if (this.saveMask == null)
                {
                    this.saveMask = new SaveMask();
                    this.saveMask.TrackViewState();
                }

                return this.saveMask;
            }
        }

        /// <summary>
        /// Sets the maximum height of the grid - ignored if autoHeight is not on.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(typeof(Unit), "400")]
        [Description("Sets the maximum height of the grid - ignored if autoHeight is not on.")]
        public override Unit MaxHeight
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["MaxHeight"], Unit.Pixel(400), "MaxHeight");
            }
            set
            {
                this.ViewState["MaxHeight"] = value;
            }
        }

        /// <summary>
        /// The minimum width a column can be resized to. Defaults to 25.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(typeof(Unit), "25")]
        [Description("The minimum width a column can be resized to. Defaults to 25.")]
        public virtual Unit MinColumnWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["MinColumnWidth"], Unit.Pixel(25), "MinColumnWidth");
            }
            set
            {
                this.ViewState["MinColumnWidth"] = value;
            }
        }

        /// <summary>
        /// True to autoSize the grid when the window resizes. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(true)]
        [Description("True to autoSize the grid when the window resizes. Defaults to true.")]
        public virtual bool MonitorWindowResize
        {
            get
            {
                object obj = this.ViewState["MonitorWindowResize"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["MonitorWindowResize"] = value;
            }
        }

        private SelectionModelCollection selectionModel;

        /// <summary>
        /// Any subclass of AbstractSelectionModel that will provide the selection model for the grid (defaults to Ext.grid.RowSelectionModel if not specified).
        /// </summary>
        [Meta]
        [ConfigOption("sm>Primary")]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Any subclass of AbstractSelectionModel that will provide the selection model for the grid (defaults to Ext.grid.RowSelectionModel if not specified).")]
        public virtual SelectionModelCollection SelectionModel
        {
            get
            {
                if (this.selectionModel == null)
                {
                    this.selectionModel = new SelectionModelCollection();
                    this.selectionModel.AfterItemAdd += this.AfterSelModelAdd;
                    this.selectionModel.AfterItemRemove += this.AfterSelModelRemove;
                }

                return this.selectionModel;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void AfterSelModelAdd(Observable item)
        {
            this.Controls.AddAt(0, item);
            this.LazyItems.Insert(0, item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void AfterSelModelRemove(Observable item)
        {
            this.Controls.Remove(item);
            this.LazyItems.Remove(item);
        }

        /// <summary>
        /// The data store to use.
        /// </summary>
        [Meta]
        [ConfigOption("store", JsonMode.ToClientID)]
        [Category("7. GridPanel")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [Description("The data store to use.")]
        public virtual string StoreID
        {
            get
            {
                return (string)this.ViewState["StoreID"] ?? "";
            }
            set
            {
                this.ViewState["StoreID"] = value;
                this.ListenStore();
            }
        }

        private StoreCollection store;

        /// <summary>
        /// The Ext.Net.Store the grid should use as its data source (required).
        /// </summary>
        [Meta]
        [ConfigOption("store>Primary", 1)]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Ext.Net.Store the grid should use as its data source (required).")]
        public virtual StoreCollection Store
        {
            get
            {
                if (this.store == null)
                {
                    this.store = new StoreCollection();
                    this.store.AfterItemAdd += this.AfterStoreAdd;
                    this.store.AfterItemRemove += this.AfterSelModelRemove;
                }

                return this.store;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void AfterStoreAdd(Store item)
        {
            //item.IsLazyInstance = true;
            this.Controls.AddAt(0, item);
            this.LazyItems.Insert(0, item);
            this.ListenStore();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.ListenStore();
        }

        private void ListenStore()
        {
            if (!this.DesignMode && this.Page != null && (this.StoreID.IsNotEmpty() || this.Store.Primary != null) && !RequestManager.IsAjaxRequest)
            {
                this.EnsureChildControls();
                Store store = this.Store.Primary ?? (ControlUtils.FindControl(this, this.StoreID) as Store);

                if (store != null)
                {
                    store.BeforeClientInit -= Store_BeforeClientInit;
                    store.BeforeClientInit += Store_BeforeClientInit;
                }
            }
        }

        void Store_BeforeClientInit(Observable sender)
        {
            Store store = this.Store.Primary ?? ControlUtils.FindControl(this, this.StoreID) as Store;

            if (store != null)
            {
                //It doesn't need show mask for store ajax postback
                //store.DirectEventConfig.EventMask.ShowMask = false;

                if (store.Proxy.Count == 0)
                {
                    if (store.IsAutoLoadUndefined)
                    {
                        store.AutoLoad = true;
                    }

                    PagingToolbar pBar = null;

                    if (this.BottomBar.Count > 0 && this.BottomBar[0] is PagingToolbar)
                    {
                        pBar = this.BottomBar[0] as PagingToolbar;
                    }
                    else if (this.TopBar.Count > 0 && this.TopBar[0] is PagingToolbar)
                    {
                        pBar = this.TopBar[0] as PagingToolbar;
                    }

                    if (pBar != null)
                    {
                        if (store.BaseParams["start"] == null)
                        {
                            store.BaseParams.Add(new Parameter("start", "0", ParameterMode.Raw));
                        }

                        if (store.BaseParams["limit"] == null)
                        {
                            store.BaseParams.Add(new Parameter("limit", pBar.PageSize.ToString(), ParameterMode.Raw));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        //[ConfigOption("pbarID")]
        [Category("7. GridPanel")]
        [DefaultValue("")]
        [Description("")]
        protected internal virtual string PbarID
        {
            get
            {
                PagingToolbar pBar = null;

                if (this.BottomBar.Count > 0 && this.BottomBar[0] is PagingToolbar)
                {
                    pBar = this.BottomBar[0] as PagingToolbar;
                }
                else if (this.TopBar.Count > 0 && this.TopBar[0] is PagingToolbar)
                {
                    pBar = this.TopBar[0] as PagingToolbar;
                }

                return (pBar != null && pBar.Visible) ? pBar.ClientID : "";
            }
        }

        /// <summary>
        /// True to stripe the rows. Default is false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(false)]
        [Description("True to stripe the rows. Default is false.")]
        public virtual bool StripeRows
        {
            get
            {
                object obj = this.ViewState["StripeRows"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["StripeRows"] = value;
            }
        }

        /// <summary>
        /// True to highlight rows when the mouse is over. Default is true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(false)]
        [Description("True to highlight rows when the mouse is over. Default is true.")]
        public virtual bool TrackMouseOver
        {
            get
            {
                object obj = this.ViewState["TrackMouseOver"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["TrackMouseOver"] = value;
            }
        }

        private GridViewCollection view;

        /// <summary>
        /// The Ext.grid.GridView used by the grid. This can be set before a call to render().
        /// </summary>
        [Meta]
        [ConfigOption("view>View")]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Ext.grid.GridView used by the grid. This can be set before a call to render().")]
        public virtual GridViewCollection View
        {
            get
            {
                if (this.view == null)
                {
                    this.view = new GridViewCollection();
                    this.view.AfterItemAdd += this.AfterViewAdd;
                    this.view.AfterItemRemove += this.AfterViewRemove;
                }

                return this.view;
            }
        }

        private void AfterViewAdd(GridView item)
        {
            item.ParentGrid = this;
            this.Controls.AddAt(0, item);
            this.LazyItems.Insert(0, item);

            XTemplate tpl = item.Templates.Header;

            if (tpl != null)
            {
                this.Controls.AddAt(0, tpl);
                this.LazyItems.Insert(0, tpl);
            }

            foreach (HeaderRow row in item.HeaderRows)
            {
                foreach (HeaderColumn column in row.Columns)
                {
                    this.EnsureHeaderColumn(item, column);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void AfterViewRemove(GridView item)
        {
            XTemplate tpl = item.Templates.Header;

            if (tpl != null)
            {
                this.Controls.Remove(item.Templates.Header);
                this.LazyItems.Remove(item.Templates.Header);
            }

            this.Controls.Remove(item);
            this.LazyItems.Remove(item);
        }

        internal void EnsureHeaderColumn(GridView item, HeaderColumn column)
        {
            if (column.Component.Count > 0)
            {
                this.EnsureHeaderControl(item, column.Component[0]);
            }
        }

        internal void EnsureHeaderControl(GridView item, Component c)
        {
            if (!this.Controls.Contains(c))
            {
                this.Controls.AddAt(0, c);
            }

            if (!this.LazyItems.Contains(c))
            {
                this.LazyItems.Insert(0, c);
            }
        }

        /// <summary>
        /// True to automatically HTML encode and decode values pre and post edit (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(false)]
        [Description("True to automatically HTML encode and decode values pre and post edit (defaults to false).")]
        public virtual bool AutoEncode
        {
            get
            {
                object obj = this.ViewState["AutoEncode"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoEncode"] = value;
            }
        }

        /// <summary>
        /// The number of clicks on a cell required to display the cell's editor (defaults to 2).
        /// Available values: 2, 1, 0
        /// Setting this option to 0 means that mousedown on the selected cell starts editing that cell.
        /// </summary>
        [Meta]
        [Category("7. GridPanel")]
        [DefaultValue(2)]
        [Description("The number of clicks on a cell required to display the cell's editor (defaults to 2).")]
        public virtual int ClicksToEdit
        {
            get
            {
                object obj = this.ViewState["ClicksToEdit"];
                return (obj == null) ? 2 : (int)obj;
            }
            set
            {
                this.ViewState["ClicksToEdit"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("clicksToEdit", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string ClicksToEditProxy
        {
            get
            {
                switch (this.ClicksToEdit)
                {
                    case 2:
                        return "";
                    case 0:
                        return JSON.Serialize("auto");
                    default:
                        return "1";
                }
            }
        }

        /// <summary>
        /// Set init selection without event firing
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(false)]
        [Description("Set init selection without event firing")]
        public virtual bool FireSelectOnLoad
        {
            get
            {
                object obj = this.ViewState["FireSelectOnLoad"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["FireSelectOnLoad"] = value;
            }
        }

        /// <summary>
        /// True to force validation even if the value is unmodified (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(false)]
        [Description("True to force validation even if the value is unmodified (defaults to false)")]
        public virtual bool ForceValidation
        {
            get
            {
                object obj = this.ViewState["ForceValidation"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ForceValidation"] = value;
            }
        }

        private int DefaultSelectionSavingBuffer()
        {
            if (this.SelectionModel.Primary != null && this.SelectionModel.Primary is RowSelectionModel)
            {
                return ((RowSelectionModel)this.SelectionModel.Primary).SingleSelect ? 0 : 10;
            }

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue(0)]
        [Description("")]
        public virtual int SelectionSavingBuffer
        {
            get
            {
                object obj = this.ViewState["SelectionSavingBuffer"];
                return (obj == null) ? this.DefaultSelectionSavingBuffer() : (int)obj;
            }
            set
            {
                this.ViewState["SelectionSavingBuffer"] = value;
            }
        }

        /// <summary>
        /// True to enable saving selection during paging. Default is true.
        /// </summary>
        [Meta]
        [Category("7. GridPanel")]
        [DefaultValue(SelectionMemoryMode.Auto)]
        [Description("True to enable saving selection during paging. Default is true.")]
        public virtual SelectionMemoryMode SelectionMemory
        {
            get
            {
                object obj = this.ViewState["SelectionMemory"];
                return (obj == null) ? SelectionMemoryMode.Auto : (SelectionMemoryMode)obj;
            }
            set
            {
                this.ViewState["SelectionMemory"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("selectionMemory")]
        [DefaultValue(true)]
        [Description("")]
        protected bool SelectionMemoryProxy
        {
            get
            {
                switch (this.SelectionMemory)
                {
                    case SelectionMemoryMode.Auto:
                        RowSelectionModel sm = this.SelectionModel.Primary as RowSelectionModel;

                        if (sm != null && sm.SingleSelect)
                        {
                            return false;
                        }

                        return this.PbarID.IsNotEmpty();
                    case SelectionMemoryMode.Disabled:
                        return false;
                    case SelectionMemoryMode.Enabled:
                        return true;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GridPanel")]
        [DefaultValue("")]
        [Description("")]
        public virtual string MemoryIDField
        {
            get
            {
                return (string)this.ViewState["MemoryIDField"] ?? "";
            }
            set
            {
                this.ViewState["MemoryIDField"] = value;
            }
        }

        private JFunction getDragDropText;

        /// <summary>
        /// Called to get grid's drag proxy text, by default returns this.ddText.
        /// Parameters:
        ///    e : The mouse up event
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Called to get grid's drag proxy text, by default returns this.ddText.")]
        public virtual JFunction GetDragDropText
        {
            get
            {
                if (this.getDragDropText == null)
                {
                    this.getDragDropText = new JFunction();
                }

                return this.getDragDropText;
            }
        }

        private ColumnModel columnModel;

        /// <summary>
        /// The Ext.grid.ColumnModel to use when rendering the grid (required).
        /// </summary>
        [Meta]
        [ConfigOption("cm", typeof(LazyControlJsonConverter))]
        [Category("7. GridPanel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Ext.grid.ColumnModel to use when rendering the grid (required).")]
        public virtual ColumnModel ColumnModel
        {
            get
            {
                if (this.columnModel == null)
                {
                    this.columnModel = new ColumnModel();
                    this.columnModel.ParentGrid = this;
                    this.Controls.Add(this.columnModel);
                    this.LazyItems.Add(this.columnModel);
                }

                return this.columnModel;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.ColumnModel.EnsureChildControlsInternal();
        }

        /// <summary>
        /// Add new column to the end.
        /// </summary>
        /// <param name="column"></param>
        [Meta]
        [Description("Add new column to the end.")]
        public virtual void AddColumn(ColumnBase column)
        {
            const string template = "{0}.addColumn({1});";
            this.AddScript(template, this.ClientID, column.Serialize());
        }

        /// <summary>
        /// Insert new column.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="column"></param>
        [Meta]
        [Description("Insert new column.")]
        public virtual void InsertColumn(int index, ColumnBase column)
        {
            const string template = "{0}.insertColumn({1}, {2});";
            this.AddScript(template, this.ClientID, index, column.Serialize());
        }

        /// <summary>
        /// Remove column.
        /// </summary>
        /// <param name="index"></param>
        [Meta]
        [Description("Remove column.")]
        public virtual void RemoveColumn(int index)
        {
            const string template = "{0}.removeColumn({1});";
            this.AddScript(template, this.ClientID, index);
        }

        /// <summary>
        /// Reconfigure columns.
        /// </summary>
        [Meta]
        [Description("Reconfigure columns.")]
        public virtual void Reconfigure()
        {
            const string template = "{0}.reconfigureColumns({1});";
            this.AddScript(template, this.ClientID, this.ColumnModel.Serialize());
        }

        /// <summary>
        /// Reconfigures the grid to use a different Store and Column Model and fires the 'reconfigure' event. The View will be bound to the new objects and refreshed.
        /// Be aware that upon reconfiguring a GridPanel, certain existing settings may become invalidated. For example the configured autoExpandColumn may no longer exist in the new ColumnModel. Also, an existing PagingToolbar will still be bound to the old Store, and will need rebinding. Any plugins might also need reconfiguring with the new data.
        /// </summary>
        /// <param name="store">Store ClientID</param>
        /// <param name="cm">New ColumnModel</param>
        public virtual void Reconfigure(string store, ColumnModel cm)
        {
            this.Call("reconfigure", new JRawValue(store), new JRawValue("new {0}({1})".FormatWith(cm.InstanceOf, cm.Serialize())));
        }

        /// <summary>
        /// Reconfigures the grid to use a different Store and Column Model and fires the 'reconfigure' event. The View will be bound to the new objects and refreshed.
        /// Be aware that upon reconfiguring a GridPanel, certain existing settings may become invalidated. For example the configured autoExpandColumn may no longer exist in the new ColumnModel. Also, an existing PagingToolbar will still be bound to the old Store, and will need rebinding. Any plugins might also need reconfiguring with the new data.
        /// </summary>
        /// <param name="store">Store ClientID</param>
        public virtual void Reconfigure(string store)
        {
            this.Call("reconfigure", new JRawValue(store), new JRawValue(this.ClientID.ConcatWith(".cm")));
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Insert record
        /// </summary>
        /// <param name="index"></param>
        /// <param name="values"></param>
        [Meta]
        [Description("Insert record")]
        public virtual void InsertRecord(int index, object values)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("insertRecord", index, values);
        }

        /// <summary>
        /// Insert record
        /// </summary>
        /// <param name="index"></param>
        /// <param name="values"></param>
        /// <param name="commit">Commit</param>
        [Meta]
        [Description("Insert record")]
        public virtual void InsertRecord(int index, object values, bool commit)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("insertRecord", index, values, commit);
        }

        /// <summary>
        /// Add record
        /// </summary>
        /// <param name="values"></param>
        [Meta]
        [Description("Add record")]
        public virtual void AddRecord(object values)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("addRecord", values);
        }

        /// <summary>
        /// Add record
        /// </summary>
        /// <param name="values"></param>
        /// <param name="commit"></param>
        [Meta]
        [Description("Add record")]
        public virtual void AddRecord(object values, bool commit)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("addRecord", values, commit);
        }

        /// <summary>
        /// Delete selected records
        /// </summary>
        [Meta]
        [Description("Delete selected records")]
        public virtual void DeleteSelected()
        {
            RequestManager.EnsureDirectEvent();

            this.Call("deleteSelected");
        }

        /// <summary>
        /// Refresh view
        /// </summary>
        [Meta]
        [Description("Refresh view")]
        public virtual void RefreshView()
        {
            RequestManager.EnsureDirectEvent();

            string template = "{0}.getView().refresh(true);";
            this.AddScript(template, this.ClientID);
        }

        /// <summary>
        /// Show/Hide the grid's header.
        /// </summary>
        /// <param name="hide"></param>
        [Description("Show/Hide the grid's header.")]
        internal virtual void SetHideHeaders(bool hide)
        {
            RequestManager.EnsureDirectEvent();

            this.AddScript("{0}.getView().mainHd.setDisplayed({1});", this.ClientID, JSON.Serialize(!hide));
        }

        /// <summary>
        /// Starts editing the specified for the specified row/column
        /// </summary>
        /// <param name="rowIndex">row index</param>
        /// <param name="colIndex">column index</param>
        [Meta]
        [Description("Starts editing the specified for the specified row/column")]
        public virtual void StartEditing(int rowIndex, int colIndex)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("startEditing", rowIndex, colIndex);
        }

        /// <summary>
        /// Stops any active editing
        /// </summary>
        /// <param name="cancel">True to cancel any changes</param>
        [Meta]
        [Description("Stops any active editing")]
        public virtual void StopEditing(bool cancel)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("stopEditing", cancel);
        }

        /// <summary>
        /// Stops any active editing
        /// </summary>
        [Meta]
        [Description("Stops any active editing")]
        public virtual void StopEditing()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("stopEditing");
        }

        /// <summary>
        /// Update cell content
        /// </summary>
        /// <param name="rowIndex">row index</param>
        /// <param name="dataIndex">data index</param>
        /// <param name="value">value</param>
        [Meta]
        [Description("Update cell content")]
        public virtual void UpdateCell(int rowIndex, string dataIndex, object value)
        {
            RequestManager.EnsureDirectEvent();
            this.AddScript("{0}.store.getAt({1}).set({2},{3});", this.ClientID, rowIndex, JSON.Serialize(dataIndex), JSON.Serialize(value));
        }

        /// <summary>
        /// Update cell content
        /// </summary>
        /// <param name="id">id value</param>
        /// <param name="dataIndex">data index</param>
        /// <param name="value">value</param>
        [Meta]
        [Description("Update cell content")]
        public virtual void UpdateCell(object id, string dataIndex, object value)
        {
            RequestManager.EnsureDirectEvent();
            this.AddScript("{0}.store.getById({1}).set({2},{3});", this.ClientID, JSON.Serialize(id), JSON.Serialize(dataIndex), JSON.Serialize(value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Store GetStore()
        {
            if (this.Store.Primary != null)
            {
                return this.Store.Primary;
            }

            if (this.StoreID.IsNotEmpty())
            {
                return ControlUtils.FindControl<Store>(this, this.StoreID, true);
            }

            return null;
        }

        /// <summary>
        /// Returns a GridPanel's View
        /// </summary>
        public GridView GetView()
        {
            return this.View.View;
        }

        /// <summary>
        /// Returns a GridPanel's Selection model
        /// </summary>
        public AbstractSelectionModel GetSelectionModel()
        {
            return this.SelectionModel.Primary;
        }
    }
}