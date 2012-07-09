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
    public abstract partial class CheckboxGroupBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TCheckboxGroupBase, TBuilder> : Field.Builder<TCheckboxGroupBase, TBuilder>
            where TCheckboxGroupBase : CheckboxGroupBase
            where TBuilder : Builder<TCheckboxGroupBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCheckboxGroupBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// False to validate that at least one item in the group is checked (defaults to true). If no items are selected at validation time, BlankText will be used as the error text.
			/// </summary>
            public virtual TBuilder AllowBlank(bool allowBlank)
            {
                this.ToComponent().AllowBlank = allowBlank;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the AllowBlank validation fails (defaults to 'You must select at least one item in this group')
			/// </summary>
            public virtual TBuilder BlankText(string blankText)
            {
                this.ToComponent().BlankText = blankText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Specifies the number of columns to use when displaying grouped checkbox/radio controls using automatic layout.
			/// </summary>
            public virtual TBuilder ColumnsNumber(int columnsNumber)
            {
                this.ToComponent().ColumnsNumber = columnsNumber;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// You can also specify an array of column widths, mixing integer (fixed width) and float (percentage width) values as needed (e.g., [100, .25, .75]). Any integer values will be rendered first, then any float values will be calculated as a percentage of the remaining space. Float values do not have to add up to 1 (100%) although if you want the controls to take up the entire field container you should do so.
			/// </summary>
            public virtual TBuilder ColumnsWidths(string[] columnsWidths)
            {
                this.ToComponent().ColumnsWidths = columnsWidths;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Fire change event after rendering
			/// </summary>
            public virtual TBuilder FireChangeOnLoad(bool fireChangeOnLoad)
            {
                this.ToComponent().FireChangeOnLoad = fireChangeOnLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to distribute contained controls across columns, completely filling each column top to bottom before starting on the next column. The number of controls in each column will be automatically calculated to keep columns as even as possible. The default value is false, so that controls will be added to columns one at a time, completely filling each row left to right before starting on the next row.
			/// </summary>
            public virtual TBuilder Vertical(bool vertical)
            {
                this.ToComponent().Vertical = vertical;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetValue(string id, bool value)
            {
                this.ToComponent().SetValue(id, value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetValue(bool[] values)
            {
                this.ToComponent().SetValue(values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetValue(Dictionary<string, bool> values)
            {
                this.ToComponent().SetValue(values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetValue(string values)
            {
                this.ToComponent().SetValue(values);
                return this as TBuilder;
            }
            
        }        
    }
}