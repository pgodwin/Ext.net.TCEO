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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Simple color palette class for choosing colors.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:ColorPalette runat=\"server\"></{0}:ColorPalette>")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(ColorPalette), "Build.ToolboxIcons.ColorPalette.bmp")]
    [DefaultProperty("Value")]
    [DefaultEvent("SelectionChanged")]
    [ValidationProperty("Value")]
    [ControlValueProperty("Value")]
    [SupportsEventValidation]
    [Description("Simple color palette class for choosing colors.")]
    public partial class ColorPalette : Component, IAutoPostBack, IXPostBackDataHandler, IPostBackEventHandler
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ColorPalette() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "colorpalette";
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
                return "Ext.ColorPalette";
            }
        }

        /// <summary>
        /// If set to true then reselecting a color that is already selected fires the select event
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. ColorPalette")]
        [DefaultValue(false)]
        [Description("If set to true then reselecting a color that is already selected fires the select event")]
        public virtual bool AllowReselect
        {
            get
            {
                object obj = this.ViewState["AllowReselect"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AllowReselect"] = value;
            }
        }

        private readonly string[] predefinedColors = new string[]{
            "000000", "993300", "333300", "003300", "003366", "000080", "333399", "333333",
            "800000", "FF6600", "808000", "008000", "008080", "0000FF", "666699", "808080",
            "FF0000", "FF9900", "99CC00", "339966", "33CCCC", "3366FF", "800080", "969696",
            "FF00FF", "FFCC00", "FFFF00", "00FF00", "00FFFF", "00CCFF", "993366", "C0C0C0",
            "FF99CC", "FFCC99", "FFFF99", "CCFFCC", "CCFFFF", "99CCFF", "CC99FF", "FFFFFF"
        };

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string[] PredefinedColors
        {
            get
            {
                return (string[])this.predefinedColors.Clone();
            }
        }

        private string[] colors;

        /// <summary>
        /// An array of 6-digit color hex code strings (without the # symbol).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.AlwaysArray)]
        [DefaultValue(null)]
        [Description("An array of 6-digit color hex code strings (without the # symbol).")]
        public virtual string[] Colors
        {
            get
            {
                return this.colors;
            }
            set
            {
                if (value != null)
                {
                    value = Array.ConvertAll(value, delegate(string item) { return item.ToUpperInvariant(); });
                }
                
                this.colors = value;
            }
        }

        /// <summary>
        /// The CSS class to apply to the containing element (defaults to \"x-color-palette\")
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. ColorPalette")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The CSS class to apply to the containing element (defaults to \"x-color-palette\")")]
        public override string ItemCls
        {
            get
            {
                return (string)this.ViewState["ItemCls"] ?? "";
            }
            set
            {
                this.ViewState["ItemCls"] = value;
            }
        }

        private XTemplate template;

        /// <summary>
        /// An existing XTemplate instance to be used in place of the default template for rendering the component.
        /// </summary>
        [Meta]
        [Category("4. ColorPalette")]
        [ConfigOption("tpl", typeof(LazyControlJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An existing XTemplate instance to be used in place of the default template for rendering the component.")]
        public virtual XTemplate Template
        {
            get
            {
                if (this.template == null)
                {
                    this.template = new XTemplate();
                    this.Controls.Add(this.template);
                    this.LazyItems.Add(this.template);
                }

                return this.template;
            }
        }

        /// <summary>
        /// The initial color to highlight (should be a valid 6-digit color hex code without the # symbol). Note that the hex codes are case-sensitive.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. ColorPalette")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName = "SilentSelect")]
        [Description("The initial color to highlight (should be a valid 6-digit color hex code without the # symbol). Note that the hex codes are case-sensitive.")]
        public virtual string Value
        {
            get
            {
                return (string)this.ViewState["Value"] ?? "";
            }
            set
            {
                this.ViewState["Value"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            if (this.AutoPostBack)
            {
                this.CustomConfig.Add(new ConfigItem("postback", JSON.Serialize(new { eventName = "select", fn = new JFunction(this.PostBackFunction) }), ParameterMode.Raw));
            }
        }

        /// <summary>
        /// AutoPostBack
        /// </summary>
        /// <value><c>true</c> if [auto post back]; otherwise, <c>false</c>.</value>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("AutoPostBack")]
        public virtual bool AutoPostBack
        {
            get
            {
                object obj = this.ViewState["AutoPostBack"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoPostBack"] = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating whether validation is performed when the control is set to validate when a postback occurs.")]
        public virtual bool CausesValidation
        {
            get
            {
                object obj = this.ViewState["CausesValidation"];
                return (obj != null && (bool)obj);
            }
            set
            {
                this.ViewState["CausesValidation"] = value;
            }
        }

        /// <summary>
        /// Gets or Sets the Controls ValidationGroup
        /// </summary>
        [Meta]
        [Category("Behavior")]
        [DefaultValue("")]
        [Description("Gets or Sets the Controls ValidationGroup")]
        public virtual string ValidationGroup
        {
            get
            {
                return (string)this.ViewState["ValidationGroup"] ?? "";
            }
            set
            {
                this.ViewState["ValidationGroup"] = value;
            }
        }

        private static readonly object EventColorChanged = new object();

        /// <summary>
        /// Fires when the Item property has been changed
        /// </summary>
        [Category("Action")]
        [Description("Fires when the color has been changed")]
        public event EventHandler ColorChanged
        {
            add
            {
                this.Events.AddHandler(EventColorChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventColorChanged, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnColorChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventColorChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private bool hasLoadPostData = false;

        /// <summary>
        /// 
        /// </summary>
        protected virtual bool HasLoadPostData
        {
            get
            {
                return this.hasLoadPostData;
            }
            set
            {
                this.hasLoadPostData = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        bool IXPostBackDataHandler.HasLoadPostData
        {
            get
            {
                return this.HasLoadPostData;
            }
            set
            {
                this.HasLoadPostData = value;
            }
        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            return this.LoadPostData(postDataKey, postCollection);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.ConfigID.ConcatWith("_Color")];

            if (val.IsNotEmpty())
            {
                try
                {
                    this.SuspendScripting();
                    this.Value = val;
                }
                finally
                {
                    this.ResumeScripting();
                }

                return true;
            }

            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            this.RaisePostDataChangedEvent();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void RaisePostDataChangedEvent() { }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            this.OnColorChanged(EventArgs.Empty);
        }

        private ColorPaletteListeners listeners;

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
        public ColorPaletteListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ColorPaletteListeners();
                }

                return this.listeners;
            }
        }


        private ColorPaletteDirectEvents directEvents;

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
        public ColorPaletteDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ColorPaletteDirectEvents();
                }

                return this.directEvents;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Selects the specified color in the palette (fires the select event)
        /// </summary>
        /// <param name="value">color A valid 6-digit color hex code (# will be stripped if included)</param>
        [Meta]
        [Description("Selects the specified color in the palette (fires the select event)")]
        public virtual void Select(string value)
        {
            this.Call("select", value);
        }

        /// <summary>
        /// Selects the specified color in the palette (fires the select event)
        /// </summary>
        /// <param name="value">color A valid 6-digit color hex code (# will be stripped if included)</param>
        /// <param name="suppressEvent">(optional) True to stop the select event from firing. Defaults to <tt>false</tt>.</param>
        [Meta]
        [Description("Selects the specified color in the palette (fires the select event)")]
        public virtual void Select(string value, bool suppressEvent)
        {
            this.Call("select", value, suppressEvent);
        }

        /// <summary>
        /// Selects the specified color in the palette (doesn't fire the select event)
        /// </summary>
        /// <param name="value"></param>
        [Meta]
        [Description("Selects the specified color in the palette (doesn't fire the select event)")]
        public virtual void SilentSelect(string value)
        {
            this.Call("silentSelect", value);
        }
    }
}