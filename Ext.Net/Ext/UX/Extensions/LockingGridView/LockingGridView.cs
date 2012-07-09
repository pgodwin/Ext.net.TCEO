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
using System.Collections.Generic;
using System.ComponentModel;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [ToolboxItem(false)]
    public partial class LockingGridView : GridView
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public LockingGridView() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override List<ResourceItem> Resources
        {
            get 
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 2;
                baseList.Add(new ClientStyleItem(typeof(LockingGridView), "Ext.Net.Build.Ext.Net.ux.extensions.lockinggrid.css.LockingGridView.css", "/ux/extensions/lockinggrid/css/LockingGridView.css"));
                baseList.Add(new ClientScriptItem(typeof(LockingGridView), "Ext.Net.Build.Ext.Net.ux.extensions.lockinggrid.LockingGridView.js", "/ux/extensions/lockinggrid/LockingGridView.js"));

                return baseList;
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.ux.grid.LockingGridView";
            }
        }

        /// <summary>
        /// The text displayed in the "Lock" menu item
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("4. LockingGridView")]
        [DefaultValue("Lock")]
        [Description("The text displayed in the \"Lock\" menu item")]
        public virtual string LockText
        {
            get
            {
                return (string)this.ViewState["LockText"] ?? "Lock";
            }
            set
            {
                this.ViewState["LockText"] = value;
            }
        }

        /// <summary>
        /// The text displayed in the "Unlock" menu item
        /// </summary>
        [Meta]
        [ConfigOption]
        [Localizable(true)]
        [Category("4. LockingGridView")]
        [DefaultValue("Unlock")]
        [Description("The text displayed in the \"Unlock\" menu item")]
        public virtual string UnlockText
        {
            get
            {
                return (string)this.ViewState["UnlockText"] ?? "Unlock";
            }
            set
            {
                this.ViewState["UnlockText"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. LockingGridView")]
        [DefaultValue(1)]
        [Description("")]
        public virtual int RowBorderWidth
        {
            get
            {
                object obj = this.ViewState["RowBorderWidth"];
                return (obj == null) ? 1 : (int)obj;
            }
            set
            {
                this.ViewState["RowBorderWidth"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. LockingGridView")]
        [DefaultValue(1)]
        [Description("")]
        public virtual int LockedBorderWidth
        {
            get
            {
                object obj = this.ViewState["LockedBorderWidth"];
                return (obj == null) ? 1 : (int)obj;
            }
            set
            {
                this.ViewState["LockedBorderWidth"] = value;
            }
        }

        /// <summary>
        /// This option ensures that height between the rows is synchronized between the locked and unlocked sides. This option only needs to be used when the row heights isn't predictable.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. LockingGridView")]
        [DefaultValue(false)]
        public virtual bool SyncHeights
        {
            get
            {
                object obj = this.ViewState["SyncHeights"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["SyncHeights"] = value;
            }
        }
    }
}
