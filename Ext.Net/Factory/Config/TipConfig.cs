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
    public abstract partial class Tip
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : PanelBase.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private bool closable = false;

			/// <summary>
			/// True to render a close tool button into the tooltip header (defaults to false).
			/// </summary>
			[DefaultValue(false)]
			public override bool Closable 
			{ 
				get
				{
					return this.closable;
				}
				set
				{
					this.closable = value;
				}
			}

			private bool constrainPosition = false;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(false)]
			public virtual bool ConstrainPosition 
			{ 
				get
				{
					return this.constrainPosition;
				}
				set
				{
					this.constrainPosition = value;
				}
			}

			private string defaultAlign = "";

			/// <summary>
			/// Experimental. The default Ext.Element.alignTo anchor position value for this tip relative to its element of origin (defaults to 'tl-bl?').
			/// </summary>
			[DefaultValue("")]
			public virtual string DefaultAlign 
			{ 
				get
				{
					return this.defaultAlign;
				}
				set
				{
					this.defaultAlign = value;
				}
			}

			private Unit maxWidth = Unit.Pixel(300);

			/// <summary>
			/// The maximum width of the tip in pixels (defaults to 300). The maximum supported value is 500.
			/// </summary>
			[DefaultValue(typeof(Unit), "300")]
			public override Unit MaxWidth 
			{ 
				get
				{
					return this.maxWidth;
				}
				set
				{
					this.maxWidth = value;
				}
			}

			private Unit minWidth = Unit.Pixel(40);

			/// <summary>
			/// The minimum width of the tip in pixels (defaults to 40).
			/// </summary>
			[DefaultValue(typeof(Unit), "40")]
			public override Unit MinWidth 
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