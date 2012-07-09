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

using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class StoreBase : LazyObservable
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool RemoveContainer
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        ///  true to destroy the store when the component the store is bound to is destroyed (defaults to false). Note: this should be set to true when using stores that are bound to only 1 component.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("true to destroy the store when the component the store is bound to is destroyed (defaults to false). Note: this should be set to true when using stores that are bound to only 1 component.")]
        public virtual bool AutoDestroy
        {
            get
            {
                object obj = this.ViewState["AutoDestroy"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoDestroy"] = value;
            }
        }

        /// <summary>
        /// If passed, this store's load method is automatically called after creation with the autoLoad object.
        /// </summary>
        /// <value><c>true</c> if [auto load]; otherwise, <c>false</c>.</value>
        [Meta]
        [Category("3. Store")]
        [DefaultValue(true)]
        [Description("If passed, this store's load method is automatically called after creation with the autoLoad object.")]
        public virtual bool AutoLoad
        {
            get
            {
                object obj = this.ViewState["AutoLoad"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AutoLoad"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("autoLoad")]
        [DefaultValue(false)]
		[Description("")]
        protected virtual bool AutoLoadProxy
        {
            get
            {
                if (this.AutoLoadParams.Count == 0)
                {
                    return this.AutoLoad;
                }

                return false;
            }
        }

        /// <summary>
        /// Defaults to false. Set to true to have the Store and the set Proxy operate in a RESTful manner.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue(false)]
        [Description("Defaults to false. Set to true to have the Store and the set Proxy operate in a RESTful manner.")]
        public virtual bool Restful
        {
            get
            {
                object obj = this.ViewState["Restful"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Restful"] = value;
            }
        }

        /// <summary>
        /// Save ALL fields of a modified record -- not just those that changed. 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue(true)]
        [Description("Save ALL fields of a modified record -- not just those that changed.")]
        public virtual bool SaveAllFields
        {
            get
            {
                object obj = this.ViewState["SaveAllFields"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["SaveAllFields"] = value;
            }
        }

        /// <summary>
        /// Defaults to true causing the store to automatically save records to the server when a record is modified (ie: becomes 'dirty'). Specify false to manually call save to send all modifiedRecords to the server.
        /// </summary>
        /// <value><c>true</c> if [auto load]; otherwise, <c>false</c>.</value>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue(false)]
        [Description("Defaults to true causing the store to automatically save records to the server when a record is modified (ie: becomes 'dirty'). Specify false to manually call save to send all modifiedRecords to the server.")]
        public virtual bool AutoSave
        {
            get
            {
                object obj = this.ViewState["AutoSave"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoSave"] = value;
            }
        }

        internal bool IsAutoLoadUndefined
        {
            get
            {
                return this.ViewState["AutoLoad"] == null;
            }
        }

        /// <summary>
        /// If true then submitted data will be decoded
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue(false)]
        [Description("If true then submitted data will be decoded")]
        public virtual bool AutoDecode
        {
            get
            {
                object obj = this.ViewState["AutoDecode"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoDecode"] = value;
            }
        }

        private ParameterCollection baseParams;

        /// <summary>
        /// An object containing properties which are to be sent as parameters on any HTTP request.
        /// </summary>
        //[ClientConfig(JsonMode.ArrayToObject)]
        [Meta]
        [Category("3. Store")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("An object containing properties which are to be sent as parameters on any HTTP request.")]
        public virtual ParameterCollection BaseParams
        {
            get
            {
                if (this.baseParams == null)
                {
                    this.baseParams = new ParameterCollection();
                    this.baseParams.Owner = this;
                }

                return this.baseParams;
            }
        }

        private ParameterCollection autoParams;

        /// <summary>
        /// An object containing properties which are to be sent as parameters on auto load HTTP request.")]
        /// </summary>
        [Meta]
        [Category("3. Store")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("An object containing properties which are to be sent as parameters on auto load HTTP request.")]
        public virtual ParameterCollection AutoLoadParams
        {
            get
            {
                if (this.autoParams == null)
                {
                    this.autoParams = new ParameterCollection();
                    this.autoParams.Owner = this;
                }

                return this.autoParams;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("autoLoad", typeof(AutoLoadParamsJsonConverter))]
        [Description("")]
        protected ParameterCollection AutoLoadParamsProxy
        {
            get
            {
                if (this.AutoLoad == false)
                {
                    return new ParameterCollection();
                }

                return this.AutoLoadParams;
            }
        }


        private ParameterCollection writeBaseParams;

        /// <summary>
        /// An object containing properties which are to be sent as parameters on any HTTP request.
        /// </summary>
        [Meta]
        [Category("3. Store")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("An object containing properties which are to be sent as parameters on any HTTP request.")]
        public virtual ParameterCollection WriteBaseParams
        {
            get
            {
                if (this.writeBaseParams == null)
                {
                    this.writeBaseParams = new ParameterCollection();
                    this.writeBaseParams.Owner = this;
                }

                return this.writeBaseParams;
            }
        }

        // add:data

        private ProxyCollection proxy;

        /// <summary>
        /// The Proxy object which provides access to a data object.
        /// </summary>
        [Meta]
        [ConfigOption("proxy>Proxy")]
        [Category("3. Store")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("The Proxy object which provides access to a data object.")]
        public virtual ProxyCollection Proxy
        {
            get
            {
                if (this.proxy == null)
                {
                    this.proxy = new ProxyCollection();
                    this.proxy.Store = this as Store;
                }

                return this.proxy;
            }
        }

        private UpdateProxyCollection updateProxy;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("updateProxy>Proxy")]
        [Category("3. Store")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("")]
        public virtual UpdateProxyCollection UpdateProxy
        {
            get
            {
                if (this.updateProxy == null)
                {
                    this.updateProxy = new UpdateProxyCollection();
                    this.updateProxy.Store = this;
                }

                return this.updateProxy;
            }
        }

        private ReaderCollection reader;

        /// <summary>
        /// The DataReader object which processes the data object and returns an Array of Ext.data.Record objects which are cached keyed by their id property.
        /// </summary>
        [Meta]
        [ConfigOption("reader>Reader")]
        [Category("3. Store")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("The DataReader object which processes the data object and returns an Array of Ext.data.Record objects which are cached keyed by their id property.")]
        public virtual ReaderCollection Reader
        {
            get
            {
                if (this.reader == null)
                {
                    this.reader = new ReaderCollection();
                }

                return this.reader;
            }
        }

        /// <summary>
        /// True to clear all modified record information each time the store is loaded or when a record is removed. (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue(false)]
        [Description("True to clear all modified record information each time the store is loaded or when a record is removed. (defaults to false).")]
        public virtual bool PruneModifiedRecords
        {
            get
            {
                object obj = this.ViewState["PruneModifiedRecords"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["PruneModifiedRecords"] = value;
            }
        }

        /// <summary>
        /// True if sorting is to be handled by requesting the Proxy to provide a refreshed version of the data object in sorted order, as opposed to sorting the Record cache in place (defaults to false). If remote sorting is specified, then clicking on a column header causes the current page to be requested from the server with the addition of the following two parameters: sort: String - The name (as specified in the Record's Field definition) of the field to sort on. dir : String - The direction of the sort, 'ASC' or 'DESC' (case-sensitive).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue(false)]
        [Description("True if sorting is to be handled by requesting the Proxy to provide a refreshed version of the data object in sorted order, as opposed to sorting the Record cache in place (defaults to false). If remote sorting is specified, then clicking on a column header causes the current page to be requested from the server with the addition of the following two parameters: sort: String - The name (as specified in the Record's Field definition) of the field to sort on. dir : String - The direction of the sort, 'ASC' or 'DESC' (case-sensitive).")]
        public virtual bool RemoteSort
        {
            get
            {
                object obj = this.ViewState["RemoteSort"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["RemoteSort"] = value;
            }
        }

        /// <summary>
        /// True to perform remote paging
        /// </summary>
        [Meta]
        [Category("3. Store")]
        [DefaultValue(true)]
        [Description("True to perform remote paging.")]
        public virtual bool RemotePaging
        {
            get
            {
                object obj = this.ViewState["RemotePaging"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["RemotePaging"] = value;
            }
        }

        private SortInfo sortInfo;

        /// <summary>
        /// An object which determines the Store sorting information.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [Category("Data")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("An object which determines the Store sorting information.")]
        public virtual SortInfo SortInfo
        {
            get
            {
                if (this.sortInfo == null)
                {
                    this.sortInfo = new SortInfo();
                }
                return this.sortInfo;
            }
        }

        /// <summary>
        /// If true show a warning before load/reload if store has dirty data
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue(true)]
        [Description("If true show a warning before load/reload if store has dirty data")]
        public virtual bool WarningOnDirty
        {
            get
            {
                object obj = this.ViewState["WarningOnDirty"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["WarningOnDirty"] = value;
            }
        }

        /// <summary>
        /// The title of window showing before load if the dirty data exists
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("3. Store")]
        [DefaultValue("Uncommitted Changes")]
        [Description("The title of window showing before load if the dirty data exists")]
        public virtual string DirtyWarningTitle
        {
            get
            {
                return (string)this.ViewState["DirtyWarningTitle"] ?? "Uncommitted Changes";
            }
            set
            {
                this.ViewState["DirtyWarningTitle"] = value;
            }
        }

        /// <summary>
        /// The text of window showing before load if the dirty data exists
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue("You have uncommitted changes.  Are you sure you want to load/reload data?")]
        [Description("The text of window showing before load if the dirty data exists")]
        public virtual string DirtyWarningText
        {
            get
            {
                object obj = this.ViewState["DirtyWarningText"];
                return (obj == null) ? "You have uncommitted changes.  Are you sure you want to load/reload data?" : (string)obj;
            }
            set
            {
                this.ViewState["DirtyWarningText"] = value;
            }
        }

        /// <summary>
        /// The refresh mode
        /// </summary>
        [Meta]
        [ConfigOption("refreshAfterSave", JsonMode.Value)]
        [Category("3. Store")]
        [DefaultValue(RefreshAfterSavingMode.Auto)]
        [Description("The refresh mode")]
        public virtual RefreshAfterSavingMode RefreshAfterSaving
        {
            get
            {
                object obj = this.ViewState["RefreshAfterSaving"];
                return (obj == null) ? RefreshAfterSavingMode.Auto : (RefreshAfterSavingMode)obj;
            }
            set
            {
                this.ViewState["RefreshAfterSaving"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("useIdConfirmation", JsonMode.Value)]
        [Category("3. Store")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool UseIdConfirmation
        {
            get
            {
                object obj = this.ViewState["UseIdConfirmation"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["UseIdConfirmation"] = value;
            }
        }

        private BaseDirectEvent directEventConfig;

        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [ConfigOption(JsonMode.ObjectAllowEmpty)]
        [Description("")]
        public BaseDirectEvent DirectEventConfig
        {
            get
            {
                if (this.directEventConfig == null)
                {
                    this.directEventConfig = new BaseDirectEvent();
                }

                return this.directEventConfig;
            }
        }

        /// <summary>
        /// The field name by which to sort the store's data (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue("")]
        [Description("The field name by which to sort the store's data (defaults to '').")]
        public virtual string GroupField
        {
            get
            {
                return (string)this.ViewState["GroupField"] ?? "";
            }
            set
            {
                this.ViewState["GroupField"] = value;
            }
        }

        /// <summary>
        /// Group field sorting direction
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. Store")]
        [DefaultValue(SortDirection.Default)]
        [Description("Group field sorting direction")]
        public virtual SortDirection GroupDir
        {
            get
            {
                object o = this.ViewState["GroupDir"];
                return o == null ? SortDirection.Default : (SortDirection)o;
            }
            set
            {
                this.ViewState["GroupDir"] = value;
            }
        }

        /// <summary>
        /// True to sort the data on the grouping field when a grouping operation occurs, false to sort based on the existing sort info (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue(false)]
        [Description("True to sort the data on the grouping field when a grouping operation occurs, false to sort based on the existing sort info (defaults to false).")]
        public virtual bool GroupOnSort
        {
            get
            {
                object obj = this.ViewState["GroupOnSort"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["GroupOnSort"] = value;
            }
        }

        /// <summary>
        /// True if the grouping should apply on the server side, false if it is local only (defaults to false). If the grouping is local, it can be applied immediately to the data. If it is remote, then it will simply act as a helper, automatically sending the grouping field name as the 'groupBy' param with each XHR call.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue(false)]
        [Description("True if the grouping should apply on the server side, false if it is local only (defaults to false). If the grouping is local, it can be applied immediately to the data. If it is remote, then it will simply act as a helper, automatically sending the grouping field name as the 'groupBy' param with each XHR call.")]
        public virtual bool RemoteGroup
        {
            get
            {
                object obj = this.ViewState["RemoteGroup"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["RemoteGroup"] = value;
            }
        }

        /// <summary>
        /// If true then only properties included to reader will be converted to json
        /// </summary>
        [Meta]
        [Category("3. Store")]
        [DefaultValue(true)]
        [Description("If true then only properties included to reader will be converted to json")]
        public virtual bool IgnoreExtraFields
        {
            get
            {
                object obj = this.ViewState["IgnoreExtraFields"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["IgnoreExtraFields"] = value;
            }
        }

        /// <summary>
        /// Show warning if request fail.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Show a Window with error message is DirectEvent request fails.")]
        public bool ShowWarningOnFailure
        {
            get
            {
                object obj = this.ViewState["ShowWarningOnFailure"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["ShowWarningOnFailure"] = value;
            }
        }

        /// <summary>
        /// Skip Id field from save data for new records.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Store")]
        [DefaultValue(true)]
        [Description("Skip Id field from save data for new records.")]
        public virtual bool SkipIdForNewRecords
        {
            get
            {
                object obj = this.ViewState["SkipIdForNewRecords"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["SkipIdForNewRecords"] = value;
            }
        }


        private object data;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected object Data
        {
            get { return data; }
            set { data = value; }
        }

        private string jsonData;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected string JsonData
        {
            get { return jsonData; }
            set { jsonData = value; }
        }

        private bool isUrl;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected bool IsUrl
        {
            get { return isUrl; }
            set { isUrl = value; }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Loads data from a passed data block. A Reader which understands the format of the data must have been configured in the constructor.
        /// </summary>
        [Meta]
        [Description("Loads data from a passed data block. A Reader which understands the format of the data must have been configured in the constructor.")]
        public virtual void LoadData(object data)
        {
            this.Call("loadData", data);
        }

        /// <summary>
        /// Loads data from a passed data block. A Reader which understands the format of the data must have been configured in the constructor.
        /// </summary>
        [Meta]
        [Description("Loads data from a passed data block. A Reader which understands the format of the data must have been configured in the constructor.")]
        public virtual void LoadData(object data, bool append)
        {
            this.Call("loadData", data, append);
        }

        /// <summary>
        /// Add Record to the Store and fires the add event.
        /// </summary>
        [Meta]
        [Description("Add Record to the Store and fires the add event.")]
        public virtual void AddRecord(object values)
        {
            this.Call("addRecord", values);
        }

        /// <summary>
        /// Add Record to the Store and fires the add event.
        /// </summary>
        [Meta]
        [Description("Add Record to the Store and fires the add event.")]
        public virtual void AddRecord(object values, bool commit)
        {
            this.Call("addRecord", values, commit);
        }

        /// <summary>
        /// Inserts Record into the Store at the given index and fires the add event.
        /// </summary>
        [Meta]
        [Description("Inserts Record into the Store at the given index and fires the add event.")]
        public virtual void InsertRecord(int index, object values)
        {
            this.Call("insertRecord", index, values);
        }

        /// <summary>
        /// Inserts Record into the Store at the given index and fires the add event.
        /// </summary>
        [Meta]
        [Description("Inserts Record into the Store at the given index and fires the add event.")]
        public virtual void InsertRecord(int index, object values, bool commit)
        {
            this.Call("insertRecord", index, values, false, commit);
        }
        
        /// <summary>
        /// (Local sort only) Inserts the passed Record into the Store at the index where it should go based on the current sort information.
        /// </summary>
        [Meta]
        [Description("(Local sort only) Inserts the passed Record into the Store at the index where it should go based on the current sort information.")]
        public virtual void AddSortedRecord(object values)
        {
            this.Call("addSortedRecord", values);
        }

        /// <summary>
        /// (Local sort only) Inserts the passed Record into the Store at the index where it should go based on the current sort information.
        /// </summary>
        [Meta]
        [Description("(Local sort only) Inserts the passed Record into the Store at the index where it should go based on the current sort information.")]
        public virtual void AddSortedRecord(object values, bool commit)
        {
            this.Call("addSortedRecord", values, commit);
        }

        /// <summary>
        /// Revert to a view of the Record cache with no filtering applied.
        /// </summary>
        [Meta]
        [Description("Revert to a view of the Record cache with no filtering applied.")]
        public virtual void ClearFilter()
        {
            this.ClearFilter(false);
        }

        /// <summary>
        /// Revert to a view of the Record cache with no filtering applied.
        /// </summary>
        /// <param name="suppressEvent">If true the filter is cleared silently without notifying listeners</param>
        [Meta]
        [Description("Revert to a view of the Record cache with no filtering applied.")]
        public virtual void ClearFilter(bool suppressEvent)
        {
            this.Call("clearFilter", suppressEvent);
        }

        /// <summary>
        /// Commit all Records with outstanding changes. To handle updates for changes, subscribe to the Store's "update" event, and perform updating when the third parameter is Ext.data.Record.COMMIT.
        /// </summary>
        [Meta]
        [Description("Commit all Records with outstanding changes. To handle updates for changes, subscribe to the Store's \"update\" event, and perform updating when the third parameter is Ext.data.Record.COMMIT.")]
        public virtual void CommitChanges()
        {
            this.Call("commitChanges");
        }

        /// <summary>
        /// Filter the records by a specified property.
        /// </summary>
        /// <param name="field">A field on your records</param>
        /// <param name="value">Either a string that the field should begin with, or a RegExp (should be raw token) to test against the field.</param>
        /// <param name="anyMatch">True to match any part not just the beginning</param>
        /// <param name="caseSensitive">True for case sensitive comparison</param>
        [Meta]
        [Description("Filter the records by a specified property.")]
        public virtual void Filter(string field, string value, bool anyMatch, bool caseSensitive)
        {
            if (TokenUtils.IsRawToken(value))
            {
                value = TokenUtils.ReplaceRawToken(value);
            }

            this.Call("filter", field, value, anyMatch, caseSensitive);
        }

        /// <summary>
        /// Filter by a function. The specified function will be called for each Record in this Store. If the function returns true the Record is included, otherwise it is filtered out.
        /// </summary>
        /// <param name="fn">The function to be called. It will be passed the following parameters: record - The record to test for filtering. Access field values using Ext.data.Record.get. id - The ID of the Record passed.</param>
        [Meta]
        [Description("Filter by a function. The specified function will be called for each Record in this Store. If the function returns true the Record is included, otherwise it is filtered out.")]
        public virtual void FilterBy(JFunction fn)
        {
            this.Call("filterBy", fn);
        }

        /// <summary>
        /// Filter by a function. The specified function will be called for each Record in this Store. If the function returns true the Record is included, otherwise it is filtered out.
        /// </summary>
        /// <param name="fn">The function to be called. It will be passed the following parameters: record - The record to test for filtering. Access field values using Ext.data.Record.get. id - The ID of the Record passed.</param>
        /// <param name="scope">The scope of the function (defaults to this)</param>
        [Meta]
        [Description("Filter by a function. The specified function will be called for each Record in this Store. If the function returns true the Record is included, otherwise it is filtered out.")]
        public virtual void FilterBy(JFunction fn, string scope)
        {
            this.Call("filterBy", fn, new JRawValue(scope));
        }

        /// <summary>
        /// Cancel outstanding changes on all changed records.
        /// </summary>
        [Meta]
        [Description("Cancel outstanding changes on all changed records.")]
        public virtual void RejectChanges()
        {
            this.Call("rejectChanges");
        }

        /// <summary>
        /// Remove all Records from the Store and fires the clear event.
        /// </summary>
        [Meta]
        [Description("Remove all Records from the Store and fires the clear event.")]
        public virtual void RemoveAll()
        {
            this.Call("removeAll");
        }

        /// <summary>
        /// Sets the default sort column and order to be used by the next load operation.
        /// </summary>
        /// <param name="field">The name of the field to sort by.</param>
        /// <param name="dir">The sort order, "ASC" or "DESC"</param>
        [Meta]
        [Description("Sets the default sort column and order to be used by the next load operation.")]
        public virtual void SetDefaultSort(string field, SortDirection dir)
        {
            this.Call("setDefaultSort", field, dir);
        }

        /// <summary>
        /// Sort the Records. If remote sorting is used, the sort is performed on the server, and the cache is reloaded. If local sorting is used, the cache is sorted internally.
        /// </summary>
        /// <param name="field">The name of the field to sort by.</param>
        /// <param name="dir">The sort order, "ASC" or "DESC"</param>
        [Meta]
        [Description("Sort the Records. If remote sorting is used, the sort is performed on the server, and the cache is reloaded. If local sorting is used, the cache is sorted internally.")]
        public virtual void Sort(string field, SortDirection dir)
        {
            this.Call("sort", field, dir);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="clearMeta">Clear Meta</param>
        [Meta]
        [Description("")]
        public virtual void AddField(RecordField field, bool clearMeta)
        {
            this.AddField(field, -1, clearMeta);
        }

		/// <summary>
		/// 
		/// </summary>
        [Meta]
        [Description("")]
        public virtual void AddField(RecordField field)
        {
            this.AddField(field, true);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void AddField(RecordField field, int index)
        {
            this.AddField(field, index, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="index"></param>
        /// <param name="clearMeta"></param>
        [Meta]
        [Description("")]
        public virtual void AddField(RecordField field, int index, bool clearMeta)
        {
            if (this.Reader.Reader != null)
            {
                if (index >= 0 && index < this.Reader.Reader.Fields.Count)
                {
                    this.Reader.Reader.Fields.Insert(index, field);
                }
                else
                {
                    this.Reader.Reader.Fields.Add(field);
                }
            }

            //this.AddScript("{0}.addField({1}{2});", this.ClientID, new ClientConfig().Serialize(field), index >=0 ? ", " + index : ", ");

            this.Call("addField", new JRawValue(new ClientConfig().Serialize(field)), index, clearMeta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        [Meta]
        [Description("")]
        public virtual void RemoveField(RecordField field)
        {
            this.Call("removeField", new JRawValue(new ClientConfig().Serialize(field)));
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void RemoveFields()
        {
            this.Call("removeFields");
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void ClearMeta()
        {
            this.Call("clearMeta");
        }

        /// <summary>
        /// Update record field value
        /// </summary>
        /// <param name="rowIndex">row index</param>
        /// <param name="dataIndex">data index</param>
        /// <param name="value">value</param>
        [Meta]
        [Description("Update record field value")]
        public virtual void UpdateRecordField(int rowIndex, string dataIndex, object value)
        {
            RequestManager.EnsureDirectEvent();
            this.AddScript("{0}.getAt({1}).set({2},{3});", this.ClientID, rowIndex, JSON.Serialize(dataIndex), JSON.Serialize(value));
        }

        /// <summary>
        /// Update record field value
        /// </summary>
        /// <param name="id">id value</param>
        /// <param name="dataIndex">data index</param>
        /// <param name="value">value</param>
        [Meta]
        [Description("Update record field value")]
        public virtual void UpdateRecordField(object id, string dataIndex, object value)
        {
            RequestManager.EnsureDirectEvent();
            this.AddScript("{0}.getById({1}).set({2},{3});", this.ClientID, JSON.Serialize(id), JSON.Serialize(dataIndex), JSON.Serialize(value));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void UpdateRecordId(object id, object newId)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("updateRecordId", id, newId);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void UpdateRecordId(object id, object newId, bool silent)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("updateRecordId", id, newId, silent);
        }

        /// <summary>
        /// Remove record by id
        /// </summary>
        /// <param name="id">id</param>
        public virtual void RemoveRecord(object id)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("remove", new JRawValue("{0}.getById({1})".FormatWith(this.ClientID, JSON.Serialize(id))));
        }

        /// <summary>
        /// Remove record by id
        /// </summary>
        /// <param name="index">index</param>
        public virtual void RemoveRecord(int index)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("remove", new JRawValue("{0}.getAt({1})".FormatWith(this.ClientID, index)));
        }

        /// <summary>
        /// Clears any existing grouping and refreshes the data using the default sort.
        /// </summary>
        public virtual void ClearGrouping()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("clearGrouping");
        }

        /// <summary>
        /// Groups the data by the specified field.
        /// </summary>
        /// <param name="field">The field name by which to sort the store's data</param>
        /// <param name="forceRegroup">True to force the group to be refreshed even if the field passed in is the same as the current grouping field, false to skip grouping on the same field</param>
        public virtual void GroupBy(string field, bool forceRegroup)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("groupBy", field, forceRegroup);
        }

        /// <summary>
        /// Groups the data by the specified field.
        /// </summary>
        /// <param name="field">The field name by which to sort the store's data</param>
        public virtual void GroupBy(string field)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("groupBy", field);
        }

        /// <summary>
        /// Apply grouping
        /// </summary>
        /// <param name="alwaysFireChange">fire datachanged event</param>
        public virtual void ApplyGrouping(bool alwaysFireChange)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("applyGrouping", alwaysFireChange);
        }

        /// <summary>
        /// Apply sort
        /// </summary>
        public virtual void ApplySort()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("applySort");
        }
    }
}