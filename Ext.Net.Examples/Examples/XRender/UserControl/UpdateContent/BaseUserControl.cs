using System.Collections.Generic;
using System.Web.UI;

namespace Ext.Net.Examples
{
    public class BaseUserControl : UserControl
    {
        public virtual List<string> ControlsToDestroy
        {
            get
            {
                // we should return none lazy controls only because lazy controls will be autodestroyed by parent container
                return new List<string>();
            }
        }
    }
}
