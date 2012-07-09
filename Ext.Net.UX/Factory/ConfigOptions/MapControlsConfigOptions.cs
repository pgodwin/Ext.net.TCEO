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
    public partial class MapControls
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
                
                list.Add("gSmallMapControl", new ConfigOption("gSmallMapControl", null, false, this.GSmallMapControl ));
                list.Add("gLargeMapControl", new ConfigOption("gLargeMapControl", null, false, this.GLargeMapControl ));
                list.Add("gSmallZoomControl", new ConfigOption("gSmallZoomControl", null, false, this.GSmallZoomControl ));
                list.Add("gScaleControl", new ConfigOption("gScaleControl", null, false, this.GScaleControl ));
                list.Add("gMapTypeControl", new ConfigOption("gMapTypeControl", null, false, this.GMapTypeControl ));
                list.Add("gMenuMapTypeControl", new ConfigOption("gMenuMapTypeControl", null, false, this.GMenuMapTypeControl ));
                list.Add("gHierarchicalMapTypeControl", new ConfigOption("gHierarchicalMapTypeControl", null, false, this.GHierarchicalMapTypeControl ));
                list.Add("gOverviewMapControl", new ConfigOption("gOverviewMapControl", null, false, this.GOverviewMapControl ));

                return list;
            }
        }
    }
}