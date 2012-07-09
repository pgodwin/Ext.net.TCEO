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
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class DateFieldDesigner : ExtControlDesigner
    {
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
        public override string XGetDesignTimeHtml()
        {
            StringWriter writer = new StringWriter(CultureInfo.CurrentCulture);
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);

            DateField c = (DateField)this.Control;

            string width = (c.Width != Unit.Empty) ? " width: {0};".FormatWith(c.Width.ToString()) : "";
            string height = (c.Height != Unit.Empty) ? " height: {0};".FormatWith(c.Height.ToString()) : "";

            object[] args = new object[9];
            args[0] = c.ClientID;

            if (c.SelectedDate != DateTime.MinValue && c.SelectedDate != DateTime.MaxValue)
            {
                args[1] = c.SelectedDate.ToString(c.Format);
            }
            else
            {
                args[1] = "";
            }
            
            args[2] = width;
            args[3] = height;
            args[4] = c.StyleSpec;
            args[5] = "x-form-text x-form-field " + ((c.IsEmpty) ? "x-form-empty-field " : "") + c.Cls;
            args[6] = "x-form-trigger x-form-date-trigger " + c.TriggerClass;

            ResourceManager sm = c.ResourceManager;

            if (sm != null)
            {
                args[7] = c.ResourceManager.BLANK_IMAGE_URL;
            }
            else
            {
                args[7] = "";
            }
            args[8] = " width: {0};".FormatWith((c.Width != Unit.Empty) ? (c.Width.Value + 20) + "px" : "144px");

            LiteralControl ctrl = new LiteralControl(string.Format(this.Html, args));
            ctrl.RenderControl(htmlWriter);

            return writer.ToString();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string Html
        {
            get
            {
                /*
                 * 0 - ClientID
                 * 1 - Text
                 * 2 - Width
                 * 3 - Height
                 * 4 - Style
                 * 5 - Class
                 * 6 - Image Class
                 * 7 - Image Url
                 * 8 - Wrapper Width
                 */
                return @"<div style=""{8}"" class=""x-form-field-wrap""><input value=""{1}"" type=""text"" style=""{4}{3}{2}"" class=""{5}"" /><img src=""{7}"" class=""{6}""></div>";
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
                    actionLists.Add(new DateFieldActionList(this.Component));
                }

                return actionLists;
            }
        }
    }
}