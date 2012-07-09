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
using System.Web.UI.WebControls;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class GroupingSummaryColumn : Column
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. GroupingSummaryColumn")]
        [DefaultValue(SummaryType.None)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual SummaryType SummaryType
        {
            get
            {
                object obj = this.ViewState["SummaryType"];
                return (obj == null) ? SummaryType.None : (SummaryType)obj;
            }
            set
            {
                this.ViewState["SummaryType"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("summaryType")]
        [Category("3. GroupingSummaryColumn")]
        [DefaultValue("")]
        [Description("")]
        public virtual string CustomSummaryType
        {
            get
            {
                return (string)this.ViewState["CustomSummaryType"] ?? "";
            }
            set
            {
                this.ViewState["CustomSummaryType"] = value;
            }
        }

        private Renderer summaryRenderer;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(typeof(RendererJsonConverter))]
        [Category("3. GroupingSummaryColumn")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ViewStateMember]
        [Description("")]
        public virtual Renderer SummaryRenderer
        {
            get
            {
                if (this.summaryRenderer == null)
                {
                    this.summaryRenderer = new Renderer();
                }

                return this.summaryRenderer;
            }
            set
            {
                this.summaryRenderer = value;
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum SummaryType
    {
        /// <summary>
        /// 
        /// </summary>
        None,

        /// <summary>
        /// 
        /// </summary>
        Average,

        /// <summary>
        /// 
        /// </summary>
        Count,

        /// <summary>
        /// 
        /// </summary>
        Max,

        /// <summary>
        /// 
        /// </summary>
        Min,

        /// <summary>
        /// 
        /// </summary>
        Sum
    }
}