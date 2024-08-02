//using authen;
using eContract;
using System;
using System.Data;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for contractUI
/// </summary>
namespace eContract
{


    public class ContractUI
    {
        public ContractUI()
        { }



        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: UiStudentProfile
        /// Method : UiStudentProfile
        /// Sample : N/A
        /// </summary>
        public static string UiStudentProfile(string _studentCode)
        {
            StringBuilder _string = new StringBuilder();

            StudentInfo _stdInfo = new StudentInfo(_studentCode);


            string _programCode, _quotaCode, _admissionType, _stdNameTh, _stdNameEn, _stdStatusEn, _stdStatusTh, _urlPic;
            string _facultyCode, _facultyNameTh, _facultyNameEn, _pCode, _programNameTh, _programNameEn, _urlPicInternet;

            //_studentCode = Myconfig.CvEmpty(_stdInfo.StudentCode, " - ");
            _admissionType = Myconfig.CvEmpty(_stdInfo.AdmissionType, " - ");
            _urlPic = Myconfig.CvEmpty(_stdInfo.UrlPic, " - ");
            _stdNameEn = Myconfig.CvEmpty(_stdInfo.StdNameEn, " - ");
            _stdNameTh = Myconfig.CvEmpty(_stdInfo.StdNameTh, " - ");
            _programCode = Myconfig.CvEmpty(_stdInfo.ProgramCode, " - ");
            _quotaCode = Myconfig.CvEmpty(_stdInfo.QuotaCode, " - ");
            _facultyCode = Myconfig.CvEmpty(_stdInfo.FacultyCode, " - ");
            _facultyNameTh = Myconfig.CvEmpty(_stdInfo.FacultyNameTh, " - ");
            _facultyNameEn = Myconfig.CvEmpty(_stdInfo.FacultyNameEn, " - ");
            _programNameTh = Myconfig.CvEmpty(_stdInfo.ProgramNameTh, " - ");
            _programNameEn = Myconfig.CvEmpty(_stdInfo.ProgramNameEn, " - ");
            _pCode = Myconfig.CvEmpty(_stdInfo.PCode, " - ");
            _stdStatusEn = Myconfig.CvEmpty(_stdInfo.StatusEn, " - ");
            _stdStatusTh = Myconfig.CvEmpty(_stdInfo.StatusTh, " - ");
            _urlPicInternet = _stdInfo.UrlPicInternet;

            _string.Append("<div class='row'>");
            _string.Append("    <div class='col m2 l2 hide-on-med-and-down'>" +
                           "            <img src = '" + _urlPicInternet + "' alt='' class='square responsive-img z-depth-1'" +
                           "                onError='this.onerror=null;this.src='nopic.png';'/>" +
                           "    </div>");



            _string.Append(@"   <div class='col l2 m2 hide-on-med-and-down'>
                                <ul class='pink-text'>
                                        <li><span class='th'>รหัสนักศึกษา</span><span class='en hide'>StudentID</span></li>
                                        <li><span class='th'>ชื่อ-นามสกุล</span><span class='en hide'>Name-Lastname</span></li>
                                        <li><span class='th'>คณะ</span><span class='en hide'>Faculty</span></li>
                                        <li><span class='th'>หลักสูตร</span><span class='en hide'>Program</span></li>
                                        <li><span class='th'>สถานะ</span><span class='en hide'>Status</span></li>
                                </ul>
                            </div>");

            _string.Append("   <div class='col l8 m8 s12'>" +
                           "       <ul class='blue-text text-darken-4'>" +
                           "               <li>" + _studentCode + "</li>" +
                           "               <li><span class='th'>" + _stdNameTh + "</span></li>" +
                           "               <li><span class='en hide'>" + _stdNameEn + "</span></li>" +
                           "               <li><span class='th'>" + _facultyNameTh + "</span>" +
                           "                   <span class='en hide'>" + _facultyNameEn + "</span>" +
                           "                   <span>&nbsp;&nbsp;( " + _facultyCode + " )</span>" +
                           "               </li>" +
                           "               <li>" +
                           "                   <span class='th'>" + _programNameTh + "</span>" +
                           "                   <span class='en hide'>" + _programNameEn + "</span>" +
                           "               </li>" +
                           "               <li>" +
                           "                   <span class='th'>" + _stdStatusTh + "</span>" +
                           "                   <span class='en hide'>" + _stdStatusEn + "</span>" +
                           "               </li>" +
                           "       </ul>" +
                           "   </div>");

            _string.Append("</div>");

            return _string.ToString();
        }

        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: ข้อมูล บิดามารดา
        /// Method : parentProfile
        /// Sample : N/A
        /// </summary>
        public static string UiParentProfile(string _studentId, string _parentType, string _studentCode)
        {
            StringBuilder _string = new StringBuilder();

            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            ParentInfo _parentInfo = new ParentInfo(_studentId, _parentType);

            string _idCard, _fullNameTh, _fullNameEn, _position;
            string _stdNameTh, _stdNameEn, _stdStatusTh, _stdStatusEn;

            _idCard = Myconfig.CvEmpty(_parentInfo.IdCard, " - ");
            _fullNameTh = Myconfig.CvEmpty(_parentInfo.FullNameTh, " - ");
            _fullNameEn = Myconfig.CvEmpty(_parentInfo.FullNameEn, " - ");
            _position = Myconfig.CvEmpty(_parentInfo.Position, " - ");

            _stdNameTh = Myconfig.CvEmpty(_stdInfo.StdNameTh, " - ");
            _stdNameEn = Myconfig.CvEmpty(_stdInfo.StdNameEn, " - ");
            _stdStatusEn = Myconfig.CvEmpty(_stdInfo.StatusEn, " - ");
            _stdStatusTh = Myconfig.CvEmpty(_stdInfo.StatusTh, " - ");

            _string.Append(@"<div class='row'>");

            _string.Append(@"   <div class='col m2 l2 hide-on-med-and-down'>
                                <img src = 'images/nopic.png' alt='' class='square responsive-img z-depth-1' />
                            </div>
                            <div class='col l2 m2 hide-on-med-and-down'>
                                <ul class='pink-text'>
                                    <li><span class='th'>เลข ปชช.</span><span class='en hide'>Student-ID</span></li>
                                    <li><span class='th'>ชื่อภาษาไทย</span><span class='en hide'>Thai-Name</span></li>
                                    <li><span class='th'>ชื่ออังกฤษ</span><span class='en hide'>Eng-Name</span></li>
                                    <li><span class='th'>อาชีพ</span><span class='en hide'>Faculty</span></li>
                                    <li><span class='th'>นักศึกษา</span><span class='en hide'>Student</span></li>
                                    <li><span class='th'>สถานะ</span><span class='en hide'>Status</span></li>
                                </ul>
                            </div>");


            _string.Append("    <div class='col l8 m8 s12'>" +
                            "       <ul class='blue-text text-darken-4'>" +
                            "           <li>" + _idCard + "</li>" +
                            "           <li><span>" + _fullNameTh + "</span></li>" +
                            "           <li><span>" + _fullNameEn + "</span></li>" +
                            "           </li>" +
                            "           <li><span class='th'>" + _position + "</span>" +
                            "                <span class='en hide'>" + _position + "</span>" +
                            "           </li>" +
                            "           <li>" +
                            "                <span class='th'>" + _stdNameTh + "</span>" +
                            "                <span class='en hide'>" + _stdNameEn + "</span>" +
                            "           </li>" +
                            "           <li>" +
                            "                <span class='th'>" + _stdStatusTh + "</span>" +
                            "                <span class='en hide'>" + _stdStatusEn + "</span>" +
                            "                <span class=''></span>" +
                            "           </li>" +
                            "       </ul>" +
                            "   </div>");

            _string.Append("</div>");


            return _string.ToString();
        }

        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Change Auther : korakot.pim
        /// Change Date   : 2020-08-07
        /// Detail Change : เพิ่มสถานภาพของบิดามารดา หย่าร้าง แยกกันอยู่ โสด
        /// Perpose: UiParentCheckingStatus
        /// Method : UiParentCheckingStatus
        /// Sample : N/A
        /// </summary>
        public static string UiParentCheckingStatus(string _studentId)
        {
            StringBuilder _string = new StringBuilder();
            DataSet _ds = ContractDB.Sp_ectStatusInfo(_studentId);

            //const string _checked = "checked='checked'";
            string _register = string.Empty
                 , _unregister = string.Empty
                 , _divorced = string.Empty
                 , _fatherDied = string.Empty
                 , _motherDied = string.Empty
                 , _studentStatus = string.Empty
                 , _fatherAlive = string.Empty
                 , _motherAlive = string.Empty
                 , _registerStatus = string.Empty
                 , _studentStatusNameTh = string.Empty
                 , _studentStatusNameEn = string.Empty;

            // fill parameter

            _fatherAlive = _ds.Tables[0].Rows[0]["fatherSts"].ToString();
            _motherAlive = _ds.Tables[0].Rows[0]["motherSts"].ToString();
            _registerStatus = _ds.Tables[0].Rows[0]["marriedSts"].ToString();
            _studentStatus = _ds.Tables[0].Rows[0]["studentStatus"].ToString();
            _studentStatusNameEn = _ds.Tables[0].Rows[0]["stsNameEn"].ToString();
            _studentStatusNameTh = _ds.Tables[0].Rows[0]["stsNameTh"].ToString();

            // register status
            if (_studentStatus == "000") //สถานะกำลังศึกษาอยู่ไหม
            {
                //20200807 anussara.wan เนื่องจากอนาคตจะมีการยกเลิกการกรอกสถานภาพจาก e-Profile จึงไม่เช็ค Defalut แล้ว
                //switch (_registerStatus) //สถานภาพที่เลือกมาจากระบบ e-Profile
                //{
                //    case "1": // สมรสจดทะเบียน
                //        _register = _checked;
                //        break;

                //    case "2": // สมรสไม่จดทะเบียน
                //        _unregister = _checked;
                //        break;

                //    case "3": // หย่าร้าง
                //        _divorced = _checked;
                //        break;
                //}

                // father alive
                //switch (_fatherAlive)
                //{
                //    case "Y":
                //        _fatherAlive = _checked;
                //        break;

                //    case "N":
                //        _fatherDied = _checked;
                //        break;

                //    default:
                //        _fatherAlive = _checked;
                //        break;
                //}

                //// mother alive
                //switch (_motherAlive)
                //{
                //    case "Y":
                //        _motherAlive = _checked;
                //        break;

                //    case "N":
                //        _motherDied = _checked;
                //        break;

                //    default:
                //        _motherAlive = _checked;
                //        break;
                //}

                _string.Append(@"<ul class='collection'>
                            <li class='collection-item avatar'>
                                <i class='mdi mdi-human-male-female circle green'></i>
                                <span class='title'><span class='th'>สถานภาพสมรสบิดามารดา</span>
                                <span class='en hide'>Parent Status</span></span>
                                <p>");
                //สมรส จดทะเบียน
                _string.Append(@"               <input class='rdoMarried' name='rdoMarried' type='radio' id='rdoRegister' title='สมรส(จดทะเบียน)' value='1' />");
                _string.Append(@"               <label for='rdoRegister'>
                                        <span class='th'>จดทะเบียน</span><span class='en hide'>Registered</span>
                                    </label>");
                //สมรส ไม่จดทะเบียน
                _string.Append(@"               <input class='rdoMarried' name='rdoMarried' type='radio' title='สมรส(ไม่จดทะเบียน)' id='rdoNotregister' value='2' />");
                _string.Append(@"               <label for='rdoNotregister'>
                                        <span class='th'>ไม่จดทะเบียน</span><span class='en hide'>Not Registered</span>
                                    </label>");
                //หย่าร้าง
                _string.Append(@"               <input class='rdoMarried' name='rdoMarried' type='radio' title='หย่าร้าง(จดทะเบียนหย่า)' id='rdoDivorced' value='3' />");
                _string.Append(@"               <label for='rdoDivorced'>
                                        <span class='th'>หย่าร้าง</span><span class='en hide'>Divorced</span>
                                    </label>");
                //แยกกันอยู่
                _string.Append(@"               <input class='rdoMarried' name='rdoMarried' type='radio' title='แยกกันอยู่(จดทะเบียนแต่แยกกันอยู่)' id='rdoSeparated' value='4' />");
                _string.Append(@"               <label for='rdoSeparated'>
                                        <span class='th'>แยกกันอยู่(จดทะเบียนแต่แยกกันอยู่)</span><span class='en hide'>Separated</span>
                                    </label>");
                //หม้าย
                _string.Append(@"               <input class='rdoMarried' name='rdoMarried' type='radio' title='หม้าย(จดทะเบียนแต่ฝ่ายใดฝ่ายหนึ่งเสียชีวิต)' id='rdoWidowed' value='5' />");
                _string.Append(@"               <label for='rdoWidowed'>
                                        <span class='th'>หม้าย(จดทะเบียนแต่ฝ่ายใดฝ่ายหนึ่งเสียชีวิต)</span><span class='en hide'>Widowed</span>
                                    </label>");
                //โสด
                _string.Append(@"               <input class='rdoMarried' name='rdoMarried' type='radio' title='โสด(ไม่จดทะเบียนและแยกกันอยู่)' id='rdoSingle' value='6' />");
                _string.Append(@"               <label for='rdoSingle'>
                                        <span class='th'>โสด(ไม่จดทะเบียนและแยกกันอยู่)</span><span class='en hide'>Single</span>
                                    </label>");
                _string.Append(@"
                                </p>
                            </li>
                            <li class='collection-item avatar'>
                                <i class='mdi mdi-gender-male circle blue'></i>
                                <span class='title'><span class='th'>บิดามีชีวิตอยู่หรือไม่</span>
                                <span class='en hide'>Father Status</span></span>
                                <p>");
                _string.Append(@"           <input class='rdoFatherSts' name='rdoFatherSts' type='radio' id='rdoFatherStsYes'  value='1' />");
                _string.Append(@"           <label for='rdoFatherStsYes'>
                                        <span class='th'>มีชีวิตอยู่</span><span class='en hide'>Yes</span>
                                    </label>");
                _string.Append(@"           <input class='rdoFatherSts' name='rdoFatherSts' type='radio' id='rdoFatherStsNo' value='2' />");
                _string.Append(@"           <label for='rdoFatherStsNo'>
                                        <span class='th'>เสียชีวิตแล้ว</span><span class='en hide'>No</span>
                                    </label>
                                </p>
                            </li>
                            <li class='collection-item avatar'>
                                <i class='mdi mdi-gender-female circle pink'></i>
                                <span class='title'><span class='th'>มารดามีชีวิตอยู่หรือไม่</span>
                                <span class='en hide'>Mother Status</span></span>
                                <p>");
                _string.Append(@"           <input class='rdoMotherSts' name='rdoMotherSts' type='radio' id='rdoMotherStsYes' value='1' />");
                _string.Append(@"           <label for='rdoMotherStsYes'>
                                        <span class='th'>มีชีวิตอยู่</span><span class='en hide'>Yes</span>
                                    </label>");
                _string.Append(@"           <input class='rdoMotherSts' name='rdoMotherSts' type='radio' id='rdoMotherStsNo' value='2' />");
                _string.Append(@"           <label for='rdoMotherStsNo'>
                                        <span class='th'>เสียชีวิตแล้ว</span><span class='en hide'>No</span>
                                    </label>
                                </p>
                            </li>
                            ");
                //<li class='collection-item avatar panelStayWith' style='display:none;'>
                //    <i class='mdi mdi-home circle amber'></i>
                //    <span class='title'><span class='th'>นักศึกษาอาศัยอยู่กับ</span>
                //        <span class='en hide'>Stay with</span></span>
                //    <p>
                //        <input class='chkStay' name='chkStay' type='checkbox' id='chkStayF' value='1' />
                //        <label for='chkStayF'>
                //            <span class='th'>บิดา</span><span class='en hide'>Father</span>
                //        </label>
                //        <input class='chkStay' name='chkStay' type='checkbox' id='chkStayM' value='1' />
                //        <label for='chkStayM'>
                //            <span class='th'>มารดา</span><span class='en hide'>Mother</span>
                //        </label>
                //        <input class='chkStay' name='chkStay' type='checkbox' id='chkStayO' value='1' />
                //        <label for='chkStayO'>
                //            <span class='th'>บุคคลอื่น</span><span class='en hide'>Other</span>
                //        </label>

                //    </p>
                //</li>
                _string.Append(@"
                            <li class='collection-item avatar grey lighten-2'>
                                <i class='mdi mdi-clipboard-check circle blue-grey'></i>
                                <span class='title'><span class='th'>สรุปเงื่อนไข</span>
                                    <span class='en hide'>Summary Accept</span></span>
                                <p>
                                    <span class='green-text'>ค้ำประกันโดย : </span><span class='blue-text spWarrant'></span><br>
                                    <span class='green-text'>ยินยอมโดย : </span><span class='blue-text spConsent'></span><br><br>                                       
                                </p>
                                <p class='panelContactLost'>
                                    //<span class='title'><span class='th red-text'>สถานะติดต่อ :&nbsp; 
                                    //<input class='chkStay' name='chkStay' type='checkbox' id='chkStayLost' value='1' />
                                    //<label for='chkStayLost'>
                                    //    <span class='th red-text'>ไม่สามารถติดต่อ ผู้ค้ำประกันได้</span><span class='en hide red-text'>Family not found</span>
                                    //</label>
                                    //</span>
                                </p>");
                //เพิ่มการแสดงสถานะให้ติดต่อทำสัญญานอกระบบที่กองกฎหมาย
                _string.Append(@"
                                <p class='panelContactTolaw'>
                                        <span class='th red-text'>ให้นักศึกษาดำเนินการทำสัญญาการเป็นนักศึกษาผ่านระบบ e-Contract ให้เรียบร้อย ทั้งนี้ การทำหนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม และสัญญาค้ำประกันในระบบ e-Contract เป็นสิทธิของบิดาและมารดาโดยชอบธรรมด้วยกฎหมายเท่านั้น ระบบจะไม่สามารถออกรหัสผ่านให้แก่ บุคคลอื่น ซึ่งไม่ได้รับอนุญาตสิทธิ โปรดติดต่อกองกฎหมาย สำนักงานอธิการบดี เพื่อทำสัญญาการเป็นนักศึกษานอกระบบ e-Contract ต่อไป</span>
                                    </span>
                                </p>
                            </li>
                         </ul>");
                _string.Append("<span class='waves-effect waves-light btn-large green col s12  accent-12 btnConfirmInfo' >ยืนยันข้อมูล</span>");
            }
            else//กรณีที่นักศึกษาลาออกไปแล้ว
            {
                _string.Append(@"<ul class='collection'>
                            <li class='collection-item avatar'>");
                _string.Append(@"<span class='title'><span class='th red-text'>" + _studentStatusNameTh + "</span>");
                _string.Append(@"<span class='en hide red-text'>" + _studentStatusNameEn + "</span></span>");
                _string.Append(@"</li>
                            </ul>
                            ");
            }
            return _string.ToString();
        }

        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: parallaxbanner
        /// Method : parallaxbanner
        /// Sample : N/A
        /// </summary>
        public static string Parallaxbanner(string _acaYear1)
        {
            string _txtDateOpen = "";

            DataSet _ds = ContractDB.Sp_ectGetDateEvent(_acaYear1);

            int _row = _ds.Tables[0].Rows.Count;
            string _startDate, _endDate, _sTime, _eTime, _acaYear, _isBetween, _enAcaYear;
            string _startDateEn, _endDateEn;
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _startDate = _dr["cStartDate"].ToString();
                _endDate = _dr["cEndDate"].ToString();
                _startDateEn = _dr["enStartDate"].ToString();
                _endDateEn = _dr["enEndDate"].ToString();
                _acaYear = _dr["acaYear"].ToString();
                _isBetween = _dr["isBetween"].ToString();
                _enAcaYear = _dr["enAcaYear"].ToString();
                _sTime = _dr["cStartTime"].ToString();
                _eTime = _dr["cEndTime"].ToString();

                if (_isBetween == "1")
                {

                    _txtDateOpen = "<span class='th' style='font-size:15pt;font-weight:bold;color:green;'>เปิดทำสัญญา สำหรับนักศึกษาที่เข้าศึกษาปี " + _acaYear + " </br>ตั้งแต่วันที่ " + _startDate + " เวลา " + _sTime +" น. ถึงวันที่ " + _endDate + " เวลา " + _eTime + " น. " + "</span><span class='en hide' style='font-size:12pt;font-weight:bold;color:blue;'>Sign e-Contract. A Students who admission for academic year " + _enAcaYear + "(BE " + _acaYear + ")</br>the system wil be available from " + _startDateEn + " to " + _endDateEn + "  </span>";

                }
                else
                {

                    _txtDateOpen = "<span class='th' style='font-size:13pt;font-weight:bold;color:red;'>ยังไม่เปิดให้บริการ หรือ ปิดชั่วคราว สำหรับนักศึกษาที่เข้าศึกษาปี " + _acaYear + " </br>เปิด วันที่ " + _startDate + " เวลา " + _sTime + " น. ถึงวันที่ " + _endDate + " เวลา " + _eTime + " น. " + "</span><span class='en hide' style='font-size:12pt;font-weight:bold;color:red;'>The System out of service. A Students who admission for academic year " + _enAcaYear + "(BE " + _acaYear + ") </br>the system wil be available from " + _startDateEn + " to " + _endDateEn + "  </span>";
                }
            }


            StringBuilder _string = new StringBuilder();
            _string.Append(@"<div id='index-bannerx' class='parallax-container' style='height: 160px;'>
        <div class='section no-pad-bot '>
            <div class='container'>
                <div class='row'>
                    <div class='col s12 m12 l12'><img src='Images/logoFullName.png' alt='' class='responsive-img' /></div>
                    <div class='col s12 m8 l8 hide-on-small-only'>");
            _string.Append(@"<div class=''><h5 class='light'>" + _txtDateOpen + "</h5></div>");
            _string.Append(@"</div>
                    <div class='col s12 m4 l4'>
                        <div class='right-align'><img src='Images/contract_string.png' alt='' class='responsive-img' /></div>
                    </div>
                </div>
            </div>
        <div class='parallax'>
            <img src='images/bgs.png' alt='#' />
        </div>
    </div>");
            return _string.ToString();
        }

        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: parallaxbanner
        /// Method : parallaxbanner
        /// Sample : N/A
        /// </summary>
        public static string UiLoginForm()
        {
            StringBuilder _string = new StringBuilder();
            _string.Append(@"<div class='row'>
                        <div class='col s12 m6 l6'>
                            <div class='card medium'>
                                <div class='card-image waves-effect waves-block waves-light'>
                                    <img class='activator' src='images/student018-s.jpg' />
                                </div>
                                <div class='card-content'>
                                    <span class='card-title activator grey-text text-darken-4 th'>สำหรับนักศึกษา<i class='mdi mdi-dots-vertical right'></i></span>
                                    <span class='card-title activator grey-text text-darken-4 en hide'>For Student<i class='mdi mdi-dots-vertical right'></i></span>
                                    <p class='center-align'>
                                        <a href='javascript:void(0);' class='activator btn indigo darken-4 th student-login'>เข้าที่นี่</a>
                                        <a href='javascript:void(0);' class='activator btn indigo darken-4 en hide'>Click</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                    ");
            //<div class='card-reveal light-green lighten-5'>
            //    <span class='card-title grey-text text-darken-4'>
            //        <span class='th'>สำหรับนักศึกษา</span>
            //        <span class='en hide'>For Student</span>
            //        <i class='mdi mdi-close right'></i></span>

            //    <div class='row'>
            //        <div class='input-field'>
            //            <i class='mdi mdi-account-circle prefix'></i>
            //            <input placeholder='u59xxxxx' id='username' name='username' type='text' class='validate' maxlength='30' value='' />
            //            <label for='username'><span class='th'>ชื่อผู้ใช้งาน</span><span class='en hide'>Username</span></label>
            //        </div>
            //    </div>
            //    <div class='row'>
            //        <div class='input-field'>
            //            <i class='mdi mdi-multiplication prefix'></i>
            //            <input placeholder='internet account' id='studentpassword' name='studentpassword' type='password' class='validate' maxlength='50' value='' />
            //            <label for='studentpassword'><span class='th'>รหัสผ่าน</span><span class='en hide'>Password</span></label>
            //        </div>
            //    </div>
            //    <div>
            //        <p class='teal-text'><i class='mdi mdi-message-alert on-left'></i><span class='blue-text th'>ลืมรหัสผ่าน โทร 0-2849-6022</span>
            //        <span class='en hide'>Forgot password Call. 66(0) 2849-6022</span></p>
            //        <a href='https://myinternet.mahidol.ac.th/'><i class='mdi mdi-undo-variant'></i>
            //        <span class='pink-text th'>สมัครใช้งาน Internet Account หรือ เปลี่ยนรหัสผ่าน</span>
            //        <span class='pink-text en hide'>Register Internet Account or Change password</span></a>
            //    </div>
            //    <div class='card-action center-align'>
            //        <a href='javascript:void(0);' class='activator btn indigo darken-4 th student-login'>เข้าระบบ</a>
            //        <a href='javascript:void(0);' class='activator btn indigo darken-4 en hide student-login'>Log in</a>
            //    </div>
            //</div>
            _string.Append(@"
                        <div class='col s12 m6 l6'>
                            <div class='card medium'>
                                <div class='card-image waves-effect waves-block waves-light'>
                                    <img class='activator' src='images/grad010.jpg' />
                                </div>
                                <div class='card-content'>
                                    <span class='card-title activator grey-text text-darken-4 th'>สำหรับผู้ปกครอง<i class='mdi mdi-dots-vertical right'></i></span>
                                    <span class='card-title activator grey-text text-darken-4 en hide'>For Parent<i class='mdi mdi-dots-vertical right'></i></span>
                                    <p class='center-align'>
                                        <a href='javascript:void(0);' class='activator btn lime darken-4 th'>เข้าที่นี่</a>
                                        <a href='javascript:void(0);' class='activator btn lime darken-4 en hide'>Click</a>
                                    </p>
                                </div>
                                <div class='card-reveal pink lighten-5'>
                                    <span class='card-title grey-text text-darken-4'>
                                        <span class='th'>สำหรับผู้ปกครอง/ผู้คำประกัน-ยินยอม</span>
                                        <span class='en hide'>For Parent</span>
                                        <i class='mdi mdi-close right'></i></span>
                                    <div class='row'>
                                        <div class='input-field'>
                                            <i class='mdi mdi-account-circle prefix'></i>
                                            <input placeholder='' id='citizenid' name='userid' type='text' class='validate' maxlength='50' value='' />
                                            <label for='citizenid'><span class='th'>รหัสผู้ใช้</span><span class='en hide'>Username</span></label>
                                        </div>
                                    </div>
                                    <div class='row'>
                                        <div class='input-field'>
                                            <i class='mdi mdi-multiplication prefix'></i>
                                            <input placeholder='' id='parentpassword' name='parentpassword' type='password' class='validate' maxlength='30' value='' />
                                            <label for='parentpassword'><span class='th'>รหัสผ่าน</span><span class='en hide'>Password</span></label>
                                        </div>
                                    </div>
                                    <div>
                                        <p class='teal-text'><i class='mdi mdi-message-alert on-left'></i><span class='blue-text th'>ลืมรหัสผ่าน โทร 0-2849-6260</span>
                                        <span class='en hide'>Forgot password Call. 0(66)2849-6260</span></p>
                                        <i class='mdi mdi-undo-variant'></i>
                                        <span class='pink-text th'>นักศึกษาเป็นผู้รับรหัสผ่านของบิดาและมารดา จากส่วนสำหรับนักศึกษาขอให้บิดาและมารดา<br/>สอบถามข้อมูล Username และ Password จากนักศึกษาก่อนเข้าทำสัญญา</span>
                                        <span class='pink-text en hide'>The Student will receive Parents' Username and Password from the Student Section. Please ask the student for your Username and Password before entering into a contract.</span>
                                    </div>
                                    <div class='card-action center-align'>
                                        <input type='hidden' id='usertype' name='usertype' value='' />
                                        <a href='javascript:void(0);' class='activator btn lime darken-4 th parent-login'>เข้าระบบ</a>
                                        <a href='javascript:void(0);' class='activator btn lime darken-4 en hide parent-login'>LOG-IN</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>");
            return _string.ToString();
        }

        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: reLoginForm
        /// Method : reLoginForm
        /// Sample : N/A
        /// </summary>
        public static string UiReLoginForm(string _userType, ContractInfo _ctInfo, string _username, string _parentType)
        {
            string _lblUsernameTh = "";
            string _lblUserNameEn = "";
            string _lblPasswordTh = "";
            string _lblPasswordEn = "";

            string _warrantBy = _ctInfo.WarrantBy;
            string _consentBy = _ctInfo.ConsentBy;
            string _txtTitle = "ใส่รหัสอีกครั้งเพื่อยืนยันการทำสัญญา";
            if (_warrantBy == _parentType)
            {
                _txtTitle += " ค้ำประกัน";
            }
            else if (_consentBy == _parentType)
            {
                _txtTitle += " ยินยอมคู่สมรส";

            }

            StringBuilder _string = new StringBuilder();

            if (_userType == "STUDENT")
            {
                _lblUsernameTh = "รหัสนักศึกษา";
                _lblUserNameEn = "STUDENT ID";
                _lblPasswordTh = "รหัสผ่าน (Internet Account)";
                _lblPasswordEn = "INTERNET ACCOUNT";
                _string.Append("   <div class='card-panel blue lighten-5'>" +
                   "         <div class='row'>" +
                   "             <h5 class='red-text'><span class='th'>" + _txtTitle + "</span><span class='en hide'>Re-Login for sign contract</span></h5>" +
                   "             <div class='col s12 m8 l8'>" +
                   "                 <div class='input-field'>" +
                   "                     <i class='mdi mdi-account-circle prefix'></i>" +
                   "                     <input placeholder='' id='username' name='username' type='text' class='validate valid' maxlength='8' value='" + _username + "' />" +
                   "                     <label for='username' class='active'><span class='th'>" + _lblUsernameTh + "</span><span class='en hide'>" + _lblUserNameEn + "</span></label>" +
                   "                 </div>" +
                   "             </div>" +
                   //"             <div class='col s12 m4 l4'>" +
                   //"                 <div class='input-field'>" +
                   //"                     <i class='mdi mdi-multiplication prefix'></i>" +
                   //"                     <input placeholder='' id='password' name='password' type='password' class='validate' maxlength='50' value='' />" +
                   //"                     <label for='password'><span class='th'>" + _lblPasswordTh + "</span><span class='en hide'>" + _lblPasswordEn + "</span></label>" +
                   //"                 </div>" +
                   //"             </div>" +
                   "            <div class='col s12 m4 l4'>" +
                   "                 <div class='center'>" +
                   "                     <a href='#!' class='waves-effect waves-light btn-large blue accent-4 btnReLogin'><i class='mdi mdi-checkbox-marked-circle-outline'></i>" +
                   "                         <span class='th'>ทำสัญญา</span><span class='en hide'>Sign Contract</span>" +
                   "                     </a>" +
                   "                 </div>" +
                   "             </div>" +
                   "         </div>" +
                   "     </div>");
            }
            else if (_userType == "PARENT")
            {
                _lblUsernameTh = "รหัสผู้ใช้";
                _lblUserNameEn = "USERNAME";
                _lblPasswordTh = "รหัสผ่าน";
                _lblPasswordEn = "PASSWORD";
                _string.Append("   <div class='card-panel blue lighten-5'>" +
                   "         <div class='row'>" +
                   "             <h5 class='red-text'><span class='th'>" + _txtTitle + "</span><span class='en hide'>Re-Login for sign contract</span></h5>" +
                   "             <div class='col s12 m4 l4'>" +
                   "                 <div class='input-field'>" +
                   "                     <i class='mdi mdi-account-circle prefix'></i>" +
                   "                     <input placeholder='' id='username' name='username' type='text' class='validate valid' maxlength='30' value='" + _username + "' />" +
                   "                     <label for='username' class='active'><span class='th'>" + _lblUsernameTh + "</span><span class='en hide'>" + _lblUserNameEn + "</span></label>" +
                   "                 </div>" +
                   "             </div>" +
                   "             <div class='col s12 m4 l4'>" +
                   "                 <div class='input-field'>" +
                   "                     <i class='mdi mdi-multiplication prefix'></i>" +
                   "                     <input placeholder='' id='password' name='password' type='password' class='validate' maxlength='50' value='' />" +
                   "                     <label for='password'><span class='th'>" + _lblPasswordTh + "</span><span class='en hide'>" + _lblPasswordEn + "</span></label>" +
                   "                 </div>" +
                   "             </div>" +
                   "            <div class='col s12 m4 l4'>" +
                   "                 <div class='center'>" +
                   "                     <a href='#!' class='waves-effect waves-light btn-large blue accent-4 btnReLogin'><i class='mdi mdi-checkbox-marked-circle-outline'></i>" +
                   "                         <span class='th'>ทำสัญญา</span><span class='en hide'>Sign Contract</span>" +
                   "                     </a>" +
                   "                 </div>" +
                   "             </div>" +
                   "         </div>" +
                   "     </div>");
            }




            return _string.ToString();
        }

        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: UiComplete
        /// Method : UiComplete
        /// Sample : N/A
        /// </summary>
        public static string UiComplete(ContractInfo _ctInfo, StudentInfo _stdInfo, ParentInfo _parentMInfo, ParentInfo _parentFInfo, string _userType)
        {
            StringBuilder _string = new StringBuilder();
            const string _teal = "teal-text";
            const string _amber = "amber-text";
            const string _red = "red-text";
            const string _contractTh = "การทำสัญญา";
            const string _contractEn = "Contract";
            const string _completeTh = "เสร็จสิ้น";
            const string _completeEn = "Complete";
            const string _incompleteTh = "ยังไม่เสร็จสิ้น";
            const string _incompleteEn = "not complete";

            const string _messageIncomplete = "กรุณาติดต่อผู้ปกครองให้ดำเนินการจัดทำ หนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม และ สัญญาค้ำประกัน";
            const string _messageComplete = "ดาวน์โหลดเอกสารเก็บไว้เป็นหลักฐาน";
            Login _login = new Login("STUDENT");


            string _message = _messageIncomplete;
            string _iconPass = "<i class='mdi mdi-check green-text'></i>";
            string _iconNotpass = "<i class='mdi mdi-close-box-outline red-text'></i>";
            string _contractHeaderTh = "";
            string _contractHeaderEn = "";
            string _csstext = _amber;
            // fill parameter

            string _contractDate = _ctInfo.DateLongContractStudent;

            string _iconContract = string.Empty, _iconGuarantee = string.Empty, _iconWarrant = string.Empty;
            string _cssContract = string.Empty, _cssGuarantee = string.Empty, _cssWarrant = string.Empty;
            string _headContract = string.Empty, _headGuarantee = string.Empty, _headWarrant = string.Empty;


            string _btnPrintContract = "";
            string _btnPrintConsent = "";
            string _btnPrintWarrant = "";
            string _btnPrintAll = "";

            // check 3 pass items. active on download .pdf button
            if ((_ctInfo.StatusComplete == "S") || (_ctInfo.SignStudent == "True" && _ctInfo.SignParent1 == "True" && _ctInfo.SignParent2 == "True"))
            {
                _csstext = _teal;
                _message = _messageComplete;
                _contractHeaderTh = "การทำสัญญาสมบูรณ์ครบถ้วน";
                _contractHeaderEn = "Sign Contract is Successfully";

                //_btnPrintAll = "<a href='printContract.aspx?action=printAll&userType=" + _userType + "' target='printContract' class='waves-effect waves-light btn-large green'>" +
                //               "    <span class='th'>ดาวน์โหลดเอกสาร 3 ฉบับ</span><span class='en hide'>Download All items</span><i class='mdi mdi-file-pdf'></i>" +
                //               "</a>";


                _btnPrintContract = "<a href='printContract.aspx?action=printContract&userType=" + _userType + "' target='printContract' class='waves-effect waves-light btn-large  green darken-1'>" +
                                        "<span class='th'>สัญญา</span><span class='en hide'>Contract</span><i class='mdi mdi-file-pdf'></i>" +
                                    "</a>";
                _btnPrintConsent = "<a href='printContract.aspx?action=printConsent&userType=" + _userType + "' target='printContract' class='waves-effect waves-light btn-large green darken-1'>" +
                                        "<span class='th'>สัญญา</span><span class='en hide'>Contract</span><i class='mdi mdi-file-pdf'></i>" +
                                    "</a>";

                _btnPrintWarrant = "<a href='printContract.aspx?action=printWarrant&userType=" + _userType + "' target='printContract' class='waves-effect waves-light btn-large green darken-1'>" +
                            "<span class='th'>สัญญา</span><span class='en hide'>Contract</span><i class='mdi mdi-file-pdf'></i>" +
                        "</a>";

            }
            else
            {

                _csstext = _red;
                if (_ctInfo.SignStudent == "True" && (_ctInfo.SignParent1 == "False" || _ctInfo.SignParent2 == "False"))
                {
                    _contractHeaderTh = "การทำสัญญายังไม่สมบูรณ์ครบถ้วน<br>กรุณาแจ้งผู้ค้ำประกัน/ยินยอม ให้เข้ามาทำสัญญา";
                    _contractHeaderEn = "Sign Contract is Unsuccessfully";

                }


                //_btnPrintAll = "<span  class='waves-effect waves-light btn-large red darken-4 disabled'>" +
                //               "    <span class='th'>ดาวน์โหลดเอกสาร 3 ฉบับ</span><span class='en hide'>Download All items</span><i class='mdi mdi-file-pdf'></i>" +
                //               "</span>";
                _btnPrintContract = "<span class='waves-effect waves-light btn-large red accent-2 disabled'>" +
                                        "<span class='th'>สัญญา</span><span class='en hide'>Contract</span><i class='mdi mdi-file-pdf'></i>" +
                                   "</span>";
                _btnPrintConsent = "<span class='waves-effect waves-light btn-large red accent-2 disabled'>" +
                                    "   <span class='th'>สัญญา</span><span class='en hide'>Contract</span><i class='mdi mdi-file-pdf'></i>" +
                                    "</span>";

                _btnPrintWarrant = "<span class='waves-effect waves-light btn-large red accent-2 disabled'>" +
                                    "   <span class='th'>สัญญา</span><span class='en hide'>Contract</span><i class='mdi mdi-file-pdf'></i>" +
                                    "</span>";
            }

            _iconGuarantee = _ctInfo.StatusSignMother == "Y" ? _iconPass : _iconNotpass;
            _iconWarrant = _ctInfo.StatusSignMother == "Y" ? _iconPass : _iconNotpass;

            // นักศึกษาทำสํญญาแล้ว หรือสถานะสำเร็จ
            if (_ctInfo.StatusComplete == "S" || _ctInfo.SignStudent == "True")
            {

                _iconContract = _iconPass;
                _cssContract = _teal;
                _headContract = _completeTh;
                _btnPrintContract = "<a href='printContract.aspx?action=printContract&userType=" + _userType + "' target='printContract' class='waves-effect waves-light btn-large  green darken-1'>" +
                                        "<span class='th'>สัญญา</span><span class='en hide'>Contract</span><i class='mdi mdi-file-pdf'></i>" +
                                    "</a>";


            }
            else
            {
                _iconContract = _iconNotpass;
                _cssContract = _red;
                _headContract = _incompleteTh;

            }

            // warrant
            //ถ้าผู้ค้ำประกัน สถานะสำเร็จ
            if (_ctInfo.StatusComplete == "S" || _ctInfo.SignParent1 == "True")
            {
                _iconWarrant = _iconPass;
                _cssWarrant = _teal;
                _headWarrant = _completeTh;

            }
            else
            {
                _iconWarrant = _iconNotpass;
                _cssWarrant = _red;
                _headWarrant = _incompleteTh;

            }

            // guarantee
            //ถ้าผู้ยินยอมคู่สมรส สถานะสำเร็จ
            if (_ctInfo.StatusComplete == "S" || _ctInfo.SignParent2 == "True")
            {
                _iconGuarantee = _iconPass;
                _cssGuarantee = _teal;
                _headGuarantee = _completeTh;

            }
            else
            {
                _iconGuarantee = _iconNotpass;
                _cssGuarantee = _red;
                _headGuarantee = _incompleteTh;

            }



            _string.Append("   <div class='section'>" +
                            "        <div class='row'>" +
                            "            <div class='col s12 m12'>");
            if (_userType == "STUDENT")
            {
                string _marriage = _ctInfo.IsMarriage;//Case When 1=สมรส,2=สมรส(ไม่ได้จดทะเบียน),3=บิดามารดาหย่าร้าง
                string __maritalStatus = _ctInfo.maritalStatus;//1=สมรส,2=สมรส(ไม่ได้จดทะเบียน),3=บิดามารดาหย่าร้าง,4=แยกกันอยู่,5=หม้าย,6=โสด
                string _aliveF = _ctInfo.IsAliveFather;//สถานะบิดา 1=มีชีวิต , 2 = เสียชีวิต
                string _aliveM = _ctInfo.IsAliveMother;//สถานะมารดา 1=มีชีวิต , 2 = เสียชีวิต
                string _liveWithF = _ctInfo.IsLiveFather;//อาศัยอยู่=1,ไม่อาศัย=0
                string _liveWithM = _ctInfo.IsLiveMother;//อาศัยอยู่=1,ไม่อาศัย=0
                string _liveWithOther = _ctInfo.IsLiveOther;//อาศัยอยู่=1,ไม่อาศัย=0
                string _warrantBy = _ctInfo.WarrantBy; //ผู้ค้ำประกัน พ่อ=F,แม่=M,บุคคลอื่น=N
                DataSet _ds = ContractDB.Sp_ectGetStatusReqPasswordParent(__maritalStatus, _aliveF, _aliveM, _liveWithF, _liveWithM, _liveWithOther, _warrantBy);
                int _row = _ds.Tables[0].Rows.Count;
                string _passwordForFather = string.Empty
                     , _passwordForMother = string.Empty;
                if (_row > 0)
                {
                    _passwordForFather = _ds.Tables[0].Rows[0]["passwordForFather"].ToString();
                    _passwordForMother = _ds.Tables[0].Rows[0]["passwordForMother"].ToString();
                }

                if (_passwordForFather == "1" || _passwordForMother == "1")
                {
                    //Internal Contract
                    //_passwordForFather = _ds.Tables[0].Rows[0]["passwordForFather"].ToString();
                    //_passwordForMother = _ds.Tables[0].Rows[0]["passwordForMother"].ToString();
                    //if (_passwordForFather == "1" || _passwordForMother == "1")
                    //{
                    _string.Append("<div class='row center-align'><button type='button' id='submit_confirmRequest' class='waves-effect waves-light btn-large' runat='server'>ขอรับรหัสผ่านของบิดาและมารดา</button></div>");
                    //}
                    //else
                    //{
                    //    _string.Append(@"<div class='row'><span class='th'><h5 class='red-text'><b>*เป็นกรณีที่ต้องทำสัญญาภายนอกระบบ*</b></br></h5> 
                    //                <h5 class='blue-text' style='text-align: left;'>11d. ขอให้นักศึกษาตรวจสอบการบันทึกข้อมูลในระบบ e-profile : ข้อมูลส่วนตัวข้อมูลที่อยู่ และข้อมูลครอบครัว ให้ครบถ้วนทุกรายการ</br></h5>
                    //                <h5 class='blue-text' style='text-align: left;'>22d. ให้ศึกษารายละเอียดเพิ่มเติมจาก<a href='https://econtract.mahidol.ac.th/faqContract.aspx'><u>FAQ การทำสัญญาค้ำประกัน ฯ</u></a>และให้นักศึกษา
                    //                                        กับผู้ค้ำประกันติดต่อทำสัญญาภายนอกระบบ ให้แล้วเสร็จภายในระยะเวลาเดียวกันกับระยะเวลา
                    //                                        การทำสัญญาการเป็นนักศึกษาในระบบนี้ ได้ที่กองกฎหมาย ชั้น 2 สำนักงานอธิการบดี โดยติดต่อ
                    //                                        กำหนดวันและเวลาทำสัญญา รวมทั้งสอบถามข้อมูลผ่าน LINE Official Account กองกฎหมาย 
                    //                                        ม.มหิดล : @csq0251v หรือ โทร. 02 849 6260 ในวันทำการ เวลา 08.30 – 16.30 น.
                    //                                        </h5></span></div>");
                    //}
                }
                else
                {
                    //External Contract 
                    _string.Append(@"<div class='row'><span class='th'><h5 class='red-text'><b>*เป็นกรณีที่ต้องทำสัญญาภายนอกระบบ*</b></br></h5> 
                                <h5 class='blue-text' style='text-align: left;'>1. ขอให้นักศึกษาตรวจสอบการบันทึกข้อมูลในระบบ e-profile : ข้อมูลส่วนตัวข้อมูลที่อยู่ และข้อมูลครอบครัว ให้ครบถ้วนทุกรายการ</br></h5>
                                <h5 class='blue-text' style='text-align: left;'>2. ให้ศึกษารายละเอียดเพิ่มเติมจาก<a href='https://econtract.mahidol.ac.th/faqContract.aspx'><u>FAQ การทำสัญญาค้ำประกัน ฯ</u></a>และให้นักศึกษา
                                                        กับผู้ค้ำประกันติดต่อทำสัญญาภายนอกระบบ ให้แล้วเสร็จภายในระยะเวลาเดียวกันกับระยะเวลา
                                                        การทำสัญญาการเป็นนักศึกษาในระบบนี้ ได้ที่กองกฎหมาย ชั้น 2 สำนักงานอธิการบดี โดยติดต่อ
                                                        กำหนดวันและเวลาทำสัญญา รวมทั้งสอบถามข้อมูลผ่าน LINE Official Account กองกฎหมาย 
                                                        ม.มหิดล : @csq0251v หรือ โทร. 02 849 6260 ในวันทำการ เวลา 08.30 – 16.30 น.
                                                        </h5></span></div>");
                }

            }
            _string.Append("        <h3 class='" + _csstext + " center-align'>" +
                           "        <span class='th'>" + _contractHeaderTh + "</span><span class='en hide'>" + _contractHeaderEn + "</span>" +
                           "        </h3>" +
                           "               <div class='blue-text center-align'>" +
                           "                   <span class='th'>" + _contractDate + "</span>" +
                           "                   <span class='en hide'>" + _contractDate + "</span>" +
                           "               </div>" +
                           "               <div class='center-align'>" + _btnPrintAll + "</div><br />" +
                           "               <div class='divider'></div>" +
                           "        </div>");
            _string.Append("        <div class='col s12 m4'>" +
                           "             <div class='icon-block'>" +
                           "                   <h2 class='center'>" + _iconContract + "<i class='mdi mdi-numeric-1-box blue-text text-darken-3'></i></h2>" +
                           "                   <h5 class='center teal-text'><span class='th'>การทำสัญญานักศึกษา" + _login.FullNameTh + " " + _headContract + "</span><span class='en hide'>Student Contract Finish</span></h5>" +
                           "                   <p class='light'>" + _message + "</p>" +
                           "                   <p class='white-text center'>" +
                                                _btnPrintContract +
                           "                   <span class='on-right red-text'>*</span>" +
                           "                   </p>" +
                           "               </div>" +
                           "           </div>");

            _string.Append("           <div class='col s12 m4'>" +
                            "               <div class='icon-block'>" +
                            "                   <h2 class='center'>" + _iconGuarantee + "<i class='mdi mdi-numeric-2-box blue-text text-darken-3'></i></h2>" +
                            "                   <h5 class='center " + _cssGuarantee + "'>การทำหนังสือแสดงความยินยอมฯ " + _headGuarantee + "</h5>" +
                            "                   <p class='light'>" + _message + "</p>" +
                            "                   <p class='white-text center'>" +
                                                    _btnPrintConsent +
                            "                       <span class='on-right red-text'>*</span>" +
                            "                   </p>" +
                            "               </div>" +
                            "           </div>");


            _string.Append("           <div class='col s12 m4'>" +
                            "               <div class='icon-block'>" +
                            "                   <h2 class='center'>" + _iconWarrant + "<i class='mdi mdi-numeric-3-box blue-text text-darken-3'></i></h2>" +
                            "                   <h5 class='center " + _cssWarrant + "'>การทำสัญญาค้ำประกัน " + _headWarrant + "</h5>" +
                            "                   <p class='light'>" + _message + "</p>" +
                            "                   <p class='white-text center'>" +
                                                    _btnPrintWarrant +
                            "                       <span class='on-right red-text'>*</span>" +
                            "                   </p>" +
                            "               </div>" +
                            "           </div>" +
                            "       </div>" +
                            "   </div>");

            _string.Append("   <div class='red-text'><span class='th'>*ดาวน์โหลดเอกสารได้เมื่อทำสัญญาครบ 3 ฉบับ</span><span class='en hide'>Allow Download Contract at Complete 3 items</span></div>");


            return _string.ToString();
        }

        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: footerbanner
        /// Method : footerbanner
        /// Sample : N/A
        /// </summary>
        public static string FooterBanner()
        {
            StringBuilder _string = new StringBuilder();
            _string.Append(@"<div class='container'>
            <div class='row'>
                <div class='col l9 s12'>
                    <p class='grey-text text-lighten-5'>
                        <span class='yellow-text th'>โปรดให้ความสนใจเป็นพิเศษ</span>
                        <span class='yellow-text en hide'>Important Notice</span>
                        <span class='th'>
                        นักศึกษา บิดา และมารดาจะต้องตรวจสอบข้อมูล และอ่านรายละเอียดเงื่อนไขของสัญญาให้เข้าใจ และเมื่อเห็นว่าข้อมูลถูกต้องครบถ้วน และยอมรับในเงื่อนไขของสัญญาแล้ว นักศึกษา บิดา
                        และมารดาจะต้องดำเนินการตามขั้นตอนของการจัดทำสัญญาในระบบอิเล็กทรอนิกส์เพื่อผูกพันกับมหาวิทยาลัยต่อไปตามลำดับ
                        </span>
                        <span class='en hide'>
                        Student,Parent read all contract, Accept them and follow contract process.
                        </span>
                    </p>
                </div>
                <div class='col l3 s12'>
                    <ul>
                        <li class='lime-text'><span class='th'>กองกฎหมาย ชั้น 2 สำนักงานอธิการบดี  มหาวิทยาลัยมหิดล  ศาลายา</span><span class='en hide'>The 2nd Floor,Department of Legal Affairs, Office of the President, Mahidol University (Salaya Campus)</span></li>
                        <li><a class='white-text' href='#'><span class='th'>โทร : 02-849-6262</span><span class='en hide'>Telephone: 66(0) 2849-6262</span></a></li>
                        <li><a class='white-text' href='#'><span class='th'>LINE Official Account: @csq0251v</span><span class='en hide'>LINE Official Account: @csq0251v</span></a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class='footer-copyright'>
            <div class='container'>");
            _string.Append(@"Copyright ©2015-" + Myconfig._yearEn);
            _string.Append(@" Mahidol University. All rights reserved. Legal Affairs Division/Student Application Section
            </div>
        </div>");
            return _string.ToString();
        }


        /// <summary>
        /// Auther : anussara.wan
        /// Date   : 07-08-2020
        /// Perpose: SetContract
        /// Method : SetContract
        /// Sample : N/A
        /// </summary>
        /// <param name="_dtInput">ข้อมูลสถานะบิดามารดา</param>
        /// <param name="_acaYear">ปีการศึกษา</param>
        /// <param name="_studentId">รหัสนักศึกษา</param>
        /// <param name="_userType">STUDENT,PARENT</param>
        /// <param name="_parentType">F,M</param>
        /// <param name="_docId">รหัสสัญญา</param>
        /// <param name="_username">username</param>
        public static void SetContract(DataTable _dtInput, string _acaYear, string _studentId, string _userType, string _parentType, string _docId, string _username, string _fatherUsername, string _motherUsername)
        {
            //ข้อมูลตามตารางเงื่อนไขสถานภาพชีวิตบิดามารดา
            string _warrantBy
                 , _consentBy
                 , _marriage
                 , _aliveM
                 , _aliveF
                 , _liveWithM
                 , _liveWithF
                 , _liveWithOther
                 , _contactFm;
            _warrantBy = _dtInput.Rows[0]["warrantBy"].ToString();
            _consentBy = _dtInput.Rows[0]["consentBy"].ToString();
            _marriage = _dtInput.Rows[0]["marriage"].ToString();
            _aliveM = _dtInput.Rows[0]["aliveM"].ToString();
            _aliveF = _dtInput.Rows[0]["aliveF"].ToString();
            _liveWithM = _dtInput.Rows[0]["liveWithM"].ToString();
            _liveWithF = _dtInput.Rows[0]["liveWithF"].ToString();
            _liveWithOther = _dtInput.Rows[0]["liveWithOther"].ToString();
            _contactFm = _dtInput.Rows[0]["contactFm"].ToString();
            if (_warrantBy == "N" && _consentBy == "N")
            {
                _fatherUsername = String.Empty;
                _motherUsername = String.Empty;
            }
            //ส่งไปบันทึกในตาราง ectDocMgmt
            ContractDB.SetContract(_userType, _studentId, _acaYear, _warrantBy, _consentBy, _marriage, _aliveM, _aliveF, _liveWithM, _liveWithF, _liveWithOther, _contactFm, _parentType, _username, _docId, _fatherUsername, _motherUsername);
        }

        public static string UImenuStudent(string _studentId)
        {
            StringBuilder _string = new StringBuilder();
            programContract _cStsInfo = new programContract(_studentId); //เช็คว่าหลักสูตรสามารถทำสัญญาได้หรือไม่
            ContractInfo _ctInfo = new ContractInfo(_studentId);//ข้อมูลสัญญานักศึกษา
            string _marriage = _ctInfo.maritalStatus;//1=สมรส,2=สมรส(ไม่ได้จดทะเบียน),3=บิดามารดาหย่าร้าง,4=แยกกันอยู่,5=หม้าย,6=โสด
            string _aliveF = _ctInfo.IsAliveFather;//สถานะบิดา 1=มีชีวิต , 2 = เสียชีวิต
            string _aliveM = _ctInfo.IsAliveMother;//สถานะมารดา 1=มีชีวิต , 2 = เสียชีวิต
            string _liveWithF = _ctInfo.IsLiveFather;//อาศัยอยู่=1,ไม่อาศัย=0
            string _liveWithM = _ctInfo.IsLiveMother;//อาศัยอยู่=1,ไม่อาศัย=0
            string _liveWithOther = _ctInfo.IsLiveOther;//อาศัยอยู่=1,ไม่อาศัย=0
            string _warrantBy = _ctInfo.WarrantBy; //ผู้ค้ำประกัน พ่อ=F,แม่=M,บุคคลอื่น=N


            DataSet _ds = ContractDB.Sp_ectGetStatusReqPasswordParent(_marriage, _aliveF, _aliveM, _liveWithF, _liveWithM, _liveWithOther, _warrantBy);
            int _row = _ds.Tables[0].Rows.Count;
            string _passwordForFather = string.Empty
                 , _passwordForMother = string.Empty;
            if (_cStsInfo.statusMakeContract == "MakeContract")
            {
                _string.Append(@"<div id='menuStd' style='text-align:center;'>");
                _string.Append(@"<div class='row'>
                                <button type='button' id='submit_frmContract' class='waves-effect waves-light btn-large' runat='server'>ทำสัญญาการเป็นนักศึกษา/ดาวน์โหลดสัญญานักศึกษา</button>
                            </div>");
            }
            else
            {
                _string.Append(@"<div id='menuStd' style='text-align:center;'>");
                _string.Append(@"<div class='row'>
                                <span class='th'><h5 class='red-text'>คุณไม่ใช่หลักสูตรที่ต้องทำสัญญาอิเล็กทรอนิกส์ กรุณาตรวจสอบว่าต้องทำสัญญาหรือไม่</h5></span><span class='en hide'><h5 class='red-text'>คุณไม่ใช่หลักสูตรที่ต้องทำสัญญาอิเล็กทรอนิกส์ กรุณาตรวจสอบว่าต้องทำสัญญาหรือไม่</h5></span>
                            </div>");
            }

            if (_row > 0)
            {
                _passwordForFather = _ds.Tables[0].Rows[0]["passwordForFather"].ToString();
                _passwordForMother = _ds.Tables[0].Rows[0]["passwordForMother"].ToString();
                if (_passwordForFather == "1" || _passwordForMother == "1")
                {
                    _string.Append(@"       <div class='row'>
                                <button type='button' id='submit_confirmRequest' class='waves-effect waves-light btn-large' runat='server'>ขอรับรหัสผ่านของบิดาและมารดา</button>
                            </div>");
                }
            }


            _string.Append(@" </div>");
            return _string.ToString();
        }
        public static string UIconfirmRequestPassStd()
        {
            StringBuilder _string = new StringBuilder();
            _string.Append(@"<div id='termReq' style='text-align:center;margin-top:50px;'>
                            <iframe src='termRequest.html' width='60%' height='80%' align='center' ></iframe>
                            <div style='margin-top:10px;text-align:center;'>
                                <button id='btnAcceptRequest' class='btn btn-outline-secondary' type='button' runat='server'>ยืนยัน</button>
                            </div>
                        </div>");
            return _string.ToString();
        }
        public static string UIsetConfirmRequestPassword()
        {

            StringBuilder _string = new StringBuilder();
            Login _login = new Login("STUDENT");
            StudentInfo _stdInfo = new StudentInfo(_login.StudentCode);
            if (_stdInfo.CheckConfirmStd != "1")
            {
                //Insert Confirm Log 
                int _result = ContractDB.setConfirmRequestPassword(_login.StudentCode, _login.StudentId, _stdInfo.AcaYear, _login.Username);
                if (_result == -1)
                {
                    _string.Append("<h6 style='text-align:center;color:red;'>ไม่สามารถขอรหัสผ่านได้ กรุณาติดต่อเจ้าหน้าที่</h6>");
                }
                else
                {
                    _string.Append(@"<div style='margin-top:10px;text-align:center;'>
                                <button id='btnPrintPassword' class='btn btn-outline-secondary' type='button' runat='server'>ดาวน์โหลดรหัสผ่าน</button>
                         </div>
                      ");
                }
            }
            else
            {
                _string.Append(@"<div style='margin-top:10px;text-align:center;'>
                                <button id='btnPrintPassword' class='btn btn-outline-secondary' type='button' runat='server'>ดาวน์โหลดรหัสผ่าน</button>
                         </div>
                      ");
            }
            return _string.ToString();
        }
        public static string UIsetAcceptedRequestPassword()
        {
            StringBuilder _string = new StringBuilder();
            DataSet _ds = new DataSet();
            Login _login = new Login("STUDENT");
            StudentInfo _stdInfo = new StudentInfo(_login.StudentCode);
            ParentInfo _parentMInfo = new ParentInfo(_login.StudentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_login.StudentId, "F");
            ContractInfo _contractInfo = new ContractInfo(_login.StudentId);

            if (_contractInfo.IsAliveFather == "1" && _parentFInfo.IdCard == null && (_parentFInfo.enFirstName == null || _parentFInfo.enFirstName == "" || _parentFInfo.enLastName == null || _parentFInfo.enLastName == ""))
            {
                //idcard Father is empty
                _string.Append("<p>ไม่สามารถขอรหัสผ่านได้ เนื่องจากไม่พบรหัสบัตรประจำตัวประชาชนของบิดา/ชื่อ-นามสกุลภาษาอังกฤษ สามารถกรอกรหัสบัตรประชาชนของบิดาได้ที่<a href='https://smartedu.mahidol.ac.th'>ระบบ e-Profile</a></p>");
            }
            if (_contractInfo.IsAliveFather == "1" && _parentMInfo.IdCard == null && (_parentMInfo.enFirstName == null || _parentMInfo.enFirstName == "" || _parentMInfo.enLastName == null || _parentMInfo.enLastName == ""))
            {
                //idcard Mother is empty
                _string.Append("<p>ไม่สามารถขอรหัสผ่านได้ เนื่องจากไม่พบรหัสบัตรประจำตัวประชาชนของมารดา/ชื่อ-นามสกุลภาษาอังกฤษ สามารถกรอกรหัสบัตรประชาชนของมารดาได้ที่<a href='https://smartedu.mahidol.ac.th'>ระบบ e-Profile</a></p>");
            }
            else
            {
                //Check Confirm Log  
                int _checkAcaYearSTD = Convert.ToInt32(_stdInfo.AcaYear);
                int _checkConfirmLog = Convert.ToInt32(_stdInfo.CheckConfirmStd);
                if (_checkConfirmLog <= 0 && _checkAcaYearSTD >= 2562)
                {
                    _string.Append(UIconfirmRequestPassStd());
                }
                else
                {
                    _string.Append(UIsetConfirmRequestPassword());
                }

            }
            return _string.ToString();
        }

        /// <summary>
        /// Auther : anussara.wan
        /// Date   : 2019-08-19
        /// Perpose: เพื่อแสดงหน้า confirm parent
        /// Method : UiConfirmParent
        /// Sample : N/A
        /// </summary>
        public static string UiConfirmParent(string _userType, ContractInfo _ctInfo, string _username, string _parentType, string _studentId, string _studentCode)
        {
            StringBuilder _string = new StringBuilder();
            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            string _stdNameTh, _stdNameEn, _stdStatusEn, _stdStatusTh;
            string _facultyNameTh, _facultyNameEn, _pCode;

            _stdNameEn = Myconfig.CvEmpty(_stdInfo.StdNameEn, " - ");
            _stdNameTh = Myconfig.CvEmpty(_stdInfo.StdNameTh, " - ");
            _facultyNameTh = Myconfig.CvEmpty(_stdInfo.FacultyNameTh, " - ");
            _facultyNameEn = Myconfig.CvEmpty(_stdInfo.FacultyNameEn, " - ");
            _pCode = Myconfig.CvEmpty(_stdInfo.PCode, " - ");
            _stdStatusEn = Myconfig.CvEmpty(_stdInfo.StatusEn, " - ");
            _stdStatusTh = Myconfig.CvEmpty(_stdInfo.StatusTh, " - ");
            _string.Append(@"<div class='card-panel grey lighten-5'>
                                <div class='grey-text text-darken-4'>
                                    <div class='section'>
                                        <p>
                                        <input class='chkStay' name='chkStay' type='checkbox' id='chkConP' value='1' />
                                        <label for='chkConP'>
                                        <span class='th'></span><span class='en hide'></span>
                                        </label>
                                            ข้าพเจ้าขอให้สัตยาบันว่า ข้าพเจ้าได้มอบฉันทะให้  <b> " + _stdNameTh + @"</b> นักศึกษา <b> " + _facultyNameTh + @"</b> ขอรับชื่อผู้ใช้และรหัสผ่านสำหรับการทำสัญญาค้ำประกัน และหนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม แทนข้าพเจ้าจริง
                                            โดยข้าพเจ้าได้รับทราบนโยบาย ระเบียบปฏิบัติการจัดทำสัญญาระบบอิเล็กทรอนิกส์กับทางมหาวิทยาลัยมหิดลแล้ว และขอยอมรับผิดชอบในการกระทำของผู้รับมอบฉันทะโดยถือเสมือนว่าเป็นการกระทำของข้าพเจ้าเองทุกประการ</br></br>
                                        </p>
                                    </div>");
            _string.Append("<span class='waves-effect waves-light btn-large green col s12  accent-12 btnConfirmParent' >ทำหนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรมและ/หรือสัญญาค้ำประกัน</span>");
            _string.Append(@"</div></div>");
            return _string.ToString();
        }

        /// <summary>
        /// Auther : anussara.wan
        /// Date   : 2020-08-07
        /// Perpose: ParallaxbannerFAQ
        /// Method : ParallaxbannerFAQ
        /// Sample : N/A
        /// </summary>
        public static string ParallaxbannerFAQ()
        {
            string _txtDateOpen = "";

            _txtDateOpen = "<span class='th' style='font-size:16pt;font-family: courier;font-weight:bold;color:#0035AD;'>FAQ คำถามที่พบบ่อยเกี่ยวกับการทำสัญญาการเป็นนักศึกษา</span>";



            StringBuilder _string = new StringBuilder();
            _string.Append(@"<div id='index-bannerx' class='parallax-container' style='height: 160px;'>
        <div class='section no-pad-bot '>
            <div class='container'>
                <div class='row'>
                    <div class='col s12 m12 l12'><img src='http://www.student.mahidol.ac.th/portal/images/logo.png' alt='' class='responsive-img' /></div>
                    <div class='col s12 m8 l8 hide-on-small-only'>");
            _string.Append(@"<div class=''><h5 class='light'>" + _txtDateOpen + "</h5></div>");
            _string.Append(@"</div>
                    <div class='col s12 m4 l4'>
                        <div class='right-align'><img src='Images/contract_string.png' alt='' class='responsive-img' /></div>
                    </div>
                </div>
            </div>
        <div class='parallax'>
            <img src='images/bgs.png' alt='#' />
        </div>
    </div>");
            return _string.ToString();
        }
        /// <summary>
        /// Auther : anussara.wan
        /// Date   : 2020-08-07
        /// Perpose: ParallaxbannerHelp
        /// Method : ParallaxbannerHelp
        /// Sample : N/A
        /// </summary>
        public static string ParallaxbannerHelp()
        {
            string _txtDateOpen = "";

            _txtDateOpen = "<span class='th' style='font-size:16pt;font-family: courier;font-weight:bold;color:#0035AD;'>Help คู่มือการใช้งานระบบการทำสัญญาการเป็นนักศึกษา</span>";



            StringBuilder _string = new StringBuilder();
            _string.Append(@"<div id='index-bannerx' class='parallax-container' style='height: 160px;'>
        <div class='section no-pad-bot '>
            <div class='container'>
                <div class='row'>
                    <div class='col s12 m12 l12'><img src='http://www.student.mahidol.ac.th/portal/images/logo.png' alt='' class='responsive-img' /></div>
                    <div class='col s12 m8 l8 hide-on-small-only'>");
            _string.Append(@"<div class=''><h5 class='light'>" + _txtDateOpen + "</h5></div>");
            _string.Append(@"</div>
                    <div class='col s12 m4 l4'>
                        <div class='right-align'><img src='Images/contract_string.png' alt='' class='responsive-img' /></div>
                    </div>
                </div>
            </div>
        <div class='parallax'>
            <img src='images/bgs.png' alt='#' />
        </div>
    </div>");
            return _string.ToString();
        }
    }
}