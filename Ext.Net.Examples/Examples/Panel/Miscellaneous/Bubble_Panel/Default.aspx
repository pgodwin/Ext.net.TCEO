<%@ Page Language="C#" %>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bubble Panel</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <link href="resources/css/bubble.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
	    body {
	        background-color: #4E79B2 !important;
	    }
	    
	    #bubble-markup em {
		    font-style: italic
	    }
    </style>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:Panel runat="server"
        BaseCls="x-bubble"
        Frame="true"
        StyleSpec="padding-top: 5px;"
        BodyStyle="padding-left: 8px;color: #0d2a59"
        Html="<h3>Ext.ux.BubblePanel</h3>"
        Width="200"
        AutoHeight="true"
    />
    
    <ext:Panel runat="server"
        BaseCls="x-bubble"
        Frame="true"
        Padding="5"
        Width="400"
        AutoHeight="true"
    >
        <Content>
            <p>This is a custom panel to achieve a different look and feel while not changing the default appearance of an Panel.</p>
            <p>The majority of the work is actually done in <a href="resources/css/bubble.css">bubble.css</a>. Panel uses a custom baseCls ('x-bubble') which will generate unique CSS classes for the markup in a Panel such as <em>'x-bubble-tl'</em>, <em>'x-bubble-tr'</em> and <em>'x-bubble-tc'</em>.</p>
        </Content>
    </ext:Panel>
    
    <ext:Panel runat="server"
        Frame="true"
        Padding="5"
        Width="400"
        AutoHeight="true"
        Title="Plain Old Panel"
        Html="<h3>Plain panel</h3>"
    />
</body>
</html>
