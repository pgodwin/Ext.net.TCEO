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

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class Box : StateManagedItem
    {
        private int x = int.MinValue;
        private int y = int.MinValue;
        private int width = int.MinValue;
        private int height = int.MinValue;
        private string strWidth;
        private string strHeight;

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
        [DefaultValue(int.MinValue)]
		[Description("")]
        public int X
        {
            get { return x; }
            set { x = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
        [DefaultValue(int.MinValue)]
		[Description("")]
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
        [DefaultValue(int.MinValue)]
		[Description("")]
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
        [DefaultValue(int.MinValue)]
		[Description("")]
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("width")]
        [DefaultValue(int.MinValue)]
		[Description("")]
        public string StrWidth
        {
            get { return strWidth; }
            set { strWidth = value; }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("height")]
        [DefaultValue(null)]
		[Description("")]
        public string StrHeight
        {
            get { return strHeight; }
            set { strHeight = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Serialize()
        {
            return new ClientConfig().Serialize(this, true);
        }
    }
}