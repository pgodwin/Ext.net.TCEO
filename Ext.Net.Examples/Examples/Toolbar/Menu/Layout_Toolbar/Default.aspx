<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Layout Toolbar - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <h3>Vertical Flat Toolbar</h3>
    
    <ext:Toolbar ID="Toolbar1" runat="server" Layout="Container" Width="25" Flat="true">
        <Items>
            <ext:Button ID="Button1" runat="server" Icon="Accept" />
            <ext:Button ID="Button2" runat="server" Icon="Add" />
            <ext:Button ID="Button3" runat="server" Icon="Application" />
            <ext:Button ID="Button4" runat="server" Icon="Bell" />
            <ext:Button ID="Button5" runat="server" Icon="Bomb" />
        </Items>
    </ext:Toolbar>
    
    <h3>Table Toolbar</h3>
    
    <ext:Panel runat="server" Title="Panel" Height="150" Width="340">
        <TopBar>
            <ext:Toolbar runat="server">
                <Items>
                    <ext:Toolbar runat="server" Width="105" Flat="false">
                        <Defaults>
                            <ext:Parameter Name="width" Value="33" Mode="Raw" />
                        </Defaults>
                        <Items>                            
                            <ext:TableLayout runat="server" Columns="3">
                                <Cells>
                                    <ext:Cell>
                                        <ext:Button runat="server" Text="1" StandOut="true" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button runat="server" Text="2" StandOut="true" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button runat="server" Text="3" StandOut="true" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button runat="server" Text="4" StandOut="true" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button runat="server" Text="5" StandOut="true" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button  runat="server" Text="6" StandOut="true" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button  runat="server" Text="7" StandOut="true" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button  runat="server" Text="8" StandOut="true" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button  runat="server" Text="9" StandOut="true" />
                                    </ext:Cell>
                                </Cells>
                            </ext:TableLayout>            
                        </Items>
                    </ext:Toolbar>
                    
                    <ext:ToolbarSeparator runat="server" />
                    
                    <ext:Toolbar ID="Toolbar2" runat="server" Width="105" Flat="false">
                        <Defaults>
                            <ext:Parameter Name="width" Value="33" Mode="Raw" />
                        </Defaults>
                        <Items>                            
                            <ext:TableLayout ID="TableLayout1" runat="server" Columns="3">
                                <Cells>
                                    <ext:Cell>
                                        <ext:Button runat="server" Text="1" StandOut="true" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button runat="server" Text="2" StandOut="true" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button runat="server" Text="3" StandOut="true" />
                                    </ext:Cell>
                                     <ext:Cell ColSpan="3">
                                        <ext:Button runat="server" Text="4" StandOut="true" Width="99" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button runat="server" Text="5" StandOut="true" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button runat="server" Text="6" StandOut="true" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button runat="server" Text="7" StandOut="true" />
                                    </ext:Cell>                                    
                                </Cells>
                            </ext:TableLayout>            
                        </Items>
                    </ext:Toolbar>
                    
                    <ext:ToolbarSeparator runat="server" />
                    
                    <ext:Toolbar runat="server" Width="105" Flat="false">
                        <Defaults>
                            <ext:Parameter Name="width" Value="99" Mode="Raw" />
                        </Defaults>
                        <Items>                            
                            <ext:TableLayout runat="server" Columns="1">
                                <Cells>
                                    <ext:Cell>
                                        <ext:Button runat="server" Text="1" Icon="BulletTick" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button runat="server" Text="2" Icon="BulletTick" />
                                    </ext:Cell>
                                     <ext:Cell>
                                        <ext:Button runat="server" Text="3" Icon="BulletTick" />
                                    </ext:Cell>                                                                   
                                </Cells>
                            </ext:TableLayout>            
                        </Items>
                    </ext:Toolbar>
                </Items>
            </ext:Toolbar>
        </TopBar>
    </ext:Panel>
    
    <h3>Vertical Toolbar In Panel</h3>
    
    <ext:Panel runat="server" Title="Vertical Toolbar" Width="300" Height="150">
        <Items>
            <ext:ColumnLayout runat="server" FitHeight="true">
                <Columns>
                    <ext:LayoutColumn>
                        <ext:Panel 
                            runat="server" 
                            Width="27" 
                            Border="false" 
                            StyleSpec="background-color:#d0def0;padding-left:2px;" 
                            BodyStyle="background-color:#d0def0;">
                            <TopBar>
                                <ext:Toolbar runat="server" Layout="Container" Flat="true">
                                    <Items>
                                        <ext:Button runat="server" Icon="Accept" />
                                        <ext:Button runat="server" Icon="Add" />
                                        <ext:Button runat="server" Icon="Application" />
                                        <ext:Button runat="server" Icon="Bell" />
                                        <ext:Button runat="server" Icon="Bomb" />
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                        </ext:Panel>
                    </ext:LayoutColumn>
                    
                    <ext:LayoutColumn ColumnWidth="1">
                        <ext:Panel runat="server" Border="false" Padding="6" Html="Your Content" />
                    </ext:LayoutColumn>
                </Columns>
            </ext:ColumnLayout>
        </Items>
    </ext:Panel>
    
    <h3>Multiple Toolbars</h3>
    
    <ext:Panel runat="server" Title="Panel" Width="300" Height="150">
        <TopBar>
            <ext:Toolbar runat="server" Layout="Container">
                <Items>
                    <ext:Toolbar runat="server" Flat="false">
                        <Items>
                            <ext:Button runat="server" Icon="Accept" />
                            <ext:Button runat="server" Icon="Add" />
                            <ext:Button runat="server" Icon="Application" />
                            <ext:Button runat="server" Icon="Bell" />
                            <ext:Button runat="server" Icon="Bomb" />
                        </Items>
                    </ext:Toolbar>
                    
                    <ext:Toolbar runat="server" Flat="false">
                        <Items>
                            <ext:Button runat="server" Icon="Accept" />
                            <ext:Button runat="server" Icon="Add" />
                            <ext:Button runat="server" Icon="Application" />
                            <ext:Button runat="server" Icon="Bell" />
                            <ext:Button runat="server" Icon="Bomb" />
                        </Items>
                    </ext:Toolbar>
                    
                    <ext:Toolbar runat="server" Flat="false">
                        <Items>
                            <ext:Button runat="server" Icon="Accept" />
                            <ext:Button runat="server" Icon="Add" />
                            <ext:Button runat="server" Icon="Application" />
                            <ext:Button runat="server" Icon="Bell" />
                            <ext:Button runat="server" Icon="Bomb" />
                        </Items>
                    </ext:Toolbar>
                </Items>
            </ext:Toolbar>
        </TopBar>                    
    </ext:Panel>
    
</body>
</html>