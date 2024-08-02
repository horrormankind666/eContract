using eContract;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for contractDB
/// </summary>
public class ContractDB
{
    public ContractDB()
    {
    }

    /// <summary>
    /// Auther : anussara.wan
    /// Date   : 07-08-2020
    /// Perpose: save login loggin record
    /// Method : autSetAuthenLog
    /// Sample : 5 parameter
    /// </summary>
    public static int AutSetAuthenLog(string _username, string _status, string _authen, string _allowIp, string _result)
    {
        SqlParameter[] _params = new SqlParameter[5];
        _params[0] = new SqlParameter("@username", _username);
        _params[1] = new SqlParameter("@status", _status);
        _params[2] = new SqlParameter("@authen", _authen);
        _params[3] = new SqlParameter("@allowIp", _allowIp);
        _params[4] = new SqlParameter("@result", _result);
        string _query = "sp_autSetAuthenLog @username,@status,@authen,@allowIp,@result";
        return Myconfig.ExecuteCmdParam(_query, CommandType.Text, _params);
    }

    /// <summary>
    /// Author : anussara.wan   
    /// Date   : 07-08-2020
    /// Perpose: check parent password
    /// Method : Sp_ectAuthenParent.
    /// Sample : 1 is true , 0 is failed
    /// </summary>
    public static DataSet Sp_ectAuthenParent(string _userid, string _password)
    {
        SqlParameter[] _params = new SqlParameter[2];
        _params[0] = new SqlParameter("@username", _userid);
        _params[1] = new SqlParameter("@password", _password);
        string _query = "sp_ectAuthenParent @username,@password";
        return Myconfig.ExecuteSqlParam(_query, CommandType.Text, _params);
    }


    /// <summary>
    /// Author : anussara.wan
    /// Date   : 07-08-2020
    /// Perpose: บันทึกการทำสัญญาของนักศึกษา
    /// Method : SetContract
    /// Property :_userType,_studentId,_acaYear,_warrantBy,_consentBy,_marriage,_aliveM,_aliveF,_liveWithM,_liveWithF,_liveWithOther,_contactFm,_parentType,_username,_docId
    /// </summary>
    public static int SetContract(string _userType, string _studentId, string _acaYear, string _warrantBy, string _consentBy, string _marriage, string _aliveM, string _aliveF, string _liveWithM, string _liveWithF, string _liveWithOther, string _contactFm, string _parentType, string _username, string _docId, string _fatherUsername, string _motherUsername)
    {
        SqlParameter[] _params = new SqlParameter[17];
        _params[0] = new SqlParameter("@userType", _userType);
        _params[1] = new SqlParameter("@studentId", _studentId);
        _params[2] = new SqlParameter("@acaYear", _acaYear);
        _params[3] = new SqlParameter("@warrantBy", _warrantBy);
        _params[4] = new SqlParameter("@consentBy", _consentBy);
        _params[5] = new SqlParameter("@marriage", _marriage);
        _params[6] = new SqlParameter("@aliveM", _aliveM);
        _params[7] = new SqlParameter("@aliveF", _aliveF);
        _params[8] = new SqlParameter("@liveWithM", _liveWithM);
        _params[9] = new SqlParameter("@liveWithF", _liveWithF);
        _params[10] = new SqlParameter("@liveWithOther", _liveWithOther);
        _params[11] = new SqlParameter("@contactFM", _contactFm);
        _params[12] = new SqlParameter("@parentType", _parentType);
        _params[13] = new SqlParameter("@username", _username);
        _params[14] = new SqlParameter("@docId", _docId);
        _params[15] = new SqlParameter("@fatherUsername", _fatherUsername);
        _params[16] = new SqlParameter("@motherUsername", _motherUsername);
        string _query = "sp_ectSetContract @userType,@studentId,@acaYear,@warrantBy,@consentBy,@marriage,@aliveM,@aliveF,@liveWithM,@liveWithF,@liveWithOther,@contactFM,@parentType,@username,@docId,@fatherUsername,@motherUsername";
        return Myconfig.ExecuteCmdParam(_query, CommandType.Text, _params);
    }

    /// <summary>
    /// Author : anussara.wan
    /// Date   : 07-08-2020
    /// Description: แสดงข้อมูลสถานะสมรสและมีชีวิตของบิดามารดา.
    /// Method: Sp_ectStatusInfo
    /// </summary>
    public static DataSet Sp_ectStatusInfo(string _studentId)
    {
        SqlParameter[] _params = new SqlParameter[1];
        _params[0] = new SqlParameter("@studentId", _studentId);
        string _query = "sp_ectStatusInfo @studentId";
        return Myconfig.ExecuteSqlParam(_query, CommandType.Text, _params);
    }

