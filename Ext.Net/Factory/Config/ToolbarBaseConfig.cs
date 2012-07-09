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
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
    public abstract partial class ToolbarBase
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : ContainerBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string defaultType = "Button";

			/// <summary>
			/// The default type of content Container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel').
			/// </summary>
			[DefaultValue("Button")]
			public override string DefaultType 
			{ 
				get
				{
					return this.defaultType;
				}
				set
				{
					this.defaultType = value;
				}
			}

			private bool flat = false;

			/// <summary>
			/// True to use flat style.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Flat 
			{ 
				get
				{
					return this.flat;
				}
				set
				{
					this.flat = value;
				}
			}

			private bool classicButtonStyle = false;

			/// <summary>
			/// True to use classic (none-flat) style.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ClassicButtonStyle 
			{ 
				get
				{
					return this.classicButtonStyle;
				}
				set
				{
					this.classicButtonStyle = value;
				}
			}

			private bool enableOverflow = false;

			/// <summary>
			/// Defaults to false. Configure <tt>true</tt> to make the toolbar provide a button which activates a dropdown Menu to show items which overflow the Toolbar's width.
			/// </summary>
			[DefaultValue(false)]
			public virtual bool EnableOverflow 
			{ 
				get
				{
					return this.enableOverflow;
				}
				set
				{
					this.enableOverflow = value;
				}
			}

        }
    }
}