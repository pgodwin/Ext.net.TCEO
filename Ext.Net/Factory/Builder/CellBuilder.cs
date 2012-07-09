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
    public partial class Cell
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : LayoutItem.Builder<Cell, Cell.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Cell()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Cell component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Cell.Config config) : base(new Cell(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Cell component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual Cell.Builder RowSpan(int rowSpan)
            {
                this.ToComponent().RowSpan = rowSpan;
                return this as Cell.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual Cell.Builder ColSpan(int colSpan)
            {
                this.ToComponent().ColSpan = colSpan;
                return this as Cell.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual Cell.Builder CellCls(string cellCls)
            {
                this.ToComponent().CellCls = cellCls;
                return this as Cell.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual Cell.Builder CellId(string cellId)
            {
                this.ToComponent().CellId = cellId;
                return this as Cell.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public Cell.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Cell(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Cell.Builder Cell()
        {
            return this.Cell(new Cell());
        }

        /// <summary>
        /// 
        /// </summary>
        public Cell.Builder Cell(Cell component)
        {
            return new Cell.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Cell.Builder Cell(Cell.Config config)
        {
            return new Cell.Builder(new Cell(config));
        }
    }
}