<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Complex BorderLayout - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <h1>Complex BorderLayout in Markup</h1>
    
    <ext:Button 
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
        Title="Complex Layout"
        Icon="Application"
        Width="640" 
        Height="480" 
        Plain="true"
        Border="false"
        Collapsible="true"
        BodyBorder="false"
        AnimateTarget="Button1">
        <Items>
            <ext:BorderLayout runat="server">
                <West MinWidth="175" MaxWidth="400" Split="true" Collapsible="true">
                    <ext:Panel 
                        ID="WestPanel" 
                        runat="server" 
                        Title="West"
                        Width="175"
                        Layout="Accordion">
                        <Items>
                            <ext:Panel 
                                ID="Navigation" 
                                runat="server" 
                                Title="Navigation" 
                                Icon="FolderGo"
                                Border="false" 
                                Padding="6"
                                Html="West"
                                />
                            <ext:Panel 
                                ID="Settings" 
                                runat="server" 
                                Title="Settings" 
                                Icon="FolderWrench"
                                Border="false" 
                                Padding="6" 
                                Collapsed="True"
                                Html="Some settings in here."
                                />
                        </Items>
                    </ext:Panel>
                </West>
                <Center>
                    <ext:TabPanel 
                        ID="CenterPanel" 
                        runat="server" 
                        ActiveTabIndex="1">
                        <Items>
                            <ext:Panel 
                                ID="Tab1" 
                                runat="server" 
                                Title="Close Me" 
                                Closable="true" 
                                Border="false" 
                                Padding="6"
                                Html="Hello"
                                />
                            <ext:Panel 
                                ID="Tab2" 
                                runat="server" 
                                Title="Center" 
                                Border="false" 
                                Padding="6"
                                Html="...World"
                                />
                        </Items>
                    </ext:TabPanel>
                </Center>
                <East Collapsible="true" Split="true" MinWidth="225">
                    <ext:Panel ID="EastPanel" runat="server" Width="225" Title="East" Layout="Fit">
                        <Items>
                            <ext:TabPanel 
                                runat="server" 
                                ActiveTabIndex="0" 
                                TabPosition="Bottom" 
                                Border="false" ID="ctl71" Title="ctl71">
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
                </East>
                <South Split="true" Collapsible="true">
                    <ext:Panel 
                        ID="SouthPanel" 
                        runat="server"
                        Title="South" 
                        Height="150"
                        Padding="6" 
                        />
                </South>
            </ext:BorderLayout>
        </Items>
    </ext:Window>
</body>
</html>