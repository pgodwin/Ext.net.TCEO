<%@ Page Language="C#" %>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Draggable Panel - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var onDrag = function (e) {
            var pel = this.proxy.getEl();
            this.x = pel.getLeft(true);
            this.y = pel.getTop(true);

            var s = this.panel.getEl().shadow;
            
            if (s) {
                s.realign(this.x, this.y, pel.getWidth(), pel.getHeight());
            }
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:Panel 
            runat="server" 
            Title="Drag Me" 
            Icon="ArrowNsew"
            StyleSpec="position:absolute;"
            Frame="true" 
            Width="150" 
            Height="150" 
            Floating="true" 
            X="50"
            Y="50">
            <DraggableConfig runat="server">
                <OnDrag Fn="onDrag" />
                <EndDrag Handler="this.panel.setPosition(this.x, this.y);" />
                <CustomConfig>
                    <ext:ConfigItem Name="insertProxy" Value="false" Mode="Raw" />
                </CustomConfig>
            </DraggableConfig>
        </ext:Panel>
        
        <ext:Panel 
            runat="server" 
            Title="Drag Me Too" 
            Icon="ArrowNsew"
            StyleSpec="position:absolute;"
            Frame="true" 
            Width="150" 
            Height="150" 
            Floating="true" 
            X="100"
            Y="100">
            <DraggableConfig runat="server">
                <OnDrag Fn="onDrag" />
                <EndDrag Handler="this.panel.setPosition(this.x, this.y);" />
                <CustomConfig>
                    <ext:ConfigItem Name="insertProxy" Value="false" Mode="Raw" />
                </CustomConfig>
            </DraggableConfig>
        </ext:Panel>
    </form>
</body>
</html>
