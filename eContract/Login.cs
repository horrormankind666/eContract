//using authen;
using eContract;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for Login
/// </summary>
public class Login
{
    private string _uId;

    public string UId
    {
        get { return _uId; }
        set { _uId = value; }
    }

    private string _userType;

    public string UserType
    {
        get { return _userType; }
        set { _userType = value; }
    }

    private string _fullNameTh;

    public string FullNameTh
    {
        get { return _fullNameTh; }
        set { _fullNameTh = value; }
    }

    private string _fullNameEn;

    public string FullNameEn
    {
        get { return _fullNameEn; }
        set { _fullNameEn = value; }
    }

    private string _authen;

    public string Authen
    {
        get { return _authen; }
        set { _authen = value; }
    }

    private string _username;

    public string Username
    {
        get { return _username; }
        set { _username = value; }
    }

    private string _studentId;

    public string StudentId
    {
        get { return _studentId; }
        set { _studentId = value; }
    }

    private string _studentCode;

    public string StudentCode
    {
        get { return _studentCode; }
        set { _studentCode = value; }
    }

    private string _message;

    public string Message
    {
        get { return _message; }
        set { _message = value; }
    }

    private string _depCode;

    public string DepCode
    {
        get { return _depCode; }
        set { _depCode = value; }
    }

    private string _mailAddress;

    public string MailAddress
    {
        get { return _mailAddress; }
        set { _mailAddress = value; }
    }

    private string _strResult;

    public string StrResult
    {
        get { return _strResult; }
        set { _strResult = value; }
    }

    private string _urlStaffLogin = "http://www.student.mahidol.ac.th/infinity/authen/staffLogin.aspx";

    public string UrlStaffLogin
    {
        get { return _urlStaffLogin; }
        set { _urlStaffLogin = value; }
    }

    private string _urlStudentLogin = "http://www.student.mahidol.ac.th/infinity/authen/studentLogin.aspx";

    public string UrlStudentLogin
    {
        get { return _urlStudentLogin; }
        set { _urlStudentLogin = value; }
    }

