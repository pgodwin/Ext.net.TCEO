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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    public abstract partial class DataViewBase : BoxComponentBase, IStore
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity++;

                baseList.Add(XControl.ExtNetDataItem);

                return baseList;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            this.CheckProperties();
            this.CheckStore();
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void CheckStore()
        {
            if (this.IsDynamic && !string.IsNullOrEmpty(this.StoreID))
            {
                return;
            }

            if (this.GetStore() == null)
            {
                throw new StoreNotFoundException("Please define a store for the DataView with ID='" + this.ID + "'");
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void CheckProperties()
        {
            //Verify.IsNotNull(this.ItemSelector, "ItemSelector");
            //Verify.IsNotNull(this.Template.Text, "Template.Text");

            if (this.ItemSelector.IsEmpty())
            {
                throw new ArgumentNullException("ItemSelector", "The ItemSelector can not be empty");
            }

            if (this.Template.Html.IsEmpty())
            {
                throw new ArgumentNullException("Template", "The Template can not be empty");
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnBeforeClientInitHandler()
        {
            if (this.StoreID.IsNotEmpty() && this.Store.Primary != null)
            {
                throw new Exception(string.Format("Please do not set both the StoreID property on {0} and <Store> inner property at the same time.", this.ID));
                
            }
            
            base.OnBeforeClientInitHandler();
            this.PrepareData.Args = new string[] {"data"};
        }

        /// <summary>
        /// True to defer emptyText being applied until the store's first load
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DataView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to defer emptyText being applied until the store's first load")]
        public virtual bool DeferEmptyText
        {
            get
            {
                object obj = this.ViewState["DeferEmptyText"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["DeferEmptyText"] = value;
            }
        }

        /// <summary>
        /// The text to display in the view when there is no data to display (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DataView")]
        [DefaultValue("")]
        [Description("The text to display in the view when there is no data to display (defaults to '').")]
        public virtual string EmptyText
        {
            get
            {
                object obj = this.ViewState["EmptyText"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["EmptyText"] = value;
            }
        }

        /// <summary>
        /// This is a required setting. A simple CSS selector (e.g. div.some-class or span:first-child) that will be used to determine what nodes this DataView will be working with.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DataView")]
        [DefaultValue("")]
        [Description("This is a required setting. A simple CSS selector (e.g. div.some-class or span:first-child) that will be used to determine what nodes this DataView will be working with.")]
        public virtual string ItemSelector
        {
            get
            {
                object obj = this.ViewState["ItemSelector"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["ItemSelector"] = value;
            }
        }

        /// <summary>
        /// A string to display during data load operations (defaults to undefined). If specified, this text will be displayed in a loading div and the view's contents will be cleared while loading, otherwise the view's contents will continue to display normally until the new data is loaded and the contents are replaced.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DataView")]
        [DefaultValue("")]
        [Description("A string to display during data load operations (defaults to undefined). If specified, this text will be displayed in a loading div and the view's contents will be cleared while loading, otherwise the view's contents will continue to display normally until the new data is loaded and the contents are replaced.")]
        public virtual string LoadingText
        {
            get
            {
                object obj = this.ViewState["LoadingText"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["LoadingText"] = value;
            }
        }

        /// <summary>
        /// True to allow selection of more than one item at a time, false to allow selection of only a single item at a time or no selection at all, depending on the value of singleSelect (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DataView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to allow selection of more than one item at a time, false to allow selection of only a single item at a time or no selection at all, depending on the value of singleSelect (defaults to false).")]
        public virtual bool MultiSelect
        {
            get
            {
                object obj = this.ViewState["MultiSelect"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["MultiSelect"] = value;
            }
        }

        /// <summary>
        /// A CSS class to apply to each item in the view on mouseover (defaults to undefined).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DataView")]
        [DefaultValue("")]
        [Description("A CSS class to apply to each item in the view on mouseover (defaults to undefined).")]
        public virtual string OverClass
        {
            get
            {
                object obj = this.ViewState["OverClass"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["OverClass"] = value;
            }
        }

        /// <summary>
        /// A CSS class to apply to each selected item in the view (defaults to 'x-view-selected').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DataView")]
        [DefaultValue("x-view-selected")]
        [Description("A CSS class to apply to each selected item in the view (defaults to 'x-view-selected').")]
        public virtual string SelectedClass
        {
            get
            {
                object obj = this.ViewState["SelectedClass"];
                return (obj == null) ? "x-view-selected" : (string)obj;
            }
            set
            {
                this.ViewState["SelectedClass"] = value;
            }
        }

        /// <summary>
        /// True to enable multiselection by clicking on multiple items without requiring the user to hold Shift or Ctrl, false to force the user to hold Ctrl or Shift to select more than on item (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DataView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to enable multiselection by clicking on multiple items without requiring the user to hold Shift or Ctrl, false to force the user to hold Ctrl or Shift to select more than on item (defaults to false).")]
        public virtual bool SimpleSelect
        {
            get
            {
                object obj = this.ViewState["SimpleSelect"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["SimpleSelect"] = value;
            }
        }

        /// <summary>
        /// True to allow selection of exactly one item at a time, false to allow no selection at all (defaults to false). Note that if multiSelect = true, this value will be ignored.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DataView")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to allow selection of exactly one item at a time, false to allow no selection at all (defaults to false). Note that if multiSelect = true, this value will be ignored.")]
        public virtual bool SingleSelect
        {
            get
            {
                object obj = this.ViewState["SingleSelect"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["SingleSelect"] = value;
            }
        }

        /// <summary>
        /// The data store to use.
        /// </summary>
        [Meta]
        [ConfigOption("store", JsonMode.ToClientID)]
        [Category("5. DataView")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [Description("The data store to use.")]
        public virtual string StoreID
        {
            get
            {
                object obj = this.ViewState["StoreID"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["StoreID"] = value;
            }
        }

        private StoreCollection store;

        /// <summary>
        ///  The data store to use.
        /// </summary>
        [Meta]
        [ConfigOption("store>Primary")]
        [Category("5. DataView")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The data store to use.")]
        public virtual StoreCollection Store
        {
            get
            {
                if (this.store == null)
                {
                    this.store = new StoreCollection();
                    this.store.AfterItemAdd += this.AfterStoreAdd;
                    this.store.AfterItemRemove += this.AfterStoreRemove;
                }

                return this.store;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void AfterStoreAdd(Store item)
        {
            this.Controls.AddAt(0, item);
            this.LazyItems.Insert(0, item);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void AfterStoreRemove(Store item)
        {
            if (this.Controls.Contains(item))
            {
                this.Controls.Remove(item);
            }

            if (this.LazyItems.Contains(item))
            {
                this.LazyItems.Remove(item);
            }
        }

        private XTemplate template;

        /// <summary>
        /// The template string to use to display each item in the dropdown list.
        /// </summary>
        [Meta]
        [Category("5. DataView")]
        [ConfigOption("tpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The template string to use to display each item in the dropdown list.")]
        public virtual XTemplate Template
        {
            get
            {
                if (this.template == null)
                {
                    this.template = new XTemplate();
                }

                return this.template;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.Controls.Add(this.Template);
            this.LazyItems.Add(this.Template);
        }

        /// <summary>
        /// True to enable mouseenter and mouseleave events
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. DataView")]
        [DefaultValue(false)]
        [Description("True to enable mouseenter and mouseleave events")]
        public virtual bool TrackOver
        {
            get
            {
                object obj = this.ViewState["TrackOver"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["TrackOver"] = value;
            }
        }

        private JFunction prepareData;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("5. DataView")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public virtual JFunction PrepareData
        {
            get
            {
                if (this.prepareData == null)
                {
                    this.prepareData = new JFunction();
                }

                return this.prepareData;
            }
            set
            {
                this.prepareData = value;
            }
        }

        /// <summary>
        /// Clears all selections.
        /// </summary>
        /// <param name="suppressEvent">True to skip firing of the selectionchange event</param>
        [Meta]
        [Description("Clears all selections.")]
        public void ClearSelections(bool suppressEvent)
        {
            this.Call("clearSelections", suppressEvent);
        }

        /// <summary>
        /// Clears all selections.
        /// </summary>
        [Meta]
        [Description("Clears all selections.")]
        public void ClearSelections()
        {
            this.Call("clearSelections");
        }

        /// <summary>
        /// Deselects a node.
        /// </summary>
        /// <param name="index">The index of node to deselect</param>
        [Meta]
        [Description("Deselects a node.")]
        public void Deselect(int index)
        {
            this.Call("deselect", index);
        }

        /// <summary>
        /// Refreshes the view by reloading the data from the store and re-rendering the template.
        /// </summary>
        [Meta]
        [Description("Refreshes the view by reloading the data from the store and re-rendering the template.")]
        public void Refresh()
        {
            this.Call("refresh");
        }

        /// <summary>
        /// Refreshes an individual node's data from the store.
        /// </summary>
        /// <param name="index">The item's data index in the store</param>
        [Meta]
        [Description("Refreshes an individual node's data from the store.")]
        public void RefreshNode(int index)
        {
            this.Call("refreshNode", index);
        }

        /// <summary>
        /// Selects a set of nodes.
        /// </summary>
        /// <param name="indexes">An array of indexes to select</param>
        /// <param name="keepExisting">true to keep existing selections</param>
        /// <param name="suppressEvent">true to skip firing of the selectionchange vent</param>
        [Meta]
        [Description("Selects a set of nodes.")]
        public void Select(int[] indexes, bool keepExisting, bool suppressEvent)
        {
            this.Call("select", indexes, keepExisting, suppressEvent);
        }

        /// <summary>
        /// Selects a set of nodes.
        /// </summary>
        /// <param name="indexes">An array of indexes to select</param>
        [Meta]
        [Description("Selects a set of nodes.")]
        public void Select(int[] indexes)
        {
            this.Call("select", indexes);
        }

        /// <summary>
        /// Selects a range of nodes. All nodes between start and end are selected.
        /// </summary>
        /// <param name="start">The index of the first node in the range</param>
        /// <param name="end">The index of the last node in the range</param>
        /// <param name="keepExisting">True to retain existing selections</param>
        [Meta]
        [Description("Selects a range of nodes. All nodes between start and end are selected.")]
        public void SelectRange(int start, int end, bool keepExisting)
        {
            this.Call("selectRange", start, end, keepExisting);
        }

        /// <summary>
        /// Selects a range of nodes. All nodes between start and end are selected.
        /// </summary>
        /// <param name="start">The index of the first node in the range</param>
        /// <param name="end">The index of the last node in the range</param>
        [Meta]
        [Description("Selects a range of nodes. All nodes between start and end are selected.")]
        public void SelectRange(int start, int end)
        {
            this.Call("selectRange", start, end);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Store GetStore()
        {
            if (this.Store.Primary != null)
            {
                return this.Store.Primary;
            }

            if (this.StoreID.IsNotEmpty())
            {
                return ControlUtils.FindControl<Store>(this, this.StoreID, true);
            }

            return null;
        }
    }
}