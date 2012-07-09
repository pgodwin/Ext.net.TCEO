<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        var win = new Window {
            ID = "Window1",
            Title = "Ajaxian",
            Width = Unit.Pixel(1000),
            Height = Unit.Pixel(600),
            Modal = true,
            Collapsible = true,
            Maximizable = true,
            Hidden = true
        };
        
        win.AutoLoad.Url = "http://ajaxian.com/archives/mad-cool-date-library/";
        win.AutoLoad.Mode = LoadMode.IFrame;

        win.Render(this.Form);
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Load External Website into Window - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Load External Website into an &lt;ext:Window></h1>
        <p>Load an external url into a Window using the AutoLoad property. 
            All Properties for the &lt;ext:Window> are set during the Page_Load Event.</p>

        <ext:Button runat="server" Text="Show Window" Icon="Application">
            <Listeners>
                <Click Handler="#{Window1}.show(this);" />
            </Listeners>
        </ext:Button>
    </form>
</body>
</html>
