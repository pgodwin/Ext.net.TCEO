using System.Collections.Generic;
using System.Web;

// !!! DO NOT REMOVE CODEBEHIND AND DO NOT MOVE CODE TO THE ASPX (REQUIRED FOR THE WEB SERVICE)

namespace Ext.Net.Calendar.Demo
{
    public partial class EventsViewer : System.Web.UI.UserControl
    {
        public void Render(List<Event> events)
        {
            this.EventStore1.Events.AddRange(events);
            this.Window1.Render();
        }
    }
}