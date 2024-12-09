<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="false" EnableEventValidation="false" CodeBehind="Default.aspx.cs" Inherits="eContract._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MU-Contract</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="msapplication-tap-highlight" content="no" />
    <meta name="description" content="Mahidol University, MU Contract,ทำสัญญาการเป็นนักศึกษา, มหาวิทยาลัยมหิดล" />
    <link rel="apple-touch-icon-precomposed" href="images/logo.png" />
    <meta name="msapplication-TileColor" content="#FFFFFF" />
    <meta name="msapplication-TileImage" content="images/logo.png" />
    <link rel="icon" href="images/logo.png" sizes="32x32" />
    <!--  Android 5 Chrome Color-->
    <meta name="theme-color" content="#EE6E73" />
    <%--   <style type="text/css">
       body{       
           filter:gray;
           webbit-filter:grayscale(100%);
           filter:grayscale(100%);
       }
   </style>--%>
</head>
<body class="" style="background-color: #F2F0EF">
    <!-- navigater bar -->
    <nav id="navBar" runat="server" style="background-color: #253988" role='navigation'></nav>
    <!-- parallax banner -->
    <div id="divBanner" runat="server">
    </div>

    <div>
    </div>
    <a class="waves-effect waves-light btn modal-trigger" href="#modal1">ระบบสัญญาอิเล็กทรอนิกส์ e-Contract</a>

    <%--    <!-- Modal Trigger -->
  <a class="modal-trigger waves-effect waves-light btn" href="#modal1">Modal</a>--%>

    <!-- Modal Structure -->
    <div id="modal1" class="modal modal-fixed-footer">
        <div class="modal-content">
            <%--     <h4>Modal Header</h4>
      <p>A bunch of text</p>--%>

            <div class='card-panel grey lighten-5'>
                <div class='grey-text text-darken-4'>
                    <div class='section'>
