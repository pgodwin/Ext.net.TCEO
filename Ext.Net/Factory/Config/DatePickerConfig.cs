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
    public partial class DatePicker
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DatePicker(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DatePicker.Config Conversion to DatePicker
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DatePicker(DatePicker.Config config)
        {
            return new DatePicker(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Component.Config 
        { 
			/*  Implicit DatePicker.Config Conversion to DatePicker.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DatePicker.Builder(DatePicker.Config config)
			{
				return new DatePicker.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
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

			private object value = null;

			/// <summary>
			/// 
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
        
			private object emptyValue = null;

			/// <summary>
			/// The fields null value.
			/// </summary>
			public object EmptyValue
			{
				get
				{
					if (this.emptyValue == null)
					{
						this.emptyValue = new object();
					}
			
					return this.emptyValue;
				}
			}
			
			private bool autoPostBack = false;

			/// <summary>
			/// AutoPostBack
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

			private DateTime selectedDate = new DateTime(0001, 01, 01);

			/// <summary>
			/// Gets or sets the current selected date of the DatePicker. Accepts and returns a DateTime object.
			/// </summary>
			[DefaultValue(typeof(DateTime), "0001-01-01")]
			public virtual DateTime SelectedDate 
			{ 
				get
				{
					return this.selectedDate;
				}
				set
				{
					this.selectedDate = value;
				}
			}
        
			private object selectedValue = null;

			/// <summary>
			/// Gets or sets the current selected date of the DatePicker.
			/// </summary>
			public object SelectedValue
			{
				get
				{
					if (this.selectedValue == null)
					{
						this.selectedValue = new object();
					}
			
					return this.selectedValue;
				}
			}
			
			private string cancelText = "";

			/// <summary>
			/// The text to display on the cancel button.
			/// </summary>
			[DefaultValue("")]
			public virtual string CancelText 
			{ 
				get
				{
					return this.cancelText;
				}
				set
				{
					this.cancelText = value;
				}
			}
        
			private DisabledDateCollection disabledDates = null;

			/// <summary>
			/// An array of \"dates\" to disable, as strings. These strings will be used to build a dynamic regular expression so they are very powerful.
			/// </summary>
			public DisabledDateCollection DisabledDates
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
			
			private string[] dayNames = null;

			/// <summary>
			/// An array of textual day names which can be overriden for localization support (defaults to Date.dayNames).
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] DayNames 
			{ 
				get
				{
					return this.dayNames;
				}
				set
				{
					this.dayNames = value;
				}
			}

			private string disabledDatesRE = "";

			/// <summary>
			/// JavaScript regular expression used to disable a pattern of dates (defaults to null).
			/// </summary>
			[DefaultValue("")]
			public virtual string DisabledDatesRE 
			{ 
				get
				{
					return this.disabledDatesRE;
				}
				set
				{
					this.disabledDatesRE = value;
				}
			}

			private int[] disabledDays = null;

			/// <summary>
			/// An array of days to disable, 0-based. For example, [0, 6] disables Sunday and Saturday (defaults to null).
			/// </summary>
			[DefaultValue(null)]
			public virtual int[] DisabledDays 
			{ 
				get
				{
					return this.disabledDays;
				}
				set
				{
					this.disabledDays = value;
				}
			}

			private string disabledDaysText = "";

			/// <summary>
			/// The tooltip to display when the date falls on a disabled day (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string DisabledDaysText 
			{ 
				get
				{
					return this.disabledDaysText;
				}
				set
				{
					this.disabledDaysText = value;
				}
			}

			private string format = "d";

			/// <summary>
			/// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'm/d/y').
			/// </summary>
			[DefaultValue("d")]
			public virtual string Format 
			{ 
				get
				{
					return this.format;
				}
				set
				{
					this.format = value;
				}
			}

			private DateTime maxDate = new DateTime(9999, 12, 31);

			/// <summary>
			/// The maximum allowed date.
			/// </summary>
			[DefaultValue(typeof(DateTime), "9999-12-31")]
			public virtual DateTime MaxDate 
			{ 
				get
				{
					return this.maxDate;
				}
				set
				{
					this.maxDate = value;
				}
			}

			private string maxText = "";

			/// <summary>
			/// The error text to display when the date in the cell is after MaxValue (defaults to 'The date in this field must be before {MaxValue}').
			/// </summary>
			[DefaultValue("")]
			public virtual string MaxText 
			{ 
				get
				{
					return this.maxText;
				}
				set
				{
					this.maxText = value;
				}
			}

			private DateTime minDate = new DateTime(0001, 01, 01);

			/// <summary>
			/// The minimum allowed date.
			/// </summary>
			[DefaultValue(typeof(DateTime), "0001-01-01")]
			public virtual DateTime MinDate 
			{ 
				get
				{
					return this.minDate;
				}
				set
				{
					this.minDate = value;
				}
			}

			private string minText = "";

			/// <summary>
			/// The error text to display when the date in the cell is before MinValue (defaults to 'The date in this field must be after {MinValue}').
			/// </summary>
			[DefaultValue("")]
			public virtual string MinText 
			{ 
				get
				{
					return this.minText;
				}
				set
				{
					this.minText = value;
				}
			}

			private string[] monthNames = null;

			/// <summary>
			/// An array of textual month names which can be overriden for localization support (defaults to Date.monthNames).
			/// </summary>
			[DefaultValue(null)]
			public virtual string[] MonthNames 
			{ 
				get
				{
					return this.monthNames;
				}
				set
				{
					this.monthNames = value;
				}
			}

			private string monthYearText = "Choose a month (Control+Up/Down to move years)";

			/// <summary>
			/// The header month selector tooltip (defaults to 'Choose a month (Control+Up/Down to move years)').
			/// </summary>
			[DefaultValue("Choose a month (Control+Up/Down to move years)")]
			public virtual string MonthYearText 
			{ 
				get
				{
					return this.monthYearText;
				}
				set
				{
					this.monthYearText = value;
				}
			}

			private string nextText = "Next Month (Control+Right)";

			/// <summary>
			/// The next month navigation button tooltip (defaults to 'Next Month (Control+Right)').
			/// </summary>
			[DefaultValue("Next Month (Control+Right)")]
			public virtual string NextText 
			{ 
				get
				{
					return this.nextText;
				}
				set
				{
					this.nextText = value;
				}
			}

			private string okText = "";

			/// <summary>
			/// The text to display on the ok button.
			/// </summary>
			[DefaultValue("")]
			public virtual string OkText 
			{ 
				get
				{
					return this.okText;
				}
				set
				{
					this.okText = value;
				}
			}

			private string prevText = "Previous Month (Control+Left)";

			/// <summary>
			/// The previous month navigation button tooltip (defaults to 'Previous Month (Control+Left)').
			/// </summary>
			[DefaultValue("Previous Month (Control+Left)")]
			public virtual string PrevText 
			{ 
				get
				{
					return this.prevText;
				}
				set
				{
					this.prevText = value;
				}
			}

			private bool showToday = true;

			/// <summary>
			/// False to hide the footer area containing the Today button and disable the keyboard handler for spacebar that selects the current date (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowToday 
			{ 
				get
				{
					return this.showToday;
				}
				set
				{
					this.showToday = value;
				}
			}

			private int startDay = 0;

			/// <summary>
			/// Day index at which the week should begin, 0-based (defaults to 0, which is Sunday).
			/// </summary>
			[DefaultValue(0)]
			public virtual int StartDay 
			{ 
				get
				{
					return this.startDay;
				}
				set
				{
					this.startDay = value;
				}
			}

			private string todayText = "Today";

			/// <summary>
			/// The text to display on the button that selects the current date (defaults to 'Today').
			/// </summary>
			[DefaultValue("Today")]
			public virtual string TodayText 
			{ 
				get
				{
					return this.todayText;
				}
				set
				{
					this.todayText = value;
				}
			}

			private string todayTip = "{current date} (Spacebar)";

			/// <summary>
			/// The tooltip to display for the button that selects the current date (defaults to '{current date} (Spacebar)').
			/// </summary>
			[DefaultValue("{current date} (Spacebar)")]
			public virtual string TodayTip 
			{ 
				get
				{
					return this.todayTip;
				}
				set
				{
					this.todayTip = value;
				}
			}
        
			private DatePickerListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
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
			        
			private DatePickerDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
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
			
        }
    }
}