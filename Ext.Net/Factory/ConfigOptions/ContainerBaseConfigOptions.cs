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
    public abstract partial class ContainerBase
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
                
                list.Add("activeItem", new ConfigOption("activeItem", null, "", this.ActiveItem ));
                list.Add("activeIndex", new ConfigOption("activeIndex", new SerializationOptions("activeItem"), -1, this.ActiveIndex ));
                list.Add("autoDestroy", new ConfigOption("autoDestroy", null, true, this.AutoDestroy ));
                list.Add("autoDoLayout", new ConfigOption("autoDoLayout", null, false, this.AutoDoLayout ));
                list.Add("bufferResize", new ConfigOption("bufferResize", null, 50, this.BufferResize ));
                list.Add("defaultTypeProxy", new ConfigOption("defaultTypeProxy", new SerializationOptions("defaultType"), "panel", this.DefaultTypeProxy ));
                list.Add("defaults", new ConfigOption("defaults", new SerializationOptions(JsonMode.ArrayToObject), null, this.Defaults ));
                list.Add("hideBorders", new ConfigOption("hideBorders", null, false, this.HideBorders ));
                list.Add("monitorResize", new ConfigOption("monitorResize", null, false, this.MonitorResize ));
                list.Add("forceLayout", new ConfigOption("forceLayout", null, false, this.ForceLayout ));
                list.Add("itemsProxy", new ConfigOption("itemsProxy", new SerializationOptions("items", typeof(ItemCollectionJsonConverter)), null, this.ItemsProxy ));
                list.Add("layoutConfig", new ConfigOption("layoutConfig", new SerializationOptions("layoutConfig>Primary"), null, this.LayoutConfig ));
                list.Add("layoutProxy", new ConfigOption("layoutProxy", new SerializationOptions("layout"), "", this.LayoutProxy ));
                list.Add("layoutControl", new ConfigOption("layoutControl", new SerializationOptions(JsonMode.UnrollObject), null, this.LayoutControl ));

                return list;
            }
        }
    }
}