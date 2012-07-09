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
using System.Drawing.Design;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Plugin which allows items to be dropped onto a toolbar and be turned into new Toolbar items. To use the plugin, you just need to provide a createItem implementation that takes the drop data as an argument and returns an object that can be placed onto the toolbar.
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(ToolbarDroppable), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:ToolbarDroppable runat=\"server\" />")]
    [Description("Plugin which allows items to be dropped onto a toolbar and be turned into new Toolbar items.")]
    public partial class ToolbarDroppable : Plugin, IAjaxPostBackEventHandler
    {
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

                baseList.Add(new ClientScriptItem(typeof(ToolbarDroppable), "Ext.Net.Build.Ext.Net.ux.plugins.toolbardroppable.toolbardroppable.js", "/ux/plugins/toolbardroppable/toolbardroppable.js"));

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
                return "Ext.ux.ToolbarDroppable";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("proxyId")]
        [Description("")]
        protected override string ConfigIDProxy
        {
            get
            {
                return base.ConfigIDProxy;
            }
        }

        private JFunction createItem;

        /// <summary>
        /// Creates the new toolbar item based on drop data. This method must be implemented by the plugin instance
        /// Parameters:
        ///     data : Arbitrary data from the drop
        /// Return:
        ///     An item that can be added to a toolbar
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ToolbarDroppable")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Creates the new toolbar item based on drop data.")]
        public virtual JFunction CreateItem
        {
            get
            {
                if (this.createItem == null)
                {
                    this.createItem = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.createItem.Args = new string[] { "data" };
                    }
                }

                return this.createItem;
            }
        }

        private JFunction canDrop;

        /// <summary>
        /// Returns true if the drop is allowed on the drop target. This function can be overridden and defaults to simply return true
        /// Parameters:
        ///     data : Arbitrary data from the drop
        /// Return:
        ///     True if the drop is allowed
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ToolbarDroppable")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Returns true if the drop is allowed on the drop target.")]
        public virtual JFunction CanDrop
        {
            get
            {
                if (this.canDrop == null)
                {
                    this.canDrop = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.canDrop.Args = new string[] { "data" };
                    }
                }

                return this.canDrop;
            }
        }

        private JFunction calculateEntryIndex;

        /// <summary>
        /// Calculates the location on the toolbar to create the new sorter button based on the XY of the drag event
        /// Parameters:
        ///     e : The event object
        /// Return:
        ///     The index at which to insert the new button
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ToolbarDroppable")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Calculates the location on the toolbar to create the new sorter button based on the XY of the drag event")]
        public virtual JFunction CalculateEntryIndex
        {
            get
            {
                if (this.calculateEntryIndex == null)
                {
                    this.calculateEntryIndex = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.calculateEntryIndex.Args = new string[] { "e" };
                    }
                }

                return this.calculateEntryIndex;
            }
        }

        private BaseDirectEvent directEventConfig;

        /// <summary>
        /// 
        /// </summary>
        [Category("3. ToolbarDroppable")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [ConfigOption(JsonMode.Object)]
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
        /// Set to 'remote' if need remote item creation.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. ToolbarDroppable")]
        [DefaultValue(DataLoadMode.Local)]
        [Description("Set to 'remote' if need remote item creation.")]
        public virtual DataLoadMode Mode
        {
            get
            {
                object obj = this.ViewState["Mode"];
                return (obj == null) ? DataLoadMode.Local : (DataLoadMode)obj;
            }
            set
            {
                this.ViewState["Mode"] = value;
            }
        }

        private JFunction beforeRemoteCreate;

        /// <summary>
        /// Calls before remote request
        /// Parameters:
        ///     e : The event object
        ///         - data, 
        ///         - options,
        ///         - dragSource, 
        ///         - event
        /// Return:
        ///     False to cancel request
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ToolbarDroppable")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Calls before remote request")]
        public virtual JFunction BeforeRemoteCreate
        {
            get
            {
                if (this.beforeRemoteCreate == null)
                {
                    this.beforeRemoteCreate = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.beforeRemoteCreate.Args = new string[] { "e" };
                    }
                }

                return this.beforeRemoteCreate;
            }
        }

        private JFunction afterRemoteCreate;

        /// <summary>
        /// Calls before remote request
        /// Parameters:
        ///     e : The event object
        ///        - success
		///        - message
		///        - response
		///        - o
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. ToolbarDroppable")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Calls before remote request")]
        public virtual JFunction AfterRemoteCreate
        {
            get
            {
                if (this.afterRemoteCreate == null)
                {
                    this.afterRemoteCreate = new JFunction();

                    if (!this.DesignMode)
                    {
                        this.afterRemoteCreate.Args = new string[] { "e" };
                    }
                }

                return this.afterRemoteCreate;
            }
        }

        private static readonly object EventCreate = new object();

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void ToolbarItemCreateEventHandler(object sender, ToolbarItemCreateEventArgs e);

        internal virtual void OnItemCreate(ToolbarItemCreateEventArgs e)
        {
            ToolbarItemCreateEventHandler handler = (ToolbarItemCreateEventHandler)Events[EventCreate];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event ToolbarItemCreateEventHandler ItemCreate
        {
            add
            {
                this.Events.AddHandler(EventCreate, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventCreate, value);
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
                ToolbarItemCreateEventArgs e = new ToolbarItemCreateEventArgs(extraParams);
                this.OnItemCreate(e);
                
                success = e.Success;
                msg = e.ErrorMessage;                
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