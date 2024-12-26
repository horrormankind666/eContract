using System;
using System.Web.UI;

namespace eContract {
    public partial class Logout : Page {
        protected void Page_Load(
            object sender,
            EventArgs e
        ) {
            Login.ClearCookie("STUDENT");
            Login.ClearCookie("PARENT");
            Login.ClearCookie(".AspNet.Cookies");

            Response.Redirect("https://idp.mahidol.ac.th/adfs/oauth2/logout?post_logout_redirect_uri=https://econtract.mahidol.ac.th");
        }
    }
}