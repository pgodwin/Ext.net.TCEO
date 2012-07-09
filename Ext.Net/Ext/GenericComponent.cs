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

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Meta]
    [ToolboxItem(false)]
    [ToolboxData("<{0}:GenericComponent runat=\"server\" />")]
    [Description("A generic Component.")]
    public partial class GenericComponent<T> : Component where T : Component, new()
    {
        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return this.GenericXType ?? "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return this.GenericInstanceOf ?? "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [DefaultValue(null)]
        public virtual string GenericXType
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [DefaultValue(null)]
        [Description("")]
        public virtual string GenericInstanceOf
        {
            get;
            set;
        }

        private T component;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.UnrollObject)]
        [DefaultValue(null)]
        [Description("")]
        public virtual T Component
        {
            get
            {
                if (this.component == null)
                {
                    this.component = new T();
                    this.component.ID = this.ID;
                    this.component.IsProxy = true;
                    this.component.AutoRender = false;
                }

                return this.component;
            }
        }
    }
}