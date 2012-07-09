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
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class FitLayoutDesigner : ExtControlDesigner
    {
        private FitLayout fitLayout;
        private DesignerRegionCollection designerRegions;
        private HtmlTextWriter htmlWriter;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            this.fitLayout = component as FitLayout;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool AllowResize
        {
            get { return false; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string XGetDesignTimeHtml(DesignerRegionCollection regions)
        {
            StringWriter writer = new StringWriter(CultureInfo.CurrentCulture);
            this.htmlWriter = new HtmlTextWriter(writer);

            designerRegions = regions;

            StringBuilder sb = new StringBuilder(256);

            if (this.fitLayout.Items.Count == 0)
            {
                sb.Append(begin);

                object[] prms = new object[]
                    {
                        this.GetWebResourceUrl("Ext.Net.Build.Ext.Net.icons.add.png"),
                        this.GetDesignerRegionAttribute(FitLayoutClickAction.AddPanel),
                        this.GetDesignerRegionAttribute(FitLayoutClickAction.AddTabPanel)
                    };

                sb.AppendFormat(content, prms);
                sb.Append(end);
            }
            else
            {
                PanelBase item = this.fitLayout.Items[0] as PanelBase;
                PanelBaseDesigner designer;

                if (ReflectionUtils.IsTypeOf(item, typeof(Panel), false))
                {
                    designer = new PanelDesigner();
                }
                else if (ReflectionUtils.IsTypeOf(item, typeof(TabPanel), false))
                {
                    designer = new TabPanelDesigner();
                }
                else
                {
                    return unsupported;
                }

                designer.Width = Unit.Percentage(100);

                designer.Layout = LayoutType.Fit;

                designer.CurrentDesigner = CurrentDesigner;
                designer.Initialize(item);

                int addBottomMargins = 27;// +(this.fitLayout.Items[0] is TabPanel ? 2 : 0);

                if (item.Collapsible && item.Collapsed && item is Panel)
                {
                    addBottomMargins = 0;
                }

                sb.AppendFormat("<div style='width:100%;height:auto;margins:0;padding-bottom:{0}px;'>",
                                addBottomMargins);
                sb.AppendFormat(designer.GetDesignTimeHtml(designerRegions));
                sb.Append(this.GetIconStyleBlock() + "</div>");
            }

            return sb.ToString();
        }

        #region Markup consts

        private readonly string begin =
            @"<table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""border:1px solid #99bbe8;width:100%;height:100%;background-color:#dfe8f6;""
                                    <tr><td style=""padding:5px 10px;background-color: #C8DAF4;border-bottom:1px solid #99bbe8;color:#15428b;""><b>FitLayout</b></td></tr>
                                    <tr style=""height:100%;""><td align=""center"" valign=""middle"" style=""padding: 20px 40px;"">";

        private readonly string content =
            @"<table border=""0"">
              <tr>
              <td align=""left"">
                <p style=""padding:5px;""><img src=""{0}""><a href=""#"" {1}>Add Panel</a></p>
                <p style=""padding:5px;""><img src=""{0}""><a href=""#"" {2}>Add TabPanel</a></p>
              </td>
              </tr>
              </table>";

        private readonly string end = "</td></tr></table>";

        private readonly string unsupported =
            @"<div style='width:auto;height:100%;background-color:#dfe8f6;text-align:center;margins:20px;'>Unsupported design-time control</div>";

        #endregion

        protected override void OnClick(DesignerRegionMouseEventArgs e)
        {
            string[] parameters = e.Region.Name.Split('_');
            string actionName = parameters[0];

            FitLayoutClickAction action =
                (FitLayoutClickAction) Enum.Parse(typeof (FitLayoutClickAction), actionName);

            switch (action)
            {
                case FitLayoutClickAction.AddPanel:
                    AddItem(typeof (Panel));
                    break;
                case FitLayoutClickAction.AddTabPanel:
                    AddItem(typeof (TabPanel));
                    break;
                case FitLayoutClickAction.Toggle:
                    Panel panel = this.fitLayout.Items[0] as Panel;

                    PropertyDescriptor collapsed = TypeDescriptor.GetProperties(panel)["Collapsed"];
                    bool value = (bool)collapsed.GetValue(panel);
                    collapsed.SetValue(panel, !value);
                    panel.Collapsed = !value;

                    Tag.SetDirty(true);
                    this.UpdateDesignTimeHtml();

                    break;
                case FitLayoutClickAction.ChangeTab:
                    if (parameters.Length < 2)
                    {
                        return;
                    }
                    int tabId = int.Parse(parameters[1]);

                    if (this.fitLayout.Items.Count == 0)
                    {
                        return;
                    }

                    TabPanel tabPanel = this.fitLayout.Items[0] as TabPanel;

                    if (tabPanel == null)
                    {
                        return;
                    }

                    if (tabPanel.ActiveTabIndex != tabId)
                    {
                        IComponentChangeService changeService =
                            (IComponentChangeService) GetService(typeof (IComponentChangeService));

                        try
                        {
                            changeService.OnComponentChanging(this.fitLayout,
                                                              TypeDescriptor.GetProperties(this.fitLayout)["Items"]);
                            PropertyDescriptor activeTab = TypeDescriptor.GetProperties(tabPanel)["ActiveTabIndex"];
                            activeTab.SetValue(tabPanel, tabId);
                            tabPanel.ActiveTabIndex = tabId;
                        }
                        finally
                        {
                            changeService.OnComponentChanged(this.fitLayout,
                                                             TypeDescriptor.GetProperties(this.fitLayout)["Items"], null,
                                                             null);
                        }
                        Tag.SetDirty(true);
                        this.UpdateDesignTimeHtml();
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal void AddItem(Type type)
        {
            IDesignerHost host = (IDesignerHost) GetService(typeof (IDesignerHost));

            if (host != null)
            {
                
                    PanelBase item = (PanelBase) host.CreateComponent(type);

                    if (item != null)
                    {
                        InitializeItem(item);
                        IComponentChangeService changeService =
                            (IComponentChangeService) GetService(typeof (IComponentChangeService));

                        try
                        {
                            changeService.OnComponentChanging(this.fitLayout,
                                                              TypeDescriptor.GetProperties(this.fitLayout)["Items"]);
                            this.fitLayout.Items.Clear();
                            this.fitLayout.Items.Add(item);
                        }
                        finally
                        {
                            changeService.OnComponentChanged(this.fitLayout,
                                                             TypeDescriptor.GetProperties(this.fitLayout)["Items"], null,
                                                             null);
                        }
                    }
                
                this.UpdateDesignTimeHtml();
                //this.RaiseComponentChanged(TypeDescriptor.GetProperties(this.fitLayout)["Controls"],null,null);
                this.Tag.SetDirty(true);

                //this.Refresh();
            }
        }

        internal void Clear()
        {
            IDesignerHost host = (IDesignerHost) GetService(typeof (IDesignerHost));

            if (host != null)
            {
                using (DesignerTransaction transaction = host.CreateTransaction("Clear"))
                {
                    IComponentChangeService changeService =
                        (IComponentChangeService) GetService(typeof (IComponentChangeService));

                    try
                    {
                        changeService.OnComponentChanging(this.fitLayout,
                                                          TypeDescriptor.GetProperties(this.fitLayout)["Items"]);
                        this.fitLayout.Items.Clear();
                    }
                    finally
                    {
                        changeService.OnComponentChanged(this.fitLayout,
                                                         TypeDescriptor.GetProperties(this.fitLayout)["Items"], null,
                                                         null);
                    }

                    this.UpdateDesignTimeHtml();
                    transaction.Commit();
                }

                this.Tag.SetDirty(true);
            }
        }

        private void InitializeItem(PanelBase item)
        {
            item.Title = "Title";

            if (item is TabPanel)
            {
                TabPanel tabPanel = item as TabPanel;

                Panel tab = new Panel();
                tab.Title = "Tab 1";
                tabPanel.Items.Add(tab);

                tab = new Panel();
                tab.Title = "Tab 2";
                tabPanel.Items.Add(tab);

                tab = new Panel();
                tab.Title = "Tab 3";
                tabPanel.Items.Add(tab);

                tabPanel.ActiveTabIndex = 0;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string GetEditableDesignerRegionContent(EditableDesignerRegion region)
        {
            IDesignerHost host = (IDesignerHost) this.Component.Site.GetService(typeof (IDesignerHost));

            if (host != null)
            {
                string[] parameters = region.Name.Split('_');

                if (parameters.Length == 2 && parameters[0] == "Body" && this.fitLayout.Items.Count > 0)
                {
                    int activeIndex = int.Parse(parameters[1]);

                    IContent contentPanel = null;

                    if (this.fitLayout.Items[0] is Panel)
                    {
                        contentPanel = this.fitLayout.Items[0] as Panel;
                    }
                    else if (this.fitLayout.Items[0] is TabPanel)
                    {
                        TabPanel tabPanel = this.fitLayout.Items[0] as TabPanel;

                        if (activeIndex < tabPanel.Items.Count)
                        {
                            contentPanel = tabPanel.Items[activeIndex] as IContent;
                        }
                    }

                    if (contentPanel == null)
                    {
                        return "";
                    }

                    ITemplate contentTemplate = contentPanel.Content;

                    if (contentTemplate != null)
                    {
                        return ControlPersister.PersistTemplate(contentTemplate, host);
                    }
                }
            }

            return "";
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void SetEditableDesignerRegionContent(EditableDesignerRegion region, string content)
        {
            if (content == null)
            {
                return;
            }

            IDesignerHost host = (IDesignerHost) Component.Site.GetService(typeof (IDesignerHost));

            if (host != null)
            {
                string[] parameters = region.Name.Split('_');

                if (parameters.Length == 2 && parameters[0] == "Body")
                {
                    if (this.fitLayout.Items.Count > 0)
                    {
                        IContent contentPanel = null;
                        int activeIndex = int.Parse(parameters[1]);

                        if (this.fitLayout.Items[0] is Panel)
                        {
                            contentPanel = this.fitLayout.Items[0] as Panel;
                        }
                        else if (this.fitLayout.Items[0] is TabPanel)
                        {
                            TabPanel tabPanel = this.fitLayout.Items[0] as TabPanel;

                            if (activeIndex < tabPanel.Items.Count)
                            {
                                contentPanel = tabPanel.Items[activeIndex] as IContent;
                            }
                        }

                        if (contentPanel == null)
                        {
                            return;
                        }

                        ITemplate template = ControlParser.ParseTemplate(host, content);
                        PropertyDescriptor contentProperty = TypeDescriptor.GetProperties(contentPanel)["Body"];
                        contentProperty.SetValue(contentPanel, template);
                        //contentPanel.Body = template;

                        this.Tag.SetDirty(true);
                    }
                }
            }
        }

        private string GetDesignerRegionAttribute(FitLayoutClickAction action)
        {
            designerRegions.Add(new DesignerRegion(this, action.ToString(), false));

            return "{0}=\"{1}\"".FormatWith(DesignerRegion.DesignerRegionAttributeName, designerRegions.Count - 1);
        }

        //private DesignerActionListCollection actionLists;
        //public override DesignerActionListCollection XActionLists
        //{
        //    get
        //    {
        //        if (this.fitLayout.Items.Count > 0)
        //        {
        //            actionLists = new DesignerActionListCollection();

        //            if (this.fitLayout.Items[0] is Panel)
        //            {
        //                actionLists.Add(new PanelActionList(this.fitLayout.Items[0]));
        //            }
        //            else
        //            {
        //                return base.ActionLists;
        //            }

        //            return actionLists;

        //            //else if (this.fitLayout.Items[0] is TabPanel)
        //            //{
        //            //    actionLists.Add(new TabPanelActionList(this.fitLayout.Items[0]));
        //            //}

        //        }
        //        else
        //        {
        //            return base.ActionLists;
        //        }
        //    }
        //}


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
                    actionLists.Add(new FitLayoutActionList(this));
                }

                return actionLists;
            }
        }

        private enum FitLayoutClickAction
        {
            AddPanel,
            AddTabPanel,
            ChangeTab,
            Toggle
        }
    }
}