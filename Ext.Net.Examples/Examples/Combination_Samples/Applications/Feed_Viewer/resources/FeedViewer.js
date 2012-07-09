/********
 * @version   : 1.0.0 - Professional Edition (Ext.NET Professional License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2009-11-15
 * @copyright : Copyright (c) 2010, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : See license.txt and http://www.ext.net/license/. 
 ********/
 
Ext.ns("FeedViewer");

FeedViewer.LinkInterceptor = function (p) {
    p.body.on({
        "mousedown" : function (e, t) {
            t.target = "_blank";
        },
        "click" : function (e, t) {
            if (String(t.target).toLowerCase() != "_blank") {
                e.stopEvent();
                window.open(t.href);
            }
        },
        delegate : "a"
    });
};

//-----FeedTree----------------------------

FeedViewer.FeedTree = {
    selectionChange : function (sm, node) {
        if (node) {
            this.tree.fireEvent("feedselect", node.attributes);
        }
        
        this.tree.getTopToolbar().items.get("Delete").setDisabled(!node);
    },
    
    onContextMenu : function (node, e) {
        if (!this.tree.menu.render){
            this.tree.menu = Ext.ComponentMgr.create(this.tree.menu);
        }
        
        if (this.tree.ctxNode) {
            this.tree.ctxNode.ui.removeClass("x-node-ctx");
        }
        
        if (node.isLeaf()) {
            this.tree.ctxNode = node;
            this.tree.ctxNode.ui.addClass("x-node-ctx");
            this.tree.menu.items.get("Load").setDisabled(node.isSelected());
            this.tree.menu.showAt(e.getXY());
        }
        
        e.preventDefault();
    },

    onContextHide : function () {
        if (this.tree.ctxNode) {
            this.tree.ctxNode.ui.removeClass("x-node-ctx");
        }
    }
};

//-----FeedGrid----------------------------    

FeedViewer.FeedGrid = {
    applyRowClass : function (record, rowIndex, p, ds) {
        if (this.showPreview) {
            var xf = Ext.util.Format;
            p.body = "<p>" + xf.ellipsis(xf.stripTags(record.data.description), 200) + "</p>";
            return "x-grid3-row-expanded";
        }
        
        return "x-grid3-row-collapsed";
    },
    
    onContextClick : function (grid, index, e) {
        e.stopEvent();
        
        if (!this.grid.menu.render){
            this.grid.menu = Ext.ComponentMgr.create(this.grid.menu);
        }
        
        if (this.grid.ctxRow) {
            Ext.fly(this.grid.ctxRow).removeClass("x-node-ctx");
            this.grid.ctxRow = null;
        }
        
        this.grid.ctxRow = this.grid.view.getRow(index);
        this.grid.ctxRecord = this.grid.store.getAt(index);
        Ext.fly(this.grid.ctxRow).addClass("x-node-ctx");
        this.grid.menu.showAt(e.getXY());
    },

    onContextHide : function () {
        if (this.grid.ctxRow) {
            Ext.fly(this.grid.ctxRow).removeClass("x-node-ctx");
            this.grid.ctxRow = null;
        }
    },
    
    loadFeed : function (url) {
        this.grid.store.baseParams = {
            feed: url
        };
   
        this.grid.store.load();
    },

    formatTitle : function (value, p, record) {
        return String.format(
                '<div class="topic"><b>{0}</b><span class="author">{1}</span></div>',
                value, record.data.author, record.id, record.data.forumid
                );
    }
};


//------MainPanel---------------

FeedViewer.MainPanel = {
    clear : function () {
        this.preview.body.update("");
        var items = this.preview.topToolbar.items;
        items.get("btnNewTab").disable();
        items.get("btnNewWin").disable();
    },
    
    afterLayout : function (p) {
        this.panel = p;
        this.grid = Ext.getCmp("TopicGrid");
        this.preview = Ext.getCmp("Preview");
    },
    
    onRowSelect :  function (sm, index, record) {
        this.panel.tpl.overwrite(this.preview.body, record.data);
        var items = this.preview.topToolbar.items;
        items.get("btnNewTab").enable();
        items.get("btnNewWin").enable();
    },
    
    onStoreLoad : function () {
        this.grid.getSelectionModel().selectFirstRow();
    },
    
    loadFeed : function (feed) {
        FeedViewer.FeedGrid.loadFeed(feed.url);
        this.panel.items.get(0).setTitle(feed.text);
    },
    
    cyclePreview : function () {
        var items = Ext.menu.MenuMgr.get("ReadingMenu").items.items,
            b = items[0], 
            r = items[1], 
            h = items[2];
       
        if (b.checked) {
            r.setChecked(true);
        } else if (r.checked) {
            h.setChecked(true);
        } else if (h.checked) {
            b.setChecked(true);
        }
    },
    
    movePreview : function (m, pressed) {
        if (pressed) {            
            Ext.net.DirectMethods.MainPanel.MovePreview(m.text);           
        }
    },

    openTab : function (record) {
        record = (record && record.data) ? record : this.grid.getSelectionModel().getSelected();
        
        var d = record.data,
            id = !d.link ? Ext.id() : d.link.replace(/[^A-Z0-9_]/gi, ""),
            tab;
        
        if (!(tab = this.panel.getItem(id))) {
            Ext.net.DirectMethods.MainPanel.OpenTab(id, d.title, d.link,{
                success : (function (){
                    tab = this.panel.getActiveTab();
                    tab.body.update(this.panel.tpl.apply(d));
                }).createDelegate(this)
            });
        } else {
            this.panel.setActiveTab(tab);
        }
    },

    openAll : function () {
        this.grid.store.data.each(this.openTab, this);
    }
};

//------FeedWindow---------------

FeedViewer.FeedWindow = {
    getWindow : function () {
        this.window = Ext.getCmp("AddFeedWin");
        return this.window;
    }, 
    
    hide : function () {
        this.getWindow().hide();
    },
    
    syncShadow : function () {
        this.getWindow().syncShadow();
    },
    
    beforeShow : function () {
        if (this.getWindow().rendered) {
            this.feedUrl.setValue("");
        }
    },

    markInvalid : function () {
        this.feedUrl.markInvalid("The URL specified is not a valid RSS2 feed.");
        this.getWindow().el.unmask();
    }      
};