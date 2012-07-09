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

using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class RowNumbererColumn : ColumnBase, ICustomConfigSerialization
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RowNumbererColumn() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToScript(Control owner)
        {
            return string.Concat("new Ext.grid.RowNumberer(", new ClientConfig().Serialize(this, true), ")");
        }

        /// <summary>
        /// (optional) The initial width in pixels of the column. Using this instead of Ext.grid.GridPanel.autoSizeColumns is more efficient.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. ColumnBase")]
        [DefaultValue(typeof(Unit), "-1")]
        [Description("(optional) The initial width in pixels of the column. Using this instead of Ext.grid.Grid.autoSizeColumns is more efficient.")]
        public override Unit Width
        {
            get
            {
                object obj = this.ViewState["Width"];
                return (obj == null) ? Unit.Pixel(-1) : (Unit)obj;
            }
            set
            {
                this.ViewState["Width"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("rowspan")]
        [DefaultValue(1)]
        [Category("2. ColumnBase")]
        [Description("")]
        public int RowSpan
        {
            get
            {
                object obj = this.ViewState["RowSpan"];
                return obj != null ? (int)obj : 1;
            }
            set
            {
                this.ViewState["RowSpan"] = value;
            }
        }

    }
}
