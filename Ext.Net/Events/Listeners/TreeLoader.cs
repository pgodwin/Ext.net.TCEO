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
    public partial class TreeLoaderListeners : ComponentListeners
    {
        private ComponentListener beforeLoad;

        /// <summary>
        /// Fires before a network request is made to retrieve the Json text which specifies a node's children.
        /// </summary>
        [ListenerArgument(0, "loader", typeof(TreeLoader), "this")]
        [ListenerArgument(1, "node", typeof(Node))]
        [ListenerArgument(2, "callback")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeload", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a network request is made to retrieve the Json text which specifies a node's children.")]
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

        private ComponentListener load;

        /// <summary>
        /// Fires when the node has been successfuly loaded.
        /// </summary>
        [ListenerArgument(0, "loader", typeof(TreeLoader), "this")]
        [ListenerArgument(1, "node", typeof(Node))]
        [ListenerArgument(2, "response")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("load", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the node has been successfuly loaded.")]
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

        private ComponentListener loadException;

        /// <summary>
        /// Fires if the network request failed.
        /// </summary>
        [ListenerArgument(0, "loader", typeof(TreeLoader), "this")]
        [ListenerArgument(1, "node", typeof(Node))]
        [ListenerArgument(2, "response")]
        [ListenerArgument(3, "errorMessage")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("loadexception", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires if the network request failed.")]
        public virtual ComponentListener LoadException
        {
            get
            {
                if (this.loadException == null)
                {
                    this.loadException = new ComponentListener();
                }

                return this.loadException;
            }
        }
    }
}