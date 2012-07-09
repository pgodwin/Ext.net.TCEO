<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
    
<%@ Register src="NormalButtons.ascx" tagname="NormalButtons" tagprefix="uc1" %>
<%@ Register src="ToggleButtons.ascx" tagname="ToggleButtons" tagprefix="uc1" %>
<%@ Register src="MenuButtons.ascx" tagname="MenuButtons" tagprefix="uc1" %>
<%@ Register src="SplitButtons.ascx" tagname="SplitButtons" tagprefix="uc1" %>
<%@ Register src="SplitButtonsArrowBottom.ascx" tagname="SplitButtonsArrowBottom" tagprefix="uc1" %>
<%@ Register src="MenuButtonsArrowBottom.ascx" tagname="MenuButtonsArrowBottom" tagprefix="uc1" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Button Variations - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .add32 {
            background-image: url(images/add32.gif) !important;
        }
        
        .add16 {
            background-image: url(images/add16.gif) !important;
        }
        
        .add24 {
            background-image: url(images/add24.gif) !important;
        }

        .btn-panel td {
            padding-left:5px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />    
    
        <uc1:NormalButtons runat="server" />
        <br />
        <br />
        <uc1:ToggleButtons runat="server" />
        <br />
        <br />
        <uc1:MenuButtons runat="server" />
        <br />
        <br />
        <uc1:SplitButtons runat="server" />
        <br />
        <br />
        <uc1:MenuButtonsArrowBottom runat="server" />
        <br />
        <br />
        <uc1:SplitButtonsArrowBottom runat="server" />
    </form>    
</body>
</html>
