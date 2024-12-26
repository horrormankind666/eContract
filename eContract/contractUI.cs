using System;
using System.Data;
using System.Text;

namespace eContract {
    public class ContractUI {
        /*
        Auther  : Odd.Nopparat
        Date    : 20-11-2015
        Perpose : UiStudentProfile
        Method  : UiStudentProfile
        Sample  : N/A
        */
        public static string UiStudentProfile(string studentCode) {
            StringBuilder html = new StringBuilder();
            StudentInfo stdInfo = new StudentInfo(studentCode);
            //string programCode = Myconfig.CvEmpty(stdInfo.ProgramCode, " - ");
            //string quotaCode = Myconfig.CvEmpty(stdInfo.QuotaCode, " - ");
            //string admissionType = Myconfig.CvEmpty(stdInfo.AdmissionType, " - "); 
            //string studentCode = Myconfig.CvEmpty(_stdInfo.StudentCode, " - ");
            string stdNameTH = Myconfig.CvEmpty(stdInfo.StdNameTH, " - ");
            string stdNameEN = Myconfig.CvEmpty(stdInfo.StdNameEN, " - ");
            string stdStatusNameTH = Myconfig.CvEmpty(stdInfo.StatusNameTH, " - ");
            string stdStatusNameEN = Myconfig.CvEmpty(stdInfo.StatusNameEN, " - ");
            //string urlPic = Myconfig.CvEmpty(stdInfo.UrlPic, " - ");
            string facultyCode = Myconfig.CvEmpty(stdInfo.FacultyCode, " - ");
            string facultyNameTH = Myconfig.CvEmpty(stdInfo.FacultyNameTH, " - ");
            string facultyNameEN = Myconfig.CvEmpty(stdInfo.FacultyNameEN, " - ");
            //string pCode = Myconfig.CvEmpty(stdInfo.PCode, " - ");
            string programNameTH = Myconfig.CvEmpty(stdInfo.ProgramNameTH, " - ");
            string programNameEN = Myconfig.CvEmpty(stdInfo.ProgramNameEN, " - ");
            string urlPicInternet = stdInfo.UrlPicInternet;            

            html.Append(@"
                <div class='row'>
                    <div class='col m2 l2 hide-on-med-and-down'>
                        <img src = '" + urlPicInternet + @"' alt='' class='square responsive-img z-depth-1' onError='this.onerror=null;this.src='nopic.png';' />
                    </div>
                    <div class='col l2 m2 hide-on-med-and-down'>
                        <ul class='pink-text'>
                            <li>
                                <span class='th'>รหัสนักศึกษา</span>
                                <span class='en hide'>StudentID</span>
                            </li>
                            <li>
                                <span class='th'>ชื่อ-นามสกุล</span>
                                <span class='en hide'>Name-Lastname</span>
                            </li>
                            <li>
                                <span class='th'>คณะ</span>
                                <span class='en hide'>Faculty</span>
                            </li>
                            <li>
                                <span class='th'>หลักสูตร</span>
                                <span class='en hide'>Program</span>
                            </li>
                            <li>
                                <span class='th'>สถานะ</span>
                                <span class='en hide'>Status</span>
                            </li>
                        </ul>
                    </div>
                    <div class='col l8 m8 s12'>
                        <ul class='blue-text text-darken-4'>
                            <li>" + studentCode + @"</li>
                            <li>
                                <span class='th'>" + stdNameTH + @"</span>
                            </li>
                            <li>
                                <span class='en hide'>" + stdNameEN + @"</span>
                            </li>
                            <li>
                                <span class='th'>" + facultyNameTH + @"</span>
                                <span class='en hide'>" + facultyNameEN + @"</span>
                                <span>&nbsp;&nbsp;( " + facultyCode + @" )</span>
                            </li>
                            <li>
                                <span class='th'>" + programNameTH + @"</span>
                                <span class='en hide'>" + programNameEN + @"</span>
                            </li>
                            <li>
                                <span class='th'>" + stdStatusNameTH + @"</span>
                                <span class='en hide'>" + stdStatusNameEN + @"</span>
                            </li>
                        </ul>
                    </div>
                </div>
            ");

            return html.ToString();
        }

        /*
        Auther  : Odd.Nopparat
        Date    : 20-11-2015
        Perpose : ข้อมูล บิดามารดา
        Method  : parentProfile
        Sample  : N/A
        */
        public static string UiParentProfile(
            string studentID,
            string parentType,
            string studentCode
        ) {
            StringBuilder html = new StringBuilder();
            StudentInfo stdInfo = new StudentInfo(studentCode);
            ParentInfo parentInfo = new ParentInfo(studentID, parentType);
            string idCard = Myconfig.CvEmpty(parentInfo.IDCard, " - ");
            string fullNameTH = Myconfig.CvEmpty(parentInfo.FullNameTH, " - ");
            string fullNameEN = Myconfig.CvEmpty(parentInfo.FullNameEN, " - ");
            string position = Myconfig.CvEmpty(parentInfo.Position, " - ");
            string stdNameTH = Myconfig.CvEmpty(stdInfo.StdNameTH, " - ");
            string stdNameEN = Myconfig.CvEmpty(stdInfo.StdNameEN, " - ");
            string stdStatusNameTH = Myconfig.CvEmpty(stdInfo.StatusNameTH, " - ");
            string stdStatusNameEN = Myconfig.CvEmpty(stdInfo.StatusNameEN, " - ");
            
            html.Append(@"
                <div class='row'>
                    <div class='col m2 l2 hide-on-med-and-down'>
                        <img src = 'images/nopic.png' alt='' class='square responsive-img z-depth-1' />
                    </div>
                    <div class='col l2 m2 hide-on-med-and-down'>
                        <ul class='pink-text'>
                            <li>
                                <span class='th'>เลข ปชช.</span>
                                <span class='en hide'>Student-ID</span>
                            </li>
                            <li>
                                <span class='th'>ชื่อภาษาไทย</span>
                                <span class='en hide'>Thai-Name</span>
                            </li>
                            <li>
                                <span class='th'>ชื่ออังกฤษ</span>
                                <span class='en hide'>Eng-Name</span>
                            </li>
                            <li>
                                <span class='th'>อาชีพ</span>
                                <span class='en hide'>Faculty</span>
                            </li>
                            <li>
                                <span class='th'>นักศึกษา</span>
                                <span class='en hide'>Student</span>
                            </li>
                            <li>
                                <span class='th'>สถานะ</span>
                                <span class='en hide'>Status</span>
                            </li>
                        </ul>
                    </div>
                    <div class='col l8 m8 s12'>
                        <ul class='blue-text text-darken-4'>
                            <li>" + idCard + @"</li>
                            <li>
                                <span>" + fullNameTH + @"</span>
                            </li>
                            <li>
                                <span>" + fullNameEN + @"</span>
                            </li>
                            </li>
                            <li>
                                <span class='th'>" + position + @"</span>
                                <span class='en hide'>" + position + @"</span>
                            </li>
                            <li>
                                <span class='th'>" + stdNameTH + @"</span>
                                <span class='en hide'>" + stdNameEN + @"</span>
                            </li>
                            <li>
                                <span class='th'>" + stdStatusNameTH + @"</span>
                                <span class='en hide'>" + stdStatusNameEN + @"</span>
                                <span class=''></span>
                            </li>
                        </ul>
                    </div>
                </div>
            ");

            return html.ToString();
        }

        /*
        Auther          : Odd.Nopparat
        Date            : 20-11-2015
        Change Auther   : korakot.pim
        Change Date     : 07-08-2020
        Detail Change   : เพิ่มสถานภาพของบิดามารดา หย่าร้าง แยกกันอยู่ โสด
        Perpose         : UiParentCheckingStatus
        Method          : UiParentCheckingStatus
        Sample          : N/A
        */
        public static string UiParentCheckingStatus(string studentID) {
            StringBuilder html = new StringBuilder();
            DataSet ds = ContractDB.Sp_ectStatusInfo(studentID);
            //const string checked = "checked = 'checked'";
            //string register = string.Empty;
            //string unregister = string.Empty;
            //string divorced = string.Empty;
            //string fatherDied = string.Empty;
            //string motherDied = string.Empty;            
            //string fatherAlive = ds.Tables[0].Rows[0]["fatherSts"].ToString();
            //string motherAlive = ds.Tables[0].Rows[0]["motherSts"].ToString();
            //string registerStatus = ds.Tables[0].Rows[0]["marriedSts"].ToString();
            string stdStatus = ds.Tables[0].Rows[0]["studentStatus"].ToString();
            string stdStatusNameTH = ds.Tables[0].Rows[0]["stsNameTh"].ToString();
            string stdStatusNameEN = ds.Tables[0].Rows[0]["stsNameEn"].ToString();

            //สถานะกำลังศึกษาอยู่ไหม
            if (stdStatus == "000") {
                //20200807 anussara.wan เนื่องจากอนาคตจะมีการยกเลิกการกรอกสถานภาพจาก e-Profile จึงไม่เช็ค defalut แล้ว
                /*
                //สถานภาพที่เลือกมาจากระบบ e-Profile
                switch (registerStatus) {
                    //สมรสจดทะเบียน
                    case "1":
                        register = checked;
                        break;
                    //สมรสไม่จดทะเบียน
                    case "2":
                        unregister = checked;
                        break;
                    //หย่าร้าง
                    case "3":
                        divorced = checked;
                        break;
                }
                */

                /*
                //father alive
                switch (fatherAlive) {
                    case "Y":
                        fatherAlive = checked;
                        break;
                    case "N":
                        fatherDied = checked;
                        break;
                    default:
                        fatherAlive = checked;
                        break;
                }
                */

                /*
                //mother alive
                switch (motherAlive) {
                    case "Y":
                        motherAlive = checked;
                        break;
                    case "N":
                        motherDied = checked;
                        break;
                    default:
                        motherAlive = _checked;
                        break;
                }
                */

                html.Append(@"
                    <ul class='collection'>
                        <li class='collection-item avatar'>
                            <i class='mdi mdi-human-male-female circle green'></i>
                            <span class='title'>
                                <span class='th'>สถานภาพสมรสบิดามารดา</span>
                                <span class='en hide'>Parent Status</span>
                            </span>
                            <p>" +
                                //สมรส จดทะเบียน
                                @"
                                <input class='rdoMarried' name='rdoMarried' type='radio' id='rdoRegister' title='สมรส(จดทะเบียน)' value='1' />
                                <label for='rdoRegister'>
                                    <span class='th'>จดทะเบียน</span>
                                    <span class='en hide'>Registered</span>
                                </label>" +
                                //สมรส ไม่จดทะเบียน
                                @"
                                <input class='rdoMarried' name='rdoMarried' type='radio' title='สมรส(ไม่จดทะเบียน)' id='rdoNotregister' value='2' />
                                <label for='rdoNotregister'>
                                    <span class='th'>ไม่จดทะเบียน</span>
                                    <span class='en hide'>Not Registered</span>
                                </label>" +
                                //หย่าร้าง
                                @"
                                <input class='rdoMarried' name='rdoMarried' type='radio' title='หย่าร้าง(จดทะเบียนหย่า)' id='rdoDivorced' value='3' />
                                <label for='rdoDivorced'>
                                    <span class='th'>หย่าร้าง</span>
                                    <span class='en hide'>Divorced</span>
                                </label>" +
                                //แยกกันอยู่
                                @"
                                <input class='rdoMarried' name='rdoMarried' type='radio' title='แยกกันอยู่(จดทะเบียนแต่แยกกันอยู่)' id='rdoSeparated' value='4' />
                                <label for='rdoSeparated'>
                                    <span class='th'>แยกกันอยู่(จดทะเบียนแต่แยกกันอยู่)</span>
                                    <span class='en hide'>Separated</span>
                                </label>" +
                                //หม้าย
                                @"
                                <input class='rdoMarried' name='rdoMarried' type='radio' title='หม้าย(จดทะเบียนแต่ฝ่ายใดฝ่ายหนึ่งเสียชีวิต)' id='rdoWidowed' value='5' />
                                <label for='rdoWidowed'>
                                    <span class='th'>หม้าย(จดทะเบียนแต่ฝ่ายใดฝ่ายหนึ่งเสียชีวิต)</span>
                                    <span class='en hide'>Widowed</span>
                                </label>" +
                                //โสด
                                @"
                                <input class='rdoMarried' name='rdoMarried' type='radio' title='โสด(ไม่จดทะเบียนและแยกกันอยู่)' id='rdoSingle' value='6' />
                                <label for='rdoSingle'>
                                    <span class='th'>โสด(ไม่จดทะเบียนและแยกกันอยู่)</span>
                                    <span class='en hide'>Single</span>
                                </label>
                            </p>
                        </li>
                        <li class='collection-item avatar'>
                            <i class='mdi mdi-gender-male circle blue'></i>
                            <span class='title'>
                                <span class='th'>บิดามีชีวิตอยู่หรือไม่</span>
                                <span class='en hide'>Father Status</span>
                            </span>
                            <p>
                                <input class='rdoFatherSts' name='rdoFatherSts' type='radio' id='rdoFatherStsYes'  value='1' />
                                <label for='rdoFatherStsYes'>
                                    <span class='th'>มีชีวิตอยู่</span>
                                    <span class='en hide'>Yes</span>
                                </label>;
                                <input class='rdoFatherSts' name='rdoFatherSts' type='radio' id='rdoFatherStsNo' value='2' />
                                <label for='rdoFatherStsNo'>
                                    <span class='th'>เสียชีวิตแล้ว</span>
                                    <span class='en hide'>No</span>
                                </label>
                            </p>
                        </li>
                        <li class='collection-item avatar'>
                            <i class='mdi mdi-gender-female circle pink'></i>
                            <span class='title'>
                                <span class='th'>มารดามีชีวิตอยู่หรือไม่</span>
                                <span class='en hide'>Mother Status</span>
                            </span>
                            <p>
                                <input class='rdoMotherSts' name='rdoMotherSts' type='radio' id='rdoMotherStsYes' value='1' />
                                <label for='rdoMotherStsYes'>
                                    <span class='th'>มีชีวิตอยู่</span>
                                    <span class='en hide'>Yes</span>
                                </label>
                                <input class='rdoMotherSts' name='rdoMotherSts' type='radio' id='rdoMotherStsNo' value='2' />
                                <label for='rdoMotherStsNo'>
                                    <span class='th'>เสียชีวิตแล้ว</span>
                                    <span class='en hide'>No</span>
                                </label>
                            </p>
                        </li>" +
                        /*
                        <li class='collection-item avatar panelStayWith' style='display:none;'>
                            <i class='mdi mdi-home circle amber'></i>
                            <span class='title'>
                                <span class='th'>นักศึกษาอาศัยอยู่กับ</span>
                                <span class='en hide'>Stay with</span>
                            </span>
                            <p>
                                <input class='chkStay' name='chkStay' type='checkbox' id='chkStayF' value='1' />
                                <label for='chkStayF'>
                                    <span class='th'>บิดา</span>
                                    <span class='en hide'>Father</span>
                                </label>
                                <input class='chkStay' name='chkStay' type='checkbox' id='chkStayM' value='1' />
                                <label for='chkStayM'>
                                    <span class='th'>มารดา</span>
                                    <span class='en hide'>Mother</span>
                                </label>
                                <input class='chkStay' name='chkStay' type='checkbox' id='chkStayO' value='1' />
                                <label for='chkStayO'>
                                    <span class='th'>บุคคลอื่น</span>
                                    <span class='en hide'>Other</span>
                                </label>
                            </p>
                        </li>
                        */
                        @"
                        <li class='collection-item avatar grey lighten-2'>
                            <i class='mdi mdi-clipboard-check circle blue-grey'></i>
                            <span class='title'>
                                <span class='th'>สรุปเงื่อนไข</span>
                                <span class='en hide'>Summary Accept</span>
                            </span>
                            <p>
                                <span class='green-text'>ค้ำประกันโดย : </span><span class='blue-text spWarrant'></span><br />
                                <span class='green-text'>ยินยอมโดย : </span><span class='blue-text spConsent'></span><br /><br />                                       
                            </p>
                            <p class='panelContactLost'>" +
                                /*
                                <span class='title'>
                                    <span class='th red-text'>
                                        สถานะติดต่อ :&nbsp; 
                                        <input class='chkStay' name='chkStay' type='checkbox' id='chkStayLost' value='1' />
                                        <label for='chkStayLost'>
                                            <span class='th red-text'>ไม่สามารถติดต่อ ผู้ค้ำประกันได้</span>
                                            <span class='en hide red-text'>Family not found</span>
                                        </label>
                                    </span>
                                */
                            @"
                            </p>" +
                            //เพิ่มการแสดงสถานะให้ติดต่อทำสัญญานอกระบบที่กองกฎหมาย
                            @" 
                            <p class='panelContactTolaw'>
                                <span class='th red-text'>ให้นักศึกษาดำเนินการทำสัญญาการเป็นนักศึกษาผ่านระบบ e-Contract ให้เรียบร้อย ทั้งนี้ การทำหนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม และสัญญาค้ำประกันในระบบ e-Contract เป็นสิทธิของบิดาและมารดาโดยชอบธรรมด้วยกฎหมายเท่านั้น ระบบจะไม่สามารถออกรหัสผ่านให้แก่ บุคคลอื่น ซึ่งไม่ได้รับอนุญาตสิทธิ โปรดติดต่อกองกฎหมาย สำนักงานอธิการบดี เพื่อทำสัญญาการเป็นนักศึกษานอกระบบ e-Contract ต่อไป</span>
                            </p>
                        </li>
                    </ul>
                    <span class='waves-effect waves-light btn-large green col s12  accent-12 btnConfirmInfo' >ยืนยันข้อมูล</span>
                ");
            }
            else {
                //กรณีที่นักศึกษาลาออกไปแล้ว
                html.Append(@"
                    <ul class='collection'>
                        <li class='collection-item avatar'>
                            <span class='title'>
                                <span class='th red-text'>" + stdStatusNameTH + @"</span>
                                <span class='en hide red-text'>" + stdStatusNameEN + @"</span>
                            </span>
                        </li>
                    </ul>
                ");
            }

            return html.ToString();
        }

        /*
        Auther  : Odd.Nopparat
        Date    : 20-11-2015
        Perpose : parallaxbanner
        Method  : parallaxbanner
        Sample  : N/A
        */
        public static string Parallaxbanner(string acaYear1) {
            StringBuilder html = new StringBuilder();
            string txtDateOpen = "";
            DataSet ds = ContractDB.Sp_ectGetDateEvent(acaYear1);
            //int row = ds.Tables[0].Rows.Count;
            string startDate;
            string endDate;
            string sTime;
            string eTime;
            string acaYear;
            string isBetween;
            string acaYearEN;
            string startDateEN;
            string endDateEN;

            foreach (DataRow dr in ds.Tables[0].Rows) {
                startDate = dr["cStartDate"].ToString();
                endDate = dr["cEndDate"].ToString();
                startDateEN = dr["enStartDate"].ToString();
                endDateEN = dr["enEndDate"].ToString();
                acaYear = dr["acaYear"].ToString();
                isBetween = dr["isBetween"].ToString();
                acaYearEN = dr["enAcaYear"].ToString();
                sTime = dr["cStartTime"].ToString();
                eTime = dr["cEndTime"].ToString();

                if (isBetween == "1") {
                    txtDateOpen = (@"
                        <span class='th' style='font-size:15pt;font-weight:bold;color:green;'>เปิดทำสัญญา สำหรับนักศึกษาที่เข้าศึกษาปี " + acaYear + " <br />ตั้งแต่วันที่ " + startDate + " เวลา " + sTime +" น. ถึงวันที่ " + endDate + " เวลา " + eTime + " น. " + @"</span>
                        <span class='en hide' style='font-size:12pt;font-weight:bold;color:blue;'>Sign e-Contract. A Students who admission for academic year " + acaYearEN + "(BE " + acaYear + ")<br />the system wil be available from " + startDateEN + " to " + endDateEN + @"  </span>
                    ");
                }
                else {
                    txtDateOpen = (@"
                        <span class='th' style='font-size:13pt;font-weight:bold;color:red;'>ยังไม่เปิดให้บริการ หรือ ปิดชั่วคราว สำหรับนักศึกษาที่เข้าศึกษาปี " + acaYear + " <br />เปิด วันที่ " + startDate + " เวลา " + sTime + " น. ถึงวันที่ " + endDate + " เวลา " + eTime + " น. " + @"</span>
                        <span class='en hide' style='font-size:12pt;font-weight:bold;color:red;'>The System out of service. A Students who admission for academic year " + acaYearEN + "(BE " + acaYear + ") </br>the system wil be available from " + startDateEN + " to " + endDateEN + @"  </span>
                    ");
                }
            }

            html.Append(@"
                <div id='index-bannerx' class='parallax-container' style='height: 160px;'>
                    <div class='section no-pad-bot'>
                        <div class='container'>
                            <div class='row'>
                                <div class='col s12 m12 l12'>
                                    <img src='Images/logoFullName.png' alt='' class='responsive-img' />
                                </div>
                                <div class='col s12 m8 l8 hide-on-small-only'>
                                    <div class=''>
                                        <h5 class='light'>" + txtDateOpen + @"</h5>
                                    </div>
                                </div>
                                <div class='col s12 m4 l4'>
                                    <div class='right-align'>
                                        <img src='Images/contract_string.png' alt='' class='responsive-img' />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class='parallax'>
                            <img src='images/bgs.png' alt='#' />
                        </div>
                    </div>
                </div>
            ");

            return html.ToString();
        }

        /*
        Auther  : Odd.Nopparat
        Date    : 20-11-2015
        Perpose : parallaxbanner
        Method  : parallaxbanner
        Sample  : N/A
        */
        public static string UiLoginForm() {
            StringBuilder html = new StringBuilder();

            html.Append(@"
                <div class='row'>
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
                    </div>" +
                    /*
                    <div class='card-reveal light-green lighten-5'>
                        <span class='card-title grey-text text-darken-4'>
                            <span class='th'>สำหรับนักศึกษา</span>
                            <span class='en hide'>For Student</span>
                            <i class='mdi mdi-close right'></i>
                        </span>
                        <div class='row'>
                            <div class='input-field'>
                                <i class='mdi mdi-account-circle prefix'></i>
                                <input placeholder='u59xxxxx' id='username' name='username' type='text' class='validate' maxlength='30' value='' />
                                <label for='username'>
                                    <span class='th'>ชื่อผู้ใช้งาน</span>
                                    <span class='en hide'>Username</span>
                                </label>
                            </div>
                        </div>
                        <div class='row'>
                            <div class='input-field'>
                                <i class='mdi mdi-multiplication prefix'></i>
                                <input placeholder='internet account' id='studentpassword' name='studentpassword' type='password' class='validate' maxlength='50' value='' />
                                <label for='studentpassword'>
                                    <span class='th'>รหัสผ่าน</span>
                                    <span class='en hide'>Password</span>
                                </label>
                            </div>
                        </div>
                        <div>
                            <p class='teal-text'>
                                <i class='mdi mdi-message-alert on-left'></i>
                                <span class='blue-text th'>ลืมรหัสผ่าน โทร 0-2849-6022</span>
                                <span class='en hide'>Forgot password Call. 66(0) 2849-6022</span>
                            </p>
                            <a href='https://myinternet.mahidol.ac.th/'>
                                <i class='mdi mdi-undo-variant'></i>
                                <span class='pink-text th'>สมัครใช้งาน Internet Account หรือ เปลี่ยนรหัสผ่าน</span>
                                <span class='pink-text en hide'>Register Internet Account or Change password</span>
                            </a>
                        </div>
                        <div class='card-action center-align'>
                            <a href='javascript:void(0);' class='activator btn indigo darken-4 th student-login'>เข้าระบบ</a>
                            <a href='javascript:void(0);' class='activator btn indigo darken-4 en hide student-login'>Log in</a>
                        </div>
                    </div>
                    */
                    @"
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
                                    <i class='mdi mdi-close right'></i>
                                </span>
                                <div class='row'>
                                    <div class='input-field'>
                                        <i class='mdi mdi-account-circle prefix'></i>
                                        <input placeholder='' id='citizenid' name='userid' type='text' class='validate' maxlength='50' value='' />
                                        <label for='citizenid'>
                                            <span class='th'>รหัสผู้ใช้</span>
                                            <span class='en hide'>Username</span>
                                        </label>
                                    </div>
                                </div>
                                <div class='row'>
                                    <div class='input-field'>
                                        <i class='mdi mdi-multiplication prefix'></i>
                                        <input placeholder='' id='parentpassword' name='parentpassword' type='password' class='validate' maxlength='30' value='' />
                                        <label for='parentpassword'>
                                            <span class='th'>รหัสผ่าน</span>
                                            <span class='en hide'>Password</span>
                                        </label>
                                    </div>
                                </div>
                                <div>
                                    <p class='teal-text'>
                                        <i class='mdi mdi-message-alert on-left'></i>
                                        <span class='blue-text th'>ลืมรหัสผ่าน โทร 0-2849-6260</span>
                                        <span class='en hide'>Forgot password Call. 0(66)2849-6260</span>
                                    </p>
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
                </div>
            ");

            return html.ToString();
        }

        /*
        Auther  : Odd.Nopparat
        Date    : 20-11-2015
        Perpose : reLoginForm
        Method  : reLoginForm
        Sample  : N/A
        */
        public static string UiReLoginForm(
            string userType,
            ContractInfo ctInfo,
            string username,
            string parentType
        ) {
            StringBuilder html = new StringBuilder();
            string lblUsernameTH;
            string lblUserNameEN;
            string lblPasswordTH;
            string lblPasswordEN;
            string warrantBy = ctInfo.WarrantBy;
            string consentBy = ctInfo.ConsentBy;
            string txtTitle = "ใส่รหัสอีกครั้งเพื่อยืนยันการทำสัญญา";

            if (warrantBy == parentType) {
                txtTitle += " ค้ำประกัน";
            }
            else if (consentBy == parentType) {
                txtTitle += " ยินยอมคู่สมรส";
            }

            if (userType == "STUDENT") {
                lblUsernameTH = "รหัสนักศึกษา";
                lblUserNameEN = "STUDENT ID";
                //lblPasswordTH = "รหัสผ่าน (Internet Account)";
                //lblPasswordEN = "INTERNET ACCOUNT";

                html.Append(@"
                    <div class='card-panel blue lighten-5'>
                        <div class='row'>
                            <h5 class='red-text'>
                                <span class='th'>" + txtTitle + @"</span>
                                <span class='en hide'>Re-Login for sign contract</span>
                            </h5>
                            <div class='col s12 m8 l8'>
                                <div class='input-field'>
                                    <i class='mdi mdi-account-circle prefix'></i>
                                    <input placeholder='' id='username' name='username' type='text' class='validate valid' maxlength='8' value='" + username + @"' />
                                    <label for='username' class='active'>
                                        <span class='th'>" + lblUsernameTH + @"</span>
                                        <span class='en hide'>" + lblUserNameEN + @"</span>
                                    </label>
                                </div>
                            </div>" +
                            /*
                            <div class='col s12 m4 l4'>
                                <div class='input-field'>
                                    <i class='mdi mdi-multiplication prefix'></i>
                                    <input placeholder='' id='password' name='password' type='password' class='validate' maxlength='50' value='' />
                                    <label for='password'>
                                        <span class='th'>" + lblPasswordTH + @"</span>
                                        <span class='en hide'>" + lblPasswordEN + @"</span>
                                    </label>
                                </div>
                            </div>
                            */
                            @"
                            <div class='col s12 m4 l4'>
                                <div class='center'>
                                    <a href='#!' class='waves-effect waves-light btn-large blue accent-4 btnReLogin'>
                                        <i class='mdi mdi-checkbox-marked-circle-outline'></i>
                                        <span class='th'>ทำสัญญา</span>
                                        <span class='en hide'>Sign Contract</span>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                ");
            }
            else {
                if (userType == "PARENT") {
                    lblUsernameTH = "รหัสผู้ใช้";
                    lblUserNameEN = "USERNAME";
                    lblPasswordTH = "รหัสผ่าน";
                    lblPasswordEN = "PASSWORD";

                    html.Append(@"
                        <div class='card-panel blue lighten-5'>
                            <div class='row'>
                                <h5 class='red-text'>
                                    <span class='th'>" + txtTitle + @"</span>
                                    <span class='en hide'>Re-Login for sign contract</span>
                                </h5>
                                <div class='col s12 m4 l4'>
                                    <div class='input-field'>
                                        <i class='mdi mdi-account-circle prefix'></i>
                                        <input placeholder='' id='username' name='username' type='text' class='validate valid' maxlength='30' value='" + username + @"' />
                                        <label for='username' class='active'>
                                            <span class='th'>" + lblUsernameTH + @"</span>
                                            <span class='en hide'>" + lblUserNameEN + @"</span>
                                        </label>
                                    </div>
                                </div>
                                <div class='col s12 m4 l4'>
                                    <div class='input-field'>
                                        <i class='mdi mdi-multiplication prefix'></i>
                                        <input placeholder='' id='password' name='password' type='password' class='validate' maxlength='50' value='' />
                                        <label for='password'>
                                            <span class='th'>" + lblPasswordTH + @"</span>
                                            <span class='en hide'>" + lblPasswordEN + @"</span>
                                        </label>
                                    </div>
                                </div>
                                <div class='col s12 m4 l4'>
                                    <div class='center'>
                                        <a href='#!' class='waves-effect waves-light btn-large blue accent-4 btnReLogin'>
                                            <i class='mdi mdi-checkbox-marked-circle-outline'></i>
                                            <span class='th'>ทำสัญญา</span>
                                            <span class='en hide'>Sign Contract</span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    ");
                }
            }

            return html.ToString();
        }

        /*
        Auther  : Odd.Nopparat
        Date    : 20-11-2015
        Perpose : UiComplete
        Method  : UiComplete
        Sample  : N/A
        */
        public static string UiComplete(
            ContractInfo ctInfo,
            StudentInfo stdInfo,
            ParentInfo parentMInfo,
            ParentInfo parentFInfo,
            string userType
        ) {
            if (stdInfo is null)
                throw new ArgumentNullException(nameof(stdInfo));

            if (parentMInfo is null)
                throw new ArgumentNullException(nameof(parentMInfo));

            if (parentFInfo is null)
                throw new ArgumentNullException(nameof(parentFInfo));

            StringBuilder html = new StringBuilder();
            Login login = new Login("STUDENT");
            string teal = "teal-text";
            //string amber = "amber-text";
            string red = "red-text";
            //string contractTH = "การทำสัญญา";
            //string contractEN = "Contract";
            string completeTH = "เสร็จสิ้น";
            //string completeEN = "Complete";
            string incompleteTH = "ยังไม่เสร็จสิ้น";
            //string incompleteEN = "not complete";
            string messageIncomplete = "กรุณาติดต่อผู้ปกครองให้ดำเนินการจัดทำ หนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม และ สัญญาค้ำประกัน";
            string messageComplete = "ดาวน์โหลดเอกสารเก็บไว้เป็นหลักฐาน";
            string message = messageIncomplete;
            string iconPass = "<i class='mdi mdi-check green-text'></i>";
            string iconNotpass = "<i class='mdi mdi-close-box-outline red-text'></i>";
            string contractHeaderTH = "";
            string contractHeaderEN = "";
            string csstext;
            string contractDate = ctInfo.DateLongContractStudent;
            string iconContract;
            string iconGuarantee;
            string iconWarrant;
            //string cssContract;
            string cssGuarantee;
            string cssWarrant;
            string headContract;
            string headGuarantee;
            string headWarrant;
            string btnPrintContract;
            string btnPrintConsent;
            string btnPrintWarrant;
            string btnPrintAll = string.Empty;

            //check 3 pass items. active on download .pdf button
            if (ctInfo.StatusComplete == "S" ||
                (ctInfo.SignStudent == "True" && ctInfo.SignParent1 == "True" && ctInfo.SignParent2 == "True")) {
                csstext = teal;
                message = messageComplete;
                contractHeaderTH = "การทำสัญญาสมบูรณ์ครบถ้วน";
                contractHeaderEN = "Sign Contract is Successfully";

                /*
                btnPrintAll = (@"
                    <a href='printContract.aspx?action=printAll&userType=" + userType + @"' target='printContract' class='waves-effect waves-light btn-large green'>
                        <span class='th'>ดาวน์โหลดเอกสาร 3 ฉบับ</span>
                        <span class='en hide'>Download All items</span>
                        <i class='mdi mdi-file-pdf'></i>
                    </a>
                ");
                */

                btnPrintContract = (@"
                    <a href='printContract.aspx?action=printContract&userType=" + userType + @"' target='printContract' class='waves-effect waves-light btn-large  green darken-1'>
                        <span class='th'>สัญญา</span>
                        <span class='en hide'>Contract</span>
                        <i class='mdi mdi-file-pdf'></i>
                    </a>
                ");
                btnPrintConsent = (@"
                    <a href='printContract.aspx?action=printConsent&userType=" + userType + @"' target='printContract' class='waves-effect waves-light btn-large green darken-1'>
                        <span class='th'>สัญญา</span>
                        <span class='en hide'>Contract</span>
                        <i class='mdi mdi-file-pdf'></i>
                    </a>
                ");
                btnPrintWarrant = (@"
                    <a href='printContract.aspx?action=printWarrant&userType=" + userType + @"' target='printContract' class='waves-effect waves-light btn-large green darken-1'>
                        <span class='th'>สัญญา</span>
                        <span class='en hide'>Contract</span>
                        <i class='mdi mdi-file-pdf'></i>
                    </a>
                ");
            }
            else {
                csstext = red;

                if (ctInfo.SignStudent == "True" &&
                    (ctInfo.SignParent1 == "False" || ctInfo.SignParent2 == "False")) {
                    contractHeaderTH = "การทำสัญญายังไม่สมบูรณ์ครบถ้วน<br>กรุณาแจ้งผู้ค้ำประกัน/ยินยอม ให้เข้ามาทำสัญญา";
                    contractHeaderEN = "Sign Contract is Unsuccessfully";
                }

                /*
                btnPrintAll = (@"
                    <span class='waves-effect waves-light btn-large red darken-4 disabled'>
                        <span class='th'>ดาวน์โหลดเอกสาร 3 ฉบับ</span>
                        <span class='en hide'>Download All items</span>
                        <i class='mdi mdi-file-pdf'></i>
                    </span>
                ");
                */

                btnPrintContract = (@"
                    <span class='waves-effect waves-light btn-large red accent-2 disabled'>
                        <span class='th'>สัญญา</span>
                        <span class='en hide'>Contract</span>
                        <i class='mdi mdi-file-pdf'></i>
                    </span>
                ");
                btnPrintConsent = (@"
                    <span class='waves-effect waves-light btn-large red accent-2 disabled'>
                        <span class='th'>สัญญา</span>
                        <span class='en hide'>Contract</span>
                        <i class='mdi mdi-file-pdf'></i>
                    </span>
                ");
                btnPrintWarrant = (@"
                    <span class='waves-effect waves-light btn-large red accent-2 disabled'>
                        <span class='th'>สัญญา</span>
                        <span class='en hide'>Contract</span>
                        <i class='mdi mdi-file-pdf'></i>
                    </span>
                ");
            }

            //iconGuarantee = (ctInfo.StatusSignMother == "Y" ? iconPass : iconNotpass);
            //iconWarrant = (ctInfo.StatusSignMother == "Y" ? iconPass : iconNotpass);

            //นักศึกษาทำสํญญาแล้ว หรือสถานะสำเร็จ
            if (ctInfo.StatusComplete == "S" ||
                ctInfo.SignStudent == "True") {
                iconContract = iconPass;
                //cssContract = teal;
                headContract = completeTH;
                btnPrintContract = (@"
                    <a href='printContract.aspx?action=printContract&userType=" + userType + @"' target='printContract' class='waves-effect waves-light btn-large  green darken-1'>
                        <span class='th'>สัญญา</span>
                        <span class='en hide'>Contract</span>
                        <i class='mdi mdi-file-pdf'></i>
                    </a>
                ");
            }
            else {
                iconContract = iconNotpass;
                //cssContract = red;
                headContract = incompleteTH;
            }

            //warrant
            //ถ้าผู้ค้ำประกัน สถานะสำเร็จ
            if (ctInfo.StatusComplete == "S" ||
                ctInfo.SignParent1 == "True") {
                iconWarrant = iconPass;
                cssWarrant = teal;
                headWarrant = completeTH;
            }
            else {
                iconWarrant = iconNotpass;
                cssWarrant = red;
                headWarrant = incompleteTH;
            }

            //guarantee
            //ถ้าผู้ยินยอมคู่สมรส สถานะสำเร็จ
            if (ctInfo.StatusComplete == "S" ||
                ctInfo.SignParent2 == "True") {
                iconGuarantee = iconPass;
                cssGuarantee = teal;
                headGuarantee = completeTH;
            }
            else {
                iconGuarantee = iconNotpass;
                cssGuarantee = red;
                headGuarantee = incompleteTH;
            }

            html.Append(@"
                <div class='section'>
                    <div class='row'>
                        <div class='col s12 m12'>
            ");

            if (userType == "STUDENT") {
                //string marriage = ctInfo.IsMarriage; //1 = สมรส, 2 = สมรส(ไม่ได้จดทะเบียน), 3 = บิดามารดาหย่าร้าง
                string maritalStatus = ctInfo.MaritalStatus;//1 = สมรส, 2 = สมรส(ไม่ได้จดทะเบียน), 3 = บิดามารดาหย่าร้าง, 4 = แยกกันอยู่, 5 = หม้าย, 6 = โสด
                string aliveF = ctInfo.IsAliveFather; //สถานะบิดา 1 = มีชีวิต, 2 = เสียชีวิต
                string aliveM = ctInfo.IsAliveMother; //สถานะมารดา 1 = มีชีวิต, 2 = เสียชีวิต
                string liveWithF = ctInfo.IsLiveFather; //อาศัยอยู่ = 1, ไม่อาศัย = 0
                string liveWithM = ctInfo.IsLiveMother; //อาศัยอยู่ = 1, ไม่อาศัย = 0
                string liveWithOther = ctInfo.IsLiveOther; //อาศัยอยู่ = 1, ไม่อาศัย = 0
                string warrantBy = ctInfo.WarrantBy; //ผู้ค้ำประกัน พ่อ = F, แม่ = M, บุคคลอื่น = N
                string passwordForFather = string.Empty;
                string passwordForMother = string.Empty;

                DataSet ds = ContractDB.Sp_ectGetStatusReqPasswordParent(maritalStatus, aliveF, aliveM, liveWithF, liveWithM, liveWithOther, warrantBy);
                int row = ds.Tables[0].Rows.Count;

                if (row > 0) {
                    passwordForFather = ds.Tables[0].Rows[0]["passwordForFather"].ToString();
                    passwordForMother = ds.Tables[0].Rows[0]["passwordForMother"].ToString();
                }

                if (passwordForFather == "1" ||
                    passwordForMother == "1") {
                    //internal contract
                    /*
                    passwordForFather = ds.Tables[0].Rows[0]["passwordForFather"].ToString();
                    passwordForMother = ds.Tables[0].Rows[0]["passwordForMother"].ToString();

                    if (passwordForFather == "1" ||
                        passwordForMother == "1") {
                    */
                    html.Append(@"
                            <div class='row center-align'>
                                <button type='button' id='submit_confirmRequest' class='waves-effect waves-light btn-large' runat='server'>ขอรับรหัสผ่านของบิดาและมารดา</button>
                            </div>
                    ");
                    /*
                    }
                    else {
                        html.Append(@"
                            <div class='row'>
                                <span class='th'>
                                    <h5 class='red-text'>
                                        <b>*เป็นกรณีที่ต้องทำสัญญาภายนอกระบบ*</b><br />
                                    </h5> 
                                    <h5 class='blue-text' style='text-align: left;'>
                                        11d. ขอให้นักศึกษาตรวจสอบการบันทึกข้อมูลในระบบ e-profile : ข้อมูลส่วนตัวข้อมูลที่อยู่ และข้อมูลครอบครัว ให้ครบถ้วนทุกรายการ<br />
                                    </h5>
                                    <h5 class='blue-text' style='text-align: left;'>
                                        22d. ให้ศึกษารายละเอียดเพิ่มเติมจาก<a href='https://econtract.mahidol.ac.th/faqContract.aspx'><u>FAQ การทำสัญญาค้ำประกัน ฯ</u></a>และให้นักศึกษา
                                        กับผู้ค้ำประกันติดต่อทำสัญญาภายนอกระบบ ให้แล้วเสร็จภายในระยะเวลาเดียวกันกับระยะเวลา
                                        การทำสัญญาการเป็นนักศึกษาในระบบนี้ ได้ที่กองกฎหมาย ชั้น 2 สำนักงานอธิการบดี โดยติดต่อ
                                        กำหนดวันและเวลาทำสัญญา รวมทั้งสอบถามข้อมูลผ่าน LINE Official Account กองกฎหมาย 
                                        ม.มหิดล : @csq0251v หรือ โทร. 02 849 6260 ในวันทำการ เวลา 08.30 – 16.30 น.
                                    </h5>
                                </span>
                            </div>
                        ");
                    }
                    */
                }
                else {
                    //external contract 
                    html.Append(@"
                            <div class='row'>
                                <span class='th'>
                                    <h5 class='red-text'>
                                        <b>*เป็นกรณีที่ต้องทำสัญญาภายนอกระบบ*</b><br />
                                    </h5> 
                                    <h5 class='blue-text' style='text-align: left;'>
                                        1. ขอให้นักศึกษาตรวจสอบการบันทึกข้อมูลในระบบ e-profile : ข้อมูลส่วนตัวข้อมูลที่อยู่ และข้อมูลครอบครัว ให้ครบถ้วนทุกรายการ<br />
                                    </h5>
                                    <h5 class='blue-text' style='text-align: left;'>
                                        2. ให้ศึกษารายละเอียดเพิ่มเติมจาก<a href='https://econtract.mahidol.ac.th/faqContract.aspx'><u>FAQ การทำสัญญาค้ำประกัน ฯ</u></a>และให้นักศึกษา
                                        กับผู้ค้ำประกันติดต่อทำสัญญาภายนอกระบบ ให้แล้วเสร็จภายในระยะเวลาเดียวกันกับระยะเวลา
                                        การทำสัญญาการเป็นนักศึกษาในระบบนี้ ได้ที่กองกฎหมาย ชั้น 2 สำนักงานอธิการบดี โดยติดต่อ
                                        กำหนดวันและเวลาทำสัญญา รวมทั้งสอบถามข้อมูลผ่าน LINE Official Account กองกฎหมาย 
                                        ม.มหิดล : @csq0251v หรือ โทร. 02 849 6260 ในวันทำการ เวลา 08.30 – 16.30 น.
                                    </h5>
                                </span>
                            </div>
                    ");
                }
            }

            html.Append(@"
                            <h3 class='" + csstext + @" center-align'>
                                <span class='th'>" + contractHeaderTH + @"</span>
                                <span class='en hide'>" + contractHeaderEN + @"</span>
                            </h3>
                            <div class='blue-text center-align'>
                                <span class='th'>" + contractDate + @"</span>
                                <span class='en hide'>" + contractDate + @"</span>
                            </div>
                            <div class='center-align'>" + btnPrintAll + @"</div>
                            <br />
                            <div class='divider'></div>
                        </div>
                        <div class='col s12 m4'>
                            <div class='icon-block'>
                                <h2 class='center'>" + iconContract + @"<i class='mdi mdi-numeric-1-box blue-text text-darken-3'></i></h2>
                                <h5 class='center teal-text'>
                                    <span class='th'>การทำสัญญานักศึกษา" + login.FullNameTH + " " + headContract + @"</span>
                                    <span class='en hide'>Student Contract Finish</span>
                                </h5>
                                <p class='light'>" + message + @"</p>
                                <p class='white-text center'>" +
                                    btnPrintContract + @"
                                    <span class='on-right red-text'>*</span>
                                </p>
                            </div>
                        </div>
                        <div class='col s12 m4'>
                            <div class='icon-block'>
                                <h2 class='center'>" + iconGuarantee + @"<i class='mdi mdi-numeric-2-box blue-text text-darken-3'></i></h2>
                                <h5 class='center " + cssGuarantee + "'>การทำหนังสือแสดงความยินยอมฯ " + headGuarantee + @"</h5>
                                <p class='light'>" + message + @"</p>
                                <p class='white-text center'>" +
                                    btnPrintConsent + @"
                                    <span class='on-right red-text'>*</span>
                                </p>
                            </div>
                        </div>
                        <div class='col s12 m4'>
                            <div class='icon-block'>
                                <h2 class='center'>" + iconWarrant + @"<i class='mdi mdi-numeric-3-box blue-text text-darken-3'></i></h2>
                                <h5 class='center " + cssWarrant + "'>การทำสัญญาค้ำประกัน " + headWarrant + @"</h5>
                                <p class='light'>" + message + @"</p>
                                <p class='white-text center'>" +
                                    btnPrintWarrant + @"
                                    <span class='on-right red-text'>*</span>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class='red-text'>
                    <span class='th'>*ดาวน์โหลดเอกสารได้เมื่อทำสัญญาครบ 3 ฉบับ</span>
                    <span class='en hide'>Allow Download Contract at Complete 3 items</span>
                </div>
            ");

            return html.ToString();
        }

        /*
        Auther  : Odd.Nopparat
        Date    : 20-11-2015
        Perpose : footerbanner
        Method  : footerbanner
        Sample  : N/A
        */
        public static string FooterBanner() {
            StringBuilder html = new StringBuilder();

            html.Append(@"
                <div class='container'>
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
                                <li class='lime-text'>
                                    <span class='th'>กองกฎหมาย ชั้น 2 สำนักงานอธิการบดี  มหาวิทยาลัยมหิดล  ศาลายา</span>
                                    <span class='en hide'>The 2nd Floor,Department of Legal Affairs, Office of the President, Mahidol University (Salaya Campus)</span>
                                </li>
                                <li>
                                    <a class='white-text' href='#'>
                                        <span class='th'>โทร : 02-849-6262</span>
                                        <span class='en hide'>Telephone: 66(0) 2849-6262</span>
                                    </a>
                                </li>
                                <li>
                                    <a class='white-text' href='#'>
                                        <span class='th'>LINE Official Account: @csq0251v</span>
                                        <span class='en hide'>LINE Official Account: @csq0251v</span>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class='footer-copyright'>
                    <div class='container'>
                        Copyright ©2015-" + Myconfig.yearEN + @"
                        Mahidol University. All rights reserved. Legal Affairs Division/Student Application Section
                    </div>
                </div>
            ");

            return html.ToString();
        }

        /*
        Auther  : anussara.wan
        Date    : 07-08-2020
        Perpose : SetContract
        Method  : SetContract
        Sample  : <param name="_dtInput">ข้อมูลสถานะบิดามารดา</param>
                  <param name="_acaYear">ปีการศึกษา</param>
                  <param name="_studentId">รหัสนักศึกษา</param>
                  <param name="_userType">STUDENT,PARENT</param>
                  <param name="_parentType">F,M</param>
                  <param name="_docId">รหัสสัญญา</param>
                  <param name="_username">username</param>
        */
        public static void SetContract(
            DataTable dtInput,
            string acaYear,
            string studentID,
            string userType,
            string parentType,
            string docID,
            string username,
            string fatherUsername,
            string motherUsername
        ) {
            //ข้อมูลตามตารางเงื่อนไขสถานภาพชีวิตบิดามารดา
            string warrantBy = dtInput.Rows[0]["warrantBy"].ToString();
            string consentBy = dtInput.Rows[0]["consentBy"].ToString();
            string marriage = dtInput.Rows[0]["marriage"].ToString();
            string aliveF = dtInput.Rows[0]["aliveF"].ToString();
            string aliveM = dtInput.Rows[0]["aliveM"].ToString();
            string liveWithF = dtInput.Rows[0]["liveWithF"].ToString();
            string liveWithM = dtInput.Rows[0]["liveWithM"].ToString();
            string liveWithOther = dtInput.Rows[0]["liveWithOther"].ToString();
            string contactFM = dtInput.Rows[0]["contactFm"].ToString();

            if (warrantBy == "N" &&
                consentBy == "N") {
                fatherUsername = string.Empty;
                motherUsername = string.Empty;
            }

            //ส่งไปบันทึกในตาราง ectDocMgmt
            ContractDB.SetContract(userType, studentID, acaYear, warrantBy, consentBy, marriage, aliveM, aliveF, liveWithM, liveWithF, liveWithOther, contactFM, parentType, username, docID, fatherUsername, motherUsername);
        }

        public static string UImenuStudent(string studentID) {
            StringBuilder html = new StringBuilder();
            ProgramContract cStsInfo = new ProgramContract(studentID); //เช็คว่าหลักสูตรสามารถทำสัญญาได้หรือไม่
            ContractInfo ctInfo = new ContractInfo(studentID); //ข้อมูลสัญญานักศึกษา
            string marriage = ctInfo.MaritalStatus; //1 = สมรส, 2 = สมรส(ไม่ได้จดทะเบียน), 3 = บิดามารดาหย่าร้าง, 4 = แยกกันอยู่, 5 = หม้าย, 6 = โสด
            string aliveF = ctInfo.IsAliveFather; //สถานะบิดา 1 = มีชีวิต, 2 = เสียชีวิต
            string aliveM = ctInfo.IsAliveMother; //สถานะมารดา 1 = มีชีวิต, 2 = เสียชีวิต
            string liveWithF = ctInfo.IsLiveFather; //อาศัยอยู่ =1, ไม่อาศัย = 0
            string liveWithM = ctInfo.IsLiveMother; //อาศัยอยู่ =1, ไม่อาศัย = 0
            string liveWithOther = ctInfo.IsLiveOther; //อาศัยอยู่ = 1, ไม่อาศัย = 0
            string warrantBy = ctInfo.WarrantBy; //ผู้ค้ำประกัน พ่อ=F,แม่=M,บุคคลอื่น=N
            //string passwordForFather = string.Empty;
            //string passwordForMother = string.Empty;
            DataSet ds = ContractDB.Sp_ectGetStatusReqPasswordParent(marriage, aliveF, aliveM, liveWithF, liveWithM, liveWithOther, warrantBy);
            int row = ds.Tables[0].Rows.Count;

            if (cStsInfo.StatusMakeContract == "MakeContract") {
                html.Append(@"
                    <div id='menuStd' style='text-align:center;'>
                        <div class='row'>
                            <button type='button' id='submit_frmContract' class='waves-effect waves-light btn-large' runat='server'>ทำสัญญาการเป็นนักศึกษา/ดาวน์โหลดสัญญานักศึกษา</button>
                        </div>
                ");
            }
            else {
                html.Append(@"
                    <div id='menuStd' style='text-align:center;'>
                        <div class='row'>
                            <span class='th'>
                                <h5 class='red-text'>คุณไม่ใช่หลักสูตรที่ต้องทำสัญญาอิเล็กทรอนิกส์ กรุณาตรวจสอบว่าต้องทำสัญญาหรือไม่</h5>
                            </span>
                            <span class='en hide'>
                                <h5 class='red-text'>คุณไม่ใช่หลักสูตรที่ต้องทำสัญญาอิเล็กทรอนิกส์ กรุณาตรวจสอบว่าต้องทำสัญญาหรือไม่</h5>
                            </span>
                        </div>
                ");
            }

            if (row > 0) {
                string passwordForFather = ds.Tables[0].Rows[0]["passwordForFather"].ToString();
                string passwordForMother = ds.Tables[0].Rows[0]["passwordForMother"].ToString();

                if (passwordForFather == "1" ||
                    passwordForMother == "1") {
                    html.Append(@"
                        <div class='row'>
                            <button type='button' id='submit_confirmRequest' class='waves-effect waves-light btn-large' runat='server'>ขอรับรหัสผ่านของบิดาและมารดา</button>
                        </div>
                    ");
                }
            }

            html.Append(@"
                    </div>
            ");

            return html.ToString();
        }

        public static string UIconfirmRequestPassStd() {
            StringBuilder html = new StringBuilder();

            html.Append(@"
                <div id='termReq' style='text-align:center;margin-top:50px;'>
                    <iframe src='termRequest.html' width='60%' height='80%' align='center' ></iframe>
                    <div style='margin-top:10px;text-align:center;'>
                        <button id='btnAcceptRequest' class='btn btn-outline-secondary' type='button' runat='server'>ยืนยัน</button>
                    </div>
                </div>
            ");

            return html.ToString();
        }

        public static string UIsetConfirmRequestPassword() {
            StringBuilder html = new StringBuilder();
            Login login = new Login("STUDENT");
            StudentInfo stdInfo = new StudentInfo(login.StudentCode);

            if (stdInfo.CheckConfirmStd != "1") {
                //insert confirm log 
                int result = ContractDB.SetConfirmRequestPassword(login.StudentCode, login.StudentID, stdInfo.AcaYear, login.Username);

                if (result == -1) {
                    html.Append(@"
                        <h6 style='text-align:center;color:red;'>ไม่สามารถขอรหัสผ่านได้ กรุณาติดต่อเจ้าหน้าที่</h6>
                    ");
                }
                else {
                    html.Append(@"
                        <div style='margin-top:10px;text-align:center;'>
                            <button id='btnPrintPassword' class='btn btn-outline-secondary' type='button' runat='server'>ดาวน์โหลดรหัสผ่าน</button>
                        </div>
                    ");
                }
            }
            else {
                html.Append(@"
                        <div style='margin-top:10px;text-align:center;'>
                            <button id='btnPrintPassword' class='btn btn-outline-secondary' type='button' runat='server'>ดาวน์โหลดรหัสผ่าน</button>
                        </div>
                ");
            }

            return html.ToString();
        }

        public static string UIsetAcceptedRequestPassword() {
            StringBuilder html = new StringBuilder();
            //DataSet ds = new DataSet();
            Login login = new Login("STUDENT");
            StudentInfo stdInfo = new StudentInfo(login.StudentCode);
            ParentInfo parentMInfo = new ParentInfo(login.StudentID, "M");
            ParentInfo parentFInfo = new ParentInfo(login.StudentID, "F");
            ContractInfo contractInfo = new ContractInfo(login.StudentID);

            if (contractInfo.IsAliveFather == "1" &&
                parentFInfo.IDCard == null && (parentFInfo.FirstNameEN == null || parentFInfo.FirstNameEN == "" || parentFInfo.LastNameEN == null || parentFInfo.LastNameEN == "")) {
                //idcard father is empty
                html.Append("<p>ไม่สามารถขอรหัสผ่านได้ เนื่องจากไม่พบรหัสบัตรประจำตัวประชาชนของบิดา/ชื่อ-นามสกุลภาษาอังกฤษ สามารถกรอกรหัสบัตรประชาชนของบิดาได้ที่<a href='https://smartedu.mahidol.ac.th'>ระบบ e-Profile</a></p>");
            }

            if (contractInfo.IsAliveFather == "1" &&
                parentMInfo.IDCard == null && (parentMInfo.FirstNameEN == null || parentMInfo.FirstNameEN == "" || parentMInfo.LastNameEN == null || parentMInfo.LastNameEN == "")) {
                //idcard mother is empty
                html.Append("<p>ไม่สามารถขอรหัสผ่านได้ เนื่องจากไม่พบรหัสบัตรประจำตัวประชาชนของมารดา/ชื่อ-นามสกุลภาษาอังกฤษ สามารถกรอกรหัสบัตรประชาชนของมารดาได้ที่<a href='https://smartedu.mahidol.ac.th'>ระบบ e-Profile</a></p>");
            }
            else {
                //check confirm log  
                int checkAcaYearSTD = Convert.ToInt32(stdInfo.AcaYear);
                int checkConfirmLog = Convert.ToInt32(stdInfo.CheckConfirmStd);

                if (checkConfirmLog <= 0 &&
                    checkAcaYearSTD >= 2562) {
                    html.Append(UIconfirmRequestPassStd());
                }
                else {
                    html.Append(UIsetConfirmRequestPassword());
                }

            }

            return html.ToString();
        }

        /*
        Auther  : anussara.wan
        Date    : 19-08-2019
        Perpose : เพื่อแสดงหน้า confirm parent
        Method  : UiConfirmParent
        Sample  : N/A
        */
        public static string UiConfirmParent(
            string userType,
            ContractInfo ctInfo,
            string username,
            string parentType,
            string studentID,
            string studentCode
        ) {
            if (string.IsNullOrEmpty(userType)) {
                throw new ArgumentException($"'{nameof(userType)}' cannot be null or empty.", nameof(userType));
            }

            if (ctInfo is null) {
                throw new ArgumentNullException(nameof(ctInfo));
            }

            if (string.IsNullOrEmpty(username)) {
                throw new ArgumentException($"'{nameof(username)}' cannot be null or empty.", nameof(username));
            }

            if (string.IsNullOrEmpty(parentType)) {
                throw new ArgumentException($"'{nameof(parentType)}' cannot be null or empty.", nameof(parentType));
            }

            if (string.IsNullOrEmpty(studentID)) {
                throw new ArgumentException($"'{nameof(studentID)}' cannot be null or empty.", nameof(studentID));
            }

            StringBuilder html = new StringBuilder();
            StudentInfo stdInfo = new StudentInfo(studentCode);
            string stdNameTH = Myconfig.CvEmpty(stdInfo.StdNameTH, " - ");
            //string stdNameEN = Myconfig.CvEmpty(stdInfo.StdNameEN, " - ");
            //string stdStatusNameTH = Myconfig.CvEmpty(stdInfo.StatusNameTH, " - ");
            //string stdStatusNameEN = Myconfig.CvEmpty(stdInfo.StatusNameEN, " - ");
            string facultyNameTH = Myconfig.CvEmpty(stdInfo.FacultyNameTH, " - ");
            //string facultyNameEH = Myconfig.CvEmpty(stdInfo.FacultyNameEN, " - ");
            //string pCode = Myconfig.CvEmpty(stdInfo.PCode, " - ");

            html.Append(@"
                <div class='card-panel grey lighten-5'>
                    <div class='grey-text text-darken-4'>
                        <div class='section'>
                            <p>
                                <input class='chkStay' name='chkStay' type='checkbox' id='chkConP' value='1' />
                                <label for='chkConP'>
                                    <span class='th'></span>
                                    <span class='en hide'></span>
                                </label>
                                ข้าพเจ้าขอให้สัตยาบันว่า ข้าพเจ้าได้มอบฉันทะให้  <b> " + stdNameTH + @"</b> นักศึกษา <b> " + facultyNameTH + @"</b> ขอรับชื่อผู้ใช้และรหัสผ่านสำหรับการทำสัญญาค้ำประกัน และหนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม แทนข้าพเจ้าจริง
                                โดยข้าพเจ้าได้รับทราบนโยบาย ระเบียบปฏิบัติการจัดทำสัญญาระบบอิเล็กทรอนิกส์กับทางมหาวิทยาลัยมหิดลแล้ว และขอยอมรับผิดชอบในการกระทำของผู้รับมอบฉันทะโดยถือเสมือนว่าเป็นการกระทำของข้าพเจ้าเองทุกประการ</br></br>
                            </p>
                        </div>
                        <span class='waves-effect waves-light btn-large green col s12  accent-12 btnConfirmParent' >ทำหนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรมและ/หรือสัญญาค้ำประกัน</span>
                    </div>
                </div>
            ");

            return html.ToString();
        }

        /*
        Auther  : anussara.wan
        Date    : 07-08-2020
        Perpose : ParallaxbannerFAQ
        Method  : ParallaxbannerFAQ
        Sample  : N/A
        */
        public static string ParallaxbannerFAQ() {
            StringBuilder html = new StringBuilder();
            string txtDateOpen = "<span class='th' style='font-size:16pt;font-family: courier;font-weight:bold;color:#0035AD;'>FAQ คำถามที่พบบ่อยเกี่ยวกับการทำสัญญาการเป็นนักศึกษา</span>";

            html.Append(@"
                <div id='index-bannerx' class='parallax-container' style='height: 160px;'>
                    <div class='section no-pad-bot'>
                        <div class='container'>
                            <div class='row'>
                                <div class='col s12 m12 l12'>
                                    <img src='http://www.student.mahidol.ac.th/portal/images/logo.png' alt='' class='responsive-img' />
                                </div>
                                <div class='col s12 m8 l8 hide-on-small-only'>
                                    <div class=''>
                                        <h5 class='light'>" + txtDateOpen + @"</h5>
                                    </div>
                                </div>
                                <div class='col s12 m4 l4'>
                                    <div class='right-align'>
                                        <img src='Images/contract_string.png' alt='' class='responsive-img' />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class='parallax'>
                            <img src='images/bgs.png' alt='#' />
                        </div>
                    </div>
            ");

            return html.ToString();
        }

        /*
        Auther  : anussara.wan
        Date    : 2020-08-07
        Perpose : ParallaxbannerHelp
        Method  : ParallaxbannerHelp
        Sample  : N/A
        */
        public static string ParallaxbannerHelp() {
            StringBuilder html = new StringBuilder();
            string txtDateOpen = "<span class='th' style='font-size:16pt;font-family: courier;font-weight:bold;color:#0035AD;'>Help คู่มือการใช้งานระบบการทำสัญญาการเป็นนักศึกษา</span>";
            
            html.Append(@"
                <div id='index-bannerx' class='parallax-container' style='height: 160px;'>
                    <div class='section no-pad-bot'>
                        <div class='container'>
                            <div class='row'>
                                <div class='col s12 m12 l12'>
                                    <img src='http://www.student.mahidol.ac.th/portal/images/logo.png' alt='' class='responsive-img' />
                                </div>
                                <div class='col s12 m8 l8 hide-on-small-only'>
                                    <div class=''>
                                        <h5 class='light'>" + txtDateOpen + @"</h5>
                                    </div>
                                </div>
                                <div class='col s12 m4 l4'>
                                    <div class='right-align'>
                                        <img src='Images/contract_string.png' alt='' class='responsive-img' />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class='parallax'>
                            <img src='images/bgs.png' alt='#' />
                        </div>
                    </div>
            ");

            return html.ToString();
        }
    }
}