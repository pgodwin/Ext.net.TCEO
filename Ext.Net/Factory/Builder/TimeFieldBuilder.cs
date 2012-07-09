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
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    public partial class TimeField
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : ComboBox.Builder<TimeField, TimeField.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TimeField()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TimeField component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TimeField.Config config) : base(new TimeField(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TimeField component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The fields null value.
			/// </summary>
            public virtual TimeField.Builder EmptyValue(object emptyValue)
            {
                this.ToComponent().EmptyValue = emptyValue;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TimeField.Builder SelectedTime(TimeSpan selectedTime)
            {
                this.ToComponent().SelectedTime = selectedTime;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TimeField.Builder SelectedValue(object selectedValue)
            {
                this.ToComponent().SelectedValue = selectedValue;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TimeField.Builder Value(object value)
            {
                this.ToComponent().Value = value;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// Multiple date formats separated by \" | \" to try when parsing a user input value and it doesn't match the defined format (defaults to 'm/d/Y|m-d-y|m-d-Y|m/d|m-d|d').
			/// </summary>
            public virtual TimeField.Builder AltFormats(string altFormats)
            {
                this.ToComponent().AltFormats = altFormats;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'h:mm tt', e.g., '3:15 PM'). For 24-hour time format try 'H:mm' instead.
			/// </summary>
            public virtual TimeField.Builder Format(string format)
            {
                this.ToComponent().Format = format;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// The number of minutes between each time value in the list (defaults to 15).
			/// </summary>
            public virtual TimeField.Builder Increment(int increment)
            {
                this.ToComponent().Increment = increment;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// The error text to display when the time is after maxValue (defaults to 'The time in this field must be equal to or before {0}').
			/// </summary>
            public virtual TimeField.Builder MaxText(string maxText)
            {
                this.ToComponent().MaxText = maxText;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// The maximum allowed time. Can be either a Javascript date object or a string date in a valid format (defaults to null).
			/// </summary>
            public virtual TimeField.Builder MaxTime(TimeSpan maxTime)
            {
                this.ToComponent().MaxTime = maxTime;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// The minimum allowed time. Can be either a Javascript date object or a string date in a valid format (defaults to null).
			/// </summary>
            public virtual TimeField.Builder MinTime(TimeSpan minTime)
            {
                this.ToComponent().MinTime = minTime;
                return this as TimeField.Builder;
            }
             
 			/// <summary>
			/// The error text to display when the date in the cell is before minValue (defaults to 'The time in this field must be equal to or after {0}').
			/// </summary>
            public virtual TimeField.Builder MinText(string minText)
            {
                this.ToComponent().MinText = minText;
                return this as TimeField.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeField.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TimeField(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TimeField.Builder TimeField()
        {
            return this.TimeField(new TimeField());
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeField.Builder TimeField(TimeField component)
        {
            return new TimeField.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TimeField.Builder TimeField(TimeField.Config config)
        {
            return new TimeField.Builder(new TimeField(config));
        }
    }
}