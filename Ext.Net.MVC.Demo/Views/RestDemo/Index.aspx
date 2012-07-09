<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="padding:10px;">    
    <ext:ResourceManager runat="server">
        <RestAPI 
            Create="POST" 
            Destroy="DELETE" 
            Read="GET" 
            Update="POST" 
            />
    </ext:ResourceManager>
    
    <h3>RESTful Store</h3>
   
    <ext:GridPanel 
        ID="CategoriesGrid" 
        runat="server"
        Icon="Table"
        Frame="true"
        Title="Categories"
        Height="400"
        StyleSpec="margin-top: 10px"
        AutoExpandColumn="Description">
        <Store>
            <ext:Store 
                ID="Store1" 
                runat="server" 
                AutoSave="true" 
                Restful="true"
                ShowWarningOnFailure="false"
                SkipIdForNewRecords="false"
                RefreshAfterSaving="None">
                <Proxy>
                    <ext:HttpProxy>
                        <RestAPI 
                            CreateUrl="/RestDemo/Create" 
                            DestroyUrl="/RestDemo/Destroy" 
                            ReadUrl="/RestDemo/Read" 
                            UpdateUrl="/RestDemo/Update" />
                    </ext:HttpProxy>
                </Proxy>
                
                <Reader>
                    <ext:JsonReader 
                        IDProperty="CategoryID" 
                        Root="data" 
                        MessageProperty="message">
                        <Fields>
                            <ext:RecordField Name="CategoryID" />
                            <ext:RecordField Name="CategoryName" AllowBlank="false" />
                            <ext:RecordField Name="Description" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
                
                <Listeners>
                    <Exception Handler="
                        Ext.net.Notification.show({
                            iconCls   : 'icon-exclamation', 
                            html      : e && e.message ? e.message : response.message || response.statusText, 
                            title     : 'EXCEPTION', 
                            hideDelay : 5000
                        });" />
                    <Save Handler="Ext.net.Notification.show({
                            iconCls   : 'icon-information', 
                            html      : arg.message, 
                            title     : 'Success', 
                            hideDelay : 5000
                        });" />
                </Listeners>
            </ext:Store>
        </Store>
        <ColumnModel>
            <Columns>
                <ext:Column Header="ID" Width="40" DataIndex="CategoryID" />
                <ext:Column Header="Name" Width="100" DataIndex="CategoryName">
                    <Editor>
                        <ext:TextField runat="server" MaxLength="15" />    
                    </Editor>
                </ext:Column>
                <ext:Column Header="Description" DataIndex="Description">
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
                            <Click Handler="#{CategoriesGrid}.insertRecord();#{CategoriesGrid}.getRowEditor().startEditing(0);" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button runat="server" Text="Delete" Icon="Exclamation">
                        <Listeners>
                            <Click Handler="#{CategoriesGrid}.deleteSelected();" />
                        </Listeners>
                    </ext:Button>
                    <ext:ToolbarSeparator runat="server" />
                    <ext:Label runat="server" Text="(Double-Click Row to Edit)" />
                </Items>
            </ext:Toolbar>
        </TopBar>
        <Plugins>
            <ext:RowEditor runat="server" SaveText="Update" ClicksToEdit="2" />
        </Plugins>
    </ext:GridPanel>
</body>
</html>
