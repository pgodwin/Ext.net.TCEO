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
    public partial class ElementListeners : ComponentListeners
    {
        private ComponentListener domActivate;

        /// <summary>
        /// Where supported. Fires when an element is activated, for instance, through a mouse click or a keypress.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("DOMActivate", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener DOMActivate
        {
            get
            {
                if (this.domActivate == null)
                {
                    this.domActivate = new ComponentListener();
                }

                return this.domActivate;
            }
        }

        private ComponentListener domAttrModified;

        /// <summary>
        /// Where supported. Fires when an attribute has been modified.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("DOMAttrModified", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener DOMAttrModified
        {
            get
            {
                if (this.domAttrModified == null)
                {
                    this.domAttrModified = new ComponentListener();
                }

                return this.domAttrModified;
            }
        }

        private ComponentListener domCharacterDataModified;

        /// <summary>
        /// Where supported. Fires when the character data has been modified.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("DOMCharacterDataModified", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener DOMCharacterDataModified
        {
            get
            {
                if (this.domCharacterDataModified == null)
                {
                    this.domCharacterDataModified = new ComponentListener();
                }

                return this.domCharacterDataModified;
            }
        }

        private ComponentListener domFocusIn;

        /// <summary>
        /// Where supported. Similar to HTML focus event, but can be applied to any focusable element.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("DOMFocusIn", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener DOMFocusIn
        {
            get
            {
                if (this.domFocusIn == null)
                {
                    this.domFocusIn = new ComponentListener();
                }

                return this.domFocusIn;
            }
        }

        private ComponentListener domFocusOut;

        /// <summary>
        /// Where supported. Similar to HTML blur event, but can be applied to any focusable element.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("DOMFocusOut", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener DOMFocusOut
        {
            get
            {
                if (this.domFocusOut == null)
                {
                    this.domFocusOut = new ComponentListener();
                }

                return this.domFocusOut;
            }
        }

        private ComponentListener domNodeInserted;

        /// <summary>
        /// Where supported. Fires when a node has been added as a child of another node.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("DOMNodeInserted", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener DOMNodeInserted
        {
            get
            {
                if (this.domNodeInserted == null)
                {
                    this.domNodeInserted = new ComponentListener();
                }

                return this.domNodeInserted;
            }
        }

        private ComponentListener domNodeInsertedIntoDocument;

        /// <summary>
        /// Where supported. Fires when a node is being inserted into a document.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("DOMNodeInsertedIntoDocument", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener DOMNodeInsertedIntoDocument
        {
            get
            {
                if (this.domNodeInsertedIntoDocument == null)
                {
                    this.domNodeInsertedIntoDocument = new ComponentListener();
                }

                return this.domNodeInsertedIntoDocument;
            }
        }

        private ComponentListener domNodeRemoved;

        /// <summary>
        /// Where supported. Fires when a descendant node of the element is removed.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("DOMNodeRemoved", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener DOMNodeRemoved
        {
            get
            {
                if (this.domNodeRemoved == null)
                {
                    this.domNodeRemoved = new ComponentListener();
                }

                return this.domNodeRemoved;
            }
        }

        private ComponentListener domNodeRemovedFromDocument;

        /// <summary>
        /// Where supported. Fires when a node is being removed from a document.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("DOMNodeRemovedFromDocument", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener DOMNodeRemovedFromDocument
        {
            get
            {
                if (this.domNodeRemovedFromDocument == null)
                {
                    this.domNodeRemovedFromDocument = new ComponentListener();
                }

                return this.domNodeRemovedFromDocument;
            }
        }

        private ComponentListener domSubtreeModified;

        /// <summary>
        /// Where supported. Fires when the subtree is modified.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("DOMSubtreeModified", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener DOMSubtreeModified
        {
            get
            {
                if (this.domSubtreeModified == null)
                {
                    this.domSubtreeModified = new ComponentListener();
                }

                return this.domSubtreeModified;
            }
        }

        private ComponentListener abort;

        /// <summary>
        /// Fires when an object/image is stopped from loading before completely loaded.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("abort", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener Abort
        {
            get
            {
                if (this.abort == null)
                {
                    this.abort = new ComponentListener();
                }

                return this.abort;
            }
        }

        private ComponentListener blur;

        /// <summary>
        /// Fires when an element loses focus either via the pointing device or by tabbing navigation.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("blur", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener Blur
        {
            get
            {
                if (this.blur == null)
                {
                    this.blur = new ComponentListener();
                }

                return this.blur;
            }
        }

        private ComponentListener change;

        /// <summary>
        /// Fires when a control loses the input focus and its value has been modified since gaining focus.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("change", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener Change
        {
            get
            {
                if (this.change == null)
                {
                    this.change = new ComponentListener();
                }

                return this.change;
            }
        }

        private ComponentListener click;

        /// <summary>
        /// Fires when a mouse click is detected within the element.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("click", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener Click
        {
            get
            {
                if (this.click == null)
                {
                    this.click = new ComponentListener();
                }

                return this.click;
            }
        }

        private ComponentListener dblclick;

        /// <summary>
        /// Fires when a mouse double click is detected within the element.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("dblclick", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener DblClick 
        {
            get
            {
                if (this.dblclick == null)
                {
                    this.dblclick = new ComponentListener();
                }

                return this.dblclick;
            }
        }

        private ComponentListener error;

        /// <summary>
        /// Fires when an object/image/frame cannot be loaded properly.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("error", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener Error
        {
            get
            {
                if (this.error == null)
                {
                    this.error = new ComponentListener();
                }

                return this.error;
            }
        }

        private ComponentListener focus;

        /// <summary>
        /// Fires when an element receives focus either via the pointing device or by tab navigation.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("focus", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener Focus
        {
            get
            {
                if (this.focus == null)
                {
                    this.focus = new ComponentListener();
                }

                return this.focus;
            }
        }

        private ComponentListener keydown;

        /// <summary>
        /// Fires when a keydown is detected within the element.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("keydown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener KeyDown
        {
            get
            {
                if (this.keydown == null)
                {
                    this.keydown = new ComponentListener();
                }

                return this.keydown;
            }
        }

        private ComponentListener keypress;

        /// <summary>
        /// Fires when a keypress is detected within the element.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("keypress", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener KeyPress
        {
            get
            {
                if (this.keypress == null)
                {
                    this.keypress = new ComponentListener();
                }

                return this.keypress;
            }
        }

        private ComponentListener keyup;

        /// <summary>
        /// Fires when a keyup is detected within the element.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("keyup", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener KeyUp
        {
            get
            {
                if (this.keyup == null)
                {
                    this.keyup = new ComponentListener();
                }

                return this.keyup;
            }
        }

        private ComponentListener load;

        /// <summary>
        /// Fires when the user agent finishes loading all content within the element. Only supported by window, frames, objects and images.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("load", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener Load
        {
            get
            {
                if (this.load == null)
                {
                    this.load = new ComponentListener();
                }

                return this.load;
            }
        }

        private ComponentListener mousedown;

        /// <summary>
        /// Fires when a mousedown is detected within the element.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mousedown", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener MouseDown
        {
            get
            {
                if (this.mousedown == null)
                {
                    this.mousedown = new ComponentListener();
                }

                return this.mousedown;
            }
        }

        private ComponentListener mouseenter;

        /// <summary>
        /// Fires when the mouse enters the element.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseenter", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener MouseEnter
        {
            get
            {
                if (this.mouseenter == null)
                {
                    this.mouseenter = new ComponentListener();
                }

                return this.mouseenter;
            }
        }

        private ComponentListener mouseleave;

        /// <summary>
        /// Fires when the mouse leaves the element.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseleave", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener MouseLeave
        {
            get
            {
                if (this.mouseleave == null)
                {
                    this.mouseleave = new ComponentListener();
                }

                return this.mouseleave;
            }
        }

        private ComponentListener mousemove;

        /// <summary>
        /// Fires when a mousemove is detected with the element.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mousemove", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener MouseMove
        {
            get
            {
                if (this.mousemove == null)
                {
                    this.mousemove = new ComponentListener();
                }

                return this.mousemove;
            }
        }

        private ComponentListener mouseout;

        /// <summary>
        /// Fires when a mouseout is detected with the element.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseout", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener MouseOut
        {
            get
            {
                if (this.mouseout == null)
                {
                    this.mouseout = new ComponentListener();
                }

                return this.mouseout;
            }
        }

        private ComponentListener mouseover;

        /// <summary>
        /// Fires when a mouseover is detected within the element.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseover", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener MouseOver
        {
            get
            {
                if (this.mouseover == null)
                {
                    this.mouseover = new ComponentListener();
                }

                return this.mouseover;
            }
        }

        private ComponentListener mouseup;

        /// <summary>
        /// Fires when a mouseup is detected within the element.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("mouseup", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener MouseUp
        {
            get
            {
                if (this.mouseup == null)
                {
                    this.mouseup = new ComponentListener();
                }

                return this.mouseup;
            }
        }

        private ComponentListener reset;

        /// <summary>
        /// Fires when a form is reset.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("reset", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener Reset
        {
            get
            {
                if (this.reset == null)
                {
                    this.reset = new ComponentListener();
                }

                return this.reset;
            }
        }

        private ComponentListener resize;

        /// <summary>
        /// Fires when a document view is resized.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("resize", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener Resize
        {
            get
            {
                if (this.resize == null)
                {
                    this.resize = new ComponentListener();
                }

                return this.resize;
            }
        }

        private ComponentListener scroll;

        /// <summary>
        /// Fires when a document view is scrolled.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("scroll", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener Scroll
        {
            get
            {
                if (this.scroll == null)
                {
                    this.scroll = new ComponentListener();
                }

                return this.scroll;
            }
        }

        private ComponentListener select;

        /// <summary>
        /// Fires when a user selects some text in a text field, including input and textarea.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("select", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener Select
        {
            get
            {
                if (this.select == null)
                {
                    this.select = new ComponentListener();
                }

                return this.select;
            }
        }

        private ComponentListener submit;

        /// <summary>
        /// Fires when a form is submitted.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("submit", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener Submit
        {
            get
            {
                if (this.submit == null)
                {
                    this.submit = new ComponentListener();
                }

                return this.submit;
            }
        }

        private ComponentListener unload;

        /// <summary>
        /// Fires when the user agent removes all content from a window or frame. For elements, it fires when the target element or any of its content has been removed.
        /// </summary>
        [ListenerArgument(0, "e", typeof(object), "The Ext.EventObject encapsulating the DOM event.")]
        [ListenerArgument(1, "t", typeof(object), "HtmlElement. The target of the event.")]
        [ListenerArgument(2, "o", typeof(object), "The options configuration passed to the addListener call.")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [ConfigOption("unload", typeof(ListenerJsonConverter))]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        public virtual ComponentListener Unload
        {
            get
            {
                if (this.unload == null)
                {
                    this.unload = new ComponentListener();
                }

                return this.unload;
            }
        }
    }
}