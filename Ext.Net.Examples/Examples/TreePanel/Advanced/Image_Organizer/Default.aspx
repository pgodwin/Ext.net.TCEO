<%@ Page Language="C#" %>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

 <script runat="server">
    private int NewIndex
    {
        get
        {
            return (int) (Session["newIndex"] ?? 3);
        }
        set
        {
            Session["newIndex"] = value;
        }
    }
     
     protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                string path = Server.MapPath("resources/thumbs");
                string[] files = System.IO.Directory.GetFiles(path);

                List<object> data = new List<object>(files.Length);
                foreach (string fileName in files)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
                    data.Add(new
                    {
                        name = fi.Name,
                        url = "resources/thumbs/" + fi.Name
                    });
                }

                this.Store1.DataSource = data;
                this.Store1.DataBind();
            }
        }

        protected void NewAlbumClick(object sender, DirectEventArgs e)
        {
            TreePanel1.AppendChild("root", new Ext.Net.TreeNode
                                               {
                                                   NodeID = (++NewIndex).ToString(),
                                                   Text = "Album "+NewIndex,
                                                   Cls = "album-node",
                                                   AllowDrag=false
                                               });
            TreePanel1.SelectNode(NewIndex.ToString());
            TreePanel1.StartEdit(NewIndex.ToString(), 10);
        }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>Organizing Images into Albums</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    <link href="resources/organizer.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        var getDragData = function(e){
            var target = e.getTarget('.thumb-wrap');
            if (target){
                var view = ImageView;
                if (!view.isSelected(target)){
                    view.onClick(e);
                }
                var selNodes = view.getSelectedNodes();
                var dragData = {
                    nodes: selNodes
                };
                if (selNodes.length == 1){
                    dragData.ddel = target;
                    dragData.single = true;
                }else{
                    var div = document.createElement('div');
                    div.className = 'multi-proxy';
                    for(var i = 0, len = selNodes.length; i < len; i++){
                        div.appendChild(selNodes[i].firstChild.firstChild.cloneNode(true));
                        if ((i+1) % 3 == 0){
                            div.appendChild(document.createElement('br'));
                        }
                    }
                    var count = document.createElement('div');
                    count.innerHTML = i + ' images selected';
                    div.appendChild(count);
                    
                    dragData.ddel = div;
                    dragData.multi = true;
                }
                return dragData;
            }
            return false;
        };

        var getTreeNode = function(){
            var treeNodes = [];
            var nodeData = ImageView.getRecords(this.dragData.nodes);
            for(var i = 0, len = nodeData.length; i < len; i++){
                var data = nodeData[i].data;
                treeNodes.push(new Ext.tree.TreeNode({
                    text: data.name,
                    icon: data.url,
                    data: data,
                    leaf:true,
                    cls: 'image-node'
                }));
            }
            return treeNodes;
        };

        var afterRepair = function(){
            for(var i = 0, len = this.dragData.nodes.length; i < len; i++){
                Ext.fly(this.dragData.nodes[i]).frame('#8db2e3', 1);
            }
            this.dragging = false;    
        };
        
        var getRepairXY = function(e){
            if (!this.dragData.multi){
                var xy = Ext.Element.fly(this.dragData.ddel).getXY();
                xy[0]+=3;xy[1]+=3;
                return xy;
            }
            return false;
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:Store runat="server" ID="Store1">
            <Reader>
                <ext:JsonReader IDProperty="name">
                    <Fields>
                        <ext:RecordField Name="name" />
                        <ext:RecordField Name="url" /> 
                        <ext:RecordField Name="shortName" Mapping="name">
                            <Convert Handler="return Ext.util.Format.ellipsis(value, 15);" />
                        </ext:RecordField>
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>   
        
        <h1>Organizing Images into Albums</h1>
        <p>This example shows demonstrates how you can drop anything into the tree.</p>
        <p>This example also shows how a customized DragZone can be
        applied to a JsonView to get automatic lightweight drag and drop of asynchronously loaded data.</p>
        <p>The multi image drag drop added a little complexity to the code, but hopefully it is still easy to follow.</p>
        <p>For simplicity, there is no validation on the names you enter in the tree node editor and you can drag the same picture
        into an album as many times as you want.</p>
        <p>Hold shift/control to select multiple images in the main images view. You can drag those images into the tree.</p>
        
        
        <ext:Panel runat="server"
            Width="650"
            Height="400"
        >
            <Items>
                <ext:BorderLayout runat="server">
                    <West Split="true" MarginsSummary="5 0 5 5">
                        <ext:TreePanel ID="TreePanel1" runat="server"
                            Animate="true"
                            EnableDD="true"
                            ContainerScroll="true"
                            DDGroup="organizerDD"
                            RootVisible="false"
                            Width="200"
                            Title="My Albums"
                            AutoScroll="true"
                        >
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Button runat="server" Text="New Album" IconCls="album-btn">
                                            <DirectEvents>
                                                <Click OnEvent="NewAlbumClick"></Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            
                            <Root>
                                <ext:TreeNode NodeID="root" Text="Albums" AllowDrag="false" AllowDrop="false">
                                    <Nodes>
                                        <ext:TreeNode NodeID="1" Text="Album 1" AllowDrag="false" Cls="album-node"/>
                                        <ext:TreeNode NodeID="2" Text="Album 2" AllowDrag="false" Cls="album-node"/>
                                        <ext:TreeNode NodeID="3" Text="Album 3" AllowDrag="false" Cls="album-node"/>
                                    </Nodes>
                                </ext:TreeNode>
                            </Root>
                            
                            <Editors>
                                <ext:TreeEditor runat="server" AutoShow="false">
                                    <Field>
                                        <ext:TextField runat="server" AllowBlank="false" BlankText="A name is required" SelectOnFocus="true" />
                                    </Field>
                                </ext:TreeEditor>
                            </Editors>
                        </ext:TreePanel>
                    </West>
                    
                    <Center MarginsSummary="5 5 5 0">
                        <ext:Panel runat="server" ID="Images" Title="My Images" Cls="images" Layout="fit">
                            <Items>
                                <ext:DataView ID="ImageView" runat="server"
                                    ItemSelector="div.thumb-wrap"
                                    StyleSpec="overflow:auto"
                                    MultiSelect="true"
                                    StoreID="Store1"
                                >
                                    <Template>
                                        <Html>
											<tpl for=".">
												<div class="thumb-wrap" id="{name}">
													<div class="thumb">
														<img src="{url}" class="thumb-img">
													</div>
													<span>{shortName}</span>
												</div>
											</tpl>
										</Html>
                                    </Template>
                                </ext:DataView>
                            </Items>
                        </ext:Panel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Panel>
        
        <ext:DragZone runat="server" Target="ImageView" Group="organizerDD" ContainerScroll="true">
            <GetDragData Fn="getDragData" />
            <GetRepairXY Fn="getRepairXY" />
            <AfterRepair Fn="afterRepair" />
            
            <CustomConfig>
                <ext:ConfigItem Name="getTreeNode" Value="getTreeNode" Mode="Raw" />
            </CustomConfig>
        </ext:DragZone>
    </form>
</body>
</html>