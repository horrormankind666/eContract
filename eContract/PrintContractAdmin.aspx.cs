using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;
using System.Text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using System.Net;
using System.Diagnostics.Contracts;
using System.Data;

namespace eContract
{
    public partial class PrintContractAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = "printWarrant";
            DataSet ds = ContractDB.GetListRePrintWarranty("2561", "PYPYB", "");
            
            if (ds != null )
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    string studentCode = row["StudentCode"].ToString();
                    string studentId = row["StudentId"].ToString();
                    switch (action)
                    {
                        case "printContract":
                            //Response.Write("printContract"); A
                            printContractStd(studentId, studentCode);
                            break;
                        case "printConsent":
                            //Response.Write("printConsent"); B
                            printGarrantee(studentId, "STUDENT", studentCode);
                            break;
                        case "printWarrant":
                            //Response.Write("printWarrant"); C
                            printWarrant(studentId, "STUDENT", studentCode);
                            break;
                    }
                }

            }

        }
        #region printContractStd
        /// <summary>
        /// Author: Anussara Wanwang
        /// Create date: 11-12-2015
        /// Description: พิมพ์สัญญานักศึกษา 
        /// Parameter:n/a
        /// </summary>
        public void printContractStd(string _studentId, string _studentCode)
        {
            //ในกรณีที่มี file ใน Folder แล้วให้เปิดเลย ไม่ต้องสร้าง pdf ใหม่
            ContractInfo _ctInfo = new ContractInfo(_studentId);
            string _contract = Myconfig.CvEmpty(_ctInfo.contractPath, " - ");
            if (_contract == " - ")
            {

                StringBuilder _string = new StringBuilder();
                StudentInfo _stdInfo = new StudentInfo(_studentCode);
                ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
                ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");

                CurDate _date = new CurDate();

                string _acaYear = Myconfig.CvEmpty(_stdInfo.AcaYear, " - ");

                signCEOinfo _signInfo = new signCEOinfo(_acaYear);
                string _dateContract = _ctInfo.DateLongContractStudent;
                string _quotaCode = _stdInfo.QuotaCode;
                string _signCEO, _signCEOPosition;
                string _fatherName, _motherName;
                string _idCard, _stdNameTh, _birthDate, _age, _moo, _no, _soi, _road, _subdistrict, _district, _provice, _zipcode, _phone, _ProgramCode, _statusContract;
                string _programCodeExtra = "";
                _signCEO = Myconfig.CvEmpty(_signInfo.signNameCEO, " - ");
                _signCEOPosition = Myconfig.CvEmpty(_signInfo.SignCEOPosition, "-");
                //_studentCode = Myconfig.CvEmpty(_stdInfo.StudentCode, " - ");
                _stdNameTh = Myconfig.CvEmpty(_stdInfo.StdNameTh, " - ");
                _age = Myconfig.CvEmpty(_stdInfo.Age, " - ");
                _birthDate = Myconfig.CvEmpty(_stdInfo.BirthDate, " - ");
                _no = Myconfig.CvEmpty(_stdInfo.No, " - ");
                _moo = Myconfig.CvEmpty(_stdInfo.Moo, " - ");
                _soi = Myconfig.CvEmpty(_stdInfo.Soi, " - ");
                _road = Myconfig.CvEmpty(_stdInfo.Road, " - ");
                _subdistrict = Myconfig.CvEmpty(_stdInfo.ThSubDistrict, " - ");
                _district = Myconfig.CvEmpty(_stdInfo.ThDistrict, " - ");
                _provice = Myconfig.CvEmpty(_stdInfo.ThProvince, " - ");
                _zipcode = Myconfig.CvEmpty(_stdInfo.ZipCode, " - ");
                _phone = Myconfig.CvEmpty(_stdInfo.phoneSTD, " - ");
                _idCard = Myconfig.CvEmpty(_stdInfo.IdCard, " - ");
                _ProgramCode = Myconfig.CvEmpty(_stdInfo.ProgramCode, " - ");
                //_ProgramCode = "DTDSB";
                _fatherName = _parentFInfo.FullNameTh;
                _motherName = _parentMInfo.FullNameTh;

                int _checkAcaYear = Convert.ToInt32(_acaYear);
                if (_checkAcaYear < 2565)
                {
                    _statusContract = "OLD";
                }
                else
                {
                    _statusContract = "NEW";
                }
                //_statusContract = "NEW";
                string _path = Server.MapPath("~");
                string _fileTmp = "";
                //เรียกใช้ file Template
                switch (_ProgramCode)
                {
                    case "SIMDB":
                        switch (_statusContract)
                        {
                            case "OLD":
                                _fileTmp = _path + "/Template/A_Contract/SIMDB.pdf";
                                break;
                            case "NEW":
                                _fileTmp = _path + "/Template/A_Contract/SIMDBNEW.pdf";
                                break;
                        }
                        break;

                    case "RAMDB":
                        switch (_statusContract)
                        {
                            case "OLD":
                                _fileTmp = _path + "/Template/A_Contract/RAMDB.pdf";
                                break;
                            case "NEW":
                                _fileTmp = _path + "/Template/A_Contract/RAMDBNEW.pdf";
                                break;
                        }
                        break;

                    case "PYPYB":
                        _fileTmp = _path + "/Template/A_Contract/PYPYB.pdf";
                        break;

                    case "DTDSB":
                        switch (_statusContract)
                        {
                            case "OLD":
                                _fileTmp = _path + "/Template/A_Contract/DTDSB.pdf";
                                break;
                            case "NEW":
                                _fileTmp = _path + "/Template/A_Contract/DTDSBNEW.pdf";
                                break;
                        }
                        break;
                    case "RANSB":
                        _fileTmp = _path + "/Template/A_Contract/RANSB.pdf";
                        break;

                    case "NSNSB":
                        switch (_quotaCode) // specification nurse program project
                        {
                            default: // siriraj hospital
                                _fileTmp = _path + "/Template/A_Contract/NSNSB.pdf";
                                break;

                            case "354": // chula research
                                _fileTmp = _path + "/Template/A_Contract/NSNSB_CL.pdf";
                                _programCodeExtra = "_CL";
                                break;

                            case "351": // faculty of tropical medicine
                                _fileTmp = _path + "/Template/A_Contract/NSNSB_TM.pdf";
                                _programCodeExtra = "_TM";
                                break;
                        }
                        break;
                }


                string _fileName = _studentCode + _ProgramCode + _programCodeExtra + "_A.pdf";
                string _fileDocument = _path + "/ElectronicContract/" + _fileName;

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + _studentCode + "_A.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Open the reader
                PdfReader _reader = new PdfReader(_fileTmp);//file Template
                                                            //string path = requestObj.PhysicalApplicationPath + "\\electronicContract\\" 
                DirectoryInfo DirInfo = new DirectoryInfo(Server.MapPath("~/ElectronicContract/" + _acaYear + "/" + _ProgramCode + _programCodeExtra + "/"));  // ต้องเป็นตัวแปรโฟลเดอร์ด้วยนะ
                if (!DirInfo.Exists)
                {
                    //  Response.Write("OK");
                    DirInfo.Create();
                }
                Document _document = new Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F);
                // open the writer
                PdfWriter _writer = PdfWriter.GetInstance(_document, new FileStream(Server.MapPath("~/ElectronicContract/" + _acaYear + "/" + _ProgramCode + _programCodeExtra + "/") + _fileName, FileMode.Create));
                //PdfWriter _writer = PdfWriter.GetInstance(_document, Response.OutputStream);
                Response.Charset = String.Empty;
                Response.ClearContent();
                _document.Open();
                int _y = 0;
                //Configure the content
                PdfContentByte _cb = _writer.DirectContent;
                // select the font properties

                //Write the text here
                _cb.BeginText();


                //หน้าที่ 1
                PdfImportedPage page1 = _writer.GetImportedPage(_reader, 1);//หน้า pdf template 1
                _cb.AddTemplate(page1, 0, 0);

                if (_ProgramCode == "SIMDB")
                {
                    if (_statusContract == "OLD")
                    {// acaYear < 2565
                        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Current Date
                        _y = 670;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayStd, 418, _y, 0);//Date
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThStd, 460, _y, 0);//Month
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThStd, 523, _y, 0);//Year
                                                                                                      //Name-LastName
                        _y = 532;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 100, _y, 0);
                        //bithDate,Age
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _birthDate, 360, _y, 0);//วัน/เดือน/ปี เกิด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 523, _y, 0);//อายุ
                                                                                         //No,Moo,Soi
                        _y = 508;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 160, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 265, _y, 0);//หมู่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 360, _y, 0);//ตรอก/ซอย
                                                                                         //road,subdistrict,district
                        _y = 484;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 75, _y, 0);//ถนน
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 230, _y, 0);//ตำบล/แขวง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 405, _y, 0);//อำเภอ/เขต
                                                                                              //provice,zipcode,phone
                        _y = 460;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 95, _y, 0);//จังหวัด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 300, _y, 0);//รหัสไปรษณีย์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 420, _y, 0);//เบอร์โทรศัพท์
                                                                                           //IdCard Student
                        _y = 437;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 180, _y, 0);//รหัสบัตรประชาชนนักศึกษา
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fatherName, 340, _y, 0);//ชื่อบิดา  
                        _y = 415;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _motherName, 100, _y, 0);//ชื่อมารดา
                        _cb.EndText();
                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();
                        //หน้าที่ 2
                        PdfImportedPage page2 = _writer.GetImportedPage(_reader, 2);//หน้า pdf template 2
                        _cb.AddTemplate(page2, 0, 0);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                        _cb.EndText();
                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();
                        //หน้าที่ 3
                        PdfImportedPage page3 = _writer.GetImportedPage(_reader, 3);//หน้า pdf template 2
                        _cb.AddTemplate(page3, 0, 0);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //ลายเซ็นนักศึกษา
                        _y = 482;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 335, _y, 0);//ชื่อนักศึกษา
                                                                                               //อธิการบดี
                        _y = 443;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEO, 335, _y, 0);//ชื่ออธิการบดี
                        _y = 420;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEOPosition, 335, _y, 0);//ตำแหน่งอธิการบดี
                    }
                    else
                    {// acayear >= 2565 
                        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        _y = 746;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 439, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Current Date
                        _y = 651;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayStd, 348, _y, 0);//Date
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThStd, 406, _y, 0);//Month
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThStd, 510, _y, 0);//Year
                                                                                                      //Name-LastName
                        _y = 506;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 188, _y, 0);
                        //ethnicity, nationality, religion, birthDate
                        _y = 488;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "-", 148, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdInfo.thNationalityName, 238, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "-", 341, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _birthDate, 427, _y, 0);//วัน/เดือน/ปี เกิด
                                                                                               //Age, No, Moo, Soi
                        _y = 471;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 112, _y, 0);//อายุ
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 239, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 317, _y, 0);//หมู่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 397, _y, 0);//ตรอก/ซอย
                                                                                         //Road,subdistrict
                        _y = 452;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 115, _y, 0);//ถนน
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 352, _y, 0);//ตำบล/แขวง
                                                                                                 //district, provice, zipcode
                        _y = 435;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 144, _y, 0);//อำเภอ/เขต
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 299, _y, 0);//จังหวัด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 496, _y, 0);//รหัสไปรษณีย์
                                                                                             //phone, IdCard Student
                        _y = 417;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 137, _y, 0);//เบอร์โทรศัพท์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 423, _y, 0);//รหัสบัตรประชาชนนักศึกษา
                                                                                            //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fatherName, 400, _y, 0);//ชื่อบิดา  
                                                                                            //_y = 417;
                                                                                            //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _motherName, 150, _y, 0);//ชื่อมารดา

                        //YearEntry
                        _y = 291;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdInfo.AcaYear, 95, _y, 0);//ปีการศึกษา
                        _cb.EndText();
                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();

                        //หน้าที่ 2
                        PdfImportedPage page2 = _writer.GetImportedPage(_reader, 2);//หน้า pdf template 2
                        _cb.AddTemplate(page2, 0, 0);
                        //ContractId
                        _y = 746;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 439, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                        _cb.EndText();
                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = _writer.GetImportedPage(_reader, 3);//หน้า pdf template 2
                        _cb.AddTemplate(page3, 0, 0);

                        //ContractId
                        _y = 746;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 439, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                        //WarrantyBy
                        _y = 688;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        if (_ctInfo.WarrantBy == "F")
                        {//Father

                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fatherName, 328, _y, 0);
                        }
                        else if (_ctInfo.WarrantBy == "M")
                        {//Mother
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _motherName, 328, _y, 0);
                        }
                        else
                        {
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "บุคคลอื่น", 328, _y, 0);
                        }

                        //ลายเซ็นนักศึกษา
                        _y = 471;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 210, _y, 0);//ชื่อนักศึกษา
                                                                                               //อธิการบดี
                        _y = 417;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEO, 210, _y, 0);//ชื่ออธิการบดี
                                                                                             //_y = 459;
                                                                                             //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEOPosition, 350, _y, 0);//ตำแหน่งอธิการบดี
                    }
                    _cb.EndText();
                }
                else if (_ProgramCode == "RAMDB")
                {
                    if (_statusContract == "OLD")
                    {// acaYear < 2565
                        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Current Date
                        _y = 670;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayStd, 418, _y, 0);//Date
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThStd, 460, _y, 0);//Month
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThStd, 523, _y, 0);//Year
                                                                                                      //Name-LastName
                        _y = 532;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 100, _y, 0);
                        //bithDate,Age
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _birthDate, 360, _y, 0);//วัน/เดือน/ปี เกิด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 523, _y, 0);//อายุ
                                                                                         //No,Moo,Soi
                        _y = 508;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 160, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 265, _y, 0);//หมู่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 360, _y, 0);//ตรอก/ซอย
                                                                                         //road,subdistrict,district
                        _y = 484;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 75, _y, 0);//ถนน
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 230, _y, 0);//ตำบล/แขวง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 405, _y, 0);//อำเภอ/เขต
                                                                                              //provice,zipcode,phone
                        _y = 460;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 95, _y, 0);//จังหวัด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 300, _y, 0);//รหัสไปรษณีย์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 420, _y, 0);//เบอร์โทรศัพท์
                                                                                           //IdCard Student
                        _y = 437;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 180, _y, 0);//รหัสบัตรประชาชนนักศึกษา
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fatherName, 340, _y, 0);//ชื่อบิดา  
                        _y = 415;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _motherName, 100, _y, 0);//ชื่อมารดา
                        _cb.EndText();
                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();
                        //หน้าที่ 2
                        PdfImportedPage page2 = _writer.GetImportedPage(_reader, 2);//หน้า pdf template 2
                        _cb.AddTemplate(page2, 0, 0);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                        _cb.EndText();
                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();
                        //หน้าที่ 3
                        PdfImportedPage page3 = _writer.GetImportedPage(_reader, 3);//หน้า pdf template 2
                        _cb.AddTemplate(page3, 0, 0);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //ลายเซ็นนักศึกษา
                        _y = 279;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 335, _y, 0);//ชื่อนักศึกษา
                                                                                               //อธิการบดี
                        _y = 241;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEO, 335, _y, 0);//ชื่ออธิการบดี
                        _y = 218;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEOPosition, 335, _y, 0);//ตำแหน่งอธิการบดี
                    }
                    else
                    {// acayear >= 2565 
                        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        _y = 746;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 439, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Current Date
                        _y = 651;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayStd, 348, _y, 0);//Date
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThStd, 406, _y, 0);//Month
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThStd, 510, _y, 0);//Year
                                                                                                      //Name-LastName
                        _y = 506;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 188, _y, 0);
                        //ethnicity, nationality, religion, birthDate
                        _y = 488;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "-", 148, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdInfo.thNationalityName, 238, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "-", 341, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _birthDate, 427, _y, 0);//วัน/เดือน/ปี เกิด
                                                                                               //Age, No, Moo, Soi
                        _y = 471;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 112, _y, 0);//อายุ
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 239, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 317, _y, 0);//หมู่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 397, _y, 0);//ตรอก/ซอย
                                                                                         //Road,subdistrict
                        _y = 452;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 115, _y, 0);//ถนน
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 352, _y, 0);//ตำบล/แขวง
                                                                                                 //district, provice, zipcode
                        _y = 435;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 144, _y, 0);//อำเภอ/เขต
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 299, _y, 0);//จังหวัด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 496, _y, 0);//รหัสไปรษณีย์
                                                                                             //phone, IdCard Student
                        _y = 417;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 137, _y, 0);//เบอร์โทรศัพท์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 423, _y, 0);//รหัสบัตรประชาชนนักศึกษา
                                                                                            //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fatherName, 400, _y, 0);//ชื่อบิดา  
                                                                                            //_y = 417;
                                                                                            //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _motherName, 150, _y, 0);//ชื่อมารดา

                        //YearEntry
                        _y = 291;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdInfo.AcaYear, 95, _y, 0);//ปีการศึกษา
                        _cb.EndText();
                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();

                        //หน้าที่ 2
                        PdfImportedPage page2 = _writer.GetImportedPage(_reader, 2);//หน้า pdf template 2
                        _cb.AddTemplate(page2, 0, 0);
                        //ContractId
                        _y = 746;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 439, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                        _cb.EndText();
                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = _writer.GetImportedPage(_reader, 3);//หน้า pdf template 2
                        _cb.AddTemplate(page3, 0, 0);

                        //ContractId
                        _y = 746;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 439, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                        //WarrantyBy
                        _y = 688;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        if (_ctInfo.WarrantBy == "F")
                        {//Father

                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fatherName, 328, _y, 0);
                        }
                        else if (_ctInfo.WarrantBy == "M")
                        {//Mother
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _motherName, 328, _y, 0);
                        }
                        else
                        {
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "บุคคลอื่น", 328, _y, 0);
                        }

                        //ลายเซ็นนักศึกษา
                        _y = 471;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 210, _y, 0);//ชื่อนักศึกษา
                                                                                               //อธิการบดี
                        _y = 417;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEO, 210, _y, 0);//ชื่ออธิการบดี
                                                                                             //_y = 459;
                                                                                             //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEOPosition, 350, _y, 0);//ตำแหน่งอธิการบดี
                    }
                    _cb.EndText();

                }
                else if (_ProgramCode == "PYPYB")
                {
                    BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    //ContractId
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                            //Current Date
                    _y = 673;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.SetColorFill(BaseColor.BLACK);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayStd, 400, _y, 0);//Date
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThStd, 450, _y, 0);//Month
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThStd, 515, _y, 0);//Year
                                                                                                  //Name-LastName
                    _y = 533;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 100, _y, 0);
                    //bithDate,Age
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _birthDate, 360, _y, 0);//วัน/เดือน/ปี เกิด
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 515, _y, 0);//อายุ
                                                                                     //No,Moo,Soi
                    _y = 510;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 160, _y, 0);//บ้านเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 265, _y, 0);//หมู่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 360, _y, 0);//ตรอก/ซอย
                                                                                     //road,subdistrict,district
                    _y = 486;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 75, _y, 0);//ถนน
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 230, _y, 0);//ตำบล/แขวง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 405, _y, 0);//อำเภอ/เขต
                                                                                          //provice,zipcode,phone
                    _y = 464;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 95, _y, 0);//จังหวัด
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 300, _y, 0);//รหัสไปรษณีย์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 420, _y, 0);//เบอร์โทรศัพท์
                                                                                       //IdCard Student
                    _y = 440;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 180, _y, 0);//รหัสบัตรประชาชนนักศึกษา
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fatherName, 340, _y, 0);//ชื่อบิดา  
                    _y = 417;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _motherName, 100, _y, 0);//ชื่อมารดา
                    _cb.EndText();
                    //ขึ้นหน้าใหม่
                    _document.NewPage();
                    _cb.BeginText();
                    //หน้าที่ 2
                    PdfImportedPage page2 = _writer.GetImportedPage(_reader, 2);//หน้า pdf template 2
                    _cb.AddTemplate(page2, 0, 0);
                    //ContractId
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                    _cb.EndText();
                    //ขึ้นหน้าใหม่
                    _document.NewPage();
                    _cb.BeginText();
                    //หน้าที่ 3
                    PdfImportedPage page3 = _writer.GetImportedPage(_reader, 3);//หน้า pdf template 2
                    _cb.AddTemplate(page3, 0, 0);
                    //ContractId
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                            //ลายเซ็นนักศึกษา
                    _y = 445;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.SetColorFill(BaseColor.BLACK);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 335, _y, 0);//ชื่อนักศึกษา
                                                                                           //อธิการบดี
                    _y = 405;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEO, 335, _y, 0);//ชื่ออธิการบดี
                    _y = 382;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEOPosition, 335, _y, 0);//ตำแหน่งอธิการบดี
                    _cb.EndText();
                }
                else if (_ProgramCode == "DTDSB")
                {
                    if (_statusContract == "OLD")
                    {// acaYear < 2565
                        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Current Date
                        _y = 672;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayStd, 418, _y, 0);//Date
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThStd, 460, _y, 0);//Month
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThStd, 523, _y, 0);//Year
                                                                                                      //Name-LastName
                        _y = 534;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 150, _y, 0);
                        //bithDate,Age
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _birthDate, 360, _y, 0);//วัน/เดือน/ปี เกิด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 523, _y, 0);//อายุ
                                                                                         //No,Moo,Soi
                        _y = 510;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 180, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 280, _y, 0);//หมู่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 400, _y, 0);//ตรอก/ซอย
                                                                                         //road,subdistrict,district
                        _y = 486;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 75, _y, 0);//ถนน
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 230, _y, 0);//ตำบล/แขวง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 405, _y, 0);//อำเภอ/เขต
                                                                                              //provice,zipcode,phone
                        _y = 465;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 120, _y, 0);//จังหวัด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 280, _y, 0);//รหัสไปรษณีย์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 410, _y, 0);//เบอร์โทรศัพท์
                                                                                           //IdCard Student
                        _y = 440;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 180, _y, 0);//รหัสบัตรประชาชนนักศึกษา
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fatherName, 400, _y, 0);//ชื่อบิดา  
                        _y = 417;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _motherName, 150, _y, 0);//ชื่อมารดา
                        _cb.EndText();
                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();
                        //หน้าที่ 2
                        PdfImportedPage page2 = _writer.GetImportedPage(_reader, 2);//หน้า pdf template 2
                        _cb.AddTemplate(page2, 0, 0);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                        _cb.EndText();
                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();
                        //หน้าที่ 3
                        PdfImportedPage page3 = _writer.GetImportedPage(_reader, 3);//หน้า pdf template 2
                        _cb.AddTemplate(page3, 0, 0);

                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //ลายเซ็นนักศึกษา
                        _y = 520;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 350, _y, 0);//ชื่อนักศึกษา
                                                                                               //อธิการบดี
                        _y = 482;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEO, 350, _y, 0);//ชื่ออธิการบดี
                        _y = 459;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEOPosition, 350, _y, 0);//ตำแหน่งอธิการบดี
                    }
                    else
                    {// acayear >= 2565 
                        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        _y = 746;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 439, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Current Date
                        _y = 651;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayStd, 348, _y, 0);//Date
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThStd, 406, _y, 0);//Month
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThStd, 510, _y, 0);//Year
                                                                                                      //Name-LastName
                        _y = 506;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 188, _y, 0);
                        //ethnicity, nationality, religion, birthDate
                        _y = 488;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "-", 148, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdInfo.thNationalityName, 238, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "-", 341, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _birthDate, 427, _y, 0);//วัน/เดือน/ปี เกิด
                                                                                               //Age, No, Moo, Soi
                        _y = 471;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 112, _y, 0);//อายุ
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 239, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 317, _y, 0);//หมู่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 397, _y, 0);//ตรอก/ซอย
                                                                                         //Road,subdistrict
                        _y = 452;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 115, _y, 0);//ถนน
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 352, _y, 0);//ตำบล/แขวง
                                                                                                 //district, provice, zipcode
                        _y = 435;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 144, _y, 0);//อำเภอ/เขต
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 299, _y, 0);//จังหวัด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 496, _y, 0);//รหัสไปรษณีย์
                                                                                             //phone, IdCard Student
                        _y = 417;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 137, _y, 0);//เบอร์โทรศัพท์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 423, _y, 0);//รหัสบัตรประชาชนนักศึกษา
                                                                                            //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fatherName, 400, _y, 0);//ชื่อบิดา  
                                                                                            //_y = 417;
                                                                                            //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _motherName, 150, _y, 0);//ชื่อมารดา

                        //YearEntry
                        _y = 291;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdInfo.AcaYear, 95, _y, 0);//ปีการศึกษา
                        _cb.EndText();
                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();

                        //หน้าที่ 2
                        PdfImportedPage page2 = _writer.GetImportedPage(_reader, 2);//หน้า pdf template 2
                        _cb.AddTemplate(page2, 0, 0);
                        //ContractId
                        _y = 746;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 439, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                        _cb.EndText();
                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = _writer.GetImportedPage(_reader, 3);//หน้า pdf template 2
                        _cb.AddTemplate(page3, 0, 0);

                        //ContractId
                        _y = 746;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 439, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                        //WarrantyBy
                        _y = 688;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        if (_ctInfo.WarrantBy == "F")
                        {//Father

                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fatherName, 328, _y, 0);
                        }
                        else if (_ctInfo.WarrantBy == "M")
                        {//Mother
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _motherName, 328, _y, 0);
                        }
                        else
                        {
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "บุคคลอื่น", 328, _y, 0);
                        }

                        //ลายเซ็นนักศึกษา
                        _y = 471;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 210, _y, 0);//ชื่อนักศึกษา
                                                                                               //อธิการบดี
                        _y = 417;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEO, 210, _y, 0);//ชื่ออธิการบดี
                                                                                             //_y = 459;
                                                                                             //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEOPosition, 350, _y, 0);//ตำแหน่งอธิการบดี
                    }
                    _cb.EndText();
                }
                else if (_ProgramCode == "RANSB")
                {
                    BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    //ContractId
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                            //Current Date
                    _y = 670;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.SetColorFill(BaseColor.BLACK);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayStd, 418, _y, 0);//Date
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThStd, 460, _y, 0);//Month
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThStd, 523, _y, 0);//Year
                                                                                                  //Name-LastName
                    _y = 599;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 100, _y, 0);
                    //bithDate,Age
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _birthDate, 360, _y, 0);//วัน/เดือน/ปี เกิด
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 523, _y, 0);//อายุ
                                                                                     //No,Moo,Soi
                    _y = 578;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 160, _y, 0);//บ้านเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 270, _y, 0);//หมู่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 360, _y, 0);//ตรอก/ซอย
                                                                                     //road,subdistrict,district
                    _y = 555;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 75, _y, 0);//ถนน
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 230, _y, 0);//ตำบล/แขวง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 405, _y, 0);//อำเภอ/เขต
                                                                                          //provice,zipcode,phone
                    _y = 529;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 90, _y, 0);//จังหวัด
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 290, _y, 0);//รหัสไปรษณีย์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 420, _y, 0);//เบอร์โทรศัพท์
                                                                                       //IdCard Student
                    _y = 508;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 180, _y, 0);//รหัสบัตรประชาชนนักศึกษา
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fatherName, 400, _y, 0);//ชื่อบิดา  
                    _y = 485;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _motherName, 150, _y, 0);//ชื่อมารดา
                    _cb.EndText();

                    //ขึ้นหน้าใหม่
                    _document.NewPage();
                    _cb.BeginText();

                    //หน้าที่ 2
                    PdfImportedPage page2 = _writer.GetImportedPage(_reader, 2);//หน้า pdf template 2
                    _cb.AddTemplate(page2, 0, 0);
                    //ContractId
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                    _cb.EndText();

                    //ขึ้นหน้าใหม่
                    _document.NewPage();
                    _cb.BeginText();

                    //หน้าที่ 3
                    PdfImportedPage page3 = _writer.GetImportedPage(_reader, 3);//หน้า pdf template 2
                    _cb.AddTemplate(page3, 0, 0);
                    //ContractId
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                            //ลายเซ็นนักศึกษา
                    _y = 275;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.SetColorFill(BaseColor.BLACK);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 350, _y, 0);//ชื่อนักศึกษา
                                                                                           //อธิการบดี
                    _y = 235;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEO, 350, _y, 0);//ชื่ออธิการบดี
                    _y = 212;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEOPosition, 350, _y, 0);//ตำแหน่งอธิการบดี
                    _cb.EndText();
                }
                else if (_ProgramCode == "NSNSB")
                {
                    BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    if (_quotaCode == "") // specification nurse program project
                    {
                        // siriraj hospital
                        //-----------------------------------------------------NSNSB
                        //ContractId 
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Current Date
                        _y = 670;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayStd, 418, _y, 0);//Date
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThStd, 460, _y, 0);//Month
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThStd, 526, _y, 0);//Year
                                                                                                      //Name-LastName
                        _y = 600;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 100, _y, 0);
                        //bithDate,Age
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _birthDate, 360, _y, 0);//วัน/เดือน/ปี เกิด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 520, _y, 0);//อายุ
                                                                                         //No,Moo,Soi
                        _y = 577;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 160, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 260, _y, 0);//หมู่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 360, _y, 0);//ตรอก/ซอย
                                                                                         //road,subdistrict,district
                        _y = 554;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 80, _y, 0);//ถนน
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 230, _y, 0);//ตำบล/แขวง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 405, _y, 0);//อำเภอ/เขต
                                                                                              //provice,zipcode,phone
                        _y = 529;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 80, _y, 0);//จังหวัด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 280, _y, 0);//รหัสไปรษณีย์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 415, _y, 0);//เบอร์โทรศัพท์
                                                                                           //IdCard Student
                        _y = 506;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 180, _y, 0);//รหัสบัตรประชาชนนักศึกษา
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fatherName, 340, _y, 0);//ชื่อบิดา  
                        _y = 482;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _motherName, 100, _y, 0);//ชื่อมารดา
                        _cb.EndText();

                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();

                        //หน้าที่ 2
                        PdfImportedPage page2 = _writer.GetImportedPage(_reader, 2);//หน้า pdf template 2
                        _cb.AddTemplate(page2, 0, 0);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                        _cb.EndText();

                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = _writer.GetImportedPage(_reader, 3);//หน้า pdf template 2
                        _cb.AddTemplate(page3, 0, 0);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //ลายเซ็นนักศึกษา
                        _y = 325;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 350, _y, 0);//ชื่อนักศึกษา
                                                                                               //อธิการบดี
                        _y = 285;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEO, 350, _y, 0);//ชื่ออธิการบดี
                        _y = 262;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEOPosition, 350, _y, 0);//ตำแหน่งอธิการบดี
                        _cb.EndText();
                    }
                    else if (_quotaCode == "354")
                    {

                        // chula research
                        //-----------------------------------------------------NSNSB
                        //ContractId 
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Current Date
                        _y = 670;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayStd, 418, _y, 0);//Date
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThStd, 460, _y, 0);//Month
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThStd, 526, _y, 0);//Year
                                                                                                      //Name-LastName
                        _y = 577;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 100, _y, 0);
                        //bithDate,Age
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _birthDate, 360, _y, 0);//วัน/เดือน/ปี เกิด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 520, _y, 0);//อายุ
                                                                                         //No,Moo,Soi
                        _y = 554;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 160, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 260, _y, 0);//หมู่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 360, _y, 0);//ตรอก/ซอย
                                                                                         //road,subdistrict,district
                        _y = 529;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 80, _y, 0);//ถนน
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 230, _y, 0);//ตำบล/แขวง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 405, _y, 0);//อำเภอ/เขต
                                                                                              //provice,zipcode,phone
                        _y = 506;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 80, _y, 0);//จังหวัด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 280, _y, 0);//รหัสไปรษณีย์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 415, _y, 0);//เบอร์โทรศัพท์
                                                                                           //IdCard Student
                        _y = 482;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 180, _y, 0);//รหัสบัตรประชาชนนักศึกษา
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fatherName, 340, _y, 0);//ชื่อบิดา  
                        _y = 462;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _motherName, 100, _y, 0);//ชื่อมารดา
                        _cb.EndText();

                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();

                        //หน้าที่ 2
                        PdfImportedPage page2 = _writer.GetImportedPage(_reader, 2);//หน้า pdf template 2
                        _cb.AddTemplate(page2, 0, 0);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                        _cb.EndText();

                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = _writer.GetImportedPage(_reader, 3);//หน้า pdf template 2
                        _cb.AddTemplate(page3, 0, 0);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //ลายเซ็นนักศึกษา
                        _y = 325;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 350, _y, 0);//ชื่อนักศึกษา
                                                                                               //อธิการบดี
                        _y = 285;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEO, 350, _y, 0);//ชื่ออธิการบดี
                        _y = 262;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEOPosition, 350, _y, 0);//ตำแหน่งอธิการบดี
                        _cb.EndText();
                    }
                    else if (_quotaCode == "351")
                    {

                        // faculty of tropical medicine
                        //-----------------------------------------------------NSNSB
                        ////ContractId 
                        //_cb.SetFontAndSize(_bf, 10);
                        ////แกน Y
                        //for (int i = 0; i <= 800; i += 10)
                        //{
                        //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                        //}
                        ////แกน X
                        //for (int i = 600; i >= 0; i -= 10)
                        //{
                        //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                        //}
                        //ContractId 
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Current Date
                        _y = 670;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayStd, 418, _y, 0);//Date
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThStd, 460, _y, 0);//Month
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThStd, 526, _y, 0);//Year
                                                                                                      //Name-LastName
                        _y = 577;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 100, _y, 0);
                        //bithDate,Age
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _birthDate, 360, _y, 0);//วัน/เดือน/ปี เกิด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 520, _y, 0);//อายุ
                                                                                         //No,Moo,Soi
                        _y = 554;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 160, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 260, _y, 0);//หมู่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 360, _y, 0);//ตรอก/ซอย
                                                                                         //road,subdistrict,district
                        _y = 529;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 80, _y, 0);//ถนน
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 230, _y, 0);//ตำบล/แขวง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 405, _y, 0);//อำเภอ/เขต
                                                                                              //provice,zipcode,phone
                        _y = 506;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 90, _y, 0);//จังหวัด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 280, _y, 0);//รหัสไปรษณีย์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 415, _y, 0);//เบอร์โทรศัพท์
                                                                                           //IdCard Student
                        _y = 483;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 180, _y, 0);//รหัสบัตรประชาชนนักศึกษา
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fatherName, 340, _y, 0);//ชื่อบิดา  
                        _y = 462;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _motherName, 100, _y, 0);//ชื่อมารดา
                        _cb.EndText();

                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();

                        //หน้าที่ 2
                        PdfImportedPage page2 = _writer.GetImportedPage(_reader, 2);//หน้า pdf template 2
                        _cb.AddTemplate(page2, 0, 0);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                        _cb.EndText();

                        //ขึ้นหน้าใหม่
                        _document.NewPage();
                        _cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = _writer.GetImportedPage(_reader, 3);//หน้า pdf template 2
                        _cb.AddTemplate(page3, 0, 0);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_A", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //ลายเซ็นนักศึกษา
                        _y = 347;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 350, _y, 0);//ชื่อนักศึกษา
                                                                                               //อธิการบดี
                        _y = 307;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEO, 350, _y, 0);//ชื่ออธิการบดี
                        _y = 284;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _signCEOPosition, 350, _y, 0);//ตำแหน่งอธิการบดี
                        _cb.EndText();
                    }
                }
                //Close all streams
                _document.Close();
                _writer.Close();
                _reader.Close();

                //update ContractPath
                string _contractPath = Server.MapPath("~/ElectronicContract/" + _acaYear + "/" + _ProgramCode + _programCodeExtra + "/") + _fileName;
                ContractDB.SetContractPath(_studentId, _acaYear, _contractPath);


                FileStream sourceFile = new FileStream((Server.MapPath("~/ElectronicContract/" + _acaYear + "/" + _ProgramCode + _programCodeExtra + "/") + _fileName), FileMode.Open);
                long FileSize;
                FileSize = sourceFile.Length;
                byte[] getContent = new byte[(int)FileSize];
                sourceFile.Read(getContent, 0, (int)sourceFile.Length);
                sourceFile.Close();
                Response.BinaryWrite(getContent);
            }
            else
            {
                //กรณีมี File สัญญาในระบบแล้ว เปิดอ่านเลย

                WebClient client1 = new WebClient();
                Byte[] buffer1 = client1.DownloadData(_contract);
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer1.Length.ToString());
                Response.BinaryWrite(buffer1);
                client1.Dispose();
            }

        }
        #endregion printContractStd

        #region printWarrant
        /// <summary>
        /// Author: Anussara Wanwang
        /// Create date:11-12-2015
        /// Update Date:20-08-2017
        /// Update Date:07-08-2020
        /// Description: สัญญาค้ำประกัน และหนังสือให้ความยินยอมของคู่สมรสผู้ค้ำประกัน C
        /// Parameter:n/a
        /// </summary>
        public void printWarrant(string _studentId, string _parentType, string _studentCode)
        {
            //ในกรณีที่มี file ใน Folder แล้วให้เปิดเลย ไม่ต้องสร้าง pdf ใหม่
            ContractInfo _ctInfo = new ContractInfo(_studentId);
            //string _warran = Myconfig.CvEmpty(_ctInfo.warranPath, " - ");
            //if (_warran == " - ")
            //{
                StudentInfo _stdInfo = new StudentInfo(_studentCode);
                ParentInfo _parentInfo = new ParentInfo(_studentId, _parentType);
                ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
                ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
                string _programCodeExtra = "";
                CurDate _date = new CurDate();

                string _acaYear = Myconfig.CvEmpty(_stdInfo.AcaYear, " - ");
                string _quotaCode = _stdInfo.QuotaCode;
                StringBuilder _string = new StringBuilder();

                //ข้อมูลนักศึกษา
                string _stdNameTh, _programNameTh, _ProgramCode, _studentProgram;
                _stdNameTh = Myconfig.CvEmpty(_stdInfo.StdNameTh, " - ");
                _programNameTh = Myconfig.CvEmpty(_stdInfo.ProgramNameTh, " - ");
                //_studentCode = Myconfig.CvEmpty(_stdInfo.StudentCode, " - ");
                _ProgramCode = Myconfig.CvEmpty(_stdInfo.ProgramCode, " - ");
                _studentProgram = Myconfig.CvEmpty(_stdInfo.StrStudentProgram, " - ");

                string _idCard, _fullNameTh, _fullNameMarTh, _age, _moo, _no, _soi, _road, _subdistrict, _thOccupation, _position, _agencyNameTH
                    , _district, _provice, _zipcode, _phone, _mobile, _assure1 = "", _assure2 = "", _assure3 = "";
                string _dateContract = _ctInfo.DateLongContractStudent;
                string _warrantBy = _ctInfo.WarrantBy;
                string _consentBy = _ctInfo.ConsentBy;
                string _aliveF = _ctInfo.IsAliveFather;//สถานะพ่อ 1=มีชีวิต , 2 = เสียชีวิต
                string _aliveM = _ctInfo.IsAliveMother;//สถานะแม่ 1=มีชีวิต , 2 = เสียชีวิต
                string _marriage = _ctInfo.IsMarriage;//1=สมรส,2=สมรส(ไม่ได้จดทะเบียน),3=บิดามารดาหย่าร้าง
                string _relationship = _ctInfo.relationship;//เกียวพันกับนักศึกษาโดยเป็น บิดา หรือ มารดา หรือ บุคคลอื่น

                //ข้อมูลผู้ค้ำประกัน
                if (_warrantBy == "M")//มารดาเป็นผู้ค้ำ
                {
                    if (_marriage == "1" && _aliveF == "1")
                    {
                        _fullNameMarTh = Myconfig.CvEmpty(_parentFInfo.FullNameTh, " - ");
                    }
                    else
                    {
                        _fullNameMarTh = " - ";
                    }

                    _fullNameTh = Myconfig.CvEmpty(_parentMInfo.FullNameTh, " - ");
                    _age = Myconfig.CvEmpty(_parentMInfo.Age, " - ");
                    _moo = Myconfig.CvEmpty(_parentMInfo.MooPermanent, " - ");
                    _no = Myconfig.CvEmpty(_parentMInfo.NoPermanent, " - ");
                    _soi = Myconfig.CvEmpty(_parentMInfo.SoiPermanent, " - ");
                    _road = Myconfig.CvEmpty(_parentMInfo.RoadPermanent, " - ");
                    _subdistrict = Myconfig.CvEmpty(_parentMInfo.ThSubdistrictName, " - ");
                    _district = Myconfig.CvEmpty(_parentMInfo.ThDistrictName, " - ");
                    _provice = Myconfig.CvEmpty(_parentMInfo.ProvinceNameTH, " - ");
                    _zipcode = Myconfig.CvEmpty(_parentMInfo.ZipCodePermanent, " - ");
                    _phone = Myconfig.CvEmpty(_parentMInfo.PhoneNumberPermanent, " - ");
                    _mobile = Myconfig.CvEmpty(_parentMInfo.MobileNumberPermanent, " - ");
                    _idCard = Myconfig.CvEmpty(_parentMInfo.IdCard, " - ");
                    _thOccupation = Myconfig.CvEmpty(_parentMInfo.ThOccupation, " - ");
                    _position = Myconfig.CvEmpty(_parentMInfo.Position, " - ");
                    _agencyNameTH = Myconfig.CvEmpty(_parentMInfo.AgencyNameTH, " - ");
                }

                else if (_warrantBy == "F")//บิดาเป็นผู้ค้ำ
                {
                    if (_marriage == "1" && _aliveM == "1")
                    {
                        _fullNameMarTh = Myconfig.CvEmpty(_parentMInfo.FullNameTh, " - ");
                    }
                    else
                    {
                        _fullNameMarTh = " - ";
                    }

                    _fullNameTh = Myconfig.CvEmpty(_parentFInfo.FullNameTh, " - ");
                    _age = Myconfig.CvEmpty(_parentFInfo.Age, " - ");
                    _moo = Myconfig.CvEmpty(_parentFInfo.MooPermanent, " - ");
                    _no = Myconfig.CvEmpty(_parentFInfo.NoPermanent, " - ");
                    _soi = Myconfig.CvEmpty(_parentFInfo.SoiPermanent, " - ");
                    _road = Myconfig.CvEmpty(_parentFInfo.RoadPermanent, " - ");
                    _subdistrict = Myconfig.CvEmpty(_parentFInfo.ThSubdistrictName, " - ");
                    _district = Myconfig.CvEmpty(_parentFInfo.ThDistrictName, " - ");
                    _provice = Myconfig.CvEmpty(_parentFInfo.ProvinceNameTH, " - ");
                    _zipcode = Myconfig.CvEmpty(_parentFInfo.ZipCodePermanent, " - ");
                    _phone = Myconfig.CvEmpty(_parentFInfo.PhoneNumberPermanent, " - ");
                    _mobile = Myconfig.CvEmpty(_parentFInfo.MobileNumberPermanent, " - ");
                    _idCard = Myconfig.CvEmpty(_parentFInfo.IdCard, " - ");
                    _thOccupation = Myconfig.CvEmpty(_parentFInfo.ThOccupation, " - ");
                    _position = Myconfig.CvEmpty(_parentFInfo.Position, " - ");
                    _agencyNameTH = Myconfig.CvEmpty(_parentFInfo.AgencyNameTH, " - ");

                }
                else
                {
                    _fullNameTh = " - ";
                    _fullNameMarTh = " - ";//ชื่อคู่สมรส
                    _age = " - ";
                    _moo = " - ";
                    _no = " - ";
                    _soi = " - ";
                    _road = " - ";
                    _subdistrict = " - ";
                    _district = " - ";
                    _provice = " - ";
                    _zipcode = " - ";
                    _phone = " - ";
                    _mobile = " - ";
                    _idCard = " - ";
                    _thOccupation = " - ";
                    _position = " - ";
                    _agencyNameTH = " - ";
                }
                string _path = Server.MapPath("~");
                string _fileTmp = "";
                //เรียกใช้ file Template
                switch (_ProgramCode)
                {
                    case "SIMDB":
                        _fileTmp = _path + "/Template/C_Warrant/WarrantSIMDB_NEW.pdf";
                        break;

                    case "RAMDB":
                        _fileTmp = _path + "/Template/C_Warrant/WarrantRAMDB_NEW.pdf";
                        break;

                    case "PYPYB":
                        _fileTmp = _path + "/Template/C_Warrant/WarrantPYPYB_NEW.pdf";
                        break;

                    case "DTDSB":
                        _fileTmp = _path + "/Template/C_Warrant/WarrantDTDSB_NEW.pdf";
                        break;

                    case "RANSB":
                        _fileTmp = _path + "/Template/C_Warrant/WarrantRANSB_NEW.pdf";
                        break;

                    case "NSNSB":
                        _fileTmp = _path + "/Template/C_Warrant/WarrantNSNSB_NEW.pdf";
                        break;
                }

                //Folder extra
                switch (_quotaCode)
                {
                    default: // siriraj hospital
                        _programCodeExtra = "";
                        break;
                    case "354":
                        _programCodeExtra = "_CL";
                        break;
                    case "351":
                        _programCodeExtra = "_TM";
                        break;
                }
                string _fileName = _studentCode + _ProgramCode + _programCodeExtra + "_C.pdf";
                string _fileDocument = _path + "/ElectronicContract/" + _fileName;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + _studentCode + "_C.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Open the reader
                PdfReader _reader = new PdfReader(_fileTmp);//file Template
                                                            //string path = requestObj.PhysicalApplicationPath + "\\electronicContract\\" 
                DirectoryInfo DirInfo = new DirectoryInfo(Server.MapPath("~/ElectronicContract/" + _acaYear + "/" + _ProgramCode + _programCodeExtra + "/"));  // ต้องเป็นตัวแปรโฟลเดอร์ด้วยนะ
                if (!DirInfo.Exists)
                {
                    //  Response.Write("OK");
                    DirInfo.Create();
                }
                Document _document = new Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F);
                // open the writer
                PdfWriter _writer = PdfWriter.GetInstance(_document, new FileStream(Server.MapPath("~/ElectronicContract/" + _acaYear + "/" + _ProgramCode + _programCodeExtra + "/") + _fileName, FileMode.Create));
                //PdfWriter _writer = PdfWriter.GetInstance(_document, Response.OutputStream);
                Response.Charset = String.Empty;
                Response.ClearContent();
                _document.Open();
                int _y = 0;
                //Configure the content
                PdfContentByte _cb = _writer.DirectContent;
                // select the font properties
                BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                //Write the text here
                _cb.BeginText();
                //หน้าที่ 1
                PdfImportedPage page1 = _writer.GetImportedPage(_reader, 1);//หน้า pdf template 1
                _cb.AddTemplate(page1, 0, 0);

                if (_ProgramCode == "SIMDB")
                {
                    //ContractId 
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);

                    ////แกน Y
                    //for (int i = 0; i <= 800; i += 10)
                    //{
                    //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                    //}
                    ////แกน X
                    //for (int i = 600; i >= 0; i -= 10)
                    //{
                    //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                    //}


                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                    //Current Date
                    _y = 670;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.SetColorFill(BaseColor.BLACK);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayP1, 390, _y, 0);//Date
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThP1, 435, _y, 0);//Month
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThP1, 515, _y, 0);//Year

                    //Name-LastName,age parent
                    _y = 650;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 180, _y, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 490, _y, 0);

                    //Occupation position agency
                    _y = 625;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _thOccupation, 80, _y, 0);//อาชีพ
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _thOccupation, 80, _y, 0);//อาชีพ
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _position, 250, _y, 0);//ตำแหน่ง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _agencyNameTH, 380, _y, 0);//สังกัด

                    //No,Moo,Soi
                    _y = 600;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 110, _y, 0);//บ้านเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 190, _y, 0);//หมู่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 270, _y, 0);//ตรอก/ซอย
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 410, _y, 0);//ถนน

                    //subdistrict,district,provice
                    _y = 578;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 110, _y, 0);//ตำบล/แขวง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 265, _y, 0);//อำเภอ/เขต
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 400, _y, 0);//จังหวัด

                    //zipcode,phone,mobile
                    _y = 555;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 110, _y, 0);//รหัสไปรษณีย์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 250, _y, 0);//เบอร์โทรศัพท์บ้าน
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _mobile, 430, _y, 0);//เบอร์โทรศัพท์มือถือ

                    //marrie Name
                    _y = 530;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 180, _y, 0);//รหัสบัตรประชาชน
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameMarTh, 380, _y, 0);//ชื่อคู่สมรส

                    //Name Student
                    _y = 460;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 100, _y, 0);//ชื่อนักศึกษา

                    //date Contract
                    _y = 438;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateContract, 150, _y, 0);//วันที่ทำสัญญา

                }
                else if (_ProgramCode == "RAMDB")
                {

                    //ContractId 
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);

                    ////แกน Y
                    //for (int i = 0; i <= 800; i += 10)
                    //{
                    //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                    //}
                    ////แกน X
                    //for (int i = 600; i >= 0; i -= 10)
                    //{
                    //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                    //}


                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                    //Current Date
                    _y = 670;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.SetColorFill(BaseColor.BLACK);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayP1, 390, _y, 0);//Date
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThP1, 435, _y, 0);//Month
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThP1, 515, _y, 0);//Year

                    //Name-LastName,age parent
                    _y = 650;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 180, _y, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 490, _y, 0);

                    //Occupation position agency
                    _y = 625;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _thOccupation, 80, _y, 0);//อาชีพ
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _position, 250, _y, 0);//ตำแหน่ง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _agencyNameTH, 380, _y, 0);//สังกัด

                    //No,Moo,Soi
                    _y = 600;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 110, _y, 0);//บ้านเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 190, _y, 0);//หมู่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 270, _y, 0);//ตรอก/ซอย
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 410, _y, 0);//ถนน

                    //subdistrict,district,provice
                    _y = 578;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 110, _y, 0);//ตำบล/แขวง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 265, _y, 0);//อำเภอ/เขต
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 400, _y, 0);//จังหวัด

                    //zipcode,phone,mobile
                    _y = 555;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 110, _y, 0);//รหัสไปรษณีย์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 250, _y, 0);//เบอร์โทรศัพท์บ้าน
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _mobile, 430, _y, 0);//เบอร์โทรศัพท์มือถือ

                    //marrie Name
                    _y = 530;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 180, _y, 0);//รหัสบัตรประชาชน
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameMarTh, 380, _y, 0);//ชื่อคู่สมรส

                    //Name Student
                    _y = 460;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 100, _y, 0);//ชื่อนักศึกษา

                    //date Contract
                    _y = 438;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateContract, 150, _y, 0);//วันที่ทำสัญญา

                }
                else if (_ProgramCode == "PYPYB")
                {
                    //ContractId 
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);

                    ////แกน Y
                    //for (int i = 0; i <= 800; i += 10)
                    //{
                    //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                    //}
                    ////แกน X
                    //for (int i = 600; i >= 0; i -= 10)
                    //{
                    //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                    //}


                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                    //Current Date
                    _y = 670;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.SetColorFill(BaseColor.BLACK);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayP1, 390, _y, 0);//Date
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThP1, 435, _y, 0);//Month
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThP1, 515, _y, 0);//Year

                    //Name-LastName,age parent
                    _y = 650;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 180, _y, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 490, _y, 0);

                    //Occupation position agency
                    _y = 625;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _thOccupation, 80, _y, 0);//อาชีพ
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _position, 250, _y, 0);//ตำแหน่ง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _agencyNameTH, 380, _y, 0);//สังกัด

                    //No,Moo,Soi
                    _y = 600;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 110, _y, 0);//บ้านเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 190, _y, 0);//หมู่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 270, _y, 0);//ตรอก/ซอย
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 410, _y, 0);//ถนน

                    //subdistrict,district,provice
                    _y = 578;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 110, _y, 0);//ตำบล/แขวง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 265, _y, 0);//อำเภอ/เขต
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 400, _y, 0);//จังหวัด

                    //zipcode,phone,mobile
                    _y = 555;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 110, _y, 0);//รหัสไปรษณีย์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 250, _y, 0);//เบอร์โทรศัพท์บ้าน
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _mobile, 430, _y, 0);//เบอร์โทรศัพท์มือถือ

                    //marrie Name
                    _y = 530;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 180, _y, 0);//รหัสบัตรประชาชน
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameMarTh, 380, _y, 0);//ชื่อคู่สมรส

                    //Name Student
                    _y = 460;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 100, _y, 0);//ชื่อนักศึกษา

                    //date Contract
                    _y = 438;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateContract, 150, _y, 0);//วันที่ทำสัญญา

                }
                else if (_ProgramCode == "DTDSB")
                {
                    //ContractId 
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);

                    ////แกน Y
                    //for (int i = 0; i <= 800; i += 10)
                    //{
                    //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                    //}
                    ////แกน X
                    //for (int i = 600; i >= 0; i -= 10)
                    //{
                    //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                    //}


                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                    //Current Date
                    _y = 670;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.SetColorFill(BaseColor.BLACK);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayP1, 390, _y, 0);//Date
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThP1, 435, _y, 0);//Month
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThP1, 515, _y, 0);//Year

                    //Name-LastName,age parent
                    _y = 650;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 180, _y, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 490, _y, 0);

                    //Occupation position agency
                    _y = 625;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _thOccupation, 80, _y, 0);//อาชีพ
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _position, 250, _y, 0);//ตำแหน่ง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _agencyNameTH, 380, _y, 0);//สังกัด

                    //No,Moo,Soi
                    _y = 600;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 110, _y, 0);//บ้านเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 190, _y, 0);//หมู่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 270, _y, 0);//ตรอก/ซอย
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 410, _y, 0);//ถนน

                    //subdistrict,district,provice
                    _y = 578;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 110, _y, 0);//ตำบล/แขวง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 265, _y, 0);//อำเภอ/เขต
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 400, _y, 0);//จังหวัด

                    //zipcode,phone,mobile
                    _y = 555;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 110, _y, 0);//รหัสไปรษณีย์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 250, _y, 0);//เบอร์โทรศัพท์บ้าน
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _mobile, 430, _y, 0);//เบอร์โทรศัพท์มือถือ

                    //marrie Name
                    _y = 530;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 180, _y, 0);//รหัสบัตรประชาชน
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameMarTh, 380, _y, 0);//ชื่อคู่สมรส

                    //Name Student
                    _y = 460;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 100, _y, 0);//ชื่อนักศึกษา

                    //date Contract
                    _y = 438;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateContract, 150, _y, 0);//วันที่ทำสัญญา

                }
                else if (_ProgramCode == "RANSB")
                {
                    //ContractId 
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);

                    ////แกน Y
                    //for (int i = 0; i <= 800; i += 10)
                    //{
                    //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                    //}
                    ////แกน X
                    //for (int i = 600; i >= 0; i -= 10)
                    //{
                    //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                    //}


                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                    //Current Date
                    _y = 670;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.SetColorFill(BaseColor.BLACK);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayP1, 390, _y, 0);//Date
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThP1, 435, _y, 0);//Month
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThP1, 515, _y, 0);//Year

                    //Name-LastName,age parent
                    _y = 650;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 180, _y, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 490, _y, 0);

                    //Occupation position agency
                    _y = 625;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _thOccupation, 80, _y, 0);//อาชีพ
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _position, 250, _y, 0);//ตำแหน่ง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _agencyNameTH, 380, _y, 0);//สังกัด

                    //No,Moo,Soi
                    _y = 600;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 110, _y, 0);//บ้านเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 190, _y, 0);//หมู่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 270, _y, 0);//ตรอก/ซอย
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 410, _y, 0);//ถนน

                    //subdistrict,district,provice
                    _y = 578;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 110, _y, 0);//ตำบล/แขวง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 265, _y, 0);//อำเภอ/เขต
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 400, _y, 0);//จังหวัด

                    //zipcode,phone,mobile
                    _y = 555;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 110, _y, 0);//รหัสไปรษณีย์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 250, _y, 0);//เบอร์โทรศัพท์บ้าน
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _mobile, 430, _y, 0);//เบอร์โทรศัพท์มือถือ

                    //marrie Name
                    _y = 530;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 180, _y, 0);//รหัสบัตรประชาชน
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameMarTh, 380, _y, 0);//ชื่อคู่สมรส

                    //Name Student
                    _y = 460;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 100, _y, 0);//ชื่อนักศึกษา

                    //date Contract
                    _y = 438;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateContract, 150, _y, 0);//วันที่ทำสัญญา

                }
                else if (_ProgramCode == "NSNSB")
                {
                    //ContractId 
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);

                    ////แกน Y
                    //for (int i = 0; i <= 800; i += 10)
                    //{
                    //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                    //}
                    ////แกน X
                    //for (int i = 600; i >= 0; i -= 10)
                    //{
                    //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                    //}


                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                    //Current Date
                    _y = 670;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.SetColorFill(BaseColor.BLACK);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayP1, 390, _y, 0);//Date
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThP1, 435, _y, 0);//Month
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThP1, 515, _y, 0);//Year

                    //Name-LastName,age parent
                    _y = 650;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 180, _y, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 490, _y, 0);

                    //Occupation position agency
                    _y = 625;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _thOccupation, 80, _y, 0);//อาชีพ
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _position, 250, _y, 0);//ตำแหน่ง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _agencyNameTH, 380, _y, 0);//สังกัด

                    //No,Moo,Soi
                    _y = 600;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 110, _y, 0);//บ้านเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 190, _y, 0);//หมู่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 270, _y, 0);//ตรอก/ซอย
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 410, _y, 0);//ถนน

                    //subdistrict,district,provice
                    _y = 578;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 110, _y, 0);//ตำบล/แขวง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 265, _y, 0);//อำเภอ/เขต
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 400, _y, 0);//จังหวัด

                    //zipcode,phone,mobile
                    _y = 555;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 110, _y, 0);//รหัสไปรษณีย์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 250, _y, 0);//เบอร์โทรศัพท์บ้าน
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _mobile, 430, _y, 0);//เบอร์โทรศัพท์มือถือ

                    //marrie Name
                    _y = 530;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 180, _y, 0);//รหัสบัตรประชาชน
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameMarTh, 380, _y, 0);//ชื่อคู่สมรส

                    //Name Student
                    _y = 460;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 100, _y, 0);//ชื่อนักศึกษา

                    //date Contract
                    _y = 438;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateContract, 150, _y, 0);//วันที่ทำสัญญา

                }
                _cb.EndText();
                //ขึ้นหน้าใหม่
                _document.NewPage();
                _cb.BeginText();

                //หน้าที่ 2 relationship
                PdfImportedPage page2 = _writer.GetImportedPage(_reader, 2);//หน้า pdf template 2
                _cb.AddTemplate(page2, 0, 0);
                //ContractId 
                _y = 745;
                _cb.SetFontAndSize(_bf, 10);
                _cb.SetColorFill(BaseColor.GRAY);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                if (_ProgramCode == "SIMDB" || _ProgramCode == "RAMDB")
                {
                    _y = 322;
                }
                else if (_ProgramCode == "PYPYB")
                {
                    _y = 290;
                }
                else if (_ProgramCode == "DTDSB")
                {
                    _y = 290;
                }
                else if (_ProgramCode == "RANSB")
                {
                    _y = 270;
                }
                else if (_ProgramCode == "NSNSB")
                {
                    _y = 270;
                }

                _cb.SetFontAndSize(_bf, 15);
                _cb.SetColorFill(BaseColor.BLACK);
                ////แกน Y
                //for (int i = 0; i <= 800; i += 10)
                //{
                //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                //}
                ////แกน X
                //for (int i = 600; i >= 0; i -= 10)
                //{
                //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                //}
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _relationship, 290, _y, 0);//เกี่ยวพันกับนักศึกษาโดยเป็น
                _cb.EndText();

                //ขึ้นหน้าใหม่
                _document.NewPage();
                _cb.BeginText();

                //หน้าที่ 3 ลายเซ็นผู้ค้ำ
                PdfImportedPage page3 = _writer.GetImportedPage(_reader, 3);//หน้า pdf template 3
                _cb.AddTemplate(page3, 0, 0);
                //ContractId 
                _y = 745;
                _cb.SetFontAndSize(_bf, 10);
                _cb.SetColorFill(BaseColor.GRAY);
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                _cb.SetFontAndSize(_bf, 15);
                _cb.SetColorFill(BaseColor.BLACK);

                ////แกน Y
                //for (int i = 0; i <= 800; i += 10)
                //{
                //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                //}
                ////แกน X
                //for (int i = 600; i >= 0; i -= 10)
                //{
                //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                //}
                if (_ProgramCode == "SIMDB" || _ProgramCode == "RAMDB")
                {
                    _y = 375;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 325, _y, 0);//ลงชื่อผู้ค้ำประกัน

                    _y = 343;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 325, _y, 0);//ลงชื่อผู้ค้ำประกัน
                    _cb.EndText();
                }
                else if (_ProgramCode == "PYPYB")
                {
                    _y = 355;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 325, _y, 0);//ลงชื่อผู้ค้ำประกัน

                    _y = 320;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 325, _y, 0);//ลงชื่อผู้ค้ำประกัน
                    _cb.EndText();
                }
                else if (_ProgramCode == "DTDSB")
                {
                    _y = 375;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 325, _y, 0);//ลงชื่อผู้ค้ำประกัน

                    _y = 343;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 325, _y, 0);//ลงชื่อผู้ค้ำประกัน
                    _cb.EndText();
                }
                else if (_ProgramCode == "RANSB")
                {
                    _y = 330;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 325, _y, 0);//ลงชื่อผู้ค้ำประกัน

                    _y = 300;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 325, _y, 0);//ลงชื่อผู้ค้ำประกัน
                    _cb.EndText();
                }
                else if (_ProgramCode == "NSNSB")
                {
                    _y = 330;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 325, _y, 0);//ลงชื่อผู้ค้ำประกัน

                    _y = 300;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 325, _y, 0);//ลงชื่อผู้ค้ำประกัน
                    _cb.EndText();
                }

                //ขึ้นหน้าใหม่
                _document.NewPage();
                _cb.BeginText();

                //หน้าที่ 4 หนังสือให้ความยินยอมคู่สมรส
                PdfImportedPage page4 = _writer.GetImportedPage(_reader, 4);//หน้า pdf template 4
                _cb.AddTemplate(page4, 0, 0);

                string _idCardonsent = "", _fullNameThonsent = "", _fullNameThonsent1 = "", _ageonsent = "";
                string _dateSign = Myconfig.CvEmpty(_ctInfo.DateLongContractParent2, "");
                if (_dateSign == "")
                {
                    _dateSign = _date.Day + " " + _date.MonthNameTh + " " + _date.YearTh;
                }
                //ข้อมูลบิดา
                //ผู้ให้ควมยินยอมคู่สมรส
                //parent sign

                string _signCur = Myconfig.CvEmpty(_parentInfo.FullNameTh, " - ");
                //string _consentBy = _ctInfo.ConsentBy;//ยินยอมโดย
                //string _warrantBy = _ctInfo.WarrantBy;//ค้ำประกัน
                //string _aliveF = _ctInfo.IsAliveFather;//สถานะพ่อ 1=มีชีวิต , 2 = เสียชีวิต
                //string _aliveM = _ctInfo.IsAliveMother;//สถานะแม่ 1=มีชีวิต , 2 = เสียชีวิต
                //string _marriage = _ctInfo.IsMarriage;//1=สมรส,2=สมรส(ไม่ได้จดทะเบียน),3=บิดามารดาหย่าร้าง
                string _remark = "";//หมายเหตุ

                //---กรณีสมรสกันบิดาและมารดายังมีชีวิตอยู่ทั้งคู่
                if (_marriage == "1") //รวมไปถึง maritalStatus = 4,5
                {
                    if (_aliveF == "1" && _aliveM == "1")
                    {
                        if (_consentBy == "F")//แม่ค้ำ พ่อยินยอมคู่สมรส
                        {
                            _fullNameThonsent = Myconfig.CvEmpty(_parentFInfo.FullNameTh, " - ");
                            _fullNameThonsent1 = Myconfig.CvEmpty(_parentMInfo.FullNameTh, " - ");
                            _ageonsent = Myconfig.CvEmpty(_parentFInfo.Age, " - ");
                            _idCardonsent = Myconfig.CvEmpty(_parentFInfo.IdCard, " - ");
                        }
                        else if (_consentBy == "M")//พ่อค้ำ แม่ยินยอมคู่สมรส
                        {
                            _fullNameThonsent = Myconfig.CvEmpty(_parentMInfo.FullNameTh, " - ");//ผู้ให้ความยินยอม
                            _fullNameThonsent1 = Myconfig.CvEmpty(_parentFInfo.FullNameTh, " - ");//ผู้ค้ำ
                            _ageonsent = Myconfig.CvEmpty(_parentMInfo.Age, " - ");
                            _idCardonsent = Myconfig.CvEmpty(_parentMInfo.IdCard, " - ");
                        }
                        else
                        {
                            _fullNameThonsent = " - ";
                            _fullNameThonsent1 = " - ";
                            _ageonsent = " - ";
                            _idCardonsent = " - ";
                        }
                    }
                    else if (_aliveM == "1" && _aliveF == "2")
                    {
                        _fullNameThonsent = " - ";
                        _fullNameThonsent1 = " - ";
                        _ageonsent = " - ";
                        _idCardonsent = " - ";
                        _dateSign = "-";
                        //_remark = "หมายเหตุ : บิดาเสียชีวิต";
                        _assure2 = "X";//คู่สมรสตาย : ใช้กับเคสที่เป็นหม้าย
                    }
                    else if (_aliveM == "2" && _aliveF == "1")
                    {
                        _fullNameThonsent = " - ";
                        _fullNameThonsent1 = " - ";
                        _ageonsent = " - ";
                        _idCardonsent = " - ";
                        _dateSign = "-";
                        //_remark = "หมายเหตุ : มารดาเสียชีวิต";
                        _assure2 = "X";//คู่สมรสตาย : ใช้กับเคสที่เป็นหม้าย
                    }
                }
                else
                {
                    //---กรณี ไม่สมรสหรือหย่าร้าง
                    _fullNameThonsent = "-";
                    _fullNameThonsent1 = " - ";
                    _ageonsent = " - ";
                    _idCardonsent = " - ";
                    _signCur = "-";
                    _dateSign = "-";
                    if (_marriage == "2")//สมรส (ไม่จดทะเบียน)
                    {
                        //_remark = "หมายเหตุ : บิดาและมารดามิได้จดทะเบียนสมรสกัน";
                        _assure1 = "X";//โสด : ใช้กับเคสที่ไม่จดทะเบียนสมรส กับเคสที่เป็นโสด
                    }
                    else if (_marriage == "3")
                    {
                        //_remark = "หมายเหตุ : บิดาและมารดาจดทะเบียนหย่า";
                        _assure3 = "X";//- หย่าร้าง : ใช้กับเคสที่เป็นหย่าร้าง
                    }
                }
                string _singleSts = _assure1 == "X" ? "X" : "";//คู่สมรสตาย : ใช้กับเคสที่เป็นหม้าย
                string _dieSts = _assure2 == "X" ? "X" : "";//โสด : ใช้กับเคสที่ไม่จดทะเบียนสมรส กับเคสที่เป็นโสด
                string _divorceSts = _assure3 == "X" ? "X" : ""; //-หย่าร้าง : ใช้กับเคสที่เป็นหย่าร้าง

                //ผู้ค้ำประกัน ไม่ใช่ คนเดียวกันกับผู้ยินยอม
                if (_warrantBy != _consentBy)
                {

                    if (_ProgramCode == "SIMDB")
                    {
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        ////แกน Y
                        //for (int i = 0; i <= 800; i += 10)
                        //{
                        //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                        //}
                        ////แกน X
                        //for (int i = 600; i >= 0; i -= 10)
                        //{
                        //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                        //}
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Name-LastName,age parent
                        _y = 692;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 130, _y, 0);//
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ageonsent, 305, _y, 0);//อายุ
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCardonsent, 445, _y, 0);//รหัสบัตรประชาชน

                        //คู่สมรส
                        _y = 670;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 150, _y, 0);
                        //คู่สมรส
                        _y = 647;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 90, _y, 0);
                        //วันที่
                        _y = 625;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateSign, 60, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 370, _y, 0);
                        //ลงนาม
                        _y = 580;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 320, _y, 0);
                        _y = 543;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 320, _y, 0);

                        _y = 510;
                        //รับรอง assure โสด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _singleSts, 206, _y, 0);
                        //รับรอง assure คู่สมรสตาย
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dieSts, 276, _y, 0);
                        //รับรอง assure หย่าร้าง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _divorceSts, 370, _y, 0);
                        //รหัสนักศึกษา
                        _y = 480;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentProgram, 380, _y, 0);
                        ////หมายเหตุ
                        //_y = 450;
                        //_cb.SetFontAndSize(_bf, 18);
                        //_cb.SetColorFill(BaseColor.BLACK);
                        //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _remark, 60, _y, 0);
                        //_cb.EndText();
                    }
                    else if (_ProgramCode == "RAMDB")
                    {
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        ////แกน Y
                        //for (int i = 0; i <= 800; i += 10)
                        //{
                        //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                        //}
                        ////แกน X
                        //for (int i = 600; i >= 0; i -= 10)
                        //{
                        //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                        //}
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Name-LastName,age parent
                        _y = 692;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 130, _y, 0);//
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ageonsent, 305, _y, 0);//อายุ
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCardonsent, 445, _y, 0);//รหัสบัตรประชาชน

                        //คู่สมรส
                        _y = 670;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 150, _y, 0);
                        //คู่สมรส
                        _y = 647;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 90, _y, 0);
                        //วันที่
                        _y = 625;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateSign, 60, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 370, _y, 0);
                        //ลงนาม
                        _y = 580;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 320, _y, 0);
                        _y = 543;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 320, _y, 0);

                        _y = 510;
                        //รับรอง assure โสด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _singleSts, 206, _y, 0);
                        //รับรอง assure คู่สมรสตาย
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dieSts, 276, _y, 0);
                        //รับรอง assure หย่าร้าง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _divorceSts, 370, _y, 0);
                        //รหัสนักศึกษา
                        _y = 480;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentProgram, 380, _y, 0);
                        ////หมายเหตุ
                        //_y = 450;
                        //_cb.SetFontAndSize(_bf, 18);
                        //_cb.SetColorFill(BaseColor.BLACK);
                        //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _remark, 60, _y, 0);
                        //_cb.EndText();
                    }
                    else if (_ProgramCode == "PYPYB")
                    {
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        ////แกน Y
                        //for (int i = 0; i <= 800; i += 10)
                        //{
                        //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                        //}
                        ////แกน X
                        //for (int i = 600; i >= 0; i -= 10)
                        //{
                        //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                        //}
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Name-LastName,age parent
                        _y = 692;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 130, _y, 0);//
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ageonsent, 305, _y, 0);//อายุ
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCardonsent, 445, _y, 0);//รหัสบัตรประชาชน

                        //คู่สมรส
                        _y = 670;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 150, _y, 0);
                        //คู่สมรส
                        _y = 647;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 90, _y, 0);
                        //วันที่
                        _y = 625;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateSign, 60, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 370, _y, 0);
                        //ลงนาม
                        _y = 580;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 320, _y, 0);
                        _y = 543;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 320, _y, 0);

                        _y = 510;
                        //รับรอง assure โสด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _singleSts, 206, _y, 0);
                        //รับรอง assure คู่สมรสตาย
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dieSts, 276, _y, 0);
                        //รับรอง assure หย่าร้าง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _divorceSts, 370, _y, 0);
                        //รหัสนักศึกษา
                        _y = 480;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentProgram, 380, _y, 0);
                        ////หมายเหตุ
                        //_y = 450;
                        //_cb.SetFontAndSize(_bf, 18);
                        //_cb.SetColorFill(BaseColor.BLACK);
                        //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _remark, 60, _y, 0);
                        //_cb.EndText();
                    }
                    else if (_ProgramCode == "DTDSB")
                    {
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        ////แกน Y
                        //for (int i = 0; i <= 800; i += 10)
                        //{
                        //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                        //}
                        ////แกน X
                        //for (int i = 600; i >= 0; i -= 10)
                        //{
                        //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                        //}
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Name-LastName,age parent
                        _y = 692;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 130, _y, 0);//
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ageonsent, 305, _y, 0);//อายุ
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCardonsent, 445, _y, 0);//รหัสบัตรประชาชน

                        //คู่สมรส
                        _y = 670;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 150, _y, 0);
                        //คู่สมรส
                        _y = 647;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 90, _y, 0);
                        //วันที่
                        _y = 625;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateSign, 60, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 370, _y, 0);
                        //ลงนาม
                        _y = 580;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 320, _y, 0);
                        _y = 543;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 320, _y, 0);

                        _y = 510;
                        //รับรอง assure โสด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _singleSts, 206, _y, 0);
                        //รับรอง assure คู่สมรสตาย
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dieSts, 276, _y, 0);
                        //รับรอง assure หย่าร้าง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _divorceSts, 370, _y, 0);
                        //รหัสนักศึกษา
                        _y = 480;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentProgram, 380, _y, 0);
                        ////หมายเหตุ
                        //_y = 450;
                        //_cb.SetFontAndSize(_bf, 18);
                        //_cb.SetColorFill(BaseColor.BLACK);
                        //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _remark, 60, _y, 0);
                        //_cb.EndText();
                    }
                    else if (_ProgramCode == "RANSB")
                    {
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        ////แกน Y
                        //for (int i = 0; i <= 800; i += 10)
                        //{
                        //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                        //}
                        ////แกน X
                        //for (int i = 600; i >= 0; i -= 10)
                        //{
                        //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                        //}
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Name-LastName,age parent
                        _y = 692;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 130, _y, 0);//
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ageonsent, 305, _y, 0);//อายุ
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCardonsent, 445, _y, 0);//รหัสบัตรประชาชน

                        //คู่สมรส
                        _y = 670;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 150, _y, 0);
                        //คู่สมรส
                        _y = 647;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 90, _y, 0);
                        //วันที่
                        _y = 625;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateSign, 60, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 370, _y, 0);
                        //ลงนาม
                        _y = 580;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 320, _y, 0);
                        _y = 543;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 320, _y, 0);

                        _y = 510;
                        //รับรอง assure โสด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _singleSts, 206, _y, 0);
                        //รับรอง assure คู่สมรสตาย
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dieSts, 276, _y, 0);
                        //รับรอง assure หย่าร้าง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _divorceSts, 370, _y, 0);
                        //รหัสนักศึกษา
                        _y = 480;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentProgram, 380, _y, 0);
                        ////หมายเหตุ
                        //_y = 450;
                        //_cb.SetFontAndSize(_bf, 18);
                        //_cb.SetColorFill(BaseColor.BLACK);
                        //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _remark, 60, _y, 0);
                        //_cb.EndText();
                    }
                    else if (_ProgramCode == "NSNSB")
                    {
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        ////แกน Y
                        //for (int i = 0; i <= 800; i += 10)
                        //{
                        //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                        //}
                        ////แกน X
                        //for (int i = 600; i >= 0; i -= 10)
                        //{
                        //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                        //}
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                                //Name-LastName,age parent
                        _y = 692;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 130, _y, 0);//
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ageonsent, 305, _y, 0);//อายุ
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCardonsent, 445, _y, 0);//รหัสบัตรประชาชน

                        //คู่สมรส
                        _y = 670;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 150, _y, 0);
                        //คู่สมรส
                        _y = 647;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 90, _y, 0);
                        //วันที่
                        _y = 625;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateSign, 60, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 370, _y, 0);
                        //ลงนาม
                        _y = 580;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 320, _y, 0);
                        _y = 543;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 320, _y, 0);

                        _y = 510;
                        //รับรอง assure โสด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _singleSts, 206, _y, 0);
                        //รับรอง assure คู่สมรสตาย
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dieSts, 276, _y, 0);
                        //รับรอง assure หย่าร้าง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _divorceSts, 370, _y, 0);
                        //รหัสนักศึกษา
                        _y = 480;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentProgram, 380, _y, 0);
                        ////หมายเหตุ
                        //_y = 450;
                        //_cb.SetFontAndSize(_bf, 18);
                        //_cb.SetColorFill(BaseColor.BLACK);
                        //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _remark, 60, _y, 0);
                        //_cb.EndText();
                    }


                    //
                }
                //
                else
                {

                    //ContractId
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);
                    ////แกน Y
                    //for (int i = 0; i <= 800; i += 10)
                    //{
                    //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", 0, i, 0);
                    //}
                    ////แกน X
                    //for (int i = 600; i >= 0; i -= 10)
                    //{
                    //    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                    //}
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_C", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                            //Name-LastName,age parent
                    _y = 692;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.SetColorFill(BaseColor.BLACK);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 130, _y, 0);//
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ageonsent, 305, _y, 0);//อายุ
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCardonsent, 445, _y, 0);//รหัสบัตรประชาชน

                    //คู่สมรส
                    _y = 670;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 150, _y, 0);
                    //คู่สมรส
                    _y = 647;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 90, _y, 0);
                    //วันที่
                    _y = 625;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateSign, 60, _y, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent1, 370, _y, 0);
                    //ลงนาม
                    _y = 580;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 320, _y, 0);
                    _y = 543;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameThonsent, 320, _y, 0);

                    _y = 510;
                    //รับรอง assure โสด
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _singleSts, 206, _y, 0);
                    //รับรอง assure คู่สมรสตาย
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dieSts, 276, _y, 0);
                    //รับรอง assure หย่าร้าง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _divorceSts, 370, _y, 0);
                    //รหัสนักศึกษา
                    _y = 480;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentProgram, 380, _y, 0);
                    ////หมายเหตุ
                    //_y = 450;
                    //_cb.SetFontAndSize(_bf, 18);
                    //_cb.SetColorFill(BaseColor.BLACK);
                    //_cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _remark, 60, _y, 0);
                    //_cb.EndText();
                }
                _cb.EndText();
                _document.Close();
                _writer.Close();
                _reader.Close();

                //update warranPath C
                //string _warranPath = Server.MapPath("~/ElectronicContract/" + _acaYear + "/" + _ProgramCode + _programCodeExtra + "/") + _fileName;
                string _warranPath = "C:\\inetpub\\wwwroot\\Econtract\\ElectronicContract\\" + _acaYear + "\\" + _ProgramCode + _programCodeExtra + "\\" + _fileName;
                ContractDB.SetWarranPath(_studentId, _acaYear, _warranPath);

                FileStream sourceFile = new FileStream((Server.MapPath("~/ElectronicContract/" + _acaYear + "/" + _ProgramCode + _programCodeExtra + "/") + _fileName), FileMode.Open);
                long FileSize;
                FileSize = sourceFile.Length;
                byte[] getContent = new byte[(int)FileSize];
                sourceFile.Read(getContent, 0, (int)sourceFile.Length);
                sourceFile.Close();
                Response.BinaryWrite(getContent);
            //}
            //else
            //{
            //    //กรณีมี File สัญญาในระบบแล้ว เปิดอ่านเลย

            //    WebClient client3 = new WebClient();
            //    Byte[] buffer3 = client3.DownloadData(_warran);
            //    Response.ContentType = "application/pdf";
            //    Response.AddHeader("content-length", buffer3.Length.ToString());
            //    Response.BinaryWrite(buffer3);
            //    client3.Dispose();
            //}


        }

        #endregion printWarrant_NEW20170820

        #region printGarrantee
        /// <summary>
        /// Author: Anussara Wanwang
        /// Create Date: 11-12-2015
        /// Update Date: 07-08-2020
        /// Description: หนังสือให้ความยินยอมของผู้แทนโดยชอบธรรม B
        /// Parameter:n/a
        /// </summary>
        public void printGarrantee(string _studentId, string _parentType, string _studentCode)
        {
            //ในกรณีที่มี file ใน Folder แล้วให้เปิดเลย ไม่ต้องสร้าง pdf ใหม่
            ContractInfo _ctInfo = new ContractInfo(_studentId);
            string _garrantee = Myconfig.CvEmpty(_ctInfo.garranteePath, " - ");
            if (_garrantee == " - ")
            {
                StringBuilder _string = new StringBuilder();

                StudentInfo _stdInfo = new StudentInfo(_studentCode);
                ParentInfo _parentInfo = new ParentInfo(_studentId, _parentType);
                ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
                ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
                CurDate _date = new CurDate();
                //string _acaYear = Myconfig.GetYearContract();
                string _acaYear = Myconfig.CvEmpty(_stdInfo.AcaYear, " - ");
                string _quotaCode = _stdInfo.QuotaCode;
                string _warrantBy = _ctInfo.WarrantBy;
                string _consentBy = _ctInfo.ConsentBy;
                string _programCodeExtra = "";
                string _stdNameTh, _programNameTh, _ProgramCode;
                //ข้อมูลนักศึกษา
                _stdNameTh = Myconfig.CvEmpty(_stdInfo.StdNameTh, " - ");
                _programNameTh = Myconfig.CvEmpty(_stdInfo.ProgramNameTh, " - ");
                //_studentCode = Myconfig.CvEmpty(_stdInfo.StudentCode, " - ");
                _ProgramCode = Myconfig.CvEmpty(_stdInfo.ProgramCode, " - ");

                string _idCard, _fullNameTh, _age, _moo, _no, _soi, _road, _subdistrict
                    , _district, _provice, _zipcode, _phone, _statusContract; ;

                string _signFather, _signMother;

                string _dateContract = _ctInfo.DateLongContractStudent;
                int _checkAcaYear = Convert.ToInt32(_acaYear);
                if (_checkAcaYear < 2565)
                {
                    _statusContract = "OLD";
                }
                else
                {
                    _statusContract = "NEW";
                }

                //ข้อมูลบิดา ถ้าเป็นผู้ค้ำประกัน หรือ ผู้ยินยอมคู่สมรส ให้รับรองบุตรด้วย
                if (_warrantBy == "F" || _consentBy == "F")
                {
                    _fullNameTh = Myconfig.CvEmpty(_parentFInfo.FullNameTh, " - ");
                    _age = Myconfig.CvEmpty(_parentFInfo.Age, " - ");
                    _moo = Myconfig.CvEmpty(_parentFInfo.MooPermanent, " - ");
                    _no = Myconfig.CvEmpty(_parentFInfo.NoPermanent, " - ");
                    _soi = Myconfig.CvEmpty(_parentFInfo.SoiPermanent, " - ");
                    _road = Myconfig.CvEmpty(_parentFInfo.RoadPermanent, " - ");
                    _subdistrict = Myconfig.CvEmpty(_parentFInfo.ThSubdistrictName, " - ");
                    _district = Myconfig.CvEmpty(_parentFInfo.ThDistrictName, " - ");
                    _provice = Myconfig.CvEmpty(_parentFInfo.ProvinceNameTH, " - ");
                    _zipcode = Myconfig.CvEmpty(_parentFInfo.ZipCodePermanent, " - ");
                    _phone = Myconfig.CvEmpty(_parentFInfo.PhoneNumberPermanent, " - ");
                    _idCard = Myconfig.CvEmpty(_parentFInfo.IdCard, " - ");
                    _signFather = Myconfig.CvEmpty(_parentFInfo.FullNameTh, " - ");
                }
                else
                {
                    _fullNameTh = " - ";
                    _age = " - ";
                    _moo = " - ";
                    _no = " - ";
                    _soi = " - ";
                    _road = " - ";
                    _subdistrict = " - ";
                    _district = " - ";
                    _provice = " - ";
                    _zipcode = " - ";
                    _phone = " - ";
                    _idCard = " - ";
                    _signFather = " - ";
                }


                //end father profile



                string _path = Server.MapPath("~");
                string _fileTmp = "";
                //เรียกใช้ file Template
                switch (_ProgramCode)
                {
                    case "SIMDB":
                        switch (_statusContract)
                        {
                            case "OLD":
                                _fileTmp = _path + "/Template/B_Consent/Consent1.pdf";
                                break;
                            case "NEW":
                                _fileTmp = _path + "/Template/B_Consent/SIMDB-2565-consent.pdf";
                                break;
                        }
                        break;
                    case "RAMDB":
                        switch (_statusContract)
                        {
                            case "OLD":
                                _fileTmp = _path + "/Template/B_Consent/Consent1.pdf";
                                break;
                            case "NEW":
                                _fileTmp = _path + "/Template/B_Consent/RAMDB-2565-consent.pdf";
                                break;
                        }
                        break;

                    case "DTDSB":
                        switch (_statusContract)
                        {
                            case "OLD":
                                _fileTmp = _path + "/Template/B_Consent/Consent2.pdf";
                                break;
                            case "NEW":
                                _fileTmp = _path + "/Template/B_Consent/DTDSB-2565-consent.pdf";
                                break;
                        }
                        break;

                    case "PYPYB":
                        _fileTmp = _path + "/Template/B_Consent/Consent3.pdf";
                        break;

                    case "RANSB":
                    case "NSNSB":
                        _fileTmp = _path + "/Template/B_Consent/Consent4.pdf";
                        break;
                }

                //Folder extra
                switch (_quotaCode)
                {
                    default: // siriraj hospital
                        _programCodeExtra = "";
                        break;
                    case "354":
                        _programCodeExtra = "_CL";
                        break;
                    case "351":
                        _programCodeExtra = "_TM";
                        break;
                }
                string _fileName = _studentCode + _ProgramCode + _programCodeExtra + "_B.pdf";
                string _fileDocument = _path + "/ElectronicContract/" + _fileName;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + _studentCode + "_B.pdf");
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Open the reader
                PdfReader _reader = new PdfReader(_fileTmp);//file Template

                //string path = requestObj.PhysicalApplicationPath + "\\electronicContract\\" 
                DirectoryInfo DirInfo = new DirectoryInfo(Server.MapPath("~/ElectronicContract/" + _acaYear + "/" + _ProgramCode + _programCodeExtra + "/"));  // ต้องเป็นตัวแปรโฟลเดอร์ด้วยนะ
                if (!DirInfo.Exists)
                {
                    //  Response.Write("OK");
                    DirInfo.Create();
                }
                Document _document = new Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F);
                // open the writer
                PdfWriter _writer = PdfWriter.GetInstance(_document, new FileStream(Server.MapPath("~/ElectronicContract/" + _acaYear + "/" + _ProgramCode + _programCodeExtra + "/") + _fileName, FileMode.Create));
                //PdfWriter _writer = PdfWriter.GetInstance(_document, Response.OutputStream);
                Response.Charset = String.Empty;
                Response.ClearContent();
                _document.Open();
                int _y = 0;
                //Configure the content
                PdfContentByte _cb = _writer.DirectContent;
                //Write the text here
                _cb.BeginText();
                //หน้าที่ 1
                PdfImportedPage page1 = _writer.GetImportedPage(_reader, 1);//หน้า pdf template 1
                _cb.AddTemplate(page1, 0, 0);


                if (_ProgramCode == "SIMDB" || _ProgramCode == "RAMDB")
                {
                    if (_statusContract == "OLD")
                    {// acaYear < 2565
                        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_B", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                        //Current Date
                        _y = 670;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayP2, 418, _y, 0);//Date
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThP2, 460, _y, 0);//Month
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThP2, 523, _y, 0);//Year

                        //Name-LastName,age parent
                        _y = 647;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh + "  (บิดา)", 180, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 510, _y, 0);

                        //No,Moo,Soi
                        _y = 625;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 110, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 200, _y, 0);//หมู่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 290, _y, 0);//ตรอก/ซอย
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 430, _y, 0);//ถนน

                        //road,subdistrict,district
                        _y = 600;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 110, _y, 0);//ตำบล/แขวง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 282, _y, 0);//อำเภอ/เขต
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 415, _y, 0);//จังหวัด

                        //provice,zipcode,phone
                        _y = 578;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 130, _y, 0);//รหัสไปรษณีย์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 220, _y, 0);//เบอร์โทรศัพท์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 420, _y, 0);//รหัสบัตรประชาชน

                        //sign father
                        _y = 295;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 350, _y, 0);
                    }
                    else
                    {// acayear >= 2565

                        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        //ContractId
                        _y = 746;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_B", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                        //Current Date
                        _y = 645;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayP2, 346, _y, 0);//Date
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThP2, 400, _y, 0);//Month
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThP2, 509, _y, 0);//Year

                        //Name-LastName,age parent, NO., MOO
                        _y = 611;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 180, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 338, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 433, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 521, _y, 0);//หมู่

                        //Soi, Road, SubDistrict
                        _y = 587;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 136, _y, 0);//ตรอก/ซอย
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 251, _y, 0);//ถนน
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 424, _y, 0);//ตำบล/แขวง

                        //District, Province, Zipcode
                        _y = 566;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 136, _y, 0);//อำเภอ/เขต
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 300, _y, 0);//จังหวัด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 489, _y, 0);//รหัสไปรษณีย์

                        //Telephone, IdCard
                        _y = 545;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 125, _y, 0);//เบอร์โทรศัพท์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 347, _y, 0);//รหัสบัตรประชาชน
                    }
                }
                else if (_ProgramCode == "DTDSB")
                {
                    if (_statusContract == "OLD")
                    {

                        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        //ContractId
                        _y = 745;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_B", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                        //Current Date
                        _y = 670;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayP2, 418, _y, 0);//Date
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThP2, 460, _y, 0);//Month
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThP2, 523, _y, 0);//Year

                        //Name-LastName,age parent
                        _y = 647;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh + "  (บิดา)", 180, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 510, _y, 0);

                        //No,Moo,Soi
                        _y = 625;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 130, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 210, _y, 0);//หมู่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 310, _y, 0);//ตรอก/ซอย
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 450, _y, 0);//ถนน

                        //road,subdistrict,district
                        _y = 600;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 110, _y, 0);//ตำบล/แขวง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 282, _y, 0);//อำเภอ/เขต
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 415, _y, 0);//จังหวัด

                        //provice,zipcode,phone
                        _y = 578;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 130, _y, 0);//รหัสไปรษณีย์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 220, _y, 0);//เบอร์โทรศัพท์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 420, _y, 0);//รหัสบัตรประชาชน
                                                                                            //sign father
                        _y = 295;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 350, _y, 0);

                    }
                    else
                    {// acayear >= 2565

                        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        //ContractId
                        _y = 746;
                        _cb.SetFontAndSize(_bf, 10);
                        _cb.SetColorFill(BaseColor.GRAY);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_B", 438, _y, 0);//สัญญาเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                        //Current Date
                        _y = 645;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.SetColorFill(BaseColor.BLACK);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayP2, 346, _y, 0);//Date
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThP2, 400, _y, 0);//Month
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThP2, 509, _y, 0);//Year

                        //Name-LastName,age parent, NO., MOO
                        _y = 610;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 180, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 338, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 433, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 521, _y, 0);//หมู่

                        //Soi, Road, SubDistrict
                        _y = 587;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 136, _y, 0);//ตรอก/ซอย
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 251, _y, 0);//ถนน
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 424, _y, 0);//ตำบล/แขวง

                        //District, Province, Zipcode
                        _y = 566;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 136, _y, 0);//อำเภอ/เขต
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 300, _y, 0);//จังหวัด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 489, _y, 0);//รหัสไปรษณีย์

                        //Telephone, IdCard
                        _y = 545;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 125, _y, 0);//เบอร์โทรศัพท์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 347, _y, 0);//รหัสบัตรประชาชน
                    }
                }
                else if (_ProgramCode == "PYPYB")
                {
                    BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                    //ContractId
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_B", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา

                    //Current Date
                    _y = 670;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.SetColorFill(BaseColor.BLACK);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayP2, 418, _y, 0);//Date
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThP2, 460, _y, 0);//Month
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThP2, 523, _y, 0);//Year

                    //Name-LastName,age parent
                    _y = 648;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh + "  (บิดา)", 180, _y, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 510, _y, 0);

                    //No,Moo,Soi
                    _y = 625;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 130, _y, 0);//บ้านเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 220, _y, 0);//หมู่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 300, _y, 0);//ตรอก/ซอย
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 445, _y, 0);//ถนน

                    //road,subdistrict,district
                    _y = 600;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 110, _y, 0);//ตำบล/แขวง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 280, _y, 0);//อำเภอ/เขต
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 410, _y, 0);//จังหวัด

                    //provice,zipcode,phone
                    _y = 578;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 130, _y, 0);//รหัสไปรษณีย์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 220, _y, 0);//เบอร์โทรศัพท์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 420, _y, 0);//รหัสบัตรประชาชน

                    //sign father
                    _y = 295;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 400, _y, 0);
                }
                else if (_ProgramCode == "RANSB" || _ProgramCode == "NSNSB")
                {
                    BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    //ContractId
                    _y = 745;
                    _cb.SetFontAndSize(_bf, 10);
                    _cb.SetColorFill(BaseColor.GRAY);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode + "_B", 438, _y, 0);//สัญญาเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _studentCode + _ProgramCode, 540, _y, 0);//รหัสนักศึกษา
                                                                                                            //Current Date
                    _y = 670;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.SetColorFill(BaseColor.BLACK);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayP2, 418, _y, 0);//Date
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThP2, 460, _y, 0);//Month
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThP2, 523, _y, 0);//Year
                                                                                                 //Name-LastName,age parent
                    _y = 648;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh + "  (บิดา)", 180, _y, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 505, _y, 0);
                    //No,Moo,Soi
                    _y = 625;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 115, _y, 0);//บ้านเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 220, _y, 0);//หมู่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 300, _y, 0);//ตรอก/ซอย
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 445, _y, 0);//ถนน

                    //road,subdistrict,district
                    _y = 600;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 100, _y, 0);//ตำบล/แขวง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 285, _y, 0);//อำเภอ/เขต
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 415, _y, 0);//จังหวัด

                    //provice,zipcode,phone
                    _y = 578;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 130, _y, 0);//รหัสไปรษณีย์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 215, _y, 0);//เบอร์โทรศัพท์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 420, _y, 0);//รหัสบัตรประชาชน

                    //sign father
                    _y = 275;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 400, _y, 0);
                }




                // show mohter profile
                //ข้อมูลมารดา ถ้าเป็นผู้ค้ำประกัน หรือ ผู้ยินยอมคู่สมรส ให้รับรองบุตรด้วย
                if (_warrantBy == "M" || _consentBy == "M")
                {
                    _fullNameTh = Myconfig.CvEmpty(_parentMInfo.FullNameTh, " - ");
                    _age = Myconfig.CvEmpty(_parentMInfo.Age, " - ");
                    _moo = Myconfig.CvEmpty(_parentMInfo.MooPermanent, " - ");
                    _no = Myconfig.CvEmpty(_parentMInfo.NoPermanent, " - ");
                    _soi = Myconfig.CvEmpty(_parentMInfo.SoiPermanent, " - ");
                    _road = Myconfig.CvEmpty(_parentMInfo.RoadPermanent, " - ");
                    _subdistrict = Myconfig.CvEmpty(_parentMInfo.ThSubdistrictName, " - ");
                    _district = Myconfig.CvEmpty(_parentMInfo.ThDistrictName, " - ");
                    _provice = Myconfig.CvEmpty(_parentMInfo.ProvinceNameTH, " - ");
                    _zipcode = Myconfig.CvEmpty(_parentMInfo.ZipCodePermanent, " - ");
                    _phone = Myconfig.CvEmpty(_parentMInfo.PhoneNumberPermanent, " - ");
                    _idCard = Myconfig.CvEmpty(_parentMInfo.IdCard, " - ");
                    _signMother = Myconfig.CvEmpty(_parentMInfo.FullNameTh, " - ");
                }
                else
                {
                    _fullNameTh = " - ";
                    _age = " - ";
                    _moo = " - ";
                    _no = " - ";
                    _soi = " - ";
                    _road = " - ";
                    _subdistrict = " - ";
                    _district = " - ";
                    _provice = " - ";
                    _zipcode = " - ";
                    _phone = " - ";
                    _idCard = " - ";
                    _signMother = " - ";

                }

                if (_ProgramCode == "SIMDB" || _ProgramCode == "RAMDB")
                { // Name-LastName,age
                    if (_statusContract == "OLD")
                    {// acaYear < 2565
                        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        _y = 530;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh + "  (มารดา)", 180, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 505, _y, 0);
                        //No,Moo,Soi
                        _y = 505;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 130, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 200, _y, 0);//หมู่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 285, _y, 0);//ตรอก/ซอย
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 425, _y, 0);//ถนน

                        //road,subdistrict,district
                        _y = 482;
                        _cb.SetFontAndSize(_bf, 15);

                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 105, _y, 0);//ตำบล/แขวง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 282, _y, 0);//อำเภอ/เขต
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 415, _y, 0);//จังหวัด
                                                                                             //provice,zipcode,phone
                        _y = 460;
                        _cb.SetFontAndSize(_bf, 15);

                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 130, _y, 0);//รหัสไปรษณีย์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 220, _y, 0);//เบอร์โทรศัพท์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 420, _y, 0);//รหัสบัตรประชาชน


                        //Name student
                        _y = 437;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 240, _y, 0);//ชื่อนักศึกษา
                        _y = 412;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 350, _y, 0);//ชื่อนักศึกษา
                        _y = 389;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateContract, 289, _y, 0);//วันที่ทำสัญญา
                        _y = 368;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 90, _y, 0);//ชื่อนักศึกษา

                        //sign Mather
                        _y = 250;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 350, _y, 0);
                        _cb.EndText();
                    }
                    else
                    {// acaYear < 2565
                        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        //FullName, Age, NO, MOO
                        _y = 525;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 165, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 336, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 432, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 520, _y, 0);//หมู่

                        //Soi, Road, Subdistrict
                        _y = 502;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 136, _y, 0);//ตรอก/ซอย
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 251, _y, 0);//ถนน
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 424, _y, 0);//ตำบล/แขวง

                        //District, Province, Zipcode
                        _y = 480;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 136, _y, 0);//อำเภอ/เขต
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 300, _y, 0);//จังหวัด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 489, _y, 0);//รหัสไปรษณีย์

                        //Telephone, IdCard
                        _y = 459;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 125, _y, 0);//เบอร์โทรศัพท์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 347, _y, 0);//รหัสบัตรประชาชน

                        //Name student
                        _y = 439;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 267, _y, 0);//ชื่อนักศึกษา

                        _y = 398;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 189, _y, 0);//ชื่อนักศึกษา

                        _y = 354;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 89, _y, 0);//ชื่อนักศึกษา

                        //Relation
                        _y = 418;
                        if (Myconfig.CvEmpty(_parentFInfo.FullNameTh, "") != "" && Myconfig.CvEmpty(_parentMInfo.FullNameTh, "") != "")
                        {//บิดาและมารดา
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "บิดาและมารดา", 178, _y, 0);
                        }
                        else if (Myconfig.CvEmpty(_parentFInfo.FullNameTh, "") != "" && Myconfig.CvEmpty(_parentMInfo.FullNameTh, "") == "")
                        {//บิดา
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "บิดา", 185, _y, 0);
                        }
                        else if (Myconfig.CvEmpty(_parentFInfo.FullNameTh, "") == "" && Myconfig.CvEmpty(_parentMInfo.FullNameTh, "") != "")
                        {//มารดา
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "มารดา", 185, _y, 0);
                        }


                        //Contract Date
                        _y = 374;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayStd, 205, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThStd, 262, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThStd, 357, _y, 0);

                        //Sign Father & Mother
                        _y = 311;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Myconfig.CvEmpty(_parentFInfo.FullNameTh, " "), 199, _y, 0);
                        _y = 248;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Myconfig.CvEmpty(_parentMInfo.FullNameTh, " "), 199, _y, 0);
                        _cb.EndText();
                    }
                }
                else if (_ProgramCode == "DTDSB")
                {// Name-LastName,age
                    if (_statusContract == "OLD")
                    {// acaYear < 2565
                        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        _y = 530;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh + "  (มารดา)", 180, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 505, _y, 0);
                        //No,Moo,Soi
                        _y = 505;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 130, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 200, _y, 0);//หมู่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 285, _y, 0);//ตรอก/ซอย
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 425, _y, 0);//ถนน
                                                                                          //road,subdistrict,district
                        _y = 482;
                        _cb.SetFontAndSize(_bf, 15);

                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 105, _y, 0);//ตำบล/แขวง
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 282, _y, 0);//อำเภอ/เขต
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 415, _y, 0);//จังหวัด
                                                                                             //provice,zipcode,phone
                        _y = 460;
                        _cb.SetFontAndSize(_bf, 15);

                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 130, _y, 0);//รหัสไปรษณีย์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 220, _y, 0);//เบอร์โทรศัพท์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 420, _y, 0);//รหัสบัตรประชาชน


                        //Name student
                        _y = 437;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 240, _y, 0);//ชื่อนักศึกษา
                        _y = 412;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 400, _y, 0);//ชื่อนักศึกษา
                        _y = 389;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateContract, 289, _y, 0);//วันที่ทำสัญญา
                        _y = 368;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 90, _y, 0);//ชื่อนักศึกษา
                                                                                              //sign Mather
                        _y = 250;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 350, _y, 0);
                        _cb.EndText();
                    }
                    else
                    {// acaYear < 2565
                        BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        //FullName, Age, NO, MOO
                        _y = 524;
                        _cb.SetFontAndSize(_bf, 15);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 165, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 336, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 432, _y, 0);//บ้านเลขที่
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 520, _y, 0);//หมู่

                        //Soi, Road, Subdistrict
                        _y = 502;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 136, _y, 0);//ตรอก/ซอย
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 251, _y, 0);//ถนน
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 424, _y, 0);//ตำบล/แขวง

                        //District, Province, Zipcode
                        _y = 480;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 136, _y, 0);//อำเภอ/เขต
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 300, _y, 0);//จังหวัด
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 489, _y, 0);//รหัสไปรษณีย์

                        //Telephone, IdCard
                        _y = 459;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 125, _y, 0);//เบอร์โทรศัพท์
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 347, _y, 0);//รหัสบัตรประชาชน

                        //Name student
                        _y = 439;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 267, _y, 0);//ชื่อนักศึกษา

                        _y = 397;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 215, _y, 0);//ชื่อนักศึกษา

                        _y = 354;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 89, _y, 0);//ชื่อนักศึกษา

                        //Relation
                        _y = 418;
                        if (Myconfig.CvEmpty(_parentFInfo.FullNameTh, "") != "" && Myconfig.CvEmpty(_parentMInfo.FullNameTh, "") != "")
                        {//บิดาและมารดา
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "บิดาและมารดา", 178, _y, 0);
                        }
                        else if (Myconfig.CvEmpty(_parentFInfo.FullNameTh, "") != "" && Myconfig.CvEmpty(_parentMInfo.FullNameTh, "") == "")
                        {//บิดา
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "บิดา", 185, _y, 0);
                        }
                        else if (Myconfig.CvEmpty(_parentFInfo.FullNameTh, "") == "" && Myconfig.CvEmpty(_parentMInfo.FullNameTh, "") != "")
                        {//มารดา
                            _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "มารดา", 185, _y, 0);
                        }


                        //Contract Date
                        _y = 374;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.dayStd, 205, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.monthNameThStd, 262, _y, 0);
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _ctInfo.yearThStd, 357, _y, 0);

                        //Sign Father & Mother
                        _y = 311;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Myconfig.CvEmpty(_parentFInfo.FullNameTh, " "), 199, _y, 0);
                        _y = 248;
                        _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Myconfig.CvEmpty(_parentMInfo.FullNameTh, " "), 199, _y, 0);
                        _cb.EndText();
                    }
                }
                else if (_ProgramCode == "PYPYB")
                { // Name-LastName,age
                    BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    _y = 530;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh + "  (มารดา)", 180, _y, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 505, _y, 0);
                    //No,Moo,Soi
                    _y = 505;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 130, _y, 0);//บ้านเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 200, _y, 0);//หมู่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 285, _y, 0);//ตรอก/ซอย
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 425, _y, 0);//ถนน
                                                                                      //road,subdistrict,district
                    _y = 482;
                    _cb.SetFontAndSize(_bf, 15);

                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 105, _y, 0);//ตำบล/แขวง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 280, _y, 0);//อำเภอ/เขต
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 410, _y, 0);//จังหวัด
                                                                                         //provice,zipcode,phone
                    _y = 460;
                    _cb.SetFontAndSize(_bf, 15);

                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 130, _y, 0);//รหัสไปรษณีย์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 220, _y, 0);//เบอร์โทรศัพท์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 420, _y, 0);//รหัสบัตรประชาชน


                    //Name student
                    _y = 435;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 270, _y, 0);//ชื่อนักศึกษา
                    _y = 415;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 350, _y, 0);//ชื่อนักศึกษา
                    _y = 392;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateContract, 280, _y, 0);//วันที่ทำสัญญา
                    _y = 368;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 90, _y, 0);//ชื่อนักศึกษา
                                                                                          //sign Mather
                    _y = 250;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 400, _y, 0);
                    _cb.EndText();
                }
                else if (_ProgramCode == "RANSB" || _ProgramCode == "NSNSB")
                {// Name-LastName,age
                    BaseFont _bf = BaseFont.CreateFont(_path + "\\fonts\\THSarabun.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    _y = 530;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh + "  (มารดา)", 180, _y, 0);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _age, 500, _y, 0);
                    //No,Moo,Soi
                    _y = 505;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _no, 110, _y, 0);//บ้านเลขที่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _moo, 200, _y, 0);//หมู่
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _soi, 290, _y, 0);//ตรอก/ซอย
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _road, 425, _y, 0);//ถนน
                                                                                      //road,subdistrict,district
                    _y = 485;
                    _cb.SetFontAndSize(_bf, 15);

                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _subdistrict, 105, _y, 0);//ตำบล/แขวง
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _district, 285, _y, 0);//อำเภอ/เขต
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _provice, 415, _y, 0);//จังหวัด
                                                                                         //provice,zipcode,phone
                    _y = 460;
                    _cb.SetFontAndSize(_bf, 15);

                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _zipcode, 130, _y, 0);//รหัสไปรษณีย์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _phone, 215, _y, 0);//เบอร์โทรศัพท์
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _idCard, 420, _y, 0);//รหัสบัตรประชาชน


                    //Name student
                    _y = 435;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 270, _y, 0);//ชื่อนักศึกษา
                    _y = 390;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 180, _y, 0);//ชื่อนักศึกษา
                    _y = 365;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _dateContract, 230, _y, 0);//วันที่ทำสัญญา
                    _y = 344;
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _stdNameTh, 130, _y, 0);//ชื่อนักศึกษา
                                                                                           //sign Mather
                    _y = 229;
                    _cb.SetFontAndSize(_bf, 15);
                    _cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _fullNameTh, 400, _y, 0);
                    _cb.EndText();
                }




                //Close all streams
                _document.Close();
                _writer.Close();
                _reader.Close();

                //update garranteePath  B
                string _garranteePath = Server.MapPath("~/ElectronicContract/" + _acaYear + "/" + _ProgramCode + _programCodeExtra + "/") + _fileName;
                ContractDB.SetGarranteePath(_studentId, _acaYear, _garranteePath);

                FileStream sourceFile = new FileStream((Server.MapPath("~/ElectronicContract/" + _acaYear + "/" + _ProgramCode + _programCodeExtra + "/") + _fileName), FileMode.Open);
                long FileSize;
                FileSize = sourceFile.Length;
                byte[] getContent = new byte[(int)FileSize];
                sourceFile.Read(getContent, 0, (int)sourceFile.Length);
                sourceFile.Close();
                Response.BinaryWrite(getContent);
            }
            else
            {
                //กรณีมี File สัญญาในระบบแล้ว เปิดอ่านเลย

                WebClient client2 = new WebClient();
                Byte[] buffer2 = client2.DownloadData(_garrantee);
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer2.Length.ToString());
                Response.BinaryWrite(buffer2);
                client2.Dispose();
            }

            // end mother profile


            // abs contract




            // ens abs

            // sign father and mother

        }

        #endregion printGarrantee
    }
}