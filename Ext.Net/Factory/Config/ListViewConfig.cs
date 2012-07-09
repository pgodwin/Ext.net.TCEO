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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ListView(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ListView.Config Conversion to ListView
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ListView(ListView.Config config)
        {
            return new ListView(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : DataView.Config 
        { 
			/*  Implicit ListView.Config Conversion to ListView.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ListView.Builder(ListView.Config config)
			{
				return new ListView.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool columnResize = true;

			/// <summary>
			/// Specify true to enable the columns to be resizable (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ColumnResize 
			{ 
				get
				{
					return this.columnResize;
				}
				set
				{
					this.columnResize = value;
				}
			}

			private double minPct = 0.05;

			/// <summary>
			/// The minimum percentage to allot for any column (defaults to .05)
			/// </summary>
			[DefaultValue(0.05)]
			public virtual double MinPct 
			{ 
				get
				{
					return this.minPct;
				}
				set
				{
					this.minPct = value;
				}
			}

			private bool columnSort = true;

			/// <summary>
			/// Specify true to enable the columns to be sortable (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ColumnSort 
			{ 
				get
				{
					return this.columnSort;
				}
				set
				{
					this.columnSort = value;
				}
			}
        
			private ListViewColumnCollection columns = null;

			/// <summary>
			/// An array of column configuration objects
			/// </summary>
			public ListViewColumnCollection Columns
			{
				get
				{
					if (this.columns == null)
					{
						this.columns = new ListViewColumnCollection();
					}
			
					return this.columns;
				}
			}
			
			private bool hideHeaders = false;

			/// <summary>
			/// true to hide the header row (defaults to false so the header row will be shown).
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

			private bool reserveScrollOffset = false;

			/// <summary>
			/// By default will defer accounting for the configured scrollOffset for 10 milliseconds. Specify true to account for the configured scrollOffset immediately.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ReserveScrollOffset 
			{ 
				get
				{
					return this.reserveScrollOffset;
				}
				set
				{
					this.reserveScrollOffset = value;
				}
			}

			private int scrollOffset = 19;

			/// <summary>
			/// The amount of space to reserve for the scrollbar (defaults to 19 pixels)
			/// </summary>
			[DefaultValue(19)]
			public virtual int ScrollOffset 
			{ 
				get
				{
					return this.scrollOffset;
				}
				set
				{
					this.scrollOffset = value;
				}
			}

			private string overClass = "x-list-over";

			/// <summary>
			/// The CSS class applied when over a row (defaults to 'x-list-over').
			/// </summary>
			[DefaultValue("x-list-over")]
			public override string OverClass 
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

			private string selectedClass = "x-list-selected";

			/// <summary>
			/// The CSS class applied to a selected row (defaults to 'x-list-selected'). 
			/// </summary>
			[DefaultValue("x-list-selected")]
			public override string SelectedClass 
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

			private bool disableHeaders = false;

			/// <summary>
			/// Set this property to true to disable the header click handler disabling sort (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisableHeaders 
			{ 
				get
				{
					return this.disableHeaders;
				}
				set
				{
					this.disableHeaders = value;
				}
			}

        }
    }
}