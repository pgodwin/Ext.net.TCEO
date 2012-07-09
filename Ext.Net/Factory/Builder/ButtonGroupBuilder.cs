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
    public partial class ButtonGroup
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : Panel.Builder<ButtonGroup, ButtonGroup.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new ButtonGroup()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ButtonGroup component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(ButtonGroup.Config config) : base(new ButtonGroup(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(ButtonGroup component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The default type of content Container represented by this object as registered in Ext.ComponentMgr. Defaults to 'button' in ButtonGroup
			/// </summary>
            public virtual ButtonGroup.Builder DefaultType(string defaultType)
            {
                this.ToComponent().DefaultType = defaultType;
                return this as ButtonGroup.Builder;
            }
             
 			/// <summary>
			/// True to render the panel with custom rounded borders, false to render with plain 1px square borders (defaults to true).
			/// </summary>
            public virtual ButtonGroup.Builder Frame(bool frame)
            {
                this.ToComponent().Frame = frame;
                return this as ButtonGroup.Builder;
            }
             
 			/// <summary>
			/// The columns configuration property passed to the configured layout manager. See Ext.layout.TableLayout.columns.
			/// </summary>
            public virtual ButtonGroup.Builder Columns(int columns)
            {
                this.ToComponent().Columns = columns;
                return this as ButtonGroup.Builder;
            }
             
 			/// <summary>
			/// The layout type to be used in this container.
			/// </summary>
            public virtual ButtonGroup.Builder Layout(string layout)
            {
                this.ToComponent().Layout = layout;
                return this as ButtonGroup.Builder;
            }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public ButtonGroup.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.ButtonGroup(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public ButtonGroup.Builder ButtonGroup()
        {
            return this.ButtonGroup(new ButtonGroup());
        }

        /// <summary>
        /// 
        /// </summary>
        public ButtonGroup.Builder ButtonGroup(ButtonGroup component)
        {
            return new ButtonGroup.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public ButtonGroup.Builder ButtonGroup(ButtonGroup.Config config)
        {
            return new ButtonGroup.Builder(new ButtonGroup(config));
        }
    }
}