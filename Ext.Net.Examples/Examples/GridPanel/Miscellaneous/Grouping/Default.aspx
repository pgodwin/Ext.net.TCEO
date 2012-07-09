<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GridPanel GroupingView with EnableRowBody - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        // this "setGroupStyle" function is called when the GroupingView is refreshed.     
        var setGroupStyle = function (view) {
            // get an instance of the Groups
            var groups = view.getGroups();

            for (var i = 0; i < groups.length; i++) {
                var spans =  Ext.query("span", groups[i]);
                
                if (spans && spans.length > 0){
                    // Loop through the Groups, the do a query to find the <span> with our ColorCode
                    // Get the "id" from the <span> and split on the "-", the second array item should be our ColorCode
                    var color = "#" + spans[0].id.split("-")[1];

                    // Set the "background-color" of the original Group node.
                    Ext.get(groups[i]).setStyle("background-color", color);
                }
            }
        };
    </script>    
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />

        <ext:GridPanel
            ID="GridPanel1"
            runat="server" 
            Collapsible="true" 
            Width="600" 
            Height="350" 
            AutoExpandColumn="Common" 
            Title="Plants" 
            Frame="true">
            <Store>
                <ext:Store runat="server" GroupField="Light">
                    <Proxy>
                        <ext:HttpProxy Method="GET" Url="../../Shared/PlantService.asmx/Plants" />
                    </Proxy>
                    <Reader>
                        <ext:XmlReader Record="Plant">
                            <Fields>
                                <ext:RecordField Name="Common" />
                                <ext:RecordField Name="Botanical" />
                                <ext:RecordField Name="Zone" Type="Int" />
                                <ext:RecordField Name="ColorCode" />
                                <ext:RecordField Name="Light" />
                                <ext:RecordField Name="Price" Type="Float" />
                                <ext:RecordField Name="Availability" Type="Date" />
                                <ext:RecordField Name="Indoor" Type="Boolean" />
                            </Fields>
                        </ext:XmlReader>
                    </Reader>
                    <SortInfo Field="Common" Direction="ASC" />
                </ext:Store>
            </Store>
            <ColumnModel runat="server">
                <Columns>
                    <ext:Column ColumnID="Common" Header="Common Name" DataIndex="Common" Width="220" />
                    <ext:Column Header="Light" DataIndex="Light" Width="130" />
                    <ext:Column Header="Price" DataIndex="Price" Width="70" Align="right" Groupable="false">
                        <Renderer Format="UsMoney" />
                    </ext:Column>
                    <ext:DateColumn 
                        Header="Available" 
                        DataIndex="Availability" 
                        Width="95" 
                        Groupable="false" 
                        Format="yyyy-MM-dd" 
                        />
                    <ext:Column Header="Indoor?" DataIndex="Indoor" Width="55" />
                </Columns>
            </ColumnModel>
            <LoadMask ShowMask="true" />
            <SelectionModel>
                <ext:RowSelectionModel runat="server" />
            </SelectionModel>
            <View>
                <ext:GroupingView  
                    ID="GroupingView1"
                    HideGroupedColumn="true"
                    runat="server" 
                    ForceFit="true"
                    StartCollapsed="true"
                    GroupTextTpl='<span id="ColorCode-{[values.rs[0].data.ColorCode]}"></span>{text} ({[values.rs.length]} {[values.rs.length > 1 ? "Items" : "Item"]})'
                    EnableRowBody="true">
                    <Listeners>
                        <Refresh Fn="setGroupStyle" />
                    </Listeners>
                    <GetRowClass Handler="var d = record.data; rowParams.body = String.format('<div style=\'padding:0 5px 5px 5px;\'>The {0} [{1}] requires light conditions of <i>{2}</i>.<br /><b>Price: {3}</b></div>', d.Common, d.Botanical, d.Light, Ext.util.Format.usMoney(d.Price));" />
                </ext:GroupingView>
            </View>
            <Buttons>
                <ext:Button 
                    ID="btnToggleGroups" 
                    runat="server" 
                    Text="Expand/Collapse Groups"
                    Icon="TableSort"
                    Style="margin-left: 6px;"
                    AutoPostBack="false">
                    <Listeners>
                        <Click Handler="#{GridPanel1}.getView().toggleAllGroups();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:GridPanel>
    </form>
</body>
</html>
