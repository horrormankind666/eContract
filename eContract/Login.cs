using System;
using System.Data;
using System.IO;
using System.Web;
using System.Xml;
using eContract;

public class Login {
    private string uID;
    public string UID {
        get { return uID; }
        set { uID = value; }
    }

    private string userType;
    public string UserType {
        get { return userType; }
        set { userType = value; }
    }

    private string fullNameTH;
    public string FullNameTH {
        get { return fullNameTH; }
        set { fullNameTH = value; }
    }

    private string fullNameEN;
    public string FullNameEN {
        get { return fullNameEN; }
        set { fullNameEN = value; }
    }

    private string authen;
    public string Authen {
        get { return authen; }
        set { authen = value; }
    }

    private string username;
    public string Username {
        get { return username; }
        set { username = value; }
    }

    private string studentID;
    public string StudentID {
        get { return studentID; }
        set { studentID = value; }
    }

    private string studentCode;
    public string StudentCode {
        get { return studentCode; }
        set { studentCode = value; }
    }

    private string message;
    public string Message {
        get { return message; }
        set { message = value; }
    }

    private string depCode;
    public string DepCode {
        get { return depCode; }
        set { depCode = value; }
    }

    private string mailAddress;
    public string MailAddress {
        get { return mailAddress; }
        set { mailAddress = value; }
    }

    private string strResult;
    public string StrResult {
        get { return strResult; }
        set { strResult = value; }
    }

    private string urlStaffLogin = "http://www.student.mahidol.ac.th/infinity/authen/staffLogin.aspx";
    public string UrlStaffLogin {
        get { return urlStaffLogin; }
        set { urlStaffLogin = value; }
    }

    private string urlStudentLogin = "http://www.student.mahidol.ac.th/infinity/authen/studentLogin.aspx";
    public string UrlStudentLogin {
        get { return urlStudentLogin; }
        set { urlStudentLogin = value; }
    }

    public Login(string ownerType) {
        try {
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies[ownerType];

            if (httpCookie == null) {
                uID = "";
                userType = "";
                fullNameTH = "";
                fullNameEN = "";                
                depCode = "";
                authen = "";
                username = "";
                message = "Cookie may be null";
                studentID = "";
                studentCode = "";
            }
            else {
                strResult = httpCookie["result"].ToString();

                if (ownerType == "STUDENT") {
                    string studentCode = strResult.Substring(1, strResult.Length - 1);
                    StudentInfo std = new StudentInfo(studentCode);

                    studentID = std.StudentID;
                    fullNameTH = std.StdNameTH;
                    fullNameEN = std.StdNameEN;                    
                    studentCode = std.StudentCode;
                    username = strResult;
                }
                else {
                    //Finservice finservice = new Finservice();
                    DataSet ds = new DataSet();

                    if (strResult != "" ||
                        strResult != null) {
                        string res = Myconfig.ConvertString(strResult);
                        XmlTextReader reader = new XmlTextReader(new StringReader(res));
                        ds.ReadXml(reader, XmlReadMode.Auto);

                        if (ds.Tables[0].Rows.Count > 0) {
                            uID = ds.Tables[0].Rows[0]["uid"].ToString();
                            userType = ds.Tables[0].Rows[0]["userType"].ToString();
                            username = ds.Tables[0].Rows[0]["username"].ToString();
                            studentID = ds.Tables[0].Rows[0]["studentid"].ToString();
                            studentCode = ds.Tables[0].Rows[0]["studentcode"].ToString();
                            authen = ds.Tables[0].Rows[0]["authen"].ToString();
                        }
                    }
                }
            }
        }
        catch (Exception ex) {
            uID = "";
            userType = "";
            fullNameTH = "";
            fullNameEN = "";            
            depCode = "";
            authen = "error";
            username = "";
            message = ("Service error : " + ex.Message);
            studentID = "";
            studentCode = "";

            /*
            if (HttpContext.Current.Request.ServerVariables["SERVER_NAME"] == "localhost" {
                uID = "U0001";
                userType = _ownerType;
                fullNameTH = "test";
                fullNameEN = "test";                
                authen = "true";
                username = "6602081";
                message = ("Service error : " + _ex.Message);
                studentID = "STD256603596";
            }
            */
        }
    }

