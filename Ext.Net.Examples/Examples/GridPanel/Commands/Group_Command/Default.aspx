<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Group Commands - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var prepare = function (grid, toolbar, groupId, records) {
            // you can prepare ready toolbar
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />

        <ext:GridPanel
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
                        <ext:HttpProxy Method="POST" Url="../../Shared/PlantService.asmx/Plants" />
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
                    <ext:DateColumn Header="Available" Width="95" DataIndex="lastChange" Format="yyyy-MM-dd" />
                    <ext:Column Header="Indoor?" DataIndex="Indoor" Width="55" />
                    <ext:CommandColumn Hidden="true">
                        <GroupCommands>
                            <ext:GridCommand Icon="TableRow" CommandName="SelectGroup">
                                <ToolTip Title="Select" Text="Select all rows of the group" />
                            </ext:GridCommand>
                            <ext:CommandFill />
                            <ext:GridCommand Text="Menu" StandOut="true">
                                <Menu>
                                    <Items>
                                        <ext:MenuCommand CommandName="ItemCommand" Text="Item" />
                                        <ext:MenuCommand CommandName="ItemCommand" Text="Item" />
                                    </Items>
                                </Menu>
                            </ext:GridCommand>
                        </GroupCommands>
                        <PrepareGroupToolbar Fn="prepare" />
                    </ext:CommandColumn>
                </Columns>
            </ColumnModel>
            
            <Listeners>
                <GroupCommand Handler="if(command === 'SelectGroup'){ this.getSelectionModel().selectRecords(records, true); return;} Ext.Msg.alert(command, 'Group id: ' + groupId + '<br/>Count - ' + records.length);" />
            </Listeners>
            
            <LoadMask ShowMask="true" />
            
            <SelectionModel>
                <ext:CheckboxSelectionModel runat="server" RowSpan="2" />
            </SelectionModel>
            
            <View>
                <ext:GroupingView  
                    ID="GroupingView1"
                    HideGroupedColumn="true"
                    runat="server" 
                    ForceFit="true"
                    GroupTextTpl='{text} ({[values.rs.length]} {[values.rs.length > 1 ? "Items" : "Item"]})'
                    EnableRowBody="true">
                    <GetRowClass Handler="var d = record.data; rowParams.body = String.format('<div style=\'padding:0 5px 5px 5px;\'>The {0} [{1}] requires light conditions of <i>{2}</i>.<br /><b>Price: {3}</b></div>', d.Common, d.Botanical, d.Light, Ext.util.Format.usMoney(d.Price));" />
                </ext:GroupingView>
            </View>            
        </ext:GridPanel>
    </form>
</body>
</html>
