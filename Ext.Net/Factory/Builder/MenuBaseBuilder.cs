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
    public abstract partial class MenuBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TMenuBase, TBuilder> : ContainerBase.Builder<TMenuBase, TBuilder>
            where TMenuBase : MenuBase
            where TBuilder : Builder<TMenuBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TMenuBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').
			/// </summary>
            public virtual TBuilder DefaultType(string defaultType)
            {
                this.ToComponent().DefaultType = defaultType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whenever a menu gets so long that the items won't fit the viewable area, it provides the user with an easy UI to scroll the menu.
			/// </summary>
            public virtual TBuilder EnableScrolling(bool enableScrolling)
            {
                this.ToComponent().EnableScrolling = enableScrolling;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// By default, a Menu configured as floating:true will be rendered as an Ext.Layer (an absolutely positioned, floating Component with zindex=15000). If configured as floating:false, the Menu may be used as child item of another Container instead of a free-floating Layer.
			/// </summary>
            public virtual TBuilder Floating(bool floating)
            {
                this.ToComponent().Floating = floating;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to allow multiple menus to be displayed at the same time (defaults to false).
			/// </summary>
            public virtual TBuilder AllowOtherMenus(bool allowOtherMenus)
            {
                this.ToComponent().AllowOtherMenus = allowOtherMenus;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default Ext.Element.alignTo anchor position value for this menu relative to its element of origin (defaults to \"tl-bl?\")
			/// </summary>
            public virtual TBuilder DefaultAlign(string defaultAlign)
            {
                this.ToComponent().DefaultAlign = defaultAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// X offset in pixels by which to change the default Menu popup position after aligning according to the defaultAlign configuration.
			/// </summary>
            public virtual TBuilder OffsetX(int offsetX)
            {
                this.ToComponent().OffsetX = offsetX;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Y offset in pixels by which to change the default Menu popup position after aligning according to the defaultAlign configuration.
			/// </summary>
            public virtual TBuilder OffsetY(int offsetY)
            {
                this.ToComponent().OffsetY = offsetY;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to ignore clicks on any item in this menu that is a parent item (displays a submenu) so that the submenu is not dismissed when clicking the parent item (defaults to false).
			/// </summary>
            public virtual TBuilder IgnoreParentClicks(bool ignoreParentClicks)
            {
                this.ToComponent().IgnoreParentClicks = ignoreParentClicks;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum width of the menu in pixels (defaults to 120).
			/// </summary>
            public virtual TBuilder MinWidth(Unit minWidth)
            {
                this.ToComponent().MinWidth = minWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum height of the menu. Only applies when enableScrolling is set to True (defaults to null).
			/// </summary>
            public virtual TBuilder MaxHeight(Unit maxHeight)
            {
                this.ToComponent().MaxHeight = maxHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The amount to scroll the menu. Only applies when enableScrolling is set to True (defaults to 24).
			/// </summary>
            public virtual TBuilder ScrollIncrement(int scrollIncrement)
            {
                this.ToComponent().ScrollIncrement = scrollIncrement;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to show the icon separator. (defaults to true).
			/// </summary>
            public virtual TBuilder ShowSeparator(bool showSeparator)
            {
                this.ToComponent().ShowSeparator = showSeparator;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True or \"sides\" for the default effect, \"frame\" for 4-way shadow, and \"drop\" for bottom-right shadow (defaults to \"sides\")
			/// </summary>
            public virtual TBuilder Shadow(ShadowMode shadow)
            {
                this.ToComponent().Shadow = shadow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Ext.Element.alignTo anchor position value to use for submenus of this menu (defaults to \"tl-tr?\")
			/// </summary>
            public virtual TBuilder SubMenuAlign(string subMenuAlign)
            {
                this.ToComponent().SubMenuAlign = subMenuAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder DisableMenuNavigation(bool disableMenuNavigation)
            {
                this.ToComponent().DisableMenuNavigation = disableMenuNavigation;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RenderToForm(bool renderToForm)
            {
                this.ToComponent().RenderToForm = renderToForm;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Hides this menu and optionally all parent menus
			/// </summary>
            public virtual TBuilder Hide(bool deep)
            {
                this.ToComponent().Hide(deep);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Displays this menu relative to another element
			/// </summary>
            public virtual TBuilder Show(string element, string position)
            {
                this.ToComponent().Show(element, position);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Displays this menu relative to another element
			/// </summary>
            public virtual TBuilder Show(string element)
            {
                this.ToComponent().Show(element);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Displays this menu at a specific xy position
			/// </summary>
            public virtual TBuilder ShowAt(int x, int y)
            {
                this.ToComponent().ShowAt(x, y);
                return this as TBuilder;
            }
            
        }        
    }
}