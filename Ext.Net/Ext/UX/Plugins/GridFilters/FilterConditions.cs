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
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

using Ext.Net.Utilities;
using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class FilterConditions
    {
        const string fieldPattern = @"f_([\d]+)_field";
        const string dataTypePattern = @"f_([\d]+)_data_type";
        const string dataComparisonPattern = @"f_([\d]+)_data_comparison";
        const string dataValuePattern = @"f_([\d]+)_data_value";

        private string filtersStr;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FilterConditions(string filtersStr)
        {
            this.filtersStr = filtersStr;
            this.ParseConditions();
        }

        private void ParseConditions()
        {
            XmlDocument xml = new XmlDocument();

            if (filtersStr.StartsWith("{"))
            {
                xml.LoadXml(JSON.DeserializeXmlNode("{filters:" + filtersStr + "}").OuterXml);                
            }
            else{
                xml.LoadXml("<filters>".ConcatWith(this.filtersStr, "</filters>"));
            }
            
           
            this.conditions = new FilterConditionCollection();

            foreach (XmlNode node in xml.SelectSingleNode("filters").ChildNodes)
            {
                string name = node.Name;

                int value;

                if (this.CheckPattern(fieldPattern, name, out value))
                {
                    FilterCondition condition = this.GetCondition(value);
                    condition.Name = node.InnerText;
                    continue;
                }

                if (this.CheckPattern(dataTypePattern, name, out value))
                {
                    FilterCondition condition = this.GetCondition(value);
                    condition.FilterType = (FilterType)Enum.Parse(typeof(FilterType), node.InnerText, true);
                    continue;
                }

                if (this.CheckPattern(dataComparisonPattern, name, out value))
                {
                    FilterCondition condition = this.GetCondition(value);
                    condition.Comparison = (Comparison)Enum.Parse(typeof(Comparison), node.InnerText, true);
                    continue;
                }

                if (this.CheckPattern(dataValuePattern, name, out value))
                {
                    FilterCondition condition = this.GetCondition(value);
                    condition.Value = node.InnerText; 

                    continue;
                }
            }

            this.conditions.Sort(delegate(FilterCondition x, FilterCondition y)
                                     {
                                         if (x == null)
                                         {
                                             return y == null ? 0 : -1;
                                         }
                                         else
                                         {
                                             return y == null ? 1 : x.Id.CompareTo(y.Id);
                                         }
                                     });
        }

        private FilterCondition GetCondition(int id)
        {
            foreach (FilterCondition condition in this.Conditions)
            {
                if (condition.Id == id)
                {
                    return condition;
                }
            }

            FilterCondition newCondition = new FilterCondition(id);
            this.conditions.Add(newCondition);

            return newCondition;
        }

        private bool CheckPattern(string pattern, string str, out int id)
        {
            id = -1;

            foreach (Match match in Regex.Matches(str, pattern))
            {
                if (match.Success)
                {
                    id = int.Parse(match.Groups[1].Value);
                    return true;
                }
            }

            return false;
        }

        private FilterConditionCollection conditions;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ReadOnlyCollection<FilterCondition> Conditions
        {
            get
            {
                if (conditions == null)
                {
                    conditions = new FilterConditionCollection();
                }

                return conditions.AsReadOnly();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class FilterConditionCollection : List<FilterCondition> { }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class FilterCondition
    {
        private int id;

        internal FilterCondition(int id)
        {
            this.id = id;
        }

        internal int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string fieldName;
        private FilterType filterType;
        private Comparison comparison = Comparison.Eq;
        private string value;
        private List<string> valuesList;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Name
        {
            get { return fieldName; }
            internal set { fieldName = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FilterType FilterType
        {
            get { return filterType; }
            internal set { filterType = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Comparison Comparison
        {
            get { return comparison; }
            internal set { comparison = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Value
        {
            get { return value; }
            internal set
            {
                if (this.FilterType == FilterType.List || this.value != null)
                {
                    if (this.valuesList == null)
                    {
                        this.valuesList = new List<string>();    
                    }

                    if (this.value != null)
                    {
                        this.valuesList.Add(this.value);
                        this.value = null;
                    }

                    this.valuesList.Add(value);
                    return;
                }
                this.value = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DateTime ValueAsDate
        {
            get
            {
                //IFormatProvider culture = new CultureInfo("en-US", true);
                //return DateTime.Parse(this.Value, culture);
                return DateTime.ParseExact(this.Value, "d", System.Threading.Thread.CurrentThread.CurrentUICulture);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DateTime ValueAsDateF(string format)
        {
            return DateTime.ParseExact(this.Value, format, System.Threading.Thread.CurrentThread.CurrentUICulture);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool ValueAsBoolean
        {
            get
            {
                if (this.Value == "1" || this.Value == "true" || this.Value == "True" || this.Value == "Yes" || this.Value == "yes")
                {
                    return true;
                }

                if (this.Value == "0" || this.Value == "false" || this.Value == "False" || this.Value == "No" || this.Value == "no")
                {
                    return false;
                }

                throw new ArgumentException("The value '".ConcatWith(this.Value, "' can not be parsed to bool"));
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int ValueAsInt
        {
            get
            {
                return int.Parse(this.Value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public double ValueAsDouble
        {
            get
            {
                IFormatProvider culture = new CultureInfo("en-US", true);
                return Double.Parse(this.Value, culture);
            }
        }

        
        //If int then return int
        //else if double then return double
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public object ValueAsNumeric
        {
            get
            {
                int vi;

                if (int.TryParse(this.Value, out vi))
                {
                    return vi;
                }

                return this.ValueAsDouble;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ReadOnlyCollection<string> ValuesList
        {
            get
            {
                if (this.FilterType != FilterType.List)
                {
                    throw new InvalidOperationException("The filter type is not List");
                }

                return this.valuesList.AsReadOnly();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum Comparison
    {
        /// <summary>
        /// 
        /// </summary>
        Eq,

        /// <summary>
        /// 
        /// </summary>
        Gt,

        /// <summary>
        /// 
        /// </summary>
        Lt
    }
    
}
