<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:TextField ID="TextField1" runat="server" />
        
        <ext:Button runat="server" Text="To the B" Icon="ArrowRight">
            <Listeners>
                <Click Handler="parent.Panel2.getBody().TextField1.setValue(TextField1.getValue());" />
            </Listeners>
        </ext:Button>
    </form>
</body>
</html>