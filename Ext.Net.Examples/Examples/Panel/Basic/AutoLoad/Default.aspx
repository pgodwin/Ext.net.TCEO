<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Button1_Click(object sender, DirectEventArgs e)
    {
        this.Panel1.Html = DateTime.Now.ToLongTimeString();
    }

    protected void Button2_Click(object sender, DirectEventArgs e)
    {
        this.Panel2.AutoLoad.Url = "Child.aspx";
        this.Panel2.AutoLoad.NoCache = true;
        this.Panel2.LoadContent();
    }

    protected void Button3_Click(object sender, DirectEventArgs e)
    {
        this.Panel2.LoadContent("Child.aspx", true);
    }
    
    protected void Button4_Click(object sender, DirectEventArgs e)
    {
        this.Panel3.AutoLoad.Url = "Child.aspx";
        this.Panel3.AutoLoad.Mode = LoadMode.IFrame;
        this.Panel3.AutoLoad.NoCache = true;
        this.Panel3.LoadContent();
    }

    protected void Button5_Click(object sender, DirectEventArgs e)
    {
        this.Panel3.LoadContent(new LoadConfig("Child.aspx", LoadMode.IFrame, true));
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Setting Html and AutoLoad Properties - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <h1>Setting Html and AutoLoad Properties</h1>
    
    <ext:ResourceManager runat="server" DirectEventUrl="default.aspx" />
    
    <h2>Html Property</h2>
    
    <p>Setting the &lt;Content> region or setting the .Html property will add the text directly to the "body" of the Panel.</p>
    
    <ext:Panel 
        ID="Panel1" 
        runat="server" 
        Height="150" 
        Width="350"
        Title="Html"
        Padding="5">
        <Content>
            <%= DateTime.Now.ToLongTimeString() %>
        </Content>
        <Buttons>
            <ext:Button ID="Button1" runat="server" Text="Set Html Property">
                <DirectEvents>
                    <Click OnEvent="Button1_Click" />
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Panel>
    
    <h2>AutoLoad Property</h2>
    
    <%--
    <p>The .AutoLoad property must be set with a url. The url can be either a local or remote url. A url is considered remote if it starts with "http".</p>
    <p>The .AutoLoad property functions differently depending on the whether the url is local or remote.</p>
    <p>If the url is a local url, the Panel will make an Ajax request for the url and replace the body of the Panel with the html from the &lt;body> of the Page being requested.
    Think of this functionality as a "merge" of the two Pages.</p>
    <p>If the local url/Page contains JavaScript or Css (StyleSheet), the JavaScript is executed and the Css is applied to the Parent Page where the requesting Panel is located.</p>
    <p>If the local url (Child) is a ASP.NET .aspx Page with a &lt;form runat="server">, and the Child Page can perform PostBacks, the combined Page may not function properly and the Child PostBack may cause a JavaScript error or Exception.</p>
    <p>If PostBacks are required in the Child Page, please set the .AutoLoadIFrame property as noted below.</p>
    <p>If the .AutoLoad property is set with a remote url (starts with "http"), an &lt;iframe> will automatically added to the body of the Panel and the url will be loaded into the &lt;iframe>. This is the same functionality as the .AutoLoadIFrame property.</p>
    --%>

    <ext:Panel 
        ID="Panel2" 
        runat="server" 
        Height="150"
        Width="350"
        Title="Merge Mode"
        Padding="5">
        <AutoLoad Url="Child.aspx" />
        <Buttons>
            <ext:Button ID="Button2" runat="server" Text="Set Property">
                <DirectEvents>
                    <Click OnEvent="Button2_Click" Method="GET" />
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="Button3" runat="server" Text="Load">
                <DirectEvents>
                    <Click OnEvent="Button3_Click" />
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Panel>
    
    <ext:Panel 
        ID="Panel3" 
        runat="server" 
        Height="150" 
        Width="350"
        Title="IFrame Mode">
        <AutoLoad Url="Child.aspx" Mode="IFrame" ShowMask="true" />
        <Buttons>
            <ext:Button ID="Button4" runat="server" Text="Set Property">
                <DirectEvents>
                    <Click OnEvent="Button4_Click" />
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="Button5" runat="server" Text="Load">
                <DirectEvents>
                    <Click OnEvent="Button5_Click" />
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Panel>
</body>
</html>
