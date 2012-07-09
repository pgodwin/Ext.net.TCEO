<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var commandHandler = function (cmd, record) {
            switch (cmd) {
                case "view":
                    var win = OrderDetailsWindow;
                    win.autoLoad.params.orderID = record.id;
                    win.setTitle('Order #' + record.id);
                    win.show();
                    break;
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:Store ID="dsOrders" runat="server" RemoteSort="true">
        <Proxy>
            <ext:HttpProxy Url="/Data/GetOrders/" />
        </Proxy>
        <Reader>
            <ext:JsonReader IDProperty="OrderID" Root="data" TotalProperty="total">
                <Fields>
                    <ext:RecordField Name="OrderID" />
                    <ext:RecordField Name="OrderDate" Type="Date" />
                    <ext:RecordField Name="Salesperson" />
                    <ext:RecordField Name="CompanyName" />
                    <ext:RecordField Name="ShippedDate" Type="Date"/>
                    <ext:RecordField Name="Freight" Type="Float" />
                    <ext:RecordField Name="Total" Type="Float" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <BaseParams>
            <ext:Parameter Name="limit" Value="15" Mode="Raw" />
            <ext:Parameter Name="start" Value="0" Mode="Raw" />
            <ext:Parameter Name="dir" Value="ASC" />
            <ext:Parameter Name="sort" Value="OrderID" />
        </BaseParams>
        <SortInfo Field="OrderID" Direction="ASC" />
    </ext:Store>
    
    <ext:ViewPort runat="server" Layout="fit">
        <Items>
                <ext:GridPanel 
                    runat="server" 
                    Header="false"
                    Border="false"
                    StoreID="dsOrders" 
                    ClicksToEdit="1"
                    TrackMouseOver="true"
                    AutoExpandColumn="CompanyName">
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns> 
                            <ext:Column ColumnID="OrderID" DataIndex="OrderID" Header="ID" />
                            <ext:Column ColumnID="CompanyName" DataIndex="CompanyName" Header="Company" />
                            <ext:Column ColumnID="Salesperson" DataIndex="Salesperson" Header="Salesperson" />
                            <ext:DateColumn ColumnID="OrderDate" DataIndex="OrderDate" Header="Order Date" Format="yyyy-MM-dd" />
                            <ext:DateColumn ColumnID="ShippedDate" DataIndex="ShippedDate" Header="Ship Date" Format="yyyy-MM-dd" />
                            <ext:Column ColumnID="Freight" DataIndex="Freight" Header="Shipping">
                                <Renderer Format="UsMoney" />
                            </ext:Column>
                            <ext:Column ColumnID="Total" DataIndex="Total" Header="Total">
                                <Renderer Format="UsMoney" />
                            </ext:Column>
                            <ext:CommandColumn Width="30">
                                <Commands>
                                    <ext:GridCommand CommandName="view" Icon="ApplicationFormEdit">
                                        <ToolTip Text="Show order details" />
                                    </ext:GridCommand>
                                </Commands>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel runat="server" SingleSelect="true" />
                    </SelectionModel>
                    <BottomBar>
                        <ext:PagingToolbar runat="server" StoreID="dsOrders" PageSize="15" />
                    </BottomBar>
                    <LoadMask ShowMask="true" />
                    <Listeners>
                        <Command Fn="commandHandler" />
                    </Listeners>
                </ext:GridPanel>
        </Items>
    </ext:ViewPort>
    
    <ext:Window 
        ID="OrderDetailsWindow" 
        runat="server" 
        Icon="ApplicationFormEdit" 
        Width="800" 
        Height="600" 
        Hidden="true" 
        Modal="true"
        Constrain="true">
        <AutoLoad 
            Url="/Order/OrderDetails/" 
            Mode="IFrame" 
            TriggerEvent="show" 
            ReloadOnEvent="true" 
            ShowMask="true" 
            MaskMsg="Loading order...">
            <Params>
                <ext:Parameter Name="orderID" Value="" Mode="Value" />
            </Params>
        </AutoLoad>
        <Buttons>
            <ext:Button runat="server" Text="Close">
                <Listeners>
                    <Click Handler="#{OrderDetailsWindow}.hide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
</body>
</html>
