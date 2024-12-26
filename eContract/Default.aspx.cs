using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace eContract {
    public partial class Default : Page {
        protected void Page_Load(
            object sender,
            EventArgs e
        ) {
            string path = Myconfig.GetVirtualPath();
            Myconfig.GetMeteriaUi(Page, path);
            HtmlGenericControl navBar = FindControl("navBar") as HtmlGenericControl;
            navBar.InnerHtml = Myconfig.NavBar("STUDENT");
        }
    }
}