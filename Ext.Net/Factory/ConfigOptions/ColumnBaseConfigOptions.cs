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
    public abstract partial class ColumnBase
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
                
                list.Add("wrap", new ConfigOption("wrap", null, false, this.Wrap ));
                list.Add("locked", new ConfigOption("locked", null, false, this.Locked ));
                list.Add("align", new ConfigOption("align", new SerializationOptions(JsonMode.ToLower), Alignment.Left, this.Align ));
                list.Add("css", new ConfigOption("css", null, "", this.Css ));
                list.Add("dataIndex", new ConfigOption("dataIndex", null, null, this.DataIndex ));
                list.Add("editorProxy", new ConfigOption("editorProxy", new SerializationOptions("editor", JsonMode.Raw), "", this.EditorProxy ));
                list.Add("fixed", new ConfigOption("fixed", null, false, this.Fixed ));
                list.Add("header", new ConfigOption("header", null, "", this.Header ));
                list.Add("hidden", new ConfigOption("hidden", null, false, this.Hidden ));
                list.Add("hideable", new ConfigOption("hideable", null, true, this.Hideable ));
                list.Add("columnID", new ConfigOption("columnID", new SerializationOptions("id"), "", this.ColumnID ));
                list.Add("menuDisabled", new ConfigOption("menuDisabled", null, false, this.MenuDisabled ));
                list.Add("renderer", new ConfigOption("renderer", new SerializationOptions(typeof(RendererJsonConverter)), null, this.Renderer ));
                list.Add("groupRenderer", new ConfigOption("groupRenderer", new SerializationOptions(typeof(RendererJsonConverter)), null, this.GroupRenderer ));
                list.Add("groupable", new ConfigOption("groupable", null, true, this.Groupable ));
                list.Add("resizable", new ConfigOption("resizable", null, true, this.Resizable ));
                list.Add("scope", new ConfigOption("scope", new SerializationOptions(JsonMode.Raw), "", this.Scope ));
                list.Add("sortableProxy", new ConfigOption("sortableProxy", new SerializationOptions("sortable"), null, this.SortableProxy ));
                list.Add("tooltip", new ConfigOption("tooltip", null, "", this.Tooltip ));
                list.Add("width", new ConfigOption("width", null, Unit.Pixel(100), this.Width ));
                list.Add("editable", new ConfigOption("editable", null, true, this.Editable ));
                list.Add("emptyGroupText", new ConfigOption("emptyGroupText", null, "", this.EmptyGroupText ));
                list.Add("groupName", new ConfigOption("groupName", null, "", this.GroupName ));
                list.Add("customConfig", new ConfigOption("customConfig", new SerializationOptions("-", typeof(CustomConfigJsonConverter)), null, this.CustomConfig ));

                return list;
            }
        }
    }
}