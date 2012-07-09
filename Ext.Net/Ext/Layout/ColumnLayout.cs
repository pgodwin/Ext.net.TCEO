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
using System.Drawing;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// This is the layout style of choice for creating structural layouts in a multi-column format where the width of each column can be specified as a percentage or fixed width, but the height is allowed to vary based on the content. 
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:ColumnLayout runat=\"server\"><{0}:LayoutColumn><{0}:Panel runat=\"server\" Title=\"Column 1 (125px)\" Width=\"125\" Height=\"200\" /></{0}:LayoutColumn><{0}:LayoutColumn ColumnWidth=\"0.8\"><{0}:Panel runat=\"server\" Title=\"Column 2 (80% of remainder)\" Height=\"200\" /></{0}:LayoutColumn><{0}:LayoutColumn ColumnWidth=\"0.2\"><{0}:Panel runat=\"server\" Title=\"Column 3 (20% of remainder)\" Height=\"200\" /></{0}:LayoutColumn></{0}:ColumnLayout>")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(ColumnLayout), "Build.ToolboxIcons.Layout.bmp")]
    [Description("This is the layout style of choice for creating structural layouts in a multi-column format where the width of each column can be specified as a percentage or fixed width, but the height is allowed to vary based on the content. ")]
    public partial class ColumnLayout : ContainerLayout
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public ColumnLayout() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("4. Layout")]
        [Description("")]
        public override string LayoutType
        {
            get
            {
                return "netcolumn";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Object)]
        [Browsable(false)]
        [Description("")]
        protected internal override LayoutConfig LayoutConfig
        {
            get
            {
                return new ColumnLayoutConfig(
                    this.FitHeight,
                    this.Split,
                    this.Margin,
                    this.ScrollOffset,
                    this.Background,
                    this.RenderHidden,
                    this.ExtraCls);
            }
        }

        /// <summary>
        /// True to fit the column elements height-wise into the Container. Defaults to true.
        /// </summary>
        [Meta]
        [Category("6. ColumnLayout")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to fit the column elements height-wise into the Container. Defaults to false.")]
        public virtual bool FitHeight
        {
            get
            {
                object obj = this.ViewState["FitHeight"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["FitHeight"] = value;
            }
        }

        /// <summary>
        /// True to fill background by predefined color. Defaults to false.
        /// </summary>
        [Meta]
        [Category("6. ColumnLayout")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to fill background by predefined color. Defaults to false.")]
        public virtual bool Background
        {
            get
            {
                object obj = this.ViewState["Background"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Background"] = value;
            }
        }

        /// <summary>
        /// True to allow resizing of the columns using a SplitBar. Defaults to false.
        /// </summary>
        [Meta]
        [Category("6. ColumnLayout")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to allow resizing of the columns using a SplitBar. Defaults to false.")]
        public virtual bool Split
        {
            get
            {
                object obj = this.ViewState["Split"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Split"] = value;
            }
        }

        /// <summary>
        /// Width of margin between columns in pixels. Overrides any style settings. Defaults to 0.
        /// </summary>
        [Meta]
        [Category("6. ColumnLayout")]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("Width of margin between columns in pixels. Overrides any style settings. Defaults to 0.")]
        public virtual int Margin
        {
            get
            {
                object obj = this.ViewState["Margin"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["Margin"] = value;
            }
        }

        /// <summary>
        /// The amount of space to reserve for the scrollbar
        /// </summary>
        [Meta]
        [Category("6. ColumnLayout")]
        [NotifyParentProperty(true)]
        [DefaultValue(0)]
        [Description("The amount of space to reserve for the scrollbar")]
        public virtual int ScrollOffset
        {
            get
            {
                object obj = this.ViewState["ScrollOffset"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["ScrollOffset"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [Description("")]
        public override ItemsCollection<Component> Items
        {
            get { return base.Items; }
        }
        
        private LayoutColumnCollection columns;

        /// <summary>
        /// Columns collection
        /// </summary>
        [Meta]
        [Category("6. ColumnLayout")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("Columns collection")]
        public LayoutColumnCollection Columns
        {
            get
            {
                if (this.columns == null)
                {
                    this.columns = new LayoutColumnCollection();
                    this.columns.AfterItemAdd += Columns_AfterItemAdd;
                    this.columns.AfterItemRemove += Columns_AfterItemRemove;
                }

                return this.columns;
            }
        }

        void Columns_AfterItemAdd(LayoutColumn item)
        {
            if (item.Control != null)
            {
                this.Items.Add((Component)item.Control);
                item.Items[0].AdditionalConfig = item;
            }

            item.Items.AfterItemAdd += delegate(Component cItem)
            {
                this.Items.Add(cItem);
                cItem.AdditionalConfig = item;
            };
            
            item.Items.AfterItemRemove += this.AfterItemRemove;
        }

        private void Columns_AfterItemRemove(LayoutColumn item)
        {
            if (item.Control != null)
            {
                this.Items.Remove(item.Control as Component);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                foreach (LayoutColumn column in this.Columns)
                {
                    if (column.Items.Count == 0)
                    {
                        throw new InvalidOperationException("This Column must contain a Component");
                    }
                }
            }

            base.OnPreRender(e);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class LayoutColumnCollection : StateManagedCollection<LayoutColumn> { }
}