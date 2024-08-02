using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Web.UI.HtmlControls;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security;
using eContract.Models;
using System.Web.UI.WebControls;
using System.Security.Policy;

namespace eContract
{


    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ----- prepare default parameter -----------
            string _authen = string.Empty, _username = string.Empty, _password = string.Empty;
            string _userid = string.Empty, _parentpassword = string.Empty;
            string _userType = string.Empty;
            string _acaYear = string.Empty;

            string _path = Myconfig.GetVirtualPath();
            StringBuilder _script = new StringBuilder();
            Myconfig.GetMeteriaUi(Page, _path);

            // ---- post request zone --------------------
            // get student username and authen password
            _username = Request.Form["username"];
            _password = Request.Form["studentpassword"];

            // get parent citizen-id and parent password
            _userid = Request.Form["userid"];
            _parentpassword = Request.Form["parentpassword"];

            // get user type (student/parent)
            _userType = Request.Form["usertype"];

            // ---- display zone -------------------------
            HtmlGenericControl navBar = FindControl("navBar") as HtmlGenericControl;
            navBar.InnerHtml = Myconfig.NavBar(_userType);
            HtmlGenericControl divBanner = FindControl("divBanner") as HtmlGenericControl;
            divBanner.InnerHtml = ContractUI.Parallaxbanner(_acaYear);
            HtmlGenericControl divBody = FindControl("divBody") as HtmlGenericControl;
            divBody.InnerHtml = ContractUI.UiLoginForm();
            HtmlGenericControl divFooter = FindControl("divFooter") as HtmlGenericControl;
            divFooter.InnerHtml = ContractUI.FooterBanner();
            HiddenField txtUserTypeActive = ((HiddenField)FindControl("txtUserTypeActive"));
            txtUserTypeActive.Value = _userType;

            if (IsPostBack)
            {
                if (_userType != null)
                {
                    //txtUserTypeActive.Value = _userType;
                    if (_userType == "STUDENT")
                    {
                        GotoPage();
                    }
                    else
                    {
                        // for parent
                        if (!string.IsNullOrEmpty(_userid) && !string.IsNullOrEmpty(_parentpassword))
                        {
                            LoginParent(_userid, _parentpassword, _userType);
                        }
                    }
                }
            }
        }


        private void LoginStudent(string _username, string _password, string _userType)
        {
            StringBuilder _script = new StringBuilder();
            string _authen;
            try
            {
                // sending webservice
                //Login.AuthenAD(_username, _password, _userType); // ส่งรหัสให้ AD ตรวจสอบ --> return as cookie --> in class user
                Login _login = new Login(_userType);
                _authen = _login.Authen;


                //_authen = "true";
                //_authen = "false"; // test code
                switch (_authen)
                {
                    case "true":
                        GotoPage();
                        break;

                    case "false":
                        //Login.ClearCookie(_userType);
                        _script.Append(@"<script type='text/javascript'> ");
                        _script.Append(@" $('.message').text('" + _login.Message + "');$('#modal1').openModal();");
                        _script.Append(@" </script>");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", _script.ToString(), false);
                        break;
                }
            }
            catch (Exception _ex)
            {
                _script.Append(@"<script type='text/javascript'> ");
                _script.Append(@" $('.message').html('<p>Code Error : " + _ex.Message.Replace("'", " ") + "</p><p>กรุณาแจ้งปัญหามาที่ e-mail:anussara.wan@mahidol.ac.th พร้อมแนบไฟล์ Print Screen Code Error.</p>');$('#modal1').openModal();");
                _script.Append(@" </script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", _script.ToString(), false);
            }
        }


        private void LoginParent(string _userid, string _password, string _userType)
        {
            StringBuilder _script = new StringBuilder();


            string _result = string.Empty;


            try
            {
                Login.AuthenParent(_userid, _password, _userType);

                Login _login = new Login(_userType);

                string _authen = _login.Authen;


                //_authen = "true";
                //_authen = "false"; // test code
                switch (_authen)
                {
                    case "true":
                        GotoPage();
                        break;

                    case "false":
                        //Login.ClearCookie(_userType);
                        _script.Append(@"<script type='text/javascript'> ");
                        _script.Append(@" $('.message').text('" + _login.Message + "');$('#modal1').openModal();");
                        _script.Append(@" </script>");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", _script.ToString(), false);
                        break;
                }

            }
            catch (Exception _ex)
            {
                _script.Append(@"<script type='text/javascript'> ");
                _script.Append(@" $('.message').html('<p>Code Error : " + _ex.Message.Replace("'", " ") + "</p><p>กรุณาแจ้งปัญหามาที่ e-mail:anussara.wan@mahidol.ac.th พร้อมแนบไฟล์ Print Screen Code Error.</p>');$('#modal1').openModal();");
                _script.Append(@" </script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", _script.ToString(), false);
            }


        }

        private void GotoPage()
        {
            StringBuilder _script = new StringBuilder();
            _script.Append(@"<script type='text/javascript'> ");
            _script.Append(@"$('#loginform').prop('action','frmContract.aspx');$('#loginform').submit();");
            _script.Append(@" </script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", _script.ToString(), false);
        }
    }
}