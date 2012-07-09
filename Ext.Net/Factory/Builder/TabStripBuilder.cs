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
    public partial class TabStrip
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BoxComponentBase.Builder<TabStrip, TabStrip.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TabStrip()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TabStrip component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TabStrip.Config config) : base(new TabStrip(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TabStrip component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// Items Collection
			// /// </summary>
            // public virtual TBuilder Items(TabStripItems items)
            // {
            //    this.ToComponent().Items = items;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The ID of the container which has card layout. TabStrip will switch active item automatically beased on the current index.
			/// </summary>
            public virtual TabStrip.Builder ActionContainerID(string actionContainerID)
            {
                this.ToComponent().ActionContainerID = actionContainerID;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// The container which has card layout. TabStrip will switch active item automatically beased on the current index.
			/// </summary>
            public virtual TabStrip.Builder ActionContainer(Container actionContainer)
            {
                this.ToComponent().ActionContainer = actionContainer;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// The numeric index of the tab that should be initially activated on render.
			/// </summary>
            public virtual TabStrip.Builder ActiveTabIndex(int activeTabIndex)
            {
                this.ToComponent().ActiveTabIndex = activeTabIndex;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// True to animate tab scrolling so that hidden tabs slide smoothly into view (defaults to true). Only applies when EnableTabScroll = true.
			/// </summary>
            public virtual TabStrip.Builder AnimScroll(bool animScroll)
            {
                this.ToComponent().AnimScroll = animScroll;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// True to enable scrolling to tabs that may be invisible due to overflowing the overall TabPanel width. Only available with tabs on addToStart. (defaults to false).
			/// </summary>
            public virtual TabStrip.Builder EnableTabScroll(bool enableTabScroll)
            {
                this.ToComponent().EnableTabScroll = enableTabScroll;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// The minimum width in pixels for each tab when ResizeTabs = true (defaults to 30).
			/// </summary>
            public virtual TabStrip.Builder MinTabWidth(Unit minTabWidth)
            {
                this.ToComponent().MinTabWidth = minTabWidth;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// True to render the tab strip without a background content Container image (defaults to true).
			/// </summary>
            public virtual TabStrip.Builder Plain(bool plain)
            {
                this.ToComponent().Plain = plain;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// True to automatically resize each tab so that the tabs will completely fill the tab strip (defaults to false). Setting this to true may cause specific widths that might be set per tab to be overridden in order to fit them all into view (although MinTabWidth will always be honored).
			/// </summary>
            public virtual TabStrip.Builder ResizeTabs(bool resizeTabs)
            {
                this.ToComponent().ResizeTabs = resizeTabs;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// Sync size after active tab change. This property is ignored if AutoGrow=false
			/// </summary>
            public virtual TabStrip.Builder SyncOnTabChange(bool syncOnTabChange)
            {
                this.ToComponent().SyncOnTabChange = syncOnTabChange;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// True to auto grow width
			/// </summary>
            public virtual TabStrip.Builder AutoGrow(bool autoGrow)
            {
                this.ToComponent().AutoGrow = autoGrow;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// The number of milliseconds that each scroll animation should last (defaults to .35). Only applies when AnimScroll = true.
			/// </summary>
            public virtual TabStrip.Builder ScrollDuration(float scrollDuration)
            {
                this.ToComponent().ScrollDuration = scrollDuration;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// The number of pixels to scroll each time a tab scroll button is pressed (defaults to 100, or if ResizeTabs = true, the calculated tab width). Only applies when EnableTabScroll = true.
			/// </summary>
            public virtual TabStrip.Builder ScrollIncrement(int scrollIncrement)
            {
                this.ToComponent().ScrollIncrement = scrollIncrement;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// Number of milliseconds between each scroll while a tab scroll button is continuously pressed (defaults to 400).
			/// </summary>
            public virtual TabStrip.Builder ScrollRepeatInterval(int scrollRepeatInterval)
            {
                this.ToComponent().ScrollRepeatInterval = scrollRepeatInterval;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// The number of pixels of space to calculate into the sizing and scrolling of tabs. If you change the margin in CSS, you will need to update this value so calculations are correct with either resizeTabs or scrolling tabs. (defaults to 2)
			/// </summary>
            public virtual TabStrip.Builder TabMargin(Unit tabMargin)
            {
                this.ToComponent().TabMargin = tabMargin;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// This config option is used on child Components of ths TabPanel. A CSS class name applied to the tab strip item representing the child Component, allowing special styling to be applied.
			/// </summary>
            public virtual TabStrip.Builder TabCls(string tabCls)
            {
                this.ToComponent().TabCls = tabCls;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// The position where the tab strip should be rendered (defaults to 'addToStart'). The only other supported value is 'Bottom'. Note that tab scrolling is only supported for position 'addToStart'.
			/// </summary>
            public virtual TabStrip.Builder TabPosition(TabPosition tabPosition)
            {
                this.ToComponent().TabPosition = tabPosition;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// The initial width in pixels of each new tab (defaults to 120).
			/// </summary>
            public virtual TabStrip.Builder TabWidth(Unit tabWidth)
            {
                this.ToComponent().TabWidth = tabWidth;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// For scrolling tabs, the number of pixels to increment on mouse wheel scrolling (defaults to 20).
			/// </summary>
            public virtual TabStrip.Builder WheelIncrement(int wheelIncrement)
            {
                this.ToComponent().WheelIncrement = wheelIncrement;
                return this as TabStrip.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(TabStripListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(TabStripDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// Gets or sets a value indicating whether the control state automatically posts back to the server when tab changed.
			/// </summary>
            public virtual TabStrip.Builder AutoPostBack(bool autoPostBack)
            {
                this.ToComponent().AutoPostBack = autoPostBack;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
            public virtual TabStrip.Builder CausesValidation(bool causesValidation)
            {
                this.ToComponent().CausesValidation = causesValidation;
                return this as TabStrip.Builder;
            }
             
 			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
            public virtual TabStrip.Builder ValidationGroup(string validationGroup)
            {
                this.ToComponent().ValidationGroup = validationGroup;
                return this as TabStrip.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public TabStrip.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TabStrip(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TabStrip.Builder TabStrip()
        {
            return this.TabStrip(new TabStrip());
        }

        /// <summary>
        /// 
        /// </summary>
        public TabStrip.Builder TabStrip(TabStrip component)
        {
            return new TabStrip.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TabStrip.Builder TabStrip(TabStrip.Config config)
        {
            return new TabStrip.Builder(new TabStrip(config));
        }
    }
}