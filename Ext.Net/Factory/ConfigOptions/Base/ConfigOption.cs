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

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public class ConfigOptionsCollection : Dictionary<string, ConfigOption>
    {
        private SortedDictionary<int, ConfigOption> priorityProperties = new SortedDictionary<int, ConfigOption>();

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SortedDictionary<int, ConfigOption> PriorityProperties
        {
            get
            {
                return this.priorityProperties;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        [Description("")]
        new public void Add(string key, ConfigOption value)
        {
            if(value.Serialization.Priority != 0)
            {
                if (this.priorityProperties.ContainsKey(value.Serialization.Priority))
                {
                    this.priorityProperties.Remove(value.Serialization.Priority);
                }

                this.priorityProperties.Add(value.Serialization.Priority, value);
            }
            
            if (this.ContainsKey(key))
            {
                this.Remove(key);
            }

            if (value.Serialization.Priority == 0)
            {
                base.Add(key, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Add(string propertyName, object defaultValue, object value)
        {
            this.Add(propertyName, new ConfigOption(propertyName, null, defaultValue, value));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public class ConfigOption
    {
        private readonly string propertyName;
        private SerializationOptions serialization;
        private readonly object defaultValue;
        private readonly object value;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigOption(string propertyName, SerializationOptions serialization, object defaultValue, object value)
        {
            
            this.propertyName = propertyName;
            this.serialization = serialization;
            this.defaultValue = defaultValue;
            this.value = value;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string PropertyName
        {
            get 
            { 
                return propertyName; 
            }
        }

        private static readonly SerializationOptions defaultSerialization = new SerializationOptions();

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SerializationOptions Serialization
        {
            get 
            {
                return serialization ?? defaultSerialization; 
            }
            internal set
            {
                serialization = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public object DefaultValue
        {
            get 
            { 
                return defaultValue; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Name
        {
            get
            {
                if (this.Serialization != null)
                {
                    if (this.Serialization.Name.IsNotEmpty())
                    {
                        return this.Serialization.Name;
                    }
                }

                return this.PropertyName;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public object Value
        {
            get
            {
                return this.value;
            }
        }
    }
}