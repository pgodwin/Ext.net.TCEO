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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using Ext.Net.Utilities;

namespace Ext.Net
{
    [ToolboxBitmap(typeof(GroupTab), "Build.ToolboxIcons.GroupTab.bmp")]
    [ToolboxData("<{0}:GroupTab runat=\"server\" Title=\"GroupTab\" />")]
    [Description("GroupTab")]
    public partial class GroupTab : ContainerBase, IPostBackDataHandler
    {
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "grouptab";
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
                return "Ext.ux.GroupTab";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool UseDefaultLayout
        {
            get
            {
                return false;
            }
        }

        private GroupTabListeners listeners;

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
        public GroupTabListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new GroupTabListeners();
                }

                return this.listeners;
            }
        }

        private TabPanelDirectEvents directEvents;

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
        public TabPanelDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new TabPanelDirectEvents();
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// The main item.
        /// </summary>
        [ConfigOption]
        [Category("6. GroupTab")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetMainItem")]
        [Description("The main item.")]
        public virtual int MainItem
        {
            get
            {
                object obj = this.ViewState["MainItem"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["MainItem"] = value;
            }
        }

        /// <summary>
        /// Expand the group.
        /// </summary>
        [ConfigOption]
        [Category("6. GroupTab")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Expand the group.")]
        public virtual bool Expanded
        {
            get
            {
                object obj = this.ViewState["Expanded"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Expanded"] = value;
            }
        }

        /// <summary>
        /// Deferred Render
        /// </summary>
        [ConfigOption]
        [Category("6. GroupTab")]
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

        private Component activeTab;

        /// <summary>
        /// Active tab
        /// </summary>
        [Category("6. GroupTab")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetActiveTab")]
        [Description("Active tab")]
        public virtual Component ActiveTab
        {
            get
            {
                return this.activeTab;
            }
            set
            {
                this.activeTab = value;

                if (RequestManager.IsAjaxRequest && this.AllowCallbackScriptMonitoring && !this.IsDynamic)
                {
                    this.SetActiveTab(value);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("6. GroupTab")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetActiveTab")]
        public virtual int ActiveTabIndex
        {
            get
            {
                object obj = this.ViewState["ActiveTabIndex"];
                return (obj == null) ? -1 : (int)obj;
            }
            set
            {
                this.ViewState["ActiveTabIndex"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("activeTab", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected internal string ActiveTabProxy
        {
            get
            {
                if (this.ActiveTab != null)
                {
                    return JSON.Serialize(this.ActiveTab.ClientID);
                }

                if (this.ActiveTabIndex < 0)
                {
                    return "";
                }

                return this.ActiveTabIndex.ToString();
            }
        }

        /// <summary>
        /// Id Delimiter
        /// </summary>
        [ConfigOption]
        [Category("6. GroupTab")]
        [DefaultValue("__")]
        [NotifyParentProperty(true)]
        [Description("Id Delimiter")]
        public virtual string IdDelimiter
        {
            get
            {
                return (string)this.ViewState["IdDelimiter"] ?? "__";
            }
            set
            {
                this.ViewState["IdDelimiter"] = value;
            }
        }

        /// <summary>
        /// Header as Text
        /// </summary>
        [ConfigOption]
        [Category("6. GroupTab")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Header as Text")]
        public virtual bool HeaderAsText
        {
            get
            {
                object obj = this.ViewState["HeaderAsText"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HeaderAsText"] = value;
            }
        }

        /// <summary>
        /// Frame
        /// </summary>
        [ConfigOption]
        [Category("6. GroupTab")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Frame")]
        public virtual bool Frame
        {
            get
            {
                object obj = this.ViewState["Frame"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Frame"] = value;
            }
        }

        /// <summary>
        /// Hide borders
        /// </summary>
        [ConfigOption]
        [Category("6. GroupTab")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Hide borders")]
        public override bool HideBorders
        {
            get
            {
                object obj = this.ViewState["HideBorders"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["HideBorders"] = value;
            }
        }

        private static readonly object EventTabChanged = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event EventHandler TabChanged
        {
            add
            {
                this.Events.AddHandler(EventTabChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventTabChanged, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnTabChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventTabChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string val = postCollection[this.ConfigID.ConcatWith("_ActiveTab")];

            if (val.IsNotEmpty())
            {
                int activeTabNum;
                string[] at = val.Split(':');

                if (int.TryParse(at.Length > 1 ? at[1] : at[0], out activeTabNum))
                {
                    int index = this.Items.FindIndex(delegate(Component tab)
                    {
                        return tab.ClientID == at[0];
                    });

                    if (index >= 0)
                    {
                        activeTabNum = index;
                    }
                    else
                    {
                        if (this.Visible)
                        {
                            for (int i = 0; i <= activeTabNum; i++)
                            {
                                if (i < this.Items.Count && !this.Items[i].Visible)
                                {
                                    activeTabNum++;
                                }
                            }
                        }
                    }

                    if (activeTabNum > -1 && this.ActiveTabIndex != activeTabNum)
                    {
                        this.ViewState.Suspend();
                        this.ActiveTabIndex = activeTabNum;
                        this.ViewState.Resume();
                        return true;
                    }
                }
            }

            return false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void RaisePostDataChangedEvent()
        {
            this.OnTabChanged(EventArgs.Empty);
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(int index)
        {
            this.SetActiveTab(this.Items[index].ClientID);
        }

        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(Component item)
        {
            this.Call("setActiveTab", item.ClientID);
        }

        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        /// <param name="id">The id.</param>
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(string id)
        {
            Component activeTab = null;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].ID == id)
                {
                    activeTab = this.Items[i];
                    break;
                }
            }

            if (activeTab == null)
            {
                throw new InvalidOperationException("The '{0}' item does not exist with the '{1}' TabPanel.".FormatWith(id, this.ID));
            }

            this.SetActiveTab(activeTab);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        [Description("")]
        public virtual void SetMainItem(int index)
        {
            this.Call("setMainItem", index);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void SetMainItem(Component item)
        {
            this.Call("setMainItem", item.ClientID);
        }
    }
}