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
        new public abstract partial class Config : Field.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string text = "";

			/// <summary>
			/// The Text value to initialize this field with.
			/// </summary>
			[DefaultValue("")]
			public virtual string Text 
			{ 
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
				}
			}

			private string rawText = "";

			/// <summary>
			/// The Text value to initialize this field with.
			/// </summary>
			[DefaultValue("")]
			public virtual string RawText 
			{ 
				get
				{
					return this.rawText;
				}
				set
				{
					this.rawText = value;
				}
			}

			private bool allowBlank = true;

			/// <summary>
			/// False to validate that the value length > 0 (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowBlank 
			{ 
				get
				{
					return this.allowBlank;
				}
				set
				{
					this.allowBlank = value;
				}
			}

			private string blankText = "";

			/// <summary>
			/// Error text to display if the allow blank validation fails (defaults to 'This field is required').
			/// </summary>
			[DefaultValue("")]
			public virtual string BlankText 
			{ 
				get
				{
					return this.blankText;
				}
				set
				{
					this.blankText = value;
				}
			}

			private bool disableKeyFilter = false;

			/// <summary>
			/// True to disable input keystroke filtering (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool DisableKeyFilter 
			{ 
				get
				{
					return this.disableKeyFilter;
				}
				set
				{
					this.disableKeyFilter = value;
				}
			}

			private string emptyClass = "";

			/// <summary>
			/// The CSS class to apply to an empty field to style the emptyText (defaults to 'x-form-empty-field'). This class is automatically added and removed as needed depending on the current field value.
			/// </summary>
			[DefaultValue("")]
			public virtual string EmptyClass 
			{ 
				get
				{
					return this.emptyClass;
				}
				set
				{
					this.emptyClass = value;
				}
			}

			private string emptyText = "";

			/// <summary>
			/// The default text to display in an empty field (defaults to null).
			/// </summary>
			[DefaultValue("")]
			public virtual string EmptyText 
			{ 
				get
				{
					return this.emptyText;
				}
				set
				{
					this.emptyText = value;
				}
			}

			private bool enableKeyEvents = false;

			/// <summary>
			/// True to enable the proxying of key events for the HTML input field (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnableKeyEvents 
			{ 
				get
				{
					return this.enableKeyEvents;
				}
				set
				{
					this.enableKeyEvents = value;
				}
			}

			private bool grow = false;

			/// <summary>
			/// True if this field should automatically grow and shrink to its content (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Grow 
			{ 
				get
				{
					return this.grow;
				}
				set
				{
					this.grow = value;
				}
			}

			private Unit growMax = Unit.Pixel(800);

			/// <summary>
			/// The maximum width to allow when grow = true (defaults to 800).
			/// </summary>
			[DefaultValue(typeof(Unit), "800")]
			public virtual Unit GrowMax 
			{ 
				get
				{
					return this.growMax;
				}
				set
				{
					this.growMax = value;
				}
			}

			private Unit growMin = Unit.Pixel(30);

			/// <summary>
			/// The minimum width to allow when grow = true (defaults to 30).
			/// </summary>
			[DefaultValue(typeof(Unit), "30")]
			public virtual Unit GrowMin 
			{ 
				get
				{
					return this.growMin;
				}
				set
				{
					this.growMin = value;
				}
			}

			private InputType inputType = InputType.Text;

			/// <summary>
			/// The type attribute for input fields.
			/// </summary>
			[DefaultValue(InputType.Text)]
			public virtual InputType InputType 
			{ 
				get
				{
					return this.inputType;
				}
				set
				{
					this.inputType = value;
				}
			}

			private string maskRe = "";

			/// <summary>
			/// An input mask regular expression that will be used to filter keystrokes that don't match (defaults to null).
			/// </summary>
			[DefaultValue("")]
			public virtual string MaskRe 
			{ 
				get
				{
					return this.maskRe;
				}
				set
				{
					this.maskRe = value;
				}
			}

			private int maxLength = -1;

			/// <summary>
			/// Maximum input field length allowed (defaults to Number.MAX_VALUE).
			/// </summary>
			[DefaultValue(-1)]
			public virtual int MaxLength 
			{ 
				get
				{
					return this.maxLength;
				}
				set
				{
					this.maxLength = value;
				}
			}

			private string maxLengthText = "";

			/// <summary>
			/// Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').
			/// </summary>
			[DefaultValue("")]
			public virtual string MaxLengthText 
			{ 
				get
				{
					return this.maxLengthText;
				}
				set
				{
					this.maxLengthText = value;
				}
			}

			private int minLength = 0;

			/// <summary>
			/// Minimum input field length required (defaults to 0).
			/// </summary>
			[DefaultValue(0)]
			public virtual int MinLength 
			{ 
				get
				{
					return this.minLength;
				}
				set
				{
					this.minLength = value;
				}
			}

			private string minLengthText = "";

			/// <summary>
			/// Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').
			/// </summary>
			[DefaultValue("")]
			public virtual string MinLengthText 
			{ 
				get
				{
					return this.minLengthText;
				}
				set
				{
					this.minLengthText = value;
				}
			}

			private string regex = "";

			/// <summary>
			/// A JavaScript RegExp object to be tested against the field value during validation (defaults to null). If available, this regex will be evaluated only after the basic validators all return true, and will be passed the current field value. If the test fails, the field will be marked invalid using RegexText.
			/// </summary>
			[DefaultValue("")]
			public virtual string Regex 
			{ 
				get
				{
					return this.regex;
				}
				set
				{
					this.regex = value;
				}
			}

			private string regexText = "";

			/// <summary>
			/// The error text to display if regex is used and the test fails during validation (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string RegexText 
			{ 
				get
				{
					return this.regexText;
				}
				set
				{
					this.regexText = value;
				}
			}

			private bool selectOnFocus = false;

			/// <summary>
			/// True to automatically select any existing field text when the field receives input focus (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SelectOnFocus 
			{ 
				get
				{
					return this.selectOnFocus;
				}
				set
				{
					this.selectOnFocus = value;
				}
			}

			private bool truncate = true;

			/// <summary>
			/// If MaxLength property has been set, more characters than the MaxLength can be entered if Truncate='false'. If 'false', then a validation error is rendered if more characters entered (or pasted) than the MaxLength property. Default value is 'true'.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Truncate 
			{ 
				get
				{
					return this.truncate;
				}
				set
				{
					this.truncate = value;
				}
			}

			private string validator = "";

			/// <summary>
			/// A custom validation function to be called during field validation (defaults to null). If available, this function will be called only after the basic validators all return true, and will be passed the current field value and expected to return boolean true if the value is valid or a string error message if invalid.
			/// </summary>
			[DefaultValue("")]
			public virtual string Validator 
			{ 
				get
				{
					return this.validator;
				}
				set
				{
					this.validator = value;
				}
			}

			private string vtype = "";

			/// <summary>
			/// A validation type name as defined in Ext.form.VTypes (defaults to null).
			/// </summary>
			[DefaultValue("")]
			public virtual string Vtype 
			{ 
				get
				{
					return this.vtype;
				}
				set
				{
					this.vtype = value;
				}
			}

			private string vtypeText = "";

			/// <summary>
			/// A custom error message to display in place of the default message provided for the vtype currently set for this field (defaults to ''). Only applies if vtype is set, else ignored.
			/// </summary>
			[DefaultValue("")]
			public virtual string VtypeText 
			{ 
				get
				{
					return this.vtypeText;
				}
				set
				{
					this.vtypeText = value;
				}
			}

			private Icon icon = Icon.None;

			/// <summary>
			/// The icon to use in the input field. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon Icon 
			{ 
				get
				{
					return this.icon;
				}
				set
				{
					this.icon = value;
				}
			}

			private string iconCls = "";

			/// <summary>
			/// A css class which sets a background image to be used as the icon for this field.
			/// </summary>
			[DefaultValue("")]
			public virtual string IconCls 
			{ 
				get
				{
					return this.iconCls;
				}
				set
				{
					this.iconCls = value;
				}
			}

        }
    }
}