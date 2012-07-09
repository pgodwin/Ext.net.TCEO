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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// ComboBox with multi item selection.
    /// </summary>
    [Meta]
    [ToolboxItem(true)]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxData("<{0}:MultiCombo runat=\"server\"></{0}:MultiCombo>")]
    [ToolboxBitmap(typeof(MultiCombo), "Build.ToolboxIcons.MultiCombo.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("ComboBox with multi item selection.")]
    public partial class MultiCombo : ComboBoxBaseMulti<ListItem>, IPostBackEventHandler
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public MultiCombo() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.net.MultiCombo";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "netmulticombo";
            }
        }

        /// <summary>
        /// False to prevent the user from typing text directly into the field, just like a traditional select (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. MultiCombo")]
        [DefaultValue(false)]
        [Description("False to prevent the user from typing text directly into the field, just like a traditional select (defaults to true).")]
        public override bool Editable
        {
            get
            {
                object obj = this.ViewState["Editable"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Editable"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            if (this.Editable)
            {
                throw new Exception("The MultiCombo doesn't support Editable mode");
            }
            
            this.InitPostBack();

            if ((this.StoreID.IsNotEmpty() || this.Store.Primary != null) && !this.IsDynamic)
            {
                Store store = this.Store.Primary ?? ControlUtils.FindControl<Store>(this, this.StoreID, true);

                if (store == null)
                {
                    throw new InvalidOperationException("The Control '{0}' could not find the StoreID of '{1}'.".FormatWith(this.ID, this.StoreID));
                }
            }
            else
            {
                this.TriggerAction = TriggerAction.All;
                this.Mode = DataLoadMode.Local;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("selectionPredefined", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string SelectionPredefinedProxy
        {
            get
            {
                if (this.SelectedItems.Count == 0)
                {
                    return "";
                }

                return this.SelectedItems.ToJsonArray();
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.UniqueName.ConcatWith("_Selection")];

            this.SuspendScripting();
            this.RawValue = val;
            this.ResumeScripting();

            if (val == null)
            {
                return false;
            }

            bool existsItems = this.SelectedItems.Count > 0;
            this.SelectedItems.Clear();
            Dictionary<string, string>[] selection = JSON.Deserialize<Dictionary<string, string>[]>(val);
            
            if (selection == null)
            {
                return existsItems;
            }

            foreach (Dictionary<string, string> item in selection)
            {
                this.SelectedItems.Add(new SelectedListItem(item["text"], item["value"], int.Parse(item["index"])));
            }

            return true;
        }

        protected override void RaisePostDataChangedEvent()
        {
            this.OnValueChanged(EventArgs.Empty);
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            switch (eventArgument)
            {
                case "select":
                    this.OnItemSelected(EventArgs.Empty);
                    break;
                case "change":
                    this.OnValueChanged(EventArgs.Empty);
                    break;
                default:
                    int index;

                    if (int.TryParse(eventArgument, out index))
                    {
                        this.OnTriggerClicked(new TriggerEventArgs(index));
                    }
                    break;
            }
        }

        private ComboBoxListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public ComboBoxListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ComboBoxListeners();
                }

                return this.listeners;
            }
        }

        private ComboBoxDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public ComboBoxDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ComboBoxDirectEvents();
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Select all items
        /// </summary>
        [Meta]
        [Description("Select all items")]
        public virtual void SelectAll()
        {
            this.Call("selectAll");
        }

        /// <summary>
        /// Clear selection
        /// </summary>
        [Meta]
        [Description("Clear selection")]
        public virtual void ClearSelections()
        {
            this.Call("clearSelections");
        }

        /// <summary>
        /// Deselect item by index
        /// </summary>
        [Meta]
        [Description("Deselect item by index")]
        public virtual void DeselectItem(int index)
        {
            this.Call("deselectItem", index);
        }

        /// <summary>
        /// Deselect item by value
        /// </summary>
        [Meta]
        [Description("Deselect item by value")]
        public virtual void DeselectItem(string value)
        {
            this.Call("deselectItem", value);
        }

        /// <summary>
        /// Select item by index
        /// </summary>
        [Meta]
        [Description("Select item by index")]
        public virtual void SelectItem(int index)
        {
            this.Call("selectItem", index);
        }

        /// <summary>
        /// Select item by value
        /// </summary>
        [Meta]
        [Description("Select item by value")]
        public virtual void SelectItem(string value)
        {
            this.Call("selectItem", value);
        }
    }
}