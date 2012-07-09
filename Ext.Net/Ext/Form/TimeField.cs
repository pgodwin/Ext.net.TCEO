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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Provides a time input field with a time dropdown and automatic time validation.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:TimeField runat=\"server\"></{0}:TimeField>")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(TimeField), "Build.ToolboxIcons.TimeField.bmp")]
    [Description("Provides a time input field with a time dropdown and automatic time validation.")]
    public partial class TimeField : ComboBox
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TimeField() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "timefield";
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
                return "Ext.form.TimeField";
            }
        }

        /*  IField
            -----------------------------------------------------------------------------------------------*/
        private TimeSpan initTime = new TimeSpan(-9223372036854775808);

        /// <summary>
        /// The fields null value.
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [DefaultValue(typeof(TimeSpan), "-9223372036854775808")]
        [Description("The fields null value.")]
        public override object EmptyValue
        {
            get
            {
                object obj = this.ViewState["EmptyValue"];
                return (obj == null) ? this.initTime : obj;
            }
            set
            {
                this.ViewState["EmptyValue"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("store", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected override string ItemsProxy
        {
            get
            {
                if (this.StoreID.IsNotEmpty() || this.Items.Count == 0)
                {
                    return "";
                }

                return this.ItemsToStore;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [TypeConverter(typeof(TimeSpanConverter))]
        [Category("9. TimeField")]
        [DefaultValue(typeof(TimeSpan), "-9223372036854775808")]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("")]
        public TimeSpan SelectedTime
        {
            get
            {
                object obj = this.Value;
                return obj == null ? (TimeSpan)this.EmptyValue : (TimeSpan)obj;
            }
            set
            {
                this.Value = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("value")]
        [DefaultValue(null)]
        protected internal override object ValueProxy
        {
            get
            {
                CultureInfo culture = this.SafeResourceManager != null ? this.ResourceManager.CurrentLocale : CultureInfo.CurrentUICulture;
                return (this.SelectedTime != this.initTime) ? new DateTime(this.SelectedTime.Ticks).ToString(this.Format, culture).ToLower(culture) : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("9. TimeField")]
        [DefaultValue(null)]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("")]
        public object SelectedValue
        {
            get
            {
                if (this.IsEmpty)
                {
                    return null;
                }
                else
                {
                    return this.SelectedTime;
                }
            }
            set
            {
                this.Value = value;
            }
        }
		
		/// <summary>
        /// 
        /// </summary>
        [Meta]
        [Browsable(false)]
        [DirectEventUpdate(MethodName = "SetTimeValue")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        [Description("")]
        public override object Value
        {
            get
            {
                object obj = this.ViewState["Value"];
                return (obj == null) ? null : obj;
            }
            set
            {
                if (this.SafeResourceManager == null)
                {
                    this.Init += delegate
                    {
                        this.Value = this.ViewState["Value"];
                    };
                    this.ViewState["Value"] = value;
                    return;
                }
                
                TimeSpan obj = (TimeSpan)this.EmptyValue;

                if (value is TimeSpan)
                {
                    obj = (TimeSpan)value;
                }
                else if (value is DateTime)
                {
                    obj = ((DateTime)value).TimeOfDay;
                }
                else if (value == null || value is System.DBNull)
                {
                    obj = (TimeSpan)this.EmptyValue;
                }
                else
                {
                    try
                    {
                        DateTime postedValue = DateTime.ParseExact(value.ToString(), this.Format, this.ResourceManager.CurrentLocale);
                        obj = postedValue.TimeOfDay;
                    }
                    catch
                    {
                        obj = TimeSpan.Parse(value.ToString());
                    }
                }

                this.ViewState["Value"] = obj;
            }
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

            bool val = base.LoadPostData(postDataKey, postCollection);

            this.SuspendScripting();

            this.RawValue = this.SelectedItem.Value;

            if (this.SelectedItem.Value.IsEmpty())
            {
                this.Value = this.EmptyValue;
            }
            else
            {
                this.Value = this.SelectedItem.Value;
            }

            this.ResumeScripting();

            return val;
        }

        /// <summary>
        /// Multiple date formats separated by \" | \" to try when parsing a user input value and it doesn't match the defined format (defaults to 'm/d/Y|m-d-y|m-d-Y|m/d|m-d|d').
        /// </summary>
        [Meta]
        [Category("9. TimeField")]
        [DefaultValue("")]
        [Description("Multiple date formats separated by \" | \" to try when parsing a user input value and it doesn't match the defined format (defaults to 'm/d/Y|m-d-y|m-d-Y|m/d|m-d|d').")]
        public virtual string AltFormats
        {
            get
            {
                return (string)this.ViewState["AltFormats"] ?? "";
            }
            set
            {
                this.ViewState["AltFormats"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("altFormats")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string AltFormatsProxy
        {
            get
            {
                return this.AltFormats.IsNotEmpty() ? DateTimeUtils.ConvertNetToPHP(this.AltFormats) : "";
            }
        }

        /// <summary>
        /// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'm/d/y').
        /// </summary>
        [Meta]
        [Category("9. TimeField")]
        [DefaultValue("t")]
        [Description("The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'h:mm tt', e.g., '3:15 PM'). For 24-hour time format try 'H:mm' instead.")]
        public virtual string Format
        {
            get
            {
                return (string)this.ViewState["Format"] ?? "t";
            }
            set
            {
                this.ViewState["Format"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("format")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string FormatProxy
        {
            get
            {
                return DateTimeUtils.ConvertNetToPHP(this.Format, this.HasResourceManager ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// The number of minutes between each time value in the list (defaults to 15).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("9. TimeField")]
        [DefaultValue(15)]
        [Description("The number of minutes between each time value in the list (defaults to 15).")]
        public virtual int Increment
        {
            get
            {
                object obj = this.ViewState["Increment"];
                return (obj == null) ? 15 : (int)obj;
            }
            set
            {
                this.ViewState["Increment"] = value;
            }
        }

        /// <summary>
        /// The error text to display when the time is after maxValue (defaults to 'The time in this field must be equal to or before {0}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("9. TimeField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to display when the time is after maxValue (defaults to 'The time in this field must be equal to or before {0}').")]
        public virtual string MaxText
        {
            get
            {
                return (string)this.ViewState["MaxText"] ?? "";
            }
            set
            {
                this.ViewState["MaxText"] = value;
            }
        }

        /// <summary>
        /// The maximum allowed time. Can be either a Javascript date object or a string date in a valid format (defaults to TimeSpan.MaxValue).
        /// </summary>
        [Meta]
        [Category("9. TimeField")]
        [DefaultValue(typeof(TimeSpan), "9223372036854775807")]
        [TypeConverter(typeof(TimeSpanConverter))]
        [Description("The maximum allowed time. Can be either a Javascript date object or a string date in a valid format (defaults to null).")]
        public virtual TimeSpan MaxTime
        {
            get
            {
                object obj = this.ViewState["MaxTime"];

                if (obj == null && this.DesignMode)
                {
                    return new TimeSpan(23, 59, 59);
                }
                
                return (obj == null) ? TimeSpan.MaxValue : (TimeSpan)obj;
            }
            set
            {
                this.ViewState["MaxTime"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("maxValue")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string MaxTimeProxy
        {
            get
            {
                CultureInfo culture = this.SafeResourceManager != null ? this.ResourceManager.CurrentLocale : CultureInfo.CurrentUICulture;
                return (this.MaxTime != TimeSpan.MaxValue) ? new DateTime(this.MaxTime.Ticks).ToString(this.Format, culture).ToLower(culture) : "";
            }
        }

        /// <summary>
        /// The minimum allowed time. Can be either a Javascript date object or a string date in a valid format (defaults to TimeSpan.MinValue).
        /// </summary>
        [Meta]
        [Category("9. TimeField")]
        [DefaultValue(typeof(TimeSpan), "-9223372036854775808")]
        [TypeConverter(typeof(TimeSpanConverter))]
        [Description("The minimum allowed time. Can be either a Javascript date object or a string date in a valid format (defaults to null).")]
        public virtual TimeSpan MinTime
        {
            get
            {
                object obj = this.ViewState["MinTime"];

                if (obj == null && this.DesignMode)
                {
                    return TimeSpan.Zero;
                }

                return (obj == null) ? (TimeSpan)this.EmptyValue : (TimeSpan)obj;
            }
            set
            {
                this.ViewState["MinTime"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("minValue")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string MinTimeProxy
        {
            get
            {
                CultureInfo culture = this.SafeResourceManager != null ? this.ResourceManager.CurrentLocale : CultureInfo.CurrentUICulture;
                return (this.MinTime != (TimeSpan)this.EmptyValue) ? new DateTime(this.MinTime.Ticks).ToString(this.Format, culture).ToLower(culture) : "";
            }
        }

        /// <summary>
        /// The error text to display when the date in the cell is before minValue (defaults to 'The time in this field must be equal to or after {0}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("9. TimeField")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to display when the date in the cell is before minValue (defaults to 'The time in this field must be equal to or after {0}').")]
        public virtual string MinText
        {
            get
            {
                return (string)this.ViewState["MinText"] ?? "";
            }
            set
            {
                this.ViewState["MinText"] = value;
            }
        }

        internal void SetSelectedTime(TimeSpan time)
        {
            CultureInfo culture = this.SafeResourceManager != null ? this.ResourceManager.CurrentLocale : CultureInfo.CurrentUICulture;
            this.Call("setValue", new DateTime(time.Ticks).ToString(this.Format, culture).ToLower(culture));
        }

        internal void SetTimeValue(object time)
        {
            this.SetSelectedTime((TimeSpan)time);
        }


        /*  DirectEvent Handler
            -----------------------------------------------------------------------------------------------*/
        
        static TimeField()
        {
            DirectEventChange = new object();
        }

        private static readonly object DirectEventChange;

        /// <summary>
        /// Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).
        /// </summary>
        [Description("Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).")]
        public event ComponentDirectEvent.DirectEventHandler DirectChange
        {
            add
            {
                this.DirectEvents.Change.Event += value;
            }
            remove
            {
                this.DirectEvents.Change.Event -= value;
            }
        }


        /*  Hidden
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ConfigOption(JsonMode.Ignore)]
        [Description("")]
        public override string AllQuery
        {
            get { return base.AllQuery; }
            set { base.AllQuery = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ConfigOption(JsonMode.Ignore)]
        [Description("")]
        public override int QueryDelay
        {
            get { return base.QueryDelay; }
            set { base.QueryDelay = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ConfigOption(JsonMode.Ignore)]
        [Description("")]
        public override string QueryParam
        {
            get { return base.QueryParam; }
            set { base.QueryParam = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ConfigOption(JsonMode.Ignore)]
        [Description("")]
        public override string StoreID
        {
            get { return base.StoreID; }
            set { base.StoreID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ConfigOption(JsonMode.Ignore)]
        [Description("")]
        public override ListItem SelectedItem
        {
            get { return base.SelectedItem; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ConfigOption]
        [DefaultValue("")]
        [Description("")]
        public override string ValueField
        {
            get { return "text"; }
            set { base.ValueField = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ConfigOption(JsonMode.Ignore)]
        [Description("")]
        public override string DisplayField
        {
            get { return ""; }
            set { base.DisplayField = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ConfigOption(JsonMode.Ignore)]
        [Description("")]
        public override TriggerAction TriggerAction
        {
            get { return TriggerAction.Query; }
            set { base.TriggerAction = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [ConfigOption(JsonMode.Ignore)]
        [Description("")]
        public override DataLoadMode Mode
        {
            get { return DataLoadMode.Remote; }
            set { base.Mode = value; }
        }
    }
}