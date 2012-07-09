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
    public partial class ImageCommandColumn
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
                
                list.Add("hideable", new ConfigOption("hideable", null, true, this.Hideable ));
                list.Add("rightCommandAlign", new ConfigOption("rightCommandAlign", new SerializationOptions(JsonMode.Ignore), false, this.RightCommandAlign ));
                list.Add("groupCommands", new ConfigOption("groupCommands", new SerializationOptions("groupCommands", JsonMode.AlwaysArray), null, this.GroupCommands ));
                list.Add("isCellCommand", new ConfigOption("isCellCommand", new SerializationOptions(JsonMode.Ignore), false, this.IsCellCommand ));
                list.Add("prepareGroupCommand", new ConfigOption("prepareGroupCommand", new SerializationOptions(JsonMode.Raw), null, this.PrepareGroupCommand ));
                list.Add("prepareGroupCommands", new ConfigOption("prepareGroupCommands", new SerializationOptions(JsonMode.Raw), null, this.PrepareGroupCommands ));
                list.Add("prepareCommand", new ConfigOption("prepareCommand", new SerializationOptions(JsonMode.Raw), null, this.PrepareCommand ));
                list.Add("prepareCommands", new ConfigOption("prepareCommands", new SerializationOptions(JsonMode.Raw), null, this.PrepareCommands ));

                return list;
            }
        }
    }
}