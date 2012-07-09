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
    public partial class DesktopWindow
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public DesktopWindow(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit DesktopWindow.Config Conversion to DesktopWindow
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator DesktopWindow(DesktopWindow.Config config)
        {
            return new DesktopWindow(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Window.Config 
        { 
			/*  Implicit DesktopWindow.Config Conversion to DesktopWindow.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator DesktopWindow.Builder(DesktopWindow.Config config)
			{
				return new DesktopWindow.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool maximizable = true;

			/// <summary>
			/// True to display the 'maximize' tool button and allow the user to maximize the window, false to hide the button and disallow maximizing the window (defaults to false). Note that when a window is maximized, the tool button will automatically change to a 'restore' button with the appropriate behavior already built-in that will restore the window to its previous size.
			/// </summary>
			[DefaultValue(true)]
			public override bool Maximizable 
			{ 
				get
				{
					return this.maximizable;
				}
				set
				{
					this.maximizable = value;
				}
			}

			private bool lazyRender = true;

			/// <summary>
			/// True to force rendering otherwise rendering will be performed before the first showing.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool LazyRender 
			{ 
				get
				{
					return this.lazyRender;
				}
				set
				{
					this.lazyRender = value;
				}
			}

			private bool showInTaskbar = true;

			/// <summary>
			/// False to skip task button showing
			/// </summary>
			[DefaultValue(true)]
			public virtual bool ShowInTaskbar 
			{ 
				get
				{
					return this.showInTaskbar;
				}
				set
				{
					this.showInTaskbar = value;
				}
			}

			private bool minimizable = true;

			/// <summary>
			/// True to display the 'minimize' tool button and allow the user to minimize the window, false to hide the button and disallow minimizing the window (defaults to false). Note that this button provides no implementation -- the behavior of minimizing a window is implementation-specific, so the minimize event must be handled and a custom minimize behavior implemented for this option to be useful.
			/// </summary>
			[DefaultValue(true)]
			public override bool Minimizable 
			{ 
				get
				{
					return this.minimizable;
				}
				set
				{
					this.minimizable = value;
				}
			}

        }
    }
}