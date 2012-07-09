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
    public abstract partial class ColumnBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : StateManagedItem.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool wrap = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Wrap 
			{ 
				get
				{
					return this.wrap;
				}
				set
				{
					this.wrap = value;
				}
			}

			private bool locked = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Locked 
			{ 
				get
				{
					return this.locked;
				}
				set
				{
					this.locked = value;
				}
			}

			private Alignment align = Alignment.Left;

			/// <summary>
			/// (optional) Set the CSS text-align property of the column. Defaults to undefined.
			/// </summary>
			[DefaultValue(Alignment.Left)]
			public virtual Alignment Align 
			{ 
				get
				{
					return this.align;
				}
				set
				{
					this.align = value;
				}
			}

			private string css = "";

			/// <summary>
			/// (optional) Set custom CSS for all table cells in the column (excluding headers). Defaults to undefined.
			/// </summary>
			[DefaultValue("")]
			public virtual string Css 
			{ 
				get
				{
					return this.css;
				}
				set
				{
					this.css = value;
				}
			}

			private string dataIndex = null;

			/// <summary>
			/// (optional) The name of the field in the grid's Ext.data.Store's Ext.data.Record definition from which to draw the column's value. If not specified, the column's index is used as an index into the Record's data Array.
			/// </summary>
			[DefaultValue(null)]
			public virtual string DataIndex 
			{ 
				get
				{
					return this.dataIndex;
				}
				set
				{
					this.dataIndex = value;
				}
			}
        
			private EditorCollection editor = null;

			/// <summary>
			/// (optional) The Ext.form.Field to use when editing values in this column if editing is supported by the grid.
			/// </summary>
			public EditorCollection Editor
			{
				get
				{
					if (this.editor == null)
					{
						this.editor = new EditorCollection();
					}
			
					return this.editor;
				}
			}
			        
			private GridEditorOptions editorOptions = null;

			/// <summary>
			/// Editor options
			/// </summary>
			public GridEditorOptions EditorOptions
			{
				get
				{
					if (this.editorOptions == null)
					{
						this.editorOptions = new GridEditorOptions();
					}
			
					return this.editorOptions;
				}
			}
			
			private bool _fixed = false;

			/// <summary>
			/// (optional) True if the column width cannot be changed. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Fixed 
			{ 
				get
				{
					return this._fixed;
				}
				set
				{
					this._fixed = value;
				}
			}

			private string header = "";

			/// <summary>
			/// The header text to display in the Grid view.
			/// </summary>
			[DefaultValue("")]
			public virtual string Header 
			{ 
				get
				{
					return this.header;
				}
				set
				{
					this.header = value;
				}
			}

			private bool hidden = false;

			/// <summary>
			/// (optional) True to hide the column. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Hidden 
			{ 
				get
				{
					return this.hidden;
				}
				set
				{
					this.hidden = value;
				}
			}

			private bool hideable = true;

			/// <summary>
			/// (optional) Specify as false to prevent the user from hiding this column. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Hideable 
			{ 
				get
				{
					return this.hideable;
				}
				set
				{
					this.hideable = value;
				}
			}

			private string columnID = "";

			/// <summary>
			/// (optional) Defaults to the column's initial ordinal position. A name which identifies this column. The id is used to create a CSS class name which is applied to all table cells (including headers) in that column.
			/// </summary>
			[DefaultValue("")]
			public virtual string ColumnID 
			{ 
				get
				{
					return this.columnID;
				}
				set
				{
					this.columnID = value;
				}
			}

			private bool menuDisabled = false;

			/// <summary>
			/// (optional) True to disable the column menu. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool MenuDisabled 
			{ 
				get
				{
					return this.menuDisabled;
				}
				set
				{
					this.menuDisabled = value;
				}
			}

			private Renderer renderer = null;

			/// <summary>
			/// (optional) A function used to generate HTML markup for a cell given the cell's data value. If not specified, the default renderer uses the raw data value.
			/// </summary>
			[DefaultValue(null)]
			public virtual Renderer Renderer 
			{ 
				get
				{
					return this.renderer;
				}
				set
				{
					this.renderer = value;
				}
			}

			private Renderer groupRenderer = null;

			/// <summary>
			/// (optional) A function used to generate HTML markup for a cell given the cell's data value.
			/// </summary>
			[DefaultValue(null)]
			public virtual Renderer GroupRenderer 
			{ 
				get
				{
					return this.groupRenderer;
				}
				set
				{
					this.groupRenderer = value;
				}
			}

			private bool groupable = true;

			/// <summary>
			/// (optional) False to disable grouping by this column. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Groupable 
			{ 
				get
				{
					return this.groupable;
				}
				set
				{
					this.groupable = value;
				}
			}

			private bool resizable = true;

			/// <summary>
			/// (optional) False to disable column resizing. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Resizable 
			{ 
				get
				{
					return this.resizable;
				}
				set
				{
					this.resizable = value;
				}
			}

			private string scope = "";

			/// <summary>
			/// The scope (this reference) in which to execute the renderer. Defaults to the Column configuration object.
			/// </summary>
			[DefaultValue("")]
			public virtual string Scope 
			{ 
				get
				{
					return this.scope;
				}
				set
				{
					this.scope = value;
				}
			}

			private bool sortable = true;

			/// <summary>
			/// (optional) True if sorting is to be allowed on this column. Defaults to the value of the defaultSortable property. Whether local/remote sorting is used is specified in Ext.data.Store.remoteSort.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Sortable 
			{ 
				get
				{
					return this.sortable;
				}
				set
				{
					this.sortable = value;
				}
			}

			private string tooltip = "";

			/// <summary>
			/// (optional) A text string to use as the column header's tooltip. If Quicktips are enabled, this value will be used as the text of the quick tip, otherwise it will be set as the header's HTML title attribute. Defaults to ''.
			/// </summary>
			[DefaultValue("")]
			public virtual string Tooltip 
			{ 
				get
				{
					return this.tooltip;
				}
				set
				{
					this.tooltip = value;
				}
			}

			private Unit width = Unit.Pixel(100);

			/// <summary>
			/// (optional) The initial width in pixels of the column. Using this instead of Ext.grid.Grid.autoSizeColumns is more efficient.
			/// </summary>
			[DefaultValue(typeof(Unit), "100")]
			public virtual Unit Width 
			{ 
				get
				{
					return this.width;
				}
				set
				{
					this.width = value;
				}
			}

			private bool editable = true;

			/// <summary>
			/// Optional. Defaults to true, enabling the configured editor. Set to false to initially disable editing on this column.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Editable 
			{ 
				get
				{
					return this.editable;
				}
				set
				{
					this.editable = value;
				}
			}

			private string emptyGroupText = "";

			/// <summary>
			/// Optional. If the grid is being rendered by an Ext.grid.GroupingView, this option may be used to specify the text to display when there is an empty group value. Defaults to the Ext.grid.GroupingView.emptyGroupText.
			/// </summary>
			[DefaultValue("")]
			public virtual string EmptyGroupText 
			{ 
				get
				{
					return this.emptyGroupText;
				}
				set
				{
					this.emptyGroupText = value;
				}
			}

			private string groupName = "";

			/// <summary>
			/// Optional. If the grid is being rendered by an Ext.grid.GroupingView, this option may be used to specify the text with which to prefix the group field value in the group header line. See also groupRenderer and Ext.grid.GroupingView.showGroupName.
			/// </summary>
			[DefaultValue("")]
			public virtual string GroupName 
			{ 
				get
				{
					return this.groupName;
				}
				set
				{
					this.groupName = value;
				}
			}
        
			private ConfigItemCollection customConfig = null;

			/// <summary>
			/// Collection of custom js config
			/// </summary>
			public ConfigItemCollection CustomConfig
			{
				get
				{
					if (this.customConfig == null)
					{
						this.customConfig = new ConfigItemCollection();
					}
			
					return this.customConfig;
				}
			}
			
        }
    }
}