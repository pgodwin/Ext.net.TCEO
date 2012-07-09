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
    public partial class ValidationStatus
    {
		/*  Ctor
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public ValidationStatus(Config config)
        {
            this.Apply(config);
        }


		/*  Implicit ValidationStatus.Config Conversion to ValidationStatus
			-----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        public static implicit operator ValidationStatus(ValidationStatus.Config config)
        {
            return new ValidationStatus(config);
        }
        
        /// <summary>
        /// 
        /// </summary>
        new public partial class Config : Plugin.Config 
        { 
			/*  Implicit ValidationStatus.Config Conversion to ValidationStatus.Builder
				-----------------------------------------------------------------------------------------------*/
        
            /// <summary>
			/// 
			/// </summary>
			public static implicit operator ValidationStatus.Builder(ValidationStatus.Config config)
			{
				return new ValidationStatus.Builder(config);
			}
			
			
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			
			private string formPanelID = "";

			/// <summary>
			/// The FormPanel to use.
			/// </summary>
			[DefaultValue("")]
			public virtual string FormPanelID 
			{ 
				get
				{
					return this.formPanelID;
				}
				set
				{
					this.formPanelID = value;
				}
			}

			private Icon errorIcon = Icon.None;

			/// <summary>
			/// The error icon
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon ErrorIcon 
			{ 
				get
				{
					return this.errorIcon;
				}
				set
				{
					this.errorIcon = value;
				}
			}

			private string errorIconCls = "x-status-error";

			/// <summary>
			/// The error icon css class
			/// </summary>
			[DefaultValue("x-status-error")]
			public virtual string ErrorIconCls 
			{ 
				get
				{
					return this.errorIconCls;
				}
				set
				{
					this.errorIconCls = value;
				}
			}

			private string errorListCls = "x-status-error-list";

			/// <summary>
			/// The error list css class
			/// </summary>
			[DefaultValue("x-status-error-list")]
			public virtual string ErrorListCls 
			{ 
				get
				{
					return this.errorListCls;
				}
				set
				{
					this.errorListCls = value;
				}
			}

			private Icon validIcon = Icon.None;

			/// <summary>
			/// The valid icon
			/// </summary>
			[DefaultValue(Icon.None)]
			public virtual Icon ValidIcon 
			{ 
				get
				{
					return this.validIcon;
				}
				set
				{
					this.validIcon = value;
				}
			}

			private string validIconCls = "x-status-valid";

			/// <summary>
			/// The valid icon css class
			/// </summary>
			[DefaultValue("x-status-valid")]
			public virtual string ValidIconCls 
			{ 
				get
				{
					return this.validIconCls;
				}
				set
				{
					this.validIconCls = value;
				}
			}

			private string showText = "The form has errors (click for details...)";

			/// <summary>
			/// The text which shown when errors exist
			/// </summary>
			[DefaultValue("The form has errors (click for details...)")]
			public virtual string ShowText 
			{ 
				get
				{
					return this.showText;
				}
				set
				{
					this.showText = value;
				}
			}

			private string hideText = "Click again to hide the error list";

			/// <summary>
			/// The text which hide error list when click on it
			/// </summary>
			[DefaultValue("Click again to hide the error list")]
			public virtual string HideText 
			{ 
				get
				{
					return this.hideText;
				}
				set
				{
					this.hideText = value;
				}
			}

        }
    }
}