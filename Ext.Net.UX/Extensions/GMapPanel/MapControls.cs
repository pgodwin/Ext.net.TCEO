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
    public partial class MapControls : StateManagedItem
    {
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Creates a control with buttons to pan in four directions, and zoom in and zoom out.")]
        public bool GSmallMapControl
        {
            get
            {
                object obj = this.ViewState["GSmallMapControl"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["GSmallMapControl"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Creates a control with buttons to pan in four directions, and zoom in and zoom out, and a zoom slider.")]
        public bool GLargeMapControl
        {
            get
            {
                object obj = this.ViewState["GLargeMapControl"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["GLargeMapControl"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Creates a control with buttons to zoom in and zoom out.")]
        public bool GSmallZoomControl
        {
            get
            {
                object obj = this.ViewState["GSmallZoomControl"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["GSmallZoomControl"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Creates a control that displays the map scale.")]
        public bool GScaleControl
        {
            get
            {
                object obj = this.ViewState["GScaleControl"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["GScaleControl"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Creates a standard map type control for selecting and switching between supported map types via buttons.")]
        public bool GMapTypeControl
        {
            get
            {
                object obj = this.ViewState["GMapTypeControl"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["GMapTypeControl"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Creates a drop-down map type control for switching between supported map types.")]
        public bool GMenuMapTypeControl
        {
            get
            {
                object obj = this.ViewState["GMenuMapTypeControl"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["GMenuMapTypeControl"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Creates a 'nested' map type control for selecting and switching between supported map types via buttons and nested checkboxes.")]
        public bool GHierarchicalMapTypeControl
        {
            get
            {
                object obj = this.ViewState["GHierarchicalMapTypeControl"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["GHierarchicalMapTypeControl"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Creates a collapsible overview mini-map in the corner of the main map for reference location and navigation (through dragging). The GOverviewMapControl creates an overview map with a one-pixel black border.")]
        public bool GOverviewMapControl
        {
            get
            {
                object obj = this.ViewState["GOverviewMapControl"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["GOverviewMapControl"] = value;
            }
        }
    }
}