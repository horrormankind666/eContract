<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="false" EnableEventValidation="false" CodeBehind="menuStudent.aspx.cs" Inherits="eContract.menuStudent" %>

<!DOCTYPE html>

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
</head>
<body style="background-color: #F2F0EF">
    <form id="frmMenuStd" method="post"  runat="server">
    <nav id="navBar" runat="server" class='' style="background-color: #253988" role='navigation'></nav>
    <div id="index-bannerx" class="parallax-container" style="height: 170px;">
        <div class="container transp" id="divUserProfile" runat="server"></div>
        <div class="parallax">
            <img src="images/building009-s.jpg" alt="#" />
        </div>
    </div>
    <!-- body panel -->
    <div class="container" >
        <div id="divBody" runat="server"></div>
    </div>
    <asp:HiddenField id="txtUserTypeActive" runat="server" />
    </form>
    <!-- footer banner -->
    <div class="page-footer" style="background-color: #A5802E;" id="divFooter" runat="server"></div>
</body>
</html>
<script src="Scripts/modernizr-custom.min.js"></script>
<script type="text/javascript">
        $(function () {
        $('.parallax').parallax();
        // mobile display mini - message
        //$('.minimessage').text($('#messenger').text());

        $('.btnThai').click(function () {
            thaiAcitive();
        });

        $('.btnEng').click(function () {
            engAcitive();
        });

        $('a#submit_frmContract').click(function () {
            $('form#frmMenuStd').attr('action', 'frmContract.aspx');
            $('form#frmMenuStd').submit();
        });

        $('a#submit_confrimRequest').click(function () {
            $('form#frmMenuStd').attr('action', 'confirmRequest.aspx');
            $('form#frmMenuStd').submit();
        });
    });

    /// <summary>
    /// Auther : Odd.Nopparat
    /// Date   : 2015-08-20.
    /// Perpose: สลับภาษาอังกฤษ.
    /// Method : english-active.
    /// </summary>
    function thaiAcitive() {
        $('.lang-active').data('lang', 'th');
        $('.en').addClass('hide');
        $('.th').removeClass('hide');
    }

    // english active
    function engAcitive() {
        $('.lang-active').data('lang', 'en');
        $('.th').addClass('hide');
        $('.en').removeClass('hide');
    }
</script>
<script type="text/javascript">
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
            { string: navigator.userAgent, subString: "Chrome", identity: "Chrome" },
            { string: navigator.userAgent, subString: "MSIE", identity: "Explorer" },
            { string: navigator.userAgent, subString: "Trident", identity: "Explorer" },
            { string: navigator.userAgent, subString: "Firefox", identity: "Firefox" },
            { string: navigator.userAgent, subString: "Safari", identity: "Safari" },
            { string: navigator.userAgent, subString: "Opera", identity: "Opera" }
        ]

    };

//    BrowserDetect.init();
//    if (BrowserDetect.browser == 'Chrome' && BrowserDetect.version <= 42) window.location = 'http://outdatedbrowser.com/en';
//    if (BrowserDetect.browser == 'Explorer' && BrowserDetect.version <= 9) window.location = 'http://outdatedbrowser.com/en';
//    if (BrowserDetect.browser == 'Firefox' && BrowserDetect.version <= 39) window.location = 'http://outdatedbrowser.com/en';
//    if (BrowserDetect.browser == 'Opera' && BrowserDetect.version <= 31) window.location = 'http://outdatedbrowser.com/en';
//    if (BrowserDetect.browser == 'Safari' && BrowserDetect.version <= 7) window.location = 'http://outdatedbrowser.com/en';
</script>
