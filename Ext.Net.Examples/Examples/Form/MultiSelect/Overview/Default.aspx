<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void SubmitSelection1(object sender, DirectEventArgs e)
    {
        this.ShowSelection(MultiSelect3);
    }

    protected void SubmitSelection2(object sender, DirectEventArgs e)
    {
        this.ShowSelection(MultiSelect4);
    }
    
    private void ShowSelection(MultiSelect ctrl)
    {
        StringBuilder sb = new StringBuilder(256);
        sb.Append("Ext.Msg.alert('Selection', '");

        foreach (SelectedListItem item in ctrl.SelectedItems)
        {
            sb.AppendFormat("Value={0}, Index={1}, Text={2} <br/>", item.Value, item.Index, item.Text);
        }

        sb.Append("');");
        
        ctrl.AddScript(sb.ToString());
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Overview of MultiSelect - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .label {
            font    : bold 11px tahoma,arial,sans-serif;
            width   : 300px;
            height  : 15px;
            padding : 5px 0;
            border  : 1px dotted #99bbe8;
            color   : #15428b;
            cursor  : default;
            margin  : 10px;
            background  : #dfe8f6;
            text-align  : center;
            margin-left : 0px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <ext:TabPanel runat="server" Plain="true" Height="400" LayoutOnTabChange="true">
            <Items>
                <ext:Panel runat="server" Title="Legend" Padding="10">
                    <Items>
                        <ext:TableLayout runat="server" Columns="2">
                            <Cells>
                                <ext:Cell>
                                    <ext:Label runat="server" Html="<div class='label'>With Legend</div>" />                                
                                </ext:Cell>
                                <ext:Cell>
                                    <ext:Label runat="server" Html="<div class='label'>Without Legend</div>" />                                
                                </ext:Cell>
                                
                                <ext:Cell>
                                    <ext:Panel runat="server" Border="false" BodyStyle="height: 260px;">
                                        <Items>
                                            <ext:MultiSelect runat="server" Legend="With Legend" Width="300" Height="250">
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
                                </ext:Cell>
                                
                                <ext:Cell>
                                    <ext:Panel runat="server" Border="false" BodyStyle="height: 260px;">
                                        <Items>
                                            <ext:MultiSelect 
                                                runat="server" 
                                                Width="300" 
                                                Height="250">
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
                                </ext:Cell>
                            </Cells>
                        </ext:TableLayout>                        
                    </Items>
                </ext:Panel>
                
                 <ext:Panel runat="server" Title="Selection Mode" Padding="10">
                    <Items>
                        <ext:TableLayout runat="server" Columns="2">
                            <Cells>
                                <ext:Cell>
                                    <ext:Label runat="server" Html="<div class='label'>Always keep selection on click</div>" />                                
                                </ext:Cell>
                                <ext:Cell>
                                    <ext:Label runat="server" Html="<div class='label'>Keep selection with Ctrl key</div>" />                                
                                </ext:Cell>
                                
                                <ext:Cell>
                                    <ext:Panel runat="server" Border="false" BodyStyle="height: 260px;">
                                        <Items>
                                            <ext:MultiSelect runat="server" Width="300" Height="250">
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
                                </ext:Cell>
                                
                                <ext:Cell>
                                    <ext:Panel ID="Panel2" runat="server" Border="false" BodyStyle="height: 260px;">
                                        <Items>
                                            <ext:MultiSelect runat="server" Width="300" Height="250" KeepSelectionOnClick="WithCtrlKey">
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
                                </ext:Cell>
                            </Cells>
                        </ext:TableLayout>                        
                    </Items>
                </ext:Panel>
                
                <ext:Panel runat="server" Title="Bars" Padding="10">
                    <Items>
                        <ext:TableLayout runat="server" Columns="2">
                            <Cells>
                                <ext:Cell>
                                    <ext:Label runat="server" Html="<div class='label'>Top Bar</div>" />                                
                                </ext:Cell>
                                <ext:Cell>
                                    <ext:Label runat="server" Html="<div class='label'>Bottom Bar</div>" />                                
                                </ext:Cell>
                                <ext:Cell>
                                    <ext:Panel runat="server" Border="false" Layout="Fit" Width="300" Height="250">
                                        <TopBar>
                                            <ext:Toolbar runat="server">
                                                <Items>
                                                    <ext:Button runat="server" Text="Clear Selection">
                                                        <Listeners>
                                                            <Click Handler="#{MultiSelect1}.reset();" />
                                                        </Listeners>
                                                    </ext:Button>
                                                </Items>
                                            </ext:Toolbar>
                                        </TopBar>
                                        <Items>                                        
                                            <ext:MultiSelect ID="MultiSelect1" runat="server">                                                
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
                                </ext:Cell>
                                
                                <ext:Cell>
                                    <ext:Panel runat="server" Border="false" Layout="Fit" Width="300" Height="250">
                                        <Items>
                                            <ext:MultiSelect ID="MultiSelect2" runat="server">
                                                <Items>
                                                    <ext:ListItem Text="Item 1" Value="1" />
                                                    <ext:ListItem Text="Item 2" Value="2" />
                                                    <ext:ListItem Text="Item 3" Value="3" />
                                                    <ext:ListItem Text="Item 4" Value="4" />
                                                    <ext:ListItem Text="Item 5" Value="5" />
                                                </Items>                                                
                                            </ext:MultiSelect>                                                  
                                        </Items>
                                        
                                        <BottomBar>
                                            <ext:Toolbar runat="server">
                                                <Items>
                                                    <ext:Button  runat="server" Text="Select [2,3]">
                                                        <Listeners>
                                                            <Click Handler="#{MultiSelect2}.setValue([2, 3]);" />
                                                        </Listeners>
                                                    </ext:Button>
                                                </Items>
                                            </ext:Toolbar>
                                        </BottomBar>
                                    </ext:Panel>                                                             
                                </ext:Cell>
                            </Cells>
                        </ext:TableLayout>                        
                    </Items>
                </ext:Panel>
                
                <ext:Panel runat="server" Title="Drag/Drop (Append Mode)" Padding="10">
                    <Items>
                        <ext:TableLayout runat="server" Columns="2">
                            <Cells>
                                <ext:Cell>
                                    <ext:Label ID="Label1" runat="server" Html="<div class='label'>Drag</div>" />                                
                                </ext:Cell>
                                <ext:Cell>
                                    <ext:Label ID="Label2" runat="server" Html="<div class='label'>Drop</div>" />                                
                                </ext:Cell>
                                
                                <ext:Cell>
                                    <ext:Panel runat="server" Border="false" BodyStyle="height: 260px;">
                                        <Items>                                        
                                            <ext:MultiSelect runat="server" AppendOnly="true" DragGroup="grp1" Width="300" Height="250" KeepSelectionOnClick="WithCtrlKey">
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
                                </ext:Cell>
                                
                                <ext:Cell>
                                    <ext:Panel runat="server" Border="false" BodyStyle="height: 260px;">
                                        <Items>
                                            <ext:MultiSelect runat="server" AppendOnly="true" DropGroup="grp1" Width="300" Height="250" KeepSelectionOnClick="WithCtrlKey">
                                                <Items>
                                                    <ext:ListItem Text="Item 6" Value="6" />
                                                    <ext:ListItem Text="Item 7" Value="7" />
                                                    <ext:ListItem Text="Item 8" Value="8" />
                                                    <ext:ListItem Text="Item 9" Value="9" />
                                                    <ext:ListItem Text="Item 10" Value="10" />
                                                </Items>                                            
                                            </ext:MultiSelect>      
                                        </Items>
                                    </ext:Panel>                                                             
                                </ext:Cell>
                            </Cells>
                        </ext:TableLayout>                        
                    </Items>
                </ext:Panel>
            
                <ext:Panel runat="server" Title="Drag/Drop (Insert Mode)" Padding="10">
                    <Items>
                        <ext:TableLayout runat="server" Columns="2">                            
                            <Cells>
                                <ext:Cell>
                                    <ext:Label runat="server" Html="<div class='label'>Drag/Drop with Reorder</div>" />                                
                                </ext:Cell>
                                <ext:Cell>
                                    <ext:Label runat="server" Html="<div class='label'>Drag/Drop with Reorder</div>" />                                
                                </ext:Cell>
                                
                                <ext:Cell>
                                    <ext:Panel runat="server" Border="false" BodyStyle="height: 260px;">
                                        <Items>                                        
                                            <ext:MultiSelect runat="server" DragGroup="grp1" DropGroup="grp2,grp1" Width="300" Height="250" KeepSelectionOnClick="WithCtrlKey">
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
                                </ext:Cell>
                                
                                <ext:Cell>
                                    <ext:Panel runat="server" Border="false" BodyStyle="height: 260px;">
                                        <Items>
                                            <ext:MultiSelect runat="server" DragGroup="grp2" DropGroup="grp1,grp2" Width="300" Height="250" KeepSelectionOnClick="WithCtrlKey">
                                                <Items>
                                                    <ext:ListItem Text="Item 6" Value="6" />
                                                    <ext:ListItem Text="Item 7" Value="7" />
                                                    <ext:ListItem Text="Item 8" Value="8" />
                                                    <ext:ListItem Text="Item 9" Value="9" />
                                                    <ext:ListItem Text="Item 10" Value="10" />
                                                </Items>                                            
                                            </ext:MultiSelect>      
                                        </Items>
                                    </ext:Panel>                                                             
                                </ext:Cell>
                            </Cells>
                        </ext:TableLayout>                        
                    </Items>
                </ext:Panel>
                
                <ext:Panel runat="server" Title="Submit Text" Padding="10">
                    <Items>
                        <ext:TableLayout runat="server" Columns="2">                            
                            <Cells>
                                <ext:Cell>
                                    <ext:Label runat="server" Html="<div class='label'>Indexes and Values Submit</div>" />                                
                                </ext:Cell>
                                <ext:Cell>
                                    <ext:Label runat="server" Html="<div class='label'>Indexes, Values and Text Submit</div>" />                                
                                </ext:Cell>
                                
                                <ext:Cell>
                                    <ext:Panel runat="server" Border="false" Width="300" Height="250" Layout="Fit">
                                        <Items>                                        
                                            <ext:MultiSelect ID="MultiSelect3" runat="server" SubmitText="false">
                                                <Items>
                                                    <ext:ListItem Text="Item 1" Value="1" />
                                                    <ext:ListItem Text="Item 2" Value="2" />
                                                    <ext:ListItem Text="Item 3" Value="3" />
                                                    <ext:ListItem Text="Item 4" Value="4" />
                                                    <ext:ListItem Text="Item 5" Value="5" />
                                                </Items>
                                                <SelectedItems>
                                                    <ext:SelectedListItem Value="1" />
                                                    <ext:SelectedListItem Value="3" />
                                                    <ext:SelectedListItem Value="5" />
                                                </SelectedItems>                                                
                                            </ext:MultiSelect>      
                                        </Items>
                                        
                                        <BottomBar>
                                            <ext:Toolbar runat="server">
                                                <Items>
                                                    <ext:ToolbarFill />
                                                    <ext:Button runat="server" Text="Submit">
                                                        <DirectEvents>
                                                            <Click OnEvent="SubmitSelection1" />
                                                        </DirectEvents>
                                                    </ext:Button>
                                                </Items>
                                            </ext:Toolbar>
                                        </BottomBar>
                                    </ext:Panel>                                                             
                                </ext:Cell>
                                
                                <ext:Cell>
                                    <ext:Panel runat="server" Border="false" Width="300" Height="250" Layout="Fit">
                                        <Items>
                                            <ext:MultiSelect ID="MultiSelect4" runat="server">
                                                <Items>
                                                    <ext:ListItem Text="Item 6" Value="6" />
                                                    <ext:ListItem Text="Item 7" Value="7" />
                                                    <ext:ListItem Text="Item 8" Value="8" />
                                                    <ext:ListItem Text="Item 9" Value="9" />
                                                    <ext:ListItem Text="Item 10" Value="10" />
                                                </Items>   
                                                <SelectedItems>
                                                    <ext:SelectedListItem Value="7" />
                                                    <ext:SelectedListItem Value="9" />
                                                </SelectedItems>                                                                                         
                                            </ext:MultiSelect>      
                                        </Items>
                                        
                                        <BottomBar>
                                            <ext:Toolbar  runat="server">
                                                <Items>
                                                    <ext:ToolbarFill />
                                                    <ext:Button runat="server" Text="Submit">
                                                        <DirectEvents>
                                                            <Click OnEvent="SubmitSelection2" />
                                                        </DirectEvents>
                                                    </ext:Button>
                                                </Items>
                                            </ext:Toolbar>
                                        </BottomBar>
                                    </ext:Panel>                                                             
                                </ext:Cell>
                            </Cells>
                        </ext:TableLayout>                        
                    </Items>
                </ext:Panel>
            </Items>
        </ext:TabPanel>
    </form>
</body>
</html>
