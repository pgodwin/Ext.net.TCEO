<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
    
<script runat="server">
    protected void Color_Changed(object sender, EventArgs e)
    {
        string tpl = "Choosen color: #<span style='color:#{0};font-weight:bold;'>{0}</span>";
        this.Label1.Html = string.Format(tpl, this.ColorPalette1.Value);
    }

    protected void AjaxColor_Changed(object sender, DirectEventArgs e)
    {
        string tpl = "Choosen color: #<span style='color:#{0};font-weight:bold;'>{0}</span>";
        this.Label2.Html = string.Format(tpl, this.ColorPalette2.Value);
    }
</script>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ColorPalate Overview - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h2>1. PostBack model</h2>
        
        <ext:ColorPalette 
            ID="ColorPalette1" 
            runat="server" 
            AutoPostBack="true" 
            OnColorChanged="Color_Changed"
            />
        
        <ext:Label ID="Label1" runat="server" />
        
        <h2>2. DirectEvent model</h2>
        
        <ext:ColorPalette ID="ColorPalette2" runat="server">
            <DirectEvents>
                <Select OnEvent="AjaxColor_Changed" />
            </DirectEvents>
        </ext:ColorPalette>
        
        <ext:Label ID="Label2" runat="server" />
    </form>
</body>
</html>
