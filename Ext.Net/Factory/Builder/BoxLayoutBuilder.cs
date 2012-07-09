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
    public abstract partial class BoxLayout
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TBoxLayout, TBuilder> : ContainerLayout.Builder<TBoxLayout, TBuilder>
            where TBoxLayout : BoxLayout
            where TBuilder : Builder<TBoxLayout, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TBoxLayout component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The default margins from this property will be applied to each item.
			/// </summary>
            public virtual TBuilder DefaultMargins(string defaultMargins)
            {
                this.ToComponent().DefaultMargins = defaultMargins;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Defaults to '0'. Sets the padding to be applied to all child items managed by this container's layout.
			/// </summary>
            public virtual TBuilder Padding(string padding)
            {
                this.ToComponent().Padding = padding;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Controls how the child items of the container are packed together.
			/// </summary>
            public virtual TBuilder Pack(BoxPack pack)
            {
                this.ToComponent().Pack = pack;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The amount of space to reserve for the scrollbar
			/// </summary>
            public virtual TBuilder ScrollOffset(int scrollOffset)
            {
                this.ToComponent().ScrollOffset = scrollOffset;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// Box items collection
			// /// </summary>
            // public virtual TBuilder BoxItems(BoxItemCollection boxItems)
            // {
            //    this.ToComponent().BoxItems = boxItems;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}