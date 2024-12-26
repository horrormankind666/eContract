using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eContract {
    public class ContractInfo {
        string acaYear;
        public string AcaYear {
            get { return acaYear; }
            set { acaYear = value; }
        }

        string studentID;
        public string StudentID {
            get { return studentID; }
            set { studentID = value; }
        }

        string studentCode;
        public string StudentCode {
            get { return studentCode; }
            set { studentCode = value; }
        }

        string programID;
        public string ProgramID {
            get { return programID; }
            set { programID = value; }
        }

        string quotaCode;
        public string QuotaCode {
            get { return quotaCode; }
            set { quotaCode = value; }
        }

        string idCardFather;
        public string IDCardFather {
            get { return idCardFather; }
            set { idCardFather = value; }
        }

        string idCardMother;
        public string IDCardMother {
            get { return idCardMother; }
            set { idCardMother = value; }
        }

        string signStudent;
        public string SignStudent {
            get { return signStudent; }
            set { signStudent = value; }
        }

        string signParent1;
        public string SignParent1 {
            get { return signParent1; }
            set { signParent1 = value; }
        }

        string signParent2;
        public string SignParent2 {
            get { return signParent2; }
            set { signParent2 = value; }
        }

        string dateSignStudent;
        public string DateSignStudent {
            get { return dateSignStudent; }
            set { dateSignStudent = value; }
        }

        string dateSignParent1;
        public string DateSignParent1 {
            get { return dateSignParent1; }
            set { dateSignParent1 = value; }
        }

        string dateSignParent2;
        public string DateSignParent2 {
            get { return dateSignParent2; }
            set { dateSignParent2 = value; }
        }

        string statusComplete;
        public string StatusComplete {
            get { return statusComplete; }
            set { statusComplete = value; }
        }

        string statusSignStudent;
        public string StatusSignStudent {
            get { return statusSignStudent; }
            set { statusSignStudent = value; }
        }

        string statusSignMother;
        public string StatusSignMother {
            get { return statusSignMother; }
            set { statusSignMother = value; }
        }

        string statusSignFather;
        public string StatusSignFather {
            get { return statusSignFather; }
            set { statusSignFather = value; }
        }

        string warrantBy;
        public string WarrantBy {
            get { return warrantBy; }
            set { warrantBy = value; }
        }

        string signFather1;
        public string SignFather1 {
            get { return signFather1; }
            set { signFather1 = value; }
        }

        string signFather2;
        public string SignFather2 {
            get { return signFather2; }
            set { signFather2 = value; }
        }

        string signMother1;
        public string SignMother1 {
            get { return signMother1; }
            set { signMother1 = value; }
        }

        string signMother2;
        public string SignMother2 {
            get { return signMother2; }
            set { signMother2 = value; }
        }

        string isMarriage;
        public string IsMarriage {
            get { return isMarriage; }
            set { isMarriage = value; }
        }

        string isAliveMother;
        public string IsAliveMother {
            get { return isAliveMother; }
            set { isAliveMother = value; }
        }

        string isAliveFather;
        public string IsAliveFather {
            get { return isAliveFather; }
            set { isAliveFather = value; }
        }

        string isLiveMother;
        public string IsLiveMother {
            get { return isLiveMother; }
            set { isLiveMother = value; }
        }

        string isLiveFather;
        public string IsLiveFather {
            get { return isLiveFather; }
            set { isLiveFather = value; }
        }

        string isLiveOther;
        public string IsLiveOther {
            get { return isLiveOther; }
            set { isLiveOther = value; }
        }

        string isContactFatherMother;
        public string IsContactFatherMother {
            get { return isContactFatherMother; }
            set { isContactFatherMother = value; }
        }

        string isData;
        public string IsData {
            get { return isData; }
            set { isData = value; }
        }

        string docID;
        public string DocID {
            get { return docID; }
            set { docID = value; }
        }

        string consentBy;
        public string ConsentBy {
            get { return consentBy; }
            set { consentBy = value; }
        }

        string dateMidContractStudent;
        public string DateMidContractStudent {
            get { return dateMidContractStudent; }
            set { dateMidContractStudent = value; }
        }

        string dateMidContractParent1;
        public string DateMidContractParent1 {
            get { return dateMidContractParent1; }
            set { dateMidContractParent1 = value; }
        }

        string dateMidContractParent2;
        public string DateMidContractParent2 {
            get { return dateMidContractParent2; }
            set { dateMidContractParent2 = value; }
        }

        string dateLongContractStudent;
        public string DateLongContractStudent {
            get { return dateLongContractStudent; }
            set { dateLongContractStudent = value; }
        }

        string dateLongContractParent1;
        public string DateLongContractParent1 {
            get { return dateLongContractParent1; }
            set { dateLongContractParent1 = value; }
        }

        string dateLongContractParent2;
        public string DateLongContractParent2 {
            get { return dateLongContractParent2; }
            set { dateLongContractParent2 = value; }
        }

        string contractPath;
        public string ContractPath {
            get { return contractPath; }
            set { contractPath = value; }
        }

        string garranteePath;
        public string GarranteePath {
            get { return garranteePath; }
            set { garranteePath = value; }
        }

        string warranPath;
        public string WarranPath {
            get { return warranPath; }
            set { warranPath = value; }
        }

        string dayStd;
        public string DayStd {
            get { return dayStd; }
            set { dayStd = value; }
        }

        string monthNameTHStd;
        public string MonthNameTHStd {
            get { return monthNameTHStd; }
            set { monthNameTHStd = value; }
        }

        string yearTHStd;
        public string YearTHStd {
            get { return yearTHStd; }
            set { yearTHStd = value; }
        }

        string dayP1;
        public string DayP1 {
            get { return dayP1; }
            set { dayP1 = value; }
        }

        string monthNameTHP1;
        public string MonthNameTHP1 {
            get { return monthNameTHP1; }
            set { monthNameTHP1 = value; }
        }

        string yearTHP1;
        public string YearTHP1 {
            get { return yearTHP1; }
            set { yearTHP1 = value; }
        }

        string dayP2;
        public string DayP2 {
            get { return dayP2; }
            set { dayP2 = value; }
        }

        string monthNameTHP2;
        public string MonthNameTHP2 {
            get { return monthNameTHP2; }
            set { monthNameTHP2 = value; }
        }

        string yearTHP2;
        public string YearTHP2 {
            get { return yearTHP2; }
            set { yearTHP2 = value; }
        }

        string relationship;
        public string Relationship {
            get { return relationship; }
            set { relationship = value; }
        }

        string maritalStatus;
        public string MaritalStatus {
            get { return maritalStatus; }
            set { maritalStatus = value; }
        }

        string fatherUsername;
        public string FatherUsername {
            get { return fatherUsername; }
            set { fatherUsername = value; }
        }

        string motherUsername;
        public string MotherUsername {
            get { return motherUsername; }
            set { motherUsername = value; }
        }

        public ContractInfo(string studentID) {
            GetInfo(studentID);
        }

        public void GetInfo(string studentID) {
            SetEmpty();

            string query = ("Sp_ectContractInfo '" + studentID + "'");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataSet dsEctInfo = new DataSet();
            adp.Fill(dsEctInfo);
            int rowInfo = dsEctInfo.Tables[0].Rows.Count;

            if (rowInfo > 0) {
                isData = "Y";

                acaYear = dsEctInfo.Tables[0].Rows[0]["acaYear"].ToString();
                studentID = dsEctInfo.Tables[0].Rows[0]["studentId"].ToString();
                studentCode = dsEctInfo.Tables[0].Rows[0]["studentCode"].ToString();
                programID = dsEctInfo.Tables[0].Rows[0]["programId"].ToString();
                quotaCode = dsEctInfo.Tables[0].Rows[0]["quotaCode"].ToString();
                idCardFather = dsEctInfo.Tables[0].Rows[0]["FIdCard"].ToString();
                idCardMother = dsEctInfo.Tables[0].Rows[0]["MIdCard"].ToString();
                signStudent = dsEctInfo.Tables[0].Rows[0]["contractSignByStudent"].ToString();
                signParent1 = dsEctInfo.Tables[0].Rows[0]["contractSignByParent1"].ToString();
                signParent2 = dsEctInfo.Tables[0].Rows[0]["contractSignByParent2"].ToString();
                signFather1 = dsEctInfo.Tables[0].Rows[0]["parentContractSignFlagF1"].ToString();
                signFather2 = dsEctInfo.Tables[0].Rows[0]["parentContractSignFlagF2"].ToString();
                signMother1 = dsEctInfo.Tables[0].Rows[0]["parentContractSignFlagM1"].ToString();
                signMother2 = dsEctInfo.Tables[0].Rows[0]["parentContractSignFlagM2"].ToString();
                dateSignStudent = dsEctInfo.Tables[0].Rows[0]["contractDateSignByStudent"].ToString();
                dateSignParent1 = dsEctInfo.Tables[0].Rows[0]["contractDateSignByParent1"].ToString();
                dateSignParent2 = dsEctInfo.Tables[0].Rows[0]["contractDateSignByParent2"].ToString();
                statusComplete = dsEctInfo.Tables[0].Rows[0]["operationType"].ToString();
                statusSignStudent = dsEctInfo.Tables[0].Rows[0]["signStudent"].ToString();
                statusSignMother = dsEctInfo.Tables[0].Rows[0]["signMother"].ToString();
                statusSignFather = dsEctInfo.Tables[0].Rows[0]["signFather"].ToString();
                warrantBy = dsEctInfo.Tables[0].Rows[0]["parentCode"].ToString();
                isMarriage = dsEctInfo.Tables[0].Rows[0]["marriage"].ToString();
                maritalStatus = dsEctInfo.Tables[0].Rows[0]["maritalStatus"].ToString();
                isAliveMother = dsEctInfo.Tables[0].Rows[0]["aliveM"].ToString();
                isAliveFather = dsEctInfo.Tables[0].Rows[0]["aliveF"].ToString();
                isLiveMother = dsEctInfo.Tables[0].Rows[0]["liveWithM"].ToString();
                isLiveFather = dsEctInfo.Tables[0].Rows[0]["liveWithF"].ToString();
                isLiveOther = dsEctInfo.Tables[0].Rows[0]["liveWithOther"].ToString();
                isContactFatherMother = dsEctInfo.Tables[0].Rows[0]["contactFM"].ToString();
                docID = dsEctInfo.Tables[0].Rows[0]["id"].ToString();
                consentBy = dsEctInfo.Tables[0].Rows[0]["consentBy"].ToString();
                dateMidContractStudent = dsEctInfo.Tables[0].Rows[0]["dateThMidContractStudent"].ToString();
                dateMidContractParent1 = dsEctInfo.Tables[0].Rows[0]["dateThMidContractParent1"].ToString();
                dateMidContractParent2 = dsEctInfo.Tables[0].Rows[0]["dateThMidContractParent2"].ToString();
                dateLongContractStudent = dsEctInfo.Tables[0].Rows[0]["dateThLongContractStudent"].ToString();
                dateLongContractParent1 = dsEctInfo.Tables[0].Rows[0]["dateThLongContractParent1"].ToString();
                dateLongContractParent2 = dsEctInfo.Tables[0].Rows[0]["dateThLongContractParent2"].ToString();
                contractPath = dsEctInfo.Tables[0].Rows[0]["contractPath"].ToString();
                garranteePath = dsEctInfo.Tables[0].Rows[0]["garranteePath"].ToString();
                warranPath = dsEctInfo.Tables[0].Rows[0]["warranPath"].ToString();
                dayStd = dsEctInfo.Tables[0].Rows[0]["DayStd"].ToString(); // วันที่นักศึกษาทำสัญญา
                monthNameTHStd = dsEctInfo.Tables[0].Rows[0]["monthNameThStd"].ToString(); // เดือนที่นักศึกษาทำสัญญา
                yearTHStd = dsEctInfo.Tables[0].Rows[0]["yearThStd"].ToString(); // ปีที่ที่นักศึกษาทำสัญญา
                dayP1 = dsEctInfo.Tables[0].Rows[0]["DayP1"].ToString(); // ผู้ค้ำ
                monthNameTHP1 = dsEctInfo.Tables[0].Rows[0]["monthNameThP1"].ToString();
                yearTHP1 = dsEctInfo.Tables[0].Rows[0]["yearThP1"].ToString();
                dayP2 = dsEctInfo.Tables[0].Rows[0]["DayP2"].ToString(); // ผู้แทนโดยชอบธรรม
                monthNameTHP2 = dsEctInfo.Tables[0].Rows[0]["monthNameThP2"].ToString();
                yearTHP2 = dsEctInfo.Tables[0].Rows[0]["yearThP2"].ToString();
                relationship = dsEctInfo.Tables[0].Rows[0]["relationship"].ToString();
                fatherUsername = dsEctInfo.Tables[0].Rows[0]["FatherUsername"].ToString();
                motherUsername = dsEctInfo.Tables[0].Rows[0]["MotherUsername"].ToString();
            }
        }

        public void SetEmpty() {
            acaYear = "";
            studentID = "";
            studentCode = "";
            programID = "";
            quotaCode = "";
            idCardFather = "";
            idCardMother = "";
            signStudent = "";
            signParent1 = "";
            signParent2 = "";
            signFather1 = "";
            signFather2 = "";
            signMother1 = "";
            signMother2 = "";
            dateSignStudent = "";
            dateSignParent1 = "";
            dateSignParent2 = "";
            statusComplete = "";
            statusSignStudent = "N";
            statusSignMother = "N";
            statusSignFather = "N";
            warrantBy = "";
            isMarriage = "";
            maritalStatus = "";
            isAliveMother = "";
            isAliveFather = "";
            isLiveMother = "";
            isLiveFather = "";
            isLiveOther = "";
            isContactFatherMother = "";
            isData = "N";
            docID = "";
            consentBy = "";
            dateMidContractStudent = "";
            dateMidContractParent1 = "";
            dateMidContractParent2 = "";
            dateLongContractStudent = "";
            dateLongContractParent1 = "";
            dateLongContractParent2 = "";
            contractPath = "";
            garranteePath = "";
            warranPath = "";
            dayStd = "";
            monthNameTHStd = "";
            yearTHStd = "";
            dayP1 = "";
            monthNameTHP1 = "";
            yearTHP1 = "";
            dayP2 = "";
            monthNameTHP2 = "";
            yearTHP2 = "";
            relationship = "";
        }

        public static string IsParentSuccess(
            ContractInfo ctInfo,
            string parentType
        ) {
            string isSuccess = "0";

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
                    if (ctInfo.StatusComplete == "S" ||
                        (ctInfo.SignParent1 == "True" && ctInfo.SignParent2 == "True")) {
                        isSuccess = "1";
                    }
                }
            }

            return isSuccess;
        }
    }
}