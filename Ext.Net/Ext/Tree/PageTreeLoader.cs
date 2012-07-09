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

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class PageTreeLoader : TreeLoader
    {
        /// <summary>
		/// 
		/// </summary>
		[Category("0. About")]
		[Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.net.PageTreeLoader";
            }
        }

        private static readonly object EventNodeLoad = new object();

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public delegate void NodeLoadEventHandler(object sender, NodeLoadEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        [Category("Action")]
        [Description("")]
        public event NodeLoadEventHandler NodeLoad
        {
            add
            {
                this.Events.AddHandler(EventNodeLoad, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventNodeLoad, value);
            }
        }

        internal virtual void OnNodeLoad(NodeLoadEventArgs e)
        {
            NodeLoadEventHandler handler = (NodeLoadEventHandler)Events[EventNodeLoad];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// True if the form object is a file upload
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("True if the form object is a file upload")]
        public bool IsUpload
        {
            get
            {
                object obj = this.ViewState["IsUpload"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["IsUpload"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(ViewStateMode.Inherit)]
        [NotifyParentProperty(true)]
        [Description("")]
        public ViewStateMode ViewStateMode
        {
            get
            {
                object obj = this.ViewState["ViewStateMode"];

                if (obj == null || ((ViewStateMode)obj) == ViewStateMode.Inherit)
                {
                    if (HttpContext.Current != null)
                    {
                        ResourceManager sm = ResourceManager.GetInstance(HttpContext.Current);

                        if (sm == null)
                        {
                            return ViewStateMode.Inherit;
                        }

                        return sm.AjaxViewStateMode;
                    }
                    return ViewStateMode.Inherit;
                }
                else
                {
                    return (ViewStateMode)obj;
                }
            }
            set
            {
                this.ViewState["ViewStateMode"] = value;
            }
        }

        /// <summary>
        /// The type of DirectEvent to perform. The 'Submit' type will submit the &lt;form> and 'Load' will make a POST request to url set in the .Url property, or the current url if the .Url property has not been set.
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(DirectEventType.Submit)]
        [NotifyParentProperty(true)]
        [Description("The type of DirectEvent to perform. The 'Submit' type will submit the &lt;form> and 'Load' will make a POST request to url set in the .Url property, or the current url if the .Url property has not been set.")]
        public DirectEventType Type
        {
            get
            {
                object obj = this.ViewState["Type"];
                return obj != null ? (DirectEventType)obj : DirectEventType.Submit;
            }
            set
            {
                this.ViewState["Type"] = value;
            }
        }

        /// <summary>
        /// The id of the form to submit. If this.ParentForm is not null then this.ParentForm.ClientID is used, else if FormID is empty then FormID is used, else try to find the form in dom tree hierarchy, otherwise the Url of current page is used.
        /// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [Description("The id of the form to submit. If this.ParentForm is not null then this.ParentForm.ClientID is used, else if FormID is empty then FormID is used, else try to find the form in dom tree hierarchy, otherwise the Url of current page is used.")]
        public string FormID
        {
            get
            {
                return (string)this.ViewState["FormID"] ?? "";
            }
            set
            {
                this.ViewState["FormID"] = value;
            }
        }

        /// <summary>
        /// The HTTP request method for loading data.
        /// </summary>
        [ConfigOption(JsonMode.Ignore)]
        [Category("3. PageTreeLoader")]
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("The HTTP request method for loading data.")]
        public override HttpMethod RequestMethod
        {
            get
            {
                object obj = this.ViewState["RequestMethod"];
                return obj == null ? HttpMethod.Default : (HttpMethod)obj;
            }
            set
            {
                this.ViewState["RequestMethod"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
        [DefaultValue(HttpMethod.Default)]
        [ConfigOption("method")]
		[Description("")]
        protected virtual HttpMethod MethodProxy
        {
            get
            {
                if (this.Owner != null && this.Owner is XControl)
                {
                    XControl control = (XControl)this.Owner;

                    if (control != null)
                    {
                        if (this.RequestMethod == HttpMethod.Default && !control.IsInForm)
                        {
                            return HttpMethod.GET;
                        }
                    }
                }

                return this.RequestMethod;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [DefaultValue("")]
        [Description("")]
        public string FormProxyArg
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return "";
                }

                string formId = "";

                if (this.FormID.IsNotEmpty())
                {
                    formId = this.FormID;
                }
                /*else if (this.Owner != null && this.Owner.Page.Form != null)
                {
                    formId = this.Owner.Page.Form.ClientID;
                }*/

                return formId;
            }
        }

        private EventMask eventMask;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Object)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [Description("")]
        public EventMask EventMask
        {
            get
            {
                if (this.eventMask == null)
                {
                    this.eventMask = new EventMask();
                }

                return this.eventMask;
            }
        }
    }
}