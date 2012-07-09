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
        new public abstract partial class Config : ContainerBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool animCollapse = true;

			/// <summary>
			/// True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.Fx class is available, otherwise false).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AnimCollapse 
			{ 
				get
				{
					return this.animCollapse;
				}
				set
				{
					this.animCollapse = value;
				}
			}
        
			private LoadConfig autoLoad = null;

			/// <summary>
			/// A valid url spec according to the UpdateOptions Ext.UpdateOptions.update method. If autoLoad is not null, the panel will attempt to load its contents immediately upon render. The URL will become the default URL for this panel's body element, so it may be refreshed at any time.
			/// </summary>
			public LoadConfig AutoLoad
			{
				get
				{
					if (this.autoLoad == null)
					{
						this.autoLoad = new LoadConfig();
					}
			
					return this.autoLoad;
				}
			}
			
			private string baseCls = "";

			/// <summary>
			/// The base CSS class to apply to this panel's element (defaults to 'x-panel').
			/// </summary>
			[DefaultValue("")]
			public virtual string BaseCls 
			{ 
				get
				{
					return this.baseCls;
				}
				set
				{
					this.baseCls = value;
				}
			}
        
			private ToolbarCollection bottomBar = null;

			/// <summary>
			/// The bottom toolbar of the panel. This can be a Ext.Toolbar object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.
			/// </summary>
			public ToolbarCollection BottomBar
			{
				get
				{
					if (this.bottomBar == null)
					{
						this.bottomBar = new ToolbarCollection();
					}
			
					return this.bottomBar;
				}
			}
			
			private bool closable = false;

			/// <summary>
			/// Panels themselves do not directly support being closed, but some Panel subclasses do (like Ext.Window) or a Panel Class within an Ext.TabPanel. Specify true to enable closing in such situations. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Closable 
			{ 
				get
				{
					return this.closable;
				}
				set
				{
					this.closable = value;
				}
			}

			private CloseAction closeAction = CloseAction.Close;

			/// <summary>
			/// The action to take when the Panel is closed. The default action is 'close' which will actually remove the Panel from the DOM and destroy it. The other valid option is 'hide' which will simply hide the Panel by setting visibility to hidden and applying negative offsets, keeping the Panel available to be redisplayed via the show method.
			/// </summary>
			[DefaultValue(CloseAction.Close)]
			public virtual CloseAction CloseAction 
			{ 
				get
				{
					return this.closeAction;
				}
				set
				{
					this.closeAction = value;
				}
			}
        
			private ToolbarCollection topBar = null;

			/// <summary>
			/// The top toolbar of the panel. This can be a Ext.Toolbar object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.
			/// </summary>
			public ToolbarCollection TopBar
			{
				get
				{
					if (this.topBar == null)
					{
						this.topBar = new ToolbarCollection();
					}
			
					return this.topBar;
				}
			}
			        
			private ToolbarCollection footerBar = null;

			/// <summary>
			/// A Toolbar object, a Toolbar config, or an array of Buttons/Button configs, describing a Toolbar to be rendered into this Panel's footer element.
			/// </summary>
			public ToolbarCollection FooterBar
			{
				get
				{
					if (this.footerBar == null)
					{
						this.footerBar = new ToolbarCollection();
					}
			
					return this.footerBar;
				}
			}
			
			private bool formGroup = false;

			/// <summary>
			/// True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.Fx class is available, otherwise false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool FormGroup 
			{ 
				get
				{
					return this.formGroup;
				}
				set
				{
					this.formGroup = value;
				}
			}

			private bool bodyBorder = true;

			/// <summary>
			/// True to display an interior border on the body element of the panel, false to hide it (defaults to true). This only applies when border == true. If border == true and bodyBorder == false, the border will display as a 1px wide inset border, giving the entire body element an inset appearance.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool BodyBorder 
			{ 
				get
				{
					return this.bodyBorder;
				}
				set
				{
					this.bodyBorder = value;
				}
			}

			private string bodyCssClass = "";

			/// <summary>
			/// Additional css class selector to be applied to the body element
			/// </summary>
			[DefaultValue("")]
			public virtual string BodyCssClass 
			{ 
				get
				{
					return this.bodyCssClass;
				}
				set
				{
					this.bodyCssClass = value;
				}
			}

			private string bodyStyle = "";

			/// <summary>
			/// Custom CSS styles to be applied to the body element in the format expected by Ext.Element.applyStyles (defaults to null).
			/// </summary>
			[DefaultValue("")]
			public virtual string BodyStyle 
			{ 
				get
				{
					return this.bodyStyle;
				}
				set
				{
					this.bodyStyle = value;
				}
			}

			private bool border = true;

			/// <summary>
			/// True to display the borders of the panel's body element, false to hide them (defaults to true). By default, the border is a 2px wide inset border, but this can be further altered by setting bodyBorder to false.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Border 
			{ 
				get
				{
					return this.border;
				}
				set
				{
					this.border = value;
				}
			}

			private Alignment buttonAlign = Alignment.Right;

			/// <summary>
			/// Valid values are \"left\", \"center\" and \"right\" (defaults to \"right\").
			/// </summary>
			[DefaultValue(Alignment.Right)]
			public virtual Alignment ButtonAlign 
			{ 
				get
				{
					return this.buttonAlign;
				}
				set
				{
					this.buttonAlign = value;
				}
			}
        
			private ItemsCollection<ButtonBase> buttons = null;

			/// <summary>
			/// A collection of buttons configs used to add buttons to the footer of this panel.
			/// </summary>
			public ItemsCollection<ButtonBase> Buttons
			{
				get
				{
					if (this.buttons == null)
					{
						this.buttons = new ItemsCollection<ButtonBase>();
					}
			
					return this.buttons;
				}
			}
			
			private bool collapseFirst = true;

			/// <summary>
			/// True to make sure the collapse/expand toggle button always renders first (to the left of) any other tools in the panel's title bar, false to render it last (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool CollapseFirst 
			{ 
				get
				{
					return this.collapseFirst;
				}
				set
				{
					this.collapseFirst = value;
				}
			}

			private bool collapsed = false;

			/// <summary>
			/// True to render the panel collapsed, false to render it expanded (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Collapsed 
			{ 
				get
				{
					return this.collapsed;
				}
				set
				{
					this.collapsed = value;
				}
			}

			private string collapsedCls = "";

			/// <summary>
			/// A CSS class to add to the panel's element after it has been collapsed (defaults to 'x-panel-collapsed').
			/// </summary>
			[DefaultValue("")]
			public virtual string CollapsedCls 
			{ 
				get
				{
					return this.collapsedCls;
				}
				set
				{
					this.collapsedCls = value;
				}
			}

			private bool collapsible = false;

			/// <summary>
			/// True to make the panel collapsible and have the expand/collapse toggle button automatically rendered into the header tool button area, false to keep the panel statically sized with no button (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Collapsible 
			{ 
				get
				{
					return this.collapsible;
				}
				set
				{
					this.collapsible = value;
				}
			}

			private bool draggable = false;

			/// <summary>
			/// True to enable dragging of this Panel (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Draggable 
			{ 
				get
				{
					return this.draggable;
				}
				set
				{
					this.draggable = value;
				}
			}

			private string elements = "";

			/// <summary>
			/// A comma-delimited list of panel elements to initialize when the panel is rendered.
			/// </summary>
			[DefaultValue("")]
			public virtual string Elements 
			{ 
				get
				{
					return this.elements;
				}
				set
				{
					this.elements = value;
				}
			}

			private bool floating = false;

			/// <summary>
			/// True to float the panel (absolute position it with automatic shimming and shadow), false to display it inline where it is rendered (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Floating 
			{ 
				get
				{
					return this.floating;
				}
				set
				{
					this.floating = value;
				}
			}

			private bool footer = false;

			/// <summary>
			/// True to create the footer element explicitly, false to skip creating it. By default, when footer is not specified, if one or more buttons have been added to the panel the footer will be created automatically, otherwise it will not.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Footer 
			{ 
				get
				{
					return this.footer;
				}
				set
				{
					this.footer = value;
				}
			}

			private bool frame = false;

			/// <summary>
			/// True to render the panel with custom rounded borders, false to render with plain 1px square borders (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Frame 
			{ 
				get
				{
					return this.frame;
				}
				set
				{
					this.frame = value;
				}
			}

			private bool header = true;

			/// <summary>
			/// True to create the header element explicitly, false to skip creating it. By default, when header is not specified, if a title is set the header will be created automatically, otherwise it will not. If a title is set but header is explicitly set to false, the header will not be rendered.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Header 
			{ 
				get
				{
					return this.header;
				}
				set
				{
					this.header = value;
				}
			}

			private bool headerAsText = true;

			/// <summary>
			/// True to display the panel title in the header, false to hide it (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool HeaderAsText 
			{ 
				get
				{
					return this.headerAsText;
				}
				set
				{
					this.headerAsText = value;
				}
			}

			private bool hideCollapseTool = false;

			/// <summary>
			/// True to hide the expand/collapse toggle button when collapsible = true, false to display it (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideCollapseTool 
			{ 
				get
				{
					return this.hideCollapseTool;
				}
				set
				{
					this.hideCollapseTool = value;
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

			private string iconCls = "";

			/// <summary>
			/// A CSS class that will provide a background image to be used as the panel header icon (defaults to '').
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
        
			private KeyBindingCollection keyMap = null;

			/// <summary>
			/// A KeyMap config object (in the format expected by Ext.KeyMap.addBinding used to assign custom key handling to this panel (defaults to null).
			/// </summary>
			public KeyBindingCollection KeyMap
			{
				get
				{
					if (this.keyMap == null)
					{
						this.keyMap = new KeyBindingCollection();
					}
			
					return this.keyMap;
				}
			}
			
			private bool maskDisabled = true;

			/// <summary>
			/// True to mask the panel when it is disabled, false to not mask it (defaults to true). Either way, the panel will always tell its contained elements to disable themselves when it is disabled, but masking the panel can provide an additional visual cue that the panel is disabled.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool MaskDisabled 
			{ 
				get
				{
					return this.maskDisabled;
				}
				set
				{
					this.maskDisabled = value;
				}
			}

			private Unit minButtonWidth = Unit.Pixel(75);

			/// <summary>
			/// Minimum width in pixels of all buttons in this panel (defaults to 75).
			/// </summary>
			[DefaultValue(typeof(Unit), "75")]
			public virtual Unit MinButtonWidth 
			{ 
				get
				{
					return this.minButtonWidth;
				}
				set
				{
					this.minButtonWidth = value;
				}
			}

			private ShadowMode shadow = ShadowMode.Sides;

			/// <summary>
			/// ShadowMode to display a shadow behind the panel. Note that this option only applies when floating = true.
			/// </summary>
			[DefaultValue(ShadowMode.Sides)]
			public virtual ShadowMode Shadow 
			{ 
				get
				{
					return this.shadow;
				}
				set
				{
					this.shadow = value;
				}
			}

			private int shadowOffset = 4;

			/// <summary>
			/// The number of pixels to offset the shadow if displayed (defaults to 4). Note that this option only applies when floating = true.
			/// </summary>
			[DefaultValue(4)]
			public virtual int ShadowOffset 
			{ 
				get
				{
					return this.shadowOffset;
				}
				set
				{
					this.shadowOffset = value;
				}
			}

			private bool shim = true;

			/// <summary>
			/// False to disable the iframe shim in browsers which need one (defaults to true). Note that this option only applies when floating = true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Shim 
			{ 
				get
				{
					return this.shim;
				}
				set
				{
					this.shim = value;
				}
			}

			private int padding = 0;

			/// <summary>
			/// A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. See also, PaddingSummary.
			/// </summary>
			[DefaultValue(0)]
			public virtual int Padding 
			{ 
				get
				{
					return this.padding;
				}
				set
				{
					this.padding = value;
				}
			}

			private string paddingSummary = "";

			/// <summary>
			/// A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. See also, Padding.
			/// </summary>
			[DefaultValue("")]
			public virtual string PaddingSummary 
			{ 
				get
				{
					return this.paddingSummary;
				}
				set
				{
					this.paddingSummary = value;
				}
			}
        
			private LoadMask loadMask = null;

			/// <summary>
			/// An Ext.LoadMask to mask the Panel while loading (defaults to false).
			/// </summary>
			public LoadMask LoadMask
			{
				get
				{
					if (this.loadMask == null)
					{
						this.loadMask = new LoadMask();
					}
			
					return this.loadMask;
				}
			}
			
			private string title = "";

			/// <summary>
			/// The title text to display in the panel header (defaults to ''). When a title is specified the header element will automatically be created and displayed unless header is explicitly set to false. If you don't want to specify a title at config time, but you may want one later, you must either specify a non-empty title (a blank space ' ' will do) or header:true so that the content Container element will get created.
			/// </summary>
			[DefaultValue("")]
			public virtual string Title 
			{ 
				get
				{
					return this.title;
				}
				set
				{
					this.title = value;
				}
			}

			private bool titleCollapse = false;

			/// <summary>
			/// True to allow expanding and collapsing the panel (when collapsible = true) by clicking anywhere in the header bar, false to allow it only by clicking to tool button (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TitleCollapse 
			{ 
				get
				{
					return this.titleCollapse;
				}
				set
				{
					this.titleCollapse = value;
				}
			}
        
			private ToolsCollection tools = null;

			/// <summary>
			/// An array of tool button configs to be added to the header tool area. When rendered, each tool is stored as an Element referenced by a public property called tools.
			/// </summary>
			public ToolsCollection Tools
			{
				get
				{
					if (this.tools == null)
					{
						this.tools = new ToolsCollection();
					}
			
					return this.tools;
				}
			}
			
			private bool unstyled = false;

			/// <summary>
			/// Overrides the baseCls setting to baseCls = 'x-plain' which renders the panel unstyled except for required attributes for Ext layouts to function (e.g. overflow:hidden).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Unstyled 
			{ 
				get
				{
					return this.unstyled;
				}
				set
				{
					this.unstyled = value;
				}
			}

			private bool preventBodyReset = false;

			/// <summary>
			/// Defaults to false. When set to true, an extra css class 'x-panel-normal' will be added to the panel's element, effectively applying css styles suggested by the W3C (see http://www.w3.org/TR/CSS21/sample.html) to the Panel's body element (not the header, footer, etc.).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PreventBodyReset 
			{ 
				get
				{
					return this.preventBodyReset;
				}
				set
				{
					this.preventBodyReset = value;
				}
			}

        }
    }
}