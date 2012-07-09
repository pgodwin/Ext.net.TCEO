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
    public partial class RowEditorListeners : ComponentListeners
    {
        private ComponentListener afterEdit;

        /// <summary>
        /// Fired after a row is edited and passes validation.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "o", typeof(object), "Object with changes made to the record.")]
        [ListenerArgument(2, "r", typeof(object), "The Record that was edited")]
        [ListenerArgument(3, "rowIndex", typeof(object), "The rowIndex of the row just edited")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("afteredit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a row is edited and passes validation.")]
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
        /// Fired before the row editor is activated.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "rowIndex")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeedit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired before the row editor is activated.")]
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

        private ComponentListener cancelEdit;

        /// <summary>
        /// Fired when the editor is cancelled.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "forced")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("canceledit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired when the editor is cancelled.")]
        public virtual ComponentListener CancelEdit
        {
            get
            {
                if (this.cancelEdit == null)
                {
                    this.cancelEdit = new ComponentListener();
                }

                return this.cancelEdit;
            }
        }

        private ComponentListener validateEdit;

        /// <summary>
        /// Fired after a row is edited and passes validation.
        /// </summary>
        [ListenerArgument(0, "el")]
        [ListenerArgument(1, "o", typeof(object), "Object with changes made to the record.")]
        [ListenerArgument(2, "r", typeof(object), "The Record that was edited")]
        [ListenerArgument(3, "rowIndex", typeof(object), "The rowIndex of the row just edited")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("validateedit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired after a row is edited and passes validation.")]
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

        private ComponentListener preEdit;

        /// <summary>
        /// Fired for each field's value.
        /// </summary>
        [ListenerArgument(0, "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("preedit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fired for each field's value.")]
        public virtual ComponentListener PreEdit
        {
            get
            {
                if (this.preEdit == null)
                {
                    this.preEdit = new ComponentListener();
                }

                return this.preEdit;
            }
        }
    }
}