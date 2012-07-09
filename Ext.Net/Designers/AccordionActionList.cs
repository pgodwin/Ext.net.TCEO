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
using System.ComponentModel.Design;
using System.Text;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class AccordionActionList : ExtControlActionList
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected readonly IDesigner designer;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public AccordionActionList(IDesigner designer)
            : base(designer.Component)
        {
            this.designer = designer;
        }

        private AccordionDesigner Designer
        {
            get
            {
                return designer as AccordionDesigner;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void AddPanel()
        {
            Designer.AddPanel();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void RemovePanel()
        {
            Designer.RemovePanel();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            this.AddHeaderItem(new DesignerActionHeaderItem("Actions", "600"));

            DesignerActionMethodItem add = new DesignerActionMethodItem(this, "AddPanel", "Add Panel", "600");
            DesignerActionMethodItem remove = new DesignerActionMethodItem(this, "RemovePanel", "Remove panel", "600", "Remove active panel");
            AccordionLayout layout = (AccordionLayout)this.Control;
            this.AddMethodItem(add);

            if (layout.ExpandedPanelIndex > -1)
            {
                this.AddMethodItem(remove);
            }
            else
            {
                this.RemoveMethodItem(remove);
            }

            return base.GetSortedActionItems();
        }
    }
}