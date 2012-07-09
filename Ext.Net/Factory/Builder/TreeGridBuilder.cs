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
    public partial class TreeGrid
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : TreePanel.Builder<TreeGrid, TreeGrid.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TreeGrid()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TreeGrid component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TreeGrid.Config config) : base(new TreeGrid(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TreeGrid component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The index (or data index) of a column in this tree grid that should expand to fill unused space
			/// </summary>
            public virtual TreeGrid.Builder AutoExpandColumn(string autoExpandColumn)
            {
                this.ToComponent().AutoExpandColumn = autoExpandColumn;
                return this as TreeGrid.Builder;
            }
             
 			/// <summary>
			/// The maximum width the autoExpandColumn can have (if enabled). Defaults to 1000.
			/// </summary>
            public virtual TreeGrid.Builder AutoExpandMax(Unit autoExpandMax)
            {
                this.ToComponent().AutoExpandMax = autoExpandMax;
                return this as TreeGrid.Builder;
            }
             
 			/// <summary>
			/// The minimum width the autoExpandColumn can have (if enabled). defaults to 50.
			/// </summary>
            public virtual TreeGrid.Builder AutoExpandMin(Unit autoExpandMin)
            {
                this.ToComponent().AutoExpandMin = autoExpandMin;
                return this as TreeGrid.Builder;
            }
             
 			// /// <summary>
			// /// An array of column configuration objects
			// /// </summary>
            // public virtual TBuilder Columns(TreeGridColumnCollection columns)
            // {
            //    this.ToComponent().Columns = columns;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// True to hide the grid's header (defaults to false).
			/// </summary>
            public virtual TreeGrid.Builder HideHeaders(bool hideHeaders)
            {
                this.ToComponent().HideHeaders = hideHeaders;
                return this as TreeGrid.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public TreeGrid.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TreeGrid(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TreeGrid.Builder TreeGrid()
        {
            return this.TreeGrid(new TreeGrid());
        }

        /// <summary>
        /// 
        /// </summary>
        public TreeGrid.Builder TreeGrid(TreeGrid component)
        {
            return new TreeGrid.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TreeGrid.Builder TreeGrid(TreeGrid.Config config)
        {
            return new TreeGrid.Builder(new TreeGrid(config));
        }
    }
}