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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    public abstract partial class StoreBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TStoreBase, TBuilder> : LazyObservable.Builder<TStoreBase, TBuilder>
            where TStoreBase : StoreBase
            where TBuilder : Builder<TStoreBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TStoreBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// true to destroy the store when the component the store is bound to is destroyed (defaults to false). Note: this should be set to true when using stores that are bound to only 1 component.
			/// </summary>
            public virtual TBuilder AutoDestroy(bool autoDestroy)
            {
                this.ToComponent().AutoDestroy = autoDestroy;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If passed, this store's load method is automatically called after creation with the autoLoad object.
			/// </summary>
            public virtual TBuilder AutoLoad(bool autoLoad)
            {
                this.ToComponent().AutoLoad = autoLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Defaults to false. Set to true to have the Store and the set Proxy operate in a RESTful manner.
			/// </summary>
            public virtual TBuilder Restful(bool restful)
            {
                this.ToComponent().Restful = restful;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Save ALL fields of a modified record -- not just those that changed.
			/// </summary>
            public virtual TBuilder SaveAllFields(bool saveAllFields)
            {
                this.ToComponent().SaveAllFields = saveAllFields;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Defaults to true causing the store to automatically save records to the server when a record is modified (ie: becomes 'dirty'). Specify false to manually call save to send all modifiedRecords to the server.
			/// </summary>
            public virtual TBuilder AutoSave(bool autoSave)
            {
                this.ToComponent().AutoSave = autoSave;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If true then submitted data will be decoded
			/// </summary>
            public virtual TBuilder AutoDecode(bool autoDecode)
            {
                this.ToComponent().AutoDecode = autoDecode;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// An object containing properties which are to be sent as parameters on any HTTP request.
			// /// </summary>
            // public virtual TBuilder BaseParams(ParameterCollection baseParams)
            // {
            //    this.ToComponent().BaseParams = baseParams;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// An object containing properties which are to be sent as parameters on auto load HTTP request.
			// /// </summary>
            // public virtual TBuilder AutoLoadParams(ParameterCollection autoLoadParams)
            // {
            //    this.ToComponent().AutoLoadParams = autoLoadParams;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// An object containing properties which are to be sent as parameters on any HTTP request.
			// /// </summary>
            // public virtual TBuilder WriteBaseParams(ParameterCollection writeBaseParams)
            // {
            //    this.ToComponent().WriteBaseParams = writeBaseParams;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// The Proxy object which provides access to a data object.
			// /// </summary>
            // public virtual TBuilder Proxy(ProxyCollection proxy)
            // {
            //    this.ToComponent().Proxy = proxy;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder UpdateProxy(UpdateProxyCollection updateProxy)
            // {
            //    this.ToComponent().UpdateProxy = updateProxy;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// The DataReader object which processes the data object and returns an Array of Ext.data.Record objects which are cached keyed by their id property.
			// /// </summary>
            // public virtual TBuilder Reader(ReaderCollection reader)
            // {
            //    this.ToComponent().Reader = reader;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// True to clear all modified record information each time the store is loaded or when a record is removed. (defaults to false).
			/// </summary>
            public virtual TBuilder PruneModifiedRecords(bool pruneModifiedRecords)
            {
                this.ToComponent().PruneModifiedRecords = pruneModifiedRecords;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True if sorting is to be handled by requesting the Proxy to provide a refreshed version of the data object in sorted order, as opposed to sorting the Record cache in place (defaults to false). If remote sorting is specified, then clicking on a column header causes the current page to be requested from the server with the addition of the following two parameters: sort: String - The name (as specified in the Record's Field definition) of the field to sort on. dir : String - The direction of the sort, 'ASC' or 'DESC' (case-sensitive).
			/// </summary>
            public virtual TBuilder RemoteSort(bool remoteSort)
            {
                this.ToComponent().RemoteSort = remoteSort;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to perform remote paging.
			/// </summary>
            public virtual TBuilder RemotePaging(bool remotePaging)
            {
                this.ToComponent().RemotePaging = remotePaging;
                return this as TBuilder;
            }
             
 			// /// <summary>
			// /// An object which determines the Store sorting information.
			// /// </summary>
            // public virtual TBuilder SortInfo(SortInfo sortInfo)
            // {
            //    this.ToComponent().SortInfo = sortInfo;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// If true show a warning before load/reload if store has dirty data
			/// </summary>
            public virtual TBuilder WarningOnDirty(bool warningOnDirty)
            {
                this.ToComponent().WarningOnDirty = warningOnDirty;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The title of window showing before load if the dirty data exists
			/// </summary>
            public virtual TBuilder DirtyWarningTitle(string dirtyWarningTitle)
            {
                this.ToComponent().DirtyWarningTitle = dirtyWarningTitle;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The text of window showing before load if the dirty data exists
			/// </summary>
            public virtual TBuilder DirtyWarningText(string dirtyWarningText)
            {
                this.ToComponent().DirtyWarningText = dirtyWarningText;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The refresh mode
			/// </summary>
            public virtual TBuilder RefreshAfterSaving(RefreshAfterSavingMode refreshAfterSaving)
            {
                this.ToComponent().RefreshAfterSaving = refreshAfterSaving;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The field name by which to sort the store's data (defaults to '').
			/// </summary>
            public virtual TBuilder GroupField(string groupField)
            {
                this.ToComponent().GroupField = groupField;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Group field sorting direction
			/// </summary>
            public virtual TBuilder GroupDir(SortDirection groupDir)
            {
                this.ToComponent().GroupDir = groupDir;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to sort the data on the grouping field when a grouping operation occurs, false to sort based on the existing sort info (defaults to false).
			/// </summary>
            public virtual TBuilder GroupOnSort(bool groupOnSort)
            {
                this.ToComponent().GroupOnSort = groupOnSort;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True if the grouping should apply on the server side, false if it is local only (defaults to false). If the grouping is local, it can be applied immediately to the data. If it is remote, then it will simply act as a helper, automatically sending the grouping field name as the 'groupBy' param with each XHR call.
			/// </summary>
            public virtual TBuilder RemoteGroup(bool remoteGroup)
            {
                this.ToComponent().RemoteGroup = remoteGroup;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// If true then only properties included to reader will be converted to json
			/// </summary>
            public virtual TBuilder IgnoreExtraFields(bool ignoreExtraFields)
            {
                this.ToComponent().IgnoreExtraFields = ignoreExtraFields;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Show a Window with error message is DirectEvent request fails.
			/// </summary>
            public virtual TBuilder ShowWarningOnFailure(bool showWarningOnFailure)
            {
                this.ToComponent().ShowWarningOnFailure = showWarningOnFailure;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Skip Id field from save data for new records.
			/// </summary>
            public virtual TBuilder SkipIdForNewRecords(bool skipIdForNewRecords)
            {
                this.ToComponent().SkipIdForNewRecords = skipIdForNewRecords;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Loads data from a passed data block. A Reader which understands the format of the data must have been configured in the constructor.
			/// </summary>
            public virtual TBuilder LoadData(object data)
            {
                this.ToComponent().LoadData(data);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Loads data from a passed data block. A Reader which understands the format of the data must have been configured in the constructor.
			/// </summary>
            public virtual TBuilder LoadData(object data, bool append)
            {
                this.ToComponent().LoadData(data, append);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Add Record to the Store and fires the add event.
			/// </summary>
            public virtual TBuilder AddRecord(object values)
            {
                this.ToComponent().AddRecord(values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Add Record to the Store and fires the add event.
			/// </summary>
            public virtual TBuilder AddRecord(object values, bool commit)
            {
                this.ToComponent().AddRecord(values, commit);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Inserts Record into the Store at the given index and fires the add event.
			/// </summary>
            public virtual TBuilder InsertRecord(int index, object values)
            {
                this.ToComponent().InsertRecord(index, values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Inserts Record into the Store at the given index and fires the add event.
			/// </summary>
            public virtual TBuilder InsertRecord(int index, object values, bool commit)
            {
                this.ToComponent().InsertRecord(index, values, commit);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// (Local sort only) Inserts the passed Record into the Store at the index where it should go based on the current sort information.
			/// </summary>
            public virtual TBuilder AddSortedRecord(object values)
            {
                this.ToComponent().AddSortedRecord(values);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// (Local sort only) Inserts the passed Record into the Store at the index where it should go based on the current sort information.
			/// </summary>
            public virtual TBuilder AddSortedRecord(object values, bool commit)
            {
                this.ToComponent().AddSortedRecord(values, commit);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Revert to a view of the Record cache with no filtering applied.
			/// </summary>
            public virtual TBuilder ClearFilter()
            {
                this.ToComponent().ClearFilter();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Revert to a view of the Record cache with no filtering applied.
			/// </summary>
            public virtual TBuilder ClearFilter(bool suppressEvent)
            {
                this.ToComponent().ClearFilter(suppressEvent);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Commit all Records with outstanding changes. To handle updates for changes, subscribe to the Store's \"update\" event, and perform updating when the third parameter is Ext.data.Record.COMMIT.
			/// </summary>
            public virtual TBuilder CommitChanges()
            {
                this.ToComponent().CommitChanges();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Filter the records by a specified property.
			/// </summary>
            public virtual TBuilder Filter(string field, string value, bool anyMatch, bool caseSensitive)
            {
                this.ToComponent().Filter(field, value, anyMatch, caseSensitive);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Filter by a function. The specified function will be called for each Record in this Store. If the function returns true the Record is included, otherwise it is filtered out.
			/// </summary>
            public virtual TBuilder FilterBy(JFunction fn)
            {
                this.ToComponent().FilterBy(fn);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Filter by a function. The specified function will be called for each Record in this Store. If the function returns true the Record is included, otherwise it is filtered out.
			/// </summary>
            public virtual TBuilder FilterBy(JFunction fn, string scope)
            {
                this.ToComponent().FilterBy(fn, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Cancel outstanding changes on all changed records.
			/// </summary>
            public virtual TBuilder RejectChanges()
            {
                this.ToComponent().RejectChanges();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Remove all Records from the Store and fires the clear event.
			/// </summary>
            public virtual TBuilder RemoveAll()
            {
                this.ToComponent().RemoveAll();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the default sort column and order to be used by the next load operation.
			/// </summary>
            public virtual TBuilder SetDefaultSort(string field, SortDirection dir)
            {
                this.ToComponent().SetDefaultSort(field, dir);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sort the Records. If remote sorting is used, the sort is performed on the server, and the cache is reloaded. If local sorting is used, the cache is sorted internally.
			/// </summary>
            public virtual TBuilder Sort(string field, SortDirection dir)
            {
                this.ToComponent().Sort(field, dir);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddField(RecordField field, bool clearMeta)
            {
                this.ToComponent().AddField(field, clearMeta);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddField(RecordField field)
            {
                this.ToComponent().AddField(field);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddField(RecordField field, int index, bool clearMeta)
            {
                this.ToComponent().AddField(field, index, clearMeta);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveField(RecordField field)
            {
                this.ToComponent().RemoveField(field);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveFields()
            {
                this.ToComponent().RemoveFields();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder ClearMeta()
            {
                this.ToComponent().ClearMeta();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Update record field value
			/// </summary>
            public virtual TBuilder UpdateRecordField(int rowIndex, string dataIndex, object value)
            {
                this.ToComponent().UpdateRecordField(rowIndex, dataIndex, value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Update record field value
			/// </summary>
            public virtual TBuilder UpdateRecordField(object id, string dataIndex, object value)
            {
                this.ToComponent().UpdateRecordField(id, dataIndex, value);
                return this as TBuilder;
            }
            
        }        
    }
}