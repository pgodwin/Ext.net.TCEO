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
    public abstract partial class CheckboxBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : Field.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string boxLabel = "";

			/// <summary>
			/// The text that appears beside the checkbox (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string BoxLabel 
			{ 
				get
				{
					return this.boxLabel;
				}
				set
				{
					this.boxLabel = value;
				}
			}

			private string boxLabelStyle = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string BoxLabelStyle 
			{ 
				get
				{
					return this.boxLabelStyle;
				}
				set
				{
					this.boxLabelStyle = value;
				}
			}

			private string boxLabelCls = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string BoxLabelCls 
			{ 
				get
				{
					return this.boxLabelCls;
				}
				set
				{
					this.boxLabelCls = value;
				}
			}

			private bool _checked = false;

			/// <summary>
			/// True if the checkbox should render already checked (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Checked 
			{ 
				get
				{
					return this._checked;
				}
				set
				{
					this._checked = value;
				}
			}

			private string checkedCls = "x-form-check-checked";

			/// <summary>
			/// The CSS class to use when the control is checked (defaults to 'x-form-check-checked'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.
			/// </summary>
			[DefaultValue("x-form-check-checked")]
			public virtual string CheckedCls 
			{ 
				get
				{
					return this.checkedCls;
				}
				set
				{
					this.checkedCls = value;
				}
			}

			private string focusCls = "x-form-check-focus";

			/// <summary>
			/// The CSS class to use when the control receives input focus (defaults to 'x-form-check-focus'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.
			/// </summary>
			[DefaultValue("x-form-check-focus")]
			public virtual string FocusCls 
			{ 
				get
				{
					return this.focusCls;
				}
				set
				{
					this.focusCls = value;
				}
			}

			private string inputValue = "";

			/// <summary>
			/// The value that should go into the generated input element's value attribute (defaults to undefined, with no value attribute)
			/// </summary>
			[DefaultValue("")]
			public virtual string InputValue 
			{ 
				get
				{
					return this.inputValue;
				}
				set
				{
					this.inputValue = value;
				}
			}

			private string mouseDownCls = "x-form-check-down";

			/// <summary>
			/// The CSS class to use when the control is being actively clicked (defaults to 'x-form-check-down'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.
			/// </summary>
			[DefaultValue("x-form-check-down")]
			public virtual string MouseDownCls 
			{ 
				get
				{
					return this.mouseDownCls;
				}
				set
				{
					this.mouseDownCls = value;
				}
			}

			private string overCls = "x-form-check-over";

			/// <summary>
			/// The CSS class to use when the control is hovered over (defaults to 'x-form-check-over'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.
			/// </summary>
			[DefaultValue("x-form-check-over")]
			public override string OverCls 
			{ 
				get
				{
					return this.overCls;
				}
				set
				{
					this.overCls = value;
				}
			}

			private string tag = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Tag 
			{ 
				get
				{
					return this.tag;
				}
				set
				{
					this.tag = value;
				}
			}

        }
    }
}