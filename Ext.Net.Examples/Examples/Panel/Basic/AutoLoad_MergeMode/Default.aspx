<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void btnParent_Click(object sender, DirectEventArgs e)
    {
        this.Label1.Text = "Parent [DirectEvent]: " + DateTime.Now.ToLongTimeString();
       X.Msg.Alert("DirectEvent", "Parent Button Clicked").Show();
    }

    [DirectMethod]
    public void ButtonClickParent()
    {
        this.Label1.Text = "Parent [DirectMethod]: " + DateTime.Now.ToLongTimeString();
       X.Msg.Alert("DirectMethod", "Parent Button Clicked").Show();
    }
</script>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ext.NET Examples</title>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
 
    <form id="Form1" runat="server">
        <ext:Panel 
            ID="Panel1" 
            runat="server" 
            Title="Parent" 
            Height="300" 
            Width="500"
            Padding="6">
            <AutoLoad Url="Child.aspx" Mode="Merge" />
            <Buttons>
                <ext:Button ID="btnParent" runat="server" Text="Submit [DirectEvent]">
                    <DirectEvents>
                        <Click OnEvent="btnParent_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button1" IDMode="Ignore" runat="server" Text="Submit [DirectMethod]">
                    <Listeners>
                        <Click Handler="Ext.net.DirectMethods.ButtonClickParent();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Panel>
    
        <ext:Label ID="Label1" runat="server" />
    </form>
</body>
</html>
