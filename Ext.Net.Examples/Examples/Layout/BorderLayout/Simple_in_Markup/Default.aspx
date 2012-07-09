<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple BorderLayout in Markup - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager runat="server" />

    <h1>Simple BorderLayout in Markup</h1>
    
    <ext:Button 
        ID="Button1" 
        runat="server" 
        Text="Show Window" 
        Icon="Application">
        <Listeners>
            <Click Handler="#{Window1}.show();" />
        </Listeners>    
    </ext:Button>
        
    <ext:Window 
        ID="Window1" 
        runat="server" 
        Title="Simple Layout" 
        Icon="Application"
        Width="600" 
        Height="350"
        Border="false" 
        Collapsible="true"
        Plain="true">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <West Collapsible="true" MinWidth="175" Split="true">
                    <ext:Panel runat="server" Width="175" Title="Navigation" />
                </West>
                <Center>
                    <ext:TabPanel runat="server" ActiveTabIndex="0">
                        <Items>
                            <ext:Panel 
                                ID="Tab1" 
                                runat="server" 
                                Title="First Tab" 
                                Padding="6"
                                Html="First Tab"
                                />
                            <ext:Panel 
                                ID="Tab2" 
                                runat="server" 
                                Title="Another Tab" 
                                Padding="6"
                                Html="Another Tab"
                                />
                            <ext:Panel 
                                ID="Tab3" 
                                runat="server" 
                                Title="Closeable Tab" 
                                Closable="true" 
                                Padding="6"
                                Html="Closable Tab"
                                />
                        </Items>
                    </ext:TabPanel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Window>
</body>
</html>