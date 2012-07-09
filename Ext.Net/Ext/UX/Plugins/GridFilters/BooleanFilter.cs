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

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class BooleanFilter : GridFilter
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. BooleanFilter")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override FilterType Type
        {
            get 
            {
                return FilterType.Boolean;
            }
        }

        /// <summary>
        /// The text displayed for the 'Yes' checkbox
        /// </summary>
        [ConfigOption]
        [Category("3. BooleanFilter")]
        [DefaultValue("Yes")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("The text displayed for the 'Yes' checkbox")]
        public string YesText
        {
            get
            {
                object obj = this.ViewState["YesText"];
                return obj == null ? "Yes" : (string)obj;
            }
            set
            {
                this.ViewState["YesText"] = value;
            }
        }

        /// <summary>
        /// The text displayed for the 'No' checkbox
        /// </summary>
        [ConfigOption]
        [Category("3. BooleanFilter")]
        [DefaultValue("No")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("The text displayed for the 'No' checkbox")]
        public string NoText
        {
            get
            {
                object obj = this.ViewState["NoText"];
                return obj == null ? "No" : (string)obj;
            }
            set
            {
                this.ViewState["NoText"] = value;
            }
        }

        /// <summary>
        /// The default value of this filter (defaults to false)
        /// </summary>
        [ConfigOption]
        [Category("3. BooleanFilter")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("The default value of this filter (defaults to false)")]
        public bool DefaultValue
        {
            get
            {
                object obj = this.ViewState["DefaultValue"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                this.ViewState["DefaultValue"] = value;
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [ConfigOption]
        [Category("3. BooleanFilter")]
        [DefaultValue(null)]
        [Description("Predefined filter value")]
        public virtual bool? Value
        {
            get
            {
                object obj = this.ViewState["Value"];
                return (obj == null) ? null : (bool?)obj;
            }
            set
            {
                this.ViewState["Value"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetValue(bool? value)
        {
            RequestManager.EnsureDirectEvent();

            if (this.ParentGrid != null)
            {
                this.ParentGrid.AddScript("{0}.getFilterPlugin().getFilter({1}).setValue({2});", this.ParentGrid.ClientID, JSON.Serialize(this.DataIndex), JSON.Serialize(value));
            }
        }
    }
}
