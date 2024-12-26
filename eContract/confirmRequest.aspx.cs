using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace eContract {
    public partial class ConfirmRequest : Page {
        public class Data {
            public string StudentID { get; set; }
            public string AcaYear { get; set; }
            public string IDCardF { get; set; }
            public string IDCardM { get; set; }
            public string PasswordF { get; set; }
            public string PasswordM { get; set; }
            public string TypeF { get; set; }
            public string TypeM { get; set; }
            public string FatherUsername { get; set; }
            public string MotherUsername { get; set; }
        }

        protected void Page_Load(
            object sender,
            EventArgs e
        ) {
            string printPasswordF;
            string printPasswordM;
            string path = Myconfig.GetVirtualPath();
            Myconfig.GetMeteriaUi(Page, path);
            string userType = Request.Form["txtUserTypeActive"]; 
            //get user type (student/parent)
            //string userType = "student";

            HiddenField txtUserTypeActive = ((HiddenField)FindControl("txtUserTypeActive"));
            txtUserTypeActive.Value = userType;
            HtmlGenericControl navBar = FindControl("navBar") as HtmlGenericControl;
            navBar.InnerHtml = Myconfig.NavBar(userType);
            HtmlGenericControl divFooter = FindControl("divFooter") as HtmlGenericControl;
            divFooter.InnerHtml = ContractUI.FooterBanner();

            Login login = new Login(userType);
            StudentInfo stdInfo = new StudentInfo(login.StudentCode);
            ContractInfo contractCheckInfo = new ContractInfo(login.StudentID);
            //F = father
            ParentInfo parentFInfo = new ParentInfo(login.StudentID, "F");

            if (contractCheckInfo.IsAliveFather == "1" &&
                parentFInfo.IDCard != "") {
                printPasswordF = "1";
            }
            else {
                printPasswordF = "0";
            }

            //M = mother
            ParentInfo parentMInfo = new ParentInfo(login.StudentID, "M");

            if (contractCheckInfo.IsAliveMother == "1" &&
                parentMInfo.IDCard != "") {
                printPasswordM = "1";
            }
            else {
                printPasswordM = "0";
            }

            if (userType == "STUDENT") {
                if (!Request.IsAuthenticated) {
                    Login.ClearCookie(userType);
                    Response.Redirect("login.aspx");
                }

                UiContractStudent(userType);
            }
            else {
                if (userType == "" ||
                    userType == null) {
                    Response.Redirect("login.aspx");
                }
            }

            if (Page.IsPostBack) {
                //check condition create contract parent anussara.wan 20200811
                ContractInfo ctInfo = new ContractInfo(login.StudentID); //ข้อมูลสัญญานักศึกษา
                string marriage = ctInfo.IsMarriage; //1 = สมรส, 2 = สมรส(ไม่ได้จดทะเบียน), 3 = บิดามารดาหย่าร้าง, 4 = แยกกันอยู่, 5 = หม้าย, 6 = โสด
                string aliveF = ctInfo.IsAliveFather; //สถานะบิดา 1 = มีชีวิต, 2 = เสียชีวิต
                string aliveM = ctInfo.IsAliveMother; //สถานะมารดา 1 = มีชีวิต, 2 = เสียชีวิต
                string liveWithF = ctInfo.IsLiveFather; //อาศัยอยู่ = 1, ไม่อาศัย = 0
                string liveWithM = ctInfo.IsLiveMother; //อาศัยอยู่ = 1, ไม่อาศัย = 0
                string liveWithOther = ctInfo.IsLiveOther; //อาศัยอยู่ = 1, ไม่อาศัย = 0
                string warrantBy = ctInfo.WarrantBy; //ผู้ค้ำประกัน พ่อ = F, แม่ = M, บุคคลอื่น = N

                DataSet ds = ContractDB.Sp_ectGetStatusReqPasswordParent(marriage, aliveF, aliveM, liveWithF, liveWithM, liveWithOther, warrantBy);
                int row = ds.Tables[0].Rows.Count;
                string passwordForFather; //1 = ออกรหัสพ่อ, 0 = ไม่ออกรหัสพ่อ
                string passwordForMother; //1 = ออกรหัสพ่อ, 0 = ไม่ออกรหัสพ่อ

                if (row > 0) {
                    passwordForFather = ds.Tables[0].Rows[0]["passwordForFather"].ToString();
                    passwordForMother = ds.Tables[0].Rows[0]["passwordForMother"].ToString();
                }
                else {
                    passwordForFather = "";
                    passwordForMother = "";
                }

                //create password parent 
                //string data = Request.Form["hidDataJson"];
                if (parentFInfo.Password == "" &&
                    passwordForFather == "1") {
                    var data = new List<Data> {
                        new Data {
                            StudentID = login.StudentID,
                            AcaYear = stdInfo.AcaYear,
                            IDCardF = parentFInfo.IDCard,
                            IDCardM = parentMInfo.IDCard,
                            PasswordF = printPasswordF,
                            PasswordM = "0",
                            TypeF = "F",
                            TypeM = "M",
                            FatherUsername = ctInfo.FatherUsername,
                            MotherUsername = ctInfo.MotherUsername
                        }
                    };

                    var dataJson = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    //create password parent father
                    CreatePassword(dataJson, login.Username);
                }

                if (parentMInfo.Password == "" &&
                    passwordForMother == "1") {
                    var data = new List<Data> {
                        new Data {
                            StudentID = login.StudentID,
                            AcaYear = stdInfo.AcaYear,
                            IDCardF = parentFInfo.IDCard,
                            IDCardM = parentMInfo.IDCard,
                            PasswordF = "0",
                            PasswordM = printPasswordM,
                            TypeF = "F",
                            TypeM = "M",
                            FatherUsername = ctInfo.FatherUsername,
                            MotherUsername = ctInfo.MotherUsername
                        }
                    };

                    var dataJson = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    //create password parent mother
                    CreatePassword(dataJson, login.Username);
                }

                //เรียก function print password PDF
                PrintPassword(login.StudentID, stdInfo.AcaYear, printPasswordF, printPasswordM);
            }
        }

        private void UiContractStudent(string userType) {
            //prepare default parameter
            Login login = new Login(userType);
            string studentID = login.StudentID;
            string parentType = login.UserType;
            //string acaYear = Myconfig.GetYearContract();

            //StringBuilder html = new StringBuilder();
            StudentInfo stdInfo = new StudentInfo(login.StudentCode);
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
            divUserProfile.InnerHtml = ContractUI.UiStudentProfile(login.StudentCode);

            string isSuccess;

            if (ctInfo.StatusSignStudent == "Y") {
                isSuccess = "1";
            }
            else {
                //ตรวจสอบสถานะผู้ปกครอง
                isSuccess = ContractInfo.IsParentSuccess(ctInfo, parentType);
            }

            if (isSuccess == "1") {
                HtmlGenericControl divComplete = FindControl("divComplete") as HtmlGenericControl;
                divComplete.InnerHtml = ContractUI.UiComplete(ctInfo, stdInfo, parentMInfo, parentFInfo, userType);
            }
            else {
                //check วันที่เปิดปิดระบบ
                if (isBetween == "0") {
                    //Response.Redirect("login.aspx?logout=yes&userType=" + _userType);
                    Response.Redirect("logout.aspx");
                }
                else {
                    HtmlGenericControl divParentStatus = FindControl("divParentStatus") as HtmlGenericControl;
                    divParentStatus.InnerHtml = ContractUI.UiParentCheckingStatus(studentID);
                    //ปุ่มยืนยัน Status
                    //divParentStatus.InnerHtml += "<span class='waves-effect waves-light btn-large green col s12  accent-12 btnConfirmInfo' >ยืนยันข้อมูล</span>";
                }
            }
        }

        //create password
        public void CreatePassword(
            string dataJson,
            string username
        ) {
            //string userName = "anussara.wan";

            var dtData = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(dataJson);
            ContractDB.SetCreatePassword(dtData, username);

            //c.Response.Write("บันทึกข้อมูลเรียบร้อยแล้ว");
        }

        private void PrintPassword(
            string studentCode,
            string acaYear,
            string printPasswordF,
            string printPasswordM
        ) {
            DataSet ds = ContractDB.GetListParentPassword(studentCode, printPasswordF, printPasswordM, acaYear);

            if (ds.Tables[0].Rows.Count > 0) {
                //var dtData = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(Request["_itemList"]);
                //DataRow[] dr = dtData.Select("print='Th'", "studentCode");

                //string studentCode = string.Empty;
                //string printFather = string.Empty;
                //string printMother = string.Empty;
                //int row = dtData.Rows.Count;

                //contractDB.SetCreatePassword(dtData, userName);

                string path = Server.MapPath("~");
                string fileTmp = (path + "/Template/TemplatePasswordParent/TemplatePassword.pdf");
                string fileName = (DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + acaYear + ".pdf");

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", ("attachment;filename=" + fileName));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //open the reader
                PdfReader reader = new PdfReader(fileTmp);
                Document document = new Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F);
                //open the writer
                PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
                
                document.Open();

                PdfContentByte cb = writer.DirectContent;
                BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                /*
                for (int i = 0; i < row; i++) {
                    studentCode = stdCode;
                    printFather = printPasswordF;
                    printMother = printPasswordM;
                */

                foreach (DataRow dr in ds.Tables[0].Rows) {
                    //create the new page
                    document.NewPage();

                    PdfImportedPage page = writer.GetImportedPage(reader, 1);

                    cb.AddTemplate(page, 0, 0);
                    cb.BeginText();
                    cb.SetFontAndSize(bf, 16);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dr["nameParent"].ToString(), 225, 700, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dr["nameStudent"].ToString(), 225, 675, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dr["facultyName"].ToString(), 225, 650, 0);
                    cb.SetFontAndSize(bf, 14);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dr["dateCalendar"].ToString(), 295, 599, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dr["dateCreate"].ToString(), 230, 480, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dr["nameParent"].ToString(), 110, 428, 0);
                    //change ID card to firstname.sur(3)
                    //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dr["idcard"].ToString(), 230, 312, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dr["username"].ToString(), 230, 312, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dr["password"].ToString(), 230, 292, 0);
                    cb.EndText();

                    //add template
                }
                //}
                document.Close();
                //fs.Close();
                writer.Close();
                reader.Close();
            }
            else {
                HtmlGenericControl divResponseERROR = FindControl("divResponseERROR") as HtmlGenericControl;
                divResponseERROR.InnerHtml = (
                    "<table border='3'><tr><td><h5 class='red-text'>" +
                    "<span class='th'><center>ระบบไม่สามารถแสดงข้อมูลรหัสผ่านของบิดาและมารดาของนักศึกษา</br>สำหรับการทำหนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรมและสัญญาค้ำประกันได้</center></span>" +
                    "<span class='en hide'><center>ระบบไม่สามารถแสดงข้อมูลรหัสผ่านของบิดาและมารดาของนักศึกษา</br>สำหรับการทำหนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรมและสัญญาค้ำประกันได้</center></span>" +
                    "</h5></td></tr>" +
                    "<tr><td><h5 class='blue-text'><span class='th'>1. ขอให้นักศึกษา<a href='https://smartedu.mahidol.ac.th'><u>ตรวจสอบการบันทึกข้อมูลในระบบ e-profile</u></a> : ข้อมูลส่วนตัวข้อมูลที่อยู่ และข้อมูลครอบครัว ให้ครบถ้วนทุกรายการ</br>" +
                    "<p style='text - indent: 2.5em;'>2. หากดำเนินการตามข้อ 1. แล้ว แต่ระบบยังไม่สามารถแสดงรหัสผ่านได้ ให้<b>ตรวจสอบเงื่อนไขการทำสัญญา </b> <a href='https://econtract.mahidol.ac.th/faqContract.aspx'><u>เงื่อนไขการทำสัญญา</u></a> แล้วดำเนินการดังนี้</br>" +
                    "  2.1 <b>กรณีการค้ำประกันโดยบิดาหรือมารดาโดยชอบด้วยกฎหมาย</b> ให้แจ้งข้อขัดข้องไปยังกองกฎหมาย สำนักงานอธิการบดี ผ่านทาง LINE Official Account กองกฎหมาย ม.มหิดล: @csq0251v หรือ โทร. 02 849 6260 ในวันทำการ เวลา 08.30 – 16.30 น.</br>" +
                    "  2.2 <b>กรณีที่ต้องติดต่อทำสัญญาภายนอกระบบ</b> ให้ศึกษารายละเอียดเอกสารเพิ่มเติม<a href='https://econtract.mahidol.ac.th/faqContract.aspx'><u>FAQ การทำสัญญาค้ำประกัน ฯ</u></a> และติดต่อสอบถามการทำสัญญาภายนอกระบบไปยังกองกฎหมาย สำนักงานอธิการบดี" +
                    "ผ่านทาง LINE Official Account กองกฎหมาย ม.มหิดล: @csq0251v หรือ โทร. 02 849 6260 ในวันทำการ เวลา 08.30 – 16.30 น.</p></span>" +
                    "<span class='en hide'>1. ขอให้นักศึกษา<a href='https://smartedu.mahidol.ac.th'>ตรวจสอบการบันทึกข้อมูลในระบบ e-profile</a> : ข้อมูลส่วนตัวข้อมูลที่อยู่ และข้อมูลครอบครัว ให้ครบถ้วนทุกรายการ</br>" +
                    "2. หากดำเนินการตามข้อ 1. แล้ว แต่ระบบยังไม่สามารถแสดงรหัสผ่านได้ ให้<b>ตรวจสอบเงื่อนไขการทำสัญญา </b> <a href='https://econtract.mahidol.ac.th/faqContract.aspx'><u>เงื่อนไขการทำสัญญา</u></a> แล้วดำเนินการดังนี้</br>" +
                    "  2.1 <b>กรณีการค้ำประกันโดยบิดาหรือมารดาโดยชอบด้วยกฎหมาย</b> ให้แจ้งข้อขัดข้องไปยังกองกฎหมาย สำนักงานอธิการบดี ผ่านทาง LINE Official Account กองกฎหมาย ม.มหิดล: @csq0251v หรือ โทร. 02 849 6260 ในวันทำการ เวลา 08.30 – 16.30 น.</br>" +
                    "  2.2 <b>กรณีที่ต้องติดต่อทำสัญญาภายนอกระบบ</b> ให้ศึกษารายละเอียดเอกสารเพิ่มเติม<a href='https://econtract.mahidol.ac.th/faqContract.aspx'><u>FAQ การทำสัญญาค้ำประกัน ฯ</u></a>และติดต่อสอบถามการทำสัญญาภายนอกระบบไปยังกองกฎหมาย สำนักงานอธิการบดี " +
                    "ผ่านทาง LINE Official Account กองกฎหมาย ม.มหิดล: @csq0251v หรือ โทร. 02 849 6260 ในวันทำการ เวลา 08.30 – 16.30 น.</span>" +
                    "</h5></td></tr></table>"
                );
            }
        }
    }
}