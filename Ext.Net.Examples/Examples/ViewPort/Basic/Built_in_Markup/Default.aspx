<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Viewport with BorderLayout - Ext.NET Examples</title>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:Viewport runat="server" Layout="border">
        <Items>
            <ext:Panel 
                runat="server"
                Title="North" 
                Region="North"
                Split="true"
                Height="150"
                Padding="6"
                Html="North"
                Collapsible="true"
                />
            <ext:Panel 
                runat="server" 
                Title="West" 
                Region="West"
                Layout="accordion"
                Width="225" 
                MinWidth="225" 
                MaxWidth="400" 
                Split="true" 
                Collapsible="true">
                <Items>
                    <ext:Panel 
                        runat="server" 
                        Title="Navigation" 
                        Border="false" 
                        Padding="6"
                        Icon="FolderGo"
                        Html="West"
                        />
                    <ext:Panel 
                        runat="server" 
                        Title="Settings" 
                        Border="false" 
                        Padding="6"
                        Icon="FolderWrench"
                        Html="Some settings in here"
                        />
                </Items>
            </ext:Panel>
            <ext:TabPanel runat="server" Region="Center">
                <Items>
                    <ext:Panel 
                        runat="server" 
                        Title="Center" 
                        Border="false" 
                        Padding="6"
                        Html="<h1>Viewport with BorderLayout</h1>"
                        />
                    <ext:Panel 
                        runat="server" 
                        Title="Close Me" 
                        Closable="true" 
                        Border="false" 
                        Padding="6"
                        Html="Closeable Tab"
                        />
                </Items>
            </ext:TabPanel>
            <ext:Panel 
                runat="server" 
                Title="East" 
                Region="East"
                Collapsible="true" 
                Split="true" 
                MinWidth="225"
                Width="225" 
                Layout="Fit">
                <Items>
                    <ext:TabPanel 
                        runat="server"
                        ActiveTabIndex="1" 
                        TabPosition="Bottom" 
                        Border="false">
                        <Items>
                            <ext:Panel 
                                runat="server" 
                                Title="Tab 1" 
                                Border="false" 
                                Padding="6"
                                Html="East Tab 1"
                                />
                            <ext:Panel 
                                runat="server" 
                                Title="Tab 2" 
                                Closable="true" 
                                Border="false" 
                                Padding="6"
                                Html="East Tab 2"
                                />
                        </Items>
                    </ext:TabPanel>
                </Items>
            </ext:Panel>
            <ext:Panel 
                runat="server"
                Title="South"
                Region="South"
                Split="true"
                Collapsible="true"
                Height="150"
                Padding="6"
                Html="South"
                />
        </Items>
    </ext:Viewport>
</body>
</html>