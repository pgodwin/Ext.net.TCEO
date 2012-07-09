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
    public partial class FitLayoutActionList : ExtControlActionList
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
        public FitLayoutActionList(IDesigner designer)
            : base(designer.Component)
        {
            this.designer = designer;
        }

        private FitLayoutDesigner Designer
        {
            get
            {
                return designer as FitLayoutDesigner;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void AddPanel()
        {
            Designer.AddItem(typeof(Panel));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void AddTabPanel()
        {
            Designer.AddItem(typeof(TabPanel));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void Clear()
        {
            Designer.Clear();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            this.AddHeaderItem(new DesignerActionHeaderItem("Actions", "600"));

            DesignerActionMethodItem addPanel = new DesignerActionMethodItem(this, "AddPanel", "Add Panel", "600");
            DesignerActionMethodItem addTabPanel = new DesignerActionMethodItem(this, "AddTabPanel", "Add TabPanel", "600");
            
            //DesignerActionMethodItem clear = new DesignerActionMethodItem(this, "Clear", "Clear layout", "600", "Remove control from layout");

            if (((FitLayout)this.Control).Items.Count > 0)
            {
                //this.AddMethodItem(clear);
                this.RemoveMethodItem(addPanel);
                this.RemoveMethodItem(addTabPanel);
            }
            else
            {
                this.AddMethodItem(addPanel);
                this.AddMethodItem(addTabPanel);
                //this.RemoveMethodItem(clear);
            }

            return base.GetSortedActionItems();
        }
    }
}