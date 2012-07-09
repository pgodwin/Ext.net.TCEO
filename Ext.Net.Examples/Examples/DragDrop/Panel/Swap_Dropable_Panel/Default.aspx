<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Container[] panels = new Container[] { this.North, this.East, this.West, this.South, this.Center };

        foreach (Container region in panels)
        {
            Ext.Net.Panel p = (Ext.Net.Panel)region.Items[0];
            p.DraggableConfig.Group = "panelDD";
            p.DraggableConfig.StartDrag.Fn = "startDrag";
            p.DraggableConfig.EndDrag.Fn = "endDrag";
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Draggable Panels within a Viewport - Ext.NET Examples</title>
    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .invite {
            background-color: #99bbe8 !important;
        }
        
        .x-drop-marker {
            background-color: silver;            
        }
    </style>
    
    <script type="text/javascript">
        var notifyDrop = function (source, e, data) {
            var targetCt = Ext.getCmp(this.el.dom.id),
                targetPanel = targetCt.items.get(0),
                sourceCt = data.panel.ownerCt;                
            
            sourceCt.add(targetPanel);
            targetCt.add(data.panel);            
            targetCt.doLayout.defer(10,targetCt);
            sourceCt.doLayout.defer(10,sourceCt);
        };
        
        var startDrag = function () {
            Ext.select(".dropable").addClass("x-drop-marker");
            Ext.select(".draggable:not(.x-panel-ghost)").hide();
        };
        
        var endDrag = function () {
            Ext.select(".dropable").removeClass("x-drop-marker");
            Ext.select(".draggable").show();
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:ViewPort ID="ViewPort1" runat="server">
            <Items>
                <ext:BorderLayout runat="server">
                    <North MarginsSummary="10 10 5 10">
                         <ext:Container ID="North" runat="server" Cls="dropable" Layout="Fit" Height="100">
                            <Items>
                                <ext:Panel runat="server" Cls="draggable" Title="North" />
                            </Items>
                         </ext:Container>
                    </North>
                    
                    <East MarginsSummary="5 10 5 10">
                         <ext:Container ID="East" runat="server" Cls="dropable" Layout="Fit" Width="200">
                            <Items>
                                <ext:Panel runat="server" Cls="draggable" Title="East" />
                            </Items>
                         </ext:Container>
                    </East>
                    
                    <West MarginsSummary="5 10 5 10">
                        <ext:Container ID="West" runat="server" Cls="dropable" Layout="Fit" Width="200">
                            <Items>
                                <ext:Panel runat="server" Cls="draggable" Title="West" />
                            </Items>
                         </ext:Container>
                    </West>
                    
                    <South MarginsSummary="5 10 10 10">
                        <ext:Container ID="South" runat="server" Cls="dropable" Layout="Fit" Height="100">
                            <Items>
                                <ext:Panel runat="server" Cls="draggable" Title="South" />
                            </Items>
                         </ext:Container>
                    </South>
                    
                    <Center MarginsSummary="5 0 5 0">
                        <ext:Container ID="Center" runat="server" Cls="dropable" Layout="Fit">
                            <Items>
                                <ext:Panel 
                                    runat="server" 
                                    Cls="draggable"
                                    Title="Center" 
                                    Padding="5"
                                    Html="Drag/Drop Panel Headers to a different Viewport Region"
                                    />
                            </Items>
                        </ext:Container>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:ViewPort>
        
        <ext:DropTarget runat="server" Target="${.dropable}" Group="panelDD" OverClass="invite">
            <NotifyDrop Fn="notifyDrop" />    
            <NotifyOut Handler="this.el.removeClass('invite');" />
            <NotifyOver Handler="Ext.select('.dropable').removeClass('invite'); this.el.addClass('invite');" />        
        </ext:DropTarget>
    </form>    
</body>
</html>
