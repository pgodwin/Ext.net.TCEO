<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Northwind Traders - Sample web application using Ext.NET, ExtJS and ASP.NET MVC</title>    
    <style type="text/css">
        h1 {
            font: normal 60px tahoma, arial, verdana;
            color: #E1E1E1;
        }
        
        h2 {
            font: normal 20px tahoma, arial, verdana;
            color: #E1E1E1;
        }
        
        h2 a {
            text-decoration: none;
            color: #E1E1E1;
        }
        
        .x-window-mc {
            background-color : #F4F4F4 !important;
        }
    </style>
    <script type="text/javascript">
        if (window.top.frames.length !== 0) {
            window.top.location = self.document.location;
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <h1>Northwind Traders</h1>
    <h2>Powered by <a href="http://www.ext.net/">Ext.NET</a>, <a href="http://www.extjs.com/">ExtJS</a> and <a href="http://www.asp.net/mvc/">ASP.NET MVC</a></h2>
    <ext:Window 
        ID="LoginWindow"
        runat="server" 
        Closable="false"
        Resizable="false"
        Height="130" 
        Icon="Lock" 
        Title="Login"
        Draggable="true"
        Width="300"
        Modal="true"
        Layout="fit"
        BodyBorder="false"
        Padding="5">        
        <Items>
                <ext:FormPanel 
                    runat="server" 
                    FormID="form1"
                    Border="false"
                    Layout="form"
                    BodyBorder="false" 
                    BodyStyle="background:transparent;" 
                    Url='<%# Html.AttributeEncode(Url.Action("Login")) %>'>
                    <Items>
                        <ext:TextField 
                            ID="txtUsername" 
                            runat="server" 
                            FieldLabel="Username" 
                            AllowBlank="false"
                            BlankText="Username is required."
                            Text="demo"
                            AnchorHorizontal="100%"
                            />
                         <ext:TextField 
                            ID="txtPassword" 
                            runat="server" 
                            InputType="Password" 
                            FieldLabel="Password" 
                            AllowBlank="false" 
                            BlankText="Password is required."
                            Text="demo"
                            AnchorHorizontal="100%"
                            />
                    </Items>
                </ext:FormPanel>
        </Items>
        <Buttons>
            <ext:Button runat="server" Text="Login" Icon="Accept">
                <DirectEvents>
                    <Click 
                        Url="/Account/Login/" 
                        Timeout="60000"
                        FormID="form1"
                        CleanRequest="true" 
                        Method="POST"
                        Before="Ext.Msg.wait('Verifying...', 'Authentication');"
                        Failure="Ext.Msg.show({
                           title:   'Login Error',
                           msg:     result.errorMessage,
                           buttons: Ext.Msg.OK,
                           icon:    Ext.MessageBox.ERROR
                        });">
                        <EventMask MinDelay="250" />
                        <ExtraParams>
                            <ext:Parameter Name="ReturnUrl" Value="Ext.urlDecode(String(document.location).split('?')[1]).r || '/'" Mode="Raw" />
                        </ExtraParams>
                    </Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
</body>
</html>
