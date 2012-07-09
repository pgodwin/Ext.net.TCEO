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
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class Task : StateManagedItem
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Task() { }

        /// <summary>
        /// (optional) The TaskID.
        /// </summary>
        [Meta]
        [ConfigOption("id")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("(optional) The TaskID.")]
        public virtual string TaskID
        {
            get
            {
                return (string)this.ViewState["TaskID"] ?? "";
            }
            set
            {
                this.ViewState["TaskID"] = value;
            }
        }

        /// <summary>
        /// True to auto run task (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TaskManager")]
        [DefaultValue(true)]
        [Description("True to auto run task (defaults to false).")]
        public virtual bool AutoRun
        {
            get
            {
                object obj = this.ViewState["AutoRun"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AutoRun"] = value;
            }
        }

        /// <summary>
        /// The frequency in milliseconds with which the task should be executed (defaults to 1000)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TaskManager")]
        [DefaultValue(1000)]
        [Description("The frequency in milliseconds with which the task should be executed (defaults to 1000)")]
        public virtual int Interval
        {
            get
            {
                object obj = this.ViewState["Interval"];
                return (obj == null) ? 1000 : (int)obj;
            }
            set
            {
                this.ViewState["Interval"] = value;
            }
        }

        /// <summary>
        /// (optional) An array of arguments to be passed to the function specified by run
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("(optional) An array of arguments to be passed to the function specified by run")]
        public virtual string[] Args
        {
            get
            {
                object obj = this.ViewState["Args"];
                return (obj == null) ? null : (string[])obj;
            }
            set
            {
                this.ViewState["Args"] = value;
            }
        }

        /// <summary>
        /// (optional) The scope in which to execute the run function.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("this")]
        [NotifyParentProperty(true)]
        [Description("(optional) The scope in which to execute the run function.")]
        public virtual string Scope
        {
            get
            {
                return (string)this.ViewState["Scope"] ?? "this";
            }
            set
            {
                this.ViewState["Scope"] = value;
            }
        }

        /// <summary>
        /// (optional) The length of time in milliseconds to execute the task before stopping automatically (defaults to indefinite).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TaskManager")]
        [DefaultValue(0)]
        [Description("(optional) The length of time in milliseconds to execute the task before stopping automatically (defaults to indefinite).")]
        public virtual int Duration
        {
            get
            {
                object obj = this.ViewState["Duration"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["Duration"] = value;
            }
        }

        /// <summary>
        /// (optional) The number of times to execute the task before stopping automatically (defaults to indefinite).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. TaskManager")]
        [DefaultValue(0)]
        [Description("(optional) The number of times to execute the task before stopping automatically (defaults to indefinite).")]
        public virtual int Repeat
        {
            get
            {
                object obj = this.ViewState["Repeat"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["Repeat"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("serverRun", JsonMode.Raw)]
        [Description("")]
        protected string DirectEventProxy
        {
            get
            {
                if (!this.DirectEvents.Update.IsDefault)
                {
                    string configObject = new ClientConfig().SerializeInternal(this.DirectEvents.Update, this.DirectEvents.Update.Owner);

                    StringBuilder cfgObj = new StringBuilder(configObject.Length + 64);

                    cfgObj.Append(configObject);
                    if (this.DirectEvents.Update.HandlerIsNotEmpty)
                    {
                        cfgObj.Remove(cfgObj.Length - 1, 1);
                        cfgObj.AppendFormat("{0}eventType: \"{1}\"", configObject.Length > 2 ? "," : "", AjaxRequestType.PostBack.ToString().ToLower());
                        cfgObj.AppendFormat(",action:\"{0}\"", this.DirectEvents.Update.HandlerName);
                        cfgObj.Append("}");
                    }

                    return new JFunction(string.Concat("return ", cfgObj.ToString(), ";")).ToString();
                }
                
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        [ConfigOption("clientRun", JsonMode.Raw)]
        [Description("")]
        protected string ListenerProxy
        {
            get
            {
                if (!this.Listeners.Update.IsDefault)
                {
                    return this.Listeners.Update.ToString();
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [ConfigOption("onstart", typeof(FunctionJsonConverter))]
        [NotifyParentProperty(true)]
        [Description("")]
        public string OnStart
        {
            get
            {
                return (string)this.ViewState["OnStart"] ?? "";
            }
            set
            {
                this.ViewState["OnStart"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [ConfigOption("onstop", typeof(FunctionJsonConverter))]
        [NotifyParentProperty(true)]
        [Description("")]
        public string OnStop
        {
            get
            {
                return (string)this.ViewState["OnStop"] ?? "";
            }
            set
            {
                this.ViewState["OnStop"] = value;
            }
        }

        private TaskListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public TaskListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new TaskListeners();

                    if (this.IsTrackingViewState)
                    {
                        ((IStateManager)this.listeners).TrackViewState();
                    }
                }

                return this.listeners;
            }
        }

        private TaskDirectEvents directEvents;

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
        public TaskDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new TaskDirectEvents();

                    if (this.IsTrackingViewState)
                    {
                        ((IStateManager)this.directEvents).TrackViewState();
                    }
                }

                return this.directEvents;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class TaskCollection : StateManagedCollection<Task> { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class TaskListeners : StateManagedItem
    {
        private SimpleListener update;

        /// <summary>
        /// The function to execute each time the task is run. The function will be called at each interval.
        /// </summary>
        [ConfigOption("clientRun", JsonMode.Raw)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The function to execute each time the task is run. The function will be called at each interval.")]
        public virtual SimpleListener Update
        {
            get
            {
                if (this.update == null)
                {
                    this.update = new SimpleListener();
                }

                return this.update;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override object SaveViewState()
        {
            return this.Update.SaveViewState();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        [Description("")]
        public override void LoadViewState(object state)
        {
            this.Update.LoadViewState(state);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class TaskDirectEvents : StateManagedItem
    {
        private ComponentDirectEvent update;

        /// <summary>
        /// The function to execute each time the task is run. The function will be called at each interval.
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("The function to execute each time the task is run. The function will be called at each interval.")]
        public virtual ComponentDirectEvent Update
        {
            get
            {
                if (this.update == null)
                {
                    this.update = new ComponentDirectEvent();
                }

                return this.update;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override object SaveViewState()
        {
            return this.Update.SaveViewState();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        [Description("")]
        public override void LoadViewState(object state)
        {
            this.Update.LoadViewState(state);
        }
    }
}