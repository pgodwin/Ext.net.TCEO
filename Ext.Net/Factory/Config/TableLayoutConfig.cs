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
    public partial class TableLayout
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TableLayout(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TableLayout.Config Conversion to TableLayout
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TableLayout(TableLayout.Config config)
        {
            return new TableLayout(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : ContainerLayout.Config 
        { 
			/*  Implicit TableLayout.Config Conversion to TableLayout.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TableLayout.Builder(TableLayout.Config config)
			{
				return new TableLayout.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private DomObject tableAttrs = null;

			/// <summary>
			/// An object containing properties which are added to the DomHelper specification used to create the layout's <table> element.
			/// </summary>
			public DomObject TableAttrs
			{
				get
				{
					if (this.tableAttrs == null)
					{
						this.tableAttrs = new DomObject();
					}
			
					return this.tableAttrs;
				}
			}
			
			private int columns = 0;

			/// <summary>
			/// The total number of columns to create in the table for this layout. If not specified, all panels added to this layout will be rendered into a single row using a column per panel.
			/// </summary>
			[DefaultValue(0)]
			public virtual int Columns 
			{ 
				get
				{
					return this.columns;
				}
				set
				{
					this.columns = value;
				}
			}
        
			private CellCollection cells = null;

			/// <summary>
			/// Cells collection
			/// </summary>
			public CellCollection Cells
			{
				get
				{
					if (this.cells == null)
					{
						this.cells = new CellCollection();
					}
			
					return this.cells;
				}
			}
			
        }
    }
}