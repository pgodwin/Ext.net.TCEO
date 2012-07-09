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
    public partial class TableGrid
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : GridPanel.Builder<TableGrid, TableGrid.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TableGrid()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TableGrid component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TableGrid.Config config) : base(new TableGrid(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TableGrid component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The table element from which this grid will be created.
			/// </summary>
            public virtual TableGrid.Builder Table(string table)
            {
                this.ToComponent().Table = table;
                return this as TableGrid.Builder;
            }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder ColumnModel(ColumnModel columnModel)
            // {
            //    this.ToComponent().ColumnModel = columnModel;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// The columns to use when rendering the grid (required).
			// /// </summary>
            // public virtual TBuilder Columns(ColumnCollection columns)
            // {
            //    this.ToComponent().Columns = columns;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Either a Collection of RecordField definition objects
			// /// </summary>
            // public virtual TBuilder Fields(RecordFieldCollection fields)
            // {
            //    this.ToComponent().Fields = fields;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// True to use height:'auto', false to use fixed height (defaults to false).
			/// </summary>
            public virtual TableGrid.Builder AutoHeight(bool autoHeight)
            {
                this.ToComponent().AutoHeight = autoHeight;
                return this as TableGrid.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public TableGrid.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TableGrid(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TableGrid.Builder TableGrid()
        {
            return this.TableGrid(new TableGrid());
        }

        /// <summary>
        /// 
        /// </summary>
        public TableGrid.Builder TableGrid(TableGrid component)
        {
            return new TableGrid.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TableGrid.Builder TableGrid(TableGrid.Config config)
        {
            return new TableGrid.Builder(new TableGrid(config));
        }
    }
}