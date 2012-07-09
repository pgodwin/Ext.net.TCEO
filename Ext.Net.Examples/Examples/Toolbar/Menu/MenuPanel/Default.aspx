<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MenuPanel - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var menuItemClick = function (item) {
            pnlCenter.body.update(String.format("Clicked: {0}", item.text)).highlight();       
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" IDMode="Explicit" />

        <h1>MenuPanel Example</h1>        
        
        <ext:Window 
            runat="server" 
            Title="MenuPanel" 
            Closable="false" 
            Width="600" 
            Height="370"
            Layout="border">
            <Items>
                <ext:Panel 
                    runat="server" 
                    Width="350" 
                    Layout="Accordion" 
                    Split="true" 
                    Region="West" 
                    Margins="5 0 5 5" 
                    DefaultBorder="false">
                    <Items>
                        <ext:MenuPanel 
                            runat="server" 
                            Title="MenuPanel with Selection Saving" 
                            Icon="ArrowSwitch">
                            <Menu runat="server">
                                <Items>
                                    <ext:MenuItem runat="server" Text="Item 1" Icon="ArrowRight" />
                                    <ext:MenuItem runat="server" Text="Item 2" Icon="ArrowRight" />
                                    <ext:MenuItem runat="server" Text="Item 3" Icon="ArrowRight" />
                                </Items>
                                <Listeners>
                                    <ItemClick Fn="menuItemClick" />
                                </Listeners>                                            
                            </Menu>                                        
                        </ext:MenuPanel>
                        <ext:MenuPanel 
                            runat="server" 
                            Title="MenuPanel without Selection Saving" 
                            SaveSelection="false" 
                            Icon="ArrowSwitch">
                            <Menu runat="server">
                                <Items>
                                    <ext:MenuItem runat="server" Text="Item 1" Icon="ArrowRight" />
                                    <ext:MenuItem runat="server" Text="Item 2" Icon="ArrowRight" />
                                    <ext:MenuItem runat="server" Text="Item 3" Icon="ArrowRight" />
                                </Items>
                                <Listeners>
                                    <ItemClick Fn="menuItemClick" />
                                </Listeners>
                            </Menu>
                        </ext:MenuPanel>
                        <ext:MenuPanel 
                            runat="server" 
                            Title="Menu with Predefined Selection" 
                            SelectedIndex="1" 
                            Icon="ArrowSwitch">
                            <Menu runat="server">
                                <Items>
                                    <ext:MenuItem runat="server" Text="Item 1" Icon="ArrowRight" />
                                    <ext:MenuItem runat="server" Text="Item 2" Icon="ArrowRight" />
                                    <ext:MenuItem runat="server" Text="Item 3" Icon="ArrowRight" />
                                </Items>
                                <Listeners>
                                    <ItemClick Fn="menuItemClick" />
                                </Listeners>
                            </Menu>
                        </ext:MenuPanel>
                    </Items>
                </ext:Panel>
                <ext:Panel 
                    ID="pnlCenter" 
                    runat="server" 
                    Title="Selected Item" 
                    Padding="5" 
                    Region="Center" 
                    Margins="5 5 5 0" 
                    />
            </Items>
        </ext:Window>
    </form>
</body>
</html>