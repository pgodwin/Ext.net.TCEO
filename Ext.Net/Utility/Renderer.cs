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
using System.Drawing.Design;
using System.Globalization;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [DefaultProperty("Handler")]
    [TypeConverter(typeof(RendererConverter))]
    [ToolboxItem(false)]
    [Description("")]
    public partial class Renderer : StateManagedItem
    {
        private string[] args;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Renderer() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Renderer(string handler) 
        {
            this.Handler = handler;
        }

        /// <summary>
        /// 
        /// </summary>
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("")]
        public string[] Args
        {
            get
            {
                if (this.args == null && !this.DesignMode)
                {
                    this.args = new string[] { "value", "metadata", "record", "rowIndex", "colIndex", "store" };
                }
                return this.args;
            }
            set
            {
                this.args = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToConfigString()
        {
            if (this.Format != RendererFormat.None)
            {
                if (this.FormatArgs != null && this.FormatArgs.Length > 0)
                {
                    return new JFunction("return Ext.util.Format.".ConcatWith(
                                this.Format.ToString().ToLowerCamelCase(),
                                "(value,",
                                this.FormatArgs.Join(),
                                ");"), "value").ToScript();
                }

                if (this.Handler.IsEmpty())
                {
                    return "Ext.util.Format.".ConcatWith(this.Format.ToString().ToLowerCamelCase());
                }
            }

            if (this.Handler.IsNotEmpty())
            {
                string temp = TokenUtils.ParseTokens(this.Handler, this.Owner);

                if (TokenUtils.IsRawToken(temp))
                {
                    return TokenUtils.ReplaceRawToken(temp);
                }

                return new JFunction(
                        temp, 
                        this.Args)
                        .ToScript();
            }

            return TokenUtils.ReplaceRawToken(TokenUtils.ParseTokens(this.Fn));
        }

        /// <summary>
        /// The raw JavaScript function to be called when this Renderer fires.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The raw JavaScript function to be called when this Renderer fires.")]
        public virtual string Fn
        {
            get
            {
                return (string)this.ViewState["Fn"] ?? "";
            }
            set
            {
                this.ViewState["Fn"] = value;
            }
        }

        /// <summary>
        /// The JavaScript logic to be called when this Renderer fires. The Handler will be automatically wrapped in a proper function{} template and passed the correct arguments for this event.
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The JavaScript logic to be called when this Renderer fires. The Handler will be automatically wrapped in a proper function{} template and passed the correct arguments for this event.")]
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
        /// The JavaScript logic to be called when this Renderer fires. The Handler will be automatically wrapped in a proper function{} template and passed the correct arguments for this event.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The JavaScript logic to be called when this Renderer fires. The Handler will be automatically wrapped in a proper function{} template and passed the correct arguments for this event.")]
        public virtual string Scope
        {
            get
            {
                return (string)this.ViewState["Scope"] ?? "";
            }
            set
            {
                this.ViewState["Scope"] = value;
            }
        }

        /// <summary>
        /// A simple helper type to format the value. For custom renderer formating please use .Fn or .Handler.
        /// </summary>
        [DefaultValue(RendererFormat.None)]
        [NotifyParentProperty(true)]
        [Description("A simple helper type to format the value. For custom renderer formating please use .Fn or .Handler.")]
        public virtual RendererFormat Format
        {
            get
            {
                object obj = this.ViewState["Format"];
                return (obj == null) ? RendererFormat.None : (RendererFormat)obj;
            }
            set
            {
                this.ViewState["Format"] = value;
            }
        }

        /// <summary>
        /// Custom arguments passed to Format. Required if Format is Date, DateRenderer, DefaultValue, Ellipsis or Substr.
        /// </summary>
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("Custom arguments passed to Format. Required if Format is Date, DateRenderer, DefaultValue, Ellipsis or Substr.")]
        public virtual string[] FormatArgs
        {
            get
            {
                object obj = this.ViewState["FormatArgs"];
                return (obj == null) ? null : (string[])obj;
            }
            set
            {
                this.ViewState["FormatArgs"] = value;
            }
        }

        /// <summary>
        /// Are all the properties still set with thier default values.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Are all the properties still set with thier default values.")]
        public override bool IsDefault
        {
            get
            {
                return this.Fn.IsEmpty() && this.Handler.IsEmpty() && this.Format == RendererFormat.None;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToString()
        {
            return this.ToString(CultureInfo.InvariantCulture);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToString(CultureInfo culture)
        {
            return TypeDescriptor.GetConverter(this.GetType()).ConvertToString(null, culture, this);
        }
    }
}