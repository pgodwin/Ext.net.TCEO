<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Button3_Click(object sender, DirectEventArgs e)
    {
        this.Button3.Disabled = true;
        this.TriggerField3.ShowTrigger(3);
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Overview of TriggerField - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var triggerHandler = function (el, trigger, index) {
            switch (index) {
                case 0:
                    TriggerField2.getEl().applyStyles('background:white');
                    TriggerField2.triggers[0].hide();
                    TriggerField2.setValue('');
                    break;
                case 1:
                    Window1.show();
                    break;
            }
        }
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <h1>Overview of &lt;ext:TriggerField></h1>

        <h2>1. With TriggerClick Listener</h2>
        
        <ext:TriggerField 
            ID="TriggerField1" 
            runat="server" 
            Width="200" 
            EmptyText="Click Trigger Button -->">
            <Listeners>
                <TriggerClick Handler="Ext.Msg.alert('Message', 'You Clicked the Trigger!');" />
            </Listeners>
        </ext:TriggerField>
        
        <h2>2. With Dialog Editor</h2>
        
        <ext:TriggerField 
            ID="TriggerField2" 
            runat="server" 
            Width="200" 
            Editable="false">
            <Triggers>
                <ext:FieldTrigger Icon="Clear" Qtip="Click to clear field" HideTrigger="true" />
                <ext:FieldTrigger Icon="Ellipsis" Qtip="Click to choose value" />
            </Triggers>
            <Listeners>
                <TriggerClick Fn="triggerHandler" />
            </Listeners>
        </ext:TriggerField>
        
        <ext:Window 
            ID="Window1" 
            runat="server" 
            MinWidth="165" 
            MinHeight="125" 
            Resizable="false" 
            Title="Choose value" 
            Hidden="true" 
            Icon="ColorSwatch"
            Padding="3">
            <Items>
                <ext:ColorPalette ID="ColorPalette1" runat="server">
                    <Listeners>
                        <Select 
                            Handler="
                                var tf = #{TriggerField2};
                                tf.getEl().applyStyles('background:#' + color);
                                tf.triggers[0].show();
                                tf.setValue('#' + color);
                                #{Window1}.hide();"
                                />
                    </Listeners>
                </ext:ColorPalette>
            </Items>        
        </ext:Window>
        
        <h2>3. With Multiple Triggers</h2>
        
        <ext:TriggerField ID="TriggerField3" runat="server" Width="200">
            <Triggers>
                <ext:FieldTrigger Icon="Date" Qtip="Custom tip" />
                <ext:FieldTrigger Icon="Clear" Qtip="<b>Title</b><br/>Custom title" />
                <ext:FieldTrigger Icon="Search" />
                <ext:FieldTrigger Icon="Combo" HideTrigger="true" />
            </Triggers>
            <Listeners>
                <TriggerClick Handler="Ext.Msg.alert('Message', 'TriggerIndex: ' + index + '<br /><br />Text: ' + this.getValue());" />
            </Listeners>
        </ext:TriggerField> 
        
        <br/>
        
        <ext:Button ID="Button3" runat="server" Text="Show hidden Trigger (via DirectEvent)">
            <DirectEvents>
                <Click OnEvent="Button3_Click">
                    <EventMask ShowMask="true" />
                </Click>
            </DirectEvents>
        </ext:Button>
    </form>
</body>
</html>
