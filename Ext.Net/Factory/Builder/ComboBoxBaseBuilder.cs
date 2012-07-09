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
        new public abstract partial class Builder<TComboBoxBase, TBuilder> : TriggerFieldBase.Builder<TComboBoxBase, TBuilder>
            where TComboBoxBase : ComboBoxBase<T>
            where TBuilder : Builder<TComboBoxBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TComboBoxBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The text query to send to the server to return all records for the list with no filtering (defaults to '').
			/// </summary>
            public virtual TBuilder AllQuery(string allQuery)
            {
                this.ToComponent().AllQuery = allQuery;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to clear any filters on the store (when in local mode) when reset is called (defaults to true)
			/// </summary>
            public virtual TBuilder ClearFilterOnReset(bool clearFilterOnReset)
            {
                this.ToComponent().ClearFilterOnReset = clearFilterOnReset;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The underlying data field name to bind to this ComboBox (defaults to undefined if mode = 'remote' or 'text' if transforming a select).
			/// </summary>
            public virtual TBuilder DisplayField(string displayField)
            {
                this.ToComponent().DisplayField = displayField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to true).
			/// </summary>
            public virtual TBuilder ForceSelection(bool forceSelection)
            {
                this.ToComponent().ForceSelection = forceSelection;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The height in pixels of the dropdown list resize handle if resizable = true (defaults to 8).
			/// </summary>
            public virtual TBuilder HandleHeight(Unit handleHeight)
            {
                this.ToComponent().HandleHeight = handleHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If hiddenName is specified, hiddenId can also be provided to give the hidden field a unique id (defaults to the hiddenName). The hiddenId and combo id should be different, since no two DOM nodes should share the same id.
			/// </summary>
            public virtual TBuilder HiddenID(string hiddenID)
            {
                this.ToComponent().HiddenID = hiddenID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Sets the initial value of the hidden field if hiddenName is specified to contain the selected valueField, from the Store. Defaults to the configured value.
			/// </summary>
            public virtual TBuilder HiddenValue(string hiddenValue)
            {
                this.ToComponent().HiddenValue = hiddenValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If specified, a hidden form field with this name is dynamically generated to store the field's data value (defaults to the underlying DOM element's name). Required for the combo's value to automatically post during a form submission.
			/// </summary>
            public virtual TBuilder HiddenName(string hiddenName)
            {
                this.ToComponent().HiddenName = hiddenName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// This setting is required if a custom XTemplate has been specified in tpl which assigns a class other than 'x-combo-list-item' to dropdown list items. A simple CSS selector (e.g. div.some-class or span:first-child) that will be used to determine what nodes the DataView which handles the dropdown display will be working with.
			/// </summary>
            public virtual TBuilder ItemSelector(string itemSelector)
            {
                this.ToComponent().ItemSelector = itemSelector;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to not initialize the list for this combo until the field is focused. (defaults to true).
			/// </summary>
            public virtual TBuilder LazyInit(bool lazyInit)
            {
                this.ToComponent().LazyInit = lazyInit;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to prevent the ComboBox from rendering until requested (should always be used when rendering into an Ext.Editor, defaults to false).
			/// </summary>
            public virtual TBuilder LazyRender(bool lazyRender)
            {
                this.ToComponent().LazyRender = lazyRender;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to fire select event after setValue on page load
			/// </summary>
            public virtual TBuilder FireSelectOnLoad(bool fireSelectOnLoad)
            {
                this.ToComponent().FireSelectOnLoad = fireSelectOnLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A valid anchor position value. See Ext.Element.alignTo for details on supported anchor positions (defaults to 'tl-bl').
			/// </summary>
            public virtual TBuilder ListAlign(string listAlign)
            {
                this.ToComponent().ListAlign = listAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// CSS class to apply to the dropdown list element (defaults to '').
			/// </summary>
            public virtual TBuilder ListClass(string listClass)
            {
                this.ToComponent().ListClass = listClass;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The width in pixels of the dropdown list (defaults to the width of the ComboBox field).
			/// </summary>
            public virtual TBuilder ListWidth(Unit listWidth)
            {
                this.ToComponent().ListWidth = listWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text to display in the dropdown list while data is loading. Only applies when mode = 'remote' (defaults to 'Loading...').
			/// </summary>
            public virtual TBuilder LoadingText(string loadingText)
            {
                this.ToComponent().LoadingText = loadingText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum height in pixels of the dropdown list before scrollbars are shown (defaults to 300).
			/// </summary>
            public virtual TBuilder MaxHeight(Unit maxHeight)
            {
                this.ToComponent().MaxHeight = maxHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum height in pixels of the dropdown list when the list is constrained by its distance to the viewport edges (defaults to 90).
			/// </summary>
            public virtual TBuilder MinHeight(Unit minHeight)
            {
                this.ToComponent().MinHeight = minHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum number of characters the user must type before autocomplete and typeahead activate (defaults to 4 if remote or 0 if local, does not apply if editable = false).
			/// </summary>
            public virtual TBuilder MinChars(int minChars)
            {
                this.ToComponent().MinChars = minChars;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum width of the dropdown list in pixels (defaults to 70, will be ignored if listWidth has a higher value).
			/// </summary>
            public virtual TBuilder MinListWidth(Unit minListWidth)
            {
                this.ToComponent().MinListWidth = minListWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to 'local' if the ComboBox loads local data (defaults to 'remote' which loads from the server).
			/// </summary>
            public virtual TBuilder Mode(DataLoadMode mode)
            {
                this.ToComponent().Mode = mode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If greater than 0, a paging toolbar is displayed in the footer of the dropdown list and the filter queries will execute with page addToStart and limit parameters. Only applies when mode = 'remote' (defaults to 0).
			/// </summary>
            public virtual TBuilder PageSize(int pageSize)
            {
                this.ToComponent().PageSize = pageSize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The length of time in milliseconds to delay between the addToStart of typing and sending the query to filter the dropdown list (defaults to 500 if mode = 'remote' or 10 if mode = 'local').
			/// </summary>
            public virtual TBuilder QueryDelay(int queryDelay)
            {
                this.ToComponent().QueryDelay = queryDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Name of the query as it will be passed on the querystring (defaults to 'query').
			/// </summary>
            public virtual TBuilder QueryParam(string queryParam)
            {
                this.ToComponent().QueryParam = queryParam;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to add a resize handle to the bottom of the dropdown list (defaults to false)
			/// </summary>
            public virtual TBuilder Resizable(bool resizable)
            {
                this.ToComponent().Resizable = resizable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// CSS class to apply to the selected items in the dropdown list (defaults to 'x-combo-selected').
			/// </summary>
            public virtual TBuilder SelectedClass(string selectedClass)
            {
                this.ToComponent().SelectedClass = selectedClass;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 'Sides' for the default effect, 'Frame' for 4-way shadow, and 'Drop' for bottom-right.
			/// </summary>
            public virtual TBuilder Shadow(ShadowMode shadow)
            {
                this.ToComponent().Shadow = shadow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true for the default effect
			/// </summary>
            public virtual TBuilder EnableShadow(bool enableShadow)
            {
                this.ToComponent().EnableShadow = enableShadow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically select any existing field text when the field receives input focus (defaults to false).
			/// </summary>
            public virtual TBuilder SelectOnFocus(bool selectOnFocus)
            {
                this.ToComponent().SelectOnFocus = selectOnFocus;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// The template string to use to display each item in the dropdown list.
			// /// </summary>
            // public virtual TBuilder Template(XTemplate template)
            // {
            //    this.ToComponent().Template = template;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The ID of an existing select to convert to a ComboBox.
			/// </summary>
            public virtual TBuilder Transform(string transform)
            {
                this.ToComponent().Transform = transform;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If supplied, a header element is created containing this text and added into the top of the dropdown list.
			/// </summary>
            public virtual TBuilder Title(string title)
            {
                this.ToComponent().Title = title;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The action to execute when the trigger field is activated. Use 'All' to run the query specified by the allQuery config option (defaults to 'Query').
			/// </summary>
            public virtual TBuilder TriggerAction(TriggerAction triggerAction)
            {
                this.ToComponent().TriggerAction = triggerAction;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to populate and autoselect the remainder of the text being typed after a configurable delay (typeAheadDelay) if it matches a known value (defaults to false).
			/// </summary>
            public virtual TBuilder TypeAhead(bool typeAhead)
            {
                this.ToComponent().TypeAhead = typeAhead;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The length of time in milliseconds to wait until the typeahead text is displayed if TypeAhead = true (defaults to 250).
			/// </summary>
            public virtual TBuilder TypeAheadDelay(int typeAheadDelay)
            {
                this.ToComponent().TypeAheadDelay = typeAheadDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The underlying data value name to bind to this ComboBox (defaults to undefined if mode = 'remote' or 'value' if transforming a select) Note: use of a valueField requires the user to make a selection in order for a value to be mapped.
			/// </summary>
            public virtual TBuilder ValueField(string valueField)
            {
                this.ToComponent().ValueField = valueField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// When using a name/value combo, if the value passed to setValue is not found in the store, valueNotFoundText will be displayed as the field text if defined (defaults to undefined).
			/// </summary>
            public virtual TBuilder ValueNotFoundText(string valueNotFoundText)
            {
                this.ToComponent().ValueNotFoundText = valueNotFoundText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The data store to use.
			/// </summary>
            public virtual TBuilder StoreID(string storeID)
            {
                this.ToComponent().StoreID = storeID;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// The data store to use.
			// /// </summary>
            // public virtual TBuilder Store(StoreCollection store)
            // {
            //    this.ToComponent().Store = store;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AlwaysMergeItems(bool alwaysMergeItems)
            {
                this.ToComponent().AlwaysMergeItems = alwaysMergeItems;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Trigger AutoPostBack
			/// </summary>
            public virtual TBuilder TriggerAutoPostBack(bool triggerAutoPostBack)
            {
                this.ToComponent().TriggerAutoPostBack = triggerAutoPostBack;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AutoPostBackEvent(ComboAutoPostBackEvent autoPostBackEvent)
            {
                this.ToComponent().AutoPostBackEvent = autoPostBackEvent;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Clears any text/value currently set in the field
			/// </summary>
            public virtual TBuilder ClearValue()
            {
                this.ToComponent().ClearValue();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hides the dropdown list if it is currently expanded. Fires the collapse event on completion.
			/// </summary>
            public virtual TBuilder Collapse()
            {
                this.ToComponent().Collapse();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Execute a query to filter the dropdown list. Fires the beforequery event prior to performing the query allowing the query action to be canceled if needed.
			/// </summary>
            public virtual TBuilder DoQuery(string query, bool forceAll)
            {
                this.ToComponent().DoQuery(query, forceAll);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Execute a query to filter the dropdown list. Fires the beforequery event prior to performing the query allowing the query action to be canceled if needed.
			/// </summary>
            public virtual TBuilder DoQuery(string query)
            {
                this.ToComponent().DoQuery(query);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Expands the dropdown list if it is currently hidden. Fires the expand event on completion.
			/// </summary>
            public virtual TBuilder Expand()
            {
                this.ToComponent().Expand();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Select an item in the dropdown list by its numeric index in the list. This function does NOT cause the select event to fire. The store must be loaded and the list expanded for this function to work, otherwise use setValue.
			/// </summary>
            public virtual TBuilder Select(int index, bool scrollIntoView)
            {
                this.ToComponent().Select(index, scrollIntoView);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Select an item in the dropdown list by its numeric index in the list. This function does NOT cause the select event to fire. The store must be loaded and the list expanded for this function to work, otherwise use setValue.
			/// </summary>
            public virtual TBuilder Select(int index)
            {
                this.ToComponent().Select(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Select an item in the dropdown list by its data value. This function does NOT cause the select event to fire. The store must be loaded and the list expanded for this function to work, otherwise use setValue.
			/// </summary>
            public virtual TBuilder SelectByValue(string value, bool scrollIntoView)
            {
                this.ToComponent().SelectByValue(value, scrollIntoView);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Select an item in the dropdown list by its data value. This function does NOT cause the select event to fire. The store must be loaded and the list expanded for this function to work, otherwise use setValue.
			/// </summary>
            public virtual TBuilder SelectByValue(string value)
            {
                this.ToComponent().SelectByValue(value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Insert record
			/// </summary>
            public virtual TBuilder InsertRecord(int index, IDictionary<string,object> values)
            {
                this.ToComponent().InsertRecord(index, values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Add record
			/// </summary>
            public virtual TBuilder AddRecord(IDictionary<string, object> values)
            {
                this.ToComponent().AddRecord(values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Insert item
			/// </summary>
            public virtual TBuilder InsertItem(int index, string text, object value)
            {
                this.ToComponent().InsertItem(index, text, value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Add item
			/// </summary>
            public virtual TBuilder AddItem(string text, object value)
            {
                this.ToComponent().AddItem(text, value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Remove by field
			/// </summary>
            public virtual TBuilder RemoveByField(string field, object value)
            {
                this.ToComponent().RemoveByField(field, value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Remove by index
			/// </summary>
            public virtual TBuilder RemoveByIndex(int index)
            {
                this.ToComponent().RemoveByIndex(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Remove by value
			/// </summary>
            public virtual TBuilder RemoveByValue(string value)
            {
                this.ToComponent().RemoveByValue(value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Remove by text
			/// </summary>
            public virtual TBuilder RemoveByText(string text)
            {
                this.ToComponent().RemoveByText(text);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets a data value into the field and validates it. To set the value directly without validation see setRawValue.
			/// </summary>
            public virtual TBuilder SetValueAndFireSelect(object value)
            {
                this.ToComponent().SetValueAndFireSelect(value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets a data value into the field and validates it. To set the value directly without validation see setRawValue.
			/// </summary>
            public virtual TBuilder SetInitValue(object value)
            {
                this.ToComponent().SetInitValue(value);
                return this as TBuilder;
            }
            
        }        
    }
}