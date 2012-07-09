<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Globalization" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Locale - Ext.NET Examples</title>    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    
    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (CultureInfo culture in Ext.Net.ResourceManager.SupportedCultures)
            {
                this.ComboBox1.Items.Add(new Ext.Net.ListItem(culture.EnglishName, culture.ToString()));
            }

            if (!this.IsPostBack)
            {
                bool isParent;
                if (Ext.Net.ResourceManager.IsSupportedCulture(ResourceManager1.Locale, out isParent))
                {
                    string cultureName = isParent ? this.ResourceManager1.Locale.Split(new char[] { '-' })[0] : ResourceManager1.Locale;
                    this.ComboBox1.SelectedItem.Value = cultureName;
                }
            }
        }
        
        protected void ComboBox1_ItemSelected(object sender, EventArgs e)
        {
            if (this.ComboBox1.SelectedItem.Value == "Ignore")
            {
                this.ResourceManager1.Locale = "Ignore";
                return;
            }
            this.Page.UICulture = this.ComboBox1.SelectedItem.Value;                  
        }
    </script>
    
    <style type="text/css">
        .spacer {
            width:176px; 
            height:5px; 
            border-bottom:dotted 1px gray;
            margin-bottom:5px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <h1>Auto detect language (depending UI Culture)</h1>
        
        <ext:ComboBox 
            ID="ComboBox1" 
            runat="server" 
            AutoPostBack="true" 
            OnItemSelected="ComboBox1_ItemSelected" 
            Width="176">
            <Items>
                <ext:ListItem Text="None" Value="Ignore" />
            </Items>
        </ext:ComboBox>
        
        <div class="spacer" />
        
        <ext:DatePicker runat="server" />
    </form>
</body>
</html>
