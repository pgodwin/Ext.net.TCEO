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
    /// A basic hidden field for storing hidden values in forms that need to be passed in the form submit. Can be used as a direct replacement for the traditional &lt;asp:Hidden> Web Control.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Hidden runat=\"server\" />")]
    [DefaultProperty("Text")]
    [DefaultEvent("ValueChanged")]
    [ValidationProperty("Text")]
    [ControlValueProperty("Text")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [NonVisualControl]
    [Designer(typeof(HiddenFieldDesigner))]
    [ToolboxBitmap(typeof(Hidden), "Build.ToolboxIcons.Hidden.bmp")]
    [Description("A basic hidden field for storing hidden values in forms that need to be passed in the form submit. Can be used as a direct replacement for the traditional &lt;asp:Hidden> Web Control.")]
    public partial class Hidden : Field
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Hidden() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "hidden";
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
                return "Ext.form.Hidden";
            }
        }

        /// <summary>
        /// The Text value to initialize this field with.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Localizable(true)]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("The Text value to initialize this field with.")]
        public virtual string Text
        {
            get
            {
                return (string)this.Value;
            }
            set
            {
                this.Value = value;
            }
        }

        private bool hideInDesign = false;

        /// <summary>
        /// Hide this Control at Design Time.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(false)]
        [Description("Hide this Control at Design Time.")]
        public virtual bool HideInDesign
        {
            get
            {
                return this.hideInDesign;
            }
            set
            {
                this.hideInDesign = value;
            }
        }


        /*  IField
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// The fields null value.
        /// </summary>
        [Meta]
        [Category("5. Field")]
        [DefaultValue("")]
        [Description("The fields null value.")]
        public override object EmptyValue
        {
            get
            {
                return this.ViewState["EmptyValue"] ?? "";
            }
            set
            {
                this.ViewState["EmptyValue"] = value;
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

        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        private static readonly object EventValueChanged = new object();

        /// <summary>
        /// Fires when the Text property has been changed
        /// </summary>
        [Category("Action")]
        [Description("Fires when the Text property has been changed")]
        public event EventHandler ValueChanged
        {
            add
            {
                Events.AddHandler(EventValueChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventValueChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnValueChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventValueChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.HasLoadPostData = true;

            string val = postCollection[this.UniqueName];

            this.SuspendScripting();
            this.RawValue = val;
            this.ResumeScripting();

            if (val != null && (this.Value == null || !this.Value.Equals(val)))
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
        

        /*  DirectEvent Handler
            -----------------------------------------------------------------------------------------------*/
        
        static Hidden()
        {
            DirectEventChange = new object();
        }

        private static readonly object DirectEventChange;

        /// <summary>
        /// Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).
        /// </summary>
        [Description("Server-side DirectEvent handler. Method signature is (object sender, DirectEventArgs e).")]
        public event ComponentDirectEvent.DirectEventHandler DirectChange
        {
            add
            {
                this.DirectEvents.Change.Event += value;
            }
            remove
            {
                this.DirectEvents.Change.Event -= value;
            }
        }
    }
}