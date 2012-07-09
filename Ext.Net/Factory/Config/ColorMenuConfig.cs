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
    public partial class ColorMenu
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ColorMenu(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ColorMenu.Config Conversion to ColorMenu
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ColorMenu(ColorMenu.Config config)
        {
            return new ColorMenu(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : MenuBase.Config 
        { 
			/*  Implicit ColorMenu.Config Conversion to ColorMenu.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ColorMenu.Builder(ColorMenu.Config config)
			{
				return new ColorMenu.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private ColorPalette palette = null;

			/// <summary>
			/// The ColorPalette object
			/// </summary>
			public ColorPalette Palette
			{
				get
				{
					if (this.palette == null)
					{
						this.palette = new ColorPalette();
					}
			
					return this.palette;
				}
			}
			        
			private ColorMenuListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ColorMenuListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ColorMenuListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ColorMenuDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public ColorMenuDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ColorMenuDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}