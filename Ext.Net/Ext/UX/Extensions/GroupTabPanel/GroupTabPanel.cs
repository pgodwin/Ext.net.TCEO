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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(GroupTabPanel), "Build.ToolboxIcons.GroupTabPanel.bmp")]
    [ToolboxData("<{0}:GroupTabPanel runat=\"server\" Title=\"GroupTabPanel\"><Items></Items></{0}:GroupTabPanel>")]
    [Description("")]
    public partial class GroupTabPanel : PanelBase, IItems, IPostBackEventHandler
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
                baseList.Capacity += 3;

                baseList.Add(new ClientStyleItem(typeof(GroupTabPanel), "Ext.Net.Build.Ext.Net.ux.extensions.grouptabpanel.css.GroupTab-embedded.css", "/ux/extensions/grouptabpanel/css/GroupTab.css"));
                baseList.Add(new ClientScriptItem(typeof(GroupTabPanel), "Ext.Net.Build.Ext.Net.ux.extensions.grouptabpanel.GroupTab.js", "/ux/extensions/grouptabpanel/GroupTab.js"));
                baseList.Add(new ClientScriptItem(typeof(GroupTabPanel), "Ext.Net.Build.Ext.Net.ux.extensions.grouptabpanel.GroupTabPanel.js", "/ux/extensions/grouptabpanel/GroupTabPanel.js"));

                return baseList;
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "grouptabpanel";
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
                return "Ext.ux.GroupTabPanel";
            }
        }

        /// <summary>
        /// Deferred Render
        /// </summary>
        [ConfigOption]
        [Category("7. GroupTabPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Deferred Render")]
        public virtual bool DeferredRender
        {
            get
            {
                object obj = this.ViewState["DeferredRender"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["DeferredRender"] = value;
            }
        }

        private GroupTab activeGroup;

        /// <summary>
        /// Active group
        /// </summary>
        [Category("7. GroupTabPanel")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetActiveGroup")]
        [Description("Active group")]
        public virtual GroupTab ActiveGroup
        {
            get
            {
                return this.activeGroup;
            }
            set
            {
                this.activeGroup = value;
                if (RequestManager.IsAjaxRequest && this.AllowCallbackScriptMonitoring && !this.IsDynamic)
                {
                    this.SetActiveGroup(value);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("7. GroupTabPanel")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetActiveGroup")]
        public virtual int ActiveGroupIndex
        {
            get
            {
                object obj = this.ViewState["ActiveGroupIndex"];
                return (obj == null) ? (this.Groups.Count == 0) ? -1 : 0 : (int)obj;
            }
            set
            {
                this.ViewState["ActiveGroupIndex"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("activeGroup", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected internal string ActiveGroupProxy
        {
            get
            {
                if (this.ActiveGroup != null)
                {
                    return JSON.Serialize(this.ActiveGroup.ClientID);
                }

                if (this.ActiveGroupIndex < 0)
                {
                    return "";
                }

                return this.ActiveGroupIndex.ToString();
            }
        }

        private ItemsCollection<GroupTab> groups;

        /// <summary>
        /// Tabs Collection
        /// </summary>
        [ConfigOption("items", typeof(ItemCollectionJsonConverter))]
        [Category("7. GroupTabPanel")]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Groups Collection")]
        public virtual ItemsCollection<GroupTab> Groups
        {
            get
            {
                if (this.groups == null)
                {
                    this.groups = new ItemsCollection<GroupTab>();
                    this.groups.AfterItemAdd += this.AfterItemAdd;
                    this.groups.AfterItemRemove += this.AfterItemRemove;
                }

                return this.groups;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("7. GroupTabPanel")]
        [DefaultValue(TabAlign.Left)]
        [NotifyParentProperty(true)]
        public virtual TabAlign TabPosition
        {
            get
            {
                object obj = this.ViewState["TabPosition"];
                return (obj == null) ? TabAlign.Left : (TabAlign)obj;
            }
            set
            {
                this.ViewState["TabPosition"] = value;
            }
        }

        /// <summary>
        /// The initial width in pixels of each new tab (defaults to 120).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. GroupTabPanel")]
        [DefaultValue(typeof(Unit), "120")]
        [NotifyParentProperty(true)]
        [Description("The initial width in pixels of each new tab (defaults to 120).")]
        public virtual Unit TabWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["TabWidth"], Unit.Pixel(120), "TabWidth");
            }
            set
            {
                this.ViewState["TabWidth"] = value;
            }
        }

        IList IItems.ItemsList
        {
            get
            {
                return this.Groups;
            }
        }

        private GroupTabPanelListeners listeners;

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
        public GroupTabPanelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new GroupTabPanelListeners();
                }

                return this.listeners;
            }
        }

        private GroupTabPanelDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [ConfigOption("directEvents", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public GroupTabPanelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new GroupTabPanelDirectEvents();
                }

                return this.directEvents;
            }
        }

        private static readonly object EventGroupChanged = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event EventHandler GroupChanged
        {
            add
            {
                this.Events.AddHandler(EventGroupChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventGroupChanged, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnGroupChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventGroupChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private bool baseLoadPostData;
        private bool thisLoadPostData;
        private bool eventWasRaised;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            baseLoadPostData = base.LoadPostData(postDataKey, postCollection);
            string val = postCollection[this.ConfigID.ConcatWith("_ActiveTab")];

            if (val.IsNotEmpty())
            {
                int activeGroupNum;
                string[] at = val.Split(':');

                if (int.TryParse(at.Length > 1 ? at[1] : at[0], out activeGroupNum))
                {
                    int index = this.Groups.FindIndex(delegate(GroupTab tab)
                    {
                        return tab.ClientID == at[0];
                    });

                    if (index >= 0)
                    {
                        activeGroupNum = index;
                    }
                    else
                    {
                        if (this.Visible)
                        {
                            for (int i = 0; i <= activeGroupNum; i++)
                            {
                                if (i < this.Groups.Count && !this.Groups[i].Visible)
                                {
                                    activeGroupNum++;
                                }
                            }
                        }
                    }

                    if (activeGroupNum > -1 && this.ActiveGroupIndex != activeGroupNum)
                    {
                        this.ViewState.Suspend();
                        this.ActiveGroupIndex = activeGroupNum;
                        this.ViewState.Resume();
                        thisLoadPostData = true;
                        return true;
                    }
                }
            }

            return false || baseLoadPostData;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void RaisePostDataChangedEvent()
        {
            if (baseLoadPostData)
            {
                base.RaisePostDataChangedEvent();
            }

            if (thisLoadPostData)
            {
                if (!eventWasRaised)
                {
                    this.OnGroupChanged(EventArgs.Empty);
                    eventWasRaised = false;
                }
            }
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            if (!eventWasRaised)
            {
                this.OnGroupChanged(EventArgs.Empty);
                eventWasRaised = false;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void SetActiveGroup(int index)
        {
            this.SetActiveGroup(this.Groups[index].ClientID);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void SetActiveGroup(GroupTab group)
        {
            this.Call("setActiveGroup", group.ClientID);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void SetActiveGroup(string id)
        {
            GroupTab activeGroup = null;
            for (int i = 0; i < this.Groups.Count; i++)
            {
                if (this.Groups[i].ID == id)
                {
                    activeGroup = this.Groups[i];
                    break;
                }
            }

            if (activeGroup == null)
            {
                throw new InvalidOperationException("The '{0}' item does not exist with the '{1}' TabPanel.".FormatWith(id, this.ID));
            }

            this.SetActiveGroup(activeGroup);
        }

    }
}