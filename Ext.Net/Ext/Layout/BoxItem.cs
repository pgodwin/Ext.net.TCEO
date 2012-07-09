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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class BoxItem : LayoutItem
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public BoxItem() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="component"></param>
        [Description("")]
        public BoxItem(Component component)
        {
            this.Items.Add(component);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="component"></param>
        /// <param name="flex"></param>
        [Description("")]
        public BoxItem(Component component, int flex)
        {
            this.Items.Add(component);
            this.Flex = flex;
        }

        /// <summary>
        /// This configuation option is to be applied to child items of the container managed by this layout. Each child item with a flex property will be flexed horizontally according to each item's relative flex value compared to the sum of all items with a flex value specified. Any child items that have either a flex = 0 or flex = undefined will not be 'flexed' (the initial size will not be changed).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. BoxItem")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("This configuation option is to be applied to child items of the container managed by this layout. Each child item with a flex property will be flexed horizontally according to each item's relative flex value compared to the sum of all items with a flex value specified. Any child items that have either a flex = 0 or flex = undefined will not be 'flexed' (the initial size will not be changed).")]
        public virtual int Flex
        {
            get
            {
                object obj = this.ViewState["Flex"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["Flex"] = value;
            }
        }

        /// <summary>
        /// The margins from this property will be applied to the item.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. BoxItem")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [Description("The margins from this property will be applied to the item.")]
        public string Margins
        {
            get
            {
                return (string)this.ViewState["Margins"] ?? "";
            }
            set
            {
                this.ViewState["Margins"] = value;
            }
        }
    }
}