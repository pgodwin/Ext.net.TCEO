<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script type="text/javascript">
        var commandHandler = function (cmd, record) {
            switch (cmd) {
                case "edit":
                    var win = CustomerDetailsWindow;
                    win.autoLoad.params.id = record.id;
                    win.setTitle(record.data.CompanyName);
                    win.show();
                    break;
                case "delete":
                    Ext.Msg.confirm('Alert', 'Delete Record?', function (btn) {
                        if (btn == "yes") {
                            dsCustomers.remove(record);
                            dsCustomers.save();
                        }
                    });
                    break;
            }
        };
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />

    <ext:ViewPort runat="server" Layout="fit">
        <Items>
            <ext:GridPanel 
                ID="GridPanel1" 
                runat="server" 
                Header="false"
                Border="false"
                TrackMouseOver="true"
                AutoExpandColumn="CompanyName">
                <Store>
                    <ext:Store 
                        ID="dsCustomers" 
                        runat="server" 
                        RemoteSort="true" 
                        UseIdConfirmation="true">
                        <Proxy>
                            <ext:HttpProxy Url="/Data/GetCustomers/" />
                        </Proxy>
                        <UpdateProxy>
                            <ext:HttpWriteProxy Url="/Data/SaveCustomersWithConfirmation/" />
                        </UpdateProxy>
                        <Reader>
                            <ext:JsonReader IDProperty="CustomerID" Root="data" TotalProperty="total">
                                <Fields>
                                    <ext:RecordField Name="CustomerID" SortDir="ASC"/>
                                    <ext:RecordField Name="CompanyName" />
                                    <ext:RecordField Name="ContactName" />
                                    <ext:RecordField Name="Phone" />
                                    <ext:RecordField Name="Fax" />
                                    <ext:RecordField Name="Region" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                        <BaseParams>
                            <ext:Parameter Name="limit" Value="15" Mode="Raw" />
                            <ext:Parameter Name="start" Value="0" Mode="Raw" />
                            <ext:Parameter Name="dir" Value="ASC" />
                            <ext:Parameter Name="sort" Value="CustomerID" />
                        </BaseParams>
                        <SortInfo Field="CustomerID" Direction="ASC" />
                    </ext:Store>
                </Store>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:Column ColumnID="CustomerID" DataIndex="CustomerID" Header="ID">
                            <Editor>
                                <ext:DisplayField runat="server" StyleSpec="padding-left:5px;font:11px arial, tahoma, helvetica, sans-serif;" />
                            </Editor>
                        </ext:Column>
                        <ext:Column ColumnID="CompanyName" DataIndex="CompanyName" Header="Company Name">
                            <Editor>
                                <ext:TextField runat="server" AllowBlank="false" />
                            </Editor>
                        </ext:Column>
                        <ext:Column ColumnID="ContactName" DataIndex="ContactName" Header="Contact Name" Width="150">
                            <Editor>
                                <ext:TextField runat="server" AllowBlank="false" />
                            </Editor>
                        </ext:Column>
                        <ext:Column ColumnID="Phone" DataIndex="Phone" Header="Phone">
                            <Editor>
                                <ext:TextField runat="server" />
                            </Editor>
                        </ext:Column>
                        <ext:Column ColumnID="Fax" DataIndex="Fax" Header="Fax">
                            <Editor>
                                <ext:TextField runat="server" />
                            </Editor>
                        </ext:Column>
                        <ext:Column ColumnID="Region" DataIndex="Region" Header="Region">
                            <Editor>
                                <ext:TextField runat="server" />
                            </Editor>
                        </ext:Column>
                        <ext:CommandColumn Width="25" Hideable="false">
                            <Commands>
                                <ext:GridCommand CommandName="edit" Icon="ApplicationFormEdit">
                                    <ToolTip Text="Edit" />
                                </ext:GridCommand>
                            </Commands>
                            <PrepareToolbar Handler="toolbar.setVisible(!record.newRecord);" />
                        </ext:CommandColumn>
                        <ext:CommandColumn Width="25" Hideable="false">
                            <Commands>
                                <ext:GridCommand CommandName="delete" Icon="Cross">
                                    <ToolTip Text="Delete" />
                                </ext:GridCommand>
                            </Commands>
                            <PrepareToolbar Handler="toolbar.setVisible(!record.newRecord);" />
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <TopBar>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:Button ID="Button1" runat="server" Text="Save" Icon="Disk">
                                <Listeners>
                                    <Click Handler="#{dsCustomers}.save();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="Button3" runat="server" Text="Add" Icon="Add">
                                <Listeners>
                                    <Click Handler="#{GridPanel1}.insertRecord(0, {});#{GridPanel1}.getView().focusRow(0);#{GridPanel1}.startEditing(0, 0);" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="Button2" runat="server" Text="Reject Changes" Icon="ArrowUndo">
                                <Listeners>
                                    <Click Handler="#{dsCustomers}.rejectChanges();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Plugins>
                    <ext:RowEditor runat="server" ErrorSummary="false" />
                </Plugins>
                <SelectionModel>
                    <ext:RowSelectionModel runat="server" />
                </SelectionModel>
                <BottomBar>
                    <ext:PagingToolbar runat="server" PageSize="15" />
                </BottomBar>
                <Listeners>
                    <Command Fn="commandHandler" />
                    <BeforeEdit Handler="return !(e.field=='CustomerID' && !e.record.newRecord);" />
                </Listeners>
                <LoadMask ShowMask="true" />
                <SaveMask ShowMask="true" />
            </ext:GridPanel>
        </Items>
    </ext:ViewPort>
    
    <ext:Window 
        ID="CustomerDetailsWindow" 
        runat="server" 
        Icon="ApplicationFormEdit" 
        Width="800" 
        Height="600" 
        Hidden="true" 
        Modal="true"
        Constrain="true">
        <AutoLoad 
            Url="/Customer/CustomerDetails/" 
            Mode="IFrame" 
            TriggerEvent="show" 
            ReloadOnEvent="true" 
            ShowMask="true" 
            MaskMsg="Loading customer...">
            <Params>
                <ext:Parameter Name="id" Value="" Mode="Value" />
            </Params>
        </AutoLoad>
        <Buttons>
            <ext:Button runat="server" Text="Close">
                <Listeners>
                    <Click Handler="#{CustomerDetailsWindow}.hide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
        <Listeners>
            <Hide Handler="if(this.getBody().customerChanged) { dsCustomers.reload(); };" />
        </Listeners>
    </ext:Window>
</body>
</html>
