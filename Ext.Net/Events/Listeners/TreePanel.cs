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
    public partial class TreePanelListeners : PanelListeners
    {
        private ComponentListener append;

        /// <summary>
        /// Fires when a new child node is appended to a node in this tree.
        /// </summary>
        [ListenerArgument(0, "tree", typeof(TreePanel))]
        [ListenerArgument(1, "parent", typeof(Node))]
        [ListenerArgument(2, "node", typeof(Node))]
        [ListenerArgument(3, "index")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("append", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new child node is appended to a node in this tree.")]
        public virtual ComponentListener Append
        {
            get
            {
                if (this.append == null)
                {
                    this.append = new ComponentListener();
                }

                return this.append;
            }
        }

        private ComponentListener beforeAppend;

        /// <summary>
        /// Fires before a new child is appended to a node in this tree, return false to cancel the append.
        /// </summary>
        [ListenerArgument(0, "tree", typeof(TreePanel))]
        [ListenerArgument(1, "parent", typeof(Node))]
        [ListenerArgument(2, "node", typeof(Node))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeappend", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a new child is appended to a node in this tree, return false to cancel the append.")]
        public virtual ComponentListener BeforeAppend
        {
            get
            {
                if (this.beforeAppend == null)
                {
                    this.beforeAppend = new ComponentListener();
                }

                return this.beforeAppend;
            }
        }

        private ComponentListener beforeChildrenRendered;

        /// <summary>
        /// Fires right before the child nodes for a node are rendered
        /// </summary>
        [ListenerArgument(0, "node", typeof(Node))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforechildrenrendered", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires right before the child nodes for a node are rendered")]
        public virtual ComponentListener BeforeChildrenRendered
        {
            get
            {
                if (this.beforeChildrenRendered == null)
                {
                    this.beforeChildrenRendered = new ComponentListener();
                }

                return this.beforeChildrenRendered;
            }
        }

        private ComponentListener beforeClick;

        /// <summary>
        /// Fires before click processing on a node. Return false to cancel the default action.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before click processing on a node. Return false to cancel the default action.")]
        public virtual ComponentListener BeforeClick
        {
            get
            {
                if (this.beforeClick == null)
                {
                    this.beforeClick = new ComponentListener();
                }

                return this.beforeClick;
            }
        }

        private ComponentListener beforeCollapseNode;

        /// <summary>
        /// Fires before a node is collapsed, return false to cancel.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "deep")]
        [ListenerArgument(2, "anim")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecollapsenode", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a node is collapsed, return false to cancel.")]
        public virtual ComponentListener BeforeCollapseNode
        {
            get
            {
                if (this.beforeCollapseNode == null)
                {
                    this.beforeCollapseNode = new ComponentListener();
                }

                return this.beforeCollapseNode;
            }
        }

        private ComponentListener beforeExpandNode;

        /// <summary>
        /// Fires before a node is expanded, return false to cancel.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "deep")]
        [ListenerArgument(2, "anim")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeexpandnode", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a node is expanded, return false to cancel.")]
        public virtual ComponentListener BeforeExpandNode
        {
            get
            {
                if (this.beforeExpandNode == null)
                {
                    this.beforeExpandNode = new ComponentListener();
                }

                return this.beforeExpandNode;
            }
        }

        private ComponentListener beforeInsert;

        /// <summary>
        /// Fires before a new child is inserted in a node in this tree, return false to cancel the insert.
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "parent", typeof(Node))]
        [ListenerArgument(2, "node", typeof(Node))]
        [ListenerArgument(3, "refNode")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeinsert", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a new child is inserted in a node in this tree, return false to cancel the insert.")]
        public virtual ComponentListener BeforeInsert
        {
            get
            {
                if (this.beforeInsert == null)
                {
                    this.beforeInsert = new ComponentListener();
                }

                return this.beforeInsert;
            }
        }

        private ComponentListener beforeLoad;

        /// <summary>
        /// Fires before a node is loaded, return false to cancel.
        /// </summary>
        [ListenerArgument(0, "node")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeload", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a node is loaded, return false to cancel.")]
        public virtual ComponentListener BeforeLoad
        {
            get
            {
                if (this.beforeLoad == null)
                {
                    this.beforeLoad = new ComponentListener();
                }

                return this.beforeLoad;
            }
        }

        private ComponentListener beforeMoveNode;

        /// <summary>
        /// Fires before a node is moved to a new location in the tree. Return false to cancel the move.
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node", typeof(Node))]
        [ListenerArgument(2, "oldParent", typeof(Node))]
        [ListenerArgument(3, "newParent", typeof(Node))]
        [ListenerArgument(4, "index")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforemovenode", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a node is moved to a new location in the tree. Return false to cancel the move.")]
        public virtual ComponentListener BeforeMoveNode
        {
            get
            {
                if (this.beforeMoveNode == null)
                {
                    this.beforeMoveNode = new ComponentListener();
                }

                return this.beforeMoveNode;
            }
        }

        private ComponentListener beforeNodeDrop;

        /// <summary>
        /// Fires when a DD object is dropped on a node in this tree for preprocessing. Return false to cancel the drop.
        /// </summary>
        [ListenerArgument(0, "dropEvent")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforenodedrop", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a DD object is dropped on a node in this tree for preprocessing. Return false to cancel the drop.")]
        public virtual ComponentListener BeforeNodeDrop
        {
            get
            {
                if (this.beforeNodeDrop == null)
                {
                    this.beforeNodeDrop = new ComponentListener();
                }

                return this.beforeNodeDrop;
            }
        }

        private ComponentListener beforeRemoveNode;

        /// <summary>
        /// Fires before a child is removed from a node in this tree, return false to cancel the remove.
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "parent", typeof(Node))]
        [ListenerArgument(2, "node", typeof(Node))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a child is removed from a node in this tree, return false to cancel the remove.")]
        public virtual ComponentListener BeforeRemoveNode
        {
            get
            {
                if (this.beforeRemoveNode == null)
                {
                    this.beforeRemoveNode = new ComponentListener();
                }

                return this.beforeRemoveNode;
            }
        }

        private ComponentListener checkChange;

        /// <summary>
        /// Fires when a node with a checkbox's checked property changes
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "checked")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("checkchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node with a checkbox's checked property changes")]
        public virtual ComponentListener CheckChange
        {
            get
            {
                if (this.checkChange == null)
                {
                    this.checkChange = new ComponentListener();
                }

                return this.checkChange;
            }
        }

        private ComponentListener click;

        /// <summary>
        /// Fires when a node is clicked
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node is clicked")]
        public virtual ComponentListener Click
        {
            get
            {
                if (this.click == null)
                {
                    this.click = new ComponentListener();
                }

                return this.click;
            }
        }

        private ComponentListener collapseNode;

        /// <summary>
        /// Fires when a node is collapsed
        /// </summary>
        [ListenerArgument(0, "node")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("collapsenode", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node is collapsed")]
        public virtual ComponentListener CollapseNode
        {
            get
            {
                if (this.collapseNode == null)
                {
                    this.collapseNode = new ComponentListener();
                }

                return this.collapseNode;
            }
        }

        private ComponentListener contextMenu;

        /// <summary>
        /// Fires when a node is right clicked.
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("contextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node is right clicked.")]
        public virtual ComponentListener ContextMenu
        {
            get
            {
                if (this.contextMenu == null)
                {
                    this.contextMenu = new ComponentListener();
                }

                return this.contextMenu;
            }
        }

        private ComponentListener dblClick;

        /// <summary>
        /// Fires when a node is double clicked
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node is double clicked")]
        public virtual ComponentListener DblClick
        {
            get
            {
                if (this.dblClick == null)
                {
                    this.dblClick = new ComponentListener();
                }

                return this.dblClick;
            }
        }

        private ComponentListener disabledChange;

        /// <summary>
        /// Fires when the disabled status of a node changes
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "disabled")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("disabledchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the disabled status of a node changes")]
        public virtual ComponentListener DisabledChange
        {
            get
            {
                if (this.disabledChange == null)
                {
                    this.disabledChange = new ComponentListener();
                }

                return this.disabledChange;
            }
        }

        private ComponentListener dragDrop;

        /// <summary>
        /// Fires when a dragged node is dropped on a valid DD target
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "dd")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dragdrop", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a dragged node is dropped on a valid DD target")]
        public virtual ComponentListener DragDrop
        {
            get
            {
                if (this.dragDrop == null)
                {
                    this.dragDrop = new ComponentListener();
                }

                return this.dragDrop;
            }
        }

        private ComponentListener endDrag;

        /// <summary>
        /// Fires when a drag operation is complete
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("enddrag", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a drag operation is complete")]
        public virtual ComponentListener EndDrag
        {
            get
            {
                if (this.endDrag == null)
                {
                    this.endDrag = new ComponentListener();
                }

                return this.endDrag;
            }
        }

        private ComponentListener expandNode;

        /// <summary>
        /// Fires when a node is expanded
        /// </summary>
        [ListenerArgument(0, "node")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("expandnode", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node is expanded")]
        public virtual ComponentListener ExpandNode
        {
            get
            {
                if (this.expandNode == null)
                {
                    this.expandNode = new ComponentListener();
                }

                return this.expandNode;
            }
        }

        private ComponentListener insert;

        /// <summary>
        /// Fires when a new child node is inserted in a node in this tree.
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "parent", typeof(Node))]
        [ListenerArgument(2, "node", typeof(Node))]
        [ListenerArgument(3, "refNode", typeof(Node))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("insert", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a new child node is inserted in a node in this tree.")]
        public virtual ComponentListener Insert
        {
            get
            {
                if (this.insert == null)
                {
                    this.insert = new ComponentListener();
                }

                return this.insert;
            }
        }

        private ComponentListener load;

        /// <summary>
        /// Fires when a node is loaded
        /// </summary>
        [ListenerArgument(0, "node")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("load", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node is loaded")]
        public virtual ComponentListener Load
        {
            get
            {
                if (this.load == null)
                {
                    this.load = new ComponentListener();
                }

                return this.load;
            }
        }

        private ComponentListener moveNode;

        /// <summary>
        /// Fires when a node is moved to a new location in the tree
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node", typeof(Node))]
        [ListenerArgument(2, "oldParent", typeof(Node))]
        [ListenerArgument(3, "newParent", typeof(Node))]
        [ListenerArgument(4, "index")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("movenode", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node is moved to a new location in the tree")]
        public virtual ComponentListener MoveNode
        {
            get
            {
                if (this.moveNode == null)
                {
                    this.moveNode = new ComponentListener();
                }

                return this.moveNode;
            }
        }

        private ComponentListener nodeDragOver;

        /// <summary>
        /// Fires when a tree node is being targeted for a drag drop, return false to signal drop not allowed.
        /// </summary>
        [ListenerArgument(0, "dragOverEvent")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("nodedragover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a tree node is being targeted for a drag drop, return false to signal drop not allowed.")]
        public virtual ComponentListener NodeDragOver
        {
            get
            {
                if (this.nodeDragOver == null)
                {
                    this.nodeDragOver = new ComponentListener();
                }

                return this.nodeDragOver;
            }
        }

        private ComponentListener nodeDrop;

        /// <summary>
        /// Fires after a DD object is dropped on a node in this tree.
        /// </summary>
        [ListenerArgument(0, "dropEvent")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("nodedrop", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a DD object is dropped on a node in this tree.")]
        public virtual ComponentListener NodeDrop
        {
            get
            {
                if (this.nodeDrop == null)
                {
                    this.nodeDrop = new ComponentListener();
                }

                return this.nodeDrop;
            }
        }


        private ComponentListener removeNode;

        /// <summary>
        /// Fires when a child node is removed from a node in this tree.
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "parent", typeof(Node))]
        [ListenerArgument(2, "node", typeof(Node))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a child node is removed from a node in this tree.")]
        public virtual ComponentListener RemoveNode
        {
            get
            {
                if (this.removeNode == null)
                {
                    this.removeNode = new ComponentListener();
                }

                return this.removeNode;
            }
        }

        private ComponentListener startDrag;

        /// <summary>
        /// Fires when a node starts being dragged
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("startdrag", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a node starts being dragged")]
        public virtual ComponentListener StartDrag
        {
            get
            {
                if (this.startDrag == null)
                {
                    this.startDrag = new ComponentListener();
                }

                return this.startDrag;
            }
        }

        private ComponentListener textChange;

        /// <summary>
        /// Fires when the text for a node is changed
        /// </summary>
        [ListenerArgument(0, "node")]
        [ListenerArgument(1, "text")]
        [ListenerArgument(2, "oldText")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("textchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the text for a node is changed")]
        public virtual ComponentListener TextChange
        {
            get
            {
                if (this.textChange == null)
                {
                    this.textChange = new ComponentListener();
                }

                return this.textChange;
            }
        }

        private ComponentListener submit;

        /// <summary>
        /// Fires when the submit is success
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("submit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the submit is success")]
        public virtual ComponentListener Submit
        {
            get
            {
                if (this.submit == null)
                {
                    this.submit = new ComponentListener();
                }

                return this.submit;
            }
        }

        private ComponentListener submitException;

        /// <summary>
        /// Fires when the submit is success
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "o")]
        [ListenerArgument(2, "response")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("submitexception", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the submit is success")]
        public virtual ComponentListener SubmitException
        {
            get
            {
                if (this.submitException == null)
                {
                    this.submitException = new ComponentListener();
                }

                return this.submitException;
            }
        }

        private ComponentListener beforeRemoteAction;

        /// <summary>
        /// Fires before remote action request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "action")]
        [ListenerArgument(3, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteaction", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote action request")]
        public virtual ComponentListener BeforeRemoteAction
        {
            get
            {
                if (this.beforeRemoteAction == null)
                {
                    this.beforeRemoteAction = new ComponentListener();
                }

                return this.beforeRemoteAction;
            }
        }

        private ComponentListener remoteActionException;

        /// <summary>
        /// Fires when an remote action exception occurs
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "response")]
        [ListenerArgument(2, "e")]
        [ListenerArgument(3, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionexception", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an remote action exception occurs")]
        public virtual ComponentListener RemoteActionException
        {
            get
            {
                if (this.remoteActionException == null)
                {
                    this.remoteActionException = new ComponentListener();
                }

                return this.remoteActionException;
            }
        }

        private ComponentListener remoteActionRefusal;

        /// <summary>
        /// Fires when remote action is finished but contains refusal answer
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "response")]
        [ListenerArgument(2, "e")]
        [ListenerArgument(3, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionrefusal", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when remote action is finished but contains refusal answer")]
        public virtual ComponentListener RemoteActionRefusal
        {
            get
            {
                if (this.remoteActionRefusal == null)
                {
                    this.remoteActionRefusal = new ComponentListener();
                }

                return this.remoteActionRefusal;
            }
        }

        private ComponentListener remoteActionSuccess;

        /// <summary>
        /// Fires when remote action successful
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "action")]
        [ListenerArgument(3, "o")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remoteactionsuccess", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when remote action successful")]
        public virtual ComponentListener RemoteActionSuccess
        {
            get
            {
                if (this.remoteActionSuccess == null)
                {
                    this.remoteActionSuccess = new ComponentListener();
                }

                return this.remoteActionSuccess;
            }
        }

        private ComponentListener beforeRemoteMove;

        /// <summary>
        /// Fires before remote move request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "target")]
        [ListenerArgument(3, "e")]
        [ListenerArgument(4, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremotemove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote move request")]
        public virtual ComponentListener BeforeRemoteMove
        {
            get
            {
                if (this.beforeRemoteMove == null)
                {
                    this.beforeRemoteMove = new ComponentListener();
                }

                return this.beforeRemoteMove;
            }
        }

        private ComponentListener beforeRemoteRename;

        /// <summary>
        /// Fires before remote rename request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoterename", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote rename request")]
        public virtual ComponentListener BeforeRemoteRename
        {
            get
            {
                if (this.beforeRemoteRename == null)
                {
                    this.beforeRemoteRename = new ComponentListener();
                }

                return this.beforeRemoteRename;
            }
        }

        private ComponentListener beforeRemoteRemove;

        /// <summary>
        /// Fires before remote remove request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteremove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote remove request")]
        public virtual ComponentListener BeforeRemoteRemove
        {
            get
            {
                if (this.beforeRemoteRemove == null)
                {
                    this.beforeRemoteRemove = new ComponentListener();
                }

                return this.beforeRemoteRemove;
            }
        }

        private ComponentListener beforeRemoteAppend;

        /// <summary>
        /// Fires before remote insert/append request
        /// </summary>
        [ListenerArgument(0, "tree")]
        [ListenerArgument(1, "node")]
        [ListenerArgument(2, "params")]
        [ListenerArgument(3, "insert")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeremoteappend", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before remote insert/append request")]
        public virtual ComponentListener BeforeRemoteAppend
        {
            get
            {
                if (this.beforeRemoteAppend == null)
                {
                    this.beforeRemoteAppend = new ComponentListener();
                }

                return this.beforeRemoteAppend;
            }
        }
    }
}