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
    public abstract partial class Observable
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TObservable, TBuilder> : XControl.Builder<TObservable, TBuilder>
            where TObservable : Observable
            where TBuilder : Builder<TObservable, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TObservable component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			// /// <summary>
			// /// Collection of custom js config
			// /// </summary>
            // public virtual TBuilder CustomConfig(ConfigItemCollection customConfig)
            // {
            //    this.ToComponent().CustomConfig = customConfig;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Used to define events on this Observable
			/// </summary>
            public virtual TBuilder AddEvents(string events)
            {
                this.ToComponent().AddEvents(events);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Appends an event handler to this component
			/// </summary>
            public virtual TBuilder AddListener(string eventName, JFunction fn)
            {
                this.ToComponent().AddListener(eventName, fn);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Appends an event handler to this component
			/// </summary>
            public virtual TBuilder AddListener(string eventName, JFunction fn, string scope)
            {
                this.ToComponent().AddListener(eventName, fn, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Appends an event handler to this component
			/// </summary>
            public virtual TBuilder AddListener(string eventName, JFunction fn, string scope, HandlerConfig options)
            {
                this.ToComponent().AddListener(eventName, fn, scope, options);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Appends an event handler to this component
			/// </summary>
            public virtual TBuilder AddListener(string eventName, string fn)
            {
                this.ToComponent().AddListener(eventName, fn);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Appends an event handler to this component
			/// </summary>
            public virtual TBuilder AddListener(string eventName, string fn, string scope)
            {
                this.ToComponent().AddListener(eventName, fn, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Appends an event handler to this component
			/// </summary>
            public virtual TBuilder AddListener(string eventName, string fn, string scope, HandlerConfig options)
            {
                this.ToComponent().AddListener(eventName, fn, scope, options);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Fires the specified event with the passed parameters (minus the event name)
			/// </summary>
            public virtual TBuilder FireEvent(string eventName, params object[] args)
            {
                this.ToComponent().FireEvent(eventName, args);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Appends an event handler to this element (shorthand for addListener)
			/// </summary>
            public virtual TBuilder On(string eventName, string fn)
            {
                this.ToComponent().On(eventName, fn);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Appends an event handler to this element (shorthand for addListener)
			/// </summary>
            public virtual TBuilder On(string eventName, string fn, string scope)
            {
                this.ToComponent().On(eventName, fn, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Appends an event handler to this element (shorthand for addListener)
			/// </summary>
            public virtual TBuilder On(string eventName, string fn, string scope, HandlerConfig options)
            {
                this.ToComponent().On(eventName, fn, scope, options);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Appends an event handler to this element (shorthand for addListener)
			/// </summary>
            public virtual TBuilder On(string eventName, JFunction fn)
            {
                this.ToComponent().On(eventName, fn);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Appends an event handler to this element (shorthand for addListener)
			/// </summary>
            public virtual TBuilder On(string eventName, JFunction fn, string scope)
            {
                this.ToComponent().On(eventName, fn, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Appends an event handler to this element (shorthand for addListener)
			/// </summary>
            public virtual TBuilder On(string eventName, JFunction fn, string scope, HandlerConfig options)
            {
                this.ToComponent().On(eventName, fn, scope, options);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes all listeners for this object
			/// </summary>
            public virtual TBuilder PurgeListeners()
            {
                this.ToComponent().PurgeListeners();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes a listener
			/// </summary>
            public virtual TBuilder RemoveListener(string eventName, string fn)
            {
                this.ToComponent().RemoveListener(eventName, fn);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes a listener
			/// </summary>
            public virtual TBuilder RemoveListener(string eventName, string fn, string scope)
            {
                this.ToComponent().RemoveListener(eventName, fn, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Resume firing events. (see suspendEvents)
			/// </summary>
            public virtual TBuilder ResumeEvents()
            {
                this.ToComponent().ResumeEvents();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Suspend the firing of all events. (see resumeEvents)
			/// </summary>
            public virtual TBuilder SuspendEvents(bool queueSuspended)
            {
                this.ToComponent().SuspendEvents(queueSuspended);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes a listener (shorthand for removeListener)
			/// </summary>
            public virtual TBuilder Un(string eventName, string fn)
            {
                this.ToComponent().Un(eventName, fn);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Removes a listener (shorthand for removeListener)
			/// </summary>
            public virtual TBuilder Un(string eventName, string fn, string scope)
            {
                this.ToComponent().Un(eventName, fn, scope);
                return this as TBuilder;
            }
            
        }        
    }
}