<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        // Create Proxy
        HttpProxy proxy = new HttpProxy { 
            Method = HttpMethod.POST,
            Url = "Plants.ashx"
        };
        
        // Create Reader
        JsonReader reader = new JsonReader { 
            Root = "plants",
            TotalProperty = "total",
            Fields = {
                new RecordField("Common"),
                new RecordField("Botanical"),
                new RecordField("Light"),
                new RecordField("Price", RecordFieldType.Float),
                new RecordField("Indoor", RecordFieldType.Boolean)
            }
        };
        
        // Add Proxy and Reader to Store
        Store store = new Store { 
            Proxy = { proxy },
            Reader = { reader },
            AutoLoad = false
        };
        
        // Create ComboBox
        ComboBox combobox = new ComboBox {
            DisplayField = "Common",
            ValueField = "Common",
            TypeAhead = false,
            LoadingText = "Searching...",
            Width = 570,
            PageSize = 10,
            HideTrigger = true,
            ItemSelector = "div.search-item",
            MinChars = 1,
            Store = { store }
        };
        
        combobox.Template.Html = @"
               <tpl for=""."">
                  <div class=""search-item"">
                     <h3><span>${Price}</span>{Common}</h3>
                     {Botanical}
                  </div>
               </tpl>";

        // Add ComboBox to Controls Collection
        this.Placeholder1.Controls.Add(combobox);
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ComboBox with Template - Ext.NET Examples</title>
    <style type="text/css">
        .search-item {
            font          : normal 11px tahoma, arial, helvetica, sans-serif;
            padding       : 3px 10px 3px 10px;
            border        : 1px solid #fff;
            border-bottom : 1px solid #eeeeee;
            white-space   : normal;
            color         : #555;
        }
        
        .search-item h3 {
            display     : block;
            font        : inherit;
            font-weight : bold;
            color       : #222;
        }

        .search-item h3 span {
            float       : right;
            font-weight : normal;
            margin      : 0 0 5px 5px;
            width       : 100px;
            display     : block;
            clear       : none;
        } 
        
        p { width: 650px; }
        
        .ext-ie .x-form-text { position : static !important; }
    </style>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Combo with Templates and Ajax</h1><br />
        <p>This is a more advanced example demonstrating how to combine Store Paging and a Template to create "live search" functionality.</p>
    
        <div style="width:600px;">
            <div class="x-box-tl"><div class="x-box-tr"><div class="x-box-tc"></div></div></div>
            <div class="x-box-ml"><div class="x-box-mr"><div class="x-box-mc">
                <h3 style="margin-bottom:5px;">Search the plants</h3>
                
            <ext:ComboBox 
                runat="server" 
                DisplayField="Common" 
                ValueField="Common"
                
                TypeAhead="false"
                LoadingText="Searching..." 
                Width="570"
                PageSize="10"
                HideTrigger="true"
                ItemSelector="div.search-item"        
                MinChars="1">
                <Store>
                    <ext:Store runat="server" AutoLoad="false">
                        <Proxy>
                            <ext:HttpProxy Method="POST" Url="Plants.ashx" />
                        </Proxy>
                        <Reader>
                            <ext:JsonReader Root="plants" TotalProperty="total">
                                <Fields>
                                    <ext:RecordField Name="Common" />
                                    <ext:RecordField Name="Botanical" />
                                    <ext:RecordField Name="Light" />
                                    <ext:RecordField Name="Price" Type="Float" />
                                    <ext:RecordField Name="Indoor" Type="Boolean" />
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>
                <Template runat="server">
                   <Html>
					   <tpl for=".">
						  <div class="search-item">
							 <h3><span>${Price}</span>{Common}</h3>
							 {Botanical}
						  </div>
					   </tpl>
				   </Html>
                </Template>
            </ext:ComboBox>    
            
            <div style="padding-top:4px;">
                Plants search (type '*' (asterisk) for showing all)
            </div>
            </div></div></div>
            <div class="x-box-bl"><div class="x-box-br"><div class="x-box-bc"></div></div></div>
        </div>
            
        <br />
        <br />
        <br />
            
        <div style="width:600px;">
            <div class="x-box-tl">
                <div class="x-box-tr">
                    <div class="x-box-tc"></div>
                </div>
            </div>
            <div class="x-box-ml">
                <div class="x-box-mr">
                    <div class="x-box-mc">
                        <h3 style="margin-bottom:5px;">Search the plants (controls dynamically created)</h3>
                        <asp:PlaceHolder ID="Placeholder1" runat="server" />
                        <div style="padding-top:4px;">
                            Plants search (type '*' (asterisk) for showing all)
                        </div>
                    </div>
                </div>
            </div>
            <div class="x-box-bl">
                <div class="x-box-br">
                    <div class="x-box-bc"></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>