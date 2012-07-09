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
    public partial class StoreListeners
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
                
                list.Add("add", new ConfigOption("add", new SerializationOptions("add", typeof(ListenerJsonConverter)), null, this.Add ));
                list.Add("beforeLoad", new ConfigOption("beforeLoad", new SerializationOptions("beforeload", typeof(ListenerJsonConverter)), null, this.BeforeLoad ));
                list.Add("clear", new ConfigOption("clear", new SerializationOptions("clear", typeof(ListenerJsonConverter)), null, this.Clear ));
                list.Add("dataChanged", new ConfigOption("dataChanged", new SerializationOptions("datachanged", typeof(ListenerJsonConverter)), null, this.DataChanged ));
                list.Add("load", new ConfigOption("load", new SerializationOptions("load", typeof(ListenerJsonConverter)), null, this.Load ));
                list.Add("loadException", new ConfigOption("loadException", new SerializationOptions("loadexception", typeof(ListenerJsonConverter)), null, this.LoadException ));
                list.Add("metaChange", new ConfigOption("metaChange", new SerializationOptions("metachange", typeof(ListenerJsonConverter)), null, this.MetaChange ));
                list.Add("remove", new ConfigOption("remove", new SerializationOptions("remove", typeof(ListenerJsonConverter)), null, this.Remove ));
                list.Add("update", new ConfigOption("update", new SerializationOptions("update", typeof(ListenerJsonConverter)), null, this.Update ));
                list.Add("beforeSave", new ConfigOption("beforeSave", new SerializationOptions("beforesave", typeof(ListenerJsonConverter)), null, this.BeforeSave ));
                list.Add("save", new ConfigOption("save", new SerializationOptions("save", typeof(ListenerJsonConverter)), null, this.Save ));
                list.Add("saveException", new ConfigOption("saveException", new SerializationOptions("saveexception", typeof(ListenerJsonConverter)), null, this.SaveException ));
                list.Add("commitDone", new ConfigOption("commitDone", new SerializationOptions("commitdone", typeof(ListenerJsonConverter)), null, this.CommitDone ));
                list.Add("commitFailed", new ConfigOption("commitFailed", new SerializationOptions("commitfailed", typeof(ListenerJsonConverter)), null, this.CommitFailed ));
                list.Add("exception", new ConfigOption("exception", new SerializationOptions("exception", typeof(ListenerJsonConverter)), null, this.Exception ));
                list.Add("groupChange", new ConfigOption("groupChange", new SerializationOptions("groupchange", typeof(ListenerJsonConverter)), null, this.GroupChange ));

                return list;
            }
        }
    }
}