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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Abstract base class for reading structured data from a data source and
    /// converting it into an object containing RecordField objects and metadata
    /// for use by an Store. This class is intended to be extended and should
    /// not be created directly. For existing implementations, see ArrayReader,
    /// JsonReader and XmlReader.
    /// </summary>
    [Meta]
    [Description("Abstract base class for reading structured data from a data source and converting it into an object containing RecordField objects and metadata for use by an Store.")]
    public abstract partial class DataReader : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public abstract string IDField
        { 
            get;
        }
        
        private RecordFieldCollection fields;

        /// <summary>
        /// An array of field definition objects
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.AlwaysArray)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Either a Collection of RecordField definition objects")]
        public virtual RecordFieldCollection Fields
        {
            get
            {
                if (fields == null)
                {
                    fields = new RecordFieldCollection();
                }

                return fields;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [ConfigOption("fields", JsonMode.Raw)]
		[Description("")]
        protected virtual string EmptyFields
        {
            get
            {
                if (this.Fields.Count == 0)
                {
                    return "[]";
                }

                return "";
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("")]
        [ConfigOption]
		[Description("")]
        public virtual string MessageProperty
        {
            get
            {
                object obj = this.ViewState["MessageProperty"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                this.ViewState["MessageProperty"] = value;
            }
        }
    }
}
