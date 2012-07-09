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

namespace Ext.Net
{
    /// <summary>
    /// A custom GridView which renders rows on an as-needed basis.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("A custom GridView which renders rows on an as-needed basis.")]
    public partial class BufferView : GridView
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public BufferView() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.ux.grid.BufferView";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 1;

                baseList.Add(new ClientScriptItem(typeof(BufferView), "Ext.Net.Build.Ext.Net.ux.extensions.bufferview.bufferview.js", "/ux/extensions/bufferview/bufferview.js"));

                return baseList;
            }
        }

        /// <summary>
        /// The height of a row in the grid.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("4. BufferView")]
        [DefaultValue(19)]
        [Description("The height of a row in the grid.")]
        public virtual int RowHeight
        {
            get
            {
                object obj = this.ViewState["RowHeight"];
                return (obj == null) ? 19 : (int)obj;
            }
            set
            {
                this.ViewState["RowHeight"] = value;
            }
        }

        /// <summary>
        /// The combined height of border-top and border-bottom of a row.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("4. BufferView")]
        [DefaultValue(2)]
        [Description("The combined height of border-top and border-bottom of a row.")]
        public virtual int BorderHeight
        {
            get
            {
                object obj = this.ViewState["BorderHeight"];
                return (obj == null) ? 2 : (int)obj;
            }
            set
            {
                this.ViewState["BorderHeight"] = value;
            }
        }

        /// <summary>
        /// The number of milliseconds before rendering rows out of the visible viewing area. Defaults to 100. Rows will render immediately with a config of false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("4. BufferView")]
        [DefaultValue(100)]
        [Description("The number of milliseconds before rendering rows out of the visible viewing area. Defaults to 100. Rows will render immediately with a config of false.")]
        public virtual int ScrollDelay
        {
            get
            {
                object obj = this.ViewState["ScrollDelay"];
                return (obj == null) ? 100 : (int)obj;
            }
            set
            {
                this.ViewState["ScrollDelay"] = value;
            }
        }

        /// <summary>
        /// The number of rows to look forward and backwards from the currently viewable area.  The cache applies only to rows that have been rendered already.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("4. BufferView")]
        [DefaultValue(20)]
        [Description("The number of rows to look forward and backwards from the currently viewable area.  The cache applies only to rows that have been rendered already.")]
        public virtual int CacheSize
        {
            get
            {
                object obj = this.ViewState["CacheSize"];
                return (obj == null) ? 20 : (int)obj;
            }
            set
            {
                this.ViewState["CacheSize"] = value;
            }
        }

        /// <summary>
        /// The number of milliseconds to buffer cleaning of extra rows not in the cache.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("4. BufferView")]
        [DefaultValue(500)]
        [Description("The number of milliseconds to buffer cleaning of extra rows not in the cache.")]
        public virtual int CleanDelay
        {
            get
            {
                object obj = this.ViewState["CleanDelay"];
                return (obj == null) ? 500 : (int)obj;
            }
            set
            {
                this.ViewState["CleanDelay"] = value;
            }
        }
    }
}