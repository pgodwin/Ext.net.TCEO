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
    public abstract partial class BaseMenuItem
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : Component.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string activeClass = "";

			/// <summary>
			/// The CSS class to use when the item becomes activated (defaults to \"x-menu-item-active\").
			/// </summary>
			[DefaultValue("")]
			public virtual string ActiveClass 
			{ 
				get
				{
					return this.activeClass;
				}
				set
				{
					this.activeClass = value;
				}
			}

			private bool canActivate = false;

			/// <summary>
			/// True if this item can be visually activated (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CanActivate 
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

			private string handler = "";

			/// <summary>
			/// A function that will handle the click event of this menu item (defaults to undefined).
			/// </summary>
			[DefaultValue("")]
			public virtual string Handler 
			{ 
				get
				{
					return this.handler;
				}
				set
				{
					this.handler = value;
				}
			}

			private string scope = "";

			/// <summary>
			/// The scope (this reference) in which the handler function will be called.
			/// </summary>
			[DefaultValue("")]
			public virtual string Scope 
			{ 
				get
				{
					return this.scope;
				}
				set
				{
					this.scope = value;
				}
			}

			private int hideDelay = 100;

			/// <summary>
			/// Length of time in milliseconds to wait before hiding after a click (defaults to 100).
			/// </summary>
			[DefaultValue(100)]
			public virtual int HideDelay 
			{ 
				get
				{
					return this.hideDelay;
				}
				set
				{
					this.hideDelay = value;
				}
			}

			private bool hideOnClick = true;

			/// <summary>
			/// True to hide the containing menu after this item is clicked (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool HideOnClick 
			{ 
				get
				{
					return this.hideOnClick;
				}
				set
				{
					this.hideOnClick = value;
				}
			}

        }
    }
}