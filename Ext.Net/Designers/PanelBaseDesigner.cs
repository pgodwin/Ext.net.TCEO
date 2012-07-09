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

using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class PanelBaseDesigner : ContainerDesigner
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected string BuildFooter
        {
            get
            {
                StringBuilder footer = new StringBuilder(256);

                PanelBase panel = (PanelBase) this.Control;
                
                footer.AppendFormat(footerTemplateBegin, FooterClass, panel.ButtonAlign.ToString().ToLower());

                foreach (ButtonBase button in panel.Buttons)
                {
                    ButtonDesigner designer = new ButtonDesigner();
                    footer.AppendFormat(buttonWraper, designer.BuildButton(button));
                }

                footer.Append(footerTemplateEnd);
                return footer.ToString();
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual string FooterClass
        {
            get
            {
                return "x-panel-footer";
            }
        }

        //0 - FooterClass
        //1 - buttons align
        private const string footerTemplateBegin = "<div class=\"{0}\"><div class=\"x-panel-btns-ct\"><div class=\"x-panel-btns x-panel-btns-{1}\"><table cellSpacing=\"0\"><tbody><tr>";

        private const string footerTemplateEnd = "</tr></tbody></table><div class=\"x-clear\"/></div></div></div>";

        //0 - button(buttonTemplate)
        private const string buttonWraper = "<td class=\"x-panel-btn-td\">{0}</td>";

        private LayoutType? layout;
        internal LayoutType? Layout
        {
            get { return layout; }
            set { layout = value; }
        }

        private BorderLayoutRegion borderRegion;
        internal BorderLayoutRegion BorderRegion
        {
            get { return borderRegion; }
            set { borderRegion = value; }
        }

        private Unit width;
        internal Unit Width
        {
            get { return width; }
            set { width = value; }
        }

        private Unit height;
        internal Unit Height
        {
            get { return height; }
            set { height = value; }
        }
    }
}