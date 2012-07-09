<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ext.NET Examples</title>
    <style type="text/css">
        *
        {
            margin: 0;
            padding: 0;
            border: 0 none;
            outline: 0;
        }
        body
        {
            font-family: "Myriad Pro" , "Lucida Grande" , "Verdana" , sans-serif;
            font-size: 16px;
        }
        p
        {
            margin: 20px 0 40px 0;
        }
        h1
        {
            font-size: 36px;
            padding: 0;
            margin: 7px 0;
        }
        h2
        {
            font-size: 24px;
        }
        #container
        {
            width: 900px;
            margin-left: auto;
            margin-right: auto;
            padding: 50px 0 0 0;
            position: relative;
        }
        .section
        {
            padding: 10px;
            width: 900px;
            margin: 0 auto;
            background-color: #f1f1f1;
            position: relative;
        }
        .section .content
        {
            height: 800px;
            background-color: #ddd;
            margin-left: 250px;
            text-align: center;
            color: #333;
            font-size: 16px;
        }
        .section .menu
        {
            position: absolute;
            left: 10px;
            width: 240px;
            height: 100px;
            background: #06C;
            text-align: center;
            color: #fff;
            font-size: 14px;
        }
        #ohmygodsomuchwhitespace
        {
            width: 10px;
            height: 1000px;
        }
    </style>
    
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/ext-core/3.1.0/ext-core.js"></script>
    
    <script type="text/javascript">
        Ext.ns("Ext.ux");
        Ext.ux.FloatElement = Ext.extend(Ext.util.Observable, {
            duration: 0.2, 
            lockBottom:true,
                    
            constructor: function(elId, config) {
                config = config || {};
                Ext.apply(this, config);

                Ext.ux.FloatElement.superclass.constructor.call(this, config);

                this.el = Ext.get(elId);                                
                var el = this.el;
                this.options = {
                    offsetY : parseInt(el.parent().getStyle('padding-top')),
                    startOffset : el.parent().getOffsetsTo(Ext.getBody())[1]                    
                };
                
                this.options.bottomPos = el.parent().getHeight() - el.getHeight()- this.options.offsetY;
                
                el.setStyle({ position: 'absolute' });
				
				if(this.lockBottom){					
					if( this.options.bottomPos < 0 ){
						this.options.bottomPos = 0;
			        }
				}
				
		        Ext.EventManager.on(window, 'scroll', this.onScroll, this, {buffer:250});
            },
            
            onScroll : function (e) {
                this.el.stopFx(); 

				var pastStartOffset			= Ext.getBody().getScroll().top > this.options.startOffset,	
				    objFartherThanTopPos	= this.el.getOffsetsTo(Ext.getBody())[1] > this.options.startOffset,
				    objBiggerThanWindow 	= this.el.getHeight() < Ext.getBody().getHeight();	

				if( (pastStartOffset || objFartherThanTopPos) && objBiggerThanWindow ){ 
					var newpos = (Ext.getBody().getScroll().top - this.options.startOffset + this.options.offsetY );
					if ( newpos > this.options.bottomPos )
						newpos = this.options.bottomPos;
					if ( Ext.getBody().getScroll().top < this.options.startOffset ) 
						newpos = this.options.offsetY;
		
					this.el.animate({ top : {to: newpos}}, this.options.duration);
					//this.el.setStyle({top:newpos});
				}
            }
        });
        
        Ext.onReady(function(){
            new Ext.ux.FloatElement("menu", {duration : 0.4});
            new Ext.ux.FloatElement("menu2", {duration : 0.4});
        });
    </script>
</head>
<body>
    <div id="container">
        <h1>Floating elements</h1>
        
        <div class="section">
            <div id="menu" class="menu">
                Sticky menu
            </div>
            
            <div class="content">   
                I wanted to write something incredibly, unabashedly witty here.<br />
                <br />
                I failed. :(
            </div>
        </div>
        
        <div class="section">
            <div id="menu2" class="menu">
                Yep, I'll follow you everywhere as long as you're within my parent
            </div>
            <div class="content">
                You were expecting something clever here, weren't you? I know you did! Fess up!
            </div>
        </div>
        
        <div id="ohmygodsomuchwhitespace">
        </div>
    </div>
</body>
</html>
