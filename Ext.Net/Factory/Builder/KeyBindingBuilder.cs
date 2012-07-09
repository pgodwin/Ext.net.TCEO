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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : StateManagedItem.Builder<KeyBinding, KeyBinding.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new KeyBinding()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(KeyBinding component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(KeyBinding.Config config) : base(new KeyBinding(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(KeyBinding component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to handle key only when shift is pressed, False to handle the key only when shift is not pressed (defaults to undefined)
			/// </summary>
            public virtual KeyBinding.Builder Shift(bool? shift)
            {
                this.ToComponent().Shift = shift;
                return this as KeyBinding.Builder;
            }
             
 			/// <summary>
			/// True to handle key only when ctrl is pressed, False to handle the key only when ctrl is not pressed (defaults to undefined)
			/// </summary>
            public virtual KeyBinding.Builder Ctrl(bool? ctrl)
            {
                this.ToComponent().Ctrl = ctrl;
                return this as KeyBinding.Builder;
            }
             
 			/// <summary>
			/// True to handle key only when alt is pressed, False to handle the key only when alt is not pressed (defaults to undefined)
			/// </summary>
            public virtual KeyBinding.Builder Alt(bool? alt)
            {
                this.ToComponent().Alt = alt;
                return this as KeyBinding.Builder;
            }
             
 			/// <summary>
			/// True to stop the event from bubbling and prevent the default browser action if the key was handled by the KeyMap (defaults to false)
			/// </summary>
            public virtual KeyBinding.Builder StopEvent(bool stopEvent)
            {
                this.ToComponent().StopEvent = stopEvent;
                return this as KeyBinding.Builder;
            }
             
 			/// <summary>
			/// The scope of the callback function
			/// </summary>
            public virtual KeyBinding.Builder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as KeyBinding.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(KeyListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyBinding.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.KeyBinding(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public KeyBinding.Builder KeyBinding()
        {
            return this.KeyBinding(new KeyBinding());
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyBinding.Builder KeyBinding(KeyBinding component)
        {
            return new KeyBinding.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyBinding.Builder KeyBinding(KeyBinding.Config config)
        {
            return new KeyBinding.Builder(new KeyBinding(config));
        }
    }
}