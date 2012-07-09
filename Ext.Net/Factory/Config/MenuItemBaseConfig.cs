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
        new public abstract partial class Config : BaseMenuItem.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string postBackUrl = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string PostBackUrl 
			{ 
				get
				{
					return this.postBackUrl;
				}
				set
				{
					this.postBackUrl = value;
				}
			}

			private string onClientClick = "";

			/// <summary>
			/// The JavaScript to execute when the item is clicked. Or, please use the &lt;Listeners> for more flexibility.
			/// </summary>
			[DefaultValue("")]
			public virtual string OnClientClick 
			{ 
				get
				{
					return this.onClientClick;
				}
				set
				{
					this.onClientClick = value;
				}
			}

			private bool autoPostBack = false;

			/// <summary>
			/// Gets or sets a value indicating whether the control state automatically posts back to the server when button clicked.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoPostBack 
			{ 
				get
				{
					return this.autoPostBack;
				}
				set
				{
					this.autoPostBack = value;
				}
			}

			private bool causesValidation = true;

			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool CausesValidation 
			{ 
				get
				{
					return this.causesValidation;
				}
				set
				{
					this.causesValidation = value;
				}
			}

			private string validationGroup = "";

			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
			[DefaultValue("")]
			public virtual string ValidationGroup 
			{ 
				get
				{
					return this.validationGroup;
				}
				set
				{
					this.validationGroup = value;
				}
			}

			private bool canActivate = true;

			/// <summary>
			/// True if this item can be visually activated (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public override bool CanActivate 
			{ 
				get
				{
					return this.canActivate;
				}
				set
				{
					this.canActivate = value;
				}
			}

			private string href = "";

			/// <summary>
			/// The href attribute to use for the underlying anchor link (defaults to '#').
			/// </summary>
			[DefaultValue("")]
			public virtual string Href 
			{ 
				get
				{
					return this.href;
				}
				set
				{
					this.href = value;
				}
			}

			private string hrefTarget = "";

			/// <summary>
			/// The target attribute to use for the underlying anchor link (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string HrefTarget 
			{ 
				get
				{
					return this.hrefTarget;
				}
				set
				{
					this.hrefTarget = value;
				}
			}

			private string iconUrl = "";

			/// <summary>
			/// The path to an icon to display in this item (defaults to Ext.BLANK_IMAGE_URL). If icon is specified iconCls should not be.
			/// </summary>
			[DefaultValue("")]
			public virtual string IconUrl 
			{ 
				get
				{
					return this.iconUrl;
				}
				set
				{
					this.iconUrl = value;
				}
			}

			private string iconCls = "";

			/// <summary>
			/// A CSS class that specifies a background image that will be used as the icon for this item (defaults to ''). If iconCls is specified icon should not be.
			/// </summary>
			[DefaultValue("")]
			public virtual string IconCls 
			{ 
				get
				{
					return this.iconCls;
				}
				set
				{
					this.iconCls = value;
				}
			}

			private string itemCls = "";

			/// <summary>
			/// The default CSS class to use for menu items (defaults to 'x-menu-item')
			/// </summary>
			[DefaultValue("")]
			public override string ItemCls 
			{ 
				get
				{
					return this.itemCls;
				}
				set
				{
					this.itemCls = value;
				}
			}

			private int showDelay = 200;

			/// <summary>
			/// Length of time in milliseconds to wait before showing this item (defaults to 200)
			/// </summary>
			[DefaultValue(200)]
			public virtual int ShowDelay 
			{ 
				get
				{
					return this.showDelay;
				}
				set
				{
					this.showDelay = value;
				}
			}

			private string text = "";

			/// <summary>
			/// The text to display in this item (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string Text 
			{ 
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
				}
			}
        
			private MenuCollection menu = null;

			/// <summary>
			/// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob
			/// </summary>
			public MenuCollection Menu
			{
				get
				{
					if (this.menu == null)
					{
						this.menu = new MenuCollection();
					}
			
					return this.menu;
				}
			}
			
			private Icon icon = Icon.None;

			/// <summary>
			/// The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon Icon 
			{ 
				get
				{
					return this.icon;
				}
				set
				{
					this.icon = value;
				}
			}

        }
    }
}