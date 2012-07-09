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
    public partial class ScriptTagProxy
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ScriptTagProxy(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ScriptTagProxy.Config Conversion to ScriptTagProxy
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ScriptTagProxy(ScriptTagProxy.Config config)
        {
            return new ScriptTagProxy(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : DataProxy.Config 
        { 
			/*  Implicit ScriptTagProxy.Config Conversion to ScriptTagProxy.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ScriptTagProxy.Builder(ScriptTagProxy.Config config)
			{
				return new ScriptTagProxy.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string callbackParam = "callback";

			/// <summary>
			/// The name of the parameter to pass to the server which tells the server the name of the callback function set up by the load call to process the returned data object.
			/// </summary>
			[DefaultValue("callback")]
			public virtual string CallbackParam 
			{ 
				get
				{
					return this.callbackParam;
				}
				set
				{
					this.callbackParam = value;
				}
			}

			private bool noCache = true;

			/// <summary>
			/// Whether a new request should abort any pending requests. (defaults to false)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool NoCache 
			{ 
				get
				{
					return this.noCache;
				}
				set
				{
					this.noCache = value;
				}
			}

			private int timeout = 30000;

			/// <summary>
			/// (optional) The number of milliseconds to wait for a response. Defaults to 30 seconds.
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
			/// The URL from which to request the data object.
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

        }
    }
}