<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Getting Started - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css"  rel="stylesheet" type="text/css" />
    <base target="_blank" />
</head>
<body>
    <form runat="server">
        <h1>Welcome to the Ext.NET Examples Explorer</h1>
        
        <h2>Overview</h2>
        
        <p>Ext.NET is a toolkit of AJAX enabled ASP.NET Web Controls.</p>

        <p>Ext.NET includes the powerful cross-browser <a href="http://www.sencha.com/products/extjs/">ExtJS</a> JavaScript Library and 
            simplifies the development of powerful and rich AJAX enabled Web Applications.</p>

        <p>Both Open-Source (Community License) or Closed-Source (Pro License) options are available. 
            The <a href="http://www.ext.net/license/">License Summary</a> outlines differences between the two licensing options. 
            The code and functionality of both the Community and Pro Editions are essentially the same with the only effective difference being the License under which each is released.</p>
            
        <p>Direct access to the latest Ext.NET source code, via read-only SVN access, is available to all Pro Edition License holders with a valid Support Subscription. More information regarding
            Pro Edition Licenses and Support Subscriptions are available in the <a href="http://www.ext.net/store">Store</a>.</p>
            
        <h2>System Requirements</h2>
        
        <ol class="expanded">
            <li><a href="http://www.microsoft.com/visualstudio/">Visual Studio</a> 2008 or 2010</li>
            <li><a href="http://www.microsoft.com/express/vwd/">Visual Web Developer Express</a> 2008 or 2010</li>
            <li>.NET Framework 3.5 and 4.0</li>
        </ol>
        
        <h2>Getting Started (Step-by-Step)</h2>
        
        <ol class="expanded">
            <li>First ensure you have Visual Studio or Visual Web Developer Express installed on your development computer.
                <div class="information"><p>If you do not have a copy of Visual Studio already installed, the <a href="http://www.microsoft.com/express/vwd/">Visual Web Developer Express Edition</a> is free to use and 
                is a great way to get started with ASP.NET and Ext.NET. The Ext.NET Components work exactly the same in both environments.</p></div></li>
            
            <li><p>A Manual installation package (.zip) is available for download at <a href="http://www.ext.net/download/">http://www.ext.net/download/</a>.</p></li>
            
            <li>Create your first "Web Site" Project.
                <ol style="list-style-type: lower-roman;">
                    <li>Open Visual Studio (or Visual Web Developer) and create a new "Web Site" project. From the File Menu, select New > Web Site.</li>
                    <li>The "New Web Site" dialog will open, ensure "ASP.NET Web Site" is selected from the list of Templates.</li>
                    <li>For your first project, the "Location" option of "File System" and default file path should be fine, or modify to fit your preference.</li>
                    <li>Please select your "Language" preference. Whether you choose "Visual C#" or "Visual Basic" is ultimately just dependent on personal coding preferences. 
                        Ext.NET and the Examples Explorer are written in C#, although can be used in any .NET language, including Visual Basic or C#.</li>
                    <li>Click "OK".</li>
                </ol>
            </li>
            
            <li>Add the Ext.NET Controls to your Visual Studio (or Visual Web Developer) Toolbox, see also <a href="http://ext.net/support/readme.txt">README.txt</a>
                <ol style="list-style-type: lower-roman;">
                    <li>Open Visual Studio or Visual Web Developer Express</li>
                    <li>Open an existing web site or create a new web site project.</li>
                    <li>Open or create a new .aspx page.</li>
                    <li>Open the ToolBox panel, typically located on the left side in a fly-out panel (Ctrl + Alt + x).</li>
                    <li>Create a new "Ext.NET" Tab:
                        <ol style="list-style-type: lower-alpha;">
                            <li>Right-Click in the ToolBox area</li>
                            <li>Select "Add Tab"</li>
                            <li>Enter "Ext.NET"</li>
                        </ol>
                    </li>
		            <li>Inside the "Ext.NET" tab, Right-Click and select "Choose Items...".</li>
		            <li>Under the ".NET Framework Components" Tab select the "Browse" button.</li>
		            <li>Navigate to and select the Ext.Net.dll file, choose open.</li>
                    <li>Ext.NET controls should now be added to the list and pre-checked. You can confirm by sorting the list by "Namespace" and scrolling to "Ext.Net"</li>
                    <li>Click "OK". The icons should be added to your ToolBox. You should now be able to drag/drop a Ext.NET component onto your .aspx Page.</li>
                </ol>
            </li>

            <li>Add the required Web.config nodes.
                <ol style="list-style-type: lower-roman;">
                    <li>Open your projects Web.config file.</li>
                    <li>Integrate the following Ext.NET related nodes into your Web.config:<br />
                    <b>Example</b>
                    <br />
<pre style="line-height:18px;" class="code">
&lt;?xml version="1.0"?>
&lt;configuration>
	&lt;configSections>
		&lt;section name="extnet" type="Ext.Net.GlobalConfig" requirePermission="false" />
	&lt;/configSections>
  
	&lt;extnet scriptMode="Release" /> &lt;!-- See Property Options in README.txt -->
  
	&lt;!-- 
		The following system.web section is only requited for running ASP.NET AJAX under Internet
		Information Services 6.0 (or earlier).  This section is not necessary for IIS 7.0 or later.
	-->
	&lt;system.web>
		&lt;httpHandlers>
			&lt;add path="*/ext.axd" verb="*" type="Ext.Net.ResourceHandler" validate="false" />
		&lt;/httpHandlers>
		&lt;httpModules>
			&lt;add name="DirectRequestModule" type="Ext.Net.DirectRequestModule, Ext.Net" />
		&lt;/httpModules>
	&lt;/system.web>
  
	&lt;!-- 
		The system.webServer section is required for running ASP.NET AJAX under Internet Information Services 7.0.
		It is not necessary for previous version of IIS.
	-->
	&lt;system.webServer>
		&lt;validation validateIntegratedModeConfiguration="false"/>
		&lt;modules>
			&lt;add 
				name="DirectRequestModule" 
				preCondition="managedHandler" 
				type="Ext.Net.DirectRequestModule, Ext.Net" 
				/>
		&lt;/modules>
		&lt;handlers>
			&lt;add 
				name="DirectRequestHandler" 
				verb="*" 
				path="*/ext.axd" 
				preCondition="integratedMode" 
				type="Ext.Net.ResourceHandler"
				/>
		&lt;/handlers>
	&lt;/system.webServer>
&lt;/configuration>
</pre>                    
                    </li>
                </ol>
            </li>
           
            <li>Create your first web page.
                <ol style="list-style-type: lower-roman;">
                    <li>Open a .aspx Page</li>
                    <li>Drag the Ext.NET "ResourceManager" control onto your Page. One &lt;ext:ResourceManager runat="server" /> is required on each .aspx Page</li>
                    <li>Drag an Ext.NET "Window" Control onto your Page, then Save (Ctrl + s) your Page.</li>
                    <li>Hit "F5" to start debugging, or Right-Click on the Page and select "View in Browser". Your Page should now render in the browser and the &lt;ext:Window> will be displayed.</li>
                    <li>Enjoy.</li>
                </ol>
            </li>
        </ol>
    </form>
  </body>
</html>
    