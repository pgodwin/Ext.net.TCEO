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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Xml;

using Ext.Net.Utilities;
using Newtonsoft.Json.Serialization;

namespace Ext.Net
{
    /// <summary>
    /// The TreePanel provides tree-structured UI representation of tree-structured data.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:TreePanel runat=\"server\" Title=\"Title\" Height=\"300\"></{0}:TreePanel>")]
    [ToolboxBitmap(typeof(TreePanel), "Build.ToolboxIcons.TreePanel.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("The TreePanel provides tree-structured UI representation of tree-structured data.")]
    public partial class TreePanel : TreePanelBase, IAjaxPostBackEventHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TreePanel() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "nettreepanel";
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
                return "Ext.net.TreePanel";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("raRenameUrl", JsonMode.Url)]
        [Category("7. TreePanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RemoteRenameUrl
        {
            get
            {
                return (string)this.ViewState["RemoteRenameUrl"] ?? "";
            }
            set
            {
                this.ViewState["RemoteRenameUrl"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("raRemoveUrl", JsonMode.Url)]
        [Category("7. TreePanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RemoteRemoveUrl
        {
            get
            {
                return (string)this.ViewState["RemoteRemoveUrl"] ?? "";
            }
            set
            {
                this.ViewState["RemoteRemoveUrl"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("raAppendUrl", JsonMode.Url)]
        [Category("7. TreePanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RemoteAppendUrl
        {
            get
            {
                return (string)this.ViewState["RemoteAppendUrl"] ?? "";
            }
            set
            {
                this.ViewState["RemoteAppendUrl"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("raInsertUrl", JsonMode.Url)]
        [Category("7. TreePanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RemoteInsertUrl
        {
            get
            {
                return (string)this.ViewState["RemoteInsertUrl"] ?? "";
            }
            set
            {
                this.ViewState["RemoteInsertUrl"] = value;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("raMoveUrl", JsonMode.Url)]
        [Category("7. TreePanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string RemoteMoveUrl
        {
            get
            {
                return (string)this.ViewState["RemoteMoveUrl"] ?? "";
            }
            set
            {
                this.ViewState["RemoteMoveUrl"] = value;
            }
        }

        private static readonly object EventSubmit = new object();
        private static readonly object EventRename = new object();
        private static readonly object EventRemove = new object();
        private static readonly object EventAppend = new object();
        private static readonly object EventMove = new object();

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void SubmitEventHandler(object sender, SubmitEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void RemoteRenameEventHandler(object sender, RemoteRenameEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void RemoteActionEventHandler(object sender, RemoteActionEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void RemoteAppendEventHandler(object sender, RemoteAppendEventArgs e);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void RemoteMoveEventHandler(object sender, RemoteMoveEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event SubmitEventHandler Submit
        {
            add
            {
                this.Events.AddHandler(EventSubmit, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventSubmit, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event RemoteRenameEventHandler RemoteRename
        {
            add
            {
                this.Events.AddHandler(EventRename, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventRename, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event RemoteActionEventHandler RemoteRemove
        {
            add
            {
                this.Events.AddHandler(EventRemove, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventRemove, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event RemoteAppendEventHandler RemoteAppend
        {
            add
            {
                this.Events.AddHandler(EventAppend, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventAppend, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event RemoteMoveEventHandler RemoteMove
        {
            add
            {
                this.Events.AddHandler(EventMove, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventMove, value);
            }
        }

        internal virtual void OnSubmit(SubmitEventArgs e)
        {
            SubmitEventHandler handler = (SubmitEventHandler)Events[EventSubmit];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        internal virtual void OnRemoteRename(RemoteRenameEventArgs e)
        {
            RemoteRenameEventHandler handler = (RemoteRenameEventHandler)Events[EventRename];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        internal virtual void OnRemoteRemove(RemoteActionEventArgs e)
        {
            RemoteActionEventHandler handler = (RemoteActionEventHandler)Events[EventRemove];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        internal virtual void OnRemoteAppend(RemoteAppendEventArgs e)
        {
            RemoteAppendEventHandler handler = (RemoteAppendEventHandler)Events[EventAppend];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        internal virtual void OnRemoteMove(RemoteMoveEventArgs e)
        {
            RemoteMoveEventHandler handler = (RemoteMoveEventHandler)Events[EventMove];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        bool initParams = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.initParams)
            {
                return;
            }

            if (this.Loader.Primary != null && this.Loader.Primary.BaseParams.Count > 0)
            {
                TreeLoader loader = this.Loader.Primary as TreeLoader;

                if (loader != null)
                {
                    if (loader.Listeners.BeforeLoad.IsDefault)
                    {
                        loader.Listeners.BeforeLoad.Fn = BuildParams(this.Loader.Primary.BaseParams, null, true);     
                    }
                    else
                    {
                        if (loader.Listeners.BeforeLoad.Fn.IsNotEmpty())
                        {
                            loader.Listeners.BeforeLoad.Fn = BuildParams(this.Loader.Primary.BaseParams, loader.Listeners.BeforeLoad.Fn, true);     
                        }
                        else
                        {
                            loader.Listeners.BeforeLoad.Fn = BuildParams(this.Loader.Primary.BaseParams, loader.Listeners.BeforeLoad.Handler, false);     
                        }
                    }
                }
            }

            if (this.RemoteExtraParams.Count > 0)
            {
                if (this.Listeners.BeforeRemoteAction.IsDefault)
                {
                    this.Listeners.BeforeRemoteAction.Fn = this.BuildRemoteParams(this.RemoteExtraParams, null, true);
                }
                else
                {
                    if (this.Listeners.BeforeRemoteAction.Fn.IsNotEmpty())
                    {
                        this.Listeners.BeforeRemoteAction.Fn = this.BuildRemoteParams(this.RemoteExtraParams, this.Listeners.BeforeRemoteAction.Fn, true);
                    }
                    else
                    {
                        this.Listeners.BeforeRemoteAction.Fn = this.BuildRemoteParams(this.RemoteExtraParams, this.Listeners.BeforeRemoteAction.Handler, false);
                    }
                }
            }

            this.initParams = true;
        }

        private string BuildRemoteParams(ParameterCollection parameters, string userHandler, bool isFn)
        {
            StringBuilder sb = new StringBuilder("function(tree, node, action, o){");

            sb.AppendFormat("Ext.apply(o.params,{0});", parameters.ToJson());

            if (userHandler.IsNotEmpty())
            {
                sb.Append(userHandler);

                if (isFn)
                {
                    sb.Append("(tree, node, action, o);");
                }
            }
            sb.Append("}");

            return sb.ToString();
        }

        private string BuildParams(ParameterCollection parameters, string userHandler, bool isFn)
        {
            StringBuilder sb = new StringBuilder("function(loader,node){if (!loader.baseParams){loader.baseParams = {};};");

            sb.AppendFormat("Ext.apply(loader.baseParams,{0});", parameters.ToJson(0));

            if (userHandler.IsNotEmpty())
            {
                sb.Append(userHandler);

                if (isFn)
                {
                    sb.Append("(loader,node);");
                }
            }
            sb.Append("}");

            return sb.ToString();
        }
        
        private TreePanelListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public TreePanelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new TreePanelListeners();
                }

                return this.listeners;
            }
        }


        private TreePanelDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side DirectEventHandlers")]
        public TreePanelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new TreePanelDirectEvents();
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            bool result = base.LoadPostData(postDataKey, postCollection);
            string val = postCollection[this.ConfigID.ConcatWith("_SM")];

            if (val != null && this.SelectionModel.Primary != null)
            {
                if (this.SelectionModel.Primary is DefaultSelectionModel)
                {
                    SubmittedNode node = JSON.Deserialize<SubmittedNode>(val, new CamelCasePropertyNamesContractResolver());
                    ((DefaultSelectionModel) this.SelectionModel.Primary).SelectedNode = node;
                }
                else if (this.SelectionModel.Primary is MultiSelectionModel)
                {
                    List<SubmittedNode> nodes = JSON.Deserialize<List<SubmittedNode>>(val, new CamelCasePropertyNamesContractResolver());
                    ((MultiSelectionModel)this.SelectionModel.Primary).SelectedNodes = nodes;
                }
            }

            val = postCollection[this.ConfigID.ConcatWith("_CheckNodes")];
            if (val != null)
            {
                List<SubmittedNode> nodes = JSON.Deserialize<List<SubmittedNode>>(val, new CamelCasePropertyNamesContractResolver());
                this.CheckedNodes = nodes;
            }

            return result;
        }

        protected virtual void RegisterNodesIcons(TreeNodeCollection nodes)
        {
            if (ResourceManager.HasResourceManager)
            {
                foreach (TreeNodeBase node in nodes)
                {
                    if (node.Icon != Icon.None)
                    {
                        ResourceManager.GetInstance().RegisterIcon(node.Icon);
                    }

                    TreeNode treeNode = node as TreeNode;

                    if (treeNode != null && treeNode.Nodes.Count > 0)
                    {
                        this.RegisterNodesIcons(treeNode.Nodes);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgument"></param>
        /// <param name="extraParams"></param>
        [Description("")]
        public void RaiseAjaxPostBackEvent(string eventArgument, ParameterCollection extraParams)
        {
            bool success = true;
            string msg = null;

            Response response = new Response();

            try
            {
                if (eventArgument.IsEmpty())
                {
                    throw new ArgumentNullException("eventArgument");
                }

                XmlNode xmlData = this.SubmitConfig;
                string data = null;

                if (xmlData != null)
                {
                    XmlNode serviceNode = xmlData.SelectSingleNode("config/serviceParams");

                    if (serviceNode != null)
                    {
                        data = serviceNode.InnerText;
                    }
                }

                switch(eventArgument)
                {
                    case "nodeload":
                        NodeLoadEventArgs e = new NodeLoadEventArgs(extraParams);
                        PageTreeLoader loader = (PageTreeLoader) this.Loader.Primary;
                        loader.OnNodeLoad(e);
                        TreeNodeCollection nodes = e.Nodes;
                        success = e.Success;
                        msg = e.ErrorMessage;
                        response.Data = nodes != null ? nodes.ToJson() : null;
                        break;
                    case "submit":
                        SubmitEventArgs se = new SubmitEventArgs(extraParams, JSON.Deserialize<SubmittedNode>(data, new CamelCasePropertyNamesContractResolver()));
                        this.OnSubmit(se);
                        break;
                    case "raRename":
                        RemoteRenameEventArgs rr = new RemoteRenameEventArgs(data,extraParams);
                        this.OnRemoteRename(rr);
                        success = rr.Accept;
                        msg = rr.RefusalMessage;
                        break;
                    case "raRemove":
                        RemoteActionEventArgs rrm = new RemoteActionEventArgs(data, extraParams);
                        this.OnRemoteRemove(rrm);
                        success = rrm.Accept;
                        msg = rrm.RefusalMessage;
                        break;
                    case "raInsert":
                    case "raAppend":
                        RemoteAppendEventArgs ra = new RemoteAppendEventArgs(eventArgument == "raInsert", data, extraParams);
                        this.OnRemoteAppend(ra);
                        success = ra.Accept;
                        msg = ra.RefusalMessage;
                        break;
                    case "raMove":
                        RemoteMoveEventArgs rm = new RemoteMoveEventArgs(data, extraParams);
                        this.OnRemoteMove(rm);
                        success = rm.Accept;
                        msg = rm.RefusalMessage;
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

            response.Success = success;
            response.Message = msg;

            ResourceManager.ServiceResponse = response;
        }
    }
}