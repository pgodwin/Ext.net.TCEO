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
    [Meta]
    [Description("")]
    public abstract partial class SplitButtonBase : ButtonBase
    {
        /// <summary>
        /// A function called when the arrow button is clicked (can be used instead of click event).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("6. SplitButton")]
        [DefaultValue("")]
        [Description("A function called when the arrow button is clicked (can be used instead of click event).")]
        public virtual string ArrowHandler
        {
            get
            {
                return (string)this.ViewState["ArrowHandler"] ?? "";
            }
            set
            {
                this.ViewState["ArrowHandler"] = value;
            }
        }

        /// <summary>
        /// The title attribute of the arrow.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("6. SplitButton")]
        [DefaultValue("")]
        [Description("The title attribute of the arrow.")]
        public virtual string ArrowTooltip
        {
            get
            {
                return (string)this.ViewState["ArrowTooltip"] ?? "";
            }
            set
            {
                this.ViewState["ArrowTooltip"] = value;
            }
        }
    }
}