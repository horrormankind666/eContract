using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace eContract {
    public partial class PrintContractAdmin : Page {
        protected void Page_Load(
            object sender,
            EventArgs e
        ) {
            string action = "printWarrant";
            DataSet ds = ContractDB.GetListRePrintWarranty("2561", "PYPYB", "");
            
            if (ds != null ) {
                DataTable dt = ds.Tables[0];

                foreach (DataRow row in dt.Rows) {
                    string studentCode = row["StudentCode"].ToString();
                    string studentID = row["StudentId"].ToString();

                    switch (action) {
                        case "printContract":
                            //Response.Write("printContract"); A
                            PrintContractStd(studentID, studentCode);
                            break;
                        case "printConsent":
                            //Response.Write("printConsent"); B
                            PrintGarrantee(studentID, "STUDENT", studentCode);
                            break;
                        case "printWarrant":
                            //Response.Write("printWarrant"); C
                            PrintWarrant(studentID, "STUDENT", studentCode);
                            break;
                    }
                }
            }
        }

        #region PrintContractStd
        /*
        author      : Anussara Wanwang
        create date : 11-12-2015
        description : พิมพ์สัญญานักศึกษา 
        parameter   : n/a
        */
        public void PrintContractStd(
            string studentID,
            string studentCode
        ) {
            //ในกรณีที่มี file ใน folder แล้วให้เปิดเลย ไม่ต้องสร้าง pdf ใหม่
            ContractInfo ctInfo = new ContractInfo(studentID);
            string contract = Myconfig.CvEmpty(ctInfo.ContractPath, " - ");

            if (contract == " - ") {
                //StringBuilder html = new StringBuilder();
                StudentInfo stdInfo = new StudentInfo(studentCode);
                ParentInfo parentMInfo = new ParentInfo(studentID, "M");
                ParentInfo parentFInfo = new ParentInfo(studentID, "F");
                //CurDate date = new CurDate();
                string acaYear = Myconfig.CvEmpty(stdInfo.AcaYear, " - ");
                SignCEOinfo signInfo = new SignCEOinfo(acaYear);
                //string dateContract = ctInfo.DateLongContractStudent;
                string quotaCode = stdInfo.QuotaCode;
                string signCEO = Myconfig.CvEmpty(signInfo.SignNameCEO, " - ");
                string signCEOPosition = Myconfig.CvEmpty(signInfo.SignCEOPosition, "-");
                string fatherName = parentFInfo.FullNameTH;
                string motherName = parentMInfo.FullNameTH;
                string idCard = Myconfig.CvEmpty(stdInfo.IDCard, " - ");
                //string studentCode = Myconfig.CvEmpty(stdInfo.StudentCode, " - ");
                string stdNameTH = Myconfig.CvEmpty(stdInfo.StdNameTH, " - ");
                string birthDate = Myconfig.CvEmpty(stdInfo.Birthdate, " - ");
                string age = Myconfig.CvEmpty(stdInfo.Age, " - ");
                string moo = Myconfig.CvEmpty(stdInfo.Moo, " - ");
                string no = Myconfig.CvEmpty(stdInfo.No, " - ");
                string soi = Myconfig.CvEmpty(stdInfo.Soi, " - ");
                string road = Myconfig.CvEmpty(stdInfo.Road, " - ");
                string subdistrict = Myconfig.CvEmpty(stdInfo.SubdistrictNameTH, " - ");
                string district = Myconfig.CvEmpty(stdInfo.DistrictNameTH, " - ");
                string province = Myconfig.CvEmpty(stdInfo.ProgramNameTH, " - ");
                string zipcode = Myconfig.CvEmpty(stdInfo.Zipcode, " - ");
                string phone = Myconfig.CvEmpty(stdInfo.PhoneNumberStd, " - ");
                string programCode = Myconfig.CvEmpty(stdInfo.ProgramCode, " - ");
                string statusContract;
                string programCodeExtra = "";
                int checkAcaYear = Convert.ToInt32(acaYear);

                if (checkAcaYear < 2565) {
                    statusContract = "OLD";
                }
                else {
                    statusContract = "NEW";
                }
                
                string path = Server.MapPath("~");
                string fileTmp = "";

                //เรียกใช้ file template
                switch (programCode) {
                    case "SIMDB":
                        switch (statusContract) {
                            case "OLD":
                                fileTmp = (path + "/Template/A_Contract/SIMDB.pdf");
                                break;
                            case "NEW":
                                fileTmp = (path + "/Template/A_Contract/SIMDBNEW.pdf");
                                break;
                        }
                        break;
                    case "RAMDB":
                        switch (statusContract) {
                            case "OLD":
                                fileTmp = (path + "/Template/A_Contract/RAMDB.pdf");
                                break;
                            case "NEW":
                                fileTmp = (path + "/Template/A_Contract/RAMDBNEW.pdf");
                                break;
                        }
                        break;
                    case "PYPYB":
                        fileTmp = (path + "/Template/A_Contract/PYPYB.pdf");
                        break;
                    case "DTDSB":
                        switch (statusContract) {
                            case "OLD":
                                fileTmp = (path + "/Template/A_Contract/DTDSB.pdf");
                                break;
                            case "NEW":
                                fileTmp = (path + "/Template/A_Contract/DTDSBNEW.pdf");
                                break;
                        }
                        break;
                    case "RANSB":
                        fileTmp = (path + "/Template/A_Contract/RANSB.pdf");
                        break;
                    case "NSNSB":
                        //specification nurse program project
                        switch (quotaCode) {
                            //siriraj hospital
                            default: 
                                fileTmp = (path + "/Template/A_Contract/NSNSB.pdf");
                                break;
                            //chula research
                            case "354":
                                fileTmp = (path + "/Template/A_Contract/NSNSB_CL.pdf");
                                programCodeExtra = "_CL";
                                break;
                            //faculty of tropical medicine
                            case "351":
                                fileTmp = (path + "/Template/A_Contract/NSNSB_TM.pdf");
                                programCodeExtra = "_TM";
                                break;
                        }
                        break;
                }

                string fileName = (studentCode + programCode + programCodeExtra + "_A.pdf");
                //string fileDocument = (path + "/ElectronicContract/" + fileName);

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", ("attachment;filename=" + studentCode + "_A.pdf"));
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);

                //open the reader
                PdfReader reader = new PdfReader(fileTmp); //file Template
                //string path = (requestObj.PhysicalApplicationPath + "\\electronicContract\\"); 
                DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath("~/ElectronicContract/" + acaYear + "/" + programCode + programCodeExtra + "/")); //ต้องเป็นตัวแปรโฟลเดอร์ด้วยนะ
                
                if (!dirInfo.Exists) {
                    //Response.Write("OK");
                    dirInfo.Create();
                }

                Document document = new Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F);
                //open the writer
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream((Server.MapPath("~/ElectronicContract/" + acaYear + "/" + programCode + programCodeExtra + "/") + fileName), FileMode.Create));
                //PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
                Response.Charset = string.Empty;
                Response.ClearContent();
                document.Open();
                int y = 0;

                //configure the content
                PdfContentByte cb = writer.DirectContent;
                //select the font properties

                //write the text here
                cb.BeginText();

                //หน้าที่ 1
                PdfImportedPage page1 = writer.GetImportedPage(reader, 1); //หน้า pdf template 1
                cb.AddTemplate(page1, 0, 0);

                if (programCode == "SIMDB") {
                    //acayear < 2565
                    if (statusContract == "OLD") {
                        BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                               
                        //current date
                        y = 670;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayStd, 418, y, 0); //date
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHStd, 460, y, 0); //month
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHStd, 523, y, 0); //year
                                                                                                      
                        //fullname
                        y = 532;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 100, y, 0);
                        //bithdate, age
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, birthDate, 360, y, 0); //วัน/เดือน/ปี เกิด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 523, y, 0); //อายุ
                                                                                         
                        //no, moo, soi
                        y = 508;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 160, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 265, y, 0); //หมู่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 360, y, 0); //ตรอก/ซอย
                                                                                         
                        //road, subdistrict, district
                        y = 484;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 75, y, 0); //ถนน
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 230, y, 0); //ตำบล/แขวง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 405, y, 0); //อำเภอ/เขต
                                                                                              
                        //province, zipcode, phone
                        y = 460;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 95, y, 0); //จังหวัด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 300, y, 0); //รหัสไปรษณีย์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 420, y, 0); //เบอร์โทรศัพท์
                                                                                           
                        //ID card student
                        y = 437;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 180, y, 0); //รหัสบัตรประชาชนนักศึกษา
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fatherName, 340, y, 0); //ชื่อบิดา  

                        y = 415;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, motherName, 100, y, 0); //ชื่อมารดา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 2
                        PdfImportedPage page2 = writer.GetImportedPage(reader, 2); //หน้า pdf template 2
                        cb.AddTemplate(page2, 0, 0);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = writer.GetImportedPage(reader, 3); //หน้า pdf template 2
                        cb.AddTemplate(page3, 0, 0);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //ลายเซ็นนักศึกษา
                        y = 482;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 335, y, 0); //ชื่อนักศึกษา
                                                                                               
                        //อธิการบดี
                        y = 443;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEO, 335, y, 0); //ชื่ออธิการบดี

                        y = 420;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEOPosition, 335, y, 0); //ตำแหน่งอธิการบดี
                    }
                    else {
                        //acayear >= 2565 
                        BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        y = 746;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 439, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //current date
                        y = 651;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayStd, 348, y, 0); //date
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHStd, 406, y, 0); //month
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHStd, 510, y, 0); //year
                                                                                                      
                        //fullname
                        y = 506;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 188, y, 0);
                        
                        //ethnicity, nationality, religion, birthdate
                        y = 488;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "-", 148, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdInfo.NationalityNameTH, 238, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "-", 341, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, birthDate, 427, y, 0); //วัน/เดือน/ปี เกิด
                                                                                               
                        //age, no, moo, soi
                        y = 471;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 112, y, 0); //อายุ
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 239, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 317, y, 0); //หมู่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 397, y, 0); //ตรอก/ซอย
                                                                                         
                        //road, subdistrict
                        y = 452;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 115, y, 0); //ถนน
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 352, y, 0); //ตำบล/แขวง
                                                                                                 
                        //district, province, zipcode
                        y = 435;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 144, y, 0); //อำเภอ/เขต
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 299, y, 0); //จังหวัด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 496, y, 0); //รหัสไปรษณีย์
                                                                                             
                        //phone, ID card student
                        y = 417;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 137, y, 0); //เบอร์โทรศัพท์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 423, y, 0); //รหัสบัตรประชาชนนักศึกษา
                        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fatherName, 400, y, 0); //ชื่อบิดา  

                        //y = 417;
                        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, motherName, 150, y, 0); //ชื่อมารดา

                        //year entry
                        y = 291;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdInfo.AcaYear, 95, y, 0); //ปีการศึกษา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 2
                        PdfImportedPage page2 = writer.GetImportedPage(reader, 2); //หน้า pdf template 2
                        cb.AddTemplate(page2, 0, 0);

                        //contract ID
                        y = 746;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 439, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = writer.GetImportedPage(reader, 3); //หน้า pdf template 2
                        cb.AddTemplate(page3, 0, 0);

                        //contract ID
                        y = 746;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 439, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                        //warranty by
                        y = 688;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);

                        //father
                        if (ctInfo.WarrantBy == "F") {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fatherName, 328, y, 0);
                        }
                        else {
                            //mother
                            if (ctInfo.WarrantBy == "M") {
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, motherName, 328, y, 0);
                            }
                            else {
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "บุคคลอื่น", 328, y, 0);
                            }
                        }

                        //ลายเซ็นนักศึกษา
                        y = 471;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 210, y, 0); //ชื่อนักศึกษา
                                                                                               
                        //อธิการบดี
                        y = 417;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEO, 210, y, 0); //ชื่ออธิการบดี
                                                                                             
                        //y = 459;
                        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEOPosition, 350, y, 0); //ตำแหน่งอธิการบดี
                    }

                    cb.EndText();
                }
                
                if (programCode == "RAMDB") {
                    //acayear < 2565
                    if (statusContract == "OLD") {
                        BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        
                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //current date
                        y = 670;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayStd, 418, y, 0); //date
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHStd, 460, y, 0); //month
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHStd, 523, y, 0); //year
                                                                                                      
                        //fullname
                        y = 532;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 100, y, 0);
                        //bithdate, age
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, birthDate, 360, y, 0); //วัน/เดือน/ปี เกิด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 523, y, 0); //อายุ
                                                                                         
                        //no, moo, soi
                        y = 508;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 160, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 265, y, 0); //หมู่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 360, y, 0); //ตรอก/ซอย
                                                                                         
                        //road, subdistrict, district
                        y = 484;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 75, y, 0); //ถนน
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 230, y, 0); //ตำบล/แขวง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 405, y, 0); //อำเภอ/เขต
                                                                                              
                        //province, zipcode, phone
                        y = 460;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 95, y, 0); //จังหวัด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 300, y, 0); //รหัสไปรษณีย์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 420, y, 0); //เบอร์โทรศัพท์
                                                                                           
                        //ID card student
                        y = 437;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 180, y, 0); //รหัสบัตรประชาชนนักศึกษา
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fatherName, 340, y, 0); //ชื่อบิดา  
                        
                        y = 415;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, motherName, 100, y, 0); //ชื่อมารดา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 2
                        PdfImportedPage page2 = writer.GetImportedPage(reader, 2); //หน้า pdf template 2
                        cb.AddTemplate(page2, 0, 0);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                        
                        cb.EndText();
                        
                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = writer.GetImportedPage(reader, 3); //หน้า pdf template 2
                        cb.AddTemplate(page3, 0, 0);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //ลายเซ็นนักศึกษา
                        y = 279;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 335, y, 0); //ชื่อนักศึกษา
                                                                                               
                        //อธิการบดี
                        y = 241;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEO, 335, y, 0); //ชื่ออธิการบดี
                        
                        y = 218;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEOPosition, 335, y, 0); //ตำแหน่งอธิการบดี
                    }
                    else {
                        //acayear >= 2565 
                        BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        
                        y = 746;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 439, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //current date
                        y = 651;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayStd, 348, y, 0); //date
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHStd, 406, y, 0); //month
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHStd, 510, y, 0); //year
                                                                                                      
                        //fullname
                        y = 506;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 188, y, 0);

                        //ethnicity, nationality, religion, birthdate
                        y = 488;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "-", 148, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdInfo.NationalityNameTH, 238, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "-", 341, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, birthDate, 427, y, 0); //วัน/เดือน/ปี เกิด
                                                                                               
                        //age, no, moo, soi
                        y = 471;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 112, y, 0); //อายุ
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 239, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 317, y, 0); //หมู่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 397, y, 0); //ตรอก/ซอย
                                                                                         
                        //road, subdistrict
                        y = 452;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 115, y, 0); //ถนน
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 352, y, 0); //ตำบล/แขวง
                                                                                                 
                        //district, province, zipcode
                        y = 435;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 144, y, 0); //อำเภอ/เขต
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 299, y, 0); //จังหวัด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 496, y, 0); //รหัสไปรษณีย์
                                                                                             
                        //phone, ID card student
                        y = 417;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 137, y, 0); //เบอร์โทรศัพท์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 423, y, 0); //รหัสบัตรประชาชนนักศึกษา
                        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fatherName, 400, y, 0); //ชื่อบิดา  

                        //y = 417;
                        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, motherName, 150, y, 0); //ชื่อมารดา

                        //year entry
                        y = 291;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdInfo.AcaYear, 95, y, 0); //ปีการศึกษา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 2
                        PdfImportedPage page2 = writer.GetImportedPage(reader, 2); //หน้า pdf template 2
                        cb.AddTemplate(page2, 0, 0);

                        //contract ID
                        y = 746;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 439, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = writer.GetImportedPage(reader, 3); //หน้า pdf template 2
                        cb.AddTemplate(page3, 0, 0);

                        //contract ID
                        y = 746;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 439, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                        //warranty by
                        y = 688;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);

                        //father
                        if (ctInfo.WarrantBy == "F") {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fatherName, 328, y, 0);
                        }
                        else {
                            //mother
                            if (ctInfo.WarrantBy == "M") {
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, motherName, 328, y, 0);
                            }
                            else {
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "บุคคลอื่น", 328, y, 0);
                            }
                        }

                        //ลายเซ็นนักศึกษา
                        y = 471;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 210, y, 0); //ชื่อนักศึกษา
                                                                                               
                        //อธิการบดี
                        y = 417;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEO, 210, y, 0); //ชื่ออธิการบดี
                                                                                             
                        //y = 459;
                        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEOPosition, 350, y, 0); //ตำแหน่งอธิการบดี
                    }

                    cb.EndText();
                }
                
                if (programCode == "PYPYB") {
                    BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                    //contract ID
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                            
                    //current date
                    y = 673;
                    cb.SetFontAndSize(bf, 15);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayStd, 400, y, 0); //date
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHStd, 450, y, 0); //month
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHStd, 515, y, 0); //year
                                                                                                  
                    //fullname
                    y = 533;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 100, y, 0);
                    //bithdate, age
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, birthDate, 360, y, 0); //วัน/เดือน/ปี เกิด
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 515, y, 0); //อายุ
                                                                                     
                    //no, moo, soi
                    y = 510;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 160, y, 0); //บ้านเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 265, y, 0); //หมู่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 360, y, 0); //ตรอก/ซอย
                                                                                    
                    //road, subdistrict, district
                    y = 486;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 75, y, 0); //ถนน
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 230, y, 0); //ตำบล/แขวง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 405, y, 0); //อำเภอ/เขต
                                                                                          
                    //province, zipcode, phone
                    y = 464;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 95, y, 0); //จังหวัด
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 300, y, 0); //รหัสไปรษณีย์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 420, y, 0); //เบอร์โทรศัพท์
                                                                                       
                    //ID card student
                    y = 440;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 180, y, 0); //รหัสบัตรประชาชนนักศึกษา
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fatherName, 340, y, 0); //ชื่อบิดา  

                    y = 417;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, motherName, 100, y, 0); //ชื่อมารดา

                    cb.EndText();

                    //ขึ้นหน้าใหม่
                    document.NewPage();
                    cb.BeginText();

                    //หน้าที่ 2
                    PdfImportedPage page2 = writer.GetImportedPage(reader, 2); //หน้า pdf template 2
                    cb.AddTemplate(page2, 0, 0);

                    //contract ID
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                    cb.EndText();

                    //ขึ้นหน้าใหม่
                    document.NewPage();
                    cb.BeginText();

                    //หน้าที่ 3
                    PdfImportedPage page3 = writer.GetImportedPage(reader, 3); //หน้า pdf template 2
                    cb.AddTemplate(page3, 0, 0);

                    //contract ID
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                            
                    //ลายเซ็นนักศึกษา
                    y = 445;
                    cb.SetFontAndSize(bf, 15);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 335, y, 0); //ชื่อนักศึกษา
                                                                                           
                    //อธิการบดี
                    y = 405;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEO, 335, y, 0); //ชื่ออธิการบดี
                    
                    y = 382;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEOPosition, 335, y, 0); //ตำแหน่งอธิการบดี

                    cb.EndText();
                }

                if (programCode == "DTDSB") {
                    //acaYear < 2565
                    if (statusContract == "OLD") {
                        BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //current date
                        y = 672;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayStd, 418, y, 0); //date
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHStd, 460, y, 0); //month
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHStd, 523, y, 0); //year
                                                                                                      
                        //fullname
                        y = 534;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 150, y, 0);

                        //bithdate, age
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, birthDate, 360, y, 0); //วัน/เดือน/ปี เกิด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 523, y, 0); //อายุ
                                                                                         
                        //no, moo, soi
                        y = 510;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 180, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 280, y, 0); //หมู่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 400, y, 0); //ตรอก/ซอย
                                                                                         
                        //road, subdistrict, district
                        y = 486;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 75, y, 0); //ถนน
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 230, y, 0); //ตำบล/แขวง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 405, y, 0); //อำเภอ/เขต
                                                                                              
                        //province, zipcode, phone
                        y = 465;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 120, y, 0); //จังหวัด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 280, y, 0); //รหัสไปรษณีย์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 410, y, 0); //เบอร์โทรศัพท์
                                                                                           
                        //ID card student
                        y = 440;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 180, y, 0); //รหัสบัตรประชาชนนักศึกษา
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fatherName, 400, y, 0); //ชื่อบิดา  
                        
                        y = 417;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, motherName, 150, y, 0); //ชื่อมารดา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();
                        
                        //หน้าที่ 2
                        PdfImportedPage page2 = writer.GetImportedPage(reader, 2); //หน้า pdf template 2
                        cb.AddTemplate(page2, 0, 0);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                        
                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = writer.GetImportedPage(reader, 3); //หน้า pdf template 2
                        cb.AddTemplate(page3, 0, 0);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //ลายเซ็นนักศึกษา
                        y = 520;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 350, y, 0); //ชื่อนักศึกษา
                                                                                               
                        //อธิการบดี
                        y = 482;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEO, 350, y, 0); //ชื่ออธิการบดี
                        
                        y = 459;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEOPosition, 350, y, 0); //ตำแหน่งอธิการบดี
                    }
                    else {
                        //acayear >= 2565 
                        BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        
                        y = 746;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 439, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //current date
                        y = 651;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayStd, 348, y, 0); //date
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHStd, 406, y, 0); //month
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHStd, 510, y, 0); //year
                                                                                                      
                        //fullname
                        y = 506;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 188, y, 0);

                        //ethnicity, nationality, religion, birthdate
                        y = 488;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "-", 148, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdInfo.NationalityNameTH, 238, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "-", 341, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, birthDate, 427, y, 0); //วัน/เดือน/ปี เกิด
                                                                                               
                        //age, no, moo, soi
                        y = 471;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 112, y, 0); //อายุ
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 239, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 317, y, 0); //หมู่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 397, y, 0); //ตรอก/ซอย
                                                                                         
                        //road, subdistrict
                        y = 452;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 115, y, 0); //ถนน
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 352, y, 0); //ตำบล/แขวง
                                                                                                 
                        //district, province, zipcode
                        y = 435;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 144, y, 0); //อำเภอ/เขต
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 299, y, 0); //จังหวัด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 496, y, 0); //รหัสไปรษณีย์
                                                                                             
                        //phone, ID card student
                        y = 417;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 137, y, 0); //เบอร์โทรศัพท์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 423, y, 0); //รหัสบัตรประชาชนนักศึกษา
                        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fatherName, 400, y, 0); //ชื่อบิดา  

                        //y = 417;
                        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, motherName, 150, y, 0); //ชื่อมารดา

                        //year entry
                        y = 291;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdInfo.AcaYear, 95, y, 0); //ปีการศึกษา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 2
                        PdfImportedPage page2 = writer.GetImportedPage(reader, 2); //หน้า pdf template 2
                        cb.AddTemplate(page2, 0, 0);

                        //contract ID
                        y = 746;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 439, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = writer.GetImportedPage(reader, 3); //หน้า pdf template 2
                        cb.AddTemplate(page3, 0, 0);

                        //contract ID
                        y = 746;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 439, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                        //warranty by
                        y = 688;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);

                        //father
                        if (ctInfo.WarrantBy == "F") {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fatherName, 328, y, 0);
                        }
                        else {
                            //mother
                            if (ctInfo.WarrantBy == "M") {                                
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, motherName, 328, y, 0);
                            }
                            else {
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "บุคคลอื่น", 328, y, 0);
                            }
                        }

                        //ลายเซ็นนักศึกษา
                        y = 471;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 210, y, 0); //ชื่อนักศึกษา
                                                                                               
                        //อธิการบดี
                        y = 417;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEO, 210, y, 0); //ชื่ออธิการบดี

                        //y = 459;
                        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEOPosition, 350, y, 0); //ตำแหน่งอธิการบดี
                    }

                    cb.EndText();
                }
                
                if (programCode == "RANSB") {
                    BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                    //contract ID
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                            
                    //current date
                    y = 670;
                    cb.SetFontAndSize(bf, 15);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayStd, 418, y, 0); //date
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHStd, 460, y, 0); //month
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHStd, 523, y, 0); //year
                                                                                                  
                    //fullname
                    y = 599;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 100, y, 0);
                    
                    //bithdate, age
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, birthDate, 360, y, 0); //วัน/เดือน/ปี เกิด
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 523, y, 0); //อายุ
                                                                                     
                    //no, moo, soi
                    y = 578;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 160, y, 0); //บ้านเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 270, y, 0); //หมู่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 360, y, 0); //ตรอก/ซอย
                                                                                     
                    //road, subdistrict, district
                    y = 555;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 75, y, 0); //ถนน
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 230, y, 0); //ตำบล/แขวง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 405, y, 0); //อำเภอ/เขต
                                                                                          
                    //province, zipcode, phone
                    y = 529;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 90, y, 0); //จังหวัด
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 290, y, 0); //รหัสไปรษณีย์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 420, y, 0); //เบอร์โทรศัพท์
                                                                                       
                    //ID card student
                    y = 508;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 180, y, 0); //รหัสบัตรประชาชนนักศึกษา
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fatherName, 400, y, 0); //ชื่อบิดา  
                    
                    y = 485;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, motherName, 150, y, 0); //ชื่อมารดา

                    cb.EndText();

                    //ขึ้นหน้าใหม่
                    document.NewPage();
                    cb.BeginText();

                    //หน้าที่ 2
                    PdfImportedPage page2 = writer.GetImportedPage(reader, 2); //หน้า pdf template 2
                    cb.AddTemplate(page2, 0, 0);

                    //contract ID
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                    cb.EndText();

                    //ขึ้นหน้าใหม่
                    document.NewPage();
                    cb.BeginText();

                    //หน้าที่ 3
                    PdfImportedPage page3 = writer.GetImportedPage(reader, 3); //หน้า pdf template 2
                    cb.AddTemplate(page3, 0, 0);

                    //contract ID
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                            
                    //ลายเซ็นนักศึกษา
                    y = 275;
                    cb.SetFontAndSize(bf, 15);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 350, y, 0); //ชื่อนักศึกษา
                                                                                           
                    //อธิการบดี
                    y = 235;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEO, 350, y, 0); //ชื่ออธิการบดี
                    
                    y = 212;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEOPosition, 350, y, 0); //ตำแหน่งอธิการบดี

                    cb.EndText();
                }

                if (programCode == "NSNSB") {
                    BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    //specification nurse program project
                    //siriraj hospital
                    if (quotaCode == "")  {                           
                        //contract ID 
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //current date
                        y = 670;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayStd, 418, y, 0); //date
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHStd, 460, y, 0); //month
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHStd, 526, y, 0); //year
                                                                                                      
                        //fullname
                        y = 600;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 100, y, 0);
                        //bithdate, age
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, birthDate, 360, y, 0); //วัน/เดือน/ปี เกิด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 520, y, 0); //อายุ
                                                                                         
                        //no, moo, soi
                        y = 577;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 160, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 260, y, 0); //หมู่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 360, y, 0); //ตรอก/ซอย
                                                                                         
                        //road, subdistrict, district
                        y = 554;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 80, y, 0); //ถนน
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 230, y, 0); //ตำบล/แขวง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 405, y, 0); //อำเภอ/เขต
                                                                                              
                        //province, zipcode, phone
                        y = 529;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 80, y, 0); //จังหวัด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 280, y, 0); //รหัสไปรษณีย์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 415, y, 0); //เบอร์โทรศัพท์
                                                                                           
                        //ID card student
                        y = 506;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 180, y, 0); //รหัสบัตรประชาชนนักศึกษา
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fatherName, 340, y, 0); //ชื่อบิดา  
                        
                        y = 482;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, motherName, 100, y, 0); //ชื่อมารดา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 2
                        PdfImportedPage page2 = writer.GetImportedPage(reader, 2); //หน้า pdf template 2
                        cb.AddTemplate(page2, 0, 0);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = writer.GetImportedPage(reader, 3); //หน้า pdf template 2
                        cb.AddTemplate(page3, 0, 0);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //ลายเซ็นนักศึกษา
                        y = 325;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 350, y, 0); //ชื่อนักศึกษา
                                                                                               
                        //อธิการบดี
                        y = 285;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEO, 350, y, 0); //ชื่ออธิการบดี
                        
                        y = 262;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEOPosition, 350, y, 0); //ตำแหน่งอธิการบดี

                        cb.EndText();
                    }

                    //chula research
                    if (quotaCode == "354") {
                        //contract ID 
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //current date
                        y = 670;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayStd, 418, y, 0); //date
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHStd, 460, y, 0); //month
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHStd, 526, y, 0); //year
                                                                                                      
                        //fullname
                        y = 577;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 100, y, 0);
                        //bithdate, age
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, birthDate, 360, y, 0); //วัน/เดือน/ปี เกิด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 520, y, 0); //อายุ
                                                                                         
                        //no, moo, soi
                        y = 554;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 160, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 260, y, 0); //หมู่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 360, y, 0); //ตรอก/ซอย
                                                                                         
                        //road, subdistrict, district
                        y = 529;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 80, y, 0); //ถนน
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 230, y, 0); //ตำบล/แขวง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 405, y, 0); //อำเภอ/เขต
                                                                                              
                        //province, zipcode, phone
                        y = 506;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 80, y, 0); //จังหวัด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 280, y, 0); //รหัสไปรษณีย์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 415, y, 0); //เบอร์โทรศัพท์
                                                                                          
                        //ID card student
                        y = 482;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 180, y, 0); //รหัสบัตรประชาชนนักศึกษา
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fatherName, 340, y, 0); //ชื่อบิดา  
                        
                        y = 462;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, motherName, 100, y, 0); //ชื่อมารดา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 2
                        PdfImportedPage page2 = writer.GetImportedPage(reader, 2); //หน้า pdf template 2
                        cb.AddTemplate(page2, 0, 0);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                        
                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = writer.GetImportedPage(reader, 3); //หน้า pdf template 2
                        cb.AddTemplate(page3, 0, 0);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //ลายเซ็นนักศึกษา
                        y = 325;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 350, y, 0); //ชื่อนักศึกษา
                                                                                               
                        //อธิการบดี
                        y = 285;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEO, 350, y, 0); //ชื่ออธิการบดี
                        
                        y = 262;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEOPosition, 350, y, 0); //ตำแหน่งอธิการบดี

                        cb.EndText();
                    }

                    //faculty of tropical medicine
                    if (quotaCode == "351") {
                        //contract ID 
                        /*
                        cb.SetFontAndSize(_bf, 10);

                        //แกน Y
                        for (int i = 0; i <= 800; i += 10) {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                        }

                        //แกน X
                        for (int i = 600; i >= 0; i -= 10) {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                        }
                        */

                        //contract ID 
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //current date
                        y = 670;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayStd, 418, y, 0); //date
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHStd, 460, y, 0); //month
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHStd, 526, y, 0); //year
                                                                                                      
                        //fullname
                        y = 577;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 100, y, 0);
                        //bithDate, age
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, birthDate, 360, y, 0); //วัน/เดือน/ปี เกิด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 520, y, 0); //อายุ

                        //no, moo, soi
                        y = 554;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 160, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 260, y, 0); //หมู่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 360, y, 0); //ตรอก/ซอย
                                                                                         
                        //road, subdistrict, district
                        y = 529;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 80, y, 0); //ถนน
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 230, y, 0); //ตำบล/แขวง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 405, y, 0); //อำเภอ/เขต
                                                                                              
                        //provice, zipcode, phone
                        y = 506;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 90, y, 0); //จังหวัด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 280, y, 0); //รหัสไปรษณีย์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 415, y, 0); //เบอร์โทรศัพท์
                                                                                           
                        //ID card student
                        y = 483;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 180, y, 0); //รหัสบัตรประชาชนนักศึกษา
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fatherName, 340, y, 0); //ชื่อบิดา  
                        
                        y = 462;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, motherName, 100, y, 0); //ชื่อมารดา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 2
                        PdfImportedPage page2 = writer.GetImportedPage(reader, 2); //หน้า pdf template 2
                        cb.AddTemplate(page2, 0, 0);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                        cb.EndText();

                        //ขึ้นหน้าใหม่
                        document.NewPage();
                        cb.BeginText();

                        //หน้าที่ 3
                        PdfImportedPage page3 = writer.GetImportedPage(reader, 3); //หน้า pdf template 2
                        cb.AddTemplate(page3, 0, 0);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_A"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //ลายเซ็นนักศึกษา
                        y = 347;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 350, y, 0); //ชื่อนักศึกษา
                                                                                               
                        //อธิการบดี
                        y = 307;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEO, 350, y, 0); //ชื่ออธิการบดี
                        
                        y = 284;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, signCEOPosition, 350, y, 0); //ตำแหน่งอธิการบดี

                        cb.EndText();
                    }
                }

                document.Close();
                writer.Close();
                reader.Close();

                //update contract path
                string contractPath = (Server.MapPath("~/ElectronicContract/" + acaYear + "/" + programCode + programCodeExtra + "/") + fileName);
                ContractDB.SetContractPath(studentID, acaYear, contractPath);
                FileStream sourceFile = new FileStream((Server.MapPath("~/ElectronicContract/" + acaYear + "/" + programCode + programCodeExtra + "/") + fileName), FileMode.Open);
                long FileSize;
                FileSize = sourceFile.Length;
                byte[] getContent = new byte[(int)FileSize];

                sourceFile.Read(getContent, 0, (int)sourceFile.Length);
                sourceFile.Close();
                Response.BinaryWrite(getContent);
            }
            else {
                //กรณีมี file สัญญาในระบบแล้ว เปิดอ่านเลย
                WebClient client1 = new WebClient();
                Byte[] buffer1 = client1.DownloadData(contract);

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer1.Length.ToString());
                Response.BinaryWrite(buffer1);
                client1.Dispose();
            }
        }

        #endregion PrintContractStd

        #region PrintWarrant
        /*
        author      : Anussara Wanwang
        create date : 11-12-2015
        update Date : 20-08-2017
        update Date : 07-08-2020
        description : สัญญาค้ำประกัน และหนังสือให้ความยินยอมของคู่สมรสผู้ค้ำประกัน C
        parameter   : n/a
        */
        public void PrintWarrant(
            string studentID,
            string parentType,
            string studentCode
        ) {
            //ในกรณีที่มี file ใน folder แล้วให้เปิดเลย ไม่ต้องสร้าง pdf ใหม่
            ContractInfo ctInfo = new ContractInfo(studentID);
            //string warran = Myconfig.CvEmpty(ctInfo.WarranPath, " - ");

            //if (warran == " - ") {
                //StringBuilder html = new StringBuilder();
                StudentInfo stdInfo = new StudentInfo(studentCode);
                ParentInfo parentInfo = new ParentInfo(studentID, parentType);
                ParentInfo parentMInfo = new ParentInfo(studentID, "M");
                ParentInfo parentFInfo = new ParentInfo(studentID, "F");
                CurDate date = new CurDate();
                string programCodeExtra;
                string acaYear = Myconfig.CvEmpty(stdInfo.AcaYear, " - ");
                string quotaCode = stdInfo.QuotaCode;
                //string studentCode = Myconfig.CvEmpty(stdInfo.StudentCode, " - ");
                string stdNameTH = Myconfig.CvEmpty(stdInfo.StdNameTH, " - ");
                //string programNameTH = Myconfig.CvEmpty(stdInfo.ProgramNameTH, " - ");
                string programCode = Myconfig.CvEmpty(stdInfo.ProgramCode, " - ");
                string studentProgram = Myconfig.CvEmpty(stdInfo.StrStudentProgram, " - ");
                string idCard;
                string fullNameTH;
                string fullNameMarTH;
                string age;
                string moo;
                string no;
                string soi;
                string road;
                string subdistrict;
                string occupationTH;
                string position;
                string agencyNameTH;
                string district;
                string province;
                string zipcode;
                string phone;
                string mobile;
                string assure1 = "";
                string assure2 = "";
                string assure3 = "";
                string dateContract = ctInfo.DateLongContractStudent;
                string warrantBy = ctInfo.WarrantBy;
                string consentBy = ctInfo.ConsentBy;
                string aliveF = ctInfo.IsAliveFather; //สถานะพ่อ 1 = มีชีวิต, 2 = เสียชีวิต
                string aliveM = ctInfo.IsAliveMother; //สถานะแม่ 1 = มีชีวิต, 2 = เสียชีวิต
                string marriage = ctInfo.IsMarriage; //1 = สมรส, 2 = สมรส(ไม่ได้จดทะเบียน), 3 = บิดามารดาหย่าร้าง
                string relationship = ctInfo.Relationship; //เกียวพันกับนักศึกษาโดยเป็น บิดา หรือ มารดา หรือ บุคคลอื่น

                //ข้อมูลผู้ค้ำประกัน
                //มารดาเป็นผู้ค้ำ
                if (warrantBy == "M") {
                    if (marriage == "1" &&
                        aliveF == "1") {
                        fullNameMarTH = Myconfig.CvEmpty(parentFInfo.FullNameTH, " - ");
                    }
                    else {
                        fullNameMarTH = " - ";
                    }

                    fullNameTH = Myconfig.CvEmpty(parentMInfo.FullNameTH, " - ");
                    age = Myconfig.CvEmpty(parentMInfo.Age, " - ");
                    moo = Myconfig.CvEmpty(parentMInfo.MooPermanent, " - ");
                    no = Myconfig.CvEmpty(parentMInfo.NoPermanent, " - ");
                    soi = Myconfig.CvEmpty(parentMInfo.SoiPermanent, " - ");
                    road = Myconfig.CvEmpty(parentMInfo.RoadPermanent, " - ");
                    subdistrict = Myconfig.CvEmpty(parentMInfo.SubdistrictNameTH, " - ");
                    district = Myconfig.CvEmpty(parentMInfo.DistrictNameTH, " - ");
                    province = Myconfig.CvEmpty(parentMInfo.ProvinceNameTH, " - ");
                    zipcode = Myconfig.CvEmpty(parentMInfo.ZipcodePermanent, " - ");
                    phone = Myconfig.CvEmpty(parentMInfo.PhoneNumberPermanent, " - ");
                    mobile = Myconfig.CvEmpty(parentMInfo.MobileNumberPermanent, " - ");
                    idCard = Myconfig.CvEmpty(parentMInfo.IDCard, " - ");
                    occupationTH = Myconfig.CvEmpty(parentMInfo.OccupationTH, " - ");
                    position = Myconfig.CvEmpty(parentMInfo.Position, " - ");
                    agencyNameTH = Myconfig.CvEmpty(parentMInfo.AgencyNameTH, " - ");
                }
                else {
                    //บิดาเป็นผู้ค้ำ
                    if (warrantBy == "F") {
                        if (marriage == "1" &&
                            aliveM == "1") {
                            fullNameMarTH = Myconfig.CvEmpty(parentMInfo.FullNameTH, " - ");
                        }
                        else {
                            fullNameMarTH = " - ";
                        }

                        fullNameTH = Myconfig.CvEmpty(parentFInfo.FullNameTH, " - ");
                        age = Myconfig.CvEmpty(parentFInfo.Age, " - ");
                        moo = Myconfig.CvEmpty(parentFInfo.MooPermanent, " - ");
                        no = Myconfig.CvEmpty(parentFInfo.NoPermanent, " - ");
                        soi = Myconfig.CvEmpty(parentFInfo.SoiPermanent, " - ");
                        road = Myconfig.CvEmpty(parentFInfo.RoadPermanent, " - ");
                        subdistrict = Myconfig.CvEmpty(parentFInfo.SubdistrictNameTH, " - ");
                        district = Myconfig.CvEmpty(parentFInfo.DistrictNameTH, " - ");
                        province = Myconfig.CvEmpty(parentFInfo.ProvinceNameTH, " - ");
                        zipcode = Myconfig.CvEmpty(parentFInfo.ZipcodePermanent, " - ");
                        phone = Myconfig.CvEmpty(parentFInfo.PhoneNumberPermanent, " - ");
                        mobile = Myconfig.CvEmpty(parentFInfo.MobileNumberPermanent, " - ");
                        idCard = Myconfig.CvEmpty(parentFInfo.IDCard, " - ");
                        occupationTH = Myconfig.CvEmpty(parentFInfo.OccupationTH, " - ");
                        position = Myconfig.CvEmpty(parentFInfo.Position, " - ");
                        agencyNameTH = Myconfig.CvEmpty(parentFInfo.AgencyNameTH, " - ");

                    }
                    else {
                        fullNameTH = " - ";
                        fullNameMarTH = " - "; //ชื่อคู่สมรส
                        age = " - ";
                        moo = " - ";
                        no = " - ";
                        soi = " - ";
                        road = " - ";
                        subdistrict = " - ";
                        district = " - ";
                        province = " - ";
                        zipcode = " - ";
                        phone = " - ";
                        mobile = " - ";
                        idCard = " - ";
                        occupationTH = " - ";
                        position = " - ";
                        agencyNameTH = " - ";
                    }
                }

                string path = Server.MapPath("~");
                string fileTmp = "";

                //เรียกใช้ file template
                switch (programCode) {
                    case "SIMDB":
                        fileTmp = (path + "/Template/C_Warrant/WarrantSIMDB_NEW.pdf");
                        break;
                    case "RAMDB":
                        fileTmp = (path + "/Template/C_Warrant/WarrantRAMDB_NEW.pdf");
                        break;
                    case "PYPYB":
                        fileTmp = (path + "/Template/C_Warrant/WarrantPYPYB_NEW.pdf");
                        break;
                    case "DTDSB":
                        fileTmp = (path + "/Template/C_Warrant/WarrantDTDSB_NEW.pdf");
                        break;
                    case "RANSB":
                        fileTmp = (path + "/Template/C_Warrant/WarrantRANSB_NEW.pdf");
                        break;
                    case "NSNSB":
                        fileTmp = (path + "/Template/C_Warrant/WarrantNSNSB_NEW.pdf");
                        break;
                }

                //folder extra
                switch (quotaCode) {
                    //siriraj hospital
                    default:
                        programCodeExtra = "";
                        break;
                    case "354":
                        programCodeExtra = "_CL";
                        break;
                    case "351":
                        programCodeExtra = "_TM";
                        break;
                }

                string fileName = (studentCode + programCode + programCodeExtra + "_C.pdf");
                //string fileDocument = (path + "/ElectronicContract/" + fileName);

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", ("attachment;filename=" + studentCode + "_C.pdf"));
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);

                //open the reader
                PdfReader reader = new PdfReader(fileTmp); //file template
                //string path = (requestObj.PhysicalApplicationPath + "\\electronicContract\\"); 
                DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath("~/ElectronicContract/" + acaYear + "/" + programCode + programCodeExtra + "/")); //ต้องเป็นตัวแปรโฟลเดอร์ด้วยนะ

                if (!dirInfo.Exists) {
                    //Response.Write("OK");
                    dirInfo.Create();
                }

                Document document = new Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F);
                //open the writer
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream((Server.MapPath("~/ElectronicContract/" + acaYear + "/" + programCode + programCodeExtra + "/") + fileName), FileMode.Create));
                //PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
                Response.Charset = String.Empty;
                Response.ClearContent();
                document.Open();
                int y = 0;

                //configure the content
                PdfContentByte cb = writer.DirectContent;
                //select the font properties
                BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                //write the text here
                cb.BeginText();

                //หน้าที่ 1
                PdfImportedPage page1 = writer.GetImportedPage(reader, 1); //หน้า pdf template 1
                cb.AddTemplate(page1, 0, 0);

                if (programCode == "SIMDB") {
                    //contract ID 
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);

                    /*
                    //แกน Y
                    for (int i = 0; i <= 800; i += 10) {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                    }

                    //แกน X
                    for (int i = 600; i >= 0; i -= 10) {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                    }
                    */

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                    //current date
                    y = 670;
                    cb.SetFontAndSize(bf, 15);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayP1, 390, y, 0); //date
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHP1, 435, y, 0); //month
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHP1, 515, y, 0); //year

                    //fullname, age parent
                    y = 650;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 180, y, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 490, y, 0);

                    //occupation, position, agency
                    y = 625;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, occupationTH, 80, y, 0); //อาชีพ
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, occupationTH, 80, y, 0); //อาชีพ
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, position, 250, y, 0); //ตำแหน่ง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, agencyNameTH, 380, y, 0); //สังกัด

                    //no, moo, soi
                    y = 600;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 110, y, 0); //บ้านเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 190, y, 0); //หมู่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 270, y, 0); //ตรอก/ซอย
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 410, y, 0); //ถนน

                    //subdistrict, district, province
                    y = 578;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 110, y, 0); //ตำบล/แขวง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 265, y, 0); //อำเภอ/เขต
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 400, y, 0); //จังหวัด

                    //zipcode, phone, mobile
                    y = 555;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 110, y, 0); //รหัสไปรษณีย์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 250, y, 0); //เบอร์โทรศัพท์บ้าน
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, mobile, 430, y, 0); //เบอร์โทรศัพท์มือถือ

                    //marrie name
                    y = 530;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 180, y, 0); //รหัสบัตรประชาชน
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameMarTH, 380, y, 0); //ชื่อคู่สมรส

                    //name student
                    y = 460;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 100, y, 0); //ชื่อนักศึกษา

                    //date contract
                    y = 438;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateContract, 150, y, 0); //วันที่ทำสัญญา
                }
                
                if (programCode == "RAMDB") {
                    //contract ID 
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);

                    /*
                    //แกน Y
                    for (int i = 0; i <= 800; i += 10) {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                    }
                    
                    //แกน X
                    for (int i = 600; i >= 0; i -= 10) {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                    }
                    */

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                    //current date
                    y = 670;
                    cb.SetFontAndSize(bf, 15);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayP1, 390, y, 0); //date
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHP1, 435, y, 0); //month
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHP1, 515, y, 0); //year

                    //fullname, age parent
                    y = 650;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 180, y, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 490, y, 0);

                    //occupation, position, agency
                    y = 625;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, occupationTH, 80, y, 0); //อาชีพ
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, position, 250, y, 0); //ตำแหน่ง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, agencyNameTH, 380, y, 0); //สังกัด

                    //no, moo, soi
                    y = 600;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 110, y, 0); //บ้านเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 190, y, 0); //หมู่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 270, y, 0); //ตรอก/ซอย
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 410, y, 0); //ถนน

                    //subdistrict, district, province
                    y = 578;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 110, y, 0); //ตำบล/แขวง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 265, y, 0); //อำเภอ/เขต
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 400, y, 0); //จังหวัด

                    //zipcode, phone, mobile
                    y = 555;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 110, y, 0); //รหัสไปรษณีย์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 250, y, 0); //เบอร์โทรศัพท์บ้าน
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, mobile, 430, y, 0); //เบอร์โทรศัพท์มือถือ

                    //marrie name
                    y = 530;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 180, y, 0); //รหัสบัตรประชาชน
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameMarTH, 380, y, 0); //ชื่อคู่สมรส

                    //name student
                    y = 460;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 100, y, 0); //ชื่อนักศึกษา

                    //date contract
                    y = 438;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateContract, 150, y, 0); //วันที่ทำสัญญา
                }
                
                if (programCode == "PYPYB") {
                    //contract ID 
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);

                    /*
                    //แกน Y
                    for (int i = 0; i <= 800; i += 10) {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                    }

                    //แกน X
                    for (int i = 600; i >= 0; i -= 10) {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                    }
                    */

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                    //current date
                    y = 670;
                    cb.SetFontAndSize(bf, 15);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayP1, 390, y, 0); //date
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHP1, 435, y, 0); //month
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHP1, 515, y, 0); //year

                    //fullname, age parent
                    y = 650;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 180, y, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 490, y, 0);

                    //occupation, position, agency
                    y = 625;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, occupationTH, 80, y, 0); //อาชีพ
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, position, 250, y, 0); //ตำแหน่ง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, agencyNameTH, 380, y, 0); //สังกัด

                    //no, moo, soi
                    y = 600;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 110, y, 0); //บ้านเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 190, y, 0); //หมู่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 270, y, 0); //ตรอก/ซอย
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 410, y, 0); //ถนน

                    //subdistrict, district, province
                    y = 578;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 110, y, 0); //ตำบล/แขวง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 265, y, 0); //อำเภอ/เขต
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 400, y, 0); //จังหวัด

                    //zipcode, phone, mobile
                    y = 555;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 110, y, 0); //รหัสไปรษณีย์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 250, y, 0); //เบอร์โทรศัพท์บ้าน
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, mobile, 430, y, 0); //เบอร์โทรศัพท์มือถือ

                    //marrie name
                    y = 530;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 180, y, 0); //รหัสบัตรประชาชน
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameMarTH, 380, y, 0); //ชื่อคู่สมรส

                    //name student
                    y = 460;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 100, y, 0); //ชื่อนักศึกษา

                    //date contract
                    y = 438;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateContract, 150, y, 0); //วันที่ทำสัญญา
                }
                
                if (programCode == "DTDSB") {
                    //contract ID 
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);

                    /*
                    //แกน Y
                    for (int i = 0; i <= 800; i += 10) {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                    }

                    //แกน X
                    for (int i = 600; i >= 0; i -= 10) {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                    }
                    */

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                    //current date
                    y = 670;
                    cb.SetFontAndSize(bf, 15);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayP1, 390, y, 0); //date
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHP1, 435, y, 0); //month
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHP1, 515, y, 0); //year

                    //fullname, age parent
                    y = 650;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 180, y, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 490, y, 0);

                    //occupation, position, agency
                    y = 625;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, occupationTH, 80, y, 0); //อาชีพ
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, position, 250, y, 0); //ตำแหน่ง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, agencyNameTH, 380, y, 0); //สังกัด

                    //no, moo, soi
                    y = 600;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 110, y, 0); //บ้านเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 190, y, 0); //หมู่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 270, y, 0); //ตรอก/ซอย
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 410, y, 0); //ถนน

                    //subdistrict, district, province
                    y = 578;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 110, y, 0); //ตำบล/แขวง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 265, y, 0); //อำเภอ/เขต
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 400, y, 0); //จังหวัด

                    //zipcode, phone, mobile
                    y = 555;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 110, y, 0); //รหัสไปรษณีย์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 250, y, 0); //เบอร์โทรศัพท์บ้าน
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, mobile, 430, y, 0); //เบอร์โทรศัพท์มือถือ

                    //marrie name
                    y = 530;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 180, y, 0); //รหัสบัตรประชาชน
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameMarTH, 380, y, 0); //ชื่อคู่สมรส

                    //name student
                    y = 460;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 100, y, 0); //ชื่อนักศึกษา

                    //date contract
                    y = 438;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateContract, 150, y, 0); //วันที่ทำสัญญา
                }
                
                if (programCode == "RANSB") {
                    //contract ID 
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);

                    /*
                    //แกน Y
                    for (int i = 0; i <= 800; i += 10) {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                    }

                    //แกน X
                    for (int i = 600; i >= 0; i -= 10) {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                    }
                    */

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                    //current date
                    y = 670;
                    cb.SetFontAndSize(bf, 15);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayP1, 390, y, 0); //date
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHP1, 435, y, 0); //month
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHP1, 515, y, 0); //year

                    //fullname, age parent
                    y = 650;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 180, y, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 490, y, 0);

                    //occupation, position, agency
                    y = 625;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, occupationTH, 80, y, 0); //อาชีพ
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, position, 250, y, 0); //ตำแหน่ง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, agencyNameTH, 380, y, 0); //สังกัด

                    //no, moo, soi
                    y = 600;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 110, y, 0); //บ้านเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 190, y, 0); //หมู่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 270, y, 0); //ตรอก/ซอย
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 410, y, 0); //ถนน

                    //subdistrict, district, province
                    y = 578;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 110, y, 0); //ตำบล/แขวง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 265, y, 0); //อำเภอ/เขต
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 400, y, 0); //จังหวัด

                    //zipcode, phone, mobile
                    y = 555;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 110, y, 0); //รหัสไปรษณีย์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 250, y, 0); //เบอร์โทรศัพท์บ้าน
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, mobile, 430, y, 0); //เบอร์โทรศัพท์มือถือ

                    //marrie name
                    y = 530;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 180, y, 0); //รหัสบัตรประชาชน
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameMarTH, 380, y, 0); //ชื่อคู่สมรส

                    //name student
                    y = 460;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 100, y, 0); //ชื่อนักศึกษา

                    //date contract
                    y = 438;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateContract, 150, y, 0); //วันที่ทำสัญญา
                }
                
                if (programCode == "NSNSB") {
                    //contract ID 
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);

                    /*
                    //แกน Y
                    for (int i = 0; i <= 800; i += 10) {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                    }
                    
                    //แกน X
                    for (int i = 600; i >= 0; i -= 10) {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                    }
                    */

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                    //current date
                    y = 670;
                    cb.SetFontAndSize(bf, 15);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayP1, 390, y, 0); //date
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHP1, 435, y, 0); //month
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHP1, 515, y, 0); //year

                    //fullname, age parent
                    y = 650;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 180, y, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 490, y, 0);

                    //occupation, position, agency
                    y = 625;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, occupationTH, 80, y, 0); //อาชีพ
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, position, 250, y, 0); //ตำแหน่ง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, agencyNameTH, 380, y, 0); //สังกัด

                    //no, moo, soi
                    y = 600;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 110, y, 0); //บ้านเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 190, y, 0); //หมู่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 270, y, 0); //ตรอก/ซอย
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 410, y, 0); //ถนน

                    //subdistrict, district, provice
                    y = 578;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 110, y, 0); //ตำบล/แขวง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 265, y, 0); //อำเภอ/เขต
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 400, y, 0); //จังหวัด

                    //zipcode, phone, mobile
                    y = 555;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 110, y, 0); //รหัสไปรษณีย์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 250, y, 0); //เบอร์โทรศัพท์บ้าน
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, mobile, 430, y, 0); //เบอร์โทรศัพท์มือถือ

                    //marrie name
                    y = 530;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 180, y, 0); //รหัสบัตรประชาชน
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameMarTH, 380, y, 0); //ชื่อคู่สมรส

                    //name student
                    y = 460;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 100, y, 0); //ชื่อนักศึกษา

                    //date contract
                    y = 438;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateContract, 150, y, 0); //วันที่ทำสัญญา
                }

                cb.EndText();

                //ขึ้นหน้าใหม่
                document.NewPage();
                cb.BeginText();

                //หน้าที่ 2 relationship
                PdfImportedPage page2 = writer.GetImportedPage(reader, 2); //หน้า pdf template 2
                cb.AddTemplate(page2, 0, 0);

                //contract ID 
                y = 745;
                cb.SetFontAndSize(bf, 10);
                cb.SetColorFill(BaseColor.GRAY);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                if (programCode == "SIMDB" ||
                    programCode == "RAMDB") {
                    y = 322;
                }
                else {
                    if (programCode == "PYPYB") {
                        y = 290;
                    }
                    else {
                        if (programCode == "DTDSB") {
                            y = 290;
                        }
                        else {
                            if (programCode == "RANSB") {
                                y = 270;
                            }
                            else {
                                if (programCode == "NSNSB") {
                                    y = 270;
                                }
                            }
                        }
                    }
                }

                cb.SetFontAndSize(bf, 15);
                cb.SetColorFill(BaseColor.BLACK);

                /*
                //แกน Y
                for (int i = 0; i <= 800; i += 10) {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                }
                
                //แกน X
                for (int i = 600; i >= 0; i -= 10) {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                }
                */

                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, relationship, 290, y, 0); //เกี่ยวพันกับนักศึกษาโดยเป็น

                cb.EndText();

                //ขึ้นหน้าใหม่
                document.NewPage();
                cb.BeginText();

                //หน้าที่ 3 ลายเซ็นผู้ค้ำ
                PdfImportedPage page3 = writer.GetImportedPage(reader, 3); //หน้า pdf template 3
                cb.AddTemplate(page3, 0, 0);

                //contract ID 
                y = 745;
                cb.SetFontAndSize(bf, 10);
                cb.SetColorFill(BaseColor.GRAY);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                cb.SetFontAndSize(bf, 15);
                cb.SetColorFill(BaseColor.BLACK);

                /*
                //แกน Y
                for (int i = 0; i <= 800; i += 10) {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                }

                //แกน X
                for (int i = 600; i >= 0; i -= 10) {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                }
                */

                if (programCode == "SIMDB" ||
                    programCode == "RAMDB") {
                    y = 375;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 325, y, 0); //ลงชื่อผู้ค้ำประกัน

                    y = 343;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 325, y, 0); //ลงชื่อผู้ค้ำประกัน
                    cb.EndText();
                }

                if (programCode == "PYPYB") {
                    y = 355;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 325, y, 0); //ลงชื่อผู้ค้ำประกัน

                    y = 320;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 325, y, 0); //ลงชื่อผู้ค้ำประกัน
                    cb.EndText();
                }
                
                if (programCode == "DTDSB") {
                    y = 375;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 325, y, 0); //ลงชื่อผู้ค้ำประกัน

                    y = 343;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 325, y, 0); //ลงชื่อผู้ค้ำประกัน
                    cb.EndText();
                }

                if (programCode == "RANSB") {
                    y = 330;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 325, y, 0); //ลงชื่อผู้ค้ำประกัน

                    y = 300;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 325, y, 0); //ลงชื่อผู้ค้ำประกัน
                    cb.EndText();
                }
                
                if (programCode == "NSNSB") {
                    y = 330;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 325, y, 0); //ลงชื่อผู้ค้ำประกัน

                    y = 300;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 325, y, 0); //ลงชื่อผู้ค้ำประกัน
                    cb.EndText();
                }

                //ขึ้นหน้าใหม่
                document.NewPage();
                cb.BeginText();

                //หน้าที่ 4 หนังสือให้ความยินยอมคู่สมรส
                PdfImportedPage page4 = writer.GetImportedPage(reader, 4); //หน้า pdf template 4
                cb.AddTemplate(page4, 0, 0);

                string idCardOnsent = "";
                string fullNameTHOnsent = "";
                string fullNameTHOnsent1 = "";
                string ageOnsent = "";
                string dateSign = Myconfig.CvEmpty(ctInfo.DateLongContractParent2, "");

                if (dateSign == "") {
                    dateSign = (date.Day + " " + date.MonthNameTH + " " + date.YearTH);
                }

                //ข้อมูลบิดา
                //ผู้ให้ควมยินยอมคู่สมรส
                //parent sign
                //string signCur = Myconfig.CvEmpty(parentInfo.FullNameTH, " - ");
                //string consentBy = ctInfo.ConsentBy; //ยินยอมโดย
                //string warrantBy = ctInfo.WarrantBy; //ค้ำประกัน
                //string aliveF = ctInfo.IsAliveFather; //สถานะพ่อ 1 = มีชีวิต, 2 = เสียชีวิต
                //string aliveM = ctInfo.IsAliveMother; //สถานะแม่ 1 = มีชีวิต, 2 = เสียชีวิต
                //string marriage = ctInfo.IsMarriage; //1 = สมรส, 2 = สมรส(ไม่ได้จดทะเบียน), 3 = บิดามารดาหย่าร้าง
                //string remark = ""; //หมายเหตุ

                //กรณีสมรสกันบิดาและมารดายังมีชีวิตอยู่ทั้งคู่
                //รวมไปถึง marital status = 4,5
                if (marriage == "1") {
                    if (aliveF == "1" &&
                        aliveM == "1") {
                        //แม่ค้ำ พ่อยินยอมคู่สมรส
                        if (consentBy == "F") {
                            fullNameTHOnsent = Myconfig.CvEmpty(parentFInfo.FullNameTH, " - ");
                            fullNameTHOnsent1 = Myconfig.CvEmpty(parentMInfo.FullNameTH, " - ");
                            ageOnsent = Myconfig.CvEmpty(parentFInfo.Age, " - ");
                            idCardOnsent = Myconfig.CvEmpty(parentFInfo.IDCard, " - ");
                        }
                        else {
                            //พ่อค้ำ แม่ยินยอมคู่สมรส
                            if (consentBy == "M") {
                                fullNameTHOnsent = Myconfig.CvEmpty(parentMInfo.FullNameTH, " - "); //ผู้ให้ความยินยอม
                                fullNameTHOnsent1 = Myconfig.CvEmpty(parentFInfo.FullNameTH, " - "); //ผู้ค้ำ
                                ageOnsent = Myconfig.CvEmpty(parentMInfo.Age, " - ");
                                idCardOnsent = Myconfig.CvEmpty(parentMInfo.IDCard, " - ");
                            }
                            else {
                                fullNameTHOnsent = " - ";
                                fullNameTHOnsent1 = " - ";
                                ageOnsent = " - ";
                                idCardOnsent = " - ";
                            }
                        }
                    }
                    else {
                        if (aliveM == "1" &&
                            aliveF == "2") {
                            fullNameTHOnsent = " - ";
                            fullNameTHOnsent1 = " - ";
                            ageOnsent = " - ";
                            idCardOnsent = " - ";
                            dateSign = "-";
                            //remark = "หมายเหตุ : บิดาเสียชีวิต";
                            assure2 = "X"; //คู่สมรสตาย : ใช้กับเคสที่เป็นหม้าย
                        }
                        else {
                            if (aliveM == "2" &&
                                aliveF == "1") {
                                fullNameTHOnsent = " - ";
                                fullNameTHOnsent1 = " - ";
                                ageOnsent = " - ";
                                idCardOnsent = " - ";
                                dateSign = "-";
                                //remark = "หมายเหตุ : มารดาเสียชีวิต";
                                assure2 = "X";//คู่สมรสตาย : ใช้กับเคสที่เป็นหม้าย
                            }
                        }
                    }
                }
                else {
                    //กรณีไม่สมรสหรือหย่าร้าง
                    fullNameTHOnsent = "-";
                    fullNameTHOnsent1 = " - ";
                    ageOnsent = " - ";
                    idCardOnsent = " - ";
                    //signCur = "-";
                    dateSign = "-";

                    //สมรส (ไม่จดทะเบียน)
                    if (marriage == "2") {
                        //remark = "หมายเหตุ : บิดาและมารดามิได้จดทะเบียนสมรสกัน";
                        assure1 = "X";//โสด : ใช้กับเคสที่ไม่จดทะเบียนสมรส กับเคสที่เป็นโสด
                    }
                    else {
                        if (marriage == "3") {
                            //remark = "หมายเหตุ : บิดาและมารดาจดทะเบียนหย่า";
                            assure3 = "X";//- หย่าร้าง : ใช้กับเคสที่เป็นหย่าร้าง
                        }
                    }
                }

                string singleSts = (assure1 == "X" ? "X" : ""); //คู่สมรสตาย : ใช้กับเคสที่เป็นหม้าย
                string dieSts = (assure2 == "X" ? "X" : ""); //โสด : ใช้กับเคสที่ไม่จดทะเบียนสมรส กับเคสที่เป็นโสด
                string divorceSts = (assure3 == "X" ? "X" : ""); //หย่าร้าง : ใช้กับเคสที่เป็นหย่าร้าง

                //ผู้ค้ำประกัน ไม่ใช่ คนเดียวกันกับผู้ยินยอม
                if (warrantBy != consentBy) {
                    if (programCode == "SIMDB") {
                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        
                        /*
                        //แกน Y
                        for (int i = 0; i <= 800; i += 10) {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                        }
                        
                        //แกน X
                        for (int i = 600; i >= 0; i -= 10) {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                        }
                        */

                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //fullname, age parent
                        y = 692;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 130, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ageOnsent, 305, y, 0); //อายุ
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCardOnsent, 445, y, 0); //รหัสบัตรประชาชน

                        //คู่สมรส
                        y = 670;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 150, y, 0);

                        //คู่สมรส
                        y = 647;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 90, y, 0);

                        //วันที่
                        y = 625;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateSign, 60, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 370, y, 0);

                        //ลงนาม
                        y = 580;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 320, y, 0);
                        
                        y = 543;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 320, y, 0);

                        y = 510;
                        //รับรอง assure โสด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, singleSts, 206, y, 0);
                        //รับรอง assure คู่สมรสตาย
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dieSts, 276, y, 0);
                        //รับรอง assure หย่าร้าง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, divorceSts, 370, y, 0);

                        //รหัสนักศึกษา
                        y = 480;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, studentProgram, 380, y, 0);

                        /*
                        //หมายเหตุ
                        y = 450;
                        cb.SetFontAndSize(bf, 18);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, remark, 60, y, 0);

                        cb.EndText();
                        */
                    }

                    if (programCode == "RAMDB") {
                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);

                        /*
                        //แกน Y
                        for (int i = 0; i <= 800; i += 10) {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                        }

                        //แกน X
                        for (int i = 600; i >= 0; i -= 10) {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "" + i + "--", i, 820, 270);
                        }
                        */

                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //fullname, age parent
                        y = 692;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 130, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ageOnsent, 305, y, 0); //อายุ
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCardOnsent, 445, y, 0); //รหัสบัตรประชาชน

                        //คู่สมรส
                        y = 670;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 150, y, 0);

                        //คู่สมรส
                        y = 647;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 90, y, 0);
                        
                        //วันที่
                        y = 625;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateSign, 60, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 370, y, 0);
                        
                        //ลงนาม
                        y = 580;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 320, y, 0);

                        y = 543;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 320, y, 0);

                        y = 510;
                        //รับรอง assure โสด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, singleSts, 206, y, 0);
                        //รับรอง assure คู่สมรสตาย
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dieSts, 276, y, 0);
                        //รับรอง assure หย่าร้าง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, divorceSts, 370, y, 0);

                        //รหัสนักศึกษา
                        y = 480;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, studentProgram, 380, y, 0);

                        /*
                        //หมายเหตุ
                        y = 450;
                        cb.SetFontAndSize(bf, 18);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, remark, 60, y, 0);
                        
                        cb.EndText();
                        */
                    }
                    
                    if (programCode == "PYPYB") {
                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);

                        /*
                        //แกน Y
                        for (int i = 0; i <= 800; i += 10) {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                        }

                        //แกน X
                        for (int i = 600; i >= 0; i -= 10) {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                        }
                        */

                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //fullname, age parent
                        y = 692;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 130, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ageOnsent, 305, y, 0); //อายุ
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCardOnsent, 445, y, 0); //รหัสบัตรประชาชน

                        //คู่สมรส
                        y = 670;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 150, y, 0);
                        
                        //คู่สมรส
                        y = 647;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 90, y, 0);

                        //วันที่
                        y = 625;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateSign, 60, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 370, y, 0);

                        //ลงนาม
                        y = 580;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 320, y, 0);
                        
                        y = 543;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 320, y, 0);

                        y = 510;
                        //รับรอง assure โสด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, singleSts, 206, y, 0);
                        //รับรอง assure คู่สมรสตาย
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dieSts, 276, y, 0);
                        //รับรอง assure หย่าร้าง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, divorceSts, 370, y, 0);

                        //รหัสนักศึกษา
                        y = 480;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, studentProgram, 380, y, 0);

                        /*
                        //หมายเหตุ
                        y = 450;
                        cb.SetFontAndSize(bf, 18);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, remark, 60, y, 0);
                        
                        cb.EndText();
                        */
                    }
                    
                    if (programCode == "DTDSB") {
                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);

                        /*
                        //แกน Y
                        for (int i = 0; i <= 800; i += 10) {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                        }
                        
                        //แกน X
                        for (int i = 600; i >= 0; i -= 10) {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                        }
                        */

                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //fullname, age parent
                        y = 692;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 130, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ageOnsent, 305, y, 0); //อายุ
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCardOnsent, 445, y, 0);//รหัสบัตรประชาชน

                        //คู่สมรส
                        y = 670;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 150, y, 0);

                        //คู่สมรส
                        y = 647;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 90, y, 0);

                        //วันที่
                        y = 625;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateSign, 60, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 370, y, 0);

                        //ลงนาม
                        y = 580;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 320, y, 0);
                        
                        y = 543;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 320, y, 0);

                        y = 510;
                        //รับรอง assure โสด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, singleSts, 206, y, 0);
                        //รับรอง assure คู่สมรสตาย
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dieSts, 276, y, 0);
                        //รับรอง assure หย่าร้าง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, divorceSts, 370, y, 0);
                        //รหัสนักศึกษา
                        y = 480;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, studentProgram, 380, y, 0);

                        /*
                        //หมายเหตุ
                        y = 450;
                        cb.SetFontAndSize(bf, 18);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, remark, 60, y, 0);
                        
                        cb.EndText();
                        */
                    }

                    if (programCode == "RANSB") {
                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);

                        /*
                        //แกน Y
                        for (int i = 0; i <= 800; i += 10) {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                        }

                        //แกน X
                        for (int i = 600; i >= 0; i -= 10) {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                        }
                        */

                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //fullname, age parent
                        y = 692;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 130, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ageOnsent, 305, y, 0); //อายุ
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCardOnsent, 445, y, 0); //รหัสบัตรประชาชน

                        //คู่สมรส
                        y = 670;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 150, y, 0);
                        
                        //คู่สมรส
                        y = 647;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 90, y, 0);
                        
                        //วันที่
                        y = 625;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateSign, 60, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 370, y, 0);
                        
                        //ลงนาม
                        y = 580;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 320, y, 0);
                        
                        y = 543;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 320, y, 0);

                        y = 510;
                        //รับรอง assure โสด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, singleSts, 206, y, 0);
                        //รับรอง assure คู่สมรสตาย
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dieSts, 276, y, 0);
                        //รับรอง assure หย่าร้าง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, divorceSts, 370, y, 0);

                        //รหัสนักศึกษา
                        y = 480;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, studentProgram, 380, y, 0);

                        /*
                        //หมายเหตุ
                        y = 450;
                        cb.SetFontAndSize(bf, 18);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, remark, 60, y, 0);
                        
                        cb.EndText();
                        */
                    }

                    if (programCode == "NSNSB") {
                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);

                        /*
                        //แกน Y
                        for (int i = 0; i <= 800; i += 10) {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                        }
                        
                        //แกน X
                        for (int i = 600; i >= 0; i -= 10) {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                        }
                        */

                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                                
                        //fullname, age parent
                        y = 692;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 130, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ageOnsent, 305, y, 0); //อายุ
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCardOnsent, 445, y, 0); //รหัสบัตรประชาชน

                        //คู่สมรส
                        y = 670;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 150, y, 0);

                        //คู่สมรส
                        y = 647;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 90, y, 0);

                        //วันที่
                        y = 625;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateSign, 60, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 370, y, 0);

                        //ลงนาม
                        y = 580;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 320, y, 0);
                        
                        y = 543;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 320, y, 0);

                        y = 510;
                        //รับรอง assure โสด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, singleSts, 206, y, 0);
                        //รับรอง assure คู่สมรสตาย
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dieSts, 276, y, 0);
                        //รับรอง assure หย่าร้าง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, divorceSts, 370, y, 0);

                        //รหัสนักศึกษา
                        y = 480;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, studentProgram, 380, y, 0);

                        /*
                        //หมายเหตุ
                        y = 450;
                        cb.SetFontAndSize(bf, 18);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, remark, 60, y, 0);
                        
                        cb.EndText();
                        */
                    }
                }
                else {
                    //contract ID
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);

                    /*
                    //แกน Y
                    for (int i = 0; i <= 800; i += 10) {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), 0, i, 0);
                    }

                    //แกน X
                    for (int i = 600; i >= 0; i -= 10) {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ("" + i + "--"), i, 820, 270);
                    }
                    */

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_C"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                            
                    //fullname, age parent
                    y = 692;
                    cb.SetFontAndSize(bf, 15);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 130, y, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ageOnsent, 305, y, 0); //อายุ
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCardOnsent, 445, y, 0); //รหัสบัตรประชาชน

                    //คู่สมรส
                    y = 670;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 150, y, 0);

                    //คู่สมรส
                    y = 647;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 90, y, 0);

                    //วันที่
                    y = 625;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateSign, 60, y, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent1, 370, y, 0);

                    //ลงนาม
                    y = 580;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 320, y, 0);
                    y = 543;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTHOnsent, 320, y, 0);

                    y = 510;
                    //รับรอง assure โสด
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, singleSts, 206, y, 0);
                    //รับรอง assure คู่สมรสตาย
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dieSts, 276, y, 0);
                    //รับรอง assure หย่าร้าง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, divorceSts, 370, y, 0);

                    //รหัสนักศึกษา
                    y = 480;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, studentProgram, 380, y, 0);

                    /*
                    //หมายเหตุ
                    y = 450;
                    cb.SetFontAndSize(_bf, 18);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, remark, 60, y, 0);
                    
                    cb.EndText();
                    */
                }

                cb.EndText();
                document.Close();
                writer.Close();
                reader.Close();

                //update warran path C
                //string warranPath = (Server.MapPath("~/ElectronicContract/" + acaYear + "/" + programCode + programCodeExtra + "/") + fileName);
                string warranPath = ("C:\\inetpub\\wwwroot\\Econtract\\ElectronicContract\\" + acaYear + "\\" + programCode + programCodeExtra + "\\" + fileName);
                ContractDB.SetWarranPath(studentID, acaYear, warranPath);
                FileStream sourceFile = new FileStream((Server.MapPath("~/ElectronicContract/" + acaYear + "/" + programCode + programCodeExtra + "/") + fileName), FileMode.Open);
                long FileSize;
                FileSize = sourceFile.Length;
                byte[] getContent = new byte[(int)FileSize];

                sourceFile.Read(getContent, 0, (int)sourceFile.Length);
                sourceFile.Close();
                Response.BinaryWrite(getContent);
            /*
            }
            else {
                //กรณีมี file สัญญาในระบบแล้ว เปิดอ่านเลย
                WebClient client3 = new WebClient();
                Byte[] buffer3 = client3.DownloadData(warran);

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer3.Length.ToString());
                Response.BinaryWrite(buffer3);
                client3.Dispose();
            }
            */
        }

        #endregion PrintWarrant_NEW20170820

        #region PrintGarrantee
        /*
        author      : Anussara Wanwang
        create date : 11-12-2015
        update date : 07-08-2020
        description : หนังสือให้ความยินยอมของผู้แทนโดยชอบธรรม B
        parameter   : n/a
        */
        public void PrintGarrantee(
            string studentID,
            string parentType,
            string studentCode
        ) {
            if (parentType is null){
                throw new ArgumentNullException(nameof(parentType));
            }

            //ในกรณีที่มี file ใน folder แล้วให้เปิดเลย ไม่ต้องสร้าง pdf ใหม่
            ContractInfo ctInfo = new ContractInfo(studentID);
            string garrantee = Myconfig.CvEmpty(ctInfo.GarranteePath, " - ");

            if (garrantee == " - ") {
                //StringBuilder html = new StringBuilder();
                StudentInfo stdInfo = new StudentInfo(studentCode);
                //ParentInfo parentInfo = new ParentInfo(studentID, parentType);
                ParentInfo parentMInfo = new ParentInfo(studentID, "M");
                ParentInfo parentFInfo = new ParentInfo(studentID, "F");
                //CurDate date = new CurDate();
                //string acaYear = Myconfig.GetYearContract();
                string acaYear = Myconfig.CvEmpty(stdInfo.AcaYear, " - ");
                string quotaCode = stdInfo.QuotaCode;
                string warrantBy = ctInfo.WarrantBy;
                string consentBy = ctInfo.ConsentBy;
                string programCodeExtra;
                //string studentCode = Myconfig.CvEmpty(stdInfo.StudentCode, " - ");
                string stdNameTH = Myconfig.CvEmpty(stdInfo.StdNameTH, " - ");
                //string programNameTH = Myconfig.CvEmpty(stdInfo.ProgramNameTH, " - ");
                string programCode = Myconfig.CvEmpty(stdInfo.ProgramCode, " - ");
                string idCard;
                string fullNameTH;
                string age;
                string moo;
                string no;
                string soi;
                string road;
                string subdistrict;
                string district;
                string province;
                string zipcode;
                string phone;
                string statusContract;
                //string signFather;
                string signMother;
                string dateContract = ctInfo.DateLongContractStudent;
                int checkAcaYear = Convert.ToInt32(acaYear);

                if (checkAcaYear < 2565) {
                    statusContract = "OLD";
                }
                else {
                    statusContract = "NEW";
                }

                //ข้อมูลบิดา ถ้าเป็นผู้ค้ำประกัน หรือ ผู้ยินยอมคู่สมรส ให้รับรองบุตรด้วย
                if (warrantBy == "F" ||
                    consentBy == "F") {
                    fullNameTH = Myconfig.CvEmpty(parentFInfo.FullNameTH, " - ");
                    age = Myconfig.CvEmpty(parentFInfo.Age, " - ");
                    moo = Myconfig.CvEmpty(parentFInfo.MooPermanent, " - ");
                    no = Myconfig.CvEmpty(parentFInfo.NoPermanent, " - ");
                    soi = Myconfig.CvEmpty(parentFInfo.SoiPermanent, " - ");
                    road = Myconfig.CvEmpty(parentFInfo.RoadPermanent, " - ");
                    subdistrict = Myconfig.CvEmpty(parentFInfo.SubdistrictNameTH, " - ");
                    district = Myconfig.CvEmpty(parentFInfo.DistrictNameTH, " - ");
                    province = Myconfig.CvEmpty(parentFInfo.ProvinceNameTH, " - ");
                    zipcode = Myconfig.CvEmpty(parentFInfo.ZipcodePermanent, " - ");
                    phone = Myconfig.CvEmpty(parentFInfo.PhoneNumberPermanent, " - ");
                    idCard = Myconfig.CvEmpty(parentFInfo.IDCard, " - ");
                    //signFather = Myconfig.CvEmpty(parentFInfo.FullNameTH, " - ");
                }
                else {
                    fullNameTH = " - ";
                    age = " - ";
                    moo = " - ";
                    no = " - ";
                    soi = " - ";
                    road = " - ";
                    subdistrict = " - ";
                    district = " - ";
                    province = " - ";
                    zipcode = " - ";
                    phone = " - ";
                    idCard = " - ";
                    //signFather = " - ";
                }

                string path = Server.MapPath("~");
                string fileTmp = "";

                //เรียกใช้ file template
                switch (programCode) {
                    case "SIMDB":
                        switch (statusContract) {
                            case "OLD":
                                fileTmp = (path + "/Template/B_Consent/Consent1.pdf");
                                break;
                            case "NEW":
                                fileTmp = (path + "/Template/B_Consent/SIMDB-2565-consent.pdf");
                                break;
                        }
                        break;
                    case "RAMDB":
                        switch (statusContract) {
                            case "OLD":
                                fileTmp = (path + "/Template/B_Consent/Consent1.pdf");
                                break;
                            case "NEW":
                                fileTmp = (path + "/Template/B_Consent/RAMDB-2565-consent.pdf");
                                break;
                        }
                        break;
                    case "DTDSB":
                        switch (statusContract) {
                            case "OLD":
                                fileTmp = (path + "/Template/B_Consent/Consent2.pdf");
                                break;
                            case "NEW":
                                fileTmp = (path + "/Template/B_Consent/DTDSB-2565-consent.pdf");
                                break;
                        }
                        break;
                    case "PYPYB":
                        fileTmp = (path + "/Template/B_Consent/Consent3.pdf");
                        break;
                    case "RANSB":
                    case "NSNSB":
                        fileTmp = (path + "/Template/B_Consent/Consent4.pdf");
                        break;
                }

                //folder extra
                switch (quotaCode) {
                    //siriraj hospital
                    default: 
                        programCodeExtra = "";
                        break;
                    case "354":
                        programCodeExtra = "_CL";
                        break;
                    case "351":
                        programCodeExtra = "_TM";
                        break;
                }

                string fileName = (studentCode + programCode + programCodeExtra + "_B.pdf");
                //string fileDocument = (path + "/ElectronicContract/" + fileName);

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", ("attachment;filename=" + studentCode + "_B.pdf"));
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                
                //open the reader
                PdfReader reader = new PdfReader(fileTmp); //file template
                //string path = (requestObj.PhysicalApplicationPath + "\\electronicContract\\"); 
                DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath("~/ElectronicContract/" + acaYear + "/" + programCode + programCodeExtra + "/")); //ต้องเป็นตัวแปรโฟลเดอร์ด้วยนะ

                if (!dirInfo.Exists) {
                    //Response.Write("OK");
                    dirInfo.Create();
                }

                Document document = new Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F);
                //open the writer
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream((Server.MapPath("~/ElectronicContract/" + acaYear + "/" + programCode + programCodeExtra + "/") + fileName), FileMode.Create));
                //PdfWriter writer = PdfWriter.GetInstance(_document, Response.OutputStream);                
                Response.Charset = string.Empty;
                Response.ClearContent();
                document.Open();
                int y = 0;

                //configure the content
                PdfContentByte cb = writer.DirectContent;
                //write the text here
                cb.BeginText();

                //หน้าที่ 1
                PdfImportedPage page1 = writer.GetImportedPage(reader, 1); //หน้า pdf template 1
                cb.AddTemplate(page1, 0, 0);

                if (programCode == "SIMDB" ||
                    programCode == "RAMDB") {
                    //acaYear < 2565
                    if (statusContract == "OLD") {
                        BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_B"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                        //current date
                        y = 670;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayP2, 418, y, 0); //date
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHP2, 460, y, 0); //month
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHP2, 523, y, 0); //year

                        //fullname, age parent
                        y = 647;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (fullNameTH + "  (บิดา)"), 180, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 510, y, 0);

                        //no, moo, soi
                        y = 625;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 110, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 200, y, 0); //หมู่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 290, y, 0); //ตรอก/ซอย
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 430, y, 0); //ถนน

                        //road, subdistrict, district
                        y = 600;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 110, y, 0); //ตำบล/แขวง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 282, y, 0); //อำเภอ/เขต
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 415, y, 0); //จังหวัด

                        //province, zipcode, phone
                        y = 578;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 130, y, 0); //รหัสไปรษณีย์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 220, y, 0); //เบอร์โทรศัพท์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 420, y, 0); //รหัสบัตรประชาชน

                        //sign father
                        y = 295;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 350, y, 0);
                    }
                    else {
                        //acayear >= 2565
                        BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        //contract ID
                        y = 746;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_B"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                        //current date
                        y = 645;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayP2, 346, y, 0); //date
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHP2, 400, y, 0); //month
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHP2, 509, y, 0); //year

                        //fullname, age parent, no, moo
                        y = 611;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 180, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 338, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 433, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 521, y, 0); //หมู่

                        //soi, road, subdistrict
                        y = 587;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 136, y, 0); //ตรอก/ซอย
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 251, y, 0); //ถนน
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 424, y, 0); //ตำบล/แขวง

                        //district, province, zipcode
                        y = 566;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 136, y, 0); //อำเภอ/เขต
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 300, y, 0); //จังหวัด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 489, y, 0); //รหัสไปรษณีย์

                        //telephone, ID card
                        y = 545;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 125, y, 0); //เบอร์โทรศัพท์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 347, y, 0); //รหัสบัตรประชาชน
                    }
                }
                
                if (programCode == "DTDSB") {
                    if (statusContract == "OLD") {
                        BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        
                        //contract ID
                        y = 745;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_B"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                        //current date
                        y = 670;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayP2, 418, y, 0); //date
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHP2, 460, y, 0); //month
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHP2, 523, y, 0); //year

                        //fullname, age parent
                        y = 647;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (fullNameTH + "  (บิดา)"), 180, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 510, y, 0);

                        //no, moo, soi
                        y = 625;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 130, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 210, y, 0); //หมู่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 310, y, 0); //ตรอก/ซอย
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 450, y, 0); //ถนน

                        //road, subdistrict, district
                        y = 600;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 110, y, 0); //ตำบล/แขวง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 282, y, 0); //อำเภอ/เขต
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 415, y, 0); //จังหวัด

                        //province, zipcode, phone
                        y = 578;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 130, y, 0); //รหัสไปรษณีย์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 220, y, 0); //เบอร์โทรศัพท์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 420, y, 0); //รหัสบัตรประชาชน
                                                                                            
                        //sign father
                        y = 295;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 350, y, 0);
                    }
                    else {
                        //acayear >= 2565
                        BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        //contract ID
                        y = 746;
                        cb.SetFontAndSize(bf, 10);
                        cb.SetColorFill(BaseColor.GRAY);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_B"), 438, y, 0); //สัญญาเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                        //current date
                        y = 645;
                        cb.SetFontAndSize(bf, 15);
                        cb.SetColorFill(BaseColor.BLACK);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayP2, 346, y, 0); //date
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHP2, 400, y, 0); //month
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHP2, 509, y, 0); //year

                        //fullname, age parent, no, moo
                        y = 610;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 180, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 338, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 433, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 521, y, 0); //หมู่

                        //soi, road, subdistrict
                        y = 587;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 136, y, 0); //ตรอก/ซอย
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 251, y, 0); //ถนน
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 424, y, 0); //ตำบล/แขวง

                        //district, province, zipcode
                        y = 566;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 136, y, 0); //อำเภอ/เขต
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 300, y, 0); //จังหวัด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 489, y, 0); //รหัสไปรษณีย์

                        //telephone, ID card
                        y = 545;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 125, y, 0); //เบอร์โทรศัพท์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 347, y, 0); //รหัสบัตรประชาชน
                    }
                }
                
                if (programCode == "PYPYB") {
                    BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                    //contract ID
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_B"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา

                    //current date
                    y = 670;
                    cb.SetFontAndSize(bf, 15);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayP2, 418, y, 0); //date
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHP2, 460, y, 0); //month
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHP2, 523, y, 0); //year

                    //fullname, age parent
                    y = 648;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (fullNameTH + "  (บิดา)"), 180, y, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 510, y, 0);

                    //no, moo, soi
                    y = 625;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 130, y, 0); //บ้านเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 220, y, 0); //หมู่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 300, y, 0); //ตรอก/ซอย
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 445, y, 0); //ถนน

                    //road, subdistrict, district
                    y = 600;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 110, y, 0); //ตำบล/แขวง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 280, y, 0); //อำเภอ/เขต
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 410, y, 0); //จังหวัด

                    //province, zipcode, phone
                    y = 578;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 130, y, 0); //รหัสไปรษณีย์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 220, y, 0); //เบอร์โทรศัพท์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 420, y, 0); //รหัสบัตรประชาชน

                    //sign father
                    y = 295;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 400, y, 0);
                }
                
                if (programCode == "RANSB" ||
                    programCode == "NSNSB") {
                    BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                    //contract ID
                    y = 745;
                    cb.SetFontAndSize(bf, 10);
                    cb.SetColorFill(BaseColor.GRAY);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode + "_B"), 438, y, 0); //สัญญาเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (studentCode + programCode), 540, y, 0); //รหัสนักศึกษา
                                                                                                            
                    //current date
                    y = 670;
                    cb.SetFontAndSize(bf, 15);
                    cb.SetColorFill(BaseColor.BLACK);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayP2, 418, y, 0); //date
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHP2, 460, y, 0); //month
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHP2, 523, y, 0); //year
                                                                                                 
                    //fullname, age parent
                    y = 648;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (fullNameTH + "  (บิดา)"), 180, y, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 505, y, 0);

                    //no, moo, soi
                    y = 625;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 115, y, 0); //บ้านเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 220, y, 0); //หมู่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 300, y, 0); //ตรอก/ซอย
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 445, y, 0); //ถนน

                    //road, subdistrict, district
                    y = 600;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 100, y, 0); //ตำบล/แขวง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 285, y, 0); //อำเภอ/เขต
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 415, y, 0); //จังหวัด

                    //province, zipcode, phone
                    y = 578;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 130, y, 0); //รหัสไปรษณีย์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 215, y, 0); //เบอร์โทรศัพท์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 420, y, 0); //รหัสบัตรประชาชน

                    //sign father
                    y = 275;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 400, y, 0);
                }

                //show mohter profile
                //ข้อมูลมารดา ถ้าเป็นผู้ค้ำประกัน หรือ ผู้ยินยอมคู่สมรส ให้รับรองบุตรด้วย
                if (warrantBy == "M" ||
                    consentBy == "M") {
                    fullNameTH = Myconfig.CvEmpty(parentMInfo.FullNameTH, " - ");
                    age = Myconfig.CvEmpty(parentMInfo.Age, " - ");
                    moo = Myconfig.CvEmpty(parentMInfo.MooPermanent, " - ");
                    no = Myconfig.CvEmpty(parentMInfo.NoPermanent, " - ");
                    soi = Myconfig.CvEmpty(parentMInfo.SoiPermanent, " - ");
                    road = Myconfig.CvEmpty(parentMInfo.RoadPermanent, " - ");
                    subdistrict = Myconfig.CvEmpty(parentMInfo.SubdistrictNameTH, " - ");
                    district = Myconfig.CvEmpty(parentMInfo.DistrictNameTH, " - ");
                    province = Myconfig.CvEmpty(parentMInfo.ProvinceNameTH, " - ");
                    zipcode = Myconfig.CvEmpty(parentMInfo.ZipcodePermanent, " - ");
                    phone = Myconfig.CvEmpty(parentMInfo.PhoneNumberPermanent, " - ");
                    idCard = Myconfig.CvEmpty(parentMInfo.IDCard, " - ");
                    signMother = Myconfig.CvEmpty(parentMInfo.FullNameTH, " - ");
                }
                else {
                    fullNameTH = " - ";
                    age = " - ";
                    moo = " - ";
                    no = " - ";
                    soi = " - ";
                    road = " - ";
                    subdistrict = " - ";
                    district = " - ";
                    province = " - ";
                    zipcode = " - ";
                    phone = " - ";
                    idCard = " - ";
                    signMother = " - ";
                }

                if (programCode == "SIMDB" ||
                    programCode == "RAMDB") {
                    //acaYear < 2565
                    if (statusContract == "OLD") {                        
                        BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        //fullname, age
                        y = 530;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (fullNameTH + "  (มารดา)"), 180, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 505, y, 0);

                        //no, moo, soi
                        y = 505;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 130, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 200, y, 0); //หมู่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 285, y, 0); //ตรอก/ซอย
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 425, y, 0); //ถนน

                        //road, subdistrict, district
                        y = 482;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 105, y, 0); //ตำบล/แขวง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 282, y, 0); //อำเภอ/เขต
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 415, y, 0); //จังหวัด
                                                                                             
                        //province, zipcode, phone
                        y = 460;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 130, y, 0); //รหัสไปรษณีย์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 220, y, 0); //เบอร์โทรศัพท์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 420, y, 0); //รหัสบัตรประชาชน

                        //name student
                        y = 437;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 240, y, 0); //ชื่อนักศึกษา

                        y = 412;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 350, y, 0); //ชื่อนักศึกษา

                        y = 389;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateContract, 289, y, 0); //วันที่ทำสัญญา

                        y = 368;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 90, y, 0); //ชื่อนักศึกษา

                        //sign Mather
                        y = 250;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 350, y, 0);

                        cb.EndText();
                    }
                    else {
                        //acaYear < 2565
                        BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                        
                        //fullname, age, no, moo
                        y = 525;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 165, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 336, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 432, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 520, y, 0); //หมู่

                        //soi, road, subdistrict
                        y = 502;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 136, y, 0); //ตรอก/ซอย
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 251, y, 0); //ถนน
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 424, y, 0); //ตำบล/แขวง

                        //district, province, zipcode
                        y = 480;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 136, y, 0); //อำเภอ/เขต
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 300, y, 0); //จังหวัด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 489, y, 0); //รหัสไปรษณีย์

                        //telephone, ID card
                        y = 459;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 125, y, 0); //เบอร์โทรศัพท์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 347, y, 0); //รหัสบัตรประชาชน

                        //name student
                        y = 439;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 267, y, 0); //ชื่อนักศึกษา

                        y = 398;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 189, y, 0); //ชื่อนักศึกษา

                        y = 354;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 89, y, 0); //ชื่อนักศึกษา

                        //relation
                        y = 418;
                        //บิดาและมารดา
                        if (Myconfig.CvEmpty(parentFInfo.FullNameTH, "") != "" &&
                            Myconfig.CvEmpty(parentMInfo.FullNameTH, "") != "") {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "บิดาและมารดา", 178, y, 0);
                        }
                        else {
                            //บิดา
                            if (Myconfig.CvEmpty(parentFInfo.FullNameTH, "") != "" &&
                                Myconfig.CvEmpty(parentMInfo.FullNameTH, "") == "") {
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "บิดา", 185, y, 0);
                            }
                            else {
                                //มารดา
                                if (Myconfig.CvEmpty(parentFInfo.FullNameTH, "") == "" &&
                                    Myconfig.CvEmpty(parentMInfo.FullNameTH, "") != "") {
                                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "มารดา", 185, y, 0);
                                }
                            }
                        }

                        //contract date
                        y = 374;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayStd, 205, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHStd, 262, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHStd, 357, y, 0);

                        //sign father & mother
                        y = 311;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Myconfig.CvEmpty(parentFInfo.FullNameTH, " "), 199, y, 0);

                        y = 248;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Myconfig.CvEmpty(parentMInfo.FullNameTH, " "), 199, y, 0);

                        cb.EndText();
                    }
                }
                
                if (programCode == "DTDSB") {
                    //acaYear < 2565
                    if (statusContract == "OLD") {
                        BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        //fullname, age
                        y = 530;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (fullNameTH + "  (มารดา)"), 180, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 505, y, 0);

                        //no, moo, soi
                        y = 505;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 130, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 200, y, 0); //หมู่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 285, y, 0); //ตรอก/ซอย
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 425, y, 0); //ถนน
                                                                                          
                        //road, subdistrict, district
                        y = 482;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 105, y, 0); //ตำบล/แขวง
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 282, y, 0); //อำเภอ/เขต
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 415, y, 0); //จังหวัด
                                                                                             
                        //province, zipcode, phone
                        y = 460;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 130, y, 0); //รหัสไปรษณีย์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 220, y, 0); //เบอร์โทรศัพท์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 420, y, 0); //รหัสบัตรประชาชน

                        //name student
                        y = 437;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 240, y, 0); //ชื่อนักศึกษา

                        y = 412;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 400, y, 0); //ชื่อนักศึกษา

                        y = 389;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateContract, 289, y, 0); //วันที่ทำสัญญา

                        y = 368;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 90, y, 0); //ชื่อนักศึกษา
                                                                                              
                        //sign mather
                        y = 250;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 350, y, 0);
                        cb.EndText();
                    }
                    else {
                        //acaYear < 2565
                        BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        //fullname, age, no, moo
                        y = 524;
                        cb.SetFontAndSize(bf, 15);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 165, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 336, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 432, y, 0); //บ้านเลขที่
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 520, y, 0); //หมู่

                        //soi, road, subdistrict
                        y = 502;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 136, y, 0); //ตรอก/ซอย
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 251, y, 0); //ถนน
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 424, y, 0); //ตำบล/แขวง

                        //district, province, zipcode
                        y = 480;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 136, y, 0); //อำเภอ/เขต
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 300, y, 0); //จังหวัด
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 489, y, 0); //รหัสไปรษณีย์

                        //telephone, ID card
                        y = 459;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 125, y, 0); //เบอร์โทรศัพท์
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 347, y, 0); //รหัสบัตรประชาชน

                        //name student
                        y = 439;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 267, y, 0); //ชื่อนักศึกษา

                        y = 397;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 215, y, 0); //ชื่อนักศึกษา

                        y = 354;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 89, y, 0); //ชื่อนักศึกษา

                        //relation
                        y = 418;
                        //บิดาและมารดา
                        if (Myconfig.CvEmpty(parentFInfo.FullNameTH, "") != "" &&
                            Myconfig.CvEmpty(parentMInfo.FullNameTH, "") != "") {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "บิดาและมารดา", 178, y, 0);
                        }
                        else {
                            //บิดา
                            if (Myconfig.CvEmpty(parentFInfo.FullNameTH, "") != "" &&
                                Myconfig.CvEmpty(parentMInfo.FullNameTH, "") == "") {
                                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "บิดา", 185, y, 0);
                            }
                            else {
                                //มารดา
                                if (Myconfig.CvEmpty(parentFInfo.FullNameTH, "") == "" &&
                                    Myconfig.CvEmpty(parentMInfo.FullNameTH, "") != "") {
                                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "มารดา", 185, y, 0);
                                }
                            }
                        }

                        //contract date
                        y = 374;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.DayStd, 205, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.MonthNameTHStd, 262, y, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ctInfo.YearTHStd, 357, y, 0);

                        //sign father & mother
                        y = 311;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Myconfig.CvEmpty(parentFInfo.FullNameTH, " "), 199, y, 0);

                        y = 248;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Myconfig.CvEmpty(parentMInfo.FullNameTH, " "), 199, y, 0);

                        cb.EndText();
                    }
                }
                
                if (programCode == "PYPYB") {                    
                    BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                    //fullname, age
                    y = 530;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (fullNameTH + "  (มารดา)"), 180, y, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 505, y, 0);

                    //no, moo, soi
                    y = 505;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 130, y, 0); //บ้านเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 200, y, 0); //หมู่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 285, y, 0); //ตรอก/ซอย
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 425, y, 0); //ถนน
                                                                                      
                    //road, subdistrict, district
                    y = 482;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 105, y, 0); //ตำบล/แขวง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 280, y, 0); //อำเภอ/เขต
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 410, y, 0); //จังหวัด
                                                                                         
                    //provice, zipcode, phone
                    y = 460;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 130, y, 0); //รหัสไปรษณีย์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 220, y, 0); //เบอร์โทรศัพท์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 420, y, 0); //รหัสบัตรประชาชน

                    //name student
                    y = 435;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 270, y, 0); //ชื่อนักศึกษา

                    y = 415;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 350, y, 0); //ชื่อนักศึกษา
                    
                    y = 392;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateContract, 280, y, 0); //วันที่ทำสัญญา
                    
                    y = 368;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 90, y, 0); //ชื่อนักศึกษา
                                                                                          
                    //sign mother
                    y = 250;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 400, y, 0);

                    cb.EndText();
                }
                
                if (programCode == "RANSB" ||
                    programCode == "NSNSB") {
                    BaseFont bf = BaseFont.CreateFont((path + "\\fonts\\THSarabun.ttf"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                    //fullname, age
                    y = 530;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, (fullNameTH + "  (มารดา)"), 180, y, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, age, 500, y, 0);

                    //no, moo, soi
                    y = 505;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, no, 110, y, 0); //บ้านเลขที่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, moo, 200, y, 0); //หมู่
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, soi, 290, y, 0); //ตรอก/ซอย
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, road, 425, y, 0); //ถนน
                                                                                      
                    //road, subdistrict, district
                    y = 485;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, subdistrict, 105, y, 0); //ตำบล/แขวง
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, district, 285, y, 0); //อำเภอ/เขต
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, province, 415, y, 0); //จังหวัด
                                                                                         
                    //province, zipcode, phone
                    y = 460;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, zipcode, 130, y, 0); //รหัสไปรษณีย์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, phone, 215, y, 0); //เบอร์โทรศัพท์
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, idCard, 420, y, 0); //รหัสบัตรประชาชน

                    //name student
                    y = 435;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 270, y, 0); //ชื่อนักศึกษา

                    y = 390;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 180, y, 0); //ชื่อนักศึกษา

                    y = 365;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, dateContract, 230, y, 0); //วันที่ทำสัญญา

                    y = 344;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, stdNameTH, 130, y, 0); //ชื่อนักศึกษา
                                                                                           
                    //sign mother
                    y = 229;
                    cb.SetFontAndSize(bf, 15);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fullNameTH, 400, y, 0);
                    
                    cb.EndText();
                }

                document.Close();
                writer.Close();
                reader.Close();

                //update garrantee path B
                string garranteePath = (Server.MapPath("~/ElectronicContract/" + acaYear + "/" + programCode + programCodeExtra + "/") + fileName);
                ContractDB.SetGarranteePath(studentID, acaYear, garranteePath);
                FileStream sourceFile = new FileStream((Server.MapPath("~/ElectronicContract/" + acaYear + "/" + programCode + programCodeExtra + "/") + fileName), FileMode.Open);
                long FileSize;
                FileSize = sourceFile.Length;
                byte[] getContent = new byte[(int)FileSize];

                sourceFile.Read(getContent, 0, (int)sourceFile.Length);
                sourceFile.Close();
                Response.BinaryWrite(getContent);
            }
            else {
                //กรณีมี file สัญญาในระบบแล้ว เปิดอ่านเลย
                WebClient client2 = new WebClient();
                Byte[] buffer2 = client2.DownloadData(garrantee);

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", buffer2.Length.ToString());
                Response.BinaryWrite(buffer2);
                client2.Dispose();
            }
        }

        #endregion PrintGarrantee
    }
}