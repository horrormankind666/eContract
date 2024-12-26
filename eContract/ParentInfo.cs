using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eContract {
    public class ParentInfo {
        string idCard;
        public string IDCard {
            get { return idCard; }
            set { idCard = value; }
        }

        string fullNameTH;
        public string FullNameTH {
            get { return fullNameTH; }
            set { fullNameTH = value; }
        }

        string fullNameEN;
        public string FullNameEN {
            get { return fullNameEN; }
            set { fullNameEN = value; }
        }

        string position;
        public string Position {
            get { return position; }
            set { position = value; }
        }

        string age;
        public string Age {
            get { return age; }
            set { age = value; }
        }

        string noPermanent;
        public string NoPermanent {
            get { return noPermanent; }
            set { noPermanent = value; }
        }

        string mooPermanent;
        public string MooPermanent {
            get { return mooPermanent; }
            set { mooPermanent = value; }
        }

        string soiPermanent;
        public string SoiPermanent {
            get { return soiPermanent; }
            set { soiPermanent = value; }
        }

        string roadPermanent;
        public string RoadPermanent {
            get { return roadPermanent; }
            set { roadPermanent = value; }
        }

        string subdistrictNameTH;
        public string SubdistrictNameTH {
            get { return subdistrictNameTH; }
            set { subdistrictNameTH = value; }
        }

        string subdistrictNameEN;
        public string SubdistrictNameEN {
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

        string zipcodePermanent;
        public string ZipcodePermanent {
            get { return zipcodePermanent; }
            set { zipcodePermanent = value; }
        }

        string phoneNumberPermanent;
        public string PhoneNumberPermanent {
            get { return phoneNumberPermanent; }
            set { phoneNumberPermanent = value; }
        }

        string mobileNumberPermanent;
        public string MobileNumberPermanent {
            get { return mobileNumberPermanent; }
            set { mobileNumberPermanent = value; }
        }

        string occupationTH;
        public string OccupationTH {
            get { return occupationTH; }
            set { occupationTH = value; }
        }

        string occupationEN;
        public string OccupationEN {
            get { return occupationEN; }
            set { occupationEN = value; }
        }

        string agencyNameTH;
        public string AgencyNameTH {
            get { return agencyNameTH; }
            set { agencyNameTH = value; }
        }

        string agencyNameEN;
        public string AgencyNameEN {
            get { return agencyNameEN; }
            set { agencyNameEN = value; }
        }

        string isData;
        public string IsData {
            get { return isData; }
            set { isData = value; }
        }

        string checkDataParent = "Y";
        public string CheckDataParent {
            get { return checkDataParent; }
            set { checkDataParent = value; }
        }

        string checkAlive;
        public string CheckAlive {
            get { return checkAlive; }
            set { checkAlive = value; }
        }

        string checkConfirmParent;
        public string CheckConfirmParent {
            get { return checkConfirmParent; }
            set { checkConfirmParent = value; }
        }

        string password;
        public string Password {
            get { return password; }
            set { password = value; }
        }

        string firstNameEN;
        public string FirstNameEN {
            get { return firstNameEN; }
            set { firstNameEN = value; }
        }

        string lastNameEN;
        public string LastNameEN {
            get { return lastNameEN; }
            set { lastNameEN = value; }
        }

        string nationalityID;
        public string NationalityID {
            get { return nationalityID; }
            set { nationalityID = value; }
        }

        public ParentInfo(
            string studentID,
            string parentType
        ) {
            GetInfo(studentID, parentType);
            GetCheckDataParent();
        }

        private void GetInfo(
            string studentID,
            string parentType
        ) {
            SetEmpty();

            string query = ("sp_ectParentInfo '" + studentID + "','" + parentType + "'");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataSet dsParent = new DataSet();
            adp.Fill(dsParent);
            int row = dsParent.Tables[0].Rows.Count;

            //Parent Info
            if (row > 0) {
                idCard = dsParent.Tables[0].Rows[0]["strIdCard"].ToString();
                fullNameEN = dsParent.Tables[0].Rows[0]["fullNameEn"].ToString();
                fullNameTH = dsParent.Tables[0].Rows[0]["fullNameTh"].ToString();
                firstNameEN = dsParent.Tables[0].Rows[0]["enFirstName"].ToString();
                lastNameEN = dsParent.Tables[0].Rows[0]["enLastName"].ToString();
                age = dsParent.Tables[0].Rows[0]["age"].ToString();
                //ที่อยู่
                noPermanent = dsParent.Tables[0].Rows[0]["noPermanent"].ToString();
                mooPermanent = dsParent.Tables[0].Rows[0]["mooPermanent"].ToString();
                soiPermanent = dsParent.Tables[0].Rows[0]["soiPermanent"].ToString();
                roadPermanent = dsParent.Tables[0].Rows[0]["roadPermanent"].ToString();
                subdistrictNameTH = dsParent.Tables[0].Rows[0]["thSubdistrictName"].ToString();
                subdistrictNameEN = dsParent.Tables[0].Rows[0]["enSubdistrictName"].ToString();
                districtNameTH = dsParent.Tables[0].Rows[0]["thDistrictName"].ToString();
                districtNameEN = dsParent.Tables[0].Rows[0]["enDistrictName"].ToString();                
                provinceNameTH = dsParent.Tables[0].Rows[0]["provinceNameTH"].ToString();
                provinceNameEN = dsParent.Tables[0].Rows[0]["provinceNameEN"].ToString();
                zipcodePermanent = dsParent.Tables[0].Rows[0]["zipcodePermanent"].ToString();
                phoneNumberPermanent = dsParent.Tables[0].Rows[0]["phoneParent"].ToString();
                mobileNumberPermanent = dsParent.Tables[0].Rows[0]["mobileParent"].ToString();
                //อาชีพ
                occupationTH = dsParent.Tables[0].Rows[0]["thOccupation"].ToString();
                occupationEN = dsParent.Tables[0].Rows[0]["enOccupation"].ToString();
                position = dsParent.Tables[0].Rows[0]["position"].ToString();//ตำแหน่ง
                                                                               //สังกัดด
                agencyNameTH = dsParent.Tables[0].Rows[0]["agencyNameTH"].ToString();
                agencyNameEN = dsParent.Tables[0].Rows[0]["agencyNameEN"].ToString();
                checkAlive = dsParent.Tables[0].Rows[0]["alive"].ToString();
                checkConfirmParent = dsParent.Tables[0].Rows[0]["confirmStatus"].ToString();
                password = dsParent.Tables[0].Rows[0]["password"].ToString();
                nationalityID = dsParent.Tables[0].Rows[0]["perNationalityId"].ToString();
            }
        }

        public void SetEmpty() {
            idCard = "";
            fullNameTH = "";
            fullNameEN = "";
            age = "";
            noPermanent = "";
            mooPermanent = "";
            soiPermanent = "";
            roadPermanent = "";
            subdistrictNameTH = "";
            subdistrictNameEN = "";
            districtNameTH = "";
            districtNameEN = "";
            provinceNameEN = "";
            provinceNameTH = "";
            zipcodePermanent = "";
            phoneNumberPermanent = "";
            mobileNumberPermanent = "";
            position = "";
            occupationTH = "";
            occupationEN = "";
            agencyNameTH = "";
            agencyNameEN = "";
            checkAlive = "";
            checkConfirmParent = "";
            password = "";
            nationalityID = "";
        }

        //ตรวจสอบข้อมูลก่อนทำสัญญาค้ำประกัน สัญญาให้ความยินยอม
        public void GetCheckDataParent() {
            if (fullNameTH == "" ||
                idCard == "" ||
                mobileNumberPermanent == "" ||
                age == "" ||
                noPermanent == "" ||
                subdistrictNameTH == "" ||
                districtNameTH == "" ||
                provinceNameTH == "" ||
                zipcodePermanent == "") {
                checkDataParent = "N";
            }
        }
    }
}