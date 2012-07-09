<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
    
<script runat="server">
    protected void Button1_Click(object sender, DirectEventArgs e)
    {
        string tpl = "Age : {0}<br />Test : {1}";

        this.Label1.Html = string.Format(tpl, this.SpinnerField1.Number, this.SpinnerField2.Number);
    }
</script>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SpinnerField - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>SpinnerField</h1>
        
        <ext:Panel 
            ID="Panel1" 
            runat="server" 
            Title="Simple Form"
            Width="210"
            Frame="true"
            Layout="Form"
            LabelWidth="40"
            Padding="5">
            <Items>
                <ext:SpinnerField ID="SpinnerField1" runat="server" FieldLabel="Age" />
                <ext:SpinnerField 
                    ID="SpinnerField2" 
                    runat="server" 
                    FieldLabel="Test" 
                    MinValue="0"
                    MaxValue="100"
                    AllowDecimals="true"
                    DecimalPrecision="1"
                    IncrementValue="0.4"
                    Accelerate="true"
                    AlternateIncrementValue="2.1"
                    />
            </Items>
            <Buttons>
                <ext:Button ID="Button1" runat="server" Text="Submit">
                    <DirectEvents>
                        <Click OnEvent="Button1_Click" />
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:Panel>
        
        <ext:Label ID="Label1" runat="server" />
    </form>
</body>
</html>
