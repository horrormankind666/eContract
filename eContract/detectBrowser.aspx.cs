using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eContract
{
    public partial class detectBrowser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _path = Myconfig.GetVirtualPath();
            Myconfig.GetMeteriaUi(Page, _path);
        }
    }
}