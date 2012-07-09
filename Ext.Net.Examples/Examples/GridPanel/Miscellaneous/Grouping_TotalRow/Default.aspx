<%@ Page Language="C#" %>
 
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Collections.Generic" %>
 
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
 
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        CultureInfo ci = new CultureInfo("en-US");

        var store = this.GridPanel1.GetStore();
        
        store.DataSource = new List<Project> 
        { 
            new Project(100, "Ext Forms: Field Anchoring",      112, "Integrate 2.0 Forms with 2.0 Layouts", 6, 150, 0, DateTime.Parse("06/24/2007",ci)),
            new Project(100, "Ext Forms: Field Anchoring",      113, "Implement AnchorLayout", 4, 150, 0, DateTime.Parse("06/25/2007",ci)),
            new Project(100, "Ext Forms: Field Anchoring",      114, "Add support for multiple types of anchors", 4, 150, 0, DateTime.Parse("06/27/2007",ci)),
            new Project(100, "Ext Forms: Field Anchoring",      115, "Testing and debugging", 8, 0, 0, DateTime.Parse("06/29/2007",ci)),
            new Project(101, "Ext Grid: Single-level Grouping", 101, "Add required rendering \"hooks\" to GridView", 6, 100, 0, DateTime.Parse("07/01/2007",ci)),
            new Project(101, "Ext Grid: Single-level Grouping", 102, "Extend GridView and override rendering functions", 6, 100, 0, DateTime.Parse("07/03/2007",ci)),
            new Project(101, "Ext Grid: Single-level Grouping", 103, "Extend Store with grouping functionality", 4, 100, 0, DateTime.Parse("07/04/2007",ci)),
            new Project(101, "Ext Grid: Single-level Grouping", 121, "Default CSS Styling", 2, 100, 0, DateTime.Parse("07/05/2007",ci)),
            new Project(101, "Ext Grid: Single-level Grouping", 104, "Testing and debugging", 6, 100, 0, DateTime.Parse("07/06/2007",ci)),
            new Project(102, "Ext Grid: Summary Rows",          105, "Ext Grid plugin integration", 4, 125, 0, DateTime.Parse("07/01/2007",ci)),
            new Project(102, "Ext Grid: Summary Rows",          106, "Summary creation during rendering phase", 4, 125, 0, DateTime.Parse("07/02/2007",ci)),
            new Project(102, "Ext Grid: Summary Rows",          107, "Dynamic summary updates in editor grids", 6, 125, 0, DateTime.Parse("07/05/2007",ci)),
            new Project(102, "Ext Grid: Summary Rows",          108, "Remote summary integration", 4, 125, 0, DateTime.Parse("07/05/2007",ci)),
            new Project(102, "Ext Grid: Summary Rows",          109, "Summary renderers and calculators", 4, 125, 0, DateTime.Parse("07/06/2007",ci)),
            new Project(102, "Ext Grid: Summary Rows",          110, "Integrate summaries with GroupingView", 10, 125, 0, DateTime.Parse("07/11/2007",ci)),
            new Project(102, "Ext Grid: Summary Rows",          111, "Testing and debugging", 8, 125, 0, DateTime.Parse("07/15/2007",ci))
        };
 
        store.DataBind();
    }
 
    public class Project
    {
        public Project(int projectId, string name, int taskId, string description, int estimate, double rate, double cost, DateTime due)
        {
            this.ProjectID = projectId;
            this.Name = name;
            this.TaskID = taskId;
            this.Description = description;
            this.Estimate = estimate;
            this.Rate = rate;
            this.Due = due;
        }
 
        public int ProjectID { get; set; }
        public string Name { get;set; }
        public int TaskID { get; set; }
        public string Description { get;set; }
        public int Estimate { get;set; }
        public double Rate { get; set; }
        public double Cost { get; set; }
        public DateTime Due { get; set; }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GroupingSummary Plugin with Summary row - Ext.NET Examples</title>
    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .x-grid3-cell-inner {
            font-family : "segoe ui",tahoma, arial, sans-serif;
        }
         
        .x-grid-group-hd div {
            font-family : "segoe ui",tahoma, arial, sans-serif;
        }
         
        .x-grid3-hd-inner {
            font-family : "segoe ui",tahoma, arial, sans-serif;
            font-size   : 12px;
        }
         
        .x-grid3-body .x-grid3-td-Cost {
            background-color : #f1f2f4;
        }
         
        .x-grid3-summary-row .x-grid3-td-Cost {
            background-color : #e1e2e4;
        }    
         
        .total-field{
            background-color : #fff;
            font-weight      : bold !important;                       
            color            : #000;
            border           : solid 1px silver;
            padding          : 2px;
            margin-right     : 5px;
        } 
    </style>
     
    <script type="text/javascript">
        var updateTotal = function (grid) {
            var fbar = grid.getBottomToolbar(),
                column,
                field,
                width,
                data = {},
                c,
                cs = grid.view.getColumnData();
                 
            for (var j = 0, jlen = grid.store.getCount(); j < jlen; j++) {
                var r = grid.store.getAt(j);
                
                for (var i = 0, len = cs.length; i < len; i++) {
                    c = cs[i];
                    column = grid.getColumnModel().columns[i];
 
                    if (column.summaryType) {
                        data[c.name] = Ext.grid.GroupSummary.Calculations[column.summaryType](data[c.name] || 0, r, c.name, data);
                    }
                }
            }
                 
            for (var i=0; i < grid.getColumnModel().columns.length; i++) {
                column = grid.getColumnModel().columns[i];
                                     
                if (column.dataIndex != grid.store.groupField) {
                    field = fbar.findBy(function (item) {
                        return item.dataIndex === column.dataIndex;
                    })[0];
                    
                    c = cs[i];
                    fbar.remove(field, false);
                    fbar.insert(i, field);
                    width = grid.getColumnModel().getColumnWidth(i);
                    field.setWidth(width-5);  
                    field.setValue((column.summaryRenderer || c.renderer)(data[c.name], {}, {}, 0, i, grid.store));
                }
            }            
             
            fbar.doLayout();
        }
    </script>
 
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server"/>
         
        <ext:GridPanel
            ID="GridPanel1"
            runat="server"
            Frame="true"
            StripeRows="true"
            Title="Sponsored Projects"
            AutoExpandColumn="Description"
            Collapsible="true"
            AnimCollapse="false"
            Icon="ApplicationViewColumns"
            TrackMouseOver="false"
            Width="800"
            Height="450"           
            ClicksToEdit="1">
            <Store>
                <ext:Store ID="Store1" runat="server" GroupField="Name">
                    <SortInfo Direction="ASC" Field="Due" />
                    <Reader>
                        <ext:JsonReader IDProperty="TaskID">
                            <Fields>
                                <ext:RecordField Name="ProjectID" />
                                <ext:RecordField Name="Name" />
                                <ext:RecordField Name="TaskID" />
                                <ext:RecordField Name="Description" />
                                <ext:RecordField Name="Estimate" Type="Int" />
                                <ext:RecordField Name="Rate" Type="Float" />
                                <ext:RecordField Name="Due" Type="Date" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:GroupingSummaryColumn
                        ColumnID="Description"
                        Header="Task"
                        Sortable="true"
                        DataIndex="Description"
                        Hideable="false"
                        SummaryType="Count">
                        <SummaryRenderer Handler="return ((value === 0 || value > 1) ? '(' + value +' Tasks)' : '(1 Task)');" />    
                        <Editor>
                            <ext:TextField runat="server" AllowBlank="false" />
                        </Editor>
                    </ext:GroupingSummaryColumn>
                     
                    <ext:Column ColumnID="Name" Header="Project" DataIndex="Name" Width="20" />
                     
                    <ext:GroupingSummaryColumn
                        ColumnID="Due"
                        Width="25"
                        Header="Due Date"
                        Sortable="true"
                        DataIndex="Due"
                        SummaryType="Max">
                        <Renderer Format="Date" FormatArgs="'m/d/Y'" />
                        <Editor>
                            <ext:DateField runat="server" Format="MM/dd/yyyy" />
                        </Editor>
                    </ext:GroupingSummaryColumn>
 
                    <ext:GroupingSummaryColumn
                        Width="20"
                        ColumnID="Estimate"
                        Header="Estimate"
                        Sortable="true"
                        DataIndex="Estimate"
                        SummaryType="Sum">
                        <Renderer Handler="return value +' hours';" />
                        <Editor>
                            <ext:NumberField runat="server" AllowBlank="false" AllowNegative="false" StyleSpec="text-align:left" />
                        </Editor>
                    </ext:GroupingSummaryColumn>
                     
                    <ext:GroupingSummaryColumn
                        Width="20"
                        ColumnID="Rate"
                        Header="Rate"
                        Sortable="true"
                        DataIndex="Rate"
                        SummaryType="Average">
                        <Renderer Format="UsMoney" />
                         <Editor>
                            <ext:NumberField runat="server" AllowBlank="false" AllowNegative="false" StyleSpec="text-align:left" />
                        </Editor>
                    </ext:GroupingSummaryColumn>
                     
                    <ext:GroupingSummaryColumn
                        Width="20"
                        ColumnID="Cost"
                        Header="Cost"
                        Sortable="false"
                        Groupable="false"
                        DataIndex="Cost"
                        CustomSummaryType="totalCost">
                        <Renderer Handler="return Ext.util.Format.usMoney(record.data.Estimate * record.data.Rate);" />
                        <SummaryRenderer Format="UsMoney" />
                    </ext:GroupingSummaryColumn>
                </Columns>
                <Listeners>
                    <WidthChange Handler="updateTotal(#{GridPanel1});" />
                </Listeners>
            </ColumnModel>
            <Listeners>
                <ColumnResize Handler="updateTotal(#{GridPanel1});" />
                <AfterRender Handler="updateTotal(#{GridPanel1});" Delay="100" />
            </Listeners>
            <View>
                <ext:GroupingView
                    runat="server"
                    ForceFit="true"
                    MarkDirty="false"
                    ShowGroupName="false"
                    EnableNoGroups="true"
                    HideGroupedColumn="true"
                    />
            </View>
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" Text="Toggle" ToolTip="Toggle the visibility of summary row">
                            <Listeners>
                                <Click Handler="#{GridPanel1}.getGroupingSummary().toggleSummaries();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Plugins>
                <ext:GroupingSummary runat="server">
                    <Calculations>
                        <ext:JFunction Name="totalCost" Handler="return v + (record.data.Estimate * record.data.Rate);" />
                    </Calculations>
                </ext:GroupingSummary>
            </Plugins>
            <BottomBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:DisplayField ID="ColumnField1" runat="server" DataIndex="Description" Cls="total-field" Text="-" />
                        <ext:DisplayField ID="ColumnField2" runat="server" DataIndex="Due" Cls="total-field" Text="-"  />
                        <ext:DisplayField ID="ColumnField3" runat="server" DataIndex="Estimate" Cls="total-field" Text="-"  />
                        <ext:DisplayField ID="ColumnField4" runat="server" DataIndex="Rate" Cls="total-field" Text="-"  />
                        <ext:DisplayField ID="ColumnField5" runat="server" DataIndex="Cost" Cls="total-field" Text="-"  />
                    </Items>
                </ext:Toolbar>
            </BottomBar>
        </ext:GridPanel>
    </form>
  </body>
</html>