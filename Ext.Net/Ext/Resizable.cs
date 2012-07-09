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

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// Applies drag handles to an element to make it resizable.
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:Resizable runat=\"server\" />")]
    [ToolboxBitmap(typeof(Resizable), "Build.ToolboxIcons.Resizable.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("Applies drag handles to an element to make it resizable.")]
    public partial class Resizable : Observable
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Resizable() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.Resizable";
            }
        }

        internal override string GetClientConstructor(bool instanceOnly, string body)
        {
            string template = (instanceOnly) ? "new {1}({2},{3})" : "this.{0}=new {1}({2},{3});";

            return string.Format(template, this.ClientID, "Ext.Resizable", this.ElementProxy, body ?? this.InitialConfig);
        }

        private string ElementProxy
        {
            get
            {
                string parsedElement = TokenUtils.ParseTokens(this.Element, this);

                if (TokenUtils.IsRawToken(parsedElement))
                {
                    return TokenUtils.ReplaceRawToken(parsedElement);
                }

                return "\"".ConcatWith(parsedElement, "\"");
            }
        }

        /// <summary>
        /// The id or element to resize
        /// </summary>
        [Meta]
        [Category("3. Resizable")]
        [DefaultValue("")]
        [Description("The id or element to resize")]
        public virtual string Element
        {
            get
            {
                return (string)this.ViewState["Element"] ?? "";
            }
            set
            {
                this.ViewState["Element"] = value;
            }
        }

        /// <summary>
        /// The array [width, height] with values to be added to the resize operation's new size (defaults to [0, 0])
        /// </summary>
        [Meta]
        [Category("3. Resizable")]
        [DefaultValue(typeof(Size), "")]
        [NotifyParentProperty(true)]
        [Description("The array [width, height] with values to be added to the resize operation's new size (defaults to [0, 0])")]
        public Size Adjustments
        {
            get
            {
                object obj = this.ViewState["Adjustments"];
                return obj != null ? (Size)obj : Size.Empty;
            }
            set
            {
                this.ViewState["Adjustments"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("adjustments", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected string AdjustmentsProxy
        {
            get
            {
                if (this.Adjustments.IsEmpty)
                {
                    return "";
                }

                return "[".ConcatWith(this.Adjustments.Width, ",", this.Adjustments.Height, "]");
            }
        }

        /// <summary>
        /// True to animate the resize (not compatible with dynamic sizing, defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to animate the resize (not compatible with dynamic sizing, defaults to false).")]
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
        /// True to disable mouse tracking. This is only applied at config time. (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to disable mouse tracking. This is only applied at config time. (defaults to false)")]
        public virtual bool DisableTrackOver
        {
            get
            {
                object obj = this.ViewState["DisableTrackOver"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["DisableTrackOver"] = value;
            }
        }

        /// <summary>
        /// Convenience to initialize drag drop (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Convenience to initialize drag drop (defaults to false)")]
        public virtual bool Draggable
        {
            get
            {
                object obj = this.ViewState["Draggable"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Draggable"] = value;
            }
        }

        /// <summary>
        /// Animation duration if animate = true (defaults to .35)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(0.35)]
        [Description("Animation duration if animate = true (defaults to .35)")]
        public virtual double Duration
        {
            get
            {
                object obj = this.ViewState["Duration"];
                return (obj == null) ? 0.35 : (double)obj;
            }
            set
            {
                this.ViewState["Duration"] = value;
            }
        }

        /// <summary>
        /// True to resize the element while dragging instead of using a proxy (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to resize the element while dragging instead of using a proxy (defaults to false)")]
        public virtual bool Dynamic
        {
            get
            {
                object obj = this.ViewState["Dynamic"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Dynamic"] = value;
            }
        }

        /// <summary>
        /// Animation easing if animate = true (defaults to 'easeOutStrong')
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ToCamelLower)]
        [Category("3. Resizable")]
        [DefaultValue(Easing.EaseOutStrong)]
        [Description("Animation easing if animate = true (defaults to 'easeOutStrong')")]
        public virtual Easing Easing
        {
            get
            {
                object obj = this.ViewState["Easing"];
                return (obj == null) ? Easing.EaseOutStrong : (Easing)obj;
            }
            set
            {
                this.ViewState["Easing"] = value;
            }
        }

        /// <summary>
        /// False to disable resizing (defaults to true)
        /// </summary>
        [Meta]
        [ConfigOption("enabled")]
        [Category("3. Resizable")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("False to disable resizing (defaults to true)")]
        public virtual bool EnabledResizing
        {
            get
            {
                object obj = this.ViewState["EnabledResizing"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["EnabledResizing"] = value;
            }
        }

        /// <summary>
        /// String consisting of the resize handles to display (defaults to undefined)
        /// </summary>
        [Meta]
        [Category("3. Resizable")]
        [DefaultValue(ResizeHandle.None)]
        [Description("String consisting of the resize handles to display (defaults to undefined)")]
        public virtual ResizeHandle Handles
        {
            get
            {
                object obj = this.ViewState["Handles"];
                return (obj == null) ? ResizeHandle.None : (ResizeHandle)obj;
            }
            set
            {
                this.ViewState["Handles"] = value;
            }
        }

        /// <summary>
        ///  String consisting of the resize handles to display (defaults to undefined). Specify either 'all' or any of 'n s e w ne nw se sw'.
        /// </summary>
        [Meta]
        [ConfigOption("handles")]
        [Category("3. Resizable")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("String consisting of the resize handles to display (defaults to undefined). Specify either 'all' or any of 'n s e w ne nw se sw'.")]
        public virtual string HandlesSummary
        {
            get
            {
                return (string)this.ViewState["HandlesSummary"] ?? "";
            }
            set
            {
                this.ViewState["HandlesSummary"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("handles")]
        [DefaultValue("")]
        [Description("")]
        protected string HandlesProxy
        {
            get
            {
                switch(this.Handles)
                {
                    case ResizeHandle.None:
                        return "";
                    case ResizeHandle.North:
                        return "n";
                    case ResizeHandle.South:
                        return "s";
                    case ResizeHandle.East:
                        return "e";
                    case ResizeHandle.West:
                        return "w";
                    case ResizeHandle.NorthWest:
                        return "nw";
                    case ResizeHandle.SouthWest:
                        return "sw";
                    case ResizeHandle.SouthEast:
                        return "se";
                    case ResizeHandle.NorthEast:
                        return "ne";
                    case ResizeHandle.All:
                        return "all";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// The width of this component in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The width of the element in pixels (defaults to null)")]
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
        /// The height of this component in pixels (defaults to auto).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        [Description("The height of the element in pixels (defaults to null)")]
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
        /// The increment to snap the height resize in pixels (dynamic must be true, defaults to 0).
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(0)]
        [Description("The increment to snap the height resize in pixels (dynamic must be true, defaults to 0).")]
        public virtual int HeightIncrement
        {
            get
            {
                object obj = this.ViewState["HeightIncrement"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["HeightIncrement"] = value;
            }
        }

        /// <summary>
        /// The maximum height for the element (defaults to 10000)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(10000)]
        [Description("The maximum height for the element (defaults to 10000)")]
        public virtual int MaxHeight
        {
            get
            {
                object obj = this.ViewState["MaxHeight"];
                return (obj == null) ? 10000 : (int)obj;
            }
            set
            {
                this.ViewState["MaxHeight"] = value;
            }
        }

        /// <summary>
        /// The maximum width for the element (defaults to 10000)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(10000)]
        [Description("The maximum width for the element (defaults to 10000)")]
        public virtual int MaxWidth
        {
            get
            {
                object obj = this.ViewState["MaxWidth"];
                return (obj == null) ? 10000 : (int)obj;
            }
            set
            {
                this.ViewState["MaxWidth"] = value;
            }
        }

        /// <summary>
        /// The minimum height for the element (defaults to 5)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(5)]
        [Description("The minimum height for the element (defaults to 5)")]
        public virtual int MinHeight
        {
            get
            {
                object obj = this.ViewState["MinHeight"];
                return (obj == null) ? 5 : (int)obj;
            }
            set
            {
                this.ViewState["MinHeight"] = value;
            }
        }

        /// <summary>
        /// The minimum width for the element (defaults to 5)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(5)]
        [Description("The minimum width for the element (defaults to 5)")]
        public virtual int MinWidth
        {
            get
            {
                object obj = this.ViewState["MinWidth"];
                return (obj == null) ? 5 : (int)obj;
            }
            set
            {
                this.ViewState["MinWidth"] = value;
            }
        }

        /// <summary>
        /// The minimum allowed page X for the element (only used for west resizing, defaults to 0)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(0)]
        [Description("The minimum allowed page X for the element (only used for west resizing, defaults to 0)")]
        public virtual int MinX
        {
            get
            {
                object obj = this.ViewState["MinX"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["MinX"] = value;
            }
        }

        /// <summary>
        /// The minimum allowed page Y for the element (only used for north resizing, defaults to 0)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(0)]
        [Description("The minimum allowed page Y for the element (only used for north resizing, defaults to 0)")]
        public virtual int MinY
        {
            get
            {
                object obj = this.ViewState["MinY"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["MinY"] = value;
            }
        }

        /// <summary>
        /// True to ensure that the resize handles are always visible, false to display them only when the user mouses over the resizable borders. This is only applied at config time. (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to ensure that the resize handles are always visible, false to display them only when the user mouses over the resizable borders. This is only applied at config time. (defaults to false)")]
        public virtual bool Pinned
        {
            get
            {
                object obj = this.ViewState["Pinned"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Pinned"] = value;
            }
        }

        /// <summary>
        /// True to preserve the original ratio between height and width during resize (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to preserve the original ratio between height and width during resize (defaults to false)")]
        public virtual bool PreserveRatio
        {
            get
            {
                object obj = this.ViewState["PreserveRatio"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["PreserveRatio"] = value;
            }
        }

        /// <summary>
        /// id of element to resize
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("id of element to resize")]
        public virtual string ResizeChild
        {
            get
            {
                return (string)this.ViewState["ResizeChild"] ?? "";
            }
            set
            {
                this.ViewState["ResizeChild"] = value;
            }
        }

        /// <summary>
        /// True for transparent handles. This is only applied at config time. (defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True for transparent handles. This is only applied at config time. (defaults to false)")]
        public virtual bool Transparent
        {
            get
            {
                object obj = this.ViewState["Transparent"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Transparent"] = value;
            }
        }

        /// <summary>
        /// The increment to snap the width resize in pixels (dynamic must be true, defaults to 0)
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [DefaultValue(0)]
        [Description("The increment to snap the width resize in pixels (dynamic must be true, defaults to 0)")]
        public virtual int WidthIncrement
        {
            get
            {
                object obj = this.ViewState["WidthIncrement"];
                return (obj == null) ? 0 : (int)obj;
            }
            set
            {
                this.ViewState["WidthIncrement"] = value;
            }
        }

        /// <summary>
        /// True to wrap an element with a div if needed (required for textareas and images, defaults to false)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("3. Resizable")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("True to wrap an element with a div if needed (required for textareas and images, defaults to false)")]
        public virtual bool Wrap
        {
            get
            {
                object obj = this.ViewState["Wrap"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["Wrap"] = value;
            }
        }

        private JFunction resizeElement;

        /// <summary>
        /// Performs resizing of the associated Element. 
        /// This method is called internally by this class, and should not be called by user code.
        /// If a Resizable is being used to resize an Element which encapsulates a more complex UI component such as a Panel,
        /// this method may be overridden by specifying an implementation as a config option to provide appropriate behaviour
        /// at the end of the resize operation on mouseup, for example resizing the Panel, and relaying the Panel's content.
        /// The new area to be resized to is available by examining the state of the proxy Element.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Raw)]
        [Category("3. Resizable")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [Description("Performs resizing of the associated Element. ")]
        public virtual JFunction ResizeElement
        {
            get
            {
                if (this.resizeElement == null)
                {
                    this.resizeElement = new JFunction();
                }

                return this.resizeElement;
            }
        }

        private ResizableListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("Client-side JavaScript Event Handlers")]
        public ResizableListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new ResizableListeners();
                }

                return this.listeners;
            }
        }

        private ResizableDirectEvents directEvents;

        /// <summary>
        /// Server-side DirectEvent Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [ViewStateMember]
        [Description("Server-side DirectEventHandlers")]
        public ResizableDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new ResizableDirectEvents();
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Destroys this resizable
        /// </summary>
        public virtual void Destroy()
        {
            this.Call("destroy");
        }

        /// <summary>
        /// Destroys this resizable. If the element was wrapped and removeEl is not true then the element remains.
        /// </summary>
        /// <param name="removeEl">(optional) true to remove the element from the DOM</param>
        public virtual void Destroy(bool removeEl)
        {
            this.Call("destroy", removeEl);
        }

        /// <summary>
        /// Perform a manual resize and fires the 'resize' event.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public virtual void ResizeTo(int width, int height)
        {
            this.Call("resizeTo", width, height);
        }
    }
}