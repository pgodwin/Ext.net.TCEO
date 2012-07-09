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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class SingleItemCollection<T> : Collection<T>, IXObject
    {
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection list = new ConfigOptionsCollection();

                return list;
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
		[Description("")]
        protected override void InsertItem(int index, T item)
        {
            this.CheckCount();
            base.InsertItem(index, item);

            if (this.AfterItemAdd != null)
            {
                this.AfterItemAdd(item);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void SetItem(int index, T item)
        {
            this.CheckCount();
            base.SetItem(index, item);

            if (this.AfterItemAdd != null)
            {
                this.AfterItemAdd(item);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual string ExcessItemsMessage
        {
            get
            {
                return "Only one item can be added to this Items Collection.";
            }
        }

        private void CheckCount()
        {
            if (Count > 0)
            {
                throw new ExcessItemsException(ExcessItemsMessage);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        new public void Clear()
        {
            foreach (T item in this)
            {
                if (this.AfterItemRemove != null)
                {
                    this.AfterItemRemove(item);
                }
            }

            base.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        new public void Remove(T item)
        {
            base.Remove(item);

            if (this.AfterItemRemove != null)
            {
                this.AfterItemRemove(item);
            }
        }

        public delegate void AfterItemAddHandler(T item);
        public event AfterItemAddHandler AfterItemAdd;

        public delegate void AfterItemRemoveHandler(T item);
        public event AfterItemRemoveHandler AfterItemRemove;
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ExcessItemsException : Exception
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ExcessItemsException(string message) : base(message) { }
    }
}