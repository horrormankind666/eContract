//using authen;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for Myconfig
/// </summary>
namespace eContract
{


    public class Myconfig
    {
        public Myconfig()
        {

        }

        // กำหนดปีการศึกษาเป็นค่าเริ่มต้น
        public static CultureInfo th = System.Globalization.CultureInfo.GetCultureInfo("th-TH");

        public static CultureInfo en = System.Globalization.CultureInfo.GetCultureInfo("en-US");

        public static string _day = DateTime.Now.ToString("dd", th);
        public static string _month = DateTime.Now.ToString("MM", th);
        public static string _monthstring = DateTime.Now.ToString("MMMM", th);
        public static string _year = DateTime.Now.ToString("yyyy", th);
        public static string _yearEn = DateTime.Now.Year.ToString();
        public static string g_programcode = string.Empty;
        public static string g_quotacode = string.Empty;

        #region convert ascii

        /// <summary>
        /// Auther : Odd.Nopparat (Original-Thanakrit)
        /// Date   : 2015-03-20.
        /// Perpose: แปลงภาษาไทยให้เป็นแอสกี้
        /// Method : convertAscii
        /// Sample : "Odd.Nopparatap","XXX"
        /// </summary>
        public static string ConvertAscii(string _string)
        {
            string _x = string.Empty;
            if (_string != null && _string != "")
            {
                Encoding enc = Encoding.GetEncoding("tis-620");
                byte[] _arrByte = enc.GetBytes(_string.ToCharArray());
                foreach (byte _b in _arrByte)
                {
                    _x += _b.ToString() + "@#@";
                }
            }
            return _x;
        }

        #endregion convert ascii

        #region Storeproc dataset

        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-03-20.
        /// Perpose: รัน คิวรี่ ออกมาเป็น เซ็ต
        /// Method : ExecuteDb
        /// Sample : N/A
        /// </summary>
        public static DataSet ExecuteDb(string _query)
        {
            SqlDataAdapter _adp = new SqlDataAdapter(_query, Myconfig.GetConnect());
            DataSet _ds = new DataSet();
            _adp.Fill(_ds);
            return _ds;
        }

        #endregion Storeproc dataset

        #region Connect Link Layer.

        /// <summary>
        /// Author : Odd.Nopparat
        /// Date   : 2015-03-20.
        /// Perpose: เชื่อมต่อฐานข้อมูล.
        /// Method : getConnect.
        /// Sample : 10.90.101.101
        /// </summary>
        public static SqlConnection GetConnect()
        {
            SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            return _con;
        }

        #endregion Connect Link Layer.

        //ExecuteScalarParam anussara.wan 20200807
        public static string ExecuteScalarParam(string _query, CommandType _cmdType, params SqlParameter[] _parameters)
        {
            string _result = "";
            try
            {
                using (SqlConnection _conn = GetConnect())
                {
                    SqlCommand _cmd = new SqlCommand(_query);
                    _cmd.Connection = _conn;
                    _cmd.CommandType = _cmdType;
                    _cmd.CommandText = _query;

                    foreach (var _parameter in _parameters)
                    {
                        if (_parameter.Value == null)
                            _parameter.SqlValue = "";

                        _cmd.Parameters.Add(_parameter);
                    }

                    _conn.Open();
                    _result = (string)_cmd.ExecuteScalar();
                    _conn.Close();
                    _conn.Dispose();
                    _cmd.Dispose();
                }
            }
            catch (Exception ex)
            { }



            return _result.ToString();
        }


        #region Storeproc scalar

        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-03-20.
        /// Perpose: รัน คิวรี่ ออกมาเป็น เลขโดดๆ
        /// Method : ExecuteDb
        /// Sample : N/A
        /// </summary>

        public static int ExecuteCmd(string _query)
        {
            SqlConnection _conn = Myconfig.GetConnect();
            SqlCommand _cmd = new SqlCommand(_query, _conn);
            _conn.Open();
            int _result = _cmd.ExecuteNonQuery();
            _conn.Close();
            _cmd.Dispose();
            _conn.Dispose();
            return _result;
        }

        public static int ExecuteCmdParam(string _query, CommandType _cmdType, params SqlParameter[] _parameters)
        {
            int _result = 0;

            try
            {
                using (SqlConnection _conn = GetConnect())
                {
                    SqlCommand _cmd = new SqlCommand(_query);
                    _cmd.Connection = _conn;
                    _cmd.CommandType = _cmdType;
                    _cmd.CommandText = _query;

                    foreach (var _parameter in _parameters)
                    {
                        if (_parameter.Value == null)
                            _parameter.SqlValue = "";

                        _cmd.Parameters.Add(_parameter);
                    }

                    _conn.Open();
                    _result = _cmd.ExecuteNonQuery();
                    _conn.Close();
                    _conn.Dispose();
                    _cmd.Dispose();
                }
            }
            catch (Exception ex)
            { }


            return _result;
        }

