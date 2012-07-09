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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class NumberColumn : Column
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public NumberColumn() { }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("xtype")]
        [DefaultValue("")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "numbercolumn";
            }
        }

        /// <summary>
        /// A formatting string as used by Ext.util.Format.number to format a numeric value for this Column (defaults to '0,000.00').
        /// Formats the number according to the format string.
        /// examples (123456.789):
        /// 0 - (123456) show only digits, no precision
        /// 0.00 - (123456.78) show only digits, 2 precision
        /// 0.0000 - (123456.7890) show only digits, 4 precision
        /// 0,000 - (123,456) show comma and digits, no precision
        /// 0,000.00 - (123,456.78) show comma and digits, 2 precision
        /// 0,0.00 - (123,456.78) shortcut method, show comma and digits, 2 precision
        /// To reverse the grouping (,) and decimal (.) for international numbers, add /i to the end. For example: 0.000,00/i
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. NumberColumn")]
        [DefaultValue("0,000.00")]
        [Description("A formatting string as used by Ext.util.Format.number to format a numeric value for this Column (defaults to '0,000.00').")]
        public virtual string Format
        {
            get
            {
                return (string)this.ViewState["Format"] ?? "0,000.00";
            }
            set
            {
                this.ViewState["Format"] = value;
            }
        }
    }
}