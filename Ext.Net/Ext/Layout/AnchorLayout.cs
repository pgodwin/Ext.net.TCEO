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
    /// This is a layout that enables anchoring of contained elements relative to the container's dimensions. If the container is resized, all anchored items are automatically rerendered according to their anchor rules.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:AnchorLayout runat=\"server\"><Anchors><ext:Anchor><!-- Single Control Here --></ext:Anchor></Anchors></{0}:AnchorLayout>")]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(AnchorLayout), "Build.ToolboxIcons.Layout.bmp")]
    [Description("This is a layout that enables anchoring of contained elements relative to the container's dimensions. If the container is resized, all anchored items are automatically rerendered according to their anchor rules.")]
    public partial class AnchorLayout : ContainerLayout
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public AnchorLayout() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("4. Layout")]
        [Description("")]
        public override string LayoutType
        {
            get
            {
                return "anchor";
            }
        }

        /// <summary>
        /// The height of this Anchor in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [Category("6. AnchorLayout")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The height of this Anchor in pixels (defaults to auto).")]
        public override Unit Height
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["Height"], Unit.Empty, "Height");
            }
            set
            {
                this.ViewState["Height"] = value;
            }
        }

        /// <summary>
        /// The width of this Anchor in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Ignore)]
        [Category("6. AnchorLayout")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("The width of this Anchor in pixels (defaults to auto).")]
        public override Unit Width
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["Width"], Unit.Empty, "Width");
            }
            set
            {
                this.ViewState["Width"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("anchorSize", JsonMode.Object)]
        [DefaultValue(null)]
        [Browsable(false)]
        [Description("")]
        public AnchorSize AnchorSize
        {
            get
            {
                if (this.Width.IsEmpty && this.Height.IsEmpty)
                {
                    return null;
                }
                return new AnchorSize(this.Width, this.Height);
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

        private AnchorCollection anchors;

        /// <summary>
        /// Anchors collection
        /// </summary>
        [Meta]
        [Category("6. AnchorLayout")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [ViewStateMember]
        [Description("Anchors collection")]
        public AnchorCollection Anchors
        {
            get
            {
                if (this.anchors == null)
                {
                    this.anchors = new AnchorCollection();
                    this.anchors.AfterItemAdd += Anchors_AfterItemAdd;
                    this.anchors.AfterItemRemove += Anchors_AfterItemRemove;
                }

                return this.anchors;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected void Anchors_AfterItemAdd(Anchor item)
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

        private void Anchors_AfterItemRemove(Anchor item)
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
                foreach (Anchor anchor in this.Anchors)
                {
                    if (anchor.Items.Count == 0)
                    {
                        throw new InvalidOperationException("Anchor must contain at least one Component.");
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
    public partial class AnchorCollection : StateManagedCollection<Anchor> 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="component"></param>
        [Description("")]
        public virtual void Add(Component component)
        {
            this.Add(new Anchor(component));
        }
    }
}