    public Login(string _ownerType)
    {
        //
        // TODO: Add constructor logic here
        //
        try
        {
            HttpCookie _httpCookie = HttpContext.Current.Request.Cookies[_ownerType];
            if (_httpCookie == null)
            {
                _uId = "";
                _userType = "";
                _fullNameEn = "";
                _fullNameTh = "";
                _depCode = "";
                _authen = "";
                _username = "";
                _message = "Cookie may be null";
                _studentId = "";
                _studentCode = "";

            }
            else
            {
                _strResult = _httpCookie["result"].ToString();
                if (_ownerType == "STUDENT")
                {
                    string studentCode = _strResult.Substring(1, _strResult.Length - 1);
                    StudentInfo std = new StudentInfo(studentCode);
                    _studentId = std.StudentId;
                    _fullNameEn = std.StdNameEn;
                    _fullNameTh = std.StdNameTh;
                    _studentCode = std.StudentCode;
                    _username = _strResult;
                }
                else
                {
                    //Finservice finservice = new Finservice();
                    DataSet ds = new DataSet();
                    if (_strResult != "" || _strResult != null)
                    {
                        string res = Myconfig.ConvertString(_strResult);
                        XmlTextReader reader = new XmlTextReader(new StringReader(res));
                        ds.ReadXml(reader, XmlReadMode.Auto);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            _uId = ds.Tables[0].Rows[0]["uid"].ToString();
                            _userType = ds.Tables[0].Rows[0]["userType"].ToString();
                            _username = ds.Tables[0].Rows[0]["username"].ToString();
                            _studentId = ds.Tables[0].Rows[0]["studentid"].ToString();
                            _studentCode = ds.Tables[0].Rows[0]["studentcode"].ToString();
                            _authen = ds.Tables[0].Rows[0]["authen"].ToString();
                        }
                    }
                }
            }
        }
        catch (Exception _ex)
        {
            _uId = "";
            _userType = "";
            _fullNameEn = "";
            _fullNameTh = "";
            _depCode = "";
            _authen = "error";
            _username = "";
            _message = "Service error : " + _ex.Message;
            _studentId = "";
            _studentCode = "";


            //if (HttpContext.Current.Request.ServerVariables["SERVER_NAME"] == "localhost")
            //{
            //    _uId = "U0001";
            //    _userType = _ownerType;
            //    _fullNameEn = "test";
            //    _fullNameTh = "test";
            //    _authen = "true";
            //    _username = "6602081";
            //    //_message = "Service error : " + _ex.Message;
            //    _studentId = "STD256603596";
            //}

        }


    }

    public void SetLogin(string _uId, string _username, string _userType, string _fullNameTh, string _fullNameEn, string _authen, string _studentId, string _studentCode, string _message, string _depCode, string _mailAddress)
    {
        this.UId = _uId;
        this.UserType = _userType;
        this.FullNameTh = _fullNameTh;
        this.FullNameEn = _fullNameEn;
        this.DepCode = _depCode;
        this.MailAddress = _mailAddress;
        this.Authen = _authen;
        this.Message = _message;
        this.StudentId = _studentId;
        this.StudentCode = _studentCode;
        this.Username = _username;
    }


    public static void ClearCookie(string _userType)
    {
        HttpContext _c = HttpContext.Current;
        HttpCookie _httpCookie = _c.Request.Cookies[_userType];
        if (_httpCookie != null)
        {
            _httpCookie.Value = null;
            _httpCookie.Expires = DateTime.Now.AddDays(-1);
            _c.Response.Cookies.Add(_httpCookie);
        }
    }



    /// <summary>
    /// Auther : Nopparat.j
    /// Date   : 2014-03-20.
    /// Perpose: ส่ง รหัสผู้ใช้ รหัสผ่านให้เว็บเซอร์วิส
    /// Method : AuthenAD
    /// Sample : "Nopparat.jap","XXX","STAFF"
    /// </summary>

    //public static void AuthenAD(string _userName, string _password, string _userType)
    //{
    //    // เตรียมตัวแปร
    //    string _result = string.Empty;
    //    Finservice _webservice = new Finservice();
    //    HttpCookie _cookie = new HttpCookie(_userType);

    //    // เติมข้อมูลลงในคุ้กกี้
    //    //Fixed Password Authen For Test
    //    _result = _password.Equals("xxx") ? _webservice.XmlUserInfo(_userName, _userType) : _webservice.XmlAuthen(_userName, _password, _userType);
    //    //_result = _webservice.XmlAuthen(_userName, _password, _userType);
    //    _cookie["result"] = Myconfig.ConvertAscii(_result);
    //    HttpContext.Current.Response.Cookies.Add(_cookie);
    //    _cookie.Expires = DateTime.Now.AddMinutes(20.0d);
    //    Login _login = new Login(_userType);
    //    string _allowIp = "0";
    //    ContractDB.AutSetAuthenLog(_login.Username, "login", _login.Authen, _allowIp, _result);
    //}

    public static void AuthenParent(string _username, string _password,string _userType)
    {
        DataSet _dsAuthen = ContractDB.Sp_ectAuthenParent(_username, _password); // check parent password --> return as string --> "1 = pass","0 = failed"
        // เตรียมตัวแปร

        HttpCookie _cookie = new HttpCookie(_userType);
        // เติมข้อมูลลงในคุ้กกี้
        string _result = _dsAuthen.Tables[0].Rows[0]["xmls"].ToString();
        _cookie["result"] = Myconfig.ConvertAscii(_result);
        HttpContext.Current.Response.Cookies.Add(_cookie);
        _cookie.Expires = DateTime.Now.AddMinutes(20.0d);
        
    }


    public static string AuthenSignStudent(string _username, string _userType)
    {
        string _authen = "false";
        //string _result = "";
        HttpCookie cookie = HttpContext.Current.Request.Cookies["STUDENT"];
        string cookieStudentCode = cookie != null ? cookie["result"].ToUpper().Split('U')[1].ToString() : null;
        if(_username != null || cookieStudentCode != null)
        {
            _username = _username.Trim().ToUpper();
            if(_username.IndexOf('U') != -1)
            {
                _username = _username.Substring(1, _username.Length - 1);
            }

            if(_username == cookieStudentCode)
            {
                _authen = "true";
            }
            else
            {
                _authen = "false";
            }
        }
        // เติมข้อมูลลงในคุ้กกี้
        //_result = _serAuthen.XmlAuthen(_username, _password, _userType);
        //_result = _password.Equals("xxx") ? _serAuthen.XmlUserInfo(_username, _userType) : _serAuthen.XmlAuthen(_username, _password, _userType);
        //_result = Myconfig.ConvertAscii(_result);
        //DataSet _dsInfo = _serAuthen.info(_result);
        //int _row = _dsInfo.Tables[0].Rows.Count;
        //if (_row > 0)
        //{
        //    _authen = _dsInfo.Tables[0].Rows[0]["authen"].ToString();

        //}


        return _authen;

    }

    public static string AuthenSignParent(string _username, string _password, string _userType)
    {
        string _authen = "false";
        DataSet _dsAuthen = ContractDB.Sp_ectAuthenParent(_username, _password);
        // เตรียมตัวแปร
        _authen = _dsAuthen.Tables[0].Rows[0]["authen"].ToString();
        return _authen;

    }

}