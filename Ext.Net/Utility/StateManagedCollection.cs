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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public abstract partial class StateManagedCollection<T> : IList<T>, IStateManager, IXObject, IList where T : StateManagedItem
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

        private Control owner;

        /// <summary>
        /// The Owner Control for this collection.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The Owner Control for this collection.")]
        public Control Owner
        {
            get
            {
                return this.owner;
            }
            internal set
            {
                this.owner = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual bool CreateOnLoading
        {
            get
            {
                return false;
            }
        }

        private readonly List<T> items = new List<T>();

        private bool tracking;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual int IndexOf(T item)
        {
            return this.items.IndexOf(item);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Sort()
        {
            items.Sort();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Sort(Comparison<T> comparison)
        {
            items.Sort(comparison);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Sort(Comparer<T> comparer)
        {
            items.Sort(comparer);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Insert(int index, T item)
        {
            if (this.Owner != null && !(this.Owner is Page))
            {
                item.Owner = this.Owner;
            }
            this.CheckCount();

            if (this.AfterItemAdd != null)
            {
                this.AfterItemAdd(item);
            }
            this.items.Insert(index, item);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void RemoveAt(int index)
        {
            if (this.AfterItemRemove != null)
            {
                this.AfterItemRemove(this.items[index]);
            }
            this.items.RemoveAt(index);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public T this[int index]
        {
            get { return this.items[index]; }
            set { this.items[index] = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Add(T item)
        {
            if (this.Owner != null && !(this.Owner is Page))
            {
                item.Owner = this.Owner;
            }

            this.CheckCount();

            this.items.Add(item);
            
            if (this.AfterItemAdd != null)
            {
                this.AfterItemAdd(item);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void AddRange(IEnumerable<T> collection)
        {
            if (this.Owner != null && !(this.Owner is Page))
            {
                foreach (T item in collection)
                {
                    item.Owner = this.Owner;
                }
            }
            this.CheckCount();

            if (this.AfterItemAdd != null)
            {
                foreach (T item in collection)
                {
                    this.AfterItemAdd(item);
                }
            }
            this.items.AddRange(collection);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void Clear()
        {
            this.items.Clear();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool Contains(T item)
        {
            return this.items.Contains(item);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual int Count
        {
            get { return this.items.Count; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool IsReadOnly
        {
            get { return false; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool Remove(T item)
        {
            if (this.AfterItemRemove != null)
            {
                this.AfterItemRemove(item);
            }

            return this.items.Remove(item);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this.items).GetEnumerator();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool IsTrackingViewState
        {
            get { return tracking; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void LoadViewState(object state)
        {
            if (state != null)
            {
                Pair p = state as Pair;

                if (p != null)
                {
                    int count = (int)p.First;
                    object[] savedItems = (object[])p.Second;

                    if (!this.CreateOnLoading)
                    {
                        for (int i = 0; i < this.items.Count; i++)
                        {
                            this.items[i].LoadViewState(savedItems[i]);
                        }
                    }
                    else
                    {
                        items.Clear();
                        foreach (object savedState in savedItems)
                        {
                            //T item = new T();
                            T item = Activator.CreateInstance<T>();
                            item.TrackViewState();
                            item.LoadViewState(savedState);
                            items.Add(item);
                            if (this.AfterItemAdd != null)
                            {
                                this.AfterItemAdd(item);
                            }
                        }
                    }
                    this.CheckCount();
                }
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual object SaveViewState()
        {
            if (this.items.Count == 0)
            {
                return null;
            }
            
            object[] saveList = new object[this.items.Count];
            for (int i = 0; i < this.items.Count; i++)
            {
                T item = this.items[i];
                SetItemDirty(item);
                saveList[i] = item.SaveViewState();
            }

            return new Pair(this.items.Count, saveList);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void TrackViewState()
        {
            this.tracking = true;
            foreach (IStateManager item in this.items)
            {
                item.TrackViewState();
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void SetDirty()
        {
            foreach (T item in this.items)
            {
                SetItemDirty(item);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void SetItemDirty(T item)
        {
            item.SetDirty();
        }

        int IList.Add(object value)
        {
            Add(value as T);

            return Count - 1;
        }

        void IList.Clear()
        {
            Clear();
        }

        bool IList.Contains(object value)
        {
            return Contains(value as T);
        }

        int IList.IndexOf(object value)
        {
            return IndexOf(value as T);
        }

        void IList.Insert(int index, object value)
        {
            Insert(index, value as T);
        }

        bool IList.IsFixedSize
        {
            get { return false; }
        }

        bool IList.IsReadOnly
        {
            get { return IsReadOnly; }
        }

        void IList.Remove(object value)
        {
            Remove(value as T);
        }

        void IList.RemoveAt(int index)
        {
            RemoveAt(index);
        }

        object IList.this[int index]
        {
            get { return this[index]; }
            set { this[index] = value as T; }
        }

        void ICollection.CopyTo(Array array, int index) { }

        int ICollection.Count
        {
            get { return Count; }
        }

        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        object ICollection.SyncRoot
        {
            get { return null; }
        }

        private bool singleItemMode = false;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool SingleItemMode
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

        private void CheckCount()
        {
            if (this.SingleItemMode && this.items.Count > 0)
            {
                throw new InvalidOperationException("Only one Control allowed in this collection");
            }
        }

        public delegate void AfterItemAddHandler(T item);
        public event AfterItemAddHandler AfterItemAdd;

        public delegate void AfterItemRemoveHandler(T item);
        public event AfterItemRemoveHandler AfterItemRemove;
    }
}