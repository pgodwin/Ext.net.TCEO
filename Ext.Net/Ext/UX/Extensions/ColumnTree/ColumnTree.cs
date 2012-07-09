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
    [Meta]
    [Description("")]
    public partial class ColumnTree : TreePanel
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ColumnTree() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string ColumnNodeUI
        {
            get
            {
                return "Ext.tree.ColumnNodeUI";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "columntree";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.tree.ColumnTree";
            }
        }

        private ColumnTreeColumnCollection columns;

        /// <summary>
        /// An array of column configuration objects
        /// </summary>
        [Meta]
        [ConfigOption("columns", JsonMode.AlwaysArray)]
        [Category("8. ColumnTree")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An array of column configuration objects")]
        public virtual ColumnTreeColumnCollection Columns
        {
            get
            {
                if (this.columns == null)
                {
                    this.columns = new ColumnTreeColumnCollection();
                }

                return this.columns;
            }
        }

        /// <summary>
        /// True to hide the grid's header (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to hide the grid's header (defaults to false).")]
        public virtual bool HideHeaders
        {
            get
            {
                object obj = this.ViewState["HideHeaders"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideHeaders"] = value;
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
                baseList.Capacity += 2;

                baseList.Add(new ClientStyleItem(typeof(MultiSelect), "Ext.Net.Build.Ext.Net.ux.extensions.columntree.resources.css.columnnodeui-embedded.css", "/ux/extensions/columntree/resources/css/columnnodeui.css"));
                baseList.Add(new ClientScriptItem(typeof(MultiSelect), "Ext.Net.Build.Ext.Net.ux.extensions.columntree.columnnodeui.js", "/ux/extensions/columntree/columnnodeui.js"));

                return baseList;
            }
        }
    }
}