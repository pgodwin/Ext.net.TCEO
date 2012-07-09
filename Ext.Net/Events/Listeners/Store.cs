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
    [TypeConverter(typeof(ListenersConverter))]
    public partial class StoreListeners : ComponentBaseListeners
    {
        private ComponentListener add;

        /// <summary>
        /// Fires when Records have been added to the Store
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "records", typeof(object), "The array of Records added")]
        [ListenerArgument(2, "index", typeof(object), "The index at which the record(s) were added")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("add", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when Records have been added to the Store")]
        public virtual ComponentListener Add
        {
            get
            {
                if (this.add == null)
                {
                    this.add = new ComponentListener();
                }

                return this.add;
            }
        }

        private ComponentListener beforeLoad;

        /// <summary>
        /// Fires before a request is made for a new data object. If the beforeload handler returns false the load action will be canceled
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "options", typeof(object), "The loading options that were specified (see load for details)")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforeload", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a request is made for a new data object. If the beforeload handler returns false the load action will be canceled")]
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

        private ComponentListener clear;

        /// <summary>
        /// Fires when the data cache has been cleared.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("clear", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the data cache has been cleared.")]
        public virtual ComponentListener Clear
        {
            get
            {
                if (this.clear == null)
                {
                    this.clear = new ComponentListener();
                }

                return this.clear;
            }
        }

        private ComponentListener dataChanged;

        /// <summary>
        /// Fires when the data cache has changed, and a widget which is using this Store as a Record cache should refresh its view.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("datachanged", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when the data cache has changed, and a widget which is using this Store as a Record cache should refresh its view.")]
        public virtual ComponentListener DataChanged
        {
            get
            {
                if (this.dataChanged == null)
                {
                    this.dataChanged = new ComponentListener();
                }

                return this.dataChanged;
            }
        }

        private ComponentListener load;

        /// <summary>
        /// Fires after a new set of Records has been loaded.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "records", typeof(object), "The Records that were loaded")]
        [ListenerArgument(2, "options", typeof(object), "The loading options that were specified (see load for details)")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("load", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires after a new set of Records has been loaded.")]
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
        /// Fires if an exception occurs in the Proxy during loading. Called with the signature of the Proxy's \"loadexception\" event.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "options", typeof(object), "options")]
        [ListenerArgument(2, "response", typeof(object), "response")]
        [ListenerArgument(3, "e", typeof(object), "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("loadexception", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires if an exception occurs in the Proxy during loading. Called with the signature of the Proxy's \"loadexception\" event.")]
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

        private ComponentListener metaChange;

        /// <summary>
        /// Fires when this store's reader provides new metadata (fields). This is currently only supported for JsonReaders.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "meta", typeof(object), "The JSON metadata")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("metachange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when this store's reader provides new metadata (fields). This is currently only supported for JsonReaders.")]
        public virtual ComponentListener MetaChange
        {
            get
            {
                if (this.metaChange == null)
                {
                    this.metaChange = new ComponentListener();
                }

                return this.metaChange;
            }
        }

        private ComponentListener remove;

        /// <summary>
        /// Fires when a Record has been removed from the Store
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "records", typeof(object), "The Record that was removed")]
        [ListenerArgument(2, "index", typeof(object), "The index at which the record was removed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("remove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a Record has been removed from the Store")]
        public virtual ComponentListener Remove
        {
            get
            {
                if (this.remove == null)
                {
                    this.remove = new ComponentListener();
                }

                return this.remove;
            }
        }

        private ComponentListener update;

        /// <summary>
        /// Fires when a Record has been updated
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "records", typeof(object), "The Record that was updated")]
        [ListenerArgument(2, "operation", typeof(object), "The update operation being performed")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("update", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires when a Record has been updated")]
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

        private ComponentListener beforeSave;

        /// <summary>
        /// Fires before a network request is made to save a data object. If the beforesave handler returns false the save action will be canceled
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "params", typeof(object), "The saving params that were specified")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("beforesave", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before a network request is made to save a data object. If the beforesave handler returns false the save action will be canceled")]
        public virtual ComponentListener BeforeSave
        {
            get
            {
                if (this.beforeSave == null)
                {
                    this.beforeSave = new ComponentListener();
                }

                return this.beforeSave;
            }
        }

        private ComponentListener save;

        /// <summary>
        /// Fires before the save method's callback is called.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "o", typeof(object), "o")]
        [ListenerArgument(2, "arg", typeof(object), "arg")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("save", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires before the save method's callback is called.")]
        public virtual ComponentListener Save
        {
            get
            {
                if (this.save == null)
                {
                    this.save = new ComponentListener();
                }

                return this.save;
            }
        }

        private ComponentListener saveException;

        /// <summary>
        /// Fires if an exception occurs in the Proxy during writing.
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "o", typeof(object), "o")]
        [ListenerArgument(2, "response", typeof(object), "response")]
        [ListenerArgument(3, "e", typeof(object), "e")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("saveexception", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires if an exception occurs in the Proxy during writing.")]
        public virtual ComponentListener SaveException
        {
            get
            {
                if (this.saveException == null)
                {
                    this.saveException = new ComponentListener();
                }

                return this.saveException;
            }
        }

        private ComponentListener commitDone;

		/// <summary>
		/// 
		/// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "options", typeof(object), "options")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("commitdone", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
		[Description("")]
        public virtual ComponentListener CommitDone
        {
            get
            {
                if (this.commitDone == null)
                {
                    this.commitDone = new ComponentListener();
                }

                return this.commitDone;
            }
        }

        private ComponentListener commitFailed;

		/// <summary>
		/// 
		/// </summary>
        [ListenerArgument(0, "store", typeof(Store), "this")]
        [ListenerArgument(1, "msg", typeof(object), "error message")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("commitfailed", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
		[Description("")]
        public virtual ComponentListener CommitFailed
        {
            get
            {
                if (this.commitFailed == null)
                {
                    this.commitFailed = new ComponentListener();
                }

                return this.commitFailed;
            }
        }

        private ComponentListener exception;

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
        [ConfigOption("exception", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Fires if an exception occurs during request")]
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

        private ComponentListener groupChange;

        /// <summary>
        /// Fired whenever a call to store.groupBy successfully changes the grouping on the store
        /// </summary>
        [ListenerArgument(0, "store", typeof(Store), "The grouping store")]
        [ListenerArgument(1, "groupField", typeof(object), "The field that the store is now grouped by")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("groupchange", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ComponentListener GroupChange
        {
            get
            {
                if (this.groupChange == null)
                {
                    this.groupChange = new ComponentListener();
                }

                return this.groupChange;
            }
        }
    }
}