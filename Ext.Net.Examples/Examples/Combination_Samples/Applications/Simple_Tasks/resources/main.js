Ext.ns("SimpleTasks");

//-------------------TasksTopBar
SimpleTasks.TasksTopBar = {
    init : function (panel) {
        this.bar = panel.getTopToolbar();
    }
};

// ------------------TasksTree----------------------------------
SimpleTasks.TasksTree = {
    init : function (tree) {
        this.tree = tree;
        this.tree.getRootNode().select.defer(100, this.tree.getRootNode());
    },
    
    onContextMenu : function (node, e) {
        if (this.ctxNode) {
            this.ctxNode.ui.removeClass("x-node-ctx");
            this.ctxNode = null;
        }
        
        this.ctxNode = node;
        this.ctxNode.ui.addClass("x-node-ctx");		
				
		this.tree[node.attributes.isFolder ? "ctxFolder" : "ctxCategory"].showAt(e.getXY());
		
		e.preventDefault();
    },

    onContextHide : function () {
        if (this.ctxNode) {
            this.ctxNode.ui.removeClass("x-node-ctx");
            this.ctxNode = null;
        }
    },
    
    insertCategory : function (parentNode) {
        parentNode = parentNode || this.ctxNode || this.tree.getSelectionModel().getSelectedNode() || this.tree.getRootNode();
        
        if (!parentNode.attributes.isFolder) {
            parentNode = parentNode.parentNode;
        }
        
        this.tree.appendChild(parentNode, {text: "New Category", isFolder: false, iconCls: "icon-category"});
    },
    
    insertFolder : function (parentNode) {
        parentNode = parentNode || this.ctxNode || this.tree.getSelectionModel().getSelectedNode() || this.tree.getRootNode();
        
        if (!parentNode.attributes.isFolder) {
            parentNode = parentNode.parentNode;
        }
        
        this.tree.appendChild(parentNode, {
            text     : "New Folder", 
            isFolder : true, 
            iconCls  : "icon-folder"
        });
    },
    
    deleteCategory : function (node) {
        node = node || this.ctxNode || this.tree.getSelectionModel().getSelectedNode() || this.tree.getRootNode();
        
        Ext.Msg.confirm("Confirm", 'Are you sure you want to delete "' + node.text + '"?', function (btn) {
			if (btn == "yes") {
				this.tree.removeNode(node);
			}
		}, this);
    },
    
    beforeRemoteAppend : function (tree, node, params) {
        params["isFolder"] = node.attributes.isFolder;
    },
    
    remoteActionRefusal : function (tree, response, e, o) {
        Ext.Msg.show({
           title   :"Action failure",
           msg     : e.message,
           buttons : Ext.Msg.OK,
           icon    : Ext.MessageBox.ERROR
        });
    },
    
    selectionChange : function (sm, node) {
        var bar = this.tree.getBottomToolbar(),
            isCategory = Ext.isEmpty(node) || !node.attributes.isFolder;
        
        bar.items.get(0).setDisabled(isCategory);
        bar.items.get(1).setDisabled(!isCategory);
        bar.items.get(3).setDisabled(isCategory);
        bar.items.get(4).setDisabled(isCategory);
        
        SimpleTasks.TasksGrid.loadTasks(node);
    },
    
    nodeDragOver : function (e) {
        e.cancel = !e.target.attributes.isFolder;
    },
    
    remoteActionSuccess : function (tree, node, action) {
        var node = this.tree.getSelectionModel().getSelectedNode();
                
        if (!Ext.isEmpty(node)) {
            if (action == "raAppend") {
               SimpleTasks.TasksGrid.loadTasks(node);
            } else {
                SimpleTasks.TasksGrid.updateTitle(node);
            }
        }
    },
    
    moveTasks : function (ids, categoryID) {
        SimpleTasks.TasksGrid.setIndicator(true);
        
        Ext.net.DirectMethods.MoveTasks(Ext.encode(ids), categoryID, {
            success : function () {
                SimpleTasks.TasksGrid.applyFilter();
            },
            
            failure : function (error, response) {
                Ext.Msg.alert("Tasks moving failure", response.responseText)
            },
            
            complete : function () {
                SimpleTasks.TasksGrid.setIndicator(false);
            }
        });
    },
    
    beforeNodeDrop : function (e) { 
        if (Ext.isArray(e.data.selections)) {
            e.cancel = true;
            e.dropStatus = true;
            var ids=[];
            
            for (var i = 0; i < e.data.selections.length; i++) {
                ids.push(e.data.selections[i].id);
            }
            
            this.moveTasks(ids, e.target.id);
            
            return false;
        }
    }
};

