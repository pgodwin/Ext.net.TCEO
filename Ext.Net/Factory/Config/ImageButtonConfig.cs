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
    public partial class ImageButton
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ImageButton(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ImageButton.Config Conversion to ImageButton
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ImageButton(ImageButton.Config config)
        {
            return new ImageButton(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Button.Config 
        { 
			/*  Implicit ImageButton.Config Conversion to ImageButton.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ImageButton.Builder(ImageButton.Config config)
			{
				return new ImageButton.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string imageUrl = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string ImageUrl 
			{ 
				get
				{
					return this.imageUrl;
				}
				set
				{
					this.imageUrl = value;
				}
			}

			private string overImageUrl = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string OverImageUrl 
			{ 
				get
				{
					return this.overImageUrl;
				}
				set
				{
					this.overImageUrl = value;
				}
			}

			private string disabledImageUrl = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string DisabledImageUrl 
			{ 
				get
				{
					return this.disabledImageUrl;
				}
				set
				{
					this.disabledImageUrl = value;
				}
			}

			private string pressedImageUrl = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string PressedImageUrl 
			{ 
				get
				{
					return this.pressedImageUrl;
				}
				set
				{
					this.pressedImageUrl = value;
				}
			}

			private string alternateText = "";

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue("")]
			public virtual string AlternateText 
			{ 
				get
				{
					return this.alternateText;
				}
				set
				{
					this.alternateText = value;
				}
			}

			private ImageAlign align = ImageAlign.NotSet;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(ImageAlign.NotSet)]
			public virtual ImageAlign Align 
			{ 
				get
				{
					return this.align;
				}
				set
				{
					this.align = value;
				}
			}

        }
    }
}