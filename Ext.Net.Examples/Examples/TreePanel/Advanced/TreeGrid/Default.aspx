<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>TreeGrid - Ext.NET Examples</title>
    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var formatHours = function (v) {
            if (v < 1) {
                return Math.round(v * 60) + " mins";
            } else if (Math.floor(v) !== v) {
                var min = v - Math.floor(v);
                return Math.floor(v) + "h " + Math.round(min * 60) + "m";
            } else {
                return v + " hour" + (v === 1 ? "" : "s");
            }
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>TreeGrid</h1>
        
        <ext:TreeGrid 
            runat="server"
            Title="Core Team Projects"
            Width="500"
            Height="300"
            NoLeafIcon="true"
            EnableDD="true">
            <Columns>
                <ext:TreeGridColumn Header="task" Width="230" DataIndex="task" />
                <ext:TreeGridColumn Header="duration" Width="100" DataIndex="duration" Align="Center" SortType="AsFloat">
                    <XTemplate runat="server">
                        <Html>
                            {duration:this.formatHours}
                        </Html>
                        <Functions>
                            <ext:JFunction Name="formatHours" Fn="formatHours" />
                        </Functions>
                    </XTemplate>
                </ext:TreeGridColumn>
                <ext:TreeGridColumn Header="Assigned To" Width="150" DataIndex="user" />
            </Columns>
            
            <Root>
                <ext:TreeNode Text="Tasks">
                    <Nodes>
                        <ext:TreeNode Icon="Folder" Expanded="true">
                            <CustomAttributes>
                                <ext:ConfigItem Name="task" Value="Project: Shopping" Mode="Value" />
                                <ext:ConfigItem Name="duration" Value="13.25" />
                                <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                            </CustomAttributes>
                            <Nodes>
                                <ext:TreeNode Icon="Folder">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="task" Value="Housewares" Mode="Value" />
                                        <ext:ConfigItem Name="duration" Value="1.25" />
                                        <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                    </CustomAttributes>
                                    <Nodes>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Kitchen supplies" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="0.25" />
                                                <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Groceries" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="0.4" />
                                                <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Cleaning supplies" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="0.4" />
                                                <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Office supplies" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="0.2" />
                                                <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                    </Nodes>
                                </ext:TreeNode>
                                <ext:TreeNode Icon="Folder" Expanded="true">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="task" Value="Remodeling" Mode="Value" />
                                        <ext:ConfigItem Name="duration" Value="12" />
                                        <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                    </CustomAttributes>
                                    <Nodes>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Retile kitchen" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="6.5" />
                                                <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                        <ext:TreeNode Icon="Folder">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Paint bedroom" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="2.75" />
                                                <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                            </CustomAttributes>
                                            <Nodes>
                                                <ext:TreeNode Leaf="true">
                                                    <CustomAttributes>
                                                        <ext:ConfigItem Name="task" Value="Ceiling" Mode="Value" />
                                                        <ext:ConfigItem Name="duration" Value="1.25" />
                                                        <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                    </CustomAttributes>
                                                </ext:TreeNode>
                                                <ext:TreeNode Leaf="true">
                                                    <CustomAttributes>
                                                        <ext:ConfigItem Name="task" Value="Walls" Mode="Value" />
                                                        <ext:ConfigItem Name="duration" Value="1.5" />
                                                        <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                                    </CustomAttributes>
                                                </ext:TreeNode>
                                            </Nodes>
                                        </ext:TreeNode>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Decorate living room" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="2.75" />
                                                <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Fix lights" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="0.75" />
                                                <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Reattach screen door" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="2" />
                                                <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                    </Nodes>
                                </ext:TreeNode>
                            </Nodes>
                        </ext:TreeNode>
                        <ext:TreeNode Icon="Folder">
                            <CustomAttributes>
                                <ext:ConfigItem Name="task" Value="Project: Testing" Mode="Value" />
                                <ext:ConfigItem Name="duration" Value="2" />
                                <ext:ConfigItem Name="user" Value="Core Team" Mode="Value" />
                            </CustomAttributes>
                            <Nodes>
                                <ext:TreeNode Icon="Folder">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="task" Value="Mac OSX" Mode="Value" />
                                        <ext:ConfigItem Name="duration" Value="0.75" />
                                        <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                    </CustomAttributes>
                                    <Nodes>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="FireFox" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="0.25" />
                                                <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Safari" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="0.25" />
                                                <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Chrome" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="0.25" />
                                                <ext:ConfigItem Name="user" Value="Tommy Maintz" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                    </Nodes>
                                </ext:TreeNode>
                                <ext:TreeNode Icon="Folder">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="task" Value="Windows" Mode="Value" />
                                        <ext:ConfigItem Name="duration" Value="3.75" />
                                        <ext:ConfigItem Name="user" Value="Darrell Meyer" Mode="Value" />
                                    </CustomAttributes>
                                    <Nodes>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="FireFox" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="0.25" />
                                                <ext:ConfigItem Name="user" Value="Darrell Meyer" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Safari" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="0.25" />
                                                <ext:ConfigItem Name="user" Value="Darrell Meyer" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Chrome" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="0.25" />
                                                <ext:ConfigItem Name="user" Value="Darrell Meyer" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Internet Explorer" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="3" />
                                                <ext:ConfigItem Name="user" Value="Darrell Meyer" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                    </Nodes>
                                </ext:TreeNode>
                                <ext:TreeNode Icon="Folder">
                                    <CustomAttributes>
                                        <ext:ConfigItem Name="task" Value="Linux" Mode="Value" />
                                        <ext:ConfigItem Name="duration" Value="0.5" />
                                        <ext:ConfigItem Name="user" Value="Aaron Conran" Mode="Value" />
                                    </CustomAttributes>
                                    <Nodes>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="FireFox" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="0.25" />
                                                <ext:ConfigItem Name="user" Value="Aaron Conran" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                        <ext:TreeNode Leaf="true">
                                            <CustomAttributes>
                                                <ext:ConfigItem Name="task" Value="Chrome" Mode="Value" />
                                                <ext:ConfigItem Name="duration" Value="0.25" />
                                                <ext:ConfigItem Name="user" Value="Aaron Conran" Mode="Value" />
                                            </CustomAttributes>
                                        </ext:TreeNode>
                                    </Nodes>
                                </ext:TreeNode>
                            </Nodes>
                        </ext:TreeNode>
                    </Nodes>
                </ext:TreeNode>
            </Root>
        </ext:TreeGrid>        
    </form>
</body>
</html>