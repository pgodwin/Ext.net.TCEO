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
    public partial class GridCommand
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public GridCommand(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit GridCommand.Config Conversion to GridCommand
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator GridCommand(GridCommand.Config config)
        {
            return new GridCommand(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : GridCommandBase.Config 
        { 
			/*  Implicit GridCommand.Config Conversion to GridCommand.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator GridCommand.Builder(GridCommand.Config config)
			{
				return new GridCommand.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string commandName = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string CommandName 
			{ 
				get
				{
					return this.commandName;
				}
				set
				{
					this.commandName = value;
				}
			}
        
			private SimpleToolTip toolTip = null;

			/// <summary>
			/// 
			/// </summary>
			public SimpleToolTip ToolTip
			{
				get
				{
					if (this.toolTip == null)
					{
						this.toolTip = new SimpleToolTip();
					}
			
					return this.toolTip;
				}
			}
			
			private Icon icon = Icon.None;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon Icon 
			{ 
				get
				{
					return this.icon;
				}
				set
				{
					this.icon = value;
				}
			}

			private string iconCls = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string IconCls 
			{ 
				get
				{
					return this.iconCls;
				}
				set
				{
					this.iconCls = value;
				}
			}

			private string text = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Text 
			{ 
				get
				{
					return this.text;
				}
				set
				{
					this.text = value;
				}
			}

			private bool standOut = false;

			/// <summary>
			/// True to enable stand out by default (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public virtual bool StandOut 
			{ 
				get
				{
					return this.standOut;
				}
				set
				{
					this.standOut = value;
				}
			}

			private string cls = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string Cls 
			{ 
				get
				{
					return this.cls;
				}
				set
				{
					this.cls = value;
				}
			}

			private string ctCls = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string CtCls 
			{ 
				get
				{
					return this.ctCls;
				}
				set
				{
					this.ctCls = value;
				}
			}

			private bool disabled = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Disabled 
			{ 
				get
				{
					return this.disabled;
				}
				set
				{
					this.disabled = value;
				}
			}

			private string disabledClass = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string DisabledClass 
			{ 
				get
				{
					return this.disabledClass;
				}
				set
				{
					this.disabledClass = value;
				}
			}

			private bool hidden = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool Hidden 
			{ 
				get
				{
					return this.hidden;
				}
				set
				{
					this.hidden = value;
				}
			}

			private string overCls = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string OverCls 
			{ 
				get
				{
					return this.overCls;
				}
				set
				{
					this.overCls = value;
				}
			}
        
			private CommandMenu menu = null;

			/// <summary>
			/// 
			/// </summary>
			public CommandMenu Menu
			{
				get
				{
					if (this.menu == null)
					{
						this.menu = new CommandMenu();
					}
			
					return this.menu;
				}
			}
			
			private HideMode hideMode = HideMode.Display;

			/// <summary>
			/// How this component should be hidden. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display) - defaults to 'display'.
			/// </summary>
			[DefaultValue(HideMode.Display)]
			public virtual HideMode HideMode 
			{ 
				get
				{
					return this.hideMode;
				}
				set
				{
					this.hideMode = value;
				}
			}

			private Unit minWidth = Unit.Pixel(16);

			/// <summary>
			/// The minimum width for this button (used to give a set of buttons a common width).
			/// </summary>
			[DefaultValue(typeof(Unit), "16")]
			public virtual Unit MinWidth 
			{ 
				get
				{
					return this.minWidth;
				}
				set
				{
					this.minWidth = value;
				}
			}

        }
    }
}