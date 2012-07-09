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
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class TabPanelBase : PanelBase, IItems, IAutoPostBack
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
                return "tabpanel";
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
                return "Ext.TabPanel";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override bool UseDefaultLayout
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!this.DesignMode)
            {
                this.Page.PreRender += Page_PreRender;
            }
        }

        private void Page_PreRender(object sender, EventArgs e)
        {
            if (this.MinTabWidth != Unit.Pixel(30))
            {
                this.ResizeTabs = true;
            }

            foreach (BoxComponentBase item in this.Items)
            {
                if (item.Hidden)
                {
                    if (this.LazyItems.Contains(item))
                    {
                        this.LazyItems.Remove(item);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool HasLayout()
        {
            return true;
        }

        /// <summary>
        /// The numeric index of the tab that should be initially activated on render.
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Browsable(false)]
        [Description("The numeric index of the tab that should be initially activated on render.")]
        public virtual BoxComponentBase ActiveTab
        {
            get
            {
                if (this.ActiveTabIndex > this.Items.Count - 1)
                {
                    return this.Items[this.Items.Count - 1] as BoxComponentBase;
                }

                return this.Items[this.ActiveTabIndex] as BoxComponentBase;
            }
            set
            {
                this.ActiveTabIndex = this.Items.IndexOf(value);
            }
        }

        /// <summary>
        /// The numeric index of the tab that should be initially activated on render.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetActiveTab")]
        [Category("7. TabPanel")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
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
                this.CheckTabVisible();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("activeTab")]
        [DefaultValue(-1)]
        protected internal int VisibleIndex
        {
            get
            {
                int i = this.ActiveTabIndex;
                int correction = 0;

                for (int ind = 0; ind < Math.Min(i, this.Items.Count); ind++)
                {
                    if (!this.Items[ind].Visible || this.Items[ind].Hidden)
                    {
                        correction++;
                    }
                }

                return i - correction;
            }
        }

        internal bool HasVisibleTab
        {
            get
            {
                foreach (BoxComponentBase item in this.Items)
                {
                    if (item.Visible == true)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private void CheckTabVisible()
        {
            TabPanel tp = (TabPanel)this;

            if (tp.AutoPostBack && tp.DeferredRender)
            {
                for (int i = 0; i < tp.Items.Count; i++)
                {
                    if (tp.Items[i] is IContent)
                    {
                        if (!tp.Items[i].HasLayout() || (tp.Items[i].HasLayout() && tp.ActiveTabIndex == i))
                        {
                            ((IContent)tp.Items[i]).ContentContainer.Visible = (tp.ActiveTabIndex == i);
                        }
                    }

                    foreach (Control control in tp.Items[i].Controls)
                    {
                        control.Visible = tp.ActiveTabIndex == i;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.CheckTabVisible();
        }

        /// <summary>
        /// True to animate tab scrolling so that hidden tabs slide smoothly into view (defaults to true). Only applies when EnableTabScroll = true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TabPanel")]
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
        /// The CSS selector used to search for tabs in existing markup when autoTabs = true (defaults to 'div.x-tab'). This can be any valid selector supported by Ext.DomQuery.select. Note that the query will be executed within the scope of this tab panel only (so that multiple tab panels from markup can be supported on a page).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TabPanel")]
        [DefaultValue("div.x-tab")]
        [NotifyParentProperty(true)]
        [Description("The CSS selector used to search for tabs in existing markup when autoTabs = true (defaults to 'div.x-tab'). This can be any valid selector supported by Ext.DomQuery.select. Note that the query will be executed within the scope of this tab panel only (so that multiple tab panels from markup can be supported on a page).")]
        public virtual string AutoTabSelector
        {
            get
            {
                return (string)this.ViewState["AutoTabSelector"] ?? "div.x-tab";
            }
            set
            {
                this.ViewState["AutoTabSelector"] = value;
            }
        }

        /// <summary>
        /// true to query the DOM for any divs with a class of 'x-tab' to be automatically converted to tabs and added to this panel (defaults to false). Note that the query will be executed within the scope of the container element only (so that multiple tab panels from markup can be supported via this method).
        /// </summary>
        /// <remarks>
        /// This method is only possible when the markup is structured correctly as a container with nested divs containing the class 'x-tab'. To create TabPanels without these limitations, or to pull tab content from other elements on the page, see the example at the top of the class for generating tabs from markup.
        /// There are a couple of things to note when using this method:
        /// When using the autoTabs config (as opposed to passing individual tab configs in the TabPanel's items collection), you must use applyTo to correctly use the specified id as the tab container. The autoTabs method replaces existing content with the TabPanel components.
        /// Make sure that you set deferredRender: false so that the content elements for each tab will be rendered into the TabPanel immediately upon page load, otherwise they will not be transformed until each tab is activated and will be visible outside the TabPanel.
        /// </remarks>
        [Meta]
        [ConfigOption]
        [Category("7. TabPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to animate tab scrolling so that hidden tabs slide smoothly into view (defaults to true). Only applies when EnableTabScroll = true.")]
        public virtual bool AutoTabs
        {
            get
            {
                object obj = this.ViewState["AutoTabs"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoTabs"] = value;
            }
        }

        /// <summary>
        /// The base CSS class applied to the panel (defaults to 'x-tab-panel').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TabPanel")]
        [DefaultValue("x-tab-panel")]
        [NotifyParentProperty(true)]
        [Description("The base CSS class applied to the panel (defaults to 'x-tab-panel').")]
        public override string BaseCls
        {
            get
            {
                return (string)this.ViewState["BaseCls"] ?? "x-tab-panel";
            }
            set
            {
                this.ViewState["BaseCls"] = value;
            }
        }

        /// <summary>
        /// Determining whether or not each tab is rendered only when first accessed (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TabPanel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Determining whether or not each tab is rendered only when first accessed (defaults to true).")]
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

        /// <summary>
        /// True to enable scrolling to tabs that may be invisible due to overflowing the overall TabPanel width. Only available with tabs on addToStart. (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TabPanel")]
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
        /// Set to true to do a layout of tab items as tabs are changed.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TabPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Set to true to do a layout of tab items as tabs are changed.")]
        public virtual bool LayoutOnTabChange 
        {
            get
            {
                object obj = this.ViewState["LayoutOnTabChange"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["LayoutOnTabChange"] = value;
            }
        }

        /// <summary>
        /// The minimum width in pixels for each tab when ResizeTabs = true (defaults to 30).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TabPanel")]
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
        /// True to render the tab strip without a background content Container image (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TabPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to render the tab strip without a background content Container image (defaults to false).")]
        public bool Plain
        {
            get
            {
                object obj = this.ViewState["Plain"];
                return (obj == null) ? false : (bool)obj;
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
        [Category("7. TabPanel")]
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
        /// The number of milliseconds that each scroll animation should last (defaults to .35). Only applies when AnimScroll = true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TabPanel")]
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
        [Category("7. TabPanel")]
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
        [Category("7. TabPanel")]
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
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected override void BeforeItemAdd(Component item)
        {
            base.BeforeItemAdd(item);

            if (!(item is BoxComponentBase))
            {
                throw new InvalidOperationException(string.Format("Invalid type of Control ({0}). Only Components which inherit from Ext.Net.BoxComponent can be added to this ({1}) Items Collection.", item.GetType(), this.GetType()));
            }
        }

        /// <summary>
        /// The number of pixels of space to calculate into the sizing and scrolling of tabs. If you change the margin in CSS, you will need to update this value so calculations are correct with either resizeTabs or scrolling tabs. (defaults to 2)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TabPanel")]
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
        /// The alignment of the Tabs (defaults to 'Left'). Other option includes 'Right'. Note that tab scrolling is only supported for TabAlign='Left'. Note that when 'Right', the Tabs will be rendered in reverse order.
        /// </summary>
        [Meta]
        [Category("7. TabPanel")]
        [DefaultValue(TabAlign.Left)]
        [NotifyParentProperty(true)]
        [Description("The alignment of the Tabs (defaults to 'Left'). Other option includes 'Right'. Note that tab scrolling is only supported for TabAlign='Left'. Note that when 'Right', the Tabs will be rendered in reverse order.")]
        public virtual TabAlign TabAlign
        {
            get
            {
                object obj = this.ViewState["TabAlign"];
                return (obj == null) ? TabAlign.Left : (TabAlign)obj;
            }
            set
            {
                this.ViewState["TabAlign"] = value;

                if (value == TabAlign.Right)
                {
                    this.EnableTabScroll = false;
                }
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("tabAlign", JsonMode.ToLower)]
        [DefaultValue(TabAlign.Left)]
		[Description("")]
        protected virtual TabAlign TabAlignProxy
        {
            get
            {
                if (this.TabAlign == TabAlign.Right)
                {
                    string styles = "#".ConcatWith(this.ClientID, " ul.x-tab-strip {width:100%;}#", this.ClientID, " ul.x-tab-strip li {float:right;margin:0 2px 0 0;}");
                    this.ResourceManager.RegisterClientStyleBlock(this.ClientID.ConcatWith("_TabAlign"), styles);
                }

                return this.TabAlign;
            }
        }

        /// <summary>
        /// This config option is used on child Components of ths TabPanel. A CSS class name applied to the tab strip item representing the child Component, allowing special styling to be applied.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TabPanel")]
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
        [Category("7. TabPanel")]
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
        [Category("7. TabPanel")]
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
        [Category("7. TabPanel")]
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

        private MenuCollection defaultTabMenu;

        /// <summary>
        /// Default menu for all tabs
        /// </summary>
        [Meta]
        [ConfigOption("defaultTabMenu", typeof(ItemCollectionJsonConverter))]
        [Category("7. TabPanel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Default menu for all tabs")]
        public virtual MenuCollection DefaultTabMenu
        {
            get
            {
                if (this.defaultTabMenu == null)
                {
                    this.defaultTabMenu = new MenuCollection();
                    this.defaultTabMenu.AfterItemAdd += this.AfterItemAdd;
                    this.defaultTabMenu.AfterItemRemove += this.AfterItemRemove;
                }

                return this.defaultTabMenu;
            }
        }

        
        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Sets the specified Panel as the active Tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        [Meta]
        [Description("Sets the specified Panel as the active Tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void Activate(BoxComponentBase item)
        {
            this.Activate(item.ClientID);
        }

        /// <summary>
        /// Sets the specified Panel as the active Panel. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        [Meta]
        [Description("Sets the specified Panel as the active Panel. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void Activate(string item)
        {
            this.Call("activate", item);
        }

        /// <summary>
        /// Suspends any internal calculations or scrolling while doing a bulk operation. See endUpdate
        /// </summary>
        [Meta]
        [Description("Suspends any internal calculations or scrolling while doing a bulk operation. See endUpdate")]
        public virtual void BeginUpdate()
        {
            this.Call("beginUpdate");
        }

        /// <summary>
        /// Suspends any internal calculations or scrolling while doing a bulk operation. See endUpdate
        /// </summary>
        [Meta]
        [Description("Suspends any internal calculations or scrolling while doing a bulk operation. See endUpdate")]
        public virtual void EndUpdate()
        {
            this.Call("endUpdate");
        }

        /// <summary>
        /// Hides the tab strip item for the passed tab
        /// </summary>
        [Meta]
        [Description("Hides the tab strip item for the passed tab")]
        public virtual void HideTabStripItem(int item)
        {
            this.Call("hideTabStripItem", item);
        }

        /// <summary>
        /// Hides the tab strip item for the passed tab
        /// </summary>
        [Meta]
        [Description("Hides the tab strip item for the passed tab")]
        public virtual void HideTabStripItem(BoxComponentBase item)
        {
            this.HideTabStripItem(item.ClientID);
        }

        /// <summary>
        /// Hides the tab strip item for the passed tab
        /// </summary>
        [Meta]
        [Description("Hides the tab strip item for the passed tab")]
        public virtual void HideTabStripItem(string item)
        {
            this.Call("hideTabStripItem", item);
        }

        /// <summary>
        /// True to scan the markup in this tab panel for autoTabs using the autoTabSelector
        /// </summary>
        [Meta]
        [Description("True to scan the markup in this tab panel for autoTabs using the autoTabSelector")]
        public virtual void ReadTabs(bool removeExisting)
        {
            this.Call("hideTabStripItem", removeExisting);
        }

        /// <summary>
        /// Scrolls to a particular tab if tab scrolling is enabled
        /// </summary>
        [Meta]
        [Description("Scrolls to a particular tab if tab scrolling is enabled")]
        public virtual void ScrollToTab(BoxComponentBase item, bool animate)
        {
            this.Call("scrollToTab", new JRawValue(item.ClientID), animate);
        }

        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        [Meta]
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(int index)
        {
            int correction = 0;

            for (int ind = 0; ind < Math.Min(index, this.Items.Count); ind++)
            {
                if (!this.Items[ind].Visible)
                {
                    correction++;
                }
            }

            this.Call("setActiveTab", index - correction);
        }

        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        [Meta]
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(BoxComponentBase item)
        {
            this.SetActiveTab(item.ClientID);
        }

        /// <summary>
        /// Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.
        /// </summary>
        /// <param name="id">The id.</param>
        [Meta]
        [Description("Sets the specified tab as the active tab. This method fires the beforetabchange event which can return false to cancel the tab change.")]
        public virtual void SetActiveTab(string id)
        {
            this.Call("setActiveTab", id);
        }

        /// <summary>
        /// Unhides the tab strip item for the passed tab
        /// </summary>
        [Meta]
        [Description("Unhides the tab strip item for the passed tab")]
        public virtual void UnhideTabStripItem(int index)
        {
            this.Call("unhideTabStripItem", index);
        }

        /// <summary>
        /// Unhides the tab strip item for the passed tab
        /// </summary>
        [Meta]
        [Description("Unhides the tab strip item for the passed tab")]
        public virtual void UnhideTabStripItem(BoxComponentBase item)
        {
            this.UnhideTabStripItem(item.ClientID);
        }

        /// <summary>
        /// Unhides the tab strip item for the passed tab
        /// </summary>
        [Meta]
        [Description("Unhides the tab strip item for the passed tab")]
        public virtual void UnhideTabStripItem(string id)
        {
            this.Call("unhideTabStripItem", id);
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
    }
}