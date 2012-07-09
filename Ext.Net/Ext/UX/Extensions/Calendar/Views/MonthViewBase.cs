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

using System.ComponentModel;

namespace Ext.Net
{
    public abstract partial class MonthViewBase : CalendarView
    {
        /// <summary>
        /// True to display a header beneath the navigation bar containing the week names above each week's column, false not to show it and instead display the week names in the first row of days in the calendar (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MonthView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to display a header beneath the navigation bar containing the week names above each week's column, false not to show it and instead display the week names in the first row of days in the calendar (defaults to false).")]
        public virtual bool ShowHeader
        {
            get
            {
                object obj = this.ViewState["ShowHeader"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["ShowHeader"] = value;
            }
        }

        /// <summary>
        /// True to display the current time in today's box in the calendar, false to not display it (defautls to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MonthView")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to display the current time in today's box in the calendar, false to not display it (defautls to true)")]
        public virtual bool ShowTime
        {
            get
            {
                object obj = this.ViewState["ShowTime"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["ShowTime"] = value;
            }
        }

        /// <summary>
        /// True to display the todayText string in today's box in the calendar, false to not display it (defautls to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MonthView")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to display the todayText string in today's box in the calendar, false to not display it (defautls to true)")]
        public virtual bool ShowTodayText
        {
            get
            {
                object obj = this.ViewState["ShowTodayText"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["ShowTodayText"] = value;
            }
        }

        /// <summary>
        /// True to display an extra column before the first day in the calendar that links to the view for each individual week, false to not show it (defaults to false). If true, the week links can also contain the week number depending on the value of showWeekNumbers.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MonthView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to display an extra column before the first day in the calendar that links to the view for each individual week, false to not show it (defaults to false). If true, the week links can also contain the week number depending on the value of showWeekNumbers.")]
        public virtual bool ShowWeekLinks
        {
            get
            {
                object obj = this.ViewState["ShowWeekLinks"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["ShowWeekLinks"] = value;
            }
        }

        /// <summary>
        /// True to show the week number for each week in the calendar in the week link column, false to show nothing (defaults to false). Note that if showWeekLinks is false this config will have no affect even if true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MonthView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to show the week number for each week in the calendar in the week link column, false to show nothing (defaults to false). Note that if showWeekLinks is false this config will have no affect even if true.")]
        public virtual bool ShowWeekNumbers
        {
            get
            {
                object obj = this.ViewState["ShowWeekNumbers"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["ShowWeekNumbers"] = value;
            }
        }

        /// <summary>
        /// The text to display in the current day's box in the calendar when showTodayText is true (defaults to 'Today')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MonthView")]
        [DefaultValue("Today")]
        [NotifyParentProperty(true)]
        [Description("The text to display in the current day's box in the calendar when showTodayText is true (defaults to 'Today')")]
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
        /// The CSS class name applied when the mouse moves over a week link element (only applies when showWeekLinks is true, defaults to 'ext-week-link-over').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MonthView")]
        [DefaultValue("ext-week-link-over")]
        [NotifyParentProperty(true)]
        [Description("The CSS class name applied when the mouse moves over a week link element (only applies when showWeekLinks is true, defaults to 'ext-week-link-over').")]
        public virtual string WeekLinkOverClass
        {
            get
            {
                return (string)this.ViewState["WeekLinkOverClass"] ?? "ext-week-link-over";
            }
            set
            {
                this.ViewState["WeekLinkOverClass"] = value;
            }
        }
    }
}