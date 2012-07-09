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
    public partial class StoreDirectEvents : ComponentBaseDirectEvents
    {
        private ComponentDirectEvent add;

        /// <summary>
        /// Fires when Records have been added to the Store
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "records", typeof(object), "The array of Records added")]
        [ListenerArgument(2, "index", typeof(object), "The index at which the record(s) were added")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("add", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when Records have been added to the Store")]
        public virtual ComponentDirectEvent Add
        {
            get
            {
                if (this.add == null)
                {
                    this.add = new ComponentDirectEvent();
                }

                return this.add;
            }
        }

        private ComponentDirectEvent beforeLoad;

        /// <summary>
        /// Fires before a request is made for a new data object. If the beforeload handler returns false the load action will be canceled
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "options", typeof(object), "The loading options that were specified (see load for details)")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeload", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a request is made for a new data object. If the beforeload handler returns false the load action will be canceled")]
        public virtual ComponentDirectEvent BeforeLoad
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

        private ComponentDirectEvent clear;

        /// <summary>
        /// Fires when the data cache has been cleared.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("clear", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the data cache has been cleared.")]
        public virtual ComponentDirectEvent Clear
        {
            get
            {
                if (this.clear == null)
                {
                    this.clear = new ComponentDirectEvent();
                }

                return this.clear;
            }
        }

        private ComponentDirectEvent dataChanged;

        /// <summary>
        /// Fires when the data cache has changed, and a widget which is using this Store as a Record cache should refresh its view.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("datachanged", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the data cache has changed, and a widget which is using this Store as a Record cache should refresh its view.")]
        public virtual ComponentDirectEvent DataChanged
        {
            get
            {
                if (this.dataChanged == null)
                {
                    this.dataChanged = new ComponentDirectEvent();
                }

                return this.dataChanged;
            }
        }

        private ComponentDirectEvent load;

        /// <summary>
        /// Fires after a new set of Records has been loaded.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "records", typeof(Store), "The Records that were loaded")]
        [ListenerArgument(2, "options", typeof(Store), "The loading options that were specified (see load for details)")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("load", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a new set of Records has been loaded.")]
        public virtual ComponentDirectEvent Load
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
        /// Fires if an exception occurs in the Proxy during loading. Called with the signature of the Proxy's \"loadexception\" event.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "options", typeof(DataProxy), "options")]
        [ListenerArgument(2, "response", typeof(DataProxy), "response")]
        [ListenerArgument(3, "e", typeof(DataProxy), "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("loadexception", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires if an exception occurs in the Proxy during loading. Called with the signature of the Proxy's \"loadexception\" event.")]
        public virtual ComponentDirectEvent LoadException
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

        private ComponentDirectEvent metaChange;

        /// <summary>
        /// Fires when this store's reader provides new metadata (fields). This is currently only supported for JsonReaders.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "meta", typeof(Store), "The JSON metadata")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("metachange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this store's reader provides new metadata (fields). This is currently only supported for JsonReaders.")]
        public virtual ComponentDirectEvent MetaChange
        {
            get
            {
                if (this.metaChange == null)
                {
                    this.metaChange = new ComponentDirectEvent();
                }

                return this.metaChange;
            }
        }

        private ComponentDirectEvent remove;

        /// <summary>
        /// Fires when a Record has been removed from the Store
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "records", typeof(object), "The Record that was removed")]
        [ListenerArgument(2, "index", typeof(object), "The index at which the record was removed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remove", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a Record has been removed from the Store")]
        public virtual ComponentDirectEvent Remove
        {
            get
            {
                if (this.remove == null)
                {
                    this.remove = new ComponentDirectEvent();
                }

                return this.remove;
            }
        }

        private ComponentDirectEvent update;

        /// <summary>
        /// Fires when a Record has been updated
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "records", typeof(object), "The Record that was updated")]
        [ListenerArgument(2, "operation", typeof(object), "The update operation being performed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("update", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a Record has been updated")]
        public virtual ComponentDirectEvent Update
        {
            get
            {
                if (this.update == null)
                {
                    this.update = new ComponentDirectEvent();
                }

                return this.update;
            }
        }

        private ComponentDirectEvent beforeSave;

        /// <summary>
        /// Fires before a network request is made to save a data object. If the beforesave handler returns false the save action will be canceled
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "params", typeof(object), "The saving params that were specified")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforesave", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a network request is made to save a data object. If the beforesave handler returns false the save action will be canceled")]
        public virtual ComponentDirectEvent BeforeSave
        {
            get
            {
                if (this.beforeSave == null)
                {
                    this.beforeSave = new ComponentDirectEvent();
                }

                return this.beforeSave;
            }
        }

        private ComponentDirectEvent save;

        /// <summary>
        /// Fires before the save method's callback is called.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "o", typeof(DataProxy), "o")]
        [ListenerArgument(2, "arg", typeof(DataProxy), "arg")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("save", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the save method's callback is called.")]
        public virtual ComponentDirectEvent Save
        {
            get
            {
                if (this.save == null)
                {
                    this.save = new ComponentDirectEvent();
                }

                return this.save;
            }
        }

        private ComponentDirectEvent saveException;

        /// <summary>
        /// Fires if an exception occurs in the Proxy during writing.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "o", typeof(DataProxy), "o")]
        [ListenerArgument(2, "response", typeof(DataProxy), "response")]
        [ListenerArgument(3, "e", typeof(DataProxy), "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("saveexception", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires if an exception occurs in the Proxy during writing.")]
        public virtual ComponentDirectEvent SaveException
        {
            get
            {
                if (this.saveException == null)
                {
                    this.saveException = new ComponentDirectEvent();
                }

                return this.saveException;
            }
        }

        private ComponentDirectEvent commitDone;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "options", typeof(DataProxy), "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("commitdone", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent CommitDone
        {
            get
            {
                if (this.commitDone == null)
                {
                    this.commitDone = new ComponentDirectEvent();
                }

                return this.commitDone;
            }
        }

        private ComponentDirectEvent commitFailed;

        /// <summary>
        /// 
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "msg", typeof(DataProxy), "error message")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("commitfailed", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentDirectEvent CommitFailed
        {
            get
            {
                if (this.commitFailed == null)
                {
                    this.commitFailed = new ComponentDirectEvent();
                }

                return this.commitFailed;
            }
        }

        private ComponentDirectEvent exception;

        /// <summary>
        /// Fires if an exception occurs during request
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "type", typeof(string), "type")]
        [ListenerArgument(2, "action", typeof(string), "action")]
        [ListenerArgument(3, "o", typeof(object), "o")]
        [ListenerArgument(4, "response", typeof(object), "response")]
        [ListenerArgument(5, "e", typeof(object), "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("exception", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires if an exception occurs during request")]
        public virtual ComponentDirectEvent Exception
        {
            get
            {
                if (this.exception == null)
                {
                    this.exception = new ComponentDirectEvent();
                }

                return this.exception;
            }
        }

        private ComponentDirectEvent groupChange;

        /// <summary>
        /// Fired whenever a call to store.groupBy successfully changes the grouping on the store
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "The grouping store")]
        [ListenerArgument(1, "groupField", typeof(object), "The field that the store is now grouped by")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupchange", typeof(DirectEventJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
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
    }
}