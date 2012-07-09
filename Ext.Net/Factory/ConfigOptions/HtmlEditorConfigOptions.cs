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
    public partial class HtmlEditor
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
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));
                list.Add("createLinkText", new ConfigOption("createLinkText", null, "", this.CreateLinkText ));
                list.Add("defaultLinkValue", new ConfigOption("defaultLinkValue", null, "http://", this.DefaultLinkValue ));
                list.Add("enableAlignments", new ConfigOption("enableAlignments", null, true, this.EnableAlignments ));
                list.Add("enableColors", new ConfigOption("enableColors", null, true, this.EnableColors ));
                list.Add("enableFont", new ConfigOption("enableFont", null, true, this.EnableFont ));
                list.Add("enableFontSize", new ConfigOption("enableFontSize", null, true, this.EnableFontSize ));
                list.Add("enableFormat", new ConfigOption("enableFormat", null, true, this.EnableFormat ));
                list.Add("enableLinks", new ConfigOption("enableLinks", null, true, this.EnableLinks ));
                list.Add("enableLists", new ConfigOption("enableLists", null, true, this.EnableLists ));
                list.Add("enableSourceEdit", new ConfigOption("enableSourceEdit", null, true, this.EnableSourceEdit ));
                list.Add("escapeValue", new ConfigOption("escapeValue", null, true, this.EscapeValue ));
                list.Add("fontFamilies", new ConfigOption("fontFamilies", new SerializationOptions(typeof(StringArrayJsonConverter)), null, this.FontFamilies ));

                return list;
            }
        }
    }
}