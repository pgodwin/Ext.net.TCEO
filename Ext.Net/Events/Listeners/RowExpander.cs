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
    public partial class RowExpanderListeners : ComponentBaseListeners
    {
        private ComponentListener beforeExpand;

        /// <summary>
        /// Fires before a row expand
        /// </summary>
        [ListenerArgument(0, "item", typeof(RowExpander), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "body", typeof(object))]
        [ListenerArgument(3, "rowIndex", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeexpand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a row expand")]
        public virtual ComponentListener BeforeExpand
        {
            get
            {
                if (this.beforeExpand == null)
                {
                    this.beforeExpand = new ComponentListener();
                }

                return this.beforeExpand;
            }
        }

        private ComponentListener expand;

        /// <summary>
        /// Fires afyter a row expand
        /// </summary>
        [ListenerArgument(0, "item", typeof(RowExpander), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "body", typeof(object))]
        [ListenerArgument(3, "rowIndex", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("expand", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires afyter a row expand")]
        public virtual ComponentListener Expand
        {
            get
            {
                if (this.expand == null)
                {
                    this.expand = new ComponentListener();
                }

                return this.expand;
            }
        }

        private ComponentListener beforeCollapse;

        /// <summary>
        /// Fires before a row collapse
        /// </summary>
        [ListenerArgument(0, "item", typeof(RowExpander), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "body", typeof(object))]
        [ListenerArgument(3, "rowIndex", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforecollapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a row collapse")]
        public virtual ComponentListener BeforeCollapse
        {
            get
            {
                if (this.beforeCollapse == null)
                {
                    this.beforeCollapse = new ComponentListener();
                }

                return this.beforeCollapse;
            }
        }

        private ComponentListener collapse;

        /// <summary>
        /// Fires after a row collapse
        /// </summary>
        [ListenerArgument(0, "item", typeof(RowExpander), "this")]
        [ListenerArgument(1, "record", typeof(object))]
        [ListenerArgument(2, "body", typeof(object))]
        [ListenerArgument(3, "rowIndex", typeof(object))]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("collapse", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a row collapse")]
        public virtual ComponentListener Collapse
        {
            get
            {
                if (this.collapse == null)
                {
                    this.collapse = new ComponentListener();
                }

                return this.collapse;
            }
        }
    }
}