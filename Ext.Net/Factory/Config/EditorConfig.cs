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
    public partial class Editor
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public Editor(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit Editor.Config Conversion to Editor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator Editor(Editor.Config config)
        {
            return new Editor(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Component.Config 
        { 
			/*  Implicit Editor.Config Conversion to Editor.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator Editor.Builder(Editor.Config config)
			{
				return new Editor.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string activateEvent = "click";

			/// <summary>
			/// Event name for activate the editor
			/// </summary>
			[DefaultValue("click")]
			public virtual string ActivateEvent 
			{ 
				get
				{
					return this.activateEvent;
				}
				set
				{
					this.activateEvent = value;
				}
			}

			private EditorAutoSize autoSize = EditorAutoSize.Disable;

			/// <summary>
			/// Size for the editor to automatically adopt the size of the underlying field, Width to adopt the width only, or Height to adopt the height only (defaults to Disable)
			/// </summary>
			[DefaultValue(EditorAutoSize.Disable)]
			public virtual EditorAutoSize AutoSize 
			{ 
				get
				{
					return this.autoSize;
				}
				set
				{
					this.autoSize = value;
				}
			}

			private int zIndex = 0;

			/// <summary>
			/// Editor z-index
			/// </summary>
			[DefaultValue(0)]
			public virtual int ZIndex 
			{ 
				get
				{
					return this.zIndex;
				}
				set
				{
					this.zIndex = value;
				}
			}

			private bool allowBlur = true;

			/// <summary>
			/// True to complete edit complete the editing process if in edit mode when the field is blurred. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AllowBlur 
			{ 
				get
				{
					return this.allowBlur;
				}
				set
				{
					this.allowBlur = value;
				}
			}

			private bool cancelOnBlur = false;

			/// <summary>
			/// True to cancel the edit when the blur event is fired (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CancelOnBlur 
			{ 
				get
				{
					return this.cancelOnBlur;
				}
				set
				{
					this.cancelOnBlur = value;
				}
			}

			private bool cancelOnEsc = false;

			/// <summary>
			/// True to cancel the edit when the escape key is pressed (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CancelOnEsc 
			{ 
				get
				{
					return this.cancelOnEsc;
				}
				set
				{
					this.cancelOnEsc = value;
				}
			}

			private bool completeOnEnter = false;

			/// <summary>
			/// True to complete the edit when the enter key is pressed (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool CompleteOnEnter 
			{ 
				get
				{
					return this.completeOnEnter;
				}
				set
				{
					this.completeOnEnter = value;
				}
			}

			private bool hideEl = true;

			/// <summary>
			/// False to keep the bound element visible while the editor is displayed (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool HideEl 
			{ 
				get
				{
					return this.hideEl;
				}
				set
				{
					this.hideEl = value;
				}
			}

			private bool ignoreNoChange = false;

			/// <summary>
			/// True to skip the edit completion process (no save, no events fired) if the user completes an edit and the value has not changed (defaults to false). Applies only to string values - edits for other data types will never be ignored.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool IgnoreNoChange 
			{ 
				get
				{
					return this.ignoreNoChange;
				}
				set
				{
					this.ignoreNoChange = value;
				}
			}

			private bool revertInvalid = true;

			/// <summary>
			/// True to automatically revert the field value and cancel the edit when the user completes an edit and the field validation fails (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool RevertInvalid 
			{ 
				get
				{
					return this.revertInvalid;
				}
				set
				{
					this.revertInvalid = value;
				}
			}

			private ShadowMode shadow = ShadowMode.Frame;

			/// <summary>
			/// \"sides\" for sides/bottom only, \"frame\" for 4-way shadow, and \"drop\" for bottom-right shadow (defaults to \"frame\")
			/// </summary>
			[DefaultValue(ShadowMode.Frame)]
			public virtual ShadowMode Shadow 
			{ 
				get
				{
					return this.shadow;
				}
				set
				{
					this.shadow = value;
				}
			}

			private bool swallowKeys = true;

			/// <summary>
			/// Handle the keydown/keypress events so they don't propagate (defaults to true)
			/// </summary>
			[DefaultValue(true)]
			public virtual bool SwallowKeys 
			{ 
				get
				{
					return this.swallowKeys;
				}
				set
				{
					this.swallowKeys = value;
				}
			}

			private bool updateEl = false;

			/// <summary>
			/// True to update the innerHTML of the bound element when the update completes (defaults to false)
			/// </summary>
			[DefaultValue(false)]
			public virtual bool UpdateEl 
			{ 
				get
				{
					return this.updateEl;
				}
				set
				{
					this.updateEl = value;
				}
			}

			private string value = "";

			/// <summary>
			/// The data value of the underlying field (defaults to \"\")
			/// </summary>
			[DefaultValue("")]
			public virtual string Value 
			{ 
				get
				{
					return this.value;
				}
				set
				{
					this.value = value;
				}
			}
        
			private ItemsCollection<Field> field = null;

			/// <summary>
			/// The Field object (or descendant)
			/// </summary>
			public ItemsCollection<Field> Field
			{
				get
				{
					if (this.field == null)
					{
						this.field = new ItemsCollection<Field>();
					}
			
					return this.field;
				}
			}
			        
			private Control targetControl = null;

			/// <summary>
			/// 
			/// </summary>
			public Control TargetControl
			{
				get
				{
					if (this.targetControl == null)
					{
						this.targetControl = new Control();
					}
			
					return this.targetControl;
				}
			}
			
			private string target = "";

			/// <summary>
			/// The target id to associate with this tooltip.
			/// </summary>
			[DefaultValue("")]
			public virtual string Target 
			{ 
				get
				{
					return this.target;
				}
				set
				{
					this.target = value;
				}
			}
        
			private InlineEditorListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public InlineEditorListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new InlineEditorListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private InlineEditorDirectEvents directEvents = null;

			/// <summary>
			/// Server-side DirectEventHandlers
			/// </summary>
			public InlineEditorDirectEvents DirectEvents
			{
				get
				{
					if (this.directEvents == null)
					{
						this.directEvents = new InlineEditorDirectEvents();
					}
			
					return this.directEvents;
				}
			}
			
        }
    }
}