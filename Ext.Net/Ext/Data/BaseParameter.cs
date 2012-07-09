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
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [DefaultProperty("Params")]
    [ParseChildren(true, "Params")]
    [Description("")]
    public abstract partial class BaseParameter: StateManagedItem
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected BaseParameter() { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected BaseParameter(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected BaseParameter(string name, string value, ParameterMode mode) : this(name, value)
        {
            this.Mode = mode;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected BaseParameter(string name, string value, bool encode) : this(name, value)
        {
            this.Encode = encode;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected BaseParameter(string name, string value, ParameterMode mode, bool encode) : this(name, value)
        {
            this.Mode = mode;
            this.Encode = encode;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("")]
        public virtual string Name
        {
            get
            {
                return (string)this.ViewState["Name"] ?? "";
            }
            set
            {
                this.ViewState["Name"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("")]
        public virtual string Value
        {
            get
            {
                return (string)this.ViewState["Value"] ?? "";
            }
            set
            {
                this.ViewState["Value"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual ParameterMode DefaultMode
        {
             get
             {
                 return ParameterMode.Value;
             }  
        }

        /// <summary>
        /// Wrap in quotes or not
        /// </summary>
        [Meta]
        [DefaultValue(ParameterMode.Value)]
        [Description("Wrap in quotes or not")]
        public virtual ParameterMode Mode
        {
            get
            {
                object obj = this.ViewState["Mode"];
                return obj == null ? this.DefaultMode : (ParameterMode)obj;
            }
            set
            {
                this.ViewState["Mode"] = value;
            }
        }

        /// <summary>
        /// Encode value. Useful when value is js object
        /// </summary>
        [Meta]
        [DefaultValue(false)]
        [Description("Encode value, it might be useful when value is js object")]
        public virtual bool Encode
        {
            get
            {
                object obj = this.ViewState["Encode"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Encode"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override string ToString()
        {
            return this.ToString(this.CamelName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="camelNames"></param>
        /// <returns></returns>
        [Description("")]
        public virtual string ToString(bool camelNames)
        {
            //this.EnsureDataBind();

            ParameterMode mode = this.Mode;

            string name = camelNames ? this.Name.ToLowerCamelCase() : this.Name;

            if (this.Params.Count > 0)
            {
                return this.ToStringInnerParams(name);
            }
            else
            {
                string script = TokenUtils.ParseTokens(this.Value, this.Owner);

                if (TokenUtils.IsRawToken(script))
                {
                    mode = ParameterMode.Raw;
                    script = TokenUtils.ReplaceRawToken(script);
                }

                return JSON.Serialize(name).ConcatWith(":", this.Encode ? "Ext.encode(" : "", mode == ParameterMode.Raw ? script : JSON.Serialize(script), this.Encode ? ")" : "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        private string ToStringInnerParams(string name)
        {
            //this.EnsureDataBind();

            if (this.Value.IsNotEmpty())
            {
                throw new Exception("The Value can not be used with Params in a Parameter object.");
            }

            StringBuilder sb = new StringBuilder();

            if (name.IsNotEmpty())
            {
                sb.Append(name).Append(":");
            }

            sb.Append("{");

            foreach (Parameter parameter in this.Params)
            {
                sb.Append(parameter.ToString());
                sb.Append(",");
            }

            if (sb[sb.Length-1] == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }

            sb.Append("}");

            return sb.ToString();
        }


        private bool camelName;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        internal virtual bool CamelName
        {
            get
            {
                return this.camelName;
            }
            set
            {
                this.camelName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string ValueToString()
        {
            //this.EnsureDataBind();
            ParameterMode mode = this.Mode;

            if (this.Params.Count > 0)
            {
                return this.ToStringInnerParams(null);
            }
            else
            {

                string script = TokenUtils.ParseTokens(this.Value, this.Owner);

                if (TokenUtils.IsRawToken(script))
                {
                    mode = ParameterMode.Raw;
                    script = TokenUtils.ReplaceRawToken(script);
                }

                return (this.Encode ? "Ext.encode(" : "").ConcatWith(
                                     mode == ParameterMode.Raw ? script : JSON.Serialize(script), this.Encode ? ")" : "");
            }
        }

        private ParameterCollection userParams;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [Description("")]
        public virtual ParameterCollection Params
        {
            get
            {
                if (this.userParams == null)
                {
                    this.userParams = new ParameterCollection();
                    this.userParams.Owner = this.Owner;
                }

                return this.userParams;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum ParameterMode
    {
        /// <summary>
        /// 
        /// </summary>
        Raw,

        /// <summary>
        /// 
        /// </summary>
        Value
    }
}
