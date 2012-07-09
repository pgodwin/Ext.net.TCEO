<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Store1.DataSource = new object[]
        {
            new object[] { "AL", "Alabama", "The Heart of Dixie" },
            new object[] { "AK", "Alaska", "The Land of the Midnight Sun" },
            new object[] { "AZ", "Arizona", "The Grand Canyon State" },
            new object[] { "AR", "Arkansas", "The Natural State" },
            new object[] { "CA", "California", "The Golden State" },
            new object[] { "CO", "Colorado", "The Mountain State" },
            new object[] { "CT", "Connecticut", "The Constitution State" },
            new object[] { "DE", "Delaware", "The First State" },
            new object[] { "DC", "District of Columbia", "The Nation's Capital" },
            new object[] { "FL", "Florida", "The Sunshine State" },
            new object[] { "GA", "Georgia", "The Peach State" },
            new object[] { "HI", "Hawaii", "The Aloha State" },
            new object[] { "ID", "Idaho", "Famous Potatoes" },
            new object[] { "IL", "Illinois", "The Prairie State" },
            new object[] { "IN", "Indiana", "The Hospitality State" },
            new object[] { "IA", "Iowa", "The Corn State" },
            new object[] { "KS", "Kansas", "The Sunflower State" },
            new object[] { "KY", "Kentucky", "The Bluegrass State" },
            new object[] { "LA", "Louisiana", "The Bayou State" },
            new object[] { "ME", "Maine", "The Pine Tree State" },
            new object[] { "MD", "Maryland", "Chesapeake State" },
            new object[] { "MA", "Massachusetts", "The Spirit of America" },
            new object[] { "MI", "Michigan", "Great Lakes State" },
            new object[] { "MN", "Minnesota", "North Star State" },
            new object[] { "MS", "Mississippi", "Magnolia State" },
            new object[] { "MO", "Missouri", "Show Me State" },
            new object[] { "MT", "Montana", "Big Sky Country" },
            new object[] { "NE", "Nebraska", "Beef State" },
            new object[] { "NV", "Nevada", "Silver State" },
            new object[] { "NH", "New Hampshire", "Granite State" },
            new object[] { "NJ", "New Jersey", "Garden State" },
            new object[] { "NM", "New Mexico", "Land of Enchantment" },
            new object[] { "NY", "New York", "Empire State" },
            new object[] { "NC", "North Carolina", "First in Freedom" },
            new object[] { "ND", "North Dakota", "Peace Garden State" },
            new object[] { "OH", "Ohio", "The Heart of it All" },
            new object[] { "OK", "Oklahoma", "Oklahoma is OK" },
            new object[] { "OR", "Oregon", "Pacific Wonderland" },
            new object[] { "PA", "Pennsylvania", "Keystone State" },
            new object[] { "RI", "Rhode Island", "Ocean State" },
            new object[] { "SC", "South Carolina", "Nothing Could be Finer" },
            new object[] { "SD", "South Dakota", "Great Faces, Great Places" },
            new object[] { "TN", "Tennessee", "Volunteer State" },
            new object[] { "TX", "Texas", "Lone Star State" },
            new object[] { "UT", "Utah", "Salt Lake State" },
            new object[] { "VT", "Vermont", "Green Mountain State" },
            new object[] { "VA", "Virginia", "Mother of States" },
            new object[] { "WA", "Washington", "Green Tree State" },
            new object[] { "WV", "West Virginia", "Mountain State" },
            new object[] { "WI", "Wisconsin", "America's Dairyland" },
            new object[] { "WY", "Wyoming", "Like No Place on Earth" } 
        };
        
        this.Store1.DataBind();
        
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Comboboxes - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:Store ID="Store1" runat="server">
            <Reader>
                <ext:ArrayReader>
                    <Fields>
                        <ext:RecordField Name="abbr" />
                        <ext:RecordField Name="state" />
                        <ext:RecordField Name="nick" />
                    </Fields>
                </ext:ArrayReader>
            </Reader>            
        </ext:Store>

        <ext:Button runat="server" Text="Set 'IDAHO' value">
            <Listeners>
                <Click Handler="#{ComboBox1}.setValue('ID');" />
            </Listeners>
        </ext:Button>
        
        <h2>Not Editable:</h2>
        
        <ext:ComboBox 
            ID="ComboBox1" 
            runat="server" 
            StoreID="Store1" 
            Editable="false"
            DisplayField="state"
            ValueField="abbr"
            TypeAhead="true" 
            Mode="Local"
            ForceSelection="true"
            EmptyText="Select a state..."
            Resizable="true"
            SelectOnFocus="true"
            />
        
        <h2>Editable with predefine value:</h2>
        
        <ext:ComboBox 
            runat="server" 
            StoreID="Store1" 
            Editable="true"
            DisplayField="state"
            ValueField="abbr"
            TypeAhead="true" 
            Mode="Local"
            ForceSelection="true"
            TriggerAction="All"
            EmptyText="Select a state..."
            SelectOnFocus="true">
            <SelectedItem Value="ID" />
        </ext:ComboBox>
                
        <h2>With inner items:</h2>
        
        <ext:ComboBox
            runat="server" 
            Editable="false"         
            EmptyText="Select a state...">
            <Items>
                <ext:ListItem Text="Alabama" Value="AL" />
                <ext:ListItem Text="Alaska" Value="AK" />
            </Items>
        </ext:ComboBox>
    </form>
</body>
</html>
