<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.GridPanel1.Store.Primary.DataSource = new List<object>
            {
                new { 
                    Value = 1, 
                    Text = "One"
                },
                new { 
                    Value = 2, 
                    Text = "Two"
                },
                new { 
                    Value = 3, 
                    Text = "Three"
                },
                new { 
                    Value = 4, 
                    Text = "Four"
                },
                new { 
                    Value = 5, 
                    Text = "Five"
                }
            };

            this.GridPanel1.Store.Primary.DataBind();
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel with EditableGrid Plugin - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>GridPanel with EditableGrid Plugin</h1>
        
        <p><b>NOTE</b> : Do NOT use this plugin on large datasets!</p>
        
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server"
            Width="300"
            Height="200"
            Title="EditableGrid Plugin">
            <Store>
                <ext:Store runat="server">
                    <Reader>
                        <ext:JsonReader>
                            <Fields>
                                <ext:RecordField Name="Value" Type="Int" />
                                <ext:RecordField Name="Text" Type="String" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <Plugins>
                <ext:EditableGrid runat="server" />
            </Plugins>
            <ColumnModel>
                <Columns>
                    <ext:RowNumbererColumn />
                    <ext:Column 
                        Header="Value" 
                        DataIndex="Value" 
                        Width="130" 
                        Sortable="true">
                        <Editor>
                            <ext:NumberField runat="server" AllowBlank="false" />
                        </Editor>
                    </ext:Column>
                    <ext:Column 
                        Header="Text" 
                        DataIndex="Text" 
                        Width="130" 
                        Sortable="true">
                        <Editor>
                            <ext:TextField runat="server" AllowBlank="false" />
                        </Editor>
                    </ext:Column>
                </Columns>
            </ColumnModel>
        </ext:GridPanel>
    </form>  
</body>
</html>