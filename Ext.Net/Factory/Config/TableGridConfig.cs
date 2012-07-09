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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public TableGrid(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit TableGrid.Config Conversion to TableGrid
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator TableGrid(TableGrid.Config config)
        {
            return new TableGrid(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : GridPanel.Config 
        { 
			/*  Implicit TableGrid.Config Conversion to TableGrid.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator TableGrid.Builder(TableGrid.Config config)
			{
				return new TableGrid.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string table = "";

			/// <summary>
			/// The table element from which this grid will be created.
			/// </summary>
			[DefaultValue("")]
			public virtual string Table 
			{ 
				get
				{
					return this.table;
				}
				set
				{
					this.table = value;
				}
			}
        
			private ColumnModel columnModel = null;

			/// <summary>
			/// 
			/// </summary>
			public ColumnModel ColumnModel
			{
				get
				{
					if (this.columnModel == null)
					{
						this.columnModel = new ColumnModel();
					}
			
					return this.columnModel;
				}
			}
			        
			private ColumnCollection columns = null;

			/// <summary>
			/// The columns to use when rendering the grid (required).
			/// </summary>
			public ColumnCollection Columns
			{
				get
				{
					if (this.columns == null)
					{
						this.columns = new ColumnCollection();
					}
			
					return this.columns;
				}
			}
			        
			private RecordFieldCollection fields = null;

			/// <summary>
			/// Either a Collection of RecordField definition objects
			/// </summary>
			public RecordFieldCollection Fields
			{
				get
				{
					if (this.fields == null)
					{
						this.fields = new RecordFieldCollection();
					}
			
					return this.fields;
				}
			}
			
			private bool autoHeight = true;

			/// <summary>
			/// True to use height:'auto', false to use fixed height (defaults to false).
			/// </summary>
			[DefaultValue(true)]
			public override bool AutoHeight 
			{ 
				get
				{
					return this.autoHeight;
				}
				set
				{
					this.autoHeight = value;
				}
			}

        }
    }
}