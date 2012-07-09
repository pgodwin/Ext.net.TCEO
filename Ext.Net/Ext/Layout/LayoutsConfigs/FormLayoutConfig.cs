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

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class FormLayoutConfig : LayoutConfig
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FormLayoutConfig(bool trackLabels, string elementStyle, string labelSeparator, string labelStyle, bool renderHidden, string extraCls) : base(renderHidden, extraCls)
        {
            this.TrackLabels = trackLabels;
            this.ElementStyle = elementStyle;
            this.LabelSeparator = labelSeparator;
            this.LabelStyle = labelStyle;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FormLayoutConfig() { }

        /// <summary>
        /// True to show/hide the field label when the field is hidden. Defaults to true. 
        /// </summary>
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to show/hide the field label when the field is hidden. Defaults to true.")]
        public virtual bool TrackLabels
        {
            get
            {
                object obj = this.ViewState["TrackLabels"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["TrackLabels"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [Description("")]
        public virtual string ElementStyle
        {
            get
            {
                return (string)this.ViewState["ElementStyle"] ?? "";
            }
            set
            {
                this.ViewState["ElementStyle"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
        [DefaultValue(":")]
        [Localizable(true)]
		[Description("")]
        public virtual string LabelSeparator
        {
            get
            {
                return (string)this.ViewState["LabelSeparator"] ?? ":";
            }
            set
            {
                this.ViewState["LabelSeparator"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
        [DefaultValue("")]
		[Description("")]
        public string LabelStyle
        {
            get
            {
                return (string)this.ViewState["LabelStyle"] ?? "";
            }
            set
            {
                this.ViewState["LabelStyle"] = value;
            }
        }
    }
}