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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class EditorAlignmentConfig : StateManagedItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public EditorAlignmentConfig() { }

        /// <summary>
        /// Element anchor point
        /// </summary>
        [DefaultValue(AnchorPoint.Center)]
        [NotifyParentProperty(true)]
        [Description("Element anchor point")]
        public AnchorPoint ElementAnchor
        {
            get
            {
                object obj = this.ViewState["ElementAnchor"];
                return obj == null ? AnchorPoint.Center : (AnchorPoint)obj;
            }
            set
            {
                this.ViewState["ElementAnchor"] = value;
            }
        }

        /// <summary>
        /// Target anchor point
        /// </summary>
        [DefaultValue(AnchorPoint.Center)]
        [NotifyParentProperty(true)]
        [Description("Target anchor point")]
        public AnchorPoint TargetAnchor
        {
            get
            {
                object obj = this.ViewState["TargetAnchor"];
                return obj == null ? AnchorPoint.Center : (AnchorPoint)obj;
            }
            set
            {
                this.ViewState["TargetAnchor"] = value;
            }
        }

        /// <summary>
        ///  The editor will attempt to align as specified, but the position will be adjusted to constrain to the viewport if necessary
        /// </summary>
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("The editor will attempt to align as specified, but the position will be adjusted to constrain to the viewport if necessary")]
        public virtual bool ConstrainViewport
        {
            get
            {
                object obj = this.ViewState["ConstrainViewport"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ConstrainViewport"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override bool IsDefault
        {
            get
            {
                return this.ToString() == "c-c?";
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string ToString()
        {
            return Fx.AnchorConvert(this.ElementAnchor)
                    .ConcatWith("-")
                    .ConcatWith(Fx.AnchorConvert(this.TargetAnchor))
                    .ConcatWith(this.ConstrainViewport ? "?" : "");
        }
    }
}