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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
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
    public abstract partial class MenuItemBase : BaseMenuItem, IIcon, IAutoPostBack, IPostBackEventHandler, IButtonControl
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void OnBeforeClientInitHandler()
        {
            base.OnBeforeClientInitHandler();

            if (this.OnClientClick.IsNotEmpty())
            {
                this.On("click", new JFunction(TokenUtils.ParseTokens(this.OnClientClick, this), "el", "e"));
            }

            string fn = this.PostBackFunction;

            if (this.ParentForm != null && fn.IsNotEmpty())
            {
                this.On("click", new JFunction(fn));
            }
        }

        /*  PostBack
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [UrlProperty("*.aspx")]
        [Editor("System.Web.UI.Design.UrlEditor", typeof(UITypeEditor))]
        [Description("")]
        public virtual string PostBackUrl
        {
            get
            {
                return (string)this.ViewState["PostBackUrl"] ?? "";
            }
            set
            {
                this.ViewState["PostBackUrl"] = value;
            }
        }


        /*  EventClick
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventClick = new object();

        /// <summary>
        /// Fires when the button has been clicked
        /// </summary>
        [Category("Action")]
        [Description("Fires when the button has been clicked")]
        public event EventHandler Click
        {
            add
            {
                this.Events.AddHandler(EventClick, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventClick, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnClick(EventArgs e)
        {
            EventHandler handler = (EventHandler)this.Events[EventClick];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgument"></param>
        [Description("")]
        protected virtual void RaisePostBackEvent(string eventArgument)
        {
            if (this.CausesValidation)
            {
                this.Page.Validate(this.ValidationGroup);
            }
            this.OnClick(EventArgs.Empty);
            this.OnCommand(new CommandEventArgs(this.CommandName, this.CommandArgument));
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            this.RaisePostBackEvent(eventArgument);
        }


        /*  EventCommand
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventCommand = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event CommandEventHandler Command
        {
            add
            {
                base.Events.AddHandler(EventCommand, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventCommand, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnCommand(CommandEventArgs e)
        {
            CommandEventHandler handler = (CommandEventHandler)base.Events[EventCommand];

            if (handler != null)
            {
                handler(this, e);
            }
            base.RaiseBubbleEvent(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [Description("")]
        public string CommandName
        {
            get
            {
                string str = (string)this.ViewState["CommandName"];

                if (str != null)
                {
                    return str;
                }

                return "";
            }
            set
            {
                this.ViewState["CommandName"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [Description("")]
        public string CommandArgument
        {
            get
            {
                string str = (string)this.ViewState["CommandArgument"];

                if (str != null)
                {
                    return str;
                }

                return "";
            }
            set
            {
                this.ViewState["CommandArgument"] = value;
            }
        }

        /// <summary>
        /// The JavaScript to execute when the item is clicked. Or, please use the &lt;Listeners> for more flexibility.
        /// </summary>
        [Meta]
        [Category("5. Item")]
        [DefaultValue("")]
        [Description("The JavaScript to execute when the item is clicked. Or, please use the &lt;Listeners> for more flexibility.")]
        public virtual string OnClientClick
        {
            get
            {
                return (string)this.ViewState["OnClientClick"] ?? "";
            }
            set
            {
                this.ViewState["OnClientClick"] = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control state automatically posts back to the server when button clicked.
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating whether the control state automatically posts back to the server when button clicked.")]
        public virtual bool AutoPostBack
        {
            get
            {
                object obj = this.ViewState["AutoPostBack"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoPostBack"] = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.")]
        public virtual bool CausesValidation
        {
            get
            {
                object obj = this.ViewState["CausesValidation"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["CausesValidation"] = value;
            }
        }

        /// <summary>
        /// Gets or Sets the Controls ValidationGroup
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue("")]
        [Description("Gets or Sets the Controls ValidationGroup")]
        public virtual string ValidationGroup
        {
            get
            {
                return (string)this.ViewState["ValidationGroup"] ?? "";
            }
            set
            {
                this.ViewState["ValidationGroup"] = value;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public MenuBase ParentMenu
        {
            get
            {
                return (MenuBase)ReflectionUtils.GetTypeOfParent(this, typeof(MenuBase));
            }
        }

        internal Desktop ParentDesktop
        {
            get
            {
                return (Desktop)ReflectionUtils.GetTypeOfParent(this, typeof(Desktop));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// True if this item can be visually activated (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Item")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True if this item can be visually activated (defaults to true).")]
        public override bool CanActivate
        {
            get
            {
                object obj = this.ViewState["CanActivate"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["CanActivate"] = value;
            }
        }

        /// <summary>
        /// The href attribute to use for the underlying anchor link (defaults to '#').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Item")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The href attribute to use for the underlying anchor link (defaults to '#').")]
        public virtual string Href
        {
            get
            {
                return (string)this.ViewState["Href"] ?? "";
            }
            set
            {
                this.ViewState["Href"] = value;
            }
        }

        /// <summary>
        /// The target attribute to use for the underlying anchor link (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Item")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The target attribute to use for the underlying anchor link (defaults to '').")]
        public virtual string HrefTarget
        {
            get
            {
                return (string)this.ViewState["HrefTarget"] ?? "";
            }
            set
            {
                this.ViewState["HrefTarget"] = value;
            }
        }

        /// <summary>
        /// The path to an icon to display in this item (defaults to Ext.BLANK_IMAGE_URL). If icon is specified iconCls should not be.
        /// </summary>
        [Meta]
        [Category("5. Item")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The path to an icon to display in this item (defaults to Ext.BLANK_IMAGE_URL). If icon is specified iconCls should not be.")]
        public virtual string IconUrl
        {
            get
            {
                return (string)this.ViewState["IconUrl"] ?? "";
            }
            set
            {
                this.ViewState["IconUrl"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("icon")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string IconUrlProxy
        {
            get
            {
                return this.ResolveUrlLink(this.IconUrl);
            }
        }

        /// <summary>
        /// A CSS class that specifies a background image that will be used as the icon for this item (defaults to ''). If iconCls is specified icon should not be.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Item")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(Script = "{0}.setIconClass({1});")]
        [Description("A CSS class that specifies a background image that will be used as the icon for this item (defaults to ''). If iconCls is specified icon should not be.")]
        public virtual string IconCls
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return "icon-{0}".FormatWith(this.Icon.ToString().ToLower());
                }

                return (string)this.ViewState["IconCls"] ?? "";
            }
            set
            {
                this.ViewState["IconCls"] = value;
            }
        }

        /// <summary>
        /// The default CSS class to use for menu items (defaults to 'x-menu-item')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Item")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The default CSS class to use for menu items (defaults to 'x-menu-item')")]
        public override string ItemCls
        {
            get
            {
                return (string)this.ViewState["ItemCls"] ?? "";
            }
            set
            {
                this.ViewState["ItemCls"] = value;
            }
        }

        /// <summary>
        /// Length of time in milliseconds to wait before showing this item (defaults to 200)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Item")]
        [DefaultValue(200)]
        [NotifyParentProperty(true)]
        [Description("Length of time in milliseconds to wait before showing this item (defaults to 200)")]
        public virtual int ShowDelay
        {
            get
            {
                object obj = this.ViewState["ShowDelay"];
                return (obj == null) ? 200 : (int)obj;
            }
            set
            {
                this.ViewState["ShowDelay"] = value;
            }
        }

        /// <summary>
        /// The text to display in this item (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Item")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(GenerateMode = AutoGeneratingScript.WithSet)]
        [Description("The text to display in this item (defaults to '').")]
        public virtual string Text
        {
            get
            {
                return (string)this.ViewState["Text"] ?? "";
            }
            set
            {
                this.ViewState["Text"] = value;
            }
        }

        private MenuCollection menu;

        /// <summary>
        /// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob
        /// </summary>
        [Meta]
        [ConfigOption("menu", typeof(ItemCollectionJsonConverter))]
        [Category("5. Item")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob")]
        public virtual MenuCollection Menu
        {
            get
            {
                if (this.menu == null)
                {
                    this.menu = new MenuCollection();
                    this.menu.AfterItemAdd += this.AfterItemAdd;
                    this.menu.AfterItemRemove += this.AfterItemRemove;
                }

                return this.menu;
            }
        }

        /// <summary>
        /// The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [Category("5. Item")]
        [DefaultValue(Icon.None)]
        [Description("The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.")]
        public virtual Icon Icon
        {
            get
            {
                object obj = this.ViewState["Icon"];
                return (obj == null) ? Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["Icon"] = value;
            }
        }

        List<Icon> IIcon.Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>(1);
                icons.Add(this.Icon);
                return icons;
            }
        }
    }
}