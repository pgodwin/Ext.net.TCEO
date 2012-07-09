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
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Base class for Numeric field.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:NumberField runat=\"server\" />")]
    [DefaultProperty("Number")]
    [DefaultEvent("TextChanged")]
    [ValidationProperty("Number")]
    [ControlValueProperty("Number")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [Designer(typeof(NumberFieldDesigner))]
    [ToolboxBitmap(typeof(NumberField), "Build.ToolboxIcons.NumberField.bmp")]
    [Description("Base class for Numeric field.")]
    public abstract partial class NumberFieldBase : TextFieldBase
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
                return "numberfield";
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
                return "Ext.form.NumberField";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            if (this.AutoPostBack)
            {
                this.On("change", new JFunction(this.PostBackFunction));
            }
        }

        /// <summary>
        /// The fields null value.
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [Description("The fields null value.")]
        public override object EmptyValue
        {
            get
            {
                object obj = this.ViewState["EmptyValue"];
                return (obj == null) ? double.MinValue : obj;
            }
            set
            {
                this.ViewState["EmptyValue"] = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Browsable(false)]
        [DefaultValue(InputType.Text)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description()]
        public override InputType InputType
        {
            get
            {
                return InputType.Text;
            }
            set
            {
                base.InputType = value;
            }
        }

        /// <summary>
        /// The Text value to initialize this field with.
        /// </summary>
        [Meta]
        [Category("Appearance")]
        [DefaultValue("")]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("The Text value to initialize this field with.")]
        public override string Text
        {
            get
            {
                return !this.IsEmpty ? this.Number.ToString(NumberFormatInfo.InvariantInfo) : "";
            }
            set
            {
                this.Number = this.CheckRange(value);
            }
        }

        /// <summary>
        /// The Number (double) to initialize this field with.
        /// </summary>
        [Meta]
        [Category("Appearance")]
        [DefaultValue(double.MinValue)]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("The Number (double) to initialize this field with.")]
        public virtual double Number
        {
            get
            {
                return this.CheckRange(Convert.ToDouble(this.Value));
            }
            set
            {
                this.Value = this.CheckRange(value);
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual double CheckRange(string value)
        {
            if (value.IsEmpty() || value == this.EmptyText || value == this.BlankText)
            {
                return double.MinValue;
            }
            
            Double number;

            try
            {
                if (this.DecimalSeparator.IsNotEmpty())
                {
                    NumberFormatInfo nf = new NumberFormatInfo();
                    nf.NumberDecimalSeparator = this.DecimalSeparator;
                    number = Double.Parse(value, nf);
                }
                else
                {
                    number = Double.Parse(value, NumberFormatInfo.InvariantInfo);
                }
                
            }
            catch (Exception exception)
            {
                throw new InvalidCastException("The Text value supplied is not a type of Double. " + exception.Message);
            }

            return this.CheckRange(number);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual double CheckRange(double number)
        {
            number = this.MinValue > number ? this.MinValue : number;

            return this.MaxValue < number ? this.MaxValue : number;
        }


        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        protected override void Render(HtmlTextWriter writer)
        {
            if (this.MinValue > this.MaxValue)
            {
                throw new ArgumentOutOfRangeException("MinValue", "The MinValue must be less then the MaxValue.");
            }

            base.Render(writer);
        }

        private static readonly object EventNumberChanged = new object();

        /// <summary>
        /// Fires when the Number property has been changed.
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Text property has been changed.")]
        public event EventHandler NumberChanged
        {
            add
            {
                Events.AddHandler(EventNumberChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventNumberChanged, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnNumberChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventNumberChanged];

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
            base.RaisePostDataChangedEvent();
            this.OnNumberChanged(EventArgs.Empty);
        }


        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// False to disallow decimal values (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue(true)]
        [Description("False to disallow decimal values (defaults to true).")]
        public virtual bool AllowDecimals
        {
            get
            {
                object obj = this.ViewState["AllowDecimals"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AllowDecimals"] = value;
            }
        }

        /// <summary>
        /// False to disallow trim trailed zeros.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue(true)]
        [Description("False to disallow trim trailed zeros.")]
        public virtual bool TrimTrailedZeros
        {
            get
            {
                object obj = this.ViewState["TrimTrailedZeros"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["TrimTrailedZeros"] = value;
            }
        }

        /// <summary>
        /// False to prevent entering a negative sign (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue(true)]
        [Description("False to prevent entering a negative sign (defaults to true).")]
        public virtual bool AllowNegative
        {
            get
            {
                object obj = this.ViewState["AllowNegative"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AllowNegative"] = value;
            }
        }

        /// <summary>
        /// The base set of characters to evaluate as valid numbers (defaults to '0123456789').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue("0123456789")]
        [Description("The base set of characters to evaluate as valid numbers (defaults to '0123456789').")]
        public virtual string BaseChars
        {
            get
            {
                object obj = this.ViewState["BaseChars"];
                return (obj == null) ? "0123456789" : (string)obj;
            }
            set
            {
                this.ViewState["BaseChars"] = value;
            }
        }

        /// <summary>
        /// The maximum precision to display after the decimal separator (defaults to 2).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue(2)]
        [Description("The maximum precision to display after the decimal separator (defaults to 2).")]
        public virtual int DecimalPrecision
        {
            get
            {
                object obj = this.ViewState["DecimalPrecision"];
                return (obj == null) ? 2 : (int)obj;
            }
            set
            {
                this.ViewState["DecimalPrecision"] = value;
            }
        }

        /// <summary>
        /// Character(s) to allow as the decimal separator (defaults to '.').
        /// </summary>
        [Meta]        
        [Category("7. NumberField")]
        [DefaultValue(".")]
        [Description("Character(s) to allow as the decimal separator (defaults to '.').")]
        public virtual string DecimalSeparator
        {
            get
            {
                string separator = this.ViewState["DecimalSeparator"] as string;

                if (separator.IsNotEmpty())
                {
                    return separator;
                }

                ResourceManager rm = this.SafeResourceManager;

                if (rm != null)
                {
                    CultureInfo locale = rm.CurrentLocale;
                    return locale.NumberFormat.NumberDecimalSeparator;
                }

                return ".";
            }
            set
            {
                this.ViewState["DecimalSeparator"] = value;
            }
        }

        [ConfigOption("decimalSeparator")]
        [DefaultValue("")]
        protected virtual string DecimalSeparatorProxy
        {
            get
            {
                //ResourceManager rm = this.SafeResourceManager;
                string ds = this.DecimalSeparator;

                //if (rm != null)
                //{
                //    CultureInfo locale = rm.CurrentLocale;
                //    return locale.NumberFormat.NumberDecimalSeparator == ds ? "" : ds;                    
                //}

                //return ds == "." ? "" : ds;
                
                // Temporary solution because ExtJS locales don't have always proper decimal separator
                return ds;
            }
        }

        /// <summary>
        /// Error text to display if the maximum value validation fails (defaults to 'The maximum value for this field is {maxValue}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue("The maximum value for this field is {maxValue}")]
        [Localizable(true)]
        [Description("Error text to display if the maximum value validation fails (defaults to 'The maximum value for this field is {maxValue}').")]
        public virtual string MaxText
        {
            get
            {
                return (string)this.ViewState["MaxText"] ?? "The maximum value for this field is {maxValue}";
            }
            set
            {
                this.ViewState["MaxText"] = value;
            }
        }

        /// <summary>
        /// The maximum allowed value (defaults to Double.MaxValue)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue(Double.MaxValue)]
        [Description("The maximum allowed value (defaults to Double.MaxValue)")]
        public virtual Double MaxValue
        {
            get
            {
                object obj = this.ViewState["MaxValue"];
                return (obj == null) ? Double.MaxValue : (Double)obj;
            }
            set
            {
                this.ViewState["MaxValue"] = value;
            }
        }

        /// <summary>
        /// Error text to display if the minimum value validation fails (defaults to 'The minimum value for this field is {minValue}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue("The minimum value for this field is {minValue}")]
        [Localizable(true)]
        [Description("Error text to display if the minimum value validation fails (defaults to 'The minimum value for this field is {minValue}').")]
        public virtual string MinText
        {
            get
            {
                return (string)this.ViewState["MinText"] ?? "The minimum value for this field is {minValue}";
            }
            set
            {
                this.ViewState["MinText"] = value;
            }
        }

        /// <summary>
        /// The minimum allowed value (defaults to Double.MinValue)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue(Double.MinValue)]
        [Description("The minimum allowed value (defaults to Double.MinValue)")]
        public virtual Double MinValue
        {
            get
            {
                object obj = this.ViewState["MinValue"];
                return (obj == null) ? Double.MinValue : (Double)obj;
            }
            set
            {
                this.ViewState["MinValue"] = value;
            }
        }

        /// <summary>
        /// Error text to display if the value is not a valid number. For example, this can happen if a valid character like '.' or '-' is left in the field with no number (defaults to '{value} is not a valid number').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. NumberField")]
        [DefaultValue("{value} is not a valid number")]
        [Localizable(true)]
        [Description("Error text to display if the value is not a valid number. For example, this can happen if a valid character like '.' or '-' is left in the field with no number (defaults to '{value} is not a valid number').")]
        public virtual string NanText
        {
            get
            {
                return (string)this.ViewState["NanText"] ?? "{value} is not a valid number";
            }
            set
            {
                this.ViewState["NanText"] = value;
            }
        }
    }
}