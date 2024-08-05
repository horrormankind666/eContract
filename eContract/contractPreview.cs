using System;
using System.Data;
using System.Text;

namespace eContract
{


    public class ContractPreview
    {
        public ContractPreview()
        {
        }




        #region SIMDB
        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: SIMDB_Preview
        /// Method : แสดงสัญญา SIMDB พรีวิว
        /// Sample : N/A
        /// </summary>
        public static string Preview_SIMDB(string _acaYear, string _studentId, string _studentCode)
        {
            StringBuilder _string = new StringBuilder();
            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
            signCEOinfo _signInfo = new signCEOinfo(_acaYear);
            CurDate _date = new CurDate();
            string _signCEO, _signCEOPosition; ;
            string _fatherName, _motherName;
            string _idCard, _stdNameTh, _birthDate, _age, _moo, _no, _soi, _road, _subdistrict, _district, _provice, _zipcode, _phone, _mobile;
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
            //_phone = Myconfig.CvEmpty(_stdInfo.Tel, " - ");
            _mobile = Myconfig.CvEmpty(_stdInfo.phoneSTD, " - ");
            _idCard = Myconfig.CvEmpty(_stdInfo.IdCard, " - ");


            _fatherName = _parentFInfo.FullNameTh;
            _motherName = _parentMInfo.FullNameTh;
            //_signCEO = Myconfig.GetSignCeoMahidol(_acaYear);
            _signCEO = Myconfig.CvEmpty(_signInfo.signNameCEO, " - ");
            _signCEOPosition = Myconfig.CvEmpty(_signInfo.SignCEOPosition, "-");




            _string.Append(@"   <div class='card-panel grey lighten-5'>
                                <div class='grey-text text-darken-4'>
                                    <div class='section'>
                                        <h5 class='center'>
                                            <img src='Images/logo.png' class='circle images' />
                                        </h5>
                                        <p class='center'><b><u>สัญญาการเป็นนักศึกษาเพื่อศึกษาวิชาแพทยศาสตร์</u></b></p>
                                    </div>
                                    <div class='section'>
                                        <div class='right'>
                                            สัญญาทำที่ มหาวิทยาลัยมหิดล<br />");
            _string.Append(@"                   วันที่ <b>" + _date.Day + "</b> เดือน <b>" + _date.MonthNameTh + "</b> พ.ศ. <b>" + _date.YearTh + "</b>");
            _string.Append(@"               </div>
                                    </div>
                                    <br />
                                    <div class='section'>
                                        <p style='text-indent: 4em;'>
                                            โดยที่รัฐบาลมีเจตจำนงมุ่งหมายที่จะให้นักศึกษาวิชาแพทยศาสตร์ทุกคนทำงาน
                                            หรือรับราชการสนองความต้องการของประเทศชาติภายหลังสำเร็จการศึกษาแล้ว และในการนี้เป็นหน้าที่ของมหาวิทยาลัยมหิดล
                                            สำนักงานคณะกรรมการข้าราชการพลเรือนและคณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาแพทยศาสตร์ ผู้สำเร็จการศึกษาไป
                                            ปฏิบัติงานในส่วนราชการหรือองค์การของรัฐบาลต่างๆ ซึ่งคณะรัฐมนตรีได้หรือจะได้แต่งตั้งขึ้นเพื่อจัดสรรนักศึกษาวิชาแพทยศาสตร์
                                            เข้าทำงานหรือรับราชการสนองความต้องการของประเทศชาติที่จะดำเนินการให้สำเร็จผลสมความมุ่งหมายดังกล่าว
                                        </p>
                                    </div>
                                
                                    <div class='section'>
                                        <p style='text-indent: 4em;'>");
            // show student prefile
            _string.Append(@"                   ข้าพเจ้า <span class='indigo-text text-darken-3'><b>" + _stdNameTh + "</b></span>");
            _string.Append(@"                   เกิดเมื่อวันที่ ");
            _string.Append(@"                   <span class='indigo-text text-darken-3'><b>" + _birthDate + "</b></span>");
            _string.Append(@"                   อายุ <span class='indigo-text text-darken-3'><b>" + _age + "</b></span> ปี ");
            _string.Append("                   ตั้งบ้านเรือนอยู่บ้านเลขที่ <span class='indigo-text text-darken-3' data-options='{\"no\":\"" + _no + "\"'><b>" + _no + "</b></span>");
            _string.Append(@"                   หมู่ที่ <span class='indigo-text text-darken-3'><b>" + _moo + "</b></span>");
            _string.Append(@"                   ตรอก /ซอย <span class='indigo-text text-darken-3'><b>" + _soi + "</b></span>");
            _string.Append(@"                   ถนน <span class='indigo-text text-darken-3'><b>" + _road + " </b></span>");
            _string.Append(@"                   ตำบล /แขวง <span class='indigo-text text-darken-3'><b>" + _subdistrict + "</b></span>");
            _string.Append(@"                   อำเภอ/เขต <span class='indigo-text text-darken-3'><b>" + _district + "</b></span>");
            _string.Append(@"                   จังหวัด <span class='indigo-text text-darken-3'><b>" + _provice + "</b></span>");
            _string.Append(@"                   รหัสไปรษณีย์ <span class='indigo-text text-darken-3'><b>" + _zipcode + "</b></span>");
            _string.Append(@"                   โทรศัพท์  <span class='indigo-text text-darken-3'><b>" + _mobile + "</b></span>");
            _string.Append(@"                   เลขบัตรประจำตัวประชาชน <span class='indigo-text text-darken-3'><b>" + _idCard + "</b></span>");
            _string.Append(@"                   ชื่อบิดา <span class='indigo-text text-darken-3'><b>" + _fatherName + "</b></span>");
            _string.Append(@"                   ชื่อมารดา <span class='indigo-text text-darken-3'><b>" + _motherName + "</b></span>");
            _string.Append(@"                   เป็นผู้หนึ่งซึ่งประสงค์จะเข้าศึกษาวิชาแพทยศาสตร์เพื่อสนองความต้องการของประเทศชาติ ตามเจตจำนงของรัฐบาล
                                            ดังกล่าวข้างต้น
                                        </p>
                                    </div>");



            _string.Append(@"           <div class='section'>
                                        <p class='center red-text'>ข้าพเจ้าจึงขอทำสัญญาให้ไว้แก่มหาวิทยาลัยมหิดล ซึ่งต่อไปในสัญญานี้เรียกว่า “มหาวิทยาลัย” ดังมีข้อความต่อไปนี้</p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 1</b> ข้าพเจ้าตกลงเข้าศึกษาวิชาแพทยศาสตร์ที่มหาวิทยาลัยนี้ ตั้งแต่วันที่ทำสัญญาเป็นต้นไป จนกว่าจะสำเร็จการศึกษาตามหลักสูตรแพทยศาสตรบัณฑิต
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            ในระหว่างที่ข้าพเจ้าศึกษาวิชาแพทยศาสตร์ตามสัญญานี้ ข้าพเจ้ายินยอมประพฤติและปฏิบัติตามระเบียบ
                                            ข้อบังคับหรือคำสั่งของมหาวิทยาลัยที่ได้กำหนดหรือสั่งการเกี่ยวกับการเป็นนักศึกษาวิชาแพทยศาสตร์ ทั้งที่ได้ออกใช้
                                            บังคับอยู่แล้วก่อนวันที่ข้าพเจ้าลงนามในสัญญานี้ และที่จะได้ออกใช้บังคับต่อไปในภายหน้าโดยเคร่งครัด และให้
                                            ถือว่าระเบียบข้อบังคับหรือคำสั่งต่างๆ ดังกล่าวเป็นส่วนหนึ่งของสัญญานี้ด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 2</b> ในระหว่างที่ข้าพเจ้าเข้าศึกษาวิชาตามสัญญานี้ ข้าพเจ้าจะตั้งใจและเพียรพยายามอย่างดีที่สุดใน
                                            การศึกษาเล่าเรียน โดยจะไม่หลีกเลี่ยง ละเลย ทอดทิ้ง ยุติ หรือเลิกการศึกษาก่อนสำเร็จการศึกษาตามหลักสูตร ดังได้ระบุ
                                            ไว้ในข้อ 1 ของสัญญานี้
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 3</b> ภายหลังจากที่สำเร็จการศึกษาตามหลักสูตรแล้ว ข้าพเจ้าตกลงยินยอมจะปฏิบัติการให้เป็นไปตามคำสั่ง
                                            ของสำนักงานคณะกรรมการข้าราชการพลเรือน และหรือคณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาแพทยศาสตร์
                                            ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการหรือองค์การของรัฐบาลต่างๆ ในการจัดสรรให้ข้าพเจ้าเข้ารับการศึกษา
                                            อบรมเพิ่มเติม ณ แห่งใด ๆ หรือเข้ารับราชการ หรือทำงานในสถานศึกษา ส่วนราชการหรือองค์การของรัฐบาลแห่ง
                                            ใดทุกประการ และในกรณีที่สำนักงานคณะกรรมการข้าราชการพลเรือน และหรือคณะกรรมการพิจารณาจัดสรร
                                            นักศึกษาวิชาแพทยศาสตร์ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการ หรือองค์การของรัฐบาลต่างๆ สั่งให้ข้าพเจ้า
                                            เข้ารับราชการหรือทำงาน ข้าพเจ้าจะรับราชการหรือทำงานนั้นอยู่ต่อไปเป็นเวลา<b class='red-text'>ไม่น้อยกว่าสามปี</b>ติดต่อกันไป
                                            นับตั้งแต่วันที่ได้กำหนดในคำสั่ง
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            แต่ถ้าหลังจากสำเร็จการศึกษาตามหลักสูตรแล้ว สำนักงานคณะกรรมการข้าราชการพลเรือน  และหรือ
                                            คณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาแพทยศาสตร์ ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการหรือองค์การ
                                            ของรัฐบาลต่างๆ ได้ให้ข้าพเจ้าเข้ารับการศึกษาอบรมเพิ่มเติมตามความต้องการของกระทรวงทบวงกรมใดต่อไปอีกแล้ว
                                            เมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้วหรือไม่ได้ทำการศึกษาอบรมเพิ่มเติมต่อไปจนสำเร็จด้วยเหตุใดก็ดี
                                            ข้าพเจ้ายินยอมเข้ารับราชการหรือทำงานตามที่สำนักงานคณะกรรมการข้าราชการพลเรือน และหรือ
                                            คณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาแพทยศาสตร์ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการหรือองค์การของ
                                            รัฐบาลต่างๆ สั่งให้เข้ารับราชการหรือทำงานนั้น โดยจะรับราชการหรือทำงานนั้นอยู่ต่อไปเป็นเวลา<b class='red-text'>ไม่น้อยกว่าสามปี</b>
                                            ติดต่อกันไปนับตั้งแต่วันที่ได้กำหนดในคำสั่ง แต่ถ้าเป็นการเข้ารับการศึกษาอบรมเพิ่มเติมในระหว่างที่รับราชการหรือ
                                            ทำงานตามคำสั่งในวรรคแรก เมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ทำการศึกษาอบรมเพิ่มเติมต่อไป
                                            จนสำเร็จด้วยเหตุใดก็ดี ข้าพเจ้าจะยินยอมเข้ารับราชการหรือทำงานต่อไปจนครบกำหนดระยะเวลา<b class='red-text'>ไม่น้อยกว่าสามปี</b>
                                            ทั้งนี้ ไม่นับระยะเวลาระหว่างเข้ารับการศึกษาอบรมเพิ่มเติมรวมคำนวณเข้าด้วย
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าข้าพเจ้าไม่รับราชการ หรือทำงานตามที่กล่าวในวรรคแรก หรือวรรคสองแล้วแต่กรณี ข้าพเจ้ายินยอมรับผิด
                                            ชดใช้เงินให้แก่มหาวิทยาลัยเป็น<span class='red-text'>จำนวน 400,000 บาท (สี่แสนบาทถ้วน)</span> ภายในกำหนดเวลาที่มหาวิทยาลัย
                                            เรียกร้องให้ชำระ
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าข้าพเจ้ารับราชการ หรือทำงานไม่ครบกำหนดเวลาตามที่กล่าวไว้ในวรรคแรกหรือวรรคสอง แล้วแต่กรณี
                                            ข้าพเจ้ายินยอมรับผิดชดใช้เงินให้แก่มหาวิทยาลัยตามระยะเวลาที่ขาด โดยคิดคำนวณลดลงตามส่วนเฉลี่ยจากจำนวนเงิน
                                            ที่ต้องชดใช้ในวรรคก่อน
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าการที่ข้าพเจ้ามิได้เข้ารับราชการหรือทำงานตามความในวรรคสาม  หรือออกจากราชการหรืองานก่อนครบ
                                            กำหนดเวลาดังกล่าวในวรรคสี่  เป็นเพราะเหตุที่ข้าพเจ้าเจ็บป่วยหรือพิการ  และสำนักงานคณะกรรมการข้าราชการ
                                            พลเรือนได้พิจารณาแล้วเห็นว่า ข้าพเจ้าไม่อาจ หรือไม่สามารถที่จะรับราชการหรือทำงานได้ ข้าพเจ้าจึงจะไม่ต้องรับ
                                            ผิดตามที่ระบุไว้ในวรรคสามหรือวรรคสี่แล้วแต่กรณี
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 4</b> เพื่อเป็นหลักประกันในการปฏิบัติตามสัญญานี้ ข้าพเจ้าจะจัดหาบุคคลที่มีคุณสมบัติซึ่งมหาวิทยาลัย
                                            เห็นสมควรทำสัญญาค้ำประกันข้าพเจ้า ภายในเวลาที่มหาวิทยาลัยกำหนด และในกรณีที่มหาวิทยาลัยเห็นสมควรให้
                                            ข้าพเจ้าเปลี่ยนผู้ค้ำประกันข้าพเจ้าจะปฏิบัติตามทุกประการ
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 5</b> ข้าพเจ้าสมัครใจที่จะเข้าร่วมศึกษาดูงาน หรือฝึกปฏิบัติงานภายนอกคณะแพทยศาสตร์ศิริราชพยาบาล  ซึ่ง
                                            เป็นส่วนงานหนึ่งของมหาวิทยาลัยตามกำหนดของรายวิชาต่าง ๆ ซึ่งอยู่ในหลักสูตร แพทยศาสตรบัณฑิต ทั้งที่มีอยู่ใน
                                            ขณะนี้และที่จะมีขึ้นภายหน้า
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 6</b> ในการศึกษาดูงานหรือปฏิบัติงานตามข้อ 5 ข้าพเจ้าจะประพฤติปฏิบัติตามระเบียบ ข้อบังคับ ประกาศของ
                                            คณะแพทยศาสตร์ศิริราชพยาบาลโดยเคร่งครัด ทั้งจะต้องใช้ความระมัดระวังในการปฏิบัติงานเพื่อให้สำเร็จตาม
                                            จุดมุ่งหมายที่กำหนดไว้  ข้าพเจ้าจะไม่ก่อให้เกิดความเสียหายไม่ว่ากรณีใด ๆ แก่ตัวข้าพเจ้าและบุคคลอื่น
                                            ในการศึกษาดูงานหรือฝึกปฏิบัติงาน ตามความในข้อ 5 หากข้าพเจ้าได้รับความเสียหายไม่ว่าจะเกิดจากการ
                                            กระทำของข้าพเจ้า หรือจากบุคคลอื่นไม่ว่าจะเป็นผลโดยตรง หรือต่อเนื่องหรือที่เกี่ยวข้องกับมหาวิทยาลัยมหิดลข้าพเจ้า
                                            จะมีสิทธิได้รับเพียงเงินสงเคราะห์ สำหรับนักศึกษามหาวิทยาลัยมหิดล และสิทธิประโยชน์จากการประกันอุบัติเหตุที่
                                            ข้าพเจ้าหรือคณะแพทยศาสตร์ศิริราชพยาบาล ได้ทำประกันไว้เท่านั้น
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 7</b> กรณีที่ คณะแพทยศาสตร์ศิริราชพยาบาล ได้ชำระเงินค่าเสียหายแก่บุคคลภายนอกแทนข้าพเจ้า ไม่ว่า
                                            กรณีใดๆ อันเกิดจากการที่ข้าพเจ้าปฏิบัติฝ่าฝืนความในข้อ 6 วรรคแรก ข้าพเจ้ายินยอมรับผิดชดใช้เงินค่าเสียหายคืนแก่
                                            คณะแพทยศาสตร์ศิริราชพยาบาล  พร้อมดอกเบี้ยในอัตราร้อยละ  15 ต่อปี นับจากวันที่คณะแพทยศาสตร์ศิริราชพยาบาล
                                            ได้ชำระเงินให้แก่บุคคลภายนอก นอกจากนี้ข้าพเจ้ายังต้องรับผิดชดใช้ค่าใช้จ่ายต่าง   ๆ อันเป็นผลสืบเนื่องจากการฝ่าฝืน
                                            นั้นด้วย
                                        </p>
                                        <p class='center red-text'>ข้าพเจ้าได้ทราบและเข้าใจข้อความในสัญญาฉบับนี้ดีแล้ว จึงได้ลงนามในสัญญานี้ไว้เป็นหลักฐาน</p>
                                    </div>");

            _string.Append("            <div class='section'>" +
                           "                <div class='right'>" +
                                            _stdNameTh + "  นักศึกษา<br /><br />" +
                                            _signCEO +
                           "                <p>" + _signCEOPosition + "</p>" +
                           "            </div>" +
                           "    </div>" +
                           "</div> <br /><br /><br /><br />");
            //relogin
            //_string.Append("");

            return _string.ToString();
        }
        #endregion SIMDB

        #region SIMDBNEW
        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: SIMDB_Preview
        /// Method : แสดงสัญญา SIMDB พรีวิว
        /// Sample : N/A
        /// </summary>
        public static string Preview_SIMDBNEW(string _acaYear, string _studentId, string _warranty, string _consent, string _studentCode)
        {
            StringBuilder _string = new StringBuilder();
            CurDate _date = new CurDate();
            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
            signCEOinfo _signInfo = new signCEOinfo(_acaYear);
            string _signCEO, _signCEOPosition; ;
            string _fatherName, _motherName;
            string _idCard, _stdNameTh, _birthDate, _age, _moo, _no, _soi, _road, _subdistrict, _district, _provice, _zipcode, _phone, _mobile, _thNationalityName, _warrantyBy;
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
            //_phone = Myconfig.CvEmpty(_stdInfo.Tel, " - ");
            _mobile = Myconfig.CvEmpty(_stdInfo.phoneSTD, " - ");
            _idCard = Myconfig.CvEmpty(_stdInfo.IdCard, " - ");
            _thNationalityName = Myconfig.CvEmpty(_stdInfo.thNationalityName, " - ");


            _fatherName = _parentFInfo.FullNameTh;
            _motherName = _parentMInfo.FullNameTh;
            //_signCEO = Myconfig.GetSignCeoMahidol(_acaYear);
            _signCEO = Myconfig.CvEmpty(_signInfo.signNameCEO, " - ");
            _signCEOPosition = Myconfig.CvEmpty(_signInfo.SignCEOPosition, "-");
            if (_warranty == "F")
            {
                _warrantyBy = _fatherName;
            }
            else if (_warranty == "M")
            {
                _warrantyBy = _motherName;
            }
            else
            {
                _warrantyBy = "บุคคลอื่น";
            }




            _string.Append(@"   <div class='card-panel grey lighten-5'>
                                <div class='grey-text text-darken-4'>
                                    <div class='section'>
                                        <h5 class='center'>
                                            <img src='Images/logo.png' class='circle images' />
                                        </h5>
                                        <p class='center'><b><u>สัญญาการเป็นนักศึกษาเพื่อศึกษาวิชาแพทยศาสตร์</u></b></p>
                                    </div>
                                    <div class='section'>
                                        <div class='right'>
                                            สัญญาทำที่ มหาวิทยาลัยมหิดล<br />");
            _string.Append(@"                   วันที่ <b>" + _date.Day + "</b> เดือน <b>" + _date.MonthNameTh + "</b> พ.ศ. <b>" + _date.YearTh + "</b>");
            _string.Append(@"               </div>
                                    </div>
                                    <br />
                                    <div class='section'>
                                        <p style='text-indent: 4em;'>
                                            โดยที่รัฐบาลมีเจตจำนงมุ่งหมายที่จะให้นักศึกษาหลักสูตรแพทยศาสตรบัณฑิตทุกคนทำงาน
                                            หรือรับราชการ สนองความต้องการของประเทศชาติภายหลังสำเร็จการศึกษาตามหลักสูตรแพทยศาสตรบัณฑิต
                                            และสอบได้ใบอนุญาตเป็นผู้ประกอบวิชาชีพเวชกรรมแล้ว และในการนี้เป็นหน้าที่ของมหาวิทยาลัยมหิดล
                                            และคณะกรรมการพิจารณาจัดสรรนักศึกษาแพทย์ผู้ทำสัญญาการเป็นนักศึกษาแพทย์ (คณะกรรมการพิจารณาจัดสรรนักศึกษาแพทย์ ฯ) 
                                            ซึ่งคณะรัฐมนตรีได้แต่งตั้งขึ้นเพื่อจัดสรรนักศึกษาแพทย์เข้าทำงานหรือรับราชการสนองความต้องการของประเทศชาติที่จะดำเนินการให้สำเร็จผลสมความมุ่งหมายดังกล่าว
                                        </p>
                                    </div>
                                
                                    <div class='section'>
                                        <p style='text-indent: 4em;'>");
            // show student prefile
            _string.Append(@"                   ข้าพเจ้า <span class='indigo-text text-darken-3'><b>" + _stdNameTh + "</b></span>");
            _string.Append(@"                   เชื้อชาติ <span class='indigo-text text-darken-3'><b> - </b></span>");
            _string.Append(@"                   สัญชาติ <span class='indigo-text text-darken-3'><b>" + _thNationalityName + "</b></span>");
            _string.Append(@"                   ศาสนา <span class='indigo-text text-darken-3'><b> - </b></span>");
            _string.Append(@"                   เกิดเมื่อวันที่ ");
            _string.Append(@"                   <span class='indigo-text text-darken-3'><b>" + _birthDate + "</b></span>");
            _string.Append(@"                   อายุ <span class='indigo-text text-darken-3'><b>" + _age + "</b></span> ปี ");
            _string.Append(@"                   ตั้งบ้านเรือนอยู่บ้านเลขที่ <span class='indigo-text text-darken-3'><b>" + _no + "</b></span>");
            _string.Append(@"                   หมู่ที่ <span class='indigo-text text-darken-3'><b>" + _moo + "</b></span>");
            _string.Append(@"                   ตรอก /ซอย <span class='indigo-text text-darken-3'><b>" + _soi + "</b></span>");
            _string.Append(@"                   ถนน <span class='indigo-text text-darken-3'><b>" + _road + " </b></span>");
            _string.Append(@"                   ตำบล /แขวง <span class='indigo-text text-darken-3'><b>" + _subdistrict + "</b></span>");
            _string.Append(@"                   อำเภอ/เขต <span class='indigo-text text-darken-3'><b>" + _district + "</b></span>");
            _string.Append(@"                   จังหวัด <span class='indigo-text text-darken-3'><b>" + _provice + "</b></span>");
            _string.Append(@"                   รหัสไปรษณีย์ <span class='indigo-text text-darken-3'><b>" + _zipcode + "</b></span>");
            _string.Append(@"                   โทรศัพท์  <span class='indigo-text text-darken-3'><b>" + _mobile + "</b></span>");
            _string.Append(@"                   ผู้ถือบัตรประจำตัวประชาชนเลขที่ <span class='indigo-text text-darken-3'><b>" + _idCard + "</b></span>");
            _string.Append(@"                   (ดังปรากฏตามสำเนาบัตรประจำตัวประชาชนแนบท้ายสัญญานี้) ซึ่งต่อไปนี้ในสัญญาเรียกว่า “ผู้ให้สัญญา”
                                            ประสงค์จะเข้าศึกษาหลักสูตรแพทยศาสตรบัณฑิต เพื่อสนองความต้องการของประเทศชาติตามเจตจำนงของรัฐบาลดังกล่าวข้างต้น
                        ");

            _string.Append(@"
                                        </p>
                                    </div>");

            _string.Append(@"           <div class='section'>
                                        <p style='text-indent: 4em;'>");
            _string.Append(@"                   ผู้ให้สัญญาจึงขอทำสัญญาให้ไว้แก่ มหาวิทยาลัยมหิดล โดย " + _signCEO + " ตำแหน่ง " + _signCEOPosition + " ซึ่งต่อไปในสัญญานี้เรียกว่า “มหาวิทยาลัย” มีข้อความดังต่อไปนี้");
            _string.Append(@"               </p>
                                        <p style='text-indent: 4em;'>");
            _string.Append(@"                   ข้อ ๑. ผู้ให้สัญญาตกลงเข้าศึกษาหลักสูตรแพทยศาสตรบัณฑิตที่มหาวิทยาลัยนี้ ตั้งแต่ปีการศึกษา <span class='indigo-text text-darken-3'><b>" + _acaYear +
                                                " </b></span>จนกว่าจะสำเร็จการศึกษาตามหลักสูตรแพทยศาสตรบัณฑิต");

            _string.Append(@"               </p>

                                        <p style='text-indent: 4em;'>
                                            ในระหว่างที่ผู้ให้สัญญาศึกษาหลักสูตรแพทยศาสตรบัณฑิตตามสัญญานี้ ผู้ให้สัญญายินยอมประพฤติและปฏิบัติตามประกาศ ข้อบังคับ 
                                            หรือคำสั่งของมหาวิทยาลัยที่ได้กำหนดหรือสั่งการเกี่ยวกับการเป็นนักศึกษาหลักสูตรแพทยศาสตรบัณฑิต ทั้งที่ได้ออกใช้บังคับอยู่แล้วในขณะที่ลงนามในสัญญานี้ 
                                            และที่จะได้ออกใช้บังคับต่อไปในภายหน้าโดยเคร่งครัด และให้ถือว่าประกาศ ข้อบังคับ หรือคำสั่งต่าง ๆ ดังกล่าวเป็นส่วนหนึ่งของสัญญานี้
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            ข้อ ๒ ในระหว่างที่ผู้ให้สัญญาเข้าศึกษาตามสัญญานี้ ผู้ให้สัญญาจะตั้งใจและเพียรพยายามอย่างดีที่สุดในการศึกษาเล่าเรียน โดยจะไม่หลีกเลี่ยง ละเลย ทอดทิ้ง ยุติ 
                                            หรือเลิกการศึกษาก่อนที่จะสำเร็จการศึกษาตามหลักสูตรแพทยศาสตรบัณฑิต ดังได้ระบุไว้ในข้อ ๑ ของสัญญานี้

                                        </p>

                                        <p style='text-indent: 4em;'>
                                            ข้อ ๓. ภายหลังจากที่สำเร็จการศึกษาตามหลักสูตรแพทยศาสตรบัณฑิต และสอบได้ใบอนุญาตเป็นผู้ประกอบวิชาชีพเวชกรรมแล้ว ผู้ให้สัญญาตกลงยินยอมจะปฏิบัติให้เป็นไปตามคำสั่งของคณะกรรมการ
                                            พิจารณาจัดสรรนักศึกษาแพทย์ ฯ ในการจัดสรรให้ผู้ให้สัญญาเข้ารับการศึกษาอบรมเพิ่มเติม ณ แห่งใด ๆ หรือเข้ารับราชการ หรือทำงานในสถานศึกษา ส่วนราชการ หรือหน่วยงานของรัฐแห่งใดทุกประการ 
                                            และในกรณีที่คณะกรรมการพิจารณาจัดสรรนักศึกษาแพทย์ ฯ สั่งให้ผู้ให้สัญญาเข้ารับราชการหรือทำงาน ผู้ให้สัญญาจะรับราชการหรือทำงานนั้นอยู่ต่อไปเป็นระยะเวลา ๓ (สาม) ปีติดต่อกันไปนับตั้งแต่วันที่ได้กำหนดในคำสั่ง


                                        </p>
                                        <p style='text-indent: 4em;'>
                                            หากภายหลังจากสำเร็จการศึกษาตามหลักสูตรแพทยศาสตรบัณฑิต และสอบได้ใบอนุญาตเป็นผู้ประกอบวิชาชีพเวชกรรมแล้ว และคณะกรรมการพิจารณาจัดสรรนักศึกษาแพทย์ ฯ ได้ให้ผู้ให้สัญญา
                                            เข้ารับการศึกษาอบรมเพิ่มเติมตามความต้องการของกระทรวง ทบวง กรมใดต่อไปอีก เมื่อผู้ให้สัญญาได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ทำการศึกษาอบรมเพิ่มเติมต่อไปจนสำเร็จด้วยเหตุใดก็ดี ผู้ให้สัญญายินยอม
                                            เข้ารับราชการหรือทำงานตามที่คณะกรรมการพิจารณาจัดสรรนักศึกษาแพทย์ ฯ สั่งให้เข้ารับราชการหรือทำงานนั้น โดยจะรับราชการหรือทำงานนั้นอยู่ต่อไปเป็นระยะเวลา ๓ (สาม) ปีติดต่อกันไปนับตั้งแต่วันที่ได้กำหนดในคำสั่ง
                                             แต่ถ้าเป็นการเข้ารับการศึกษาอบรมเพิ่มเติมในระหว่างที่รับราชการหรือทำงานตามคำสั่งในวรรคหนึ่ง เมื่อผู้ให้สัญญาได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ทำการศึกษาอบรมเพิ่มเติมต่อไปจนสำเร็จด้วยเหตุใดก็ดี 
                                            ผู้ให้สัญญาจะยินยอมเข้ารับราชการหรือทำงานต่อไปจนครบกำหนดระยะเวลา ๓ (สาม) ปี ทั้งนี้ โดยไม่นับระยะเวลาระหว่างเข้ารับการศึกษาอบรมเพิ่มเติมรวมคำนวณเข้าด้วยแต่อย่างใด

                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าผู้ให้สัญญาไม่รับราชการหรือทำงานตามที่กล่าวในวรรคหนึ่ง หรือวรรคสอง แล้วแต่กรณี ผู้ให้สัญญายินยอมรับผิดชดใช้เงินเป็นจำนวน<span class='red-text'> ๔๐๐,๐๐๐ บาท (สี่แสนบาทถ้วน)</span> ให้แก่มหาวิทยาลัย
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าผู้ให้สัญญารับราชการหรือทำงานไม่ครบกำหนดเวลาตามที่กล่าวไว้ในวรรคหนึ่ง หรือวรรคสอง แล้วแต่กรณี เงินที่จะชดใช้คืนตามวรรคก่อนจะลดลงตามสัดส่วนของระยะเวลาที่ผู้ให้สัญญารับราชการหรือทำงาน
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าการที่ผู้ให้สัญญามิได้เข้ารับราชการหรือทำงานตามความในวรรคสาม หรือออกจากราชการหรืองานก่อนครบกำหนดเวลาดังกล่าวในวรรคสี่ เป็นเหตุเกิดจากผู้ให้สัญญาเจ็บป่วยหรือพิการ 
                                            หรือมีเหตุอันสมควรอื่น และคณะกรรมการพิจารณาจัดสรรนักศึกษาแพทย์ ฯ และมหาวิทยาลัยได้พิจารณาแล้วเห็นว่าผู้ให้สัญญาไม่สามารถที่จะรับราชการหรือทำงานได้ ผู้ให้สัญญาจึงจะไม่ต้องรับผิดตามที่ระบุไว้ในวรรคสามหรือวรรคสี่ แล้วแต่กรณี
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            เงินที่จะต้องชดใช้ตามสัญญานี้ ผู้ให้สัญญาจะต้องชำระให้แก่มหาวิทยาลัยจนครบถ้วนภายในกำหนดระยะเวลา<span class='red-text'> ๓๐ (สามสิบ) </span>วัน นับถัดจากวันที่ได้รับแจ้งจากมหาวิทยาลัย หากผู้ให้สัญญาไม่ชำระภายในกำหนดระยะเวลาดังกล่าวหรือชำระไม่ครบถ้วน  ผู้ให้สัญญาจะต้องชำระดอกเบี้ยในอัตราร้อยละ<span class='red-text'> ๗.๕ (เจ็ดจุดห้า) </span>ต่อปี ของจำนวนเงินที่ยังมิได้ชำระนับถัดจากวันครบกำหนดระยะเวลาดังกล่าวจนกว่าจะชำระครบถ้วน
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ในกรณีที่ผู้ให้สัญญาสำเร็จการศึกษาตามหลักสูตรแพทยศาสตรบัณฑิต แต่ยังไม่ได้รับใบอนุญาตประกอบวิชาชีพเวชกรรม ผู้ให้สัญญายังคงมีความผูกพันต้องเข้ารับราชการหรือทำงานตามหลักเกณฑ์ ระเบียบ ข้อบังคับ หรือคำสั่งที่คณะกรรมการพิจารณาจัดสรรนักศึกษาแพทย์ ฯ กำหนด ทั้งที่มีอยู่แล้วในวันทำสัญญานี้และที่จะออกใช้บังคับต่อไปในภายหน้าโดยเคร่งครัด และให้ถือว่าหลักเกณฑ์ ระเบียบ ข้อบังคับ หรือคำสั่งดังกล่าวเป็นส่วนหนึ่งของสัญญานี้
                                        </p>");
            _string.Append(@"
                                        <p style='text-indent: 4em;'>
                                            ข้อ ๔. ในวันทำสัญญานี้ ผู้ให้สัญญาได้จัดให้ <span class='indigo-text text-darken-3'><b>" + _warrantyBy + "</b></span> ทำสัญญาค้ำประกันการปฏิบัติและความรับผิดตามสัญญานี้ของผู้ให้สัญญาด้วย");
            _string.Append(@"               </p>
                                        <p style='text-indent: 4em;'>
                                            ในกรณีที่ผู้ค้ำประกันตาย หรือถูกศาลสั่งพิทักษ์ทรัพย์เด็ดขาดหรือพิพากษาให้บุคคลล้มละลาย หรือมหาวิทยาลัยเห็นสมควรให้ผู้สัญญาเปลี่ยนผู้ค้ำประกันในระหว่างอายุประกันตามสัญญานี้ ผู้ให้สัญญาจะต้องจัดให้มีผู้ค้ำประกันใหม่ ภายใน<span class='red-text'> ๓๐ (สามสิบ) </span>วัน นับแต่วันที่ผู้ค้ำประกันเดิมตายหรือถูกพิทักษ์ทรัพย์เด็ดขาด
                                            หรือศาลพิพากษาให้เป็นบุคคลล้มละลาย หรือวันที่ได้รับแจ้งเป็นลายลักษณ์อักษรให้เปลี่ยนผู้ค้ำประกันแล้วแต่กรณี โดยผู้ค้ำประกันรายใหม่จะต้องค้ำประกันตามสัญญาค้ำประกันเดิมทุกประการ
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            สัญญานี้ทำขึ้นเป็นสองฉบับ มีข้อความถูกต้องตรงกัน คู่สัญญาได้อ่านและเข้าใจข้อความ
                                            โดยละเอียดตลอดแล้ว จึงได้ลงลายมือชื่อไว้เป็นสำคัญต่อหน้าพยานและคู่สัญญาต่างยึดถือไว้ฝ่ายละหนึ่งฉบับ
                                        </p>
                                        <p class='center red-text'>ข้าพเจ้าได้ทราบและเข้าใจข้อความในสัญญาฉบับนี้ดีแล้ว จึงได้ลงนามในสัญญานี้ไว้เป็นหลักฐาน</p>
                                    </div>");



            _string.Append("            <div class='section'>" +
                           "                <div class='right'>" +
                                            _stdNameTh + "  ผู้ให้สัญญา<br /><br />" +
                                            _signCEO +
                           "                <p>" + _signCEOPosition + "</p>" +
                           "            </div>" +
                           "        </div>" +
                           "    </div> <br /><br /><br /><br />");

            return _string.ToString();
        }
        #endregion SIMDBNEW
        #region RAMDB
        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: Preview_RAMDB
        /// Method : แสดงสัญญา RAMDB พรีวิว
        /// Sample : N/A
        /// </summary>
        public static string Preview_RAMDB(string _acaYear, string _studentId, string _studentCode)
        {
            StringBuilder _string = new StringBuilder();
            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
            signCEOinfo _signInfo = new signCEOinfo(_acaYear);
            CurDate _date = new CurDate();
            string _signCEO, _signCEOPosition;
            string _fatherName, _motherName;
            string _idCard, _stdNameTh, _birthDate, _age, _moo, _no, _soi, _road, _subdistrict, _district, _provice, _zipcode, _phone, _mobile;
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
            //_phone = Myconfig.CvEmpty(_stdInfo.Tel, " - ");
            _mobile = Myconfig.CvEmpty(_stdInfo.phoneSTD, " - ");
            _idCard = Myconfig.CvEmpty(_stdInfo.IdCard, " - ");


            _fatherName = _parentFInfo.FullNameTh;
            _motherName = _parentMInfo.FullNameTh;
            //_signCEO = Myconfig.GetSignCeoMahidol(_acaYear);
            _signCEO = Myconfig.CvEmpty(_signInfo.signNameCEO, " - ");
            _signCEOPosition = Myconfig.CvEmpty(_signInfo.SignCEOPosition, "-");
            _string.Append(@"   <div class='card-panel grey lighten-5'>
                                <div class='grey-text text-darken-4'>
                                    <div class='section'>
                                        <h5 class='center'>
                                        <img src='Images/logo.png' class='circle images' /></h5>
                                        <p class='center'><b><u>สัญญาการเป็นนักศึกษาเพื่อศึกษาวิชาแพทยศาสตร์</u></b></p>
                                    </div>
                                 <div class='section'>
                                    <div class='right'>
                                        สัญญาทำที่ มหาวิทยาลัยมหิดล<br />");
            _string.Append(@"               วันที่ <b>" + Myconfig._day + "</b> เดือน <b>" + Myconfig._monthstring + "</b> พ.ศ. <b>" + Myconfig._year + "</b>");
            _string.Append(@"           </div>
                                </div>
                                <br />
                                <div class='section'>
                                    <p style='text-indent: 4em;'>
                                        โดยที่รัฐบาลมีเจตจำนงมุ่งหมายที่จะให้นักศึกษาวิชาแพทยศาสตร์ทุกคนทำงาน
                                        หรือรับราชการสนองความต้องการของประเทศชาติภายหลังสำเร็จการศึกษาแล้ว และในการนี้เป็นหน้าที่ของมหาวิทยาลัยมหิดล
                                        สำนักงานคณะกรรมการข้าราชการพลเรือนและคณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาแพทยศาสตร์ ผู้สำเร็จการศึกษาไป
                                        ปฏิบัติงานในส่วนราชการหรือองค์การของรัฐบาลต่างๆ ซึ่งคณะรัฐมนตรีได้หรือจะได้แต่งตั้งขึ้นเพื่อจัดสรรนักศึกษาวิชาแพทยศาสตร์
                                        เข้าทำงานหรือรับราชการสนองความต้องการของประเทศชาติที่จะดำเนินการให้สำเร็จผลสมความมุ่งหมายดังกล่าว
                                    </p>
                                </div>");

            // show student prefile
            _string.Append(@"       <div class='section'>
                                    <p style='text-indent: 4em;'>");
            _string.Append(@"               ข้าพเจ้า <span class='indigo-text text-darken-3'><b>" + _stdNameTh + "</b></span>");
            _string.Append(@"               เกิดเมื่อวันที่ ");
            _string.Append(@"               <span class='indigo-text text-darken-3'><b>" + _birthDate + "</b></span>");
            _string.Append(@"               อายุ <span class='indigo-text text-darken-3'><b>" + _age + "</b></span> ปี ");
            _string.Append(@"               ตั้งบ้านเรือนอยู่บ้านเลขที่ <span class='indigo-text text-darken-3'><b>" + _no + "</b></span>");
            _string.Append(@"               หมู่ที่ <span class='indigo-text text-darken-3'><b>" + _moo + "</b></span>");
            _string.Append(@"               ตรอก /ซอย <span class='indigo-text text-darken-3'><b>" + _soi + "</b></span>");
            _string.Append(@"               ถนน <span class='indigo-text text-darken-3'><b>" + _road + " </b></span>");
            _string.Append(@"               ตำบล /แขวง <span class='indigo-text text-darken-3'><b>" + _subdistrict + "</b></span>");
            _string.Append(@"               อำเภอ/เขต <span class='indigo-text text-darken-3'><b>" + _district + "</b></span>");
            _string.Append(@"               จังหวัด <span class='indigo-text text-darken-3'><b>" + _provice + "</b></span>");
            _string.Append(@"               รหัสไปรษณีย์ <span class='indigo-text text-darken-3'><b>" + _zipcode + "</b></span>");
            _string.Append(@"               โทรศัพท์  <span class='indigo-text text-darken-3'><b>" + _mobile + "</b></span>");
            _string.Append(@"               เลขบัตรประจำตัวประชาชน <span class='indigo-text text-darken-3'><b>" + _idCard + "</b></span>");
            _string.Append(@"               ชื่อบิดา <span class='indigo-text text-darken-3'><b>" + _fatherName + "</b></span>");
            _string.Append(@"               ชื่อมารดา <span class='indigo-text text-darken-3'><b>" + _motherName + "</b></span>");
            _string.Append(@"               เป็นผู้หนึ่งซึ่งประสงค์จะเข้าศึกษาวิชาแพทยศาสตร์เพื่อสนองความต้องการของประเทศชาติ ตามเจตจำนงของรัฐบาล
                                        ดังกล่าวข้างต้น
                                    </p>
                                </div>");

            _string.Append(@"       <div class='section'>
                                    <p class='center red-text'>ข้าพเจ้าจึงขอทำสัญญาให้ไว้แก่มหาวิทยาลัยมหิดล ซึ่งต่อไปในสัญญานี้เรียกว่า “มหาวิทยาลัย” ดังมีข้อความต่อไปนี้</p>
                                    <p style='text-indent: 4em;'>
                                        <b class='deep-purple-text'>ข้อ 1</b> ข้าพเจ้าตกลงเข้าศึกษาวิชาแพทยศาสตร์ที่มหาวิทยาลัยนี้ ตั้งแต่วันที่ทำสัญญาเป็นต้นไป จนกว่าจะสำเร็จการศึกษาตามหลักสูตรแพทยศาสตรบัณฑิต
                                    </p>

                                <p style='text-indent: 4em;'>
                                    ในระหว่างที่ข้าพเจ้าศึกษาวิชาแพทยศาสตร์ตามสัญญานี้ ข้าพเจ้ายินยอมประพฤติและปฏิบัติตามระเบียบ
                                    ข้อบังคับหรือคำสั่งของมหาวิทยาลัยที่ได้กำหนดหรือสั่งการเกี่ยวกับการเป็นนักศึกษาวิชาแพทยศาสตร์ ทั้งที่ได้ออกใช้
                                    บังคับอยู่แล้วก่อนวันที่ข้าพเจ้าลงนามในสัญญานี้ และที่จะได้ออกใช้บังคับต่อไปในภายหน้าโดยเคร่งครัด และให้
                                    ถือว่าระเบียบข้อบังคับหรือคำสั่งต่างๆ ดังกล่าวเป็นส่วนหนึ่งของสัญญานี้ด้วย
                                </p>

                                <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>ข้อ 2</b> ในระหว่างที่ข้าพเจ้าเข้าศึกษาวิชาตามสัญญานี้ ข้าพเจ้าจะตั้งใจและเพียรพยายามอย่างดีที่สุดใน
                                    การศึกษาเล่าเรียน โดยจะไม่หลีกเลี่ยง ละเลย ทอดทิ้ง ยุติ หรือเลิกการศึกษาก่อนสำเร็จการศึกษาตามหลักสูตร ดังได้ระบุ
                                    ไว้ในข้อ 1 ของสัญญานี้
                                </p>

                                <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>ข้อ 3</b> ภายหลังจากที่สำเร็จการศึกษาตามหลักสูตรแล้ว ข้าพเจ้าตกลงยินยอมจะปฏิบัติการให้เป็นไปตามคำสั่ง
                                    ของสำนักงานคณะกรรมการข้าราชการพลเรือน และหรือคณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาแพทยศาสตร์
                                    ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการหรือองค์การของรัฐบาลต่างๆ ในการจัดสรรให้ข้าพเจ้าเข้ารับการศึกษา
                                    อบรมเพิ่มเติม ณ แห่งใด ๆ หรือเข้ารับราชการ หรือทำงานในสถานศึกษา ส่วนราชการหรือองค์การของรัฐบาลแห่ง
                                    ใดทุกประการ และในกรณีที่สำนักงานคณะกรรมการข้าราชการพลเรือน และหรือคณะกรรมการพิจารณาจัดสรร
                                    นักศึกษาวิชาแพทยศาสตร์ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการ หรือองค์การของรัฐบาลต่างๆ สั่งให้ข้าพเจ้า
                                    เข้ารับราชการหรือทำงาน ข้าพเจ้าจะรับราชการหรือทำงานนั้นอยู่ต่อไปเป็นเวลา<b class='red-text'>ไม่น้อยกว่าสามปี</b>ติดต่อกันไป
                                    นับตั้งแต่วันที่ได้กำหนดในคำสั่ง
                                </p>
                                <p style='text-indent: 4em;'>
                                    แต่ถ้าหลังจากสำเร็จการศึกษาตามหลักสูตรแล้ว สำนักงานคณะกรรมการข้าราชการพลเรือน  และหรือ
                                    คณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาแพทยศาสตร์ ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการหรือองค์การ
                                    ของรัฐบาลต่างๆ ได้ให้ข้าพเจ้าเข้ารับการศึกษาอบรมเพิ่มเติมตามความต้องการของกระทรวงทบวงกรมใดต่อไปอีกแล้ว
                                    เมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้วหรือไม่ได้ทำการศึกษาอบรมเพิ่มเติมต่อไปจนสำเร็จด้วยเหตุใดก็ดี
                                    ข้าพเจ้ายินยอมเข้ารับราชการหรือทำงานตามที่สำนักงานคณะกรรมการข้าราชการพลเรือน และหรือ
                                    คณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาแพทยศาสตร์ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการหรือองค์การของ
                                    รัฐบาลต่างๆ สั่งให้เข้ารับราชการหรือทำงานนั้น โดยจะรับราชการหรือทำงานนั้นอยู่ต่อไปเป็นเวลา<b class='red-text'>ไม่น้อยกว่าสามปี</b>
                                    ติดต่อกันไปนับตั้งแต่วันที่ได้กำหนดในคำสั่ง แต่ถ้าเป็นการเข้ารับการศึกษาอบรมเพิ่มเติมในระหว่างที่รับราชการหรือ
                                    ทำงานตามคำสั่งในวรรคแรก เมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ทำการศึกษาอบรมเพิ่มเติมต่อไป
                                    จนสำเร็จด้วยเหตุใดก็ดี ข้าพเจ้าจะยินยอมเข้ารับราชการหรือทำงานต่อไปจนครบกำหนดระยะเวลา<b class='red-text'>ไม่น้อยกว่าสามปี</b>
                                    ทั้งนี้ ไม่นับระยะเวลาระหว่างเข้ารับการศึกษาอบรมเพิ่มเติมรวมคำนวณเข้าด้วย
                                </p>
                                <p style='text-indent: 4em;'>
                                    ถ้าข้าพเจ้าไม่รับราชการ หรือทำงานตามที่กล่าวในวรรคแรก หรือวรรคสองแล้วแต่กรณี ข้าพเจ้ายินยอมรับผิด
                                    ชดใช้เงินให้แก่มหาวิทยาลัยเป็น<span class='red-text'>จำนวน 400,000 บาท (สี่แสนบาทถ้วน)</span> ภายในกำหนดเวลาที่มหาวิทยาลัย
                                    เรียกร้องให้ชำระ
                                </p>
                                <p style='text-indent: 4em;'>
                                    ถ้าข้าพเจ้ารับราชการ หรือทำงานไม่ครบกำหนดเวลาตามที่กล่าวไว้ในวรรคแรกหรือวรรคสอง  แล้วแต่กรณี
                                    ข้าพเจ้ายินยอมรับผิดชดใช้เงินให้แก่มหาวิทยาลัยตามระยะเวลาที่ขาด  โดยคิดคำนวณลดลงตามส่วนเฉลี่ยจากจำนวนเงิน
                                    ที่ต้องชดใช้ในวรรคก่อน
                                </p>
                                <p style='text-indent: 4em;'>
                                    ถ้าการที่ข้าพเจ้ามิได้เข้ารับราชการหรือทำงานตามความในวรรคสาม  หรือออกจากราชการหรืองานก่อนครบ
                                    กำหนดเวลาดังกล่าวในวรรคสี่  เป็นเพราะเหตุที่ข้าพเจ้าเจ็บป่วยหรือพิการ  และสำนักงานคณะกรรมการข้าราชการ
                                    พลเรือนได้พิจารณาแล้วเห็นว่า ข้าพเจ้าไม่อาจ หรือไม่สามารถที่จะรับราชการหรือทำงานได้ ข้าพเจ้าจึงจะไม่ต้องรับ
                                    ผิดตามที่ระบุไว้ในวรรคสามหรือวรรคสี่แล้วแต่กรณี
                                </p>
                                <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>ข้อ 4</b> เพื่อเป็นหลักประกันในการปฏิบัติตามสัญญานี้ ข้าพเจ้าจะจัดหาบุคคลที่มีคุณสมบัติซึ่งมหาวิทยาลัย
                                    เห็นสมควรทำสัญญาค้ำประกันข้าพเจ้า ภายในเวลาที่มหาวิทยาลัยกำหนด และในกรณีที่มหาวิทยาลัยเห็นสมควรให้
                                    ข้าพเจ้าเปลี่ยนผู้ค้ำประกันข้าพเจ้าจะปฏิบัติตามทุกประการ
                                </p>
                                <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>ข้อ 5</b> ข้าพเจ้าสมัครใจที่จะเข้าร่วมศึกษาดูงาน หรือฝึกปฏิบัติงานภายนอกคณะแพทยศาสตร์โรงพยาบาลรามาธิบดี  ซึ่ง
                                    เป็นส่วนงานหนึ่งของมหาวิทยาลัยตามกำหนดของรายวิชาต่าง ๆ ซึ่งอยู่ในหลักสูตร แพทยศาสตรบัณฑิต ทั้งที่มีอยู่ใน
                                    ขณะนี้และที่จะมีขึ้นภายหน้า
                                </p>

                                <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>ข้อ 6</b> ในการศึกษาดูงานหรือปฏิบัติงานตามข้อ 5 ข้าพเจ้าจะประพฤติปฏิบัติตามระเบียบ ข้อบังคับ ประกาศของ
                                    คณะแพทยศาสตร์โรงพยาบาลรามาธิบดีโดยเคร่งครัด ทั้งจะต้องใช้ความระมัดระวังในการปฏิบัติงานเพื่อให้สำเร็จตาม
                                    จุดมุ่งหมายที่กำหนดไว้  ข้าพเจ้าจะไม่ก่อให้เกิดความเสียหายไม่ว่ากรณีใด ๆ แก่ตัวข้าพเจ้าและบุคคลอื่น
                                    ในการศึกษาดูงานหรือฝึกปฏิบัติงาน ตามความในข้อ 5 หากข้าพเจ้าได้รับความเสียหายไม่ว่าจะเกิดจากการ
                                    กระทำของข้าพเจ้า หรือจากบุคคลอื่นไม่ว่าจะเป็นผลโดยตรง หรือต่อเนื่องหรือที่เกี่ยวข้องกับมหาวิทยาลัยมหิดลข้าพเจ้า
                                    จะมีสิทธิได้รับเพียงเงินสงเคราะห์ สำหรับนักศึกษามหาวิทยาลัยมหิดล และสิทธิประโยชน์จากการประกันอุบัติเหตุที่
                                    ข้าพเจ้าหรือคณะคณะแพทยศาสตร์โรงพยาบาลรามาธิบดี ได้ทำประกันไว้เท่านั้น
                                </p>
                                <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>ข้อ 7</b> กรณีที่ คณะแพทยศาสตร์โรงพยาบาลรามาธิบดี ได้ชำระเงินค่าเสียหายแก่บุคคลภายนอกแทนข้าพเจ้า ไม่ว่า
                                    กรณีใดๆ อันเกิดจากการที่ข้าพเจ้าปฏิบัติฝ่าฝืนความในข้อ 6 วรรคแรก ข้าพเจ้ายินยอมรับผิดชดใช้เงินค่าเสียหายคืนแก่
                                    คณะแพทยศาสตร์โรงพยาบาลรามาธิบดี  พร้อมดอกเบี้ยในอัตราร้อยละ 15 ต่อปี นับจากวันที่คณะแพทยศาสตร์โรงพยาบาลรามาธิบดี
                                    ได้ชำระเงินให้แก่บุคคลภายนอก นอกจากนี้ข้าพเจ้ายังต้องรับผิดชดใช้ค่าใช้จ่ายต่างๆ อันเป็นผลสืบเนื่องจากการฝ่าฝืน
                                    นั้นด้วย
                                </p>
                                <p class='center red-text'>ข้าพเจ้าได้ทราบและเข้าใจข้อความในสัญญาฉบับนี้ดีแล้ว จึงได้ลงนามในสัญญานี้ไว้เป็นหลักฐาน</p>
                            </div>");


            _string.Append("            <div class='section'>" +
                           "                <div class='right'>" +
                                            _stdNameTh + "  นักศึกษา<br /><br />" +
                                            _signCEO +
                           "                <p>" + _signCEOPosition + "</p>" +
                           "            </div>" +
                           "    </div>" +
                           "</div> <br /><br /><br /><br />");
            return _string.ToString();
        }
        #endregion RAMDB

        #region RAMDBNEW
        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: SIMDB_Preview
        /// Method : แสดงสัญญา SIMDB พรีวิว
        /// Sample : N/A
        /// </summary>
        public static string Preview_RAMDBNEW(string _acaYear, string _studentId, string _warranty, string _consent, string _studentCode)
        {
            StringBuilder _string = new StringBuilder();
            CurDate _date = new CurDate();
            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
            signCEOinfo _signInfo = new signCEOinfo(_acaYear);
            string _signCEO, _signCEOPosition; ;
            string _fatherName, _motherName;
            string _idCard, _stdNameTh, _birthDate, _age, _moo, _no, _soi, _road, _subdistrict, _district, _provice, _zipcode, _phone, _mobile, _thNationalityName, _warrantyBy;
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
            //_phone = Myconfig.CvEmpty(_stdInfo.Tel, " - ");
            _mobile = Myconfig.CvEmpty(_stdInfo.phoneSTD, " - ");
            _idCard = Myconfig.CvEmpty(_stdInfo.IdCard, " - ");
            _thNationalityName = Myconfig.CvEmpty(_stdInfo.thNationalityName, " - ");


            _fatherName = _parentFInfo.FullNameTh;
            _motherName = _parentMInfo.FullNameTh;
            //_signCEO = Myconfig.GetSignCeoMahidol(_acaYear);
            _signCEO = Myconfig.CvEmpty(_signInfo.signNameCEO, " - ");
            _signCEOPosition = Myconfig.CvEmpty(_signInfo.SignCEOPosition, "-");
            if (_warranty == "F")
            {
                _warrantyBy = _fatherName;
            }
            else if (_warranty == "M")
            {
                _warrantyBy = _motherName;
            }
            else
            {
                _warrantyBy = "บุคคลอื่น";
            }




            _string.Append(@"   <div class='card-panel grey lighten-5'>
                                <div class='grey-text text-darken-4'>
                                    <div class='section'>
                                        <h5 class='center'>
                                            <img src='Images/logo.png' class='circle images' />
                                        </h5>
                                        <p class='center'><b><u>สัญญาการเป็นนักศึกษาเพื่อศึกษาวิชาแพทยศาสตร์</u></b></p>
                                    </div>
                                    <div class='section'>
                                        <div class='right'>
                                            สัญญาทำที่ มหาวิทยาลัยมหิดล<br />");
            _string.Append(@"                   วันที่ <b>" + _date.Day + "</b> เดือน <b>" + _date.MonthNameTh + "</b> พ.ศ. <b>" + _date.YearTh + "</b>");
            _string.Append(@"               </div>
                                    </div>
                                    <br />
                                    <div class='section'>
                                        <p style='text-indent: 4em;'>
                                            โดยที่รัฐบาลมีเจตจำนงมุ่งหมายที่จะให้นักศึกษาหลักสูตรแพทยศาสตรบัณฑิตทุกคนทำงาน
                                            หรือรับราชการ สนองความต้องการของประเทศชาติภายหลังสำเร็จการศึกษาตามหลักสูตรแพทยศาสตรบัณฑิต
                                            และสอบได้ใบอนุญาตเป็นผู้ประกอบวิชาชีพเวชกรรมแล้ว และในการนี้เป็นหน้าที่ของมหาวิทยาลัยมหิดล
                                            และคณะกรรมการพิจารณาจัดสรรนักศึกษาแพทย์ผู้ทำสัญญาการเป็นนักศึกษาแพทย์ (คณะกรรมการพิจารณาจัดสรรนักศึกษาแพทย์ ฯ) 
                                            ซึ่งคณะรัฐมนตรีได้แต่งตั้งขึ้นเพื่อจัดสรรนักศึกษาแพทย์เข้าทำงานหรือรับราชการสนองความต้องการของประเทศชาติที่จะดำเนินการให้สำเร็จผลสมความมุ่งหมายดังกล่าว
                                        </p>
                                    </div>
                                
                                    <div class='section'>
                                        <p style='text-indent: 4em;'>");
            // show student prefile
            _string.Append(@"                   ข้าพเจ้า <span class='indigo-text text-darken-3'><b>" + _stdNameTh + "</b></span>");
            _string.Append(@"                   เชื้อชาติ <span class='indigo-text text-darken-3'><b> - </b></span>");
            _string.Append(@"                   สัญชาติ <span class='indigo-text text-darken-3'><b>" + _thNationalityName + "</b></span>");
            _string.Append(@"                   ศาสนา <span class='indigo-text text-darken-3'><b> - </b></span>");
            _string.Append(@"                   เกิดเมื่อวันที่ ");
            _string.Append(@"                   <span class='indigo-text text-darken-3'><b>" + _birthDate + "</b></span>");
            _string.Append(@"                   อายุ <span class='indigo-text text-darken-3'><b>" + _age + "</b></span> ปี ");
            _string.Append(@"                   ตั้งบ้านเรือนอยู่บ้านเลขที่ <span class='indigo-text text-darken-3'><b>" + _no + "</b></span>");
            _string.Append(@"                   หมู่ที่ <span class='indigo-text text-darken-3'><b>" + _moo + "</b></span>");
            _string.Append(@"                   ตรอก /ซอย <span class='indigo-text text-darken-3'><b>" + _soi + "</b></span>");
            _string.Append(@"                   ถนน <span class='indigo-text text-darken-3'><b>" + _road + " </b></span>");
            _string.Append(@"                   ตำบล /แขวง <span class='indigo-text text-darken-3'><b>" + _subdistrict + "</b></span>");
            _string.Append(@"                   อำเภอ/เขต <span class='indigo-text text-darken-3'><b>" + _district + "</b></span>");
            _string.Append(@"                   จังหวัด <span class='indigo-text text-darken-3'><b>" + _provice + "</b></span>");
            _string.Append(@"                   รหัสไปรษณีย์ <span class='indigo-text text-darken-3'><b>" + _zipcode + "</b></span>");
            _string.Append(@"                   โทรศัพท์  <span class='indigo-text text-darken-3'><b>" + _mobile + "</b></span>");
            _string.Append(@"                   ผู้ถือบัตรประจำตัวประชาชนเลขที่ <span class='indigo-text text-darken-3'><b>" + _idCard + "</b></span>");
            _string.Append(@"                   (ดังปรากฏตามสำเนาบัตรประจำตัวประชาชนแนบท้ายสัญญานี้) ซึ่งต่อไปนี้ในสัญญาเรียกว่า “ผู้ให้สัญญา”
                                            ประสงค์จะเข้าศึกษาหลักสูตรแพทยศาสตรบัณฑิต เพื่อสนองความต้องการของประเทศชาติตามเจตจำนงของรัฐบาลดังกล่าวข้างต้น
                        ");

            _string.Append(@"
                                        </p>
                                    </div>");

            _string.Append(@"           <div class='section'>
                                        <p style='text-indent: 4em;'>");
            _string.Append(@"                   ผู้ให้สัญญาจึงขอทำสัญญาให้ไว้แก่ มหาวิทยาลัยมหิดล โดย " + _signCEO + " ตำแหน่ง " + _signCEOPosition + " ซึ่งต่อไปในสัญญานี้เรียกว่า “มหาวิทยาลัย” มีข้อความดังต่อไปนี้");
            _string.Append(@"               </p>
                                        <p style='text-indent: 4em;'>");
            _string.Append(@"                   ข้อ ๑. ผู้ให้สัญญาตกลงเข้าศึกษาหลักสูตรแพทยศาสตรบัณฑิตที่มหาวิทยาลัยนี้ ตั้งแต่ปีการศึกษา <span class='indigo-text text-darken-3'><b>" + _acaYear +
                                                " </b></span>จนกว่าจะสำเร็จการศึกษาตามหลักสูตรแพทยศาสตรบัณฑิต");

            _string.Append(@"               </p>

                                        <p style='text-indent: 4em;'>
                                            ในระหว่างที่ผู้ให้สัญญาศึกษาหลักสูตรแพทยศาสตรบัณฑิตตามสัญญานี้ ผู้ให้สัญญายินยอมประพฤติและปฏิบัติตามประกาศ ข้อบังคับ 
                                            หรือคำสั่งของมหาวิทยาลัยที่ได้กำหนดหรือสั่งการเกี่ยวกับการเป็นนักศึกษาหลักสูตรแพทยศาสตรบัณฑิต ทั้งที่ได้ออกใช้บังคับอยู่แล้วในขณะที่ลงนามในสัญญานี้ 
                                            และที่จะได้ออกใช้บังคับต่อไปในภายหน้าโดยเคร่งครัด และให้ถือว่าประกาศ ข้อบังคับ หรือคำสั่งต่าง ๆ ดังกล่าวเป็นส่วนหนึ่งของสัญญานี้
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            ข้อ ๒ ในระหว่างที่ผู้ให้สัญญาเข้าศึกษาตามสัญญานี้ ผู้ให้สัญญาจะตั้งใจและเพียรพยายามอย่างดีที่สุดในการศึกษาเล่าเรียน โดยจะไม่หลีกเลี่ยง ละเลย ทอดทิ้ง ยุติ 
                                            หรือเลิกการศึกษาก่อนที่จะสำเร็จการศึกษาตามหลักสูตรแพทยศาสตรบัณฑิต ดังได้ระบุไว้ในข้อ ๑ ของสัญญานี้

                                        </p>

                                        <p style='text-indent: 4em;'>
                                            ข้อ ๓. ภายหลังจากที่สำเร็จการศึกษาตามหลักสูตรแพทยศาสตรบัณฑิต และสอบได้ใบอนุญาตเป็นผู้ประกอบวิชาชีพเวชกรรมแล้ว ผู้ให้สัญญาตกลงยินยอมจะปฏิบัติให้เป็นไปตามคำสั่งของคณะกรรมการ
                                            พิจารณาจัดสรรนักศึกษาแพทย์ ฯ ในการจัดสรรให้ผู้ให้สัญญาเข้ารับการศึกษาอบรมเพิ่มเติม ณ แห่งใด ๆ หรือเข้ารับราชการ หรือทำงานในสถานศึกษา ส่วนราชการ หรือหน่วยงานของรัฐแห่งใดทุกประการ 
                                            และในกรณีที่คณะกรรมการพิจารณาจัดสรรนักศึกษาแพทย์ ฯ สั่งให้ผู้ให้สัญญาเข้ารับราชการหรือทำงาน ผู้ให้สัญญาจะรับราชการหรือทำงานนั้นอยู่ต่อไปเป็นระยะเวลา ๓ (สาม) ปีติดต่อกันไปนับตั้งแต่วันที่ได้กำหนดในคำสั่ง


                                        </p>
                                        <p style='text-indent: 4em;'>
                                            หากภายหลังจากสำเร็จการศึกษาตามหลักสูตรแพทยศาสตรบัณฑิต และสอบได้ใบอนุญาตเป็นผู้ประกอบวิชาชีพเวชกรรมแล้ว และคณะกรรมการพิจารณาจัดสรรนักศึกษาแพทย์ ฯ ได้ให้ผู้ให้สัญญา
                                            เข้ารับการศึกษาอบรมเพิ่มเติมตามความต้องการของกระทรวง ทบวง กรมใดต่อไปอีก เมื่อผู้ให้สัญญาได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ทำการศึกษาอบรมเพิ่มเติมต่อไปจนสำเร็จด้วยเหตุใดก็ดี ผู้ให้สัญญายินยอม
                                            เข้ารับราชการหรือทำงานตามที่คณะกรรมการพิจารณาจัดสรรนักศึกษาแพทย์ ฯ สั่งให้เข้ารับราชการหรือทำงานนั้น โดยจะรับราชการหรือทำงานนั้นอยู่ต่อไปเป็นระยะเวลา ๓ (สาม) ปีติดต่อกันไปนับตั้งแต่วันที่ได้กำหนดในคำสั่ง
                                             แต่ถ้าเป็นการเข้ารับการศึกษาอบรมเพิ่มเติมในระหว่างที่รับราชการหรือทำงานตามคำสั่งในวรรคหนึ่ง เมื่อผู้ให้สัญญาได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ทำการศึกษาอบรมเพิ่มเติมต่อไปจนสำเร็จด้วยเหตุใดก็ดี 
                                            ผู้ให้สัญญาจะยินยอมเข้ารับราชการหรือทำงานต่อไปจนครบกำหนดระยะเวลา ๓ (สาม) ปี ทั้งนี้ โดยไม่นับระยะเวลาระหว่างเข้ารับการศึกษาอบรมเพิ่มเติมรวมคำนวณเข้าด้วยแต่อย่างใด

                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าผู้ให้สัญญาไม่รับราชการหรือทำงานตามที่กล่าวในวรรคหนึ่ง หรือวรรคสอง แล้วแต่กรณี ผู้ให้สัญญายินยอมรับผิดชดใช้เงินเป็นจำนวน<span class='red-text'> ๔๐๐,๐๐๐ บาท (สี่แสนบาทถ้วน)</span> ให้แก่มหาวิทยาลัย
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าผู้ให้สัญญารับราชการหรือทำงานไม่ครบกำหนดเวลาตามที่กล่าวไว้ในวรรคหนึ่ง หรือวรรคสอง แล้วแต่กรณี เงินที่จะชดใช้คืนตามวรรคก่อนจะลดลงตามสัดส่วนของระยะเวลาที่ผู้ให้สัญญารับราชการหรือทำงาน
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าการที่ผู้ให้สัญญามิได้เข้ารับราชการหรือทำงานตามความในวรรคสาม หรือออกจากราชการหรืองานก่อนครบกำหนดเวลาดังกล่าวในวรรคสี่ เป็นเหตุเกิดจากผู้ให้สัญญาเจ็บป่วยหรือพิการ 
                                            หรือมีเหตุอันสมควรอื่น และคณะกรรมการพิจารณาจัดสรรนักศึกษาแพทย์ ฯ และมหาวิทยาลัยได้พิจารณาแล้วเห็นว่าผู้ให้สัญญาไม่สามารถที่จะรับราชการหรือทำงานได้ ผู้ให้สัญญาจึงจะไม่ต้องรับผิดตามที่ระบุไว้ในวรรคสามหรือวรรคสี่ แล้วแต่กรณี
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            เงินที่จะต้องชดใช้ตามสัญญานี้ ผู้ให้สัญญาจะต้องชำระให้แก่มหาวิทยาลัยจนครบถ้วนภายในกำหนดระยะเวลา<span class='red-text'> ๓๐ (สามสิบ) </span>วัน นับถัดจากวันที่ได้รับแจ้งจากมหาวิทยาลัย หากผู้ให้สัญญาไม่ชำระภายในกำหนดระยะเวลาดังกล่าวหรือชำระไม่ครบถ้วน  ผู้ให้สัญญาจะต้องชำระดอกเบี้ยในอัตราร้อยละ<span class='red-text'> ๗.๕ (เจ็ดจุดห้า) </span>ต่อปี ของจำนวนเงินที่ยังมิได้ชำระนับถัดจากวันครบกำหนดระยะเวลาดังกล่าวจนกว่าจะชำระครบถ้วน
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ในกรณีที่ผู้ให้สัญญาสำเร็จการศึกษาตามหลักสูตรแพทยศาสตรบัณฑิต แต่ยังไม่ได้รับใบอนุญาตประกอบวิชาชีพเวชกรรม ผู้ให้สัญญายังคงมีความผูกพันต้องเข้ารับราชการหรือทำงานตามหลักเกณฑ์ ระเบียบ ข้อบังคับ หรือคำสั่งที่คณะกรรมการพิจารณาจัดสรรนักศึกษาแพทย์ ฯ กำหนด ทั้งที่มีอยู่แล้วในวันทำสัญญานี้และที่จะออกใช้บังคับต่อไปในภายหน้าโดยเคร่งครัด และให้ถือว่าหลักเกณฑ์ ระเบียบ ข้อบังคับ หรือคำสั่งดังกล่าวเป็นส่วนหนึ่งของสัญญานี้
                                        </p>");
            _string.Append(@"
                                        <p style='text-indent: 4em;'>
                                            ข้อ ๔. ในวันทำสัญญานี้ ผู้ให้สัญญาได้จัดให้ <span class='indigo-text text-darken-3'><b>" + _warrantyBy + "</b></span> ทำสัญญาค้ำประกันการปฏิบัติและความรับผิดตามสัญญานี้ของผู้ให้สัญญาด้วย");
            _string.Append(@"               </p>
                                        <p style='text-indent: 4em;'>
                                            ในกรณีที่ผู้ค้ำประกันตาย หรือถูกศาลสั่งพิทักษ์ทรัพย์เด็ดขาดหรือพิพากษาให้บุคคลล้มละลาย หรือมหาวิทยาลัยเห็นสมควรให้ผู้สัญญาเปลี่ยนผู้ค้ำประกันในระหว่างอายุประกันตามสัญญานี้ ผู้ให้สัญญาจะต้องจัดให้มีผู้ค้ำประกันใหม่ ภายใน<span class='red-text'> ๓๐ (สามสิบ) </span>วัน นับแต่วันที่ผู้ค้ำประกันเดิมตายหรือถูกพิทักษ์ทรัพย์เด็ดขาด
                                            หรือศาลพิพากษาให้เป็นบุคคลล้มละลาย หรือวันที่ได้รับแจ้งเป็นลายลักษณ์อักษรให้เปลี่ยนผู้ค้ำประกันแล้วแต่กรณี โดยผู้ค้ำประกันรายใหม่จะต้องค้ำประกันตามสัญญาค้ำประกันเดิมทุกประการ
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            สัญญานี้ทำขึ้นเป็นสองฉบับ มีข้อความถูกต้องตรงกัน คู่สัญญาได้อ่านและเข้าใจข้อความ
                                            โดยละเอียดตลอดแล้ว จึงได้ลงลายมือชื่อไว้เป็นสำคัญต่อหน้าพยานและคู่สัญญาต่างยึดถือไว้ฝ่ายละหนึ่งฉบับ
                                        </p>
                                        <p class='center red-text'>ข้าพเจ้าได้ทราบและเข้าใจข้อความในสัญญาฉบับนี้ดีแล้ว จึงได้ลงนามในสัญญานี้ไว้เป็นหลักฐาน</p>
                                    </div>");



            _string.Append("            <div class='section'>" +
                           "                <div class='right'>" +
                                            _stdNameTh + "  ผู้ให้สัญญา<br /><br />" +
                                            _signCEO +
                           "                <p>" + _signCEOPosition + "</p>" +
                           "            </div>" +
                           "        </div>" +
                           "    </div> <br /><br /><br /><br />");

            return _string.ToString();
        }
        #endregion RAMDBNEW

        #region DTDSBOLD
        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: Preview_DTDSB
        /// Method : แสดงสัญญา DTDSB พรีวิว
        /// Sample : N/A
        /// </summary>
        public static string Preview_DTDSB(string _acaYear, string _studentId, string _studentCode)
        {
            StringBuilder _string = new StringBuilder();
            CurDate _date = new CurDate();
            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
            signCEOinfo _signInfo = new signCEOinfo(_acaYear);
            string _signCEO, _signCEOPosition; ;
            string _fatherName, _motherName;
            string _idCard, _stdNameTh, _birthDate, _age, _moo, _no, _soi, _road, _subdistrict, _district, _provice, _zipcode, _phone, _mobile;
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
            //_phone = Myconfig.CvEmpty(_stdInfo.Tel, " - ");
            _mobile = Myconfig.CvEmpty(_stdInfo.phoneSTD, " - ");
            _idCard = Myconfig.CvEmpty(_stdInfo.IdCard, " - ");


            _fatherName = _parentFInfo.FullNameTh;
            _motherName = _parentMInfo.FullNameTh;
            //_signCEO = Myconfig.GetSignCeoMahidol(_acaYear);
            _signCEO = Myconfig.CvEmpty(_signInfo.signNameCEO, " - ");
            _signCEOPosition = Myconfig.CvEmpty(_signInfo.SignCEOPosition, "-");


            _string.Append(@"   <div class='card-panel grey lighten-5'>
                                <div class='grey-text text-darken-4'>
                                    <div class='section'>
                                        <h5 class='center'>
                                            <img src='Images/logo.png' class='circle images' /></h5>
                                            <p class='center'><b><u>สัญญาการเป็นนักศึกษาเพื่อศึกษาวิชาทันตแพทยศาสตร์</u></b></p>
                                    </div>
                                    <div class='section'>
                                        <div class='right'>
                                            สัญญาทำที่ มหาวิทยาลัยมหิดล<br />");
            _string.Append(@"                   วันที่ <b>" + _date.Day + "</b> เดือน <b>" + _date.MonthNameTh + "</b> พ.ศ. <b>" + _date.YearTh + "</b>");
            _string.Append(@"               </div>
                                    </div>
                                    <br />
                                    <div class='section'>
                                        <p style='text-indent: 4em;'>
                                            โดยที่รัฐบาลมีเจตจำนงมุ่งหมายที่จะให้นักศึกษาวิชาทันตแพทยศาสตร์ทุกคนทำงาน
                                            หรือรับราชการสนองความต้องการของประเทศชาติภายหลังสำเร็จการศึกษาแล้ว และในการนี้เป็นหน้าที่ของมหาวิทยาลัยมหิดล
                                            สำนักงานคณะกรรมการข้าราชการพลเรือนและคณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาทันตแพทยศาสตร์ ผู้สำเร็จการศึกษาไป
                                            ปฏิบัติงานในส่วนราชการหรือองค์การของรัฐบาลต่างๆ ซึ่งคณะรัฐมนตรีได้หรือจะได้แต่งตั้งขึ้นเพื่อจัดสรรนักศึกษาวิชาทันตแพทยศาสตร์
                                            เข้าทำงานหรือรับราชการสนองความต้องการของประเทศชาติที่จะดำเนินการให้สำเร็จผลสมความมุ่งหมายดังกล่าว
                                        </p>
                                    </div>");




            // show student prefile
            _string.Append(@"           <div class='section'>
                                        <p style='text-indent: 4em;'>");
            _string.Append(@"                   ข้าพเจ้า <span class='indigo-text text-darken-3'><b>" + _stdNameTh + "</b></span>");
            _string.Append(@"                   เกิดเมื่อวันที่ ");
            _string.Append(@"                   <span class='indigo-text text-darken-3'><b>" + _birthDate + "</b></span>");
            _string.Append(@"                   อายุ <span class='indigo-text text-darken-3'><b>" + _age + "</b></span> ปี ");
            _string.Append(@"                   ตั้งบ้านเรือนอยู่บ้านเลขที่ <span class='indigo-text text-darken-3'><b>" + _no + "</b></span>");
            _string.Append(@"                   หมู่ที่ <span class='indigo-text text-darken-3'><b>" + _moo + "</b></span>");
            _string.Append(@"                   ตรอก /ซอย <span class='indigo-text text-darken-3'><b>" + _soi + "</b></span>");
            _string.Append(@"                   ถนน <span class='indigo-text text-darken-3'><b>" + _road + " </b></span>");
            _string.Append(@"                   ตำบล /แขวง <span class='indigo-text text-darken-3'><b>" + _subdistrict + "</b></span>");
            _string.Append(@"                   อำเภอ/เขต <span class='indigo-text text-darken-3'><b>" + _district + "</b></span>");
            _string.Append(@"                   จังหวัด <span class='indigo-text text-darken-3'><b>" + _provice + "</b></span>");
            _string.Append(@"                   รหัสไปรษณีย์ <span class='indigo-text text-darken-3'><b>" + _zipcode + "</b></span>");
            _string.Append(@"                   โทรศัพท์  <span class='indigo-text text-darken-3'><b>" + _mobile + "</b></span>");
            _string.Append(@"                   เลขบัตรประจำตัวประชาชน <span class='indigo-text text-darken-3'><b>" + _idCard + "</b></span>");
            _string.Append(@"                   ชื่อบิดา <span class='indigo-text text-darken-3'><b>" + _fatherName + "</b></span>");
            _string.Append(@"                   ชื่อมารดา <span class='indigo-text text-darken-3'><b>" + _motherName + "</b></span>");
            _string.Append(@"                   เป็นผู้หนึ่งซึ่งประสงค์จะเข้าศึกษาวิชาทันตแพทยศาสตร์เพื่อสนองความต้องการของประเทศชาติ ตามเจตจำนงของรัฐบาล
                                            ดังกล่าวข้างต้น
                                        </p>
                                    </div>");

            _string.Append(@"           <div class='section'>
                                        <p class='center red-text'>ข้าพเจ้าจึงขอทำสัญญาให้ไว้แก่มหาวิทยาลัยมหิดล ซึ่งต่อไปในสัญญานี้เรียกว่า “มหาวิทยาลัย” ดังมีข้อความต่อไปนี้</p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 1</b> ข้าพเจ้าตกลงเข้าศึกษาวิชาทันตแพทยศาสตร์ที่มหาวิทยาลัยนี้ ตั้งแต่วันที่ทำสัญญาเป็นต้นไป จนกว่าจะสำเร็จการศึกษาตามหลักสูตรทันตแพทยศาสตรบัณฑิต
                                        </p>

                                         <p style='text-indent: 4em;'>
                                            ในระหว่างที่ข้าพเจ้าศึกษาวิชาทันตแพทยศาสตร์ตามสัญญานี้ ข้าพเจ้ายินยอมประพฤติและปฏิบัติตามระเบียบ
                                            ข้อบังคับหรือคำสั่งของมหาวิทยาลัยที่ได้กำหนดหรือสั่งการเกี่ยวกับการเป็นนักศึกษาวิชาทันตแพทยศาสตร์ ทั้งที่ได้ออกใช้
                                            บังคับอยู่แล้วก่อนวันที่ข้าพเจ้าลงนามในสัญญานี้ และที่จะได้ออกใช้บังคับต่อไปในภายหน้าโดยเคร่งครัด และให้
                                            ถือว่าระเบียบข้อบังคับหรือคำสั่งต่างๆ ดังกล่าวเป็นส่วนหนึ่งของสัญญานี้ด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 2</b> ในระหว่างที่ข้าพเจ้าเข้าศึกษาวิชาตามสัญญานี้ ข้าพเจ้าจะตั้งใจและเพียรพยายามอย่างดีที่สุดใน
                                            การศึกษาเล่าเรียน โดยจะไม่หลีกเลี่ยง ละเลย ทอดทิ้ง ยุติ หรือเลิกการศึกษาก่อนสำเร็จการศึกษาตามหลักสูตร ดังได้ระบุ
                                            ไว้ในข้อ 1 ของสัญญานี้
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 3</b> ภายหลังจากที่สำเร็จการศึกษาตามหลักสูตรแล้ว ข้าพเจ้าตกลงยินยอมจะปฏิบัติการให้เป็นไปตามคำสั่ง
                                            ของสำนักงานคณะกรรมการข้าราชการพลเรือน และหรือคณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาทันตแพทยศาสตร์
                                            ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการหรือองค์การของรัฐบาลต่างๆ ในการจัดสรรให้ข้าพเจ้าเข้ารับการศึกษา
                                            อบรมเพิ่มเติม ณ แห่งใด ๆ หรือเข้ารับราชการ หรือทำงานในสถานศึกษา ส่วนราชการหรือองค์การของรัฐบาลแห่ง
                                            ใดทุกประการ และในกรณีที่สำนักงานคณะกรรมการข้าราชการพลเรือน และหรือคณะกรรมการพิจารณาจัดสรร
                                            นักศึกษาวิชาทันตแพทยศาสตร์ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการ หรือองค์การของรัฐบาลต่างๆ สั่งให้ข้าพเจ้า
                                            เข้ารับราชการหรือทำงาน ข้าพเจ้าจะรับราชการหรือทำงานนั้นอยู่ต่อไปเป็นเวลา<b class='red-text'>ไม่น้อยกว่าสามปี</b>ติดต่อกันไป
                                            นับตั้งแต่วันที่ได้กำหนดในคำสั่ง
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            แต่ถ้าหลังจากสำเร็จการศึกษาตามหลักสูตรแล้ว สำนักงานคณะกรรมการข้าราชการพลเรือน  และหรือ
                                            คณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาทันตแพทยศาสตร์ ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการหรือองค์การ
                                            ของรัฐบาลต่างๆ ได้ให้ข้าพเจ้าเข้ารับการศึกษาอบรมเพิ่มเติมตามความต้องการของกระทรวงทบวงกรมใดต่อไปอีกแล้ว
                                            เมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้วหรือไม่ได้ทำการศึกษาอบรมเพิ่มเติมต่อไปจนสำเร็จด้วยเหตุใดก็ดี
                                            ข้าพเจ้ายินยอมเข้ารับราชการหรือทำงานตามที่สำนักงานคณะกรรมการข้าราชการพลเรือน และหรือ
                                            คณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาทันตแพทยศาสตร์ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการหรือองค์การของ
                                            รัฐบาลต่างๆ สั่งให้เข้ารับราชการหรือทำงานนั้น โดยจะรับราชการหรือทำงานนั้นอยู่ต่อไปเป็นเวลา<b class='red-text'>ไม่น้อยกว่าสามปี</b>
                                            ติดต่อกันไปนับตั้งแต่วันที่ได้กำหนดในคำสั่ง แต่ถ้าเป็นการเข้ารับการศึกษาอบรมเพิ่มเติมในระหว่างที่รับราชการหรือ
                                            ทำงานตามคำสั่งในวรรคแรก เมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว  หรือไม่ได้ทำการศึกษาอบรมเพิ่มเติมต่อไป
                                            จนสำเร็จด้วยเหตุใดก็ดี ข้าพเจ้าจะยินยอมเข้ารับราชการหรือทำงานต่อไปจนครบกำหนดระยะเวลา<b class='red-text'>ไม่น้อยกว่าสามปี</b>
                                            ทั้งนี้ ไม่นับระยะเวลาระหว่างเข้ารับการศึกษาอบรมเพิ่มเติมรวมคำนวณเข้าด้วย
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าข้าพเจ้าไม่รับราชการ หรือทำงานตามที่กล่าวในวรรคแรก หรือวรรคสองแล้วแต่กรณี ข้าพเจ้ายินยอมรับผิด
                                            ชดใช้เงินให้แก่มหาวิทยาลัยเป็น<span class='red-text'>จำนวน 400,000 บาท (สี่แสนบาทถ้วน)</span> ภายในกำหนดเวลาที่มหาวิทยาลัย
                                            เรียกร้องให้ชำระ
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าข้าพเจ้ารับราชการ หรือทำงานไม่ครบกำหนดเวลาตามที่กล่าวไว้ในวรรคแรกหรือวรรคสอง  แล้วแต่กรณี
                                            ข้าพเจ้ายินยอมรับผิดชดใช้เงินให้แก่มหาวิทยาลัยตามระยะเวลาที่ขาด  โดยคิดคำนวณลดลงตามส่วนเฉลี่ยจากจำนวนเงิน
                                            ที่ต้องชดใช้ในวรรคก่อน
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าการที่ข้าพเจ้ามิได้เข้ารับราชการหรือทำงานตามความในวรรคสาม หรือออกจากราชการหรืองานก่อนครบ
                                            กำหนดเวลาดังกล่าวในวรรคสี่ เป็นเพราะเหตุที่ข้าพเจ้าเจ็บป่วยหรือพิการ และสำนักงานคณะกรรมการข้าราชการ
                                            พลเรือนได้พิจารณาแล้วเห็นว่า ข้าพเจ้าไม่อาจ หรือไม่สามารถที่จะรับราชการหรือทำงานได้ ข้าพเจ้าจึงจะไม่ต้องรับ
                                            ผิดตามที่ระบุไว้ในวรรคสามหรือวรรคสี่แล้วแต่กรณี
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 4</b> เพื่อเป็นหลักประกันในการปฏิบัติตามสัญญานี้ ข้าพเจ้าจะจัดหาบุคคลที่มีคุณสมบัติซึ่งมหาวิทยาลัย
                                            เห็นสมควรทำสัญญาค้ำประกันข้าพเจ้า ภายในเวลาที่มหาวิทยาลัยกำหนด และในกรณีที่มหาวิทยาลัยเห็นสมควรให้
                                            ข้าพเจ้าเปลี่ยนผู้ค้ำประกันข้าพเจ้าจะปฏิบัติตามทุกประการ
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 5</b> ข้าพเจ้าสมัครใจที่จะเข้าร่วมศึกษาดูงาน หรือฝึกปฏิบัติงานภายนอกคณะทันตแพทยศาสตร์ ซึ่ง
                                            เป็นส่วนงานหนึ่งของมหาวิทยาลัยตามกำหนดของรายวิชาต่างๆ ซึ่งอยู่ในหลักสูตรทันตแพทยศาสตรบัณฑิต ทั้งที่มีอยู่ใน
                                            ขณะนี้และที่จะมีขึ้นภายหน้า
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 6</b> ในการศึกษาดูงานหรือปฏิบัติงานตามข้อ 5 ข้าพเจ้าจะประพฤติปฏิบัติตามระเบียบ ข้อบังคับ ประกาศของ
                                            คณะทันตแพทยศาสตร์โดยเคร่งครัด ทั้งจะต้องใช้ความระมัดระวังในการปฏิบัติงานเพื่อให้สำเร็จตาม
                                            จุดมุ่งหมายที่กำหนดไว้  ข้าพเจ้าจะไม่ก่อให้เกิดความเสียหายไม่ว่ากรณีใด ๆ แก่ตัวข้าพเจ้าและบุคคลอื่น
                                            ในการศึกษาดูงานหรือฝึกปฏิบัติงาน ตามความในข้อ 5 หากข้าพเจ้าได้รับความเสียหายไม่ว่าจะเกิดจากการ
                                            กระทำของข้าพเจ้า หรือจากบุคคลอื่นไม่ว่าจะเป็นผลโดยตรง หรือต่อเนื่องหรือที่เกี่ยวข้องกับมหาวิทยาลัยมหิดล ข้าพเจ้า
                                            จะมีสิทธิได้รับเพียงเงินสงเคราะห์ สำหรับนักศึกษามหาวิทยาลัย และสิทธิประโยชน์จากการประกันอุบัติเหตุที่
                                            ข้าพเจ้าหรือคณะทันตแพทยศาสตร์ ได้ทำประกันไว้เท่านั้น
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 7</b> กรณีที่ คณะทันตแพทยศาสตร์ ได้ชำระเงินค่าเสียหายแก่บุคคลภายนอกแทนข้าพเจ้า ไม่ว่า
                                            กรณีใดๆ อันเกิดจากการที่ข้าพเจ้าปฏิบัติฝ่าฝืนความในข้อ 6 วรรคแรก ข้าพเจ้ายินยอมรับผิดชดใช้เงินค่าเสียหายคืนแก่
                                            คณะทันตแพทยศาสตร์ พร้อมดอกเบี้ยในอัตราร้อยละ  15 ต่อปี นับจากวันที่คณะทันตแพทยศาสตร์
                                            ได้ชำระเงินให้แก่บุคคลภายนอก นอกจากนี้ข้าพเจ้ายังต้องรับผิดชดใช้ค่าใช้จ่ายต่างๆ อันเป็นผลสืบเนื่องจากการฝ่าฝืน
                                            นั้นด้วย
                                        </p>
                                        <p class='center red-text'>ข้าพเจ้าได้ทราบและเข้าใจข้อความในสัญญาฉบับนี้ดีแล้ว จึงได้ลงนามในสัญญานี้ไว้เป็นหลักฐาน</p>
                                    </div>");



            _string.Append("            <div class='section'>" +
                           "                <div class='right'>" +
                                            _stdNameTh + "  นักศึกษา<br /><br />" +
                                            _signCEO +
                           "                <p>" + _signCEOPosition + "</p>" +
                           "            </div>" +
                           "        </div>" +
                           "    </div> <br /><br /><br /><br />");

            return _string.ToString();
        }
        #endregion DTDSBOLD

        #region DTDSBNEW
        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: Preview_DTDSB
        /// Method : แสดงสัญญา DTDSB พรีวิว
        /// Sample : N/A
        /// </summary>
        public static string Preview_DTDSBNEW(string _acaYear, string _studentId, string _warranty, string _consent, string _studentCode)
        {
            StringBuilder _string = new StringBuilder();
            CurDate _date = new CurDate();
            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
            signCEOinfo _signInfo = new signCEOinfo(_acaYear);
            string _signCEO, _signCEOPosition; ;
            string _fatherName, _motherName;
            string _idCard, _stdNameTh, _birthDate, _age, _moo, _no, _soi, _road, _subdistrict, _district, _provice, _zipcode, _phone, _mobile, _thNationalityName, _warrantyBy;
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
            //_phone = Myconfig.CvEmpty(_stdInfo.Tel, " - ");
            _mobile = Myconfig.CvEmpty(_stdInfo.phoneSTD, " - ");
            _idCard = Myconfig.CvEmpty(_stdInfo.IdCard, " - ");
            _thNationalityName = Myconfig.CvEmpty(_stdInfo.thNationalityName, " - ");


            _fatherName = _parentFInfo.FullNameTh;
            _motherName = _parentMInfo.FullNameTh;
            //_signCEO = Myconfig.GetSignCeoMahidol(_acaYear);
            _signCEO = Myconfig.CvEmpty(_signInfo.signNameCEO, " - ");
            _signCEOPosition = Myconfig.CvEmpty(_signInfo.SignCEOPosition, "-");
            if (_warranty == "F")
            {
                _warrantyBy = _fatherName;
            }
            else if (_warranty == "M")
            {
                _warrantyBy = _motherName;
            }
            else
            {
                _warrantyBy = "บุคคลอื่น";
            }

            _string.Append(@"   <div class='card-panel grey lighten-5'>
                                <div class='grey-text text-darken-4'>
                                    <div class='section'>
                                        <h5 class='center'>
                                            <img src='Images/logo.png' class='circle images' /></h5>
                                            <p class='center'><b><u>สัญญาการเป็นนักศึกษาเพื่อศึกษาหลักสูตรทันตแพทยศาสตรบัณฑิต</u></b></p>
                                    </div>
                                    <div class='section'>
                                        <div class='right'>
                                            สัญญาทำที่ มหาวิทยาลัยมหิดล<br />");
            _string.Append(@"                   วันที่ <b>" + _date.Day + "</b> เดือน <b>" + _date.MonthNameTh + "</b> พ.ศ. <b>" + _date.YearTh + "</b>");
            _string.Append(@"               </div>
                                    </div>
                                    <br />
                                    <div class='section'>
                                        <p style='text-indent: 4em;'>
                                            โดยที่รัฐบาลมีเจตจำนงมุ่งหมายที่จะให้นักศึกษาหลักสูตรทันตแพทยศาสตรบัณฑิตทุกคนทำงาน
                                            หรือรับราชการ สนองความต้องการของประเทศชาติภายหลังสำเร็จการศึกษาตามหลักสูตรทันตแพทยศาสตรบัณฑิต
                                            และสอบได้ใบอนุญาตเป็นผู้ประกอบวิชาชีพทันตกรรมแล้ว โดยในการนี้เป็นหน้าที่ของมหาวิทยาลัยมหิดล
                                            และคณะกรรมการพิจารณาจัดสรรนักศึกษาทันตแพทย์ผู้ทำสัญญาการเป็นนักศึกษาทันตแพทย์ (คณะกรรมการพิจารณาจัดสรรนักศึกษาทันตแพทย์ฯ)  
                                            ซึ่งคณะรัฐมนตรีได้แต่งตั้งขึ้นเพื่อจัดสรรนักศึกษาทันตแพทย์เข้าทำงานหรือรับราชการสนองความต้องการของประเทศชาติที่จะดำเนินการให้สำเร็จผลสมความมุ่งหมายดังกล่าว
                                        </p>
                                    </div>");




            // show student prefile
            _string.Append(@"           <div class='section'>
                                        <p style='text-indent: 4em;'>");
            _string.Append(@"                   ข้าพเจ้า <span class='indigo-text text-darken-3'><b>" + _stdNameTh + "</b></span>");
            _string.Append(@"                   เชื้อชาติ <span class='indigo-text text-darken-3'><b> - </b></span>");
            _string.Append(@"                   สัญชาติ <span class='indigo-text text-darken-3'><b>" + _thNationalityName + "</b></span>");
            _string.Append(@"                   ศาสนา <span class='indigo-text text-darken-3'><b> - </b></span>");
            _string.Append(@"                   เกิดเมื่อวันที่ ");
            _string.Append(@"                   <span class='indigo-text text-darken-3'><b>" + _birthDate + "</b></span>");
            _string.Append(@"                   อายุ <span class='indigo-text text-darken-3'><b>" + _age + "</b></span> ปี ");
            _string.Append(@"                   ตั้งบ้านเรือนอยู่บ้านเลขที่ <span class='indigo-text text-darken-3'><b>" + _no + "</b></span>");
            _string.Append(@"                   หมู่ที่ <span class='indigo-text text-darken-3'><b>" + _moo + "</b></span>");
            _string.Append(@"                   ตรอก /ซอย <span class='indigo-text text-darken-3'><b>" + _soi + "</b></span>");
            _string.Append(@"                   ถนน <span class='indigo-text text-darken-3'><b>" + _road + " </b></span>");
            _string.Append(@"                   ตำบล /แขวง <span class='indigo-text text-darken-3'><b>" + _subdistrict + "</b></span>");
            _string.Append(@"                   อำเภอ/เขต <span class='indigo-text text-darken-3'><b>" + _district + "</b></span>");
            _string.Append(@"                   จังหวัด <span class='indigo-text text-darken-3'><b>" + _provice + "</b></span>");
            _string.Append(@"                   รหัสไปรษณีย์ <span class='indigo-text text-darken-3'><b>" + _zipcode + "</b></span>");
            _string.Append(@"                   โทรศัพท์  <span class='indigo-text text-darken-3'><b>" + _mobile + "</b></span>");
            _string.Append(@"                   ผู้ถือบัตรประจำตัวประชาชนเลขที่ <span class='indigo-text text-darken-3'><b>" + _idCard + "</b></span>");
            //_string.Append(@"                   ชื่อบิดา <span class='indigo-text text-darken-3'><b>" + _fatherName + "</b></span>");
            //_string.Append(@"                   ชื่อมารดา <span class='indigo-text text-darken-3'><b>" + _motherName + "</b></span>");
            //_string.Append(@"                   เป็นผู้หนึ่งซึ่งประสงค์จะเข้าศึกษาวิชาทันตแพทยศาสตร์เพื่อสนองความต้องการของประเทศชาติ ตามเจตจำนงของรัฐบาล
            //                                    ดังกล่าวข้างต้น
            _string.Append(@"                   (ดังปรากฏตามสำเนาบัตรประจำตัวประชาชนแนบท้ายสัญญานี้) ซึ่งต่อไปนี้ในสัญญาเรียกว่า “ผู้ให้สัญญา”
                                            ประสงค์จะเข้าศึกษาหลักสูตรทันตแพทยศาสตรบัณฑิต เพื่อสนองความต้องการของประเทศชาติตามเจตจำนง
                                            ของรัฐบาลดังกล่าวข้างต้น)");

            _string.Append(@"
                                        </p>
                                    </div>");

            _string.Append(@"           <div class='section'>
                                        <p style='text-indent: 4em;'>");
            _string.Append(@"                   ผู้ให้สัญญาจึงขอทำสัญญาให้ไว้แก่ มหาวิทยาลัยมหิดล โดย " + _signCEO + " ตำแหน่ง " + _signCEOPosition + " ซึ่งต่อไปในสัญญานี้เรียกว่า “มหาวิทยาลัย” มีข้อความดังต่อไปนี้");
            _string.Append(@"               </p>
                                        <p style='text-indent: 4em;'>");
            _string.Append(@"                   ข้อ ๑. ผู้ให้สัญญาตกลงเข้าศึกษาหลักสูตรทันตแพทยศาสตรบัณฑิตที่มหาวิทยาลัยนี้ ตั้งแต่ปีการศึกษา <span class='indigo-text text-darken-3'><b>" + _acaYear +
                                                " </b></span>จนกว่าจะสำเร็จการศึกษาตามหลักสูตรทันตแพทยศาสตรบัณฑิต");
            _string.Append(@"               </p>

                                        <p style='text-indent: 4em;'>
                                            ในระหว่างที่ผู้ให้สัญญาศึกษาหลักสูตรทันตแพทยศาสตรบัณฑิตตามสัญญานี้ ผู้ให้สัญญายินยอมประพฤติและปฏิบัติตามประกาศ ข้อบังคับ 
                                            หรือคำสั่งของมหาวิทยาลัยที่ได้กำหนดหรือสั่งการเกี่ยวกับการเป็นนักศึกษาหลักสูตรทันตแพทยศาสตรบัณฑิต ทั้งที่ได้ออกใช้บังคับอยู่แล้ว ในขณะที่ลงนามในสัญญานี้ 
                                            และที่จะได้ออกใช้บังคับต่อไปในภายหน้าโดยเคร่งครัด และให้ถือว่าประกาศ ข้อบังคับ หรือคำสั่งต่างๆ ดังกล่าวเป็นส่วนหนึ่งของสัญญานี้
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            ข้อ ๒. ในระหว่างที่ผู้ให้สัญญาเข้าศึกษาตามสัญญานี้ ผู้ให้สัญญาจะตั้งใจและเพียรพยายามอย่างดีที่สุดในการศึกษาเล่าเรียน โดยจะไม่หลีกเลี่ยง ละเลย ทอดทิ้ง ยุติ หรือเลิกการศึกษาก่อนที่จะสำเร็จการศึกษา
                                            ตามหลักสูตรทันตแพทยศาสตรบัณฑิต ดังได้ระบุไว้ในข้อ ๑ ของสัญญานี้
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            ข้อ ๓. ภายหลังจากที่สำเร็จการศึกษาตามหลักสูตรทันตแพทยศาสตรบัณฑิต และสอบได้ใบอนุญาตเป็นผู้ประกอบวิชาชีพทันตกรรมแล้ว ผู้ให้สัญญาตกลงยินยอมจะปฏิบัติการให้เป็นไปตามคำสั่งของคณะกรรมการพิจารณาจัดสรรนักศึกษาทันตแพทย์ฯ ในการจัดสรรให้ผู้ให้สัญญาเข้ารับการศึกษาอบรมเพิ่มเติม ณ แห่งใดๆ หรือ
                                            เข้ารับราชการ หรือทำงานในสถานศึกษา ส่วนราชการ หรือหน่วยงานของรัฐแห่งใดทุกประการ และในกรณีที่ คณะกรรมการพิจารณาจัดสรรนักศึกษาทันตแพทย์ฯ สั่งให้ผู้ให้สัญญาเข้ารับราชการหรือทำงานผู้ให้สัญญาจะรับราชการหรือทำงานนั้นอยู่ต่อไปเป็นระยะเวลา ๓ (สาม) ปีติดต่อกันไป นับตั้งแต่วันที่ได้กำหนดในคำสั่ง

                                        </p>
                                        <p style='text-indent: 4em;'>
                                            หากภายหลังจากสำเร็จการศึกษาตามหลักสูตรทันตแพทยศาสตรบัณฑิต และสอบได้ใบอนุญาตเป็นผู้ประกอบวิชาชีพทันตกรรมแล้ว และคณะกรรมการพิจารณาจัดสรรนักศึกษาทันตแพทย์ฯ ได้ให้ผู้ให้สัญญาเข้ารับการศึกษาอบรมเพิ่มเติมตามความต้องการของกระทรวง ทบวงกรมใดต่อไปอีก เมื่อผู้ให้สัญญาได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ทำการศึกษาอบรมเพิ่มเติมต่อไปจนสำเร็จด้วยเหตุใดก็ดี ผู้ให้สัญญายินยอมเข้า
                                            รับราชการหรือทำงานตามที่คณะกรรมการพิจารณาจัดสรรนักศึกษาทันตแพทย์ฯ สั่งให้เข้ารับราชการหรือทำงานนั้นโดยจะรับราชการหรือทำงานนั้นอยู่ต่อไปเป็นระยะเวลา ๓ (สาม) ปี ติดต่อกันไป นับตั้งแต่วันที่ได้กำหนดในคำสั่ง แต่ถ้าเป็นการเข้ารับการศึกษาอบรมเพิ่มเติมในระหว่างที่รับราชการหรือทำงานตามคำสั่งในวรรคหนึ่ง เมื่อผู้ให้สัญญาได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ทำการศึกษาอบรมเพิ่มเติมต่อไปจนสำเร็จด้วยเหตุใดก็ดี ผู้ให้สัญญาจะยินยอมเข้ารับราชการหรือทำงานต่อไปจนครบกำหนดระยะเวลา ๓ (สาม) ปี ทั้งนี้ โดยไม่นับระยะเวลาระหว่างเข้ารับการศึกษาอบรมเพิ่มเติมรวมคำนวณเข้าด้วยแต่อย่างใด

                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าผู้ให้สัญญาไม่รับราชการ หรือทำงานตามที่กล่าวในวรรคหนึ่ง หรือวรรคสอง แล้วแต่กรณี
                                            ผู้ให้สัญญายินยอมรับผิดชดใช้เงิน เป็นจำนวน<span class='red-text'> ๔๐๐,๐๐๐ บาท (สี่แสนบาทถ้วน)</span> ให้แก่มหาวิทยาลัย
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าผู้ให้สัญญารับราชการหรือทำงานไม่ครบกำหนดเวลาตามที่กล่าวไว้ในวรรคหนึ่ง หรือวรรคสอง แล้วแต่กรณี เงินที่จะชดใช้คืนตามวรรคก่อนจะลดลงตามสัดส่วนของระยะเวลาที่ผู้ให้สัญญารับราชการหรือทำงาน
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าการที่ผู้ให้สัญญามิได้เข้ารับราชการหรือทำงานตามความในวรรคสาม หรือออกจากราชการ
                                            หรืองานก่อนครบกำหนดเวลาดังกล่าวในวรรคสี่ เป็นเหตุเกิดจากผู้ให้สัญญาเจ็บป่วยหรือพิการ หรือมีเหตุอันสมควรอื่น และคณะกรรมการพิจารณาจัดสรรนักศึกษาทันตแพทย์ฯ และมหาวิทยาลัยได้พิจารณาแล้วเห็นว่าผู้ให้สัญญา
                                            ไม่สามารถที่จะรับราชการหรือทำงานได้ ผู้ให้สัญญาจึงจะไม่ต้องรับผิดตามที่ระบุไว้ในวรรคสามหรือวรรคสี่แล้วแต่กรณี
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            เงินที่จะต้องชดใช้ตามสัญญานี้ ผู้ให้สัญญาจะต้องชำระให้แก่มหาวิทยาลัยจนครบถ้วนภายในกำหนดระยะเวลา<span class='red-text'> ๓๐ (สามสิบ) </span>วัน นับถัดจากวันที่ได้รับแจ้งจากมหาวิทยาลัย หากผู้ให้สัญญาไม่ชำระภายในกำหนดระยะเวลาดังกล่าวหรือชำระไม่ครบถ้วน  ผู้ให้สัญญาจะต้องชำระดอกเบี้ยในอัตราร้อยละ<span class='red-text'> ๗.๕ (เจ็ดจุดห้า) </span>ต่อปี ของจำนวนเงินที่ยังมิได้ชำระนับถัดจากวันครบกำหนดระยะเวลาดังกล่าวจนกว่าจะชำระครบถ้วน
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ในกรณีที่ผู้ให้สัญญาสำเร็จการศึกษาตามหลักสูตรทันตแพทยศาสตรบัณฑิต แต่ยังไม่ได้รับใบอนุญาตประกอบวิชาชีพทันตกรรม ผู้ให้สัญญายังคงมีความผูกพันต้องเข้ารับราชการหรือทำงานตามหลักเกณฑ์ 
                                            ระเบียบ ข้อบังคับ หรือคำสั่งที่คณะกรรมการพิจารณาจัดสรรนักศึกษาทันตแพทย์ฯ กำหนด ทั้งที่มีอยู่แล้ว
                                            ในวันทำสัญญานี้และที่จะออกใช้บังคับต่อไปในภายหน้าโดยเคร่งครัดและให้ถือว่าหลักเกณฑ์ ระเบียบ ข้อบังคับหรือคำสั่งดังกล่าวเป็นส่วนหนึ่งของสัญญานี้
                                        </p>");
            _string.Append(@"
                                        <p style='text-indent: 4em;'>
                                            ข้อ ๔. ในวันทำสัญญานี้ ผู้ให้สัญญาได้จัดให้ <span class='indigo-text text-darken-3'><b>" + _warrantyBy + "</b></span> ทำสัญญาค้ำประกันการปฏิบัติและความรับผิดตามสัญญานี้ของผู้ให้สัญญาด้วย");
            _string.Append(@"               </p>
                                        <p style='text-indent: 4em;'>
                                            ในกรณีที่ผู้ค้ำประกันตาย หรือถูกศาลสั่งพิทักษ์ทรัพย์เด็ดขาดหรือพิพากษาให้บุคคลล้มละลาย หรือมหาวิทยาลัยเห็นสมควรให้ผู้สัญญาเปลี่ยนผู้ค้ำประกันในระหว่างอายุประกันตามสัญญานี้ ผู้ให้สัญญาจะต้องจัดให้มีผู้ค้ำประกันใหม่ ภายใน<span class='red-text'> ๓๐ (สามสิบ) </span>วัน นับแต่วันที่ผู้ค้ำประกันเดิมตายหรือถูกพิทักษ์ทรัพย์เด็ดขาด
                                            หรือศาลพิพากษาให้เป็นบุคคลล้มละลาย หรือวันที่ได้รับแจ้งเป็นลายลักษณ์อักษรให้เปลี่ยนผู้ค้ำประกันแล้วแต่กรณี โดยผู้ค้ำประกันรายใหม่จะต้องค้ำประกันตามสัญญาค้ำประกันเดิมทุกประการ
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            สัญญานี้ทำขึ้นเป็นสองฉบับ มีข้อความถูกต้องตรงกัน คู่สัญญาได้อ่านและเข้าใจข้อความ
                                            โดยละเอียดตลอดแล้ว จึงได้ลงลายมือชื่อไว้เป็นสำคัญต่อหน้าพยานและคู่สัญญาต่างยึดถือไว้ฝ่ายละหนึ่งฉบับ
                                        </p>
                                        <p class='center red-text'>ข้าพเจ้าได้ทราบและเข้าใจข้อความในสัญญาฉบับนี้ดีแล้ว จึงได้ลงนามในสัญญานี้ไว้เป็นหลักฐาน</p>
                                    </div>");



            _string.Append("            <div class='section'>" +
                           "                <div class='right'>" +
                                            _stdNameTh + "  ผู้ให้สัญญา<br /><br />" +
                                            _signCEO +
                           "                <p>" + _signCEOPosition + "</p>" +
                           "            </div>" +
                           "        </div>" +
                           "    </div> <br /><br /><br /><br />");

            return _string.ToString();
        }
        #endregion DTDSBNEW

        #region PYPYB
        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: Preview_PYPYB
        /// Method : แสดงสัญญา PYPYB พรีวิว
        /// Sample : N/A
        /// </summary>
        public static string Preview_PYPYB(string _acaYear, string _studentId, string _studentCode)
        {
            StringBuilder _string = new StringBuilder();
            CurDate _date = new CurDate();
            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
            signCEOinfo _signInfo = new signCEOinfo(_acaYear);
            string _signCEO, _signCEOPosition; ;
            string _fatherName, _motherName;
            string _idCard, _stdNameTh, _birthDate, _age, _moo, _no, _soi, _road, _subdistrict, _district, _provice, _zipcode, _phone, _mobile;
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
            //_phone = Myconfig.CvEmpty(_stdInfo.Tel, " - ");
            _mobile = Myconfig.CvEmpty(_stdInfo.phoneSTD, " - ");
            _idCard = Myconfig.CvEmpty(_stdInfo.IdCard, " - ");


            _fatherName = _parentFInfo.FullNameTh;
            _motherName = _parentMInfo.FullNameTh;
            //_signCEO = Myconfig.GetSignCeoMahidol(_acaYear);
            _signCEO = Myconfig.CvEmpty(_signInfo.signNameCEO, " - ");
            _signCEOPosition = Myconfig.CvEmpty(_signInfo.SignCEOPosition, "-");

            _string.Append(@"   <div class='card-panel grey lighten-5'>
                                <div class='grey-text text-darken-4'>
                                    <div class='section'>
                                        <h5 class='center'>
                                            <img src='Images/logo.png' class='circle images' />
                                        </h5>
                                        <p class='center'><b><u>สัญญาการเป็นนักศึกษาเพื่อศึกษาวิชาเภสัชศาสตร์</u></b></p>
                                    </div>
                                    <div class='section'>
                                        <div class='right'>
                                            สัญญาทำที่ มหาวิทยาลัยมหิดล<br />");
            _string.Append(@"                   วันที่ <b>" + _date.Day + "</b> เดือน <b>" + _date.MonthNameTh + "</b> พ.ศ. <b>" + _date.YearTh + "</b>");
            _string.Append(@"               </div>
                                    </div>
                                    <br />
                                    <div class='section'>
                                        <p style='text-indent: 4em;'>
                                            โดยที่รัฐบาลมีเจตจำนงมุ่งหมายที่จะให้นักศึกษาวิชาคณะเภสัชศาสตร์ทุกคนทำงาน
                                            หรือรับราชการสนองความต้องการของประเทศชาติภายหลังสำเร็จการศึกษาแล้ว และในการนี้เป็นหน้าที่ของมหาวิทยาลัยมหิดล
                                            สำนักงานคณะกรรมการข้าราชการพลเรือนและคณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาเภสัชศาสตร์ ผู้สำเร็จการศึกษาไป
                                            ปฏิบัติงานในส่วนราชการหรือองค์การของรัฐบาลต่างๆ ซึ่งคณะรัฐมนตรีได้หรือจะได้แต่งตั้งขึ้นเพื่อจัดสรรนักศึกษาวิชาเภสัชศาสตร์
                                            เข้าทำงานหรือรับราชการสนองความต้องการของประเทศชาติที่จะดำเนินการให้สำเร็จผลสมความมุ่งหมายดังกล่าว
                                        </p>
                                    </div>");

            // show student prefile
            _string.Append(@"           <div class='section'>
                                        <p style='text-indent: 4em;'>");
            _string.Append(@"                   ข้าพเจ้า <span class='indigo-text text-darken-3'><b>" + _stdNameTh + "</b></span>");
            _string.Append(@"                   เกิดเมื่อวันที่ ");
            _string.Append(@"                   <span class='indigo-text text-darken-3'><b>" + _birthDate + "</b></span>");
            _string.Append(@"                   อายุ <span class='indigo-text text-darken-3'><b>" + _age + "</b></span> ปี ");
            _string.Append(@"                   ตั้งบ้านเรือนอยู่บ้านเลขที่ <span class='indigo-text text-darken-3'><b>" + _no + "</b></span>");
            _string.Append(@"                   หมู่ที่ <span class='indigo-text text-darken-3'><b>" + _moo + "</b></span>");
            _string.Append(@"                   ตรอก /ซอย <span class='indigo-text text-darken-3'><b>" + _soi + "</b></span>");
            _string.Append(@"                   ถนน <span class='indigo-text text-darken-3'><b>" + _road + " </b></span>");
            _string.Append(@"                   ตำบล /แขวง <span class='indigo-text text-darken-3'><b>" + _subdistrict + "</b></span>");
            _string.Append(@"                   อำเภอ/เขต <span class='indigo-text text-darken-3'><b>" + _district + "</b></span>");
            _string.Append(@"                   จังหวัด <span class='indigo-text text-darken-3'><b>" + _provice + "</b></span>");
            _string.Append(@"                   รหัสไปรษณีย์ <span class='indigo-text text-darken-3'><b>" + _zipcode + "</b></span>");
            _string.Append(@"                   โทรศัพท์  <span class='indigo-text text-darken-3'><b>" + _mobile + "</b></span>");
            _string.Append(@"                   เลขบัตรประจำตัวประชาชน <span class='indigo-text text-darken-3'><b>" + _idCard + "</b></span>");
            _string.Append(@"                   ชื่อบิดา <span class='indigo-text text-darken-3'><b>" + _fatherName + "</b></span>");
            _string.Append(@"                   ชื่อมารดา <span class='indigo-text text-darken-3'><b>" + _motherName + "</b></span>");
            _string.Append(@"                   เป็นผู้หนึ่งซึ่งประสงค์จะเข้าศึกษาวิชาเภสัชศาสตร์เพื่อสนองความต้องการของประเทศชาติ ตามเจตจำนงของรัฐบาล
                                            ดังกล่าวข้างต้น
                                        </p>
                                    </div>");
            _string.Append(@"           <div class='section'>
                                        <p class='center red-text'>ข้าพเจ้าจึงขอทำสัญญาให้ไว้แก่มหาวิทยาลัยมหิดล ซึ่งต่อไปในสัญญานี้เรียกว่า “มหาวิทยาลัย” ดังมีข้อความต่อไปนี้</p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 1</b> ข้าพเจ้าตกลงเข้าศึกษาวิชาเภสัชศาสตร์ที่มหาวิทยาลัยนี้ ตั้งแต่วันที่ทำสัญญาเป็นต้นไป จนกว่าจะสำเร็จการศึกษาตามหลักสูตรเภสัชศาสตรบัณฑิต
                                         </p>

                                        <p style='text-indent: 4em;'>
                                            ในระหว่างที่ข้าพเจ้าศึกษาวิชาเภสัชศาสตร์ตามสัญญานี้ ข้าพเจ้ายินยอมประพฤติและปฏิบัติตามระเบียบ
                                            ข้อบังคับหรือคำสั่งของมหาวิทยาลัยที่ได้กำหนดหรือสั่งการเกี่ยวกับการเป็นนักศึกษาวิชาเภสัชศาสตร์ ทั้งที่ได้ออกใช้
                                            บังคับอยู่แล้วก่อนวันที่ข้าพเจ้าลงนามในสัญญานี้ และที่จะได้ออกใช้บังคับต่อไปในภายหน้าโดยเคร่งครัด และให้
                                            ถือว่าระเบียบข้อบังคับหรือคำสั่งต่างๆ ดังกล่าวเป็นส่วนหนึ่งของสัญญานี้ด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 2</b> ในระหว่างที่ข้าพเจ้าเข้าศึกษาวิชาตามสัญญานี้ ข้าพเจ้าจะตั้งใจและเพียรพยายามอย่างดีที่สุดใน
                                            การศึกษาเล่าเรียน โดยจะไม่หลีกเลี่ยง ละเลย ทอดทิ้ง ยุติ หรือเลิกการศึกษาก่อนสำเร็จการศึกษาตามหลักสูตร ดังได้ระบุ
                                            ไว้ในข้อ 1 ของสัญญานี้
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 3</b> ภายหลังจากที่สำเร็จการศึกษาตามหลักสูตรแล้ว ข้าพเจ้าตกลงยินยอมจะปฏิบัติการให้เป็นไปตามคำสั่ง
                                            ของสำนักงานคณะกรรมการข้าราชการพลเรือน และหรือคณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาเภสัชศาสตร์
                                            ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการหรือองค์การของรัฐบาลต่างๆ ในการจัดสรรให้ข้าพเจ้าเข้ารับการศึกษา
                                            อบรมเพิ่มเติม ณ แห่งใด ๆ หรือเข้ารับราชการ หรือทำงานในสถานศึกษา ส่วนราชการหรือองค์การของรัฐบาลแห่ง
                                            ใดทุกประการ และในกรณีที่สำนักงานคณะกรรมการข้าราชการพลเรือน และหรือคณะกรรมการพิจารณาจัดสรร
                                            นักศึกษาวิชาเภสัชศาสตร์ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการ หรือองค์การของรัฐบาลต่างๆ สั่งให้ข้าพเจ้า
                                            เข้ารับราชการหรือทำงาน ข้าพเจ้าจะรับราชการหรือทำงานนั้นอยู่ต่อไปเป็นเวลา<b class='red-text'>ไม่น้อยกว่าสองปี</b>ติดต่อกันไป
                                            นับตั้งแต่วันที่ได้กำหนดในคำสั่ง
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            แต่ถ้าหลังจากสำเร็จการศึกษาตามหลักสูตรแล้ว สำนักงานคณะกรรมการข้าราชการพลเรือน  และหรือ
                                            คณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาเภสัชศาสตร์ ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการหรือองค์การ
                                            ของรัฐบาลต่างๆ ได้ให้ข้าพเจ้าเข้ารับการศึกษาอบรมเพิ่มเติมตามความต้องการของกระทรวงทบวงกรมใดต่อไปอีกแล้ว
                                            เมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้วหรือไม่ได้ทำการศึกษาอบรมเพิ่มเติมต่อไปจนสำเร็จด้วยเหตุใดก็ดี
                                            ข้าพเจ้ายินยอมเข้ารับราชการหรือทำงานตามที่สำนักงานคณะกรรมการข้าราชการพลเรือน และหรือ
                                            คณะกรรมการพิจารณาจัดสรรนักศึกษาวิชาเภสัชศาสตร์ผู้สำเร็จการศึกษาไปปฏิบัติงานในส่วนราชการหรือองค์การของ
                                            รัฐบาลต่างๆ สั่งให้เข้ารับราชการหรือทำงานนั้น โดยจะรับราชการหรือทำงานนั้นอยู่ต่อไปเป็นเวลา<b class='red-text'>ไม่น้อยกว่าสองปี</b>
                                            ติดต่อกันไปนับตั้งแต่วันที่ได้กำหนดในคำสั่ง แต่ถ้าเป็นการเข้ารับการศึกษาอบรมเพิ่มเติมในระหว่างที่รับราชการหรือ
                                            ทำงานตามคำสั่งในวรรคแรก เมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว  หรือไม่ได้ทำการศึกษาอบรมเพิ่มเติมต่อไป
                                            จนสำเร็จด้วยเหตุใดก็ดี ข้าพเจ้าจะยินยอมเข้ารับราชการหรือทำงานต่อไปจนครบกำหนดระยะเวลา<b class='red-text'>ไม่น้อยกว่าสองปี</b>
                                            ทั้งนี้ ไม่นับระยะเวลาระหว่างเข้ารับการศึกษาอบรมเพิ่มเติมรวมคำนวณเข้าด้วย
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าข้าพเจ้าไม่รับราชการ หรือทำงานตามที่กล่าวในวรรคแรก หรือวรรคสองแล้วแต่กรณี ข้าพเจ้ายินยอมรับผิด
                                            ชดใช้เงินให้แก่มหาวิทยาลัยเป็น<span class='red-text'>จำนวน 250,000 บาท (สองแสนห้าหมื่นบาทถ้วน)</span> ภายในกำหนดเวลาที่มหาวิทยาลัย
                                            เรียกร้องให้ชำระ
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าข้าพเจ้ารับราชการ หรือทำงานไม่ครบกำหนดเวลาตามที่กล่าวไว้ในวรรคแรกหรือวรรคสอง  แล้วแต่กรณี
                                            ข้าพเจ้ายินยอมรับผิดชดใช้เงินให้แก่มหาวิทยาลัยตามระยะเวลาที่ขาด  โดยคิดคำนวณลดลงตามส่วนเฉลี่ยจากจำนวนเงิน
                                            ที่ต้องชดใช้ในวรรคก่อน
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            ถ้าการที่ข้าพเจ้ามิได้เข้ารับราชการหรือทำงานตามความในวรรคสาม หรือออกจากราชการหรืองานก่อนครบ
                                            กำหนดเวลาดังกล่าวในวรรคสี่ เป็นเพราะเหตุที่ข้าพเจ้าเจ็บป่วยหรือพิการ และสำนักงานคณะกรรมการข้าราชการ
                                            พลเรือนได้พิจารณาแล้วเห็นว่า ข้าพเจ้าไม่อาจ หรือไม่สามารถที่จะรับราชการหรือทำงานได้ ข้าพเจ้าจึงจะไม่ต้องรับ
                                            ผิดตามที่ระบุไว้ในวรรคสามหรือวรรคสี่แล้วแต่กรณี
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 4</b> เพื่อเป็นหลักประกันในการปฏิบัติตามสัญญานี้ ข้าพเจ้าจะจัดหาบุคคลที่มีคุณสมบัติซึ่งมหาวิทยาลัย
                                            เห็นสมควรทำสัญญาค้ำประกันข้าพเจ้า ภายในเวลาที่มหาวิทยาลัยกำหนด และในกรณีที่มหาวิทยาลัยเห็นสมควรให้
                                            ข้าพเจ้าเปลี่ยนผู้ค้ำประกันข้าพเจ้าจะปฏิบัติตามทุกประการ
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 5</b> ข้าพเจ้าสมัครใจที่จะเข้าร่วมศึกษาดูงาน หรือฝึกปฏิบัติงานภายนอกคณะเภสัชศาสตร์ ซึ่ง
                                            เป็นส่วนงานหนึ่งของมหาวิทยาลัยตามกำหนดของรายวิชาต่างๆ ซึ่งอยู่ในหลักสูตรเภสัชศาสตรบัณฑิต ทั้งที่มีอยู่ใน
                                            ขณะนี้และที่จะมีขึ้นภายหน้า
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 6</b> ในการศึกษาดูงานหรือปฏิบัติงานตามข้อ 5 ข้าพเจ้าจะประพฤติปฏิบัติตามระเบียบ ข้อบังคับ ประกาศของ
                                            คณะเภสัชศาสตร์โดยเคร่งครัด ทั้งจะต้องใช้ความระมัดระวังในการปฏิบัติงานเพื่อให้สำเร็จตาม
                                            จุดมุ่งหมายที่กำหนดไว้  ข้าพเจ้าจะไม่ก่อให้เกิดความเสียหายไม่ว่ากรณีใด ๆ แก่ตัวข้าพเจ้าและบุคคลอื่น
                                            ในการศึกษาดูงานหรือฝึกปฏิบัติงาน ตามความในข้อ 5 หากข้าพเจ้าได้รับความเสียหายไม่ว่าจะเกิดจากการ
                                            กระทำของข้าพเจ้า หรือจากบุคคลอื่นไม่ว่าจะเป็นผลโดยตรง หรือต่อเนื่องหรือที่เกี่ยวข้องกับมหาวิทยาลัยมหิดล ข้าพเจ้า
                                            จะมีสิทธิได้รับเพียงเงินสงเคราะห์ สำหรับนักศึกษามหาวิทยาลัย และสิทธิประโยชน์จากการประกันอุบัติเหตุที่
                                            ข้าพเจ้าหรือคณะเภสัชศาสตร์ ได้ทำประกันไว้เท่านั้น
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 7</b> กรณีที่ คณะเภสัชศาสตร์ ได้ชำระเงินค่าเสียหายแก่บุคคลภายนอกแทนข้าพเจ้า ไม่ว่า
                                            กรณีใดๆ อันเกิดจากการที่ข้าพเจ้าปฏิบัติฝ่าฝืนความในข้อ 6 วรรคแรก ข้าพเจ้ายินยอมรับผิดชดใช้เงินค่าเสียหายคืนแก่
                                            คณะเภสัชศาสตร์ พร้อมดอกเบี้ยในอัตราร้อยละ 15 ต่อปี นับจากวันที่คณะเภสัชศาสตร์
                                            ได้ชำระเงินให้แก่บุคคลภายนอก นอกจากนี้ข้าพเจ้ายังต้องรับผิดชดใช้ค่าใช้จ่ายต่างๆ อันเป็นผลสืบเนื่องจากการฝ่าฝืน
                                            นั้นด้วย
                                        </p>
                                        <p class='center red-text'>ข้าพเจ้าได้ทราบและเข้าใจข้อความในสัญญาฉบับนี้ดีแล้ว จึงได้ลงนามในสัญญานี้ไว้เป็นหลักฐาน</p>
                                    </div>");

            _string.Append("            <div class='section'>" +
                           "                <div class='right'>" +
                                            _stdNameTh + "  นักศึกษา<br /><br />" +
                                            _signCEO +
                           "                <p>" + _signCEOPosition + "</p>" +
                           "            </div>" +
                           "        </div>" +
                           "    </div> <br /><br /><br /><br />");

            return _string.ToString();
        }
        #endregion PYPYB
        #region NSNSB
        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: Preview_NSNSB
        /// Method : แสดงสัญญา NSNS พรีวิว
        /// Sample : N/A
        /// </summary>
        public static string Preview_NSNSB(string _acaYear, string _studentId, string _studentCode)
        {
            StringBuilder _string = new StringBuilder();
            CurDate _date = new CurDate();
            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
            signCEOinfo _signInfo = new signCEOinfo(_acaYear);
            string _signCEO, _signCEOPosition; ;
            string _fatherName, _motherName;
            string _idCard, _stdNameTh, _birthDate, _age, _moo, _no, _soi, _road, _subdistrict, _district, _provice, _zipcode, _phone, _mobile;
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
            //_phone = Myconfig.CvEmpty(_stdInfo.Tel, " - ");
            _mobile = Myconfig.CvEmpty(_stdInfo.phoneSTD, " - ");
            _idCard = Myconfig.CvEmpty(_stdInfo.IdCard, " - ");


            _fatherName = _parentFInfo.FullNameTh;
            _motherName = _parentMInfo.FullNameTh;
            //_signCEO = Myconfig.GetSignCeoMahidol(_acaYear);
            _signCEO = Myconfig.CvEmpty(_signInfo.signNameCEO, " - ");
            _signCEOPosition = Myconfig.CvEmpty(_signInfo.SignCEOPosition, "-");




            _string.Append(@"   <div class='card-panel grey lighten-5'>
                                <div class='grey-text text-darken-4'>
                                    <div class='section'>
                                        <h5 class='center'>
                                            <img src='Images/logo.png' class='circle images' />
                                        </h5>
                                        <p class='center'><b><u>สัญญาการเป็นนักศึกษาเพื่อศึกษาวิชาพยาบาลศาสตรบัณฑิต</u></b></p>
                                    </div>
                                    <div class='section'>
                                        <div class='right'>
                                            สัญญาทำที่ มหาวิทยาลัยมหิดล<br />");
            _string.Append(@"                   วันที่ <b>" + _date.Day + "</b> เดือน <b>" + _date.MonthNameTh + "</b> พ.ศ. <b>" + _date.YearTh + "</b>");
            _string.Append(@"           </div>
                                    <br />
                                    <div class='section'>
                                        <p style='text-indent: 4em;'>
                                            โดยที่มหาวิทยาลัยมหิดล มีความประสงค์ที่จะให้นักศึกษาในหลักสูตรพยาบาลศาสตรบัณฑิต รับราชการ
                                            หรือทำงานสนองความต้องการของประเทศชาติภายหลังสำเร็จการศึกษาแล้วโดยที่
                                        </p>
                                    </div>");



            // show student prefile
            _string.Append(@"           <div class='section'>
                                        <p style='text-indent: 4em;'>");
            _string.Append(@"                   ข้าพเจ้า <span class='indigo-text text-darken-3'><b>" + _stdNameTh + "</b></span>");
            _string.Append(@"                   เกิดเมื่อวันที่ ");
            _string.Append(@"                   <span class='indigo-text text-darken-3'><b>" + _birthDate + "</b></span>");
            _string.Append(@"                   อายุ <span class='indigo-text text-darken-3'><b>" + _age + "</b></span> ปี ");
            _string.Append(@"                   ตั้งบ้านเรือนอยู่บ้านเลขที่ <span class='indigo-text text-darken-3'><b>" + _no + "</b></span>");
            _string.Append(@"                   หมู่ที่ <span class='indigo-text text-darken-3'><b>" + _moo + "</b></span>");
            _string.Append(@"                   ตรอก /ซอย <span class='indigo-text text-darken-3'><b>" + _soi + "</b></span>");
            _string.Append(@"                   ถนน <span class='indigo-text text-darken-3'><b>" + _road + " </b></span>");
            _string.Append(@"                   ตำบล /แขวง <span class='indigo-text text-darken-3'><b>" + _subdistrict + "</b></span>");
            _string.Append(@"                   อำเภอ/เขต <span class='indigo-text text-darken-3'><b>" + _district + "</b></span>");
            _string.Append(@"                   จังหวัด <span class='indigo-text text-darken-3'><b>" + _provice + "</b></span>");
            _string.Append(@"                   รหัสไปรษณีย์ <span class='indigo-text text-darken-3'><b>" + _zipcode + "</b></span>");
            _string.Append(@"                   โทรศัพท์  <span class='indigo-text text-darken-3'><b>" + _mobile + "</b></span>");
            _string.Append(@"                   เลขบัตรประจำตัวประชาชน <span class='indigo-text text-darken-3'><b>" + _idCard + "</b></span>");
            _string.Append(@"                   ชื่อบิดา <span class='indigo-text text-darken-3'><b>" + _fatherName + "</b></span>");
            _string.Append(@"                   ชื่อมารดา <span class='indigo-text text-darken-3'><b>" + _motherName + "</b></span>");
            _string.Append(@"                   เป็นผู้หนึ่งซึ่งประสงค์จะเข้าศึกษาในหลักสูตรพยาบาลศาสตรบัณฑิต คณะพยาบาลศาสตร์ เพื่อสนองความต้องการของ
                                            ประเทศชาติ ตามเจตจำนงของมหาวิทยาลัยมหิดล ดังกล่าวข้างต้น
                                        </p>
                                    </div>");

            _string.Append(@"           <div class='section'>
                                        <p class='center red-text'>ข้าพเจ้าจึงขอทำสัญญาให้ไว้แก่มหาวิทยาลัยมหิดล ซึ่งต่อไปในสัญญานี้เรียกว่า “มหาวิทยาลัย” ดังมีข้อความต่อไปนี้</p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 1</b> ข้าพเจ้าตกลงเข้าศึกษาในหลักสูตรพยาบาลศาสตรบัณฑิตที่มหาวิทยาลัย ตั้งแต่วันที่ทำสัญญาเป็นต้นไป จนกว่าจะสำเร็จการศึกษาตามหลักสูตร
                                        </p>

                                        <p style='text-indent: 4em;'>
                                           ในระหว่างที่ข้าพเจ้าเข้าศึกษาตามสัญญานี้ ข้าพเจ้ายินยอมประพฤติและปฏิบัติตามระเบียบข้อบังคับและคำสั่ง
                                            ของมหาวิทยาลัยที่กำหนดหรือสั่งไว้ทุกประการ ทั้งที่ได้ออกใช้บังคับอยู่ในวันที่ข้าพเจ้าลงลายมือชื่อในสัญญานี้ และที่
                                            ออกใช้บังคับในภายหน้าโดยเคร่งครัด และข้าพเจ้ายอมรับว่าระเบียบข้อบังคับและคำสั่งต่างๆ ดังกล่าวเป็นส่วนหนึ่งของ
                                            สัญญานี้ด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 2</b> ในระหว่างที่ข้าพเจ้าเข้าศึกษาตามสัญญานี้ ข้าพเจ้าจะตั้งใจและเพียรพยายามอย่างดีที่สุดในการศึกษาเล่า
                                                    เรียน โดยจะไม่หลีกเลี่ยง ละเลย ทอดทิ้ง ยุติ หรือเลิกการศึกษาก่อนสำเร็จการศึกษาตามหลักสูตร ดังที่ระบุไว้ในข้อ 1
                                                    ถ้าข้าพเจ้าลาออกก่อนศึกษาสำเร็จ หรือประพฤติตนไม่เหมาะสม หรือฝ่าฝืนระเบียบข้อบังคับของมหาวิทยาลัย
                                                    และมหาวิทยาลัยได้พิจารณาแล้วเห็นสมควรให้พ้นสภาพจากการเป็นนักศึกษา ข้าพเจ้ายินยอมชดใช้เงินให้แก่
                                                    มหาวิทยาลัย <b class='red-text'>โดยคิดเป็นเงินเดือนละ 2,000 บาท (สองพันบาทถ้วน)</b> นับตั้งแต่วันที่สัญญานี้มีผลใช้บังคับ
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 3</b> ในระหว่างที่ข้าพเจ้าเข้าศึกษาตามสัญญานี้ หากข้าพเจ้าเกิดเจ็บป่วยหรือพิการ และทางมหาวิทยาลัย
                                            เห็นว่าข้าพเจ้าไม่อาจ หรือไม่สามารถศึกษาตามสัญญานี้ต่อไปได้ ข้าพเจ้าจะไม่ต้องรับผิดชอบตามที่ระบุไว้ในข้อ 2
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 4</b> ภายหลังที่ข้าพเจ้าสำเร็จการศึกษาตามหลักสูตรแล้วข้าพเจ้ายินยอมปฏิบัติให้เป็นไปตามคำสั่งของ
                                            มหาวิทยาลัยในการจัดสรรให้ข้าพเจ้าเข้ารับราชการ หรือทำงานใน<span class='teal-text'>คณะแพทยศาสตร์ศิริราชพยาบาล</span> มหาวิทยาลัยมหิดล
                                            ก่อนหน่วยงานอื่น หรือในส่วนราชการ หรือองค์การอื่นของรัฐบาล ซึ่งต่อไปในสัญญานี้เรียกว่า “หน่วยงาน” โดย
                                            ข้าพเจ้าจะรับราชการหรือทำงานในหน่วยงานนั้นเป็นเวลาติดต่อกัน<b class='red-text'>ไม่น้อยกว่าสองปี</b> นับแต่วันเริ่มเข้ารับราชการหรือ
                                            ทำงานในหน่วยงานนั้น
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            แต่ถ้าภายหลังจากสำเร็จการศึกษาตามหลักสูตรแล้ว มหาวิทยาลัยได้ให้ข้าพเจ้าเข้ารับการศึกษาอบรมเพิ่มเติม
                                            ตามความต้องการของหน่วยงานต่อไปอีก เมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ศึกษาเพิ่มเติมต่อไปจน
                                            สำเร็จด้วยเหตุใดก็ดี ข้าพเจ้ายินยอมเข้ารับราชการหรือทำงานตามที่มหาวิทยาลัยสั่งให้เข้ารับราชการ หรือทำงานใน
                                            หน่วยงานนั้น โดยจะรับราชการหรือทำงานติดต่อกันเป็นเวลา<b class='red-text'>ไม่น้อยกว่าสองปี</b> นับแต่วันเริ่มเข้ารับราชการ หรือทำงาน
                                            ในหน่วยงานนั้น    แต่ถ้าเป็นการเข้ารับการศึกษาอบรมเพิ่มเติมในระหว่างที่รับราชการหรือทำงานตามคำสั่งของ
                                            หน่วยงานที่จัดสรรให้ข้าพเจ้าไปทำงานเมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ศึกษาอบรมเพิ่มเติม
                                            ต่อไปจนสำเร็จด้วยเหตุใดก็ดี ข้าพเจ้ายินยอมเข้ารับราชการหรือทำงานต่อไปจนครบกำหนดเวลาไม่น้อยกว่าสองปี ทั้งนี้
                                            ไม่นับระยะเวลาระหว่างเข้ารับการศึกษาอบรมเพิ่มเติมรวมคำนวณเข้าด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                           ถ้าข้าพเจ้าไม่เข้ารับราชการหรือทำงานตามที่กล่าวในวรรคหนึ่ง หรือวรรคสองแล้วแต่กรณี ข้าพเจ้ายินยอม
                                            รับผิดชดใช้เงินให้แก่มหาวิทยาลัยเป็นจำนวนเงินทั้งสิ้น <b class='red-text'>96,000 บาท (เก้าหมื่นหกพันบาทถ้วน)</b>
                                        </p>

                                        <p style='text-indent: 4em;'>
                                           ถ้าข้าพเจ้ารับราชการ หรือทำงานไม่ครบกำหนดเวลาตามที่กล่าวในวรรคหนึ่งหรือวรรคสอง แล้วแต่กรณี
                                            ข้าพเจ้ายินยอมรับผิดชดใช้เงินให้แก่มหาวิทยาลัยตามระยะเวลาที่ขาด โดยคิดคำนวณลดลงตามส่วนเฉลี่ยจากจำนวนเงิน
                                            ที่ต้อง ชดใช้ในวรรคสาม
                                        </p>
                                        <p style='text-indent: 4em;'>
                                           ถ้าการที่ข้าพเจ้ามิได้เข้ารับราชการหรือทำงานตามความในวรรคสาม หรือออกจากราชการหรือออกจากงาน
                                            ก่อนครบกำหนดดังกล่าวในวรรคสี่ เป็นเพราะเหตุที่ข้าพเจ้าเจ็บป่วยหรือพิการ และมหาวิทยาลัยได้พิจารณาแล้วเห็นว่า
                                            ข้าพเจ้าไม่อาจหรือไม่สามารถที่จะรับราชการหรือทำงานได้ ข้าพเจ้าจึงจะไม่ต้องรับผิดตามที่ระบุไว้ในวรรคสามหรือ
                                            วรรคสี่ แล้วแต่กรณี
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 5</b> ข้าพเจ้ายอมรับรู้ว่า เมื่อข้าพเจ้าสำเร็จการศึกษาตามหลักสูตรแล้ว หากมหาวิทยาลัยไม่รับข้าพเจ้า หรือ
                                            จัดสรรให้ข้าพเจ้าเข้ารับราชการหรือทำงานในหน่วยงาน ไม่ว่าด้วยเหตุประการใดก็ตาม ข้าพเจ้าจะไม่เรียกร้องสิทธิใด ๆ
                                            จากมหาวิทยาลัย ข้าพเจ้าถือว่ามหาวิทยาลัยไม่มีข้อผูกพันในการที่จะต้องหาสถานที่ทำงานให้ข้าพเจ้า และให้ถือว่า
                                            ข้าพเจ้าพ้นจากข้อผูกพันตามสัญญานี้ด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 6</b> เพื่อเป็นหลักประกันในการปฏิบัติตามสัญญานี้ ข้าพเจ้าจะจัดหาบุคคลที่มีคุณสมบัติ ซึ่งมหาวิทยาลัย
                                            เห็นสมควรทำสัญญาค้ำประกันข้าพเจ้า ภายในเวลาที่มหาวิทยาลัยกำหนด และในกรณีที่มหาวิทยาลัยเห็นสมควรให้
                                            ข้าพเจ้าเปลี่ยนผู้ค้ำประกันข้าพเจ้าจะปฏิบัติตามทุกประการ
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 7</b> สัญญานี้ให้มีผลบังคับ เมื่อข้าพเจ้าได้ศึกษาในชั้นปีที่ 3 ของหลักสูตรพยาบาลศาสตรบัณฑิตเป็นต้นไป
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 8</b> ข้าพเจ้าสมัครใจที่จะเข้าร่วมศึกษาดูงาน หรือฝึกปฏิบัติงานภายนอกคณะพยาบาลศาสตร์ ซึ่งเป็นส่วนงาน
                                            หนึ่งของมหาวิทยาลัย ตามกำหนดของรายวิชาต่างๆ ซึ่งอยู่ในหลักสูตรพยาบาลศาสตรบัณฑิต ทั้งที่มีอยู่ในขณะนี้และที่จะมีขึ้นในภายหน้า
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 9</b> ในการศึกษาดูงานหรือฝึกปฏิบัติงานตามข้อที่ 8 ข้าพเจ้าจะประพฤติปฏิบัติตามระเบียบ ข้อบังคับ
                                            ประกาศของคณะพยาบาลศาสตร์โดยเคร่งครัดทั้งจะต้องใช้ความระมัดระวังในการปฏิบัติงานเพื่อให้สำเร็จตาม
                                            จุดมุ่งหมายที่กำหนดไว้ ข้าพเจ้าจะไม่ก่อให้เกิดความเสียหายไม่ว่ากรณีใด ๆ แก่ตัวข้าพเจ้าและบุคคลอื่น
                                            ในการศึกษาดูงานหรือฝึกปฏิบัติงานตามความในข้อ 8 หากข้าพเจ้าได้รับความเสียหาย ไม่ว่าจะเกิดจากการ
                                            กระทำของข้าพเจ้าหรือจากบุคคลอื่น  ไม่ว่าจะเป็นผลโดยตรงหรือต่อเนื่องหรือที่เกี่ยวข้องกับมหาวิทยาลัยมหิดลข้าพเจ้า
                                            จะมีสิทธิได้รับเพียงเงินสงเคราะห์ สำหรับนักศึกษามหาวิทยาลัยมหิดล และสิทธิประโยชน์จากการประกันอุบัติเหตุที่
                                            ข้าพเจ้าและหรือคณะแพทยศาสตร์โรงพยาบาลรามาธิบดี ได้ทำประกันไว้เท่านั้น
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 10</b> กรณีที่ คณะพยาบาลศาสตร์ ได้ชำระค่าเสียหายแก่บุคคลภายนอกแทนข้าพเจ้า ไม่ว่ากรณีใดๆ อันเกิด
                                            จากการที่ข้าพเจ้าปฏิบัติฝ่าฝืนความในข้อ 9 วรรคแรก ข้าพเจ้ายินยอมรับผิดชดใช้เงินค่าเสียหายคืนแก่คณะพยาบาลศาสตร์
                                            พร้อมดอกเบี้ยในอัตราร้อยละ 15 ต่อปีนับจากวันที่คณะพยาบาลศาสตร์ ได้ชำระเงินให้แก่บุคคลภายนอก
                                            นอกจากนี้ข้าพเจ้ายังต้องรับผิดชดใช้ค่าใช้จ่ายต่าง ๆ อันเป็นผลสืบเนื่องจากการฝ่าฝืนนั้นด้วย
                                        </p>
                                        <p class='center red-text'>ข้าพเจ้าได้ทราบและเข้าใจข้อความในสัญญาฉบับนี้ดีแล้ว จึงได้ลงนามในสัญญานี้ไว้เป็นหลักฐาน</p>
                                    </div>");

            _string.Append("            <div class='section'>" +
                           "                <div class='right'>" +
                                            _stdNameTh + "  นักศึกษา<br /><br />" +
                                            _signCEO +
                           "                <p>" + _signCEOPosition + "</p>" +
                           "            </div>" +
                           "        </div>" +
                           "    </div> <br /><br /><br /><br />");

            return _string.ToString();
        }
        #endregion NSNSB
        #region RANSB
        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: Preview_RANSB
        /// Method : แสดงสัญญา RANSB พรีวิว
        /// Sample : N/A
        /// </summary>
        public static string Preview_RANSB(string _acaYear, string _studentId, string _studentCode)
        {
            StringBuilder _string = new StringBuilder();
            CurDate _date = new CurDate();
            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
            signCEOinfo _signInfo = new signCEOinfo(_acaYear);
            string _signCEO, _signCEOPosition; ;
            string _fatherName, _motherName;
            string _idCard, _stdNameTh, _birthDate, _age, _moo, _no, _soi, _road, _subdistrict, _district, _provice, _zipcode, _phone, _mobile;
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
            //_phone = Myconfig.CvEmpty(_stdInfo.Tel, " - ");
            _mobile = Myconfig.CvEmpty(_stdInfo.phoneSTD, " - ");
            _idCard = Myconfig.CvEmpty(_stdInfo.IdCard, " - ");


            _fatherName = _parentFInfo.FullNameTh;
            _motherName = _parentMInfo.FullNameTh;
            //_signCEO = Myconfig.GetSignCeoMahidol(_acaYear);
            _signCEO = Myconfig.CvEmpty(_signInfo.signNameCEO, " - ");
            _signCEOPosition = Myconfig.CvEmpty(_signInfo.SignCEOPosition, "-");

            _string.Append(@"   <div class='card-panel grey lighten-5'>
                                <div class='grey-text text-darken-4'>
                                    <div class='section'>
                                        <h5 class='center'>
                                            <img src='Images/logo.png' class='circle images' />
                                        </h5>
                                        <p class='center'><b><u>สัญญาการเป็นนักศึกษาเพื่อศึกษาวิชาพยาบาลศาสตรบัณฑิต</u></b></p>
                                    </div>
                                    <div class='section'>
                                        <div class='right'>
                                            สัญญาทำที่ มหาวิทยาลัยมหิดล<br />");
            _string.Append(@"                   วันที่ <b>" + _date.Day + "</b> เดือน <b>" + _date.MonthNameTh + "</b> พ.ศ. <b>" + _date.YearTh + "</b>");
            _string.Append(@"               </div>
                                    </div>
                                    <br />
                                    <div class='section'>
                                        <p style='text-indent: 4em;'>
                                            โดยที่มหาวิทยาลัยมหิดล มีความประสงค์ที่จะให้นักศึกษาในหลักสูตรพยาบาลศาสตรบัณฑิต รับราชการ
                                            หรือทำงานสนองความต้องการของประเทศชาติภายหลังสำเร็จการศึกษาแล้วโดยที่
                                        </p>
                                    </div>");
            // show student prefile
            _string.Append(@"           <div class='section'>
                                        <p style='text-indent: 4em;'>");
            _string.Append(@"                   ข้าพเจ้า <span class='indigo-text text-darken-3'><b>" + _stdNameTh + "</b></span>");
            _string.Append(@"                   เกิดเมื่อวันที่ ");
            _string.Append(@"                   <span class='indigo-text text-darken-3'><b>" + _birthDate + "</b></span>");
            _string.Append(@"                   อายุ <span class='indigo-text text-darken-3'><b>" + _age + "</b></span> ปี ");
            _string.Append(@"                   ตั้งบ้านเรือนอยู่บ้านเลขที่ <span class='indigo-text text-darken-3'><b>" + _no + "</b></span>");
            _string.Append(@"                   หมู่ที่ <span class='indigo-text text-darken-3'><b>" + _moo + "</b></span>");
            _string.Append(@"                   ตรอก /ซอย <span class='indigo-text text-darken-3'><b>" + _soi + "</b></span>");
            _string.Append(@"                   ถนน <span class='indigo-text text-darken-3'><b>" + _road + " </b></span>");
            _string.Append(@"                   ตำบล /แขวง <span class='indigo-text text-darken-3'><b>" + _subdistrict + "</b></span>");
            _string.Append(@"                   อำเภอ/เขต <span class='indigo-text text-darken-3'><b>" + _district + "</b></span>");
            _string.Append(@"                   จังหวัด <span class='indigo-text text-darken-3'><b>" + _provice + "</b></span>");
            _string.Append(@"                   รหัสไปรษณีย์ <span class='indigo-text text-darken-3'><b>" + _zipcode + "</b></span>");
            _string.Append(@"                   โทรศัพท์  <span class='indigo-text text-darken-3'><b>" + _mobile + "</b></span>");
            _string.Append(@"                   เลขบัตรประจำตัวประชาชน <span class='indigo-text text-darken-3'><b>" + _idCard + "</b></span>");
            _string.Append(@"                   ชื่อบิดา <span class='indigo-text text-darken-3'><b>" + _fatherName + "</b></span>");
            _string.Append(@"                   ชื่อมารดา <span class='indigo-text text-darken-3'><b>" + _motherName + "</b></span>");
            _string.Append(@"                   เป็นผู้หนึ่งซึ่งประสงค์จะเข้าศึกษาในหลักสูตรพยาบาลศาสตรบัณฑิต ภาควิชาพยาบาลศาสตร์ คณะแพทยศาสตร์ โรงพยาบาลรามาธิบดี เพื่อสนองความต้องการของประเทศชาติ ตามเจตจำนงของมหาวิทยาลัยมหิดล ดังกล่าวข้างต้น
                                        </p>
                                    </div>");

            _string.Append(@"           <div class='section'>
                                        <p class='center red-text'>ข้าพเจ้าจึงขอทำสัญญาให้ไว้แก่มหาวิทยาลัยมหิดล ซึ่งต่อไปในสัญญานี้เรียกว่า “มหาวิทยาลัย” ดังมีข้อความต่อไปนี้</p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 1</b> ข้าพเจ้าตกลงเข้าศึกษาในหลักสูตรพยาบาลศาสตรบัณฑิตที่มหาวิทยาลัย ตั้งแต่วันที่ทำสัญญาเป็นต้นไป จนกว่าจะสำเร็จการศึกษาตามหลักสูตร
                                        </p>

                                        <p style='text-indent: 4em;'>
                                           ในระหว่างที่ข้าพเจ้าเข้าศึกษาตามสัญญานี้ ข้าพเจ้ายินยอมประพฤติและปฏิบัติตามระเบียบข้อบังคับและคำสั่ง
                                            ของมหาวิทยาลัยที่กำหนดหรือสั่งไว้ทุกประการ ทั้งที่ได้ออกใช้บังคับอยู่ในวันที่ข้าพเจ้าลงลายมือชื่อในสัญญานี้ และที่
                                            ออกใช้บังคับในภายหน้าโดยเคร่งครัด และข้าพเจ้ายอมรับว่าระเบียบข้อบังคับและคำสั่งต่างๆ ดังกล่าวเป็นส่วนหนึ่งของ
                                            สัญญานี้ด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 2</b> ในระหว่างที่ข้าพเจ้าเข้าศึกษาตามสัญญานี้ ข้าพเจ้าจะตั้งใจและเพียรพยายามอย่างดีที่สุดในการศึกษาเล่า
                                                    เรียน โดยจะไม่หลีกเลี่ยง ละเลย ทอดทิ้ง ยุติ หรือเลิกการศึกษาก่อนสำเร็จการศึกษาตามหลักสูตร ดังที่ระบุไว้ในข้อ 1
                                                    ถ้าข้าพเจ้าลาออกก่อนศึกษาสำเร็จ หรือประพฤติตนไม่เหมาะสม หรือฝ่าฝืนระเบียบข้อบังคับของมหาวิทยาลัย
                                                    และมหาวิทยาลัยได้พิจารณาแล้วเห็นสมควรให้พ้นสภาพจากการเป็นนักศึกษา ข้าพเจ้ายินยอมชดใช้เงินให้แก่
                                                    มหาวิทยาลัย <b class='red-text'>โดยคิดเป็นเงินเดือนละ 2,000 บาท (สองพันบาทถ้วน)</b> นับตั้งแต่วันที่สัญญานี้มีผลใช้บังคับ
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 3</b> ในระหว่างที่ข้าพเจ้าเข้าศึกษาตามสัญญานี้ หากข้าพเจ้าเกิดเจ็บป่วยหรือพิการ และทางมหาวิทยาลัย
                                            เห็นว่าข้าพเจ้าไม่อาจ หรือไม่สามารถศึกษาตามสัญญานี้ต่อไปได้ ข้าพเจ้าจะไม่ต้องรับผิดชอบตามที่ระบุไว้ในข้อ 2
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 4</b> ภายหลังที่ข้าพเจ้าสำเร็จการศึกษาตามหลักสูตรแล้วข้าพเจ้ายินยอมปฏิบัติให้เป็นไปตามคำสั่งของ
                                            มหาวิทยาลัยในการจัดสรรให้ข้าพเจ้าเข้ารับราชการ หรือทำงานใน<span class='teal-text'>คณะแพทยศาสตร์โรงพยาบาลรามาธิบดี</span> มหาวิทยาลัยมหิดล
                                            ก่อนหน่วยงานอื่น หรือในส่วนราชการ หรือองค์การอื่นของรัฐบาล ซึ่งต่อไปในสัญญานี้เรียกว่า “หน่วยงาน” โดย
                                            ข้าพเจ้าจะรับราชการหรือทำงานในหน่วยงานนั้นเป็นเวลาติดต่อกัน<b class='red-text'>ไม่น้อยกว่าสองปี</b> นับแต่วันเริ่มเข้ารับราชการหรือ
                                            ทำงานในหน่วยงานนั้น
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            แต่ถ้าภายหลังจากสำเร็จการศึกษาตามหลักสูตรแล้ว มหาวิทยาลัยได้ให้ข้าพเจ้าเข้ารับการศึกษาอบรมเพิ่มเติม
                                            ตามความต้องการของหน่วยงานต่อไปอีก เมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ศึกษาเพิ่มเติมต่อไปจน
                                            สำเร็จด้วยเหตุใดก็ดี ข้าพเจ้ายินยอมเข้ารับราชการหรือทำงานตามที่มหาวิทยาลัยสั่งให้เข้ารับราชการ หรือทำงานใน
                                            หน่วยงานนั้น โดยจะรับราชการหรือทำงานติดต่อกันเป็นเวลา<b class='red-text'>ไม่น้อยกว่าสองปี</b> นับแต่วันเริ่มเข้ารับราชการ หรือทำงาน
                                            ในหน่วยงานนั้น    แต่ถ้าเป็นการเข้ารับการศึกษาอบรมเพิ่มเติมในระหว่างที่รับราชการหรือทำงานตามคำสั่งของ
                                            หน่วยงานที่จัดสรรให้ข้าพเจ้าไปทำงานเมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ศึกษาอบรมเพิ่มเติม
                                            ต่อไปจนสำเร็จด้วยเหตุใดก็ดี ข้าพเจ้ายินยอมเข้ารับราชการหรือทำงานต่อไปจนครบกำหนดเวลาไม่น้อยกว่าสองปี ทั้งนี้
                                            ไม่นับระยะเวลาระหว่างเข้ารับการศึกษาอบรมเพิ่มเติมรวมคำนวณเข้าด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                           ถ้าข้าพเจ้าไม่เข้ารับราชการหรือทำงานตามที่กล่าวในวรรคหนึ่ง หรือวรรคสองแล้วแต่กรณี ข้าพเจ้ายินยอม
                                            รับผิดชดใช้เงินให้แก่มหาวิทยาลัยเป็นจำนวนเงินทั้งสิ้น <b class='red-text'>96,000 บาท (เก้าหมื่นหกพันบาทถ้วน)</b>
                                        </p>

                                        <p style='text-indent: 4em;'>
                                           ถ้าข้าพเจ้ารับราชการ หรือทำงานไม่ครบกำหนดเวลาตามที่กล่าวในวรรคหนึ่งหรือวรรคสอง แล้วแต่กรณี
                                            ข้าพเจ้ายินยอมรับผิดชดใช้เงินให้แก่มหาวิทยาลัยตามระยะเวลาที่ขาด โดยคิดคำนวณลดลงตามส่วนเฉลี่ยจากจำนวนเงิน
                                            ที่ต้อง ชดใช้ในวรรคสาม
                                        </p>
                                        <p style='text-indent: 4em;'>
                                           ถ้าการที่ข้าพเจ้ามิได้เข้ารับราชการหรือทำงานตามความในวรรคสาม หรือออกจากราชการหรือออกจากงาน
                                            ก่อนครบกำหนดดังกล่าวในวรรคสี่ เป็นเพราะเหตุที่ข้าพเจ้าเจ็บป่วยหรือพิการ และมหาวิทยาลัยได้พิจารณาแล้วเห็นว่า
                                            ข้าพเจ้าไม่อาจหรือไม่สามารถที่จะรับราชการหรือทำงานได้ ข้าพเจ้าจึงจะไม่ต้องรับผิดตามที่ระบุไว้ในวรรคสามหรือ
                                            วรรคสี่ แล้วแต่กรณี
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 5</b> ข้าพเจ้ายอมรับรู้ว่า เมื่อข้าพเจ้าสำเร็จการศึกษาตามหลักสูตรแล้ว หากมหาวิทยาลัยไม่รับข้าพเจ้า หรือ
                                            จัดสรรให้ข้าพเจ้าเข้ารับราชการหรือทำงานในหน่วยงาน ไม่ว่าด้วยเหตุประการใดก็ตาม ข้าพเจ้าจะไม่เรียกร้องสิทธิใด ๆ
                                            จากมหาวิทยาลัย ข้าพเจ้าถือว่ามหาวิทยาลัยไม่มีข้อผูกพันในการที่จะต้องหาสถานที่ทำงานให้ข้าพเจ้า และให้ถือว่า
                                            ข้าพเจ้าพ้นจากข้อผูกพันตามสัญญานี้ด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 6</b> เพื่อเป็นหลักประกันในการปฏิบัติตามสัญญานี้ ข้าพเจ้าจะจัดหาบุคคลที่มีคุณสมบัติ ซึ่งมหาวิทยาลัย
                                            เห็นสมควรทำสัญญาค้ำประกันข้าพเจ้า ภายในเวลาที่มหาวิทยาลัยกำหนด และในกรณีที่มหาวิทยาลัยเห็นสมควรให้
                                            ข้าพเจ้าเปลี่ยนผู้ค้ำประกันข้าพเจ้าจะปฏิบัติตามทุกประการ
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 7</b> สัญญานี้ให้มีผลบังคับ เมื่อข้าพเจ้าได้ศึกษาในชั้นปีที่ 3 ของหลักสูตรพยาบาลศาสตรบัณฑิตเป็นต้นไป
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 8</b> ข้าพเจ้าสมัครใจที่จะเข้าร่วมศึกษาดูงาน หรือฝึกปฏิบัติงานภายนอกคณะแพทยศาสตร์โรงพยาบาลรามาธิบดี ซึ่งเป็นส่วนงาน
                                            หนึ่งของมหาวิทยาลัย ตามกำหนดของรายวิชาต่างๆ ซึ่งอยู่ในหลักสูตรพยาบาลศาสตรบัณฑิต ทั้งที่มีอยู่ในขณะนี้และที่จะมีขึ้นในภายหน้า
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 9</b> ในการศึกษาดูงานหรือฝึกปฏิบัติงานตามข้อที่ 8 ข้าพเจ้าจะประพฤติปฏิบัติตามระเบียบ ข้อบังคับ
                                            ประกาศของคณะพยาบาลศาสตร์โดยเคร่งครัดทั้งจะต้องใช้ความระมัดระวังในการปฏิบัติงานเพื่อให้สำเร็จตาม
                                            จุดมุ่งหมายที่กำหนดไว้ ข้าพเจ้าจะไม่ก่อให้เกิดความเสียหายไม่ว่ากรณีใด ๆ แก่ตัวข้าพเจ้าและบุคคลอื่น
                                            ในการศึกษาดูงานหรือฝึกปฏิบัติงานตามความในข้อ 8 หากข้าพเจ้าได้รับความเสียหาย ไม่ว่าจะเกิดจากการ
                                            กระทำของข้าพเจ้าหรือจากบุคคลอื่น  ไม่ว่าจะเป็นผลโดยตรงหรือต่อเนื่องหรือที่เกี่ยวข้องกับมหาวิทยาลัยมหิดลข้าพเจ้า
                                            จะมีสิทธิได้รับเพียงเงินสงเคราะห์ สำหรับนักศึกษามหาวิทยาลัยมหิดล และสิทธิประโยชน์จากการประกันอุบัติเหตุที่
                                            ข้าพเจ้าและหรือคณะแพทยศาสตร์โรงพยาบาลรามาธิบดี ได้ทำประกันไว้เท่านั้น
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 10</b> กรณีที่ คณะแพทยศาสตร์โรงพยาบาลรามาธิบดี ได้ชำระค่าเสียหายแก่บุคคลภายนอกแทนข้าพเจ้า ไม่ว่ากรณีใดๆ อันเกิด
                                            จากการที่ข้าพเจ้าปฏิบัติฝ่าฝืนความในข้อ 9 วรรคแรก ข้าพเจ้ายินยอมรับผิดชดใช้เงินค่าเสียหายคืนแก่คณะแพทยศาสตร์โรงพยาบาลรามาธิบดี
                                            พร้อมดอกเบี้ยในอัตราร้อยละ 15 ต่อปีนับจากวันที่คณะแพทยศาสตร์โรงพยาบาลรามาธิบดี ได้ชำระเงินให้แก่บุคคลภายนอก
                                            นอกจากนี้ข้าพเจ้ายังต้องรับผิดชดใช้ค่าใช้จ่ายต่างๆ อันเป็นผลสืบเนื่องจากการฝ่าฝืนนั้นด้วย
                                        </p>
                                        <p class='center red-text'>ข้าพเจ้าได้ทราบและเข้าใจข้อความในสัญญาฉบับนี้ดีแล้ว จึงได้ลงนามในสัญญานี้ไว้เป็นหลักฐาน</p>
                                    </div>");

            _string.Append("            <div class='section'>" +
                          "                <div class='right'>" +
                                           _stdNameTh + "  นักศึกษา<br /><br />" +
                                           _signCEO +
                          "                <p>" + _signCEOPosition + "</p>" +
                          "            </div>" +
                          "        </div>" +
                          "    </div> <br /><br /><br /><br />");

            return _string.ToString();
        }
        #endregion RANSB
        #region NSNSB_CL
        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: Preview_NSNSB_CL
        /// Method : แสดงสัญญา NSNSB_CL พรีวิว
        /// Sample : N/A
        /// </summary>
        public static string Preview_NSNSB_CL(string _acaYear, string _studentId, string _studentCode)
        {
            StringBuilder _string = new StringBuilder();
            CurDate _date = new CurDate();
            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
            signCEOinfo _signInfo = new signCEOinfo(_acaYear);
            string _signCEO, _signCEOPosition; ;
            string _fatherName, _motherName;
            string _idCard, _stdNameTh, _birthDate, _age, _moo, _no, _soi, _road, _subdistrict, _district, _provice, _zipcode, _phone, _mobile;
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
            //_phone = Myconfig.CvEmpty(_stdInfo.Tel, " - ");
            _mobile = Myconfig.CvEmpty(_stdInfo.phoneSTD, " - ");
            _idCard = Myconfig.CvEmpty(_stdInfo.IdCard, " - ");


            _fatherName = _parentFInfo.FullNameTh;
            _motherName = _parentMInfo.FullNameTh;
            // _signCEO = Myconfig.GetSignCeoMahidol(_acaYear);
            _signCEO = Myconfig.CvEmpty(_signInfo.signNameCEO, " - ");
            _signCEOPosition = Myconfig.CvEmpty(_signInfo.SignCEOPosition, "-");

            _string.Append(@"   <div class='card-panel grey lighten-5'>
                                <div class='grey-text text-darken-4'>
                                    <div class='section'>
                                        <h5 class='center'>
                                            <img src='Images/logo.png' class='circle images' />
                                        </h5>
                                        <p class='center'><b><u>สัญญาการเป็นนักศึกษาเพื่อศึกษาวิชาพยาบาลศาสตรบัณฑิต</u></b></p>
                                    </div>
                                    <div class='section'>
                                        <div class='right'>
                                            สัญญาทำที่ มหาวิทยาลัยมหิดล<br />");
            _string.Append(@"                   วันที่ <b>" + _date.Day + "</b> เดือน <b>" + _date.MonthNameTh + "</b> พ.ศ. <b>" + _date.YearTh + "</b>");
            _string.Append(@"               </div>
                                    </div>
                                    <br />
                                    <div class='section'>
                                        <p style='text-indent: 4em;'>
                                            โดยที่มหาวิทยาลัยมหิดล มีความประสงค์ที่จะให้นักศึกษาในหลัสูตรพยาบาลศาสตรบัณฑิต ปฏิบัติงานที่ศูนย์วิจัยศึกษาและบำบัดโรคมะเร็ง สถาบันวิจัยจุฬาภรณ์ รับราชการ
                                            หรือทำงานสนองความต้องการของประเทศชาติภายหลังสำเร็จการศึกษาแล้วโดยที่
                                        </p>
                                    </div>");

            _string.Append(@"           <div class='section'>
                                        <p style='text-indent: 4em;'>");

            // show student prefile
            _string.Append(@"                   ข้าพเจ้า <span class='indigo-text text-darken-3'><b>" + _stdNameTh + "</b></span>");
            _string.Append(@"                   เกิดเมื่อวันที่ ");
            _string.Append(@"                   <span class='indigo-text text-darken-3'><b>" + _birthDate + "</b></span>");
            _string.Append(@"                   อายุ <span class='indigo-text text-darken-3'><b>" + _age + "</b></span> ปี ");
            _string.Append(@"                   ตั้งบ้านเรือนอยู่บ้านเลขที่ <span class='indigo-text text-darken-3'><b>" + _no + "</b></span>");
            _string.Append(@"                   หมู่ที่ <span class='indigo-text text-darken-3'><b>" + _moo + "</b></span>");
            _string.Append(@"                   ตรอก /ซอย <span class='indigo-text text-darken-3'><b>" + _soi + "</b></span>");
            _string.Append(@"                   ถนน <span class='indigo-text text-darken-3'><b>" + _road + " </b></span>");
            _string.Append(@"                   ตำบล /แขวง <span class='indigo-text text-darken-3'><b>" + _subdistrict + "</b></span>");
            _string.Append(@"                   อำเภอ/เขต <span class='indigo-text text-darken-3'><b>" + _district + "</b></span>");
            _string.Append(@"                   จังหวัด <span class='indigo-text text-darken-3'><b>" + _provice + "</b></span>");
            _string.Append(@"                   รหัสไปรษณีย์ <span class='indigo-text text-darken-3'><b>" + _zipcode + "</b></span>");
            _string.Append(@"                   โทรศัพท์  <span class='indigo-text text-darken-3'><b>" + _mobile + "</b></span>");
            _string.Append(@"                   เลขบัตรประจำตัวประชาชน <span class='indigo-text text-darken-3'><b>" + _idCard + "</b></span>");
            _string.Append(@"                   ชื่อบิดา <span class='indigo-text text-darken-3'><b>" + _fatherName + "</b></span>");
            _string.Append(@"                   ชื่อมารดา <span class='indigo-text text-darken-3'><b>" + _motherName + "</b></span>");
            _string.Append(@"                   เป็นผู้หนึ่งซึ่งประสงค์จะเข้าศึกษาในหลักสูตรพยาบาลศาสตรบัณฑิต คณะพยาบาลศาสตร์ เพื่อสนองความต้องการของ
                                            ประเทศชาติ ตามเจตจำนงของมหาวิทยาลัยมหิดล ดังกล่าวข้างต้น
                                        </p>
                                    </div>");

            _string.Append(@"           <div class='section'>
                                        <p class='center red-text'>ข้าพเจ้าจึงขอทำสัญญาให้ไว้แก่มหาวิทยาลัยมหิดล ซึ่งต่อไปในสัญญานี้เรียกว่า “มหาวิทยาลัย” ดังมีข้อความต่อไปนี้</p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 1</b> ข้าพเจ้าตกลงเข้าศึกษาในหลักสูตรพยาบาลศาสตรบัณฑิตที่มหาวิทยาลัย ตั้งแต่วันที่ทำสัญญาเป็นต้นไป จนกว่าจะสำเร็จการศึกษาตามหลักสูตร
                                        </p>

                                        <p style='text-indent: 4em;'>
                                           ในระหว่างที่ข้าพเจ้าเข้าศึกษาตามสัญญานี้ ข้าพเจ้ายินยอมประพฤติและปฏิบัติตามระเบียบข้อบังคับและคำสั่ง
                                            ของมหาวิทยาลัยที่กำหนดหรือสั่งไว้ทุกประการ ทั้งที่ได้ออกใช้บังคับอยู่ในวันที่ข้าพเจ้าลงลายมือชื่อในสัญญานี้ และที่
                                            ออกใช้บังคับในภายหน้าโดยเคร่งครัด และข้าพเจ้ายอมรับว่าระเบียบข้อบังคับและคำสั่งต่างๆ ดังกล่าวเป็นส่วนหนึ่งของ
                                            สัญญานี้ด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 2</b> ในระหว่างที่ข้าพเจ้าเข้าศึกษาตามสัญญานี้ ข้าพเจ้าจะตั้งใจและเพียรพยายามอย่างดีที่สุดในการศึกษาเล่า
                                                    เรียน โดยจะไม่หลีกเลี่ยง ละเลย ทอดทิ้ง ยุติ หรือเลิกการศึกษาก่อนสำเร็จการศึกษาตามหลักสูตร ดังที่ระบุไว้ในข้อ 1
                                                    ถ้าข้าพเจ้าลาออกก่อนศึกษาสำเร็จ หรือประพฤติตนไม่เหมาะสม หรือฝ่าฝืนระเบียบข้อบังคับของมหาวิทยาลัย
                                                    และมหาวิทยาลัยได้พิจารณาแล้วเห็นสมควรให้พ้นสภาพจากการเป็นนักศึกษา ข้าพเจ้ายินยอมชดใช้เงินให้แก่
                                                    มหาวิทยาลัย <b class='red-text'>โดยคิดเป็นเงินเดือนละ 3,000 บาท (สามพันบาทถ้วน)</b> นับตั้งแต่วันที่สัญญานี้มีผลใช้บังคับ
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 3</b> ในระหว่างที่ข้าพเจ้าเข้าศึกษาตามสัญญานี้ หากข้าพเจ้าเกิดเจ็บป่วยหรือพิการ และทางมหาวิทยาลัย
                                            เห็นว่าข้าพเจ้าไม่อาจ หรือไม่สามารถศึกษาตามสัญญานี้ต่อไปได้ ข้าพเจ้าจะไม่ต้องรับผิดชอบตามที่ระบุไว้ในข้อ 2
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 4</b> ภายหลังที่ข้าพเจ้าสำเร็จการศึกษาตามหลักสูตรแล้วข้าพเจ้ายินยอมปฏิบัติให้เป็นไปตามคำสั่งของ
                                            มหาวิทยาลัยในการจัดสรรให้ข้าพเจ้าเข้ารับราชการ หรือทำงานใน<span class='teal-text'>ศูนย์วิจัยศึกษาและบำบัดโรคมะเร็ง สถาบันวิจัยจุฬาภรณ์</span>
                                            ก่อนหน่วยงานอื่น หรือในส่วนราชการ หรือองค์การอื่นของรัฐบาล ซึ่งต่อไปในสัญญานี้เรียกว่า “หน่วยงาน” โดย
                                            ข้าพเจ้าจะรับราชการหรือทำงานในหน่วยงานนั้นเป็นเวลาติดต่อกัน<b class='red-text'>ไม่น้อยกว่าสามปี</b> นับแต่วันเริ่มเข้าทำงานในหน่วยงานนั้น
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            แต่ถ้าภายหลังจากสำเร็จการศึกษาตามหลักสูตรแล้ว มหาวิทยาลัยได้ให้ข้าพเจ้าเข้ารับการศึกษาอบรมเพิ่มเติม
                                            ตามความต้องการของหน่วยงานต่อไปอีก เมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ศึกษาเพิ่มเติมต่อไปจน
                                            สำเร็จด้วยเหตุใดก็ดี ข้าพเจ้ายินยอมเข้ารับราชการหรือทำงานตามที่มหาวิทยาลัยสั่งให้เข้ารับราชการ หรือทำงานใน
                                            หน่วยงานนั้น โดยจะรับราชการหรือทำงานติดต่อกันเป็นเวลา<b class='red-text'>ไม่น้อยกว่าสามปี</b> นับแต่วันเริ่มเข้ารับราชการ หรือทำงาน
                                            ในหน่วยงานนั้น    แต่ถ้าเป็นการเข้ารับการศึกษาอบรมเพิ่มเติมในระหว่างที่รับราชการหรือทำงานตามคำสั่งของ
                                            หน่วยงานที่จัดสรรให้ข้าพเจ้าไปทำงานเมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ศึกษาอบรมเพิ่มเติม
                                            ต่อไปจนสำเร็จด้วยเหตุใดก็ดี ข้าพเจ้ายินยอมเข้ารับราชการหรือทำงานต่อไปจนครบกำหนดเวลาไม่น้อยกว่าสามปี ทั้งนี้
                                            ไม่นับระยะเวลาระหว่างเข้ารับการศึกษาอบรมเพิ่มเติมรวมคำนวณเข้าด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                           ถ้าข้าพเจ้าไม่เข้ารับราชการหรือทำงานตามที่กล่าวในวรรคหนึ่ง หรือวรรคสองแล้วแต่กรณี ข้าพเจ้ายินยอม
                                            รับผิดชดใช้เงินให้แก่มหาวิทยาลัยเป็นจำนวนเงินทั้งสิ้น <b class='red-text'>144,000 บาท (หนึ่งแสนสี่หมื่นสี่พันบาทถ้วน)</b>
                                            ภายในกำหนดเวลาที่มหาวิทยาลัยเรียกร้องให้ชำระ
                                        </p>

                                        <p style='text-indent: 4em;'>
                                           ถ้าข้าพเจ้ารับราชการ หรือทำงานไม่ครบกำหนดเวลาตามที่กล่าวในวรรคหนึ่งหรือวรรคสอง แล้วแต่กรณี
                                            ข้าพเจ้ายินยอมรับผิดชดใช้เงินให้แก่มหาวิทยาลัยตามระยะเวลาที่ขาด โดยคิดคำนวณลดลงตามส่วนเฉลี่ยจากจำนวนเงิน
                                            ที่ต้อง ชดใช้ในวรรคสาม
                                        </p>
                                        <p style='text-indent: 4em;'>
                                           ถ้าการที่ข้าพเจ้ามิได้เข้ารับราชการหรือทำงานตามความในวรรคสาม หรือออกจากราชการหรือออกจากงาน
                                            ก่อนครบกำหนดดังกล่าวในวรรคสี่ เป็นเพราะเหตุที่ข้าพเจ้าเจ็บป่วยหรือพิการ และมหาวิทยาลัยได้พิจารณาแล้วเห็นว่า
                                            ข้าพเจ้าไม่อาจหรือไม่สามารถที่จะรับราชการหรือทำงานได้ ข้าพเจ้าจึงจะไม่ต้องรับผิดตามที่ระบุไว้ในวรรคสามหรือ
                                            วรรคสี่ แล้วแต่กรณี
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 5</b> ข้าพเจ้ายอมรับรู้ว่า เมื่อข้าพเจ้าสำเร็จการศึกษาตามหลักสูตรแล้ว หากมหาวิทยาลัยไม่รับข้าพเจ้า หรือ
                                            จัดสรรให้ข้าพเจ้าเข้ารับราชการหรือทำงานในหน่วยงาน ไม่ว่าด้วยเหตุประการใดก็ตาม ข้าพเจ้าจะไม่เรียกร้องสิทธิใด ๆ
                                            จากมหาวิทยาลัย ข้าพเจ้าถือว่ามหาวิทยาลัยไม่มีข้อผูกพันในการที่จะต้องหาสถานที่ทำงานให้ข้าพเจ้า และให้ถือว่า
                                            ข้าพเจ้าพ้นจากข้อผูกพันตามสัญญานี้ด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 6</b> เพื่อเป็นหลักประกันในการปฏิบัติตามสัญญานี้ ข้าพเจ้าจะจัดหาบุคคลที่มีคุณสมบัติ ซึ่งมหาวิทยาลัย
                                            เห็นสมควรทำสัญญาค้ำประกันข้าพเจ้า ภายในเวลาที่มหาวิทยาลัยกำหนด และในกรณีที่มหาวิทยาลัยเห็นสมควรให้
                                            ข้าพเจ้าเปลี่ยนผู้ค้ำประกันข้าพเจ้าจะปฏิบัติตามทุกประการ
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 7</b> ข้าพเจ้าสมัครใจที่จะเข้าร่วมศึกษาดูงาน หรือฝึกปฏิบัติงานภายนอกคณะพยาบาลศาสตร์ ซึ่งเป็นส่วนงาน
                                            หนึ่งของมหาวิทยาลัย ตามกำหนดของรายวิชาต่างๆ ซึ่งอยู่ในหลักสูตรพยาบาลศาสตรบัณฑิต ทั้งที่มีอยู่ในขณะนี้และที่จะมีขึ้นในภายหน้า
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 8</b>ในการศึกษาดูงานหรือฝึกปฏิบัติงานภายนอกคณะพยาบาลศาสตร์ มหาวิทยาลัยมหิดลตามข้อ 7
                                            ข้าพเจ้าจะประพฤติปฏิบัติตามระเบียบ ข้อบังคับ ประกาศของคณะพยาบาลศาสตร์ มหาวิทยาลัยมหิดลโดยเคร่งครัด
                                            ทั้งจะต้องใช้ความระมัดระวังในการปฏิบัติงานเพื่อให้สำเร็จตามจุดมุ่งหมายที่กำหนดไว้ ข้าพเจ้าจะไม่ก่อให้เกิด
                                            ความเสียหายไม่ว่ากรณีใด ๆ แก่ตัวข้าพเจ้าและบุคคลอื่น ในการศึกษาดูงานหรือฝึกปฏิบัติงานภายนอก
                                            คณะพยาบาลศาสตร์ มหาวิทยาลัยมหิดล ตามความในข้อ 7 หากข้าพเจ้าได้รับความเสียหาย ไม่ว่าจะเกิดจาก
                                            การกระทำของข้าพเจ้าหรือจากบุคคลอื่น ไม่ว่าจะเป็นผลโดยตรงหรือต่อเนื่องหรือที่เกี่ยวข้องกับมหาวิทยาลัยมหิดล
                                            ข้าพเจ้าจะมีสิทธิได้รับเพียงเงินสงเคราะห์ สำหรับนักศึกษามหาวิทยาลัยมหิดล และสิทธิประโยชน์จาการประอุบัติเหตุ
                                            ที่ข้าพเจ้าและหรือคณะพยาบาลศาสตร์  มหาวิทยาลัยมหิดล ได้ทำประกันไว้เท่านั้น
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 9</b> ข้อ 9 กรณีที่คณะพยาบาลศาสตร์ มหาวิทยาลัยมหิดล ได้ชำระเงินค่าเสียหายแก่บุคคลภายนอกแทนข้าพเจ้า
                                            ไม่ว่ากรณีใด ๆ อันเกิดจากการที่ข้าพเจ้าปฏิบัติฝ่าฝืนความในข้อ 8 วรรคแรก ข้าพเจ้ายินยอมรับผิดชดใช้เงินค่าเสียหาย
                                            คืนแก่คณะพยาบาลศาสตร์ มหาวิทยาลัยมหิดล พร้อมดอกเบี้ยในอัตราร้อยละ 15 ต่อปี นับจากวันที่คณะพยาบาลศาสตร์
                                            มหาวิทยาลัยมหิดล ได้ชำระเงินให้แก่บุคคลภายนอก นอกจากนี้ข้าพเจ้ายังต้องรับผิดชดใช้ค่าใช้จ่ายต่างๆ
                                            อันเป็นผลสืบเนื่องจากการฝ่าฝืนนั้นด้วย
                                        </p>
                                            <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 10</b>สัญญานี้ให้มีผลบังคับตั้งแต่วันถัดจากวันลงนามในสัญญาเป็นต้นไป
                                        </p>
                                        <p class='center red-text'>ข้าพเจ้าได้ทราบและเข้าใจข้อความในสัญญาฉบับนี้ดีแล้ว จึงได้ลงนามในสัญญานี้ไว้เป็นหลักฐาน</p>
                                    </div>");

            _string.Append("            <div class='section'>" +
                          "                <div class='right'>" +
                                           _stdNameTh + "  นักศึกษา<br /><br />" +
                                           _signCEO +
                          "                <p>" + _signCEOPosition + "</p>" +
                          "            </div>" +
                          "        </div>" +
                          "    </div> <br /><br /><br /><br />");

            return _string.ToString();
        }
        #endregion NSNSB_CL
        #region NSNSB_TM
        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: NSNSB_TM_Preview
        /// Method : แสดงสัญญา NSNSB_TM พรีวิว
        /// Sample : N/A
        /// </summary>

        public static string Preview_NSNSB_TM(string _acaYear, string _studentId, string _studentCode)
        {
            StringBuilder _string = new StringBuilder();
            CurDate _date = new CurDate();
            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
            signCEOinfo _signInfo = new signCEOinfo(_acaYear);
            string _signCEO, _signCEOPosition; ;
            string _fatherName, _motherName;
            string _idCard, _stdNameTh, _birthDate, _age, _moo, _no, _soi, _road, _subdistrict, _district, _provice, _zipcode, _phone, _mobile;
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
            //_phone = Myconfig.CvEmpty(_stdInfo.Tel, " - ");
            _mobile = Myconfig.CvEmpty(_stdInfo.phoneSTD, " - ");
            _idCard = Myconfig.CvEmpty(_stdInfo.IdCard, " - ");


            _fatherName = _parentFInfo.FullNameTh;
            _motherName = _parentMInfo.FullNameTh;
            //_signCEO = Myconfig.GetSignCeoMahidol(_acaYear);
            _signCEO = Myconfig.CvEmpty(_signInfo.signNameCEO, " - ");
            _signCEOPosition = Myconfig.CvEmpty(_signInfo.SignCEOPosition, "-");

            _string.Append(@"   <div class='card-panel grey lighten-5'>
                                <div class='grey-text text-darken-4'>
                                    <div class='section'>
                                        <h5 class='center'>
                                            <img src='Images/logo.png' class='circle images' />
                                        </h5>
                                        <p class='center'><b><u>สัญญาการเป็นนักศึกษาเพื่อศึกษาวิชาพยาบาลศาสตรบัณฑิต</u></b></p>
                                    </div>
                                    <div class='section'>
                                        <div class='right'>
                                            สัญญาทำที่ มหาวิทยาลัยมหิดล<br />");
            _string.Append(@"                   วันที่ <b>" + Myconfig._day + "</b> เดือน <b>" + Myconfig._monthstring + "</b> พ.ศ. <b>" + Myconfig._year + "</b>");
            _string.Append(@"               </div>
                                    </div>
                                    <br />
                                    <div class='section'>
                                        <p style='text-indent: 4em;'>
                                            โดยที่มหาวิทยาลัยมหิดล มีความประสงค์ที่จะให้นักศึกษาในหลัสูตรพยาบาลศาสตรบัณฑิต ปฏิบัติงานที่โรงพยาบาลเวชศาสตร์เขตร้อน คณะเวชศาสตร์เขตร้อน มหาวิทยาลัยมหิดล รับราชการ
                                            หรือทำงานสนองความต้องการของประเทศชาติภายหลังสำเร็จการศึกษาแล้วโดยที่
                                        </p>
                                    </div>");

            // show student prefile
            _string.Append(@"           <div class='section'>
                                        <p style='text-indent: 4em;'>");
            _string.Append(@"                   ข้าพเจ้า <span class='indigo-text text-darken-3'><b>" + _stdNameTh + "</b></span>");
            _string.Append(@"                   เกิดเมื่อวันที่ ");
            _string.Append(@"                   <span class='indigo-text text-darken-3'><b>" + _birthDate + "</b></span>");
            _string.Append(@"                   อายุ <span class='indigo-text text-darken-3'><b>" + _age + "</b></span> ปี ");
            _string.Append(@"                   ตั้งบ้านเรือนอยู่บ้านเลขที่ <span class='indigo-text text-darken-3'><b>" + _no + "</b></span>");
            _string.Append(@"                   หมู่ที่ <span class='indigo-text text-darken-3'><b>" + _moo + "</b></span>");
            _string.Append(@"                   ตรอก /ซอย <span class='indigo-text text-darken-3'><b>" + _soi + "</b></span>");
            _string.Append(@"                   ถนน <span class='indigo-text text-darken-3'><b>" + _road + " </b></span>");
            _string.Append(@"                   ตำบล /แขวง <span class='indigo-text text-darken-3'><b>" + _subdistrict + "</b></span>");
            _string.Append(@"                   อำเภอ/เขต <span class='indigo-text text-darken-3'><b>" + _district + "</b></span>");
            _string.Append(@"                   จังหวัด <span class='indigo-text text-darken-3'><b>" + _provice + "</b></span>");
            _string.Append(@"                   รหัสไปรษณีย์ <span class='indigo-text text-darken-3'><b>" + _zipcode + "</b></span>");
            _string.Append(@"                   โทรศัพท์  <span class='indigo-text text-darken-3'><b>" + _mobile + "</b></span>");
            _string.Append(@"                   เลขบัตรประจำตัวประชาชน <span class='indigo-text text-darken-3'><b>" + _idCard + "</b></span>");
            _string.Append(@"                   ชื่อบิดา <span class='indigo-text text-darken-3'><b>" + _fatherName + "</b></span>");
            _string.Append(@"                   ชื่อมารดา <span class='indigo-text text-darken-3'><b>" + _motherName + "</b></span>");
            _string.Append(@"                   เป็นผู้หนึ่งซึ่งประสงค์จะเข้าศึกษาในหลักสูตรพยาบาลศาสตรบัณฑิต คณะพยาบาลศาสตร์ เพื่อสนองความต้องการของ
                                            ประเทศชาติ ตามเจตจำนงของมหาวิทยาลัยมหิดล ดังกล่าวข้างต้น
                                        </p>
                                    </div>");
            _string.Append(@"           <div class='section'>
                                        <p class='center red-text'>ข้าพเจ้าจึงขอทำสัญญาให้ไว้แก่มหาวิทยาลัยมหิดล ซึ่งต่อไปในสัญญานี้เรียกว่า “มหาวิทยาลัย” ดังมีข้อความต่อไปนี้</p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 1</b> ข้าพเจ้าตกลงเข้าศึกษาในหลักสูตรพยาบาลศาสตรบัณฑิตที่มหาวิทยาลัย ตั้งแต่วันที่ทำสัญญาเป็นต้นไป จนกว่าจะสำเร็จการศึกษาตามหลักสูตร
                                        </p>

                                        <p style='text-indent: 4em;'>
                                           ในระหว่างที่ข้าพเจ้าเข้าศึกษาตามสัญญานี้ ข้าพเจ้ายินยอมประพฤติและปฏิบัติตามระเบียบข้อบังคับและคำสั่ง
                                            ของมหาวิทยาลัยที่กำหนดหรือสั่งไว้ทุกประการ ทั้งที่ได้ออกใช้บังคับอยู่ในวันที่ข้าพเจ้าลงลายมือชื่อในสัญญานี้ และที่
                                            ออกใช้บังคับในภายหน้าโดยเคร่งครัด และข้าพเจ้ายอมรับว่าระเบียบข้อบังคับและคำสั่งต่างๆ ดังกล่าวเป็นส่วนหนึ่งของ
                                            สัญญานี้ด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 2</b> ในระหว่างที่ข้าพเจ้าเข้าศึกษาตามสัญญานี้ ข้าพเจ้าจะตั้งใจและเพียรพยายามอย่างดีที่สุดในการศึกษาเล่า
                                                    เรียน โดยจะไม่หลีกเลี่ยง ละเลย ทอดทิ้ง ยุติ หรือเลิกการศึกษาก่อนสำเร็จการศึกษาตามหลักสูตร ดังที่ระบุไว้ในข้อ 1
                                                    ถ้าข้าพเจ้าลาออกก่อนศึกษาสำเร็จ หรือประพฤติตนไม่เหมาะสม หรือฝ่าฝืนระเบียบข้อบังคับของมหาวิทยาลัย
                                                    และมหาวิทยาลัยได้พิจารณาแล้วเห็นสมควรให้พ้นสภาพจากการเป็นนักศึกษา ข้าพเจ้ายินยอมชดใช้เงินให้แก่
                                                    มหาวิทยาลัย <b class='red-text'>โดยคิดเป็นเงินเดือนละ 4,500 บาท (สี่พันห้าร้อยบาทถ้วน)</b> นับตั้งแต่วันที่สัญญานี้มีผลใช้บังคับ
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 3</b> ในระหว่างที่ข้าพเจ้าเข้าศึกษาตามสัญญานี้ หากข้าพเจ้าเกิดเจ็บป่วยหรือพิการ และทางมหาวิทยาลัย
                                            เห็นว่าข้าพเจ้าไม่อาจ หรือไม่สามารถศึกษาตามสัญญานี้ต่อไปได้ ข้าพเจ้าจะไม่ต้องรับผิดชอบตามที่ระบุไว้ในข้อ 2
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 4</b> ภายหลังที่ข้าพเจ้าสำเร็จการศึกษาตามหลักสูตรแล้วข้าพเจ้ายินยอมปฏิบัติให้เป็นไปตามคำสั่งของ
                                            มหาวิทยาลัยในการจัดสรรให้ข้าพเจ้าเข้ารับราชการ หรือทำงานใน<span class='teal-text'>โรงพยาบาลเวชศาสตร์เขตร้อน คณะเวชศาสตร์เขตร้อน</span>
                                            ก่อนหน่วยงานอื่น หรือในส่วนราชการ หรือองค์การอื่นของรัฐบาล ซึ่งต่อไปในสัญญานี้เรียกว่า “หน่วยงาน” โดย
                                            ข้าพเจ้าจะรับราชการหรือทำงานในหน่วยงานนั้นเป็นเวลาติดต่อกัน<b class='red-text'>ไม่น้อยกว่าสี่ปี</b> นับแต่วันเริ่มเข้าทำงานในหน่วยงานนั้น
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            แต่ถ้าภายหลังจากสำเร็จการศึกษาตามหลักสูตรแล้ว มหาวิทยาลัยได้ให้ข้าพเจ้าเข้ารับการศึกษาอบรมเพิ่มเติม
                                            ตามความต้องการของหน่วยงานต่อไปอีก เมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ศึกษาเพิ่มเติมต่อไปจน
                                            สำเร็จด้วยเหตุใดก็ดี ข้าพเจ้ายินยอมเข้ารับราชการหรือทำงานตามที่มหาวิทยาลัยสั่งให้เข้ารับราชการ หรือทำงานใน
                                            หน่วยงานนั้น โดยจะรับราชการหรือทำงานติดต่อกันเป็นเวลา<b class='red-text'>ไม่น้อยกว่าสี่ปี</b> นับแต่วันเริ่มเข้ารับราชการ หรือทำงาน
                                            ในหน่วยงานนั้น    แต่ถ้าเป็นการเข้ารับการศึกษาอบรมเพิ่มเติมในระหว่างที่รับราชการหรือทำงานตามคำสั่งของ
                                            หน่วยงานที่จัดสรรให้ข้าพเจ้าไปทำงานเมื่อข้าพเจ้าได้ศึกษาอบรมเพิ่มเติมเสร็จแล้ว หรือไม่ได้ศึกษาอบรมเพิ่มเติม
                                            ต่อไปจนสำเร็จด้วยเหตุใดก็ดี ข้าพเจ้ายินยอมเข้ารับราชการหรือทำงานต่อไปจนครบกำหนดเวลาไม่น้อยกว่าสี่ปี ทั้งนี้
                                            ไม่นับระยะเวลาระหว่างเข้ารับการศึกษาอบรมเพิ่มเติมรวมคำนวณเข้าด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                           ถ้าข้าพเจ้าไม่เข้ารับราชการหรือทำงานตามที่กล่าวในวรรคหนึ่ง หรือวรรคสองแล้วแต่กรณี ข้าพเจ้ายินยอม
                                            รับผิดชดใช้เงินให้แก่มหาวิทยาลัยเป็นจำนวนเงินทั้งสิ้น <b class='red-text'>400,000 บาท (สี่แสนบาทถ้วน)</b>
                                            ภายในกำหนดเวลาที่มหาวิทยาลัยเรียกร้องให้ชำระ
                                        </p>

                                        <p style='text-indent: 4em;'>
                                           ถ้าข้าพเจ้ารับราชการ หรือทำงานไม่ครบกำหนดเวลาตามที่กล่าวในวรรคหนึ่งหรือวรรคสอง แล้วแต่กรณี
                                            ข้าพเจ้ายินยอมรับผิดชดใช้เงินให้แก่มหาวิทยาลัยตามระยะเวลาที่ขาด โดยคิดคำนวณลดลงตามส่วนเฉลี่ยจากจำนวนเงิน
                                            ที่ต้อง ชดใช้ในวรรคสาม
                                        </p>
                                        <p style='text-indent: 4em;'>
                                           ถ้าการที่ข้าพเจ้ามิได้เข้ารับราชการหรือทำงานตามความในวรรคสาม หรือออกจากราชการหรือออกจากงาน
                                            ก่อนครบกำหนดดังกล่าวในวรรคสี่ เป็นเพราะเหตุที่ข้าพเจ้าเจ็บป่วยหรือพิการ และมหาวิทยาลัยได้พิจารณาแล้วเห็นว่า
                                            ข้าพเจ้าไม่อาจหรือไม่สามารถที่จะรับราชการหรือทำงานได้ ข้าพเจ้าจึงจะไม่ต้องรับผิดตามที่ระบุไว้ในวรรคสามหรือ
                                            วรรคสี่ แล้วแต่กรณี
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 5</b> ข้าพเจ้ายอมรับรู้ว่า เมื่อข้าพเจ้าสำเร็จการศึกษาตามหลักสูตรแล้ว หากมหาวิทยาลัยไม่รับข้าพเจ้า หรือ
                                            จัดสรรให้ข้าพเจ้าเข้ารับราชการหรือทำงานในหน่วยงาน ไม่ว่าด้วยเหตุประการใดก็ตาม ข้าพเจ้าจะไม่เรียกร้องสิทธิใด ๆ
                                            จากมหาวิทยาลัย ข้าพเจ้าถือว่ามหาวิทยาลัยไม่มีข้อผูกพันในการที่จะต้องหาสถานที่ทำงานให้ข้าพเจ้า และให้ถือว่า
                                            ข้าพเจ้าพ้นจากข้อผูกพันตามสัญญานี้ด้วย
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 6</b> เพื่อเป็นหลักประกันในการปฏิบัติตามสัญญานี้ ข้าพเจ้าจะจัดหาบุคคลที่มีคุณสมบัติ ซึ่งมหาวิทยาลัย
                                            เห็นสมควรทำสัญญาค้ำประกันข้าพเจ้า ภายในเวลาที่มหาวิทยาลัยกำหนด และในกรณีที่มหาวิทยาลัยเห็นสมควรให้
                                            ข้าพเจ้าเปลี่ยนผู้ค้ำประกันข้าพเจ้าจะปฏิบัติตามทุกประการ
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 7</b> ข้าพเจ้าสมัครใจที่จะเข้าร่วมศึกษาดูงาน หรือฝึกปฏิบัติงานภายนอกคณะพยาบาลศาสตร์ ซึ่งเป็นส่วนงาน
                                            หนึ่งของมหาวิทยาลัย ตามกำหนดของรายวิชาต่างๆ ซึ่งอยู่ในหลักสูตรพยาบาลศาสตรบัณฑิต ทั้งที่มีอยู่ในขณะนี้และที่จะมีขึ้นในภายหน้า
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 8</b>ในการศึกษาดูงานหรือฝึกปฏิบัติงานตามข้อ 7 ข้าพเจ้าจะประพฤติปฏิบัติตามระเบียบ ข้อบังคับ
                                                ประกาศของคณะพยาบาลศาสตร์ โดยเคร่งครัด ทั้งจะต้องใช้ความระมัดระวังในการปฏิบัติงานเพื่อให้สําเร็จตาม
                                                จุดมุ่งหมายที่กําหนดไว้ ข้าพเจ้าจะไม่ก่อให้เกิดความเสียหายไม่ว่ากรณีใดๆ แก่ตัวข้าพเจ้าและบุคคลอื่น
                                                ในการศึกษาดูงาน หรือฝึกปฏิบัติงานตามความในข้อ 7 หากข้าพเจ้าได้รับความเสียหาย
                                                ไม่ว่าจะเกิดจากการกระทําของข้าพเจ้าหรือจากบุคคลอื่น ไม่ว่าจะเป็นผลโดยตรงหรือต่อเนื่องหรือที่เกี่ยวข้อง
                                                กับมหาวิทยาลัย ข้าพเจ้าจะมีสิทธิได้รับเพียงเงิน สงเคราะห์ สําหรับนักศึกษามหาวิทยาลัยมหิดล และสิทธิประโยชน์จาการประสพอุบัติเหตุที่
                                                ข้าพเจ้าและหรือคณะพยาบาลศาสตร์ ได้ทําประกันไว้เท่านั้น
                                        </p>

                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 9</b> กรณีที่คณะพยาบาลศาสตร์ มหาวิทยาลัยมหิดล ได้ชำระเงินค่าเสียหายแก่บุคคลภายนอกแทนข้าพเจ้า
                                            ไม่ว่ากรณีใด ๆ อันเกิดจากการที่ข้าพเจ้าปฏิบัติฝ่าฝืนความในข้อ 8 วรรคแรก ข้าพเจ้ายินยอมรับผิดชดใช้เงินค่าเสียหาย
                                            คืนแก่คณะพยาบาลศาสตร์ มหาวิทยาลัยมหิดล พร้อมดอกเบี้ยในอัตราร้อยละ 15 ต่อปี นับจากวันที่คณะพยาบาลศาสตร์
                                            มหาวิทยาลัยมหิดล ได้ชำระเงินให้แก่บุคคลภายนอก นอกจากนี้ข้าพเจ้ายังต้องรับผิดชดใช้ค่าใช้จ่ายต่าง ๆ
                                            อันเป็นผลสืบเนื่องจากการฝ่าฝืนนั้นด้วย
                                        </p>
                                        <p style='text-indent: 4em;'>
                                            <b class='deep-purple-text'>ข้อ 10</b>สัญญานี้ให้มีผลบังคับตั้งแต่วันถัดจากวันลงนามในสัญญาเป็นต้นไป
                                        </p>
                                        <p class='center red-text'>ข้าพเจ้าได้ทราบและเข้าใจข้อความในสัญญาฉบับนี้ดีแล้ว จึงได้ลงนามในสัญญานี้ไว้เป็นหลักฐาน</p>
                                    </div>");

            _string.Append("            <div class='section'>" +
                          "                <div class='right'>" +
                                           _stdNameTh + "  นักศึกษา<br /><br />" +
                                           _signCEO +
                          "                <p>" + _signCEOPosition + "</p>" +
                          "            </div>" +
                          "        </div>" +
                          "    </div> <br /><br /><br /><br />");

            return _string.ToString();
        }
        #endregion NSNSB_TM

        #region Preview_Warrant
        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: Preview_Warrant
        /// Method : แสดงสัญญา ค้ำประกัน พรีวิว HTML
        /// Sample : N/A
        /// </summary>
        public static string Preview_Warrant(string _studentId, string _parentType, string _studentCode)
        {
            StudentInfo _stdInfo = new StudentInfo(_studentCode);//ข้อมูลนักศึกษา
            ParentInfo _parentInfo = new ParentInfo(_studentId, _parentType);//ข้อมูลผู้ปกครอง
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");//ข้อมูลเมื่อมารดาเป็นผู้ค้ำประกัน
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");//ข้อมูลเมื่อบิดาเป็นผู้ค้ำประกัน
            ContractInfo _ctInfo = new ContractInfo(_studentId);//ข้อมูลสัญญานักศึกษา
            CurDate _date = new CurDate();
            StringBuilder _string = new StringBuilder();

            //ข้อมูลนักศึกษา
            string _stdNameTh = string.Empty
                 , _programNameTh = string.Empty
                 , _groupNameTh = string.Empty
                 , _warrantCoverage = string.Empty
                 , _txtWarrantCoverage = string.Empty
                 , _operatingRange = string.Empty;

            _stdNameTh = Myconfig.CvEmpty(_stdInfo.StdNameTh, " - ");
            _programNameTh = Myconfig.CvEmpty(_stdInfo.ProgramNameTh, " - ");
            _groupNameTh = Myconfig.CvEmpty(_stdInfo.GroupNameTh, " - ");
            _warrantCoverage = Myconfig.CvEmpty(_stdInfo.WarrantCoverage, " - ");
            _txtWarrantCoverage = Myconfig.CvEmpty(_stdInfo.TxtWarrantCoverage, " - ");
            _operatingRange = Myconfig.CvEmpty(_stdInfo.OperatingRange, " - ");


            //ข้อมูลผู้ค้ำประกันจากที่นักศึกษาเลือก
            string _idCard = string.Empty
                 , _fullNameTh = string.Empty
                 , _fullNameMarTh = string.Empty
                 , _age = string.Empty
                 , _moo = string.Empty
                 , _no = string.Empty
                 , _soi = string.Empty
                 , _road = string.Empty
                 , _subdistrict = string.Empty
                 , _thOccupation = string.Empty
                 , _district = string.Empty
                 , _provice = string.Empty
                 , _zipcode = string.Empty
                 , _phoneNumberPermanent = string.Empty
                 , _mobileNumberPermanent = string.Empty
                 , _position = string.Empty
                 , _agencyNameTH = string.Empty;
            string _dateContract = _ctInfo.DateLongContractStudent;
            string _warrantBy = _ctInfo.WarrantBy;
            string _consentBy = _ctInfo.ConsentBy;
            string _aliveF = _ctInfo.IsAliveFather;//สถานะบิดา 1=มีชีวิต , 2 = เสียชีวิต
            string _aliveM = _ctInfo.IsAliveMother;//สถานะมารดา 1=มีชีวิต , 2 = เสียชีวิต
            string _marriage = _ctInfo.IsMarriage;//1=สมรส,2=สมรส(ไม่ได้จดทะเบียน),3=บิดามารดาหย่าร้าง,4=แยกกันอยู่,5=หม้าย,6=โสด
            string _relationship = _ctInfo.relationship;//เกียวพันกับนักศึกษาโดยเป็น บิดา หรือ มารดา หรือ บุคคลอื่น

            //ข้อมูลเมื่อมารดาเป็นผู้ค้ำประกัน
            if (_warrantBy == "M")
            {
                if (_marriage == "1" && _aliveF == "1") //สถานะสมรสจดทะเบียน บิดามีชีวิต
                {
                    _fullNameMarTh = Myconfig.CvEmpty(_parentFInfo.FullNameTh, " - "); //ลายเซ็นบิดายินยอมคู่สมรสของผู้ค้ำประกัน
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
                _phoneNumberPermanent = Myconfig.CvEmpty(_parentMInfo.PhoneNumberPermanent, " - ");
                _mobileNumberPermanent = Myconfig.CvEmpty(_parentMInfo.MobileNumberPermanent, " - ");
                _idCard = Myconfig.CvEmpty(_parentMInfo.IdCard, " - ");
                _thOccupation = Myconfig.CvEmpty(_parentMInfo.ThOccupation, " - ");
                _position = Myconfig.CvEmpty(_parentMInfo.Position, " - ");
                _agencyNameTH = Myconfig.CvEmpty(_parentMInfo.AgencyNameTH, " - ");
            }
            //ข้อมูลเมื่อบิดาเป็นผู้ค้ำประกัน
            else if (_warrantBy == "F")
            {
                if (_marriage == "1" && _aliveM == "1") //สถานะสมรสจดทะเบียน มารดามีชีวิต
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
                _phoneNumberPermanent = Myconfig.CvEmpty(_parentFInfo.PhoneNumberPermanent, " - ");
                _mobileNumberPermanent = Myconfig.CvEmpty(_parentFInfo.MobileNumberPermanent, " - ");
                _idCard = Myconfig.CvEmpty(_parentFInfo.IdCard, " - ");
                _thOccupation = Myconfig.CvEmpty(_parentFInfo.ThOccupation, " - ");
                _position = Myconfig.CvEmpty(_parentFInfo.Position, " - ");
                _agencyNameTH = Myconfig.CvEmpty(_parentFInfo.AgencyNameTH, " - ");
            }
            //ไม่พบข้อมูลผู้ค้ำประกันที่เป็น F และ M
            else
            {
                _fullNameTh = " - ";
                _fullNameMarTh = " - ";
                _age = " - ";
                _moo = " - ";
                _no = " - ";
                _soi = " - ";
                _road = " - ";
                _subdistrict = " - ";
                _district = " - ";
                _provice = " - ";
                _zipcode = " - ";
                _phoneNumberPermanent = " - ";
                _mobileNumberPermanent = " - ";
                _idCard = " - ";
                _thOccupation = " - ";
                _position = " - ";
                _agencyNameTH = " - ";

            }


            // เนื้อหาสัญญาค้ำประกัน
            // show header
            _string.Append("    <div class='card-panel grey lighten-5'>" +
                           "        <div class='grey-text text-darken-4'>" +
                           "            <div class='section'>" +
                           "                 <h5 class='center'>" +
                           "                     <img src='Images/logo.png' class='circle images' /></h5>" +
                           "                     <p class='center'><b><u>สัญญาค้ำประกันการเป็นนักศึกษาวิชา" + _groupNameTh + "</u></b></p>" +
                           "            </div>" +
                           "            <div class='section'>" +
                           "                 <div class='right'>" +
                           "                    สัญญาทำที่ มหาวิทยาลัยมหิดล<br />" +
                           "                    วันที่ <b>" + _date.Day + "</b> เดือน <b>" + _date.MonthNameTh + "</b> พ.ศ. <b>" + _date.YearTh + "</b>" +
                           "                </div>" +
                           "            </div><br><br>");

            _string.Append(@"   <div class='section'>
                                <p style='text-indent: 4em;'>");
            _string.Append(@"           ข้าพเจ้า <span class='indigo-text text-darken-3'><b><u>" + _fullNameTh + "</u></b></span>");
            _string.Append(@"           อายุ <span class='indigo-text text-darken-3'><b><u>" + _age + "</u></b></span> ปี ");
            _string.Append(@"           อาชีพ <span class='indigo-text text-darken-3'><b><u>" + _thOccupation + "</u></b></span>");
            _string.Append(@"           ตำแหน่ง <span class='indigo-text text-darken-3'><b><u>" + _position + "</u></b></span>");
            _string.Append(@"           สังกัด <span class='indigo-text text-darken-3'><b><u>" + _agencyNameTH + "</u></b></span>");
            _string.Append(@"           อยู่บ้านเลขที่ <span class='indigo-text text-darken-3'><b><u>" + _no + "</u></b></span>");
            _string.Append(@"           หมู่ที่ <span class='indigo-text text-darken-3'><b><u>" + _moo + "</u></b></span>");
            _string.Append(@"           ตรอก /ซอย <span class='indigo-text text-darken-3'><b><u>" + _soi + "</u></b></span>");
            _string.Append(@"           ถนน <span class='indigo-text text-darken-3'><b><u>" + _road + "</u></b></span>");
            _string.Append(@"           ตำบล /แขวง <span class='indigo-text text-darken-3'><b><u>" + _subdistrict + "</u></b></span>");
            _string.Append(@"           อำเภอ/เขต <span class='indigo-text text-darken-3'><b><u>" + _district + "</u></b></span>");
            _string.Append(@"           จังหวัด <span class='indigo-text text-darken-3'><b><u>" + _provice + "</u></b></span>");
            _string.Append(@"           รหัสไปรษณีย์ <span class='indigo-text text-darken-3'><b><u>" + _zipcode + "</u></b></span>");
            _string.Append(@"           โทรศัพท์บ้าน  <span class='indigo-text text-darken-3'><b><u>" + _phoneNumberPermanent + "</u></b></span>");
            _string.Append(@"           โทรศัพท์เคลื่อนที่  <span class='indigo-text text-darken-3'><b><u>" + _mobileNumberPermanent + "</u></b></span>");
            _string.Append(@"           เลขบัตรประจำตัวประชาชน <span class='indigo-text text-darken-3'><b><u>" + _idCard + "</u></b></span>");
            _string.Append(@"           คู่สมรสชื่อ (ถ้ามี) <span class='indigo-text text-darken-3'><b><u>" + _fullNameMarTh + "</u></b></span>");
            _string.Append(@"           ขอทำสัญญาค้ำประกันฉบับนี้ให้ไว้ต่อมหาวิทยาลัยมหิดล ซึ่งต่อไปในสัญญานี้เรียกว่า “มหาวิทยาลัย”  ดังมีข้อความต่อไปนี้");
            _string.Append(@"       </p>");
            _string.Append(@"   </div>");

            _string.Append(@"   <div class='section'>
                                <p style='text-indent: 4em;'>");
            _string.Append(@"           <b class='deep-purple-text'>ข้อ ๑.</b>ข้าพเจ้าได้ทราบและเข้าใจข้อความในสัญญาการเป็นนักศึกษาเพื่อศึกษาวิชา" + _programNameTh + " ที่ ");
            _string.Append(@"           <span class='blue-text text-darken-3'><b><u>" + _stdNameTh + "</u></b></span>");
            _string.Append(@"           ซึ่งต่อไปในสัญญานี้เรียกว่า “นักศึกษา”  ได้ทำให้ไว้ต่อมหาวิทยาลัย  ตามสัญญาฉบับลงวันที่ <span class='blue-text text-darken-3'><b><u>" + _dateContract + "</u></b></span>");
            _string.Append(@"           ปรากฏตามสำเนาสัญญาการเป็นนักศึกษาวิชา" + _programNameTh + "");
            _string.Append(@"           แนบท้ายสัญญานี้แล้ว ข้าพเจ้าขอให้สัญญาว่า ถ้านักศึกษากระทำผิดสัญญาการเป็นนักศึกษาดังกล่าวที่ให้ไว้ต่อมหาวิทยาลัย 
                                    เป็นเหตุให้เกิดความรับผิดต้องชดใช้เงินให้แก่มหาวิทยาลัย และมหาวิทยาลัยได้มีหนังสือบอกกล่าวไปยังข้าพเจ้าภายใน ๖๐ (หกสิบ) 
                                    วันนับแต่วันที่นักศึกษาผิดนัดแล้ว ข้าพเจ้าตกลงยินยอมรับผิดชดใช้เงินไม่เกินกว่าจำนวนเงินที่นักศึกษาต้องรับผิดตามข้อผูกพันที่ระบุไว้ในสัญญาการเป็นนักศึกษาข้างต้นนั้น 
                                    รวมทั้งดอกเบี้ย ค่าสินไหมทดแทน ค่าฤชาธรรมเนียม ค่าภาระติดพันอันเป็นอุปกรณ์แห่งหนี้รายนี้  และค่าเสียหายใดๆ บรรดาที่มหาวิทยาลัยมีสิทธิเรียกร้องกับนักศึกษาทั้งสิ้น 
                                    ให้แก่มหาวิทยาลัยจนครบถ้วนภายใน กำหนดเวลาที่มหาวิทยาลัยมีหนังสือบอกกล่าวให้ข้าพเจ้าชำระหนี้ และข้าพเจ้าจะรับผิดตามสัญญาค้ำประกันนี้ตลอดไปจนกว่าจะมีการชำระหนี้ 
                                    ครบเต็มตามจำนวน ทั้งนี้ไม่เกินวงเงินค้ำประกันจำนวน <span class='red-text'><u>" + _warrantCoverage + @"</u></span> บาท  " + _txtWarrantCoverage + @"  ในกรณีที่มหาวิทยาลัยไม่ได้มีหนังสือบอกกล่าวไปยังข้าพเจ้าภายใน ๖๐ (หกสิบ) 
                                    วันนับแต่วันที่นักศึกษาผิดนัด ก็ให้ข้าพเจ้าหลุดพ้นจากความรับผิดในดอกเบี้ย ค่าสินไหมทดแทน 
                                    ตลอดจนค่าภาระติดพันอันเป็นอุปกรณ์แห่งหนี้ตามสัญญาการเป็นนักศึกษาดังกล่าวเฉพาะที่เกิดขึ้นภายหลังจากล่วงพ้น ๖๐ (หกสิบ) วันแล้ว</p>
                                    <p style='text-indent: 4em;'>
                                    ในกรณีที่นักศึกษาได้รับอนุญาตจากมหาวิทยาลัยให้ขยายเวลาอยู่ศึกษาต่อด้วยทุนหรือเงินอื่นใดหรือเหตุใดๆ ก็ตาม 
                                    แม้การขยายเวลาอยู่ศึกษาต่อนั้น จะมีการเปลี่ยนแปลงสาขาวิชา ระดับการศึกษา หรือสถานศึกษาที่ศึกษาไปจากเดิม 
                                    และมหาวิทยาลัยได้มีหนังสือแจ้งให้ข้าพเจ้าทราบแล้ว ให้ถือว่าข้าพเจ้าตกลงรับเป็นผู้ค้ำประกันนักศึกษาต่อไปอีกตลอดระยะเวลาที่นักศึกษาได้รับการขยายเวลาอยู่ศึกษาต่อดังกล่าวด้วย
                                    </p>");
            _string.Append(@"       <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>ข้อ ๒.</b> หากมีการผ่อนเวลาหรือผ่อนจำนวนเงินในการชำระหนี้ตามสัญญาการเป็นนักศึกษาให้แก่นักศึกษา 
                                    โดยได้มีหนังสือแจ้งให้ข้าพเจ้าทราบ และข้าพเจ้าได้ตกลงยินยอมในการผ่อนเวลาหรือผ่อนจำนวนเงินในการชำระหนี้นั้น 
                                    ให้ถือว่าข้าพเจ้ายินยอมมิให้ถือเอาการผ่อนเวลาหรือผ่อนจำนวนในการชำระหนี้ดังกล่าวเป็นเหตุปลดเปลื้องควมรับผิดของข้าพเจ้า 
                                    และข้าพเจ้าจะรับผิดในฐานะผู้ค้ำประกันตามสัญญานี้ตลอดไปจนกว่าจะมีการชำระหนี้ครบตามจำนวน 
                                    แต่ไม่เกินกว่าระยะเวลาในการก่อหนี้ค้ำประกันตามที่กำหนดไว้ในข้ ๕ ของสัญญาค้ำประกันนี้ 
                                    หรือไม่เกินกว่าระยะเวลาอยู่ศึกษาต่อของนักศึกษาที่ขยายออกไปตากข้อ ๑ วรรคสองของสัญญาค้ำประกันนี้ 
                                        ในกรณีที่การพิจารณาอนุมัติจากมหาวิทยาลัยให้นักศึกษาขยายเวลาอยู่ศึกษาต่อ จะทำให้ระยะเวลาในการก่อหนี้
                                    ค้ำประกันเกินกว่าระยะเวลาตามที่กำหนดไว้ในข้อ ๕ ของสัญญาค้ำประกันนั้น เมื่อมหาวิทยาลัยได้มีหนังสือแจ้งข้าพเจ้า 
                                    และข้าพเจ้าได้ยินยอมด้วยแล้ว ข้าพเจ้าตกลงจะมาทำสัญญาค้ำประกันฉบับใหม่เพื่อให้การค้ำประกันของข้าพเจ้าครอบคลุมระยะเวลาในการก่อหนี้
                                    ที่จะค้ำประกันตามที่นักศึกษาจะได้รับอนุมัติให้ขยายเวลาอยู่ศึกษาต่อด้วย และถึงแม้ข้าพเจ้าจะไม่มาทำสัญญาค้ำประกันฉบับใหม่ 
                                    แต่ถ้าหากข้าพเจ้าได้ให้ความยินยอมในการขยายเวลาอยู่ศึกษาต่อแล้ว ให้ถือว่าข้าพเจ้ายังตกลงรับเป็นผู้ค้ำประกันนักศึกษาต่อไปอีก
                                    ตลอดระยะเวลาที่นักศึกษาได้รับการขยายเวลาอยู่ศึกษาต่อตามที่ได้กำหนดไว้ในข้อ ๑ วรรคสอง ของสัญญาค้ำประกันกันนี้
                                </p>");

            _string.Append(@"       <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>ข้อ ๓.</b> ข้าพเจ้าจะไม่ยกเลิกเพิกถอนการค้ำประกันไม่ว่ากรณีใดๆ ตลอดระยะเวลาที่นักศึกษายังต้องรับผิดชอบอยู่ตามเงื่อนไขในสัญญาการเป็นนักศึกษา
                                </p>");

            _string.Append(@"       <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>ข้อ ๔.</b> เพื่อเป็นหลักฐานในการค้ำประกัน ข้าพเจ้าขอยืนยันว่าข้าพเจ้าเป็นบุคคลที่มีคุณสมบัติตรงตามหลักเกณฑ์และเงื่อนไขที่มหาวิทยาลัยกำหนด โดยมีรายละเอียดในข้อใดข้อหนึ่งดังต่อไปนี้
                                </p>");

            _string.Append(@"       <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>ข้อ ๔.๑</b> ข้าพเจ้ามีความเกี่ยวพันกับนักศึกษา โดยเป็น <span class='red-text'><u>" + _relationship + @"</u></span> ของนักศึกษา หรือ
                                </p>");

            _string.Append(@"       <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>ข้อ ๔.๒</b> ข้าพเจ้าเป็นข้าราชการ/พนักงานรัฐวิสาหกิจ/เจ้าหน้าที่ของรัฐ ตำแหน่ง_______________________ระดับ____
                                    สังกัด________________________โดยได้รับเงินเดือน____________บาท (__________________________________) หรือ
                                </p>");

            _string.Append(@"       <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>ข้อ ๔.๓</b> ข้าพเจ้าขอรับรองว่าข้าพเจ้าเป็นเจ้าของกรรมสิทธิ์ที่ดิน โดยปลอดจากภาระผูกพันใดๆ ทั้งสิ้นตามกฎหมาย 
                                    ปรากฏตามโฉนดเลขที่_______________หน้าสำรวจ___________ระวาง_________เนื้อที่________ไร่____________
                                    งาน___________วา อยู่ที่ตำบล/แขวง__________________อำเภอ/เขต________________จังหวัด__________________
                                    ราคาประมาณ____________________บาท (__________________________________) และข้าพเจ้าตกลงจะไม่จำหน่าย 
                                    โอน ก่อหนี้สิน หรือภาระผูกพันใดๆ  ในที่ดินของข้าพเจ้าตามที่ระบุในข้อ ๔.๓ นี้ ตลอดระยะเวลาที่สัญญาค้ำประกันฉบับนี้มี
                                    ผลใช้บังคับอยู่ เว้นแต่จะได้รับความยินยอมเป็นหนังสือจากมหาวิทยาลัยก่อน
                                </p>");

            _string.Append(@"       <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>ข้อ ๕.</b> ระยะเวลาในการก่อหนี้ค้ำประกันตามสัญญานี้ ให้เริ่มตั้งแต่วันที่นักศึกษาทำสัญญาการเป็นนักศึกษา" + _groupNameTh + @" 
                                    จนถึงวันที่นักศึกษาได้ปฏิบัติราชการหรือปฏิบัติงานครบถ้วนตามสัญญาการเป็นนักศึกษาดังกล่าว แต่ไม่เกิน " + _operatingRange + @" ปี_________ (________) เดือน_______ (________) วัน
                                </p>");

            _string.Append(@"       <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>ข้อ ๖.</b>อยู่ของข้าพเจ้าที่ปรากฏในสัญญาค้ำประกันนี้ ให้ถือเป็นภูมิลำเนาของข้าพเจ้า การส่งหนังสือหรือ
                                    เอกสารเพื่อบอกกล่าว แจ้ง หรือทวงถาม ไปยังข้าพเจ้า ให้ส่งไปยังภูมิลำเนาดังกล่าว และถือว่าเป็นการส่งโดยชอบ โดยถือว่า
                                    ข้าพเจ้าได้ทราบข้อความในหนังสือหรือเอกสารดังกล่าว นับแต่วันที่หนังสือหรือเอกสารไปถึงภูมิลำเนาของข้าพเจ้า ไม่ว่า
                                    ข้าพเจ้าหรือบุคคลอื่นใดที่พำนักอยู่ในภูมิลำเนาของข้าพเจ้าจะได้รับหนังสือ หรือเอกสารนั้นหรือไม่ก็ตาม
                                </p>");

            _string.Append(@"       <p style='text-indent: 4em;'>
                                    หากข้าพเจ้าเปลี่ยนแปลงภูมิลำเนา ข้าพเจ้าจะต้องมีหนังสือแจ้งเปลี่ยนแปลงภูมิลำเนามายังมหาวิทยาลัย 
                                    หรือได้บันทึกถ้อยคำการเปลี่ยนแปลงภูมิลำเนาดังกล่าวให้มหาวิทยาลัยทราบ หากมหาวิทยาลัยได้ส่งหนังสือหรือเอกสารเพื่อ
                                    บอกกล่าว แจ้ง หรือทวงถามไปยังข้าพเจ้าตามที่ปรากฏอยู่ในสัญญาค้ำประกันนี้ ให้ถือว่าข้าพเจ้าได้ทราบข้อความในหนังสือ
                                    หรือเอกสารดังกล่าวโดยชอบแล้ว
                                </p>");
            _string.Append(@" </div>");

            // sign
            _string.Append(@"   <div class='section'>
                                <p class='center red-text'> ข้าพเจ้าได้อ่านและเข้าใจข้อความในสัญญาค้ำประกันฉบับนี้โดยละเอียดดีแล้ว จึงได้ลงลายมือชื่อไว้เป็นสำคัญต่อหน้าพยาน</p>
                            </div>");
            _string.Append(@"   <div class='section'>
                                <div class='right'>");
            _string.Append(@"           <span class='blue-text text-darken-2'>(ลงนาม)&nbsp;&nbsp;<b><u>" + _fullNameTh + "</u></b></span>&nbsp;&nbsp;ผู้ค้ำประกัน<br/><br/>");
            _string.Append(@"            <span class='blue-text text-darken-2'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;( <u>" + _fullNameTh + "</u> )</span><br/><br/>");
            _string.Append(@"       </div>");
            _string.Append(@"   </div><br><br><br>");

            //พยาน1
            _string.Append(@"   <div class='section'>
                                <div class='right'>");
            _string.Append(@"           <span class='blue-text text-darken-2'>(ลงนาม)______________________</span> พยาน<br/><br/>");
            _string.Append(@"           <span class='blue-text text-darken-2'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(___________________________)<span/>");
            _string.Append(@"       </div>");
            _string.Append(@"   </div><br><br><br><br>");

            //พยาน2
            _string.Append(@"   <div class='section'>
                                <div class='right'>");
            _string.Append(@"           <span class='blue-text text-darken-2'>(ลงนาม)______________________</span> พยาน<br/><br/>");
            _string.Append(@"           <span class='blue-text text-darken-2'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(___________________________)<span/>");
            _string.Append(@"       </div>");
            _string.Append(@"   </div><br><br><br><br>");


            _string.Append(@"   </div>
                        </div><br><br>");

            //end sign


            //หนังสือยินยอมคู่สมรส
            //string _signCur = Myconfig.CvEmpty(_parentInfo.FullNameTh, " - ");

            _string.Append(Preview_Consent(_ctInfo, _parentInfo, _parentMInfo, _parentFInfo, _parentType, _stdInfo));

            //จบหนังสือยินยอม

            return _string.ToString();
        }
        #endregion Preview_Warrant

        #region Preview_Consent
        /// Auther : anussara.wan
        /// Date   : 2017-08-20
        /// Perpose: Preview_Consent
        /// Method : สัญญาค้ำประกัน ส่วนของ หนังสือให้ความยินยอมของคู่สมรสผู้ค้ำประกัน
        /// Sample : N/A
        public static string Preview_Consent(ContractInfo _ctInfo, ParentInfo _parentInfo, ParentInfo _parentMInfo, ParentInfo _parentFInfo, string _parentType, StudentInfo _stdInfo)
        {
            StringBuilder _string = new StringBuilder();
            CurDate _date = new CurDate();
            //นักศึกษา
            string _strStudentProgram = string.Empty;
            _strStudentProgram = Myconfig.CvEmpty(_stdInfo.StrStudentProgram, " - ");

            string _idCard = ""
                 , _fullNameTh = ""
                 , _fullNameTh1 = ""
                 , _age = "";
            string _dateSign = Myconfig.CvEmpty(_ctInfo.DateLongContractParent2, "");
            if (_dateSign == "")
            {
                _dateSign = _date.Day + " " + _date.MonthNameTh + " " + _date.YearTh;
            }
            //ข้อมูลบิดา
            //ผู้ให้ควมยินยอมคู่สมรส
            //parent sign

            string _signCur = Myconfig.CvEmpty(_parentInfo.FullNameTh, " - ");
            string _consentBy = _ctInfo.ConsentBy;//ยินยอมโดย
            string _warrantBy = _ctInfo.WarrantBy;//ค้ำประกัน
            string _aliveF = _ctInfo.IsAliveFather;//สถานะพ่อ 1=มีชีวิต , 2 = เสียชีวิต
            string _aliveM = _ctInfo.IsAliveMother;//สถานะแม่ 1=มีชีวิต , 2 = เสียชีวิต
            string _marriage = _ctInfo.IsMarriage;//1=สมรส,2=สมรส(ไม่ได้จดทะเบียน),3=บิดามารดาหย่าร้าง
            string _remark = "";//หมายเหตุ
            string _assure1 = "", _assure2 = "", _assure3 = "";
            string _ckeckSts = "<img src='Images/assure.gif' width='20' height='20' />";
            string _uncheckSts = "<img src='Images/notassure.gif' width='20' height='20' />";
            //---กรณีสมรสกันบิดาและมารดายังมีชีวิตอยู่ทั้งคู่
            if (_marriage == "1")
            {
                if (_aliveF == "1" && _aliveM == "1")
                {
                    if (_consentBy == "F")//แม่ค้ำ พ่อยินยอมคู่สมรส
                    {
                        _fullNameTh = Myconfig.CvEmpty(_parentFInfo.FullNameTh, " - ");
                        _fullNameTh1 = Myconfig.CvEmpty(_parentMInfo.FullNameTh, " - ");
                        _age = Myconfig.CvEmpty(_parentFInfo.Age, " - ");
                        _idCard = Myconfig.CvEmpty(_parentFInfo.IdCard, " - ");

                    }
                    else if (_consentBy == "M")//พ่อค้ำ แม่ยินยอมคู่สมรส
                    {
                        _fullNameTh = Myconfig.CvEmpty(_parentMInfo.FullNameTh, " - ");//ผู้ให้ความยินยอม
                        _fullNameTh1 = Myconfig.CvEmpty(_parentFInfo.FullNameTh, " - ");//ผู้ค้ำ
                        _age = Myconfig.CvEmpty(_parentMInfo.Age, " - ");
                        _idCard = Myconfig.CvEmpty(_parentMInfo.IdCard, " - ");

                    }
                    else
                    {
                        _fullNameTh = " - ";
                        _fullNameTh1 = " - ";
                        _age = " - ";
                        _idCard = " - ";
                    }
                }
                else if (_aliveM == "1" && _aliveF == "2")
                {
                    _fullNameTh = " - ";
                    _fullNameTh1 = " - ";
                    _age = " - ";
                    _idCard = " - ";
                    _dateSign = "-";
                    _remark = "หมายเหตุ : บิดาเสียชีวิต";
                    _assure2 = "X";//คู่สมรสตาย
                }
                else if (_aliveM == "2" && _aliveF == "1")
                {
                    _fullNameTh = " - ";
                    _fullNameTh1 = " - ";
                    _age = " - ";
                    _idCard = " - ";
                    _dateSign = "-";
                    _remark = "หมายเหตุ : มารดาเสียชีวิต";
                    _assure2 = "X";//คู่สมรสตาย
                }
            }
            else
            {
                //---กรณี ไม่สมรสจดทะเบียน,หย่าร้าง
                _fullNameTh = "-";
                _fullNameTh1 = " - ";
                _age = " - ";
                _idCard = " - ";
                _signCur = "-";
                _dateSign = "-";
                if (_marriage == "2")//สมรส (ไม่จดทะเบียน)
                {
                    _remark = "หมายเหตุ : บิดามารดาไม่ได้จดทะเบียนสมรสกัน";
                    _assure1 = "X";//เป็นโสด
                }
                else if (_marriage == "3")
                {
                    _remark = "หมายเหตุ : บิดามารดาหย่าร้าง";
                    _assure3 = "X";//หย่า
                }
            }

            string _dieSts = _assure2 == "X" ? _ckeckSts : _uncheckSts;
            string _singleSts = _assure1 == "X" ? _ckeckSts : _uncheckSts;
            string _divorceSts = _assure3 == "X" ? _ckeckSts : _uncheckSts;

            //ผู้ค้ำประกัน ไม่ใช่ คนเดียวกันกับผู้ยินยอม
            if (_warrantBy != _consentBy)
            {
                _string.Append("    <div class='card-panel grey lighten-5'>" +
                               "        <div class='grey-text text-darken-4'>");

                _string.Append(@"   <div class='section'>
                                <p class='center'><b><u>หนังสือให้ความยินยอมของคู่สมรสผู้ค้ำประกัน</u></b></p>");
                _string.Append(@"   <p style='text-indent: 4em;'>");
                _string.Append(@"           ข้าพเจ้า <span class='teal-text text-darken-3'><b><u>" + _fullNameTh + "</u></b></span>");
                _string.Append(@"           อายุ <span class='teal-text text-darken-3'><b><u>" + _age + "</u></b></span> ปี ");
                _string.Append(@"           เลขบัตรประจำตัวประชาชน <span class='teal-text text-darken-3'><b><u>" + _idCard + "</u></b></span>");
                _string.Append(@"           เป็นคู่สมรสของ <span class='teal-text text-darken-3'><b><u>" + _fullNameTh1 + "</u></b></span>");
                _string.Append(@"           ได้รับทราบข้อความในสัญญาค้ำประกันที่");
                _string.Append(@"           <span class='teal-text text-darken-3'><b><u>" + _fullNameTh1 + "</u></b></span>");
                _string.Append(@"           ได้ทำให้ไว้ต่อมหาวิทยาลัยมหิดลตามสัญญาฉบับลงวันที่");
                _string.Append(@"           <span class='teal-text text-darken-3'><b><u>" + _dateSign + "</u></b></span>");
                _string.Append(@"           แล้วขอให้ความยินยอมในการที่ ");
                _string.Append(@"           <span class='teal-text text-darken-3'><b><u>" + _fullNameTh1 + "</u></b></span>");
                _string.Append(@"           ได้ทำสัญญาดังกล่าวให้ไว้ต่อมหาวิทยาลัยมหิดลทุกประการ");
                _string.Append(@"       </p>");
                _string.Append(@"   </div>");

                _string.Append(@"   <div class='section'>
                                <div class='right'>");
                _string.Append(@"           <span class='blue-text text-darken-2'>(ลงนาม)&nbsp;<b><u>" + _fullNameTh + "</u></b></span> &nbsp;ผู้ให้ความยินยาอม<br /><br />");
                _string.Append(@"           <span class='blue-text text-darken-2'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;<u>" + _fullNameTh + @"</u>&nbsp;)<span/>");
                _string.Append(@"       </div>
                            </div><br><br><br>");


                _string.Append(@"   <div class='section'>");
                _string.Append(@"   ข้าพเจ้าขอรับรองว่าไม่มีคู่สมรสโดย&nbsp; " + _singleSts + @" เป็นโสด&nbsp; " + _dieSts + @" คู่สมรสตาย&nbsp; " + _divorceSts + @" หย่า ในขณะที่ทำสัญญานี้        ");
                _string.Append(@"</div><br>");


                _string.Append(@"   <div class='section'>
                                <div class='right'>");
                _string.Append(@"           <span class='blue-text text-darken-2'>รหัสประจำตัวนักศึกษา<b><u>&nbsp;&nbsp;&nbsp;" + _strStudentProgram + "&nbsp;&nbsp;&nbsp;</u></b></span><br /><br />");
                _string.Append(@"       </div>
                            </div><br><br><br><br>");
                _string.Append(@"       </div>
                            </div>");

            }
            else
            {
                //_string.Append("    <div class='card-panel grey lighten-5'>" +
                //                  "        <div class='grey-text text-darken-4'>");

                //_string.Append(@"   <div class='section'>
                //                    <p class='center'><b><u>หนังสือให้ความยินยอมของคู่สมรสผู้ค้ำประกัน</u></b></p>");
                //_string.Append(@"       <p>");
                //_string.Append(@"           ข้าพเจ้า <span class='teal-text text-darken-3'><b>" + _fullNameTh + "</b></span>");
                //_string.Append(@"           อายุ <span class='teal-text text-darken-3'><b>" + _age + "</b></span> ปี ");
                //_string.Append(@"           เลขบัตรประจำตัวประชาชน <span class='teal-text text-darken-3'><b>" + _idCard + "</b></span>");
                //_string.Append(@"           เป็นคู่สมรสของ <span class='teal-text text-darken-3'><b>" + _fullNameTh1 + "</b></span>");
                //_string.Append(@"           ได้รับทราบข้อความในสัญญาค้ำประกันที่");
                //_string.Append(@"           <span class='teal-text text-darken-3'><b>" + _fullNameTh1 + "</b></span>");
                //_string.Append(@"           ได้ทำให้ไว้ต่อมหาวิทยาลัยมหิดลตามสัญญาฉบับลงวันที่");
                //_string.Append(@"           <span class='teal-text text-darken-3'><b>" + _dateSign + "</b></span>");
                //_string.Append(@"           แล้วขอให้ความยินยอมในการที่ ");
                //_string.Append(@"           <span class='teal-text text-darken-3'><b>" + _fullNameTh1 + "</b></span>");
                //_string.Append(@"           ได้ทำสัญญาดังกล่าวให้ไว้ต่อมหาวิทยาลัยมหิดลทุกประการ");
                //_string.Append(@"       </p>");
                //_string.Append(@"   </div>");

                //_string.Append(@"   <div class='section'>
                //                    <div class='right'>");
                //_string.Append(@"           <span class='blue-text text-darken-2'><b>" + _fullNameTh + "</b></span> คู่สมรส<br /><br />");
                //_string.Append(@"       </div>
                //                </div><br><br><br><br>");
                //_string.Append(@"   <div class='section'>
                //                    <div class='left'>");
                //_string.Append(@"           <span class='blue-text text-darken-2'><b>" + _remark + "</b></span><br /><br />");
                //_string.Append(@"       </div>
                //                </div><br><br><br><br>");

                //_string.Append(@"       </div>
                //                </div>");

                _string.Append("    <div class='card-panel grey lighten-5'>" +
                               "        <div class='grey-text text-darken-4'>");

                _string.Append(@"   <div class='section'>
                                <p class='center'><b><u>หนังสือให้ความยินยอมของคู่สมรสผู้ค้ำประกัน</u></b></p>");
                _string.Append(@"   <p style='text-indent: 4em;'>");
                _string.Append(@"           ข้าพเจ้า <span class='teal-text text-darken-3'><b><u>" + _fullNameTh + "</u></b></span>");
                _string.Append(@"           อายุ <span class='teal-text text-darken-3'><b><u>" + _age + "</u></b></span> ปี ");
                _string.Append(@"           เลขบัตรประจำตัวประชาชน <span class='teal-text text-darken-3'><b><u>" + _idCard + "</u></b></span>");
                _string.Append(@"           เป็นคู่สมรสของ <span class='teal-text text-darken-3'><b><u>" + _fullNameTh1 + "</u></b></span>");
                _string.Append(@"           ได้รับทราบข้อความในสัญญาค้ำประกันที่");
                _string.Append(@"           <span class='teal-text text-darken-3'><b><u>" + _fullNameTh1 + "</u></b></span>");
                _string.Append(@"           ได้ทำให้ไว้ต่อมหาวิทยาลัยมหิดลตามสัญญาฉบับลงวันที่");
                _string.Append(@"           <span class='teal-text text-darken-3'><b><u>" + _dateSign + "</u></b></span>");
                _string.Append(@"           แล้วขอให้ความยินยอมในการที่ ");
                _string.Append(@"           <span class='teal-text text-darken-3'><b><u>" + _fullNameTh1 + "</u></b></span>");
                _string.Append(@"           ได้ทำสัญญาดังกล่าวให้ไว้ต่อมหาวิทยาลัยมหิดลทุกประการ");
                _string.Append(@"       </p>");
                _string.Append(@"   </div>");

                _string.Append(@"   <div class='section'>
                                <div class='right'>");
                _string.Append(@"           <span class='blue-text text-darken-2'>(ลงนาม)&nbsp;<b><u>" + _fullNameTh + "</u></b></span> &nbsp;ผู้ให้ความยินยาอม<br /><br />");
                _string.Append(@"           <span class='blue-text text-darken-2'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;" + _fullNameTh + @"&nbsp;)<span/>");
                _string.Append(@"       </div>
                            </div><br><br><br>");


                _string.Append(@"   <div class='section'>");
                _string.Append(@"   ข้าพเจ้าขอรับรองว่าไม่มีคู่สมรสโดย&nbsp; " + _singleSts + @" เป็นโสด&nbsp; " + _dieSts + @" คู่สมรสตาย&nbsp; " + _divorceSts + @" หย่า ในขณะที่ทำสัญญานี้        ");
                _string.Append(@"</div><br>");


                _string.Append(@"   <div class='section'>
                                <div class='right'>");
                _string.Append(@"           <span class='blue-text text-darken-2'>รหัสประจำตัวนักศึกษา<b><u>&nbsp;&nbsp;&nbsp;" + _strStudentProgram + "&nbsp;&nbsp;&nbsp;</u></b></span><br /><br />");
                _string.Append(@"       </div>
                            </div><br><br><br><br>");
                _string.Append(@"       </div>
                            </div>");
            }

            return _string.ToString();
        }
        #endregion Preview_Consent

        #region Preview_Guarantee
        /// <summary>
        /// Auther : Odd.Nopparat
        /// Date   : 2015-11-20.
        /// Perpose: Preview_Guarantee
        /// Method : แสดงหนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม พรีวิว HTML
        /// Sample : N/A
        /// </summary>
        public static string Preview_Guarantee(string _studentId, string _parentType, string _studentCode)
        {
            StringBuilder _string = new StringBuilder();

            StudentInfo _stdInfo = new StudentInfo(_studentCode);
            ParentInfo _parentInfo = new ParentInfo(_studentId, _parentType);
            ParentInfo _parentMInfo = new ParentInfo(_studentId, "M");
            ParentInfo _parentFInfo = new ParentInfo(_studentId, "F");
            ContractInfo _ctInfo = new ContractInfo(_studentId);
            CurDate _date = new CurDate();
            string _warrantBy = _ctInfo.WarrantBy;
            string _consentBy = _ctInfo.ConsentBy;

            string _stdNameTh, _programNameTh;
            //ข้อมูลนักศึกษา
            _stdNameTh = Myconfig.CvEmpty(_stdInfo.StdNameTh, " - ");
            _programNameTh = Myconfig.CvEmpty(_stdInfo.ProgramNameTh, " - ");



            string _idCard, _fullNameTh, _age, _moo, _no, _soi, _road, _subdistrict
                , _district, _provice, _zipcode, _phone;

            string _signFather, _signMother;

            string _dateContract = _ctInfo.DateLongContractStudent;

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


            //header
            _string.Append("    <div class='card-panel grey lighten-5'>" +
                           "        <div class='grey-text text-darken-4'>" +
                           "            <div class='section'>" +
                           "                 <h5 class='center'>" +
                           "                 <img src='Images/logo.png' class='circle images' /></h5>" +
                           "                 <p class='center'><b><u>หนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม</u></b></p>" +
                           "            </div>" +
                           "            <div class='section'>" +
                           "                    <div class='right'>" +
                           "                    สัญญาทำที่ มหาวิทยาลัยมหิดล<br />" +
                           "                    วันที่ <b>" + _date.Day + "</b> เดือน <b>" + _date.MonthNameTh + "</b> พ.ศ. <b>" + _date.YearTh + "</b></div>" +
                           "            </div><br><br>");
            // end header

            // show father profile
            _string.Append(@"   <div class='section'>
                                <p style='text-indent: 4em;'>");
            _string.Append(@"           ข้าพเจ้า <span class='indigo-text text-darken-3'><b><u>" + _fullNameTh + " (บิดา)</u></b></span>");
            _string.Append(@"           อายุ <span class='indigo-text text-darken-3'><b><u>" + _age + "</u></b></span> ปี ");
            _string.Append(@"           อยู่บ้านเลขที่ <span class='indigo-text text-darken-3'><b><u>" + _no + "</u></b></span>");
            _string.Append(@"           หมู่ที่ <span class='indigo-text text-darken-3'><b><u>" + _moo + "</u></b></span>");
            _string.Append(@"           ตรอก /ซอย <span class='indigo-text text-darken-3'><b><u>" + _soi + "</u></b></span>");
            _string.Append(@"           ถนน <span class='indigo-text text-darken-3'><b><u>" + _road + "</u></b></span>");
            _string.Append(@"           ตำบล /แขวง <span class='indigo-text text-darken-3'><b><u>" + _subdistrict + "</u></b></span>");
            _string.Append(@"           อำเภอ/เขต <span class='indigo-text text-darken-3'><b><u>" + _district + "</u></b></span>");
            _string.Append(@"           จังหวัด <span class='indigo-text text-darken-3'><b><u>" + _provice + "</u></b></span>");
            _string.Append(@"           รหัสไปรษณีย์ <span class='indigo-text text-darken-3'><b><u>" + _zipcode + "</u></b></span>");
            _string.Append(@"           โทรศัพท์  <span class='indigo-text text-darken-3'><b><u>" + _phone + "</u></b></span>");
            _string.Append(@"           เลขบัตรประจำตัวประชาชน <span class='indigo-text text-darken-3'><b><u>" + _idCard + "</u></b></span>");
            _string.Append(@"       </p>
                            </div>");

            //end father profile


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


            _string.Append(@"   <div class='section'>
                                <p style='text-indent: 4em;'>");
            _string.Append(@"           และข้าพเจ้า <span class='purple-text text-darken-3'><b><u>" + _fullNameTh + " (มารดา)</u></b></span>");
            _string.Append(@"           อายุ <span class='purple-text text-darken-3'><b><u>" + _age + "</u></b></span> ปี ");
            _string.Append(@"           อยู่บ้านเลขที่ <span class='purple-text text-darken-3'><b><u>" + _no + "</u></b></span>");
            _string.Append(@"           หมู่ที่ <span class='purple-text text-darken-3'><b><u>" + _moo + "</u></b></span>");
            _string.Append(@"           ตรอก /ซอย <span class='purple-text text-darken-3'><b><u>" + _soi + "</u></b></span>");
            _string.Append(@"           ถนน <span class='purple-text text-darken-3'><b><u>" + _road + "</u></b></span>");
            _string.Append(@"           ตำบล /แขวง <span class='purple-text text-darken-3'><b><u>" + _subdistrict + "</u></b></span>");
            _string.Append(@"           อำเภอ/เขต <span class='purple-text text-darken-3'><b><u>" + _district + "</u></b></span>");
            _string.Append(@"           จังหวัด <span class='purple-text text-darken-3'><b><u>" + _provice + "</u></b></span>");
            _string.Append(@"           รหัสไปรษณีย์ <span class='purple-text text-darken-3'><b><u>" + _zipcode + "</u></b></span>");
            _string.Append(@"           โทรศัพท์  <span class='purple-text text-darken-3'><b><u>" + _phone + "</u></b></span>");
            _string.Append(@"           เลขบัตรประจำตัวประชาชน <span class='purple-text text-darken-3'><b><u>" + _idCard + "</u></b></span>");
            _string.Append(@"       </p>
                            </div>");

            // end mother profile


            // abs contract



            _string.Append(@"   <div class='section'>
                                <p>เป็นผู้แทนโดยชอบธรรมตามกฎหมายของ ");
            _string.Append("            <span class='teal-text text-darken-2'><b><u>" + _stdNameTh + " นักศึกษา" + _programNameTHGuarantee + "</u></b></span>");// <--ชื่อ นศ.

            _string.Append("            โดยได้ทราบข้อความในสัญญาการเป็นนักศึกษาเพื่อศึกษา" + _forProgramNameTHGuarantee + "ที่ ");
            _string.Append("            <span class='teal-text text-darken-2'><b><u>" + _stdNameTh + "</u></b></span>");// <--ชื่อ นศ.

            _string.Append("            ได้ทำให้ไว้ต่อมหาวิทยาลัยมหิดล ตามสัญญาฉบับลงวันที่ ");
            _string.Append("            <span class='teal-text text-darken-2'><b><u>" + _dateContract + "</u></b></span> แล้ว");// <--ชื่อ นศ.

            _string.Append("            ขอแสดงความยินยอมในการที่ ");
            _string.Append("            <span class='teal-text text-darken-2'><b><u>" + _stdNameTh + "</u></b></span>");// <--ชื่อ นศ.

            _string.Append(@"           ได้ทำสัญญาดังกล่าว ให้ไว้ต่อมหาวิทยาลัยมหิดลทุกประการ
                                </p>
                            </div>");
            // ens abs

            // sign father and mother
            _string.Append(@"   <div class='section'>
                                <div class='right'>");
            _string.Append("            <span class='blue-text text-darken-2'><b><u>" + _signFather + "</u></b></span> (บิดา)<br /><br />");  // <--ชื่อ บิดา
            _string.Append("            <span class='blue-text text-darken-2'><b><u>" + _signMother + "</u></b></span> (มารดา)");  // <--ชื่อ มารดา
            _string.Append(@"       </div>
                            </div><br><br><br><br>");

            _string.Append(@"    </div>
                        </div><br><br>");

            // end sign
            return _string.ToString();
        }
        #endregion Preview_Guarantee
        public static string _programNameTHGuarantee { get; set; }

        public static string _forProgramNameTHGuarantee { get; set; }
    }
}