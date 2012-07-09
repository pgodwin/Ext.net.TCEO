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
using System.Text;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ConfigItem : BaseParameter
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigItem() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigItem(string name, string value) : base(name, value) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigItem(string name, string value, ParameterMode mode) : base(name, value, mode) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigItem(string name, string value, bool encode) : base(name, value, encode) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfigItem(string name, string value, ParameterMode mode, bool encode) : base(name, value, mode, encode) { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override ParameterMode DefaultMode
        {
            get
            {
                return ParameterMode.Raw;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ConfigItemCollection : StateManagedCollection<ConfigItem>
    {
        private bool camelName = true;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual bool CamelName
        {
            get
            {
                return this.camelName;
            }
            set
            {
                this.camelName = value;
            }
        }
        
        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToJson()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            if (this.Count > 0)
            {
                bool needComma = false;

                foreach (ConfigItem item in this)
                {
                    if (needComma)
                    {
                        sb.Append(",");
                    }
                    
                    sb.Append(item.Name);
                    sb.Append(":");
                    sb.Append(item.ValueToString());
                    needComma = true;
                }
            }

            sb.Append("}");

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Description("")]
        public virtual bool Contains(string name)
        {
            foreach (ConfigItem item in this)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}