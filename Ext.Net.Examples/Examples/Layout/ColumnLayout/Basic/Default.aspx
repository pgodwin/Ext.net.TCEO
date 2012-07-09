<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Column Layout - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    
    <ext:Viewport ID="ViewPort1" runat="server">
        <Items>
            <ext:ColumnLayout ID="ColumnLayout1" runat="server" Split="true" FitHeight="true">
                <Columns>
                    <ext:LayoutColumn ColumnWidth="0.25">
                        <ext:Panel runat="server" Title="Width=0.25" Html="This is some content." />
                    </ext:LayoutColumn>
                    
                    <ext:LayoutColumn ColumnWidth="0.75">
                        <ext:Panel ID="Panel2" runat="server" Title="Width=0.75" Html="This is some content." />
                    </ext:LayoutColumn>
                    
                    <ext:LayoutColumn>
                        <ext:Panel ID="Panel3" runat="server" Title="Width=250px" Width="250" Html="This is some content." />
                    </ext:LayoutColumn>
                </Columns>
            </ext:ColumnLayout>
        </Items>
    </ext:Viewport>
</body>
</html>