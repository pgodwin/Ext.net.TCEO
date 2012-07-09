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

namespace Ext.Net
{
    /// <summary>
    /// This is a base class for layouts that contain a single items that automatically expands to fill the layout's content Container. This class is intended to be extended or created via the layout:'fit' Ext.Container.layout config, and should generally not need to be created directly via the new keyword. FitLayout does not have any direct config options (other than inherited ones). To fit a panel to a content Container using FitLayout, simply set layout:'fit' on the content Container and add a single panel to it. If the content Container has multiple panels, only the first one will be displayed.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:AccordionLayout runat=\"server\" Animate=\"true\"><Items><{0}:Panel runat=\"server\" Border=\"false\" Title=\"Item 1\"><Items></Items></{0}:Panel><{0}:Panel runat=\"server\" Border=\"false\" Title=\"Item 2\" Collapsed=\"true\"><Items></Items></{0}:Panel></Items></{0}:AccordionLayout>")]
    [ToolboxBitmap(typeof(AccordionLayout), "Build.ToolboxIcons.Layout.bmp")]
    [Designer(typeof(AccordionDesigner))]
    [Description("This is a base class for layouts that contain a single items that automatically expands to fill the layout's content Container. This class is intended to be extended or created via the layout:'fit' Ext.Container.layout config, and should generally not need to be created directly via the new keyword. FitLayout does not have any direct config options (other than inherited ones). To fit a panel to a content Container using FitLayout, simply set layout:'fit' on the content Container and add a single panel to it. If the content Container has multiple panels, only the first one will be displayed.")]
    public partial class AccordionLayout : ContainerLayout
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public AccordionLayout() { }

