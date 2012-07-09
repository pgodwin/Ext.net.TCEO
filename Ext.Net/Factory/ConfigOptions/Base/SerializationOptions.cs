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
using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class SerializationOptions
    {
        private readonly JsonMode mode = JsonMode.Value;
        private readonly string name = "";
        private readonly Type jsonConverter;
        private readonly int priority;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SerializationOptions() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SerializationOptions(string name)
        {
            this.name = name;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SerializationOptions(string name, int priority)
        {
            this.name = name;
            this.priority = priority;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SerializationOptions(JsonMode mode)
        {
            this.mode = mode;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SerializationOptions(JsonMode mode, int priority)
        {
            this.mode = mode;
            this.priority = priority;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SerializationOptions(string name, JsonMode mode)
        {
            this.name = name;
            this.mode = mode;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SerializationOptions(string name, JsonMode mode, int priority)
        {
            this.name = name;
            this.mode = mode;
            this.priority = priority;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SerializationOptions(Type jsonConverter)
        {
            this.name = "";

            if (!jsonConverter.IsSubclassOf(typeof(ExtJsonConverter)))
            {
                throw new ArgumentException("Parameter must be subclass of ExtJsonConverter", "jsonConverter");
            }

            this.jsonConverter = jsonConverter;
            this.mode = JsonMode.Custom;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SerializationOptions(Type jsonConverter, int priority) : this(jsonConverter)
        {
            this.priority = priority;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SerializationOptions(string name, Type jsonConverter)
        {
            this.name = name;

            if (!jsonConverter.IsSubclassOf(typeof(ExtJsonConverter)))
            {
                throw new ArgumentException("Parameter must be subclass of ExtJsonConverter", "jsonConverter");
            }

            this.jsonConverter = jsonConverter;
            this.mode = JsonMode.Custom;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SerializationOptions(string name, Type jsonConverter, int priority) : this(jsonConverter)
        {
            this.priority = priority;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Type JsonConverter
        {
            get { return jsonConverter; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public JsonMode Mode
        {
            get { return this.mode; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Name
        {
            get { return this.name; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int Priority
        {
            get
            {
                return priority;
            }
        }
    }
}