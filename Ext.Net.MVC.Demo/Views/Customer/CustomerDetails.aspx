<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<%@ Register src="CustomerDetailsGeneral.ascx" tagname="CustomerDetailsGeneral" tagprefix="uc1" %>
<%@ Register src="CustomerDetailsOrders.ascx" tagname="CustomerDetailsOrders" tagprefix="uc1" %>
<%@ Register src="~/Views/Order/OrderDetails.ascx" tagname="OrderDetails" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    
    <script type="text/javascript">
        var failureHandler = function (form, action) {
            var msg = "";
            if (action.failureType == "client" || (action.result && action.result.errors && action.result.errors.length > 0)) {
                msg = "Please check fields";
            } else if (action.result && action.result.extraParams.msg) {
                msg = action.result.extraParams.msg;
            } else if (action.response) {
                msg = action.response.responseText;
            }

            Ext.Msg.show({
                title   : "Save Error",
                msg     : msg,
                buttons : Ext.Msg.OK,
                icon    : Ext.Msg.ERROR
            });
        };

        var successHandler = function(form, action) {

            if (action.result && action.result.extraParams && action.result.extraParams.newID) {
                dsCustomer.getAt(0).id = action.result.extraParams.newID;
                if (dsCustomer.getAt(0).newRecord) {
                    delete dsCustomer.getAt(0).newRecord;
                }
            } else {
                Ext.MessageBox.alert("Success", "Customer has been saved!");
            }

            customerChanged = true;

            if (action.options.params.setNew) {
                DetailsForm.form.reset();
                dsCustomer.removeAll();
                dsOrders.removeAll();

                var rec = new dsCustomer.recordType();
                rec.newRecord = true;
                dsCustomer.add(rec);
                initUI(true);
            } else {
                initUI(false);
            }
            
            txtCustomers.lastQuery=null; 
        };

        var getCustomerID = function() {
            return (dsCustomer.getCount() > 0 && !dsCustomer.getAt(0).newRecord) ? dsCustomer.getAt(0).id : ""
        };

        var customerLoaded = function(store, records) {
            if (records.length > 0) {
                DetailsForm.form.loadRecord(records[0]);
                dsOrders.loaded = false;                

                if (CustomerPanel.getActiveTab().id == tabOrders.id) {
                    dsOrders.reload();
                }
            } else {
                DetailsForm.form.reset();
                dsOrders.removeAll();
            }
            
            initUI(false);
            CustomerPanel.el.unmask();
        };

        var initUI = function(isNew) {
            btnDelete.setDisabled(isNew);
            tabOrders.setDisabled(isNew);
            CustomerID.setDisabled(!isNew);
        };
    </script>

    <style type="text/css">
        .txtCustomers-list {
            width : 298px;
            font  : 11px tahoma,arial,helvetica,sans-serif;
        }
        
        .txtCustomers-list th {
            font-weight : bold;
        }
        
        .txtCustomers-list td, .txtCustomers-list th {
            padding : 3px;
        }
    </style>
