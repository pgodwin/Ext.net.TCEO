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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Data reader class to create an Array of Ext.data.Record objects from an Array.
    /// Each element of that Array represents a row of data fields. The fields are pulled
    /// into a Record object using as a subscript, the mapping property of the field
    /// definition if it exists, or the field's ordinal position in the definition.
    /// </summary>
    [Meta]
    [Description("Data reader class to create an Array of Ext.data.Record objects from an Array.")]
    public partial class ArrayReader : JsonReader
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ArrayReader() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.data.ArrayReader";
            }
        }

        /// <summary>
        /// [id] Name of the property within a row object that contains a record identifier value. Defaults to id
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("[id] Name of the property within a row object that contains a record identifier value. Defaults to id")]
        public override string IDProperty
        {
            get
            {
                return (string)this.ViewState["IDProperty"] ?? "";
            }
            set
            {
                this.ViewState["IDProperty"] = value;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override string IDField
        {
            get
            {
                if (this.IDProperty.IsNotEmpty())
                {
                    return this.IDProperty;
                }

                if (this.IDIndex < 0 || this.IDIndex >= this.Fields.Count)
                {
                    return "";
                }

                return this.Fields[this.IDIndex].Name;
            }
        }
        
        /// <summary>
        /// The subscript within row Array that provides an ID for the Record.
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [Description("The subscript within row Array that provides an ID for the Record.")]
        public int IDIndex
        {
            get
            {
                object obj = this.ViewState["IDIndex"];
                return obj == null ? -1 : (int)obj;
            }
            set
            {
                this.ViewState["IDIndex"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("idIndex")]
        [DefaultValue(-1)]
		[Description("")]
        protected int IDIndexProxy
        {
            get
            {
                if (this.IDIndex < 0)
                {
                    if (this.IDProperty.IsNotEmpty())
                    {
                        for (int i = 0; i < this.Fields.Count; i++)
                        {
                            if (this.Fields[i].Name == this.IDProperty)
                            {
                                return i;
                            }
                        }
                    }
                    
                    return -1;
                }

                if (this.IDIndex < this.Fields.Count)
                {
                    return this.IDIndex;
                }

                throw new InvalidOperationException("Invalid index in the IDIndex of ArrayReader");
            }
        }
    }
}
