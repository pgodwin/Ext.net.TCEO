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
    public partial class TreePanelDirectEvents
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
                
                list.Add("append", new ConfigOption("append", new SerializationOptions("append", typeof(DirectEventJsonConverter)), null, this.Append ));
                list.Add("beforeAppend", new ConfigOption("beforeAppend", new SerializationOptions("beforeappend", typeof(DirectEventJsonConverter)), null, this.BeforeAppend ));
                list.Add("beforeChildrenRendered", new ConfigOption("beforeChildrenRendered", new SerializationOptions("beforechildrenrendered", typeof(DirectEventJsonConverter)), null, this.BeforeChildrenRendered ));
                list.Add("beforeClick", new ConfigOption("beforeClick", new SerializationOptions("beforeclick", typeof(DirectEventJsonConverter)), null, this.BeforeClick ));
                list.Add("beforeCollapseNode", new ConfigOption("beforeCollapseNode", new SerializationOptions("beforecollapsenode", typeof(DirectEventJsonConverter)), null, this.BeforeCollapseNode ));
                list.Add("beforeExpandNode", new ConfigOption("beforeExpandNode", new SerializationOptions("beforeexpandnode", typeof(DirectEventJsonConverter)), null, this.BeforeExpandNode ));
                list.Add("beforeInsert", new ConfigOption("beforeInsert", new SerializationOptions("beforeinsert", typeof(DirectEventJsonConverter)), null, this.BeforeInsert ));
                list.Add("beforeLoad", new ConfigOption("beforeLoad", new SerializationOptions("beforeload", typeof(DirectEventJsonConverter)), null, this.BeforeLoad ));
                list.Add("beforeMoveNode", new ConfigOption("beforeMoveNode", new SerializationOptions("beforemovenode", typeof(DirectEventJsonConverter)), null, this.BeforeMoveNode ));
                list.Add("beforeNodeDrop", new ConfigOption("beforeNodeDrop", new SerializationOptions("beforenodedrop", typeof(DirectEventJsonConverter)), null, this.BeforeNodeDrop ));
                list.Add("beforeRemoveNode", new ConfigOption("beforeRemoveNode", new SerializationOptions("beforeremove", typeof(DirectEventJsonConverter)), null, this.BeforeRemoveNode ));
                list.Add("checkChange", new ConfigOption("checkChange", new SerializationOptions("checkchange", typeof(DirectEventJsonConverter)), null, this.CheckChange ));
                list.Add("click", new ConfigOption("click", new SerializationOptions("click", typeof(DirectEventJsonConverter)), null, this.Click ));
                list.Add("collapseNode", new ConfigOption("collapseNode", new SerializationOptions("collapsenode", typeof(DirectEventJsonConverter)), null, this.CollapseNode ));
                list.Add("contextMenu", new ConfigOption("contextMenu", new SerializationOptions("contextmenu", typeof(DirectEventJsonConverter)), null, this.ContextMenu ));
                list.Add("dblClick", new ConfigOption("dblClick", new SerializationOptions("dblclick", typeof(DirectEventJsonConverter)), null, this.DblClick ));
                list.Add("disabledChange", new ConfigOption("disabledChange", new SerializationOptions("disabledchange", typeof(DirectEventJsonConverter)), null, this.DisabledChange ));
                list.Add("dragDrop", new ConfigOption("dragDrop", new SerializationOptions("dragdrop", typeof(DirectEventJsonConverter)), null, this.DragDrop ));
                list.Add("endDrag", new ConfigOption("endDrag", new SerializationOptions("enddrag", typeof(DirectEventJsonConverter)), null, this.EndDrag ));
                list.Add("expandNode", new ConfigOption("expandNode", new SerializationOptions("expandnode", typeof(DirectEventJsonConverter)), null, this.ExpandNode ));
                list.Add("insert", new ConfigOption("insert", new SerializationOptions("insert", typeof(DirectEventJsonConverter)), null, this.Insert ));
                list.Add("load", new ConfigOption("load", new SerializationOptions("load", typeof(DirectEventJsonConverter)), null, this.Load ));
                list.Add("moveNode", new ConfigOption("moveNode", new SerializationOptions("movenode", typeof(DirectEventJsonConverter)), null, this.MoveNode ));
                list.Add("nodeDragOver", new ConfigOption("nodeDragOver", new SerializationOptions("nodedragover", typeof(DirectEventJsonConverter)), null, this.NodeDragOver ));
                list.Add("nodeDrop", new ConfigOption("nodeDrop", new SerializationOptions("nodedrop", typeof(DirectEventJsonConverter)), null, this.NodeDrop ));
                list.Add("removeNode", new ConfigOption("removeNode", new SerializationOptions("remove", typeof(DirectEventJsonConverter)), null, this.RemoveNode ));
                list.Add("startDrag", new ConfigOption("startDrag", new SerializationOptions("startdrag", typeof(DirectEventJsonConverter)), null, this.StartDrag ));
                list.Add("textChange", new ConfigOption("textChange", new SerializationOptions("textchange", typeof(DirectEventJsonConverter)), null, this.TextChange ));
                list.Add("submit", new ConfigOption("submit", new SerializationOptions("submit", typeof(DirectEventJsonConverter)), null, this.Submit ));
                list.Add("submitException", new ConfigOption("submitException", new SerializationOptions("submitexception", typeof(DirectEventJsonConverter)), null, this.SubmitException ));
                list.Add("beforeRemoteAction", new ConfigOption("beforeRemoteAction", new SerializationOptions("beforeremoteaction", typeof(DirectEventJsonConverter)), null, this.BeforeRemoteAction ));
                list.Add("remoteActionException", new ConfigOption("remoteActionException", new SerializationOptions("remoteactionexception", typeof(DirectEventJsonConverter)), null, this.RemoteActionException ));
                list.Add("remoteActionRefusal", new ConfigOption("remoteActionRefusal", new SerializationOptions("remoteactionrefusal", typeof(DirectEventJsonConverter)), null, this.RemoteActionRefusal ));
                list.Add("remoteActionSuccess", new ConfigOption("remoteActionSuccess", new SerializationOptions("remoteactionsuccess", typeof(DirectEventJsonConverter)), null, this.RemoteActionSuccess ));
                list.Add("beforeRemoteMove", new ConfigOption("beforeRemoteMove", new SerializationOptions("beforeremotemove", typeof(DirectEventJsonConverter)), null, this.BeforeRemoteMove ));
                list.Add("beforeRemoteRename", new ConfigOption("beforeRemoteRename", new SerializationOptions("beforeremoterename", typeof(DirectEventJsonConverter)), null, this.BeforeRemoteRename ));
                list.Add("beforeRemoteRemove", new ConfigOption("beforeRemoteRemove", new SerializationOptions("beforeremoteremove", typeof(DirectEventJsonConverter)), null, this.BeforeRemoteRemove ));
                list.Add("beforeRemoteAppend", new ConfigOption("beforeRemoteAppend", new SerializationOptions("beforeremoteappend", typeof(DirectEventJsonConverter)), null, this.BeforeRemoteAppend ));

                return list;
            }
        }
    }
}