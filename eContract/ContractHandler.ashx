<%@ WebHandler Language="C#" Class="eContract.ContractHandler" %>

using System;
using System.Web;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace eContract {
    public class ContractHandler : IHttpHandler {
        HttpContext c;

        public void ProcessRequest(HttpContext context) {
            c = context;
            string action = c.Request.Form["action"];

            switch (action) {
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
                /*
                case "CheckConsent":
                    CheckConsent();
                    break;
                */
                case "CheckENFullNameParent":
                    CheckENFullNameParent();
                    break;
            }
        }

        public string GenerateUsername(
            string firstNameEN,
            string lastNameEN
        ) {
            string username = "";
            bool checkStatus = false;
            Regex rgx = new Regex("[^a-zA-Z]");
            firstNameEN = rgx.Replace(firstNameEN, "").ToLower();
            lastNameEN = rgx.Replace(lastNameEN, "").ToLower();
            int lengthLastName = lastNameEN.Length;

            if (lastNameEN != "" ||
                lastNameEN != string.Empty ||
                lengthLastName != 0) {
                if (lengthLastName < 3) {
                    username = (firstNameEN + "." + lastNameEN);
                    checkStatus = CheckAvailableUsername(username);

                    if(checkStatus == false) {
                        for(int i = 1; i <= 10; i++) {
                            username = (username + i.ToString());
                            checkStatus = CheckAvailableUsername(username);

                            if(checkStatus == true) {
                                break;
                            }
                        }
                    }
                }
                else {
                    //FirstName.LastName(Left, 3)
                    for (int charAt = 2; charAt <= lengthLastName; charAt++) {
                        username = (firstNameEN + "." + lastNameEN.Substring(0, 2) + lastNameEN.Substring(charAt, 1));
                        checkStatus = CheckAvailableUsername(username);

                        if (checkStatus == true) {
                            break;
                        }
                    }

                    //if checkStatus == false after Loop first
                    if (checkStatus == false) {
                        //FirstName.LastName(Right, 3)
                        for (int charAt = 3; charAt <= lengthLastName; charAt++) {
                            username = (firstNameEN + "." + lastNameEN.Substring(lengthLastName - 1, 1) + lastNameEN.Substring(lengthLastName - 2, 1) + lastNameEN.Substring(lengthLastName - charAt, 1));
                            checkStatus = CheckAvailableUsername(username);

                            if (checkStatus == true) {
                                break;
                            }
                        }
                    }
                }
            }
            else {
                //enLastName = null
                for (int increment = 0; increment <= 100; increment++) {
                    if (increment == 0) {
                        username = firstNameEN;
                    }
                    else {
                        username = (firstNameEN + "_" + increment);
                    }

                    checkStatus = CheckAvailableUsername(username);

                    if (checkStatus == true) {
                        break;
                    }
                }
            }

            return username;
        }

        public bool CheckAvailableUsername(string username) {
            bool status = false;
            DataSet result = new DataSet();
            result = ContractDB.CheckAvailableUsername(username);

            if (result.Tables[0].Rows.Count > 0) {
                //unavailable
                status = false;
            }
            else {
                //available
                status = true;
            }

            return status;
        }

        public void SignLogin() {
            StringBuilder xml = new StringBuilder();
            string username;
            string password;
            string userType;
            string fatherUsername = "";
            string motherUsername = "";
            string authen = "false";
            string isSuccess = "0";
            string msgTH = "";
            string msgEN = "";

            try {
                DataTable dtSign = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(c.Request.Form["strSign"]);
                DataTable dtInput = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(c.Request.Form["strInput"]);
                int row = dtSign.Rows.Count;

                if (row > 0) {
                    //ข้อมูล re-login
                    username = dtSign.Rows[0]["username"].ToString();
                    password = dtSign.Rows[0]["password"].ToString();
                    userType = dtSign.Rows[0]["userType"].ToString();

                    Login login = new Login(userType);
                    string studentID = login.StudentID;
                    //string acaYear = Myconfig.GetYearContract();

                    StudentInfo stdInfo = new StudentInfo(login.StudentCode);
                    ParentInfo parentMInfo = new ParentInfo(studentID, "M");
                    ParentInfo parentFInfo = new ParentInfo(studentID, "F");

                    ContractInfo ctInfo = new ContractInfo(studentID); // check already sign contract
                    string acaYear = Myconfig.CvEmpty(stdInfo.AcaYear, " - ");
                    string parentType = login.UserType; // F M or student

                    //ตรวจสอบ ประเภท ผู้ใช้งาน เพื่อตรวจสอบสิทธิ์
                    if (userType == "STUDENT") {
                        //generate Username
                        fatherUsername = GenerateUsername(parentFInfo.FirstNameEN, parentFInfo.LastNameEN).ToLower();
                        motherUsername = GenerateUsername(parentMInfo.FirstNameEN, parentMInfo.LastNameEN).ToLower();
                        authen = Login.AuthenSignStudent(username, userType);
                    }
                    else {
                        if (userType == "PARENT") {
                            authen = Login.AuthenSignParent(username, password, userType);
                        }
                    }

                    //ตรวจสอบ รหัสผ่านอีกครั้งก่อนทำการบันทึกการทำสัญญา ทั้งสัญญานักศึกษา สัญญาค้ำประกัน หนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม
                    if (authen == "true") {
                        //save data
                        ContractUI.SetContract(dtInput, acaYear, studentID, userType, parentType, ctInfo.DocID, username, fatherUsername, motherUsername);

                        //after finish save
                        //refill data
                        ctInfo = new ContractInfo(studentID); // refresh data for checkstatus complete

                        if (userType == "STUDENT") {
                            if (ctInfo.StatusSignStudent == "Y" ||
                                ctInfo.StatusComplete == "S") {
                                isSuccess = "1";
                            }
                        }
                        else {
                            if (userType == "PARENT") {
                                //ผู้ใช้งาน เป็นผู้ค้ำประกัน และได้ทำสัญญาแล้ว
                                if (ctInfo.WarrantBy == parentType &&
                                    ctInfo.SignParent1 == "True") {
                                    isSuccess = "1";
                                }                                
                                else {
                                    //ผู้ใช้งาน เป็นยินยอม และได้ทำสัญญาแล้ว
                                    if (ctInfo.ConsentBy == parentType &&
                                        ctInfo.SignParent2 == "True") {
                                        isSuccess = "1";
                                    }
                                    else {
                                        if (ctInfo.StatusComplete == "S") {
                                            isSuccess = "1";
                                        }
                                    }
                                }
                            }
                        }


                        if (isSuccess == "1") {
                            msgTH = "<span class=\"green-text\"><h5>ดำเนินการบันทึกสัญญาเข้าระบบแล้ว</h5></span>";
                            msgEN = "<span class=\"green-text\"><h5>Successfully Sign Contract</h5></span>";
                            xml.Append(ContractUI.UiComplete(ctInfo, stdInfo, parentMInfo, parentFInfo, userType));
                        }
                        else {
                            msgTH = "<span class=\"red-text\"><h5>ระบบขัดข้อง!!! ไม่สามารถบันทึกข้อมูลได้</h5></span>";
                            msgEN = "<span class=\"red-text\"><h5>System Error!!!</h5></span>";
                        }
                    }
                    else {
                        if (authen == "false") {
                            msgTH = "<span class=\"red-text\"><h5>ผู้ใช้งาน/รหัสผ่าน ไม่ถูกต้อง!!!</h5></span>";
                            msgEN = "<span class=\"red-text\"><h5>User/Password Incorrect!!!</h5></span>";
                        }
                    }
                }
                else {
                    msgTH = "<span class=\"red-text\"><h5>ไม่พบการส่งค่าข้อมูล!!!</h5></span>";
                    msgEN = "<span class=\"red-text\"><h5>Post Data Not Found!!!</h5></span>";
                }
            }
            catch (Exception ex) {
                msgTH = ("<span class=\"red-text\"><h5>ระบบผิดพลาด : " + ex.Message.Replace("'", " ") + "</h5></span>");
                msgEN = ("<span class=\"red-text\"><h5>CODE ERROR : " + ex.Message.Replace("'", " ") + "</h5></span>");
            }

            xml.Append("<input type='hidden' class='txtProcessStatus' value='" + isSuccess + "' data-msg_th='" + msgTH + "' data-msg_en='" + msgEN + "' >");

            c.Response.Write(xml.ToString());
        }

        public void UiPreviewContrat() {
            StringBuilder html = new StringBuilder();
            string userType = c.Request.Form["userType"];
            string warranty = c.Request.Form["warranty"];
            string consent = c.Request.Form["consent"];

            Login login = new Login(userType);
            string studentID = login.StudentID;
            //string acaYear = Myconfig.GetYearContract();
            string username = login.Username;

            StudentInfo stdInfo = new StudentInfo(login.StudentCode);
            string acaYear = Myconfig.CvEmpty(stdInfo.AcaYear, " - ");
            string quotaCode = stdInfo.QuotaCode;
            string programCode = stdInfo.ProgramCode;
            string checkDataStd = stdInfo.CheckDataStd;
            ContractInfo ctInfo = new ContractInfo(studentID);
            //str.Append(ContractPreview.SIMDB_Preview(acaYear, studentID));
            string statusContract = "";
            int checkAcaYear = Convert.ToInt32(acaYear);
            //int checkAcaYear = 2565;

            if (checkAcaYear < 2565)
                statusContract = "OLD";
            else
                statusContract = "NEW";

            switch (programCode) {
                case "SIMDB":
                    switch (statusContract) {
                        case "NEW":
                            html.Append(ContractPreview.Preview_SIMDBNEW(acaYear, studentID, warranty, consent, stdInfo.StudentCode));
                            break;
                        case "OLD":
                            html.Append(ContractPreview.Preview_SIMDB(acaYear, studentID, stdInfo.StudentCode));
                            break;
                    }
                    break;
                case "RAMDB":
                    switch (statusContract) {
                        case "NEW":
                            html.Append(ContractPreview.Preview_RAMDBNEW(acaYear, studentID, warranty, consent, stdInfo.StudentCode));
                            break;
                        case "OLD":
                            html.Append(ContractPreview.Preview_RAMDB(acaYear, studentID, stdInfo.StudentCode));
                            break;
                    }
                    break;
                case "PYPYB":
                    html.Append(ContractPreview.Preview_PYPYB(acaYear, studentID, stdInfo.StudentCode));
                    break;
                case "DTDSB":
                    switch (statusContract) {
                        case "NEW":
                            html.Append(ContractPreview.Preview_DTDSBNEW(acaYear, studentID, warranty, consent, stdInfo.StudentCode));
                            break;
                        case "OLD":
                            html.Append(ContractPreview.Preview_DTDSB(acaYear, studentID, stdInfo.StudentCode));
                            break;
                    }
                    break;
                case "RANSB":
                    html.Append(ContractPreview.Preview_RANSB(acaYear, studentID, stdInfo.StudentCode));
                    break;
                case "NSNSB":
                    switch (quotaCode) {
                        //specification nurse program project
                        //siriraj hospital
                        default:                            
                            html.Append(ContractPreview.Preview_NSNSB(acaYear, studentID, stdInfo.StudentCode));
                            break;
                        //chula research
                        case "354":                            
                            html.Append(ContractPreview.Preview_NSNSB_CL(acaYear, studentID, stdInfo.StudentCode));
                            break;
                        // faculty of tropical medicine
                        case "351":                            
                            html.Append(ContractPreview.Preview_NSNSB_TM(acaYear, studentID, stdInfo.StudentCode));
                            break;
                    }
                    break;
            }

            if (checkDataStd == "N") {
                html.Append(GetMessageProfilevalidated());
            }
            else {
                html.Append(ContractUI.UiReLoginForm(userType, ctInfo, username, "student"));
            }

            html.Append("<span class='waves-effect waves-light btn-large grey col s12  accent-12 btnBack' >ย้อนกลับ</span><br><br>");

            c.Response.Write(html.ToString());
        }

        public string GetMessageProfilevalidated() {
            StringBuilder html = new StringBuilder();

            html.Append(
                "<div class='card-panel blue lighten-5'>" +
                "<div class='row'>" +
                "<h5 class='red-text'><center>เนื่องจากนักศึกษากรอกข้อมูลในระบบ e-Profile ไม่ครบถ้วน</center><p><center>ให้นักศึกษาเข้าระบบ e-Profile เพื่อกรอกข้อมูลในช่องที่ขาดหาย</center></p></h5>" +
                "<h5 class='green-text'><center>hint : ข้อมูลที่อยู่ที่ปรากฏในสัญญาชื่อ-นามสกุล, วันเกิด<br>ที่อยู่ปัจจุบันที่ติดต่อได้ บ้านเลขที่, ตำบล, อำเภอ, จังหวัด, รหัสไปรษณีย์<br> เบอร์โทรศัพท์, บัตรประชาชน, ชื่อ-นามสกุล บิดา, ชื่อ-นามสกุล มารดา <br>และที่อยู่ปัจจุบันของบิดา มารดา</center></h5>" +
                "<h5><center><a href='https://smartedu.mahidol.ac.th'>คลิกที่นี่เพื่อเข้าสู่ระบบ e-Profile</a></center></p><p><center>ถ้าระบบ e-Profile ไม่เปิดให้บริการ กรุณาติดต่อ 02-849-4562 </center></p><p><center>เพื่อให้เจ้าหน้าที่เปิดระบบ</center></h5>" +
                "</div>" +
                "</div>"
            );

            return html.ToString();
        }

        public void UIsetConfirmRequestPassword() {
            StringBuilder html = new StringBuilder();

            html.Append(ContractUI.UIsetConfirmRequestPassword());

            c.Response.Write(html.ToString());
        }

        public void UIsetAcceptedRequestPassword() {
            StringBuilder html = new StringBuilder();

            html.Append(ContractUI.UIsetAcceptedRequestPassword());

            c.Response.Write(html.ToString());
        }

        /*
        Auther  : anussara.wan
        Date    : 2019-08-20
        Perpose : SetConfirmParent
        Method  : SetConfirmParent
        Sample  : N/A
        */
        public void SetConfirmParent() {
            StringBuilder html = new StringBuilder();
            string userType = c.Request.Form["userType"];
            Login login = new Login(userType);
            string studentID = login.StudentID;
            string username = login.Username;            
            ContractInfo ctInfo = new ContractInfo(studentID); //check already sign contract
            string parentType = login.UserType; //F M or student
            string confirmStatus = "Y";

            ContractDB.SetConfirmParent(username, studentID, confirmStatus);
            html.Append(ContractPreview.Preview_Guarantee(studentID, parentType, login.StudentCode));
            html.Append(ContractPreview.Preview_Warrant(studentID, parentType, login.StudentCode));
            html.Append(ContractUI.UiReLoginForm(userType, ctInfo, username, userType));

            c.Response.Write(html.ToString());
        }

        public bool IsReusable {
            get{
                return false;
            }
        }

        /*
        public void CheckConsent() {
            DataSet ds = new DataSet();
            string consentStatus = "";
            string userType = c.Request.Form["userType"];
            Login login = new Login(userType);
            string studentID = login.StudentId;
        
            ds = ContractDB.GetConsent(studentID);

            if (ds.Tables[0].Rows.Count > 0) {
                consentStatus = "true";
            }
            else {
                consentStatus = "false";
            }
        
            c.Response.Write(_consentStatus);
        }
        */

        public void CheckENFullNameParent() {
            DataSet ds = new DataSet();
            string userType = c.Request.Form["userType"];
            string warranty = c.Request.Form["warranty"];
            string consent = c.Request.Form["consent"];
            Login login = new Login(userType);
            string studentID = login.StudentID;
            ParentInfo parentInfoWarranty = null;
            ParentInfo parentInfoConsent = null;
            ParentInfo parentInfo = null;

            if (warranty == consent) {
                //same person
                parentInfo = new ParentInfo(studentID, warranty);

                string firstNameEN = parentInfo.FirstNameEN;
                string lastNameEN = parentInfo.LastNameEN;

                if ((firstNameEN == "" || lastNameEN == "") &&
                    parentInfo.NationalityID == "177") {
                    c.Response.Write(JsonConvert.SerializeObject(new {
                        Status = "False",
                        Person = "Same",
                        enFirstName = firstNameEN,
                        enLastName = lastNameEN
                    }));
                }
                else {
                    if (parentInfo.NationalityID != "177" &&
                        firstNameEN == "") {
                        c.Response.Write(JsonConvert.SerializeObject(new {
                            Status = "False",
                            Person = "Same",
                            enFirstName = firstNameEN,
                            enLastName = lastNameEN
                        }));
                    }
                    else {
                        c.Response.Write(JsonConvert.SerializeObject(new {
                            Status = "True",
                            Person = "Same"
                        }));
                    }
                }
            }
            else {
                //different person
                parentInfoWarranty = new ParentInfo(studentID, warranty);
                parentInfoConsent = new ParentInfo(studentID, consent);
                string firstNameENWarranty = parentInfoWarranty.FirstNameEN;
                string lastNameENWarranty = parentInfoWarranty.LastNameEN;
                string firstNameENConsent = parentInfoConsent.FirstNameEN;
                string lastNameENConsent = parentInfoConsent.LastNameEN;

                if ((firstNameENWarranty == "" || lastNameENWarranty == "" || firstNameENConsent == "" || lastNameENConsent == "") &&
                    (parentInfoWarranty.NationalityID == "177" && parentInfoConsent.NationalityID == "177")) {
                    c.Response.Write(JsonConvert.SerializeObject(new {
                        Status = "False",
                        Person = "Different",
                        enFirstNameWarranty = firstNameENWarranty,
                        enLastNameWarranty = lastNameENWarranty,
                        enFirstNameConsent = firstNameENConsent,
                        enLastNameConsent = lastNameENConsent
                    }));
                }
                else {
                    if ((parentInfoWarranty.NationalityID != "177" || parentInfoConsent.NationalityID != "177") &&
                        (firstNameENWarranty == "" || firstNameENConsent == "")) {
                        c.Response.Write(JsonConvert.SerializeObject(new {
                            Status = "False",
                            Person = "Different",
                            enFirstNameWarranty = firstNameENWarranty,
                            enLastNameWarranty = lastNameENWarranty,
                            enFirstNameConsent = firstNameENConsent,
                            enLastNameConsent = lastNameENConsent
                        }));
                    }
                    else {
                        c.Response.Write(JsonConvert.SerializeObject(new {
                            Status = "True",
                            Person = "Different"
                        }));
                    }
                }
            }
        }
    }
}