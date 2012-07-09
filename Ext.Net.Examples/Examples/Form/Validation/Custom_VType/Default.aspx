<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Custom VType - Ext.Net Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <ext:ResourcePlaceHolder runat="server" />

    <script type="text/javascript">
        Ext.apply(Ext.form.VTypes, {
            numberrange : function(val, field) {
                if (!val) {
                    return;
                }
                
                if (field.startNumberField && (!field.numberRangeMax || (val != field.numberRangeMax))) {
                    var start = Ext.getCmp(field.startNumberField);
                    
                    if (start) {
                        start.setMaxValue(val);
                        field.numberRangeMax = val;
                        start.validate();
                    }
                } else if (field.endNumberField && (!field.numberRangeMin || (val != field.numberRangeMin))) {
                    var end = Ext.getCmp(field.endNumberField);
                    
                    if (end) {
                        end.setMinValue(val);
                        field.numberRangeMin = val;
                        end.validate();
                    }
                }
                
                return true;
            }
        });
    </script>

</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>NumberFields with NumberRange Validation</h1>
            
        <p>This example demonstrates two number fields acting as a number range. Specifying
            an initial number sets the minimum value for the end field. Specifying an ending
            number sets a maximum value for the start field.</p>
            
        <p>If a value is specified in the 'NumberField1 field', the 'NumberField2
            field' doesn't allow any number prior to the 'NumberField1' entry to be specified
            and vice versa.</p>
            
        <ext:NumberField 
            ID="NumberField1" 
            runat="server" 
            Number="5"
            Vtype="numberrange" 
            FieldLabel="From"
            LabelWidth="30" 
            EndNumberField="#{NumberField2}" 
            />
            
        <ext:NumberField 
            ID="NumberField2" 
            runat="server" 
            Vtype="numberrange" 
            FieldLabel="To"
            LabelWidth="30" 
            StartNumberField="#{NumberField1}" 
            />
    </form>
</body>
</html>
