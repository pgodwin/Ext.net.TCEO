<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.GridPanel1.Store.Primary.DataSource = new object[]
            {
                new object[] {true, DateTime.Now, 1},
                new object[] {false, DateTime.Now.AddDays(-1), 2},
                new object[] {true, DateTime.Now.AddDays(-2), 3},
                new object[] {false, DateTime.Now.AddDays(-3), 4},
                new object[] {true, DateTime.Now.AddDays(-4), 5}
            };

            this.GridPanel1.Store.Primary.DataBind();
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Columns Variations - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server" 
            StripeRows="true"
            Title="Column Variations" 
            DisableSelection="true"
            Width="600" 
            Height="350">
            <Store>
                <ext:Store runat="server">
                    <Reader>
                        <ext:ArrayReader>
                            <Fields>
                                <ext:RecordField Name="booleanCol" Type="Boolean" />
                                <ext:RecordField Name="dateCol" Type="Date" />
                                <ext:RecordField Name="numberCol" Type="Int" />
                            </Fields>
                        </ext:ArrayReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:RowNumbererColumn />
                    <ext:BooleanColumn DataIndex="booleanCol" Header="Boolean" />
                    <ext:CheckColumn DataIndex="booleanCol" Header="Check" />
                    <ext:DateColumn DataIndex="dateCol" Header="Date" />
                    <ext:NumberColumn DataIndex="numberCol" Header="Number" Format="0.00" />
                    <ext:TemplateColumn DataIndex="" MenuDisabled="true" Header="Template">
                        <Template runat="server">
                            <Html>
						        <tpl for=".">
							        {booleanCol}<br />
								    {dateCol:date("d/m/Y")}<br />
								    {numberCol}<br />
						        </tpl>
					        </Html>
                        </Template>
                    </ext:TemplateColumn>
                </Columns>
            </ColumnModel>
        </ext:GridPanel>  
    </form>
</body>
</html>
