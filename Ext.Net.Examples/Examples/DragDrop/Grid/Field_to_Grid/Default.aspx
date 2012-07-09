<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    private object[] TestData
    {
        get
        {
            DateTime now = DateTime.Now;

            return new object[]
            {
                new object[] { "3m Co", 71.72, 0.02, 0.03, now },
                new object[] { "Alcoa Inc", 29.01, 0.42, 1.47, now },
                new object[] { "Altria Group Inc", 83.81, 0.28, 0.34, now },
                new object[] { "American Express Company", 52.55, 0.01, 0.02, now },
                new object[] { "American International Group, Inc.", 64.13, 0.31, 0.49, now },
                new object[] { "AT&T Inc.", 31.61, -0.48, -1.54, now },
                new object[] { "Boeing Co.", 75.43, 0.53, 0.71, now },
                new object[] { "Caterpillar Inc.", 67.27, 0.92, 1.39, now },
                new object[] { "Citigroup, Inc.", 49.37, 0.02, 0.04, now },
                new object[] { "E.I. du Pont de Nemours and Company", 40.48, 0.51, 1.28, now },
                new object[] { "Exxon Mobil Corp", 68.1, -0.43, -0.64, now },
                new object[] { "General Electric Company", 34.14, -0.08, -0.23, now },
                new object[] { "General Motors Corporation", 30.27, 1.09, 3.74, now },
                new object[] { "Hewlett-Packard Co.", 36.53, -0.03, -0.08, now },
                new object[] { "Honeywell Intl Inc", 38.77, 0.05, 0.13, now },
                new object[] { "Intel Corporation", 19.88, 0.31, 1.58, now },
                new object[] { "International Business Machines", 81.41, 0.44, 0.54, now },
                new object[] { "Johnson & Johnson", 64.72, 0.06, 0.09, now },
                new object[] { "JP Morgan & Chase & Co", 45.73, 0.07, 0.15, now },
                new object[] { "McDonald\"s Corporation", 36.76, 0.86, 2.40, now },
                new object[] { "Merck & Co., Inc.", 40.96, 0.41, 1.01, now },
                new object[] { "Microsoft Corporation", 25.84, 0.14, 0.54, now },
                new object[] { "Pfizer Inc", 27.96, 0.4, 1.45, now },
                new object[] { "The Coca-Cola Company", 45.07, 0.26, 0.58, now },
                new object[] { "The Home Depot, Inc.", 34.64, 0.35, 1.02, now },
                new object[] { "The Procter & Gamble Company", 61.91, 0.01, 0.02, now },
                new object[] { "United Technologies Corporation", 63.26, 0.55, 0.88, now },
                new object[] { "Verizon Communications", 35.57, 0.39, 1.11, now },
                new object[] { "Wal-Mart Stores, Inc.", 45.45, 0.73, 1.63, now }
            };
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.Store1.DataSource = this.TestData;
            this.Store1.DataBind(); 
        }
    }

    protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        this.Store1.DataSource = this.TestData;
        this.Store1.DataBind(); 
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Field to Grid - Ext.NET Examples</title>    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .x-drop-target-active {
	        background-color: #D88;
        }
    </style>

    <script type="text/javascript">
        var template = '<span style="color:{0};">{1}</span>';

        var change = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value);
        };

        var pctChange = function (value) {
            return String.format(template, (value > 0) ? "green" : "red", value + "%");
        };
        
        //---DD-------------------
        
        var getTargetFromEvent = function(e) {
            var grid = GridPanel1,
                t = e.getTarget(grid.view.cellSelector);
            if (t) {
                var rowIndex = grid.view.findRowIndex(t);
                var columnIndex = grid.view.findCellIndex(t);
                if ((rowIndex !== false) && (columnIndex !== false)) {
                    return {
                        node: t,
                        record: grid.store.getAt(rowIndex),
                        fieldName: grid.getColumnModel().getDataIndex(columnIndex)
                    }
                }
            }
        };

        var onNodeEnter = function(target, dd, e, dragData) {
            delete this.dropOK;
            if (!target) {
                return;
            }

            var f = dragData.field;
            if (!f) {
                return;
            }

            var type = target.record.fields.get(target.fieldName).type;
            switch (type) {
                case "float":
                case "int":
                    if (!f.isXType("numberfield")) {
                        return;
                    }
                    break;
                case "date":
                    if (!f.isXType("datefield")) {
                        return;
                    }
                    break;
                case "boolean":
                    if (!f.isXType("checkbox")) {
                        return;
                    }
            }
            this.dropOK = true;
            Ext.fly(target.node).addClass("x-drop-target-active");
        };

        var onNodeOver = function(target, dd, e, dragData) {
            return this.dropOK ? this.dropAllowed : this.dropNotAllowed;
        };

        var onNodeOut = function(target, dd, e, dragData) {
            Ext.fly(target.node).removeClass("x-drop-target-active");
        };

        var onNodeDrop = function(target, dd, e, dragData) {
            if (this.dropOK) {
                target.record.set(target.fieldName, dragData.field.getValue());
                return true;
            }
        };
        
        var getDragData = function(e) {
            var t = e.getTarget("input");
            if (t) {
                e.stopEvent();

                //   Ugly code to "detach" the drag gesture from the input field.
                //   Without this, Opera never changes the mouseover target from the input field
                //   even when dragging outside of the field - it just keeps selecting.
                if (Ext.isOpera) {
                    Ext.fly(t).on("mousemove", function(e1){
                        t.style.visibility = "hidden";
                        (function(){
                            t.style.visibility = "";
                        }).defer(1);
                    }, null, {single:true});
                }
                
                var f = Ext.getCmp(t.id);
                var d = document.createElement("div");
                d.className = "x-form-text";
                d.appendChild(document.createTextNode(t.value));
                Ext.fly(d).setWidth(f.getEl().getWidth());
                return {
                    field: f,
                    ddel: d
                };
            }
        };

        var getRepairXY = function() {
            return this.dragData.field.getEl().getXY();
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:Store ID="Store1" runat="server" OnRefreshData="MyData_Refresh">
            <Reader>
                <ext:ArrayReader>
                    <Fields>
                        <ext:RecordField Name="company" />
                        <ext:RecordField Name="price" Type="Float" />
                        <ext:RecordField Name="change" Type="Float" />
                        <ext:RecordField Name="pctChange" Type="Float" />
                        <ext:RecordField Name="lastChange" Type="Date" DateFormat="yyyy-MM-ddTHH:mm:ss" />
                    </Fields>
                </ext:ArrayReader>
            </Reader>
        </ext:Store>
        
        <ext:GridPanel 
            ID="GridPanel1"
            runat="server" 
            StoreID="Store1" 
            StripeRows="true"
            Title="Grid"
            Width="600"
            Height="350" 
            AutoExpandColumn="Company">
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column ColumnID="Company" Header="Company" DataIndex="company" />
                    <ext:Column Header="Price" DataIndex="price">
                        <Renderer Format="UsMoney" />
                    </ext:Column>
                    <ext:Column Header="Change" DataIndex="change">
                        <Renderer Fn="change" />
                    </ext:Column>
                    <ext:Column Header="Change" DataIndex="pctChange">
                        <Renderer Fn="pctChange" />
                    </ext:Column>
                    <ext:DateColumn Header="Last Updated" DataIndex="lastChange" />
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" />
            </SelectionModel>
            <LoadMask ShowMask="true" />
            <BottomBar>
                <ext:PagingToolbar runat="server" PageSize="10" StoreID="Store1" />
            </BottomBar>
        </ext:GridPanel>
        
        <ext:Panel 
             ID="Panel1"
             runat="server"
             Frame="true"
             Layout="form"
             Width="600"
             StyleSpec="margin-top: 10px"
             LabelWidth="100">
            <Items>
                <ext:TextField runat="server" FieldLabel="Drag this text" Text="test" />
                <ext:NumberField runat="server" FieldLabel="Drag this number" Number="1.2" />
                <ext:DateField runat="server" FieldLabel="Drag this date" SelectedDate="<%# DateTime.Now %>" AutoDataBind="true" />
            </Items>
            
            <Listeners>
                <AfterLayout Handler="this.getEl().select('input').unselectable();" />
            </Listeners>
        </ext:Panel>
        
        <ext:DropZone runat="server" ContainerScroll="true" Target="={GridPanel1.view.scroller}">
            <GetTargetFromEvent Fn="getTargetFromEvent" />
            <OnNodeEnter Fn="onNodeEnter" />
            <OnNodeOver Fn="onNodeOver" />
            <OnNodeOut Fn="onNodeOut" />
            <OnNodeDrop Fn="onNodeDrop" />
        </ext:DropZone>
        
        <ext:DragZone runat="server" Scroll="false" Target="={Panel1.getEl()}">
            <GetDragData Fn="getDragData" />
            <GetRepairXY Fn="getRepairXY" />
        </ext:DragZone>
    </form>
</body>
</html>
