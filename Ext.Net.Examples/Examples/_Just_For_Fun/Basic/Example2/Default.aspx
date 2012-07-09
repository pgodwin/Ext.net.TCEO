<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ext.NET Examples</title>
    
    <style type="text/css">
        body {
            padding : 20px;
        }
        
        #searchBox {
            width : 300px;
        }
        
        #searchSubmit {
            display : none;
        }
        
        #searchResults	{ 
            width:400px; 
            background:#fff; 
            opacity:0.7; 
            padding:10px; 
            font-size:0.7em; 
            position:absolute; 
            top:60px; 
            left:20px; 
            z-index:5000; 
            border-radius:10px; 
            -webkit-border-radius:10px; 
            -moz-border-radius:10px; 
            display:none; 
            border: solid 1px black;
            background-color: #FDF880;
        }
        
        #selectionImage	{ 
            background:url(search.png) 0 0 no-repeat; 
            position:absolute; 
            width:24px; 
            height:24px;             
            top:-50; 
            left:-50px; 
            z-index:99000; 
            display:block; 
        } 
    </style>
    
    <script type="text/javascript" src="http://www.google.com/jsapi"></script> 
    <script type="text/javascript">	    
	    google.load("ext-core", "3.0");
	    google.load("search","1");	    
	    
	    google.setOnLoadCallback(function () {
	        var selectionImage, selection, searchTriggerFn;
	        
	        var getSelection = function () {
			    try{
			        if(window.getSelection) {
			            return window.getSelection().toString();
			        }
    			    
			        if(document.getSelection) {
			            return document.getSelection().toString();
			        }
    			    
			        var selection = document.selection && document.selection.createRange();
                    if(selection.text) { 
                        return selection.text; 
                    }				
			    } catch(e) { }
    			
			    return false;
		    }
    		
		    var initSelectionImage = function () {
		        selectionImage = Ext.DomHelper.append(Ext.getBody(),{
		            tag   : 'a',
			        id    : 'selectionImage',
		            href  : 'javascript:;',			        
			        title : 'Click here to learn more about this term'
		        });
		        
		        selectionImage = Ext.get(selectionImage);
		        
		        selectionImage.on("click", function () {
		            var searchBox = Ext.get("searchBox");
			        searchBox.dom.value = selection;
			        searchBox.focus();
			        (function () {
			            searchTriggerFn();
			        }).defer(100);			        
		        });
		        
		        selectionImage.setOpacity(0);
		        
		        var content = Ext.get("content");
		        
		        content.on("mouseup", function (e) {
		            selection = getSelection();
		            
		            if(selection && (selection = new String(selection).replace(/^\s+|\s+$/g,'')) && selection.length > 2 && selection.length < 30) {
				        selectionImage.stopFx();
				        selectionImage.setStyle({ 
					        top: (e.getPageY() - 20) + "px",
					        left: (e.getPageX() + 13) + "px"
				        }).fadeIn();
			        }
		        }, content, {delay:10});		        
		       
		        
		        Ext.getBody().on("mousedown",function () { 
		            selectionImage.stopFx();
		            selectionImage.fadeOut(); 
		        }); 
		    }
		    
		    var initSearch = function () {
		        function searchFn () {        			
			        if(!searchLoaded) {
				        searchLoaded = true;
				        
				        var container = Ext.DomHelper.append(Ext.getBody(),{
				            id : "searchResults",
				            style: "display:block"
				        });
				        
				        container = Ext.get(container);
				        container.setOpacity(0);				        
				        
				        var wrapper = Ext.DomHelper.append(container,{
				            style: "position:relative"
				        });
				        
				        wrapper = Ext.get(wrapper);
				        
				        Ext.DomHelper.append(wrapper,{
				            id: "searchResultsPointer"
				        });				        
				        
				        var contentContainer = Ext.DomHelper.append(wrapper,{ 
				            id: "searchResultsContent" 
				        });				        
				        
				        var closer = Ext.DomHelper.append(wrapper,{
					        tag : "a",
					        href: 'javascript:;',
					        html: 'Close'
				        });
				        
				        closer = Ext.get(closer);
				        closer.setStyle({
					        position: 'absolute',
					        bottom: 35,
					        right: 20,
					        'z-index': 9000,
					        display: 'block',
					        'font-weight': 'bold',
					        'text-decoration': 'none',
					        background: '#fdf4c0',
					        padding: '5px 10px',
					        border: '1px solid #ffd200',
					        color: '#222'
				        });
				        closer.on("click", function () {
				            container.fadeOut();
				        });				        

				        
				        var search = new google.search.WebSearch(), 
					        control = new google.search.SearchControl(),
					        options = new google.search.DrawOptions();

				        options.setDrawMode(google.search.SearchControl.DRAW_MODE_TABBED);
				        options.setInput(searchBox.dom);

				        search.setUserDefinedClassSuffix('siteSearch');
				        search.setSiteRestriction('en.wikipedia.org');
				        search.setLinkTarget(google.search.Search.LINK_TARGET_SELF);

				        control.addSearcher(search);
				        control.draw(contentContainer,options);
				        control.setNoResultsString('No results were found.');
				        
				        searchTriggerFn = function (e) {
					        container.setStyle("display","block");
					        if(searchBox.dom.value && searchBox.dom.value != searchBox.getAttribute('placeholder')) {
						        container.fadeIn({endOpacity:0.9});
						        control.execute(searchBox.dom.value);
					        }
					        else {
						        container.fadeOut();
					        }
				        };

				        searchBox.on("keyup", searchTriggerFn);
				        searchBox.un("focus",searchFn);
			        };
		        }
		        
		        var searchBox = Ext.get("searchBox"), 
		            searchLoaded = false;		            
		        
		        searchBox.on("focus",searchFn);
		    }
		    
		    initSelectionImage();
		    initSearch();
	    });
    </script> 
    
    
