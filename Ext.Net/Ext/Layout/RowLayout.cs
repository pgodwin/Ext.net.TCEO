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
using System.Globalization;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// This is the layout style of choice for creating structural layouts in a multi-row format where the height of each row can be specified as a percentage or fixed height.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:RowLayout runat=\"server\"></{0}:RowLayout>")]
    [ToolboxBitmap(typeof(RowLayout), "Build.ToolboxIcons.Layout.bmp")]
    [Description("This is the layout style of choice for creating structural layouts in a multi-row format where the height of each row can be specified as a percentage or fixed height.")]
    [Designer(typeof(EmptyDesigner))]
    public partial class RowLayout : ContainerLayout
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RowLayout() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("4. Layout")]
		[Description("")]
        public override string LayoutType
        {
            get
            {
                return "ux.row";
            }
        }

        /// <summary>
        /// True to fill background by predefined color. Defaults to false.
        /// </summary>
        [Meta]
        [Category("6. RowLayout")]
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
		/// 
		/// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
		[Description("")]
        public override ItemsCollection<Component> Items
        {
            get 
            { 
                return base.Items; 
            }
        }
        
        private LayoutRowCollection rows;

        /// <summary>
        /// Rows collection
        /// </summary>
        [Category("6. RowLayout")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("Rows collection")]
        public LayoutRowCollection Rows
        {
            get
            {
                if (this.rows == null)
                {
                    this.rows = new LayoutRowCollection();
                    this.rows.AfterItemAdd += Rows_AfterItemAdd;
                    this.rows.AfterItemRemove += Rows_AfterItemRemove;
                }

                return this.rows;
            }
        }

        void Rows_AfterItemAdd(LayoutRow item)
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

        private void Rows_AfterItemRemove(LayoutRow item)
        {
            if (item.Control != null)
            {
                this.Items.Remove(item.Control as Component);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (!this.DesignMode)
            {
                foreach (LayoutRow row in this.Rows)
                {
                    if (row.Items.Count == 0)
                    {
                        throw new InvalidOperationException("This Row must contain a Component");
                    }
                }
            }
        }

        /// <summary>
        /// True to allow resizing of the columns using a SplitBar. Defaults to false.
        /// </summary>
        [Meta]
        [Category("6. RowLayout")]
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
        [Category("6. RowLayout")]
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
		/// 
		/// </summary>
        [ConfigOption(JsonMode.Object)]
        [Browsable(false)]
		[Description("")]
        protected internal override LayoutConfig LayoutConfig
        {
            get
            {
                return new RowLayoutConfig(
                    this.Split,
                    this.Margin,
                    this.Background,
                    this.RenderHidden,
                    this.ExtraCls);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class LayoutRowCollection : StateManagedCollection<LayoutRow> { }
}