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

using System.ComponentModel;

namespace Ext.Net
{
    public partial class RatingColumn : ColumnBase
    {
        /// <summary>
		/// 
		/// </summary>
		[Description("")]
        public RatingColumn() { }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("xtype")]
        [DefaultValue("")]
		[Description("")]
        public virtual string XType
        {
            get
            {
                return "ratingcolumn";
            }
        }
        
        /// <summary>
        /// (optional) True if the column width cannot be changed. Defaults to false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue(true)]
        [Description("(optional) True if the column width cannot be changed. Defaults to false.")]
        public override bool Fixed
        {
            get
            {
                object obj = this.ViewState["Fixed"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Fixed"] = value;
            }
        }

        /// <summary>
        /// (optional) The name of the field in the grid's Store's Record definition from which
        /// to draw the column's value. If not specified, the column's index is used as an index
        /// into the Record's data Array.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue("rating")]
        [Description("(optional) The name of the field in the grid's Ext.data.Store's Ext.data.Record definition from which to draw the column's value. If not specified, the column's index is used as an index into the Record's data Array.")]
        public override string DataIndex
        {
            get
            {
                object obj = this.ViewState["DataIndex"];
                return (obj == null) ? "rating" : (string)obj;
            }
            set
            {
                this.ViewState["DataIndex"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue(false)]
        [Description("")]
        public override bool Editable
        {
            get
            {
                object obj = this.ViewState["Editable"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Editable"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool AllowChange
        {
            get
            {
                object obj = this.ViewState["AllowChange"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AllowChange"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue("rating-selected")]
        [Description("")]
        public virtual string SelectedCls
        {
            get
            {
                object obj = this.ViewState["SelectedCls"];
                return (obj == null) ? "rating-selected" : (string)obj;
            }
            set
            {
                this.ViewState["SelectedCls"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue("rating-unselected")]
        [Description("")]
        public virtual string UnselectedCls
        {
            get
            {
                object obj = this.ViewState["UnselectedCls"];
                return (obj == null) ? "rating-unselected" : (string)obj;
            }
            set
            {
                this.ViewState["UnselectedCls"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue(5)]
        [Description("")]
        public virtual int MaxRating
        {
            get
            {
                object obj = this.ViewState["MaxRating"];
                return (obj == null) ? 5 : (int)obj;
            }
            set
            {
                this.ViewState["MaxRating"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue(16)]
        [Description("")]
        public virtual int TickSize
        {
            get
            {
                object obj = this.ViewState["TickSize"];
                return (obj == null) ? 16 : (int)obj;
            }
            set
            {
                this.ViewState["TickSize"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. RatingColumn")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool RoundToTick
        {
            get
            {
                object obj = this.ViewState["RoundToTick"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["RoundToTick"] = value;
            }
        }
    }
}