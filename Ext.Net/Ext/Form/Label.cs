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

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Basic Label field.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Label runat=\"server\" />")]
    [DefaultProperty("Html")]
    [ParseChildren(true, "Html")]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [Designer(typeof(LabelDesigner))]
    [ToolboxBitmap(typeof(Label), "Build.ToolboxIcons.Label.bmp")]
    [Description("Basic Label field.")]
    public partial class Label : BoxComponentBase, ITextControl, IIcon
    {
        /*  Ctor
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Label() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Label(string text) 
        {
            this.Text = text;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Label(string format, string text)
        {
            this.Format = format;
            this.Text = text;
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
                return "Ext.form.Label";
            }
        }


        /*  Override
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
                return "label";
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
                return Const.DisplayInline;
            }
        }


        /*  Public Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// The format of the string to render using the .Text property. Example 'Hello {0}'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Label")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The format of the string to render using the .Text property. Example 'Hello {0}'.")]
        public virtual string Format
        {
            get
            {
                return (string)this.ViewState["Format"] ?? "";
            }
            set
            {
                this.ViewState["Format"] = value;
            }
        }

        /// <summary>
        /// The default text to display if the Text property is empty (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("5. Label")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("The default text to display if the Text property is empty (defaults to '').")]
        public virtual string EmptyText
        {
            get
            {
                return (string)this.ViewState["EmptyText"] ?? "";
            }
            set
            {
                this.ViewState["EmptyText"] = value;
            }
        }
        
        /// <summary>
        /// The id of the input element to which this label will be bound via the standard 'htmlFor' attribute. If not specified, the attribute will not be added to the label.
        /// </summary>
        [Meta]
        [ConfigOption("forId")]
        [Category("5. Label")]
        [DefaultValue("")]
        [Description("The id of the input element to which this label will be bound via the standard 'htmlFor' attribute. If not specified, the attribute will not be added to the label.")]
        public virtual string ForID
        {
            get
            {
                return (string)this.ViewState["ForID"] ?? "";
            }
            set
            {
                this.ViewState["ForID"] = value;
            }
        }

        /// <summary>
        /// An HTML fragment that will be used as the label's innerHTML (defaults to ''). Note that if text is specified it will take precedence and this value will be ignored.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetHtml")]
        [Localizable(true)]
        [Category("5. Label")]
        [DefaultValue("")]
        [Description("An HTML fragment that will be used as the label's innerHTML (defaults to ''). Note that if text is specified it will take precedence and this value will be ignored.")]
        public virtual string Html
        {
            get
            {
                return (string)this.ViewState["Html"] ?? "";
            }
            set
            {
                this.ViewState["Html"] = value;
            }
        }

        /// <summary>
        /// The plain text to display within the label (defaults to ''). If you need to include HTML tags within the label's innerHTML, use the html config instead.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetText")]
        [Localizable(true)]
        [Category("5. Label")]
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

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("text")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string TextProxy
        {
            get
            {
                if (this.EmptyText.IsNotEmpty() && this.Text.IsEmpty())
                {
                    return this.EmptyText;
                }

                if (this.Text.IsNotEmpty() && this.Format.IsNotEmpty())
                {
                    return string.Format(this.Format, this.Text);
                }

                return this.Text;
            }
        }

        /// <summary>
        /// The icon to use in the label. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetIconClass")]
        [Category("5. Label")]
        [DefaultValue(Icon.None)]
        [Description("The icon to use in the label. See also, IconCls to set an icon with a custom Css class.")]
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
        protected virtual string IconClsProxy
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
        /// A css class which sets a background image to be used as the icon for this label.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetIconClass")]
        [Category("5. Label")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class which sets a background image to be used as the icon for this label.")]
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

        /// <summary>
        /// (optional) Set the CSS text-align property of the icon. The center is not supported. Defaults left.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("5. Label")]
        [DefaultValue(Alignment.Left)]
        [Description("(optional) Set the CSS text-align property of the icon. The center is not supported. Defaults to \"Left\"")]
        public virtual Alignment IconAlign
        {
            get
            {
                object obj = this.ViewState["IconAlign"];
                return (obj == null) ? Alignment.Left : (Alignment)obj;
            }
            set
            {
                this.ViewState["IconAlign"] = value;
            }
        }

        private ItemsCollection<Editor> editor;

        /// <summary>
        /// Inline editor
        /// </summary>
        [Meta]
        [ConfigOption("editor", typeof(ItemCollectionJsonConverter))]
        [Category("5. Label")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Inline editor")]
        public virtual ItemsCollection<Editor> Editor
        {
            get
            {
                if (this.editor == null)
                {
                    this.editor = new ItemsCollection<Editor>();
                    this.editor.SingleItemMode = true;
                    this.editor.AfterItemAdd += this.AfterItemAdd;
                    this.editor.AfterItemRemove += this.AfterItemRemove;
                }

                return this.editor;
            }
        }


        /*  Client Events
            -----------------------------------------------------------------------------------------------*/

        private BoxComponentListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public BoxComponentListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new BoxComponentListeners();
                }

                return this.listeners;
            }
        }

        private BoxComponentDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side Ajax Event Handlers")]
        public BoxComponentDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new BoxComponentDirectEvents();
                }

                return this.directEvents;
            }
        }

        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Updates the label's innerHTML with the specified string.
        /// </summary>
        [Description("Updates the label's innerHTML with the specified string.")]
        protected virtual void SetHtml(string html)
        {
            this.SetText(html, false);
        }

        /// <summary>
        /// Updates the label's innerHTML with the specified string.
        /// </summary>
        [Description("Updates the label's innerHTML with the specified string.")]
        protected virtual void SetText(string text)
        {
            this.SetText(text, true);
        }

        /// <summary>
        /// Updates the label's innerHTML with the specified string.
        /// </summary>
        [Description("Updates the label's innerHTML with the specified string.")]
        protected virtual void SetText(string text, bool encode)
        {
            this.Call("setText", text, encode);
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        [Description("Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.")]
        protected virtual void SetIconClass(string cls)
        {
            this.Call("setIconClass", cls);
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
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

        List<Icon> IIcon.Icons
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