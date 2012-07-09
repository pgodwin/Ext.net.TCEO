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
    public partial class HyperLink
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Label.Builder<HyperLink, HyperLink.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new HyperLink()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HyperLink component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HyperLink.Config config) : base(new HyperLink(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(HyperLink component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual HyperLink.Builder ImageUrl(string imageUrl)
            {
                this.ToComponent().ImageUrl = imageUrl;
                return this as HyperLink.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual HyperLink.Builder NavigateUrl(string navigateUrl)
            {
                this.ToComponent().NavigateUrl = navigateUrl;
                return this as HyperLink.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual HyperLink.Builder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as HyperLink.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public HyperLink.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.HyperLink(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public HyperLink.Builder HyperLink()
        {
            return this.HyperLink(new HyperLink());
        }

        /// <summary>
        /// 
        /// </summary>
        public HyperLink.Builder HyperLink(HyperLink component)
        {
            return new HyperLink.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public HyperLink.Builder HyperLink(HyperLink.Config config)
        {
            return new HyperLink.Builder(new HyperLink(config));
        }
    }
}