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
    public partial class MouseDistanceSensor
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public MouseDistanceSensor(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit MouseDistanceSensor.Config Conversion to MouseDistanceSensor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator MouseDistanceSensor(MouseDistanceSensor.Config config)
        {
            return new MouseDistanceSensor(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Plugin.Config 
        { 
			/*  Implicit MouseDistanceSensor.Config Conversion to MouseDistanceSensor.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator MouseDistanceSensor.Builder(MouseDistanceSensor.Config config)
			{
				return new MouseDistanceSensor.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private int threshold = 100;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(100)]
			public virtual int Threshold 
			{ 
				get
				{
					return this.threshold;
				}
				set
				{
					this.threshold = value;
				}
			}

			private bool opacity = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Opacity 
			{ 
				get
				{
					return this.opacity;
				}
				set
				{
					this.opacity = value;
				}
			}

			private decimal minOpacity = 0;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(0)]
			public virtual decimal MinOpacity 
			{ 
				get
				{
					return this.minOpacity;
				}
				set
				{
					this.minOpacity = value;
				}
			}

			private decimal maxOpacity = 1;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(1)]
			public virtual decimal MaxOpacity 
			{ 
				get
				{
					return this.maxOpacity;
				}
				set
				{
					this.maxOpacity = value;
				}
			}

			private string sensorElement = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string SensorElement 
			{ 
				get
				{
					return this.sensorElement;
				}
				set
				{
					this.sensorElement = value;
				}
			}

			private string constrainElement = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string ConstrainElement 
			{ 
				get
				{
					return this.constrainElement;
				}
				set
				{
					this.constrainElement = value;
				}
			}

        }
    }
}