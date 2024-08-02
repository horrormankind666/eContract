using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ParentInfo
/// </summary>
namespace eContract
{
    public class ParentInfo
    {

        string _idCard;

        public string IdCard
        {
            get { return _idCard; }
            set { _idCard = value; }
        }
        string _fullNameTh;

        public string FullNameTh
        {
            get { return _fullNameTh; }
            set { _fullNameTh = value; }
        }
        string _fullNameEn;

        public string FullNameEn
        {
            get { return _fullNameEn; }
            set { _fullNameEn = value; }
        }
        string _position;

        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }

        string _age;

        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }

        string _noPermanent;

        public string NoPermanent
        {
            get { return _noPermanent; }
            set { _noPermanent = value; }
        }
        string _mooPermanent;

        public string MooPermanent
        {
            get { return _mooPermanent; }
            set { _mooPermanent = value; }
        }
        string _soiPermanent;

        public string SoiPermanent
        {
            get { return _soiPermanent; }
            set { _soiPermanent = value; }
        }
        string _roadPermanent;

        public string RoadPermanent
        {
            get { return _roadPermanent; }
            set { _roadPermanent = value; }
        }


        string _thSubdistrictName;

        public string ThSubdistrictName
        {
            get { return _thSubdistrictName; }
            set { _thSubdistrictName = value; }
        }
        string _enSubdistrictName;

        public string EnSubdistrictName
        {
            get { return _enSubdistrictName; }
            set { _enSubdistrictName = value; }
        }
        string _thDistrictName;

        public string ThDistrictName
        {
            get { return _thDistrictName; }
            set { _thDistrictName = value; }
        }
        string _enDistrictName;

        public string EnDistrictName
        {
            get { return _enDistrictName; }
            set { _enDistrictName = value; }
        }

        string _provinceNameTH;

        public string ProvinceNameTH
        {
            get { return _provinceNameTH; }
            set { _provinceNameTH = value; }
        }
        string _provinceNameEN;

        public string ProvinceNameEN
        {
            get { return _provinceNameEN; }
            set { _provinceNameEN = value; }
        }
        string _zipCodePermanent;

        public string ZipCodePermanent
        {
            get { return _zipCodePermanent; }
            set { _zipCodePermanent = value; }
        }
        string _phoneNumberPermanent;

        public string PhoneNumberPermanent
        {
            get { return _phoneNumberPermanent; }
            set { _phoneNumberPermanent = value; }
        }

        string _mobileNumberPermanent;

        public string MobileNumberPermanent
        {
            get { return _mobileNumberPermanent; }
            set { _mobileNumberPermanent = value; }
        }

        string _thOccupation;

        public string ThOccupation
        {
            get { return _thOccupation; }
            set { _thOccupation = value; }
        }

        string _enOccupation;

        public string EnOccupation
        {
            get { return _enOccupation; }
            set { _enOccupation = value; }
        }

        string _agencyNameEN;

        public string AgencyNameEN
        {
            get { return _agencyNameEN; }
            set { _agencyNameEN = value; }
        }

        string _agencyNameTH;

        public string AgencyNameTH
        {
            get { return _agencyNameTH; }
            set { _agencyNameTH = value; }
        }

        string _isData;

        public string IsData
        {
            get { return _isData; }
            set { _isData = value; }
        }

        string _checkDataParent = "Y";

        public string CheckDataParent
        {
            get { return _checkDataParent; }
            set { _checkDataParent = value; }
        }

        string _checkAlive;
        public string checkAlive
        {
            get { return _checkAlive; }
            set { _checkAlive = value; }
        }

        string _checkConfirmParent;
        public string CheckConfirmParent
        {
            get { return _checkConfirmParent; }
            set { _checkConfirmParent = value; }
        }

        string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        //check confirm 2019-08-19

        string _enFirstName;
        public string enFirstName
        {
            get { return _enFirstName; }
            set { _enFirstName = value; }
        }

        string _enLastName;
        public string enLastName
        {
            get { return _enLastName; }
            set { _enLastName = value; }
        }


        string _nationalityId;
        public string nationalityId
        {
            get { return _nationalityId; }
            set { _nationalityId = value; }
        }



        public ParentInfo(string _studentId, string _parentType)
        {
            //
            // TODO: Add constructor logic here
            GetInfo(_studentId, _parentType);
            GetCheckDataParent();
            //
        }


        private void GetInfo(string _studentId, string _parentType)
        {
            SetEmpty();
            string _query = "sp_ectParentInfo '" + _studentId + "','" + _parentType + "'";
            SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            SqlDataAdapter _adp = new SqlDataAdapter(_query, _con);
            DataSet _dsParent = new DataSet();
            _adp.Fill(_dsParent);
            int _row = _dsParent.Tables[0].Rows.Count;


            // Parent Info
            if (_row > 0)
            {
                _idCard = _dsParent.Tables[0].Rows[0]["strIdCard"].ToString();
                _fullNameEn = _dsParent.Tables[0].Rows[0]["fullNameEn"].ToString();
                _fullNameTh = _dsParent.Tables[0].Rows[0]["fullNameTh"].ToString();
                _enFirstName = _dsParent.Tables[0].Rows[0]["enFirstName"].ToString();
                _enLastName = _dsParent.Tables[0].Rows[0]["enLastName"].ToString();
                _age = _dsParent.Tables[0].Rows[0]["age"].ToString();
                //ที่อยู่
                _noPermanent = _dsParent.Tables[0].Rows[0]["noPermanent"].ToString();
                _mooPermanent = _dsParent.Tables[0].Rows[0]["mooPermanent"].ToString();
                _soiPermanent = _dsParent.Tables[0].Rows[0]["soiPermanent"].ToString();
                _roadPermanent = _dsParent.Tables[0].Rows[0]["roadPermanent"].ToString();
                _thSubdistrictName = _dsParent.Tables[0].Rows[0]["thSubdistrictName"].ToString();
                _enSubdistrictName = _dsParent.Tables[0].Rows[0]["enSubdistrictName"].ToString();
                _thDistrictName = _dsParent.Tables[0].Rows[0]["thDistrictName"].ToString();
                _enDistrictName = _dsParent.Tables[0].Rows[0]["enDistrictName"].ToString();
                _provinceNameEN = _dsParent.Tables[0].Rows[0]["provinceNameEN"].ToString();
                _provinceNameTH = _dsParent.Tables[0].Rows[0]["provinceNameTH"].ToString();
                _zipCodePermanent = _dsParent.Tables[0].Rows[0]["zipCodePermanent"].ToString();
                _phoneNumberPermanent = _dsParent.Tables[0].Rows[0]["phoneParent"].ToString();
                _mobileNumberPermanent = _dsParent.Tables[0].Rows[0]["mobileParent"].ToString();
                //อาชีพ
                _thOccupation = _dsParent.Tables[0].Rows[0]["thOccupation"].ToString();
                _enOccupation = _dsParent.Tables[0].Rows[0]["enOccupation"].ToString();
                _position = _dsParent.Tables[0].Rows[0]["position"].ToString();//ตำแหน่ง
                                                                               //สังกัดด
                _agencyNameTH = _dsParent.Tables[0].Rows[0]["agencyNameTH"].ToString();
                _agencyNameEN = _dsParent.Tables[0].Rows[0]["agencyNameEN"].ToString();
                _checkAlive = _dsParent.Tables[0].Rows[0]["alive"].ToString();
                _checkConfirmParent = _dsParent.Tables[0].Rows[0]["confirmStatus"].ToString();
                _password = _dsParent.Tables[0].Rows[0]["password"].ToString();
                //Nationality Id
                _nationalityId = _dsParent.Tables[0].Rows[0]["perNationalityId"].ToString();
            }



        }


        public void SetEmpty()
        {
            _idCard = "";
            _fullNameTh = "";
            _fullNameEn = "";
            _age = "";
            _noPermanent = "";
            _mooPermanent = "";
            _soiPermanent = "";
            _roadPermanent = "";
            _thSubdistrictName = "";
            _enSubdistrictName = "";
            _thDistrictName = "";
            _enDistrictName = "";
            _provinceNameEN = "";
            _provinceNameTH = "";
            _zipCodePermanent = "";
            _phoneNumberPermanent = "";
            _mobileNumberPermanent = "";
            _position = "";
            _thOccupation = "";
            _enOccupation = "";
            _agencyNameTH = "";
            _agencyNameEN = "";
            _checkAlive = "";
            _checkConfirmParent = "";
            _password = "";
            _nationalityId = "";
        }

        //ตรวจสอบข้อมูลก่อนทำสัญญาค้ำประกัน สัญญาให้ความยินยอม
        public void GetCheckDataParent()
        {

            if (_fullNameTh == "" || _idCard == "" || _mobileNumberPermanent == "" || _age == "" || _noPermanent == "" || _thSubdistrictName == "" || _thDistrictName == "" || _provinceNameTH == "" || _zipCodePermanent == "")
            {
                _checkDataParent = "N";
            }

        }
    }
}