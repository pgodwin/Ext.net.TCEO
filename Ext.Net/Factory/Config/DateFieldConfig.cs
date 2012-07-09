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
    public partial class DateField
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DateField(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DateField.Config Conversion to DateField
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DateField(DateField.Config config)
        {
            return new DateField(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : TriggerFieldBase.Config 
        { 
			/*  Implicit DateField.Config Conversion to DateField.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DateField.Builder(DateField.Config config)
			{
				return new DateField.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
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
			[DefaultValue(null)]
			public virtual object SelectedValue 
			{ 
				get
				{
					return this.selectedValue;
				}
				set
				{
					this.selectedValue = value;
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
			        
			private DateFieldListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public DateFieldListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new DateFieldListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private DateFieldDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public DateFieldDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new DateFieldDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
			private string altFormats = "";

			/// <summary>
			/// Multiple date formats separated by \" | \" to try when parsing a user input value and it doesn't match the defined format ('MM/dd/yyyy|MM-dd-yy|MM-dd-yyyy|MM/dd|MM-dd|dd').
			/// </summary>
			[DefaultValue("")]
			public virtual string AltFormats 
			{ 
				get
				{
					return this.altFormats;
				}
				set
				{
					this.altFormats = value;
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
			
			private string disabledDatesText = "";

			/// <summary>
			/// The tooltip text to display when the date falls on a disabled date (defaults to 'Disabled').
			/// </summary>
			[DefaultValue("")]
			public virtual string DisabledDatesText 
			{ 
				get
				{
					return this.disabledDatesText;
				}
				set
				{
					this.disabledDatesText = value;
				}
			}

			private int[] disabledDays = null;

			/// <summary>
			/// An array of days to disable, 0 based. For example, [0, 6] disables Sunday and Saturday (defaults to null).
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
			/// The tooltip to display when the date falls on a disabled day (defaults to 'Disabled').
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
			/// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'd').
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

			private bool showToday = true;

			/// <summary>
			/// False to hide the footer area of the DatePicker containing the Today button and disable the keyboard handler for spacebar that selects the current date (defaults to true).
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

        }
    }
}