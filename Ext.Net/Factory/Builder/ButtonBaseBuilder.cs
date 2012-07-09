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
        new public abstract partial class Builder<TButtonBase, TBuilder> : BoxComponentBase.Builder<TButtonBase, TBuilder>
            where TButtonBase : ButtonBase
            where TBuilder : Builder<TButtonBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TButtonBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// By default, if a width is not specified the button will attempt to stretch horizontally to fit its content. If the button is being managed by a width sizing layout (hbox, fit, anchor), set this to false to prevent the button from doing this automatic sizing. Defaults to <tt>undefined</tt>.
			/// </summary>
            public virtual TBuilder AutoWidth(bool autoWidth)
            {
                this.ToComponent().AutoWidth = autoWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable stand out by default (defaults to false).
			/// </summary>
            public virtual TBuilder StandOut(bool standOut)
            {
                this.ToComponent().StandOut = standOut;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder PostBackUrl(string postBackUrl)
            {
                this.ToComponent().PostBackUrl = postBackUrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The JavaScript to execute when the Button is clicked. Or, please use the &lt;Listeners> for more flexibility.
			/// </summary>
            public virtual TBuilder OnClientClick(string onClientClick)
            {
                this.ToComponent().OnClientClick = onClientClick;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to not allow a pressed Button to be depressed (defaults to true). Only valid when enableToggle is true.
			/// </summary>
            public virtual TBuilder AllowDepress(bool allowDepress)
            {
                this.ToComponent().AllowDepress = allowDepress;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The side of the Button box to render the arrow if the button has an associated menu. Defaults to 'Right'.
			/// </summary>
            public virtual TBuilder ArrowAlign(ArrowAlign arrowAlign)
            {
                this.ToComponent().ArrowAlign = arrowAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The type of event to map to the button's event handler (defaults to 'click').
			/// </summary>
            public virtual TBuilder ClickEvent(string clickEvent)
            {
                this.ToComponent().ClickEvent = clickEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable pressed/not pressed toggling (defaults to false).
			/// </summary>
            public virtual TBuilder EnableToggle(bool enableToggle)
            {
                this.ToComponent().EnableToggle = enableToggle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to apply a flat style.
			/// </summary>
            public virtual TBuilder Flat(bool flat)
            {
                this.ToComponent().Flat = flat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Buttons in the footer of a FormPanel may be configured with the option formBind: true. This causes the form's valid state monitor task to enable/disable those Buttons depending on the form's valid/invalid state.
			/// </summary>
            public virtual TBuilder FormBind(bool formBind)
            {
                this.ToComponent().FormBind = formBind;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to disable visual cues on mouseover, mouseout and mousedown (defaults to true).
			/// </summary>
            public virtual TBuilder HandleMouseEvents(bool handleMouseEvents)
            {
                this.ToComponent().HandleMouseEvents = handleMouseEvents;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A function called when the button is clicked (can be used instead of click event).
			/// </summary>
            public virtual TBuilder Handler(string handler)
            {
                this.ToComponent().Handler = handler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual TBuilder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The side of the Button box to render the icon. Defaults to 'Left'.
			/// </summary>
            public virtual TBuilder IconAlign(IconAlign iconAlign)
            {
                this.ToComponent().IconAlign = iconAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A css class which sets a background image to be used as the icon for this button.
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to hide the Menu arrow drop down arrow (defaults to true).
			/// </summary>
            public virtual TBuilder MenuArrow(bool menuArrow)
            {
                this.ToComponent().MenuArrow = menuArrow;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob.
			// /// </summary>
            // public virtual TBuilder Menu(MenuCollection menu)
            // {
            //    this.ToComponent().Menu = menu;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The position to align the menu to (see Ext.Element.alignTo for more details, defaults to 'tl-bl?').
			/// </summary>
            public virtual TBuilder MenuAlign(string menuAlign)
            {
                this.ToComponent().MenuAlign = menuAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum width for this button (used to give a set of buttons a common width).
			/// </summary>
            public virtual TBuilder MinWidth(Unit minWidth)
            {
                this.ToComponent().MinWidth = minWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If used in a Toolbar, the text to be used if this item is shown in the overflow menu.
			/// </summary>
            public virtual TBuilder OverflowText(string overflowText)
            {
                this.ToComponent().OverflowText = overflowText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to addToStart pressed (only if enableToggle = true).
			/// </summary>
            public virtual TBuilder Pressed(bool pressed)
            {
                this.ToComponent().Pressed = pressed;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to repeat fire the click event while the mouse is down. (defaults to false).
			/// </summary>
            public virtual TBuilder Repeat(bool repeat)
            {
                this.ToComponent().Repeat = repeat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The scope of the handler.
			/// </summary>
            public virtual TBuilder Scope(object scope)
            {
                this.ToComponent().Scope = scope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The size of the Button. Defaults to 'Small'.
			/// </summary>
            public virtual TBuilder Scale(ButtonScale scale)
            {
                this.ToComponent().Scale = scale;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set a DOM tabIndex for this button (defaults to undefined).
			/// </summary>
            public virtual TBuilder TabIndex(short tabIndex)
            {
                this.ToComponent().TabIndex = tabIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The position to align the menu to (see Ext.Element.alignTo for more details, defaults to 'tl-bl?').
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Function called when a Button with enableToggle set to true is clicked.
			/// </summary>
            public virtual TBuilder ToggleHandler(string toggleHandler)
            {
                this.ToComponent().ToggleHandler = toggleHandler;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The group this toggle button is a member of (only 1 per group can be pressed, only applies if enableToggle = true).
			/// </summary>
            public virtual TBuilder ToggleGroup(string toggleGroup)
            {
                this.ToComponent().ToggleGroup = toggleGroup;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The tooltip for the button - can be a string to be used as innerHTML (html tags are accepted). Or, see ToolTip config.
			/// </summary>
            public virtual TBuilder ToolTip(string toolTip)
            {
                this.ToComponent().ToolTip = toolTip;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The type of tooltip to use. Either 'qtip' (default) for QuickTips or 'title' for title attribute.
			/// </summary>
            public virtual TBuilder ToolTipType(ToolTipType toolTipType)
            {
                this.ToComponent().ToolTipType = toolTipType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// submit, reset or button - defaults to 'button'.
			/// </summary>
            public virtual TBuilder Type(ButtonType type)
            {
                this.ToComponent().Type = type;
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
			/// 
			/// </summary>
            public virtual TBuilder NavigateUrl(string navigateUrl)
            {
                this.ToComponent().NavigateUrl = navigateUrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Focus the button
			/// </summary>
            public virtual TBuilder Focus()
            {
                this.ToComponent().Focus();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hide this button's menu (if it has one)
			/// </summary>
            public virtual TBuilder HideMenu()
            {
                this.ToComponent().HideMenu();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// initComponent
			/// </summary>
            public virtual TBuilder InitComponent()
            {
                this.ToComponent().InitComponent();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Show this button's menu (if it has one)
			/// </summary>
            public virtual TBuilder ShowMenu()
            {
                this.ToComponent().ShowMenu();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// If a state it passed, it becomes the pressed state otherwise the current state is toggled.
			/// </summary>
            public virtual TBuilder Toggle()
            {
                this.ToComponent().Toggle();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// If a state it passed, it becomes the pressed state otherwise the current state is toggled.
			/// </summary>
            public virtual TBuilder Toggle(bool state)
            {
                this.ToComponent().Toggle(state);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// If a state it passed, it becomes the pressed state otherwise the current state is toggled.
			/// </summary>
            public virtual TBuilder ToggleMenuArrow()
            {
                this.ToComponent().ToggleMenuArrow();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// If a state it passed, it becomes the pressed state otherwise the current state is toggled.
			/// </summary>
            public virtual TBuilder ToggleMenuArrow(bool state)
            {
                this.ToComponent().ToggleMenuArrow(state);
                return this as TBuilder;
            }
            
        }        
    }
}