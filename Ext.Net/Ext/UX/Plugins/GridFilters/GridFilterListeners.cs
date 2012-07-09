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
 ********/using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
    [ToolboxItem(false)]
    [TypeConverter(typeof(ListenersConverter))]
    public partial class GridFilterListeners : ComponentListeners
    {
        private ComponentListener activate;

        /// <summary>
        /// Fires when an inactive filter becomes active
        /// </summary>
        [ListenerArgument(0, "filter", typeof(object), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("activate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an inactive filter becomes active")]
        public virtual ComponentListener Activate
        {
            get
            {
                if (this.activate == null)
                {
                    this.activate = new ComponentListener();
                }

                return this.activate;
            }
        }

        private ComponentListener deactivate;

        /// <summary>
        /// Fires when an active filter becomes inactive
        /// </summary>
        [ListenerArgument(0, "filter", typeof(object), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("deactivate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when an active filter becomes inactive")]
        public virtual ComponentListener Deactivate
        {
            get
            {
                if (this.deactivate == null)
                {
                    this.deactivate = new ComponentListener();
                }

                return this.deactivate;
            }
        }

        private ComponentListener serialize;

        /// <summary>
        /// Fires after the serialization process. Use this to attach additional parameters to serialization
        /// data before it is encoded and sent to the server.
        /// </summary>
        [ListenerArgument(0, "data", typeof(object), "A map or collection of maps representing the current filter configuration.")]
        [ListenerArgument(1, "filter", typeof(object), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("serialize", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after the serialization process. Use this to attach additional parameters to serialization data before it is encoded and sent to the server.")]
        public virtual ComponentListener Serialize
        {
            get
            {
                if (this.serialize == null)
                {
                    this.serialize = new ComponentListener();
                }

                return this.serialize;
            }
        }

        private ComponentListener update;

        /// <summary>
        /// Fires when a filter configuration has changed
        /// </summary>
        [ListenerArgument(0, "filter", typeof(object), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("update", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a filter configuration has changed")]
        public virtual ComponentListener Update
        {
            get
            {
                if (this.update == null)
                {
                    this.update = new ComponentListener();
                }

                return this.update;
            }
        }
    }
}