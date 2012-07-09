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
    public abstract partial class TreeNodeBase
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
                
                list.Add("allowChildren", new ConfigOption("allowChildren", null, true, this.AllowChildren ));
                list.Add("allowDrag", new ConfigOption("allowDrag", null, true, this.AllowDrag ));
                list.Add("allowDrop", new ConfigOption("allowDrop", null, true, this.AllowDrop ));
                list.Add("checked", new ConfigOption("checked", new SerializationOptions(typeof(ThreeStateBoolJsonConverter)), ThreeStateBool.Undefined, this.Checked ));
                list.Add("cls", new ConfigOption("cls", null, "", this.Cls ));
                list.Add("disabled", new ConfigOption("disabled", null, false, this.Disabled ));
                list.Add("draggable", new ConfigOption("draggable", null, false, this.Draggable ));
                list.Add("editable", new ConfigOption("editable", null, true, this.Editable ));
                list.Add("expandable", new ConfigOption("expandable", new SerializationOptions(typeof(ThreeStateBoolJsonConverter)), ThreeStateBool.Undefined, this.Expandable ));
                list.Add("expanded", new ConfigOption("expanded", null, false, this.Expanded ));
                list.Add("hidden", new ConfigOption("hidden", null, false, this.Hidden ));
                list.Add("href", new ConfigOption("href", null, "#", this.Href ));
                list.Add("hrefTarget", new ConfigOption("hrefTarget", null, "", this.HrefTarget ));
                list.Add("iconFile", new ConfigOption("iconFile", new SerializationOptions("icon"), "", this.IconFile ));
                list.Add("iconClsProxy", new ConfigOption("iconClsProxy", new SerializationOptions("iconCls"), "", this.IconClsProxy ));
                list.Add("isTarget", new ConfigOption("isTarget", null, true, this.IsTarget ));
                list.Add("qtip", new ConfigOption("qtip", null, "", this.Qtip ));
                list.Add("qtipConfig", new ConfigOption("qtipConfig", new SerializationOptions("qtipCfg", JsonMode.Object), null, this.QtipConfig ));
                list.Add("singleClickExpand", new ConfigOption("singleClickExpand", null, false, this.SingleClickExpand ));
                list.Add("text", new ConfigOption("text", null, "", this.Text ));
                list.Add("customAttributes", new ConfigOption("customAttributes", new SerializationOptions("-", typeof(CustomConfigJsonConverter)), null, this.CustomAttributes ));
                list.Add("uIProvider", new ConfigOption("uIProvider", new SerializationOptions("uiProvider", JsonMode.Value), "", this.UIProvider ));
                list.Add("uIProviderClass", new ConfigOption("uIProviderClass", new SerializationOptions("uiProvider", JsonMode.Raw), "Ext.tree.TreeNodeUI", this.UIProviderClass ));

                return list;
            }
        }
    }
}