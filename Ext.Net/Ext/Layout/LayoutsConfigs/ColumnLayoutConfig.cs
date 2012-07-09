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
    public partial class ColumnLayoutConfig : LayoutConfig
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ColumnLayoutConfig(bool fitHeight, bool split, int margin, int scrollOffset, bool background, bool renderHidden, string extraCls)
            : base(renderHidden, extraCls)
        {
            this.FitHeight = fitHeight;
            this.Split = split;
            this.Margin = margin;
            this.ScrollOffset = scrollOffset;
            this.Background = background;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ColumnLayoutConfig()
        {
        }

        /// <summary>
        /// Fit item's height
        /// </summary>
        [ConfigOption]
        [DefaultValue(true)]
        public virtual bool FitHeight
        {
            get
            {
                object obj = this.ViewState["FitHeight"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["FitHeight"] = value;
            }
        }

        /// <summary>
        /// True to fill background by predefined color. Defaults to false.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        public virtual bool Background
        {
            get
            {
                object obj = this.ViewState["Background"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Background"] = value;
            }
        }


        /// <summary>
        /// Add splitter to the item
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        public virtual bool Split
        {
            get
            {
                object obj = this.ViewState["Split"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Split"] = value;
            }
        }
        
        /// <summary>
        /// Item's margin
        /// </summary>
        [ConfigOption]
        [DefaultValue(0)]
        public virtual int Margin
        {
            get
            {
                object obj = this.ViewState["Margin"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["Margin"] = value;
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