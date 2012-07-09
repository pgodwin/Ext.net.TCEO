Ext.ns("Northwind");

Northwind = {
    hashCode: function(str) {
        var hash = 1315423911;

        for (var i = 0; i < str.length; i++) {
            hash ^= ((hash << 5) + str.charCodeAt(i) + (hash >> 2));
        }

        return (hash & 0x7FFFFFFF);
    },

    addTab: function(config) {
        if (Ext.isEmpty(config.url, false)) {
            return;
        }

        var tp = Ext.getCmp('tpMain');
        var id = this.hashCode(config.url);
        var tab = tp.getComponent(id);

        if (!tab) {
            tab = tp.addTab({
                id: id.toString(),
                title: config.title,
                iconCls: config.icon || 'icon-applicationdouble',
                closable: true,
                autoLoad: {
                    showMask: true,
                    url: config.url,
                    mode: 'iframe',
                    noCache: true,
                    maskMsg: "Loading '" + config.title + "'...",
                    scripts: true,
                    passParentSize: config.passParentSize
                }
            });
        } else {
            tp.setActiveTab(tab);
            Ext.get(tab.tabEl).frame();
        }
    }
};