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

using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class TreePanelDirectEvents : PanelDirectEvents
    {
        private ComponentDirectEvent append;

        /// <summary>
        /// Fires when a new child node is appended to a node in this tree.
        /// </summary>
        [ListenerArgument(0, "tree", typeof(TreePanel))]
        [ListenerArgument(1, "parent", typeof(Node))]
        [ListenerArgument(2, "node", typeof(Node))]
        [ListenerArgument(3, "index")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("append", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new child node is appended to a node in this tree.")]
        public virtual ComponentDirectEvent Append
        {
            get
            {
                if (this.append == null)
                {
                    this.append = new ComponentDirectEvent();
                }

                return this.append;
            }
        }

        private ComponentDirectEvent beforeAppend;

        /// <summary>
        /// Fires before a new child is appended to a node in this tree, return false to cancel the append.
        /// </summary>
        [ListenerArgument(0, "tree", typeof(TreePanel))]
        [ListenerArgument(1, "parent", typeof(Node))]
        [ListenerArgument(2, "node", typeof(Node))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeappend", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a new child is appended to a node in this tree, return false to cancel the append.")]
        public virtual ComponentDirectEvent BeforeAppend
        {
            get
            {
                if (this.beforeAppend == null)
                {
                    this.beforeAppend = new ComponentDirectEvent();
                }

                return this.beforeAppend;
            }
        }

        private ComponentDirectEvent beforeChildrenRendered;

        /// <summary>
        /// Fires right before the child nodes for a node are rendered
        /// </summary>
        [ListenerArgument(0, "node", typeof(Node))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforechildrenrendered", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires right before the child nodes for a node are rendered")]
        public virtual ComponentDirectEvent BeforeChildrenRendered
        {
            get
            {
                if (this.beforeChildrenRendered == null)
                {
                    this.beforeChildrenRendered = new ComponentDirectEvent();
                }

                return this.beforeChildrenRendered;
            }
        }

        private ComponentDirectEvent beforeClick;

        /// <summary>
        /// Fires before click processing on a node. Return false to cancel the default action.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before click processing on a node. Return false to cancel the default action.")]
        public virtual ComponentDirectEvent BeforeClick
        {
            get
            {
                if (this.beforeClick == null)
                {
                    this.beforeClick = new ComponentDirectEvent();
                }

                return this.beforeClick;
            }
        }

        private ComponentDirectEvent beforeCollapseNode;

        /// <summary>
        /// Fires before a node is collapsed, return false to cancel.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "deep")]
        [ListenerArgument(2, "anim")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecollapsenode", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a node is collapsed, return false to cancel.")]
        public virtual ComponentDirectEvent BeforeCollapseNode
        {
            get
            {
                if (this.beforeCollapseNode == null)
                {
                    this.beforeCollapseNode = new ComponentDirectEvent();
                }

                return this.beforeCollapseNode;
            }
        }

        private ComponentDirectEvent beforeExpandNode;

        /// <summary>
        /// Fires before a node is expanded, return false to cancel.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "deep")]
        [ListenerArgument(2, "anim")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeexpandnode", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a node is expanded, return false to cancel.")]
        public virtual ComponentDirectEvent BeforeExpandNode
        {
            get
            {
                if (this.beforeExpandNode == null)
                {
                    this.beforeExpandNode = new ComponentDirectEvent();
                }

                return this.beforeExpandNode;
            }
        }

        private ComponentDirectEvent beforeInsert;

        /// <summary>
        /// Fires before a new child is inserted in a node in this tree, return false to cancel the insert.
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "parent", typeof(Node))]
        [ListenerArgument(2, "node", typeof(Node))]
        [ListenerArgument(3, "refNode")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeinsert", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a new child is inserted in a node in this tree, return false to cancel the insert.")]
        public virtual ComponentDirectEvent BeforeInsert
        {
            get
            {
                if (this.beforeInsert == null)
                {
                    this.beforeInsert = new ComponentDirectEvent();
                }

                return this.beforeInsert;
            }
        }

        private ComponentDirectEvent beforeLoad;

        /// <summary>
        /// Fires before a node is loaded, return false to cancel.
        /// </summary>
        [ListenerArgument(0, "node")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeload", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a node is loaded, return false to cancel.")]
        public virtual ComponentDirectEvent BeforeLoad
        {
            get
            {
                if (this.beforeLoad == null)
                {
                    this.beforeLoad = new ComponentDirectEvent();
                }

                return this.beforeLoad;
            }
        }

        private ComponentDirectEvent beforeMoveNode;

        /// <summary>
        /// Fires before a node is moved to a new location in the tree. Return false to cancel the move.
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node", typeof(Node))]
        [ListenerArgument(2, "oldParent", typeof(Node))]
        [ListenerArgument(3, "newParent", typeof(Node))]
        [ListenerArgument(4, "index")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforemovenode", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a node is moved to a new location in the tree. Return false to cancel the move.")]
        public virtual ComponentDirectEvent BeforeMoveNode
        {
            get
            {
                if (this.beforeMoveNode == null)
                {
                    this.beforeMoveNode = new ComponentDirectEvent();
                }

                return this.beforeMoveNode;
            }
        }

        private ComponentDirectEvent beforeNodeDrop;

        /// <summary>
        /// Fires when a DD object is dropped on a node in this tree for preprocessing. Return false to cancel the drop.
        /// </summary>
        [ListenerArgument(0, "dropEvent")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforenodedrop", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a DD object is dropped on a node in this tree for preprocessing. Return false to cancel the drop.")]
        public virtual ComponentDirectEvent BeforeNodeDrop
        {
            get
            {
                if (this.beforeNodeDrop == null)
                {
                    this.beforeNodeDrop = new ComponentDirectEvent();
                }

                return this.beforeNodeDrop;
            }
        }

        private ComponentDirectEvent beforeRemoveNode;

        /// <summary>
        /// Fires before a child is removed from a node in this tree, return false to cancel the remove.
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "parent", typeof(Node))]
        [ListenerArgument(2, "node", typeof(Node))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a child is removed from a node in this tree, return false to cancel the remove.")]
        public virtual ComponentDirectEvent BeforeRemoveNode
        {
            get
            {
                if (this.beforeRemoveNode == null)
                {
                    this.beforeRemoveNode = new ComponentDirectEvent();
                }

                return this.beforeRemoveNode;
            }
        }

        private ComponentDirectEvent checkChange;

        /// <summary>
        /// Fires when a node with a checkbox's checked property changes
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "checked")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("checkchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node with a checkbox's checked property changes")]
        public virtual ComponentDirectEvent CheckChange
        {
            get
            {
                if (this.checkChange == null)
                {
                    this.checkChange = new ComponentDirectEvent();
                }

                return this.checkChange;
            }
        }

        private ComponentDirectEvent click;

        /// <summary>
        /// Fires when a node is clicked
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node is clicked")]
        public virtual ComponentDirectEvent Click
        {
            get
            {
                if (this.click == null)
                {
                    this.click = new ComponentDirectEvent();
                }

                return this.click;
            }
        }

        private ComponentDirectEvent collapseNode;

        /// <summary>
        /// Fires when a node is collapsed
        /// </summary>
        [ListenerArgument(0, "node")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("collapsenode", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node is collapsed")]
        public virtual ComponentDirectEvent CollapseNode
        {
            get
            {
                if (this.collapseNode == null)
                {
                    this.collapseNode = new ComponentDirectEvent();
                }

                return this.collapseNode;
            }
        }

        private ComponentDirectEvent contextMenu;

        /// <summary>
        /// Fires when a node is right clicked.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("contextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node is right clicked.")]
        public virtual ComponentDirectEvent ContextMenu
        {
            get
            {
                if (this.contextMenu == null)
                {
                    this.contextMenu = new ComponentDirectEvent();
                }

                return this.contextMenu;
            }
        }

        private ComponentDirectEvent dblClick;

        /// <summary>
        /// Fires when a node is double clicked
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node is double clicked")]
        public virtual ComponentDirectEvent DblClick
        {
            get
            {
                if (this.dblClick == null)
                {
                    this.dblClick = new ComponentDirectEvent();
                }

                return this.dblClick;
            }
        }

        private ComponentDirectEvent disabledChange;

        /// <summary>
        /// Fires when the disabled status of a node changes
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "disabled")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("disabledchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the disabled status of a node changes")]
        public virtual ComponentDirectEvent DisabledChange
        {
            get
            {
                if (this.disabledChange == null)
                {
                    this.disabledChange = new ComponentDirectEvent();
                }

                return this.disabledChange;
            }
        }

        private ComponentDirectEvent dragDrop;

        /// <summary>
        /// Fires when a dragged node is dropped on a valid DD target
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "dd")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dragdrop", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a dragged node is dropped on a valid DD target")]
        public virtual ComponentDirectEvent DragDrop
        {
            get
            {
                if (this.dragDrop == null)
                {
                    this.dragDrop = new ComponentDirectEvent();
                }

                return this.dragDrop;
            }
        }

        private ComponentDirectEvent endDrag;

        /// <summary>
        /// Fires when a drag operation is complete
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("enddrag", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a drag operation is complete")]
        public virtual ComponentDirectEvent EndDrag
        {
            get
            {
                if (this.endDrag == null)
                {
                    this.endDrag = new ComponentDirectEvent();
                }

                return this.endDrag;
            }
        }

        private ComponentDirectEvent expandNode;

        /// <summary>
        /// Fires when a node is expanded
        /// </summary>
        [ListenerArgument(0, "node")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("expandnode", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node is expanded")]
        public virtual ComponentDirectEvent ExpandNode
        {
            get
            {
                if (this.expandNode == null)
                {
                    this.expandNode = new ComponentDirectEvent();
                }

                return this.expandNode;
            }
        }

        private ComponentDirectEvent insert;

        /// <summary>
        /// Fires when a new child node is inserted in a node in this tree.
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "parent", typeof(Node))]
        [ListenerArgument(2, "node", typeof(Node))]
        [ListenerArgument(3, "refNode", typeof(Node))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("insert", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new child node is inserted in a node in this tree.")]
        public virtual ComponentDirectEvent Insert
        {
            get
            {
                if (this.insert == null)
                {
                    this.insert = new ComponentDirectEvent();
                }

                return this.insert;
            }
        }

        private ComponentDirectEvent load;

        /// <summary>
        /// Fires when a node is loaded
        /// </summary>
        [ListenerArgument(0, "node")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("load", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node is loaded")]
        public virtual ComponentDirectEvent Load
        {
            get
            {
                if (this.load == null)
                {
                    this.load = new ComponentDirectEvent();
                }

                return this.load;
            }
        }

        private ComponentDirectEvent moveNode;

        /// <summary>
        /// Fires when a node is moved to a new location in the tree
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node", typeof(Node))]
        [ListenerArgument(2, "oldParent", typeof(Node))]
        [ListenerArgument(3, "newParent", typeof(Node))]
        [ListenerArgument(4, "index")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("movenode", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node is moved to a new location in the tree")]
        public virtual ComponentDirectEvent MoveNode
        {
            get
            {
                if (this.moveNode == null)
                {
                    this.moveNode = new ComponentDirectEvent();
                }

                return this.moveNode;
            }
        }

        private ComponentDirectEvent nodeDragOver;

        /// <summary>
        /// Fires when a tree node is being targeted for a drag drop, return false to signal drop not allowed.
        /// </summary>
        [ListenerArgument(0, "dragOverEvent")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("nodedragover", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a tree node is being targeted for a drag drop, return false to signal drop not allowed.")]
        public virtual ComponentDirectEvent NodeDragOver
        {
            get
            {
                if (this.nodeDragOver == null)
                {
                    this.nodeDragOver = new ComponentDirectEvent();
                }

                return this.nodeDragOver;
            }
        }

        private ComponentDirectEvent nodeDrop;

        /// <summary>
        /// Fires after a DD object is dropped on a node in this tree.
        /// </summary>
        [ListenerArgument(0, "dropEvent")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("nodedrop", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a DD object is dropped on a node in this tree.")]
        public virtual ComponentDirectEvent NodeDrop
        {
            get
            {
                if (this.nodeDrop == null)
                {
                    this.nodeDrop = new ComponentDirectEvent();
                }

                return this.nodeDrop;
            }
        }

        private ComponentDirectEvent removeNode;

        /// <summary>
        /// Fires when a child node is removed from a node in this tree.
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "parent", typeof(Node))]
        [ListenerArgument(2, "node", typeof(Node))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a child node is removed from a node in this tree.")]
        public virtual ComponentDirectEvent RemoveNode
        {
            get
            {
                if (this.removeNode == null)
                {
                    this.removeNode = new ComponentDirectEvent();
                }

                return this.removeNode;
            }
        }

        private ComponentDirectEvent startDrag;

        /// <summary>
        /// Fires when a node starts being dragged
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("startdrag", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node starts being dragged")]
        public virtual ComponentDirectEvent StartDrag
        {
            get
            {
                if (this.startDrag == null)
                {
                    this.startDrag = new ComponentDirectEvent();
                }

                return this.startDrag;
            }
        }

        private ComponentDirectEvent textChange;

        /// <summary>
        /// Fires when the text for a node is changed
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "text")]
        [ListenerArgument(2, "oldText")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("textchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the text for a node is changed")]
        public virtual ComponentDirectEvent TextChange
        {
            get
            {
                if (this.textChange == null)
                {
                    this.textChange = new ComponentDirectEvent();
                }

                return this.textChange;
            }
        }

        private ComponentDirectEvent submit;

        /// <summary>
        /// Fires when the submit is success
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("submit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the submit is success")]
        public virtual ComponentDirectEvent Submit
        {
            get
            {
                if (this.submit == null)
                {
                    this.submit = new ComponentDirectEvent();
                }

                return this.submit;
            }
        }

        private ComponentDirectEvent submitException;

        /// <summary>
        /// Fires when the submit is success
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "o")]
        [ListenerArgument(2, "response")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("submitexception", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the submit is success")]
        public virtual ComponentDirectEvent SubmitException
        {
            get
            {
                if (this.submitException == null)
                {
                    this.submitException = new ComponentDirectEvent();
                }

                return this.submitException;
            }
        }

        private ComponentDirectEvent beforeRemoteAction;

        /// <summary>
        /// Fires before remote action request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "action")]
        [ListenerArgument(3, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteaction", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote action request")]
        public virtual ComponentDirectEvent BeforeRemoteAction
        {
            get
            {
                if (this.beforeRemoteAction == null)
                {
                    this.beforeRemoteAction = new ComponentDirectEvent();
                }

                return this.beforeRemoteAction;
            }
        }

        private ComponentDirectEvent remoteActionException;

        /// <summary>
        /// Fires when an remote action exception occurs
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "response")]
        [ListenerArgument(2, "e")]
        [ListenerArgument(3, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionexception", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an remote action exception occurs")]
        public virtual ComponentDirectEvent RemoteActionException
        {
            get
            {
                if (this.remoteActionException == null)
                {
                    this.remoteActionException = new ComponentDirectEvent();
                }

                return this.remoteActionException;
            }
        }

        private ComponentDirectEvent remoteActionRefusal;

        /// <summary>
        /// Fires when remote action is finished but contains refusal answer
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "response")]
        [ListenerArgument(2, "e")]
        [ListenerArgument(3, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionrefusal", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when remote action is finished but contains refusal answer")]
        public virtual ComponentDirectEvent RemoteActionRefusal
        {
            get
            {
                if (this.remoteActionRefusal == null)
                {
                    this.remoteActionRefusal = new ComponentDirectEvent();
                }

                return this.remoteActionRefusal;
            }
        }

        private ComponentDirectEvent remoteActionSuccess;

        /// <summary>
        /// Fires when remote action successful
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "action")]
        [ListenerArgument(3, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionsuccess", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when remote action successful")]
        public virtual ComponentDirectEvent RemoteActionSuccess
        {
            get
            {
                if (this.remoteActionSuccess == null)
                {
                    this.remoteActionSuccess = new ComponentDirectEvent();
                }

                return this.remoteActionSuccess;
            }
        }

        private ComponentDirectEvent beforeRemoteMove;

        /// <summary>
        /// Fires before remote move request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "target")]
        [ListenerArgument(3, "e")]
        [ListenerArgument(4, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremotemove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote move request")]
        public virtual ComponentDirectEvent BeforeRemoteMove
        {
            get
            {
                if (this.beforeRemoteMove == null)
                {
                    this.beforeRemoteMove = new ComponentDirectEvent();
                }

                return this.beforeRemoteMove;
            }
        }

        private ComponentDirectEvent beforeRemoteRename;

        /// <summary>
        /// Fires before remote rename request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoterename", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote rename request")]
        public virtual ComponentDirectEvent BeforeRemoteRename
        {
            get
            {
                if (this.beforeRemoteRename == null)
                {
                    this.beforeRemoteRename = new ComponentDirectEvent();
                }

                return this.beforeRemoteRename;
            }
        }

        private ComponentDirectEvent beforeRemoteRemove;

        /// <summary>
        /// Fires before remote remove request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteremove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote remove request")]
        public virtual ComponentDirectEvent BeforeRemoteRemove
        {
            get
            {
                if (this.beforeRemoteRemove == null)
                {
                    this.beforeRemoteRemove = new ComponentDirectEvent();
                }

                return this.beforeRemoteRemove;
            }
        }

        private ComponentDirectEvent beforeRemoteAppend;

        /// <summary>
        /// Fires before remote insert/append request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [ListenerArgument(3, "insert")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteappend", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote insert/append request")]
        public virtual ComponentDirectEvent BeforeRemoteAppend
        {
            get
            {
                if (this.beforeRemoteAppend == null)
                {
                    this.beforeRemoteAppend = new ComponentDirectEvent();
                }

                return this.beforeRemoteAppend;
            }
        }
    }
}