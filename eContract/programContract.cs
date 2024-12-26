using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace eContract {
    public class ProgramContract {
        string studentID;
        public string StudentID {
            get { return studentID; }
            set { studentID = value; }
        }

        string statusMakeContract;
        public string StatusMakeContract {
            get { return statusMakeContract; }
            set { statusMakeContract = value; }
        }

        public ProgramContract(string studentID) {

            GetStatusInfo(studentID);
        }

        public void GetStatusInfo(string studentID) {
            SetEmpty();

            string query = ("sp_ectGetStatusContractInfo '" + studentID + "'");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataSet dsEctStsInfo = new DataSet();
            adp.Fill(dsEctStsInfo);
            int rowInfo = dsEctStsInfo.Tables[0].Rows.Count;

            if (rowInfo > 0) {
                studentID = dsEctStsInfo.Tables[0].Rows[0]["studentId"].ToString();
                statusMakeContract = dsEctStsInfo.Tables[0].Rows[0]["statusMakeContract"].ToString();
            }
        }

        public void SetEmpty() {
            studentID = "";
            statusMakeContract = "";
        }
    }
}
