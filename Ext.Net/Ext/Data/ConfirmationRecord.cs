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
using System.Text;
using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ConfirmationRecord
    {
        private bool confirm;
        private string oldId;
        private string newId;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfirmationRecord(bool confirm, string oldId)
        {
            this.confirm = confirm;
            this.oldId = oldId;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ConfirmationRecord()
        {
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Confirm
        {
            get { return confirm; }
            set { confirm = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string OldId
        {
            get { return oldId; }
            set { oldId = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string NewId
        {
            get { return newId; }
            set { newId = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void ConfirmRecord(string newId)
        {
            this.Confirm = true;
            this.NewId = newId;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void ConfirmRecord()
        {
            this.Confirm = true;
            this.NewId = this.oldId;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void UnConfirmRecord()
        {
            this.Confirm = false;
            this.NewId = null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ConfirmationList : SortedList<string, ConfirmationRecord>
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void ConfirmRecord(string oldId, string newId)
        {
            this[oldId].ConfirmRecord(newId);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void ConfirmRecord(string oldId)
        {
            this[oldId].ConfirmRecord();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ToJson()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            foreach (KeyValuePair<string, ConfirmationRecord> pair in this)
            {
                sb.AppendFormat("{{s:{0},oldId:{1},newId:{2}}},", pair.Value.Confirm.ToString().ToLower(), JSON.Serialize(pair.Value.OldId), JSON.Serialize(pair.Value.NewId ?? pair.Value.OldId));
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");

            return sb.ToString();
        }
    }
}
