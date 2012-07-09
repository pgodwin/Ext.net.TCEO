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
    public partial class TextArea
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TextArea(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TextArea.Config Conversion to TextArea
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TextArea(TextArea.Config config)
        {
            return new TextArea(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : TextFieldBase.Config 
        { 
			/*  Implicit TextArea.Config Conversion to TextArea.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TextArea.Builder(TextArea.Config config)
			{
				return new TextArea.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private Unit growMax = Unit.Pixel(1000);

			/// <summary>
			/// The maximum width to allow when grow = true (defaults to 800).
			/// </summary>
			[DefaultValue(typeof(Unit), "1000")]
			public override Unit GrowMax 
			{ 
				get
				{
					return this.growMax;
				}
				set
				{
					this.growMax = value;
				}
			}

			private Unit growMin = Unit.Pixel(60);

			/// <summary>
			/// The minimum width to allow when grow = true (defaults to 60).
			/// </summary>
			[DefaultValue(typeof(Unit), "60")]
			public override Unit GrowMin 
			{ 
				get
				{
					return this.growMin;
				}
				set
				{
					this.growMin = value;
				}
			}

			private bool preventScrollbars = false;

			/// <summary>
			/// True to prevent scrollbars from appearing regardless of how much text is in the field (equivalent to setting overflow: hidden, defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PreventScrollbars 
			{ 
				get
				{
					return this.preventScrollbars;
				}
				set
				{
					this.preventScrollbars = value;
				}
			}
        
			private TextFieldListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public TextFieldListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new TextFieldListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private TextFieldDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public TextFieldDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new TextFieldDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}