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
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A base editor field that handles displaying/hiding on demand and has some built-in sizing and event handling logic.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Editor runat=\"server\" />")]
    [ToolboxBitmap(typeof(Editor), "Build.ToolboxIcons.Editor.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("A base editor field that handles displaying/hiding on demand and has some built-in sizing and event handling logic.")]
    public partial class Editor : Component
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Editor() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "editor";
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
                return "Ext.Editor";
            }
        }
        
        /// <summary>
        /// Event name for activate the editor
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("4. Editor")]
        [DefaultValue("click")]
        [NotifyParentProperty(true)]
        [Description("Event name for activate the editor")]
        public virtual string ActivateEvent
        {
            get
            {
                return (string)this.ViewState["ActivateEvent"] ?? "click";
            }
            set
            {
                this.ViewState["ActivateEvent"] = value;
            }
        }
        
        private EditorAlignmentConfig alignment;

        /// <summary>
        /// The position to align to (see Ext.Element.alignTo for more details, defaults to "c-c?").
        /// </summary>
        [ConfigOption(JsonMode.ToString)]
        [Category("4. Editor")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The position to align to (see Ext.Element.alignTo for more details, defaults to \"c-c?\").")]
        public virtual EditorAlignmentConfig Alignment
        {
            get
            {
                if (this.alignment == null)
                {
                    this.alignment = new EditorAlignmentConfig();
                }

                return this.alignment;
            }
        }

        /// <summary>
        /// Size for the editor to automatically adopt the size of the underlying field, "Width" to adopt the width only, or "Height" to adopt the height only (defaults to Disable)
        /// </summary>
        [Meta]
        [Category("4. Editor")]
        [DefaultValue(EditorAutoSize.Disable)]
        [NotifyParentProperty(true)]
        [Description("Size for the editor to automatically adopt the size of the underlying field, Width to adopt the width only, or Height to adopt the height only (defaults to Disable)")]
        public virtual EditorAutoSize AutoSize
        {
            get
            {
                object obj = this.ViewState["AutoSize"];
                return (obj == null) ? EditorAutoSize.Disable : (EditorAutoSize)obj;
            }
            set
            {
                this.ViewState["AutoSize"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("false")]
        [ConfigOption("autoSize", JsonMode.Raw)]
		[Description("")]
        protected string AutoSizeProxy
        {
            get
            {
                switch(this.AutoSize)
                {
                    case EditorAutoSize.Disable:
                        return "false";
                    case EditorAutoSize.Fit:
                        return "true";
                    case EditorAutoSize.Width:
                        return JSON.Serialize("width");
                    case EditorAutoSize.Height:
                        return JSON.Serialize("height");
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Editor z-index
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("Editor z-index")]
        public virtual int ZIndex
        {
            get
            {
                object obj = this.ViewState["ZIndex"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["ZIndex"] = value;
            }
        }

        /// <summary>
        /// True to complete edit complete the editing process if in edit mode when the field is blurred. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to complete edit complete the editing process if in edit mode when the field is blurred. Defaults to true.")]
        public virtual bool AllowBlur
        {
            get
            {
                object obj = this.ViewState["AllowBlur"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AllowBlur"] = value;
            }
        }

        /// <summary>
        /// True to cancel the edit when the blur event is fired (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to cancel the edit when the blur event is fired (defaults to false)")]
        public virtual bool CancelOnBlur
        {
            get
            {
                object obj = this.ViewState["CancelOnBlur"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["CancelOnBlur"] = value;
            }
        }

        /// <summary>
        /// True to cancel the edit when the escape key is pressed (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to cancel the edit when the escape key is pressed (defaults to false)")]
        public virtual bool CancelOnEsc
        {
            get
            {
                object obj = this.ViewState["CancelOnEsc"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["CancelOnEsc"] = value;
            }
        }

        /// <summary>
        /// True to complete the edit when the enter key is pressed (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to complete the edit when the enter key is pressed (defaults to false)")]
        public virtual bool CompleteOnEnter
        {
            get
            {
                object obj = this.ViewState["CompleteOnEnter"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["CompleteOnEnter"] = value;
            }
        }

        /// <summary>
        /// False to keep the bound element visible while the editor is displayed (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to keep the bound element visible while the editor is displayed (defaults to true)")]
        public virtual bool HideEl
        {
            get
            {
                object obj = this.ViewState["HideEl"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["HideEl"] = value;
            }
        }

        /// <summary>
        /// True to skip the edit completion process (no save, no events fired) if the user completes an edit and the value has not changed (defaults to false). Applies only to string values - edits for other data types will never be ignored.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to skip the edit completion process (no save, no events fired) if the user completes an edit and the value has not changed (defaults to false). Applies only to string values - edits for other data types will never be ignored.")]
        public virtual bool IgnoreNoChange
        {
            get
            {
                object obj = this.ViewState["IgnoreNoChange"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["IgnoreNoChange"] = value;
            }
        }

        /// <summary>
        /// True to automatically revert the field value and cancel the edit when the user completes an edit and the field validation fails (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to automatically revert the field value and cancel the edit when the user completes an edit and the field validation fails (defaults to true)")]
        public virtual bool RevertInvalid
        {
            get
            {
                object obj = this.ViewState["RevertInvalid"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["RevertInvalid"] = value;
            }
        }

        /// <summary>
        /// "sides" for sides/bottom only, "frame" for 4-way shadow, and "drop" for bottom-right shadow (defaults to "frame")
        /// </summary>
        [Meta]
        [ConfigOption(typeof(ShadowJsonConverter))]
        [Category("4. Editor")]
        [DefaultValue(ShadowMode.Frame)]
        [NotifyParentProperty(true)]
        [Description("\"sides\" for sides/bottom only, \"frame\" for 4-way shadow, and \"drop\" for bottom-right shadow (defaults to \"frame\")")]
        public virtual ShadowMode Shadow
        {
            get
            {
                object obj = this.ViewState["Shadow"];
                return (obj == null) ? ShadowMode.Frame : (ShadowMode)obj;
            }
            set
            {
                this.ViewState["Shadow"] = value;
            }
        }

        /// <summary>
        /// Handle the keydown/keypress events so they don't propagate (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Handle the keydown/keypress events so they don't propagate (defaults to true)")]
        public virtual bool SwallowKeys
        {
            get
            {
                object obj = this.ViewState["SwallowKeys"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["SwallowKeys"] = value;
            }
        }

        /// <summary>
        /// Handle the keydown/keypress events so they don't propagate (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. Editor")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to update the innerHTML of the bound element when the update completes (defaults to false)")]
        public virtual bool UpdateEl
        {
            get
            {
                object obj = this.ViewState["UpdateEl"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["UpdateEl"] = value;
            }
        }

        /// <summary>
        /// The data value of the underlying field (defaults to "")
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetValueProxy")]
        [Category("4. Editor")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The data value of the underlying field (defaults to \"\")")]
        public virtual string Value
        {
            get
            {
                object obj = this.ViewState["Value"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["Value"] = value;
            }
        }

        private ItemsCollection<Field> field;

        /// <summary>
        /// The Field object (or descendant)
        /// </summary>
        [Meta]
        [ConfigOption("field", typeof(ItemCollectionJsonConverter))]
        [Category("4. Editor")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The Field object (or descendant)")]
        public virtual ItemsCollection<Field> Field
        {
            get
            {
                if (this.field == null)
                {
                    this.field = new ItemsCollection<Field>();
                    this.field.SingleItemMode = true;
                    this.field.AfterItemAdd += this.AfterItemAdd;
                    this.field.AfterItemRemove += this.AfterItemRemove;
                }

                return this.field;
            }
        }

        int[] offsets;

        /// <summary>
        /// The offsets to use when aligning. Defaults to [0, 0].
        /// </summary>
        [ConfigOption(JsonMode.AlwaysArray)]
        [TypeConverter(typeof(IntArrayConverter))]
        [NotifyParentProperty(true)]
        [DefaultValue(null)]
        [Description("The offsets to use when aligning. Defaults to [0, 0].")]
        public virtual int[] Offsets
        {
            get
            {
                return this.offsets;
            }
            set
            {
                this.offsets = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override string RenderTo
        {
            get
            {
                return "";
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public override string ApplyTo
        {
            get
            {
                return "";
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
        [DefaultValue(false)]
		[Description("")]
        protected virtual bool IsSeparate
        {
            get
            {
                return true;
            }
        }

        private Control targetControl;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public Control TargetControl
        {
            get
            {
                return this.targetControl;
            }
            set
            {
                this.targetControl = value;
            }
        }

        /// <summary>
        /// The target id to associate with this tooltip.
        /// </summary>
        [Meta]
        [Category("4. Editor")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The target id to associate with this tooltip.")]
        public virtual string Target
        {
            get
            {
                return (string)this.ViewState["Target"] ?? "";
            }
            set
            {
                this.ViewState["Target"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("target", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string TargetProxy
        {
            get
            {
                string target = this.Target;

                if (target.IsNotEmpty())
                {
                    return this.ParseTarget(target);
                }

                if (this.TargetControl != null)
                {
                    return JSON.Serialize(this.TargetControl.ClientID);
                }

                return "";
            }
        }

        internal override string GetClientConstructor(bool instanceOnly, string body)
        {
            string field = this.Field.Count == 0 ? "{xtype: \"textfield\"}" : "{}";

            string template = (instanceOnly) ? "new {1}({3},{2})" : "new {1}({3},{2});";

            return string.Format(template, this.ClientID, this.InstanceOf, body ?? this.InitialConfig, field);
        }

        private InlineEditorListeners listeners;

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


        private InlineEditorDirectEvents directEvents;

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


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Cancels the editing process and hides the editor without persisting any changes. The field value will be reverted to the original starting value.
        /// </summary>
        /// <param name="remainVisible">Override the default behavior and keep the editor visible after cancel</param>
        [Meta]
        [Description("Cancels the editing process and hides the editor without persisting any changes. The field value will be reverted to the original starting value.")]
        public virtual void CancelEdit(bool remainVisible)
        {
            this.Call("cancelEdit", remainVisible);
        }

        /// <summary>
        /// Cancels the editing process and hides the editor without persisting any changes. The field value will be reverted to the original starting value.
        /// </summary>
        [Meta]
        [Description("Cancels the editing process and hides the editor without persisting any changes. The field value will be reverted to the original starting value.")]
        public virtual void CancelEdit()
        {
            this.Call("cancelEdit");
        }

        /// <summary>
        /// Ends the editing process, persists the changed value to the underlying field, and hides the editor.
        /// </summary>
        /// <param name="remainVisible">Override the default behavior and keep the editor visible after edit (defaults to false)</param>
        [Meta]
        [Description("Cancels the editing process and hides the editor without persisting any changes. The field value will be reverted to the original starting value.")]
        public virtual void CompleteEdit(bool remainVisible)
        {
            this.Call("completeEdit", remainVisible);
        }

        /// <summary>
        /// Ends the editing process, persists the changed value to the underlying field, and hides the editor.
        /// </summary>
        [Meta]
        [Description("Cancels the editing process and hides the editor without persisting any changes. The field value will be reverted to the original starting value.")]
        public virtual void CompleteEdit()
        {
            this.Call("completeEdit");
        }

        /// <summary>
        /// Realigns the editor to the bound field based on the current alignment config value.
        /// </summary>
        [Meta]
        [Description("Realigns the editor to the bound field based on the current alignment config value.")]
        public virtual void Realign()
        {
            this.Set("alignment", new JRawValue(this.Alignment.ToString()));
            this.Call("realign");
        }

        /// <summary>
        /// Sets the height and width of this editor.
        /// </summary>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        [Meta]
        [Description("Sets the height and width of this editor.")]
        public virtual void SetSize(int width, int height)
        {
            this.Call("setSize", width, height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [Description("")]
        protected virtual void SetValueProxy(string value)
        {
            this.Call("setValue", value);
        }

        /// <summary>
        /// Sets the data value of the editor
        /// </summary>
        /// <param name="value">Any valid value supported by the underlying field</param>
        [Description("Sets the data value of the editor")]
        public virtual void SetValue(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Starts the editing process and shows the editor.
        /// </summary>
        /// <param name="el">The element to edit</param>
        /// <param name="value">A value to initialize the editor with. If a value is not provided, it defaults to the innerHTML of el.</param>
        [Meta]
        [Description("Starts the editing process and shows the editor.")]
        public virtual void StartEdit(string el, string value)
        {
            this.Call("startEdit", new JRawValue("Ext.net.getEl({0})".FormatWith(this.ParseTarget(el))), value);
        }

        /// <summary>
        /// Starts the editing process and shows the editor.
        /// </summary>
        /// <param name="el">The element to edit</param>
        [Meta]
        [Description("Starts the editing process and shows the editor.")]
        public virtual void StartEdit(string el)
        {
            this.Call("startEdit", new JRawValue("Ext.net.getEl({0})".FormatWith(this.ParseTarget(el))));
        }
    }
}