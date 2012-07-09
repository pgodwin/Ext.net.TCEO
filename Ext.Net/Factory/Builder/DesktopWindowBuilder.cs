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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Window.Builder<DesktopWindow, DesktopWindow.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new DesktopWindow()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopWindow component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(DesktopWindow.Config config) : base(new DesktopWindow(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(DesktopWindow component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to display the 'maximize' tool button and allow the user to maximize the window, false to hide the button and disallow maximizing the window (defaults to false). Note that when a window is maximized, the tool button will automatically change to a 'restore' button with the appropriate behavior already built-in that will restore the window to its previous size.
			/// </summary>
            public virtual DesktopWindow.Builder Maximizable(bool maximizable)
            {
                this.ToComponent().Maximizable = maximizable;
                return this as DesktopWindow.Builder;
            }
             
 			/// <summary>
			/// True to force rendering otherwise rendering will be performed before the first showing.
			/// </summary>
            public virtual DesktopWindow.Builder LazyRender(bool lazyRender)
            {
                this.ToComponent().LazyRender = lazyRender;
                return this as DesktopWindow.Builder;
            }
             
 			/// <summary>
			/// False to skip task button showing
			/// </summary>
            public virtual DesktopWindow.Builder ShowInTaskbar(bool showInTaskbar)
            {
                this.ToComponent().ShowInTaskbar = showInTaskbar;
                return this as DesktopWindow.Builder;
            }
             
 			/// <summary>
			/// True to display the 'minimize' tool button and allow the user to minimize the window, false to hide the button and disallow minimizing the window (defaults to false). Note that this button provides no implementation -- the behavior of minimizing a window is implementation-specific, so the minimize event must be handled and a custom minimize behavior implemented for this option to be useful.
			/// </summary>
            public virtual DesktopWindow.Builder Minimizable(bool minimizable)
            {
                this.ToComponent().Minimizable = minimizable;
                return this as DesktopWindow.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual DesktopWindow.Builder Show()
            {
                this.ToComponent().Show();
                return this;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopWindow.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.DesktopWindow(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public DesktopWindow.Builder DesktopWindow()
        {
            return this.DesktopWindow(new DesktopWindow());
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopWindow.Builder DesktopWindow(DesktopWindow component)
        {
            return new DesktopWindow.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public DesktopWindow.Builder DesktopWindow(DesktopWindow.Config config)
        {
            return new DesktopWindow.Builder(new DesktopWindow(config));
        }
    }
}