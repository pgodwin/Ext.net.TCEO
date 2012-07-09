<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu Layout - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .white-menu .x-menu {
            background:white !important;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Menu layout</h1>
        
        <ext:Toolbar runat="server">
            <Items>
                <ext:Button runat="server" Text="Home" />
                
                <ext:Button runat="server" Text="Products">
                    <Menu>
                        <ext:Menu runat="server" ShowSeparator="false">
                            <Items>
                                <ext:ComponentMenuItem runat="server" Shift="false">
                                    <Component>
                                        <ext:Container runat="server" Width="600" Height="200" Layout="HBox">
                                            <Items>
                                                <ext:MenuPanel runat="server" Flex="1" Title="Desktop" Margins="0 5 0 0" Cls="white-menu">
                                                    <Menu runat="server" ShowSeparator="false">
                                                        <Items>
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                        </Items>
                                                    </Menu>
                                                </ext:MenuPanel>
                                                
                                                <ext:MenuPanel runat="server" Flex="1" Title="Laptop" Margins="0 5 0 0" Cls="white-menu">
                                                    <Menu runat="server" ShowSeparator="false">
                                                        <Items>
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                        </Items>
                                                    </Menu>
                                                </ext:MenuPanel>
                                                
                                                <ext:MenuPanel runat="server" Flex="1" Title="Accessories" Margins="0 5 0 0" Cls="white-menu">
                                                    <Menu runat="server" ShowSeparator="false">
                                                        <Items>
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                        </Items>
                                                    </Menu>
                                                </ext:MenuPanel>
                                                
                                                <ext:MenuPanel runat="server" Flex="1" Title="Accessories" Cls="white-menu">
                                                    <Menu runat="server" ShowSeparator="false">
                                                        <Items>
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                            <ext:MenuItem runat="server" Text="Navigation Link" />
                                                        </Items>
                                                    </Menu>
                                                </ext:MenuPanel>
                                            </Items>
                                        </ext:Container>
                                    </Component>
                                </ext:ComponentMenuItem>
                            </Items>
                        </ext:Menu>
                    </Menu>
                </ext:Button>
                
                <ext:Button runat="server" Text="Sales Items">
                    <Menu>
                        <ext:Menu runat="server" ShowSeparator="false">
                            <Items>
                                <ext:ComponentMenuItem runat="server" Shift="false">
                                    <Component>
                                        <ext:Container runat="server" Width="400" Height="410" Layout="VBox">
                                            <LayoutConfig>
                                                <ext:VBoxLayoutConfig Align="Stretch" />
                                            </LayoutConfig>
                                            <Items>
                                                <ext:Container runat="server" Flex="1" Layout="Hbox" Margins="0 0 5 0">
                                                    <Items>
                                                        <ext:MenuPanel runat="server" Flex="1" Title="Deal of the week" Margins="0 5 0 0" Cls="white-menu">
                                                            <Menu runat="server" ShowSeparator="false">
                                                                <Items>
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                </Items>
                                                            </Menu>
                                                        </ext:MenuPanel>
                                                        
                                                        <ext:MenuPanel runat="server" Flex="1" Title="Clearance items" Cls="white-menu">
                                                            <Menu runat="server" ShowSeparator="false">
                                                                <Items>
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                </Items>
                                                            </Menu>
                                                        </ext:MenuPanel>
                                                    </Items>
                                                </ext:Container>
                                                
                                                <ext:Container runat="server" Flex="1" Layout="Hbox">
                                                    <Items>
                                                        <ext:MenuPanel runat="server" Flex="1" Title="Deal of the week" Margins="0 5 0 0" Cls="white-menu">
                                                            <Menu runat="server" ShowSeparator="false">
                                                                <Items>
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                </Items>
                                                            </Menu>
                                                        </ext:MenuPanel>
                                                        
                                                        <ext:MenuPanel runat="server" Flex="1" Title="Clearance items" Margins="0 5 0 0" Cls="white-menu">
                                                            <Menu runat="server" ShowSeparator="false">
                                                                <Items>
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                </Items>
                                                            </Menu>
                                                        </ext:MenuPanel>
                                                        
                                                        <ext:MenuPanel runat="server" Flex="1" Title="Open Box Items" Cls="white-menu">
                                                            <Menu runat="server" ShowSeparator="false">
                                                                <Items>
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                    <ext:MenuItem runat="server" Text="Navigation Link" />
                                                                </Items>
                                                            </Menu>
                                                        </ext:MenuPanel>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                    </Component>
                                </ext:ComponentMenuItem>
                            </Items>
                        </ext:Menu>
                    </Menu>
                </ext:Button>
            </Items>
        </ext:Toolbar>
    </form>
</body>
</html>
