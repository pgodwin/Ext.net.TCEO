<%@ Page Language="C#" %>
 
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
 
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            var data = this.GetData();
            var store1 = this.GridPanel1.GetStore();
            var store2 = this.ComboBox1.GetStore();
 
            store1.DataSource = data;
            store1.DataBind();
            
            store2.DataSource = data;
            store2.DataBind();
        }
    }

    public object[] GetData()
    {
        return new object[] {
            new object[] { "3m Co", 71.72, 0.02, 0.03, "01/01/2008" },
            new object[] { "Alcoa Inc", 29.01, 0.42, 1.47, "02/01/2008" },
            new object[] { "Altria Group Inc", 83.81, 0.28, 0.34, "03/01/2008" },
            new object[] { "American Express Company", 52.55, 0.01, 0.02, "10/01/2008" },
            new object[] { "American International Group, Inc.", 64.13, 0.31, 0.49, "09/01/2008" },
            new object[] { "AT&T Inc.", 31.61, -0.48, -1.54, "01/03/2008" },
            new object[] { "Boeing Co.", 75.43, 0.53, 0.71, "01/04/2008" },
            new object[] { "Caterpillar Inc.", 67.27, 0.92, 1.39, "01/01/2008" },
            new object[] { "Citigroup, Inc.", 49.37, 0.02, 0.04, "02/02/2008" },
            new object[] { "E.I. du Pont de Nemours and Company", 40.48, 0.51, 1.28, "03/05/2008" },
            new object[] { "Exxon Mobil Corp", 68.1, -0.43, -0.64, "01/01/2008" },
            new object[] { "General Electric Company", 34.14, -0.08, -0.23, "01/01/2008" },
            new object[] { "General Motors Corporation", 30.27, 1.09, 3.74, "01/01/2008" },
            new object[] { "Hewlett-Packard Co.", 36.53, -0.03, -0.08, "01/01/2008" },
            new object[] { "Honeywell Intl Inc", 38.77, 0.05, 0.13, "01/01/2008" },
            new object[] { "Intel Corporation", 19.88, 0.31, 1.58, "01/01/2008" },
            new object[] { "International Business Machines", 81.41, 0.44, 0.54, "01/01/2008" },
            new object[] { "Johnson & Johnson", 64.72, 0.06, 0.09, "01/01/2008" },
            new object[] { "JP Morgan & Chase & Co", 45.73, 0.07, 0.15, "01/01/2008" },
            new object[] { "McDonald\"s Corporation", 36.76, 0.86, 2.40, "01/01/2008" },
            new object[] { "Merck & Co., Inc.", 40.96, 0.41, 1.01, "01/01/2008" },
            new object[] { "Microsoft Corporation", 25.84, 0.14, 0.54, "01/01/2008" },
            new object[] { "Pfizer Inc", 27.96, 0.4, 1.45, "01/01/2008" },
            new object[] { "The Coca-Cola Company", 45.07, 0.26, 0.58, "01/01/2008" },
            new object[] { "The Home Depot, Inc.", 34.64, 0.35, 1.02, "01/01/2008" },
            new object[] { "The Procter & Gamble Company", 61.91, 0.01, 0.02, "01/01/2008" },
            new object[] { "United Technologies Corporation", 63.26, 0.55, 0.88, "01/01/2008" },
            new object[] { "Verizon Communications", 35.57, 0.39, 1.11, "01/01/2008" },
            new object[] { "Wal-Mart Stores, Inc.", 45.45, 0.73, 1.63, "01/01/2008" }
        };
    }
