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
    public partial class ColumnListeners : ComponentBaseListeners
    {
        private ComponentListener columnMoved;

        /// <summary>
        /// Fires when a column is moved.
        /// </summary>
        [ListenerArgument(0, "item", typeof(ColumnModel), "this")]
        [ListenerArgument(1, "oldIndex", typeof(int), "")]
        [ListenerArgument(2, "newIndex", typeof(int), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("columnmoved", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a column is moved.")]
        public virtual ComponentListener ColumnMoved 
        {
            get
            {
                if (this.columnMoved == null)
                {
                    this.columnMoved = new ComponentListener();
                }

                return this.columnMoved;
            }
        }

        private ComponentListener configChanged;

        /// <summary>
        /// Fires when the configuration is changed
        /// </summary>
        [ListenerArgument(0, "item", typeof(ColumnModel), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("configchanged", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the configuration is changed.")]
        public virtual ComponentListener ConfigChanged
        {
            get
            {
                if (this.configChanged == null)
                {
                    this.configChanged = new ComponentListener();
                }

                return this.configChanged;
            }
        }

        private ComponentListener headerChange;

        /// <summary>
        /// Fires when the text of a header changes.
        /// </summary>
        [ListenerArgument(0, "item", typeof(ColumnModel), "this")]
        [ListenerArgument(1, "columnIndex", typeof(int), "")]
        [ListenerArgument(2, "newText", typeof(string), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("headerchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the text of a header changes.")]
        public virtual ComponentListener HeaderChange
        {
            get
            {
                if (this.headerChange == null)
                {
                    this.headerChange = new ComponentListener();
                }

                return this.headerChange;
            }
        }

        private ComponentListener hiddenChange;

        /// <summary>
        /// Fires when a column is hidden or "unhidden".
        /// </summary>
        [ListenerArgument(0, "item", typeof(ColumnModel), "this")]
        [ListenerArgument(1, "columnIndex", typeof(int), "")]
        [ListenerArgument(2, "hidden", typeof(bool), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("hiddenchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a column is hidden or 'unhidden'.")]
        public virtual ComponentListener HiddenChange
        {
            get
            {
                if (this.hiddenChange == null)
                {
                    this.hiddenChange = new ComponentListener();
                }

                return this.hiddenChange;
            }
        }

        private ComponentListener widthChange;

        /// <summary>
        /// Fires when the width of a column is programmaticially changed using setColumnWidth. Note internal resizing suppresses the event from firing. 
        /// </summary>
        [ListenerArgument(0, "item", typeof(ColumnModel), "this")]
        [ListenerArgument(1, "columnIndex", typeof(int), "")]
        [ListenerArgument(2, "newWidth", typeof(int), "")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("widthchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the width of a column is programmaticially changed using setColumnWidth. Note internal resizing suppresses the event from firing. ")]
        public virtual ComponentListener WidthChange
        {
            get
            {
                if (this.widthChange == null)
                {
                    this.widthChange = new ComponentListener();
                }

                return this.widthChange;
            }
        }
    }
}