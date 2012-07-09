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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public BorderLayoutRegion(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit BorderLayoutRegion.Config Conversion to BorderLayoutRegion
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator BorderLayoutRegion(BorderLayoutRegion.Config config)
        {
            return new BorderLayoutRegion(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : StateManagedItem.Config 
        { 
			/*  Implicit BorderLayoutRegion.Config Conversion to BorderLayoutRegion.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator BorderLayoutRegion.Builder(BorderLayoutRegion.Config config)
			{
				return new BorderLayoutRegion.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private ItemsCollection<Component> items = null;

			/// <summary>
			/// Region items
			/// </summary>
			public ItemsCollection<Component> Items
			{
				get
				{
					if (this.items == null)
					{
						this.items = new ItemsCollection<Component>();
					}
			
					return this.items;
				}
			}
			
			private bool animFloat = true;

			/// <summary>
			/// When a collapsed region's bar is clicked, the region's panel will be displayed as a floated panel that will close again once the user mouses out of that panel (or clicks out if AutoHide = false). Setting animFloat to false will prevent the open and close of these floated panels from being animated (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AnimFloat 
			{ 
				get
				{
					return this.animFloat;
				}
				set
				{
					this.animFloat = value;
				}
			}

			private bool autoHide = true;

			/// <summary>
			/// When a collapsed region's bar is clicked, the region's panel will be displayed as a floated panel. If autoHide is true, the panel will automatically hide after the user mouses out of the panel. If autoHide is false, the panel will continue to display until the user clicks outside of the panel (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoHide 
			{ 
				get
				{
					return this.autoHide;
				}
				set
				{
					this.autoHide = value;
				}
			}

			private string cMarginsSummary = "";

			/// <summary>
			/// A string containing margins to apply to the region's collapsed element. Example '5 0 5 0' (addToStart, Right, Bottom, Left)
			/// </summary>
			[DefaultValue("")]
			public virtual string CMarginsSummary 
			{ 
				get
				{
					return this.cMarginsSummary;
				}
				set
				{
					this.cMarginsSummary = value;
				}
			}

			private CollapseMode collapseMode = CollapseMode.Default;

			/// <summary>
			/// By default, collapsible regions are collapsed by clicking the expand/collapse tool button that renders into the region's title bar. Optionally, when collapseMode is set to 'mini' the region's split bar will also display a small collapse button in the center of the bar. In 'mini' mode the region will collapse to a thinner bar than in normal mode. By default collapseMode is undefined, and the only two supported values are undefined and 'mini'. Note that if a collapsible region does not have a title bar, then collapseMode must be set to 'mini' in order for the region to be collapsible by the user as the tool button will not be rendered.
			/// </summary>
			[DefaultValue(CollapseMode.Default)]
			public virtual CollapseMode CollapseMode 
			{ 
				get
				{
					return this.collapseMode;
				}
				set
				{
					this.collapseMode = value;
				}
			}

			private bool collapsible = false;

			/// <summary>
			/// True to allow the user to collapse this region (defaults to false). If true, an expand/collapse tool button will automatically be rendered into the title bar of the region, otherwise the button will not be shown. Note that a title bar is required to display the toggle button -- if no region title is specified, the region will only be collapsible if CollapseMode is set to 'Mini'.
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

			private bool floatable = true;

			/// <summary>
			/// True to allow clicking a collapsed region's bar to display the region's panel floated above the layout, false to force the user to fully expand a collapsed region by clicking the expand button to see it again (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Floatable 
			{ 
				get
				{
					return this.floatable;
				}
				set
				{
					this.floatable = value;
				}
			}

			private string marginsSummary = "";

			/// <summary>
			/// An string containing margins to apply to the region. Example '5 0 5 0' (addToStart, Right, Bottom, Left)
			/// </summary>
			[DefaultValue("")]
			public virtual string MarginsSummary 
			{ 
				get
				{
					return this.marginsSummary;
				}
				set
				{
					this.marginsSummary = value;
				}
			}

			private Unit minHeight = Unit.Pixel(50);

			/// <summary>
			/// The minimum allowable height in pixels for this region (defaults to 50)
			/// </summary>
			[DefaultValue(typeof(Unit), "50")]
			public virtual Unit MinHeight 
			{ 
				get
				{
					return this.minHeight;
				}
				set
				{
					this.minHeight = value;
				}
			}

			private Unit maxHeight = Unit.Empty;

			/// <summary>
			/// The maximum allowable height in pixels for this region
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit MaxHeight 
			{ 
				get
				{
					return this.maxHeight;
				}
				set
				{
					this.maxHeight = value;
				}
			}

			private Unit maxWidth = Unit.Empty;

			/// <summary>
			/// The maximum allowable width in pixels for this region.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit MaxWidth 
			{ 
				get
				{
					return this.maxWidth;
				}
				set
				{
					this.maxWidth = value;
				}
			}

			private Unit minWidth = Unit.Pixel(50);

			/// <summary>
			/// The minimum allowable width in pixels for this region (defaults to 50)
			/// </summary>
			[DefaultValue(typeof(Unit), "50")]
			public virtual Unit MinWidth 
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

			private bool useSplitTips = false;

			/// <summary>
			/// True to display a tooltip when the user hovers over a region's split bar (defaults to false). The tooltip text will be the value of either SplitTip or CollapsibleSplitTip as appropriate.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool UseSplitTips 
			{ 
				get
				{
					return this.useSplitTips;
				}
				set
				{
					this.useSplitTips = value;
				}
			}

			private string collapsibleSplitTip = "Drag to resize. Double click to hide.";

			/// <summary>
			/// The tooltip to display when the user hovers over a collapsible region's split bar. Only applies if UseSplitTips = true.
			/// </summary>
			[DefaultValue("Drag to resize. Double click to hide.")]
			public virtual string CollapsibleSplitTip 
			{ 
				get
				{
					return this.collapsibleSplitTip;
				}
				set
				{
					this.collapsibleSplitTip = value;
				}
			}

			private string expandableSplitTip = "Double click to show.";

			/// <summary>
			/// The tooltip to display when the user hovers over a collapsible region's split bar. Only applies if UseSplitTips = true.
			/// </summary>
			[DefaultValue("Double click to show.")]
			public virtual string ExpandableSplitTip 
			{ 
				get
				{
					return this.expandableSplitTip;
				}
				set
				{
					this.expandableSplitTip = value;
				}
			}

			private bool split = false;

			/// <summary>
			/// True to display a SplitBar between this region and its neighbor, allowing the user to resize the regions dynamically (defaults to false). When split = true, it is common to specify a minSize and maxSize for the region.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Split 
			{ 
				get
				{
					return this.split;
				}
				set
				{
					this.split = value;
				}
			}

			private string splitTip = "Drag to resize.";

			/// <summary>
			/// The tooltip to display when the user hovers over a non-collapsible region's split bar. Only applies if UseSplitTips = true.
			/// </summary>
			[DefaultValue("Drag to resize.")]
			public virtual string SplitTip 
			{ 
				get
				{
					return this.splitTip;
				}
				set
				{
					this.splitTip = value;
				}
			}

        }
    }
}