<%@ Control Language="C#" %>

<%@ Import Namespace="Ext.Net.Examples.Northwind"%>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        this.EmployeesStore.DataSource = Employee.GetAll();
        this.EmployeesStore.DataBind();
    }
</script>

<script type="text/javascript">
    Ext.applyIf(CompanyX, {
        open : function () {
            rec = this.getRecord();
            
            if (rec != null) {
                win = <%= winDetails.ClientID %>;
                
                win.show();
                win.setTitle(String.format("Employee Details : {0}, {1}", rec.data.LastName, rec.data.FirstName));
                
                <%= EmployeeID1.ClientID %>.setValue(rec.id);
                <%= EmployeeID2.ClientID %>.setValue(rec.id);
                
                //Company        
                
                <%= FirstName.ClientID %>.setValue(rec.data.FirstName);
                <%= LastName.ClientID %>.setValue(rec.data.LastName);
                <%= Title.ClientID %>.setValue(rec.data.Title);
                <%= HireDate.ClientID %>.setValue(rec.data.HireDate);
                <%= Extension.ClientID %>.setValue(rec.data.Extension);
                <%= ReportsTo.ClientID %>.setValue(rec.data.ReportsTo);
                
                //Personal
                <%= Address.ClientID %>.setValue(rec.data.Address);
                <%= City.ClientID %>.setValue(rec.data.City);
                <%= PostCode.ClientID %>.setValue(rec.data.PostalCode);
                <%= HomePhone.ClientID %>.setValue(rec.data.Homephone);
                <%= TitleCourt.ClientID %>.setValue(rec.data.TitleOfCourtesy);
                <%= BirthDate.ClientID %>.setValue(rec.data.BirthDate);
                <%= Region.ClientID %>.setValue(rec.data.Region);
                <%= Country.ClientID %>.setValue(rec.data.Country);
                <%= Note.ClientID %>.setValue(rec.data.Notes);
            }
        },
        
        save : function () {
            var rec = this.getRecord();
            
            if (rec != null) {
                rec.set("FirstName", <%= FirstName.ClientID %>.getValue());
                rec.set("LastName", <%= LastName.ClientID %>.getValue());
                rec.set("Title", <%= Title.ClientID %>.getValue());
                rec.set("HireDate", <%= HireDate.ClientID %>.getValue());
                rec.set("Extension", <%= Extension.ClientID %>.getValue());        
                rec.set("ReportsTo", <%= ReportsTo.ClientID %>.getValue());
                
                //Personal
                rec.set("Address", <%= Address.ClientID %>.getValue());
                rec.set("City", <%= City.ClientID %>.getValue());
                rec.set("PostalCode", <%= PostCode.ClientID %>.getValue());
                rec.set("Homephone", <%= HomePhone.ClientID %>.getValue());
                rec.set("TitleOfCourtesy", <%= TitleCourt.ClientID %>.getValue());
                rec.set("BirthDate", <%= BirthDate.ClientID %>.getValue());
                rec.set("Region", <%= Region.ClientID %>.getValue());
                rec.set("Country", <%= Country.ClientID %>.getValue());
                rec.set("Notes", <%= Note.ClientID %>.getValue());
            }
            
            win.hide(null);
        }
    });
</script>

<ext:Store ID="EmployeesStore" runat="server">
    <Reader>
        <ext:JsonReader IDProperty="EmployeeID">
            <Fields>
                <ext:RecordField Name="EmployeeID" />
                <ext:RecordField Name="LastName" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>

<ext:Window 
    ID="winDetails" 
    runat="server" 
    Title="Employee Details" 
    Icon="Group" 
    Width="400" 
    Height="400" 
    Modal="true"
    Hidden="true"
    Layout="Fit">
    <Items>
        <ext:TabPanel runat="server" Border="false">
            <Items>
                <ext:Panel 
                    ID="CompanyInfoTab" 
                    runat="server" 
                    Title="Company Info" 
                    Icon="ChartOrganisation"
                    Padding="5"
                    Layout="Form">
                    <Items>
                        <ext:TextField ID="EmployeeID1" runat="server" FieldLabel="Employee ID" Width="250" Disabled="true" />
                        <ext:TextField ID="FirstName" runat="server" FieldLabel="First Name" Width="250" />
                        <ext:TextField ID="LastName" runat="server" FieldLabel="Last Name" Width="250" />
                        <ext:TextField ID="Title" runat="server" FieldLabel="Title" Width="250" />
                        <ext:ComboBox 
                            ID="ReportsTo"
                            runat="server" 
                            StoreID="EmployeesStore"
                            FieldLabel="Reports to" 
                            AllowBlank="true"
                            DisplayField="LastName"
                            ValueField="EmployeeID"
                            TypeAhead="true" 
                            Mode="Local"
                            ForceSelection="true"
                            TriggerAction="All"
                            EmptyText="Select an employee..."
                            Width="250"
                            />
                        <ext:DateField ID="HireDate" runat="server" Width="250" FieldLabel="Hire date" Format="yyyy-MM-dd" />
                        <ext:TextField runat="server" ID="Extension" FieldLabel="Extension" Width="250" />
                    </Items>
                </ext:Panel>
                <ext:Panel 
                    ID="PersonalInfoTab" 
                    runat="server" 
                    Title="Personal Info" 
                    Icon="User"
                    Padding="5"
                    Layout="Form">
                    <Items>
                        <ext:TextField ID="EmployeeID2" runat="server" FieldLabel="Employee ID" Width="250" Disabled="true" />
                        <ext:TextField ID="Address" runat="server" FieldLabel="Address" Width="250" />
                        <ext:TextField ID="City" runat="server" FieldLabel="City" Width="250" />
                        <ext:TextField ID="PostCode" runat="server" FieldLabel="Post Code" Width="250" />
                        <ext:TextField ID="HomePhone" runat="server" FieldLabel="Home Phone" Width="250" />
                        <ext:TextField ID="TitleCourt" runat="server" FieldLabel="Title Of Courtesy" Width="250" />
                        <ext:DateField ID="BirthDate" runat="server" Width="250" FieldLabel="Birth date" Format="yyyy-MM-dd" />
                        <ext:TextField ID="Region" runat="server" FieldLabel="Region" Width="250" />
                        <ext:TextField ID="Country" runat="server" FieldLabel="Country" Width="250" />
                        <ext:TextArea ID="Note" runat="server" FieldLabel="Note" Height="50" Width="250" />
                    </Items>
                </ext:Panel>
            </Items>                
        </ext:TabPanel>
    </Items>
    <Buttons>
        <ext:Button ID="btnPrevious" runat="server" Text="Previous" Icon="PreviousGreen">
            <Listeners>
                <Click Handler="CompanyX.previous();" />
            </Listeners>
        </ext:Button>
    
        <ext:Button ID="btnSave" runat="server" Text="Save" Icon="Disk">
           <Listeners>
                <Click Handler="CompanyX.save();" />
            </Listeners>
        </ext:Button>
        
        <ext:Button ID="btnCancel" runat="server" Text="Cancel" Icon="Cancel">
            <Listeners>
                <Click Handler="#{winDetails}.hide();" />
            </Listeners>
        </ext:Button>
        
        <ext:Button ID="btnNext" runat="server" Text="Next" Icon="NextGreen">
            <Listeners>
                <Click Handler="CompanyX.next();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>