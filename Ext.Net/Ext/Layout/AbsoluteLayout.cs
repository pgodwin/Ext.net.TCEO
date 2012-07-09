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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// This layout adds the ability for x/y positioning using the standard x and y component config options.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:AbsoluteLayout id=\"AbsoluteLayout1\" runat=\"server\"><Anchors><{0}:Anchor><{0}:Panel runat=\"server\" Title=\"Panel 1\" X=\"50\" Y=\"50\" Width=\"200\" Height=\"100\"Frame=\"true\" BodyStyle=\"padding:15px;\"><Content>Positioned at x:50, y:50</Content></{0}:Panel></{0}:Anchor><{0}:Anchor><{0}:Panel runat=\"server\" Title=\"Panel 2\" X=\"125\" Y=\"125\" Width=\"200\"Height=\"100\" Frame=\"true\" BodyStyle=\"padding:15px;\"><Content>Positioned at x:125, y:125</Content></{0}:Panel></{0}:Anchor></Anchors></{0}:AbsoluteLayout>")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(AbsoluteLayout), "Build.ToolboxIcons.Layout.bmp")]
    [Description("This layout adds the ability for x/y positioning using the standard x and y component config options.")]
    public partial class AbsoluteLayout : AnchorLayout
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public AbsoluteLayout() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("4. Layout")]
		[Description("")]
        public override string LayoutType
        {
            get
            {
                return "absolute";
            }
        }
    }
}