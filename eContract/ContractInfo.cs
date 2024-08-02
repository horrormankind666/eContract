using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ContractInfo
/// </summary>
namespace eContract
{


    public class ContractInfo
    {

        string _acaYear;

        public string AcaYear
        {
            get { return _acaYear; }
            set { _acaYear = value; }
        }

        string _studentId;

        public string StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }


        string _studentCode;

        public string StudentCode
        {
            get { return _studentCode; }
            set { _studentCode = value; }
        }


        string _programId;

        public string ProgramId
        {
            get { return _programId; }
            set { _programId = value; }
        }

        string _quotaCode;

        public string QuotaCode
        {
            get { return _quotaCode; }
            set { _quotaCode = value; }
        }

        string _idCardFather;

        public string IdCardFather
        {
            get { return _idCardFather; }
            set { _idCardFather = value; }
        }

        string _idCardMother;

        public string IdCardMother
        {
            get { return _idCardMother; }
            set { _idCardMother = value; }
        }

        string _signStudent;

        public string SignStudent
        {
            get { return _signStudent; }
            set { _signStudent = value; }
        }

        string _signParent1;

        public string SignParent1
        {
            get { return _signParent1; }
            set { _signParent1 = value; }
        }

        string _signParent2;

        public string SignParent2
        {
            get { return _signParent2; }
            set { _signParent2 = value; }
        }

        string _dateSignStudent;

        public string DateSignStudent
        {
            get { return _dateSignStudent; }
            set { _dateSignStudent = value; }
        }

        string _dateSignParent1;

        public string DateSignParent1
        {
            get { return _dateSignParent1; }
            set { _dateSignParent1 = value; }
        }

        string _dateSignParent2;

        public string DateSignParent2
        {
            get { return _dateSignParent2; }
            set { _dateSignParent2 = value; }
        }

        string _statusComplete;

        public string StatusComplete
        {
            get { return _statusComplete; }
            set { _statusComplete = value; }
        }

        string _statusSignStudent;



        public string StatusSignStudent
        {
            get { return _statusSignStudent; }
            set { _statusSignStudent = value; }
        }

        string _statusSignMother;

        public string StatusSignMother
        {
            get { return _statusSignMother; }
            set { _statusSignMother = value; }
        }


        string _statusSignFather;

        public string StatusSignFather
        {
            get { return _statusSignFather; }
            set { _statusSignFather = value; }
        }

        string _warrantBy;

        public string WarrantBy
        {
            get { return _warrantBy; }
            set { _warrantBy = value; }
        }

        string _signFather1;

        public string SignFather1
        {
            get { return _signFather1; }
            set { _signFather1 = value; }
        }

        string _signFather2;

        public string SignFather2
        {
            get { return _signFather2; }
            set { _signFather2 = value; }
        }

        string _signMother1;

        public string SignMother1
        {
            get { return _signMother1; }
            set { _signMother1 = value; }
        }

        string _signMother2;

        public string SignMother2
        {
            get { return _signMother2; }
            set { _signMother2 = value; }
        }


        string _isMarriage;

        public string IsMarriage
        {
            get { return _isMarriage; }
            set { _isMarriage = value; }
        }


        string _isAliveMother;

        public string IsAliveMother
        {
            get { return _isAliveMother; }
            set { _isAliveMother = value; }
        }

        string _isAliveFather;

        public string IsAliveFather
        {
            get { return _isAliveFather; }
            set { _isAliveFather = value; }
        }

        string _isLiveMother;

        public string IsLiveMother
        {
            get { return _isLiveMother; }
            set { _isLiveMother = value; }
        }

        string _isLiveFather;

        public string IsLiveFather
        {
            get { return _isLiveFather; }
            set { _isLiveFather = value; }
        }

        string _isLiveOther;

        public string IsLiveOther
        {
            get { return _isLiveOther; }
            set { _isLiveOther = value; }
        }

        string _isContactFatherMother;

        public string IsContactFatherMother
        {
            get { return _isContactFatherMother; }
            set { _isContactFatherMother = value; }
        }

