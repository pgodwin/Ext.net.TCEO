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
    public partial class ProgressBar
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BoxComponentBase.Builder<ProgressBar, ProgressBar.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ProgressBar()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ProgressBar component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ProgressBar.Config config) : base(new ProgressBar(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ProgressBar component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The base CSS class to apply to the progress bar's wrapper element (defaults to 'x-progress')
			/// </summary>
            public virtual ProgressBar.Builder BaseCls(string baseCls)
            {
                this.ToComponent().BaseCls = baseCls;
                return this as ProgressBar.Builder;
            }
             
 			/// <summary>
			/// The progress bar text (defaults to '')
			/// </summary>
            public virtual ProgressBar.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as ProgressBar.Builder;
            }
             
 			/// <summary>
			/// The element to render the progress text to (defaults to the progress bar's internal text element)
			/// </summary>
            public virtual ProgressBar.Builder TextEl(string textEl)
            {
                this.ToComponent().TextEl = textEl;
                return this as ProgressBar.Builder;
            }
             
 			/// <summary>
			/// A floating point value between 0 and 1 (e.g., .5, defaults to 0)
			/// </summary>
            public virtual ProgressBar.Builder Value(float value)
            {
                this.ToComponent().Value = value;
                return this as ProgressBar.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(ProgressBarListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(ProgressBarDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Resets the progress bar value to 0 and text to empty string. If hide = true, the progress bar will also be hidden (using the hideMode property internally).
			/// </summary>
            public virtual ProgressBar.Builder Reset()
            {
                this.ToComponent().Reset();
                return this;
            }
            
 			/// <summary>
			/// Resets the progress bar value to 0 and text to empty string. If hide = true, the progress bar will also be hidden (using the hideMode property internally).
			/// </summary>
            public virtual ProgressBar.Builder Reset(bool hide)
            {
                this.ToComponent().Reset(hide);
                return this;
            }
            
 			/// <summary>
			/// Synchronizes the inner bar width to the proper proportion of the total componet width based on the current progress value. This will be called automatically when the ProgressBar is resized by a layout, but if it is rendered auto width, this method can be called from another resize handler to sync the ProgressBar if necessary.
			/// </summary>
            public virtual ProgressBar.Builder SyncProgressBar()
            {
                this.ToComponent().SyncProgressBar();
                return this;
            }
            
 			/// <summary>
			/// Updates the progress bar value, and optionally its text. If the text argument is not specified, any existing text value will be unchanged. To blank out existing text, pass ''. Note that even if the progress bar value exceeds 1, it will never automatically reset -- you are responsible for determining when the progress is complete and calling reset to clear and/or hide the control.
			/// </summary>
            public virtual ProgressBar.Builder UpdateProgress(float value, string text)
            {
                this.ToComponent().UpdateProgress(value, text);
                return this;
            }
            
 			/// <summary>
			/// Updates the progress bar text. If specified, textEl will be updated, otherwise the progress bar itself will display the updated text.
			/// </summary>
            public virtual ProgressBar.Builder UpdateText()
            {
                this.ToComponent().UpdateText();
                return this;
            }
            
 			/// <summary>
			/// Updates the progress bar text. If specified, textEl will be updated, otherwise the progress bar itself will display the updated text.
			/// </summary>
            public virtual ProgressBar.Builder UpdateText(string text)
            {
                this.ToComponent().UpdateText(text);
                return this;
            }
            
 			/// <summary>
			/// Initiates an auto-updating progress bar. A duration can be specified, in which case the progress bar will automatically reset after a fixed amount of time and optionally call a callback function if specified. If no duration is passed in, then the progress bar will run indefinitely and must be manually cleared by calling reset.
			/// </summary>
            public virtual ProgressBar.Builder Wait()
            {
                this.ToComponent().Wait();
                return this;
            }
            
 			/// <summary>
			/// Updates the progress bar text. If specified, textEl will be updated, otherwise the progress bar itself will display the updated text.
			/// </summary>
            public virtual ProgressBar.Builder Wait(WaitConfig config)
            {
                this.ToComponent().Wait(config);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public ProgressBar.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ProgressBar(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ProgressBar.Builder ProgressBar()
        {
            return this.ProgressBar(new ProgressBar());
        }

        /// <summary>
        /// 
        /// </summary>
        public ProgressBar.Builder ProgressBar(ProgressBar component)
        {
            return new ProgressBar.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ProgressBar.Builder ProgressBar(ProgressBar.Config config)
        {
            return new ProgressBar.Builder(new ProgressBar(config));
        }
    }
}