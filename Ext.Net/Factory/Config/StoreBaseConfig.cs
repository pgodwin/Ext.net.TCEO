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
        new public abstract partial class Config : LazyObservable.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoDestroy = false;

			/// <summary>
			/// true to destroy the store when the component the store is bound to is destroyed (defaults to false). Note: this should be set to true when using stores that are bound to only 1 component.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoDestroy 
			{ 
				get
				{
					return this.autoDestroy;
				}
				set
				{
					this.autoDestroy = value;
				}
			}

			private bool autoLoad = true;

			/// <summary>
			/// If passed, this store's load method is automatically called after creation with the autoLoad object.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AutoLoad 
			{ 
				get
				{
					return this.autoLoad;
				}
				set
				{
					this.autoLoad = value;
				}
			}

			private bool restful = false;

			/// <summary>
			/// Defaults to false. Set to true to have the Store and the set Proxy operate in a RESTful manner.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Restful 
			{ 
				get
				{
					return this.restful;
				}
				set
				{
					this.restful = value;
				}
			}

			private bool saveAllFields = true;

			/// <summary>
			/// Save ALL fields of a modified record -- not just those that changed.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SaveAllFields 
			{ 
				get
				{
					return this.saveAllFields;
				}
				set
				{
					this.saveAllFields = value;
				}
			}

			private bool autoSave = false;

			/// <summary>
			/// Defaults to true causing the store to automatically save records to the server when a record is modified (ie: becomes 'dirty'). Specify false to manually call save to send all modifiedRecords to the server.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoSave 
			{ 
				get
				{
					return this.autoSave;
				}
				set
				{
					this.autoSave = value;
				}
			}

			private bool autoDecode = false;

			/// <summary>
			/// If true then submitted data will be decoded
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoDecode 
			{ 
				get
				{
					return this.autoDecode;
				}
				set
				{
					this.autoDecode = value;
				}
			}
        
			private ParameterCollection baseParams = null;

			/// <summary>
			/// An object containing properties which are to be sent as parameters on any HTTP request.
			/// </summary>
			public ParameterCollection BaseParams
			{
				get
				{
					if (this.baseParams == null)
					{
						this.baseParams = new ParameterCollection();
					}
			
					return this.baseParams;
				}
			}
			        
			private ParameterCollection autoLoadParams = null;

			/// <summary>
			/// An object containing properties which are to be sent as parameters on auto load HTTP request.
			/// </summary>
			public ParameterCollection AutoLoadParams
			{
				get
				{
					if (this.autoLoadParams == null)
					{
						this.autoLoadParams = new ParameterCollection();
					}
			
					return this.autoLoadParams;
				}
			}
			        
			private ParameterCollection writeBaseParams = null;

			/// <summary>
			/// An object containing properties which are to be sent as parameters on any HTTP request.
			/// </summary>
			public ParameterCollection WriteBaseParams
			{
				get
				{
					if (this.writeBaseParams == null)
					{
						this.writeBaseParams = new ParameterCollection();
					}
			
					return this.writeBaseParams;
				}
			}
			        
			private ProxyCollection proxy = null;

			/// <summary>
			/// The Proxy object which provides access to a data object.
			/// </summary>
			public ProxyCollection Proxy
			{
				get
				{
					if (this.proxy == null)
					{
						this.proxy = new ProxyCollection();
					}
			
					return this.proxy;
				}
			}
			        
			private UpdateProxyCollection updateProxy = null;

			/// <summary>
			/// 
			/// </summary>
			public UpdateProxyCollection UpdateProxy
			{
				get
				{
					if (this.updateProxy == null)
					{
						this.updateProxy = new UpdateProxyCollection();
					}
			
					return this.updateProxy;
				}
			}
			        
			private ReaderCollection reader = null;

			/// <summary>
			/// The DataReader object which processes the data object and returns an Array of Ext.data.Record objects which are cached keyed by their id property.
			/// </summary>
			public ReaderCollection Reader
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
			
			private bool pruneModifiedRecords = false;

			/// <summary>
			/// True to clear all modified record information each time the store is loaded or when a record is removed. (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool PruneModifiedRecords 
			{ 
				get
				{
					return this.pruneModifiedRecords;
				}
				set
				{
					this.pruneModifiedRecords = value;
				}
			}

			private bool remoteSort = false;

			/// <summary>
			/// True if sorting is to be handled by requesting the Proxy to provide a refreshed version of the data object in sorted order, as opposed to sorting the Record cache in place (defaults to false). If remote sorting is specified, then clicking on a column header causes the current page to be requested from the server with the addition of the following two parameters: sort: String - The name (as specified in the Record's Field definition) of the field to sort on. dir : String - The direction of the sort, 'ASC' or 'DESC' (case-sensitive).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RemoteSort 
			{ 
				get
				{
					return this.remoteSort;
				}
				set
				{
					this.remoteSort = value;
				}
			}

			private bool remotePaging = true;

			/// <summary>
			/// True to perform remote paging.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool RemotePaging 
			{ 
				get
				{
					return this.remotePaging;
				}
				set
				{
					this.remotePaging = value;
				}
			}
        
			private SortInfo sortInfo = null;

			/// <summary>
			/// An object which determines the Store sorting information.
			/// </summary>
			public SortInfo SortInfo
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
			
			private bool warningOnDirty = true;

			/// <summary>
			/// If true show a warning before load/reload if store has dirty data
			/// </summary>
			[DefaultValue(true)]
			public virtual bool WarningOnDirty 
			{ 
				get
				{
					return this.warningOnDirty;
				}
				set
				{
					this.warningOnDirty = value;
				}
			}

			private string dirtyWarningTitle = "Uncommitted Changes";

			/// <summary>
			/// The title of window showing before load if the dirty data exists
			/// </summary>
			[DefaultValue("Uncommitted Changes")]
			public virtual string DirtyWarningTitle 
			{ 
				get
				{
					return this.dirtyWarningTitle;
				}
				set
				{
					this.dirtyWarningTitle = value;
				}
			}

			private string dirtyWarningText = "You have uncommitted changes.  Are you sure you want to load/reload data?";

			/// <summary>
			/// The text of window showing before load if the dirty data exists
			/// </summary>
			[DefaultValue("You have uncommitted changes.  Are you sure you want to load/reload data?")]
			public virtual string DirtyWarningText 
			{ 
				get
				{
					return this.dirtyWarningText;
				}
				set
				{
					this.dirtyWarningText = value;
				}
			}

			private RefreshAfterSavingMode refreshAfterSaving = RefreshAfterSavingMode.Auto;

			/// <summary>
			/// The refresh mode
			/// </summary>
			[DefaultValue(RefreshAfterSavingMode.Auto)]
			public virtual RefreshAfterSavingMode RefreshAfterSaving 
			{ 
				get
				{
					return this.refreshAfterSaving;
				}
				set
				{
					this.refreshAfterSaving = value;
				}
			}

			private string groupField = "";

			/// <summary>
			/// The field name by which to sort the store's data (defaults to '').
			/// </summary>
			[DefaultValue("")]
			public virtual string GroupField 
			{ 
				get
				{
					return this.groupField;
				}
				set
				{
					this.groupField = value;
				}
			}

			private SortDirection groupDir = SortDirection.Default;

			/// <summary>
			/// Group field sorting direction
			/// </summary>
			[DefaultValue(SortDirection.Default)]
			public virtual SortDirection GroupDir 
			{ 
				get
				{
					return this.groupDir;
				}
				set
				{
					this.groupDir = value;
				}
			}

			private bool groupOnSort = false;

			/// <summary>
			/// True to sort the data on the grouping field when a grouping operation occurs, false to sort based on the existing sort info (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool GroupOnSort 
			{ 
				get
				{
					return this.groupOnSort;
				}
				set
				{
					this.groupOnSort = value;
				}
			}

			private bool remoteGroup = false;

			/// <summary>
			/// True if the grouping should apply on the server side, false if it is local only (defaults to false). If the grouping is local, it can be applied immediately to the data. If it is remote, then it will simply act as a helper, automatically sending the grouping field name as the 'groupBy' param with each XHR call.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool RemoteGroup 
			{ 
				get
				{
					return this.remoteGroup;
				}
				set
				{
					this.remoteGroup = value;
				}
			}

			private bool ignoreExtraFields = true;

			/// <summary>
			/// If true then only properties included to reader will be converted to json
			/// </summary>
			[DefaultValue(true)]
			public virtual bool IgnoreExtraFields 
			{ 
				get
				{
					return this.ignoreExtraFields;
				}
				set
				{
					this.ignoreExtraFields = value;
				}
			}

			private bool showWarningOnFailure = true;

			/// <summary>
			/// Show a Window with error message is DirectEvent request fails.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowWarningOnFailure 
			{ 
				get
				{
					return this.showWarningOnFailure;
				}
				set
				{
					this.showWarningOnFailure = value;
				}
			}

			private bool skipIdForNewRecords = true;

			/// <summary>
			/// Skip Id field from save data for new records.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SkipIdForNewRecords 
			{ 
				get
				{
					return this.skipIdForNewRecords;
				}
				set
				{
					this.skipIdForNewRecords = value;
				}
			}

        }
    }
}