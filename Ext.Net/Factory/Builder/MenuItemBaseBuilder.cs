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
    public abstract partial class MenuItemBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TMenuItemBase, TBuilder> : BaseMenuItem.Builder<TMenuItemBase, TBuilder>
            where TMenuItemBase : MenuItemBase
            where TBuilder : Builder<TMenuItemBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TMenuItemBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PostBackUrl(string postBackUrl)
            {
                this.ToComponent().PostBackUrl = postBackUrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The JavaScript to execute when the item is clicked. Or, please use the &lt;Listeners> for more flexibility.
			/// </summary>
            public virtual TBuilder OnClientClick(string onClientClick)
            {
                this.ToComponent().OnClientClick = onClientClick;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether the control state automatically posts back to the server when button clicked.
			/// </summary>
            public virtual TBuilder AutoPostBack(bool autoPostBack)
            {
                this.ToComponent().AutoPostBack = autoPostBack;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
            public virtual TBuilder CausesValidation(bool causesValidation)
            {
                this.ToComponent().CausesValidation = causesValidation;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
            public virtual TBuilder ValidationGroup(string validationGroup)
            {
                this.ToComponent().ValidationGroup = validationGroup;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True if this item can be visually activated (defaults to true).
			/// </summary>
            public virtual TBuilder CanActivate(bool canActivate)
            {
                this.ToComponent().CanActivate = canActivate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The href attribute to use for the underlying anchor link (defaults to '#').
			/// </summary>
            public virtual TBuilder Href(string href)
            {
                this.ToComponent().Href = href;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The target attribute to use for the underlying anchor link (defaults to '').
			/// </summary>
            public virtual TBuilder HrefTarget(string hrefTarget)
            {
                this.ToComponent().HrefTarget = hrefTarget;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The path to an icon to display in this item (defaults to Ext.BLANK_IMAGE_URL). If icon is specified iconCls should not be.
			/// </summary>
            public virtual TBuilder IconUrl(string iconUrl)
            {
                this.ToComponent().IconUrl = iconUrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class that specifies a background image that will be used as the icon for this item (defaults to ''). If iconCls is specified icon should not be.
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default CSS class to use for menu items (defaults to 'x-menu-item')
			/// </summary>
            public virtual TBuilder ItemCls(string itemCls)
            {
                this.ToComponent().ItemCls = itemCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Length of time in milliseconds to wait before showing this item (defaults to 200)
			/// </summary>
            public virtual TBuilder ShowDelay(int showDelay)
            {
                this.ToComponent().ShowDelay = showDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text to display in this item (defaults to '').
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob
			// /// </summary>
            // public virtual TBuilder Menu(MenuCollection menu)
            // {
            //    this.ToComponent().Menu = menu;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual TBuilder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}