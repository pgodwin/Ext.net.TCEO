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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public abstract partial class StoreDataBound : StoreBase
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public event EventHandler DataBound;
		
		object dataSource;
		bool initialized;
		bool preRendered;
		bool requiresDataBinding;
        DataSourceSelectArguments selectArguments;
        DataSourceView currentView;
        
        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Bindable(true)]
		[Themeable(true)]
		[DefaultValue(null)]
		[DesignerSerializationVisibilityAttribute (DesignerSerializationVisibility.Hidden)]
        [Description("")]
   		public virtual object DataSource 
        {
			get 
            {
				return this.dataSource;
			}
			set 
            {
				ValidateDataSource (value);
				this.dataSource = value;
                this.IsDataBound = false;

                if (this.initialized)
                {
                    this.OnDataPropertyChanged();
                }
			}
		}

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [DefaultValue("")]
		[ThemeableAttribute (false)]
        [IDReferencePropertyAttribute(typeof(DataSourceControl))]
        [Description("")]
		public virtual string DataSourceID 
        {
			get 
            {
                return (string)this.ViewState["DataSourceID"] ?? "";
			}
			set 
            {
				this.ViewState["DataSourceID"] = value;
                this.IsDataBound = false;

                if (initialized)
                {
                    this.OnDataPropertyChanged();
                }
			}
		}

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [ThemeableAttribute(false)]
        [DefaultValue("")]
        [Description("")]
        public virtual string DataMember
        {
            get
            {
                return (string)this.ViewState["DataMember"] ?? "";
            }
            set 
            { 
                ViewState["DataMember"] = value; 
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected bool Initialized
        {
			get 
            { 
                return initialized; 
            }
		}

		/// <summary>
		/// 
		/// </summary>
        [Description("")]
        protected bool IsBoundUsingDataSourceID
        {
            get
            {
                return DataSourceID.Length > 0;
            }
		}

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual bool RequiresDataBinding {
			get 
            { 
                return this.requiresDataBinding; 
            }
			set 
            { 
				this.requiresDataBinding = value;

                if (value && this.preRendered && this.IsBoundUsingDataSourceID && this.Page != null && !this.Page.IsCallback && !RequestManager.IsAjaxRequest)
                {
                    this.EnsureDataBound();
                }
			}
		}
		
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected void ConfirmInitState()
		{
			this.initialized = true;
		}

        private bool ajaxDataBindingRequired = true;

        protected virtual void AjaxDataBind()
        {
            if (RequestManager.IsAjaxRequest && this.IsAjaxRequestInitiator)
            {
                return;
            }

            if (!this.ajaxDataBindingRequired || this.IsParentDeferredRender)
            {
                return;
            }

            this.RequiresDataBinding = false;
            this.PerformSelect();

            this.GenerateAjaxResponseScript();
        }

        protected virtual string GetAjaxDataJson()
        {
            return this.Data != null ? JSON.Serialize(this.Data) : this.JsonData;
        }

        protected virtual void GenerateAjaxResponseScript()
        {
            StoreResponseData dataResponse = new StoreResponseData();
            dataResponse.Data = this.GetAjaxDataJson();
            PageProxy dsp = this.Proxy.Proxy as PageProxy;

            if (dsp == null && this.Proxy.Proxy != null)
            {
                return;
            }

            dataResponse.Total = dsp != null ? dsp.Total : 0;

            Response response = new Response(true);
            response.Data = dataResponse.ToString();

            this.AddScript(this.ClientID.ConcatWith(".callbackRefreshHandler(response, {serviceResponse: ", new ClientConfig().Serialize(response), "}, ", this.ClientID, ", o.eventType, o.action, o.extraParams);"));
            this.ajaxDataBindingRequired = false;
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]
        [Description("")]
        public override void DataBind()
		{
            base.DataBind(true);

            if (this.IsDataBound)
            {
                return;
            }

            if (RequestManager.IsAjaxRequest && !this.IsAjaxRequestInitiator && !this.IsDynamic)
			{
			    this.AjaxDataBind();
			}

            if (((!RequestManager.IsAjaxRequest || this.IsDynamic) && this.Proxy.Count == 0) || (RequestManager.IsAjaxRequest && this.IsAjaxRequestInitiator))
            {
                this.RequiresDataBinding = false;
                this.PerformSelect();
            }
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override string ToScript()
        {
            return this.ToScript(this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override string ToScript(bool selfRendering)
        {
            if (this.Proxy.Count == 0)
            {
                this.RequiresDataBinding = false;
                this.PerformSelect();
            }

            return base.ToScript(selfRendering);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override void Render()
        {
            this.Render(this.Page == null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public override void Render(bool selfRendering)
        {
            if (this.Proxy.Count == 0)
            {
                this.RequiresDataBinding = false;
                this.PerformSelect();
            }

            base.Render(selfRendering);
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void EnsureDataBound()
		{
            if (this.RequiresDataBinding && this.IsBoundUsingDataSourceID && this.Proxy.Count == 0)
            {
                this.DataBind();
            }
            else
            {
                base.DataBind(true);
            }
		}
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnDataBound(EventArgs e)
		{
            if (this.DataBound != null)
            {
                this.DataBound(this, e);
            }
		}

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        protected virtual void OnDataPropertyChanged()
		{
			this.RequiresDataBinding = true;
            this.UpdateViewData();
		}
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnInit(EventArgs e)
		{
			base.OnInit (e);
			this.Page.PreLoad += OnPagePreLoad;

            if (!IsViewStateEnabled && Page != null && Page.IsPostBack)
            {
                this.RequiresDataBinding = true;
            }
		}
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Description("")]
        protected virtual void OnPagePreLoad(object sender, EventArgs e)
		{
			this.ConfirmInitState ();
            this.UpdateViewData();
		}
		
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        [Description("")]
        protected override void OnPreRender(EventArgs e)
		{
			this.preRendered = true;

			if (!RequestManager.IsAjaxRequest)
			{
                this.EnsureDataBound(); 
			}
			
            base.OnPreRender (e);
		}

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static IEnumerable ResolveDataSource(object o, string data_member)
        {
            IEnumerable ds;

            ds = o as IEnumerable;

            if (ds != null)
            {
                return ds;
            }

            IListSource ls = o as IListSource;

            if (ls == null)
            {
                return null;
            }

            IList member_list = ls.GetList();

            if (!ls.ContainsListCollection)
            {
                return member_list;
            }

            ITypedList tl = member_list as ITypedList;

            if (tl == null)
            {
                return null;
            }

            PropertyDescriptorCollection pd = tl.GetItemProperties(new PropertyDescriptor[0]);

            if (pd == null || pd.Count == 0)
            {
                throw new HttpException("The selected data source did not contain any data members to bind to");
            }

            PropertyDescriptor member_desc = data_member == "" ?
                pd[0] :
                pd.Find(data_member, true);

            if (member_desc != null)
            {
                ds = member_desc.GetValue(member_list[0]) as IEnumerable;
            }

            if (ds == null)
            {
                throw new HttpException("A list corresponding to the selected DataMember was not found");
            }

            return ds;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        [Description("")]
        protected virtual IDataSource GetDataSource()
        {
            if (this.IsBoundUsingDataSourceID)
            {
                Control ctrl = Utilities.ControlUtils.FindControl(this, this.DataSourceID);

                if (ctrl == null)
                {
                    throw new HttpException("A IDatasource Control with the ID '{0}' could not be found.".FormatWith(this.DataSourceID));
                }

                if (!(ctrl is IDataSource))
                {
                    throw new HttpException("The control with ID '{0}' is not a control of type IDataSource.".FormatWith(this.DataSourceID));
                }

                return (IDataSource)ctrl;
            }

            if (this.DataSource == null)
            {
                return null;
            }

            IDataSource ds = this.DataSource as IDataSource;
            
            if (ds != null)
            {
                return ds;
            }

            IEnumerable ie = ResolveDataSource(DataSource, DataMember);

            if (ie != null)
            {
                return new CollectionDataSource(ie);
            }

            throw new HttpException("Unexpected data source type: {0}".FormatWith(DataSource.GetType()));
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual DataSourceView GetData()
        {
            if (this.currentView == null)
            {
                this.UpdateViewData();
            }

            return currentView;
        }

        DataSourceView InternalGetData()
        {
            if (this.DataSource != null && this.IsBoundUsingDataSourceID)
            {
                throw new HttpException("Control bound using both DataSourceID and DataSource properties.");
            }

            IDataSource ds = this.GetDataSource();

            if (ds != null)
            {
                return ds.GetView(DataMember);
            }
            
            return null;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual void OnDataSourceViewChanged(object sender, EventArgs e)
        {
            this.RequiresDataBinding = true;
        }

        void UpdateViewData()
        {
            DataSourceView view = this.InternalGetData();

            if (view == currentView)
            {
                return;
            }

            if (currentView != null)
            {
                currentView.DataSourceViewChanged -= OnDataSourceViewChanged;
            }

            currentView = view;

            if (view != null)
            {
                view.DataSourceViewChanged += OnDataSourceViewChanged;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override void OnLoad(EventArgs e)
        {
            if (!this.Page.IsPostBack || (this.IsViewStateEnabled && !this.IsDataBound))
            {
                this.RequiresDataBinding = true;
            }

            base.OnLoad(e);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected internal virtual void PerformDataBinding(IEnumerable data)
        {
            if (data == null)
            {
                this.JsonData = "[]";
                return;
            }

            this.firstRecord = null;
            IEnumerator en = data.GetEnumerator();
            AutoGeneratedFieldProperties[] autoFieldProperties = this.CreateAutoFieldProperties(data, en);

            if (autoFieldProperties != null)
            {
                StringBuilder sb = new StringBuilder(256);
                sb.Append("[");

                if (this.firstRecord != null)
                {
                    this.BindRecord(autoFieldProperties, sb, this.firstRecord);
                }

                while (en.MoveNext())
                {
                    object obj = en.Current;
                    this.BindRecord(autoFieldProperties, sb, obj);
                }

                RemoveLastComma(sb);
                sb.Append("]");

                this.JsonData = sb.ToString();
            }
        }

        private void BindRecord(AutoGeneratedFieldProperties[] autoFieldProperties, StringBuilder sb, object obj)
        {
            sb.Append("{");
            System.Data.DataRow dataRow = obj as System.Data.DataRow;

            foreach (AutoGeneratedFieldProperties property in autoFieldProperties)
            {
                FieldInReader field = this.IsInReader(property.DataField);

                if (this.IgnoreExtraFields && !field.InReader)
                {
                    continue;
                }
                
                if (field.Fields != null && field.Fields.Count > 0)
                {
                    foreach (RecordField recordField in field.Fields)
                    {
                        object value = this.GetFieldValue(property, obj, recordField, dataRow);
                        if (value != null && value.GetType().IsEnum && recordField.Type == RecordFieldType.Int)
                        {
                            value = (int)value;
                        }
                        sb.AppendFormat("{0}:{1},", JSON.Serialize(string.IsNullOrEmpty(recordField.Mapping) ? recordField.Name : recordField.Mapping), JSON.Serialize(value));
                    }
                }
                else
                {                    
                    if (dataRow == null || !dataRow.IsNull(property.DataField))
                    {
                        sb.AppendFormat("{0}:{1},", JSON.Serialize(property.DataField), JSON.Serialize(DataBinder.GetPropertyValue(obj, property.DataField)));
                    }
                }
            }
            
            RemoveLastComma(sb);
            sb.Append("},");
        }

        private object GetFieldValue(AutoGeneratedFieldProperties property, object obj, RecordField field, System.Data.DataRow dataRow)
        {
            if (field != null && field.ServerMapping.IsNotEmpty())
            {
                string[] mapping = field.ServerMapping.Split('.');

                if (mapping.Length > 1)
                {
                    for (int i = 0; i < mapping.Length; i++)
                    {
                        if (dataRow != null && dataRow.IsNull(mapping[i]))
                        {
                            return null;
                        }
                        
                        PropertyInfo p = obj.GetType().GetProperty(mapping[i]);
                        try
                        {
                            obj = p.GetValue(obj, null);
                        }
                        catch (NullReferenceException e)
                        {
                            throw new NullReferenceException(String.Format("Mapped property '{0}' doesn't exist", mapping[i]));
                        }
                        
                        if (obj == null)
                        {
                            return null;
                        }
                    }

                    return obj;
                }
            }

            return (dataRow != null && dataRow.IsNull(property.DataField)) ? null : DataBinder.GetPropertyValue(obj, property.DataField);
        }

        private FieldInReader IsInReader(string name)
        {
            if (this.Reader.Reader == null)
            {
                return new FieldInReader(false, null);
            }

			bool found = false;

            if (this.Reader.Reader.IDField == name)
            {
                found = true;
            }
            List< RecordField> fields = new List<RecordField>();

            foreach (RecordField field in this.Reader.Reader.Fields)
            {
                if ((field.ServerMapping.IsNotEmpty() && field.ServerMapping.Split('.')[0] == name) ||
                    ((field.Mapping.IsEmpty() ? field.Name : field.Mapping) == name))
                {
                    fields.Add(field);
                }			
            }
			
			if (fields.Count >0)
            {
                return new FieldInReader(true, fields);
            }

            if (found)
            {
                return new FieldInReader(true, null);
            }

            return new FieldInReader(false, null);
        }

        private bool IsComplexField(string name)
        {
            if (this.Reader.Reader == null)
            {
                return false;
            }

            foreach (RecordField field in this.Reader.Reader.Fields)
            {
                if ((field.ServerMapping.IsNotEmpty() && field.ServerMapping.Split('.')[0] == name))
                {
                    return true;
                }

                if (name == (field.Mapping.IsEmpty() ? field.Name : field.Mapping))
                {
                    return field.IsComplex;
                }
            }

            return false;
        }

        private static void RemoveLastComma(StringBuilder sb)
        {
            if (sb[sb.Length-1] == ',')
            {
                sb.Remove(sb.Length - 1, 1);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected static void ValidateDataSource(object dataSource)
        {
            if (dataSource is IListSource || dataSource is IEnumerable || dataSource is IDataSource)
            {
                return;
            }

            throw new ArgumentException("Invalid data source source type. The data source must be of type IListSource, IEnumerable or IDataSource.");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected void PerformSelect()
        {
            if (!this.IsBoundUsingDataSourceID)
            {
                this.OnDataBinding(EventArgs.Empty);
            }

            DataSourceView view = GetData();

            if (view != null)
            {
                view.Select(this.SelectArguments, this.OnSelect);
                this.MarkAsDataBound();
            }
        }

        void OnSelect(IEnumerable data)
        {
            this.PerformDataBinding(data);
            this.OnDataBound(EventArgs.Empty);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected virtual DataSourceSelectArguments CreateDataSourceSelectArguments()
        {
            return DataSourceSelectArguments.Empty;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected DataSourceSelectArguments SelectArguments
        {
            get
            {
                if (this.selectArguments == null)
                {
                    this.selectArguments = this.CreateDataSourceSelectArguments();
                }

                return this.selectArguments;
            }
        }

        private bool isDataBound;
        private object firstRecord;

        private bool IsDataBound
        {
            get
            {
                return this.isDataBound;
            }
            set
            {
                this.isDataBound = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected void MarkAsDataBound()
        {
            this.IsDataBound = true; 
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public void SetDataFromJson(string json)
        {
            this.RequiresDataBinding = false;
            this.JsonData = json;
            this.Data = null;

            if (RequestManager.IsAjaxRequest && !this.IsDynamic)
            {
                this.GenerateAjaxResponseScript();
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual bool IsBindableType(Type type)
        {
            if (type.IsGenericType
            && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                type = Nullable.GetUnderlyingType(type);
            }

            return type.IsPrimitive
                || type.IsEnum
                || type == typeof(string)
                || type == typeof(DateTime)
                || type == typeof(Guid)
                || type == typeof(TimeSpan)
                || type == typeof(Decimal);
        }
        
        AutoGeneratedFieldProperties[] CreateAutoFieldProperties(IEnumerable source, IEnumerator en)
        {
            Data = null;
            JsonData = "";

            if (this.SerializationMode == SerializationMode.Complex)
            {
                Data = source;
                return null;
            }
            
            if (source == null) return null;

            if (source is string && source.ToString().StartsWith("http"))
            {
                this.JsonData = "'{0}'".FormatWith(source);
                this.IsUrl = true;
                return null;
            }

            ITypedList typed = source as ITypedList;
            PropertyDescriptorCollection props = typed == null ? null : typed.GetItemProperties(new PropertyDescriptor[0]);

            Type prop_type;

            ArrayList retVal = new ArrayList();


            if (props == null)
            {
                object fitem = null;
                prop_type = null;
                PropertyInfo prop_item = source.GetType().GetProperty("Item",
                                                  BindingFlags.Instance | BindingFlags.Static |
                                                  BindingFlags.Public, null, null,
                                                  new Type[] { typeof(int) }, null);

                if (prop_item != null)
                {
                    prop_type = prop_item.PropertyType;

                    if (prop_type.IsInterface)
                    {
                        prop_type = null;
                    }
                }

                if (prop_type == null || prop_type == typeof(object))
                {
                    if (en.MoveNext())
                    {
                        fitem = en.Current;
                        this.firstRecord = fitem;
                    }

                    if (fitem != null)
                    {
                        prop_type = fitem.GetType();
                    }
                }

                if (fitem != null && fitem is ICustomTypeDescriptor)
                {
                    props = TypeDescriptor.GetProperties(fitem);
                }
                else if (prop_type != null)
                {
                    if (IsBindableType(prop_type))
                    {
                        AutoGeneratedFieldProperties field = new AutoGeneratedFieldProperties();
                        ((IStateManager)field).TrackViewState();
                        field.Name = "Item";
                        field.DataField = BoundField.ThisExpression;
                        field.Type = prop_type;
                        retVal.Add(field);
                    }
                    else
                    {
                        if (prop_type.IsArray)
                        {
                            Data = source;
                            return null;
                        }
                        else
                        {
                            props = TypeDescriptor.GetProperties(prop_type); 
                        }
                    }
                }
            }

            if (props != null && props.Count > 0)
            {
                foreach (PropertyDescriptor current in props)
                {
                    if (this.IsBindableType(current.PropertyType) || this.IsComplexField(current.Name))
                    {
                        AutoGeneratedFieldProperties field = new AutoGeneratedFieldProperties();
                        field.Name = current.Name;
                        field.DataField = current.Name;
                        retVal.Add(field);
                    }
                }
            }

            if (retVal.Count > 0)
            {
                return (AutoGeneratedFieldProperties[])retVal.ToArray(typeof(AutoGeneratedFieldProperties));
            }
            
            return null;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public SerializationMode SerializationMode
        {
            get
            {
                object obj = this.ViewState["SerializationMode"];
                return (obj == null) ? SerializationMode.Simple : (SerializationMode)obj;
            }
            set
            {
                this.ViewState["SerializationMode"] = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public enum SerializationMode
    {
        /// <summary>
        /// 
        /// </summary>
        Simple,

        /// <summary>
        /// 
        /// </summary>
        Complex
    }

    internal class CollectionDataSource : IDataSource
    {
        static readonly string[] names = new string[0];
        readonly IEnumerable collection;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CollectionDataSource(IEnumerable collection)
        {
            this.collection = collection;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public event EventHandler DataSourceChanged
        {
            add { }
            remove { }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public DataSourceView GetView(string viewName)
        {
            return new CollectionDataSourceView(this, viewName, collection);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ICollection GetViewNames()
        {
            return names;
        }
    }

    internal class CollectionDataSourceView : DataSourceView
    {
        readonly IEnumerable collection;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public CollectionDataSourceView(IDataSource owner, string viewName, IEnumerable collection)
            : base(owner, viewName)
        {
            this.collection = collection;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected override IEnumerable ExecuteSelect(DataSourceSelectArguments arguments)
        {
            return collection;
        }
    }

    internal class FieldInReader
    {
        private bool inReader;
        private List<RecordField> fields;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public FieldInReader(bool inReader, List<RecordField> fields)
        {
            this.inReader = inReader;
            this.fields = fields;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public bool InReader
        {
            get { return inReader; }
            set { inReader = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public List<RecordField> Fields
        {
            get { return fields; }
            set { fields = value; }
        }
    }
}