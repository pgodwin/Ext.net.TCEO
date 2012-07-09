<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">      
          div.botright{
            display:block;      
            position:absolute;
            bottom:0;
            right:0;
            width:105px;        
            height:105px;        
            background:#eee;
            border:1px solid #ddd;
          }
    </style> 
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <h1>Demonstrates how to show custom load mask while iframe loading.</h1>   
        <p>The animation will be shown at the right bottom corner of page</p>
                
        <ext:Window 
            ID="Window1" 
            runat="server" 
            Width="500" 
            Height="470" 
            Icon="Link"
            Title="IFrame panel" 
            ShowOnLoad="true" 
            CenterOnLoad="true"
            Closable="false">
            <AutoLoad Url="http://www.ext.net" Mode="IFrame" />
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:ToolbarFill />
                        <ext:Button runat="server" Text="Load Google">
                            <Listeners>
                                <Click Handler="#{Window1}.load('http://www.google.com/');" />
                            </Listeners>
                        </ext:Button>
                        
                        <ext:Button runat="server" Text="Refresh" Icon="ArrowRotateClockwise">
                            <Listeners>
                                <Click Handler="#{Window1}.reload();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            
             <Listeners>
                <BeforeUpdate Handler="#{maskDiv}.removeClass('x-hide-display');" />
                <Update Handler="#{maskDiv}.addClass('x-hide-display');" />
            </Listeners>
        </ext:Window>
        
        <div id="maskDiv" class="botright x-hide-display">     
            <img src="loading.gif" />
        </div>
    </form>
</body>
</html>