        public static DataSet ExecuteSqlParam(string _query, CommandType _cmdType, params SqlParameter[] _parameters)
        {
            DataSet _ds = new DataSet();

            using (SqlConnection _conn = GetConnect())
            {
                SqlCommand _cmd = new SqlCommand(_query);
                _cmd.Connection = _conn;
                _cmd.CommandType = _cmdType;
                _cmd.CommandText = _query;

                foreach (var _parameter in _parameters)
                {
                    if (_parameter.Value == null)
                        _parameter.SqlValue = "";

                    _cmd.Parameters.Add(_parameter);
                }

                SqlDataAdapter _da = new SqlDataAdapter(_cmd);
                _da.Fill(_ds);
                _cmd.Dispose();
                _conn.Dispose();
            }

            return _ds;
        }

        public static int ExecuteCmdParamWithSQLType(string _query, CommandType _cmdType, SqlParameter[] _parameters, string table)
        {
            int _result = 0;

            try
            {
                using (SqlConnection _conn = GetConnect())
                {
                    SqlCommand _cmd = new SqlCommand(_query);
                    _cmd.Connection = _conn;
                    _cmd.CommandType = _cmdType;
                    _cmd.CommandText = _query;

                    foreach (var _parameter in _parameters)
                    {
                        if (_parameter.Value == null)
                            _parameter.SqlValue = "";
                        SqlParameter _param = _cmd.Parameters.AddWithValue(_parameter.ParameterName, _parameter.Value);
                        _param.SqlDbType = _parameter.SqlDbType;
                        _param.TypeName = table;
                    }

                    _conn.Open();
                    _result = _cmd.ExecuteNonQuery();
                    _conn.Close();
                    _conn.Dispose();
                    _cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                string _ex = ex.ToString();
            }


            return _result;
        }

        #endregion Storeproc scalar

        #region Storeproc scalar with string

        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-03-20.
        /// Perpose: รัน คิวรี่ ออกมาเป็น string
        /// Method : ExecuteScalarCmd
        /// Sample : N/A
        /// </summary>
        public static string ExecuteScalarCmd(string _query)
        {
            SqlConnection _conn = Myconfig.GetConnect();
            SqlCommand _cmd = new SqlCommand(_query, _conn);
            _conn.Open();
            string _result = _cmd.ExecuteScalar().ToString();
            _conn.Close();
            _cmd.Dispose();
            _conn.Dispose();
            return _result;
        }

        #endregion Storeproc scalar with string

        #region script meteria bootstrap

        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-10-20.
        /// Perpose: ใช้บูตสแตรปเฟรมเวิร์ค
        /// Method : getMeteriaUi
        /// Sample : N/A
        /// </summary>
        public static void GetMeteriaUi(Page _page, string _path)
        {
            string _icon = "<link href='" + _path + "/css/icon.css' rel='stylesheet' />";
            string _materialize = "<link href='" + _path + "/css/materialize.css' rel='stylesheet' />";
            string _style = "<link href='" + _path + "/css/style.css' rel='stylesheet' />";
            string _materialdesignicons = "<link href='" + _path + "/css/materialdesignicons.css' rel='stylesheet' />";
            string _jquery = "<script type='text/javascript' src='" + _path + "/js/jquery-2.1.4.min.js'></script>";
            string _materializes = "<script type='text/javascript' src='" + _path + "/js/materialize.js'></script>";
            string _init = "<script type='text/javascript' src='" + _path + "/js/init.js'></script>";

            _page.Header.Controls.Add(new LiteralControl(_icon));
            _page.Header.Controls.Add(new LiteralControl(_materialize));
            _page.Header.Controls.Add(new LiteralControl(_style));
            _page.Header.Controls.Add(new LiteralControl(_materialdesignicons));
            _page.Header.Controls.Add(new LiteralControl(_jquery));
            _page.Header.Controls.Add(new LiteralControl(_materializes));
            _page.Header.Controls.Add(new LiteralControl(_init));
        }

        #endregion script meteria bootstrap

        #region nav bar

        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-10-20.
        /// Perpose: navBar
        /// Method : navBar
        /// Sample : N/A
        /// </summary>
        public static string NavBar(string _userType)
        {
            StringBuilder _string = new StringBuilder();
            _string.Append(@"
                        <div class='nav-wrapper container lang-active' data-lang='th'>
                              <a href='javascript:void(0);' class='brand-logo'>
                                <img src='images/MU-graphics1.png' alt='' class='hide-on-small-only' /></a>
                                <a href='#' data-activates='mobile-demo' class='button-collapse'><i class='mdi mdi-menu'></i></a>
                              <ul class='right hide-on-med-and-down'>
                              <li class='yellow-text'><b>MU-Contract<sup class='blue-text'>2.0</sup></b></li>");
            _string.Append(@"<li><a href='javascript:void(0);'></a></li>");
            _string.Append(@"<li><a href='javascript:void(0);' class='btnThai'>Thai</a></li>
                         <li><a href='javascript:void(0);' class='btnEng'>Eng</a></li>
                         <li><a href='faqContract.aspx'>FAQ คำถามที่พบบ่อย</a></li>
                         <li><a href='helpContract.aspx'>Help คู่มือการใช้งาน</a></li>");

            //_string.Append("<li><a href='login.aspx?logout=yes&userType=" + _userType + "' class='amber-text'><i class='mdi mdi-exit-to-app'></i></a></li>");
            _string.Append("<li><a href='logout.aspx' class='amber-text'><i class='mdi mdi-exit-to-app'></i></a></li>");
            _string.Append(@"     </ul>
                              <ul class='side-nav' id='mobile-demo'>
                                <li><a href='javascript:void(0);' class='btnThai'>Thai</a></li>
                                <li><a href='javascript:void(0);' class='btnEng'>Eng</a></li>
                                <li><a href='help/help_e-Contract.docx' class='btnHelpWORD'>Help WORD</a></li>
                                <li><a href='help/help_e-Contract.pdf' target='_blank' class='btnHelpPDF'>Help PDF</a></li>
                                <li><a href='Template/FormRequestPassword/requestPassword.pdf' target='_blank' class='btnFormDwn'>Form Download</a></li>
                              </ul>
                       </div>");
            return _string.ToString();
        }

        #endregion nav bar

        #region auto path mapping

        /// <summary>
        /// Author : Thanakrit.tae
        /// Create Date : 2015-02-12
        /// Method : GetVirtualPath()
        /// Param : n/a
        /// Description : สำหรับต้องการ path เริ่มต้นของ application ที่พัฒนาอยู่
        /// </summary>
        /// <returns></returns>
        public static string GetVirtualPath()
        {
            string _path = HttpContext.Current.Request.ApplicationPath.ToString();
            if (_path == "/")
            {
                _path = "";
            }
            return _path;
        }

        #endregion auto path mapping

        #region Authen Login Local Layer..

        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2014-12-20.
        /// Perpose: ส่ง รหัสผู้ใช้ วันเดือนปีเกิด ส่งให้ฐานข้อมูลเช็ค
        /// Method : AuthenLocal
        /// Sample : '5790081', '1998-10-28'
        /// </summary>

        /*public static string AuthenAD(string _userName, string _password)
        {
            // เตรียมตัวแปร
            string _result = string.Empty;
            HttpCookie _cookie = new HttpCookie("STAFF");

            // เติมข้อมูลลงในคุ้กกี้
            _result = surveyDB.autGetStdADAuthen(_userName, _password);
        }*/

        #endregion Authen Login Local Layer..



        #region clear cookie.

        public static void ClearCookie(string _userType)
        {
            HttpCookie _cookie = new HttpCookie(_userType);
            HttpContext.Current.Response.Cookies.Add(_cookie);
            _cookie.Expires = DateTime.Now.AddDays(-1d);
            //Login _login = new Login(_userType);
        }

        #endregion clear cookie.

        #region keep loging.

        public static int Sp_autSetAuthenLog(string _username, string _status, string _authen, string _allowIp, string _result)
        {
            string _query = "sp_autSetAuthenLog '" + _username + "','" + _status + "','" + _authen + "','" + _allowIp + "','" + _result + "'";
            return Myconfig.ExecuteCmd(_query);
        }

        #endregion keep loging.



        /// <summary>
        /// Auther : Nopparat.j (Original-Thanakrit)
        /// Date   : 2014-03-20.
        /// Perpose: แปลงแอสกี้ให้เป็นภาษาไทย
        /// Method : convertString
        /// Sample : "Nopparat.jap","XXX"
        /// </summary>
        public static string ConvertString(string str)
        {
            string _x = "";
            if (str != null && str != "")
            {
                Encoding enc = Encoding.GetEncoding("tis-620");
                string[] _arr = str.Split(new string[] { "@#@" }, StringSplitOptions.None);
                byte[] _bb = new byte[_arr.Length - 1];
                for (int j = 0; j < _arr.Length - 1; j++)
                {
                    if (_arr[j] != "")
                    {
                        _bb[j] = Convert.ToByte(_arr[j]);
                    }
                }
                _x = enc.GetString(_bb);
            }

            return _x;
        }

        public static string CvEmpty(string _txtSource, string _txtDefault)
        {
            string _result = _txtSource;
            if (_txtSource == null || _txtSource == "")
            {
                _result = _txtDefault;
            }
            return _result;
        }

        //public static string GetSignCeoMahidol(string _acaYear)
        //{        
        //   // return "ท่าน โน๊ตอุดม แต้พานิช";
        //}


        public static string GetYearContract()
        {

            return "2558";
        }



        public static string GetSignCeoMahidol(string _acaYear)
        {
            throw new NotImplementedException();
        }
    }
}