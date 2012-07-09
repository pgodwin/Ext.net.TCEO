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
    public partial class GridPanelListeners : PanelListeners
    {
        private ComponentListener bodyScroll;

        /// <summary>
        /// Fires when the body element is scrolled.
        /// </summary>
        [ListenerArgument(0, "scrollLeft")]
        [ListenerArgument(1, "scrollTop")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("bodyscroll", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the body element is scrolled.")]
        public virtual ComponentListener BodyScroll
        {
            get
            {
                if (this.bodyScroll == null)
                {
                    this.bodyScroll = new ComponentListener();
                }

                return this.bodyScroll;
            }
        }

        private ComponentListener cellClick;

        /// <summary>
        /// Fires when a cell is clicked. The data for the cell is drawn from the Record for this row.
        /// </summary>
        [ListenerArgument(0, "item",typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "columnIndex")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("cellclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a cell is clicked. The data for the cell is drawn from the Record for this row.")]
        public virtual ComponentListener CellClick
        {
            get
            {
                if (this.cellClick == null)
                {
                    this.cellClick = new ComponentListener();
                }

                return this.cellClick;
            }
        }

        private ComponentListener cellContextMenu;

        /// <summary>
        /// Fires when a cell is right clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "cellIndex")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("cellcontextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a cell is right clicked.")]
        public virtual ComponentListener CellContextMenu
        {
            get
            {
                if (this.cellContextMenu == null)
                {
                    this.cellContextMenu = new ComponentListener();
                }

                return this.cellContextMenu;
            }
        }

        private ComponentListener cellDblClick;

        /// <summary>
        /// Fires when a cell is double clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "columnIndex")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("celldblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a cell is double clicked.")]
        public virtual ComponentListener CellDblClick
        {
            get
            {
                if (this.cellDblClick == null)
                {
                    this.cellDblClick = new ComponentListener();
                }

                return this.cellDblClick;
            }
        }

        private ComponentListener cellMouseDown;

        /// <summary>
        /// Fires before a cell is clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "columnIndex")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("cellMouseDown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a cell is clicked.")]
        public virtual ComponentListener CellMouseDown
        {
            get
            {
                if (this.cellMouseDown == null)
                {
                    this.cellMouseDown = new ComponentListener();
                }

                return this.cellMouseDown;
            }
        }

        private ComponentListener click;

        /// <summary>
        /// The raw click event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw click event for the entire grid.")]
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

        private ComponentListener columnMove;

        /// <summary>
        /// Fires when the user moves a column.
        /// </summary>
        [ListenerArgument(0, "oldIndex")]
        [ListenerArgument(1, "newIndex")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("columnmove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the user moves a column.")]
        public virtual ComponentListener ColumnMove
        {
            get
            {
                if (this.columnMove == null)
                {
                    this.columnMove = new ComponentListener();
                }

                return this.columnMove;
            }
        }

        private ComponentListener columnResize;

        /// <summary>
        /// Fires when the user resizes a column.
        /// </summary>
        [ListenerArgument(0, "columnIndex")]
        [ListenerArgument(1, "newSize")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("columnresize", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the user resizes a column.")]
        public virtual ComponentListener ColumnResize
        {
            get
            {
                if (this.columnResize == null)
                {
                    this.columnResize = new ComponentListener();
                }

                return this.columnResize;
            }
        }

        private ComponentListener containerClick;

        /// <summary>
        /// Fires when the container is clicked. The container consists of any part of the grid body that is not covered by a row.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containerclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the container is clicked. The container consists of any part of the grid body that is not covered by a row.")]
        public virtual ComponentListener ContainerClick
        {
            get
            {
                if (this.containerClick == null)
                {
                    this.containerClick = new ComponentListener();
                }

                return this.containerClick;
            }
        }

        private ComponentListener containerContextMenu;

        /// <summary>
        /// Fires when the container is right clicked. The container consists of any part of the grid body that is not covered by a row.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containercontextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the container is right clicked. The container consists of any part of the grid body that is not covered by a row.")]
        public virtual ComponentListener ContainerContextMenu
        {
            get
            {
                if (this.containerContextMenu == null)
                {
                    this.containerContextMenu = new ComponentListener();
                }

                return this.containerContextMenu;
            }
        }

        private ComponentListener containerDblClick;

        /// <summary>
        /// Fires when the container is double clicked. The container consists of any part of the grid body that is not covered by a row.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containerdblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the container is double clicked. The container consists of any part of the grid body that is not covered by a row.")]
        public virtual ComponentListener ContainerDblClick
        {
            get
            {
                if (this.containerDblClick == null)
                {
                    this.containerDblClick = new ComponentListener();
                }

                return this.containerDblClick;
            }
        }

        private ComponentListener containerMouseDown;

        /// <summary>
        /// Fires before the container is clicked. The container consists of any part of the grid body that is not covered by a row.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containermousedown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the container is clicked. The container consists of any part of the grid body that is not covered by a row.")]
        public virtual ComponentListener ContainerMouseDown
        {
            get
            {
                if (this.containerMouseDown == null)
                {
                    this.containerMouseDown = new ComponentListener();
                }

                return this.containerMouseDown;
            }
        }

        private ComponentListener contextMenu;

        /// <summary>
        /// The raw contextmenu event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("contextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw contextmenu event for the entire grid.")]
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
        /// The raw dblclick event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw dblclick event for the entire grid.")]
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

        private ComponentListener groupChange;

        /// <summary>
        /// Fires when the grid's grouping changes (only applies for grids with a GroupingView)
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "groupField", typeof(string), "A string with the grouping field, null if the store is not grouped.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the grid's grouping changes (only applies for grids with a GroupingView)")]
        public virtual ComponentListener GroupChange
        {
            get
            {
                if (this.groupChange == null)
                {
                    this.groupChange = new ComponentListener();
                }

                return this.groupChange;
            }
        }

        private ComponentListener groupClick;

        /// <summary>
        /// Fires when group header is clicked. Only applies for grids with a GroupingView.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "groupField", typeof(string), "A string with the grouping field, null if the store is not grouped.")]
        [ListenerArgument(2, "groupValue")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is clicked. Only applies for grids with a GroupingView.")]
        public virtual ComponentListener GroupClick
        {
            get
            {
                if (this.groupClick == null)
                {
                    this.groupClick = new ComponentListener();
                }

                return this.groupClick;
            }
        }

        private ComponentListener groupContextMenu;

        /// <summary>
        /// Fires when group header is right clicked. Only applies for grids with a GroupingView.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "groupField", typeof(string), "A string with the grouping field, null if the store is not grouped.")]
        [ListenerArgument(2, "groupValue")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupcontextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is right clicked. Only applies for grids with a GroupingView.")]
        public virtual ComponentListener GroupContextMenu
        {
            get
            {
                if (this.groupContextMenu == null)
                {
                    this.groupContextMenu = new ComponentListener();
                }

                return this.groupContextMenu;
            }
        }

        private ComponentListener groupDblClick;

        /// <summary>
        /// Fires when group header is double clicked. Only applies for grids with a GroupingView.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "groupField", typeof(string), "A string with the grouping field, null if the store is not grouped.")]
        [ListenerArgument(2, "groupValue")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupdblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is double clicked. Only applies for grids with a GroupingView.")]
        public virtual ComponentListener GroupDblClick
        {
            get
            {
                if (this.groupDblClick == null)
                {
                    this.groupDblClick = new ComponentListener();
                }

                return this.groupDblClick;
            }
        }

        private ComponentListener groupMouseDown;

        /// <summary>
        /// Fires before a group header is clicked. Only applies for grids with a GroupingView.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "groupField", typeof(string), "A string with the grouping field, null if the store is not grouped.")]
        [ListenerArgument(2, "groupValue")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupmousedown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a group header is clicked. Only applies for grids with a GroupingView.")]
        public virtual ComponentListener GroupMouseDown
        {
            get
            {
                if (this.groupMouseDown == null)
                {
                    this.groupMouseDown = new ComponentListener();
                }

                return this.groupMouseDown;
            }
        }

        private ComponentListener headerClick;

        /// <summary>
        /// Fires when a header is clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "columnIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("headerclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a header is clicked.")]
        public virtual ComponentListener HeaderClick
        {
            get
            {
                if (this.headerClick == null)
                {
                    this.headerClick = new ComponentListener();
                }

                return this.headerClick;
            }
        }

        private ComponentListener headerContextMenu;

        /// <summary>
        /// Fires when a header is right clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "columnIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("headercontextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a header is right clicked.")]
        public virtual ComponentListener HeaderContextMenu
        {
            get
            {
                if (this.headerContextMenu == null)
                {
                    this.headerContextMenu = new ComponentListener();
                }

                return this.headerContextMenu;
            }
        }

        private ComponentListener headerDblClick;

        /// <summary>
        /// Fires when a header cell is double clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "columnIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("headerdblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a header cell is double clicked.")]
        public virtual ComponentListener HeaderDblClick
        {
            get
            {
                if (this.headerDblClick == null)
                {
                    this.headerDblClick = new ComponentListener();
                }

                return this.headerDblClick;
            }
        }

        private ComponentListener headerMouseDown;

        /// <summary>
        /// Fires before a header is clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "columnIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("headermousedown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a header is clicked.")]
        public virtual ComponentListener HeaderMouseDown
        {
            get
            {
                if (this.headerMouseDown == null)
                {
                    this.headerMouseDown = new ComponentListener();
                }

                return this.headerMouseDown;
            }
        }

        private ComponentListener keyDown;

        /// <summary>
        /// The raw keydown event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("keydown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw keydown event for the entire grid.")]
        public virtual ComponentListener KeyDown
        {
            get
            {
                if (this.keyDown == null)
                {
                    this.keyDown = new ComponentListener();
                }

                return this.keyDown;
            }
        }

        private ComponentListener keyPress;

        /// <summary>
        /// The raw keypress event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("keypress", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [Description("The raw keypress event for the entire grid.")]
        public virtual ComponentListener KeyPress
        {
            get
            {
                if (this.keyPress == null)
                {
                    this.keyPress = new ComponentListener();
                }

                return this.keyPress;
            }
        }

        private ComponentListener mouseDown;

        /// <summary>
        /// The raw mousedown event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mousedown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw mousedown event for the entire grid.")]
        public virtual ComponentListener MouseDown
        {
            get
            {
                if (this.mouseDown == null)
                {
                    this.mouseDown = new ComponentListener();
                }

                return this.mouseDown;
            }
        }

        private ComponentListener mouseOut;

        /// <summary>
        /// The raw mouseout event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseout", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw mouseout event for the entire grid.")]
        public virtual ComponentListener MouseOut
        {
            get
            {
                if (this.mouseOut == null)
                {
                    this.mouseOut = new ComponentListener();
                }

                return this.mouseOut;
            }
        }

        private ComponentListener mouseOver;

        /// <summary>
        /// The raw mouseover event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw mouseover event for the entire grid.")]
        public virtual ComponentListener MouseOver
        {
            get
            {
                if (this.mouseOver == null)
                {
                    this.mouseOver = new ComponentListener();
                }

                return this.mouseOver;
            }
        }

        private ComponentListener mouseUp;

        /// <summary>
        /// The raw mouseup event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseup", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw mouseup event for the entire grid.")]
        public virtual ComponentListener MouseUp
        {
            get
            {
                if (this.mouseUp == null)
                {
                    this.mouseUp = new ComponentListener();
                }

                return this.mouseUp;
            }
        }

        private ComponentListener reconfigure;

        /// <summary>
        /// Fires when the grid is reconfigured with a new store and/or column model.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "store", typeof(Store), "The new Store")]
        [ListenerArgument(2, "el", typeof(ColumnModel), "The new ColumnModel")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("reconfigure", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the grid is reconfigured with a new store and/or column model.")]
        public virtual ComponentListener Reconfigure
        {
            get
            {
                if (this.reconfigure == null)
                {
                    this.reconfigure = new ComponentListener();
                }

                return this.reconfigure;
            }
        }

        private ComponentListener rowBodyClick;

        /// <summary>
        /// Fires when the row body is clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowbodyclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the row body is clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>")]
        public virtual ComponentListener RowBodyClick
        {
            get
            {
                if (this.rowBodyClick == null)
                {
                    this.rowBodyClick = new ComponentListener();
                }

                return this.rowBodyClick;
            }
        }

        private ComponentListener rowBodyContextMenu;

        /// <summary>
        /// Fires when the row body is right clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowbodycontextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the row body is right clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>")]
        public virtual ComponentListener RowBodyContextMenu
        {
            get
            {
                if (this.rowBodyContextMenu == null)
                {
                    this.rowBodyContextMenu = new ComponentListener();
                }

                return this.rowBodyContextMenu;
            }
        }

        private ComponentListener rowBodyDblClick;

        /// <summary>
        /// Fires when the row body is double clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowbodydblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the row body is double clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>")]
        public virtual ComponentListener RowBodyDblClick
        {
            get
            {
                if (this.rowBodyDblClick == null)
                {
                    this.rowBodyDblClick = new ComponentListener();
                }

                return this.rowBodyDblClick;
            }
        }

        private ComponentListener rowBodyMouseDown;

        /// <summary>
        /// Fires before the row body is clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowbodymousedown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the row body is clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>")]
        public virtual ComponentListener RowBodyMouseDown
        {
            get
            {
                if (this.rowBodyMouseDown == null)
                {
                    this.rowBodyMouseDown = new ComponentListener();
                }

                return this.rowBodyMouseDown;
            }
        }

        private ComponentListener rowClick;

        /// <summary>
        /// Fires when a row is clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a row is clicked.")]
        public virtual ComponentListener RowClick
        {
            get
            {
                if (this.rowClick == null)
                {
                    this.rowClick = new ComponentListener();
                }

                return this.rowClick;
            }
        }

        private ComponentListener rowContextMenu;

        /// <summary>
        /// Fires when a row is right clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowcontextmenu", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a row is right clicked.")]
        public virtual ComponentListener RowContextMenu
        {
            get
            {
                if (this.rowContextMenu == null)
                {
                    this.rowContextMenu = new ComponentListener();
                }

                return this.rowContextMenu;
            }
        }

        private ComponentListener rowDblClick;

        /// <summary>
        /// Fires when a row is double clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowdblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a row is double clicked.")]
        public virtual ComponentListener RowDblClick
        {
            get
            {
                if (this.rowDblClick == null)
                {
                    this.rowDblClick = new ComponentListener();
                }

                return this.rowDblClick;
            }
        }

        private ComponentListener rowMouseDown;

        /// <summary>
        /// Fires before a row is clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowmousedown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a row is clicked.")]
        public virtual ComponentListener RowMouseDown
        {
            get
            {
                if (this.rowMouseDown == null)
                {
                    this.rowMouseDown = new ComponentListener();
                }

                return this.rowMouseDown;
            }
        }

        private ComponentListener sortChange;

        /// <summary>
        /// Fires when the grid's store sort changes.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "sortInfo")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("sortchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the grid's store sort changes.")]
        public virtual ComponentListener SortChange
        {
            get
            {
                if (this.sortChange == null)
                {
                    this.sortChange = new ComponentListener();
                }

                return this.sortChange;
            }
        }

        private ComponentListener viewReady;

        /// <summary>
        /// Fires when the grid view is available (use this for selecting a default row).
        /// </summary>
        [ListenerArgument(0, "el")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("viewready", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the grid view is available (use this for selecting a default row).")]
        public virtual ComponentListener ViewReady
        {
            get
            {
                if (this.viewReady == null)
                {
                    this.viewReady = new ComponentListener();
                }
                return this.viewReady;
            }
        }

        /* */

        private ComponentListener afterEdit;

        /// <summary>
        /// Fires after a cell is edited.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("afteredit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a cell is edited.")]
        public virtual ComponentListener AfterEdit
        {
            get
            {
                if (this.afterEdit == null)
                {
                    this.afterEdit = new ComponentListener();
                }

                return this.afterEdit;
            }
        }

        private ComponentListener beforeEdit;

        /// <summary>
        /// Fires after a cell is edited.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeedit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before cell editing is triggered.")]
        public virtual ComponentListener BeforeEdit
        {
            get
            {
                if (this.beforeEdit == null)
                {
                    this.beforeEdit = new ComponentListener();
                }

                return this.beforeEdit;
            }
        }

        private ComponentListener validateEdit;

        /// <summary>
        /// Fires after a cell is edited.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("validateedit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a cell is edited, but before the value is set in the record. Return false to cancel the change.")]
        public virtual ComponentListener ValidateEdit
        {
            get
            {
                if (this.validateEdit == null)
                {
                    this.validateEdit = new ComponentListener();
                }

                return this.validateEdit;
            }
        }

        private ComponentListener command;

        /// <summary>
        /// Fires when the command is clicked.
        /// </summary>
        [ListenerArgument(0, "command")]
        [ListenerArgument(1, "record")]
        [ListenerArgument(2, "rowIndex")]
        [ListenerArgument(3, "colIndex")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("command", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the command is clicked.")]
        public virtual ComponentListener Command
        {
            get
            {
                if (this.command == null)
                {
                    this.command = new ComponentListener();
                }

                return this.command;
            }
        }

        private ComponentListener groupCommand;

        /// <summary>
        /// Fires when the group command is clicked.
        /// </summary>
        [ListenerArgument(0, "command")]
        [ListenerArgument(1, "groupId")]
        [ListenerArgument(2, "records")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupcommand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the group command is clicked.")]
        public virtual ComponentListener GroupCommand
        {
            get
            {
                if (this.groupCommand == null)
                {
                    this.groupCommand = new ComponentListener();
                }

                return this.groupCommand;
            }
        }

        private ComponentListener filterUpdate;

        /// <summary>
        /// Fires when the grid's filter is updated.
        /// </summary>
        [ListenerArgument(0, "filtersPlugin")]
        [ListenerArgument(1, "filter")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("filterupdate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the grid's filter is updated.")]
        public virtual ComponentListener FilterUpdate
        {
            get
            {
                if (this.filterUpdate == null)
                {
                    this.filterUpdate = new ComponentListener();
                }
                return this.filterUpdate;
            }
        }
    }
}