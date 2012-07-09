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

using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class EventEditWindowBase : WindowBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.AutoRender = false;
        }
        
        /// <summary>
        /// The title during event adding
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. EventEditWindow")]
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
        [Category("8. EventEditWindow")]
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
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. EventEditWindow")]
        [DefaultValue("Saving changes...")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string SavingMessage
        {
            get
            {
                return (string)this.ViewState["SavingMessage"] ?? "Saving changes...";
            }
            set
            {
                this.ViewState["SavingMessage"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("8. EventEditWindow")]
        [DefaultValue("Deleting event...")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string DeletingMessage
        {
            get
            {
                return (string)this.ViewState["DeletingMessage"] ?? "Deleting event...";
            }
            set
            {
                this.ViewState["DeletingMessage"] = value;
            }
        }

        /// <summary>
        /// The group store ID to use.
        /// </summary>
        [Meta]
        [ConfigOption("calendarStore", JsonMode.ToClientID)]
        [Category("8. EventEditWindow")]
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

        // <summary>
        /// The width of this component in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetWidth")]
        [Category("7. Window")]
        [DefaultValue(typeof(Unit), "")]
        [Description("The width of this component in pixels (defaults to auto).")]
        public override Unit Width
        {
            get
            {
                Unit width = this.UnitPixelTypeCheck(ViewState["Width"], Unit.Empty, "Width");
                return width;
            }
            set
            {
                this.ViewState["Width"] = value;
            }
        }

        /// <summary>
        /// The height of this component in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetHeight")]
        [Category("7. Window")]
        [DefaultValue(typeof(Unit), "")]
        [Description("The height of this component in pixels (defaults to auto).")]
        public override Unit Height
        {
            get
            {
                Unit height = this.UnitPixelTypeCheck(ViewState["Height"], Unit.Empty, "Height");
                return height;
            }
            set
            {
                this.ViewState["Height"] = value;
            }
        }

        /// <summary>
        /// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
        /// </summary>
        /// <param name="storeId">Store Id</param>
        /// <param name="recordId">Record Id</param>
        public void Show(string storeId, object recordId)
        {
            this.Call("show", new JRawValue("{0}.getById({1})".FormatWith(storeId, JSON.Serialize(recordId))));
        }

        /// <summary>
        /// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
        /// </summary>
        /// <param name="storeId">Store Id</param>
        /// <param name="recordIndex">Record index</param>
        public void Show(string storeId, int recordIndex)
        {
            this.Call("show", new JRawValue("{0}.getAt({1})".FormatWith(storeId, recordIndex)));
        }

        /// <summary>
        /// Shows the window, rendering it first if necessary, or activates it and brings it to front if hidden.
        /// </summary>
        /// <param name="o">Plain object containing a StartDate property (and optionally an EndDate property) for showing the form in add mode.</param>
        public void Show(JsonObject obj)
        {
            this.Call("show", obj);
        }
    }
}