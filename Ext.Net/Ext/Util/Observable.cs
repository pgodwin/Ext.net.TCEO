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
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Abstract base class that provides a common interface for publishing events
    /// </summary>
    [Meta]
    [Description("Abstract base class that provides a common interface for publishing events")]
    public abstract partial class Observable : XControl, ILazyItems
    {
        /*  ILazyItems
           -----------------------------------------------------------------------------------------------*/

        List<Observable> lazyItems;

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual List<Observable> LazyItems
        {
            get
            {
                if (this.lazyItems == null)
                {
                    this.lazyItems = new List<Observable>();
                }

                return this.lazyItems;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        protected virtual bool SingleItemMode
        {
            get
            {
                return false;
            }
        }
        
        private ConfigItemCollection customConfig;

        /// <summary>
        /// Collection of custom js config
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [ConfigOption("-", typeof(CustomConfigJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Collection of custom js config")]
        public virtual ConfigItemCollection CustomConfig
        {
            get
            {
                if (this.customConfig == null)
                {
                    this.customConfig = new ConfigItemCollection();
                }

                return this.customConfig;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.BeforeClientInit += Observable_BeforeClientInit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        void Observable_BeforeClientInit(Observable sender)
        {
            this.RegisterAttributes();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void RegisterAttributes()
        {
            foreach (string key in this.Attributes.Keys)
            {
                string value = this.Attributes[key];

                if (value != null && !this.CustomConfig.Contains(key))
                {
                    this.RegisterCustomAttribute(key, TokenUtils.ParseTokens(value, this));
                }
            }

            this.Attributes.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected virtual void RegisterCustomAttribute(string key, string value)
        {
            bool isDefaults = key.IndexOf("Default", StringComparison.CurrentCultureIgnoreCase) == 0;
            bool isOverride = key.IndexOf("X", StringComparison.CurrentCultureIgnoreCase) == 0;

            if (isDefaults)
            {
                key = key.Substring(7);
            }
            else if (isOverride)
            {
                key = key.Substring(1);
            }

            ConfigItem item = new ConfigItem();

            item.Name = key.ToLowerCamelCase();
            item.Mode = ParameterMode.Value;

            if (value.StartsWith("<raw>"))
            {
                item.Mode = ParameterMode.Raw;
                value = value.Remove(0, 5);
            }
            else if (value.StartsWith("<string>"))
            {
                item.Mode = ParameterMode.Value;
                value = value.Remove(0, value.StartsWith("<string><raw>") ? 13 : 8);
            }
            else
            {
                bool boolTest;
                double doubleTest;
                DateTime dateTest;

                if (bool.TryParse(value, out boolTest) || double.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out doubleTest))
                {
                    item.Mode = ParameterMode.Raw;
                }
                else if (DateTime.TryParse(value, System.Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTest))
                {
                    item.Mode = ParameterMode.Raw;
                    value = DateTimeUtils.DateNetToJs(dateTest);
                }
            }

            item.Value = value;

            if (this is ContainerBase && isDefaults)
            {
                ((ContainerBase)this).Defaults.Add(new Parameter(item.Name, item.Value, item.Mode));
            }
            else
            {
                this.CustomConfig.Add(item);
            }
        }

        /// <summary>
        /// The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.
        /// </summary>
        [Category("0. About")]
        [Description("The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.")]
        public virtual string XType
        {
            get
            {
                return "";
            }
        }

        private bool renderXType = true;

        /// <summary>
        /// 
        /// </summary>
        internal protected virtual bool RenderXType
        {
            get
            {
                return this.renderXType;
            }
            set
            {
                this.renderXType = value;
            }
        }
        
        /// <summary>
        /// The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child items of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.
        /// </summary>
        [ConfigOption("xtype")]
        [DefaultValue("")]
        [Category("2. Observable")]
        [Description("The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child items of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.")]
        protected virtual string XTypeProxy
        {
            get
            {
                if ((this.IsLazy || this.IsDynamicLazy || this.DesignMode) && this.RenderXType)
                {
                    string defaultType = "";

                    string xtype = this.XType;

                    if (this is Component)
                    {
                        ContainerBase ownerCt = ((Component)this).OwnerCt;

                        if (ownerCt != null)
                        {
                            defaultType = DefaultTypeConverter.GetXType(ownerCt.DefaultType);
                        }
                    }

                    return xtype.Equals(defaultType) ? "" : xtype;
                }

                return "";
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Used to define events on this Observable
        /// </summary>
        [Meta]
        [Description("Used to define events on this Observable")]
        public virtual void AddEvents(string events)
        {
            this.Call("addEvents", events);
        }

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        [Meta]
        [Description("Appends an event handler to this component")]
        public virtual void AddListener(string eventName, JFunction fn)
        {
            this.AddListener(eventName, fn.ToScript());
        }

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        [Meta]
        [Description("Appends an event handler to this component")]
        public virtual void AddListener(string eventName, JFunction fn, string scope)
        {
            this.AddListener(eventName, fn.ToScript(), scope);
        }

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        [Meta]
        [Description("Appends an event handler to this component")]
        public virtual void AddListener(string eventName, JFunction fn, string scope, HandlerConfig options)
        {
            this.AddListener(eventName, fn.ToScript(), scope, options);
        }

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        [Meta]
        [Description("Appends an event handler to this component")]
        public virtual void AddListener(string eventName, string fn)
        {
            fn = TokenUtils.ParseAndNormalize(fn, this).Trim('"');
            this.Call("on", eventName.ToLower(), new JRawValue(fn));
        }

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        [Meta]
        [Description("Appends an event handler to this component")]
        public virtual void AddListener(string eventName, string fn, string scope)
        {
            fn = TokenUtils.ParseAndNormalize(fn, this).Trim('"');
            this.Call("on", eventName.ToLower(), new JRawValue(fn), new JRawValue(scope));
        }

        /// <summary>
        /// Appends an event handler to this component
        /// </summary>
        [Meta]
        [Description("Appends an event handler to this component")]
        public virtual void AddListener(string eventName, string fn, string scope, HandlerConfig options)
        {
            fn = TokenUtils.ParseAndNormalize(fn, this).Trim('"');
            this.Call("on", eventName, new JRawValue(fn), new JRawValue(scope), new JRawValue(options.ToJsonString()));
        }

        /// <summary>
        /// Fires the specified event with the passed parameters (minus the event name)
        /// </summary>
        [Meta]
        [Description("Fires the specified event with the passed parameters (minus the event name)")]
        public virtual void FireEvent(string eventName, params object[] args)
        {
            StringBuilder sb = new StringBuilder(256);

            sb.AppendFormat("{0},", JSON.Serialize(eventName));

            if (args != null && args.Length > 0)
            {
                foreach (object arg in args)
                {
                    sb.AppendFormat("{0},", JSON.Serialize(arg));
                }
            }
            
            this.Call("fireEvent", new JRawValue(sb.ToString().LeftOfRightmostOf(',')));
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        [Meta]
        [Description("Appends an event handler to this element (shorthand for addListener)")]
        public virtual void On(string eventName, string fn)
        {
            this.AddListener(eventName, fn);
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        [Meta]
        [Description("Appends an event handler to this element (shorthand for addListener)")]
        public virtual void On(string eventName, string fn, string scope)
        {
            this.AddListener(eventName, fn, scope);
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        [Meta]
        [Description("Appends an event handler to this element (shorthand for addListener)")]
        public virtual void On(string eventName, string fn, string scope, HandlerConfig options)
        {
            this.AddListener(eventName, fn, scope, options);
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        [Meta]
        [Description("Appends an event handler to this element (shorthand for addListener)")]
        public virtual void On(string eventName, JFunction fn)
        {
            this.AddListener(eventName, "<raw>" + fn.ToScript());
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        [Meta]
        [Description("Appends an event handler to this element (shorthand for addListener)")]
        public virtual void On(string eventName, JFunction fn, string scope)
        {
            this.AddListener(eventName, "<raw>" + fn.ToScript(), scope);
        }

        /// <summary>
        /// Appends an event handler to this element (shorthand for addListener)
        /// </summary>
        [Meta]
        [Description("Appends an event handler to this element (shorthand for addListener)")]
        public virtual void On(string eventName, JFunction fn, string scope, HandlerConfig options)
        {
            this.AddListener(eventName, "<raw>" + fn.ToScript(), scope, options);
        }

        /// <summary>
        /// Removes all listeners for this object
        /// </summary>
        [Meta]
        [Description("Removes all listeners for this object")]
        public virtual void PurgeListeners()
        {
            this.Call("purgeListeners");
        }

        /// <summary>
        /// Removes a listener
        /// </summary>
        [Meta]
        [Description("Removes a listener")]
        public virtual void RemoveListener(string eventName, string fn)
        {
            this.Call("un", eventName.ToLower(), new JRawValue(fn));
        }

        /// <summary>
        /// Removes a listener
        /// </summary>
        [Meta]
        [Description("Removes a listener")]
        public virtual void RemoveListener(string eventName, string fn, string scope)
        {
            this.Call("un", eventName.ToLower(), new JRawValue(fn), new JRawValue(scope));
        }

        /// <summary>
        /// Resume firing events. (see suspendEvents)
        /// </summary>
        [Meta]
        [Description("Resume firing events. (see suspendEvents)")]
        public virtual void ResumeEvents()
        {
            this.Call("resumeEvents");
        }

        /// <summary>
        /// Suspend the firing of all events. (see resumeEvents)
        /// </summary>
        /// <param name="queueSuspended">Pass as true to queue up suspended events to be fired after the resumeEvents call instead of discarding all suspended events;</param>
        [Meta]
        [Description("Suspend the firing of all events. (see resumeEvents)")]
        public virtual void SuspendEvents(bool queueSuspended)
        {
            this.Call("suspendEvents", queueSuspended);
        }

        /// <summary>
        /// Removes a listener (shorthand for removeListener)
        /// </summary>
        [Meta]
        [Description("Removes a listener (shorthand for removeListener)")]
        public virtual void Un(string eventName, string fn)
        {
            this.RemoveListener(eventName, fn);
        }

        /// <summary>
        /// Removes a listener (shorthand for removeListener)
        /// </summary>
        [Meta]
        [Description("Removes a listener (shorthand for removeListener)")]
        public virtual void Un(string eventName, string fn, string scope)
        {
            this.RemoveListener(eventName, fn, scope);
        }


        /*  Client Initialization
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void OnBeforeClientInit(Observable sender) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnAfterClientInit(Observable sender) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void OnBeforeClientInitializedHandler(Observable sender);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void OnAfterClientInitializedHandler(Observable sender);

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public event OnBeforeClientInitializedHandler BeforeClientInit;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public event OnAfterClientInitializedHandler AfterClientInit;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnBeforeClientInitHandler()
        {
            if (this.BeforeClientInit != null)
            {
                this.BeforeClientInit(this);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnAfterClientInitHandler()
        {
            if (this.AfterClientInit != null)
            {
                this.AfterClientInit(this);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected internal override void OnClientInit(bool reinit)
        {
            this.OnBeforeClientInitHandler();
            base.OnClientInit(reinit);
            this.OnAfterClientInitHandler();
        }

        private const string DirectEventsKey = "DirectEvents";

        private ComponentDirectEvents GetDirectEvents()
        {
            // assumption: server side listeners class should have name 'DirectEvents'
            PropertyInfo ssl = this.GetType().GetProperty(Observable.DirectEventsKey);

            if (ssl == null)
            {
                return null;
            }

            return ssl.GetValue(this, null) as ComponentDirectEvents;
        }

        internal void FireAsyncEvent(string eventName, ParameterCollection extraParams)
        {
            ComponentDirectEvents directevents = this.GetDirectEvents();

            if (directevents == null)
            {
                throw new HttpException("The control has no DirectEvents");
            }

            PropertyInfo eventListenerInfo = directevents.GetType().GetProperty(eventName);

            if (eventListenerInfo.PropertyType != typeof(ComponentDirectEvent))
            {
                throw new HttpException("The control '{1}' does not have an DirectEvent with the name '{0}'".FormatWith(eventName, this.ClientID));
            }

            ComponentDirectEvent directevent = eventListenerInfo.GetValue(directevents, null) as ComponentDirectEvent;

            if (directevent == null || directevent.IsDefault)
            {
                throw new HttpException("The control '{1}' does not have an DirectEvent with the name '{0}' or the handler is absent".FormatWith(eventName, this.ClientID));
            }

            DirectEventArgs e = new DirectEventArgs(extraParams);
            directevent.Owner = this;
            directevent.OnEvent(e);
        }

        private bool eventsInit = false;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            if (!RequestManager.IsAjaxRequest || this.IsDynamic)
            {
                if (!this.eventsInit && (!RequestManager.IsMicrosoftAjaxRequest || this.IsInUpdatePanelRefresh))
                {
                    this.BeforeClientInit += OnBeforeClientInit;
                    this.AfterClientInit += OnAfterClientInit;
                    this.eventsInit = true;
                }
            }

            base.OnPreRender(e);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void PreRenderAction()
        {
            if (!RequestManager.IsAjaxRequest && !this.eventsInit && (this.Visible && !RequestManager.IsMicrosoftAjaxRequest || this.IsInUpdatePanelRefresh || this.IsDynamic))
            {
                this.BeforeClientInit += OnBeforeClientInit;
                this.AfterClientInit += OnAfterClientInit;
                this.eventsInit = true;
            }

            base.PreRenderAction();
        }

        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void AfterItemAdd(Observable item)
        {
            if (!this.Controls.Contains(item))
            {
                this.Controls.Add(item);
            }

            if (!this.LazyItems.Contains(item))
            {
                this.LazyItems.Add(item);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void AfterItemRemove(Observable item)
        {
            if (this.Controls.Contains(item))
            {
                this.Controls.Remove(item);
            }

            if (this.LazyItems.Contains(item))
            {
                this.LazyItems.Remove(item);
            }
        }
    }
}
