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
using System.Web.UI;

namespace Ext.Net.UX
{
    public partial class Marker : StateManagedItem
    {
        [ConfigOption]
        [DefaultValue(0.0)]
        [NotifyParentProperty(true)]
        [Description("The latitude coordinate")]
        public double Lat
        {
            get
            {
                object obj = this.ViewState["Lat"];
                return obj != null ? (double)obj : 0.0;
            }
            set
            {
                this.ViewState["Lat"] = value;
            }
        }

        [ConfigOption]
        [DefaultValue(0.0)]
        [NotifyParentProperty(true)]
        [Description("The longitude  coordinate")]
        public double Lng
        {
            get
            {
                object obj = this.ViewState["Lng"];
                return obj != null ? (double)obj : 0.0;
            }
            set
            {
                this.ViewState["Lng"] = value;
            }
        }

        private MarkerOptions markerOptions;

        [ConfigOption("marker",JsonMode.Object)]
        [Category("Config Options")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        public MarkerOptions Options
        {
            get
            {
                if (this.markerOptions == null)
                {
                    this.markerOptions = new MarkerOptions();
                    this.markerOptions.TrackViewState();
                }

                return this.markerOptions;
            }
        }

        private MarkerListeners listeners;

        [ConfigOption("listeners", JsonMode.Object)]
        [Category("Events")]
        [Themeable(false)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript EventHandlers")]
        [ViewStateMember]
        public MarkerListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new MarkerListeners();

                    if (this.IsTrackingViewState)
                    {
                        ((IStateManager)this.listeners).TrackViewState();
                    }
                }
                return this.listeners;
            }
        }
    }

    public class MarkerCollection : StateManagedCollection<Marker> { }
}