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
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;
using System.Web.UI.WebControls;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class X : ExtNet { }

    /// <summary>
    /// Ext core utilities and functions.
    /// </summary>
    [Description("")]
    public partial class ExtNet
    {
        /*  Properties
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Determines if the current HttpRequest is an Ext.NET Ajax Request.
        /// </summary>
        [Description("Determines if the current HttpRequest is an Ext.NET Ajax Request.")]
        public static bool IsAjaxRequest
        {
            get
            {
                return RequestManager.IsAjaxRequest;
            }
        }

        /// <summary>
        /// Returns an instance of the current Ext.NET ResourceManager.
        /// </summary>
        [Description("Returns an instance of the current ResourceManager.")]
        public static ResourceManager ResourceManager
        {
            get
            {
                return ExtNet.Js.ResourceManager;
            }
        }

        /*  Methods
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Copies all the properties of config to obj.
        /// </summary>
        /// <param name="obj">The receiver of the properties</param>
        /// <param name="config">The source of the properties</param>
        /// <returns>obj</returns>
        [Description("Copies all the properties of config to obj.")]
        public static object Apply(object obj, object config)
        {
            return ObjectUtils.Apply(obj, config);
        }

        /// <summary>
        /// Copies all the properties of config to obj.
        /// </summary>
        /// <typeparam name="T">The Type of the obj param.</typeparam>
        /// <param name="obj">The receiver of the properties</param>
        /// <param name="config">The source of the properties</param>
        /// <returns>obj as T</returns>
        public static T Apply<T>(object obj, object config) where T : IComponent
        {
            return ObjectUtils.Apply<T>(obj, config);
        }

        /// <summary>
        /// Redirects a client to a new Url.
        /// </summary>
        /// <param name="url">The location of the target.</param>
        [Description("Redirects a client to a new Url.")]
        public static void Redirect(string url)
        {
            ResponseManager.Redirect(url);
        }

        /// <summary>
        /// Redirects a client to a new Url.
        /// </summary>
        /// <param name="url">The location of the target.</param>
        /// <param name="msg">The message to display in the loading mask which is rendered during the Redirect.</param>
        [Description("Redirects a client to a new Url.")]
        public static void Redirect(string url, string msg)
        {
            ResponseManager.Redirect(url, msg);
        }

        /// <summary>
        /// Redirects a client to a new Url.
        /// </summary>
        /// <param name="url">The location of the target.</param>
        /// <param name="msg">The message to display in the load mask which is rendered during the Redirect.</param>
        /// <param name="msgCls">A custom css class to apply to the load mask element.</param>
        [Description("Redirects a client to a new Url.")]
        public static void Redirect(string url, string msg, string msgCls)
        {
            ResponseManager.Redirect(url, msg, msgCls);
        }


        /*  Mask
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static Mask Mask
        {
            get
            {
                return (HttpContext.Current.Items["ExtNet.Mask"] ?? (HttpContext.Current.Items["ExtNet.Mask"] = new Mask())) as Mask;
            }
        }


        /*  MessageBox
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static MessageBox Msg
        {
            get
            {
                return ExtNet.MessageBox;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static MessageBox MessageBox
        {
            get
            {
                return (HttpContext.Current.Items["ExtNet.MessageBox"] ?? (HttpContext.Current.Items["ExtNet.MessageBox"] = new MessageBox())) as MessageBox;
            }
        }


        /*  QuickTips
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static QuickTips QuickTips
        {
            get
            {
                return (HttpContext.Current.Items["ExtNet.QuickTips"] ?? (HttpContext.Current.Items["ExtNet.QuickTips"] = new QuickTips())) as QuickTips;
            }
        }


        /*  WindowMgr
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static WindowManager WindowManager
        {
            get
            {
                return (HttpContext.Current.Items["Ext.Net.WindowManager"] ?? (HttpContext.Current.Items["Ext.Net.WindowManager"] = new WindowManager())) as WindowManager;
            }
        }


        /*  Js
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static Js Js
        {
            get
            {
                return (HttpContext.Current.Items["Ext.Net.Js"] ?? (HttpContext.Current.Items["Ext.Net.Js"] = new Js())) as Js;
            }
        }


        /*  ControlMgr
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Get the Control with the specified id.
        /// </summary>
        /// <param name="id">The ID of the Control to find.</param>
        /// <returns>Control</returns>
        [Description("Get the Control with the specified id.")]
        public static Control GetCtl(string id)
        {
            return ControlUtils.FindControl<Control>(ResourceManager.GetInstance(HttpContext.Current), id);
        }

        /// <summary>
        /// Get the Control with the specified id.
        /// </summary>
        /// <typeparam name="T">The Type control to return</typeparam>
        /// <param name="id">The ID of the Control to find.</param>
        /// <returns>Control</returns>
        [Description("Get the Control with the specified id.")]
        public static T GetCtl<T>(string id) where T : Control, new()
        {
            T control = ControlUtils.FindControl<T>(ResourceManager.GetInstance(HttpContext.Current), id) as T 
                ?? new T { ID = id };

            if (control is ITextControl)
            {
                ((ITextControl)control).Text = HttpContext.Current.Request[id];
            }

            return control;
        }


        /*  ComponentMgr
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Returns a Component by id.
        /// </summary>
        /// <param name="id">The Component id</param>
        /// <returns>The Component, or throws ArgumentNullException if not found</returns>        
        public static Component GetCmp(string id)
        {
            Component component = ComponentManager.Get(id);

            return X.SetValue<Component>(component, X.GetValue(id));
        }

        /// <summary>
        /// Returns the Component by id and sets the .Value related fields by calling if available from the Request.
        /// </summary>
        /// <param name="id">The Component id</param>
        /// <typeparam name="T">The Type of Component to return.</typeparam>
        /// <returns>The Component, or throws ArgumentNullException if not found</returns>
        [Description("")]
        public static T GetCmp<T>(string id) where T : Component, new()
        {
            T component = ComponentManager.Get<T>(id) ?? new T { ID = id, IsProxy = true };

            if (X.IsAjaxRequest)
            {
                IXPostBackDataHandler ctrl = component as IXPostBackDataHandler;

                if (ctrl != null && !ctrl.HasLoadPostData)
                {
                    ctrl.LoadPostData(id, HttpContext.Current.Request.Params);
                }
            }

            if (X.ResourceManager == null)
            {
                component.GenerateMethodsCalling = true;
            }

            component.AllowCallbackScriptMonitoring = true;

            return component as T;
        }

        /// <summary>
        /// Returns the Component and sets the .Value related fields by calling if available from the Request.
        /// </summary>
        /// <typeparam name="T">The Type of Component to return</typeparam>
        /// <param name="component">The Component instance</param>
        /// <returns></returns>
        public static T GetCmp<T>(T component) where T : Component, new()
        {
            return X.GetCmp<T>(component.ClientID);
        }

        /// <summary>
        /// Sets the value of the component if the component is a typeof IField. 
        /// </summary>
        /// <typeparam name="T">The Type of Component to return.</typeparam>
        /// <param name="component">The component</param>
        /// <param name="value">The value to set</param>
        /// <returns>Returns the component</returns>
        public static T SetValue<T>(T component, string value) where T : Component
        {
            if (component is IField && value != null)
            {
                (component as IField).Value = value;
            }

            return component as T;
        }

        /// <summary>
        /// Given the ID of a form field, returns the raw submmitted form value as a string. Returns 'null' if value can not be found.
        /// </summary>
        /// <param name="id">The ID of the submitted form field to be found</param>
        /// <returns>The form value as a string, or null if not found.</returns>
        public static string GetValue(string id)
        {
            return HttpContext.Current.Request[id];
        }
        
        
        /*  Element
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// Retrieves Ext.Element objects.
        /// This method does not retrieve Components. This method retrieves Ext.Element objects which encapsulate DOM elements.
        /// Uses simple caching to consistently return the same object. Automatically fixes if an object was recreated with the same id via AJAX or DOM.
        /// </summary>
        /// <param name="control">The Control to get as an Element object.</param>
        /// <returns>Element</returns>
        public static Element Get(Control control)
        {
            return Element.Get(control);
        }

        /// <summary>
        /// Retrieves Ext.Element objects.
        /// This method does not retrieve Components. This method retrieves Ext.Element objects which encapsulate DOM elements.
        /// Uses simple caching to consistently return the same object. Automatically fixes if an object was recreated with the same id via AJAX or DOM.
        /// </summary>
        /// <param name="id">The id of the node</param>
        /// <returns>Element</returns>
        public static Element Get(string id)
        {
            return Element.Get(id);
        }

        /// <summary>
        /// Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element - the dom node can be overwritten by other code. Shorthand of Ext.Element.fly
        /// Use this to make one-time references to DOM elements which are not going to be accessed again either by application code, or by Ext's classes. If accessing an element which will be processed regularly, then Ext.get will be more appropriate to take advantage of the caching provided by the Ext.Element class.
        /// </summary>
        /// <param name="id">The id of the node</param>
        /// <returns>Element</returns>
        public static Element Fly(string id)
        {
            return Element.Fly(id);
        }

        /// <summary>
        /// Gets the globally shared flyweight Element, with the passed node as the active element. Do not store a reference to this element - the dom node can be overwritten by other code. Shorthand of Ext.Element.fly
        /// Use this to make one-time references to DOM elements which are not going to be accessed again either by application code, or by Ext's classes. If accessing an element which will be processed regularly, then Ext.get will be more appropriate to take advantage of the caching provided by the Ext.Element class.
        /// </summary>
        /// <param name="id">The id of the node</param>
        /// <param name="named">Allows for creation of named reusable flyweights to prevent conflicts</param>
        /// <returns>Element</returns>
        public static Element Fly(string id, string named)
        {
            return Element.Fly(id, named);
        }

        /// <summary>
        /// Returns the current document body as an Ext.Element.
        /// </summary>
        /// <returns>Element</returns>
        public static Element Body()
        {
            return Element.Body();
        }

        /// <summary>
        /// Returns the current ASP.NET form as an Ext.Element.
        /// </summary>
        /// <returns>Element</returns>
        public static Element Form()
        {
            return Element.Form();
        }

        /// <summary>
        /// Returns the current HTML document object as an Ext.Element.
        /// </summary>
        /// <returns>Element</returns>
        public static Element Document()
        {
            return Element.Document();
        }

        /// <summary>
        /// Returns the current HTML head object as an Ext.Element.
        /// </summary>
        /// <returns>Element</returns>
        public static Element Head()
        {
            return Element.Head();
        }

        /// <summary>
        /// Selects elements based on the passed CSS selector to enable Element methods to be applied to many related elements in one statement
        /// </summary>
        /// <param name="selector">The CSS selector or an array of elements</param>
        /// <param name="unique">true to create a unique Ext.Element for each element (defaults to a shared flyweight object)</param>
        /// <param name="root">id of the root</param>
        /// <returns>Elements</returns>
        public static Element Select(string selector, bool unique, string root)
        {
            return new Element("Ext.select({0},{1},{2})".FormatWith(JSON.Serialize(selector), JSON.Serialize(unique), JSON.Serialize(root)));
        }

        /// <summary>
        /// Selects elements based on the passed CSS selector to enable Element methods to be applied to many related elements in one statement
        /// </summary>
        /// <param name="selector">The CSS selector or an array of elements</param>
        /// <param name="unique">true to create a unique Ext.Element for each element (defaults to a shared flyweight object)</param>
        /// <returns>Elements</returns>
        public static Element Select(string selector, bool unique)
        {
            return new Element("Ext.select({0},{1})".FormatWith(JSON.Serialize(selector), JSON.Serialize(unique)));
        }

        /// <summary>
        /// Selects elements based on the passed CSS selector to enable Element methods to be applied to many related elements in one statement
        /// </summary>
        /// <param name="selector">The CSS selector or an array of elements</param>
        /// <returns>Elements</returns>
        public static Element Select(string selector)
        {
            return new Element("Ext.select({0})".FormatWith(JSON.Serialize(selector)));
        }

        /// <summary>
        /// Selects first element based on the passed CSS selector
        /// </summary>
        /// <param name="selector">The CSS selector</param>
        /// <returns>Elements</returns>
        public static Element SingleSelect(string selector)
        {
            return new Element("Ext.get(Ext.select({0}).elements[0])".FormatWith(JSON.Serialize(selector)));
        }

        /// <summary>
        /// Selects first element based on the passed CSS selector
        /// </summary>
        /// <param name="selector">The CSS selector</param>
        /// <param name="unique"></param>
        /// <returns>Elements</returns>
        public static Element SingleSelect(string selector, bool unique)
        {
            return new Element("Ext.get(Ext.select({0},{1}).elements[0])".FormatWith(JSON.Serialize(selector), JSON.Serialize(unique)));
        }

        /// <summary>
        /// Selects first element based on the passed CSS selector
        /// </summary>
        /// <param name="selector">The CSS selector</param>
        /// <param name="unique"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public static Element SingleSelect(string selector, bool unique, string root)
        {
            return new Element("Ext.get(Ext.select({0},{1}).elements[0])".FormatWith(JSON.Serialize(selector), JSON.Serialize(unique), JSON.Serialize(root)));
        }


        /*  Js Helpers
            -----------------------------------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="args"></param>
        [Description("")]
        public static void AddScript(string template, params object[] args)
        {
            ExtNet.Js.AddScript(template, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        [Description("")]
        public static void AddScript(string script)
        {
            ExtNet.Js.AddScript(script);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static void Call(string name)
        {
            ExtNet.Js.Call(name);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static void Call(string name, params object[] args)
        {
            ExtNet.Js.Call(name, args);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public static void Set(string name, object value)
        {
            ExtNet.Js.Set(name, value);
        }
    }
}