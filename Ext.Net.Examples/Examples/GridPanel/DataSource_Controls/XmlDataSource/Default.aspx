<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel with XmlDataSource - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <asp:XmlDataSource 
            ID="XmlDataSource1" 
            runat="server" 
            DataFile="../../Shared/Plants.xml"
            TransformFile="../../Shared/Plants.xsl" 
            />
        
        <ext:GridPanel 
            runat="server" 
            Width="600" 
            Height="300" 
            AutoExpandColumn="Common"
            Title="Plants" 
            Frame="true">
            <Store>
                <ext:Store runat="server" DataSourceID="XmlDataSource1">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                                <ext:RecordField Name="Common" />
                                <ext:RecordField Name="Botanical" />
                                <ext:RecordField Name="Light" />
                                <ext:RecordField Name="Price" Type="Float" />
                                <ext:RecordField Name="Availability" Type="Date" DateFormat="m/d/Y" />
                                <ext:RecordField Name="Indoor" Type="Boolean" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                    <SortInfo Field="Common" Direction="ASC" />
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column ColumnID="Common" Header="Common Name" DataIndex="Common" Width="220" Sortable="true" />
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
                <ext:PagingToolbar runat="server" PageSize="10" />
            </BottomBar>
        </ext:GridPanel>    
    </form>
</body>
</html>