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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class TabStripItem : StateManagedItem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        public TabStripItem(Control owner) : base(owner) { }

        /// <summary>
        /// 
        /// </summary>
        public TabStripItem() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        public TabStripItem(string title)
        {
            this.Title = title;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="title"></param>
        public TabStripItem(string itemID, string title)
        {
            this.ItemID = itemID;
            this.Title = title;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("id")]
        [DefaultValue("")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        public virtual string ItemID
        {
            get
            {
                return (string)this.ViewState["ItemID"] ?? "";
            }
            set
            {
                this.ViewState["ItemID"] = value;
            }
        }

        /// <summary>
        /// Managed container id. It will be shown when tab is activated
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Description("Managed container id. It will be shown when tab is activated")]
        public virtual string ActionItemID
        {
            get
            {
                return (string)this.ViewState["ActionItemID"] ?? "";
            }
            set
            {
                this.ViewState["ActionItemID"] = value;
            }
        }

        private Component actionItem;

        /// <summary>
        /// Managed container. It will be shown when tab is activated
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Managed container. It will be shown when tab is activated")]
        public virtual Component ActionItem
        {
            get
            {
                return this.actionItem;
            }
            set
            {
                this.actionItem = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("actionItem")]
        [DefaultValue("")]
		[Description("")]
        protected virtual string ActionItemProxy
        {
            get
            {
                if (this.ActionItem != null)
                {
                    return this.ActionItem.ClientID;
                }

                if (this.ActionItemID.IsNotEmpty())
                {
                    Control ctrl = ControlUtils.FindControl(this.Owner, this.ActionItemID, true);

                    if (ctrl == null)
                    {
                        return this.ActionItemID;
                    }

                    return ctrl.ClientID;
                }

                return "";
            }
        }

        /// <summary>
        /// How the action item should be hidden. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. Component")]
        [DefaultValue(HideMode.Display)]
        [NotifyParentProperty(true)]
        [Description("How the action item. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display).")]
        public virtual HideMode HideMode
        {
            get
            {
                object obj = this.ViewState["HideMode"];
                return (obj == null) ? HideMode.Display : (HideMode)obj;
            }
            set
            {
                this.ViewState["HideMode"] = value;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        public virtual string Title
        {
            get
            {
                return (string)this.ViewState["Title"] ?? "";
            }
            set
            {
                this.ViewState["Title"] = value;
                this.SetTitle(value);
            }
        }

        /// <summary>
        ///  A string to be used as innerHTML (html tags are accepted) to show in a tooltip when mousing over the associated tab selector element. NOTE: TabTip config is used when a BoxComponent is a child of a TabPanel.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A string to be used as innerHTML (html tags are accepted) to show in a tooltip when mousing over the associated tab selector element. NOTE: TabTip config is used when a BoxComponent is a child of a TabPanel.")]
        public virtual string TabTip
        {
            get
            {
                return (string)this.ViewState["TabTip"] ?? "";
            }
            set
            {
                this.ViewState["TabTip"] = value;
            }
        }

        /// <summary>
        /// True to display the 'close' button and allow the user to close the tab, false to hide the button and disallow closing the tab (default to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Panels themselves do not directly support being closed, but some Panel subclasses do (like Ext.Window) or a Panel Class within an Ext.TabPanel. Specify true to enable closing in such situations. Defaults to false.")]
        public virtual bool Closable
        {
            get
            {
                object obj = this.ViewState["Closable"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Closable"] = value;
            }
        }

        /// <summary>
        /// Render this item hidden (default is false). If true, the hide method will be called internally.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Render this component hidden (default is false). If true, the hide method will be called internally.")]
        public virtual bool Hidden
        {
            get
            {
                object obj = this.ViewState["Hidden"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Hidden"] = value;
                this.SetHidden(value);
            }
        }

        /// <summary>
        /// The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [DefaultValue(Icon.None)]
        [Description("The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.")]
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
                this.SetIconCls(ResourceManager.GetIconClassName(value));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("iconCls")]
        [DefaultValue("")]
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
        /// A css class which sets a background image to be used as the icon for this button.
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class which sets a background image to be used as the icon for this button.")]
        public virtual string IconCls
        {
            get
            {
                return (string)this.ViewState["IconCls"] ?? "";
            }
            set
            {
                this.ViewState["IconCls"] = value;
                this.SetIconCls(value);
            }
        }

        private ConfigItemCollection customConfig;

        /// <summary>
        /// Collection of custom js config
        /// </summary>
        [Meta]
        [Category("2. Observable")]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="arg"></param>
        private void Call(string method, object arg)
        {
            if (!X.IsAjaxRequest)
            {
                return;
            }
            
            TabStrip tabStrip = this.Owner as TabStrip;

            if (tabStrip == null || !tabStrip.AllowCallbackScriptMonitoring)
            {
                return;
            }

            string item = this.ItemID.IsNotEmpty() ? JSON.Serialize(this.ItemID) : tabStrip.Items.IndexOf(this).ToString();
            tabStrip.AddScript("{0}.{1}({2}, {3});", this.Owner.ClientID, method, item, JSON.Serialize(arg));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        protected virtual void SetTitle(string title)
        {
            this.Call("setTabTitle", title);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hidden"></param>
        protected virtual void SetHidden(bool hidden)
        {
            this.Call("setTabHidden", hidden);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iconCls"></param>
        protected virtual void SetIconCls(string iconCls)
        {
            this.Call("setTabIconCls", iconCls);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class TabStripItems : StateManagedCollection<TabStripItem>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TabStripItem this[string id]
        {
            get
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].ItemID == id)
                    {
                        return this[i];
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int IndexOfID(string id)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].ItemID == id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
