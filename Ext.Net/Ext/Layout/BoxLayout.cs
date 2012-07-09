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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Base Class for HBoxLayout and VBoxLayout Classes. Generally it should not need to be used directly.
    /// </summary>
    [Meta]
    [Description("Base Class for HBoxLayout and VBoxLayout Classes. Generally it should not need to be used directly.")]
    public abstract partial class BoxLayout : ContainerLayout
    {
        /// <summary>
        /// The default margins from this property will be applied to each item.
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [Description("The default margins from this property will be applied to each item.")]
        public string DefaultMargins
        {
            get
            {
                return (string)this.ViewState["DefaultMargins"] ?? "";
            }
            set
            {
                this.ViewState["DefaultMargins"] = value;
            }
        }

        /// <summary>
        /// Defaults to '0'. Sets the padding to be applied to all child items managed by this container's layout.
        /// </summary>
        [Meta]
        [DefaultValue("0")]
        [NotifyParentProperty(true)]
        [Description("Defaults to '0'. Sets the padding to be applied to all child items managed by this container's layout.")]
        public virtual string Padding 
        {
            get
            {
                return (string)this.ViewState["Padding"] ?? "0";
            }
            set
            {
                this.ViewState["Padding"] = value;
            }
        }

        /// <summary>
        /// Controls how the child items of the container are packed together. 
        /// </summary>
        [Meta]
        [Category("6. BoxLayout")]
        [DefaultValue(BoxPack.Start)]
        [Description("Controls how the child items of the container are packed together.")]
        public virtual BoxPack Pack
        {
            get
            {
                object obj = this.ViewState["Pack"];
                return (obj == null) ? BoxPack.Start : (BoxPack)obj;
            }
            set
            {
                this.ViewState["Pack"] = value;
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

        private BoxItemCollection boxItems;

        /// <summary>
        /// Box items collection
        /// </summary>
        [Meta]
        [Category("6. BoxLayout")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("Box items collection")]
        public BoxItemCollection BoxItems
        {
            get
            {
                if (this.boxItems == null)
                {
                    this.boxItems = new BoxItemCollection();
                    this.boxItems.AfterItemAdd += BoxItems_AfterItemAdd;
                    this.boxItems.AfterItemRemove += BoxItems_AfterItemRemove;
                }

                return this.boxItems;
            }
        }

        private void BoxItems_AfterItemAdd(BoxItem item)
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

        private void BoxItems_AfterItemRemove(BoxItem item)
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
                foreach (BoxItem boxItem in this.BoxItems)
                {
                    if (boxItem.Items.Count == 0)
                    {
                        throw new InvalidOperationException("BoxItem must contain at least one Component.");
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
    public partial class BoxItemCollection : StateManagedCollection<BoxItem>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="component"></param>
        [Description("")]
        public virtual void Add(Component component)
        {
            this.Add(new BoxItem(component));
        }
    }
}