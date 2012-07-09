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

using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// This class encapsulates the user interface of an Ext.grid.GridPanel. Methods of this 
    /// class may be used to access user interface elements to enable special display effects. 
    /// Do not change the DOM structure of the user interface.
    ///
    /// This class does not provide ways to manipulate the underlying data. The data model of a 
    /// Grid is held in an Ext.data.Store.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("This class encapsulates the user interface of an Ext.grid.GridPanel. Methods of this class may be used to access user interface elements to enable special display effects. Do not change the DOM structure of the user interface.This class does not provide ways to manipulate the underlying data. The data model of a Grid is held in an Ext.data.Store.")]
    public partial class GridView : LazyObservable
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public GridView() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.GridView";
            }
        }

        private GridPanelBase parentGrid;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public GridPanelBase ParentGrid
        {
            get
            {
                return this.parentGrid;
            }
            internal set
            {
                this.parentGrid = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;

                if (this.RegisterAllResources || this.HeaderGroupRows.Count>0)
                {
                    baseList.Capacity += 2;

                    baseList.Add(new ClientStyleItem(typeof(GridView), "Ext.Net.Build.Ext.Net.ux.plugins.columnheadergroup.resources.css.ColumnHeaderGroup-embedded.css", "/ux/plugins/columnheadergroup/resources/css/ColumnHeaderGroup.css"));
                    baseList.Add(new ClientScriptItem(typeof(GridView), "Ext.Net.Build.Ext.Net.ux.plugins.columnheadergroup.ColumnHeaderGroup.js", "/ux/plugins/columnheadergroup/ColumnHeaderGroup.js"));
                }

                return baseList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void OnBeforeClientInitHandler()
        {
            base.OnBeforeClientInitHandler();
            
            if (this.GetRowClass != null && this.GetRowClass.Handler.IsNotEmpty())
            {
                this.GetRowClass.FormatHandler = false;
                this.GetRowClass.Args = new string[] { "record", "index", "rowParams", "store" };
            }
        }

        /// <summary>
        /// True to auto expand the columns to fit the grid when the grid is created.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. GridView")]
        [DefaultValue(false)]
        [Description("True to auto expand the columns to fit the grid when the grid is created.")]
        public virtual bool AutoFill
        {
            get
            {
                object obj = this.ViewState["AutoFill"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoFill"] = value;
            }
        }

        /// <summary>
        /// The text displayed in the \"Columns\" menu item
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. GridView")]
        [DefaultValue("")]
        [Description("The text displayed in the \"Columns\" menu item")]
        public virtual string ColumnsText
        {
            get
            {
                return (string)this.ViewState["ColumnsText"] ?? "";
            }
            set
            {
                this.ViewState["ColumnsText"] = value;
            }
        }

        /// <summary>
        /// The selector used to find cells internally
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. GridView")]
        [DefaultValue("")]
        [Description("The selector used to find cells internally")]
        public virtual string CellSelector
        {
            get
            {
                return (string)this.ViewState["CellSelector"] ?? "";
            }
            set
            {
                this.ViewState["CellSelector"] = value;
            }
        }

        /// <summary>
        /// The number of levels to search for cells in event delegation (defaults to 4)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. GridView")]
        [DefaultValue(4)]
        [Description("The number of levels to search for cells in event delegation (defaults to 4)")]
        public virtual int CellSelectorDepth
        {
            get
            {
                object obj = this.ViewState["CellSelectorDepth"];
                return (obj == null) ? 4 : (int)obj;
            }
            set
            {
                this.ViewState["CellSelectorDepth"] = value;
            }
        }

        /// <summary>
        /// True to defer emptyText being applied until the store's first load
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. GridView")]
        [DefaultValue(true)]
        [Description("True to defer emptyText being applied until the store's first load")]
        public virtual bool DeferEmptyText
        {
            get
            {
                object obj = this.ViewState["DeferEmptyText"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["DeferEmptyText"] = value;
            }
        }


        /// <summary>
        /// Default text to display in the grid body when no rows are available (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. GridView")]
        [DefaultValue("")]
        [Description("Default text to display in the grid body when no rows are available (defaults to '').")]
        public virtual string EmptyText
        {
            get
            {
                return (string)this.ViewState["EmptyText"] ?? "";
            }
            set
            {
                this.ViewState["EmptyText"] = value;
            }
        }

        /// <summary>
        /// True to add a second TR element per row that can be used to provide a row body that spans 
        /// beneath the data row. Use the getRowClass method's rowParams config to customize the row body.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. GridView")]
        [DefaultValue(false)]
        [Description("True to add a second TR element per row that can be used to provide a row body that spans beneath the data row. Use the getRowClass method's rowParams config to customize the row body.")]
        public virtual bool EnableRowBody
        {
            get
            {
                object obj = this.ViewState["EnableRowBody"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["EnableRowBody"] = value;
            }
        }

        /// <summary>
        /// True to auto expand/contract the size of the columns to fit the grid width and prevent 
        /// horizontal scrolling.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. GridView")]
        [DefaultValue(false)]
        [Description("True to auto expand/contract the size of the columns to fit the grid width and prevent horizontal scrolling.")]
        public virtual bool ForceFit
        {
            get
            {
                object obj = this.ViewState["ForceFit"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ForceFit"] = value;
            }
        }

        /// <summary>
        /// True to disable the grid column headers (defaults to false). Use the ColumnModel menuDisabled config to disable the menu for individual columns. While this config is true the following will be disabled:
        ///  - clicking on header to sort
        ///  - the trigger to reveal the menu.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. GridView")]
        [DefaultValue(false)]
        [Description("True to disable the grid column headers (defaults to false).")]
        public virtual bool HeadersDisabled
        {
            get
            {
                object obj = this.ViewState["HeadersDisabled"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HeadersDisabled"] = value;
            }
        }

        /// <summary>
        /// The CSS class to add to the header cell when its menu is visible. Defaults to 'x-grid3-hd-menu-open'
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. GridView")]
        [DefaultValue("x-grid3-hd-menu-open")]
        [Description("The CSS class to add to the header cell when its menu is visible. Defaults to 'x-grid3-hd-menu-open'")]
        public virtual string HeaderMenuOpenCls
        {
            get
            {
                return (string)this.ViewState["HeaderMenuOpenCls"] ?? "x-grid3-hd-menu-open";
            }
            set
            {
                this.ViewState["HeaderMenuOpenCls"] = value;
            }
        }

        /// <summary>
        /// The CSS class added to each row when it is hovered over. Defaults to 'x-grid3-row-over'
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. GridView")]
        [DefaultValue("x-grid3-row-over")]
        [Description("The CSS class added to each row when it is hovered over. Defaults to 'x-grid3-row-over'")]
        public virtual string RowOverCls
        {
            get
            {
                return (string)this.ViewState["RowOverCls"] ?? "x-grid3-row-over";
            }
            set
            {
                this.ViewState["RowOverCls"] = value;
            }
        }

        /// <summary>
        /// The selector used to find rows internally
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. GridView")]
        [DefaultValue("")]
        [Description("The selector used to find rows internally")]
        public virtual string RowSelector
        {
            get
            {
                return (string)this.ViewState["RowSelector"] ?? "";
            }
            set
            {
                this.ViewState["RowSelector"] = value;
            }
        }

        /// <summary>
        /// The number of levels to search for rows in event delegation (defaults to 10)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. GridView")]
        [DefaultValue(10)]
        [Description("The number of levels to search for rows in event delegation (defaults to 10)")]
        public virtual int RowSelectorDepth
        {
            get
            {
                object obj = this.ViewState["RowSelectorDepth"];
                return (obj == null) ? 10 : (int)obj;
            }
            set
            {
                this.ViewState["RowSelectorDepth"] = value;
            }
        }

        /// <summary>
        /// The selector used to find row bodies internally (defaults to <tt>'div.x-grid3-row'</tt>)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. GridView")]
        [DefaultValue("div.x-grid3-row-body")]
        [Description("The selector used to find row bodies internally (defaults to <tt>'div.x-grid3-row'</tt>)")]
        public virtual string RowBodySelector
        {
            get
            {
                return (string)this.ViewState["RowBodySelector"] ?? "div.x-grid3-row-body";
            }
            set
            {
                this.ViewState["RowBodySelector"] = value;
            }
        }

        /// <summary>
        /// The number of levels to search for row bodies in event delegation (defaults to <tt>10</tt>)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. GridView")]
        [DefaultValue(10)]
        [Description("The number of levels to search for row bodies in event delegation (defaults to <tt>10</tt>)")]
        public virtual int RowBodySelectorDepth
        {
            get
            {
                object obj = this.ViewState["RowBodySelectorDepth"];
                return (obj == null) ? 10 : (int)obj;
            }
            set
            {
                this.ViewState["RowBodySelectorDepth"] = value;
            }
        }

        /// <summary>
        /// The amount of space to reserve for the scrollbar (defaults to 19 pixels)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. GridView")]
        [DefaultValue(19)]
        [Description("The amount of space to reserve for the scrollbar (defaults to 19 pixels)")]
        public virtual int ScrollOffset
        {
            get
            {
                object obj = this.ViewState["ScrollOffset"];
                return (obj == null) ? 19 : (int)obj;
            }
            set
            {
                this.ViewState["ScrollOffset"] = value;
            }
        }

        /// <summary>
        /// The text displayed in the \"Sort Ascending\" menu item
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. GridView")]
        [DefaultValue("")]
        [Description("The text displayed in the \"Sort Ascending\" menu item")]
        public virtual string SortAscText
        {
            get
            {
                return (string)this.ViewState["SortAscText"] ?? "";
            }
            set
            {
                this.ViewState["SortAscText"] = value;
            }
        }

        /// <summary>
        /// The text displayed in the \"Sort Descending\" menu item
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. GridView")]
        [DefaultValue("")]
        [Description("The text displayed in the \"Sort Descending\" menu item")]
        public virtual string SortDescText
        {
            get
            {
                return (string)this.ViewState["SortDescText"] ?? "";
            }
            set
            {
                this.ViewState["SortDescText"] = value;
            }
        }

        /// <summary>
        /// The CSS class applied to a selected row (defaults to "x-grid3-row-selected").
        /// An example overriding the default styling:
        /// .x-grid3-row-selected {background-color: yellow;}
        /// Note that this only controls the row, and will not do anything for the text inside it. To style inner facets (like text) use something like:
        /// .x-grid3-row-selected .x-grid3-cell-inner {
        ///    color: #FFCC00;
        /// }
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. GridView")]
        [DefaultValue("x-grid3-row-selected")]
        [Description("The CSS class applied to a selected row (defaults to \"x-grid3-row-selected\").")]
        public virtual string SelectedRowClass
        {
            get
            {
                return (string)this.ViewState["SelectedRowClass"] ?? "x-grid3-row-selected";
            }
            set
            {
                this.ViewState["SelectedRowClass"] = value;
            }
        }

        /// <summary>
        /// The CSS class applied to a header when it is asc sorted.
        /// </summary>
        [Meta]
        [Category("3. GridView")]
        [DefaultValue("sort-asc")]
        [Description("The CSS class applied to a header when it is asc sorted.")]
        public virtual string SortAscClass
        {
            get
            {
                return (string)this.ViewState["SortAscClass"] ?? "sort-asc";
            }
            set
            {
                this.ViewState["SortAscClass"] = value;
            }
        }

        /// <summary>
        /// The CSS class applied to a header when it is desc sorted.
        /// </summary>
        [Meta]
        [Category("3. GridView")]
        [DefaultValue("sort-desc")]
        [Description("The CSS class applied to a header when it is desc sorted.")]
        public virtual string SortDescClass
        {
            get
            {
                return (string)this.ViewState["SortDescClass"] ?? "sort-desc";
            }
            set
            {
                this.ViewState["SortDescClass"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected internal virtual string SortClasses
        {
            get
            {
                if (this.SortAscClass == "sort-asc" && this.SortDescClass == "sort-desc")
                {
                    return "";
                }
                return "[".ConcatWith(JSON.Serialize(this.SortAscClass), ",", JSON.Serialize(this.SortDescClass),"]");
            }
        }

        /// <summary>
        /// True to show the dirty cell indicator when a cell has been modified. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. GridView")]
        [DefaultValue(true)]
        [Description("True to show the dirty cell indicator when a cell has been modified. Defaults to true.")]
        public virtual bool MarkDirty
        {
            get
            {
                object obj = this.ViewState["MarkDirty"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["MarkDirty"] = value;
            }
        }

        private JFunction getRowClass;

        /// <summary>
        /// Override this function to apply custom CSS classes to rows during rendering.
        /// You can also supply custom parameters to the row template for the current row 
        /// to customize how it is rendered using the rowParams parameter. This function 
        /// should return the CSS class name (or empty string '' for none) that will be 
        /// added to the row's wrapping div. To apply multiple class names, simply return 
        /// them space-delimited within the string (e.g., 'my-class another-class').
        /// 
        /// Parameters:
        ///     record : Record
        ///         The Ext.data.Record corresponding to the current row
        ///     index : Number
        ///         The row index
        ///     rowParams : Object
        ///         A config object that is passed to the row template during rendering 
        ///         that allows customization of various aspects of a body row, if applicable. 
        ///         Note that this object will only be applied if enableRowBody = true, 
        ///         otherwise it will be ignored. The object may contain any of these properties:
        ///     store : Store
        ///         The Ext.data.Store this grid is bound to
        /// Returns:
        ///     String
        ///     a CSS class name to add to the row.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. GridView")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Override this function to apply custom CSS classes to rows during rendering.")]
        public virtual JFunction GetRowClass
        {
            get
            {
                if (this.getRowClass == null)
                {
                    this.getRowClass = new JFunction();
                }

                return this.getRowClass;
            }
        }

        private GridViewListeners listeners;

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
        public GridViewListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new GridViewListeners();
                }

                return this.listeners;
            }
        }

        private GridViewDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side Ajax Event Handlers")]
        public GridViewDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new GridViewDirectEvents();
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. GridView")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool StandardHeaderRow
        {
            get
            {
                object obj = this.ViewState["StandardHeaderRow"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["StandardHeaderRow"] = value;
            }
        }

        /// <summary>
        /// The width of the column header splitter target area.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. GridView")]
        [DefaultValue(5)]
        [Description("The width of the column header splitter target area.")]
        public virtual int SplitHandleWidth
        {
            get
            {
                object obj = this.ViewState["SplitHandleWidth"];
                return (obj == null) ? 5 : (int)obj;
            }
            set
            {
                this.ViewState["SplitHandleWidth"] = value;
            }
        }

        private HeaderGroupRows headerGroupRows;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual HeaderGroupRows HeaderGroupRows
        {
            get
            {
                if (this.headerGroupRows == null)
                {
                    this.headerGroupRows = new HeaderGroupRows();
                }

                return this.headerGroupRows;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("headerGroupRows", JsonMode.Raw)]
        [Description("")]
        protected string headerGroupRowsProxy
        {
            get
            {
                if (this.HeaderGroupRows.Count == 0)
                {
                    return "";
                }

                StringBuilder sb = new StringBuilder();
                sb.Append("[");

                foreach (HeaderGroupRow row in this.HeaderGroupRows)
                {
                    sb.Append("[");

                    foreach (HeaderGroupColumn column in row.Columns)
                    {
                        sb.Append(new ClientConfig().SerializeInternal(column, this));
                        sb.Append(",");
                    }

                    if (row.Columns.Count > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }

                    sb.Append("],");
                }

                sb.Remove(sb.Length - 1, 1);

                sb.Append("]");

                return sb.ToString();
            }
        }

        private HeaderRowCollection headerRows;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual HeaderRowCollection HeaderRows
        {
            get
            {
                if (this.headerRows == null)
                {
                    this.headerRows = new HeaderRowCollection();
                    this.headerRows.Owner = this;
                    this.headerRows.AfterItemAdd += HeaderRows_AfterItemAdd;
                }

                return this.headerRows;
            }
        }

        private void HeaderRows_AfterItemAdd(HeaderRow item)
        {
            if (this.ParentGrid != null)
            {
                foreach (HeaderColumn column in item.Columns)
                {
                    this.ParentGrid.EnsureHeaderColumn(this,column);
                }                
            }
            
            item.Columns.AfterItemAdd += Columns_AfterItemAdd;
            this.Templates.BuildHeaderTemplate();
            this.Templates.Header.Visible = true;
        }

        void Columns_AfterItemAdd(HeaderColumn item)
        {
            if (item.Component.Count > 0 && this.ParentGrid != null)
            {
                this.ParentGrid.EnsureHeaderColumn(this, item);
            }

            item.Component.AfterItemAdd += Component_AfterItemAdd;
        }

        void Component_AfterItemAdd(Component item)
        {
            if (this.ParentGrid != null)
            {
                this.ParentGrid.EnsureHeaderControl(this, item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("headerRows", JsonMode.Raw)]
        [Description("")]
        protected string HeaderRowsProxy
        {
            get
            {
                if (this.HeaderRows.Count == 0)
                {
                    return "";
                }

                StringBuilder sb = new StringBuilder();
                sb.Append("[");

                foreach (HeaderRow row in this.HeaderRows)
                {
                    sb.Append("{columns:[");

                    foreach (HeaderColumn column in row.Columns)
                    {
                        sb.Append(new ClientConfig().SerializeInternal(column, this));
                        sb.Append(",");
                    }

                    if (row.Columns.Count > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }

                    sb.Append("]},");
                }

                sb.Remove(sb.Length - 1, 1);

                sb.Append("]");

                return sb.ToString();
            }
        }

        private GridViewTemplates templates;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("templates", JsonMode.Object)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public GridViewTemplates Templates
        {
            get
            {
                if (this.templates == null)
                {
                    this.templates = new GridViewTemplates(this);
                }

                return this.templates;
            }
        }

        /// <summary>
        /// Focuses the specified cell.
        /// </summary>
        /// <param name="row">The row index</param>
        /// <param name="col">The column index</param>
        [Meta]
        [Description("Focuses the specified cell.")]
        public virtual void FocusCell(int row, int col)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("focusCell", row, col);
        }

        /// <summary>
        /// Focuses the specified row.
        /// </summary>
        /// <param name="row">The row index</param>
        [Meta]
        [Description("Focuses the specified row.")]
        public virtual void FocusRow(int row)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("focusRow", row);
        }

        /// <summary>
        /// Refreshs the grid UI
        /// </summary>
        /// <param name="headersToo">True to also refresh the headers</param>
        [Meta]
        [Description("Refreshs the grid UI")]
        public virtual void Refresh(bool headersToo)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("refresh", headersToo);
        }

        /// <summary>
        /// Refreshs the grid UI
        /// </summary>
        [Meta]
        [Description("Refreshs the grid UI")]
        public virtual void Refresh()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("refresh");
        }

        /// <summary>
        /// Scrolls the grid to the top
        /// </summary>
        [Meta]
        [Description("Scrolls the grid to the top")]
        public virtual void ScrollToTop()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("scrollToTop");
        }
    }
}