    /// <summary>
    /// Author : alex
    /// Date   : 2015-11-26.
    /// Description: ข้อมูลวันที่เปิดระบบ
    /// Method: Sp_sysGetDateEvent
    /// </summary>
    public static DataSet Sp_ectGetDateEvent(string _acaYear)
    {
        SqlParameter[] _params = new SqlParameter[1];
        _params[0] = new SqlParameter("@acaYear", _acaYear);
        string _query = "sp_ectGetDateEvent @acaYear";
        return Myconfig.ExecuteSqlParam(_query, CommandType.Text, _params);
    }

    /// <summary>
    /// Author : anussara.wan
    /// Date   : 08-07-2020
    /// Description: ตรวจสอบเปิดปิดระบบตามปีที่รับเข้า
    /// Method: Sp_sysGetDateEvent
    /// </summary>
    public static DataSet Sp_ectGetDateEventLogin(string _acaYear)
    {
        //string _query = "sp_ectGetDateEventLogin '" + _acaYear + "'";
        //return Myconfig.ExecuteDb(_query);
        SqlParameter[] _params = new SqlParameter[1];
        _params[0] = new SqlParameter("@acaYear", _acaYear);
        string _query = "sp_ectGetDateEventLogin @acaYear";
        return Myconfig.ExecuteSqlParam(_query, CommandType.Text, _params);
    }

    /// <summary>
    /// Auther : anussara.wan
    /// Date   : 07-08-2020
    /// Perpose: save ContractPath (A)
    /// Method : SetContractPath
    /// Sample : 3 parameter
    /// </summary>
    public static int SetContractPath(string _studentId, string _acaYear, string _contractpath)
    {
        SqlParameter[] _params = new SqlParameter[5];
        _params[0] = new SqlParameter("@studentId", _studentId);
        _params[1] = new SqlParameter("@acaYear", _acaYear);
        _params[2] = new SqlParameter("@contractPath", _contractpath);
        _params[3] = new SqlParameter("@garranteePath", "");
        _params[4] = new SqlParameter("@warranPath", "");
        string _query = "sp_ectSetContractPath @studentId,@acaYear,@contractPath,@garranteePath,@warranPath";
        return Myconfig.ExecuteCmdParam(_query, CommandType.Text, _params);
    }

    /// <summary>
    /// Auther : Anussara.wan
    /// Date   : 07-08-2020
    /// Perpose: save SetWarranPath (C)
    /// Method : SetContractPath
    /// Sample : 3 parameter
    /// </summary>
    public static int SetWarranPath(string _studentId, string _acaYear, string _warranPath)
    {
        SqlParameter[] _params = new SqlParameter[5];
        _params[0] = new SqlParameter("@studentId", _studentId);
        _params[1] = new SqlParameter("@acaYear", _acaYear);
        _params[2] = new SqlParameter("@contractPath", "");
        _params[3] = new SqlParameter("@garranteePath", "");
        _params[4] = new SqlParameter("@warranPath", _warranPath);
        string _query = "sp_ectSetContractPath @studentId,@acaYear,@contractPath,@garranteePath,@warranPath";
        return Myconfig.ExecuteCmdParam(_query, CommandType.Text, _params);
    }

    /// <summary>
    /// Auther : anussara.wan
    /// Date   : 07-08-2020
    /// Perpose: save GarranteePath (B)
    /// Method : SetGarranteePath
    /// Sample : 3 parameter
    /// </summary>
    public static int SetGarranteePath(string _studentId, string _acaYear, string _garrantPath)
    {
        SqlParameter[] _params = new SqlParameter[5];
        _params[0] = new SqlParameter("@studentId", _studentId);
        _params[1] = new SqlParameter("@acaYear", _acaYear);
        _params[2] = new SqlParameter("@contractPath", "");
        _params[3] = new SqlParameter("@garranteePath", _garrantPath);
        _params[4] = new SqlParameter("@warranPath", "");
        string _query = "sp_ectSetContractPath @studentId,@acaYear,@contractPath,@garranteePath,@warranPath";
        return Myconfig.ExecuteCmdParam(_query, CommandType.Text, _params);
    }

    /// <summary>
    /// Auther : korakot.pim
    /// Date   : 07-08-2020
    /// Perpose: save ConfirmRequestPassword
    /// Method : setConfirmRequestPassword
    /// Sample : 4 parameter
    /// </summary>
    public static int setConfirmRequestPassword(string _studentCode, string _studentId, string _acaYear, string _username)
    {
        SqlParameter[] _params = new SqlParameter[4];
        _params[0] = new SqlParameter("@studentCode", _studentCode);
        _params[1] = new SqlParameter("@studentId", _studentId);
        _params[2] = new SqlParameter("@acaYear", _acaYear);
        _params[3] = new SqlParameter("@username", _username);
        string _query = "sp_ectSetConfirmReqPasswordParent @studentCode,@studentId,@acaYear,@username";
        return Myconfig.ExecuteCmdParam(_query, CommandType.Text, _params);
    }

