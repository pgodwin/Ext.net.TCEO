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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class EventEditFormBase : FormPanelBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected internal CalendarPanelBase CalendarPanel
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.GroupStoreID.IsEmpty() && this.CalendarPanel != null)
            {
                this.GroupStoreID = this.CalendarPanel.GroupStoreID;
            }
        }

        /// <summary>
        /// The title during event adding
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. EventEditForm")]
        [DefaultValue("Add Event")]
        [NotifyParentProperty(true)]
        [Description("The title during event adding")]
        public virtual string TitleTextAdd
        {
            get
            {
                return (string)this.ViewState["TitleTextAdd"] ?? "Add Event";
            }
            set
            {
                this.ViewState["TitleTextAdd"] = value;
            }
        }

        /// <summary>
        /// The title during event editing
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. EventEditForm")]
        [DefaultValue("Edit Event")]
        [NotifyParentProperty(true)]
        [Description("The title during event editing")]
        public virtual string TitleTextEdit
        {
            get
            {
                return (string)this.ViewState["TitleTextEdit"] ?? "Edit Event";
            }
            set
            {
                this.ViewState["TitleTextEdit"] = value;
            }
        }

        /// <summary>
        /// The group store ID to use.
        /// </summary>
        [Meta]
        [ConfigOption("calendarStore", JsonMode.ToClientID)]
        [Category("7. EventEditForm")]
        [DefaultValue("")]
        [IDReferenceProperty(typeof(Store))]
        [Description("The group store ID to use.")]
        public virtual string GroupStoreID
        {
            get
            {
                return (string)this.ViewState["GroupStoreID"] ?? "";
            }
            set
            {
                this.ViewState["GroupStoreID"] = value;
            }
        }

        /// <summary>
        /// Load the record to the form's fields
        /// </summary>
        /// <param name="storeId">Store id</param>
        /// <param name="recordId">Record id</param>
        public void LoadRecord(string storeId, object recordId)
        {
            this.Call("loadRecord", new JRawValue("{0}.getById({1})".FormatWith(storeId, JSON.Serialize(recordId))));
        }

        /// <summary>
        /// Load the record to the form's fields
        /// </summary>
        /// <param name="storeId">Store id</param>
        /// <param name="recordIndex">Record index</param>
        public void LoadRecord(string storeId, int recordIndex)
        {
            this.Call("loadRecord", new JRawValue("{0}.getAt({1})".FormatWith(storeId, recordIndex)));
        }

        /// <summary>
        /// Save fields values to the record
        /// </summary>
        public void UpdateRecord()
        {
            this.Call("updateRecord");
        }
    }
}