// ------------------TasksGrid----------------------------------
SimpleTasks.TasksGrid = {
    init : function (grid) {
        this.grid = grid;
    },
    
    ctxMoveTasks : function (node, e) {
        var ids=[],
            records = this.grid.selModel.getSelections();
            
        for (var i = 0; i < records.length; i++) {
            ids.push(records[i].id);
        }
        
        SimpleTasks.TasksTree.moveTasks(ids, node.id);
        this.grid.ctxMenu.hide();
    },
    
    onRowContext : function (grid, row, e) {
		if (!this.grid.selModel.isSelected(row)) {
			this.grid.selModel.selectRow(row);
		}
		
		e.stopEvent();
		var rootNode = Ext.getCmp("ctxTreeCategory").getRootNode();
		rootNode.removeChildren();
	    rootNode.appendChild(SimpleTasks.TasksTree.tree.getRootNode().clone(false));
		this.grid.ctxMenu.showAt(e.getXY());
    },
    
    afterRender : function () {
        this.headerHandlers.scope = this;
        ntTitle.on(this.headerHandlers);
        ntCategory.on(this.headerHandlers);
        ntDue.on(this.headerHandlers);
    },
    
    loadTasks : function (node) {
        if (Ext.isEmpty(node)) {
            return;
        }
        
        this.updateTitle(node);
        
        if (Ext.isNumber(parseInt(node.id))) {
            this.setIndicator(true);
            
            this.grid.store.reload({ 
                params : {
                    categoryID : node.id, 
                    filter: this.getFilterValue()
                }, 
                callback : function () {
                    this.setIndicator(false);
                }, 
                scope: this
            });
        }
    },
    
    updateTitle : function (node) {
        this.grid.setTitle(node.text);
        this.grid.setIconClass(node.attributes.iconCls);
    },
    
    getRowClass : function (r) {
        var d = r.data;
        
        if (d.Completed) {
            return "task-completed";
        }
        
        if (d.DueDate && d.DueDate.getTime() < new Date().clearTime().getTime()) {
            return "task-overdue";
        }
        return "";
    },
    
    focusTaskField : function () {
        if (SimpleTasks.TasksTree.ctxNode) {
           SimpleTasks.TasksTree.ctxNode.select(); 
        }
        
        this.grid.getView().headerRows[0].columns[1].component.focus();
    },
    
    onFocusNewTask : function () {
        this.hFocused = true;
        
        if (!this.hEditing) {
            ntCategory.enable();
            ntDue.enable();
            this.hEditing = true;		
        }
    },
    
    doBlur : function () {
        if (this.hEditing && !this.hFocused) {
			var title = ntTitle.getValue();
			
            if (!Ext.isEmpty(title)) {				
                if (this.hUserTriggered) {
                   this.onAddTask();
                } else {
                    ntTitle.setValue("");
                    ntCategory.setValue("");
                    delete ntCategory.categoryID;
                }
            } else {
                ntCategory.setValue("");
                delete ntCategory.categoryID;
            }
            
            ntCategory.disable();
            ntDue.disable();
            this.hEditing = false;
        }
    },
    
    onAddTask : function () {
        if (!Ext.isEmpty(ntTitle.getValue(), false) && !Ext.isEmpty(ntCategory.getValue(), false) && !Ext.isEmpty(ntDue.getValue(), false)) {
            this.setIndicator(true);
            
            Ext.net.DirectMethods.AddTask(ntTitle.getValue(), ntCategory.getValue(), Ext.encode(ntDue.getValue()), {
                complete: (function () {
                    this.setIndicator(false);
                }).createDelegate(this)
            });   
            ntTitle.setValue(""); 
        } else {
            if (Ext.isEmpty(ntTitle.getValue(), false)) {
                 Ext.net.Notification.show({                                  
                                        html  : "Please specify the task subject",
                                        title : "Warning"
                                     });
            } else if (Ext.isEmpty(ntCategory.getValue(), false)) {
                 Ext.net.Notification.show({                                  
                                        html  : "Please specify the task category",
                                        title : "Warning"
                                     });
            } else if (Ext.isEmpty(ntDue.getValue(), false)) {
                 Ext.net.Notification.show({                                  
                                        html  : "Please specify the due date",
                                        title : "Warning"
                                     });
            }
        }        
	                	    
        this.hUserTriggered = false;
        ntTitle.focus.defer(100, ntTitle);
    },
    
    categoryCheckChange : function (node, e) {
        var ddf = node.getOwnerTree().dropDownField;
        ddf.setValue(node.id, node.text);
    },
    
    headerHandlers : {
        focus : function () {
            (function (v) {
                this.hFocused = v;
            }).defer(20, this, [true]);
        },
        blur : function () {
            this.hFocused = false;
            this.doBlur.defer(250, this);
        },
        specialkey : function (f, e) {
            if (e.getKey()==e.ENTER) {
                this.hUserTriggered = true;
                e.stopEvent();
                f.el.blur();
                if (f.triggerBlur) {
                    f.triggerBlur();
                }
            }
        }
    },
    
    setIndicator : function (loading) {
        var indicator = Ext.fly("icnIndicator");

        if (indicator) {
            indicator[loading ? "addClass" : "removeClass"]("loading-indicator");
        }
    },
    
    prepareStatusButton : function (grid, toolbar, rowIndex, record) {
        toolbar.items.itemAt(0).setIconClass(record.get("Completed") ? "icon-complete" : "icon-active");
    },
    
    selectionChange : function (sm) {
        var bar = SimpleTasks.TasksTopBar.bar;
        bar.items.get(2).setDisabled(!sm.hasSelection());
        bar.items.get(3).setDisabled(!sm.hasSelection());
        bar.items.get(4).setDisabled(!sm.hasSelection());
    },
    
    getSelectedIds : function () {
        var selectedIds = [];
        Ext.each(SimpleTasks.TasksGrid.grid.getSelectionModel().getSelections(), function (taskRecord) {
            selectedIds.push(taskRecord.id);
        });
        
        return Ext.encode(selectedIds);
    },
    
    getFilterValue : function () {
        var filter = "";
        
        if (filterAll.pressed) {
            filter = "all";
        }  else if (filterActive.pressed) {
            filter = "active";
        } else if (filterCompleted.pressed) {
            filter = "completed";
        }
        
        return filter;
    },
    
    getActiveNodeCategory : function () {
        return SimpleTasks.TasksTree.tree.getSelectionModel().getSelectedNode();
    },
    
    applyFilter : function () {        
        this.loadTasks(this.getActiveNodeCategory());
    },
    
    categoryExpand : function () {
        var tree = SimpleTasks.TasksTree.tree,
		    rootNode = ntTreeCategory.getRootNode(),
		    node = this.getActiveNodeCategory();
		    
		rootNode.removeChildren();
		rootNode.appendChild(node.clone(false));
    }
};

