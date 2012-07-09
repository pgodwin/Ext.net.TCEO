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
using System.Web.UI.WebControls;

using Ext.Net.Utilities;
using Icon16x16 = Ext.Net.Icon;
using System.Web;

namespace Ext.Net
{
    [ToolboxItem(false)]
    [Description("A config object containing any or all of the following properties. If this object is not specified the status will be cleared using the defaults.")]
    public partial class MessageBoxConfig : ExtObject
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToScript()
        {
            return new ClientConfig().Serialize(this);
        }

        string title = "";

        /// <summary>
        /// The title text
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The title text")]
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

        string animEl = "";

        /// <summary>
        /// An id or Element from which the message box should animate as it opens and closes (defaults to undefined)
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An id or Element from which the message box should animate as it opens and closes (defaults to undefined)")]
        public virtual string AnimEl
        {
            get
            {
                return this.animEl;
            }
            set
            {
                this.animEl = value;
            }
        }

        private MessageBox.Button buttons = MessageBox.Button.NONE;

        /// <summary>
        /// A buttons kind, or NONE to not show any buttons (defaults to NONE)
        /// </summary>
        [DefaultValue(MessageBox.Button.NONE)]
        [NotifyParentProperty(true)]
        [Description("A buttons kind, or NONE to not show any buttons (defaults to NONE)")]
        public virtual MessageBox.Button Buttons
        {
            get
            {
                return this.buttons;
            }
            set
            {
                this.buttons = value;
            }
        }

        private MessageBoxButtonsConfig buttonsConfig = null;

