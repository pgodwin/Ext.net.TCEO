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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;
using System.Xml;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Base Class for Form Fields that provides default event handling, sizing, value handling and other functionality.
    /// </summary>
    [Meta]
    [Description("Base Class for Form Fields that provides default event handling, sizing, value handling and other functionality.")]
    public abstract partial class Field : BoxComponentBase, IAutoPostBack, IXPostBackDataHandler, IPostBackEventHandler, IToolbarItem, IField, IIcon, IAjaxPostBackEventHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "field";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override string ContainerStyle
        {
            get
            {
                return "display:inline;";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual string UniqueName
        {
            get
            {
                if (this.IsProxy)
                {
                    return this.ID;
                }

                return this.Name.IsEmpty() ? this.ConfigID : this.Name;
            }
        }

        /// <summary>
        /// TextBox_AutoPostBack
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [DefaultValue(false)]
        [Description("TextBox_AutoPostBack")]
        public virtual bool AutoPostBack
        {
            get
            {
                object obj = this.ViewState["AutoPostBack"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoPostBack"] = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.")]
        public virtual bool CausesValidation
        {
            get
            {
                object obj = this.ViewState["CausesValidation"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["CausesValidation"] = value;
            }
        }

        /// <summary>
        /// (optional) The name of the field in the grid's Ext.data.Store's Ext.data.Record definition from which to draw the column's value.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("(optional) The name of the field in the grid's Ext.data.Store's Ext.data.Record definition from which to draw the column's value.")]
        public virtual string DataIndex
        {
            get
            {
                object obj = this.ViewState["DataIndex"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["DataIndex"] = value;
            }
        }

        /// <summary>
        /// Gets or Sets the Controls ValidationGroup
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("Gets or Sets the Controls ValidationGroup")]
        public virtual string ValidationGroup
        {
            get
            {
                return (string)this.ViewState["ValidationGroup"] ?? "";
            }
            set
            {
                this.ViewState["ValidationGroup"] = value;
            }
        }

        /// <summary>
        /// The field's HTML name attribute (defaults to ''). Note: this property must be set if this field is to be automatically included with form submit().
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("The field's HTML name attribute (defaults to ''). Note: this property must be set if this field is to be automatically included with form submit().")]
        public virtual string Name
        {
            get
            {
                return (string)this.ViewState["Name"] ?? "";
            }
            set
            {
                this.ViewState["Name"] = value;
            }
        }


        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// A DomHelper element spec (defaults to {tag: 'input', type: 'text', size: '20', autocomplete: 'off'}).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("A DomHelper element spec (defaults to {tag: 'input', type: 'text', size: '20', autocomplete: 'off'}).")]
        public virtual string AutoCreate
        {
            get
            {
                return (string)this.ViewState["AutoCreate"] ?? "";
            }
            set
            {
                this.ViewState["AutoCreate"] = value;
            }
        }

        /// <summary>
        /// The default CSS class for the field (defaults to 'x-form-field').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("The default CSS class for the field (defaults to 'x-form-field').")]
        public virtual string FieldClass
        {
            get
            {
                return (string)this.ViewState["FieldClass"] ?? "";
            }
            set
            {
                this.ViewState["FieldClass"] = value;
            }
        }

        /// <summary>
        /// The CSS class to use when the field receives focus (defaults to 'x-form-focus').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("The CSS class to use when the field receives focus (defaults to 'x-form-focus').")]
        public virtual string FocusClass
        {
            get
            {
                return (string)this.ViewState["FocusClass"] ?? "";
            }
            set
            {
                this.ViewState["FocusClass"] = value;
            }
        }

        /// <summary>
        /// True to hide the label when the field hide
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(true)]
        [Description("True to hide the label when the field hide")]
        public virtual bool HideWithLabel
        {
            get
            {
                object obj = this.ViewState["HideWithLabel"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["HideWithLabel"] = value;
            }
        }

        /// <summary>
        /// The CSS class to use when marking a field invalid (defaults to 'x-form-invalid').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("The CSS class to use when marking a field invalid (defaults to 'x-form-invalid').")]
        public virtual string InvalidClass
        {
            get
            {
                return (string)this.ViewState["InvalidClass"] ?? "";
            }
            set
            {
                this.ViewState["InvalidClass"] = value;
            }
        }

        /// <summary>
        /// The error text to use when marking a field invalid and no message is provided (defaults to 'The value in this field is invalid').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to use when marking a field invalid and no message is provided (defaults to 'The value in this field is invalid').")]
        public virtual string InvalidText
        {
            get
            {
                return (string)this.ViewState["InvalidText"] ?? "";
            }
            set
            {
                this.ViewState["InvalidText"] = value;
            }
        }

        /// <summary>
        /// EXPERIMENTAL The effect used when displaying a validation message under the field (defaults to 'normal').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("normal")]
        [Description("EXPERIMENTAL The effect used when displaying a validation message under the field (defaults to 'normal').")]
        public virtual string MsgFx
        {
            get
            {
                return (string)this.ViewState["MsgFx"] ?? "normal";
            }
            set
            {
                this.ViewState["MsgFx"] = value;
            }
        }

        /// <summary>
        /// The location where error text should display. (defaults to 'Qtip').
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Field")]
        [TypeConverter(typeof(MessageTarget))]
        [DefaultValue(MessageTarget.Qtip)]
        [Description("The location where error text should display. (defaults to 'Qtip').")]
        public virtual MessageTarget MsgTarget
        {
            get
            {
                object obj = this.ViewState["MsgTarget"];
                return (obj == null) ? MessageTarget.Qtip : (MessageTarget)obj;
            }
            set
            {
                this.ViewState["MsgTarget"] = value;
            }
        }

        /// <summary>
        /// True to mark the field as readOnly in HTML (defaults to false) -- Note: this only sets the element's readOnly DOM attribute.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetReadOnly")]
        [ConfigOption]
        [Category("5. Field")]
        [Bindable(true)]
        [DefaultValue(false)]
        [Description("True to mark the field as readOnly in HTML (defaults to false) -- Note: this only sets the element's readOnly DOM attribute.")]
        public virtual bool ReadOnly 
        {
            get
            {
                object obj = this.ViewState["ReadOnly"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ReadOnly"] = value;
            }
        }

        /// <summary>
        /// True to disable marking the field invalid
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(false)]
        [Description("True to disable marking the field invalid")]
        public virtual bool PreventMark
        {
            get
            {
                object obj = this.ViewState["PreventMark"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["PreventMark"] = value;
            }
        }

        /// NOTE: [2009-11-30] [geoff] Might be a conflict with @TabIndex property and short type. Can not change/override member type. 
        /// <summary>
        /// The tabIndex for this field. Note this only applies to fields that are rendered, not those which are built via applyTo (defaults to undefined).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue((short)0)]
        [Description("The tabIndex for this field. Note this only applies to fields that are rendered, not those which are built via applyTo (defaults to undefined).")]
        public override short TabIndex
        {
            get
            {
                object obj = this.ViewState["TabIndex"];
                return (obj == null) ? (short)0 : (short)obj;
            }
            set
            {
                this.ViewState["TabIndex"] = value;
            }
        }

        /// <summary>
        /// Whether the field should validate when it loses focus (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(true)]
        [Description("Whether the field should validate when it loses focus (defaults to true).")]
        public virtual bool ValidateOnBlur
        {
            get
            {
                object obj = this.ViewState["ValidateOnBlur"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ValidateOnBlur"] = value;
            }
        }

        /// <summary>
        /// The length of time in milliseconds after user input begins until validation is initiated (defaults to 250).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(250)]
        [Description("The length of time in milliseconds after user input begins until validation is initiated (defaults to 250).")]
        public virtual int ValidateDelay
        {
            get
            {
                object obj = this.ViewState["ValidateDelay"];
                return (obj == null) ? 250 : (int)obj;
            }
            set
            {
                this.ViewState["ValidateDelay"] = value;
            }
        }


        /// <summary>
        /// The event that should initiate field validation. Set to false to disable automatic validation (defaults to 'keyup').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("The event that should initiate field validation. Set to false to disable automatic validation (defaults to 'keyup').")]
        public virtual string ValidationEvent
        {
            get
            {
                return (string)this.ViewState["ValidationEvent"] ?? "";
            }
            set
            {
                this.ViewState["ValidationEvent"] = value;
            }
        }

        /// <summary>
        /// Set to false to disable automatic validation
        /// </summary>
        [Meta]
        [ConfigOption("validationEvent")]
        [Category("5. Field")]
        [DefaultValue(true)]
        [Description("Set to false to disable automatic validation")]
        public virtual bool ValidateOnEvent
        {
            get
            {
                object obj = this.ViewState["ValidateOnEvent"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ValidateOnEvent"] = value;
            }
        }

        /// <summary>
        /// The indicator text.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetIndicatorText")]
        [Description("The indicator text.")]
        public virtual string IndicatorText
        {
            get
            {
                return (string)this.ViewState["IndicatorText"] ?? "";
            }
            set
            {
                this.ViewState["IndicatorText"] = value;
            }
        }

        /// <summary>
        /// The indicator css class.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetIndicatorCls")]
        [Description("The indicator css class.")]
        public virtual string IndicatorCls
        {
            get
            {
                return (string)this.ViewState["IndicatorCls"] ?? "";
            }
            set
            {
                this.ViewState["IndicatorCls"] = value;
            }
        }

        /// <summary>
        /// The indicator icon class.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetIndicatorIconCls")]
        [Description("The indicator icon class.")]
        public virtual string IndicatorIconCls
        {
            get
            {
                return (string)this.ViewState["IndicatorIconCls"] ?? "";
            }
            set
            {
                this.ViewState["IndicatorIconCls"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [DefaultValue(Icon.None)]
        [DirectEventUpdate(MethodName = "SetIndicatorIconCls")]
        [Description("")]
        public virtual Icon IndicatorIcon
        {
            get
            {
                object obj = this.ViewState["IndicatorIcon"];
                return (obj == null) ? Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["IndicatorIcon"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("indicatorIconCls")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string IndicatorIconClsProxy
        {
            get
            {
                if (this.IndicatorIcon != Icon.None)
                {
                    return ResourceManager.GetIconClassName(this.IndicatorIcon);
                }

                return this.IndicatorIconCls;
            }
        }

        /// <summary>
        /// The indicator tip.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetIndicatorTip")]
        [Description("The indicator tip.")]
        public virtual string IndicatorTip
        {
            get
            {
                return (string)this.ViewState["IndicatorTip"] ?? "";
            }
            set
            {
                this.ViewState["IndicatorTip"] = value;
            }
        }


        /// <summary>
        /// The note.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetNote")]
        [Description("The note.")]
        public virtual string Note
        {
            get
            {
                return (string)this.ViewState["Note"] ?? "";
            }
            set
            {
                this.ViewState["Note"] = value;
            }
        }

        /// <summary>
        /// The note css class.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetNoteCls")]
        [Description("The note css class.")]
        public virtual string NoteCls
        {
            get
            {
                return (string)this.ViewState["NoteCls"] ?? "";
            }
            set
            {
                this.ViewState["NoteCls"] = value;
            }
        }

        /// <summary>
        /// Note align
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Field")]
        [DefaultValue(NoteAlign.Down)]
        [Description("Note align")]
        public virtual NoteAlign NoteAlign
        {
            get
            {
                object obj = this.ViewState["NoteAlign"];
                return (obj == null) ? NoteAlign.Down : (NoteAlign)obj;
            }
            set
            {
                this.ViewState["NoteAlign"] = value;
            }
        }

        /// <summary>
        /// True to encode note text
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(false)]
        [Description("True to encode note text")]
        public virtual bool NoteEncode
        {
            get
            {
                object obj = this.ViewState["NoteEncode"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["NoteEncode"] = value;
            }
        }

        /// <summary>
        /// False to clear the name attribute on the field so that it is not submitted during a form post. If a hiddenName is specified, setting this to true will cause both the hidden field and the element to be submitted. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(true)]
        [Description("False to clear the name attribute on the field so that it is not submitted during a form post. If a hiddenName is specified, setting this to true will cause both the hidden field and the element to be submitted. Defaults to undefined.")]
        public virtual bool SubmitValue
        {
            get
            {
                object obj = this.ViewState["SubmitValue"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["SubmitValue"] = value;
            }
        }


        /*  IField
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// A value to initialize this field with.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetValueProxy")]
        [Category("5. Field")]
        [DefaultValue(null)]
        [Description("A value to initialize this field with.")]
        public virtual object Value
        {
            get
            {
                object obj = this.ViewState["Value"];
                return (obj == null) ? null : obj;
            }
            set
            {
                this.ViewState["Value"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("value")]
        [DefaultValue(null)]
        protected internal virtual object ValueProxy
        {
            get
            {
                if (!this.IsEmpty)
                {
                    return this.Value;
                }

                return null;
            }
        }

        /// <summary>
        /// The raw data value which may or may not be a valid, defined value. To return a normalized value see Value property.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetRawValueProxy")]
        [Category("5. Field")]
        [DefaultValue(null)]
        [Description("The raw data value which may or may not be a valid, defined value. To return a normalized value see Value property.")]
        public virtual object RawValue
        {
            get
            {
                return this.ViewState["RawValue"];
            }
            set
            {
                this.ViewState["RawValue"] = value;
            }
        }

        /// <summary>
        /// The fields null value.
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [DefaultValue(null)]
        [Description("The fields null value.")]
        public virtual object EmptyValue
        {
            get
            {
                return this.ViewState["EmptyValue"];
            }
            set
            {
                this.ViewState["EmptyValue"] = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Value is equal to EmptyValue.
        /// </summary>
        [Description("Gets a value indicating whether the Value is equal to EmptyValue.")]
        public virtual bool IsEmpty
        {
            get
            {
                return this.Value == null ? true : this.Value.Equals(this.EmptyValue);
            }
        }

        /// <summary>
        /// Clears the Field value.
        /// </summary>
        [Meta]
        [Description("Clears the Field value.")]
        public virtual void Clear()
        {
            try
            {
                this.SuspendScripting();
                this.Value = this.EmptyValue;
            }
            finally
            {
                this.ResumeScripting();
                this.Call("clear");
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Clear any invalid styles/messages for this field
        /// </summary>
        [Meta]
        [Description("Clear any invalid styles/messages for this field")]
        public virtual void ClearInvalid()
        {
            this.Call("clearInvalid");
        }

        /// <summary>
        /// Mark this field as invalid, using msgTarget to determine how to display the error and applying invalidClass to the field's element.
        /// </summary>
        [Meta]
        [Description("Mark this field as invalid, using msgTarget to determine how to display the error and applying invalidClass to the field's element.")]
        public virtual void MarkInvalid()
        {
            this.Call("markInvalid");
        }

        /// <summary>
        /// Mark this field as invalid, using msgTarget to determine how to display the error and applying invalidClass to the field's element.
        /// </summary>
        [Meta]
        [Description("Mark this field as invalid, using msgTarget to determine how to display the error and applying invalidClass to the field's element.")]
        public virtual void MarkInvalid(string msg)
        {
            this.Call("markInvalid", msg);
        }

        /// <summary>
        /// Resets the current field value to the originally loaded value and clears any validation messages
        /// </summary>
        [Meta]
        [Description("Resets the current field value to the originally loaded value and clears any validation messages")]
        public virtual void Reset()
        {
            this.Call("reset");
        }

        /// <summary>
        /// Sets the underlying DOM field's value directly, bypassing validation. To set the value with validation see setValue.
        /// </summary>
        [Meta]
        [Description("Sets the underlying DOM field's value directly, bypassing validation. To set the value with validation see setValue.")]
        public virtual void SetRawValue(object value)
        {
            this.RawValue = value;
        }

        /// <summary>
        /// Sets a data value into the field and validates it. To set the value directly without validation see setRawValue.
        /// </summary>
        [Description("Sets a data value into the field and validates it. To set the value directly without validation see setRawValue.")]
        public virtual void SetValue(object value)
        {
            this.Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetValueProxy(object value)
        {
            this.Call("setValue", value);
        }

        /// <summary>
        /// Sets the underlying DOM field's value directly, bypassing validation. To set the value with validation see setValue.
        /// </summary>
        [Description("Sets the underlying DOM field's value directly, bypassing validation. To set the value with validation see setValue.")]
        protected virtual void SetRawValueProxy(object value)
        {
            this.Call("setRawValue", value);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetReadOnly(bool value)
        {
            this.Call("setReadOnly", value);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetNoteCls(string cls)
        {
            this.Call("setNoteCls", cls);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetNote(string note)
        {
            this.SetNote(note, this.NoteEncode);
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void SetNote(string note, bool encode)
        {
            this.Call("setNote", note, encode);
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void ShowNote()
        {
            this.Call("showNote");
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void HideNote()
        {
            this.Call("hideNote");
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual List<Icon> Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>(1);
                icons.Add(this.IndicatorIcon);
                return icons;
            }
        }

        /* Remote Validation */
        
        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool IsRemoteValidation
        {
            get
            {
                object obj = this.ViewState["IsRemoteValidation"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["IsRemoteValidation"] = value;
            }
        }

        private RemoteValidationDirectEvent remoteValidation;

        /// <summary>
        /// 
        /// </summary>
        [Category("5. Field")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [ConfigOption("remoteValidationOptions", JsonMode.Object)]
        [Description("")]
        public RemoteValidationDirectEvent RemoteValidation
        {
            get
            {
                if (this.remoteValidation == null)
                {
                    this.remoteValidation = new RemoteValidationDirectEvent();
                    this.remoteValidation.Owner = this;
                }

                return this.remoteValidation;
            }
        }

        private JFunction getErrors;

        /// <summary>
        /// Runs this field's validators and returns an array of error messages for any validation failures. This is called internally during validation and would not usually need to be used manually. Each subclass should override or augment the return value to provide their own errors
        /// Returns: Array All error messages for this field
        /// </summary>

        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Field")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Runs this field's validators and returns an array of error messages for any validation failures.")]
        public virtual JFunction GetErrors
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

        /*  IPostBackDataHandler + IPostBackEventHandler
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgument"></param>
        /// <param name="extraParams"></param>
        [Description("")]
        public void RaiseAjaxPostBackEvent(string eventArgument, ParameterCollection extraParams)
        {
            bool success = true;
            string message = null;
            object value = null;

            try
            {
                if (eventArgument.IsEmpty())
                {
                    throw new ArgumentNullException("eventArgument");
                }

                XmlNode xmlData = this.SubmitConfig;
                string data = null;

                if (xmlData != null)
                {
                    XmlNode serviceNode = xmlData.SelectSingleNode("config/serviceParams");

                    if (serviceNode != null)
                    {
                        data = serviceNode.InnerText;
                    }
                }

                switch (eventArgument)
                {
                    case "remotevalidation":
                        RemoteValidationEventArgs e = new RemoteValidationEventArgs(data, extraParams);
                        this.RemoteValidation.OnValidation(e);                        
                        success = e.Success;
                        message = e.ErrorMessage;
                        if (e.ValueIsChanged)
                        {
                            value = e.Value;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                success = false;
                message = this.IsDebugging ? ex.ToString() : ex.Message;

                if (this.ResourceManager.RethrowAjaxExceptions)
                {
                    throw;
                }
            }

            ResourceManager.ServiceResponse = new { valid=success, message, value };
        }

        private bool hasLoadPostData = false;

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool HasLoadPostData
        {
            get
            {
                return this.hasLoadPostData;
            }
            set
            {
                this.hasLoadPostData = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        bool IXPostBackDataHandler.HasLoadPostData
        {
            get
            {
                return this.HasLoadPostData;
            }
            set
            {
                this.HasLoadPostData = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            return this.LoadPostData(postDataKey, postCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            this.RaisePostDataChangedEvent();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void RaisePostDataChangedEvent() { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void RaisePostBackEvent(string eventArgument) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cls"></param>
        [Description("")]
        protected virtual void SetIndicatorIconCls(string cls)
        {
            this.Call("setIndicatorIconCls", cls);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        [Description("")]
        protected virtual void SetIndicatorIconCls(Icon icon)
        {
            if (this.IndicatorIcon != Icon.None)
            {
                this.SetIndicatorIconCls(ResourceManager.GetIconClassName(icon));
            }
            else
            {
                this.SetIndicatorIconCls("");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetIndicatorCls(string cls)
        {
            this.Call("setIndicatorCls", cls);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetIndicatorText(string text)
        {
            this.Call("setIndicator", text);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetIndicatorTip(string tip)
        {
            this.Call("setIndicatorTip", tip);
        }  

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void ShowIndicator()
        {
            this.Call("showIndicator");
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void HideIndicator()
        {
            this.Call("hideIndicator");
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void ClearIndicator()
        {
            this.Call("clearIndicator");
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void AlignIndicator()
        {
            this.Call("alignIndicator");
        }

        /// <summary>
        /// this method is used with remote validation only
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void MarkAsValid()
        {
            this.Call("markAsValid");
        }

        /// <summary>
        /// this method is used with remote validation only
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void MarkAsValid(bool abortRequest)
        {
            this.Call("markAsValid", abortRequest);
        }
    }
}