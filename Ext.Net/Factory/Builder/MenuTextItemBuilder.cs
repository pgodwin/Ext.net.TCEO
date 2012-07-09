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
    public partial class MenuTextItem
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseMenuItem.Builder<MenuTextItem, MenuTextItem.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new MenuTextItem()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MenuTextItem component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MenuTextItem.Config config) : base(new MenuTextItem(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(MenuTextItem component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to hide the containing menu after this item is clicked (defaults to true).
			/// </summary>
            public virtual MenuTextItem.Builder HideOnClick(bool hideOnClick)
            {
                this.ToComponent().HideOnClick = hideOnClick;
                return this as MenuTextItem.Builder;
            }
             
 			/// <summary>
			/// The default CSS class to use for text items (defaults to \"x-menu-text\")
			/// </summary>
            public virtual MenuTextItem.Builder ItemCls(string itemCls)
            {
                this.ToComponent().ItemCls = itemCls;
                return this as MenuTextItem.Builder;
            }
             
 			/// <summary>
			/// The text to display for this item (defaults to '')
			/// </summary>
            public virtual MenuTextItem.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as MenuTextItem.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(BaseMenuItemListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side DirectEventHandlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(BaseMenuItemDirectEvents directEvents)
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
        public MenuTextItem.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.MenuTextItem(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public MenuTextItem.Builder MenuTextItem()
        {
            return this.MenuTextItem(new MenuTextItem());
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuTextItem.Builder MenuTextItem(MenuTextItem component)
        {
            return new MenuTextItem.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuTextItem.Builder MenuTextItem(MenuTextItem.Config config)
        {
            return new MenuTextItem.Builder(new MenuTextItem(config));
        }
    }
}