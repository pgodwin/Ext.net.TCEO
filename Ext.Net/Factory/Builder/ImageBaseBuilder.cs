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
    public abstract partial class ImageBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TImageBase, TBuilder> : BoxComponentBase.Builder<TImageBase, TBuilder>
            where TImageBase : ImageBase
            where TBuilder : Builder<TImageBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TImageBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The height of this component in pixels (defaults to auto).
			/// </summary>
            public virtual TBuilder Height(Unit height)
            {
                this.ToComponent().Height = height;
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
			/// 
			/// </summary>
            public virtual TBuilder ImageUrl(string imageUrl)
            {
                this.ToComponent().ImageUrl = imageUrl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AlternateText(string alternateText)
            {
                this.ToComponent().AlternateText = alternateText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Align(ImageAlign align)
            {
                this.ToComponent().Align = align;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to load image after rendering only
			/// </summary>
            public virtual TBuilder LazyLoad(bool lazyLoad)
            {
                this.ToComponent().LazyLoad = lazyLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to monitor complete state and fire Complete event
			/// </summary>
            public virtual TBuilder MonitorComplete(bool monitorComplete)
            {
                this.ToComponent().MonitorComplete = monitorComplete;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to allow scroll the image by mouse dragging
			/// </summary>
            public virtual TBuilder AllowPan(bool allowPan)
            {
                this.ToComponent().AllowPan = allowPan;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to allow resize the image
			/// </summary>
            public virtual TBuilder Resizable(bool resizable)
            {
                this.ToComponent().Resizable = resizable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The milliseconds to poll complete state, ignored if MonitorComplete is not true (defaults to 200)
			/// </summary>
            public virtual TBuilder MonitorPoll(int monitorPoll)
            {
                this.ToComponent().MonitorPoll = monitorPoll;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// Resize object config
			// /// </summary>
            // public virtual TBuilder ResizeConfig(Resizable resizeConfig)
            // {
            //    this.ToComponent().ResizeConfig = resizeConfig;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// X offset
			/// </summary>
            public virtual TBuilder XDelta(int xDelta)
            {
                this.ToComponent().XDelta = xDelta;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Y offset
			/// </summary>
            public virtual TBuilder YDelta(int yDelta)
            {
                this.ToComponent().YDelta = yDelta;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder LoadMask(LoadMask loadMask)
            // {
            //    this.ToComponent().LoadMask = loadMask;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}