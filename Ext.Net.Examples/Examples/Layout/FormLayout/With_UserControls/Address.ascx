<%@ Control Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    public string Title
    {
        get { return this.Panel1.Title; }
        set { this.Panel1.Title = value; }
    }

    public string StreetAddress
    {
        get { return this.txtStreet.Text; }
        set { this.txtStreet.Text = value; }
    }
    
    public string ZipPostalCode
    {
        get { return this.txtZipPostalCode.Text; }
        set { this.txtZipPostalCode.Text = value; }
    }
    
    public string City
    {
        get { return this.txtCity.Text; }
        set { this.txtCity.Text = value; }
    }

    public string CountryID
    {
        get { return this.cbxCountry.SelectedItem.Value; }
        set { this.cbxCountry.SelectedItem.Value = value; }
    }

    public bool ShowCheckbox
    {
        get 
        { 
            object obj =  this.ViewState["ShowCheckbox"];

            return (obj == null) ? false : (bool)obj;
        }
        set 
        { 
            this.ViewState["ShowCheckbox"] = value; 
        }
    }

    public bool Checked
    {
        get { return this.chkSame.Checked; }
        set { this.chkSame.Checked = value; }
    }

    public string CheckboxMessage
    {
        get { return this.chkSame.FieldLabel; }
        set { this.chkSame.FieldLabel = value; }
    }

    Checkbox chkSame = new Checkbox();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            if (this.ShowCheckbox)
            {
                this.chkSame.ID = "chkSame";
                this.chkSame.Checked = this.Checked;
                this.chkSame.FieldLabel = this.CheckboxMessage;
                this.chkSame.LabelStyle = "white-space:nowrap;";

                this.chkSame.Listeners.Check.Handler = "#{Panel2}.setVisible(!this.getValue());#{Panel2}.doLayout();if (!this.getValue()) {#{txtStreet}.focus();}";

                this.Panel1.Items.Insert(0, this.chkSame);

                this.Panel2.Hidden = this.Checked;
            }
        }
    }
</script>

<ext:FitLayout ID="FitLayout1" runat="server">
    <Items>
        <ext:Panel ID="Panel1" runat="server" FormGroup="true" AutoHeight="true" Layout="Form">
            <Items>
                <ext:Panel ID="Panel2" runat="server" Border="false" Header="false" AnchorHorizontal="100%" Layout="Form">
                    <Items>
                        <ext:TextField ID="txtStreet" runat="server" FieldLabel="Street" AnchorHorizontal="100%" />
                        <ext:TextField ID="txtZipPostalCode" runat="server" FieldLabel="Zip/Postal Code" AnchorHorizontal="100%" />
                        <ext:TextField ID="txtCity" runat="server" FieldLabel="City" AnchorHorizontal="100%" />
                        <ext:ComboBox ID="cbxCountry" runat="server" FieldLabel="Country" AnchorHorizontal="100%">
                            <Items>
                                <ext:ListItem Text="Australia" Value="AU" />
                                <ext:ListItem Text="Canada" Value="CA" />
                                <ext:ListItem Text="United States" Value="US" />
                            </Items>
                        </ext:ComboBox>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Panel>
    </Items>
</ext:FitLayout>