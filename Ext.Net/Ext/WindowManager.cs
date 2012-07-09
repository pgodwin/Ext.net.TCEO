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
using System.ComponentModel;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class WindowManager : ScriptClass
    {
        /*  IScriptable
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.WindowMgr";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToScript()
        {
            return "";
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Brings the specified window to the front of any other active windows.
        /// </summary>
        /// <param name="windowID">The id of the window</param>
        /// <returns>WindowMgr</returns>
        public virtual void BringToFront(string windowID)
        {
            this.Call("bringToFront", windowID);
        }

        /// <summary>
        /// Brings the specified window to the front of any other active windows.
        /// </summary>
        /// <param name="window">Window</param>
        /// <returns>WindowMgr</returns>
        public virtual void BringToFront(WindowBase window)
        {
            this.BringToFront(window.ClientID);
        }

        /// <summary>
        /// Hides all windows in the group.
        /// </summary>
        /// <returns>WindowMgr</returns>
        public virtual void HideAll()
        {
            this.Call("hideAll");
        }

        /// <summary>
        /// Sends the specified window to the back of other active windows.
        /// </summary>
        /// <param name="windowID">The id of the window</param>
        /// <returns>WindowMgr</returns>
        public virtual void SendToBack(string windowID)
        {
            this.Call("sendToBack", windowID);
        }

        /// <summary>
        /// Sends the specified window to the back of other active windows.
        /// </summary>
        /// <param name="window">Window</param>
        /// <returns>WindowMgr</returns>
        public virtual void SendToBack(WindowBase window)
        {
            this.SendToBack(window.ClientID);
        }
    }
}