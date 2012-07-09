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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Component.Builder<Editor, Editor.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Editor()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Editor component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Editor.Config config) : base(new Editor(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Editor component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Event name for activate the editor
			/// </summary>
            public virtual Editor.Builder ActivateEvent(string activateEvent)
            {
                this.ToComponent().ActivateEvent = activateEvent;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// Size for the editor to automatically adopt the size of the underlying field, Width to adopt the width only, or Height to adopt the height only (defaults to Disable)
			/// </summary>
            public virtual Editor.Builder AutoSize(EditorAutoSize autoSize)
            {
                this.ToComponent().AutoSize = autoSize;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// Editor z-index
			/// </summary>
            public virtual Editor.Builder ZIndex(int zIndex)
            {
                this.ToComponent().ZIndex = zIndex;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True to complete edit complete the editing process if in edit mode when the field is blurred. Defaults to true.
			/// </summary>
            public virtual Editor.Builder AllowBlur(bool allowBlur)
            {
                this.ToComponent().AllowBlur = allowBlur;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True to cancel the edit when the blur event is fired (defaults to false)
			/// </summary>
            public virtual Editor.Builder CancelOnBlur(bool cancelOnBlur)
            {
                this.ToComponent().CancelOnBlur = cancelOnBlur;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True to cancel the edit when the escape key is pressed (defaults to false)
			/// </summary>
            public virtual Editor.Builder CancelOnEsc(bool cancelOnEsc)
            {
                this.ToComponent().CancelOnEsc = cancelOnEsc;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True to complete the edit when the enter key is pressed (defaults to false)
			/// </summary>
            public virtual Editor.Builder CompleteOnEnter(bool completeOnEnter)
            {
                this.ToComponent().CompleteOnEnter = completeOnEnter;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// False to keep the bound element visible while the editor is displayed (defaults to true)
			/// </summary>
            public virtual Editor.Builder HideEl(bool hideEl)
            {
                this.ToComponent().HideEl = hideEl;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True to skip the edit completion process (no save, no events fired) if the user completes an edit and the value has not changed (defaults to false). Applies only to string values - edits for other data types will never be ignored.
			/// </summary>
            public virtual Editor.Builder IgnoreNoChange(bool ignoreNoChange)
            {
                this.ToComponent().IgnoreNoChange = ignoreNoChange;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True to automatically revert the field value and cancel the edit when the user completes an edit and the field validation fails (defaults to true)
			/// </summary>
            public virtual Editor.Builder RevertInvalid(bool revertInvalid)
            {
                this.ToComponent().RevertInvalid = revertInvalid;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// \"sides\" for sides/bottom only, \"frame\" for 4-way shadow, and \"drop\" for bottom-right shadow (defaults to \"frame\")
			/// </summary>
            public virtual Editor.Builder Shadow(ShadowMode shadow)
            {
                this.ToComponent().Shadow = shadow;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// Handle the keydown/keypress events so they don't propagate (defaults to true)
			/// </summary>
            public virtual Editor.Builder SwallowKeys(bool swallowKeys)
            {
                this.ToComponent().SwallowKeys = swallowKeys;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// True to update the innerHTML of the bound element when the update completes (defaults to false)
			/// </summary>
            public virtual Editor.Builder UpdateEl(bool updateEl)
            {
                this.ToComponent().UpdateEl = updateEl;
                return this as Editor.Builder;
            }
             
 			/// <summary>
			/// The data value of the underlying field (defaults to \"\")
			/// </summary>
            public virtual Editor.Builder Value(string value)
            {
                this.ToComponent().Value = value;
                return this as Editor.Builder;
            }
             
 			// /// <summary>
			// /// The Field object (or descendant)
			// /// </summary>
            // public virtual TBuilder Field(ItemsCollection<Field> field)
            // {
            //    this.ToComponent().Field = field;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder TargetControl(Control targetControl)
            // {
            //    this.ToComponent().TargetControl = targetControl;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// The target id to associate with this tooltip.
			/// </summary>
            public virtual Editor.Builder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as Editor.Builder;
            }
             
 			// /// <summary>
			// /// Client-side JavaScript Event Handlers
			// /// </summary>
            // public virtual TBuilder Listeners(InlineEditorListeners listeners)
            // {
            //    this.ToComponent().Listeners = listeners;
            //    return this as TBuilder;
            // }
             
 			// /// <summary>
			// /// Server-side DirectEventHandlers
			// /// </summary>
            // public virtual TBuilder DirectEvents(InlineEditorDirectEvents directEvents)
            // {
            //    this.ToComponent().DirectEvents = directEvents;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// Cancels the editing process and hides the editor without persisting any changes. The field value will be reverted to the original starting value.
			/// </summary>
            public virtual Editor.Builder CancelEdit(bool remainVisible)
            {
                this.ToComponent().CancelEdit(remainVisible);
                return this;
            }
            
 			/// <summary>
			/// Cancels the editing process and hides the editor without persisting any changes. The field value will be reverted to the original starting value.
			/// </summary>
            public virtual Editor.Builder CancelEdit()
            {
                this.ToComponent().CancelEdit();
                return this;
            }
            
 			/// <summary>
			/// Cancels the editing process and hides the editor without persisting any changes. The field value will be reverted to the original starting value.
			/// </summary>
            public virtual Editor.Builder CompleteEdit(bool remainVisible)
            {
                this.ToComponent().CompleteEdit(remainVisible);
                return this;
            }
            
 			/// <summary>
			/// Cancels the editing process and hides the editor without persisting any changes. The field value will be reverted to the original starting value.
			/// </summary>
            public virtual Editor.Builder CompleteEdit()
            {
                this.ToComponent().CompleteEdit();
                return this;
            }
            
 			/// <summary>
			/// Realigns the editor to the bound field based on the current alignment config value.
			/// </summary>
            public virtual Editor.Builder Realign()
            {
                this.ToComponent().Realign();
                return this;
            }
            
 			/// <summary>
			/// Sets the height and width of this editor.
			/// </summary>
            public virtual Editor.Builder SetSize(int width, int height)
            {
                this.ToComponent().SetSize(width, height);
                return this;
            }
            
 			/// <summary>
			/// Starts the editing process and shows the editor.
			/// </summary>
            public virtual Editor.Builder StartEdit(string el, string value)
            {
                this.ToComponent().StartEdit(el, value);
                return this;
            }
            
 			/// <summary>
			/// Starts the editing process and shows the editor.
			/// </summary>
            public virtual Editor.Builder StartEdit(string el)
            {
                this.ToComponent().StartEdit(el);
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public Editor.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Editor(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public Editor.Builder Editor()
        {
            return this.Editor(new Editor());
        }

        /// <summary>
        /// 
        /// </summary>
        public Editor.Builder Editor(Editor component)
        {
            return new Editor.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Editor.Builder Editor(Editor.Config config)
        {
            return new Editor.Builder(new Editor(config));
        }
    }
}