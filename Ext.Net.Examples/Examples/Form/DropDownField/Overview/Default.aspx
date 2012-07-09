<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
   "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DropDownField Overview - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var getTasks = function (tree) {
            var msg = [], 
                selNodes = tree.getChecked();
            msg.push("[");   
             
            Ext.each(selNodes, function (node) {
                if (msg.length > 1) {
                    msg.push(",");
                }
                
                msg.push(node.text);
            });
            
            msg.push("]");
            
            return msg.join("");
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>DropDownField Overview</h1>
        
        <h2>Panel with AccordionLayout</h2>
        
        <ext:DropDownField ID="Field1" runat="server" TriggerIcon="Search">
            <Component>
                <ext:Panel runat="server" Height="200" Layout="Accordion">
                    <Items>
                        <ext:MenuPanel runat="server" Title="Group 1" Icon="Group">
                            <Menu runat="server">
                                <Items>
                                    <ext:MenuItem runat="server" Text="Item 1" />
                                    <ext:MenuItem runat="server" Text="Item 2" />
                                    <ext:MenuItem runat="server" Text="Item 3" />
                                </Items>
                                <Listeners>
                                    <ItemClick Handler="#{Field1}.setValue('Group 1 - '+menuItem.text);" />
                                </Listeners>
                            </Menu>
                        </ext:MenuPanel>
                        
                        <ext:MenuPanel runat="server" Title="Group 2" Icon="Group">
                            <Menu runat="server">
                                <Items>
                                    <ext:MenuItem runat="server" Text="Item 1" />
                                    <ext:MenuItem runat="server" Text="Item 2" />
                                    <ext:MenuItem runat="server" Text="Item 3" />
                                </Items>
                                <Listeners>
                                    <ItemClick Handler="#{Field1}.setValue('Group 2 - '+menuItem.text);" />
                                </Listeners>
                            </Menu>
                        </ext:MenuPanel>
                        
                        <ext:MenuPanel runat="server" Title="Group 3" Icon="Group">
                            <Menu runat="server">
                                <Items>
                                    <ext:MenuItem runat="server" Text="Item 1" />
                                    <ext:MenuItem runat="server" Text="Item 2" />
                                    <ext:MenuItem runat="server" Text="Item 3" />
                                </Items>
                                <Listeners>
                                    <ItemClick Handler="#{Field1}.setValue('Group 3 - '+menuItem.text);" />
                                </Listeners>
                            </Menu>
                        </ext:MenuPanel>
                    </Items>
                </ext:Panel>
            </Component>
        </ext:DropDownField>
        
        <h2>Panel with Multiple Columns and Custom Align</h2>
        
        <ext:DropDownField ID="Field2" runat="server" TriggerIcon="SimpleRight" ComponentAlign="tl-tr?" Editable="false">
            <Component>
                <ext:Panel runat="server" Width="300" Height="80" Layout="column">
                    <Items>
                         <ext:MenuPanel runat="server" Border="false" ColumnWidth="0.33" SaveSelection="false">
                            <Menu runat="server" ShowSeparator="false">
                                <Items>
                                    <ext:MenuItem runat="server" Text="Item 1" Icon="Group" />
                                    <ext:MenuItem runat="server" Text="Item 2" Icon="Group" />
                                    <ext:MenuItem runat="server" Text="Item 3" Icon="Group" />
                                </Items>
                                <Listeners>
                                    <ItemClick Handler="#{Field2}.setValue(menuItem.text);" />
                                </Listeners>
                            </Menu>
                        </ext:MenuPanel>
                        
                        <ext:MenuPanel runat="server" Border="false" ColumnWidth="0.33" SaveSelection="false">
                            <Menu runat="server" ShowSeparator="false">
                                <Items>
                                    <ext:MenuItem runat="server" Text="Item 4" Icon="Group" />
                                    <ext:MenuItem runat="server" Text="Item 5" Icon="Group" />
                                    <ext:MenuItem runat="server" Text="Item 6" Icon="Group" />
                                </Items>
                                <Listeners>
                                    <ItemClick Handler="#{Field2}.setValue(menuItem.text);" />
                                </Listeners>
                            </Menu>
                        </ext:MenuPanel>
                        
                        <ext:MenuPanel runat="server" Border="false" ColumnWidth="0.33" SaveSelection="false">
                            <Menu runat="server" ShowSeparator="false">
                                <Items>
                                    <ext:MenuItem runat="server" Text="Item 7" Icon="Group" />
                                    <ext:MenuItem runat="server" Text="Item 8" Icon="Group" />
                                    <ext:MenuItem runat="server" Text="Item 9" Icon="Group" />
                                </Items>
                                <Listeners>
                                    <ItemClick Handler="#{Field2}.setValue(menuItem.text);" />
                                </Listeners>
                            </Menu>
                        </ext:MenuPanel>
                    </Items>
                </ext:Panel>
            </Component>
        </ext:DropDownField>
        
        <h2>TreePanel</h2>
        
        <ext:DropDownField ID="Field3" runat="server" Editable="false" Width="300" TriggerIcon="SimpleArrowDown">
            <Component>
                <ext:TreePanel 
                    runat="server" 
                    Title="My Task List"
                    Icon="Accept"
                    Height="300"
                    Shadow="None"
                    UseArrows="true"
                    AutoScroll="true"
                    Animate="true"
                    EnableDD="true"
                    ContainerScroll="true"
                    RootVisible="false">
                    <Root>
                        <ext:TreeNode>
                            <Nodes>
                                <ext:TreeNode Text="To Do" Icon="Folder">
                                    <Nodes>
                                        <ext:TreeNode Text="Go jogging" Leaf="true" Checked="False" />
                                        <ext:TreeNode Text="Take a nap" Leaf="true" Checked="False" />
                                        <ext:TreeNode Text="Clean house" Leaf="true" Checked="False" />
                                    </Nodes>
                                </ext:TreeNode>
                                
                                <ext:TreeNode Text="Grocery List" Icon="Folder">
                                    <Nodes>
                                        <ext:TreeNode Text="Bananas" Leaf="true" Checked="False" />
                                        <ext:TreeNode Text="Milk" Leaf="true" Checked="False" />
                                        <ext:TreeNode Text="Cereal" Leaf="true" Checked="False" />
                                        
                                        <ext:TreeNode Text="Energy foods" Icon="Folder">
                                            <Nodes>
                                                <ext:TreeNode Text="Coffee" Leaf="true" Checked="False" />
                                                <ext:TreeNode Text="Red Bull" Leaf="true" Checked="False" />
                                            </Nodes>
                                        </ext:TreeNode>
                                    </Nodes>
                                </ext:TreeNode>
                                
                                <ext:TreeNode Text="Kitchen Remodel" Icon="Folder">
                                    <Nodes>
                                        <ext:TreeNode Text="Finish the budget" Leaf="true" Checked="False" />
                                        <ext:TreeNode Text="Call contractors" Leaf="true" Checked="False" />
                                        <ext:TreeNode Text="Choose design" Leaf="true" Checked="False" />
                                    </Nodes>
                                </ext:TreeNode>
                            </Nodes>
                        </ext:TreeNode>
                    </Root>
                    
                    <Buttons>
                        <ext:Button runat="server" Text="Close">
                            <Listeners>
                                <Click Handler="#{Field3}.collapse();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                    
                    <Listeners>
                        <CheckChange Handler="this.dropDownField.setValue(getTasks(this), false);" />
                    </Listeners>
                          
                 </ext:TreePanel>
            </Component>
            <Listeners>
                <Expand Handler="this.component.getRootNode().expand(true);" Single="true" Delay="10" />
            </Listeners>
        </ext:DropDownField>
        
        <h2>GridPanel with Grouping</h2>
        
        <ext:Store runat="server" ID="Store1" GroupField="Light">
            <Proxy>
                <ext:HttpProxy Method="POST" Url="../../../GridPanel/Shared/PlantService.asmx/Plants" />
            </Proxy>
            <Reader>
                <ext:XmlReader Record="Plant">
                    <Fields>
                        <ext:RecordField Name="Common" />
                        <ext:RecordField Name="Light" />
                        <ext:RecordField Name="Price" Type="Float" />
                    </Fields>
                </ext:XmlReader>
            </Reader>
            <SortInfo Field="Common" Direction="ASC" />
        </ext:Store>
        
        <ext:DropDownField runat="server" Editable="false" Width="300" TriggerIcon="SimpleArrowDown">
            <Component>
                <ext:GridPanel
                    runat="server" 
                    Height="350" 
                    AutoExpandColumn="Common" 
                    Title="Plants" 
                    Frame="true" 
                    StoreID="Store1">
                    <ColumnModel runat="server">
                        <Columns>
                            <ext:Column ColumnID="Common" Header="Common Name" DataIndex="Common" Width="220" />
                            <ext:Column Header="Light" DataIndex="Light" Width="130" />
                            <ext:Column Header="Price" DataIndex="Price" Width="70" Align="right" Groupable="false">
                                <Renderer Format="UsMoney" />
                            </ext:Column>
                            <ext:CommandColumn>
                                <Commands>
                                    <ext:CommandFill />
                                    <ext:GridCommand Icon="Accept" CommandName="Pick">
                                        <ToolTip Title="Plant" Text="Click to choose this plant" />
                                    </ext:GridCommand>
                                    <ext:CommandSpacer Width="20" />
                                </Commands>
                            </ext:CommandColumn>
                        </Columns>
                    </ColumnModel>
                    
                    <Listeners>
                        <Command Handler="this.dropDownField.setValue(record.data.Common);" />
                    </Listeners>
                    
                    <LoadMask ShowMask="true" />
                    
                    <SelectionModel>
                        <ext:RowSelectionModel runat="server" />
                    </SelectionModel>
                    
                    <View>
                        <ext:GroupingView  
                            ID="GroupingView1"
                            HideGroupedColumn="true"
                            StartCollapsed="true"
                            runat="server" 
                            ForceFit="true"
                            />
                    </View>            
                </ext:GridPanel>
            </Component>
        </ext:DropDownField>
   </form>
</body>
</html>
