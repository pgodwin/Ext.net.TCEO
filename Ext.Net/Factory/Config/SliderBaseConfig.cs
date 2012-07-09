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
    public abstract partial class SliderBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : BoxComponentBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int value = int.MinValue;

			/// <summary>
			/// The Number (int) to initialize this field with.
			/// </summary>
			[DefaultValue(int.MinValue)]
			public virtual int Value 
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

			private bool animate = true;

			/// <summary>
			/// Turn on or off animation. Defaults to true
			/// </summary>
			[DefaultValue(true)]
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

			private bool clickToChange = true;

			/// <summary>
			/// Determines whether or not clicking on the Slider axis will change the slider. Defaults to true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ClickToChange 
			{ 
				get
				{
					return this.clickToChange;
				}
				set
				{
					this.clickToChange = value;
				}
			}

			private bool constrainThumbs = true;

			/// <summary>
			/// True to disallow thumbs from overlapping one another. Defaults to true
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ConstrainThumbs 
			{ 
				get
				{
					return this.constrainThumbs;
				}
				set
				{
					this.constrainThumbs = value;
				}
			}

			private int decimalPrecision = 0;

			/// <summary>
			/// The number of decimal places to which to round the Slider's value. Defaults to 0.
			/// </summary>
			[DefaultValue(0)]
			public virtual int DecimalPrecision 
			{ 
				get
				{
					return this.decimalPrecision;
				}
				set
				{
					this.decimalPrecision = value;
				}
			}

			private int increment = 0;

			/// <summary>
			/// How many units to change the slider when adjusting by drag and drop. Use this option to enable 'snapping'.
			/// </summary>
			[DefaultValue(0)]
			public virtual int Increment 
			{ 
				get
				{
					return this.increment;
				}
				set
				{
					this.increment = value;
				}
			}

			private int keyIncrement = 1;

			/// <summary>
			/// How many units to change the Slider when adjusting with keyboard navigation. Defaults to 1. If the increment config is larger, it will be used instead.
			/// </summary>
			[DefaultValue(1)]
			public virtual int KeyIncrement 
			{ 
				get
				{
					return this.keyIncrement;
				}
				set
				{
					this.keyIncrement = value;
				}
			}

			private int maxValue = 100;

			/// <summary>
			/// The maximum value for the Slider. Defaults to 100.
			/// </summary>
			[DefaultValue(100)]
			public virtual int MaxValue 
			{ 
				get
				{
					return this.maxValue;
				}
				set
				{
					this.maxValue = value;
				}
			}

			private int minValue = 0;

			/// <summary>
			/// The minimum value for the Slider. Defaults to 0.
			/// </summary>
			[DefaultValue(0)]
			public virtual int MinValue 
			{ 
				get
				{
					return this.minValue;
				}
				set
				{
					this.minValue = value;
				}
			}

			private bool vertical = false;

			/// <summary>
			/// Orient the Slider vertically rather than horizontally, defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Vertical 
			{ 
				get
				{
					return this.vertical;
				}
				set
				{
					this.vertical = value;
				}
			}

			private int topThumbZIndex = 10000;

			/// <summary>
			/// The number used to set the z index of the top thumb
			/// </summary>
			[DefaultValue(10000)]
			public virtual int TopThumbZIndex 
			{ 
				get
				{
					return this.topThumbZIndex;
				}
				set
				{
					this.topThumbZIndex = value;
				}
			}

        }
    }
}