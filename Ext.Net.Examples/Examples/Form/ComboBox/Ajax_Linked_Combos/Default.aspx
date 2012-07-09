<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Xml" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>

    <script runat="server">
        
        protected void CitiesRefresh(object sender, StoreRefreshDataEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Current.Server.MapPath("Cities.xml"));
            List<object> data = new List<object>();

            foreach (XmlNode cityNode in xmlDoc.SelectNodes(string.Concat("countries/country[@code='", this.Countries.SelectedItem.Value, "']/city")))
            {
                string id = cityNode.SelectSingleNode("id").InnerText;
                string name = cityNode.SelectSingleNode("name").InnerText;

                data.Add(new { Id = id, Name = name });
            }
            this.CitiesStore.DataSource = data;

            this.CitiesStore.DataBind();
        }
    </script>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    
    <ext:Store runat="server" ID="CitiesStore" AutoLoad="false" OnRefreshData="CitiesRefresh">
        <DirectEventConfig>
            <EventMask ShowMask="false" />
        </DirectEventConfig>
        <Reader>
            <ext:JsonReader IDProperty="Id">
                <Fields>
                    <ext:RecordField Name="id" Type="String" Mapping="Id" />
                    <ext:RecordField Name="name" Type="String" Mapping="Name" />
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Listeners>
            <Load Handler="#{Cities}.setValue(#{Cities}.store.getAt(0).get('id'));" />
        </Listeners>
    </ext:Store>
    
    <ext:ComboBox ID="Countries" runat="server" 
        Editable="false" 
        TypeAhead="true" 
        Mode="Local"
        ForceSelection="true" 
        TriggerAction="All" 
        SelectOnFocus="true" 
        EmptyText="Select a country">
        <Listeners>
            <Select Handler="#{Cities}.clearValue(); #{CitiesStore}.reload();" />
        </Listeners>        
        <Items>
            <ext:ListItem Text="Belgium" Value="BE" />
            <ext:ListItem Text="Brazil" Value="BR" />
            <ext:ListItem Text="Bulgaria" Value="BG" />
            <ext:ListItem Text="Canada" Value="CA" />
            <ext:ListItem Text="Chile" Value="CL" />
            <ext:ListItem Text="Cyprus" Value="CY" />
            <ext:ListItem Text="Finland" Value="FI" />
            <ext:ListItem Text="France" Value="FR" />
            <ext:ListItem Text="Germany" Value="DE" />
            <ext:ListItem Text="Hungary" Value="HU" />
            <ext:ListItem Text="Ireland" Value="IE" />
            <ext:ListItem Text="Israel" Value="IL" />
            <ext:ListItem Text="Italy" Value="IT" />
            <ext:ListItem Text="Lithuania" Value="LT" />
            <ext:ListItem Text="Mexico" Value="MX" />
            <ext:ListItem Text="Netherlands" Value="NL" />
            <ext:ListItem Text="New Zealand" Value="NZ" />
            <ext:ListItem Text="Norway" Value="NO" />
            <ext:ListItem Text="Pakistan" Value="PK" />
            <ext:ListItem Text="Poland" Value="PL" />
            <ext:ListItem Text="Romania" Value="RO" />
            <ext:ListItem Text="Slovakia" Value="SK" />
            <ext:ListItem Text="Slovenia" Value="SI" />
            <ext:ListItem Text="Spain" Value="ES" />
            <ext:ListItem Text="Sweden" Value="SE" />
            <ext:ListItem Text="Switzerland" Value="CH" />
            <ext:ListItem Text="United Kingdom" Value="GB" />
        </Items>
    </ext:ComboBox>
    
    <ext:ComboBox ID="Cities" runat="server" 
        StoreID="CitiesStore" 
        TypeAhead="true" 
        Mode="Local"
        ForceSelection="true" 
        TriggerAction="All" 
        DisplayField="name" 
        ValueField="id"
        EmptyText="Loading..." 
        ValueNotFoundText="Loading...">
    </ext:ComboBox>
    
    </form>
</body>
</html>
