using System;
using System.Web.Mvc;

namespace Ext.Net.MVC
{
    public class RestResult : ActionResult
    {
        private bool success;
        private string msg;
        private object data;

        public bool Success
        {
            get { return success; }
            set { success = value; }
        }
        public string Message
        {
            get { return msg; }
            set { msg = value; }
        }

        public object Data
        {
            get { return data; }
            set { data = value; }
        }
        
        public override void ExecuteResult(ControllerContext context)
        {
            Response response = new Response(true);
            response.Success = this.Success;
            response.Message = this.Message;
            response.Data = JSON.Serialize(this.Data);

            response.Return();
        }
    }
}
