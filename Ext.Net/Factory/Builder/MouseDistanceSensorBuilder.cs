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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Plugin.Builder<MouseDistanceSensor, MouseDistanceSensor.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new MouseDistanceSensor()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MouseDistanceSensor component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MouseDistanceSensor.Config config) : base(new MouseDistanceSensor(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(MouseDistanceSensor component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual MouseDistanceSensor.Builder Threshold(int threshold)
            {
                this.ToComponent().Threshold = threshold;
                return this as MouseDistanceSensor.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MouseDistanceSensor.Builder Opacity(bool opacity)
            {
                this.ToComponent().Opacity = opacity;
                return this as MouseDistanceSensor.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MouseDistanceSensor.Builder MinOpacity(decimal minOpacity)
            {
                this.ToComponent().MinOpacity = minOpacity;
                return this as MouseDistanceSensor.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MouseDistanceSensor.Builder MaxOpacity(decimal maxOpacity)
            {
                this.ToComponent().MaxOpacity = maxOpacity;
                return this as MouseDistanceSensor.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MouseDistanceSensor.Builder SensorElement(string sensorElement)
            {
                this.ToComponent().SensorElement = sensorElement;
                return this as MouseDistanceSensor.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual MouseDistanceSensor.Builder ConstrainElement(string constrainElement)
            {
                this.ToComponent().ConstrainElement = constrainElement;
                return this as MouseDistanceSensor.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public MouseDistanceSensor.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.MouseDistanceSensor(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public MouseDistanceSensor.Builder MouseDistanceSensor()
        {
            return this.MouseDistanceSensor(new MouseDistanceSensor());
        }

        /// <summary>
        /// 
        /// </summary>
        public MouseDistanceSensor.Builder MouseDistanceSensor(MouseDistanceSensor component)
        {
            return new MouseDistanceSensor.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public MouseDistanceSensor.Builder MouseDistanceSensor(MouseDistanceSensor.Config config)
        {
            return new MouseDistanceSensor.Builder(new MouseDistanceSensor(config));
        }
    }
}