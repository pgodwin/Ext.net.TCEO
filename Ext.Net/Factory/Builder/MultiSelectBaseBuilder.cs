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
        new public abstract partial class Builder<TMultiSelectBase, TBuilder> : Field.Builder<TMultiSelectBase, TBuilder>
            where TMultiSelectBase : MultiSelectBase<T>
            where TBuilder : Builder<TMultiSelectBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TMultiSelectBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
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
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Items(ListItemCollection<T> items)
            // {
            //    this.ToComponent().Items = items;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder SelectedItems(SelectedListItemCollection selectedItems)
            // {
            //    this.ToComponent().SelectedItems = selectedItems;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The underlying data field name to bind to this MultiSelect.
			/// </summary>
            public virtual TBuilder DisplayField(string displayField)
            {
                this.ToComponent().DisplayField = displayField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The underlying data value name to bind to this MultiSelect.
			/// </summary>
            public virtual TBuilder ValueField(string valueField)
            {
                this.ToComponent().ValueField = valueField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to validate that the value length > 0 (defaults to true).
			/// </summary>
            public virtual TBuilder AllowBlank(bool allowBlank)
            {
                this.ToComponent().AllowBlank = allowBlank;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Maximum input field length allowed (defaults to Number.MAX_VALUE).
			/// </summary>
            public virtual TBuilder MaxLength(int maxLength)
            {
                this.ToComponent().MaxLength = maxLength;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Minimum input field length required (defaults to 0).
			/// </summary>
            public virtual TBuilder MinLength(int minLength)
            {
                this.ToComponent().MinLength = minLength;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').
			/// </summary>
            public virtual TBuilder MaxLengthText(string maxLengthText)
            {
                this.ToComponent().MaxLengthText = maxLengthText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').
			/// </summary>
            public virtual TBuilder MinLengthText(string minLengthText)
            {
                this.ToComponent().MinLengthText = minLengthText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the allow blank validation fails (defaults to 'This field is required').
			/// </summary>
            public virtual TBuilder BlankText(string blankText)
            {
                this.ToComponent().BlankText = blankText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Causes drag operations to copy nodes rather than move (defaults to false).
			/// </summary>
            public virtual TBuilder Copy(bool copy)
            {
                this.ToComponent().Copy = copy;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AllowDuplicates(bool allowDuplicates)
            {
                this.ToComponent().AllowDuplicates = allowDuplicates;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AllowTrash(bool allowTrash)
            {
                this.ToComponent().AllowTrash = allowTrash;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The title text to display in the panel header (defaults to '')
			/// </summary>
            public virtual TBuilder Legend(string legend)
            {
                this.ToComponent().Legend = legend;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The string used to delimit between items when set or returned as a string of values
			/// </summary>
            public virtual TBuilder Delimiter(string delimiter)
            {
                this.ToComponent().Delimiter = delimiter;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The ddgroup name(s) for the View's DragZone (defaults to undefined).
			/// </summary>
            public virtual TBuilder DragGroup(string dragGroup)
            {
                this.ToComponent().DragGroup = dragGroup;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The ddgroup name(s) for the View's DropZone (defaults to undefined).
			/// </summary>
            public virtual TBuilder DropGroup(string dropGroup)
            {
                this.ToComponent().DropGroup = dropGroup;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AppendOnly(bool appendOnly)
            {
                this.ToComponent().AppendOnly = appendOnly;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SortField(string sortField)
            {
                this.ToComponent().SortField = sortField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Direction(SortDirection direction)
            {
                this.ToComponent().Direction = direction;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to submit text of selected items
			/// </summary>
            public virtual TBuilder SubmitText(bool submitText)
            {
                this.ToComponent().SubmitText = submitText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set init selecetion without event fires
			/// </summary>
            public virtual TBuilder FireSelectOnLoad(bool fireSelectOnLoad)
            {
                this.ToComponent().FireSelectOnLoad = fireSelectOnLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to allow multi selection (defaults to true).
			/// </summary>
            public virtual TBuilder MultiSelect(bool multiSelect)
            {
                this.ToComponent().MultiSelect = multiSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Selection Mode
			/// </summary>
            public virtual TBuilder KeepSelectionOnClick(KeepSelectionMode keepSelectionOnClick)
            {
                this.ToComponent().KeepSelectionOnClick = keepSelectionOnClick;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Custom CSS styles to be applied to the body element in the format expected by Ext.Element.applyStyles (defaults to null).
			/// </summary>
            public virtual TBuilder BodyStyle(string bodyStyle)
            {
                this.ToComponent().BodyStyle = bodyStyle;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// The bottom toolbar of the panel.
			// /// </summary>
            // public virtual TBuilder BottomBar(ToolbarCollection bottomBar)
            // {
            //    this.ToComponent().BottomBar = bottomBar;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// The top toolbar of the panel.
			// /// </summary>
            // public virtual TBuilder TopBar(ToolbarCollection topBar)
            // {
            //    this.ToComponent().TopBar = topBar;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder UpdateSelection()
            {
                this.ToComponent().UpdateSelection();
                return this as TBuilder;
            }
            
        }        
    }
}