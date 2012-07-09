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
using System.Drawing;

namespace Ext.Net
{
    /// <summary>
    /// A DragDrop implementation where the linked element follows the mouse cursor during a drag.
    /// </summary>
    [ToolboxItem(true)]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxData("<{0}:DD runat=\"server\"></{0}:DD>")]
    [ToolboxBitmap(typeof(DD), "Build.ToolboxIcons.DragDrop.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("A DragDrop implementation where the linked element follows the mouse cursor during a drag.")]
    public partial class DD : DragDrop
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
                return "Ext.dd.DD";
            }
        }

        /// <summary>
        /// When set to true, the utility automatically tries to scroll the browser window when a drag and drop element is dragged near the viewport boundary. Defaults to true.
        /// </summary>
        [ConfigOption]
        [Category("4. DD")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("When set to true, the utility automatically tries to scroll the browser window when a drag and drop element is dragged near the viewport boundary. Defaults to true.")]
        public virtual bool Scroll
        {
            get
            {
                object obj = this.ViewState["Scroll"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Scroll"] = value;
            }
        }

        /// <summary>
        /// Sets the element to the location of the mousedown or click event, maintaining the cursor location relative to the location on the element that was clicked. Override this if you want to place the element in a location other than where the cursor is.
        /// </summary>
        /// <param name="el">the element to move</param>
        /// <param name="iPageX">the X coordinate of the mousedown or drag event</param>
        /// <param name="iPageY">the Y coordinate of the mousedown or drag event</param>
        public void AlignElWithMouse(string el, int iPageX, int iPageY)
        {
            this.Call("alignElWithMouse", new JRawValue(string.Concat("Ext.net.getEl(", TokenUtils.ParseAndNormalize(el),".dom")), iPageX, iPageY);
        }

        /// <summary>
        /// Sets the pointer offset to the distance between the linked element's top left corner and the location the element was clicked
        /// </summary>
        /// <param name="iPageX">the X coordinate of the click</param>
        /// <param name="iPageY">the Y coordinate of the click</param>
        public void AutoOffset(int iPageX, int iPageY)
        {
            this.Call("autoOffset", iPageX, iPageY);
        }

        /// <summary>
        /// Saves the most recent position so that we can reset the constraints and tick marks on-demand. We need to know this so that we can calculate the number of pixels the element is offset from its original position.
        /// </summary>
        /// <param name="iPageX">current x position (optional, this just makes it so we don't have to look it up again)</param>
        /// <param name="iPageY">current y position (optional, this just makes it so we don't have to look it up again)</param>
        public void CachePosition(int iPageX, int iPageY)
        {
            this.Call("cachePosition", iPageX, iPageY);
        }

        /// <summary>
        /// Saves the most recent position so that we can reset the constraints and tick marks on-demand. We need to know this so that we can calculate the number of pixels the element is offset from its original position.
        /// </summary>
        public void CachePosition()
        {
            this.Call("cachePosition");
        }

        /// <summary>
        /// Sets the pointer offset. You can call this directly to force the offset to be in a particular location (e.g., pass in 0,0 to set it to the center of the object)
        /// </summary>
        /// <param name="iDeltaX">the distance from the left</param>
        /// <param name="iDeltaY">the distance from the top</param>
        public void SetDelta(int iDeltaX, int iDeltaY)
        {
            this.Call("setDelta", iDeltaX, iDeltaY);
        }

        /// <summary>
        /// Sets the drag element to the location of the mousedown or click event, maintaining the cursor location relative to the location on the element that was clicked. Override this if you want to place the element in a location other than where the cursor is.
        /// </summary>
        /// <param name="iPageX">the X coordinate of the mousedown or drag event</param>
        /// <param name="iPageY">the Y coordinate of the mousedown or drag event</param>
        public void SetDragElPos(int iPageX, int iPageY)
        {
            this.Call("setDragElPos", iPageX, iPageY);
        }
    }
}