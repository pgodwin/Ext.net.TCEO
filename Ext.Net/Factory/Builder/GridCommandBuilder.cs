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
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : GridCommandBase.Builder<GridCommand, GridCommand.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new GridCommand()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GridCommand component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(GridCommand.Config config) : base(new GridCommand(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(GridCommand component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual GridCommand.Builder CommandName(string commandName)
            {
                this.ToComponent().CommandName = commandName;
                return this as GridCommand.Builder;
            }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder ToolTip(SimpleToolTip toolTip)
            // {
            //    this.ToComponent().ToolTip = toolTip;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual GridCommand.Builder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as GridCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual GridCommand.Builder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as GridCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual GridCommand.Builder Text(string text)
            {
                this.ToComponent().Text = text;
                return this as GridCommand.Builder;
            }
             
 			/// <summary>
			/// True to enable stand out by default (defaults to false).
			/// </summary>
            public virtual GridCommand.Builder StandOut(bool standOut)
            {
                this.ToComponent().StandOut = standOut;
                return this as GridCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual GridCommand.Builder Cls(string cls)
            {
                this.ToComponent().Cls = cls;
                return this as GridCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual GridCommand.Builder CtCls(string ctCls)
            {
                this.ToComponent().CtCls = ctCls;
                return this as GridCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual GridCommand.Builder Disabled(bool disabled)
            {
                this.ToComponent().Disabled = disabled;
                return this as GridCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual GridCommand.Builder DisabledClass(string disabledClass)
            {
                this.ToComponent().DisabledClass = disabledClass;
                return this as GridCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual GridCommand.Builder Hidden(bool hidden)
            {
                this.ToComponent().Hidden = hidden;
                return this as GridCommand.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual GridCommand.Builder OverCls(string overCls)
            {
                this.ToComponent().OverCls = overCls;
                return this as GridCommand.Builder;
            }
             
 			// /// <summary>
			// /// 
			// /// </summary>
            // public virtual TBuilder Menu(CommandMenu menu)
            // {
            //    this.ToComponent().Menu = menu;
            //    return this as TBuilder;
            // }
             
 			/// <summary>
			/// How this component should be hidden. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display) - defaults to 'display'.
			/// </summary>
            public virtual GridCommand.Builder HideMode(HideMode hideMode)
            {
                this.ToComponent().HideMode = hideMode;
                return this as GridCommand.Builder;
            }
             
 			/// <summary>
			/// The minimum width for this button (used to give a set of buttons a common width).
			/// </summary>
            public virtual GridCommand.Builder MinWidth(Unit minWidth)
            {
                this.ToComponent().MinWidth = minWidth;
                return this as GridCommand.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public GridCommand.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.GridCommand(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public GridCommand.Builder GridCommand()
        {
            return this.GridCommand(new GridCommand());
        }

        /// <summary>
        /// 
        /// </summary>
        public GridCommand.Builder GridCommand(GridCommand component)
        {
            return new GridCommand.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public GridCommand.Builder GridCommand(GridCommand.Config config)
        {
            return new GridCommand.Builder(new GridCommand(config));
        }
    }
}