    public void SetLogin(
        string uID,
        string username,
        string userType,
        string fullNameTH,
        string fullNameEN,
        string authen,
        string studentID,
        string studentCode,
        string message,
        string depCode,
        string mailAddress
    ) {
        this.UID = uID;
        this.UserType = userType;
        this.FullNameTH = fullNameTH;
        this.FullNameEN = fullNameEN;
        this.DepCode = depCode;
        this.MailAddress = mailAddress;
        this.Authen = authen;
        this.Message = message;
        this.StudentID = studentID;
        this.StudentCode = studentCode;
        this.Username = username;
    }

    public static void ClearCookie(string userType) {
        HttpContext c = HttpContext.Current;
        HttpCookie httpCookie = c.Request.Cookies[userType];

        if (httpCookie != null) {
            httpCookie.Value = null;
            httpCookie.Expires = DateTime.Now.AddDays(-1);
            c.Response.Cookies.Add(httpCookie);
        }
    }

    /*
    Auther  : Nopparat.j
    Date    : 20-03-2014
    Perpose : ส่ง รหัสผู้ใช้ รหัสผ่านให้เว็บเซอร์วิส
    Method  : AuthenAD
    Sample  : "Nopparat.jap","XXX","STAFF"
    */
    /*
    public static void AuthenAD(
        string username,
        string password,
        string userType
    ) {    
        Finservice webservice = new Finservice();
        HttpCookie cookie = new HttpCookie(userType);
        string result = (password.Equals("xxx") ? webservice.XmlUserInfo(username, userType) : webservice.XmlAuthen(username, password, nuserType)); // webservice.XmlAuthen(username, password, userType);

        cookie["result"] = Myconfig.ConvertAscii(result);
        HttpContext.Current.Response.Cookies.Add(cookie);
        cookie.Expires = DateTime.Now.AddMinutes(20.0d);

        Login login = new Login(userType);
        string allowIP = "0";
        ContractDB.AutSetAuthenLog(login.Username, "login", login.Authen, allowIP, result);
    }
    */

    public static void AuthenParent(
        string username,
        string password,
        string userType
    ) {
        DataSet dsAuthen = ContractDB.Sp_ectAuthenParent(username, password); //check parent password --> return as string --> "1 = pass","0 = failed"
        HttpCookie cookie = new HttpCookie(userType);
        string result = dsAuthen.Tables[0].Rows[0]["xmls"].ToString();

        cookie["result"] = Myconfig.ConvertAscii(result);
        HttpContext.Current.Response.Cookies.Add(cookie);
        cookie.Expires = DateTime.Now.AddMinutes(20.0d);
    }

    public static string AuthenSignStudent(
        string username,
        string userType
    ) {
        if (userType is null) {
            throw new ArgumentNullException(nameof(userType));
        }

        string authen = "false";
        //string result = "";
        HttpCookie cookie = HttpContext.Current.Request.Cookies["STUDENT"];
        string cookieStudentCode = (cookie?["result"].ToUpper().Split('U')[1].ToString());

        if (username != null ||
            cookieStudentCode != null) {
            username = username.Trim().ToUpper();

            if (username.IndexOf('U') != -1)
                username = username.Substring(1, username.Length - 1);

            if (username == cookieStudentCode)
                authen = "true";
        }

        /*
        result = serAuthen.XmlAuthen(username, password, userType);
        result = (password.Equals("xxx") ? serAuthen.XmlUserInfo(username, userType) : serAuthen.XmlAuthen(username, password, userType));
        result = Myconfig.ConvertAscii(result);
        
        DataSet dsInfo = _serAuthen.info(result);
        int row = dsInfo.Tables[0].Rows.Count;

        if (row > 0)
            authen = dsInfo.Tables[0].Rows[0]["authen"].ToString();
        */

        return authen;
    }

    public static string AuthenSignParent(
        string username,
        string password,
        string userType
    ) {
        if (userType is null) {
            throw new ArgumentNullException(nameof(userType));
        }

        DataSet dsAuthen = ContractDB.Sp_ectAuthenParent(username, password);
        string authen = dsAuthen.Tables[0].Rows[0]["authen"].ToString();

        return authen;
    }
}