</head>
<body>
    <ext:ResourceManager runat="server">    
        <Listeners>
            <DocumentReady Handler="if (Ext.isEmpty(#{txtFilter}.getValue(), false)) { #{dsCustomer}.load(); }" />
        </Listeners>        
    </ext:ResourceManager>
    
    <ext:Store ID="dsCustomer" runat="server" AutoLoad="false">
        <Proxy>
            <ext:HttpProxy Url="/Data/GetCustomer/" />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="CustomerID" Root="data" TotalProperty="total">
                <Fields>
                    <ext:RecordField Name="CustomerID" />
                    <ext:RecordField Name="CompanyName" />
                    <ext:RecordField Name="ContactName" />
                    <ext:RecordField Name="ContactTitle" />
                    <ext:RecordField Name="Address" />
                    <ext:RecordField Name="City" />
                    <ext:RecordField Name="Region" />
                    <ext:RecordField Name="PostalCode" />
                    <ext:RecordField Name="Country" />
                    <ext:RecordField Name="Phone" />
                    <ext:RecordField Name="Fax" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="filter" Value="#{txtFilter}.getValue()" Mode="Raw" />
        </BaseParams>
        <Listeners>
            <BeforeLoad Handler="#{CustomerPanel}.el.mask('Loading customer...', 'x-mask-loading');" />
            <LoadException Handler="#{CustomerPanel}.el.unmask();" />
            <Load Fn="customerLoaded" />
        </Listeners>
    </ext:Store>
    
    <ext:Store ID="dsCustomers" runat="server" ShowWarningOnFailure="true" AutoLoad="false">
        <Proxy>
            <ext:HttpProxy Url="/Data/GetCustomersPaging/" />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="CustomerID" Root="data" TotalProperty="total">
                <Fields>
                    <ext:RecordField Name="CustomerID"/>
                    <ext:RecordField Name="CompanyName" />
                    <ext:RecordField Name="ContactName" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Name="filter" Value="#{txtCustomers}.getText()" Mode="Raw" />
        </BaseParams>
    </ext:Store>
    
    <ext:ViewPort runat="server" Layout="fit">
        <Items>
            <ext:Panel runat="server" Border="false" Layout="fit">
                 <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Button runat="server" Text="Save" Icon="Disk">
                                <Listeners>
                                    <Click Handler="#{DetailsForm}.form.submit({ waitMsg : 'Saving...', params : { id : getCustomerID() }, success : successHandler, failure : failureHandler });" />
                                </Listeners>
                            </ext:Button>
                            
                            <ext:Button runat="server" Text="Save and New" Icon="Add">
                                 <Listeners>
                                    <Click Handler="#{DetailsForm}.form.submit({ waitMsg : 'Saving...', params : { setNew : true, id : getCustomerID() }, success : successHandler, failure : failureHandler });" />
                                </Listeners>
                            </ext:Button>
                            
                            <ext:Button ID="btnDelete" runat="server" Text="Delete" Icon="Cross">
                                 <DirectEvents>
                                    <Click 
                                        Url="/Data/DeleteCustomer" 
                                        CleanRequest="true"
                                        Method="POST"
                                        Failure="Ext.Msg.show({title:'Delete Error',msg: result.errorMessage,buttons: Ext.Msg.OK,icon: Ext.Msg.ERROR});" 
                                        Success="txtCustomers.lastQuery=null; customerChanged = true;#{CustomerPager}.doLoad(Math.max(0, #{CustomerPager}.cursor-1));">
                                        <Confirmation ConfirmRequest="true" Title="Alert" Message="Delete Record?" />
                                        <ExtraParams>
                                            <ext:Parameter Name="id" Value="#{dsCustomer}.getAt(0).id" Mode="Raw" />
                                        </ExtraParams>
                                    </Click>
                                 </DirectEvents>
                            </ext:Button>
                            
                            <ext:ToolbarFill runat="server" />
                            <ext:Hidden ID="txtFilter" runat="server" Text='<%# ViewData["id"] %>' AutoDataBind="true">
                                <Listeners>
                                    <Change Handler="#{CustomerPager}.changePage(1);" Delay="30" />
                                </Listeners>
                            </ext:Hidden>
                            
                            <ext:ComboBox 
                                ID="txtCustomers" 
                                runat="server"
                                EmptyText="Select Customer"
                                TypeAhead="true"
                                ForceSelection="true"
                                StoreID="dsCustomers"
                                DisplayField="CompanyName" 
                                ValueField="CustomerID"
                                MinChars="1"
                                ListWidth="300"
                                PageSize="10"
                                ItemSelector="tr.list-item">
                                <Template runat="server">
                                    <Html>
										<tpl for=".">
											<tpl if="[xindex] == 1">
												<table class="txtCustomers-list">
													<tr>
														<th>Company</th>
														<th>Contact Name</th>
													</tr>
											</tpl>
											<tr class="list-item">
												<td style="padding:3px 0px;">{CompanyName}</td>
												<td>{ContactName}</td>
											</tr>
											<tpl if="[xcount-xindex]==0">
												</table>
											</tpl>
										</tpl>
									</Html>
                                </Template>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if(index == 0) { this.focus().clearValue(); trigger.hide(); #{txtFilter}.setValue(''); }" />
                                    <Select Handler="this.triggers[0].show(); #{txtSearch}.setValue(''); #{txtFilter}.setValue(this.getValue());" />
                                    <Blur Handler="if(Ext.isEmpty(this.getText())) { this.setValue(''); #{txtFilter}.setValue(''); };" />
                                </Listeners>
                            </ext:ComboBox>                                   
                            
                            <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" />
                            <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" />
                            <ext:TriggerField 
                                ID="txtSearch" 
                                runat="server" 
                                EmptyText="Search" 
                                EnableKeyEvents="true">
                                <Listeners>
                                    <KeyDown Buffer="200" Handler="#{txtCustomers}.setValue('');#{txtFilter}.setValue(this.getValue()); if(!Ext.isEmpty(this.getValue())) { this.triggers[0].show(); }" />
                                    <TriggerClick Handler="if (index == 1) { #{txtFilter}.setValue(this.getValue()); } if(index == 0) { #{txtSearch}.reset(); #{txtFilter}.setValue(''); this.triggers[0].hide(); }" />
                                    <Blur Handler="if (Ext.isEmpty(this.getValue())) { this.triggers[0].hide(); }" />
                                </Listeners>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    <ext:FieldTrigger Icon="Search" />
                                </Triggers>
                            </ext:TriggerField>
                        </Items>
                    </ext:Toolbar>
                 </TopBar>
                 <Items>
                    <ext:TabPanel ID="CustomerPanel" runat="server" Border="false" LayoutOnTabChange="true">
                        <Items>
                            <ext:Panel 
                                runat="server" 
                                Title="General" 
                                Padding="6" 
                                Layout="fit">
                                <Items>
                                    <ext:FormPanel 
                                        ID="DetailsForm" 
                                        runat="server" 
                                        Border="false" 
                                        Url="/Data/SaveCustomer/" 
                                        LabelWidth="130">
                                        <Items>
                                            <ext:FieldSet runat="server" Layout="form">
                                                <Items>
                                                    <ext:TextField 
                                                        ID="CustomerID" 
                                                        runat="server" 
                                                        FieldLabel="Customer ID" 
                                                        LabelSeparator=" "
                                                        MaxLength="5" 
                                                        AllowBlank="false"
                                                        />
                                                    <ext:TextField 
                                                        ID="CompanyName" 
                                                        runat="server" 
                                                        Width="250" 
                                                        FieldLabel="Company" 
                                                        />
                                                </Items>
                                            </ext:FieldSet>
                                            <ext:Container runat="server" Layout="hbox">
                                                <Items>
                                                    <ext:Container runat="server" Flex="1">
                                                        <Items>
                                                            <ext:FieldSet 
                                                                runat="server" 
                                                                Title="Primary Contact" 
                                                                Border="false" 
                                                                Layout="form"
                                                                DefaultAnchor="-10">
                                                                <Items>
                                                                    <ext:TextField 
                                                                        ID="ContactName" 
                                                                        runat="server" 
                                                                        FieldLabel="Contact Name" 
                                                                        MsgTarget="Side" 
                                                                        AllowBlank="false"
                                                                        />
                                                                    <ext:TextField ID="ContactTitle" runat="server" FieldLabel="Job Title" />
                                                                </Items>
                                                            </ext:FieldSet>
                                                            <ext:FieldSet 
                                                                runat="server" 
                                                                Title="Phone Numbers" 
                                                                Border="false" 
                                                                Layout="form"
                                                                DefaultAnchor="-10">
                                                                <Items>
                                                                    <ext:TextField ID="Phone" runat="server" FieldLabel="Business Phone" />
                                                                    <ext:TextField ID="Fax" runat="server" FieldLabel="Fax Number" />
                                                                </Items>
                                                            </ext:FieldSet>
                                                        </Items>
                                                    </ext:Container>
                                                    <ext:FieldSet 
                                                        runat="server" 
                                                        Title="Address" 
                                                        Border="false" 
                                                        Layout="form" 
                                                        Flex="1"
                                                        DefaultAnchor="100%">
                                                        <Items>
                                                            <ext:TextField ID="Address" runat="server" FieldLabel="Street" />
                                                            <ext:TextField ID="City" runat="server" FieldLabel="City" />
                                                            <ext:TextField ID="Region" runat="server" FieldLabel="State/Province" />
                                                            <ext:TextField ID="PostalCode" runat="server" FieldLabel="Zip/Postal Code" />
                                                            <ext:TextField ID="Country" runat="server" FieldLabel="Country/Region" /> 
                                                        </Items>
                                                    </ext:FieldSet>
                                                </Items>
                                            </ext:Container>
                                        </Items>
                                    </ext:FormPanel>
                                </Items>
                            </ext:Panel>
                            <ext:Panel 
                                ID="tabOrders" 
                                runat="server" 
                                Title="Orders" 
                                Layout="border"
                                BodyStyle="background-color:#F0F0F0;">
                                <Items>
                                    <ext:GridPanel 
                                        ID="grdOrders" 
                                        runat="server" 
                                        Region="Center"
                                        Border="false"
                                        TrackMouseOver="true">
                                        <Store>
                                            <ext:Store 
                                                ID="dsOrders" 
                                                runat="server" 
                                                ShowWarningOnFailure="true" 
                                                AutoLoad="false">
                                                <Proxy>
                                                    <ext:HttpProxy Url="/Data/GetCustomerOrders/" />
                                                </Proxy>
                                                <Reader>
                                                    <ext:JsonReader IDProperty="OrderID" Root="data" TotalProperty="total">
                                                        <Fields>
                                                            <ext:RecordField Name="OrderID" />
                                                            <ext:RecordField Name="OrderDate" Type="Date" />
                                                            <ext:RecordField Name="RequiredDate" Type="Date" />
                                                            <ext:RecordField Name="ShippedDate" Type="Date" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                                <BaseParams>
                                                    <ext:Parameter Name="customerID" Value="getCustomerID()" Mode="Raw" />
                                                </BaseParams>
                                                <Listeners>
                                                    <BeforeLoad Handler="OrderCommonInformation.form.reset();dsOrderDetails.removeAll();ShippingInformationForm.form.reset();SouthPanel.collapse(true);return !this.loaded;" />
                                                    <Load Handler="this.loaded = true;" />
                                                </Listeners>
                                            </ext:Store>
                                        </Store>
                                        <ColumnModel>
                                            <Columns>
                                                <ext:Column Header="Order ID" DataIndex="OrderID"/>                                               
                                                <ext:DateColumn Header="Order Date" DataIndex="OrderDate" Format="yyyy-MM-dd" />
                                                <ext:DateColumn Header="Required Date" DataIndex="RequiredDate" Format="yyyy-MM-dd" />
                                                <ext:DateColumn Header="Shipped Date" DataIndex="ShippedDate" Format="yyyy-MM-dd" />
                                            </Columns>
                                        </ColumnModel>
                                        <View>
                                            <ext:GridView runat="server" AutoFill="true" />
                                        </View>
                                        <SelectionModel>
                                            <ext:RowSelectionModel runat="server">
                                                <Listeners>
                                                    <RowSelect Handler="SouthPanel.expand(true);SouthPanel.doLayout();OrderDetails.body.mask('Loading order ' + record.id + '...', 'x-mask-loading'); dsOrder.load({params:{orderID: record.id}});" Buffer="250" />
                                                </Listeners>
                                            </ext:RowSelectionModel>
                                        </SelectionModel>
                                        <LoadMask ShowMask="true" />
                                    </ext:GridPanel>
                                    <ext:Panel 
                                        ID="SouthPanel" 
                                        runat="server" 
                                        Region="South" 
                                        Split="true" 
                                        Border="true" 
                                        Collapsible="true" 
                                        Title="Order" 
                                        Collapsed="true" 
                                        Height="350">
                                        <Content>
                                            <uc1:OrderDetails runat="server" />
                                        </Content>
                                    </ext:Panel>
                                </Items>
                                <Listeners>
                                    <Activate Handler="#{dsOrders}.reload();" />
                                </Listeners>
                            </ext:Panel>
                        </Items>
                        <BottomBar>
                            <ext:PagingToolbar 
                                ID="CustomerPager" 
                                runat="server" 
                                PageSize="1" 
                                StoreID="dsCustomer"
                                DisplayMsg="Displaying Customer {0} of {2}"
                                />
                        </BottomBar>
                    </ext:TabPanel>
                 </Items> 
            </ext:Panel>
        </Items>
    </ext:ViewPort>
</body>
</html>
