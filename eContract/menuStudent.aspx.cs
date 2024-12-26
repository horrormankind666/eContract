using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace eContract {
    public partial class MenuStudent : Page {
        protected void Page_Load(
            object sender,
            EventArgs e
        ) {
            string path = Myconfig.GetVirtualPath();
            Myconfig.GetMeteriaUi(Page, path);
            string userType = Request.Form["txtUserTypeActive"]; //get user type (student/parent)
            //string userType = "student";

            HiddenField txtUserTypeActive = ((HiddenField)FindControl("txtUserTypeActive"));
            txtUserTypeActive.Value = userType;

            HtmlGenericControl navBar = FindControl("navBar") as HtmlGenericControl;
            navBar.InnerHtml = Myconfig.NavBar(userType);

            //divBody.InnerHtml = ContractUI.UImenuStudent(_studentId);

            HtmlGenericControl divFooter = FindControl("divFooter") as HtmlGenericControl;
            divFooter.InnerHtml = ContractUI.FooterBanner();

            //student profile
            //divUserProfile.InnerHtml = ContractUI.UiStudentProfile();

            //Login login = new Login(userType);
            //login.StudentCode = "5809009"; //"5415001"; // "5402001" // hardcode

            if (!Request.IsAuthenticated) {
                Login.ClearCookie(userType);
                Response.Redirect("login.aspx");
            }

            if (userType == "STUDENT") {
                UIContractStudent(userType);
            }
        }

        private void UIContractStudent(string userType) {
            //StringBuilder html = new StringBuilder();
            Login login = new Login(userType);
            string studentID = login.StudentID;
            //string parentType = login.UserType;
            //string acaYear = Myconfig.GetYearContract();

            HtmlGenericControl divBody = FindControl("divBody") as HtmlGenericControl;
            divBody.InnerHtml = ContractUI.UImenuStudent(studentID);
            
            //StudentInfo stdInfo = new StudentInfo(login.StudentCode);
            //ParentInfo parentInfo = new ParentInfo(studentID, parentType);
            //ParentInfo parentMInfo = new ParentInfo(studentID, "M");
            //ParentInfo parentFInfo = new ParentInfo(studentID, "F");
            //string acaYear = Myconfig.CvEmpty(stdInfo.AcaYear, " - ");
            /*
            DataSet ds = ContractDB.Sp_ectGetDateEventLogin(acaYear);
            int row = ds.Tables[0].Rows.Count;
            string isBetween;

            if (row > 0) {
                isBetween = ds.Tables[0].Rows[0]["isBetween"].ToString();
            }
            else {
                isBetween = "0";
            }
            */
            
            //ContractInfo ctInfo = new ContractInfo(studentID); //check already sign contract

            //student profile
            HtmlGenericControl divUserProfile = FindControl("divUserProfile") as HtmlGenericControl;
            divUserProfile.InnerHtml = ContractUI.UiStudentProfile(login.StudentCode);
            /*
            string isSuccess;

            if (ctInfo.StatusSignStudent == "Y") {
                isSuccess = "1";
            }
            else {
                //ตรวจสอบสถานะผู้ปกครอง
                isSuccess = ContractInfo.IsParentSuccess(ctInfo, parentType);
            }
            */
            /*
            if (isSuccess == "1") {
                divComplete.InnerHtml = ContractUI.UiComplete(ctInfo, stdInfo, parentMInfo, parentFInfo, userType);
            }
            else {
                //check วันที่เปิดปิดระบบ
                if (isBetween == "0") {
                    Response.Redirect("logout.aspx");
                }
                else {
                    divParentStatus.InnerHtml = ContractUI.UiParentCheckingStatus(studentID);
                    // ปุ่มยืนยัน Status
                    // divParentStatus.InnerHtml += "<span class='waves-effect waves-light btn-large green col s12  accent-12 btnConfirmInfo' >ยืนยันข้อมูล</span>";
                }
            }
            */
        }
    }
}
