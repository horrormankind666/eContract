using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for signCEOinfo
/// </summary>
public class signCEOinfo
{
    string _signName;
    public string signNameCEO
    {
        get { return _signName; }
        set { _signName = value; }
    }

    string _signImage;
    private string _acaYear;

    public string signImageCEO
    {
        get { return _signImage; }
        set { _signImage = value; }
    }

    string _signCEOPosition;
    public string SignCEOPosition
    {
        get { return _signCEOPosition; }
        set { _signCEOPosition = value; }
    }

    //public signCEOinfo()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //

    //}

    public signCEOinfo(string _acaYear)
    {
        // TODO: Complete member initialization
        //this._acaYear = _acaYear;
        GetSignCeoMahidol(_acaYear);
    }

    public void GetSignCeoMahidol(string _acaYear)
    {
        SetEmpty();
        string _query = "sp_ectGetCEO '" + _acaYear + "'";
        SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlDataAdapter _adp = new SqlDataAdapter(_query, _con);
        DataSet _dsCEO = new DataSet();
        _adp.Fill(_dsCEO);
        int _row = _dsCEO.Tables[0].Rows.Count;

        // Student Info
        _row = _dsCEO.Tables[0].Rows.Count;
        if (_row > 0)
        {

            _signName = _dsCEO.Tables[0].Rows[0]["signName"].ToString();
            _signImage = _dsCEO.Tables[0].Rows[0]["signImage"].ToString();
            _signCEOPosition = _dsCEO.Tables[0].Rows[0]["positionTh"].ToString();

        }
    }




    public void SetEmpty()
    {
        _signName = "";
        _signImage = "";
    }
}