using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using eContract.Models;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security;

namespace eContract
{
    public partial class frmContract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            string _path = Myconfig.GetVirtualPath();
            Myconfig.GetMeteriaUi(Page, _path);
            //string _userType = "STUDENT";
            string _userType = Request.Form["txtUserTypeActive"]; // get user type (student/parent)
            HiddenField txtUserTypeActive = ((HiddenField)FindControl("txtUserTypeActive"));
            txtUserTypeActive.Value = _userType;
            HtmlGenericControl navBar = FindControl("navBar") as HtmlGenericControl;
            navBar.InnerHtml = Myconfig.NavBar(_userType);
            HtmlGenericControl divFooter = FindControl("divFooter") as HtmlGenericControl;
            divFooter.InnerHtml = ContractUI.FooterBanner();

            //For Test Student
            //_userType = "STUDENT";
            //string name = "u6103092";
            //UserProfile profile = new UserProfile(new System.Security.Claims.ClaimsIdentity(User.Identity));
            //string name = profile.Claims["unique_name"];
            //HttpCookie _cookie = new HttpCookie(_userType);
            ////เติมข้อมูลลงในคุ้กกี้
            //_cookie["result"] = name;
            //HttpContext.Current.Response.Cookies.Add(_cookie);
            //UiContractStudent(_userType);

