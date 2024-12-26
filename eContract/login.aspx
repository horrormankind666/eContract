<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="false" EnableEventValidation="false"  CodeBehind="login.aspx.cs" Inherits="eContract.LoginP" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="th">
<head runat="server">
    <title>MU-Contract</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="msapplication-tap-highlight" content="no" />
    <meta name="description" content="Mahidol University, MU Contract,ทำสัญญาการเป็นนักศึกษา, มหาวิทยาลัยมหิดล" />    
    <meta name="msapplication-TileColor" content="#FFFFFF" />
    <meta name="msapplication-TileImage" content="Images/logo.png" />
    <meta name="theme-color" content="#EE6E73" />
    <link rel="apple-touch-icon-precomposed" href="Images/logo.png" />
    <link rel="icon" href="Images/logo.png" sizes="32x32" />
    <%-- <link href="cookieConsent/css/bootstrap.css" rel="stylesheet" /> --%>
    <%-- <link rel="stylesheet" href="cookieConsent/css/icomoon.css" /> --%>
	<link rel="stylesheet" href="cookieConsent/css/style.css" />
    <%--
    <style type="text/css">
        body {
            filter: gray;
            webbit-filter: grayscale(100%);
            filter: grayscale(100%);
        }
    </style>
    --%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
</head>
<body class="" style="background-color: #F2F0EF">
    <form id="loginform" name="loginform" runat="server" method="post" action="login.aspx">
        <!-- navigater bar -->
        <nav id="navBar" runat="server" style="background-color: #253988" role='navigation'></nav>
        <!-- parallax banner -->
        <div id="divBanner" runat="server"></div>
        <!-- body panel -->
        <div class="container">
            <div class="section no-pad-bot" id="index-banner">
                <h5 class="minimessage hide-on-med-and-up pink-text row center"></h5>
            </div>
        </div>
        <div id="divBody" runat="server"></div>
        <!-- footer banner -->
        <div class="page-footer" style="background-color: #A5802E;" id="divFooter" runat="server"></div>
        <!-- modal structure -->
        <div id="modal1" class="modal">
            <div class="modal-content">
                <h4 class="red-text">Warning message.</h4>
                <p class="message red-text text-darken-3"></p>
            </div>
            <div class="modal-footer">
                <a href="javascript:void(0);" class="modal-action modal-close waves-effect waves-green btn-flat">
                    <span class='th' style='font-weight: bold; font-size: 16pt;'>ปิด</span>
                    <span class='en hide' style='font-weight: bold; font-size: 16pt;'>CLOSE</span>
                </a>
            </div>
        </div>
        <asp:HiddenField id="txtUserTypeActive" runat="server" />
    </form>
    <script src="cookieConsent/js/popupConsent.min.js"></script>
	<script>
        var cookieConsentOptions = {
            //cookie usage prevention text
            textPopup: 'เว็บไซต์นี้ใช้คุกกี้ที่จำเป็น ที่ต้องมีเพื่อให้เว็บไซต์ทำงานได้อย่างถูกต้อง โปรดคลิก ยอมรับ  อนุญาตให้เราใช้คุกกี้ตาม <a href="https://privacy.mahidol.ac.th/">นโยบายคุกกี้ของเรา</a>',
            //the text of the accept button
            textButtonAccept: 'ยอมรับ',
            //the text of the configure my options button
            textButtonConfigure: 'การตั้งค่าคุกกี้',
            //the text of the save my options button
            //textButtonSave: 'ยอมรับ',
            //the text of the first parameter that the user can define in the "configuration" section.
            authorization: [
                {
                    textAuthorization: 'คุกกี้ประเภทจำเป็นถาวร',
                    nameCookieAuthorization: 'cookieConsent'
                }
                /*
                {
                    textAuthorization: 'Allow personalised ads and content, ad measurement and audience analysis',
                    nameCookieAuthorization: 'targetedAdvertising'
                },
                {
                    textAuthorization: 'Storing and/or accessing information on a device',
                    nameCookieAuthorization: 'cookieConsent'
                }
                */
            ]
        }

        popupConsent(cookieConsentOptions);
	</script>
</body> 
</html>

