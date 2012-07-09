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
using System.Collections.ObjectModel;
using System.ComponentModel.Design;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ItemCollection : Collection<Component>
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void InsertItem(int index, Component item)
        {
            this.CheckItem(item);
            base.InsertItem(index, item);

            if (this.AfterInsert != null)
            {
                this.AfterInsert(item); 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void SetItem(int index, Component item)
        {
            this.CheckItem(item);
            base.SetItem(index, item);

            if (this.AfterInsert != null)
            {
                this.AfterInsert(item);
            }
        }

        private void CheckItem(Component item)
        {
            if (this.SingleItemMode && this.Count>0)
            {
                throw new InvalidOperationException("Only one Component allowed in the Items Collection");
            }
            
            item.AutoRender = false;

            if (item is Viewport || item is Window)
            {
                throw new InvalidCastException("Invalid type of Control ({0}). This type can not be added to Items Collection".FormatWith(item.GetType()));
            }
        }

        private bool singleItemMode;

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

        internal delegate void AfterInsertHandler(Component item);
        internal event AfterInsertHandler AfterInsert;
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ItemCollectionEditor : CollectionEditor
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ItemCollectionEditor(Type type) : base(type) {}

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