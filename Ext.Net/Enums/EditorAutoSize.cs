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
    /// Size for the editor to automatically adopt the size of the underlying field, "Width" to adopt the width only, or "Height" to adopt the height only (defaults to Disable)
    /// </summary>
    public enum EditorAutoSize
    {
        /// <summary>
        /// Disable auto size
        /// </summary>
        Disable,
        /// <summary>
        /// Fits the editor to automatically adopt the size of the underlying field
        /// </summary>
        Fit,
        /// <summary>
        /// "Width" to adopt the width only
        /// </summary>
        Width,
        /// <summary>
        /// "Height" to adopt the height only
        /// </summary>
        Height
    }
}