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
    [ToolboxItem(false)]
    [TypeConverter(typeof(ListenersConverter))]
    public partial class DataProxyListeners : ComponentListeners
    {
        private ComponentListener beforeLoad;

        /// <summary>
        /// Fires before a request to retrieve a data object.
        /// </summary>
        [ListenerArgument(0, "proxy", typeof(DataProxy), "The proxy for the request")]
        [ListenerArgument(1, "params", typeof(object), "The params object passed to the request function")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeload", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a request to retrieve a data object.")]
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

        private ComponentListener beforeWrite;

        /// <summary>
        /// Fires before a request is generated for one of the actions Ext.data.Api.actions.create|update|destroy
        /// In addition to being fired through the DataProxy instance that raised the event, this event is also fired through the Ext.data.DataProxy class to allow for centralized processing of beforewrite events from all DataProxies by attaching a listener to the Ext.data.DataProxy class itself.
        /// </summary>
        [ListenerArgument(0, "proxy", typeof(DataProxy), "The proxy for the request")]
        [ListenerArgument(1, "action", typeof(string), "[Ext.data.Api.actions.create|update|destroy]")]
        [ListenerArgument(2, "rs", typeof(object), "The Record(s) to create|update|destroy.")]
        [ListenerArgument(3, "params", typeof(object), "The request params object. Edit params to add parameters to the request.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforewrite", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a request is generated for one of the actions Ext.data.Api.actions.create|update|destroy")]
        public virtual ComponentListener BeforeWrite
        {
            get
            {
                if (this.beforeWrite == null)
                {
                    this.beforeWrite = new ComponentListener();
                }

                return this.beforeWrite;
            }
        }

        private ComponentListener exception;

        /// <summary>
        /// Fires if an exception occurs in the Proxy during a remote request. This event is relayed through a corresponding Ext.data.Store.exception, so any Store instance may observe this event.
        /// In addition to being fired through the DataProxy instance that raised the event, this event is also fired through the Ext.data.DataProxy class to allow for centralized processing of exception events from all DataProxies by attaching a listener to the Ext.data.DataProxy class itself.
        /// </summary>
        [ListenerArgument(0, "proxy", typeof(DataProxy), "The proxy for the request")]
        [ListenerArgument(1, "type", typeof(string), "The value of this parameter will be either 'response' or 'remote'.")]
        [ListenerArgument(2, "action", typeof(string), "Name of the action (see Ext.data.Api.actions)")]
        [ListenerArgument(3, "options", typeof(object), "The options for the action that were specified in the request.")]
        [ListenerArgument(4, "response", typeof(object), "The value of this parameter depends on the value of the type parameter")]
        [ListenerArgument(5, "arg", typeof(object), "The type and value of this parameter depends on the value of the type parameter")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("exception", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires if an exception occurs in the Proxy during a remote request.")]
        public virtual ComponentListener Exception
        {
            get
            {
                if (this.exception == null)
                {
                    this.exception = new ComponentListener();
                }

                return this.exception;
            }
        }

        private ComponentListener load;

        /// <summary>
        /// Fires before the load method's callback is called.
        /// </summary>
        [ListenerArgument(0, "proxy", typeof(DataProxy), "The proxy for the request")]
        [ListenerArgument(1, "o", typeof(string), "The request transaction object")]
        [ListenerArgument(2, "options", typeof(object), "The callback's options property as passed to the request function")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("load", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the load method's callback is called.")]
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

        private ComponentListener write;

        /// <summary>
        /// Fires before the request-callback is called
        /// In addition to being fired through the DataProxy instance that raised the event, this event is also fired through the Ext.data.DataProxy class to allow for centralized processing of write events from all DataProxies by attaching a listener to the Ext.data.DataProxy class itself.
        /// </summary>
        [ListenerArgument(0, "proxy", typeof(DataProxy), "The proxy for the request")]
        [ListenerArgument(1, "action", typeof(string), "[Ext.data.Api.actions.create|upate|destroy]")]
        [ListenerArgument(2, "data", typeof(object), "The data object extracted from the server-response")]
        [ListenerArgument(3, "response", typeof(object), "The decoded response from server")]
        [ListenerArgument(4, "rs", typeof(object), "The Record(s) from Store")]
        [ListenerArgument(5, "options", typeof(object), "The callback's options property as passed to the request function")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("write", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the request-callback is called")]
        public virtual ComponentListener Write
        {
            get
            {
                if (this.write == null)
                {
                    this.write = new ComponentListener();
                }

                return this.write;
            }
        }
    }
}