<script type="text/javascript">
    /*
    Auther  : anussara.wan
    Date    : 20-12-2015
    Perpose : แสดงวันที่ทำสัญญาของแต่ละปีที่เข้าศึกษา
    Method  :
    */
    /*
    function getEventAcaYear () {
        var acaYears = $('#select_acayear').text();
        var facultyCode = $('.ddlFaculty option:selected').val();
        var post = $.param({
            action: "uiProgram",
            acaYears: acaYears,
            facultyCode: 
            facultyCode
        });

        $.ajax({
            type: "POST",
            url: "DefaultHandler.ashx",
            data: post,
            beforeSend: function () {
            },
            success: function (data) {
                $(".PanelProgram").html(data);
                $('select').material_select();

                datetimeCalendar();
            },
            error: function (data) {
                alert(jQuery.error);
            },
        });
    }
    */

    /*
    Auther  : Odd.Nopparat
    Date    : 20-11-2015
    Perpose : initial parameter
    Method  :
    */
    $(function () {
        $('.parallax').parallax();
        //mobile display mini - message
        $('.minimessage').text($('#messenger').text());

        $('.btnThai').click(function () {
            thaiAcitive();
        });

        $('.btnEng').click(function () {
            engAcitive();
        });
    });

    /*
    Auther  : odd.nopparat/2015
    Date    : 20-11-2015
    Perpose : password text on enter key
    Paramte :
    */
    $('#studentpassword').keydown(function (e) {
        var key = e.which;

        if (key == 13) {
            $('.student-login').click(); //submit student-form code
        }
    });

    /*
    Auther  : odd.nopparat/2015
    Date    : 2015-11-20.
    Perpose : password text on enter key
    Paramte :
    */
    $('#parentpassword').keydown(function (e) {
        var key = e.which;

        if (key == 5) {
            $('.parent-login').click(); //submit parent-form code
        }
    });

    /*
    Auther  : Odd.Nopparat
    Date    : 2015-11-20.
    Perpose : student login
    Method  :
    */
    $('.student-login').click(function () {
        //student login..
        //var username = $.trim($('#username').val());
        //var studentpassword = $.trim($('#studentpassword').val());

        $('#usertype').val('STUDENT');
        $('#txtUserTypeActive').val('STUDENT');        
        $('#loginform').submit();

        /*
        if (username === '' ||
            studentpassword === '') {
            myDialog('กรุณาระบุรหัสนักศึกษา ( ตย. u57xxxxx ) และรหัสผ่าน ให้ถูกต้อง', 'Please specify student ID ( ex. u5700000 ) and password');
            
            return false;
        }
        else {
            $('#loginform').submit();
        }
        
        myDialog('ขออภัยในความไม่สะดวก เนื่องจากอยู่ระหว่างการปรับปรุงระบบ', 'ขออภัยในความไม่สะดวก เนื่องจากอยู่ระหว่างการปรับปรุงระบบ');
        
        return false;
        */
    });

    /*
    Auther  : Odd.Nopparat
    Date    : 20-11-2015
    Perpose : staff login
    Method  :
    */
    $('.parent-login').click(function () {
        //parent login..
        //var citizenid = $.trim($('#citizenid').val());
        //var parentpassword = $.trim($('#parentpassword').val());

        $('#usertype').val('PARENT');
        $('#txtUserTypeActive').val('PARENT');
        $('#loginform').submit();

        /*
        if (citizenid === '' ||
            parentpassword === '') {
            myDialog('กรุณาระบุรหัสผู้ใช้ และรหัสผ่าน ให้ถูกต้อง', 'Please specify username and password');

            return false;
        }
        else {
            $('#loginform').submit();
        }
        
        myDialog('ขออภัยในความไม่สะดวก เนื่องจากอยู่ระหว่างการปรับปรุงระบบ', 'ขออภัยในความไม่สะดวก เนื่องจากอยู่ระหว่างการปรับปรุงระบบ');
        
        return false;
        */
    });

    /*
    Auther  : Odd.Nopparat
    Date    : 20-08-2015
    Perpose : สลับภาษาอังกฤษ.
    Method  : english-active.
    */
    function thaiAcitive() {
        $('.lang-active').data('lang', 'th');
        $('.en').addClass('hide');
        $('.th').removeClass('hide');
    }

    function engAcitive() {
        $('.lang-active').data('lang', 'en');
        $('.th').addClass('hide');
        $('.en').removeClass('hide');

    }
    
    function memoryLanguage() {
        if ($('.lang-active').data('lang') == 'th') {
            thaiAcitive();
        }

        if ($('.lang-active').data('lang') == 'en') {
            engAcitive();
        }
    }

    /*
    Auther  : Odd.Nopparat
    Date    : 20-06-2015
    Perpose : เตือนข้อมูลไม่ครบ
    Method  : myDialog.
    */
    function myDialog(
        messageTH,
        messageEN
    ) {
        if ($('.lang-active').data('lang') == 'th') {
            $('.message').html(messageTH);
        }

        if ($('.lang-active').data('lang') == 'en') {
            $('.message').html(messageEN);
        }
    
        $('#modal1').openModal();
    }
</script>

<script src="Scripts/modernizr-custom.min.js"></script>
<script type="text/javascript">
    //original code from http://stackoverflow.com/questions/13478303/correct-way-to-use-modernizr-to-detect-ie
    var BrowserDetect = {
        init: function () {
            this.browser = (this.searchString(this.dataBrowser) || "Other");
            this.version = (this.searchVersion(navigator.userAgent) || this.searchVersion(navigator.appVersion) || "Unknown");
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

            if (this.versionSearchString === "Trident" &&
                rv !== -1) {
                return parseFloat(dataString.substring(rv + 3));
            }
            else {
                return parseFloat(dataString.substring(index + this.versionSearchString.length + 1));
            }
        },
        dataBrowser: [
            {
                string: navigator.userAgent,
                subString: "Edge",
                identity: "MS Edge"
            },
            {
                string: navigator.userAgent,
                subString: "Chrome",
                identity: "Chrome"
            },
            {
                string: navigator.userAgent,
                subString: "MSIE",
                identity: "Explorer"
            },
            {
                string: navigator.userAgent,
                subString: "Trident",
                identity: "Explorer"
            },
            {
                string: navigator.userAgent,
                subString: "Firefox",
                identity: "Firefox"
            },
            {
                string: navigator.userAgent,
                subString: "Safari",
                identity: "Safari"
            },
            {
                string: navigator.userAgent,
                subString: "Opera",
                identity: "Opera"
            }
        ]

    };

    /*
    BrowserDetect.init();

    if (BrowserDetect.browser == 'Chrome' &&
        BrowserDetect.version <= 42)
        window.location = 'http://outdatedbrowser.com/en';

    if (BrowserDetect.browser == 'Explorer' &&
        BrowserDetect.version <= 9)
        window.location = 'http://outdatedbrowser.com/en';

    if (BrowserDetect.browser == 'Firefox' &&
        BrowserDetect.version <= 39)
        window.location = 'http://outdatedbrowser.com/en';

    if (BrowserDetect.browser == 'Opera' &&
        BrowserDetect.version <= 31)
        window.location = 'http://outdatedbrowser.com/en';

    if (BrowserDetect.browser == 'Safari' &&
        BrowserDetect.version <= 7)
        window.location = 'http://outdatedbrowser.com/en';
    */
</script>