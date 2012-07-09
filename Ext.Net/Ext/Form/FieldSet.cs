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
using System.Web.UI.WebControls;

namespace Ext.Net
{
    /// <summary>
    /// Standard content Container used for grouping form fields.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:FieldSet runat=\"server\"><Items></Items></{0}:FieldSet>")]
    [DefaultEvent("Width")]
    [ToolboxBitmap(typeof(FieldSet), "Build.ToolboxIcons.FieldSet.bmp")]
    [Designer(typeof(FieldSetDesigner))]
    [Description("Standard content Container used for grouping form fields.")]
    public partial class FieldSet : Panel
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FieldSet() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string XType
        {
            get
            {
                return "fieldset";
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
                return "Ext.form.FieldSet";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool IsCollapsible
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// True to render a checkbox into the fieldset frame just in front of the legend (defaults to false). The fieldset will be expanded or collapsed when the checkbox is toggled.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. FieldSet")]
        [DefaultValue(false)]
        [Description("True to render a checkbox into the fieldset frame just in front of the legend (defaults to false). The fieldset will be expanded or collapsed when the checkbox is toggled.")]
        public override bool AnimCollapse
        {
            get
            {
                object obj = this.ViewState["AnimCollapse"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AnimCollapse"] = value;
            }
        }

        /// <summary>
        /// True to render a checkbox into the fieldset frame just in front of the legend (defaults to false). The fieldset will be expanded or collapsed when the checkbox is toggled.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. FieldSet")]
        [DefaultValue("")]
        [Description("True to render a checkbox into the fieldset frame just in front of the legend (defaults to false). The fieldset will be expanded or collapsed when the checkbox is toggled.")]
        public virtual string CheckboxName
        {
            get
            {
                return (string)this.ViewState["CheckboxName"] ?? "";
            }
            set
            {
                this.ViewState["CheckboxName"] = value;
            }
        }


        /// <summary>
        /// True to render a checkbox into the fieldset frame just in front of the legend (defaults to false). The fieldset will be expanded or collapsed when the checkbox is toggled.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. FieldSet")]
        [DefaultValue(false)]
        [Description("True to render a checkbox into the fieldset frame just in front of the legend (defaults to false). The fieldset will be expanded or collapsed when the checkbox is toggled.")]
        public virtual bool CheckboxToggle
        {
            get
            {
                object obj = this.ViewState["CheckboxToggle"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["CheckboxToggle"] = value;
            }
        }

        /// <summary>
        /// A css class to apply to the x-form-items of fields. This property cascades to child containers.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. FieldSet")]
        [DefaultValue("")]
        [Description("A css class to apply to the x-form-items of fields. This property cascades to child containers.")]
        public override string ItemCls
        {
            get
            {
                return (string)this.ViewState["ItemCls"] ?? "";
            }
            set
            {
                this.ViewState["ItemCls"] = value;
            }
        }

        /// <summary>
        /// The width of labels. This property cascades to child containers.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. FieldSet")]
        [DefaultValue(75)]
        [Description("The width of labels. This property cascades to child containers.")]
        public override int LabelWidth
        {
            get
            {
                object obj = this.ViewState["LabelWidth"];
                return (obj == null) ? 75 : (int)obj;
            }
            set
            {
                this.ViewState["LabelWidth"] = value;
            }
        }
    }
}