    /// <summary>
    /// Auther : anussara.wan
    /// Date   : 07-08-2020
    /// Perpose: GetListParentPassword
    /// Method : GetListParentPassword
    /// Sample : 4 parameter
    /// </summary>
    public static DataSet GetListParentPassword(string _studentCode, string _printFather, string _printMother, string _acaYear)
    {
        SqlParameter[] _params = new SqlParameter[4];
        _params[0] = new SqlParameter("@studentID", _studentCode);
        _params[1] = new SqlParameter("@printFather", _printFather);
        _params[2] = new SqlParameter("@printMother", _printMother);
        _params[3] = new SqlParameter("@acaYear", _acaYear);
        string _query = "sp_ectGetListPrintPassword @studentID,@printFather,@printMother,@acaYear";
        return Myconfig.ExecuteSqlParam(_query, CommandType.Text, _params);
    }

    /// <summary>
    /// Auther : korakot.pim
    /// Date   : 07-08-2020
    /// Perpose: SetCreatePassword
    /// Method : SetCreatePassword
    /// Sample : 2 parameter
    /// </summary>
    public static void SetCreatePassword(DataTable _dtData, string _userName)
    {
        SqlConnection _conn = Myconfig.GetConnect();
        _conn.Open();
        SqlCommand _cmd = new SqlCommand();
        SqlDataAdapter _da = new SqlDataAdapter();
        _cmd.Connection = _conn;
        _cmd.CommandType = CommandType.StoredProcedure;
        _cmd.CommandText = "sp_ectSetListCreatePassword";
        _cmd.Parameters.Add("@tempStudentGenedPassword", SqlDbType.Structured).Value = _dtData;
        _cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = _userName;
        _cmd.ExecuteNonQuery();
        _conn.Close();
    }

    /// <summary>
    /// Auther : anussara.wan
    /// Date   : 2019-08-20
    /// Perpose: save GarranteePath (B)
    /// Method : SetGarranteePath
    /// Sample : 3 parameter
    /// </summary>
    public static int SetConfirmParent(string _username, string _studentId, string _confirmStatus)
    {
        SqlParameter[] _params = new SqlParameter[3];
        _params[0] = new SqlParameter("@username", _username);
        _params[1] = new SqlParameter("@studentId", _studentId);
        _params[2] = new SqlParameter("@confirmSts", _confirmStatus);
        string _query = "sp_ectSetConfirmParent @username,@studentId,@confirmSts";
        return Myconfig.ExecuteCmdParam(_query, CommandType.Text, _params);
    }

    /// <summary>
    /// Auther : anussara.wan
    /// Date   : 2020-08-11
    /// Update : 2020-12-16
    /// Perpose: GetStatusReqPasswordParent
    /// Method : GetStatusReqPasswordParent
    /// Sample : 7 parameter
    /// </summary>
    public static DataSet Sp_ectGetStatusReqPasswordParent(string _maritalStatus,string _aliveFStatus,string _aliveMStatus,string _stayFStatus,string _stayMStatus,string _stayOStatus,string _warrantBy)
    {
        SqlParameter[] _params = new SqlParameter[7];
        _params[0] = new SqlParameter("@maritalStatus", _maritalStatus);
        _params[1] = new SqlParameter("@aliveFStatus", _aliveFStatus);
        _params[2] = new SqlParameter("@aliveMStatus", _aliveMStatus);
        _params[3] = new SqlParameter("@stayFStatus", _stayFStatus);
        _params[4] = new SqlParameter("@stayMStatus", _stayMStatus);
        _params[5] = new SqlParameter("@stayOStatus", _stayOStatus);
        _params[6] = new SqlParameter("@warrantBy", _warrantBy);
        string _query = "sp_ectGetStatusReqPasswordParent @maritalStatus,@aliveFStatus,@aliveMStatus,@stayFStatus,@stayMStatus,@stayOStatus,@warrantBy";
        return Myconfig.ExecuteSqlParam(_query, CommandType.Text, _params);
    }

    public static DataSet GetConsent(string _studentId)
    {
        string _query = "sp_ectGetConsent '" + _studentId + "'";
        SqlDataAdapter _adapter = new SqlDataAdapter(_query, Myconfig.GetConnect());
        return Myconfig.ExecuteDb(_query);
    }

    public static DataSet CheckAvailableUsername(string username)
    {
        SqlParameter[] _params = new SqlParameter[1];
        _params[0] = new SqlParameter("@username", username);
        string _query = "sp_ectCheckAvailableUsername @username";
        return Myconfig.ExecuteSqlParam(_query, CommandType.Text, _params);

    }

    public static DataSet GetListRePrintWarranty(string acaYear, string programCode, string studentCode)
    {
        SqlParameter[] _params = new SqlParameter[3];
        _params[0] = new SqlParameter("@acaYear", acaYear);
        _params[1] = new SqlParameter("@programCode", programCode);
        _params[2] = new SqlParameter("@studentCode", studentCode);
        string _query = "sp_ectGetListRePrintWarranty @acaYear,@programCode,@studentCode";
        return Myconfig.ExecuteSqlParam(_query, CommandType.Text, _params);
    }


}