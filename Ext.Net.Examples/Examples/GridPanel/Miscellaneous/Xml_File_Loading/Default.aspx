<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XML File Loading</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    
    <ext:Store runat="server" ID="Store1">
        <Proxy>
            <ext:HttpProxy runat="server" Url="../../Shared/Plants.xml" />
        </Proxy>
        <Reader>
            <ext:XmlReader Record="plant">
                <Fields>
                    <ext:RecordField Name="common" />
                    <ext:RecordField Name="botanical" />
                    <ext:RecordField Name="light" />
                    <ext:RecordField Name="price" Type="Float" />
                    <ext:RecordField Name="availability" Type="Date" />
                    <ext:RecordField Name="indoor" Type="Boolean" />
                </Fields>
            </ext:XmlReader>
        </Reader>
        <SortInfo Field="common" Direction="ASC" />
    </ext:Store>
    
    <ext:GridPanel 
        runat="server" 
        Width="600" 
        Height="300" 
        AutoExpandColumn="common" 
        Title="Plants" 
        Frame="true" 
        StoreID="Store1">
        <ColumnModel runat="server">
		<Columns>
            <ext:Column ColumnID="common" Header="Common Name" DataIndex="common" Width="220" />
            <ext:Column Header="Light" DataIndex="light" Width="130" />
            <ext:Column Header="Price" DataIndex="price" Width="70" Align="right">
                <Renderer Format="UsMoney" />
            </ext:Column>
            <ext:DateColumn Header="Available" DataIndex="availability" Width="95" Format="yyyy-MM-dd" />
            <ext:Column Header="Indoor?" DataIndex="indoor" Width="55" />
		</Columns>
        </ColumnModel>
        <LoadMask ShowMask="true" />        
    </ext:GridPanel>
</body>
</html>