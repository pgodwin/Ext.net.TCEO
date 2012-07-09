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
using System.IO;
using System.Text;
using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class DragDropGroups : StateManagedCollection<DragDropGroup>
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool this[string name]
        {
            get
            {
                foreach (DragDropGroup group in this)
                {
                    if (group.Name == name)
                    {
                        return group.Allow;
                    }
                }

                throw new Exception("Group was not found");
            }
            set
            {
                foreach (DragDropGroup group in this)
                {
                    if (group.Name == name)
                    {
                        group.Allow = value;
                        return;
                    }
                }

                this.Add(new DragDropGroup(name, value));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DragDropGroup GetGroup(string name)
        {
            foreach (DragDropGroup group in this)
            {
                if (group.Name == name)
                {
                    return group;
                }
            }

            return null;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToString()
        {
            if (this.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonTextWriter writer = new JsonTextWriter(sw);

            writer.WriteStartObject();

            foreach (DragDropGroup group in this)
            {
                writer.WritePropertyName(group.Name);
                writer.WriteValue(group.Allow);
            }

            writer.WriteEndObject();
            writer.Flush();

            return sw.GetStringBuilder().ToString();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class DragDropGroup : StateManagedItem
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public DragDropGroup()
        {
        }

        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DragDropGroup(string name, bool allow)
        {
            this.Name = name;
            this.Allow = allow;
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Description("")]
        public string Name
        {
            get
            {
                return (string)this.ViewState["Name"] ?? "";
            }
            set
            {
                this.ViewState["Name"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Description("")]
        public bool Allow
        {
            get
            {
                object obj = this.ViewState["Allow"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["Allow"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToString()
        {
            return this.Name.ConcatWith(":", JSON.Serialize(this.Allow));
        }
    }
}