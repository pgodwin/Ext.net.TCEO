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
    public partial class GridEditorOptions
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
                
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("zIndex", new ConfigOption("zIndex", null, 0, this.ZIndex ));
                list.Add("alignment", new ConfigOption("alignment", null, "tl-tl", this.Alignment ));
                list.Add("autoSizeProxy", new ConfigOption("autoSizeProxy", new SerializationOptions("autoSize", JsonMode.Raw), "\"width\"", this.AutoSizeProxy ));
                list.Add("allowBlur", new ConfigOption("allowBlur", null, true, this.AllowBlur ));
                list.Add("cancelOnEsc", new ConfigOption("cancelOnEsc", null, true, this.CancelOnEsc ));
                list.Add("completeOnEnter", new ConfigOption("completeOnEnter", null, true, this.CompleteOnEnter ));
                list.Add("cancelOnBlur", new ConfigOption("cancelOnBlur", null, false, this.CancelOnBlur ));
                list.Add("ignoreNoChange", new ConfigOption("ignoreNoChange", null, false, this.IgnoreNoChange ));
                list.Add("revertInvalid", new ConfigOption("revertInvalid", null, true, this.RevertInvalid ));
                list.Add("shadow", new ConfigOption("shadow", new SerializationOptions(typeof(ShadowJsonConverter)), ShadowMode.None, this.Shadow ));
                list.Add("swallowKeys", new ConfigOption("swallowKeys", null, true, this.SwallowKeys ));
                list.Add("offsets", new ConfigOption("offsets", new SerializationOptions(JsonMode.AlwaysArray), null, this.Offsets ));

                return list;
            }
        }
    }
}