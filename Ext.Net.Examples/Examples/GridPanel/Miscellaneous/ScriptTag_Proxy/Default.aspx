<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ScriptTag Proxy</title>    
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .x-grid3-td-topic b {
            font-family : tahoma, verdana;
            display     : block;
        }
        .x-grid3-td-topic b i {
            font-weight : normal;
            font-style  : normal;
            color       : #000;
        }
        .x-grid3-td-topic .x-grid3-cell-inner {
            white-space : normal;
        }
        .x-grid3-td-topic a {
            color : #385F95;
            text-decoration : none;
        }
        .x-grid3-td-topic a:hover {
            text-decoration : underline;
        }
        
        .x-grid3-row-body p {
            margin : 5px 5px 10px 5px !important;
        }
    </style>
    
    <script type="text/javascript">
        var template = function (value, metadata, record, rowIndex, colIndex, store) {
            return String.format(
                '<b><a href="http://extjs.com/forum/showthread.php?t={2}" target="_blank">{0}</a>' +
                '</b><a href="http://extjs.com/forum/forumdisplay.php?f={3}" target="_blank">{1} Forum</a>', 
                value, record.data.forumtitle, record.id, record.data.forumid);
        };
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <ext:GridPanel 
        ID="GridPanel1" 
        runat="server" 
        Width="700" 
        Height="500" 
        DisableSelection="true" 
        Title="ExtJS.com - Browse Forums" 
        TrackMouseOver="false">
        <Store>
            <ext:Store runat="server" RemoteSort="true">
                <Proxy>
                    <ext:ScriptTagProxy Url="http://extjs.com/forum/topics-browse-remote.php" />
                </Proxy>
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
        </Store>
        <ColumnModel runat="server">
		    <Columns>
                <ext:Column ColumnID="topic" Header="Topic" DataIndex="title" Width="420">
                    <Renderer Fn="template" />
                </ext:Column>
                <ext:Column Header="Author" DataIndex="author" Width="100" Hidden="true" />
                <ext:Column Header="Replies" DataIndex="replycount" Width="70" Align="right" />
                <ext:Column ColumnID="last" Header="Last Post" DataIndex="lastpost" Width="150">
                    <Renderer Handler="return String.format('{{0}}<br/>by {{1}}', value.dateFormat('M j, Y, g:i a'), record.data['lastposter']);" />
                </ext:Column>
		    </Columns>
        </ColumnModel>
       
        <View>
            <ext:GridView ForceFit="true" EnableRowBody="true" runat="server">
                <GetRowClass Handler="rowParams.body = '<p>' + record.data.excerpt + '</p>'; return 'x-grid3-row-expanded';" />
            </ext:GridView>
        </View>
        <LoadMask ShowMask="true" Msg="Loading Data..." />
    </ext:GridPanel>
    
</body>
</html>
