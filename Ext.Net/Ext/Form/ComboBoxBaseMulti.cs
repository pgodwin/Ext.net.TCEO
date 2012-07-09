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
    public abstract partial class ComboBoxBaseMulti<T> : ComboBoxBase<T> where T : StateManagedItem
    {
        /// <summary>
        /// The delimiter of selected items
        /// </summary>
        [ConfigOption]
        [Category("8. MultiCombo")]
        [DefaultValue(",")]
        [Description("The delimiter of selected items.")]
        public virtual string Delimiter
        {
            get
            {
                return (string)this.ViewState["Delimiter"] ?? ",";
            }
            set
            {
                this.ViewState["Delimiter"] = value;
            }
        }

        /// <summary>
        /// True to wrap by square brackets.
        /// </summary>
        [ConfigOption]
        [Category("8. MultiCombo")]
        [DefaultValue(false)]
        [Description("True to wrap by square brackets.")]
        public virtual bool WrapBySquareBrackets
        {
            get
            {
                object obj = this.ViewState["WrapBySquareBrackets"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["WrapBySquareBrackets"] = value;
            }
        }

        /// <summary>
        /// Selection UI mode
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("8. MultiCombo")]
        [DefaultValue(MultiSelectMode.Checkbox)]
        [Description("Selection UI mode")]
        public virtual MultiSelectMode SelectionMode
        {
            get
            {
                object obj = this.ViewState["SelectionMode"];
                return (obj == null) ? MultiSelectMode.Checkbox : (MultiSelectMode)obj;
            }
            set
            {
                this.ViewState["SelectionMode"] = value;
            }
        }
        
        private SelectedListItemCollection selectedItems;

		/// <summary>
		/// 
		/// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
		[Description("")]
        public SelectedListItemCollection SelectedItems
        {
            get
            {
                if (this.selectedItems == null)
                {
                    this.selectedItems = new SelectedListItemCollection();
                }

                return this.selectedItems;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void UpdateSelection()
        {
            if (this.SelectedItems.Count == 0)
            {
                this.Call("clearValue");
            }
            else
            {
                this.Call("initSelection", new JRawValue(this.SelectedItems.ToJsonArray()));
            }
        }
    }
}