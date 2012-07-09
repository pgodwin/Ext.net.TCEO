<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Image on Collapsed BorderLayout Region - Ext.NET Examples</title>
    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .west-panel .x-layout-collapsed-west{
            background: url(collapsed-west.png) no-repeat center;
        }
        
        .south-panel .x-layout-collapsed-south{
            background: url(collapsed-south.png) no-repeat center;
        }
    </style>
</head>
<body>
    <ext:ResourceManager runat="server" />

    <h1>Image on Collapsed BorderLayout Region</h1>
    
    <ext:Window 
        runat="server" 
        Title="Collapsed Region Image" 
        Icon="Application"
        Width="600" 
        Height="350"
        Border="false"
        Closable="false"
        X="100"
        Y="100"
        Plain="true">
        <Items>
            <ext:BorderLayout runat="server">
                <West Collapsible="true" MinWidth="175" Split="true">
                    <ext:Panel 
                        runat="server"                             
                        Width="175" 
                        CtCls="west-panel"
                        Title="Navigation" 
                        Collapsed="true"
                        Padding="5"
                        Html="Collapse Panel to see image."
                        />
                </West>
                <Center>
                    <ext:Panel runat="server" Title="Center region" />
                </Center>
                <South Collapsible="true" MinHeight="100" Split="true">
                    <ext:Panel 
                        runat="server"                             
                        Height="100" 
                        CtCls="south-panel"
                        Title="Footer"
                        Collapsed="true"
                        />
                </South>                    
            </ext:BorderLayout>
        </Items>
    </ext:Window>
</body>
</html>