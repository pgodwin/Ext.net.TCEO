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
    public partial class NotificationConfig
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
                
                list.Add("iD", new ConfigOption("iD", new SerializationOptions("id"), "", this.ID ));
                list.Add("cls", new ConfigOption("cls", null, "", this.Cls ));
                list.Add("ctCls", new ConfigOption("ctCls", null, "", this.CtCls ));
                list.Add("title", new ConfigOption("title", null, "", this.Title ));
                list.Add("html", new ConfigOption("html", null, "", this.Html ));
                list.Add("contentEl", new ConfigOption("contentEl", null, "", this.ContentEl ));
                list.Add("width", new ConfigOption("width", null, Unit.Pixel(200), this.Width ));
                list.Add("height", new ConfigOption("height", null, Unit.Pixel(100), this.Height ));
                list.Add("autoHide", new ConfigOption("autoHide", null, true, this.AutoHide ));
                list.Add("autoScroll", new ConfigOption("autoScroll", null, false, this.AutoScroll ));
                list.Add("closable", new ConfigOption("closable", null, true, this.Closable ));
                list.Add("shadow", new ConfigOption("shadow", null, false, this.Shadow ));
                list.Add("plain", new ConfigOption("plain", null, false, this.Plain ));
                list.Add("resizable", new ConfigOption("resizable", null, false, this.Resizable ));
                list.Add("draggable", new ConfigOption("draggable", null, false, this.Draggable ));
                list.Add("bodyStyle", new ConfigOption("bodyStyle", null, "", this.BodyStyle ));
                list.Add("alignCfg", new ConfigOption("alignCfg", new SerializationOptions("alignToCfg", JsonMode.Object), null, this.AlignCfg ));
                list.Add("showMode", new ConfigOption("showMode", null, ShowMode.Grid, this.ShowMode ));
                list.Add("closeVisible", new ConfigOption("closeVisible", null, false, this.CloseVisible ));
                list.Add("modal", new ConfigOption("modal", null, false, this.Modal ));
                list.Add("pinEventProxy", new ConfigOption("pinEventProxy", new SerializationOptions("pinEvent"), "none", this.PinEventProxy ));
                list.Add("hideDelay", new ConfigOption("hideDelay", null, 2500, this.HideDelay ));
                list.Add("customConfig", new ConfigOption("customConfig", new SerializationOptions("-", typeof(CustomConfigJsonConverter)), null, this.CustomConfig ));
                list.Add("showFx", new ConfigOption("showFx", new SerializationOptions(JsonMode.Object), null, this.ShowFx ));
                list.Add("hideFx", new ConfigOption("hideFx", new SerializationOptions(JsonMode.Object), null, this.HideFx ));
                list.Add("iconClsProxy", new ConfigOption("iconClsProxy", new SerializationOptions("iconCls"), "", this.IconClsProxy ));
                list.Add("autoLoadProxy", new ConfigOption("autoLoadProxy", new SerializationOptions("autoLoad", JsonMode.Raw), "", this.AutoLoadProxy ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("tools", new ConfigOption("tools", new SerializationOptions(JsonMode.AlwaysArray), null, this.Tools ));
                list.Add("showPin", new ConfigOption("showPin", null, false, this.ShowPin ));
                list.Add("pinned", new ConfigOption("pinned", null, false, this.Pinned ));
                list.Add("bringToFront", new ConfigOption("bringToFront", null, false, this.BringToFront ));

                return list;
            }
        }
    }
}