/********
 * @version   : 1.0.0
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2011-06-15
 * @copyright : Copyright (c) 2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

using System.Text;
using System.Text.RegularExpressions;

namespace Ext.Net.Utilities
{
    public static class HtmlUtils
    {
        public static string StripWhitespaceChars(this string html)
        {
            return Regex.Replace(html, "[\n\r\t]", "");
        }
        
        public static string StripExtraSpaces(this string html)
        {
            return Regex.Replace(html, @"\s+", " ");
        }
    }
}