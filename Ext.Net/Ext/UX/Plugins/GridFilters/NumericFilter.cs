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
using System.IO;
using System.Text;
using Newtonsoft.Json;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class NumericFilter : GridFilter
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. NumericFilter")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override FilterType Type
        {
            get 
            { 
                return FilterType.Numeric;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("3. NumericFilter")]
        [DefaultValue("Enter Filter Text...")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public string EmptyText
        {
            get
            {
                object obj = this.ViewState["EmptyText"];
                return obj == null ? "Enter Filter Text..." : (string)obj;
            }
            set
            {
                this.ViewState["EmptyText"] = value;
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [Category("3. NumericFilter")]
        [DefaultValue("")]
        [Description("Predefined filter value")]
        public virtual float? GreaterThanValue
        {
            get
            {
                object obj = this.ViewState["GreaterThanValue"];
                return (obj == null) ? null : (float?)obj;
            }
            set
            {
                this.ViewState["GreaterThanValue"] = value;
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [Category("3. NumericFilter")]
        [DefaultValue("")]
        [Description("Predefined filter value")]
        public virtual float? LessThanValue
        {
            get
            {
                object obj = this.ViewState["LessThanValue"];
                return (obj == null) ? null : (float?)obj;
            }
            set
            {
                this.ViewState["LessThanValue"] = value;
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [Category("3. NumericFilter")]
        [DefaultValue("")]
        [Description("Predefined filter value")]
        public virtual float? EqualValue
        {
            get
            {
                object obj = this.ViewState["EqualValue"];
                return (obj == null) ? null : (float?)obj;
            }
            set
            {
                this.ViewState["EqualValue"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("value", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string ValueProxy
        {
            get
            {
                if (this.GreaterThanValue.HasValue || this.LessThanValue.HasValue || this.EqualValue.HasValue)
                {
                    StringWriter sw = new StringWriter(new StringBuilder());
                    JsonTextWriter jw = new JsonTextWriter(sw);
                    jw.WriteStartObject();

                    if (this.GreaterThanValue.HasValue)
                    {
                        jw.WritePropertyName("gt");
                        jw.WriteValue(this.GreaterThanValue);
                    }

                    if (this.LessThanValue.HasValue)
                    {
                        jw.WritePropertyName("lt");
                        jw.WriteValue(this.LessThanValue);
                    }

                    if (this.EqualValue.HasValue)
                    {
                        jw.WritePropertyName("eq");
                        jw.WriteValue(this.EqualValue);
                    }
                    
                    jw.WriteEndObject();

                    return sw.GetStringBuilder().ToString();
                }

                return "";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetValue(float? greaterThanValue, float? lessThanValue)
        {
            RequestManager.EnsureDirectEvent();

            if (this.ParentGrid != null)
            {
                string value = "{gt:".ConcatWith(greaterThanValue.HasValue ? JSON.Serialize(greaterThanValue.Value) : "undefined",
                    ",lt:", lessThanValue.HasValue ? JSON.Serialize(lessThanValue.Value) : "undefined", "}");

                this.ParentGrid.AddScript("{0}.getFilterPlugin().getFilter({1}).setValue({2});", this.ParentGrid.ClientID, JSON.Serialize(this.DataIndex), value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetValue(float? eqValue)
        {
            RequestManager.EnsureDirectEvent();
            
            if (this.ParentGrid != null)
            {
                string value = "{eq:".ConcatWith(eqValue.HasValue ? JSON.Serialize(eqValue.Value) : "undefined", "}");
                this.ParentGrid.AddScript("{0}.getFilterPlugin().getFilter({1}).setValue({2});", this.ParentGrid.ClientID, JSON.Serialize(this.DataIndex), value);
            }
        }
    }
}
