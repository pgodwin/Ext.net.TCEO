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

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// File upload field
    /// </summary>
    [Meta]
    [ControlValueProperty("FileBytes")]
    [ValidationProperty("FileName")]
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal, Unrestricted = false)]
    [AspNetHostingPermissionAttribute(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal, Unrestricted = false)]
    [ToolboxData("<{0}:FileUploadField runat=\"server\" />")]
    [DefaultEvent("FileSelected")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [SupportsEventValidation]
    [Designer(typeof(EmptyDesigner))]
    [ToolboxBitmap(typeof(FileUploadField), "Build.ToolboxIcons.FileUploadField.bmp")]
    [Description("File upload field")]
    public partial class FileUploadField : TextFieldBase, IIcon
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public FileUploadField() { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 1;

                baseList.Add(new ClientStyleItem(typeof(FileUploadField), "Ext.Net.Build.Ext.Net.ux.extensions.fileuploadfield.css.file-upload.css", "/ux/extensions/fileuploadfield/css/file-upload.css"));

                return baseList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "fileuploadfield";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string InstanceOf
        {
            get
            {
                return "Ext.form.FileUploadField";
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        [Description("")]
        protected override void OnBeforeClientInit(Observable sender)
        {
            if (this.AutoPostBack)
            {
                //this.On("fileselected", new JFunction(this.PostBackFunction));
                this.CustomConfig.Add(new ConfigItem("postback", JSON.Serialize(new { eventName = "fileselected", fn = new JFunction(this.PostBackFunction) }), ParameterMode.Raw));
            }
        }

        /// <summary>
        /// The Text value to initialize this field with.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetText")]
        [Category("7. FileUploadField")]
        [DefaultValue(null)]
        [Localizable(true)]
        [Bindable(true, BindingDirection.TwoWay)]
        [Description("The Text value to initialize this field with.")]
        public override string Text
        {
            get
            {
                return (string)this.ViewState["Text"] ?? null;
            }
            set
            {
                this.ViewState["Text"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public override object Value
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = (string)value;
            }
        }

        /// <summary>
        /// The button text to display on the upload button (defaults to 'Browse...'). Note that if you supply a value for ButtonCfg, the ButtonCfg.Text value will be used instead if available.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetButtonText")]
        [ConfigOption]
        [DefaultValue("Browse...")]
        [Category("7. FileUploadField")]
        [Localizable(true)]
        [Description("The button text to display on the upload button (defaults to 'Browse...'). Note that if you supply a value for ButtonCfg, the ButtonCfg.Text value will be used instead if available.")]
        public virtual string ButtonText
        {
            get
            {
                return (string)this.ViewState["ButtonText"] ?? "Browse...";
            }
            set
            {
                this.ViewState["ButtonText"] = value;
            }
        }

        /// <summary>
        /// True to display the file upload field as a button with no visible text field (defaults to false).
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. FileUploadField")]
        [DefaultValue(false)]
        [Description("True to display the file upload field as a button with no visible text field (defaults to false).")]
        public virtual bool ButtonOnly
        {
            get
            {
                object obj = this.ViewState["ButtonOnly"];
                return (obj == null) ? false : (bool)obj;
            }
            set
            {
                this.ViewState["ButtonOnly"] = value;
            }
        }

        /// <summary>
        /// The number of pixels of space reserved between the button and the text field (defaults to 3).  Note that this only applies if ButtonOnly=false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [Category("7. FileUploadField")]
        [DefaultValue(3)]
        [Description("The number of pixels of space reserved between the button and the text field (defaults to 3).  Note that this only applies if ButtonOnly=false.")]
        public virtual int ButtonOffset
        {
            get
            {
                object obj = this.ViewState["ButtonOffset"];
                return (obj == null) ? 3 : (int)obj;
            }
            set
            {
                this.ViewState["ButtonOffset"] = value;
            }
        }

        /// <summary>
        /// True to mark the field as readOnly in HTML (defaults to false) -- Note: this only sets the element's readOnly DOM attribute.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetReadOnly")]
        [ConfigOption]
        [Category("7. FileUploadField")]
        [Bindable(true)]
        [DefaultValue(true)]
        [Description("True to mark the field as readOnly in HTML (defaults to false) -- Note: this only sets the element's readOnly DOM attribute.")]
        public override bool ReadOnly
        {
            get
            {
                object obj = this.ViewState["ReadOnly"];
                return (obj == null) ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ReadOnly"] = value;
            }
        }

        /// <summary>
        /// The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.
        /// </summary>
        [Meta]
        [Category("7. FileUploadField")]
        [DefaultValue(Icon.None)]
        [DirectEventUpdate(MethodName = "SetIconClass")]
        [Description("The icon to use in the Button. See also, IconCls to set an icon with a custom Css class.")]
        public override Icon Icon
        {
            get
            {
                object obj = this.ViewState["Icon"];
                return (obj == null) ? Icon.None : (Icon)obj;
            }
            set
            {
                this.ViewState["Icon"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("iconCls")]
        [DefaultValue("")]
        [Description("")]
        protected override string IconClsProxy
        {
            get
            {
                if (this.Icon != Icon.None)
                {
                    return ResourceManager.GetIconClassName(this.Icon);
                }

                return this.IconCls;
            }
        }

        /// <summary>
        /// A css class which sets a background image to be used as the icon for this button.
        /// </summary>
        [Meta]
        [DirectEventUpdate(MethodName = "SetIconClass")]
        [Category("7. FileUploadField")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("A css class which sets a background image to be used as the icon for this button.")]
        public override string IconCls
        {
            get
            {
                return (string)this.ViewState["IconCls"] ?? "";
            }
            set
            {
                this.ViewState["IconCls"] = value;
            }
        }

        byte[] cachedBytes;

        /// <summary>
        /// 
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Bindable(true, BindingDirection.OneWay)]
        [Browsable(false)]
        [Description("")]
        public byte[] FileBytes
        {
            get
            {
                if (this.cachedBytes == null)
                {
                    this.cachedBytes = new byte[this.FileContent.Length];
                    this.FileContent.Read(this.cachedBytes, 0, this.cachedBytes.Length);
                }

                return (byte[])(this.cachedBytes.Clone());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public Stream FileContent
        {
            get
            {
                if (this.PostedFile == null)
                {
                    return Stream.Null;
                }
                
                return this.PostedFile.InputStream;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public string FileName
        {
            get
            {
                if (this.PostedFile == null)
                {
                    return "";
                }
                 
                return this.PostedFile.FileName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public bool HasFile
        {
            get
            {
                return this.FileName.IsNotEmpty();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("")]
        public HttpPostedFile PostedFile
        {
            get
            {
                if (this.Page == null || !this.Page.IsPostBack)
                {
                    return null;
                }
                    
                if (this.Context == null || this.Context.Request == null)
                {
                    return null;
                }

                return this.Context.Request.Files[this.ClientID + "-file"];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(System.EventArgs e)
        {
            if (this.IsInForm)
            {
                this.Page.Form.Enctype = "multipart/form-data";
            }

            base.OnPreRender(e);
        }

        private FileUploadFieldListeners listeners;

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
        public FileUploadFieldListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new FileUploadFieldListeners();
                }

                return this.listeners;
            }
        }

        private FileUploadFieldDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ViewStateMember]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side Ajax Event Handlers")]
        public FileUploadFieldDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new FileUploadFieldDirectEvents();
                }

                return this.directEvents;
            }
        }


        /*  Lifecycle
            -----------------------------------------------------------------------------------------------*/

        List<Icon> IIcon.Icons
        {
            get
            {
                List<Icon> icons = new List<Icon>(1);
                icons.Add(this.Icon);
                return icons;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="args"></param>
        [Description("")]
        protected virtual void CallButton(string name, params object[] args)
        {
            this.CallTemplate("{0}.button.{1}({2});", name, args);
        }


        /*  Public Methods
            -----------------------------------------------------------------------------------------------*/
        
        /// <summary>
        /// Sets this button's text
        /// </summary>
        [Description("Sets this button's text")]
        protected virtual void SetButtonText(string text)
        {
            this.CallButton("setText", text);
        }

        /// <summary>
        /// Sets this text
        /// </summary>
        [Description("Sets this text")]
        protected virtual void SetText(string text)
        {
            this.Call("setValue", text);
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        [Description("Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.")]
        protected override void SetIconClass(string cls)
        {
            this.CallButton("setIconClass", cls);
        }

        /// <summary>
        /// Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.
        /// </summary>
        [Description("Sets the CSS class that provides a background image to use as the button's icon. This method also changes the value of the iconCls config internally.")]
        protected override void SetIconClass(Icon icon)
        {
            if (this.Icon != Icon.None)
            {
                this.SetIconClass(ResourceManager.GetIconClassName(icon));
            }
            else
            {
                this.SetIconClass("");
            }
        }
    }
}