            if (Request.IsAuthenticated && _userType != "PARENT")
            {
                _userType = "STUDENT";
                txtUserTypeActive.Value = _userType;
                UserProfile profile = new UserProfile(new System.Security.Claims.ClaimsIdentity(User.Identity));
                string name = profile.Claims["unique_name"];
                //string name = "u6103009";
                HttpCookie _cookie = new HttpCookie(_userType);
                //เติมข้อมูลลงในคุ้กกี้
                _cookie["result"] = name;
                HttpContext.Current.Response.Cookies.Add(_cookie);

                UiContractStudent(_userType);
            }
            else if (_userType == "PARENT")
            {
                UiContractParent(_userType);
            }
            else
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "https://econtract.mahidol.ac.th/frmContract.aspx" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }




        private void UiContractStudent(string _userType)
        {
            // prepare default parameter
            Login _login = new Login(_userType);
            string _studentCode = _login.StudentCode;
            string _studentId = _login.StudentId;
            string _parentType = _login.UserType;
            //string _acaYear = Myconfig.GetYearContract();
            // -- END OF STUDENT PROCESS --
            StringBuilder _string = new StringBuilder();

            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            ParentInfo _parentInfo = new ParentInfo(_studentId, _parentType);
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
            string _acaYear = Myconfig.CvEmpty(_stdInfo.AcaYear, " - ");

            DataSet _ds = ContractDB.Sp_ectGetDateEventLogin(_acaYear);
            int _row = _ds.Tables[0].Rows.Count;
            string _isBetween = "";
            if (_row > 0)
            {
                _isBetween = _ds.Tables[0].Rows[0]["isBetween"].ToString();

            }
            else
            {
                _isBetween = "0";
            }
            ContractInfo _ctInfo = new ContractInfo(_studentId);// check already sign contract

            // student profile
            HtmlGenericControl divUserProfile = FindControl("divUserProfile") as HtmlGenericControl;
            divUserProfile.InnerHtml = ContractUI.UiStudentProfile(_studentCode);
            HtmlGenericControl divMenuStd = FindControl("divMenuStd") as HtmlGenericControl;
            divMenuStd.InnerHtml = ContractUI.UImenuStudent(_studentId);
            string _isSuccess = "0";
            if (_ctInfo.StatusSignStudent == "Y")
            {
                _isSuccess = "1";
            }
            else
            {
                //ตรวจสอบสถานะผู้ปกครอง
                _isSuccess = ContractInfo.IsParentSuccess(_ctInfo, _parentType);
            }


            if (_isSuccess == "1")
            {
                HiddenField hidStatusViewComplete = ((HiddenField)FindControl("hidStatusViewComplete"));
                hidStatusViewComplete.Value = "1";
                HtmlGenericControl divComplete = FindControl("divComplete") as HtmlGenericControl;
                divComplete.InnerHtml = ContractUI.UiComplete(_ctInfo, _stdInfo, _parentMInfo, _parentFInfo, _userType);

            }
            else
            {
                //check วันที่เปิดปิดระบบ
                if (_isBetween == "0")
                {
                    Response.Redirect("logout.aspx");
                }
                else
                {
                    //hidStatusViewParent.Value = "1";
                    HtmlGenericControl divParentStatus = FindControl("divParentStatus") as HtmlGenericControl;
                    divParentStatus.InnerHtml = ContractUI.UiParentCheckingStatus(_studentId);
                    // ปุ่มยืนยัน Status
                    //divParentStatus.InnerHtml += "<span class='waves-effect waves-light btn-large green col s12  accent-12 btnConfirmInfo' >ยืนยันข้อมูล</span>";
                }
            }
        }

        private void UiContractParent(string _userType)
        {
            Login _login = new Login(_userType);
            string _studentId = _login.StudentId;
            string _parentType = _login.UserType;
            //string _acaYear = Myconfig.GetYearContract();
            string _username = _login.Username;
            // -- END OF STUDENT PROCESS --

            StringBuilder _string = new StringBuilder();

            // parent profile
            HtmlGenericControl divUserProfile = FindControl("divUserProfile") as HtmlGenericControl;
            divUserProfile.InnerHtml = ContractUI.UiParentProfile(_studentId, _parentType, _login.StudentCode);


            StudentInfo _stdInfo = new StudentInfo(_login.StudentCode);
            ParentInfo _parentInfo = new ParentInfo(_studentId, _parentType);
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");

            ContractInfo _ctInfo = new ContractInfo(_studentId);// check already sign contract
            string _acaYear = Myconfig.CvEmpty(_stdInfo.AcaYear, " - ");
            //ตรวจสอบการกรองข้อมูล บิดามารดา
            string _checkDataParent = _parentInfo.CheckDataParent;
            //ตรวจสอบข้อมูลการ confirm การรับรหัสจาก นศ. 2019-08-19
            string _checkConfirmParent = _parentInfo.CheckConfirmParent;

            //วันที่เปิด-ปิด ระบบ Between = "1" ระบบเปิด
            DataSet _ds = ContractDB.Sp_ectGetDateEventLogin(_acaYear);
            int _row = _ds.Tables[0].Rows.Count;
            string _isBetween = "";
            if (_row > 0)
            {
                _isBetween = _ds.Tables[0].Rows[0]["isBetween"].ToString();
            }
            else
            {
                _isBetween = "0";
            }

            string _statusSignStudent = _ctInfo.StatusSignStudent;
            string _warrantBy = _ctInfo.WarrantBy;
            string _consentBy = _ctInfo.ConsentBy;



            switch (_statusSignStudent)
            {
                case "Y":

                    if (_parentType == _warrantBy || _parentType == _consentBy)
                    // if (_parentType != _warrantBy)
                    {


                        //9
                        string _isSuccess = ContractInfo.IsParentSuccess(_ctInfo, _parentType);


                        //สัญญาสมบูรณ์แล้ว
                        if (_isSuccess == "1")
                        {
                            HtmlGenericControl divContractView = FindControl("divContractView") as HtmlGenericControl;
                            divContractView.InnerHtml = ContractUI.UiComplete(_ctInfo, _stdInfo, _parentMInfo, _parentFInfo, _userType);

                        }
                        else
                        {

                            //check วันที่เปิดปิดระบบ
                            if (_isBetween == "0")
                            {
                                Response.Redirect("logout.aspx");
                                //Response.Redirect("login.aspx?logout=yes&userType=" + _userType);
                            }
                            else
                            {

                                if (_checkConfirmParent == "N")
                                {
                                    //ผู้ปกครองยืนยันการรับรหัสผ่าน
                                    HtmlGenericControl divLogin = FindControl("divLogin") as HtmlGenericControl;
                                    divLogin.InnerHtml = ContractUI.UiConfirmParent(_userType, _ctInfo, _username, _parentType, _studentId, _login.StudentCode);

                                }
                                else
                                {
                                    if (_checkDataParent == "N")
                                    {
                                        //กรณีที่ข้อมูล e-Profile ผู้ปกครองไม่ครบถ้วน
                                        HtmlGenericControl divLogin = FindControl("divLogin") as HtmlGenericControl;
                                        divLogin.InnerHtml = GetMessageProfileParentvalidated();
                                    }
                                    else
                                    {
                                        //ฟอร์มค้ำประกัน ยินยอม
                                        HtmlGenericControl divLogin = FindControl("divLogin") as HtmlGenericControl;
                                        divLogin.InnerHtml = ContractUI.UiReLoginForm(_userType, _ctInfo, _username, _parentType);
                                    }
                                    //ถ้าสัญญาของนักศึกษา ผู้ค้ำประกัน ตรงกับ ผู้ใช้งาน
                                    HtmlGenericControl divContractView = FindControl("divContractView") as HtmlGenericControl;
                                    divContractView.InnerHtml = ContractPreview.Preview_Guarantee(_studentId, _parentType, _stdInfo.StudentCode);
                                    //ค้ำประกัน และคู่สมรสยินยอม
                                    HtmlGenericControl divWarantView = FindControl("divWarantView") as HtmlGenericControl;
                                    divWarantView.InnerHtml = ContractPreview.Preview_Warrant(_studentId, _parentType, _stdInfo.StudentCode);
                                }

                            }
                        }

                    }
                    else
                    {

                        //Login.ClearCookie(_userType); // ล้างข้อมูลใน cookie
                        string _txtWarrant, _txtConsent;
                        if (_warrantBy == "M")
                            _txtWarrant = "มารดา";
                        else if (_warrantBy == "F")
                            _txtWarrant = "บิดา";
                        else
                            _txtWarrant = "บุคคลอื่น";

                        if (_consentBy == "M")
                            _txtConsent = "มารดา";
                        else if (_consentBy == "F")
                            _txtConsent = "บิดา";
                        else
                            _txtConsent = "บุคคลอื่น";

                        if (_isBetween == "0")
                        {
                            Response.Redirect("logout.aspx");
                        }
                        else
                        {
                            _string.Append("  <div class='section'><div class='row'>" +
                                           "         <div class='col s12 m12'>" +
                                           "             <h3 class='red-text' center-align'><span class='th'>ท่านไม่สามารถทำสัญญาค้ำประกัน/ยินยอมได้ เนื่องจากไม่อยู่ในเงื่อนไขที่สามารถทำสัญญาได้<br><br>ผู้ค้ำประกันโดย : " + _txtWarrant + "<br>ยินยอมโดย : " + _txtConsent + "</span><span class='en hide'>Wait for student Create a new contract.</span>" +
                                           "             </h3>" +
                                           "         </div></div>" +
                                           "     </div>");
                            HtmlGenericControl divContractView = FindControl("divContractView") as HtmlGenericControl;
                            divContractView.InnerHtml = _string.ToString();
                        }
                    }
                    break;

                case "N":
                    //Login.ClearCookie(_userType); // ล้างข้อมูลใน cookie

                    if (_isBetween == "0")
                    {
                        Response.Redirect("logout.aspx");
                    }
                    else
                    {
                        _string.Append(@"  <div class='section'><div class='row'>
                                            <div class='col s12 m12'>
                                                <h3 class='red-text' center-align'><span class='th'>ยังไม่สามารถทำสัญญาได้<br>เนื่องจากต้องให้นักศึกษาทำสัญญาก่อน</span><span class='en hide'>Wait for student Create a new contract.</span>
                                                </h3>
                                            </div></div>
                                        </div>");
                        HtmlGenericControl divContractView = FindControl("divContractView") as HtmlGenericControl;
                        divContractView.InnerHtml = _string.ToString();
                    }

                    break;
            }




        }

        public string GetMessageProfileParentvalidated()
        {
            StringBuilder _string = new StringBuilder();
            _string.Append("<div class='card-panel blue lighten-5'>");
            _string.Append("<div class='row'>");
            _string.Append("<h5 class='red-text'><span class='th'><center>เนื่องจากมีข้อมูลที่สำคัญบางอย่างไม่ครบถ้วน จึงไม่สามารถดำเนินการต่อได้</center><p><center>ให้ดำเนินการแจ้งนักศึกษาให้เข้าไปกรอกข้อมูลดังกล่าวให้ครบถ้วนได้ที่ระบบ e-Profile</center><p><p><center><a href='https://smartedu.mahidol.ac.th'>เข้าสู่ระบบ e-Profile</a></center></p></span><span class='en hide'>Re-Login for sign contract</span></h5>");
            _string.Append("</div>");
            _string.Append("</div>");
            return _string.ToString();
        }
    }
}