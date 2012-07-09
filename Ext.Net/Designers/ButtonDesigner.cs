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
using System.ComponentModel;
using System.ComponentModel.Design;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ButtonDesigner : ExtControlDesigner
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string XGetDesignTimeHtml()
        {
            return BuildButton((ButtonBase)this.Control);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool AllowResize
        {
            get
            {
                return false;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string BuildButton(ButtonBase button)
        {
            this.AddIcon(button.Icon);

            object[] args = new object[7];
            args[0] = button.EnableToggle && button.Pressed ? pressed : "";
            args[1] = button.IconCls.IsNotEmpty() ? textIcon : "";
            args[2] = button.Disabled ? disabled : "";
            args[3] = button.Text;
            args[4] = button.IconCls;
            args[5] = this.GetIconStyleBlock();
            args[6] = button.StyleSpec;

            return string.Format(buttonTemplate, args);
        }

        private const string buttonTemplate = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width: auto;{6}\" class=\"x-btn-wrap x-btn{0}{1}{2}\"><tbody><tr><td class=\"x-btn-left\">{5}<i>&nbsp;</i></td><td class=\"x-btn-center\"><em unselectable=\"on\"><button class=\"x-btn-text {4}\" style=\"width:auto;\" type=\"button\">{3}</button></em></td><td class=\"x-btn-right\"><i>&nbsp;</i></td></tr></tbody></table>";
        
        private const string pressed = " x-btn-pressed";
        private const string textIcon = " x-btn-text-icon";
        private const string disabled = " x-items-disabled";

        private DesignerActionListCollection actionLists;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override DesignerActionListCollection XActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ButtonActionList(this.Component));
                }

                return actionLists;
            }
        }
    }
}