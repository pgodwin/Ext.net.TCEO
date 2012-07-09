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

using System.Text;

using Ext.Net.Utilities;
using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class StoreResponseData
    {
        private string data;
        private int count;
        private ConfirmationList confirmation;

		/// <summary>
		/// 
		/// </summary>
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
        public ConfirmationList Confirmation
        {
            get { return confirmation; }
            set { confirmation = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int Total
        {
            get { return count; }
            set { count = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void Return()
        {
            CompressionUtils.GZipAndSend(this);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToString()
        {
            if (this.Data.IsEmpty() && (this.Confirmation == null || this.Confirmation.Count==0))
            {
                return null;
            }
            
            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            if (this.Data.IsNotEmpty())
            {
                sb.AppendFormat("data:{0}, total: {1},", this.Data, this.Total);
            }
            
            string returnConfirmation = "";

            if (this.Confirmation != null && this.Confirmation.Count>0)
            {
                returnConfirmation = this.Confirmation.ToJson();
            }

            if (returnConfirmation.IsNotEmpty())
            {
                sb.AppendFormat("confirm:{0}", returnConfirmation);
            }
            else
            {
                sb.Remove(sb.Length - 1, 1);
            }

            sb.Append("}");

            return sb.ToString();
        }
    }
}
