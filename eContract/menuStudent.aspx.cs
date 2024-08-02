using eContract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace eContract
{
    public partial class menuStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _path = Myconfig.GetVirtualPath();
            Myconfig.GetMeteriaUi(Page, _path);
            string _userType = Request.Form["txtUserTypeActive"]; // get user type (student/parent)
                                                                  //string _userType = "student";
            HiddenField txtUserTypeActive = ((HiddenField)FindControl("txtUserTypeActive"));
            txtUserTypeActive.Value = _userType;
            HtmlGenericControl navBar = FindControl("navBar") as HtmlGenericControl;
            navBar.InnerHtml = Myconfig.NavBar(_userType);
            //divBody.InnerHtml = ContractUI.UImenuStudent(_studentId);
            HtmlGenericControl divFooter = FindControl("divFooter") as HtmlGenericControl;
            divFooter.InnerHtml = ContractUI.FooterBanner();
            // student profile
            //divUserProfile.InnerHtml = ContractUI.UiStudentProfile();

            // -- END OF REQUEST PROCESS --

            // -- REQUEST PROCESS --
            Login _login = new Login(_userType);
            //_login.StudentCode = "5809009"; //"5415001"; // "5402001" // hardcode

            if (!Request.IsAuthenticated)
            {
                Login.ClearCookie(_userType);
                Response.Redirect("login.aspx");
            }


            if (_userType == "STUDENT")
            {
                UiContractStudent(_userType);
            }
        }

        private void UiContractStudent(string _userType)
        {
            // prepare default parameter
            Login _login = new Login(_userType);
            string _studentId = _login.StudentId;
            string _parentType = _login.UserType;
            //string _acaYear = Myconfig.GetYearContract();
            // -- END OF STUDENT PROCESS --
            HtmlGenericControl divBody = FindControl("divBody") as HtmlGenericControl;
            divBody.InnerHtml = ContractUI.UImenuStudent(_studentId);
            StringBuilder _string = new StringBuilder();

            StudentInfo _stdInfo = new StudentInfo(_login.StudentCode);
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
            divUserProfile.InnerHtml = ContractUI.UiStudentProfile(_login.StudentCode);

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


            //if (_isSuccess == "1")
            //{
            //    divComplete.InnerHtml = ContractUI.UiComplete(_ctInfo, _stdInfo, _parentMInfo, _parentFInfo, _userType);

            //}
            //else
            //{
            //    //  check  วันที่เปิดปิดระบบ
            //    //check วันที่เปิดปิดระบบ
            //    if (_isBetween == "0")
            //    {
            //        Response.Redirect("logout.aspx");
            //    }
            //    else
            //    {
            //        divParentStatus.InnerHtml = ContractUI.UiParentCheckingStatus(_studentId);
            //        // ปุ่มยืนยัน Status
            //        //divParentStatus.InnerHtml += "<span class='waves-effect waves-light btn-large green col s12  accent-12 btnConfirmInfo' >ยืนยันข้อมูล</span>";
            //    }
            //}


        }

    }
}
