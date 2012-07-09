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
    public abstract partial class DataViewBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : BoxComponentBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool deferEmptyText = false;

			/// <summary>
			/// True to defer emptyText being applied until the store's first load
			/// </summary>
			[DefaultValue(false)]
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
			/// The text to display in the view when there is no data to display (defaults to '').
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

			private string itemSelector = "";

			/// <summary>
			/// This is a required setting. A simple CSS selector (e.g. div.some-class or span:first-child) that will be used to determine what nodes this DataView will be working with.
			/// </summary>
			[DefaultValue("")]
			public virtual string ItemSelector 
			{ 
				get
				{
					return this.itemSelector;
				}
				set
				{
					this.itemSelector = value;
				}
			}

			private string loadingText = "";

			/// <summary>
			/// A string to display during data load operations (defaults to undefined). If specified, this text will be displayed in a loading div and the view's contents will be cleared while loading, otherwise the view's contents will continue to display normally until the new data is loaded and the contents are replaced.
			/// </summary>
			[DefaultValue("")]
			public virtual string LoadingText 
			{ 
				get
				{
					return this.loadingText;
				}
				set
				{
					this.loadingText = value;
				}
			}

			private bool multiSelect = false;

			/// <summary>
			/// True to allow selection of more than one item at a time, false to allow selection of only a single item at a time or no selection at all, depending on the value of singleSelect (defaults to false).
			/// </summary>
			[DefaultValue(false)]
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

			private string overClass = "";

			/// <summary>
			/// A CSS class to apply to each item in the view on mouseover (defaults to undefined).
			/// </summary>
			[DefaultValue("")]
			public virtual string OverClass 
			{ 
				get
				{
					return this.overClass;
				}
				set
				{
					this.overClass = value;
				}
			}

			private string selectedClass = "x-view-selected";

			/// <summary>
			/// A CSS class to apply to each selected item in the view (defaults to 'x-view-selected').
			/// </summary>
			[DefaultValue("x-view-selected")]
			public virtual string SelectedClass 
			{ 
				get
				{
					return this.selectedClass;
				}
				set
				{
					this.selectedClass = value;
				}
			}

			private bool simpleSelect = false;

			/// <summary>
			/// True to enable multiselection by clicking on multiple items without requiring the user to hold Shift or Ctrl, false to force the user to hold Ctrl or Shift to select more than on item (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SimpleSelect 
			{ 
				get
				{
					return this.simpleSelect;
				}
				set
				{
					this.simpleSelect = value;
				}
			}

			private bool singleSelect = false;

			/// <summary>
			/// True to allow selection of exactly one item at a time, false to allow no selection at all (defaults to false). Note that if multiSelect = true, this value will be ignored.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SingleSelect 
			{ 
				get
				{
					return this.singleSelect;
				}
				set
				{
					this.singleSelect = value;
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
			        
			private XTemplate template = null;

			/// <summary>
			/// The template string to use to display each item in the dropdown list.
			/// </summary>
			public XTemplate Template
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
			
			private bool trackOver = false;

			/// <summary>
			/// True to enable mouseenter and mouseleave events
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TrackOver 
			{ 
				get
				{
					return this.trackOver;
				}
				set
				{
					this.trackOver = value;
				}
			}

			private JFunction prepareData = null;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(null)]
			public virtual JFunction PrepareData 
			{ 
				get
				{
					return this.prepareData;
				}
				set
				{
					this.prepareData = value;
				}
			}

        }
    }
}