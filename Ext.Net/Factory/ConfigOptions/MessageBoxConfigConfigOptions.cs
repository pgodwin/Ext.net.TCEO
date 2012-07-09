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
    public partial class MessageBoxConfig
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
                
                list.Add("title", new ConfigOption("title", null, "", this.Title ));
                list.Add("animEl", new ConfigOption("animEl", null, "", this.AnimEl ));
                list.Add("buttonsProxy", new ConfigOption("buttonsProxy", new SerializationOptions("buttons", JsonMode.Raw), "", this.ButtonsProxy ));
                list.Add("closable", new ConfigOption("closable", null, true, this.Closable ));
                list.Add("cls", new ConfigOption("cls", null, "", this.Cls ));
                list.Add("multilineHeight", new ConfigOption("multilineHeight", new SerializationOptions("multiline"), Unit.Pixel(0), this.MultilineHeight ));
                list.Add("fnProxy", new ConfigOption("fnProxy", new SerializationOptions("fn", JsonMode.Raw), "", this.FnProxy ));
                list.Add("scope", new ConfigOption("scope", new SerializationOptions(JsonMode.Raw), "", this.Scope ));
                list.Add("iconProxy", new ConfigOption("iconProxy", new SerializationOptions("icon", JsonMode.Raw), "", this.IconProxy ));
                list.Add("headerIconClsProxy", new ConfigOption("headerIconClsProxy", new SerializationOptions("iconCls"), "", this.HeaderIconClsProxy ));
                list.Add("maxWidth", new ConfigOption("maxWidth", null, Unit.Pixel(600), this.MaxWidth ));
                list.Add("minWidth", new ConfigOption("minWidth", null, Unit.Pixel(100), this.MinWidth ));
                list.Add("modal", new ConfigOption("modal", null, true, this.Modal ));
                list.Add("message", new ConfigOption("message", new SerializationOptions("msg"), "", this.Message ));
                list.Add("multiline", new ConfigOption("multiline", null, false, this.Multiline ));
                list.Add("progress", new ConfigOption("progress", null, false, this.Progress ));
                list.Add("progressText", new ConfigOption("progressText", null, "", this.ProgressText ));
                list.Add("prompt", new ConfigOption("prompt", null, false, this.Prompt ));
                list.Add("proxyDrag", new ConfigOption("proxyDrag", null, false, this.ProxyDrag ));
                list.Add("value", new ConfigOption("value", null, "", this.Value ));
                list.Add("wait", new ConfigOption("wait", null, false, this.Wait ));
                list.Add("waitConfigProxy", new ConfigOption("waitConfigProxy", new SerializationOptions("waitConfig", JsonMode.Raw), "", this.WaitConfigProxy ));
                list.Add("width", new ConfigOption("width", null, Unit.Pixel(0), this.Width ));

                return list;
            }
        }
    }
}