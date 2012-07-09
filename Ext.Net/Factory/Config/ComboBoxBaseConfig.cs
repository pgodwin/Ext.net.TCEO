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
    public abstract partial class ComboBoxBase<T>
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : TriggerFieldBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string allQuery = "";

			/// <summary>
			/// The text query to send to the server to return all records for the list with no filtering (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string AllQuery 
			{ 
				get
				{
					return this.allQuery;
				}
				set
				{
					this.allQuery = value;
				}
			}

			private bool clearFilterOnReset = true;

			/// <summary>
			/// true to clear any filters on the store (when in local mode) when reset is called (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ClearFilterOnReset 
			{ 
				get
				{
					return this.clearFilterOnReset;
				}
				set
				{
					this.clearFilterOnReset = value;
				}
			}

			private string displayField = "";

			/// <summary>
			/// The underlying data field name to bind to this ComboBox (defaults to undefined if mode = 'remote' or 'text' if transforming a select).
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

			private bool forceSelection = true;

			/// <summary>
			/// True to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ForceSelection 
			{ 
				get
				{
					return this.forceSelection;
				}
				set
				{
					this.forceSelection = value;
				}
			}

			private Unit handleHeight = Unit.Pixel(8);

			/// <summary>
			/// The height in pixels of the dropdown list resize handle if resizable = true (defaults to 8).
			/// </summary>
			[DefaultValue(typeof(Unit), "8")]
			public virtual Unit HandleHeight 
			{ 
				get
				{
					return this.handleHeight;
				}
				set
				{
					this.handleHeight = value;
				}
			}

			private string hiddenID = "";

			/// <summary>
			/// If hiddenName is specified, hiddenId can also be provided to give the hidden field a unique id (defaults to the hiddenName). The hiddenId and combo id should be different, since no two DOM nodes should share the same id.
			/// </summary>
			[DefaultValue("")]
			public virtual string HiddenID 
			{ 
				get
				{
					return this.hiddenID;
				}
				set
				{
					this.hiddenID = value;
				}
			}

			private string hiddenValue = "";

			/// <summary>
			/// Sets the initial value of the hidden field if hiddenName is specified to contain the selected valueField, from the Store. Defaults to the configured value.
			/// </summary>
			[DefaultValue("")]
			public virtual string HiddenValue 
			{ 
				get
				{
					return this.hiddenValue;
				}
				set
				{
					this.hiddenValue = value;
				}
			}

			private string hiddenName = "";

			/// <summary>
			/// If specified, a hidden form field with this name is dynamically generated to store the field's data value (defaults to the underlying DOM element's name). Required for the combo's value to automatically post during a form submission.
			/// </summary>
			[DefaultValue("")]
			public virtual string HiddenName 
			{ 
				get
				{
					return this.hiddenName;
				}
				set
				{
					this.hiddenName = value;
				}
			}

			private string itemSelector = "";

			/// <summary>
			/// This setting is required if a custom XTemplate has been specified in tpl which assigns a class other than 'x-combo-list-item' to dropdown list items. A simple CSS selector (e.g. div.some-class or span:first-child) that will be used to determine what nodes the DataView which handles the dropdown display will be working with.
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

			private bool lazyInit = true;

			/// <summary>
			/// True to not initialize the list for this combo until the field is focused. (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool LazyInit 
			{ 
				get
				{
					return this.lazyInit;
				}
				set
				{
					this.lazyInit = value;
				}
			}

			private bool lazyRender = false;

			/// <summary>
			/// True to prevent the ComboBox from rendering until requested (should always be used when rendering into an Ext.Editor, defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool LazyRender 
			{ 
				get
				{
					return this.lazyRender;
				}
				set
				{
					this.lazyRender = value;
				}
			}

			private bool fireSelectOnLoad = false;

			/// <summary>
			/// True to fire select event after setValue on page load
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

			private string listAlign = "";

			/// <summary>
			/// A valid anchor position value. See Ext.Element.alignTo for details on supported anchor positions (defaults to 'tl-bl').
			/// </summary>
			[DefaultValue("")]
			public virtual string ListAlign 
			{ 
				get
				{
					return this.listAlign;
				}
				set
				{
					this.listAlign = value;
				}
			}

			private string listClass = "";

			/// <summary>
			/// CSS class to apply to the dropdown list element (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string ListClass 
			{ 
				get
				{
					return this.listClass;
				}
				set
				{
					this.listClass = value;
				}
			}

			private Unit listWidth = Unit.Empty;

			/// <summary>
			/// The width in pixels of the dropdown list (defaults to the width of the ComboBox field).
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit ListWidth 
			{ 
				get
				{
					return this.listWidth;
				}
				set
				{
					this.listWidth = value;
				}
			}

			private string loadingText = "Loading...";

			/// <summary>
			/// The text to display in the dropdown list while data is loading. Only applies when mode = 'remote' (defaults to 'Loading...').
			/// </summary>
			[DefaultValue("Loading...")]
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

			private Unit maxHeight = Unit.Pixel(300);

			/// <summary>
			/// The maximum height in pixels of the dropdown list before scrollbars are shown (defaults to 300).
			/// </summary>
			[DefaultValue(typeof(Unit), "300")]
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

			private Unit minHeight = Unit.Pixel(90);

			/// <summary>
			/// The minimum height in pixels of the dropdown list when the list is constrained by its distance to the viewport edges (defaults to 90).
			/// </summary>
			[DefaultValue(typeof(Unit), "90")]
			public override Unit MinHeight 
			{ 
				get
				{
					return this.minHeight;
				}
				set
				{
					this.minHeight = value;
				}
			}

			private int minChars = 4;

			/// <summary>
			/// The minimum number of characters the user must type before autocomplete and typeahead activate (defaults to 4 if remote or 0 if local, does not apply if editable = false).
			/// </summary>
			[DefaultValue(4)]
			public virtual int MinChars 
			{ 
				get
				{
					return this.minChars;
				}
				set
				{
					this.minChars = value;
				}
			}

			private Unit minListWidth = Unit.Pixel(70);

			/// <summary>
			/// The minimum width of the dropdown list in pixels (defaults to 70, will be ignored if listWidth has a higher value).
			/// </summary>
			[DefaultValue(typeof(Unit), "70")]
			public virtual Unit MinListWidth 
			{ 
				get
				{
					return this.minListWidth;
				}
				set
				{
					this.minListWidth = value;
				}
			}

			private DataLoadMode mode = DataLoadMode.Remote;

			/// <summary>
			/// Set to 'local' if the ComboBox loads local data (defaults to 'remote' which loads from the server).
			/// </summary>
			[DefaultValue(DataLoadMode.Remote)]
			public virtual DataLoadMode Mode 
			{ 
				get
				{
					return this.mode;
				}
				set
				{
					this.mode = value;
				}
			}

			private int pageSize = 0;

			/// <summary>
			/// If greater than 0, a paging toolbar is displayed in the footer of the dropdown list and the filter queries will execute with page addToStart and limit parameters. Only applies when mode = 'remote' (defaults to 0).
			/// </summary>
			[DefaultValue(0)]
			public virtual int PageSize 
			{ 
				get
				{
					return this.pageSize;
				}
				set
				{
					this.pageSize = value;
				}
			}

			private int queryDelay = 500;

			/// <summary>
			/// The length of time in milliseconds to delay between the addToStart of typing and sending the query to filter the dropdown list (defaults to 500 if mode = 'remote' or 10 if mode = 'local').
			/// </summary>
			[DefaultValue(500)]
			public virtual int QueryDelay 
			{ 
				get
				{
					return this.queryDelay;
				}
				set
				{
					this.queryDelay = value;
				}
			}

			private string queryParam = "query";

			/// <summary>
			/// Name of the query as it will be passed on the querystring (defaults to 'query').
			/// </summary>
			[DefaultValue("query")]
			public virtual string QueryParam 
			{ 
				get
				{
					return this.queryParam;
				}
				set
				{
					this.queryParam = value;
				}
			}

			private bool resizable = false;

			/// <summary>
			/// True to add a resize handle to the bottom of the dropdown list (defaults to false)
			/// </summary>
			[DefaultValue(false)]
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

			private string selectedClass = "";

			/// <summary>
			/// CSS class to apply to the selected items in the dropdown list (defaults to 'x-combo-selected').
			/// </summary>
			[DefaultValue("")]
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

			private ShadowMode shadow = ShadowMode.Sides;

			/// <summary>
			/// 'Sides' for the default effect, 'Frame' for 4-way shadow, and 'Drop' for bottom-right.
			/// </summary>
			[DefaultValue(ShadowMode.Sides)]
			public virtual ShadowMode Shadow 
			{ 
				get
				{
					return this.shadow;
				}
				set
				{
					this.shadow = value;
				}
			}

			private bool enableShadow = true;

			/// <summary>
			/// true for the default effect
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnableShadow 
			{ 
				get
				{
					return this.enableShadow;
				}
				set
				{
					this.enableShadow = value;
				}
			}

			private bool selectOnFocus = false;

			/// <summary>
			/// True to automatically select any existing field text when the field receives input focus (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public override bool SelectOnFocus 
			{ 
				get
				{
					return this.selectOnFocus;
				}
				set
				{
					this.selectOnFocus = value;
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
			
			private string transform = "";

			/// <summary>
			/// The ID of an existing select to convert to a ComboBox.
			/// </summary>
			[DefaultValue("")]
			public virtual string Transform 
			{ 
				get
				{
					return this.transform;
				}
				set
				{
					this.transform = value;
				}
			}

			private string title = "";

			/// <summary>
			/// If supplied, a header element is created containing this text and added into the top of the dropdown list.
			/// </summary>
			[DefaultValue("")]
			public virtual string Title 
			{ 
				get
				{
					return this.title;
				}
				set
				{
					this.title = value;
				}
			}

			private TriggerAction triggerAction = TriggerAction.Query;

			/// <summary>
			/// The action to execute when the trigger field is activated. Use 'All' to run the query specified by the allQuery config option (defaults to 'Query').
			/// </summary>
			[DefaultValue(TriggerAction.Query)]
			public virtual TriggerAction TriggerAction 
			{ 
				get
				{
					return this.triggerAction;
				}
				set
				{
					this.triggerAction = value;
				}
			}

			private bool typeAhead = false;

			/// <summary>
			/// True to populate and autoselect the remainder of the text being typed after a configurable delay (typeAheadDelay) if it matches a known value (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TypeAhead 
			{ 
				get
				{
					return this.typeAhead;
				}
				set
				{
					this.typeAhead = value;
				}
			}

			private int typeAheadDelay = 250;

			/// <summary>
			/// The length of time in milliseconds to wait until the typeahead text is displayed if TypeAhead = true (defaults to 250).
			/// </summary>
			[DefaultValue(250)]
			public virtual int TypeAheadDelay 
			{ 
				get
				{
					return this.typeAheadDelay;
				}
				set
				{
					this.typeAheadDelay = value;
				}
			}

			private string valueField = "";

			/// <summary>
			/// The underlying data value name to bind to this ComboBox (defaults to undefined if mode = 'remote' or 'value' if transforming a select) Note: use of a valueField requires the user to make a selection in order for a value to be mapped.
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

			private string valueNotFoundText = "";

			/// <summary>
			/// When using a name/value combo, if the value passed to setValue is not found in the store, valueNotFoundText will be displayed as the field text if defined (defaults to undefined).
			/// </summary>
			[DefaultValue("")]
			public virtual string ValueNotFoundText 
			{ 
				get
				{
					return this.valueNotFoundText;
				}
				set
				{
					this.valueNotFoundText = value;
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
			
			private bool alwaysMergeItems = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AlwaysMergeItems 
			{ 
				get
				{
					return this.alwaysMergeItems;
				}
				set
				{
					this.alwaysMergeItems = value;
				}
			}

			private bool triggerAutoPostBack = false;

			/// <summary>
			/// Trigger AutoPostBack
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TriggerAutoPostBack 
			{ 
				get
				{
					return this.triggerAutoPostBack;
				}
				set
				{
					this.triggerAutoPostBack = value;
				}
			}

			private ComboAutoPostBackEvent autoPostBackEvent = ComboAutoPostBackEvent.Select;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(ComboAutoPostBackEvent.Select)]
			public virtual ComboAutoPostBackEvent AutoPostBackEvent 
			{ 
				get
				{
					return this.autoPostBackEvent;
				}
				set
				{
					this.autoPostBackEvent = value;
				}
			}

        }
    }
}