<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Assembly="Ext.Net.Examples" Namespace="Ext.Net.Examples.FeedViewer" TagPrefix="feed" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FeedViewer - Ext.NET Examples</title>    
    
    <link href="../Feed_Viewer/resources/feed-viewer.css" rel="stylesheet" type="text/css" />
    
    <ext:ResourcePlaceHolder runat="server" Mode="ScriptFiles" />

    <script src="resources/FeedViewer.js" type="text/javascript"></script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server">
            <Listeners>
                <BeforeAjaxRequest Handler="Ext.fly('direct_indicator').removeClass('x-hidden');" />
                <AjaxRequestComplete Handler="Ext.fly('direct_indicator').addClass('x-hidden');" />
                <AjaxRequestException Handler="Ext.fly('direct_indicator').addClass('x-hidden');" />
            </Listeners>
        </ext:ResourceManager>
       
        <feed:FeedViewPort runat="server" />
    </form>    
</body>
</html>