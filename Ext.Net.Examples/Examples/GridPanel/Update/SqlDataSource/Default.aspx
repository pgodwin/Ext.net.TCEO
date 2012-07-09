<%@ Page Language="C#" %>

<%@ Import Namespace="System.Xml" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        XmlDocument xml = new XmlDocument();
        xml.Load(Server.MapPath("States.xml"));

        foreach (XmlNode state in xml.SelectNodes("states/state"))
        {
            this.cbStates.Items.Add(new Ext.Net.ListItem(state.Attributes["label"].InnerText, state.Attributes["data"].InnerText));
        }
    }

    private bool cancel;
    private string message;
    private string insertedValue;

    protected void Store1_BeforeRecordInserted(object sender, BeforeRecordInsertedEventArgs e)
    {
        object region = e.NewValues["Region"];
        
        if (region == null || region.ToString() != "Alabama (AL)")
        {
            e.Cancel = true;
            this.cancel = true;
            this.message = "The Region must be 'AL'";
        }
    }

    protected void Store1_AfterRecordInserted(object sender, AfterRecordInsertedEventArgs e)
    {
        //The deleted and updated records confirms automatic (depending AffectedRows field)
        //But you can override this in AfterRecordUpdated and AfterRecordDeleted event
        //For insert we should set new id for refresh on client
        //If we don't set new id then old id will be used
        if (e.Confirmation.Confirm && !string.IsNullOrEmpty(insertedValue))
        {
            e.Confirmation.ConfirmRecord(insertedValue);
            insertedValue = "";
        }
    }

    protected void SqlDataSource1_Inserted(object sender, SqlDataSourceStatusEventArgs e)
    {
        //use e.AffectedRows for ensure success action. The store read this value and set predefined Confirm depend on e.AffectedRows
        //The Confirm can be granted or denied in OnRecord....ed event
        insertedValue = e.Command.Parameters["@newId"].Value != null
                            ? e.Command.Parameters["@newId"].Value.ToString()
                            : "";
    }

    protected void Store1_AfterDirectEvent(object sender, AfterDirectEventArgs e)
    {
        if (e.Response.Success)
        {
            // set to .Success to false if we want to return a failure
            e.Response.Success = !cancel;
            e.Response.Message = message;
            //if (this.cancel)
           // {
               // GridPanel1.AddScript("alert({0});", JSON.Serialize(this.message));
            //}
        }
    }

    protected void Store1_BeforeDirectEvent(object sender, BeforeDirectEventArgs e)
    {
        string emulError = e.Parameters["EmulateError"];
        
        if (emulError == "1")
        {
            throw new Exception("Emulating error");
        }
    }

    protected void Store1_RefershData(object sender, StoreRefreshDataEventArgs e)
    {
        this.Store1.DataBind();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AJAX GridPanel with Details - Ext.NET Examples</title>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <asp:SqlDataSource 
            ID="SqlDataSource1" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
            DeleteCommand="DELETE FROM Suppliers WHERE (SupplierID = @SupplierID)"
            InsertCommand="INSERT INTO Suppliers 
                               (CompanyName,
                                ContactName,
                                ContactTitle, 
                                Address, 
                                City, 
                                Region, 
                                PostalCode, 
                                Country, 
                                Phone, 
                                Fax) 
                            VALUES 
                                (@CompanyName,
                                 @ContactName,
                                 @ContactTitle,
                                 @Address,
                                 @City,
                                 @Region,
                                 @PostalCode,
                                 @Country,
                                 @Phone,
                                 @Fax);                         
                            SELECT @newId = @@Identity;"
                            
            SelectCommand="SELECT 
                                SupplierID, 
                                CompanyName, 
                                ContactName, 
                                ContactTitle, 
                                Address, 
                                City, 
                                Region, 
                                PostalCode, 
                                Country, 
                                Phone, 
                                Fax                            
                           FROM Suppliers"
                           
            UpdateCommand="UPDATE Suppliers SET 
                                CompanyName = @CompanyName, 
                                ContactName = @ContactName, 
                                ContactTitle = @ContactTitle, 
                                Address = @Address, 
                                City = @City, 
                                Region = @Region, 
                                PostalCode = @PostalCode, 
                                Country = @Country, 
                                Phone = @Phone, 
                                Fax = @Fax
                           WHERE (SupplierID = @SupplierID)"
                           
            OnInserted="SqlDataSource1_Inserted">
            
            <DeleteParameters>
                <asp:Parameter Name="SupplierID" Type="Int32" />
            </DeleteParameters>
            
            <UpdateParameters>
                <asp:Parameter Name="CompanyName" Type="String" />
                <asp:Parameter Name="ContactName" Type="String" />
                <asp:Parameter Name="ContactTitle" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Region" Type="String" />
                <asp:Parameter Name="PostalCode" Type="String" />
                <asp:Parameter Name="Country" Type="String" />
                <asp:Parameter Name="Phone" Type="String" />
                <asp:Parameter Name="Fax" Type="String" />
                <asp:Parameter Name="SupplierID" Type="Int32" />
            </UpdateParameters>
            
            <InsertParameters>
                <asp:Parameter Name="CompanyName" Type="String" />
                <asp:Parameter Name="ContactName" Type="String" />
                <asp:Parameter Name="ContactTitle" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Region" Type="String" />
                <asp:Parameter Name="PostalCode" Type="String" />
                <asp:Parameter Name="Country" Type="String" />
                <asp:Parameter Name="Phone" Type="String" />
                <asp:Parameter Name="Fax" Type="String" />
                <asp:Parameter Direction="Output" Name="newId" Type="Int32" />
            </InsertParameters>
        </asp:SqlDataSource>
        
        <ext:Store 
            ID="Store1" 
            runat="server" 
            DataSourceID="SqlDataSource1" 
            ShowWarningOnFailure="false"
            OnAfterDirectEvent="Store1_AfterDirectEvent"
            OnBeforeDirectEvent="Store1_BeforeDirectEvent" 
            UseIdConfirmation="true" 
            OnBeforeRecordInserted="Store1_BeforeRecordInserted"
            OnAfterRecordInserted="Store1_AfterRecordInserted"
            OnRefreshData="Store1_RefershData">
            <Reader>
                <ext:JsonReader IDProperty="SupplierID">
                    <Fields>
                        <ext:RecordField Name="CompanyName" />
                        <ext:RecordField Name="ContactName" />
                        <ext:RecordField Name="ContactTitle" />
                        <ext:RecordField Name="Address" />
                        <ext:RecordField Name="City" />
                        <ext:RecordField Name="Region" />
                        <ext:RecordField Name="PostalCode" />
                        <ext:RecordField Name="Country" />
                        <ext:RecordField Name="Phone" />
                        <ext:RecordField Name="Fax" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
            <SortInfo Field="CompanyName" Direction="ASC" />
            <Listeners>
                <LoadException Handler="Ext.Msg.alert('Suppliers - Load failed', e.message || e);" />
                <CommitFailed Handler="Ext.Msg.alert('Suppliers - Commit failed', 'Reason: ' + msg);" />
                <SaveException Handler="Ext.Msg.alert('Suppliers - Save failed', e.message || e);" />
                <CommitDone Handler="Ext.Msg.alert('Suppliers - Commit', 'The data successfully saved');" />
            </Listeners>      
        </ext:Store>
        
        <ext:Viewport runat="server">
            <Items>
                <ext:BorderLayout runat="server">
                    <North MarginsSummary="5 5 5 5">
                        <ext:Panel 
                            runat="server" 
                            Title="Description" 
                            Height="100" 
                            Padding="5"
                            Frame="true" 
                            Icon="Information">
                            <Content>
                                Example - Ajax update (insert/delete/update) with SqlDataSource.
                                <br />
                                For demo purpose when insert action perfoms, the Region must be &quot;AL&quot; otherwise
                                custom data validation will fail and return error message.
                            </Content>
                        </ext:Panel>
                    </North>
                    <Center MarginsSummary="0 5 0 5">
                        <ext:Panel ID="Panel1" runat="server" Height="300" Header="false" Layout="Fit">
                            <Items>
                                <ext:GridPanel 
                                    ID="GridPanel1" 
                                    runat="server"  
                                    Title="Suppliers" 
                                    AutoExpandColumn="CompanyName"
                                    StoreID="Store1" 
                                    Border="false" 
                                    Icon="Lorry">
                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:Column 
                                                ColumnID="CompanyName" 
                                                DataIndex="CompanyName" 
                                                Header="Company Name">
                                                <Editor>
                                                    <ext:TextField runat="server" />
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column DataIndex="ContactName" Header="Contact Name">
                                                <Editor>
                                                    <ext:TextField runat="server" />
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column DataIndex="ContactTitle" Header="Contact Title">
                                                <Editor>
                                                    <ext:TextField runat="server" />
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column DataIndex="Address" Header="Address">
                                                <Editor>
                                                    <ext:TextField runat="server" />
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column DataIndex="City" Header="City">
                                                <Editor>
                                                    <ext:TextField runat="server" />
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column DataIndex="Region" Header="Region" Width="200">
                                                <Editor>
                                                    <ext:ComboBox ID="cbStates" runat="server" />
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column DataIndex="PostalCode" Header="Postal Code">
                                                <Editor>
                                                    <ext:TextField runat="server" />
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column DataIndex="Country" Header="Country">
                                                <Editor>
                                                    <ext:TextField runat="server" />
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column DataIndex="Phone" Header="Phone">
                                                <Editor>
                                                    <ext:TextField runat="server" />
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column DataIndex="Fax" Header="Fax">
                                                <Editor>
                                                    <ext:TextField runat="server" />
                                                </Editor>
                                            </ext:Column>                                            
                                        </Columns>
                                    </ColumnModel>                                    
                                    <SelectionModel>
                                        <ext:RowSelectionModel runat="server" />
                                    </SelectionModel>
                                    <BottomBar>
                                        <ext:PagingToolbar 
                                            runat="server" 
                                            PageSize="10" 
                                            StoreID="Store1" 
                                            DisplayInfo="false" 
                                            />
                                    </BottomBar>
                                    <SaveMask ShowMask="true" />
                                    <LoadMask ShowMask="true" />
                                </ext:GridPanel>
                            </Items>
                            <Buttons>
                                <ext:Button ID="btnSave" runat="server"  Text="Save" Icon="Disk">
                                    <Listeners>
                                        <Click Handler="#{GridPanel1}.save();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="btnDelete" runat="server"  Text="Delete selected records" Icon="Delete">
                                    <Listeners>
                                        <Click Handler="#{GridPanel1}.deleteSelected();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="btnInsert" runat="server"  Text="Insert" Icon="Add">
                                    <Listeners>
                                        <Click Handler="#{GridPanel1}.insertRecord(0, {});#{GridPanel1}.getView().focusRow(0);#{GridPanel1}.startEditing(0, 0);" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="btnRefresh" runat="server"  Text="Refresh" Icon="ArrowRefresh">
                                    <Listeners>
                                        <Click Handler="#{GridPanel1}.reload();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="btnEmulError" runat="server"  Text="Refresh with Emulated error" Icon="Exclamation">
                                    <Listeners>
                                        <Click Handler="#{GridPanel1}.reload({params:{EmulateError: 1}});" />
                                    </Listeners>
                                </ext:Button>                           
                            </Buttons>
                        </ext:Panel>
                    </Center>             
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>