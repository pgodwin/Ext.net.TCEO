<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AbsoluteLayout - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager runat="server" />

    <ext:Viewport runat="server" Layout="Absolute">
        <Items>
            <ext:Panel 
                runat="server" 
                Padding="15" 
                Width="200" 
                Height="100" 
                Frame="true" 
                Title="Panel 1" 
                X="50" 
                Y="50" 
                Html="Positioned at x:50, y:50"
                />
            <ext:Panel 
                runat="server" 
                Padding="15" 
                Width="200" 
                Height="100" 
                Frame="true" 
                Title="Panel 2" 
                X="125" 
                Y="125" 
                Html="Positioned at x:125, y:125"
                />
        </Items>
    </ext:Viewport>
</body>
</html>
