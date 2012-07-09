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

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A Grid which creates itself from an existing HTML table element.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:TableGrid runat=\"server\"></{0}:TableGrid>")]
    [ToolboxBitmap(typeof(TableGrid), "Build.ToolboxIcons.TableGrid.bmp")]
    [Description("A Grid which creates itself from an existing HTML table element.")]
    public partial class TableGrid : GridPanel
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public TableGrid() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "tablegrid";
            }
        }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.grid.TableGrid";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CheckStore()
        {
            // do not remove
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.AutoRender)
            {
                this.Call("render");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Ignore)]
        [Description("")]
        protected internal override string RenderToProxy
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("table", JsonMode.Raw)]
        [Description("")]
        protected string TableProxy
        {
            get
            {
                string parsedTable = TokenUtils.ParseTokens(this.Table, this);

                if (TokenUtils.IsRawToken(parsedTable))
                {
                    return TokenUtils.ReplaceRawToken(parsedTable);
                }

                return "\"".ConcatWith(parsedTable, "\"");
            }
        }

        /// <summary>
        /// The table element from which this grid will be created.
        /// </summary>
        [Meta]
        [Category("8. TableGrid")]
        [DefaultValue("")]
        [Description("The table element from which this grid will be created.")]
        public virtual string Table
        {
            get
            {
                return (string)this.ViewState["Table"] ?? "";
            }
            set
            {
                this.ViewState["Table"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override ColumnModel ColumnModel
        {
            get
            {
                base.ColumnModel.Visible = false;
                return base.ColumnModel;
            }
        }

        private ColumnCollection columns;

        /// <summary>
        /// The columns to use when rendering the grid (required).
        /// </summary>
        [Meta]
        [ConfigOption("columns", JsonMode.AlwaysArray)]
        [Category("8. TableGrid")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("The columns to use when rendering the grid (required).")]
        public virtual ColumnCollection Columns
        {
            get
            {
                if (this.columns == null)
                {
                    this.columns = new ColumnCollection();
                }

                return this.columns;
            }
        }

        private RecordFieldCollection fields;

        /// <summary>
        /// An array of field definition objects
        /// </summary>
        [Meta]
        [ConfigOption("fields", JsonMode.AlwaysArray)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Either a Collection of RecordField definition objects")]
        public RecordFieldCollection Fields
        {
            get
            {
                if (fields == null)
                {
                    fields = new RecordFieldCollection();
                }

                return fields;
            }
        }

        /// <summary>
        /// True to use height:'auto', false to use fixed height (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxComponent")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to use height:'auto', false to use fixed height (defaults to false).")]
        public override bool AutoHeight
        {
            get
            {
                object obj = this.ViewState["AutoHeight"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AutoHeight"] = value;
            }
        }
    }
}