</script>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
     
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel with MultiHeader Row Filters - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    
 
    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';
 
        var change = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value);
        };
 
        var pctChange = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value + "%");
        };
    </script>
     
    <ext:XScript runat="server">
        <script type="text/javascript">
                         
            var applyFilter = function (field) {                
                var store = #{GridPanel1}.getStore();
                store.suspendEvents();
                store.filterBy(getRecordFilter());                                
                store.resumeEvents();
                #{GridPanel1}.getView().refresh(false);
            };
             
            var clearFilter = function () {
                #{ComboBox1}.reset();
                #{PriceFilter}.reset();
                #{ChangeFilter}.reset();
                #{PctChangeFilter}.reset();
                #{LastChangeFilter}.reset();
                 
                #{Store1}.clearFilter();
            }
 
            var filterString = function (value, dataIndex, record) {
                var val = record.get(dataIndex);
                
                if (typeof val != "string") {
                    return value.length == 0;
                }
                
                return val.toLowerCase().indexOf(value.toLowerCase()) > -1;
            };
 
            var filterDate = function (value, dataIndex, record) {
                var val = record.get(dataIndex).clearTime(true).getTime();
 
                if (!Ext.isEmpty(value, false) && val != value.clearTime(true).getTime()) {
                    return false;
                }
                return true;
            };
 
            var filterNumber = function (value, dataIndex, record) {
                var val = record.get(dataIndex);                
 
                if (!Ext.isEmpty(value, false) && val != value) {
                    return false;
                }
                
                return true;
            };
 
            var getRecordFilter = function () {
                var f = [];
 
                f.push({
                    filter: function (record) {                         
                        return filterString(#{ComboBox1}.getValue(), "company", record);
                    }
                });
                 
                f.push({
                    filter: function (record) {                         
                        return filterNumber(#{PriceFilter}.getValue(), "price", record);
                    }
                });
                 
                f.push({
                    filter: function (record) {                         
                        return filterNumber(#{ChangeFilter}.getValue(), "change", record);
                    }
                });
                 
                f.push({
                    filter: function (record) {                         
                        return filterNumber(#{PctChangeFilter}.getValue(), "pctChange", record);
                    }
                });
                 
                f.push({
                    filter: function (record) {                         
                        return filterDate(#{LastChangeFilter}.getValue(), "lastChange", record);
                    }
                });
 
                var len = f.length;
                 
                return function (record) {
                    for (var i = 0; i < len; i++) {
                        if (!f[i].filter(record)) {
                            return false;
                        }
                    }
                    return true;
                };
            };
        </script>
    </ext:XScript>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />        
         
        <ext:GridPanel
            ID="GridPanel1"
            runat="server"
            StripeRows="true"
            Title="Array Grid"
            TrackMouseOver="true"
            Width="600"
            Height="350"
            AutoExpandColumn="Company">
            <Store>
                <ext:Store ID="Store1" runat="server">
                    <Reader>
                        <ext:ArrayReader>
                            <Fields>
                                <ext:RecordField Name="company" />
                                <ext:RecordField Name="price" Type="Float" />
                                <ext:RecordField Name="change" Type="Float" />
                                <ext:RecordField Name="pctChange" Type="Float" />
                                <ext:RecordField Name="lastChange" Type="Date" DateFormat="MM/dd/yyyy" />
                            </Fields>
                        </ext:ArrayReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column ColumnID="Company" Header="Company" Width="160" DataIndex="company" />
                    <ext:Column Header="Price" Width="75" DataIndex="price">
                        <Renderer Format="UsMoney" />
                    </ext:Column>
                    <ext:Column Header="Change" Width="75" DataIndex="change">
                        <Renderer Fn="change" />
                    </ext:Column>
                    <ext:Column Header="Change" Width="75" DataIndex="pctChange">
                        <Renderer Fn="pctChange" />
                    </ext:Column>
                    <ext:DateColumn Header="Last Updated" Width="95" DataIndex="lastChange" />
                    <ext:Column Width="28" DataIndex="company" Sortable="false" MenuDisabled="true" Header="&nbsp;" Fixed="true">
                        <Renderer Handler="return '';" />
                    </ext:Column>
                </Columns>
            </ColumnModel>
             
            <SelectionModel>
                <ext:RowSelectionModel runat="server" SingleSelect="true" />
            </SelectionModel>
             
            <View>
                <ext:GridView runat="server">
                    <HeaderRows>
                        <ext:HeaderRow>
                            <Columns>
                                <ext:HeaderColumn Cls="x-small-editor">
                                    <Component>
                                        <ext:ComboBox 
                                            ID="ComboBox1" 
                                            runat="server"
                                            TriggerAction="All"
                                            Mode="Local"
                                            DisplayField="company"
                                            ValueField="company">
                                            <Store>
                                                <ext:Store runat="server">
                                                    <Reader>
                                                        <ext:ArrayReader>
                                                            <Fields>
                                                                <ext:RecordField Name="company" />
                                                            </Fields>
                                                        </ext:ArrayReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Listeners>
                                                <Select Handler="applyFilter(this);" />
                                            </Listeners>     
                                        </ext:ComboBox>
                                    </Component>
                                </ext:HeaderColumn>
                                 
                                <ext:HeaderColumn Cls="x-small-editor">
                                    <Component>
                                        <ext:TextField ID="PriceFilter" runat="server" EnableKeyEvents="true">
                                            <Listeners>
                                                <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                            </Listeners>
                                        </ext:TextField>
                                    </Component>
                                </ext:HeaderColumn>
                                 
                                <ext:HeaderColumn Cls="x-small-editor">
                                    <Component>
                                        <ext:TextField ID="ChangeFilter" runat="server"  EnableKeyEvents="true">
                                            <Listeners>
                                                <KeyUp Handler="applyFilter(this);" Buffer="250" />
                                            </Listeners>
                                        </ext:TextField>
                                    </Component>
                                </ext:HeaderColumn>
                                 
                                <ext:HeaderColumn Cls="x-small-editor">
                                    <Component>
                                        <ext:TextField ID="PctChangeFilter" runat="server"  EnableKeyEvents="true">
                                            <Listeners>
                                                <KeyUp Handler="applyFilter(this);" Buffer="250" />
                                            </Listeners>
                                        </ext:TextField>
                                    </Component>
                                </ext:HeaderColumn>
                                 
                                <ext:HeaderColumn Cls="x-small-editor">
                                    <Component>
                                        <ext:DateField ID="LastChangeFilter" runat="server" Editable="false">
                                            <Listeners>
                                                <Select Handler="applyFilter(this);" />
                                            </Listeners>
                                        </ext:DateField>
                                    </Component>                                    
                                </ext:HeaderColumn>
                                                               
                                <ext:HeaderColumn AutoWidthElement="false">
                                    <Component>
                                        <ext:Button ID="ClearFilterButton" runat="server" Icon="Cancel">
                                            <ToolTips>
                                                <ext:ToolTip runat="server" Html="Clear filter" />
                                            </ToolTips>
                                             
                                            <Listeners>
                                                <Click Handler="clearFilter(null);" />
                                            </Listeners>                                            
                                        </ext:Button>
                                    </Component>
                                </ext:HeaderColumn>
                            </Columns>
                        </ext:HeaderRow>
                    </HeaderRows>
                </ext:GridView>
            </View>
        </ext:GridPanel>  
    </form>
</body>
</html>