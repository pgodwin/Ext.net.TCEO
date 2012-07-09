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
    public partial class MapConfiguration
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
                
                list.Add("dragging", new ConfigOption("dragging", null, true, this.Dragging ));
                list.Add("infoWindow", new ConfigOption("infoWindow", null, true, this.InfoWindow ));
                list.Add("doubleClickZoom", new ConfigOption("doubleClickZoom", null, false, this.DoubleClickZoom ));
                list.Add("continuousZoom", new ConfigOption("continuousZoom", null, false, this.ContinuousZoom ));
                list.Add("googleBar", new ConfigOption("googleBar", null, false, this.GoogleBar ));
                list.Add("scrollWheelZoom", new ConfigOption("scrollWheelZoom", null, false, this.ScrollWheelZoom ));

                return list;
            }
        }
    }
}