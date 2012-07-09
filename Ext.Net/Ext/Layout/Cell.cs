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
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class Cell : LayoutItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Cell() { }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("rowspan", JsonMode.Raw)]
        [NotifyParentProperty(true)]
        [Category("6. TableLayout")]
        [DefaultValue(0)]
        [Description("")]
        public virtual int RowSpan
        {
            get
            {
                object obj = this.ViewState["RowSpan"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["RowSpan"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("colspan", JsonMode.Raw)]
        [NotifyParentProperty(true)]
        [Category("6. TableLayout")]
        [DefaultValue(0)]
        [Description("")]
        public virtual int ColSpan
        {
            get
            {
                object obj = this.ViewState["ColSpan"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["ColSpan"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TableLayout")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string CellCls
        {
            get
            {
                return (string)this.ViewState["CellCls"] ?? "";
            }
            set
            {
                this.ViewState["CellCls"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TableLayout")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string CellId
        {
            get
            {
                return (string)this.ViewState["CellId"] ?? "";
            }
            set
            {
                this.ViewState["CellId"] = value;
            }
        }
    }
}