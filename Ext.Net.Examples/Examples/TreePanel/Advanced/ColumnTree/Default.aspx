<%@ Page Language="C#" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>ColumnTree - Ext.NET Examples</title>
    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>ColumnTree</h1>
        
        <ext:ColumnTree 
            runat="server"
            Width="550"
            Height="300"
            RootVisible="false"
            AutoScroll="true"
            Title="Example Tasks">
            <Columns>
                <ext:ColumnTreeColumn Header="Tasks" Width="330" DataIndex="Task" />
                <ext:ColumnTreeColumn Header="Duration" Width="100" DataIndex="Duration" />
                <ext:ColumnTreeColumn Header="Assigned To" Width="100" DataIndex="User" />
            </Columns>
            
            <Loader>
                <ext:TreeLoader>
                    <UIProviders>
                        <ext:TreeNodeUIProvider Alias="col" ClassName="<%# ColumnTree.ColumnNodeUI %>" AutoDataBind="true" />
                    </UIProviders>
                </ext:TreeLoader>
            </Loader>
            
            <Root>
                <ext:TreeNode Text="Tasks">
                    <Nodes>
                        <ext:TreeNode UIProvider="col" Icon="FolderGo">
                            <CustomAttributes>
                                <ext:ConfigItem Name="Task" Value="ColumnTree Example" Mode="Value" />
                                <ext:ConfigItem Name="Duration" Value="3 hours" Mode="Value" />
                                <ext:ConfigItem Name="User" Value="" Mode="Value" />
                            </CustomAttributes>
                            
                            <Nodes>
                                <ext:TreeNode UIProvider="col" Icon="Cog" Leaf="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="Task" Value="Abstract rendering in TreeNodeUI" Mode="Value" />
                                        <ext:ConfigItem Name="Duration" Value="15 min" Mode="Value" />
                                        <ext:ConfigItem Name="User" Value="Core Team" Mode="Value" />
                                    </CustomAttributes>
                                </ext:TreeNode>
                                
                                <ext:TreeNode UIProvider="col" Icon="Cog" Leaf="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="Task" Value="Create TreeNodeUI with column knowledge" Mode="Value" />
                                        <ext:ConfigItem Name="Duration" Value="45 min" Mode="Value" />
                                        <ext:ConfigItem Name="User" Value="Core Team" Mode="Value" />
                                    </CustomAttributes>
                                </ext:TreeNode>
                                
                                <ext:TreeNode UIProvider="col" Icon="Cog" Leaf="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="Task" Value="Create TreePanel to render and lock headers" Mode="Value" />
                                        <ext:ConfigItem Name="Duration" Value="30 min" Mode="Value" />
                                        <ext:ConfigItem Name="User" Value="Core Team" Mode="Value" />
                                    </CustomAttributes>
                                </ext:TreeNode>
                                
                                <ext:TreeNode UIProvider="col" Icon="Cog" Leaf="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="Task" Value="Add CSS to make it look fly" Mode="Value" />
                                        <ext:ConfigItem Name="Duration" Value="30 min" Mode="Value" />
                                        <ext:ConfigItem Name="User" Value="Core Team" Mode="Value" />
                                    </CustomAttributes>
                                </ext:TreeNode>
                                
                                <ext:TreeNode UIProvider="col" Icon="Cog" Leaf="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="Task" Value="Test and make sure it works" Mode="Value" />
                                        <ext:ConfigItem Name="Duration" Value="1 hour" Mode="Value" />
                                        <ext:ConfigItem Name="User" Value="Core Team" Mode="Value" />
                                    </CustomAttributes>
                                </ext:TreeNode>
                            </Nodes>
                        </ext:TreeNode>
                        
                        <ext:TreeNode UIProvider="col" Icon="FolderGo">
                            <CustomAttributes>
                                <ext:ConfigItem Name="Task" Value="Custom Field Example" Mode="Value" />
                                <ext:ConfigItem Name="Duration" Value="2 1/2 hours" Mode="Value" />
                                <ext:ConfigItem Name="User" Value="" Mode="Value" />
                            </CustomAttributes>
                            
                            <Nodes>
                                <ext:TreeNode UIProvider="col" Icon="Cog" Leaf="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="Task" Value="Implement 'Live Search' on extjs.com from Alex" Mode="Value" />
                                        <ext:ConfigItem Name="Duration" Value="1 hour" Mode="Value" />
                                        <ext:ConfigItem Name="User" Value="Core Team" Mode="Value" />
                                    </CustomAttributes>
                                </ext:TreeNode>
                                
                                <ext:TreeNode UIProvider="col" Icon="Cog" Leaf="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="Task" Value="Extend TwinTrigger" Mode="Value" />
                                        <ext:ConfigItem Name="Duration" Value="30 min" Mode="Value" />
                                        <ext:ConfigItem Name="User" Value="Core Team" Mode="Value" />
                                    </CustomAttributes>
                                </ext:TreeNode>
                                
                                <ext:TreeNode UIProvider="col" Icon="Cog" Leaf="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="Task" Value="Testing and debugging" Mode="Value" />
                                        <ext:ConfigItem Name="Duration" Value="1 hour" Mode="Value" />
                                        <ext:ConfigItem Name="User" Value="Core Team" Mode="Value" />
                                    </CustomAttributes>
                                </ext:TreeNode>                                
                            </Nodes>
                        </ext:TreeNode>
                        
                        <ext:TreeNode UIProvider="col" Icon="FolderGo">
                            <CustomAttributes>
                                <ext:ConfigItem Name="Task" Value="Misc Items" Mode="Value" />
                                <ext:ConfigItem Name="Duration" Value="3 hours" Mode="Value" />
                                <ext:ConfigItem Name="User" Value="" Mode="Value" />
                            </CustomAttributes>
                            
                            <Nodes>
                                <ext:TreeNode UIProvider="col" Icon="Cog" Leaf="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="Task" Value="Abstract rendering in TreeNodeUI" Mode="Value" />
                                        <ext:ConfigItem Name="Duration" Value="15 min" Mode="Value" />
                                        <ext:ConfigItem Name="User" Value="Core Team" Mode="Value" />
                                    </CustomAttributes>
                                </ext:TreeNode>
                                
                                <ext:TreeNode UIProvider="col" Icon="Cog" Leaf="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="Task" Value="Create TreeNodeUI with column knowledge" Mode="Value" />
                                        <ext:ConfigItem Name="Duration" Value="45 min" Mode="Value" />
                                        <ext:ConfigItem Name="User" Value="Core Team" Mode="Value" />
                                    </CustomAttributes>
                                </ext:TreeNode>
                                
                                <ext:TreeNode UIProvider="col" Icon="Cog" Leaf="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="Task" Value="Create TreePanel to render and lock headers" Mode="Value" />
                                        <ext:ConfigItem Name="Duration" Value="30 min" Mode="Value" />
                                        <ext:ConfigItem Name="User" Value="Core Team" Mode="Value" />
                                    </CustomAttributes>
                                </ext:TreeNode>
                                
                                <ext:TreeNode UIProvider="col" Icon="Cog" Leaf="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="Task" Value="Add CSS to make it look fly" Mode="Value" />
                                        <ext:ConfigItem Name="Duration" Value="30 min" Mode="Value" />
                                        <ext:ConfigItem Name="User" Value="Core Team" Mode="Value" />
                                    </CustomAttributes>
                                </ext:TreeNode>
                                
                                <ext:TreeNode UIProvider="col" Icon="Cog" Leaf="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="Task" Value="Test and make sure it works" Mode="Value" />
                                        <ext:ConfigItem Name="Duration" Value="1 hour" Mode="Value" />
                                        <ext:ConfigItem Name="User" Value="Core Team" Mode="Value" />
                                    </CustomAttributes>
                                </ext:TreeNode>
                            </Nodes>
                        </ext:TreeNode>
                    </Nodes>
                </ext:TreeNode>
            </Root>
        </ext:ColumnTree>
    </form>
</body>
</html>