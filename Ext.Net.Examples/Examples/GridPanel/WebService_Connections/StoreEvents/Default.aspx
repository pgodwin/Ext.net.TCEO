<%@ Page Language="C#" %>

<%@ Import Namespace="Ext.Net.Examples.Northwind"%>
<%@ Import Namespace="System.Data.Linq" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    private NorthwindDataContext db;
    
    protected void Store1_BeforeChanged(object sender, BeforeStoreChangedEventArgs e)
    {
        this.db = new NorthwindDataContext();
    }

    //This handler will be calling for each inserted record
    protected void Store1_BeforeInserted(object sender, BeforeRecordInsertedEventArgs e)
    {
        Supplier supplier = e.Object<Supplier>();
        db.Suppliers.InsertOnSubmit(supplier);
    }

    //This handler will be calling for each changed record
    protected void Store1_BeforeUpdated(object sender, BeforeRecordUpdatedEventArgs e)
    {
        Supplier supplier = e.Object<Supplier>();
        this.db.Suppliers.Attach(supplier);
        this.db.Refresh(RefreshMode.KeepCurrentValues, supplier);
    }

    //This handler will be calling for each deleted record
    protected void Store1_BeforeDeleted(object sender, BeforeRecordDeletedEventArgs e)
    {
        Supplier supplier = e.Object<Supplier>();
        this.db.Suppliers.Attach(supplier);
        this.db.Suppliers.DeleteOnSubmit(supplier);
    }

    protected void Store1_AfterChanged(object sender, AfterStoreChangedEventArgs e)
    {
        this.db.SubmitChanges();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel with CRUD - Ext.NET Example</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:Viewport runat="server" Layout="border">
            <Items>
                <ext:Panel 
                    runat="server" 
                    Region="North"
                    Border="false" 
                    Height="120" 
                    Padding="6">
                    <Content>
                        <h1>CRUD Grid Example</h1>
                        <p>Demonstrates how to get data from web-service and save using Store (with store events).</p>                           
                    </Content>
                </ext:Panel>
                <ext:GridPanel 
                    ID="GridPanel1" 
                    runat="server" 
                    Title="Suppliers" 
                    Region="Center"
                    AutoExpandColumn="CompanyName"
                    Icon="Lorry" 
                    Frame="true">
                    <Store>
                        <ext:Store 
                            runat="server" 
                            OnBeforeStoreChanged="Store1_BeforeChanged" 
                            OnAfterStoreChanged="Store1_AfterChanged"
                            OnBeforeRecordInserted="Store1_BeforeInserted"
                            OnBeforeRecordUpdated="Store1_BeforeUpdated"
                            OnBeforeRecordDeleted="Store1_BeforeDeleted">
                            <Proxy>
                                <ext:HttpProxy Method="GET" Url="../../Shared/SuppliersService.asmx/GetAllSuppliers" />
                            </Proxy>        
                            <Reader>
                                <ext:XmlReader Record="Supplier" IDPath="SupplierID">
                                    <Fields>
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
                                </ext:XmlReader>
                            </Reader>
                            <SortInfo Field="CompanyName" Direction="ASC" />
                            <Listeners>
                                <LoadException Handler="var e = e || {message: response.responseText}; alert('Load failed: ' + e.message);" />
                                <SaveException Handler="alert('save failed');" />
                                <CommitDone Handler="alert('commit success');" />
                                <CommitFailed Handler="alert('Commit failed\nReason: '+msg)" />
                            </Listeners>
                        </ext:Store>
                    </Store>
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:Column ColumnID="CompanyName" DataIndex="CompanyName" Header="Company Name">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column DataIndex="ContactName" Header="Contact Name">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column DataIndex="ContactTitle" Header="Contact Title">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column DataIndex="Address" Header="Address">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column DataIndex="City" Header="City">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column DataIndex="Region" Header="Region">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column DataIndex="PostalCode" Header="Postal Code">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column DataIndex="Country" Header="Country">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column DataIndex="Phone" Header="Phone">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                            <ext:Column DataIndex="Fax" Header="Fax">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    
                    <LoadMask ShowMask="true" />
                    <SaveMask ShowMask="true" />
                    
                    <SelectionModel>
                        <ext:RowSelectionModel SingleSelect="false" runat="server">
                            <Listeners>
                                <RowSelect Handler="#{btnDelete}.enable();" />
                                <RowDeselect Handler="if (!#{GridPanel1}.hasSelection()) {#{btnDelete}.disable();}" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    
                    <Buttons>
                        <ext:Button runat="server" Text="Add" Icon="Add">
                            <Listeners>
                                <Click Handler="var rowIndex = #{GridPanel1}.addRecord(); #{GridPanel1}.getView().focusRow(rowIndex); #{GridPanel1}.startEditing(rowIndex, 0);" />
                            </Listeners>
                        </ext:Button>
                        
                        <ext:Button runat="server" Text="Insert" Icon="Add">
                            <Listeners>
                                <Click Handler="#{GridPanel1}.insertRecord(0, {});#{GridPanel1}.getView().focusRow(0);#{GridPanel1}.startEditing(0, 0);" />
                            </Listeners>
                        </ext:Button>
                        
                        <ext:Button ID="btnDelete" runat="server" Text="Delete" Icon="Delete" Disabled="true">
                            <Listeners>
                                <Click Handler="#{GridPanel1}.deleteSelected();if (!#{GridPanel1}.hasSelection()) {#{btnDelete}.disable();}" />
                            </Listeners>
                        </ext:Button>
                        
                        <ext:Button runat="server" Text="Save" Icon="Disk">
                            <Listeners>
                                <Click Handler="#{GridPanel1}.save();" />
                            </Listeners>
                        </ext:Button>
                        
                        <ext:Button runat="server" Text="Clear" Icon="Cancel">
                            <Listeners>
                                <Click Handler="#{GridPanel1}.clear();if (!#{GridPanel1}.hasSelection()) {#{btnDelete}.disable();}" />
                            </Listeners>
                        </ext:Button>
                        
                        <ext:Button runat="server" Text="Refresh" Icon="ArrowRefresh">
                            <Listeners>
                                <Click Handler="#{GridPanel1}.reload();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:GridPanel>
            </Items>        
        </ext:Viewport>   
    </form>      
</body>
</html>
