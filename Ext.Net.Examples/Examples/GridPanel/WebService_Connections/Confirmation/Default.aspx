<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The CRUD Example</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    
</head>
<body>
       
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    
    <ext:Store runat="server" ID="Store1" RefreshAfterSaving="None" UseIdConfirmation="true">
        <Proxy>
            <ext:HttpProxy Method="GET" Url="../../Shared/SuppliersService.asmx/GetAllSuppliers" />
        </Proxy>
        <UpdateProxy>
            <ext:HttpWriteProxy Method="POST" Url="../../Shared/SuppliersSaveWithConfirmation.ashx" />
        </UpdateProxy>
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
    
    <ext:Viewport ID="ViewPort1" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <North>
                    <ext:Panel ID="Panel1" runat="server" Border="false" Height="120" Padding="6">
                        <Content>
                            <h1>CRUD Grid Example</h1>
                            <p>Demonstrates how to get data from web-service and save using HttpHandler with Confirmation.</p>                                                       
                        </Content>
                    </ext:Panel>
                </North>
                <Center>
                     <ext:GridPanel runat="server" ID="GridPanel1" Title="Suppliers" AutoExpandColumn="CompanyName"
                        StoreID="Store1" Icon="Lorry" Frame="true">
                        <ColumnModel runat="server">
                            <Columns>
                                <ext:Column ColumnID="CompanyName" DataIndex="CompanyName" Header="Company Name">
                                    <Editor>
                                        <ext:TextField ID="TextField1" runat="server" />
                                    </Editor>
                                </ext:Column>
                                <ext:Column DataIndex="ContactName" Header="Contact Name">
                                    <Editor>
                                        <ext:TextField ID="TextField2" runat="server" />
                                    </Editor>
                                </ext:Column>
                                <ext:Column DataIndex="ContactTitle" Header="Contact Title">
                                    <Editor>
                                        <ext:TextField ID="TextField3" runat="server" />
                                    </Editor>
                                </ext:Column>
                                <ext:Column DataIndex="Address" Header="Address">
                                    <Editor>
                                        <ext:TextField ID="TextField4" runat="server" />
                                    </Editor>
                                </ext:Column>
                                <ext:Column DataIndex="City" Header="City">
                                    <Editor>
                                        <ext:TextField ID="TextField5" runat="server" />
                                    </Editor>
                                </ext:Column>
                                <ext:Column DataIndex="Region" Header="Region">
                                    <Editor>
                                        <ext:TextField ID="TextField6" runat="server" />
                                    </Editor>
                                </ext:Column>
                                <ext:Column DataIndex="PostalCode" Header="Postal Code">
                                    <Editor>
                                        <ext:TextField ID="TextField7" runat="server" />
                                    </Editor>
                                </ext:Column>
                                <ext:Column DataIndex="Country" Header="Country">
                                    <Editor>
                                        <ext:TextField ID="TextField8" runat="server" />
                                    </Editor>
                                </ext:Column>
                                <ext:Column DataIndex="Phone" Header="Phone">
                                    <Editor>
                                        <ext:TextField ID="TextField9" runat="server" />
                                    </Editor>
                                </ext:Column>
                                <ext:Column DataIndex="Fax" Header="Fax">
                                    <Editor>
                                        <ext:TextField ID="TextField10" runat="server" />
                                    </Editor>
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        
                        <LoadMask ShowMask="true" />
                        <SaveMask ShowMask="true" />
                        
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel1" SingleSelect="false" runat="server">
                                <Listeners>
                                    <RowSelect Handler="#{btnDelete}.enable();" />
                                    <RowDeselect Handler="if (!#{GridPanel1}.hasSelection()) {#{btnDelete}.disable();}" />
                                </Listeners>
                            </ext:RowSelectionModel>
                        </SelectionModel>
                        
                        <Buttons>
                            <ext:Button ID="Button1" runat="server" Text="Add" Icon="Add">
                                <Listeners>
                                    <Click Handler="var rowIndex = #{GridPanel1}.addRecord(); #{GridPanel1}.getView().focusRow(rowIndex); #{GridPanel1}.startEditing(rowIndex, 0);" />
                                </Listeners>
                            </ext:Button>
                            
                            <ext:Button ID="Button2" runat="server" Text="Insert" Icon="Add">
                                <Listeners>
                                    <Click Handler="#{GridPanel1}.insertRecord(0, {});#{GridPanel1}.getView().focusRow(0);#{GridPanel1}.startEditing(0, 0);" />
                                </Listeners>
                            </ext:Button>
                            
                            <ext:Button ID="btnDelete" runat="server" Text="Delete" Icon="Delete" Disabled="true">
                                <Listeners>
                                    <Click Handler="#{GridPanel1}.deleteSelected();if (!#{GridPanel1}.hasSelection()) {#{btnDelete}.disable();}" />
                                </Listeners>
                            </ext:Button>
                            
                            <ext:Button ID="Button3" runat="server" Text="Save" Icon="Disk">
                                <Listeners>
                                    <Click Handler="#{GridPanel1}.save();" />
                                </Listeners>
                            </ext:Button>
                            
                            <ext:Button ID="Button4" runat="server" Text="Clear" Icon="Cancel">
                                <Listeners>
                                    <Click Handler="#{GridPanel1}.clear();if (!#{GridPanel1}.hasSelection()) {#{btnDelete}.disable();}" />
                                </Listeners>
                            </ext:Button>
                            
                            <ext:Button ID="Button5" runat="server" Text="Refresh" Icon="ArrowRefresh">
                                <Listeners>
                                    <Click Handler="#{GridPanel1}.reload();" />
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:GridPanel>
                </Center>            
            </ext:BorderLayout>
        </Items>        
    </ext:Viewport>   
   
</body>
</html>
