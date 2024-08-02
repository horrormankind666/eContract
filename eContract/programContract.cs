using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for programContract
/// </summary>
namespace eContract
{
    public class programContract
    {

        //
        // TODO: Add constructor logic here
        //
        string _studentId;
        public string studentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }
        string _statusMakeContract;
        public string statusMakeContract
        {
            get { return _statusMakeContract; }
            set { _statusMakeContract = value; }
        }

        public programContract(string _studentId)
        {

            getStatusInfo(_studentId);
        }

        public void getStatusInfo(string _studentId)
        {

            SetEmpty();
            string _query = "sp_ectGetStatusContractInfo '" + _studentId + "'";
            SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            SqlDataAdapter _adp = new SqlDataAdapter(_query, _con);
            DataSet _dsEctStsInfo = new DataSet();
            _adp.Fill(_dsEctStsInfo);
            int _rowInfo = _dsEctStsInfo.Tables[0].Rows.Count;


            if (_rowInfo > 0)
            {
                _studentId = _dsEctStsInfo.Tables[0].Rows[0]["studentId"].ToString();
                _statusMakeContract = _dsEctStsInfo.Tables[0].Rows[0]["statusMakeContract"].ToString();
            }
        }
        public void SetEmpty()
        {
            _studentId = "";
            _statusMakeContract = "";
        }
    }
}
