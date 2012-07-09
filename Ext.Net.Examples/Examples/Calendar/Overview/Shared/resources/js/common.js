var CompanyX = {
   getCalendar : function () {
       return CompanyX.CalendarPanel1;
   },
   
   getStore : function () {
       return CompanyX.EventStore1;
   },
   
   getWindow : function () {
       return CompanyX.EventEditWindow1;
   },
   
   viewChange : function (p, vw, dateInfo) {
        var win = this.getWindow();
        
        if (win) {
            win.hide();
        }
        
        if (dateInfo !== null) {
            // will be null when switching to the event edit form, so ignore
            this.DatePicker1.setValue(dateInfo.activeDate);
            this.updateTitle(dateInfo.viewStart, dateInfo.viewEnd);
        }
    },
    
    updateTitle : function (startDt, endDt) {
        var msg = '';
        
        if (startDt.clearTime().getTime() == endDt.clearTime().getTime()) {
            msg = startDt.format('F j, Y');
        } else if (startDt.getFullYear() == endDt.getFullYear()) {
            if (startDt.getMonth() == endDt.getMonth()) {
                msg = startDt.format('F j') + ' - ' + endDt.format('j, Y');
            } else {
                msg = startDt.format('F j') + ' - ' + endDt.format('F j, Y');
            }
        } else {
            msg = startDt.format('F j, Y') + ' - ' + endDt.format('F j, Y');
        }
        
        this.Panel1.setTitle(msg);
    },
    
    setStartDate : function (picker, date) {
        this.getCalendar().setStartDate(date);
    },
    
    rangeSelect : function (cal, dates, callback) {
        this.record.show(cal, dates);
        this.getWindow().on('hide', callback, cal, { single : true} );
    },
    
    dayClick : function (cal, dt, allDay, el) {
        this.record.show.call(this, cal, {
            StartDate : dt, 
            IsAllDay  : allDay
        }, el);
    },
    
    record : {    
        add : function (win, rec) {
	        win.hide();
	        rec.data.IsNew = false;
	        CompanyX.getStore().add(rec);
            CompanyX.ShowMsg('Event ' + rec.data.Title + ' was added');
        },
        
        update : function (win, rec) {
	        win.hide();
	        rec.commit();
            CompanyX.ShowMsg('Event ' + rec.data.Title + ' was updated');
        },
        
        remove : function (win, rec) {
            this.getStore().remove(rec);
            win.hide();
            CompanyX.ShowMsg('Event ' + rec.data.Title + ' was deleted');
        },
        
        edit : function (win, rec) {
            win.hide();
            CompanyX.getCalendar().showEditForm(rec);
        },
        
        resize : function (cal, rec) {
            rec.commit(); 
            CompanyX.ShowMsg('Event '+ rec.data.Title + ' was updated');
        },
        
        move : function (cal, rec) {
            rec.commit(); 
            CompanyX.ShowMsg('Event '+ rec.data.Title + ' was moved to ' + rec.data.StartDate.format('F jS' + (rec.data.IsAllDay ? '' : ' \\a\\t g:i a')));
        },

        show : function (cal, rec, el) {
            CompanyX.getWindow().show(rec, el);
        },
        
        saveAll : function () {
            CompanyX.getStore().submitData();
        }
    }
};