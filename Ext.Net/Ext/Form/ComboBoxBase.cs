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
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// A combobox control with support for autocomplete, remote-loading, paging and many other features.
    /// </summary>
    [Meta]
    [Description("A combobox control with support for autocomplete, remote-loading, paging and many other features.")]
    public abstract partial class ComboBoxBase<T> : TriggerFieldBase, IStore where T : StateManagedItem 
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
                baseList.Capacity += 1;

                baseList.Add(XControl.ExtNetDataItem);

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
                return "combo";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnBeforeClientInitHandler()
        {
            base.OnBeforeClientInitHandler();

            if (this.StoreID.IsNotEmpty() && this.Store.Primary != null)
            {
                throw new Exception(string.Format("Please do not set both the StoreID property on {0} and <Store> inner property at the same time.", this.ID));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void RegisterIcons()
        {
            base.RegisterIcons();
           
        }
        
        /// <summary>
        /// The text query to send to the server to return all records for the list with no filtering (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("The text query to send to the server to return all records for the list with no filtering (defaults to '').")]
        public virtual string AllQuery
        {
            get
            {
                return (string)this.ViewState["AllQuery"] ?? "";
            }
            set
            {
                this.ViewState["AllQuery"] = value;
            }
        }

        /// <summary>
        /// true to clear any filters on the store (when in local mode) when reset is called (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(true)]
        [Description("true to clear any filters on the store (when in local mode) when reset is called (defaults to true)")]
        public virtual bool ClearFilterOnReset
        {
            get
            {
                object obj = this.ViewState["ClearFilterOnReset"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ClearFilterOnReset"] = value;
            }
        }

        /// <summary>
        /// The underlying data field name to bind to this ComboBox (defaults to undefined if mode = 'remote' or 'text' if transforming a select).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("The underlying data field name to bind to this ComboBox (defaults to undefined if mode = 'remote' or 'text' if transforming a select).")]
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
        /// True to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(true)]
        [Description("True to restrict the selected value to one of the values in the list, false to allow the user to set arbitrary text into the field (defaults to true).")]
        public virtual bool ForceSelection
        {
            get
            {
                object obj = this.ViewState["ForceSelection"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ForceSelection"] = value;
            }
        }

        /// <summary>
        /// The height in pixels of the dropdown list resize handle if resizable = true (defaults to 8).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(typeof(Unit), "8")]
        [Description("The height in pixels of the dropdown list resize handle if resizable = true (defaults to 8).")]
        public virtual Unit HandleHeight
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["HandleHeight"], Unit.Pixel(8), "HandleHeight");
            }
            set
            {
                this.ViewState["HandleHeight"] = value;
            }
        }

        /// <summary>
        /// If hiddenName is specified, hiddenId can also be provided to give the hidden field a unique id (defaults to the hiddenName). The hiddenId and combo id should be different, since no two DOM nodes should share the same id.
        /// </summary>
        [Meta]
        [ConfigOption("hiddenId")]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("If hiddenName is specified, hiddenId can also be provided to give the hidden field a unique id (defaults to the hiddenName). The hiddenId and combo id should be different, since no two DOM nodes should share the same id.")]
        public virtual string HiddenID
        {
            get
            {
                return (string)this.ViewState["HiddenID"] ?? "";
            }
            set
            {
                this.ViewState["HiddenID"] = value;
            }
        }

        /// <summary>
        /// Sets the initial value of the hidden field if hiddenName is specified to contain the selected valueField, from the Store. Defaults to the configured value.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("Sets the initial value of the hidden field if hiddenName is specified to contain the selected valueField, from the Store. Defaults to the configured value.")]
        public virtual string HiddenValue
        {
            get
            {
                return (string)this.ViewState["HiddenValue"] ?? "";
            }
            set
            {
                this.ViewState["HiddenValue"] = value;
            }
        }

        /// <summary>
        /// If specified, a hidden form field with this name is dynamically generated to store the field's data value (defaults to the underlying DOM element's name). Required for the combo's value to automatically post during a form submission.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("If specified, a hidden form field with this name is dynamically generated to store the field's data value (defaults to the underlying DOM element's name). Required for the combo's value to automatically post during a form submission.")]
        public virtual string HiddenName
        {
            get
            {
                return (string)this.ViewState["HiddenName"] ?? this.UniqueName.ConcatWith("_Value");
            }
            set
            {
                this.ViewState["HiddenName"] = value;
            }
        }

        /// <summary>
        /// This setting is required if a custom XTemplate has been specified in tpl which assigns a class other than 'x-combo-list-item' to dropdown list items. A simple CSS selector (e.g. div.some-class or span:first-child) that will be used to determine what nodes the DataView which handles the dropdown display will be working with.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("This setting is required if a custom XTemplate has been specified in tpl which assigns a class other than 'x-combo-list-item' to dropdown list items. A simple CSS selector (e.g. div.some-class or span:first-child) that will be used to determine what nodes the DataView which handles the dropdown display will be working with.")]
        public virtual string ItemSelector
        {
            get
            {
                return (string)this.ViewState["ItemSelector"] ?? "";
            }
            set
            {
                this.ViewState["ItemSelector"] = value;
            }
        }

        /// <summary>
        /// True to not initialize the list for this combo until the field is focused. (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(true)]
        [Description("True to not initialize the list for this combo until the field is focused. (defaults to true).")]
        public virtual bool LazyInit
        {
            get
            {
                object obj = this.ViewState["LazyInit"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["LazyInit"] = value;
            }
        }

        /// <summary>
        /// True to prevent the ComboBox from rendering until requested (should always be used when rendering into an Ext.Editor, defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(false)]
        [Description("True to prevent the ComboBox from rendering until requested (should always be used when rendering into an Ext.Editor, defaults to false).")]
        public virtual bool LazyRender
        {
            get
            {
                object obj = this.ViewState["LazyRender"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["LazyRender"] = value;
            }
        }

        /// <summary>
        /// True to fire select event after setValue on page load
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(false)]
        [Description("True to fire select event after setValue on page load")]
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
        /// A valid anchor position value. See Ext.Element.alignTo for details on supported anchor positions (defaults to 'tl-bl').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("A valid anchor position value. See Ext.Element.alignTo for details on supported anchor positions (defaults to 'tl-bl').")]
        public virtual string ListAlign
        {
            get
            {
                return (string)this.ViewState["ListAlign"] ?? "";
            }
            set
            {
                this.ViewState["ListAlign"] = value;
            }
        }

        /// <summary>
        /// CSS class to apply to the dropdown list element (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("CSS class to apply to the dropdown list element (defaults to '').")]
        public virtual string ListClass
        {
            get
            {
                return (string)this.ViewState["ListClass"] ?? "";
            }
            set
            {
                this.ViewState["ListClass"] = value;
            }
        }

        /// <summary>
        /// The width in pixels of the dropdown list (defaults to the width of the ComboBox field).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(typeof(Unit), "")]
        [Description("The width in pixels of the dropdown list (defaults to the width of the ComboBox field).")]
        public virtual Unit ListWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["ListWidth"], Unit.Empty, "ListWidth");
            }
            set
            {
                this.ViewState["ListWidth"] = value;
            }
        }

        /// <summary>
        /// The text to display in the dropdown list while data is loading. Only applies when mode = 'remote' (defaults to 'Loading...').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("Loading...")]
        [Localizable(true)]
        [Description("The text to display in the dropdown list while data is loading. Only applies when mode = 'remote' (defaults to 'Loading...').")]
        public virtual string LoadingText
        {
            get
            {
                return (string)this.ViewState["LoadingText"] ?? "Loading...";
            }
            set
            {
                this.ViewState["LoadingText"] = value;
            }
        }

        /// <summary>
        /// The maximum height in pixels of the dropdown list before scrollbars are shown (defaults to 300).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(typeof(Unit), "300")]
        [Description("The maximum height in pixels of the dropdown list before scrollbars are shown (defaults to 300).")]
        public override Unit MaxHeight
        {
            get
            {
                return this.UnitPixelTypeCheck(this.ViewState["MaxHeight"], Unit.Pixel(300), "MaxHeight");
            }
            set
            {
                this.ViewState["MaxHeight"] = value;
            }
        }

        /// <summary>
        /// The minimum height in pixels of the dropdown list when the list is constrained by its distance to the viewport edges (defaults to 90).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(typeof(Unit), "90")]
        [Description("The minimum height in pixels of the dropdown list when the list is constrained by its distance to the viewport edges (defaults to 90).")]
        public override Unit MinHeight
        {
            get
            {
                return this.UnitPixelTypeCheck(this.ViewState["MinHeight"], Unit.Pixel(90), "MinHeight");
            }
            set
            {
                this.ViewState["MinHeight"] = value;
            }
        }

        /// <summary>
        /// The minimum number of characters the user must type before autocomplete and typeahead activate (defaults to 4 if remote or 0 if local, does not apply if editable = false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(4)]
        [Description("The minimum number of characters the user must type before autocomplete and typeahead activate (defaults to 4 if remote or 0 if local, does not apply if editable = false).")]
        public virtual int MinChars
        {
            get
            {
                object obj = this.ViewState["MinChars"];
                return (obj == null) ? 4 : (int)obj;
            }
            set
            {
                this.ViewState["MinChars"] = value;
            }
        }

        /// <summary>
        /// The minimum width of the dropdown list in pixels (defaults to 70, will be ignored if listWidth has a higher value).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(typeof(Unit), "70")]
        [Description("The minimum width of the dropdown list in pixels (defaults to 70, will be ignored if listWidth has a higher value).")]
        public virtual Unit MinListWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["MinListWidth"], Unit.Pixel(70), "MinListWidth");
            }
            set
            {
                this.ViewState["MinListWidth"] = value;
            }
        }

        /// <summary>
        /// Set to 'local' if the ComboBox loads local data (defaults to 'remote' which loads from the server).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("8. ComboBox")]
        [DefaultValue(DataLoadMode.Remote)]
        [Description("Set to 'local' if the ComboBox loads local data (defaults to 'remote' which loads from the server).")]
        public virtual DataLoadMode Mode
        {
            get
            {
                object obj = this.ViewState["Mode"];
                return (obj == null) ? DataLoadMode.Remote : (DataLoadMode)obj;
            }
            set
            {
                this.ViewState["Mode"] = value;
            }
        }

        /// <summary>
        /// If greater than 0, a paging toolbar is displayed in the footer of the dropdown list and the filter queries will execute with page addToStart and limit parameters. Only applies when mode = 'remote' (defaults to 0).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(0)]
        [Description("If greater than 0, a paging toolbar is displayed in the footer of the dropdown list and the filter queries will execute with page addToStart and limit parameters. Only applies when mode = 'remote' (defaults to 0).")]
        public virtual int PageSize
        {
            get
            {
                object obj = this.ViewState["PageSize"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["PageSize"] = value;
            }
        }

        /// <summary>
        /// The length of time in milliseconds to delay between the addToStart of typing and sending the query to filter the dropdown list (defaults to 500 if mode = 'remote' or 10 if mode = 'local').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(500)]
        [Description("The length of time in milliseconds to delay between the addToStart of typing and sending the query to filter the dropdown list (defaults to 500 if mode = 'remote' or 10 if mode = 'local').")]
        public virtual int QueryDelay
        {
            get
            {
                object obj = this.ViewState["QueryDelay"];
                return (obj == null) ? (this.Mode == DataLoadMode.Local) ? 10 : 500 : (int)obj;
            }
            set
            {
                this.ViewState["QueryDelay"] = value;
            }
        }

        /// <summary>
        /// Name of the query as it will be passed on the querystring (defaults to 'query').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("query")]
        [Description("Name of the query as it will be passed on the querystring (defaults to 'query').")]
        public virtual string QueryParam
        {
            get
            {
                return (string)this.ViewState["QueryParam"] ?? "query";
            }
            set
            {
                this.ViewState["QueryParam"] = value;
            }
        }

        /// <summary>
        /// True to add a resize handle to the bottom of the dropdown list (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(false)]
        [Description("True to add a resize handle to the bottom of the dropdown list (defaults to false)")]
        public virtual bool Resizable
        {
            get
            {
                object obj = this.ViewState["Resizable"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Resizable"] = value;
            }
        }

        /// <summary>
        /// CSS class to apply to the selected items in the dropdown list (defaults to 'x-combo-selected').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("CSS class to apply to the selected items in the dropdown list (defaults to 'x-combo-selected').")]
        public virtual string SelectedClass
        {
            get
            {
                return (string)this.ViewState["SelectedClass"] ?? "";
            }
            set
            {
                this.ViewState["SelectedClass"] = value;
            }
        }

        /// <summary>
        /// 'Sides' for the default effect, 'Frame' for 4-way shadow, and 'Drop' for bottom-right.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(ShadowJsonConverter))]
        [Category("8. ComboBox")]
        [DefaultValue(ShadowMode.Sides)]
        [Description("'Sides' for the default effect, 'Frame' for 4-way shadow, and 'Drop' for bottom-right.")]
        public virtual ShadowMode Shadow
        {
            get
            {
                object obj = this.ViewState["Shadow"];
                return (obj == null) ? ShadowMode.Sides : (ShadowMode)obj;
            }
            set
            {
                this.ViewState["Shadow"] = value;
            }
        }

        /// <summary>
        /// true for the default effect
        /// </summary>
        [Meta]
        [ConfigOption("shadow")]
        [Category("8. ComboBox")]
        [DefaultValue(true)]
        [Description("true for the default effect")]
        public virtual bool EnableShadow
        {
            get
            {
                object obj = this.ViewState["EnableShadow"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["EnableShadow"] = value;
            }
        }

        /// <summary>
        /// True to automatically select any existing field text when the field receives input focus (defaults to false).
        /// </summary>
        [Meta]
        [Category("8. ComboBox")]
        [DefaultValue(false)]
        [Description("True to automatically select any existing field text when the field receives input focus (defaults to false).")]
        public override bool SelectOnFocus
        {
            get
            {
                object obj = this.ViewState["SelectOnFocus"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["SelectOnFocus"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("selectOnFocus")]
        [DefaultValue(false)]
		[Description("")]
        protected bool SelectOnFocusProxy
        {
            get
            {
                return (this.Editable) ? this.SelectOnFocus : false;
            }
        }

        private XTemplate template;

        /// <summary>
        /// The template string to use to display each item in the dropdown list.
        /// </summary>
        [Meta]
        [Category("8. ComboBox")]
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
                    this.template.EnableViewState = false;
                    this.Controls.Add(this.template);
                    this.LazyItems.Add(this.template);                    
                }

                return this.template;
            }
        }

        /// <summary>
        /// The ID of an existing select to convert to a ComboBox.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("The ID of an existing select to convert to a ComboBox.")]
        public virtual string Transform
        {
            get
            {
                return (string)this.ViewState["Transform"] ?? "";
            }
            set
            {
                this.ViewState["Transform"] = value;
            }
        }

        /// <summary>
        /// If supplied, a header element is created containing this text and added into the top of the dropdown list.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("If supplied, a header element is created containing this text and added into the top of the dropdown list.")]
        public virtual string Title
        {
            get
            {
                return (string)this.ViewState["Title"] ?? "";
            }
            set
            {
                this.ViewState["Title"] = value;
            }
        }

        /// <summary>
        /// The action to execute when the trigger field is activated. Use 'All' to run the query specified by the allQuery config option (defaults to 'Query').
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("8. ComboBox")]
        [DefaultValue(TriggerAction.Query)]
        [Description("The action to execute when the trigger field is activated. Use 'All' to run the query specified by the allQuery config option (defaults to 'Query').")]
        public virtual TriggerAction TriggerAction
        {
            get
            {
                object obj = this.ViewState["TriggerAction"];
                return (obj == null) ? TriggerAction.All : (TriggerAction)obj;
            }
            set
            {
                this.ViewState["TriggerAction"] = value;
            }
        }

        /// <summary>
        /// True to populate and autoselect the remainder of the text being typed after a configurable delay (typeAheadDelay) if it matches a known value (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(false)]
        [Description("True to populate and autoselect the remainder of the text being typed after a configurable delay (typeAheadDelay) if it matches a known value (defaults to false).")]
        public virtual bool TypeAhead
        {
            get
            {
                object obj = this.ViewState["TypeAhead"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["TypeAhead"] = value;
            }
        }

        /// <summary>
        /// The length of time in milliseconds to wait until the typeahead text is displayed if TypeAhead = true (defaults to 250).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(250)]
        [Description("The length of time in milliseconds to wait until the typeahead text is displayed if TypeAhead = true (defaults to 250).")]
        public virtual int TypeAheadDelay
        {
            get
            {
                object obj = this.ViewState["TypeAheadDelay"];
                return (obj == null) ? 250 : (int)obj;
            }
            set
            {
                this.ViewState["TypeAheadDelay"] = value;
            }
        }

        /// <summary>
        /// The underlying data value name to bind to this ComboBox (defaults to undefined if mode = 'remote' or 'value' if transforming a select) Note: use of a valueField requires the user to make a selection in order for a value to be mapped.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Description("The underlying data value name to bind to this ComboBox (defaults to undefined if mode = 'remote' or 'value' if transforming a select) Note: use of a valueField requires the user to make a selection in order for a value to be mapped.")]
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
        /// When using a name/value combo, if the value passed to setValue is not found in the store, valueNotFoundText will be displayed as the field text if defined (defaults to undefined).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("When using a name/value combo, if the value passed to setValue is not found in the store, valueNotFoundText will be displayed as the field text if defined (defaults to undefined).")]
        public virtual string ValueNotFoundText
        {
            get
            {
                return (string)this.ViewState["ValueNotFoundText"] ?? "";
            }
            set
            {
                this.ViewState["ValueNotFoundText"] = value;
            }
        }

        /// <summary>
        /// The data store to use.
        /// </summary>
        [Meta]
        [ConfigOption("store", JsonMode.ToClientID)]
        [Category("8. ComboBox")]
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
        [Category("7. ComboBox")]
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

        private void AfterStoreRemove(Store item)
        {
            this.Controls.Remove(item);
            this.LazyItems.Remove(item);
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

        private ListItemCollection<T> items;

        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Category("8. ComboBox")]
        [Description("")]
        public ListItemCollection<T> Items
        {
            get
            {
                if (items == null)
                {
                    items = new ListItemCollection<T>();
                }

                return items;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual string ItemsToStore
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

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. ComboBox")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool AlwaysMergeItems
        {
            get
            {
                object obj = this.ViewState["AlwaysMergeItems"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AlwaysMergeItems"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("store", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected virtual string ItemsProxy
        {
            get
            {
                if (this.StoreID.IsNotEmpty() || this.Transform.IsNotEmpty() || this.Store.Primary != null)
                {
                    return "";
                }

                return this.ItemsToStore;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("mergeItems", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected internal string MergeItems
        {
            get
            {
                if ((this.StoreID.IsEmpty() && this.Store.Primary == null) || this.Items.Count == 0)
                {
                    return "";
                }

                return this.ItemsToStore;
            }
        }

        /// <summary>
        /// Trigger AutoPostBack
        /// </summary>
        [Meta]
        [Category("8. ComboBox")]
        [DefaultValue(false)]
        [Description("Trigger AutoPostBack")]
        public virtual bool TriggerAutoPostBack
        {
            get
            {
                object obj = this.ViewState["TriggerAutoPostBack"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["TriggerAutoPostBack"] = value;
            }
        }

        private static readonly object EventTriggerClicked = new object();

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void TriggerClickedHandler(object sender, TriggerEventArgs e);

		/// <summary>
		/// 
		/// </summary>
        [Category("Action")]
        [Description("Fires when a trigger has been clicked")]
        public event TriggerClickedHandler TriggerClicked
        {
            add
            {
                Events.AddHandler(EventTriggerClicked, value);
            }
            remove
            {
                Events.RemoveHandler(EventTriggerClicked, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnTriggerClicked(TriggerEventArgs e)
        {
            TriggerClickedHandler handler = (TriggerClickedHandler)Events[EventTriggerClicked];

            if (handler != null)
            {
                handler(this, e);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("submitValue", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        public virtual string SubmitValueProxy
        {
            get 
            { 
                if(this.ViewState["SubmitValue"] != null)
                {
                    return JSON.Serialize(this.SubmitValue);
                }

                if (this.ViewState["HiddenName"] == null)
                {
                    return "true";
                }

                return "";
            }
        }

        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected static readonly object EventValueChanged = new object();

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected static readonly object EventItemSelected = new object();

        /// <summary>
        /// Fires when the Item property has been changed
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Item property has been changed")]
        public event EventHandler ValueChanged
        {
            add
            {
                this.Events.AddHandler(EventValueChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventValueChanged, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Category("Action")]
        [Description("Fires when the Item property has been selected")]
        public event EventHandler ItemSelected
        {
            add
            {
                this.Events.AddHandler(EventItemSelected, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventItemSelected, value);
            }
        }

        private bool onValueChangedRaised;
        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnValueChanged(EventArgs e)
        {
            if(this.onValueChangedRaised)
            {
                return;
            }

            this.onValueChangedRaised = true;

            EventHandler handler = (EventHandler)this.Events[EventValueChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnItemSelected(EventArgs e)
        {
            EventHandler handler = (EventHandler)this.Events[EventItemSelected];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(ComboAutoPostBackEvent.Select)]
        [Category("8. ComboBox")]
        [Description("")]
        public ComboAutoPostBackEvent AutoPostBackEvent
        {
            get
            {
                object obj = this.ViewState["AutoPostBackEvent"];
                return obj == null ? ComboAutoPostBackEvent.Select : (ComboAutoPostBackEvent)obj;
            }
            set
            {
                this.ViewState["AutoPostBackEvent"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected void InitPostBack()
        {
            if (!this.ClientID.Equals(this.UniqueName))
            {
                this.CustomConfig.Add(new ConfigItem("uniqueName", this.UniqueName, ParameterMode.Value));
            }

            if (this.TriggerAutoPostBack)
            {
                this.PostBackArgument = "_index_";
                string replace = "'".ConcatWith(this.PostBackArgument, "'");
                this.On("triggerclick", new JFunction(this.PostBackFunction.Replace(replace, "index"), "el", "t", "index"));
            }


            if (this.AutoPostBack)
            {
                EventHandler handler = (EventHandler)Events[EventItemSelected];

                if (handler != null)
                {
                    this.PostBackArgument = "select";

                    this.On("select", new JFunction(this.PostBackFunction));
                }
                else
                {
                    HandlerConfig config = new HandlerConfig();
                    config.Delay = 10;

                    this.PostBackArgument = "change";
                    this.On("blur", new JFunction(this.PostBackFunction), "this", config);
                }
            }
        }

        private JFunction getListParent;

        /// <summary>
        /// Returns the element used to house this ComboBox's pop-up list. Defaults to the document body.
        /// A custom implementation may be provided as a configuration option if the floating list needs to be rendered to a different Element. 
        /// An example might be rendering the list inside a Menu so that clicking the list does not hide the Menu:
        /// 
        /// <GetListParent Handler="return this.el.up('.x-menu');" />
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("8. ComboBox")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Returns the element used to house this ComboBox's pop-up list. Defaults to the document body.")]
        public virtual JFunction GetListParent
        {
            get
            {
                if (this.getListParent == null)
                {
                    this.getListParent = new JFunction();
                }

                return this.getListParent;
            }
        }



        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Clears any text/value currently set in the field
        /// </summary>
        [Meta]
        [Description("Clears any text/value currently set in the field")]
        public virtual void ClearValue()
        {
            RequestManager.EnsureDirectEvent(); 
            this.Call("clearValue");
        }

        /// <summary>
        /// Hides the dropdown list if it is currently expanded. Fires the collapse event on completion.
        /// </summary>
        [Meta]
        [Description("Hides the dropdown list if it is currently expanded. Fires the collapse event on completion.")]
        public virtual void Collapse()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("collapse");
        }

        /// <summary>
        /// Execute a query to filter the dropdown list. Fires the beforequery event prior to performing the query allowing the query action to be canceled if needed.
        /// </summary>
        /// <param name="query">The SQL query to execute</param>
        /// <param name="forceAll">true to force the query to execute even if there are currently fewer characters in the field than the minimum specified by the minChars config option. It also clears any filter previously saved in the current store </param>
        [Meta]
        [Description("Execute a query to filter the dropdown list. Fires the beforequery event prior to performing the query allowing the query action to be canceled if needed.")]
        public virtual void DoQuery(string query, bool forceAll)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("doQuery", query, forceAll);
        }

        /// <summary>
        /// Execute a query to filter the dropdown list. Fires the beforequery event prior to performing the query allowing the query action to be canceled if needed.
        /// </summary>
        /// <param name="query">The SQL query to execute</param>
        [Meta]
        [Description("Execute a query to filter the dropdown list. Fires the beforequery event prior to performing the query allowing the query action to be canceled if needed.")]
        public virtual void DoQuery(string query)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("doQuery", query);
        }

        /// <summary>
        /// Expands the dropdown list if it is currently hidden. Fires the expand event on completion.
        /// </summary>
        [Meta]
        [Description("Expands the dropdown list if it is currently hidden. Fires the expand event on completion.")]
        public virtual void Expand()
        {
            RequestManager.EnsureDirectEvent();
            this.Call("expand");
        }

        /// <summary>
        /// Select an item in the dropdown list by its numeric index in the list. This function does NOT cause the select event to fire. The store must be loaded and the list expanded for this function to work, otherwise use setValue.
        /// </summary>
        /// <param name="index">The zero-based index of the list item to select</param>
        /// <param name="scrollIntoView">False to prevent the dropdown list from autoscrolling to display the selected item if it is not currently in view</param>
        [Meta]
        [Description("Select an item in the dropdown list by its numeric index in the list. This function does NOT cause the select event to fire. The store must be loaded and the list expanded for this function to work, otherwise use setValue.")]
        public virtual void Select(int index, bool scrollIntoView)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("select", index, scrollIntoView);
        }

        /// <summary>
        /// Select an item in the dropdown list by its numeric index in the list. This function does NOT cause the select event to fire. The store must be loaded and the list expanded for this function to work, otherwise use setValue.
        /// </summary>
        /// <param name="index">The zero-based index of the list item to select</param>
        [Meta]
        [Description("Select an item in the dropdown list by its numeric index in the list. This function does NOT cause the select event to fire. The store must be loaded and the list expanded for this function to work, otherwise use setValue.")]
        public virtual void Select(int index)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("select", index);
        }

        /// <summary>
        /// Select an item in the dropdown list by its data value. This function does NOT cause the select event to fire. The store must be loaded and the list expanded for this function to work, otherwise use setValue.
        /// </summary>
        /// <param name="value">The data value of the item to select</param>
        /// <param name="scrollIntoView">False to prevent the dropdown list from autoscrolling to display the selected item if it is not currently in view</param>
        [Meta]
        [Description("Select an item in the dropdown list by its data value. This function does NOT cause the select event to fire. The store must be loaded and the list expanded for this function to work, otherwise use setValue.")]
        public virtual void SelectByValue(string value, bool scrollIntoView)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("selectByValue", value, scrollIntoView);
        }

        /// <summary>
        /// Select an item in the dropdown list by its data value. This function does NOT cause the select event to fire. The store must be loaded and the list expanded for this function to work, otherwise use setValue.
        /// </summary>
        /// <param name="value">The data value of the item to select</param>
        [Meta]
        [Description("Select an item in the dropdown list by its data value. This function does NOT cause the select event to fire. The store must be loaded and the list expanded for this function to work, otherwise use setValue.")]
        public virtual void SelectByValue(string value)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("selectByValue", value);
        }

        /// <summary>
        /// Insert record
        /// </summary>
        /// <param name="index"></param>
        /// <param name="values"></param>
        [Meta]
        [Description("Insert record")]
        public virtual void InsertRecord(int index, IDictionary<string,object> values)
        {
            RequestManager.EnsureDirectEvent();
            this.Call("insertRecord", index, values);
        }

        /// <summary>
        /// Add record
        /// </summary>
        /// <param name="values"></param>
        [Meta]
        [Description("Add record")]
        public virtual void AddRecord(IDictionary<string, object> values)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("addRecord", values);
        }

        /// <summary>
        /// Insert item
        /// </summary>
        /// <param name="index"></param>
        /// <param name="text"></param>
        /// <param name="value"></param>
        [Meta]
        [Description("Insert item")]
        public virtual void InsertItem(int index, string text, object value)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("insertItem", index, text, value);
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        [Meta]
        [Description("Add item")]
        public virtual void AddItem(string text, object value)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("addItem", text, value);
        }

        /// <summary>
        /// Remove by field
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        [Meta]
        [Description("Remove by field")]
        public virtual void RemoveByField(string field, object value)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("removeByField", field, value);
        }

        /// <summary>
        /// Remove by index
        /// </summary>
        /// <param name="index"></param>
        [Meta]
        [Description("Remove by index")]
        public virtual void RemoveByIndex(int index)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("removeByIndex", index);
        }

        /// <summary>
        /// Remove by value
        /// </summary>
        /// <param name="value"></param>
        [Meta]
        [Description("Remove by value")]
        public virtual void RemoveByValue(string value)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("removeByValue", value);
        }

        /// <summary>
        /// Remove by text
        /// </summary>
        /// <param name="text"></param>
        [Meta]
        [Description("Remove by text")]
        public virtual void RemoveByText(string text)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("removeByText", text);
        }

        /// <summary>
        /// Sets a data value into the field and validates it. To set the value directly without validation see setRawValue.
        /// </summary>
        /// <param name="value"></param>
        [Meta]
        [Description("Sets a data value into the field and validates it. To set the value directly without validation see setRawValue.")]
        public virtual void SetValueAndFireSelect(object value)
        {
            List<JsonConverter> converters = new List<JsonConverter>();
            converters.Add(new CtorDateTimeJsonConverter());

            this.Call("setValueAndFireSelect", new JRawValue(JSON.Serialize(value, converters)));
            this.ClearInvalid();
        }

        /// <summary>
        /// Sets a data value into the field and validates it. To set the value directly without validation see setRawValue.
        /// </summary>
        /// <param name="value"></param>
        [Meta]
        [Description("Sets a data value into the field and validates it. To set the value directly without validation see setRawValue.")]
        public virtual void SetInitValue(object value)
        {
            List<JsonConverter> converters = new List<JsonConverter>();
            converters.Add(new CtorDateTimeJsonConverter());

            this.Call("setInitValue", new JRawValue(JSON.Serialize(value, converters)));
            this.ClearInvalid();
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