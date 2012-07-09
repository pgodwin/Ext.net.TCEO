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

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// This is a base class for layouts that contain a single items that automatically expands to fill the layout's content Container. This class is intended to be extended or created via the layout:'fit' Ext.Container.layout config, and should generally not need to be created directly via the new keyword. FitLayout does not have any direct config options (other than inherited ones). To fit a panel to a content Container using FitLayout, simply set layout:'fit' on the content Container and add a single panel to it. If the content Container has multiple panels, only the first one will be displayed.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:FitLayout runat=\"server\"><Items><{0}:Panel runat=\"server\" Title=\"Title\"><Items></Items></{0}:Panel></Items></{0}:FitLayout>")]
    [ToolboxBitmap(typeof(FitLayout), "Build.ToolboxIcons.Layout.bmp")]
    [Description("This is a base class for layouts that contain a single items that automatically expands to fill the layout's content Container. This class is intended to be extended or created via the layout:'fit' Ext.Container.layout config, and should generally not need to be created directly via the new keyword. FitLayout does not have any direct config options (other than inherited ones). To fit a panel to a content Container using FitLayout, simply set layout:'fit' on the content Container and add a single panel to it. If the content Container has multiple panels, only the first one will be displayed.")]
    [Designer(typeof(FitLayoutDesigner))]
    public partial class FitLayout : ContainerLayout
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FitLayout() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("4. Layout")]
		[Description("")]
        public override string LayoutType
        {
            get
            {
                return "fit";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool SingleItemMode
        {
            get
            {
                return true;
            }
        }
    }
}