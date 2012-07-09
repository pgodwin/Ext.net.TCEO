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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// A specialized container representing the viewable application area (the browser viewport).
    /// </summary>
    [Meta]
    [Description("A specialized container representing the viewable application area (the browser viewport).")]
    public abstract partial class ViewportBase : ContainerBase, IContent
    {
        /// <summary>
        /// The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.
        /// </summary>
        [Category("0. About")]
        [Description("The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.")]
        public override string XType
        {
            get
            {
                return this.IsInForm ? "netviewport" : "viewport";
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
                return this.IsInForm ? "Ext.net.Viewport" : "Ext.Viewport";
            }
        }

        /// <summary>
        /// The id of the node, a DOM node or an existing Element that will be the content Container to render this component into.
        /// </summary>
        [DefaultValue("")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("The id of the node, a DOM node or an existing Element that will be the content Container to render this component into.")]
        public override string RenderTo
        {
            get
            {
                return this.IsInForm ? this.ParentForm.ClientID : "={Ext.getBody()}";
            }
            set
            {
                base.RenderTo = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override bool RemoveContainer
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Ignore)]
        [NotifyParentProperty(true)]
        [ReadOnly(true)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override Unit Height
        {
            get
            {
                return base.Height;
            }
            set
            {
                base.Height = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Ignore)]
        [NotifyParentProperty(true)]
        [ReadOnly(true)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override Unit Width
        {
            get
            {
                return base.Width;
            }
            set
            {
                base.Width = value;
            }
        }


        /*  IContent
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// The id of an existing HTML node to use as the panel's body content (defaults to '').
        /// </summary>
        [ConfigOption]
        [Category("6. Viewport")]
        [DefaultValue("")]
        [Description("The id of an existing HTML node to use as the panel's body content (defaults to '').")]
        public virtual string ContentEl
        {
            get
            {
                return "";
            }
        }

        private ITemplate body;

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        [Browsable(false)]
        [TemplateInstance(TemplateInstance.Single)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual ITemplate Content
        {
            get
            {
                return this.body;
            }
            set
            {
                this.body = value;

                if (value != null)
                {
                    value.InstantiateIn(this.ContentContainer);
                }
            }
        }

        private HtmlGenericControl contentContainer;

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public virtual HtmlGenericControl ContentContainer
        {
            get
            {
                if (this.contentContainer == null)
                {
                    this.contentContainer = this.CreateContainer();
                }

                return this.contentContainer;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            if (this.ContentContainer != null && !this.DesignMode)
            {
                this.ContentContainer.ID = this.ID.ConcatWith("_Content");
            }

            base.OnPreRender(e);
        }

		/// <summary>
		/// 
		/// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
        public ControlCollection ContentControls
        {
            get
            {
                return this.ContentContainer.Controls;
            }
        }
    }
}