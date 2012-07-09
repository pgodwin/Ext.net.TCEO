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
    public abstract partial class PanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TPanelBase, TBuilder> : ContainerBase.Builder<TPanelBase, TBuilder>
            where TPanelBase : PanelBase
            where TBuilder : Builder<TPanelBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TPanelBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.Fx class is available, otherwise false).
			/// </summary>
            public virtual TBuilder AnimCollapse(bool animCollapse)
            {
                this.ToComponent().AnimCollapse = animCollapse;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// A valid url spec according to the UpdateOptions Ext.UpdateOptions.update method. If autoLoad is not null, the panel will attempt to load its contents immediately upon render. The URL will become the default URL for this panel's body element, so it may be refreshed at any time.
			// /// </summary>
            // public virtual TBuilder AutoLoad(LoadConfig autoLoad)
            // {
            //    this.ToComponent().AutoLoad = autoLoad;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The base CSS class to apply to this panel's element (defaults to 'x-panel').
			/// </summary>
            public virtual TBuilder BaseCls(string baseCls)
            {
                this.ToComponent().BaseCls = baseCls;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// The bottom toolbar of the panel. This can be a Ext.Toolbar object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.
			// /// </summary>
            // public virtual TBuilder BottomBar(ToolbarCollection bottomBar)
            // {
            //    this.ToComponent().BottomBar = bottomBar;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// Panels themselves do not directly support being closed, but some Panel subclasses do (like Ext.Window) or a Panel Class within an Ext.TabPanel. Specify true to enable closing in such situations. Defaults to false.
			/// </summary>
            public virtual TBuilder Closable(bool closable)
            {
                this.ToComponent().Closable = closable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The action to take when the Panel is closed. The default action is 'close' which will actually remove the Panel from the DOM and destroy it. The other valid option is 'hide' which will simply hide the Panel by setting visibility to hidden and applying negative offsets, keeping the Panel available to be redisplayed via the show method.
			/// </summary>
            public virtual TBuilder CloseAction(CloseAction closeAction)
            {
                this.ToComponent().CloseAction = closeAction;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// The top toolbar of the panel. This can be a Ext.Toolbar object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.
			// /// </summary>
            // public virtual TBuilder TopBar(ToolbarCollection topBar)
            // {
            //    this.ToComponent().TopBar = topBar;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// A Toolbar object, a Toolbar config, or an array of Buttons/Button configs, describing a Toolbar to be rendered into this Panel's footer element.
			// /// </summary>
            // public virtual TBuilder FooterBar(ToolbarCollection footerBar)
            // {
            //    this.ToComponent().FooterBar = footerBar;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.Fx class is available, otherwise false).
			/// </summary>
            public virtual TBuilder FormGroup(bool formGroup)
            {
                this.ToComponent().FormGroup = formGroup;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display an interior border on the body element of the panel, false to hide it (defaults to true). This only applies when border == true. If border == true and bodyBorder == false, the border will display as a 1px wide inset border, giving the entire body element an inset appearance.
			/// </summary>
            public virtual TBuilder BodyBorder(bool bodyBorder)
            {
                this.ToComponent().BodyBorder = bodyBorder;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Additional css class selector to be applied to the body element
			/// </summary>
            public virtual TBuilder BodyCssClass(string bodyCssClass)
            {
                this.ToComponent().BodyCssClass = bodyCssClass;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Custom CSS styles to be applied to the body element in the format expected by Ext.Element.applyStyles (defaults to null).
			/// </summary>
            public virtual TBuilder BodyStyle(string bodyStyle)
            {
                this.ToComponent().BodyStyle = bodyStyle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display the borders of the panel's body element, false to hide them (defaults to true). By default, the border is a 2px wide inset border, but this can be further altered by setting bodyBorder to false.
			/// </summary>
            public virtual TBuilder Border(bool border)
            {
                this.ToComponent().Border = border;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Valid values are \"left\", \"center\" and \"right\" (defaults to \"right\").
			/// </summary>
            public virtual TBuilder ButtonAlign(Alignment buttonAlign)
            {
                this.ToComponent().ButtonAlign = buttonAlign;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// A collection of buttons configs used to add buttons to the footer of this panel.
			// /// </summary>
            // public virtual TBuilder Buttons(ItemsCollection<ButtonBase> buttons)
            // {
            //    this.ToComponent().Buttons = buttons;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// True to make sure the collapse/expand toggle button always renders first (to the left of) any other tools in the panel's title bar, false to render it last (defaults to true).
			/// </summary>
            public virtual TBuilder CollapseFirst(bool collapseFirst)
            {
                this.ToComponent().CollapseFirst = collapseFirst;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to render the panel collapsed, false to render it expanded (defaults to false).
			/// </summary>
            public virtual TBuilder Collapsed(bool collapsed)
            {
                this.ToComponent().Collapsed = collapsed;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class to add to the panel's element after it has been collapsed (defaults to 'x-panel-collapsed').
			/// </summary>
            public virtual TBuilder CollapsedCls(string collapsedCls)
            {
                this.ToComponent().CollapsedCls = collapsedCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to make the panel collapsible and have the expand/collapse toggle button automatically rendered into the header tool button area, false to keep the panel statically sized with no button (defaults to false).
			/// </summary>
            public virtual TBuilder Collapsible(bool collapsible)
            {
                this.ToComponent().Collapsible = collapsible;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable dragging of this Panel (defaults to false).
			/// </summary>
            public virtual TBuilder Draggable(bool draggable)
            {
                this.ToComponent().Draggable = draggable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A comma-delimited list of panel elements to initialize when the panel is rendered.
			/// </summary>
            public virtual TBuilder Elements(string elements)
            {
                this.ToComponent().Elements = elements;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to float the panel (absolute position it with automatic shimming and shadow), false to display it inline where it is rendered (defaults to false).
			/// </summary>
            public virtual TBuilder Floating(bool floating)
            {
                this.ToComponent().Floating = floating;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to create the footer element explicitly, false to skip creating it. By default, when footer is not specified, if one or more buttons have been added to the panel the footer will be created automatically, otherwise it will not.
			/// </summary>
            public virtual TBuilder Footer(bool footer)
            {
                this.ToComponent().Footer = footer;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to render the panel with custom rounded borders, false to render with plain 1px square borders (defaults to false).
			/// </summary>
            public virtual TBuilder Frame(bool frame)
            {
                this.ToComponent().Frame = frame;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to create the header element explicitly, false to skip creating it. By default, when header is not specified, if a title is set the header will be created automatically, otherwise it will not. If a title is set but header is explicitly set to false, the header will not be rendered.
			/// </summary>
            public virtual TBuilder Header(bool header)
            {
                this.ToComponent().Header = header;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display the panel title in the header, false to hide it (defaults to true).
			/// </summary>
            public virtual TBuilder HeaderAsText(bool headerAsText)
            {
                this.ToComponent().HeaderAsText = headerAsText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to hide the expand/collapse toggle button when collapsible = true, false to display it (defaults to false).
			/// </summary>
            public virtual TBuilder HideCollapseTool(bool hideCollapseTool)
            {
                this.ToComponent().HideCollapseTool = hideCollapseTool;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual TBuilder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A CSS class that will provide a background image to be used as the panel header icon (defaults to '').
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// A KeyMap config object (in the format expected by Ext.KeyMap.addBinding used to assign custom key handling to this panel (defaults to null).
			// /// </summary>
            // public virtual TBuilder KeyMap(KeyBindingCollection keyMap)
            // {
            //    this.ToComponent().KeyMap = keyMap;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// True to mask the panel when it is disabled, false to not mask it (defaults to true). Either way, the panel will always tell its contained elements to disable themselves when it is disabled, but masking the panel can provide an additional visual cue that the panel is disabled.
			/// </summary>
            public virtual TBuilder MaskDisabled(bool maskDisabled)
            {
                this.ToComponent().MaskDisabled = maskDisabled;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Minimum width in pixels of all buttons in this panel (defaults to 75).
			/// </summary>
            public virtual TBuilder MinButtonWidth(Unit minButtonWidth)
            {
                this.ToComponent().MinButtonWidth = minButtonWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// ShadowMode to display a shadow behind the panel. Note that this option only applies when floating = true.
			/// </summary>
            public virtual TBuilder Shadow(ShadowMode shadow)
            {
                this.ToComponent().Shadow = shadow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of pixels to offset the shadow if displayed (defaults to 4). Note that this option only applies when floating = true.
			/// </summary>
            public virtual TBuilder ShadowOffset(int shadowOffset)
            {
                this.ToComponent().ShadowOffset = shadowOffset;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to disable the iframe shim in browsers which need one (defaults to true). Note that this option only applies when floating = true.
			/// </summary>
            public virtual TBuilder Shim(bool shim)
            {
                this.ToComponent().Shim = shim;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. See also, PaddingSummary.
			/// </summary>
            public virtual TBuilder Padding(int padding)
            {
                this.ToComponent().Padding = padding;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. See also, Padding.
			/// </summary>
            public virtual TBuilder PaddingSummary(string paddingSummary)
            {
                this.ToComponent().PaddingSummary = paddingSummary;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// An Ext.LoadMask to mask the Panel while loading (defaults to false).
			// /// </summary>
            // public virtual TBuilder LoadMask(LoadMask loadMask)
            // {
            //    this.ToComponent().LoadMask = loadMask;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The title text to display in the panel header (defaults to ''). When a title is specified the header element will automatically be created and displayed unless header is explicitly set to false. If you don't want to specify a title at config time, but you may want one later, you must either specify a non-empty title (a blank space ' ' will do) or header:true so that the content Container element will get created.
			/// </summary>
            public virtual TBuilder Title(string title)
            {
                this.ToComponent().Title = title;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to allow expanding and collapsing the panel (when collapsible = true) by clicking anywhere in the header bar, false to allow it only by clicking to tool button (defaults to false).
			/// </summary>
            public virtual TBuilder TitleCollapse(bool titleCollapse)
            {
                this.ToComponent().TitleCollapse = titleCollapse;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// An array of tool button configs to be added to the header tool area. When rendered, each tool is stored as an Element referenced by a public property called tools.
			// /// </summary>
            // public virtual TBuilder Tools(ToolsCollection tools)
            // {
            //    this.ToComponent().Tools = tools;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// Overrides the baseCls setting to baseCls = 'x-plain' which renders the panel unstyled except for required attributes for Ext layouts to function (e.g. overflow:hidden).
			/// </summary>
            public virtual TBuilder Unstyled(bool unstyled)
            {
                this.ToComponent().Unstyled = unstyled;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Defaults to false. When set to true, an extra css class 'x-panel-normal' will be added to the panel's element, effectively applying css styles suggested by the W3C (see http://www.w3.org/TR/CSS21/sample.html) to the Panel's body element (not the header, footer, etc.).
			/// </summary>
            public virtual TBuilder PreventBodyReset(bool preventBodyReset)
            {
                this.ToComponent().PreventBodyReset = preventBodyReset;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Apply css styles for body
			/// </summary>
            public virtual TBuilder ApplyBodyStyles(string style)
            {
                this.ToComponent().ApplyBodyStyles(style);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Add new css class for body
			/// </summary>
            public virtual TBuilder AddBodyCssClass(string cssClass)
            {
                this.ToComponent().AddBodyCssClass(cssClass);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Remove body's css class
			/// </summary>
            public virtual TBuilder RemoveBodyCssClass(string cssClass)
            {
                this.ToComponent().RemoveBodyCssClass(cssClass);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Collapses the panel body so that it becomes hidden. Fires the beforecollapse event which will cancel the collapse action if it returns false.
			/// </summary>
            public virtual TBuilder Collapse()
            {
                this.ToComponent().Collapse();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Collapses the panel body so that it becomes hidden. Fires the beforecollapse event which will cancel the collapse action if it returns false.
			/// </summary>
            public virtual TBuilder Collapse(bool animate)
            {
                this.ToComponent().Collapse(animate);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Expands the panel body so that it becomes visible. Fires the beforeexpand event which will cancel the expand action if it returns false.
			/// </summary>
            public virtual TBuilder Expand()
            {
                this.ToComponent().Expand();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Expands the panel body so that it becomes visible. Fires the beforeexpand event which will cancel the expand action if it returns false.
			/// </summary>
            public virtual TBuilder Expand(bool animate)
            {
                this.ToComponent().Expand(animate);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Clear loaded content.
			/// </summary>
            public virtual TBuilder ClearContent()
            {
                this.ToComponent().ClearContent();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Loads this content panel immediately with content returned from an XHR call.
			/// </summary>
            public virtual TBuilder LoadContent()
            {
                this.ToComponent().LoadContent();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Loads this content panel immediately with content returned from an XHR call.
			/// </summary>
            public virtual TBuilder LoadContent(string url)
            {
                this.ToComponent().LoadContent(url);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Loads this content panel immediately with content returned from an XHR call.
			/// </summary>
            public virtual TBuilder LoadContent(string url, bool noCache)
            {
                this.ToComponent().LoadContent(url, noCache);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Loads this content panel immediately with content returned from an XHR call.
			/// </summary>
            public virtual TBuilder LoadContent(LoadConfig config)
            {
                this.ToComponent().LoadContent(config);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Loads this content panel immediately with content returned from an XHR call.
			/// </summary>
            public virtual TBuilder LoadContent(JFunction fn)
            {
                this.ToComponent().LoadContent(fn);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Reloads the content panel based on the current LoadConfig.
			/// </summary>
            public virtual TBuilder Reload()
            {
                this.ToComponent().Reload();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the title text for the panel and optionally the icon class.
			/// </summary>
            public virtual TBuilder SetTitle(string title)
            {
                this.ToComponent().SetTitle(title);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the title text for the panel and optionally the icon class.
			/// </summary>
            public virtual TBuilder SetTitle(string title, string cls)
            {
                this.ToComponent().SetTitle(title, cls);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Shortcut for performing an expand or collapse based on the current state of the panel.
			/// </summary>
            public virtual TBuilder ToggleCollapse()
            {
                this.ToComponent().ToggleCollapse();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Shortcut for performing an expand or collapse based on the current state of the panel.
			/// </summary>
            public virtual TBuilder ToggleCollapse(bool animate)
            {
                this.ToComponent().ToggleCollapse(animate);
                return this as TBuilder;
            }
            
        }        
    }
}