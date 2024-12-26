using System.Data;
using System.Data.SqlClient;
using eContract;

public class ContractDB {
    /*
    Auther  : anussara.wan
    Date    : 07-08-2020
    Perpose : save login loggin record
    Method  : autSetAuthenLog
    Sample  : 5 parameter
    */
    public static int AutSetAuthenLog(
        string username,
        string status,
        string authen,
        string allowIP,
        string result
    ) {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@username", username);
        param[1] = new SqlParameter("@status", status);
        param[2] = new SqlParameter("@authen", authen);
        param[3] = new SqlParameter("@allowIp", allowIP);
        param[4] = new SqlParameter("@result", result);

        string query = "sp_autSetAuthenLog @username,@status,@authen,@allowIp,@result";

        return Myconfig.ExecuteCmdParam(query, CommandType.Text, param);
    }

    /*
    Author  : anussara.wan   
    Date    : 07-08-2020
    Perpose : check parent password
    Method  : Sp_ectAuthenParent.
    Sample  : 1 is true, 0 is failed
    */
    public static DataSet Sp_ectAuthenParent(
        string userID,
        string password
    ) {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@username", userID);
        param[1] = new SqlParameter("@password", password);

        string query = "sp_ectAuthenParent @username,@password";

        return Myconfig.ExecuteSqlParam(query, CommandType.Text, param);
    }

    /*
    Author      : anussara.wan
    Date        : 07-08-2020
    Perpose     : บันทึกการทำสัญญาของนักศึกษา
    Method      : SetContract
    Property    : userType, studentID, acaYear, warrantBy, consentBy, marriage, aliveM, aliveF, liveWithM, liveWithF, liveWithOther, contactFm, parentType, username, docID
    */
    public static int SetContract(
        string userType,
        string studentID,
        string acaYear,
        string warrantBy,
        string consentBy,
        string marriage,
        string aliveM,
        string aliveF,
        string liveWithM,
        string liveWithF,
        string liveWithOther,
        string contactFM,
        string parentType,
        string username,
        string docID,
        string fatherUsername,
        string motherUsername
    ) {
        SqlParameter[] param = new SqlParameter[17];
        param[0] = new SqlParameter("@userType", userType);
        param[1] = new SqlParameter("@studentId", studentID);
        param[2] = new SqlParameter("@acaYear", acaYear);
        param[3] = new SqlParameter("@warrantBy", warrantBy);
        param[4] = new SqlParameter("@consentBy", consentBy);
        param[5] = new SqlParameter("@marriage", marriage);
        param[6] = new SqlParameter("@aliveM", aliveM);
        param[7] = new SqlParameter("@aliveF", aliveF);
        param[8] = new SqlParameter("@liveWithM", liveWithM);
        param[9] = new SqlParameter("@liveWithF", liveWithF);
        param[10] = new SqlParameter("@liveWithOther", liveWithOther);
        param[11] = new SqlParameter("@contactFM", contactFM);
        param[12] = new SqlParameter("@parentType", parentType);
        param[13] = new SqlParameter("@username", username);
        param[14] = new SqlParameter("@docId", docID);
        param[15] = new SqlParameter("@fatherUsername", fatherUsername);
        param[16] = new SqlParameter("@motherUsername", motherUsername);

        string query = "sp_ectSetContract @userType,@studentId,@acaYear,@warrantBy,@consentBy,@marriage,@aliveM,@aliveF,@liveWithM,@liveWithF,@liveWithOther,@contactFM,@parentType,@username,@docId,@fatherUsername,@motherUsername";

        return Myconfig.ExecuteCmdParam(query, CommandType.Text, param);
    }

    /*
    Author      : anussara.wan
    Date        : 07-08-2020
    Description : แสดงข้อมูลสถานะสมรสและมีชีวิตของบิดามารดา.
    Method      : Sp_ectStatusInfo
    */
    public static DataSet Sp_ectStatusInfo(string studentID) {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@studentId", studentID);

        string query = "sp_ectStatusInfo @studentId";

        return Myconfig.ExecuteSqlParam(query, CommandType.Text, param);
    }

