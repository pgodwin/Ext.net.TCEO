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
    public partial class GridView
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
                
                list.Add("autoFill", new ConfigOption("autoFill", null, false, this.AutoFill ));
                list.Add("columnsText", new ConfigOption("columnsText", null, "", this.ColumnsText ));
                list.Add("cellSelector", new ConfigOption("cellSelector", null, "", this.CellSelector ));
                list.Add("cellSelectorDepth", new ConfigOption("cellSelectorDepth", null, 4, this.CellSelectorDepth ));
                list.Add("deferEmptyText", new ConfigOption("deferEmptyText", null, true, this.DeferEmptyText ));
                list.Add("emptyText", new ConfigOption("emptyText", null, "", this.EmptyText ));
                list.Add("enableRowBody", new ConfigOption("enableRowBody", null, false, this.EnableRowBody ));
                list.Add("forceFit", new ConfigOption("forceFit", null, false, this.ForceFit ));
                list.Add("headersDisabled", new ConfigOption("headersDisabled", null, false, this.HeadersDisabled ));
                list.Add("headerMenuOpenCls", new ConfigOption("headerMenuOpenCls", null, "x-grid3-hd-menu-open", this.HeaderMenuOpenCls ));
                list.Add("rowOverCls", new ConfigOption("rowOverCls", null, "x-grid3-row-over", this.RowOverCls ));
                list.Add("rowSelector", new ConfigOption("rowSelector", null, "", this.RowSelector ));
                list.Add("rowSelectorDepth", new ConfigOption("rowSelectorDepth", null, 10, this.RowSelectorDepth ));
                list.Add("rowBodySelector", new ConfigOption("rowBodySelector", null, "div.x-grid3-row-body", this.RowBodySelector ));
                list.Add("rowBodySelectorDepth", new ConfigOption("rowBodySelectorDepth", null, 10, this.RowBodySelectorDepth ));
                list.Add("scrollOffset", new ConfigOption("scrollOffset", null, 19, this.ScrollOffset ));
                list.Add("sortAscText", new ConfigOption("sortAscText", null, "", this.SortAscText ));
                list.Add("sortDescText", new ConfigOption("sortDescText", null, "", this.SortDescText ));
                list.Add("selectedRowClass", new ConfigOption("selectedRowClass", null, "x-grid3-row-selected", this.SelectedRowClass ));
                list.Add("sortClasses", new ConfigOption("sortClasses", new SerializationOptions(JsonMode.Raw), "", this.SortClasses ));
                list.Add("markDirty", new ConfigOption("markDirty", null, true, this.MarkDirty ));
                list.Add("getRowClass", new ConfigOption("getRowClass", new SerializationOptions(JsonMode.Raw), null, this.GetRowClass ));
                list.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners ));
                list.Add("directEvents", new ConfigOption("directEvents", new SerializationOptions("directEvents", JsonMode.Object), null, this.DirectEvents ));
                list.Add("standardHeaderRow", new ConfigOption("standardHeaderRow", null, true, this.StandardHeaderRow ));
                list.Add("splitHandleWidth", new ConfigOption("splitHandleWidth", null, 5, this.SplitHandleWidth ));
                list.Add("headerGroupRowsProxy", new ConfigOption("headerGroupRowsProxy", new SerializationOptions("headerGroupRows", JsonMode.Raw), "", this.headerGroupRowsProxy ));
                list.Add("headerRowsProxy", new ConfigOption("headerRowsProxy", new SerializationOptions("headerRows", JsonMode.Raw), "", this.HeaderRowsProxy ));
                list.Add("templates", new ConfigOption("templates", new SerializationOptions("templates", JsonMode.Object), null, this.Templates ));

                return list;
            }
        }
    }
}