<%--                        <p style='text-align: center; font-family: TH Sarabun New; font-size: 32px; color: darkred; font-weight: bold;'>ปิดปรับปรุงระบบชั่วคราว ขออภัยในความไม่สะดวก</p>
                        <p style='text-align: center; font-family: TH Sarabun New; font-size: 32px; color: darkred; font-weight: bold;'>ระบบจะเปิดให้ใช้บริการอีกครั้ง ในวันที่ 6/9/2566</p>--%>
                        <%--<div class='col s12 m12 l12'><center><img src='Images/announce2563-1.png' alt='' class='responsive-img' /></center></div>--%>
                        <%--<p class='center red-text' style="font-family:TH Sarabun New;font-size:16px"><b>ประกาศ !!! เนื่องจากระบบสัญญาอิเล็กทรอนิกส์ (E-contract) มีการแก้ไขรายละเอียดของสัญญาเพื่อให้สมบูรณ์</b></p>
                                            <p class='center red-text' style="font-family:TH Sarabun New;font-size:16px"><b>ครบถ้วน และเป็นไปตามกฎหมายที่เกี่ยวข้องจึงขอแจ้งเปลี่ยนแปลงกำหนดการดำเนินการทำสัญญาอิเล็กทรอนิกส์ </b></p>
                                            <p class='center red-text' style="font-family:TH Sarabun New;font-size:16px"><b>(สัญญาการเป็นนักศึกษา หนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม และสัญญาค้ำประกัน)</b></p>
                                            <p class='center red-text' style="font-family:TH Sarabun New;font-size:16px"><b>จึงขอให้นักศึกษาที่เข้าศึกษาปี 2564 เข้าทำสัญญา</b></p>
                                            <p class='center red-text' style="font-family:TH Sarabun New;font-size:16px"><b>จากเดิม "วันที่ 9 สิงหาคม 2564" เปลี่ยนเป็น "วันที่ 1 กันยายน 2564"</b></p>
                                            <p class='center red-text' style="font-family:TH Sarabun New;font-size:16px"><b>LINE Official Account กองกฎหมาย มหาวิทยาลัยมหิดล : @csq0251v</b></p>                        
                                            <p class='center red-text'><b>ทั้งนี้ การดำเนินการดังกล่าวมีความจำเป็นที่จะต้องรีเซ็ทสัญญาอิเล็กทรอนิกส์ที่ได้จัดทำไปแล้ว จึงขอให้นักศึกษาและบิดามารดาของนักศึกษาที่ได้ทำสัญญาเสร็จสิ้นแล้ว เข้าทำสัญญาใหม่อีกครั้งตามวันที่ได้แจ้งเปลี่ยนแปลงข้างต้น</b></p>
                                            <p class='center red-text' style="font-family:TH Sarabun New;font-size:16px"><b>จึงเรียนมาเพื่อโปรดทราบ และขออภัยมา ณ ที่นี้</b></p>--%>
                        <%--                                            <p class='center black-text' style="font-family:TH Sarabun New;font-size:16px"><b>กรณีที่นักศึกษาประสงค์จะแก้ไขข้อมูลในระเบียนประวัตินักศึกษา (e-profile) ขอให้ดำเนินการดังนี้</b></p>--%>
                        <%--                                            <p class='right black-text' style="font-family:TH Sarabun New;font-size:16px"><b>1. แก้ไขเพิ่มเติมข้อมูลใน e-profile : ให้นักศึกษาติดต่อ <h8 style="color:red;">One Stop Service กองบริหารการศึกษา</h8> เพื่อแก้ไขเพิ่มเติมข้อมูลใน e-profile ให้ถูกต้อง โดยแจ้งขอแก้ไขเพิ่มเติมหรือติดต่อสอบถามรายละเอียดได้ที่ <h8 style="color:red;">onestopservice@mahidol.edu</h8></b></p>
                                            <p class='right black-text' style="font-family:TH Sarabun New;font-size:16px"><b>2. แจ้ง Reset สัญญา : เมื่อดำเนินการตามข้อ 1. เรียบร้อยแล้ว ให้ติดต่อ<h8 style="color:red;">กองกฎหมาย</h8>ได้ที่ <h8 style="color:red;">0 2849 62620 2849 6260</h8> หรือ <h8 style="color:red;">LINE Official Account: @csq0251v</h8> เพื่อแจ้ง Reset สัญญาเดิมที่มีข้อมูลไม่ถูกต้อง</b></p>
                                            <p class='right black-text' style="font-family:TH Sarabun New;font-size:16px"><b>3. เข้าทำสัญญาใหม่ : นักศึกษาและบิดามารดา เข้าทำ (1) สัญญาการเป็นนักศึกษา (2) หนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม และ (3) สัญญาค้ำประกัน ผ่าน http://econtract.mahidol.ac.th/ แทนฉบับเดิมเพื่อเชื่อมโยงข้อมูลที่ถูกต้องในการทำสัญญาฉบับใหม่</b></p>
                                            <p class='center red-text' style="font-family:TH Sarabun New;font-size:25px"><b><u>เมื่อสัญญาเสร็จสมบูรณ์ ระบบแสดงหน้าจอดังนี้</u></b></p>--%>
                        <div style='text-align: center; font-family: TH Sarabun New; font-size: 25px; color: darkblue; font-weight: bold;'>การทำสัญญาการเป็นนักศึกษาของปีการศึกษา 2567 และนักศึกษาชั้นปีอื่นที่มีการแก้ไขเพิ่มเติมข้อมูล</div>
                        <%--                                        <p style='text-align:center;font-family:TH Sarabun New;font-size:20px;color:darkred;font-weight:bold;'>มหาวิทยาลัยจะปิดระบบการทำสัญญาการเป็นนักศึกษาของปีการศึกษา 2565</p>--%>
                        <%--                                        <p style='text-align:center;font-family:TH Sarabun New;font-size:20px;color:darkred;font-weight:bold;'>ในวันที่ 31 ธันวาคม 2565 เวลา 00.00 น.</p>
                                        <p style='text-align:center;font-family:TH Sarabun New;font-size:20px;color:darkred;font-weight:bold;'>จึงขอให้นักศึกษาและบิดามารดาเข้าทำสัญญาให้แล้วเสร็จภายในกำหนดระยะเวลาดังกล่าว</p>
                                        <p style='text-align:center;font-family:TH Sarabun New;font-size:18px;color:darkblue;'>(กรณีที่นักศึกษาและหรือบิดามารดาไม่สามารถเข้าทำสัญญาให้แล้วเสร็จภายในระยะเวลาที่กำหนด</p>
                                        <p style='text-align:center;font-family:TH Sarabun New;font-size:18px;color:darkblue;'>ขอให้ติดตามขั้นตอนการทำสัญญาล่าช้า ซึ่งมหาวิทยาลัยจะแจ้งให้ทราบผ่านทางเว็บไซต์นี้ในช่วงเดือนมกราคม 2566 ต่อไป)</p>--%>
                        
                        <%--<p style='text-align: center; font-family: TH Sarabun New; font-size: 20px; color: darkred; font-weight: bold;'>มหาวิทยาลัยมหิดลจะเปิดระบบให้เข้าทำสัญญาการเป็นนักศึกษา</p>--%>
                        <div style='text-align: center; font-family: TH Sarabun New; font-size: 28px; color: darkred; font-weight: bold; margin-top: 5px;'>มหาวิทยาลัยขยายระยะเวลาการทำสัญญา</div>
                        <div style='text-align: center; font-family: TH Sarabun New; font-size: 28px; color: darkred; font-weight: bold;'>ตั้งแต่วันจันทร์ที่ 9 ธันวาคม 2567 จนถึงวันศุกร์ที่ 31 มกราคม 2568</div>
                        <div style='text-align: center; font-family: TH Sarabun New; font-size: 20px; color: darkblue; margin-top: 5px;'>และจะปิดระบบในส่วนของการทำสัญญา ตั้งแต่วันเสาร์ที่ 1 กุมภาพันธ์ 2567 เวลา 00.00 น. เป็นต้นไป</div>
                        <div style='text-align: center; font-family: TH Sarabun New; font-size: 20px; color: darkblue;'>ขอให้<u>นักศึกษา</u>และ<u>บิดามารดา</u> เข้าทำสัญญาการเป็นนักศึกษา สัญญาค้ำประกัน</div>
                        <div style='text-align: center; font-family: TH Sarabun New; font-size: 20px; color: darkblue;'>และหนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม ให้แล้วเสร็จภายในกำหนดระยะเวลาดังกล่าว</div>
                        <br />
                        <div style='text-align: center; font-family: TH Sarabun New; font-size: 20px; color: darkgoldenrod; font-weight: bold;'>(ในส่วนของการดาวน์โหลดสัญญา นักศึกษาปัจจุบันทุกชั้นปีสามารถเข้าสู่ระบบเพื่อดาวน์โหลดสัญญาได้จนกว่าจะสำเร็จการศึกษา)</div>
                        <br />
                        <div style='text-align: center; font-family: TH Sarabun New; font-size: 20px; font-weight: bold;'>สอบถามเพิ่มเติม/ติดต่อทำสัญญาค้ำประกันกรณีที่ระบบไม่รองรับเงื่อนไขการค้ำประกัน</div>
                        <div style='text-align: center; font-family: TH Sarabun New; font-size: 20px; font-weight: bold;'>LINE Official Account กองกฎหมาย : @csq0251v ในวันทำการ เวลา 09.00 น. - 17.00 น.</div>
                        <p style='text-align: center; font-family: TH Sarabun New; font-size: 20px; color: darkblue; font-weight: bold;'>...................................................</p>
                        <p style='text-align: center; font-family: TH Sarabun New; font-size: 22px; color: darkblue; font-weight: bold;'>ขั้นตอนการทำสัญญา</p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; color: darkblue; font-weight: bold;'>
                            1. ให้นักศึกษาดำเนินการทำ “สัญญาการเป็นนักศึกษา” เป็นอันดับแรก
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; color: darkblue; text-indent: 2em;'>
                            หากนักศึกษาไม่ดำเนินการทำสัญญาก่อน บิดาและมารดาจะไม่สามารถเข้าทำสัญญาได้
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; color: darkblue; font-weight: bold;'>
                            2. ให้นักศึกษากดรับรหัสผ่านของบิดาและมารดา
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; color: darkblue; text-indent: 2em;'>
                            กรณีที่ไม่สามารถกดรับรหัสผ่านได้ ขอให้ตรวจสอบความครบถ้วนถูกต้องของ ชื่อ นามสกุล (ภาษาไทยและภาษาอังกฤษ) เลขประจำตัวประชาชน (ไม่มี “-“ หรือเว้นวรรค) วันเดือนปีเกิด สถานภาพชีวิต สถานภาพการสมรส และที่อยู่ ของบิดาและมารดา ที่นักศึกษาได้บันทึกไว้ในระบบระเบียนประวัตินักศึกษา (e-profile)<a href="https://smartedu.mahidol.ac.th/Authen/login.aspx">https://smartedu.mahidol.ac.th/Authen/login.aspx</a>
                        </p>
                        <div style='font-family: TH Sarabun New; font-size: 18px; color: darkblue;'>
                            <p><b>3. ให้ <font style="text-decoration-line: underline;">บิดา และ มารดา</font> ดำเนินการทำ “สัญญาค้ำประกัน” และ “หนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม”</b> โดยให้บิดาหรือมารดาเข้าทำสัญญาใดสัญญาหนึ่งก่อนก็ได้</p>
                        </div>
                        <p style='font-family: TH Sarabun New; font-size: 18px; color: darkblue; text-indent: 2em;'>
                            <font style="text-decoration-line: underline;">เว้นแต่</font>กรณีที่บิดาและมารดามีสถานภาพการสมรสดังต่อไปนี้
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; color: darkblue; text-indent: 2em;'>
                            - <b>“สมรส</b> (ไม่จดทะเบียน)<b>” หรือ “โสด </b>(ไม่จดทะเบียนและแยกกันอยู่)<b>” : มารดาเท่านั้น</b>ที่สามารถเข้าทำสัญญาผ่านระบบ ฯ ได้
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; color: darkblue; text-indent: 2em;'>
                            - <b>“หย่าร้าง</b> (จดทะเบียนหย่า)<b>” หรือ “หม้าย</b> (จดทะเบียนสมรสแต่ฝ่ายใดฝ่ายหนึ่งเสียชีวิต)<b>” : บิดาหรือมารดาคนใดคนหนึ่งเท่านั้น</b>ที่สามารถเข้าทำสัญญาผ่านระบบ ฯ ได้
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; color: limegreen; font-weight: bold;'>
                            * กรณีที่ระบบ ฯ แจ้งให้ทำสัญญาค้ำประกันภายนอกระบบ
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; color: limegreen; text-indent: 2em;'>
                            - ขอให้นักศึกษาทำ <b>“สัญญาการเป็นนักศึกษา”</b> ในส่วนของนักศึกษาภายในระบบ ฯ ให้แล้วเสร็จภายในระยะเวลาที่กำหนดไว้ในระบบ ฯ ให้เรียบร้อยเสียก่อน
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; color: limegreen; text-indent: 2em;'>
                            - แล้วจึง<b>ติดต่อกองกฎหมาย</b>เพื่อทำสัญญาภายนอกระบบ โดย
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; color: limegreen; text-indent: 2.1em;'>
                            (1) <b>ติดต่อทำสัญญา ณ กองกฎหมาย ชั้น 2 สำนักงานอธิการบดี</b> <u>หรือ</u>
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; color: limegreen; text-indent: 2.1em;'>
                            (2) <b>แจ้งรหัสนักศึกษาพร้อมแจ้งบุคคลที่ประสงค์ให้เป็นผู้ค้ำประกันผ่านทางไลน์ OA กองกฎหมาย : @MULA หรือ @csq0251v</b>
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; color: limegreen; text-indent: 2.3em;'>
                            เจ้าหน้าที่จะให้คำแนะนำในการเลือกผู้ค้ำประกัน แจ้งขั้นตอนการทำสัญญาค้ำประกัน และส่งไฟล์สัญญาค้ำประกัน (และไฟล์หนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรมในกรณีที่ผู้ค้ำประกันเป็นผู้แทนโดยชอบธรรมของนักศึกษา) เพื่อให้ผู้ค้ำประกันกรอกข้อมูล แนบเอกสาร และจัดส่งกลับไปยังมหาวิทยาลัยต่อไป
                        </p>
                        <p style='text-align: center; font-family: TH Sarabun New; font-size: 18px; color: darkblue; font-weight: bold;'>...................................................</p>
                        <p style='text-align: center; font-family: TH Sarabun New; font-size: 22px; color: darkblue; font-weight: bold;'>การแก้ไขเพิ่มเติมสัญญา</p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; text-indent: 2em; color:darkblue'>
                            กรณีที่ประสงค์จะแก้ไขเพิ่มเติมข้อมูลในสัญญาการเป็นนักศึกษา หนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม และหรือสัญญาค้ำประกัน ขอให้ดำเนินการดังนี้
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; color: darkred; font-weight: bold;'>
                            1. กรณีที่กดยืนยันทำสัญญา ฯ แล้ว
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; text-indent: 2em;'>
                             <font style="color: darkred; font-weight: bold;">(1) แก้ไขข้อมูล :</font> <font style="color: darkred;">ให้นักศึกษาแก้ไขเพิ่มเติมข้อมูลในระบบระเบียนประวัตินักศึกษา (e-profile) <a href="https://smartedu.mahidol.ac.th/Authen/login.aspx">https://smartedu.mahidol.ac.th/Authen/login.aspx</a> ด้วยตนเองให้ครบถ้วนถูกต้อง</font>
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; text-indent: 2em;'>
                             <font style="color: darkred; font-weight: bold;">(2) แจ้ง reset สัญญา :</font> <font style="color: darkred;">เมื่อดำเนินการตาม (1) เรียบร้อยแล้ว ให้ติดต่อกองกฎหมายได้ที่ LINE Official Account : @MULA หรือ @csq0251v เพื่อแจ้งเหตุผลในการ reset สัญญาเดิมที่มีข้อมูลไม่ถูกต้อง</font>
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; text-indent: 2em;'>
                             <font style="color: darkred; font-weight: bold;">(3) เข้าทำสัญญาใหม่ :</font> <font style="color: darkred;">นักศึกษาและบิดามารดา เข้าทำ 1) สัญญาการเป็นนักศึกษา 2) หนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม และหรือ 3) สัญญาค้ำประกัน แล้วแต่กรณี ผ่านเว็บไซต์นี้แทนฉบับเดิมเพื่อเชื่อมโยงข้อมูลที่ถูกต้องในการทำสัญญาฉบับใหม่</font>
                        </p>
                                                <p style='font-family: TH Sarabun New; font-size: 18px; color: darkblue; font-weight: bold;'>
                            2. กรณีที่ยังมิได้กดยืนยันทำสัญญา ฯ
                        </p>
                                                <p style='font-family: TH Sarabun New; font-size: 18px; text-indent: 2em;'>
                             <font style="color: darkblue; font-weight: bold;">(1) แก้ไขข้อมูล :</font> <font style="color: darkblue;">ให้นักศึกษาแก้ไขเพิ่มเติมข้อมูลในระบบระเบียนประวัตินักศึกษา (e-profile) <a href="https://smartedu.mahidol.ac.th/Authen/login.aspx">https://smartedu.mahidol.ac.th/Authen/login.aspx</a> ด้วยตนเองให้ครบถ้วนถูกต้อง</font>
                        </p>
                        <p style='font-family: TH Sarabun New; font-size: 18px; text-indent: 2em;'>
                             <font style="color: darkblue; font-weight: bold;">(2) ดำเนินการทำสัญญา :</font> <font style="color: darkblue;">นักศึกษาและบิดามารดา เข้าทำ 1) สัญญาการเป็นนักศึกษา 2) หนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม และหรือ 3) สัญญาค้ำประกัน แล้วแต่กรณี ผ่านเว็บไซต์นี้ โดยระบบจะเชื่อมโยงข้อมูลที่ถูกต้องทันที</font> <font style="color: darkblue; font-weight: bold;">*ไม่ต้องแจ้ง reset สัญญา*</font>
                        </p>
                        <p style='text-align: center; font-family: TH Sarabun New; font-size: 18px; color: darkblue; font-weight: bold;'>...................................................</p>
                        <p class='center' style="font-family: TH Sarabun New; font-size: 25px; color: darkblue;"><b><u>เมื่อดำเนินการทำสัญญาเสร็จสิ้นเรียบร้อยแล้ว ระบบ ฯ จะแสดงหน้าจอดังนี้</u></b></p>
                        <div class='col s12 m12 l12'>
                            <img src='images/econtractComplete.png' alt='' class='responsive-img' />
                        </div>
                        <%--                                        <p class='black-text' style='text-indent:2em;font-family:TH Sarabun New;font-size:18px;margin-top:-20px;' >
                                            <b>1.1 </b><font style="color:blue;"><b>นักศึกษารหัส 65 : </b></font>ให้แก้ไขเพิ่มเติมข้อมูลในระบบ e-profile ด้วยตนเองให้ครบถ้วนถูกต้อง
                                        </p>
                                        <p class='black-text' style='text-indent:2em;font-family:TH Sarabun New;font-size:18px;margin-top:-20px;' >
                                            <b>1.2 </b><font style="color:blue;"><b>นักศึกษาชั้นปีอื่น : </b></font>ให้ติดต่อ <font style="color:blue;"><b>One Stop Service กองบริหารการศึกษา</b></font> เพื่อแก้ไขเพิ่มเติมข้อมูลใน e-profile ให้ถูกต้อง โดยแจ้งขอแก้ไขเพิ่มเติมหรือติดต่อสอบถามรายละเอียดได้ที่ <font style="color:blue;"><b>onestopservice@mahidol.edu</b></font>
                                        </p>
                                        <p class='black-text' style='font-family:TH Sarabun New;font-size:18px;margin-top:-10px;' >
                                            <b>2. </b><font style="color:blue;"><b>แจ้ง reset สัญญา : </b></font>เมื่อดำเนินการตามข้อ 1. เรียบร้อยแล้ว ให้ติดต่อ<font style="color:blue;"><b>กองกฎหมาย</b></font>ได้ที่ <font style="color:blue;"><b>LINE Official Account : @mula</b></font> หรือโทรศัพท์ <font style="color:blue;"><b>  0 2849 6262</b></font> และ <font style="color:blue;"><b>0 2849 6260</b></font> เพื่อแจ้ง reset สัญญาเดิมที่มีข้อมูลไม่ถูกต้อง
                                        </p>
                                        <p class='black-text' style='font-family:TH Sarabun New;font-size:18px;margin-top:-10px;' >
                                            <b>3. </b><font style="color:blue;"><b>เข้าทำสัญญาใหม่ : </b></font>นักศึกษาและบิดามารดา เข้าทำ (1) สัญญาการเป็นนักศึกษา (2) หนังสือแสดงความยินยอมของผู้แทนโดยชอบธรรม และหรือ (3) สัญญาค้ำประกัน แล้วแต่กรณี ผ่านเว็บไซต์นี้แทนฉบับเดิมเพื่อเชื่อมโยงข้อมูลที่ถูกต้องในการทำสัญญาฉบับใหม่
                                        </p>
                                        <p class='center red-text' style="font-family:TH Sarabun New;font-size:25px"><b><u>เมื่อสัญญาเสร็จสมบูรณ์ ระบบแสดงหน้าจอดังนี้</u></b></p>
                                        <div class='col s12 m12 l12'><img src='images/econtractComplete.png' alt='' class='responsive-img' /></div>

                                    </div>
                                    <div class='left'>
                                        ขั้นตอนการทำสัญญา<br />
                                    </div>
                               <div class='section'>
                                    <p style='text-indent: 4em;'>
                                        <b class='deep-purple-text'>1.</b> นักศึกษาดำเนินการทำสัญญาเป็นอันดับแรก (หากนักศึกษาไม่ดำเนินการทำสัญญาก่อน บิดา มารดา จะไม่สามารถเข้าทำสัญญาได้)
                                    </p>
                                <p style='text-indent: 4em;'>
                                    <b class='deep-purple-text'>2</b> ให้บิดา หรือมารดา เข้าทำสัญญาค้ำประกัน และหนังสือให้ความยินยอมของผู้แทนโดยชอบธรรม ทำสัญญาใดสัญญาหนึ่งก่อนได้ 
                                </p> --%>
                    </div>
                </div>
            </div>
        </div>
        <%--modal-footer--%>
        <div class="modal-footer">
            <form id="gotologin" name="gotologin" runat="server" method="post" action="Login.aspx">
                <a href="javascript:void(0);" class="modal-action modal-close waves-effect waves-green btn-flat " id="comfirm">เข้าสู่ระบบ</a>
            </form>
        </div>
    </div>
    <%--    <form id="loginform" name="loginform" method="post">
        <input type='hidden' id='txtUserTypeActive' name='txtUserTypeActive' value='STUDENT' />
        <input type='hidden' id='usertype' name='usertype' value='STUDENT' />
    </form>--%>
