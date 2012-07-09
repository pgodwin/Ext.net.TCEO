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
    public partial class AnchorLayout
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ContainerLayout.Builder<AnchorLayout, AnchorLayout.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new AnchorLayout()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(AnchorLayout component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(AnchorLayout.Config config) : base(new AnchorLayout(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(AnchorLayout component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The height of this Anchor in pixels (defaults to auto).
			/// </summary>
            public virtual AnchorLayout.Builder Height(Unit height)
            {
                this.ToComponent().Height = height;
                return this as AnchorLayout.Builder;
            }
             
 			/// <summary>
			/// The width of this Anchor in pixels (defaults to auto).
			/// </summary>
            public virtual AnchorLayout.Builder Width(Unit width)
            {
                this.ToComponent().Width = width;
                return this as AnchorLayout.Builder;
            }
             
 			// /// <summary>
			// /// Anchors collection
			// /// </summary>
            // public virtual TBuilder Anchors(AnchorCollection anchors)
            // {
            //    this.ToComponent().Anchors = anchors;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public AnchorLayout.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.AnchorLayout(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public AnchorLayout.Builder AnchorLayout()
        {
            return this.AnchorLayout(new AnchorLayout());
        }

        /// <summary>
        /// 
        /// </summary>
        public AnchorLayout.Builder AnchorLayout(AnchorLayout component)
        {
            return new AnchorLayout.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public AnchorLayout.Builder AnchorLayout(AnchorLayout.Config config)
        {
            return new AnchorLayout.Builder(new AnchorLayout(config));
        }
    }
}