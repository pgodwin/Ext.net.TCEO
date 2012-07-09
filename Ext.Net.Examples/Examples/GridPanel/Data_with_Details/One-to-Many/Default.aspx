<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Store2_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        string id = e.Parameters["SupplierID"];
        this.LinqDataSource2.WhereParameters["SupplierID"].DefaultValue = id ?? "-1";
        
        this.Store2.DataBind();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>One to Many Data Relationship with GridPanels - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <asp:LinqDataSource 
            ID="LinqDataSource1" 
            runat="server" 
            ContextTypeName="Ext.Net.Examples.Northwind.NorthwindDataContext"
            Select="new (SupplierID,
                     CompanyName, 
                     ContactName, 
                     ContactTitle, 
                     Address, 
                     City, 
                     Region, 
                     PostalCode, 
                     Country, 
                     Phone, 
                     Fax)" 
            TableName="Suppliers" 
            />
        
        <asp:LinqDataSource 
            ID="LinqDataSource2" 
            runat="server" 
            ContextTypeName="Ext.Net.Examples.Northwind.NorthwindDataContext"
            Select="new (ProductName,
                     QuantityPerUnit,
                     UnitPrice, 
                     UnitsInStock, 
                     Discontinued, 
                     UnitsOnOrder, 
                     ReorderLevel, 
                     ProductID, 
                     SupplierID)" 
            TableName="Products" 
            AutoGenerateWhereClause="True">
            <WhereParameters>
                <asp:Parameter Name="SupplierID" Type="Int32" DefaultValue="-1" />
            </WhereParameters>
        </asp:LinqDataSource>
        
        <ext:Viewport ID="ViewPort1" runat="server">
            <Items>
                <ext:BorderLayout ID="BorderLayout1" runat="server">
                    <North MarginsSummary="5 5 5 5">
                        <ext:Panel 
                            ID="Panel1" 
                            runat="server" 
                            Title="Description" 
                            Height="100" 
                            Padding="5"
                            Frame="true" 
                            Icon="Information">
                            <Content>
                                <h1>One to Many Data Relationship with GridPanels</h1>
                                <p>Click on any record within the parent GridPanel to load related data into second GridPanel.</p>
                                <p>If South Region is collapsed then Ajax load is not performed for the second GridPanel.
                                After South Region is expanded the Ajax request will be performed.</p>
                            </Content>
                        </ext:Panel>
                    </North>
                    <Center MarginsSummary="0 5 0 5">
                        <ext:Panel runat="server" Frame="true" Title="Suppliers" Icon="Lorry" Layout="Fit">
                            <Items>
                                <ext:GridPanel 
                                    ID="GridPanel1" 
                                    runat="server" 
                                    AutoExpandColumn="CompanyName">
                                    <Store>
                                        <ext:Store ID="Store1" runat="server" DataSourceID="LinqDataSource1">
                                            <Reader>
                                                <ext:JsonReader IDProperty="SupplierID">
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
                                                        <ext:RecordField Name="HomePage" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column ColumnID="CompanyName" DataIndex="CompanyName" Header="Company Name" />
                                            <ext:Column DataIndex="ContactName" Header="Contact Name" />
                                            <ext:Column DataIndex="ContactTitle" Header="Contact Title" />
                                            <ext:Column DataIndex="Address" Header="Address" />
                                            <ext:Column DataIndex="City" Header="City" />
                                            <ext:Column DataIndex="Region" Header="Region" Width="200" />
                                            <ext:Column DataIndex="PostalCode" Header="Postal Code" />
                                            <ext:Column DataIndex="Country" Header="Country" />
                                            <ext:Column DataIndex="Phone" Header="Phone" />
                                            <ext:Column DataIndex="Fax" Header="Fax" />
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:RowSelectionModel runat="server" SingleSelect="true">
                                            <Listeners>
                                                <RowSelect Handler="if (#{pnlSouth}.isVisible()) {#{Store2}.reload();}" Buffer="250" />
                                            </Listeners>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolBar1" runat="server" PageSize="10" />
                                    </BottomBar>
                                    <LoadMask ShowMask="true" />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </Center>
                    <South Collapsible="true" Split="true" MarginsSummary="0 5 5 5">
                        <ext:Panel 
                            ID="pnlSouth" 
                            runat="server" 
                            Title="Products" 
                            Height="200" 
                            Icon="Basket" 
                            Layout="Fit">
                            <Items>
                                <ext:GridPanel 
                                    ID="GridPanel2" 
                                    runat="server" 
                                    AutoExpandColumn="ProductName"
                                    Border="false">
                                    <Store>
                                        <ext:Store ID="Store2" runat="server" DataSourceID="LinqDataSource2" OnRefreshData="Store2_Refresh">
                                            <Reader>
                                                <ext:JsonReader IDProperty="ProductID">
                                                    <Fields>
                                                        <ext:RecordField Name="ProductName" />
                                                        <ext:RecordField Name="QuantityPerUnit" />
                                                        <ext:RecordField Name="UnitPrice" Type="Float" />
                                                        <ext:RecordField Name="UnitsInStock" Type="Int" />
                                                        <ext:RecordField Name="UnitsOnOrder" Type="Int" />
                                                        <ext:RecordField Name="ReorderLevel" Type="Int" />
                                                        <ext:RecordField Name="Discontinued" Type="Boolean" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                            <BaseParams>
                                                <ext:Parameter 
                                                    Name="SupplierID" 
                                                    Value="Ext.getCmp('#{GridPanel1}') && #{GridPanel1}.getSelectionModel().hasSelection() ? #{GridPanel1}.getSelectionModel().getSelected().id : -1"
                                                    Mode="Raw" 
                                                    />
                                            </BaseParams>
                                            <Listeners>
                                                <LoadException Handler="Ext.Msg.alert('Products - Load failed', e.message || response.statusText);" />
                                            </Listeners>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column ColumnID="ProductName" DataIndex="ProductName" Header="Product Name" />
                                            <ext:Column DataIndex="QuantityPerUnit" Header="Quantity Per Unit" />
                                            <ext:Column DataIndex="UnitPrice" Header="Unit Price" />
                                            <ext:Column DataIndex="UnitsInStock" Header="Units In Stock" />
                                            <ext:Column DataIndex="UnitsOnOrder" Header="Units On Order" />
                                            <ext:Column DataIndex="ReorderLevel" Header="Reorder Level" />
                                            <ext:CheckColumn DataIndex="Discontinued" Header="Discontinued" />
                                        </Columns>
                                    </ColumnModel>
                                    <LoadMask ShowMask="true" />
                                    <SelectionModel>
                                        <ext:RowSelectionModel runat="server" SingleSelect="true" />
                                    </SelectionModel>                                   
                                </ext:GridPanel>
                            </Items>
                            <Listeners>
                                <Expand Handler="#{Store2}.reload();" />
                            </Listeners>
                        </ext:Panel>
                    </South>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
