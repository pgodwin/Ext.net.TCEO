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
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class HeaderColumn : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public HeaderColumn() { }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption("target", JsonMode.Raw)]
        [DefaultValue("")]
		[Description("")]
        protected string TargetProxy
        {
            get
            {
                if (this.Target.IsEmpty())
                {
                    return "undefined";
                }

                return "Ext.net.getEl(".ConcatWith(TokenUtils.ParseAndNormalize(this.Target, this.Owner), ")");
            }
        }

        /// <summary>
        /// The target element which will be placed to the header.
        /// </summary>
        [Meta]
        [Category("3. GridView")]
        [DefaultValue("")]
        [Description("The target element which will be placed to the header.")]
        public virtual string Target
        {
            get
            {
                return (string)this.ViewState["Target"] ?? "";
            }
            set
            {
                this.ViewState["Target"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("autoWidth")]
        [Category("3. GridView")]
        [DefaultValue(true)]
        [Description("")]
        public virtual bool AutoWidthElement
        {
            get
            {
                object obj = this.ViewState["AutoWidthElement"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AutoWidthElement"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("correction")]
        [Category("3. GridView")]
        [DefaultValue(3)]
        [Description("")]
        public virtual int AutoWidthCorrection
        {
            get
            {
                object obj = this.ViewState["AutoWidthCorrection"];
                return (obj == null) ? 3 : (int)obj;
            }
            set
            {
                this.ViewState["AutoWidthCorrection"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
        [Description("")]
        public virtual string Cls
        {
            get
            {
                return (string)this.ViewState["Cls"] ?? "";
            }
            set
            {
                this.ViewState["Cls"] = value;
            }
        }

        ItemsCollection<Component> component;

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Category("3. GridView")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("component", typeof(ItemCollectionJsonConverter))]
        [Description("")]
        public virtual ItemsCollection<Component> Component
        {
            get
            {
                if (this.component == null)
                {
                    this.component = new ItemsCollection<Component>();
                    this.component.SingleItemMode = true;
                }

                return this.component;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class HeaderColumnCollection : StateManagedCollection<HeaderColumn> { }
}
