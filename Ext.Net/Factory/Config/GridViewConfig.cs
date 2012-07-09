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
using System.Web.UI.WebControls;

namespace Ext.Net
{
    public partial class GridView
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public GridView(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit GridView.Config Conversion to GridView
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator GridView(GridView.Config config)
        {
            return new GridView(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : LazyObservable.Config 
        { 
			/*  Implicit GridView.Config Conversion to GridView.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator GridView.Builder(GridView.Config config)
			{
				return new GridView.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoFill = false;

			/// <summary>
			/// True to auto expand the columns to fit the grid when the grid is created.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoFill 
			{ 
				get
				{
					return this.autoFill;
				}
				set
				{
					this.autoFill = value;
				}
			}

			private string columnsText = "";

			/// <summary>
			/// The text displayed in the \"Columns\" menu item
			/// </summary>
			[DefaultValue("")]
			public virtual string ColumnsText 
			{ 
				get
				{
					return this.columnsText;
				}
				set
				{
					this.columnsText = value;
				}
			}

			private string cellSelector = "";

			/// <summary>
			/// The selector used to find cells internally
			/// </summary>
			[DefaultValue("")]
			public virtual string CellSelector 
			{ 
				get
				{
					return this.cellSelector;
				}
				set
				{
					this.cellSelector = value;
				}
			}

			private int cellSelectorDepth = 4;

			/// <summary>
			/// The number of levels to search for cells in event delegation (defaults to 4)
			/// </summary>
			[DefaultValue(4)]
			public virtual int CellSelectorDepth 
			{ 
				get
				{
					return this.cellSelectorDepth;
				}
				set
				{
					this.cellSelectorDepth = value;
				}
			}

			private bool deferEmptyText = true;

			/// <summary>
			/// True to defer emptyText being applied until the store's first load
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DeferEmptyText 
			{ 
				get
				{
					return this.deferEmptyText;
				}
				set
				{
					this.deferEmptyText = value;
				}
			}

			private string emptyText = "";

			/// <summary>
			/// Default text to display in the grid body when no rows are available (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string EmptyText 
			{ 
				get
				{
					return this.emptyText;
				}
				set
				{
					this.emptyText = value;
				}
			}

			private bool enableRowBody = false;

			/// <summary>
			/// True to add a second TR element per row that can be used to provide a row body that spans beneath the data row. Use the getRowClass method's rowParams config to customize the row body.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnableRowBody 
			{ 
				get
				{
					return this.enableRowBody;
				}
				set
				{
					this.enableRowBody = value;
				}
			}

			private bool forceFit = false;

			/// <summary>
			/// True to auto expand/contract the size of the columns to fit the grid width and prevent horizontal scrolling.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ForceFit 
			{ 
				get
				{
					return this.forceFit;
				}
				set
				{
					this.forceFit = value;
				}
			}

			private bool headersDisabled = false;

			/// <summary>
			/// True to disable the grid column headers (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HeadersDisabled 
			{ 
				get
				{
					return this.headersDisabled;
				}
				set
				{
					this.headersDisabled = value;
				}
			}

			private string headerMenuOpenCls = "x-grid3-hd-menu-open";

			/// <summary>
			/// The CSS class to add to the header cell when its menu is visible. Defaults to 'x-grid3-hd-menu-open'
			/// </summary>
			[DefaultValue("x-grid3-hd-menu-open")]
			public virtual string HeaderMenuOpenCls 
			{ 
				get
				{
					return this.headerMenuOpenCls;
				}
				set
				{
					this.headerMenuOpenCls = value;
				}
			}

			private string rowOverCls = "x-grid3-row-over";

			/// <summary>
			/// The CSS class added to each row when it is hovered over. Defaults to 'x-grid3-row-over'
			/// </summary>
			[DefaultValue("x-grid3-row-over")]
			public virtual string RowOverCls 
			{ 
				get
				{
					return this.rowOverCls;
				}
				set
				{
					this.rowOverCls = value;
				}
			}

			private string rowSelector = "";

			/// <summary>
			/// The selector used to find rows internally
			/// </summary>
			[DefaultValue("")]
			public virtual string RowSelector 
			{ 
				get
				{
					return this.rowSelector;
				}
				set
				{
					this.rowSelector = value;
				}
			}

			private int rowSelectorDepth = 10;

			/// <summary>
			/// The number of levels to search for rows in event delegation (defaults to 10)
			/// </summary>
			[DefaultValue(10)]
			public virtual int RowSelectorDepth 
			{ 
				get
				{
					return this.rowSelectorDepth;
				}
				set
				{
					this.rowSelectorDepth = value;
				}
			}

			private string rowBodySelector = "div.x-grid3-row-body";

			/// <summary>
			/// The selector used to find row bodies internally (defaults to <tt>'div.x-grid3-row'</tt>)
			/// </summary>
			[DefaultValue("div.x-grid3-row-body")]
			public virtual string RowBodySelector 
			{ 
				get
				{
					return this.rowBodySelector;
				}
				set
				{
					this.rowBodySelector = value;
				}
			}

			private int rowBodySelectorDepth = 10;

			/// <summary>
			/// The number of levels to search for row bodies in event delegation (defaults to <tt>10</tt>)
			/// </summary>
			[DefaultValue(10)]
			public virtual int RowBodySelectorDepth 
			{ 
				get
				{
					return this.rowBodySelectorDepth;
				}
				set
				{
					this.rowBodySelectorDepth = value;
				}
			}

			private int scrollOffset = 19;

			/// <summary>
			/// The amount of space to reserve for the scrollbar (defaults to 19 pixels)
			/// </summary>
			[DefaultValue(19)]
			public virtual int ScrollOffset 
			{ 
				get
				{
					return this.scrollOffset;
				}
				set
				{
					this.scrollOffset = value;
				}
			}

			private string sortAscText = "";

			/// <summary>
			/// The text displayed in the \"Sort Ascending\" menu item
			/// </summary>
			[DefaultValue("")]
			public virtual string SortAscText 
			{ 
				get
				{
					return this.sortAscText;
				}
				set
				{
					this.sortAscText = value;
				}
			}

			private string sortDescText = "";

			/// <summary>
			/// The text displayed in the \"Sort Descending\" menu item
			/// </summary>
			[DefaultValue("")]
			public virtual string SortDescText 
			{ 
				get
				{
					return this.sortDescText;
				}
				set
				{
					this.sortDescText = value;
				}
			}

			private string selectedRowClass = "x-grid3-row-selected";

			/// <summary>
			/// The CSS class applied to a selected row (defaults to \"x-grid3-row-selected\").
			/// </summary>
			[DefaultValue("x-grid3-row-selected")]
			public virtual string SelectedRowClass 
			{ 
				get
				{
					return this.selectedRowClass;
				}
				set
				{
					this.selectedRowClass = value;
				}
			}

			private string sortAscClass = "sort-asc";

			/// <summary>
			/// The CSS class applied to a header when it is asc sorted.
			/// </summary>
			[DefaultValue("sort-asc")]
			public virtual string SortAscClass 
			{ 
				get
				{
					return this.sortAscClass;
				}
				set
				{
					this.sortAscClass = value;
				}
			}

			private string sortDescClass = "sort-desc";

			/// <summary>
			/// The CSS class applied to a header when it is desc sorted.
			/// </summary>
			[DefaultValue("sort-desc")]
			public virtual string SortDescClass 
			{ 
				get
				{
					return this.sortDescClass;
				}
				set
				{
					this.sortDescClass = value;
				}
			}

			private bool markDirty = true;

			/// <summary>
			/// True to show the dirty cell indicator when a cell has been modified. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool MarkDirty 
			{ 
				get
				{
					return this.markDirty;
				}
				set
				{
					this.markDirty = value;
				}
			}
        
			private JFunction getRowClass = null;

			/// <summary>
			/// Override this function to apply custom CSS classes to rows during rendering.
			/// </summary>
			public JFunction GetRowClass
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
			        
			private GridViewListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
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
			        
			private GridViewDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
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
			
			private bool standardHeaderRow = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool StandardHeaderRow 
			{ 
				get
				{
					return this.standardHeaderRow;
				}
				set
				{
					this.standardHeaderRow = value;
				}
			}

			private int splitHandleWidth = 5;

			/// <summary>
			/// The width of the column header splitter target area.
			/// </summary>
			[DefaultValue(5)]
			public virtual int SplitHandleWidth 
			{ 
				get
				{
					return this.splitHandleWidth;
				}
				set
				{
					this.splitHandleWidth = value;
				}
			}
        
			private HeaderGroupRows headerGroupRows = null;

			/// <summary>
			/// 
			/// </summary>
			public HeaderGroupRows HeaderGroupRows
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
			        
			private HeaderRowCollection headerRows = null;

			/// <summary>
			/// 
			/// </summary>
			public HeaderRowCollection HeaderRows
			{
				get
				{
					if (this.headerRows == null)
					{
						this.headerRows = new HeaderRowCollection();
					}
			
					return this.headerRows;
				}
			}
			        
			private GridViewTemplates templates = null;

			/// <summary>
			/// 
			/// </summary>
			public GridViewTemplates Templates
			{
				get
				{
					if (this.templates == null)
					{
						this.templates = new GridViewTemplates();
					}
			
					return this.templates;
				}
			}
			
        }
    }
}