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

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class TreeDropZone : DropZone
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
                return "Ext.dd.TreeDropZone";
            }
        }

        private ConfigItemCollection dragOverData;

        /// <summary>
        /// Arbitrary data that can be associated with this tree and will be included in the event object that gets passed to any nodedragover event handler (defaults to {})
        /// </summary>
        [Category("7. TreeDropZone")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Arbitrary data that can be associated with this tree and will be included in the event object that gets passed to any nodedragover event handler (defaults to {})")]
        public virtual ConfigItemCollection DragOverData
        {
            get
            {
                if (this.dragOverData == null)
                {
                    this.dragOverData = new ConfigItemCollection();
                }

                return this.dragOverData;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("dragOverData", JsonMode.Raw)]
        [DefaultValue("{}")]
        [Description("")]
        protected internal virtual string DragOverDataProxy
        {
            get
            {
                return this.DragOverData.ToJson();
            }
        }

        /// <summary>
        /// True if drops on the tree container (outside of a specific tree node) are allowed (defaults to false)
        /// </summary>
        [ConfigOption]
        [Category("7. TreeDropZone")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True if drops on the tree container (outside of a specific tree node) are allowed (defaults to false)")]
        public virtual bool AllowContainerDrop
        {
            get
            {
                object obj = this.ViewState["AllowContainerDrop"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AllowContainerDrop"] = value;
            }
        }

        /// <summary>
        /// Allow inserting a dragged node between an expanded parent node and its first child that will become a sibling of the parent when dropped (defaults to false)
        /// </summary>
        [ConfigOption]
        [Category("7. TreeDropZone")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Allow inserting a dragged node between an expanded parent node and its first child that will become a sibling of the parent when dropped (defaults to false)")]
        public virtual bool AllowParentInsert
        {
            get
            {
                object obj = this.ViewState["AllowParentInsert"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AllowParentInsert"] = value;
            }
        }

        /// <summary>
        /// True if the tree should only allow append drops (use for trees which are sorted, defaults to false)
        /// </summary>
        [ConfigOption]
        [Category("7. TreeDropZone")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True if the tree should only allow append drops (use for trees which are sorted, defaults to false)")]
        public virtual bool AppendOnly
        {
            get
            {
                object obj = this.ViewState["AppendOnly"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AppendOnly"] = value;
            }
        }

        /// <summary>
        /// The delay in milliseconds to wait before expanding a target tree node while dragging a droppable node over the target (defaults to 1000)
        /// </summary>
        [ConfigOption]
        [Category("7. TreeDropZone")]
        [DefaultValue(1000)]
        [NotifyParentProperty(true)]
        [Description("The delay in milliseconds to wait before expanding a target tree node while dragging a droppable node over the target (defaults to 1000)")]
        public virtual int ExpandDelay
        {
            get
            {
                object obj = this.ViewState["ExpandDelay"];
                return (obj == null) ? 1000 : (int)obj;
            }
            set
            {
                this.ViewState["ExpandDelay"] = value;
            }
        }
    }
}