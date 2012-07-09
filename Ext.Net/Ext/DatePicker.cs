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
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;
using Newtonsoft.Json;
using System.Globalization;

namespace Ext.Net
{
    /// <summary>
    /// Simple DatePicker class.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:DatePicker runat=\"server\" />")]
    [DefaultProperty("SelectedDate")]
    [DefaultEvent("SelectionChanged")]
    [ValidationProperty("SelectedDate")]
    [ControlValueProperty("SelectedDate")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [Designer(typeof(DatePickerDesigner))]
    [ToolboxBitmap(typeof(DatePicker), "Build.ToolboxIcons.DatePicker.bmp")]
    [Description("Simple DatePicker class.")]
    public partial class DatePicker : Component, IDate, IAutoPostBack, IXPostBackDataHandler, IPostBackEventHandler, IField
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public DatePicker() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "datepicker";
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
                return "Ext.DatePicker";
            }
        }


        /*  IField
            -----------------------------------------------------------------------------------------------*/

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
        /// The note.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Field")]
        [DefaultValue("")]
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
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(typeof(CtorDateTimeJsonConverter))]
        [DirectEventUpdate(MethodName = "SetValueProxy")]
        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public virtual object Value
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
                
                DateTime obj = (DateTime)this.EmptyValue;

                if (value is string)
                {
                    try
                    {
                        obj = DateTime.ParseExact((string)value, this.Format, this.ResourceManager.CurrentLocale);
                    }
                    catch
                    {
                        try
                        {
                            obj = DateTime.Parse((string)value, this.ResourceManager.CurrentLocale);
                        }
                        catch { }
                    }
                }
                else if (value is DateTime)
                {
                    obj = (DateTime)value;
                }

                this.ViewState["Value"] = obj;
            }
        }

        /// <summary>
        /// The fields null value.
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [Description("The fields null value.")]
        public virtual object EmptyValue
        {
            get
            {
                object obj = this.ViewState["EmptyValue"];
                return (obj == null) ? new DateTime(0001, 01, 01) : obj;
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
                return this.Value == null || this.Value.Equals(this.EmptyValue);
            }
        }

        /// <summary>
        /// Clear the value of this field.
        /// </summary>
        [Meta]
        [Description("Clear the value of this field.")]
        public virtual void Clear()
        {
            this.SuspendScripting();
            this.Value = this.EmptyValue;
            this.ResumeScripting();
            this.Call("clear");
        }


        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            if (this.AutoPostBack)
            {
                this.On("select", new JFunction(this.PostBackFunction), "this", new HandlerConfig { Delay = 10 });
            }
        }


        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// AutoPostBack
        /// </summary>
        /// <value><c>true</c> if [auto post back]; otherwise, <c>false</c>.</value>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("AutoPostBack")]
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
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.")]
        public virtual bool CausesValidation
        {
            get
            {
                object obj = this.ViewState["CausesValidation"];
                return (obj != null && (bool)obj);
            }
            set
            {
                this.ViewState["CausesValidation"] = value;
            }
        }

        /// <summary>
        /// Gets or Sets the Controls ValidationGroup
        /// </summary>
        [Meta]
        [Category("Behavior")]
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
        /// Gets or sets the current selected date of the DatePicker. Accepts and returns a DateTime object.
        /// </summary>
        [Meta]
        [Category("4. DatePicker")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("Gets or sets the current selected date of the DatePicker. Accepts and returns a DateTime object.")]
        public virtual DateTime SelectedDate
        {
            get
            {
                object obj = this.Value;
                return (obj == null) ? (DateTime)this.EmptyValue : (DateTime)obj;
            }
            set
            {
                this.Value = value.Date;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("4. DatePicker")]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("Gets or sets the current selected date of the DatePicker.")]
        public object SelectedValue
        {
            get
            {
                if (this.IsEmpty)
                {
                    return this.EmptyValue;
                }
                else
                {
                    return this.SelectedDate;
                }
            }
            set
            {
                object init = value;

                if (init is DateTime)
                {
                    this.SelectedDate = (DateTime)init;
                }
                else if (init == null || init is System.DBNull)
                {
                    this.SelectedDate = (DateTime)this.EmptyValue;
                }
                else
                {
                    try
                    {
                        this.SelectedDate = DateTime.Parse(init.ToString(), this.ResourceManager.CurrentLocale.DateTimeFormat);
                    }
                    catch (FormatException)
                    {
                        this.SelectedDate = (DateTime)this.EmptyValue;
                    }
                }
            }
        }

        /// <summary>
        /// The text to display on the cancel button.
        /// </summary>
        [Meta]
        [ConfigOption]
        [UrlProperty]
        [Category("4. DatePicker")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The text to display on the cancel button.")]
        public virtual string CancelText
        {
            get
            {
                return (string)this.ViewState["CancelText"] ?? "";
            }
            set
            {
                this.ViewState["CancelText"] = value;
            }
        }

        private DisabledDateCollection disabledDates;
        
        /// <summary>
        /// An array of \"dates\" to disable, as strings. These strings will be used to build a dynamic regular expression so they are very powerful.
        /// </summary>
        [Meta]
        [Category("4. DatePicker")]
        [Description("An array of \"dates\" to disable, as strings. These strings will be used to build a dynamic regular expression so they are very powerful.")]
        public virtual DisabledDateCollection DisabledDates
        {
            get
            {
                if (this.disabledDates == null)
                {
                    this.disabledDates = new DisabledDateCollection();
                }

                return this.disabledDates;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("disabledDates", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected string DisabledDatesProxy
        {
            get
            {
                return this.DisabledDates.ToString(this.Format.IsEmpty() ? "yyyy-MM-dd\\Thh:mm:ss" : this.Format, this.HasResourceManager ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// An array of textual day names which can be overriden for localization support (defaults to Date.dayNames).
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("4. DatePicker")]
        [DefaultValue(null)]
        [Description("An array of textual day names which can be overriden for localization support (defaults to Date.dayNames).")]
        public virtual string[] DayNames
        {
            get
            {
                object obj = this.ViewState["DayNames"];
                return (obj == null) ? null : (string[])obj;
            }
            set
            {
                this.ViewState["DayNames"] = value;
            }
        }

        /// <summary>
        /// JavaScript regular expression used to disable a pattern of dates (defaults to null).
        /// </summary>
        [Meta]
        [ConfigOption(typeof(RegexJsonConverter))]
        [Category("4. DatePicker")]
        [DefaultValue("")]
        [Editor("System.Web.UI.Design.WebControls.RegexTypeEditor", typeof(UITypeEditor))]
        [Description("JavaScript regular expression used to disable a pattern of dates (defaults to null).")]
        public virtual string DisabledDatesRE
        {
            get
            {
                return (string)this.ViewState["DisabledDatesRE"] ?? "";
            }
            set
            {
                this.ViewState["DisabledDatesRE"] = value;
            }
        }

        /// <summary>
        /// An array of days to disable, 0-based. For example, [0, 6] disables Sunday and Saturday (defaults to null).
        /// </summary>
        [Meta]
        [ConfigOption(typeof(IntArrayJsonConverter))]
        [TypeConverter(typeof(IntArrayConverter))]
        [Category("4. DatePicker")]
        [DefaultValue(null)]
        [Description("An array of days to disable, 0-based. For example, [0, 6] disables Sunday and Saturday (defaults to null).")]
        public virtual int[] DisabledDays
        {
            get
            {
                object obj = this.ViewState["DisabledDays"];
                return (obj == null) ? null : (int[])obj;
            }
            set
            {
                this.ViewState["DisabledDays"] = value;
            }
        }

        /// <summary>
        /// The tooltip to display when the date falls on a disabled day (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The tooltip to display when the date falls on a disabled day (defaults to '').")]
        public virtual string DisabledDaysText
        {
            get
            {
                return (string)this.ViewState["DisabledDaysText"] ?? "";
            }
            set
            {
                this.ViewState["DisabledDaysText"] = value;
            }
        }

        /// <summary>
        /// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'm/d/y').
        /// </summary>
        [Meta]
        [Category("4. DatePicker")]
        [DefaultValue("d")]
        [Localizable(true)]
        [Description("The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'm/d/y').")]
        public virtual string Format
        {
            get
            {
                return (string)this.ViewState["Format"] ?? "d";
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
        protected string FormatProxy
        {
            get
            {
                return DateTimeUtils.ConvertNetToPHP(this.Format, this.ResourceManager.CurrentLocale);
            }
        }

        /// <summary>
        /// The maximum allowed date.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(CtorDateTimeJsonConverter))]
        [DirectEventUpdate(MethodName = "SetMaxDate")]
        [Category("4. DatePicker")]
        [DefaultValue(typeof(DateTime), "9999-12-31")]
        [Bindable(true)]
        [Description("The maximum allowed date.")]
        public virtual DateTime MaxDate
        {
            get
            {
                object obj = this.ViewState["MaxDate"];

                if (obj == null && this.DesignMode)
                {
                    return DateTime.MinValue;
                }

                return (obj == null) ? new DateTime(9999, 12, 31) : (DateTime)obj;

            }
            set
            {
                this.ViewState["MaxDate"] = value.Date;
            }
        }

        /// <summary>
        /// The error text to display when the date in the cell is after MaxValue (defaults to 'The date in this field must be before {MaxValue}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to display when the date in the cell is after MaxValue (defaults to 'The date in this field must be before {MaxValue}').")]
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
        /// The minimum allowed date.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(CtorDateTimeJsonConverter))]
        [DirectEventUpdate(MethodName = "SetMinDate")]
        [DefaultValue(typeof(DateTime), "0001-01-01")]
        [Category("4. DatePicker")]
        [Bindable(true)]
        [Description("The minimum allowed date.")]
        public virtual DateTime MinDate
        {
            get
            {
                object obj = this.ViewState["MinDate"];
                return (obj == null) ? new DateTime(0001, 01, 01) : (DateTime)obj;

            }
            set
            {
                this.ViewState["MinDate"] = value.Date;
            }
        }

        /// <summary>
        /// The error text to display when the date in the cell is before MinValue (defaults to 'The date in this field must be after {MinValue}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The error text to display when the date in the cell is before MinValue (defaults to 'The date in this field must be after {MinValue}').")]
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

        /// <summary>
        /// An array of textual month names which can be overriden for localization support (defaults to Date.monthNames).
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("4. DatePicker")]
        [DefaultValue(null)]
        [Description("An array of textual month names which can be overriden for localization support (defaults to Date.monthNames).")]
        public virtual string[] MonthNames
        {
            get
            {
                object obj = this.ViewState["MonthNames"];
                return (obj == null) ? null : (string[])obj;
            }
            set
            {
                this.ViewState["MonthNames"] = value;
            }
        }

        /// <summary>
        /// The header month selector tooltip (defaults to 'Choose a month (Control+Up/Down to move years)').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("Choose a month (Control+Up/Down to move years)")]
        [Localizable(true)]
        [Description("The header month selector tooltip (defaults to 'Choose a month (Control+Up/Down to move years)').")]
        public virtual string MonthYearText
        {
            get
            {
                return (string)this.ViewState["MonthYearText"] ?? "Choose a month (Control+Up/Down to move years)";
            }
            set
            {
                this.ViewState["MonthYearText"] = value;
            }
        }

        /// <summary>
        /// The next month navigation button tooltip (defaults to 'Next Month (Control+Right)').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("Next Month (Control+Right)")]
        [Localizable(true)]
        [Description("The next month navigation button tooltip (defaults to 'Next Month (Control+Right)').")]
        public virtual string NextText
        {
            get
            {
                return (string)this.ViewState["NextText"] ?? "Next Month (Control+Right)";
            }
            set
            {
                this.ViewState["NextText"] = value;
            }
        }

        /// <summary>
        /// The text to display on the ok button.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The text to display on the ok button.")]
        public virtual string OkText
        {
            get
            {
                return (string)this.ViewState["OkText"] ?? "";
            }
            set
            {
                this.ViewState["OkText"] = value;
            }
        }

        /// <summary>
        /// The previous month navigation button tooltip (defaults to 'Previous Month (Control+Left)').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("Previous Month (Control+Left)")]
        [Localizable(true)]
        [Description("The previous month navigation button tooltip (defaults to 'Previous Month (Control+Left)').")]
        public virtual string PrevText
        {
            get
            {
                return (string)this.ViewState["PrevText"] ?? "Previous Month (Control+Left)";
            }
            set
            {
                this.ViewState["PrevText"] = value;
            }
        }

        /// <summary>
        /// False to hide the footer area containing the Today button and disable the keyboard handler for spacebar that selects the current date (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue(true)]
        [Description("False to hide the footer area containing the Today button and disable the keyboard handler for spacebar that selects the current date (defaults to true).")]
        public virtual bool ShowToday
        {
            get
            {
                object obj = this.ViewState["ShowToday"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ShowToday"] = value;
            }
        }

        /// <summary>
        /// Day index at which the week should begin, 0-based (defaults to 0, which is Sunday).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue(0)]
        [Description("Day index at which the week should begin, 0-based (defaults to 0, which is Sunday).")]
        public virtual int StartDay
        {
            get
            {
                object obj = this.ViewState["StartDay"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["StartDay"] = value;
            }
        }

        /// <summary>
        /// The text to display on the button that selects the current date (defaults to 'Today').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("Today")]
        [Localizable(true)]
        [Description("The text to display on the button that selects the current date (defaults to 'Today').")]
        public virtual string TodayText
        {
            get
            {
                return (string)this.ViewState["TodayText"] ?? "Today";
            }
            set
            {
                this.ViewState["TodayText"] = value;
            }
        }

        /// <summary>
        /// The tooltip to display for the button that selects the current date (defaults to '{current date} (Spacebar)').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. DatePicker")]
        [DefaultValue("{current date} (Spacebar)")]
        [Localizable(true)]
        [Description("The tooltip to display for the button that selects the current date (defaults to '{current date} (Spacebar)').")]
        public virtual string TodayTip
        {
            get
            {
                return (string)this.ViewState["TodayTip"] ?? "{current date} (Spacebar)";
            }
            set
            {
                this.ViewState["TodayTip"] = value;
            }
        }

        private DatePickerListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public DatePickerListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new DatePickerListeners();
                }

                return this.listeners;
            }
        }

        private DatePickerDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public DatePickerDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new DatePickerDirectEvents();
                }

                return this.directEvents;
            }
        }


        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventSelectionChanged = new object();

        /// <summary>
        /// Fires when the Item property has been changed
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Item property has been changed")]
        public event EventHandler SelectionChanged
        {
            add
            {
                Events.AddHandler(DatePicker.EventSelectionChanged, value);
            }
            remove
            {
                Events.RemoveHandler(DatePicker.EventSelectionChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnSelectionChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[DatePicker.EventSelectionChanged];

            if (handler != null)
            {
                handler(this, e);
            }
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
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            return this.LoadPostData(postDataKey, postCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.ConfigID.ConcatWith("_Input")];

            if (val.IsNotEmpty())
            {
                try
                {
                    this.SuspendScripting();
                    this.SelectedDate = DateTime.ParseExact(val, "yyyy\\-MM\\-dd\\THH\\:mm\\:ss", this.ResourceManager.CurrentLocale);
                }
                catch
                {
                    this.SelectedDate = (DateTime)this.EmptyValue;
                }
                finally
                {
                    this.ResumeScripting();
                }

                return true;
            }

            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            this.RaisePostDataChangedEvent();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void RaisePostDataChangedEvent() { }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            this.OnSelectionChanged(EventArgs.Empty);
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Sets a data value into the field and validates it. To set the value directly without validation see setRawValue.
        /// </summary>
        [Description("Sets a data value into the field and validates it. To set the value directly without validation see setRawValue.")]
        protected virtual void SetValue(object value)
        {
            List<JsonConverter> converters = new List<JsonConverter>();
            converters.Add(new CtorDateTimeJsonConverter());

            this.Call("setValue", new JRawValue(JSON.Serialize(value, converters)));
        }

        /// <summary>
        /// Replaces any existing minDate with the new value and refreshes the DatePicker.
        /// </summary>
        [Description("Replaces any existing minDate with the new value and refreshes the DatePicker.")]
        protected virtual void SetMinDate(DateTime minDate)
        {
            List<JsonConverter> converters = new List<JsonConverter>();
            converters.Add(new CtorDateTimeJsonConverter());

            this.Call("setMinDate", new JRawValue(JSON.Serialize(minDate.Date, converters)));
        }

        /// <summary>
        /// Replaces any existing maxDate with the new value and refreshes the DatePicker.
        /// </summary>
        [Description("Replaces any existing maxDate with the new value and refreshes the DatePicker.")]
        protected virtual void SetMaxDate(DateTime maxDate)
        {
            List<JsonConverter> converters = new List<JsonConverter>();
            converters.Add(new CtorDateTimeJsonConverter());

            this.Call("setMaxDate", new JRawValue(JSON.Serialize(maxDate.Date, converters)));
        }

        /// <summary>
        /// Replaces any existing disabled dates with new values and refreshes the DatePicker.
        /// </summary>
        [Description("Replaces any existing disabled dates with new values and refreshes the DatePicker.")]
        public void UpdateDisabledDates()
        {
            this.Call("setDisabledDates", new JRawValue(this.DisabledDates.ToString(this.Format, this.HasResourceManager ? this.ResourceManager.CurrentLocale : CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Replaces any existing disabled days (by index, 0-6) with new values and refreshes the DatePicker.
        /// </summary>
        [Description("Replaces any existing disabled days (by index, 0-6) with new values and refreshes the DatePicker.")]
        public void UpdateDisabledDays()
        {
            this.Call("setDisabledDays", this.DisabledDays);
        }
    }
}
