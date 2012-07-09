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

using System.ComponentModel;
using System.Web;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [TypeConverter(typeof(DirectEventConverter))]
    [ToolboxItem(false)]
    [Description("")]
    public partial class DirectEvent : ComponentDirectEvent
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DirectEvent() { }

        //target and handler are required properties, so must be initialized always
        private DirectEvent(string target, DirectEventHandler handler)
        {
            this.Target = target;
            this.Event += handler;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DirectEvent(string target, HtmlEvent htmlEvent, DirectEventHandler handler) : this(target, handler)
        {
            this.HtmlEvent = htmlEvent;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DirectEvent(string target, string eventName, DirectEventHandler handler) : this(target, handler)
        {
            this.EventName = eventName;
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
		[Description("")]
        public string EventID
        {
            get
            {
                return string.Concat(this.Target.GetHashCode(), "_", this.EventName.IsEmpty() ? "click" : this.EventName);
            }
        }

        /// <summary>
        /// The target to attach this DirectEvent to. The target can be an ID, an ID token (#{Button1}), or a Select token (${div.box}).
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The target to attach this DirectEvent to. The target can be an ID, an ID token (#{Button1}), or a Select token (${div.box}).")]
        public string Target
        {
            get
            {
                return (string)this.ViewState["Target"] ?? "";
            }
            set
            {
                this.ViewState["Target"] = value;
            }
        }

        /// <summary>
        /// The name of the server-side Event to fire during the DirectEvent.
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The name of the server-side Event to fire during the DirectEvent.")]
        public string EventName
        {
            get
            {
                string o = this.ViewState["EventName"] as string;

                if (o.IsEmpty() && HttpContext.Current != null)
                {
                    return this.HtmlEvent.ToString().ToLower();
                }
                
                return o ?? "";
            }
            set
            {
                this.ViewState["EventName"] = value;
            }
        }

        /// <summary>
        /// The html event type to attach this DirectEvent to. Example 'click'.
        /// </summary>
        [DefaultValue(HtmlEvent.Click)]
        [NotifyParentProperty(true)]
        [Description("The html event type to attach this DirectEvent to. Example 'click'.")]
        public HtmlEvent HtmlEvent
        {
            get
            {
                object o = this.ViewState["HtmlEvent"];
                return o != null ? (HtmlEvent)o : HtmlEvent.Click;
            }
            set
            {
                this.ViewState["HtmlEvent"] = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class DirectEventCollection : StateManagedCollection<DirectEvent> { }
}
