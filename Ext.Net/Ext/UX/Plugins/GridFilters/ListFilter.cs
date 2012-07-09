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
using System.Web.UI.WebControls;
using System.Web.UI;
using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ListFilter : GridFilter
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. ListFilter")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override FilterType Type
        {
            get 
            { 
                return FilterType.List;
            }
        }

        /// <summary>
        /// The loading text displayed when data loading
        /// </summary>
        [ConfigOption]
        [Category("3. ListFilter")]
        [DefaultValue("Loading...")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("The loading text displayed when data loading")]
        public string LoadingText
        {
            get
            {
                object obj = this.ViewState["LoadingText"];
                return obj == null ? "Loading..." : (string)obj;
            }
            set
            {
                this.ViewState["LoadingText"] = value;
            }
        }

        /// <summary>
        /// If true then the data loading on show
        /// </summary>
        [ConfigOption]
        [Category("3. ListFilter")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("If true then the data loading on show")]
        public bool LoadOnShow
        {
            get
            {
                object obj = this.ViewState["LoadOnShow"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                this.ViewState["LoadOnShow"] = value;
            }
        }

        /// <summary>
        /// The list of options
        /// </summary>
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The list of options")]
        public virtual string[] Options
        {
            get
            {
                object obj = this.ViewState["Options"];
                return (obj == null) ? null : (string[])obj;
            }
            set
            {
                this.ViewState["Options"] = value;
            }
        }

        /// <summary>
        /// The list of options
        /// </summary>
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("The list of options")]
        public virtual string[] Value
        {
            get
            {
                object obj = this.ViewState["Value"];
                return (obj == null) ? null : (string[])obj;
            }
            set
            {
                this.ViewState["Value"] = value;
            }
        }

        /// <summary>
        /// The data store to use.
        /// </summary>
        [Meta]        
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [Description("The data store to use.")]
        public virtual string StoreID
        {
            get
            {
                return (string)this.ViewState["StoreID"] ?? "";
            }
            set
            {
                this.ViewState["StoreID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("text")]
        public virtual string LabelField
        {
            get
            {
                return (string)this.ViewState["LabelField"] ?? "text";
            }
            set
            {
                this.ViewState["LabelField"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("options", JsonMode.Raw)]
        [DefaultValue("")]
        protected internal string OptionsProxy
        {
            get
            {
                if (this.StoreID.IsEmpty() && this.Options != null && this.Options.Length > 0)
                {
                    return JSON.Serialize(this.Options);
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("store", JsonMode.Raw)]
        [DefaultValue("")]
        protected internal string StoreProxy
        {
            get
            {
                if (!this.StoreID.IsEmpty())
                {
                    return ControlUtils.FindControl(this.ParentGrid, this.StoreID).ClientID;
                }

                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("labelField")]
        [DefaultValue("text")]
        protected internal string LabelFieldProxy
        {
            get
            {
                if (!this.StoreID.IsEmpty())
                {
                    return this.LabelField;
                }

                return "text";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public void UpdateOptions(string[] options)
        {
            RequestManager.EnsureDirectEvent();

            if (this.ParentGrid != null)
            {
                this.ParentGrid.AddScript("{0}.getFilterPlugin().getFilter({1}).updateOptions({2});", this.ParentGrid.ClientID, JSON.Serialize(this.DataIndex), JSON.Serialize(options));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetValue(string[] value)
        {
            RequestManager.EnsureDirectEvent();

            if (this.ParentGrid != null)
            {
                this.ParentGrid.AddScript("{0}.getFilterPlugin().getFilter({1}).setValue({2});", this.ParentGrid.ClientID, JSON.Serialize(this.DataIndex), JSON.Serialize(value));
            }
        }
    }
}