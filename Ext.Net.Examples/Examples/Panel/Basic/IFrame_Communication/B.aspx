<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ScriptManager1" runat="server" />
        
        <ext:TextField ID="TextField1" runat="server" />
        <ext:Button ID="Button1" runat="server" Text="To the A" Icon="ArrowLeft">
            <Listeners>
                <Click Handler="parent.Panel1.getBody().TextField1.setValue(TextField1.getValue());" />
            </Listeners>
        </ext:Button>
    </form>
</body>
</html>