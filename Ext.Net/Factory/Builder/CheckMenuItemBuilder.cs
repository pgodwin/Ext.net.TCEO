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
    public partial class CheckMenuItem
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : MenuItemBase.Builder<CheckMenuItem, CheckMenuItem.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CheckMenuItem()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CheckMenuItem component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CheckMenuItem.Config config) : base(new CheckMenuItem(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CheckMenuItem component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to initialize this checkbox as checked (defaults to false). Note that if this checkbox is part of a radio group (group = true) only the last item in the group that is initialized with checked = true will be rendered as checked.
			/// </summary>
            public virtual CheckMenuItem.Builder Checked(bool _checked)
            {
                this.ToComponent().Checked = _checked;
                return this as CheckMenuItem.Builder;
            }
             
 			/// <summary>
			/// All check items with the same group name will automatically be grouped into a single-select radio button group (defaults to '').
			/// </summary>
            public virtual CheckMenuItem.Builder Group(string group)
            {
                this.ToComponent().Group = group;
                return this as CheckMenuItem.Builder;
            }
             
 			/// <summary>
			/// The default CSS class to use for radio group check items (defaults to \"x-menu-group-item\")
			/// </summary>
            public virtual CheckMenuItem.Builder GroupClass(string groupClass)
            {
                this.ToComponent().GroupClass = groupClass;
                return this as CheckMenuItem.Builder;
            }
             
 			/// <summary>
			/// A function that handles the checkchange event.
			/// </summary>
            public virtual CheckMenuItem.Builder CheckHandler(string checkHandler)
            {
                this.ToComponent().CheckHandler = checkHandler;
                return this as CheckMenuItem.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(CheckMenuItemListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side DirectEventHandlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(CheckMenuItemDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Set the checked state of this item.
			/// </summary>
            public virtual CheckMenuItem.Builder SetChecked(bool value, bool suppressEvent)
            {
                this.ToComponent().SetChecked(value, suppressEvent);
                return this;
            }
            
 			/// <summary>
			/// Set the checked state of this item.
			/// </summary>
            public virtual CheckMenuItem.Builder SetChecked(bool value)
            {
                this.ToComponent().SetChecked(value);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public CheckMenuItem.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CheckMenuItem(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CheckMenuItem.Builder CheckMenuItem()
        {
            return this.CheckMenuItem(new CheckMenuItem());
        }

        /// <summary>
        /// 
        /// </summary>
        public CheckMenuItem.Builder CheckMenuItem(CheckMenuItem component)
        {
            return new CheckMenuItem.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CheckMenuItem.Builder CheckMenuItem(CheckMenuItem.Config config)
        {
            return new CheckMenuItem.Builder(new CheckMenuItem(config));
        }
    }
}