        string _isData;

        public string IsData
        {
            get { return _isData; }
            set { _isData = value; }
        }

        string _docId;

        public string DocId
        {
            get { return _docId; }
            set { _docId = value; }
        }

        string _consentBy;

        public string ConsentBy
        {
            get { return _consentBy; }
            set { _consentBy = value; }
        }

        string _dateMidContractStudent;

        public string DateMidContractStudent
        {
            get { return _dateMidContractStudent; }
            set { _dateMidContractStudent = value; }
        }

        string _dateMidContractParent1;

        public string DateMidContractParent1
        {
            get { return _dateMidContractParent1; }
            set { _dateMidContractParent1 = value; }
        }

        string _dateMidContractParent2;

        public string DateMidContractParent2
        {
            get { return _dateMidContractParent2; }
            set { _dateMidContractParent2 = value; }
        }

        string _dateLongContractStudent;

        public string DateLongContractStudent
        {
            get { return _dateLongContractStudent; }
            set { _dateLongContractStudent = value; }
        }

        string _dateLongContractParent1;

        public string DateLongContractParent1
        {
            get { return _dateLongContractParent1; }
            set { _dateLongContractParent1 = value; }
        }

        string _dateLongContractParent2;

        public string DateLongContractParent2
        {
            get { return _dateLongContractParent2; }
            set { _dateLongContractParent2 = value; }
        }

        string _contractPath;

        public string contractPath
        {
            get { return _contractPath; }
            set { _contractPath = value; }
        }

        string _garranteePath;

        public string garranteePath
        {
            get { return _garranteePath; }
            set { _garranteePath = value; }
        }

        string _warranPath;
        public string warranPath
        {
            get { return _warranPath; }
            set { _warranPath = value; }
        }

        string _dayStd;
        public string dayStd
        {
            get { return _dayStd; }
            set { _dayStd = value; }
        }

        string _monthNameThStd;
        public string monthNameThStd
        {
            get { return _monthNameThStd; }
            set { _monthNameThStd = value; }
        }

        string _yearThStd;
        public string yearThStd
        {
            get { return _yearThStd; }
            set { _yearThStd = value; }
        }

        string _dayP1;
        public string dayP1
        {
            get { return _dayP1; }
            set { _dayP1 = value; }
        }

        string _monthNameThP1;
        public string monthNameThP1
        {
            get { return _monthNameThP1; }
            set { _monthNameThP1 = value; }
        }

        string _yearThP1;
        public string yearThP1
        {
            get { return _yearThP1; }
            set { _yearThP1 = value; }
        }

        string _dayP2;
        public string dayP2
        {
            get { return _dayP2; }
            set { _dayP2 = value; }
        }

        string _monthNameThP2;
        public string monthNameThP2
        {
            get { return _monthNameThP2; }
            set { _monthNameThP2 = value; }
        }

        string _yearThP2;
        public string yearThP2
        {
            get { return _yearThP2; }
            set { _yearThP2 = value; }
        }

        string _relationship;
        public string relationship
        {
            get { return _relationship; }
            set { _relationship = value; }
        }

        string _maritalStatus;
        public string maritalStatus
        {
            get { return _maritalStatus; }
            set { _maritalStatus = value; }
        }

        string _fatherUsername;
        public string FatherUsername
        {
            get { return _fatherUsername; }
            set { _fatherUsername = value; }
        }

        string _motherUsername;
        public string MotherUsername
        {
            get { return _motherUsername; }
            set { _motherUsername = value; }
        }



        public ContractInfo(string _studentId)
        {
            //
            // TODO: Add constructor logic here
            //
            GetInfo(_studentId);

        }

