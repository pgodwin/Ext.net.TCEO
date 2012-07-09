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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Component.Builder<DatePicker, DatePicker.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DatePicker()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DatePicker component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DatePicker.Config config) : base(new DatePicker(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DatePicker component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// (optional) The name of the field in the grid's Ext.data.Store's Ext.data.Record definition from which to draw the column's value.
			/// </summary>
            public virtual DatePicker.Builder DataIndex(string dataIndex)
            {
                this.ToComponent().DataIndex = dataIndex;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// True to hide the label when the field hide
			/// </summary>
            public virtual DatePicker.Builder HideWithLabel(bool hideWithLabel)
            {
                this.ToComponent().HideWithLabel = hideWithLabel;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// True to mark the field as readOnly in HTML (defaults to false) -- Note: this only sets the element's readOnly DOM attribute.
			/// </summary>
            public virtual DatePicker.Builder ReadOnly(bool readOnly)
            {
                this.ToComponent().ReadOnly = readOnly;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The note.
			/// </summary>
            public virtual DatePicker.Builder Note(string note)
            {
                this.ToComponent().Note = note;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The note css class.
			/// </summary>
            public virtual DatePicker.Builder NoteCls(string noteCls)
            {
                this.ToComponent().NoteCls = noteCls;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// Note align
			/// </summary>
            public virtual DatePicker.Builder NoteAlign(NoteAlign noteAlign)
            {
                this.ToComponent().NoteAlign = noteAlign;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual DatePicker.Builder Value(object value)
            {
                this.ToComponent().Value = value;
                return this as DatePicker.Builder;
            }
             
 			// /// <summary>
			// /// The fields null value.
			// /// </summary>
            // public virtual TBuilder EmptyValue(object emptyValue)
            // {
            //    this.ToComponent().EmptyValue = emptyValue;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// AutoPostBack
			/// </summary>
            public virtual DatePicker.Builder AutoPostBack(bool autoPostBack)
            {
                this.ToComponent().AutoPostBack = autoPostBack;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
			/// </summary>
            public virtual DatePicker.Builder CausesValidation(bool causesValidation)
            {
                this.ToComponent().CausesValidation = causesValidation;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// Gets or Sets the Controls ValidationGroup
			/// </summary>
            public virtual DatePicker.Builder ValidationGroup(string validationGroup)
            {
                this.ToComponent().ValidationGroup = validationGroup;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// Gets or sets the current selected date of the DatePicker. Accepts and returns a DateTime object.
			/// </summary>
            public virtual DatePicker.Builder SelectedDate(DateTime selectedDate)
            {
                this.ToComponent().SelectedDate = selectedDate;
                return this as DatePicker.Builder;
            }
             
 			// /// <summary>
			// /// Gets or sets the current selected date of the DatePicker.
			// /// </summary>
            // public virtual TBuilder SelectedValue(object selectedValue)
            // {
            //    this.ToComponent().SelectedValue = selectedValue;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The text to display on the cancel button.
			/// </summary>
            public virtual DatePicker.Builder CancelText(string cancelText)
            {
                this.ToComponent().CancelText = cancelText;
                return this as DatePicker.Builder;
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
			/// An array of textual day names which can be overriden for localization support (defaults to Date.dayNames).
			/// </summary>
            public virtual DatePicker.Builder DayNames(string[] dayNames)
            {
                this.ToComponent().DayNames = dayNames;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// JavaScript regular expression used to disable a pattern of dates (defaults to null).
			/// </summary>
            public virtual DatePicker.Builder DisabledDatesRE(string disabledDatesRE)
            {
                this.ToComponent().DisabledDatesRE = disabledDatesRE;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// An array of days to disable, 0-based. For example, [0, 6] disables Sunday and Saturday (defaults to null).
			/// </summary>
            public virtual DatePicker.Builder DisabledDays(int[] disabledDays)
            {
                this.ToComponent().DisabledDays = disabledDays;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The tooltip to display when the date falls on a disabled day (defaults to '').
			/// </summary>
            public virtual DatePicker.Builder DisabledDaysText(string disabledDaysText)
            {
                this.ToComponent().DisabledDaysText = disabledDaysText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'm/d/y').
			/// </summary>
            public virtual DatePicker.Builder Format(string format)
            {
                this.ToComponent().Format = format;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The maximum allowed date.
			/// </summary>
            public virtual DatePicker.Builder MaxDate(DateTime maxDate)
            {
                this.ToComponent().MaxDate = maxDate;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The error text to display when the date in the cell is after MaxValue (defaults to 'The date in this field must be before {MaxValue}').
			/// </summary>
            public virtual DatePicker.Builder MaxText(string maxText)
            {
                this.ToComponent().MaxText = maxText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The minimum allowed date.
			/// </summary>
            public virtual DatePicker.Builder MinDate(DateTime minDate)
            {
                this.ToComponent().MinDate = minDate;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The error text to display when the date in the cell is before MinValue (defaults to 'The date in this field must be after {MinValue}').
			/// </summary>
            public virtual DatePicker.Builder MinText(string minText)
            {
                this.ToComponent().MinText = minText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// An array of textual month names which can be overriden for localization support (defaults to Date.monthNames).
			/// </summary>
            public virtual DatePicker.Builder MonthNames(string[] monthNames)
            {
                this.ToComponent().MonthNames = monthNames;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The header month selector tooltip (defaults to 'Choose a month (Control+Up/Down to move years)').
			/// </summary>
            public virtual DatePicker.Builder MonthYearText(string monthYearText)
            {
                this.ToComponent().MonthYearText = monthYearText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The next month navigation button tooltip (defaults to 'Next Month (Control+Right)').
			/// </summary>
            public virtual DatePicker.Builder NextText(string nextText)
            {
                this.ToComponent().NextText = nextText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The text to display on the ok button.
			/// </summary>
            public virtual DatePicker.Builder OkText(string okText)
            {
                this.ToComponent().OkText = okText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The previous month navigation button tooltip (defaults to 'Previous Month (Control+Left)').
			/// </summary>
            public virtual DatePicker.Builder PrevText(string prevText)
            {
                this.ToComponent().PrevText = prevText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// False to hide the footer area containing the Today button and disable the keyboard handler for spacebar that selects the current date (defaults to true).
			/// </summary>
            public virtual DatePicker.Builder ShowToday(bool showToday)
            {
                this.ToComponent().ShowToday = showToday;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// Day index at which the week should begin, 0-based (defaults to 0, which is Sunday).
			/// </summary>
            public virtual DatePicker.Builder StartDay(int startDay)
            {
                this.ToComponent().StartDay = startDay;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The text to display on the button that selects the current date (defaults to 'Today').
			/// </summary>
            public virtual DatePicker.Builder TodayText(string todayText)
            {
                this.ToComponent().TodayText = todayText;
                return this as DatePicker.Builder;
            }
             
 			/// <summary>
			/// The tooltip to display for the button that selects the current date (defaults to '{current date} (Spacebar)').
			/// </summary>
            public virtual DatePicker.Builder TodayTip(string todayTip)
            {
                this.ToComponent().TodayTip = todayTip;
                return this as DatePicker.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(DatePickerListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side Ajax Event Handlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(DatePickerDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Clear the value of this field.
			/// </summary>
            public virtual DatePicker.Builder Clear()
            {
                this.ToComponent().Clear();
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public DatePicker.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DatePicker(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DatePicker.Builder DatePicker()
        {
            return this.DatePicker(new DatePicker());
        }

        /// <summary>
        /// 
        /// </summary>
        public DatePicker.Builder DatePicker(DatePicker component)
        {
            return new DatePicker.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DatePicker.Builder DatePicker(DatePicker.Config config)
        {
            return new DatePicker.Builder(new DatePicker(config));
        }
    }
}