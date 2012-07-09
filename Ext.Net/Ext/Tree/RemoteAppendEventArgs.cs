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

using System.Web;
using Ext.Net.Utilities;
using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public class RemoteAppendEventArgs : RemoteActionEventArgs
    {
        private readonly bool insert;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RemoteAppendEventArgs(bool insert, string serviceParams, ParameterCollection extraParams)
            : base(serviceParams, extraParams)
        {
            this.insert = insert;
        }

        private string id;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool IsInsert
        {
            get
            {
                return this.insert;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public new string NodeID
        {
            get
            {
                if (this.id != null)
                {
                    return this.id;
                }
                return this.GetValue<string>("id");
            }
            set
            {
                this.id = value;
                ResourceManager.ExtraParamsResponse["ra_id"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ParentNodeID
        {
            get
            {
                return this.GetValue<string>("parentId");
            }
        }

        private string text;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Text
        {
            get
            {
                if (this.text != null)
                {
                    return this.text;
                }
                string s = this.GetValue<string>("text");
                return s.IsEmpty() ? s : HttpUtility.HtmlDecode(s);
            }
            set
            {
                this.text = value;
                ResourceManager.ExtraParamsResponse["ra_text"] = value;
            }
        }
    }
}