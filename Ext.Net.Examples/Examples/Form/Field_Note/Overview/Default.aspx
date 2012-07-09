<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Field Note - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .red-note {
            color: red !important;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <h2>1. Simple note</h2>
        
        <ext:TextField runat="server" Note="Simple note" />
        
        <h2>2. Top note</h2>
        
        <ext:ComboBox runat="server" Note="Top note" NoteAlign="Top" />
        
        <h2>3. Custom note</h2>
        
        <ext:TextArea runat="server" BoxLabel="CheckBox" Note="Red note" NoteCls="red-note" />
        
        <h2>4. FormPanel with notes</h2>      
        
        <ext:FormPanel runat="server" Padding="5" Width="270" Height="180">
            <Items>
                <ext:TextField runat="server" FieldLabel="Field1" Note="Description" />
                <ext:TextField runat="server" FieldLabel="Field2" Note="Description" />
                <ext:TextField runat="server" FieldLabel="Field3" Note="Description" />
                <ext:TextField runat="server" FieldLabel="Field4" Note="Description" />
            </Items>
        </ext:FormPanel>
    </form>    
</body>
</html>
