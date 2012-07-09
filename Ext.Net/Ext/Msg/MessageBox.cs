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
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public partial class MessageBox : ScriptClass
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
                return "Ext.Msg";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToScript()
        {
            return this.currentConfig != null ? this.InstanceOf.ConcatWith(".show(", TokenUtils.ParseTokens(this.currentConfig.ToScript(), this.Page), ");") : "";
        }


        /*  Configure
            -----------------------------------------------------------------------------------------------*/

        private MessageBoxConfig currentConfig;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual MessageBox Configure(MessageBoxConfig config)
        {
            this.currentConfig = config;

            return this;
        }


        /*  Show
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Show()
        {
            this.Render();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Show(MessageBoxConfig config)
        {
            this.Configure(config).Show();
        }


        /*  Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Hides the message box if it is displayed
        /// </summary>
        [Description("Hides the message box if it is displayed")]
        public void Hide()
        {
            this.Call("hide");
        }


        /// <summary>
        /// Adds the specified icon to the dialog. By default, the class 'ext-mb-icon' is applied for default styling, and the class passed in is expected to supply the background image url. Pass in empty string ('') to clear any existing icon.
        /// </summary>
        /// <param name="icon">A CSS classname specifying the icon's background image url, or empty string to clear the icon</param>
        [Description("Adds the specified icon to the dialog. By default, the class 'ext-mb-icon' is applied for default styling, and the class passed in is expected to supply the background image url. Pass in empty string ('') to clear any existing icon.")]
        public void SetIcon(string icon)
        {
            this.Call("setIcon", icon);
        }


        /// <summary>
        /// Adds the specified icon to the dialog. By default, the class 'ext-mb-icon' is applied for default styling, and the class passed in is expected to supply the background image url. Pass in empty string ('') to clear any existing icon.
        /// </summary>
        /// <param name="icon">A CSS classname specifying the icon's background image url, or empty string to clear the icon</param>
        [Description("Adds the specified icon to the dialog. By default, the class 'ext-mb-icon' is applied for default styling, and the class passed in is expected to supply the background image url. Pass in empty string ('') to clear any existing icon.")]
        public void SetIcon(Icon icon)
        {
            this.Call("setIcon", "Ext.MessageBox.{0}".FormatWith(icon.ToString()));
        }


        /// <summary>
        /// Updates a progress-style message box's text and progress bar. Only relevant on message boxes initiated via Ext.MessageBox.progress or Ext.MessageBox.wait, or by calling Ext.MessageBox.show with progress: true.
        /// </summary>
        /// <param name="value">Any number between 0 and 1 (e.g., .5, defaults to 0)</param>
        /// <param name="progressText">The progress text to display inside the progress bar (defaults to '')</param>
        /// <param name="msg">The message box's body text is replaced with the specified string (defaults to undefined so that any existing body text will not get overwritten by default unless a new value is passed in)</param>
        [Description("Updates a progress-style message box's text and progress bar. Only relevant on message boxes initiated via Ext.MessageBox.progress or Ext.MessageBox.wait, or by calling Ext.MessageBox.show with progress: true.")]
        public void UpdateProgress(float value, string progressText, string msg)
        {
            this.Call("updateProgress", value, progressText, msg);
        }

        /// <summary>
        /// Updates a progress-style message box's text and progress bar. Only relevant on message boxes initiated via Ext.MessageBox.progress or Ext.MessageBox.wait, or by calling Ext.MessageBox.show with progress: true.
        /// </summary>
        /// <param name="value">Any number between 0 and 1 (e.g., .5, defaults to 0)</param>
        /// <param name="progressText">The progress text to display inside the progress bar (defaults to '')</param>
        [Description("Updates a progress-style message box's text and progress bar. Only relevant on message boxes initiated via Ext.MessageBox.progress or Ext.MessageBox.wait, or by calling Ext.MessageBox.show with progress: true.")]
        public void UpdateProgress(float value, string progressText)
        {
            this.Call("updateProgress", value, progressText);
        }


        /// <summary>
        /// Updates the message box body text
        /// </summary>
        [Description("Updates the message box body text")]
        public void UpdateText()
        {
            this.Call("updateText");
        }

        /// <summary>
        /// Updates the message box body text
        /// </summary>
        /// <param name="text">(optional) Replaces the message box element's innerHTML with the specified string (defaults to the XHTML-compliant non-breaking space character '&#160;')</param>
        [Description("Updates the message box body text")]
        public void UpdateText(string text)
        {
            this.Call("updateText", text);
        }


        /*  Properties
            -----------------------------------------------------------------------------------------------*/

        private MessageBoxButtonTextConfig buttonText;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual MessageBoxButtonTextConfig ButtonText
        {
            get
            {
                if (this.buttonText == null)
                {
                    this.buttonText = new MessageBoxButtonTextConfig(this);
                }

                return this.buttonText;
            }
        }

        private Unit defaultTextHeight = Unit.Pixel(75);

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue(typeof(Unit), "75")]
        [Description("The default height in pixels of the message box's multiline textarea if displayed (defaults to 75)")]
        public virtual Unit DefaultTextHeight
        {
            get
            {
                return this.defaultTextHeight;
            }
            set
            {
                this.defaultTextHeight = value;
                this.Set("defaultTextHeight", value.Value);
            }
        }

        private Unit maxWidth = Unit.Pixel(600);

		/// <summary>
		/// 
		/// </summary>
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
                this.Set("maxWidth", value.Value);
            }
        }

        private Unit minProgressWidth = Unit.Pixel(250);

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue(typeof(Unit), "250")]
        [Description("The minimum width in pixels of the message box if it is a progress-style dialog. This is useful for setting a different minimum width than text-only dialogs may need (defaults to 250)")]
        public virtual Unit MinProgressWidth
        {
            get
            {
                return this.minProgressWidth;
            }
            set
            {
                this.minProgressWidth = value;
                this.Set("minProgressWidth", value.Value);
            }
        }

        private Unit minWidth = Unit.Pixel(100);

		/// <summary>
		/// 
		/// </summary>
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
                this.Set("minWidth", value.Value);
            }
        }

        /*  Enums
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public enum Button
        {
            /// <summary>
            /// 
            /// </summary>
            NONE,

            /// <summary>
            /// 
            /// </summary>
            CANCEL,

            /// <summary>
            /// 
            /// </summary>
            OK,

            /// <summary>
            /// 
            /// </summary>
            OKCANCEL,

            /// <summary>
            /// 
            /// </summary>
            YESNO,

            /// <summary>
            /// 
            /// </summary>
            YESNOCANCEL
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public enum Icon
        {
            /// <summary>
            /// 
            /// </summary>
            NONE,

            /// <summary>
            /// 
            /// </summary>
            ERROR,

            /// <summary>
            /// 
            /// </summary>
            INFO,

            /// <summary>
            /// 
            /// </summary>
            QUESTION,

            /// <summary>
            /// 
            /// </summary>
            WARNING
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class MessageBoxButtonsConfig : ExtObject
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToScript()
        {
            JsonObject config = new JsonObject();

            if (this.Ok != null)
            {
                config.Add("ok", this.Ok.Text);
            }

            if (this.Cancel != null)
            {
                config.Add("cancel", this.Cancel.Text);
            }

            if (this.Yes != null)
            {
                config.Add("yes", this.Yes.Text);
            }

            if (this.No != null)
            {
                config.Add("no", this.No.Text);
            }

            return config.Count > 0 ? config.ToJsonString() : "";
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool HasHandlers
        {
            get
            {
                return (this.Ok != null && this.Ok.Handler.IsNotEmpty()) ||
                    (this.Cancel != null && this.Cancel.Handler.IsNotEmpty()) ||
                    (this.Yes != null && this.Yes.Handler.IsNotEmpty()) ||
                    (this.No != null && this.No.Handler.IsNotEmpty());
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual JFunction Fn
        {
            get
            {
                if (!this.HasHandlers)
                {
                    return null;
                }

                StringBuilder handler = new StringBuilder();

                handler.Append("switch(buttonId){");

                if (this.Ok != null && this.Ok.Handler.IsNotEmpty())
                {
                    handler.Append("case \"ok\":");
                    handler.Append(this.Ok.HandlerProxy);
                    handler.Append("break;");
                }

                if (this.Cancel != null && this.Cancel.Handler.IsNotEmpty())
                {
                    handler.Append("case \"cancel\":");
                    handler.Append(this.Cancel.HandlerProxy);
                    handler.Append("break;");
                }

                if (this.Yes != null && this.Yes.Handler.IsNotEmpty())
                {
                    handler.Append("case \"yes\":");
                    handler.Append(this.Yes.HandlerProxy);
                    handler.Append("break;");
                }

                if (this.No != null && this.No.Handler.IsNotEmpty())
                {
                    handler.Append("case \"no\":");
                    handler.Append(this.No.HandlerProxy);
                    handler.Append("break;");
                }

                handler.Append("}");

                return new JFunction(handler.ToString(), "buttonId", "text");
            }
        }

        private MessageBoxButtonConfig ok = null;

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        public MessageBoxButtonConfig Ok
        {
            get
            {
                return this.ok;
            }
            set
            {
                this.ok = value;
            }
        }

        private MessageBoxButtonConfig cancel = null;

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        public MessageBoxButtonConfig Cancel
        {
            get
            {
                return this.cancel;
            }
            set
            {
                this.cancel = value;
            }
        }

        private MessageBoxButtonConfig yes = null;

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        public MessageBoxButtonConfig Yes
        {
            get
            {
                return this.yes;
            }
            set
            {
                this.yes = value;
            }
        }

        private MessageBoxButtonConfig no = null;

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Description("")]
        public MessageBoxButtonConfig No
        {
            get
            {
                return this.no;
            }
            set
            {
                this.no = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class MessageBoxButtonConfig : ExtObject
    {
        private string handler = "";

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string Handler
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

        internal virtual string HandlerProxy
        {
            get
            {
                string handler = this.Handler;

                if (handler.IsNotEmpty())
                {
                    if (handler.EndsWith("}"))
                    {
                        return handler;
                    }

                    if (!handler.EndsWith(";"))
                    {
                        return handler.ConcatWith(";");
                    }
                }

                return handler;
            }
        }

        private string text = "";

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string Text
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
    }

    public partial class MessageBoxButtonTextConfig : ExtObject
    {
        private MessageBox mb;

        internal MessageBoxButtonTextConfig(MessageBox mb)
        {
            this.mb = mb;
        }

        private string ok = "";

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
        [DefaultValue("")]
		[Description("")]
        public string Ok
        {
            get
            {
                return this.ok;
            }
            set
            {
                this.ok = value;

                this.mb.Set("buttonText.ok", value);
            }
        }

        private string cancel = "";

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
        [DefaultValue("")]
		[Description("")]
        public string Cancel
        {
            get
            {
                return this.cancel;
            }
            set
            {
                this.cancel = value;

                this.mb.Set("buttonText.cancel", value);
            }
        }

        private string yes = "";

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
        [DefaultValue("")]
		[Description("")]
        public string Yes
        {
            get
            {
                return this.yes;
            }
            set
            {
                this.yes = value;

                this.mb.Set("buttonText.yes", value);
            }
        }

        private string no = "";

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
        [DefaultValue("")]
		[Description("")]
        public string No
        {
            get
            {
                return this.no;
            }
            set
            {
                this.no = value;
                this.mb.Set("buttonText.no", value);
            }
        }
    }
}