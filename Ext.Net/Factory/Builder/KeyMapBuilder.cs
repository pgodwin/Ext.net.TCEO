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
    public partial class KeyMap
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Observable.Builder<KeyMap, KeyMap.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new KeyMap()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(KeyMap component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(KeyMap.Config config) : base(new KeyMap(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(KeyMap component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// A KeyMap config object (in the format expected by Ext.KeyMap.addBinding used to assign custom key handling to this panel (defaults to null).
			// /// </summary>
            // public virtual TBuilder Keys(KeyBindingCollection keys)
            // {
            //    this.ToComponent().Keys = keys;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The element to bind to
			/// </summary>
            public virtual KeyMap.Builder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as KeyMap.Builder;
            }
             
 			/// <summary>
			/// (optional) The event to bind to (defaults to 'keydown')
			/// </summary>
            public virtual KeyMap.Builder EventName(string eventName)
            {
                this.ToComponent().EventName = eventName;
                return this as KeyMap.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual KeyMap.Builder Enable()
            {
                this.ToComponent().Enable();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual KeyMap.Builder Disable()
            {
                this.ToComponent().Disable();
                return this;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual KeyMap.Builder AddKeyBinding(KeyBinding keyBinding)
            {
                this.ToComponent().AddKeyBinding(keyBinding);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyMap.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.KeyMap(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public KeyMap.Builder KeyMap()
        {
            return this.KeyMap(new KeyMap());
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyMap.Builder KeyMap(KeyMap component)
        {
            return new KeyMap.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyMap.Builder KeyMap(KeyMap.Config config)
        {
            return new KeyMap.Builder(new KeyMap(config));
        }
    }
}