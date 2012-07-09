<%@ Page Language="C#" %>

<%@ Import Namespace="Ext.Net.Utilities" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.Store1.DataSource = new object[]
            {
                new object[] { "3m Co", "A" },
                new object[] { "Alcoa Inc", "B" },
                new object[] { "Altria Group Inc", "C" },
                new object[] { "American Express Company", "D" },
                new object[] { "American International Group", "E" }
            };

            this.Store1.DataBind();

            this.Store2.DataSource = new object[]
            {
                new object[] { "A", "Excelent" },
                new object[] { "B", "Good" },
                new object[] { "C", "Average" },
                new object[] { "D", "Poor" },
                new object[] { "E", "Bad" }
            };

            this.Store2.DataBind();

            this.FillRadioGroup(RatingChoose);
            this.FillRadioGroup(CompanyRating);
        }
    }
    
    private void FillRadioGroup(RadioGroup group)
    {
        foreach (object[] rating in (object[])this.Store2.DataSource)
        {
            group.Items.Add(new Radio
            {
                Tag = rating[0].ToString(),
                BoxLabel = rating[1].ToString()
            });
        }
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EditorGrid with TriggerField Editor and Dialog - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var triggerClick = function (el, trigger, tag, auto, index) {
            switch(tag) {
                case "pick":
                    PickWindow.editor = el;
                    PickWindow.autoComplete = auto;
                                        
                    PickWindow.show(trigger, function () {
                        PickWindow.layout.setActiveItem(index);
                        PickWindow.layout.activeItem.initValue(PickWindow);
                    });
                    break;                    
                case "complete":
                    GridPanel1.stopEditing(false);
                    break;
            }
        };
        
        var ratingRenderer = function (value) {
            var r = Store2.getById(value);

            if (Ext.isEmpty(r)) {
                return "";
            }

            return r.data.description;
        };
        
        var setActiveRating = function (w) {
            var value = w.editor.getValue();
            RatingChoose.items.each(function (item) {
                if (item.tag == value) {
                    item.setValue(true);
                    return false;
                }   
            });
        };
        
        var saveRating = function (w) {
            w.editor.setValue(RatingChoose.getValue().tag);
        };
        
        var setCompany = function (w) {
            var record = GridPanel1.activeEditor.record,
                company = w.editor.getValue(),
                rating = record.get("rating");
            
            CompanyName.setValue(company);                
            CompanyRating.items.each(function (item) {
                if (item.tag == rating) {
                    item.setValue(true);
                    return false;
                }   
            });
        };
        
        var saveCompany = function (w) {
            w.editor.setValue(CompanyName.getValue());
            GridPanel1.activeEditor.record.set("rating", CompanyRating.getValue().tag);
        };
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <h1>EditorGrid with TriggerField Editor and Dialog</h1>
    
    <p>Company column: auto complete edit after window hiding</p>
    <p>Rating column: should confirm value by clicking on the 'tick' trigger button</p>
    
    <ext:Store ID="Store1" runat="server">
        <Reader>
            <ext:ArrayReader>
                <Fields>
                    <ext:RecordField Name="company" />
                    <ext:RecordField Name="rating" />
                </Fields>
            </ext:ArrayReader>
        </Reader>
    </ext:Store>
    
    <ext:Store ID="Store2" runat="server">
        <Reader>
            <ext:ArrayReader IDProperty="rating">
                <Fields>
                    <ext:RecordField Name="rating" />
                    <ext:RecordField Name="description" />
                </Fields>
            </ext:ArrayReader>
        </Reader>
    </ext:Store>
    
    <ext:GridPanel 
        ID="GridPanel1" 
        runat="server" 
        StoreID="Store1" 
        StripeRows="true"
        Title="Grid" 
        Width="300" 
        Height="200"
        AutoExpandColumn="Company">
        <ColumnModel runat="server">
            <Columns>
                <ext:Column ColumnID="Company" Header="Company" DataIndex="company">
                    <Editor>
                        <ext:TriggerField runat="server">
                            <Triggers>
                                <ext:FieldTrigger Icon="SimpleEllipsis" Tag="pick" />
                                <ext:FieldTrigger Icon="SimpleTick" Tag="complete" />
                            </Triggers>
                            <Listeners>
                                <TriggerClick Handler="triggerClick(this, trigger, tag, true, 0);" />
                            </Listeners>
                        </ext:TriggerField>
                    </Editor>
                    <EditorOptions AllowBlur="false" ZIndex="8000" />
                </ext:Column>
                
                <ext:Column Header="Rating" DataIndex="rating">
                    <Editor>
                        <ext:ComboBox 
                            runat="server" 
                            StoreID="Store2"
                            DisplayField="description"
                            ValueField="rating"
                            Mode="Local"
                            TriggerAction="All"
                            MinChars="100"
                            Editable="false" 
                            HideTrigger="true">
                            <Triggers>
                                <ext:FieldTrigger Icon="SimpleEllipsis" Tag="pick" />
                                <ext:FieldTrigger Icon="SimpleTick" Tag="complete" />
                            </Triggers>
                            <Listeners>
                                <TriggerClick Handler="triggerClick(this, trigger, tag, false, 1);" />
                            </Listeners>
                        </ext:ComboBox>
                    </Editor>
                    <EditorOptions AllowBlur="false"  ZIndex="8000" />
                    <Renderer Fn="ratingRenderer" />
                </ext:Column>
            </Columns>
        </ColumnModel>
    </ext:GridPanel>
    
    <ext:Window 
        ID="PickWindow" 
        runat="server"
        Hidden="true"
        InitCenter="true"
        Title="Pick a Value"
        Width="300"
        Height="250"
        Modal="true"
        Layout="card"
        Closable="false">
        <Items>
            <ext:Panel 
                runat="server" 
                Padding="5" 
                Layout="form"
                Border="false">
                <Items>
                    <ext:TextField 
                        ID="CompanyName" 
                        runat="server" 
                        Anchor="100%"
                        FieldLabel="Own value" 
                        />
                    
                    <ext:RadioGroup 
                        ID="CompanyRating" 
                        runat="server" 
                        FieldLabel="Rating" 
                        Vertical="true" 
                        ColumnsNumber="1"
                        />                    
                </Items>
                <CustomConfig>
                    <ext:ConfigItem Name="initValue" Value="setCompany" Mode="Raw" />
                    <ext:ConfigItem Name="saveValue" Value="saveCompany" Mode="Raw" />
                </CustomConfig>
            </ext:Panel>
        
            <ext:Panel runat="server" Layout="Fit" Padding="5">
                <Items>
                    <ext:RadioGroup ID="RatingChoose" runat="server" Vertical="true" ColumnsNumber="1" />                    
                </Items>
                <CustomConfig>
                    <ext:ConfigItem Name="initValue" Value="setActiveRating" Mode="Raw" />
                    <ext:ConfigItem Name="saveValue" Value="saveRating" Mode="Raw" />
                </CustomConfig>
            </ext:Panel>
                            
        </Items>
        
        <Buttons>
            <ext:Button runat="server" Text="OK">
                <Listeners>
                    <Click Handler="PickWindow.layout.activeItem.saveValue(PickWindow); if (PickWindow.autoComplete) {GridPanel1.stopEditing(false);} PickWindow.hide();" />
                </Listeners>
            </ext:Button>
            <ext:Button runat="server" Text="Cancel">
                <Listeners>
                    <Click Handler="if (PickWindow.autoComplete) {GridPanel1.stopEditing(true);} PickWindow.hide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
</body>
</html>
