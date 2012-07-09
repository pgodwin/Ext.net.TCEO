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
    public partial class TreeGrid
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
                
                list.Add("autoExpandColumn", new ConfigOption("autoExpandColumn", null, "", this.AutoExpandColumn ));
                list.Add("autoExpandMax", new ConfigOption("autoExpandMax", null, Unit.Pixel(1000), this.AutoExpandMax ));
                list.Add("autoExpandMin", new ConfigOption("autoExpandMin", null, Unit.Pixel(50), this.AutoExpandMin ));
                list.Add("columns", new ConfigOption("columns", new SerializationOptions("columns", JsonMode.AlwaysArray), null, this.Columns ));
                list.Add("rootVisible", new ConfigOption("rootVisible", null, false, this.RootVisible ));
                list.Add("useArrows", new ConfigOption("useArrows", null, true, this.UseArrows ));
                list.Add("lines", new ConfigOption("lines", null, false, this.Lines ));
                list.Add("columnResize", new ConfigOption("columnResize", null, true, this.ColumnResize ));
                list.Add("enableSort", new ConfigOption("enableSort", null, true, this.EnableSort ));
                list.Add("reserveScrollOffset", new ConfigOption("reserveScrollOffset", null, true, this.ReserveScrollOffset ));
                list.Add("enableHdMenu", new ConfigOption("enableHdMenu", null, true, this.EnableHdMenu ));
                list.Add("columnsText", new ConfigOption("columnsText", null, "Columns", this.ColumnsText ));
                list.Add("hideHeaders", new ConfigOption("hideHeaders", null, false, this.HideHeaders ));

                return list;
            }
        }
    }
}