using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace eContract {
    public partial class FAQContract : Page {
        protected void Page_Load(
            object sender,
            EventArgs e
        ) {
            string path = Myconfig.GetVirtualPath();
            //StringBuilder script = new StringBuilder();
            Myconfig.GetMeteriaUi(Page, path);
            string userType = string.Empty;

            HtmlGenericControl navBar = FindControl("navBar") as HtmlGenericControl;
            navBar.InnerHtml = Myconfig.NavBar(userType);
            HtmlGenericControl divBanner = FindControl("divBanner") as HtmlGenericControl;
            divBanner.InnerHtml = ContractUI.ParallaxbannerFAQ();
            HtmlGenericControl divFooter = FindControl("divFooter") as HtmlGenericControl;
            divFooter.InnerHtml = ContractUI.FooterBanner();
        }
    }
}