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
using System.IO;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class DateFilter : GridFilter
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("3. DateFilter")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override FilterType Type
        {
            get 
            { 
                return FilterType.Date;
            }
        }

        /// <summary>
        /// The text displayed for the 'Before' menu item
        /// </summary>
        [ConfigOption]
        [Category("3. DateFilter")]
        [DefaultValue("Before")]
        [NotifyParentProperty(true)]
        [Description("The text displayed for the 'Before' menu item")]
        public string BeforeText
        {
            get
            {
                object obj = this.ViewState["BeforeText"];
                return obj == null ? "Before" : (string)obj;
            }
            set
            {
                this.ViewState["BeforeText"] = value;
            }
        }

        /// <summary>
        /// The text displayed for the 'After' menu item
        /// </summary>
        [ConfigOption]
        [Category("3. DateFilter")]
        [DefaultValue("After")]
        [NotifyParentProperty(true)]
        [Description("The text displayed for the 'After' menu item")]
        public string AfterText
        {
            get
            {
                object obj = this.ViewState["AfterText"];
                return obj == null ? "After" : (string)obj;
            }
            set
            {
                this.ViewState["AfterText"] = value;
            }
        }

        /// <summary>
        /// The text displayed for the 'On' menu item
        /// </summary>
        [ConfigOption]
        [Category("3. DateFilter")]
        [DefaultValue("On")]
        [Localizable(true)]
        [NotifyParentProperty(true)]
        [Description("The text displayed for the 'On' menu item")]
        public virtual string OnText
        {
            get
            {
                object obj = this.ViewState["OnText"];
                return obj == null ? "On" : (string)obj;
            }
            set
            {
                this.ViewState["OnText"] = value;
            }
        }

        /// <summary>
        /// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'd').
        /// </summary>
        [Meta]
        [Category("8. DateField")]
        [DefaultValue("d")]
        [Description("The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'd').")]
        public virtual string Format
        {
            get
            {
                return (string)this.ViewState["Format"] ?? "d";
            }
            set
            {
                this.ViewState["Format"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("dateFormat")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string FormatProxy
        {
            get
            {
                return DateTimeUtils.ConvertNetToPHP(this.Format);
            }
        }

        private DatePickerOptions pickerOptions;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("pickerOpts", JsonMode.Object)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public DatePickerOptions DatePickerOptions
        {
            get
            {
                if (pickerOptions == null)
                {
                    pickerOptions = new DatePickerOptions();
                }

                return pickerOptions;
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [Category("3. DateFilter")]
        [DefaultValue(null)]
        [Description("Predefined filter value")]
        public virtual DateTime? BeforeValue
        {
            get
            {
                object obj = this.ViewState["BeforeValue"];
                return (obj == null) ? null : (DateTime?)obj;
            }
            set
            {
                this.ViewState["BeforeValue"] = value;
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [Category("3. DateFilter")]
        [DefaultValue(null)]
        [Description("Predefined filter value")]
        public virtual DateTime? AfterValue
        {
            get
            {
                object obj = this.ViewState["AfterValue"];
                return (obj == null) ? null : (DateTime?)obj;
            }
            set
            {
                this.ViewState["AfterValue"] = value;
            }
        }

        /// <summary>
        /// Predefined filter value
        /// </summary>
        [Category("3. DateFilter")]
        [DefaultValue(null)]
        [Description("Predefined filter value")]
        public virtual DateTime? OnValue
        {
            get
            {
                object obj = this.ViewState["OnValue"];
                return (obj == null) ? null : (DateTime?)obj;
            }
            set
            {
                this.ViewState["OnValue"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetValue(DateTime? afterValue, DateTime? beforeValue)
        {
            RequestManager.EnsureDirectEvent();

            if (this.ParentGrid != null)
            {
                string value = "{before:".ConcatWith(beforeValue.HasValue ? DateTimeUtils.DateNetToJs(beforeValue.Value) : "undefined",
                    ",after:", afterValue.HasValue ? DateTimeUtils.DateNetToJs(afterValue.Value) : "undefined", "}");

                this.ParentGrid.AddScript("{0}.getFilterPlugin().getFilter({1}).setValue({2});", this.ParentGrid.ClientID, JSON.Serialize(this.DataIndex), value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetValue(DateTime? onValue)
        {
            RequestManager.EnsureDirectEvent();

            if (this.ParentGrid != null)
            {
                string value = "{on:".ConcatWith(onValue.HasValue ? DateTimeUtils.DateNetToJs(onValue.Value) : "undefined", "}");

                this.ParentGrid.AddScript("{0}.getFilterPlugin().getFilter({1}).setValue({2});", this.ParentGrid.ClientID, JSON.Serialize(this.DataIndex), value);
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("value", JsonMode.Raw)]
        [DefaultValue("")]
        protected string ValueProxy
        {
            get
            {
                if (this.BeforeValue.HasValue || this.AfterValue.HasValue || this.OnValue.HasValue)
                {
                    StringWriter sw = new StringWriter(new StringBuilder());
                    JsonTextWriter jw = new JsonTextWriter(sw);
                    jw.WriteStartObject();

                    if (this.BeforeValue.HasValue)
                    {
                        jw.WritePropertyName("before");
                        jw.WriteRawValue(DateTimeUtils.DateNetToJs(this.BeforeValue.Value));
                    }

                    if (this.AfterValue.HasValue)
                    {
                        jw.WritePropertyName("after");
                        jw.WriteRawValue(DateTimeUtils.DateNetToJs(this.AfterValue.Value));
                    }

                    if (this.OnValue.HasValue)
                    {
                        jw.WritePropertyName("on");
                        jw.WriteRawValue(DateTimeUtils.DateNetToJs(this.OnValue.Value));
                    }
                    
                    jw.WriteEndObject();

                    return sw.GetStringBuilder().ToString();
                }

                return "";
            }
        }
    }
}