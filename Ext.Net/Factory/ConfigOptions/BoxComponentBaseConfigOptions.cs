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
    public abstract partial class BoxComponentBase
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
                
                list.Add("autoScroll", new ConfigOption("autoScroll", null, false, this.AutoScroll ));
                list.Add("autoHeight", new ConfigOption("autoHeight", null, false, this.AutoHeight ));
                list.Add("autoWidth", new ConfigOption("autoWidth", null, false, this.AutoWidth ));
                list.Add("collapseMode", new ConfigOption("collapseMode", new SerializationOptions(JsonMode.ToLower), CollapseMode.Default, this.CollapseMode ));
                list.Add("boxMaxHeight", new ConfigOption("boxMaxHeight", null, Unit.Empty, this.BoxMaxHeight ));
                list.Add("boxMaxWidth", new ConfigOption("boxMaxWidth", null, Unit.Empty, this.BoxMaxWidth ));
                list.Add("boxMinHeight", new ConfigOption("boxMinHeight", null, Unit.Empty, this.BoxMinHeight ));
                list.Add("boxMinWidth", new ConfigOption("boxMinWidth", null, Unit.Empty, this.BoxMinWidth ));
                list.Add("regionMaxHeight", new ConfigOption("regionMaxHeight", new SerializationOptions("maxHeight"), Unit.Empty, this.RegionMaxHeight ));
                list.Add("regionMaxWidth", new ConfigOption("regionMaxWidth", new SerializationOptions("maxWidth"), Unit.Empty, this.RegionMaxWidth ));
                list.Add("regionMinHeight", new ConfigOption("regionMinHeight", new SerializationOptions("minHeight"), Unit.Empty, this.RegionMinHeight ));
                list.Add("regionMinWidth", new ConfigOption("regionMinWidth", new SerializationOptions("minWidth"), Unit.Empty, this.RegionMinWidth ));
                list.Add("height", new ConfigOption("height", null, Unit.Empty, this.Height ));
                list.Add("margins", new ConfigOption("margins", null, "", this.Margins ));
                list.Add("cMargins", new ConfigOption("cMargins", new SerializationOptions("cmargins"), "", this.CMargins ));
                list.Add("pageX", new ConfigOption("pageX", null, Unit.Empty, this.PageX ));
                list.Add("pageY", new ConfigOption("pageY", null, Unit.Empty, this.PageY ));
                list.Add("region", new ConfigOption("region", new SerializationOptions(JsonMode.ToLower), Region.None, this.Region ));
                list.Add("split", new ConfigOption("split", null, false, this.Split ));
                list.Add("tabTip", new ConfigOption("tabTip", null, "", this.TabTip ));
                list.Add("width", new ConfigOption("width", null, Unit.Empty, this.Width ));
                list.Add("x", new ConfigOption("x", new SerializationOptions(JsonMode.Raw), 0, this.X ));
                list.Add("y", new ConfigOption("y", new SerializationOptions(JsonMode.Raw), 0, this.Y ));
                list.Add("tabMenu", new ConfigOption("tabMenu", new SerializationOptions("tabMenu", typeof(ItemCollectionJsonConverter)), null, this.TabMenu ));
                list.Add("tabMenuHidden", new ConfigOption("tabMenuHidden", null, false, this.TabMenuHidden ));

                return list;
            }
        }
    }
}