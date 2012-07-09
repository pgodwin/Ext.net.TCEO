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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class TabPanelDesigner : PanelBaseDesigner
    {
        private TabPanel tabPanelControl;
        private DesignerRegionCollection designerRegions;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="component"></param>
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            this.SetViewFlags(ViewFlags.TemplateEditing, true);
            this.tabPanelControl = (TabPanel) component;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override string FooterClass
        {
            get
            {
                 return "x-tab-panel-footer";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override TemplateGroupCollection TemplateGroups
        {
            get
            {
                TemplateGroupCollection templateGroups = new TemplateGroupCollection();
                TemplateGroup group = new TemplateGroup("Body");
                
                int i = 0;

                foreach (PanelBase tab in this.tabPanelControl.Items)
                {
                    string tabID = tab.ID.IsEmpty() ? "No ID" : tab.ID;
                    TemplateDefinition template = new TemplateDefinition(this, "Body{0}({1})".FormatWith(i, tabID), tab, "Body", false);
                    group.AddTemplateDefinition(template);
                    i++;
                }
                
                templateGroups.Add(group);

                return templateGroups;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool AllowResize
        {
            get { return true; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string XGetDesignTimeHtml(DesignerRegionCollection regions)
        {
            if (regions == null)
            {
                base.GetDesignTimeHtml(regions);
            }

            this.designerRegions = regions;

            HtmlGenericControl tabPanel = new HtmlGenericControl("div");
            tabPanel.Attributes["class"] = "{0}{1}".FormatWith(this.tabPanelControl.BaseCls,!this.tabPanelControl.Border ? " x-tab-panel-noborder" : "");
            tabPanel.Style["width"] = this.tabPanelControl.Width == Unit.Empty ? "auto" : this.tabPanelControl.Width.ToString();

            if (this.tabPanelControl.TabPosition == TabPosition.Top && this.tabPanelControl.Items.Count>0)
            {
                tabPanel.Controls.Add(BuildTabs(TabPosition.Top));
            }

            tabPanel.Controls.Add(this.BuildBody());
            
            StringWriter sr = new StringWriter(CultureInfo.CurrentCulture);
            HtmlTextWriter hw = new HtmlTextWriter(sr);
            tabPanel.RenderControl(hw);

            return sr.ToString();
        }

        private HtmlGenericControl BuildBody()
        {
            HtmlGenericControl tabPanelBwrap = new HtmlGenericControl("div");
            tabPanelBwrap.Attributes["class"] = "x-tab-panel-bwrap";

            tabPanelBwrap.Controls.Add(new LiteralControl(this.GetIconStyleBlock()));

            HtmlGenericControl panelBody = new HtmlGenericControl("div");

            if (this.tabPanelControl.TabPosition == TabPosition.Top)
            {
                panelBody.Attributes["class"] = "x-tab-panel-body {0} x-tab-panel-body-addToStart".FormatWith(this.tabPanelControl.Border ? "" : "x-tab-panel-body-noborder");
            }
            else
            {
                panelBody.Attributes["class"] = "x-tab-panel-body {0} x-tab-panel-body-noheader x-tab-panel-body-bottom".FormatWith(this.tabPanelControl.Border ? "" : "x-tab-panel-body-noborder");
            }

            string panelBodyWidth;

            if (this.tabPanelControl.Width != Unit.Empty)
            {
                double bodyWidth = this.tabPanelControl.Width.Value - (this.tabPanelControl.Border ? 2 : 0);
                panelBodyWidth = "width:{0}px;".FormatWith(bodyWidth);
            }
            else
            {
                panelBodyWidth = "width:auto;";
            }

            int footerHeight = (this.tabPanelControl.Footer || this.tabPanelControl.Buttons.Count > 0) ? 39 : 0;

            string panelBodyHeight = "";

            if (this.tabPanelControl.Height != Unit.Empty)
            {
                panelBodyHeight = string.Format("height:{0}px;",this.tabPanelControl.Height.Value - 28-footerHeight);
            }

            panelBody.Attributes["style"] =
                "{0}{1}{2}".FormatWith(panelBodyWidth, panelBodyHeight, this.tabPanelControl.BodyStyle);

            HtmlGenericControl panelNoBorder = new HtmlGenericControl("div");
            panelNoBorder.Attributes["class"] = "x-panel x-panel-noborder";
            panelNoBorder.Style["width"] = panelBody.Style["width"];

            HtmlGenericControl panelBwrap = new HtmlGenericControl("div");
            panelBwrap.Attributes["class"] = "x-panel-bwrap";

            HtmlGenericControl contentPanel = new HtmlGenericControl("div");
            contentPanel.Attributes["class"] = "x-panel-body x-panel-body-noheader x-panel-body-noborder";

            int activeTab = this.tabPanelControl.ActiveTabIndex;

            if (activeTab == -1)
            {
                activeTab = 0;
            }

            if (this.tabPanelControl.Items.Count > activeTab && activeTab >= 0)
            {
                contentPanel.Attributes["style"] = (this.tabPanelControl.Items[activeTab] as PanelBase).BodyStyle;
            }

            contentPanel.Style["overflow"] = "hidden";

            if (this.tabPanelControl.Width != Unit.Empty)
            {
                contentPanel.Style["width"] = (this.tabPanelControl.Width.Value - (this.tabPanelControl.Border ? 2 : 0)).ToString() + "px";                
            }
            else
            {
                contentPanel.Style["width"] = "auto";
            }

            if (this.tabPanelControl.Height != Unit.Empty)
            {
                contentPanel.Style["height"] = (this.tabPanelControl.Height.Value - 28 - footerHeight).ToString() + "px"; ;
            }
            else
            {
                contentPanel.Style["height"] = "100%";
            }

            if (this.tabPanelControl.Items.Count > 0)
            {
                if (this.tabPanelControl.ActiveTabIndex > -1)
                {
                    designerRegions.Add(new EditableDesignerRegion(CurrentDesigner, GetContentRegionName(this.tabPanelControl.ActiveTabIndex), false));
                    contentPanel.Attributes[DesignerRegion.DesignerRegionAttributeName] = (designerRegions.Count - 1).ToString();
                }
            }
            else
            {
                contentPanel.Style["text-align"] = "center";
                contentPanel.Style["vertical-align"] = "center";

                HtmlAnchor anchor = new HtmlAnchor();
                anchor.InnerText = "Add Tab";
                designerRegions.Add(new DesignerRegion(CurrentDesigner, TabPanelClickAction.AddTab.ToString(), false));
                anchor.Attributes[DesignerRegion.DesignerRegionAttributeName] = (designerRegions.Count - 1).ToString();
                contentPanel.Controls.Add(anchor);
            }

            
            panelBwrap.Controls.Add(contentPanel);
            panelNoBorder.Controls.Add(panelBwrap);
            panelBody.Controls.Add(panelNoBorder);
            tabPanelBwrap.Controls.Add(panelBody);

            if (this.tabPanelControl.Footer || this.tabPanelControl.Buttons.Count>0)
            {
                LiteralControl literal = new LiteralControl(BuildFooter);
                tabPanelBwrap.Controls.Add(literal);
            }

            if (this.tabPanelControl.TabPosition == TabPosition.Bottom)
            {
                tabPanelBwrap.Controls.Add(BuildTabs(TabPosition.Bottom));
            }

            return tabPanelBwrap;
        }

        private HtmlGenericControl BuildTabs(TabPosition position)
        {
            HtmlGenericControl header = new HtmlGenericControl("div");
            StringBuilder headerClass;

            if (position == TabPosition.Top)
            {
                headerClass = new StringBuilder("x-tab-panel-header");
            }
            else
            {
                headerClass = new StringBuilder("x-tab-panel-footer"); 
            }

            if (!this.tabPanelControl.Border)
            {
                if (position == TabPosition.Top)
                {
                    headerClass.Append(" x-tab-panel-header-noborder");
                }
                else
                {
                    headerClass.Append(" x-tab-panel-footer-noborder");
                }
            }

            if (this.tabPanelControl.Plain && position == TabPosition.Top)
            {
                headerClass.Append(" x-tab-panel-header-plain");
            }

            if (this.tabPanelControl.EnableTabScroll && position == TabPosition.Top)
            {
                headerClass.Append(" x-tab-scrolling");
            }

            header.Attributes["class"] = headerClass.ToString();
            
            double headerWidth = 0;

            if (this.tabPanelControl.Width != Unit.Empty)
            {
                headerWidth = this.tabPanelControl.Width.Value - (this.tabPanelControl.Border ? 2 : 0);
                header.Style["width"] = "{0}px".FormatWith(headerWidth.ToString());
            }
            else
            {
                header.Style["width"] = "auto";
            }

            //header.Style["MozUserSelect"] = "none";
            //header.Style["KhtmlUserSelect"] = "none";

            if (this.tabPanelControl.EnableTabScroll && position == TabPosition.Top)
            {
                HtmlGenericControl scrollRight = new HtmlGenericControl("div");
                scrollRight.Attributes["class"] = "x-tab-scroller-right x-unselectable";
                //scrollRight.Style["MozUserSelect"] = "none";
                //scrollRight.Style["KhtmlUserSelect"] = "none";
                int h = 22 - (this.tabPanelControl.Plain ? 1 : 0);

                //foreach (Tab tab in tabPanelControl.Items)
                //{
                //    if (tab.Closable)
                //    {
                //        if (ActiveTabIndexIsValid && this.tabPanelControl.Items[this.tabPanelControl.ActiveTabIndex].Closable)
                //        {
                //            h--;
                //        }
                //        break;
                //    }
                //}

                scrollRight.Style["height"] = h+"px";
                header.Controls.Add(scrollRight);

                HtmlGenericControl scrollLeft = new HtmlGenericControl("div");
                scrollLeft.Attributes["class"] = "x-tab-scroller-left x-unselectable";
                //scrollLeft.Style["MozUserSelect"] = "none";
                //scrollLeft.Style["KhtmlUserSelect"] = "none";
                scrollLeft.Style["height"] = h + "px";
                header.Controls.Add(scrollLeft);
            }

            HtmlGenericControl stripWrap = new HtmlGenericControl("div");
            stripWrap.Attributes["class"] = "x-tab-strip-wrap";
            stripWrap.Style["width"] = "auto";

            if (this.tabPanelControl.EnableTabScroll && position == TabPosition.Top)
            {
                if (this.tabPanelControl.Width != Unit.Empty)
                {
                    stripWrap.Style["width"] = "{0}px".FormatWith((headerWidth - 36).ToString());
                }
            }

            HtmlGenericControl ul = new HtmlGenericControl("ul");
            
            if (position == TabPosition.Top)
            {
                ul.Attributes["class"] = "x-tab-strip x-tab-strip-top";
            }
            else
            {
                ul.Attributes["class"] = "x-tab-strip x-tab-strip-bottom";
            }
                
            //ul.Style["width"] = "100%";
            ul.Style["width"] = "auto! important";
            ul.Style["height"] = "21px";

            int activeIndex = tabPanelControl.ActiveTabIndex;

            for (int i = 0; i < tabPanelControl.Items.Count; i++)
            {
                PanelBase tabControl = this.tabPanelControl.Items[i] as PanelBase;

                this.AddIcon(tabControl.Icon);

                bool IsActive = i == activeIndex;
                HtmlGenericControl tab = new HtmlGenericControl("li");

                //tab.Style["height"] = "100%";

                StringBuilder tabClass = new StringBuilder();

                if (tabControl.Closable)
                {
                    tabClass.Append("x-tab-strip-closable");
                }

                if (tabControl.Disabled)
                {
                    tabClass.Append(" x-item-disabled");
                }

                if (tabControl.IconClsProxy.IsNotEmpty())
                {
                    tabClass.Append(" x-tab-with-icon");
                }

                if (IsActive)
                {
                    tabClass.Append(" x-tab-strip-active");
                }

                tab.Attributes["class"] = tabClass.ToString();

                HtmlAnchor tabRight = new HtmlAnchor();
                tabRight.Attributes["class"] = "x-tab-right";

                designerRegions.Add(new DesignerRegion(CurrentDesigner, this.BuildChangeTabSignature(i), false));
                tabRight.Attributes[DesignerRegion.DesignerRegionAttributeName] = (designerRegions.Count - 1).ToString();
                
                HtmlGenericControl tabLeft= new HtmlGenericControl("em");
                tabLeft.Attributes["class"] = "x-tab-left";

                HtmlGenericControl stripInner = new HtmlGenericControl("span");
                stripInner.Attributes["class"] = "x-tab-strip-inner";

                HtmlGenericControl stripText = new HtmlGenericControl("span");

                if (tabControl.IconClsProxy.IsNotEmpty())
                {
                    stripText.Attributes["class"] = "x-tab-strip-text {0}".FormatWith(tabControl.IconClsProxy); 
                }
                else
                {
                    stripText.Attributes["class"] = "x-tab-strip-text"; 
                }

                stripText.InnerHtml = tabControl.Title.IsEmpty() ? "&nbsp;" : tabControl.Title;

                if (tabControl.Closable)
                {
                    HtmlGenericControl stripClose = new HtmlGenericControl("a");
                    stripClose.Attributes["class"] = "x-tab-strip-close";
                    stripClose.Style["position"] = "none";
                    //tab.Controls.Add(stripClose);
                    stripText.Controls.Add(stripClose);
                }
                
                stripInner.Controls.Add(stripText);
                tabLeft.Controls.Add(stripInner);
                tabRight.Controls.Add(tabLeft);
                tab.Controls.Add(tabRight);
                ul.Controls.Add(tab);
            }
            
           
            HtmlGenericControl edge = new HtmlGenericControl("li");
            edge.Attributes["class"] = "x-tab-edge";
            ul.Controls.Add(edge);

            HtmlGenericControl clear = new HtmlGenericControl("div");
            clear.Attributes["class"] = "x-clear";
            ul.Controls.Add(clear);
            
            stripWrap.Controls.Add(ul);
            header.Controls.Add(stripWrap);

            HtmlGenericControl stripSpacer = new HtmlGenericControl("div");
            stripSpacer.Attributes["class"] = "x-tab-strip-spacer";
            header.Controls.Add(stripSpacer);

            return header;
        }

        private string BuildChangeTabSignature(int i)
        {
            if (Layout.HasValue)
            {
                switch (Layout.Value)
                {
                    case LayoutType.Accordion:
                        break;
                    case LayoutType.Anchor:
                        break;
                    case LayoutType.Border:
                        return "{0}_{1}_{2}".FormatWith(BorderRegion.Region, TabPanelClickAction.ChangeTab, i);
                    case LayoutType.Card:
                        break;
                    case LayoutType.Column:
                        break;
                    case LayoutType.Container:
                        break;
                    case LayoutType.Fit:
                        return "{0}_{1}".FormatWith(TabPanelClickAction.ChangeTab, i);
                    case LayoutType.Form:
                        break;
                    case LayoutType.Table:
                        break;
                }
            }

            return "{0}_{1}".FormatWith(TabPanelClickAction.ChangeTab, i);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string GetEditableDesignerRegionContent(EditableDesignerRegion region)
        {
            IDesignerHost host = (IDesignerHost)Component.Site.GetService(typeof(IDesignerHost));

            if (host != null && region != null)
            {
                string[] parameters = region.Name.Split('_');

                if (parameters.Length == 2 && parameters[0] == "Body")
                {
                    int activeIndex = int.Parse(parameters[1]);

                    if (activeIndex >= 0)
                    {
                        PanelBase tab = this.tabPanelControl.Items[activeIndex] as PanelBase;

                        if (tab != null && tab is IContent)
                        {
                            ITemplate contentTemplate = ((IContent)tab).Content;

                            if (contentTemplate != null)
                            {
                                return ControlPersister.PersistTemplate(contentTemplate, host);
                            }
                        }
                    }
                }
            }

            return String.Empty;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void SetEditableDesignerRegionContent(EditableDesignerRegion region, string content)
        {
            if (content == null)
                return;
            IDesignerHost host = (IDesignerHost)Component.Site.GetService(typeof(IDesignerHost));

            if (host != null)
            {

                string[] parameters = region.Name.Split('_');

                if (parameters.Length == 2 && parameters[0] == "Body")
                {
                    int index = int.Parse(parameters[1]);

                    if (this.tabPanelControl != null && this.tabPanelControl.Items.Count > 0)
                    {
                        PanelBase tab = this.tabPanelControl.Items[index] as PanelBase;

                        if (tab != null && tab is IContent)
                        {
                            ITemplate template = ControlParser.ParseTemplate(host, content);

                            ((IContent)tab).Content = template;
                        }

                        this.Tag.SetDirty(true);
                    }
                }
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnClick(DesignerRegionMouseEventArgs e)
        {
            if (e.Region == null)
            {
                return;
            }

            string[] parameters = e.Region.Name.Split('_');

            TabPanelClickAction action = (TabPanelClickAction)Enum.Parse(typeof(TabPanelClickAction), parameters[0]);
            
            switch (action)
            {
                case TabPanelClickAction.ChangeTab:
                    
                    int tabId = int.Parse(parameters[1]);

                    if (this.tabPanelControl.ActiveTabIndex != tabId)
                    {
                        PropertyDescriptor activeTab = TypeDescriptor.GetProperties(this.tabPanelControl)["ActiveTabIndex"];
                        activeTab.SetValue(this.tabPanelControl, tabId);
                        this.tabPanelControl.ActiveTabIndex = tabId;
                    }

                    break;
                case TabPanelClickAction.AddTab:
                    AddTabAtEnd();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            this.Tag.SetDirty(true);
            this.UpdateDesignTimeHtml();
            base.OnClick(e);
        }

        internal void AddTabAtBegin()
        {
            AddTab(InsertMode.Begin);
        }

        internal void AddTabAtEnd()
        {
            AddTab(InsertMode.End);
        }

        internal void AddTabAfterActive()
        {
            AddTab(InsertMode.AfterActive);
        }

        internal bool ActiveTabIndexIsValid
        {
            get
            {
                return
                    this.tabPanelControl.ActiveTabIndex > -1 &&
                    this.tabPanelControl.ActiveTabIndex < this.tabPanelControl.Items.Count;
            }
        }

        internal void RemoveActiveTab()
        {
            if (ActiveTabIndexIsValid)
            {
                int oldIndex = this.tabPanelControl.ActiveTabIndex;

                IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));

                if (host != null)
                {
                    using (DesignerTransaction dt = host.CreateTransaction("Remove Active Tab"))
                    {
                        IComponentChangeService changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
                        PanelBase activeTab = this.tabPanelControl.Items[this.tabPanelControl.ActiveTabIndex] as PanelBase;
                       
                        try
                        {
                            changeService.OnComponentChanging(this.tabPanelControl, TypeDescriptor.GetProperties(this.tabPanelControl)["Tabs"]);
                            this.tabPanelControl.Items.Remove(activeTab);
                        }
                        finally
                        {
                            changeService.OnComponentChanged(this.tabPanelControl, TypeDescriptor.GetProperties(this.tabPanelControl)["Tabs"], null, null);
                        }

                        activeTab.Dispose();

                        if (this.tabPanelControl.Items.Count > 0)
                        {
                            PropertyDescriptor activeTabIndex = TypeDescriptor.GetProperties(this.tabPanelControl)["ActiveTabIndex"];
                            activeTabIndex.SetValue(this.tabPanelControl, Math.Min(oldIndex, this.tabPanelControl.Items.Count - 1));
                            this.tabPanelControl.ActiveTabIndex = Math.Min(oldIndex, this.tabPanelControl.Items.Count - 1);
                        }

                        UpdateDesignTimeHtml();
                        dt.Commit();
                    }
                    this.Tag.SetDirty(true);
                }
            }
        }

        private void AddTab(InsertMode mode)
        {
            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));
            
            if (host != null)
            {
                PanelBase tab = (PanelBase)host.CreateComponent(typeof(PanelBase));

                if (tab != null)
                    {
                        //this.tabPanelControl.EnsureTabs();

                        IComponentChangeService changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));

                        try
                        {
                            changeService.OnComponentChanging(this.tabPanelControl, TypeDescriptor.GetProperties(this.tabPanelControl)["Tabs"]);
                            
                            switch(mode)
                            {
                                case InsertMode.Begin:
                                    this.tabPanelControl.Items.Insert(0,tab);
                                    break;
                                case InsertMode.End:
                                    this.tabPanelControl.Items.Add(tab);
                                    break;
                                case InsertMode.AfterActive:
                                    if (ActiveTabIndexIsValid)
                                    {
                                        this.tabPanelControl.Items.Insert(this.tabPanelControl.ActiveTabIndex+1, tab);
                                    }
                                    else
                                    {
                                        this.tabPanelControl.Items.Add(tab);
                                    }
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException("mode");
                            }
                        }
                        finally
                        {
                            changeService.OnComponentChanged(this.tabPanelControl, TypeDescriptor.GetProperties(this.tabPanelControl)["Tabs"], null, null);
                        }
                        PropertyDescriptor activeTab = TypeDescriptor.GetProperties(this.tabPanelControl)["ActiveTabIndex"];

                        int newActiveTab;

                        switch(mode)
                        {
                            case InsertMode.Begin:
                                newActiveTab = 0;
                                break;
                            case InsertMode.End:
                                newActiveTab = this.tabPanelControl.Items.Count - 1;
                                break;
                            case InsertMode.AfterActive:
                                if (ActiveTabIndexIsValid)
                                {
                                    newActiveTab = this.tabPanelControl.ActiveTabIndex + 1;
                                }
                                else
                                {
                                    newActiveTab = this.tabPanelControl.Items.Count - 1;
                                }
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("mode");
                        }

                        activeTab.SetValue(this.tabPanelControl, newActiveTab);
                        this.tabPanelControl.ActiveTabIndex = newActiveTab;
                    }

                    this.UpdateDesignTimeHtml();
                
                this.Tag.SetDirty(true);
            }
        }

        private DesignerActionListCollection actionLists;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override DesignerActionListCollection XActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new TabPanelActionList(this));
                }

                return actionLists;
            }
        }

        enum InsertMode
        {
            Begin,
            End,
            AfterActive
        }

        enum TabPanelClickAction
        {
            ChangeTab,
            AddTab
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected string GetContentRegionName(int tabIndex)
        {
            if (Layout.HasValue)
            {
                switch (Layout.Value)
                {
                    case LayoutType.Accordion:
                        break;
                    case LayoutType.Anchor:
                        break;
                    case LayoutType.Border:
                        return "Body_{0}_{1}".FormatWith(BorderRegion.Region, tabIndex);
                    case LayoutType.Card:
                        break;
                    case LayoutType.Column:
                        break;
                    case LayoutType.Container:
                        break;
                    case LayoutType.Fit:
                        return "Body_{0}".FormatWith(tabIndex);
                    case LayoutType.Form:
                        break;
                    case LayoutType.Table:
                        break;
                }
            }

            return "Body_{0}".FormatWith(tabIndex);
        }
    }
}