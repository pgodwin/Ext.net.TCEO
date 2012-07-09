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
    public partial class BufferView
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public BufferView(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit BufferView.Config Conversion to BufferView
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator BufferView(BufferView.Config config)
        {
            return new BufferView(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : GridView.Config 
        { 
			/*  Implicit BufferView.Config Conversion to BufferView.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator BufferView.Builder(BufferView.Config config)
			{
				return new BufferView.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int rowHeight = 19;

			/// <summary>
			/// The height of a row in the grid.
			/// </summary>
			[DefaultValue(19)]
			public virtual int RowHeight 
			{ 
				get
				{
					return this.rowHeight;
				}
				set
				{
					this.rowHeight = value;
				}
			}

			private int borderHeight = 2;

			/// <summary>
			/// The combined height of border-top and border-bottom of a row.
			/// </summary>
			[DefaultValue(2)]
			public virtual int BorderHeight 
			{ 
				get
				{
					return this.borderHeight;
				}
				set
				{
					this.borderHeight = value;
				}
			}

			private int scrollDelay = 100;

			/// <summary>
			/// The number of milliseconds before rendering rows out of the visible viewing area. Defaults to 100. Rows will render immediately with a config of false.
			/// </summary>
			[DefaultValue(100)]
			public virtual int ScrollDelay 
			{ 
				get
				{
					return this.scrollDelay;
				}
				set
				{
					this.scrollDelay = value;
				}
			}

			private int cacheSize = 20;

			/// <summary>
			/// The number of rows to look forward and backwards from the currently viewable area.  The cache applies only to rows that have been rendered already.
			/// </summary>
			[DefaultValue(20)]
			public virtual int CacheSize 
			{ 
				get
				{
					return this.cacheSize;
				}
				set
				{
					this.cacheSize = value;
				}
			}

			private int cleanDelay = 500;

			/// <summary>
			/// The number of milliseconds to buffer cleaning of extra rows not in the cache.
			/// </summary>
			[DefaultValue(500)]
			public virtual int CleanDelay 
			{ 
				get
				{
					return this.cleanDelay;
				}
				set
				{
					this.cleanDelay = value;
				}
			}

        }
    }
}