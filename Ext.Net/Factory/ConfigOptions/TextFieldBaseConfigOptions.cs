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
    public abstract partial class TextFieldBase
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
                
                list.Add("allowBlank", new ConfigOption("allowBlank", null, true, this.AllowBlank ));
                list.Add("blankText", new ConfigOption("blankText", null, "", this.BlankText ));
                list.Add("disableKeyFilter", new ConfigOption("disableKeyFilter", null, false, this.DisableKeyFilter ));
                list.Add("emptyClass", new ConfigOption("emptyClass", null, "", this.EmptyClass ));
                list.Add("emptyText", new ConfigOption("emptyText", null, "", this.EmptyText ));
                list.Add("enableKeyEvents", new ConfigOption("enableKeyEvents", null, false, this.EnableKeyEvents ));
                list.Add("grow", new ConfigOption("grow", null, false, this.Grow ));
                list.Add("growMax", new ConfigOption("growMax", null, Unit.Pixel(800), this.GrowMax ));
                list.Add("growMin", new ConfigOption("growMin", null, Unit.Pixel(30), this.GrowMin ));
                list.Add("inputType", new ConfigOption("inputType", new SerializationOptions(JsonMode.ToLower), InputType.Text, this.InputType ));
                list.Add("maskRe", new ConfigOption("maskRe", new SerializationOptions(typeof(RegexJsonConverter)), "", this.MaskRe ));
                list.Add("maxLength", new ConfigOption("maxLength", null, -1, this.MaxLength ));
                list.Add("maxLengthText", new ConfigOption("maxLengthText", null, "", this.MaxLengthText ));
                list.Add("minLength", new ConfigOption("minLength", null, 0, this.MinLength ));
                list.Add("minLengthText", new ConfigOption("minLengthText", null, "", this.MinLengthText ));
                list.Add("regex", new ConfigOption("regex", new SerializationOptions(typeof(RegexJsonConverter)), "", this.Regex ));
                list.Add("regexText", new ConfigOption("regexText", null, "", this.RegexText ));
                list.Add("selectOnFocus", new ConfigOption("selectOnFocus", null, false, this.SelectOnFocus ));
                list.Add("truncate", new ConfigOption("truncate", null, true, this.Truncate ));
                list.Add("validator", new ConfigOption("validator", new SerializationOptions(JsonMode.Raw), "", this.Validator ));
                list.Add("vtype", new ConfigOption("vtype", null, "", this.Vtype ));
                list.Add("vtypeText", new ConfigOption("vtypeText", null, "", this.VtypeText ));
                list.Add("iconClsProxy", new ConfigOption("iconClsProxy", new SerializationOptions("iconCls"), "", this.IconClsProxy ));

                return list;
            }
        }
    }
}