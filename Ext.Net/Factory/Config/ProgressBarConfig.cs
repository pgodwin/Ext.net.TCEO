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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ProgressBar(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ProgressBar.Config Conversion to ProgressBar
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ProgressBar(ProgressBar.Config config)
        {
            return new ProgressBar(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BoxComponentBase.Config 
        { 
			/*  Implicit ProgressBar.Config Conversion to ProgressBar.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ProgressBar.Builder(ProgressBar.Config config)
			{
				return new ProgressBar.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string baseCls = "x-progress";

			/// <summary>
			/// The base CSS class to apply to the progress bar's wrapper element (defaults to 'x-progress')
			/// </summary>
			[DefaultValue("x-progress")]
			public virtual string BaseCls 
			{ 
				get
				{
					return this.baseCls;
				}
				set
				{
					this.baseCls = value;
				}
			}

			private string text = "";

			/// <summary>
			/// The progress bar text (defaults to '')
			/// </summary>
			[DefaultValue("")]
			public virtual string Text 
			{ 
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
				}
			}

			private string textEl = "";

			/// <summary>
			/// The element to render the progress text to (defaults to the progress bar's internal text element)
			/// </summary>
			[DefaultValue("")]
			public virtual string TextEl 
			{ 
				get
				{
					return this.textEl;
				}
				set
				{
					this.textEl = value;
				}
			}

			private float value = 0;

			/// <summary>
			/// A floating point value between 0 and 1 (e.g., .5, defaults to 0)
			/// </summary>
			[DefaultValue(0)]
			public virtual float Value 
			{ 
				get
				{
					return this.value;
				}
				set
				{
					this.value = value;
				}
			}
        
			private ProgressBarListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ProgressBarListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ProgressBarListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private ProgressBarDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public ProgressBarDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new ProgressBarDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}