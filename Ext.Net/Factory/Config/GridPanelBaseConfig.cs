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
        new public abstract partial class Config : PanelBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string autoExpandColumn = "";

			/// <summary>
			/// The id of a column in this grid that should expand to fill unused space. This id can not be 0.
			/// </summary>
			[DefaultValue("")]
			public virtual string AutoExpandColumn 
			{ 
				get
				{
					return this.autoExpandColumn;
				}
				set
				{
					this.autoExpandColumn = value;
				}
			}

			private int autoExpandMax = 1000;

			/// <summary>
			/// The maximum width the autoExpandColumn can have (if enabled). Defaults to 1000.
			/// </summary>
			[DefaultValue(1000)]
			public virtual int AutoExpandMax 
			{ 
				get
				{
					return this.autoExpandMax;
				}
				set
				{
					this.autoExpandMax = value;
				}
			}

			private int autoExpandMin = 50;

			/// <summary>
			/// The minimum width the autoExpandColumn can have (if enabled). defaults to 50.
			/// </summary>
			[DefaultValue(50)]
			public virtual int AutoExpandMin 
			{ 
				get
				{
					return this.autoExpandMin;
				}
				set
				{
					this.autoExpandMin = value;
				}
			}

			private bool clearEditorFilter = true;

			/// <summary>
			/// True to clear editor filter before start editing. Default is true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ClearEditorFilter 
			{ 
				get
				{
					return this.clearEditorFilter;
				}
				set
				{
					this.clearEditorFilter = value;
				}
			}

			private bool columnLines = false;

			/// <summary>
			/// true to add css for column separation lines. Default is false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ColumnLines 
			{ 
				get
				{
					return this.columnLines;
				}
				set
				{
					this.columnLines = value;
				}
			}

			private string dDGroup = "GridDD";

			/// <summary>
			/// The DD group this GridPanel belongs to. Defaults to 'GridDD' if not specified.
			/// </summary>
			[DefaultValue("GridDD")]
			public virtual string DDGroup 
			{ 
				get
				{
					return this.dDGroup;
				}
				set
				{
					this.dDGroup = value;
				}
			}

			private string dDText = "{0} selected row{1}";

			/// <summary>
			/// Configures the text in the drag proxy. Defaults to: '{0} selected row{1}' {0} is replaced with the number of selected rows.
			/// </summary>
			[DefaultValue("{0} selected row{1}")]
			public virtual string DDText 
			{ 
				get
				{
					return this.dDText;
				}
				set
				{
					this.dDText = value;
				}
			}

			private bool deferRowRender = true;

			/// <summary>
			/// True to enable deferred row rendering. Default is true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DeferRowRender 
			{ 
				get
				{
					return this.deferRowRender;
				}
				set
				{
					this.deferRowRender = value;
				}
			}

			private bool disableSelection = false;

			/// <summary>
			/// True to disable selections in the grid (defaults to false). - ignored a SelectionModel is specified.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisableSelection 
			{ 
				get
				{
					return this.disableSelection;
				}
				set
				{
					this.disableSelection = value;
				}
			}

			private bool enableColumnHide = true;

			/// <summary>
			/// True to enable hiding of columns with the header context menu.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableColumnHide 
			{ 
				get
				{
					return this.enableColumnHide;
				}
				set
				{
					this.enableColumnHide = value;
				}
			}

			private bool enableColumnMove = true;

			/// <summary>
			/// True to enable drag and drop reorder of columns.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableColumnMove 
			{ 
				get
				{
					return this.enableColumnMove;
				}
				set
				{
					this.enableColumnMove = value;
				}
			}

			private bool enableColumnResize = true;

			/// <summary>
			/// False to turn off column resizing for the whole grid (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableColumnResize 
			{ 
				get
				{
					return this.enableColumnResize;
				}
				set
				{
					this.enableColumnResize = value;
				}
			}

			private bool enableDragDrop = false;

			/// <summary>
			/// True to enable drag and drop of rows.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnableDragDrop 
			{ 
				get
				{
					return this.enableDragDrop;
				}
				set
				{
					this.enableDragDrop = value;
				}
			}

			private bool enableHdMenu = true;

			/// <summary>
			/// True to enable the drop down button for menu in the headers.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableHdMenu 
			{ 
				get
				{
					return this.enableHdMenu;
				}
				set
				{
					this.enableHdMenu = value;
				}
			}

			private bool hideHeaders = false;

			/// <summary>
			/// True to hide the grid's header (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideHeaders 
			{ 
				get
				{
					return this.hideHeaders;
				}
				set
				{
					this.hideHeaders = value;
				}
			}
        
			private LoadMask loadMask = null;

			/// <summary>
			/// An Ext.LoadMask to mask the grid while loading (defaults to false).
			/// </summary>
			public LoadMask LoadMask
			{
				get
				{
					if (this.loadMask == null)
					{
						this.loadMask = new LoadMask();
					}
			
					return this.loadMask;
				}
			}
			        
			private SaveMask saveMask = null;

			/// <summary>
			/// An Ext.SaveMask to mask the grid while saving (defaults to false).
			/// </summary>
			public SaveMask SaveMask
			{
				get
				{
					if (this.saveMask == null)
					{
						this.saveMask = new SaveMask();
					}
			
					return this.saveMask;
				}
			}
			
			private Unit maxHeight = Unit.Pixel(400);

			/// <summary>
			/// Sets the maximum height of the grid - ignored if autoHeight is not on.
			/// </summary>
			[DefaultValue(typeof(Unit), "400")]
			public override Unit MaxHeight 
			{ 
				get
				{
					return this.maxHeight;
				}
				set
				{
					this.maxHeight = value;
				}
			}

			private Unit minColumnWidth = Unit.Pixel(25);

			/// <summary>
			/// The minimum width a column can be resized to. Defaults to 25.
			/// </summary>
			[DefaultValue(typeof(Unit), "25")]
			public virtual Unit MinColumnWidth 
			{ 
				get
				{
					return this.minColumnWidth;
				}
				set
				{
					this.minColumnWidth = value;
				}
			}

			private bool monitorWindowResize = true;

			/// <summary>
			/// True to autoSize the grid when the window resizes. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool MonitorWindowResize 
			{ 
				get
				{
					return this.monitorWindowResize;
				}
				set
				{
					this.monitorWindowResize = value;
				}
			}
        
			private SelectionModelCollection selectionModel = null;

			/// <summary>
			/// Any subclass of AbstractSelectionModel that will provide the selection model for the grid (defaults to Ext.grid.RowSelectionModel if not specified).
			/// </summary>
			public SelectionModelCollection SelectionModel
			{
				get
				{
					if (this.selectionModel == null)
					{
						this.selectionModel = new SelectionModelCollection();
					}
			
					return this.selectionModel;
				}
			}
			
			private string storeID = "";

			/// <summary>
			/// The data store to use.
			/// </summary>
			[DefaultValue("")]
			public virtual string StoreID 
			{ 
				get
				{
					return this.storeID;
				}
				set
				{
					this.storeID = value;
				}
			}
        
			private StoreCollection store = null;

			/// <summary>
			/// The Ext.Net.Store the grid should use as its data source (required).
			/// </summary>
			public StoreCollection Store
			{
				get
				{
					if (this.store == null)
					{
						this.store = new StoreCollection();
					}
			
					return this.store;
				}
			}
			
			private bool stripeRows = false;

			/// <summary>
			/// True to stripe the rows. Default is false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool StripeRows 
			{ 
				get
				{
					return this.stripeRows;
				}
				set
				{
					this.stripeRows = value;
				}
			}

			private bool trackMouseOver = false;

			/// <summary>
			/// True to highlight rows when the mouse is over. Default is true.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TrackMouseOver 
			{ 
				get
				{
					return this.trackMouseOver;
				}
				set
				{
					this.trackMouseOver = value;
				}
			}
        
			private GridViewCollection view = null;

			/// <summary>
			/// The Ext.grid.GridView used by the grid. This can be set before a call to render().
			/// </summary>
			public GridViewCollection View
			{
				get
				{
					if (this.view == null)
					{
						this.view = new GridViewCollection();
					}
			
					return this.view;
				}
			}
			
			private bool autoEncode = false;

			/// <summary>
			/// True to automatically HTML encode and decode values pre and post edit (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoEncode 
			{ 
				get
				{
					return this.autoEncode;
				}
				set
				{
					this.autoEncode = value;
				}
			}

			private int clicksToEdit = 2;

			/// <summary>
			/// The number of clicks on a cell required to display the cell's editor (defaults to 2).
			/// </summary>
			[DefaultValue(2)]
			public virtual int ClicksToEdit 
			{ 
				get
				{
					return this.clicksToEdit;
				}
				set
				{
					this.clicksToEdit = value;
				}
			}

			private bool fireSelectOnLoad = false;

			/// <summary>
			/// Set init selection without event firing
			/// </summary>
			[DefaultValue(false)]
			public virtual bool FireSelectOnLoad 
			{ 
				get
				{
					return this.fireSelectOnLoad;
				}
				set
				{
					this.fireSelectOnLoad = value;
				}
			}

			private bool forceValidation = false;

			/// <summary>
			/// True to force validation even if the value is unmodified (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ForceValidation 
			{ 
				get
				{
					return this.forceValidation;
				}
				set
				{
					this.forceValidation = value;
				}
			}

			private int selectionSavingBuffer = 0;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(0)]
			public virtual int SelectionSavingBuffer 
			{ 
				get
				{
					return this.selectionSavingBuffer;
				}
				set
				{
					this.selectionSavingBuffer = value;
				}
			}

			private SelectionMemoryMode selectionMemory = SelectionMemoryMode.Auto;

			/// <summary>
			/// True to enable saving selection during paging. Default is true.
			/// </summary>
			[DefaultValue(SelectionMemoryMode.Auto)]
			public virtual SelectionMemoryMode SelectionMemory 
			{ 
				get
				{
					return this.selectionMemory;
				}
				set
				{
					this.selectionMemory = value;
				}
			}

			private string memoryIDField = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string MemoryIDField 
			{ 
				get
				{
					return this.memoryIDField;
				}
				set
				{
					this.memoryIDField = value;
				}
			}
        
			private JFunction getDragDropText = null;

			/// <summary>
			/// Called to get grid's drag proxy text, by default returns this.ddText.
			/// </summary>
			public JFunction GetDragDropText
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
			        
			private ColumnModel columnModel = null;

			/// <summary>
			/// The Ext.grid.ColumnModel to use when rendering the grid (required).
			/// </summary>
			public ColumnModel ColumnModel
			{
				get
				{
					if (this.columnModel == null)
					{
						this.columnModel = new ColumnModel();
					}
			
					return this.columnModel;
				}
			}
			
        }
    }
}