    /*
    Author      : alex
    Date        : 2015-11-26.
    Description : ข้อมูลวันที่เปิดระบบ
    Method      : Sp_sysGetDateEvent
    */
    public static DataSet Sp_ectGetDateEvent(string acaYear) {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@acaYear", acaYear);

        string query = "sp_ectGetDateEvent @acaYear";

        return Myconfig.ExecuteSqlParam(query, CommandType.Text, param);
    }

    /*
    Author      : anussara.wan
    Date        : 08-07-2020
    Description : ตรวจสอบเปิดปิดระบบตามปีที่รับเข้า
    Method      : Sp_sysGetDateEvent
    */
    public static DataSet Sp_ectGetDateEventLogin(string acaYear) {
        //string query = ("sp_ectGetDateEventLogin '" + _acaYear + "'");

        //return Myconfig.ExecuteDb(_query);
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@acaYear", acaYear);

        string query = "sp_ectGetDateEventLogin @acaYear";

        return Myconfig.ExecuteSqlParam(query, CommandType.Text, param);
    }

    /*
    Auther  : anussara.wan
    Date    : 07-08-2020
    Perpose : save ContractPath (A)
    Method  : SetContractPath
    Sample  : 3 parameter
    */
    public static int SetContractPath(
        string studentID,
        string acaYear,
        string contractpath
    ) {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@studentId", studentID);
        param[1] = new SqlParameter("@acaYear", acaYear);
        param[2] = new SqlParameter("@contractPath", contractpath);
        param[3] = new SqlParameter("@garranteePath", "");
        param[4] = new SqlParameter("@warranPath", "");

        string query = "sp_ectSetContractPath @studentId,@acaYear,@contractPath,@garranteePath,@warranPath";

        return Myconfig.ExecuteCmdParam(query, CommandType.Text, param);
    }

    /*
    Auther  : Anussara.wan
    Date    : 07-08-2020
    Perpose : save SetWarranPath (C)
    Method  : SetContractPath
    Sample  : 3 parameter
    */
    public static int SetWarranPath(
        string studentID,
        string acaYear,
        string warranPath
    ) {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@studentId", studentID);
        param[1] = new SqlParameter("@acaYear", acaYear);
        param[2] = new SqlParameter("@contractPath", "");
        param[3] = new SqlParameter("@garranteePath", "");
        param[4] = new SqlParameter("@warranPath", warranPath);

        string query = "sp_ectSetContractPath @studentId,@acaYear,@contractPath,@garranteePath,@warranPath";

        return Myconfig.ExecuteCmdParam(query, CommandType.Text, param);
    }

    /*
    Auther  : anussara.wan
    Date    : 07-08-2020
    Perpose : save GarranteePath (B)
    Method  : SetGarranteePath
    Sample  : 3 parameter
    */
    public static int SetGarranteePath(
        string studentID,
        string acaYear,
        string garrantPath
    ) {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@studentId", studentID);
        param[1] = new SqlParameter("@acaYear", acaYear);
        param[2] = new SqlParameter("@contractPath", "");
        param[3] = new SqlParameter("@garranteePath", garrantPath);
        param[4] = new SqlParameter("@warranPath", "");

        string query = "sp_ectSetContractPath @studentId,@acaYear,@contractPath,@garranteePath,@warranPath";

        return Myconfig.ExecuteCmdParam(query, CommandType.Text, param);
    }

    /*
    Auther  : korakot.pim
    Date    : 07-08-2020
    Perpose : save ConfirmRequestPassword
    Method  : setConfirmRequestPassword
    Sample  : 4 parameter
    */
    public static int SetConfirmRequestPassword(
        string studentCode,
        string studentID,
        string acaYear,
        string username
    ) {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@studentCode", studentCode);
        param[1] = new SqlParameter("@studentId", studentID);
        param[2] = new SqlParameter("@acaYear", acaYear);
        param[3] = new SqlParameter("@username", username);

        string query = "sp_ectSetConfirmReqPasswordParent @studentCode,@studentId,@acaYear,@username";

        return Myconfig.ExecuteCmdParam(query, CommandType.Text, param);
    }

