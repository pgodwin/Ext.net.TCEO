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
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    public partial class HttpProxy
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public HttpProxy(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit HttpProxy.Config Conversion to HttpProxy
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator HttpProxy(HttpProxy.Config config)
        {
            return new HttpProxy(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : DataProxy.Config 
        { 
			/*  Implicit HttpProxy.Config Conversion to HttpProxy.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator HttpProxy.Builder(HttpProxy.Config config)
			{
				return new HttpProxy.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoAbort = false;

			/// <summary>
			/// Whether a new request should abort any pending requests. (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool AutoAbort 
			{ 
				get
				{
					return this.autoAbort;
				}
				set
				{
					this.autoAbort = value;
				}
			}
        
			private ParameterCollection headers = null;

			/// <summary>
			/// An object containing request headers which are added to each request made by this object.
			/// </summary>
			public ParameterCollection Headers
			{
				get
				{
					if (this.headers == null)
					{
						this.headers = new ParameterCollection();
					}
			
					return this.headers;
				}
			}
			
			private bool disableCaching = true;

			/// <summary>
			/// True to add a unique cache-buster param to GET requests. (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool DisableCaching 
			{ 
				get
				{
					return this.disableCaching;
				}
				set
				{
					this.disableCaching = value;
				}
			}

			private HttpMethod method = HttpMethod.Default;

			/// <summary>
			/// The default HTTP method to be used for requests.
			/// </summary>
			[DefaultValue(HttpMethod.Default)]
			public virtual HttpMethod Method 
			{ 
				get
				{
					return this.method;
				}
				set
				{
					this.method = value;
				}
			}

			private int timeout = 30000;

			/// <summary>
			/// The timeout in milliseconds to be used for requests. (defaults to 30000)
			/// </summary>
			[DefaultValue(30000)]
			public virtual int Timeout 
			{ 
				get
				{
					return this.timeout;
				}
				set
				{
					this.timeout = value;
				}
			}

			private string url = "";

			/// <summary>
			/// The default URL to be used for requests to the server.
			/// </summary>
			[DefaultValue("")]
			public virtual string Url 
			{ 
				get
				{
					return this.url;
				}
				set
				{
					this.url = value;
				}
			}

			private bool json = false;

			/// <summary>
			/// Send params as JSON object
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Json 
			{ 
				get
				{
					return this.json;
				}
				set
				{
					this.json = value;
				}
			}

        }
    }
}