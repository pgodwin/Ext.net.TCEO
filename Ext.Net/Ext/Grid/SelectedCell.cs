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
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class SelectedCell : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SelectedCell() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SelectedCell(int rowIndex, int colIndex)
        {
            this.RowIndex = rowIndex;
            this.ColIndex = colIndex;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SelectedCell(string recordID, string name)
        {
            this.RecordID = recordID;
            this.Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [DefaultValue(-1)]
        [Description("")]
        public int RowIndex
        {
            get
            {
                object obj = this.ViewState["RowIndex"];
                return obj == null ? -1 : (int)obj;
            }
            set
            {
                this.ViewState["RowIndex"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [DefaultValue(-1)]
        [Description("")]
        public int ColIndex
        {
            get
            {
                object obj = this.ViewState["ColIndex"];
                return obj == null ? -1 : (int)obj;
            }
            set
            {
                this.ViewState["ColIndex"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [Description("")]
        public string RecordID
        {
            get
            {
                return (string)this.ViewState["RecordID"] ?? "";
            }
            set
            {
                this.ViewState["RecordID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [Description("")]
        public string Name
        {
            get
            {
                return (string)this.ViewState["Name"] ?? "";
            }
            set
            {
                this.ViewState["Name"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public virtual string Value
        {
            get
            {
                return (string)this.ViewState["Value"] ?? "";
            }
            internal set
            {
                this.ViewState["Value"] = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class SelectedCellSerializable : SelectedCell
    {
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public string SubmittedValue
        {
            get 
            { 
                return this.Value; 
            }
            set 
            { 
                this.Value = value; 
            }
        }
    }
}