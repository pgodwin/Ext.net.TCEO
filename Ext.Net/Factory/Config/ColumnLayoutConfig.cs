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
    public partial class ColumnLayout
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ColumnLayout(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ColumnLayout.Config Conversion to ColumnLayout
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ColumnLayout(ColumnLayout.Config config)
        {
            return new ColumnLayout(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ContainerLayout.Config 
        { 
			/*  Implicit ColumnLayout.Config Conversion to ColumnLayout.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ColumnLayout.Builder(ColumnLayout.Config config)
			{
				return new ColumnLayout.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool fitHeight = true;

			/// <summary>
			/// True to fit the column elements height-wise into the Container. Defaults to false.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool FitHeight 
			{ 
				get
				{
					return this.fitHeight;
				}
				set
				{
					this.fitHeight = value;
				}
			}

			private bool background = false;

			/// <summary>
			/// True to fill background by predefined color. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Background 
			{ 
				get
				{
					return this.background;
				}
				set
				{
					this.background = value;
				}
			}

			private bool split = false;

			/// <summary>
			/// True to allow resizing of the columns using a SplitBar. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Split 
			{ 
				get
				{
					return this.split;
				}
				set
				{
					this.split = value;
				}
			}

			private int margin = 0;

			/// <summary>
			/// Width of margin between columns in pixels. Overrides any style settings. Defaults to 0.
			/// </summary>
			[DefaultValue(0)]
			public virtual int Margin 
			{ 
				get
				{
					return this.margin;
				}
				set
				{
					this.margin = value;
				}
			}

			private int scrollOffset = 0;

			/// <summary>
			/// The amount of space to reserve for the scrollbar
			/// </summary>
			[DefaultValue(0)]
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
        
			private LayoutColumnCollection columns = null;

			/// <summary>
			/// Columns collection
			/// </summary>
			public LayoutColumnCollection Columns
			{
				get
				{
					if (this.columns == null)
					{
						this.columns = new LayoutColumnCollection();
					}
			
					return this.columns;
				}
			}
			
        }
    }
}