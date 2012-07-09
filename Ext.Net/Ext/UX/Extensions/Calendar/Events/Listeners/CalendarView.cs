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
using System.Web.UI;

namespace Ext.Net
{
    public partial class CalendarViewListeners : BoxComponentListeners
    {

        /// <summary>
        /// 
        /// </summary>
        public override ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get
            {
                return CalendarPanel.ConfigOptionsEngine;
            }
        }

        private ComponentListener dateChange;

        /// <summary>
        /// Fires after the start date of the view changes
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarView), "Ext.calendar.CalendarView")]
        [ListenerArgument(1, "startDate", typeof(DateTime), "The start date of the view")]
        [ListenerArgument(2, "viewStart", typeof(DateTime), "The first displayed date in the view")]
        [ListenerArgument(3, "viewEnd", typeof(DateTime), "The last displayed date in the view")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("datechange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the start date of the view changes")]
        public virtual ComponentListener DateChange
        {
            get
            {
                if (this.dateChange == null)
                {
                    this.dateChange = new ComponentListener();
                }

                return this.dateChange;
            }
        }

        private ComponentListener dayOut;

        /// <summary>
        /// Fires when the mouse exits a day element
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarView), "Ext.calendar.CalendarView")]
        [ListenerArgument(1, "date", typeof(DateTime), "The date that is exited")]
        [ListenerArgument(2, "el", typeof(Element), "The day Element that is exited")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dayout", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the mouse exits a day element")]
        public virtual ComponentListener DayOut
        {
            get
            {
                if (this.dayOut == null)
                {
                    this.dayOut = new ComponentListener();
                }

                return this.dayOut;
            }
        }

        private ComponentListener dayOver;

        /// <summary>
        /// Fires while the mouse is over a day element
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarView), "Ext.calendar.CalendarView")]
        [ListenerArgument(1, "date", typeof(DateTime), "The date that is being moused over")]
        [ListenerArgument(2, "el", typeof(Element), "The day Element that is being moused over")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dayover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires while the mouse is over a day element")]
        public virtual ComponentListener DayOver
        {
            get
            {
                if (this.dayOver == null)
                {
                    this.dayOver = new ComponentListener();
                }

                return this.dayOver;
            }
        }



        private ComponentListener eventClick;

        /// <summary>
        /// Fires after the user clicks on an event element
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarView), "Ext.calendar.CalendarView")]
        [ListenerArgument(1, "record", typeof(object), "The record for the event that was clicked on")]
        [ListenerArgument(2, "el", typeof(object), "The DOM node that was clicked on")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the user clicks on an event element")]
        public virtual ComponentListener EventClick
        {
            get
            {
                if (this.eventClick == null)
                {
                    this.eventClick = new ComponentListener();
                }

                return this.eventClick;
            }
        }

        private ComponentListener eventMove;

        /// <summary>
        /// Fires after an event element is dragged by the user and dropped in a new position
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarView), "Ext.calendar.CalendarView")]
        [ListenerArgument(1, "record", typeof(object), "The record for the event that was moved with updated start and end dates")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventmove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after an event element is dragged by the user and dropped in a new position")]
        public virtual ComponentListener EventMove
        {
            get
            {
                if (this.eventMove == null)
                {
                    this.eventMove = new ComponentListener();
                }

                return this.eventMove;
            }
        }

        private ComponentListener eventOut;

        /// <summary>
        /// Fires anytime the mouse exits an event element
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarView), "Ext.calendar.CalendarView")]
        [ListenerArgument(1, "record", typeof(object), "The record for the event that the cursor exited")]
        [ListenerArgument(2, "el", typeof(object), "The DOM node that was exited")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventout", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires anytime the mouse exits an event element")]
        public virtual ComponentListener EventOut
        {
            get
            {
                if (this.eventOut == null)
                {
                    this.eventOut = new ComponentListener();
                }

                return this.eventOut;
            }
        }

        private ComponentListener eventOver;

        /// <summary>
        /// Fires anytime the mouse is over an event element
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarView), "Ext.calendar.CalendarView")]
        [ListenerArgument(1, "record", typeof(object), "The record for the event that the cursor is over")]
        [ListenerArgument(2, "el", typeof(object), "The DOM node that is being moused over")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires anytime the mouse is over an event element")]
        public virtual ComponentListener EventOver
        {
            get
            {
                if (this.eventOver == null)
                {
                    this.eventOver = new ComponentListener();
                }

                return this.eventOver;
            }
        }

        private ComponentListener eventsRendered;

        /// <summary>
        /// Fires after events are finished rendering in the view
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarView), "Ext.calendar.CalendarView")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("eventsrendered", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after events are finished rendering in the view")]
        public virtual ComponentListener EventsRendered
        {
            get
            {
                if (this.eventsRendered == null)
                {
                    this.eventsRendered = new ComponentListener();
                }

                return this.eventsRendered;
            }
        }

        private ComponentListener initDrag;

        /// <summary>
        /// Fires when a drag operation is initiated in the view
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarView), "Ext.calendar.CalendarView")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("initdrag", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a drag operation is initiated in the view")]
        public virtual ComponentListener InitDrag
        {
            get
            {
                if (this.initDrag == null)
                {
                    this.initDrag = new ComponentListener();
                }

                return this.initDrag;
            }
        }

        private ComponentListener rangeSelect;

        /// <summary>
        /// Fires after the user drags on the calendar to select a range of dates/times in which to create an event
        /// </summary>
        [ListenerArgument(0, "item", typeof(CalendarView), "Ext.calendar.CalendarView")]
        [ListenerArgument(1, "dates", typeof(object), "An object containing the start (StartDate property) and end (EndDate property) dates selected")]
        [ListenerArgument(2, "callback", typeof(JFunction), "A callback function that MUST be called after the event handling is complete so that the view is properly cleaned up (shim elements are persisted in the view while the user is prompted to handle the range selection). The callback is already created in the proper scope, so it simply needs to be executed as a standard function call (e.g., callback()).")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rangeselect", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the user drags on the calendar to select a range of dates/times in which to create an event")]
        public virtual ComponentListener RangeSelect
        {
            get
            {
                if (this.rangeSelect == null)
                {
                    this.rangeSelect = new ComponentListener();
                }

                return this.rangeSelect;
            }
        }
    }
}