        /// <summary>
		/// 
		/// </summary>
		[Category("4. Layout")]
		[Description("")]
        public override string LayoutType
        {
            get
            {
                return "accordion";
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [ConfigOption(JsonMode.Object)]
        [Browsable(false)]
		[Description("")]
        protected internal override LayoutConfig LayoutConfig
        {
            get
            {
                return new AccordionLayoutConfig(
                    this.ActiveOnTop,                    
                    this.Animate,
                    this.OriginalHeader,
                    this.AutoWidth,
                    this.CollapseFirst,
                    this.Fill,
                    this.HideCollapseTool,
                    this.Sequence,
                    this.TitleCollapse,
                    this.RenderHidden,
                    this.ExtraCls);
            }
        }

        /// <summary>
        /// True to swap the position of each panel as it is expanded so that it becomes the first items in the content Container, false to keep the panels in the rendered order. This is NOT compatible with 'animate:true' (defaults to false).
        /// </summary>
        [Meta]
        [Category("6. AccordionLayout")]
        [DefaultValue(false)]
        [Description("True to swap the position of each panel as it is expanded so that it becomes the first items in the content Container, false to keep the panels in the rendered order. This is NOT compatible with 'animate:true' (defaults to false).")]
        public virtual bool ActiveOnTop
        {
            get
            {
                object obj = this.ViewState["ActiveOnTop"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ActiveOnTop"] = value;
            }
        }

        /// <summary>
        /// If true then original header UI is used.
        /// </summary>
        [Meta]
        [Category("6. AccordionLayout")]
        [DefaultValue(false)]
        [Description("If true then original header UI is used")]
        public virtual bool OriginalHeader
        {
            get
            {
                object obj = this.ViewState["OriginalHeader"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["OriginalHeader"] = value;
            }
        }

        /// <summary>
        /// True to slide the contained panels open and closed during expand/collapse using animation, false to open and close directly with no animation (defaults to false). Note: to defer to the specific config setting of each contained panel for this property, set this to undefined at the layout level.
        /// </summary>
        [Meta]
        [Category("6. AccordionLayout")]
        [DefaultValue(false)]
        [Description("True to slide the contained panels open and closed during expand/collapse using animation, false to open and close directly with no animation (defaults to false). Note: to defer to the specific config setting of each contained panel for this property, set this to undefined at the layout level.")]
        public virtual bool Animate
        {
            get
            {
                object obj = this.ViewState["Animate"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Animate"] = value;
            }
        }

        /// <summary>
        /// True to set each contained items's width to 'auto', false to use the items's current width (defaults to true).
        /// </summary>
        [Meta]
        [Category("6. AccordionLayout")]
        [DefaultValue(true)]
        [Description("True to set each contained items's width to 'auto', false to use the items's current width (defaults to true).")]
        public virtual bool AutoWidth
        {
            get
            {
                object obj = this.ViewState["AutoWidth"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AutoWidth"] = value;
            }
        }

        /// <summary>
        /// True to make sure the collapse/expand toggle button always renders first (to the left of) any other tools in the contained panels' title bars, false to render it last (defaults to false).
        /// </summary>
        [Meta]
        [Category("6. AccordionLayout")]
        [DefaultValue(false)]
        [Description("True to make sure the collapse/expand toggle button always renders first (to the left of) any other tools in the contained panels' title bars, false to render it last (defaults to false).")]
        public virtual bool CollapseFirst
        {
            get
            {
                object obj = this.ViewState["CollapseFirst"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["CollapseFirst"] = value;
            }
        }

        /// <summary>
        /// True to adjust the active items's height to fill the available space in the content Container, false to use the items's current height, or auto height if not explicitly set (defaults to true).
        /// </summary>
        [Meta]
        [Category("6. AccordionLayout")]
        [DefaultValue(true)]
        [Description("True to adjust the active items's height to fill the available space in the content Container, false to use the items's current height, or auto height if not explicitly set (defaults to true).")]
        public virtual bool Fill
        {
            get
            {
                object obj = this.ViewState["Fill"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Fill"] = value;
            }
        }

        /// <summary>
        /// True to hide the contained panels' collapse/expand toggle buttons, false to display them (defaults to false). When set to true, titleCollapse should be true also.
        /// </summary>
        [Meta]
        [Category("6. AccordionLayout")]
        [DefaultValue(false)]
        [Description("True to hide the contained panels' collapse/expand toggle buttons, false to display them (defaults to false). When set to true, titleCollapse should be true also.")]
        public virtual bool HideCollapseTool
        {
            get
            {
                object obj = this.ViewState["HideCollapseTool"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["HideCollapseTool"] = value;
            }
        }

        /// <summary>
        /// Experimental. If animate is set to true, this will result in each animation running in sequence.
        /// </summary>
        [Meta]
        [Category("6. AccordionLayout")]
        [DefaultValue(false)]
        [Description("Experimental. If animate is set to true, this will result in each animation running in sequence.")]
        public virtual bool Sequence
        {
            get
            {
                object obj = this.ViewState["Sequence"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Sequence"] = value;
            }
        }

        /// <summary>
        /// True to allow expand/collapse of each contained panel by clicking anywhere on the title bar, false to allow expand/collapse only when the toggle tool button is clicked (defaults to true). When set to false, hideCollapseTool should be false also.
        /// </summary>
        /// <value><c>true</c> if [title collapse]; otherwise, <c>false</c>.</value>
        [Meta]
        [Category("6. AccordionLayout")]
        [DefaultValue(true)]
        [Description("True to allow expand/collapse of each contained panel by clicking anywhere on the title bar, false to allow expand/collapse only when the toggle tool button is clicked (defaults to true). When set to false, hideCollapseTool should be false also.")]
        public virtual bool TitleCollapse
        {
            get
            {
                object obj = this.ViewState["TitleCollapse"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["TitleCollapse"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual int ExpandedPanelIndex
        {
            get
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (!((PanelBase)this.Items[i]).Collapsed)
                    {
                        return i;
                    }
                }

                return -1;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual void ExpandPanel(int index)
        {
            if (index >= this.Items.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            foreach (PanelBase panel in this.Items)
            {
                if (!panel.Collapsed)
                {
                    panel.Collapsed = true;
                }
            }

            ((PanelBase)this.Items[index]).Collapsed = false;
        }
    }
}