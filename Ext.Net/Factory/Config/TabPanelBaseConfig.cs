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
    public abstract partial class TabPanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : PanelBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private BoxComponentBase activeTab = null;

			/// <summary>
			/// The numeric index of the tab that should be initially activated on render.
			/// </summary>
			[DefaultValue(null)]
			public virtual BoxComponentBase ActiveTab 
			{ 
				get
				{
					return this.activeTab;
				}
				set
				{
					this.activeTab = value;
				}
			}

			private int activeTabIndex = -1;

			/// <summary>
			/// The numeric index of the tab that should be initially activated on render.
			/// </summary>
			[DefaultValue(-1)]
			public virtual int ActiveTabIndex 
			{ 
				get
				{
					return this.activeTabIndex;
				}
				set
				{
					this.activeTabIndex = value;
				}
			}

			private bool animScroll = true;

			/// <summary>
			/// True to animate tab scrolling so that hidden tabs slide smoothly into view (defaults to true). Only applies when EnableTabScroll = true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AnimScroll 
			{ 
				get
				{
					return this.animScroll;
				}
				set
				{
					this.animScroll = value;
				}
			}

			private string autoTabSelector = "div.x-tab";

			/// <summary>
			/// The CSS selector used to search for tabs in existing markup when autoTabs = true (defaults to 'div.x-tab'). This can be any valid selector supported by Ext.DomQuery.select. Note that the query will be executed within the scope of this tab panel only (so that multiple tab panels from markup can be supported on a page).
			/// </summary>
			[DefaultValue("div.x-tab")]
			public virtual string AutoTabSelector 
			{ 
				get
				{
					return this.autoTabSelector;
				}
				set
				{
					this.autoTabSelector = value;
				}
			}

			private bool autoTabs = false;

			/// <summary>
			/// True to animate tab scrolling so that hidden tabs slide smoothly into view (defaults to true). Only applies when EnableTabScroll = true.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoTabs 
			{ 
				get
				{
					return this.autoTabs;
				}
				set
				{
					this.autoTabs = value;
				}
			}

			private string baseCls = "x-tab-panel";

			/// <summary>
			/// The base CSS class applied to the panel (defaults to 'x-tab-panel').
			/// </summary>
			[DefaultValue("x-tab-panel")]
			public override string BaseCls 
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

			private bool deferredRender = true;

			/// <summary>
			/// Determining whether or not each tab is rendered only when first accessed (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DeferredRender 
			{ 
				get
				{
					return this.deferredRender;
				}
				set
				{
					this.deferredRender = value;
				}
			}

			private bool enableTabScroll = false;

			/// <summary>
			/// True to enable scrolling to tabs that may be invisible due to overflowing the overall TabPanel width. Only available with tabs on addToStart. (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnableTabScroll 
			{ 
				get
				{
					return this.enableTabScroll;
				}
				set
				{
					this.enableTabScroll = value;
				}
			}

			private bool layoutOnTabChange = false;

			/// <summary>
			/// Set to true to do a layout of tab items as tabs are changed.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool LayoutOnTabChange 
			{ 
				get
				{
					return this.layoutOnTabChange;
				}
				set
				{
					this.layoutOnTabChange = value;
				}
			}

			private Unit minTabWidth = Unit.Pixel(30);

			/// <summary>
			/// The minimum width in pixels for each tab when ResizeTabs = true (defaults to 30).
			/// </summary>
			[DefaultValue(typeof(Unit), "30")]
			public virtual Unit MinTabWidth 
			{ 
				get
				{
					return this.minTabWidth;
				}
				set
				{
					this.minTabWidth = value;
				}
			}

			private bool plain = false;

			/// <summary>
			/// True to render the tab strip without a background content Container image (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Plain 
			{ 
				get
				{
					return this.plain;
				}
				set
				{
					this.plain = value;
				}
			}

			private bool resizeTabs = false;

			/// <summary>
			/// True to automatically resize each tab so that the tabs will completely fill the tab strip (defaults to false). Setting this to true may cause specific widths that might be set per tab to be overridden in order to fit them all into view (although MinTabWidth will always be honored).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ResizeTabs 
			{ 
				get
				{
					return this.resizeTabs;
				}
				set
				{
					this.resizeTabs = value;
				}
			}

			private float scrollDuration = 0.35f;

			/// <summary>
			/// The number of milliseconds that each scroll animation should last (defaults to .35). Only applies when AnimScroll = true.
			/// </summary>
			[DefaultValue(0.35f)]
			public virtual float ScrollDuration 
			{ 
				get
				{
					return this.scrollDuration;
				}
				set
				{
					this.scrollDuration = value;
				}
			}

			private int scrollIncrement = 100;

			/// <summary>
			/// The number of pixels to scroll each time a tab scroll button is pressed (defaults to 100, or if ResizeTabs = true, the calculated tab width). Only applies when EnableTabScroll = true.
			/// </summary>
			[DefaultValue(100)]
			public virtual int ScrollIncrement 
			{ 
				get
				{
					return this.scrollIncrement;
				}
				set
				{
					this.scrollIncrement = value;
				}
			}

			private int scrollRepeatInterval = 400;

			/// <summary>
			/// Number of milliseconds between each scroll while a tab scroll button is continuously pressed (defaults to 400).
			/// </summary>
			[DefaultValue(400)]
			public virtual int ScrollRepeatInterval 
			{ 
				get
				{
					return this.scrollRepeatInterval;
				}
				set
				{
					this.scrollRepeatInterval = value;
				}
			}

			private Unit tabMargin = Unit.Pixel(2);

			/// <summary>
			/// The number of pixels of space to calculate into the sizing and scrolling of tabs. If you change the margin in CSS, you will need to update this value so calculations are correct with either resizeTabs or scrolling tabs. (defaults to 2)
			/// </summary>
			[DefaultValue(typeof(Unit), "2")]
			public virtual Unit TabMargin 
			{ 
				get
				{
					return this.tabMargin;
				}
				set
				{
					this.tabMargin = value;
				}
			}

			private TabAlign tabAlign = TabAlign.Left;

			/// <summary>
			/// The alignment of the Tabs (defaults to 'Left'). Other option includes 'Right'. Note that tab scrolling is only supported for TabAlign='Left'. Note that when 'Right', the Tabs will be rendered in reverse order.
			/// </summary>
			[DefaultValue(TabAlign.Left)]
			public virtual TabAlign TabAlign 
			{ 
				get
				{
					return this.tabAlign;
				}
				set
				{
					this.tabAlign = value;
				}
			}

			private string tabCls = "";

			/// <summary>
			/// This config option is used on child Components of ths TabPanel. A CSS class name applied to the tab strip item representing the child Component, allowing special styling to be applied.
			/// </summary>
			[DefaultValue("")]
			public virtual string TabCls 
			{ 
				get
				{
					return this.tabCls;
				}
				set
				{
					this.tabCls = value;
				}
			}

			private TabPosition tabPosition = TabPosition.Top;

			/// <summary>
			/// The position where the tab strip should be rendered (defaults to 'addToStart'). The only other supported value is 'Bottom'. Note that tab scrolling is only supported for position 'addToStart'.
			/// </summary>
			[DefaultValue(TabPosition.Top)]
			public virtual TabPosition TabPosition 
			{ 
				get
				{
					return this.tabPosition;
				}
				set
				{
					this.tabPosition = value;
				}
			}

			private Unit tabWidth = Unit.Pixel(120);

			/// <summary>
			/// The initial width in pixels of each new tab (defaults to 120).
			/// </summary>
			[DefaultValue(typeof(Unit), "120")]
			public virtual Unit TabWidth 
			{ 
				get
				{
					return this.tabWidth;
				}
				set
				{
					this.tabWidth = value;
				}
			}

			private int wheelIncrement = 20;

			/// <summary>
			/// For scrolling tabs, the number of pixels to increment on mouse wheel scrolling (defaults to 20).
			/// </summary>
			[DefaultValue(20)]
			public virtual int WheelIncrement 
			{ 
				get
				{
					return this.wheelIncrement;
				}
				set
				{
					this.wheelIncrement = value;
				}
			}
        
			private MenuCollection defaultTabMenu = null;

			/// <summary>
			/// Default menu for all tabs
			/// </summary>
			public MenuCollection DefaultTabMenu
			{
				get
				{
					if (this.defaultTabMenu == null)
					{
						this.defaultTabMenu = new MenuCollection();
					}
			
					return this.defaultTabMenu;
				}
			}
			
			private bool autoPostBack = false;

			/// <summary>
			/// Gets or sets a value indicating whether the control state automatically posts back to the server when tab changed.
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

			private bool causesValidation = false;

			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
			[DefaultValue(false)]
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

        }
    }
}