/******** 
 * This file is part of Ext.Net UX.

 * Ext.Net UX is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * Ext.Net UX is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.

 * You should have received a copy of the GNU Lesser General Public License
 * along with the Ext.Net.  If not, see <http://www.gnu.org/licenses/>.
 */

/*
* @version:		1.2.0
* @author:		Ext.NET, Inc. http://www.ext.net/
* @date:		2011-09-12
* @copyright:	Copyright (c) 2006-2011, Ext.NET, Inc. or as noted within each 
* 				applicable file LICENSE.txt file
* @license:		LGPL 3.0 License
* @website:		http://www.ext.net/
 ********/

using System.ComponentModel;
using System.Web;
using System.Web.UI;
using Ext.Net;

namespace Ext.Net.UX
{
    public abstract partial class GMapPanelBase : Panel
    {
        [Browsable(false)]
        public override ITemplate Content
        {
            get { return null; }
            set { base.Content = value; }
        }

        [Browsable(false)]
        [ConfigOption(JsonMode.Ignore)]
        public override string Html
        {
            get { return base.Html; }
            set { base.Html = value; }
        }

        [Browsable(false)]
        [ConfigOption(JsonMode.Ignore)]
        public override string ContentEl
        {
            get { return base.ContentEl; }
        }

        [ConfigOption]
        [DefaultValue(3)]
        [NotifyParentProperty(true)]
        [Description("The zoom level of the blowup map in the info window.")]
        public virtual int ZoomLevel
        {
            get
            {
                object obj = this.ViewState["ZoomLevel"];
                return obj != null ? (int) obj : 3; 
            }
            set
            {
                this.ViewState["ZoomLevel"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(180)]
        [NotifyParentProperty(true)]
        [Description("Used by street view. The camera yaw in degrees relative to true north. True north is 0 degrees, east is 90 degrees, south is 180 degrees, west is 270 degrees.")]
        public virtual int Yaw
        {
            get
            {
                object obj = this.ViewState["Yaw"];
                return obj != null ? (int)obj : 180;
            }
            set
            {
                this.ViewState["Yaw"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("Used by street view. The camera pitch in degrees, relative to the street view vehicle. Ranges from 90 degrees (directly upwards) to -90 degrees (directly downwards).")]
        public virtual int Pitch
        {
            get
            {
                object obj = this.ViewState["Pitch"];
                return obj != null ? (int)obj : 0;
            }
            set
            {
                this.ViewState["Pitch"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("Used by street view. The zoom level. Fully zoomed-out is level 0, zooming in increases the zoom level.")]
        public virtual int Zoom
        {
            get
            {
                object obj = this.ViewState["Pitch"];
                return obj != null ? (int)obj : 0;
            }
            set
            {
                this.ViewState["Pitch"] = value;
            }
        }

        [ConfigOption("gmapType", JsonMode.ToLower)]
        [DefaultValue(GMapType.Map)]
        [NotifyParentProperty(true)]
        [Description("GMap type")]
        public virtual GMapType GMapType
        {
            get
            {
                object obj = this.ViewState["GMapType"];
                return obj != null ? (GMapType)obj : GMapType.Map;
            }
            set
            {
                this.ViewState["GMapType"] = value;
            }
        }

        private MapConfiguration mapConfiguration;

        [ConfigOption("mapConfOpts",typeof(MapPropertiesJsonConverter))]
        [Category("Config Options")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        public virtual MapConfiguration MapConfiguration
        {
            get
            {
                if (this.mapConfiguration == null)
                {
                    this.mapConfiguration = new MapConfiguration();
                    this.mapConfiguration.TrackViewState();
                }

                return this.mapConfiguration;
            }
        }

        private MapControls mapControls;

        [ConfigOption("mapControls",typeof(MapPropertiesJsonConverter))]
        [Category("Config Options")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        public virtual MapControls MapControls
        {
            get
            {
                if (this.mapControls == null)
                {
                    this.mapControls = new MapControls();
                    this.mapControls.TrackViewState();
                }

                return this.mapControls;
            }
        }

        private CenterMarker centerMarker;

        [ConfigOption("setCenter", JsonMode.Object)]
        [Category("Config Options")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        public virtual CenterMarker CenterMarker
        {
            get
            {
                if (this.centerMarker == null)
                {
                    this.centerMarker = new CenterMarker();
                    this.centerMarker.TrackViewState();
                }

                return this.centerMarker;
            }
        }

        private MarkerCollection markers;

        [ConfigOption("markers", JsonMode.AlwaysArray)]
        [Category("Config Options")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        public virtual MarkerCollection Markers
        {
            get
            {
                if (this.markers == null)
                {
                    this.markers = new MarkerCollection();
                    this.markers.TrackViewState();
                }

                return this.markers;
            }
        }

        [DefaultValue("ABQIAAAA2CKu_qQN-JHtlfQ5L7BLlRT2yXp_ZAY8_ufC3CFXhHIE1NvwkxQl3I3p2yrGARYK4f4bkjp9NHpm5w")]
        [NotifyParentProperty(true)]
        [Description("GMaps API Key. Default key -  GMaps API Key that works for localhost")]
        public virtual string APIKey
        {
            get
            {
                return (string)this.ViewState["ApiKey"] ?? "ABQIAAAA2CKu_qQN-JHtlfQ5L7BLlRT2yXp_ZAY8_ufC3CFXhHIE1NvwkxQl3I3p2yrGARYK4f4bkjp9NHpm5w";
            }
            set
            {
                this.ViewState["ApiKey"] = value;
                if (!this.DesignMode)
                {
                    HttpContext.Current.Items["GMapApiKey"] = value;
                }
            }
        }

        [DefaultValue("http://maps.google.com/maps?file=api&amp;v=2.x&amp;key={0}")]
        [NotifyParentProperty(true)]
        [Description("GMaps API Key. Default key -  GMaps API Key that works for localhost")]
        public virtual string APIBaseUrl
        {
            get
            {
                return (string)this.ViewState["APIBaseUrl"] ?? "http://maps.google.com/maps?file=api&amp;v=2.x&amp;key={0}";
            }
            set
            {
                this.ViewState["APIBaseUrl"] = value;
            }
        }
    }
}
