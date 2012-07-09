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
    [ToolboxItem(false)]
    [Description("")]
    public partial class JFunction : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public JFunction() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public JFunction(string handler)
        {
            this.Handler = handler;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public JFunction(string handler, params string[] args) 
        {
            this.Handler = handler;
            this.Args = args;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToString()
        {
            return this.ToScript();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public virtual string ToScript()
        {
            if (this.Fn.IsNotEmpty())
            {
                return this.NamePrefix + this.Fn;
            }

            string handler = TokenUtils.ReplaceRawToken(TokenUtils.ParseTokens(this.Handler, this.Owner));

            if (this.Args != null && this.Args.Length > 0)
            {
                if (this.FormatHandler)
                {
                    return this.NamePrefix + "function(".ConcatWith(this.Args.Join(","), "){", handler.FormatWith(this.Args), "}");
                }
                else
                {
                    return this.NamePrefix + "function(".ConcatWith(this.Args.Join(","), "){", handler, "}");
                }
            }
            else
            {
                return this.NamePrefix + "function(){".ConcatWith(handler).ConcatWith("}");
            }
        }

        private string NamePrefix
        {
            get
            {
                return this.Name.IsEmpty() ? "" : this.Name + ":";
            }
        }

        private string name;

		/// <summary>
		/// 
		/// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
		[Description("")]
        public virtual string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }


        private string fn;

        /// <summary>
        /// The raw JavaScript code to call.
        /// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [Description("The raw JavaScript code to call.")]
        public virtual string Fn
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

        string handler = "";

        /// <summary>
        /// The JavaScript logic within the function(){} signature.
        /// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [Description("The JavaScript logic within the function(){} signature.")]
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

        string[] args;

        /// <summary>
        /// Custom arguments passed to event handler if Handler property is set.
        /// </summary>
        [TypeConverter(typeof(StringArrayConverter))]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [Description("Custom arguments passed to event handler if Handler property is set.")]
        public virtual string[] Args
        {
            get
            {
                return this.args;
            }
            set
            {
                this.args = value;
            }
        }

        private bool formatHandler = false;

        /// <summary>
        /// If FormatHander=true, then the Handler property will be passed through the string.Format() Method and argument placeholders/tokens with be replaced with the argument index value.
        /// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue(false)]
        [Description("If FormatHander=true, then the Handler property will be passed through the string.Format() Method and argument placeholders/tokens with be replaced with the argument index value.")]
        public virtual bool FormatHandler
        {
            get
            {
                return this.formatHandler;
            }
            set
            {
                this.formatHandler = value;
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
                return this.Handler.IsEmpty() && this.Fn.IsEmpty();
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static JFunction EmptyFn
        {
            get
            {
                JFunction fn = new JFunction();
                fn.Fn = "Ext.emptyFn";

                return fn;
            }
        }
    }
}