        /// <summary>
        /// A buttons kind, or NONE to not show any buttons (defaults to NONE)
        /// </summary>
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("A buttons kind, or NONE to not show any buttons (defaults to NONE)")]
        public virtual MessageBoxButtonsConfig MessageBoxButtonsConfig
        {
            get
            {
                return this.buttonsConfig;
            }
            set
            {
                this.buttonsConfig = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("buttons", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string ButtonsProxy
        {
            get
            {
                if (this.Buttons == MessageBox.Button.NONE)
                {
                    return "false";
                }

                if (this.MessageBoxButtonsConfig != null)
                {
                    return this.MessageBoxButtonsConfig.ToScript();
                }

                return "Ext.Msg.".ConcatWith(this.Buttons.ToString());
            }
        }

        private bool closable = true;

        /// <summary>
        /// False to hide the top-right close button (defaults to true). Note that progress and wait dialogs will ignore this property and always hide the close button as they can only be closed programmatically.
        /// </summary>
        [DefaultValue(true)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("False to hide the top-right close button (defaults to true). Note that progress and wait dialogs will ignore this property and always hide the close button as they can only be closed programmatically.")]
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

        string cls = "";

        /// <summary>
        /// A custom CSS class to apply to the message box's container element
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A custom CSS class to apply to the message box's container element")]
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

        private Unit multilineHeight = Unit.Pixel(0);

        /// <summary>
        /// The height in pixels to create the textbox
        /// </summary>
        [ConfigOption("multiline")]
        [DefaultValue(typeof(Unit), "0")]
        [Description("The height in pixels to create the textbox")]
        public virtual Unit MultilineHeight
        {
            get
            {
                return this.multilineHeight;
            }
            set
            {
                this.multilineHeight = value;
            }
        }

        string handler = "";

        /// <summary>
        /// A callback function which is called when the dialog is dismissed either by clicking on the configured buttons, or on the dialog close button, or by pressing the return button to enter input.
        /// Progress and wait dialogs will ignore this option since they do not respond to user actions and can only be closed programmatically, so any required function should be called by the same code after it closes the dialog. Parameters passed:
        ///     buttonId : String
        ///         The ID of the button pressed, one of:
        ///             ok
        ///             yes
        ///             no
        ///             cancel
        ///     text : String
        ///         Value of the input field if either prompt or multiline is true
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A callback function which is called when the dialog is dismissed either by clicking on the configured buttons, or on the dialog close button, or by pressing the return button to enter input.")]
        public virtual string Handler
        {
            get
            {
                return this.handler;
            }
            set
            {
                this.handler = value;
            }
        }

        private JFunction fn = null;

        /// <summary>
        /// A callback function which is called when the dialog is dismissed either by clicking on the configured buttons, or on the dialog close button, or by pressing the return button to enter input.
        /// Progress and wait dialogs will ignore this option since they do not respond to user actions and can only be closed programmatically, so any required function should be called by the same code after it closes the dialog. Parameters passed:
        ///     buttonId : String
        ///         The ID of the button pressed, one of:
        ///             ok
        ///             yes
        ///             no
        ///             cancel
        ///     text : String
        ///         Value of the input field if either prompt or multiline is true
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A callback function which is called when the dialog is dismissed either by clicking on the configured buttons, or on the dialog close button, or by pressing the return button to enter input.")]
        public JFunction Fn
        {
            get
            {
                return this.fn;
            }
            set
            {
                this.fn = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("fn", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string FnProxy
        {
            get
            {
                if (this.MessageBoxButtonsConfig != null)
                {
                    this.Fn = this.MessageBoxButtonsConfig.Fn;
                }

                if (this.Handler.IsNotEmpty())
                {
                    return new JFunction(handler, "buttonId", "text").ToScript();
                }

                if (this.Fn == null || this.Fn.IsDefault)
                {
                    return "";
                }

                return this.Fn.ToScript();
            }
        }

        string scope = "";

        /// <summary>
        /// The scope of the callback function
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The scope of the callback function")]
        public virtual string Scope
        {
            get
            {
                return this.scope;
            }
            set
            {
                this.scope = value;
            }
        }

        private MessageBox.Icon icon = MessageBox.Icon.NONE;

        /// <summary>
        /// A CSS class that provides a background image to be used as the body icon for the dialog (e.g. Ext.MessageBox.WARNING or 'custom-class') (defaults to '')
        /// </summary>
        [DefaultValue(MessageBox.Icon.NONE)]
        [NotifyParentProperty(true)]
        [Description("A CSS class that provides a background image to be used as the body icon for the dialog (e.g. Ext.MessageBox.WARNING or 'custom-class') (defaults to '')")]
        public virtual MessageBox.Icon Icon
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

        string iconCls = "";

        /// <summary>
        /// A CSS class that provides a background image
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class that provides a background image")]
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

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("icon", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string IconProxy
        {
            get
            {
                if (this.Icon != MessageBox.Icon.NONE)
                {
                    return "Ext.Msg.".ConcatWith(this.Icon.ToString());
                }

                if (this.IconCls.IsNotEmpty())
                {
                    return JSON.Serialize(this.IconCls);
                }

                return "";
            }
        }

        private Icon16x16 headerIcon = Icon16x16.None;

        /// <summary>
        /// The standard Ext.Window.iconCls to add an optional header icon (defaults to '')
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(Icon16x16.None)]
        [Description("The standard Ext.Window.iconCls to add an optional header icon (defaults to '')")]
        public virtual Icon16x16 HeaderIcon
        {
            get
            {
                return this.headerIcon;
            }
            set
            {
                this.headerIcon = value;
            }
        }

        private string headerIconCls = "";

        /// <summary>
        /// The standard Ext.Window.iconCls to add an optional header icon (defaults to '')
        /// </summary>
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The standard Ext.Window.iconCls to add an optional header icon (defaults to '')")]
        public virtual string HeaderIconCls
        {
            get
            {
                return this.headerIconCls;
            }
            set
            {
                this.headerIconCls = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("iconCls")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string HeaderIconClsProxy
        {
            get
            {
                if (this.HeaderIcon != Icon16x16.None)
                {
                    if (!RequestManager.IsAjaxRequest && HttpContext.Current != null)
                    {
                        ResourceManager sm = ResourceManager.GetInstance(HttpContext.Current);

                        if (sm != null)
                        {
                            sm.RegisterIcon(this.HeaderIcon);
                        }
                    }

                    return ResourceManager.GetIconClassName(this.HeaderIcon);
                }

                return this.HeaderIconCls;
            }
        }

        private Unit maxWidth = Unit.Pixel(600);

        /// <summary>
        /// The maximum width in pixels of the message box (defaults to 600)
        /// </summary>
        [ConfigOption]
        [DefaultValue(typeof(Unit), "600")]
        [Description("The maximum width in pixels of the message box (defaults to 600)")]
        public virtual Unit MaxWidth
        {
            get
            {
                return this.maxWidth;
            }
            set
            {
                this.maxWidth = value;
            }
        }

        private Unit minWidth = Unit.Pixel(100);

        /// <summary>
        /// The minimum width in pixels of the message box (defaults to 100)
        /// </summary>
        [ConfigOption]
        [DefaultValue(typeof(Unit), "100")]
        [Description("The minimum width in pixels of the message box (defaults to 100)")]
        public virtual Unit MinWidth
        {
            get
            {
                return this.minWidth;
            }
            set
            {
                this.minWidth = value;
            }
        }

        private bool modal = true;

        /// <summary>
        /// False to allow user interaction with the page while the message box is displayed (defaults to true)
        /// </summary>
        [DefaultValue(true)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("False to allow user interaction with the page while the message box is displayed (defaults to true)")]
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

        private string msg = "";

        /// <summary>
        /// A string that will replace the existing message box body text (defaults to the XHTML-compliant non-breaking space character '&#160;')
        /// </summary>
        [ConfigOption("msg")]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A string that will replace the existing message box body text (defaults to the XHTML-compliant non-breaking space character '&#160;')")]
        public virtual string Message
        {
            get
            {
                return this.msg;
            }
            set
            {
                this.msg = value;
            }
        }

        private bool multiline = false;

        /// <summary>
        /// True to prompt the user to enter multi-line text (defaults to false)
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("True to prompt the user to enter multi-line text (defaults to false)")]
        public virtual bool Multiline
        {
            get
            {
                return this.multiline;
            }
            set
            {
                this.multiline = value;
            }
        }

        private bool progress = false;

        /// <summary>
        /// True to display a progress bar (defaults to false)
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("True to display a progress bar (defaults to false)")]
        public virtual bool Progress
        {
            get
            {
                return this.progress;
            }
            set
            {
                this.progress = value;
            }
        }

        private string progressText = "";

        /// <summary>
        /// The text to display inside the progress bar if progress = true (defaults to '')
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The text to display inside the progress bar if progress = true (defaults to '')")]
        public virtual string ProgressText
        {
            get
            {
                return this.progressText;
            }
            set
            {
                this.progressText = value;
            }
        }

        private bool prompt = false;

        /// <summary>
        /// True to prompt the user to enter single-line text (defaults to false)
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("True to prompt the user to enter single-line text (defaults to false)")]
        public virtual bool Prompt
        {
            get
            {
                return this.prompt;
            }
            set
            {
                this.prompt = value;
            }
        }

        private bool proxyDrag = false;

        /// <summary>
        /// True to display a lightweight proxy while dragging (defaults to false)
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("True to display a lightweight proxy while dragging (defaults to false)")]
        public virtual bool ProxyDrag
        {
            get
            {
                return this.proxyDrag;
            }
            set
            {
                this.proxyDrag = value;
            }
        }

        private string value = "";

        /// <summary>
        /// The string value to set into the active textbox element if displayed
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The string value to set into the active textbox element if displayed")]
        public virtual string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        private bool wait = false;

        /// <summary>
        /// True to display a progress bar (defaults to false)
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("True to display a progress bar (defaults to false)")]
        public virtual bool Wait
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

        private WaitConfig waitConfig = new WaitConfig();

        /// <summary>
        /// A WaitConfig object (applies only if Wait = true)
        /// </summary>
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("A Ext.ProgressBar.waitConfig object (applies only if wait = true)")]
        public WaitConfig WaitConfig
        {
            get
            {
                return this.waitConfig;
            }
            set
            {
                this.waitConfig = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("waitConfig", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string WaitConfigProxy
        {
            get
            {
                if (this.WaitConfig == null)
                {
                    return "";
                }

                string cfg = this.WaitConfig.ToJsonString();

                if (cfg.IsEmpty() || cfg.Equals("{}"))
                {
                    return "";
                }

                return cfg;
            }
        }

        private Unit width = Unit.Pixel(0);

        /// <summary>
        /// The width of the dialog in pixels
        /// </summary>
        [ConfigOption]
        [DefaultValue(typeof(Unit), "0")]
        [Description("The width of the dialog in pixels")]
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
    }
}