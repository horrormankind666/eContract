using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace eContract {
    public partial class LoginP : Page {
        protected void Page_Load(
            object sender,
            EventArgs e
        ) {
            //string authen = string.Empty;
            //string username = Request.Form["username"];
            //string password = Request.Form["studentpassword"];
            string userID = Request.Form["userid"];
            string parentpassword = Request.Form["parentpassword"];
            string userType = Request.Form["usertype"];
            string acaYear = string.Empty;

            string path = Myconfig.GetVirtualPath();
            //StringBuilder script = new StringBuilder();
            Myconfig.GetMeteriaUi(Page, path);
           
            HtmlGenericControl navBar = FindControl("navBar") as HtmlGenericControl;
            navBar.InnerHtml = Myconfig.NavBar(userType);

            HtmlGenericControl divBanner = FindControl("divBanner") as HtmlGenericControl;
            divBanner.InnerHtml = ContractUI.Parallaxbanner(acaYear);

            HtmlGenericControl divBody = FindControl("divBody") as HtmlGenericControl;
            divBody.InnerHtml = ContractUI.UiLoginForm();

            HtmlGenericControl divFooter = FindControl("divFooter") as HtmlGenericControl;
            divFooter.InnerHtml = ContractUI.FooterBanner();

            HiddenField txtUserTypeActive = ((HiddenField)FindControl("txtUserTypeActive"));
            txtUserTypeActive.Value = userType;

            if (IsPostBack) {
                if (userType != null) {
                    //txtUserTypeActive.Value = userType;
                    if (userType == "STUDENT") {
                        GotoPage();
                    }
                    else {
                        //for parent
                        if (!string.IsNullOrEmpty(userID) &&
                            !string.IsNullOrEmpty(parentpassword)){
                            LoginParent(userID, parentpassword, userType);
                        }
                    }
                }
            }
        }

        /*
        private void LoginStudent(
            string username,
            string password,
            string userType
        ) {
            if (string.IsNullOrEmpty(username)) {
                throw new ArgumentException($"'{nameof(username)}' cannot be null or empty.", nameof(username));
            }

            if (string.IsNullOrEmpty(password)) {
                throw new ArgumentException($"'{nameof(password)}' cannot be null or empty.", nameof(password));
            }

            StringBuilder html = new StringBuilder();
            string authen;

            try {
                //sending webservice
                //Login.AuthenAD(username, password, userType); //ส่งรหัสให้ AD ตรวจสอบ --> return as cookie --> in class user
                Login login = new Login(userType);
                authen = login.Authen;

                //authen = "true";
                //authen = "false"; //test code
                switch (authen) {
                    case "true":
                        GotoPage();
                        break;
                    case "false":
                        //Login.ClearCookie(userType);
                        html.Append(@"
                            <script type='text/javascript'>
                                $('.message').text('" + login.Message + @"');
                                $('#modal1').openModal();
                            </script>
                        ");

                        ScriptManager.RegisterStartupScript(this, GetType(), "ajax", html.ToString(), false);
                        break;
                }
            }
            catch (Exception ex) {
                html.Append(@"
                    <script type='text/javascript'>
                        $('.message').html('<p>Code Error : " + ex.Message.Replace("'", " ") + @"</p><p>กรุณาแจ้งปัญหามาที่ e-mail:anussara.wan@mahidol.ac.th พร้อมแนบไฟล์ Print Screen Code Error.</p>');
                        $('#modal1').openModal();
                    </script>
                ");

                ScriptManager.RegisterStartupScript(this, GetType(), "ajax", html.ToString(), false);
            }
        }
        */

        private void LoginParent(
            string userID,
            string password,
            string userType
        ) {
            StringBuilder html = new StringBuilder();
            //string result = string.Empty;

            try {
                Login.AuthenParent(userID, password, userType);
                Login login = new Login(userType);
                string authen = login.Authen;

                //authen = "true";
                //authen = "false"; //test code
                switch (authen) {
                    case "true":
                        GotoPage();
                        break;
                    case "false":
                        //Login.ClearCookie(_userType);
                        html.Append(@"
                            <script type='text/javascript'>
                                $('.message').text('" + login.Message + @"');
                                $('#modal1').openModal();
                            </script>
                        ");

                        ScriptManager.RegisterStartupScript(this, GetType(), "ajax", html.ToString(), false);
                        break;
                }

            }
            catch (Exception ex) {
                html.Append(@"
                    <script type='text/javascript'>
                        $('.message').html('<p>Code Error : " + ex.Message.Replace("'", " ") + @"</p><p>กรุณาแจ้งปัญหามาที่ e-mail:anussara.wan@mahidol.ac.th พร้อมแนบไฟล์ Print Screen Code Error.</p>');
                        $('#modal1').openModal();
                    </script>
                ");

                ScriptManager.RegisterStartupScript(this, GetType(), "ajax", html.ToString(), false);
            }
        }

        private void GotoPage() {
            StringBuilder html = new StringBuilder();
            
            html.Append(@"
                <script type='text/javascript'>
                    $('#loginform').prop('action','frmContract.aspx');
                    $('#loginform').submit();
                </script>
            ");

            ScriptManager.RegisterStartupScript(this, GetType(), "ajax", html.ToString(), false);
        }
    }
}