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
using System.Collections.Generic;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ExtControlActionList : System.ComponentModel.Design.DesignerActionList
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DesignerActionItemCollection Items;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ExtControlActionList(IComponent component) : base(component) 
        {
            this.Control = component as XControl;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool AutoShow
        {
            get
            {
                return false;
            }
            set
            {
                base.AutoShow = false;
            }
        }

        private XControl control;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public XControl Control
        {
            get
            {
                return this.control;
            }
            set
            {
                this.control = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string ID
        {
            get
            {
                return this.Control.ID;
            }
            set
            {
                GetPropertyByName("ID").SetValue(this.Control, value);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void LaunchSupportHome()
        {
            System.Diagnostics.Process.Start("http://www.ext.net/support/");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void LaunchForums()
        {
            System.Diagnostics.Process.Start("http://forums.ext.net/");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void LaunchDocumentation()
        {
            System.Diagnostics.Process.Start("http://docs.ext.net/");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void LaunchExamples()
        {
            System.Diagnostics.Process.Start("http://examples.ext.net/");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public PropertyDescriptor GetPropertyByName(string name)
        {
            PropertyDescriptor property;
            property = TypeDescriptor.GetProperties(this.Control)[name];

            if (null == property)
                throw new ArgumentException("Matching WebControl property not found.", name);
            else
                return property;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            this.AddHeaderItem(new DesignerActionHeaderItem("Properties", "500"));
            this.AddHeaderItem(new DesignerActionHeaderItem("Support [Version " + this.Control.Version + "]", "1000"));

            this.AddMethodItem(new DesignerActionMethodItem(this, "LaunchForums", "Community Forums", "1000", "Visit the Ext.NET Forums"));
            this.AddMethodItem(new DesignerActionMethodItem(this, "LaunchExamples", "Examples Explorer", "1000", "View Ext.NET examples online"));
            this.AddMethodItem(new DesignerActionMethodItem(this, "LaunchDocumentation", "Documentation", "1000", "View online Ext.NET documentation"));
            this.AddMethodItem(new DesignerActionMethodItem(this, "LaunchSupportHome", "Support Home", "1000", "Visit the Ext.NET website for more support options", true));

            this.Items = new DesignerActionItemCollection();

            this.Items.Add(new DesignerActionPropertyItem("ID", "ID", "", "Change the ID of the control"));

            foreach (DesignerActionHeaderItem item in this.Headers)
            {
                this.Items.Add(item);
            }

            foreach (DesignerActionPropertyItem item in this.Properties)
            {
                this.Items.Add(item);
            }

            foreach (DesignerActionMethodItem item in this.Methods)
            {
                this.Items.Add(item);
            }

            return this.Items;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void AddHeaderItem(DesignerActionHeaderItem item)
        {
            foreach (DesignerActionHeaderItem header in this.Headers)
            {
                if (item.DisplayName == header.DisplayName)
                {
                    return;
                }
            }

            this.Headers.Add(item);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void RemoveHeaderItem(DesignerActionHeaderItem item)
        {
            foreach (DesignerActionHeaderItem header in this.Headers)
            {
                if (item.DisplayName == header.DisplayName)
                {
                    this.Headers.Remove(header);

                    return;
                }
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void AddPropertyItem(DesignerActionPropertyItem item)
        {
            foreach (DesignerActionPropertyItem property in this.Properties)
            {
                if (item.MemberName == property.MemberName && item.Category == property.Category)
                {
                    return;
                }
            }
            this.Properties.Add(item);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void RemovePropertyItem(DesignerActionPropertyItem item)
        {
            foreach (DesignerActionPropertyItem property in this.Properties)
            {
                if (item.MemberName == property.MemberName && item.Category == property.Category)
                {
                    this.Properties.Remove(property);
                    return;
                }
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void AddMethodItem(DesignerActionMethodItem item)
        {
            foreach (DesignerActionMethodItem method in this.Methods)
            {
                if (item.MemberName == method.MemberName && item.Category == method.Category)
                {
                    return;
                }
            }
            this.Methods.Add(item);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void RemoveMethodItem(DesignerActionMethodItem item)
        {
            foreach (DesignerActionMethodItem method in this.Methods)
            {
                if (item.MemberName == method.MemberName && item.Category == method.Category)
                {
                    this.Methods.Remove(method);
                    return;
                }
            }
        }

        private List<DesignerActionHeaderItem> headers = new List<DesignerActionHeaderItem>();
        private List<DesignerActionHeaderItem> Headers
        {
            get
            {
                this.headers.Sort(new DesignerActionHeaderItemComparer());
                return this.headers;
            }
        }

        private List<DesignerActionPropertyItem> properties = new List<DesignerActionPropertyItem>();
        private List<DesignerActionPropertyItem> Properties
        {
            get
            {
                return this.properties;
            }
        }

        private List<DesignerActionMethodItem> methods = new List<DesignerActionMethodItem>();
        private List<DesignerActionMethodItem> Methods
        {
            get
            {
                return this.methods;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class DesignerActionHeaderItemComparer : IComparer<DesignerActionHeaderItem>
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public int Compare(DesignerActionHeaderItem att1, DesignerActionHeaderItem att2)
        {
            Int32 cat1 = Convert.ToInt32(att1.Category);
            Int32 cat2 = Convert.ToInt32(att2.Category);

            return cat1.CompareTo(cat2);
        }
    }
}