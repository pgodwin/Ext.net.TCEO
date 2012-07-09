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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class CalendarPanelBase : PanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;

                baseList.Capacity += 2;

                baseList.Add(new ClientScriptItem(typeof(CalendarPanel), "Ext.Net.Build.Ext.Net.ux.extensions.calendar.calendar-all.js", "Ext.Net.Build.Ext.Net.ux.extensions.calendar.calendar-all-debug.js", "/ux/extensions/calendar/calendar-all.js", "/ux/extensions/calendar/calendar-all-debug.js"));
                baseList.Add(new ClientStyleItem(typeof(CalendarPanel), "Ext.Net.Build.Ext.Net.ux.extensions.calendar.resources.css.calendar-embedded.css", "/ux/calendar/resources/css/calendar.css"));

                return baseList;
            }
        }
        
        /// <summary>
        /// Alternate text to use for the 'Day' nav bar button.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. CalendarPanel")]
        [DefaultValue("Day")]
        [NotifyParentProperty(true)]
        [Description("Alternate text to use for the 'Day' nav bar button.")]
        public virtual string DayText
        {
            get
            {
                return (string)this.ViewState["DayText"] ?? "Day";
            }
            set
            {
                this.ViewState["DayText"] = value;
            }
        }

        /// <summary>
        /// Alternate text to use for the 'Month' nav bar button.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. CalendarPanel")]
        [DefaultValue("Month")]
        [NotifyParentProperty(true)]
        [Description("Alternate text to use for the 'Month' nav bar button.")]
        public virtual string MonthText
        {
            get
            {
                return (string)this.ViewState["MonthText"] ?? "Month";
            }
            set
            {
                this.ViewState["MonthText"] = value;
            }
        }

        /// <summary>
        /// True to include the day view (and toolbar button), false to hide them (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. CalendarPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to include the day view (and toolbar button), false to hide them (defaults to true).")]
        public virtual bool ShowDayView 
        {
            get
            {
                object obj = this.ViewState["ShowDayView"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["ShowDayView"] = value;
            }
        }

        /// <summary>
        /// True to include the month view (and toolbar button), false to hide them (defaults to true). If the day and week views are both hidden, the month view will show by default even if this config is false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. CalendarPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to include the month view (and toolbar button), false to hide them (defaults to true). If the day and week views are both hidden, the month view will show by default even if this config is false.")]
        public virtual bool ShowMonthView
        {
            get
            {
                object obj = this.ViewState["ShowMonthView"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["ShowMonthView"] = value;
            }
        }

        /// <summary>
        /// True to display the calendar navigation toolbar, false to hide it (defaults to true). Note that if you hide the default navigation toolbar you'll have to provide an alternate means of navigating the calendar.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. CalendarPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to display the calendar navigation toolbar, false to hide it (defaults to true). Note that if you hide the default navigation toolbar you'll have to provide an alternate means of navigating the calendar.")]
        public virtual bool ShowNavBar
        {
            get
            {
                object obj = this.ViewState["ShowNavBar"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["ShowNavBar"] = value;
            }
        }

        /// <summary>
        /// True to display the current time next to the date in the calendar's current day box, false to not show it (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. CalendarPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to display the current time next to the date in the calendar's current day box, false to not show it (defaults to true).")]
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
        /// True to show the value of todayText instead of today's date in the calendar's current day box, false to display the day number(defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. CalendarPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to show the value of todayText instead of today's date in the calendar's current day box, false to display the day number(defaults to true).")]
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
        /// True to include the week view (and toolbar button), false to hide them (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. CalendarPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to include the week view (and toolbar button), false to hide them (defaults to true).")]
        public virtual bool ShowWeekView
        {
            get
            {
                object obj = this.ViewState["ShowWeekView"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["ShowWeekView"] = value;
            }
        }

        /// <summary>
        /// Alternate text to use for the 'Today' nav bar button.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. CalendarPanel")]
        [DefaultValue("Today")]
        [NotifyParentProperty(true)]
        [Description("Alternate text to use for the 'Today' nav bar button.")]
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
        /// Alternate text to use for the 'Week' nav bar button.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. CalendarPanel")]
        [DefaultValue("Week")]
        [NotifyParentProperty(true)]
        [Description("Alternate text to use for the 'Week' nav bar button.")]
        public virtual string WeekText
        {
            get
            {
                return (string)this.ViewState["WeekText"] ?? "Week";
            }
            set
            {
                this.ViewState["WeekText"] = value;
            }
        }

        /// <summary>
        /// The group store ID to use.
        /// </summary>
        [Meta]
        [ConfigOption("calendarStore", JsonMode.ToClientID)]
        [Category("7. CalendarPanel")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [Description("The group store ID to use.")]
        public virtual string GroupStoreID
        {
            get
            {
                return (string)this.ViewState["GroupStoreID"] ?? "";
            }
            set
            {
                this.ViewState["GroupStoreID"] = value;
            }
        }
        
        private GroupStore groupStore;
        
        [Category("7. CalendarPanel")]
        [ConfigOption("calendarStore", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        [DefaultValue(null)]
        public virtual GroupStore GroupStore
        {
            get
            {
                return this.groupStore;
            }
            set
            {
                this.ClearWidget(this.groupStore);
                this.groupStore = value;
                this.AfterWidgetAdd(this.groupStore);
            }
        }

        /// <summary>
        /// The event store ID to use.
        /// </summary>
        [Meta]
        [ConfigOption("eventStore", JsonMode.ToClientID)]
        [Category("7. CalendarPanel")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [Description("The event store ID to use.")]
        public virtual string EventStoreID
        {
            get
            {
                return (string)this.ViewState["EventStoreID"] ?? "";
            }
            set
            {
                this.ViewState["EventStoreID"] = value;
            }
        }

        private EventStore eventStore;
        
        [Category("7. CalendarPanel")]
        [ConfigOption("eventStore", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        [DefaultValue(null)]
        public virtual EventStore EventStore
        {
            get
            {
                return this.eventStore;
            }
            set
            {
                this.ClearWidget(this.eventStore);
                this.eventStore = value;
                this.AfterWidgetAdd(this.eventStore);
            }
        }

        private DayView dayView;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("dayViewCfg", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DefaultValue(null)]
        [Description("")]
        public virtual DayView DayView
        {
            get
            {
                return this.dayView;
            }
            set
            {
                this.ClearWidget(this.dayView);
                this.dayView = value;
                this.AfterWidgetAdd(this.dayView);
            }
        }

        private WeekView weekView;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("weekViewCfg", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DefaultValue(null)]
        [Description("")]
        public virtual WeekView WeekView
        {
            get
            {
                return this.weekView;
            }
            set
            {
                this.ClearWidget(this.weekView);
                this.weekView = value;
                this.AfterWidgetAdd(this.weekView);
            }
        }

        private MonthView monthView;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("monthViewCfg", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DefaultValue(null)]
        [Description("")]
        public virtual MonthView MonthView
        {
            get
            {                
                return this.monthView;
            }
            set
            {
                this.ClearWidget(this.monthView);
                this.monthView = value;
                this.AfterWidgetAdd(this.monthView);
            }
        }

        private EventEditForm eventEditForm;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("editViewCfg", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DefaultValue(null)]
        [Description("")]
        public virtual EventEditForm EventEditForm
        {
            get
            {
                return this.eventEditForm;
            }
            set
            {
                this.ClearWidget(this.eventEditForm);
                this.eventEditForm = value;
                this.eventEditForm.CalendarPanel = this;
                this.AfterWidgetAdd(this.eventEditForm);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("editViewCfg", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string EventEditFormProxy
        {
            get
            {
                if (this.EventEditForm != null || !this.IsInForm)
                {
                    return "";
                }

                return "{renderFormElement : false}";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void ClearWidget(Observable item)
        {
            if (item != null && this.Controls.Contains(item))
            {
                this.LazyItems.Remove(item);
                this.Controls.Remove(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void AfterWidgetAdd(Observable item)
        {
            this.LazyItems.Add(item);            
            this.Controls.Add(item);            
        }        

        /* Methods */

        /// <summary>
        /// Hides the built-in event edit form and returns to the previous calendar view. If the edit form is not currently visible this method has no effect.
        /// </summary>
        public void HideEditForm()
        {
            this.Call("hideEditForm");
        }

        /// <summary>
        /// Sets the start date for the currently-active calendar view.
        /// </summary>
        /// <param name="dt">start date</param>
        public void SetStartDate(DateTime dt)
        {
            this.Call("setStartDate", dt);
        }

        /// <summary>
        /// Shows the built-in event edit form for the passed in event record. This method automatically hides the calendar views and navigation toolbar. To return to the calendar, call hideEditForm.
        /// </summary>
        /// <param name="id">The event record id to edit</param>
        public void ShowEditForm(object id)
        {
            this.Call("showEditForm", new JRawValue("this.eventStore.getById({0})".FormatWith(JSON.Serialize(id))));
        }

        /// <summary>
        /// Shows the built-in event edit form for the passed in event record. This method automatically hides the calendar views and navigation toolbar. To return to the calendar, call hideEditForm.
        /// </summary>
        /// <param name="id">The event record index to edit</param>
        public void ShowEditForm(int index)
        {
            this.Call("showEditForm", new JRawValue("this.eventStore.getAt({0})".FormatWith(index)));
        }
    }
}