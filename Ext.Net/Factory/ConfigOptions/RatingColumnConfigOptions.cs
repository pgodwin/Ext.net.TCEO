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
    public partial class RatingColumn
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
                
                list.Add("xType", new ConfigOption("xType", new SerializationOptions("xtype"), "", this.XType ));
                list.Add("fixed", new ConfigOption("fixed", null, true, this.Fixed ));
                list.Add("dataIndex", new ConfigOption("dataIndex", null, "rating", this.DataIndex ));
                list.Add("editable", new ConfigOption("editable", null, false, this.Editable ));
                list.Add("allowChange", new ConfigOption("allowChange", null, true, this.AllowChange ));
                list.Add("selectedCls", new ConfigOption("selectedCls", null, "rating-selected", this.SelectedCls ));
                list.Add("unselectedCls", new ConfigOption("unselectedCls", null, "rating-unselected", this.UnselectedCls ));
                list.Add("maxRating", new ConfigOption("maxRating", null, 5, this.MaxRating ));
                list.Add("tickSize", new ConfigOption("tickSize", null, 16, this.TickSize ));
                list.Add("roundToTick", new ConfigOption("roundToTick", null, true, this.RoundToTick ));

                return list;
            }
        }
    }
}