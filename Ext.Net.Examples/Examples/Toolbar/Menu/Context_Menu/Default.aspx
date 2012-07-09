<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Example</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" /> 

    <script type="text/javascript">
        var setColor = function (menu, color) {
            var cmp;

            if (menu.lastTargetIn(Panel1)) {
                cmp = Panel1;
            } else if (menu.lastTargetIn(Panel2)) {
                cmp = Panel2;
            }
            
            cmp.body.applyStyles(String.format('background-color:#{0}', color));
        }
    </script>
</head>
<body style="padding:10px;">
    <form runat="server">
        <ext:ResourceManager ID="resourceManager2" runat="server" />
        
        <ext:ColorMenu ID="ColorMenu1" runat="server">
            <Listeners>
                <Select Handler="setColor(#{ColorMenu1}, color);" />
            </Listeners>
        </ext:ColorMenu>
        
        <ext:Panel 
            ID="Panel1" 
            runat="server" 
            Height="200"
            Title="Right-Click on this Panel"
            ContextMenuID="ColorMenu1"
            />
        
        <ext:Panel 
            ID="Panel2" 
            runat="server" 
            Height="200"
            Title="Right-Click on this Panel too!"
            ContextMenuID="ColorMenu1"
            />
            
        <asp:Button runat="server" Text="Postback" />
        
    </form>
</body>
</html>