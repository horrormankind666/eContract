using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI;

namespace eContract {
    public class Myconfig {
        //กำหนดปีการศึกษาเป็นค่าเริ่มต้น
        public static CultureInfo th = CultureInfo.GetCultureInfo("th-TH");
        public static CultureInfo en = CultureInfo.GetCultureInfo("en-US");
        public static string day = DateTime.Now.ToString("dd", th);
        public static string month = DateTime.Now.ToString("MM", th);
        public static string monthNameTH = DateTime.Now.ToString("MMMM", th);
        public static string yearTH = DateTime.Now.ToString("yyyy", th);
        public static string yearEN = DateTime.Now.Year.ToString();
        public static string gProgramCode = string.Empty;
        public static string gQuotaCode = string.Empty;

        #region Convert Ascii
        /*
        Auther  : Odd.Nopparat (Original-Thanakrit)
        Date    : 20-03-2015
        Perpose : แปลงภาษาไทยให้เป็นแอสกี้
        Method  : convertAscii
        Sample  : "Odd.Nopparatap","XXX"
        */
        public static string ConvertAscii(string str) {
            string x = string.Empty;

            if (str != null &&
                str != "") {
                Encoding enc = Encoding.GetEncoding("tis-620");
                byte[] arrByte = enc.GetBytes(str.ToCharArray());

                foreach (byte b in arrByte) {
                    x += (b.ToString() + "@#@");
                }
            }

            return x;
        }

        #endregion Convert Ascii

        #region Stored Procedure Dataset
        /*
        Auther  : Odd.Nopparat
        Date    : 20-03-2015
        Perpose : รัน คิวรี่ ออกมาเป็น เซ็ต
        Method  : ExecuteDb
        Sample  : N/A
        */
        public static DataSet ExecuteDb(string query) {
            SqlDataAdapter adp = new SqlDataAdapter(query, GetConnect());
            DataSet ds = new DataSet();
            adp.Fill(ds);

            return ds;
        }

        #endregion Stored Procedure Dataset

        #region Connect Link Layer
        /*
        Auther  : Odd.Nopparat
        Date    : 20-03-2015
        Perpose : เชื่อมต่อฐานข้อมูล.
        Method  : getConnect.
        Sample  : 10.90.101.101
        */
        public static SqlConnection GetConnect() {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());

            return con;
        }

        #endregion Connect Link Layer

