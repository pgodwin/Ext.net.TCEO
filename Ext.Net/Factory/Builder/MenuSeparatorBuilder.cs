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
    public partial class MenuSeparator
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : BaseMenuItem.Builder<MenuSeparator, MenuSeparator.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new MenuSeparator()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MenuSeparator component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(MenuSeparator.Config config) : base(new MenuSeparator(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(MenuSeparator component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to hide the containing menu after this item is clicked (defaults to true).
			/// </summary>
            public virtual MenuSeparator.Builder HideOnClick(bool hideOnClick)
            {
                this.ToComponent().HideOnClick = hideOnClick;
                return this as MenuSeparator.Builder;
            }
             
 			/// <summary>
			/// Render this component disabled (default is false).
			/// </summary>
            public virtual MenuSeparator.Builder Disabled(bool disabled)
            {
                this.ToComponent().Disabled = disabled;
                return this as MenuSeparator.Builder;
            }
             
 			/// <summary>
			/// The default CSS class to use for text items (defaults to \"x-menu-text\")
			/// </summary>
            public virtual MenuSeparator.Builder ItemCls(string itemCls)
            {
                this.ToComponent().ItemCls = itemCls;
                return this as MenuSeparator.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuSeparator.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.MenuSeparator(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public MenuSeparator.Builder MenuSeparator()
        {
            return this.MenuSeparator(new MenuSeparator());
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuSeparator.Builder MenuSeparator(MenuSeparator component)
        {
            return new MenuSeparator.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public MenuSeparator.Builder MenuSeparator(MenuSeparator.Config config)
        {
            return new MenuSeparator.Builder(new MenuSeparator(config));
        }
    }
}