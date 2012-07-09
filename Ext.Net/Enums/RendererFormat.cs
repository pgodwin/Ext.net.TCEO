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

namespace Ext.Net
{
	/// <summary>
    /// Reusable data formatting functions
	/// </summary>
    public enum RendererFormat
	{
        /// <summary>
        /// 
        /// </summary>
        None,

		/// <summary>
        /// Converts the first character only of a string to upper case
		/// </summary>
        Capitalize,
        
        /// <summary>
        /// Parse a value into a formatted date using the specified format pattern.
        /// </summary>
        Date,
        
        /// <summary>
        /// Returns a date rendering function that can be reused to apply a date format multiple times efficiently
        /// format : String
        /// (optional) Any valid date format string (defaults to 'm/d/Y')
        /// </summary>
        DateRenderer,
        
        /// <summary>
        /// Checks a reference and converts it to the default value if it's empty
        /// </summary>
        DefaultValue,
        
        /// <summary>
        /// Truncate a string and add an ellipsis ('...') to the end if it exceeds the specified length
        /// defaultValue : String
        /// The value to insert of it's undefined (defaults to "")
        /// </summary>
        Ellipsis,
		
        /// <summary>
        /// Simple format for a file size (xxx bytes, xxx KB, xxx MB)
        /// length : Number
        /// The maximum length to allow before truncating
        /// word : Boolean
        /// True to try to find a common work break
		/// </summary>
        FileSize,
        
        /// <summary>
        /// Convert certain characters (&, &lt;, >, and ') from their HTML character equivalents.
        /// </summary>
        HtmlDecode,
        
        /// <summary>
        /// Convert certain characters (&, &lt;, >, and ') to their HTML character equivalents for literal display in web pages.
        /// </summary>
        HtmlEncode,
        
        /// <summary>
        /// Converts newline characters to the HTML tag &lt;br/>
        /// </summary>
        Nl2br,
        
        /// <summary>
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
        Number,
        
        /// <summary>
        /// Returns a number rendering function that can be reused to apply a number format multiple times efficiently
        /// </summary>
        NumberRenderer,
        
        /// <summary>
        /// Converts a string to all lower case letters
        /// </summary>
        Lowercase,
        
        /// <summary>
        /// Selectively do a plural form of a word based on a numeric value. For example, in a template, {commentCount:plural("Comment")} would result in "1 Comment" if commentCount was 1 or would be "x Comments" if the value is 0 or greater than 1.
        /// </summary>
        Plural,
        
        /// <summary>
        /// Rounds the passed number to the required decimal precision.
        /// singular : String
        /// The singular form of the word
        /// plural : String
        /// (optional) The plural form of the word (defaults to the singular with an "s")
        /// </summary>
        Round,
        
        /// <summary>
        /// Strips all script tags
        /// precision : Number
        /// The number of decimal places to which to round the first parameter's value.
        /// </summary>
        StripScripts,
        
        /// <summary>
        /// Strips all HTML tags
        /// </summary>
        StripTags,
        
        /// <summary>
        /// Returns a substring from within an original string
        /// </summary>
        Substr,
        
        /// <summary>
        /// Trims any whitespace from either side of a string
        /// start : Number
        /// The start index of the substring
        /// length : Number
        /// The length of the substring
        /// </summary>
        Trim,
        
        /// <summary>
        /// Checks a reference and converts it to empty string if it is undefined
        /// </summary>
        Undef,
        
        /// <summary>
        /// Converts a string to all upper case letters
        /// </summary>
        Uppercase,
        
        /// <summary>
        /// Format a number as US currency
        /// </summary>
        UsMoney,

        /// <summary>
        /// Format a number as Euro currency
        /// </summary>
        EuroMoney
	}
}