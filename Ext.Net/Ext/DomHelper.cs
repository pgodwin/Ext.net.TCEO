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
using System.Text;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class DomObject : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.Tag == HtmlTextWriterTag.Div &&
                       this.ID.IsEmpty() &&
                       this.Cls.IsEmpty() &&
                       this.Html.IsEmpty() &&
                       this.CustomConfig.Count == 0 &&
                       this.Children.Count == 0;
            }
        }

        /// <summary>
        /// The tag name of the element
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("Config Options")]
        [DefaultValue(HtmlTextWriterTag.Div)]
        [Description("The tag name of the element")]
        public virtual HtmlTextWriterTag Tag
        {
            get
            {
                object obj = this.ViewState["Tag"];
                return (obj == null) ? HtmlTextWriterTag.Div : (HtmlTextWriterTag)obj;
            }
            set
            {
                this.ViewState["Tag"] = value;
            }
        }

        /// <summary>
        /// The id of the element
        /// </summary>
        [ConfigOption("id")]
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("The id of the element")]
        public virtual string ID
        {
            get
            {
                return (string)this.ViewState["ID"] ?? "";
            }
            set
            {
                this.ViewState["ID"] = value;
            }
        }

        /// <summary>
        /// The class attribute of the element. This will end up being either the "class" attribute on a HTML fragment or className for a DOM node, depending on whether DomHelper is using fragments or DOM.
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("The class attribute of the element. This will end up being either the \"class\" attribute on a HTML fragment or className for a DOM node, depending on whether DomHelper is using fragments or DOM.")]
        public virtual string Cls
        {
            get
            {
                return (string)this.ViewState["Cls"] ?? "";
            }
            set
            {
                this.ViewState["Cls"] = value;
            }
        }

        /// <summary>
        /// The innerHTML for the element
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [Description("The innerHTML for the element")]
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

        private ConfigItemCollection customConfig;

        [ConfigOption("-", typeof(CustomConfigJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Collection of custom js config")]
        public virtual ConfigItemCollection CustomConfig
        {
            get
            {
                if (this.customConfig == null)
                {
                    this.customConfig = new ConfigItemCollection();
                }

                return this.customConfig;
            }
        }

        private DomObjectCollection children;

        /// <summary>
        /// An array of the same kind of element definition objects to be created and appended. These can be nested as deep as you want.
        /// </summary>
        [ConfigOption("cn", JsonMode.AlwaysArray)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An array of the same kind of element definition objects to be created and appended. These can be nested as deep as you want.")]
        public virtual DomObjectCollection Children
        {
            get
            {
                if (this.children == null)
                {
                    this.children = new DomObjectCollection();
                }

                return this.children;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Serialize()
        {
            return new ClientConfig().Serialize(this);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class DomObjectCollection : StateManagedCollection<DomObject> { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class DomHelper
    {
        private static string FormatArgs(object[] args)
        {
            StringBuilder sb = new StringBuilder();

            if (args != null && args.Length > 0)
            {
                foreach (object arg in args)
                {
                    if (arg is string)
                    {
                        sb.AppendFormat("{0},", TokenUtils.ParseAndNormalize(arg.ToString(), ResourceManager.GetInstance(HttpContext.Current)));
                    }
                    else
                    {
                        sb.AppendFormat("{0},", JSON.Serialize(arg));
                    }
                }
            }
            return sb.ToString().LeftOfRightmostOf(',');
        }

        private static void RegisterScript(string name, params object[] arguments)
        {
            ResourceManager rm = ResourceManager.GetInstance(HttpContext.Current);
            string script = "Ext.DomHelper.".ConcatWith(name, "(", FormatArgs(arguments), ");");

            if (rm != null)
            {
                rm.AddScript(script);
                return;
            }

            ResourceManager.AddInstanceScript(script);
        }

        private static Element ReturnElement(string name, params object[] arguments)
        {
            Element e = new Element("Ext.DomHelper.".ConcatWith(name, "(", FormatArgs(arguments), ")"));
            e.RegisterVar();

            return e;
        }
        
        private static Element Call(bool register, string name, params object[] arguments)
        {
            if (register)
            {
                DomHelper.RegisterScript(name, arguments);
                return null;
            }

            return DomHelper.ReturnElement(name, arguments);
        }

        /// <summary>
        /// Creates new DOM element(s) and appends them to el.
        /// </summary>
        /// <param name="el">The context element</param>
        /// <param name="o">The DOM object spec (and children) or raw HTML blob</param>
        public static Element Append(Element el, DomObject o)
        {
            return DomHelper.Call(false, "append", new JRawValue(el.Descriptor), new JRawValue(new ClientConfig().Serialize(o)), true);
        }

        /// <summary>
        /// Creates new DOM element(s) and appends them to el.
        /// </summary>
        /// <param name="el">The context element</param>
        /// <param name="o">Raw HTML blob</param>
        public static Element Append(Element el, string o)
        {
            return DomHelper.Call(false, "append", new JRawValue(el.Descriptor), o, true);
        }

        /// <summary>
        /// Applies a style specification to an element.
        /// </summary>
        /// <param name="el">The element to apply styles to</param>
        /// <param name="styles">A style specification.</param>
        public static void ApplyStyles(Element el, Dictionary<string, string> styles)
        {
            DomHelper.Call(true, "applyStyles", new JRawValue(el.Descriptor), styles);
        }

        /// <summary>
        /// Creates new DOM element(s) and inserts them after el.
        /// </summary>
        /// <param name="el">The context element</param>
        /// <param name="o">The DOM object spec (and children)</param>
        public static Element InsertAfter(Element el, DomObject o)
        {
            return DomHelper.Call(false, "insertAfter", new JRawValue(el.Descriptor), new JRawValue(o.Serialize()), true);
        }

        /// <summary>
        /// Creates new DOM element(s) and inserts them after el.
        /// </summary>
        /// <param name="el">The context element</param>
        /// <param name="o">The DOM object spec (and children)</param>
        public static Element InsertAfter(Element el, string o)
        {
            return DomHelper.Call(false, "insertAfter", new JRawValue(el.Descriptor), o, true);
        }

        /// <summary>
        /// Creates new DOM element(s) and inserts them before el.
        /// </summary>
        /// <param name="el">The context element</param>
        /// <param name="o">The DOM object spec (and children)</param>
        public static Element InsertBefore(Element el, DomObject o)
        {
            return DomHelper.Call(false, "insertBefore", new JRawValue(el.Descriptor), new JRawValue(o.Serialize()), true);
        }

        /// <summary>
        /// Creates new DOM element(s) and inserts them before el.
        /// </summary>
        /// <param name="el">The context element</param>
        /// <param name="o">The DOM object spec (and children)</param>
        public static Element InsertBefore(Element el, string o)
        {
            return DomHelper.Call(false, "insertBefore", new JRawValue(el.Descriptor), o, true);
        }

        /// <summary>
        /// Creates new DOM element(s) and inserts them as the first child of el.
        /// </summary>
        /// <param name="el">The context element</param>
        /// <param name="o">The DOM object spec (and children)</param>
        public static Element InsertFirst(Element el, DomObject o)
        {
            return DomHelper.Call(false, "insertFirst", new JRawValue(el.Descriptor), new JRawValue(o.Serialize()), true);
        }

        /// <summary>
        /// Creates new DOM element(s) and inserts them as the first child of el.
        /// </summary>
        /// <param name="el">The context element</param>
        /// <param name="o">The DOM object spec (and children)</param>
        public static Element InsertFirst(Element el, string o)
        {
            return DomHelper.Call(false, "insertFirst", new JRawValue(el.Descriptor), o, true);
        }

        /// <summary>
        /// Inserts an HTML fragment into the DOM.
        /// </summary>
        /// <param name="where">Where to insert the html in relation to el - BeforeBegin, AfterBegin, BeforeEnd, AfterEnd.</param>
        /// <param name="el">The context element</param>
        /// <param name="html">The HTML fragmenet</param>
        public static Element InsertHtml(InsertPosition where, Element el, string html)
        {
            Element e = Element.Get("Ext.DomHelper.".ConcatWith("insertHtml", "(", FormatArgs(new object[]{where.ToString().ToLowerCamelCase(), new JRawValue(el.Descriptor+".dom"), Element.ConvertToSafeJSHtml(html)}), ")"));
            e.RegisterVar();

            return e;
        }

        /// <summary>
        /// Creates new DOM element(s) and overwrites the contents of el with them.
        /// </summary>
        /// <param name="el">The context element</param>
        /// <param name="o">The DOM object spec (and children)</param>
        public static Element Overwrite(Element el, DomObject o)
        {
            return DomHelper.Call(false, "overwrite", new JRawValue(el.Descriptor), new JRawValue(o.Serialize()), true);
        }

        /// <summary>
        /// Creates new DOM element(s) and overwrites the contents of el with them.
        /// </summary>
        /// <param name="el">The context element</param>
        /// <param name="o">The DOM object spec (and children)</param>
        public static Element Overwrite(Element el, string o)
        {
            return DomHelper.Call(false, "overwrite", new JRawValue(el.Descriptor), o, true);
        }
    }
}