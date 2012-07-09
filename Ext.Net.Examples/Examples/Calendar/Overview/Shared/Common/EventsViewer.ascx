<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventsViewer.ascx.cs" Inherits="Ext.Net.Calendar.Demo.EventsViewer" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<ext:Window 
    ID="Window1" 
    runat="server"
    Title="Events"
    Modal="true"
    BodyStyle="background:#fff;"
    CloseAction="Close"
    Width="600"
    Height="400"
    Layout="Fit">
    <Items>
        <ext:DataView 
            ID="DataView1" 
            runat="server" 
            ItemSelector="div.event" 
            AutoScroll="true">
            <Store>
                <ext:EventStore ID="EventStore1" runat="server" />                    
            </Store>
            <Template runat="server">
                <Html>
                    <tpl for=".">
                        <div class="event">
                            <table>
                                <caption>{Title} ({CalendarId}-{EventId})</caption>
                                <tr>
                                    <th>Start Date</th>
                                    <td>{StartDate:date("Y-m-d H:i:s")}</td>
                                </tr>
                                <tr>
                                    <th>End Date</th>
                                    <td>{EndDate:date("Y-m-d H:i:s")}</td>
                                </tr>
                                <tr>
                                    <th>Location</th>
                                    <td>{Location}</td>
                                </tr>
                                <tr>
                                    <th>Notes</th>
                                    <td>{Notes}</td>
                                </tr>
                                <tr>
                                    <th>Url</th>
                                    <td>{Url}</td>
                                </tr>
                                <tr>
                                    <th>IsAllDay</th>
                                    <td>{IsAllDay}</td>
                                </tr>
                                <tr>
                                    <th>Reminder</th>
                                    <td>{Reminder}</td>
                                </tr>
                                <tr>
                                    <th>IsNew</th>
                                    <td>{IsNew}</td>
                                </tr>
                            </table>
                        </div>
                    </tpl>
                </Html>
            </Template>
        </ext:DataView>
    </Items>
</ext:Window>
