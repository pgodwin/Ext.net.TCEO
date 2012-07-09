using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;

namespace Ext.Net.MVC
{
    public class PartialViewPage : ViewPage, Ext.Net.ISelfRenderingPage
    {
        public PartialViewPage()
        {
            this.EnableEventValidation = false;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}
