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

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public abstract partial class ComboBoxBaseSingle<T> : ComboBoxBase<T> where T : StateManagedItem
    {
        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override object Value
        {
            get
            {
                return this.SelectedItem.Value;
            }
            set
            {
                this.SelectedItem.Value = value == null ? null : value.ToString();
            }
        }

        private ListItem selectedItem;

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [DefaultValue(null)]
        [Description("")]
        public virtual ListItem SelectedItem
        {
            get
            {
                if (this.selectedItem == null)
                {
                    this.selectedItem = new ListItem(this);
                }

                return this.selectedItem;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("8. ComboBox")]
        [DirectEventUpdate(MethodName = "SetSelectedIndex")]
        [DefaultValue(-1)]
        [Description("")]
        public virtual int SelectedIndex
        {
            get
            {
                object obj = this.ViewState["SelectedIndex"];
                return (obj == null) ? -1 : (int)obj;
            }
            set
            {
                this.ViewState["SelectedIndex"] = value;
            }
        }
		
        /// <summary>
        /// 
        /// </summary>
		[ConfigOption("initSelectedIndex")]
        [DefaultValue(-1)]
        [Description("")]
        protected virtual int SelectedIndexProperty
        {
            get
            {
                if (string.IsNullOrEmpty(this.SelectedItem.Value))
                {
                    return this.SelectedIndex;
                }

                return -1;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        [Description("")]
        protected virtual void SetSelectedIndex(int index)
        {
            this.Call("selectByIndex", index);
        }
    }
}