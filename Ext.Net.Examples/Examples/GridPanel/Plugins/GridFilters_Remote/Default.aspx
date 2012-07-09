<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.ObjectModel" %>
<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        List<object> data = FiltersTestData.Data;

        string s = e.Parameters[this.GridFilters1.ParamPrefix];
        //or with hardcoding - string s = e.Parameters["gridfilters"];;
        
        
        //-- start filtering ------------------------------------------------------------
        if (!string.IsNullOrEmpty(s))
        {
            FilterConditions fc = new FilterConditions(s);

            foreach (FilterCondition condition in fc.Conditions)
            {
                Comparison comparison = condition.Comparison;
                string field = condition.Name;
                FilterType type = condition.FilterType;
                
                object value;
                switch(condition.FilterType)
                {
                    case FilterType.Boolean:
                        value = condition.ValueAsBoolean;
                       break;
                    case FilterType.Date:
                        value = condition.ValueAsDate;
                        break;
                    case FilterType.List:
                        value = condition.ValuesList;
                        break;
                    case FilterType.Numeric:
                        if (data.Count > 0 && data[0].GetType().GetProperty(field).PropertyType == typeof(int))
                        {
                            value = condition.ValueAsInt;
                        }
                        else
                        {
                            value = condition.ValueAsDouble;
                        }
                        
                        break;
                    case FilterType.String:
                        value = condition.Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                data.RemoveAll(
                    item =>
                        {
                            object oValue = item.GetType().GetProperty(field).GetValue(item, null);
                            IComparable cItem = oValue as IComparable;
                            
                            switch (comparison)
                            {
                                case Comparison.Eq:
                                    
                                    switch(type)
                                    {
                                        case FilterType.List:
                                            return !(value as ReadOnlyCollection<string>).Contains(oValue.ToString());
                                        case FilterType.String:
                                            return !oValue.ToString().StartsWith(value.ToString());
                                        default:
                                            return !cItem.Equals(value);
                                    }
                                    
                                case Comparison.Gt:
                                    return cItem.CompareTo(value) < 1;
                                case Comparison.Lt:
                                    return cItem.CompareTo(value) > -1;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }
                );
            }
        }
        //-- end filtering ------------------------------------------------------------


        //-- start sorting ------------------------------------------------------------
        if (!string.IsNullOrEmpty(e.Sort))
        {
            data.Sort(delegate(object x, object y)
            {
                object a;
                object b;

                int direction = e.Dir == Ext.Net.SortDirection.DESC ? -1 : 1;

                a = x.GetType().GetProperty(e.Sort).GetValue(x, null);
                b = y.GetType().GetProperty(e.Sort).GetValue(y, null);
                return CaseInsensitiveComparer.Default.Compare(a, b) * direction;
            });
        }
        //-- end sorting ------------------------------------------------------------


        //-- start paging ------------------------------------------------------------
        var limit = e.Limit;
        
        if ((e.Start + e.Limit) > data.Count)
        {
            limit = data.Count - e.Start;
        }

        List<object> rangeData = (e.Start < 0 || limit < 0) ? data : data.GetRange(e.Start, limit);
        //-- end paging ------------------------------------------------------------

        //The Total can be set in RefreshData event as below
        //or (Store1.Proxy.Proxy as PageProxy).Total in anywhere
        //Please pay attention that the Total make a sence only during DirectEvent because
        //the Store with PageProxy get/refresh data using ajax request

        e.Total = data.Count;
        
        this.GridPanel1.GetStore().DataSource = rangeData;
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel with Remote Filtering, Sorting and Paging - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>GridPanel with Remote Filtering, Sorting and Paging</h1>
        
        <p>Please see column header menu for apllying filters</p>
        
        <ext:Window 
            ID="Window1" 
            runat="server" 
            Width="700" 
            Height="400" 
            Closable="false"
            Collapsible="true" 
            Title="Example"
            Maximizable="true"
            Layout="Fit">
            <Items>
                <ext:GridPanel ID="GridPanel1" runat="server" Border="false">
                    <Store>
                        <ext:Store runat="server" RemoteSort="true" OnRefreshData="Store1_RefreshData">
                            <Proxy>
                                <ext:PageProxy />
                            </Proxy>
                            <Reader>
                                <ext:JsonReader IDProperty="Id">
                                    <Fields>
                                        <ext:RecordField Name="Id" Type="Int" />
                                        <ext:RecordField Name="Company" Type="String" />
                                        <ext:RecordField Name="Price" Type="Float" />
                                        <ext:RecordField Name="Date" Type="Date" DateFormat="yyyy-MM-ddTHH:mm:ss" />
                                        <ext:RecordField Name="Size" Type="String" />
                                        <ext:RecordField Name="Visible" Type="Boolean" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                            <BaseParams>
                                <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                <ext:Parameter Name="limit" Value="10" Mode="Raw" />
                                <ext:Parameter Name="sort" Value="" />
                                <ext:Parameter Name="dir" Value="" />
                            </BaseParams>
                            <SortInfo Field="Company" Direction="ASC" />
                        </ext:Store>
                    </Store>
                    <ColumnModel runat="server">
			            <Columns>
                            <ext:Column Header="Id" DataIndex="Id" />
                            <ext:Column Header="Company" DataIndex="Company" />
                            <ext:Column Header="Price" DataIndex="Price">
                                <Renderer Format="UsMoney" />
                            </ext:Column>                        
                            <ext:DateColumn Header="Date" DataIndex="Date" Align="Center" Format="yyyy-MM-dd" />
                            <ext:Column Header="Size" DataIndex="Size" />
                            <ext:Column Header="Visible" DataIndex="Visible" Align="Center">
                                <Renderer Handler="return (value) ? 'Yes':'No';" />
                            </ext:Column>
			            </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" />
                    <Plugins>
                        <ext:GridFilters runat="server" ID="GridFilters1">
                            <Filters>
                                <ext:NumericFilter DataIndex="Id" />
                                <ext:StringFilter DataIndex="Company" />
                                <ext:NumericFilter DataIndex="Price" />
                                <ext:DateFilter DataIndex="Date">
                                    <DatePickerOptions runat="server" TodayText="Now" />
                                </ext:DateFilter>
                                <ext:ListFilter DataIndex="Size" Options="extra small,small,medium,large,extra large" />
                                <ext:BooleanFilter DataIndex="Visible" />
                            </Filters>
                        </ext:GridFilters>
                    </Plugins>
                    <BottomBar>
                        <ext:PagingToolbar runat="server" PageSize="10" />
                    </BottomBar>
                </ext:GridPanel>
            </Items>
        </ext:Window>    
    </form>
</body>
</html>