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
    public partial class GridPanelListeners
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
                
                list.Add("bodyScroll", new ConfigOption("bodyScroll", new SerializationOptions("bodyscroll", typeof(ListenerJsonConverter)), null, this.BodyScroll ));
                list.Add("cellClick", new ConfigOption("cellClick", new SerializationOptions("cellclick", typeof(ListenerJsonConverter)), null, this.CellClick ));
                list.Add("cellContextMenu", new ConfigOption("cellContextMenu", new SerializationOptions("cellcontextmenu", typeof(ListenerJsonConverter)), null, this.CellContextMenu ));
                list.Add("cellDblClick", new ConfigOption("cellDblClick", new SerializationOptions("celldblclick", typeof(ListenerJsonConverter)), null, this.CellDblClick ));
                list.Add("cellMouseDown", new ConfigOption("cellMouseDown", new SerializationOptions("cellMouseDown", typeof(ListenerJsonConverter)), null, this.CellMouseDown ));
                list.Add("click", new ConfigOption("click", new SerializationOptions("click", typeof(ListenerJsonConverter)), null, this.Click ));
                list.Add("columnMove", new ConfigOption("columnMove", new SerializationOptions("columnmove", typeof(ListenerJsonConverter)), null, this.ColumnMove ));
                list.Add("columnResize", new ConfigOption("columnResize", new SerializationOptions("columnresize", typeof(ListenerJsonConverter)), null, this.ColumnResize ));
                list.Add("containerClick", new ConfigOption("containerClick", new SerializationOptions("containerclick", typeof(ListenerJsonConverter)), null, this.ContainerClick ));
                list.Add("containerContextMenu", new ConfigOption("containerContextMenu", new SerializationOptions("containercontextmenu", typeof(ListenerJsonConverter)), null, this.ContainerContextMenu ));
                list.Add("containerDblClick", new ConfigOption("containerDblClick", new SerializationOptions("containerdblclick", typeof(ListenerJsonConverter)), null, this.ContainerDblClick ));
                list.Add("containerMouseDown", new ConfigOption("containerMouseDown", new SerializationOptions("containermousedown", typeof(ListenerJsonConverter)), null, this.ContainerMouseDown ));
                list.Add("contextMenu", new ConfigOption("contextMenu", new SerializationOptions("contextmenu", typeof(ListenerJsonConverter)), null, this.ContextMenu ));
                list.Add("dblClick", new ConfigOption("dblClick", new SerializationOptions("dblclick", typeof(ListenerJsonConverter)), null, this.DblClick ));
                list.Add("groupChange", new ConfigOption("groupChange", new SerializationOptions("groupchange", typeof(ListenerJsonConverter)), null, this.GroupChange ));
                list.Add("groupClick", new ConfigOption("groupClick", new SerializationOptions("groupclick", typeof(ListenerJsonConverter)), null, this.GroupClick ));
                list.Add("groupContextMenu", new ConfigOption("groupContextMenu", new SerializationOptions("groupcontextmenu", typeof(ListenerJsonConverter)), null, this.GroupContextMenu ));
                list.Add("groupDblClick", new ConfigOption("groupDblClick", new SerializationOptions("groupdblclick", typeof(ListenerJsonConverter)), null, this.GroupDblClick ));
                list.Add("groupMouseDown", new ConfigOption("groupMouseDown", new SerializationOptions("groupmousedown", typeof(ListenerJsonConverter)), null, this.GroupMouseDown ));
                list.Add("headerClick", new ConfigOption("headerClick", new SerializationOptions("headerclick", typeof(ListenerJsonConverter)), null, this.HeaderClick ));
                list.Add("headerContextMenu", new ConfigOption("headerContextMenu", new SerializationOptions("headercontextmenu", typeof(ListenerJsonConverter)), null, this.HeaderContextMenu ));
                list.Add("headerDblClick", new ConfigOption("headerDblClick", new SerializationOptions("headerdblclick", typeof(ListenerJsonConverter)), null, this.HeaderDblClick ));
                list.Add("headerMouseDown", new ConfigOption("headerMouseDown", new SerializationOptions("headermousedown", typeof(ListenerJsonConverter)), null, this.HeaderMouseDown ));
                list.Add("keyDown", new ConfigOption("keyDown", new SerializationOptions("keydown", typeof(ListenerJsonConverter)), null, this.KeyDown ));
                list.Add("keyPress", new ConfigOption("keyPress", new SerializationOptions("keypress", typeof(ListenerJsonConverter)), null, this.KeyPress ));
                list.Add("mouseDown", new ConfigOption("mouseDown", new SerializationOptions("mousedown", typeof(ListenerJsonConverter)), null, this.MouseDown ));
                list.Add("mouseOut", new ConfigOption("mouseOut", new SerializationOptions("mouseout", typeof(ListenerJsonConverter)), null, this.MouseOut ));
                list.Add("mouseOver", new ConfigOption("mouseOver", new SerializationOptions("mouseover", typeof(ListenerJsonConverter)), null, this.MouseOver ));
                list.Add("mouseUp", new ConfigOption("mouseUp", new SerializationOptions("mouseup", typeof(ListenerJsonConverter)), null, this.MouseUp ));
                list.Add("reconfigure", new ConfigOption("reconfigure", new SerializationOptions("reconfigure", typeof(ListenerJsonConverter)), null, this.Reconfigure ));
                list.Add("rowBodyClick", new ConfigOption("rowBodyClick", new SerializationOptions("rowbodyclick", typeof(ListenerJsonConverter)), null, this.RowBodyClick ));
                list.Add("rowBodyContextMenu", new ConfigOption("rowBodyContextMenu", new SerializationOptions("rowbodycontextmenu", typeof(ListenerJsonConverter)), null, this.RowBodyContextMenu ));
                list.Add("rowBodyDblClick", new ConfigOption("rowBodyDblClick", new SerializationOptions("rowbodydblclick", typeof(ListenerJsonConverter)), null, this.RowBodyDblClick ));
                list.Add("rowBodyMouseDown", new ConfigOption("rowBodyMouseDown", new SerializationOptions("rowbodymousedown", typeof(ListenerJsonConverter)), null, this.RowBodyMouseDown ));
                list.Add("rowClick", new ConfigOption("rowClick", new SerializationOptions("rowclick", typeof(ListenerJsonConverter)), null, this.RowClick ));
                list.Add("rowContextMenu", new ConfigOption("rowContextMenu", new SerializationOptions("rowcontextmenu", typeof(ListenerJsonConverter)), null, this.RowContextMenu ));
                list.Add("rowDblClick", new ConfigOption("rowDblClick", new SerializationOptions("rowdblclick", typeof(ListenerJsonConverter)), null, this.RowDblClick ));
                list.Add("rowMouseDown", new ConfigOption("rowMouseDown", new SerializationOptions("rowmousedown", typeof(ListenerJsonConverter)), null, this.RowMouseDown ));
                list.Add("sortChange", new ConfigOption("sortChange", new SerializationOptions("sortchange", typeof(ListenerJsonConverter)), null, this.SortChange ));
                list.Add("viewReady", new ConfigOption("viewReady", new SerializationOptions("viewready", typeof(ListenerJsonConverter)), null, this.ViewReady ));
                list.Add("afterEdit", new ConfigOption("afterEdit", new SerializationOptions("afteredit", typeof(ListenerJsonConverter)), null, this.AfterEdit ));
                list.Add("beforeEdit", new ConfigOption("beforeEdit", new SerializationOptions("beforeedit", typeof(ListenerJsonConverter)), null, this.BeforeEdit ));
                list.Add("validateEdit", new ConfigOption("validateEdit", new SerializationOptions("validateedit", typeof(ListenerJsonConverter)), null, this.ValidateEdit ));
                list.Add("command", new ConfigOption("command", new SerializationOptions("command", typeof(ListenerJsonConverter)), null, this.Command ));
                list.Add("groupCommand", new ConfigOption("groupCommand", new SerializationOptions("groupcommand", typeof(ListenerJsonConverter)), null, this.GroupCommand ));
                list.Add("filterUpdate", new ConfigOption("filterUpdate", new SerializationOptions("filterupdate", typeof(ListenerJsonConverter)), null, this.FilterUpdate ));

                return list;
            }
        }
    }
}