<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detectBrowser.aspx.cs" Inherits="eContract.DetectBrowser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%--
    <style type="text/css">
        body{       
            filter:gray;
            webbit-filter:grayscale(100%);
            filter:grayscale(100%);
        }
    </style>
    --%>
</head>
<body>
<center>
    <div class='card-panel grey lighten-5'>
        <div class='grey-text text-darken-4'>
            <div class='section'>
                <p class='center red-text'>
                    <b><u>ข้อแนะนำเบื้องต้น เมื่อไม่สามารถเข้าระบบทำสัญญาอิเล็กทรอนิกส์ได้</u></b>
                </p>
                <div class='col s12 m12 l12'>
                    <img src='images/webbrowsers_icons.png' alt='' class='responsive-img' />
                </div>
            </div>
            <table class="logos">
                <tr>
                    <td class="b bf">
                        <a class="l" href="http://www.mozilla.com/firefox/" target="_blank" onmousedown="countBrowser('f')">
                            <span class="bro">Firefox</span>
                            <span class="vendor">Mozilla Foundation</span>
                        </a>
                    </td>
                    <td class="b bo">
                        <a class="l" href="http://www.opera.com/?utm_medium=roc&utm_source=team23_de&utm_campaign=browser-update_org" target="_blank" onmousedown="countBrowser('o')">
                            <span class="bro">Opera</span>
                            <span class="vendor">Opera Software</span>
                        </a>
                    </td>
                    <td class="b bc">
                        <a class="l" href="https://www.google.com/chrome/browser/desktop/" target="_blank" onmousedown="countBrowser('c')">
                            <span class="bro">Chrome</span>
                            <span class="vendor">Google</span>
                        </a>
                    </td>
                    <td class="b bi">
                        <a class="l" href="http://windows.microsoft.com/en-US/internet-explorer/downloads/ie" target="_blank" onmousedown="countBrowser('i')">
                            <span class="bro">Edge</span>
                            <span class="vendor">Microsoft</span>
                        </a>
                    </td>
                </tr>
            </table>  
            <div class='section'>
                <p style='text-indent: 4em; text-align:left;' >
                    <b class='deep-purple-text '>1.</b> ระบบรองรับการทำงานของ IE,Google Chorme,Mozila firefox, Safari รุ่นใหม่เท่านั้น ถ้าเข้าระบบไม่ได้ให้เปลี่ยนเบราเซอร์ หรืออัพเดชเวอร์ชั้น หรือ ดาวน์โหลดเบาเซอร์ตัวอื่น
                </p>
                <p style='text-indent: 4em; text-align:left;' >
                    <b class='deep-purple-text '>2</b> หากกรณีที่ทำตามข้อ 1 แล้วยังไม่สามารถเข้าได้ให้ลองเปลี่ยนเครื่องคอมพิวเตอร์ โดยส่วนใหญ่ที่พบคือ ภาษาสคริปของเบราเซอร์ไม่สนับสนุน
                </p>                                                                                                                               
            </div> 
        </div>
    </div>
</center>
</body>
</html>