    /*
    Auther  : anussara.wan
    Date    : 07-08-2020
    Perpose : GetListParentPassword
    Method  : GetListParentPassword
    Sample  : 4 parameter
    */
    public static DataSet GetListParentPassword(
        string studentCode,
        string printFather,
        string printMother,
        string acaYear
    ) {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@studentID", studentCode);
        param[1] = new SqlParameter("@printFather", printFather);
        param[2] = new SqlParameter("@printMother", printMother);
        param[3] = new SqlParameter("@acaYear", acaYear);

        string query = "sp_ectGetListPrintPassword @studentID,@printFather,@printMother,@acaYear";

        return Myconfig.ExecuteSqlParam(query, CommandType.Text, param);
    }

    /*
    Auther  : korakot.pim
    Date    : 07-08-2020
    Perpose : SetCreatePassword
    Method  : SetCreatePassword
    Sample  : 2 parameter
    */
    public static void SetCreatePassword(
        DataTable dtData,
        string userName
    ) {
        SqlConnection conn = Myconfig.GetConnect();
        SqlCommand cmd = new SqlCommand();

        conn.Open();
        
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_ectSetListCreatePassword";
        cmd.Parameters.Add("@tempStudentGenedPassword", SqlDbType.Structured).Value = dtData;
        cmd.Parameters.Add("@userName", SqlDbType.VarChar).Value = userName;
        cmd.ExecuteNonQuery();
        
        conn.Close();
    }

    /*
    Auther  : anussara.wan
    Date    : 2019-08-20
    Perpose : save GarranteePath (B)
    Method  : SetGarranteePath
    Sample  : 3 parameter
    */
    public static int SetConfirmParent(
        string username,
        string studentID,
        string confirmStatus
    ) {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@username", username);
        param[1] = new SqlParameter("@studentId", studentID);
        param[2] = new SqlParameter("@confirmSts", confirmStatus);

        string query = "sp_ectSetConfirmParent @username,@studentId,@confirmSts";

        return Myconfig.ExecuteCmdParam(query, CommandType.Text, param);
    }

    /*
    Auther  : anussara.wan
    Date    : 2020-08-11
    Update  : 2020-12-16
    Perpose : GetStatusReqPasswordParent
    Method  : GetStatusReqPasswordParent
    Sample  : 7 parameter
    */
    public static DataSet Sp_ectGetStatusReqPasswordParent(
        string maritalStatus,
        string aliveFStatus,
        string aliveMStatus,
        string stayFStatus,
        string stayMStatus,
        string stayOStatus,
        string warrantBy
    ) {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@maritalStatus", maritalStatus);
        param[1] = new SqlParameter("@aliveFStatus", aliveFStatus);
        param[2] = new SqlParameter("@aliveMStatus", aliveMStatus);
        param[3] = new SqlParameter("@stayFStatus", stayFStatus);
        param[4] = new SqlParameter("@stayMStatus", stayMStatus);
        param[5] = new SqlParameter("@stayOStatus", stayOStatus);
        param[6] = new SqlParameter("@warrantBy", warrantBy);

        string query = "sp_ectGetStatusReqPasswordParent @maritalStatus,@aliveFStatus,@aliveMStatus,@stayFStatus,@stayMStatus,@stayOStatus,@warrantBy";

        return Myconfig.ExecuteSqlParam(query, CommandType.Text, param);
    }

    public static DataSet GetConsent(string studentID) {
        string query = ("sp_ectGetConsent '" + studentID + "'");
        //SqlDataAdapter adapter = new SqlDataAdapter(query, Myconfig.GetConnect());

        return Myconfig.ExecuteDb(query);
    }

    public static DataSet CheckAvailableUsername(string username) {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@username", username);

        string query = "sp_ectCheckAvailableUsername @username";

        return Myconfig.ExecuteSqlParam(query, CommandType.Text, param);
    }

    public static DataSet GetListRePrintWarranty(
        string acaYear,
        string programCode,
        string studentCode
    ) {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@acaYear", acaYear);
        param[1] = new SqlParameter("@programCode", programCode);
        param[2] = new SqlParameter("@studentCode", studentCode);

        string query = "sp_ectGetListRePrintWarranty @acaYear,@programCode,@studentCode";

        return Myconfig.ExecuteSqlParam(query, CommandType.Text, param);
    }
}