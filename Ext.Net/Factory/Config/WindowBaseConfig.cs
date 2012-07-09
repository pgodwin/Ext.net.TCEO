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
        new public abstract partial class Config : PanelBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool autoWidth = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public override bool AutoWidth 
			{ 
				get
				{
					return this.autoWidth;
				}
				set
				{
					this.autoWidth = value;
				}
			}

			private string animateTarget = "";

			/// <summary>
			/// Id or element from which the window should animate while opening (defaults to null with no animation).
			/// </summary>
			[DefaultValue("")]
			public virtual string AnimateTarget 
			{ 
				get
				{
					return this.animateTarget;
				}
				set
				{
					this.animateTarget = value;
				}
			}

			private bool closable = true;

			/// <summary>
			/// True to display the 'close' tool button and allow the user to close the window, false to hide the button and disallow closing the window (default to true).
			/// </summary>
			[DefaultValue(true)]
			public override bool Closable 
			{ 
				get
				{
					return this.closable;
				}
				set
				{
					this.closable = value;
				}
			}

			private CloseAction closeAction = CloseAction.Hide;

			/// <summary>
			/// The action to take when the close button is clicked. The default action is 'close' which will actually remove the window from the DOM and destroy it. The other valid option is 'hide' which will simply hide the window by setting visibility to hidden and applying negative offsets, keeping the window available to be redisplayed via the show method.
			/// </summary>
			[DefaultValue(CloseAction.Hide)]
			public override CloseAction CloseAction 
			{ 
				get
				{
					return this.closeAction;
				}
				set
				{
					this.closeAction = value;
				}
			}

			private bool constrain = false;

			/// <summary>
			/// True to constrain the window to the viewport, false to allow it to fall outside of the viewport (defaults to false). Optionally the header only can be constrained using ConstrainHeader.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Constrain 
			{ 
				get
				{
					return this.constrain;
				}
				set
				{
					this.constrain = value;
				}
			}

			private bool constrainHeader = false;

			/// <summary>
			/// True to constrain the window header to the viewport, allowing the window body to fall outside of the viewport, false to allow the header to fall outside the viewport (defaults to false). Optionally the entire window can be constrained using constrain.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ConstrainHeader 
			{ 
				get
				{
					return this.constrainHeader;
				}
				set
				{
					this.constrainHeader = value;
				}
			}

			private string defaultButton = "";

			/// <summary>
			/// The id of a button to focus when this window received the focus.
			/// </summary>
			[DefaultValue("")]
			public virtual string DefaultButton 
			{ 
				get
				{
					return this.defaultButton;
				}
				set
				{
					this.defaultButton = value;
				}
			}

			private DefaultRenderTo defaultRenderTo = DefaultRenderTo.Body;

			/// <summary>
			/// The default render to Element (Body or Form). Using when AutoRender='false'
			/// </summary>
			[DefaultValue(DefaultRenderTo.Body)]
			public virtual DefaultRenderTo DefaultRenderTo 
			{ 
				get
				{
					return this.defaultRenderTo;
				}
				set
				{
					this.defaultRenderTo = value;
				}
			}

			private bool draggable = true;

			/// <summary>
			/// True to allow the window to be dragged by the header bar, false to disable dragging (defaults to true). Note that by default the window will be centered in the viewport, so if dragging is disabled the window may need to be positioned programmatically after render (e.g., myWindow.setPosition(100, 100);).
			/// </summary>
			[DefaultValue(true)]
			public override bool Draggable 
			{ 
				get
				{
					return this.draggable;
				}
				set
				{
					this.draggable = value;
				}
			}

			private bool expandOnShow = true;

			/// <summary>
			/// True to always expand the window when it is displayed, false to keep it in its current state (which may be collapsed) when displayed (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ExpandOnShow 
			{ 
				get
				{
					return this.expandOnShow;
				}
				set
				{
					this.expandOnShow = value;
				}
			}

			private bool maximizable = false;

			/// <summary>
			/// True to display the 'maximize' tool button and allow the user to maximize the window, false to hide the button and disallow maximizing the window (defaults to false). Note that when a window is maximized, the tool button will automatically change to a 'restore' button with the appropriate behavior already built-in that will restore the window to its previous size.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Maximizable 
			{ 
				get
				{
					return this.maximizable;
				}
				set
				{
					this.maximizable = value;
				}
			}

			private bool maximized = false;

			/// <summary>
			/// True to initially display the window in a maximized state. (Defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Maximized 
			{ 
				get
				{
					return this.maximized;
				}
				set
				{
					this.maximized = value;
				}
			}

			private Unit height = Unit.Empty;

			/// <summary>
			/// The height of this component in pixels (defaults to auto).
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public override Unit Height 
			{ 
				get
				{
					return this.height;
				}
				set
				{
					this.height = value;
				}
			}

			private Unit minHeight = Unit.Pixel(100);

			/// <summary>
			/// The minimum height in pixels allowed for this window (defaults to 100).
			/// </summary>
			[DefaultValue(typeof(Unit), "100")]
			public override Unit MinHeight 
			{ 
				get
				{
					return this.minHeight;
				}
				set
				{
					this.minHeight = value;
				}
			}

			private Unit width = Unit.Empty;

			/// <summary>
			/// The width of this component in pixels (defaults to auto).
			/// </summary>
			[DefaultValue(typeof(Unit), "")]
			public override Unit Width 
			{ 
				get
				{
					return this.width;
				}
				set
				{
					this.width = value;
				}
			}

			private Unit minWidth = Unit.Pixel(200);

			/// <summary>
			/// The minimum width in pixels allowed for this window (defaults to 200). Only applies when resizable = true.
			/// </summary>
			[DefaultValue(typeof(Unit), "200")]
			public override Unit MinWidth 
			{ 
				get
				{
					return this.minWidth;
				}
				set
				{
					this.minWidth = value;
				}
			}

			private bool minimizable = false;

			/// <summary>
			/// True to display the 'minimize' tool button and allow the user to minimize the window, false to hide the button and disallow minimizing the window (defaults to false). Note that this button provides no implementation -- the behavior of minimizing a window is implementation-specific, so the minimize event must be handled and a custom minimize behavior implemented for this option to be useful.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Minimizable 
			{ 
				get
				{
					return this.minimizable;
				}
				set
				{
					this.minimizable = value;
				}
			}

			private bool modal = false;

			/// <summary>
			/// True to make the window modal and mask everything behind it when displayed, false to display it without restricting access to other UI elements (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Modal 
			{ 
				get
				{
					return this.modal;
				}
				set
				{
					this.modal = value;
				}
			}

			private string onEsc = "Ext.emptyFn";

			/// <summary>
			/// Allows override of the built-in processing for the escape key. Default action is to close the Window (performing whatever action is specified in closeAction. To prevent the Window closing when the escape key is pressed, specify this as Ext.emptyFn (See Ext.emptyFn).
			/// </summary>
			[DefaultValue("Ext.emptyFn")]
			public virtual string OnEsc 
			{ 
				get
				{
					return this.onEsc;
				}
				set
				{
					this.onEsc = value;
				}
			}

			private bool plain = false;

			/// <summary>
			/// True to render the window body with a transparent background so that it will blend into the framing elements, false to add a lighter background color to visually highlight the body element and separate it more distinctly from the surrounding frame (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Plain 
			{ 
				get
				{
					return this.plain;
				}
				set
				{
					this.plain = value;
				}
			}

			private bool resizable = true;

			/// <summary>
			/// True to allow user resizing at each edge and corner of the window, false to disable resizing (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public virtual bool Resizable 
			{ 
				get
				{
					return this.resizable;
				}
				set
				{
					this.resizable = value;
				}
			}

			private string resizeHandles = "all";

			/// <summary>
			/// A valid Ext.Resizable handles config string (defaults to 'all'). Only applies when resizable = true.
			/// </summary>
			[DefaultValue("all")]
			public virtual string ResizeHandles 
			{ 
				get
				{
					return this.resizeHandles;
				}
				set
				{
					this.resizeHandles = value;
				}
			}

			private bool initCenter = true;

			/// <summary>
			/// Centers this window in the viewport when the window is initialized.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool InitCenter 
			{ 
				get
				{
					return this.initCenter;
				}
				set
				{
					this.initCenter = value;
				}
			}

        }
    }
}