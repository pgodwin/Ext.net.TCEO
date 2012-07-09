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
    public partial class FieldSet
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public FieldSet(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit FieldSet.Config Conversion to FieldSet
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator FieldSet(FieldSet.Config config)
        {
            return new FieldSet(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Panel.Config 
        { 
			/*  Implicit FieldSet.Config Conversion to FieldSet.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator FieldSet.Builder(FieldSet.Config config)
			{
				return new FieldSet.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool animCollapse = false;

			/// <summary>
			/// True to render a checkbox into the fieldset frame just in front of the legend (defaults to false). The fieldset will be expanded or collapsed when the checkbox is toggled.
			/// </summary>
			[DefaultValue(false)]
			public override bool AnimCollapse 
			{ 
				get
				{
					return this.animCollapse;
				}
				set
				{
					this.animCollapse = value;
				}
			}

			private string checkboxName = "";

			/// <summary>
			/// True to render a checkbox into the fieldset frame just in front of the legend (defaults to false). The fieldset will be expanded or collapsed when the checkbox is toggled.
			/// </summary>
			[DefaultValue("")]
			public virtual string CheckboxName 
			{ 
				get
				{
					return this.checkboxName;
				}
				set
				{
					this.checkboxName = value;
				}
			}

			private bool checkboxToggle = false;

			/// <summary>
			/// True to render a checkbox into the fieldset frame just in front of the legend (defaults to false). The fieldset will be expanded or collapsed when the checkbox is toggled.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CheckboxToggle 
			{ 
				get
				{
					return this.checkboxToggle;
				}
				set
				{
					this.checkboxToggle = value;
				}
			}

			private string itemCls = "";

			/// <summary>
			/// A css class to apply to the x-form-items of fields. This property cascades to child containers.
			/// </summary>
			[DefaultValue("")]
			public override string ItemCls 
			{ 
				get
				{
					return this.itemCls;
				}
				set
				{
					this.itemCls = value;
				}
			}

			private int labelWidth = 75;

			/// <summary>
			/// The width of labels. This property cascades to child containers.
			/// </summary>
			[DefaultValue(75)]
			public override int LabelWidth 
			{ 
				get
				{
					return this.labelWidth;
				}
				set
				{
					this.labelWidth = value;
				}
			}

        }
    }
}