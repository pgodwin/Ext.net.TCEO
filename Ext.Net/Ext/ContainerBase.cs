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
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Base Class for any visual Component that uses a box content Container.
    /// </summary>
    [Meta]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [Description("Base Class for any visual Component that uses a box content Container.")]
    public abstract partial class ContainerBase : BoxComponentBase, ILayout, IItems
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool HasLayout()
        {
            return this.LayoutControl != null;
        }

        /// <summary>
        /// A string component id or the numeric index of the component that should be initially activated within the content Container's layout on render.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetActiveItem")]
        [Category("5. Container")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A string component id of the component that should be initially activated within the content Container's layout on render.")]
        public virtual string ActiveItem
        {
            get
            {
                return (string)this.ViewState["ActiveItem"] ?? "";
            }
            set
            {
                this.ViewState["ActiveItem"] = value;
            }
        }

        /// <summary>
        /// A string component id or the numeric index of the component that should be initially activated within the content Container's layout on render.
        /// </summary>
        [Meta]
        [ConfigOption("activeItem")]
        [DirectEventUpdate(MethodName = "SetActiveIndex")]
        [Category("5. Container")]
        [DefaultValue(-1)]
        [NotifyParentProperty(true)]
        [Description("A numeric index of the component that should be initially activated within the content Container's layout on render.")]
        public virtual int ActiveIndex
        {
            get
            {
                object obj = this.ViewState["ActiveIndex"];
                return (obj == null) ? -1 : (int)obj;
            }
            set
            {
                this.ViewState["ActiveIndex"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void SetActiveIndex(int index)
        {
            this.AddScript("if({0}.getLayout().setActiveItem){{{0}.getLayout().setActiveItem({1});}}", this.ClientID, index);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void SetActiveItem(string item)
        {
            this.AddScript("if({0}.getLayout().setActiveItem){{{0}.getLayout().setActiveItem(\"{1}\");}}", this.ClientID, item);
        }

        /// <summary>
        /// If true the content Container will automatically destroy any contained component that is removed from it, else destruction must be handled manually (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Container")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]    
        [Description("If true the content Container will automatically destroy any contained component that is removed from it, else destruction must be handled manually (defaults to true).")]
        public virtual bool AutoDestroy
        {
            get
            {
                object obj = this.ViewState["AutoDestroy"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AutoDestroy"] = value;
            }
        }

        /// <summary>
        /// If true .doLayout() is called after render. Default is false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Container")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If true .doLayout() is called after render. Default is false.")]
        public virtual bool AutoDoLayout
        {
            get
            {
                object obj = this.ViewState["AutoDoLayout"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoDoLayout"] = value;
            }
        }

        /// <summary>
        /// When set to true (50 milliseconds) or a number of milliseconds, the layout assigned for this container will buffer the frequency it calculates and does a re-layout of components. This is useful for heavy containers or containers with a large quantity of sub-components for which frequent layout calls would be expensive. Defaults to 50.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Container")]
        [DefaultValue(50)]
        [NotifyParentProperty(true)]
        [Description("When set to true (50 milliseconds) or a number of milliseconds, the layout assigned for this container will buffer the frequency it calculates and does a re-layout of components. This is useful for heavy containers or containers with a large quantity of sub-components for which frequent layout calls would be expensive. Defaults to 50.")]
        public virtual int BufferResize
        {
            get
            {
                object obj = this.ViewState["BufferResize"];
                return (obj == null) ? 50 : (int)obj;
            }
            set
            {
                this.ViewState["BufferResize"] = value;
            }
        }

        /// <summary>
        /// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').
        /// </summary>
        [Meta]
        [Category("5. Container")]
        [DefaultValue("Panel")]
        [TypeConverter(typeof(DefaultTypeConverter))]
        [NotifyParentProperty(true)]    
        [Description("The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').")]
        public virtual string DefaultType
        {
            get
            {
                return (string)this.ViewState["DefaultType"] ?? "Panel";
            }
            set
            {
                this.ViewState["DefaultType"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("defaultType")]
        [DefaultValue("panel")]
        [Description("")]
        protected virtual string DefaultTypeProxy
        {
            get
            {
                return DefaultTypeConverter.GetXType(this.DefaultType);
            }
        }

        private ParameterCollection defaults;

        /// <summary>
        /// A config object that will be applied to all components added to this content Container either via the items config or via the add or insert methods. The defaults config can contain any number of name/value property pairs to be added to each items, and should be valid for the types of items being added to the content Container. For example, to automatically apply padding to the body of each of a set of contained Ext.Panel items, you could pass: defaults: {bodyStyle:'padding:15px'}.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [Category("5. Container")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A config object that will be applied to all components added to this content Container either via the items config or via the add or insert methods. The defaults config can contain any number of name/value property pairs to be added to each items, and should be valid for the types of items being added to the content Container. For example, to automatically apply padding to the body of each of a set of contained Ext.Panel items, you could pass: defaults: {bodyStyle:'padding:15px'}.")]
        public virtual ParameterCollection Defaults
        {
            get
            {
                if (this.defaults == null)
                {
                    this.defaults = new ParameterCollection(true);
                    this.defaults.Owner = this;
                    this.defaults.AfterItemAdd += Defaults_AfterItemAdd;
                }

                return this.defaults;
            }
        }

        void Defaults_AfterItemAdd(Parameter item)
        {
            item.CamelName = true;
        }

        /// <summary>
        /// True to hide the borders of each contained component, false to defer to the component's existing border settings (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Container")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]    
        [Description("True to hide the borders of each contained component, false to defer to the component's existing border settings (defaults to false).")]
        public virtual bool HideBorders
        {
            get
            {
                object obj = this.ViewState["HideBorders"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideBorders"] = value;
            }
        }

        /// <summary>
        /// True to automatically monitor window resize events to handle anything that is sensitive to the current size of the viewport. This value is typically managed by the chosen layout and should not need to be set manually.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Container")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]    
        [Description("True to automatically monitor window resize events to handle anything that is sensitive to the current size of the viewport. This value is typically managed by the chosen layout and should not need to be set manually.")]
        public virtual bool MonitorResize
        {
            get
            {
                object obj = this.ViewState["MonitorResize"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["MonitorResize"] = value;
            }
        }

        /// <summary>
        /// If true the container will force a layout initially even if hidden or collapsed. This option is useful for forcing forms to render in collapsed or hidden containers. (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Container")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If true the container will force a layout initially even if hidden or collapsed. This option is useful for forcing forms to render in collapsed or hidden containers. (defaults to false).")]
        public virtual bool ForceLayout
        {
            get
            {
                object obj = this.ViewState["ForceLayout"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ForceLayout"] = value;
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Adds a component to this container. Fires the beforeadd event before adding, then fires the add event after the component has been added. If the container is already rendered when add is called, you may need to call doLayout to refresh the view. This is required so that you can add multiple child components if needed while only refreshing the layout once.
        /// </summary>
        [Meta]
        [Description("Adds a component to this container. Fires the beforeadd event before adding, then fires the add event after the component has been added. If the container is already rendered when add is called, you may need to call doLayout to refresh the view. This is required so that you can add multiple child components if needed while only refreshing the layout once.")]
        public virtual void Add(Component component)
        {
            if (this is TabPanelBase && component is Container)
            {
                ((TabPanelBase)this).Items.Add((Container)component);
            }
            else
            {
                this.Items.Add(component);
            }
        }

        /// <summary>
        /// Adds a range of components to this container.
        /// </summary>
        [Meta]
        [Description("Adds a range of components to this container.")]
        public virtual void Add(IEnumerable<Component> collection)
        {
            foreach (Component cmp in collection)
            {
                this.Add(cmp);
            }
        }

        /// <summary>
        /// Cascades down the component/container heirarchy from this component (called first), calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the cascade is stopped on that branch.
        /// </summary>
        [Meta]
        [Description("Cascades down the component/container heirarchy from this component (called first), calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the cascade is stopped on that branch.")]
        public virtual void Cascade(string function)
        {
            this.Call("cascade", new JRawValue(function));
        }

        /// <summary>
        /// Cascades down the component/container heirarchy from this component (called first), calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the cascade is stopped on that branch.
        /// </summary>
        [Meta]
        [Description("Cascades down the component/container heirarchy from this component (called first), calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the cascade is stopped on that branch.")]
        public virtual void Cascade(string function, string scope)
        {
            this.Call("cascade", new JRawValue(function), new JRawValue(scope));
        }

        /// <summary>
        /// Cascades down the component/container heirarchy from this component (called first), calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the cascade is stopped on that branch.
        /// </summary>
        [Meta]
        [Description("Cascades down the component/container heirarchy from this component (called first), calling the specified function with each component. The scope (this) of function call will be the scope provided or the current component. The arguments to the function will be the args provided or the current component. If the function returns false at any point, the cascade is stopped on that branch.")]
        public virtual void Cascade(string function, string scope, Dictionary<string, object> args)
        {
            this.Call("cascade", new JRawValue(function), new JRawValue(scope), args);
        }

        /// <summary>
        /// Force this container's layout to be recalculated. A call to this function is required after adding a new component to an already rendered container, or possibly after changing sizing/position properties of child components.
        /// </summary>
        [Meta]
        [Description("Force this container's layout to be recalculated. A call to this function is required after adding a new component to an already rendered container, or possibly after changing sizing/position properties of child components.")]
        public virtual void DoLayout()
        {
            this.Call("doLayout");
        }

        /// <summary>
        /// Force this container's layout to be recalculated. A call to this function is required after adding a new component to an already rendered container, or possibly after changing sizing/position properties of child components.
        /// </summary>
        [Meta]
        [Description("Force this container's layout to be recalculated. A call to this function is required after adding a new component to an already rendered container, or possibly after changing sizing/position properties of child components.")]
        public virtual void DoLayout(bool shallow)
        {
            this.Call("doLayout", shallow);
        }

		/// <summary>
		/// 
		/// </summary>
        [Meta]
        [Description("Force this container's layout to be recalculated. A call to this function is required after adding a new component to an already rendered container, or possibly after changing sizing/position properties of child components.")]
        public virtual void DoLayout(bool shallow, bool force)
        {
            this.Call("doLayout", shallow, force);
        }

        /// <summary>
        /// Inserts a Component into this Container at a specified index. Fires the beforeadd event before inserting, then fires the add event after the Component has been inserted.
        /// </summary>
        /// <param name="index">The index at which the Component will be inserted into the Container's items collection</param>
        /// <param name="component">The child Component to insert.</param>
        [Meta]
        [Description("Inserts a Component into this Container at a specified index. Fires the beforeadd event before inserting, then fires the add event after the Component has been inserted.")]
        public virtual void Insert(int index, Component component)
        {
            this.Call("insert", index, new JRawValue(component.ClientID));
        }

        /// <summary>
        /// Inserts a Component into this Container at a specified index. Fires the beforeadd event before inserting, then fires the add event after the Component has been inserted.
        /// </summary>
        /// <param name="index">The index at which the Component will be inserted into the Container's items collection</param>
        /// <param name="id">The id of the child Component to insert.</param>
        [Meta]
        [Description("Inserts a Component into this Container at a specified index. Fires the beforeadd event before inserting, then fires the add event after the Component has been inserted.")]
        public virtual void Insert(int index, string id)
        {
            this.Call("insert", index, new JRawValue(id));
        }

        /// <summary>
        /// Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
        /// </summary>
        [Meta]
        [Description("Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.")]
        public virtual void Remove(Component component)
        {
            this.Call("remove", new JRawValue(component.ClientID));
        }

        /// <summary>
        /// Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
        /// </summary>
        [Meta]
        [Description("Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.")]
        public virtual void Remove(Component component, bool destroy)
        {
            this.Call("remove", new JRawValue(component.ClientID), destroy);
        }

        /// <summary>
        /// Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
        /// </summary>
        [Meta]
        [Description("Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.")]
        public virtual void Remove(string id)
        {
            this.Call("remove", new JRawValue(id));
        }

        /// <summary>
        /// Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.
        /// </summary>
        [Meta]
        [Description("Removes a component from this container. Fires the beforeremove event before removing, then fires the remove event after the component has been removed.")]
        public virtual void Remove(string id, bool destroy)
        {
            this.Call("remove", new JRawValue(id), destroy);
        }

        /// <summary>
        /// Removes all components from this container.
        /// </summary>
        [Meta]
        [Description("Removes all components from this container.")]
        public virtual void RemoveAll()
        {
            this.Call("removeAll");
        }

        /// <summary>
        /// Removes all components from this container.
        /// </summary>
        /// <param name="autoDestroy">(optional) True to automatically invoke the removed Component's Ext.Component.destroy function. Defaults to the value of this Container's autoDestroy config.</param>
        [Meta]
        [Description("Removes all components from this container.")]
        public virtual void RemoveAll(bool autoDestroy)
        {
            this.Call("removeAll", autoDestroy);
        }
        /*  Items
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool UseDefaultLayout
        {
            get
            {
                return true;
            }
        }

        private ItemsCollection<Component> items;

        /// <summary>
        /// Items Collection
        /// </summary>
        [Meta]
        [DeferredRender]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Items Collection")]
        public virtual ItemsCollection<Component> Items
        {
            get
            {
                this.InitItems();

                return this.items;
            }
        }

        IList IItems.ItemsList
        {
            get
            {
                return this.Items;
            }
        }

        /// <summary>
        /// Items Collection
        /// </summary>
        [ConfigOption("items", typeof(ItemCollectionJsonConverter))]
        [DeferredRender]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Items Collection")]
        protected internal virtual ItemsCollection<Component> ItemsProxy
        {
            get
            {
                Layout layoutControl = this.LayoutControl;

                if (layoutControl != null)
                {
                    return layoutControl.Items;
                }

                this.InitItems();

                return this.items;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected internal void InitItems()
        {
            if (this.items == null)
            {
                this.items = new ItemsCollection<Component>();
                this.items.BeforeItemAdd += this.BeforeItemAdd;
                this.items.AfterItemAdd += this.AfterItemAdd;
                this.items.AfterItemRemove += this.AfterItemRemove;
                this.items.SingleItemMode = this.SingleItemMode;
            }
        }

        private bool layoutDetected = false;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected internal virtual void DetectLayoutFromConfig()
        {
            if (!this.layoutDetected && this.LayoutConfig.Count > 0)
            {
                this.Layout = this.LayoutConfig.Primary.GetType().Name.LeftOf("LayoutConfig");
                this.layoutDetected = true;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
            this.InitItems();

            this.DetectLayoutFromConfig();

            if (this.Items.Count > 0 && this.Layout.IsEmpty() && this.LayoutControl == null && this.UseDefaultLayout)
            {
                this.Layout = "auto";
            }

            if (this.Items.Count > 0)
            {
                return;
            }

            if (this.Layout.IsNotEmpty() && this.Items.Count == 0 && this is IContent && this.LayoutControl == null)
            {
                ControlCollection contentControls = ((IContent)this).ContentControls;

                if (contentControls.Count == 0)
                {
                    return;
                }

                List<Component> components = new List<Component>();

                foreach (Control control in contentControls)
                {
                    Component cmp = control as Component;

                    if (cmp != null)
                    {
                        // need interim collection to avoid Items' AfterItemAdd firing while we go over the body's controls
                        components.Add(cmp);
                        cmp.ID = cmp.ID; 
                    }
                }

                if (components.Count == 0)
                {
                    return;
                }

                contentControls.Clear();

                foreach (Component cmp in components)
                {
                    this.Add(cmp);
                }
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void BeforeItemAdd(Component item) { }

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

                this.DetectLayoutFromConfig();

                if (this.GetLayoutFromContent() != null || (this.Layout.IsNotEmpty() && this.ContentControls.Count == 0))
                {
                    return true;
                }

                return false;
            }
        }
        
        /*  ILayout
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// The layout type to be used in this container.
        /// </summary>
        [Meta]
        [Category("5. Container")]
        [DefaultValue("")]
        [TypeConverter(typeof(LayoutConverter))]
        [Description("The layout type to be used in this container.")]
        public virtual string Layout
        {
            get
            {
                return (string)this.ViewState["Layout"] ?? "";
            }
            set
            {
                this.ViewState["Layout"] = value;
            }
        }

        private LayoutConfigCollection layoutConfig;

        /// <summary>
        /// This is a config object containing properties specific to the chosen layout (to be used in conjunction with the layout config value)
        /// </summary>
        [Meta]
        [ConfigOption("layoutConfig>Primary")]
        [Category("5. Container")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("This is a config object containing properties specific to the chosen layout (to be used in conjunction with the layout config value)")]
        public virtual LayoutConfigCollection LayoutConfig
        {
            get
            {
                if (this.layoutConfig == null)
                {
                    this.layoutConfig = new LayoutConfigCollection();
                }

                return this.layoutConfig;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("layout")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string LayoutProxy
        {
            get
            {
                this.DetectLayoutFromConfig();

                if (this.Layout.IsNotEmpty() && this.LayoutControl == null)
                {
                    string layout = this.Layout.ToLowerInvariant();
                    string temp = layout.EndsWith("layout") ? layout.LeftOfRightmostOf("layout") : layout;

                    //Dictionary<string, string> layouts = new Dictionary<string, string>();

                    //layouts.Add("anchor", "net{0}");
                    //layouts.Add("container", "auto");
                    //layouts.Add("center", "ux.{0}");

                    //if (layouts.ContainsKey(temp))
                    //{
                    //    return string.Format(layouts[temp], temp);
                    //}

                    switch(temp)
                    {
                        case "column":
                            return "net".ConcatWith(temp);
                        case "container":
                            return "auto";
                        case "form":
                            return this is FormPanelBase ? "" : "form";
                        case "center":
                        case "row":
                            return "ux.".ConcatWith(temp);
                        default:
                            return temp;
                    }
                }

                return "";
            }
        }

        private string LayoutWarning
        {
            get
            {
                return "Only one layout is possible in the container (ID = '" + this.ID + "')";
            }
        }

        protected virtual Layout GetLayoutFromItems()
        {
            Layout layout = null;
            if (this.Items.Count > 0)
            {
                foreach (Component item in this.Items)
                {
                    if (item is Layout)
                    {
                        if (layout != null)
                        {
                            throw new Exception(this.LayoutWarning);
                        }

                        layout = (Layout)item;
                    }
                }
            }

            return layout;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected internal virtual Layout GetLayoutFromContent()
        {
            Layout layout = null;

            if (this is IContent)
            {
                foreach (Control control in ((IContent)this).ContentControls)
                {
                    if (control is Layout)
                    {
                        if (layout != null)
                        {
                            throw new Exception(this.LayoutWarning);
                        }

                        layout = (Layout)control;
                    }
                    else if (control is ContentPlaceHolder || control is UserControl)
                    {
                        if (layout != null)
                        {
                            throw new Exception(this.LayoutWarning);
                        }

                        layout = this.FindLayout(control);
                    }
                }
            }

            return layout;
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.UnrollObject)]
        [DeferredRender]
        [Category("5. Container")]
        [DefaultValue(null)]
        [Browsable(false)]
        [Description("")]
        public virtual Layout LayoutControl
        {
            get
            {
                Layout layout = this.GetLayoutFromItems();

                if (layout != null)
                {
                    return layout;
                }

                return this.GetLayoutFromContent();
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual Layout FindLayout(Control control)
        {
            Layout layout = null;
            foreach (Control c in control.Controls)
            {
                if (c is Layout)
                {
                    if (layout != null)
                    {
                        throw new Exception(this.LayoutWarning);
                    }
                    
                    layout = (Layout)c;
                }
            }

            if (layout != null)
            {
                return layout;
            }

            foreach (Control c in control.Controls)
            {
                if (c is ContentPlaceHolder || c is UserControl)
                {
                    layout = this.FindLayout(c);

                    if (layout != null)
                    {
                        return layout;
                    }
                }
            }

            return null;
        }

        internal virtual Store ContentStore
        {
            get
            {
                if (this is IContent)
                {
                    foreach (Control control in ((IContent)this).ContentControls)
                    {
                        if (control is Store)
                        {
                            return (Store)control;
                        }
                        else if (control is ContentPlaceHolder || control is UserControl)
                        {
                            foreach (Control c in control.Controls)
                            {
                                if (c is Store)
                                {
                                    return (Store)c;
                                }
                            }
                        }
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode && this.Page != null && !RequestManager.IsAjaxRequest && this.LayoutControl != null)
            {
                Store store = this.ContentStore;

                if (store != null)
                {
                    store.ForcePreRender();
                }
            }

            base.Render(writer);
        }

        private string contentScript;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ContentToScript(bool selfRendering)
        {
            if (this.AlreadyRendered)
            {
                return this.contentScript;
            }

            this.contentScript = ContentScriptBuilder.Create(this).Build(selfRendering);

            return this.contentScript;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ContentToScript()
        {
            return this.ContentToScript(this.Page == null);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void UpdateContent(bool selfRendering)
        {
            if (!this.AlreadyRendered)
            {
                this.ResourceManager.AddScript(this.ContentToScript(selfRendering));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void UpdateContent()
        {
            this.UpdateContent(this.Page == null);
        }
    }
}