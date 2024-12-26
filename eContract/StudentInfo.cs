using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eContract {
    public class StudentInfo {
        string statusNameTH;
        public string StatusNameTH {
            get { return statusNameTH; }
            set { statusNameTH = value; }
        }

        string statusNameEN;
        public string StatusNameEN {
            get { return statusNameEN; }
            set { statusNameEN = value; }
        }

        string stdNameTH;
        public string StdNameTH {
            get { return stdNameTH; }
            set { stdNameTH = value; }
        }

        string stdNameEN;
        public string StdNameEN {
            get { return stdNameEN; }
            set { stdNameEN = value; }
        }

        string facultyCode;
        public string FacultyCode {
            get { return facultyCode; }
            set { facultyCode = value; }
        }

        string facultyNameTH;
        public string FacultyNameTH {
            get { return facultyNameTH; }
            set { facultyNameTH = value; }
        }

        string facultyNameEN;
        public string FacultyNameEN {
            get { return facultyNameEN; }
            set { facultyNameEN = value; }
        }

        string programNameTH;
        public string ProgramNameTH {
            get { return programNameTH; }
            set { programNameTH = value; }
        }

        string programNameEN;
        public string ProgramNameEN {
            get { return programNameEN; }
            set { programNameEN = value; }
        }

        string idCard;
        public string IDCard {
            get { return idCard; }
            set { idCard = value; }
        }

        string studentID;
        public string StudentID {
            get { return studentID; }
            set { studentID = value; }
        }

        string isData;
        public string IsData {
            get { return isData; }
            set { isData = value; }
        }

        string studentCode;
        public string StudentCode {
            get { return studentCode; }
            set { studentCode = value; }
        }

        string programCode;
        public string ProgramCode {
            get { return programCode; }
            set { programCode = value; }
        }

        string majorCode;
        public string MajorCode {
            get { return majorCode; }
            set { majorCode = value; }
        }

        string groupNum;
        public string GroupNum {
            get { return groupNum; }
            set { groupNum = value; }
        }

        string pCode;
        public string PCode {
            get { return pCode; }
            set { pCode = value; }
        }

        string birthDate;
        public string Birthdate {
            get { return birthDate; }
            set { birthDate = value; }
        }

        string age;
        public string Age {
            get { return age; }
            set { age = value; }
        }

        string no;
        public string No {
            get { return no; }
            set { no = value; }
        }

        string moo;
        public string Moo {
            get { return moo; }
            set { moo = value; }
        }

        string soi;
        public string Soi {
            get { return soi; }
            set { soi = value; }
        }

        string road;
        public string Road {
            get { return road; }
            set { road = value; }
        }

        string subdistrictNameTH;

        public string SubdistrictNameTH
        {
            get { return subdistrictNameTH; }
            set { subdistrictNameTH = value; }
        }

        string subdistrictNameEN;
        public string SubDistrictNameEN {
            get { return subdistrictNameEN; }
            set { subdistrictNameEN = value; }
        }

        string districtNameTH;
        public string DistrictNameTH {
            get { return districtNameTH; }
            set { districtNameTH = value; }
        }

        string districtNameEN;
        public string DistrictNameEN {
            get { return districtNameEN; }
            set { districtNameEN = value; }
        }

        string provinceNameTH;
        public string ProvinceNameTH {
            get { return provinceNameTH; }
            set { provinceNameTH = value; }
        }

        string provinceNameEN;
        public string ProvinceNameEN {
            get { return provinceNameEN; }
            set { provinceNameEN = value; }
        }

        string zipcode;
        public string Zipcode {
            get { return zipcode; }
            set { zipcode = value; }
        }

        string phoneNumberStd;
        public string PhoneNumberStd {
            get { return phoneNumberStd; }
            set { phoneNumberStd = value; }
        }

        string dayOfBirth;
        public string DayOfBirth {
            get { return dayOfBirth; }
            set { dayOfBirth = value; }
        }

        string monthNameOfBirth;
        public string MonthNameOfBirth {
            get { return monthNameOfBirth; }
            set { monthNameOfBirth = value; }
        }

        string yearOfBirth;
        public string YearOfBirth {
            get { return yearOfBirth; }
            set { yearOfBirth = value; }
        }

        string admissionType;
        public string AdmissionType {
            get { return admissionType; }
            set { admissionType = value; }
        }

        string urlPic;
        public string UrlPic {
            get { return urlPic; }
            set { urlPic = value; }
        }

        string quotaCode;
        public string QuotaCode {
            get { return quotaCode; }
            set { quotaCode = value; }
        }

        string programNameTHGuarantee;
        public string ProgramNameTHGuarantee {
            get {return programNameTHGuarantee; }
            set { programNameTHGuarantee = value; }
        }

        string forProgramNameTHGuarantee;
        public string ForProgramNameTHGuarantee {
            get { return forProgramNameTHGuarantee; }
            set { forProgramNameTHGuarantee = value; }
        }

        string acaYear;
        public string AcaYear {
            get { return acaYear; }
            set { acaYear = value; }
        }

        string checkDataStd = "Y";
        public string CheckDataStd {
            get { return checkDataStd; }
            set { checkDataStd = value; }
        }

        string urlPicInternet;
        public string UrlPicInternet {
            get { return urlPicInternet; }
            set { urlPicInternet = value; }
        }

        string groupNameTH;
        public string GroupNameTH {
            get { return groupNameTH; }
            set { groupNameTH = value; }
        }

        string warrantCoverage;
        public string WarrantCoverage {
            get { return warrantCoverage; }
            set { warrantCoverage = value; }
        }

        string operatingRange;
        public string OperatingRange {
            get { return operatingRange; }
            set { operatingRange = value; }
        }

        string strStudentProgram;
        public string StrStudentProgram {
            get { return strStudentProgram; }
            set { strStudentProgram = value; }
        }

        string txtWarrantCoverage;
        public string TxtWarrantCoverage {
            get { return txtWarrantCoverage; }
            set { txtWarrantCoverage = value; }
        }

        string checkConfirmStd;
        public string CheckConfirmStd {
            get { return checkConfirmStd; }
            set { checkConfirmStd = value; }
        }

        string nationalityNameTH;
        public string NationalityNameTH {
            get { return nationalityNameTH; }
            set { nationalityNameTH = value; }
        }

        public StudentInfo(string studentID) {
            GetInfo(studentID);
            GetCheckData();
	    }

        public void GetInfo(string cStudentID) {
            SetEmpty();
        
            string query = ("sp_ectStudentInfoByStudentCode '" + cStudentID + "'");
            //string query = ("sp_ectStudentInfo '" + cStudentID + "'");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataSet dsStd = new DataSet();
            adp.Fill(dsStd);
            int row = dsStd.Tables[0].Rows.Count;
     
            if (row > 0) {
                isData = "Y";
                stdNameTH = dsStd.Tables[0].Rows[0]["stdNameTh"].ToString();
                stdNameEN = dsStd.Tables[0].Rows[0]["stdNameEn"].ToString();
                facultyCode = dsStd.Tables[0].Rows[0]["facultyCode"].ToString();
                facultyNameTH = dsStd.Tables[0].Rows[0]["facultyNameTh"].ToString();
                facultyNameEN = dsStd.Tables[0].Rows[0]["facultyNameEn"].ToString();
                programNameTH = dsStd.Tables[0].Rows[0]["programNameTh"].ToString();
                programNameEN = dsStd.Tables[0].Rows[0]["programNameEn"].ToString();
                statusNameTH = dsStd.Tables[0].Rows[0]["statusTh"].ToString();
                statusNameEN = dsStd.Tables[0].Rows[0]["statusEn"].ToString();
                studentCode = dsStd.Tables[0].Rows[0]["studentCode"].ToString();
                idCard = dsStd.Tables[0].Rows[0]["idcard"].ToString();
                programCode = dsStd.Tables[0].Rows[0]["programCode"].ToString();
                majorCode = dsStd.Tables[0].Rows[0]["majorCode"].ToString();
                groupNum = dsStd.Tables[0].Rows[0]["groupNum"].ToString();
                pCode = dsStd.Tables[0].Rows[0]["pCode"].ToString();
                phoneNumberStd = dsStd.Tables[0].Rows[0]["phoneStudent"].ToString();
                birthDate = dsStd.Tables[0].Rows[0]["birthDateTh"].ToString();
                age = dsStd.Tables[0].Rows[0]["age"].ToString();
            
                //ที่อยู่ดึงตามทะเบียนบ้าน
                no = dsStd.Tables[0].Rows[0]["addrNo"].ToString();//*
                moo = dsStd.Tables[0].Rows[0]["addrMoo"].ToString();
                soi = dsStd.Tables[0].Rows[0]["addrSoi"].ToString();
                road = dsStd.Tables[0].Rows[0]["addrStreet"].ToString();
                subdistrictNameTH = dsStd.Tables[0].Rows[0]["addrSubDistrict"].ToString();//*
                subdistrictNameEN = dsStd.Tables[0].Rows[0]["addrSubDistrict"].ToString();
                districtNameTH = dsStd.Tables[0].Rows[0]["addrDistrict"].ToString();//*
                districtNameEN = dsStd.Tables[0].Rows[0]["addrDistrict"].ToString();
                provinceNameTH = dsStd.Tables[0].Rows[0]["addrProvince"].ToString();//*
                provinceNameEN = dsStd.Tables[0].Rows[0]["addrProvince"].ToString();
                zipcode = dsStd.Tables[0].Rows[0]["addrZip"].ToString();//*
                dayOfBirth = dsStd.Tables[0].Rows[0]["dayOfBD"].ToString();
                monthNameOfBirth = dsStd.Tables[0].Rows[0]["monthOfBD"].ToString();
                yearOfBirth = dsStd.Tables[0].Rows[0]["yearOfBD"].ToString();
                admissionType = dsStd.Tables[0].Rows[0]["admissionType"].ToString();
                urlPic = dsStd.Tables[0].Rows[0]["pictureName"].ToString();
                urlPicInternet = dsStd.Tables[0].Rows[0]["urlPicInternet"].ToString();
                quotaCode = dsStd.Tables[0].Rows[0]["quotaCode"].ToString();
                programNameTHGuarantee = dsStd.Tables[0].Rows[0]["programNameTHGuarantee"].ToString();
                forProgramNameTHGuarantee = dsStd.Tables[0].Rows[0]["forProgramNameTHGuarantee"].ToString();
                acaYear = dsStd.Tables[0].Rows[0]["yearEntry"].ToString();
                groupNameTH = dsStd.Tables[0].Rows[0]["groupNameTh"].ToString();
                warrantCoverage = dsStd.Tables[0].Rows[0]["warrantCoverage"].ToString();
                operatingRange = dsStd.Tables[0].Rows[0]["operatingRange"].ToString();
                strStudentProgram = dsStd.Tables[0].Rows[0]["strStudentProgram"].ToString();
                txtWarrantCoverage = dsStd.Tables[0].Rows[0]["txtWarrantCoverage"].ToString();
                checkConfirmStd = dsStd.Tables[0].Rows[0]["checkConfirmStd"].ToString();
                nationalityNameTH = dsStd.Tables[0].Rows[0]["thNationalityName"].ToString();
                studentID = dsStd.Tables[0].Rows[0]["id"].ToString();
            }
        }

        public void SetEmpty() {
            studentID = "";
            statusNameTH = "";
            statusNameEN = "";
            stdNameTH = "";
            stdNameEN = "";
            facultyCode = "";
            facultyNameTH = "";
            facultyNameEN = "";
            programNameTH = "";
            programNameEN = "";
            idCard = "";
            studentCode = "";
            programCode = "";
            majorCode = "";
            groupNum = "";
            pCode = "";
            isData = "N";
            birthDate="";
            age = "";
            no = "";
            moo = "";
            soi = "";
            road = "";
            subdistrictNameTH = "";
            subdistrictNameEN = "";
            districtNameTH = "";
            districtNameEN = "";
            provinceNameTH = "";
            provinceNameEN = "";
            zipcode = "";
            phoneNumberStd = "";
            dayOfBirth = "";
            monthNameOfBirth = "";
            yearOfBirth = "";
            admissionType="";
            urlPic="";
            quotaCode="";
            programNameTHGuarantee = "";
            forProgramNameTHGuarantee = "";
            groupNameTH = "";
            warrantCoverage = "";
            operatingRange = "";
            strStudentProgram = "";
            txtWarrantCoverage = "";
            checkConfirmStd = "";
        }

        //ตรวจสอบข้อมูลก่อนทำสัญญานักศึกษา
        public void GetCheckData() {
            if (stdNameTH == "" ||
                studentCode == "" ||
                idCard == "" ||
                phoneNumberStd == "" ||
                birthDate == "" ||
                age == "" ||
                no == "" ||
                subdistrictNameTH == "" ||
                districtNameTH == "" ||
                provinceNameTH == "" ||
                zipcode == "") {
                checkDataStd = "N";
            }
        }
    }
}