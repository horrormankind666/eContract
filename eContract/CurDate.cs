using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eContract {
    public class CurDate {
        string dateLongTH;
        public string DateLongTH {
            get { return dateLongTH; }
            set { dateLongTH = value; }
        }

        string dateMidTH;
        public string DateMidTH {
            get { return dateMidTH; }
            set { dateMidTH = value; }
        }

        string dateTH;
        public string DateTH {
            get { return dateTH; }
            set { dateTH = value; }
        }

        string dateLongEN;
        public string DateLongEN {
            get { return dateLongEN; }
            set { dateLongEN = value; }
        }
        
        string dateMidEN;
        public string DateMidEN {
            get { return dateMidEN; }
            set { dateMidEN = value; }
        }

        string dateEN;
        public string DateEN {
            get { return dateEN; }
            set { dateEN = value; }
        }

        string dateISO;
        public string DateISO {
            get { return dateISO; }
            set { dateISO = value; }
        }

        string day;
        public string Day {
            get { return day; }
            set { day = value; }
        }

        string monthNameEN;
        public string MonthNameEN {
            get { return monthNameEN; }
            set { monthNameEN = value; }
        }

        string monthNameTH;
        public string MonthNameTH {
            get { return monthNameTH; }
            set { monthNameTH = value; }
        }

        string yearEN;
        public string YearEN {
            get { return yearEN; }
            set { yearEN = value; }
        }

        string yearTH;
        public string YearTH {
            get { return yearTH; }
            set { yearTH = value; }
        }

        string date;
        public string Date {
            get { return date; }
            set { date = value; }
        }

        string strDateLongTH;
        public string StrDateLongTH {
            get { return strDateLongTH; }
            set { strDateLongTH = value; }
        }

        string strDateLongEN;
        public string StrDateLongEN {
            get { return strDateLongEN; }
            set { strDateLongEN = value; }
        }

        public CurDate() {
            GetInfo();
        }

        private void GetInfo() {
            SetEmpty();

            string query = "sp_sysGetDate";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            int row = ds.Tables[0].Rows.Count;

            //parent info
            if (row > 0) {
                dateLongTH = ds.Tables[0].Rows[0]["dateLognTh"].ToString();
                dateMidTH = ds.Tables[0].Rows[0]["dateMidTh"].ToString();
                dateTH = ds.Tables[0].Rows[0]["dateTh"].ToString();
                dateLongEN = ds.Tables[0].Rows[0]["dateLongEn"].ToString();
                dateMidEN = ds.Tables[0].Rows[0]["dateMidEn"].ToString();
                dateEN = ds.Tables[0].Rows[0]["dateEn"].ToString();
                dateISO = ds.Tables[0].Rows[0]["dateISO"].ToString();
                day = ds.Tables[0].Rows[0]["cDay"].ToString();
                monthNameEN = ds.Tables[0].Rows[0]["cMonthNameEn"].ToString();
                monthNameTH = ds.Tables[0].Rows[0]["cMonthNameTh"].ToString();
                yearEN = ds.Tables[0].Rows[0]["yearEn"].ToString();
                yearTH = ds.Tables[0].Rows[0]["YearTh"].ToString();
                date = ds.Tables[0].Rows[0]["cDate"].ToString();
                strDateLongTH = (day + " เดือน " + monthNameTH + " พ.ศ. " + yearTH);
                strDateLongEN = (day + " " + monthNameEN + " ค.ศ. " + yearTH);
            }
        }

        public void SetEmpty() {
            dateLongTH = "";
            dateMidTH = "";
            dateTH = "";
            dateLongEN = "";
            dateMidEN = "";
            dateEN = "";
            dateISO = "";
            day = "";
            monthNameEN = "";
            monthNameTH = "";
            yearEN = "";
            yearTH = "";
            date = "";
            strDateLongEN = "";
            strDateLongTH = "";
        }
    }
}