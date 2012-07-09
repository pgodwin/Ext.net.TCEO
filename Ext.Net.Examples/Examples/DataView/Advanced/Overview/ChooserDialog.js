var ChooserDialog = function (windowDialog, view, detailPanel, detailsTemplate, callback, el, folder) {
    this.windowDialog = windowDialog;
    this.detailPanel = detailPanel;
    this.detailsTemplate = detailsTemplate;
    this.view = view;
    this.callback = callback;
    this.animateTarget = el;
    this.folder = folder;
};

ChooserDialog.prototype = {
    // cache data by image name for easy lookup
    lookup: {},

    formatData: function (data) {
        data.shortName = Ext.util.Format.ellipsis(data.name, 15);
        data.dateString = new Date(data.lastmod).format("m/d/Y g:i a");
        this.lookup[data.name] = data;
        return data;
    },

    showDetails: function () {
        var selNode = this.view.getSelectedNodes();
        var detailEl = this.detailPanel.body;
        if (selNode && selNode.length > 0) {
            selNode = selNode[0];
            this.windowDialog.buttons[0].enable();
            var data = this.lookup[selNode.id];
            detailEl.hide();
            this.detailsTemplate.overwrite(detailEl, data);
            detailEl.slideIn('l', { stopFx: true, duration: .2 });
        } else {
            this.windowDialog.buttons[0].disable();
            detailEl.update('');
        }
    },

    show: function () {
        this.reset();
        this.windowDialog.show(this.animateTarget);
    },

    doCallback: function () {
        var selNode = this.view.getSelectedNodes()[0];
        var callback = this.callback;
        var lookup = this.lookup;
        this.windowDialog.hide(this.animateTarget, function () {
            if (selNode && callback) {
                var data = lookup[selNode.id];
                callback(data);
            }
        });
    },

    reset: function () {
        if (this.windowDialog.rendered && this.view.rendered) {
            //Ext.getCmp('filter').reset();
            this.view.getEl().dom.scrollTop = 0;
        }
        this.view.store.reload({params:{folder:this.folder}});
        //this.view.store.clearFilter();
        this.view.select(0);
    }
};