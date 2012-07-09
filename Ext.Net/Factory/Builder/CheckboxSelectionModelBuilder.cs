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
    public partial class CheckboxSelectionModel
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : RowSelectionModel.Builder<CheckboxSelectionModel, CheckboxSelectionModel.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new CheckboxSelectionModel()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CheckboxSelectionModel component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(CheckboxSelectionModel.Config config) : base(new CheckboxSelectionModel(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(CheckboxSelectionModel component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// true if rows can only be selected by clicking on the checkbox column (defaults to false).
			/// </summary>
            public virtual CheckboxSelectionModel.Builder CheckOnly(bool checkOnly)
            {
                this.ToComponent().CheckOnly = checkOnly;
                return this as CheckboxSelectionModel.Builder;
            }
             
 			/// <summary>
			/// Any valid text or HTML fragment to display in the header cell for the checkbox column (defaults to '<div class='x-grid3-hd-checker'> </div>'). The default CSS class of 'x-grid3-hd-checker' displays a checkbox in the header and provides support for automatic check all/none behavior on header click. This string can be replaced by any valid HTML fragment, including a simple text string (e.g., 'Select Rows'), but the automatic check all/none behavior will only work if the 'x-grid3-hd-checker' class is supplied.
			/// </summary>
            public virtual CheckboxSelectionModel.Builder Header(string header)
            {
                this.ToComponent().Header = header;
                return this as CheckboxSelectionModel.Builder;
            }
             
 			/// <summary>
			/// True if the checkbox column is sortable (defaults to false).
			/// </summary>
            public virtual CheckboxSelectionModel.Builder Sortable(bool sortable)
            {
                this.ToComponent().Sortable = sortable;
                return this as CheckboxSelectionModel.Builder;
            }
             
 			/// <summary>
			/// True if need hide the checkbox in the header (defaults to false).
			/// </summary>
            public virtual CheckboxSelectionModel.Builder HideCheckAll(bool hideCheckAll)
            {
                this.ToComponent().HideCheckAll = hideCheckAll;
                return this as CheckboxSelectionModel.Builder;
            }
             
 			/// <summary>
			/// False if need disable deselection
			/// </summary>
            public virtual CheckboxSelectionModel.Builder AllowDeselect(bool allowDeselect)
            {
                this.ToComponent().AllowDeselect = allowDeselect;
                return this as CheckboxSelectionModel.Builder;
            }
             
 			/// <summary>
			/// The default width in pixels of the checkbox column (defaults to 20).
			/// </summary>
            public virtual CheckboxSelectionModel.Builder Width(int width)
            {
                this.ToComponent().Width = width;
                return this as CheckboxSelectionModel.Builder;
            }
             
 			/// <summary>
			/// RowSpan attribute for the checkbox table cell
			/// </summary>
            public virtual CheckboxSelectionModel.Builder RowSpan(int rowSpan)
            {
                this.ToComponent().RowSpan = rowSpan;
                return this as CheckboxSelectionModel.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual CheckboxSelectionModel.Builder ColumnPosition(int columnPosition)
            {
                this.ToComponent().ColumnPosition = columnPosition;
                return this as CheckboxSelectionModel.Builder;
            }
             
 			/// <summary>
			/// Selection Mode
			/// </summary>
            public virtual CheckboxSelectionModel.Builder KeepSelectionOnClick(KeepSelectionMode keepSelectionOnClick)
            {
                this.ToComponent().KeepSelectionOnClick = keepSelectionOnClick;
                return this as CheckboxSelectionModel.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public CheckboxSelectionModel.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.CheckboxSelectionModel(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public CheckboxSelectionModel.Builder CheckboxSelectionModel()
        {
            return this.CheckboxSelectionModel(new CheckboxSelectionModel());
        }

        /// <summary>
        /// 
        /// </summary>
        public CheckboxSelectionModel.Builder CheckboxSelectionModel(CheckboxSelectionModel component)
        {
            return new CheckboxSelectionModel.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public CheckboxSelectionModel.Builder CheckboxSelectionModel(CheckboxSelectionModel.Config config)
        {
            return new CheckboxSelectionModel.Builder(new CheckboxSelectionModel(config));
        }
    }
}