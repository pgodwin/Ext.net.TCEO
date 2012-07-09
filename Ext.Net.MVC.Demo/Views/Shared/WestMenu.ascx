<%@ Control Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<ext:AccordionLayout runat="server" Animate="true">
    <Items>
        <ext:MenuPanel 
            ID="acReports" 
            runat="server" 
            Border="false" 
            SaveSelection="false"
            Cls="white-menu" 
            Collapsed="true" 
            Title="Reports">
            <Menu runat="server">
                <Items>
                    <ext:MenuItem 
                        ID="mnCustomerAddressBook" 
                        runat="server" 
                        Text="Customer Address Book"
                        Icon="Report">
                        <CustomConfig>
                            <ext:ConfigItem Name="url" Value="/Report/CustomerAddressBook/" Mode="Value" />
                        </CustomConfig>
                    </ext:MenuItem>
                    <ext:MenuItem 
                        runat="server" 
                        Text="Total Sales By Employee" 
                        Icon="ChartBar">
                        <CustomConfig>
                            <ext:ConfigItem Name="url" Value="/Chart/TotalByEmployee/" Mode="Value" />
                            <ext:ConfigItem Name="passParentSize" Value="true" Mode="Raw" />
                        </CustomConfig>
                    </ext:MenuItem>
                    <ext:MenuItem 
                        runat="server" 
                        Text="Product Sales By Category" 
                        Icon="ChartBar" 
                        Visible="false">
                        <CustomConfig>
                            <ext:ConfigItem Name="url" Value="/Chart/ProductSalesByCategory/" Mode="Value" />
                        </CustomConfig>
                    </ext:MenuItem>
                </Items>
                <Listeners>
                    <ItemClick Handler="Northwind.addTab({ title: menuItem.text, url: menuItem.url, icon: menuItem.iconCls, passParentSize: menuItem.passParentSize});" />
                </Listeners>
            </Menu>
        </ext:MenuPanel>
        <ext:MenuPanel 
            ID="acCustomers" 
            runat="server" 
            Collapsed="true" 
            Title="Customers & Orders"
            Border="false" 
            SaveSelection="false" 
            Cls="white-menu">
            <Menu runat="server">
                <Items>
                    <ext:MenuItem runat="server" Text="Customer Details" Icon="ApplicationForm">
                        <CustomConfig>
                            <ext:ConfigItem Name="url" Value="/Customer/CustomerDetails/" Mode="Value" />
                        </CustomConfig>
                    </ext:MenuItem>
                    <ext:MenuItem ID="mnCustomerList" runat="server" Text="Customer List" Icon="ApplicationForm">
                        <CustomConfig>
                            <ext:ConfigItem Name="url" Value="/Customer/CustomerList/" Mode="Value" />
                        </CustomConfig>
                    </ext:MenuItem>                   
                    <ext:MenuItem ID="mnOrderList" runat="server" Text="Order List" Icon="ApplicationForm">
                        <CustomConfig>
                            <ext:ConfigItem Name="url" Value="/Order/OrderList/" Mode="Value" />
                        </CustomConfig>
                    </ext:MenuItem>
                </Items>
                <Listeners>
                    <ItemClick Handler="Northwind.addTab({ title: menuItem.text, url: menuItem.url, icon: menuItem.iconCls });" />
                </Listeners>
            </Menu>
        </ext:MenuPanel>
        <ext:MenuPanel 
            ID="acExamples" 
            runat="server" 
            Collapsed="true" 
            Title="Examples"
            Border="false" 
            SaveSelection="false" 
            Cls="white-menu">
            <Menu runat="server">
                <Items>
                    <ext:MenuItem ID="mnRest" runat="server" Text="REST Demo" Icon="Application">
                        <CustomConfig>
                            <ext:ConfigItem Name="url" Value="/RestDemo/" Mode="Value" />
                        </CustomConfig>
                    </ext:MenuItem>
                    <ext:MenuItem ID="mnPartial" runat="server" Text="Partial Views" Icon="Application">
                        <CustomConfig>
                            <ext:ConfigItem Name="url" Value="/Partial/" Mode="Value" />
                        </CustomConfig>
                    </ext:MenuItem>                                           
                </Items>
                <Listeners>
                    <ItemClick Handler="Northwind.addTab({ title : menuItem.text, url : menuItem.url, icon : menuItem.iconCls });" />
                </Listeners>
            </Menu>
        </ext:MenuPanel>
    </Items>
</ext:AccordionLayout>
