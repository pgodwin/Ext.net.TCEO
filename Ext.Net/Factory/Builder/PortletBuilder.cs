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
    public partial class Portlet
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Panel.Builder<Portlet, Portlet.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Portlet()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Portlet component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Portlet.Config config) : base(new Portlet(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Portlet component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to make the panel collapsible and have the expand/collapse toggle button automatically rendered into the header tool button area, false to keep the panel statically sized with no button (defaults to false).
			/// </summary>
            public virtual Portlet.Builder Collapsible(bool collapsible)
            {
                this.ToComponent().Collapsible = collapsible;
                return this as Portlet.Builder;
            }
             
 			/// <summary>
			/// True to enable dragging of this Panel (defaults to false).
			/// </summary>
            public virtual Portlet.Builder Draggable(bool draggable)
            {
                this.ToComponent().Draggable = draggable;
                return this as Portlet.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Portlet.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Portlet(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Portlet.Builder Portlet()
        {
            return this.Portlet(new Portlet());
        }

        /// <summary>
        /// 
        /// </summary>
        public Portlet.Builder Portlet(Portlet component)
        {
            return new Portlet.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Portlet.Builder Portlet(Portlet.Config config)
        {
            return new Portlet.Builder(new Portlet(config));
        }
    }
}