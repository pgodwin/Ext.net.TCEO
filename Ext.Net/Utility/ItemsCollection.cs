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
using System.ComponentModel.Design;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ItemsCollection<T> : List<T> where T : Observable, IXObject
    {
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
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
        /// <param name="item"></param>
        [Description("")]
        new public void Add(T item)
        {
            this.CheckItem(item);

            if (this.BeforeItemAdd != null)
            {
                this.BeforeItemAdd(item);
            }
            
            base.Add(item);

            if (this.AfterItemAdd != null)
            {
                this.AfterItemAdd(item);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Add(IEnumerable<T> collection)
        {
            this.AddRange(collection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        [Description("")]
        new public void AddRange(IEnumerable<T> collection)
        {
            base.AddRange(collection);

            foreach (T item in collection)
            {
                if (this.AfterItemAdd != null)
                {
                    this.AfterItemAdd(item);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        [Description("")]
        new public void Insert(int index, T item)
        {
            this.CheckItem(item);

            if (this.BeforeItemAdd != null)
            {
                this.BeforeItemAdd(item);
            } 
            
            base.Insert(index, item);

            if (this.AfterItemAdd != null)
            {
                this.AfterItemAdd(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="collection"></param>
        [Description("")]
        new public void InsertRange(int index, IEnumerable<T> collection)
        {
            base.InsertRange(index, collection);

            foreach (T item in collection)
            {
                if (this.AfterItemAdd != null)
                {
                    this.AfterItemAdd(item);
                }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        [Description("")]
        new public void RemoveAt(int index)
        {
            T item = this[index];
            base.RemoveAt(index);

            if (this.AfterItemRemove != null)
            {
                this.AfterItemRemove(item);
            }
        }

        private void CheckItem(T item)
        {
            if (this.SingleItemMode && this.Count > 0)
            {
                throw new InvalidOperationException("Only one Component allowed in this Collection.");
            }

            Component cmp = item as Component;

            if (cmp != null)
            {
                cmp.AutoRender = false;
            }
        }

        private bool singleItemMode = false;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool SingleItemMode
        {
            get
            {
                return this.singleItemMode;
            }
            internal set
            {
                this.singleItemMode = value;
            }
        }

        internal delegate void BeforeItemAddHandler(T item);
        internal event BeforeItemAddHandler BeforeItemAdd;

        internal delegate void AfterItemAddHandler(T item);
        internal event AfterItemAddHandler AfterItemAdd;

        internal delegate void AfterItemRemoveHandler(T item);
        internal event AfterItemRemoveHandler AfterItemRemove;
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ItemTCollectionEditor : CollectionEditor
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ItemTCollectionEditor(Type type) : base(type) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool CanSelectMultipleInstances()
        {
            return false;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override Type[] CreateNewItemTypes()
        {
            return new Type[]
              {
                typeof(Panel),
                typeof(TabPanel)
              };
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override Type CreateCollectionItemType()
        {
            return typeof(Panel);
        }
    }
}