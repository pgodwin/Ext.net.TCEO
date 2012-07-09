<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register src="OrderDetails.ascx" tagname="OrderDetails" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <ext:ResourceManager ID="ScriptManager1" runat="server" />
    
    <ext:ViewPort runat="server">
        <Content>
            <uc1:OrderDetails runat="server" />
        </Content>
    </ext:ViewPort>
</body>
</html>