Ext.ns("X");

var makeTab = function (id, url, title) {
    var win, 
        tab, 
        hostName, 
        exampleName, 
        node, 
        tabTip;
    
    if (id === "-") {
        id = Ext.id(undefined, "extnet");
        lookup[url] = id;
    }
    
    tabTip = url.replace(/^\//g, "");
    tabTip = tabTip.replace(/\/$/g, "");
    tabTip = tabTip.replace(/\//g, " > ");
    tabTip = tabTip.replace(/_/g, " ");
    
    win = new Ext.Window({
        id      : "w" + id,
        layout  : "fit",        
        title   : "Source Code",
        iconCls : "icon-pagewhitecode",
        width   : 925,
        height  : 650,
        maximizable : true,
        constrain   : true,
        closeAction : "hide",
        listeners : {
            beforeshow : {
                fn : function (el) {
                    var height = Ext.getBody().getViewSize().height;
                    
                    if (el.getSize().height > height) {
                        el.setHeight(height - 20)
                    }
                }
            },
            show : {
                fn : function () {
                    this.body.mask("Loading...", "x-mask-loading");
                    Ext.Ajax.request({
                        url     : "ExampleLoader.ashx",
                        success : function (response) { 
                            this.body.unmask();
                            eval(response.responseText);
                        },
                        failure : function (response) {
                            this.body.unmask();
                            Ext.Msg.alert("Failure", "The error during example loading:\n" + response.responseText);
                        },
                        params : { 
                            id  : id, 
                            url : url, 
                            wId : this.id
                        },
                        scope : this
                    });
                },
                
                single : true
            }
        },
        buttons : [
            {
                id   : "b" + id,
                text : "Download",
                iconCls   : "icon-compress",
                listeners : {
                    click : {
                        fn : function (el, e) {
                            window.location = "/GenerateSource.ashx?t=1&e=" + url;
                        }
                    }
                }
            }
        ]        
    });
    
    hostName = window.location.protocol + "//" + window.location.host;
    exampleName = url;
    
    tab = ExampleTabs.add(new Ext.Panel({
        id   : id,        
        tbar : [{
            text    : "Source Code",
            iconCls : "icon-pagewhitecode",
            listeners : {
                "click" : function () {
                    Ext.getCmp("w" + id).show(null);
                }
            }
        },
        /*"-",
        {
            ref : "../commentsBtn",
            text : "Comments (*)",
            iconCls : "icon-comments",
            listeners : {
                "render" : function () {
                    Ext.net.DirectMethod.request({
                        url          : "/ExampleLoader.ashx",
                        cleanRequest : true,
                        button       : this,
                        params       : {
                            url : url,
                            action : "comments.count"                            
                        },
                        success      : function (result, response, extraParams, o) {
                            o.button.setText("Comments ("+result+")");
                        }
                    });
                },
                
                "click" : function () {
                    loadComments(this, url);
                }
            }
        },*/
        "->", 
	    {
            text    : "Direct Link",
            iconCls : "icon-link",
            handler : function () {
                new Ext.Window({
                    modal     : true,
                    iconCls   : "icon-link",
                    layout    : "absolute",
                    defaultButton : "dl" + id,
                    width     : 400,
                    height    : 110,
                    title     : "Direct Link",
                    closable  : false,
                    resizable : false,
                    items : [{
                        id    : "dl" + id,
                        xtype : "textfield",
                        cls   : "dlText",
                        width : 364,
                        x     : 10,
                        y     : 10,
                        selectOnFocus : true,
                        readOnly : true,
                        value    : hostName + "/#" + exampleName
                    }],
                    buttons: [{
                        xtype   : "button",
                        text    : " Open",
                        iconCls : "icon-applicationdouble",
                        tooltip : "Open Example in the separate window",
                        handler : function () {
                            window.open(hostName + "/#" + exampleName);
                        }
                    },
                    {
                        xtype   : "button",
                        text    : " Open (Direct)",
                        iconCls : "icon-applicationgo",
                        tooltip : "Open Example in the separate window using a direct link",
                        handler : function () {
                            window.open(hostName + "/Examples" + url, "_blank");
                        }
                    },
                    {
                        xtype   : "button",
                        text    : "Close",
                        handler : function () {
                            this.findParentByType("window").hide(null);
                        }
                    }]
                }).show(null);
            }
        },
        "-", 
        {
            text    : "Refresh",
            handler : function () {
                Ext.getCmp(id).reload(true)
            },
            iconCls : "icon-arrowrefresh"
        }],
        title    : title,
        tabTip   : tabTip,
        hideMode : "offsets",
        autoLoad : {
            showMask : true,
            scripts  : true,
            mode     : "iframe",
            url      : hostName + "/Examples" + url
        },
        listeners : {
            deactivate : {
                fn : function (el) {
                    if (this.sWin && this.sWin.isVisible()) {
                         this.sWin.hide();
                    }
                }
            },
            
            destroy : function () {
                if (this.sWin) {
                    this.sWin.close();
                    this.sWin.destroy();
                }
            }
        },
        closable : true
    }));
    
    tab.sWin = win;
    ExampleTabs.setActiveTab(tab);
    
    var node = exampleTree.getNodeById(id);
            
    if (node) {
        node.ensureVisible(function () {            
            exampleTree.getNodeById(this.id).select();
        }, node);
    } else {
        exampleTree.on("load", function (node) {
            node = exampleTree.getNodeById(id);
      
            if (node) {
                node.ensureVisible(function () {
                    exampleTree.getNodeById(this.id).select();
                }, node);
            }
        }, this, { single : true });
    }
};

var lookup = {};

var loadExample = function (href, id, title) {
    var tab = ExampleTabs.getComponent(id),
        lObj = lookup[href];
        
    if (id == "-") {
        X.GetHashCode(href,{
            success: function (result) {
                loadExample(href, "e" + result, title);
            }
        });
        
        return;
    }
    
    lookup[href] = id;

    if (tab) {
        ExampleTabs.setActiveTab(tab);
    } else {
        if (Ext.isEmpty(title)) {
            var m = /(\w+)\/$/g.exec(href);
            title = m == null ? "[No name]" : m[1];
        }
        
        title = title.replace(/<span>&nbsp;<\/span>/g, "");
        title = title.replace(/_/g, " ");
        makeTab(id, href, title);     
    }
};

var selectionChaged = function (dv, nodes) {
    if (nodes.length > 0) {
        var url = nodes[0].getAttribute("ext:url"),
            id = nodes[0].getAttribute("ext:id");
        
        loadExample(url, id, nodes[0].getAttribute("ext:title"));
    }
};

var viewClick = function (dv, e) {
    var group = e.getTarget("h2", 3, true);

    if (group) {
        group.up("div").toggleClass("collapsed");
    }
};

var beforeSourceShow = function (el) {
    var height = Ext.getBody().getViewSize().height;
    
    if (el.getSize().height > height) {
        el.setHeight(height - 20);
    }
};

var change = function (token) {
    if (token) {
        loadExample(token, lookup[token] || "-" );
    } else {
        ExampleTabs.setActiveTab(0);
    }
};

var addToken = function (el, tab) {
    if (tab.autoLoad && tab.autoLoad.url) {
        var host = window.location.protocol + "//" + window.location.host + "/Examples",
            token = tab.autoLoad.url.substr(host.length);
        
        if (!Ext.isEmpty(token)) {
            History1.add(token);
        }
    } else {                
        History1.add("");                
    }
};        

var keyUp = function (el, e) {
    var tree = exampleTree,
        text = this.getRawValue();
    
    if (e.getKey() === 40) {
        tree.getRootNode().select();
    }
        
    if (Ext.isEmpty(text, false)) {
        clearFilter(el);
    }
    
    if (text.length < 3) {
        return;
    }
    
    tree.clearFilter();
    
    if (Ext.isEmpty(text, false)) {
        return;
    }
    
    el.triggers[0].show();
    
    if (e.getKey() === Ext.EventObject.ESC) {
        clearFilter(el);
    } else {
        var re = new RegExp(".*" + text + ".*", "i");
        
        tree.getRootNode().collapse(true,false);
        
        tree.filterBy(function (node) {
            var match = re.test(node.text.replace(/<span>&nbsp;<\/span>/g, "")),
                pn = node.parentNode;
                
            if (match && node.isLeaf()) {
               pn.hasMatchNode = true;
            }
            
            if (pn != null && pn.fixed) {
                if (node.isLeaf() === false) {
                    node.fixed = true;
                }
                return true;
            }            
                
            if (node.isLeaf() === false) {
                node.fixed = match;
                return match;
            }            
            
            return (pn != null && pn.fixed) || match;
        }, { expandNodes : false });
        
        tree.getRootNode().cascade(function (node) {
            if (node.isRoot) {
               return;
            }            
            
            if ((node.getDepth() === 1) || 
               (node.getDepth() === 2 && node.hasMatchNode)) {
               node.expand(false, false);
            }
            
            delete node.fixed;
            delete node.hasMatchNode;
        }, tree);
    }
};

var clearFilter = function (el, trigger, index, e) {
    var tree = exampleTree;
    
    el.setValue(""); 
    el.triggers[0].hide();
    tree.clearFilter(); 
    tree.getRootNode().collapseChildNodes(true);    
    el.focus(false, 100);        
};

var filterSpecialKey = function (field, e) {
    if (e.getKey() == e.DOWN) {
        var n = exampleTree.getRootNode().findChildBy(function (node) {
            return node.isLeaf() && !node.hidden;
        }, exampleTree, true);
        
        if (n) {
            n.ensureVisible(function () {
                exampleTree.getSelectionModel().select(n);
            } );            
        }
    }
};

var loadComments = function (at, url) {
    winComments.url = url;
    
    winComments.show(at, function () {
        updateComments(false, url);
        TagsView.store.reload();
    });
};

var updateComments = function (updateCount, url) {
    winComments.body.mask("Loading...", "x-mask-loading");
    Ext.net.DirectMethod.request({
        url: "/ExampleLoader.ashx",
        cleanRequest : true,
        params       : {
            url : url,
            action : "comments.build"                            
        },
        success      : function (result, response, extraParams, o) {
            if (result && result.length > 0) {
                tplComments.overwrite(CommentsBody.body, result);
            }
            
            if (updateCount) {
                ExampleTabs.getActiveTab().commentsBtn.setText("Comments ("+result.length+")");
            }
        },
        complete    : function (success, result, response, extraParams, o) {
            winComments.body.unmask();
        }
    });
};

if (window.location.href.indexOf("#") > 0) {
    var directLink = window.location.href.substr(window.location.href.indexOf("#") + 1);
    
    Ext.onReady(function () {
        if (!Ext.isEmpty(directLink, false)) {
            loadExample(directLink, "-");
        }
    }, window, { delay : 100 });
}