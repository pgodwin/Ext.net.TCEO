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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class TemplateColumn : Column
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TemplateColumn() { }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("xtype")]
        [DefaultValue("")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "templatecolumn";
            }
        }

        private XTemplate template;

        /// <summary>
        /// An XTemplate to use to process a Record's data to produce a column's rendered value.
        /// </summary>
        [Category("3. TemplateColumn")]
        [ConfigOption("tpl", typeof(LazyControlJsonConverter))]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description(" An XTemplate to use to process a Record's data to produce a column's rendered value.")]
        public virtual XTemplate Template
        {
            get
            {
                if (this.IsSerialize)
                {
                    return null;
                }

                if (this.template == null)
                {
                    this.template = new XTemplate();

                    if (this.ParentGrid != null)
                    {
                        this.ParentGrid.Controls.Add(this.template);
                        this.ParentGrid.LazyItems.Add(this.template);
                    }
                }

                return this.template;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("tpl", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string TemplateSerializationProxy
        {
            get
            {
                if (!this.IsSerialize || this.template == null || this.template.Html.IsEmpty())
                {
                    return "";
                }

                return this.template.ToConfig(LazyMode.Instance);
            }
        }
    }
}