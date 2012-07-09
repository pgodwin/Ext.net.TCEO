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
using System.ComponentModel;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Provides a convenient wrapper for TextFields that adds a clickable trigger button (looks like a combobox by default). The trigger has no default action, so you must assign a function to implement the trigger click handler by overriding onTriggerClick. You can create a TriggerField directly, as it renders exactly like a combobox for which you can provide a custom implementation.
    /// </summary>
    [Meta]
    [Description("Provides a convenient wrapper for TextFields that adds a clickable trigger button (looks like a combobox by default). The trigger has no default action, so you must assign a function to implement the trigger click handler by overriding onTriggerClick. You can create a TriggerField directly, as it renders exactly like a combobox for which you can provide a custom implementation.")]
    public abstract partial class TriggerFieldBase : TextFieldBase
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "trigger";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            this.RegisterIcons();
            base.OnPreRender(e);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual void RegisterIcons()
        {
            if (!Ext.Net.X.IsAjaxRequest || this.IsDynamic)
            {
                this.RegisterIcon(this.TriggerIcon);

                foreach (FieldTrigger trigger in this.Triggers)
                {
                    this.RegisterIcon(trigger.Icon);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public void RegisterIcon(TriggerIcon icon)
        {
            TriggerFieldBase.RegisterTriggerIcon(icon);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected static void RegisterTriggerIcon(TriggerIcon icon)
        {
            if (icon == TriggerIcon.Combo ||
                icon == TriggerIcon.Clear ||
                icon == TriggerIcon.Date ||
                icon == TriggerIcon.Search ||
                HttpContext.Current == null)
            {
                return;
            }

            ResourceManager rm = ResourceManager.GetInstance(HttpContext.Current);
            if (rm == null)
            {
                return;
            }

            string iconName = icon.ToString();
            string key = "x-form-".ConcatWith(iconName.ToLower(), "-trigger");
            if (rm.IsClientStyleBlockRegistered(key))
            {
                return;
            }

            string urlName = iconName.ToCharacterSeparatedFileName('-', "gif");
            if (rm.Theme != Theme.Default && (icon == Net.TriggerIcon.Ellipsis || icon == Net.TriggerIcon.Empty))
            {
                urlName = string.Concat(rm.Theme.ToString().ToLowerInvariant(), ".", urlName);
            }

            string url = rm.GetWebResourceUrl(string.Format(ResourceManager.ASSEMBLYSLUG + ".ux.extensions.triggerfield.images.{0}", urlName));
            string url1 = "";
            string css = ".x-form-field-wrap .{0}{{background-image:url({1});cursor:pointer;}}";

            if (!RequestManager.IsWebKit && iconName.StartsWith("Simple"))
            {
                url1 = rm.GetWebResourceUrl(string.Format(ResourceManager.ASSEMBLYSLUG + ".ux.extensions.triggerfield.images.{0}", iconName.ToCharacterSeparatedFileName('-', "").ConcatWith("-small.gif")));
                css += " .x-small-editor .x-form-field-wrap .{0}{{background-image:url({2});cursor:pointer;}}";
            }

            if (Ext.Net.X.IsAjaxRequest)
            {
                //CSS.CreateStyleSheet(css.FormatWith(key, url, url1), key);
                rm.AddScript("Ext.net.ResourceMgr.registerCssClass({0}, {1});", JSON.Serialize(key), JSON.Serialize(css.FormatWith(key, url, url1)));
            }
            else
            {
                rm.RegisterClientStyleBlock(key, css.FormatWith(key, url, url1));
            }
        }

        private FieldTrigerCollection triggers;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("triggersConfig", JsonMode.AlwaysArray)]
        [Category("8. ComboBox")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual FieldTrigerCollection Triggers
        {
            get
            {
                if (this.triggers == null)
                {
                    this.triggers = new FieldTrigerCollection();
                }

                return this.triggers;
            }
        }

        /// <summary>
        /// True to hide the trigger element and display only the base text field (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. TriggerField")]
        [DefaultValue(false)]
        [DirectEventUpdate(MethodName = "SetHideTrigger")]
        [Description("True to hide the trigger element and display only the base text field (defaults to false).")]
        public virtual bool HideTrigger
        {
            get
            {
                object obj = this.ViewState["HideTrigger"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideTrigger"] = value;
            }
        }

        /// <summary>
        /// False to prevent the user from typing text directly into the field, the field will only respond to a click on the trigger to set the value. (defaults to true).
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetEditable")]
        [ConfigOption]
        [Category("6. TriggerField")]
        [Bindable(true)]
        [DefaultValue(true)]
        [Description("False to prevent the user from typing text directly into the field, the field will only respond to a click on the trigger to set the value. (defaults to true).")]
        public virtual bool Editable
        {
            get
            {
                object obj = this.ViewState["Editable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Editable"] = value;
            }
        }

        /// <summary>
        /// True to show base trigger first
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. TriggerField")]
        [DefaultValue(false)]
        [Description("True to show base trigger first")]
        public virtual bool FirstBaseTrigger
        {
            get
            {
                object obj = this.ViewState["FirstBaseTrigger"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["FirstBaseTrigger"] = value;
            }
        }

        /// <summary>
        /// A CSS class to apply to the trigger.
        /// </summary>
        [Meta]
        [Category("7. TriggerField")]
        [DefaultValue("")]
        [Description("A CSS class to apply to the trigger.")]
        public virtual string TriggerClass
        {
            get
            {
                return (string)this.ViewState["TriggerClass"] ?? "";
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
        [Category("Config Options")]
        [DefaultValue(Net.TriggerIcon.Combo)]
        [Description("The icon to use in the trigger.")]
        public virtual TriggerIcon TriggerIcon
        {
            get
            {
                object obj = this.ViewState["TriggerIcon"];
                return (obj == null) ? TriggerIcon.Combo : (TriggerIcon)obj;
            }
            set
            {
                this.ViewState["TriggerIcon"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("triggerClass")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string TriggerIconClsProxy
        {
            get
            {
                if (this.TriggerIcon != TriggerIcon.Combo)
                {
                    return "x-form-".ConcatWith(this.TriggerIcon.ToString().ToLower(), "-trigger");
                }

                return this.TriggerClass;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetHideTrigger(bool hide)
        {
            this.AddScript("{0}.trigger.setDisplayed({1});", this.ClientID, JSON.Serialize(!hide));
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void SetEditable(bool value)
        {
            this.Call("setEditable", value);
        }

        /// <summary>
        /// Show a trigger
        /// </summary>
        /// <param name="index"></param>
        [Meta]
        [Description("Show a trigger")]
        public virtual void ShowTrigger(int index)
        {
            RequestManager.EnsureDirectEvent();
            this.Triggers[index].HideTrigger = false;

            string template = "{0}.triggers[{1}].show();";
            this.AddScript(template, this.ClientID, index);
        }

        /// <summary>
        /// Hide a trigger
        /// </summary>
        /// <param name="index"></param>
        [Meta]
        [Description("Hide a trigger")]
        public virtual void ConcealTrigger(int index)
        {
            RequestManager.EnsureDirectEvent();
            this.Triggers[index].HideTrigger = true;

            string template = "{0}.triggers[{1}].hide();";
            this.AddScript(template, this.ClientID, index);
        }
    }
}