        public void GetInfo(string _studentId)
        {
            SetEmpty();
            string _query = "Sp_ectContractInfo '" + _studentId + "'";
            SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            SqlDataAdapter _adp = new SqlDataAdapter(_query, _con);
            DataSet _dsEctInfo = new DataSet();
            _adp.Fill(_dsEctInfo);
            int _rowInfo = _dsEctInfo.Tables[0].Rows.Count;


            if (_rowInfo > 0)
            {
                _isData = "Y";

                _acaYear = _dsEctInfo.Tables[0].Rows[0]["acaYear"].ToString();
                _studentId = _dsEctInfo.Tables[0].Rows[0]["studentId"].ToString();
                _studentCode = _dsEctInfo.Tables[0].Rows[0]["studentCode"].ToString();
                _programId = _dsEctInfo.Tables[0].Rows[0]["programId"].ToString();
                _quotaCode = _dsEctInfo.Tables[0].Rows[0]["quotaCode"].ToString();
                _idCardFather = _dsEctInfo.Tables[0].Rows[0]["FIdCard"].ToString();
                _idCardMother = _dsEctInfo.Tables[0].Rows[0]["MIdCard"].ToString();
                _signStudent = _dsEctInfo.Tables[0].Rows[0]["contractSignByStudent"].ToString();
                _signParent1 = _dsEctInfo.Tables[0].Rows[0]["contractSignByParent1"].ToString();
                _signParent2 = _dsEctInfo.Tables[0].Rows[0]["contractSignByParent2"].ToString();
                _signFather1 = _dsEctInfo.Tables[0].Rows[0]["parentContractSignFlagF1"].ToString();
                _signFather2 = _dsEctInfo.Tables[0].Rows[0]["parentContractSignFlagF2"].ToString();
                _signMother1 = _dsEctInfo.Tables[0].Rows[0]["parentContractSignFlagM1"].ToString();
                _signMother2 = _dsEctInfo.Tables[0].Rows[0]["parentContractSignFlagM2"].ToString();
                _dateSignStudent = _dsEctInfo.Tables[0].Rows[0]["contractDateSignByStudent"].ToString();
                _dateSignParent1 = _dsEctInfo.Tables[0].Rows[0]["contractDateSignByParent1"].ToString();
                _dateSignParent2 = _dsEctInfo.Tables[0].Rows[0]["contractDateSignByParent2"].ToString();
                _statusComplete = _dsEctInfo.Tables[0].Rows[0]["operationType"].ToString();
                _statusSignStudent = _dsEctInfo.Tables[0].Rows[0]["signStudent"].ToString();
                _statusSignMother = _dsEctInfo.Tables[0].Rows[0]["signMother"].ToString();
                _statusSignFather = _dsEctInfo.Tables[0].Rows[0]["signFather"].ToString();
                _warrantBy = _dsEctInfo.Tables[0].Rows[0]["parentCode"].ToString();
                _isMarriage = _dsEctInfo.Tables[0].Rows[0]["marriage"].ToString();
                _maritalStatus = _dsEctInfo.Tables[0].Rows[0]["maritalStatus"].ToString();
                _isAliveMother = _dsEctInfo.Tables[0].Rows[0]["aliveM"].ToString();
                _isAliveFather = _dsEctInfo.Tables[0].Rows[0]["aliveF"].ToString();
                _isLiveMother = _dsEctInfo.Tables[0].Rows[0]["liveWithM"].ToString();
                _isLiveFather = _dsEctInfo.Tables[0].Rows[0]["liveWithF"].ToString();
                _isLiveOther = _dsEctInfo.Tables[0].Rows[0]["liveWithOther"].ToString();
                _isContactFatherMother = _dsEctInfo.Tables[0].Rows[0]["contactFM"].ToString();
                _docId = _dsEctInfo.Tables[0].Rows[0]["id"].ToString();
                _consentBy = _dsEctInfo.Tables[0].Rows[0]["consentBy"].ToString();
                _dateMidContractStudent = _dsEctInfo.Tables[0].Rows[0]["dateThMidContractStudent"].ToString();
                _dateMidContractParent1 = _dsEctInfo.Tables[0].Rows[0]["dateThMidContractParent1"].ToString();
                _dateMidContractParent2 = _dsEctInfo.Tables[0].Rows[0]["dateThMidContractParent2"].ToString();
                _dateLongContractStudent = _dsEctInfo.Tables[0].Rows[0]["dateThLongContractStudent"].ToString();
                _dateLongContractParent1 = _dsEctInfo.Tables[0].Rows[0]["dateThLongContractParent1"].ToString();
                _dateLongContractParent2 = _dsEctInfo.Tables[0].Rows[0]["dateThLongContractParent2"].ToString();
                _contractPath = _dsEctInfo.Tables[0].Rows[0]["contractPath"].ToString();
                _garranteePath = _dsEctInfo.Tables[0].Rows[0]["garranteePath"].ToString();
                _warranPath = _dsEctInfo.Tables[0].Rows[0]["warranPath"].ToString();
                _dayStd = _dsEctInfo.Tables[0].Rows[0]["DayStd"].ToString();//วันที่นักศึกษาทำสัญญา
                _monthNameThStd = _dsEctInfo.Tables[0].Rows[0]["monthNameThStd"].ToString();//เดือนที่นักศึกษาทำสัญญา
                _yearThStd = _dsEctInfo.Tables[0].Rows[0]["yearThStd"].ToString();//ปีที่ที่นักศึกษาทำสัญญา
                _dayP1 = _dsEctInfo.Tables[0].Rows[0]["DayP1"].ToString();//ผู้ค้ำ
                _monthNameThP1 = _dsEctInfo.Tables[0].Rows[0]["monthNameThP1"].ToString();
                _yearThP1 = _dsEctInfo.Tables[0].Rows[0]["yearThP1"].ToString();
                _dayP2 = _dsEctInfo.Tables[0].Rows[0]["DayP2"].ToString();//ผู้แทนโดยชอบธรรม
                _monthNameThP2 = _dsEctInfo.Tables[0].Rows[0]["monthNameThP2"].ToString();
                _yearThP2 = _dsEctInfo.Tables[0].Rows[0]["yearThP2"].ToString();
                _relationship = _dsEctInfo.Tables[0].Rows[0]["relationship"].ToString();
                _fatherUsername = _dsEctInfo.Tables[0].Rows[0]["FatherUsername"].ToString();
                _motherUsername = _dsEctInfo.Tables[0].Rows[0]["MotherUsername"].ToString();
            }

        }

