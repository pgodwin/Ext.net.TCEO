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
    public partial class ToolbarDroppable
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
                
                list.Add("configIDProxy", new ConfigOption("configIDProxy", new SerializationOptions("proxyId"), null, this.ConfigIDProxy ));
                list.Add("createItem", new ConfigOption("createItem", new SerializationOptions(JsonMode.Raw), null, this.CreateItem ));
                list.Add("canDrop", new ConfigOption("canDrop", new SerializationOptions(JsonMode.Raw), null, this.CanDrop ));
                list.Add("calculateEntryIndex", new ConfigOption("calculateEntryIndex", new SerializationOptions(JsonMode.Raw), null, this.CalculateEntryIndex ));
                list.Add("directEventConfig", new ConfigOption("directEventConfig", new SerializationOptions(JsonMode.Object), null, this.DirectEventConfig ));
                list.Add("mode", new ConfigOption("mode", new SerializationOptions(JsonMode.ToLower), DataLoadMode.Local, this.Mode ));
                list.Add("beforeRemoteCreate", new ConfigOption("beforeRemoteCreate", new SerializationOptions(JsonMode.Raw), null, this.BeforeRemoteCreate ));
                list.Add("afterRemoteCreate", new ConfigOption("afterRemoteCreate", new SerializationOptions(JsonMode.Raw), null, this.AfterRemoteCreate ));

                return list;
            }
        }
    }
}