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
    public partial class GridPanelDirectEvents : PanelDirectEvents
    {
        private ComponentDirectEvent bodyScroll;

        /// <summary>
        /// Fires when the body element is scrolled.
        /// </summary>
        [ListenerArgument(0, "scrollLeft")]
        [ListenerArgument(1, "scrollTop")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("bodyscroll", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the body element is scrolled.")]
        public virtual ComponentDirectEvent BodyScroll
        {
            get
            {
                if (this.bodyScroll == null)
                {
                    this.bodyScroll = new ComponentDirectEvent();
                }

                return this.bodyScroll;
            }
        }

        private ComponentDirectEvent cellClick;

        /// <summary>
        /// Fires when a cell is clicked. The data for the cell is drawn from the Record for this row.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "columnIndex")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("cellclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a cell is clicked. The data for the cell is drawn from the Record for this row.")]
        public virtual ComponentDirectEvent CellClick
        {
            get
            {
                if (this.cellClick == null)
                {
                    this.cellClick = new ComponentDirectEvent();
                }

                return this.cellClick;
            }
        }

        private ComponentDirectEvent cellContextMenu;

        /// <summary>
        /// Fires when a cell is right clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "cellIndex")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("cellcontextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a cell is right clicked.")]
        public virtual ComponentDirectEvent CellContextMenu
        {
            get
            {
                if (this.cellContextMenu == null)
                {
                    this.cellContextMenu = new ComponentDirectEvent();
                }

                return this.cellContextMenu;
            }
        }

        private ComponentDirectEvent cellDblClick;

        /// <summary>
        /// Fires when a cell is double clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "columnIndex")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("celldblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a cell is double clicked.")]
        public virtual ComponentDirectEvent CellDblClick
        {
            get
            {
                if (this.cellDblClick == null)
                {
                    this.cellDblClick = new ComponentDirectEvent();
                }

                return this.cellDblClick;
            }
        }

        private ComponentDirectEvent cellMouseDown;

        /// <summary>
        /// Fires before a cell is clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "columnIndex")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("cellMouseDown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a cell is clicked.")]
        public virtual ComponentDirectEvent CellMouseDown
        {
            get
            {
                if (this.cellMouseDown == null)
                {
                    this.cellMouseDown = new ComponentDirectEvent();
                }

                return this.cellMouseDown;
            }
        }

        private ComponentDirectEvent click;

        /// <summary>
        /// The raw click event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw click event for the entire grid.")]
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

        private ComponentDirectEvent columnMove;

        /// <summary>
        /// Fires when the user moves a column.
        /// </summary>
        [ListenerArgument(0, "oldIndex")]
        [ListenerArgument(1, "newIndex")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("columnmove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the user moves a column.")]
        public virtual ComponentDirectEvent ColumnMove
        {
            get
            {
                if (this.columnMove == null)
                {
                    this.columnMove = new ComponentDirectEvent();
                }

                return this.columnMove;
            }
        }

        private ComponentDirectEvent columnResize;

        /// <summary>
        /// Fires when the user resizes a column.
        /// </summary>
        [ListenerArgument(0, "columnIndex")]
        [ListenerArgument(1, "newSize")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("columnresize", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the user resizes a column.")]
        public virtual ComponentDirectEvent ColumnResize
        {
            get
            {
                if (this.columnResize == null)
                {
                    this.columnResize = new ComponentDirectEvent();
                }

                return this.columnResize;
            }
        }

        private ComponentDirectEvent containerClick;

        /// <summary>
        /// Fires when the container is clicked. The container consists of any part of the grid body that is not covered by a row.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containerclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the container is clicked. The container consists of any part of the grid body that is not covered by a row.")]
        public virtual ComponentDirectEvent ContainerClick
        {
            get
            {
                if (this.containerClick == null)
                {
                    this.containerClick = new ComponentDirectEvent();
                }

                return this.containerClick;
            }
        }

        private ComponentDirectEvent containerContextMenu;

        /// <summary>
        /// Fires when the container is right clicked. The container consists of any part of the grid body that is not covered by a row.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containercontextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the container is right clicked. The container consists of any part of the grid body that is not covered by a row.")]
        public virtual ComponentDirectEvent ContainerContextMenu
        {
            get
            {
                if (this.containerContextMenu == null)
                {
                    this.containerContextMenu = new ComponentDirectEvent();
                }

                return this.containerContextMenu;
            }
        }

        private ComponentDirectEvent containerDblClick;

        /// <summary>
        /// Fires when the container is double clicked. The container consists of any part of the grid body that is not covered by a row.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containerdblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the container is double clicked. The container consists of any part of the grid body that is not covered by a row.")]
        public virtual ComponentDirectEvent ContainerDblClick
        {
            get
            {
                if (this.containerDblClick == null)
                {
                    this.containerDblClick = new ComponentDirectEvent();
                }

                return this.containerDblClick;
            }
        }

        private ComponentDirectEvent containerMouseDown;

        /// <summary>
        /// Fires before the container is clicked. The container consists of any part of the grid body that is not covered by a row.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("containermousedown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the container is clicked. The container consists of any part of the grid body that is not covered by a row.")]
        public virtual ComponentDirectEvent ContainerMouseDown
        {
            get
            {
                if (this.containerMouseDown == null)
                {
                    this.containerMouseDown = new ComponentDirectEvent();
                }

                return this.containerMouseDown;
            }
        }

        private ComponentDirectEvent contextMenu;

        /// <summary>
        /// The raw contextmenu event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("contextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw contextmenu event for the entire grid.")]
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
        /// The raw dblclick event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw dblclick event for the entire grid.")]
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

        private ComponentDirectEvent groupChange;

        /// <summary>
        /// Fires when the grid's grouping changes (only applies for grids with a GroupingView)
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "groupField", typeof(string), "A string with the grouping field, null if the store is not grouped.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the grid's grouping changes (only applies for grids with a GroupingView)")]
        public virtual ComponentDirectEvent GroupChange
        {
            get
            {
                if (this.groupChange == null)
                {
                    this.groupChange = new ComponentDirectEvent();
                }

                return this.groupChange;
            }
        }

        private ComponentDirectEvent groupClick;

        /// <summary>
        /// Fires when group header is clicked. Only applies for grids with a GroupingView.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "groupField", typeof(string), "A string with the grouping field, null if the store is not grouped.")]
        [ListenerArgument(2, "groupValue")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is clicked. Only applies for grids with a GroupingView.")]
        public virtual ComponentDirectEvent GroupClick
        {
            get
            {
                if (this.groupClick == null)
                {
                    this.groupClick = new ComponentDirectEvent();
                }

                return this.groupClick;
            }
        }

        private ComponentDirectEvent groupContextMenu;

        /// <summary>
        /// Fires when group header is right clicked. Only applies for grids with a GroupingView.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "groupField", typeof(string), "A string with the grouping field, null if the store is not grouped.")]
        [ListenerArgument(2, "groupValue")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupcontextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is clicked. Only applies for grids with a GroupingView.")]
        public virtual ComponentDirectEvent GroupContextMenu
        {
            get
            {
                if (this.groupContextMenu == null)
                {
                    this.groupContextMenu = new ComponentDirectEvent();
                }

                return this.groupContextMenu;
            }
        }

        private ComponentDirectEvent groupDblClick;

        /// <summary>
        /// Fires when group header is double clicked. Only applies for grids with a GroupingView.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "groupField", typeof(string), "A string with the grouping field, null if the store is not grouped.")]
        [ListenerArgument(2, "groupValue")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupdblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when group header is double clicked. Only applies for grids with a GroupingView.")]
        public virtual ComponentDirectEvent GroupDblClick
        {
            get
            {
                if (this.groupDblClick == null)
                {
                    this.groupDblClick = new ComponentDirectEvent();
                }

                return this.groupDblClick;
            }
        }

        private ComponentDirectEvent groupMouseDown;

        /// <summary>
        /// Fires before a group header is clicked. Only applies for grids with a GroupingView.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "groupField", typeof(string), "A string with the grouping field, null if the store is not grouped.")]
        [ListenerArgument(2, "groupValue")]
        [ListenerArgument(3, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupmousedown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a group header is clicked. Only applies for grids with a GroupingView.")]
        public virtual ComponentDirectEvent GroupMouseDown
        {
            get
            {
                if (this.groupMouseDown == null)
                {
                    this.groupMouseDown = new ComponentDirectEvent();
                }

                return this.groupMouseDown;
            }
        }

        private ComponentDirectEvent headerClick;

        /// <summary>
        /// Fires when a header is clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "columnIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("headerclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a header is clicked.")]
        public virtual ComponentDirectEvent HeaderClick
        {
            get
            {
                if (this.headerClick == null)
                {
                    this.headerClick = new ComponentDirectEvent();
                }

                return this.headerClick;
            }
        }

        private ComponentDirectEvent headerContextMenu;

        /// <summary>
        /// Fires when a header is right clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "columnIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("headercontextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a header is right clicked.")]
        public virtual ComponentDirectEvent HeaderContextMenu
        {
            get
            {
                if (this.headerContextMenu == null)
                {
                    this.headerContextMenu = new ComponentDirectEvent();
                }

                return this.headerContextMenu;
            }
        }

        private ComponentDirectEvent headerDblClick;

        /// <summary>
        /// Fires when a header cell is double clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "columnIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("headerdblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a header cell is double clicked.")]
        public virtual ComponentDirectEvent HeaderDblClick
        {
            get
            {
                if (this.headerDblClick == null)
                {
                    this.headerDblClick = new ComponentDirectEvent();
                }

                return this.headerDblClick;
            }
        }

        private ComponentDirectEvent headerMouseDown;

        /// <summary>
        /// Fires before a header is clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "columnIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("headermousedown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a header is clicked.")]
        public virtual ComponentDirectEvent HeaderMouseDown
        {
            get
            {
                if (this.headerMouseDown == null)
                {
                    this.headerMouseDown = new ComponentDirectEvent();
                }

                return this.headerMouseDown;
            }
        }

        private ComponentDirectEvent keyDown;

        /// <summary>
        /// The raw keydown event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("keydown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw keydown event for the entire grid.")]
        public virtual ComponentDirectEvent KeyDown
        {
            get
            {
                if (this.keyDown == null)
                {
                    this.keyDown = new ComponentDirectEvent();
                }

                return this.keyDown;
            }
        }

        private ComponentDirectEvent keyPress;

        /// <summary>
        /// The raw keypress event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("keypress", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [Description("The raw keypress event for the entire grid.")]
        public virtual ComponentDirectEvent KeyPress
        {
            get
            {
                if (this.keyPress == null)
                {
                    this.keyPress = new ComponentDirectEvent();
                }

                return this.keyPress;
            }
        }

        private ComponentDirectEvent mouseDown;

        /// <summary>
        /// The raw mousedown event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mousedown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw mousedown event for the entire grid.")]
        public virtual ComponentDirectEvent MouseDown
        {
            get
            {
                if (this.mouseDown == null)
                {
                    this.mouseDown = new ComponentDirectEvent();
                }

                return this.mouseDown;
            }
        }

        private ComponentDirectEvent mouseOut;

        /// <summary>
        /// The raw mouseout event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseout", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw mouseout event for the entire grid.")]
        public virtual ComponentDirectEvent MouseOut
        {
            get
            {
                if (this.mouseOut == null)
                {
                    this.mouseOut = new ComponentDirectEvent();
                }

                return this.mouseOut;
            }
        }

        private ComponentDirectEvent mouseOver;

        /// <summary>
        /// The raw mouseover event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseover", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw mouseover event for the entire grid.")]
        public virtual ComponentDirectEvent MouseOver
        {
            get
            {
                if (this.mouseOver == null)
                {
                    this.mouseOver = new ComponentDirectEvent();
                }

                return this.mouseOver;
            }
        }

        private ComponentDirectEvent mouseUp;

        /// <summary>
        /// The raw mouseup event for the entire grid.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseup", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The raw mouseup event for the entire grid.")]
        public virtual ComponentDirectEvent MouseUp
        {
            get
            {
                if (this.mouseUp == null)
                {
                    this.mouseUp = new ComponentDirectEvent();
                }

                return this.mouseUp;
            }
        }

            private ComponentDirectEvent reconfigure;

            /// <summary>
            /// Fires when the grid is reconfigured with a new store and/or column model.
            /// </summary>
            [ListenerArgument(0, "el")]
            [ListenerArgument(1, "store", typeof(Store), "The new Store")]
            [ListenerArgument(2, "el", typeof(ColumnModel), "The new ColumnModel")]
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [ConfigOption("reconfigure", typeof(DirectEventJsonConverter))]
            [PersistenceMode(PersistenceMode.InnerProperty)]
            [NotifyParentProperty(true)]
            [Description("Fires when the grid is reconfigured with a new store and/or column model.")]
            public virtual ComponentDirectEvent Reconfigure
            {
                get
                {
                    if (this.reconfigure == null)
                    {
                        this.reconfigure = new ComponentDirectEvent();
                    }

                    return this.reconfigure;
                }
            }

        private ComponentDirectEvent rowBodyClick;

        /// <summary>
        /// Fires when the row body is clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowbodyclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the row body is clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>")]
        public virtual ComponentDirectEvent RowBodyClick
        {
            get
            {
                if (this.rowBodyClick == null)
                {
                    this.rowBodyClick = new ComponentDirectEvent();
                }

                return this.rowBodyClick;
            }
        }

        private ComponentDirectEvent rowBodyContextMenu;

        /// <summary>
        /// Fires when the row body is right clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowbodycontextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the row body is right clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>")]
        public virtual ComponentDirectEvent RowBodyContextMenu
        {
            get
            {
                if (this.rowBodyContextMenu == null)
                {
                    this.rowBodyContextMenu = new ComponentDirectEvent();
                }

                return this.rowBodyContextMenu;
            }
        }

        private ComponentDirectEvent rowBodyDblClick;

        /// <summary>
        /// Fires when the row body is double clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowbodydblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the row body is double clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>")]
        public virtual ComponentDirectEvent RowBodyDblClick
        {
            get
            {
                if (this.rowBodyDblClick == null)
                {
                    this.rowBodyDblClick = new ComponentDirectEvent();
                }

                return this.rowBodyDblClick;
            }
        }
        
        private ComponentDirectEvent rowBodyMouseDown;

        /// <summary>
        /// Fires before the row body is clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowbodymousedown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the row body is clicked. <b>Only applies for grids with {@link Ext.grid.GridView#enableRowBody enableRowBody} configured.</b>")]
        public virtual ComponentDirectEvent RowBodyMouseDown
        {
            get
            {
                if (this.rowBodyMouseDown == null)
                {
                    this.rowBodyMouseDown = new ComponentDirectEvent();
                }

                return this.rowBodyMouseDown;
            }
        }

        private ComponentDirectEvent rowClick;

        /// <summary>
        /// Fires when a row is clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a row is clicked.")]
        public virtual ComponentDirectEvent RowClick
        {
            get
            {
                if (this.rowClick == null)
                {
                    this.rowClick = new ComponentDirectEvent();
                }

                return this.rowClick;
            }
        }

        private ComponentDirectEvent rowContextMenu;

        /// <summary>
        /// Fires when a row is right clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowcontextmenu", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a row is right clicked.")]
        public virtual ComponentDirectEvent RowContextMenu
        {
            get
            {
                if (this.rowContextMenu == null)
                {
                    this.rowContextMenu = new ComponentDirectEvent();
                }

                return this.rowContextMenu;
            }
        }

        private ComponentDirectEvent rowDblClick;

        /// <summary>
        /// Fires when a row is double clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowdblclick", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a row is double clicked.")]
        public virtual ComponentDirectEvent RowDblClick
        {
            get
            {
                if (this.rowDblClick == null)
                {
                    this.rowDblClick = new ComponentDirectEvent();
                }

                return this.rowDblClick;
            }
        }

        private ComponentDirectEvent rowMouseDown;

        /// <summary>
        /// Fires before a row is clicked.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "rowIndex")]
        [ListenerArgument(2, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowmousedown", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a row is clicked.")]
        public virtual ComponentDirectEvent RowMouseDown
        {
            get
            {
                if (this.rowMouseDown == null)
                {
                    this.rowMouseDown = new ComponentDirectEvent();
                }

                return this.rowMouseDown;
            }
        }

        private ComponentDirectEvent sortChange;

        /// <summary>
        /// Fires when the grid's store sort changes.
        /// </summary>
        [ListenerArgument(0, "item", typeof(GridPanel))]
        [ListenerArgument(1, "sortInfo")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("sortchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the grid's store sort changes.")]
        public virtual ComponentDirectEvent SortChange
        {
            get
            {
                if (this.sortChange == null)
                {
                    this.sortChange = new ComponentDirectEvent();
                }

                return this.sortChange;
            }
        }

        private ComponentDirectEvent viewReady;

        /// <summary>
        /// Fires when the grid view is available (use this for selecting a default row).
        /// </summary>
        [ListenerArgument(0, "el")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("viewready", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the grid view is available (use this for selecting a default row).")]
        public virtual ComponentDirectEvent ViewReady
        {
            get
            {
                if (this.viewReady == null)
                {
                    this.viewReady = new ComponentDirectEvent();
                }

                return this.viewReady;
            }
        }

        /* */

        private ComponentDirectEvent afterEdit;

        /// <summary>
        /// Fires after a cell is edited.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("afteredit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a cell is edited.")]
        public virtual ComponentDirectEvent AfterEdit
        {
            get
            {
                if (this.afterEdit == null)
                {
                    this.afterEdit = new ComponentDirectEvent();
                }

                return this.afterEdit;
            }
        }

        private ComponentDirectEvent beforeEdit;

        /// <summary>
        /// Fires before cell editing is triggered.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeedit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before cell editing is triggered.")]
        public virtual ComponentDirectEvent BeforeEdit
        {
            get
            {
                if (this.beforeEdit == null)
                {
                    this.beforeEdit = new ComponentDirectEvent();
                }

                return this.beforeEdit;
            }
        }

        private ComponentDirectEvent validateEdit;

        /// <summary>
        /// Fires after a cell is edited, but before the value is set in the record. Return false to cancel the change.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("validateedit", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a cell is edited, but before the value is set in the record. Return false to cancel the change.")]
        public virtual ComponentDirectEvent ValidateEdit
        {
            get
            {
                if (this.validateEdit == null)
                {
                    this.validateEdit = new ComponentDirectEvent();
                }

                return this.validateEdit;
            }
        }

        private ComponentDirectEvent command;

        /// <summary>
        /// Fires when the command is clicked.
        /// </summary>
        [ListenerArgument(0, "command")]
        [ListenerArgument(1, "record")]
        [ListenerArgument(2, "rowIndex")]
        [ListenerArgument(3, "colIndex")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("command", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the command is clicked.")]
        public virtual ComponentDirectEvent Command
        {
            get
            {
                if (this.command == null)
                {
                    this.command = new ComponentDirectEvent();
                }

                return this.command;
            }
        }

        private ComponentDirectEvent groupCommand;

        /// <summary>
        /// Fires when the group command is clicked.
        /// </summary>
        [ListenerArgument(0, "command")]
        [ListenerArgument(1, "groupId")]
        [ListenerArgument(2, "records")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupcommand", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the group command is clicked.")]
        public virtual ComponentDirectEvent GroupCommand
        {
            get
            {
                if (this.groupCommand == null)
                {
                    this.groupCommand = new ComponentDirectEvent();
                }

                return this.groupCommand;
            }
        }

        private ComponentDirectEvent filterUpdate;

        /// <summary>
        /// Fires when the grid's filter is updated.
        /// </summary>
        [ListenerArgument(0, "filtersPlugin")]
        [ListenerArgument(1, "filter")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("filterupdate", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the grid's filter is updated.")]
        public virtual ComponentDirectEvent FilterUpdate
        {
            get
            {
                if (this.filterUpdate == null)
                {
                    this.filterUpdate = new ComponentDirectEvent();
                }
                return this.filterUpdate;
            }
        }
    }
}