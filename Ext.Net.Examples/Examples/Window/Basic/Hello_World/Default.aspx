<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Button2_Click(object sender, DirectEventArgs e)
    {
        this.Window1.Show();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Basic Hello World Window - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Simple Ext.NET Window Sample</h1>
        
        <p>The following example demonstrates how to configure a new Window Component and "show" the Window if closed.</p>
    
        <ext:Button runat="server" Text="Show Window (Client Event)" Icon="Application">
            <Listeners>
                <Click Handler="#{Window1}.show();" />
            </Listeners>
        </ext:Button>
        
        <br />
        
        <ext:Button 
            runat="server" 
            Text="Show Window (Server Event)" 
            Icon="Application" 
            OnDirectClick="Button2_Click" 
            />
        
        <ext:Window 
            ID="Window1" 
            runat="server" 
            Title="Hello World!"  
            Icon="Application"
            Height="185px" 
            Width="350px"
            BodyStyle="background-color: #fff;" 
            Padding="5"
            Collapsible="true" 
            Modal="true">
            <Content>
                This is my first <a target="_blank" href="http://www.ext.net/"> Ext.Net</a> Window.
            </Content>
        </ext:Window>
    </form>
</body>
</html>