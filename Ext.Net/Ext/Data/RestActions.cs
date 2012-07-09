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
    /// Defined {CRUD action}:{HTTP method} pairs to associate HTTP methods with the corresponding actions for RESTful proxies.
    /// </summary>
    public partial class RestActions : StateManagedItem, ICustomConfigSerialization
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue(HttpMethod.POST)]
        [NotifyParentProperty(true)]
        [Description("")]
        public HttpMethod Create
        {
            get
            {
                object obj = this.ViewState["Create"];
                return obj != null ? (HttpMethod)obj : HttpMethod.POST;
            }
            set
            {
                this.ViewState["Create"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue(HttpMethod.GET)]
        [NotifyParentProperty(true)]
        [Description("")]
        public HttpMethod Read
        {
            get
            {
                object obj = this.ViewState["Read"];
                return obj != null ? (HttpMethod)obj : HttpMethod.GET;
            }
            set
            {
                this.ViewState["Read"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue(HttpMethod.PUT)]
        [NotifyParentProperty(true)]
        [Description("")]
        public HttpMethod Update
        {
            get
            {
                object obj = this.ViewState["Update"];
                return obj != null ? (HttpMethod)obj : HttpMethod.PUT;
            }
            set
            {
                this.ViewState["Update"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue(HttpMethod.DELETE)]
        [NotifyParentProperty(true)]
        [Description("")]
        public HttpMethod Destroy
        {
            get
            {
                object obj = this.ViewState["Destroy"];
                return obj != null ? (HttpMethod)obj : HttpMethod.DELETE;
            }
            set
            {
                this.ViewState["Destroy"] = value;
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
                return this.Create == HttpMethod.POST &&
                       this.Read == HttpMethod.GET &&
                       this.Update == HttpMethod.PUT &&
                       this.Destroy == HttpMethod.DELETE;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToScript(Control owner)
        {
            return "Ext.apply(Ext.data.Api.restActions, {0});".FormatWith(new ClientConfig().Serialize(this, true));
        }
    }
}