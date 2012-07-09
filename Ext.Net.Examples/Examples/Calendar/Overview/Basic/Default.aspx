<%@ Page Language="C#" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Import Namespace="Ext.Net.Calendar.Demo" %>

<script runat="server">
    protected void Page_Init(object sender, EventArgs e)
    {
        this.CalendarPanel1.EventStore = new EventStore { ID = "EventStore1" };
        this.CalendarPanel1.EventStore.SubmitData += EventStore_SubmitData;
    }

    void EventStore_SubmitData(object sender, StoreSubmitDataEventArgs e)
    {
        var events = e.Object<Event>();
        ((EventsViewer)this.Page.LoadControl("../Shared/Common/EventsViewer.ascx")).Render(events);
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {            
        if (!X.IsAjaxRequest)
        {
            this.CalendarPanel1.EventStore.Events.AddRange(Data.Events);            
        }
    }

    [DirectMethod(Namespace = "CompanyX")]
    public void ShowMsg(string msg)
    {
        X.Msg.Notify("Message", msg).Show();
    }
</script>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Calendar - Ext.NET Examples</title>
    
    <ext:ResourcePlaceHolder runat="server" Mode="Style" />
    <link rel="stylesheet" type="text/css" href="../Shared/resources/css/main.css" />
    
    <ext:ResourcePlaceHolder runat="server" Mode="Script" />
    <script type="text/javascript" src="../Shared/resources/js/common.js"></script>
    
    <style type="text/css">
        .ext-color-4,
        .ext-ie .ext-color-4-ad,
        .ext-opera .ext-color-4-ad {
	        color: #7F0000;
        }
        .ext-cal-day-col .ext-color-4,
        .ext-dd-drag-proxy .ext-color-4,
        .ext-color-4-ad,
        .ext-color-4-ad .ext-cal-evm,
        .ext-color-4 .ext-cal-picker-icon,
        .ext-color-4-x dl,
        .ext-color-4-x .ext-cal-evb {
	        background: #7F0000;
        }
        .ext-color-4-x .ext-cal-evb,
        .ext-color-4-x dl {
            border-color: #7C3939;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager 
            runat="server" 
            IDMode="Explicit" 
            InitScriptMode="Linked" 
            RemoveViewState="true"
            Namespace="CompanyX" 
            />
        
        <ext:Viewport runat="server" Layout="Border">
            <Items>
                <ext:Panel 
                    runat="server" 
                    Height="35" 
                    Border="false" 
                    Region="North" 
                    Cls="app-header" 
                    BodyCssClass="app-header-content">
                    <Content>
                        <div id="app-logo">
                            <div class="logo-top">&nbsp;</div>
                            <div id="logo-body">&nbsp;</div>
                            <div class="logo-bottom">&nbsp;</div>
                        </div>
                        <h1>My Calendar</h1>
                        <span id="app-msg" class="x-hidden"></span>
                    </Content>
                </ext:Panel>
                
                <ext:Panel 
                    ID="Panel1" 
                    runat="server" 
                    Title="..." 
                    Layout="Border" 
                    Region="Center" 
                    Cls="app-center">
                    <Items>
                        <ext:Panel 
                            runat="server" 
                            Width="176" 
                            Region="West" 
                            Border="false" 
                            Cls="app-west">
                            <Items>
                                <ext:DatePicker 
                                    ID="DatePicker1" 
                                    runat="server" 
                                    Cls="ext-cal-nav-picker">
                                    <Listeners>
                                        <Select Fn="CompanyX.setStartDate" Scope="CompanyX" />
                                    </Listeners>
                                </ext:DatePicker>
                            </Items>
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Button 
                                            ID="Button1"
                                            runat="server" 
                                            Text="Save All Events" 
                                            Icon="Disk" 
                                            OnClientClick="CompanyX.record.saveAll();" 
                                            />
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                        </ext:Panel>
                        
                        <ext:CalendarPanel
                            ID="CalendarPanel1" 
                            runat="server"
                            Region="Center"
                            ActiveIndex="2"
                            Border="false">
                            <GroupStore ID="GroupStore1" runat="server">
                                <Groups>
                                    <ext:Group CalendarId="1" Title="Home" />
                                    <ext:Group CalendarId="2" Title="Work" />
                                    <ext:Group CalendarId="3" Title="School" />
                                    <ext:Group CalendarId="4" Title="Other" />
                                </Groups>
                            </GroupStore>
                            <MonthView 
                                runat="server" 
                                ShowHeader="true" 
                                ShowWeekLinks="true" 
                                ShowWeekNumbers="true" 
                                />  
                            <Listeners>
                                <ViewChange  Fn="CompanyX.viewChange" Scope="CompanyX" />
                                <EventClick  Fn="CompanyX.record.show" Scope="CompanyX" />
                                <DayClick    Fn="CompanyX.dayClick" Scope="CompanyX" />
                                <RangeSelect Fn="CompanyX.rangeSelect" Scope="CompanyX" />

                                <EventMove   Fn="CompanyX.record.move" Scope="CompanyX" />
                                <EventResize Fn="CompanyX.record.resize" Scope="CompanyX" />
                            </Listeners>
                        </ext:CalendarPanel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>
        
        <ext:EventEditWindow 
            ID="EventEditWindow1" 
            runat="server"
            Hidden="true"
            GroupStoreID="GroupStore1">
            <Listeners>
                <EventAdd    Fn="CompanyX.record.add" Scope="CompanyX" />
                <EventUpdate Fn="CompanyX.record.update" Scope="CompanyX" />
                <EditDetails Fn="CompanyX.record.edit" Scope="CompanyX" />
                <EventDelete Fn="CompanyX.record.remove" Scope="CompanyX" />
            </Listeners>
        </ext:EventEditWindow>
    </form>
</body>
</html>
