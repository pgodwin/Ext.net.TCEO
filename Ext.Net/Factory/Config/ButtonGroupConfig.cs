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
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ButtonGroup(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ButtonGroup.Config Conversion to ButtonGroup
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ButtonGroup(ButtonGroup.Config config)
        {
            return new ButtonGroup(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Panel.Config 
        { 
			/*  Implicit ButtonGroup.Config Conversion to ButtonGroup.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ButtonGroup.Builder(ButtonGroup.Config config)
			{
				return new ButtonGroup.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string defaultType = "Button";

			/// <summary>
			/// The default type of content Container represented by this object as registered in Ext.ComponentMgr. Defaults to 'button' in ButtonGroup
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

			private bool frame = true;

			/// <summary>
			/// True to render the panel with custom rounded borders, false to render with plain 1px square borders (defaults to true).
			/// </summary>
			[DefaultValue(true)]
			public override bool Frame 
			{ 
				get
				{
					return this.frame;
				}
				set
				{
					this.frame = value;
				}
			}

			private int columns = -1;

			/// <summary>
			/// The columns configuration property passed to the configured layout manager. See Ext.layout.TableLayout.columns.
			/// </summary>
			[DefaultValue(-1)]
			public virtual int Columns 
			{ 
				get
				{
					return this.columns;
				}
				set
				{
					this.columns = value;
				}
			}

			private string layout = "table";

			/// <summary>
			/// The layout type to be used in this container.
			/// </summary>
			[DefaultValue("table")]
			public override string Layout 
			{ 
				get
				{
					return this.layout;
				}
				set
				{
					this.layout = value;
				}
			}

        }
    }
}