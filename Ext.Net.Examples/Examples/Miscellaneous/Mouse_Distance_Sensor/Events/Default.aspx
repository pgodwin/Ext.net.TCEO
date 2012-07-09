<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mouse Sensor Distance Events - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    
    
    <ext:XScript runat="server">
        <script type="text/javascript">
            var near = function (el, sensorEl) {
                var bar = #{Toolbar1},
                    win = #{Window1};
              
                bar.setWidth(win.body.getWidth() - 2);
                bar.el.setStyle("zIndex", win.el.getStyle("zIndex")+1);
                bar.show();
                bar.getPositionEl().alignTo(sensorEl, "t-t", [0, 23]);
            };
            
            var far = function () {
                var bar = #{Toolbar1};
                bar.hide();
            };
        </script>
    </ext:XScript>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <h1>Mouse Sensor Distance Events</h1>
    
    <ext:Window 
        ID="Window1"
        runat="server"
        Title="Move Mouse to top of Window" 
        Width="350" 
        Height="215"
        Closable="false"
        Layout="fit"
        PageX="100"
        PageY="100">
        <Items>
            <ext:TextArea runat="server" />
        </Items>
        <Plugins>
            <ext:MouseDistanceSensor 
                runat="server" 
                SensorElement="={#{Window1}.header}" 
                ConstrainElement="Window1"
                Opacity="false"
                Threshold="25">
                <Listeners>
                    <Near Fn="near" />
                    <Far Fn="far" />
                </Listeners>
            </ext:MouseDistanceSensor>
        </Plugins>
    </ext:Window>
    
    <ext:Toolbar 
        ID="Toolbar1" 
        runat="server" 
        Hidden="true" 
        StyleSpec="position:absolute;">
        <Items>
            <ext:Button runat="server" Text="Paste" Icon="PastePlain" />
            <ext:Button runat="server" Text="Copy" Icon="ApplicationDouble" />
            <ext:Button runat="server" Text="Cut" Icon="Cut" />
        </Items>
    </ext:Toolbar>
</body>
</html>
