<%@ Page Language="C#" %>

<%@ Import Namespace="System.Xml" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.Store1.DataSource = this.TestData;
            this.Store1.DataBind();
        }
    }

    private object[] TestData
    {
        get
        {
            var firstNames = new string[] { "Ed", "Tommy", "Aaron", "Abe", "Jamie", "Adam", "Dave", "David", "Jay" };
            var lastNames = new string[] { "Spencer", "Maintz", "Conran", "Elias", "Avins", "Mishcon", "Kaneda", "Davis", "Robinson" };
            var ratings = new int[] { 1, 2, 3, 4, 5 };
            var salaries = new int[] { 100, 400, 900, 1500, 1000000 };

            var data = new object[25];
            var rnd = new Random();

            for (int i = 0; i < 25; i++)
            {
                var ratingId = rnd.Next(ratings.Length);
                var salaryId = rnd.Next(salaries.Length);
                var firstNameId = rnd.Next(firstNames.Length);
                var lastNameId = rnd.Next(lastNames.Length);

                var rating = ratings[ratingId];
                var salary = salaries[salaryId];
                var name = String.Format("{0} {1}", firstNames[firstNameId], lastNames[lastNameId]);

                data[i] = new object[] { name, rating, salary };
            }

            return data;
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Multiple Sorting- Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    

    <script type="text/javascript">
        var getSorters = function () {
            var sorters = [];
            
            Ext.each(Toolbar1.findByType("button"), function (button) {
                sorters.push(button.sortData);
            }, this);
            
            return sorters;
        };
        
        var sort = function (button, changeDirection) {
            var sortData = button.sortData,
                iconCls  = button.iconCls;
            
            if (sortData != undefined) {
                if (changeDirection !== false) {
                    button.sortData.direction = button.sortData.direction.toggle("ASC", "DESC");
                    button.setIconClass(iconCls.toggle("icon-sortascending", "icon-sortdescending"));
                }
                
                Store1.clearFilter();
                Store1.sort(getSorters(), "ASC");
            }
        };
        
        var createItem = function (data) {
            var column = getColumnFromDragDrop(data);
            
            return createSorterButton({
                text    : column.header,
                sortData: {
                    field     : column.dataIndex,
                    direction : "ASC"
                }
            });
        };
        
        var getColumnFromDragDrop = function (data) {
            var index    = data.header.cellIndex,
                colModel = GridPanel1.colModel,
                column   = colModel.getColumnById(colModel.getColumnId(index));

            return column;
        };
        
        var createSorterButton = function (config) {
            config = config || {};
                  
            Ext.applyIf(config, {
                listeners : {
                    click : function (button, e) {
                        sort(button, true);                    
                    }
                },
                iconCls     : config.sortData.direction.toLowerCase() == "asc" ? "icon-sortascending" : "icon-sortdescending",
                reorderable : true,
                menu : new Ext.menu.Menu({
                    items : [
                        {
                            text    : "Remove",
                            handler : remove
                        }
                    ]
                })
            });
            
            return new Ext.SplitButton(config);
        };
        
        var canDrop = function (dragSource, event, data) {
            var sorters = getSorters(),
                column  = getColumnFromDragDrop(data);

            for (var i = 0; i < sorters.length; i++) {
                if (sorters[i].field == column.dataIndex) {
                    return false;
                }
            }

            return true;
        };
        
        var remove = function (menu) {
            Toolbar1.remove(menu.parentMenu.ownerCt);
            Store1.clearFilter();
            Store1.sort(getSorters(), "ASC");
        };
    </script>

</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <h1>Multiple Grid Sorting Example</h1>
        
        <p>This example demontrates how to sort a grid by more than a single field.</p>
        
        <p>The store is initially sorted by Rating DESC then by Salary ASC, as indicated in the toolbar.</p>
        
        <p>Click a button to change sorting direction, drag buttons to reorder them.</p>
        
        <p>This example also uses the ToolbarDroppable plugin to allow column headers to be dropped onto the toolbar. Try it with 
          Name column header. Each column is only allowed one button, so Rating and Salary cannot be dropped in this example.</p>
        
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server" 
            StripeRows="true"
            Title="Array Grid" 
            Width="600" 
            Height="300"
            AutoExpandColumn="Company">
            <Store>
                <ext:Store ID="Store1" runat="server">
                    <Reader>
                        <ext:ArrayReader>
                            <Fields>
                                <ext:RecordField Name="name" />
                                <ext:RecordField Name="rating" Type="Int" />
                                <ext:RecordField Name="salary" Type="Float" />
                            </Fields>
                        </ext:ArrayReader>
                    </Reader>            
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column ColumnID="Company" Header="Name" Width="160" DataIndex="name" Sortable="false" /> 
                    <ext:Column Header="Rating" Width="125" DataIndex="rating" Sortable="false"/>
                    <ext:Column Header="Salary" Width="125" DataIndex="salary" Sortable="false">
                        <Renderer Format="UsMoney" />
                    </ext:Column>
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" />
            </SelectionModel>
            <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <ext:ToolbarTextItem runat="server" Text="Sorting order:" />
                        <ext:ToolbarSeparator runat="server" />
                        <ext:SplitButton 
                            runat="server" 
                            Text="Rating" 
                            Icon="SortDescending"
                            OnClientClick="sort(this, true);"
                            SortData="={{field:'rating',direction:'DESC'}}"
                            Reorderable="true">
                            <Menu>
                                <ext:Menu runat="server">
                                    <Items>
                                        <ext:MenuItem runat="server" Text="Remove" OnClientClick="remove(this);" />
                                    </Items>
                                </ext:Menu>
                            </Menu>
                        </ext:SplitButton>
                        <ext:SplitButton 
                            runat="server" 
                            Text="Salary" 
                            Icon="SortAscending"
                            OnClientClick="sort(this, true);"
                            SortData="={{field:'salary',direction:'ASC'}}"
                            Reorderable="true">
                            <Menu>
                                <ext:Menu runat="server">
                                    <Items>
                                        <ext:MenuItem runat="server" Text="Remove" OnClientClick="remove(this);" />
                                    </Items>
                                </ext:Menu>
                            </Menu>
                        </ext:SplitButton>
                    </Items>
                    <Plugins>
                        <ext:ToolbarReorderer runat="server">
                            <Listeners>
                                <Reorder Fn="sort" />
                            </Listeners>
                        </ext:ToolbarReorderer>
                        <ext:ToolbarDroppable ID="ToolbarDroppable1" runat="server">
                            <CreateItem Fn="createItem" />
                            <CanDrop Fn="canDrop" />
                        </ext:ToolbarDroppable>
                    </Plugins>
                    <Listeners>
                        <AfterLayout Handler="Store1.sort(getSorters(), 'ASC');" />
                    </Listeners>
                </ext:Toolbar>
            </TopBar>
            <Listeners>
                <Render Handler="ToolbarDroppable1.addDDGroup(this.getView().columnDrag.ddGroup);" />
            </Listeners>
        </ext:GridPanel> 
    </form>
</body>
</html>
