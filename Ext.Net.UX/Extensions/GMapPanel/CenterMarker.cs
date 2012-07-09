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

namespace Ext.Net.UX
{
    public partial class CenterMarker : Marker
    {
        [ConfigOption("geoCodeAddr")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Sends a request to Google servers to geocode the specified address.")]
        public string GeoCodeAddress
        {
            get
            {
                return (string)this.ViewState["GeoCodeAddress"] ?? "";
            }
            set
            {
                this.ViewState["GeoCodeAddress"] = value;
            }
        }
    }
}
