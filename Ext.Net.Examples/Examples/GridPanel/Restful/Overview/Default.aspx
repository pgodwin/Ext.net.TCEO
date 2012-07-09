<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
    
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        ResourceManager.GetInstance(this.Page).RegisterIcon(Icon.Information);
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RESTful Store - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>RESTful Store</h1>
        
        <p>(also see <a href="http://mvc.ext.net/restdemo/">http://mvc.ext.net/restdemo/</a>)</p>
       
        <ext:GridPanel 
            ID="UserGrid" 
            runat="server"
            Icon="Table"
            Frame="true"
            Title="Users"
            Height="400"
            Width="500"
            StyleSpec="margin-top: 10px">
            <Store>
                <ext:Store 
                    runat="server" 
                    AutoSave="true" 
                    Restful="true"
                    ShowWarningOnFailure="false"
                    SkipIdForNewRecords="false"
                    RefreshAfterSaving="None">
                    <Proxy>
                        <ext:HttpProxy Url="RestfulPersons.ashx/person" />
                    </Proxy>
                    <Reader>
                        <ext:JsonReader IDProperty="Id" Root="data" MessageProperty="message">
                            <Fields>
                                <ext:RecordField Name="Id" />
                                <ext:RecordField Name="Email" AllowBlank="false" />
                                <ext:RecordField Name="First" AllowBlank="false" />
                                <ext:RecordField Name="Last" AllowBlank="false" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                    <Listeners>
                        <Exception Handler="
                            Ext.net.Notification.show({
                                iconCls    : 'icon-exclamation', 
                                html       : e && e.message ? e.message : response.message || response.statusText, 
                                title      : 'EXCEPTION', 
                                hideDelay  : 5000
                            });" />
                        <Save Handler=" Ext.net.Notification.show({
                                iconCls    : 'icon-information', 
                                html       : arg.message, 
                                title      : 'Success', 
                                hideDelay  : 5000
                            });" />
                    </Listeners>
                </ext:Store>
            </Store>
            <ColumnModel>
                <Columns>
                    <ext:Column Header="ID" Width="40" DataIndex="Id" />
                    <ext:Column Header="Email" Width="100" DataIndex="Email">
                        <Editor>
                            <ext:TextField runat="server" />    
                        </Editor>
                    </ext:Column>
                    <ext:Column Header="First" Width="50" DataIndex="First">
                        <Editor>
                            <ext:TextField runat="server" />    
                        </Editor>
                    </ext:Column>
                    <ext:Column Header="Last" Width="50" DataIndex="Last">
                        <Editor>
                            <ext:TextField runat="server" />    
                        </Editor>
                    </ext:Column>
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" />
            </SelectionModel>
            <View>
                <ext:GridView runat="server" ForceFit="true" />
            </View>
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" Text="Add" Icon="Add">
                            <Listeners>
                                <Click Handler="#{UserGrid}.insertRecord();#{UserGrid}.getRowEditor().startEditing(0);" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" Text="Delete" Icon="Exclamation">
                            <Listeners>
                                <Click Handler="#{UserGrid}.deleteSelected();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Plugins>
                <ext:RowEditor runat="server" SaveText="Update" />
            </Plugins>
        </ext:GridPanel>
    </form>
</body>
</html>