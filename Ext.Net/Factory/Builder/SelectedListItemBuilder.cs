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
    public partial class SelectedListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : StateManagedItem.Builder<SelectedListItem, SelectedListItem.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new SelectedListItem()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SelectedListItem component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(SelectedListItem.Config config) : base(new SelectedListItem(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(SelectedListItem component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual SelectedListItem.Builder Value(string value)
            {
                this.ToComponent().Value = value;
                return this as SelectedListItem.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual SelectedListItem.Builder Index(int index)
            {
                this.ToComponent().Index = index;
                return this as SelectedListItem.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public SelectedListItem.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.SelectedListItem(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public SelectedListItem.Builder SelectedListItem()
        {
            return this.SelectedListItem(new SelectedListItem());
        }

        /// <summary>
        /// 
        /// </summary>
        public SelectedListItem.Builder SelectedListItem(SelectedListItem component)
        {
            return new SelectedListItem.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public SelectedListItem.Builder SelectedListItem(SelectedListItem.Config config)
        {
            return new SelectedListItem.Builder(new SelectedListItem(config));
        }
    }
}