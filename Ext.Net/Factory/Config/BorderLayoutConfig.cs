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
    public partial class BorderLayout
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public BorderLayout(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit BorderLayout.Config Conversion to BorderLayout
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator BorderLayout(BorderLayout.Config config)
        {
            return new BorderLayout(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ContainerLayout.Config 
        { 
			/*  Implicit BorderLayout.Config Conversion to BorderLayout.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator BorderLayout.Builder(BorderLayout.Config config)
			{
				return new BorderLayout.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private BorderLayoutRegion north = null;

			/// <summary>
			/// Represent options of north region
			/// </summary>
			public BorderLayoutRegion North
			{
				get
				{
					if (this.north == null)
					{
						this.north = new BorderLayoutRegion();
					}
			
					return this.north;
				}
			}
			        
			private BorderLayoutRegion south = null;

			/// <summary>
			/// Represent options of south region
			/// </summary>
			public BorderLayoutRegion South
			{
				get
				{
					if (this.south == null)
					{
						this.south = new BorderLayoutRegion();
					}
			
					return this.south;
				}
			}
			        
			private BorderLayoutRegion west = null;

			/// <summary>
			/// Represent options of west region
			/// </summary>
			public BorderLayoutRegion West
			{
				get
				{
					if (this.west == null)
					{
						this.west = new BorderLayoutRegion();
					}
			
					return this.west;
				}
			}
			        
			private BorderLayoutRegion east = null;

			/// <summary>
			/// Represent options of east region
			/// </summary>
			public BorderLayoutRegion East
			{
				get
				{
					if (this.east == null)
					{
						this.east = new BorderLayoutRegion();
					}
			
					return this.east;
				}
			}
			        
			private BorderLayoutRegion center = null;

			/// <summary>
			/// Represent options of center region
			/// </summary>
			public BorderLayoutRegion Center
			{
				get
				{
					if (this.center == null)
					{
						this.center = new BorderLayoutRegion();
					}
			
					return this.center;
				}
			}
			
        }
    }
}