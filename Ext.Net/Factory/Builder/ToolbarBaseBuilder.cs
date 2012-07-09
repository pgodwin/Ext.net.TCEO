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
    public abstract partial class ToolbarBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TToolbarBase, TBuilder> : ContainerBase.Builder<TToolbarBase, TBuilder>
            where TToolbarBase : ToolbarBase
            where TBuilder : Builder<TToolbarBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TToolbarBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').
			/// </summary>
            public virtual TBuilder DefaultType(string defaultType)
            {
                this.ToComponent().DefaultType = defaultType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to use flat style.
			/// </summary>
            public virtual TBuilder Flat(bool flat)
            {
                this.ToComponent().Flat = flat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to use classic (none-flat) style.
			/// </summary>
            public virtual TBuilder ClassicButtonStyle(bool classicButtonStyle)
            {
                this.ToComponent().ClassicButtonStyle = classicButtonStyle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Defaults to false. Configure <tt>true</tt> to make the toolbar provide a button which activates a dropdown Menu to show items which overflow the Toolbar's width.
			/// </summary>
            public virtual TBuilder EnableOverflow(bool enableOverflow)
            {
                this.ToComponent().EnableOverflow = enableOverflow;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}