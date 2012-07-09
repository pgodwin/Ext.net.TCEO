<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
   "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Multiple DateFields with DateRange Validation - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Multiple DateFields with DateRange Validation</h1>
        
        <p>This example demonstrates two date fields acting as a date range. Selecting an initial date sets the minimum value for the end field. Selecting an ending date sets a maximum value for the start field.</p>
        
        <p>If a value is specified / selected in the 'DateField1 field', the 'DateField2 field' doesn't allow any date prior to the 'DateField1' entry to be specified / selected and vice versa.</p>
        
        <ext:Window 
            runat="server" 
            Width="350"
            Title="DateRange"
            Icon="Date"
            AutoHeight="true"
            Closable="false"
            Padding="5"
            Layout="Form">
            <Items>
                <ext:DateField 
                    ID="DateField1" 
                    runat="server"
                    Vtype="daterange"
                    FieldLabel="To"
                    AnchorHorizontal="100%">  
                    <CustomConfig>
                        <ext:ConfigItem Name="endDateField" Value="#{DateField2}" Mode="Value" />
                    </CustomConfig>                        
                </ext:DateField>
                
                <%--
                // Alternative syntax using custom config property attributes. 

                <ext:DateField 
                    ID="DateField1" 
                    runat="server" 
                    FieldLabel="To"
                    Vtype="daterange"
                    AnchorHorizontal="100%" 
                    EndDateField="DateField2"
                    />--%>
                    
                <ext:DateField 
                    ID="DateField2"
                    runat="server" 
                    Vtype="daterange"
                    FieldLabel="From"
                    AnchorHorizontal="100%">    
                    <CustomConfig>
                        <ext:ConfigItem Name="startDateField" Value="#{DateField1}" Mode="Value" />
                    </CustomConfig>                                 
                </ext:DateField>
                
                <%--
                // Alternative syntax using custom config property attributes. 
                
                <ext:DateField 
                    ID="DateField2" 
                    runat="server" 
                    Vtype="daterange"
                    FieldLabel="From"
                    AnchorHorizontal="100%">    
                    StartDateField="DateField1"
                    />--%>  
            </Items>            
        </ext:Window>                
   </form>
</body>
</html>
