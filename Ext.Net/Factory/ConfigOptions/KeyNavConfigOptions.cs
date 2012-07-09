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
    public partial class KeyNav
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
                
                list.Add("left", new ConfigOption("left", new SerializationOptions(JsonMode.Raw), null, this.Left ));
                list.Add("right", new ConfigOption("right", new SerializationOptions(JsonMode.Raw), null, this.Right ));
                list.Add("up", new ConfigOption("up", new SerializationOptions(JsonMode.Raw), null, this.Up ));
                list.Add("down", new ConfigOption("down", new SerializationOptions(JsonMode.Raw), null, this.Down ));
                list.Add("pageUp", new ConfigOption("pageUp", new SerializationOptions(JsonMode.Raw), null, this.PageUp ));
                list.Add("pageDown", new ConfigOption("pageDown", new SerializationOptions(JsonMode.Raw), null, this.PageDown ));
                list.Add("del", new ConfigOption("del", new SerializationOptions(JsonMode.Raw), null, this.Del ));
                list.Add("home", new ConfigOption("home", new SerializationOptions(JsonMode.Raw), null, this.Home ));
                list.Add("end", new ConfigOption("end", new SerializationOptions(JsonMode.Raw), null, this.End ));
                list.Add("enter", new ConfigOption("enter", new SerializationOptions(JsonMode.Raw), null, this.Enter ));
                list.Add("esc", new ConfigOption("esc", new SerializationOptions(JsonMode.Raw), null, this.Esc ));
                list.Add("tab", new ConfigOption("tab", new SerializationOptions(JsonMode.Raw), null, this.Tab ));
                list.Add("defaultEventAction", new ConfigOption("defaultEventAction", null, KeyEventAction.StopEvent, this.DefaultEventAction ));
                list.Add("disabled", new ConfigOption("disabled", null, false, this.Disabled ));
                list.Add("forceKeyDown", new ConfigOption("forceKeyDown", null, false, this.ForceKeyDown ));
                list.Add("scope", new ConfigOption("scope", new SerializationOptions(JsonMode.Raw), "", this.Scope ));

                return list;
            }
        }
    }
}