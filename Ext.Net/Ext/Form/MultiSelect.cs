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
    /// A control that allows selection and form submission of multiple list items.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:MultiSelect runat=\"server\"></{0}:MultiSelect>")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(MultiSelect), "Build.ToolboxIcons.MultiSelect.bmp")]
    [Description("A control that allows selection and form submission of multiple list items.")]
    public partial class MultiSelect : MultiSelectBase<ListItem>, IPostBackEventHandler
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public MultiSelect() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 3;

                baseList.Add(new ClientStyleItem(typeof(MultiSelect), "Ext.Net.Build.Ext.Net.ux.extensions.multiselect.resources.css.multiselect.css", "/ux/extensions/multiselect/resources/css/multiselect.css"));
                baseList.Add(new ClientScriptItem(typeof(MultiSelect), "Ext.Net.Build.Ext.Net.ux.extensions.ddview.ddview.js", "/ux/extensions/ddview/ddview.js"));
                baseList.Add(new ClientScriptItem(typeof(MultiSelect), "Ext.Net.Build.Ext.Net.ux.extensions.multiselect.multiselect.js", "/ux/extensions/multiselect/multiselect.js"));

                return baseList;
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
                return "multiselect";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.ux.Multiselect";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            if (this.StoreID.IsNotEmpty() && this.Store.Primary != null)
            {
                throw new Exception(string.Format("Please do not set both the StoreID property on {0} and <Store> inner property at the same time.", this.ID));
            }
            
            if (this.AutoPostBack)
            {
                EventHandler handler = (EventHandler)Events[EventSelectionChanged];

                if (handler != null)
                {
                    this.On("change", new JFunction(this.PostBackFunction));
                }
            }

            if (this.StoreID.IsNotEmpty() || this.Store.Primary != null)
            {
                Store store = this.Store.Primary??ControlUtils.FindControl<Store>(this, this.StoreID, true);

                if (store == null && !this.IsDynamic)
                {
                    throw new InvalidOperationException("The Control '{0}' could not find the StoreID of '{1}'.".FormatWith(this.ID, this.StoreID));
                }

                if (this.SelectedItems.Count > 0)
                {
                    HandlerConfig options = new HandlerConfig();
                    options.Single = true;

                    string template = "{0}.store.on(\"{1}\",{2},{3},{4});";
                    string values = this.SelectedItems.ValuesToJsonArray();
                    string indexes = this.SelectedItems.IndexesToJsonArray(true);


                    string suppressEvent = this.FireSelectOnLoad ? "false" : "true";
                    values = values != "[]" ? ".setValue(".ConcatWith(values, ", true, ", suppressEvent, ");") : "";
                    indexes = indexes != "[]" ? ".setValueByIndex(".ConcatWith(indexes, ", true, ", suppressEvent, ");") : "";

                    this.AddScript(template,
                            this.ClientID, 
                            "load",
                            new JFunction(this.ClientID.ConcatWith(values, indexes, this.ClientID, ".clearInvalid();")).ToScript(),
                            "this",
                            options.ToJsonString()
                            );
                }
            }
            else
            {
                if (this.SelectedItems.Count > 0)
                {
                    string values = this.SelectedItems.ValuesToJsonArray();
                    string indexes = this.SelectedItems.IndexesToJsonArray(true);
                    string suppressEvent = this.FireSelectOnLoad ? "false" : "true";

                    if (values != "[]")
                    {
                        this.Call("setValue", new JRawValue(values), true, suppressEvent);
                    }

                    if (indexes != "[]")
                    {
                        this.Call("setValue", new JRawValue(indexes), true, suppressEvent);
                    }
                }
            }
        }

        private static readonly object EventSelectionChanged = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event EventHandler SelectionChanged
        {
            add
            {
                this.Events.AddHandler(EventSelectionChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventSelectionChanged, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnSelectionChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)this.Events[EventSelectionChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string text = postCollection[this.UniqueName.ConcatWith("_text")];
            string values = postCollection[this.UniqueName];
            string indexes = postCollection[this.UniqueName.ConcatWith("_indexes")];

            this.SuspendScripting();
            this.RawValue = text;
            this.ResumeScripting();

            if (values == null)
            {
                return false;
            }

            bool fireEvent = false;

            if (values.IsEmpty())
            {
                fireEvent = this.SelectedItems.Count > 0;
                this.SelectedItems.Clear();
                return fireEvent;
            }

            string[] arrValues = values.Split(new[] { this.Delimiter }, StringSplitOptions.RemoveEmptyEntries);
            string[] arrIndexes = indexes.Split(new[] { this.Delimiter }, StringSplitOptions.RemoveEmptyEntries);
            string[] arrText = new string[0];

            if (text.IsNotEmpty())
            {
                arrText = text.Split(new[] { this.Delimiter }, StringSplitOptions.RemoveEmptyEntries);
            }

            SelectedListItemCollection temp = new SelectedListItemCollection();

            for (int i = 0; i < arrValues.Length; i++)
            {
                string value = arrValues[i];
                string index = arrIndexes[i];
                string _text = arrText.Length > 0 ? arrText[i] : "";

                SelectedListItem item = new SelectedListItem(_text, value, int.Parse(index));

                temp.Add(item);

                if (!this.SelectedItems.Contains(item))
                {
                    fireEvent = true;
                }
            }

            this.SelectedItems.Clear();
            this.SelectedItems.AddRange(temp);

            return fireEvent;
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            this.OnSelectionChanged(EventArgs.Empty);
        }

        
        private MultiSelectListeners listeners;

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
        public MultiSelectListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new MultiSelectListeners();
                }

                return this.listeners;
            }
        }


        private MultiSelectDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side DirectEventHandlers")]
        public MultiSelectDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new MultiSelectDirectEvents();
                }

                return this.directEvents;
            }
        }
    }
}
