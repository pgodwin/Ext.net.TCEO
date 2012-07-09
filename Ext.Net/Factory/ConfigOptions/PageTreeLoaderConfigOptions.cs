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
    public partial class PageTreeLoader
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
                
                list.Add("isUpload", new ConfigOption("isUpload", null, false, this.IsUpload ));
                list.Add("viewStateMode", new ConfigOption("viewStateMode", new SerializationOptions(JsonMode.ToLower), ViewStateMode.Inherit, this.ViewStateMode ));
                list.Add("type", new ConfigOption("type", new SerializationOptions(JsonMode.ToLower), DirectEventType.Submit, this.Type ));
                list.Add("requestMethod", new ConfigOption("requestMethod", new SerializationOptions(JsonMode.Ignore), HttpMethod.Default, this.RequestMethod ));
                list.Add("methodProxy", new ConfigOption("methodProxy", new SerializationOptions("method"), HttpMethod.Default, this.MethodProxy ));
                list.Add("formProxyArg", new ConfigOption("formProxyArg", null, "", this.FormProxyArg ));
                list.Add("eventMask", new ConfigOption("eventMask", new SerializationOptions(JsonMode.Object), null, this.EventMask ));

                return list;
            }
        }
    }
}