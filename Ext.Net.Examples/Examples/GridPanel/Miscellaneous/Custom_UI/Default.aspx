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
                new object[] { "3m Co", 71.72, 0.02, 0.03, "9/1 12:00am" },
                new object[] { "Alcoa Inc", 29.01, 0.42, 1.47, "9/1 12:00am" },
                new object[] { "Altria Group Inc", 83.81, 0.28, 0.34, "9/1 12:00am" },
                new object[] { "American Express Company", 52.55, 0.01, 0.02, "9/1 12:00am" },
                new object[] { "American International Group, Inc.", 64.13, 0.31, 0.49, "9/1 12:00am" },
                new object[] { "AT&T Inc.", 31.61, -0.48, -1.54, "9/1 12:00am" },
                new object[] { "Boeing Co.", 75.43, 0.53, 0.71, "9/1 12:00am" },
                new object[] { "Caterpillar Inc.", 67.27, 0.92, 1.39, "9/1 12:00am" },
                new object[] { "Citigroup, Inc.", 49.37, 0.02, 0.04, "9/1 12:00am" },
                new object[] { "E.I. du Pont de Nemours and Company", 40.48, 0.51, 1.28, "9/1 12:00am" },
                new object[] { "Exxon Mobil Corp", 68.1, -0.43, -0.64, "9/1 12:00am" },
                new object[] { "General Electric Company", 34.14, -0.08, -0.23, "9/1 12:00am" },
                new object[] { "General Motors Corporation", 30.27, 1.09, 3.74, "9/1 12:00am" },
                new object[] { "Hewlett-Packard Co.", 36.53, -0.03, -0.08, "9/1 12:00am" },
                new object[] { "Honeywell Intl Inc", 38.77, 0.05, 0.13, "9/1 12:00am" },
                new object[] { "Intel Corporation", 19.88, 0.31, 1.58, "9/1 12:00am" },
                new object[] { "International Business Machines", 81.41, 0.44, 0.54, "9/1 12:00am" },
                new object[] { "Johnson & Johnson", 64.72, 0.06, 0.09, "9/1 12:00am" },
                new object[] { "JP Morgan & Chase & Co", 45.73, 0.07, 0.15, "9/1 12:00am" },
                new object[] { "McDonald\"s Corporation", 36.76, 0.86, 2.40, "9/1 12:00am" },
                new object[] { "Merck & Co., Inc.", 40.96, 0.41, 1.01, "9/1 12:00am" },
                new object[] { "Microsoft Corporation", 25.84, 0.14, 0.54, "9/1 12:00am" },
                new object[] { "Pfizer Inc", 27.96, 0.4, 1.45, "9/1 12:00am" },
                new object[] { "The Coca-Cola Company", 45.07, 0.26, 0.58, "9/1 12:00am" },
                new object[] { "The Home Depot, Inc.", 34.64, 0.35, 1.02, "9/1 12:00am" },
                new object[] { "The Procter & Gamble Company", 61.91, 0.01, 0.02, "9/1 12:00am" },
                new object[] { "United Technologies Corporation", 63.26, 0.55, 0.88, "9/1 12:00am" },
                new object[] { "Verizon Communications", 35.57, 0.39, 1.11, "9/1 12:00am" },
                new object[] { "Wal-Mart Stores, Inc.", 45.45, 0.73, 1.63, "9/1 12:00am" }
            };
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Custom UI - Ext.NET Examples</title>

    <script type="text/javascript">
        function linkClick(recordId){
            alert("Company: "+Store1.getById(recordId).get("company"));
        }
        
        function linkRenderer(value, meta, record){                        
            return String.format("<a class='company-link' href='#' onclick='linkClick(\"{1}\");'>{0}</a>", value, record.id);
        }
    </script>
    
    <style type="text/css">
        .x-grid-custom TD.ux-grid-hd-group-cell{
            background:url(header_sprite.png) repeat-x 50% bottom;
        }
        
        .x-grid-custom .x-grid3-hd-row TD{            
            border-left-color: #6085A5;
            border-right-color: #728BA1;
            font: 12px/16px "segoe ui",arial,sans-serif;
            height: 22px;
        } 
               
        .x-grid-custom .x-grid3-row TD{            
            font: 12px/16px "segoe ui",arial,sans-serif;
        }
        
        .x-grid-custom .x-grid3-header{
            background: #718CA1 url(header_sprite.png) repeat scroll 0 bottom;
        }
        
        .x-grid-custom td.x-grid3-hd-over .x-grid3-hd-inner,
        .x-grid-custom td.sort-desc .x-grid3-hd-inner,
        .x-grid-custom td.sort-asc .x-grid3-hd-inner,
        .x-grid-custom td.x-grid3-hd-menu-open .x-grid3-hd-inner
        {
            background: #ebf3fd url(header_sprite_over.png) repeat 0 bottom;
        }
        
        .x-grid-custom .x-grid3-hd div {
          color: white;
        }
        
        .x-grid-custom .company-link{
            color: #0E3D4F;
        }
        
        .x-grid-custom .x-grid3-hd-btn {
          background: #718CA1 url(grid3-hd-btn.png) no-repeat left center;
        }
        
        .x-grid-custom .x-grid3-row-alt{
           background-color: #DAE2E8;           
        }
        
        .x-grid-custom .x-grid3-row-over {
	        border-color:#728BA1;            
            background-image:url(row-over.png);
        }
        
        .x-grid-custom .x-grid3-row-selected{
            background: url(row-selected.png) repeat-x scroll 0 0 #7BBBCF;
            border-color:#728BA1;
            border-style:solid;
        }
        .x-grid-custom .x-grid3-row-selected TD, 
        .x-grid-custom .x-grid3-row-selected TD .company-link{
            color: White;
        }
        
        .x-grid-custom .x-toolbar div.xtb-text{
            color:#ffffff;
        }
        
        .x-grid-custom .x-toolbar{
            background:url(toolbar-bg.png) repeat-x 0 0;
        }
       
        .x-grid-custom .x-tbar-loading{
	        background-image: url(refresh.gif) !important;
        }
        
        .x-grid-custom .x-tbar-page-first {
          background-image: url(page-first.gif) !important;
        }

        .x-grid-custom .x-tbar-page-last {
          background-image: url(page-last.gif) !important;
        }

        .x-grid-custom .x-tbar-page-next {
          background-image: url(page-next.gif) !important;
        }

        .x-grid-custom .x-tbar-page-prev {
          background-image: url(page-prev.gif) !important;
        }

        .x-grid-custom .x-paging-info {
          color: #FFFFFF;
        }
        
        .x-grid-custom .x-toolbar .x-btn-tl,
        .x-grid-custom .x-toolbar .x-btn-tr,
        .x-grid-custom .x-toolbar .x-btn-tc,
        .x-grid-custom .x-toolbar .x-btn-ml,
        .x-grid-custom .x-toolbar .x-btn-mr,
        .x-grid-custom .x-toolbar .x-btn-mc,
        .x-grid-custom .x-toolbar .x-btn-bl,
        .x-grid-custom .x-toolbar .x-btn-br,
        .x-grid-custom .x-toolbar .x-btn-bc {
          background-image: url(btn.gif);
        }
    </style>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:Window runat="server" Plain="true" Layout="Fit" Width="650" Height="310" Header="false" Closable="false" Border="false">
        <Items>
            <ext:GridPanel ID="GridPanel1" runat="server" 
                Cls="x-grid-custom"
                Header="false"
                Border="false"
                StripeRows="true" 
                Title="Array Grid"
                AutoExpandColumn="Company"
                TrackMouseOver="true">
                <Store>
                    <ext:Store ID="Store1" runat="server">
                        <Reader>
                            <ext:ArrayReader>
                                <Fields>
                                    <ext:RecordField Name="company" />
                                    <ext:RecordField Name="price" Type="Float" />
                                    <ext:RecordField Name="change" Type="Float" />
                                    <ext:RecordField Name="pctChange" Type="Float" />
                                    <ext:RecordField Name="lastChange" Type="Date" DateFormat="M/d hh:mmtt" />
                                </Fields>
                            </ext:ArrayReader>
                        </Reader>
                    </ext:Store>
                </Store>
                <ColumnModel runat="server">
                    <Columns>
                        <ext:Column ColumnID="Company" Header="Company" DataIndex="company">
                            <Renderer Fn="linkRenderer" />
                        </ext:Column>
                        <ext:Column Header="Price" DataIndex="price">
                            <Renderer Format="UsMoney" />
                        </ext:Column>
                        <ext:Column ColumnID="Change" Header="Change" DataIndex="change">
                        </ext:Column>
                        <ext:Column Header="Change" DataIndex="pctChange">
                        </ext:Column>
                        <ext:DateColumn Header="Last Updated" DataIndex="lastChange" />
                    </Columns>
                </ColumnModel>
                
                <SelectionModel>
                    <ext:RowSelectionModel runat="server" />
                </SelectionModel>
                
                <BottomBar>
                    <ext:PagingToolbar runat="server" PageSize="10"/> 
                </BottomBar>
                
                <View>
                    <ext:GridView runat="server" ScrollOffset="2" />
                </View>
            </ext:GridPanel>
        </Items>
    </ext:Window>
</body>
</html>
