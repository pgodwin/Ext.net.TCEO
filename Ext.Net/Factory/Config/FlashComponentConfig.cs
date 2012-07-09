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
    public partial class FlashComponent
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public FlashComponent(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit FlashComponent.Config Conversion to FlashComponent
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator FlashComponent(FlashComponent.Config config)
        {
            return new FlashComponent(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : BoxComponentBase.Config 
        { 
			/*  Implicit FlashComponent.Config Conversion to FlashComponent.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator FlashComponent.Builder(FlashComponent.Config config)
			{
				return new FlashComponent.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string backgroundColor = "#ffffff";

			/// <summary>
			/// The background color. Defaults to '#ffffff' (white).
			/// </summary>
			[DefaultValue("#ffffff")]
			public virtual string BackgroundColor 
			{ 
				get
				{
					return this.backgroundColor;
				}
				set
				{
					this.backgroundColor = value;
				}
			}

			private bool expressInstall = false;

			/// <summary>
			/// True to prompt the user to install flash if not installed. Note that this uses Ext.FlashComponent.EXPRESS_INSTALL_URL, which should be set to the local resource. Defaults to false.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ExpressInstall 
			{ 
				get
				{
					return this.expressInstall;
				}
				set
				{
					this.expressInstall = value;
				}
			}

			private string flashVersion = "9.0.45";

			/// <summary>
			/// Indicates the version the flash content was published for. Defaults to '9.0.45'.
			/// </summary>
			[DefaultValue("9.0.45")]
			public virtual string FlashVersion 
			{ 
				get
				{
					return this.flashVersion;
				}
				set
				{
					this.flashVersion = value;
				}
			}

			private string url = "";

			/// <summary>
			/// The URL of the swf object to include. Defaults to undefined.
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
        
			private ParameterCollection flashVars = null;

			/// <summary>
			/// A set of key value pairs to be passed to the flash object as flash variables.
			/// </summary>
			public ParameterCollection FlashVars
			{
				get
				{
					if (this.flashVars == null)
					{
						this.flashVars = new ParameterCollection();
					}
			
					return this.flashVars;
				}
			}
			        
			private ParameterCollection flashParams = null;

			/// <summary>
			/// A set of key value pairs to be passed to the flash object as parameters.
			/// </summary>
			public ParameterCollection FlashParams
			{
				get
				{
					if (this.flashParams == null)
					{
						this.flashParams = new ParameterCollection();
					}
			
					return this.flashParams;
				}
			}
			        
			private FlashComponentListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public FlashComponentListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new FlashComponentListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private FlashComponentDirectEvents directEvents = null;

			/// <summary>
			/// Server-side Ajax Event Handlers
			/// </summary>
			public FlashComponentDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new FlashComponentDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}