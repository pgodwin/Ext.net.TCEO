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
    public abstract partial class GridPanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TGridPanelBase, TBuilder> : PanelBase.Builder<TGridPanelBase, TBuilder>
            where TGridPanelBase : GridPanelBase
            where TBuilder : Builder<TGridPanelBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TGridPanelBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The id of a column in this grid that should expand to fill unused space. This id can not be 0.
			/// </summary>
            public virtual TBuilder AutoExpandColumn(string autoExpandColumn)
            {
                this.ToComponent().AutoExpandColumn = autoExpandColumn;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum width the autoExpandColumn can have (if enabled). Defaults to 1000.
			/// </summary>
            public virtual TBuilder AutoExpandMax(int autoExpandMax)
            {
                this.ToComponent().AutoExpandMax = autoExpandMax;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum width the autoExpandColumn can have (if enabled). defaults to 50.
			/// </summary>
            public virtual TBuilder AutoExpandMin(int autoExpandMin)
            {
                this.ToComponent().AutoExpandMin = autoExpandMin;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to clear editor filter before start editing. Default is true.
			/// </summary>
            public virtual TBuilder ClearEditorFilter(bool clearEditorFilter)
            {
                this.ToComponent().ClearEditorFilter = clearEditorFilter;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to add css for column separation lines. Default is false.
			/// </summary>
            public virtual TBuilder ColumnLines(bool columnLines)
            {
                this.ToComponent().ColumnLines = columnLines;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The DD group this GridPanel belongs to. Defaults to 'GridDD' if not specified.
			/// </summary>
            public virtual TBuilder DDGroup(string dDGroup)
            {
                this.ToComponent().DDGroup = dDGroup;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Configures the text in the drag proxy. Defaults to: '{0} selected row{1}' {0} is replaced with the number of selected rows.
			/// </summary>
            public virtual TBuilder DDText(string dDText)
            {
                this.ToComponent().DDText = dDText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable deferred row rendering. Default is true.
			/// </summary>
            public virtual TBuilder DeferRowRender(bool deferRowRender)
            {
                this.ToComponent().DeferRowRender = deferRowRender;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to disable selections in the grid (defaults to false). - ignored a SelectionModel is specified.
			/// </summary>
            public virtual TBuilder DisableSelection(bool disableSelection)
            {
                this.ToComponent().DisableSelection = disableSelection;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable hiding of columns with the header context menu.
			/// </summary>
            public virtual TBuilder EnableColumnHide(bool enableColumnHide)
            {
                this.ToComponent().EnableColumnHide = enableColumnHide;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable drag and drop reorder of columns.
			/// </summary>
            public virtual TBuilder EnableColumnMove(bool enableColumnMove)
            {
                this.ToComponent().EnableColumnMove = enableColumnMove;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to turn off column resizing for the whole grid (defaults to true).
			/// </summary>
            public virtual TBuilder EnableColumnResize(bool enableColumnResize)
            {
                this.ToComponent().EnableColumnResize = enableColumnResize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable drag and drop of rows.
			/// </summary>
            public virtual TBuilder EnableDragDrop(bool enableDragDrop)
            {
                this.ToComponent().EnableDragDrop = enableDragDrop;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable the drop down button for menu in the headers.
			/// </summary>
            public virtual TBuilder EnableHdMenu(bool enableHdMenu)
            {
                this.ToComponent().EnableHdMenu = enableHdMenu;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to hide the grid's header (defaults to false).
			/// </summary>
            public virtual TBuilder HideHeaders(bool hideHeaders)
            {
                this.ToComponent().HideHeaders = hideHeaders;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// An Ext.LoadMask to mask the grid while loading (defaults to false).
			// /// </summary>
            // public virtual TBuilder LoadMask(LoadMask loadMask)
            // {
            //    this.ToComponent().LoadMask = loadMask;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// An Ext.SaveMask to mask the grid while saving (defaults to false).
			// /// </summary>
            // public virtual TBuilder SaveMask(SaveMask saveMask)
            // {
            //    this.ToComponent().SaveMask = saveMask;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// Sets the maximum height of the grid - ignored if autoHeight is not on.
			/// </summary>
            public virtual TBuilder MaxHeight(Unit maxHeight)
            {
                this.ToComponent().MaxHeight = maxHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum width a column can be resized to. Defaults to 25.
			/// </summary>
            public virtual TBuilder MinColumnWidth(Unit minColumnWidth)
            {
                this.ToComponent().MinColumnWidth = minColumnWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to autoSize the grid when the window resizes. Defaults to true.
			/// </summary>
            public virtual TBuilder MonitorWindowResize(bool monitorWindowResize)
            {
                this.ToComponent().MonitorWindowResize = monitorWindowResize;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// Any subclass of AbstractSelectionModel that will provide the selection model for the grid (defaults to Ext.grid.RowSelectionModel if not specified).
			// /// </summary>
            // public virtual TBuilder SelectionModel(SelectionModelCollection selectionModel)
            // {
            //    this.ToComponent().SelectionModel = selectionModel;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The data store to use.
			/// </summary>
            public virtual TBuilder StoreID(string storeID)
            {
                this.ToComponent().StoreID = storeID;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// The Ext.Net.Store the grid should use as its data source (required).
			// /// </summary>
            // public virtual TBuilder Store(StoreCollection store)
            // {
            //    this.ToComponent().Store = store;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// True to stripe the rows. Default is false.
			/// </summary>
            public virtual TBuilder StripeRows(bool stripeRows)
            {
                this.ToComponent().StripeRows = stripeRows;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to highlight rows when the mouse is over. Default is true.
			/// </summary>
            public virtual TBuilder TrackMouseOver(bool trackMouseOver)
            {
                this.ToComponent().TrackMouseOver = trackMouseOver;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// The Ext.grid.GridView used by the grid. This can be set before a call to render().
			// /// </summary>
            // public virtual TBuilder View(GridViewCollection view)
            // {
            //    this.ToComponent().View = view;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// True to automatically HTML encode and decode values pre and post edit (defaults to false).
			/// </summary>
            public virtual TBuilder AutoEncode(bool autoEncode)
            {
                this.ToComponent().AutoEncode = autoEncode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of clicks on a cell required to display the cell's editor (defaults to 2).
			/// </summary>
            public virtual TBuilder ClicksToEdit(int clicksToEdit)
            {
                this.ToComponent().ClicksToEdit = clicksToEdit;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set init selection without event firing
			/// </summary>
            public virtual TBuilder FireSelectOnLoad(bool fireSelectOnLoad)
            {
                this.ToComponent().FireSelectOnLoad = fireSelectOnLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to force validation even if the value is unmodified (defaults to false)
			/// </summary>
            public virtual TBuilder ForceValidation(bool forceValidation)
            {
                this.ToComponent().ForceValidation = forceValidation;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SelectionSavingBuffer(int selectionSavingBuffer)
            {
                this.ToComponent().SelectionSavingBuffer = selectionSavingBuffer;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable saving selection during paging. Default is true.
			/// </summary>
            public virtual TBuilder SelectionMemory(SelectionMemoryMode selectionMemory)
            {
                this.ToComponent().SelectionMemory = selectionMemory;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MemoryIDField(string memoryIDField)
            {
                this.ToComponent().MemoryIDField = memoryIDField;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// Called to get grid's drag proxy text, by default returns this.ddText.
			// /// </summary>
            // public virtual TBuilder GetDragDropText(JFunction getDragDropText)
            // {
            //    this.ToComponent().GetDragDropText = getDragDropText;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// The Ext.grid.ColumnModel to use when rendering the grid (required).
			// /// </summary>
            // public virtual TBuilder ColumnModel(ColumnModel columnModel)
            // {
            //    this.ToComponent().ColumnModel = columnModel;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Add new column to the end.
			/// </summary>
            public virtual TBuilder AddColumn(ColumnBase column)
            {
                this.ToComponent().AddColumn(column);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Insert new column.
			/// </summary>
            public virtual TBuilder InsertColumn(int index, ColumnBase column)
            {
                this.ToComponent().InsertColumn(index, column);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Remove column.
			/// </summary>
            public virtual TBuilder RemoveColumn(int index)
            {
                this.ToComponent().RemoveColumn(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Reconfigure columns.
			/// </summary>
            public virtual TBuilder Reconfigure()
            {
                this.ToComponent().Reconfigure();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Insert record
			/// </summary>
            public virtual TBuilder InsertRecord(int index, object values)
            {
                this.ToComponent().InsertRecord(index, values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Insert record
			/// </summary>
            public virtual TBuilder InsertRecord(int index, object values, bool commit)
            {
                this.ToComponent().InsertRecord(index, values, commit);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Add record
			/// </summary>
            public virtual TBuilder AddRecord(object values)
            {
                this.ToComponent().AddRecord(values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Add record
			/// </summary>
            public virtual TBuilder AddRecord(object values, bool commit)
            {
                this.ToComponent().AddRecord(values, commit);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Delete selected records
			/// </summary>
            public virtual TBuilder DeleteSelected()
            {
                this.ToComponent().DeleteSelected();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Refresh view
			/// </summary>
            public virtual TBuilder RefreshView()
            {
                this.ToComponent().RefreshView();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Starts editing the specified for the specified row/column
			/// </summary>
            public virtual TBuilder StartEditing(int rowIndex, int colIndex)
            {
                this.ToComponent().StartEditing(rowIndex, colIndex);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Stops any active editing
			/// </summary>
            public virtual TBuilder StopEditing(bool cancel)
            {
                this.ToComponent().StopEditing(cancel);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Stops any active editing
			/// </summary>
            public virtual TBuilder StopEditing()
            {
                this.ToComponent().StopEditing();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Update cell content
			/// </summary>
            public virtual TBuilder UpdateCell(int rowIndex, string dataIndex, object value)
            {
                this.ToComponent().UpdateCell(rowIndex, dataIndex, value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Update cell content
			/// </summary>
            public virtual TBuilder UpdateCell(object id, string dataIndex, object value)
            {
                this.ToComponent().UpdateCell(id, dataIndex, value);
                return this as TBuilder;
            }
            
        }        
    }
}