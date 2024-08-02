using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eContract
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Login.ClearCookie("STUDENT");
            Login.ClearCookie("PARENT");
            Login.ClearCookie(".AspNet.Cookies");
            Response.Redirect("https://idp.mahidol.ac.th/adfs/oauth2/logout?post_logout_redirect_uri=https://econtract.mahidol.ac.th");
        }
    }
}