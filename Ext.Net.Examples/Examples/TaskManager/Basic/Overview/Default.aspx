<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void RefreshTime(object sender, DirectEventArgs e)
    {
        this.ServerTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TaskManager with Client and Server Side Events - Ext.NET Examples</title>    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>    
    <form runat="server">
        <ext:ResourceManager runat="server">
            <Listeners>
                <DocumentReady Handler="var msg = function (text) { 
                    #{LogArea}.setValue(
                        String.format('{0}\n{1} : {2}', 
                        #{LogArea}.getValue(), 
                        text, 
                        new Date().dateFormat('H:i:s'))); 
                    }" />
            </Listeners>
        </ext:ResourceManager>        
        
        <ext:Viewport runat="server">
            <Items>
                <ext:BorderLayout runat="server">
                    <Center>
                        <ext:Panel runat="server" Title="TaskManager example" Icon="Time" Border="false">
                            <TopBar>
                                <ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <ext:Button 
                                            ID="btnStartAll" 
                                            runat="server" 
                                            Text="Start All Tasks" 
                                            Icon="ControlPlayBlue" 
                                            Disabled="true">
                                            <Listeners>
                                                <Click Handler="this.disable();#{TaskManager1}.startAll();#{btnStopAll}.enable()" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button 
                                            ID="btnStopAll" 
                                            runat="server" 
                                            Text="Stop All Tasks" 
                                            Icon="ControlStopBlue">
                                            <Listeners>
                                                <Click Handler="this.disable();#{TaskManager1}.stopAll();#{btnStartAll}.enable();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Items>
                                <ext:ColumnLayout runat="server" FitHeight="true">
                                    <Columns>
                                        <ext:LayoutColumn ColumnWidth="0.5">
                                            <ext:Panel 
                                                runat="server" 
                                                Title="Local time" 
                                                BodyStyle="text-align:center;"
                                                Padding="20">
                                                <Items>
                                                    <ext:Label ID="LocalTimeLabel" runat="server" StyleSpec="font-weight:bold;font-size:500%;" />
                                                </Items>
                                                <BottomBar>
                                                    <ext:Toolbar runat="server">
                                                        <Items>
                                                             <ext:Button ID="StartLocalTime" runat="server" Text="Start Task">
                                                                <Listeners>
                                                                    <Click Handler="#{TaskManager1}.startTask(0);" />
                                                                </Listeners>
                                                            </ext:Button>
                                                            <ext:Button ID="StopLocalTime" runat="server" Text="Stop Task">
                                                                <Listeners>
                                                                    <Click Handler="#{TaskManager1}.stopTask(0);" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </Items>
                                                    </ext:Toolbar>
                                                </BottomBar>
                                            </ext:Panel>
                                        </ext:LayoutColumn>
                                        
                                        <ext:LayoutColumn ColumnWidth="0.5">
                                            <ext:Panel 
                                                ID="ServerTimeContainer" 
                                                runat="server" 
                                                Title="Server Time (update every 5 seconds)" 
                                                BodyStyle="text-align:center;"
                                                Padding="20">
                                                <Items>
                                                    <ext:Label ID="ServerTimeLabel" runat="server" StyleSpec="font-weight:bold;font-size:500%;" />
                                                </Items>
                                                <BottomBar>
                                                    <ext:Toolbar runat="server">
                                                        <Items>
                                                             <ext:Button ID="StartServerTime" runat="server" Text="Start Task">
                                                                <Listeners>
                                                                    <Click Handler="#{TaskManager1}.startTask('servertime');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                            <ext:Button ID="StopServerTime" runat="server" Text="Stop Task">
                                                                <Listeners>
                                                                    <Click Handler="#{TaskManager1}.stopTask('servertime');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </Items>
                                                    </ext:Toolbar>
                                                </BottomBar>
                                            </ext:Panel>
                                        </ext:LayoutColumn>
                                    </Columns>
                                </ext:ColumnLayout>
                            </Items>
                        </ext:Panel>
                    </Center>
                    
                    <South>
                        <ext:Panel runat="server" Height="200" Border="false" Layout="Fit">
                            <Items>
                                <ext:TextArea ID="LogArea" runat="server" />
                            </Items>
                        </ext:Panel>
                    </South>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
        
        <ext:TaskManager ID="TaskManager1" runat="server">
            <Tasks>
                <ext:Task                    
                    OnStart="
                        #{StartLocalTime}.setDisabled(true);
                        #{StopLocalTime}.setDisabled(false);
                        msg('Start Client');"
                    OnStop="
                        #{StartLocalTime}.setDisabled(false);
                        #{StopLocalTime}.setDisabled(true);
                        msg('Stop Client');">
                    <Listeners>
                        <Update Handler="#{LocalTimeLabel}.setText(new Date().dateFormat('H:i:s'));" />
                    </Listeners>    
                </ext:Task>
                
                <ext:Task 
                    TaskID="servertime"
                    Interval="5000"
                    OnStart="
                        #{StartServerTime}.setDisabled(true);
                        #{StopServerTime}.setDisabled(false); 
                        msg('Start Server')"
                    OnStop="
                        #{StartServerTime}.setDisabled(false);
                        #{StopServerTime}.setDisabled(true);
                        msg('Stop Server')">
                    <DirectEvents>
                        <Update OnEvent="RefreshTime">
                            <EventMask 
                                ShowMask="true" 
                                Target="CustomTarget" 
                                CustomTarget="={Ext.getCmp('#{ServerTimeContainer}').getBody()}" 
                                MinDelay="350"
                                />
                        </Update>
                    </DirectEvents>                    
                </ext:Task>
            </Tasks>
        </ext:TaskManager>
    </form>
</body>
</html>
