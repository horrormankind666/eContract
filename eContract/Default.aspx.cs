using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Web.UI.HtmlControls;
using eContract.Models;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security;
namespace eContract
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder _script = new StringBuilder();
            string _path = Myconfig.GetVirtualPath();
            Myconfig.GetMeteriaUi(Page, _path);
            HtmlGenericControl navBar = FindControl("navBar") as HtmlGenericControl;
            navBar.InnerHtml = Myconfig.NavBar("STUDENT");
        }
    }
}