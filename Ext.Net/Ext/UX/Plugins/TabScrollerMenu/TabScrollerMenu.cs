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
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(TabScrollerMenu), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:TabScrollerMenu runat=\"server\" />")]
    [Description("")]
    public partial class TabScrollerMenu : Plugin
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TabScrollerMenu() { }

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

                baseList.Add(new ClientScriptItem(typeof(TabScrollerMenu), "Ext.Net.Build.Ext.Net.ux.plugins.tabscrollermenu.TabScrollerMenu.js", "/ux/plugins/tabscrollermenu/TabScrollerMenu.js"));
                baseList.Add(new ClientStyleItem(typeof(TabScrollerMenu), "Ext.Net.Build.Ext.Net.ux.plugins.tabscrollermenu.css.tab-scroller-menu-embedded.css", "/ux/plugins/tabscrollermenu/css/tab-scroller-menu.css"));

                return baseList;
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
                return "Ext.ux.TabScrollerMenu";
            }
        }

        /// <summary>
        /// The page size.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TabScrollerMenu")]
        [DefaultValue(10)]
        [NotifyParentProperty(true)]
        [Description("The page size.")]
        public virtual int PageSize
        {
            get
            {
                object obj = this.ViewState["PageSize"];
                return (obj == null) ? 10 : (int)obj;
            }
            set
            {
                this.ViewState["PageSize"] = value;
            }
        }

        /// <summary>
        /// The maximum text length to truncate.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TabScrollerMenu")]
        [DefaultValue(15)]
        [NotifyParentProperty(true)]
        [Description("The maximum text length to truncate.")]
        public virtual int MaxText
        {
            get
            {
                object obj = this.ViewState["MaxText"];
                return (obj == null) ? 15 : (int)obj;
            }
            set
            {
                this.ViewState["MaxText"] = value;
            }
        }

        /// <summary>
        /// Menu prefix text.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TabScrollerMenu")]
        [Localizable(true)]
        [DefaultValue("Items")]
        [NotifyParentProperty(true)]
        [Description("Menu prefix text.")]
        public virtual string MenuPrefixText
        {
            get
            {
                return (string)this.ViewState["MenuPrefixText"] ?? "Items";
            }
            set
            {
                this.ViewState["MenuPrefixText"] = value;
            }
        }
    }
}