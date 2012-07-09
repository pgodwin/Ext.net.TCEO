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
    public partial class Resizable
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
                
                list.Add("adjustmentsProxy", new ConfigOption("adjustmentsProxy", new SerializationOptions("adjustments", JsonMode.Raw), "", this.AdjustmentsProxy ));
                list.Add("animate", new ConfigOption("animate", null, false, this.Animate ));
                list.Add("disableTrackOver", new ConfigOption("disableTrackOver", null, false, this.DisableTrackOver ));
                list.Add("draggable", new ConfigOption("draggable", null, false, this.Draggable ));
                list.Add("duration", new ConfigOption("duration", null, 0.35, this.Duration ));
                list.Add("dynamic", new ConfigOption("dynamic", null, false, this.Dynamic ));
                list.Add("easing", new ConfigOption("easing", new SerializationOptions(JsonMode.ToCamelLower), Easing.EaseOutStrong, this.Easing ));
                list.Add("enabledResizing", new ConfigOption("enabledResizing", new SerializationOptions("enabled"), true, this.EnabledResizing ));
                list.Add("handlesSummary", new ConfigOption("handlesSummary", new SerializationOptions("handles"), "", this.HandlesSummary ));
                list.Add("handlesProxy", new ConfigOption("handlesProxy", new SerializationOptions("handles"), "", this.HandlesProxy ));
                list.Add("width", new ConfigOption("width", null, Unit.Empty, this.Width ));
                list.Add("height", new ConfigOption("height", null, Unit.Empty, this.Height ));
                list.Add("heightIncrement", new ConfigOption("heightIncrement", new SerializationOptions(JsonMode.Raw), 0, this.HeightIncrement ));
                list.Add("maxHeight", new ConfigOption("maxHeight", new SerializationOptions(JsonMode.Raw), 10000, this.MaxHeight ));
                list.Add("maxWidth", new ConfigOption("maxWidth", new SerializationOptions(JsonMode.Raw), 10000, this.MaxWidth ));
                list.Add("minHeight", new ConfigOption("minHeight", new SerializationOptions(JsonMode.Raw), 5, this.MinHeight ));
                list.Add("minWidth", new ConfigOption("minWidth", new SerializationOptions(JsonMode.Raw), 5, this.MinWidth ));
                list.Add("minX", new ConfigOption("minX", new SerializationOptions(JsonMode.Raw), 0, this.MinX ));
                list.Add("minY", new ConfigOption("minY", new SerializationOptions(JsonMode.Raw), 0, this.MinY ));
                list.Add("pinned", new ConfigOption("pinned", null, false, this.Pinned ));
                list.Add("preserveRatio", new ConfigOption("preserveRatio", null, false, this.PreserveRatio ));
                list.Add("resizeChild", new ConfigOption("resizeChild", null, "", this.ResizeChild ));
                list.Add("transparent", new ConfigOption("transparent", null, false, this.Transparent ));
                list.Add("widthIncrement", new ConfigOption("widthIncrement", new SerializationOptions(JsonMode.Raw), 0, this.WidthIncrement ));
                list.Add("wrap", new ConfigOption("wrap", null, false, this.Wrap ));
                list.Add("resizeElement", new ConfigOption("resizeElement", new SerializationOptions(JsonMode.Raw), null, this.ResizeElement ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}