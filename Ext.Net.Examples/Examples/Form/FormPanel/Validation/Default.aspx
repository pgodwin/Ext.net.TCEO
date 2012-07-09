<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FormPanel Validation - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .icon-exclamation {
            padding-left: 25px !important;
            background: url(/icons/exclamation-png/ext.axd) no-repeat 3px 3px !important;
        }
        
        .icon-accept {
            padding-left: 25px !important;
            background: url(/icons/accept-png/ext.axd) no-repeat 3px 3px !important;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:FormPanel 
            ID="FormPanel1" 
            runat="server" 
            Title="FormPanel Validation (all fields required)"
            MonitorPoll="500" 
            MonitorValid="true" 
            Padding="5" 
            Width="600" 
            Height="250"
            ButtonAlign="Right"
            Layout="Column">
            <Items>
                <ext:Panel runat="server" Border="false" Header="false" ColumnWidth=".5" Layout="Form" LabelAlign="Top">
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />
                    </Defaults>
                    <Items>
                        <ext:TextField ID="TextField1" runat="server" FieldLabel="First Name" AnchorHorizontal="92%" />
                        <ext:TextField runat="server" FieldLabel="Company" AnchorHorizontal="92%" />
                    </Items>
                </ext:Panel>
                <ext:Panel runat="server" Border="false" Layout="Form" ColumnWidth=".5" LabelAlign="Top">
                    <Defaults>
                        <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                        <ext:Parameter Name="MsgTarget" Value="side" />
                    </Defaults>
                    <Items>
                        <ext:TextField runat="server" FieldLabel="Last Name" AnchorHorizontal="92%" />
                        <ext:TextField runat="server" FieldLabel="Email" Vtype="email" AnchorHorizontal="92%" />
                    </Items>
                </ext:Panel>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Save">
                    <Listeners>
                        <Click Handler="if (#{FormPanel1}.getForm().isValid()) {Ext.Msg.alert('Submit', 'Saved!');}else{Ext.Msg.show({icon: Ext.MessageBox.ERROR, msg: 'FormPanel is incorrect', buttons:Ext.Msg.OK});}" />
                    </Listeners>
                </ext:Button>
                <ext:Button runat="server" Text="Cancel" />
            </Buttons>
            <BottomBar>
                <ext:StatusBar runat="server" Height="25" />
            </BottomBar>
            <Listeners>
                <ClientValidation Handler="this.getBottomToolbar().setStatus({text : valid ? 'Form is valid' : 'Form is invalid', iconCls: valid ? 'icon-accept' : 'icon-exclamation'});" />
            </Listeners>
        </ext:FormPanel>
    </form>
</body>
</html>
