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
    public abstract partial class BoxLayoutConfig : LayoutConfig
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public BoxLayoutConfig(string defaultMargins, string padding, BoxPack pack, int scrollOffset, bool renderHidden, string extraCls)
            : base(renderHidden, extraCls)
        {
            this.DefaultMargins = defaultMargins;
            this.Padding = padding;
            this.ScrollOffset = scrollOffset;
            this.Pack = pack;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected BoxLayoutConfig() { }

        /// <summary>
        /// If the individual contained items do not have a margins property specified, the default margins from this property will be applied to each item.
        /// The order of the sides associated with each value matches the way CSS processes margin values:
        ///    If there is only one value, it applies to all sides.
        ///    If there are two values, the top and bottom borders are set to the first value and the right and left are set to the second.
        ///    If there are three values, the top is set to the first value, the left and right are set to the second, and the bottom is set to the third.
        ///    If there are four values, they apply to the top, right, bottom, and left, respectively.
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        public string DefaultMargins
        {
            get
            {
                return (string)this.ViewState["DefaultMargins"] ?? "";
            }
            set
            {
                this.ViewState["DefaultMargins"] = value;
            }
        }

        /// <summary>
        /// Defaults to '0'. Sets the padding to be applied to all child items managed by this container's layout.
        /// </summary>
        [ConfigOption]
        [DefaultValue("0")]
        public string Padding
        {
            get
            {
                return (string)this.ViewState["Padding"] ?? "0";
            }
            set
            {
                this.ViewState["Padding"] = value;
            }
        }

        /// <summary>
        /// Controls how the child items of the container are packed together.
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(BoxPack.Start)]
        public BoxPack Pack
        {
            get
            {
                object obj = this.ViewState["Pack"];
                return obj == null ? BoxPack.Start : (BoxPack) obj;
            }
            set
            {
                this.ViewState["Pack"] = value;
            }
        }

        /// <summary>
        /// The amount of space to reserve for the scrollbar
        /// </summary>
        [ConfigOption]
        [DefaultValue(0)]
        public virtual int ScrollOffset
        {
            get
            {
                object obj = this.ViewState["ScrollOffset"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["ScrollOffset"] = value;
            }
        }
    }
}