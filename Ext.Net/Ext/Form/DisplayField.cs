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
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// A display-only text field which is not validated and not submitted.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:DisplayField runat=\"server\" />")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(DisplayField), "Build.ToolboxIcons.DisplayField.bmp")]
    [Description("A display-only text field which is not validated and not submitted.")]
    public partial class DisplayField : Field
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DisplayField() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "displayfield";
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
                return "Ext.form.DisplayField";
            }
        }

        /// <summary>
        /// The default CSS class for the field (defaults to "x-form-display-field")
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DisplayField")]
        [DefaultValue("x-form-display-field")]
        [Localizable(true)]
        [Description("The default CSS class for the field (defaults to 'x-form-display-field')")]
        public override string FieldClass
        {
            get
            {
                return (string)this.ViewState["FieldClass"] ?? "x-form-display-field";
            }
            set
            {
                this.ViewState["FieldClass"] = value;
            }
        }
        
        /// <summary>
        /// false to skip HTML-encoding the text when rendering it (defaults to false). This might be useful if you want to include tags in the field's innerHTML rather than rendering them as string literals per the default logic.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetHtmlEncode")]
        [ConfigOption]
        [Category("6. DisplayField")]
        [DefaultValue(false)]
        [Description("false to skip HTML-encoding the text when rendering it (defaults to false). This might be useful if you want to include tags in the field's innerHTML rather than rendering them as string literals per the default logic.")]
        public virtual bool HtmlEncode
        {
            get
            {
                object obj = this.ViewState["HtmlEncode"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HtmlEncode"] = value;
            }
        }

        /// <summary>
        /// The plain text to display within the label (defaults to ''). If you need to include HTML tags within the label's innerHTML, use the html config instead.
        /// </summary>
        [Meta]
        [ConfigOption("value")]
        [DirectEventUpdate(MethodName = "SetValue")]
        [Localizable(true)]
        [Category("6. DisplayField")]
        [DefaultValue("")]
        [Description("The plain text to display within the label (defaults to ''). If you need to include HTML tags within the label's innerHTML, use the html config instead.")]
        public virtual string Text
        {
            get
            {
                return (string)this.ViewState["Text"] ?? "";
            }
            set
            {
                this.ViewState["Text"] = value;
            }
        }

        private FieldListeners listeners;

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
        public FieldListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new FieldListeners();
                }

                return this.listeners;
            }
        }

        private FieldDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side Ajax Event Handlers")]
        public FieldDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new FieldDirectEvents();
                }

                return this.directEvents;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// false to skip HTML-encoding the text when rendering it (defaults to false). This might be useful if you want to include tags in the field's innerHTML rather than rendering them as string literals per the default logic.
        /// </summary>
        /// <seealso cref="HtmlEncode" />
        [Description("false to skip HTML-encoding the text when rendering it (defaults to false). This might be useful if you want to include tags in the field's innerHTML rather than rendering them as string literals per the default logic.")]
        protected virtual void SetHtmlEncode(bool encode)
        {
            this.Set("htmlEncode", encode);
        }

        /// <summary>
        /// Updates the label's innerHTML with the specified string.
        /// </summary>
        /// <seealso cref="HtmlEncode" />
        [Description("Updates the Display Fields inner Html with the specified string.")]
        protected virtual void SetText(string text)
        {
            this.Call("setValue", text);
        }
    }
}