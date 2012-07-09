<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.Store1.DataSource = this.Data;
            this.Store1.DataBind();
        }
    }

    private object[] Data
    {
        get
        {
            return new object[]
            {
                new object[] { "3m Co", 1, 3, 1 },
                new object[] { "Alcoa Inc", 2, 2.7, 2 },
                new object[] { "Altria Group Inc", 3.5, 2, 3 },
                new object[] { "American Express Company", 4, 1.3, 4 },
                new object[] { "American International Group, Inc.", 5, 0, 5 }
            };
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RatingColumn - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" /> 
    
    <style type="text/css">
        .number-selected {
	        background: transparent url(star_n.png) repeat-x left center;
        }
        .number-unselected {
	        background: transparent url(star_fade_n.png) repeat-x left center;
        }
    </style>       
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <h1>Rating Column</h1>
    
    <ext:GridPanel 
        ID="GridPanel1"
        runat="server" 
        StripeRows="true"
        Title="Array Grid" 
        TrackMouseOver="true"
        Width="600" 
        Height="350">
        <Store>
            <ext:Store ID="Store1" runat="server">
                <Reader>
                    <ext:ArrayReader>
                        <Fields>
                            <ext:RecordField Name="company" />
                            <ext:RecordField Name="rating1" Type="Float" />
                            <ext:RecordField Name="rating2" Type="Float" />
                            <ext:RecordField Name="rating3" Type="Float" />
                        </Fields>
                    </ext:ArrayReader>
                </Reader>
            </ext:Store>
        </Store>
        <ColumnModel runat="server">
            <Columns>
                <ext:Column ColumnID="Company" Header="Company" DataIndex="company" />
                <ext:RatingColumn Header="Rating" DataIndex="rating1" />                  
                <ext:RatingColumn Header="Editable" DataIndex="rating2" RoundToTick="false" Editable="true" /> 
                <ext:RatingColumn Header="Custom" DataIndex="rating3" SelectedCls="number-selected" UnselectedCls="number-unselected" />
            </Columns>
        </ColumnModel>        
    </ext:GridPanel>          
</body>
</html>
