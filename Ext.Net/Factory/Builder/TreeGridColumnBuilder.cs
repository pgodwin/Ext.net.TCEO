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
    public partial class TreeGridColumn
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : StateManagedItem.Builder<TreeGridColumn, TreeGridColumn.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TreeGridColumn()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TreeGridColumn component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TreeGridColumn.Config config) : base(new TreeGridColumn(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TreeGridColumn component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Set the CSS text-align property of the column. Defaults to 'left'.
			/// </summary>
            public virtual TreeGridColumn.Builder Align(TextAlign align)
            {
                this.ToComponent().Align = align;
                return this as TreeGridColumn.Builder;
            }
             
 			/// <summary>
			/// Optional. This option can be used to add a CSS class to the cell of each row for this column.
			/// </summary>
            public virtual TreeGridColumn.Builder Cls(string cls)
            {
                this.ToComponent().Cls = cls;
                return this as TreeGridColumn.Builder;
            }
             
 			/// <summary>
			/// (optional) The name of the field in the grid's Ext.data.Store's Ext.data.Record definition from which to draw the column's value. If not specified, the column's index is used as an index into the Record's data Array.
			/// </summary>
            public virtual TreeGridColumn.Builder DataIndex(string dataIndex)
            {
                this.ToComponent().DataIndex = dataIndex;
                return this as TreeGridColumn.Builder;
            }
             
 			/// <summary>
			/// The header text to display in the Grid view.
			/// </summary>
            public virtual TreeGridColumn.Builder Header(string header)
            {
                this.ToComponent().Header = header;
                return this as TreeGridColumn.Builder;
            }
             
 			/// <summary>
			/// Specify a string to pass as the configuration string for Ext.XTemplate. By default an Ext.XTemplate will be implicitly created using the dataIndex.
			/// </summary>
            public virtual TreeGridColumn.Builder Template(string template)
            {
                this.ToComponent().Template = template;
                return this as TreeGridColumn.Builder;
            }
             
 			// /// <summary>
			// /// An XTemplate to use to process a Record's data to produce a column's rendered value.
			// /// </summary>
            // public virtual TBuilder XTemplate(XTemplate xTemplate)
            // {
            //    this.ToComponent().XTemplate = xTemplate;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// Percentage of the container width this column should be allocated. Columns that have no width specified will be allocated with an equal percentage to fill 100% of the container width. To easily take advantage of the full container width, leave the width of at least one column undefined. Note that if you do not want to take up the full width of the container, the width of every column needs to be explicitly defined.
			/// </summary>
            public virtual TreeGridColumn.Builder Width(double width)
            {
                this.ToComponent().Width = width;
                return this as TreeGridColumn.Builder;
            }
             
 			/// <summary>
			/// Sort method
			/// </summary>
            public virtual TreeGridColumn.Builder SortType(SortTypeMethod sortType)
            {
                this.ToComponent().SortType = sortType;
                return this as TreeGridColumn.Builder;
            }
             
 			/// <summary>
			/// (optional) True to hide the column. Defaults to false.
			/// </summary>
            public virtual TreeGridColumn.Builder Hidden(bool hidden)
            {
                this.ToComponent().Hidden = hidden;
                return this as TreeGridColumn.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public TreeGridColumn.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TreeGridColumn(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TreeGridColumn.Builder TreeGridColumn()
        {
            return this.TreeGridColumn(new TreeGridColumn());
        }

        /// <summary>
        /// 
        /// </summary>
        public TreeGridColumn.Builder TreeGridColumn(TreeGridColumn component)
        {
            return new TreeGridColumn.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TreeGridColumn.Builder TreeGridColumn(TreeGridColumn.Config config)
        {
            return new TreeGridColumn.Builder(new TreeGridColumn(config));
        }
    }
}