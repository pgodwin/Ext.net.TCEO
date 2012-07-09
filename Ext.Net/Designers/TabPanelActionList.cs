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
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace Ext.Net 
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class TabPanelActionList : ExtControlActionList
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
        public TabPanelActionList(IDesigner designer) : base(designer.Component)
        {
            this.designer = designer;
        }

        private TabPanelDesigner Designer
        {
            get
            {
                return designer as TabPanelDesigner;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public bool Plain
        {
            get
            {
                return ((TabPanel)this.Control).Plain;
            }
            set
            {
                this.GetPropertyByName("Plain").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Border
        {
            get
            {
                return ((TabPanel)this.Control).Border;
            }
            set
            {
                this.GetPropertyByName("Border").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool AutoPostBack
        {
            get
            {
                return ((TabPanel) this.Control).AutoPostBack;
            }
            set
            {
                this.GetPropertyByName("AutoPostBack").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool EnableTabScroll
        {
            get
            {
                return ((TabPanel)this.Control).EnableTabScroll;
            }
            set
            {
                this.GetPropertyByName("EnableTabScroll").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TabPosition TabPosition
        {
            get
            {
                return ((TabPanel)this.Control).TabPosition;
            }
            set
            {
                this.GetPropertyByName("TabPosition").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int ActiveTabIndex 
        {
            get
            {
                return ((TabPanel)this.Control).ActiveTabIndex;
            }
            set
            {
                this.GetPropertyByName("ActiveTabIndex").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Unit Height
        {
            get
            {
                return ((TabPanel)this.Control).Height;
            }
            set
            {
                this.GetPropertyByName("Height").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Unit Width
        {
            get
            {
                return ((TabPanel)this.Control).Width;
            }
            set
            {
                this.GetPropertyByName("Width").SetValue(this.Control, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public List<string> Tabs
        {
            get
            {
                List<string> tabsNames = new List<string>();

                foreach (PanelBase item in ((TabPanel)this.Control).Items)
                {
                    tabsNames.Add(item.ID);
                }

                return tabsNames;
            }
            set { }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string TabID
        {
            get
            {
                TabPanel tabs = (TabPanel)this.Control;
                return tabs.Items[tabs.ActiveTabIndex].ID;
            }
            set
            {
                TabPanel tabs = (TabPanel)this.Control;
                PanelBase activeTab = tabs.Items[tabs.ActiveTabIndex] as PanelBase;
                TypeDescriptor.GetProperties(activeTab)["ID"].SetValue(activeTab, value);
                ControlDesigner.InvokeTransactedChange(this.Component, new TransactedChangeCallback(func), activeTab, "Desc");
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Title
        {
            get
            {
                TabPanel tabs = (TabPanel)this.Control;
                PanelBase tab = tabs.Items[tabs.ActiveTabIndex] as PanelBase;
                return tab != null ? tab.Title : "[No title]";
            }
            set
            {
                TabPanel tabs = (TabPanel)this.Control;
                PanelBase activeTab = tabs.Items[tabs.ActiveTabIndex] as PanelBase;

                if (activeTab == null)
                {
                    return;
                }
                TypeDescriptor.GetProperties(activeTab)["Title"].SetValue(activeTab, value);
                ControlDesigner.InvokeTransactedChange(this.Component, new TransactedChangeCallback(func), activeTab, "Desc");
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Icon Icon
        {
            get
            {
                TabPanel tabs = (TabPanel)this.Control;
                PanelBase tab = tabs.Items[tabs.ActiveTabIndex] as PanelBase;
                return tab.Icon;
            }
            set
            {
                TabPanel tabs = (TabPanel)this.Control;
                PanelBase activeTab = tabs.Items[tabs.ActiveTabIndex] as PanelBase;

                if (activeTab == null)
                {
                    return;
                }
                TypeDescriptor.GetProperties(activeTab)["Icon"].SetValue(activeTab, value);
                ControlDesigner.InvokeTransactedChange(this.Component, new TransactedChangeCallback(func), activeTab, "Desc");
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Closable
        {
            get
            {
                TabPanel tabs = (TabPanel)this.Control;
                return (tabs.Items[tabs.ActiveTabIndex] as PanelBase).Closable;
            }
            set
            {
                TabPanel tabs = (TabPanel)this.Control;
                PanelBase activeTab = tabs.Items[tabs.ActiveTabIndex] as PanelBase;

                if (activeTab == null)
                {
                    return;
                }

                TypeDescriptor.GetProperties(activeTab)["Closable"].SetValue(activeTab, value);
                ControlDesigner.InvokeTransactedChange(this.Component, new TransactedChangeCallback(func), activeTab, "Desc");
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool Disabled
        {
            get
            {
                TabPanel tabs = (TabPanel)this.Control;
                return tabs.Items[tabs.ActiveTabIndex].Disabled;
            }
            set
            {
                TabPanel tabs = (TabPanel)this.Control;
                PanelBase activeTab = tabs.Items[tabs.ActiveTabIndex] as PanelBase;

                if (activeTab == null)
                {
                    return;
                }

                TypeDescriptor.GetProperties(activeTab)["Disabled"].SetValue(activeTab, value);
                ControlDesigner.InvokeTransactedChange(this.Component, new TransactedChangeCallback(func), activeTab, "Desc");
            }
        }

        private static bool func(object o)
        {
            return true;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void AddTabAtBegin()
        {
            Designer.AddTabAtBegin();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void AddTabAtEnd()
        {
            Designer.AddTabAtEnd();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void AddTabAfterActive()
        {
            Designer.AddTabAfterActive();
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void RemoveActiveTab()
        {
            Designer.RemoveActiveTab();
        }

        internal bool ActiveTabIndexIsValid
        {
            get
            {
                TabPanel tabPanelControl = (TabPanel) this.Control;
                return
                    tabPanelControl.ActiveTabIndex > -1 &&
                    tabPanelControl.ActiveTabIndex < tabPanelControl.Items.Count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            this.AddPropertyItem(new DesignerActionPropertyItem("Border", "Border", "500", "Add/Remove Border from TabPanel"));
            this.AddPropertyItem(new DesignerActionPropertyItem("Plain", "Plain", "500", "Render the TabPanel without a background image"));
            this.AddPropertyItem(new DesignerActionPropertyItem("AutoPostBack", "AutoPostBack", "500", "Automatically PostBack on Tab Changed"));
            this.AddPropertyItem(new DesignerActionPropertyItem("EnableTabScroll", "Enable Tab Scrolling", "500", "Enable scrolling to tabs that may be invisible"));
            this.AddPropertyItem(new DesignerActionPropertyItem("TabPosition", "Tab Position", "500", "The position where the Tabs should be rendered"));
            this.AddPropertyItem(new DesignerActionPropertyItem("Width", "Width", "500", "Change the Width of the TabPanel"));
            this.AddPropertyItem(new DesignerActionPropertyItem("Height", "Height", "500", "Change the Height of the TabPanel"));
            this.AddPropertyItem(new DesignerActionPropertyItem("ActiveTabIndex", "Active Tab", "500", "The numeric index of the Tab that should be initially activated"));

            DesignerActionHeaderItem activeTabHeader = new DesignerActionHeaderItem("Edit Tab Properties", "600");
            DesignerActionPropertyItem tabs = new DesignerActionPropertyItem("Tabs", "Select Tab", "600");
            DesignerActionPropertyItem tabID = new DesignerActionPropertyItem("TabID", "ID", "600");
            DesignerActionPropertyItem title = new DesignerActionPropertyItem("Title", "Title", "600");
            DesignerActionPropertyItem iconCls = new DesignerActionPropertyItem("Icon", "Icon", "600", "The Icon to use");
            DesignerActionPropertyItem closable = new DesignerActionPropertyItem("Closable", "Closable", "600", "Check to disable Tab");
            DesignerActionPropertyItem disabled = new DesignerActionPropertyItem("Disabled", "Disabled", "600", "Allow the user to close the Tab");

            if (this.ActiveTabIndexIsValid)
            {
                this.AddHeaderItem(activeTabHeader);
                this.AddPropertyItem(tabID);
                this.AddPropertyItem(title);
                this.AddPropertyItem(iconCls);
                this.AddPropertyItem(closable);
                this.AddPropertyItem(disabled);
            }
            else
            {
                this.RemovePropertyItem(disabled);
                this.RemovePropertyItem(closable);
                this.RemovePropertyItem(iconCls);
                this.RemovePropertyItem(title);
                this.RemovePropertyItem(tabID);
                this.RemoveHeaderItem(activeTabHeader);
            }

            this.AddHeaderItem(new DesignerActionHeaderItem("Operations", "700"));
            this.AddMethodItem(new DesignerActionMethodItem(this, "AddTabAtBegin", "Insert Tab at Start", "700", "Insert Tab at Start"));
            this.AddMethodItem(new DesignerActionMethodItem(this, "AddTabAtEnd", "Insert Tab at End", "700", "Insert Tab at End"));
            this.AddMethodItem(new DesignerActionMethodItem(this, "AddTabAfterActive", "Insert Tab after Active Tab", "700", "Insert Tab after Active Tab"));
            this.AddMethodItem(new DesignerActionMethodItem(this, "RemoveActiveTab", "Remove Active Tab", "700", "Remove Active Tab"));

            return base.GetSortedActionItems();
        }
    }
}