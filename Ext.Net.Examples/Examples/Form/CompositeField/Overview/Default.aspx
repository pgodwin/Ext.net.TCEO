<%@ Page Language="C#" %>
<%@ Import Namespace="System.Collections.Generic"%>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
    
<script runat="server">
    protected void LoadData(object sender, DirectEventArgs e)
    {
         FormPanel1.SetValues(new {
            Email = "ed@extjs.com",
            Title = "mr",
            FirstName = "Abraham",
            LastName = "Elias",
            StartDate = new DateTime(2003, 1, 10),
            EndDate = new DateTime(2009, 12,11),
            Phone1 = 555,
            Phone2 = 123,
            Phone3 = 4567,
            Hours = 7,
            Minutes = 15
         });           
    }

    protected void SaveData(object sender, DirectEventArgs e)
    {
        var values = JSON.Deserialize<Dictionary<string, string>>(e.ExtraParams["values"]);
        StringBuilder sb = new StringBuilder();
        
        foreach (var value in values)
        {
            sb.AppendFormat("{0} = {1}<br />", value.Key, value.Value);
        }

        X.Msg.Alert("Values", sb.ToString()).Show();
    }

</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Composite Field - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .dot-label {
            font-weight : bold; 
            font-size   : 20px;
        }
        
        .form-toolbar {
	        top      : 1px;
            position : relative;
        }
    </style>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:FormPanel runat="server" Height="400" Title="Form Panel" Padding="5" MonitorResize="true">
        <Items>
            <ext:CompositeField runat="server" FieldLabel="Text fields" AnchorHorizontal="100%">
                <Items>
                    <ext:TextField runat="server" Width="150" />
                    <ext:TextField runat="server" Width="300" />
                </Items>
            </ext:CompositeField>
            
            <ext:CompositeField runat="server" FieldLabel="50% / 50%" AnchorHorizontal="100%">
                <Items>
                    <ext:TextField runat="server" Flex="1" />
                    <ext:TextField runat="server" Flex="1" />
                </Items>
            </ext:CompositeField>
            
            <ext:CompositeField runat="server" FieldLabel="Fill" AnchorHorizontal="100%">
                <Items>
                    <ext:TextField runat="server" Width="200" />
                    <ext:DisplayField runat="server" Flex="1" Html="&nbsp;" />
                    <ext:TextField runat="server" Width="200" />
                </Items>
            </ext:CompositeField>
            
            <ext:CompositeField runat="server" FieldLabel="200px / 100%" AnchorHorizontal="100%">
                <Items>
                    <ext:TextField runat="server" Width="200" />
                    <ext:TextField runat="server" Flex="1" />
                </Items>
            </ext:CompositeField>
            
            <ext:CompositeField runat="server" FieldLabel="Mix">
                <Items>
                    <ext:TextField runat="server" Width="150" />
                    <ext:ComboBox runat="server" Width="300" />
                </Items>
            </ext:CompositeField>
            
            <ext:CompositeField runat="server" FieldLabel="With toolbar">
                <Items>
                    <ext:TextField runat="server" Width="150" Cls="onepx-shift" />
                    <ext:DateField runat="server" Width="300" />
                    <ext:Toolbar runat="server" Cls="form-toolbar" Flat="true">
                        <Items>
                            <ext:Button runat="server" Text="Button" Icon="Add" />
                            <ext:SplitButton runat="server" Text="Split" Icon="ArrowDown">
                                <Menu>
                                    <ext:Menu runat="server">
                                        <Items>
                                            <ext:MenuItem runat="server" Text="Item1" />
                                            <ext:MenuItem runat="server" Text="Item2" />
                                        </Items>
                                    </ext:Menu>
                                </Menu>
                            </ext:SplitButton>
                        </Items>
                    </ext:Toolbar>
                </Items>
            </ext:CompositeField>
            
            <ext:CompositeField ID="MultiField1" runat="server" FieldLabel="With button">
                <Items>
                    <ext:TextField ID="TextField1" runat="server" Width="150" Cls="onepx-shift" />
                    <ext:DateField ID="DateField1" runat="server" Width="300" />
                    <ext:Button ID="Button1" runat="server" Text="..." Cls="onepx-shift" />
                </Items>
            </ext:CompositeField>
            
            <ext:CompositeField runat="server" FieldLabel="IP Address">
                <Items>
                    <ext:NumberField runat="server" Width="40" />
                    <ext:DisplayField runat="server" Text="." Cls="dot-label" />
                    <ext:NumberField runat="server" Width="40" />
                    <ext:DisplayField runat="server" Text="." Cls="dot-label" />
                    <ext:NumberField runat="server" Width="40" />
                    <ext:DisplayField runat="server" Text="." Cls="dot-label" />
                    <ext:NumberField runat="server" Width="40" />
                </Items>
            </ext:CompositeField>
            
            <ext:CompositeField runat="server" FieldLabel="Long note" Note="Lorem ipsum dolor sit amet, consectetuer adipiscing elit">
                <Items>
                    <ext:TextField runat="server" />
                    <ext:TextField runat="server" />
                    <ext:TextField runat="server" />
                </Items>
            </ext:CompositeField>
            
            <ext:CompositeField ID="MultiField2" runat="server" FieldLabel="Several notes">
                <Items>
                    <ext:TextField runat="server" Note="Note" />
                    <ext:TextField runat="server" Note="Note" />
                    <ext:TextField runat="server" Note="Note" />
                </Items>
            </ext:CompositeField>
        </Items>
    </ext:FormPanel>
    
    <br />
    
    <ext:FormPanel 
        ID="FormPanel1" 
        runat="server"
        Title="Composite Fields"
        AutoHeight="true"
        Width="600"
        Padding="5"
        DefaultAnchor="0">
        <Items>
            <ext:TextField runat="server" DataIndex="Email" FieldLabel="Email Address" AnchorHorizontal="-20" />
            
            <ext:CompositeField 
                runat="server" 
                MsgTarget="Side"
                AnchorHorizontal="-20"
                FieldLabel="Date Range"
                DefaultFlex="1">
                <Items>
                    <ext:DateField runat="server" FieldLabel="Start Date" DataIndex="StartDate" />
                    <ext:DateField runat="server" FieldLabel="End Date" DataIndex="EndDate" />
                </Items>
            </ext:CompositeField>
            
            <ext:FieldSet 
                runat="server"
                Title="Details"
                Collapsible="true"
                Layout="form">
                <Items>
                    <ext:CompositeField 
                        runat="server"
                        FieldLabel="Phone"
                        MsgTarget="Under">
                        <Items>
                            <ext:DisplayField runat="server" Text="(" />
                            <ext:TextField runat="server" DataIndex="Phone1" Width="29" AllowBlank="false" />
                            <ext:DisplayField runat="server" Text=")" />
                            <ext:TextField runat="server" DataIndex="Phone2" Width="29" AllowBlank="false" Margins="0 5 0 0" />
                            <ext:TextField runat="server" DataIndex="Phone3" Width="48" AllowBlank="false" />
                        </Items>
                    </ext:CompositeField>
                    
                    <ext:CompositeField runat="server" FieldLabel="Time worked" CombineErrors="false">
                        <Items>
                            <ext:NumberField runat="server" DataIndex="Hours" Width="48" AllowBlank="false" />
                            <ext:DisplayField runat="server" Text="hours" />
                            <ext:NumberField runat="server" DataIndex="Minutes" Width="48" AllowBlank="false" />
                            <ext:DisplayField runat="server" Text="mins" />
                        </Items>
                    </ext:CompositeField>
                    
                    <ext:CompositeField 
                        runat="server"
                        AnchorHorizontal="-20"
                        MsgTarget="Side"
                        FieldLabel="Full Name">
                        <Items>
                            <ext:ComboBox 
                                runat="server"
                                Width="50"
                                Editable="false"
                                DataIndex="Title">
                                <Items>
                                    <ext:ListItem Text="Mr" Value="mr" />
                                    <ext:ListItem Text="Mrs" Value="mrs" />
                                    <ext:ListItem Text="Miss" Value="miss" />
                                </Items>
                                <SelectedItem Value="mr" />
                            </ext:ComboBox>
                            
                            <ext:TextField runat="server" Flex="1" DataIndex="FirstName" AllowBlank="false" />
                            
                            <ext:TextField runat="server" Flex="1" DataIndex="LastName" AllowBlank="false" />
                        </Items>
                    </ext:CompositeField>
                </Items>
            </ext:FieldSet>
        </Items>
        
        <Buttons>
            <ext:Button runat="server" Text="Load test data">
                <DirectEvents>
                    <Click OnEvent="LoadData" />
                </DirectEvents>
            </ext:Button>
            
            <ext:Button runat="server" Text="Save">
                <DirectEvents>
                    <Click OnEvent="SaveData" Before="return #{FormPanel1}.isValid();">
                        <ExtraParams>
                            <ext:Parameter Name="values" Value="#{FormPanel1}.getForm().getValues()" Mode="Raw" Encode="true" />
                        </ExtraParams>
                    </Click>
                </DirectEvents>
            </ext:Button>
            
            <ext:Button runat="server" Text="Reset">
                <Listeners>
                    <Click Handler="#{FormPanel1}.getForm().reset();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:FormPanel>
</body>
</html>
