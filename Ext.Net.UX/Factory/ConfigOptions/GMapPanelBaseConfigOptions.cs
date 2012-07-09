/********
 * @version   : 1.2.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2011-09-12
 * @copyright : Copyright (c) 2006-2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

using Newtonsoft.Json;

namespace Ext.Net.UX
{
    public abstract partial class GMapPanelBase
    {
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
                
                list.Add("html", new ConfigOption("html", new SerializationOptions(JsonMode.Ignore), null, this.Html ));
                list.Add("contentEl", new ConfigOption("contentEl", new SerializationOptions(JsonMode.Ignore), null, this.ContentEl ));
                list.Add("zoomLevel", new ConfigOption("zoomLevel", null, 3, this.ZoomLevel ));
                list.Add("yaw", new ConfigOption("yaw", null, 180, this.Yaw ));
                list.Add("pitch", new ConfigOption("pitch", null, 0, this.Pitch ));
                list.Add("zoom", new ConfigOption("zoom", null, 0, this.Zoom ));
                list.Add("gMapType", new ConfigOption("gMapType", new SerializationOptions("gmapType", JsonMode.ToLower), GMapType.Map, this.GMapType ));
                list.Add("mapConfiguration", new ConfigOption("mapConfiguration", new SerializationOptions("mapConfOpts",typeof(MapPropertiesJsonConverter)), null, this.MapConfiguration ));
                list.Add("mapControls", new ConfigOption("mapControls", new SerializationOptions("mapControls",typeof(MapPropertiesJsonConverter)), null, this.MapControls ));
                list.Add("centerMarker", new ConfigOption("centerMarker", new SerializationOptions("setCenter", JsonMode.Object), null, this.CenterMarker ));
                list.Add("markers", new ConfigOption("markers", new SerializationOptions("markers", JsonMode.AlwaysArray), null, this.Markers ));

                return list;
            }
        }
    }
}