<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="false" EnableEventValidation="false" CodeBehind="confirmRequest.aspx.cs" Inherits="eContract.ConfirmRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MU-Contract</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="msapplication-tap-highlight" content="no" />
    <meta name="description" content="Mahidol University, MU Contract,ทำสัญญาการเป็นนักศึกษา, มหาวิทยาลัยมหิดล" />    
    <meta name="msapplication-TileColor" content="#FFFFFF" />
    <meta name="msapplication-TileImage" content="images/logo.png" />
    <meta name="theme-color" content="#EE6E73" />
    <link rel="apple-touch-icon-precomposed" href="images/logo.png" />
    <link rel="icon" href="images/logo.png" sizes="32x32" />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />    
    <style type="text/css">
        .overlay {
            display: none;
            position: fixed;
            width: 100%;
            height: 100%;
            top: 0;
            left: 0;
            z-index: 999;
            background: rgba(255,255,255,0.8) url("/Images/Spinner-2.gif") center no-repeat;
        }
        /* Turn off scrollbar when body element has the loading class */
        body.loading {
            overflow: hidden;
        }
            /* Make spinner image visible when body element has the loading class */
            body.loading .overlay {
                display: block;
            }
    </style>
</head>
<body>
    <form id="form1" method="post" runat="server" action="confirmRequest.aspx">
        <nav id="navBar" runat="server" class='' style="background-color: #253988" role='navigation'></nav>
        <div id="index-bannerx" class="parallax-container" style="height: 170px;">
            <div class="container transp" id="divUserProfile" runat="server"></div>
            <div class="parallax">
                <img src="images/building009-s.jpg" alt="#" />
            </div>
        </div>
        <!-- body -->
        <div class="container">
            <div class="row" style="min-height: 50vh;">
                <div class="col s12 m12 l12">
                    <div id="divBody" runat="server"></div>
                    <div class="row">
                        <div id="divResponseERROR" style="text-align: center;" runat="server"></div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col s12 m12 l12">
                    <div id="divComplete" runat="server" style="display:none;"></div>
                </div>
            </div>
        </div>
        <!-- hidden -->
        <asp:HiddenField ID="hidStudentCode" runat="server" />
        <asp:HiddenField ID="hidAcaYear" runat="server" />
        <asp:HiddenField ID="printPasswordF" runat="server" />
        <asp:HiddenField ID="printPasswordM" runat="server" />
        <asp:HiddenField ID="txtUserTypeActive" runat="server" />

    </form>
    <!-- footer banner -->
    <div class="page-footer" style="background-color: #A5802E;" id="divFooter" runat="server"></div>
    <div class="overlay"></div>
</body>
</html>
<script src="Scripts/modernizr-custom.min.js"></script>
<script type="text/javascript">
    $(function () {
        $('.parallax').parallax();
        //mobile display mini - message
        //$('.minimessage').text($('#messenger').text());

        $('.btnThai').click(function () {
            thaiAcitive();
        });

        $('.btnEng').click(function () {
            engAcitive();
        });
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

    //english active
    function engAcitive() {
        $('.lang-active').data('lang', 'en');
        $('.th').addClass('hide');
        $('.en').removeClass('hide');
    }
</script>
<script type="text/javascript">
    //original code from http://stackoverflow.com/questions/13478303/correct-way-to-use-modernizr-to-detect-ie
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
<script type="text/javascript">
    $(document).on({
        ajaxStart: function () {
            $("body").addClass("loading");
        },
        ajaxStop: function () {
            $("body").removeClass("loading");
        }
    });

    onloadUITerm();

    function onloadUITerm() {
        var _post = $.param({ action: "UIsetAcceptedRequestPassword" });
        $.ajax({
            type: "POST",
            url: "ContractHandler.ashx",
            data: _post,
            beforeSend: function () { },
            success: function (data) {
                $(document).ready(function () {
                    //onloadDataReceipt();
                    $("#divBody").html(data);
                });
                $("#btnAcceptRequest").click(function () {
                    setRequestPassword();
                });

                $("#btnPrintPassword").click(function () {
                    $('form#form1').submit();
                });
            },
            error: function (textStatus, errorThrown) {
                alert(textStatus);
                return false;
            }
        });
    }

    function setRequestPassword() {
        var post = $.param({ action: "UIsetConfirmRequestPassword" });
        $.ajax({
            type: "POST",
            url: "ContractHandler.ashx",
            data: post,
            beforeSend: function () { },
            success: function (data) {

                $(document).ready(function () {
                    $("#divBody").html(data);
                });
                $("#btnPrintPassword").click(function () {
                    $('form#form1').submit();
                });

            },
            error: function (textStatus, errorThrown) {
                //alert(textStatus);
                return false;
            }
        });
    }
</script>