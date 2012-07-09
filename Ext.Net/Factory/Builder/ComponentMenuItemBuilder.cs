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
    public partial class ComponentMenuItem
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : MenuItemBase.Builder<ComponentMenuItem, ComponentMenuItem.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ComponentMenuItem()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ComponentMenuItem component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ComponentMenuItem.Config config) : base(new ComponentMenuItem(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ComponentMenuItem component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Component(ItemsCollection<Component> component)
            // {
            //    this.ToComponent().Component = component;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The element of component which will be used during menu item rendering
			/// </summary>
            public virtual ComponentMenuItem.Builder ComponentElement(TargetElement componentElement)
            {
                this.ToComponent().ComponentElement = componentElement;
                return this as ComponentMenuItem.Builder;
            }
             
 			/// <summary>
			/// If true then element will be shiffted on horizontal, the icon place will be visible
			/// </summary>
            public virtual ComponentMenuItem.Builder Shift(bool shift)
            {
                this.ToComponent().Shift = shift;
                return this as ComponentMenuItem.Builder;
            }
             
 			/// <summary>
			/// The target element which will be placed to toolbar.
			/// </summary>
            public virtual ComponentMenuItem.Builder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as ComponentMenuItem.Builder;
            }
             
 			/// <summary>
			/// True to hide the containing menu after this item is clicked (defaults to false).
			/// </summary>
            public virtual ComponentMenuItem.Builder HideOnClick(bool hideOnClick)
            {
                this.ToComponent().HideOnClick = hideOnClick;
                return this as ComponentMenuItem.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentMenuItem.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ComponentMenuItem(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ComponentMenuItem.Builder ComponentMenuItem()
        {
            return this.ComponentMenuItem(new ComponentMenuItem());
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentMenuItem.Builder ComponentMenuItem(ComponentMenuItem component)
        {
            return new ComponentMenuItem.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ComponentMenuItem.Builder ComponentMenuItem(ComponentMenuItem.Config config)
        {
            return new ComponentMenuItem.Builder(new ComponentMenuItem(config));
        }
    }
}