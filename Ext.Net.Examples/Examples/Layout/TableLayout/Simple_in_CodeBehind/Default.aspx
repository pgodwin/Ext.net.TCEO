<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        // Build all the Panels which will fill the Table Cells.
        Ext.Net.Panel panel1 = new Ext.Net.Panel();
        panel1.Title = "Lots of Spanning";
        panel1.BodyStyle = "padding:15px;";
        panel1.Html = "<p>Row spanning.</p><br /><p>Row spanning.</p><br /><p>Row spanning.</p><br /><p>Row spanning.</p><br /><p>Row spanning.</p><br /><p>Row spanning.</p>";

        Ext.Net.Panel panel2 = new Ext.Net.Panel();
        panel2.Title = "Basic Table Cell";
        panel2.BodyStyle = "padding:15px;";
        panel2.Html = "<p>Basic panel in a table cell.</p>";

        Ext.Net.Panel panel3 = new Ext.Net.Panel();
        panel3.Header = false;
        panel3.BodyStyle = "padding:15px;";
        panel3.Html = "<p>Plain panel</p>";

        Ext.Net.Panel panel4 = new Ext.Net.Panel();
        panel4.Title = "Another Cell";
        panel4.Width = Unit.Pixel(300);
        panel4.BodyStyle = "padding:15px;";
        panel4.Html = "<p>Row spanning.</p><br /><p>Row spanning.</p><br /><p>Row spanning.</p><br /><p>Row spanning.</p>";

        Ext.Net.Panel panel5 = new Ext.Net.Panel();
        panel5.Header = false;
        panel5.BodyStyle = "padding:15px;";
        panel5.Html = "Plain cell spanning two columns";

        Ext.Net.Panel panel6 = new Ext.Net.Panel();
        panel6.Title = "More Column Spanning";
        panel6.BodyStyle = "padding:15px;";
        panel6.Html = "<p>Spanning three columns.</p>";

        Ext.Net.Panel panel7 = new Ext.Net.Panel();
        panel7.Title = "Spanning All Columns";
        panel7.BodyStyle = "padding:15px;";
        panel7.Html = "<p>Spanning all columns.</p>";

        // 
        TableLayout tableLayout1 = new TableLayout();
        tableLayout1.Columns = 4;

        Cell cell1 = new Cell();
        cell1.RowSpan = 3;
        cell1.Items.Add(panel1);

        Cell cell2 = new Cell();
        cell2.Items.Add(panel2);

        Cell cell3 = new Cell();
        cell3.Items.Add(panel3);

        Cell cell4 = new Cell();
        cell4.RowSpan = 2;
        cell4.Items.Add(panel4);

        Cell cell5 = new Cell();
        cell5.ColSpan = 2;
        cell5.Items.Add(panel5);

        Cell cell6 = new Cell();
        cell6.ColSpan = 3;
        cell6.Items.Add(panel6);

        Cell cell7 = new Cell();
        cell7.ColSpan = 4;
        cell7.Items.Add(panel7);
                
        tableLayout1.Cells.Add(cell1);
        tableLayout1.Cells.Add(cell2);
        tableLayout1.Cells.Add(cell3);
        tableLayout1.Cells.Add(cell4);
        tableLayout1.Cells.Add(cell5);
        tableLayout1.Cells.Add(cell6);
        tableLayout1.Cells.Add(cell7);

        Ext.Net.Panel pnlTableLayout = new Ext.Net.Panel();
        pnlTableLayout.ID = "pnlTableLayout";
        pnlTableLayout.Title = "Table Layout";
        pnlTableLayout.BodyStyle = "padding:15px;";
        pnlTableLayout.Border = false;
        pnlTableLayout.ContentControls.Add(tableLayout1);

        BorderLayout borderLayout1 = new BorderLayout();
        borderLayout1.Center.Items.Add(pnlTableLayout);

        Viewport viewPort1 = new Viewport();
        viewPort1.ContentControls.Add(borderLayout1);
        
        // Add Window to Form
        this.PlaceHolder1.Controls.Add(viewPort1);
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple TableLayout - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #pnlTableLayout .x-table-layout {
            padding:5px;
        }
        
        #pnlTableLayout .x-table-layout td {
            font-size:11px;
            padding:5px;
            vertical-align:top;
        }
    </style>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
</body>
</html>
