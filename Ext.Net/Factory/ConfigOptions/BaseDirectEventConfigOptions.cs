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
    public partial class BaseDirectEvent
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
                
                list.Add("cleanRequest", new ConfigOption("cleanRequest", null, false, this.CleanRequest ));
                list.Add("disableCaching", new ConfigOption("disableCaching", null, null, this.DisableCaching ));
                list.Add("disableCachingParam", new ConfigOption("disableCachingParam", null, "_dc", this.DisableCachingParam ));
                list.Add("isUpload", new ConfigOption("isUpload", null, false, this.IsUpload ));
                list.Add("json", new ConfigOption("json", null, false, this.Json ));
                list.Add("viewStateMode", new ConfigOption("viewStateMode", new SerializationOptions(JsonMode.ToLower), ViewStateMode.Inherit, this.ViewStateMode ));
                list.Add("type", new ConfigOption("type", new SerializationOptions(JsonMode.ToLower), DirectEventType.Submit, this.Type ));
                list.Add("urlProxy", new ConfigOption("urlProxy", new SerializationOptions("url"), "", this.UrlProxy ));
                list.Add("method", new ConfigOption("method", new SerializationOptions("method"), HttpMethod.Default, this.Method ));
                list.Add("timeout", new ConfigOption("timeout", null, 30000, this.Timeout ));
                list.Add("formProxyArg", new ConfigOption("formProxyArg", null, "", this.FormProxyArg ));
                list.Add("extraParams", new ConfigOption("extraParams", new SerializationOptions(JsonMode.ArrayToObject), null, this.ExtraParams ));
                list.Add("eventMask", new ConfigOption("eventMask", new SerializationOptions(JsonMode.Object), null, this.EventMask ));
                list.Add("showWarningOnFailure", new ConfigOption("showWarningOnFailure", null, true, this.ShowWarningOnFailure ));

                return list;
            }
        }
    }
}