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
    public abstract partial class CalendarView
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
                
                list.Add("startDay", new ConfigOption("startDay", null, 0, this.StartDay ));
                list.Add("dDCreateEventText", new ConfigOption("dDCreateEventText", new SerializationOptions("ddCreateEventText"), "Create event for {0}", this.DDCreateEventText ));
                list.Add("dDMoveEventText", new ConfigOption("dDMoveEventText", new SerializationOptions("ddMoveEventText"), "Move event to {0}", this.DDMoveEventText ));
                list.Add("dDResizeEventText", new ConfigOption("dDResizeEventText", new SerializationOptions("ddResizeEventText"), "Update event to {0}", this.DDResizeEventText ));
                list.Add("enableAddFx", new ConfigOption("enableAddFx", null, true, this.EnableAddFx ));
                list.Add("enableDD", new ConfigOption("enableDD", null, true, this.EnableDD ));
                list.Add("enableFx", new ConfigOption("enableFx", null, true, this.EnableFx ));
                list.Add("enableRemoveFx", new ConfigOption("enableRemoveFx", null, true, this.EnableRemoveFx ));
                list.Add("enableUpdateFx", new ConfigOption("enableUpdateFx", null, false, this.EnableUpdateFx ));
                list.Add("monitorResize", new ConfigOption("monitorResize", null, true, this.MonitorResize ));
                list.Add("spansHavePriority", new ConfigOption("spansHavePriority", null, false, this.SpansHavePriority ));
                list.Add("trackMouseOver", new ConfigOption("trackMouseOver", null, true, this.TrackMouseOver ));
                list.Add("getEventBodyMarkup", new ConfigOption("getEventBodyMarkup", new SerializationOptions(JsonMode.Raw), null, this.GetEventBodyMarkup ));
                list.Add("getEventTemplate", new ConfigOption("getEventTemplate", new SerializationOptions(JsonMode.Raw), null, this.GetEventTemplate ));

                return list;
            }
        }
    }
}