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
using System.Collections.Specialized;
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
    public abstract partial class ButtonBase : BoxComponentBase, IIcon, IAutoPostBack, IPostBackEventHandler, IXPostBackDataHandler, IButtonControl, INoneContentable
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ButtonBase() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ButtonBase(string text)
        {
            this.Text = text;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override string ContainerStyle
        {
            get
            {
                return Const.DisplayInline;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal override bool IsIdRequired
        {
            get
            {
                return true;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);
            
            if (this.OnClientClick.IsNotEmpty())
            {
                this.Handler = new JFunction(TokenUtils.ParseTokens(this.OnClientClick, this), "el", "e").ToScript();
            }

            string fn = this.PostBackFunction;

            if (this.ParentForm != null && fn.IsNotEmpty())
            {
                this.CustomConfig.Add(new ConfigItem("postback", JSON.Serialize(new { eventName = "click", fn = new JFunction(fn) }), ParameterMode.Raw));
            }

            if (this.StandOut)
            {
                if (this.Icon != Icon.None || this.IconCls.IsNotEmpty())
                {
                    this.Cls = (this.Text.IsEmpty() ? "x-btn-icon" : "x-btn-text-icon") + " x-btn-over";
                }
                else
                {
                    this.Cls = "x-btn-over";
                }
            }
        }

        /// <summary>
        /// True to use width:'auto', false to use fixed width (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxComponent")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("By default, if a width is not specified the button will attempt to stretch horizontally to fit its content. If the button is being managed by a width sizing layout (hbox, fit, anchor), set this to false to prevent the button from doing this automatic sizing. Defaults to <tt>undefined</tt>.")]
        public override bool AutoWidth
        {
            get
            {
                object obj = this.ViewState["AutoWidth"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AutoWidth"] = value;
            }
        }

        /// <summary>
        /// True to enable stand out by default (defaults to false).
        /// </summary>
        [Meta]
        [Category("5. Button")]
        [DefaultValue(false)]
        [Description("True to enable stand out by default (defaults to false).")]
        public virtual bool StandOut
        {
            get
            {
                object obj = this.ViewState["StandOut"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["StandOut"] = value;
            }
        }

        private static readonly object EventPressedChanged = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event EventHandler PressedChanged
        {
            add
            {
                this.Events.AddHandler(EventPressedChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventPressedChanged, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnPressedChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventPressedChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private bool hasLoadPostData = false;

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool HasLoadPostData
        {
            get
            {
                return this.hasLoadPostData;
            }
            set
            {
                this.hasLoadPostData = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        bool IXPostBackDataHandler.HasLoadPostData
        {
            get
            {
                return this.HasLoadPostData;
            }
            set
            {
                this.HasLoadPostData = value;
            }
        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            return this.LoadPostData(postDataKey, postCollection);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.ConfigID.ConcatWith("_Pressed")];

            if (val.IsNotEmpty())
            {
                bool pressedState;

                if (bool.TryParse(val.ToLowerInvariant(), out pressedState))
                {
                    if (this.Pressed != pressedState)
                    {
                        try
                        {
                            this.SuspendScripting();
                            this.Pressed = pressedState;
                        }
                        finally
                        {
                            this.ResumeScripting();
                        }

                        return true;
                    }
                }
            }

            return false; 
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            this.RaisePostDataChangedEvent();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void RaisePostDataChangedEvent()
        {
            this.OnPressedChanged(EventArgs.Empty);
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
        [Category("5. Button")]
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
        /// The JavaScript to execute when the Button is clicked. Or, please use the &lt;Listeners> for more flexibility.
        /// </summary>
        [Meta]
        [Category("5. Button")]
        [DefaultValue("")]
        [Description("The JavaScript to execute when the Button is clicked. Or, please use the &lt;Listeners> for more flexibility.")]
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
        /// False to not allow a pressed Button to be depressed (defaults to true). Only valid when enableToggle is true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(true)]
        [Description("False to not allow a pressed Button to be depressed (defaults to true). Only valid when enableToggle is true.")]
        public virtual bool AllowDepress
        {
            get
            {
                object obj = this.ViewState["AllowDepress"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AllowDepress"] = value;
            }
        }

        /// <summary>
        /// The side of the Button box to render the arrow if the button has an associated menu. Defaults to 'Right'.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Button")]
        [DefaultValue(ArrowAlign.Right)]
        [Description("The side of the Button box to render the arrow if the button has an associated menu. Defaults to 'Right'.")]
        public virtual ArrowAlign ArrowAlign
        {
            get
            {
                object obj = this.ViewState["ArrowAlign"];
                return (obj == null) ? ArrowAlign.Right : (ArrowAlign)obj;
            }
            set
            {
                this.ViewState["ArrowAlign"] = value;
            }
        }

        /// <summary>
        /// The type of event to map to the button's event handler (defaults to 'click').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue("click")]
        [Description("The type of event to map to the button's event handler (defaults to 'click').")]
        public virtual string ClickEvent
        {
            get
            {
                return (string)this.ViewState["ClickEvent"] ?? "click";
            }
            set
            {
                this.ViewState["ClickEvent"] = value;
            }
        }

        /// <summary>
        /// True to enable pressed/not pressed toggling (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(false)]
        [Description("True to enable pressed/not pressed toggling (defaults to false).")]
        public virtual bool EnableToggle
        {
            get
            {
                object obj = this.ViewState["EnableToggle"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["EnableToggle"] = value;
            }
        }

        /// <summary>
        /// True to apply a flat style.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(false)]
        [Description("True to apply a flat style.")]
        public virtual bool Flat
        {
            get
            {
                object obj = this.ViewState["Flat"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Flat"] = value;
            }
        }

        /// <summary>
        /// Buttons in the footer of a FormPanel may be configured with the option formBind: true. This causes the form's valid state monitor task to enable/disable those Buttons depending on the form's valid/invalid state.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(false)]
        [Description("Buttons in the footer of a FormPanel may be configured with the option formBind: true. This causes the form's valid state monitor task to enable/disable those Buttons depending on the form's valid/invalid state.")]
        public virtual bool FormBind
        {
            get
            {
                object obj = this.ViewState["FormBind"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["FormBind"] = value;
            }
        }

        /// <summary>
        /// False to disable visual cues on mouseover, mouseout and mousedown (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(true)]
        [Description("False to disable visual cues on mouseover, mouseout and mousedown (defaults to true).")]
        public virtual bool HandleMouseEvents
        {
            get
            {
                object obj = this.ViewState["HandleMouseEvents"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["HandleMouseEvents"] = value;
            }
        }

        /// <summary>
        /// A function called when the button is clicked (can be used instead of click event).
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetHandler")]
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Button")]
        [DefaultValue("")]
        [Description("A function called when the button is clicked (can be used instead of click event).")]
        public virtual string Handler
        {
            get
            {
                return (string)this.ViewState["Handler"] ?? "";
            }
            set
            {
                this.ViewState["Handler"] = value;
            }
        }

        /// <summary>
        /// The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [Category("5. Button")]
        [DefaultValue(Icon.None)]
        [DirectEventUpdate(MethodName = "SetIconClass")]
        [Description("The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.")]
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

        /// <summary>
        /// The side of the Button box to render the icon. Defaults to 'Left'.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Button")]
        [DefaultValue(IconAlign.Left)]
        [Description("The side of the Button box to render the icon. Defaults to 'Left'.")]
        public virtual IconAlign IconAlign
        {
            get
            {
                object obj = this.ViewState["IconAlign"];
                return (obj == null) ? IconAlign.Left : (IconAlign)obj;
            }
            set
            {
                this.ViewState["IconAlign"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("iconCls")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string IconClsProxy
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return ResourceManager.GetIconClassName(this.Icon);
                }

                return this.IconCls;
            }
        }

        /// <summary>
        /// A css class which sets a background image to be used as the icon for this button.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetIconClass")]
        [Category("5. Button")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class which sets a background image to be used as the icon for this button.")]
        public virtual string IconCls
        {
            get
            {
                return (string)this.ViewState["IconCls"] ?? "";
            }
            set
            {
                this.ViewState["IconCls"] = value;
            }
        }

        /// <summary>
        /// False to hide the Menu arrow drop down arrow (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "ToggleMenuArrow")]
        [Category("5. Button")]
        [DefaultValue(true)]
        [Description("False to hide the Menu arrow drop down arrow (defaults to true).")]
        public virtual bool MenuArrow
        {
            get
            {
                object obj = this.ViewState["MenuArrow"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["MenuArrow"] = value;
            }
        }

        private MenuCollection menu;

        /// <summary>
        /// Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob.
        /// </summary>
        [Meta]
        [ConfigOption("menu", typeof(ItemCollectionJsonConverter))]
        [Category("5. Button")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Standard menu attribute consisting of a reference to a menu object, a menu id or a menu config blob.")]
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
		/// 
		/// </summary>
		[Description("")]
        protected virtual void AfterItemAdd(MenuBase item)
        {
            if (!this.Controls.Contains(item))
            {
                this.Controls.Add(item);
            }

            if (!this.LazyItems.Contains(item))
            {
                this.LazyItems.Add(item);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void AfterItemRemove(MenuBase item)
        {
            if (this.Controls.Contains(item))
            {
                this.Controls.Remove(item);
            }

            if (this.LazyItems.Contains(item))
            {
                this.LazyItems.Remove(item);
            }
        }

        /// <summary>
        /// The position to align the menu to (see Ext.Element.alignTo for more details, defaults to 'tl-bl?').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue("tl-bl?")]
        [Description("The position to align the menu to (see Ext.Element.alignTo for more details, defaults to 'tl-bl?').")]
        public virtual string MenuAlign
        {
            get
            {
                return (string)this.ViewState["MenuAlign"] ?? "tl-bl?";
            }
            set
            {
                this.ViewState["MenuAlign"] = value;
            }
        }

        /// <summary>
        /// The minimum width for this button (used to give a set of buttons a common width).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(typeof(Unit), "16")]
        [Description("The minimum width for this button (used to give a set of buttons a common width).")]
        public override Unit MinWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["MinWidth"], Unit.Pixel(16), "MinWidth");
            }
            set
            {
                this.ViewState["MinWidth"] = value;
            }
        }

        /// <summary>
        /// If used in a Toolbar, the text to be used if this item is shown in the overflow menu.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("5. Button")]
        [DefaultValue("")]
        [Description("If used in a Toolbar, the text to be used if this item is shown in the overflow menu.")]
        public virtual string OverflowText 
        {
            get
            {
                return (string)this.ViewState["OverflowText"] ?? "";
            }
            set
            {
                this.ViewState["OverflowText"] = value;
            }
        }


        /// <summary>
        /// True to addToStart pressed (only if enableToggle = true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(false)]
        [Description("True to addToStart pressed (only if enableToggle = true).")]
        public virtual bool Pressed
        {
            get
            {
                object obj = this.ViewState["Pressed"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Pressed"] = value;
            }
        }

        /// <summary>
        /// True to repeat fire the click event while the mouse is down. (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue(false)]
        [Description("True to repeat fire the click event while the mouse is down. (defaults to false).")]
        public virtual bool Repeat
        {
            get
            {
                object obj = this.ViewState["Repeat"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Repeat"] = value;
            }
        }

        /// <summary>
        /// The scope of the handler.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Button")]
        [DefaultValue(null)]
        [Description("The scope of the handler.")]
        public virtual object Scope
        {
            get
            {
                object obj = this.ViewState["Scope"];
                return (obj == null) ? null : obj;
            }
            set
            {
                this.ViewState["Scope"] = value;
            }
        }

        /// <summary>
        /// The size of the Button. Defaults to 'Small'.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Button")]
        [DefaultValue(ButtonScale.Small)]
        [Description("The size of the Button. Defaults to 'Small'.")]
        public virtual ButtonScale Scale
        {
            get
            {
                object obj = this.ViewState["Scale"];
                return (obj == null) ? ButtonScale.Small : (ButtonScale)obj;
            }
            set
            {
                this.ViewState["Scale"] = value;
            }
        }

        /// <summary>
        /// Set a DOM tabIndex for this button (defaults to undefined).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Button")]
        [DefaultValue((short)0)]
        [Description("Set a DOM tabIndex for this button (defaults to undefined).")]
        public override short TabIndex
        {
            get
            {
                object obj = this.ViewState["TabIndex"];
                return (obj == null) ? (short)0 : (short)obj;
            }
            set
            {
                this.ViewState["TabIndex"] = value;
            }
        }

        /// <summary>
        /// The position to align the menu to (see Ext.Element.alignTo for more details, defaults to 'tl-bl?').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("5. Button")]
        [DefaultValue("")]
        [DirectEventUpdate(GenerateMode = AutoGeneratingScript.WithSet)]
        [Description("The position to align the menu to (see Ext.Element.alignTo for more details, defaults to 'tl-bl?').")]
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

        /// <summary>
        /// Function called when a Button with enableToggle set to true is clicked.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("5. Button")]
        [DefaultValue("")]
        [Description("Function called when a Button with enableToggle set to true is clicked.")]
        public virtual string ToggleHandler
        {
            get
            {
                return (string)this.ViewState["ToggleHandler"] ?? "";
            }
            set
            {
                this.ViewState["ToggleHandler"] = value;
            }
        }

        /// <summary>
        /// The group this toggle button is a member of (only 1 per group can be pressed, only applies if enableToggle = true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("5. Button")]
        [DefaultValue("")]
        [Description("The group this toggle button is a member of (only 1 per group can be pressed, only applies if enableToggle = true).")]
        public virtual string ToggleGroup
        {
            get
            {
                return (string)this.ViewState["ToggleGroup"] ?? "";
            }
            set
            {
                this.ViewState["ToggleGroup"] = value;
            }
        }

        /// <summary>
        /// The tooltip for the button - can be a string to be used as innerHTML (html tags are accepted). Or, see ToolTip config.
        /// </summary>
        [Meta]
        [ConfigOption("tooltip")]
        [DirectEventUpdate(MethodName = "SetTooltip")]
        [Localizable(true)]
        [Category("5. Button")]
        [DefaultValue("")]
        [ReadOnly(false)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The tooltip for the button - can be a string to be used as innerHTML (html tags are accepted). Or, see ToolTip config.")]
        public override string ToolTip
        {
            get
            {
                return (string)this.ViewState["ToolTip"] ?? "";
            }
            set
            {
                this.ViewState["ToolTip"] = value;
            }
        }

        private QTipCfg qTipCfg;

        /// <summary>
        /// A tip string.
        /// </summary>
        [ConfigOption("tooltip", JsonMode.Object)]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A tip string.")]
        public virtual QTipCfg QTipCfg
        {
            get
            {
                if (this.qTipCfg == null)
                {
                    this.qTipCfg = new QTipCfg();
                }
                return this.qTipCfg;
            }
        }

        /// <summary>
        /// The type of tooltip to use. Either 'qtip' (default) for QuickTips or 'title' for title attribute.
        /// </summary>
        [Meta]
        [ConfigOption("tooltipType")]
        [Localizable(true)]
        [Category("5. Button")]
        [DefaultValue(ToolTipType.Qtip)]
        [Description("The type of tooltip to use. Either 'qtip' (default) for QuickTips or 'title' for title attribute.")]
        public virtual ToolTipType ToolTipType
        {
            get
            {
                object obj = this.ViewState["ToolTipType"];
                return (obj == null) ? ToolTipType.Qtip : (ToolTipType)obj;
            }
            set
            {
                this.ViewState["ToolTipType"] = value;
            }
        }
         
        /// <summary>
        /// The tooltip for the button - can be a string or QuickTips config object.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Localizable(true)]
        [Category("5. Button")]
        [DefaultValue(ButtonType.Button)]
        [Description("submit, reset or button - defaults to 'button'.")]
        public virtual ButtonType Type
        {
            get
            {
                object obj = this.ViewState["Type"];
                return (obj == null) ? ButtonType.Button : (ButtonType)obj;
            }
            set
            {
                this.ViewState["Type"] = value;
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
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [Category("5. Button")]
        [DefaultValue("")]
        [DirectEventUpdate(GenerateMode = AutoGeneratingScript.Simple)]
        [Description("")]
        public virtual string NavigateUrl
        {
            get
            {
                return (string)this.ViewState["NavigateUrl"] ?? "";
            }
            set
            {
                this.ViewState["NavigateUrl"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("navigateUrl")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string NavigateUrlProxy
        {
            get
            {
                return this.ResolveUrlLink(this.NavigateUrl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [TypeConverter(typeof(TargetConverter))]
        [Category("5. Hyperlink")]
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetTarget")]
        [Description("")]
        public virtual string Target
        {
            get
            {
                return (string)this.ViewState["Target"] ?? "";
            }
            set
            {
                this.ViewState["Target"] = value;
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Focus the button
        /// </summary>
        [Meta]
        [Description("Focus the button")]
        public override void Focus()
        {
            base.Focus();
        }

        /// <summary>
        /// Hide this button's menu (if it has one)
        /// </summary>
        [Meta]
        [Description("Hide this button's menu (if it has one)")]
        public virtual void HideMenu()
        {
            this.Call("hideMenu");
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        [Meta]
        [Description("initComponent")]
        public virtual void InitComponent()
        {
            this.Call("initComponent");
        }

        /// <summary>
        /// Assigns this button's click handler
        /// </summary>
        [Description("Assigns this button's click handler")]
        protected virtual void SetHandler(string function)
        {
            this.Call("setHandler", new JRawValue(function));
        }

        /// <summary>
        /// Assigns this button's click handler
        /// </summary>
        [Description("Assigns this button's click handler")]
        public virtual void SetHandler(string function, string scope)
        {
            this.Call("setHandler", new JRawValue(function), new JRawValue(scope));
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        [Description("Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.")]
        protected virtual void SetIconClass(string cls)
        {
            this.Call("setIconClass", cls);
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        protected virtual void SetIconClass(Icon icon)
        {
            if (this.Icon != Icon.None)
            {
                this.SetIconClass(ResourceManager.GetIconClassName(icon));
            }
            else
            {
                this.SetIconClass("");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetTarget(string target)
        {
            this.Call("setTarget", target);
        }

        /// <summary>
        /// Sets this button's text
        /// </summary>
        [Description("Sets this button's text")]
        protected virtual void SetText(string text)
        {
            this.Call("setText", text);
        }

        /// <summary>
        /// Sets the tooltip for this Button.
        /// </summary>
        [Description("Sets the tooltip for this Button.")]
        protected virtual void SetTooltip(string tooltip)
        {
            this.Call("setTooltip", tooltip);
        }

        /// <summary>
        /// Sets the tooltip for this Button.
        /// </summary>
        [Description("Sets the tooltip for this Button.")]
        public virtual void SetTooltip(QTipCfg config)
        {
            this.Call("setTooltip", new JRawValue(new ClientConfig().Serialize(config, true)));
        }


        /// <summary>
        /// Show this button's menu (if it has one)
        /// </summary>
        [Meta]
        [Description("Show this button's menu (if it has one)")]
        public virtual void ShowMenu()
        {
            this.Call("showMenu");
        }

        /// <summary>
        /// If a state it passed, it becomes the pressed state otherwise the current state is toggled.
        /// </summary>
        [Meta]
        [Description("If a state it passed, it becomes the pressed state otherwise the current state is toggled.")]
        public virtual void Toggle()
        {
            this.Call("toggle");
        }

        /// <summary>
        /// If a state it passed, it becomes the pressed state otherwise the current state is toggled.
        /// </summary>
        [Meta]
        [Description("If a state it passed, it becomes the pressed state otherwise the current state is toggled.")]
        public virtual void Toggle(bool state)
        {
            this.Call("toggle", state);
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

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void ShowMenuArrow()
        {
            this.Call("showMenuArrow");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void HideMenuArrow()
        {
            this.Call("hideMenuArrow");
        }

        /// <summary>
        /// If a state it passed, it becomes the pressed state otherwise the current state is toggled.
        /// </summary>
        [Meta]
        [Description("If a state it passed, it becomes the pressed state otherwise the current state is toggled.")]
        public virtual void ToggleMenuArrow()
        {
            this.Call("toggleMenuArrow");
        }

        /// <summary>
        /// If a state it passed, it becomes the pressed state otherwise the current state is toggled.
        /// </summary>
        [Meta]
        [Description("If a state it passed, it becomes the pressed state otherwise the current state is toggled.")]
        public virtual void ToggleMenuArrow(bool state)
        {
            if (state)
            {
                this.ShowMenuArrow();
            }
            else
            {
                this.HideMenuArrow();
            }
        }
    }
}