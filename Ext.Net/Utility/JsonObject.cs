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

using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    [Description("")]
    public partial class JsonObject : Dictionary<string, object> 
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToJsonString()
        {
            return JSON.Serialize(this);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToJsonString(List<JsonConverter> converters)
        {
            return this.ToJsonString(converters, true);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToJsonString(List<JsonConverter> converters, bool quoteName)
        {
            return JSON.Serialize(this, converters, quoteName, null);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string ToJsonString(List<JsonConverter> converters, bool quoteName, IContractResolver resolver)
        {
            return JSON.Serialize(this, converters, quoteName, resolver);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToString()
        {
            return JSON.Serialize(this);
        }
    }
}