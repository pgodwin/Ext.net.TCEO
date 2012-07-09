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
using System.Reflection;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    [TypeConverter(typeof(ListenersConverter))]
    [Description("")]
    public abstract partial class ComponentListeners : StateManagedItem
    {
        private static readonly Dictionary<string, List<ListenerPropertyInfo>> propertiesCache = new Dictionary<string, List<ListenerPropertyInfo>>();
        private static readonly object syncObj = new object();

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void ClearListeners()
        {
            foreach (ListenerTriplet listener in this.Listeners)
            {
                listener.Listener.Clear();
            }
        }

        private List<ListenerPropertyInfo> ListenerProperties
        {
            get
            {
                string fullName = this.GetType().FullName;

                if (propertiesCache.ContainsKey(fullName))
                {
                    return propertiesCache[fullName];
                }

                lock (syncObj)
                {
                    if (propertiesCache.ContainsKey(fullName))
                    {
                        return propertiesCache[fullName];
                    }

                    List<ListenerPropertyInfo> list = new List<ListenerPropertyInfo>();
                    PropertyInfo[] result = this.GetType().GetProperties();

                    foreach (PropertyInfo property in result)
                    {
                        if (property.PropertyType == typeof(ComponentListener))
                        {
                            ConfigOptionAttribute config = ClientConfig.GetClientConfigAttribute(property);
                            list.Add(new ListenerPropertyInfo(property, config));
                        }
                    }

                    propertiesCache.Add(fullName, list);

                    return list;
                }
            }
        }

        private List<ListenerTriplet> listeners;

        private List<ListenerTriplet> Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new List<ListenerTriplet>();

                    foreach (ListenerPropertyInfo property in this.ListenerProperties)
                    {
                        ComponentListener value =  property.PropertyInfo.GetValue(this, null) as ComponentListener;

                        if (value != null)
                        {
                            this.listeners.Add(new ListenerTriplet(property.PropertyInfo.Name, value, property.Attribute));    
                        }
                    }
                }

                return this.listeners;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override object SaveViewState()
        {
            ResourceManager rm = this.ResourceManager;

            if (rm != null && !rm.ManageEventsViewState)
            {
                return base.SaveViewState();
            }

            List<object> states = new List<object>();
            object baseState = base.SaveViewState();

            if (baseState != null)
            {
                states.Add(new Pair("base", baseState)); 
            }

            foreach (ListenerTriplet triplet in this.Listeners)
            {
                object listenerState = triplet.Listener.SaveViewState();

                if (listenerState != null)
                {
                    states.Add(new Pair(triplet.Name, listenerState));  
                }
            }

            return states.Count == 0 ? null : states.ToArray();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void LoadViewState(object state)
        {
            object[] states = state as object[];

            ResourceManager rm = this.ResourceManager;

            if (rm != null && !rm.ManageEventsViewState)
            {
                base.LoadViewState(state);  
            }

            if (states != null)
            {
                foreach (Pair pair in states)
                {
                    string listenerName = (string)pair.First;
                    object listenerState = pair.Second;

                    if (listenerName == "base")
                    {
                        base.LoadViewState(listenerState);
                    }
                    else
                    {
                        PropertyInfo property = this.GetType().GetProperty(listenerName);

                        if (property == null)
                        {
                            throw new InvalidOperationException("Can't find the property '{0}'".FormatWith(listenerName));
                        }

                        ComponentListener componentListener = (ComponentListener)property.GetValue(this, null);

                        if (componentListener != null)
                        {
                            componentListener.LoadViewState(listenerState); 
                        }
                    }
                }
            }
            else
            {
                base.LoadViewState(state);  
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ListenerTriplet
    {
        private readonly string name;
        private readonly ComponentListener listener;
        private readonly ConfigOptionAttribute attribute;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ListenerTriplet(string name, ComponentListener listener, ConfigOptionAttribute attribute)
        {
            this.name = name;
            this.listener = listener;
            this.attribute = attribute;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Name
        {
            get { return name; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ComponentListener Listener
        {
            get { return listener; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOptionAttribute Attribute
        {
            get { return attribute; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ListenerPropertyInfo
    {
        private readonly PropertyInfo propertyInfo;
        private readonly ConfigOptionAttribute attribute;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ListenerPropertyInfo(PropertyInfo propertyInfo, ConfigOptionAttribute attribute)
        {
            this.propertyInfo = propertyInfo;
            this.attribute = attribute;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public PropertyInfo PropertyInfo
        {
            get { return propertyInfo; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOptionAttribute Attribute
        {
            get { return attribute; }
        }
    }
}