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
    public abstract partial class ImageBase
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
                
                list.Add("height", new ConfigOption("height", null, Unit.Empty, this.Height ));
                list.Add("width", new ConfigOption("width", null, Unit.Empty, this.Width ));
                list.Add("imageUrl", new ConfigOption("imageUrl", new SerializationOptions(JsonMode.Ignore), "", this.ImageUrl ));
                list.Add("imageUrlProxy", new ConfigOption("imageUrlProxy", new SerializationOptions("imageUrl"), "", this.ImageUrlProxy ));
                list.Add("alternateText", new ConfigOption("alternateText", new SerializationOptions("altText"), "", this.AlternateText ));
                list.Add("align", new ConfigOption("align", new SerializationOptions(JsonMode.ToLower), ImageAlign.NotSet, this.Align ));
                list.Add("lazyLoad", new ConfigOption("lazyLoad", null, false, this.LazyLoad ));
                list.Add("monitorComplete", new ConfigOption("monitorComplete", null, true, this.MonitorComplete ));
                list.Add("allowPan", new ConfigOption("allowPan", null, false, this.AllowPan ));
                list.Add("resizable", new ConfigOption("resizable", null, false, this.Resizable ));
                list.Add("monitorPoll", new ConfigOption("monitorPoll", null, 200, this.MonitorPoll ));
                list.Add("resizeConfigProxy", new ConfigOption("resizeConfigProxy", new SerializationOptions("resizeConfig", JsonMode.Raw), "", this.ResizeConfigProxy ));
                list.Add("xDelta", new ConfigOption("xDelta", null, 0, this.XDelta ));
                list.Add("yDelta", new ConfigOption("yDelta", null, 0, this.YDelta ));
                list.Add("loadMask", new ConfigOption("loadMask", new SerializationOptions("loadMask", typeof(LoadMaskJsonConverter)), null, this.LoadMask ));

                return list;
            }
        }
    }
}