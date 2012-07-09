<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void btnLogin_Click(object sender, DirectEventArgs e)
    {
        this.Window1.Hide();

        string template = "<br /><b>LOGIN SUCCESS</b><br /><br />Username: {0}<br />Password: {1}";
        string username = this.txtUsername.Text;
        string password = this.txtPassword.Text;
        this.lblMessage.Html = string.Format(template, username, password);
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple Login Form with Ajax Submit - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
            
        <h1>Simple Login Form with Ajax Submit</h1>
        
        <ext:Button 
            ID="Button1" 
            runat="server" 
            Text="Logout" 
            Icon="LockOpen">
            <Listeners>
                <Click Handler="#{Window1}.show();" />
            </Listeners>    
        </ext:Button>
        
        <ext:Label ID="lblMessage" runat="server" />
        
        <ext:Window 
            ID="Window1" 
            runat="server" 
            Closable="false"
            Resizable="false"
            Height="150" 
            Icon="Lock" 
            Title="Login"
            Draggable="false"
            Width="350"
            Modal="true"
            Padding="5"
            Layout="Form">
            <Items>
                <ext:TextField 
                    ID="txtUsername" 
                    runat="server" 
                    FieldLabel="Username" 
                    AllowBlank="false"
                    BlankText="Your username is required."
                    Text="Demo"
                    AnchorHorizontal="100%"
                    />
                <ext:TextField 
                    ID="txtPassword" 
                    runat="server" 
                    InputType="Password" 
                    FieldLabel="Password" 
                    AllowBlank="false" 
                    BlankText="Your password is required."
                    Text="Demo"
                    AnchorHorizontal="100%"
                    />
            </Items>
            <Buttons>
                <ext:Button ID="btnLogin" runat="server" Text="Login" Icon="Accept">
                    <Listeners>
                        <Click Handler="
                            if (!#{txtUsername}.validate() || !#{txtPassword}.validate()) {
                                Ext.Msg.alert('Error','The Username and Password fields are both required');
                                // return false to prevent the btnLogin_Click Ajax Click event from firing.
                                return false; 
                            }" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnLogin_Click">
                            <EventMask ShowMask="true" Msg="Verifying..." MinDelay="500" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCancel" runat="server" Text="Cancel" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{Window1}.hide();#{lblMessage}.setText('LOGIN CANCELED')" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>


