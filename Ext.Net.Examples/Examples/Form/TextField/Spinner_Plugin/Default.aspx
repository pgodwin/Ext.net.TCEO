<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        var data = new System.Collections.Generic.List<object> { 
            new { FirstName = "Bill", LastName = "Foot"},
            new { FirstName = "Bill", LastName = "Little"},
            new { FirstName = "Bob", LastName = "Jones"},
            new { FirstName = "Bob", LastName = "Train"},
            new { FirstName = "Chris", LastName = "Johnson"}
        };

        var count = data.Count;

        this.Store1.DataSource = data;            
        this.Store1.DataBind();

        this.Spinner1.MinValue = 0;
        this.Spinner1.MaxValue = count - 1;
        this.Spinner1.Value = this.Spinner1.MaxValue;
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
   "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Spinner Plugin - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Spinner Plugin</h1>
        
        <ext:Store ID="Store1" runat="server">
            <Reader>
                <ext:JsonReader>
                    <Fields>
                        <ext:RecordField Name="FirstName" />
                        <ext:RecordField Name="LastName" />
                        <ext:RecordField Name="FullName">
                            <Convert Handler="return record.LastName + ', ' + record.FirstName;" />
                        </ext:RecordField>
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        
        <ext:FormPanel runat="server" Title="Form" Width="400" Height="70" Padding="10" LabelWidth="150">
            <Items>
                <ext:TextField runat="server" FieldLabel="TextField with Spinner" ReadOnly="true">
                    <Plugins>
                        <ext:Spinner ID="Spinner1" runat="server">
                            <Listeners>
                                <Spin Handler="this.field.setValue(#{Store1}.getAt(this.value).get('FullName'));" Buffer="100" />
                            </Listeners>
                        </ext:Spinner>
                    </Plugins>
                </ext:TextField>
            </Items>
        </ext:FormPanel>        
       
   </form>
</body>
</html>
