<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void SendClick(object sender, DirectEventArgs e)
    {
        X.Js.Alert("Send to: " + this.SendTo.SelectedItem.Value);
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VBox-Form - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <h1>VBox Layout with Forms</h1>
        
        <p>The <code><b>align:'stretch'</b></code> config of the vbox layout manager ensures
        all child items are 100% of the container width.</p>
        
        <p>The <code><b>flex</b></code> config of child items of a vbox layout specifies what share of the vertical
        space left when unflexed items are accounted for to allocate for that child item.</p>
        
        <p>Compare this to <a target="_blank" href="http://examples.ext.net/Examples/Layout/AnchorLayout/Anchor_With_Form/">The anchoring example</a>. 
        That anchors the fields to a hardcoded offset from the edge of the Container. 
        Box Layout managers allow much more flexibility in use of available space.</p>
        
        <p>This also illustrates the use of plugins to alter the default behaviour of Components. The <b>Send To</b>
        field clones itself until the final one is left blank to allow multiple mail recipients. The layout
        manager keeps the vertical space allocated correctly.</p>
        
        <ext:Window 
            runat="server"
            Title="Compose message"
            Collapsible="true"
            Maximizable="true"
            Width="750"
            Height="500"
            MinWidth="300"
            MinHeight="200"
            Layout="Fit"
            Plain="true"
            Padding="5"
            ButtonAlign="Center">
            <Items>
                <ext:FormPanel 
                    runat="server" 
                    BaseCls="x-plain"
                    LabelWidth="55">
                    <LayoutConfig>
                        <ext:VBoxLayoutConfig Align="Stretch" DefaultMargins="1 0 1 0" />
                    </LayoutConfig>
                    <Items>
                        <ext:ComboBox 
                            ID="SendTo" 
                            runat="server" 
                            FieldLabel="Send To" 
                            ForceSelection="false">
                            <Plugins>
                                <ext:FieldReplicator runat="server" />
                            </Plugins>
                            <Items>
                                <ext:ListItem Text="test@example.com" />
                                <ext:ListItem Text="someone@example.com" />
                            </Items>
                        </ext:ComboBox>
                        <ext:TextField runat="server" FieldLabel="Subject" />
                        <ext:TextArea runat="server" Flex="1" />
                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Send" OnDirectClick="SendClick" />
                <ext:Button runat="server" Text="Cancel" />
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
