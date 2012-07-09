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
using System;

namespace Ext.Net
{
    /// <summary>
    /// Spinner Field
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:SpinnerField runat=\"server\"></{0}:SpinnerField>")]
    [ToolboxBitmap(typeof(Spotlight), "Build.ToolboxIcons.SpinnerField.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Spinner Field")]
    public partial class SpinnerField : NumberFieldBase
    {
        /// <summary>
        /// 
        /// </summary>
        public SpinnerField() { }

        /// <summary>
        /// 
        /// </summary>
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 2;

                baseList.Add(new ClientScriptItem(typeof(SpinnerField), "Ext.Net.Build.Ext.Net.ux.extensions.spinner.spinner.js", "/ux/extensions/spinner/spinner.js"));
                baseList.Add(new ClientStyleItem(typeof(SpinnerField), "Ext.Net.Build.Ext.Net.ux.extensions.spinner.css.spinner-embedded.css", "/ux/extensions/spinner/css/spinner.css"));

                return baseList;
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "spinnerfield";
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
                return "Ext.ux.form.SpinnerField";
            }
        }

        /// <summary>
        /// Increment Value
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. SpinnerField")]
        [DefaultValue(true)]
        [Description("Increment Value")]
        public virtual bool DeferHeight
        {
            get
            {
                object obj = this.ViewState["DeferHeight"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["DeferHeight"] = value;
            }
        }

        /// <summary>
        /// Increment Value
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. SpinnerField")]
        [DefaultValue(1.0)]
        [Description("Increment Value")]
        public virtual double IncrementValue
        {
            get
            {
                object obj = this.ViewState["IncrementValue"];
                return (obj == null) ? 1.0 : (double)obj;
            }
            set
            {
                this.ViewState["IncrementValue"] = value;
            }
        }

        /// <summary>
        /// Alerternate Increment Value
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. SpinnerField")]
        [DefaultValue(5.0)]
        [Description("Alerternate Increment Value")]
        public virtual double AlternateIncrementValue
        {
            get
            {
                object obj = this.ViewState["AlternateIncrementValue"];
                return (obj == null) ? 5.0 : (double)obj;
            }
            set
            {
                this.ViewState["AlternateIncrementValue"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. SpinnerField")]
        [DefaultValue("x-form-spinner-trigger")]
        [Description("")]
        public virtual string TriggerClass
        {
            get
            {
                return (string)this.ViewState["TriggerClass"] ?? "x-form-spinner-trigger";
            }
            set
            {
                this.ViewState["TriggerClass"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. SpinnerField")]
        [DefaultValue("x-form-spinner-splitter")]
        [Description("")]
        public virtual string SplitterClass
        {
            get
            {
                return (string)this.ViewState["SplitterClass"] ?? "x-form-spinner-splitter";
            }
            set
            {
                this.ViewState["SplitterClass"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. SpinnerField")]
        [DefaultValue(0.0)]
        [Description("")]
        public virtual double DefaultValue
        {
            get
            {
                object obj = this.ViewState["DefaultValue"];
                return (obj == null) ? 0.0 : (double)obj;
            }
            set
            {
                this.ViewState["DefaultValue"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. SpinnerField")]
        [DefaultValue(false)]
        [Description("")]
        public virtual bool Accelerate
        {
            get
            {
                object obj = this.ViewState["Accelerate"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Accelerate"] = value;
            }
        }

        private SpinnerFieldListeners listeners;

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
        public SpinnerFieldListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new SpinnerFieldListeners();
                }
                return this.listeners;
            }
        }

        private SpinnerFieldDirectEvents directEvents;

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
        public SpinnerFieldDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new SpinnerFieldDirectEvents();
                }
                return this.directEvents;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual void Spin()
        {
            this.Call("spin");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="down"></param>
        [Meta]
        [Description("")]
        public virtual void Spin(bool down)
        {
            this.Call("spin", down);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="down"></param>
        /// <param name="alternate"></param>
        [Meta]
        [Description("")]
        public virtual void Spin(bool down, bool alternate)
        {
            this.Call("spin", down, alternate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [Meta]
        [Description("")]
        public virtual void FixBoundries(double value)
        {
            this.Call("fixBoundries", value);
        }
    }
}