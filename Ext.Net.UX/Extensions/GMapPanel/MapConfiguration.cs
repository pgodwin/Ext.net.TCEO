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
using Ext.Net;

namespace Ext.Net.UX
{
    public partial class MapConfiguration : StateManagedItem
    {
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Enables the dragging of the map (enabled by default).")]
        public bool Dragging
        {
            get
            {
                object obj = this.ViewState["Dragging"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["Dragging"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Enables info window operations on the map (enabled by default).")]
        public bool InfoWindow
        {
            get
            {
                object obj = this.ViewState["InfoWindow"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["InfoWindow"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Enables double click to zoom in and out (disabled by default).")]
        public bool DoubleClickZoom
        {
            get
            {
                object obj = this.ViewState["DoubleClickZoom"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["DoubleClickZoom"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Enables continuous smooth zooming for select browsers (disabled by default).")]
        public bool ContinuousZoom
        {
            get
            {
                object obj = this.ViewState["ContinuousZoom"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["ContinuousZoom"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Enables the GoogleBar, an integrated search control, to the map. When enabled, this control takes the place of the default Powered By Google logo. Note that this control is not enabled by default.")]
        public bool GoogleBar
        {
            get
            {
                object obj = this.ViewState["GoogleBar"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["GoogleBar"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Enables zooming using a mouse's scroll wheel. Note: scroll wheel zoom is disabled by default.")]
        public bool ScrollWheelZoom
        {
            get
            {
                object obj = this.ViewState["ScrollWheelZoom"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["ScrollWheelZoom"] = value;
            }
        }
    }
}