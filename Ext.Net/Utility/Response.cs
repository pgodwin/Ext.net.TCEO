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
using System.Web;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class Response : ExtObject
    {
        private bool success;
        private string msg;
        private string data;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Response() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Response(bool success, string msg)
        {
            this.success = success;
            this.msg = msg;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Response(bool success)
        {
            this.success = success;
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("success")]
        [Description("")]
        public bool Success
        {
            get { return success; }
            set { success = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("message")]
        [DefaultValue(null)]
		[Description("")]
        public string Message
        {
            get { return msg; }
            set { msg = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("data", JsonMode.Raw)]
        [DefaultValue(null)]
		[Description("")]
        public string Data
        {
            get { return data; }
            set { data = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Serialize()
        {
            return new ClientConfig().Serialize(this);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void Write()
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(this.Serialize());
            HttpContext.Current.Response.End();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Return()
        {
            CompressionUtils.GZipAndSend(this.Serialize());
        }
    }
}
