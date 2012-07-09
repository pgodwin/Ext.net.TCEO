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
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    public abstract partial class WindowBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TWindowBase, TBuilder> : PanelBase.Builder<TWindowBase, TBuilder>
            where TWindowBase : WindowBase
            where TBuilder : Builder<TWindowBase, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TWindowBase component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AutoWidth(bool autoWidth)
            {
                this.ToComponent().AutoWidth = autoWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Id or element from which the window should animate while opening (defaults to null with no animation).
			/// </summary>
            public virtual TBuilder AnimateTarget(string animateTarget)
            {
                this.ToComponent().AnimateTarget = animateTarget;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display the 'close' tool button and allow the user to close the window, false to hide the button and disallow closing the window (default to true).
			/// </summary>
            public virtual TBuilder Closable(bool closable)
            {
                this.ToComponent().Closable = closable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The action to take when the close button is clicked. The default action is 'close' which will actually remove the window from the DOM and destroy it. The other valid option is 'hide' which will simply hide the window by setting visibility to hidden and applying negative offsets, keeping the window available to be redisplayed via the show method.
			/// </summary>
            public virtual TBuilder CloseAction(CloseAction closeAction)
            {
                this.ToComponent().CloseAction = closeAction;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to constrain the window to the viewport, false to allow it to fall outside of the viewport (defaults to false). Optionally the header only can be constrained using ConstrainHeader.
			/// </summary>
            public virtual TBuilder Constrain(bool constrain)
            {
                this.ToComponent().Constrain = constrain;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to constrain the window header to the viewport, allowing the window body to fall outside of the viewport, false to allow the header to fall outside the viewport (defaults to false). Optionally the entire window can be constrained using constrain.
			/// </summary>
            public virtual TBuilder ConstrainHeader(bool constrainHeader)
            {
                this.ToComponent().ConstrainHeader = constrainHeader;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The id of a button to focus when this window received the focus.
			/// </summary>
            public virtual TBuilder DefaultButton(string defaultButton)
            {
                this.ToComponent().DefaultButton = defaultButton;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The default render to Element (Body or Form). Using when AutoRender='false'
			/// </summary>
            public virtual TBuilder DefaultRenderTo(DefaultRenderTo defaultRenderTo)
            {
                this.ToComponent().DefaultRenderTo = defaultRenderTo;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to allow the window to be dragged by the header bar, false to disable dragging (defaults to true). Note that by default the window will be centered in the viewport, so if dragging is disabled the window may need to be positioned programmatically after render (e.g., myWindow.setPosition(100, 100);).
			/// </summary>
            public virtual TBuilder Draggable(bool draggable)
            {
                this.ToComponent().Draggable = draggable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to always expand the window when it is displayed, false to keep it in its current state (which may be collapsed) when displayed (defaults to true).
			/// </summary>
            public virtual TBuilder ExpandOnShow(bool expandOnShow)
            {
                this.ToComponent().ExpandOnShow = expandOnShow;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display the 'maximize' tool button and allow the user to maximize the window, false to hide the button and disallow maximizing the window (defaults to false). Note that when a window is maximized, the tool button will automatically change to a 'restore' button with the appropriate behavior already built-in that will restore the window to its previous size.
			/// </summary>
            public virtual TBuilder Maximizable(bool maximizable)
            {
                this.ToComponent().Maximizable = maximizable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to initially display the window in a maximized state. (Defaults to false).
			/// </summary>
            public virtual TBuilder Maximized(bool maximized)
            {
                this.ToComponent().Maximized = maximized;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The height of this component in pixels (defaults to auto).
			/// </summary>
            public virtual TBuilder Height(Unit height)
            {
                this.ToComponent().Height = height;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum height in pixels allowed for this window (defaults to 100).
			/// </summary>
            public virtual TBuilder MinHeight(Unit minHeight)
            {
                this.ToComponent().MinHeight = minHeight;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The width of this component in pixels (defaults to auto).
			/// </summary>
            public virtual TBuilder Width(Unit width)
            {
                this.ToComponent().Width = width;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The minimum width in pixels allowed for this window (defaults to 200). Only applies when resizable = true.
			/// </summary>
            public virtual TBuilder MinWidth(Unit minWidth)
            {
                this.ToComponent().MinWidth = minWidth;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to display the 'minimize' tool button and allow the user to minimize the window, false to hide the button and disallow minimizing the window (defaults to false). Note that this button provides no implementation -- the behavior of minimizing a window is implementation-specific, so the minimize event must be handled and a custom minimize behavior implemented for this option to be useful.
			/// </summary>
            public virtual TBuilder Minimizable(bool minimizable)
            {
                this.ToComponent().Minimizable = minimizable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to make the window modal and mask everything behind it when displayed, false to display it without restricting access to other UI elements (defaults to false).
			/// </summary>
            public virtual TBuilder Modal(bool modal)
            {
                this.ToComponent().Modal = modal;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Allows override of the built-in processing for the escape key. Default action is to close the Window (performing whatever action is specified in closeAction. To prevent the Window closing when the escape key is pressed, specify this as Ext.emptyFn (See Ext.emptyFn).
			/// </summary>
            public virtual TBuilder OnEsc(string onEsc)
            {
                this.ToComponent().OnEsc = onEsc;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to render the window body with a transparent background so that it will blend into the framing elements, false to add a lighter background color to visually highlight the body element and separate it more distinctly from the surrounding frame (defaults to false).
			/// </summary>
            public virtual TBuilder Plain(bool plain)
            {
                this.ToComponent().Plain = plain;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to allow user resizing at each edge and corner of the window, false to disable resizing (defaults to true).
			/// </summary>
            public virtual TBuilder Resizable(bool resizable)
            {
                this.ToComponent().Resizable = resizable;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// A valid Ext.Resizable handles config string (defaults to 'all'). Only applies when resizable = true.
			/// </summary>
            public virtual TBuilder ResizeHandles(string resizeHandles)
            {
                this.ToComponent().ResizeHandles = resizeHandles;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Centers this window in the viewport when the window is initialized.
			/// </summary>
            public virtual TBuilder InitCenter(bool initCenter)
            {
                this.ToComponent().InitCenter = initCenter;
                return this as TBuilder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Aligns the window to the specified element
			/// </summary>
            public virtual TBuilder AlignTo(string element, string position)
            {
                this.ToComponent().AlignTo(element, position);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Aligns the window to the specified element
			/// </summary>
            public virtual TBuilder AlignTo(string element, string position, int offsetX, int offsetY)
            {
                this.ToComponent().AlignTo(element, position, offsetX, offsetY);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Anchors this window to another element and realigns it when the window is resized or scrolled.
			/// </summary>
            public virtual TBuilder AnchorTo(string element, string position)
            {
                this.ToComponent().AnchorTo(element, position);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Anchors this window to another element and realigns it when the window is resized or scrolled.
			/// </summary>
            public virtual TBuilder AnchorTo(string element, string position, int offsetX, int offsetY)
            {
                this.ToComponent().AnchorTo(element, position, offsetX, offsetY);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Anchors this window to another element and realigns it when the window is resized or scrolled.
			/// </summary>
            public virtual TBuilder AnchorTo(string element, string position, int offsetX, int offsetY, bool monitorScroll)
            {
                this.ToComponent().AnchorTo(element, position, offsetX, offsetY, monitorScroll);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Centers this window in the viewport
			/// </summary>
            public virtual TBuilder Center()
            {
                this.ToComponent().Center();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Closes the window, removes it from the DOM and destroys the window object. The beforeclose event is fired before the close happens and will cancel the close action if it returns false.
			/// </summary>
            public virtual TBuilder Close()
            {
                this.ToComponent().Close();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Focuses the window. If a defaultButton is set, it will receive focus, otherwise the window itself will receive focus.
			/// </summary>
            public virtual TBuilder Focus()
            {
                this.ToComponent().Focus();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hides the window, setting it to invisible and applying negative offsets.
			/// </summary>
            public virtual TBuilder Hide()
            {
                this.ToComponent().Hide();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hides the window, setting it to invisible and applying negative offsets.
			/// </summary>
            public virtual TBuilder Hide(Control animateTarget)
            {
                this.ToComponent().Hide(animateTarget);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hides the window, setting it to invisible and applying negative offsets.
			/// </summary>
            public virtual TBuilder Hide(Control animateTarget, string callback)
            {
                this.ToComponent().Hide(animateTarget, callback);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hides the window, setting it to invisible and applying negative offsets.
			/// </summary>
            public virtual TBuilder Hide(Control animateTarget, string callback, string scope)
            {
                this.ToComponent().Hide(animateTarget, callback, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hides the window, setting it to invisible and applying negative offsets.
			/// </summary>
            public virtual TBuilder Hide(string animateTarget)
            {
                this.ToComponent().Hide(animateTarget);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hides the window, setting it to invisible and applying negative offsets.
			/// </summary>
            public virtual TBuilder Hide(string animateTarget, string callback)
            {
                this.ToComponent().Hide(animateTarget, callback);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Hides the window, setting it to invisible and applying negative offsets.
			/// </summary>
            public virtual TBuilder Hide(string animateTarget, string callback, string scope)
            {
                this.ToComponent().Hide(animateTarget, callback, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Fits the window within its current container and automatically replaces the 'maximize' tool button with the 'restore' tool button.
			/// </summary>
            public virtual TBuilder Maximize()
            {
                this.ToComponent().Maximize();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Placeholder method for minimizing the window. By default, this method simply fires the minimize event since the behavior of minimizing a window is application-specific. To implement custom minimize behavior, either the minimize event can be handled or this method can be overridden.
			/// </summary>
            public virtual TBuilder Minimize()
            {
                this.ToComponent().Minimize();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Restores a maximized window back to its original size and position prior to being maximized and also replaces the 'restore' tool button with the 'maximize' tool button.
			/// </summary>
            public virtual TBuilder Restore()
            {
                this.ToComponent().Restore();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Makes this the active window by showing its shadow, or deactivates it by hiding its shadow. This method also fires the activate or deactivate event depending on which action occurred.
			/// </summary>
            public virtual TBuilder SetActive(bool active)
            {
                this.ToComponent().SetActive(active);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the target element from which the window should animate while opening.
			/// </summary>
            public virtual TBuilder SetAnimateTarget(string element)
            {
                this.ToComponent().SetAnimateTarget(element);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sets the target element from which the window should animate while opening.
			/// </summary>
            public virtual TBuilder SetAnimateTarget(Control element)
            {
                this.ToComponent().SetAnimateTarget(element);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
			/// </summary>
            public virtual TBuilder Show()
            {
                this.ToComponent().Show();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
			/// </summary>
            public virtual TBuilder Show(Control animateTarget)
            {
                this.ToComponent().Show(animateTarget);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
			/// </summary>
            public virtual TBuilder Show(Control animateTarget, string callback)
            {
                this.ToComponent().Show(animateTarget, callback);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
			/// </summary>
            public virtual TBuilder Show(Control animateTarget, string callback, string scope)
            {
                this.ToComponent().Show(animateTarget, callback, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
			/// </summary>
            public virtual TBuilder Show(string animateTarget)
            {
                this.ToComponent().Show(animateTarget);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
			/// </summary>
            public virtual TBuilder Show(string animateTarget, string callback)
            {
                this.ToComponent().Show(animateTarget, callback);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
			/// </summary>
            public virtual TBuilder Show(string animateTarget, string callback, string scope)
            {
                this.ToComponent().Show(animateTarget, callback, scope);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Sends this window to the back of (lower z-index than) any other visible windows
			/// </summary>
            public virtual TBuilder ToBack()
            {
                this.ToComponent().ToBack();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Brings this window to the front of any other visible windows
			/// </summary>
            public virtual TBuilder ToFront()
            {
                this.ToComponent().ToFront();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// A shortcut method for toggling between maximize and restore based on the current maximized state of the window.
			/// </summary>
            public virtual TBuilder ToggleMaximize()
            {
                this.ToComponent().ToggleMaximize();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Shows the Window in a Modal state.
			/// </summary>
            public virtual TBuilder ShowModal()
            {
                this.ToComponent().ShowModal();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Shows the Window in a non-Modal state.
			/// </summary>
            public virtual TBuilder HideModal()
            {
                this.ToComponent().HideModal();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Toggle the Modal state of the Window. Shows or Hides the body mask.
			/// </summary>
            public virtual TBuilder ToggleModal()
            {
                this.ToComponent().ToggleModal();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Toggle the Modal state of the Window. Shows or Hides the body mask.
			/// </summary>
            public virtual TBuilder ToggleModal(bool show)
            {
                this.ToComponent().ToggleModal(show);
                return this as TBuilder;
            }
            
        }        
    }
}