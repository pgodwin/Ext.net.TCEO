using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Web.Mvc;
using System.Xml.Serialization;
using Ext.Net.Utilities;
using Newtonsoft.Json;

namespace Ext.Net.MVC
{
    public class AjaxFormResult : ActionResult, IXObject
    {
        public AjaxFormResult() { }

        [ConfigOption]
        public string Script { get; set; }
        public bool IsUpload { get; set; }

        private bool success = true;

        [ConfigOption]
        [DefaultValue("")]
        public bool Success
        {
            get { return this.success; }
            set { this.success = value; }
        }

        private List<FieldError> errors;

        [ConfigOption(JsonMode.AlwaysArray)]
        public List<FieldError> Errors
        {
            get
            {
                if(this.errors == null)
                {
                    this.errors = new List<FieldError>();
                }

                return this.errors;
            }
        }

        private ParameterCollection extraParams;
        public ParameterCollection ExtraParams
        {
            get
            {
                if (this.extraParams == null)
                {
                    this.extraParams = new ParameterCollection();
                }

                return this.extraParams;
            }
        }

        [ConfigOption("extraParams", JsonMode.Raw)]
        [DefaultValue("")]
        protected string ExtraParamsProxy
        {
            get
            {
                if (this.ExtraParams.Count > 0)
                {
                   return ExtraParams.ToJson();
                }

                return "";
            }
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (this.IsUpload)
            {
                context.HttpContext.Response.Write("<textarea>{0}</textarea>".FormatWith(new ClientConfig().Serialize(this)));
            }
            else
            {
                CompressionUtils.GZipAndSend(new ClientConfig().Serialize(this));
            }
        }

        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsCollection ConfigOptions
        {
            get
            {
                
                var list = new ConfigOptionsCollection();
                list.Add("script", new ConfigOption("script", new SerializationOptions("script"), null, this.Script));
                list.Add("success", new ConfigOption("success", new SerializationOptions("success"), "", this.Success));
                list.Add("errors", new ConfigOption("errors", new SerializationOptions("errors", JsonMode.AlwaysArray), "", this.Errors));
                list.Add("extraParamsProxy", new ConfigOption("extraParamsProxy", new SerializationOptions("extraParams", JsonMode.Raw), "", this.ExtraParamsProxy));

                return list;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get
            {
                return ConfigOptionsExtraction.List;
            }
        }
    }

    public class FieldError: IXObject
    {
        public FieldError(string fieldID, string errorMessage)
        {
            if(string.IsNullOrEmpty(fieldID))
            {
                throw new ArgumentNullException("fieldID", "Field ID can not be empty");
            }

            if (string.IsNullOrEmpty(errorMessage))
            {
                throw new ArgumentNullException("errorMessage", "Error message can not be empty");
            }

            this.FieldID = fieldID;
            this.ErrorMessage = errorMessage;
        }

        [ConfigOption("id")]
        [DefaultValue("")]
        public string FieldID { get; set; }

        [ConfigOption("msg")]
        [DefaultValue("")]
        public string ErrorMessage { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsCollection ConfigOptions
        {
            get
            {

                var list = new ConfigOptionsCollection();
                list.Add("fieldID", new ConfigOption("fieldID", new SerializationOptions("id"), null, this.FieldID));
                list.Add("errorMessage", new ConfigOption("errorMessage", new SerializationOptions("msg"), null, this.ErrorMessage));

                return list;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlIgnore]
        [JsonIgnore]
        public virtual ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get
            {
                return ConfigOptionsExtraction.List;
            }
        }
    }

    public class FieldErrors : Collection<FieldError> { }
}
