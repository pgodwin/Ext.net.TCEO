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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : LazyObservable.Builder<GridView, GridView.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new GridView()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GridView component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GridView.Config config) : base(new GridView(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(GridView component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to auto expand the columns to fit the grid when the grid is created.
			/// </summary>
            public virtual GridView.Builder AutoFill(bool autoFill)
            {
                this.ToComponent().AutoFill = autoFill;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The text displayed in the \"Columns\" menu item
			/// </summary>
            public virtual GridView.Builder ColumnsText(string columnsText)
            {
                this.ToComponent().ColumnsText = columnsText;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The selector used to find cells internally
			/// </summary>
            public virtual GridView.Builder CellSelector(string cellSelector)
            {
                this.ToComponent().CellSelector = cellSelector;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The number of levels to search for cells in event delegation (defaults to 4)
			/// </summary>
            public virtual GridView.Builder CellSelectorDepth(int cellSelectorDepth)
            {
                this.ToComponent().CellSelectorDepth = cellSelectorDepth;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// True to defer emptyText being applied until the store's first load
			/// </summary>
            public virtual GridView.Builder DeferEmptyText(bool deferEmptyText)
            {
                this.ToComponent().DeferEmptyText = deferEmptyText;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// Default text to display in the grid body when no rows are available (defaults to '').
			/// </summary>
            public virtual GridView.Builder EmptyText(string emptyText)
            {
                this.ToComponent().EmptyText = emptyText;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// True to add a second TR element per row that can be used to provide a row body that spans beneath the data row. Use the getRowClass method's rowParams config to customize the row body.
			/// </summary>
            public virtual GridView.Builder EnableRowBody(bool enableRowBody)
            {
                this.ToComponent().EnableRowBody = enableRowBody;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// True to auto expand/contract the size of the columns to fit the grid width and prevent horizontal scrolling.
			/// </summary>
            public virtual GridView.Builder ForceFit(bool forceFit)
            {
                this.ToComponent().ForceFit = forceFit;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// True to disable the grid column headers (defaults to false).
			/// </summary>
            public virtual GridView.Builder HeadersDisabled(bool headersDisabled)
            {
                this.ToComponent().HeadersDisabled = headersDisabled;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The CSS class to add to the header cell when its menu is visible. Defaults to 'x-grid3-hd-menu-open'
			/// </summary>
            public virtual GridView.Builder HeaderMenuOpenCls(string headerMenuOpenCls)
            {
                this.ToComponent().HeaderMenuOpenCls = headerMenuOpenCls;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The CSS class added to each row when it is hovered over. Defaults to 'x-grid3-row-over'
			/// </summary>
            public virtual GridView.Builder RowOverCls(string rowOverCls)
            {
                this.ToComponent().RowOverCls = rowOverCls;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The selector used to find rows internally
			/// </summary>
            public virtual GridView.Builder RowSelector(string rowSelector)
            {
                this.ToComponent().RowSelector = rowSelector;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The number of levels to search for rows in event delegation (defaults to 10)
			/// </summary>
            public virtual GridView.Builder RowSelectorDepth(int rowSelectorDepth)
            {
                this.ToComponent().RowSelectorDepth = rowSelectorDepth;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The selector used to find row bodies internally (defaults to <tt>'div.x-grid3-row'</tt>)
			/// </summary>
            public virtual GridView.Builder RowBodySelector(string rowBodySelector)
            {
                this.ToComponent().RowBodySelector = rowBodySelector;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The number of levels to search for row bodies in event delegation (defaults to <tt>10</tt>)
			/// </summary>
            public virtual GridView.Builder RowBodySelectorDepth(int rowBodySelectorDepth)
            {
                this.ToComponent().RowBodySelectorDepth = rowBodySelectorDepth;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The amount of space to reserve for the scrollbar (defaults to 19 pixels)
			/// </summary>
            public virtual GridView.Builder ScrollOffset(int scrollOffset)
            {
                this.ToComponent().ScrollOffset = scrollOffset;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The text displayed in the \"Sort Ascending\" menu item
			/// </summary>
            public virtual GridView.Builder SortAscText(string sortAscText)
            {
                this.ToComponent().SortAscText = sortAscText;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The text displayed in the \"Sort Descending\" menu item
			/// </summary>
            public virtual GridView.Builder SortDescText(string sortDescText)
            {
                this.ToComponent().SortDescText = sortDescText;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The CSS class applied to a selected row (defaults to \"x-grid3-row-selected\").
			/// </summary>
            public virtual GridView.Builder SelectedRowClass(string selectedRowClass)
            {
                this.ToComponent().SelectedRowClass = selectedRowClass;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The CSS class applied to a header when it is asc sorted.
			/// </summary>
            public virtual GridView.Builder SortAscClass(string sortAscClass)
            {
                this.ToComponent().SortAscClass = sortAscClass;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The CSS class applied to a header when it is desc sorted.
			/// </summary>
            public virtual GridView.Builder SortDescClass(string sortDescClass)
            {
                this.ToComponent().SortDescClass = sortDescClass;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// True to show the dirty cell indicator when a cell has been modified. Defaults to true.
			/// </summary>
            public virtual GridView.Builder MarkDirty(bool markDirty)
            {
                this.ToComponent().MarkDirty = markDirty;
                return this as GridView.Builder;
            }
             
 			// /// <summary>
			// /// Override this function to apply custom CSS classes to rows during rendering.
			// /// </summary>
            // public virtual TBuilder GetRowClass(JFunction getRowClass)
            // {
            //    this.ToComponent().GetRowClass = getRowClass;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(GridViewListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(GridViewDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual GridView.Builder StandardHeaderRow(bool standardHeaderRow)
            {
                this.ToComponent().StandardHeaderRow = standardHeaderRow;
                return this as GridView.Builder;
            }
             
 			/// <summary>
			/// The width of the column header splitter target area.
			/// </summary>
            public virtual GridView.Builder SplitHandleWidth(int splitHandleWidth)
            {
                this.ToComponent().SplitHandleWidth = splitHandleWidth;
                return this as GridView.Builder;
            }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder HeaderGroupRows(HeaderGroupRows headerGroupRows)
            // {
            //    this.ToComponent().HeaderGroupRows = headerGroupRows;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder HeaderRows(HeaderRowCollection headerRows)
            // {
            //    this.ToComponent().HeaderRows = headerRows;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Templates(GridViewTemplates templates)
            // {
            //    this.ToComponent().Templates = templates;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Focuses the specified cell.
			/// </summary>
            public virtual GridView.Builder FocusCell(int row, int col)
            {
                this.ToComponent().FocusCell(row, col);
                return this;
            }
            
 			/// <summary>
			/// Focuses the specified row.
			/// </summary>
            public virtual GridView.Builder FocusRow(int row)
            {
                this.ToComponent().FocusRow(row);
                return this;
            }
            
 			/// <summary>
			/// Refreshs the grid UI
			/// </summary>
            public virtual GridView.Builder Refresh(bool headersToo)
            {
                this.ToComponent().Refresh(headersToo);
                return this;
            }
            
 			/// <summary>
			/// Refreshs the grid UI
			/// </summary>
            public virtual GridView.Builder Refresh()
            {
                this.ToComponent().Refresh();
                return this;
            }
            
 			/// <summary>
			/// Scrolls the grid to the top
			/// </summary>
            public virtual GridView.Builder ScrollToTop()
            {
                this.ToComponent().ScrollToTop();
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public GridView.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.GridView(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public GridView.Builder GridView()
        {
            return this.GridView(new GridView());
        }

        /// <summary>
        /// 
        /// </summary>
        public GridView.Builder GridView(GridView component)
        {
            return new GridView.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public GridView.Builder GridView(GridView.Config config)
        {
            return new GridView.Builder(new GridView(config));
        }
    }
}