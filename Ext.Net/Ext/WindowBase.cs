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

using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class WindowBase : PanelBase
    {
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
                return "Ext.Window";
            }
        }


        /*  Overrides
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "window";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override string ContainerStyle
        {
            get
            {
                return "display:none;";
            }
        }


        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ReadOnly(true)]
        [Browsable(false)]
        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AutoWidth
        {
            get 
            { 
                return base.AutoWidth;
            }
            set 
            { 
                base.AutoWidth = value; 
            }
        }

        /// <summary>
        /// Id or element from which the window should animate while opening (defaults to null with no animation).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetAnimateTarget")]
        [Category("7. Window")]
        [DefaultValue("")]
        [TypeConverter(typeof(ControlConverter))]
        [Description("Id or element from which the window should animate while opening (defaults to null with no animation).")]
        public virtual string AnimateTarget
        {
            get
            {
                return (string)this.ViewState["AnimateTarget"] ?? "";
            }
            set
            {
                this.ViewState["AnimateTarget"] = value;
            }
        }

        /// <summary>
        /// True to display the 'close' tool button and allow the user to close the window, false to hide the button and disallow closing the window (default to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Window")]
        [DefaultValue(true)]
        [Description("True to display the 'close' tool button and allow the user to close the window, false to hide the button and disallow closing the window (default to true).")]
        public override bool Closable
        {
            get
            {
                object obj = this.ViewState["Closable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Closable"] = value;
            }
        }

        /// <summary>
        /// The action to take when the close button is clicked. The default action is 'close' which will actually remove the window from the DOM and destroy it. The other valid option is 'hide' which will simply hide the window by setting visibility to hidden and applying negative offsets, keeping the window available to be redisplayed via the show method.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("7. Window")]
        [DefaultValue(CloseAction.Hide)]
        [Description("The action to take when the close button is clicked. The default action is 'close' which will actually remove the window from the DOM and destroy it. The other valid option is 'hide' which will simply hide the window by setting visibility to hidden and applying negative offsets, keeping the window available to be redisplayed via the show method.")]
        public override CloseAction CloseAction
        {
            get
            {
                object obj = this.ViewState["CloseAction"];
                return (obj == null) ? CloseAction.Hide : (CloseAction)obj;
            }
            set
            {
                this.ViewState["CloseAction"] = value;
            }
        }

        /// <summary>
        /// True to constrain the window to the viewport, false to allow it to fall outside of the viewport (defaults to false). Optionally the header only can be constrained using ConstrainHeader.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Window")]
        [DefaultValue(false)]
        [Description("True to constrain the window to the viewport, false to allow it to fall outside of the viewport (defaults to false). Optionally the header only can be constrained using ConstrainHeader.")]
        public virtual bool Constrain
        {
            get
            {
                object obj = this.ViewState["Constrain"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Constrain"] = value;
            }
        }

        /// <summary>
        /// True to constrain the window header to the viewport, allowing the window body to fall outside of the viewport, false to allow the header to fall outside the viewport (defaults to false). Optionally the entire window can be constrained using constrain.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Window")]
        [DefaultValue(false)]
        [Description("True to constrain the window header to the viewport, allowing the window body to fall outside of the viewport, false to allow the header to fall outside the viewport (defaults to false). Optionally the entire window can be constrained using constrain.")]
        public virtual bool ConstrainHeader
        {
            get
            {
                object obj = this.ViewState["ConstrainHeader"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ConstrainHeader"] = value;
            }
        }

        /// <summary>
        /// The id of a button to focus when this window received the focus.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Window")]
        [DefaultValue("")]
        [Description("The id of a button to focus when this window received the focus.")]
        public virtual string DefaultButton
        {
            get
            {
                return (string)this.ViewState["DefaultButton"] ?? "";
            }
            set
            {
                this.ViewState["DefaultButton"] = value;
            }
        }

        /// <summary>
        /// The default render to Element (Body or Form). Using when AutoRender="false"
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("7. Window")]
        [DefaultValue(DefaultRenderTo.Body)]
        [Description("The default render to Element (Body or Form). Using when AutoRender='false'")]
        public virtual DefaultRenderTo DefaultRenderTo
        {
            get
            {
                object obj = this.ViewState["DefaultRenderTo"];
                return (obj == null) ? DefaultRenderTo.Body : (DefaultRenderTo)obj;
            }
            set
            {
                this.ViewState["DefaultRenderTo"] = value;
            }
        }

        /// <summary>
        /// True to allow the window to be dragged by the header bar, false to disable dragging (defaults to true). Note that by default the window will be centered in the viewport, so if dragging is disabled the window may need to be positioned programmatically after render (e.g., myWindow.setPosition(100, 100);).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Window")]
        [DefaultValue(true)]
        [Description("True to allow the window to be dragged by the header bar, false to disable dragging (defaults to true). Note that by default the window will be centered in the viewport, so if dragging is disabled the window may need to be positioned programmatically after render (e.g., myWindow.setPosition(100, 100);).")]
        public override bool Draggable
        {
            get
            {
                
                object obj = this.ViewState["Draggable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Draggable"] = value;
            }
        }

        /// <summary>
        /// True to always expand the window when it is displayed, false to keep it in its current state (which may be collapsed) when displayed (defaults to true).
        /// </summary>
        [Meta]
        [Category("7. Window")]
        [DefaultValue(true)]
        [Description("True to always expand the window when it is displayed, false to keep it in its current state (which may be collapsed) when displayed (defaults to true).")]
        public virtual bool ExpandOnShow
        {
            get
            {
                object obj = this.ViewState["ExpandOnShow"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ExpandOnShow"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("expandOnShow")]
        [DefaultValue(true)]
		[Description("")]
        protected bool ExpandOnShowProxy
        {
            get
            {
                return (this.Collapsed) ? false : this.ExpandOnShow;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("hidden")]
        [DefaultValue(true)]
		[Description("")]
        protected virtual bool HiddenProxy
        {
            get
            {
                return this.Hidden;
            }
        }

        //[ClientConfig]
        //[Category("7. Window")]
        //[DefaultValue(null)]
        //[Description("A reference to the WindowGroup that should manage this window (defaults to Ext.WindowMgr).")]
        //public virtual ManagerGroup Manager
        //{
        //    get
        //    {
        //        object obj = this.ViewState["Manager"];
        //        return (obj == null) ? null : (ManagerGroup)obj;
        //    }
        //    set
        //    {
        //        this.ViewState["Manager"] = value;
        //    }
        //}

        /// <summary>
        /// True to display the 'maximize' tool button and allow the user to maximize the window, false to hide the button and disallow maximizing the window (defaults to false). Note that when a window is maximized, the tool button will automatically change to a 'restore' button with the appropriate behavior already built-in that will restore the window to its previous size.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Window")]
        [DefaultValue(false)]
        [Description("True to display the 'maximize' tool button and allow the user to maximize the window, false to hide the button and disallow maximizing the window (defaults to false). Note that when a window is maximized, the tool button will automatically change to a 'restore' button with the appropriate behavior already built-in that will restore the window to its previous size.")]
        public virtual bool Maximizable
        {
            get
            {
                object obj = this.ViewState["Maximizable"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Maximizable"] = value;
            }
        }

        /// <summary>
        /// True to initially display the window in a maximized state. (Defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Window")]
        [DefaultValue(false)]
        [Description("True to initially display the window in a maximized state. (Defaults to false).")]
        public virtual bool Maximized
        {
            get
            {
                object obj = this.ViewState["Maximized"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Maximized"] = value;
            }
        }

        /// <summary>
        /// The height of this component in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetHeight")]
        [Category("7. Window")]
        [DefaultValue(typeof(Unit), "")]
        [Description("The height of this component in pixels (defaults to auto).")]
        public override Unit Height
        {
            get
            {
                Unit height = this.UnitPixelTypeCheck(ViewState["Height"], Unit.Empty, "Height");
                return (height.Value < this.MinHeight.Value) ? this.MinHeight : height;
            }
            set
            {
                this.ViewState["Height"] = value;
            }
        }

        /// <summary>
        /// The minimum height in pixels allowed for this window (defaults to 100).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Window")]
        [DefaultValue(typeof(Unit), "100")]
        [Description("The minimum height in pixels allowed for this window (defaults to 100).")]
        public override Unit MinHeight
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["MinHeight"], Unit.Pixel(100), "MinHeight");
            }
            set
            {
                this.ViewState["MinHeight"] = value;
            }
        }

        /// <summary>
        /// The width of this component in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetWidth")]
        [Category("7. Window")]
        [DefaultValue(typeof(Unit), "")]
        [Description("The width of this component in pixels (defaults to auto).")]
        public override Unit Width
        {
            get
            {
                Unit width = this.UnitPixelTypeCheck(ViewState["Width"], Unit.Empty, "Width");
                return (width.Value < this.MinWidth.Value) ? this.MinWidth : width;
            }
            set
            {
                this.ViewState["Width"] = value;
            }
        }

        /// <summary>
        /// The minimum width in pixels allowed for this window (defaults to 200). Only applies when resizable = true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Window")]
        [DefaultValue(typeof(Unit), "200")]
        [Description("The minimum width in pixels allowed for this window (defaults to 200). Only applies when resizable = true.")]
        public override Unit MinWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["MinWidth"], Unit.Pixel(200), "MinWidth");
            }
            set
            {
                this.ViewState["MinWidth"] = value;
            }
        }

        /// <summary>
        /// True to display the 'minimize' tool button and allow the user to minimize the window, false to hide the button and disallow minimizing the window (defaults to false). Note that this button provides no implementation -- the behavior of minimizing a window is implementation-specific, so the minimize event must be handled and a custom minimize behavior implemented for this option to be useful.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Window")]
        [DefaultValue(false)]
        [Description("True to display the 'minimize' tool button and allow the user to minimize the window, false to hide the button and disallow minimizing the window (defaults to false). Note that this button provides no implementation -- the behavior of minimizing a window is implementation-specific, so the minimize event must be handled and a custom minimize behavior implemented for this option to be useful.")]
        public virtual bool Minimizable
        {
            get
            {
                object obj = this.ViewState["Minimizable"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Minimizable"] = value;
            }
        }

        /// <summary>
        /// True to make the window modal and mask everything behind it when displayed, false to display it without restricting access to other UI elements (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "ToggleModal")]
        [Category("7. Window")]
        [DefaultValue(false)]
        [Description("True to make the window modal and mask everything behind it when displayed, false to display it without restricting access to other UI elements (defaults to false).")]
        public virtual bool Modal
        {
            get
            {
                object obj = this.ViewState["Modal"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Modal"] = value;
            }
        }

        /// <summary>
        /// Allows override of the built-in processing for the escape key. Default action is to close the Window (performing whatever action is specified in closeAction. To prevent the Window closing when the escape key is pressed, specify this as Ext.emptyFn (See Ext.emptyFn).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("7. Window")]
        [DefaultValue("Ext.emptyFn")]
        [Description("Allows override of the built-in processing for the escape key. Default action is to close the Window (performing whatever action is specified in closeAction. To prevent the Window closing when the escape key is pressed, specify this as Ext.emptyFn (See Ext.emptyFn).")]
        public virtual string OnEsc
        {
            get
            {
                object obj = this.ViewState["OnEsc"];
                return (obj == null) ? "Ext.emptyFn" : (string)obj;
            }
            set
            {
                this.ViewState["OnEsc"] = value;
            }
        }

        /// <summary>
        /// True to render the window body with a transparent background so that it will blend into the framing elements, false to add a lighter background color to visually highlight the body element and separate it more distinctly from the surrounding frame (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Window")]
        [DefaultValue(false)]
        [Description("True to render the window body with a transparent background so that it will blend into the framing elements, false to add a lighter background color to visually highlight the body element and separate it more distinctly from the surrounding frame (defaults to false).")]
        public virtual bool Plain
        {
            get
            {
                object obj = this.ViewState["Plain"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Plain"] = value;
            }
        }

        /// <summary>
        /// True to allow user resizing at each edge and corner of the window, false to disable resizing (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Window")]
        [DefaultValue(true)]
        [Description("True to allow user resizing at each edge and corner of the window, false to disable resizing (defaults to true).")]
        public virtual bool Resizable
        {
            get
            {
                object obj = this.ViewState["Resizable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Resizable"] = value;
            }
        }

        /// <summary>
        /// A valid Ext.Resizable handles config string (defaults to 'all'). Only applies when resizable = true.
        /// 
        /// Value   Description
        /// ------  -------------------
        /// 'n'     north
        /// 's'     south
        /// 'e'     east
        /// 'w'     west
        /// 'nw'    northwest
        /// 'sw'    southwest
        /// 'se'    southeast
        /// 'ne'    northeast
        /// 'all'   all
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. Window")]
        [DefaultValue("all")]
        [Description("A valid Ext.Resizable handles config string (defaults to 'all'). Only applies when resizable = true.")]
        public virtual string ResizeHandles
        {
            get
            {
                object obj = this.ViewState["ResizeHandles"];
                return (obj == null) ? "all" : (string)obj;
            }
            set
            {
                this.ViewState["ResizeHandles"] = value;
            }
        }

        /// <summary>
        /// Centers this window in the viewport when the Page loads.
        /// </summary>
        [Meta]
        [Category("7. Window")]
        [DefaultValue(true)]
        [Description("Centers this window in the viewport when the window is initialized.")]
        public virtual bool InitCenter
        {
            get
            {
                object obj = this.ViewState["InitCenter"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["InitCenter"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("initCenter")]
        [DefaultValue(true)]
		[Description("")]
        protected virtual bool InitCenterProxy
        {
            get
            {
                if (this.X != 0 && this.Y != 0)
                {
                    return false;
                }

                return this.InitCenter;
            }
        }


        /*  Overrides
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("renderTo")]
        [DefaultValue("")]
        protected internal override string RenderToProxy
        {
            get
            {
                if (!this.AutoRender)
                {
                    return "";
                }
                
                if (this.RenderTo.IsEmpty())
                {
                    return this.IsInForm ? "={Ext.get(\"".ConcatWith(this.ParentForm.ClientID, "\")}") : "={Ext.getBody()}";
                } 
                
                return base.RenderToProxy;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool RemoveContainer
        {
            get
            {
                return true;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Aligns the window to the specified element
        /// </summary>
        [Meta]
        [Description("Aligns the window to the specified element")]
        public virtual void AlignTo(string element, string position)
        {
            this.Call("alignTo", new JRawValue(element), position);
        }

        /// <summary>
        /// Aligns the window to the specified element
        /// </summary>
        [Meta]
        [Description("Aligns the window to the specified element")]
        public virtual void AlignTo(string element, string position, int offsetX, int offsetY)
        {
            this.Call("alignTo", new JRawValue(element), position, new int[] { offsetX, offsetY });
        }

        /// <summary>
        /// Anchors this window to another element and realigns it when the window is resized or scrolled.
        /// </summary>
        [Meta]
        [Description("Anchors this window to another element and realigns it when the window is resized or scrolled.")]
        public virtual void AnchorTo(string element, string position)
        {
            this.Call("anchorTo", new JRawValue(element), position);
        }

        /// <summary>
        /// Anchors this window to another element and realigns it when the window is resized or scrolled.
        /// </summary>
        [Meta]
        [Description("Anchors this window to another element and realigns it when the window is resized or scrolled.")]
        public virtual void AnchorTo(string element, string position, int offsetX, int offsetY)
        {
            this.Call("anchorTo", new JRawValue(element), position, new int[] { offsetX, offsetY });
        }

        /// <summary>
        /// Anchors this window to another element and realigns it when the window is resized or scrolled.
        /// </summary>
        [Meta]
        [Description("Anchors this window to another element and realigns it when the window is resized or scrolled.")]
        public virtual void AnchorTo(string element, string position, int offsetX, int offsetY, bool monitorScroll)
        {
            this.Call("anchorTo", new JRawValue(element), position, new int[] { offsetX, offsetY }, monitorScroll);
        }

        /// <summary>
        /// Centers this window in the viewport
        /// </summary>
        [Meta]
        [Description("Centers this window in the viewport")]
        public virtual void Center()
        {
            this.Call("center");
        }

        /// <summary>
        /// Closes the window, removes it from the DOM and destroys the window object. The beforeclose event is fired before the close happens and will cancel the close action if it returns false.
        /// </summary>
        [Meta]
        [Description("Closes the window, removes it from the DOM and destroys the window object. The beforeclose event is fired before the close happens and will cancel the close action if it returns false.")]
        public virtual void Close()
        {
            this.Call("close");
        }

        /// <summary>
        /// Focuses the window. If a defaultButton is set, it will receive focus, otherwise the window itself will receive focus.
        /// </summary>
        [Meta]
        [Description("Focuses the window. If a defaultButton is set, it will receive focus, otherwise the window itself will receive focus.")]
        public override void Focus()
        {
            base.Focus();
        }

        /// <summary>
        /// Hides the window, setting it to invisible and applying negative offsets.
        /// </summary>
        [Meta]
        [Description("Hides the window, setting it to invisible and applying negative offsets.")]
        public override void Hide()
        {
            base.Hide();
        }

        /// <summary>
        /// Hides the window, setting it to invisible and applying negative offsets.
        /// </summary>
        [Meta]
        [Description("Hides the window, setting it to invisible and applying negative offsets.")]
        public virtual void Hide(Control animateTarget)
        {
            this.Call("hide", animateTarget.ClientID);
        }

        /// <summary>
        /// Hides the window, setting it to invisible and applying negative offsets.
        /// </summary>
        [Meta]
        [Description("Hides the window, setting it to invisible and applying negative offsets.")]
        public virtual void Hide(Control animateTarget, string callback)
        {
            this.Call("hide", animateTarget.ClientID, new JRawValue(callback));
        }

        /// <summary>
        /// Hides the window, setting it to invisible and applying negative offsets.
        /// </summary>
        [Meta]
        [Description("Hides the window, setting it to invisible and applying negative offsets.")]
        public virtual void Hide(Control animateTarget, string callback, string scope)
        {
            this.Call("hide", animateTarget.ClientID, new JRawValue(callback), new JRawValue(scope));
        }

        /// <summary>
        /// Hides the window, setting it to invisible and applying negative offsets.
        /// </summary>
        [Meta]
        [Description("Hides the window, setting it to invisible and applying negative offsets.")]
        public virtual void Hide(string animateTarget)
        {
            this.Call("hide", animateTarget);
        }

        /// <summary>
        /// Hides the window, setting it to invisible and applying negative offsets.
        /// </summary>
        [Meta]
        [Description("Hides the window, setting it to invisible and applying negative offsets.")]
        public virtual void Hide(string animateTarget, string callback)
        {
            this.Call("hide", animateTarget, new JRawValue(callback));
        }

        /// <summary>
        /// Hides the window, setting it to invisible and applying negative offsets.
        /// </summary>
        [Meta]
        [Description("Hides the window, setting it to invisible and applying negative offsets.")]
        public virtual void Hide(string animateTarget, string callback, string scope)
        {
            this.Call("hide", animateTarget, new JRawValue(callback), new JRawValue(scope));
        }

        /// <summary>
        /// Fits the window within its current container and automatically replaces the 'maximize' tool button with the 'restore' tool button.
        /// </summary>
        [Meta]
        [Description("Fits the window within its current container and automatically replaces the 'maximize' tool button with the 'restore' tool button.")]
        public virtual void Maximize()
        {
            this.Call("maximize");
        }

        /// <summary>
        /// Placeholder method for minimizing the window. By default, this method simply fires the minimize event since the behavior of minimizing a window is application-specific. To implement custom minimize behavior, either the minimize event can be handled or this method can be overridden.
        /// </summary>
        [Meta]
        [Description("Placeholder method for minimizing the window. By default, this method simply fires the minimize event since the behavior of minimizing a window is application-specific. To implement custom minimize behavior, either the minimize event can be handled or this method can be overridden.")]
        public virtual void Minimize()
        {
            this.Call("minimize");
        }

        /// <summary>
        /// Restores a maximized window back to its original size and position prior to being maximized and also replaces the 'restore' tool button with the 'maximize' tool button.
        /// </summary>
        [Meta]
        [Description("Restores a maximized window back to its original size and position prior to being maximized and also replaces the 'restore' tool button with the 'maximize' tool button.")]
        public virtual void Restore()
        {
            this.Call("restore");
        }

        /// <summary>
        /// Makes this the active window by showing its shadow, or deactivates it by hiding its shadow. This method also fires the activate or deactivate event depending on which action occurred.
        /// </summary>
        /// <param name="active">if set to <c>true</c> [active].</param>
        [Meta]
        [Description("Makes this the active window by showing its shadow, or deactivates it by hiding its shadow. This method also fires the activate or deactivate event depending on which action occurred.")]
        public virtual void SetActive(bool active)
        {
            this.Call("setActive", active);
        }

        /// <summary>
        /// Sets the target element from which the window should animate while opening.
        /// </summary>
        [Meta]
        [Description("Sets the target element from which the window should animate while opening.")]
        public virtual void SetAnimateTarget(string element)
        {
            this.Call("setAnimateTarget", new JRawValue(element));
        }

        /// <summary>
        /// Sets the target element from which the window should animate while opening.
        /// </summary>
        [Meta]
        [Description("Sets the target element from which the window should animate while opening.")]
        public virtual void SetAnimateTarget(Control element)
        {
            this.Call("setAnimateTarget", new JRawValue(element.ClientID+".getEl()"));
        }

        /// <summary>
        /// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
        /// </summary>
        [Meta]
        [Description("Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.")]
        public override void Show()
        {
            base.Show();
        }

        /// <summary>
        /// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
        /// </summary>
        [Meta]
        [Description("Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.")]
        public virtual void Show(Control animateTarget)
        {
            this.Call("show", new JRawValue(animateTarget.ClientID + ".getEl()"));
        }

        /// <summary>
        /// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
        /// </summary>
        [Meta]
        [Description("Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.")]
        public virtual void Show(Control animateTarget, string callback)
        {
            this.Call("show", new JRawValue(animateTarget.ClientID + ".getEl()"), new JRawValue(callback));
        }

        /// <summary>
        /// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
        /// </summary>
        [Meta]
        [Description("Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.")]
        public virtual void Show(Control animateTarget, string callback, string scope)
        {
            this.Call("show", new JRawValue(animateTarget.ClientID + ".getEl()"), new JRawValue(callback), new JRawValue(scope));
        }

        /// <summary>
        /// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
        /// </summary>
        [Meta]
        [Description("Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.")]
        public virtual void Show(string animateTarget)
        {
            this.Call("show", animateTarget);
        }

        /// <summary>
        /// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
        /// </summary>
        [Meta]
        [Description("Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.")]
        public virtual void Show(string animateTarget, string callback)
        {
            this.Call("show", animateTarget, new JRawValue(callback));
        }

        /// <summary>
        /// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
        /// </summary>
        [Meta]
        [Description("Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.")]
        public virtual void Show(string animateTarget, string callback, string scope)
        {
            this.Call("show", animateTarget, new JRawValue(callback), new JRawValue(scope));
        }

        /// <summary>
        /// Sends this window to the back of (lower z-index than) any other visible windows
        /// </summary>
        [Meta]
        [Description("Sends this window to the back of (lower z-index than) any other visible windows")]
        public virtual void ToBack()
        {
            this.Call("toBack");
        }

        /// <summary>
        /// Brings this window to the front of any other visible windows
        /// </summary>
        [Meta]
        [Description("Brings this window to the front of any other visible windows")]
        public virtual void ToFront()
        {
            this.Call("toFront");
        }

        /// <summary>
        /// A shortcut method for toggling between maximize and restore based on the current maximized state of the window.
        /// </summary>
        [Meta]
        [Description("A shortcut method for toggling between maximize and restore based on the current maximized state of the window.")]
        public virtual void ToggleMaximize()
        {
            this.Call("toggleMaximize");
        }

        /// <summary>
        /// Shows the Window in a Modal state.
        /// </summary>
        [Meta]
        [Description("Shows the Window in a Modal state.")]
        public virtual void ShowModal()
        {
            this.Call("showModal");
        }

        /// <summary>
        /// Shows the Window in a non-Modal state.
        /// </summary>
        [Meta]
        [Description("Shows the Window in a non-Modal state.")]
        public virtual void HideModal()
        {
            this.Call("hideModal");
        }

        /// <summary>
        /// Toggle the Modal state of the Window. Shows or Hides the body mask. 
        /// </summary>
        [Meta]
        [Description("Toggle the Modal state of the Window. Shows or Hides the body mask.")]
        public virtual void ToggleModal()
        {
            this.Call("toggleModal");
        }

        /// <summary>
        /// Toggle the Modal state of the Window. Shows or Hides the body mask. 
        /// </summary>
        /// <param name="show">true to show the body mask.</param>
        [Meta]
        [Description("Toggle the Modal state of the Window. Shows or Hides the body mask.")]
        public virtual void ToggleModal(bool show)
        {
            if (show)
            {
                this.ShowModal();
            }
            else
            {
                this.HideModal();
            }
        }
    }
}