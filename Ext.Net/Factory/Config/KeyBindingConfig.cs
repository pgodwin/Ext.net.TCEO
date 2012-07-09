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
    public partial class KeyBinding
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public KeyBinding(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit KeyBinding.Config Conversion to KeyBinding
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator KeyBinding(KeyBinding.Config config)
        {
            return new KeyBinding(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : StateManagedItem.Config 
        { 
			/*  Implicit KeyBinding.Config Conversion to KeyBinding.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator KeyBinding.Builder(KeyBinding.Config config)
			{
				return new KeyBinding.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool? shift = null;

			/// <summary>
			/// True to handle key only when shift is pressed, False to handle the key only when shift is not pressed (defaults to undefined)
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? Shift 
			{ 
				get
				{
					return this.shift;
				}
				set
				{
					this.shift = value;
				}
			}

			private bool? ctrl = null;

			/// <summary>
			/// True to handle key only when ctrl is pressed, False to handle the key only when ctrl is not pressed (defaults to undefined)
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? Ctrl 
			{ 
				get
				{
					return this.ctrl;
				}
				set
				{
					this.ctrl = value;
				}
			}

			private bool? alt = null;

			/// <summary>
			/// True to handle key only when alt is pressed, False to handle the key only when alt is not pressed (defaults to undefined)
			/// </summary>
			[DefaultValue(null)]
			public virtual bool? Alt 
			{ 
				get
				{
					return this.alt;
				}
				set
				{
					this.alt = value;
				}
			}

			private bool stopEvent = false;

			/// <summary>
			/// True to stop the event from bubbling and prevent the default browser action if the key was handled by the KeyMap (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool StopEvent 
			{ 
				get
				{
					return this.stopEvent;
				}
				set
				{
					this.stopEvent = value;
				}
			}

			private string scope = "";

			/// <summary>
			/// The scope of the callback function
			/// </summary>
			[DefaultValue("")]
			public virtual string Scope 
			{ 
				get
				{
					return this.scope;
				}
				set
				{
					this.scope = value;
				}
			}
        
			private KeyListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public KeyListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new KeyListeners();
					}
			
					return this.listeners;
				}
			}
			
        }
    }
}