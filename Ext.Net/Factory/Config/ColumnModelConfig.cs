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
    public partial class ColumnModel
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ColumnModel(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ColumnModel.Config Conversion to ColumnModel
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ColumnModel(ColumnModel.Config config)
        {
            return new ColumnModel(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : LazyObservable.Config 
        { 
			/*  Implicit ColumnModel.Config Conversion to ColumnModel.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ColumnModel.Builder(ColumnModel.Config config)
			{
				return new ColumnModel.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool defaultSortable = true;

			/// <summary>
			/// Default sortable of columns which have no sortable specified (defaults to false). This property shall preferably be configured through the defaults config property.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DefaultSortable 
			{ 
				get
				{
					return this.defaultSortable;
				}
				set
				{
					this.defaultSortable = value;
				}
			}

			private int defaultWidth = 100;

			/// <summary>
			/// The width of columns which have no width specified (defaults to 100). This property shall preferably be configured through the defaults config property.
			/// </summary>
			[DefaultValue(100)]
			public virtual int DefaultWidth 
			{ 
				get
				{
					return this.defaultWidth;
				}
				set
				{
					this.defaultWidth = value;
				}
			}
        
			private ParameterCollection defaults = null;

			/// <summary>
			/// Object literal which will be used to apply Ext.grid.Column configuration options to all columns. Configuration options specified with individual column configs will supersede these defaults.
			/// </summary>
			public ParameterCollection Defaults
			{
				get
				{
					if (this.defaults == null)
					{
						this.defaults = new ParameterCollection();
					}
			
					return this.defaults;
				}
			}
			        
			private ColumnCollection columns = null;

			/// <summary>
			/// The columns to use when rendering the grid (required).
			/// </summary>
			public ColumnCollection Columns
			{
				get
				{
					if (this.columns == null)
					{
						this.columns = new ColumnCollection();
					}
			
					return this.columns;
				}
			}
			        
			private ColumnListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ColumnListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ColumnListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ColumnDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public ColumnDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ColumnDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}