SimpleTasks.TaskWindow = {
    openTask : function (taskId) {
        var w = Ext.getCmp("TaskWindow_" + taskId);
        
        if (w) {
            w.toFront();
            return false;
        }
        
        SimpleTasks.TasksGrid.setIndicator(true);
        
        return true;
    },
    
    initWindow : function (w) {
        var tree = SimpleTasks.TasksTree.tree;		    
		
		w.taskCategory.component.getRootNode().appendChild(tree.getRootNode().clone(false));
		w.taskCategory.component.getNodeById(parseInt(w.taskCategory.getValue())).select();
    },
    
    save : function (w) {
        if (!w.taskForm.isValid()) {
            return;
        }
        
        var values = Ext.encode(w.taskForm.getForm().getFieldValues());
        
        Ext.Msg.wait("The task is saving...");
        
        Ext.net.DirectMethods.SaveTask(w.taskId, values, {
            success : function () {
                Ext.Msg.hide();
                w.close();
                SimpleTasks.TasksGrid.applyFilter();
            },
            failure : function (error, response) {
                Ext.Msg.alert("Task saving failure", response.responseText)
            }
        });
    },
    
    deleteTask : function (w) {
        Ext.Msg.wait({
            msg: "The task is deleting..."
        });
        
        Ext.net.DirectMethods.DeleteTasks(Ext.encode([w.taskId]), {
            success : function () {
                Ext.Msg.hide();
                w.close();
            },
            failure : function (error, response) {
                Ext.Msg.alert("Task deleting failure", response.responseText)
            }
        });
    },
    
    markTask : function (w, complete) {
        Ext.Msg.wait({
            msg: "Please wait, working..."
        });
        
        Ext.net.DirectMethods.MarkTask(
            w.taskId, 
            complete, 
            SimpleTasks.TasksGrid.getActiveNodeCategory().id,
            SimpleTasks.TasksGrid.getFilterValue(), {
                success : function () {
                    Ext.Msg.hide();
                    if (complete) {
                        w.close();
                    }
                },
                failure : function (error, response) {
                    Ext.Msg.alert("Task marking failure", response.responseText)
                }
            }
        );
    },
        
    getName : function () {
        return this.dataIndex;
    }
};