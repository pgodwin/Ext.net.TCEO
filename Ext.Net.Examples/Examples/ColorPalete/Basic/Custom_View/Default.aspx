<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ColorPalate Overview - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .x-color-palette {
            width: 350px !important;
        }
    </style>  
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:ColorPalette runat="server">
            <Template runat="server">
                <Html>
					<tpl for=".">
						<a href="#" class="color-{.}" hidefocus="on">
							<em style="padding:2px;">
								<span style="background:#{.}; width:50px; height:20px; border:1px solid black;" unselectable="on">
									&#160;
								</span>
								<div style="font-size:10px;text-align:center;">#{.}</div>
							</em>
						</a>
					</tpl>
				</Html>
            </Template>
        </ext:ColorPalette>
    </form>
</body>
</html>
