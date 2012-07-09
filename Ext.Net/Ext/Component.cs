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
using System.Globalization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Base Class for all Ext.Net Web Controls.
    /// </summary>
    [Meta]
    [Description("Base Class for all Ext.Net Web Controls.")]
    public abstract partial class Component : Observable, IComponent, IContent
    {
        /// <summary>
        /// The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.
        /// </summary>
        [Category("0. About")]
        [Description("The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.")]
        public override string XType
        {
            get
            {
                return "component";
            }
        }

        private ItemsCollection<Observable> bin;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("bin", typeof(ItemCollectionJsonConverter), int.MinValue)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual ItemsCollection<Observable> Bin
        {
            get
            {
                this.InitBin();
                return this.bin;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected internal void InitBin()
        {
            if (this.bin == null)
            {
                this.bin = new ItemsCollection<Observable>();
                this.bin.AfterItemAdd += this.AfterBinItemAdd;
                this.bin.AfterItemRemove += this.AfterItemRemove;
                this.bin.SingleItemMode = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void AfterBinItemAdd(Observable item)
        {
            item.LazyMode = LazyMode.Instance;
            this.AfterItemAdd(item);
        }


        /*  IContent
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool PreventContent
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// The id of an existing HTML node to use as the panel's body content (defaults to '').
        /// </summary>
        [ConfigOption]
        [Category("6. Panel")]
        [DeferredRender]
        [DefaultValue("")]
        [Description("The id of an existing HTML node to use as the panel's body content (defaults to '').")]
        public virtual string ContentEl
        {
            get
            {
                if (!this.DesignMode)
                {
                    if (this.PreventContent)
                    {
                        return "";
                    }

                    if (!this.ContentContainer.Visible)
                    {
                        return "";
                    }

                    if (this.Content == null && this.ContentControls.Count < 1)
                    {
                        this.ContentContainer.Visible = false;
                        return "";
                    }

                    this.ContentContainer.Visible = true;
                }

                if (this is INoneContentable)
                {
                    throw new Exception(this.GetType().ToString() + " cannot use Content");
                }

                return this.ContentContainer.ClientID;
            }
        }

        protected override object SaveViewState()
        {
            if (this.Content == null && this.ContentControls.Count < 1)
            {
                this.ContentContainer.Visible = false;
                this.ContentContainer.EnableViewState = false;
            }

            return base.SaveViewState();
        }

        private ITemplate content;

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Browsable(false)]
        [TemplateInstance(TemplateInstance.Single)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ITemplate Content
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;

                if (value != null)
                {
                    value.InstantiateIn(this.ContentContainer);
                }
            }
        }

        private HtmlGenericControl contentContainer;

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public virtual HtmlGenericControl ContentContainer
        {
            get
            {
                if (this.contentContainer == null)
                {
                    this.contentContainer = this.CreateContainer();
                }

                return this.contentContainer;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public ControlCollection ContentControls
        {
            get
            {
                return this.ContentContainer.Controls;
            }
        }

        /// <summary>
        /// An HTML fragment, or a DomHelper specification to use as the layout element content (defaults to ''). The HTML content is added after the component is rendered, so the document will not contain this HTML at the time the render event is fired. This content is inserted into the body before any configured contentEl is appended.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "Update")]
        [ConfigOption("html")]
        [Category("3. Component")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An HTML fragment, or a DomHelper specification to use as the layout element content (defaults to '')")]
        public virtual string Html
        {
            get
            {
                return (string)this.ViewState["Html"] ?? "";
            }
            set
            {
                this.ViewState["Html"] = value;
            }
        }

        /*  End IContent
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// This Component's owner Container (defaults to undefined, and is set automatically when this Component is added to a Container). Read-only.
        /// </summary>
        [Description("This Component's owner Container (defaults to undefined, and is set automatically when this Component is added to a Container). Read-only.")]
        public virtual ContainerBase OwnerCt
        {
            get
            {
                Control parent = this.Parent;

                if (parent is Layout)
                {
                    parent = parent.Parent;
                }

                return parent is ContainerBase ? parent as ContainerBase : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual Element Element
        {
            get
            {
                return new Element(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (!RequestManager.IsAjaxRequest && this.Plugins.Count > 0)
            {
                GenericPlugin plug;

                this.Plugins.Each(plugin => {
                    if (plugin is GenericPlugin)
                    {
                        plug = (GenericPlugin)plugin;

                        if (plug.Path.IsNotEmpty())
                        {
                            plug.Path.Split(',').Each(path =>
                            {
                                path = path.Trim();
                                this.ResourceManager.RegisterClientScriptInclude(plugin.ClientID.ConcatWith("_", path), this.ResolveUrl(path));
                            });
                        }
                    }
                });
            }

            if (this.ContentContainer != null && !this.DesignMode)
            {
                this.ContentContainer.ID = this.ID.ConcatWith("_Content");
                this.ContentContainer.Attributes.Add("class", "x-hidden");
            }

            base.OnPreRender(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void PagePreLoad(object sender, EventArgs e)
        {
            if (this is IXPostBackDataHandler && !this.IsDynamic && (ExtNet.IsAjaxRequest || (this.Page != null && this.Page.IsPostBack)))
            {
                IXPostBackDataHandler ctrl = (IXPostBackDataHandler)this;

                if (ctrl != null && !ctrl.HasLoadPostData)
                {
                    ctrl.LoadPostData(this.ConfigID, this.Context.Request.Params);
                }
            }

            base.PagePreLoad(sender, e);
        }

        #region AnchorLayout properties

        /// <summary>
        /// This configuation option is to be applied to child items of a container managed by this layout (ie. configured with layout:'anchor').
        /// This value is what tells the layout how an item should be anchored to the container. items added 
        /// to an AnchorLayout accept an anchoring-specific config property of anchor which is a string containing two values: 
        /// the horizontal anchor value and the vertical anchor value (for example, '100% 50%'). 
        /// 
        /// The following types of anchor values are supported:
        ///     Percentage : Any value between 1 and 100, expressed as a percentage.
        ///         The first anchor is the percentage width that the item should take up within the container, 
        ///         and the second is the percentage height. For example:
        ///         // two values specified
        ///         anchor: '100% 50%' // render item complete width of the container and
        ///                            // 1/2 height of the container
        /// 
        ///         // one value specified
        /// 
        ///         anchor: '100%'     // the width value; the height will default to auto
        ///     
        ///     Offsets : Any positive or negative integer value.
        ///         This is a raw adjustment where the first anchor is the offset from the right edge of the container, 
        ///         and the second is the offset from the bottom edge. For example:
        ///         // two values specified
        /// 
        ///         anchor: '-50 -100' // render item the complete width of the container
        ///                            // minus 50 pixels and
        ///                            // the complete height minus 100 pixels.
        /// 
        ///         // one value specified
        /// 
        ///         anchor: '-50'      // anchor value is assumed to be the right offset value
        ///                            // bottom offset will default to 0
        /// 
        ///     Sides : Valid values are 'right' (or 'r') and 'bottom' (or 'b').
        ///         Either the container must have a fixed size or an anchorSize config value 
        ///         defined at render time in order for these to have any effect.
        ///     
        ///     Mixed :
        ///         Anchor values can also be mixed as needed. For example, to render the width 
        ///         offset from the container right edge by 50 pixels and 75% of the container's height use:
        ///         anchor: '-50 75%'
        /// </summary>
        [Meta]
        [Category("3. Component - AnchorLayout")]
        [DefaultValue(null)]
        [Description("This config is only used when this Component is rendered by a Container which has been configured to use an AnchorLayout based layout manager")]
        [DirectEventUpdate(MethodName = "SetAnchor")]
        public virtual string Anchor
        {
            get
            {
                return (string)this.ViewState["Anchor"] ?? null;
            }
            set
            {
                this.ViewState["Anchor"] = value;
            }
        }

        /// <summary>
        /// The DefaultAnchor is applied as the Anchor config item to all child Items during render.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component - AnchorLayout")]
        [DefaultValue(null)]
        [Description("The DefaultAnchor is applied as the Anchor config item to all child Items during render.")]
        public virtual string DefaultAnchor
        {
            get
            {
                return (string)this.ViewState["DefaultAnchor"] ?? null;
            }
            set
            {
                this.ViewState["DefaultAnchor"] = value;
            }
        }

        /// <summary>
        /// See Anchor property
        /// </summary>
        [Meta]
        [Category("3. Component - AnchorLayout")]
        [DefaultValue("")]
        [Description("See Anchor property")]
        [DirectEventUpdate(MethodName = "SetAnchor")]
        public virtual string AnchorHorizontal
        {
            get
            {
                return (string)this.ViewState["AnchorHorizontal"] ?? "";
            }
            set
            {
                this.ViewState["AnchorHorizontal"] = value;
            }
        }

        /// <summary>
        /// See Anchor property
        /// </summary>
        [Meta]
        [Category("3. Component - AnchorLayout")]
        [DefaultValue("")]
        [Description("See Anchor property")]
        public virtual string AnchorVertical
        {
            get
            {
                return (string)this.ViewState["AnchorVertical"] ?? "";
            }
            set
            {
                this.ViewState["AnchorVertical"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("anchor")]
        [DefaultValue(null)]
		[Description("")]
        protected virtual string AnchorProxy
        {
            get
            {
                if (this.Anchor.IsEmpty())
                {
                    if (this.AnchorVertical.IsEmpty() && this.AnchorHorizontal.IsNotEmpty())
                    {
                        return this.AnchorHorizontal;
                    }
                    else if (this.AnchorHorizontal.IsNotEmpty() && this.AnchorVertical.IsNotEmpty())
                    {
                        return this.AnchorHorizontal.ConcatWith(" ", this.AnchorVertical);
                    }
                }

                return this.Anchor;
            }
        }

        #endregion

        #region ColumnLayout properties

        /// <summary>
        /// The ColumnWidth property is only used with ColumnLayout is used. The ColumnWidth property is always evaluated as a percentage, and must be a decimal value greater than 0 and less than 1.
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [Category("3. Component - ColumnLayout")]
        [DefaultValue(0.0)]
        [Description("The ColumnWidth property is only used with ColumnLayout is used. The ColumnWidth property is always evaluated as a percentage, and must be a decimal value greater than 0 and less than 1.")]
        public virtual double ColumnWidth
        {
            get
            {
                object obj = this.ViewState["ColumnWidth"];
                return (obj == null) ? 0.0 : (double)obj;
            }
            set
            {
                if (value > 1 || value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", value, "The value must be greater than 0 and less than or equal to 1.0.");
                }

                this.ViewState["ColumnWidth"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("columnWidth", JsonMode.Raw)]
        [DefaultValue("0")]
        [Browsable(false)]
        [Description("")]
        protected string ColumnWidthProxy
        {
            get
            {
                NumberFormatInfo nf = new NumberFormatInfo();
                nf.CurrencyDecimalSeparator = ".";

                return ColumnWidth.ToString(nf);
            }
        }

        #endregion

        #region FormLayout properties

        /// <summary>
        /// True if component should be rendered as a Form Field with a Field Label and Label separator (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component - FormLayout")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True if component should be rendered as a Form Field with a Field Label and Label separator (defaults to false).")]
        public virtual bool IsFormField
        {
            get
            {
                object obj = this.ViewState["IsFormField"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["IsFormField"] = value;
            }
        }

        /// <summary>
        /// The separator to display after the text of each fieldLabel. This property may be configured at various levels.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component - FormLayout")]
        [DefaultValue(":")]
        [Description("The separator to display after the text of each fieldLabel. This property may be configured at various levels.")]
        public virtual string LabelSeparator
        {
            get
            {
                return (string)this.ViewState["LabelSeparator"] ?? ":";
            }
            set
            {
                this.ViewState["LabelSeparator"] = value;
            }
        }

        /// <summary>
        /// A CSS style specification string to apply directly to this field's label. Defaults to the container's labelStyle value if set (eg, Ext.layout.FormLayout.labelStyle , or '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component - FormLayout")]
        [DefaultValue("")]
        [Description("A CSS style specification string to apply directly to this field's label. Defaults to the container's labelStyle value if set (eg, Ext.layout.FormLayout.labelStyle , or '').")]
        public virtual string LabelStyle
        {
            get
            {
                return (string)this.ViewState["LabelStyle"] ?? "";
            }
            set
            {
                this.ViewState["LabelStyle"] = value;
            }
        }

        /// <summary>
        /// True to hide field labels by default (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Container")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to hide field labels by default (defaults to false).")]
        public virtual bool HideLabels
        {
            get
            {
                object obj = this.ViewState["HideLabels"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideLabels"] = value;
            }
        }

        /// <summary>
        /// The default label alignment. The default value is empty string '' for left alignment, but specifying 'top' will align the labels above the fields.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Container")]
        [DefaultValue(LabelAlign.Left)]
        [NotifyParentProperty(true)]
        [Description("The default label alignment. The default value is empty string '' for left alignment, but specifying 'top' will align the labels above the fields.")]
        public virtual LabelAlign LabelAlign
        {
            get
            {
                object obj = this.ViewState["LabelAlign"];
                return (obj == null) ? LabelAlign.Left : (LabelAlign)obj;
            }
            set
            {
                this.ViewState["LabelAlign"] = value;
            }
        }

        /// <summary>
        /// The default width in pixels of field labels (defaults to 100).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Container")]
        [DefaultValue(100)]
        [NotifyParentProperty(true)]
        [Description("The default width in pixels of field labels (defaults to 100).")]
        public virtual int LabelWidth
        {
            get
            {
                object obj = this.ViewState["LabelWidth"];
                return (obj == null) ? 100 : (int)obj;
            }
            set
            {
                this.ViewState["LabelWidth"] = value;
            }
        }

        /// <summary>
        /// The default padding in pixels for field labels (defaults to 5). labelPad only applies if labelWidth is also specified, otherwise it will be ignored.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Container")]
        [DefaultValue(5)]
        [NotifyParentProperty(true)]
        [Description("The default padding in pixels for field labels (defaults to 5). labelPad only applies if labelWidth is also specified, otherwise it will be ignored.")]
        public virtual int LabelPad
        {
            get
            {
                object obj = this.ViewState["LabelPad"];
                return (obj == null) ? 5 : (int)obj;
            }
            set
            {
                this.ViewState["LabelPad"] = value;
            }
        }

        #endregion

        #region VBox/HBoxLayout properties

        /// <summary>
        /// NOTE: This property is only used when the parent Layout is HBoxLayout or VBoxLayout. This configuation option is to be applied to child items of the container managed by this layout. Each child item with a flex property will be flexed horizontally according to each item's relative flex value compared to the sum of all items with a flex value specified. Any child items that have either a flex = 0 or flex = undefined will not be 'flexed' (the initial size will not be changed).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. BoxItem")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("NOTE: This property is only used when the parent Layout is HBoxLayout or VBoxLayout. This configuation option is to be applied to child items of the container managed by this layout. Each child item with a flex property will be flexed horizontally according to each item's relative flex value compared to the sum of all items with a flex value specified. Any child items that have either a flex = 0 or flex = undefined will not be 'flexed' (the initial size will not be changed).")]
        public virtual int Flex
        {
            get
            {
                object obj = this.ViewState["Flex"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["Flex"] = value;
            }
        }

        #endregion

        #region RowLayout properties

        /// <summary>
        /// The ColumnWidth property is always evaluated as a percentage, and must be a decimal value greater than 0 and less than or equal to 1.0.
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [Category("3. Compoenrnt - RowLayout")]
        [DefaultValue(0.0)]
        [Description("The ColumnWidth property is always evaluated as a percentage, and must be a decimal value greater than 0 and less than or equal to 1.0.")]
        public virtual double RowHeight
        {
            get
            {
                object obj = this.ViewState["RowHeight"];
                return (obj == null) ? 0.0 : (double)obj;
            }
            set
            {
                if (value > 1 || value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", value, "The value must be greater than 0 and less than or equal to 1.0.");
                }

                this.ViewState["RowHeight"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("rowHeight", JsonMode.Raw)]
        [DefaultValue("0")]
        [Browsable(false)]
        [Description("")]
        protected string RowHeightProxy
        {
            get
            {
                NumberFormatInfo nf = new NumberFormatInfo();
                nf.CurrencyDecimalSeparator = ".";

                return RowHeight.ToString(nf);
            }
        }

        #endregion

        private object additionalConfig;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.UnrollObject)]
        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected internal object AdditionalConfig
        {
            get
            {
                return additionalConfig;
            }
            set
            {
                additionalConfig = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("3. Component")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(MenuBase))]
        public virtual string ContextMenuID
        {
            get
            {
                return (string)this.ViewState["ContextMenuID"] ?? "";
            }
            set
            {
                this.ViewState["ContextMenuID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("contextMenuId")]
        protected virtual string ContextMenuIDProxy
        {
            get
            {
                if (this.ContextMenuID.IsNotEmpty())
                {
                    Control menu = ControlUtils.FindControl(this, this.ContextMenuID, true);

                    if (menu == null)
                    {
                        throw new InvalidOperationException("The Menu with the ID of '{0}' was not found.".FormatWith(this.ContextMenuID));
                    }

                    return menu.ClientID;
                }

                return "";
            }
        }


        /*  Config Properties
           -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Whether the component can move the Dom node when rendering (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue(true)]
        [Description("Whether the component can move the Dom node when rendering (defaults to true).")]
        public virtual bool AllowDomMove
        {
            get
            {
                object obj = this.ViewState["AllowDomMove"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AllowDomMove"] = value;
            }
        }

        /// <summary>
        /// Specify the id of the element, a DOM element or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.
        /// </summary>
        [Meta]
        [Category("3. Component")]
        [DefaultValue("")]
        [Description("Specify the id of the element, a DOM element or an existing Element corresponding to a DIV that is already present in the document that specifies some structural markup for this component.")]
        public virtual string ApplyTo
        {
            get
            {
                return (string)this.ViewState["ApplyTo"] ?? "";
            }
            set
            {
                this.ViewState["ApplyTo"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("applyTo")]
        [DefaultValue("")]
        protected virtual string ApplyToProxy
        {
            get
            {
                return  this.IsLazy ? "" : this.ApplyTo;
            }
        }

        private DomObject autoEl;

        /// <summary>
        /// A tag name or DomHelper spec used to create the Element which will encapsulate this Component.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [Category("3. Component")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A tag name or DomHelper spec used to create the Element which will encapsulate this Component.")]
        public virtual DomObject AutoEl
        {
            get
            {
                if (this.autoEl == null)
                {
                    this.autoEl = new DomObject();
                }

                return this.autoEl;
            }
        }

        /// <summary>
        /// True if the component should check for hidden classes (e.g. 'x-hidden' or 'x-hide-display') and remove them on render (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True if the component should check for hidden classes (e.g. 'x-hidden' or 'x-hide-display') and remove them on render (defaults to false).")]
        public virtual bool AutoShow
        {
            get
            {
                object obj = this.ViewState["AutoShow"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoShow"] = value;
            }
        }

        /// <summary>
        /// The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue("x-form-clear-left")]
        [Description("The CSS class used to to apply to the special clearing div rendered directly after each form field wrapper to provide field clearing (defaults to 'x-form-clear-left').")]
        public virtual string ClearCls
        {
            get
            {
                return (string)this.ViewState["ClearCls"] ?? "x-form-clear-left";
            }
            set
            {
                this.ViewState["ClearCls"] = value;
            }
        }

        /// <summary>
        /// An optional extra CSS class that will be added to this component's Element (defaults to ''). This can be useful for adding customized styles to the component or any of its children using standard CSS rules.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "AddClass")]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An optional extra CSS class that will be added to this component's Element (defaults to ''). This can be useful for adding customized styles to the component or any of its children using standard CSS rules.")]
        public virtual string Cls
        {
            get
            {
                return (string)this.ViewState["Cls"] ?? "";
            }
            set
            {
                this.ViewState["Cls"] = value;
            }
        }

        /// <summary>
        /// An optional extra CSS class that will be added to this component's container. This can be useful for adding customized styles to the container or any of its children using standard CSS rules.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An optional extra CSS class that will be added to this component's container. This can be useful for adding customized styles to the container or any of its children using standard CSS rules.")]
        public virtual string CtCls
        {
            get
            {
                return (string)this.ViewState["CtCls"] ?? "";
            }
            set
            {
                this.ViewState["CtCls"] = value;
            }
        }

        /// <summary>
        /// Render this component disabled (default is false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetDisabled")]
        [Category("3. Component")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Render this component disabled (default is false).")]
        public virtual bool Disabled
        {
            get
            {
                object obj = this.ViewState["Disabled"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Disabled"] = value;
            }
        }

        /// <summary>
        /// Render this component disabled (default is false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetSelectable")]
        [Category("3. Component")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Determines if this component is selectable. (default is true).")]
        public virtual bool Selectable
        {
            get
            {
                object obj = this.ViewState["Selectable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Selectable"] = value;
            }
        }

        /// <summary>
        /// CSS class added to the component when it is disabled (defaults to 'x-item-disabled').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("CSS class added to the component when it is disabled (defaults to 'x-item-disabled').")]
        public virtual string DisabledClass
        {
            get
            {
                return (string)this.ViewState["DisabledClass"] ?? "";
            }
            set
            {
                this.ViewState["DisabledClass"] = value;
            }
        }

        /// <summary>
        /// The label text to display next to this Component (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetFieldLabel")]
        [Category("3. Component")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The label text to display next to this Component (defaults to '').")]
        public virtual string FieldLabel
        {
            get
            {
                return (string)this.ViewState["FieldLabel"] ?? "";
            }
            set
            {
                this.ViewState["FieldLabel"] = value;
            }
        }

        /// <summary>
        /// Render this component hidden (default is false). If true, the hide method will be called internally.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(Script = "{0}.setVisible(!{1});")]
        [Category("3. Component")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Render this component hidden (default is false). If true, the hide method will be called internally.")]
        public virtual bool Hidden
        {
            get
            {
                object obj = this.ViewState["Hidden"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Hidden"] = value;
            }
        }

        /// <summary>
        /// true to completely hide the label element (label and separator). Defaults to false. By default, even if you do not specify a fieldLabel the space will still be reserved so that the field will line up with other fields that do have labels. Setting this to true will cause the field to not reserve that space.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue(false)]
        [Description("true to completely hide the label element (label and separator). Defaults to false. By default, even if you do not specify a fieldLabel the space will still be reserved so that the field will line up with other fields that do have labels. Setting this to true will cause the field to not reserve that space.")]
        public virtual bool HideLabel
        {
            get
            {
                object obj = this.ViewState["HideLabel"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideLabel"] = value;
            }
        }

        /// <summary>
        /// How this component should be hidden. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. Component")]
        [DefaultValue(HideMode.Display)]
        [NotifyParentProperty(true)]
        [Description("How this component should be hidden. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display).")]
        public virtual HideMode HideMode
        {
            get
            {
                object obj = this.ViewState["HideMode"];
                return (obj == null) ? HideMode.Display : (HideMode)obj;
            }
            set
            {
                this.ViewState["HideMode"] = value;
            }
        }

        /// <summary>
        /// True to hide and show the component's container when hide/show is called on the component, false to hide and show the component itself (defaults to false). 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to hide and show the component's container when hide/show is called on the component, false to hide and show the component itself (defaults to false).")]
        public virtual bool HideParent
        {
            get
            {
                object obj = this.ViewState["HideParent"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideParent"] = value;
            }
        }

        /// <summary>
        /// An additional CSS class to apply to the div wrapping the form item element of this field.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue("")]
        [Description("An additional CSS class to apply to the div wrapping the form item element of this field.")]
        public virtual string ItemCls
        {
            get
            {
                return (string)this.ViewState["ItemCls"] ?? "";
            }
            set
            {
                this.ViewState["ItemCls"] = value;
            }
        }        

        /// <summary>
        /// An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An optional extra CSS class that will be added to this component's Element when the mouse moves over the Element, and removed when the mouse moves out. (defaults to '').")]
        public virtual string OverCls
        {
            get
            {
                return (string)this.ViewState["OverCls"] ?? "";
            }
            set
            {
                this.ViewState["OverCls"] = value;
            }
        }

        /// <summary>
        /// The registered ptype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a Plugin is being specified not as a fully instantiated Component, but as a Component config object. The ptype will be looked up at render time up to determine what type of Plugin to create.
        /// </summary>
        [Meta]
        [ConfigOption("ptype")]
        [Category("3. Component")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The registered ptype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a Plugin is being specified not as a fully instantiated Component, but as a Component config object. The ptype will be looked up at render time up to determine what type of Plugin to create.")]
        public virtual string PType
        {
            get
            {
                return (string)this.ViewState["PType"] ?? "";
            }
            set
            {
                this.ViewState["PType"] = value;
            }
        }

        /// <summary>
        /// A path specification, relative to the Component's ownerCt specifying into which ancestor Container to place a named reference to this Component. The ancestor axis can be traversed by using '/' characters in the path.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A path specification, relative to the Component's ownerCt specifying into which ancestor Container to place a named reference to this Component. The ancestor axis can be traversed by using '/' characters in the path.")]
        public virtual string Ref
        {
            get
            {
                return (string)this.ViewState["Ref"] ?? "";
            }
            set
            {
                this.ViewState["Ref"] = value;
            }
        }

        /// <summary>
        /// The id of the node, a DOM node or an existing Element that will be the content Container to render this component into.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The id of the node, a DOM node or an existing Element that will be the content Container to render this component into.")]
        public virtual string RenderTo
        {
            get
            {
                return (string)this.ViewState["RenderTo"] ?? "";
            }
            set
            {
                this.ViewState["RenderTo"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected internal string TopDynamicRenderTo
        {
            get
            {
                return (this.Page != null && this.Page.Form != null)
                           ? string.Concat("={Ext.get(", JSON.Serialize(this.Page.Form.ClientID), ")}")
                           : "={Ext.getBody()}";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("renderTo")]
        [DefaultValue("")]
        protected internal virtual string RenderToProxy
        {
            get
            {
                if (!this.IsLazy && this.AutoRender)
                {
                    return this.RenderTo.IsEmpty() ? (this.TopDynamicControl ? this.TopDynamicRenderTo : (this.RemoveContainer ? "" : this.ContainerID)) : this.RenderTo;
                }

                return "";
            }
        }

        /// <summary>
        /// An array of events that, when fired, should trigger this component to save its state (defaults to none). These can be any types of events supported by this component, including browser or custom events (e.g., ['click', 'customerchange']).
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [Category("3. Component")]
        [DefaultValue(null)]
        [Description("An array of events that, when fired, should trigger this component to save its state (defaults to none). These can be any types of events supported by this component, including browser or custom events (e.g., ['click', 'customerchange']).")]
        public virtual string[] StateEvents
        {
            get
            {
                object obj = this.ViewState["StateEvents"];
                return (obj == null) ? null : (string[])obj;
            }
            set
            {
                this.ViewState["StateEvents"] = value;
            }
        }

        /// <summary>
        /// The unique id for this component to use for state management purposes (defaults to the component id).
        /// </summary>
        [Meta]
        [ConfigOption("stateId")]
        [Category("3. Component")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The unique id for this component to use for state management purposes (defaults to the component id).")]
        public virtual string StateID
        {
            get
            {
                return (string)this.ViewState["StateID"] ?? "";
            }
            set
            {
                this.ViewState["StateID"] = value;
            }
        }

        /// <summary>
        /// A flag which causes the Component to attempt to restore the state of internal properties from a saved state on startup.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("A flag which causes the Component to attempt to restore the state of internal properties from a saved state on startup.")]
        public virtual bool Stateful
        {
            get
            {
                object obj = this.ViewState["Stateful"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Stateful"] = value;
            }
        }

        /// <summary>
        /// A custom style specification to be applied to this component's Element.
        /// </summary>
        [Meta]
        [ConfigOption("style")]
        [DirectEventUpdate(MethodName = "ApplyStyles")]
        [Category("3. Component")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A custom style specification to be applied to this component's Element.")]
        public virtual string StyleSpec
        {
            get
            {
                return (string)this.ViewState["StyleSpec"] ?? "";
            }
            set
            {
                this.ViewState["StyleSpec"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string ClientID
        {
            get
            {
                if (this.IsProxy)
                {
                    return this.ID;
                }
                else
                {
                    return base.ClientID;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        public override void AddScript(string script)
        {
            if (this.IsProxy && !this.GenerateMethodsCalling)
            {
                ResourceManager.AddInstanceScript(script);
            }
            else
            {
                base.AddScript(script);
            }
        }

        /*  Items
            -----------------------------------------------------------------------------------------------*/

        ItemsCollection<Plugin> plugins;

        /// <summary>
        /// An object or array of controls that inherit from IPlugin that will provide custom functionality for this component. The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself. Each plugin can then call methods or respond to events on the component as needed to provide its functionality.
        /// </summary>
        [Meta]
        [ConfigOption("plugins", typeof(ItemCollectionJsonConverter))]
        [Category("3. Component")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An object or array of controls that inherit from IPlugin that will provide custom functionality for this component. The only requirement for a valid plugin is that it contain an init method that accepts a reference of type Ext.Component. When a component is created, if any plugins are available, the component will call the init method on each plugin, passing a reference to itself. Each plugin can then call methods or respond to events on the component as needed to provide its functionality.")]
        public virtual ItemsCollection<Plugin> Plugins
        {
            get
            {
                if (this.plugins == null)
                {
                    this.plugins = new ItemsCollection<Plugin>();
                    this.plugins.AfterItemAdd += this.AfterPluginAdd;
                    this.plugins.AfterItemRemove += this.AfterPluginRemove;
                }

                return this.plugins;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plugin"></param>
        protected virtual void AfterPluginAdd(Plugin plugin)
        {
            this.Controls.Add(plugin);
            this.LazyItems.Add(plugin);
            plugin.PluginAdded();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plugin"></param>
        protected virtual void AfterPluginRemove(Plugin plugin)
        {
            this.Controls.Remove(plugin);
            this.LazyItems.Remove(plugin);
            plugin.PluginRemoved();
        }

        /// <summary>
        /// Automatically render control on client during page load. Default is true.
        /// </summary>
        [Meta]
        [Category("3. Component")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Automatically render control on client during page load. Default is true.")]
        public virtual bool AutoRender
        {
            get
            {
                object obj = this.ViewState["AutoRender"];
                return obj != null ? (bool) obj : true;
            }
            set
            {
                this.ViewState["AutoRender"] = value;
            }
        }

        private ItemsCollection<ToolTip> toolTips;

        /// <summary>
        /// A collection of ToolTip configs used to add ToolTips to the Component
        /// </summary>
        [Meta]
        [Category("3. Component")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A collection of ToolTip configs used to add ToolTips to the Component")]
        public virtual ItemsCollection<ToolTip> ToolTips
        {
            get
            {
                if (this.toolTips == null)
                {
                    this.toolTips = new ItemsCollection<ToolTip>();
                    this.toolTips.AfterItemAdd += ToolTips_AfterItemAdd;
                    this.toolTips.AfterItemRemove += ToolTips_AfterItemRemove;
                }

                return this.toolTips;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void ToolTips_AfterItemAdd(ToolTip item)
        {
            if (!this.Controls.Contains(item))
            {
                item.TargetControl = this;
                this.Controls.Add(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void ToolTips_AfterItemRemove(ToolTip item)
        {
            if (this.Controls.Contains(item))
            {
                this.Controls.Remove(item);
            }
        }

        private JFunction getState;

        /// <summary>
        /// Return component's data which should be saved by StateProvider
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Component")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Return component's data which should be saved by StateProvider")]
        public virtual JFunction GetState
        {
            get
            {
                if (this.getState == null)
                {
                    this.getState = new JFunction();
                }

                return this.getState;
            }
        }

        /// <summary>
        /// True to automatically set the focus after render (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue(false)]
        [Description("True to automatically set the focus after render (defaults to false).")]
        public virtual bool AutoFocus
        {
            get
            {
                object obj = this.ViewState["AutoFocus"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoFocus"] = value;
            }
        }

        /// <summary>
        /// Focus delay (in milliseconds) when AutoFocus is true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Component")]
        [DefaultValue(10)]
        [Description("Focus delay (in milliseconds) when AutoFocus is true.")]
        public virtual int AutoFocusDelay
        {
            get
            {
                object obj = this.ViewState["AutoFocusDelay"];
                return (obj == null) ? 10 : (int)obj;
            }
            set
            {
                this.ViewState["AutoFocusDelay"] = value;
            }
        }

        // TODO: "Ambiguous match found" Exception thrown in VS Designer and IIS if Parent class defines Listeners property.
        // For now, the Listeners property can only be implemented in the leaf (bottom child).
        // NOTE: Figure out some way to get this to work. Arg...
        // REFERENCE: http://en.csharp-online.net/CSharp_Coding_Solutions%E2%80%94Understanding_the_Overloaded_Return_Type_and_Property
        // REFERENCE: http://support.microsoft.com/kb/823194

        //private ComponentListeners listeners;

        //[Category("2. Observable")]
        //[Themeable(true)]
        //[NotifyParentProperty(true)]
        //[PersistenceMode(PersistenceMode.InnerProperty)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //[Description("Client-side JavaScript Event Handlers")]
        //public virtual ComponentListeners Listeners
        //{
        //    get
        //    {
        //        if (this.listeners == null)
        //        {
        //            this.listeners = new ComponentListeners();
        //        }
        //        return this.listeners;
        //    }
        //}


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the bubble is stopped.
        /// </summary>
        [Meta]
        [Description("Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the bubble is stopped.")]
        public virtual void Bubble(string function)
        {
            this.Call("bubble", new JRawValue(function));
        }

        /// <summary>
        /// Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the bubble is stopped.
        /// </summary>
        [Meta]
        [Description("Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the bubble is stopped.")]
        public virtual void Bubble(string function, string scope)
        {
            this.Call("bubble", new JRawValue(function), new JRawValue(scope));
        }

        /// <summary>
        /// Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the bubble is stopped.
        /// </summary>
        [Meta]
        [Description("Bubbles up the component/container heirarchy, calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the bubble is stopped.")]
        public virtual void Bubble(string function, string scope, Dictionary<string, object> args)
        {
            this.Call("bubble", new JRawValue(function), new JRawValue(scope), JSON.Serialize(args));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Meta]
        public virtual void CallEl(string name, params object[] args)
        {
            this.CallTemplate("{0}.el.{1}({2});", name, args);
        }

        /// <summary>
        /// Adds a CSS class to the component's underlying element.
        /// </summary>
        [Meta]
        [Description("Adds a CSS class to the component's underlying element.")]
        public virtual void AddClass(string cls)
        {
            this.Call("addClass", cls);
        }

        /// <summary>
        /// Adds a CSS class to the component's container.
        /// </summary>
        [Meta]
        [Description("Adds a CSS class to the component's container.")]
        public virtual void AddContainerClass(string cls)
        {
            this.Call("container.addClass", cls);
        }

        /// <summary>
        /// More flexible version of setStyle for setting style properties.
        /// </summary>
        [Meta]
        [Description("More flexible version of setStyle for setting style properties.")]
        public virtual void ApplyStyles(string styles)
        {
            this.CallEl("applyStyles", styles);
        }

        /// <summary>
        /// Destroys this component by purging any event listeners, removing the component's element from the DOM, removing the component from its Ext.Container (if applicable) and unregistering it from Ext.ComponentMgr. Destruction is generally handled automatically by the framework and this method should usually not need to be called directly.
        /// </summary>
        [Meta]
        [Description("Destroys this component by purging any event listeners, removing the component's element from the DOM, removing the component from its Ext.Container (if applicable) and unregistering it from Ext.ComponentMgr. Destruction is generally handled automatically by the framework and this method should usually not need to be called directly.")]
        public virtual void Destroy()
        {
            this.Call("destroy");
        }

        /// <summary>
        /// Try to focus this component.
        /// </summary>
        [Meta]
        [Description("Try to focus this component.")]
        new public virtual void Focus()
        {
            this.Call("focus");
        }

        /// <summary>
        /// Try to focus this component.
        /// </summary>
        [Meta]
        [Description("Try to focus this component.")]
        public virtual void Focus(bool selectText)
        {
            this.Call("focus", selectText);
        }

        /// <summary>
        /// Try to focus this component.
        /// </summary>
        [Meta]
        [Description("Try to focus this component.")]
        public virtual void Focus(bool selectText, int delay)
        {
            this.Call("focus", selectText, delay);
        }

        /// <summary>
        /// Hide this component.
        /// </summary>
        [Meta]
        [Description("Hide this component.")]
        public virtual void Hide()
        {
            this.Call("hide");
        }

        /// <summary>
        /// Removes a CSS class from the component's underlying element.
        /// </summary>
        [Meta]
        [Description("Removes a CSS class from the component's underlying element.")]
        public virtual void RemoveClass(string cls)
        {
            this.Call("removeClass", cls);
        }

        /// <summary>
        /// Removes a CSS class from the component's container.
        /// </summary>
        [Meta]
        [Description("Removes a CSS class from the component's container.")]
        public virtual void RemoveContainerClass(string cls)
        {
            this.Call("container.removeClass", cls);
        }


        /// <summary>
        /// Show this component.
        /// </summary>
        [Meta]
        [Description("Show this component.")]
        public virtual void Show()
        {
            this.Call("show");
        }


        /*  Protected Client Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Convenience function for setting disabled/enabled by boolean.
        /// </summary>
        [Description("Convenience function for setting disabled/enabled by boolean.")]
        protected internal virtual void SetDisabled(bool disabled)
        {
            this.Call("setDisabled", disabled);
        }

        /// <summary>
        /// Convenience function for setting selectable by boolean.
        /// </summary>
        [Description("Convenience function for setting selectable by boolean.")]
        protected internal virtual void SetSelectable(bool selectable)
        {
            this.Call("setSelectable", selectable);
        }

        /// <summary>
        /// Convenience function to hide or show this component by boolean.
        /// </summary>
        [Description("Convenience function to hide or show this component by boolean.")]
        protected internal virtual void SetVisible(bool visible)
        {
            this.Call("setVisible", visible);
        }

        /// <summary>
        /// Convenience function for setting the FieldLabel of a Component during an DirectEvent or DirectMethod request.
        /// </summary>
        [Description("Convenience function for setting the FieldLabel of a Component during an DirectEvent or DirectMethod request.")]
        protected internal virtual void SetFieldLabel(string text)
        {
            this.Call("setFieldLabel", text);
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.
        /// </summary>
        [Meta]
        [Description("Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.")]
        public virtual void Mon(Element el, string eventName, JFunction fn)
        {
            this.Call("mon", new JRawValue(el.Descriptor), eventName, fn);
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.
        /// </summary>
        [Meta]
        [Description("Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.")]
        public virtual void Mon(Observable el, string eventName, JFunction fn)
        {
            this.Call("mon", new JRawValue(el.ClientID), eventName, fn);
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.
        /// </summary>
        [Meta]
        [Description("Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.")]
        public virtual void Mon(Element el, string eventName, JFunction fn, string scope)
        {
            this.Call("mon", new JRawValue(el.Descriptor), eventName, fn, new JRawValue(scope));
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.
        /// </summary>
        [Meta]
        [Description("Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.")]
        public virtual void Mon(Observable el, string eventName, JFunction fn, string scope)
        {
            this.Call("mon", new JRawValue(el.ClientID), eventName, fn, new JRawValue(scope));
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.
        /// </summary>
        [Meta]
        [Description("Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.")]
        public virtual void Mon(Element el, string eventName, string fn, string scope, HandlerConfig options)
        {
            this.Call("mon", new JRawValue(el.Descriptor), eventName, fn, new JRawValue(scope), new JRawValue(options.ToJsonString()));
        }

        /// <summary>
        /// Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.
        /// </summary>
        [Meta]
        [Description("Adds listeners to any Observable object (or Elements) which are automatically removed when this Component is destroyed.")]
        public virtual void Mon(Observable el, string eventName, string fn, string scope, HandlerConfig options)
        {
            this.Call("mon", new JRawValue(el.ClientID), eventName, fn, new JRawValue(scope), new JRawValue(options.ToJsonString()));
        }

        /// <summary>
        /// Removes listeners that were added by the Mon method. 
        /// </summary>
        [Meta]
        [Description("Removes listeners that were added by the Mon method.")]
        public virtual void Mun(Element el, string eventName, string fn)
        {
            this.Call("mun", new JRawValue(el.Descriptor), eventName, new JRawValue(fn));
        }

        /// <summary>
        /// Removes listeners that were added by the Mon method. 
        /// </summary>
        [Meta]
        [Description("Removes listeners that were added by the Mon method.")]
        public virtual void Mun(Observable el, string eventName, string fn)
        {
            this.Call("mun", new JRawValue(el.ClientID), eventName, new JRawValue(fn));
        }

        /// <summary>
        /// Removes listeners that were added by the Mon method. 
        /// </summary>
        [Meta]
        [Description("Removes listeners that were added by the Mon method.")]
        public virtual void Mun(Element el, string eventName, string fn, string scope)
        {
            this.Call("mun", new JRawValue(el.Descriptor), eventName, new JRawValue(fn), new JRawValue(scope));
        }

        /// <summary>
        /// Removes listeners that were added by the Mon method. 
        /// </summary>
        [Meta]
        [Description("Removes listeners that were added by the Mon method.")]
        public virtual void Mun(Observable el, string eventName, string fn, string scope)
        {
            this.Call("mun", new JRawValue(el.ClientID), eventName, new JRawValue(fn), new JRawValue(scope));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelCls"></param>
        [Description("")]
        public void AddLabelCls(string labelCls)
        {
            this.Call("label.addClass", labelCls);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="labelCls"></param>
        [Description("")]
        public void RemoveLabelCls(string labelCls)
        {
            this.Call("label.removeClass", labelCls);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anchor"></param>
        protected virtual void SetAnchor(string anchor)
        {
            this.Call("setAnchor", anchor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="doLayout"></param>
        public virtual void SetAnchor(string anchor, bool doLayout)
        {
            this.Call("setAnchor", anchor, doLayout);
        }

        /// <summary>
        /// Update the html of the Body, optionally searching for and processing scripts.
        /// </summary>
        /// <param name="html">The html string to update the body with. Replaces all content of the body.</param>
        [Meta]
        [Description("Update the html of the Body, optionally searching for and processing scripts.")]
        public virtual void Update(string html)
        {
            string template = "if({0}.rendered){{{0}.update({1});}}else{{{0}.html={1};}}";
            this.AddScript(template, this.ClientID, JSON.Serialize(html));
        }

        /// <summary>
        /// Update the html of the Body, optionally searching for and processing scripts.
        /// </summary>
        [Meta]
        [Description("Update the html of the Body, optionally searching for and processing scripts.")]
        public virtual void Update(string html, bool loadScripts)
        {
            this.Call("update", html, loadScripts);
        }

        /// <summary>
        /// Update the html of the Body, optionally searching for and processing scripts.
        /// </summary>
        [Meta]
        [Description("Update the html of the Body, optionally searching for and processing scripts.")]
        public virtual void Update(string html, bool loadScripts, string callback)
        {
            this.Update(html, loadScripts, new JFunction(callback));
        }

        /// <summary>
        /// Update the html of the Body, optionally searching for and processing scripts.
        /// </summary>
        [Meta]
        [Description("Update the html of the Body, optionally searching for and processing scripts.")]
        public virtual void Update(string html, bool loadScripts, JFunction callback)
        {
            this.Call("update", html, loadScripts, callback);
        }

        /// <summary>
        /// Updates the content of the Panel body with the supplied string ('html') value.
        /// </summary>
        [Description("Updates the content of the Panel body with the supplied string ('html') value.")]
        protected virtual void SetHtml(string html)
        {
            this.Update(html);
        }
    }
}