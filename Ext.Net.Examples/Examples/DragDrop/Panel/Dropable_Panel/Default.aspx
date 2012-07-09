<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Draggable Panel - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .invite {
            background-color: #99bbe8 !important;
        }
        
        .x-drop-marker {
            background-color: silver;            
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:ViewPort ID="ViewPort1" runat="server">
            <Items>
                <ext:BorderLayout runat="server">
                    <North MarginsSummary="10 10 5 10">
                         <ext:Container ID="North" runat="server" Cls="dropable" Layout="Fit" Height="100" />
                    </North>
                    
                    <East MarginsSummary="5 10 5 10">
                         <ext:Container ID="EastRegion" runat="server" Cls="dropable" Layout="Fit" Width="200" />
                    </East>
                    
                    <West MarginsSummary="5 10 5 10">
                        <ext:Container ID="WestRegion" runat="server" Cls="dropable" Layout="Fit" Width="200" />
                    </West>
                    
                    <South MarginsSummary="5 10 10 10">
                        <ext:Container ID="SouthtRegion" runat="server" Cls="dropable" Layout="Fit" Height="100" />
                    </South>
                    
                    <Center MarginsSummary="5 0 5 0">
                        <ext:Container ID="CenterRegion" runat="server" Cls="dropable" Layout="Fit">
                            <Items>
                                <ext:Panel 
                                    runat="server" 
                                    Title="Drag me" 
                                    Icon="ArrowNsew">
                                    <DraggableConfig runat="server" Group="panelDD">
                                        <StartDrag Handler="Ext.select('.dropable').addClass('x-drop-marker');" />
                                        <EndDrag Handler="Ext.select('.dropable').removeClass('x-drop-marker');" />
                                    </DraggableConfig>
                                </ext:Panel>
                            </Items>
                        </ext:Container>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:ViewPort>
        
        <ext:DropTarget runat="server" Target="${.dropable}" Group="panelDD" OverClass="invite">
            <NotifyDrop Handler="var cmp = Ext.getCmp(this.el.dom.id);cmp.add(data.panel);cmp.doLayout.defer(10,cmp);" />    
            <NotifyOver Handler="Ext.select('.dropable').removeClass('invite'); this.el.addClass('invite');" />        
        </ext:DropTarget>
    </form>    
</body>
</html>
