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
using System.Drawing.Design;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// This is a region of a BorderLayout that acts as a subcontainer within the layout. Each region has its own layout that is independent of other regions and the containing BorderLayout, and can be any of the valid Ext layout types.
    /// </summary>
    [Meta]
    [DefaultProperty("Items")]
    [ParseChildren(true, "Items")]
    [Description("This is a region of a BorderLayout that acts as a subcontainer within the layout. Each region has its own layout that is independent of other regions and the containing BorderLayout, and can be any of the valid Ext layout types.")]
    public partial class BorderLayoutRegion : StateManagedItem
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public BorderLayoutRegion() { }

        private readonly RegionPosition region;
        private readonly BorderLayout layout;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public BorderLayoutRegion(BorderLayout layout, RegionPosition region)
        {
            this.region = region;
            this.layout = layout;
        }

        private ItemsCollection<Component> items;

        /// <summary>
        /// Region items
        /// </summary>
        [Meta]
        [Category("2. BorderLayoutRegion")]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        [Editor(typeof(ItemCollectionEditor), typeof(UITypeEditor))]
        [NotifyParentProperty(true)]
        [Description("Region items")]
        public virtual ItemsCollection<Component> Items
        {
            get
            {
                if (this.items == null)
                {
                    this.items = new ItemsCollection<Component>();
                    this.items.AfterItemAdd += AfterItemAdd;
                    this.items.AfterItemRemove += AfterItemRemove;
                    this.items.SingleItemMode = true;
                }

                return this.items;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void AfterItemAdd(Component item)
        {
            item.AdditionalConfig = this;
            layout.Items.Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [Description("")]
        protected virtual void AfterItemRemove(Component item)
        {
            layout.Items.Remove(item);
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [Category("2. BorderLayoutRegion")]
        [Description("")]
        public RegionPosition Region
        {
            get 
            { 
                return this.region; 
            }
        }

        /// <summary>
        /// When a collapsed region's bar is clicked, the region's panel will be displayed as a floated panel that will close again once the user mouses out of that panel (or clicks out if AutoHide = false). Setting animFloat to false will prevent the open and close of these floated panels from being animated (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("When a collapsed region's bar is clicked, the region's panel will be displayed as a floated panel that will close again once the user mouses out of that panel (or clicks out if AutoHide = false). Setting animFloat to false will prevent the open and close of these floated panels from being animated (defaults to true).")]
        public virtual bool AnimFloat
        {
            get
            {
                object obj = this.ViewState["AnimFloat"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AnimFloat"] = value;
            }
        }

        /// <summary>
        /// When a collapsed region's bar is clicked, the region's panel will be displayed as a floated panel. If autoHide is true, the panel will automatically hide after the user mouses out of the panel. If autoHide is false, the panel will continue to display until the user clicks outside of the panel (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("When a collapsed region's bar is clicked, the region's panel will be displayed as a floated panel. If autoHide is true, the panel will automatically hide after the user mouses out of the panel. If autoHide is false, the panel will continue to display until the user clicks outside of the panel (defaults to true).")]
        public virtual bool AutoHide
        {
            get
            {
                object obj = this.ViewState["AutoHide"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["AutoHide"] = value;
            }
        }

        /// <summary>
        /// A string containing margins to apply to the region's collapsed element. Example '5 0 5 0' (addToStart, Right, Bottom, Left)
        /// </summary>
        [Meta]
        [ConfigOption("cmargins")]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A string containing margins to apply to the region's collapsed element. Example '5 0 5 0' (addToStart, Right, Bottom, Left)")]
        public string CMarginsSummary
        {
            get
            {
                object obj = this.ViewState["CMarginsSummary"];

                string temp = (obj == null) ? "" : (string)obj;

                if (temp.IsNotEmpty())
                {
                    this.CMargins.Clear();
                }

                return temp;
            }
            set
            {
                this.ViewState["CMarginsSummary"] = value;
            }
        }

        private Margins cMargins;

        /// <summary>
        /// An object containing margins to apply to the region's collapsed element.
        /// </summary>
        [ConfigOption("cmargins", typeof(MarginsJsonConverter))]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.Attribute)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue("-1 -1 -1 -1")]
        [Description("An object containing margins to apply to the region's collapsed element.")]
        public Margins CMargins
        {
            get
            {
                if (this.cMargins == null)
                {
                    this.cMargins = new Margins(-1, -1, -1, -1);
                }

                return this.cMargins;
            }
        }

        /// <summary>
        /// By default, collapsible regions are collapsed by clicking the expand/collapse tool button that renders into the region's title bar. Optionally, when collapseMode is set to 'mini' the region's split bar will also display a small collapse button in the center of the bar. In 'mini' mode the region will collapse to a thinner bar than in normal mode. By default collapseMode is undefined, and the only two supported values are undefined and 'mini'. Note that if a collapsible region does not have a title bar, then collapseMode must be set to 'mini' in order for the region to be collapsible by the user as the tool button will not be rendered.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(CollapseMode.Default)]
        [NotifyParentProperty(true)]
        [Description("By default, collapsible regions are collapsed by clicking the expand/collapse tool button that renders into the region's title bar. Optionally, when collapseMode is set to 'mini' the region's split bar will also display a small collapse button in the center of the bar. In 'mini' mode the region will collapse to a thinner bar than in normal mode. By default collapseMode is undefined, and the only two supported values are undefined and 'mini'. Note that if a collapsible region does not have a title bar, then collapseMode must be set to 'mini' in order for the region to be collapsible by the user as the tool button will not be rendered.")]
        public CollapseMode CollapseMode
        {
            get
            {
                object obj = this.ViewState["CollapseMode"];
                return obj == null ? CollapseMode.Default : (CollapseMode)obj;
            }
            set 
            {
                ViewState["CollapseMode"] = value; 
            }
        }

        /// <summary>
        /// True to allow the user to collapse this region (defaults to false). If true, an expand/collapse tool button will automatically be rendered into the title bar of the region, otherwise the button will not be shown. Note that a title bar is required to display the toggle button -- if no region title is specified, the region will only be collapsible if CollapseMode is set to 'Mini'.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to allow the user to collapse this region (defaults to false). If true, an expand/collapse tool button will automatically be rendered into the title bar of the region, otherwise the button will not be shown. Note that a title bar is required to display the toggle button -- if no region title is specified, the region will only be collapsible if CollapseMode is set to 'Mini'.")]
        public virtual bool Collapsible
        {
            get
            {
                object obj = this.ViewState["Collapsible"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Collapsible"] = value;
            }
        }

        /// <summary>
        /// True to allow clicking a collapsed region's bar to display the region's panel floated above the layout, false to force the user to fully expand a collapsed region by clicking the expand button to see it again (defaults to true).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to allow clicking a collapsed region's bar to display the region's panel floated above the layout, false to force the user to fully expand a collapsed region by clicking the expand button to see it again (defaults to true).")]
        public virtual bool Floatable
        {
            get
            {
                object obj = this.ViewState["Floatable"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["Floatable"] = value;
            }
        }

        /// <summary>
        /// An string containing margins to apply to the region. Example '5 0 5 0' (addToStart, Right, Bottom, Left)
        /// </summary>
        [Meta]
        [ConfigOption("margins")]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("An string containing margins to apply to the region. Example '5 0 5 0' (addToStart, Right, Bottom, Left)")]
        public string MarginsSummary
        {
            get
            {
                object obj = this.ViewState["MarginsSummary"];

                string temp = (obj == null) ? "" : (string)obj;

                if (temp.IsNotEmpty())
                {
                    this.Margins.Clear();
                }

                return temp;
            }
            set
            {
                this.ViewState["MarginsSummary"] = value;
            }
        }

        private Margins margins;

        /// <summary>
        /// An object containing margins to apply to the region.
        /// </summary>
        [NotifyParentProperty(true)]
        [ConfigOption("margins", typeof(MarginsJsonConverter))]
        [PersistenceMode(PersistenceMode.Attribute)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DefaultValue("-1 -1 -1 -1")]
        [Description("An object containing margins to apply to the region.")]
        public Margins Margins
        {
            get
            {
                if (this.margins == null)
                {
                    this.margins = new Margins(-1, -1, -1, -1);
                }

                return this.margins;
            }
        }

        /// <summary>
        /// The minimum allowable height in pixels for this region (defaults to 50)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue(typeof(Unit), "50")]
        [NotifyParentProperty(true)]
        [Description("The minimum allowable height in pixels for this region (defaults to 50)")]
        public virtual Unit MinHeight
        {
            get
            {
                object obj = this.ViewState["MinHeight"];
                return (obj == null) ? Unit.Pixel(50) : (Unit)obj;
            }
            set
            {
                this.ViewState["MinHeight"] = value;
            }
        }

        /// <summary>
        /// The maximum allowable height in pixels for this region
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The maximum allowable height in pixels for this region")]
        public virtual Unit MaxHeight
        {
            get
            {
                object obj = this.ViewState["MaxHeight"];
                return (obj == null) ? Unit.Empty : (Unit)obj;
            }
            set
            {
                this.ViewState["MaxHeight"] = value;
            }
        }

        /// <summary>
        /// The maximum allowable width in pixels for this region.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The maximum allowable width in pixels for this region.")]
        public virtual Unit MaxWidth
        {
            get
            {
                object obj = this.ViewState["MaxWidth"];
                return (obj == null) ? Unit.Empty : (Unit)obj;
            }
            set
            {
                this.ViewState["MaxWidth"] = value;
            }
        }

        /// <summary>
        /// The minimum allowable width in pixels for this region (defaults to 50)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue(typeof(Unit), "50")]
        [NotifyParentProperty(true)]
        [Description("The minimum allowable width in pixels for this region (defaults to 50)")]
        public virtual Unit MinWidth
        {
            get
            {
                object obj = this.ViewState["MinWidth"];
                return (obj == null) ? Unit.Pixel(50) : (Unit)obj;
            }
            set
            {
                this.ViewState["MinWidth"] = value;
            }
        }

        /// <summary>
        /// True to display a tooltip when the user hovers over a region's split bar (defaults to false). The tooltip text will be the value of either SplitTip or CollapsibleSplitTip as appropriate.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to display a tooltip when the user hovers over a region's split bar (defaults to false). The tooltip text will be the value of either SplitTip or CollapsibleSplitTip as appropriate.")]
        public virtual bool UseSplitTips
        {
            get
            {
                object obj = this.ViewState["UseSplitTips"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["UseSplitTips"] = value;
            }
        }

        /// <summary>
        /// The tooltip to display when the user hovers over a collapsible region's split bar. Only applies if UseSplitTips = true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue("Drag to resize. Double click to hide.")]
        [NotifyParentProperty(true)]
        [Description("The tooltip to display when the user hovers over a collapsible region's split bar. Only applies if UseSplitTips = true.")]
        public virtual string CollapsibleSplitTip
        {
            get
            {
                return (string)this.ViewState["CollapsibleSplitTip"] ?? "Drag to resize. Double click to hide.";
            }
            set
            {
                this.ViewState["CollapsibleSplitTip"] = value;
            }
        }

        /// <summary>
        /// The tooltip to display when the user hovers over a collapsible region's split bar. Only applies if UseSplitTips = true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue("Double click to show.")]
        [NotifyParentProperty(true)]
        [Description("The tooltip to display when the user hovers over a collapsible region's split bar. Only applies if UseSplitTips = true.")]
        public virtual string ExpandableSplitTip
        {
            get
            {
                return (string)this.ViewState["ExpandableSplitTip"] ?? "Double click to show.";
            }
            set
            {
                this.ViewState["ExpandableSplitTip"] = value;
            }
        }

        /// <summary>
        /// True to display a SplitBar between this region and its neighbor, allowing the user to resize the regions dynamically (defaults to false). When split = true, it is common to specify a minSize and maxSize for the region.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to display a SplitBar between this region and its neighbor, allowing the user to resize the regions dynamically (defaults to false). When split = true, it is common to specify a minSize and maxSize for the region.")]
        public virtual bool Split
        {
            get
            {
                object obj = this.ViewState["Split"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Split"] = value;
            }
        }

        /// <summary>
        /// The tooltip to display when the user hovers over a non-collapsible region's split bar. Only applies if UseSplitTips = true.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("2. BorderLayoutRegion")]
        [DefaultValue("Drag to resize.")]
        [NotifyParentProperty(true)]
        [Description("The tooltip to display when the user hovers over a non-collapsible region's split bar. Only applies if UseSplitTips = true.")]
        public virtual string SplitTip
        {
            get
            {
                return (string)this.ViewState["SplitTip"] ?? "Drag to resize.";
            }
            set
            {
                this.ViewState["SplitTip"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override string ToString()
        {
            return "";
        }
    }
}