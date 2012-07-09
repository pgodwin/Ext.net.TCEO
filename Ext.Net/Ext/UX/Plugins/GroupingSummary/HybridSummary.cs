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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Adds capability to specify the summary data for the group via json
    /// </summary>
    [ToolboxItem(false)]
    [ToolboxBitmap(typeof(GroupingSummary), "Build.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:HybridSummary runat=\"server\" />")]
    [Description("Adds capability to specify the summary data for the group via json")]
    public partial class HybridSummary : GroupingSummary
    {
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.HybridSummary";
            }
        }

        /// <summary>
        /// Update summary with new data
        /// </summary>
        /// <param name="groupValue">group value</param>
        /// <param name="data">data object</param>
        /// <param name="skipRefresh">skip grid refresh</param>
        public void UpdateSummaryData(string groupValue, object data, bool skipRefresh)
        {
            this.Call("updateSummaryData", groupValue, data, skipRefresh);
        }

        /// <summary>
        /// Update summary with new data
        /// </summary>
        /// <param name="groupValue">group value</param>
        /// <param name="data">data object</param>
        public void UpdateSummaryData(string groupValue, object data)
        {
            this.Call("updateSummaryData", groupValue, data);
        }
    }
}