using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace eContract
{
    public partial class helpContract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _path = Myconfig.GetVirtualPath();
            Myconfig.GetMeteriaUi(Page, _path);
            string _userType = string.Empty;
            HtmlGenericControl navBar = FindControl("navBar") as HtmlGenericControl;
            navBar.InnerHtml = Myconfig.NavBar(_userType);
            HtmlGenericControl divBanner = FindControl("divBanner") as HtmlGenericControl;
            divBanner.InnerHtml = ContractUI.ParallaxbannerHelp();
            HtmlGenericControl divFooter = FindControl("divFooter") as HtmlGenericControl;
            divFooter.InnerHtml = ContractUI.FooterBanner();
        }
    }
}