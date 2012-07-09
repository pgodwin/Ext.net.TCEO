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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Xml;

using Ext.Net.Utilities;
using Newtonsoft.Json.Linq;

namespace Ext.Net
{
    /// <summary>
    /// A specialized grid implementation intended to mimic the traditional property grid as typically seen in development IDEs. Each row in the grid represents a property of some object, and the data is stored as a set of name/value pairs
    /// </summary>
    [Meta]
    [ToolboxData("<{0}:PropertyGrid runat=\"server\"></{0}:PropertyGrid>")]
    [ToolboxBitmap(typeof(GridPanel), "Build.ToolboxIcons.GridPanel.bmp")]
    [Designer(typeof(EmptyDesigner))]
    [Description("A specialized grid implementation intended to mimic the traditional property grid as typically seen in development IDEs. Each row in the grid represents a property of some object, and the data is stored as a set of name/value pairs")]
    public partial class PropertyGrid : GridPanelBase, IPostBackEventHandler
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public PropertyGrid() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("0. About")]
        [Description("")]
        public override string XType
        {
            get
            {
                return "netpropertygrid";
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
                return "Ext.net.PropertyGrid";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CheckStore()
        {
            // do not remove
        }
        
        private PropertyGridParameterCollection source;

        /// <summary>
        /// A data object to use as the data source of the grid.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.ArrayToObject)]
        [Category("8. PropertyGrid")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A data object to use as the data source of the grid.")]
        public virtual PropertyGridParameterCollection Source
        {
            get
            {
                if (this.source == null)
                {
                    this.source = new PropertyGridParameterCollection();
                }

                return this.source;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        [Description("")]
        public void SetSource(PropertyGridParameterCollection source)
        {
            this.Call("setSource", new JRawValue(source.ToJsonObject()));
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        [Description("")]
        protected internal string CustomEditors
        {
            get
            {
                int count = 0;
                StringBuilder sb = new StringBuilder();
                sb.Append("{");

                foreach (PropertyGridParameter parameter in this.Source)
                {
                    if (parameter.Editor.Count > 0)
                    {
                        if (parameter.Editor.Editor is ComboBox)
                        {
                            ComboBox cb = (ComboBox)parameter.Editor.Editor;

                            if (cb.StoreID.IsEmpty() && cb.Store.Primary == null)
                            {
                                cb.TriggerAction = TriggerAction.All;
                                cb.Mode = DataLoadMode.Local;
                            }
                        }

                        parameter.Editor.Editor.RegisterAllResources = true;
                        parameter.Editor.Editor.RegisterScripts();
                        parameter.Editor.Editor.RegisterStyles();
                        parameter.Editor.Editor.AutoRender = false;

                        parameter.Editor.Editor.Visible = true;
                        sb.Append(JSON.Serialize(parameter.Name).ConcatWith(":new Ext.grid.GridEditor(", parameter.Editor[0].ToConfig(LazyMode.Instance), "),"));
                        parameter.Editor.Editor.Visible = false;
                        count++;
                    }
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("}");

                return count > 0 ? sb.ToString() : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        [Description("")]
        protected internal string CustomRenderers
        {
            get
            {
                int count = 0;
                StringBuilder sb = new StringBuilder();
                sb.Append("{");

                foreach (PropertyGridParameter parameter in this.Source)
                {
                    if (!parameter.Renderer.IsDefault)
                    {
                        sb.Append(JSON.Serialize(parameter.Name).ConcatWith(":", parameter.Renderer.ToConfigString(), ","));
                        count++;
                    }
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("}");

                return count > 0 ? sb.ToString() : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(null)]
        [Description("")]
        protected internal string PropertyNames 
        {
            get
            {
                int count = 0;
                StringBuilder sb = new StringBuilder();
                sb.Append("{");

                foreach (PropertyGridParameter parameter in this.Source)
                {
                    if (parameter.DisplayName.IsNotEmpty() && parameter.Name.IsNotEmpty())
                    {
                        sb.Append(JSON.Serialize(parameter.Name).ConcatWith(":", JSON.Serialize(parameter.DisplayName), ","));
                        count++;
                    }
                }

                sb.Remove(sb.Length - 1, 1);
                sb.Append("}");

                return count > 0 ? sb.ToString() : null;
            }
        }

        /// <summary>
        /// If false then all cells will be read only
        /// </summary>
        /// <value><c>true</c> if editable; otherwise, <c>false</c>.</value>
        [Meta]
        [ConfigOption]
        [Category("8. PropertyGrid")]
        [NotifyParentProperty(true)]
        [DefaultValue(true)]
        [Description("If false then all cells will be read only")]
        public virtual bool Editable
        {
            get
            {
                object obj = this.ViewState["Editable"];
                return obj != null ? (bool) obj : true;
            }
            set
            {
                this.ViewState["Editable"] = value;
            }
        }

        private BaseDirectEvent directEventConfig;

        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [ConfigOption(JsonMode.Object)]
        [Description("")]
        public BaseDirectEvent DirectEventConfig
        {
            get
            {
                if (this.directEventConfig == null)
                {
                    this.directEventConfig = new BaseDirectEvent();
                }

                return this.directEventConfig;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
        {
            CreateEditors();
            base.OnPreRender(e);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.CreateEditors();
        }

        private void CreateEditors()
        {
            foreach (PropertyGridParameter parameter in this.Source)
            {
                if (parameter.Editor.Count == 0)
                {
                    continue;
                }

                Field editor = parameter.Editor.Editor;
                editor.Visible = false;
                editor.EnableViewState = false;

                if (!this.Controls.Contains(editor))
                {
                    this.Controls.Add(editor);
                }

                if (!this.LazyItems.Contains(editor))
                {
                    this.LazyItems.Add(editor);
                }
            }
        }

        private static readonly object EventDataChanged = new object();

        /// <summary>
        /// Fires when the the PropertyGrid has changed records
        /// </summary>
        [Category("Action")]
        [Description("Fires when the the PropertyGrid has changed records")]
        public event EventHandler DataChanged
        {
            add
            {
                this.Events.AddHandler(EventDataChanged, value);
            }
            remove
            {
                this.Events.RemoveHandler(EventDataChanged, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnDataChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventDataChanged];

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private bool baseLoadPostData;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        [Description("")]
        protected override bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            baseLoadPostData = base.LoadPostData(postDataKey, postCollection);
            string val = postCollection[this.ConfigID.ConcatWith("_Data")];

            if (val.IsNotEmpty())
            {
                this.BuildSource(val);
                return true;
            }

            return false || baseLoadPostData;
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected override void RaisePostDataChangedEvent()
        {
            if (this.baseLoadPostData)
            {
                base.RaisePostDataChangedEvent();
                this.baseLoadPostData = false;
            }
            
            if (raiseChanged)
            {
                this.OnDataChanged(EventArgs.Empty);
                raiseChanged = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgument"></param>
        [Description("")]
        public void RaisePostBackEvent(string eventArgument)
        {
            if (RequestManager.IsAjaxRequest)
            {
                this.RaiseCallBackEvent(eventArgument);
            }
        }

        private string ChopQuotes(string value)
        {
            if (value.IsNotEmpty() && value.StartsWith("\"") && value.EndsWith("\""))
            {
                return value.Chop();
            }

            return value;
        }

        private PropertyGridParameter FindParam(string name)
        {
            foreach (PropertyGridParameter parameter in this.Source)
            {
                if (parameter.Name == name)
                {
                    return parameter;
                }
            }

            return new PropertyGridParameter();
        }

        private bool dataChangedEventHandled = false;
        bool raiseChanged = false;
        
        void BuildSource(string strSource)
        {
            if (this.dataChangedEventHandled)
            {
                return;
            }
            
            PropertyGridParameterCollection result = new PropertyGridParameterCollection();
            JObject jo = JObject.Parse(strSource);

            foreach (JProperty property in jo.Properties())
            {
                string value = property.Value.Type == JTokenType.String ? (string)property.Value : this.ChopQuotes(property.Value.ToString());
                PropertyGridParameter newP = new PropertyGridParameter(this.ChopQuotes(property.Name), value);
                PropertyGridParameter oldP = this.FindParam(property.Name);
                newP.Mode = oldP.Mode;
                
                if (oldP.Editor.Count > 0)
                {
                    newP.Editor.Add(oldP.Editor.Editor);    
                }

                newP.IsChanged = newP.Name.IsEmpty() || oldP.Value != newP.Value;

                if (newP.IsChanged)
                {
                    raiseChanged = true;
                }
                result.Add(newP);
            }

            this.Source.Clear();

            foreach (PropertyGridParameter parameter in result)
            {
                this.Source.Add(parameter);
            }

            this.dataChangedEventHandled = true;
        }

        private void RaiseCallBackEvent(string eventArgument)
        {
            Response response = new Response(true, null);

            try
            {
                if (eventArgument.IsEmpty())
                {
                    throw new ArgumentNullException("eventArgument");
                }

                XmlNode xmlData = this.SubmitConfig;

                if (xmlData == null)
                {
                    return; 
                }

                XmlNode parametersNode = xmlData.SelectSingleNode("config/extraParams");

                string data = null;
                XmlNode serviceNode = xmlData.SelectSingleNode("config/serviceParams");

                if (serviceNode != null)
                {
                    data = serviceNode.InnerText;
                }

                string action = eventArgument;

                switch (action)
                {
                    case "update":
                        if (data == null)
                        {
                            throw new InvalidOperationException("No data in request");
                        }

                        this.BuildSource(data);

                        if (raiseChanged)
                        {
                            this.OnDataChanged(EventArgs.Empty);
                            raiseChanged = false;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = this.IsDebugging ? ex.ToString() : ex.Message;
            }

            ResourceManager.ServiceResponse = response;
        }

        private PropertyGridListeners listeners;

        /// <summary>
        /// Client-side JavaScript Event Handlers
        /// </summary>
        [Meta]
        [ConfigOption("listeners", JsonMode.Object)]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Client-side JavaScript Event Handlers")]
        public PropertyGridListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new PropertyGridListeners();
                }

                return this.listeners;
            }
        }

        private PropertyGridDirectEvents directEvents;

        /// <summary>
        /// Server-side Ajax Event Handlers
        /// </summary>
        [Meta]
        [Category("2. Observable")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [ConfigOption("directEvents", JsonMode.Object)]
        [Description("Server-side Ajax Event Handlers")]
        public PropertyGridDirectEvents DirectEvents
        {
            get
            {
                if (this.directEvents == null)
                {
                    this.directEvents = new PropertyGridDirectEvents();
                }

                return this.directEvents;
            }
        }

        /// <summary>
        /// Adds the property.
        /// </summary>
        /// <param name="property"></param>
        [Description("Adds the property.")]
        public void AddProperty(PropertyGridParameter property)
        {
            if (property.DisplayName.IsNotEmpty())
            {
                this.Set("propertyNames[{0}]".FormatWith(JSON.Serialize(property.Name)), property.DisplayName);
            }

            if (!property.Renderer.IsDefault)
            {
                this.Set("customRenderers[{0}]".FormatWith(JSON.Serialize(property.Name)), new JRawValue(property.Renderer.ToConfigString()));
            }

            if (property.Editor.Count > 0)
            {
                property.Editor[0].AutoRender = false;
                property.Editor[0].Visible = true;
                this.Set("customEditors[{0}]".FormatWith(JSON.Serialize(property.Name)), new JRawValue("new Ext.grid.GridEditor({0})".FormatWith(property.Editor[0].ToConfig(LazyMode.Instance))));
                property.Editor[0].Visible = false;
            }

            this.Call("setProperty", property.Name, property.Mode == ParameterMode.Raw ? (object)new JRawValue(property.Value) : (object)property.Value, true);
        }

        /// <summary>
        /// Updates the property.
        /// </summary>
        /// <param name="propertyName">The name of the property</param>
        /// <param name="value">New value of the property</param>
        [Description("Updates the property.")]
        public void UpdateProperty(string propertyName, object value)
        {
            this.Call("setProperty", propertyName, value);
        }

        /// <summary>
        /// Removes a property from the grid.
        /// </summary>
        /// <param name="propertyName">The name of the property to remove</param>
        [Description("Removes a property from the grid.")]
        public void RemoveProperty(string propertyName)
        {
            this.Call("removeProperty", propertyName);
        }
    }
}
