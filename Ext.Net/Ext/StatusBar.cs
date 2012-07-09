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
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Basic status bar component that can be used as the bottom toolbar of any Ext.Panel.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:StatusBar runat=\"server\"><Items></Items></{0}:StatusBar>")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(StatusBar), "Build.ToolboxIcons.StatusBar.bmp")]
    [Description("Basic status bar component that can be used as the bottom toolbar of any Ext.Panel.")]
    public partial class StatusBar : ToolbarBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public StatusBar() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            this.RegisterStatusIcon(this.DefaultIcon);
            this.RegisterStatusIcon(this.BusyIcon);
            this.RegisterStatusIcon(this.Icon);
        }

        private void RegisterStatusIcon(Icon icon)
        {
            if (icon != Icon.None)
            {
                this.ResourceManager.RegisterClientStyleBlock(icon.ToString() + "-sbar", this.GetIconClass(icon));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        [Description("")]
        public static string GetIconClassName(Icon icon)
        {
            return (icon != Icon.None) ? string.Format("icon-{0}-sbar", icon.ToString().ToLower()) : "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="icon"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string GetIconClass(Icon icon)
        {
            if (icon != Icon.None)
            {
                return string.Format(".{0}{{background-image:url({1}) !important;padding-left: 25px !important;background-repeat: no-repeat;background-position: 3px 3px;}}", ResourceManager.GetIconClassName(icon), this.ResourceManager.GetIconUrl(icon));
            }
            return "";
        }

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

                baseList.Add(new ClientStyleItem(typeof(StatusBar), "Ext.Net.Build.Ext.Net.ux.extensions.statusbar.css.statusbar-embedded.css", "/ux/extensions/statusbar/css/statusbar.css"));
                baseList.Add(new ClientScriptItem(typeof(StatusBar), "Ext.Net.Build.Ext.Net.ux.extensions.statusbar.statusbar.js", "/ux/extensions/statusbar/statusbar.js"));

                return baseList;
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
                return "statusbar";
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
                return "Ext.ux.StatusBar";
            }
        }
        
        /// <summary>
        /// The number of milliseconds to wait after setting the status via setStatus before automatically clearing the status text and icon (defaults to 5000). Note that this only applies when passing the clear argument to setStatus since that is the only way to defer clearing the status. This can be overridden by specifying a different wait value in setStatus. Calls to clearStatus always clear the status bar immediately and ignore this value.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. StatusBar")]
        [DefaultValue(5000)]
        [NotifyParentProperty(true)]
        [Description("The number of milliseconds to wait after setting the status via setStatus before automatically clearing the status text and icon (defaults to 5000). Note that this only applies when passing the clear argument to setStatus since that is the only way to defer clearing the status. This can be overridden by specifying a different wait value in setStatus. Calls to clearStatus always clear the status bar immediately and ignore this value.")]
        public virtual int AutoClear
        {
            get
            {
                object obj = this.ViewState["AutoClear"];
                return (obj == null) ? 5000 : (int)obj;
            }
            set
            {
                this.ViewState["AutoClear"] = value;
            }
        }

        /// <summary>
        /// The default Icon applied when calling showBusy (defaults to 'Icon.None'). It can be overridden at any time by passing the iconCls argument into showBusy. See the Icon or IconCls docs for additional details about customizing the icon.
        /// </summary>
        [Meta]
        [Category("7. StatusBar")]
        [DefaultValue(Icon.None)]
        [Description("The default Icon applied when calling showBusy (defaults to 'Icon.None'). It can be overridden at any time by passing the iconCls argument into showBusy. See the Icon or IconCls docs for additional details about customizing the icon.")]
        public virtual Icon BusyIcon
        {
            get
            {
                object obj = this.ViewState["BusyIcon"];
                return (obj == null) ? Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["BusyIcon"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("busyIconCls")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string BusyIconClsProxy
        {
            get
            {
                if (this.BusyIcon != Icon.None)
                {
                    return ResourceManager.GetIconClassName(this.BusyIcon);
                }

                return (!this.BusyIconCls.Equals("x-status-busy")) ? this.BusyIconCls : "";
            }
        }

        /// <summary>
        /// The default iconCls applied when calling showBusy (defaults to 'x-status-busy'). It can be overridden at any time by passing the iconCls argument into showBusy. See the iconCls docs for additional details about customizing the icon.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. StatusBar")]
        [DefaultValue("x-status-busy")]
        [NotifyParentProperty(true)]
        [Description("The default iconCls applied when calling showBusy (defaults to 'x-status-busy'). It can be overridden at any time by passing the iconCls argument into showBusy. See the iconCls docs for additional details about customizing the icon.")]
        public virtual string BusyIconCls
        {
            get
            {
                return (string)this.ViewState["BusyIconCls"] ?? "x-status-busy";
            }
            set
            {
                this.ViewState["BusyIconCls"] = value;
            }
        }

        /// <summary>
        /// The default text applied when calling showBusy (defaults to 'Loading...'). It can be overridden at any time by passing the text argument into showBusy.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. StatusBar")]
        [DefaultValue("Loading...")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("The default text applied when calling showBusy (defaults to 'Loading...'). It can be overridden at any time by passing the text argument into showBusy.")]
        public virtual string BusyText
        {
            get
            {
                return (string)this.ViewState["BusyText"] ?? "Loading...";
            }
            set
            {
                this.ViewState["BusyText"] = value;
            }
        }

        /// <summary>
        /// The base class applied to the containing element for this component on render (defaults to 'x-statusbar')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. StatusBar")]
        [DefaultValue("x-statusbar")]
        [NotifyParentProperty(true)]
        [Description("The base class applied to the containing element for this component on render (defaults to 'x-statusbar')")]
        public override string Cls
        {
            get
            {
                return (string)this.ViewState["Cls"] ?? "x-statusbar";
            }
            set
            {
                this.ViewState["Cls"] = value;
            }
        }

        /// <summary>
        /// The default Icon (see the Icon or IconCls docs for additional details about customizing the icon). This will be used anytime the status bar is cleared with the useDefaults:true option (defaults to 'Icon.None').
        /// </summary>
        [Meta]
        [Category("7. StatusBar")]
        [DefaultValue(Icon.None)]
        [Description("The default Icon (see the Icon or IconCls docs for additional details about customizing the icon). This will be used anytime the status bar is cleared with the useDefaults:true option (defaults to 'Icon.None').")]
        public virtual Icon DefaultIcon
        {
            get
            {
                object obj = this.ViewState["DefaultIcon"];
                return (obj == null) ? Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["DefaultIcon"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("defaultIconCls")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string DefaultIconClsProxy
        {
            get
            {
                if (this.DefaultIcon != Icon.None)
                {
                    return ResourceManager.GetIconClassName(this.DefaultIcon);
                }

                return this.DefaultIconCls;
            }
        }

        /// <summary>
        /// The default iconCls value (see the iconCls docs for additional details about customizing the icon). This will be used anytime the status bar is cleared with the useDefaults:true option (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. StatusBar")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The default iconCls value (see the iconCls docs for additional details about customizing the icon). This will be used anytime the status bar is cleared with the useDefaults:true option (defaults to '').")]
        public virtual string DefaultIconCls
        {
            get
            {
                return (string)this.ViewState["DefaultIconCls"] ?? "";
            }
            set
            {
                this.ViewState["DefaultIconCls"] = value;
            }
        }

        /// <summary>
        /// The default text value. This will be used anytime the status bar is cleared with the useDefaults:true option (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. StatusBar")]
        [Localizable(true)]
        [DefaultValue("&nbsp;")]
        [NotifyParentProperty(true)]
        [Description("The default text value. This will be used anytime the status bar is cleared with the useDefaults:true option (defaults to '').")]
        public virtual string DefaultText
        {
            get
            {
                return (string)this.ViewState["DefaultText"] ?? "&nbsp;";
            }
            set
            {
                this.ViewState["DefaultText"] = value;
            }
        }

        /// <summary>
        /// An Icon that will be applied to the status element and is expected to provide a background image that will serve as the status bar icon (defaults to 'Icon.None'). The Icons is applied directly to the div that also contains the status text, so the rule should provide the appropriate padding on the div to make room for the image.
        /// </summary>
        [Meta]
        [Category("7. StatusBar")]
        [DefaultValue(Icon.None)]
        [DirectEventUpdate(MethodName="SetIcon")]
        [Description("An Icon that will be applied to the status element and is expected to provide a background image that will serve as the status bar icon (defaults to 'Icon.None'). The Icons is applied directly to the div that also contains the status text, so the rule should provide the appropriate padding on the div to make room for the image.")]
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
        /// A CSS class that will be applied to the status element and is expected to provide a background image that will serve as the status bar icon (defaults to ''). The class is applied directly to the div that also contains the status text, so the rule should provide the appropriate padding on the div to make room for the image.
        /// </summary>
        [Meta]
        [Category("7. StatusBar")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetIconClass")]
        [Description("A CSS class that will be applied to the status element and is expected to provide a background image that will serve as the status bar icon (defaults to ''). The class is applied directly to the div that also contains the status text, so the rule should provide the appropriate padding on the div to make room for the image.")]
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
        /// The alignment of the status element within the overall StatusBar layout. When the StatusBar is rendered, it creates an internal div containing the status text and icon. Any additional Toolbar items added in the StatusBar's items config, or added via add or any of the supported add* methods, will be rendered, in added order, to the opposite side. The status element is greedy, so it will automatically expand to take up all sapce left over by any other items.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("7. StatusBar")]
        [DefaultValue(StatusAlign.Left)]
        [NotifyParentProperty(true)]
        [Description("The alignment of the status element within the overall StatusBar layout. When the StatusBar is rendered, it creates an internal div containing the status text and icon. Any additional Toolbar items added in the StatusBar's items config, or added via add or any of the supported add* methods, will be rendered, in added order, to the opposite side. The status element is greedy, so it will automatically expand to take up all sapce left over by any other items.")]
        public virtual StatusAlign StatusAlign
        {
            get
            {
                object obj = this.ViewState["StatusAlign"];
                return (obj == null) ? StatusAlign.Left : (StatusAlign)obj;
            }
            set
            {
                this.ViewState["StatusAlign"] = value;
            }
        }

        /// <summary>
        /// A string that will be rendered into the status element as the status message (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. StatusBar")]
        [DefaultValue("")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SetText")]
        [Description("A string that will be rendered into the status element as the status message (defaults to '').")]
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


        /*  Listeners and DirectEvents
            -----------------------------------------------------------------------------------------------*/

        private ToolbarListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public ToolbarListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ToolbarListeners();
                }

                return this.listeners;
            }
        }

        private StatusBarDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public StatusBarDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new StatusBarDirectEvents();
                }

                return this.directEvents;
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Clears the status text and iconCls. Also supports clearing via an optional fade out animation.
        /// </summary>
        [Meta]
        [Description("Clears the status text and iconCls. Also supports clearing via an optional fade out animation.")]
        public virtual void ClearStatus()
        {
            this.Call("clearStatus");
        }

        /// <summary>
        /// Clears the status text and iconCls. Also supports clearing via an optional fade out animation.
        /// </summary>
        [Meta]
        [Description("Clears the status text and iconCls. Also supports clearing via an optional fade out animation.")]
        public virtual void ClearStatus(StatusBarClearStatusConfig config)
        {
            this.Call("clearStatus", new JRawValue(config.ToJsonString()));
        }

        /// <summary>
        /// Convenience method for setting the status icon directly. For more flexible options see setStatus. See Icon or IconCls for complete details about customizing the icon. If empty string any iconCls will be cleared. 
        /// </summary>
        [Description("Convenience method for setting the status icon directly. For more flexible options see setStatus. See Icon or IconCls for complete details about customizing the icon. If empty string any iconCls will be cleared.")]
        protected virtual void SetIcon(Icon icon)
        {
            this.SetIconClass(ResourceManager.GetIconClassName(icon));
        }

        /// <summary>
        /// Convenience method for setting the status icon directly. For more flexible options see setStatus. See Icon or IconCls for complete details about customizing the icon. If empty string any iconCls will be cleared. 
        /// </summary>
        [Description("Convenience method for setting the status icon directly. For more flexible options see setStatus. See Icon or IconCls for complete details about customizing the icon. If empty string any iconCls will be cleared.")]
        protected virtual void SetIconClass(string iconCls)
        {
            this.Call("setIcon", iconCls);
        }

        /// <summary>
        /// Sets the status text and/or iconCls. Also supports automatically clearing the status that was set after a specified interval.
        /// </summary>
        [Meta]
        [Description("Sets the status text and/or iconCls. Also supports automatically clearing the status that was set after a specified interval.")]
        public virtual void SetStatus(string text)
        {
            this.Call("setStatus", text);
        }

        /// <summary>
        /// Sets the status text and/or iconCls. Also supports automatically clearing the status that was set after a specified interval.
        /// </summary>
        [Meta]
        [Description("Sets the status text and/or iconCls. Also supports automatically clearing the status that was set after a specified interval.")]
        public virtual void SetStatus(StatusBarStatusConfig config)
        {
            this.Call("setStatus", new JRawValue(config.Serialize()));
        }

        /// <summary>
        /// Convenience method for setting the status text directly. For more flexible options see setStatus.
        /// </summary>
        [Description("Convenience method for setting the status text directly. For more flexible options see setStatus.")]
        protected virtual void SetText(string text)
        {
            this.Call("setText", text);
        }

        /// <summary>
        /// Convenience method for setting the status text directly. For more flexible options see setStatus.
        /// </summary>
        /// <param name="text">A string to use as the status text (in which case all other options for setStatus will be defaulted)</param>
        [Meta]
        [Description("Convenience method for setting the status text and icon to special values that are pre-configured to indicate a 'busy' state, usually for loading or processing activities.")]
        public virtual void ShowBusy(string text)
        {
            this.Call("showBusy", text);
        }
    }

    /// <summary>
    /// A config object containing any or all of the following properties. If this object is not specified the status will be cleared using the defaults.
    /// </summary>
    [ToolboxItem(false)]
    [Description("A config object containing any or all of the following properties. If this object is not specified the status will be cleared using the defaults.")]
    public partial class StatusBarStatusConfig : XControl
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public StatusBarStatusConfig() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        [Description("")]
        public StatusBarStatusConfig(string text) 
        {
            this.Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="iconCls"></param>
        [Description("")]
        public StatusBarStatusConfig(string text, string iconCls)
        {
            this.Text = text;
            this.IconCls = iconCls;

            if (iconCls == null || iconCls.Trim().IsEmpty())
            {
                this.ClearIcon = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="icon"></param>
        [Description("")]
        public StatusBarStatusConfig(string text, Icon icon)
        {
            this.Text = text;
            this.Icon = icon;

            if (icon == Icon.None)
            {
                this.ClearIcon = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="config"></param>
        [Description("")]
        public StatusBarStatusConfig(string text, StatusBarClearConfig config)
        {
            this.Text = text;
            this.Clear = config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string Serialize()
        {
            return new ClientConfig().Serialize(this);
        }

        string text = "";

        /// <summary>
        /// The status text to display. If not specified, any current status text will remain unchanged.
        /// </summary>
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetText")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The status text to display. If not specified, any current status text will remain unchanged.")]
        public virtual string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }

        Icon icon = Icon.None;

        /// <summary>
        /// An Icon that will be applied to the status element and is expected to provide a background image that will serve as the status bar icon (defaults to 'Icon.None'). The Icons is applied directly to the div that also contains the status text, so the rule should provide the appropriate padding on the div to make room for the image.
        /// </summary>
        [DefaultValue("")]
        [DirectEventUpdate(MethodName = "SetIcon")]
        [NotifyParentProperty(true)]
        [Description("The status text to display. If not specified, any current status text will remain unchanged.")]
        public virtual Icon Icon
        {
            get
            {
                return this.icon;
            }
            set
            {
                this.icon = value;
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

        string iconCls = "";

        /// <summary>
        /// The CSS class used to customize the status icon (see iconCls for details). If not specified, any current iconCls will remain unchanged.
        /// </summary>
        [DefaultValue("")]
        [Description("The CSS class used to customize the status icon (see iconCls for details). If not specified, any current iconCls will remain unchanged.")]
        public virtual string IconCls
        {
            get
            {
                return this.iconCls;
            }
            set
            {
                this.iconCls = value;
            }
        }

        bool clearIcon = false;

        /// <summary>
        /// True to clear icon
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to clear icon")]
        public virtual bool ClearIcon
        {
            get
            {
                return this.clearIcon;
            }
            set
            {
                this.clearIcon = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("clear", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected virtual string ClearProxy
        {
            get
            {
                if (this.Clear != null)
                {
                    return this.Clear.ToJsonString();
                }

                if (this.Clear2)
                {
                    return JSON.Serialize(this.Clear2);
                }

                if (this.Clear3 != -1)
                {
                    return JSON.Serialize(this.Clear3);
                }

                return "";
            }
        }

        StatusBarClearConfig clear = null;

        /// <summary>
        /// Allows you to set an internal callback that will automatically clear the status text and iconCls after a specified amount of time has passed. If clear is not specified, the new status will not be auto-cleared and will stay until updated again or cleared using clearStatus.
        /// </summary>
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("Allows you to set an internal callback that will automatically clear the status text and iconCls after a specified amount of time has passed. If clear is not specified, the new status will not be auto-cleared and will stay until updated again or cleared using clearStatus.")]
        public virtual StatusBarClearConfig Clear
        {
            get
            {
                return this.clear;
            }
            set
            {
                this.clear = value;
            }
        }

        bool clearBoolean = false;

        /// <summary>
        /// If true is passed, the status will be cleared using autoClear, defaultText and defaultIconCls via a fade out animation.
        /// </summary>
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If true is passed, the status will be cleared using autoClear, defaultText and defaultIconCls via a fade out animation.")]
        public virtual bool Clear2
        {
            get
            {
                return this.clearBoolean;
            }
            set
            {
                this.clearBoolean = value;
            }
        }

        int clearInt = -1;

        /// <summary>
        /// If a numeric value is passed, it will be used as the callback interval (in milliseconds), overriding the autoClear value.
        /// </summary>
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [Description("If a numeric value is passed, it will be used as the callback interval (in milliseconds), overriding the autoClear value.")]
        public virtual int Clear3
        {
            get
            {
                return this.clearInt;
            }
            set
            {
                this.clearInt = value;
            }
        }
    }

    /// <summary>
    /// A config object containing any or all of the following properties. If this object is not specified the status will be cleared using the defaults.
    /// </summary>
    [ToolboxItem(false)]
    [Description("A config object containing any or all of the following properties. If this object is not specified the status will be cleared using the defaults.")]
    public partial class StatusBarClearStatusConfig : XControl
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public StatusBarClearStatusConfig() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anim"></param>
        [Description("")]
        public StatusBarClearStatusConfig(bool anim)
        {
            this.Anim = anim;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anim"></param>
        /// <param name="useDefaults"></param>
        [Description("")]
        public StatusBarClearStatusConfig(bool anim, bool useDefaults) 
        {
            this.Anim = anim;
            this.UseDefaults = useDefaults;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string ToJsonString()
        {
            return new ClientConfig().Serialize(this);
        }

        bool anim = false;

        /// <summary>
        /// True to clear the status by fading out the status element (defaults to false which clears immediately)
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to clear the status by fading out the status element (defaults to false which clears immediately)")]
        public virtual bool Anim
        {
            get
            {
                return this.anim;
            }
            set
            {
                this.anim = value;
            }
        }

        bool useDefaults = false;

        /// <summary>
        /// True to reset the text and icon using defaultText and defaultIconCls (defaults to false which sets the text to '' and removes any existing icon class).
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to reset the text and icon using defaultText and defaultIconCls (defaults to false which sets the text to '' and removes any existing icon class).")]
        public virtual bool UseDefaults
        {
            get
            {
                return this.useDefaults;
            }
            set
            {
                this.useDefaults = value;
            }
        }
    }

    /// <summary>
    /// A config object containing any or all of the following properties. If this object is not specified the status will be cleared using the defaults.
    /// </summary>
    [ToolboxItem(false)]
    [Description("A config object containing any or all of the following properties. If this object is not specified the status will be cleared using the defaults.")]
    public partial class StatusBarClearConfig : ExtObject
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public StatusBarClearConfig() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anim"></param>
        [Description("")]
        public StatusBarClearConfig(bool anim) 
        {
            this.Anim = anim;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anim"></param>
        /// <param name="useDefaults"></param>
        [Description("")]
        public StatusBarClearConfig(bool anim, bool useDefaults)
        {
            this.Anim = anim;
            this.UseDefaults = useDefaults;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anim"></param>
        /// <param name="useDefaults"></param>
        /// <param name="wait"></param>
        [Description("")]
        public StatusBarClearConfig(bool anim, bool useDefaults, int wait)
        {
            this.Anim = anim;
            this.UseDefaults = useDefaults;
            this.Wait = wait;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string ToJsonString()
        {
            return (!this.IsDefault) ? new ClientConfig().Serialize(this) : "";
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual bool IsDefault
        {
            get
            {
                return (this.Wait == -1 && !this.Anim && this.UseDefaults);
            }
        }

        bool anim = false;

        /// <summary>
        /// False to clear the status immediately once the callback executes (defaults to true which fades the status out).
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("False to clear the status immediately once the callback executes (defaults to true which fades the status out).")]
        public virtual bool Anim 
        {
            get
            {
                return this.anim;
            }
            set
            {
                this.anim = value;
            }
        }

        bool useDefaults = true;

        /// <summary>
        /// False to completely clear the status text and iconCls (defaults to true which uses defaultText and defaultIconCls).
        /// </summary>
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to completely clear the status text and iconCls (defaults to true which uses defaultText and defaultIconCls).")]
        public virtual bool UseDefaults
        {
            get
            {
                return this.useDefaults;
            }
            set
            {
                this.useDefaults = value;
            }
        }

        int wait = -1;

        /// <summary>
        /// The number of milliseconds to wait before clearing (defaults to autoClear).
        /// </summary>
        [ConfigOption]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [Description("The number of milliseconds to wait before clearing (defaults to autoClear).")]
        public virtual int Wait
        {
            get
            {
                return this.wait;
            }
            set
            {
                this.wait = value;
            }
        }
    }
}