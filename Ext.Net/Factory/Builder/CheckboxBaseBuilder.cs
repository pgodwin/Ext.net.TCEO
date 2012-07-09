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
        new public abstract partial class Builder<TCheckboxBase, TBuilder> : Field.Builder<TCheckboxBase, TBuilder>
            where TCheckboxBase : CheckboxBase
            where TBuilder : Builder<TCheckboxBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TCheckboxBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The text that appears beside the checkbox (defaults to '').
			/// </summary>
            public virtual TBuilder BoxLabel(string boxLabel)
            {
                this.ToComponent().BoxLabel = boxLabel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder BoxLabelStyle(string boxLabelStyle)
            {
                this.ToComponent().BoxLabelStyle = boxLabelStyle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder BoxLabelCls(string boxLabelCls)
            {
                this.ToComponent().BoxLabelCls = boxLabelCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True if the checkbox should render already checked (defaults to false).
			/// </summary>
            public virtual TBuilder Checked(bool _checked)
            {
                this.ToComponent().Checked = _checked;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to use when the control is checked (defaults to 'x-form-check-checked'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.
			/// </summary>
            public virtual TBuilder CheckedCls(string checkedCls)
            {
                this.ToComponent().CheckedCls = checkedCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to use when the control receives input focus (defaults to 'x-form-check-focus'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.
			/// </summary>
            public virtual TBuilder FocusCls(string focusCls)
            {
                this.ToComponent().FocusCls = focusCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The value that should go into the generated input element's value attribute (defaults to undefined, with no value attribute)
			/// </summary>
            public virtual TBuilder InputValue(string inputValue)
            {
                this.ToComponent().InputValue = inputValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to use when the control is being actively clicked (defaults to 'x-form-check-down'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.
			/// </summary>
            public virtual TBuilder MouseDownCls(string mouseDownCls)
            {
                this.ToComponent().MouseDownCls = mouseDownCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to use when the control is hovered over (defaults to 'x-form-check-over'). Note that this class applies to both checkboxes and radio buttons and is added to the control's wrapper element.
			/// </summary>
            public virtual TBuilder OverCls(string overCls)
            {
                this.ToComponent().OverCls = overCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Tag(string tag)
            {
                this.ToComponent().Tag = tag;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }        
    }
}