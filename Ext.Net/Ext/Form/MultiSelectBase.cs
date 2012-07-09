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
using System.Web.UI;
using Newtonsoft.Json;
using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Meta]
    [Description("")]
    public abstract partial class MultiSelectBase<T> : Field, IStore where T : StateManagedItem 
    {
        /// <summary>
        /// The data store to use.
        /// </summary>
        [Meta]
        [ConfigOption("store", JsonMode.ToClientID)]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [Description("The data store to use.")]
        public virtual string StoreID
        {
            get
            {
                return (string)this.ViewState["StoreID"] ?? "";
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
        [Category("7. MultiSelect")]
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
            this.Controls.Remove(item);
            this.LazyItems.Remove(item);
        }

        private ListItemCollection<T> items;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("")]
        public ListItemCollection<T> Items
        {
            get
            {
                if (this.items == null)
                {
                    this.items = new ListItemCollection<T>();
                }

                return this.items;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("store", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string ItemsProxy
        {
            get
            {
                if (this.StoreID.IsNotEmpty() || this.Store.Primary != null)
                {
                    return "";
                }

                return this.ItemsToStore;
            }
        }

        private string ItemsToStore
        {
            get
            {
                StringWriter sw = new StringWriter();
                JsonTextWriter jw = new JsonTextWriter(sw);
                ListItemCollectionJsonConverter converter = new ListItemCollectionJsonConverter();
                converter.WriteJson(jw, this.Items, null);

                return sw.GetStringBuilder().ToString();
            }
        }

        private SelectedListItemCollection selectedItems;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("")]
        public SelectedListItemCollection SelectedItems
        {
            get
            {
                if (this.selectedItems == null)
                {
                    this.selectedItems = new SelectedListItemCollection();
                }

                return this.selectedItems;
            }
        }

        /// <summary>
        /// The underlying data field name to bind to this MultiSelect.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [Description("The underlying data field name to bind to this MultiSelect.")]
        public virtual string DisplayField
        {
            get
            {
                return (string)this.ViewState["DisplayField"] ?? "text";
            }
            set
            {
                this.ViewState["DisplayField"] = value;
            }
        }

        /// <summary>
        /// The underlying data value name to bind to this MultiSelect.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [Description("The underlying data value name to bind to this MultiSelect.")]
        public virtual string ValueField
        {
            get
            {
                return (string)this.ViewState["ValueField"] ?? "value";
            }
            set
            {
                this.ViewState["ValueField"] = value;
            }
        }

        /// <summary>
        /// False to validate that the value length > 0 (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(true)]
        [Description("False to validate that the value length > 0 (defaults to true).")]
        public virtual bool AllowBlank
        {
            get
            {
                object obj = this.ViewState["AllowBlank"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AllowBlank"] = value;
            }
        }

        /// <summary>
        /// Maximum input field length allowed (defaults to Number.MAX_VALUE).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(-1)]
        [Description("Maximum input field length allowed (defaults to Number.MAX_VALUE).")]
        public virtual int MaxLength
        {
            get
            {
                object obj = this.ViewState["MaxLength"];
                return (obj == null) ? -1 : (int)obj;
            }
            set
            {
                this.ViewState["MaxLength"] = value;
            }
        }

        /// <summary>
        /// Minimum input field length required (defaults to 0).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(0)]
        [Description("Minimum input field length required (defaults to 0).")]
        public virtual int MinLength
        {
            get
            {
                object obj = this.ViewState["MinLength"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["MinLength"] = value;
            }
        }

        /// <summary>
        /// Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the maximum length validation fails (defaults to 'The maximum length for this field is {maxLength}').")]
        public virtual string MaxLengthText
        {
            get
            {
                return (string)this.ViewState["MaxLengthText"] ?? "";
            }
            set
            {
                this.ViewState["MaxLengthText"] = value;
            }
        }

        /// <summary>
        /// Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the minimum length validation fails (defaults to 'The minimum length for this field is {minLength}').")]
        public virtual string MinLengthText
        {
            get
            {
                return (string)this.ViewState["MinLengthText"] ?? "";
            }
            set
            {
                this.ViewState["MinLengthText"] = value;
            }
        }

        /// <summary>
        /// Error text to display if the allow blank validation fails (defaults to 'This field is required').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("Error text to display if the allow blank validation fails (defaults to 'This field is required').")]
        public virtual string BlankText
        {
            get
            {
                return (string)this.ViewState["BlankText"] ?? "";
            }
            set
            {
                this.ViewState["BlankText"] = value;
            }
        }

        /// <summary>
        /// Causes drag operations to copy nodes rather than move (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(false)]
        [Description("Causes drag operations to copy nodes rather than move (defaults to false).")]
        public virtual bool Copy
        {
            get
            {
                object obj = this.ViewState["Copy"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Copy"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("allowDup")]
        [Category("6. MultiSelect")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool AllowDuplicates
        {
            get
            {
                object obj = this.ViewState["AllowDuplicates"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AllowDuplicates"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool AllowTrash
        {
            get
            {
                object obj = this.ViewState["AllowTrash"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AllowTrash"] = value;
            }
        }

        /// <summary>
        /// The title text to display in the panel header (defaults to '')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [Description("The title text to display in the panel header (defaults to '')")]
        public virtual string Legend
        {
            get
            {
                return (string)this.ViewState["Legend"] ?? "";
            }
            set
            {
                this.ViewState["Legend"] = value;
            }
        }

        /// <summary>
        /// The string used to delimit between items when set or returned as a string of values
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(",")]
        [Description("The string used to delimit between items when set or returned as a string of values")]
        public virtual string Delimiter
        {
            get
            {
                return (string)this.ViewState["Delimiter"] ?? ",";
            }
            set
            {
                this.ViewState["Delimiter"] = value;
            }
        }

        /// <summary>
        /// The ddgroup name(s) for the View's DragZone (defaults to undefined).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [Description("The ddgroup name(s) for the View's DragZone (defaults to undefined).")]
        public virtual string DragGroup
        {
            get
            {
                return (string)this.ViewState["DragGroup"] ?? "";
            }
            set
            {
                this.ViewState["DragGroup"] = value;
            }
        }

        /// <summary>
        /// The ddgroup name(s) for the View's DropZone (defaults to undefined).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [Description("The ddgroup name(s) for the View's DropZone (defaults to undefined).")]
        public virtual string DropGroup
        {
            get
            {
                return (string)this.ViewState["DropGroup"] ?? "";
            }
            set
            {
                this.ViewState["DropGroup"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool AppendOnly
        {
            get
            {
                object obj = this.ViewState["AppendOnly"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AppendOnly"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [Description("")]
        public virtual string SortField
        {
            get
            {
                return (string)this.ViewState["SortField"] ?? "";
            }
            set
            {
                this.ViewState["SortField"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(SortDirection.ASC)]
        [NotifyParentProperty(true)]
        [Description("")]
        public SortDirection Direction
        {
            get
            {
                object obj = this.ViewState["Direction"];
                return (obj == null) ? SortDirection.ASC : (SortDirection)obj;
            }
            set
            {
                this.ViewState["Direction"] = value;
            }
        }

        /// <summary>
        /// True to submit text of selected items
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(true)]
        [Description("True to submit text of selected items")]
        public virtual bool SubmitText
        {
            get
            {
                object obj = this.ViewState["SubmitText"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["SubmitText"] = value;
            }
        }

        /// <summary>
        /// Set init selecetion without event fires
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(false)]
        [Description("Set init selecetion without event fires")]
        public virtual bool FireSelectOnLoad
        {
            get
            {
                object obj = this.ViewState["FireSelectOnLoad"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["FireSelectOnLoad"] = value;
            }
        }

        /// <summary>
        /// True to allow multi selection (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue(true)]
        [Description("True to allow multi selection (defaults to true).")]
        public virtual bool MultiSelect
        {
            get
            {
                object obj = this.ViewState["MultiSelect"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["MultiSelect"] = value;
            }
        }

        /// <summary>
        /// Selection mode
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("6. MultiSelect")]
        [DefaultValue(KeepSelectionMode.Always)]
        [Description("Selection Mode")]
        public virtual KeepSelectionMode KeepSelectionOnClick
        {
            get
            {
                object obj = this.ViewState["KeepSelectionOnClick"];
                return (obj == null) ? KeepSelectionMode.Always : (KeepSelectionMode)obj;
            }
            set
            {
                this.ViewState["KeepSelectionOnClick"] = value;
            }
        }

        /// <summary>
        /// Custom CSS styles to be applied to the body element in the format expected by Ext.Element.applyStyles (defaults to null).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. MultiSelect")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Custom CSS styles to be applied to the body element in the format expected by Ext.Element.applyStyles (defaults to null).")]
        public virtual string BodyStyle
        {
            get
            {
                string style = (string)this.ViewState["BodyStyle"] ?? "";

                if (style.IsNotEmpty())
                {
                    if (!style.EndsWith(";"))
                    {
                        style += ";";
                    }
                }

                return style;
            }
            set
            {
                this.ViewState["BodyStyle"] = value;
            }
        }

        private ToolbarCollection bottomBar;

        /// <summary>
        /// The bottom toolbar of the panel.
        /// </summary>
        [Meta]
        [ConfigOption("bbar", typeof(ItemCollectionJsonConverter))]
        [Category("6. MultiSelect")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The bottom toolbar of the panel.")]
        public virtual ToolbarCollection BottomBar
        {
            get
            {
                if (this.bottomBar == null)
                {
                    this.bottomBar = new ToolbarCollection();
                    this.bottomBar.AfterItemAdd += this.AfterItemAdd;
                    this.bottomBar.AfterItemRemove += this.AfterItemRemove;
                }

                return this.bottomBar;
            }
        }

        private ToolbarCollection topBar;

        /// <summary>
        /// The top toolbar of the panel.
        /// </summary>
        [Meta]
        [ConfigOption("tbar", typeof(ItemCollectionJsonConverter))]
        [Category("6. MultiSelect")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The top toolbar of the panel.")]
        public virtual ToolbarCollection TopBar
        {
            get
            {
                if (this.topBar == null)
                {
                    this.topBar = new ToolbarCollection();
                    this.topBar.AfterItemAdd += this.AfterItemAdd;
                    this.topBar.AfterItemRemove += this.AfterItemRemove;
                }

                return this.topBar;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public void UpdateSelection()
        {
            if (this.SelectedItems.Count == 0)
            {
                this.Call("reset");
            }
            else
            {
                this.Call("setValue", new JRawValue(this.SelectedItems.ValuesToJsonArray()));
            }
        }

        /// <summary>
        /// Selects all nodes.
        /// </summary>
        [Description("Selects all nodes.")]
        public void SelectAll()
        {
            this.Call("selectAll");
        }

        /// <summary>
        /// Clears all selections.
        /// </summary>
        [Description("Selects all nodes.")]
        public void DeselectAll()
        {
            this.Call("deselectAll");
        }

        /// <summary>
        /// Clears all selections.
        /// <param name="suppressEvent">True to skip firing of the selectionchange event</param>
        /// </summary>
        [Description("Selects all nodes.")]
        public void DeselectAll(Boolean suppressEvent)
        {
            this.Call("deselectAll", suppressEvent);
        }

        #region IStore Members

        SimpleStore<T> generatedStore;
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

            if (this.generatedStore == null)
            {
                this.generatedStore = new SimpleStore<T>(this, this.Items);
				this.generatedStore.EnableViewState = false;
                this.Controls.Add(this.generatedStore);
            }
            else
            {
                this.generatedStore.Items.Clear();
                this.generatedStore.Items = this.Items;
            }

            return this.generatedStore;
        }

        #endregion
    }
}