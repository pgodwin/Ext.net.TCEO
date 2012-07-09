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

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class HeaderGroupColumn : StateManagedItem
    {
        /// <summary>
        /// optional) Set the CSS text-align property of the column. Defaults to undefined.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("2. HeaderGroupColumn")]
        [DefaultValue(Alignment.Left)]
        [Description("(optional) Set the CSS text-align property of the column. Defaults to undefined.")]
        public virtual Alignment Align
        {
            get
            {
                object obj = this.ViewState["Align"];
                return (obj == null) ? Alignment.Left : (Alignment)obj;
            }
            set
            {
                this.ViewState["Align"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("colspan")]
        [Category("2. HeaderGroupColumn")]
        [DefaultValue(1)]
        [Description("")]
        public virtual int ColSpan
        {
            get
            {
                object obj = this.ViewState["ColSpan"];
                return (obj == null) ? 1 : (int)obj;
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
        [ConfigOption("dataIndex")]
        [Category("2. HeaderGroupColumn")]
        [DefaultValue("")]
        [Description("")]
        public virtual string GroupId
        {
            get
            {
                object obj = this.ViewState["GroupId"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["GroupId"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. HeaderGroupColumn")]
        [DefaultValue("")]
        [Description("")]
        public virtual string Tooltip
        {
            get
            {
                object obj = this.ViewState["Tooltip"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["Tooltip"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. HeaderGroupColumn")]
        [DefaultValue("")]
        [Description("")]
        public virtual string Header
        {
            get
            {
                object obj = this.ViewState["Header"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["Header"] = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class HeaderGroupColumns : StateManagedCollection<HeaderGroupColumn> { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class HeaderGroupRow : StateManagedItem
    {
        private HeaderGroupColumns columns;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual HeaderGroupColumns Columns
        {
            get
            {
                if (this.columns == null)
                {
                    this.columns = new HeaderGroupColumns();
                }

                return this.columns;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class HeaderGroupRows : StateManagedCollection<HeaderGroupRow> { }
}