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
    /// This layout allows you to easily render content into an HTML table. The total number of columns can be specified, and rowspan and colspan can be used to create complex layouts within the table.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:TableLayout runat=\"server\" Columns=\"2\"><{0}:Cell><{0}:Panel runat=\"server\" Title=\"Panel 1\" Frame=\"true\" Width=\"200\" Height=\"200\" StyleSpec=\"padding: 5px;\" /></{0}:Cell><{0}:Cell><{0}:Panel runat=\"server\" Title=\"Panel 2\" Frame=\"true\" Width=\"200\" Height=\"200\"StyleSpec=\"padding: 5px 0;\" /></{0}:Cell><{0}:Cell ColSpan=\"2\"><{0}:Panel runat=\"server\" Title=\"Panel 3\" Frame=\"true\" Width=\"400\" Height=\"200\"StyleSpec=\"padding: 0 0 5px 5px\" /></{0}:Cell></{0}:TableLayout>")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(TableLayout), "Build.ToolboxIcons.Layout.bmp")]
    [Description("This layout allows you to easily render content into an HTML table. The total number of columns can be specified, and rowspan and colspan can be used to create complex layouts within the table.")]
    public partial class TableLayout : ContainerLayout
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public TableLayout() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("4. Layout")]
        [Description("")]
        public override string LayoutType
        {
            get
            {
                return "table";
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
                return new TableLayoutConfig(
                    this.Columns, 
                    this.TableAttrs,
                    this.RenderHidden,
                    this.ExtraCls);
            }
        }

        private DomObject tableAttrs;

        /// <summary>
        /// An object containing properties which are added to the DomHelper specification used to create the layout's <table> element.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [Category("6. TableLayout")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An object containing properties which are added to the DomHelper specification used to create the layout's <table> element.")]
        public virtual DomObject TableAttrs
        {
            get
            {
                if (this.tableAttrs == null)
                {
                    this.tableAttrs = new DomObject();
                }

                return this.tableAttrs;
            }
        }

        /// <summary>
        /// The total number of columns to create in the table for this layout. If not specified, all panels added to this layout will be rendered into a single row using a column per panel.
        /// </summary>
        [Meta]
        [Category("6. TableLayout")]
        [DefaultValue(0)]
        [Description("The total number of columns to create in the table for this layout. If not specified, all panels added to this layout will be rendered into a single row using a column per panel.")]
        public virtual int Columns
        {
            get
            {
                object obj = this.ViewState["Columns"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["Columns"] = value;
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

        private CellCollection cells;

        /// <summary>
        /// Cells collection
        /// </summary>
        [Meta]
        [Category("6. TableLayout")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("Cells collection")]
        public CellCollection Cells
        {
            get
            {
                if (this.cells == null)
                {
                    this.cells = new CellCollection();
                    this.cells.AfterItemAdd += new StateManagedCollection<Cell>.AfterItemAddHandler(Cells_AfterItemAdd);
                    this.cells.AfterItemRemove += new StateManagedCollection<Cell>.AfterItemRemoveHandler(Cells_AfterItemRemove);
                }

                return this.cells;
            }
        }

        private void Cells_AfterItemAdd(Cell item)
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

        private void Cells_AfterItemRemove(Cell item)
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
                foreach (Cell column in this.Cells)
                {
                    if (column.Items.Count == 0)
                    {
                        throw new InvalidOperationException("Cell in TableLayout must contain any container");
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
    public partial class CellCollection : StateManagedCollection<Cell> { }
}