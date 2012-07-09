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
    public partial class PanelListeners
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
                
                list.Add("activate", new ConfigOption("activate", new SerializationOptions("activate", typeof(ListenerJsonConverter)), null, this.Activate ));
                list.Add("beforeClose", new ConfigOption("beforeClose", new SerializationOptions("beforeclose", typeof(ListenerJsonConverter)), null, this.BeforeClose ));
                list.Add("beforeCollapse", new ConfigOption("beforeCollapse", new SerializationOptions("beforecollapse", typeof(ListenerJsonConverter)), null, this.BeforeCollapse ));
                list.Add("beforeExpand", new ConfigOption("beforeExpand", new SerializationOptions("beforeexpand", typeof(ListenerJsonConverter)), null, this.BeforeExpand ));
                list.Add("bodyResize", new ConfigOption("bodyResize", new SerializationOptions("bodyresize", typeof(ListenerJsonConverter)), null, this.BodyResize ));
                list.Add("close", new ConfigOption("close", new SerializationOptions("close", typeof(ListenerJsonConverter)), null, this.Close ));
                list.Add("collapse", new ConfigOption("collapse", new SerializationOptions("collapse", typeof(ListenerJsonConverter)), null, this.Collapse ));
                list.Add("deactivate", new ConfigOption("deactivate", new SerializationOptions("deactivate", typeof(ListenerJsonConverter)), null, this.Deactivate ));
                list.Add("expand", new ConfigOption("expand", new SerializationOptions("expand", typeof(ListenerJsonConverter)), null, this.Expand ));
                list.Add("titleChange", new ConfigOption("titleChange", new SerializationOptions("titlechange", typeof(ListenerJsonConverter)), null, this.TitleChange ));
                list.Add("beforeUpdate", new ConfigOption("beforeUpdate", new SerializationOptions("beforeupdate", typeof(ListenerJsonConverter)), null, this.BeforeUpdate ));
                list.Add("update", new ConfigOption("update", new SerializationOptions("update", typeof(ListenerJsonConverter)), null, this.Update ));
                list.Add("failure", new ConfigOption("failure", new SerializationOptions("failure", typeof(ListenerJsonConverter)), null, this.Failure ));
                list.Add("iconChange", new ConfigOption("iconChange", new SerializationOptions("iconchange", typeof(ListenerJsonConverter)), null, this.IconChange ));

                return list;
            }
        }
    }
}