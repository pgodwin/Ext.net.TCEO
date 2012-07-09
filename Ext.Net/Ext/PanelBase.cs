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
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Base abstract Panel class.
    /// </summary>
    [Meta]
    [Description("Base abstract Panel class.")]
    public abstract partial class PanelBase : ContainerBase, IIcon, IXPostBackDataHandler
    {
        /*  Ctor
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public PanelBase() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        [Description("")]
        public PanelBase(string title)
        {
            this.Title = title;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        [Description("")]
        public PanelBase(string id, string title)
        {
            this.ID = id;
            this.Title = title;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="html"></param>
        [Description("")]
        public PanelBase(string id, string title, string html)
        {
            this.ID = id;
            this.Title = title;
            this.Html = html;
        }


        /*  IScriptable
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.Panel";
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
                return "panel";
            }
        }


        /*  Overrides
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        protected override bool PreventContent
        {
            get
            {
                bool result = base.PreventContent;

                if (result)
                {
                    return true;
                }

                return !this.AutoLoad.IsDefault;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("renderTo")]
        [DefaultValue("")]
        [Description("")]
        protected internal override string RenderToProxy
        {
            get
            {
                return this.ParentComponent is TabPanel ? "" : base.RenderToProxy;
            }
        }


        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        [Description("")]
        protected override void Render(HtmlTextWriter writer)
        {
            if (this.ParentComponent is TabPanel)
            {
                IContent panel = this as IContent;

                if (panel != null && panel.ContentContainer != null && !this.DesignMode)
                {
                    panel.ContentContainer.Attributes.Add("class", "x-hidden");
                }

                this.CssClass = "x-hidden";
            }

            base.Render(writer);
        }

        internal override bool IsDeferredRender
        {
            get
            {
                if (this.Visible && this.ParentComponent is TabPanel)
                {
                    TabPanel tp = (TabPanel)this.ParentComponent;
                    {
                        IContent item = this as IContent;

                        if (item != null)
                        {
                            if (tp.AutoPostBack && tp.DeferredRender && tp.Items[tp.ActiveTabIndex].ID != this.ID)
                            {
                                item.ContentContainer.Visible = false;

                                return true;
                            }
                            else
                            {
                                item.ContentContainer.Visible = true;
                            }
                        }
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual bool IsCollapsible
        {
            get
            {
                if (this.Collapsible)
                {
                    return true;
                }

                if (this.Parent is AccordionLayout)
                {
                    return true;
                }

                if (this.Parent is BorderLayout)
                {
                    return ((BorderLayoutRegion)this.AdditionalConfig).Collapsible;
                }

                return false;
            }
        }

        private static readonly object EventPanelStateChanged = new object();

        /// <summary>
        /// Fires when the panels state is changed.
        /// </summary>
        [Category("Action")]
        [Description("Fires when the panels state is changed.")]
        public event EventHandler StateChanged
        {
            add
            {
                this.Events.AddHandler(EventPanelStateChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventPanelStateChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnStateChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)this.Events[EventPanelStateChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private bool hasLoadPostData = false;

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool HasLoadPostData
        {
            get
            {
                return this.hasLoadPostData;
            }
            set
            {
                this.hasLoadPostData = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        bool IXPostBackDataHandler.HasLoadPostData
        {
            get
            {
                return this.HasLoadPostData;
            }
            set
            {
                this.HasLoadPostData = value;
            }
        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            return this.LoadPostData(postDataKey, postCollection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.ConfigID.ConcatWith("_Collapsed")];

            if (val.IsNotEmpty())
            {
                bool collapsedState;

                if (bool.TryParse(val, out collapsedState))
                {
                    if (this.Collapsed != collapsedState)
                    {
                        try
                        {
                            this.SuspendScripting();
                            this.Collapsed = collapsedState;
                        }
                        finally
                        {
                            this.ResumeScripting();
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            this.RaisePostDataChangedEvent();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void RaisePostDataChangedEvent()
        {
            this.OnStateChanged(EventArgs.Empty);
        }


        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [ReadOnly(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public virtual Element BodyElement
        {
            get
            {
                return new Element(string.Concat(this.ClientID, ".body"));
            }
        }

        //[DirectEventUpdate(MethodName = "SetTitle")] //method which register script
        //[DirectEventUpdate(Script = "{0}.setTitle({1});")] // predefined script
        //[DirectEventUpdate] //autogenerate
        //[DirectEventUpdate(Script = "{0}.animCollapse={1};")]
        /// <summary>
        /// True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.Fx class is available, otherwise false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]    
        [Description("True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.Fx class is available, otherwise false).")]
        public virtual bool AnimCollapse
        {
            get
            {
                object obj = this.ViewState["AnimCollapse"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AnimCollapse"] = value;
            }
        }

        private LoadConfig autoLoad;

        /// <summary>
        /// A valid url spec according to the UpdateOptions Ext.UpdateOptions.update method. If autoLoad is not null, the panel will attempt to load its contents immediately upon render. The URL will become the default URL for this panel's body element, so it may be refreshed at any time.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "LoadContent")]
        [Category("6. Panel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A valid url spec according to the UpdateOptions Ext.UpdateOptions.update method. If autoLoad is not null, the panel will attempt to load its contents immediately upon render. The URL will become the default URL for this panel's body element, so it may be refreshed at any time.")]
        public virtual LoadConfig AutoLoad
        {
            get
            {
                if (this.autoLoad == null)
                {
                    this.autoLoad = new LoadConfig();
                    this.autoLoad.TrackViewState();
                }

                return this.autoLoad;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("autoLoad", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected string AutoLoadProxy
        {
            get
            {
                if (!this.AutoLoad.IsDefault)
                {
                    return new ClientConfig().Serialize(this.AutoLoad);
                }

                return "";
            }
        }

        /// <summary>
        /// The base CSS class to apply to this panel's element (defaults to 'x-panel').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]    
        [Description("The base CSS class to apply to this panel's element (defaults to 'x-panel').")]
        public virtual string BaseCls
        {
            get
            {
                return (string)this.ViewState["BaseCls"] ?? "";
            }
            set
            {
                this.ViewState["BaseCls"] = value;
            }
        }

        private ToolbarCollection bottomBar;

        /// <summary>
        /// The bottom toolbar of the panel. This can be a Ext.Toolbar object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.
        /// </summary>
        [Meta]
        [ConfigOption("bbar", typeof(ItemCollectionJsonConverter))]
        [Category("6. Panel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The bottom toolbar of the panel. This can be a Ext.Toolbar object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.")]
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

        /// <summary>
        /// True to display the 'close' button and allow the user to close the tab, false to hide the button and disallow closing the tab (default to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Panels themselves do not directly support being closed, but some Panel subclasses do (like Ext.Window) or a Panel Class within an Ext.TabPanel. Specify true to enable closing in such situations. Defaults to false.")]
        public virtual bool Closable
        {
            get
            {
                object obj = this.ViewState["Closable"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Closable"] = value;
            }
        }

        /// <summary>
        /// The action to take when the Panel is closed. The default action is 'close' which will actually remove the Panel from the DOM and destroy it. The other valid option is 'hide' which will simply hide the Panel by setting visibility to hidden and applying negative offsets, keeping the Panel available to be redisplayed via the show method.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("6. Panel")]
        [DefaultValue(CloseAction.Close)]
        [Description("The action to take when the Panel is closed. The default action is 'close' which will actually remove the Panel from the DOM and destroy it. The other valid option is 'hide' which will simply hide the Panel by setting visibility to hidden and applying negative offsets, keeping the Panel available to be redisplayed via the show method.")]
        public virtual CloseAction CloseAction
        {
            get
            {
                object obj = this.ViewState["CloseAction"];
                return (obj == null) ? CloseAction.Close : (CloseAction)obj;
            }
            set
            {
                this.ViewState["CloseAction"] = value;
            }
        }

        private ToolbarCollection topBar;

        /// <summary>
        /// The top toolbar of the panel. This can be a Ext.Toolbar object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.
        /// </summary>
        [Meta]
        [ConfigOption("tbar", typeof(ItemCollectionJsonConverter))]
        [Category("6. Panel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The top toolbar of the panel. This can be a Ext.Toolbar object, a toolbar config, or an array of buttons/button configs to be added to the toolbar.")]
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

        private ToolbarCollection footerBar;

        /// <summary>
        /// A Toolbar object, a Toolbar config, or an array of Buttons/Button configs, describing a Toolbar to be rendered into this Panel's footer element.
        /// </summary>
        [Meta]
        [ConfigOption("fbar", typeof(ItemCollectionJsonConverter))]
        [Category("6. Panel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A Toolbar object, a Toolbar config, or an array of Buttons/Button configs, describing a Toolbar to be rendered into this Panel's footer element.")]
        public virtual ToolbarCollection FooterBar
        {
            get
            {
                if (this.footerBar == null)
                {
                    this.footerBar = new ToolbarCollection();
                    this.footerBar.AfterItemAdd += this.AfterItemAdd;
                    this.footerBar.AfterItemRemove += this.AfterItemRemove;
                }

                return this.footerBar;
            }
        }

        /// <summary>
        /// True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.Fx class is available, otherwise false).
        /// </summary>
        [Meta]
        [Category("6. Panel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to animate the transition when the panel is collapsed, false to skip the animation (defaults to true if the Ext.Fx class is available, otherwise false).")]
        public virtual bool FormGroup
        {
            get
            {
                object obj = this.ViewState["FormGroup"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["FormGroup"] = value;
            }
        }

        /// <summary>
        /// True to display an interior border on the body element of the panel, false to hide it (defaults to true). This only applies when border == true. If border == true and bodyBorder == false, the border will display as a 1px wide inset border, giving the entire body element an inset appearance.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]    
        [Description("True to display an interior border on the body element of the panel, false to hide it (defaults to true). This only applies when border == true. If border == true and bodyBorder == false, the border will display as a 1px wide inset border, giving the entire body element an inset appearance.")]
        public virtual bool BodyBorder
        {
            get
            {
                object obj = this.ViewState["BodyBorder"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["BodyBorder"] = value;
            }
        }

        /// <summary>
        /// Additional css class selector to be applied to the body element
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "AddBodyCssClass")]
        [Category("6. Panel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Additional css class selector to be applied to the body element")]
        public virtual string BodyCssClass
        {
            get
            {
                return (string)this.ViewState["BodyCssClass"] ?? "";
            }
            set
            {
                this.ViewState["BodyCssClass"] = value;
            }
        }

        /// <summary>
        /// Custom CSS styles to be applied to the body element in the format expected by Ext.Element.applyStyles (defaults to null).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "ApplyBodyStyles")]
        [Category("6. Panel")]
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

        /// <summary>
        /// True to display the borders of the panel's body element, false to hide them (defaults to true). By default, the border is a 2px wide inset border, but this can be further altered by setting bodyBorder to false.
        /// </summary>
        [Meta]
        [Category("6. Panel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to display the borders of the panel's body element, false to hide them (defaults to true). By default, the border is a 2px wide inset border, but this can be further altered by setting bodyBorder to false.")]
        public virtual bool Border
        {
            get
            {
                object obj = this.ViewState["Border"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Border"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("border")]
        [DefaultValue(true)]
        [Description("")]
        protected virtual bool BorderProxy
        {
            get
            {
                return !this.BodyBorder ? false : this.Border;
            }
        }

        /// <summary>
        /// Valid values are "left", "center" and "right" (defaults to "right").
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("6. Panel")]
        [DefaultValue(Alignment.Right)]
        [NotifyParentProperty(true)]
        [Description("Valid values are \"left\", \"center\" and \"right\" (defaults to \"right\").")]
        public virtual Alignment ButtonAlign
        {
            get
            {
                object obj = this.ViewState["ButtonAlign"];
                return (obj == null) ? Alignment.Right : (Alignment)obj;
            }
            set
            {
                this.ViewState["ButtonAlign"] = value;
            }
        }

        private ItemsCollection<ButtonBase> buttons;

        /// <summary>
        /// A collection of buttons configs used to add buttons to the footer of this panel
        /// </summary>
        [Meta]
        [ConfigOption("buttons", typeof(ItemCollectionJsonConverter))]
        [Category("6. Panel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A collection of buttons configs used to add buttons to the footer of this panel.")]
        public virtual ItemsCollection<ButtonBase> Buttons
        {
            get
            {
                if (this.buttons == null)
                {
                    this.buttons = new ItemsCollection<ButtonBase>();
                    this.buttons.AfterItemAdd += this.Buttons_AfterItemAdd;
                    this.buttons.AfterItemRemove += this.Buttons_AfterItemRemove;
                }

                return this.buttons;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected virtual void Buttons_AfterItemAdd(Component item)
        {
            item.RenderXType = !item.XType.Equals("button");
            this.AfterItemAdd(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected virtual void Buttons_AfterItemRemove(Component item)
        {
            item.RenderXType = true;
            this.AfterItemRemove(item);
        }

        /// <summary>
        /// True to make sure the collapse/expand toggle button always renders first (to the left of) any other tools in the panel's title bar, false to render it last (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to make sure the collapse/expand toggle button always renders first (to the left of) any other tools in the panel's title bar, false to render it last (defaults to true).")]
        public virtual bool CollapseFirst
        {
            get
            {
                object obj = this.ViewState["CollapseFirst"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["CollapseFirst"] = value;
            }
        }

        /// <summary>
        /// True to render the panel collapsed, false to render it expanded (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "CollapsedProxy")]
        [Category("6. Panel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to render the panel collapsed, false to render it expanded (defaults to false).")]
        public virtual bool Collapsed
        {
            get
            {
                object obj = this.ViewState["Collapsed"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Collapsed"] = value;
            }
        }

        /// <summary>
        /// A CSS class to add to the panel's element after it has been collapsed (defaults to 'x-panel-collapsed').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class to add to the panel's element after it has been collapsed (defaults to 'x-panel-collapsed').")]
        public virtual string CollapsedCls
        {
            get
            {
                return (string)this.ViewState["CollapsedCls"] ?? "";
            }
            set
            {
                this.ViewState["CollapsedCls"] = value;
            }
        }

        /// <summary>
        /// True to make the panel collapsible and have the expand/collapse toggle button automatically rendered into the header tool button area, false to keep the panel statically sized with no button (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to make the panel collapsible and have the expand/collapse toggle button automatically rendered into the header tool button area, false to keep the panel statically sized with no button (defaults to false).")]
        public virtual bool Collapsible
        {
            get
            {
                object obj = this.ViewState["Collapsible"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Collapsible"] = value;
            }
        }

        /// <summary>
        /// True to enable dragging of this Panel (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to enable dragging of this Panel (defaults to false).")]
        public virtual bool Draggable
        {
            get
            {
                object obj = this.ViewState["Draggable"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Draggable"] = value;
            }
        }

        private DragSource draggableConfig;

        /// <summary>
        /// Drag config object.
        /// </summary>
        [Category("6. Panel")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Drag config object.")]
        public virtual DragSource DraggableConfig
        {
            get
            {
                if (this.draggableConfig == null && !this.DesignMode)
                {
                    this.draggableConfig = new DragSource();
                }

                return this.draggableConfig;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("draggable", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected internal virtual string DraggableConfigProxy
        {
            get
            {
                if (this.DraggableConfig == null)
                {
                    return "";
                }

                string cfg = new ClientConfig().Serialize(this.DraggableConfig, true);
                return cfg == "{}" ? "" : cfg;
            }
        }

        /// <summary>
        /// A comma-delimited list of panel elements to initialize when the panel is rendered.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A comma-delimited list of panel elements to initialize when the panel is rendered.")]
        public virtual string Elements
        {
            get
            {
                return (string)this.ViewState["Elements"] ?? "";
            }
            set
            {
                this.ViewState["Elements"] = value;
            }
        }

        /// <summary>
        /// True to float the panel (absolute position it with automatic shimming and shadow), false to display it inline where it is rendered (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to float the panel (absolute position it with automatic shimming and shadow), false to display it inline where it is rendered (defaults to false).")]
        public virtual bool Floating
        {
            get
            {
                object obj = this.ViewState["Floating"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Floating"] = value;
            }
        }

        /// <summary>
        /// True to create the footer element explicitly, false to skip creating it. By default, when footer is not specified, if one or more buttons have been added to the panel the footer will be created automatically, otherwise it will not.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to create the footer element explicitly, false to skip creating it. By default, when footer is not specified, if one or more buttons have been added to the panel the footer will be created automatically, otherwise it will not.")]
        public virtual bool Footer
        {
            get
            {
                object obj = this.ViewState["Footer"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Footer"] = value;
            }
        }

        /// <summary>
        /// True to render the panel with custom rounded borders, false to render with plain 1px square borders (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to render the panel with custom rounded borders, false to render with plain 1px square borders (defaults to false).")]
        public virtual bool Frame
        {
            get
            {
                object obj = this.ViewState["Frame"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Frame"] = value;
            }
        }

        /// <summary>
        /// True to create the header element explicitly, false to skip creating it. By default, when header is not specified, if a title is set the header will be created automatically, otherwise it will not. If a title is set but header is explicitly set to false, the header will not be rendered.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to create the header element explicitly, false to skip creating it. By default, when header is not specified, if a title is set the header will be created automatically, otherwise it will not. If a title is set but header is explicitly set to false, the header will not be rendered.")]
        public virtual bool Header
        {
            get
            {
                object obj = this.ViewState["Header"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Header"] = value;
            }
        }

        /// <summary>
        /// True to display the panel title in the header, false to hide it (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to display the panel title in the header, false to hide it (defaults to true).")]
        public virtual bool HeaderAsText
        {
            get
            {
                object obj = this.ViewState["HeaderAsText"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["HeaderAsText"] = value;
            }
        }

        /// <summary>
        /// True to hide the expand/collapse toggle button when collapsible = true, false to display it (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to hide the expand/collapse toggle button when collapsible = true, false to display it (defaults to false).")]
        public virtual bool HideCollapseTool
        {
            get
            {
                object obj = this.ViewState["HideCollapseTool"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideCollapseTool"] = value;
            }
        }        

        /// <summary>
        /// The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [Category("6. Panel")]
        [DefaultValue(Icon.None)]
        [DirectEventUpdate(MethodName = "SetIconClass")]
        [Description("The icon to use in the Title bar. See also, IconCls to set an icon with a custom Css class.")]
        public virtual Icon Icon
        {
            get
            {
                object obj = this.ViewState["Icon"];
                return (obj == null) ? Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["Icon"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("iconCls")]
        [DefaultValue("")]
        [Description("")]
        protected internal virtual string IconClsProxy
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return ResourceManager.GetIconClassName(this.Icon);
                }

                return this.IconCls;
            }
        }

        /// <summary>
        /// A CSS class that will provide a background image to be used as the panel header icon (defaults to '').
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetIconClass")]
        [Category("6. Panel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A CSS class that will provide a background image to be used as the panel header icon (defaults to '').")]
        public virtual string IconCls
        {
            get
            {
                return (string)this.ViewState["IconCls"] ?? "";
            }
            set
            {
                this.ViewState["IconCls"] = value;
            }
        }

        private KeyBindingCollection keyMap;

        /// <summary>
        /// A KeyMap config object (in the format expected by Ext.KeyMap.addBinding used to assign custom key handling to this panel (defaults to null).
        /// </summary>
        [Meta]
        [ConfigOption("keys", JsonMode.Array)]
        [Category("6. Panel")]
        [ViewStateMember]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("A KeyMap config object (in the format expected by Ext.KeyMap.addBinding used to assign custom key handling to this panel (defaults to null).")]
        public virtual KeyBindingCollection KeyMap
        {
            get
            {
                if (this.keyMap == null)
                {
                    this.keyMap = new KeyBindingCollection();
                    this.keyMap.AfterItemAdd += this.AfterKeyBindingAdd;
                }

                return this.keyMap;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyBinding"></param>
        [Description("")]
        protected virtual void AfterKeyBindingAdd(KeyBinding keyBinding)
        {
            keyBinding.Owner = this;
            keyBinding.Listeners.Event.Owner = this;
        }

        /// <summary>
        /// True to mask the panel when it is disabled, false to not mask it (defaults to true). Either way, the panel will always tell its contained elements to disable themselves when it is disabled, but masking the panel can provide an additional visual cue that the panel is disabled.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to mask the panel when it is disabled, false to not mask it (defaults to true). Either way, the panel will always tell its contained elements to disable themselves when it is disabled, but masking the panel can provide an additional visual cue that the panel is disabled.")]
        public virtual bool MaskDisabled
        {
            get
            {
                object obj = this.ViewState["MaskDisabled"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["MaskDisabled"] = value;
            }
        }

        /// <summary>
        /// Minimum width in pixels of all buttons in this panel (defaults to 75).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(typeof(Unit), "75")]
        [NotifyParentProperty(true)]
        [Description("Minimum width in pixels of all buttons in this panel (defaults to 75).")]
        public virtual Unit MinButtonWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["MinButtonWidth"], Unit.Pixel(75), "MinButtonWidth");
            }
            set
            {
                this.ViewState["MinButtonWidth"] = value;
            }
        }

        /// <summary>
        /// ShadowMode to display a shadow behind the panel. Note that this option only applies when floating = true.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(ShadowJsonConverter))]
        [Category("6. Panel")]
        [DefaultValue(ShadowMode.Sides)]
        [NotifyParentProperty(true)]
        [Description("ShadowMode to display a shadow behind the panel. Note that this option only applies when floating = true.")]
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
        /// The number of pixels to offset the shadow if displayed (defaults to 4). Note that this option only applies when floating = true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(4)]
        [NotifyParentProperty(true)]
        [Description("The number of pixels to offset the shadow if displayed (defaults to 4). Note that this option only applies when floating = true.")]
        public virtual int ShadowOffset
        {
            get
            {
                object obj = this.ViewState["ShadowOffset"];
                return (obj == null) ? 4 : (int)obj;
            }
            set
            {
                this.ViewState["ShadowOffset"] = value;
            }
        }

        /// <summary>
        /// False to disable the iframe shim in browsers which need one (defaults to true). Note that this option only applies when floating = true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to disable the iframe shim in browsers which need one (defaults to true). Note that this option only applies when floating = true.")]
        public virtual bool Shim
        {
            get
            {
                object obj = this.ViewState["Shim"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Shim"] = value;
            }
        }

        /// <summary>
        /// A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. See also, PaddingSummary.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. See also, PaddingSummary.")]
        public virtual int Padding
        {
            get
            {
                object obj = this.ViewState["Padding"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["Padding"] = value;
            }
        }

        /// <summary>
        /// A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. See also, Padding.
        /// </summary>
        [Meta]
        [ConfigOption("padding")]
        [Category("6. Panel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A shortcut for setting a padding style on the body element. The value can either be a number to be applied to all sides, or a normal css string describing padding. See also, Padding.")]
        public virtual string PaddingSummary
        {
            get
            {
                return (string)this.ViewState["PaddingSummary"] ?? "";
            }
            set
            {
                this.ViewState["PaddingSummary"] = value;
            }
        }

        private LoadMask loadMask;

        /// <summary>
        /// An Ext.LoadMask to mask the Panel while loading (defaults to false).
        /// </summary>
        [Meta]
        [Category("6. Panel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An Ext.LoadMask to mask the Panel while loading (defaults to false).")]
        public virtual LoadMask LoadMask
        {
            get
            {
                if (this.loadMask == null)
                {
                    this.loadMask = new LoadMask();
                    this.loadMask.TrackViewState();
                }

                return this.loadMask;
            }
        }

        /// <summary>
        /// The title text to display in the panel header (defaults to ''). When a title is specified the header element will automatically be created and displayed unless header is explicitly set to false. If you don't want to specify a title at config time, but you may want one later, you must either specify a non-empty title (a blank space ' ' will do) or header:true so that the content Container element will get created.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetTitle")]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue("")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("The title text to display in the panel header (defaults to ''). When a title is specified the header element will automatically be created and displayed unless header is explicitly set to false. If you don't want to specify a title at config time, but you may want one later, you must either specify a non-empty title (a blank space ' ' will do) or header:true so that the content Container element will get created.")]
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
        /// True to allow expanding and collapsing the panel (when collapsible = true) by clicking anywhere in the header bar, false to allow it only by clicking to tool button (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to allow expanding and collapsing the panel (when collapsible = true) by clicking anywhere in the header bar, false to allow it only by clicking to tool button (defaults to false).")]
        public virtual bool TitleCollapse
        {
            get
            {
                object obj = this.ViewState["TitleCollapse"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["TitleCollapse"] = value;
            }
        }

        private ToolsCollection tools;

        /// <summary>
        /// An array of tool button configs to be added to the header tool area. When rendered, each tool is stored as an Element referenced by a public property called tools.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.AlwaysArray)]
        [Category("6. Panel")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("An array of tool button configs to be added to the header tool area. When rendered, each tool is stored as an Element referenced by a public property called tools.")]
        public virtual ToolsCollection Tools
        {
            get
            {
                if (this.tools == null)
                {
                    this.tools = new ToolsCollection();
                    this.tools.Owner = this;
                    this.tools.AfterItemAdd += Tools_AfterItemAdd;
                }

                return this.tools;
            }
        }

        void Tools_AfterItemAdd(Tool item)
        {
            item.Owner = this;
        }

        /// <summary>
        /// Overrides the baseCls setting to baseCls = 'x-plain' which renders the panel unstyled except for required attributes for Ext layouts to function (e.g. overflow:hidden).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Overrides the baseCls setting to baseCls = 'x-plain' which renders the panel unstyled except for required attributes for Ext layouts to function (e.g. overflow:hidden).")]
        public virtual bool Unstyled
        {
            get
            {
                object obj = this.ViewState["Unstyled"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Unstyled"] = value;
            }
        }

        /// <summary>
        /// Defaults to false. When set to true, an extra css class 'x-panel-normal' will be added to the panel's element, effectively applying css styles suggested by the W3C (see http://www.w3.org/TR/CSS21/sample.html) to the Panel's body element (not the header, footer, etc.).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Defaults to false. When set to true, an extra css class 'x-panel-normal' will be added to the panel's element, effectively applying css styles suggested by the W3C (see http://www.w3.org/TR/CSS21/sample.html) to the Panel's body element (not the header, footer, etc.).")]
        public virtual bool PreventBodyReset
        {
            get
            {
                object obj = this.ViewState["PreventBodyReset"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["PreventBodyReset"] = value;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Description("")]
        protected virtual void CallBody(string name, params object[] args)
        {
            this.CallTemplate("{0}.body.{1}({2});", name, args);
        }

        /// <summary>
        /// Apply css styles for body
        /// </summary>
        /// <param name="style">style string</param>
        [Meta]
        [Description("Apply css styles for body")]
        public virtual void ApplyBodyStyles(string style)
        {
            this.CallBody("applyStyles", style);
        }

        /// <summary>
        /// Add new css class for body
        /// </summary>
        /// <param name="cssClass">css class name</param>
        [Meta]
        [Description("Add new css class for body")]
        public virtual void AddBodyCssClass(string cssClass)
        {
            this.CallBody("addClass", cssClass);
        }

        /// <summary>
        /// Remove body's css class
        /// </summary>
        /// <param name="cssClass">css class name</param>
        [Meta]
        [Description("Remove body's css class")]
        public virtual void RemoveBodyCssClass(string cssClass)
        {
            this.CallBody("removeClass", cssClass);
        }

        /// <summary>
        /// Collapses the panel body so that it becomes hidden. Fires the beforecollapse event which will cancel the collapse action if it returns false.
        /// </summary>
        [Meta]
        [Description("Collapses the panel body so that it becomes hidden. Fires the beforecollapse event which will cancel the collapse action if it returns false.")]
        public virtual void Collapse()
        {
            this.SuspendScripting();
            this.Collapsed = true;
            this.ResumeScripting();

            this.Call("collapse");
        }

        /// <summary>
        /// Collapses the panel body so that it becomes hidden. Fires the beforecollapse event which will cancel the collapse action if it returns false.
        /// </summary>
        /// <param name="animate">if set to <c>true</c> [animate].</param>
        [Meta]
        [Description("Collapses the panel body so that it becomes hidden. Fires the beforecollapse event which will cancel the collapse action if it returns false.")]
        public virtual void Collapse(bool animate)
        {
            this.SuspendScripting();
            this.Collapsed = true;
            this.ResumeScripting();

            this.Call("collapse", animate);
        }

        /// <summary>
        /// Expands the panel body so that it becomes visible. Fires the beforeexpand event which will cancel the expand action if it returns false.
        /// </summary>
        [Meta]
        [Description("Expands the panel body so that it becomes visible. Fires the beforeexpand event which will cancel the expand action if it returns false.")]
        public virtual void Expand()
        {
            this.SuspendScripting();
            this.Collapsed = false;
            this.ResumeScripting();

            this.Call("expand");
        }

        /// <summary>
        /// Expands the panel body so that it becomes visible. Fires the beforeexpand event which will cancel the expand action if it returns false.
        /// </summary>
        [Meta]
        [Description("Expands the panel body so that it becomes visible. Fires the beforeexpand event which will cancel the expand action if it returns false.")]
        public virtual void Expand(bool animate)
        {
            this.SuspendScripting();
            this.Collapsed = false;
            this.ResumeScripting();

            this.Call("expand", animate);
        }

        /// <summary>
        /// Clear loaded content
        /// </summary>
        [Meta]
        [Description("Clear loaded content.")]
        public virtual void ClearContent()
        {
            this.Call("clearContent");
        }

        /// <summary>
        /// Loads this content panel immediately with content returned from an XHR call.
        /// </summary>
        [Meta]
        [Description("Loads this content panel immediately with content returned from an XHR call.")]
        public virtual void LoadContent()
        {
            this.Call("load", new JRawValue(this.AutoLoad.Serialize()));
        }

        /// <summary>
        /// Loads this content panel immediately with content returned from an XHR call.
        /// </summary>
        [Meta]
        [Description("Loads this content panel immediately with content returned from an XHR call.")]
        public virtual void LoadContent(string url)
        {
            this.Call("load", new JRawValue(new LoadConfig(url).Serialize()));
        }

        /// <summary>
        /// Loads this content panel immediately with content returned from an XHR call.
        /// </summary>
        [Meta]
        [Description("Loads this content panel immediately with content returned from an XHR call.")]
        public virtual void LoadContent(string url, bool noCache)
        {
            this.Call("load", new JRawValue(new LoadConfig(url, LoadMode.Merge, noCache).Serialize()));
        }

        /// <summary>
        /// Loads this content panel immediately with content returned from an XHR call.
        /// </summary>
        [Meta]
        [Description("Loads this content panel immediately with content returned from an XHR call.")]
        public virtual void LoadContent(LoadConfig config)
        {
            this.Call("load", new JRawValue(config.Serialize()));
        }

        /// <summary>
        /// Loads this content panel immediately with content returned from an XHR call.
        /// </summary>
        [Meta]
        [Description("Loads this content panel immediately with content returned from an XHR call.")]
        public virtual void LoadContent(JFunction fn)
        {
            this.Call("load", fn);
        }

        /// <summary>
        /// Reloads the content panel based on the current LoadConfig.
        /// </summary>
        [Meta]
        [Description("Reloads the content panel based on the current LoadConfig.")]
        public virtual void Reload()
        {
            this.Call("reload");
        }
        
        /// <summary>
        /// Sets the CSS class that provides the icon image for this panel. This method will replace any existing icon class if one has already been set.
        /// </summary>
        [Description("Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.")]
        protected virtual void SetIconClass(string cls)
        {
            this.Call("setIconClass", cls);
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        [Description("Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.")]
        protected virtual void SetIconClass(Icon icon)
        {
            if (this.Icon != Icon.None)
            {
                this.SetIconClass(ResourceManager.GetIconClassName(icon)); 
            }
            else
            {
                this.SetIconClass(""); 
            }
        }

        /// <summary>
        /// Sets the title text for the panel and optionally the icon class.
        /// </summary>
        [Meta]
        [Description("Sets the title text for the panel and optionally the icon class.")]
        public virtual void SetTitle(string title)
        {
            this.Call("setTitle", title);
        }

        /// <summary>
        /// Sets the title text for the panel and optionally the icon class.
        /// </summary>
        [Meta]
        [Description("Sets the title text for the panel and optionally the icon class.")]
        public virtual void SetTitle(string title, string cls)
        {
            this.Call("setTitle", title, cls);
        }

        /// <summary>
        /// Shortcut for performing an expand or collapse based on the current state of the panel.
        /// </summary>
        [Meta]
        [Description("Shortcut for performing an expand or collapse based on the current state of the panel.")]
        public virtual void ToggleCollapse()
        {
            this.ToggleCollapse(true);
        }

        /// <summary>
        /// Shortcut for performing an expand or collapse based on the current state of the panel.
        /// </summary>
        [Meta]
        [Description("Shortcut for performing an expand or collapse based on the current state of the panel.")]
        public virtual void ToggleCollapse(bool animate)
        {
            this.Call("toggleCollapse", animate);
        }

        /// <summary>
        /// DirectEvent proxy method for .Collapsed property.
        /// </summary>
        [Description("DirectEvent proxy method for .Collapsed property.")]
        protected virtual void CollapsedProxy(bool collapsed)
        {
            this.Call(collapsed ? "collapse" : "expand");
        }

        public virtual List<Icon> Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>(1);
                icons.Add(this.Icon);

                return icons;
            }
        }
    }
}