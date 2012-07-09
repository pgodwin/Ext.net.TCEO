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
    public partial class Desktop
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Component.Builder<Desktop, Desktop.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Desktop()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Desktop component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Desktop.Config config) : base(new Desktop(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Desktop component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Modules(DesktopModulesCollection modules)
            // {
            //    this.ToComponent().Modules = modules;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Shortcuts(DesktopShortcuts shortcuts)
            // {
            //    this.ToComponent().Shortcuts = shortcuts;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual Desktop.Builder XTickSize(int xTickSize)
            {
                this.ToComponent().XTickSize = xTickSize;
                return this as Desktop.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual Desktop.Builder YTickSize(int yTickSize)
            {
                this.ToComponent().YTickSize = yTickSize;
                return this as Desktop.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual Desktop.Builder BackgroundColor(string backgroundColor)
            {
                this.ToComponent().BackgroundColor = backgroundColor;
                return this as Desktop.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual Desktop.Builder ShortcutTextColor(string shortcutTextColor)
            {
                this.ToComponent().ShortcutTextColor = shortcutTextColor;
                return this as Desktop.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual Desktop.Builder Wallpaper(string wallpaper)
            {
                this.ToComponent().Wallpaper = wallpaper;
                return this as Desktop.Builder;
            }
             
 			/// <summary>
			/// The maximum length of Ext.ux.TaskBar.TaskButton's text to allow before truncating
			/// </summary>
            public virtual Desktop.Builder TextLengthToTruncate(int textLengthToTruncate)
            {
                this.ToComponent().TextLengthToTruncate = textLengthToTruncate;
                return this as Desktop.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(DesktopListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side DirectEventHandlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(DesktopDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Desktop.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Desktop(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Desktop.Builder Desktop()
        {
            return this.Desktop(new Desktop());
        }

        /// <summary>
        /// 
        /// </summary>
        public Desktop.Builder Desktop(Desktop component)
        {
            return new Desktop.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Desktop.Builder Desktop(Desktop.Config config)
        {
            return new Desktop.Builder(new Desktop(config));
        }
    }
}