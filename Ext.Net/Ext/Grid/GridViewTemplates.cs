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

using System.ComponentModel;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class GridViewTemplates : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public GridViewTemplates() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public GridViewTemplates(Control owner) : base(owner) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public GridView View
        {
            get
            {
                return this.Owner as GridView;
            }
        }

        private XTemplate header;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("header", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public XTemplate Header
        {
            get
            {
                if (this.View.ParentGrid is PropertyGrid)
                {
                    return null;
                }

                this.EnsureHeader();                

                return this.header;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void EnsureHeader()
        {
            if (this.View.ParentGrid is PropertyGrid)
            {
                return;
            }

            if (this.header == null)
            {
                this.header = new XTemplate();
                this.header.PreRender += new System.EventHandler(header_PreRender);
            }     
        }

        void header_PreRender(object sender, System.EventArgs e)
        {
            this.BuildHeaderTemplate();
        }

        internal void BuildHeaderTemplate()
        {
            if (this.View.HeaderRows.Count > 0)
            {
                StringBuilder sb = new StringBuilder(128);
                sb.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"{tstyle}\">");

                if (this.View.StandardHeaderRow)
                {
                    sb.Append("<thead><tr class=\"x-grid3-hd-row x-grid3-sadd-row\">{cells}</tr></thead>");
                }

                sb.Append("<tbody>");
                int rowIndex = 0;

                foreach (HeaderRow headerRow in this.View.HeaderRows)
                {
                    sb.AppendFormat("<tr class=\"x-grid3-hd-row x-grid3-add-row x-grid3-hd-row-r{1} {0}\">", headerRow.Cls, rowIndex++);

                    int colIndex = 0;

                    foreach (HeaderColumn headerColumn in headerRow.Columns)
                    {
                        sb.AppendFormat("<td class=\"x-grid3-hd x-grid3-cell x-grid3-td-c{0}\"><div class=\"x-grid3-hd-inner x-grid3-add {1}\"></div></td>", colIndex++, headerColumn.Cls);
                    }

                    sb.Append("</tr>");
                }

                sb.Append("</tbody>");
                sb.Append("</table>");

                this.Header.Html = sb.ToString();
            }
        }
    }
}