        public static string ExecuteScalarParam(
            string query,
            CommandType cmdType,
            params SqlParameter[] parameters
        ) {
            string result = string.Empty;

            try {
                using (SqlConnection conn = GetConnect()) {
                    SqlCommand cmd = new SqlCommand(query) {
                        Connection = conn,
                        CommandType = cmdType,
                        CommandText = query
                    };

                    foreach (var parameter in parameters) {
                        if (parameter.Value == null)
                            parameter.SqlValue = "";

                        cmd.Parameters.Add(parameter);
                    }

                    conn.Open();
                    result = (string)cmd.ExecuteScalar();
                    conn.Close();
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            catch (Exception) {
            }

            return result.ToString();
        }

        #region Stored Procedure Scalar
        /*
        Auther  : Odd.Nopparat
        Date    : 20-03-2015
        Perpose : รัน คิวรี่ ออกมาเป็น เลขโดดๆ
        Method  : ExecuteDb
        Sample  : N/A
        */
        public static int ExecuteCmd(string query) {
            SqlConnection conn = GetConnect();
            SqlCommand cmd = new SqlCommand(query, conn);            

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();

            return result;
        }

        public static int ExecuteCmdParam(
            string query,
            CommandType cmdType,
            params SqlParameter[] parameters
        ) {
            int result = 0;

            try {
                using (SqlConnection conn = GetConnect()) {
                    SqlCommand cmd = new SqlCommand(query) {
                        Connection = conn,
                        CommandType = cmdType,
                        CommandText = query
                    };

                    foreach (var parameter in parameters) {
                        if (parameter.Value == null)
                            parameter.SqlValue = "";

                        cmd.Parameters.Add(parameter);
                    }

                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            catch (Exception) {
            }

            return result;
        }

        public static DataSet ExecuteSqlParam(
            string query,
            CommandType cmdType,
            params SqlParameter[] parameters
        ) {
            DataSet ds = new DataSet();

            using (SqlConnection conn = GetConnect()) {
                SqlCommand cmd = new SqlCommand(query) {
                    Connection = conn,
                    CommandType = cmdType,
                    CommandText = query
                };

                foreach (var parameter in parameters) {
                    if (parameter.Value == null)
                        parameter.SqlValue = "";

                    cmd.Parameters.Add(parameter);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.Dispose();
                conn.Dispose();
            }

            return ds;
        }

        public static int ExecuteCmdParamWithSQLType(
            string query,
            CommandType cmdType,
            SqlParameter[] parameters,
            string table
        ) {
            int result = 0;

            try {
                using (SqlConnection conn = GetConnect()) {
                    SqlCommand cmd = new SqlCommand(query) {
                        Connection = conn,
                        CommandType = cmdType,
                        CommandText = query
                    };

                    foreach (var parameter in parameters) {
                        if (parameter.Value == null)
                            parameter.SqlValue = "";

                        SqlParameter param = cmd.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                        param.SqlDbType = parameter.SqlDbType;
                        param.TypeName = table;
                    }

                    conn.Open();
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    cmd.Dispose();
                }
            }
            catch (Exception) {
                //string ex = ex.ToString();
            }

            return result;
        }

        #endregion Stored Procedure Scalar

        #region Stored Procedure Scalar With String
        /*
        Auther  : Odd.Nopparat
        Date    : 20-03-2015
        Perpose : รัน คิวรี่ ออกมาเป็น string
        Method  : ExecuteScalarCmd
        Sample  : N/A
        */
        public static string ExecuteScalarCmd(string query) {
            SqlConnection conn = GetConnect();
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            string result = cmd.ExecuteScalar().ToString();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();

            return result;
        }

        #endregion Stored Procedure Scalar With String

        #region Script Meteria Bootstrap
        /*
        Auther  : Odd.Nopparat
        Date    : 20-10-2015
        Perpose : ใช้บูตสแตรปเฟรมเวิร์ค
        Method  : getMeteriaUi
        Sample  : N/A
        */
        public static void GetMeteriaUi(
            Page page,
            string path
        ) {
            string icon = ("<link href='" + path + "/css/icon.css' rel='stylesheet' />");
            string materialize = ("<link href='" + path + "/css/materialize.css' rel='stylesheet' />");
            string style = ("<link href='" + path + "/css/style.css' rel='stylesheet' />");
            string materialdesignicons = ("<link href='" + path + "/css/materialdesignicons.css' rel='stylesheet' />");
            string jquery = ("<script type='text/javascript' src='" + path + "/js/jquery-2.1.4.min.js'></script>");
            string materializes = ("<script type='text/javascript' src='" + path + "/js/materialize.js'></script>");
            string init = ("<script type='text/javascript' src='" + path + "/js/init.js'></script>");

            page.Header.Controls.Add(new LiteralControl(icon));
            page.Header.Controls.Add(new LiteralControl(materialize));
            page.Header.Controls.Add(new LiteralControl(style));
            page.Header.Controls.Add(new LiteralControl(materialdesignicons));
            page.Header.Controls.Add(new LiteralControl(jquery));
            page.Header.Controls.Add(new LiteralControl(materializes));
            page.Header.Controls.Add(new LiteralControl(init));
        }

        #endregion Script Meteria Bootstrap

        #region Nav Bar
        /*
        Auther  : Odd.Nopparat
        Date    : 20-10-2015
        Perpose : navBar
        Method  : navBar
        Sample  : N/A
        */
        public static string NavBar(string userType) {
            StringBuilder html = new StringBuilder();

            html.Append(@"
                <div class='nav-wrapper container lang-active' data-lang='th'>
                    <a href='javascript:void(0);' class='brand-logo'>
                        <img src='images/MU-graphics1.png' alt='' class='hide-on-small-only' />
                    </a>
                    <a href='#' data-activates='mobile-demo' class='button-collapse'><i class='mdi mdi-menu'></i></a>
                    <ul class='right hide-on-med-and-down'>
                        <li class='yellow-text'>
                            <b>MU-Contract<sup class='blue-text'>2.0</sup></b>
                        </li>
                        <li>
                            <a href='javascript:void(0);'></a>
                        </li>
                        <li>
                            <a href='javascript:void(0);' class='btnThai'>Thai</a>
                        </li>
                        <li>
                            <a href='javascript:void(0);' class='btnEng'>Eng</a>
                        </li>
                        <li>
                            <a href='faqContract.aspx'>FAQ คำถามที่พบบ่อย</a>
                        </li>
                        <li>
                            <a href='helpContract.aspx'>Help คู่มือการใช้งาน</a>
                        </li>" +
                        /*
                        <li>
                            <a href='login.aspx?logout=yes&userType=" + _userType + "' class='amber-text'><i class='mdi mdi-exit-to-app'></i></a>
                        </li>
                        */
                        @"
                        <li>
                            <a href='logout.aspx' class='amber-text'><i class='mdi mdi-exit-to-app'></i></a>
                        </li>
                    </ul>
                    <ul class='side-nav' id='mobile-demo'>
                        <li>
                            <a href='javascript:void(0);' class='btnThai'>Thai</a>
                        </li>
                        <li>
                            <a href='javascript:void(0);' class='btnEng'>Eng</a>
                        </li>
                        <li>
                            <a href='help/help_e-Contract.docx' class='btnHelpWORD'>Help WORD</a>
                        </li>
                        <li>
                            <a href='help/help_e-Contract.pdf' target='_blank' class='btnHelpPDF'>Help PDF</a>
                        </li>
                        <li>
                            <a href='Template/FormRequestPassword/requestPassword.pdf' target='_blank' class='btnFormDwn'>Form Download</a>
                        </li>
                    </ul>
                </div>
            ");

            return html.ToString();
        }

        #endregion Nav Bar

        #region Auto Path Mapping
        /*
        Author      : Thanakrit.tae
        Create Date : 12-02-2015
        Method      : GetVirtualPath()
        Param       : n/a
        Description : สำหรับต้องการ path เริ่มต้นของ application ที่พัฒนาอยู่
        */
        public static string GetVirtualPath() {
            string path = HttpContext.Current.Request.ApplicationPath.ToString();

            if (path == "/")
                path = "";

            return path;
        }

        #endregion Auto Path Mapping

        #region Authen Login Local Layer
        /*
        Auther  : Odd.Nopparat
        Date    : 20-12-2014
        Perpose : ส่ง รหัสผู้ใช้ วันเดือนปีเกิด ส่งให้ฐานข้อมูลเช็ค
        Method  : AuthenLocal
        Sample  : '5790081', '1998-10-28'
        */
        /*
        public static string AuthenAD(
            string userName,
            string password
        ) {
            HttpCookie cookie = new HttpCookie("STAFF");
            string result = surveyDB.autGetStdADAuthen(userName, password);
        }
        */

        #endregion Authen Login Local Layer

        #region Clear Cookie
        public static void ClearCookie(string userType) {
            HttpCookie cookie = new HttpCookie(userType);
            HttpContext.Current.Response.Cookies.Add(cookie);
            cookie.Expires = DateTime.Now.AddDays(-1d);
            //Login login = new Login(userType);
        }

        #endregion Clear Cookie

        #region Keep Loging
        public static int Sp_autSetAuthenLog(
            string username,
            string status,
            string authen,
            string allowIP,
            string result
        ) {
            string query = ("sp_autSetAuthenLog '" + username + "','" + status + "','" + authen + "','" + allowIP + "','" + result + "'");

            return ExecuteCmd(query);
        }

        #endregion Keep Loging

        /*
        Auther  : Nopparat.j (Original-Thanakrit)
        Date    : 20-03-2014
        Perpose : แปลงแอสกี้ให้เป็นภาษาไทย
        Method  : convertString
        Sample  : "Nopparat.jap","XXX"
        */
        public static string ConvertString(string str) {
            string x = "";

            if (str != null &&
                str != "") {
                Encoding enc = Encoding.GetEncoding("tis-620");
                string[] arr = str.Split(new string[] { "@#@" }, StringSplitOptions.None);
                byte[] bb = new byte[arr.Length - 1];

                for (int j = 0; j < arr.Length - 1; j++) {
                    if (arr[j] != "") {
                        bb[j] = Convert.ToByte(arr[j]);
                    }
                }

                x = enc.GetString(bb);
            }

            return x;
        }

        public static string CvEmpty(
            string txtSource,
            string txtDefault
        ) {
            string result = txtSource;

            if (txtSource == null ||
                txtSource == "")
                result = txtDefault;
            
            return result;
        }

        public static string GetYearContract() {
            return "2558";
        }

        public static string GetSignCeoMahidol(string acaYear) {
            throw new NotImplementedException();
        }
    }
}