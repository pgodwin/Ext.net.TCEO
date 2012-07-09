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
    /// Base Class for any visual Component that uses a box content Container.
    /// </summary>
    [Meta]
    [Description("Base Class for any visual Component that uses a box content Container.")]
    public abstract partial class BoxComponentBase : Component
    {
        /// <summary>
        /// true to use overflow:'auto' on the components layout element and show scroll bars automatically when necessary, false to clip any overflowing content (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetAutoScroll")]
        [Category("4. BoxComponent")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("true to use overflow:'auto' on the components layout element and show scroll bars automatically when necessary, false to clip any overflowing content (defaults to false).")]
        public virtual bool AutoScroll
        {
            get
            {
                object obj = this.ViewState["AutoScroll"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoScroll"] = value;
            }
        }

        /// <summary>
        /// True to use height:'auto', false to use fixed height (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxComponent")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]    
        [Description("True to use height:'auto', false to use fixed height (defaults to false).")]
        public virtual bool AutoHeight
        {
            get
            {
                object obj = this.ViewState["AutoHeight"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoHeight"] = value;
            }
        }

        /// <summary>
        /// True to use width:'auto', false to use fixed width (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxComponent")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]    
        [Description("True to use width:'auto', false to use fixed width (defaults to false).")]
        public virtual bool AutoWidth
        {
            get
            {
                object obj = this.ViewState["AutoWidth"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["AutoWidth"] = value;
            }
        }

        /// <summary>
        /// By default, collapsible regions are collapsed by clicking the expand/collapse tool button that renders into the region's title bar. Optionally, when collapseMode is set to 'mini' the region's split bar will also display a small collapse button in the center of the bar. In 'mini' mode the region will collapse to a thinner bar than in normal mode. By default collapseMode is undefined, and the only two supported values are undefined and 'mini'. Note that if a collapsible region does not have a title bar, then collapseMode must be set to 'mini' in order for the region to be collapsible by the user as the tool button will not be rendered.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("4. BoxComponent")]
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
        /// The maximum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The maximum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.")]
        public virtual Unit BoxMaxHeight
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["BoxMaxHeight"], Unit.Empty, "BoxMaxHeight");
            }
            set
            {
                this.ViewState["BoxMaxHeight"] = value;
            }
        }

        /// <summary>
        /// The maximum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The maximum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.")]
        public virtual Unit BoxMaxWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["BoxMaxWidth"], Unit.Empty, "BoxMaxWidth");
            }
            set
            {
                this.ViewState["BoxMaxWidth"] = value;
            }
        }

        /// <summary>
        /// The minimum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The minimum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.")]
        public virtual Unit BoxMinHeight
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["BoxMinHeight"], Unit.Empty, "BoxMinHeight");
            }
            set
            {
                this.ViewState["BoxMinHeight"] = value;
            }
        }

        /// <summary>
        /// The minimum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The minimum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.")]
        public virtual Unit BoxMinWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["BoxMinWidth"], Unit.Empty, "BoxMinWidth");
            }
            set
            {
                this.ViewState["BoxMinWidth"] = value;
            }
        }

        /// <summary>
        /// The maximum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.
        /// </summary>
        [Meta]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The maximum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.")]
        public virtual Unit MaxHeight
        {
            get
            {
                return this.BoxMaxHeight;
            }
            set
            {
                this.BoxMaxHeight = value;
            }
        }

        /// <summary>
        /// The maximum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.
        /// </summary>
        [Meta]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The maximum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.")]
        public virtual Unit MaxWidth
        {
            get
            {
                return this.BoxMaxWidth;
            }
            set
            {
                this.BoxMaxWidth = value;
            }
        }

        /// <summary>
        /// The minimum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.
        /// </summary>
        [Meta]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The minimum value in pixels which this BoxComponent will set its height to. Warning: This will override any size management applied by layout managers.")]
        public virtual Unit MinHeight
        {
            get
            {
                return this.BoxMinHeight;
            }
            set
            {
                this.BoxMinHeight = value;
            }
        }

        /// <summary>
        /// The minimum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.
        /// </summary>
        [Meta]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The minimum value in pixels which this BoxComponent will set its width to. Warning: This will override any size management applied by layout managers.")]
        public virtual Unit MinWidth
        {
            get
            {
                return this.BoxMinWidth;
            }
            set
            {
                this.BoxMinWidth = value;
            }
        }

        /// <summary>
        /// The maximum value in pixels which this BoxComponent will set its height to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region. 
        /// </summary>
        [Meta]
        [ConfigOption("maxHeight")]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The maximum value in pixels which this BoxComponent will set its height to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region. ")]
        public virtual Unit RegionMaxHeight
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["RegionMaxHeight"], Unit.Empty, "RegionMaxHeight");
            }
            set
            {
                this.ViewState["RegionMaxHeight"] = value;
            }
        }

        /// <summary>
        /// The maximum value in pixels which this BoxComponent will set its width to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region. 
        /// </summary>
        [Meta]
        [ConfigOption("maxWidth")]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The maximum value in pixels which this BoxComponent will set its width to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region.")]
        public virtual Unit RegionMaxWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["RegionMaxWidth"], Unit.Empty, "RegionMaxWidth");
            }
            set
            {
                this.ViewState["RegionMaxWidth"] = value;
            }
        }

        /// <summary>
        /// The minimum value in pixels which this BoxComponent will set its height to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region. 
        /// </summary>
        [Meta]
        [ConfigOption("minHeight")]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The minimum value in pixels which this BoxComponent will set its height to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region.")]
        public virtual Unit RegionMinHeight
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["RegionMinHeight"], Unit.Empty, "RegionMinHeight");
            }
            set
            {
                this.ViewState["RegionMinHeight"] = value;
            }
        }

        /// <summary>
        /// The minimum value in pixels which this BoxComponent will set its width to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region. 
        /// </summary>
        [Meta]
        [ConfigOption("minWidth")]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The minimum value in pixels which this BoxComponent will set its width to in a BorderLayout Region. Warning: This will property will only be applied when this BoxComponent is rendered within a BorderLayout Region.")]
        public virtual Unit RegionMinWidth
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["RegionMinWidth"], Unit.Empty, "RegionMinWidth");
            }
            set
            {
                this.ViewState["RegionMinWidth"] = value;
            }
        }

        /// <summary>
        /// The height of this component in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetHeight")]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The height of this component in pixels (defaults to auto).")]
        public override Unit Height
        {
            get
            {
                return this.UnitPixelTypeCheck(this.ViewState["Height"], Unit.Empty, "Height");
            }
            set
            {
                this.ViewState["Height"] = value;
            }
        }

        /// <summary>
        ///  Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout or one of the two BoxLayout subclasses.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxComponent")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout or one of the two BoxLayout subclasses.")]
        public virtual string Margins
        {
            get
            {
                return (string)this.ViewState["Margins"] ?? "";
            }
            set
            {
                this.ViewState["Margins"] = value;
            }
        }

        /// <summary>
        ///  Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout or one of the two BoxLayout subclasses.
        /// </summary>
        [Meta]
        [ConfigOption("cmargins")]
        [Category("4. BoxComponent")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout or one of the two BoxLayout subclasses.")]
        public virtual string CMargins
        {
            get
            {
                return (string)this.ViewState["CMargins"] ?? "";
            }
            set
            {
                this.ViewState["CMargins"] = value;
            }
        }

        /// <summary>
        /// The page level x coordinate for this component if contained within a positioning container.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The page level x coordinate for this component if contained within a positioning container.")]
        public virtual Unit PageX
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["PageX"], Unit.Empty, "PageX");
            }
            set
            {
                this.ViewState["PageX"] = value;
            }
        }

        /// <summary>
        /// The page level y coordinate for this component if contained within a positioning container.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The page level y coordinate for this component if contained within a positioning container.")]
        public virtual Unit PageY
        {
            get
            {
                return this.UnitPixelTypeCheck(ViewState["PageY"], Unit.Empty, "PageY");
            }
            set
            {
                this.ViewState["PageY"] = value;
            }
        }

        /// <summary>
        /// Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToLower)]
        [Category("4. BoxComponent")]
        [DefaultValue(Region.None)]
        [NotifyParentProperty(true)]
        [Description("Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').")]
        public virtual Region Region
        {
            get
            {
                object obj = this.ViewState["Region"];
                return (obj == null) ? Region.None : (Region)obj;
            }
            set
            {
                this.ViewState["Region"] = value;
            }
        }

        /// <summary>
        /// True to create a SplitRegion and display a 5px wide Ext.SplitBar between this region and its neighbor, allowing the user to resize the regions dynamically. Defaults to false creating a Region. Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxComponent")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to create a SplitRegion and display a 5px wide Ext.SplitBar between this region and its neighbor, allowing the user to resize the regions dynamically. Defaults to false creating a Region. Note: this config is only used when this BoxComponent is rendered by a Container which has been configured to use the BorderLayout layout manager (e.g. specifying layout:'border').")]
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
        ///  A string to be used as innerHTML (html tags are accepted) to show in a tooltip when mousing over the associated tab selector element. NOTE: TabTip config is used when a BoxComponent is a child of a TabPanel.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. Panel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A string to be used as innerHTML (html tags are accepted) to show in a tooltip when mousing over the associated tab selector element. NOTE: TabTip config is used when a BoxComponent is a child of a TabPanel.")]
        public virtual string TabTip
        {
            get
            {
                return (string)this.ViewState["TabTip"] ?? "";
            }
            set
            {
                this.ViewState["TabTip"] = value;
            }
        }

        /// <summary>
        /// The width of this component in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [ConfigOption]
        [DirectEventUpdate(MethodName = "SetWidth")]
        [Category("4. BoxComponent")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]    
        [Description("The width of this component in pixels (defaults to auto).")]
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
        /// The local x (left) coordinate for this component if contained within a positioning container.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("4. BoxComponent")]
        [DefaultValue(0)]
        [Description("The local x (left) coordinate for this component if contained within a positioning container.")]
        public virtual int X
        {
            get
            {
                object obj = this.ViewState["X"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["X"] = value;
            }
        }

        /// <summary>
        /// The local y (addToStart) coordinate for this component if contained within a positioning container.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("4. BoxComponent")]
        [DefaultValue(0)]
        [Description("The local y (addToStart) coordinate for this component if contained within a positioning container.")]
        public virtual int Y
        {
            get
            {
                object obj = this.ViewState["Y"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["Y"] = value;
            }
        }

        /*  TabPanel specific properties/methods
            -----------------------------------------------------------------------------------------------*/

        private MenuCollection tabMenu;

        /// <summary>
        /// Tab's menu
        /// </summary>
        [Meta]
        [ConfigOption("tabMenu", typeof(ItemCollectionJsonConverter))]
        [Category("4. BoxComponent")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [Description("Tab's menu")]
        public virtual MenuCollection TabMenu
        {
            get
            {
                if (this.tabMenu == null)
                {
                    this.tabMenu = new MenuCollection();
                    this.tabMenu.AfterItemAdd += this.AfterItemAdd;
                    this.tabMenu.AfterItemRemove += this.AfterItemRemove;
                }

                return this.tabMenu;
            }
        }

        /// <summary>
        /// Defaults to false. True to hide tab's menu
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("4. BoxComponent")]
        [DefaultValue(false)]
        [DirectEventUpdate(MethodName = "SetTabMenuVisible")]
        [NotifyParentProperty(true)]
        [Description("Defaults to false. True to hide tab's menu.")]
        public virtual bool TabMenuHidden
        {
            get
            {
                object obj = this.ViewState["TabMenuHidden"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["TabMenuHidden"] = value;
            }
        }

        /// <summary>
        /// Show and Hide the Tab Menu option.
        /// </summary>
        /// <param name="hidden"></param>
        [Description("")]
        protected virtual void SetTabMenuVisible(bool hidden)
        {
            this.Call(hidden ? "hideTabMenu" : "showTabMenu");
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Sets the overflow on the content element of the component.
        /// </summary>
        [Description("Sets the overflow on the content element of the component.")]
        protected virtual void SetAutoScroll()
        {
            this.Call("setAutoScroll");
        }

        /// <summary>
        /// Sets the overflow on the content element of the component.
        /// </summary>
        /// <param name="scroll">True to allow the Component to auto scroll.</param>
        [Meta]
        [Description("Sets the overflow on the content element of the component.")]
        public virtual void SetAutoScroll(bool scroll)
        {
            this.Call("setAutoScroll", scroll);
        }

        /// <summary>
        /// Sets the page XY position of the component. To set the left and addToStart instead, use setPosition. This method fires the move event.
        /// </summary>
        [Meta]
        [Description("Sets the page XY position of the component. To set the left and addToStart instead, use setPosition. This method fires the move event.")]
        public virtual void SetPagePosition(Unit x, Unit y)
        {
            this.SetPagePosition(Convert.ToInt32(x.Value), Convert.ToInt32(y.Value));
        }

        /// <summary>
        /// Sets the page XY position of the component. To set the left and addToStart instead, use setPosition. This method fires the move event.
        /// </summary>
        [Meta]
        [Description("Sets the page XY position of the component. To set the left and addToStart instead, use setPosition. This method fires the move event.")]
        public virtual void SetPagePosition(int x, int y)
        {
            this.Call("setPagePosition", x, y);
        }

        /// <summary>
        /// Sets the left and addToStart of the component. To set the page XY position instead, use setPagePosition. This method fires the move event.
        /// </summary>
        [Meta]
        [Description("Sets the left and addToStart of the component. To set the page XY position instead, use setPagePosition. This method fires the move event.")]
        public virtual void SetPosition(Unit left, Unit top)
        {
            this.SetPosition(Convert.ToInt32(left.Value), Convert.ToInt32(top.Value));
        }

        /// <summary>
        /// Sets the left and addToStart of the component. To set the page XY position instead, use setPagePosition. This method fires the move event.
        /// </summary>
        [Meta]
        [Description("Sets the left and addToStart of the component. To set the page XY position instead, use setPagePosition. This method fires the move event.")]
        public virtual void SetPosition(int left, int top)
        {
            this.Call("setPosition", left, top);
        }

        /// <summary>
        /// Sets the width and height of the component. This method fires the resize event.
        /// </summary>
        [Meta]
        [Description("Sets the width and height of the component. This method fires the resize event.")]
        public virtual void SetSize(Unit width, Unit height)
        {
            this.SetSize(Convert.ToInt32(width.Value), Convert.ToInt32(height.Value));
        }

        /// <summary>
        /// Sets the width and height of the component. This method fires the resize event.
        /// </summary>
        [Meta]
        [Description("Sets the width and height of the component. This method fires the resize event.")]
        public virtual void SetSize(int width, int height)
        {
            this.Call("setSize", width, height);
        }

        /// <summary>
        /// Force the component's size to recalculate based on the underlying element's current height and width.
        /// </summary>
        [Meta]
        [Description("Force the component's size to recalculate based on the underlying element's current height and width.")]
        public virtual void SyncSize()
        {
            this.Call("syncSize");
        }

        /// <summary>
        /// Sets the current box measurements of the component's underlying element.
        /// </summary>
        [Meta]
        [Description("Sets the current box measurements of the component's underlying element.")]
        public virtual void UpdateBox(Unit x, Unit y, Unit width, Unit height)
        {
            this.UpdateBox(Convert.ToInt32(x.Value), Convert.ToInt32(y.Value), Convert.ToInt32(width.Value), Convert.ToInt32(height.Value));
        }
        
        /// <summary>
        /// Sets the current box measurements of the component's underlying element.
        /// </summary>
        [Meta]
        [Description("Sets the current box measurements of the component's underlying element.")]
        public virtual void UpdateBox(int x, int y, int width, int height)
        {
            JsonObject config = new JsonObject();

            config.Add("x", x);
            config.Add("y", y);
            config.Add("width", width);
            config.Add("height", height);

            this.Call("updateBox", config);
        }


        /*  Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Sets the height of the component. This method fires the resize event.
        /// </summary>
        [Description("Sets the height of the component. This method fires the resize event.")]
        protected virtual void SetHeight(Unit height)
        {
            this.SetHeight(Convert.ToInt32(height.Value));
        }

        /// <summary>
        /// Sets the height of the component. This method fires the resize event.
        /// </summary>
        [Description("Sets the height of the component. This method fires the resize event.")]
        protected virtual void SetHeight(int height)
        {
            this.Call("setHeight", height);
        }

        /// <summary>
        /// Sets the width of the component. This method fires the resize event.
        /// </summary>
        [Description("Sets the width of the component. This method fires the resize event.")]
        protected virtual void SetWidth(Unit width)
        {
            this.SetWidth(Convert.ToInt32(width.Value));
        }

        /// <summary>
        /// Sets the width of the component. This method fires the resize event.
        /// </summary>
        [Description("Sets the width of the component. This method fires the resize event.")]
        protected virtual void SetWidth(int width)
        {
            this.Call("setWidth", width);
        }
    }
}