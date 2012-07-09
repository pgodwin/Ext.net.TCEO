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
    public partial class BorderLayout
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ContainerLayout.Builder<BorderLayout, BorderLayout.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new BorderLayout()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BorderLayout component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(BorderLayout.Config config) : base(new BorderLayout(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(BorderLayout component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// Represent options of north region
			// /// </summary>
            // public virtual TBuilder North(BorderLayoutRegion north)
            // {
            //    this.ToComponent().North = north;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Represent options of south region
			// /// </summary>
            // public virtual TBuilder South(BorderLayoutRegion south)
            // {
            //    this.ToComponent().South = south;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Represent options of west region
			// /// </summary>
            // public virtual TBuilder West(BorderLayoutRegion west)
            // {
            //    this.ToComponent().West = west;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Represent options of east region
			// /// </summary>
            // public virtual TBuilder East(BorderLayoutRegion east)
            // {
            //    this.ToComponent().East = east;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Represent options of center region
			// /// </summary>
            // public virtual TBuilder Center(BorderLayoutRegion center)
            // {
            //    this.ToComponent().Center = center;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public BorderLayout.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.BorderLayout(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public BorderLayout.Builder BorderLayout()
        {
            return this.BorderLayout(new BorderLayout());
        }

        /// <summary>
        /// 
        /// </summary>
        public BorderLayout.Builder BorderLayout(BorderLayout component)
        {
            return new BorderLayout.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public BorderLayout.Builder BorderLayout(BorderLayout.Config config)
        {
            return new BorderLayout.Builder(new BorderLayout(config));
        }
    }
}