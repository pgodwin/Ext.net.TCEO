<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void btnChild_Click(object sender, DirectEventArgs e)
    {
        this.Label2.Text = "Child [DirectEvent]: " + DateTime.Now.ToLongTimeString();
       X.Msg.Alert("DirectEvent", "Child Button Clicked").Show();
    }

    [DirectMethod]
    public void ButtonClickChild()
    {
        this.Label2.Text = "Child [DirectMethod]: " + DateTime.Now.ToLongTimeString();
       X.Msg.Alert("DirectMethod", "Child Button Clicked").Show();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Child</title>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" RenderScripts="None" />
    
    <ext:Panel 
        ID="Panel2" 
        runat="server" 
        Title="Child" 
        Width="300" 
        Height="185"
        Frame="true">
        <Items>
            <ext:Label ID="Label2" runat="server" />
        </Items>
        <Buttons>
            <ext:Button ID="btnChild" runat="server" Text="Submit [DirectEvent]">
                <DirectEvents>
                    <Click OnEvent="btnChild_Click" Url="Child.aspx" Type="Load" />
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="Button1" IDMode="Ignore" runat="server" Text="Submit [DirectMethod]">
                <Listeners>
                    <Click Handler="Ext.net.DirectMethods.ButtonClickChild({ url: 'Child.aspx' });" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Panel>
</body>
</html>
