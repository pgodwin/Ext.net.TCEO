<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KeyNav - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" /> 
    
    <script type="text/javascript">
        var isCenter = true;
        
        var move = function (win, dir) {
            var el = win.getEl();

            if (!isCenter) {
                el.alignTo(document, 'c-c', [0,0], true);
                isCenter = true;
                return;
            }

            switch (dir) {
                case "left":
                    el.alignTo(document, "l", [0, -el.getHeight() / 2], true);
                    isCenter = false;
                    break;

                case "right":
                    el.alignTo(document, "r", [-el.getWidth(), -el.getHeight() / 2], true);
                    isCenter = false;
                    break;

                case "up":
                    el.alignTo(document, "t", [-el.getWidth() / 2, 0], true);
                    isCenter = false;
                    break;

                case "down":
                    el.alignTo(document, "b", [-el.getWidth() / 2, -el.getHeight()], true);
                    isCenter = false;
                    break;

                case "home":
                    el.center();
                    isCenter = true;               
                    break;
            }
        }
    </script>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    
    <ext:Window ID="Window1" runat="server" Width="400" Height="300" Closable="false" Title="Move Window" Padding="6">
        <Content>
            <ul>
                <li>Press:</li>
                <li>&nbsp;&nbsp;UP</li>
                <li>&nbsp;&nbsp;DOWN</li>
                <li>&nbsp;&nbsp;LEFT</li>
                <li>&nbsp;&nbsp;RIGHT</li>
                <li>&nbsp;&nbsp;HOME</li>
            </ul>
        </Content>            
    </ext:Window>
    
    <ext:KeyNav runat="server" Target="={document.body}">
        <Left Handler="move(Window1, 'left');" />
        <Right Handler="move(Window1, 'right');" />
        <Up Handler="move(Window1, 'up');" />
        <Down Handler="move(Window1, 'down');" />
        <Home Handler="move(Window1, 'home');" />
    </ext:KeyNav>
            
    <script type="text/javascript">
        var COLOUMN2 = function (value) { 
            return String.format('<img src="article_image.aspx?id={0}" id="myID" />', value);
        } 
    </script>
</body>
</html>
