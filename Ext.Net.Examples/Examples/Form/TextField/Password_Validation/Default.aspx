<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
   "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Password Validation - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Password Validation</h1>
        <p>This example shows a password verification, the second value must be equivalent to the first to validate.</p>
        
        <ext:Window 
            runat="server" 
            Width="350"
            AutoHeight="true"
            Title="Password Verification"
            Icon="Textfield"
            Closable="false"
            Padding="5"
            LabelWidth="125"
            Layout="Form">
            <Items>
                <ext:TextField 
                    ID="PasswordField" 
                    runat="server"                    
                    FieldLabel="Password"
                    InputType="Password"
                    Width="175">                            
                </ext:TextField>
                <ext:TextField 
                    runat="server"                     
                    Vtype="password"
                    FieldLabel="Confirm Password"
                    InputType="Password"
                    MsgTarget="Side"
                    Width="175">     
                    <CustomConfig>
                        <ext:ConfigItem Name="initialPassField" Value="#{PasswordField}" Mode="Value" />
                    </CustomConfig>                      
                </ext:TextField>     
            </Items>            
        </ext:Window>                
   </form>
</body>
</html>
