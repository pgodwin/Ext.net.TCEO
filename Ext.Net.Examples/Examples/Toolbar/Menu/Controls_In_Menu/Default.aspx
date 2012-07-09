<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
     {
        string[][] data = new string[10][];
        
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = new string[5];
        
            for (int j = 0; j < data[i].Length; j++)
            {
                data[i][j] = string.Format("[{0},{1}]", i+1, j+1);
            }
        }
        
        this.Store1.DataSource = data;
        this.Store1.DataBind();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var cellSelect = function (grid, rowIndex, colIndex, textField, ctxMenu) {
            var record = grid.store.getAt(rowIndex),
                name = grid.getColumnModel().getDataIndex(colIndex),
                value = record.get(name);

            textField.setValue(value);
            ctxMenu.hide();
        }
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:Store ID="Store1" runat="server">
        <Reader>
            <ext:ArrayReader>
                <Fields>
                    <ext:RecordField Name="Col1" />
                    <ext:RecordField Name="Col2" />
                    <ext:RecordField Name="Col3" />
                    <ext:RecordField Name="Col4" />
                    <ext:RecordField Name="Col5" />
                </Fields>
            </ext:ArrayReader>
        </Reader>
    </ext:Store>    
    
    <ext:Menu ID="ContextMenu" runat="server">
        <Items>
            <ext:ComponentMenuItem runat="server" Shift="false">
                <Component>
                    <ext:GridPanel 
                        ID="GridPanel1" 
                        runat="server" 
                        StoreID="Store1"
                        EnableHdMenu="false"
                        Border="false"
                        Width="420"
                        Height="245">
                        <ColumnModel runat="server">
		                    <Columns>
                                <ext:RowNumbererColumn />
                                <ext:Column Header="Column ¹1" Width="75" DataIndex="Col1" />
                                <ext:Column Header="Column ¹2" Width="75" DataIndex="Col2" />
                                <ext:Column Header="Column ¹3" Width="75" DataIndex="Col3" />
                                <ext:Column Header="Column ¹4" Width="75" DataIndex="Col4" />
                                <ext:Column Header="Column ¹5" Width="75" DataIndex="Col5" />
		                    </Columns>
                        </ColumnModel> 
                        <View>
                            <ext:GridView runat="server" ScrollOffset="0" ForceFit="true" />
                        </View>            
                        <Listeners>
                            <CellClick Handler="cellSelect(this, rowIndex, columnIndex, #{TextField1}, #{ContextMenu});" />
                        </Listeners>  
                    </ext:GridPanel>
                </Component>
            </ext:ComponentMenuItem>              
        </Items>
    </ext:Menu>
    
    <h1>Menus with Controls</h1>
    
    <h2>Click the right button on the text field for select value</h2>
    
    <ext:TextField ID="TextField1" runat="server" Width="200" ContextMenuID="ContextMenu" ReadOnly="true" />
    
    <h2>See Menu in the Toolbar</h2>
    
    <ext:Toolbar runat="server" Width="500">
        <Items>
            <ext:Button runat="server" Text="Form controls" Icon="NoteEdit">
                <Menu>
                    <ext:Menu runat="server">
                        <Items>
                            <ext:MenuItem runat="server" Icon="NoteEdit" Text="Item" />
                            <ext:ComponentMenuItem runat="server">
                                <Component>
                                    <ext:TextField runat="server" Width="200" />
                                </Component>
                            </ext:ComponentMenuItem>
                            <ext:ComponentMenuItem  runat="server">
                                <Component>
                                    <ext:DateField runat="server" Width="200" />
                                </Component>
                            </ext:ComponentMenuItem>
                            <ext:MenuSeparator />
                            <ext:ComponentMenuItem runat="server">
                                <Component>
                                    <ext:TextArea runat="server" Width="200" Height="100" />
                                </Component>
                            </ext:ComponentMenuItem>
                            <ext:MenuSeparator />
                            <ext:ComponentMenuItem runat="server">
                                <Component>
                                    <ext:ComboBox runat="server" ID="ComboBox1" Width="200" Editable="false">
                                        <Items>
                                            <ext:ListItem Text="Text1" />
                                            <ext:ListItem Text="Text2" />
                                            <ext:ListItem Text="Text3" />
                                            <ext:ListItem Text="Text4" />
                                            <ext:ListItem Text="Text5" />
                                        </Items>
                                        <SelectedItem Value="Text4" />
                                    </ext:ComboBox>    
                                </Component>                        
                            </ext:ComponentMenuItem>
                            <ext:MenuSeparator />
                            <ext:ComponentMenuItem runat="server">
                                <Component>
                                     <ext:FieldSet runat="server" Title="Account Information" Layout="form">
                                        <Items>
                                            <ext:TextField runat="server" Width="170" HideLabel="true" />           
                                            <ext:TextField runat="server" Width="170" HideLabel="true" />                
                                        </Items>
                                    </ext:FieldSet>
                                </Component>
                            </ext:ComponentMenuItem>
                        </Items>
                    </ext:Menu>
                </Menu>
            </ext:Button>
            
            <ext:Button runat="server" Text="Panels" Icon="Application">
                <Menu>
                    <ext:Menu ID="PanelsMenu" runat="server">
                        <Items>
                            <ext:ComponentMenuItem runat="server" Shift="false">
                                <Component>
                                    <ext:Panel 
                                        ID="AutoLoadPanel" 
                                        runat="server" 
                                        Title="Ext.NET Site (lazy loading)"   
                                        Width="300" 
                                        Height="200">
                                        <TopBar>
                                            <ext:Toolbar runat="server">
                                                <Items>
                                                    <ext:ToolbarFill />
                                                    <ext:Button runat="server" Text="Reload" Icon="ArrowRefreshSmall">
                                                        <Listeners>
                                                            <Click Handler="#{AutoLoadPanel}.reload();" />
                                                        </Listeners>
                                                    </ext:Button>
                                                </Items>
                                            </ext:Toolbar>
                                        </TopBar>
                                        <AutoLoad Url="http://www.ext.net/" Mode="IFrame" ShowMask="true" />
                                    </ext:Panel>
                                </Component>
                            </ext:ComponentMenuItem>
                            <ext:MenuSeparator />
                            <ext:ComponentMenuItem runat="server" Shift="false">
                                <Component>
                                    <ext:TabPanel 
                                        runat="server" 
                                        ActiveTabIndex="0" 
                                        Width="300" 
                                        Height="100" 
                                        LayoutOnTabChange="true">
                                        <Items>
                                            <ext:Panel runat="server" Title="Tab1" Icon="Tab">
                                                <Items>
                                                    <ext:Button ID="Button3" runat="server" Text="Close Menu" Icon="Door">
                                                        <Listeners>
                                                            <Click Handler="#{PanelsMenu}.hide();" />
                                                        </Listeners>
                                                    </ext:Button>                        
                                                </Items>
                                            </ext:Panel>
                                            <ext:Panel runat="server" Title="Tab2" Icon="Tab" />
                                            <ext:Panel runat="server" Title="Tab3" Icon="Tab" />
                                        </Items>
                                        <Listeners>
                                            <Render Handler="this.doLayout();" Delay="100" />
                                        </Listeners>
                                   </ext:TabPanel>
                                </Component>
                            </ext:ComponentMenuItem>
                        </Items>
                    </ext:Menu>
                </Menu>
            </ext:Button>
            <ext:Button runat="server" Text="Property Grid" Icon="Table">
                <Menu>
                    <ext:Menu ID="Menu2" runat="server">
                        <Items>
                            <ext:ComponentMenuItem runat="server" Shift="false">
                                <Component>
                                    <ext:PropertyGrid 
                                        ID="PropertyGrid1" 
                                        runat="server" 
                                        Width="300" 
                                        Height="300">
                                        <Source>
                                            <ext:PropertyGridParameter Name="(name)" Value="Properties Grid" />
                                            <ext:PropertyGridParameter Name="grouping" Value="false" Mode="Raw" />
                                            <ext:PropertyGridParameter Name="autoFitColumns" Value="true" Mode="Raw" />
                                            <ext:PropertyGridParameter Name="productionQuality" Value="false" Mode="Raw" />
                                            <ext:PropertyGridParameter Name="created" Value="10/15/2006">
                                                <Editor>
                                                    <ext:DateField ID="DateField1" runat="server" HideTrigger="true">
                                                    </ext:DateField>
                                                </Editor>
                                            </ext:PropertyGridParameter>
                                            <ext:PropertyGridParameter Name="tested" Value="false" Mode="Raw" />
                                            <ext:PropertyGridParameter Name="version" Value="0.01" />
                                            <ext:PropertyGridParameter Name="borderWidth" Value="5" Mode="Raw" />
                                        </Source>
                                        <View>
                                            <ext:GridView runat="server" ForceFit="true" ScrollOffset="2" />
                                        </View>
                                        <Buttons>
                                            <ext:Button runat="server" Text="Save" Icon="Disk">                    
                                            </ext:Button>                
                                        </Buttons>           
                                    </ext:PropertyGrid>
                                </Component>
                            </ext:ComponentMenuItem>
                        </Items>                                                
                    </ext:Menu>
                </Menu>
            </ext:Button>
            <ext:Button runat="server" Text="Layouts" Icon="Layout">
                <Menu>
                    <ext:Menu runat="server">
                        <Items>
                            <ext:ComponentMenuItem runat="server" Shift="false">
                                <Component>
                                    <ext:Panel runat="server" Width="300" Height="200">
                                       <Items>
                                            <ext:BorderLayout runat="server">
                                                <West Split="true">
                                                    <ext:Panel runat="server" Collapsible="true" Title="West" Width="100" />
                                                </West>
                                                <Center>
                                                    <ext:Panel runat="server" Title="Center" />
                                                </Center>
                                            </ext:BorderLayout>
                                       </Items>
                                   </ext:Panel>
                                </Component>
                            </ext:ComponentMenuItem>
                            <ext:ComponentMenuItem runat="server" Shift="false">
                                <Component>
                                    <ext:Panel runat="server" Width="300" Height="200" Layout="Accordion">
                                       <Items>
                                            <ext:Panel runat="server" Title="Panel1" Collapsed="false" />
                                            <ext:Panel runat="server" Title="Panel2" />
                                            <ext:Panel runat="server" Title="Panel3" />
                                        </Items>
                                    </ext:Panel>
                                </Component>
                            </ext:ComponentMenuItem>
                        </Items>                        
                    </ext:Menu>
                </Menu>
            </ext:Button>
        </Items>
    </ext:Toolbar>    
</body>
</html>
