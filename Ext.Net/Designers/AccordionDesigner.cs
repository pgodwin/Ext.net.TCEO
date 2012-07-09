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
using System.Text;
using System.Web.UI;
using System.Web.UI.Design;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class AccordionDesigner : ExtControlDesigner
    {
        private AccordionLayout layout;
        private DesignerRegionCollection designerRegions;

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
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);

            if (!this.Disabled)
            {
                this.SetViewFlags(ViewFlags.TemplateEditing, true);
            }
            this.layout = (AccordionLayout)component;
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

                foreach (Component item in this.layout.Items)
                {
                    string itemID = item.ID.IsEmpty() ? "No ID" : item.ID;
                    TemplateDefinition template = new TemplateDefinition(this, "Body{0}({1})".FormatWith(i, itemID), item, "Body", false);
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
        public override string XGetDesignTimeHtml(DesignerRegionCollection regions)
        {
            StringBuilder sb = new StringBuilder(256);
            designerRegions = regions;

            EditableDesignerRegion editableDesignerRegion = new EditableDesignerRegion(CurrentDesigner, "Body_" + this.layout.ExpandedPanelIndex);
            designerRegions.Add(editableDesignerRegion);

            sb.AppendFormat("<div style='width:100%;height:100%;margins:0px;padding-addToStart:0px;padding-right:0px;padding-left:0px;padding-bottom:{0}px;'>",23*this.layout.Items.Count);

            bool wasExpaned = false;
            
            for (int i = 0; i < this.layout.Items.Count; i++)
            {
                PanelBase item = this.layout.Items[i] as PanelBase;

                this.AddIcon(item.Icon);

                sb.Append("<div class='x-panel ");

                if (!item.Border)
                {
                    sb.Append("x-panel-noborder ");
                }

                if (item.Collapsed || wasExpaned)
                {
                    SetCollapsed(item, true);
                    sb.Append("x-panel-collapsed");
                }
                else
                {
                    wasExpaned = true;
                }

                sb.Append("' style='width:auto;'>");

                sb.AppendFormat("<a href='#' {0}><div class='x-panel-header ", GetDesignerRegionAttribute(i));

                if (!item.Border)
                {
                    sb.Append("x-panel-header-noborder ");
                }

                sb.Append("x-accordion-hd'>");

                sb.Append("<div class='x-tool x-tool-toggle'></div>");

                string iconCls = item.IconCls;

                if (iconCls.IsNotEmpty())
                {
                    string s =
                        this.GetWebResourceUrl(
                            "Ext.Net.Build.Ext.Net.extjs.resources.images.default.s.gif");
                    sb.AppendFormat("<img class='x-panel-inline-icon {0}'src='{1}'/>", iconCls, s);
                }

                sb.AppendFormat("<span class='x-panel-header-text' style='text-decoration:none;'>{0}</span>", item.Title.IsEmpty() ? "&nbsp;" : item.Title);

                sb.Append("</div></a>");

                if (!item.Collapsed)
                {
                    sb.AppendFormat(@"<div class='x-panel-bwrap' style='DISPLAY: block; LEFT: auto; VISIBILITY: visible; POSITION: static; TOP: auto'>
                                    <div class='x-panel-body {0}' style='width:auto;height:100%;padding:0px;margins:0px;' {1}></div>
                                    </div>", item.Border ? "" : "x-panel-body-noborder", GetEditableDesignerRegionAttribute());
                }

                sb.Append("</div>");
            }

            sb.Append("</div>");

            return sb.ToString() + this.GetIconStyleBlock();
        }

        private static string GetEditableDesignerRegionAttribute()
        {
            return "{0}=\"{1}\"".FormatWith(DesignerRegion.DesignerRegionAttributeName, 0);
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
                        IContent panel = this.layout.Items[activeIndex] as IContent;

                        if (panel != null)
                        {
                            ITemplate contentTemplate = panel.Content;

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

                    if (this.layout.Items.Count > 0)
                    {
                        IContent panel = this.layout.Items[index] as IContent;

                        if (panel != null)
                        {
                            ITemplate template = ControlParser.ParseTemplate(host, content);
                            panel.Content = template;
                        }
                        Tag.SetDirty(true);
                    }
                }
            }
        }

        private static void SetCollapsed(PanelBase item, bool collapse)
        {
            PropertyDescriptor collapsed = TypeDescriptor.GetProperties(item)["Collapsed"];
            collapsed.SetValue(item, collapse);
            item.Collapsed = collapse;
        }

        private string GetDesignerRegionAttribute(int index)
        {
            string name = "Toggle_{0}".FormatWith(index);
            designerRegions.Add(new DesignerRegion(this, name, false));

            return "{0}=\"{1}\"".FormatWith(DesignerRegion.DesignerRegionAttributeName, designerRegions.Count - 1);
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

            switch (parameters[0])
            {
                case "Toggle":
                    Toggle(int.Parse(parameters[1]));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            this.Tag.SetDirty(true);
            this.UpdateDesignTimeHtml();
        }

        private void Toggle(int index)
        {
            if (index < this.layout.Items.Count)
            {
                PanelBase item = this.layout.Items[index] as PanelBase;

                IComponentChangeService changeService =
                        (IComponentChangeService)GetService(typeof(IComponentChangeService));

                try
                {
                    changeService.OnComponentChanging(this.layout,
                                                      TypeDescriptor.GetProperties(this.layout)["Items"]);

                    if (item.Collapsed)
                    {
                        this.ExpandItem(item);
                    }
                    else
                    {
                        TypeDescriptor.GetProperties(item)["Collapsed"].SetValue(item, true);
                        item.Collapsed = true;
                    }

                }
                finally
                {
                    changeService.OnComponentChanged(this.layout,
                                                     TypeDescriptor.GetProperties(this.layout)["Items"],
                                                     null, null);
                }
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void AddPanel()
        {
            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));

            if (host != null)
            {
                Panel item = (Panel)host.CreateComponent(typeof(Panel));
                
                if (item != null)
                {
                    IComponentChangeService changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));

                    try
                    {
                        changeService.OnComponentChanging(layout, TypeDescriptor.GetProperties(layout)["Items"]);
                        item.Title = "Item";
                        item.Border = false;
                        layout.Items.Add(item);

                        this.ExpandItem(item);
                    }
                    finally
                    {
                        changeService.OnComponentChanged(layout, TypeDescriptor.GetProperties(layout)["Items"], null, null);
                    }
                }
                this.UpdateDesignTimeHtml();

                this.Tag.SetDirty(true);
            }
        }

        private void ExpandItem(PanelBase item)
        {
            foreach (PanelBase panel in this.layout.Items)
            {
                if (!panel.Collapsed)
                {
                    TypeDescriptor.GetProperties(panel)["Collapsed"].SetValue(panel, true);
                    panel.Collapsed = true;
                }
            }

            TypeDescriptor.GetProperties(item)["Collapsed"].SetValue(item, false);
            item.Collapsed = false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void RemovePanel()
        {
            int oldIndex = this.layout.ExpandedPanelIndex;

            if (this.layout.ExpandedPanelIndex > -1)
            {
                IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));

                if (host != null)
                {
                    using (DesignerTransaction dt = host.CreateTransaction("Remove Panel"))
                    {
                        IComponentChangeService changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
                        PanelBase panel = this.layout.Items[oldIndex] as PanelBase;
                        
                        try
                        {
                            changeService.OnComponentChanging(this.layout, TypeDescriptor.GetProperties(this.layout)["Items"]);
                            this.layout.Items.Remove(panel);

                            if (this.layout.Items.Count > 0)
                            {
                                PanelBase activeItem =
                                    this.layout.Items[Math.Min(oldIndex, this.layout.Items.Count - 1)] as PanelBase;

                                this.ExpandItem(activeItem);
                            }
                        }
                        finally
                        {
                            changeService.OnComponentChanged(this.layout, TypeDescriptor.GetProperties(this.layout)["Items"], null, null);
                        }

                        panel.Dispose();

                        this.UpdateDesignTimeHtml();
                        dt.Commit();
                    }
                    this.Tag.SetDirty(true);
                }
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
                    actionLists.Add(new AccordionActionList(this));
                }

                return actionLists;
            }
        }

    }
}