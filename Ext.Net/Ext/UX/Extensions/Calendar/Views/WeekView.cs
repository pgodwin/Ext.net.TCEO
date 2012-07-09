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
using System.Drawing;

namespace Ext.Net
{
    /// <summary>
    /// Displays a calendar view by week. This class does not usually need ot be used directly as you can use a CalendarPanel to manage multiple calendar views at once including the week view.
    /// </summary>
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(DayView), "Build.ToolboxIcons.CalendarPanel.bmp")]
    public partial class WeekView : DayView
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public WeekView() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.calendar.WeekView";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "weekview";
            }
        }

        /// <summary>
        /// The number of days to display in the view (defaults to 7)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. DayView")]
        [DefaultValue(7)]
        [NotifyParentProperty(true)]
        [Description("The number of days to display in the view (defaults to 7)")]
        public override int DayCount
        {
            get
            {
                object obj = this.ViewState["DayCount"];
                return obj != null ? (int)obj : 7;
            }
            set
            {
                this.ViewState["DayCount"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string CallID
        {
            get
            {
                Component cmp = this.ParentComponent;
                return cmp != null ? string.Format("Ext.getCmp(\"{0}\")", cmp.ConfigID + "-week") : this.ClientID;
            }
        }
    }
}