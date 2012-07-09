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
    public partial class DateField
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
                
                list.Add("valueProxy", new ConfigOption("valueProxy", new SerializationOptions("value", typeof(CtorDateTimeJsonConverter)), null, this.ValueProxy ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));
                list.Add("altFormatsProxy", new ConfigOption("altFormatsProxy", new SerializationOptions("altFormats"), "", this.AltFormatsProxy ));
                list.Add("disabledDatesProxy", new ConfigOption("disabledDatesProxy", new SerializationOptions("disabledDates", JsonMode.Raw), "", this.DisabledDatesProxy ));
                list.Add("disabledDatesText", new ConfigOption("disabledDatesText", null, "", this.DisabledDatesText ));
                list.Add("disabledDays", new ConfigOption("disabledDays", new SerializationOptions(typeof(IntArrayJsonConverter)), null, this.DisabledDays ));
                list.Add("disabledDaysText", new ConfigOption("disabledDaysText", null, "", this.DisabledDaysText ));
                list.Add("formatProxy", new ConfigOption("formatProxy", new SerializationOptions("format"), "", this.FormatProxy ));
                list.Add("maxText", new ConfigOption("maxText", null, "", this.MaxText ));
                list.Add("maxDate", new ConfigOption("maxDate", new SerializationOptions("maxValue", typeof(CtorDateTimeJsonConverter)), new DateTime(9999, 12, 31), this.MaxDate ));
                list.Add("minText", new ConfigOption("minText", null, "", this.MinText ));
                list.Add("minDate", new ConfigOption("minDate", new SerializationOptions("minValue", typeof(CtorDateTimeJsonConverter)), new DateTime(0001, 01, 01), this.MinDate ));
                list.Add("showToday", new ConfigOption("showToday", null, true, this.ShowToday ));
                list.Add("cancelText", new ConfigOption("cancelText", null, "", this.CancelText ));
                list.Add("dayNames", new ConfigOption("dayNames", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.DayNames ));
                list.Add("monthNames", new ConfigOption("monthNames", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.MonthNames ));
                list.Add("monthYearText", new ConfigOption("monthYearText", null, "Choose a month (Control+Up/Down to move years)", this.MonthYearText ));
                list.Add("nextText", new ConfigOption("nextText", null, "Next Month (Control+Right)", this.NextText ));
                list.Add("okText", new ConfigOption("okText", null, "", this.OkText ));
                list.Add("prevText", new ConfigOption("prevText", null, "Previous Month (Control+Left)", this.PrevText ));
                list.Add("startDay", new ConfigOption("startDay", null, 0, this.StartDay ));
                list.Add("todayText", new ConfigOption("todayText", null, "Today", this.TodayText ));
                list.Add("todayTip", new ConfigOption("todayTip", null, "{current date} (Spacebar)", this.TodayTip ));

                return list;
            }
        }
    }
}