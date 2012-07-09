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

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web;
using System.Web.UI;

[assembly: WebResource("Ext.Net.UX.Extensions.GMapPanel.resources.GMapPanel.js", "text/javascript")]

namespace Ext.Net.UX
{
    [Designer(typeof(EmptyDesigner))]
    [DefaultProperty("")]
    [ToolboxBitmap(typeof(UX.GMapPanel), "Extensions.GMapPanel.GMapPanel.bmp")]
    [ToolboxData("<{0}:GMapPanel runat=\"server\" Title=\"Google Map\" Height=\"300\"></{0}:GMapPanel>")]
    [Description("GMap Panel")]
    public partial class GMapPanel : GMapPanelBase
    {
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 1;

                baseList.Add(new ClientScriptItem(typeof(GMapPanel), "Ext.Net.UX.Extensions.GMapPanel.resources.GMapPanel.js", "ux/extensions/gmappanel/gmappanel.js"));

                return baseList;
            }
        }
        
        public override string XType
        {
            get
            {
                return "gmappanel";
            }
        }

        public override string InstanceOf
        {
            get
            {
                return "Ext.ux.GMapPanel";
            }
        }

        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            string apiKey = HttpContext.Current.Items["GMapApiKey"] as string;

            this.ResourceManager.RegisterClientScriptInclude("GMapApiKey", string.Format(this.APIBaseUrl, apiKey ?? this.APIKey));
        }
    }
}
