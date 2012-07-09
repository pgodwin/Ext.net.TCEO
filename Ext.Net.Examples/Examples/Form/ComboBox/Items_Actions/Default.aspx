<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">     
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            List<object> list = new List<object>
            {
                new {Text = "Text3", Value = 3},
                new {Text = "Text4", Value = 4},
                new {Text = "Text5", Value = 5}
            };
            
            this.Store1.DataSource = list;
            this.Store1.DataBind();
            
            //Please note that inner items will be above store's items
            this.ComboBox1.Items.Insert(0, new Ext.Net.ListItem("None", "-"));
            this.ComboBox1.SelectedItem.Value = "-";
        }
    }
    
    protected void InsertRecord(object sender, DirectEventArgs e)
    {
        Dictionary<string, object> values = new Dictionary<string, object>(2);
        values.Add("Text", "Text0");
        values.Add("Value", "0");

        this.ComboBox1.InsertRecord(1, values);
        this.ComboBox1.SelectedItem.Value = "0";
    }

    protected void InsertRecord2(object sender, DirectEventArgs e)
    {
        this.ComboBox2.InsertItem(0, "Text0", "0");
        this.ComboBox2.SelectedItem.Value = "0";
    }
</script> 


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
	"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Items Actions - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <ext:Store runat="server" ID="Store1">          
            <Reader>
                <ext:JsonReader IDProperty="Value">
                    <Fields>
                        <ext:RecordField Name="Text" />
                        <ext:RecordField Name="Value" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        
        <p>1. Combo with a store and inner items (merge mode)</p>
        <br />
        
        <ext:ComboBox 
            ID="ComboBox1" 
            runat="server" 
            StoreID="Store1" 
            DisplayField="Text" 
            ValueField="Value"
            Mode="Local">
            <Items>
                <ext:ListItem Text="Text2" Value="2" />
            </Items>
            <Triggers>
                <ext:FieldTrigger Icon="Clear" Qtip="Remove selected" />
            </Triggers>
            <Listeners>
                <TriggerClick Handler="this.removeByValue(this.getValue());this.clearValue();" />
            </Listeners>
        </ext:ComboBox>
        
        <br />
        
        <ext:Panel ID="Panel1" runat="server" Border="false">
            <Items>
                <ext:TableLayout ID="TableLayout1" runat="server" Columns="2">
                    <Cells>
                        <ext:Cell>
                            <ext:Button ID="Button1" runat="server" Text="Insert: client side">
                                <Listeners>
                                    <Click Handler="#{ComboBox1}.insertRecord(1, {Text:'Text1', Value:1});#{ComboBox1}.setValue(1);" />
                                </Listeners>
                            </ext:Button>
                        </ext:Cell>
                        
                        <ext:Cell>
                            <ext:Button ID="Button2" runat="server" Text="Insert: server side">
                                <DirectEvents>
                                    <Click OnEvent="InsertRecord" />
                                </DirectEvents>
                            </ext:Button>
                        </ext:Cell>
                    </Cells>
                </ext:TableLayout>
            </Items>
        </ext:Panel>
        
        <br />
        <br />
        <p>2. Combo with inner items</p>
        <br />
        
        <%-- please note that the insertRecord function works with inner items also --%>
        <ext:ComboBox ID="ComboBox2" runat="server">
            <Items>
                <ext:ListItem Text="Text2" Value="2" />
                <ext:ListItem Text="Text3" Value="3" />
                <ext:ListItem Text="Text4" Value="4" />
                <ext:ListItem Text="Text5" Value="5" />                
            </Items>
            <Triggers>
                <ext:FieldTrigger Icon="Clear" Qtip="Remove selected" />
            </Triggers>
            <Listeners>
                <TriggerClick Handler="this.removeByValue(this.getValue());this.clearValue();" />
            </Listeners>
        </ext:ComboBox>
        
        <br />
        
        <ext:Panel ID="Panel2" runat="server" Border="false">
            <Items>
                <ext:TableLayout ID="TableLayout2" runat="server" Columns="2">
                    <Cells>
                        <ext:Cell>
                            <ext:Button ID="Button3" runat="server" Text="Insert: client side">
                                <Listeners>
                                    <Click Handler="#{ComboBox2}.insertItem(0, 'Text1', 1);#{ComboBox2}.setValue(1);" />
                                </Listeners>
                            </ext:Button>
                        </ext:Cell>
                        
                        <ext:Cell>
                            <ext:Button ID="Button4" runat="server" Text="Insert: server side">
                                <DirectEvents>
                                    <Click OnEvent="InsertRecord2" />
                                </DirectEvents>
                            </ext:Button>
                        </ext:Cell>
                    </Cells>
                </ext:TableLayout>
            </Items>
        </ext:Panel>
        
        <br />
        
        <h3>Other functions:</h3>
        
        <ul>
            <li>addRecord: function (values)</li>
            <li>addItem: function (text, value)</li>
            <li>insertRecord: function (rowIndex, values)</li>
            <li>insertItem: function (rowIndex, text, value)</li>
            <li>removeByField: function (field, value)</li>
            <li>removeByIndex: function (index)</li>
            <li>removeByValue: function (value)</li>
            <li>removeByText: function (text)</li>
        </ul>
    </form>
</body>
</html>