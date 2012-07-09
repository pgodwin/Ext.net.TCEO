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
using System.Drawing;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Handles mapping keys to actions for an element.
    /// </summary>
    [Meta]
    [DefaultProperty("Keys")]
    [ParseChildren(true, "Keys")]
    [ToolboxData("<{0}:KeyMap runat=\"server\"></{0}:KeyMap>")]
    [ToolboxBitmap(typeof(KeyMap), "Build.ToolboxIcons.KeyMap.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Handles mapping keys to actions for an element.")]
    public partial class KeyMap : Observable
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public KeyMap() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.KeyMap";
            }
        }

        internal override string GetClientConstructor(bool instanceOnly, string body)
        {
            if (this.Target.IsEmpty())
            {
                throw new ArgumentNullException("Target", "The Target must defined for KeyMap control");
            }

            if (this.Keys.Count == 0)
            {
                return "";
            }

            string template = (instanceOnly) ? "new {1}(Ext.net.getEl({2}),{3}{4})" : "this.{0}=new {1}(Ext.net.getEl({2}),{3}{4});";

            return string.Format(template, this.ClientID,
                                           "Ext.KeyMap", 
                                           this.TargetProxy,
                                           this.KeysProxy, 
                                           this.EventName.IsEmpty() ? "" : "," + this.EventName);
        }

        private KeyBindingCollection keys;

        /// <summary>
        /// A KeyMap config object (in the format expected by Ext.KeyMap.addBinding used to assign custom key handling to this panel (defaults to null).
        /// </summary>
        [Meta]
        [ConfigOption("keys", JsonMode.Array)]
        [Category("3. KeyMap")]
        [NotifyParentProperty(true)]
        [ViewStateMember]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [Description("A KeyMap config object (in the format expected by Ext.KeyMap.addBinding used to assign custom key handling to this panel (defaults to null).")]
        public virtual KeyBindingCollection Keys
        {
            get
            {
                if (this.keys == null)
                {
                    this.keys = new KeyBindingCollection();
                    this.keys.AfterItemAdd += this.AfterKeyBindingAdd;
                }

                return this.keys;
            }
        }

        private string KeysProxy
        {
            get
            {
                if (this.Keys.Count == 1)
                {
                    return new ClientConfig().SerializeInternal(this.Keys[0], this);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    bool comma = false;
                    sb.Append("[");

                    foreach (KeyBinding keyBinding in this.Keys)
                    {
                        if (comma)
                        {
                            sb.Append(",");
                        }

                        sb.Append(new ClientConfig().SerializeInternal(keyBinding, this));

                        comma = true;
                    }
                    sb.Append("]");

                    return sb.ToString();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyBinding"></param>
        [Description("")]
        protected virtual void AfterKeyBindingAdd(KeyBinding keyBinding)
        {
            keyBinding.Owner = this;
            keyBinding.Listeners.Event.Owner = this;
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
        [Category("3. KeyMap")]
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

        /// <summary>
        /// (optional) The event to bind to (defaults to 'keydown')
        /// </summary>
        [Meta]
        [Category("3. KeyMap")]
        [DefaultValue("")]
        [Description("(optional) The event to bind to (defaults to 'keydown')")]
        public virtual string EventName
        {
            get
            {
                return (string)this.ViewState["EventName"] ?? "";
            }
            set
            {
                this.ViewState["EventName"] = value;
            }
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public void Enable()
        {
            this.Call("enable");
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public void Disable()
        {
            this.Call("disable");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyBinding"></param>
        [Meta]
        [Description("")]
        public void AddKeyBinding(KeyBinding keyBinding)
        {
            RequestManager.EnsureDirectEvent();

            this.Call("addBinding", new JRawValue(new ClientConfig().SerializeInternal(keyBinding, this)));
        }
    }
}