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
        new public abstract partial class Config : Component.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoScroll = false;

			/// <summary>
			/// true to use overflow:'auto' on the components layout element and show scroll bars automatically when necessary, false to clip any overflowing content (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoScroll 
			{ 
				get
				{
					return this.autoScroll;
				}
				set
				{
					this.autoScroll = value;
				}
			}

			private bool autoHeight = false;

			/// <summary>
			/// True to use height:'auto', false to use fixed height (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoHeight 
			{ 
				get
				{
					return this.autoHeight;
				}
				set
				{
					this.autoHeight = value;
				}
			}

			private bool autoWidth = false;

			/// <summary>
			/// True to use width:'auto', false to use fixed width (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoWidth 
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

			private Unit boxMaxHeight = Unit.Empty;

			/// <summary>
			/// The maximum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit BoxMaxHeight 
			{ 
				get
				{
					return this.boxMaxHeight;
				}
				set
				{
					this.boxMaxHeight = value;
				}
			}

			private Unit boxMaxWidth = Unit.Empty;

			/// <summary>
			/// The maximum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit BoxMaxWidth 
			{ 
				get
				{
					return this.boxMaxWidth;
				}
				set
				{
					this.boxMaxWidth = value;
				}
			}

			private Unit boxMinHeight = Unit.Empty;

			/// <summary>
			/// The minimum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit BoxMinHeight 
			{ 
				get
				{
					return this.boxMinHeight;
				}
				set
				{
					this.boxMinHeight = value;
				}
			}

			private Unit boxMinWidth = Unit.Empty;

			/// <summary>
			/// The minimum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit BoxMinWidth 
			{ 
				get
				{
					return this.boxMinWidth;
				}
				set
				{
					this.boxMinWidth = value;
				}
			}

			private Unit maxHeight = Unit.Empty;

			/// <summary>
			/// The maximum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.
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
			/// The maximum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.
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

			private Unit minHeight = Unit.Empty;

			/// <summary>
			/// The minimum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
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

			private Unit minWidth = Unit.Empty;

			/// <summary>
			/// The minimum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
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

			private Unit regionMaxHeight = Unit.Empty;

			/// <summary>
			/// The maximum value in pixels which this BoxComponent will set its height to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region. 
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit RegionMaxHeight 
			{ 
				get
				{
					return this.regionMaxHeight;
				}
				set
				{
					this.regionMaxHeight = value;
				}
			}

			private Unit regionMaxWidth = Unit.Empty;

			/// <summary>
			/// The maximum value in pixels which this BoxComponent will set its width to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit RegionMaxWidth 
			{ 
				get
				{
					return this.regionMaxWidth;
				}
				set
				{
					this.regionMaxWidth = value;
				}
			}

			private Unit regionMinHeight = Unit.Empty;

			/// <summary>
			/// The minimum value in pixels which this BoxComponent will set its height to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit RegionMinHeight 
			{ 
				get
				{
					return this.regionMinHeight;
				}
				set
				{
					this.regionMinHeight = value;
				}
			}

			private Unit regionMinWidth = Unit.Empty;

			/// <summary>
			/// The minimum value in pixels which this BoxComponent will set its width to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit RegionMinWidth 
			{ 
				get
				{
					return this.regionMinWidth;
				}
				set
				{
					this.regionMinWidth = value;
				}
			}

			private Unit height = Unit.Empty;

			/// <summary>
			/// The height of this component in pixels (defaults to auto).
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public override Unit Height 
			{ 
				get
				{
					return this.height;
				}
				set
				{
					this.height = value;
				}
			}

			private string margins = "";

			/// <summary>
			/// Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout or one of the two BoxLayout subclasses.
			/// </summary>
			[DefaultValue("")]
			public virtual string Margins 
			{ 
				get
				{
					return this.margins;
				}
				set
				{
					this.margins = value;
				}
			}

			private string cMargins = "";

			/// <summary>
			/// Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout or one of the two BoxLayout subclasses.
			/// </summary>
			[DefaultValue("")]
			public virtual string CMargins 
			{ 
				get
				{
					return this.cMargins;
				}
				set
				{
					this.cMargins = value;
				}
			}

			private Unit pageX = Unit.Empty;

			/// <summary>
			/// The page level x coordinate for this component if contained within a positioning container.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit PageX 
			{ 
				get
				{
					return this.pageX;
				}
				set
				{
					this.pageX = value;
				}
			}

			private Unit pageY = Unit.Empty;

			/// <summary>
			/// The page level y coordinate for this component if contained within a positioning container.
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public virtual Unit PageY 
			{ 
				get
				{
					return this.pageY;
				}
				set
				{
					this.pageY = value;
				}
			}

			private Region region = Region.None;

			/// <summary>
			/// Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').
			/// </summary>
			[DefaultValue(Region.None)]
			public virtual Region Region 
			{ 
				get
				{
					return this.region;
				}
				set
				{
					this.region = value;
				}
			}

			private bool split = false;

			/// <summary>
			/// True to create a SplitRegion and display a 5px wide Ext.SplitBar between this region and its neighbor, allowing the user to resize the regions dynamically. Defaults to false creating a Region. Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').
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

			private string tabTip = "";

			/// <summary>
			/// A string to be used as innerHTML (html tags are accepted) to show in a tooltip when mousing over the associated tab selector element. NOTE: TabTip config is used when a BoxComponent is a child of a TabPanel.
			/// </summary>
			[DefaultValue("")]
			public virtual string TabTip 
			{ 
				get
				{
					return this.tabTip;
				}
				set
				{
					this.tabTip = value;
				}
			}

			private Unit width = Unit.Empty;

			/// <summary>
			/// The width of this component in pixels (defaults to auto).
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public override Unit Width 
			{ 
				get
				{
					return this.width;
				}
				set
				{
					this.width = value;
				}
			}

			private int x = 0;

			/// <summary>
			/// The local x (left) coordinate for this component if contained within a positioning container.
			/// </summary>
			[DefaultValue(0)]
			public virtual int X 
			{ 
				get
				{
					return this.x;
				}
				set
				{
					this.x = value;
				}
			}

			private int y = 0;

			/// <summary>
			/// The local y (addToStart) coordinate for this component if contained within a positioning container.
			/// </summary>
			[DefaultValue(0)]
			public virtual int Y 
			{ 
				get
				{
					return this.y;
				}
				set
				{
					this.y = value;
				}
			}
        
			private MenuCollection tabMenu = null;

			/// <summary>
			/// Tab's menu
			/// </summary>
			public MenuCollection TabMenu
			{
				get
				{
					if (this.tabMenu == null)
					{
						this.tabMenu = new MenuCollection();
					}
			
					return this.tabMenu;
				}
			}
			
			private bool tabMenuHidden = false;

			/// <summary>
			/// Defaults to false. True to hide tab's menu.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool TabMenuHidden 
			{ 
				get
				{
					return this.tabMenuHidden;
				}
				set
				{
					this.tabMenuHidden = value;
				}
			}

        }
    }
}