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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Adds a menu item that contains a checkbox by default, but can also be part of a radio group.
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Description("Adds a menu item that contains a checkbox by default, but can also be part of a radio group.")]
    public partial class CheckMenuItem : MenuItemBase, IXPostBackDataHandler
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CheckMenuItem() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.menu.CheckItem";
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
                return "menucheckitem";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnBeforeClientInitHandler()
        {
            base.OnBeforeClientInitHandler();

            if (!RequestManager.IsAjaxRequest || this.IsDynamic)
            {
                string fn = "this.getCheckedField().setValue(checked);";
                this.On("checkchange", new JFunction(fn, "item", "checked"));
            }
        }

        private static readonly object EventCheckedChanged = new object();

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event EventHandler CheckedChanged
        {
            add
            {
                this.Events.AddHandler(EventCheckedChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventCheckedChanged, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnCheckedChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventCheckedChanged];

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
            this.HasLoadPostData = true;

            string val = postCollection[this.ConfigID.ConcatWith("_Checked")];
            
            if (val.IsNotEmpty())
            {
                bool checkedState;
            
                if (bool.TryParse(val.ToLowerInvariant(), out checkedState))
                {
                    if (this.Checked != checkedState)
                    {
                        try
                        {
                            this.SuspendScripting();
                            this.Checked = checkedState;
                        }
                        finally
                        {
                            this.ResumeScripting();
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            this.OnCheckedChanged(EventArgs.Empty);
        }

        /// <summary>
        /// True to initialize this checkbox as checked (defaults to false). Note that if this checkbox is part of a radio group (group = true) only the last item in the group that is initialized with checked = true will be rendered as checked.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetChecked")]
        [Category("6. CheckItem")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to initialize this checkbox as checked (defaults to false). Note that if this checkbox is part of a radio group (group = true) only the last item in the group that is initialized with checked = true will be rendered as checked.")]
        public virtual bool Checked
        {
            get
            {
                object obj = this.ViewState["Checked"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Checked"] = value;
            }
        }

        /// <summary>
        /// All check items with the same group name will automatically be grouped into a single-select radio button group (defaults to '').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CheckItem")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("All check items with the same group name will automatically be grouped into a single-select radio button group (defaults to '').")]
        public virtual string Group
        {
            get
            {
                return (string)this.ViewState["Group"] ?? "";
            }
            set
            {
                this.ViewState["Group"] = value;
            }
        }

        /// <summary>
        /// The default CSS class to use for radio group check items (defaults to \"x-menu-group-item\")
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. CheckItem")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The default CSS class to use for radio group check items (defaults to \"x-menu-group-item\")")]
        public virtual string GroupClass
        {
            get
            {
                return (string)this.ViewState["GroupClass"] ?? "";
            }
            set
            {
                this.ViewState["GroupClass"] = value;
            }
        }

        /// <summary>
        /// A function that handles the checkchange event.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("6. CheckItem")]
        [DefaultValue("")]
        [Description("A function that handles the checkchange event.")]
        public virtual string CheckHandler
        {
            get
            {
                return (string)this.ViewState["CheckHandler"] ?? "";
            }
            set
            {
                this.ViewState["CheckHandler"] = value;
            }
        }

        private CheckMenuItemListeners listeners;

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
        public CheckMenuItemListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new CheckMenuItemListeners();
                }

                return this.listeners;
            }
        }


        private CheckMenuItemDirectEvents directEvents;

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
        public CheckMenuItemDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new CheckMenuItemDirectEvents();
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Set the checked state of this item.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="suppressEvent"></param>
        [Meta]
        [Description("Set the checked state of this item.")]
        public virtual void SetChecked(bool value, bool suppressEvent)
        {
            this.Call("setChecked", value, suppressEvent);
        }

        /// <summary>
        /// Set the checked state of this item.
        /// </summary>
        /// <param name="value"></param>
        [Meta]
        [Description("Set the checked state of this item.")]
        public virtual void SetChecked(bool value)
        {
            this.SetChecked(value, true);
        }
    }
}