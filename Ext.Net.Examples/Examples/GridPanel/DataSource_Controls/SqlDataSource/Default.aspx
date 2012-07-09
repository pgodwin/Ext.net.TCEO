<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel with SqlDataSource - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .x-grid3-td-fullName .x-grid3-cell-inner {
            font-family : tahoma, verdana;
            display     : block;
            font-weight : normal;
            font-style  : normal;
            color       : #385F95;
            white-space : normal;
        }
        
        .x-grid3-row-body p {
            margin : 5px 5px 10px 5px !important;
            width  : 99%;
            color  : Gray;
        }
    </style>

    <script type="text/javascript">
        var fullName = function (value, metadata, record, rowIndex, colIndex, store) {
            return "<b>" + record.data.LastName + " " + record.data.FirstName + "</b>";
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <asp:SqlDataSource 
            ID="SqlDataSource1" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            SelectCommand="
            SELECT 
                [EmployeeID], 
                [LastName], 
                [FirstName], 
                [Title], 
                [TitleOfCourtesy], 
                [BirthDate], 
                [HireDate], 
                [Address], 
                [City], 
                [Region], 
                [PostalCode], 
                [Country], 
                [HomePhone], 
                [Extension], 
                [Notes] 
            FROM [Employees]"
            />
        
        <ext:GridPanel 
            runat="server" 
            Title="Employees"
            Frame="true" 
            Height="600">
            <Store>
                <ext:Store runat="server" DataSourceID="SqlDataSource1">
                    <Reader>
                        <ext:JsonReader IDProperty="EmployeeID">
                            <Fields>
                                <ext:RecordField Name="FirstName" />
                                <ext:RecordField Name="LastName" />
                                <ext:RecordField Name="Title" />
                                <ext:RecordField Name="TitleOfCourtesy" />
                                <ext:RecordField Name="BirthDate" Type="Date" />
                                <ext:RecordField Name="HireDate" Type="Date" />
                                <ext:RecordField Name="Address" />
                                <ext:RecordField Name="City" />
                                <ext:RecordField Name="Region" />
                                <ext:RecordField Name="PostalCode" />
                                <ext:RecordField Name="Country" />
                                <ext:RecordField Name="HomePhone" />
                                <ext:RecordField Name="Extension" />
                                <ext:RecordField Name="Notes" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column ColumnID="fullName" Header="Full Name" Width="150" DataIndex="LastName">
                        <Renderer Fn="fullName" />
                    </ext:Column>
                    <ext:Column DataIndex="Title" Header="Title" Width="150" />
                    <ext:Column DataIndex="TitleOfCourtesy" Header="Title Of Courtesy" Width="150" />
                    <ext:DateColumn DataIndex="BirthDate" Header="BirthDate" Width="110" Format="yyyy-MM-dd" />
                    <ext:DateColumn DataIndex="HireDate" Header="HireDate" Width="110" Format="yyyy-MM-dd" />
                    <ext:Column DataIndex="Address" Header="Address" Width="150" />
                    <ext:Column DataIndex="City" Header="City" Width="100" />
                    <ext:Column DataIndex="Region" Header="Region" Width="100" />
                    <ext:Column DataIndex="PostalCode" Header="PostalCode" Width="100" />
                    <ext:Column DataIndex="Country" Header="Country" Width="100" />
                    <ext:Column DataIndex="HomePhone" Header="HomePhone" Width="150" />
                    <ext:Column DataIndex="Extension" Header="Extension" Width="100" />
                </Columns>
            </ColumnModel>
            <View>
                <ext:GridView runat="server" EnableRowBody="true">
                    <GetRowClass Handler="rowParams.body = '<p>' + record.data.Notes + '</p>'; return 'x-grid3-row-expanded';" />
                </ext:GridView>
            </View>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" />
            </SelectionModel>
        </ext:GridPanel>
    </form>
</body>
</html>
