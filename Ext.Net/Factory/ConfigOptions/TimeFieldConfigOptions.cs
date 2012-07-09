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
    public partial class TimeField
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
                
                list.Add("itemsProxy", new ConfigOption("itemsProxy", new SerializationOptions("store", JsonMode.Raw), "", this.ItemsProxy ));
                list.Add("valueProxy", new ConfigOption("valueProxy", new SerializationOptions("value"), null, this.ValueProxy ));
                list.Add("altFormatsProxy", new ConfigOption("altFormatsProxy", new SerializationOptions("altFormats"), "", this.AltFormatsProxy ));
                list.Add("formatProxy", new ConfigOption("formatProxy", new SerializationOptions("format"), "", this.FormatProxy ));
                list.Add("increment", new ConfigOption("increment", null, 15, this.Increment ));
                list.Add("maxText", new ConfigOption("maxText", null, "", this.MaxText ));
                list.Add("maxTimeProxy", new ConfigOption("maxTimeProxy", new SerializationOptions("maxValue"), "", this.MaxTimeProxy ));
                list.Add("minTimeProxy", new ConfigOption("minTimeProxy", new SerializationOptions("minValue"), "", this.MinTimeProxy ));
                list.Add("minText", new ConfigOption("minText", null, "", this.MinText ));
                list.Add("allQuery", new ConfigOption("allQuery", new SerializationOptions(JsonMode.Ignore), null, this.AllQuery ));
                list.Add("queryDelay", new ConfigOption("queryDelay", new SerializationOptions(JsonMode.Ignore), null, this.QueryDelay ));
                list.Add("queryParam", new ConfigOption("queryParam", new SerializationOptions(JsonMode.Ignore), null, this.QueryParam ));
                list.Add("storeID", new ConfigOption("storeID", new SerializationOptions(JsonMode.Ignore), null, this.StoreID ));
                list.Add("selectedItem", new ConfigOption("selectedItem", new SerializationOptions(JsonMode.Ignore), null, this.SelectedItem ));
                list.Add("valueField", new ConfigOption("valueField", null, "", this.ValueField ));
                list.Add("displayField", new ConfigOption("displayField", new SerializationOptions(JsonMode.Ignore), null, this.DisplayField ));
                list.Add("triggerAction", new ConfigOption("triggerAction", new SerializationOptions(JsonMode.Ignore), null, this.TriggerAction ));
                list.Add("mode", new ConfigOption("mode", new SerializationOptions(JsonMode.Ignore), null, this.Mode ));

                return list;
            }
        }
    }
}