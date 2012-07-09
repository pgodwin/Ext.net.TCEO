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
using System.Web.UI;
using System.Drawing;

namespace Ext.Net
{
    /// <summary>
    /// A DragDrop implementation that inserts an empty, bordered div into the document that follows the cursor during drag operations. At the time of the click, the frame div is resized to the dimensions of the linked html element, and moved to the exact location of the linked element. References to the "frame" element refer to the single proxy element that was created to be dragged in place of all DDProxy elements on the page.
    /// </summary>
    [ToolboxItem(true)]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxData("<{0}:DDProxy runat=\"server\"></{0}:DDProxy>")]
    [ToolboxBitmap(typeof(DDProxy), "Build.ToolboxIcons.DragDrop.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("A DragDrop implementation that inserts an empty, bordered div into the document that follows the cursor during drag operations. At the time of the click, the frame div is resized to the dimensions of the linked html element, and moved to the exact location of the linked element.")]
    public partial class DDProxy : DD
    {
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.dd.DDProxy";
            }
        }

        /// <summary>
        /// By default the frame is positioned exactly where the drag element is, so we use the cursor offset provided by Ext.dd.DD. Another option that works only if you do not have constraints on the obj is to have the drag frame centered around the cursor. Set centerFrame to true for this effect.
        /// </summary>
        [ConfigOption]
        [Category("5. DDProxy")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("By default the frame is positioned exactly where the drag element is, so we use the cursor offset provided by Ext.dd.DD. Another option that works only if you do not have constraints on the obj is to have the drag frame centered around the cursor. Set centerFrame to true for this effect.")]
        public virtual bool CenterFrame
        {
            get
            {
                object obj = this.ViewState["CenterFrame"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["CenterFrame"] = value;
            }
        }

        /// <summary>
        /// By default we resize the drag frame to be the same size as the element we want to drag (this is to get the frame effect). We can turn it off if we want a different behavior.
        /// </summary>
        [ConfigOption]
        [Category("5. DDProxy")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("By default we resize the drag frame to be the same size as the element we want to drag (this is to get the frame effect). We can turn it off if we want a different behavior.")]
        public virtual bool ResizeFrame
        {
            get
            {
                object obj = this.ViewState["ResizeFrame"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ResizeFrame"] = value;
            }
        }

        private JFunction afterDrag;

        /// <summary>
        /// Abstract method runs on drag end
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Category("5. DDProxy")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Abstract method runs on drag end")]
        public virtual JFunction AfterDrag
        {
            get
            {
                if (this.afterDrag == null)
                {
                    this.afterDrag = new JFunction();
                }

                return this.afterDrag;
            }
        }
    }
}