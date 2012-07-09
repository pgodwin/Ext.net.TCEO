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
    public abstract partial class ButtonBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : BoxComponentBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoWidth = true;

			/// <summary>
			/// By default, if a width is not specified the button will attempt to stretch horizontally to fit its content. If the button is being managed by a width sizing layout (hbox, fit, anchor), set this to false to prevent the button from doing this automatic sizing. Defaults to <tt>undefined</tt>.
			/// </summary>
			[DefaultValue(true)]
			public override bool AutoWidth 
			{ 
				get
				{
					return this.autoWidth;
				}
				set
				{
					this.autoWidth = value;
				}
			}

			private bool standOut = false;

			/// <summary>
			/// True to enable stand out by default (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool StandOut 
			{ 
				get
				{
					return this.standOut;
				}
				set
				{
					this.standOut = value;
				}
			}

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
			/// The JavaScript to execute when the Button is clicked. Or, please use the &lt;Listeners> for more flexibility.
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

			private bool allowDepress = true;

			/// <summary>
			/// False to not allow a pressed Button to be depressed (defaults to true). Only valid when enableToggle is true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowDepress 
			{ 
				get
				{
					return this.allowDepress;
				}
				set
				{
					this.allowDepress = value;
				}
			}

			private ArrowAlign arrowAlign = ArrowAlign.Right;

			/// <summary>
			/// The side of the Button box to render the arrow if the button has an associated menu. Defaults to 'Right'.
			/// </summary>
			[DefaultValue(ArrowAlign.Right)]
			public virtual ArrowAlign ArrowAlign 
			{ 
				get
				{
					return this.arrowAlign;
				}
				set
				{
					this.arrowAlign = value;
				}
			}

			private string clickEvent = "click";

			/// <summary>
			/// The type of event to map to the button's event handler (defaults to 'click').
			/// </summary>
			[DefaultValue("click")]
			public virtual string ClickEvent 
			{ 
				get
				{
					return this.clickEvent;
				}
				set
				{
					this.clickEvent = value;
				}
			}

			private bool enableToggle = false;

			/// <summary>
			/// True to enable pressed/not pressed toggling (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnableToggle 
			{ 
				get
				{
					return this.enableToggle;
				}
				set
				{
					this.enableToggle = value;
				}
			}

			private bool flat = false;

			/// <summary>
			/// True to apply a flat style.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Flat 
			{ 
				get
				{
					return this.flat;
				}
				set
				{
					this.flat = value;
				}
			}

			private bool formBind = false;

			/// <summary>
			/// Buttons in the footer of a FormPanel may be configured with the option formBind: true. This causes the form's valid state monitor task to enable/disable those Buttons depending on the form's valid/invalid state.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool FormBind 
			{ 
				get
				{
					return this.formBind;
				}
				set
				{
					this.formBind = value;
				}
			}

			private bool handleMouseEvents = true;

			/// <summary>
			/// False to disable visual cues on mouseover, mouseout and mousedown (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool HandleMouseEvents 
			{ 
				get
				{
					return this.handleMouseEvents;
				}
				set
				{
					this.handleMouseEvents = value;
				}
			}

			private string handler = "";

			/// <summary>
			/// A function called when the button is clicked (can be used instead of click event).
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

			private Icon icon = Icon.None;

			/// <summary>
			/// The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.
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

			private IconAlign iconAlign = IconAlign.Left;

			/// <summary>
			/// The side of the Button box to render the icon. Defaults to 'Left'.
			/// </summary>
			[DefaultValue(IconAlign.Left)]
			public virtual IconAlign IconAlign 
			{ 
				get
				{
					return this.iconAlign;
				}
				set
				{
					this.iconAlign = value;
				}
			}

			private string iconCls = "";

			/// <summary>
			/// A css class which sets a background image to be used as the icon for this button.
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

			private bool menuArrow = true;

			/// <summary>
			/// False to hide the Menu arrow drop down arrow (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool MenuArrow 
			{ 
				get
				{
					return this.menuArrow;
				}
				set
				{
					this.menuArrow = value;
				}
			}
        
			private MenuCollection menu = null;

			/// <summary>
			/// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob.
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
			
			private string menuAlign = "tl-bl?";

			/// <summary>
			/// The position to align the menu to (see Ext.Element.alignTo for more details, defaults to 'tl-bl?').
			/// </summary>
			[DefaultValue("tl-bl?")]
			public virtual string MenuAlign 
			{ 
				get
				{
					return this.menuAlign;
				}
				set
				{
					this.menuAlign = value;
				}
			}

			private Unit minWidth = Unit.Pixel(16);

			/// <summary>
			/// The minimum width for this button (used to give a set of buttons a common width).
			/// </summary>
			[DefaultValue(typeof(Unit), "16")]
			public override Unit MinWidth 
			{ 
				get
				{
					return this.minWidth;
				}
				set
				{
					this.minWidth = value;
				}
			}

			private string overflowText = "";

			/// <summary>
			/// If used in a Toolbar, the text to be used if this item is shown in the overflow menu.
			/// </summary>
			[DefaultValue("")]
			public virtual string OverflowText 
			{ 
				get
				{
					return this.overflowText;
				}
				set
				{
					this.overflowText = value;
				}
			}

			private bool pressed = false;

			/// <summary>
			/// True to addToStart pressed (only if enableToggle = true).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Pressed 
			{ 
				get
				{
					return this.pressed;
				}
				set
				{
					this.pressed = value;
				}
			}

			private bool repeat = false;

			/// <summary>
			/// True to repeat fire the click event while the mouse is down. (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Repeat 
			{ 
				get
				{
					return this.repeat;
				}
				set
				{
					this.repeat = value;
				}
			}

			private object scope = null;

			/// <summary>
			/// The scope of the handler.
			/// </summary>
			[DefaultValue(null)]
			public virtual object Scope 
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

			private ButtonScale scale = ButtonScale.Small;

			/// <summary>
			/// The size of the Button. Defaults to 'Small'.
			/// </summary>
			[DefaultValue(ButtonScale.Small)]
			public virtual ButtonScale Scale 
			{ 
				get
				{
					return this.scale;
				}
				set
				{
					this.scale = value;
				}
			}

			private short tabIndex = (short)0;

			/// <summary>
			/// Set a DOM tabIndex for this button (defaults to undefined).
			/// </summary>
			[DefaultValue((short)0)]
			public override short TabIndex 
			{ 
				get
				{
					return this.tabIndex;
				}
				set
				{
					this.tabIndex = value;
				}
			}

			private string text = "";

			/// <summary>
			/// The position to align the menu to (see Ext.Element.alignTo for more details, defaults to 'tl-bl?').
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

			private string toggleHandler = "";

			/// <summary>
			/// Function called when a Button with enableToggle set to true is clicked.
			/// </summary>
			[DefaultValue("")]
			public virtual string ToggleHandler 
			{ 
				get
				{
					return this.toggleHandler;
				}
				set
				{
					this.toggleHandler = value;
				}
			}

			private string toggleGroup = "";

			/// <summary>
			/// The group this toggle button is a member of (only 1 per group can be pressed, only applies if enableToggle = true).
			/// </summary>
			[DefaultValue("")]
			public virtual string ToggleGroup 
			{ 
				get
				{
					return this.toggleGroup;
				}
				set
				{
					this.toggleGroup = value;
				}
			}

			private string toolTip = "";

			/// <summary>
			/// The tooltip for the button - can be a string to be used as innerHTML (html tags are accepted). Or, see ToolTip config.
			/// </summary>
			[DefaultValue("")]
			public override string ToolTip 
			{ 
				get
				{
					return this.toolTip;
				}
				set
				{
					this.toolTip = value;
				}
			}

			private ToolTipType toolTipType = ToolTipType.Qtip;

			/// <summary>
			/// The type of tooltip to use. Either 'qtip' (default) for QuickTips or 'title' for title attribute.
			/// </summary>
			[DefaultValue(ToolTipType.Qtip)]
			public virtual ToolTipType ToolTipType 
			{ 
				get
				{
					return this.toolTipType;
				}
				set
				{
					this.toolTipType = value;
				}
			}

			private ButtonType type = ButtonType.Button;

			/// <summary>
			/// submit, reset or button - defaults to 'button'.
			/// </summary>
			[DefaultValue(ButtonType.Button)]
			public virtual ButtonType Type 
			{ 
				get
				{
					return this.type;
				}
				set
				{
					this.type = value;
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

			private string navigateUrl = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string NavigateUrl 
			{ 
				get
				{
					return this.navigateUrl;
				}
				set
				{
					this.navigateUrl = value;
				}
			}

			private string target = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Target 
			{ 
				get
				{
					return this.target;
				}
				set
				{
					this.target = value;
				}
			}

        }
    }
}