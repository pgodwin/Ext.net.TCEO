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
        new public abstract partial class Builder<TDataViewBase, TBuilder> : BoxComponentBase.Builder<TDataViewBase, TBuilder>
            where TDataViewBase : DataViewBase
            where TBuilder : Builder<TDataViewBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TDataViewBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to defer emptyText being applied until the store's first load
			/// </summary>
            public virtual TBuilder DeferEmptyText(bool deferEmptyText)
            {
                this.ToComponent().DeferEmptyText = deferEmptyText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text to display in the view when there is no data to display (defaults to '').
			/// </summary>
            public virtual TBuilder EmptyText(string emptyText)
            {
                this.ToComponent().EmptyText = emptyText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// This is a required setting. A simple CSS selector (e.g. div.some-class or span:first-child) that will be used to determine what nodes this DataView will be working with.
			/// </summary>
            public virtual TBuilder ItemSelector(string itemSelector)
            {
                this.ToComponent().ItemSelector = itemSelector;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A string to display during data load operations (defaults to undefined). If specified, this text will be displayed in a loading div and the view's contents will be cleared while loading, otherwise the view's contents will continue to display normally until the new data is loaded and the contents are replaced.
			/// </summary>
            public virtual TBuilder LoadingText(string loadingText)
            {
                this.ToComponent().LoadingText = loadingText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to allow selection of more than one item at a time, false to allow selection of only a single item at a time or no selection at all, depending on the value of singleSelect (defaults to false).
			/// </summary>
            public virtual TBuilder MultiSelect(bool multiSelect)
            {
                this.ToComponent().MultiSelect = multiSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class to apply to each item in the view on mouseover (defaults to undefined).
			/// </summary>
            public virtual TBuilder OverClass(string overClass)
            {
                this.ToComponent().OverClass = overClass;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class to apply to each selected item in the view (defaults to 'x-view-selected').
			/// </summary>
            public virtual TBuilder SelectedClass(string selectedClass)
            {
                this.ToComponent().SelectedClass = selectedClass;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable multiselection by clicking on multiple items without requiring the user to hold Shift or Ctrl, false to force the user to hold Ctrl or Shift to select more than on item (defaults to false).
			/// </summary>
            public virtual TBuilder SimpleSelect(bool simpleSelect)
            {
                this.ToComponent().SimpleSelect = simpleSelect;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to allow selection of exactly one item at a time, false to allow no selection at all (defaults to false). Note that if multiSelect = true, this value will be ignored.
			/// </summary>
            public virtual TBuilder SingleSelect(bool singleSelect)
            {
                this.ToComponent().SingleSelect = singleSelect;
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
             
 			// /// <summary>
			// /// The template string to use to display each item in the dropdown list.
			// /// </summary>
            // public virtual TBuilder Template(XTemplate template)
            // {
            //    this.ToComponent().Template = template;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// True to enable mouseenter and mouseleave events
			/// </summary>
            public virtual TBuilder TrackOver(bool trackOver)
            {
                this.ToComponent().TrackOver = trackOver;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PrepareData(JFunction prepareData)
            {
                this.ToComponent().PrepareData = prepareData;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Clears all selections.
			/// </summary>
            public virtual TBuilder ClearSelections(bool suppressEvent)
            {
                this.ToComponent().ClearSelections(suppressEvent);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Clears all selections.
			/// </summary>
            public virtual TBuilder ClearSelections()
            {
                this.ToComponent().ClearSelections();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Deselects a node.
			/// </summary>
            public virtual TBuilder Deselect(int index)
            {
                this.ToComponent().Deselect(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Refreshes the view by reloading the data from the store and re-rendering the template.
			/// </summary>
            public virtual TBuilder Refresh()
            {
                this.ToComponent().Refresh();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Refreshes an individual node's data from the store.
			/// </summary>
            public virtual TBuilder RefreshNode(int index)
            {
                this.ToComponent().RefreshNode(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Selects a set of nodes.
			/// </summary>
            public virtual TBuilder Select(int[] indexes, bool keepExisting, bool suppressEvent)
            {
                this.ToComponent().Select(indexes, keepExisting, suppressEvent);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Selects a set of nodes.
			/// </summary>
            public virtual TBuilder Select(int[] indexes)
            {
                this.ToComponent().Select(indexes);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Selects a range of nodes. All nodes between start and end are selected.
			/// </summary>
            public virtual TBuilder SelectRange(int start, int end, bool keepExisting)
            {
                this.ToComponent().SelectRange(start, end, keepExisting);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Selects a range of nodes. All nodes between start and end are selected.
			/// </summary>
            public virtual TBuilder SelectRange(int start, int end)
            {
                this.ToComponent().SelectRange(start, end);
                return this as TBuilder;
            }
            
        }        
    }
}