</body>
</html>
<script type="text/javascript">

    $(document).ready(function () {
        $('#modal1').openModal({
            dismissible: false
        });
    });

    $('#comfirm').click(function () {
        $('#gotologin').submit();
    });

    // original code from http://stackoverflow.com/questions/13478303/correct-way-to-use-modernizr-to-detect-ie
    var BrowserDetect = {
        init: function () {
            this.browser = this.searchString(this.dataBrowser) || "Other";
            this.version = this.searchVersion(navigator.userAgent) || this.searchVersion(navigator.appVersion) || "Unknown";
        },
        searchString: function (data) {
            for (var i = 0; i < data.length; i++) {
                var dataString = data[i].string;
                this.versionSearchString = data[i].subString;

                if (dataString.indexOf(data[i].subString) !== -1) {
                    return data[i].identity;
                }
            }
        },
        searchVersion: function (dataString) {
            var index = dataString.indexOf(this.versionSearchString);
            if (index === -1) {
                return;
            }

            var rv = dataString.indexOf("rv:");
            if (this.versionSearchString === "Trident" && rv !== -1) {
                return parseFloat(dataString.substring(rv + 3));
            } else {
                return parseFloat(dataString.substring(index + this.versionSearchString.length + 1));
            }
        },

        dataBrowser: [
            { string: navigator.userAgent, subString: "Edge", identity: "MS Edge" },
            { string: navigator.userAgent, subString: "MSIE", identity: "Explorer" },
            { string: navigator.userAgent, subString: "Trident", identity: "Explorer" },
            { string: navigator.userAgent, subString: "Firefox", identity: "Firefox" },
            { string: navigator.userAgent, subString: "Opera", identity: "Opera" },
            { string: navigator.userAgent, subString: "OPR", identity: "Opera" },

            { string: navigator.userAgent, subString: "Chrome", identity: "Chrome" },
            { string: navigator.userAgent, subString: "Safari", identity: "Safari" }
        ]
    };

    BrowserDetect.init();
    //document.write("You are using11 <b>" + BrowserDetect.browser + "</b> with version <b>" + BrowserDetect.version + "</b>");
    if (BrowserDetect.browser == 'Chrome' && BrowserDetect.version <= 42) window.location = 'https://econtract.mahidol.ac.th/detectBrowser.aspx';
    if (BrowserDetect.browser == 'Explorer') window.location = 'https://econtract.mahidol.ac.th/detectBrowser.aspx';
    if (BrowserDetect.browser == 'Firefox' && BrowserDetect.version <= 39) window.location = 'https://econtract.mahidol.ac.th/detectBrowser.aspx';
    if (BrowserDetect.browser == 'Opera' && BrowserDetect.version <= 31) window.location = 'https://econtract.mahidol.ac.th/detectBrowser.aspx';
    if (BrowserDetect.browser == 'Safari' && BrowserDetect.version <= 7) window.location = 'https://econtract.mahidol.ac.th/detectBrowser.aspx';
</script>
