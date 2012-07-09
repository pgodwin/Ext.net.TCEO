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

using Newtonsoft.Json;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public abstract partial class ExtJsonConverter : JsonConverter
    {
        private string propertyName;
        private string name;
        private object owner;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string PropertyName
        {
            get { return propertyName; }
            set { propertyName = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public object Owner
        {
            get { return owner; }
            set { owner = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Control OwnerControl
        {
            get
            {
                if (this.Owner is StateManagedItem)
                {
                    return ((StateManagedItem)this.Owner).Owner;
                }
                else if (this.Owner is Control)
                {
                    return (Control)this.Owner;
                }

                return null;
            }
        }
    }
}