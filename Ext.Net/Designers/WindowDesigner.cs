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

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class WindowDesigner : PanelDesigner
    {
        private DesignerRegionCollection designerRegions;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string XGetDesignTimeHtml(DesignerRegionCollection regions)
        {
            Window c = (Window)this.Control;
            designerRegions = regions;

            EditableDesignerRegion region = new EditableDesignerRegion(this, "Body", false);
            regions.Add(region);

            StringWriter writer = new StringWriter(CultureInfo.CurrentCulture);
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);

            string width = " width: {0};".FormatWith(c.Width.ToString());
            string height = " height: {0}px;".FormatWith((c.Height.Value - 30).ToString());

            string buttons = "";
            buttons += (c.Closable) ? "<div class=\"x-tool x-tool-close\">&nbsp;</div>" : "";
            buttons += (c.Maximizable) ? "<div class=\"x-tool x-tool-maximize\">&nbsp;</div>" : "";
            buttons += (c.Minimizable) ? "<div class=\"x-tool x-tool-minimize\">&nbsp;</div>" : "";
            buttons += (c.Collapsible) ? "<a {0}><div class=\"x-tool x-tool-toggle\">&nbsp;</div></a>" : "";


            if (c.Collapsible)
            {
                buttons = string.Format(buttons, GetDesignerRegionAttribute(WindowClickAction.Toggle));
            }
            else
            {
                // for prevent shifting regions
                designerRegions.Add(new DesignerRegion(this.CurrentDesigner, "Empty", false));
            }

            /*
             * 0 - ClientID
             * 1 - Title
             * 2 - Width
             * 3 - Height
             * 4 - Buttons
             * 5 - BodyStyle
             */

            object[] args = new object[9];
            args[0] = c.ClientID;
            args[1] = c.Title.IsEmpty() ? "&nbsp;" : c.Title;
            args[2] = width;
            args[3] = height;
            args[4] = buttons;
            args[5] = c.BodyStyle;
            args[6] = c.IconClsProxy.IsNotEmpty() ? "x-panel-icon " + c.IconClsProxy : "";
            args[7] = c.Collapsed && c.Collapsible ? "x-panel-collapsed" : "";
            args[8] = (c.Collapsed && c.Collapsible) ? "display: none;" : "display: block;";

            // NOTE: Make sure you add to the object[SIZE] above if adding to the args array.

            this.AddIcon(c.Icon);

            LiteralControl topCtrl = new LiteralControl(string.Format(this.HtmlBegin, args) + this.GetIconStyleBlock());
  
            topCtrl.RenderControl(htmlWriter);

            if (!(c.Collapsed && c.Collapsible))
            {
                HtmlGenericControl div = (HtmlGenericControl)c.ContentContainer;
                div.Attributes[DesignerRegion.DesignerRegionAttributeName] = "0";
                div.Style["height"] = "100%";
                div.RenderControl(htmlWriter);
            }


            LiteralControl bottomCtrl = new LiteralControl(string.Format(this.HtmlEnd, args[8]));
            
            bottomCtrl.RenderControl(htmlWriter);

            string temp = writer.ToString();

            return temp;
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
                    actionLists.Add(new WindowActionList(this.Component));
                }

                return actionLists;
            }
        }

        private string GetDesignerRegionAttribute(WindowClickAction action)
        {
            designerRegions.Add(new DesignerRegion(this.CurrentDesigner, action.ToString(), false));

            return "{0}=\"{1}\"".FormatWith(DesignerRegion.DesignerRegionAttributeName, designerRegions.Count - 1);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnClick(DesignerRegionMouseEventArgs e)
        {
            WindowClickAction action =
                (WindowClickAction)Enum.Parse(typeof(WindowClickAction), e.Region.Name);

            switch (action)
            {
                case WindowClickAction.Toggle:
                    ToggleWindow();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ToggleWindow()
        {
            Window window = (Window)this.Control;

            PropertyDescriptor collapsed = TypeDescriptor.GetProperties(window)["Collapsed"];
            bool value = (bool)collapsed.GetValue(window);
            collapsed.SetValue(window, !value);
            window.Collapsed = !value;
        }

        enum WindowClickAction
        {
            Toggle
        }

        /*
         * 0 - ClientID
         * 1 - Title
         * 2 - Width
         * 3 - Height
         * 4 - Buttons
         * 5 - BodyStyle
         * 6 - IconCls
         * 7 - Collapsed style
         * 8  - Collapsed  display: block;
         */

        public override string HtmlBegin
        {
            get
            {
                return @"<div style=""display: block;{2}"" class=""x-window x-resizable-pinned {7}"">
    <div class=""x-window-tl"">
      <div class=""x-window-tr"">
        <div class=""x-window-tc"">
          <div style=""-moz-user-select: none;"" class=""x-window-header x-unselectable x-window-draggable {6}"">
            {4}
            <span class=""x-window-header-text"">{1}</span>
          </div>
        </div>
      </div>
    </div>
    <div class=""x-window-bwrap"" >
      <div class=""x-window-ml"" style=""{8}"">
        <div class=""x-window-mr"">
          <div class=""x-window-mc"">
            <div style=""{5}{3}"" class=""x-window-body"">
               <div>";
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
                return
    @"       </div>
            </div>
           </div>
          </div>
         </div>
      <div class=""x-window-bl x-panel-nofooter"" style=""{0}"">
        <div class=""x-window-br"">
          <div class=""x-window-bc""></div>
        </div>
      </div>
    </div>
  </div>";
            }
        }
    }
}