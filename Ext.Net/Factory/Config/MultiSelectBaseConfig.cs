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
    public abstract partial class MultiSelectBase<T>
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : Field.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
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
			/// The data store to use.
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
			        
			private ListItemCollection<T> items = null;

			/// <summary>
			/// 
			/// </summary>
			public ListItemCollection<T> Items
			{
				get
				{
					if (this.items == null)
					{
						this.items = new ListItemCollection<T>();
					}
			
					return this.items;
				}
			}
			        
			private SelectedListItemCollection selectedItems = null;

			/// <summary>
			/// 
			/// </summary>
			public SelectedListItemCollection SelectedItems
			{
				get
				{
					if (this.selectedItems == null)
					{
						this.selectedItems = new SelectedListItemCollection();
					}
			
					return this.selectedItems;
				}
			}
			
			private string displayField = "";

			/// <summary>
			/// The underlying data field name to bind to this MultiSelect.
			/// </summary>
			[DefaultValue("")]
			public virtual string DisplayField 
			{ 
				get
				{
					return this.displayField;
				}
				set
				{
					this.displayField = value;
				}
			}

			private string valueField = "";

			/// <summary>
			/// The underlying data value name to bind to this MultiSelect.
			/// </summary>
			[DefaultValue("")]
			public virtual string ValueField 
			{ 
				get
				{
					return this.valueField;
				}
				set
				{
					this.valueField = value;
				}
			}

			private bool allowBlank = true;

			/// <summary>
			/// False to validate that the value length > 0 (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowBlank 
			{ 
				get
				{
					return this.allowBlank;
				}
				set
				{
					this.allowBlank = value;
				}
			}

			private int maxLength = -1;

			/// <summary>
			/// Maximum input field length allowed (defaults to Number.MAX_VALUE).
			/// </summary>
			[DefaultValue(-1)]
			public virtual int MaxLength 
			{ 
				get
				{
					return this.maxLength;
				}
				set
				{
					this.maxLength = value;
				}
			}

			private int minLength = 0;

			/// <summary>
			/// Minimum input field length required (defaults to 0).
			/// </summary>
			[DefaultValue(0)]
			public virtual int MinLength 
			{ 
				get
				{
					return this.minLength;
				}
				set
				{
					this.minLength = value;
				}
			}

			private string maxLengthText = "";

			/// <summary>
			/// Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').
			/// </summary>
			[DefaultValue("")]
			public virtual string MaxLengthText 
			{ 
				get
				{
					return this.maxLengthText;
				}
				set
				{
					this.maxLengthText = value;
				}
			}

			private string minLengthText = "";

			/// <summary>
			/// Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').
			/// </summary>
			[DefaultValue("")]
			public virtual string MinLengthText 
			{ 
				get
				{
					return this.minLengthText;
				}
				set
				{
					this.minLengthText = value;
				}
			}

			private string blankText = "";

			/// <summary>
			/// Error text to display if the allow blank validation fails (defaults to 'This field is required').
			/// </summary>
			[DefaultValue("")]
			public virtual string BlankText 
			{ 
				get
				{
					return this.blankText;
				}
				set
				{
					this.blankText = value;
				}
			}

			private bool copy = false;

			/// <summary>
			/// Causes drag operations to copy nodes rather than move (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Copy 
			{ 
				get
				{
					return this.copy;
				}
				set
				{
					this.copy = value;
				}
			}

			private bool allowDuplicates = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AllowDuplicates 
			{ 
				get
				{
					return this.allowDuplicates;
				}
				set
				{
					this.allowDuplicates = value;
				}
			}

			private bool allowTrash = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AllowTrash 
			{ 
				get
				{
					return this.allowTrash;
				}
				set
				{
					this.allowTrash = value;
				}
			}

			private string legend = "";

			/// <summary>
			/// The title text to display in the panel header (defaults to '')
			/// </summary>
			[DefaultValue("")]
			public virtual string Legend 
			{ 
				get
				{
					return this.legend;
				}
				set
				{
					this.legend = value;
				}
			}

			private string delimiter = ",";

			/// <summary>
			/// The string used to delimit between items when set or returned as a string of values
			/// </summary>
			[DefaultValue(",")]
			public virtual string Delimiter 
			{ 
				get
				{
					return this.delimiter;
				}
				set
				{
					this.delimiter = value;
				}
			}

			private string dragGroup = "";

			/// <summary>
			/// The ddgroup name(s) for the View's DragZone (defaults to undefined).
			/// </summary>
			[DefaultValue("")]
			public virtual string DragGroup 
			{ 
				get
				{
					return this.dragGroup;
				}
				set
				{
					this.dragGroup = value;
				}
			}

			private string dropGroup = "";

			/// <summary>
			/// The ddgroup name(s) for the View's DropZone (defaults to undefined).
			/// </summary>
			[DefaultValue("")]
			public virtual string DropGroup 
			{ 
				get
				{
					return this.dropGroup;
				}
				set
				{
					this.dropGroup = value;
				}
			}

			private bool appendOnly = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AppendOnly 
			{ 
				get
				{
					return this.appendOnly;
				}
				set
				{
					this.appendOnly = value;
				}
			}

			private string sortField = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string SortField 
			{ 
				get
				{
					return this.sortField;
				}
				set
				{
					this.sortField = value;
				}
			}

			private SortDirection direction = SortDirection.ASC;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(SortDirection.ASC)]
			public virtual SortDirection Direction 
			{ 
				get
				{
					return this.direction;
				}
				set
				{
					this.direction = value;
				}
			}

			private bool submitText = true;

			/// <summary>
			/// True to submit text of selected items
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SubmitText 
			{ 
				get
				{
					return this.submitText;
				}
				set
				{
					this.submitText = value;
				}
			}

			private bool fireSelectOnLoad = false;

			/// <summary>
			/// Set init selecetion without event fires
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

			private bool multiSelect = true;

			/// <summary>
			/// True to allow multi selection (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool MultiSelect 
			{ 
				get
				{
					return this.multiSelect;
				}
				set
				{
					this.multiSelect = value;
				}
			}

			private KeepSelectionMode keepSelectionOnClick = KeepSelectionMode.Always;

			/// <summary>
			/// Selection Mode
			/// </summary>
			[DefaultValue(KeepSelectionMode.Always)]
			public virtual KeepSelectionMode KeepSelectionOnClick 
			{ 
				get
				{
					return this.keepSelectionOnClick;
				}
				set
				{
					this.keepSelectionOnClick = value;
				}
			}

			private string bodyStyle = "";

			/// <summary>
			/// Custom CSS styles to be applied to the body element in the format expected by Ext.Element.applyStyles (defaults to null).
			/// </summary>
			[DefaultValue("")]
			public virtual string BodyStyle 
			{ 
				get
				{
					return this.bodyStyle;
				}
				set
				{
					this.bodyStyle = value;
				}
			}
        
			private ToolbarCollection bottomBar = null;

			/// <summary>
			/// The bottom toolbar of the panel.
			/// </summary>
			public ToolbarCollection BottomBar
			{
				get
				{
					if (this.bottomBar == null)
					{
						this.bottomBar = new ToolbarCollection();
					}
			
					return this.bottomBar;
				}
			}
			        
			private ToolbarCollection topBar = null;

			/// <summary>
			/// The top toolbar of the panel.
			/// </summary>
			public ToolbarCollection TopBar
			{
				get
				{
					if (this.topBar == null)
					{
						this.topBar = new ToolbarCollection();
					}
			
					return this.topBar;
				}
			}
			
        }
    }
}