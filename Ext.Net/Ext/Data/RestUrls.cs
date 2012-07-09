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
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Specific urls to call on REST action methods "read", "create", "update" and "destroy"
    /// </summary>
    [Description("")]
    public partial class RestUrls : StateManagedItem
    {
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public string CreateUrl
        {
            get
            {
                return (string)this.ViewState["CreateUrl"] ?? "";
            }
            set
            {
                this.ViewState["CreateUrl"] = value;
            }
        }

        /// <summary>       
        /// 
        /// </summary>
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual HttpMethod CreateMethod
        {
            get
            {
                object obj = this.ViewState["CreateMethod"];
                return obj == null ? HttpMethod.Default : (HttpMethod)obj;
            }
            set
            {
                this.ViewState["CreateMethod"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("create", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string CreateProxy
        {
            get
            {
                string url = this.ResolveUrl(this.CreateUrl);

                if (url.IsEmpty())
                {
                    return "";
                }

                return this.CreateMethod == HttpMethod.Default ? JSON.Serialize(url) : this.APIActionTemplate.FormatWith(url, this.CreateMethod.ToString());
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
		[Description("")]
        public string ReadUrl
        {
            get
            {
                return (string)this.ViewState["ReadUrl"] ?? "";
            }
            set
            {
                this.ViewState["ReadUrl"] = value;
            }
        }

        /// <summary>     
        /// 
        /// </summary>
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual HttpMethod ReadMethod
        {
            get
            {
                object obj = this.ViewState["ReadMethod"];
                return obj == null ? HttpMethod.Default : (HttpMethod)obj;
            }
            set
            {
                this.ViewState["ReadMethod"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("read", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string ReadProxy
        {
            get
            {
                string url = this.ResolveUrl(this.ReadUrl);

                if (url.IsEmpty())
                {
                    return "";
                }

                return this.ReadMethod == HttpMethod.Default ? JSON.Serialize(url) : this.APIActionTemplate.FormatWith(url, this.ReadMethod.ToString());
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
		[Description("")]
        public string UpdateUrl
        {
            get
            {
                return (string)this.ViewState["UpdateUrl"] ?? "";
            }
            set
            {
                this.ViewState["UpdateUrl"] = value;
            }
        }

        /// <summary>     
        /// 
        /// </summary>
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual HttpMethod UpdateMethod
        {
            get
            {
                object obj = this.ViewState["UpdateMethod"];
                return obj == null ? HttpMethod.Default : (HttpMethod)obj;
            }
            set
            {
                this.ViewState["UpdateMethod"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("update", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string UpdateProxy
        {
            get
            {
                string url = this.ResolveUrl(this.UpdateUrl);

                if (url.IsEmpty())
                {
                    return "";
                }

                return this.UpdateMethod == HttpMethod.Default ? JSON.Serialize(url) : this.APIActionTemplate.FormatWith(url, this.UpdateMethod.ToString());
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
		[Description("")]
        public string DestroyUrl
        {
            get
            {
                return (string)this.ViewState["DestroyUrl"] ?? "";
            }
            set
            {
                this.ViewState["DestroyUrl"] = value;
            }
        }

        /// <summary>     
        /// 
        /// </summary>
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual HttpMethod DestroyMethod
        {
            get
            {
                object obj = this.ViewState["DestroyMethod"];
                return obj == null ? HttpMethod.Default : (HttpMethod)obj;
            }
            set
            {
                this.ViewState["DestroyMethod"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("destroy", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string DestroyProxy
        {
            get
            {
                string url = this.ResolveUrl(this.DestroyUrl);

                if (url.IsEmpty())
                {
                    return "";
                }

                return this.DestroyMethod == HttpMethod.Default ? JSON.Serialize(url) : this.APIActionTemplate.FormatWith(url, this.DestroyMethod.ToString());
            }
        }

        protected virtual string APIActionTemplate
        {
            get
            {
                return "{{url:\"{0}\",method:\"{1}\"}}";
            }
        }

        private string ResolveUrl(string url)
        {
            return this.Owner == null ? url : this.Owner.ResolveClientUrl(url);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.CreateUrl.IsEmpty() &&
                       this.ReadUrl.IsEmpty() &&
                       this.UpdateUrl.IsEmpty() &&
                       this.DestroyUrl.IsEmpty();
            }
        }
    }
}