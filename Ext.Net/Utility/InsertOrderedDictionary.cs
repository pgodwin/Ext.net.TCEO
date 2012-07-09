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

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public class InsertOrderedDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            this.insertList.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public new void Clear()
        {
            base.Clear();
            this.insertList.Clear();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public new bool Remove(TKey key)
        {
            bool result = base.Remove(key);

            if (result)
            {
                foreach (KeyValuePair<TKey, TValue> pair in this.insertList)
                {
                    if (pair.Key.Equals(key))
                    {
                        this.insertList.Remove(pair);
                        break;
                    }
                }
            }

            return result;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public new List<KeyValuePair<TKey, TValue>>.Enumerator GetEnumerator()
        {
            return this.insertList.GetEnumerator();
        }

        private readonly List<KeyValuePair<TKey, TValue>> insertList = new List<KeyValuePair<TKey, TValue>>();

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ReadOnlyCollection<KeyValuePair<TKey, TValue>> InsertList
        {
            get
            {
                return this.insertList.AsReadOnly();
            }
        }
    }
}
