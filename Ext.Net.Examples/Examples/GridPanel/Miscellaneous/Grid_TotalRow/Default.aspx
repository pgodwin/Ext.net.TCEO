<%@ Page Language="C#" %>
 
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
 
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            var store = this.GridPanel1.GetStore();
            
            store.DataSource = new object[] 
            { 
                new object[] {"1", "1.1", "1.01"},
                new object[] {"2", "2.2", "2.02"},
                new object[] {"3", "3.3", "3.01"}
            };
            
            store.DataBind();
        }
    }
</script>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel with Total Row - Ext.Net Example</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var updateTotal = function (grid) {
            var fbar = grid.getBottomToolbar(),
                column,
                field,
                width,
                data = {test1: 0, test2: 0, test3: 0},
                c,
                cs = grid.view.getColumnData();
 
            for (var j = 0, jlen = grid.store.getCount(); j < jlen; j++) {
                var r = grid.store.getAt(j);
                
                for (var i = 0, len = cs.length; i < len; i++) {
                    c = cs[i];
                    data[c.name] += r.get(c.name);
                }
            }
 
            for (var i = 0; i < grid.getColumnModel().columns.length; i++) {
                column = grid.getColumnModel().columns[i];
 
                field = fbar.findBy(function (item) {
                    return item.dataIndex === column.dataIndex;
                })[0];
                
                c = cs[i];
                fbar.remove(field, false);
                fbar.insert(i, field);
                width = grid.getColumnModel().getColumnWidth(i);
                field.setWidth(width - 5);
                field.setValue((c.renderer)(data[c.name], {}, {}, 0, i, grid.store));
            }
            
            fbar.doLayout();
        };
    </script>
 
    <style type="text/css">
        .total-field {
            background-color : #fff;
            font-weight      : bold !important;
            color            : #000;
            border           : solid 1px silver;
            padding          : 2px;
            margin-right     : 5px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <h1>GridPanel with Total Row</h1>
        
        <ext:ResourceManager runat="server" />
        
        <ext:GridPanel ID="GridPanel1" runat="server" AutoHeight="true">
            <Store>
                <ext:Store runat="server">
                    <Reader>
                        <ext:ArrayReader>
                            <Fields>
                                <ext:RecordField Name="test1" Type="Int"/>
                                <ext:RecordField Name="test2" Type="Float"/>
                                <ext:RecordField Name="test3" Type="Float"/>
                            </Fields>
                        </ext:ArrayReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column Header="Test1" DataIndex="test1" />
                    <ext:Column Header="Test2" DataIndex="test2" />
                    <ext:Column Header="Test3" DataIndex="test3" />
                </Columns>
            </ColumnModel>
            <View>
                <ext:GridView runat="server" ForceFit="true" />
            </View>
            <Listeners>
                <ColumnResize Handler="updateTotal(this);" />
                <AfterRender Handler="updateTotal(this);" Delay="100" />
            </Listeners>
            <BottomBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:DisplayField
                            runat="server"
                            DataIndex="test1"
                            Cls="total-field"
                            Text="-" 
                            />
                        <ext:DisplayField
                            runat="server"
                            DataIndex="test2"
                            Cls="total-field"
                            Text="-" 
                            />
                        <ext:DisplayField
                            runat="server"
                            DataIndex="test3"
                            Cls="total-field"
                            Text="-" 
                            />
                    </Items>
                </ext:Toolbar>
            </BottomBar>
        </ext:GridPanel>
    </form>
</body>
</html>