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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : TriggerFieldBase.Builder<DateField, DateField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DateField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DateField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DateField.Config config) : base(new DateField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DateField component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Gets or sets the current selected date of the DatePicker. Accepts and returns a DateTime object.
			/// </summary>
            public virtual DateField.Builder SelectedDate(DateTime selectedDate)
            {
                this.ToComponent().SelectedDate = selectedDate;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// Gets or sets the current selected date of the DatePicker.
			/// </summary>
            public virtual DateField.Builder SelectedValue(object selectedValue)
            {
                this.ToComponent().SelectedValue = selectedValue;
                return this as DateField.Builder;
            }
             
 			// /// <summary>
			// /// The fields null value.
			// /// </summary>
            // public virtual TBuilder EmptyValue(object emptyValue)
            // {
            //    this.ToComponent().EmptyValue = emptyValue;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(DateFieldListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(DateFieldDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// Multiple date formats separated by \" | \" to try when parsing a user input value and it doesn't match the defined format ('MM/dd/yyyy|MM-dd-yy|MM-dd-yyyy|MM/dd|MM-dd|dd').
			/// </summary>
            public virtual DateField.Builder AltFormats(string altFormats)
            {
                this.ToComponent().AltFormats = altFormats;
                return this as DateField.Builder;
            }
             
 			// /// <summary>
			// /// An array of \"dates\" to disable, as strings. These strings will be used to build a dynamic regular expression so they are very powerful.
			// /// </summary>
            // public virtual TBuilder DisabledDates(DisabledDateCollection disabledDates)
            // {
            //    this.ToComponent().DisabledDates = disabledDates;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The tooltip text to display when the date falls on a disabled date (defaults to 'Disabled').
			/// </summary>
            public virtual DateField.Builder DisabledDatesText(string disabledDatesText)
            {
                this.ToComponent().DisabledDatesText = disabledDatesText;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// An array of days to disable, 0 based. For example, [0, 6] disables Sunday and Saturday (defaults to null).
			/// </summary>
            public virtual DateField.Builder DisabledDays(int[] disabledDays)
            {
                this.ToComponent().DisabledDays = disabledDays;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// The tooltip to display when the date falls on a disabled day (defaults to 'Disabled').
			/// </summary>
            public virtual DateField.Builder DisabledDaysText(string disabledDaysText)
            {
                this.ToComponent().DisabledDaysText = disabledDaysText;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'd').
			/// </summary>
            public virtual DateField.Builder Format(string format)
            {
                this.ToComponent().Format = format;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// The error text to display when the date in the cell is after MaxValue (defaults to 'The date in this field must be before {MaxValue}').
			/// </summary>
            public virtual DateField.Builder MaxText(string maxText)
            {
                this.ToComponent().MaxText = maxText;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// The maximum allowed date.
			/// </summary>
            public virtual DateField.Builder MaxDate(DateTime maxDate)
            {
                this.ToComponent().MaxDate = maxDate;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// The error text to display when the date in the cell is before MinValue (defaults to 'The date in this field must be after {MinValue}').
			/// </summary>
            public virtual DateField.Builder MinText(string minText)
            {
                this.ToComponent().MinText = minText;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// The minimum allowed date.
			/// </summary>
            public virtual DateField.Builder MinDate(DateTime minDate)
            {
                this.ToComponent().MinDate = minDate;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// False to hide the footer area of the DatePicker containing the Today button and disable the keyboard handler for spacebar that selects the current date (defaults to true).
			/// </summary>
            public virtual DateField.Builder ShowToday(bool showToday)
            {
                this.ToComponent().ShowToday = showToday;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// The text to display on the cancel button.
			/// </summary>
            public virtual DateField.Builder CancelText(string cancelText)
            {
                this.ToComponent().CancelText = cancelText;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// An array of textual day names which can be overriden for localization support (defaults to Date.dayNames).
			/// </summary>
            public virtual DateField.Builder DayNames(string[] dayNames)
            {
                this.ToComponent().DayNames = dayNames;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// An array of textual month names which can be overriden for localization support (defaults to Date.monthNames).
			/// </summary>
            public virtual DateField.Builder MonthNames(string[] monthNames)
            {
                this.ToComponent().MonthNames = monthNames;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// The header month selector tooltip (defaults to 'Choose a month (Control+Up/Down to move years)').
			/// </summary>
            public virtual DateField.Builder MonthYearText(string monthYearText)
            {
                this.ToComponent().MonthYearText = monthYearText;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// The next month navigation button tooltip (defaults to 'Next Month (Control+Right)').
			/// </summary>
            public virtual DateField.Builder NextText(string nextText)
            {
                this.ToComponent().NextText = nextText;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// The text to display on the ok button.
			/// </summary>
            public virtual DateField.Builder OkText(string okText)
            {
                this.ToComponent().OkText = okText;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// The previous month navigation button tooltip (defaults to 'Previous Month (Control+Left)').
			/// </summary>
            public virtual DateField.Builder PrevText(string prevText)
            {
                this.ToComponent().PrevText = prevText;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// Day index at which the week should begin, 0-based (defaults to 0, which is Sunday).
			/// </summary>
            public virtual DateField.Builder StartDay(int startDay)
            {
                this.ToComponent().StartDay = startDay;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// The text to display on the button that selects the current date (defaults to 'Today').
			/// </summary>
            public virtual DateField.Builder TodayText(string todayText)
            {
                this.ToComponent().TodayText = todayText;
                return this as DateField.Builder;
            }
             
 			/// <summary>
			/// The tooltip to display for the button that selects the current date (defaults to '{current date} (Spacebar)').
			/// </summary>
            public virtual DateField.Builder TodayTip(string todayTip)
            {
                this.ToComponent().TodayTip = todayTip;
                return this as DateField.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public DateField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DateField(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DateField.Builder DateField()
        {
            return this.DateField(new DateField());
        }

        /// <summary>
        /// 
        /// </summary>
        public DateField.Builder DateField(DateField component)
        {
            return new DateField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DateField.Builder DateField(DateField.Config config)
        {
            return new DateField.Builder(new DateField(config));
        }
    }
}