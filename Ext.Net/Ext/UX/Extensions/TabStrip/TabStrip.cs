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
    /// A component which renders tabs similar to a TabPanel and can toggle visibility of other items.
    /// </summary>
    [Meta]
    [DefaultEvent("TabChanged")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(TabStrip), "Build.ToolboxIcons.TabPanel.bmp")]
    [ToolboxData("<{0}:TabStrip runat=\"server\"></{0}:TabStrip>")]
    [Description("A component which renders tabs similar to a TabPanel and can toggle visibility of other items.")]
    public partial class TabStrip : BoxComponentBase, IItems, IAutoPostBack, IPostBackEventHandler, IPostBackDataHandler, IIcon
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TabStrip() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "tabstrip";
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
                return "Ext.ux.TabStrip";
            }
        }

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

                baseList.Add(new ClientScriptItem(typeof(TabStrip), "Ext.Net.Build.Ext.Net.ux.extensions.tabstrip.tabstrip.js", "/ux/extensions/tabstrip/tabstrip.js"));

                return baseList;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.AutoPostBack)
            {
                this.CustomConfig.Add(new ConfigItem("tabPostback", JSON.Serialize(new JFunction(this.PostBackFunction)), ParameterMode.Raw));
            }
        }
        
        private TabStripItems items;

        /// <summary>
        /// Items Collection
        /// </summary>
        [Meta]
        [DeferredRender]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ConfigOption(JsonMode.AlwaysArray)]
        [Description("Items Collection")]
        public virtual TabStripItems Items
        {
            get
            {
                if (this.items == null)
                {
                    this.items = new TabStripItems();
                    this.items.Owner = this;
                    this.items.AfterItemAdd += Items_AfterItemAdd;
                }

                return this.items;
            }
        }

        private void Items_AfterItemAdd(TabStripItem item)
        {
            item.Owner = this;
        }

        /// <summary>
        /// The ID of the container which has card layout. TabStrip will switch active item automatically beased on the current index.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(ContainerBase))]
        [Description("The ID of the container which has card layout. TabStrip will switch active item automatically beased on the current index.")]
        public virtual string ActionContainerID
        {
            get
            {
                return (string)this.ViewState["ActionContainerID"] ?? "";
            }
            set
            {
                this.ViewState["ActionContainerID"] = value;
            }
        }

        private Container actionContainer;

        /// <summary>
        /// The container which has card layout. TabStrip will switch active item automatically beased on the current index.
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The container which has card layout. TabStrip will switch active item automatically beased on the current index.")]
        public virtual Container ActionContainer
        {
            get
            {
                return this.actionContainer;
            }
            set
            {
                this.actionContainer = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("actionContainer")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string ActionContainerProxy
        {
            get
            {
                if (this.ActionContainer != null)
                {
                    return this.ActionContainer.ClientID;
                }

                if (this.ActionContainerID.IsNotEmpty())
                {
                    Control ctrl = ControlUtils.FindControl(this, this.ActionContainerID, true);

                    if (ctrl == null)
                    {
                        return this.ActionContainerID;
                    }

                    return ctrl.ClientID;
                }

                return "";
            }
        }


        /// <summary>
        /// The numeric index of the tab that should be initially activated on render.
        /// </summary>
        [Meta]
        [ConfigOption("activeTab")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetActiveTab")]
        [Description("The numeric index of the tab that should be initially activated on render.")]
        public virtual int ActiveTabIndex
        {
            get
            {
                object obj = this.ViewState["ActiveTabIndex"];
                return (obj == null) ? (this.Items.Count == 0) ? -1 : 0 : (int)obj;
            }
            set
            {
                this.ViewState["ActiveTabIndex"] = value;
            }
        }

        /// <summary>
        /// True to animate tab scrolling so that hidden tabs slide smoothly into view (defaults to true). Only applies when EnableTabScroll = true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to animate tab scrolling so that hidden tabs slide smoothly into view (defaults to true). Only applies when EnableTabScroll = true.")]
        public virtual bool AnimScroll
        {
            get
            {
                object obj = this.ViewState["AnimScroll"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AnimScroll"] = value;
            }
        }

        /// <summary>
        /// True to enable scrolling to tabs that may be invisible due to overflowing the overall TabPanel width. Only available with tabs on addToStart. (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to enable scrolling to tabs that may be invisible due to overflowing the overall TabPanel width. Only available with tabs on addToStart. (defaults to false).")]
        public virtual bool EnableTabScroll
        {
            get
            {
                object obj = this.ViewState["EnableTabScroll"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["EnableTabScroll"] = value;

                if (value)
                {
                    this.TabPosition = TabPosition.Top;
                }
            }
        }

        /// <summary>
        /// The minimum width in pixels for each tab when ResizeTabs = true (defaults to 30).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(typeof(Unit), "30")]
        [NotifyParentProperty(true)]
        [Description("The minimum width in pixels for each tab when ResizeTabs = true (defaults to 30).")]
        public virtual Unit MinTabWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["MinTabWidth"], Unit.Pixel(30), "MinTabWidth");
            }
            set
            {
                this.ViewState["MinTabWidth"] = value;
            }
        }

        /// <summary>
        /// True to render the tab strip without a background content Container image (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to render the tab strip without a background content Container image (defaults to true).")]
        public bool Plain
        {
            get
            {
                object obj = this.ViewState["Plain"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Plain"] = value;
            }
        }

        /// <summary>
        /// True to automatically resize each tab so that the tabs will completely fill the tab strip (defaults to false). Setting this to true may cause specific widths that might be set per tab to be overridden in order to fit them all into view (although MinTabWidth will always be honored).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to automatically resize each tab so that the tabs will completely fill the tab strip (defaults to false). Setting this to true may cause specific widths that might be set per tab to be overridden in order to fit them all into view (although MinTabWidth will always be honored).")]
        public bool ResizeTabs
        {
            get
            {
                object obj = this.ViewState["ResizeTabs"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ResizeTabs"] = value;
            }
        }

        /// <summary>
        /// Sync size after active tab change. This property is ignored if AutoGrow=false
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Sync size after active tab change. This property is ignored if AutoGrow=false")]
        public bool SyncOnTabChange
        {
            get
            {
                object obj = this.ViewState["SyncOnTabChange"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["SyncOnTabChange"] = value;
            }
        }

        /// <summary>
        /// True to auto grow width.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to auto grow width")]
        public bool AutoGrow
        {
            get
            {
                object obj = this.ViewState["AutoGrow"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AutoGrow"] = value;
            }
        }

        /// <summary>
        /// The number of milliseconds that each scroll animation should last (defaults to .35). Only applies when AnimScroll = true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0.35f)]
        [NotifyParentProperty(true)]
        [Description("The number of milliseconds that each scroll animation should last (defaults to .35). Only applies when AnimScroll = true.")]
        public virtual float ScrollDuration
        {
            get
            {
                object obj = this.ViewState["ScrollDuration"];
                return (obj == null) ? 0.35f : (float)obj;
            }
            set
            {
                this.ViewState["ScrollDuration"] = value;
            }
        }

        /// <summary>
        /// The number of pixels to scroll each time a tab scroll button is pressed (defaults to 100, or if ResizeTabs = true, the calculated tab width). Only applies when EnableTabScroll = true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(100)]
        [NotifyParentProperty(true)]
        [Description("The number of pixels to scroll each time a tab scroll button is pressed (defaults to 100, or if ResizeTabs = true, the calculated tab width). Only applies when EnableTabScroll = true.")]
        public virtual int ScrollIncrement
        {
            get
            {
                object obj = this.ViewState["ScrollIncrement"];
                return (obj == null) ? 100 : (int)obj;
            }
            set
            {
                this.ViewState["ScrollIncrement"] = value;
            }
        }

        /// <summary>
        /// Number of milliseconds between each scroll while a tab scroll button is continuously pressed (defaults to 400).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(400)]
        [NotifyParentProperty(true)]
        [Description("Number of milliseconds between each scroll while a tab scroll button is continuously pressed (defaults to 400).")]
        public virtual int ScrollRepeatInterval
        {
            get
            {
                object obj = this.ViewState["ScrollRepeatInterval"];
                return (obj == null) ? 400 : (int)obj;
            }
            set
            {
                this.ViewState["ScrollRepeatInterval"] = value;
            }
        }

        /// <summary>
        /// The number of pixels of space to calculate into the sizing and scrolling of tabs. If you change the margin in CSS, you will need to update this value so calculations are correct with either resizeTabs or scrolling tabs. (defaults to 2)
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(typeof(Unit), "2")]
        [NotifyParentProperty(true)]
        [Description("The number of pixels of space to calculate into the sizing and scrolling of tabs. If you change the margin in CSS, you will need to update this value so calculations are correct with either resizeTabs or scrolling tabs. (defaults to 2)")]
        public virtual Unit TabMargin
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["TabMargin"], Unit.Pixel(2), "TabMargin");
            }
            set
            {
                this.ViewState["TabMargin"] = value;
            }
        }

        /// <summary>
        /// This config option is used on child Components of ths TabPanel. A CSS class name applied to the tab strip item representing the child Component, allowing special styling to be applied.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("This config option is used on child Components of ths TabPanel. A CSS class name applied to the tab strip item representing the child Component, allowing special styling to be applied.")]
        public virtual string TabCls
        {
            get
            {
                return (string)this.ViewState["TabCls"] ?? "";
            }
            set
            {
                this.ViewState["TabCls"] = value;
            }
        }

        /// <summary>
        /// The position where the tab strip should be rendered (defaults to 'addToStart'). The only other supported value is 'Bottom'. Note that tab scrolling is only supported for position 'addToStart'.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(TabPosition.Top)]
        [NotifyParentProperty(true)]
        [Description("The position where the tab strip should be rendered (defaults to 'addToStart'). The only other supported value is 'Bottom'. Note that tab scrolling is only supported for position 'addToStart'.")]
        public virtual TabPosition TabPosition
        {
            get
            {
                object obj = this.ViewState["TabPosition"];
                return (obj == null) ? TabPosition.Top : (TabPosition)obj;
            }
            set
            {
                this.ViewState["TabPosition"] = value;

                if (value == TabPosition.Bottom)
                {
                    this.EnableTabScroll = false;
                }
            }
        }

        /// <summary>
        /// The initial width in pixels of each new tab (defaults to 120).
        /// </summary>
        [Meta]
        [ConfigOption]
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

        /// <summary>
        /// For scrolling tabs, the number of pixels to increment on mouse wheel scrolling (defaults to 20).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(20)]
        [NotifyParentProperty(true)]
        [Description("For scrolling tabs, the number of pixels to increment on mouse wheel scrolling (defaults to 20).")]
        public virtual int WheelIncrement
        {
            get
            {
                object obj = this.ViewState["WheelIncrement"];
                return (obj == null) ? 20 : (int)obj;
            }
            set
            {
                this.ViewState["WheelIncrement"] = value;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public IList ItemsList
        {
            get
            {
                return this.Items;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [TypeConverter(typeof(DefaultTypeConverter))]
        [Description("")]
        public string DefaultType
        {
            get
            {
                return "BoxComponent";
            }
            set
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("defaultType")]
        [DefaultValue("box")]
        [Description("")]
        protected virtual string DefaultTypeProxy
        {
            get
            {
                return DefaultTypeConverter.GetXType(this.DefaultType);
            }
        }

        private TabStripListeners listeners;

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
        public TabStripListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new TabStripListeners();
                }

                return this.listeners;
            }
        }

        private TabStripDirectEvents directEvents;

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
        public TabStripDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new TabStripDirectEvents();
                }

                return this.directEvents;
            }
        }

        /*  IAutoPostBack
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Gets or sets a value indicating whether the control state automatically posts back to the server when tab changed.
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Gets or sets a value indicating whether the control state automatically posts back to the server when tab changed.")]
        public virtual bool AutoPostBack
        {
            get
            {
                object obj = this.ViewState["AutoPostBack"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoPostBack"] = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.")]
        public virtual bool CausesValidation
        {
            get
            {
                object obj = this.ViewState["CausesValidation"];
                return (obj != null && (bool)obj);
            }
            set
            {
                this.ViewState["CausesValidation"] = value;
            }
        }

        /// <summary>
        /// Gets or Sets the Controls ValidationGroup
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Gets or Sets the Controls ValidationGroup")]
        public virtual string ValidationGroup
        {
            get
            {
                return (string)this.ViewState["ValidationGroup"] ?? "";
            }
            set
            {
                this.ViewState["ValidationGroup"] = value;
            }
        }

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
		[Description("")]
        protected virtual void OnTabChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventTabChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string val = postCollection[this.ConfigID.ConcatWith("_ActiveTab")];

            if (val.IsNotEmpty())
            {
                int activeTabNum;
                string[] at = val.Split(':');

                if (int.TryParse(at.Length > 1 ? at[1] : at[0], out activeTabNum))
                {
                    int index = this.Items.IndexOfID(at[0]);

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
                                if (i < this.Items.Count && this.Items[i].Hidden)
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

        bool eventWasRaised;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void RaisePostDataChangedEvent()
        {
            if (!eventWasRaised)
            {
                this.OnTabChanged(EventArgs.Empty);
                eventWasRaised = false;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void RaisePostBackEvent(string eventArgument)
        {
            if (!eventWasRaised)
            {
                this.OnTabChanged(EventArgs.Empty);
                eventWasRaised = false;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public List<Icon> Icons
        {
            get 
            {
                List<Icon> icons = new List<Icon>(this.Items.Count);
                foreach (TabStripItem item in this.Items)
                {
                    icons.Add(item.Icon);
                }

                return icons;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(TabStripItem item)
        {
            this.Items.Add(item);
            this.Call("add", new JRawValue(new ClientConfig().Serialize(item)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void InsertItem(int index, TabStripItem item)
        {
            this.Items.Add(item);
            this.Call("insert", index, new JRawValue(new ClientConfig().Serialize(item)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Remove(TabStripItem item)
        {
            if (this.ItemID.IsNotEmpty())
            {
                this.Call("remove", item.ItemID);
            }
            else
            {
                this.Call("remove", this.Items.IndexOf(item));
            }

            if (this.Items.Contains(item))
            {
                this.Items.Remove(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        public void Remove(string itemId)
        {
            this.Call("remove", itemId);

            if (this.Items[itemId] != null)
            {
                this.Items.Remove(this.Items[itemId]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void SetActiveTab(TabStripItem item)
        {
            if (this.ItemID.IsNotEmpty())
            {
                this.Call("setActiveTab", item.ItemID);
            }
            else
            {
                this.Call("setActiveTab", this.Items.IndexOf(item));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void SetActiveTab(int index)
        {
            this.Call("setActiveTab", index);
        }

        /// <summary>
        /// Scrolls to a particular tab if tab scrolling is enabled
        /// </summary>
        public virtual void ScrollToTab(string itemId, bool animate)
        {
            itemId = "{0}.getComponent({1})".FormatWith(this.ClientID, JSON.Serialize(itemId));
            this.Call("scrollToTab", new JRawValue(itemId), animate);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SyncStripWidth()
        {
            this.Call("syncStripWidth");
        }
    }
}
