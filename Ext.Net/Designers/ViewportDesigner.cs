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
    public partial class ViewportDesigner : ExtControlDesigner
    {
        private Viewport viewPort;
        private DesignerRegionCollection designerRegions;
        private int height = 750;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            this.viewPort = component as Viewport;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool AllowResize
        {
            get
            {
                return false;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string XGetDesignTimeHtml(DesignerRegionCollection regions)
        {
            //if (DTEUtilities.Connect())
            //{
            //    // Make an approximate calculation for the current designer window height.
            //    EnvDTE._DTE dte = DTEUtilities._application;
            //    int offset = ((this.Control.ResourceManager.Hide) ? 42 : 143);
            //    this.height = dte.ActiveWindow.Height - offset;
            //}
            
            //EnvDTE.DTE dte = (EnvDTE.DTE)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.9.0");
            //int offset = ((this.Control.ResourceManager.Hide) ? 42 : 143);
            //this.height = dte.ActiveWindow.Height - offset;



            designerRegions = regions;

            StringBuilder sb = new StringBuilder(256);

            if (this.viewPort.LayoutControl == null)
            {
                sb.Append(begin);

                object[] prms = new object[]
                    {
                        this.GetWebResourceUrl("Ext.Net.Build.Ext.Net.icons.add.png"),
                        this.GetDesignerRegionAttribute(ViewportClickAction.AddBorderLayout),
                        this.GetDesignerRegionAttribute(ViewportClickAction.AddFitLayout),
                        this.GetDesignerRegionAttribute(ViewportClickAction.AddAccordion)
                    };

                sb.AppendFormat(content, prms);
                sb.AppendFormat(editor, GetEditableDesignerAttribute(), 100);
                sb.Append(end);
            }
            else
            {
                if (!this.viewPort.Height.IsEmpty)
                {
                    this.height = (int)this.viewPort.Height.Value;
                }
                sb.AppendFormat(editor, GetEditableDesignerAttribute(), this.height);
            }

            return sb.ToString();
        }

        private string GetEditableDesignerAttribute()
        {
            EditableDesignerRegion region = new EditableDesignerRegion(this, "Body", true);
            designerRegions.Add(region);

            return "{0}=\"{1}\"".FormatWith(DesignerRegion.DesignerRegionAttributeName, designerRegions.Count - 1);
        }

        private readonly string begin =
            @"<table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""border:1px solid #99bbe8;width:100%;height:100%;background-color:#dfe8f6;""
                                    <tr><td style=""padding:5px 10px;background-color: #C8DAF4;border-bottom:1px solid #99bbe8;color:#15428b;""><b>Viewport control</b></td></tr>
                                    <tr style=""height:100%;""><td align=""center"" valign=""middle"" style=""padding: 20px 40px;"">";

        private readonly string content =
            @"<table border=""0"">
              <tr>
              <td align=""left"">
              <p style=""padding:5px;""><img src=""{0}""><a href=""#"" {3}>Add Accordion</a></p>
              <p style=""padding:5px;""><img src=""{0}""><a style=""color:silver;"">Add AnchorLayout</a></p>
              <p style=""padding:5px;""><img src=""{0}""><a href=""#"" {1}>Add BorderLayout</a></p>
              <p style=""padding:5px;""><img src=""{0}""><a style=""color:silver;"">Add CardLayout</a></p>
              </td>
              <td align=""left"">
              <p style=""padding:5px;""><img src=""{0}""><a style=""color:silver;"">Add ColumnLayout</a></p>              
              <p style=""padding:5px;""><img src=""{0}""><a style=""color:silver;"">Add ContainerLayout</a></p>
              <p style=""padding:5px;""><img src=""{0}""><a href=""#"" {2}>Add FitLayout</a></p>
              <p style=""padding:5px;""><img src=""{0}""><a style=""color:silver;"">Add TableLayout</a></p>
              </td>
              </tr>
              </table>
              <br/>
              <p><span>or drop any layout to the area placed below</span></p><br/>";

        private readonly string editor =
            @"<div style=""width:100%; height:{1}px;border:1px solid #99bbe8;background-color:#E8EDF4;"" {0}></div>";

        private readonly string end = "</td></tr></table>";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnClick(DesignerRegionMouseEventArgs e)
        {
            string actionName = e.Region.Name;

            ViewportClickAction action =
                (ViewportClickAction)Enum.Parse(typeof(ViewportClickAction), actionName);

            switch(action)
            {
                case ViewportClickAction.AddBorderLayout:
                    AddBorderLayout();
                    break;
                case ViewportClickAction.AddFitLayout:
                    AddFitLayout();
                    break;
                case ViewportClickAction.AddAccordion:
                    AddAccordion();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddAccordion()
        {
            AddLayout(typeof(AccordionLayout));
        }

        private void AddBorderLayout()
        {
            AddLayout(typeof (BorderLayout));
        }

        private void AddFitLayout()
        {
            AddLayout(typeof(FitLayout));
        }

        private void AddLayout(Type layoutType)
        {
            object[] attrs = layoutType.GetCustomAttributes(typeof(ToolboxDataAttribute), true);

            if (attrs.Length != 1)
            {
                return;
            }

            ToolboxDataAttribute attr = (ToolboxDataAttribute)attrs[0];

            SetEditableDesignerRegionContent(designerRegions[0] as EditableDesignerRegion,
                                             string.Format(attr.Data, "ext"));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string GetEditableDesignerRegionContent(EditableDesignerRegion region)
        {
            IDesignerHost host = (IDesignerHost) Component.Site.GetService(typeof (IDesignerHost));

            if (host != null)
            {
                ITemplate template = this.viewPort.Content;

                if (template != null && this.viewPort.LayoutControl != null)
                {
                    return ControlPersister.PersistTemplate(template, host);
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
                return;

            IDesignerHost host = (IDesignerHost) Component.Site.GetService(typeof (IDesignerHost));

            if (host != null)
            {
                ITemplate template = ControlParser.ParseTemplate(host, content);

                if (template == null)
                {
                    this.viewPort.Content = template;
                    this.viewPort.ContentContainer.Controls.Clear();
                    this.ChangeService();
                    return;
                }

                Control control = ControlParser.ParseControl(host, content);

                if (control is Layout)
                {
                    bool needRefresh = this.viewPort.LayoutControl == null;
                    this.viewPort.Content = template;

                    this.viewPort.ContentContainer.Controls.Clear();
                    this.viewPort.ContentContainer.Controls.Add(control);

                    if (needRefresh)
                    {
                        this.ChangeService();
                    }
                }
                else
                {
                   /*
                   NOTE: We need to call ChangeService for clear content template if user drop not layout
                         But if control have ActionList then after drop this ActionList will be shown
                         If we call ChangeService at this moment than VS will crash because trying show
                         ActionList not exists control
                         
                         Need find solution for fixed it
                   */
 

                   // this.ChangeService();
                }
            }
        }

        private void ChangeService()
        {
            IComponentChangeService changeService =
                (IComponentChangeService) GetService(typeof (IComponentChangeService));

            try
            {
                changeService.OnComponentChanging(this.viewPort,
                                                  TypeDescriptor.GetProperties(this.viewPort)["Body"]);
            }
            finally
            {
                changeService.OnComponentChanged(this.viewPort,
                                                 TypeDescriptor.GetProperties(this.viewPort)["Body"], null, null);
            }
        }

        private string GetDesignerRegionAttribute(ViewportClickAction action)
        {
            designerRegions.Add(new DesignerRegion(this, action.ToString(), false));

            return "{0}=\"{1}\"".FormatWith(DesignerRegion.DesignerRegionAttributeName, designerRegions.Count - 1);
        }

        enum ViewportClickAction
        {
            AddBorderLayout,
            AddFitLayout,
            AddAccordion
        }
    }
}