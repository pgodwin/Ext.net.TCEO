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

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public class ElementAnimationProperty
    {
        private object by;
        private object from;
        private object to;
        private string unit;

        /// <summary>
        /// relative change - start at current value, change by this value
        /// </summary>
        [Description("relative change - start at current value, change by this value")]
        public object By
        {
            get
            {
                return this.by;
            }
            set
            {
                this.by = value;
            }
        }

        /// <summary>
        /// ignore current value, start from this value
        /// </summary>
        [Description("ignore current value, start from this value")]
        public object From
        {
            get
            {
                return this.from;
            }
            set
            {
                this.from = value;
            }
        }

        /// <summary>
        /// start at current value, go to this value
        /// </summary>
        [Description("start at current value, go to this value")]
        public object To
        {
            get
            {
                return this.to;
            }
            set
            {
                this.to = value;
            }
        }

        /// <summary>
        /// any allowable unit specification
        /// </summary>
        [Description("any allowable unit specification")]
        public string Unit
        {
            get
            {
                return this.unit;
            }
            set
            {
                this.unit = value;
            }
        }
    }
}