<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HyperLink Variations - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
   
    <h1>HyperLink Variations</h1>
    
    <h2>Simple HyperLink</h2>
    
    <ext:HyperLink runat="server" NavigateUrl="http://www.ext.net" Text="http://www.ext.net" Target="_blank" />
    
    <h2>HyperLink with Icon</h2>
    
    <ext:HyperLink 
        runat="server" 
        Icon="Application" 
        Target="_blank"
        NavigateUrl="http://www.ext.net" 
        Text="http://www.ext.net" 
        />
    
    <h2>HyperLink with Right Aligned Icon</h2>
    
    <ext:HyperLink 
        runat="server" 
        Icon="Application" 
        IconAlign="Right" 
        Target="_blank"
        NavigateUrl="http://www.ext.net" 
        Text="http://www.ext.net" 
        />
    
    <h2>Image HyperLink</h2>
    
    <ext:HyperLink 
        runat="server" 
        Target="_blank"
        NavigateUrl="http://www.ext.net" 
        ImageUrl="http://ext.net/images/logo.gif" 
        />
</body>
</html>
