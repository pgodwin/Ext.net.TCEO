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
using System.Web.UI;
using System.Drawing;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Provides a convenient wrapper for normalized keyboard navigation. KeyNav allows you to bind navigation keys to function calls that will get called when the keys are pressed, providing an easy way to implement custom navigation schemes for any UI component.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:KeyNav runat=\"server\"></{0}:KeyNav>")]
    [ToolboxBitmap(typeof(KeyNav), "Build.ToolboxIcons.KeyMap.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Provides a convenient wrapper for normalized keyboard navigation. KeyNav allows you to bind navigation keys to function calls that will get called when the keys are pressed, providing an easy way to implement custom navigation schemes for any UI component.")]
    public partial class KeyNav : Observable
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public KeyNav() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.KeyNav";
            }
        }

        internal override string GetClientConstructor(bool instanceOnly, string body)
        {
            if (this.Target.IsEmpty())
            {
                throw new ArgumentNullException("Target", "The Target must defined for KeyNav control");
            }

            if (this.IsDefault)
            {
                return "";
            }

            this.InitOwer();

            string template = (instanceOnly) ? "new {1}(Ext.net.getEl({2}),{3})" : "this.{0}=new {1}(Ext.net.getEl({2}),{3});";

            return string.Format(template, this.ClientID,
                                           "Ext.KeyNav",
                                           this.TargetProxy,
                                           this.InitialConfig);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.Left.IsDefault
                       && this.Right.IsDefault
                       && this.Up.IsDefault
                       && this.Down.IsDefault
                       && this.PageDown.IsDefault
                       && this.PageUp.IsDefault
                       && this.Home.IsDefault
                       && this.End.IsDefault
                       && this.Tab.IsDefault
                       && this.Del.IsDefault
                       && this.Esc.IsDefault
                       && this.Enter.IsDefault;
            }
        }

        private void InitOwer()
        {
           this.Left.Owner = this;
           this.Right.Owner = this;
           this.Up.Owner = this;
           this.Down.Owner = this;
           this.PageDown.Owner = this;
           this.PageUp.Owner = this;
           this.Home.Owner = this;
           this.End.Owner = this;
           this.Tab.Owner = this;
           this.Del.Owner = this;
           this.Esc.Owner = this;
           this.Enter.Owner = this;
        }

        private string TargetProxy
        {
            get
            {
                string parsedTarget = TokenUtils.ParseTokens(this.Target, this);

                if (TokenUtils.IsRawToken(parsedTarget))
                {
                    return TokenUtils.ReplaceRawToken(parsedTarget);
                }

                return "\"".ConcatWith(parsedTarget, "\"");
            }
        }

        /// <summary>
        /// The element to bind to
        /// </summary>
        [Meta]
        [Category("3. KeyNav")]
        [DefaultValue("")]
        [Description("The element to bind to")]
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

        private JFunction left;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Left
        {
            get
            {
                if (this.left == null)
                {
                    this.left = new JFunction(null, "e");
                }

                return this.left;
            }
        }


        private JFunction right;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Right
        {
            get
            {
                if (this.right == null)
                {
                    this.right = new JFunction(null, "e");
                }

                return this.right;
            }
        }


        private JFunction up;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Up
        {
            get
            {
                if (this.up == null)
                {
                    this.up = new JFunction(null, "e");
                }

                return this.up;
            }
        }


        private JFunction down;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Down
        {
            get
            {
                if (this.down == null)
                {
                    this.down = new JFunction(null, "e");
                }

                return this.down;
            }
        }


        private JFunction pageUp;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction PageUp
        {
            get
            {
                if (this.pageUp == null)
                {
                    this.pageUp = new JFunction(null, "e");
                }

                return this.pageUp;
            }
        }


        private JFunction pageDown;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction PageDown
        {
            get
            {
                if (this.pageDown == null)
                {
                    this.pageDown = new JFunction(null, "e");
                }

                return this.pageDown;
            }
        }


        private JFunction del;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Del
        {
            get
            {
                if (this.del == null)
                {
                    this.del = new JFunction(null, "e");
                }

                return this.del;
            }
        }


        private JFunction home;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Home
        {
            get
            {
                if (this.home == null)
                {
                    this.home = new JFunction(null, "e");
                }

                return this.home;
            }
        }


        private JFunction end;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction End
        {
            get
            {
                if (this.end == null)
                {
                    this.end = new JFunction(null, "e");
                }

                return this.end;
            }
        }

        private JFunction enter;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Enter
        {
            get
            {
                if (this.enter == null)
                {
                    this.enter = new JFunction(null, "e");
                }

                return this.enter;
            }
        }


        private JFunction esc;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Esc
        {
            get
            {
                if (this.esc == null)
                {
                    this.esc = new JFunction(null, "e");
                }

                return this.esc;
            }
        }


        private JFunction tab;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("")]
        public JFunction Tab
        {
            get
            {
                if (this.tab == null)
                {
                    this.tab = new JFunction(null, "e");
                }

                return this.tab;
            }
        }

        /// <summary>
        /// The method to call on the Ext.EventObject after this KeyNav intercepts a key. Valid values are Ext.EventObject.stopEvent, Ext.EventObject.preventDefault and Ext.EventObject.stopPropagation (defaults to 'stopEvent')
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. KeyNav")]
        [DefaultValue(KeyEventAction.StopEvent)]
        [NotifyParentProperty(true)]
        [Description("The method to call on the Ext.EventObject after this KeyNav intercepts a key. Valid values are Ext.EventObject.stopEvent, Ext.EventObject.preventDefault and Ext.EventObject.stopPropagation (defaults to 'stopEvent')")]
        public virtual KeyEventAction DefaultEventAction
        {
            get
            {
                object obj = this.ViewState["DefaultEventAction"];
                return (obj == null) ? KeyEventAction.StopEvent : (KeyEventAction)obj;
            }
            set
            {
                this.ViewState["DefaultEventAction"] = value;
            }
        }

        /// <summary>
        /// True to disable this KeyNav instance (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. KeyNav")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [DirectEventUpdate(MethodName="SetDisabled")]
        [Description("True to disable this KeyNav instance (defaults to false)")]
        public virtual bool Disabled
        {
            get
            {
                object obj = this.ViewState["Disabled"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Disabled"] = value;
            }
        }

        /// <summary>
        /// Handle the keydown event instead of keypress (defaults to false). KeyNav automatically does this for IE since IE does not propagate special keys on keypress, but setting this to true will force other browsers to also handle keydown instead of keypress.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. KeyNav")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Handle the keydown event instead of keypress (defaults to false). KeyNav automatically does this for IE since IE does not propagate special keys on keypress, but setting this to true will force other browsers to also handle keydown instead of keypress.")]
        public virtual bool ForceKeyDown
        {
            get
            {
                object obj = this.ViewState["ForceKeyDown"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ForceKeyDown"] = value;
            }
        }

        /// <summary>
        /// The scope of the callback function
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. KeyNav")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The scope of the callback function")]
        public virtual string Scope
        {
            get
            {
                object obj = this.ViewState["Scope"];
                return (obj == null) ? "" : (string)obj;
            }
            set
            {
                this.ViewState["Scope"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disabled"></param>
        [Description("")]
        private void SetDisabled(bool disabled)
        {
            this.AddScript("{0}.{1}();", this.ClientID, disabled ? "disable" : "enable");
        }
    }
}