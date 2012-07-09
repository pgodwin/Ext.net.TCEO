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
    [TypeConverter(typeof(DirectEventsConverter))]
    public partial class DataProxyDirectEvents : ComponentBaseDirectEvents
    {
        private ComponentDirectEvent beforeLoad;

        /// <summary>
        /// Fires before a network request is made to retrieve a data object.
        /// </summary>
        [ConfigOption("beforeload>Handler", JsonMode.Object)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [Description("Fires before a network request is made to retrieve a data object.")]
        public ComponentDirectEvent BeforeLoad
        {
            get
            {
                if (this.beforeLoad == null)
                {
                    this.beforeLoad = new ComponentDirectEvent();
                }

                return this.beforeLoad;
            }
        }

        private ComponentDirectEvent load;

        /// <summary>
        /// Fires before the load method's callback is called.
        /// </summary>
        [ConfigOption("load>Handler", JsonMode.Object)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [Description("Fires before the load method's callback is called.")]
        public ComponentDirectEvent Load
        {
            get
            {
                if (this.load == null)
                {
                    this.load = new ComponentDirectEvent();
                }

                return this.load;
            }
        }

        private ComponentDirectEvent loadException;

        /// <summary>
        /// Fires if an exception occurs in the Proxy during data loading. 
        /// This event can be fired for one of two reasons:
        ///     The load call timed out. This means the load callback did
        ///     not execute within the time limit specified by timeout.
        ///     In this case, this event will be raised and the fourth
        ///     parameter (read error) will be null.
        ///
        ///     The load succeeded but the reader could not read the response.
        ///     This means the server returned data, but the configured Reader
        ///     threw an error while reading the data. In this case, this event
        ///     will be raised and the caught error will be passed along as 
        ///     the fourth parameter of this event.
        /// 
        ///     Note that this event is also relayed through Store, so you
        ///     can listen for it directly on any Store instance.
        /// 
        ///     DirectEvents will be called with the following arguments:
        ///         this : Object
        ///         
        ///         options : Object
        ///             The loading options that were specified (see load for details).
        ///             If the load call timed out, this parameter will be null.
        ///         
        ///         arg : Object
        ///             The callback's arg object passed to the load function
        /// 
        ///         e : Error
        ///         The JavaScript Error object caught if the configured Reader
        ///         could not read the data. If the load call returned 
        ///         success: false, this parameter will be null.
        /// </summary>
        [ConfigOption("loadexception>Handler", JsonMode.Object)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [Description("Fires if an exception occurs in the Proxy during data loading")]
        public ComponentDirectEvent LoawdException
        {
            get
            {
                if (this.loadException == null)
                {
                    this.loadException = new ComponentDirectEvent();
                }

                return this.loadException;
            }
        }
    }
}