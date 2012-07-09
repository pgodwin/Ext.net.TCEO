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
    public abstract partial class Field
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : BoxComponentBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoPostBack = false;

			/// <summary>
			/// TextBox_AutoPostBack
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoPostBack 
			{ 
				get
				{
					return this.autoPostBack;
				}
				set
				{
					this.autoPostBack = value;
				}
			}

			private bool causesValidation = false;

			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CausesValidation 
			{ 
				get
				{
					return this.causesValidation;
				}
				set
				{
					this.causesValidation = value;
				}
			}

			private string dataIndex = "";

			/// <summary>
			/// (optional) The name of the field in the grid's Ext.data.Store's Ext.data.Record definition from which to draw the column's value.
			/// </summary>
			[DefaultValue("")]
			public virtual string DataIndex 
			{ 
				get
				{
					return this.dataIndex;
				}
				set
				{
					this.dataIndex = value;
				}
			}

			private string validationGroup = "";

			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
			[DefaultValue("")]
			public virtual string ValidationGroup 
			{ 
				get
				{
					return this.validationGroup;
				}
				set
				{
					this.validationGroup = value;
				}
			}

			private string name = "";

			/// <summary>
			/// The field's HTML name attribute (defaults to ''). Note: this property must be set if this field is to be automatically included with form submit().
			/// </summary>
			[DefaultValue("")]
			public virtual string Name 
			{ 
				get
				{
					return this.name;
				}
				set
				{
					this.name = value;
				}
			}

			private string autoCreate = "";

			/// <summary>
			/// A DomHelper element spec (defaults to {tag: 'input', type: 'text', size: '20', autocomplete: 'off'}).
			/// </summary>
			[DefaultValue("")]
			public virtual string AutoCreate 
			{ 
				get
				{
					return this.autoCreate;
				}
				set
				{
					this.autoCreate = value;
				}
			}

			private string fieldClass = "";

			/// <summary>
			/// The default CSS class for the field (defaults to 'x-form-field').
			/// </summary>
			[DefaultValue("")]
			public virtual string FieldClass 
			{ 
				get
				{
					return this.fieldClass;
				}
				set
				{
					this.fieldClass = value;
				}
			}

			private string focusClass = "";

			/// <summary>
			/// The CSS class to use when the field receives focus (defaults to 'x-form-focus').
			/// </summary>
			[DefaultValue("")]
			public virtual string FocusClass 
			{ 
				get
				{
					return this.focusClass;
				}
				set
				{
					this.focusClass = value;
				}
			}

			private bool hideWithLabel = true;

			/// <summary>
			/// True to hide the label when the field hide
			/// </summary>
			[DefaultValue(true)]
			public virtual bool HideWithLabel 
			{ 
				get
				{
					return this.hideWithLabel;
				}
				set
				{
					this.hideWithLabel = value;
				}
			}

			private string invalidClass = "";

			/// <summary>
			/// The CSS class to use when marking a field invalid (defaults to 'x-form-invalid').
			/// </summary>
			[DefaultValue("")]
			public virtual string InvalidClass 
			{ 
				get
				{
					return this.invalidClass;
				}
				set
				{
					this.invalidClass = value;
				}
			}

			private string invalidText = "";

			/// <summary>
			/// The error text to use when marking a field invalid and no message is provided (defaults to 'The value in this field is invalid').
			/// </summary>
			[DefaultValue("")]
			public virtual string InvalidText 
			{ 
				get
				{
					return this.invalidText;
				}
				set
				{
					this.invalidText = value;
				}
			}

			private string msgFx = "normal";

			/// <summary>
			/// EXPERIMENTAL The effect used when displaying a validation message under the field (defaults to 'normal').
			/// </summary>
			[DefaultValue("normal")]
			public virtual string MsgFx 
			{ 
				get
				{
					return this.msgFx;
				}
				set
				{
					this.msgFx = value;
				}
			}

			private MessageTarget msgTarget = MessageTarget.Qtip;

			/// <summary>
			/// The location where error text should display. (defaults to 'Qtip').
			/// </summary>
			[DefaultValue(MessageTarget.Qtip)]
			public virtual MessageTarget MsgTarget 
			{ 
				get
				{
					return this.msgTarget;
				}
				set
				{
					this.msgTarget = value;
				}
			}

			private bool readOnly = false;

			/// <summary>
			/// True to mark the field as readOnly in HTML (defaults to false) -- Note: this only sets the element's readOnly DOM attribute.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ReadOnly 
			{ 
				get
				{
					return this.readOnly;
				}
				set
				{
					this.readOnly = value;
				}
			}

			private bool preventMark = false;

			/// <summary>
			/// True to disable marking the field invalid
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PreventMark 
			{ 
				get
				{
					return this.preventMark;
				}
				set
				{
					this.preventMark = value;
				}
			}

			private short tabIndex = (short)0;

			/// <summary>
			/// The tabIndex for this field. Note this only applies to fields that are rendered, not those which are built via applyTo (defaults to undefined).
			/// </summary>
			[DefaultValue((short)0)]
			public override short TabIndex 
			{ 
				get
				{
					return this.tabIndex;
				}
				set
				{
					this.tabIndex = value;
				}
			}

			private bool validateOnBlur = true;

			/// <summary>
			/// Whether the field should validate when it loses focus (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ValidateOnBlur 
			{ 
				get
				{
					return this.validateOnBlur;
				}
				set
				{
					this.validateOnBlur = value;
				}
			}

			private int validateDelay = 250;

			/// <summary>
			/// The length of time in milliseconds after user input begins until validation is initiated (defaults to 250).
			/// </summary>
			[DefaultValue(250)]
			public virtual int ValidateDelay 
			{ 
				get
				{
					return this.validateDelay;
				}
				set
				{
					this.validateDelay = value;
				}
			}

			private string validationEvent = "";

			/// <summary>
			/// The event that should initiate field validation. Set to false to disable automatic validation (defaults to 'keyup').
			/// </summary>
			[DefaultValue("")]
			public virtual string ValidationEvent 
			{ 
				get
				{
					return this.validationEvent;
				}
				set
				{
					this.validationEvent = value;
				}
			}

			private bool validateOnEvent = true;

			/// <summary>
			/// Set to false to disable automatic validation
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ValidateOnEvent 
			{ 
				get
				{
					return this.validateOnEvent;
				}
				set
				{
					this.validateOnEvent = value;
				}
			}

			private string indicatorText = "";

			/// <summary>
			/// The indicator text.
			/// </summary>
			[DefaultValue("")]
			public virtual string IndicatorText 
			{ 
				get
				{
					return this.indicatorText;
				}
				set
				{
					this.indicatorText = value;
				}
			}

			private string indicatorCls = "";

			/// <summary>
			/// The indicator css class.
			/// </summary>
			[DefaultValue("")]
			public virtual string IndicatorCls 
			{ 
				get
				{
					return this.indicatorCls;
				}
				set
				{
					this.indicatorCls = value;
				}
			}

			private string indicatorIconCls = "";

			/// <summary>
			/// The indicator icon class.
			/// </summary>
			[DefaultValue("")]
			public virtual string IndicatorIconCls 
			{ 
				get
				{
					return this.indicatorIconCls;
				}
				set
				{
					this.indicatorIconCls = value;
				}
			}

			private Icon indicatorIcon = Icon.None;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon IndicatorIcon 
			{ 
				get
				{
					return this.indicatorIcon;
				}
				set
				{
					this.indicatorIcon = value;
				}
			}

			private string indicatorTip = "";

			/// <summary>
			/// The indicator tip.
			/// </summary>
			[DefaultValue("")]
			public virtual string IndicatorTip 
			{ 
				get
				{
					return this.indicatorTip;
				}
				set
				{
					this.indicatorTip = value;
				}
			}

			private string note = "";

			/// <summary>
			/// The note.
			/// </summary>
			[DefaultValue("")]
			public virtual string Note 
			{ 
				get
				{
					return this.note;
				}
				set
				{
					this.note = value;
				}
			}

			private string noteCls = "";

			/// <summary>
			/// The note css class.
			/// </summary>
			[DefaultValue("")]
			public virtual string NoteCls 
			{ 
				get
				{
					return this.noteCls;
				}
				set
				{
					this.noteCls = value;
				}
			}

			private NoteAlign noteAlign = NoteAlign.Down;

			/// <summary>
			/// Note align
			/// </summary>
			[DefaultValue(NoteAlign.Down)]
			public virtual NoteAlign NoteAlign 
			{ 
				get
				{
					return this.noteAlign;
				}
				set
				{
					this.noteAlign = value;
				}
			}

			private bool noteEncode = false;

			/// <summary>
			/// True to encode note text
			/// </summary>
			[DefaultValue(false)]
			public virtual bool NoteEncode 
			{ 
				get
				{
					return this.noteEncode;
				}
				set
				{
					this.noteEncode = value;
				}
			}

			private bool submitValue = true;

			/// <summary>
			/// False to clear the name attribute on the field so that it is not submitted during a form post. If a hiddenName is specified, setting this to true will cause both the hidden field and the element to be submitted. Defaults to undefined.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SubmitValue 
			{ 
				get
				{
					return this.submitValue;
				}
				set
				{
					this.submitValue = value;
				}
			}

			private object value = null;

			/// <summary>
			/// A value to initialize this field with.
			/// </summary>
			[DefaultValue(null)]
			public virtual object Value 
			{ 
				get
				{
					return this.value;
				}
				set
				{
					this.value = value;
				}
			}

			private object rawValue = null;

			/// <summary>
			/// The raw data value which may or may not be a valid, defined value. To return a normalized value see Value property.
			/// </summary>
			[DefaultValue(null)]
			public virtual object RawValue 
			{ 
				get
				{
					return this.rawValue;
				}
				set
				{
					this.rawValue = value;
				}
			}

			private object emptyValue = null;

			/// <summary>
			/// The fields null value.
			/// </summary>
			[DefaultValue(null)]
			public virtual object EmptyValue 
			{ 
				get
				{
					return this.emptyValue;
				}
				set
				{
					this.emptyValue = value;
				}
			}

			private bool isRemoteValidation = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IsRemoteValidation 
			{ 
				get
				{
					return this.isRemoteValidation;
				}
				set
				{
					this.isRemoteValidation = value;
				}
			}
        
			private JFunction getErrors = null;

			/// <summary>
			/// Runs this field's validators and returns an array of error messages for any validation failures.
			/// </summary>
			public JFunction GetErrors
			{
				get
				{
					if (this.getErrors == null)
					{
						this.getErrors = new JFunction();
					}
			
					return this.getErrors;
				}
			}
			
        }
    }
}