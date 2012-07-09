<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HBoxLayout - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        html, body {
            font    : normal 12px verdana;
            margin  : 0;
            padding : 0;
            border  : 0 none;
            background-color : #dfe8f6 !important;
        }
    </style>
    
    <script type="text/javascript">
        var replace = function (panel) {
            var btns = Ext.getCmp("btns");

            Ext.get("hiddenArea").appendChild(btns.remove(0, false).getEl());
            btns.add(panel);

            btns.doLayout();
        };
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:Viewport runat="server" Layout="BorderLayout">
        <Items>
            <ext:Panel 
                ID="btns" 
                runat="server"
                Region="North"
                Split="true"
                MinHeight="40"
                MaxHeight="85"
                Margins="5 5 0 5" 
                BaseCls="x-plain" 
                Height="50" 
                Layout="Fit">
                <Items>
                    <ext:Panel ID="Panel1" runat="server" BaseCls="x-plain">
                        <Content>
                            <p style="padding:10px;color:#556677;">Select a configuration below:</p>
                        </Content>
                    </ext:Panel>
                </Items>
            </ext:Panel>
            <ext:Panel 
                runat="server" 
                Layout="Anchor"
                Region="Center"
                Margins="0 5 5 5">
                <Items>
                    <ext:Panel 
                        runat="server" 
                        BaseCls="x-plain" 
                        AnchorHorizontal="100%"
                        Layout="HBoxLayout">
                        <LayoutConfig>
                            <ext:HBoxLayoutConfig Padding="10" />
                        </LayoutConfig>
                        <Defaults>
                            <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
                            <ext:Parameter Name="toggleGroup" Value="btns" Mode="Value" />
                            <ext:Parameter Name="allowDepress" Value="false" Mode="Raw" />
                        </Defaults>
                        <Items>
                            <ext:Button runat="server" Text="Spaced" OnClientClick="replace(#{pnlSpaced});" />
                            <ext:Button runat="server" Text="Align: Top" OnClientClick="replace(#{pnlAlignTop});" />
                            <ext:Button runat="server" Text="Align: Middle" OnClientClick="replace(#{pnlAlignMiddle});" />
                            <ext:Button runat="server" Text="Align: Stretch" OnClientClick="replace(#{pnlAlignStretch});" />
                            <ext:Button runat="server" Text="Align: StretchMax" OnClientClick="replace(#{pnlAlignStretchMax});" />
                        </Items>
                    </ext:Panel>
                    <ext:Panel 
                        runat="server" 
                        BaseCls="x-plain" 
                        Layout="HBoxLayout"
                        AnchorHorizontal="100%">
                        <Defaults>
                            <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
                            <ext:Parameter Name="pressed" Value="false" Mode="Raw" />
                            <ext:Parameter Name="toggleGroup" Value="btns" Mode="Value" />
                            <ext:Parameter Name="allowDepress" Value="false" Mode="Raw" />
                        </Defaults>
                        <LayoutConfig>
                            <ext:HBoxLayoutConfig Padding="0 10 10" />
                        </LayoutConfig>
                        <Items>
                            <ext:Button runat="server" Text="Flex: All Even" OnClientClick="replace(#{pnlFlexEven});" />
                            <ext:Button runat="server" Text="Flex: Ratio" OnClientClick="replace(#{pnlFlexRatio});" />
                            <ext:Button runat="server" Text="Pack: Start" OnClientClick="replace(#{pnlPackStart});" />
                            <ext:Button runat="server" Text="Pack: Center" OnClientClick="replace(#{pnlPackCenter});" />
                            <ext:Button runat="server" Text="Pack: End" OnClientClick="replace(#{pnlPackEnd});" />
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    
    <div id="hiddenArea" class="x-hidden">
        <ext:Panel 
            ID="pnlSpaced" 
            runat="server"
            Layout="HBoxLayout">
            <Defaults>
                <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
            </Defaults>
            <LayoutConfig>
                <ext:HBoxLayoutConfig Padding="5" Align="Top" />
            </LayoutConfig>
            <Items>
                <ext:Button runat="server" Text="Button 1" />
                <ext:Panel runat="server" BaseCls="x-plain" Flex="1" />
                <ext:Button runat="server" Text="Button 2" />
                <ext:Button runat="server" Text="Button 3" />
                <ext:Button runat="server" Text="Button 4" Margins="0" />
            </Items>
        </ext:Panel>
        
        <ext:Panel 
            ID="pnlAlignTop" 
            runat="server"
            Layout="HBoxLayout">
            <Defaults>
                <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
            </Defaults>
            <LayoutConfig>
                <ext:HBoxLayoutConfig Padding="5" Align="Top" />
            </LayoutConfig>
            <Items>
                <ext:Button runat="server" Text="Button 1" />
                <ext:Button runat="server" Text="Button 2" />
                <ext:Button runat="server" Text="Button 3" />
                <ext:Button runat="server" Text="Button 4" />
            </Items>
        </ext:Panel>
        
        <ext:Panel 
            ID="pnlAlignMiddle" 
            runat="server"
            Layout="HBoxLayout">
            <Defaults>
                <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
            </Defaults>
            <LayoutConfig>
                <ext:HBoxLayoutConfig Padding="5" Align="Middle" />
            </LayoutConfig>
            <Items>
                <ext:Button runat="server" Text="Button 1" />
                <ext:Button runat="server" Text="Button 2" />
                <ext:Button runat="server" Text="Button 3" />
                <ext:Button runat="server" Text="Button 4" />
            </Items>
        </ext:Panel>
        
        <ext:Panel 
            ID="pnlAlignStretch" 
            runat="server"
            Layout="HBoxLayout">
            <Defaults>
                <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
            </Defaults>
            <LayoutConfig>
                <ext:HBoxLayoutConfig Padding="5" Align="Stretch" />
            </LayoutConfig>
            <Items>
                <ext:Button runat="server" Text="Button 1" />
                <ext:Button runat="server" Text="Button 2" />
                <ext:Button runat="server" Text="Button 3" />
                <ext:Button runat="server" Text="Button 4" />
            </Items>
        </ext:Panel>
        
        <ext:Panel 
            ID="pnlAlignStretchMax" 
            runat="server"
            Layout="HBoxLayout">
            <Defaults>
                <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
            </Defaults>
            <LayoutConfig>
                <ext:HBoxLayoutConfig Padding="5" Align="StretchMax" />
            </LayoutConfig>
            <Items>
                <ext:Button runat="server" Text="Button 1 - height 30px" Height="30" />
                <ext:Button runat="server" Text="Button 2" />
                <ext:Button runat="server" Text="Button 3" />
                <ext:Button runat="server" Text="Button 4" />
            </Items>
        </ext:Panel>
        
        <ext:Panel 
            ID="pnlFlexEven" 
            runat="server"
            Layout="HBoxLayout">
            <Defaults>
                <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
            </Defaults>
            <LayoutConfig>
                <ext:HBoxLayoutConfig Padding="5" Align="Middle" />
            </LayoutConfig>
            <Items>
                <ext:Button runat="server" Text="Button 1" Flex="1" />
                <ext:Button runat="server" Text="Button 2" Flex="1" />
                <ext:Button runat="server" Text="Button 3" Flex="1" />
                <ext:Button runat="server" Text="Button 4" Flex="1" Margins="0" />
            </Items>
        </ext:Panel>
        
        <ext:Panel 
            ID="pnlFlexRatio" 
            runat="server"
            Layout="HBoxLayout">
            <Defaults>
                <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
            </Defaults>
            <LayoutConfig>
                <ext:HBoxLayoutConfig Padding="5" Align="Middle" />
            </LayoutConfig>
            <Items>
                <ext:Button runat="server" Text="Button 1" Flex="1" />
                <ext:Button runat="server" Text="Button 2" Flex="1" />
                <ext:Button runat="server" Text="Button 3" Flex="1" />
                <ext:Button runat="server" Text="Button 4" Flex="3" Margins="0" />
            </Items>
        </ext:Panel>
        
        <ext:Panel 
            ID="pnlPackStart" 
            runat="server"
            Layout="HBoxLayout">
            <Defaults>
                <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
            </Defaults>
            <LayoutConfig>
                <ext:HBoxLayoutConfig Padding="5" Align="Middle" Pack="Start" />
            </LayoutConfig>
            <Items>
                <ext:Button runat="server" Text="Button 1" />
                <ext:Button runat="server" Text="Button 2" />
                <ext:Button runat="server" Text="Button 3" />
                <ext:Button runat="server" Text="Button 4" />
            </Items>
        </ext:Panel>
        
        <ext:Panel 
            ID="pnlPackCenter" 
            runat="server"
            Layout="HBoxLayout">
            <Defaults>
                <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
            </Defaults>
            <LayoutConfig>
                <ext:HBoxLayoutConfig Padding="5" Align="Middle" Pack="Center" />
            </LayoutConfig>
            <Items>
                <ext:Button runat="server" Text="Button 1" />
                <ext:Button runat="server" Text="Button 2" />
                <ext:Button runat="server" Text="Button 3" />
                <ext:Button runat="server" Text="Button 4" />
            </Items>
        </ext:Panel>
        
        <ext:Panel 
            ID="pnlPackEnd" 
            runat="server"
            Layout="HBoxLayout">
            <Defaults>
                <ext:Parameter Name="margins" Value="0 5 0 0" Mode="Value" />
            </Defaults>
            <LayoutConfig>
                <ext:HBoxLayoutConfig Padding="5" Align="Middle" Pack="End" />
            </LayoutConfig>
            <Items>
                <ext:Button runat="server" Text="Button 1" />
                <ext:Button runat="server" Text="Button 2" />
                <ext:Button runat="server" Text="Button 3" />
                <ext:Button runat="server" Text="Button 4" />
            </Items>
        </ext:Panel>
    </div>
</body>
</html>
