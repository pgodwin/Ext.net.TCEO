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
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class MenuBase : ContainerBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool RemoveContainer
        {
            get
            {
                return this.Floating;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.Items.Count == 0 && !this.RenderEmptyMenu;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal bool RenderEmptyMenu
        {
            get;
            set;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool UseDefaultLayout
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').
        /// </summary>
        [Meta]
        [Category("5. Container")]
        [DefaultValue("MenuItem")]
        [NotifyParentProperty(true)]
        [Description("The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').")]
        public override string DefaultType
        {
            get
            {
                return (string)this.ViewState["DefaultType"] ?? "MenuItem";
            }
            set
            {
                this.ViewState["DefaultType"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("defaultType")]
        [DefaultValue("menuitem")]
        [Description("")]
        protected override string DefaultTypeProxy
        {
            get
            {
                return base.DefaultTypeProxy;
            }
        }

        /// <summary>
        /// Whenever a menu gets so long that the items won't fit the viewable area, it provides the user with an easy UI to scroll the menu.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Whenever a menu gets so long that the items won't fit the viewable area, it provides the user with an easy UI to scroll the menu.")]
        public virtual bool EnableScrolling
        {
            get
            {
                object obj = this.ViewState["EnableScrolling"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["EnableScrolling"] = value;
            }
        }

        /// <summary>
        /// By default, a Menu configured as floating:true will be rendered as an Ext.Layer (an absolutely positioned, floating Component with zindex=15000). If configured as floating:false, the Menu may be used as child item of another Container instead of a free-floating Layer.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("By default, a Menu configured as floating:true will be rendered as an Ext.Layer (an absolutely positioned, floating Component with zindex=15000). If configured as floating:false, the Menu may be used as child item of another Container instead of a free-floating Layer.")]
        public virtual bool Floating
        {
            get
            {
                object obj = this.ViewState["Floating"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Floating"] = value;
            }
        }

        /// <summary>
        /// True to allow multiple menus to be displayed at the same time (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to allow multiple menus to be displayed at the same time (defaults to false).")]
        public virtual bool AllowOtherMenus
        {
            get
            {
                object obj = this.ViewState["AllowOtherMenus"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AllowOtherMenus"] = value;
            }
        }

        /// <summary>
        /// The default Ext.Element.alignTo anchor position value for this menu relative to its element of origin (defaults to \"tl-bl?\")
        /// </summary>
        [Meta]
        [Category("6. Menu")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The default Ext.Element.alignTo anchor position value for this menu relative to its element of origin (defaults to \"tl-bl?\")")]
        public virtual string DefaultAlign
        {
            get
            {
                return (string)this.ViewState["DefaultAlign"] ?? "";
            }
            set
            {
                this.ViewState["DefaultAlign"] = value;
            }
        }

        /// <summary>
        /// X offset in pixels by which to change the default Menu popup position after aligning according to the defaultAlign configuration. 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("X offset in pixels by which to change the default Menu popup position after aligning according to the defaultAlign configuration.")]
        public virtual int OffsetX
        {
            get
            {
                object obj = this.ViewState["OffsetX"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["OffsetX"] = value;
            }
        }

        /// <summary>
        /// Y offset in pixels by which to change the default Menu popup position after aligning according to the defaultAlign configuration. 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("Y offset in pixels by which to change the default Menu popup position after aligning according to the defaultAlign configuration.")]
        public virtual int OffsetY
        {
            get
            {
                object obj = this.ViewState["OffsetY"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["OffsetY"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected internal string DefaultOffsets
        {
            get
            {
                if (this.OffsetX == 0 && this.OffsetY == 0)
                {
                    return "";
                }

                return "[".ConcatWith(this.OffsetX, ",", this.OffsetY, "]");
            }
        }

        /// <summary>
        /// True to ignore clicks on any item in this menu that is a parent item (displays a submenu) so that the submenu is not dismissed when clicking the parent item (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to ignore clicks on any item in this menu that is a parent item (displays a submenu) so that the submenu is not dismissed when clicking the parent item (defaults to false).")]
        public virtual bool IgnoreParentClicks
        {
            get
            {
                object obj = this.ViewState["IgnoreParentClicks"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["IgnoreParentClicks"] = value;
            }
        }

        /// <summary>
        /// The minimum width of the menu in pixels (defaults to 120).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(typeof(Unit), "120")]
        [NotifyParentProperty(true)]
        [Description("The minimum width of the menu in pixels (defaults to 120).")]
        public override Unit MinWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["MinWidth"], Unit.Pixel(120), "MinWidth");
            }
            set
            {
                this.ViewState["MinWidth"] = value;
            }
        }

        /// <summary>
        /// The maximum height of the menu. Only applies when enableScrolling is set to True (defaults to null).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The maximum height of the menu. Only applies when enableScrolling is set to True (defaults to null).")]
        public override Unit MaxHeight
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["MaxHeight"], Unit.Empty, "MaxHeight");
            }
            set
            {
                this.ViewState["MaxHeight"] = value;
            }
        }

        /// <summary>
        /// The amount to scroll the menu. Only applies when enableScrolling is set to True (defaults to 24).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("6. Menu")]
        [DefaultValue(24)]
        [NotifyParentProperty(true)]
        [Description("The amount to scroll the menu. Only applies when enableScrolling is set to True (defaults to 24).")]
        public virtual int ScrollIncrement
        {
            get
            {
                object obj = this.ViewState["ScrollIncrement"];
                return (obj == null) ? 24 : (int)obj;
            }
            set
            {
                this.ViewState["ScrollIncrement"] = value;
            }
        }

        /// <summary>
        /// True to show the icon separator. (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to show the icon separator. (defaults to true).")]
        public virtual bool ShowSeparator
        {
            get
            {
                object obj = this.ViewState["ShowSeparator"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ShowSeparator"] = value;
            }
        }

        /// <summary>
        /// True or \"sides\" for the default effect, \"frame\" for 4-way shadow, and \"drop\" for bottom-right shadow (defaults to \"sides\")
        /// </summary>
        [Meta]
        [ConfigOption(typeof(ShadowJsonConverter))]
        [Category("6. Menu")]
        [DefaultValue(ShadowMode.Sides)]
        [NotifyParentProperty(true)]
        [Description("True or \"sides\" for the default effect, \"frame\" for 4-way shadow, and \"drop\" for bottom-right shadow (defaults to \"sides\")")]
        public virtual ShadowMode Shadow
        {
            get
            {
                object obj = this.ViewState["Shadow"];
                return (obj == null) ? ShadowMode.Sides : (ShadowMode)obj;
            }
            set
            {
                this.ViewState["Shadow"] = value;
            }
        }

        /// <summary>
        /// The Ext.Element.alignTo anchor position value to use for submenus of this menu (defaults to \"tl-tr?\")
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The Ext.Element.alignTo anchor position value to use for submenus of this menu (defaults to \"tl-tr?\")")]
        public virtual string SubMenuAlign
        {
            get
            {
                return (string)this.ViewState["SubMenuAlign"] ?? "";
            }
            set
            {
                this.ViewState["SubMenuAlign"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("6. Menu")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool DisableMenuNavigation
        {
            get
            {
                object obj = this.ViewState["DisableMenuNavigation"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["DisableMenuNavigation"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Menu")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool RenderToForm
        {
            get
            {
                object obj = this.ViewState["RenderToForm"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["RenderToForm"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("keyNav", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string DisableMenuNavigationProxy
        {
            get
            {
                return this.DisableMenuNavigation ? "{disable:Ext.emptyFn}" : "";
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Hides this menu and optionally all parent menus
        /// </summary>
        /// <param name="deep">True to hide all parent menus recursively, if any</param>
        [Meta]
        [Description("Hides this menu and optionally all parent menus")]
        public virtual void Hide(bool deep)
        {
            this.Call("hide", deep);
        }

        /// <summary>
        /// Displays this menu relative to another element
        /// </summary>
        /// <param name="element">The element to align to</param>
        /// <param name="position">The Ext.Element.alignTo anchor position to use in aligning to the element</param>
        [Meta]
        [Description("Displays this menu relative to another element")]
        public virtual void Show(string element, string position)
        {
            this.Call("show", new JRawValue(element), position);
        }

        /// <summary>
        /// Displays this menu relative to another element
        /// </summary>
        /// <param name="element">The element to align to</param>
        [Meta]
        [Description("Displays this menu relative to another element")]
        public virtual void Show(string element)
        {
            this.Call("show", new JRawValue(element));
        }

        /// <summary>
        /// Displays this menu at a specific xy position
        /// </summary>
        /// <param name="x">Contains [x] value for the position at which to show the menu (coordinates are page-based)</param>
        /// <param name="y">Contains [y] value for the position at which to show the menu (coordinates are page-based)</param>
        [Meta]
        [Description("Displays this menu at a specific xy position")]
        public virtual void ShowAt(int x, int y)
        {
            this.Call("showAt", new int[] { x, y });
        }
    }
}