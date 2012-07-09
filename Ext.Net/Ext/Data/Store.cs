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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Xml;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// The Store class encapsulates a client side cache of Record objects which provide
    /// input data for Components such as the GridPanel, the ComboBox, or the DataView
    /// 
    /// A Store object uses its configured implementation of DataProxy to access a data
    /// object unless you call loadData directly and pass in your data.
    ///
    /// A Store object has no knowledge of the format of the data returned by the Proxy.
    ///
    /// A Store object uses its configured implementation of DataReader to create Record
    /// instances from the data object. These Records are cached and made available through
    /// accessor functions.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Store runat=\"server\"></{0}:Store>")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(Store), "Build.ToolboxIcons.Store.bmp")]
    [Description("The Store class encapsulates a client side cache of Record objects which provide input data for Components such as the GridPanel, the ComboBox, or the DataView.")]
    public partial class Store : StoreDataBound, IPostBackEventHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Store() { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 1;

                baseList.Add(XControl.ExtNetDataItem);

                return baseList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                string className = "Ext.net.Store";

                if (this.Proxy.Count == 0 || !this.RemotePaging)
                {
                    className = "Ext.ux.data.PagingStore";
                }

                return className;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!this.DesignMode && !this.IsLazy)
            {
                this.Page.LoadComplete += Page_LoadComplete;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal override bool IsIdRequired
        {
            get
            {
                return true;
            }
        }

        void Page_LoadComplete(object sender, EventArgs e)
        {
            if (this.ParentComponent == null || (RequestManager.IsMicrosoftAjaxRequest && !this.IsInUpdatePanelRefresh))
            {
                return;
            }

            Component parent = this.ParentComponent;

            if (parent != null)
            {
                parent = this.ParentComponent;
                while (parent != null && (parent.IsLazy || parent.IsLayout))
                {
                    parent = parent.ParentComponent;
                }
            }


            if (parent != null)
            {
                parent.BeforeClientInit += Parent_BeforeClientInit;
            }
        }

        void Parent_BeforeClientInit(Observable sender)
        {
            this.ForcePreRender();
        }

        internal override void ForcePreRender()
        {
            if (!RequestManager.IsAjaxRequest && !this.IsLazy)
            {
                this.EnsureDataBound();
                base.ForcePreRender();    
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("proxy", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string MemoryProxy
        {
            get
            {
                if (this.Proxy.Count == 0)
                {
                    if (this.MemoryDataPresent)
                    {
                        string template = "new Ext.data.PagingMemoryProxy({0}, {1})";
                        return string.Format(template, this.Data != null ? JSON.Serialize(this.Data) : JsonData, JSON.Serialize(this.IsUrl));
                    }
                    else
                    {
                        return "new Ext.data.PagingMemoryProxy({})";
                    }
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("beforeLoadParams", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string BeforeLoadParamsProxy
        {
            get
            {
                if (this.BaseParams.Count > 0)
                {
                    return this.BuildParams(this.BaseParams);
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("beforeSaveParams", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string BeforeSaveParamsProxy
        {
            get
            {
                if (this.WriteBaseParams.Count > 0)
                {
                    return this.BuildParams(this.WriteBaseParams);
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool MemoryDataPresent
        {
            get 
            { 
                return this.Reader != null && this.Reader.Reader != null && (this.Data != null || this.JsonData.IsNotEmpty()); 
            }
        }

        private string BuildParams(ParameterCollection parameters)
        {
            StringBuilder sb = new StringBuilder("function(store,options){if (!options.params){options.params = {};};");

            sb.AppendFormat("Ext.apply(options.params,{0});", parameters.ToJson(2));
            sb.AppendFormat("Ext.applyIf(options.params,{0});", parameters.ToJson(1));
            sb.Append("}");

            return sb.ToString();
        }

        private StoreListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public StoreListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new StoreListeners();
                }

                return this.listeners;
            }
        }

        private StoreDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public StoreDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new StoreDirectEvents();
                }
                
                return this.directEvents;
            }
        }

        /*  IPostBackEventHandler
        -----------------------------------------------------------------------------------------------*/

        private static readonly object EventBeforeStoreChanged = new object();
        private static readonly object EventAfterStoreChanged = new object();
        private static readonly object EventBeforeRecordUpdated = new object();
        private static readonly object EventAfterRecordUpdated = new object();
        private static readonly object EventBeforeRecordDeleted = new object();
        private static readonly object EventAfterRecordDeleted = new object();
        private static readonly object EventBeforeRecordPostBackInserted = new object();
        private static readonly object EventBeforeRecordInserted = new object();
        private static readonly object EventAfterRecordInserted = new object();
        private static readonly object EventBeforeDirectEvent = new object();
        private static readonly object EventAfterDirectEvent = new object();
        private static readonly object EventRefreshData = new object();
        private static readonly object EventSubmitData = new object();

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void BeforeStoreChangedEventHandler(object sender, BeforeStoreChangedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void AfterStoreChangedEventHandler(object sender, AfterStoreChangedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void BeforeRecordUpdatedEventHandler(object sender, BeforeRecordUpdatedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void AfterRecordUpdatedEventHandler(object sender, AfterRecordUpdatedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void BeforeRecordDeletedEventHandler(object sender, BeforeRecordDeletedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void AfterRecordDeletedEventHandler(object sender, AfterRecordDeletedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void BeforeRecordInsertedEventHandler(object sender, BeforeRecordInsertedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void AfterRecordInsertedEventHandler(object sender, AfterRecordInsertedEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void BeforeDirectEventHandler(object sender, BeforeDirectEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void AfterDirectEventHandler(object sender, AfterDirectEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void AjaxRefreshDataEventHandler(object sender, StoreRefreshDataEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void AjaxSubmitDataEventHandler(object sender, StoreSubmitDataEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event BeforeStoreChangedEventHandler BeforeStoreChanged
        {
            add
            {
                this.Events.AddHandler(EventBeforeStoreChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventBeforeStoreChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event AfterStoreChangedEventHandler AfterStoreChanged
        {
            add
            {
                this.Events.AddHandler(EventAfterStoreChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventAfterStoreChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event BeforeRecordUpdatedEventHandler BeforeRecordUpdated
        {
            add
            {
                this.Events.AddHandler(EventBeforeRecordUpdated, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventBeforeRecordUpdated, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event AfterRecordUpdatedEventHandler AfterRecordUpdated
        {
            add
            {
                this.Events.AddHandler(EventAfterRecordUpdated, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventAfterRecordUpdated, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event BeforeRecordDeletedEventHandler BeforeRecordDeleted
        {
            add
            {
                this.Events.AddHandler(EventBeforeRecordDeleted, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventBeforeRecordDeleted, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event AfterRecordDeletedEventHandler AfterRecordDeleted
        {
            add
            {
                this.Events.AddHandler(EventAfterRecordDeleted, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventAfterRecordDeleted, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event BeforeRecordInsertedEventHandler BeforeRecordInserted
        {
            add
            {
                this.Events.AddHandler(EventBeforeRecordInserted, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventBeforeRecordInserted, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event AfterRecordInsertedEventHandler AfterRecordInserted
        {
            add
            {
                this.Events.AddHandler(EventAfterRecordInserted, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventAfterRecordInserted, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event AfterDirectEventHandler AfterDirectEvent
        {
            add
            {
                this.Events.AddHandler(EventAfterDirectEvent, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventAfterDirectEvent, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event BeforeDirectEventHandler BeforeDirectEvent
        {
            add
            {
                this.Events.AddHandler(EventBeforeDirectEvent, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventBeforeDirectEvent, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event AjaxRefreshDataEventHandler RefreshData
        {
            add
            {
                this.Events.AddHandler(EventRefreshData, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventRefreshData, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event AjaxSubmitDataEventHandler SubmitData
        {
            add
            {
                this.Events.AddHandler(EventSubmitData, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventSubmitData, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnAfterStoreChanged(AfterStoreChangedEventArgs e)
        {
            AfterStoreChangedEventHandler handler = (AfterStoreChangedEventHandler)Events[EventAfterStoreChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnBeforeStoreChanged(BeforeStoreChangedEventArgs e)
        {
            BeforeStoreChangedEventHandler handler = (BeforeStoreChangedEventHandler)Events[EventBeforeStoreChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnBeforeRecordUpdated(BeforeRecordUpdatedEventArgs e)
        {
            BeforeRecordUpdatedEventHandler handler = (BeforeRecordUpdatedEventHandler)Events[EventBeforeRecordUpdated];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnAfterRecordUpdated(AfterRecordUpdatedEventArgs e)
        {
            AfterRecordUpdatedEventHandler handler = (AfterRecordUpdatedEventHandler)Events[EventAfterRecordUpdated];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnBeforeRecordDeleted(BeforeRecordDeletedEventArgs e)
        {
            BeforeRecordDeletedEventHandler handler = (BeforeRecordDeletedEventHandler)Events[EventBeforeRecordDeleted];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnAfterRecordDeleted(AfterRecordDeletedEventArgs e)
        {
            AfterRecordDeletedEventHandler handler = (AfterRecordDeletedEventHandler)Events[EventAfterRecordDeleted];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnBeforeRecordInserted(BeforeRecordInsertedEventArgs e)
        {
            BeforeRecordInsertedEventHandler handler = (BeforeRecordInsertedEventHandler)Events[EventBeforeRecordInserted];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnAfterRecordInserted(AfterRecordInsertedEventArgs e)
        {
            AfterRecordInsertedEventHandler handler = (AfterRecordInsertedEventHandler)Events[EventAfterRecordInserted];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnAjaxPostBack(BeforeDirectEventArgs e)
        {
            BeforeDirectEventHandler handler = (BeforeDirectEventHandler)Events[EventBeforeDirectEvent];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnRefreshData(StoreRefreshDataEventArgs e)
        {
            AjaxRefreshDataEventHandler handler = (AjaxRefreshDataEventHandler)Events[EventRefreshData];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnSubmitData(StoreSubmitDataEventArgs e)
        {
            AjaxSubmitDataEventHandler handler = (AjaxSubmitDataEventHandler)Events[EventSubmitData];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnAjaxPostBackResult(AfterDirectEventArgs e)
        {
            AfterDirectEventHandler handler = (AfterDirectEventHandler)Events[EventAfterDirectEvent];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private IDictionary keys;
        private IDictionary values;
        private IDictionary oldValues;
        private bool needRetrieve;
        private ConfirmationRecord confirmation;
        private XmlNode record;
        
        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            if (RequestManager.IsAjaxRequest)
            {
                if (eventArgument.IsEmpty())
                {
                    return;
                }
                this.RaiseAjaxPostBackEvent(eventArgument);
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (RequestManager.IsAjaxRequest && this.ParentForm == null)
            {
                this.Page.LoadComplete += new EventHandler(Store_LoadComplete);
            }
        }

        private void Store_LoadComplete(object sender, EventArgs e)
        {
            if (this.IsDynamic)
            {
                return;
            }

            if (this.Page == null)
            {
                return;
            }
            
            string _ea = this.Page.Request["__EVENTARGUMENT"];

            if (_ea.IsNotEmpty())
            {
                string _et = this.Page.Request["__EVENTTARGET"];

                if (_et == this.UniqueID)
                {
                    RaiseAjaxPostBackEvent(_ea);
                }

                return;
            }

            if (this.SubmitConfig == null)
            {
                return;
            }

            XmlNode eventArgumentNode = this.SubmitConfig.SelectSingleNode("config/__EVENTARGUMENT");

            if (eventArgumentNode == null)
            {
                throw new InvalidOperationException(
                    "Incorrect submit config - the '__EVENTARGUMENT' parameter is absent");
            }

            XmlNode eventTargetNode = this.SubmitConfig.SelectSingleNode("config/__EVENTTARGET");

            if (eventTargetNode == null)
            {
                throw new InvalidOperationException(
                    "Incorrect submit config - the '__EVENTTARGET' parameter is absent");
            }

            if (eventTargetNode.InnerText == this.UniqueID)
            {
                RaiseAjaxPostBackEvent(eventArgumentNode.InnerText);
            }
        }

        private BeforeStoreChangedEventArgs changingEventArgs;

        private void DoSaving(string jsonData, XmlNode callbackParameters)
        {
            changingEventArgs = new BeforeStoreChangedEventArgs(jsonData, null, callbackParameters);

            ConfirmationList confirmationList = null;

            if (this.UseIdConfirmation && this.Reader.Reader != null)
            {
                confirmationList = changingEventArgs.DataHandler.BuildConfirmationList(GetIdColumnName());
            }
            
            changingEventArgs.ConfirmationList = confirmationList;

            this.OnBeforeStoreChanged(changingEventArgs);

            Exception ex = null;

            try
            {
                if (!changingEventArgs.Cancel)
                {
                    this.MakeChanges();
                }
            }
            catch (Exception e)
            {
                ex = e;
            }

            AfterStoreChangedEventArgs eStoreChanged = new AfterStoreChangedEventArgs(true, ex, confirmationList);
            this.OnAfterStoreChanged(eStoreChanged);

            if (eStoreChanged.Exception != null && !eStoreChanged.ExceptionHandled)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void MakeChanges()
        {
            bool noDs = this.DataSourceID.IsEmpty();
            IDataSource ds = null;

            if (!noDs)
            {
                ds = this.GetDataSource();
            }

            if (ds == null && !noDs)
            {
                throw new HttpException("Can't find DataSource");
            }

            if (this.Reader.Reader == null)
            {
                throw new InvalidOperationException("The Store does not contain a Reader.");
            }

            XmlDocument xml = changingEventArgs.DataHandler.XmlData;

            if (noDs || ds.GetView(this.DataMember).CanUpdate)
            {
                this.MakeUpdates(ds, xml); 
            }

            if (noDs || ds.GetView(this.DataMember).CanDelete)
            {
                this.MakeDeletes(ds, xml);
            }

            if (noDs || ds.GetView(this.DataMember).CanInsert)
            {
                this.MakeInsertes(ds, xml);
            }
        }

        private string GetIdColumnName()
        {
            string id = "";

            if (this.Reader.Reader != null)
            {
                id = this.Reader.Reader.IDField;
            }

            return id;
        }

        private void MakeUpdates(IDataSource ds, XmlDocument xml)
        {
            XmlNodeList updatingRecords = xml.SelectNodes("records/Updated/record");
            
            string id = GetIdColumnName();

            foreach (XmlNode node in updatingRecords)
            {
                record = node;
                values = new SortedList(this.Reader.Reader.Fields.Count);
                keys = new SortedList();
                oldValues = new SortedList();

                foreach (RecordField field in this.Reader.Reader.Fields)
                {
                    XmlNode keyNode = node.SelectSingleNode(field.Name);
                    values[field.Name] = keyNode != null ? keyNode.InnerText : null;
                }

                confirmation = null;

                if (id.IsNotEmpty())
                {
                    XmlNode keyNode = node.SelectSingleNode(id);
                    string idStr = keyNode != null ? keyNode.InnerText : null;
                    
                    int idInt;

                    if (int.TryParse(idStr, out idInt))
                    {
                        keys[id] = idInt;
                    }
                    else
                    {
                        keys[id] = idStr;
                    }
                    
                    if (this.UseIdConfirmation && keys[id] != null)
                    {
                        confirmation = changingEventArgs.ConfirmationList[keys[id].ToString()];
                    }
                }

                BeforeRecordUpdatedEventArgs eBeforeRecordUpdated = new BeforeRecordUpdatedEventArgs(record, keys, values, oldValues, confirmation);
                this.OnBeforeRecordUpdated(eBeforeRecordUpdated);

                if (eBeforeRecordUpdated.CancelAll)
                {
                    break;
                }

                if (eBeforeRecordUpdated.Cancel)
                {
                    continue;
                }

                if (ds !=null)
                {
                    ds.GetView("").Update(keys, values, oldValues, this.UpdateCallback);
                }
                else
                {
                    this.UpdateCallback(0, null);
                }
                
            }
        }

        private void MakeDeletes(IDataSource ds, XmlDocument xml)
        {
            XmlNodeList deletingRecords = xml.SelectNodes("records/Deleted/record");
            string id = GetIdColumnName();

            foreach (XmlNode node in deletingRecords)
            {
                record = node;
                values = new SortedList(0);
                keys = new SortedList();
                oldValues = new SortedList(0);

                confirmation = null;

                if (id.IsNotEmpty())
                {
                    XmlNode keyNode = node.SelectSingleNode(id);
                    string idStr = keyNode != null ? keyNode.InnerText : null;

                    int idInt;

                    if (int.TryParse(idStr, out idInt))
                    {
                        keys[id] = idInt;
                    }
                    else
                    {
                        keys[id] = idStr;
                    }

                    if (this.UseIdConfirmation && keys[id] != null)
                    {
                        confirmation = changingEventArgs.ConfirmationList[keys[id].ToString()];
                    }
                }

                BeforeRecordDeletedEventArgs eBeforeRecordDeleted = new BeforeRecordDeletedEventArgs(record, keys, confirmation);
                this.OnBeforeRecordDeleted(eBeforeRecordDeleted);

                if (eBeforeRecordDeleted.CancelAll)
                {
                    break;
                }

                if (eBeforeRecordDeleted.Cancel)
                {
                    continue;
                }
                
                if (ds != null)
                {
                    ds.GetView("").Delete(keys, oldValues, DeleteCallback);
                }
                else
                {
                    this.DeleteCallback(0, null);
                }
            }

            if (deletingRecords.Count > 0)
            {
                needRetrieve = true;
            }
        }

        private void MakeInsertes(IDataSource ds, XmlDocument xml)
        {
            XmlNodeList insertingRecords = xml.SelectNodes("records/Created/record");
            string id = GetIdColumnName();

            foreach (XmlNode node in insertingRecords)
            {
                record = node;
                values = new SortedList(this.Reader.Reader.Fields.Count);
                keys = new SortedList();
                oldValues = new SortedList();

                foreach (RecordField field in this.Reader.Reader.Fields)
                {
                    XmlNode keyNode = node.SelectSingleNode(field.Name);
                    values[field.Name] = keyNode != null ? keyNode.InnerText : null;
                }

                confirmation = null;

                if (id.IsNotEmpty())
                {
                    XmlNode keyNode = node.SelectSingleNode(id);
                    
                    if (this.UseIdConfirmation && keyNode != null && keyNode.InnerText.IsNotEmpty())
                    {
                        confirmation = changingEventArgs.ConfirmationList[keyNode.InnerText];
                    }
                }

                BeforeRecordInsertedEventArgs eBeforeRecordInserted = new BeforeRecordInsertedEventArgs(record, keys, values, confirmation);
                this.OnBeforeRecordInserted(eBeforeRecordInserted);

                if (eBeforeRecordInserted.CancelAll)
                {
                    break;
                }

                if (eBeforeRecordInserted.Cancel)
                {
                    continue;
                }
                
                if (ds != null)
                {
                    ds.GetView("").Insert(values, InsertCallback);
                }
                else
                {
                    this.InsertCallback(0, null);
                }
            }

            if (insertingRecords.Count > 0)
            {
                needRetrieve = true;
            }
        }

        bool UpdateCallback(int recordsAffected, Exception exception)
        {
            if (confirmation != null && recordsAffected > 0)
            {
                confirmation.ConfirmRecord();
            }
            AfterRecordUpdatedEventArgs eAfterRecordUpdated = new AfterRecordUpdatedEventArgs(record, recordsAffected, exception, keys, values, oldValues, confirmation);
            this.OnAfterRecordUpdated(eAfterRecordUpdated);

            return eAfterRecordUpdated.ExceptionHandled;
        }

        bool DeleteCallback(int recordsAffected, Exception exception)
        {
            if (confirmation != null && recordsAffected > 0)
            {
                confirmation.ConfirmRecord();
            }

            AfterRecordDeletedEventArgs eAfterRecordDeleted = new AfterRecordDeletedEventArgs(record, recordsAffected, exception, keys, confirmation);
            this.OnAfterRecordDeleted(eAfterRecordDeleted);

            return eAfterRecordDeleted.ExceptionHandled;
        }

        bool InsertCallback(int recordsAffected, Exception exception)
        {
            if (confirmation != null && recordsAffected > 0)
            {
                confirmation.ConfirmRecord();
            }

            AfterRecordInsertedEventArgs eAfterRecordInserted = new AfterRecordInsertedEventArgs(record, recordsAffected, exception, keys, values, confirmation);
            this.OnAfterRecordInserted(eAfterRecordInserted);

            return eAfterRecordInserted.ExceptionHandled;
        }


        /*  ------------------------------------------------------------------------------------------*/

        private bool success = true;
        private string msg;

        private void RaiseAjaxPostBackEvent(string eventArgument)
        {
            bool needConfirmation = false;

            try
            {
                if (eventArgument.IsEmpty())
                {
                    throw new ArgumentNullException("eventArgument");
                }

                XmlNode xmlData = this.SubmitConfig;
                string data = null;
                XmlNode parametersNode = null;

                if (xmlData != null)
                {
                    parametersNode = xmlData.SelectSingleNode("config/extraParams");
                
                    XmlNode serviceNode = xmlData.SelectSingleNode("config/serviceParams");

                    if (serviceNode != null)
                    {
                        data = serviceNode.InnerText;
                    }
                }

                string action = eventArgument;

                BeforeDirectEventArgs e = new BeforeDirectEventArgs(action, data, parametersNode);
                this.OnAjaxPostBack(e);
                PageProxy dsp = this.Proxy.Proxy as PageProxy;

                if (this.AutoDecode && data.IsNotEmpty())
                {
                    data = HttpUtility.HtmlDecode(data);
                }

                switch(action)
                {
                    case "update":
                        if (data == null)
                        {
                            throw new InvalidOperationException("No data in request");
                        }

                        needConfirmation = this.UseIdConfirmation;
                        this.DoSaving(data, parametersNode);
                        
                        if (this.RefreshAfterSaving == RefreshAfterSavingMode.None || dsp != null)
                        {
                            needRetrieve = false;
                        }
                        
                        break;
                    case "refresh":
                        needRetrieve = true;
                        StoreRefreshDataEventArgs refreshArgs = new StoreRefreshDataEventArgs(parametersNode);
                        this.OnRefreshData(refreshArgs);
                        
                        if (dsp != null)
                        {
                            if (refreshArgs.Total > -1)
                            {
                                dsp.Total = refreshArgs.Total; 
                            }
                        }

                        break;
                    case "submit":
                        needRetrieve = false;

                        if (data == null)
                        {
                            throw new InvalidOperationException("No data in request");
                        }

                        StoreSubmitDataEventArgs args =new StoreSubmitDataEventArgs(data, parametersNode);
                        this.OnSubmitData(args);

                        break;
                }
            }
            catch (Exception ex)
            {
                success = false;
                msg = this.IsDebugging ? ex.ToString() : ex.Message;

                if (this.ResourceManager.RethrowAjaxExceptions)
                {
                    throw;
                }
            }

            AfterDirectEventArgs eAjaxPostBackResult = new AfterDirectEventArgs(new Response(success, msg));
            this.OnAjaxPostBackResult(eAjaxPostBackResult);
            
            StoreResponseData response = new StoreResponseData();
            
            if (needRetrieve && eAjaxPostBackResult.Response.Success)
            {
                if (this.RequiresDataBinding)
                {
                    this.DataBind(); 
                }

                response.Data = this.GetAjaxDataJson();
                PageProxy dsp = this.Proxy.Proxy as PageProxy;
                response.Total = dsp != null ? dsp.Total : 0;
            }

            if (needConfirmation)
            {
                response.Confirmation = changingEventArgs.ConfirmationList;
            }

            eAjaxPostBackResult.Response.Data = response.ToString();

            ResourceManager.ServiceResponse = eAjaxPostBackResult.Response;
        }
    }
}
