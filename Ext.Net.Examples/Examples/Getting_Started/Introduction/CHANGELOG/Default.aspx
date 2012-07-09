<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>README.txt - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css"  rel="stylesheet" type="text/css" />
</head>
<body>
<pre>
**************************************************************************
*                       Version 1.1.0 CHANGELOG                          *
**************************************************************************

Release Date     : 2011-07-07
Current Version  : 1.1.0
Previous Version : 1.0.0

1.  [UPDATE] [#3624] Update to ExtJS 3.4.0. Enhanced IE9 support.
	http://dev.sencha.com/deploy/ext-3.4.0/release-notes.html

2.  [FIX] [#3638] LinkButton .enable() and .disable() client-side functions 
	were not working as expected. 

3.  [FIX] [#3639] TreePanel .toggleChecked() client-side function had a 
	defect and was fixed. 

4.  [FIX] [#3640] ID confirmation for deleted records was defective. 
    Now fixed. Related to Store.js. 

5.  [FIX] [#3641] Client-side .isDirty() was always returning 'true' if 
	CheckboxSelectionModel used. Defect has been fixed.


**************************************************************************
*                       Version 1.0.0 CHANGELOG                          *
**************************************************************************

Release Date     : 2011-06-24
Current Version  : 1.0.0
Previous Version : 1.0.0 RC2

1.   Renamed Coolite.Ext.Web project to Ext.Net

2.   Renamed Coolite.Examples project to Ext.Net.Examples

3.   Renamed Coolite.Ext.UX project to Ext.Net.UX

4.   Renamed Coolite.EmbeddedResourceBuilder project to Ext.Net.ERB

5.   Renamed Coolite.Utilities project to Ext.Net.Utilities

6.   Renamed Coolite.Sandbox project to Ext.Net.Sandbox

7.   Renamed Coolite.Toolkit.sln Visual Studio Solution file to 
	 Ext.Net.sln.

8.   Renamed Coolite.Ext.Web Namespace to Ext.Net

9.   Renamed Coolite.Utilities Namespace to Ext.Net.Utilities

10.  Renamed Coolite.Ext.UX Namespace to Ext.Net.UX

11.  Renamed server-side root singleton "Ext" class to "X". 

	 Example (Old)
	 
	 if (!Ext.IsAjaxRequest) { }
	 
	 Ext.Msg.Alert("Title", "Message").Show();
	 
	 
	 Example (New)
	 
	 if (!X.IsAjaxRequest) { }
	 
	 X.Msg.Alert("Title", "Message").Show();
	 
	 NOTE: The renaming to "X" only applies to the server-side instance. 
	 The client-side JavaScript root class remains as "Ext". 

12.  Added new feature to get server-side Property values from client id 
     Token strings.
	 
	 Example
	 
	 &lt;ext:Window runat="server" Title="#{TextField1.Text}" />
	 
13.  Renamed WebControl class to ExtControl. As well, renamed 
     Coolite.Ext.Web.WebControl.cs file to Ext.Net.ExtControl.cs.
	 
14.  Removed &lt;ext:ToolbarButton>. Please use &lt;ext:Button>.	 

15.  Removed &lt;ext:ToolbarSplitButton>. Please use &lt;ext:SplitButton>.

16.  Renamed AjaxMethod class to DirectMethod.

17.  Renamed AjaxMethodAttribute to DirectMethodAttribute.

	 Example (Old)
	 
	 [AjaxMethod]
	 public void DoSomthing() { }
	 
	 Example (New)
	 
	 [DirectMethod]
	 public void DoSomthing() { }
	 
18.  Renamed &lt;AjaxEvents> property to &lt;DirectEvents>.	 

19.  Removed &lt;ext:ToolbarSplitButton>. Please use &lt;ext:SplitButton>.

20.  Removed Adapter class

21.  Removed ColorMenuItem class

22.  Removed ComboMenuItem class

23.  Removed DateFieldMenuItem class

24.  Removed DateMenuItem class

25.  Removed EditMenuItem class

26.  Renamed ElementMenuItem class to ComponentMenuItem

27.  Renamed &lt;ext:Accordion> to &lt;ext:AccordionLayout>
	 
28.  Removed DataReader class .ReaderID property.

29.  JsonReader: added IDProperty (instead of ReaderID)	 

30.  XmlReader: added IDPath (instead of ReaderID)

31.  ArrayReader: added IDProperty and IDIndex (instead of ReaderID)

32.  Renamed StoreResponseData class .TotalCount property to .Total.

33.  Renamed StoreRefreshDataEventArgs class .TotalCount propterty to 
	 .Total.

34.  Renamed DataSourceProxy class .TotalCount property to .Total.
	 
35.  Renamed DataSourceProxy class to PageProxy.

36.  Layout collection property is now required in markup if using a 
     Layout Control within &lt;Content> or &lt;Items>.
	
	 &lt;Items>
		AccordionLayout
		ContainerLayout
		CardLayout
		CenterLayout
		FitLayout
     
     &lt;Anchors>
		AbsoluteLayout
		AnchorLayout
		FormLayout
	 
	 &lt;BoxItems>
		HBoxLayout
		VBoxLayout
	 
	 &lt;Rows>
		RowLayout
	 
	 &lt;Columns>
		ColumnLayout
	 
	 &lt;Cells>
		TableLayout
	
37.  Removed [XType] Attribute and replaced with XType readonly property.
 	
	 Example (Old)
	
	 [Xtype("window")]
	
	
	 Example (New)
	
	 protected override string XType
     {
         get
         {
             return "window";
         }
     }	
	
38.  Removed [InstanceOf] Attribute and replaced with InstanceOf readonly 
	 property.
 	 
	 Example (Old)
	
 	 [InstanceOf("Ext.Window")]
	
	
	 Example (New)
	
	 public override string InstanceOf
     {
         get
         {
             return "Ext.Window";
         }
     }
	
39.  Removed [Layout] Attribute and replaced with new .LayoutType readonly
	 property

40.  Removed [ClientStyle] and [ClientScripts] Attributes and replaced 
	 with new .Resources property.

41.  Renamed AjaxRequestModule to DirectRequestModule

42.  Renamed &lt;ext:ScriptManager> to &lt;ext:ResourceManager>

43.  Removed &lt;ext:ResourcePlaceHolder> and &lt;ext:StyleContainer> controls.
	 
	 Please use &lt;ext:ResourcePlaceHolder> with new Mode property which can
	 determine if .js or .css resources are rendered. The Mode property is
	 not required and if not defined, both .js and .css resource files are
	 rendered into the location of the ResourcePlaceHolder. 
	 
	 Example (New)
	 
	 &lt;ext:ResourcePlaceHolder runat="server" Mode="Script" />

44.  Renamed &lt;ext:ViewPort> to &lt;ext:Viewport>. Change to lowercase "p".

45.  Renamed &lt;Body> inner property to &lt;Content>.

	 Affects all ContentPanel type controls including Panel, Window, Viewport
	 Renaming to &lt;Content> also solves &lt;Body> rendering bug in VS 2005.
	 
	 Renaming all &lt;Body> tags in a project to &lt;Content> can be easily 
	 accomplished with a case-sensitive search and replace within Visual 
	 Studio. Please search for the following (remove double quotes) and 
	 ensure you have the "Match case" option checked.

	 Find what: "Body>"
	 Replace with: "Content>"

46.  Renamed .BodyControls property to .ContentControls. 
	 Affects all ContentPanel type controls including Panel, Window, Viewport

47.  Renamed .BodyContainer property to .ContentContainer.
	 Affects all ContentPanel type controls including Panel, Window, Viewport

48.  Removed .UpdateBody() Method. Please use .Update().

49.  Removed &lt;ext:Window> .ShowOnLoad property.
     Please use .Hidden property.
	 
	 Example (Old)
	 
	 // Will show Window on initial Page_Load
	 this.Window1.ShowOnLoad = true;
	 
	 
	 Example (New)
	 
	 // Will show Window on initial Page_Load
	 this.Window.Hidden = false; // 'false' is the default value
	 
50.  Renamed the &lt;ext:Window> .CenterOnLoad property to .InitCenter.
	 Default value is unchanged as "true".
	 
	 Example (Old)
	 
	 // Will center Window on initial Page_Load
	 this.Window1.CenterOnLoad = true;
	 
	 
	 Example (New)
	 
	 // Will center Window on initial Page_Load
	 this.Window.InitCenter = true;
	 
51.  Renamed TextMenuItem control to the MenuTextItem

52.  GridPanel client API: submitData, getRowsValues has 1 argument only,
     config object

53.  GenericPlugin: renamed InstanceOf to InstanceName.

54.  Renamed TabPanel &lt;Tabs> Collection to &lt;Items>.

	 Example (Old)
	 
	 &lt;ext:TabPanel runat="server">
         &lt;Tabs>
             &lt;ext:Tab runat="server" Title="Tab 1" />
	 
	 
	 Example (New)
	 
	 &lt;ext:TabPanel runat="server">
         &lt;Items>
             &lt;ext:Panel runat="server" Title="Tab 1" />
             
55.  Removed &lt;ext:Tab> Control. Now any Ext.Net.PanelBase Component can be
     added to the TabPanel's .Items Collection. 
     
56.  XTemplate: renamed Text to Html

57.  XTemplate: Html property is required in markup
     &lt;Template>
	     &lt;Html>
	         ....
	     &lt;/Html>
	   
58.  To disable a Field, the .Disabled property should be used instead of 
	 the native ASP.NET .Enabled property. 
	 
	 See http://forums.ext.net/showthread.php?5080#post22850
	 
59.  Removed the static Instance method from Ext.Net.MessageBox class. The
     MessageBox class was changed from an Singleton to just a standard 
     (non-singleton) class.
     
     Using the X.Msg Helper is recommended method of instantiating a
     MessageBox class. 
     
     Be sure to checkout the new X.Msg.Notify Method.
     
     Example
     
     X.Msg.Notify("Alert", "A Message from the Server-Side").Show();

60.  Renamed Coolite.Ext.Web.MessageBox.Config to Ext.Net.MessageBoxConfig	 

61.  XmlReader: rename TotalRecords to the TotalProperty

62.  Added new .After property to DirectEvents. 

	 The .After handler is called immediately after the DirectEvent is fired 
	 and before the response is returned from the server.
      
     See more, http://forums.ext.net/showthread.php?6600	
	 
63.  The &lt;ext:TokenScript> component has been renamed to &lt;ext:XScript>

	 Example (Old)
	 
	 &lt;ext:TokenScript runat="server" />
	 
	 Example (New)
	 
	 &lt;ext:XScript runat="server" />
	 
64.  Renamed AjaxEventArgs property to DirectEventArgs

65.  Renamed AjaxMethodProxyID property to DirectMethodProxyID

66.  Renamed ComboBox and DropDownField .Icon property to .TriggerIcon. 

	 Example (Old)
	 
	 &lt;ext:DropDownField runat="server" Icon="Search" />
	 
	 Example (New)
	 
	 &lt;ext:DropDownField runat="server" TriggerIcon="Search" />
	 
67.  The &lt;ext:MultiField> has been replaced with the new 
	 &lt;ext:CompositeField>.
	 
	 The old inner &lt;Fields> property of &lt;ext:MultiField> should now be 
	 configured in the &lt;Items> property of &lt;ext:CompositeField>.
	 
68.  ColumnLayout: FitHeight property is true by default (it was false by 
     default for the 0.8.2)
 
69.  Tip.cs, changed .MinWidth and .MaxWidth property type from "int" to 
     "Unit". Default value remains the same at "40". 

70.  GridPanel, changed .MaxHeight property type from "int" to "Unit".
	 Default value remains the same at "400".

71.  GridPanel, changed .MinColumnWidth property type from "int" to "Unit"
	 Default value remains the same at "25".
	 
72.  The .HiddenId property of ComboBox was renamed to .HiddenID.
	 Functionality remains the same.
	 
73.  Renamed the Field.cs property .IsNull to .IsEmpty.

74.  Renamed the Field.cs property .NullValue to .EmptyValue.

75.  Renamed the standard first parameter of Component Listener arguments 
     to "item". Previous parameter name was "el". 
     
     The argument "item" is automatically passed as the first argument of 
     the Listener function Handler. 
        
     The scope of "this" is an instance of the Component which fired the
     event. 
        
     Both "item" and "this" will refer to the same Component instance.
     
     It is recommended that developers refer to the Component instance as 
     "this", instead of "item", although both will work. 
     
     Using "this" instead of "item" will avoid any future breaking 
     changes.
     
     Example
     
     &lt;ext:Panel runat="server" Title="Example">
	    &lt;Listeners>
		    // Old
			&lt;Hide Handler="alert(el);" />
	        
			// New
			&lt;Hide Handler="alert(item);" />
	        
			// Recommended
			&lt;Hide Handler="alert(this);" />
		&lt;/Listeners>
	 &lt;/ext:Panel>

76.  GroupName property of Radio widget is removed. Please use Name property.
     Please note that GroupName property of RadioGroup still exists (RadioGroup's GroupName is applied to each child Radio if AutomaticGrouping is true)
	
77.  LowerCase of RendererFormat enum is renamed to Lowercase (to correct name serialization)

78.  Renamed the ResourceManager property .RemoveViewState to .DisableViewState. 

     Example (old)
	 
	 &lt;ext:ResourceManager runat="server" RemoveViewState="true" />
	 
	 Example (new)
	 
	 &lt;ext:ResourceManager runat="server" DisableViewState="true" />
	 
79.  In prior releases, the Store .Load Listener was previously delayed by
     10 milliseconds. This delay was removed as of v1.0 RC2.

	 Projects configured to use the .Load Listener may require setting a
	 10 millisecond delay. 

	 Example

	 &lt;Load Handler="..." Delay="10" />

      
--------------------------------------------------------------------------
</pre>
</body>
</html>
    