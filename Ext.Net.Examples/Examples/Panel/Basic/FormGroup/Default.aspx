<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .x-form-group .x-form-group-header-text {
        	background-color: #dfe8f6;
        }
        
        .x-label-text {
            font-weight: bold;
            font-size: 11px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Setting FormGroup property</h1>   
                
        <ext:Window 
            ID="Window1" 
            runat="server" 
            Width="500" 
            Height="485" 
            Title="Subscription" 
            ShowOnLoad="true" 
            CenterOnLoad="true"
            Resizable="false"
            Closable="false"
            Padding="6">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Title="Subscription Details" AutoHeight="true" FormGroup="true">
                    <Content>
                        <table>
                            <tr>
                                <td style="width:50%;">
                                    <p><span class="x-label-text">Subscription ID:</span><span style="color:red">*</span></p>
                                    <ext:TextField ID="TextField1" runat="server" Text="123-456789" Width="230" />
                                </td>
                                <td colspan="2">
                                    <p><span class="x-label-text">Company:</span><span style="color:red">*</span></p>
                                    <ext:TextField ID="TextField2" runat="server" Width="230" Text="Super reach customer" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width:50%;">
                                    <p><span class="x-label-text">Subscription:</span><span style="color:red">*</span></p>
                                    <ext:ComboBox ID="ComboBox1" runat="server" Width="230">
                                        <Items>
                                            <ext:ListItem Text="Silver" />
                                            <ext:ListItem Text="Gold" />
                                            <ext:ListItem Text="Platinum" />
                                            <ext:ListItem Text="Diamond" />
                                        </Items>
                                    </ext:ComboBox>
                                </td>
                                <td style="width:25%;">
                                    <p><span class="x-label-text">Start Date:</span><span style="color:red">*</span></p>
                                    <ext:DateField ID="DateField1" runat="server" Width="108" SelectedDate="01/01/2008" />
                                </td>
                                <td style="width:25%;">
                                    <p><span class="x-label-text">Renew Date:</span><span style="color:red">*</span></p>
                                    <ext:DateField ID="DateField2" runat="server" Width="108" SelectedDate="01/01/2009" />
                                </td>
                            </tr>
                        </table>
                    </Content>
                </ext:Panel>
                
                <ext:Panel ID="Panel2" runat="server" Title="SVN Access" AutoHeight="true" FormGroup="true">
                    <Content>
                        <table border="0" cellpadding="5" cellspacing="5">
                            <tr>
                                <td style="width:50%;">
                                    <p><span class="x-label-text">SVN User:</span><span style="color:red">*</span></p>
                                    <ext:TextField ID="TextField3" runat="server" Width="230" />
                                </td>
                                <td style="width:50%;">
                                    <p><span class="x-label-text">SVN Password:</span><span style="color:red">*</span></p>
                                    <ext:TextField ID="TextField4" runat="server" Width="230" InputType="Password" />
                                </td>
                            </tr>                            
                        </table>
                    </Content>
                </ext:Panel>
                
                 <ext:Panel ID="Panel3" runat="server" Title="Import Users" AutoHeight="true" FormGroup="true" Padding="10">
                    <Content>
                        <p>Enter a comma, semi-column or space separated list of community usernames to associate with subscription.</p>
                        <ext:TextArea ID="TextArea1" runat="server" Width="460" Height="100" />
                    </Content>
                </ext:Panel>
            </Items>
        </ext:Window>
    </form>
</body>
</html>
