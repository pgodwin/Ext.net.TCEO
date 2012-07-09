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
using System.Web;
using System.Web.UI;
using System.Xml.Serialization;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public abstract partial class StateManagedItem : IStateManager, IXObject
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected StateManagedItem(Control owner) : this()
        {
            this.Owner = owner;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected new virtual bool DesignMode
        {
            get
            {
                try
                {
                    return HttpContext.Current == null;
                }
                catch (Exception)
                {
                    return true;
                }
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [XmlIgnore]
        [JsonIgnore]
		[Description("")]
        public virtual ConfigOptionsCollection ConfigOptions
        {
            get
            {
                return new ConfigOptionsCollection();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get
            {
                return ConfigOptionsExtraction.List;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("1. Item")]
        [Description("")]
        public virtual string InstanceOf
        {
            get
            {
                return "";
            }
        }

        internal static List<StateManagedItem> InstancesCache
        {
            get
            {
                if(HttpContext.Current != null)
                {
                    if(HttpContext.Current.Items["StateManagedItem_Cache"] == null)
                    {
                        HttpContext.Current.Items["StateManagedItem_Cache"] = new List<StateManagedItem>();
                    }

                    return (List<StateManagedItem>)HttpContext.Current.Items["StateManagedItem_Cache"];
                }

                return new List<StateManagedItem>();
            }
        }

        internal static void ClearCache()
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items["StateManagedItem_Cache"] = null;
            }
        }

        private bool listenPreRender = false;
        internal void RegisterDataBinding()
        {
            if (!this.listenPreRender && this.ResourceManager != null)
            {
                this.listenPreRender = true;
                this.ResourceManager.Page.PreRenderComplete += this.DataBindPoint;
            }
        }

        private bool dataBindRegistered;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected StateManagedItem()
        {
            if(this.ResourceManager == null)
            {
                StateManagedItem.InstancesCache.Add(this);
            }     
            else if (!ResourceManager.IsMono())
            {
                this.RegisterDataBinding();
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void EnsureDataBind()
        {
            XControl owner = this.Owner as XControl;

            if (!this.dataBindRegistered && (this.AutoDataBind || (owner != null && owner.AutoDataBind)))
            {
                this.dataBindRegistered = true;
                this.DataBind();
            }
        }

        void DataBindPoint(object sender, EventArgs e)
        {
            XControl owner = this.Owner as XControl;

            if (this.AutoDataBind || (owner != null && owner.AutoDataBind))
            {
                this.DataBind();
            }
        }

        private bool autoDataBind;
        
        /// <summary>
        /// 
        /// </summary>
        [Category("1. Item")]
        [DefaultValue(false)]
        [Description("")]
        public bool AutoDataBind
        {
            get
            {
                return this.autoDataBind;
            }
            set
            {
                this.autoDataBind = value;
                if (value && ResourceManager.IsMono() && this.ResourceManager != null)
                {
                    this.RegisterDataBinding();
                }
            }
        }

        ResourceManager rm;

        /// <summary>
        /// 
        /// </summary>
        [Category("1. Item")]
        [Description("")]
        public ResourceManager ResourceManager
        {
            get
            {
                if (this.rm == null)
                {
                    if (HttpContext.Current != null)
                    {
                        this.rm = ResourceManager.GetInstance(HttpContext.Current);
                    }
                }

                return this.rm;
            }
        }

        private Control owner;

        /// <summary>
        /// The Owner Control for this Listener.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Owner Control for this Listener.")]
        public Control Owner
        {
            get
            {
                if (this.owner == null)
                {
                    if (HttpContext.Current != null)
                    {
                        this.owner = ResourceManager.GetInstance(HttpContext.Current);
                        if (this.owner != null)
                        {
                            this.owner = this.owner.Page;
                        }
                    }

                    if (this.owner == null && HttpContext.Current != null && HttpContext.Current.CurrentHandler is Page)
                    {
                        this.owner = (Page)HttpContext.Current.CurrentHandler;
                    }
                }

                return this.owner;
            }
            internal set
            {
                this.owner = value;
            }
        }
        
        /// <summary>
        /// Does this object currently represent it's default state.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Does this object currently represent it's default state.")]
        public virtual bool IsDefault
        {
            get 
            {
                return false; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public T Apply<T>(IApply config) where T : StateManagedItem
        {
            return (T)this.Apply(config);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public object Apply(IApply config)
        {
            return ObjectUtils.Apply(this, config);
        }


        /*  ViewState
            -----------------------------------------------------------------------------------------------*/

        private StateBag viewstate;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected StateBag ViewState
        {
            get
            {
                if (this.viewstate == null)
                {
                    this.viewstate = new StateBag();
                    this.TrackViewState();
                }

                return this.viewstate;
            }
            set
            {
                this.viewstate = value;
            }
        }

        private bool trackingViewState = false;

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public bool IsTrackingViewState
        {
            get 
            { 
                return this.trackingViewState; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void LoadViewState(object state)
        {
            object[] states = state as object[];

            if (states != null)
            {
                foreach (Pair pair in states)
                {
                    switch((string)pair.First)
                    {
                        case "base":
                            ((IStateManager)this.ViewState).LoadViewState(pair.Second);
                            break;
                        case "vsMembers":
                            ViewStateProcessor.LoadViewState(this, pair.Second);
                            break;
                    }
                }
            }
            else
            {
                ((IStateManager)this.ViewState).LoadViewState(state);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual object SaveViewState()
        {
            List<Pair> state = new List<Pair>();
            object baseState = ((IStateManager)this.ViewState).SaveViewState();
            
            if (baseState != null)
            {
                state.Add(new Pair("base", baseState));
            }

            object vsMembers = ViewStateProcessor.SaveViewState(this);

            if (vsMembers != null)
            {
                state.Add(new Pair("vsMembers", vsMembers));
            }

            return state.Count == 0 ? null : state.ToArray();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void TrackViewState()
        {
            this.trackingViewState = true;
            ((IStateManager)this.ViewState).TrackViewState();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        bool IStateManager.IsTrackingViewState
        {
            get 
            { 
                return this.IsTrackingViewState; 
            }
        }

        void IStateManager.LoadViewState(object state)
        {
            this.LoadViewState(state);
        }

        object IStateManager.SaveViewState()
        {
            return this.SaveViewState();
        }

        void IStateManager.TrackViewState()
        {
            this.TrackViewState();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetDirty()
        {
            this.ViewState.SetDirty(true);
        }

        static readonly object DataBindingEvent = new object();

        EventHandlerList events;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected EventHandlerList Events
        {
            get
            {
                if (this.events == null)
                {
                    this.events = new EventHandlerList();
                }

                return this.events;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event EventHandler DataBinding
        {
            add
            {
                Events.AddHandler(DataBindingEvent, value);
            }
            remove
            {
                Events.RemoveHandler(DataBindingEvent, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnDataBinding(EventArgs e)
        {
            EventHandler handler = (EventHandler)(this.Events[DataBindingEvent]);

            if (handler != null)
            {
                handler(this, e);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
		[Description("")]
        public Control BindingContainer
        {
            get
            {
                Control container = this.owner != null ? this.Owner.NamingContainer : (this.ResourceManager != null ? this.ResourceManager.NamingContainer : null);

                if (container != null)
                {
                    container = container.BindingContainer;
                }

                return container;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void DataBind()
        {
            OnDataBinding(EventArgs.Empty);
        }
    }
}