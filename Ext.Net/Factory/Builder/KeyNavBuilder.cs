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
    public partial class KeyNav
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Observable.Builder<KeyNav, KeyNav.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new KeyNav()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(KeyNav component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(KeyNav.Config config) : base(new KeyNav(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(KeyNav component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The element to bind to
			/// </summary>
            public virtual KeyNav.Builder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as KeyNav.Builder;
            }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Left(JFunction left)
            // {
            //    this.ToComponent().Left = left;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Right(JFunction right)
            // {
            //    this.ToComponent().Right = right;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Up(JFunction up)
            // {
            //    this.ToComponent().Up = up;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Down(JFunction down)
            // {
            //    this.ToComponent().Down = down;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder PageUp(JFunction pageUp)
            // {
            //    this.ToComponent().PageUp = pageUp;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder PageDown(JFunction pageDown)
            // {
            //    this.ToComponent().PageDown = pageDown;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Del(JFunction del)
            // {
            //    this.ToComponent().Del = del;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Home(JFunction home)
            // {
            //    this.ToComponent().Home = home;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder End(JFunction end)
            // {
            //    this.ToComponent().End = end;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Enter(JFunction enter)
            // {
            //    this.ToComponent().Enter = enter;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Esc(JFunction esc)
            // {
            //    this.ToComponent().Esc = esc;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Tab(JFunction tab)
            // {
            //    this.ToComponent().Tab = tab;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The method to call on the Ext.EventObject after this KeyNav intercepts a key. Valid values are Ext.EventObject.stopEvent, Ext.EventObject.preventDefault and Ext.EventObject.stopPropagation (defaults to 'stopEvent')
			/// </summary>
            public virtual KeyNav.Builder DefaultEventAction(KeyEventAction defaultEventAction)
            {
                this.ToComponent().DefaultEventAction = defaultEventAction;
                return this as KeyNav.Builder;
            }
             
 			/// <summary>
			/// True to disable this KeyNav instance (defaults to false)
			/// </summary>
            public virtual KeyNav.Builder Disabled(bool disabled)
            {
                this.ToComponent().Disabled = disabled;
                return this as KeyNav.Builder;
            }
             
 			/// <summary>
			/// Handle the keydown event instead of keypress (defaults to false). KeyNav automatically does this for IE since IE does not propagate special keys on keypress, but setting this to true will force other browsers to also handle keydown instead of keypress.
			/// </summary>
            public virtual KeyNav.Builder ForceKeyDown(bool forceKeyDown)
            {
                this.ToComponent().ForceKeyDown = forceKeyDown;
                return this as KeyNav.Builder;
            }
             
 			/// <summary>
			/// The scope of the callback function
			/// </summary>
            public virtual KeyNav.Builder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as KeyNav.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyNav.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.KeyNav(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public KeyNav.Builder KeyNav()
        {
            return this.KeyNav(new KeyNav());
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyNav.Builder KeyNav(KeyNav component)
        {
            return new KeyNav.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public KeyNav.Builder KeyNav(KeyNav.Config config)
        {
            return new KeyNav.Builder(new KeyNav(config));
        }
    }
}