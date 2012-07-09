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
    public partial class CalendarPanelListeners
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
                
                list.Add("dateChange", new ConfigOption("dateChange", new SerializationOptions("datechange", typeof(ListenerJsonConverter)), null, this.DateChange ));
                list.Add("dayClick", new ConfigOption("dayClick", new SerializationOptions("dayclick", typeof(ListenerJsonConverter)), null, this.DayClick ));
                list.Add("eventAdd", new ConfigOption("eventAdd", new SerializationOptions("eventadd", typeof(ListenerJsonConverter)), null, this.EventAdd ));
                list.Add("eventCancel", new ConfigOption("eventCancel", new SerializationOptions("eventcancel", typeof(ListenerJsonConverter)), null, this.EventCancel ));
                list.Add("eventClick", new ConfigOption("eventClick", new SerializationOptions("eventclick", typeof(ListenerJsonConverter)), null, this.EventClick ));
                list.Add("eventDelete", new ConfigOption("eventDelete", new SerializationOptions("eventdelete", typeof(ListenerJsonConverter)), null, this.EventDelete ));
                list.Add("eventMove", new ConfigOption("eventMove", new SerializationOptions("eventmove", typeof(ListenerJsonConverter)), null, this.EventMove ));
                list.Add("eventOut", new ConfigOption("eventOut", new SerializationOptions("eventout", typeof(ListenerJsonConverter)), null, this.EventOut ));
                list.Add("eventOver", new ConfigOption("eventOver", new SerializationOptions("eventover", typeof(ListenerJsonConverter)), null, this.EventOver ));
                list.Add("eventResize", new ConfigOption("eventResize", new SerializationOptions("eventresize", typeof(ListenerJsonConverter)), null, this.EventResize ));
                list.Add("eventsRendered", new ConfigOption("eventsRendered", new SerializationOptions("eventsrendered", typeof(ListenerJsonConverter)), null, this.EventsRendered ));
                list.Add("eventUpdate", new ConfigOption("eventUpdate", new SerializationOptions("eventupdate", typeof(ListenerJsonConverter)), null, this.EventUpdate ));
                list.Add("initDrag", new ConfigOption("initDrag", new SerializationOptions("initdrag", typeof(ListenerJsonConverter)), null, this.InitDrag ));
                list.Add("rangeSelect", new ConfigOption("rangeSelect", new SerializationOptions("rangeselect", typeof(ListenerJsonConverter)), null, this.RangeSelect ));
                list.Add("viewChange", new ConfigOption("viewChange", new SerializationOptions("viewchange", typeof(ListenerJsonConverter)), null, this.ViewChange ));

                return list;
            }
        }
    }
}