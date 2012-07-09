<%@ Page Language="C#" %>

<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Button1_Click(object sender, DirectEventArgs e)
    {
        //JSON representation
        string multi1 = e.ExtraParams["multi1"];
        string multi2 = e.ExtraParams["multi2"];

        // Array of ListItems
        Ext.Net.ListItem[] items1 = JSON.Deserialize<Ext.Net.ListItem[]>(multi1);
        Ext.Net.ListItem[] items2 = JSON.Deserialize<Ext.Net.ListItem[]>(multi2);

        StringBuilder sb = new StringBuilder(256);

        sb.Append("<h2>Results</h2>");

        sb.Append("<h3>As ListItems</h3>");
        
        foreach (Ext.Net.ListItem item in items1)
        {
            sb.AppendFormat("Value: {0}<br />", item.Value);
        }
        
        // XML representation
        XmlNode multi1Xml = JSON.DeserializeXmlNode("{items:{item:" + multi1 + "}}");
        XmlNode multi2Xml = JSON.DeserializeXmlNode("{items:{item:" + multi2 + "}}");

        sb.Append("<h3>As XML</h3>");

        //foreach (XmlNode node in multi1)
        //{
        //    sb.AppendFormat("Value: {0}<br />", node.Value);
        //}
        
        // Array of Dictionaries
        Dictionary<string, string>[] multi1Json = JSON.Deserialize<Dictionary<string, string>[]>(multi1);
        Dictionary<string, string>[] multi2Json = JSON.Deserialize<Dictionary<string, string>[]>(multi2);

        sb.Append("<h3>As XML</h3>");

        //foreach (XmlNode node in multi1)
        //{
        //    sb.AppendFormat("Value: {0}<br />", node.Value);
        //}

        this.Label1.Html = sb.ToString();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Submit MultiSelect Values - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Submit MultiSelect Values</h1>
        
        <ext:Panel runat="server" Title="MultiSelects" Width="660" Layout="Column">
            <Items>
                <ext:Panel runat="server" Border="false" Height="260" ColumnWidth="0.5" Layout="Fit" Padding="5">
                    <Items>
                        <ext:MultiSelect ID="MultiSelect1" runat="server" Legend="MultiSelect1">
                            <Items>
                                <ext:ListItem Text="Item 1" Value="1" />
                                <ext:ListItem Text="Item 2" Value="2" />
                                <ext:ListItem Text="Item 3" Value="3" />
                                <ext:ListItem Text="Item 4" Value="4" />
                                <ext:ListItem Text="Item 5" Value="5" />
                            </Items>
                        </ext:MultiSelect>      
                    </Items>
                </ext:Panel>                                                             
                <ext:Panel runat="server" Border="false" Height="260" ColumnWidth="0.5" Layout="Fit" Padding="5">
                    <Items>
                        <ext:MultiSelect ID="MultiSelect2" runat="server" Legend="MultiSelect2">
                            <Items>
                                <ext:ListItem Text="Item 1" Value="1" />
                                <ext:ListItem Text="Item 2" Value="2" />
                                <ext:ListItem Text="Item 3" Value="3" />
                                <ext:ListItem Text="Item 4" Value="4" />
                                <ext:ListItem Text="Item 5" Value="5" />
                            </Items>
                        </ext:MultiSelect>      
                    </Items>
                </ext:Panel>                                                             
            </Items>
            <Buttons>
                 <ext:Button runat="server" Text="Submit MultiSelects">
                    <DirectEvents>
                        <Click OnEvent="Button1_Click">
                            <ExtraParams>
                                <ext:Parameter Name="multi1" Value="Ext.encode(#{MultiSelect1}.getValues())" Mode="Raw" />
                                <ext:Parameter Name="multi2" Value="Ext.encode(#{MultiSelect2}.getValues(true))" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:Panel>
        
        <ext:Label ID="Label1" runat="server" />
    </form>
</body>
</html>
