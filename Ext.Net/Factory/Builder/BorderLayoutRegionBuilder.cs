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
    public partial class BorderLayoutRegion
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : StateManagedItem.Builder<BorderLayoutRegion, BorderLayoutRegion.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new BorderLayoutRegion()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BorderLayoutRegion component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BorderLayoutRegion.Config config) : base(new BorderLayoutRegion(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(BorderLayoutRegion component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// Region items
			// /// </summary>
            // public virtual TBuilder Items(ItemsCollection<Component> items)
            // {
            //    this.ToComponent().Items = items;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// When a collapsed region's bar is clicked, the region's panel will be displayed as a floated panel that will close again once the user mouses out of that panel (or clicks out if AutoHide = false). Setting animFloat to false will prevent the open and close of these floated panels from being animated (defaults to true).
			/// </summary>
            public virtual BorderLayoutRegion.Builder AnimFloat(bool animFloat)
            {
                this.ToComponent().AnimFloat = animFloat;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// When a collapsed region's bar is clicked, the region's panel will be displayed as a floated panel. If autoHide is true, the panel will automatically hide after the user mouses out of the panel. If autoHide is false, the panel will continue to display until the user clicks outside of the panel (defaults to true).
			/// </summary>
            public virtual BorderLayoutRegion.Builder AutoHide(bool autoHide)
            {
                this.ToComponent().AutoHide = autoHide;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// A string containing margins to apply to the region's collapsed element. Example '5 0 5 0' (addToStart, Right, Bottom, Left)
			/// </summary>
            public virtual BorderLayoutRegion.Builder CMarginsSummary(string cMarginsSummary)
            {
                this.ToComponent().CMarginsSummary = cMarginsSummary;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// By default, collapsible regions are collapsed by clicking the expand/collapse tool button that renders into the region's title bar. Optionally, when collapseMode is set to 'mini' the region's split bar will also display a small collapse button in the center of the bar. In 'mini' mode the region will collapse to a thinner bar than in normal mode. By default collapseMode is undefined, and the only two supported values are undefined and 'mini'. Note that if a collapsible region does not have a title bar, then collapseMode must be set to 'mini' in order for the region to be collapsible by the user as the tool button will not be rendered.
			/// </summary>
            public virtual BorderLayoutRegion.Builder CollapseMode(CollapseMode collapseMode)
            {
                this.ToComponent().CollapseMode = collapseMode;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// True to allow the user to collapse this region (defaults to false). If true, an expand/collapse tool button will automatically be rendered into the title bar of the region, otherwise the button will not be shown. Note that a title bar is required to display the toggle button -- if no region title is specified, the region will only be collapsible if CollapseMode is set to 'Mini'.
			/// </summary>
            public virtual BorderLayoutRegion.Builder Collapsible(bool collapsible)
            {
                this.ToComponent().Collapsible = collapsible;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// True to allow clicking a collapsed region's bar to display the region's panel floated above the layout, false to force the user to fully expand a collapsed region by clicking the expand button to see it again (defaults to true).
			/// </summary>
            public virtual BorderLayoutRegion.Builder Floatable(bool floatable)
            {
                this.ToComponent().Floatable = floatable;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// An string containing margins to apply to the region. Example '5 0 5 0' (addToStart, Right, Bottom, Left)
			/// </summary>
            public virtual BorderLayoutRegion.Builder MarginsSummary(string marginsSummary)
            {
                this.ToComponent().MarginsSummary = marginsSummary;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// The minimum allowable height in pixels for this region (defaults to 50)
			/// </summary>
            public virtual BorderLayoutRegion.Builder MinHeight(Unit minHeight)
            {
                this.ToComponent().MinHeight = minHeight;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// The maximum allowable height in pixels for this region
			/// </summary>
            public virtual BorderLayoutRegion.Builder MaxHeight(Unit maxHeight)
            {
                this.ToComponent().MaxHeight = maxHeight;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// The maximum allowable width in pixels for this region.
			/// </summary>
            public virtual BorderLayoutRegion.Builder MaxWidth(Unit maxWidth)
            {
                this.ToComponent().MaxWidth = maxWidth;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// The minimum allowable width in pixels for this region (defaults to 50)
			/// </summary>
            public virtual BorderLayoutRegion.Builder MinWidth(Unit minWidth)
            {
                this.ToComponent().MinWidth = minWidth;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// True to display a tooltip when the user hovers over a region's split bar (defaults to false). The tooltip text will be the value of either SplitTip or CollapsibleSplitTip as appropriate.
			/// </summary>
            public virtual BorderLayoutRegion.Builder UseSplitTips(bool useSplitTips)
            {
                this.ToComponent().UseSplitTips = useSplitTips;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// The tooltip to display when the user hovers over a collapsible region's split bar. Only applies if UseSplitTips = true.
			/// </summary>
            public virtual BorderLayoutRegion.Builder CollapsibleSplitTip(string collapsibleSplitTip)
            {
                this.ToComponent().CollapsibleSplitTip = collapsibleSplitTip;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// The tooltip to display when the user hovers over a collapsible region's split bar. Only applies if UseSplitTips = true.
			/// </summary>
            public virtual BorderLayoutRegion.Builder ExpandableSplitTip(string expandableSplitTip)
            {
                this.ToComponent().ExpandableSplitTip = expandableSplitTip;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// True to display a SplitBar between this region and its neighbor, allowing the user to resize the regions dynamically (defaults to false). When split = true, it is common to specify a minSize and maxSize for the region.
			/// </summary>
            public virtual BorderLayoutRegion.Builder Split(bool split)
            {
                this.ToComponent().Split = split;
                return this as BorderLayoutRegion.Builder;
            }
             
 			/// <summary>
			/// The tooltip to display when the user hovers over a non-collapsible region's split bar. Only applies if UseSplitTips = true.
			/// </summary>
            public virtual BorderLayoutRegion.Builder SplitTip(string splitTip)
            {
                this.ToComponent().SplitTip = splitTip;
                return this as BorderLayoutRegion.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public BorderLayoutRegion.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.BorderLayoutRegion(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public BorderLayoutRegion.Builder BorderLayoutRegion()
        {
            return this.BorderLayoutRegion(new BorderLayoutRegion());
        }

        /// <summary>
        /// 
        /// </summary>
        public BorderLayoutRegion.Builder BorderLayoutRegion(BorderLayoutRegion component)
        {
            return new BorderLayoutRegion.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public BorderLayoutRegion.Builder BorderLayoutRegion(BorderLayoutRegion.Config config)
        {
            return new BorderLayoutRegion.Builder(new BorderLayoutRegion(config));
        }
    }
}