        public void SetEmpty()
        {
            _acaYear = "";
            _studentId = "";
            _studentCode = "";
            _programId = "";
            _quotaCode = "";
            _idCardFather = "";
            _idCardMother = "";
            _signStudent = "";
            _signParent1 = "";
            _signParent2 = "";
            _signFather1 = "";
            _signFather2 = "";
            _signMother1 = "";
            _signMother2 = "";
            _dateSignStudent = "";
            _dateSignParent1 = "";
            _dateSignParent2 = "";
            _statusComplete = "";
            _statusSignStudent = "N";
            _statusSignMother = "N";
            _statusSignFather = "N";
            _warrantBy = "";
            _isMarriage = "";
            _maritalStatus = "";
            _isAliveMother = "";
            _isAliveFather = "";
            _isLiveMother = "";
            _isLiveFather = "";
            _isLiveOther = "";
            _isContactFatherMother = "";
            _isData = "N";
            _docId = "";
            _consentBy = "";
            _dateMidContractStudent = "";
            _dateMidContractParent1 = "";
            _dateMidContractParent2 = "";
            _dateLongContractStudent = "";
            _dateLongContractParent1 = "";
            _dateLongContractParent2 = "";
            _contractPath = "";
            _garranteePath = "";
            _warranPath = "";
            _dayStd = "";
            _monthNameThStd = "";
            _yearThStd = "";
            _dayP1 = "";
            _monthNameThP1 = "";
            _yearThP1 = "";
            _dayP2 = "";
            _monthNameThP2 = "";
            _yearThP2 = "";
            _relationship = "";
        }

        public static string IsParentSuccess(ContractInfo _ctInfo, string _parentType)
        {
            string _isSuccess = "0";
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
            else if (_ctInfo.StatusComplete == "S" || (_ctInfo.SignParent1 == "True" && _ctInfo.SignParent2 == "True"))
            {

                _isSuccess = "1";
            }

            return _isSuccess;

        }
    }
}