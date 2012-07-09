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
    public partial class BaseDirectEvent : BaseListener
    {
        /// <summary>
        /// Only extra params will be added to request. Useful if request has web-service Url
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("Only extra params will be added to request. Useful if request has web-service Url")]
        public bool CleanRequest
        {
            get
            {
                bool defValue = this.ResourceManager != null ? (this.ResourceManager.IsMVC && this.Url.IsNotEmpty()) : false;
                object obj = this.ViewState["CleanRequest"];
                return obj != null ? (bool)obj : defValue;
            }
            set
            {
                this.ViewState["CleanRequest"] = value;
            }
        }

        /// <summary>
        /// True to add a unique cache-buster param to GET requests.
        /// </summary>
        [DefaultValue(null)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("True to add a unique cache-buster param to GET requests.")]
        public bool? DisableCaching
        {
            get
            {
                object obj = this.ViewState["DisableCaching"];
                return obj != null ? (bool?)obj : null;
            }
            set
            {
                this.ViewState["DisableCaching"] = value;
            }
        }

        /// <summary>
        /// Change the parameter which is sent went disabling caching through a cache buster. Defaults to '_dc'
        /// </summary>
        [ConfigOption]
        [DefaultValue("_dc")]
        [NotifyParentProperty(true)]
        [Description("Change the parameter which is sent went disabling caching through a cache buster. Defaults to '_dc'")]
        public string DisableCachingParam
        {
            get
            {
                return (string)this.ViewState["DisableCachingParam"] ?? "_dc";
            }
            set
            {
                this.ViewState["DisableCachingParam"] = value;
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
        /// True to add json header
        /// </summary>
        [DefaultValue(false)]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [Description("True if the form object is a file upload")]
        public bool Json
        {
            get
            {
                object obj = this.ViewState["Json"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["Json"] = value;
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
        /// The id of the form to submit. If this.ParentForm is not null then this.ParentForm.ClientID is used, else if FormID is empty the Page.Form.ClientID is used, else try to find the form in dom tree hierarchy, otherwise the Url of current page is used.
        /// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [Description("The id of the form to submit. If this.ParentForm is not null then this.ParentForm.ClientID is used, else if FormID is empty the Page.Form.ClientID is used, else try to find the form in dom tree hierarchy, otherwise the Url of current page is used.")]
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
        /// The default URL to be used for requests to the server. (defaults to '')
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The default URL to be used for requests to the server if DirectEventType.Request. (defaults to '')")]
        public string Url
        {
            get
            {
                return (string)this.ViewState["Url"] ?? "";
            }
            set
            {
                this.ViewState["Url"] = value;
            }
        }

        /// <summary>
        /// The default URL to be used for requests to the server if DirectEventType.Request. (defaults to '')
        /// </summary>
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [ConfigOption("url")]
        [Description("The default URL to be used for requests to the server if DirectEventType.Request. (defaults to '')")]
        protected string UrlProxy
        {
            get
            {
                if (this.Url.IsEmpty())
                {
                    return "";
                }

                Control c = this.Owner;

                if (c == null)
                {
                    c = this.ResourceManager;
                }

                return c != null ? c.ResolveUrl(this.Url) : this.Url;
            }
        }

        /// <summary>
        /// The HTTP method to use. Defaults to POST if params are present, or GET if not.
        /// </summary>
        [ConfigOption("method")]
        [DefaultValue(HttpMethod.Default)]
        [NotifyParentProperty(true)]
        [Description("The HTTP method to use. Defaults to POST if params are present, or GET if not.")]
        public virtual HttpMethod Method
        {
            get
            {
                object obj = this.ViewState["Method"];
                return (obj == null) ? HttpMethod.Default : (HttpMethod)obj;
            }
            set
            {
                this.ViewState["Method"] = value;
            }
        }

        /// <summary>
        /// The timeout in milliseconds to be used for requests. (defaults to 30000)
        /// </summary>
        [ConfigOption]
        [NotifyParentProperty(true)]
        [DefaultValue(30000)]
        [Description("The timeout in milliseconds to be used for requests. (defaults to 30000)")]
        public int Timeout
        {
            get
            {
                object obj = this.ViewState["Timeout"];
                return obj == null ? 30000 : (int)obj;
            }
            set
            {
                this.ViewState["Timeout"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [DefaultValue("")]
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
                /*else if (this.Owner != null && this.Owner.Page != null && this.Owner.Page.Form != null)
                {
                    formId = this.Owner.Page.Form.ClientID;
                }*/

                return formId;
            }
        }

        private ParameterCollection userParams;

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ArrayToObject)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public virtual ParameterCollection ExtraParams
        {
            get
            {
                if (this.userParams == null)
                {
                    this.userParams = new ParameterCollection();
                    this.userParams.Owner = this.Owner;
                }

                return this.userParams;
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

        /// <summary>
        /// Show warning if request fail. If Failure handler exists then this handler will be called instead showing warning
        /// </summary>
        [ConfigOption]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("Show a Window with error message is DirectEvent request fails. This message Window will only show if a Failure Handler does not exist.")]
        public virtual bool ShowWarningOnFailure
        {
            get
            {
                object obj = this.ViewState["ShowWarningOnFailure"];
                return obj != null ? (bool)obj : true;
            }
            set
            {
                this.ViewState["ShowWarningOnFailure"] = value;
            }
        }
    }


    /*  EventMask
    -----------------------------------------------------------------------------------------------*/

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class EventMask : LoadMask
    {
        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Category("Config Options")]
        [Localizable(true)]
        [DefaultValue("Working...")]
        [Description("")]
        public override string Msg
        {
            get
            {
                return (string)this.ViewState["Msg"] ?? "Working...";
            }
            set
            {
                this.ViewState["Msg"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.ToLower)]
        [DefaultValue(MaskTarget.Page)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual MaskTarget Target
        {
            get
            {
                object obj = this.ViewState["Target"];
                return obj != null ? (MaskTarget)obj : MaskTarget.Page;
            }
            set
            {
                this.ViewState["Target"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual string CustomTarget
        {
            get
            {
                return (string)this.ViewState["CustomTarget"] ?? "";
            }
            set
            {
                this.ViewState["CustomTarget"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(0)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual int MinDelay
        {
            get
            {
                object obj = this.ViewState["MinDelay"];
                return obj != null ? (int)obj : 0;
            }
            set
            {
                this.ViewState["MinDelay"] = value;
            }
        }
    }
}