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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : DataProxy.Builder<ScriptTagProxy, ScriptTagProxy.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ScriptTagProxy()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ScriptTagProxy component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ScriptTagProxy.Config config) : base(new ScriptTagProxy(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ScriptTagProxy component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The name of the parameter to pass to the server which tells the server the name of the callback function set up by the load call to process the returned data object.
			/// </summary>
            public virtual ScriptTagProxy.Builder CallbackParam(string callbackParam)
            {
                this.ToComponent().CallbackParam = callbackParam;
                return this as ScriptTagProxy.Builder;
            }
             
 			/// <summary>
			/// Whether a new request should abort any pending requests. (defaults to false)
			/// </summary>
            public virtual ScriptTagProxy.Builder NoCache(bool noCache)
            {
                this.ToComponent().NoCache = noCache;
                return this as ScriptTagProxy.Builder;
            }
             
 			/// <summary>
			/// (optional) The number of milliseconds to wait for a response. Defaults to 30 seconds.
			/// </summary>
            public virtual ScriptTagProxy.Builder Timeout(int timeout)
            {
                this.ToComponent().Timeout = timeout;
                return this as ScriptTagProxy.Builder;
            }
             
 			/// <summary>
			/// The URL from which to request the data object.
			/// </summary>
            public virtual ScriptTagProxy.Builder Url(string url)
            {
                this.ToComponent().Url = url;
                return this as ScriptTagProxy.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ScriptTagProxy.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ScriptTagProxy(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ScriptTagProxy.Builder ScriptTagProxy()
        {
            return this.ScriptTagProxy(new ScriptTagProxy());
        }

        /// <summary>
        /// 
        /// </summary>
        public ScriptTagProxy.Builder ScriptTagProxy(ScriptTagProxy component)
        {
            return new ScriptTagProxy.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ScriptTagProxy.Builder ScriptTagProxy(ScriptTagProxy.Config config)
        {
            return new ScriptTagProxy.Builder(new ScriptTagProxy(config));
        }
    }
}