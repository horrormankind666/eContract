<%@ WebHandler Language="C#" Class="eContract.ContractHandler" %>

using System;
using System.Web;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
//using authen;

namespace eContract
{
    public class ContractHandler : IHttpHandler
    {

        HttpContext _c;
        public void ProcessRequest(HttpContext context)
        {
            _c = context;
            string _action = _c.Request.Form["action"];

            switch (_action)
            {
                case "SignLogin":
                    SignLogin();
                    break;
                case "UiPreviewContrat":
                    UiPreviewContrat();
                    break;
                case "UIsetAcceptedRequestPassword":
                    UIsetAcceptedRequestPassword();
                    break;
                case "UIsetConfirmRequestPassword":
                    UIsetConfirmRequestPassword();
                    break;
                case "SetConfirmParent":
                    SetConfirmParent();
                    break;
                //case "CheckConsent":
                //    CheckConsent();
                //    break;
                case "CheckENFullNameParent":
                    CheckENFullNameParent();
                    break;



            }
        }

        public string GenerateUsername(string enFirstName, string enLastName)
        {
            string username = "";
            bool _checkStatus = false;
            Regex rgx = new Regex("[^a-zA-Z]");
            enFirstName = rgx.Replace(enFirstName, "").ToLower();
            enLastName = rgx.Replace(enLastName, "").ToLower();
            int lengthLastName = enLastName.Length;
            if (enLastName != "" || enLastName != string.Empty || lengthLastName != 0)
            {
                if (lengthLastName < 3)
                {
                    username = enFirstName + "." + enLastName;
                    _checkStatus = CheckAvailableUsername(username);
                    if(_checkStatus == false)
                    {
                        for(int i = 1; i <= 10; i++)
                        {
                            username = username + i.ToString();
                            _checkStatus = CheckAvailableUsername(username);
                            if(_checkStatus == true)
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    // FirstName.LastName(Left, 3)
                    for (int charAt = 2; charAt <= lengthLastName; charAt++)
                    {
                        username = enFirstName + "." + enLastName.Substring(0, 2) + enLastName.Substring(charAt, 1);
                        _checkStatus = CheckAvailableUsername(username);
                        if (_checkStatus == true)
                        {
                            break;
                        }
                    }


                    //If checkStatus == false after Loop first
                    if (_checkStatus == false)
                    {
                        //FirstName.LastName(Right, 3)
                        for (int charAt = 3; charAt <= lengthLastName; charAt++)
                        {
                            username = enFirstName + "." + enLastName.Substring(lengthLastName - 1, 1) + enLastName.Substring(lengthLastName - 2, 1) + enLastName.Substring(lengthLastName - charAt, 1);
                            _checkStatus = CheckAvailableUsername(username);
                            if (_checkStatus == true)
                            {
                                break;
                            }
                        }
                    }
                }

            }
            else
            {//enLastName = null
                for (int increment = 0; increment <= 100; increment++)
                {
                    if (increment == 0)
                    {
                        username = enFirstName;
                    }
                    else
                    {
                        username = enFirstName + "_" + increment;
                    }

                    _checkStatus = CheckAvailableUsername(username);
                    if (_checkStatus == true)
                    {
                        break;
                    }
                }
            }

            return username;
        }

        public bool CheckAvailableUsername(string username)
        {
            bool _status = false;
            DataSet _result = new DataSet();
            _result = ContractDB.CheckAvailableUsername(username);
            if (_result.Tables[0].Rows.Count > 0)
            {
                //Unavailable
                _status = false;
            }
            else
            {
                //Available
                _status = true;
            }
            return _status;
        }

        public void SignLogin()
        {
            StringBuilder _xml = new StringBuilder();
            string _username, _password, _userType;
            string FatherUsername = "";
            string MotherUsername = "";
            string _authen = "false";
            string _isSuccess = "0";
            string _msgTh = "";
            string _msgEn = "";
            try
            {
                DataTable _dtSign = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(_c.Request.Form["strSign"]);
                DataTable _dtInput = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(_c.Request.Form["strInput"]);

                int _row = _dtSign.Rows.Count;

                if (_row > 0)
                {

                    //ข้อมูล re-login
                    _username = _dtSign.Rows[0]["username"].ToString();
                    _password = _dtSign.Rows[0]["password"].ToString();
                    _userType = _dtSign.Rows[0]["userType"].ToString();

                    Login _login = new Login(_userType);
                    string _studentId = _login.StudentId;
                    //string _acaYear = Myconfig.GetYearContract();


                    StudentInfo _stdInfo = new StudentInfo(_login.StudentCode);
                    ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
                    ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");

                    ContractInfo _ctInfo = new ContractInfo(_studentId);// check already sign contract
                    string _acaYear = Myconfig.CvEmpty(_stdInfo.AcaYear, " - ");
                    string _parentType = _login.UserType; //F M or student



                    //ตรวจสอบ ประเภท ผู้ใช้งาน เพื่อตรวจสอบสิทธิ์
                    if (_userType == "STUDENT")
                    {
                        //Generate Username
                        FatherUsername = GenerateUsername(_parentFInfo.enFirstName, _parentFInfo.enLastName).ToLower();
                        MotherUsername = GenerateUsername(_parentMInfo.enFirstName, _parentMInfo.enLastName).ToLower();
                        _authen = Login.AuthenSignStudent(_username, _userType);
                    }
                    else if (_userType == "PARENT")
                    {
                        _authen = Login.AuthenSignParent(_username, _password, _userType);

                    }

                    //จบ

                    //ตรวจสอบ รหัสผ่านอีกครั้งก่อนทำการบันทึกการทำสัญญา ทั้งสัญญานักศึกษา สัญญาค้ำประกัน หนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม
                    if (_authen == "true")
                    {
                        //save data
                        ContractUI.SetContract(_dtInput, _acaYear, _studentId, _userType, _parentType, _ctInfo.DocId, _username, FatherUsername, MotherUsername);


                        //after finish save
                        //refill data
                        _ctInfo = new ContractInfo(_studentId);//refresh data for checkstatus complete
                        if (_userType == "STUDENT")
                        {
                            if (_ctInfo.StatusSignStudent == "Y" || _ctInfo.StatusComplete == "S")
                            {
                                _isSuccess = "1";
                            }
                        }
                        else if (_userType == "PARENT")
                        {

                            //ผู้ใช้งาน เป็นผู้ค้ำประกัน และได้ทำสัญญาแล้ว
                            if (_ctInfo.WarrantBy == _parentType && _ctInfo.SignParent1 == "True")
                            {
                                _isSuccess = "1";

                            }
                            //ผู้ใช้งาน เป็นยินยอม และได้ทำสัญญาแล้ว
                            else if (_ctInfo.ConsentBy == _parentType && _ctInfo.SignParent2 == "True")
                            {
                                _isSuccess = "1";
                            }
                            else if (_ctInfo.StatusComplete == "S")
                            {

                                _isSuccess = "1";
                            }

                        }


                        if (_isSuccess == "1")
                        {
                            _msgTh = "<span class=\"green-text\"><h5>ดำเนินการบันทึกสัญญาเข้าระบบแล้ว</h5></span>";
                            _msgEn = "<span class=\"green-text\"><h5>Successfully Sign Contract</h5></span>";
                            _xml.Append(ContractUI.UiComplete(_ctInfo, _stdInfo, _parentMInfo, _parentFInfo, _userType));
                        }
                        else
                        {
                            _msgTh = "<span class=\"red-text\"><h5>ระบบขัดข้อง!!! ไม่สามารถบันทึกข้อมูลได้</h5></span>";
                            _msgEn = "<span class=\"red-text\"><h5>System Error!!!</h5></span>";
                        }

                    }
                    else if (_authen == "false")
                    {
                        _msgTh = "<span class=\"red-text\"><h5>ผู้ใช้งาน/รหัสผ่าน ไม่ถูกต้อง!!!</h5></span>";
                        _msgEn = "<span class=\"red-text\"><h5>User/Password Incorrect!!!</h5></span>";
                    }//จบ
                }
                else
                {
                    _msgTh = "<span class=\"red-text\"><h5>ไม่พบการส่งค่าข้อมูล!!!</h5></span>";
                    _msgEn = "<span class=\"red-text\"><h5>Post Data Not Found!!!</h5></span>";
                }
            }
            catch (Exception _ex)
            {
                _msgTh = "<span class=\"red-text\"><h5>ระบบผิดพลาด : " + _ex.Message.Replace("'", " ") + "</h5></span>";
                _msgEn = "<span class=\"red-text\"><h5>CODE ERROR : " + _ex.Message.Replace("'", " ") + "</h5></span>"; ;
            }
            _xml.Append("<input type='hidden' class='txtProcessStatus' value='" + _isSuccess + "' data-msg_th='" + _msgTh + "' data-msg_en='" + _msgEn + "' >");
            _c.Response.Write(_xml.ToString());
        }

        public void UiPreviewContrat()
        {
            StringBuilder _string = new StringBuilder();
            string _userType = _c.Request.Form["userType"];
            string _warranty = _c.Request.Form["warranty"];
            string _consent = _c.Request.Form["consent"];
            Login _login = new Login(_userType);
            string _studentId = _login.StudentId;
            //string _acaYear = Myconfig.GetYearContract();
            string _username = _login.Username;
            StudentInfo _stdInfo = new StudentInfo(_login.StudentCode);
            string _acaYear = Myconfig.CvEmpty(_stdInfo.AcaYear, " - ");
            string _quotaCode = _stdInfo.QuotaCode;
            string _programCode = _stdInfo.ProgramCode;
            string _checkDataStd = _stdInfo.CheckDataStd;
            ContractInfo _ctInfo = new ContractInfo(_studentId);
            //_string.Append(ContractPreview.SIMDB_Preview(_acaYear,_studentId));
            string _statusContract = "";
            int _checkAcaYear = Convert.ToInt32(_acaYear);
            //int _checkAcaYear = 2565;
            if (_checkAcaYear < 2565)
            {
                _statusContract = "OLD";
            }
            else
            {
                _statusContract = "NEW";
            }
            switch (_programCode)
            {
                case "SIMDB":
                    switch (_statusContract)
                    {
                        case "NEW":
                            _string.Append(ContractPreview.Preview_SIMDBNEW(_acaYear, _studentId, _warranty, _consent, _stdInfo.StudentCode));
                            break;
                        case "OLD":
                            _string.Append(ContractPreview.Preview_SIMDB(_acaYear, _studentId, _stdInfo.StudentCode));
                            break;
                    }
                    break;

                case "RAMDB":
                    switch (_statusContract)
                    {
                        case "NEW":
                            _string.Append(ContractPreview.Preview_RAMDBNEW(_acaYear, _studentId, _warranty, _consent, _stdInfo.StudentCode));
                            break;
                        case "OLD":
                            _string.Append(ContractPreview.Preview_RAMDB(_acaYear, _studentId, _stdInfo.StudentCode));
                            break;
                    }
                    break;

                case "PYPYB":
                    _string.Append(ContractPreview.Preview_PYPYB(_acaYear, _studentId, _stdInfo.StudentCode));
                    break;

                case "DTDSB":
                    switch (_statusContract)
                    {
                        case "NEW":
                            _string.Append(ContractPreview.Preview_DTDSBNEW(_acaYear, _studentId, _warranty, _consent, _stdInfo.StudentCode));
                            break;
                        case "OLD":
                            _string.Append(ContractPreview.Preview_DTDSB(_acaYear, _studentId, _stdInfo.StudentCode));
                            break;
                    }
                    break;
                case "RANSB":
                    _string.Append(ContractPreview.Preview_RANSB(_acaYear, _studentId, _stdInfo.StudentCode));
                    break;

                case "NSNSB":
                    switch (_quotaCode) // specification nurse program project
                    {
                        default: // siriraj hospital
                            _string.Append(ContractPreview.Preview_NSNSB(_acaYear, _studentId, _stdInfo.StudentCode));
                            break;

                        case "354": // chula research
                            _string.Append(ContractPreview.Preview_NSNSB_CL(_acaYear, _studentId, _stdInfo.StudentCode));
                            break;

                        case "351": // faculty of tropical medicine
                            _string.Append(ContractPreview.Preview_NSNSB_TM(_acaYear, _studentId, _stdInfo.StudentCode));
                            break;
                    }
                    break;
            }
            if (_checkDataStd == "N")
            {
                _string.Append(GetMessageProfilevalidated());
            }
            else
            {
                _string.Append(ContractUI.UiReLoginForm(_userType, _ctInfo, _username, "student"));
            }
            _string.Append("<span class='waves-effect waves-light btn-large grey col s12  accent-12 btnBack' >ย้อนกลับ</span><br><br>");
            _c.Response.Write(_string.ToString());
        }


        public string GetMessageProfilevalidated()
        {
            StringBuilder _string = new StringBuilder();
            _string.Append("<div class='card-panel blue lighten-5'>");
            _string.Append("<div class='row'>");
            _string.Append("<h5 class='red-text'><center>เนื่องจากนักศึกษากรอกข้อมูลในระบบ e-Profile ไม่ครบถ้วน</center><p><center>ให้นักศึกษาเข้าระบบ e-Profile เพื่อกรอกข้อมูลในช่องที่ขาดหาย</center></p></h5>");
            _string.Append("<h5 class='green-text'><center>hint : ข้อมูลที่อยู่ที่ปรากฏในสัญญาชื่อ-นามสกุล, วันเกิด<br>ที่อยู่ปัจจุบันที่ติดต่อได้ บ้านเลขที่, ตำบล, อำเภอ, จังหวัด, รหัสไปรษณีย์<br> เบอร์โทรศัพท์, บัตรประชาชน, ชื่อ-นามสกุล บิดา, ชื่อ-นามสกุล มารดา <br>และที่อยู่ปัจจุบันของบิดา มารดา</center></h5>");
            _string.Append("<h5><center><a href='https://smartedu.mahidol.ac.th'>คลิกที่นี่เพื่อเข้าสู่ระบบ e-Profile</a></center></p><p><center>ถ้าระบบ e-Profile ไม่เปิดให้บริการ กรุณาติดต่อ 02-849-4562 </center></p><p><center>เพื่อให้เจ้าหน้าที่เปิดระบบ</center></h5>");
            _string.Append("</div>");
            _string.Append("</div>");
            return _string.ToString();
        }

        public void UIsetConfirmRequestPassword()
        {
            StringBuilder _string = new StringBuilder();
            _string.Append(ContractUI.UIsetConfirmRequestPassword());
            _c.Response.Write(_string.ToString());
        }

        public void UIsetAcceptedRequestPassword()
        {
            StringBuilder _string = new StringBuilder();
            _string.Append(ContractUI.UIsetAcceptedRequestPassword());
            _c.Response.Write(_string.ToString());
        }

        /// <summary>
        /// Auther : anussara.wan
        /// Date   : 2019-08-20
        /// Perpose: SetConfirmParent
        /// Method : SetConfirmParent
        /// Sample : N/A
        /// </summary>
        public void SetConfirmParent()
        {
            string _userType = _c.Request.Form["userType"];
            Login _login = new Login(_userType);
            string _studentId = _login.StudentId;
            string _username = _login.Username;
            StringBuilder _string = new StringBuilder();
            ContractInfo _ctInfo = new ContractInfo(_studentId);// check already sign contract
            string _parentType = _login.UserType; //F M or student
            string _confirmStatus = "Y";
            ContractDB.SetConfirmParent(_username, _studentId, _confirmStatus);
            _string.Append(ContractPreview.Preview_Guarantee(_studentId, _parentType, _login.StudentCode));
            _string.Append(ContractPreview.Preview_Warrant(_studentId, _parentType, _login.StudentCode));
            _string.Append(ContractUI.UiReLoginForm(_userType, _ctInfo, _username, _userType));
            _c.Response.Write(_string.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        //public void CheckConsent()
        //{
        //    DataSet _ds = new DataSet();
        //    string _consentStatus = "";
        //    string _userType = _c.Request.Form["userType"];
        //    Login _login = new Login(_userType);
        //    string _studentId = _login.StudentId;
        //    _ds = ContractDB.GetConsent(_studentId);
        //    if (_ds.Tables[0].Rows.Count > 0)
        //    {
        //        _consentStatus = "true";
        //    }
        //    else
        //    {
        //        _consentStatus = "false";
        //    }
        //    _c.Response.Write(_consentStatus);
        //}

        public void CheckENFullNameParent()
        {
            DataSet _ds = new DataSet();
            string _userType = _c.Request.Form["userType"];
            string _warranty = _c.Request.Form["warranty"];
            string _consent = _c.Request.Form["consent"];
            Login _login = new Login(_userType);
            string _studentId = _login.StudentId;
            ParentInfo parentInfoWarranty = null;
            ParentInfo parentInfoConsent = null;
            ParentInfo parentInfo = null;
            if (_warranty == _consent)
            {
                //Same person
                parentInfo = new ParentInfo(_studentId, _warranty);

                string _enFirstName = parentInfo.enFirstName;
                string _enLastName = parentInfo.enLastName;
                if (_enFirstName == "" || _enLastName == "" && parentInfo.nationalityId == "177")
                {
                    _c.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Status = "False",
                        Person = "Same",
                        enFirstName = _enFirstName,
                        enLastName = _enLastName,

                    }));
                }
                else if (parentInfo.nationalityId != "177" && _enFirstName == "")
                {
                    _c.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Status = "False",
                        Person = "Same",
                        enFirstName = _enFirstName,
                        enLastName = _enLastName,

                    }));
                }
                else
                {
                    _c.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Status = "True",
                        Person = "Same"
                    }));
                }
            }
            else
            {
                //Different person
                parentInfoWarranty = new ParentInfo(_studentId, _warranty);
                parentInfoConsent = new ParentInfo(_studentId, _consent);
                string _enFirstNameWarranty = parentInfoWarranty.enFirstName;
                string _enLastNameWarranty = parentInfoWarranty.enLastName;
                string _enFirstNameConsent = parentInfoConsent.enFirstName;
                string _enLastNameConsent = parentInfoConsent.enLastName;
                if ((_enFirstNameWarranty == "" || _enLastNameWarranty == "" || _enFirstNameConsent == "" || _enLastNameConsent == "") && (parentInfoWarranty.nationalityId == "177" && parentInfoConsent.nationalityId == "177"))
                {
                    _c.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Status = "False",
                        Person = "Different",
                        enFirstNameWarranty = _enFirstNameWarranty,
                        enLastNameWarranty = _enLastNameWarranty,
                        enFirstNameConsent = _enFirstNameConsent,
                        enLastNameConsent = _enLastNameConsent
                    }));
                }
                else if ((parentInfoWarranty.nationalityId != "177" || parentInfoConsent.nationalityId != "177") && (_enFirstNameWarranty == "" || _enFirstNameConsent == ""))
                {
                    _c.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Status = "False",
                        Person = "Different",
                        enFirstNameWarranty = _enFirstNameWarranty,
                        enLastNameWarranty = _enLastNameWarranty,
                        enFirstNameConsent = _enFirstNameConsent,
                        enLastNameConsent = _enLastNameConsent
                    }));
                }
                else
                {
                    _c.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Status = "True",
                        Person = "Different"
                    }));
                }
            }
        }
    }
}