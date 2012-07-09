<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Assembly="Ext.Net.UX" Namespace="Ext.Net.UX" TagPrefix="ux" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GMap - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" ID="ResourceManager1" />
        
        <ext:Window ID="PanWin" runat="server" 
            Title="GPanorama Window" 
            Width="400" 
            Height="300"
            Layout="Fit" 
            X="480" 
            Y="60">
            <Items>
                <ux:GMapPanel runat="server" GMapType="Panorama">
                    <CenterMarker lat="42.345573" lng="-71.098326" />
                </ux:GMapPanel>
            </Items>
            <Listeners>
                <Show Handler="this.hide();" Single="true" />
            </Listeners>
        </ext:Window>
    
        <ext:Window ID="MapWin" runat="server" 
            Hidden="true"
            Title="GMap Window" 
            Width="400" 
            Height="400"
            Layout="Fit" 
            X="40" 
            Y="60">
            <Items>
                <ux:GMapPanel runat="server" ZoomLevel="14" GMapType="Map">
                    <MapControls  GSmallMapControl="true" />
                    
                    <CenterMarker GeoCodeAddress="4 Yawkey Way, Boston, MA, 02215-3409, USA">
                         <Options Title="Fenway Park" />
                    </CenterMarker>
                    
                    <Markers>
                        <ux:Marker Lat="42.339641" Lng="-71.094224">
                            <Options Title="Boston Museum of Fine Arts" />
                        </ux:Marker>
                        
                        <ux:Marker Lat="42.339419" Lng="-71.09077">
                            <Options Title="Northeastern University" />
                        </ux:Marker>
                    </Markers>
                </ux:GMapPanel>
            </Items>
        </ext:Window>
    
        <ext:Window ID="mapParis" runat="server" 
            Title="La Tour Eiffel" 
            Hidden="true"
            Layout="Fit" 
            Width="400"
            Height="400">
            <Items>
                <ux:GMapPanel ID="GMapPanel1" runat="server" ZoomLevel="16" GMapType="Map">
                    <MapControls GSmallMapControl="true" />
                    
                    <MapConfiguration ScrollWheelZoom="true" />
                    
                    <CenterMarker GeoCodeAddress="La Tour Eiffel">
                         <Options Title="La Tour Eiffel" />
                    </CenterMarker>
                    
                    <Markers>
                        <ux:Marker Lat="48.858281" Lng="2.294533">
                            <Options Title="La Tour Eiffel" />
                        </ux:Marker>
                    </Markers>
                </ux:GMapPanel>
            </Items>
        </ext:Window>
        
        <ext:Viewport runat="server" ID="ViewPort1" Layout="Fit">
            <Items>
                <ux:GMapPanel runat="server" ID="CenterMap" Border="false" ZoomLevel="14" GMapType="Map">
                    <MapControls GHierarchicalMapTypeControl="true" GLargeMapControl="true" />
                    
                    <MapConfiguration DoubleClickZoom="true" ContinuousZoom="true" GoogleBar="true" ScrollWheelZoom="true" />
                    
                    <CenterMarker GeoCodeAddress="4 Yawkey Way, Boston, MA, 02215-3409, USA">
                        <Options Title="Fenway Park" />
                    </CenterMarker>
                    
                    <Markers>
                        <ux:Marker Lat="42.339641" Lng="-71.094224">
                            <Options Title="Boston Museum of Fine Arts" />
                            <Listeners>
                                <Click Handler="Ext.Msg.alert('Its fine', 'and its art.');" />
                            </Listeners>
                        </ux:Marker>
                        <ux:Marker Lat="42.339419" Lng="-71.09077">
                            <Options Title="Northeastern University" />
                        </ux:Marker>
                    </Markers>
                    
                    <Buttons>
                        <ext:Button runat="server" ID="PanButton" Text="Fenway Park StreetView">
                            <Listeners>
                                <Click Handler="#{PanWin}.show();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" ID="MapButton" Text="Fenway Park Map Window">
                             <Listeners>
                                <Click Handler="#{MapWin}.show();" />
                            </Listeners>
                        </ext:Button>                        
                        <ext:Button runat="server" Text="La Tour Eiffel">
                             <Listeners>
                                <Click Handler="#{mapParis}.show();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ux:GMapPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
