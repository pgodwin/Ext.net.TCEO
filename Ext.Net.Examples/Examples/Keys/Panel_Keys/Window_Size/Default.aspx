<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:Window ID="Window1" runat="server" Width="400" Height="300" Title="Move/Resize Window" Padding="6">
        <Content>
            <ul>
                <li>MOVE: Alt+LEFT/RIGHT/UP/DOWN</li>
                <li>RESIZE: Ctrl+LEFT/RIGHT/UP/DOWN</li>
            </ul>
        </Content>
        
        <KeyMap>
            <%--SIZE CHANGING--%>
            <ext:KeyBinding Ctrl="true">
                <Keys>
                    <ext:Key Code="RIGHT" />
                </Keys>
                <Listeners>
                    <Event Handler="#{Window1}.setWidth(#{Window1}.getSize().width+10);" />
                </Listeners>
            </ext:KeyBinding>
            
            <ext:KeyBinding Ctrl="true">
                <Keys>
                    <ext:Key Code="LEFT" />
                </Keys>
                <Listeners>
                    <Event Handler="#{Window1}.setWidth(#{Window1}.getSize().width-10);" />
                </Listeners>
            </ext:KeyBinding>
            
            <ext:KeyBinding Ctrl="true">
                <Keys>
                    <ext:Key Code="UP" />
                </Keys>
                <Listeners>
                    <Event Handler="#{Window1}.setHeight(#{Window1}.getSize().height-10);" />
                </Listeners>
            </ext:KeyBinding>
            
            <ext:KeyBinding Ctrl="true">
                <Keys>
                    <ext:Key Code="DOWN" />
                </Keys>
                <Listeners>
                    <Event Handler="#{Window1}.setHeight(#{Window1}.getSize().height+10);" />
                </Listeners>
            </ext:KeyBinding>
            
            <%--POSITION CHANGING--%>
            <ext:KeyBinding Alt="true">
                <Keys>
                    <ext:Key Code="RIGHT" />
                </Keys>
                <Listeners>
                    <Event Handler="#{Window1}.setPosition(#{Window1}.getPosition(false)[0]+10);" />
                </Listeners>
            </ext:KeyBinding>
            
            <ext:KeyBinding Alt="true">
                <Keys>
                    <ext:Key Code="LEFT" />
                </Keys>
                <Listeners>
                    <Event Handler="#{Window1}.setPosition(#{Window1}.getPosition(false)[0]-10);" />
                </Listeners>
            </ext:KeyBinding>
            
            <ext:KeyBinding Alt="true">
                <Keys>
                    <ext:Key Code="UP" />
                </Keys>
                <Listeners>
                    <Event Handler="#{Window1}.setPosition(undefined, #{Window1}.getPosition(false)[1]-10);" />
                </Listeners>
            </ext:KeyBinding>
            
            <ext:KeyBinding Alt="true">
                <Keys>
                    <ext:Key Code="DOWN" />
                </Keys>
                <Listeners>
                    <Event Handler="#{Window1}.setPosition(undefined, #{Window1}.getPosition()[1]+10);" />
                </Listeners>
            </ext:KeyBinding>
        </KeyMap>
    </ext:Window>
</body>
</html>
