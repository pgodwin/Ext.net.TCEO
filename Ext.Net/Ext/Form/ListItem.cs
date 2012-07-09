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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class ListItem : StateManagedItem
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public ListItem() { }

        private XControl parent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        [Description("")]
        public ListItem(string text)
        {
            this.Text = text;
            this.Value = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        [Description("")]
        public ListItem(string text, string value)
        {
            this.Value = value;
            this.Text = text;
        }
        
        internal ListItem(XControl parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public string Text
        {
            get
            {
                return (string)this.ViewState["Text"] ?? "";
            }
            set
            {
                string oldValue = this.Text;
                this.ViewState["Text"] = value;

                if (this.Value.IsEmpty() || oldValue == this.Value)
                {
                    this.Value = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue(null)]
        [NotifyParentProperty(true)]
        [Description("")]
        public string Value
        {
            get
            {
                return (string)this.ViewState["Value"] ?? null;
            }
            set
            {
                this.ViewState["Value"] = value;
                this.SetValue(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        [Description("")]
        protected void SetValue(string value)
        {
            if (parent != null && parent.AllowCallbackScriptMonitoring && RequestManager.IsAjaxRequest)
            {
                parent.Call("setValue", value);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Description("")]
    public partial class ListItemCollection<T> : StateManagedCollection<T> where T : StateManagedItem { }
}
