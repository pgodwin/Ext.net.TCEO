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
    public partial class Task
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
                
                list.Add("taskID", new ConfigOption("taskID", new SerializationOptions("id"), "", this.TaskID ));
                list.Add("autoRun", new ConfigOption("autoRun", null, true, this.AutoRun ));
                list.Add("interval", new ConfigOption("interval", null, 1000, this.Interval ));
                list.Add("args", new ConfigOption("args", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.Args ));
                list.Add("scope", new ConfigOption("scope", new SerializationOptions(JsonMode.Raw), "this", this.Scope ));
                list.Add("duration", new ConfigOption("duration", null, 0, this.Duration ));
                list.Add("repeat", new ConfigOption("repeat", null, 0, this.Repeat ));
                list.Add("directEventProxy", new ConfigOption("directEventProxy", new SerializationOptions("serverRun", JsonMode.Raw), "", this.DirectEventProxy ));
                list.Add("listenerProxy", new ConfigOption("listenerProxy", new SerializationOptions("clientRun", JsonMode.Raw), "", this.ListenerProxy ));
                list.Add("onStart", new ConfigOption("onStart", new SerializationOptions("onstart", typeof(FunctionJsonConverter)), "", this.OnStart ));
                list.Add("onStop", new ConfigOption("onStop", new SerializationOptions("onstop", typeof(FunctionJsonConverter)), "", this.OnStop ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}