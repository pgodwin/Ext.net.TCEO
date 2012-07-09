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
    public partial class Resizable
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Resizable(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Resizable.Config Conversion to Resizable
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Resizable(Resizable.Config config)
        {
            return new Resizable(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Observable.Config 
        { 
			/*  Implicit Resizable.Config Conversion to Resizable.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Resizable.Builder(Resizable.Config config)
			{
				return new Resizable.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string element = "";

			/// <summary>
			/// The id or element to resize
			/// </summary>
			[DefaultValue("")]
			public virtual string Element 
			{ 
				get
				{
					return this.element;
				}
				set
				{
					this.element = value;
				}
			}

			private Size adjustments = Size.Empty;

			/// <summary>
			/// The array [width, height] with values to be added to the resize operation's new size (defaults to [0, 0])
			/// </summary>
			[DefaultValue(typeof(Size), "")]
			public virtual Size Adjustments 
			{ 
				get
				{
					return this.adjustments;
				}
				set
				{
					this.adjustments = value;
				}
			}

			private bool animate = false;

			/// <summary>
			/// True to animate the resize (not compatible with dynamic sizing, defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Animate 
			{ 
				get
				{
					return this.animate;
				}
				set
				{
					this.animate = value;
				}
			}

			private bool disableTrackOver = false;

			/// <summary>
			/// True to disable mouse tracking. This is only applied at config time. (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisableTrackOver 
			{ 
				get
				{
					return this.disableTrackOver;
				}
				set
				{
					this.disableTrackOver = value;
				}
			}

			private bool draggable = false;

			/// <summary>
			/// Convenience to initialize drag drop (defaults to false)
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

			private double duration = 0.35;

			/// <summary>
			/// Animation duration if animate = true (defaults to .35)
			/// </summary>
			[DefaultValue(0.35)]
			public virtual double Duration 
			{ 
				get
				{
					return this.duration;
				}
				set
				{
					this.duration = value;
				}
			}

			private bool dynamic = false;

			/// <summary>
			/// True to resize the element while dragging instead of using a proxy (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Dynamic 
			{ 
				get
				{
					return this.dynamic;
				}
				set
				{
					this.dynamic = value;
				}
			}

			private Easing easing = Easing.EaseOutStrong;

			/// <summary>
			/// Animation easing if animate = true (defaults to 'easeOutStrong')
			/// </summary>
			[DefaultValue(Easing.EaseOutStrong)]
			public virtual Easing Easing 
			{ 
				get
				{
					return this.easing;
				}
				set
				{
					this.easing = value;
				}
			}

			private bool enabledResizing = true;

			/// <summary>
			/// False to disable resizing (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool EnabledResizing 
			{ 
				get
				{
					return this.enabledResizing;
				}
				set
				{
					this.enabledResizing = value;
				}
			}

			private ResizeHandle handles = ResizeHandle.None;

			/// <summary>
			/// String consisting of the resize handles to display (defaults to undefined)
			/// </summary>
			[DefaultValue(ResizeHandle.None)]
			public virtual ResizeHandle Handles 
			{ 
				get
				{
					return this.handles;
				}
				set
				{
					this.handles = value;
				}
			}

			private string handlesSummary = "";

			/// <summary>
			/// String consisting of the resize handles to display (defaults to undefined). Specify either 'all' or any of 'n s e w ne nw se sw'.
			/// </summary>
			[DefaultValue("")]
			public virtual string HandlesSummary 
			{ 
				get
				{
					return this.handlesSummary;
				}
				set
				{
					this.handlesSummary = value;
				}
			}

			private Unit width = Unit.Empty;

			/// <summary>
			/// The width of the element in pixels (defaults to null)
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

			private Unit height = Unit.Empty;

			/// <summary>
			/// The height of the element in pixels (defaults to null)
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

			private int heightIncrement = 0;

			/// <summary>
			/// The increment to snap the height resize in pixels (dynamic must be true, defaults to 0).
			/// </summary>
			[DefaultValue(0)]
			public virtual int HeightIncrement 
			{ 
				get
				{
					return this.heightIncrement;
				}
				set
				{
					this.heightIncrement = value;
				}
			}

			private int maxHeight = 10000;

			/// <summary>
			/// The maximum height for the element (defaults to 10000)
			/// </summary>
			[DefaultValue(10000)]
			public virtual int MaxHeight 
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

			private int maxWidth = 10000;

			/// <summary>
			/// The maximum width for the element (defaults to 10000)
			/// </summary>
			[DefaultValue(10000)]
			public virtual int MaxWidth 
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

			private int minHeight = 5;

			/// <summary>
			/// The minimum height for the element (defaults to 5)
			/// </summary>
			[DefaultValue(5)]
			public virtual int MinHeight 
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

			private int minWidth = 5;

			/// <summary>
			/// The minimum width for the element (defaults to 5)
			/// </summary>
			[DefaultValue(5)]
			public virtual int MinWidth 
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

			private int minX = 0;

			/// <summary>
			/// The minimum allowed page X for the element (only used for west resizing, defaults to 0)
			/// </summary>
			[DefaultValue(0)]
			public virtual int MinX 
			{ 
				get
				{
					return this.minX;
				}
				set
				{
					this.minX = value;
				}
			}

			private int minY = 0;

			/// <summary>
			/// The minimum allowed page Y for the element (only used for north resizing, defaults to 0)
			/// </summary>
			[DefaultValue(0)]
			public virtual int MinY 
			{ 
				get
				{
					return this.minY;
				}
				set
				{
					this.minY = value;
				}
			}

			private bool pinned = false;

			/// <summary>
			/// True to ensure that the resize handles are always visible, false to display them only when the user mouses over the resizable borders. This is only applied at config time. (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Pinned 
			{ 
				get
				{
					return this.pinned;
				}
				set
				{
					this.pinned = value;
				}
			}

			private bool preserveRatio = false;

			/// <summary>
			/// True to preserve the original ratio between height and width during resize (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PreserveRatio 
			{ 
				get
				{
					return this.preserveRatio;
				}
				set
				{
					this.preserveRatio = value;
				}
			}

			private string resizeChild = "";

			/// <summary>
			/// id of element to resize
			/// </summary>
			[DefaultValue("")]
			public virtual string ResizeChild 
			{ 
				get
				{
					return this.resizeChild;
				}
				set
				{
					this.resizeChild = value;
				}
			}

			private bool transparent = false;

			/// <summary>
			/// True for transparent handles. This is only applied at config time. (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Transparent 
			{ 
				get
				{
					return this.transparent;
				}
				set
				{
					this.transparent = value;
				}
			}

			private int widthIncrement = 0;

			/// <summary>
			/// The increment to snap the width resize in pixels (dynamic must be true, defaults to 0)
			/// </summary>
			[DefaultValue(0)]
			public virtual int WidthIncrement 
			{ 
				get
				{
					return this.widthIncrement;
				}
				set
				{
					this.widthIncrement = value;
				}
			}

			private bool wrap = false;

			/// <summary>
			/// True to wrap an element with a div if needed (required for textareas and images, defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Wrap 
			{ 
				get
				{
					return this.wrap;
				}
				set
				{
					this.wrap = value;
				}
			}
        
			private JFunction resizeElement = null;

			/// <summary>
			/// Performs resizing of the associated Element. 
			/// </summary>
			public JFunction ResizeElement
			{
				get
				{
					if (this.resizeElement == null)
					{
						this.resizeElement = new JFunction();
					}
			
					return this.resizeElement;
				}
			}
			        
			private ResizableListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ResizableListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ResizableListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ResizableDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public ResizableDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ResizableDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}