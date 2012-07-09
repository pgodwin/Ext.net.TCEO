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
        new public abstract partial class Builder<TTabPanelBase, TBuilder> : PanelBase.Builder<TTabPanelBase, TBuilder>
            where TTabPanelBase : TabPanelBase
            where TBuilder : Builder<TTabPanelBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTabPanelBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The numeric index of the tab that should be initially activated on render.
			/// </summary>
            public virtual TBuilder ActiveTab(BoxComponentBase activeTab)
            {
                this.ToComponent().ActiveTab = activeTab;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The numeric index of the tab that should be initially activated on render.
			/// </summary>
            public virtual TBuilder ActiveTabIndex(int activeTabIndex)
            {
                this.ToComponent().ActiveTabIndex = activeTabIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to animate tab scrolling so that hidden tabs slide smoothly into view (defaults to true). Only applies when EnableTabScroll = true.
			/// </summary>
            public virtual TBuilder AnimScroll(bool animScroll)
            {
                this.ToComponent().AnimScroll = animScroll;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS selector used to search for tabs in existing markup when autoTabs = true (defaults to 'div.x-tab'). This can be any valid selector supported by Ext.DomQuery.select. Note that the query will be executed within the scope of this tab panel only (so that multiple tab panels from markup can be supported on a page).
			/// </summary>
            public virtual TBuilder AutoTabSelector(string autoTabSelector)
            {
                this.ToComponent().AutoTabSelector = autoTabSelector;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to animate tab scrolling so that hidden tabs slide smoothly into view (defaults to true). Only applies when EnableTabScroll = true.
			/// </summary>
            public virtual TBuilder AutoTabs(bool autoTabs)
            {
                this.ToComponent().AutoTabs = autoTabs;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The base CSS class applied to the panel (defaults to 'x-tab-panel').
			/// </summary>
            public virtual TBuilder BaseCls(string baseCls)
            {
                this.ToComponent().BaseCls = baseCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Determining whether or not each tab is rendered only when first accessed (defaults to true).
			/// </summary>
            public virtual TBuilder DeferredRender(bool deferredRender)
            {
                this.ToComponent().DeferredRender = deferredRender;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable scrolling to tabs that may be invisible due to overflowing the overall TabPanel width. Only available with tabs on addToStart. (defaults to false).
			/// </summary>
            public virtual TBuilder EnableTabScroll(bool enableTabScroll)
            {
                this.ToComponent().EnableTabScroll = enableTabScroll;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to true to do a layout of tab items as tabs are changed.
			/// </summary>
            public virtual TBuilder LayoutOnTabChange(bool layoutOnTabChange)
            {
                this.ToComponent().LayoutOnTabChange = layoutOnTabChange;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum width in pixels for each tab when ResizeTabs = true (defaults to 30).
			/// </summary>
            public virtual TBuilder MinTabWidth(Unit minTabWidth)
            {
                this.ToComponent().MinTabWidth = minTabWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to render the tab strip without a background content Container image (defaults to false).
			/// </summary>
            public virtual TBuilder Plain(bool plain)
            {
                this.ToComponent().Plain = plain;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically resize each tab so that the tabs will completely fill the tab strip (defaults to false). Setting this to true may cause specific widths that might be set per tab to be overridden in order to fit them all into view (although MinTabWidth will always be honored).
			/// </summary>
            public virtual TBuilder ResizeTabs(bool resizeTabs)
            {
                this.ToComponent().ResizeTabs = resizeTabs;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of milliseconds that each scroll animation should last (defaults to .35). Only applies when AnimScroll = true.
			/// </summary>
            public virtual TBuilder ScrollDuration(float scrollDuration)
            {
                this.ToComponent().ScrollDuration = scrollDuration;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of pixels to scroll each time a tab scroll button is pressed (defaults to 100, or if ResizeTabs = true, the calculated tab width). Only applies when EnableTabScroll = true.
			/// </summary>
            public virtual TBuilder ScrollIncrement(int scrollIncrement)
            {
                this.ToComponent().ScrollIncrement = scrollIncrement;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Number of milliseconds between each scroll while a tab scroll button is continuously pressed (defaults to 400).
			/// </summary>
            public virtual TBuilder ScrollRepeatInterval(int scrollRepeatInterval)
            {
                this.ToComponent().ScrollRepeatInterval = scrollRepeatInterval;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The number of pixels of space to calculate into the sizing and scrolling of tabs. If you change the margin in CSS, you will need to update this value so calculations are correct with either resizeTabs or scrolling tabs. (defaults to 2)
			/// </summary>
            public virtual TBuilder TabMargin(Unit tabMargin)
            {
                this.ToComponent().TabMargin = tabMargin;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The alignment of the Tabs (defaults to 'Left'). Other option includes 'Right'. Note that tab scrolling is only supported for TabAlign='Left'. Note that when 'Right', the Tabs will be rendered in reverse order.
			/// </summary>
            public virtual TBuilder TabAlign(TabAlign tabAlign)
            {
                this.ToComponent().TabAlign = tabAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// This config option is used on child Components of ths TabPanel. A CSS class name applied to the tab strip item representing the child Component, allowing special styling to be applied.
			/// </summary>
            public virtual TBuilder TabCls(string tabCls)
            {
                this.ToComponent().TabCls = tabCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The position where the tab strip should be rendered (defaults to 'addToStart'). The only other supported value is 'Bottom'. Note that tab scrolling is only supported for position 'addToStart'.
			/// </summary>
            public virtual TBuilder TabPosition(TabPosition tabPosition)
            {
                this.ToComponent().TabPosition = tabPosition;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The initial width in pixels of each new tab (defaults to 120).
			/// </summary>
            public virtual TBuilder TabWidth(Unit tabWidth)
            {
                this.ToComponent().TabWidth = tabWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// For scrolling tabs, the number of pixels to increment on mouse wheel scrolling (defaults to 20).
			/// </summary>
            public virtual TBuilder WheelIncrement(int wheelIncrement)
            {
                this.ToComponent().WheelIncrement = wheelIncrement;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// Default menu for all tabs
			// /// </summary>
            // public virtual TBuilder DefaultTabMenu(MenuCollection defaultTabMenu)
            // {
            //    this.ToComponent().DefaultTabMenu = defaultTabMenu;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// Gets or sets a value indicating whether the control state automatically posts back to the server when tab changed.
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
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Sets the specified Panel as the active Tab. This method fires the beforetabchange event which can return false to cancel the tab change.
			/// </summary>
            public virtual TBuilder Activate(BoxComponentBase item)
            {
                this.ToComponent().Activate(item);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the specified Panel as the active Panel. This method fires the beforetabchange event which can return false to cancel the tab change.
			/// </summary>
            public virtual TBuilder Activate(string item)
            {
                this.ToComponent().Activate(item);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Suspends any internal calculations or scrolling while doing a bulk operation. See endUpdate
			/// </summary>
            public virtual TBuilder BeginUpdate()
            {
                this.ToComponent().BeginUpdate();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Suspends any internal calculations or scrolling while doing a bulk operation. See endUpdate
			/// </summary>
            public virtual TBuilder EndUpdate()
            {
                this.ToComponent().EndUpdate();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hides the tab strip item for the passed tab
			/// </summary>
            public virtual TBuilder HideTabStripItem(int item)
            {
                this.ToComponent().HideTabStripItem(item);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hides the tab strip item for the passed tab
			/// </summary>
            public virtual TBuilder HideTabStripItem(BoxComponentBase item)
            {
                this.ToComponent().HideTabStripItem(item);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hides the tab strip item for the passed tab
			/// </summary>
            public virtual TBuilder HideTabStripItem(string item)
            {
                this.ToComponent().HideTabStripItem(item);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// True to scan the markup in this tab panel for autoTabs using the autoTabSelector
			/// </summary>
            public virtual TBuilder ReadTabs(bool removeExisting)
            {
                this.ToComponent().ReadTabs(removeExisting);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Scrolls to a particular tab if tab scrolling is enabled
			/// </summary>
            public virtual TBuilder ScrollToTab(BoxComponentBase item, bool animate)
            {
                this.ToComponent().ScrollToTab(item, animate);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
			/// </summary>
            public virtual TBuilder SetActiveTab(int index)
            {
                this.ToComponent().SetActiveTab(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
			/// </summary>
            public virtual TBuilder SetActiveTab(BoxComponentBase item)
            {
                this.ToComponent().SetActiveTab(item);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
			/// </summary>
            public virtual TBuilder SetActiveTab(string id)
            {
                this.ToComponent().SetActiveTab(id);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Unhides the tab strip item for the passed tab
			/// </summary>
            public virtual TBuilder UnhideTabStripItem(int index)
            {
                this.ToComponent().UnhideTabStripItem(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Unhides the tab strip item for the passed tab
			/// </summary>
            public virtual TBuilder UnhideTabStripItem(BoxComponentBase item)
            {
                this.ToComponent().UnhideTabStripItem(item);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Unhides the tab strip item for the passed tab
			/// </summary>
            public virtual TBuilder UnhideTabStripItem(string id)
            {
                this.ToComponent().UnhideTabStripItem(id);
                return this as TBuilder;
            }
            
        }        
    }
}