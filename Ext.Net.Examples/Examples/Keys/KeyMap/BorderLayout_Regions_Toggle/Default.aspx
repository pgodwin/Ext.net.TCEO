<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KeyMap Toggling BorderLayout Regions - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <ext:ResourceManager runat="server" />
        
    <ext:Viewport runat="server" Layout="border">
        <Items>
            <ext:Panel ID="North" runat="server" Title="North" Region="North" Frame="true" Height="200" Collapsible="true" />
            <ext:Panel ID="West" runat="server" Title="West" Region="West" Frame="true" Width="200" Collapsible="true" />
            <ext:Panel runat="server" Region="Center" Border="true" Padding="5">
                <Content>
                    <ul>
                        <li>If keys are not working then click on center area</li>
                        <li>NORTH toggle: N</li>
                        <li>WEST toggle: W</li>
                        <li>EAST toggle: E</li>
                        <li>SOUTH toggle: S</li>
                    </ul>
                </Content>
            </ext:Panel>
            <ext:Panel ID="East" runat="server" Title="East" Region="East" Frame="true" Width="200" Collapsible="true" />
            <ext:Panel ID="South" runat="server" Title="South" Region="South" Frame="true" Height="200" Collapsible="true" />
        </Items>
    </ext:Viewport>
    
    <ext:KeyMap runat="server" Target="={Ext.isGecko ? Ext.getDoc() : Ext.getBody()}">
        <ext:KeyBinding>
            <Keys>
                <ext:Key Code="N" />
            </Keys>
            <Listeners>
                <Event Handler="#{North}.toggleCollapse();" />
            </Listeners>
        </ext:KeyBinding>    
        
        <ext:KeyBinding>
            <Keys>
                <ext:Key Code="W" />
            </Keys>
            <Listeners>
                <Event Handler="#{West}.toggleCollapse();" />
            </Listeners>
        </ext:KeyBinding>
        
        <ext:KeyBinding>
            <Keys>
                <ext:Key Code="E" />
            </Keys>
            <Listeners>
                <Event Handler="#{East}.toggleCollapse();" />
            </Listeners>
        </ext:KeyBinding>
        
        <ext:KeyBinding>
            <Keys>
                <ext:Key Code="S" />
            </Keys>
            <Listeners>
                <Event Handler="#{South}.toggleCollapse();" />
            </Listeners>
        </ext:KeyBinding>
    </ext:KeyMap>
</body>
</html>
