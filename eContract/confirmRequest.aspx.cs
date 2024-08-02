using eContract;
using iTextSharp.text;
using iTextSharp.text.pdf;
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

    public partial class confirmRequest : System.Web.UI.Page
    {
        public class data
        {
            public string studentId { get; set; }
            public string acaYear { get; set; }
            public string idCardF { get; set; }
            public string idCardM { get; set; }
            public string passwordF { get; set; }
            public string passwordM { get; set; }
            public string typeF { get; set; }
            public string typeM { get; set; }
            public string fatherUsername { get; set; }
            public string motherUsername { get; set; }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string _printPasswordF = "";
            string _printPasswordM = "";
            string _path = Myconfig.GetVirtualPath();
            Myconfig.GetMeteriaUi(Page, _path);
            string _userType = Request.Form["txtUserTypeActive"]; // get user type (student/parent)
                                                                  //string _userType = "student";
            HiddenField txtUserTypeActive = ((HiddenField)FindControl("txtUserTypeActive"));
            txtUserTypeActive.Value = _userType;
            HtmlGenericControl navBar = FindControl("navBar") as HtmlGenericControl;
            navBar.InnerHtml = Myconfig.NavBar(_userType);
            HtmlGenericControl divFooter = FindControl("divFooter") as HtmlGenericControl;
            divFooter.InnerHtml = ContractUI.FooterBanner();

            // -- REQUEST PROCESS --
            Login _login = new Login(_userType);
            StudentInfo _stdInfo = new StudentInfo(_login.StudentCode);
            ContractInfo _contractCheckInfo = new ContractInfo(_login.StudentId);
            //F = Father
            ParentInfo _parentFInfo = new ParentInfo(_login.StudentId, "F");
            if (_contractCheckInfo.IsAliveFather == "1" && _parentFInfo.IdCard != "")
            {
                _printPasswordF = "1";
            }
            else
            {
                _printPasswordF = "0";
            }
            //M = Mother
            ParentInfo _parentMInfo = new ParentInfo(_login.StudentId, "M");
            if (_contractCheckInfo.IsAliveMother == "1" && _parentMInfo.IdCard != "")
            {
                _printPasswordM = "1";
            }
            else
            {
                _printPasswordM = "0";
            }




            if (_userType == "STUDENT")
            {
                if (!Request.IsAuthenticated)
                {
                    Login.ClearCookie(_userType);
                    Response.Redirect("login.aspx");
                }
                UiContractStudent(_userType);
            }
            else if(_userType == "" || _userType == null)
            {
                Response.Redirect("login.aspx");
            }

            if (Page.IsPostBack)
            {
                //Check condition Create Contract Parent anussara.wan 20200811
                ContractInfo _ctInfo = new ContractInfo(_login.StudentId);//ข้อมูลสัญญานักศึกษา
                string _marriage = _ctInfo.IsMarriage;//1=สมรส,2=สมรส(ไม่ได้จดทะเบียน),3=บิดามารดาหย่าร้าง,4=แยกกันอยู่,5=หม้าย,6=โสด
                string _aliveF = _ctInfo.IsAliveFather;//สถานะบิดา 1=มีชีวิต , 2 = เสียชีวิต
                string _aliveM = _ctInfo.IsAliveMother;//สถานะมารดา 1=มีชีวิต , 2 = เสียชีวิต
                string _liveWithF = _ctInfo.IsLiveFather;//อาศัยอยู่=1,ไม่อาศัย=0
                string _liveWithM = _ctInfo.IsLiveMother;//อาศัยอยู่=1,ไม่อาศัย=0
                string _liveWithOther = _ctInfo.IsLiveOther;//อาศัยอยู่=1,ไม่อาศัย=0
                string _warrantBy = _ctInfo.WarrantBy; //ผู้ค้ำประกัน พ่อ=F,แม่=M,บุคคลอื่น=N

                DataSet _ds = ContractDB.Sp_ectGetStatusReqPasswordParent(_marriage, _aliveF, _aliveM, _liveWithF, _liveWithM, _liveWithOther, _warrantBy);
                int _row = _ds.Tables[0].Rows.Count;
                string _passwordForFather = string.Empty //1=ออกรหัสพ่อ,0=ไม่ออกรหัสพ่อ
                     , _passwordForMother = string.Empty;//1=ออกรหัสพ่อ,0=ไม่ออกรหัสพ่อ
                if (_row > 0)
                {
                    _passwordForFather = _ds.Tables[0].Rows[0]["passwordForFather"].ToString();
                    _passwordForMother = _ds.Tables[0].Rows[0]["passwordForMother"].ToString();

                }
                else
                {
                    _passwordForFather = "";
                    _passwordForMother = "";
                }

                //Create Password Parent 
                //String _data = Request.Form["hidDataJson"];
                if (_parentFInfo.Password == "" && _passwordForFather == "1")
                {
                    var _data = new List<data>
                {
                    new data { studentId = _login.StudentId
                        ,acaYear = _stdInfo.AcaYear
                        ,idCardF = _parentFInfo.IdCard
                        ,idCardM = _parentMInfo.IdCard
                        ,passwordF = _printPasswordF
                        ,passwordM = "0"
                        ,typeF = "F"
                        ,typeM = "M"
                        ,fatherUsername = _ctInfo.FatherUsername
                        ,motherUsername = _ctInfo.MotherUsername}
                };

                    var _dataJson = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
                    //create password parent Father
                    CreatePassword(_dataJson, _login.Username);
                }
                if (_parentMInfo.Password == "" && _passwordForMother == "1")
                {
                    var _data = new List<data>
                {
                    new data { studentId = _login.StudentId
                        ,acaYear = _stdInfo.AcaYear
                        ,idCardF = _parentFInfo.IdCard
                        ,idCardM = _parentMInfo.IdCard
                        ,passwordF = "0"
                        ,passwordM = _printPasswordM
                        ,typeF = "F"
                        ,typeM = "M"
                        ,fatherUsername = _ctInfo.FatherUsername
                        ,motherUsername = _ctInfo.MotherUsername}
                };
                    var _dataJson = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
                    //create password parent Mother
                    CreatePassword(_dataJson, _login.Username);

                }
                //เรียก function print Password PDF
                printPassword(_login.StudentId, _stdInfo.AcaYear, _printPasswordF, _printPasswordM);
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

            if (_isSuccess == "1")
            {
                HtmlGenericControl divComplete = FindControl("divComplete") as HtmlGenericControl;
                divComplete.InnerHtml = ContractUI.UiComplete(_ctInfo, _stdInfo, _parentMInfo, _parentFInfo, _userType);
            }
            else
            {
                //check วันที่เปิดปิดระบบ
                if (_isBetween == "0")
                {
                    //Response.Redirect("login.aspx?logout=yes&userType=" + _userType);
                    Response.Redirect("logout.aspx");
                }
                else
                {
                    HtmlGenericControl divParentStatus = FindControl("divParentStatus") as HtmlGenericControl;
                    divParentStatus.InnerHtml = ContractUI.UiParentCheckingStatus(_studentId);
                    // ปุ่มยืนยัน Status
                    //divParentStatus.InnerHtml += "<span class='waves-effect waves-light btn-large green col s12  accent-12 btnConfirmInfo' >ยืนยันข้อมูล</span>";
                }
            }


        }

        //create password
        public void CreatePassword(string _dataJson, string _username)
        {
            //string _userName = "anussara.wan";

            var _dtData = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(_dataJson);
            ContractDB.SetCreatePassword(_dtData, _username);

            //_c.Response.Write("บันทึกข้อมูลเรียบร้อยแล้ว");
        }
        private void printPassword(string _studentCode, string _acaYear, string _printPasswordF, string _printPasswordM)
        {

            DataSet _ds = ContractDB.GetListParentPassword(_studentCode, _printPasswordF, _printPasswordM, _acaYear);
            if (_ds.Tables[0].Rows.Count > 0)
            {
                //var _dtData = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(Request["_itemList"]);
                // DataRow[] _dr=_dtData.Select("print='Th'","studentCode");

                //string _studentCode = string.Empty, _printFather = string.Empty, _printMother = string.Empty;
                //int _row = _dtData.Rows.Count;

                //contractDB.SetCreatePassword(_dtData, _userName);
                string _path = Server.MapPath("~");
                string _fileTmp = _path + "/Template/TemplatePasswordParent/TemplatePassword.pdf";
                string _html = "";



                string _fileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + _acaYear + ".pdf";
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + _fileName);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Open the reader
                PdfReader _reader = new PdfReader(_fileTmp);

                Document _document = new Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F);
                // open the writer
                PdfWriter _writer = PdfWriter.GetInstance(_document, Response.OutputStream);
                _document.Open();


                PdfContentByte _cb = _writer.DirectContent;
                BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                //for (int i = 0; i < _row; i++)
                //{
                //_studentCode = _stdCode;
                //_printFather = _printPasswordF;
                //_printMother = _printPasswordM;

                foreach (DataRow _dr in _ds.Tables[0].Rows)
                {

                    //Create the new page
                    _document.NewPage();
                    PdfImportedPage page = _writer.GetImportedPage(_reader, 1);
                    _cb.AddTemplate(page, 0, 0);
                    _cb.BeginText();
                    _cb.SetFontAndSize(_bf, 16);


                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dr["nameParent"].ToString(), 225, 700, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dr["nameStudent"].ToString(), 225, 675, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dr["facultyName"].ToString(), 225, 650, 0);
                    _cb.SetFontAndSize(_bf, 14);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dr["dateCalendar"].ToString(), 295, 599, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dr["dateCreate"].ToString(), 230, 480, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dr["nameParent"].ToString(), 110, 428, 0);
                    //Change Idcard To FirstName.Sur(3)
                    //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dr["idcard"].ToString(), 230, 312, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dr["username"].ToString(), 230, 312, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dr["password"].ToString(), 230, 292, 0);
                    _cb.EndText();

                    //Add Template

                }




                //}



                //Close all streams
                _document.Close();
                // fs.Close();
                _writer.Close();
                _reader.Close();
            }
            else
            {
                HtmlGenericControl divResponseERROR = FindControl("divResponseERROR") as HtmlGenericControl;
                divResponseERROR.InnerHtml = "<table border='3'><tr><td><h5 class='red-text'>" +
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
                    "</h5></td></tr></table>";
            }

        }
    }
}