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
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class AccordionLayoutConfig : LayoutConfig
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public AccordionLayoutConfig(bool activeOnTop, bool animate, bool originalHeader, bool autoWidth, bool collapseFirst, bool fill, bool hideCollapseTool, bool sequence, bool titleCollapse, bool renderHidden, string extraCls)
            : base(renderHidden, extraCls)
        {
            this.ActiveOnTop = activeOnTop;
            this.OriginalHeader = originalHeader;
            this.Animate = animate;
            this.AutoWidth = autoWidth;
            this.CollapseFirst = collapseFirst;
            this.Fill = fill;
            this.HideCollapseTool = hideCollapseTool;
            this.Sequence = sequence;
            this.TitleCollapse = titleCollapse;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public AccordionLayoutConfig() { }

        /// <summary>
        /// True to swap the position of each panel as it is expanded so that it becomes the first item in the container, false to keep the panels in the rendered order. This is NOT compatible with Animate="true" (defaults to false).
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("True to swap the position of each panel as it is expanded so that it becomes the first item in the container, false to keep the panels in the rendered order. This is NOT compatible with Animate=\"true\" (defaults to false).")]
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
        [ConfigOption]
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
        [ConfigOption]
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
        /// True to set each contained item's width to 'auto', false to use the item's current width (defaults to true). Note that some components, in particular the grid, will not function properly within layouts if they have auto width, so in such cases this config should be set to false.
        /// </summary>
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to set each contained item's width to 'auto', false to use the item's current width (defaults to true). Note that some components, in particular the grid, will not function properly within layouts if they have auto width, so in such cases this config should be set to false.")]
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
        [ConfigOption]
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
        /// True to adjust the active item's height to fill the available space in the container, false to use the item's current height, or auto height if not explicitly set (defaults to true).
        /// </summary>
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to adjust the active item's height to fill the available space in the container, false to use the item's current height, or auto height if not explicitly set (defaults to true).")]
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
        [ConfigOption]
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
        [ConfigOption]
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
        [ConfigOption]
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
    }
}