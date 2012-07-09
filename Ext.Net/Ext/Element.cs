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
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class Element : ScriptClass
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static implicit operator Element(Control control)
        {
            return control.ToElement();
        }

        /*  Ctor
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Element(string el)
        {
            this.el = el;
            this.id = "_e" + this.GetID();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Element(string el, bool chaining)
            : this(el)
        {
            this.Chaining = chaining;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Element(Component el)
        {
            this.el = el.ClientID.ConcatWith(".el");
            this.id = "_e" + this.GetID();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public Element(Component el, bool chaining)
            : this(el)
        {
            this.Chaining = chaining;
        }


        /*  Dom
            -----------------------------------------------------------------------------------------------*/

        private Dom dom = null;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual Dom Dom
        {
            get
            {
                if (this.dom == null)
                {
                    this.dom = new Dom(this);
                }

                return this.dom;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual Dom GetDom()
        {
            return this.Dom;
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/

        private readonly string el;
        private int delayBlockOpen;
        private bool chainStarted;

        /// <summary>
        /// Retrieves Ext.Element objects.
        /// This method does not retrieve Components. This method retrieves Ext.Element objects which encapsulate DOM elements.
        /// Uses simple caching to consistently return the same object. Automatically fixes if an object was recreated with the same id via AJAX or DOM.
        /// </summary>
        /// <param name="control">The Control to get as an Element object.</param>
        /// <returns>Element</returns>
        [Description("Retrieves Ext.Element objects.")]
        public static Element Get(Control control)
        {
            return Element.Get(control.ClientID);
        }

        /// <summary>
        /// Retrieves Ext.Element objects.
        /// This method does not retrieve Components. This method retrieves Ext.Element objects which encapsulate DOM elements.
        /// Uses simple caching to consistently return the same object. Automatically fixes if an object was recreated with the same id via AJAX or DOM.
        /// </summary>
        /// <param name="id">The id of the node</param>
        /// <returns>Element</returns>
        [Description("Retrieves Ext.Element objects.")]
        public static Element Get(string id)
        {
            return new Element("Ext.get({0})".FormatWith(JSON.Serialize(id)));
        }

        /// <summary>
        /// Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element - the dom node can be overwritten by other code. Shorthand of Ext.Element.fly
        /// Use this to make one-time references to DOM elements which are not going to be accessed again either by application code, or by Ext's classes. If accessing an element which will be processed regularly, then Ext.get will be more appropriate to take advantage of the caching provided by the Ext.Element class.
        /// </summary>
        /// <param name="id">The id of the node</param>
        /// <returns>Element</returns>
        [Description("Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element - the dom node can be overwritten by other code. Shorthand of Ext.Element.fly")]
        public static Element Fly(string id)
        {
            return new Element("Ext.fly({0})".FormatWith(JSON.Serialize(id)));
        }

        /// <summary>
        /// Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element - the dom node can be overwritten by other code. Shorthand of Ext.Element.fly
        /// Use this to make one-time references to DOM elements which are not going to be accessed again either by application code, or by Ext's classes. If accessing an element which will be processed regularly, then Ext.get will be more appropriate to take advantage of the caching provided by the Ext.Element class.
        /// </summary>
        /// <param name="control">The Control to get as an Element object.</param>
        /// <returns>Element</returns>
        [Description("Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element - the dom node can be overwritten by other code. Shorthand of Ext.Element.fly")]
        public static Element Fly(Control control)
        {
            return Element.Fly(control.ClientID);
        }

        /// <summary>
        /// Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element - the dom node can be overwritten by other code. Shorthand of Ext.Element.fly
        /// Use this to make one-time references to DOM elements which are not going to be accessed again either by application code, or by Ext's classes. If accessing an element which will be processed regularly, then Ext.get will be more appropriate to take advantage of the caching provided by the Ext.Element class.
        /// </summary>
        /// <param name="id">The id of the node</param>
        /// <param name="named">Allows for creation of named reusable flyweights to prevent conflicts</param>
        /// <returns>Element</returns>
        [Description("Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element - the dom node can be overwritten by other code. Shorthand of Ext.Element.fly")]
        public static Element Fly(string id, string named)
        {
            return new Element("Ext.fly({0},{1})".FormatWith(JSON.Serialize(id), JSON.Serialize(named)));
        }

        /// <summary>
        /// Returns the current document body as an Ext.Element.
        /// </summary>
        /// <returns>Element</returns>
        [Description("Returns the current document body as an Ext.Element.")]
        public static Element Body()
        {
            return new Element("Ext.getBody()");
        }

        /// <summary>
        /// Returns the current document body as an Ext.Element.
        /// </summary>
        /// <returns>Element</returns>
        [Description("Returns the current document body as an Ext.Element.")]
        public static Element Form()
        {
            Page p = X.Js.Page;
            if (p != null && p.Form != null)
            {
                return Element.Get(p.Form);
            }
            return null;
        }

        /// <summary>
        /// Returns the current HTML document object as an Ext.Element.
        /// </summary>
        /// <returns>Element</returns>
        [Description("Returns the current HTML document object as an Ext.Element.")]
        public static Element Document()
        {
            return new Element("Ext.getDoc()");
        }

        /// <summary>
        /// Returns the current HTML head object as an Ext.Element.
        /// </summary>
        /// <returns></returns>
        [Description("Returns the current HTML head object as an Ext.Element.")]
        public static Element Head()
        {
            return new Element("Ext.get(document.getElementsByTagName(\"head\")[0])");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void Call(string name)
        {
            this.Call(name, null);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override void Call(string name, params object[] args)
        {
            if (this.Chaining)
            {
                if (!this.chainStarted)
                {
                    this.chainStarted = true;
                    this.Buffer.Append(this.FormatCallTemplate("{0}.{1}({2})", name, args));  
                }
                else
                {
                    this.Buffer.Append(this.FormatCallTemplate(".{1}({2})", name, args));  
                }
            }
            else
            {
                if (this.Delay > 0)
                {
                    this.CallDelay(name, args);
                }
                else
                {
                    base.Call(name, args);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void CallDelay(string name, params object[] args)
        {
            this.CallTemplate("{0}.{1}.defer({2}, {0}, [{3}]);", this.InstanceOf, name, this.Delay, this.FormatArgs(args));
        }

        private bool isVarRegistered;

        internal void RegisterVar()
        {
            if (!this.isVarRegistered)
            {
                this.AddScript("var {0}={1};", this.id, this.el);
                this.isVarRegistered = true;
            }
        }

        private static readonly object idCounter = new object();

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual int GetID()
        {
            lock (idCounter)
            {
                object obj = HttpContext.Current.Items["_uniqueElementId"];
                int id = 0;

                if (obj != null)
                {
                    id = (int)obj;
                    id++;
                }

                HttpContext.Current.Items["_uniqueElementId"] = id;
                return id;
            }
        }

        private StringBuilder buffer;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual StringBuilder Buffer
        {
            get
            {
                if (this.buffer == null)
                {
                    this.buffer = new StringBuilder();
                }

                return this.buffer;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static string ConvertToSafeJSHtml(string html)
        {
            string[] lines = html.Split(new string[] { "\r\n", "\n", "\r", "\t" }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length == 0)
            {
                return "";
            }

            return JSON.Serialize(lines).ConcatWith(".join('')");
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string Descriptor
        {
            get
            {
                return this.isVarRegistered ? this.ID : this.RealDescriptor;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string RealDescriptor
        {
            get
            {
                return this.el;
            }
        }

        private readonly string id;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual string ID
        {
            get
            {
                return this.id;
            }
        }

        private bool chaining;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual bool Chaining
        {
            get
            {
                return this.chaining;
            }
            set
            {
                this.chaining = value;
            }
        }

        private Stack<int> delays = new Stack<int>();

        private int delay;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public virtual int Delay
        {
            get
            {
                return this.delay;
            }
            set
            {
                if (this.Chaining)
                {
                    if (this.delayBlockOpen > 0 && value == 0)
                    {
                        this.delayBlockOpen--;
                        this.Buffer.AppendFormat("}}).defer({0});", this.delays.Pop());
                    }
                    else if (value > 0)
                    {
                        this.delayBlockOpen++;
                        this.delays.Push(value);

                        if (this.chainStarted)
                        {
                            this.chainStarted = false;
                            this.Buffer.Append(";");
                        }
                        this.Buffer.Append("(function(){");
                    }
                }

                this.delay = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override string InstanceOf
        {
            get 
            {
                this.RegisterVar();
                return id;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override string ToScript()
        {
            this.RegisterVar();

            if (this.Buffer.Length == 0)
            {
                return this.Descriptor;
            }
            
            this.Buffer.Append(";");
            
            while (this.delayBlockOpen > 0)
            {
                this.Delay = 0;
            }

            string script = this.Buffer.ToString();
            
            this.Buffer.Length = 0;
            this.chainStarted = false;
    
            return script;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void EnsureChaining()
        {
            if (!this.Chaining)
            {
                throw new InvalidOperationException("The method should only be called when Chaining is true.");
            }
        }

        
        #region Elements methods

        /// <summary>
        /// Turn on delay execution for subsequent methods calling
        /// </summary>
        /// <param name="delay">Delay amount</param>
        /// <returns>this element</returns>
        [Description("Turn on delay execution for subsequent methods calling")]
        public virtual Element DelayOn(int delay)
        {
            this.Delay = delay;
            return this;
        }

        /// <summary>
        /// Turn off delay execution
        /// </summary>
        /// <returns>this element</returns>
        [Description("Turn off delay execution")]
        public virtual Element DelayOff()
        {
            this.Delay = 0;
            return this;
        }

        /// <summary>
        /// Turn on script chaining
        /// </summary>
        /// <returns>this element</returns>
        [Description("Turn on script chaining")]
        public virtual Element ChainOn()
        {
            this.Chaining = true;
            return this;
        }

        /// <summary>
        /// Turn off script chaining
        /// </summary>
        /// <returns>this element</returns>
        [Description("Turn off script chaining")]
        public virtual Element ChainOff()
        {
            this.Chaining = false;
            return this;
        }

        /// <summary>
        /// Ends the existing method chaining and starts a new
        /// </summary>
        /// <returns>this element</returns>
        protected virtual Element ResetChain()
        {
            if (this.chainStarted)
            {
                this.Buffer.Append(";" + this.id);
            }

            return this;
        }


        /// <summary>
        /// Return original element, uses with Chaining only
        /// </summary>
        /// <returns>This element</returns>
        [Description("Return original element, used with Chaining only")]
        public virtual Element Up()
        {
            this.EnsureChaining();
            return this.ResetChain();
        }

        /// <summary>
        /// Adds one or more CSS classes to the element. Duplicate classes are automatically filtered out.
        /// </summary>
        /// <param name="className">The CSS class to add</param>
        /// <returns>This element</returns>
        [Description("Adds one or more CSS classes to the element. Duplicate classes are automatically filtered out.")]
        public virtual Element AddClass(string className)
        {
            this.Call("addClass", className);
            return this;
        }

        /// <summary>
        /// Adds one or more CSS classes to the element. Duplicate classes are automatically filtered out.
        /// </summary>
        /// <param name="classNames">The array of CSS classes to add</param>
        /// <returns>This element</returns>
        [Description("Adds one or more CSS classes to the element. Duplicate classes are automatically filtered out.")]
        public virtual Element AddClass(string[] classNames)
        {
            this.Call("addClass", classNames);
            return this;
        }

        /// <summary>
        /// Sets up event handlers to add and remove a css class when the mouse is down and then up on this element (a click effect)
        /// </summary>
        /// <param name="className">The CSS class to add on click</param>
        /// <returns>This element</returns>
        [Description("Sets up event handlers to add and remove a css class when the mouse is down and then up on this element (a click effect)")]
        public virtual Element AddClassOnClick(string className)
        {
            this.Call("addClassOnClick", className);
            return this;
        }

        /// <summary>
        /// Sets up event handlers to add and remove a css class when this element has the focus
        /// </summary>
        /// <param name="className">The CSS class to add on focus</param>
        /// <returns>This element</returns>
        [Description("Sets up event handlers to add and remove a css class when this element has the focus")]
        public virtual Element AddClassOnFocus(string className)
        {
            this.Call("addClassOnFocus", className);
            return this;
        }

        /// <summary>
        /// Sets up event handlers to add and remove a css class when the mouse is over this element
        /// </summary>
        /// <param name="className">The CSS class to add on over</param>
        /// <returns>This element</returns>
        [Description("Sets up event handlers to add and remove a css class when the mouse is over this element")]
        public virtual Element AddClassOnOver(string className)
        {
            this.Call("addClassOnOver", className);
            return this;
        }

        /// <summary>
        /// Convenience method for constructing a KeyMap
        /// </summary>
        /// <param name="key">Key config</param>
        /// <returns>this element</returns>
        [Description("Convenience method for constructing a KeyMap")]
        public virtual Element AddKeyListener(KeyBinding key)
        {
            this.Call("addKeyListenerEx", new ClientConfig().Serialize(key));
            return this;
        }

        /// <summary>
        /// Appends an events handlers to this element.
        /// </summary>
        /// <param name="listeners">Listeners object</param>
        /// <returns>This element</returns>
        [Description("Appends an events handlers to this element.")]
        public virtual Element AddListener(ElementListeners listeners)
        {
            this.Call("on", new JRawValue(new ClientConfig().Serialize(listeners, true)));
            return this;
        }

        /// <summary>
        /// Appends an event handler to this element.
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes.
        /// This function is passed the following parameters:
        ///    evt : EventObject
        ///    The EventObject describing the event.
        ///    el : Element
        ///    The Element which was the target of the event. Note that this may be filtered by using the delegate option.
        ///    o : Object
        ///    The options object from the addListener call.
        /// </param>
        /// </summary>
        [Description("Appends an event handler to this element.")]
        public virtual Element AddListener(string eventName, string fn)
        {
            this.Call("on", eventName.ToLower(), new JRawValue(TokenUtils.ParseAndNormalize(fn).Trim('"')));
            return this;
        }

        /// <summary>
        /// Appends an event handler to this element.
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invoke</param>
        /// </summary>
        [Description("Appends an event handler to this element.")]
        public virtual Element AddListener(string eventName, JFunction fn)
        {
            this.Call("on", eventName.ToLower(), fn);
            return this;
        }

        /// <summary>
        /// Appends an event handler to this element.
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes.
        /// This function is passed the following parameters:
        ///    evt : EventObject
        ///    The EventObject describing the event.
        ///    el : Element
        ///    The Element which was the target of the event. Note that this may be filtered by using the delegate option.
        ///    o : Object
        ///    The options object from the addListener call.
        /// </param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to this Element..</param>
        /// </summary>
        [Description("Appends an event handler to this element.")]
        public virtual Element AddListener(string eventName, string fn, string scope)
        {
            this.Call("on", eventName.ToLower(), new JRawValue(TokenUtils.ParseAndNormalize(fn).Trim('"')), new JRawValue(scope));
            return this;
        }

        /// <summary>
        /// Appends an event handler to this element.
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to this Element..</param>
        /// </summary>
        [Description("Appends an event handler to this element.")]
        public virtual Element AddListener(string eventName, JFunction fn, string scope)
        {
            this.Call("on", eventName.ToLower(), fn, new JRawValue(scope));
            return this;
        }

        /// <summary>
        /// Appends an event handler to this element.
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes.
        /// This function is passed the following parameters:
        ///    evt : EventObject
        ///    The EventObject describing the event.
        ///    el : Element
        ///    The Element which was the target of the event. Note that this may be filtered by using the delegate option.
        ///    o : Object
        ///    The options object from the addListener call.
        /// </param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to this Element.</param>
        /// <param name="options">An object containing handler configuration properties. </param>
        /// </summary>
        [Description("Appends an event handler to this element.")]
        public virtual Element AddListener(string eventName, string fn, string scope, HandlerConfig options)
        {
            this.Call("on", eventName, new JRawValue(TokenUtils.ParseAndNormalize(fn).Trim('"')), new JRawValue(scope), new JRawValue(options.ToJsonString()));
            return this;
        }

        /// <summary>
        /// Appends an event handler to this element.
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to this Element.</param>
        /// <param name="options">An object containing handler configuration properties. </param>
        /// </summary>
        [Description("Appends an event handler to this element.")]
        public virtual Element AddListener(string eventName, JFunction fn, string scope, HandlerConfig options)
        {
            this.Call("on", eventName, fn, new JRawValue(scope), new JRawValue(options.ToJsonString()));
            return this;
        }

        /// <summary>
        /// Appends an events handlers to this element.
        /// </summary>
        /// <param name="listeners">Listeners object</param>
        /// <returns>This element</returns>
        [Description("Appends an events handlers to this element.")]
        public virtual Element On(ElementListeners listeners)
        {
            return this.AddListener(listeners);
        }

        /// <summary>
        /// Appends an event handler to this element.
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes.
        /// This function is passed the following parameters:
        ///    evt : EventObject
        ///    The EventObject describing the event.
        ///    el : Element
        ///    The Element which was the target of the event. Note that this may be filtered by using the delegate option.
        ///    o : Object
        ///    The options object from the addListener call.
        /// </param>
        /// </summary>
        [Description("Appends an event handler to this element.")]
        public virtual Element On(string eventName, string fn)
        {
            return this.AddListener(eventName, fn);
        }

        /// <summary>
        /// Appends an event handler to this element.
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invoke</param>
        /// </summary>
        [Description("Appends an event handler to this element.")]
        public virtual Element On(string eventName, JFunction fn)
        {
            return this.AddListener(eventName, fn);
        }

        /// <summary>
        /// Appends an event handler to this element.
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes.
        /// This function is passed the following parameters:
        ///    evt : EventObject
        ///    The EventObject describing the event.
        ///    el : Element
        ///    The Element which was the target of the event. Note that this may be filtered by using the delegate option.
        ///    o : Object
        ///    The options object from the addListener call.
        /// </param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to this Element..</param>
        /// </summary>
        [Description("Appends an event handler to this element.")]
        public virtual Element On(string eventName, string fn, string scope)
        {
            return this.AddListener(eventName, fn, scope);
        }

        /// <summary>
        /// Appends an event handler to this element.
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to this Element..</param>
        /// </summary>
        [Description("Appends an event handler to this element.")]
        public virtual Element On(string eventName, JFunction fn, string scope)
        {
            return this.AddListener(eventName, fn, scope);
        }

        /// <summary>
        /// Appends an event handler to this element.
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes.
        /// This function is passed the following parameters:
        ///    evt : EventObject
        ///    The EventObject describing the event.
        ///    el : Element
        ///    The Element which was the target of the event. Note that this may be filtered by using the delegate option.
        ///    o : Object
        ///    The options object from the addListener call.
        /// </param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to this Element.</param>
        /// <param name="options">An object containing handler configuration properties. </param>
        /// </summary>
        [Description("Appends an event handler to this element.")]
        public virtual Element On(string eventName, string fn, string scope, HandlerConfig options)
        {
            return this.AddListener(eventName, fn, scope, options);
        }

        /// <summary>
        /// Appends an event handler to this element.
        /// <param name="eventName">The type of event to handle</param>
        /// <param name="fn">The handler function the event invokes.</param>
        /// <param name="scope">The scope (this reference) in which the handler function is executed. If omitted, defaults to this Element.</param>
        /// <param name="options">An object containing handler configuration properties. </param>
        /// </summary>
        [Description("Appends an event handler to this element.")]
        public virtual Element On(string eventName, JFunction fn, string scope, HandlerConfig options)
        {
            return this.AddListener(eventName, fn, scope, options);
        }

        /// <summary>
        /// Recursively removes all previous added listeners from this element and its children
        /// </summary>
        /// <returns>this Element</returns>
        [Description("Recursively removes all previous added listeners from this element and its children")]
        public virtual Element PurgeAllListeners()
        {
            this.Call("purgeAllListeners");
            return this;
        }
        
        /// <summary>
        /// Aligns this element with another element relative to the specified anchor points. If the other element is the document it aligns it to the viewport. 
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.
        /// The position parameter is optional, and can be specified in any one of the following formats:
        /// Blank: Defaults to aligning the element's top-left corner to the target's bottom-left corner ("tl-bl").
        /// One anchor (deprecated): The passed anchor position is used as the target element's anchor point. The element being aligned will position its top-left corner (tl) to that point. This method has been deprecated in favor of the newer two anchor syntax below.
        /// Two anchors: If two values from the table below are passed separated by a dash, the first value is used as the element's anchor point, and the second value is used as the target's anchor point.
        /// In addition to the anchor points, the position parameter also supports the "?" character. If "?" is passed at the end of the position string, the element will attempt to align as specified, but the position will be adjusted to constrain to the viewport if necessary. Note that the element being aligned might be swapped to align to a different position than that specified in order to enforce the viewport constraints. Following are all of the supported anchor positions:
        /// Value  Description
        /// -----  -----------------------------
        /// tl     The top left corner (default)
        /// t      The center of the top edge
        /// tr     The top right corner
        /// l      The center of the left edge
        /// c      In the center of the element
        /// r      The center of the right edge
        /// bl     The bottom left corner
        /// b      The center of the bottom edge
        /// br     The bottom right corner
        /// Example Usage:
        ///    align el to other-el using the default positioning ("tl-bl", non-constrained)
        ///    el.alignTo("other-el");
        /// 
        ///    align the top left corner of el with the top right corner of other-el (constrained to viewport)
        ///    el.alignTo("other-el", "tr?");
        /// 
        ///    align the bottom right corner of el with the center left edge of other-el
        ///    el.alignTo("other-el", "br-l?");
        /// 
        ///    align the center of el with the bottom left corner of other-el and
        ///    adjust the x position by -6 pixels (and the y position by 0)
        ///    el.alignTo("other-el", "c-bl", [-6, 0]);

        /// </param>
        /// <param name="offsets">Offset the positioning by [x, y]</param>
        /// <param name="animate">True for the default animation</param>
        /// <returns>This element</returns>
        [Description("Aligns this element with another element relative to the specified anchor points. If the other element is the document it aligns it to the viewport. ")]
        public virtual Element AlignTo(Element element, string position, int[] offsets, bool animate)
        {
            this.Call("alignTo", new JRawValue(element.Descriptor), position, offsets,animate);
            return this;
        }

        /// <summary>
        /// Aligns this element with another element relative to the specified anchor points. If the other element is the document it aligns it to the viewport. 
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">Offset the positioning by [x, y]</param>
        /// <param name="animate">Animation config</param>
        /// <returns>This element</returns>
        [Description("Aligns this element with another element relative to the specified anchor points. If the other element is the document it aligns it to the viewport. ")]
        public virtual Element AlignTo(Element element, string position, int[] offsets, ElementFxConfig animate)
        {
            this.Call("alignTo", new JRawValue(element.Descriptor), position, offsets, new JRawValue(new ClientConfig().Serialize(animate, true)));
            return this;
        }

        /// <summary>
        /// Aligns this element with another element relative to the specified anchor points. If the other element is the document it aligns it to the viewport. 
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.
        /// The position parameter is optional, and can be specified in any one of the following formats:
        /// Blank: Defaults to aligning the element's top-left corner to the target's bottom-left corner ("tl-bl").
        /// One anchor (deprecated): The passed anchor position is used as the target element's anchor point. The element being aligned will position its top-left corner (tl) to that point. This method has been deprecated in favor of the newer two anchor syntax below.
        /// Two anchors: If two values from the table below are passed separated by a dash, the first value is used as the element's anchor point, and the second value is used as the target's anchor point.
        /// In addition to the anchor points, the position parameter also supports the "?" character. If "?" is passed at the end of the position string, the element will attempt to align as specified, but the position will be adjusted to constrain to the viewport if necessary. Note that the element being aligned might be swapped to align to a different position than that specified in order to enforce the viewport constraints. Following are all of the supported anchor positions:
        /// Value  Description
        /// -----  -----------------------------
        /// tl     The top left corner (default)
        /// t      The center of the top edge
        /// tr     The top right corner
        /// l      The center of the left edge
        /// c      In the center of the element
        /// r      The center of the right edge
        /// bl     The bottom left corner
        /// b      The center of the bottom edge
        /// br     The bottom right corner
        /// Example Usage:
        ///    align el to other-el using the default positioning ("tl-bl", non-constrained)
        ///    el.alignTo("other-el");
        /// 
        ///    align the top left corner of el with the top right corner of other-el (constrained to viewport)
        ///    el.alignTo("other-el", "tr?");
        /// 
        ///    align the bottom right corner of el with the center left edge of other-el
        ///    el.alignTo("other-el", "br-l?");
        /// 
        ///    align the center of el with the bottom left corner of other-el and
        ///    adjust the x position by -6 pixels (and the y position by 0)
        ///    el.alignTo("other-el", "c-bl", [-6, 0]);

        /// </param>
        /// <param name="offsets">Offset the positioning by [x, y]</param>
        /// <returns>This element</returns>
        [Description("Aligns this element with another element relative to the specified anchor points. If the other element is the document it aligns it to the viewport. ")]
        public virtual Element AlignTo(Element element, string position, int[] offsets)
        {
            this.Call("alignTo", new JRawValue(element.Descriptor), position, offsets);
            return this;
        }

        /// <summary>
        /// Aligns this element with another element relative to the specified anchor points. If the other element is the document it aligns it to the viewport. 
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.
        /// The position parameter is optional, and can be specified in any one of the following formats:
        /// Blank: Defaults to aligning the element's top-left corner to the target's bottom-left corner ("tl-bl").
        /// One anchor (deprecated): The passed anchor position is used as the target element's anchor point. The element being aligned will position its top-left corner (tl) to that point. This method has been deprecated in favor of the newer two anchor syntax below.
        /// Two anchors: If two values from the table below are passed separated by a dash, the first value is used as the element's anchor point, and the second value is used as the target's anchor point.
        /// In addition to the anchor points, the position parameter also supports the "?" character. If "?" is passed at the end of the position string, the element will attempt to align as specified, but the position will be adjusted to constrain to the viewport if necessary. Note that the element being aligned might be swapped to align to a different position than that specified in order to enforce the viewport constraints. Following are all of the supported anchor positions:
        /// Value  Description
        /// -----  -----------------------------
        /// tl     The top left corner (default)
        /// t      The center of the top edge
        /// tr     The top right corner
        /// l      The center of the left edge
        /// c      In the center of the element
        /// r      The center of the right edge
        /// bl     The bottom left corner
        /// b      The center of the bottom edge
        /// br     The bottom right corner
        /// Example Usage:
        ///    align el to other-el using the default positioning ("tl-bl", non-constrained)
        ///    el.alignTo("other-el");
        /// 
        ///    align the top left corner of el with the top right corner of other-el (constrained to viewport)
        ///    el.alignTo("other-el", "tr?");
        /// 
        ///    align the bottom right corner of el with the center left edge of other-el
        ///    el.alignTo("other-el", "br-l?");
        /// 
        ///    align the center of el with the bottom left corner of other-el and
        ///    adjust the x position by -6 pixels (and the y position by 0)
        ///    el.alignTo("other-el", "c-bl", [-6, 0]);

        /// </param>
        /// <returns>This element</returns>
        [Description("Aligns this element with another element relative to the specified anchor points. If the other element is the document it aligns it to the viewport. ")]
        public virtual Element AlignTo(Element element, string position)
        {
            this.Call("alignTo", new JRawValue(element.Descriptor), position);
            return this;
        }

        /// <summary>
        /// Aligns this element with another element relative to the specified anchor points. If the other element is the document it aligns it to the viewport. 
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <returns>This element</returns>
        [Description("Aligns this element with another element relative to the specified anchor points. If the other element is the document it aligns it to the viewport. ")]
        public virtual Element AlignTo(Element element)
        {
            this.Call("alignTo", new JRawValue(element.Descriptor));
            return this;
        }

        /// <summary>
        /// Anchors an element to another element and realigns it when the window is resized.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">Offset the positioning by [x, y]</param>
        /// <param name="animate">True for the default animation</param>
        /// <param name="monitorScroll">True to monitor body scroll and reposition. If this parameter is a number, it is used as the buffer delay (defaults to 50ms).</param>
        /// <param name="callback">The function to call after the animation finishes</param>
        /// <returns>This element</returns>
        [Description("Anchors an element to another element and realigns it when the window is resized.")]
        public virtual Element AnchorTo(Element element, string position, int[] offsets, bool animate, bool monitorScroll, JFunction callback)
        {
            this.Call("anchorTo", new JRawValue(element.Descriptor), position, offsets, animate, monitorScroll, callback);
            return this;
        }

        /// <summary>
        /// Anchors an element to another element and realigns it when the window is resized.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">Offset the positioning by [x, y]</param>
        /// <param name="animate">True for the default animation</param>
        /// <param name="monitorScroll">True to monitor body scroll and reposition. If this parameter is a number, it is used as the buffer delay (defaults to 50ms).</param>
        /// <param name="callback">The function to call after the animation finishes</param>
        /// <returns>This element</returns>
        [Description("Anchors an element to another element and realigns it when the window is resized.")]
        public virtual Element AnchorTo(Element element, string position, int[] offsets, ElementFxConfig animate, bool monitorScroll, JFunction callback)
        {
            this.Call("anchorTo", new JRawValue(element.Descriptor), position, offsets, new JRawValue(new ClientConfig().Serialize(animate, true)), monitorScroll, callback);
            return this;
        }

        /// <summary>
        /// Anchors an element to another element and realigns it when the window is resized.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">Offset the positioning by [x, y]</param>
        /// <param name="animate">True for the default animation</param>
        /// <param name="monitorScroll">True to monitor body scroll and reposition. If this parameter is a number, it is used as the buffer delay (defaults to 50ms).</param>
        /// <param name="callback">The function to call after the animation finishes</param>
        /// <returns>This element</returns>
        [Description("Anchors an element to another element and realigns it when the window is resized.")]
        public virtual Element AnchorTo(Element element, string position, int[] offsets, bool animate, int monitorScroll, JFunction callback)
        {
            this.Call("anchorTo", new JRawValue(element.Descriptor), position, offsets, animate, monitorScroll, callback);
            return this;
        }

        /// <summary>
        /// Anchors an element to another element and realigns it when the window is resized.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">Offset the positioning by [x, y]</param>
        /// <param name="animate">True for the default animation</param>
        /// <param name="monitorScroll">True to monitor body scroll and reposition. If this parameter is a number, it is used as the buffer delay (defaults to 50ms).</param>
        /// <param name="callback">The function to call after the animation finishes</param>
        /// <returns>This element</returns>
        [Description("Anchors an element to another element and realigns it when the window is resized.")]
        public virtual Element AnchorTo(Element element, string position, int[] offsets, ElementFxConfig animate, int monitorScroll, JFunction callback)
        {
            this.Call("anchorTo", new JRawValue(element.Descriptor), position, offsets, new JRawValue(new ClientConfig().Serialize(animate, true)), monitorScroll, callback);
            return this;
        }

        /// <summary>
        /// Anchors an element to another element and realigns it when the window is resized.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">Offset the positioning by [x, y]</param>
        /// <param name="animate">True for the default animation</param>
        /// <param name="monitorScroll">True to monitor body scroll and reposition. If this parameter is a number, it is used as the buffer delay (defaults to 50ms).</param>
        /// <returns>This element</returns>
        [Description("Anchors an element to another element and realigns it when the window is resized.")]
        public virtual Element AnchorTo(Element element, string position, int[] offsets, bool animate, int monitorScroll)
        {
            this.Call("anchorTo", new JRawValue(element.Descriptor), position, offsets, animate, monitorScroll);
            return this;
        }

        /// <summary>
        /// Anchors an element to another element and realigns it when the window is resized.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">Offset the positioning by [x, y]</param>
        /// <param name="animate">True for the default animation</param>
        /// <param name="monitorScroll">True to monitor body scroll and reposition. If this parameter is a number, it is used as the buffer delay (defaults to 50ms).</param>
        /// <returns>This element</returns>
        [Description("Anchors an element to another element and realigns it when the window is resized.")]
        public virtual Element AnchorTo(Element element, string position, int[] offsets, ElementFxConfig animate, int monitorScroll)
        {
            this.Call("anchorTo", new JRawValue(element.Descriptor), position, offsets, new JRawValue(new ClientConfig().Serialize(animate, true)), monitorScroll);
            return this;
        }

        /// <summary>
        /// Anchors an element to another element and realigns it when the window is resized.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">Offset the positioning by [x, y]</param>
        /// <param name="animate">True for the default animation</param>
        /// <param name="monitorScroll">True to monitor body scroll and reposition. If this parameter is a number, it is used as the buffer delay (defaults to 50ms).</param>
        /// <returns>This element</returns>
        [Description("Anchors an element to another element and realigns it when the window is resized.")]
        public virtual Element AnchorTo(Element element, string position, int[] offsets, bool animate, bool monitorScroll)
        {
            this.Call("anchorTo", new JRawValue(element.Descriptor), position, offsets, animate, monitorScroll);
            return this;
        }

        /// <summary>
        /// Anchors an element to another element and realigns it when the window is resized.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">Offset the positioning by [x, y]</param>
        /// <param name="animate">True for the default animation</param>
        /// <param name="monitorScroll">True to monitor body scroll and reposition. If this parameter is a number, it is used as the buffer delay (defaults to 50ms).</param>
        /// <returns>This element</returns>
        [Description("Anchors an element to another element and realigns it when the window is resized.")]
        public virtual Element AnchorTo(Element element, string position, int[] offsets, ElementFxConfig animate, bool monitorScroll)
        {
            this.Call("anchorTo", new JRawValue(element.Descriptor), position, offsets, new JRawValue(new ClientConfig().Serialize(animate, true)), monitorScroll);
            return this;
        }

        /// <summary>
        /// Anchors an element to another element and realigns it when the window is resized.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">Offset the positioning by [x, y]</param>
        /// <param name="animate">True for the default animation</param>
        /// <returns>This element</returns>
        [Description("Anchors an element to another element and realigns it when the window is resized.")]
        public virtual Element AnchorTo(Element element, string position, int[] offsets, bool animate)
        {
            this.Call("anchorTo", new JRawValue(element.Descriptor), position, offsets, animate);
            return this;
        }

        /// <summary>
        /// Anchors an element to another element and realigns it when the window is resized.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">Offset the positioning by [x, y]</param>
        /// <param name="animate">True for the default animation</param>
        /// <returns>This element</returns>
        [Description("Anchors an element to another element and realigns it when the window is resized.")]
        public virtual Element AnchorTo(Element element, string position, int[] offsets, ElementFxConfig animate)
        {
            this.Call("anchorTo", new JRawValue(element.Descriptor), position, offsets, new JRawValue(new ClientConfig().Serialize(animate, true)));
            return this;
        }

        /// <summary>
        /// Anchors an element to another element and realigns it when the window is resized.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <param name="offsets">Offset the positioning by [x, y]</param>
        /// <returns>This element</returns>
        [Description("Anchors an element to another element and realigns it when the window is resized.")]
        public virtual Element AnchorTo(Element element, string position, int[] offsets)
        {
            this.Call("anchorTo", new JRawValue(element.Descriptor), position, offsets);
            return this;
        }

        /// <summary>
        /// Anchors an element to another element and realigns it when the window is resized.
        /// </summary>
        /// <param name="element">The element to align to.</param>
        /// <param name="position">The position to align to.</param>
        /// <returns>This element</returns>
        [Description("Anchors an element to another element and realigns it when the window is resized.")]
        public virtual Element AnchorTo(Element element, string position)
        {
            this.Call("anchorTo", new JRawValue(element.Descriptor), position);
            return this;
        }

        /// <summary>
        /// Perform custom animation on this element.
        /// </summary>
        /// <param name="args">The animation control args</param>
        /// <param name="duration">How long the animation lasts in seconds (defaults to .35)</param>
        /// <param name="onComplete">Function to call when animation completes</param>
        /// <param name="easing">Ext.Fx.easing method to use (defaults to 'easeOut')</param>
        /// <param name="animType">'run' is the default. Can also be 'color', 'motion', or 'scroll'</param>
        /// <returns>This element</returns>
        [Description("Perform custom animation on this element.")]
        public virtual Element Animate(ElementAnimationConfig args, double duration, JFunction onComplete, Easing easing, AnimationType animType)
        {
            this.Call("animate", new JRawValue(args.Serialize()), duration, onComplete, easing.ToString().ToLowerCamelCase(), animType.ToString().ToLowerInvariant());
            return this;
        }

        /// <summary>
        /// Perform custom animation on this element.
        /// </summary>
        /// <param name="args">The animation control args</param>
        /// <param name="duration">How long the animation lasts in seconds (defaults to .35)</param>
        /// <param name="onComplete">Function to call when animation completes</param>
        /// <param name="easing">Ext.Fx.easing method to use (defaults to 'easeOut')</param>
        /// <returns>This element</returns>
        [Description("Perform custom animation on this element.")]
        public virtual Element Animate(ElementAnimationConfig args, double duration, JFunction onComplete, Easing easing)
        {
            this.Call("animate", new JRawValue(args.Serialize()), duration, onComplete, easing.ToString().ToLowerCamelCase());
            return this;
        }

        /// <summary>
        /// Perform custom animation on this element.
        /// </summary>
        /// <param name="args">The animation control args</param>
        /// <param name="duration">How long the animation lasts in seconds (defaults to .35)</param>
        /// <param name="onComplete">Function to call when animation completes</param>
        /// <returns>This element</returns>
        [Description("Perform custom animation on this element.")]
        public virtual Element Animate(ElementAnimationConfig args, double duration, JFunction onComplete)
        {
            this.Call("animate", new JRawValue(args.Serialize()), duration, onComplete);
            return this;
        }

        /// <summary>
        /// Perform custom animation on this element.
        /// </summary>
        /// <param name="args">The animation control args</param>
        /// <param name="duration">How long the animation lasts in seconds (defaults to .35)</param>
        /// <returns>This element</returns>
        [Description("Perform custom animation on this element.")]
        public virtual Element Animate(ElementAnimationConfig args, double duration)
        {
            this.Call("animate", new JRawValue(args.Serialize()), duration);
            return this;
        }

        /// <summary>
        /// Perform custom animation on this element.
        /// </summary>
        /// <param name="args">The animation control args</param>
        /// <returns>This element</returns>
        [Description("Perform custom animation on this element.")]
        public virtual Element Animate(ElementAnimationConfig args)
        {
            this.Call("animate", new JRawValue(args.Serialize()));
            return this;
        }

        /// <summary>
        /// Appends the passed element(s) to this element
        /// </summary>
        /// <param name="element">element</param>
        /// <returns>This element</returns>
        [Description("Appends the passed element(s) to this element")]
        public virtual Element AppendChild(Element element)
        {
            this.Call("appendChild", new JRawValue(element.Descriptor));
            return this;
        }

        /// <summary>
        /// Appends the passed element(s) to this element
        /// </summary>
        /// <param name="element">element</param>
        /// <returns>This element</returns>
        [Description("Appends the passed element(s) to this element")]
        public virtual Element AppendChild(string element)
        {
            this.Call("appendChild", element);
            return this;
        }

        /// <summary>
        /// Appends this element to the passed element
        /// </summary>
        /// <param name="element">The new parent element</param>
        /// <returns>This element</returns>
        [Description("Appends this element to the passed element")]
        public virtual Element AppendTo(Element element)
        {
            this.Call("appendTo", new JRawValue(element.Descriptor));
            return this;
        }

        /// <summary>
        /// More flexible version of setStyle for setting style properties. 
        /// </summary>
        /// <param name="styles">A style specification string, e.g. "width:100px"</param>
        /// <returns>This element</returns>
        [Description("More flexible version of setStyle for setting style properties. ")]
        public virtual Element ApplyStyles(string styles)
        {
            this.Call("applyStyles", styles);
            return this;
        }

        /// <summary>
        /// More flexible version of setStyle for setting style properties. 
        /// </summary>
        /// <param name="styles">A style specification object in the form {width:"100px"}</param>
        /// <returns>This element</returns>
        [Description("More flexible version of setStyle for setting style properties. ")]
        public virtual Element ApplyStyles(JsonObject styles)
        {
            this.Call("applyStyles", styles);
            return this;
        }

        /// <summary>
        /// More flexible version of setStyle for setting style properties. 
        /// </summary>
        /// <param name="styles">Function which returns styles specification, like {width:"100px"}</param>
        /// <returns>This element</returns>
        [Description("More flexible version of setStyle for setting style properties. ")]
        public virtual Element ApplyStyles(JFunction styles)
        {
            this.Call("applyStyles", styles);
            return this;
        }

        /// <summary>
        /// Measures the element's content height and updates height to match. Note: this function uses setTimeout so the new height may not be available immediately.
        /// </summary>
        /// <param name="animate">Animate the transition (defaults to false)</param>
        /// <param name="duration">Length of the animation in seconds (defaults to .35)</param>
        /// <param name="onComplete">Function to call when animation completes</param>
        /// <param name="easing">Easing method to use (defaults to easeOut)</param>
        /// <returns>This element</returns>
        [Description("Measures the element's content height and updates height to match. Note: this function uses setTimeout so the new height may not be available immediately.")]
        public virtual Element AutoHeight(bool animate, double duration, JFunction onComplete, Easing easing)
        {
            this.Call("autoHeight", animate, duration, onComplete, easing.ToString().ToLowerCamelCase());
            return this;
        }

        /// <summary>
        /// Measures the element's content height and updates height to match. Note: this function uses setTimeout so the new height may not be available immediately.
        /// </summary>
        /// <param name="animate">Animate the transition (defaults to false)</param>
        /// <param name="duration">Length of the animation in seconds (defaults to .35)</param>
        /// <param name="onComplete">Function to call when animation completes</param>
        /// <returns>This element</returns>
        [Description("Measures the element's content height and updates height to match. Note: this function uses setTimeout so the new height may not be available immediately.")]
        public virtual Element AutoHeight(bool animate, double duration, JFunction onComplete)
        {
            this.Call("autoHeight", animate, duration, onComplete);
            return this;
        }

        /// <summary>
        /// Measures the element's content height and updates height to match. Note: this function uses setTimeout so the new height may not be available immediately.
        /// </summary>
        /// <param name="animate">Animate the transition (defaults to false)</param>
        /// <param name="duration">Length of the animation in seconds (defaults to .35)</param>
        /// <returns>This element</returns>
        [Description("Measures the element's content height and updates height to match. Note: this function uses setTimeout so the new height may not be available immediately.")]
        public virtual Element AutoHeight(bool animate, double duration)
        {
            this.Call("autoHeight", animate, duration);
            return this;
        }

        /// <summary>
        /// Measures the element's content height and updates height to match. Note: this function uses setTimeout so the new height may not be available immediately.
        /// </summary>
        /// <param name="animate">Animate the transition (defaults to false)</param>
        /// <returns>This element</returns>
        [Description("Measures the element's content height and updates height to match. Note: this function uses setTimeout so the new height may not be available immediately.")]
        public virtual Element AutoHeight(bool animate)
        {
            this.Call("autoHeight", animate);
            return this;
        }

        /// <summary>
        /// Measures the element's content height and updates height to match. Note: this function uses setTimeout so the new height may not be available immediately.
        /// </summary>
        /// <returns>This element</returns>
        [Description("Measures the element's content height and updates height to match. Note: this function uses setTimeout so the new height may not be available immediately.")]
        public virtual Element AutoHeight()
        {
            this.Call("autoHeight");
            return this;
        }

        /// <summary>
        /// Tries to blur the element. Any exceptions are caught and ignored.
        /// </summary>
        /// <returns>This element</returns>
        [Description("Tries to blur the element. Any exceptions are caught and ignored.")]
        public virtual Element Blur()
        {
            this.Call("blur");
            return this;
        }

        /// <summary>
        /// Wraps the specified element with a special 9 element markup/CSS block that renders by default as a gray container with a gradient background, rounded corners and a 4-way shadow.
        /// This special markup is used throughout Ext when box wrapping elements (Ext.Button, Ext.Panel when frame=true, Ext.Window).
        /// </summary>
        /// <param name="cssClass">A base CSS class to apply to the containing wrapper element (defaults to 'x-box'). Note that there are a number of CSS rules that are dependent on this name to make the overall effect work, so if you supply an alternate base class, make sure you also supply all of the necessary rules.</param>
        /// <returns>This element</returns>
        [Description("Wraps the specified element with a special 9 element markup/CSS block that renders by default as a gray container with a gradient background, rounded corners and a 4-way shadow.")]
        public virtual Element BoxWrap(string cssClass)
        {
            this.Call("boxWrap", cssClass);
            return this;
        }

        /// <summary>
        /// Wraps the specified element with a special 9 element markup/CSS block that renders by default as a gray container with a gradient background, rounded corners and a 4-way shadow.
        /// This special markup is used throughout Ext when box wrapping elements (Ext.Button, Ext.Panel when frame=true, Ext.Window).
        /// </summary>
        /// <returns>This element</returns>
        [Description("Wraps the specified element with a special 9 element markup/CSS block that renders by default as a gray container with a gradient background, rounded corners and a 4-way shadow.")]
        public virtual Element BoxWrap()
        {
            this.Call("boxWrap");
            return this;
        }

        /// <summary>
        /// Centers the Element in either the viewport, or another Element.
        /// </summary>
        /// <param name="centerIn">The element in which to center the element.</param>
        /// <returns>This element</returns>
        [Description("Centers the Element in either the viewport, or another Element.")]
        public virtual Element Center(Element centerIn)
        {
            this.Call("center", new JRawValue(centerIn.Descriptor));
            return this;
        }

        /// <summary>
        /// Centers the Element in either the viewport, or another Element.
        /// </summary>
        /// <returns>This element</returns>
        [Description("Centers the Element in either the viewport, or another Element.")]
        public virtual Element Center()
        {
            this.Call("center");
            return this;
        }

        /// <summary>
        /// Selects a single child at any depth below this element based on the passed CSS selector (the selector should not contain an id).
        /// </summary>
        /// <param name="selector">The CSS selector</param>
        /// <returns>The child Ext.Element</returns>
        [Description("Selects a single child at any depth below this element based on the passed CSS selector (the selector should not contain an id).")]
        public virtual Element Child(string selector)
        {
            this.EnsureChaining();
            this.Call("child", selector);
            return this;
        }

        /// <summary>
        /// Removes worthless text nodes
        /// </summary>
        /// <param name="forceReclean">By default the element keeps track if it has been cleaned already so you can call this over and over. However, if you update the element and need to force a reclean, you can pass true.</param>
        /// <returns>This element</returns>
        [Description("Removes worthless text nodes")]
        public virtual Element Clean(bool forceReclean)
        {
            this.Call("clean", forceReclean);
            return this;
        }

        /// <summary>
        /// Removes worthless text nodes
        /// </summary>
        /// <returns>This element</returns>
        [Description("Removes worthless text nodes")]
        public virtual Element Clean()
        {
            this.Call("clean");
            return this;
        }

        /// <summary>
        /// Clears any opacity settings from this element. Required in some cases for IE.
        /// </summary>
        /// <returns>This element</returns>
        [Description("Clears any opacity settings from this element. Required in some cases for IE.")]
        public virtual Element ClearOpacity()
        {
            this.Call("clearOpacity");
            return this;
        }

        /// <summary>
        /// Clear positioning back to the default when the document was loaded
        /// </summary>
        /// <param name="value">The value to use for the left,right,top,bottom, defaults to '' (empty string). You could use 'auto'.</param>
        /// <returns>This element</returns>
        [Description("Clear positioning back to the default when the document was loaded")]
        public virtual Element ClearPositioning(string value)
        {
            this.Call("clearPositioning", value);
            return this;
        }

        /// <summary>
        /// Store the current overflow setting and clip overflow on the element - use unclip to remove
        /// </summary>
        /// <returns>This element</returns>
        [Description("Store the current overflow setting and clip overflow on the element - use unclip to remove")]
        public virtual Element Clip()
        {
            this.Call("clip");
            return this;
        }

        /// <summary>
        /// Creates the passed DomHelper config and appends it to this element or optionally inserts it before the passed child element.
        /// </summary>
        /// <param name="config">DomHelper element config object. If no tag is specified (e.g., {tag:'input'}) then a div will be automatically generated with the specified attributes.</param>
        /// <param name="insertBefore">a child element of this element</param>
        /// <returns>The new child element</returns>
        [Description("Creates the passed DomHelper config and appends it to this element or optionally inserts it before the passed child element.")]
        public virtual Element CreateChild(DomObject config, Element insertBefore)
        {
            this.Call("createChild", new JRawValue(config.Serialize()), new JRawValue(insertBefore.Descriptor + ".dom"));
            return this;
        }

        /// <summary>
        /// Creates the passed DomHelper config and appends it to this element or optionally inserts it before the passed child element.
        /// </summary>
        /// <param name="config">DomHelper element config object. If no tag is specified (e.g., {tag:'input'}) then a div will be automatically generated with the specified attributes.</param>
        /// <returns>The new child element</returns>
        [Description("Creates the passed DomHelper config and appends it to this element or optionally inserts it before the passed child element.")]
        public virtual Element CreateChild(DomObject config)
        {
            this.Call("createChild", new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Creates a proxy element of this element
        /// </summary>
        /// <param name="config">The DomHelper config object of the proxy element</param>
        /// <param name="renderTo">The  element id to render the proxy to (defaults to document.body)</param>
        /// <param name="matchBox">True to align and size the proxy to this element now (defaults to false)</param>
        /// <returns>The new proxy element</returns>
        [Description("Creates a proxy element of this element")]
        public virtual Element CreateProxy(DomObject config, string renderTo, bool matchBox)
        {
            this.Call("createProxy", new JRawValue(config.Serialize()), renderTo, matchBox);
            return this;
        }

        /// <summary>
        /// Creates a proxy element of this element
        /// </summary>
        /// <param name="config">The DomHelper config object of the proxy element</param>
        /// <param name="renderTo">The  element to render the proxy to (defaults to document.body)</param>
        /// <param name="matchBox">True to align and size the proxy to this element now (defaults to false)</param>
        /// <returns>The new proxy element</returns>
        [Description("Creates a proxy element of this element")]
        public virtual Element CreateProxy(DomObject config, Element renderTo, bool matchBox)
        {
            this.Call("createProxy", new JRawValue(config.Serialize()), new JRawValue(renderTo.Descriptor+".dom"), matchBox);
            return this;
        }

        /// <summary>
        /// Creates a proxy element of this element
        /// </summary>
        /// <param name="className">The class name of the proxy element</param>
        /// <param name="renderTo">The  element id to render the proxy to (defaults to document.body)</param>
        /// <param name="matchBox">True to align and size the proxy to this element now (defaults to false)</param>
        /// <returns>The new proxy element</returns>
        [Description("Creates a proxy element of this element")]
        public virtual Element CreateProxy(string className, string renderTo, bool matchBox)
        {
            this.Call("createProxy", className, renderTo, matchBox);
            return this;
        }

        /// <summary>
        /// Creates a proxy element of this element
        /// </summary>
        /// <param name="className">The class name of the proxy element</param>
        /// <param name="renderTo">The  element to render the proxy to (defaults to document.body)</param>
        /// <param name="matchBox">True to align and size the proxy to this element now (defaults to false)</param>
        /// <returns>The new proxy element</returns>
        [Description("Creates a proxy element of this element")]
        public virtual Element CreateProxy(string className, Element renderTo, bool matchBox)
        {
            this.Call("createProxy", className, new JRawValue(renderTo.Descriptor + ".dom"), matchBox);
            return this;
        }

        /// <summary>
        /// Creates a proxy element of this element
        /// </summary>
        /// <param name="className">The class name of the proxy element</param>
        /// <returns>The new proxy element</returns>
        [Description("Creates a proxy element of this element")]
        public virtual Element CreateProxy(string className)
        {
            this.Call("createProxy", className);
            return this;
        }

        /// <summary>
        /// Creates a proxy element of this element
        /// </summary>
        /// <param name="config">The DomHelper config object of the proxy element</param>
        /// <returns>The new proxy element</returns>
        [Description("Creates a proxy element of this element")]
        public virtual Element CreateProxy(DomObject config)
        {
            this.Call("createProxy", new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Creates an iframe shim for this element to keep selects and other windowed objects from showing through.
        /// </summary>
        /// <returns>The new shim element</returns>
        [Description("Creates an iframe shim for this element to keep selects and other windowed objects from showing through.")]
        public virtual Element CreateShim()
        {
            this.Call("createShim");
            return this;
        }

        /// <summary>
        /// Selects a single *direct* child based on the passed CSS selector (the selector should not contain an id).
        /// </summary>
        /// <param name="selector">The CSS selector</param>
        /// <returns>This element</returns>
        [Description("Selects a single *direct* child based on the passed CSS selector (the selector should not contain an id).")]
        public virtual Element Down(string selector)
        {
            this.EnsureChaining();
            this.Call("down", selector);
            return this;
        }

        /// <summary>
        /// Convenience method for setVisibilityMode(Element.DISPLAY)
        /// </summary>
        /// <param name="display">What to set display to when visible</param>
        /// <returns>This element</returns>
        [Description("Convenience method for setVisibilityMode(Element.DISPLAY)")]
        public virtual Element EnableDisplayMode(string display)
        {
            this.Call("enableDisplayMode", display);
            return this;
        }

        /// <summary>
        /// Convenience method for setVisibilityMode(Element.DISPLAY)
        /// </summary>
        /// <returns>This element</returns>
        [Description("Convenience method for setVisibilityMode(Element.DISPLAY)")]
        public virtual Element EnableDisplayMode()
        {
            this.Call("enableDisplayMode");
            return this;
        }

        /// <summary>
        /// Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">The max depth to search as a number (defaults to 50 || document.body)</param>
        /// <returns>The matching DOM node</returns>
        [Description("Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)")]
        public virtual Element FindParent(string selector, int maxDepth)
        {
            this.EnsureChaining();
            this.Call("findParent", selector, maxDepth, true);
            return this;
        }

        /// <summary>
        /// Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">The max depth to search as a element (defaults to 50 || document.body)</param>
        /// <returns>The matching DOM node</returns>
        [Description("Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)")]
        public virtual Element FindParent(string selector, Element maxDepth)
        {
            this.EnsureChaining();
            this.Call("findParent", selector, new JRawValue(maxDepth.Descriptor+".dom"), true);
            return this;
        }

        /// <summary>
        /// Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <returns>The matching DOM node</returns>
        [Description("Looks at this node and then at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)")]
        public virtual Element FindParent(string selector)
        {
            this.EnsureChaining();
            this.Call("findParent", selector, 50, true);
            return this;
        }

        /// <summary>
        /// Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">The max depth to search as a number (defaults to 10 || document.body)</param>
        /// <returns>The matching DOM node</returns>
        [Description("Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)")]
        public virtual Element FindParentNode(string selector, int maxDepth)
        {
            this.EnsureChaining();
            this.Call("findParentNode", selector, maxDepth, true);
            return this;
        }

        /// <summary>
        /// Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">The max depth to search as a element (defaults to 10 || document.body)</param>
        /// <returns>The matching DOM node</returns>
        [Description("Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)")]
        public virtual Element FindParentNode(string selector, Element maxDepth)
        {
            this.EnsureChaining();
            this.Call("findParentNode", selector, new JRawValue(maxDepth.Descriptor + ".dom"), true);
            return this;
        }

        /// <summary>
        /// Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <returns>The matching DOM node</returns>
        [Description("Looks at parent nodes for a match of the passed simple selector (e.g. div.some-class or span:first-child)")]
        public virtual Element FindParentNode(string selector)
        {
            this.EnsureChaining();
            this.Call("findParentNode", selector, 10, true);
            return this;
        }

        /// <summary>
        /// Gets the first child, skipping text nodes
        /// </summary>
        /// <param name="selector">Find the next sibling that matches the passed simple selector</param>
        /// <returns>The first child or null</returns>
        [Description("Gets the first child, skipping text nodes")]
        public virtual Element First(string selector)
        {
            this.EnsureChaining();
            this.Call("first", selector);
            return this;
        }

        /// <summary>
        /// Gets the first child, skipping text nodes
        /// </summary>
        /// <returns>The first child or null</returns>
        [Description("Gets the first child, skipping text nodes")]
        public virtual Element First()
        {
            this.EnsureChaining();
            this.Call("first");
            return this;
        }

        /// <summary>
        /// Tries to focus the element. Any exceptions are caught and ignored.
        /// </summary>
        /// <param name="defer">Milliseconds to defer the focus</param>
        /// <returns>This element</returns>
        [Description("Tries to focus the element. Any exceptions are caught and ignored.")]
        public virtual Element Focus(int defer)
        {
            this.Call("focus", defer);
            return this;
        }

        /// <summary>
        /// Tries to focus the element. Any exceptions are caught and ignored.
        /// </summary>
        /// <returns>This element</returns>
        [Description("Tries to focus the element. Any exceptions are caught and ignored.")]
        public virtual Element Focus()
        {
            this.Call("focus");
            return this;
        }

        /// <summary>
        /// Hide this element - Uses display mode to determine whether to use "display" or "visibility". See setVisible.
        /// </summary>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Hide this element - Uses display mode to determine whether to use 'display' or 'visibility'. See setVisible.")]
        public virtual Element Hide(bool animate)
        {
            this.Call("hide", animate);
            return this;
        }

        /// <summary>
        /// Hide this element - Uses display mode to determine whether to use "display" or "visibility". See setVisible.
        /// </summary>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Hide this element - Uses display mode to determine whether to use 'display' or 'visibility'. See setVisible.")]
        public virtual Element Hide(ElementFxConfig animate)
        {
            this.Call("hide", new JRawValue(new ClientConfig().Serialize(animate, true)));
            return this;
        }

        /// <summary>
        /// Hide this element - Uses display mode to determine whether to use "display" or "visibility". See setVisible.
        /// </summary>
        /// <returns>This element</returns>
        [Description("Hide this element - Uses display mode to determine whether to use 'display' or 'visibility'. See setVisible.")]
        public virtual Element Hide()
        {
            this.Call("hide");
            return this;
        }

        /// <summary>
        /// Sets up event handlers to call the passed functions when the mouse is moved into and out of the Element.
        /// </summary>
        /// <param name="overFn">The function to call when the mouse enters the Element.</param>
        /// <param name="outFn">The function to call when the mouse leaves the Element.</param>
        /// <param name="scope">The scope (this reference) in which the functions are executed. Defaults to the Element's DOM element.</param>
        /// <param name="options">Options for the listener.</param>
        /// <returns>This element</returns>
        [Description("Sets up event handlers to call the passed functions when the mouse is moved into and out of the Element.")]
        public virtual Element Hover(JFunction overFn, JFunction outFn, string scope, HandlerConfig options)
        {
            this.Call("hover", overFn, outFn, new JRawValue(scope), new JRawValue(options.ToJsonString()));
            return this;
        }

        /// <summary>
        /// Sets up event handlers to call the passed functions when the mouse is moved into and out of the Element.
        /// </summary>
        /// <param name="overFn">The function to call when the mouse enters the Element.</param>
        /// <param name="outFn">The function to call when the mouse leaves the Element.</param>
        /// <param name="scope">The scope (this reference) in which the functions are executed. Defaults to the Element's DOM element.</param>
        /// <returns>This element</returns>
        [Description("Sets up event handlers to call the passed functions when the mouse is moved into and out of the Element.")]
        public virtual Element Hover(JFunction overFn, JFunction outFn, string scope)
        {
            this.Call("hover", overFn, outFn, new JRawValue(scope));
            return this;
        }

        /// <summary>
        /// Sets up event handlers to call the passed functions when the mouse is moved into and out of the Element.
        /// </summary>
        /// <param name="overFn">The function to call when the mouse enters the Element.</param>
        /// <param name="outFn">The function to call when the mouse leaves the Element.</param>
        /// <returns>This element</returns>
        [Description("Sets up event handlers to call the passed functions when the mouse is moved into and out of the Element.")]
        public virtual Element Hover(JFunction overFn, JFunction outFn)
        {
            this.Call("hover", overFn, outFn);
            return this;
        }

        /// <summary>
        /// Initializes a Ext.dd.DD drag drop object for this element.
        /// </summary>
        /// <param name="group">The group the DD object is member of</param>
        /// <param name="config">The DD config object</param>
        /// <param name="overrides">An object containing methods to override/implement on the DD object</param>
        /// <returns>This element</returns>
        [Description("Initializes a Ext.dd.DD drag drop object for this element.")]
        public virtual Element InitDD(string group, DD config, JsonObject overrides)
        {
            this.Call("initDDEx", group, new JRawValue(new ClientConfig().Serialize(config, true)), overrides);
            return this;
        }

        /// <summary>
        /// Initializes a Ext.dd.DDProxy object for this element.
        /// </summary>
        /// <param name="group">The group the DDProxy object is member of</param>
        /// <param name="config">The DDProxy config object</param>
        /// <param name="overrides">An object containing methods to override/implement on the DDProxy object</param>
        /// <returns>This element</returns>
        [Description("Initializes a Ext.dd.DDProxy object for this element.")]
        public virtual Element InitDDProxy(string group, DDProxy config, JsonObject overrides)
        {
            this.Call("initDDProxyEx", group, new JRawValue(new ClientConfig().Serialize(config, true)), overrides);
            return this;
        }

        /// <summary>
        /// Initializes a Ext.dd.DDTarget object for this element.
        /// </summary>
        /// <param name="group">The group the DDTarget object is member of</param>
        /// <param name="config">The DDTarget config object</param>
        /// <param name="overrides">An object containing methods to override/implement on the DDTarget object</param>
        /// <returns>This element</returns>
        [Description("Initializes a Ext.dd.DDTarget object for this element.")]
        public virtual Element InitDDTarget(string group, DDTarget config, JsonObject overrides)
        {
            this.Call("initDDTargetEx", group, new JRawValue(new ClientConfig().Serialize(config, true)), overrides);
            return this;
        }

        /// <summary>
        /// Inserts this element after the passed element in the DOM
        /// </summary>
        /// <param name="element">The element to insert after</param>
        /// <returns>This element</returns>
        [Description("Inserts this element after the passed element in the DOM")]
        public virtual Element InsertAfter(Element element)
        {
            this.Call("insertAfter", new JRawValue(element.Descriptor));
            return this;
        }

        /// <summary>
        /// Inserts this element before the passed element in the DOM
        /// </summary>
        /// <param name="element">The element before which this element will be inserted</param>
        /// <returns>This element</returns>
        [Description("Inserts this element before the passed element in the DOM")]
        public virtual Element InsertBefore(Element element)
        {
            this.Call("insertBefore", new JRawValue(element.Descriptor));
            return this;
        }

        /// <summary>
        /// Inserts an element as the first child of this element
        /// </summary>
        /// <param name="element">The id or element to insert</param>
        /// <returns>This element</returns>
        [Description("Inserts an element as the first child of this element")]
        public virtual Element InsertFirst(Element element)
        {
            this.Call("insertFirst", new JRawValue(element.Descriptor));
            return this;
        }

        /// <summary>
        /// Inserts an element as the first child of this element
        /// </summary>
        /// <param name="element">The id or element to insert</param>
        /// <returns>This element</returns>
        [Description("Inserts an element as the first child of this element")]
        public virtual Element InsertFirst(string element)
        {
            this.Call("insertFirst", element);
            return this;
        }

        /// <summary>
        /// Creates an DomHelper config as the first child of this element
        /// </summary>
        /// <param name="element">DomHelper config to create and insert</param>
        /// <returns>This element</returns>
        [Description("Creates an DomHelper config as the first child of this element")]
        public virtual Element InsertFirst(DomObject element)
        {
            this.Call("insertFirst", new JRawValue(element.Serialize()));
            return this;
        }

        /// <summary>
        /// Inserts an html fragment into this element
        /// </summary>
        /// <param name="where">Where to insert the html in relation to this element-beforeBegin, afterBegin, beforeEnd, afterEnd.</param>
        /// <param name="html">The HTML fragment</param>
        /// <returns>The inserted node (or nearest related if more than 1 inserted)</returns>
        [Description("Inserts an html fragment into this element")]
        public virtual Element InsertHtml(InsertPosition where, string html)
        {
            this.Call("insertHtml", where.ToString().ToLowerCamelCase(), Element.ConvertToSafeJSHtml(html), true);
            return this;
        }

        /// <summary>
        /// Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element
        /// </summary>
        /// <param name="element">The id or element to insert</param>
        /// <param name="where">'before' or 'after' defaults to before</param>
        /// <returns>The inserted Element</returns>
        [Description("Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element")]
        public virtual Element InsertSibling(Element element, InsertPosition where)
        {
            this.Call("insertSibling", new JRawValue(element.Descriptor), where.ToString().ToLowerCamelCase());
            return this;
        }

        /// <summary>
        /// Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element
        /// </summary>
        /// <param name="element">The id or element to insert</param>
        /// <param name="where">'before' or 'after' defaults to before</param>
        /// <returns>The inserted Element</returns>
        [Description("Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element")]
        public virtual Element InsertSibling(string element, InsertPosition where)
        {
            this.Call("insertSibling", element, where.ToString().ToLowerCamelCase());
            return this;
        }

        /// <summary>
        /// Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element
        /// </summary>
        /// <param name="element">DomHelper config to create and insert</param>
        /// <param name="where">'before' or 'after' defaults to before</param>
        /// <returns>The inserted Element</returns>
        [Description("Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element")]
        public virtual Element InsertSibling(DomObject element, InsertPosition where)
        {
            this.Call("insertSibling", new JRawValue(element.Serialize()), where.ToString().ToLowerCamelCase());
            return this;
        }

        /// <summary>
        /// Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element
        /// </summary>
        /// <param name="element">The id or element to insert</param>
        /// <returns>The inserted Element</returns>
        [Description("Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element")]
        public virtual Element InsertSibling(Element element)
        {
            this.Call("insertSibling", new JRawValue(element.Descriptor));
            return this;
        }

        /// <summary>
        /// Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element
        /// </summary>
        /// <param name="element">The id or element to insert</param>
        /// <returns>The inserted Element</returns>
        [Description("Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element")]
        public virtual Element InsertSibling(string element)
        {
            this.Call("insertSibling", element);
            return this;
        }

        /// <summary>
        /// Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element
        /// </summary>
        /// <param name="element">DomHelper config to create and insert</param>
        /// <returns>The inserted Element</returns>
        [Description("Inserts (or creates) the passed element (or DomHelper config) as a sibling of this element")]
        public virtual Element InsertSibling(DomObject element)
        {
            this.Call("insertSibling", new JRawValue(element.Serialize()));
            return this;
        }

        /// <summary>
        /// Gets the last child, skipping text nodes
        /// </summary>
        /// <param name="selector">Find the previous sibling that matches the passed simple selector</param>
        /// <returns>The last child or null</returns>
        [Description("Gets the last child, skipping text nodes")]
        public virtual Element Last(string selector)
        {
            this.EnsureChaining();
            this.Call("last", selector);
            return this;
        }

        /// <summary>
        /// Gets the last child, skipping text nodes
        /// </summary>
        /// <returns>The last child or null</returns>
        [Description("Gets the last child, skipping text nodes")]
        public virtual Element Last()
        {
            this.EnsureChaining();
            this.Call("last");
            return this;
        }

        /// <summary>
        /// Direct access to the Updater Ext.Updater.update method.
        /// </summary>
        /// <param name="config">Load config</param>
        /// <returns>This element</returns>
        [Description("Direct access to the Updater Ext.Updater.update method.")]
        public virtual Element Load(BaseLoadConfig config)
        {
            this.Call("load", new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Puts a mask over this element to disable user interaction. Requires core.css. This method can only be applied to elements which accept child nodes.
        /// </summary>
        /// <param name="msg"> A message to display in the mask</param>
        /// <param name="msgCls">A css class to apply to the msg element</param>
        /// <returns>The mask element</returns>
        [Description("Puts a mask over this element to disable user interaction. Requires core.css. This method can only be applied to elements which accept child nodes.")]
        public virtual Element Mask(string msg, string msgCls)
        {
            this.Call("mask", msg, msgCls);
            return this;
        }

        /// <summary>
        /// Puts a mask over this element to disable user interaction. Requires core.css. This method can only be applied to elements which accept child nodes.
        /// </summary>
        /// <param name="msg"> A message to display in the mask</param>
        /// <returns>The mask element</returns>
        [Description("Puts a mask over this element to disable user interaction. Requires core.css. This method can only be applied to elements which accept child nodes.")]
        public virtual Element Mask(string msg)
        {
            this.Call("mask", msg);
            return this;
        }

        /// <summary>
        /// Puts a mask over this element to disable user interaction. Requires core.css. This method can only be applied to elements which accept child nodes.
        /// </summary>
        /// <returns>The mask element</returns>
        [Description("Puts a mask over this element to disable user interaction. Requires core.css. This method can only be applied to elements which accept child nodes.")]
        public virtual Element Mask()
        {
            this.Call("mask");
            return this;
        }

        /// <summary>
        /// Move this element relative to its current position.
        /// </summary>
        /// <param name="direction">Moving direction</param>
        /// <param name="distance">How far to move the element in pixels</param>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Move this element relative to its current position.")]
        public virtual Element Move(Direction direction, int distance, bool animate)
        {
            this.Call("move", direction.ToString().ToLowerCamelCase(), distance, animate);
            return this;
        }

        /// <summary>
        /// Move this element relative to its current position.
        /// </summary>
        /// <param name="direction">Moving direction</param>
        /// <param name="distance">How far to move the element in pixels</param>
        /// <param name="animate">standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Move this element relative to its current position.")]
        public virtual Element Move(Direction direction, int distance, ElementFxConfig animate)
        {
            this.Call("move", direction.ToString().ToLowerCamelCase(), distance, new JRawValue(new ClientConfig().Serialize(animate, true)));
            return this;
        }

        /// <summary>
        /// Move this element relative to its current position.
        /// </summary>
        /// <param name="direction">Moving direction</param>
        /// <param name="distance">How far to move the element in pixels</param>
        /// <returns>This element</returns>
        [Description("Move this element relative to its current position.")]
        public virtual Element Move(Direction direction, int distance)
        {
            this.Call("move", direction.ToString().ToLowerCamelCase(), distance);
            return this;
        }

        /// <summary>
        /// Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="animate">True for the default animation</param>
        /// <returns>This element</returns>
        [Description("Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element MoveTo(int x, int y, bool animate)
        {
            this.Call("moveTo", x, y, animate);
            return this;
        }

        /// <summary>
        /// Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="animate">standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element MoveTo(int x, int y, ElementFxConfig animate)
        {
            this.Call("moveTo", x, y, new JRawValue(new ClientConfig().Serialize(animate, true)));
            return this;
        }

        /// <summary>
        /// Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <returns>This element</returns>
        [Description("Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element MoveTo(int x, int y)
        {
            this.Call("moveTo", x, y);
            return this;
        }

        /// <summary>
        /// Gets the next sibling, skipping text nodes
        /// </summary>
        /// <param name="selector">Find the next sibling that matches the passed simple selector</param>
        /// <returns>This element</returns>
        [Description("Gets the next sibling, skipping text nodes")]
        public virtual Element Next(string selector)
        {
            this.Call("next", selector);
            return this;
        }

        /// <summary>
        /// Gets the next sibling, skipping text nodes
        /// </summary>
        /// <returns>This element</returns>
        [Description("Gets the next sibling, skipping text nodes")]
        public virtual Element Next()
        {
            this.Call("next");
            return this;
        }

        /// <summary>
        /// Gets the parent node for this element, optionally chaining up trying to match a selector
        /// </summary>
        /// <param name="selector">Find a parent node that matches the passed simple selector</param>
        /// <returns>This element</returns>
        [Description("Gets the parent node for this element, optionally chaining up trying to match a selector")]
        public virtual Element Parent(string selector)
        {
            this.Call("parent", selector);
            return this;
        }

        /// <summary>
        /// Gets the parent node for this element, optionally chaining up trying to match a selector
        /// </summary>
        /// <returns>This element</returns>
        [Description("Gets the parent node for this element, optionally chaining up trying to match a selector")]
        public virtual Element Parent()
        {
            this.Call("parent");
            return this;
        }

        /// <summary>
        /// Initializes positioning on this element. If a desired position is not passed, it will make the the element positioned relative IF it is not already positioned.
        /// </summary>
        /// <param name="position">Positioning to use "relative", "absolute" or "fixed"</param>
        /// <param name="zIndex">The zIndex to apply</param>
        /// <param name="x">Set the page X position</param>
        /// <param name="y">Set the page Y position</param>
        /// <returns>This element</returns>
        [Description("Initializes positioning on this element. If a desired position is not passed, it will make the the element positioned relative IF it is not already positioned.")]
        public virtual Element Position(CssPosition position, int zIndex, int x, int y)
        {
            this.Call("positionEx", position.ToString().ToLowerCamelCase(), zIndex, x, y);
            return this;
        }

        /// <summary>
        /// Initializes positioning on this element. If a desired position is not passed, it will make the the element positioned relative IF it is not already positioned.
        /// </summary>
        /// <param name="position">Positioning to use "relative", "absolute" or "fixed"</param>
        /// <param name="zIndex">The zIndex to apply</param>
        /// <returns>This element</returns>
        [Description("Initializes positioning on this element. If a desired position is not passed, it will make the the element positioned relative IF it is not already positioned.")]
        public virtual Element Position(CssPosition position, int zIndex)
        {
            this.Call("positionEx", position.ToString().ToLowerCamelCase(), zIndex);
            return this;
        }

        /// <summary>
        /// Initializes positioning on this element. If a desired position is not passed, it will make the the element positioned relative IF it is not already positioned.
        /// </summary>
        /// <param name="position">Positioning to use "relative", "absolute" or "fixed"</param>
        /// <returns>This element</returns>
        [Description("Initializes positioning on this element. If a desired position is not passed, it will make the the element positioned relative IF it is not already positioned.")]
        public virtual Element Position(CssPosition position)
        {
            this.Call("positionEx", position.ToString().ToLowerCamelCase());
            return this;
        }

        /// <summary>
        /// Initializes positioning on this element. If a desired position is not passed, it will make the the element positioned relative IF it is not already positioned.
        /// </summary>
        /// <returns>This element</returns>
        [Description("Initializes positioning on this element. If a desired position is not passed, it will make the the element positioned relative IF it is not already positioned.")]
        public virtual Element Position()
        {
            this.Call("positionEx");
            return this;
        }

        /// <summary>
        /// Gets the previous sibling, skipping text nodes
        /// </summary>
        /// <param name="selector">Find the previous sibling that matches the passed simple selector</param>
        /// <returns>This element</returns>
        [Description("Gets the previous sibling, skipping text nodes")]
        public virtual Element Prev(string selector)
        {
            this.Call("prev", selector);
            return this;
        }

        /// <summary>
        /// Gets the previous sibling, skipping text nodes
        /// </summary>
        /// <returns>This element</returns>
        [Description("Gets the previous sibling, skipping text nodes")]
        public virtual Element Prev()
        {
            this.Call("prev");
            return this;
        }

        /// <summary>
        /// Adds one or more CSS classes to this element and removes the same class(es) from all siblings.
        /// </summary>
        /// <param name="className">The CSS class to add</param>
        /// <returns>This element</returns>
        [Description("Adds one or more CSS classes to this element and removes the same class(es) from all siblings.")]
        public virtual Element RadioClass(string className)
        {
            this.Call("radioClass", className);
            return this;
        }

        /// <summary>
        /// Adds one or more CSS classes to this element and removes the same class(es) from all siblings.
        /// </summary>
        /// <param name="classNames">The array of CSS classes to add</param>
        /// <returns>This element</returns>
        [Description("Adds one or more CSS classes to this element and removes the same class(es) from all siblings.")]
        public virtual Element RadioClass(string[] classNames)
        {
            this.Call("radioClass", classNames);
            return this;
        }

        /// <summary>
        /// Create an event handler on this element such that when the event fires and is handled by this element, it will be relayed to another object (i.e., fired again as if it originated from that object instead).
        /// </summary>
        /// <param name="eventName">The type of event to relay</param>
        /// <param name="observable">Any object that extends Ext.util.Observable that will provide the context for firing the relayed event</param>
        /// <returns>This element</returns>
        [Description("Create an event handler on this element such that when the event fires and is handled by this element, it will be relayed to another object (i.e., fired again as if it originated from that object instead).")]
        public virtual Element RelayEvent(string eventName, Observable observable)
        {
            this.Call("relayEventEx", eventName, new JRawValue(observable.ClientID));
            return this;
        }

        /// <summary>
        /// Create an event handler on this element such that when the event fires and is handled by this element, it will be relayed to another object (i.e., fired again as if it originated from that object instead).
        /// </summary>
        /// <param name="eventName">The type of event to relay</param>
        /// <param name="observable">Any object that extends Ext.util.Observable that will provide the context for firing the relayed event</param>
        /// <returns>This element</returns>
        [Description("Create an event handler on this element such that when the event fires and is handled by this element, it will be relayed to another object (i.e., fired again as if it originated from that object instead).")]
        public virtual Element RelayEvent(string eventName, string observable)
        {
            this.Call("relayEventEx", eventName, new JRawValue(observable));
            return this;
        }

        /// <summary>
        /// Removes this element from the DOM and deletes it from the cache
        /// </summary>
        [Description("Removes this element from the DOM and deletes it from the cache")]
        public virtual Element Remove()
        {
            this.Call("remove");
            return this;
        }

        /// <summary>
        /// Removes all previous added listeners from this element
        /// </summary>
        [Description("Removes all previous added listeners from this element")]
        public virtual Element RemoveAllListeners()
        {
            this.Call("removeAllListeners");
            return this;
        }

        /// <summary>
        /// Removes one or more CSS classes from the element.
        /// </summary>
        /// <param name="className">The CSS class to remove</param>
        /// <returns>This element</returns>
        [Description("Removes one or more CSS classes from the element.")]
        public virtual Element RemoveClass(string className)
        {
            this.Call("removeClass", className);
            return this;
        }

        /// <summary>
        /// Removes one or more CSS classes from the element.
        /// </summary>
        /// <param name="classNames">The array of CSS classes to remove</param>
        /// <returns>This element</returns>
        [Description("Removes one or more CSS classes from the element.")]
        public virtual Element RemoveClass(string[] classNames)
        {
            this.Call("removeClass", classNames);
            return this;
        }

        /// <summary>
        /// Removes an event handler from this element. Note: if a scope was explicitly specified when adding the listener, the same scope must be specified here. 
        /// </summary>
        /// <param name="eventName">the type of event to remove </param>
        /// <param name="funcName">the method the event invokes</param>
        /// <param name="scope">The scope (The this reference) of the handler function. Defaults to this Element.</param>
        /// <returns>This element</returns>
        [Description("Removes an event handler from this element. Note: if a scope was explicitly specified when adding the listener, the same scope must be specified here. ")]
        public virtual Element RemoveListener(string eventName, string funcName, string scope)
        {
            this.Call("removeListener", eventName, new JRawValue(funcName), new JRawValue(scope));
            return this;
        }

        /// <summary>
        /// Removes an event handler from this element. Note: if a scope was explicitly specified when adding the listener, the same scope must be specified here. 
        /// </summary>
        /// <param name="eventName">the type of event to remove </param>
        /// <param name="funcName">the method the event invokes</param>
        /// <returns>This element</returns>
        [Description("Removes an event handler from this element. Note: if a scope was explicitly specified when adding the listener, the same scope must be specified here. ")]
        public virtual Element RemoveListener(string eventName, string funcName)
        {
            this.Call("removeListener", eventName, new JRawValue(funcName));
            return this;
        }

        /// <summary>
        /// Forces the browser to repaint this element
        /// </summary>
        [Description("Forces the browser to repaint this element")]
        public virtual Element Repaint()
        {
            this.Call("repaint");
            return this;
        }

        /// <summary>
        /// Replaces the passed element with this element
        /// </summary>
        /// <param name="element">The element to replace</param>
        /// <returns>This element</returns>
        [Description("Replaces the passed element with this element")]
        public virtual Element Replace(Element element)
        {
            this.Call("replace", new JRawValue(element.Descriptor));
            return this;
        }

        /// <summary>
        /// Replaces a CSS class on the element with another. If the old name does not exist, the new name will simply be added.
        /// </summary>
        /// <param name="oldClassName">The CSS class to replace</param>
        /// <param name="newClassName">The replacement CSS class</param>
        /// <returns>This element</returns>
        [Description("Replaces a CSS class on the element with another. If the old name does not exist, the new name will simply be added.")]
        public virtual Element ReplaceClass(string oldClassName, string newClassName)
        {
            this.Call("replaceClass", oldClassName, newClassName);
            return this;
        }

        /// <summary>
        /// Replaces this element with the passed element
        /// </summary>
        /// <param name="element">The new element or a DomHelper config of an element to create</param>
        /// <returns>This element</returns>
        [Description("Replaces this element with the passed element")]
        public virtual Element ReplaceWith(Element element)
        {
            this.Call("replaceWith", new JRawValue(element.Descriptor));
            return this;
        }

        /// <summary>
        /// Replaces this element with the passed element
        /// </summary>
        /// <param name="element">The new element or a DomHelper config of an element to create</param>
        /// <returns>This element</returns>
        [Description("Replaces this element with the passed element")]
        public virtual Element ReplaceWith(DomObject element)
        {
            this.Call("replaceWith", new JRawValue(element.Serialize()));
            return this;
        }

        /// <summary>
        /// Scrolls this element the specified direction. Does bounds checking to make sure the scroll is within this element's scrollable range.
        /// </summary>
        /// <param name="direction">Scroll direction</param>
        /// <param name="distance">How far to scroll the element in pixels</param>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Scrolls this element the specified direction. Does bounds checking to make sure the scroll is within this element's scrollable range.")]
        public virtual Element Scroll(Direction direction, int distance, bool animate)
        {
            this.Call("scrollEx", direction.ToString().ToLowerCamelCase(), distance, animate);
            return this;
        }

        /// <summary>
        /// Scrolls this element the specified direction. Does bounds checking to make sure the scroll is within this element's scrollable range.
        /// </summary>
        /// <param name="direction">Scroll direction</param>
        /// <param name="distance">How far to scroll the element in pixels</param>
        /// <param name="animate">standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Scrolls this element the specified direction. Does bounds checking to make sure the scroll is within this element's scrollable range.")]
        public virtual Element Scroll(Direction direction, int distance, ElementFxConfig animate)
        {
            this.Call("scrollEx", direction.ToString().ToLowerCamelCase(), distance, new JRawValue(new ClientConfig().Serialize(animate, true)));
            return this;
        }

        /// <summary>
        /// Scrolls this element the specified direction. Does bounds checking to make sure the scroll is within this element's scrollable range.
        /// </summary>
        /// <param name="direction">Scroll direction</param>
        /// <param name="distance">How far to scroll the element in pixels</param>
        /// <returns>This element</returns>
        [Description("Scrolls this element the specified direction. Does bounds checking to make sure the scroll is within this element's scrollable range.")]
        public virtual Element Scroll(Direction direction, int distance)
        {
            this.Call("scrollEx", direction.ToString().ToLowerCamelCase(), distance);
            return this;
        }

        /// <summary>
        /// Scrolls this element into view within the passed container.
        /// </summary>
        /// <param name="container">The container element to scroll (defaults to document.body).</param>
        /// <param name="hscroll">False to disable horizontal scroll (defaults to true)</param>
        /// <returns>This element</returns>
        [Description("Scrolls this element into view within the passed container.")]
        public virtual Element ScrollIntoView(Element container, bool hscroll)
        {
            this.Call("scrollIntoView", new JRawValue(container.Descriptor), hscroll);
            return this;
        }

        /// <summary>
        /// Scrolls this element into view within the passed container.
        /// </summary>
        /// <param name="container">The container element to scroll (defaults to document.body).</param>
        /// <returns>This element</returns>
        [Description("Scrolls this element into view within the passed container.")]
        public virtual Element ScrollIntoView(Element container)
        {
            this.Call("scrollIntoView", new JRawValue(container.Descriptor));
            return this;
        }

        /// <summary>
        /// Scrolls this element into view within the passed container.
        /// </summary>
        /// <returns>This element</returns>
        [Description("Scrolls this element into view within the passed container.")]
        public virtual Element ScrollIntoView()
        {
            this.Call("scrollIntoView");
            return this;
        }

        /// <summary>
        /// Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().
        /// </summary>
        /// <param name="side">Either "Left" for scrollLeft values or "Top" for scrollTop values.</param>
        /// <param name="value">The new scroll value</param>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().")]
        public virtual Element ScrollTo(Direction side, int value, bool animate)
        {
            if (!(side == Direction.Left || side == Direction.Top))
            {
                throw new ArgumentException("Side can accept the following values only: Top, Left", "side");
            }
            this.Call("scrollTo", side.ToString().ToLowerCamelCase(), value, animate);
            return this;
        }

        /// <summary>
        /// Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().
        /// </summary>
        /// <param name="side">Either "Left" for scrollLeft values or "Top" for scrollTop values.</param>
        /// <param name="value">The new scroll value</param>
        /// <param name="animate">standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().")]
        public virtual Element ScrollTo(Direction side, int value, ElementFxConfig animate)
        {
            if (!(side == Direction.Left || side == Direction.Top))
            {
                throw new ArgumentException("Side can accept the following values only: Top, Left", "side");
            }
            this.Call("scrollTo", side.ToString().ToLowerCamelCase(), value, new JRawValue(new ClientConfig().Serialize(animate, true)));
            return this;
        }

        /// <summary>
        /// Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().
        /// </summary>
        /// <param name="side">Either "Left" for scrollLeft values or "Top" for scrollTop values.</param>
        /// <param name="value">The new scroll value</param>
        /// <returns>This element</returns>
        [Description("Scrolls this element the specified scroll point. It does NOT do bounds checking so if you scroll to a weird value it will try to do it. For auto bounds checking, use scroll().")]
        public virtual Element ScrollTo(Direction side, int value)
        {
            if (!(side == Direction.Left || side == Direction.Top))
            {
                throw new ArgumentException("Side can accept the following values only: Top, Left", "side");
            }
            this.Call("scrollTo", side.ToString().ToLowerCamelCase(), value);
            return this;
        }

        /// <summary>
        /// Sets the passed attributes as attributes of this element (a style attribute can be a string, object or function)
        /// </summary>
        /// <param name="o">The object with the attributes</param>
        /// <param name="useSet">false to override the default setAttribute to use expandos.</param>
        /// <returns>This element</returns>
        [Description("Sets the passed attributes as attributes of this element (a style attribute can be a string, object or function)")]
        public virtual Element Set(JsonObject o, bool useSet)
        {
            this.Call("set", o, useSet);
            return this;
        }

        /// <summary>
        /// Sets the passed attributes as attributes of this element (a style attribute can be a string, object or function)
        /// </summary>
        /// <param name="o">The object with the attributes</param>
        /// <returns>This element</returns>
        [Description("Sets the passed attributes as attributes of this element (a style attribute can be a string, object or function)")]
        public virtual Element Set(JsonObject o)
        {
            this.Call("set", o);
            return this;
        }

        /// <summary>
        /// Sets the element's CSS bottom style.
        /// </summary>
        /// <param name="bottom">The bottom CSS property value</param>
        /// <returns>This element</returns>
        [Description("Sets the element's CSS bottom style.")]
        public virtual Element SetBottom(string bottom)
        {
            this.Call("setBottom", bottom);
            return this;
        }

        /// <summary>
        /// Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.")]
        public virtual Element SetBounds(int x, int y, int width, int height, bool animate)
        {
            this.Call("setBounds", x, y, width, height, animate);
            return this;
        }

        /// <summary>
        /// Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.")]
        public virtual Element SetBounds(int x, int y, int width, int height, ElementFxConfig animate)
        {
            this.Call("setBounds", x, y, width, height, new JRawValue(new ClientConfig().Serialize(animate, true)));
            return this;
        }

        /// <summary>
        /// Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <returns>This element</returns>
        [Description("Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.")]
        public virtual Element SetBounds(int x, int y, string width, string height)
        {
            this.Call("setBounds", x, y, width, height);
            return this;
        }

        /// <summary>
        /// Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <returns>This element</returns>
        [Description("Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.")]
        public virtual Element SetBounds(int x, int y, int width, string height)
        {
            this.Call("setBounds", x, y, width, height);
            return this;
        }

        /// <summary>
        /// Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="width">The new width</param>
        /// <param name="height">The new height</param>
        /// <returns>This element</returns>
        [Description("Sets the element's position and size in one shot. If animation is true then width, height, x and y will be animated concurrently.")]
        public virtual Element SetBounds(int x, int y, string width, int height)
        {
            this.Call("setBounds", x, y, width, height);
            return this;
        }

        /// <summary>
        /// Sets the element's box.
        /// </summary>
        /// <param name="box">The box to fill {x, y, width, height}</param>
        /// <param name="adjust">Whether to adjust for box-model issues automatically</param>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Sets the element's box.")]
        public virtual Element SetBox(Box box, bool adjust, bool animate)
        {
            this.Call("setBox", new JRawValue(box.Serialize()), adjust, animate);
            return this;
        }

        /// <summary>
        /// Sets the element's box.
        /// </summary>
        /// <param name="box">The box to fill {x, y, width, height}</param>
        /// <param name="adjust">Whether to adjust for box-model issues automatically</param>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Sets the element's box.")]
        public virtual Element SetBox(Box box, bool adjust, ElementFxConfig animate)
        {
            this.Call("setBox", new JRawValue(box.Serialize()), adjust, new JRawValue(new ClientConfig().Serialize(this, true)));
            return this;
        }

        /// <summary>
        /// Sets the element's box.
        /// </summary>
        /// <param name="box">The box to fill {x, y, width, height}</param>
        /// <param name="adjust">Whether to adjust for box-model issues automatically</param>
        /// <returns>This element</returns>
        [Description("Sets the element's box.")]
        public virtual Element SetBox(Box box, bool adjust)
        {
            this.Call("setBox", new JRawValue(box.Serialize()), adjust);
            return this;
        }

        /// <summary>
        /// Sets the element's box.
        /// </summary>
        /// <param name="box">The box to fill {x, y, width, height}</param>
        /// <returns>This element</returns>
        [Description("Sets the element's box.")]
        public virtual Element SetBox(Box box)
        {
            this.Call("setBox", new JRawValue(box.Serialize()));
            return this;
        }

        /// <summary>
        /// Sets the CSS display property. Uses originalDisplay if the specified value is a boolean true.
        /// </summary>
        /// <param name="value">Boolean value to display the element using its default display</param>
        /// <returns>This element</returns>
        [Description("Sets the CSS display property. Uses originalDisplay if the specified value is a boolean true.")]
        public virtual Element SetDisplayed(bool value)
        {
            this.Call("setDisplayed", value);
            return this;
        }

        /// <summary>
        /// Sets the CSS display property.
        /// </summary>
        /// <param name="value">String to set the display directly.</param>
        /// <returns>This element</returns>
        [Description("Sets the CSS display property.")]
        public virtual Element SetDisplayed(string value)
        {
            this.Call("setDisplayed", value);
            return this;
        }

        /// <summary>
        /// Set the height of this Element.
        /// </summary>
        /// <param name="value">The new height</param>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Set the height of this Element.")]
        public virtual Element SetHeight(int value, bool animate)
        {
            this.Call("setHeight", value, animate);
            return this;
        }

        /// <summary>
        /// Set the height of this Element.
        /// </summary>
        /// <param name="value">The new height</param>
        /// <param name="animate">standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Set the height of this Element.")]
        public virtual Element SetHeight(int value, ElementFxConfig animate)
        {
            this.Call("setHeight", value, new JRawValue(new ClientConfig().Serialize(animate)));
            return this;
        }

        /// <summary>
        /// Set the height of this Element.
        /// </summary>
        /// <param name="value">The new height</param>
        /// <returns>This element</returns>
        [Description("Set the height of this Element.")]
        public virtual Element SetHeight(string value)
        {
            this.Call("setHeight", value);
            return this;
        }

        /// <summary>
        /// Sets the element's left position directly using CSS style (instead of setX).
        /// </summary>
        /// <param name="left">The left CSS property value</param>
        /// <returns>This element</returns>
        [Description("Sets the element's left position directly using CSS style (instead of setX).")]
        public virtual Element SetLeft(string left)
        {
            this.Call("setLeft", left);
            return this;
        }

        /// <summary>
        /// Quick set left and top adding default units
        /// </summary>
        /// <param name="left">The left CSS property value</param>
        /// <param name="top">The top CSS property value</param>
        /// <returns>This element</returns>
        [Description("Quick set left and top adding default units")]
        public virtual Element SetLeftTop(string left, string top)
        {
            this.Call("setLeftTop", left, top);
            return this;
        }

        /// <summary>
        /// Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="animate">True for the default animation</param>
        /// <returns>This element</returns>
        [Description("Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element SetLocation(int x, int y, bool animate)
        {
            this.Call("setLocation", x, y, animate);
            return this;
        }

        /// <summary>
        /// Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <param name="animate">Standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element SetLocation(int x, int y, ElementFxConfig animate)
        {
            this.Call("setLocation", x, y, new JRawValue(new ClientConfig().Serialize(animate)));
            return this;
        }

        /// <summary>
        /// Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X value for new position (coordinates are page-based)</param>
        /// <param name="y">Y value for new position (coordinates are page-based)</param>
        /// <returns>This element</returns>
        [Description("Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element SetLocation(int x, int y)
        {
            this.Call("setLocation", x, y);
            return this;
        }

        /// <summary>
        /// Set the opacity of the element
        /// </summary>
        /// <param name="opacity">The new opacity. 0 = transparent, .5 = 50% visibile, 1 = fully visible, etc</param>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Set the opacity of the element")]
        public virtual Element SetOpacity(double opacity, bool animate)
        {
            this.Call("setOpacity", opacity, animate);
            return this;
        }

        /// <summary>
        /// Set the opacity of the element
        /// </summary>
        /// <param name="opacity">The new opacity. 0 = transparent, .5 = 50% visibile, 1 = fully visible, etc</param>
        /// <returns>This element</returns>
        [Description("Set the opacity of the element")]
        public virtual Element SetOpacity(double opacity)
        {
            this.Call("setOpacity", opacity);
            return this;
        }

        /// <summary>
        /// Set the opacity of the element
        /// </summary>
        /// <param name="opacity">The new opacity. 0 = transparent, .5 = 50% visibile, 1 = fully visible, etc</param>
        /// <param name="animate">standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Set the opacity of the element")]
        public virtual Element SetOpacity(double opacity, ElementFxConfig animate)
        {
            this.Call("setOpacity", opacity, new JRawValue(new ClientConfig().Serialize(animate)));
            return this;
        }

        /// <summary>
        /// Sets the element's CSS right style.
        /// </summary>
        /// <param name="right">The right CSS property value</param>
        /// <returns>This element</returns>
        [Description("Sets the element's CSS right style.")]
        public virtual Element SetRight(string right)
        {
            this.Call("setRight", right);
            return this;
        }

        /// <summary>
        /// Set the size of this Element. If animation is true, both width and height will be animated concurrently.
        /// </summary>
        /// <param name="width">A Number specifying the new width</param>
        /// <param name="height">A Number specifying the new height</param>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Set the size of this Element. If animation is true, both width and height will be animated concurrently.")]
        public virtual Element SetSize(int width, int height, bool animate)
        {
            this.Call("setSize", width, height, animate);
            return this;
        }

        /// <summary>
        /// Set the size of this Element. If animation is true, both width and height will be animated concurrently.
        /// </summary>
        /// <param name="width">A Number specifying the new width</param>
        /// <param name="height">A Number specifying the new height</param>
        /// <param name="animate">Standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Set the size of this Element. If animation is true, both width and height will be animated concurrently.")]
        public virtual Element SetSize(int width, int height, ElementFxConfig animate)
        {
            this.Call("setSize", width, height, new JRawValue(new ClientConfig().Serialize(animate)));
            return this;
        }

        /// <summary>
        /// Set the size of this Element. If animation is true, both width and height will be animated concurrently.
        /// </summary>
        /// <param name="width">A Number specifying the new width</param>
        /// <param name="height">A Number specifying the new height</param>
        /// <returns>This element</returns>
        [Description("Set the size of this Element. If animation is true, both width and height will be animated concurrently.")]
        public virtual Element SetSize(int width, int height)
        {
            this.Call("setSize", width, height);
            return this;
        }

        /// <summary>
        /// Set the size of this Element. If animation is true, both width and height will be animated concurrently.
        /// </summary>
        /// <param name="width">A String used to set the CSS width style</param>
        /// <param name="height">A String used to set the CSS height style.</param>
        /// <returns>This element</returns>
        [Description("Set the size of this Element. If animation is true, both width and height will be animated concurrently.")]
        public virtual Element SetSize(string width, string height)
        {
            this.Call("setSize", width, height);
            return this;
        }

        /// <summary>
        /// Set the size of this Element. If animation is true, both width and height will be animated concurrently.
        /// </summary>
        /// <param name="width">A Number specifying the new width</param>
        /// <param name="height">A String used to set the CSS height style.</param>
        /// <returns>This element</returns>
        [Description("Set the size of this Element. If animation is true, both width and height will be animated concurrently.")]
        public virtual Element SetSize(int width, string height)
        {
            this.Call("setSize", width, height);
            return this;
        }

        /// <summary>
        /// Set the size of this Element. If animation is true, both width and height will be animated concurrently.
        /// </summary>
        /// <param name="width">A String used to set the CSS width style</param>
        /// <param name="height">A Number specifying the new height</param>
        /// <returns>This element</returns>
        [Description("Set the size of this Element. If animation is true, both width and height will be animated concurrently.")]
        public virtual Element SetSize(string width, int height)
        {
            this.Call("setSize", width, height);
            return this;
        }

        /// <summary>
        /// Wrapper for setting style properties, also takes single object parameter of multiple styles.
        /// </summary>
        /// <param name="properties">Object of multiple styles</param>
        /// <returns>This element</returns>
        [Description("Wrapper for setting style properties, also takes single object parameter of multiple styles.")]
        public virtual Element SetStyle(JsonObject properties)
        {
            this.Call("setStyle", properties);
            return this;
        }

        /// <summary>
        /// Wrapper for setting style properties, also takes single object parameter of multiple styles.
        /// </summary>
        /// <param name="property">The style property to be set</param>
        /// <param name="value">The value to apply to the given property</param>
        /// <returns>This element</returns>
        [Description("Wrapper for setting style properties, also takes single object parameter of multiple styles.")]
        public virtual Element SetStyle(string property, string value)
        {
            this.Call("setStyle", property, value);
            return this;
        }

        /// <summary>
        /// Sets the element's top position directly using CSS style (instead of setY).
        /// </summary>
        /// <param name="top">The top CSS property value</param>
        /// <returns>This element</returns>
        [Description("Sets the element's top position directly using CSS style (instead of setY).")]
        public virtual Element SetTop(string top)
        {
            this.Call("setTop", top);
            return this;
        }

        /// <summary>
        /// Sets the .value property of the Elements dom object if it exists.
        /// </summary>
        /// <param name="value">The value to set the Elements dom object with.</param>
        /// <returns>This element</returns>
        [Description("Sets the .value property of the Elements dom object if it exists.")]
        public virtual Element SetValue(object value)
        {
            this.Call("setValue", value);
            return this;
        }

        /// <summary>
        /// Sets the element's visibility mode. When setVisible() is called it will use this to determine whether to set the visibility or the display property.
        /// </summary>
        /// <param name="mode">Visibility mode</param>
        /// <returns>This element</returns>
        [Description("Sets the element's visibility mode. When setVisible() is called it will use this to determine whether to set the visibility or the display property.")]
        public virtual Element SetVisibilityMode(VisibilityMode mode)
        {
            string strMode = "";
            switch (mode)
            {
                case VisibilityMode.Visibility:
                    strMode = "Ext.Element.VISIBILITY";
                    break;
                case VisibilityMode.Display:
                    strMode = "Ext.Element.DISPLAY";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }
            this.Call("setVisibilityMode", new JRawValue(strMode));
            return this;
        }

        /// <summary>
        /// Sets the visibility of the element (see details). If the visibilityMode is set to Element.DISPLAY, it will use the display property to hide the element, otherwise it uses visibility. The default is to hide and show using the visibility property.
        /// </summary>
        /// <param name="visible">Whether the element is visible</param>
        /// <param name="animate">True for the default animation</param>
        /// <returns>This element</returns>
        [Description("Sets the visibility of the element (see details). If the visibilityMode is set to Element.DISPLAY, it will use the display property to hide the element, otherwise it uses visibility. The default is to hide and show using the visibility property.")]
        public virtual Element SetVisible(bool visible, bool animate)
        {
            this.Call("setVisible", visible, animate);
            return this;
        }

        /// <summary>
        /// Sets the visibility of the element (see details). If the visibilityMode is set to Element.DISPLAY, it will use the display property to hide the element, otherwise it uses visibility. The default is to hide and show using the visibility property.
        /// </summary>
        /// <param name="visible">Whether the element is visible</param>
        /// <param name="animate">standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Sets the visibility of the element (see details). If the visibilityMode is set to Element.DISPLAY, it will use the display property to hide the element, otherwise it uses visibility. The default is to hide and show using the visibility property.")]
        public virtual Element SetVisible(bool visible, ElementFxConfig animate)
        {
            this.Call("setVisible", visible, new JRawValue(new ClientConfig().Serialize(animate)));
            return this;
        }

        /// <summary>
        /// Set the width of this Element.
        /// </summary>
        /// <param name="width">The new width</param>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Set the width of this Element.")]
        public virtual Element SetWidth(int width, bool animate)
        {
            this.Call("setWidth", width, animate);
            return this;
        }

        /// <summary>
        /// Set the width of this Element.
        /// </summary>
        /// <param name="width">The new width</param>
        /// <param name="animate">standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Set the width of this Element.")]
        public virtual Element SetWidth(int width, ElementFxConfig animate)
        {
            this.Call("setWidth", width, new JRawValue(new ClientConfig().Serialize(animate)));
            return this;
        }

        /// <summary>
        /// Set the width of this Element.
        /// </summary>
        /// <param name="width">The new width</param>
        /// <returns>This element</returns>
        [Description("Set the width of this Element.")]
        public virtual Element SetWidth(string width)
        {
            this.Call("setWidth", width);
            return this;
        }

        /// <summary>
        /// Sets the X position of the element based on page coordinates. Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X position of the element</param>
        /// <param name="animate">True for the default animation</param>
        /// <returns>This element</returns>
        [Description("Sets the X position of the element based on page coordinates. Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element SetX(int x, bool animate)
        {
            this.Call("setX", x, animate);
            return this;
        }

        /// <summary>
        /// Sets the X position of the element based on page coordinates. Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X position of the element</param>
        /// <param name="animate">Standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Sets the X position of the element based on page coordinates. Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element SetX(int x, ElementFxConfig animate)
        {
            this.Call("setX", x, new JRawValue(new ClientConfig().Serialize(animate)));
            return this;
        }

        /// <summary>
        /// Sets the X position of the element based on page coordinates. Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X position of the element</param>
        /// <returns>This element</returns>
        [Description("Sets the X position of the element based on page coordinates. Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element SetX(int x)
        {
            this.Call("setX", x);
            return this;
        }

        /// <summary>
        /// Sets the Y position of the element based on page coordinates. Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="y">Y position of the element</param>
        /// <param name="animate">True for the default animation</param>
        /// <returns>This element</returns>
        [Description("Sets the Y position of the element based on page coordinates. Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element SetY(int y, bool animate)
        {
            this.Call("setY", y, animate);
            return this;
        }

        /// <summary>
        /// Sets the Y position of the element based on page coordinates. Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="y">Y position of the element</param>
        /// <param name="animate">Standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Sets the Y position of the element based on page coordinates. Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element SetY(int y, ElementFxConfig animate)
        {
            this.Call("setY", y, new JRawValue(new ClientConfig().Serialize(animate)));
            return this;
        }

        /// <summary>
        /// Sets the Y position of the element based on page coordinates. Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="y">Y position of the element</param>
        /// <returns>This element</returns>
        [Description("Sets the Y position of the element based on page coordinates. Element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element SetY(int y)
        {
            this.Call("setY", y);
            return this;
        }

        /// <summary>
        /// Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X position of the element</param>
        /// <param name="y">Y position of the element</param>
        /// <param name="animate">True for the default animation</param>
        /// <returns>This element</returns>
        [Description("Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element SetXY(int x, int y, bool animate)
        {
            this.Call("setXY", new int[]{x,y}, animate);
            return this;
        }

        /// <summary>
        /// Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X position of the element</param>
        /// <param name="y">Y position of the element</param>
        /// <param name="animate">Standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element SetXY(int x, int y, ElementFxConfig animate)
        {
            this.Call("setXY", new int[] { x, y }, new JRawValue(new ClientConfig().Serialize(animate)));
            return this;
        }

        /// <summary>
        /// Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).
        /// </summary>
        /// <param name="x">X position of the element</param>
        /// <param name="y">Y position of the element</param>
        /// <returns>This element</returns>
        [Description("Sets the position of the element in page coordinates, regardless of how the element is positioned. The element must be part of the DOM tree to have page coordinates (display:none or elements not appended return false).")]
        public virtual Element SetXY(int x, int y)
        {
            this.Call("setXY", new int[] { x, y });
            return this;
        }


        /// <summary>
        /// Selects elements based on the passed CSS selector to enable Element methods to be applied to many related elements in one statement
        /// </summary>
        /// <param name="selector">The CSS selector or an array of elements</param>
        /// <param name="unique">true to create a unique Ext.Element for each element (defaults to a shared flyweight object)</param>
        /// <param name="root">id of the root</param>
        /// <returns>Elements</returns>
        [Description("Selects elements based on the passed CSS selector to enable Element methods to be applied to many related elements in one statement")]
        public virtual Element Select(string selector, bool unique, string root)
        {
            this.EnsureChaining();
            this.Call("select", selector, unique, root);
            return this;
        }

        /// <summary>
        /// Selects elements based on the passed CSS selector to enable Element methods to be applied to many related elements in one statement
        /// </summary>
        /// <param name="selector">The CSS selector or an array of elements</param>
        /// <param name="unique">true to create a unique Ext.Element for each element (defaults to a shared flyweight object)</param>
        /// <returns>Elements</returns>
        [Description("Selects elements based on the passed CSS selector to enable Element methods to be applied to many related elements in one statement")]
        public virtual Element Select(string selector, bool unique)
        {
            this.EnsureChaining();
            this.Call("select", selector, unique);
            return this;
        }

        /// <summary>
        /// Selects elements based on the passed CSS selector to enable Element methods to be applied to many related elements in one statement
        /// </summary>
        /// <param name="selector">The CSS selector or an array of elements</param>
        /// <returns>Elements</returns>
        [Description("Selects elements based on the passed CSS selector to enable Element methods to be applied to many related elements in one statement")]
        public virtual Element Select(string selector)
        {
            this.EnsureChaining();
            this.Call("select", selector);
            return this;
        }

        /// <summary>
        /// Selects first element based on the passed CSS selector
        /// </summary>
        /// <param name="selector">The CSS selector</param>
        /// <returns>Elements</returns>
        [Description("Selects first element based on the passed CSS selector")]
        public virtual Element SingleSelect(string selector)
        {
            this.EnsureChaining();
            this.Call("singleSelect", selector);
            return this;
        }

        /// <summary>
        /// Selects first element based on the passed CSS selector
        /// </summary>
        /// <param name="selector">The CSS selector</param>
        /// <param name="unique">true to create a unique Ext.Element for each element</param>
        /// <returns>Elements</returns>
        [Description("Selects first element based on the passed CSS selector")]
        public virtual Element SingleSelect(string selector, bool unique)
        {
            this.EnsureChaining();
            this.Call("singleSelect", selector, unique);
            return this;
        }

        /// <summary>
        /// Show this element - Uses display mode to determine whether to use "display" or "visibility". See setVisible.
        /// </summary>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Show this element - Uses display mode to determine whether to use 'display' or 'visibility'. See setVisible.")]
        public virtual Element Show(bool animate)
        {
            this.Call("show", animate);
            return this;
        }

        /// <summary>
        /// Show this element - Uses display mode to determine whether to use "display" or "visibility". See setVisible.
        /// </summary>
        /// <param name="animate">Standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Show this element - Uses display mode to determine whether to use 'display' or 'visibility'. See setVisible.")]
        public virtual Element Show(ElementFxConfig animate)
        {
            this.Call("show", new JRawValue(new ClientConfig().Serialize(animate)));
            return this;
        }

        /// <summary>
        /// Show this element - Uses display mode to determine whether to use "display" or "visibility". See setVisible.
        /// </summary>
        /// <returns>This element</returns>
        [Description("Show this element - Uses display mode to determine whether to use 'display' or 'visibility'. See setVisible.")]
        public virtual Element Show()
        {
            this.Call("show");
            return this;
        }

        /// <summary>
        /// Stops the specified event(s) from bubbling and optionally prevents the default action
        /// </summary>
        /// <param name="eventName">an event / array of events to stop from bubbling</param>
        /// <param name="preventDefault">true to prevent the default action too</param>
        /// <returns>This element</returns>
        [Description("Stops the specified event(s) from bubbling and optionally prevents the default action")]
        public virtual Element SwallowEvent(string eventName, bool preventDefault)
        {
            this.Call("swallowEvent", eventName, preventDefault);
            return this;
        }

        /// <summary>
        /// Stops the specified event(s) from bubbling and optionally prevents the default action
        /// </summary>
        /// <param name="eventName">an event / array of events to stop from bubbling</param>
        /// <returns>This element</returns>
        [Description("Stops the specified event(s) from bubbling and optionally prevents the default action")]
        public virtual Element SwallowEvent(string eventName)
        {
            this.Call("swallowEvent", eventName);
            return this;
        }

        /// <summary>
        /// Stops the specified event(s) from bubbling and optionally prevents the default action
        /// </summary>
        /// <param name="eventNames">an event / array of events to stop from bubbling</param>
        /// <param name="preventDefault">true to prevent the default action too</param>
        /// <returns>This element</returns>
        [Description("Stops the specified event(s) from bubbling and optionally prevents the default action")]
        public virtual Element SwallowEvent(string[] eventNames, bool preventDefault)
        {
            this.Call("swallowEvent", eventNames, preventDefault);
            return this;
        }

        /// <summary>
        /// Stops the specified event(s) from bubbling and optionally prevents the default action
        /// </summary>
        /// <param name="eventNames">an event / array of events to stop from bubbling</param>
        /// <returns>This element</returns>
        [Description("Stops the specified event(s) from bubbling and optionally prevents the default action")]
        public virtual Element SwallowEvent(string[] eventNames)
        {
            this.Call("swallowEvent", eventNames);
            return this;
        }

        /// <summary>
        /// Toggles the element's visibility or display, depending on visibility mode.
        /// </summary>
        /// <param name="animate">true for the default animation</param>
        /// <returns>This element</returns>
        [Description("Toggles the element's visibility or display, depending on visibility mode.")]
        public virtual Element Toggle(bool animate)
        {
            this.Call("toggle", animate);
            return this;
        }

        /// <summary>
        /// Toggles the element's visibility or display, depending on visibility mode.
        /// </summary>
        /// <param name="animate">Standard Element animation config object</param>
        /// <returns>This element</returns>
        [Description("Toggles the element's visibility or display, depending on visibility mode.")]
        public virtual Element Toggle(ElementFxConfig animate)
        {
            this.Call("toggle", new JRawValue(new ClientConfig().Serialize(animate)));
            return this;
        }

        /// <summary>
        /// Toggles the element's visibility or display, depending on visibility mode.
        /// </summary>
        /// <returns>This element</returns>
        [Description("Toggles the element's visibility or display, depending on visibility mode.")]
        public virtual Element Toggle()
        {
            this.Call("toggle");
            return this;
        }

        /// <summary>
        /// Toggles the specified CSS class on this element (removes it if it already exists, otherwise adds it).
        /// </summary>
        /// <param name="className">The CSS class to toggle</param>
        /// <returns>This element</returns>
        [Description("Toggles the specified CSS class on this element (removes it if it already exists, otherwise adds it).")]
        public virtual Element ToggleClass(string className)
        {
            this.Call("toggleClass", className);
            return this;
        }

        /// <summary>
        /// Return clipping (overflow) to original clipping before clip was called
        /// </summary>
        /// <returns>This element</returns>
        [Description("Return clipping (overflow) to original clipping before clip was called")]
        public virtual Element Unclip()
        {
            this.Call("unclip");
            return this;
        }

        /// <summary>
        /// Removes a previously applied mask.
        /// </summary>
        /// <returns>This element</returns>
        [Description("Removes a previously applied mask.")]
        public virtual Element Unmask()
        {
            this.Call("unmaskEx");
            return this;
        }

        /// <summary>
        /// Disables text selection for this element (normalized across browsers)
        /// </summary>
        /// <returns>This element</returns>
        [Description("Disables text selection for this element (normalized across browsers)")]
        public virtual Element Unselectable()
        {
            this.Call("unselectable");
            return this;
        }

        /// <summary>
        /// Walks up the dom looking for a parent node that matches the passed simple selector (e.g. div.some-class or span:first-child). This is a shortcut for findParentNode() that always returns an Ext.Element.
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">The max depth to search as a number </param>
        /// <returns>The matching DOM node</returns>
        [Description("Walks up the dom looking for a parent node that matches the passed simple selector (e.g. div.some-class or span:first-child). This is a shortcut for findParentNode() that always returns an Ext.Element.")]
        public virtual Element Up(string selector, int maxDepth)
        {
            this.EnsureChaining();
            this.Call("up", selector, maxDepth);
            return this;
        }

        /// <summary>
        /// Walks up the dom looking for a parent node that matches the passed simple selector (e.g. div.some-class or span:first-child). This is a shortcut for findParentNode() that always returns an Ext.Element.
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <param name="maxDepth">The max depth to search as a element</param>
        /// <returns>The matching DOM node</returns>
        [Description("Walks up the dom looking for a parent node that matches the passed simple selector (e.g. div.some-class or span:first-child). This is a shortcut for findParentNode() that always returns an Ext.Element.")]
        public virtual Element Up(string selector, Element maxDepth)
        {
            this.EnsureChaining();
            this.Call("up", selector, new JRawValue(maxDepth.Descriptor));
            return this;
        }

        /// <summary>
        /// Walks up the dom looking for a parent node that matches the passed simple selector (e.g. div.some-class or span:first-child). This is a shortcut for findParentNode() that always returns an Ext.Element.
        /// </summary>
        /// <param name="selector">The simple selector to test</param>
        /// <returns>The matching DOM node</returns>
        [Description("Walks up the dom looking for a parent node that matches the passed simple selector (e.g. div.some-class or span:first-child). This is a shortcut for findParentNode() that always returns an Ext.Element.")]
        public virtual Element Up(string selector)
        {
            this.EnsureChaining();
            this.Call("up", selector);
            return this;
        }

        /// <summary>
        /// Update the innerHTML of this element, optionally searching for and processing scripts
        /// </summary>
        /// <param name="html">The new HTML</param>
        /// <param name="loadScripts">True to look for and process scripts (defaults to false)</param>
        /// <param name="callback">For async script loading you can be notified when the update completes</param>
        /// <returns>This element</returns>
        [Description("Update the innerHTML of this element, optionally searching for and processing scripts")]
        public virtual Element Update(string html, bool loadScripts, JFunction callback)
        {
            this.Call("update", Element.ConvertToSafeJSHtml(html), loadScripts, callback);
            return this;
        }

        /// <summary>
        /// Update the innerHTML of this element, optionally searching for and processing scripts
        /// </summary>
        /// <param name="html">The new HTML</param>
        /// <param name="loadScripts">True to look for and process scripts (defaults to false)</param>
        /// <returns>This element</returns>
        [Description("Update the innerHTML of this element, optionally searching for and processing scripts")]
        public virtual Element Update(string html, bool loadScripts)
        {
            this.Call("update", Element.ConvertToSafeJSHtml(html), loadScripts);
            return this;
        }

        /// <summary>
        /// Update the innerHTML of this element, optionally searching for and processing scripts
        /// </summary>
        /// <param name="html">The new HTML</param>
        /// <returns>This element</returns>
        [Description("Update the innerHTML of this element, optionally searching for and processing scripts")]
        public virtual Element Update(string html)
        {
            this.Call("update", Element.ConvertToSafeJSHtml(html));
            return this;
        }

        /// <summary>
        /// Creates and wraps this element with another element
        /// </summary>
        /// <param name="config">DomHelper element config object for the wrapper element</param>
        /// <returns>The newly created wrapper element</returns>
        [Description("Creates and wraps this element with another element")]
        public virtual Element Wrap(DomObject config)
        {
            this.Call("wrap", new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Creates and wraps this element with another element
        /// </summary>
        /// <returns>The newly created wrapper element</returns>
        [Description("Creates and wraps this element with another element")]
        public virtual Element Wrap()
        {
            this.Call("wrap");
            return this;
        }

        #endregion

        #region CompositeElement methods
        
        /// <summary>
        /// Adds elements to this composite.
        /// </summary>
        /// <param name="selector">A string CSS selector</param>
        /// <returns>Elements</returns>
        [Description("Adds elements to this composite.")]
        public virtual Element Add(string selector)
        {
            this.EnsureChaining();
            this.Call("add", selector);
            return this;
        }

        /// <summary>
        /// Adds elements to this composite.
        /// </summary>
        /// <param name="elements">an array of elements or an element</param>
        /// <returns>Elements</returns>
        [Description("Adds elements to this composite.")]
        public virtual Element Add(Element[] elements)
        {
            this.EnsureChaining();

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (Element element in elements)
            {
                sb.Append(element.Descriptor).Append(",");
            }
            sb.Remove(sb.Length-1,1).Append("]");

            this.Call("add", new JRawValue(sb.ToString()));
            return this;
        }

        /// <summary>
        /// Calls the passed function passing (el, this, index) for each element in this composite.
        /// </summary>
        /// <param name="fn">The function to call</param>
        /// <param name="scope">The this object (defaults to the element)</param>
        /// <returns>Elements</returns>
        [Description("Calls the passed function passing (el, this, index) for each element in this composite.")]
        public virtual Element Each(JFunction fn, string scope)
        {
            this.EnsureChaining();
            this.Call("each", fn, new JRawValue(scope));
            return this;
        }

        /// <summary>
        /// Calls the passed function passing (el, this, index) for each element in this composite.
        /// </summary>
        /// <param name="fn">The function to call</param>
        /// <returns>Elements</returns>
        [Description("Calls the passed function passing (el, this, index) for each element in this composite.")]
        public virtual Element Each(JFunction fn)
        {
            this.EnsureChaining();
            this.Call("each", fn);
            return this;
        }

        /// <summary>
        /// Filters this composite to only elements that match the passed selector.
        /// </summary>
        /// <param name="selector">A string CSS selector</param>
        /// <returns>Elements</returns>
        [Description("Filters this composite to only elements that match the passed selector.")]
        public virtual Element Filter(string selector)
        {
            this.EnsureChaining();
            this.Call("filter", selector);
            return this;
        }

        /// <summary>
        /// Returns the Element object at the specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [Description("Returns the Element object at the specified index")]
        public virtual Element Item(int index)
        {
            this.EnsureChaining();
            this.Call("item", index);
            return this;
        }

        /// <summary>
        /// Removes the specified element(s).
        /// </summary>
        /// <param name="index">the index of the element in this composite</param>
        /// <param name="removeDom">True to also remove the element from the document</param>
        /// <returns></returns>
        [Description("Removes the specified element(s).")]
        public virtual Element RemoveElement(int index, bool removeDom)
        {
            this.EnsureChaining();
            this.Call("removeElement", index, removeDom);
            return this;
        }

        /// <summary>
        /// Removes the specified element(s).
        /// </summary>
        /// <param name="index">the index of the element in this composite</param>
        /// <returns></returns>
        [Description("Removes the specified element(s).")]
        public virtual Element RemoveElement(int index)
        {
            this.EnsureChaining();
            this.Call("removeElement", index);
            return this;
        }

        /// <summary>
        /// Removes the specified element(s).
        /// </summary>
        /// <param name="id">The id of an element</param>
        /// <param name="removeDom">True to also remove the element from the document</param>
        /// <returns></returns>
        [Description("Removes the specified element(s).")]
        public virtual Element RemoveElement(string id, bool removeDom)
        {
            this.EnsureChaining();
            this.Call("removeElement", id, removeDom);
            return this;
        }

        /// <summary>
        /// Removes the specified element(s).
        /// </summary>
        /// <param name="id">The id of an element</param>
        /// <returns></returns>
        [Description("Removes the specified element(s).")]
        public virtual Element RemoveElement(string id)
        {
            this.EnsureChaining();
            this.Call("removeElement", id);
            return this;
        }

        #endregion

        #region Fx
        
        /// <summary>
        /// Fade an element in (from transparent to opaque). The ending opacity can be specified using the endOpacity config option.
        /// </summary>
        /// <param name="config">Object literal with any of the Fx config options</param>
        /// <returns>The Element</returns>
        [Description("Fade an element in (from transparent to opaque). The ending opacity can be specified using the endOpacity config option.")]
        public virtual Element FadeIn(FadeInConfig config)
        {
            this.Call("fadeIn", new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Fade an element out (from opaque to transparent). The ending opacity can be specified using the endOpacity config option. Note that IE may require useDisplay:true in order to redisplay correctly.
        /// </summary>
        /// <param name="config">Object literal with any of the Fx config options</param>
        /// <returns>The Element</returns>
        [Description("Fade an element out (from opaque to transparent). The ending opacity can be specified using the endOpacity config option. Note that IE may require useDisplay:true in order to redisplay correctly.")]
        public virtual Element FadeOut(FadeOutConfig config)
        {
            this.Call("fadeOut", new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Shows a ripple of exploding, attenuating borders to draw attention to an Element
        /// </summary>
        /// <param name="color">The color of the border. Should be a 6 char hex color without the leading # (defaults to light blue: 'C3DAF9').</param>
        /// <param name="count">The number of ripples to display (defaults to 1)</param>
        /// <param name="config">Object literal with any of the Fx config options</param>
        /// <returns>The Element</returns>
        [Description("Shows a ripple of exploding, attenuating borders to draw attention to an Element")]
        public virtual Element Frame(string color, int count, FxConfig config)
        {
            this.Call("frame", color, count, new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Shows a ripple of exploding, attenuating borders to draw attention to an Element
        /// </summary>
        /// <param name="color">The color of the border. Should be a 6 char hex color without the leading # (defaults to light blue: 'C3DAF9').</param>
        /// <param name="count">The number of ripples to display (defaults to 1)</param>
        /// <returns>The Element</returns>
        [Description("Shows a ripple of exploding, attenuating borders to draw attention to an Element")]
        public virtual Element Frame(string color, int count)
        {
            this.Call("frame", color, count);
            return this;
        }

        /// <summary>
        /// Shows a ripple of exploding, attenuating borders to draw attention to an Element
        /// </summary>
        /// <param name="color">The color of the border. Should be a 6 char hex color without the leading # (defaults to light blue: 'C3DAF9').</param>
        /// <returns>The Element</returns>
        [Description("Shows a ripple of exploding, attenuating borders to draw attention to an Element")]
        public virtual Element Frame(string color)
        {
            this.Call("frame", color);
            return this;
        }

        /// <summary>
        /// Shows a ripple of exploding, attenuating borders to draw attention to an Element
        /// </summary>
        /// <returns>The Element</returns>
        [Description("Shows a ripple of exploding, attenuating borders to draw attention to an Element")]
        public virtual Element Frame()
        {
            this.Call("frame");
            return this;
        }

        /// <summary>
        /// Slides the element while fading it out of view. An anchor point can be optionally passed to set the ending point of the effect.
        /// </summary>
        /// <param name="anchor">One of the valid Fx anchor positions (defaults to bottom: 'b')</param>
        /// <param name="config">Object literal with any of the Fx config options</param>
        /// <returns>The Element</returns>
        [Description("Slides the element while fading it out of view. An anchor point can be optionally passed to set the ending point of the effect.")]
        public virtual Element Ghost(string anchor, FxConfig config)
        {
            this.Call("ghost", anchor, new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Slides the element while fading it out of view. An anchor point can be optionally passed to set the ending point of the effect.
        /// </summary>
        /// <param name="anchor">One of the valid Fx anchor positions (defaults to bottom: 'b')</param>
        /// <returns>The Element</returns>
        [Description("Slides the element while fading it out of view. An anchor point can be optionally passed to set the ending point of the effect.")]
        public virtual Element Ghost(string anchor)
        {
            this.Call("ghost", anchor);
            return this;
        }

        /// <summary>
        /// Slides the element while fading it out of view. An anchor point can be optionally passed to set the ending point of the effect.
        /// </summary>
        /// <returns>The Element</returns>
        [Description("Slides the element while fading it out of view. An anchor point can be optionally passed to set the ending point of the effect.")]
        public virtual Element Ghost()
        {
            this.Call("ghost");
            return this;
        }

        /// <summary>
        /// Highlights the Element by setting a color (applies to the background-color by default, but can be changed using the "attr" config option) and then fading back to the original color. If no original color is available, you should provide the "endColor" config option which will be cleared after the animation.
        /// </summary>
        /// <param name="color">The highlight color. Should be a 6 char hex color without the leading # (defaults to yellow: 'ffff9c')</param>
        /// <param name="config">Object literal with any of the Fx config options</param>
        /// <returns>The Element</returns>
        [Description("Highlights the Element by setting a color (applies to the background-color by default, but can be changed using the 'attr' config option) and then fading back to the original color. If no original color is available, you should provide the 'endColor' config option which will be cleared after the animation.")]
        public virtual Element Highlight(string color, HighlightConfig config)
        {
            this.Call("highlight", color, new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Highlights the Element by setting a color (applies to the background-color by default, but can be changed using the "attr" config option) and then fading back to the original color. If no original color is available, you should provide the "endColor" config option which will be cleared after the animation.
        /// </summary>
        /// <param name="color">The highlight color. Should be a 6 char hex color without the leading # (defaults to yellow: 'ffff9c')</param>
        /// <returns>The Element</returns>
        [Description("Highlights the Element by setting a color (applies to the background-color by default, but can be changed using the 'attr' config option) and then fading back to the original color. If no original color is available, you should provide the 'endColor' config option which will be cleared after the animation.")]
        public virtual Element Highlight(string color)
        {
            this.Call("highlight", color);
            return this;
        }

        /// <summary>
        /// Highlights the Element by setting a color (applies to the background-color by default, but can be changed using the "attr" config option) and then fading back to the original color. If no original color is available, you should provide the "endColor" config option which will be cleared after the animation.
        /// </summary>
        /// <returns>The Element</returns>
        [Description("Highlights the Element by setting a color (applies to the background-color by default, but can be changed using the 'attr' config option) and then fading back to the original color. If no original color is available, you should provide the 'endColor' config option which will be cleared after the animation.")]
        public virtual Element Highlight()
        {
            this.Call("highlight");
            return this;
        }

        /// <summary>
        /// Creates a pause before any subsequent queued effects begin. If there are no effects queued after the pause it will have no effect.
        /// </summary>
        /// <param name="seconds">The length of time to pause (in seconds)</param>
        /// <returns>The Element</returns>
        [Description("Creates a pause before any subsequent queued effects begin. If there are no effects queued after the pause it will have no effect.")]
        public virtual Element Pause(int seconds)
        {
            this.Call("pause", seconds);
            return this;
        }

        /// <summary>
        /// Fades the element out while slowly expanding it in all directions. When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired.
        /// </summary>
        /// <param name="config">Object literal with any of the Fx config options</param>
        /// <returns>The Element</returns>
        [Description("Fades the element out while slowly expanding it in all directions. When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired.")]
        public virtual Element Puff(FxConfig config)
        {
            this.Call("puff", new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Fades the element out while slowly expanding it in all directions. When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired.
        /// </summary>
        /// <returns>The Element</returns>
        [Description("Fades the element out while slowly expanding it in all directions. When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired.")]
        public virtual Element Puff()
        {
            this.Call("puff");
            return this;
        }

        /// <summary>
        /// Animates the transition of an element's dimensions from a starting height/width to an ending height/width. This method is a convenience implementation of shift. 
        /// </summary>
        /// <param name="width">The new width (pass undefined to keep the original width)</param>
        /// <param name="height">The new height (pass undefined to keep the original height)</param>
        /// <param name="config">Object literal with any of the Fx config options</param>
        /// <returns>The Element</returns>
        [Description("Animates the transition of an element's dimensions from a starting height/width to an ending height/width. This method is a convenience implementation of shift. ")]
        public virtual Element Scale(int? width, int? height, FxConfig config)
        {
            this.Call("scale", width.HasValue ? (object)width.Value : new JRawValue("undefined"), height.HasValue ? (object)height.Value : new JRawValue("undefined"), new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Animates the transition of an element's dimensions from a starting height/width to an ending height/width. This method is a convenience implementation of shift. 
        /// </summary>
        /// <param name="width">The new width (pass undefined to keep the original width)</param>
        /// <param name="height">The new height (pass undefined to keep the original height)</param>
        /// <returns>The Element</returns>
        [Description("Animates the transition of an element's dimensions from a starting height/width to an ending height/width. This method is a convenience implementation of shift. ")]
        public virtual Element Scale(int? width, int? height)
        {
            this.Call("scale", width.HasValue ? (object)width.Value : new JRawValue("undefined"), height.HasValue ? (object)height.Value : new JRawValue("undefined"));
            return this;
        }

        /// <summary>
        /// Ensures that all effects queued after sequenceFx is called on the element are run in sequence. This is the opposite of syncFx.
        /// </summary>
        /// <returns>The Element</returns>
        [Description("Ensures that all effects queued after sequenceFx is called on the element are run in sequence. This is the opposite of syncFx.")]
        public virtual Element SequenceFx()
        {
            this.Call("sequenceFx");
            return this;
        }

        /// <summary>
        /// Animates the transition of any combination of an element's dimensions, xy position and/or opacity. Any of these properties not specified in the config object will not be changed. This effect requires that at least one new dimension, position or opacity setting must be passed in on the config object in order for the function to have any effect. 
        /// </summary>
        /// <param name="config">Object literal with any of the Fx config options</param>
        /// <returns>The Element</returns>
        [Description("Animates the transition of any combination of an element's dimensions, xy position and/or opacity. Any of these properties not specified in the config object will not be changed. This effect requires that at least one new dimension, position or opacity setting must be passed in on the config object in order for the function to have any effect. ")]
        public virtual Element Shift(ShiftConfig config)
        {
            this.Call("shift", new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Slides the element into view. An anchor point can be optionally passed to set the point of origin for the slide effect. This function automatically handles wrapping the element with a fixed-size container if needed. See the Fx class overview for valid anchor point options. 
        /// </summary>
        /// <param name="anchor">One of the valid Fx anchor positions (defaults to top: 't')</param>
        /// <param name="config">Object literal with any of the Fx config options</param>
        /// <returns>The Element</returns>
        [Description("Slides the element into view. An anchor point can be optionally passed to set the point of origin for the slide effect. This function automatically handles wrapping the element with a fixed-size container if needed. See the Fx class overview for valid anchor point options. ")]
        public virtual Element SlideIn(string anchor, FxConfig config)
        {
            this.Call("slideIn", anchor, new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Slides the element into view. An anchor point can be optionally passed to set the point of origin for the slide effect. This function automatically handles wrapping the element with a fixed-size container if needed. See the Fx class overview for valid anchor point options. 
        /// </summary>
        /// <param name="anchor">One of the valid Fx anchor positions (defaults to top: 't')</param>
        /// <returns>The Element</returns>
        [Description("Slides the element into view. An anchor point can be optionally passed to set the point of origin for the slide effect. This function automatically handles wrapping the element with a fixed-size container if needed. See the Fx class overview for valid anchor point options. ")]
        public virtual Element SlideIn(string anchor)
        {
            this.Call("slideIn", anchor);
            return this;
        }

        /// <summary>
        /// Slides the element into view. An anchor point can be optionally passed to set the point of origin for the slide effect. This function automatically handles wrapping the element with a fixed-size container if needed. See the Fx class overview for valid anchor point options. 
        /// </summary>
        /// <returns>The Element</returns>
        [Description("Slides the element into view. An anchor point can be optionally passed to set the point of origin for the slide effect. This function automatically handles wrapping the element with a fixed-size container if needed. See the Fx class overview for valid anchor point options. ")]
        public virtual Element SlideIn()
        {
            this.Call("slideIn");
            return this;
        }

        /// <summary>
        /// Slides the element out of view. An anchor point can be optionally passed to set the end point for the slide effect. When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired. This function automatically handles wrapping the element with a fixed-size container if needed.
        /// </summary>
        /// <param name="anchor">One of the valid Fx anchor positions (defaults to top: 't')</param>
        /// <param name="config">Object literal with any of the Fx config options</param>
        /// <returns>The Element</returns>
        [Description("Slides the element out of view. An anchor point can be optionally passed to set the end point for the slide effect. When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired. This function automatically handles wrapping the element with a fixed-size container if needed.")]
        public virtual Element SlideOut(string anchor, FxConfig config)
        {
            this.Call("slideOut", anchor, new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Slides the element out of view. An anchor point can be optionally passed to set the end point for the slide effect. When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired. This function automatically handles wrapping the element with a fixed-size container if needed.
        /// </summary>
        /// <param name="anchor">One of the valid Fx anchor positions (defaults to top: 't')</param>
        /// <returns>The Element</returns>
        [Description("Slides the element out of view. An anchor point can be optionally passed to set the end point for the slide effect. When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired. This function automatically handles wrapping the element with a fixed-size container if needed.")]
        public virtual Element SlideOut(string anchor)
        {
            this.Call("slideOut", anchor);
            return this;
        }

        /// <summary>
        /// Slides the element out of view. An anchor point can be optionally passed to set the end point for the slide effect. When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired. This function automatically handles wrapping the element with a fixed-size container if needed.
        /// </summary>
        /// <returns>The Element</returns>
        [Description("Slides the element out of view. An anchor point can be optionally passed to set the end point for the slide effect. When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired. This function automatically handles wrapping the element with a fixed-size container if needed.")]
        public virtual Element SlideOut()
        {
            this.Call("slideOut");
            return this;
        }

        /// <summary>
        /// Stops any running effects and clears the element's internal effects queue if it contains any additional effects that haven't started yet.
        /// </summary>
        /// <returns>The Element</returns>
        [Description("Stops any running effects and clears the element's internal effects queue if it contains any additional effects that haven't started yet.")]
        public virtual Element StopFx()
        {
            this.Call("stopFx");
            return this;
        }

        /// <summary>
        /// Blinks the element as if it was clicked and then collapses on its center (similar to switching off a television). When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired. 
        /// </summary>
        /// <param name="config">Object literal with any of the Fx config options</param>
        /// <returns>The Element</returns>
        [Description("Blinks the element as if it was clicked and then collapses on its center (similar to switching off a television). When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired. ")]
        public virtual Element SwitchOff(FxConfig config)
        {
            this.Call("switchOff", new JRawValue(config.Serialize()));
            return this;
        }

        /// <summary>
        /// Blinks the element as if it was clicked and then collapses on its center (similar to switching off a television). When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired. 
        /// </summary>
        /// <returns>The Element</returns>
        [Description("Blinks the element as if it was clicked and then collapses on its center (similar to switching off a television). When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired. ")]
        public virtual Element SwitchOff()
        {
            this.Call("switchOff");
            return this;
        }

        /// <summary>
        /// Ensures that all effects queued after syncFx is called on the element are run concurrently. This is the opposite of sequenceFx.
        /// </summary>
        /// <returns>The Element</returns>
        [Description("Ensures that all effects queued after syncFx is called on the element are run concurrently. This is the opposite of sequenceFx.")]
        public virtual Element SyncFx()
        {
            this.Call("syncFx");
            return this;
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public class ElementAnimationConfig : Dictionary<string, ElementAnimationProperty>
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Serialize()
        {
            StringWriter sw = new StringWriter();
            JsonTextWriter writer = new JsonTextWriter(sw);

            writer.QuoteName = true;
            JsonSerializer serializer = new JsonSerializer();
            serializer.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            serializer.DefaultValueHandling = DefaultValueHandling.Ignore;
            serializer.Serialize(writer, this);
            return sw.GetStringBuilder().ToString();
        }
    }
}