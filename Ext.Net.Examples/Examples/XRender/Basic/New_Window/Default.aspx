<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Button1_Click(object sender, DirectEventArgs e)
    {
        var win = new Window 
        {
            ID = "Window1",
            Title = "My Window",
            Height = 185,
            Width = 350,
            Padding = 5,
            Html = "A new Window created at: " + DateTime.Now.ToLongTimeString()
        };

        win.Listeners.Hide.Handler = "Button1.setDisabled(false);";
        
        win.Render(this.Form);

        this.Button1.Disabled = true;
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dynamically create a new Window during a DirectEvent - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Dynamically create a new Window during a DirectEvent</h1>
        
        <ext:Button 
            ID="Button1" 
            runat="server" 
            Text="Add Window" 
            Icon="Add" 
            OnDirectClick="Button1_Click" 
            />
    </form>
</body>
</html>