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
    public abstract partial class BoxComponentBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TBoxComponentBase, TBuilder> : Component.Builder<TBoxComponentBase, TBuilder>
            where TBoxComponentBase : BoxComponentBase
            where TBuilder : Builder<TBoxComponentBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TBoxComponentBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// true to use overflow:'auto' on the components layout element and show scroll bars automatically when necessary, false to clip any overflowing content (defaults to false).
			/// </summary>
            public virtual TBuilder AutoScroll(bool autoScroll)
            {
                this.ToComponent().AutoScroll = autoScroll;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to use height:'auto', false to use fixed height (defaults to false).
			/// </summary>
            public virtual TBuilder AutoHeight(bool autoHeight)
            {
                this.ToComponent().AutoHeight = autoHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to use width:'auto', false to use fixed width (defaults to false).
			/// </summary>
            public virtual TBuilder AutoWidth(bool autoWidth)
            {
                this.ToComponent().AutoWidth = autoWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// By default, collapsible regions are collapsed by clicking the expand/collapse tool button that renders into the region's title bar. Optionally, when collapseMode is set to 'mini' the region's split bar will also display a small collapse button in the center of the bar. In 'mini' mode the region will collapse to a thinner bar than in normal mode. By default collapseMode is undefined, and the only two supported values are undefined and 'mini'. Note that if a collapsible region does not have a title bar, then collapseMode must be set to 'mini' in order for the region to be collapsible by the user as the tool button will not be rendered.
			/// </summary>
            public virtual TBuilder CollapseMode(CollapseMode collapseMode)
            {
                this.ToComponent().CollapseMode = collapseMode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.
			/// </summary>
            public virtual TBuilder BoxMaxHeight(Unit boxMaxHeight)
            {
                this.ToComponent().BoxMaxHeight = boxMaxHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.
			/// </summary>
            public virtual TBuilder BoxMaxWidth(Unit boxMaxWidth)
            {
                this.ToComponent().BoxMaxWidth = boxMaxWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.
			/// </summary>
            public virtual TBuilder BoxMinHeight(Unit boxMinHeight)
            {
                this.ToComponent().BoxMinHeight = boxMinHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.
			/// </summary>
            public virtual TBuilder BoxMinWidth(Unit boxMinWidth)
            {
                this.ToComponent().BoxMinWidth = boxMinWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.
			/// </summary>
            public virtual TBuilder MaxHeight(Unit maxHeight)
            {
                this.ToComponent().MaxHeight = maxHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.
			/// </summary>
            public virtual TBuilder MaxWidth(Unit maxWidth)
            {
                this.ToComponent().MaxWidth = maxWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.
			/// </summary>
            public virtual TBuilder MinHeight(Unit minHeight)
            {
                this.ToComponent().MinHeight = minHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.
			/// </summary>
            public virtual TBuilder MinWidth(Unit minWidth)
            {
                this.ToComponent().MinWidth = minWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum value in pixels which this BoxComponent will set its height to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region. 
			/// </summary>
            public virtual TBuilder RegionMaxHeight(Unit regionMaxHeight)
            {
                this.ToComponent().RegionMaxHeight = regionMaxHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum value in pixels which this BoxComponent will set its width to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region.
			/// </summary>
            public virtual TBuilder RegionMaxWidth(Unit regionMaxWidth)
            {
                this.ToComponent().RegionMaxWidth = regionMaxWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum value in pixels which this BoxComponent will set its height to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region.
			/// </summary>
            public virtual TBuilder RegionMinHeight(Unit regionMinHeight)
            {
                this.ToComponent().RegionMinHeight = regionMinHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum value in pixels which this BoxComponent will set its width to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region.
			/// </summary>
            public virtual TBuilder RegionMinWidth(Unit regionMinWidth)
            {
                this.ToComponent().RegionMinWidth = regionMinWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The height of this component in pixels (defaults to auto).
			/// </summary>
            public virtual TBuilder Height(Unit height)
            {
                this.ToComponent().Height = height;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout or one of the two BoxLayout subclasses.
			/// </summary>
            public virtual TBuilder Margins(string margins)
            {
                this.ToComponent().Margins = margins;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout or one of the two BoxLayout subclasses.
			/// </summary>
            public virtual TBuilder CMargins(string cMargins)
            {
                this.ToComponent().CMargins = cMargins;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The page level x coordinate for this component if contained within a positioning container.
			/// </summary>
            public virtual TBuilder PageX(Unit pageX)
            {
                this.ToComponent().PageX = pageX;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The page level y coordinate for this component if contained within a positioning container.
			/// </summary>
            public virtual TBuilder PageY(Unit pageY)
            {
                this.ToComponent().PageY = pageY;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').
			/// </summary>
            public virtual TBuilder Region(Region region)
            {
                this.ToComponent().Region = region;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to create a SplitRegion and display a 5px wide Ext.SplitBar between this region and its neighbor, allowing the user to resize the regions dynamically. Defaults to false creating a Region. Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').
			/// </summary>
            public virtual TBuilder Split(bool split)
            {
                this.ToComponent().Split = split;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A string to be used as innerHTML (html tags are accepted) to show in a tooltip when mousing over the associated tab selector element. NOTE: TabTip config is used when a BoxComponent is a child of a TabPanel.
			/// </summary>
            public virtual TBuilder TabTip(string tabTip)
            {
                this.ToComponent().TabTip = tabTip;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The width of this component in pixels (defaults to auto).
			/// </summary>
            public virtual TBuilder Width(Unit width)
            {
                this.ToComponent().Width = width;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The local x (left) coordinate for this component if contained within a positioning container.
			/// </summary>
            public virtual TBuilder X(int x)
            {
                this.ToComponent().X = x;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The local y (addToStart) coordinate for this component if contained within a positioning container.
			/// </summary>
            public virtual TBuilder Y(int y)
            {
                this.ToComponent().Y = y;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// Tab's menu
			// /// </summary>
            // public virtual TBuilder TabMenu(MenuCollection tabMenu)
            // {
            //    this.ToComponent().TabMenu = tabMenu;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// Defaults to false. True to hide tab's menu.
			/// </summary>
            public virtual TBuilder TabMenuHidden(bool tabMenuHidden)
            {
                this.ToComponent().TabMenuHidden = tabMenuHidden;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Sets the overflow on the content element of the component.
			/// </summary>
            public virtual TBuilder SetAutoScroll(bool scroll)
            {
                this.ToComponent().SetAutoScroll(scroll);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the page XY position of the component. To set the left and addToStart instead, use setPosition. This method fires the move event.
			/// </summary>
            public virtual TBuilder SetPagePosition(Unit x, Unit y)
            {
                this.ToComponent().SetPagePosition(x, y);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the page XY position of the component. To set the left and addToStart instead, use setPosition. This method fires the move event.
			/// </summary>
            public virtual TBuilder SetPagePosition(int x, int y)
            {
                this.ToComponent().SetPagePosition(x, y);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the left and addToStart of the component. To set the page XY position instead, use setPagePosition. This method fires the move event.
			/// </summary>
            public virtual TBuilder SetPosition(Unit left, Unit top)
            {
                this.ToComponent().SetPosition(left, top);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the left and addToStart of the component. To set the page XY position instead, use setPagePosition. This method fires the move event.
			/// </summary>
            public virtual TBuilder SetPosition(int left, int top)
            {
                this.ToComponent().SetPosition(left, top);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the width and height of the component. This method fires the resize event.
			/// </summary>
            public virtual TBuilder SetSize(Unit width, Unit height)
            {
                this.ToComponent().SetSize(width, height);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the width and height of the component. This method fires the resize event.
			/// </summary>
            public virtual TBuilder SetSize(int width, int height)
            {
                this.ToComponent().SetSize(width, height);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Force the component's size to recalculate based on the underlying element's current height and width.
			/// </summary>
            public virtual TBuilder SyncSize()
            {
                this.ToComponent().SyncSize();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the current box measurements of the component's underlying element.
			/// </summary>
            public virtual TBuilder UpdateBox(Unit x, Unit y, Unit width, Unit height)
            {
                this.ToComponent().UpdateBox(x, y, width, height);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the current box measurements of the component's underlying element.
			/// </summary>
            public virtual TBuilder UpdateBox(int x, int y, int width, int height)
            {
                this.ToComponent().UpdateBox(x, y, width, height);
                return this as TBuilder;
            }
            
        }        
    }
}