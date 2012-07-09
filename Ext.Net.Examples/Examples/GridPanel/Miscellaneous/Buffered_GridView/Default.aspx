<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Buffer Grid Example - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />    
    
    <style type="text/css">
	    .x-grid3-td-topic b {
	        font-family:tahoma, verdana;
	        display:block;
		    overflow:hidden;
		    width:98%;
		    text-overflow:ellipsis;
	    }
	    .x-grid3-td-topic b i {
	        font-weight:normal;
	        font-style: normal;
	        color:#000;
		    overflow:hidden;
		    text-overflow:ellipsis;
	    }
	    .x-grid3-td-topic .x-grid3-cell-inner {
	        white-space: nowrap;
	    }
	</style>
	
	<script type="text/javascript">
        var renderTopic = function (value, p, record) {
            return String.format(
                    '<b><a href="http://extjs.com/forum/showthread.php?t={2}" target="_blank">{0}</a></b><a href="http://extjs.com/forum/forumdisplay.php?f={3}" target="_blank">{1} Forum</a>',
                    value, record.data.forumtitle, record.id, record.data.forumid);
        };
        
        var renderLast = function (value, p, r) {
            return String.format('{0}<br/>by {1}', value.dateFormat('M j, Y, g:i a'), r.data['lastposter']);
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Buffer Grid Example</h1>
        
        <p>This example customizes the grid view to do bufferred rendering of the cells of just the visible rows in the grid. 
        This results in a much smaller DOM structure and substantially improves performance of resizing, forceFit, autoExpandColumn and other layout and DOM manipulation features in a large grid. The smaller DOM structure 
        can also help to improve the overall performance of your Ext application.<br/><br/>
        <b>While this example works perfectly, this is completely experimental and only a subset of standard grid features are available.</b></p>
        
        <p>This grid uses a ScriptTagProxy to fetch cross-domain remote data (from the ExtJS forums).</p>
        
        <ext:Store runat="server" ID="Store1" RemoteSort="true">
            <Proxy>
                <ext:ScriptTagProxy Url="http://extjs.com/forum/topics-browse-remote.php" />
            </Proxy>
            <BaseParams>
                <ext:Parameter Name="lightWeight" Value="true" Mode="Raw" />
                <ext:Parameter Name="ext" Value="js" Mode="Value" />
            </BaseParams>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="0" Mode="Raw" />
                <ext:Parameter Name="limit" Value="500" Mode="Raw" />
            </AutoLoadParams>
            <Reader>
                <ext:JsonReader Root="topics" TotalProperty="totalCount" IDProperty="threadid">
                    <Fields>
                        <ext:RecordField Name="title" />
                        <ext:RecordField Name="forumtitle" />
                        <ext:RecordField Name="forumid" />
                        <ext:RecordField Name="author" />
                        <ext:RecordField Name="replycount" Type="Int" />
                        <ext:RecordField Name="lastpost" Mapping="lastpost" Type="Date" DateFormat="timestamp" /> 
                        <ext:RecordField Name="lastposter" />
                        <ext:RecordField Name="excerpt" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
            <SortInfo Field="lastpost" Direction="DESC" />
        </ext:Store>
        
        <ext:GridPanel 
            ID="GridPanel1" 
            runat="server" 
            StoreID="Store1" 
            Title="ExtJS.com - Browse Forums" 
            Frame="true"
            Width="700" 
            Height="500"
            AutoExpandColumn="topic">
            <ColumnModel>
		        <Columns>
                    <ext:RowNumbererColumn Width="30" />
                    <ext:Column ColumnID="topic" Header="Topic" DataIndex="title" Width="420">
                        <Renderer Fn="renderTopic" />
                    </ext:Column>
                    <ext:Column Header="Replies" DataIndex="replycount" Width="70" Align="right" />                    
                    <ext:Column ColumnID="last" Header="Last Post" DataIndex="lastpost" Width="150">
                        <Renderer Fn="renderLast" />
                    </ext:Column>
		        </Columns>
            </ColumnModel>
            <BottomBar>
                <ext:PagingToolbar runat="server" PageSize="500" DisplayInfo="true" />
            </BottomBar>
            <View>
                <ext:BufferView runat="server" RowHeight="34" ScrollDelay="0" />
            </View>
            <LoadMask ShowMask="true" />
        </ext:GridPanel>          
    </form>
</body>
</html>
