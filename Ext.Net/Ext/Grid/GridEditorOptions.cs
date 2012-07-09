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
using System.Web.UI;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class GridEditorOptions : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Serialize()
        {
            return new ClientConfig().Serialize(this, true);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //[Description("")]
        //public override bool IsDefault
        //{
        //    get 
        //    {
        //        return this.Alignment == "tl-tl" &&
        //               this.ZIndex == 0 &&
        //               this.AutoSize == EditorAutoSize.Width &&
        //               !this.AllowBlur &&
        //               !this.CancelOnBlur &&
        //               !this.IgnoreNoChange &&
        //               this.Offsets == null;
        //    }
        //}

        private InlineEditorListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
        /// The position to align to (see Ext.Element.alignTo for more details, defaults to "c-c?").
        /// </summary>
        [ConfigOption]
        [Category("2. GridEditorOptions")]
        [DefaultValue("tl-tl")]
        [NotifyParentProperty(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The position to align to (see Ext.Element.alignTo for more details, defaults to \"tl-tl\").")]
        public virtual string Alignment
        {
            get
            {
                object obj = this.ViewState["Alignment"];
                return (obj == null) ? "tl-tl" : (string)obj;
            }
            set
            {
                this.ViewState["Alignment"] = value;
            }
        }

        /// <summary>
        /// Size for the editor to automatically adopt the size of the underlying field, "Width" to adopt the width only, or "Height" to adopt the height only (defaults to Width)
        /// </summary>
        [Meta]
        [Category("2. GridEditorOptions")]
        [DefaultValue(EditorAutoSize.Width)]
        [NotifyParentProperty(true)]
        [Description("Size for the editor to automatically adopt the size of the underlying field, Width to adopt the width only, or Height to adopt the height only (defaults to Width)")]
        public virtual EditorAutoSize AutoSize
        {
            get
            {
                object obj = this.ViewState["AutoSize"];
                return (obj == null) ? EditorAutoSize.Width : (EditorAutoSize)obj;
            }
            set
            {
                this.ViewState["AutoSize"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue("\"width\"")]
        [ConfigOption("autoSize", JsonMode.Raw)]
		[Description("")]
        protected string AutoSizeProxy
        {
            get
            {
                switch (this.AutoSize)
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
        /// True to complete edit complete the editing process if in edit mode when the field is blurred. Defaults to true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. GridEditorOptions")]
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
        /// True to cancel the edit when the escape key is pressed (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. GridEditorOptions")]
        [DefaultValue(true)]
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
        [Category("2. GridEditorOptions")]
        [DefaultValue(true)]
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
        /// True to cancel the edit when the blur event is fired (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. GridEditorOptions")]
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
        /// True to skip the edit completion process (no save, no events fired) if the user completes an edit and the value has not changed (defaults to false). Applies only to string values - edits for other data types will never be ignored.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. GridEditorOptions")]
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
        [DefaultValue(ShadowMode.None)]
        [NotifyParentProperty(true)]
        [Description("\"sides\" for sides/bottom only, \"frame\" for 4-way shadow, and \"drop\" for bottom-right shadow (defaults to \"frame\")")]
        public virtual ShadowMode Shadow
        {
            get
            {
                object obj = this.ViewState["Shadow"];
                return (obj == null) ? ShadowMode.None : (ShadowMode)obj;
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

        int[] offsets;

        /// <summary>
        /// The offsets to use when aligning. Defaults to [0, 0].
        /// </summary>
        [ConfigOption(JsonMode.AlwaysArray)]
        [Category("2. GridEditorOptions")]
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
    }
}