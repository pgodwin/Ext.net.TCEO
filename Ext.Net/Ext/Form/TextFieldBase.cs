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
using System.Drawing.Design;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Base Class for all Text Field Web Controls.
    /// </summary>
    [Meta]
    [Description("Base Class for all Text Field Web Controls.")]
    public abstract partial class TextFieldBase : Field, IEditableTextControl
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
                return "textfield";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.form.TextField";
            }
        }


        /*  ITextControl
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// The Text value to initialize this field with.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Category("6. TextField")]
        [Localizable(true)]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("The Text value to initialize this field with.")]
        public virtual string Text
        {
            get
            {
                object val = this.Value;
                return val == null ? "" : this.Value.ToString();
            }
            set
            {
                this.Value = value == "" ? null : value;
            }
        }

        /// <summary>
        /// Get or Set the RawValue as a string value.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Category("6. TextField")]
        [Localizable(true)]
        [Description("The Text value to initialize this field with.")]
        public virtual string RawText
        {
            get
            {
                return this.RawValue != null ? this.RawValue.ToString() : "";
            }
            set
            {
                this.RawValue = value; 
            }
        }

        /// <summary>
        /// False to validate that the value length > 0 (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(true)]
        [Description("False to validate that the value length > 0 (defaults to true).")]
        public virtual bool AllowBlank
        {
            get
            {
                object obj = this.ViewState["AllowBlank"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AllowBlank"] = value;
            }
        }

        /// <summary>
        /// Error text to display if the allow blank validation fails (defaults to 'This field is required').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the allow blank validation fails (defaults to 'This field is required').")]
        public virtual string BlankText
        {
            get
            {
                return (string)this.ViewState["BlankText"] ?? "";
            }
            set
            {
                this.ViewState["BlankText"] = value;
            }
        }

        /// <summary>
        /// True to disable input keystroke filtering (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(false)]
        [Description("True to disable input keystroke filtering (defaults to false).")]
        public virtual bool DisableKeyFilter
        {
            get
            {
                object obj = this.ViewState["DisableKeyFilter"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["DisableKeyFilter"] = value;
            }
        }

        /// <summary>
        /// The CSS class to apply to an empty field to style the emptyText (defaults to 'x-form-empty-field'). This class is automatically added and removed as needed depending on the current field value.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Description("The CSS class to apply to an empty field to style the emptyText (defaults to 'x-form-empty-field'). This class is automatically added and removed as needed depending on the current field value.")]
        public virtual string EmptyClass
        {
            get
            {
                return (string)this.ViewState["EmptyClass"] ?? "";
            }
            set
            {
                this.ViewState["EmptyClass"] = value;
            }
        }

        /// <summary>
        /// The default text to display in an empty field (defaults to null).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The default text to display in an empty field (defaults to null).")]
        public virtual string EmptyText
        {
            get
            {
                return (string)this.ViewState["EmptyText"] ?? "";
            }
            set
            {
                this.ViewState["EmptyText"] = value;
            }
        }

        /// <summary>
        /// True to enable the proxying of key events for the HTML input field (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(false)]
        [Description("True to enable the proxying of key events for the HTML input field (defaults to false)")]
        public virtual bool EnableKeyEvents
        {
            get
            {
                object obj = this.ViewState["EnableKeyEvents"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["EnableKeyEvents"] = value;
            }
        }

        /// <summary>
        /// True if this field should automatically grow and shrink to its content (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(false)]
        [Description("True if this field should automatically grow and shrink to its content (defaults to false).")]
        public virtual bool Grow
        {
            get
            {
                object obj = this.ViewState["Grow"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Grow"] = value;
            }
        }

        /// <summary>
        /// The maximum width to allow when grow = true (defaults to 800).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(typeof(Unit), "800")]
        [Description("The maximum width to allow when grow = true (defaults to 800).")]
        public virtual Unit GrowMax
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["GrowMax"], Unit.Pixel(800), "GrowMax");
            }
            set
            {
                this.ViewState["GrowMax"] = value;
            }
        }

        /// <summary>
        /// The minimum width to allow when grow = true (defaults to 30).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(typeof(Unit), "30")]
        [Description("The minimum width to allow when grow = true (defaults to 30).")]
        public virtual Unit GrowMin
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["GrowMin"], Unit.Pixel(30), "GrowMin");
            }
            set
            {
                this.ViewState["GrowMin"] = value;
            }
        }

        /// <summary>
        /// The type attribute for input fields.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("6. TextField")]
        [DefaultValue(InputType.Text)]
        [Description("The type attribute for input fields.")]
        public virtual InputType InputType
        {
            get
            {
                object obj = this.ViewState["InputType"];
                return (obj == null) ? InputType.Text : (InputType)obj;
            }
            set
            {
                this.ViewState["InputType"] = value;
            }
        }

        /// <summary>
        /// An input mask regular expression that will be used to filter keystrokes that don't match (defaults to null).
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RegexJsonConverter))]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Editor("System.Web.UI.Design.WebControls.RegexTypeEditor", typeof(UITypeEditor))]
        [DirectEventUpdate(MethodName="SetMaskRe")]
        [Description("An input mask regular expression that will be used to filter keystrokes that don't match (defaults to null).")]
        public virtual string MaskRe
        {
            get
            {
                return (string)this.ViewState["MaskRe"] ?? "";
            }
            set
            {
                this.ViewState["MaskRe"] = value;
            }
        }

        /// <summary>
        /// Maximum input field length allowed (defaults to Number.MAX_VALUE).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(-1)]
        [Description("Maximum input field length allowed (defaults to Number.MAX_VALUE).")]
        public virtual int MaxLength
        {
            get
            {
                object obj = this.ViewState["MaxLength"];
                return (obj == null) ? -1 : (int)obj;
            }
            set
            {
                this.ViewState["MaxLength"] = value;
            }
        }

        /// <summary>
        /// Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').")]
        public virtual string MaxLengthText
        {
            get
            {
                return (string)this.ViewState["MaxLengthText"] ?? "";
            }
            set
            {
                this.ViewState["MaxLengthText"] = value;
            }
        }

        /// <summary>
        /// Minimum input field length required (defaults to 0).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(0)]
        [Description("Minimum input field length required (defaults to 0).")]
        public virtual int MinLength
        {
            get
            {
                object obj = this.ViewState["MinLength"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["MinLength"] = value;
            }
        }

        /// <summary>
        /// Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').")]
        public virtual string MinLengthText
        {
            get
            {
                return (string)this.ViewState["MinLengthText"] ?? "";
            }
            set
            {
                this.ViewState["MinLengthText"] = value;
            }
        }

        /// <summary>
        /// A JavaScript RegExp object to be tested against the field value during validation (defaults to null). If available, this regex will be evaluated only after the basic validators all return true, and will be passed the current field value. If the test fails, the field will be marked invalid using RegexText.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RegexJsonConverter))]
        [DirectEventUpdate(MethodName = "SetRegex")]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Editor("System.Web.UI.Design.WebControls.RegexTypeEditor", typeof(UITypeEditor))]
        [Description("A JavaScript RegExp object to be tested against the field value during validation (defaults to null). If available, this regex will be evaluated only after the basic validators all return true, and will be passed the current field value. If the test fails, the field will be marked invalid using RegexText.")]
        public virtual string Regex
        {
            get
            {
                return (string)this.ViewState["Regex"] ?? "";
            }
            set
            {
                this.ViewState["Regex"] = value;
            }
        }

        /// <summary>
        /// The error text to display if regex is used and the test fails during validation (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to display if regex is used and the test fails during validation (defaults to '').")]
        public virtual string RegexText
        {
            get
            {
                return (string)this.ViewState["RegexText"] ?? "";
            }
            set
            {
                this.ViewState["RegexText"] = value;
            }
        }

        /// <summary>
        /// True to automatically select any existing field text when the field receives input focus (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(false)]
        [Description("True to automatically select any existing field text when the field receives input focus (defaults to false).")]
        public virtual bool SelectOnFocus
        {
            get
            {
                object obj = this.ViewState["SelectOnFocus"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["SelectOnFocus"] = value;
            }
        }

        /// <summary>
        /// If MaxLength property has been set, more characters than the MaxLength can be entered if Truncate='false'. If 'false', then a validation error is rendered if more characters entered (or pasted) than the MaxLength property. Default value is 'true'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue(true)]
        [Description("If MaxLength property has been set, more characters than the MaxLength can be entered if Truncate='false'. If 'false', then a validation error is rendered if more characters entered (or pasted) than the MaxLength property. Default value is 'true'.")]
        public virtual bool Truncate
        {
            get
            {
                object obj = this.ViewState["Truncate"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Truncate"] = value;
            }
        }

        /// <summary>
        /// A custom validation function to be called during field validation (defaults to null). If available, this function will be called only after the basic validators all return true, and will be passed the current field value and expected to return boolean true if the value is valid or a string error message if invalid.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Editor("System.Web.UI.Design.WebControls.RegexTypeEditor", typeof(UITypeEditor))]
        [Description("A custom validation function to be called during field validation (defaults to null). If available, this function will be called only after the basic validators all return true, and will be passed the current field value and expected to return boolean true if the value is valid or a string error message if invalid.")]
        public virtual string Validator
        {
            get
            {
                return (string)this.ViewState["Validator"] ?? "";
            }
            set
            {
                this.ViewState["Validator"] = value;
            }
        }

        /// <summary>
        /// A validation type name as defined in Ext.form.VTypes (defaults to null).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Description("A validation type name as defined in Ext.form.VTypes (defaults to null).")]
        public virtual string Vtype
        {
            get
            {
                return (string)this.ViewState["Vtype"] ?? "";
            }
            set
            {
                this.ViewState["Vtype"] = value;
            }
        }

        /// <summary>
        /// A custom error message to display in place of the default message provided for the vtype currently set for this field (defaults to ''). Only applies if vtype is set, else ignored.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TextField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("A custom error message to display in place of the default message provided for the vtype currently set for this field (defaults to ''). Only applies if vtype is set, else ignored.")]
        public virtual string VtypeText
        {
            get
            {
                return (string)this.ViewState["VtypeText"] ?? "";
            }
            set
            {
                this.ViewState["VtypeText"] = value;
            }
        }

        private static readonly object EventTextChanged = new object();

        /// <summary>
        /// Fires when the Text property has been changed.
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Text property has been changed.")]
        public event EventHandler TextChanged
        {
            add
            {
                Events.AddHandler(EventTextChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventTextChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnTextChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventTextChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void RaisePostDataChangedEvent()
        {
            this.OnTextChanged(EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.UniqueName];
            val = val != null && val.Equals(this.EmptyText) ? "" : val;

            this.SuspendScripting();
            this.RawValue = val;
            this.ResumeScripting();

            if (val != null && this.Text != val)
            {
                bool raise = val != (this.Text ?? "");

                try
                {
                    this.SuspendScripting();
                    this.Text = val.Equals(this.EmptyText) ? "" : val;
                }
                finally
                {
                    this.ResumeScripting();
                }

                return raise;
            }

            return false;
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Automatically grows the field to accomodate the width of the text up to the maximum field width allowed. This only takes effect if grow = true, and fires the autosize event.
        /// </summary>
        [Meta]
        [Description("Automatically grows the field to accomodate the width of the text up to the maximum field width allowed. This only takes effect if grow = true, and fires the autosize event.")]
        public virtual void AutoSize()
        {
            this.Call("autoSize");
        }

        /// <summary>
        /// Selects text in this field
        /// </summary>
        [Meta]
        [Description("Selects text in this field")]
        public virtual void SelectText()
        {
            this.Call("selectText");
        }

        /// <summary>
        /// Selects text in this field
        /// </summary>
        [Meta]
        [Description("Selects text in this field")]
        public virtual void SelectText(int start)
        {
            this.Call("selectText", start);
        }

        /// <summary>
        /// Selects text in this field
        /// </summary>
        [Meta]
        [Description("Selects text in this field")]
        public virtual void SelectText(int start, int end)
        {
            this.Call("selectText", start, end);
        }

        /// <summary>
        /// The icon to use in the input field. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [Category("5. Button")]
        [DefaultValue(Icon.None)]
        [DirectEventUpdate(MethodName = "SetIconClass")]
        [Description("The icon to use in the input field. See also, IconCls to set an icon with a custom Css class.")]
        public virtual Icon Icon
        {
            get
            {
                object obj = this.ViewState["Icon"];
                return (obj == null) ? Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["Icon"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("iconCls")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string IconClsProxy
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return ResourceManager.GetIconClassName(this.Icon);
                }

                return this.IconCls;
            }
        }

        /// <summary>
        /// A css class which sets a background image to be used as the icon for this field.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetIconClass")]
        [Category("5. Button")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class which sets a background image to be used as the icon for this field.")]
        public virtual string IconCls
        {
            get
            {
                return (string)this.ViewState["IconCls"] ?? "";
            }
            set
            {
                this.ViewState["IconCls"] = value;
            }
        }

        public override List<Icon> Icons
        {
            get
            {
                List<Icon> icons = base.Icons;
                icons.Capacity += 1;
                icons.Add(this.Icon);
                return icons;
            }
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        [Description("Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.")]
        protected virtual void SetIconClass(string cls)
        {
            this.Call("setIconClass", cls);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regex"></param>
        [Description("")]
        protected virtual void SetRegex(string regex)
        {
            this.AddScript("{0}.regex={1};", this.ClientID, regex.FormatRegexPattern());
        }

        /// <summary>
        /// Sets an input mask regular expression that will be used to filter keystrokes that don't match (defaults to null).
        /// </summary>
        /// <param name="maskRe"></param>
        [Description("Sets an input mask regular expression that will be used to filter keystrokes that don't match (defaults to null).")]
        protected void SetMaskRe(string maskRe)
        {
            this.Set("maskRe", new JRawValue(maskRe.StartsWith("/") ? maskRe : maskRe.Wrap("/")));
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        [Description("Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.")]
        protected virtual void SetIconClass(Icon icon)
        {
            if (this.Icon != Icon.None)
            {
                this.SetIconClass(ResourceManager.GetIconClassName(icon));
            }
            else
            {
                this.SetIconClass("");
            }
        }
    }
}