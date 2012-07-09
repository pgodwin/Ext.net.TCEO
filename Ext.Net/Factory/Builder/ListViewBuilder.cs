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
    public partial class ListView
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : DataView.Builder<ListView, ListView.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ListView()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ListView component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ListView.Config config) : base(new ListView(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ListView component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Specify true to enable the columns to be resizable (defaults to true).
			/// </summary>
            public virtual ListView.Builder ColumnResize(bool columnResize)
            {
                this.ToComponent().ColumnResize = columnResize;
                return this as ListView.Builder;
            }
             
 			/// <summary>
			/// The minimum percentage to allot for any column (defaults to .05)
			/// </summary>
            public virtual ListView.Builder MinPct(double minPct)
            {
                this.ToComponent().MinPct = minPct;
                return this as ListView.Builder;
            }
             
 			/// <summary>
			/// Specify true to enable the columns to be sortable (defaults to true).
			/// </summary>
            public virtual ListView.Builder ColumnSort(bool columnSort)
            {
                this.ToComponent().ColumnSort = columnSort;
                return this as ListView.Builder;
            }
             
 			// /// <summary>
			// /// An array of column configuration objects
			// /// </summary>
            // public virtual TBuilder Columns(ListViewColumnCollection columns)
            // {
            //    this.ToComponent().Columns = columns;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// true to hide the header row (defaults to false so the header row will be shown).
			/// </summary>
            public virtual ListView.Builder HideHeaders(bool hideHeaders)
            {
                this.ToComponent().HideHeaders = hideHeaders;
                return this as ListView.Builder;
            }
             
 			/// <summary>
			/// By default will defer accounting for the configured scrollOffset for 10 milliseconds. Specify true to account for the configured scrollOffset immediately.
			/// </summary>
            public virtual ListView.Builder ReserveScrollOffset(bool reserveScrollOffset)
            {
                this.ToComponent().ReserveScrollOffset = reserveScrollOffset;
                return this as ListView.Builder;
            }
             
 			/// <summary>
			/// The amount of space to reserve for the scrollbar (defaults to 19 pixels)
			/// </summary>
            public virtual ListView.Builder ScrollOffset(int scrollOffset)
            {
                this.ToComponent().ScrollOffset = scrollOffset;
                return this as ListView.Builder;
            }
             
 			/// <summary>
			/// The CSS class applied when over a row (defaults to 'x-list-over').
			/// </summary>
            public virtual ListView.Builder OverClass(string overClass)
            {
                this.ToComponent().OverClass = overClass;
                return this as ListView.Builder;
            }
             
 			/// <summary>
			/// The CSS class applied to a selected row (defaults to 'x-list-selected'). 
			/// </summary>
            public virtual ListView.Builder SelectedClass(string selectedClass)
            {
                this.ToComponent().SelectedClass = selectedClass;
                return this as ListView.Builder;
            }
             
 			/// <summary>
			/// Set this property to true to disable the header click handler disabling sort (defaults to false).
			/// </summary>
            public virtual ListView.Builder DisableHeaders(bool disableHeaders)
            {
                this.ToComponent().DisableHeaders = disableHeaders;
                return this as ListView.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ListView.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ListView(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ListView.Builder ListView()
        {
            return this.ListView(new ListView());
        }

        /// <summary>
        /// 
        /// </summary>
        public ListView.Builder ListView(ListView component)
        {
            return new ListView.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ListView.Builder ListView(ListView.Config config)
        {
            return new ListView.Builder(new ListView(config));
        }
    }
}