</head>
<body>    
    <form action="http://google.com/search" id="searchForm"> 
        <input type="hidden" name="sitesearch" value="en.wikipedia.org"/> 
        <input type="search" id="searchBox" name="q" results="5" placeholder="Search on wikipedia..." autocomplete="on" /> 
        <input id="searchSubmit" type="submit" value="Search"/>
    </form>  
    
    <p>Select a word(s) from the below text by mouse to see the effect</p>
    
    <div id="content">
        <h1>ASP.NET</h1>
        <p>From Wikipedia, the free encyclopedia</p>
        <br />
        <p>
            ASP.NET is a web application framework developed and marketed by Microsoft to allow programmers to build dynamic web sites, web applications and web services. It was first released in January 2002 with version 1.0 of the .NET Framework, and is the successor to Microsoft's Active Server Pages (ASP) technology. ASP.NET is built on the Common Language Runtime (CLR), allowing programmers to write ASP.NET code using any supported .NET language. The ASP.NET SOAP extension framework allows ASP.NET components to process SOAP messages.
            
            After the release of Internet Information Services 4.0 in 1997, Microsoft began researching possibilities for a new web application model that would solve common complaints about ASP, especially with regard to separation of presentation and content and being able to write "clean" code.[1] Mark Anders, a manager on the IIS team, and Scott Guthrie, who had joined Microsoft in 1997 after graduating from Duke University, were tasked with determining what that model would look like. The initial design was developed over the course of two months by Anders and Guthrie, and Guthrie coded the initial prototypes during the Christmas holidays in 1997.[2]

            The initial prototype was called "XSP"; Guthrie explained in a 2007 interview that, "People would always ask what the X stood for. At the time it really didn't stand for anything. XML started with that; XSLT started with that. Everything cool seemed to start with an X, so that's what we originally named it."[1] The initial prototype of XSP was done using Java,[3] but it was soon decided to build the new platform on top of the Common Language Runtime (CLR), as it offered an object-oriented programming environment, garbage collection and other features that were seen as desirable features that Microsoft's Component Object Model platform didn't support. Guthrie described this decision as a "huge risk", as the success of their new web development platform would be tied to the success of the CLR, which, like XSP, was still in the early stages of development, so much so that the XSP team was the first team at Microsoft to target the CLR.
            With the move to the Common Language Runtime, XSP was re-implemented in C# (known internally as "Project Cool" but kept secret from the public), and the name changed to ASP+, as by this point the new platform was seen as being the successor to Active Server Pages, and the intention was to provide an easy migration path for ASP developers.[4]
            Mark Anders first demonstrated ASP+ at the ASP Connections conference in Phoenix, Arizona on May 2, 2000. Demonstrations to the wide public and initial beta release of ASP+ (and the rest of the .NET Framework) came at the 2000 Professional Developers Conference on July 11, 2000 in Orlando, Florida. During Bill Gates' keynote presentation, Fujitsu demonstrated ASP+ being used in conjunction with COBOL,[5] and support for a variety of other languages was announced, including Microsoft's new Visual Basic .NET and C# languages, as well as Python and Perl support by way of interoperability tools created by ActiveState.[6]
            Once the ".NET" branding was decided on in the second half of 2000, it was decided to rename ASP+ to ASP.NET. Mark Anders explained on an appearance on The MSDN Show that year that, "The .NET initiative is really about a number of factors, it's about delivering software as a service, it's about XML and web services and really enhancing the Internet in terms of what it can do ... we really wanted to bring its name more in line with the rest of the platform pieces that make up the .NET framework."[4]
            After four years of development, and a series of beta releases in 2000 and 2001, ASP.NET 1.0 was released on January 5, 2002 as part of version 1.0 of the .NET Framework. Even prior to the release, dozens of books had been written about ASP.NET,[7] and Microsoft promoted it heavily as part of their platform for web services. Guthrie became the product unit manager for ASP.NET, and development continued apace, with version 1.1 being released on April 24, 2003 as a part of Windows Server 2003. This release focused on improving ASP.NET's support for mobile devices.
        </p>
    </div>  
</body>
</html>