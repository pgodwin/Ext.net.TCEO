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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Observable.Builder<Resizable, Resizable.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Resizable()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Resizable component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Resizable.Config config) : base(new Resizable(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Resizable component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The id or element to resize
			/// </summary>
            public virtual Resizable.Builder Element(string element)
            {
                this.ToComponent().Element = element;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// The array [width, height] with values to be added to the resize operation's new size (defaults to [0, 0])
			/// </summary>
            public virtual Resizable.Builder Adjustments(Size adjustments)
            {
                this.ToComponent().Adjustments = adjustments;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// True to animate the resize (not compatible with dynamic sizing, defaults to false).
			/// </summary>
            public virtual Resizable.Builder Animate(bool animate)
            {
                this.ToComponent().Animate = animate;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// True to disable mouse tracking. This is only applied at config time. (defaults to false)
			/// </summary>
            public virtual Resizable.Builder DisableTrackOver(bool disableTrackOver)
            {
                this.ToComponent().DisableTrackOver = disableTrackOver;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// Convenience to initialize drag drop (defaults to false)
			/// </summary>
            public virtual Resizable.Builder Draggable(bool draggable)
            {
                this.ToComponent().Draggable = draggable;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// Animation duration if animate = true (defaults to .35)
			/// </summary>
            public virtual Resizable.Builder Duration(double duration)
            {
                this.ToComponent().Duration = duration;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// True to resize the element while dragging instead of using a proxy (defaults to false)
			/// </summary>
            public virtual Resizable.Builder Dynamic(bool dynamic)
            {
                this.ToComponent().Dynamic = dynamic;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// Animation easing if animate = true (defaults to 'easeOutStrong')
			/// </summary>
            public virtual Resizable.Builder Easing(Easing easing)
            {
                this.ToComponent().Easing = easing;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// False to disable resizing (defaults to true)
			/// </summary>
            public virtual Resizable.Builder EnabledResizing(bool enabledResizing)
            {
                this.ToComponent().EnabledResizing = enabledResizing;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// String consisting of the resize handles to display (defaults to undefined)
			/// </summary>
            public virtual Resizable.Builder Handles(ResizeHandle handles)
            {
                this.ToComponent().Handles = handles;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// String consisting of the resize handles to display (defaults to undefined). Specify either 'all' or any of 'n s e w ne nw se sw'.
			/// </summary>
            public virtual Resizable.Builder HandlesSummary(string handlesSummary)
            {
                this.ToComponent().HandlesSummary = handlesSummary;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// The width of the element in pixels (defaults to null)
			/// </summary>
            public virtual Resizable.Builder Width(Unit width)
            {
                this.ToComponent().Width = width;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// The height of the element in pixels (defaults to null)
			/// </summary>
            public virtual Resizable.Builder Height(Unit height)
            {
                this.ToComponent().Height = height;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// The increment to snap the height resize in pixels (dynamic must be true, defaults to 0).
			/// </summary>
            public virtual Resizable.Builder HeightIncrement(int heightIncrement)
            {
                this.ToComponent().HeightIncrement = heightIncrement;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// The maximum height for the element (defaults to 10000)
			/// </summary>
            public virtual Resizable.Builder MaxHeight(int maxHeight)
            {
                this.ToComponent().MaxHeight = maxHeight;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// The maximum width for the element (defaults to 10000)
			/// </summary>
            public virtual Resizable.Builder MaxWidth(int maxWidth)
            {
                this.ToComponent().MaxWidth = maxWidth;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// The minimum height for the element (defaults to 5)
			/// </summary>
            public virtual Resizable.Builder MinHeight(int minHeight)
            {
                this.ToComponent().MinHeight = minHeight;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// The minimum width for the element (defaults to 5)
			/// </summary>
            public virtual Resizable.Builder MinWidth(int minWidth)
            {
                this.ToComponent().MinWidth = minWidth;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// The minimum allowed page X for the element (only used for west resizing, defaults to 0)
			/// </summary>
            public virtual Resizable.Builder MinX(int minX)
            {
                this.ToComponent().MinX = minX;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// The minimum allowed page Y for the element (only used for north resizing, defaults to 0)
			/// </summary>
            public virtual Resizable.Builder MinY(int minY)
            {
                this.ToComponent().MinY = minY;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// True to ensure that the resize handles are always visible, false to display them only when the user mouses over the resizable borders. This is only applied at config time. (defaults to false)
			/// </summary>
            public virtual Resizable.Builder Pinned(bool pinned)
            {
                this.ToComponent().Pinned = pinned;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// True to preserve the original ratio between height and width during resize (defaults to false)
			/// </summary>
            public virtual Resizable.Builder PreserveRatio(bool preserveRatio)
            {
                this.ToComponent().PreserveRatio = preserveRatio;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// id of element to resize
			/// </summary>
            public virtual Resizable.Builder ResizeChild(string resizeChild)
            {
                this.ToComponent().ResizeChild = resizeChild;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// True for transparent handles. This is only applied at config time. (defaults to false)
			/// </summary>
            public virtual Resizable.Builder Transparent(bool transparent)
            {
                this.ToComponent().Transparent = transparent;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// The increment to snap the width resize in pixels (dynamic must be true, defaults to 0)
			/// </summary>
            public virtual Resizable.Builder WidthIncrement(int widthIncrement)
            {
                this.ToComponent().WidthIncrement = widthIncrement;
                return this as Resizable.Builder;
            }
             
 			/// <summary>
			/// True to wrap an element with a div if needed (required for textareas and images, defaults to false)
			/// </summary>
            public virtual Resizable.Builder Wrap(bool wrap)
            {
                this.ToComponent().Wrap = wrap;
                return this as Resizable.Builder;
            }
             
 			// /// <summary>
			// /// Performs resizing of the associated Element. 
			// /// </summary>
            // public virtual TBuilder ResizeElement(JFunction resizeElement)
            // {
            //    this.ToComponent().ResizeElement = resizeElement;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(ResizableListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side DirectEventHandlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(ResizableDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Resizable.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Resizable(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Resizable.Builder Resizable()
        {
            return this.Resizable(new Resizable());
        }

        /// <summary>
        /// 
        /// </summary>
        public Resizable.Builder Resizable(Resizable component)
        {
            return new Resizable.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Resizable.Builder Resizable(Resizable.Config config)
        {
            return new Resizable.Builder(new Resizable(config));
        }
    }
}