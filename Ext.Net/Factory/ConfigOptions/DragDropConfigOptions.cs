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
    public abstract partial class DragDrop
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
                
                list.Add("configIDProxy", new ConfigOption("configIDProxy", new SerializationOptions(JsonMode.Ignore), "", this.ConfigIDProxy ));
                list.Add("groups", new ConfigOption("groups", new SerializationOptions("groups", JsonMode.Raw), null, this.Groups ));
                list.Add("hasOuterHandles", new ConfigOption("hasOuterHandles", null, false, this.HasOuterHandles ));
                list.Add("ignoreSelf", new ConfigOption("ignoreSelf", null, true, this.IgnoreSelf ));
                list.Add("invalidHandleClasses", new ConfigOption("invalidHandleClasses", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.InvalidHandleClasses ));
                list.Add("invalidHandleTypesProxy", new ConfigOption("invalidHandleTypesProxy", new SerializationOptions("invalidHandleTypes", JsonMode.Raw), "", this.InvalidHandleTypesProxy ));
                list.Add("invalidHandleIdsProxy", new ConfigOption("invalidHandleIdsProxy", new SerializationOptions("invalidHandleIds", JsonMode.Raw), "", this.InvalidHandleIdsProxy ));
                list.Add("isTarget", new ConfigOption("isTarget", null, true, this.IsTarget ));
                list.Add("maintainOffset", new ConfigOption("maintainOffset", null, false, this.MaintainOffset ));
                list.Add("moveOnly", new ConfigOption("moveOnly", null, false, this.MoveOnly ));
                list.Add("padding", new ConfigOption("padding", new SerializationOptions(typeof(IntArrayJsonConverter)), null, this.Padding ));
                list.Add("primaryButtonOnly", new ConfigOption("primaryButtonOnly", null, true, this.PrimaryButtonOnly ));
                list.Add("xTicks", new ConfigOption("xTicks", new SerializationOptions(typeof(IntArrayJsonConverter)), null, this.XTicks ));
                list.Add("yTicks", new ConfigOption("yTicks", new SerializationOptions(typeof(IntArrayJsonConverter)), null, this.YTicks ));
                list.Add("endDrag", new ConfigOption("endDrag", new SerializationOptions(JsonMode.Raw), null, this.EndDrag ));
                list.Add("onAvailable", new ConfigOption("onAvailable", new SerializationOptions(JsonMode.Raw), null, this.OnAvailable ));
                list.Add("onDrag", new ConfigOption("onDrag", new SerializationOptions(JsonMode.Raw), null, this.OnDrag ));
                list.Add("onDragDrop", new ConfigOption("onDragDrop", new SerializationOptions(JsonMode.Raw), null, this.OnDragDrop ));
                list.Add("onDragEnter", new ConfigOption("onDragEnter", new SerializationOptions(JsonMode.Raw), null, this.OnDragEnter ));
                list.Add("onDragOut", new ConfigOption("onDragOut", new SerializationOptions(JsonMode.Raw), null, this.OnDragOut ));
                list.Add("onDragOver", new ConfigOption("onDragOver", new SerializationOptions(JsonMode.Raw), null, this.OnDragOver ));
                list.Add("onInvalidDrop", new ConfigOption("onInvalidDrop", new SerializationOptions(JsonMode.Raw), null, this.OnInvalidDrop ));
                list.Add("onMouseDown", new ConfigOption("onMouseDown", new SerializationOptions(JsonMode.Raw), null, this.OnMouseDown ));
                list.Add("onMouseUp", new ConfigOption("onMouseUp", new SerializationOptions(JsonMode.Raw), null, this.OnMouseUp ));
                list.Add("startDrag", new ConfigOption("startDrag", new SerializationOptions(JsonMode.Raw), null, this.StartDrag ));

                return list;
            }
        }
    }
}