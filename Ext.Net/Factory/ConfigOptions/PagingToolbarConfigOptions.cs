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
    public partial class PagingToolbar
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
                
                list.Add("pageIndex", new ConfigOption("pageIndex", null, 1, this.PageIndex ));
                list.Add("displayInfo", new ConfigOption("displayInfo", null, false, this.DisplayInfo ));
                list.Add("displayMsg", new ConfigOption("displayMsg", null, "Displaying {0} - {1} of {2}", this.DisplayMsg ));
                list.Add("emptyMsg", new ConfigOption("emptyMsg", null, "No data to display", this.EmptyMsg ));
                list.Add("pageSize", new ConfigOption("pageSize", null, 20, this.PageSize ));
                list.Add("storeID", new ConfigOption("storeID", new SerializationOptions("store", JsonMode.ToClientID), "", this.StoreID ));
                list.Add("afterPageText", new ConfigOption("afterPageText", null, "of {0}", this.AfterPageText ));
                list.Add("beforePageText", new ConfigOption("beforePageText", null, "Page", this.BeforePageText ));
                list.Add("firstText", new ConfigOption("firstText", null, "First Page", this.FirstText ));
                list.Add("lastText", new ConfigOption("lastText", null, "Last Page", this.LastText ));
                list.Add("nextText", new ConfigOption("nextText", null, "Next Page", this.NextText ));
                list.Add("prevText", new ConfigOption("prevText", null, "Previous Page", this.PrevText ));
                list.Add("refreshText", new ConfigOption("refreshText", null, "Refresh", this.RefreshText ));
                list.Add("hideRefresh", new ConfigOption("hideRefresh", null, false, this.HideRefresh ));
                list.Add("paramNames", new ConfigOption("paramNames", new SerializationOptions(JsonMode.ArrayToObject), null, this.ParamNames ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}