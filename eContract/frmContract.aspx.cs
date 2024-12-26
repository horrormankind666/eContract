using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security;
using eContract.Models;

namespace eContract {
    public partial class FrmContract : Page {
        protected void Page_Load (
            object sender,
            EventArgs e
        ) {
            //StringBuilder sb = new StringBuilder();
            string path = Myconfig.GetVirtualPath();
            Myconfig.GetMeteriaUi(Page, path);
            //string userType = "STUDENT";
            string userType = Request.Form["txtUserTypeActive"]; //get user type (student/parent)
            HiddenField txtUserTypeActive = ((HiddenField)FindControl("txtUserTypeActive"));
            txtUserTypeActive.Value = userType;

            HtmlGenericControl navBar = FindControl("navBar") as HtmlGenericControl;
            navBar.InnerHtml = Myconfig.NavBar(userType);

            HtmlGenericControl divFooter = FindControl("divFooter") as HtmlGenericControl;
            divFooter.InnerHtml = ContractUI.FooterBanner();

            /*
            //for test student
            userType = "STUDENT";
            string name = "u6103092";
            UserProfile profile = new UserProfile(new System.Security.Claims.ClaimsIdentity(User.Identity));
            string name = profile.Claims["unique_name"];
            HttpCookie cookie = new HttpCookie(_userType);

            //เติมข้อมูลลงในคุ้กกี้
            cookie["result"] = name;
            HttpContext.Current.Response.Cookies.Add(cookie);
            UiContractStudent(userType);
            */

            if (Request.IsAuthenticated &&
                userType != "PARENT") {
                userType = "STUDENT";
                txtUserTypeActive.Value = userType;
                UserProfile profile = new UserProfile(new System.Security.Claims.ClaimsIdentity(User.Identity));
                string name = profile.Claims["unique_name"];
                //string name = "u6103009";
                HttpCookie cookie = new HttpCookie(userType);
                //เติมข้อมูลลงในคุ้กกี้
                cookie["result"] = name;
                HttpContext.Current.Response.Cookies.Add(cookie);

                UiContractStudent(userType);
            }
            else {
                if (userType == "PARENT") {
                    UiContractParent(userType);
                }
                else {
                    HttpContext.Current.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "https://econtract.mahidol.ac.th/frmContract.aspx" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
                }
            }
        }

        private void UiContractStudent(string userType) {
            //prepare default parameter
            Login login = new Login(userType);
            string studentCode = login.StudentCode;
            string studentID = login.StudentID;
            string parentType = login.UserType;
            //string acaYear = Myconfig.GetYearContract();

            //StringBuilder html = new StringBuilder();
            StudentInfo stdInfo = new StudentInfo(studentCode);
            //ParentInfo parentInfo = new ParentInfo(studentID, parentType);
            ParentInfo parentMInfo = new ParentInfo(studentID, "M");
            ParentInfo parentFInfo = new ParentInfo(studentID, "F");
            string acaYear = Myconfig.CvEmpty(stdInfo.AcaYear, " - ");

            DataSet ds = ContractDB.Sp_ectGetDateEventLogin(acaYear);
            int row = ds.Tables[0].Rows.Count;
            string isBetween;

            if (row > 0) {
                isBetween = ds.Tables[0].Rows[0]["isBetween"].ToString();
            }
            else {
                isBetween = "0";
            }

            ContractInfo ctInfo = new ContractInfo(studentID); //check already sign contract

            //student profile
            HtmlGenericControl divUserProfile = FindControl("divUserProfile") as HtmlGenericControl;
            divUserProfile.InnerHtml = ContractUI.UiStudentProfile(studentCode);

            HtmlGenericControl divMenuStd = FindControl("divMenuStd") as HtmlGenericControl;
            divMenuStd.InnerHtml = ContractUI.UImenuStudent(studentID);

            string isSuccess;

            if (ctInfo.StatusSignStudent == "Y") {
                isSuccess = "1";
            }
            else {
                //ตรวจสอบสถานะผู้ปกครอง
                isSuccess = ContractInfo.IsParentSuccess(ctInfo, parentType);
            }

            if (isSuccess == "1") {
                HiddenField hidStatusViewComplete = ((HiddenField)FindControl("hidStatusViewComplete"));
                hidStatusViewComplete.Value = "1";

                HtmlGenericControl divComplete = FindControl("divComplete") as HtmlGenericControl;
                divComplete.InnerHtml = ContractUI.UiComplete(ctInfo, stdInfo, parentMInfo, parentFInfo, userType);
            }
            else {
                //check วันที่เปิดปิดระบบ
                if (isBetween == "0") {
                    Response.Redirect("logout.aspx");
                }
                else {
                    //hidStatusViewParent.Value = "1";
                    HtmlGenericControl divParentStatus = FindControl("divParentStatus") as HtmlGenericControl;
                    divParentStatus.InnerHtml = ContractUI.UiParentCheckingStatus(studentID);
                    //ปุ่มยืนยัน Status
                    //divParentStatus.InnerHtml += "<span class='waves-effect waves-light btn-large green col s12  accent-12 btnConfirmInfo' >ยืนยันข้อมูล</span>";
                }
            }
        }

