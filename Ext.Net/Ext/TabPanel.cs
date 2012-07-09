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
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A basic tab content Container. Tab panels can be used exactly like a standard Ext.Panel for layout purposes, but also have special support for containing child Panels that get automatically converted into tabs.
    /// </summary>
    [Meta]
    [DefaultEvent("TabChanged")]
    [ToolboxData("<{0}:TabPanel runat=\"server\" Height=\"300\"><Items><{0}:Panel runat=\"server\" Title=\"Tab 1\"><Items></Items></{0}:Panel><{0}:Panel runat=\"server\" Title=\"Tab 2\"><Items></Items></{0}:Panel><{0}:Panel runat=\"server\" Title=\"Tab 3\"><Items></Items></{0}:Panel></Items></{0}:TabPanel>")]
    [ToolboxBitmap(typeof(TabPanel), "Build.ToolboxIcons.TabPanel.bmp")]
    [Designer(typeof(TabPanelDesigner))]
    [Description("A basic tab content Container. Tab panels can be used exactly like a standard Ext.Panel for layout purposes, but also have special support for containing child Panels that get automatically converted into tabs.")]
    public partial class TabPanel : TabPanelBase, IPostBackEventHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TabPanel() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.AutoPostBack)
            {
                this.CustomConfig.Add(new ConfigItem("tabPostback", JSON.Serialize(new JFunction(this.PostBackFunction)), ParameterMode.Raw));
            }
        }

        private TabPanelListeners listeners;

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
        public TabPanelListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new TabPanelListeners();
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
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        protected override void Render(HtmlTextWriter writer)
        {
            if (this.ActiveTabIndex >= this.Items.Count && this.Page != null && !this.Page.IsPostBack && !(RequestManager.IsAjaxRequest && !this.IsDynamic))
            {
                string msg = string.Format("The .ActiveTabIndex value was set to the index of an item which does not exist in the '{0}' Items Collection.{3}The .ActiveTabIndex can not be set to a value > {1}.{3}The actual .ActiveTabIndex Value attempted was {2}.{3}{3}Are you dynamically creating Components and attempting to set the .ActiveTabIndex property to the index of an item which was dynamically created? If yes, please ensure your Compoennts are recreated on each request.{3}{3}COMMON CAUSE: Setting the .ActiveTabIndex to the index of an item which was created during a previous Button Click server-side Event.",
                        this.ID,
                        (this.Items.Count - 1).ToString(),
                        this.ActiveTabIndex.ToString(),
                        Environment.NewLine);
                
                throw new IndexOutOfRangeException(msg);
            }

            base.Render(writer);
        }


        /*  IPostBackDataHandler + IPostBackEventHandler
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventTabChanged = new object();

        /// <summary>
        /// Fires when the SelectedDate property has been changed
        /// </summary>
        [Category("Action")]
        [Description("Fires when the SelectedDate property has been changed")]
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
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnTabChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventTabChanged];

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
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.baseLoadPostData = base.LoadPostData(postDataKey, postCollection);
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

                    if (index >=0)
                    {
                        activeTabNum = index;
                    }
                    else
                    {
                        if (this.Visible)
                        {
                            for (int i = 0; i <= activeTabNum; i++ )
                            {
                                if (i < this.Items.Count && (!this.Items[i].Visible || this.Items[i].Hidden))
                                {
                                    activeTabNum++;
                                }
                            }
                        }
                    }

                    if (activeTabNum > -1 && this.ActiveTabIndex != activeTabNum)
                    {
                        this.SuspendScripting();
                        this.ActiveTabIndex = activeTabNum;
                        this.ResumeScripting();
                        thisLoadPostData = true;
                        return true;
                    }
                }
            }

            return false || this.baseLoadPostData; 
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void RaisePostDataChangedEvent()
        {
            if (this.baseLoadPostData)
            {
                base.RaisePostDataChangedEvent();
            }

            if (thisLoadPostData)
            {
                if (!this.eventWasRaised)
                {
                    this.OnTabChanged(EventArgs.Empty);
                    this.eventWasRaised = false;
                }
            }
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            if (!this.eventWasRaised)
            {
                this.OnTabChanged(EventArgs.Empty);
                this.eventWasRaised = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void TabPanel_TabChanged(object sender, EventArgs e)
        {
            this.OnTabChanged(e);
            CommandEventArgs args = new CommandEventArgs("TabChanged", ((TabPanel)sender).UniqueID);
            base.RaiseBubbleEvent(this, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            if (this.AutoPostBack && this.DeferredRender)
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i] is IContent)
                    {
                        if (!this.Items[i].HasLayout() || (this.Items[i].HasLayout() && this.ActiveTabIndex == i))
                        {
                            ((IContent)this.Items[i]).ContentContainer.Visible = (this.ActiveTabIndex == i);
                        }
                    }

                    foreach (Control control in this.Items[i].Controls)
                    {
                        control.Visible = this.ActiveTabIndex == i;
                    }
                }
            }
            
            bool registerTabMenu = this.DefaultTabMenu.Count > 0;

            if (!registerTabMenu)
            {
                foreach (BoxComponentBase tab in this.Items)
                {
                    if (tab.TabMenu.Count > 0)
                    {
                        registerTabMenu = true;
                        break;
                    }
                }
            }

            if (registerTabMenu)
            {
                bool tabMenuPluginExists = false;

                foreach (Plugin plugin in this.Plugins)
                {
                    if (plugin is TabMenu)
                    {
                        tabMenuPluginExists = true;
                        break;
                    }
                }

                if (!tabMenuPluginExists)
                {
                    this.Plugins.Add(new TabMenu());
                }
            }

            base.OnPreRender(e);
        }
    }
}