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
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// This layout contains multiple panels, each fit to the content Container, where only a single panel can be visible at any given time. This layout style is most commonly used for wizards, tab implementations, etc. This class is intended to be extended or created via the layout:'card' Ext.Container.layout config, and should generally not need to be created directly via the new keyword.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:CardLayout runat=\"server\"></{0}:CardLayout>")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(CardLayout), "Build.ToolboxIcons.Layout.bmp")]
    [Description("This layout contains multiple panels, each fit to the content Container, where only a single panel can be visible at any given time. This layout style is most commonly used for wizards, tab implementations, etc. This class is intended to be extended or created via the layout:'card' Ext.Container.layout config, and should generally not need to be created directly via the new keyword.")]
    public partial class CardLayout : ContainerLayout
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CardLayout() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("4. Layout")]
		[Description("")]
        public override string LayoutType
        {
            get
            {
                return "card";
            }
        }

        /// <summary>
        /// True to render each contained items at the time it becomes active, false to render all contained items as soon as the layout is rendered (defaults to false). If there is a significant amount of content or a lot of heavy controls being rendered into panels that are not displayed by default, setting this to true might improve performance.
        /// </summary>
        [Meta]
        [Category("6. CardLayout")]
        [DefaultValue(false)]
        [Description("True to render each contained items at the time it becomes active, false to render all contained items as soon as the layout is rendered (defaults to false). If there is a significant amount of content or a lot of heavy controls being rendered into panels that are not displayed by default, setting this to true might improve performance.")]
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

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption(JsonMode.Object)]
        [Browsable(false)]
		[Description("")]
        protected internal override LayoutConfig LayoutConfig
        {
            get
            {
                return new CardLayoutConfig(
                    this.DeferredRender,
                    this.LayoutOnCardChange,
                    this.RenderHidden,
                    this.ExtraCls);
            }
        }
    }
}