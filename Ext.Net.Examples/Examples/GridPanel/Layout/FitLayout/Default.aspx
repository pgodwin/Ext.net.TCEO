<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Store1.DataSource = this.Jobs;
        this.Store1.DataBind();
    }
    
    private List<Job> Jobs
    {
        get
        {
            List<Job> jobs = new List<Job>();

            for (int i = 1; i <= 50; i++)
            {
                jobs.Add(new Job(
                            i, 
                            "Task" + i.ToString(), 
                            DateTime.Today.AddDays(i), 
                            DateTime.Today.AddDays(i + i), 
                            (i%3 == 0)));
            }

            return jobs;
        }
    }

    public class Job
    {
        public Job(int id, string name, DateTime start, DateTime end, bool completed)
        {
            this.ID = id;
            this.Name = name;
            this.Start = start;
            this.End = end;
            this.Completed = completed;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Completed { get; set; }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel with FitLayout - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:Store ID="Store1" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="Name" />
                        <ext:RecordField Name="Start" Type="Date" />
                        <ext:RecordField Name="End" Type="Date" />
                        <ext:RecordField Name="Completed" Type="Boolean" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        
        <ext:Window 
            ID="Window1" 
            runat="server"
            Collapsible="true"
            Maximizable="true"
            Icon="Lorry" 
            Title="Job List"
            Width="600"
            Height="300"
            X="50"
            Y="50"
            CenterOnLoad="false"
            Layout="Fit">
            <Items>
                <ext:GridPanel
                    ID="GridPanel1" 
                    runat="server" 
                    StoreID="Store1"
                    StripeRows="true"
                    Header="false"
                    Border="false"
                    AutoExpandColumn="Name">
                    <LoadMask ShowMask="false" />
                    <SelectionModel>
                        <ext:RowSelectionModel 
                            ID="SelectedRowModel1" 
                            runat="server" 
                            SingleSelect="true" 
                            />
                    </SelectionModel>            
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:Column 
                                Header="ID" 
                                Width="40" 
                                Sortable="true" 
                                DataIndex="ID" 
                                />
                            <ext:Column 
                                ColumnID="Name" 
                                Header="Job Name" 
                                Sortable="true" 
                                DataIndex="Name" 
                                />
                            <ext:DateColumn 
                                ColumnID="Start" 
                                Header="Start" 
                                Width="120" 
                                Sortable="true" 
                                DataIndex="Start"
                                Format="yyyy-MM-dd"
                                />
                            <ext:DateColumn 
                                ColumnID="End" 
                                Header="End" 
                                Width="120" 
                                Sortable="true" 
                                DataIndex="End"
                                Format="yyyy-MM-dd"
                                />
                            <ext:Column 
                                ColumnID="Completed" 
                                Header="Completed" 
                                Width="80" 
                                Sortable="true" 
                                DataIndex="Completed">
                                <Renderer Handler="return (value) ? 'Yes':'No';" />
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <Plugins>
                        <ext:GridFilters runat="server" ID="GridFilters1" Local="true">
                            <Filters>
                                <ext:NumericFilter DataIndex="ID" />
                                <ext:StringFilter DataIndex="Name" />
                                <ext:DateFilter DataIndex="Start">
                                    <DatePickerOptions runat="server" TodayText="Now" />
                                </ext:DateFilter>
                                <ext:DateFilter DataIndex="End">
                                    <DatePickerOptions runat="server" TodayText="Now" />
                                </ext:DateFilter>                        
                                <ext:BooleanFilter DataIndex="Completed" />
                            </Filters>
                        </ext:GridFilters>
                    </Plugins>
                    <BottomBar>
                        <ext:PagingToolbar 
                            ID="PagingToolBar1" 
                            runat="server" 
                            StoreID="Store1"
                            PageSize="10" 
                            DisplayInfo="true"
                            DisplayMsg="Displaying Jobs {0} - {1} of {2}"
                            />
                    </BottomBar>
                </ext:GridPanel>
            </Items>
        </ext:Window>
    </form>
</body>
</html>