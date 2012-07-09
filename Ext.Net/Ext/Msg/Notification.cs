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
    [Description("")]
    public partial class Notification : ScriptClass
    {
        /*  IScriptable
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.net.Notification";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override string ToScript()
        {
            if (this.currentConfig != null && this.currentConfig.Icon != Icon.None)
            {
                if (ResourceManager.HasResourceManager)
                {
                    ResourceManager.GetInstance().RegisterIcon(this.currentConfig.Icon);
                }
            }

            return this.currentConfig != null ? this.InstanceOf.ConcatWith(".show(", TokenUtils.ParseTokens(this.currentConfig.ToScript(), this.Page), ");") : "";
        }


        /*  Configure
            -----------------------------------------------------------------------------------------------*/

        private NotificationConfig currentConfig;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        [Description("")]
        public virtual Notification Configure(NotificationConfig config)
        {
            this.currentConfig = config;

            return this;
        }


        /*  Show
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual Notification Show()
        {
            this.Render();

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        [Description("")]
        public static Notification Show(NotificationConfig config)
        {
            return new Notification().Configure(config).Show();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum ShowMode
    {
        /// <summary>
        /// 
        /// </summary>
        Grid,
        /// <summary>
        /// 
        /// </summary>
        Stack
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class NotificationAlignConfig : ExtObject
    {
        private string el = "";

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("el", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected string ElProxy
        {
            get
            {
                if (this.El.IsEmpty())
                {
                    return "";
                }

                return "Ext.net.getEl(".ConcatWith(TokenUtils.ParseAndNormalize(this.El), ")");
            }
        }

        /// <summary>
        /// Align element (default is document)
        /// </summary>
        [DefaultValue("")]
        [Description("Align element (default is document)")]
        public virtual string El
        {
            get
            {
                return this.el;
            }
            set
            {
                this.el = value;
            }
        }

        private AnchorPoint elementAnchor = AnchorPoint.BottomRight;

        /// <summary>
        /// Element anchor point
        /// </summary>
        [DefaultValue(AnchorPoint.BottomRight)]
        [Description("Element anchor point")]
        public AnchorPoint ElementAnchor
        {
            get
            {
                return this.elementAnchor;
            }
            set
            {
                this.elementAnchor = value;
            }
        }

        private AnchorPoint targetAnchor = AnchorPoint.BottomRight;

        /// <summary>
        /// Target anchor point
        /// </summary>
        [DefaultValue(AnchorPoint.BottomRight)]
        [Description("Target anchor point")]
        public AnchorPoint TargetAnchor
        {
            get
            {
                return this.targetAnchor;
            }
            set
            {
                this.targetAnchor = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("position")]
        [DefaultValue("")]
        protected string AnchorsProxy
        {
            get
            {
                return Fx.AnchorConvert(this.ElementAnchor)
                            .ConcatWith("-")
                            .ConcatWith(Fx.AnchorConvert(this.TargetAnchor));
            }
        }

        private int offsetX = -20;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public int OffsetX
        {
            get
            {
                return this.offsetX;
            }
            set
            {
                this.offsetX = value;
            }
        }

        private int offsetY = -20;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public int OffsetY
        {
            get
            {
                return this.offsetY;
            }
            set
            {
                this.offsetY = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("offset", JsonMode.Raw)]
        [DefaultValue("")]
        protected string OffsetProxy
        {
            get
            {
                if (this.OffsetX == -20 && this.OffsetY == -20)
                {
                    return "";
                }

                return "[".ConcatWith(this.OffsetX, ",", this.OffsetY, "]");
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class NotificationConfig : ExtObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string ToScript()
        {
            return new ClientConfig().Serialize(this);
        }

        private string id = "";

        /// <summary>
        /// ID of instance
        /// </summary>
        [ConfigOption("id")]
        [Category("NotificationConfig Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("ID of instance")]
        public virtual string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        private string cls = "";

        /// <summary>
        /// An optional extra CSS class that will be added to this component's Element (defaults to ''). This can be useful for adding customized styles to the component or any of its children using standard CSS rules.
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An optional extra CSS class that will be added to this component's Element (defaults to ''). This can be useful for adding customized styles to the component or any of its children using standard CSS rules.")]
        public virtual string Cls
        {
            get
            {
                return this.cls;
            }
            set
            {
                this.cls = value;
            }
        }

        private string ctCls = "";

        /// <summary>
        /// An optional extra CSS class that will be added to this component's container. This can be useful for adding customized styles to the container or any of its children using standard CSS rules.
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An optional extra CSS class that will be added to this component's container. This can be useful for adding customized styles to the container or any of its children using standard CSS rules.")]
        public virtual string CtCls
        {
            get
            {
                return this.ctCls;
            }
            set
            {
                this.ctCls = value;
            }
        }

        private string title = "";

        /// <summary>
        /// The title text to display in the window header
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The title text to display in the window header")]
        public virtual string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        private string html = "";

        /// <summary>
        /// The title text to display in the window header
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An HTML fragment to use as the panel's body content.")]
        public virtual string Html
        {
            get
            {
                return this.html;
            }
            set
            {
                this.html = value;
            }
        }

        private string contentEl = "";

        /// <summary>
        /// The id of an existing HTML node to use as the panel's body content
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The id of an existing HTML node to use as the panel's body content")]
        public virtual string ContentEl
        {
            get
            {
                return this.contentEl;
            }
            set
            {
                this.contentEl = value;
            }
        }

        private Unit width = Unit.Pixel(200);

        /// <summary>
        /// The width of this notification in pixels (defaults to 200).
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue(typeof(Unit), "200")]
        [NotifyParentProperty(true)]
        [Description("The width of this notification in pixels (defaults to 200).")]
        public virtual Unit Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        private Unit height = Unit.Pixel(100);

        /// <summary>
        /// The height of this notification in pixels (defaults to 100).
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue(typeof(Unit), "100")]
        [NotifyParentProperty(true)]
        [Description("The height of this notification in pixels (defaults to 100).")]
        public virtual Unit Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        private bool autoHide = true;

        /// <summary>
        /// False to stay visible after showing
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to stay visible after showing")]
        public virtual bool AutoHide
        {
            get
            {
                return this.autoHide;
            }
            set
            {
                this.autoHide = value;
            }
        }

        private bool autoScroll = false;

        /// <summary>
        /// True to show scrolling bar if required
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to show scrolling bar if required")]
        public virtual bool AutoScroll
        {
            get
            {
                return this.autoScroll;
            }
            set
            {
                this.autoScroll = value;
            }
        }

        private bool closable = true;

        /// <summary>
        /// False to hide the button and disallow closing the window
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to hide the button and disallow closing the window")]
        public virtual bool Closable
        {
            get
            {
                return this.closable;
            }
            set
            {
                this.closable = value;
            }
        }

        private bool shadow = false;

        /// <summary>
        /// True to show a shadow
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to show a shadow")]
        public virtual bool Shadow
        {
            get
            {
                return this.shadow;
            }
            set
            {
                this.shadow = value;
            }
        }


        private bool plain = false;

        /// <summary>
        /// False to add a lighter background color to visually highlight the body element and separate it more distinctly from the surrounding frame
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("False to add a lighter background color to visually highlight the body element and separate it more distinctly from the surrounding frame")]
        public virtual bool Plain
        {
            get
            {
                return this.plain;
            }
            set
            {
                this.plain = value;
            }
        }

        private bool resizable = false;

        /// <summary>
        /// True to allow user resizing at each edge and corner of the window, false to disable resizing 
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to allow user resizing at each edge and corner of the window, false to disable resizing ")]
        public virtual bool Resizable
        {
            get
            {
                return this.resizable;
            }
            set
            {
                this.resizable = value;
            }
        }

        private bool draggable = false;

        /// <summary>
        /// True to allow the window to be dragged by the header bar 
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to allow the window to be dragged by the header bar")]
        public virtual bool Draggable
        {
            get
            {
                return this.draggable;
            }
            set
            {
                this.draggable = value;
            }
        }

        private string bodyStyle = "";

        /// <summary>
        /// Custom CSS styles to be applied to the body element  
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Custom CSS styles to be applied to the body element")]
        public virtual string BodyStyle
        {
            get
            {
                return this.bodyStyle;
            }
            set
            {
                this.bodyStyle = value;
            }
        }

        private NotificationAlignConfig alignConfig;

        /// <summary>
        /// Align config object 
        /// </summary>
        [ConfigOption("alignToCfg", JsonMode.Object)]
        [Category("NotificationConfig Options")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("Align config object")]
        public virtual NotificationAlignConfig AlignCfg
        {
            get
            {
                return this.alignConfig;
            }
            set
            {
                this.alignConfig = value;
            }
        }

        private ShowMode showMode = ShowMode.Grid;

        /// <summary>
        /// Determines how the Notification Windows will be shown in relation to each other if more than one rendered to the viewport at a single time. 
        /// Options include "Grid" which will show each individual separately in a matrix and new Notification Windows will be shown in the best available 
        /// empty hole within the grid. Best available is considered bottom-right.
        /// If ShowMode.Stack, the Notification Windows will be stacked on top of each other hiding the Window below.
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue(ShowMode.Grid)]
        [NotifyParentProperty(true)]
        [Description("False to show a notification upon all other visible notofications")]
        public virtual ShowMode ShowMode
        {
            get
            {
                return this.showMode;
            }
            set
            {
                this.showMode = value;
            }
        }

        private bool closeVisible = false;

        /// <summary>
        /// True to close all other visible notifications
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to close all other visible notifications")]
        public virtual bool CloseVisible
        {
            get
            {
                return this.closeVisible;
            }
            set
            {
                this.closeVisible = value;
            }
        }

        private bool modal = false;

        /// <summary>
        /// True to make the window modal and mask everything behind it when displayed, false to display it without restricting access to other UI elements (defaults to false).
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to make the window modal and mask everything behind it when displayed, false to display it without restricting access to other UI elements (defaults to false).")]
        public virtual bool Modal
        {
            get
            {
                return this.modal;
            }
            set
            {
                this.modal = value;
            }
        }

        private string pinEvent = "none";

        /// <summary>
        /// Stop hidding event, 'none' if hidding can not be stoped
        /// </summary>
        [Category("NotificationConfig Options")]
        [DefaultValue("none")]
        [NotifyParentProperty(true)]
        [Description("Stop hidding event, 'none' if hidding can not be stopped")]
        public virtual string PinEvent
        {
            get
            {
                return this.pinEvent;
            }
            set
            {
                this.pinEvent = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("pinEvent")]
        [DefaultValue("none")]
        [Description("")]
        protected virtual string PinEventProxy
        {
            get
            {
                return this.PinEvent.ToLower();
            }
        }

        private int hideDelay = 2500;

        /// <summary>
        /// Hide delay in ms
        /// </summary>
        [ConfigOption]
        [Category("NotificationConfig Options")]
        [DefaultValue(2500)]
        [NotifyParentProperty(true)]
        [Description("Hide delay in ms")]
        public virtual int HideDelay
        {
            get
            {
                return this.hideDelay;
            }
            set
            {
                this.hideDelay = value;
            }
        }

        private ConfigItemCollection customConfig;

        /// <summary>
        /// Collection of custom js config
        /// </summary>
        [ConfigOption("-", typeof(CustomConfigJsonConverter))]
        [Description("Collection of custom js config")]
        public virtual ConfigItemCollection CustomConfig
        {
            get
            {
                if (this.customConfig == null)
                {
                    this.customConfig = new ConfigItemCollection();
                }

                return this.customConfig;
            }
            set
            {
                this.customConfig = value;
            }
        }

        private Fx showFx;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Object)]
        [Category("NotificationConfig Options")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual Fx ShowFx
        {
            get
            {
                return this.showFx;
            }
            set
            {
                this.showFx = value;
            }
        }

        private Fx hideFx;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Object)]
        [Category("NotificationConfig Options")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual Fx HideFx
        {
            get
            {
                return this.hideFx;
            }
            set
            {
                this.hideFx = value;
            }
        }

        private Icon icon = Icon.None;

        /// <summary>
        /// The icon to use in the header. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Category("NotificationConfig Options")]
        [DefaultValue(Icon.None)]
        [Description("The icon to use in the header. See also, IconCls to set an icon with a custom Css class.")]
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

        private string iconCls = "";

        /// <summary>
        /// A css class which sets a background image to be used as the icon in the header.
        /// </summary>
        [Category("NotificationConfig Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class which sets a background image to be used as the icon in the header.")]
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

        private LoadConfig autoLoad;

        /// <summary>
        /// A valid url spec according to the UpdateOptions Ext.UpdateOptions.update method. If autoLoad is not null, the panel will attempt to load its contents immediately upon render. The URL will become the default URL for this panel's body element, so it may be refreshed at any time.
        /// </summary>
        [Category("NotificationConfig Options")]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A valid url spec according to the UpdateOptions Ext.UpdateOptions.update method. If autoLoad is not null, the panel will attempt to load its contents immediately upon render. The URL will become the default URL for this panel's body element, so it may be refreshed at any time.")]
        public virtual LoadConfig AutoLoad
        {
            get
            {
                if (this.autoLoad == null)
                {
                    this.autoLoad = new LoadConfig();
                }

                return this.autoLoad;
            }
            set
            {
                this.autoLoad = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("autoLoad", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected string AutoLoadProxy
        {
            get
            {
                if (this.AutoLoad != null && !this.AutoLoad.IsDefault)
                {
                    return new ClientConfig().Serialize(this.AutoLoad);
                }

                return "";
            }
        }

        private WindowListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [ConfigOption("listeners", JsonMode.Object)]
        [Description("Client-side JavaScript Event Handlers")]
        public WindowListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new WindowListeners();
                }

                return this.listeners;
            }
            set
            {
                this.listeners = value;
            }
        }

        private ToolsCollection tools;

        /// <summary>
        /// An array of tool button configs to be added to the header tool area. When rendered, each tool is stored as an Element referenced by a public property called tools.
        /// </summary>
        [ConfigOption(JsonMode.AlwaysArray)]
        [Category("NotificationConfig Options")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An array of tool button configs to be added to the header tool area. When rendered, each tool is stored as an Element referenced by a public property called tools.")]
        public virtual ToolsCollection Tools
        {
            get
            {
                if (this.tools == null)
                {
                    this.tools = new ToolsCollection();
                }

                return this.tools;
            }
            set
            {
                this.tools = value;
            }
        }

        private bool showPin = false;

        /// <summary>
        /// True to show pin tool button.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to show pin tool button.")]
        public virtual bool ShowPin
        {
            get
            {
                return this.showPin;
            }
            set
            {
                this.showPin = value;
            }
        }

        private bool pinned = false;

        /// <summary>
        /// True to show pin tool button.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to to show window as pinned.")]
        public virtual bool Pinned
        {
            get
            {
                return this.pinned;
            }
            set
            {
                this.pinned = value;
            }
        }

        private bool bringToFront = false;

        /// <summary>
        /// True to show pin tool button.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to show window as pinned.")]
        public virtual bool BringToFront
        {
            get
            {
                return this.bringToFront;
            }
            set
            {
                this.bringToFront = value;
            }
        }
    }
}