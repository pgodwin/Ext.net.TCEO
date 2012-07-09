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
    public partial class CardLayoutConfig : LayoutConfig
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CardLayoutConfig() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CardLayoutConfig(bool deferredRender, bool layoutOnCardChange, bool renderHidden, string extraCls) : base(renderHidden, extraCls)
        {
            this.DeferredRender = deferredRender;
            this.LayoutOnCardChange = layoutOnCardChange;
        }

        /// <summary>
        /// True to render each contained item at the time it becomes active, false to render all contained items as soon as the layout is rendered (defaults to false). If there is a significant amount of content or a lot of heavy controls being rendered into panels that are not displayed by default, setting this to true might improve performance.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CardLayout")]
        [DefaultValue(false)]
        [Description("True to render each contained item at the time it becomes active, false to render all contained items as soon as the layout is rendered (defaults to false). If there is a significant amount of content or a lot of heavy controls being rendered into panels that are not displayed by default, setting this to true might improve performance.")]
        public virtual bool DeferredRender
        {
            get
            {
                object obj = this.ViewState["DeferredRender"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["DeferredRender"] = value;
            }
        }

        /// <summary>
        /// True to force a layout of the active item when the active card is changed. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CardLayout")]
        [DefaultValue(false)]
        [Description("True to force a layout of the active item when the active card is changed. Defaults to false.")]
        public virtual bool LayoutOnCardChange
        {
            get
            {
                object obj = this.ViewState["LayoutOnCardChange"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["LayoutOnCardChange"] = value;
            }
        }
    }
}