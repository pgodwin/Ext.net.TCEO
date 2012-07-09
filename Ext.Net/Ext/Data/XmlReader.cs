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

namespace Ext.Net
{
    /// <summary>
    /// Data reader class to create an Array of Ext.data.Record objects from an XML document
    /// based on mappings in a provided Ext.data.Record constructor.
    ///
    /// Note that in order for the browser to parse a returned XML document, the Content-Type
    /// header in the HTTP response must be set to "text/xml".
    /// </summary>
    [Meta]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Description("Data reader class to create an Array of Ext.data.Record objects from an XML document based on mappings in a provided Ext.data.Record constructor.")]
    public partial class XmlReader : DataReader
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public XmlReader() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.data.XmlReader";
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
                return this.IDPath;
            }
        }
        
        /// <summary>
        /// The DomQuery path relative from the record element to the element that contains a record identifier value.
        /// </summary>
        [Meta]
        [ConfigOption("idPath")]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The DomQuery path relative from the record element to the element that contains a record identifier value.")]
        public virtual string IDPath
        {
            get
            {
                object obj = this.ViewState["IDPath"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                this.ViewState["IDPath"] = value;
            }
        }
        
        /// <summary>
        /// The DomQuery path to the repeated element which contains record information.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The DomQuery path to the repeated element which contains record information.")]
        public virtual string Record
        {
            get
            {
                return (string)this.ViewState["Record"] ?? "";
            }
            set
            {
                this.ViewState["Record"] = value;
            }
        }

        /// <summary>
        /// The DomQuery path to the success attribute used by forms.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The DomQuery path to the success attribute used by forms.")]
        public virtual string Success
        {
            get
            {
                return (string)this.ViewState["Success"] ?? "";
            }
            set
            {
                this.ViewState["Success"] = value;
            }
        }

        /// <summary>
        /// The DomQuery path from which to retrieve the total number of records in the dataset.
        /// This is only needed if the whole dataset is not passed in one go, but is being paged
        /// from the remote server.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The DomQuery path from which to retrieve the total number of records in the dataset. This is only needed if the whole dataset is not passed in one go, but is being paged from the remote server.")]
        public virtual string TotalProperty
        {
            get
            {
                return (string)this.ViewState["TotalProperty"] ?? "";
            }
            set
            {
                this.ViewState["TotalProperty"] = value;
            }
        }
    }
}
