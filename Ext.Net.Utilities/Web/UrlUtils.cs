/********
 * @version   : 1.0.0
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2011-06-15
 * @copyright : Copyright (c) 2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/

namespace Ext.Net.Utilities
{
    public class UrlUtils
    {
        public static bool IsUrl(string url)
        {
            return (!string.IsNullOrEmpty(url) && url.IndexOf("://") >= 0);
        }
    }
}
