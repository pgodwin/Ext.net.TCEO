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
    public partial class BorderLayoutDesigner : ExtControlDesigner
    {
        private BorderLayout layout;
        private DesignerRegionCollection designerRegions;
        private bool schemeMode;

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
        public bool SchemeMode
        {
            get { return schemeMode; }
            set { schemeMode = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            this.layout = (BorderLayout)component;
            this.SchemeMode = false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string XGetDesignTimeHtml(DesignerRegionCollection regions)
        {
            StringWriter writer = new StringWriter(CultureInfo.CurrentCulture);
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
            this.designerRegions = regions;

            this.layout.Height = Unit.Percentage(100);

            foreach (BorderLayoutRegion region in this.layout.Regions)
            {
                foreach (PanelBase item in region.Items)
                {
                    this.layout.Controls.Add(item);
                }
            }

            //if (this.layout.Height.Type != UnitType.Pixel)
            //{
            //    PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.layout)["Height"];
            //    descriptor.SetValue(this.layout, Unit.Pixel((int) this.layout.Height.Value));
            //    this.layout.Height = Unit.Percentage(100);
            //    //this.layout.Height = Unit.Pixel((int) this.layout.Height.Value);
            //    Tag.SetDirty(true);
            //}

            HtmlGenericControl mainDiv = new HtmlGenericControl("div");
            mainDiv.Style["width"] = Unit.Percentage(100).ToString();
            mainDiv.Style["height"] = Unit.Percentage(100).ToString();
            mainDiv.Style["overflow"] = "hidden";

            Table table = new Table();
            table.CellPadding = 0;
            table.CellSpacing = 0;
            table.BorderWidth = 0;
            table.Width = Unit.Percentage(100);
            table.Height = Unit.Percentage(100);

            table.CssClass = "ext-ie ext-ie7 ext-border-box x-border-layout-ct";

            Unit height;
            TableRow row;
            TableCell cell;
            bool northExists = this.layout.North.Items.Count > 0;
            bool southExists = this.layout.South.Items.Count > 0;
            bool westExists = this.layout.West.Items.Count > 0;
            bool eastExists = this.layout.East.Items.Count > 0;
            string margins;
            Margins marginsObj;

            if (northExists || this.SchemeMode)
            {
                row = new TableRow();
                cell = new TableCell();
                cell.ColumnSpan = 3;
                cell.VerticalAlign = VerticalAlign.Top;
                cell.Width = Unit.Percentage(100);

                if (northExists && ((this.layout.North.Items[0] is PanelBase) && (this.layout.North.Items[0] as PanelBase).Collapsed) && this.layout.North.Collapsible && !this.SchemeMode)
                {
                    marginsObj = this.layout.North.CMargins;

                    if (marginsObj.IsDefault)
                    {
                        margins = "5px 5px 5px 5px";
                    }
                    else
                    {
                        margins = "{0}px {1}px {2}px {3}px".FormatWith(marginsObj.Top, marginsObj.Right + (this.layout.West.Split ? 5 : 0), marginsObj.Bottom, marginsObj.Left);
                    }

                    cell.Style["padding"] = margins;

                    cell.Controls.Add(this.BuildCollapsedRegion(this.layout.North));
                    row.Height = Unit.Pixel(32);
                }
                else
                {
                    if (northExists)
                    {
                        height = this.layout.North.Items[0] is BoxComponentBase ? ((BoxComponentBase)this.layout.North.Items[0]).Height : this.layout.North.Items[0].Height;
                    }
                    else
                    {
                        height = new Unit((int)(table.Height.Value * 0.3), table.Height.Type);
                    }
                    
                    if (!this.SchemeMode)
                    {
                        row.Height = height;
                        marginsObj = this.layout.North.Margins;
                        margins = "{0}px {1}px {2}px {3}px".FormatWith(marginsObj.Top, marginsObj.Right, marginsObj.Bottom + (this.layout.North.Split ? 5 : 0), marginsObj.Left);
                        cell.Style["padding"] = margins;
                    }


                    cell.Controls.Add(this.BuildRegion(this.layout.North, Unit.Percentage(100), height));
                }

                row.Cells.Add(cell);
                table.Rows.Add(row);
            }

            row = new TableRow();
            height = Unit.Percentage(100);
            row.VerticalAlign = VerticalAlign.Top;

            //Table centerTable = new Table();
            //centerTable.CellPadding = 0;
            //centerTable.CellSpacing = 0;
            //centerTable.BorderWidth = 0;
            //centerTable.Width = Unit.Percentage(100);
            //centerTable.Height = Unit.Percentage(100);

            //TableRow centerRow = new TableRow();

            int centerColSpan = (this.layout.West.Items.Count == 0 && !this.SchemeMode ? 1 : 0) +
                                (this.layout.East.Items.Count == 0 && !this.SchemeMode ? 1 : 0) + 1;

            if (westExists || this.SchemeMode)
            {
                cell = new TableCell();
                cell.Wrap = false;

                if (westExists && ((this.layout.West.Items[0] is PanelBase) && (this.layout.West.Items[0] as PanelBase).Collapsed) && this.layout.West.Collapsible && !this.SchemeMode)
                {
                    cell.Width = Unit.Pixel(25);
                    //cell.Width = Unit.Percentage(1);
                    marginsObj = this.layout.West.CMargins;

                    if (marginsObj.IsDefault)
                    {
                        margins = "0px 5px 2px 5px";
                    }
                    else
                    {
                        margins = "{0}px {1}px {2}px {3}px".FormatWith(marginsObj.Top, marginsObj.Right + (this.layout.West.Split ? 5 : 0), marginsObj.Bottom + 2, marginsObj.Left);
                    }

                    cell.Style["padding"] = margins;

                    cell.Controls.Add(this.BuildCollapsedRegion(this.layout.West));
                }
                else
                {
                    if (westExists)
                    {
                        cell.Width = this.layout.West.Items[0] is BoxComponentBase ? ((BoxComponentBase)this.layout.West.Items[0]).Width : this.layout.West.Items[0].Width;
                    }
                    else
                    {
                        cell.Width = Unit.Pixel((int)(table.Width.Value * 0.2));
                    }
                    
                    if (!this.SchemeMode)
                    {


                        marginsObj = this.layout.West.Margins;
                        int addBottomMargins = 27 + (this.layout.West.Items[0] is TabPanel ? 2 : 0);
                        margins = "{0}px {1}px {2}px {3}px".FormatWith(marginsObj.Top, marginsObj.Right + (this.layout.West.Split ? 5 : 0), marginsObj.Bottom + addBottomMargins, marginsObj.Left);
                        cell.Style["padding"] = margins;
                    }

                    cell.Controls.Add(this.BuildRegion(this.layout.West, cell.Width, height));
                }

                row.Cells.Add(cell);
            }

            cell = new TableCell();

            if (centerColSpan > 1)
            {
                cell.ColumnSpan = centerColSpan;
            }

            cell.Width = Unit.Percentage(99);

            cell.Wrap = false;

            if (!this.SchemeMode)
            {
                marginsObj = this.layout.Center.Margins;
                int addBottomMargins = 27 + (this.layout.Center.Items[0] is TabPanel ? 2 : 0);
                margins = "{0}px {1}px {2}px {3}px".FormatWith(marginsObj.Top, marginsObj.Right, marginsObj.Bottom + addBottomMargins, marginsObj.Left);
                cell.Style["padding"] = margins;
            }
            cell.Controls.Add(this.BuildRegion(this.layout.Center, Unit.Percentage(100), height));
            row.Cells.Add(cell);

            if (eastExists || this.SchemeMode)
            {
                cell = new TableCell();
                cell.Wrap = false;

                if (eastExists && ((this.layout.East.Items[0] is PanelBase) && (this.layout.East.Items[0] as PanelBase).Collapsed) && this.layout.East.Collapsible && !this.SchemeMode)
                {
                    cell.Width = Unit.Pixel(25);
                    //cell.Width = Unit.Percentage(1);
                    marginsObj = this.layout.East.CMargins;

                    if (marginsObj.IsDefault)
                    {
                        margins = "0px 5px 2px 5px";
                    }
                    else
                    {
                        margins = "{0}px {1}px {2}px {3}px".FormatWith(marginsObj.Top, marginsObj.Right + (this.layout.West.Split ? 5 : 0), marginsObj.Bottom + 2, marginsObj.Left);
                    }

                    cell.Style["padding"] = margins;

                    cell.Controls.Add(this.BuildCollapsedRegion(this.layout.East));
                }
                else
                {
                    if (eastExists)
                    {
                        cell.Width = this.layout.East.Items[0] is BoxComponentBase ? ((BoxComponentBase)this.layout.East.Items[0]).Width : this.layout.East.Items[0].Width;
                    }
                    else
                    {
                        cell.Width = Unit.Pixel((int)(table.Width.Value * 0.2));
                    }
                    
                    if (!this.SchemeMode)
                    {

                        marginsObj = this.layout.East.Margins;
                        int addBottomMargins = 27 + (this.layout.East.Items[0] is TabPanel ? 2 : 0);
                        margins = "{0}px {1}px {2}px {3}px".FormatWith(marginsObj.Top, marginsObj.Right, marginsObj.Bottom + addBottomMargins, marginsObj.Left + (this.layout.East.Split ? 5 : 0));
                        cell.Style["padding"] = margins;
                    }

                    cell.Controls.Add(this.BuildRegion(this.layout.East, cell.Width, height));
                }

                row.Cells.Add(cell);
            }
            //centerTable.Rows.Add(centerRow);

            //cell = new TableCell();
            //cell.Wrap = false;
            //cell.Controls.Add(centerTable);

            //row.Cells.Add(cell);

            table.Rows.Add(row);

            if (southExists || this.SchemeMode)
            {
                row = new TableRow();
                cell = new TableCell();
                cell.ColumnSpan = 3;
                cell.VerticalAlign = VerticalAlign.Top;
                cell.Width = Unit.Percentage(100);

                if (southExists && ((this.layout.South.Items[0] is PanelBase) && (this.layout.South.Items[0] as PanelBase).Collapsed) && this.layout.South.Collapsible && !this.SchemeMode)
                {
                    marginsObj = this.layout.South.CMargins;

                    if (marginsObj.IsDefault)
                    {
                        margins = "5px 5px 5px 5px";
                    }
                    else
                    {
                        margins = "{0}px {1}px {2}px {3}px".FormatWith(marginsObj.Top, marginsObj.Right + (this.layout.West.Split ? 5 : 0), marginsObj.Bottom, marginsObj.Left);
                    }

                    cell.Style["padding"] = margins;
                    cell.Controls.Add(this.BuildCollapsedRegion(this.layout.South));
                    row.Height = Unit.Pixel(32);
                }
                else
                {
                    if (southExists)
                    {
                        height = this.layout.South.Items[0] is BoxComponentBase ? ((BoxComponentBase)this.layout.South.Items[0]).Height : this.layout.South.Items[0].Height;
                    }
                    else
                    {
                        height = new Unit((int)(table.Height.Value * 0.3), table.Height.Type);
                    }
                    

                    if (!this.SchemeMode)
                    {
                        cell.Height = height;
                        marginsObj = this.layout.South.Margins;
                        margins = "{0}px {1}px {2}px {3}px".FormatWith(marginsObj.Top + (this.layout.South.Split ? 5 : 0), marginsObj.Right, marginsObj.Bottom, marginsObj.Left);
                        cell.Style["padding"] = margins;
                    }

                    cell.Controls.Add(this.BuildRegion(this.layout.South, Unit.Percentage(100), height));
                }

                row.Cells.Add(cell);
                table.Rows.Add(row);
            }

            mainDiv.Controls.Add(table);
            mainDiv.Controls.Add(new LiteralControl(this.GetIconStyleBlock()));

            mainDiv.RenderControl(htmlWriter);

            //this.Invalidate();

            //StringBuilder sb = new StringBuilder(256);

            //base.Render(new HtmlTextWriter(new StringWriter(sb)));
            //writer.Write(
            //    sb.ToString().Trim().Replace(Environment.NewLine, "").Replace("\n", "").Replace(
            //        "\t", "").Replace("id=\"" + this.ClientID + "\"", "id=\"" + this.ContainerID + "\""));

            return writer.ToString();
        }

        private Control BuildCollapsedRegion(BorderLayoutRegion region)
        {
            string template =
                    "<div class=\"x-layout-collapsed x-layout-collapsed-{0}\" style=\"position: static; visibility:visible;{1}\"><a {2}><div class=\"x-tool x-tool-expand-{0}\"></div></a></div>";
            string style;

            if (region.Region == RegionPosition.North || region.Region == RegionPosition.South)
            {
                style = "height:22px;width:auto;";

            }
            else
            {
                style = "height:100%;width:22px;";
            }

            LiteralControl res =
                new LiteralControl(
                    string.Format(template, region.Region.ToString().ToLower(), style,
                                  GetDesignerRegionAttribute(region.Region, BorderLayoutClickAction.Expand)));

            this.AddEmptyRegion();

            return res;
        }

        private Control BuildRegion(BorderLayoutRegion region, Unit width, Unit height)
        {
            if (!this.SchemeMode && region.Items.Count > 0)
            {
                Component item = region.Items[0];

                if (ReflectionUtils.IsTypeOf(item, typeof(PanelBase), false))
                {
                    this.AddIcon(((PanelBase)item).Icon); 
                }
                
                
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
                    return BuildStub(region, height, width, true);
                }

                designer.Width = width;

                if (region == this.layout.North || region == this.layout.South)
                {
                    designer.Height = height;
                }
                designer.Layout = LayoutType.Border;
                designer.BorderRegion = region;

                designer.CurrentDesigner = this.CurrentDesigner;
                designer.Initialize(item);

                return new LiteralControl(designer.GetDesignTimeHtml(this.designerRegions));
            }
            else
            {
                return BuildStub(region, height, width, false);
            }
        }

        private Control BuildStub(BorderLayoutRegion region, Unit height, Unit width, bool buildUnsupported)
        {
            StringBuilder sb = new StringBuilder(256);
            sb.AppendFormat(this.beginStub, region.Items.Count == 0 ? disabledColor : activeColor);

            string startRegionTemplate, emptyRegionTemplate;

            startRegionTemplate = this.startRegion;

            if (region.Region == RegionPosition.North || region.Region == RegionPosition.South)
            {
                emptyRegionTemplate = this.emptyNorthSouthRegion;
            }
            else
            {
                emptyRegionTemplate = this.emptyWestEastRegion;
            }

            sb.AppendFormat(startRegionTemplate, region.Region);

            if (!buildUnsupported)
            {
                if (region.Items.Count == 0)
                {
                    sb.AppendFormat(emptyRegionTemplate,
                                    GetDesignerRegionAttribute(region.Region, BorderLayoutClickAction.AddPanel),
                                    GetDesignerRegionAttribute(region.Region, BorderLayoutClickAction.AddTabPanel));
                }
                else
                {
                    if (region.Region != RegionPosition.Center)
                    {
                        sb.AppendFormat(this.existsRegion,
                                        GetDesignerRegionAttribute(region.Region, BorderLayoutClickAction.ClearRegion));
                    }
                    else
                    {
                        if (region.Items[0] is Panel)
                        {
                            sb.AppendFormat(this.changeToTabPanel,
                                        GetDesignerRegionAttribute(region.Region, BorderLayoutClickAction.ChangeToTabPanel));
                        }
                        else if (region.Items[0] is TabPanel)
                        {
                            sb.AppendFormat(this.changeToPanel,
                                        GetDesignerRegionAttribute(region.Region, BorderLayoutClickAction.ChangeToPanel));
                        }
                    }
                }

                if (region.Region == RegionPosition.Center && this.SchemeMode)
                {
                    sb.AppendFormat(this.turnOffScheme,
                                    GetDesignerRegionAttribute(region.Region, BorderLayoutClickAction.TurnOffScheme));
                }
            }
            else
            {
                sb.Append("Unsupported Design-Time Control");
            }

            sb.Append(this.endRegion);

            sb.Append(this.endStub);

            return new LiteralControl(sb.ToString());
        }

        private string GetDesignerRegionAttribute(RegionPosition region, BorderLayoutClickAction action)
        {
            string name = "{0}_{1}".FormatWith(region, action);
            this.designerRegions.Add(new DesignerRegion(this, name, false));

            return "{0}=\"{1}\"".FormatWith(DesignerRegion.DesignerRegionAttributeName, this.designerRegions.Count - 1);
        }

        // for prevent shifting regions
        private void AddEmptyRegion()
        {
            this.designerRegions.Add(new DesignerRegion(this.CurrentDesigner, "Empty", false));
        }

        #region StubConsts

        private readonly string beginStub =
            "<table class=\"x-border-layout-ct\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"background-color:{0};width:100%;height:100%;border:1px solid #8db2e3;\">";

        private readonly string endStub = "</table>";

        private readonly string activeColor = "transparent";
        private readonly string disabledColor = "#f0f0f0";

        private readonly string emptyNorthSouthRegion =
            @"<a href=""#"" {0}>Add&nbsp;Panel</a>
              &nbsp;&nbsp;
              <a href=""#"" {1}>Add&nbsp;TabPanel</a><br/>&nbsp;";

        private readonly string existsRegion =
            @"<a href=""#"" {0}>Remove&nbsp;region</a><br/>&nbsp;";

        private readonly string changeToPanel =
            @"<a href=""#"" {0}>Change to Panel</a><br/>&nbsp;";

        private readonly string changeToTabPanel =
            @"<a href=""#"" {0}>Change to TabPanel</a><br/>&nbsp;";

        private readonly string turnOffScheme =
            @"<br/><a href=""#"" {0}>Turn off scheme</a>";

        private readonly string endRegion = "</td></tr>";

        private readonly string startRegion =
            @"<tr>
			<td align=""center"" style=""padding:0px;height:1%;font-weight:bold;"">{0}<td>			
		</tr>
		<tr>
			<td valign=""middle"" align=""center"" style=""padding:0px 10px;"">";

        private readonly string emptyWestEastRegion =
            @"<a href=""#"" {0}>Add&nbsp;Panel</a>
              <br/><br/>
              <a href=""#"" {1}>Add&nbsp;TabPanel</a>";

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="properties"></param>
        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            base.PreFilterProperties(properties);

            properties.Add("SchemeMode",
                           TypeDescriptor.CreateProperty(typeof(BorderLayoutDesigner), "SchemeMode",
                                                         typeof(bool),
                                                         new DescriptionAttribute("Show border layout as scheme"),
                                                         DesignOnlyAttribute.Yes));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string GetEditableDesignerRegionContent(EditableDesignerRegion region)
        {
            IDesignerHost host = (IDesignerHost)this.Component.Site.GetService(typeof(IDesignerHost));

            if (host != null)
            {
                string[] parameters = region.Name.Split('_');

                if (parameters.Length == 3 && parameters[0] == "Body")
                {
                    BorderLayoutRegion layoutRegion = this.GetLayoutRegionByName(parameters[1]);

                    if (layoutRegion != null && layoutRegion.Items.Count > 0)
                    {
                        int activeIndex = int.Parse(parameters[2]);
                        IContent contentPanel = null;

                        if (layoutRegion.Items[0] is Panel)
                        {
                            contentPanel = layoutRegion.Items[0] as Panel;
                        }
                        else if (layoutRegion.Items[0] is TabPanel)
                        {
                            TabPanel tabPanel = layoutRegion.Items[0] as TabPanel;

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

            IDesignerHost host = (IDesignerHost)Component.Site.GetService(typeof(IDesignerHost));

            if (host != null)
            {
                string[] parameters = region.Name.Split('_');

                if (parameters.Length == 3 && parameters[0] == "Body")
                {
                    BorderLayoutRegion layoutRegion = GetLayoutRegionByName(parameters[1]);

                    if (layoutRegion != null && layoutRegion.Items.Count > 0)
                    {
                        IContent contentPanel = null;
                        int activeIndex = int.Parse(parameters[2]);

                        if (layoutRegion.Items[0] is Panel)
                        {
                            contentPanel = layoutRegion.Items[0] as Panel;
                        }
                        else if (layoutRegion.Items[0] is TabPanel)
                        {
                            TabPanel tabPanel = layoutRegion.Items[0] as TabPanel;

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
                        TypeDescriptor.GetProperties(contentPanel)["Body"].SetValue(
                                contentPanel, template);
                        contentPanel.Content = template;

                        this.Tag.SetDirty(true);
                    }
                }
            }
        }

        private BorderLayoutRegion GetLayoutRegionByName(string name)
        {
            switch (name)
            {
                case "North":
                    return this.layout.North;
                case "South":
                    return this.layout.South;
                case "West":
                    return this.layout.West;
                case "East":
                    return this.layout.East;
                case "Center":
                    return this.layout.Center;
                default:
                    return null;
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
                    actionLists.Add(new BorderLayoutActionList(this));
                }

                return actionLists;
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

            if (parameters.Length < 2)
            {
                return;
            }

            BorderLayoutRegion region = GetLayoutRegionByName(parameters[0]);

            if (region == null)
            {
                return;
            }

            BorderLayoutClickAction action =
                (BorderLayoutClickAction)Enum.Parse(typeof(BorderLayoutClickAction), parameters[1]);

            switch (action)
            {
                case BorderLayoutClickAction.AddPanel:
                    this.AddPanel(region);
                    break;
                case BorderLayoutClickAction.AddTabPanel:
                    this.AddTabPanel(region);
                    break;
                case BorderLayoutClickAction.ClearRegion:
                    this.ClearRegion(region.Region);
                    break;
                case BorderLayoutClickAction.TurnOffScheme:
                    TypeDescriptor.GetProperties(this.layout)["SchemeMode"].SetValue(this.layout, false);
                    //this.Refresh();
                    break;
                case BorderLayoutClickAction.ChangeTab:
                    int tabId = int.Parse(parameters[2]);

                    if (region.Items.Count == 0)
                    {
                        return;
                    }

                    TabPanel tabPanel = region.Items[0] as TabPanel;

                    if (tabPanel == null)
                    {
                        return;
                    }

                    if (tabPanel.ActiveTabIndex != tabId)
                    {
                        PropertyDescriptor activeTab = TypeDescriptor.GetProperties(tabPanel)["ActiveTabIndex"];
                        activeTab.SetValue(tabPanel, tabId);
                        tabPanel.ActiveTabIndex = tabId;
                    }

                    break;
                case BorderLayoutClickAction.ChangeToPanel:
                    this.AddPanel(region);
                    break;
                case BorderLayoutClickAction.ChangeToTabPanel:
                    this.AddTabPanel(region);
                    break;
                case BorderLayoutClickAction.Collapse:
                    CollapsePanel(region, true);
                    break;
                case BorderLayoutClickAction.Expand:
                    CollapsePanel(region, false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            this.Tag.SetDirty(true);
            this.UpdateDesignTimeHtml();
            //base.OnClick(e);
        }

        private static void CollapsePanel(BorderLayoutRegion region, bool collapse)
        {
            Component panel = region.Items[0];

            PropertyDescriptor collapsed = TypeDescriptor.GetProperties(panel)["Collapsed"];

            if (collapsed != null)
            {
                collapsed.SetValue(panel, collapse);

                if (ReflectionUtils.IsTypeOf(panel, typeof(PanelBase), false))
                {
                    ((PanelBase)panel).Collapsed = collapse;
                }
            }
        }

        private void ClearRegion(RegionPosition region)
        {
            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));

            if (host != null)
            {
                using (DesignerTransaction transaction = host.CreateTransaction("Clear region"))
                {
                    IComponentChangeService changeService =
                        (IComponentChangeService)GetService(typeof(IComponentChangeService));

                    try
                    {
                        changeService.OnComponentChanging(this.layout,
                                                          TypeDescriptor.GetProperties(this.layout)[region.ToString()]);
                        this.layout.ResetRegion(region);
                    }
                    finally
                    {
                        changeService.OnComponentChanged(this.layout,
                                                         TypeDescriptor.GetProperties(this.layout)[region.ToString()],
                                                         null, null);
                    }

                    this.UpdateDesignTimeHtml();
                    transaction.Commit();
                }

                this.Tag.SetDirty(true);
            }
        }

        internal void AddPanel(BorderLayoutRegion region)
        {
            this.AddItem(typeof(Panel), region);
        }

        internal void AddTabPanel(BorderLayoutRegion region)
        {
            this.AddItem(typeof(TabPanel), region);
        }

        internal void AddItem(Type type, BorderLayoutRegion region)
        {
            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));

            if (host != null)
            {

                PanelBase item = (PanelBase)host.CreateComponent(type);

                if (item != null)
                {
                    InitializeItem(item, region);
                    IComponentChangeService changeService =
                        (IComponentChangeService)GetService(typeof(IComponentChangeService));

                    try
                    {
                        changeService.OnComponentChanging(region, TypeDescriptor.GetProperties(region)["Items"]);
                        region.Items.Clear();
                        region.Items.Add(item);
                    }
                    finally
                    {
                        changeService.OnComponentChanged(region, TypeDescriptor.GetProperties(region)["Items"], null,
                                                         null);
                    }
                }
                this.Tag.SetDirty(true);
                this.UpdateDesignTimeHtml();
            }
        }

        private void InitializeItem(PanelBase item, BorderLayoutRegion region)
        {
            region.Split = true;
            region.Collapsible = item is Panel;
            item.Title = region.Region.ToString();
            switch (region.Region)
            {
                case RegionPosition.North:
                case RegionPosition.South:
                    item.Height = Unit.Pixel(150);
                    break;
                case RegionPosition.East:
                case RegionPosition.West:
                    item.Width = Unit.Pixel(175);
                    break;
                case RegionPosition.Center:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

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

                region.Collapsible = false;
            }
        }

        internal enum BorderLayoutClickAction
        {
            AddPanel,
            AddTabPanel,
            ClearRegion,
            TurnOffScheme,
            ChangeTab,
            ChangeToPanel,
            ChangeToTabPanel,
            Collapse,
            Expand
        }
    }
}