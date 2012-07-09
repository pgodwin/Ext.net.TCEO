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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public CheckboxSelectionModel(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit CheckboxSelectionModel.Config Conversion to CheckboxSelectionModel
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator CheckboxSelectionModel(CheckboxSelectionModel.Config config)
        {
            return new CheckboxSelectionModel(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : RowSelectionModel.Config 
        { 
			/*  Implicit CheckboxSelectionModel.Config Conversion to CheckboxSelectionModel.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator CheckboxSelectionModel.Builder(CheckboxSelectionModel.Config config)
			{
				return new CheckboxSelectionModel.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool checkOnly = false;

			/// <summary>
			/// true if rows can only be selected by clicking on the checkbox column (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CheckOnly 
			{ 
				get
				{
					return this.checkOnly;
				}
				set
				{
					this.checkOnly = value;
				}
			}

			private string header = "<div class=\"x-grid3-hd-checker\"> </div>";

			/// <summary>
			/// Any valid text or HTML fragment to display in the header cell for the checkbox column (defaults to '<div class='x-grid3-hd-checker'> </div>'). The default CSS class of 'x-grid3-hd-checker' displays a checkbox in the header and provides support for automatic check all/none behavior on header click. This string can be replaced by any valid HTML fragment, including a simple text string (e.g., 'Select Rows'), but the automatic check all/none behavior will only work if the 'x-grid3-hd-checker' class is supplied.
			/// </summary>
			[DefaultValue("<div class=\"x-grid3-hd-checker\"> </div>")]
			public virtual string Header 
			{ 
				get
				{
					return this.header;
				}
				set
				{
					this.header = value;
				}
			}

			private bool sortable = false;

			/// <summary>
			/// True if the checkbox column is sortable (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Sortable 
			{ 
				get
				{
					return this.sortable;
				}
				set
				{
					this.sortable = value;
				}
			}

			private bool hideCheckAll = false;

			/// <summary>
			/// True if need hide the checkbox in the header (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HideCheckAll 
			{ 
				get
				{
					return this.hideCheckAll;
				}
				set
				{
					this.hideCheckAll = value;
				}
			}

			private bool allowDeselect = true;

			/// <summary>
			/// False if need disable deselection
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowDeselect 
			{ 
				get
				{
					return this.allowDeselect;
				}
				set
				{
					this.allowDeselect = value;
				}
			}

			private int width = 20;

			/// <summary>
			/// The default width in pixels of the checkbox column (defaults to 20).
			/// </summary>
			[DefaultValue(20)]
			public virtual int Width 
			{ 
				get
				{
					return this.width;
				}
				set
				{
					this.width = value;
				}
			}

			private int rowSpan = 1;

			/// <summary>
			/// RowSpan attribute for the checkbox table cell
			/// </summary>
			[DefaultValue(1)]
			public virtual int RowSpan 
			{ 
				get
				{
					return this.rowSpan;
				}
				set
				{
					this.rowSpan = value;
				}
			}

			private int columnPosition = 0;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(0)]
			public virtual int ColumnPosition 
			{ 
				get
				{
					return this.columnPosition;
				}
				set
				{
					this.columnPosition = value;
				}
			}

			private KeepSelectionMode keepSelectionOnClick = KeepSelectionMode.Always;

			/// <summary>
			/// Selection Mode
			/// </summary>
			[DefaultValue(KeepSelectionMode.Always)]
			public virtual KeepSelectionMode KeepSelectionOnClick 
			{ 
				get
				{
					return this.keepSelectionOnClick;
				}
				set
				{
					this.keepSelectionOnClick = value;
				}
			}

        }
    }
}