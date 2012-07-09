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
        new public abstract partial class Builder<TField, TBuilder> : BoxComponentBase.Builder<TField, TBuilder>
            where TField : Field
            where TBuilder : Builder<TField, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TField component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// TextBox_AutoPostBack
			/// </summary>
            public virtual TBuilder AutoPostBack(bool autoPostBack)
            {
                this.ToComponent().AutoPostBack = autoPostBack;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
            public virtual TBuilder CausesValidation(bool causesValidation)
            {
                this.ToComponent().CausesValidation = causesValidation;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) The name of the field in the grid's Ext.data.Store's Ext.data.Record definition from which to draw the column's value.
			/// </summary>
            public virtual TBuilder DataIndex(string dataIndex)
            {
                this.ToComponent().DataIndex = dataIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
            public virtual TBuilder ValidationGroup(string validationGroup)
            {
                this.ToComponent().ValidationGroup = validationGroup;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The field's HTML name attribute (defaults to ''). Note: this property must be set if this field is to be automatically included with form submit().
			/// </summary>
            public virtual TBuilder Name(string name)
            {
                this.ToComponent().Name = name;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A DomHelper element spec (defaults to {tag: 'input', type: 'text', size: '20', autocomplete: 'off'}).
			/// </summary>
            public virtual TBuilder AutoCreate(string autoCreate)
            {
                this.ToComponent().AutoCreate = autoCreate;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default CSS class for the field (defaults to 'x-form-field').
			/// </summary>
            public virtual TBuilder FieldClass(string fieldClass)
            {
                this.ToComponent().FieldClass = fieldClass;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to use when the field receives focus (defaults to 'x-form-focus').
			/// </summary>
            public virtual TBuilder FocusClass(string focusClass)
            {
                this.ToComponent().FocusClass = focusClass;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to hide the label when the field hide
			/// </summary>
            public virtual TBuilder HideWithLabel(bool hideWithLabel)
            {
                this.ToComponent().HideWithLabel = hideWithLabel;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The CSS class to use when marking a field invalid (defaults to 'x-form-invalid').
			/// </summary>
            public virtual TBuilder InvalidClass(string invalidClass)
            {
                this.ToComponent().InvalidClass = invalidClass;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The error text to use when marking a field invalid and no message is provided (defaults to 'The value in this field is invalid').
			/// </summary>
            public virtual TBuilder InvalidText(string invalidText)
            {
                this.ToComponent().InvalidText = invalidText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// EXPERIMENTAL The effect used when displaying a validation message under the field (defaults to 'normal').
			/// </summary>
            public virtual TBuilder MsgFx(string msgFx)
            {
                this.ToComponent().MsgFx = msgFx;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The location where error text should display. (defaults to 'Qtip').
			/// </summary>
            public virtual TBuilder MsgTarget(MessageTarget msgTarget)
            {
                this.ToComponent().MsgTarget = msgTarget;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to mark the field as readOnly in HTML (defaults to false) -- Note: this only sets the element's readOnly DOM attribute.
			/// </summary>
            public virtual TBuilder ReadOnly(bool readOnly)
            {
                this.ToComponent().ReadOnly = readOnly;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to disable marking the field invalid
			/// </summary>
            public virtual TBuilder PreventMark(bool preventMark)
            {
                this.ToComponent().PreventMark = preventMark;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The tabIndex for this field. Note this only applies to fields that are rendered, not those which are built via applyTo (defaults to undefined).
			/// </summary>
            public virtual TBuilder TabIndex(short tabIndex)
            {
                this.ToComponent().TabIndex = tabIndex;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Whether the field should validate when it loses focus (defaults to true).
			/// </summary>
            public virtual TBuilder ValidateOnBlur(bool validateOnBlur)
            {
                this.ToComponent().ValidateOnBlur = validateOnBlur;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The length of time in milliseconds after user input begins until validation is initiated (defaults to 250).
			/// </summary>
            public virtual TBuilder ValidateDelay(int validateDelay)
            {
                this.ToComponent().ValidateDelay = validateDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The event that should initiate field validation. Set to false to disable automatic validation (defaults to 'keyup').
			/// </summary>
            public virtual TBuilder ValidationEvent(string validationEvent)
            {
                this.ToComponent().ValidationEvent = validationEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Set to false to disable automatic validation
			/// </summary>
            public virtual TBuilder ValidateOnEvent(bool validateOnEvent)
            {
                this.ToComponent().ValidateOnEvent = validateOnEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The indicator text.
			/// </summary>
            public virtual TBuilder IndicatorText(string indicatorText)
            {
                this.ToComponent().IndicatorText = indicatorText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The indicator css class.
			/// </summary>
            public virtual TBuilder IndicatorCls(string indicatorCls)
            {
                this.ToComponent().IndicatorCls = indicatorCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The indicator icon class.
			/// </summary>
            public virtual TBuilder IndicatorIconCls(string indicatorIconCls)
            {
                this.ToComponent().IndicatorIconCls = indicatorIconCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder IndicatorIcon(Icon indicatorIcon)
            {
                this.ToComponent().IndicatorIcon = indicatorIcon;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The indicator tip.
			/// </summary>
            public virtual TBuilder IndicatorTip(string indicatorTip)
            {
                this.ToComponent().IndicatorTip = indicatorTip;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The note.
			/// </summary>
            public virtual TBuilder Note(string note)
            {
                this.ToComponent().Note = note;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The note css class.
			/// </summary>
            public virtual TBuilder NoteCls(string noteCls)
            {
                this.ToComponent().NoteCls = noteCls;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Note align
			/// </summary>
            public virtual TBuilder NoteAlign(NoteAlign noteAlign)
            {
                this.ToComponent().NoteAlign = noteAlign;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to encode note text
			/// </summary>
            public virtual TBuilder NoteEncode(bool noteEncode)
            {
                this.ToComponent().NoteEncode = noteEncode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to clear the name attribute on the field so that it is not submitted during a form post. If a hiddenName is specified, setting this to true will cause both the hidden field and the element to be submitted. Defaults to undefined.
			/// </summary>
            public virtual TBuilder SubmitValue(bool submitValue)
            {
                this.ToComponent().SubmitValue = submitValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A value to initialize this field with.
			/// </summary>
            public virtual TBuilder Value(object value)
            {
                this.ToComponent().Value = value;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The raw data value which may or may not be a valid, defined value. To return a normalized value see Value property.
			/// </summary>
            public virtual TBuilder RawValue(object rawValue)
            {
                this.ToComponent().RawValue = rawValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The fields null value.
			/// </summary>
            public virtual TBuilder EmptyValue(object emptyValue)
            {
                this.ToComponent().EmptyValue = emptyValue;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder IsRemoteValidation(bool isRemoteValidation)
            {
                this.ToComponent().IsRemoteValidation = isRemoteValidation;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// Runs this field's validators and returns an array of error messages for any validation failures.
			// /// </summary>
            // public virtual TBuilder GetErrors(JFunction getErrors)
            // {
            //    this.ToComponent().GetErrors = getErrors;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Clears the Field value.
			/// </summary>
            public virtual TBuilder Clear()
            {
                this.ToComponent().Clear();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Clear any invalid styles/messages for this field
			/// </summary>
            public virtual TBuilder ClearInvalid()
            {
                this.ToComponent().ClearInvalid();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Mark this field as invalid, using msgTarget to determine how to display the error and applying invalidClass to the field's element.
			/// </summary>
            public virtual TBuilder MarkInvalid()
            {
                this.ToComponent().MarkInvalid();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Mark this field as invalid, using msgTarget to determine how to display the error and applying invalidClass to the field's element.
			/// </summary>
            public virtual TBuilder MarkInvalid(string msg)
            {
                this.ToComponent().MarkInvalid(msg);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Resets the current field value to the originally loaded value and clears any validation messages
			/// </summary>
            public virtual TBuilder Reset()
            {
                this.ToComponent().Reset();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the underlying DOM field's value directly, bypassing validation. To set the value with validation see setValue.
			/// </summary>
            public virtual TBuilder SetRawValue(object value)
            {
                this.ToComponent().SetRawValue(value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder SetNote(string note, bool encode)
            {
                this.ToComponent().SetNote(note, encode);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShowNote()
            {
                this.ToComponent().ShowNote();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder HideNote()
            {
                this.ToComponent().HideNote();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ShowIndicator()
            {
                this.ToComponent().ShowIndicator();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder HideIndicator()
            {
                this.ToComponent().HideIndicator();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ClearIndicator()
            {
                this.ToComponent().ClearIndicator();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AlignIndicator()
            {
                this.ToComponent().AlignIndicator();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MarkAsValid()
            {
                this.ToComponent().MarkAsValid();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder MarkAsValid(bool abortRequest)
            {
                this.ToComponent().MarkAsValid(abortRequest);
                return this as TBuilder;
            }
            
        }        
    }
}