        private void UiContractParent(string userType) {
            StringBuilder html = new StringBuilder();
            Login login = new Login(userType);
            string studentID = login.StudentID;
            string parentType = login.UserType;
            //string acaYear = Myconfig.GetYearContract();
            string username = login.Username;          

            //parent profile
            HtmlGenericControl divUserProfile = FindControl("divUserProfile") as HtmlGenericControl;
            divUserProfile.InnerHtml = ContractUI.UiParentProfile(studentID, parentType, login.StudentCode);

            StudentInfo stdInfo = new StudentInfo(login.StudentCode);
            ParentInfo parentInfo = new ParentInfo(studentID, parentType);
            ParentInfo parentMInfo = new ParentInfo(studentID, "M");
            ParentInfo parentFInfo = new ParentInfo(studentID, "F");

            ContractInfo ctInfo = new ContractInfo(studentID); //check already sign contract
            string acaYear = Myconfig.CvEmpty(stdInfo.AcaYear, " - ");
            //ตรวจสอบการกรองข้อมูล บิดามารดา
            string checkDataParent = parentInfo.CheckDataParent;
            //ตรวจสอบข้อมูลการ confirm การรับรหัสจาก นศ. 2019-08-19
            string checkConfirmParent = parentInfo.CheckConfirmParent;

            //วันที่เปิด-ปิด ระบบ Between = "1" ระบบเปิด
            DataSet ds = ContractDB.Sp_ectGetDateEventLogin(acaYear);
            int row = ds.Tables[0].Rows.Count;
            string isBetween;

            if (row > 0) {
                isBetween = ds.Tables[0].Rows[0]["isBetween"].ToString();
            }
            else {
                isBetween = "0";
            }

            string statusSignStudent = ctInfo.StatusSignStudent;
            string warrantBy = ctInfo.WarrantBy;
            string consentBy = ctInfo.ConsentBy;

            switch (statusSignStudent) {
                case "Y":
                    //if (parentType != _warrantBy)
                    if (parentType == warrantBy ||
                        parentType == consentBy) {                    
                        //9
                        string isSuccess = ContractInfo.IsParentSuccess(ctInfo, parentType);

                        //สัญญาสมบูรณ์แล้ว
                        if (isSuccess == "1") {
                            HtmlGenericControl divContractView = FindControl("divContractView") as HtmlGenericControl;
                            divContractView.InnerHtml = ContractUI.UiComplete(ctInfo, stdInfo, parentMInfo, parentFInfo, userType);
                        }
                        else {
                            //check วันที่เปิดปิดระบบ
                            if (isBetween == "0") {
                                Response.Redirect("logout.aspx");
                                //Response.Redirect("login.aspx?logout=yes&userType=" + _userType);
                            }
                            else {
                                if (checkConfirmParent == "N") {
                                    //ผู้ปกครองยืนยันการรับรหัสผ่าน
                                    HtmlGenericControl divLogin = FindControl("divLogin") as HtmlGenericControl;
                                    divLogin.InnerHtml = ContractUI.UiConfirmParent(userType, ctInfo, username, parentType, studentID, login.StudentCode);
                                }
                                else {
                                    if (checkDataParent == "N") {
                                        //กรณีที่ข้อมูล e-Profile ผู้ปกครองไม่ครบถ้วน
                                        HtmlGenericControl divLogin = FindControl("divLogin") as HtmlGenericControl;
                                        divLogin.InnerHtml = GetMessageProfileParentvalidated();
                                    }
                                    else {
                                        //ฟอร์มค้ำประกัน ยินยอม
                                        HtmlGenericControl divLogin = FindControl("divLogin") as HtmlGenericControl;
                                        divLogin.InnerHtml = ContractUI.UiReLoginForm(userType, ctInfo, username, parentType);
                                    }

                                    //ถ้าสัญญาของนักศึกษา ผู้ค้ำประกัน ตรงกับ ผู้ใช้งาน
                                    HtmlGenericControl divContractView = FindControl("divContractView") as HtmlGenericControl;
                                    divContractView.InnerHtml = ContractPreview.Preview_Guarantee(studentID, parentType, stdInfo.StudentCode);

                                    //ค้ำประกัน และคู่สมรสยินยอม
                                    HtmlGenericControl divWarantView = FindControl("divWarantView") as HtmlGenericControl;
                                    divWarantView.InnerHtml = ContractPreview.Preview_Warrant(studentID, parentType, stdInfo.StudentCode);
                                }
                            }
                        }
                    }
                    else {
                        //Login.ClearCookie(_userType); //ล้างข้อมูลใน cookie
                        string txtWarrant;
                        string txtConsent;

                        if (warrantBy == "M")
                            txtWarrant = "มารดา";
                        else
                            if (warrantBy == "F")
                                txtWarrant = "บิดา";
                            else
                                txtWarrant = "บุคคลอื่น";

                        if (consentBy == "M")
                            txtConsent = "มารดา";
                        else
                            if (consentBy == "F")
                                txtConsent = "บิดา";
                            else
                                txtConsent = "บุคคลอื่น";

                        if (isBetween == "0") {
                            Response.Redirect("logout.aspx");
                        }
                        else {
                            html.Append(@"
                                <div class='section'>
                                    <div class='row'>
                                        <div class='col s12 m12'>
                                            <h3 class='red-text' center-align'>
                                                <span class='th'>ท่านไม่สามารถทำสัญญาค้ำประกัน/ยินยอมได้ เนื่องจากไม่อยู่ในเงื่อนไขที่สามารถทำสัญญาได้<br /><br />ผู้ค้ำประกันโดย : " + txtWarrant + "<br />ยินยอมโดย : " + txtConsent + @"</span>
                                                <span class='en hide'>Wait for student Create a new contract.</span>
                                            </h3>
                                        </div>
                                    </div>
                                </div>
                            ");

                            HtmlGenericControl divContractView = FindControl("divContractView") as HtmlGenericControl;
                            divContractView.InnerHtml = html.ToString();
                        }
                    }

                    break;
                case "N":
                    //Login.ClearCookie(_userType); //ล้างข้อมูลใน cookie
                    if (isBetween == "0") {
                        Response.Redirect("logout.aspx");
                    }
                    else {
                        html.Append(@"
                            <div class='section'>
                                <div class='row'>
                                    <div class='col s12 m12'>
                                        <h3 class='red-text' center-align'>
                                            <span class='th'>ยังไม่สามารถทำสัญญาได้<br>เนื่องจากต้องให้นักศึกษาทำสัญญาก่อน</span>
                                            <span class='en hide'>Wait for student Create a new contract.</span>
                                        </h3>
                                    </div>
                                </div>
                            </div>
                        ");

                        HtmlGenericControl divContractView = FindControl("divContractView") as HtmlGenericControl;
                        divContractView.InnerHtml = html.ToString();
                    }

                    break;
            }
        }

        public string GetMessageProfileParentvalidated() {
            StringBuilder html = new StringBuilder();

            html.Append(@"
                <div class='card-panel blue lighten-5'>
                    <div class='row'>
                        <h5 class='red-text'>
                            <span class='th'>
                                <center>เนื่องจากมีข้อมูลที่สำคัญบางอย่างไม่ครบถ้วน จึงไม่สามารถดำเนินการต่อได้</center>
                                <p>
                                    <center>ให้ดำเนินการแจ้งนักศึกษาให้เข้าไปกรอกข้อมูลดังกล่าวให้ครบถ้วนได้ที่ระบบ e-Profile</center>
                                    <center><a href='https://smartedu.mahidol.ac.th'>เข้าสู่ระบบ e-Profile</a></center>
                                </p>
                            </span>
                            <span class='en hide'>Re-Login for sign contract</span>
                        </h5>
                    </div>
                </div>
            ");

            return html.ToString();
        }
    }
}