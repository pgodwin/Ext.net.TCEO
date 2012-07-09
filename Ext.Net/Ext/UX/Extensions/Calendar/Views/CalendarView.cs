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
    /// <summary>
    /// This is an abstract class that serves as the base for other calendar views. 
    /// This class is not intended to be directly instantiated.
    /// When extending this class to create a custom calendar view, you must provide an implementation 
    /// for the renderItems method, as there is no default implementation for rendering events 
    /// The rendering logic is totally dependent on how the UI structures its data, which is determined 
    /// by the underlying UI template (this base class does not have a template).
    /// </summary>
    public abstract partial class CalendarView : BoxComponentBase
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
        
        /// <summary>
        /// The 0-based index for the day on which the calendar week begins (0=Sunday, which is the default)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. CalendarView")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("The 0-based index for the day on which the calendar week begins (0=Sunday, which is the default)")]
        public virtual int StartDay
        {
            get
            {
                object obj = this.ViewState["StartDay"];
                return obj != null ? (int)obj : 0;
            }
            set
            {
                this.ViewState["StartDay"] = value;
            }
        }

        /// <summary>
        /// The text to display inside the drag proxy while dragging over the calendar to create a new event (defaults to 'Create event for {0}' where {0} is a date range supplied by the view)
        /// </summary>
        [Meta]
        [ConfigOption("ddCreateEventText")]
        [Category("5. CalendarView")]
        [DefaultValue("Create event for {0}")]
        [NotifyParentProperty(true)]
        [Description("The text to display inside the drag proxy while dragging over the calendar to create a new event (defaults to 'Create event for {0}' where {0} is a date range supplied by the view)")]
        public virtual string DDCreateEventText
        {
            get
            {
                return (string)this.ViewState["DDCreateEventText"] ?? "Create event for {0}";
            }
            set
            {
                this.ViewState["DDCreateEventText"] = value;
            }
        }

        /// <summary>
        /// The text to display inside the drag proxy while dragging an event to reposition it (defaults to 'Move event to {0}' where {0} is the updated event start date/time supplied by the view)
        /// </summary>
        [Meta]
        [ConfigOption("ddMoveEventText")]
        [Category("5. CalendarView")]
        [DefaultValue("Move event to {0}")]
        [NotifyParentProperty(true)]
        [Description("The text to display inside the drag proxy while dragging an event to reposition it (defaults to 'Move event to {0}' where {0} is the updated event start date/time supplied by the view)")]
        public virtual string DDMoveEventText
        {
            get
            {
                return (string)this.ViewState["DDMoveEventText"] ?? "Move event to {0}";
            }
            set
            {
                this.ViewState["DDMoveEventText"] = value;
            }
        }

        /// <summary>
        /// The string displayed to the user in the drag proxy while dragging the resize handle of an event (defaults to 'Update event to {0}' where {0} is the updated event start-end range supplied by the view). Note that this text is only used in views that allow resizing of events.
        /// </summary>
        [Meta]
        [ConfigOption("ddResizeEventText")]
        [Category("5. CalendarView")]
        [DefaultValue("Update event to {0}")]
        [NotifyParentProperty(true)]
        [Description("The string displayed to the user in the drag proxy while dragging the resize handle of an event (defaults to 'Update event to {0}' where {0} is the updated event start-end range supplied by the view). Note that this text is only used in views that allow resizing of events.")]
        public virtual string DDResizeEventText
        {
            get
            {
                return (string)this.ViewState["DDResizeEventText"] ?? "Update event to {0}";
            }
            set
            {
                this.ViewState["DDResizeEventText"] = value;
            }
        }

        /// <summary>
        /// True to enable a visual effect on adding a new event (the default), false to disable it. Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doAddFx method.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. CalendarView")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to enable a visual effect on adding a new event (the default), false to disable it. Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doAddFx method.")]
        public virtual bool EnableAddFx
        {
            get
            {
                object obj = this.ViewState["EnableAddFx"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["EnableAddFx"] = value;
            }
        }

        /// <summary>
        /// True to enable drag and drop in the calendar view (the default), false to disable it
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. CalendarView")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to enable drag and drop in the calendar view (the default), false to disable it")]
        public virtual bool EnableDD
        {
            get
            {
                object obj = this.ViewState["EnableDD"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["EnableDD"] = value;
            }
        }

        /// <summary>
        /// Determines whether or not visual effects for CRUD actions are enabled (defaults to true). If this is false it will override any values for enableAddFx, enableUpdateFx or enableRemoveFx and all animations will be disabled.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. CalendarView")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to enable a visual effect on adding a new event (the default), false to disable it. Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doAddFx method.")]
        public virtual bool EnableFx
        {
            get
            {
                object obj = this.ViewState["EnableFx"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["EnableFx"] = value;
            }
        }

        /// <summary>
        /// True to enable a visual effect on removing an event (the default), false to disable it. Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doRemoveFx method.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. CalendarView")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to enable a visual effect on removing an event (the default), false to disable it. Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doRemoveFx method.")]
        public virtual bool EnableRemoveFx
        {
            get
            {
                object obj = this.ViewState["EnableRemoveFx"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["EnableRemoveFx"] = value;
            }
        }

        /// <summary>
        /// True to enable a visual effect on updating an event, false to disable it (the default). Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doUpdateFx method.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. CalendarView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to enable a visual effect on updating an event, false to disable it (the default). Note that if enableFx is false it will override this value. The specific effect that runs is defined in the doUpdateFx method.")]
        public virtual bool EnableUpdateFx
        {
            get
            {
                object obj = this.ViewState["EnableUpdateFx"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["EnableUpdateFx"] = value;
            }
        }

        /// <summary>
        /// True to monitor the browser's resize event (the default), false to ignore it. If the calendar view is rendered into a fixed-size container this can be set to false. However, if the view can change dimensions (e.g., it's in fit layout in a viewport or some other resizable container) it is very important that this config is true so that any resize event propagates properly to all subcomponents and layouts get recalculated properly.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. CalendarView")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to monitor the browser's resize event (the default), false to ignore it. If the calendar view is rendered into a fixed-size container this can be set to false. However, if the view can change dimensions (e.g., it's in fit layout in a viewport or some other resizable container) it is very important that this config is true so that any resize event propagates properly to all subcomponents and layouts get recalculated properly.")]
        public virtual bool MonitorResize
        {
            get
            {
                object obj = this.ViewState["MonitorResize"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["MonitorResize"] = value;
            }
        }

        /// <summary>
        /// Allows switching between two different modes of rendering events that span multiple days. When true, span events are always sorted first, possibly at the expense of start dates being out of order (e.g., a span event that starts at 11am one day and spans into the next day would display before a non-spanning event that starts at 10am, even though they would not be in date order). This can lead to more compact layouts when there are many overlapping events. If false (the default), events will always sort by start date first which can result in a less compact, but chronologically consistent layout.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. CalendarView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Allows switching between two different modes of rendering events that span multiple days. When true, span events are always sorted first, possibly at the expense of start dates being out of order (e.g., a span event that starts at 11am one day and spans into the next day would display before a non-spanning event that starts at 10am, even though they would not be in date order). This can lead to more compact layouts when there are many overlapping events. If false (the default), events will always sort by start date first which can result in a less compact, but chronologically consistent layout.")]
        public virtual bool SpansHavePriority
        {
            get
            {
                object obj = this.ViewState["SpansHavePriority"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["SpansHavePriority"] = value;
            }
        }

        /// <summary>
        /// Whether or not the view tracks and responds to the browser mouseover event on contained elements (defaults to true). If you don't need mouseover event highlighting you can disable this.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. CalendarView")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Whether or not the view tracks and responds to the browser mouseover event on contained elements (defaults to true). If you don't need mouseover event highlighting you can disable this.")]
        public virtual bool TrackMouseOver
        {
            get
            {
                object obj = this.ViewState["TrackMouseOver"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["TrackMouseOver"] = value;
            }
        }

        private JFunction getEventBodyMarkup;

        /// <summary>
        /// Returns a string of HTML template markup to be used as the body portion of the event template created by getEventTemplate. This provdes the flexibility to customize what's in the body without having to override the entire XTemplate. This string can include any valid Ext.Template code, and any data tokens accessible to the containing event template can be referenced in this string.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. CalendarView")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Returns a string of HTML template markup to be used as the body portion of the event template created by getEventTemplate. This provdes the flexibility to customize what's in the body without having to override the entire XTemplate. This string can include any valid Ext.Template code, and any data tokens accessible to the containing event template can be referenced in this string.")]
        public virtual JFunction GetEventBodyMarkup
        {
            get
            {
                if (this.getEventBodyMarkup == null)
                {
                    this.getEventBodyMarkup = new JFunction();
                }

                return this.getEventBodyMarkup;
            }
        }

        private JFunction getEventTemplate;

        /// <summary>
        /// Returns the XTemplate that is bound to the calendar's event store (it expects records of type Ext.calendar.EventRecord) 
        /// to populate the calendar views with events. Internally this method by default generates different markup for browsers 
        /// that support CSS border radius and those that don't. This method can be overridden as needed to customize the markup generated.
        /// Note that this method calls getEventBodyMarkup to retrieve the body markup for events separately from the surrounding 
        /// container markup. This provdes the flexibility to customize what's in the body without having to override the entire XTemplate. 
        /// If you do override this method, you should make sure that your overridden version also does the same.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. CalendarView")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Returns the XTemplate that is bound to the calendar's event store to populate the calendar views with events.")]
        public virtual JFunction GetEventTemplate
        {
            get
            {
                if (this.getEventTemplate == null)
                {
                    this.getEventTemplate = new JFunction();
                }

                return this.getEventTemplate;
            }
        }

        /// <summary>
        /// Visually highlights an event using Ext.Fx.highlight config options. If highlightEventActions is false this method will have no effect.
        /// </summary>
        /// <param name="el">The element(s) to highlight</param>
        /// <param name="color">(optional) The highlight color. Should be a 6 char hex color without the leading # (defaults to yellow: 'ffff9c')</param>
        /// <param name="o">(optional) Object literal with any of the Ext.Fx config options. See Ext.Fx.highlight for usage examples.</param>
        public void HighlightEvent(Element el, string color, HighlightConfig o)
        {
            this.Call("highlightEvent", new JRawValue(el.Descriptor), color, new JRawValue(new ClientConfig().Serialize(o)));
        }

        /// <summary>
        /// Shifts the view by the passed number of days relative to the currently set date
        /// </summary>
        /// <param name="value">The number of days (positive or negative) by which to shift the view</param>
        public void MoveDays(int value)
        {
            this.Call("moveDays", value);
        }

        /// <summary>
        /// Shifts the view by the passed number of months relative to the currently set date
        /// </summary>
        /// <param name="value">The number of months (positive or negative) by which to shift the view</param>
        public void MoveMonths(int value)
        {
            this.Call("moveMonths", value);
        }

        /// <summary>
        /// Updates the view to the next consecutive date(s)
        /// </summary>
        public void MoveNext()
        {
            this.Call("moveNext");
        }

        /// <summary>
        /// Updates the view to the previous consecutive date(s)
        /// </summary>
        public void MovePrev()
        {
            this.Call("movePrev");
        }

        /// <summary>
        /// Updates the view to contain the passed date
        /// </summary>
        /// <param name="dt">The date to display</param>
        public void MoveTo(DateTime dt)
        {
            this.Call("moveTo", dt);
        }

        /// <summary>
        /// Updates the view to show today
        /// </summary>
        public void MoveToday()
        {
            this.Call("moveToday");
        }

        /// <summary>
        /// Shifts the view by the passed number of weeks relative to the currently set date
        /// </summary>
        /// <param name="value">The number of weeks (positive or negative) by which to shift the view</param>
        public void MoveWeeks(int value)
        {
            this.Call("moveWeeks", value);
        }

        /// <summary>
        /// Sets the start date used to calculate the view boundaries to display. The displayed view will be the earliest and latest dates that match the view requirements and contain the date passed to this function.
        /// </summary>
        /// <param name="dt">The date used to calculate the new view boundaries</param>
        public void SetStartDate(DateTime dt)
        {
            this.Call("setStartDate", dt);
        }

    }
}