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
    public partial class HttpWriteProxy
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public HttpWriteProxy(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit HttpWriteProxy.Config Conversion to HttpWriteProxy
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator HttpWriteProxy(HttpWriteProxy.Config config)
        {
            return new HttpWriteProxy(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : HttpProxy.Config 
        { 
			/*  Implicit HttpWriteProxy.Config Conversion to HttpWriteProxy.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator HttpWriteProxy.Builder(HttpWriteProxy.Config config)
			{
				return new HttpWriteProxy.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool handleSaveResponseAsXml = false;

			/// <summary>
			/// If save handler is web service then response will be xml. This option specifies how to handle response.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool HandleSaveResponseAsXml 
			{ 
				get
				{
					return this.handleSaveResponseAsXml;
				}
				set
				{
					this.handleSaveResponseAsXml = value;
				}
			}

        }
    }
}