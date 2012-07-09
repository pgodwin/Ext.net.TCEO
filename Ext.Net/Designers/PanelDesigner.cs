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
    public partial class PanelDesigner : ContentPanelDesigner
    {
        private DesignerRegionCollection designerRegions;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string XGetDesignTimeHtml(DesignerRegionCollection regions)
        {
            designerRegions = regions;
            Panel c = (Panel)this.Control;
            
            StringWriter writer = new StringWriter(CultureInfo.CurrentCulture);
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);

            string width = " width: {0};".FormatWith((c.Width == Unit.Empty) ? "auto" : c.Width.ToString());
            string height = " height: {0};".FormatWith((c.Height == Unit.Empty) ? "auto" : (c.Height.Value - 27).ToString() + "px");
            
            string buttons = "";
            buttons += (c.Collapsible) ? "<a {0}><div class=\"x-tool x-tool-toggle\">&nbsp;</div></a>" : "";

            if (this.Layout.HasValue && this.Layout.Value != LayoutType.Border || !this.Layout.HasValue)
            {
                if (buttons.IsNotEmpty())
                {
                    buttons = string.Format(buttons, GetDesignerRegionAttribute(PanelClickAction.Toggle));
                }
                else
                {
                    // for prevent shifting regions
                    designerRegions.Add(new DesignerRegion(CurrentDesigner, "Empty", false));
                }
            }
            
            if (this.Layout.HasValue)
            {
                if (!Width.IsEmpty)
                {
                    width = " width: {0};".FormatWith((Width == Unit.Empty) ? "auto" : Width.ToString());
                }

                if (!Height.IsEmpty)
                {
                    if (Height.Type == UnitType.Pixel)
                    {
                        height = " height: {0}px;".FormatWith(Height.Value - 27);  
                    }
                    else
                    {
                        height = " height: {0};".FormatWith(Height);  
                    }
                }

                if (this.Layout.Value == LayoutType.Border)
                {
                    if (BorderRegion.Collapsible && BorderRegion.Region != RegionPosition.Center)
                    {
                        buttons = "<a {1}><div class=\"x-tool x-tool-toggle x-tool-collapse-{0}\">&nbsp;</div></a>".FormatWith(BorderRegion.Region.ToString().ToLower(), GetDesignerRegionAttribute(BorderRegion.Region, BorderLayoutDesigner.BorderLayoutClickAction.Collapse));
                    }
                    else
                    {
                        // for prevent shifting regions
                        designerRegions.Add(new DesignerRegion(CurrentDesigner, "Empty", false));
                        buttons = "";
                    }
                }
            }

            string iconCls = "";

            this.AddIcon(c.Icon);

            if (c.IconClsProxy.IsNotEmpty())
            {
                if (c.Frame)
                {
                    iconCls = "x-panel-icon " + c.IconClsProxy;
                }
                else
                {
                    iconCls = "<img src=\"{0}\" class=\"x-panel-inline-icon {1}\" />".FormatWith(c.ResourceManager.BLANK_IMAGE_URL, c.IconClsProxy);
                }
            }

            string header = "";

            if (c.Header)
            {
                /*
                 * 0  - x-panel-header-noborder
                 * 1  - IconCls
                 * 2  - Title
                 * 3  - Buttons
                 */

                object[] headerArgs = new object[4];
                headerArgs[0] = !c.Border ? "x-panel-header-noborder" : "";
                headerArgs[1] = iconCls;
                headerArgs[2] = c.Title;
                headerArgs[3] = buttons;

                header = string.Format(this.HtmlHeader, headerArgs);
            }

            /*
             0  - Width
             1  - x-panel-noborder
             2  - Collapsed style
             3  - Collapsed  display: block;
             4  - BodyStyle
             5  - Height
             6  - x-panel-body-noborder
             7  - HEADER 
             */

            object[] args = new object[8];
            args[0] = width;
            args[1] = !c.Border ? "x-panel-noborder" : "";
            args[2] = c.Collapsed && c.Collapsible ? "x-panel-collapsed" : "";
            args[3] = (c.Collapsed) ? "display: none;" : "display: block;";
            args[4] = c.BodyStyle;
            args[5] = height;
            args[6] = !c.Border ? "x-panel-body-noborder" : "";
            args[7] = header;

            LiteralControl topCtrl = new LiteralControl(string.Format(this.HtmlBegin, args) + this.GetIconStyleBlock());
            topCtrl.RenderControl(htmlWriter);

            HtmlGenericControl div = (HtmlGenericControl)c.ContentContainer;
            EditableDesignerRegion region = new EditableDesignerRegion(CurrentDesigner, ContentRegionName, false);
            designerRegions.Add(region);

            if ((!c.Collapsible) || (c.Collapsible && !c.Collapsed) || (this.Layout.HasValue && this.Layout.Value == LayoutType.Border))
            {
                div.Attributes[DesignerRegion.DesignerRegionAttributeName] = (designerRegions.Count - 1).ToString();
                div.Style["height"] = "100%";
                div.Style["overflow"] = "hidden";
                div.RenderControl(htmlWriter);
            }
            
            LiteralControl bottomCtrl = new LiteralControl(this.HtmlEnd);
            bottomCtrl.RenderControl(htmlWriter);

            return writer.ToString();
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
                    actionLists.Add(new PanelActionList(this.Component));
                }

                return actionLists;
            }
        }

        private string GetDesignerRegionAttribute(RegionPosition region, BorderLayoutDesigner.BorderLayoutClickAction action)
        {
            string name = "{0}_{1}".FormatWith(region, action);
            designerRegions.Add(new DesignerRegion(CurrentDesigner, name, false));

            return "{0}=\"{1}\"".FormatWith(DesignerRegion.DesignerRegionAttributeName, designerRegions.Count-1);
        }

        private string GetDesignerRegionAttribute(PanelClickAction action)
        {
            designerRegions.Add(new DesignerRegion(CurrentDesigner, action.ToString(), false));

            return "{0}=\"{1}\"".FormatWith(DesignerRegion.DesignerRegionAttributeName, designerRegions.Count - 1);
        }

        enum PanelClickAction
        {
            Toggle
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(DesignerRegionMouseEventArgs e)
        {
            if (e == null || e.Region == null)
            {
                return;
            }
            PanelClickAction action =
                (PanelClickAction)Enum.Parse(typeof(PanelClickAction), e.Region.Name);

            switch(action)
            {
                case PanelClickAction.Toggle:
                    TogglePanel();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TogglePanel()
        {
            Panel panel = (Panel) this.Control;

            PropertyDescriptor collapsed = TypeDescriptor.GetProperties(panel)["Collapsed"];
            bool value = (bool) collapsed.GetValue(panel);
            collapsed.SetValue(panel, !value);
            panel.Collapsed = !value;
        }


        /*
         * 0  - x-panel-header-noborder
         * 1  - IconCls
         * 2  - Title
         * 3  - Buttons
         */
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string HtmlHeader
        {
            get
            {
                return (((Panel)this.Control).Frame) ?
@"<div class=""x-panel-tl"">
        <div class=""x-panel-tr"">
            <div class=""x-panel-tc"">
                <div style=""-moz-user-select: none;"" class=""x-panel-header {0} x-unselectable {1}"">
                    <table cellpading=""0"" cellspacing=""0"" border=""0"" style=""width:auto"">
                        <tr>
                            <td style=""width:1%"" align=""left"" nowrap=""nowrap"">
                                <span class=""x-panel-header-text"">{2}</span>
                            </td>
                            <td align=""right"">
                                {3}
                            </td>
                        </tr>
                    </table>	
                </div>
            </div>
        </div>
    </div>" :

      @"<div style=""-moz-user-select: none;"" class=""x-panel-header {0} x-unselectable"">
            {3}
            {1}
            <span class=""x-panel-header-text"" style=""white-space:nowrap;"">
                {2}
            </span>	
		</div>";
            }
        }

        /*
                <div style="-moz-user-select: none;" class="x-panel-header x-unselectable">
                    <div id="ext-gen6" class="x-tool x-tool-toggle">
                        &nbsp;
                    </div>
                    <img src="/extjs/resources/images/default/s-gif/ext.axd" class="x-panel-inline-icon icon-accept">
                    <span id="ext-gen7" class="x-panel-header-text">
                        another title
                    </span>
                </div>
                
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
            <div id="ext-gen4" class="x-panel-bwrap">
                <div style="width: 598px; height: 372px;" id="ext-gen5" class="x-panel-body">
                </div>
            </div>
         * /

                /*
                 0  - Width
                 1  - x-panel-noborder
                 2  - Collapsed style
                 3  - Collapsed  display: block;
                 4  - BodyStyle
                 5  - Height
                 6  - x-panel-body-noborder
                 7  - HEADER 
                 */

        /// <summary>
        /// 
        /// </summary>
        public override string HtmlBegin
        {
            get
            {
                return (((Panel)this.Control).Frame) ?
@"<div style=""{0}"" class=""x-panel {1} {2}"">
    {7}
    <div style=""{3}"" class=""x-panel-bwrap"">
      <div class=""x-panel-ml"">
        <div class=""x-panel-mr"">
          <div class=""x-panel-mc"">
            <div style=""{4}{5}"" class=""x-panel-body {6}"">" :

@"<div style=""{0}"" class=""x-panel {1} {2}"">
		{7}
		<div style=""position: static; visibility: visible; {3} left: auto;startp: auto; z-index: auto;"" class=""x-panel-bwrap"">
			<div style=""{4}{5}"" class=""x-panel-body {6}"">";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string HtmlEnd
        {
            get
            {
                return (((Panel)this.Control).Frame) ?
@"            </div>
          </div>
        </div>
      </div>
      <div class=""x-panel-bl x-panel-nofooter"">
        <div class=""x-panel-br"">
          <div class=""x-panel-bc""></div>
        </div>
      </div>
    </div>
  </div>" :
          
@"		</div>
	</div>
</div>";
            }
        }
    }
}