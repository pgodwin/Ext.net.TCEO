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
    public partial class RowEditor
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
                list.Add("clicksToEdit", new ConfigOption("clicksToEdit", null, 0, this.ClicksToEdit ));
                list.Add("frameWidth", new ConfigOption("frameWidth", null, 5, this.FrameWidth ));
                list.Add("focusDelay", new ConfigOption("focusDelay", null, 250, this.FocusDelay ));
                list.Add("buttonPad", new ConfigOption("buttonPad", null, 3, this.ButtonPad ));
                list.Add("errorSummary", new ConfigOption("errorSummary", null, true, this.ErrorSummary ));
                list.Add("monitorValid", new ConfigOption("monitorValid", null, true, this.MonitorValid ));
                list.Add("minButtonWidth", new ConfigOption("minButtonWidth", null, Unit.Pixel(75), this.MinButtonWidth ));
                list.Add("saveText", new ConfigOption("saveText", null, "Save", this.SaveText ));
                list.Add("cancelText", new ConfigOption("cancelText", null, "Cancel", this.CancelText ));
                list.Add("commitChangesText", new ConfigOption("commitChangesText", null, "You need to commit or cancel your changes", this.CommitChangesText ));
                list.Add("errorText", new ConfigOption("errorText", null, "Errors", this.ErrorText ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));

                return list;
            }
        }
    }
}