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
using System.Drawing.Design;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    [Designer(typeof(EmptyDesigner))]
    [Description("")]
    public partial class ObjectHolder : Observable, ICustomConfigSerialization
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ObjectHolder() { }

        private JsonObject items;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public virtual JsonObject Items
        {
            get
            {
                if (this.items == null)
                {
                    this.items = new JsonObject();
                }

                return this.items;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToScript(Control owner)
        {
            if (this.Items.Count == 0)
            {
                return "";
            }

            return "this.".ConcatWith(this.ClientID, "=", JSON.Serialize(this.Items),";");
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public void UpdateData()
        {
            RequestManager.EnsureDirectEvent();

            this.AddScript("{0}={1};", this.ClientID, JSON.Serialize(this.Items));
        }
    }
}