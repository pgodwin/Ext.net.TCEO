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
    public abstract partial class ComponentBaseDirectEvents
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
                
                list.Add("added", new ConfigOption("added", new SerializationOptions("added", typeof(DirectEventJsonConverter)), null, this.Added ));
                list.Add("afterRender", new ConfigOption("afterRender", new SerializationOptions("afterrender", typeof(DirectEventJsonConverter)), null, this.AfterRender ));
                list.Add("beforeDestroy", new ConfigOption("beforeDestroy", new SerializationOptions("beforedestroy", typeof(DirectEventJsonConverter)), null, this.BeforeDestroy ));
                list.Add("beforeHide", new ConfigOption("beforeHide", new SerializationOptions("beforehide", typeof(DirectEventJsonConverter)), null, this.BeforeHide ));
                list.Add("beforeRender", new ConfigOption("beforeRender", new SerializationOptions("beforerender", typeof(DirectEventJsonConverter)), null, this.BeforeRender ));
                list.Add("beforeShow", new ConfigOption("beforeShow", new SerializationOptions("beforeshow", typeof(DirectEventJsonConverter)), null, this.BeforeShow ));
                list.Add("beforeStateRestore", new ConfigOption("beforeStateRestore", new SerializationOptions("beforestaterestore", typeof(DirectEventJsonConverter)), null, this.BeforeStateRestore ));
                list.Add("beforeStateSave", new ConfigOption("beforeStateSave", new SerializationOptions("beforestatesave", typeof(DirectEventJsonConverter)), null, this.BeforeStateSave ));
                list.Add("destroy", new ConfigOption("destroy", new SerializationOptions("destroy", typeof(DirectEventJsonConverter)), null, this.Destroy ));
                list.Add("disable", new ConfigOption("disable", new SerializationOptions("disable", typeof(DirectEventJsonConverter)), null, this.Disable ));
                list.Add("enable", new ConfigOption("enable", new SerializationOptions("enable", typeof(DirectEventJsonConverter)), null, this.Enable ));
                list.Add("hide", new ConfigOption("hide", new SerializationOptions("hide", typeof(DirectEventJsonConverter)), null, this.Hide ));
                list.Add("render", new ConfigOption("render", new SerializationOptions("render", typeof(DirectEventJsonConverter)), null, this.Render ));
                list.Add("removed", new ConfigOption("removed", new SerializationOptions("removed", typeof(DirectEventJsonConverter)), null, this.Removed ));
                list.Add("show", new ConfigOption("show", new SerializationOptions("show", typeof(DirectEventJsonConverter)), null, this.Show ));
                list.Add("stateRestore", new ConfigOption("stateRestore", new SerializationOptions("staterestore", typeof(DirectEventJsonConverter)), null, this.StateRestore ));
                list.Add("stateSave", new ConfigOption("stateSave", new SerializationOptions("statesave", typeof(DirectEventJsonConverter)), null, this.StateSave ));

                return list;
            }
        }
    }
}