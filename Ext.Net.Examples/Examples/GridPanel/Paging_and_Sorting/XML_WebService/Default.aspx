<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel with XML WebService - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
       <ext:Store ID="Store1" runat="server" RemoteSort="true">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="../../Shared/PlantService.asmx/PlantsPaging" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={5}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="filter" Value="" Mode="Value" />
            </BaseParams>
            <Reader>
                <ext:XmlReader Record="Plant" TotalProperty="TotalRecords">
                    <Fields>
                        <ext:RecordField Name="Common" />
                        <ext:RecordField Name="Botanical" />
                        <ext:RecordField Name="Light" />
                        <ext:RecordField Name="Price" Type="Float" />
                        <ext:RecordField Name="Availability" Type="Date" />
                        <ext:RecordField Name="Indoor" Type="Boolean" />
                    </Fields>
                </ext:XmlReader>
            </Reader>
            <SortInfo Field="Common" Direction="ASC" />
        </ext:Store>
        
        <ext:GridPanel 
            runat="server" 
            ID="GridPanel1" 
            Title="Employees" 
            Frame="true" 
            StoreID="Store1"
            AutoExpandColumn="Common" 
            Height="300">
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column ColumnID="Comm-on" Header="Common Name" DataIndex="Common" Width="220" Sortable="true" />
                    <ext:Column Header="Botanical" DataIndex="Botanical" Width="230" />
                    <ext:Column Header="Light" DataIndex="Light" Width="130" />
                    <ext:Column Header="Price" DataIndex="Price" Width="70" Align="right" />
                    <ext:DateColumn Header="Available" DataIndex="Availability" Width="95" Format="yyyy-MM-dd" />
                    <ext:Column Header="Indoor?" DataIndex="Indoor" Width="55" />
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" />
            </SelectionModel>            
            <BottomBar>
                <ext:PagingToolbar
                    runat="server" 
                    PageSize="5"
                    DisplayInfo="true" 
                    DisplayMsg="Displaying plants {0} - {1} of {2}" 
                    EmptyMsg="No plants to display" 
                    />
            </BottomBar>
            <LoadMask ShowMask="true" />
        </ext:GridPanel>
    </form>
</body>
</html>