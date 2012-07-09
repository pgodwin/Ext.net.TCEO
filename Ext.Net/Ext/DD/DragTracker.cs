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
using System.Web;
using System.Web.UI;
    
namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    [ToolboxBitmap(typeof(DragSource), "Build.ToolboxIcons.DragDrop.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("")]
    public partial class DragTracker : Observable
    {
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return this.Selection ? "Ext.net.DragTracker" : "Ext.dd.DragTracker";
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption(JsonMode.Ignore)]
        [DefaultValue("")]
		[Description("")]
        protected override string ConfigIDProxy
        {
            get
            {
                return base.ConfigIDProxy;
            }
        }

        /// <summary>
        /// Defaults to 5.
        /// </summary>
        [Category("3. DragTracker")]
        [DefaultValue(5)]
        [ConfigOption]
        [Description("Defaults to 5.")]
        public virtual int Tolerance
        {
            get
            {
                object obj = this.ViewState["Tolerance"];
                return obj != null ? (int) obj : 5;
            }
            set
            {
                this.ViewState["Tolerance"] = value;
            }
        }

        /// <summary>
        /// Defaults to 0. Specify a Number for the number of milliseconds to defer trigger start.
        /// </summary>
        [Category("3. DragTracker")]
        [DefaultValue(0)]
        [ConfigOption]
        [Description("Defaults to 0. Specify a Number for the number of milliseconds to defer trigger start.")]
        public virtual int AutoStart
        {
            get
            {
                object obj = this.ViewState["AutoStart"];
                return obj != null ? (int)obj : 0;
            }
            set
            {
                this.ViewState["AutoStart"] = value;
            }
        }

        /// <summary>
        /// Proxy class
        /// </summary>
        [Category("3. DragDrop")]
        [DefaultValue("x-view-selector")]
        [ConfigOption]
        [Description("Proxy class")]
        public virtual string ProxyCls
        {
            get
            {
                return (string)this.ViewState["ProxyCls"] ?? "x-view-selector";
            }
            set
            {
                this.ViewState["ProxyCls"] = value;
            }
        }

        /// <summary>
        /// Defaults to true. If false then no selection tracker
        /// </summary>
        [Category("3. DragTracker")]
        [DefaultValue(true)]
        [Description("Defaults to true. If false then no selection tracker")]
        public virtual bool Selection
        {
            get
            {
                object obj = this.ViewState["Selection"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["Selection"] = value;
            }
        }

        /// <summary>
        /// ID of the element that is linked to this instance
        /// </summary>
        [Category("3. DragDrop")]
        [DefaultValue("")]
        [ConfigOption("el")]
        [Description("ID of the element that is linked to this instance")]
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

        private JFunction onBeforeStart;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction OnBeforeStart
        {
            get
            {
                if (this.onBeforeStart == null)
                {
                    this.onBeforeStart = new JFunction();

                    if (HttpContext.Current != null)
                    {
                        this.onBeforeStart.Args = new string[] { "e" };
                    }
                }

                return this.onBeforeStart;
            }
        }

        private JFunction onStart;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction OnStart
        {
            get
            {
                if (this.onStart == null)
                {
                    this.onStart = new JFunction();

                    if (HttpContext.Current != null)
                    {
                        this.onStart.Args = new string[] { "e" };
                    }
                }

                return this.onStart;
            }
        }

        private JFunction onDrag;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction OnDrag
        {
            get
            {
                if (this.onDrag == null)
                {
                    this.onDrag = new JFunction();

                    if (HttpContext.Current != null)
                    {
                        this.onDrag.Args = new string[] { "e" };
                    }
                }

                return this.onDrag;
            }
        }

        private JFunction onEnd;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("3. DragDrop")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public virtual JFunction OnEnd
        {
            get
            {
                if (this.onEnd == null)
                {
                    this.onEnd = new JFunction();

                    if (HttpContext.Current != null)
                    {
                        this.onEnd.Args = new string[] { "e" };
                    }
                }

                return this.onEnd;
            }
        }

        private DragTrackerListeners listeners;

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
        public DragTrackerListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new DragTrackerListeners();
                }

                return this.listeners;
            }
        }


        private DragTrackerDirectEvents directEvents;

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
        public DragTrackerDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new DragTrackerDirectEvents();
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Destroy this instance
        /// </summary>
        public void Destroy()
        {
            this.Call("destroy");
        }

        /// <summary>
        /// Init element of tracker
        /// </summary>
        /// <param name="el">Element</param>
        public void InitElement(Element el)
        {
            this.Call("initEl", new JRawValue(el.Descriptor));
        }
    }
}