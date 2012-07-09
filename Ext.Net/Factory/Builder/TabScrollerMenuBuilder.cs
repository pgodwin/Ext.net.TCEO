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
    public partial class TabScrollerMenu
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Plugin.Builder<TabScrollerMenu, TabScrollerMenu.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TabScrollerMenu()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TabScrollerMenu component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TabScrollerMenu.Config config) : base(new TabScrollerMenu(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TabScrollerMenu component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The page size.
			/// </summary>
            public virtual TabScrollerMenu.Builder PageSize(int pageSize)
            {
                this.ToComponent().PageSize = pageSize;
                return this as TabScrollerMenu.Builder;
            }
             
 			/// <summary>
			/// The maximum text length to truncate.
			/// </summary>
            public virtual TabScrollerMenu.Builder MaxText(int maxText)
            {
                this.ToComponent().MaxText = maxText;
                return this as TabScrollerMenu.Builder;
            }
             
 			/// <summary>
			/// Menu prefix text.
			/// </summary>
            public virtual TabScrollerMenu.Builder MenuPrefixText(string menuPrefixText)
            {
                this.ToComponent().MenuPrefixText = menuPrefixText;
                return this as TabScrollerMenu.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public TabScrollerMenu.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TabScrollerMenu(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TabScrollerMenu.Builder TabScrollerMenu()
        {
            return this.TabScrollerMenu(new TabScrollerMenu());
        }

        /// <summary>
        /// 
        /// </summary>
        public TabScrollerMenu.Builder TabScrollerMenu(TabScrollerMenu component)
        {
            return new TabScrollerMenu.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TabScrollerMenu.Builder TabScrollerMenu(TabScrollerMenu.Config config)
        {
            return new TabScrollerMenu.Builder(new TabScrollerMenu(config));
        }
    }
}