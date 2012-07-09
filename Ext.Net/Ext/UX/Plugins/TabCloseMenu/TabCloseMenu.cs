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
using System.Collections.Generic;

namespace Ext.Net
{
    /// <summary>
    /// Very simple plugin for adding a close context menu to tabs
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(TabCloseMenu), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:TabCloseMenu runat=\"server\" />")]
    [Description("Very simple plugin for adding a close context menu to tabs")]
    public partial class TabCloseMenu : Plugin, IIcon
    {
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

                baseList.Add(new ClientScriptItem(typeof(TabCloseMenu), "Ext.Net.Build.Ext.Net.ux.plugins.tabclosemenu.tabclosemenu.js", "/ux/plugins/tabclosemenu/tabclosemenu.js"));

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
                return "Ext.ux.TabCloseMenu";
            }
        }

        /// <summary>
        /// Text to display in ContextMenu for menu option to close current Tab.
        /// </summary>
        [ConfigOption]
        [Category("3. TabCloseMenu")]
        [DefaultValue("Close Tab")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("Text to display in ContextMenu for menu option to close current Tab.")]
        public string CloseTabText
        {
            get
            {
                return (string)this.ViewState["CloseTabText"] ?? "Close Tab";
            }
            set
            {
                this.ViewState["CloseTabText"] = value;
            }
        }

        /// <summary>
        /// Text to display in ContextMenu for menu option to close other Tabs.
        /// </summary>
        [ConfigOption]
        [Category("3. TabCloseMenu")]
        [DefaultValue("Close Other Tabs")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("Text to display in ContextMenu for menu option to close other Tabs.")]
        public string CloseOtherTabsText
        {
            get
            {
                return (string)this.ViewState["CloseOtherTabsText"] ?? "Close Other Tabs";
            }
            set
            {
                this.ViewState["CloseOtherTabsText"] = value;
            }
        }

        /// <summary>
        /// The text for closing all tabs. Defaults to 'Close All Tabs'.
        /// </summary>
        [ConfigOption]
        [Category("3. TabCloseMenu")]
        [DefaultValue("Close All Tabs")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("The text for closing all tabs. Defaults to 'Close All Tabs'.")]
        public string CloseAllTabsText
        {
            get
            {
                return (string)this.ViewState["CloseAllTabsText"] ?? "Close All Tabs";
            }
            set
            {
                this.ViewState["CloseAllTabsText"] = value;
            }
        }

        /// <summary>
        /// Indicates whether to show the 'Close All' option. Defaults to true. 
        /// </summary>
        [ConfigOption]
        [Category("3. TabCloseMenu")]
        [DefaultValue(true)]
        [Description("Indicates whether to show the 'Close All' option. Defaults to true.")]
        public virtual bool ShowCloseAll
        {
            get
            {
                object obj = this.ViewState["ShowCloseAll"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ShowCloseAll"] = value;
            }
        }

        /// <summary>
        /// The icon to use for the CloseTab menu item. See also, CloseTabIconCls to set an icon with a custom Css class.
        /// </summary>
        [Category("3. TabCloseMenu")]
        [DefaultValue(Icon.None)]
        [Description("The icon to use for the CloseTab menu item. See also, CloseTabIconCls to set an icon with a custom Css class.")]
        public virtual Icon CloseTabIcon
        {
            get
            {
                object obj = this.ViewState["CloseTabIcon"];
                return (obj == null) ? Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["CloseTabIcon"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("closeTabIconCls")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string CloseTabIconClsProxy
        {
            get
            {
                if (this.CloseTabIcon != Icon.None)
                {
                    return ResourceManager.GetIconClassName(this.CloseTabIcon);
                }

                return this.CloseTabIconCls;
            }
        }
 
        /// <summary>
        /// A CSS class that will provide a background image to be used as the icon to use for the CloseTab menu item (defaults to '').
        /// </summary>
        [Category("3. TabCloseMenu")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class that will provide a background image to be used as the icon to use for the CloseTab menu item (defaults to '').")]
        public virtual string CloseTabIconCls
        {
            get
            {
                return (string)this.ViewState["CloseTabIconCls"] ?? "";
            }
            set
            {
                this.ViewState["CloseTabIconCls"] = value;
            }
        }

        /// <summary>
        /// The icon to use for the CloseOtherTabs menu item. See also, CloseOtherTabsIconCls to set an icon with a custom Css class.
        /// </summary>
        [Category("3. TabCloseMenu")]
        [DefaultValue(Icon.None)]
        [Description("The icon to use for the CloseOtherTabs menu item. See also, CloseOtherTabsIconCls to set an icon with a custom Css class.")]
        public virtual Icon CloseOtherTabsIcon
        {
            get
            {
                object obj = this.ViewState["CloseOtherTabsIcon"];
                return (obj == null) ? Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["CloseOtherTabsIcon"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("closeOtherTabsIconCls")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string CloseOtherTabsIconClsProxy
        {
            get
            {
                if (this.CloseOtherTabsIcon != Icon.None)
                {
                    return ResourceManager.GetIconClassName(this.CloseOtherTabsIcon);
                }

                return this.CloseOtherTabsIconCls;
            }
        }

        /// <summary>
        /// A CSS class that will provide a background image to be used as the icon to use for the CloseOtherTabs menu item (defaults to '').
        /// </summary>
        [Category("3. TabCloseMenu")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class that will provide a background image to be used as the icon to use for the CloseOtherTabs menu item (defaults to '').")]
        public virtual string CloseOtherTabsIconCls
        {
            get
            {
                return (string)this.ViewState["CloseOtherTabsIconCls"] ?? "";
            }
            set
            {
                this.ViewState["CloseOtherTabsIconCls"] = value;
            }
        }

        /// <summary>
        /// The icon to use for the CloseAllTabs menu item. See also, CloseAllTabsIconCls to set an icon with a custom Css class.
        /// </summary>
        [Category("3. TabCloseMenu")]
        [DefaultValue(Icon.None)]
        [Description("The icon to use for the CloseAllTabs menu item. See also, CloseAllTabsIconCls to set an icon with a custom Css class.")]
        public virtual Icon CloseAllTabsIcon
        {
            get
            {
                object obj = this.ViewState["CloseAllTabsIcon"];
                return (obj == null) ? Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["CloseAllTabsIcon"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("closeAllTabsIconCls")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string CloseAllTabsIconClsProxy
        {
            get
            {
                if (this.CloseAllTabsIcon != Icon.None)
                {
                    return ResourceManager.GetIconClassName(this.CloseAllTabsIcon);
                }

                return this.CloseAllTabsIconCls;
            }
        }

        /// <summary>
        /// A CSS class that will provide a background image to be used as the icon to use for the CloseAllTabs menu item (defaults to '').
        /// </summary>
        [Category("3. TabCloseMenu")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class that will provide a background image to be used as the icon to use for the CloseAllTabs menu item (defaults to '').")]
        public virtual string CloseAllTabsIconCls
        {
            get
            {
                return (string)this.ViewState["CloseAllTabsIconCls"] ?? "";
            }
            set
            {
                this.ViewState["CloseAllTabsIconCls"] = value;
            }
        }

        List<Icon> IIcon.Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>(3);
                icons.Add(this.CloseTabIcon);
                icons.Add(this.CloseOtherTabsIcon);
                icons.Add(this.CloseAllTabsIcon);
                return icons;
            }
        }
    }
}