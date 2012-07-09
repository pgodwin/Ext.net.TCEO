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
    [Meta]
    [Description("")]
    public abstract partial class FormPanelBase : PanelBase
    {
        /// <summary>
        /// (optional) The id of the FORM tag (defaults to an auto-generated id).
        /// </summary>
        [Meta]
        [ConfigOption("formId")]
        [Category("6. FormPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("(optional) The id of the FORM tag (defaults to an auto-generated id).")]
        public virtual string FormID
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
        /// A css class to apply to the x-form-item of fields. This property cascades to child containers.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class to apply to the x-form-item of fields. This property cascades to child containers.")]
        public override string ItemCls
        {
            get
            {
                return (string)this.ViewState["ItemCls"] ?? "";
            }
            set
            {
                this.ViewState["ItemCls"] = value;
            }
        }

        /// <summary>
        /// The milliseconds to poll valid state, ignored if monitorValid is not true (defaults to 200)
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue(200)]
        [NotifyParentProperty(true)]
        [Description("The milliseconds to poll valid state, ignored if monitorValid is not true (defaults to 200)")]
        public virtual int MonitorPoll
        {
            get
            {
                object obj = this.ViewState["MonitorPoll"];
                return (obj == null) ? 200 : (int)obj;
            }
            set
            {
                this.ViewState["MonitorPoll"] = value;
            }
        }

        /// <summary>
        /// If true the form monitors its valid state client-side and fires a looping event with that state. This is required to bind buttons to the valid state using the config value formBind:true on the button.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If true the form monitors its valid state client-side and fires a looping event with that state. This is required to bind buttons to the valid state using the config value formBind:true on the button.")]
        public virtual bool MonitorValid
        {
            get
            {
                object obj = this.ViewState["MonitorValid"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["MonitorValid"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ConfigOption("renderFormElement")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("")]
        public virtual bool RenderFormElement
        {
            get
            {
                object obj = this.ViewState["RenderFormElement"];

                if (obj == null)
                {
                    obj = !this.IsInForm;
                }

                return (bool)obj;
            }
            set
            {
                this.ViewState["RenderFormElement"] = value;
            }
        }

        /*---- BasicForm properties -------*/

        private ParameterCollection baseParams;

        /// <summary>
        /// Parameters to pass with all requests. e.g. baseParams: {id: '123', foo: 'bar'}.
        /// </summary>
        [Meta]
        [Category("6. FormPanel")]
        [ViewStateMember]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Parameters to pass with all requests. e.g. baseParams: {id: '123', foo: 'bar'}.")]
        public virtual ParameterCollection BaseParams
        {
            get
            {
                if (this.baseParams == null)
                {
                    this.baseParams = new ParameterCollection();
                    this.baseParams.Owner = this;
                }

                return this.baseParams;
            }
        }

        private ReaderCollection errorReader;

        /// <summary>
        /// An Ext.data.DataReader (e.g. Ext.data.XmlReader) to be used to read data when reading validation errors on "submit" actions. This is completely optional as there is built-in support for processing JSON.
        /// </summary>
        [Meta]
        [ConfigOption("reader>Reader")]
        [Category("6. FormPanel")]
        [ViewStateMember]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An Ext.data.DataReader (e.g. Ext.data.XmlReader) to be used to read data when reading validation errors on \"submit\" actions. This is completely optional as there is built-in support for processing JSON.")]
        public virtual ReaderCollection ErrorReader
        {
            get
            {
                if (this.errorReader == null)
                {
                    this.errorReader = new ReaderCollection();
                }

                return this.errorReader;
            }
        }

        /// <summary>
        /// Set to true if this form is a file upload.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("Set to true if this form is a file upload.")]
        public virtual bool FileUpload
        {
            get
            {
                object obj = this.ViewState["FileUpload"];
                return obj != null ? (bool)obj : false;
            }
            set
            {
                this.ViewState["FileUpload"] = value;
            }
        }

        /// <summary>
        /// The HTTP method to use. Defaults to POST if params are present, or GET if not.
        /// </summary>
        [Meta]
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
        /// 
        /// </summary>
        [ConfigOption("method")]
        [DefaultValue(HttpMethod.Default)]
        [Description("")]
        protected virtual HttpMethod MethodProxy
        {
            get
            {
                if (this.Method == HttpMethod.Default && this.RenderFormElement)
                {
                    return HttpMethod.POST;
                }
                  
                return this.Method;
            }
        }

        private ReaderCollection reader;

        /// <summary>
        /// An Ext.data.DataReader (e.g. Ext.data.XmlReader) to be used to read data when executing "load" actions. This is optional as there is built-in support for processing JSON.
        /// </summary>
        [Meta]
        [ConfigOption("reader>Reader")]
        [Category("6. FormPanel")]
        [ViewStateMember]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("An Ext.data.DataReader (e.g. Ext.data.XmlReader) to be used to read data when executing \"load\" actions. This is optional as there is built-in support for processing JSON.")]
        public virtual ReaderCollection Reader
        {
            get
            {
                if (this.reader == null)
                {
                    this.reader = new ReaderCollection();
                }

                return this.reader;
            }
        }

        /// <summary>
        /// If set to true, standard HTML form submits are used instead of XHR (Ajax) style form submissions. (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If set to true, standard HTML form submits are used instead of XHR (Ajax) style form submissions. (defaults to false).")]
        public virtual bool StandardSubmit
        {
            get
            {
                object obj = this.ViewState["StandardSubmit"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["StandardSubmit"] = value;
            }
        }

        /// <summary>
        /// Timeout for form actions in seconds (default is 30 seconds).
        /// </summary>
        [Meta]
        [ConfigOption]
        [NotifyParentProperty(true)]
        [DefaultValue(30)]
        [Description("Timeout for form actions in seconds (default is 30 seconds).")]
        public virtual int Timeout
        {
            get
            {
                object obj = this.ViewState["Timeout"];
                return obj == null ? 30 : (int)this.ViewState["Timeout"];
            }
            set
            {
                this.ViewState["Timeout"] = value;
            }
        }

        /// <summary>
        /// If set to true, form.reset() resets to the last loaded or setValues() data instead of when the form was first created.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("6. FormPanel")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        [Description("If set to true, form.reset() resets to the last loaded or setValues() data instead of when the form was first created.")]
        public virtual bool TrackResetOnLoad
        {
            get
            {
                object obj = this.ViewState["TrackResetOnLoad"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["TrackResetOnLoad"] = value;
            }
        }

        /// <summary>
        /// The URL to use for form actions if one isn't supplied in the action options.
        /// </summary>
        [Meta]
        [Category("6. FormPanel")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The URL to use for form actions if one isn't supplied in the action options.")]
        public virtual string Url
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
        /// 
        /// </summary>
        [ConfigOption("url")]
        [DefaultValue("")]
        [Description("")]
        protected virtual string UrlProxy
        {
            get
            {
                if (this.Url.IsEmpty())
                {
                    if (HttpContext.Current != null && HttpContext.Current.Request.RawUrl.IsNotEmpty())
                    {
                        return HttpContext.Current.Request.RawUrl;
                    }
                    
                    return "";
                }

                return this.ResolveClientUrl(this.Url);
            }
        }

        /// <summary>
        /// A CSS style specification string to add to each field element in this layout (defaults to '').
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [Description("A CSS style specification string to add to each field element in this layout (defaults to '').")]
        public virtual string ElementStyle
        {
            get
            {
                return (string)this.ViewState["ElementStyle"] ?? "";
            }
            set
            {
                this.ViewState["ElementStyle"] = value;
            }
        }

        /// <summary>
        /// True to show/hide the field label when the field is hidden. Defaults to true. 
        /// </summary>
        [ConfigOption]
        [DefaultValue(true)]
        [Description("True to show/hide the field label when the field is hidden. Defaults to true.")]
        public virtual bool TrackLabels
        {
            get
            {
                object obj = this.ViewState["TrackLabels"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["TrackLabels"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Object)]
        [Browsable(false)]
        [DefaultValue(null)]
        [Description("")]
        protected internal FormLayoutConfig LayoutConfigProxy
        {
            get
            {
                if (this.LayoutConfig.Count > 0)
                {
                    return null;
                }

                return new FormLayoutConfig(this.TrackLabels, this.ElementStyle, this.LabelSeparator, this.LabelStyle, false, "");
            }
        }

        /// <summary>
        /// The layout type to be used in this container.
        /// </summary>
        [Meta]
        [Category("5. Container")]
        [DefaultValue("form")]
        [TypeConverter(typeof(LayoutConverter))]
        [Description("The layout type to be used in this container.")]
        public override string Layout
        {
            get
            {
                return (string)this.ViewState["Layout"] ?? "form";
            }
            set
            {
                this.ViewState["Layout"] = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void CallForm(string name, params object[] args)
        {
            this.CallTemplate("{0}.getForm().{1}({2});", name, args);
        }

        /// <summary>
        /// Starts monitoring of the valid state of this form. Usually this is done by passing the config option "monitorValid"
        /// </summary>
        public void StartMonitoring()
        {
            this.Call("startMonitoring");
        }

        /// <summary>
        /// Stops monitoring of the valid state of this form
        /// </summary>
        public void StopMonitoring()
        {
            this.Call("stopMonitoring");
        }


        /// <summary>
        /// Clears all invalid messages in this form.
        /// </summary>
        [Meta]
        [Description("Clears all invalid messages in this form.")]
        public virtual void ClearInvalid()
        {
            this.CallForm("clearInvalid");
        }

        /// <summary>
        /// Mark fields in this form invalid in bulk.
        /// </summary>
        /// <param name="errors">An object hash of {id: msg, id2: msg2}</param>
        [Meta]
        [Description("Mark fields in this form invalid in bulk.")]
        public virtual void MarkInvalid(object errors)
        {
            this.CallForm("markInvalid", errors);
        }

        /// <summary>
        /// Resets this form.
        /// </summary>
        [Meta]
        [Description("Resets this form.")]
        public virtual void Reset()
        {
            this.CallForm("reset");
        }

        /// <summary>
        /// Set values for fields in this form in bulk.
        /// </summary>
        [Meta]
        [Description("Set values for fields in this form in bulk.")]
        public virtual void SetValues(object values)
        {
            this.CallForm("setValues", values);
        }

        /// <summary>
        /// Calls Ext.apply for all fields in this form with the passed object.
        /// </summary>
        [Meta]
        [Description("Calls Ext.apply for all fields in this form with the passed object.")]
        public virtual void ApplyToFields(object values)
        {
            this.CallForm("applyToFields", values);
        }

        /// <summary>
        /// Calls Ext.applyIf for all fields in this form with the passed object.
        /// </summary>
        [Meta]
        [Description("Calls Ext.applyIf for all fields in this form with the passed object.")]
        public virtual void ApplyIfToFields(object values)
        {
            this.CallForm("applyIfToFields", values);
        }

        /// <summary>
        /// Calls required method for all fields in this form with the passed args.
        /// </summary>
        [Meta]
        [Description("Calls required method for all fields in this form with the passed args.")]
        protected virtual void CallFieldMethod(string fnName, object[] args)
        {
            this.CallForm("callFieldMethod", fnName, args);
        }
    }
}