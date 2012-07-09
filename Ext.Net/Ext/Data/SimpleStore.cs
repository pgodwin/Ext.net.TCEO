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
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    [ToolboxItem(false)]
    class SimpleStore<T> : Store, ICustomConfigSerialization where T : StateManagedItem 
    {
        /// <summary>
        /// 
        /// </summary>
        public SimpleStore()
        {
        }

        XControl control;

        /// <summary>
        /// 
        /// </summary>
        public SimpleStore(XControl control, ListItemCollection<T> items)
        {
            this.control = control;
            this.items = items;
        }

        private ListItemCollection<T> items;
        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("")]
        public ListItemCollection<T> Items
        {
            get
            {
                if (this.items == null)
                {
                    this.items = new ListItemCollection<T>();
                }

                return this.items;
            }
            set
            {
                this.items = value;
            }
        }

        public override void AddScript(string script)
        {
            this.control.AddScript(script);
        }

        protected override void CallTemplate(ScriptPosition position, string template, string name, params object[] args)
        {
            StringBuilder sb = new StringBuilder();

            if (args != null && args.Length > 0)
            {
                foreach (object arg in args)
                {
                    sb.AppendFormat("{0},", JSON.Serialize(arg, JSON.AltConvertersInternal));
                }
            }

            string script = template.FormatWith(this.control.ClientID+".store", name, sb.ToString().LeftOfRightmostOf(','));

            switch (position)
            {
                case ScriptPosition.BeforeInit:
                    this.ResourceManager.RegisterBeforeClientInitScript(script);
                    break;
                case ScriptPosition.AfterInit:
                    this.ResourceManager.RegisterAfterClientInitScript(script);
                    break;
                default:
                    this.AddScript(script);
                    break;
            }
        }

         public override object DataSource
        {
            get
            {
                return this.Items;
            }
            set
            {
            }
        }

        public override void DataBind()
        {
            StringBuilder sb = new StringBuilder("[");

            if (this.Items != null && this.Items.Count > 0)
            {
                foreach (StateManagedItem item in this.Items)
                {
                    Ext.Net.ListItem li = (Ext.Net.ListItem)item;
                    sb.Append("[");
                    sb.Append(JSON.Serialize(li.Text));
                    sb.Append(",");
                    sb.Append(JSON.Serialize(li.Value));
                    sb.Append("],");
                }
                sb.Remove(sb.Length - 1, 1);
            }

            sb.Append("]");

            this.LoadData(new JRawValue(sb.ToString()));
        }
    
        #region ICustomConfigSerialization Members

        public string ToScript(System.Web.UI.Control owner)
        {
            //StringWriter sw = new StringWriter();
            //JsonTextWriter jw = new JsonTextWriter(sw);
            //ListItemCollectionJsonConverter converter = new ListItemCollectionJsonConverter();
            //converter.WriteJson(jw, this.Items, null);

            //return sw.GetStringBuilder().ToString();

            return "";
        }

        #endregion
    }
}