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
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net
{
    public abstract partial class CalendarPanelBase
    {
        /// <summary>
        /// 
        /// </summary>
		[Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[XmlIgnore]
        [JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = base.ConfigOptions;
                
                list.Add("dayText", new ConfigOption("dayText", null, "Day", this.DayText ));
                list.Add("monthText", new ConfigOption("monthText", null, "Month", this.MonthText ));
                list.Add("showDayView", new ConfigOption("showDayView", null, true, this.ShowDayView ));
                list.Add("showMonthView", new ConfigOption("showMonthView", null, true, this.ShowMonthView ));
                list.Add("showNavBar", new ConfigOption("showNavBar", null, true, this.ShowNavBar ));
                list.Add("showTime", new ConfigOption("showTime", null, true, this.ShowTime ));
                list.Add("showTodayText", new ConfigOption("showTodayText", null, true, this.ShowTodayText ));
                list.Add("showWeekView", new ConfigOption("showWeekView", null, true, this.ShowWeekView ));
                list.Add("todayText", new ConfigOption("todayText", null, "Today", this.TodayText ));
                list.Add("weekText", new ConfigOption("weekText", null, "Week", this.WeekText ));
                list.Add("groupStoreID", new ConfigOption("groupStoreID", new SerializationOptions("calendarStore", JsonMode.ToClientID), "", this.GroupStoreID ));
                list.Add("groupStore", new ConfigOption("groupStore", new SerializationOptions("calendarStore", typeof(LazyControlJsonConverter)), null, this.GroupStore ));
                list.Add("eventStoreID", new ConfigOption("eventStoreID", new SerializationOptions("eventStore", JsonMode.ToClientID), "", this.EventStoreID ));
                list.Add("eventStore", new ConfigOption("eventStore", new SerializationOptions("eventStore", typeof(LazyControlJsonConverter)), null, this.EventStore ));
                list.Add("dayView", new ConfigOption("dayView", new SerializationOptions("dayViewCfg", typeof(LazyControlJsonConverter)), null, this.DayView ));
                list.Add("weekView", new ConfigOption("weekView", new SerializationOptions("weekViewCfg", typeof(LazyControlJsonConverter)), null, this.WeekView ));
                list.Add("monthView", new ConfigOption("monthView", new SerializationOptions("monthViewCfg", typeof(LazyControlJsonConverter)), null, this.MonthView ));
                list.Add("eventEditForm", new ConfigOption("eventEditForm", new SerializationOptions("editViewCfg", typeof(LazyControlJsonConverter)), null, this.EventEditForm ));
                list.Add("eventEditFormProxy", new ConfigOption("eventEditFormProxy", new SerializationOptions("editViewCfg", JsonMode.Raw), "", this.EventEditFormProxy ));

                return list;
            }
        }
    }
}