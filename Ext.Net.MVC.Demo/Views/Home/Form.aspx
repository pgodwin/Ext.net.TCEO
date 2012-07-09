<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">
        var getMsg = function (action) {
            if (action.failureType == "client") {
                return "Please check fields.";
            }
            
            var msg = "";
            
            if (action.result && action.result.errors.length > 0) {
                msg = action.result.errors[0].msg;
            } else if(action.response) {
                msg = action.response.responseText;
            }

            return msg;
        };

        var failureHandler = function (form, action) {
            Ext.MessageBox.show({
                title   : 'Failure',
                msg     : getMsg(action),
                buttons : Ext.MessageBox.OK,
                icon    : Ext.MessageBox.ERROR
            });
        };
        
        var success = function (form, action) {
            eval(action.result.script);  
        };
    </script>

</head>

<body>
    <ext:ResourceManager runat="server" />
    
    <ext:FormPanel 
        ID="FormPanel1" 
        runat="server" 
        Url="/Home/SaveForm/"
        Border="false" 
        BodyStyle="padding:5px 5px 0px;" 
        Layout="form"
        LabelAlign="Top">
        <Items>
            <ext:Panel runat="server" Border="false" Layout="column">
                <Items>
                    <ext:Panel 
                        runat="server" 
                        Border="false" 
                        ColumnWidth="0.5" 
                        Layout="form">
                        <Items>
                            <ext:TextField 
                                ID="txtName" 
                                runat="server" 
                                FieldLabel="Name" 
                                AllowBlank="false" 
                                AnchorHorizontal="95%" 
                                />
                        </Items>
                    </ext:Panel>
                    
                    <ext:Panel 
                        runat="server" 
                        Border="false" 
                        ColumnWidth="0.5" 
                        Layout="form">
                        <Items>
                            <ext:TextField 
                                ID="txtEmail" 
                                runat="server" 
                                FieldLabel="Email" 
                                AllowBlank="false" 
                                AnchorHorizontal="95%" 
                                />
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:Panel>
            
            <ext:HtmlEditor 
                ID="txtComments" 
                runat="server" 
                FieldLabel="Comments" 
                AnchorHorizontal="98%"
                Height="200" 
                AllowBlank="false" 
                />
        </Items>
        <Buttons>
            <ext:Button runat="server" Text="Send">
                <Listeners>
                    <Click Handler="#{FormPanel1}.form.submit({ waitMsg : 'Sending...', success : success });" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:FormPanel>
</body>
</html>
