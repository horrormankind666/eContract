using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class SignCEOinfo {
    string signName;
    public string SignNameCEO {
        get { return signName; }
        set { signName = value; }
    }

    string signImage;  
    public string SignImageCEO {
        get { return signImage; }
        set { signImage = value; }
    }

    string signCEOPosition;
    public string SignCEOPosition {
        get { return signCEOPosition; }
        set { signCEOPosition = value; }
    }

    // private string acaYear;

    public SignCEOinfo(string acaYear){
        // this.acaYear = acaYear;
        GetSignCeoMahidol(acaYear);
    }

    public void GetSignCeoMahidol(string acaYear) {
        SetEmpty();

        string query = ("sp_ectGetCEO '" + acaYear + "'");
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlDataAdapter adp = new SqlDataAdapter(query, con);
        DataSet dsCEO = new DataSet();
        adp.Fill(dsCEO);
        int row = dsCEO.Tables[0].Rows.Count;

        // Student Info
        if (row > 0) {
            signName = dsCEO.Tables[0].Rows[0]["signName"].ToString();
            signImage = dsCEO.Tables[0].Rows[0]["signImage"].ToString();
            signCEOPosition = dsCEO.Tables[0].Rows[0]["positionTh"].ToString();
        }
    }

    public void SetEmpty() {
        signName = "";
        signImage = "";
    }
}