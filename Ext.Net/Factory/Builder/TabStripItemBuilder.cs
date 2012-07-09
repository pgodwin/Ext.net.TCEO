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
    public partial class TabStripItem
    {
        /// <summary>
        /// 
        /// </summary>
        public partial class Builder : StateManagedItem.Builder<TabStripItem, TabStripItem.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TabStripItem()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TabStripItem component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TabStripItem.Config config) : base(new TabStripItem(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TabStripItem component)
            {
                return component.ToBuilder();
            }
            
            
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// 
			/// </summary>
            public virtual TabStripItem.Builder ItemID(string itemID)
            {
                this.ToComponent().ItemID = itemID;
                return this as TabStripItem.Builder;
            }
             
 			/// <summary>
			/// Managed container id. It will be shown when tab is activated
			/// </summary>
            public virtual TabStripItem.Builder ActionItemID(string actionItemID)
            {
                this.ToComponent().ActionItemID = actionItemID;
                return this as TabStripItem.Builder;
            }
             
 			/// <summary>
			/// Managed container. It will be shown when tab is activated
			/// </summary>
            public virtual TabStripItem.Builder ActionItem(Component actionItem)
            {
                this.ToComponent().ActionItem = actionItem;
                return this as TabStripItem.Builder;
            }
             
 			/// <summary>
			/// How the action item. Supported values are 'visibility' (css visibility), 'offsets' (negative offset position) and 'display' (css display).
			/// </summary>
            public virtual TabStripItem.Builder HideMode(HideMode hideMode)
            {
                this.ToComponent().HideMode = hideMode;
                return this as TabStripItem.Builder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TabStripItem.Builder Title(string title)
            {
                this.ToComponent().Title = title;
                return this as TabStripItem.Builder;
            }
             
 			/// <summary>
			/// A string to be used as innerHTML (html tags are accepted) to show in a tooltip when mousing over the associated tab selector element. NOTE: TabTip config is used when a BoxComponent is a child of a TabPanel.
			/// </summary>
            public virtual TabStripItem.Builder TabTip(string tabTip)
            {
                this.ToComponent().TabTip = tabTip;
                return this as TabStripItem.Builder;
            }
             
 			/// <summary>
			/// Panels themselves do not directly support being closed, but some Panel subclasses do (like Ext.Window) or a Panel Class within an Ext.TabPanel. Specify true to enable closing in such situations. Defaults to false.
			/// </summary>
            public virtual TabStripItem.Builder Closable(bool closable)
            {
                this.ToComponent().Closable = closable;
                return this as TabStripItem.Builder;
            }
             
 			/// <summary>
			/// Render this component hidden (default is false). If true, the hide method will be called internally.
			/// </summary>
            public virtual TabStripItem.Builder Hidden(bool hidden)
            {
                this.ToComponent().Hidden = hidden;
                return this as TabStripItem.Builder;
            }
             
 			/// <summary>
			/// The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.
			/// </summary>
            public virtual TabStripItem.Builder Icon(Icon icon)
            {
                this.ToComponent().Icon = icon;
                return this as TabStripItem.Builder;
            }
             
 			/// <summary>
			/// A css class which sets a background image to be used as the icon for this button.
			/// </summary>
            public virtual TabStripItem.Builder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return this as TabStripItem.Builder;
            }
             
 			// /// <summary>
			// /// Collection of custom js config
			// /// </summary>
            // public virtual TBuilder CustomConfig(ConfigItemCollection customConfig)
            // {
            //    this.ToComponent().CustomConfig = customConfig;
            //    return this as TBuilder;
            // }
            

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }

        /// <summary>
        /// 
        /// </summary>
        public TabStripItem.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TabStripItem(this);
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public TabStripItem.Builder TabStripItem()
        {
            return this.TabStripItem(new TabStripItem());
        }

        /// <summary>
        /// 
        /// </summary>
        public TabStripItem.Builder TabStripItem(TabStripItem component)
        {
            return new TabStripItem.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TabStripItem.Builder TabStripItem(TabStripItem.Config config)
        {
            return new TabStripItem.Builder(new TabStripItem(config));
        }
    }
}