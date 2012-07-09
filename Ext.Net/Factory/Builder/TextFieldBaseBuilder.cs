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
    public abstract partial class TextFieldBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTextFieldBase, TBuilder> : Field.Builder<TTextFieldBase, TBuilder>
            where TTextFieldBase : TextFieldBase
            where TBuilder : Builder<TTextFieldBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTextFieldBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The Text value to initialize this field with.
			/// </summary>
            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Text value to initialize this field with.
			/// </summary>
            public virtual TBuilder RawText(string rawText)
            {
                this.ToComponent().RawText = rawText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to validate that the value length > 0 (defaults to true).
			/// </summary>
            public virtual TBuilder AllowBlank(bool allowBlank)
            {
                this.ToComponent().AllowBlank = allowBlank;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the allow blank validation fails (defaults to 'This field is required').
			/// </summary>
            public virtual TBuilder BlankText(string blankText)
            {
                this.ToComponent().BlankText = blankText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to disable input keystroke filtering (defaults to false).
			/// </summary>
            public virtual TBuilder DisableKeyFilter(bool disableKeyFilter)
            {
                this.ToComponent().DisableKeyFilter = disableKeyFilter;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to apply to an empty field to style the emptyText (defaults to 'x-form-empty-field'). This class is automatically added and removed as needed depending on the current field value.
			/// </summary>
            public virtual TBuilder EmptyClass(string emptyClass)
            {
                this.ToComponent().EmptyClass = emptyClass;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default text to display in an empty field (defaults to null).
			/// </summary>
            public virtual TBuilder EmptyText(string emptyText)
            {
                this.ToComponent().EmptyText = emptyText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to enable the proxying of key events for the HTML input field (defaults to false)
			/// </summary>
            public virtual TBuilder EnableKeyEvents(bool enableKeyEvents)
            {
                this.ToComponent().EnableKeyEvents = enableKeyEvents;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True if this field should automatically grow and shrink to its content (defaults to false).
			/// </summary>
            public virtual TBuilder Grow(bool grow)
            {
                this.ToComponent().Grow = grow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The maximum width to allow when grow = true (defaults to 800).
			/// </summary>
            public virtual TBuilder GrowMax(Unit growMax)
            {
                this.ToComponent().GrowMax = growMax;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum width to allow when grow = true (defaults to 30).
			/// </summary>
            public virtual TBuilder GrowMin(Unit growMin)
            {
                this.ToComponent().GrowMin = growMin;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The type attribute for input fields.
			/// </summary>
            public virtual TBuilder InputType(InputType inputType)
            {
                this.ToComponent().InputType = inputType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An input mask regular expression that will be used to filter keystrokes that don't match (defaults to null).
			/// </summary>
            public virtual TBuilder MaskRe(string maskRe)
            {
                this.ToComponent().MaskRe = maskRe;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Maximum input field length allowed (defaults to Number.MAX_VALUE).
			/// </summary>
            public virtual TBuilder MaxLength(int maxLength)
            {
                this.ToComponent().MaxLength = maxLength;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').
			/// </summary>
            public virtual TBuilder MaxLengthText(string maxLengthText)
            {
                this.ToComponent().MaxLengthText = maxLengthText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Minimum input field length required (defaults to 0).
			/// </summary>
            public virtual TBuilder MinLength(int minLength)
            {
                this.ToComponent().MinLength = minLength;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').
			/// </summary>
            public virtual TBuilder MinLengthText(string minLengthText)
            {
                this.ToComponent().MinLengthText = minLengthText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A JavaScript RegExp object to be tested against the field value during validation (defaults to null). If available, this regex will be evaluated only after the basic validators all return true, and will be passed the current field value. If the test fails, the field will be marked invalid using RegexText.
			/// </summary>
            public virtual TBuilder Regex(string regex)
            {
                this.ToComponent().Regex = regex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error text to display if regex is used and the test fails during validation (defaults to '').
			/// </summary>
            public virtual TBuilder RegexText(string regexText)
            {
                this.ToComponent().RegexText = regexText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically select any existing field text when the field receives input focus (defaults to false).
			/// </summary>
            public virtual TBuilder SelectOnFocus(bool selectOnFocus)
            {
                this.ToComponent().SelectOnFocus = selectOnFocus;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If MaxLength property has been set, more characters than the MaxLength can be entered if Truncate='false'. If 'false', then a validation error is rendered if more characters entered (or pasted) than the MaxLength property. Default value is 'true'.
			/// </summary>
            public virtual TBuilder Truncate(bool truncate)
            {
                this.ToComponent().Truncate = truncate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A custom validation function to be called during field validation (defaults to null). If available, this function will be called only after the basic validators all return true, and will be passed the current field value and expected to return boolean true if the value is valid or a string error message if invalid.
			/// </summary>
            public virtual TBuilder Validator(string validator)
            {
                this.ToComponent().Validator = validator;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A validation type name as defined in Ext.form.VTypes (defaults to null).
			/// </summary>
            public virtual TBuilder Vtype(string vtype)
            {
                this.ToComponent().Vtype = vtype;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A custom error message to display in place of the default message provided for the vtype currently set for this field (defaults to ''). Only applies if vtype is set, else ignored.
			/// </summary>
            public virtual TBuilder VtypeText(string vtypeText)
            {
                this.ToComponent().VtypeText = vtypeText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The icon to use in the input field. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual TBuilder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A css class which sets a background image to be used as the icon for this field.
			/// </summary>
            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Automatically grows the field to accomodate the width of the text up to the maximum field width allowed. This only takes effect if grow = true, and fires the autosize event.
			/// </summary>
            public virtual TBuilder AutoSize()
            {
                this.ToComponent().AutoSize();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Selects text in this field
			/// </summary>
            public virtual TBuilder SelectText()
            {
                this.ToComponent().SelectText();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Selects text in this field
			/// </summary>
            public virtual TBuilder SelectText(int start)
            {
                this.ToComponent().SelectText(start);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Selects text in this field
			/// </summary>
            public virtual TBuilder SelectText(int start, int end)
            {
                this.ToComponent().SelectText(start, end);
                return this as TBuilder;
            }
            
        }        
    }
}