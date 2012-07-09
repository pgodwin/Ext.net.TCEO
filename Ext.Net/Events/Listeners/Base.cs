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

using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class BaseListener : StateManagedItem
    {
        /// <summary>
        /// The scope in which to execute the handler function. The handler function's 'this' context.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("this")]
        [NotifyParentProperty(true)]
        [Description("The scope in which to execute the handler function. The handler function's 'this' context.")]
        public virtual string Scope
        {
            get
            {
                return (string)this.ViewState["Scope"] ?? "this";
            }
            set
            {
                this.ViewState["Scope"] = value;
            }
        }

        /// <summary>
        /// A simple selector to filter the target or look for a descendant of the target
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A simple selector to filter the target or look for a descendant of the target")]
        public virtual string Delegate
        {
            get
            {
                return (string)this.ViewState["Delegate"] ?? "";
            }
            set
            {
                this.ViewState["Delegate"] = value;
            }
        }

        /// <summary>
        /// True to stop the event. That is stop propagation, and prevent the default action.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to stop the event. That is stop propagation, and prevent the default action.")]
        public virtual bool StopEvent
        {
            get
            {
                object obj = this.ViewState["StopEvent"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["StopEvent"] = value;
            }
        }

        /// <summary>
        /// True to prevent the default action.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to prevent the default action.")]
        public virtual bool PreventDefault
        {
            get
            {
                object obj = this.ViewState["PreventDefault"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["PreventDefault"] = value;
            }
        }

        /// <summary>
        /// True to prevent event propagation.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to prevent event propagation.")]
        public virtual bool StopPropagation
        {
            get
            {
                object obj = this.ViewState["StopPropagation"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["StopPropagation"] = value;
            }
        }

        /// <summary>
        /// False to pass a browser event to the handler function instead of an Ext.EventObject.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("False to pass a browser event to the handler function instead of an Ext.EventObject.")]
        public virtual bool Normalized
        {
            get
            {
                object obj = this.ViewState["Normalized"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Normalized"] = value;
            }
        }

        /// <summary>
        /// The number of milliseconds to delay the invocation of the handler after the event fires.
        /// </summary>
        [ConfigOption]
        [DefaultValue(20)]
        [NotifyParentProperty(true)]
        [Description("The number of milliseconds to delay the invocation of the handler after the event fires.")]
        public virtual int Delay
        {
            get
            {
                object obj = this.ViewState["Delay"];
                return (obj == null) ? 20 : (int)obj;
            }
            set
            {
                this.ViewState["Delay"] = value;
            }
        }

        /// <summary>
        /// True to add a handler to handle just the next firing of the event, and then remove itself.
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to add a handler to handle just the next firing of the event, and then remove itself.")]
        public virtual bool Single
        {
            get
            {
                object obj = this.ViewState["Single"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Single"] = value;
            }
        }

        /// <summary>
        /// Causes the handler to be scheduled to run in an Ext.util.DelayedTask delayed by the specified number of milliseconds. If the event fires again within that time, the original handler is not invoked, but the new handler is scheduled in its place.
        /// </summary>
        [ConfigOption]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("Causes the handler to be scheduled to run in an Ext.util.DelayedTask delayed by the specified number of milliseconds. If the event fires again within that time, the original handler is not invoked, but the new handler is scheduled in its place.")]
        public virtual int Buffer
        {
            get
            {
                object obj = this.ViewState["Buffer"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["Buffer"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public HandlerConfig GetListenerConfig()
        {
            HandlerConfig cfg = new HandlerConfig();
            cfg.Scope = this.Scope;
            cfg.Buffer = this.Buffer;
            cfg.Delay = this.Delay;
            cfg.Single = this.Single;
            cfg.Delegate = this.Delegate;
            cfg.Normalized = this.Normalized;
            cfg.PreventDefault = this.PreventDefault;
            cfg.StopEvent = this.StopEvent;
            cfg.StopPropagation = this.StopPropagation;

            return cfg;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public partial class ListenerArgumentAttributeComparer : IComparer<ListenerArgumentAttribute>
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj1"></param>
            /// <param name="obj2"></param>
            /// <returns></returns>
            [Description("")]
            public int Compare(ListenerArgumentAttribute obj1, ListenerArgumentAttribute obj2)
            {
                return obj1.Index.CompareTo(obj2.Index);
            }
        }

        internal void SetArgumentList(PropertyInfo property)
        {
            List<ListenerArgumentAttribute> attrs = new List<ListenerArgumentAttribute>();

            foreach (ListenerArgumentAttribute a in property.GetCustomAttributes(typeof(ListenerArgumentAttribute), false))
            {
                attrs.Add(a);
            }

            attrs.Sort(new ListenerArgumentAttributeComparer());

            List<string> args = new List<string>();

            foreach (ListenerArgumentAttribute a in attrs)
            {
                args.Add(a.Name);
            }

            this.argumentList = args;
        }

        List<string> argumentList;

        [Description("List of Arguments passed to event handler.")]
        internal List<string> ArgumentList
        {
            get
            {
                if (this.argumentList == null)
                {
                    this.argumentList = new List<string>();
                }

                return this.argumentList;
            }
        }
    }
}