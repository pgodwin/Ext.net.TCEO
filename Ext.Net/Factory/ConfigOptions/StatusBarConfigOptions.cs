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
    public partial class StatusBar
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
                
                list.Add("autoClear", new ConfigOption("autoClear", null, 5000, this.AutoClear ));
                list.Add("busyIconClsProxy", new ConfigOption("busyIconClsProxy", new SerializationOptions("busyIconCls"), "", this.BusyIconClsProxy ));
                list.Add("busyIconCls", new ConfigOption("busyIconCls", null, "x-status-busy", this.BusyIconCls ));
                list.Add("busyText", new ConfigOption("busyText", null, "Loading...", this.BusyText ));
                list.Add("cls", new ConfigOption("cls", null, "x-statusbar", this.Cls ));
                list.Add("defaultIconClsProxy", new ConfigOption("defaultIconClsProxy", new SerializationOptions("defaultIconCls"), "", this.DefaultIconClsProxy ));
                list.Add("defaultIconCls", new ConfigOption("defaultIconCls", null, "", this.DefaultIconCls ));
                list.Add("defaultText", new ConfigOption("defaultText", null, "&nbsp;", this.DefaultText ));
                list.Add("iconClsProxy", new ConfigOption("iconClsProxy", new SerializationOptions("iconCls"), "", this.IconClsProxy ));
                list.Add("statusAlign", new ConfigOption("statusAlign", new SerializationOptions(JsonMode.ToLower), StatusAlign.Left, this.StatusAlign ));
                list.Add("text", new ConfigOption("text", null, "", this.Text ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}