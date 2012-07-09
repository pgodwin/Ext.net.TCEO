<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple TableLayout in Markup - Ext.NET Examples</title>
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

    <ext:Viewport ID="ViewPort1" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Center>
                    <ext:Panel
                        id="pnlTableLayout"
                        runat="server" 
                        Title="Table Layout"
                        Border="false"
                        Padding="15">
                        <Items>
                            <ext:TableLayout runat="server" Columns="4">
                                <Cells>
                                    <ext:Cell RowSpan="3">
                                        <ext:Panel 
                                            ID="Panel1" 
                                            runat="server" 
                                            Title="Lots of Spanning" 
                                            Padding="15"
                                            Html="<p>Row spanning.</p><br /><p>Row spanning.</p><br /><p>Row spanning.</p><br /><p>Row spanning.</p><br /><p>Row spanning.</p><br /><p>Row spanning.</p>"
                                            />
                                    </ext:Cell>
                                    <ext:Cell>
                                        <ext:Panel 
                                            ID="Panel2" 
                                            runat="server" 
                                            Title="Basic Table Cell" 
                                            Padding="15"
                                            Html="<p>Basic panel in a table cell.</p>"
                                            />
                                    </ext:Cell>
                                    <ext:Cell>
                                        <ext:Panel 
                                            ID="Panel3" 
                                            runat="server" 
                                            Header="false"
                                            Padding="15"
                                            Html="<p>Plain panel</p>"
                                            />
                                    </ext:Cell>  
                                    <ext:Cell RowSpan="2">
                                        <ext:Panel 
                                            ID="Panel4" 
                                            runat="server" 
                                            Title="Another Cell"
                                            Width="300"
                                            Padding="15"
                                            Html="<p>Row spanning.</p><br /><p>Row spanning.</p><br /><p>Row spanning.</p><br /><p>Row spanning.</p>"
                                            />
                                    </ext:Cell>    
                                    <ext:Cell ColSpan="2">
                                        <ext:Panel 
                                            ID="Panel5" 
                                            runat="server" 
                                            Header="false"
                                            Padding="15"
                                            Html="Plain cell spanning two columns"
                                            />
                                    </ext:Cell>                                      
                                    <ext:Cell ColSpan="3">
                                        <ext:Panel 
                                            ID="Panel6" 
                                            runat="server" 
                                            Title="More Column Spanning"
                                            Padding="15"
                                            Html="<p>Spanning three columns.</p>"
                                            />
                                    </ext:Cell> 
                                    <ext:Cell ColSpan="4">
                                        <ext:Panel 
                                            ID="Panel7" 
                                            runat="server" 
                                            Title="Spanning All Columns"
                                            Padding="15"
                                            Html="<p>Spanning all columns.</p>"
                                            />
                                    </ext:Cell>   
                                </Cells>                                  
                            </ext:TableLayout>
                        </Items>
                    </ext:Panel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
</body>
</html>