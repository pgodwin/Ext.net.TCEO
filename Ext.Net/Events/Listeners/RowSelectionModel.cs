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
    public partial class RowSelectionModelListeners : ComponentBaseListeners
    {
        private ComponentListener beforeRowSelect;

        /// <summary>
        /// Fires when a row is being selected, return false to cancel.
        /// </summary>
        [ListenerArgument(0, "item", typeof(RowSelectionModel), "SelectionModel")]
        [ListenerArgument(1, "rowIndex", typeof(int), "The selected index")]
        [ListenerArgument(2, "keepExisting", typeof(bool), "False if other selections will be cleared")]
        [ListenerArgument(3, "record", typeof(object), "The record to be selected")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforerowselect", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a row is being selected, return false to cancel.")]
        public virtual ComponentListener BeforeRowSelect
        {
            get
            {
                if (this.beforeRowSelect == null)
                {
                    this.beforeRowSelect = new ComponentListener();
                }

                return this.beforeRowSelect;
            }
        }

        private ComponentListener rowDeselect;

        /// <summary>
        /// Fires when a row is deselected.
        /// </summary>
        [ListenerArgument(0, "item", typeof(RowSelectionModel), "SelectionModel")]
        [ListenerArgument(1, "rowIndex", typeof(int), "The selected index")]
        [ListenerArgument(2, "record", typeof(object), "The selected record")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowdeselect", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a row is deselected.")]
        public virtual ComponentListener RowDeselect
        {
            get
            {
                if (this.rowDeselect == null)
                {
                    this.rowDeselect = new ComponentListener();
                }

                return this.rowDeselect;
            }
        }

        private ComponentListener rowSelect;

        /// <summary>
        /// Fires when a row is selected.
        /// </summary>
        [ListenerArgument(0, "item", typeof(RowSelectionModel), "SelectionModel")]
        [ListenerArgument(1, "rowIndex", typeof(int), "The selected index")]
        [ListenerArgument(2, "record", typeof(object), "The selected record")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("rowselect", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a row is selected.")]
        public virtual ComponentListener RowSelect
        {
            get
            {
                if (this.rowSelect == null)
                {
                    this.rowSelect = new ComponentListener();
                }

                return this.rowSelect;
            }
        }

        private ComponentListener selectionChange;

        /// <summary>
        /// Fires when the selection changes
        /// </summary>
        [ListenerArgument(0, "item", typeof(RowSelectionModel), "SelectionModel")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("selectionchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the selection changes.")]
        public virtual ComponentListener SelectionChange
        {
            get
            {
                if (this.selectionChange == null)
                {
                    this.selectionChange = new ComponentListener();
                }

                return this.selectionChange;
            }
        }

        private ComponentListener beforeCheckAllClick;

        /// <summary>
        /// Fires when click on the check all
        /// </summary>
        [ListenerArgument(0, "item", typeof(RowSelectionModel), "SelectionModel")]
        [ListenerArgument(1, "checked", typeof(bool), "checked state")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecheckallclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when click on the check all.")]
        public virtual ComponentListener BeforeCheckAllClick
        {
            get
            {
                if (this.beforeCheckAllClick == null)
                {
                    this.beforeCheckAllClick = new ComponentListener();
                }

                return this.beforeCheckAllClick;
            }
        }

        private ComponentListener afterCheckAllClick;

        /// <summary>
        /// Fires when click on the check all
        /// </summary>
        [ListenerArgument(0, "item", typeof(RowSelectionModel), "SelectionModel")]
        [ListenerArgument(1, "checked", typeof(bool), "checked state")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("aftercheckallclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when click on the check all.")]
        public virtual ComponentListener AfterCheckAllClick
        {
            get
            {
                if (this.afterCheckAllClick == null)
                {
                    this.afterCheckAllClick = new ComponentListener();
                }

                return this.afterCheckAllClick;
            }
        }
    }
}