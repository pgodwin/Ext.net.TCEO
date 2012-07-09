<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AJAX Request to HttpHander returns Json - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    
    <ext:Store runat="server" ID="Store1">
        <Proxy>
            <ext:HttpProxy Method="GET" Url="../../Shared/JsonHandler.ashx" />
        </Proxy>
        <Reader>
            <ext:JsonReader Root="plants">
                <Fields>
                    <ext:RecordField Name="Common" Type="String" />
                    <ext:RecordField Name="Botanical" Type="String" />
                    <ext:RecordField Name="Light" />
                    <ext:RecordField Name="Price" Type="Float" />
                    <ext:RecordField Name="Availability" Type="Date" />
                    <ext:RecordField Name="Indoor" Type="Boolean" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <SortInfo Field="Common" Direction="ASC" />
    </ext:Store>
    
    <ext:Window 
        runat="server" 
        Collapsible="true" 
        Title="Plant Summary" 
        Height="500" 
        Width="1000"
        Layout="Fit">
        <Items>
            <ext:GridPanel 
                ID="GridPanel1" 
                runat="server" 
                AutoExpandColumn="Common" 
                Title="Plants" 
                Frame="false" 
                StoreID="Store1">
                <ColumnModel runat="server">
                <Columns>
                    <ext:Column ColumnID="Common" Header="Common Name" DataIndex="Common" Width="220" />
                    <ext:Column Header="Light" DataIndex="Light" Width="130" />
                    <ext:Column Header="Price" DataIndex="Price" Width="70" Align="right" />
                    <ext:DateColumn Header="Available" DataIndex="Availability" Width="95" />
                    <ext:Column Header="Indoor?" DataIndex="Indoor" Width="55" />
                </Columns>
                </ColumnModel>
                <LoadMask ShowMask="true" />
            </ext:GridPanel>  
        </Items>                          
    </ext:Window>    
</body>
</html>