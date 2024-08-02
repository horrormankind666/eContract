using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for CurDate
/// </summary>
namespace eContract
{


    public class CurDate
    {

        string _dateLongTh;

        public string DateLongTh
        {
            get { return _dateLongTh; }
            set { _dateLongTh = value; }
        }



        string _dateMidTh;

        public string DateMidTh
        {
            get { return _dateMidTh; }
            set { _dateMidTh = value; }
        }
        string _dateTh;

        public string DateTh
        {
            get { return _dateTh; }
            set { _dateTh = value; }
        }
        string _dateLongEn;

        public string DateLongEn
        {
            get { return _dateLongEn; }
            set { _dateLongEn = value; }
        }
        string _dateMidEn;

        public string DateMidEn
        {
            get { return _dateMidEn; }
            set { _dateMidEn = value; }
        }
        string _dateEn;

        public string DateEn
        {
            get { return _dateEn; }
            set { _dateEn = value; }
        }
        string _dateISO;

        public string DateISO
        {
            get { return _dateISO; }
            set { _dateISO = value; }
        }
        string _day;

        public string Day
        {
            get { return _day; }
            set { _day = value; }
        }
        string _monthNameEn;

        public string MonthNameEn
        {
            get { return _monthNameEn; }
            set { _monthNameEn = value; }
        }
        string _monthNameTh;

        public string MonthNameTh
        {
            get { return _monthNameTh; }
            set { _monthNameTh = value; }
        }
        string _yearEn;

        public string YearEn
        {
            get { return _yearEn; }
            set { _yearEn = value; }
        }
        string _yearTh;

        public string YearTh
        {
            get { return _yearTh; }
            set { _yearTh = value; }
        }
        string _date;

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        string _strDateLongTh;

        public string StrDateLongTh
        {
            get { return _strDateLongTh; }
            set { _strDateLongTh = value; }
        }
        string _strDateLongEn;

        public string StrDateLongEn
        {
            get { return _strDateLongEn; }
            set { _strDateLongEn = value; }
        }


        public CurDate()
        {
            //
            // TODO: Add constructor logic here
            //

            GetInfo();
        }




        private void GetInfo()
        {

            SetEmpty();

            string _query = "sp_sysGetDate";
            SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            SqlDataAdapter _adp = new SqlDataAdapter(_query, _con);
            DataSet _ds = new DataSet();
            _adp.Fill(_ds);
            int _row = _ds.Tables[0].Rows.Count;

            // Parent Info
            if (_row > 0)
            {

                _dateLongTh = _ds.Tables[0].Rows[0]["dateLognTh"].ToString();
                _dateMidTh = _ds.Tables[0].Rows[0]["dateMidTh"].ToString();
                _dateTh = _ds.Tables[0].Rows[0]["dateTh"].ToString();
                _dateLongEn = _ds.Tables[0].Rows[0]["dateLongEn"].ToString();
                _dateMidEn = _ds.Tables[0].Rows[0]["dateMidEn"].ToString();
                _dateEn = _ds.Tables[0].Rows[0]["dateEn"].ToString();
                _dateISO = _ds.Tables[0].Rows[0]["dateISO"].ToString();
                _day = _ds.Tables[0].Rows[0]["cDay"].ToString();
                _monthNameEn = _ds.Tables[0].Rows[0]["cMonthNameEn"].ToString();
                _monthNameTh = _ds.Tables[0].Rows[0]["cMonthNameTh"].ToString();
                _yearEn = _ds.Tables[0].Rows[0]["yearEn"].ToString();
                _yearTh = _ds.Tables[0].Rows[0]["YearTh"].ToString();
                _date = _ds.Tables[0].Rows[0]["cDate"].ToString();
                _strDateLongTh = _day + " เดือน " + _monthNameTh + " พ.ศ. " + _yearTh;
                _strDateLongEn = _day + " " + _monthNameEn + " ค.ศ. " + _yearTh;

            }



        }


        public void SetEmpty()
        {

            _dateLongTh = "";
            _dateMidTh = "";
            _dateTh = "";
            _dateLongEn = "";
            _dateMidEn = "";
            _dateEn = "";
            _dateISO = "";
            _day = "";
            _monthNameEn = "";
            _monthNameTh = "";
            _yearEn = "";
            _yearTh = "";
            _date = "";
            _strDateLongEn = "";
            _strDateLongTh = "";


        }


    }
}