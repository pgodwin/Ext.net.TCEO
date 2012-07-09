<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:ViewPort runat="server" Layout="fit">
        <Items>
            <ext:GridPanel 
                runat="server" 
                Border="false"
                TrackMouseOver="true">
                <Store>
                    <ext:Store ID="Store1" runat="server" ShowWarningOnFailure="true">
                        <Proxy>
                            <ext:HttpProxy Url="/Data/GetTopTenOrdersBySalesAmount/" />
                        </Proxy>
                        <Reader>
                            <ext:JsonReader Root="data" IDProperty="OrderID">
                                <Fields>
                                    <ext:RecordField Name="OrderID" Type="Int"/>
                                    <ext:RecordField Name="OrderDate" Type="Date" />
                                    <ext:RecordField Name="SaleAmount" Type="Float"/>
                                    <ext:RecordField Name="CompanyName" />
                                    <ext:RecordField Name="ShippedDate" Type="Date" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>                
                </Store>
                <ColumnModel>
                    <Columns>
                        <ext:Column Header="Order ID" DataIndex="OrderID"/>
                        <ext:Column Header="Sale Amount" DataIndex="SaleAmount">
                            <Renderer Format="UsMoney" />
                        </ext:Column>
                        <ext:DateColumn Header="Order Date" DataIndex="OrderDate" Format="yyyy-MM-dd" />
                        <ext:Column Header="Company" DataIndex="CompanyName"/>
                        <ext:DateColumn Header="Shipped Date" DataIndex="ShippedDate" Format="yyyy-MM-dd" />
                    </Columns>
                </ColumnModel>
                <View>
                    <ext:GridView runat="server" AutoFill="true" />
                </View>
                <SelectionModel>
                    <ext:RowSelectionModel runat="server" />
                </SelectionModel>
                <LoadMask ShowMask="true" />
            </ext:GridPanel>
        </Items>
    </ext:ViewPort>
</body>
</html>
