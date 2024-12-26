<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="false" EnableEventValidation="false" CodeBehind="frmContract.aspx.cs" Inherits="eContract.FrmContract" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang="th">
<head id="Head1" runat="server">
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
    <style type="text/css">
        .hoverMarital {
            display: none;
            width: 100px;
            height: 100px;
            color: #000;
            background: #ccc;
            position: absolute;
        }

        .overlay {
            display: none;
            position: fixed;
            width: 100%;
            height: 100%;
            top: 0;
            left: 0;
            z-index: 999;
            background: rgba(255, 255, 255, 0.8) url("/Images/Spinner-2.gif") center no-repeat;
        }

        body.loading {
            overflow: hidden;
        }

        body.loading .overlay {
            display: block;
        }
    </style>
</head>
<body style="background-color: #F2F0EF;">
    <form id="form1" runat="server" method="post">
        <nav id="navBar" runat="server" class='' style="background-color: #253988" role='navigation'></nav>
        <div id="index-bannerx" class="parallax-container" style="height: 170px;">
            <!-- Profile -->
            <div class="container transp" id="divUserProfile" runat="server"></div>
            <div class="parallax">
                <img src="images/building009-s.jpg" alt="#" />
            </div>
        </div>
        <div class="container divBody" style="margin-top:10px;">
            <div class="row" style="min-height: 50vh;">
                <div class="col s12 m12 l12">
                    <div id="divParentStatus" runat="server"></div>
                </div>
                <div class="col s12 m12 l12">
                    <div id="divMenuStd" runat="server"></div>
                </div>
                <div class="col s12 m12 l12">
                    <div id="divContractView" runat="server"></div>
                    <div id="divWarantView" runat="server"></div>
                </div>
                <div class="col s12 m12 l12">
                    <div id="divLogin" runat="server"></div>
                </div>
                <div class="col s12 m12 l12">
                    <div id="divComplete" runat="server"></div>
                </div>
                <div class="col s12 m12 l12">
                    <div id="divResult" class="hide" runat="server"></div>
                </div>
            </div>
        </div>
        <%--
        <div class="container" id="divComplete" runat="server"></div>
        --%>
        <!-- footer banner -->
        <div class="page-footer" style="background-color: #A5802E;" id="divFooter" runat="server"></div>

        <!-- Modal Structure -->
        <div id="modalMsg" class="modal">
            <div class="modal-content">
                <h4 class="red-text lblTitle">Warning message.</h4>
                <p class="message red-text text-darken-3"></p>
            </div>
            <div class="modal-footer">
                <a href="javascript:void(0);" class="modal-action modal-close waves-effect waves-green btn-flat">
                    <span style='font-weight: bold; font-size: 16pt;' class='th'>ปิด</span>
                    <span style='font-weight: bold; font-size: 16pt;' class='en hide'>CLOSE</span>
                </a>
            </div>
        </div>

        <!-- Modal Check Consent From e-Profile -->
        <div id="modalConsent" class="modal">
            <div class="modal-content">
                <h4 class="red-text lblTitle">Warning message.</h4>
                <p class="message red-text text-darken-3"></p>
            </div>
            <div class="modal-footer">
                <a href="javascript:void(0);" class="modal-action modal-close waves-effect waves-green btn-flat">
                    <span style='font-weight: bold; font-size: 16pt;' class='th'>ปิด</span>
                    <span style='font-weight: bold; font-size: 16pt;' class='en hide'>CLOSE</span>
                </a>
            </div>
        </div>

        <!-- Modal Check ENName (Same Person) From e-Profile -->
        <div id="modalCheckENNameSame" class="modal">
            <div class="modal-content">
                <h5 class="lblTitle" style="color: dimgrey;">ข้อมูลชื่อ - นามสกุล (ภาษาอังกฤษ) ไม่ครบถ้วน</h5>
                <div class="row" style="margin-top: 30px;">
                    <div class="input-field col s6">
                        <input id="txtENFirstName" type="text" disabled="disabled" class="validate" />
                        <label for="txtENFirstName" class="active" data-error="ไม่พบชื่อในระบบ" data-success="พบชื่อในะบบ" style="color: brown; font-weight: bold;">ชื่อ (ภาษาอังกฤษ)</label>
                    </div>
                    <div class="input-field col s6">
                        <input id="txtENLastName" type="text" disabled="disabled" class="validate" />
                        <label for="txtENLastName" class="active" data-error="ไม่พบนามสกุลในระบบ" data-success="พบนามสกุลในระบบ" style="color: brown; font-weight: bold;">นามสกุล (ภาษาอังกฤษ)</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col s12">
                        <p style="text-align: center;" class="message red-text text-darken-3"></p>
                        <p style="text-align: center;" class="message2 red-text text-darken-3"></p>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <a href="javascript:void(0);" class="modal-action modal-close waves-effect waves-green btn-flat">
                    <span style='font-weight: bold; font-size: 16pt;' class='th'>ปิด</span>
                    <span style='font-weight: bold; font-size: 16pt;' class='en hide'>CLOSE</span>
                </a>
            </div>
        </div>
        <!-- Modal Check ENName (Different Person) From e-Profile -->
        <div id="modalCheckENNameDiff" class="modal">
            <div class="modal-content">
                <h5 class="lblTitle" style="color: dimgrey;">ข้อมูลชื่อ - นามสกุล (ภาษาอังกฤษ) ไม่ครบถ้วน</h5>
                <div class="row" style="margin-top: 30px;">
                    <div class="input-field col s6">
                        <input id="txtENFirstNameWarranty" type="text" disabled="disabled" class="validate" />
                        <label for="txtENFirstNameWarranty" class="active" data-error="ไม่พบชื่อในระบบ" data-success="พบชื่อในะบบ" style="color: brown; font-weight: bold;">ชื่อผู้ค้ำประกัน (ภาษาอังกฤษ)</label>
                    </div>
                    <div class="input-field col s6">
                        <input id="txtENLastNameWarranty" type="text" disabled="disabled" class="validate" />
                        <label for="txtENLastNameWarranty" class="active" data-error="ไม่พบนามสกุลในระบบ" data-success="พบนามสกุลในระบบ" style="color: brown; font-weight: bold;">นามสกุลผู้ค้ำประกัน (ภาษาอังกฤษ)</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col s12" style="margin-top: 15px;">
                        <hr style="height: 3px; background-color: orange; border: none;" />
                    </div>
                </div>
                <div class="row">
                    <div class="input-field col s6">
                        <input id="txtENFirstNameConsent" type="text" disabled="disabled" class="validate" />
                        <label for="txtENFirstNameConsent" class="active" data-error="ไม่พบชื่อในระบบ" data-success="พบชื่อในะบบ" style="color: brown; font-weight: bold;">ชื่อผู้ยินยอม (ภาษาอังกฤษ)</label>
                    </div>
                    <div class="input-field col s6">
                        <input id="txtENLastNameConsent" type="text" disabled="disabled" class="validate" />
                        <label for="txtENLastNameConsent" class="active" data-error="ไม่พบนามสกุลในระบบ" data-success="พบนามสกุลในระบบ" style="color: brown; font-weight: bold;">นามสกุลผู้ยินยอม (ภาษาอังกฤษ)</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col s12">
                        <p style="text-align: center;" class="message red-text text-darken-3"></p>
                        <p style="text-align: center;" class="message2 red-text text-darken-3"></p>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <a href="javascript:void(0);" class="modal-action modal-close waves-effect waves-green btn-flat">
                    <span style='font-weight: bold; font-size: 16pt;' class='th'>ปิด</span>
                    <span style='font-weight: bold; font-size: 16pt;' class='en hide'>CLOSE</span>
                </a>
            </div>
        </div>
        <asp:hiddenfield id="hidStatusViewParent" runat="server" />
        <asp:hiddenfield id="hidStatusViewComplete"  runat="server" />
        <asp:hiddenfield id="txtUserTypeActive" runat="server" />
        <asp:hiddenfield id="txtConsentBy" runat="server" />
    </form>
    <div class="overlay"></div>
</body>
</html>
<script type="text/javascript">
    $(document).on({
        ajaxStart: function () {
            $("body").addClass("loading");
        },
        ajaxStop: function () {
            $("body").removeClass("loading");
        }
    });

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

        $('.btnReLogin').click(function () {
            signLoginContract($(this));
        });

        /*
        $('#submit_confirmRequest').click(function () {
            $('form#form1').attr('action', 'confirmRequest.aspx');
            $('form#form1').submit();
        });
        */

        menuStd();
        //checkConsent();
        //onload 
        //disabledStayWith();
        disabledAlive();

        //resetWarrant();
        initialWarrant();

        //ปุ่มยืนยันข้อมูล page กรอกสถานะภาพ บิดา มารดา
        $('.btnConfirmInfo').click(function () {
            var userType = $('#txtUserTypeActive').val();
            var warrantyBy = $('input:radio[name=rdoWarrant]:checked').val();
            var consentBy = $('#txtConsentBy').val();

            if (warrantyBy != "N" ||
                consentBy != "N") {
                //only in system
                var post = ("&userType=" + userType + "&warranty=" + warrantyBy + "&consent=" + consentBy);

                $.ajax({
                    type: "POST",
                    url: "ContractHandler.ashx",
                    data: ("action=CheckENFullNameParent" + post),
                    dataType: "json",
                    //charset: 'tis-620',
                    beforeSend: function () {
                    },
                    error: function (err) {
                    },
                    success: function (data) {
                        if (data.Status == "False") {
                            //FirstNameEN || LastNameEN == Null
                            if (data.Person == "Same") {
                                // alert(data.enFirstName);
                                var firstName = data.enFirstName;
                                var lastName = data.enLastName;

                                if (firstName == "") {
                                    $("#modalCheckENNameSame").find("#txtENFirstName").addClass("invalid");
                                    $("#modalCheckENNameSame").find("#txtENFirstName").val(" ")
                                } else {
                                    $("#modalCheckENNameSame").find("#txtENFirstName").val(firstName);
                                    $("#modalCheckENNameSame").find("#txtENFirstName").addClass("valid");
                                }

                                if (lastName == "") {
                                    $("#modalCheckENNameSame").find("#txtENLastName").addClass("invalid");
                                    $("#modalCheckENNameSame").find("#txtENLastName").val(" ")
                                } else {
                                    $("#modalCheckENNameSame").find("#txtENLastName").val(lastName);
                                    $("#modalCheckENNameSame").find("#txtENLastName").addClass("valid");
                                }

                                $("#modalCheckENNameSame").find(".message").html("กรุณาตรวจสอบข้อมูลชื่อ-นามสกุล (ภาษาอังกฤษ) ของผู้ค้ำประกัน/ผู้ยินยอม");
                                $("#modalCheckENNameSame").find(".message2").html("<a href='https://smartedu.mahidol.ac.th'>คลิกที่นี่เพื่อเข้าสู่ระบบ e-Profile</a> ถ้าระบบ e-Profile ไม่เปิดให้บริการ กรุณาติดต่อ 02-849-4562 เพื่อให้เจ้าหน้าที่เปิดระบบ");
                                Materialize.updateTextFields();
                                $("#modalCheckENNameSame").openModal();
                            }

                            if (data.Person == "Different") {
                                //alert(data.Person);
                                var firstNameWarranty = data.enFirstNameWarranty;
                                var lastNameWarranty = data.enLastNameWarranty;
                                var firstNameConsent = data.enFirstNameConsent;
                                var lastNameConsent = data.enLastNameConsent;

                                if (firstNameWarranty == "") {
                                    $("#modalCheckENNameDiff").find("#txtENFirstNameWarranty").addClass("invalid");
                                    $("#modalCheckENNameDiff").find("#txtENFirstNameWarranty").val(" ")
                                } else {
                                    $("#modalCheckENNameDiff").find("#txtENFirstNameWarranty").val(firstNameWarranty);
                                    $("#modalCheckENNameDiff").find("#txtENFirstNameWarranty").addClass("valid");
                                }

                                if (lastNameWarranty == "") {
                                    $("#modalCheckENNameDiff").find("#txtENLastNameWarranty").addClass("invalid");
                                    $("#modalCheckENNameDiff").find("#txtENLastNameWarranty").val(" ")
                                } else {
                                    $("#modalCheckENNameDiff").find("#txtENLastNameWarranty").val(lastNameWarranty);
                                    $("#modalCheckENNameDiff").find("#txtENLastNameWarranty").addClass("valid");
                                }

                                if (firstNameConsent == "") {
                                    $("#modalCheckENNameDiff").find("#txtENFirstNameConsent").addClass("invalid");
                                    $("#modalCheckENNameDiff").find("#txtENFirstNameConsent").val(" ")
                                } else {
                                    $("#modalCheckENNameDiff").find("#txtENFirstNameConsent").val(firstNameConsent);
                                    $("#modalCheckENNameDiff").find("#txtENFirstNameConsent").addClass("valid");
                                }

                                if (lastNameConsent == "") {
                                    $("#modalCheckENNameDiff").find("#txtENLastNameConsent").addClass("invalid");
                                    $("#modalCheckENNameDiff").find("#txtENLastNameConsent").val(" ")
                                } else {
                                    $("#modalCheckENNameDiff").find("#txtENLastNameConsent").val(lastNameConsent);
                                    $("#modalCheckENNameDiff").find("#txtENLastNameConsent").addClass("valid");
                                }

                                $("#modalCheckENNameDiff").find(".message").html("กรุณาตรวจสอบข้อมูลชื่อ-นามสกุล (ภาษาอังกฤษ) ของผู้ค้ำประกัน/ผู้ยินยอม");
                                $("#modalCheckENNameDiff").find(".message2").html("<a href='https://smartedu.mahidol.ac.th'>คลิกที่นี่เพื่อเข้าสู่ระบบ e-Profile</a> ถ้าระบบ e-Profile ไม่เปิดให้บริการ กรุณาติดต่อ 02-849-4562 เพื่อให้เจ้าหน้าที่เปิดระบบ");
                                Materialize.updateTextFields();
                                $("#modalCheckENNameDiff").openModal();
                            }
                        }
                        else {
                            if (data.Status == "True") {
                                uiPreviewStudentContract($(this));
                            }
                        }
                    }
                });
            } else {
                if (warrantyBy == "N" &&
                    consentBy == "N") {
                    //contract out
                    uiPreviewStudentContract($(this));
                }
            }
        });

        $('.rdoMarried').change(function () {
            enabledAlive();
            resetAlive();
            //resetStayWith();
            resetWarrant();
            //disabledWarrant();
            //showTextWarrant();
        });

        $('.rdoFatherSts').change(function () {
            var id = $(this).attr("id");
            //enabledStayWith();
            //resetStayWith();
            resetWarrant();
            onchangeAlive(id);
            showTextWarrant();
        });

        $('.rdoMotherSts').change(function () {
            var id = $(this).attr("id");
            //enabledStayWith();
            //resetStayWith();
            resetWarrant();
            onchangeAlive(id);
            showTextWarrant();
        });

        /*
        $('.chkStay').change(function () {
            var id = $(this).attr("id");
            //validationInputData();
            onchangeAlive("");
            resetWarrant();
            onchangeStayWith(id);
            enabledWarrant();
            showTextWarrant();
            //enabledWarrant();
        });
        */

        //ปุ่ม confirmParent 2019-08-20
        $('.btnConfirmParent').click(function () {
            setConfirmParent();
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

    //memory of language
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
    Date    : 2015-06-20.
    Perpose : เตือนข้อมูลไม่ครบ
    Method  : myDialog.
    */
    function myDialog(
        messageTH,
        messageEN
    ) {
        if ($('.lang-active').data('lang') == 'th')
            $('.message').html(messageTH);

        if ($('.lang-active').data('lang') == 'en')
            $('.message').html(messageEN);

        $(".lblTitle").html("Warning message.");
        $(".lblTitle").removeClass("blue-text");

        if (!$(".lblTitle").hasClass("red-text"))
            $(".lblTitle").addClass("red-text");

        $('#modalMsg').openModal();
    }

    function myDialogMsg(
        messageTH,
        messageEN
    ) {
        if ($('.lang-active').data('lang') == 'th')
            $('.message').html(messageTH);
        
        if ($('.lang-active').data('lang') == 'en')
            $('.message').html(messageEN);

        $(".lblTitle").html("Message Box");
        $(".lblTitle").removeClass("red-text");

        if (!$(".lblTitle").hasClass("blue-text"))
            $(".lblTitle").addClass("blue-text");

        $('#modalMsg').openModal();
    }

    function myDialogConsentMsg(
        messageTH,
        messageEN
    ) {
        if ($('.lang-active').data('lang') == 'th')
            $('.message').html(messageTH);

        if ($('.lang-active').data('lang') == 'en') {
            $('.message').html(messageEN);

        $(".lblTitle").html("Warning Message");
        $(".lblTitle").removeClass("red-text");

        $('#modalConsent').openModal();
    }

    /*
    function checkConsent() {
        var userType = $('#txtUserTypeActive').val();
    
        if (userType == "STUDENT") {
            var post = ("&userType=" + userType);
            
            $.ajax({
                type: "POST",
                url: "ContractHandler.ashx",
                data: ("action=CheckConsent" + post),
                charset: 'tis-620',
                beforeSend: function () {
                },
                error: function (err) {
                    alert(err);
                },
                success: function (data) {
                    alert(data);
                    
                    if (data == "false")
                        myDialogConsentMsg("<p style='font-size:20px'>ไม่สามารถดำเนินการได้ เนื่องจากยังไม่ได้ดำเนินการยินยอมให้ใช้ข้อมูลที่ระบบ e-Profile โปรดเข้าสู่ระบบ e-Profile เพื่อดำเนินการยินยอมให้ใช้ข้อมูล</p> <a href='https://smartedu.mahidol.ac.th/Authen/login.aspx'>คลิกที่นี่</a>", "<h3>Unable to perform Because the system has not yet consented to the use of information</h3> <a href='https://smartedu.mahidol.ac.th/Authen/login.aspx'>Click here</a>");
                    else
                        $("#submit_frmContract").prop("disabled", false);
                }
            });
        }
    }
    */

    function getParentStatusCondition() {
        var married = $('input:radio[name=rdoMarried]:checked').val();
        var fatherSts = $('input:radio[name=rdoFatherSts]:checked').val();
        var motherSts = $('input:radio[name=rdoMotherSts]:checked').val();
        var chkStay = $(".chkStay");
        var stayFather = "0";
        var stayMother = "0";
        var stayOther = "0";
        var contactLost = "0";
        var arrSts = new Array();
        var arrStay = new Array();

        if (typeof (married) == "undefined")
            married = null;

        if (typeof (fatherSts) == "undefined")
            fatherSts = null;

        if (typeof (motherSts) == "undefined")
            motherSts = null;

        arrSts.push({
            married: married,
            fatherSts: fatherSts,
            motherSts: motherSts
        });

        /*
        if (chkStay[0].checked)
            stayFather = "1";

        if (chkStay[1].checked)
            stayMother = "1";

        if (chkStay[2].checked)
            stayOther = "1";

        if (chkStay[3].checked) {
            contactLost = "1";
            //alert("AAAAA");
        }
        */

        if (chkStay[0])
            contactLost = "1";

        arrStay.push({
            father: null,
            mother: null,
            other: null,
            contactLost: contactLost
        });

        //alert(JSON.stringify(arrSts));
        //alert(JSON.stringify(arrStay));

        var arrData = new Array();

        arrData.push({
            arrSts: arrSts,
            arrStay: arrStay

        });

        return arrData;
    }

    function showTextWarrant() {
        $(".panelContactLost").hide();
        $(".panelContactTolaw").hide();

        var arrData = getParentStatusCondition();
        var arrSts = arrData[0].arrSts[0];
        var arrStay = arrData[0].arrStay[0];
        var married = arrSts.married;
        var fatherSts = arrSts.fatherSts;
        var motherSts = arrSts.motherSts;
        //var stayFather = arrStay.father;
        //var stayMother = arrStay.mother;
        //var stayOther = arrStay.other;

        //Check Alredy Choose Status Father And Mother
        if (fatherSts == null ||
            motherSts == null)
            return

        /*
        //if Uncheck All Stay With Then Reset Warrant
        if (stayFather == "0" &&
            stayMother == "0" &&
            stayOther == "0") {
            resetWarrant();
            
            return;
        }
        */

        //var warrantBy = "ohter";
        //var guaranteeBy = "other";
        var chkStay = $(".chkStay");
        var warrantBy = "";
        var guaranteeBy = "";
        var gVal = "";

        //จดทะเบียน
        if (married == "1") {
            //พ่อและแม่ มีชีวิต และอาศัยอยู่ด้วยกัน
            if (fatherSts == "1" &&
                motherSts == "1") {
                /*
                //พ่อและแม่ มีชีวิต และอาศัยอยู่ด้วยกัน
                if ((fatherSts == "1" && motherSts == "1") &&
                    (stayFather == "1" && stayMother == "1")) {
                */
                warrantBy = "mother_father";
                guaranteeBy = "mother_father";
                gVal = "F"; // set default เป็น แม่ค้ำ พ่อยินยอม

                $(".panelContactLost").show();
                /*
                }

                //พ่อและแม่ มีชีวิต และอาศัยอยู่กับพ่อ
                if ((fatherSts == "1" && motherSts == "1") &&
                    (stayFather == "1" && stayMother != "1")) {
                    warrantBy = "father";
                    guaranteeBy = "mother";
                    gVal = "M";

                    $(".panelContactLost").show();
                }
                        
                //พ่อและแม่ มีชีวิต และอาศัยอยู่กับแม่
                if ((fatherSts == "1" && motherSts == "1") &&
                    (stayFather != "1" && stayMother == "1")) {
                    warrantBy = "mother";
                    guaranteeBy = "father";
                    gVal = "F";
                    
                    $(".panelContactLost").show();
                }
                */
            }
            else {
                //พ่อมีชีวิต แม่ตาย
                if (fatherSts == "1" &&
                    motherSts != "1") {
                    /*
                    //พ่อมีชีวิต แม่ตาย
                    if ((fatherSts == "1" && motherSts != "1") &&
                        (stayFather == "1")) {
                    */
                    warrantBy = "father";
                    guaranteeBy = "";
                    gVal = "F";

                    $(".panelContactLost").show();
                }
                else {
                    //แม่มีชีวิต พ่อตาย
                    if (fatherSts != "1" &&
                        motherSts == "1") {
                        /*
                        //แม่มีชีวิต พ่อตาย
                        if ((fatherSts != "1" && motherSts == "1") &&
                            (stayMother == "1")) {
                        */
                        warrantBy = "mother";
                        guaranteeBy = "";
                        gVal = "M";

                        $(".panelContactLost").show();
                    }
                    else {
                        if (fatherSts != "1" &&
                            motherSts != "1") {
                            warrantBy = "other";
                            guaranteeBy = "ohter";
                            gVal = "N";

                            $(".panelContactTolaw").show();
                        }
                        /*
                        else {
                            //ไม่ต้องตรวจสอบเงื่อนไข อาศัยอยู่กับ
                            if (stayOther == "1") {
                                warrantBy = "other";
                                guaranteeBy = "ohter";
                                gVal = "N";

                                $(".panelContactTolaw").show();
                            }
                        }

                        //ห้าม check สถานะติดต่อ
                        //_chkStay[3].checked = false;
                        */
                    }
                }
            }
        }

        //ไม่จดทะเบียน
        if (married == "2") {
            //alert(_married);
            //พ่อและแม่ มีชีวิต
            if (fatherSts == "1" &&
                motherSts == "1") {
                /*
                //พ่อและแม่ มีชีวิต และอาศัยอยู่ด้วยกัน
                if ((fatherSts == "1" && motherSts == "1") &&
                    (stayFather == "1" && stayMother == "1")) {
                */
                // alert("พ่อและแม่ มีชีวิต และอาศัยอยู่ด้วยกัน");
                warrantBy = "mother";
                guaranteeBy = "";
                gVal = "M";

                $(".panelContactLost").show();
                /*
                }
                else {
                    //พ่อและแม่ มีชีวิต และอาศัยอยู่กับแม่
                    if ((fatherSts == "1" && motherSts == "1") &&
                        (stayFather != "1" && stayMother == "1")) {
                        // alert("พ่อและแม่ มีชีวิต และอาศัยอยู่กับแม่");
                        warrantBy = "mother";
                        guaranteeBy = "";
                        gVal = "M";

                        $(".panelContactLost").show();
                    }
                    else {
                        //พ่อและแม่ มีชีวิต และอาศัยอยู่กับพ่อ
                        if ((fatherSts == "1" && motherSts == "1") &&
                            (stayFather == "1" && stayMother != "1")) {
                            // alert("พ่อและแม่ มีชีวิต และอาศัยอยู่กับพ่อ");
                            warrantBy = "father";
                            guaranteeBy = "";
                            gVal = "-"; // 2020/12/14 ปรับจากค่าว่างเป็น "-" anussara.wan
                            
                            $(".panelContactTolaw").show();
                        }
                    }
                }
                */
            }
            else {
                //พ่อมีชีวิต แม่ตาย
                if (fatherSts == "1" &&
                    motherSts != "1") {
                /*
                }
                else {
                    //พ่อมีชีวิต แม่ตาย และอาศัยอยู่กับพ่อ
                    if ((fatherSts == "1" && motherSts != "1") &&
                        (stayFather == "1" && stayMother != "1")) {
                        alert("พ่อมีชีวิต แม่ตาย และอาศัยอยู่กับพ่อ");
                        warrantBy = "father";
                        guaranteeBy = "";
                        gVal = "-"; //2020/12/14 ปรับจากค่าว่างเป็น "-" anussara.wan
                    }
                */
                    warrantBy = "other";
                    guaranteeBy = "";
                    gVal = "-"; //2020/12/14 ปรับจากค่าว่างเป็น "-" anussara.wan
                    $(".panelContactTolaw").show();
                }
                else {
                    //แม่มีชีวิต พ่อตาย
                    if (fatherSts != "1" &&
                        motherSts == "1") {
                    /*            
                    }
                    else {
                        //แม่มีชีวิต พ่อตาย และอาศัยอยู่กับแม่
                        if ((fatherSts != "1" && motherSts == "1") &&
                            (stayFather != "1" && stayMother == "1")) {
                            alert("แม่มีชีวิต พ่อตาย และอาศัยอยู่กับแม่");
                        }
                    */
                        warrantBy = "mother";
                        guaranteeBy = "";
                        gVal = "M";

                        $(".panelContactLost").show();
                    }
                    else {
                        //พ่อและแม่ตาย อาศัยอบู่กับบุคคลอื่น
                        if (fatherSts != "1" &&
                            motherSts != "1") { 
                            //alert("before last");
                            warrantBy = "other";
                            guaranteeBy = "other";
                            gVal = "N";

                            $(".panelContactTolaw").show();
                        }
                    }
                }
            }
        }

        //หย่าร้าง 
        if (married == "3") {
            //alert("หย่าร้าง");
            //พ่อและแม่ มีชีวิต 
            if (fatherSts == "1" &&
                motherSts == "1") {
                /*
                //พ่อและแม่ มีชีวิต อาศัยอยู่ด้วยกัน
                if ((fatherSts == "1" && motherSts == "1") &&
                    (stayFather == "1" && stayMother == "1")) {
                */
                warrantBy = "mother_father";
                guaranteeBy = "mother_father";
                gVal = "M";

                $(".panelContactLost").show();
                /*
                } else
                    //พ่อและแม่ มีชีวิต อาศัยอยู่กับพ่อ
                    if ((fatherSts == "1" && motherSts == "1") &&
                        (stayFather == "1" && stayMother != "1")) {
                        warrantBy = "father";
                        guaranteeBy = "";
                        gVal = "F";

                        $(".panelContactLost").show();
                    } else
                        //พ่อและแม่ มีชีวิต อาศัยอยู่กับแม่
                        if ((fatherSts == "1" && motherSts == "1") &&
                            (stayFather != "1" && stayMother == "1")) {
                            warrantBy = "mother";
                            guaranteeBy = "";
                            gVal = "M";
                
                            $(".panelContactLost").show();
                */
            }
            else {
                //พ่อมีชีวิต แม่ตาย 
                if (fatherSts == "1" &&
                    motherSts != "1") {
                    /*
                    } else
                        //พ่อมีชีวิต แม่ตาย อาศัยอยู่กับพ่อ
                        if (fatherSts == "1" &&
                            motherSts != "1" &&
                            (stayFather == "1" && stayMother != "1")) {
                    */
                    warrantBy = "father";
                    guaranteeBy = "";
                    gVal = "F";

                    $(".panelContactLost").show();
                }
                else {
                    //แม่มีชีวิต พ่อตาย 
                    if (fatherSts != "1" &&
                        motherSts == "1") {
                        /*
                        } else
                            //แม่มีชีวิต พ่อตาย อาศัยอยู่กับแม่
                            if ((fatherSts != "1" && motherSts == "1") &&
                                (stayFather != "1" && stayMother == "1")) {
                        */
                        warrantBy = "mother";
                        guaranteeBy = "";
                        gVal = "M";

                        $(".panelContactLost").show();
                    }
                    else {
                        warrantBy = "other";
                        guaranteeBy = "ohter";
                        gVal = "N";

                        $(".panelContactTolaw").show();
                    }
                }
            }
        }

        //แยกกันอยู่ 
        if (married == "4") {
            //alert("แยกกันอยู่");
            //พ่อและแม่ มีชีวิต 
            if (fatherSts == "1" &&
                motherSts == "1") {
                /*
                //พ่อและแม่ มีชีวิต อาศัยอยู่ด้วยกัน
                if ((fatherSts == "1" && motherSts == "1") &&
                    (stayFather == "1" && stayMother == "1")) {
                */
                warrantBy = "mother_father";
                guaranteeBy = "mother_father";
                gVal = "M";

                $(".panelContactLost").show();
                /*
                }
                else {
                    //พ่อและแม่ มีชีวิต อาศัยอยู่กับพ่อ
                    if ((fatherSts == "1" && motherSts == "1") &&
                        (stayFather == "1" && stayMother != "1")) {
                        warrantBy = "father";
                        guaranteeBy = "mother";
                        gVal = "F";

                        $(".panelContactLost").show();
                    }
                    else {
                        //พ่อและแม่ มีชีวิต อาศัยอยู่กับแม่
                        if ((fatherSts == "1" && motherSts == "1") &&
                            (stayFather != "1" && stayMother == "1")) {
                            warrantBy = "mother";
                            guaranteeBy = "father";
                            gVal = "M";

                            $(".panelContactLost").show();
                        }
                    }
                }
                */
            }
            else {
                warrantBy = "other";
                guaranteeBy = "ohter";
                gVal = "N";

                $(".panelContactTolaw").show();
            }
        }

        //หม้าย 
        if (married == "5") {
            //พ่อมีชีวิต แม่ตาย
            if (fatherSts == "1" &&
                motherSts != "1") {
                /*
                //พ่อมีชีวิต แม่ตาย และอาศัยอยู่กับพ่อ
                if ((fatherSts == "1" && motherSts != "1") &&
                    (stayFather == "1" && stayMother != "1")) {
                */
                warrantBy = "father";
                guaranteeBy = "";
                gVal = "F";

                $(".panelContactLost").show();
            }
            else {
                //แม่มีชีวิต พ่อตาย 
                if (fatherSts != "1" &&
                    motherSts == "1") {
                /*
                } else
                    //แม่มีชีวิต พ่อตาย และอาศัยอยู่กับแม่
                    if (fatherSts != "1" &&
                        motherSts == "1" &&
                        (stayFather != "1" && _stayMother == "1")) {
                */
                    warrantBy = "mother";
                    guaranteeBy = "";
                    gVal = "M";

                    $(".panelContactLost").show();
                }
                /*
                } else
                    //อาศัยอยู่กับบุคคลอื่น
                    if (stayFather != "1" &&
                        stayMother != "1") { 
                        _warrantBy = "other";
                        guaranteeBy = "ohter";
                        gVal = "N";
                        $(".panelContactTolaw").show();
                    }
                */
            }
        }

        //โสด
        if (married == "6") {
            //พ่อและแม่ มีชีวิต อาศัยอยู่ด้วยกัน
            if (fatherSts == "1" &&
                motherSts == "1") {
                /*
                //พ่อและแม่ มีชีวิต อาศัยอยู่ด้วยกัน
                if ((fatherSts == "1" && motherSts == "1") &&
                    (stayFather == "1" && stayMother == "1")) {
                */
                warrantBy = "mother";
                guaranteeBy = "";
                gVal = "M";
                //warrantBy = "mother_father";
                //guaranteeBy = "mother_father";
                //gVal = "M";
                $(".panelContactLost").show();
                /*
                }
                else {
                    //พ่อและแม่ มีชีวิต อาศัยอยู่กับพ่อ
                    if ((fatherSts == "1" && motherSts == "1") &&
                        (stayFather == "1" && stayMother != "1")) {
                        warrantBy = "father";
                        guaranteeBy = "";
                        gVal = "-"; // 2020/12/14 ปรับจากค่าว่างเป็น "-" anussara.wan

                        $(".panelContactTolaw").show();
                    }
                    else {
                        //พ่อและแม่ มีชีวิต อาศัยอยู่กับแม่
                        if ((fatherSts == "1" && motherSts == "1") &&
                            (stayFather != "1" && stayMother == "1")) {
                            warrantBy = "mother";
                            guaranteeBy = "";
                            gVal = "M";

                            $(".panelContactLost").show();
                        }
                    }
                }
                */
            }
            else {
                //พ่อมีชีวิต แม่ตาย
                if (fatherSts == "1" &&
                    motherSts != "1") {
                /*
                }
                else {
                    //พ่อมีชีวิต แม่ตาย อาศัยอยู่กับพ่อ
                    if (fatherSts == "1" &&
                        motherSts != "1" &&
                        (stayFather == "1" && stayMother != "1")) {
                */
                    warrantBy = "father";
                    guaranteeBy = "";
                    gVal = "-"; //2020/12/14 ปรับจากค่าว่างเป็น "-" anussara.wan

                    $(".panelContactTolaw").show();
                }
                else {
                    //แม่มีชีวิต พ่อตาย 
                    if (fatherSts != "1" &&
                        motherSts == "1") {
                    /*
                    } else
                        //แม่มีชีวิต พ่อตาย อาศัยอยู่กับแม่
                        if ((fatherSts != "1" && motherSts == "1") &&
                            (stayFather != "1" && stayMother == "1")) {
                    */
                        warrantBy = "mother";
                        guaranteeBy = "";
                        gVal = "M";

                        $(".panelContactLost").show();
                    }
                    else {
                        warrantBy = "other";
                        guaranteeBy = "ohter";
                        gVal = "N";

                        $(".panelContactTolaw").show();
                    }
                }
            }
        }

        var beforeCheckedStayLostWarrant = warrantBy;
        var beforeCheckedStayLostGuarantee = guaranteeBy;
        var beforeCheckedStayLostGVal = gVal;

        //start event check/uncheck ไม่สามารถติดต่อผู้ค้ำประกันได้
        $("#chkStayLost").click(function () {
            if ($(this).is(':checked')) {
                $('chkStayLost').prop('checked', true);
                //alert("checked");
                warrantBy = "other";
                guaranteeBy = "ohter";
                gVal = "N";

                uiSPWarrant(warrantBy);

                var htmlG = "<p>บุคคลอื่น</p>";

                $('.spConsent').html(_htmlG);
                $('#txtConsentBy').val(_gVal);
                $(".panelContactTolaw").show();
            }
            else {
                $('chkStayLost').prop('checked', false);
                //alert("unchecked");
                warrantBy = beforeCheckedStayLostWarrant;
                guaranteeBy = beforeCheckedStayLostGuarantee;
                gVal = beforeCheckedStayLostGVal;

                uiSPWarrant(warrantBy);

                var htmlG = "";

                if (guaranteeBy == "mother_father") {
                    if (married == "3") {
                        htmlG = "<p>มารดา</p>";
                    }
                    else {
                        htmlG = "<p>บิดา</p>";
                    }

                    //script when select father or mother after event click chkStayLost
                    $(".rdoWarrant").click(function () {
                        var warVal = $(this).val();
                        var guaTxt = "";
                        var gVal2 = "";

                        //alert("Click : " + _warVal);
                        //check status for father
                        if (warVal == "F" &&
                            (married == "1" || married == "2")) {
                            guaTxt = "<p>มารดา</p>";
                            gVal2 = "M";
                        }
                        else {
                            //หย่าร้าง เลือกพ่อเป็นผู้ค้ำ
                            if (warVal == "F" &&
                                married != "1" &&
                                married != "2" &&
                                married != "4") {
                                guaTxt = "<p>บิดา</p>";
                                gVal2 = "F";
                            }
                            else {
                                //แยกกันอยู่ เลือกพ่อเป็นคนค้ำ
                                if (warVal == "F" &&
                                    married == "4") {
                                    guaTxt = "<p>มารดา</p>";
                                    gVal2 = "M";
                                }
                            }
                        }

                        //check status for mother
                        if (warVal == "M" &&
                            (married == "1" || married == "2")) {
                            guaTxt = "<p>บิดา</p>";
                            gVal2 = "F";
                        }
                        else {
                            //หย่าร้าง เลือกแม่เป็นผู้ค้ำ
                            if (warVal == "M" &&
                                married != "1" &&
                                married != "2" &&
                                married != "4") {
                                guaTxt = "<p>มารดา</p>";
                                gVal2 = "M";
                            }
                            else {
                                //แยกกันอยู่ เลือกแม่เป็นคนค้ำ
                                if (warVal == "M" &&
                                    married == "4") {
                                    guaTxt = "<p>บิดา</p>";
                                    gVal2 = "F";
                                }
                            }
                        }

                        $('.spConsent').html(guaTxt);
                        $('#txtConsentBy').val(gVal2);
                    });
                }
                else {
                    if (guaranteeBy == "mother") {
                        htmlG = "<p>มารดา</p>";
                    }
                    else {
                        if (guaranteeBy == "father") {
                            htmlG = "<p>บิดา</p>";
                        }
                        else {
                            if (guaranteeBy == "other") {
                                htmlG = "<p>บุคคลอื่น</p>";
                            }
                            else {
                                htmlG = "<p>-</p>";
                            }
                        }
                    }
                }

                $('.spConsent').html(htmlG);
                $('#txtConsentBy').val(gVal);
                $(".panelContactTolaw").hide();
            }
        });
        //end event check/uncheck ไม่สามารถติดต่อผู้ค้ำประกันได้

        uiSPWarrant(_warrantBy);

        var htmlG = "";

        if (guaranteeBy == "mother_father") {
            if (married == "3") {
                htmlG = "<p>มารดา</p>";
            } else {
                htmlG = "<p>บิดา</p>";
            }

            //script when select father or mother Never Click chkStayLost
            $(".rdoWarrant").click(function () {
                var warVal = $(this).val();
                var guaTxt = "";
                var gVal2 = "";

                //alert("Not Click : " + _warVal);
                //check status for father
                if (warVal == "F" &&
                    (married == "1" || married == "2")) {
                    guaTxt = "<p>มารดา</p>";
                    gVal2 = "M";
                }
                else {
                    //หย่าร้าง เลือกพ่อเป็นผู้ค้ำ
                    if (warVal == "F" &&
                        married != "1" &&
                        married != "2" &&
                        married != "4") {
                        guaTxt = "<p>บิดา</p>";
                        gVal2 = "F";
                    }
                    else {
                        //แยกกันอยู่ เลือกพ่อเป็นคนค้ำ
                        if (warVal == "F" &&
                            married == "4") {
                            guaTxt = "<p>มารดา</p>";
                            gVal2 = "M";
                        }
                    }
                }

                //check status for mother
                if (warVal == "M" &&
                    (married == "1" || married == "2")) {
                    guaTxt = "<p>บิดา</p>";
                    gVal2 = "F";
                }
                else {
                    //หย่าร้าง เลือกแม่เป็นผู้ค้ำ
                    if (warVal == "M" &&
                        married != "1" &&
                        married != "2" &&
                        married != "4") {
                        guaTxt = "<p>มารดา</p>";
                        gVal2 = "M";
                    }
                    else {
                        //แยกกันอยู่ เลือกแม่เป็นคนค้ำ
                        if (warVal == "M" &&
                            married == "4") {
                            guaTxt = "<p>บิดา</p>";
                            gVal2 = "F";
                        }
                    }
                }

                $('.spConsent').html(guaTxt);
                $('#txtConsentBy').val(gVal2);
            });
        }
        else {
            if (guaranteeBy == "mother") {
                htmlG = "<p>มารดา</p>";
            }
            else {
                if (guaranteeBy == "father") {
                    htmlG = "<p>บิดา</p>";
                }
                else {
                    if (guaranteeBy == "other") {
                        htmlG = "<p>บุคคลอื่น</p>";
                    }
                    else {
                        htmlG = "<p>-</p>";
                    }
                }
            }
        }

        $('.spConsent').html(htmlG);
        $('#txtConsentBy').val(gVal);
    }

    function uiPreviewStudentContract(this) {
        //after click btnConfirmInfo
        var userType = $('#txtUserTypeActive').val();
        var warrantyBy = $('input:radio[name=rdoWarrant]:checked').val();
        var consentBy = $('#txtConsentBy').val();
        var arrData = getParentStatusCondition();
        var arrSts = _arrData[0].arrSts[0];
        //var arrStay = arrData[0].arrStay[0];
        var errTh = "";
        var errEn = "";

        if (arrSts.married == null ||
            arrSts.fatherSts == null ||
            arrSts.motherSts == null) {
            errTh += "- กรุณาเลือกสถานะ บิดา/มารดา ให้ครบถ้วน<br><br>";
            errEn += "- Please specify status info<br><br>";
        }

        /*
        if (arrStay.father == "0" &&
            arrStay.mother == "0" &&
            arrStay.other == "0") {
            errTh += "- กรุณาเลือกข้อมูล อาศัยอยู่กับ<br><br>";
            errEn += "- Please specify stay with<br><br>";
        }
        */

        //alert(errEn);
        if (errTh != "") {
            myDialog(errTh, errEn);

            return false;
        }

        /*
        if (arrStay.contactLost == "1") {
            myDialog("นักศึกษาเลือก ไม่สามารติดต่อผู้ค้ำประกันตามเงื่อนไขได้<BR>- กรุณาติดต่อทำสัญญาที่กองกฏหมาย เพื่อให้ผู้อื่นค้ำประกัน", "Lost Contact");
        }
        */

        var post = ("&userType=" + userType + "&warranty=" + warrantyBy + "&consent=" + consentBy);
        //alert(post);
        $.ajax({
            type: "POST",
            url: "ContractHandler.ashx",
            data: ("action=UiPreviewContrat" + post),
            charset: 'tis-620',
            beforeSend: function () {
                this.hide();
                //myDialog("กำลังดำเนินการ กรุณารอสักครู่...", "System Processing. Please Wait...");
            },
            error: function (err) {
                //alert(err);
                btnLogin.show();
            },
            success: function (data) {
                //$('#modalMsg').Modal("hide");
                this.show();
                //alert(data);
                $("#divParentStatus").hide();
                $("#divContractView").html(data);

                $('#divContractView .btnReLogin').unbind();
                $('#divContractView .btnReLogin').click(function () {
                    signLoginContract($(this));
                });

                $('#divContractView .btnBack').unbind();
                $('#divContractView .btnBack').click(function () {
                    $("#divParentStatus").show();
                    $("#divContractView").html("");
                });

                /*
                $('#submit_confirmRequest').click(function () {
                    $('form#form1').attr('action', 'confirmRequest.aspx');
                    $('form#form1').submit();
                });
                */
            }
        });
    }

    /*
    Auther  : Odd.Nopparat
    Date    : 20-11-2015
    Perpose : re login
    Method  :
    */
    function signLoginContract(this) {
        //student login..
        //var no = this.data("options").no;
        //alert(no);
        var btnLogin = this;
        var userType = $('#txtUserTypeActive').val();
        var username = $.trim($('#username').val());
        var password = $.trim($('#password').val());
        var arrData = new Array();
        var arrInput = new Array();

        arrData.push({
            username: username,
            password: password,
            userType: userType
        });

        if (userType == "STUDENT") {
            //get data form student contract
            var arrInfo = getParentStatusCondition();
            //console.log(arrInfo);
            var arrSts = arrInfo[0].arrSts[0];
            var arrStay = arrInfo[0].arrStay[0];
            var warrantBy = $('input:radio[name=rdoWarrant]:checked').val();
            var consentBy = $('#txtConsentBy').val();

            if (warrantBy == null ||
                consentBy == null) {
                myDialog('ระบบไม่พบข้อมูลผู้ค้ำประกัน/ยินยอม<br>- กรุณาเลือกเงื่อนไขสถานะผู้ปกครองอีกครั้ง', 'Data Incorrect!!!<BR>Please Specify Status Again.');

                return false
            }

            arrInput.push({
                warrantBy: warrantBy,
                consentBy: consentBy,
                marriage: arrSts.married,
                aliveM: arrSts.motherSts,
                aliveF: arrSts.fatherSts,
                //liveWithM: arrStay.mother
                //liveWithF: arrStay.father
                //liveWithOther: arrStay.other
                liveWithM: null,
                liveWithF: null,
                liveWithOther: null,
                contactFm: arrStay.contactLost //ไม่สามารติดต่อผู้ค้ำประกันตามเงื่อนไขได้
            });
        }
        else {
            //form parent not use this data
            arrInput.push({
                warrantBy: null,
                consentBy: null,
                marriage: null,
                aliveM: null,
                aliveF: null,
                liveWithM: null,
                liveWithF: null,
                liveWithOther: null,
                contactFm: null
            });
        }

        if (username === '' ||
            (password === '' && userType == "PARENT")) {
            if (userType == "PARENT") {
                myDialog('กรุณารหัสผู้ใช้ และรหัสผ่าน ให้ถูกต้อง', 'Please specify username and password');
            }
            else {
                if (userType == "STUDENT") {
                    myDialog('กรุณาระบุรหัสนักศึกษา และรหัสผ่าน ให้ถูกต้อง', 'Please specify student ID and password');
                } else {
                    myDialog('รูปแบบข้อมูลไม่ถูกต้อง!!! กรุณา log in ใหม่', 'Data Incorrect!!! Please log in');
                }
            }

            return false;
        }
        else {
            //$('#form1').submit();
            var post = ("&strSign=" + JSON.stringify(arrData) + "&strInput=" + JSON.stringify(arrInput));
            //console.log(post);
            //alert(post);
            $.ajax({
                type: "POST",
                url: "ContractHandler.ashx",
                data: ("action=SignLogin" + post),
                charset: 'tis-620',
                beforeSend: function () {
                    btnLogin.hide();
                    //myDialog("กำลังดำเนินการบันทึกสัญญา กรุณารอสักครู่", "System Processing. Please Wait.");
                },
                error: function (err) {
                    alert(err);
                    btnLogin.show();
                },
                success: function (data) {
                    //console.log(data);
                    btnLogin.show();
                    // $('.modal').closeModal();
                    $("#divResult").html(data);
                    //$("#divResult").show();
                    //$('#submit_confirmRequest').show();
                    var txtProcess = $("#divResult .txtProcessStatus");
                    var msgTH = "";
                    var msgEN = "";
                    var processStatus = "0";

                    if (typeof (txtProcess) != "undefined") {
                        processStatus = _txtProcess.val();
                        msgTH = txtProcess.data("msg_th");
                        msgEN = txtProcess.data("msg_en");
                        
                        if (processStatus == "1") {
                            $("#divContractView").html("");
                            $("#divComplete").html(data);
                            $("#divComplete").show();
                            $('#submit_confirmRequest').click(function () {
                                $('form#form1').attr('action', 'confirmRequest.aspx');
                                $('form#form1').submit();
                            });
                        }
                    }
                    else {
                        msgTH = "การสื่อสารขัดข้อง!!! กรุณากดปุ่ม F5 เพื่อประมวลผลใหม่";
                        msgEN = "Transaction Error!!! Please Press F5 to Reprocees";
                    }

                    if (processStatus == "0") {
                        myDialog(msgTh, msgEN);
                    }

                    //alert("res=" + processStatus);
                    //alert(data);
                }
            });
        }
    }

    function menuStd() {
        $("#divParentStatus").hide();
        $("#divComplete").hide();
        $('#submit_frmContract').click(function () {
            //hide menu student
            $('#divMenuStd').html("");

            if ($('#hidStatusViewComplete').val() == "1") {
                $("#divComplete").show();

                $('button#submit_confirmRequest').click(function () {
                    $('form#form1').attr('action', 'confirmRequest.aspx');
                    $('form#form1').submit();
                });
            }
            else {
                $("#divParentStatus").show();
            }
        });

        $('#submit_confirmRequest').click(function () {
            $('form#form1').attr('action', 'confirmRequest.aspx');
            $('form#form1').submit();
        });
    }

    /*
    Auther  : anussara.wan
    Date    : 2019-08-20
    Perpose : สำหรับส่งค่าหน้า confirm Parent ไปบันทึกยังตาราง ectParentAndStaff
    Method  : confirmParent
    */
    function setConfirmParent() {
        var errTH1 = "";
        var errEN1 = "";
        var userType = $('#txtUserTypeActive').val();
        var post = ("&userType=" + userType);

        if ($('#chkConP').is(':checked')) {
            $.ajax({
                type: "POST",
                url: "ContractHandler.ashx",
                data: ("action=SetConfirmParent" + post),
                charset: 'tis-620',
                beforeSend: function () {
                },
                error: function (err) {
                    alert(err);
                },
                success: function (data) {
                    $("#divLogin").hide();
                    $("#divContractView").html(data);
                    $('#divContractView .btnReLogin').unbind();

                    $('#divContractView .btnReLogin').click(function () {
                        signLoginContract($(this));
                    });
                }
            });
        }
        else {
            errTH1 += "- กรุณาทำเครื่องหมายถูกหน้าข้อความดังกล่าว<br><br>";
            errEN1 += "- Please Checkbox status info<br><br>";

            if (errTH1 != "") {
                myDialog(errTH1, errEN1);

                return false;
            }
        }
    }

    function disabledStayWith() {
        $("#chkStayF").attr("disabled", true);
        $("#chkStayM").attr("disabled", true);
        $("#chkStayO").attr("disabled", true);
    }

    function enabledStayWith() {
        $("#chkStayF").attr("disabled", false);
        $("#chkStayM").attr("disabled", false);
        $("#chkStayO").attr("disabled", false);
    }

    function disabledAlive() {
        $(".rdoFatherSts").attr("disabled", true);
        $(".rdoMotherSts").attr("disabled", true);
    }

    function enabledAlive() {
        var rdoMarried = $('input:radio[name=rdoMarried]:checked').val();

        //จดทะเบียน
        if (rdoMarried == "1") {
            $("#rdoFatherStsNo").attr("disabled", true);
            $("#rdoMotherStsNo").attr("disabled", true);
            $("#rdoFatherStsYes").attr("disabled", false);
            $("#rdoMotherStsYes").attr("disabled", false);
        }
        else {
            //แยกกันอยู่
            if (rdoMarried == "4") {
                $("#rdoFatherStsNo").attr("disabled", true);
                $("#rdoMotherStsNo").attr("disabled", true);
                $("#rdoFatherStsYes").attr("disabled", false);
                $("#rdoMotherStsYes").attr("disabled", false);
            }
            else {
                //ohter type
                $(".rdoFatherSts").attr("disabled", false);
                $(".rdoMotherSts").attr("disabled", false);
            }
        }
    }

    function disabledWarrant() {
        $("#rdoWF").attr("disabled", true);
        $("#rdoWM").attr("disabled", true);
        $("#rdoWO").attr("disabled", true);
    }

    function enabledWarrant() {
        $("#rdoWF").attr("disabled", false);
        $("#rdoWM").attr("disabled", false);
        $("#rdoWO").attr("disabled", false);
    }

    function resetAlive() {
        $(".rdoFatherSts").prop('checked', false);
        $(".rdoMotherSts").prop('checked', false);
    }

    function resetStayWith() {
        $("#chkStayF").prop('checked', false);
        $("#chkStayM").prop('checked', false);
        $("#chkStayO").prop('checked', false);
        $("#chkStayF").prop('disabled', false);
        $("#chkStayM").prop('disabled', false);
        $("#chkStayO").prop('disabled', false);
    }

    function initialWarrant() {
        var htmlForpPanelContactLost = ("" +
            "<span class='title'>" +
            "   <span class='th red-text'>สถานะติดต่อ :&nbsp;</span>" +
            "   <input class='chkStay' name='chkStay' type='checkbox' id='chkStayLost' value='1' />" +
            "   <label for='chkStayLost'>" +
            "       <span class='th red-text'>ไม่สามารถติดต่อ ผู้ค้ำประกันได้</span>" +
            "       <span class='en hide red-text'>Family not found</span>" +
            "   </label>" +
            "</span>"
        );

        $(".panelContactLost").html(htmlForpPanelContactLost);
        $(".spWarrant").html("");
        $(".panelContactLost").hide();
        $(".panelContactTolaw").hide();
    }

    function resetWarrant() {
        var htmlForpPanelContactLost = ("" +
            "<span class='title'>" +
            "   <span class='th red-text'>สถานะติดต่อ :&nbsp;</span>" +
            "   <input class='chkStay' name='chkStay' type='checkbox' id='chkStayLost' value='1' />" +
            "   <label for='chkStayLost'>" +
            "       <span class='th red-text'>ไม่สามารถติดต่อ ผู้ค้ำประกันได้</span>" +
            "       <span class='en hide red-text'>Family not found</span>" +
            "   </label>" +
            "</span>"
        );

        $('.panelContactLost').html(htmlForpPanelContactLost);
        $('.spWarrant').html("");
        $('.spConsent').html("");
        $(".panelContactLost").hide();
        $(".panelContactTolaw").hide();
    }

    function onchangeAlive(id) {
        var rdoMarried = $('input:radio[name=rdoMarried]:checked').val();
        var dadAlive = $('input:radio[name=rdoFatherSts]:checked').val();
        var momAlive = $('input:radio[name=rdoMotherSts]:checked').val();

        //หม้าย
        if (rdoMarried == "5") {
            if (id == "rdoFatherStsYes") {
                if ($("#rdoFatherStsYes").is(':checked')) {
                    //dad alive checked
                    $('#rdoMotherStsYes').prop('checked', false);
                    $('#rdoMotherStsYes').prop('disabled', true);

                    $('#rdoMotherStsNo').prop('checked', true);
                    $('#rdoMotherStsNo').prop('disabled', false);

                    //can stay with dad
                    //$("#chkStayF").attr("disabled", false);

                    //can't stay with mom
                    //$("#chkStayM").prop('checked', false);
                    //$("#chkStayM").attr("disabled", true);
                }
            }
            else {
                if (id == "rdoFatherStsNo") {
                    if ($("#rdoFatherStsNo").is(':checked')) {
                        //dad died checked
                        $('#rdoMotherStsYes').prop('checked', true);
                        $('#rdoMotherStsYes').prop('disabled', false);

                        $('#rdoMotherStsNo').prop('disabled', true);
                        $('#rdoMotherStsNo').prop('checked', false);

                        //can't stay with dad
                        //$("#chkStayF").prop('checked', false);
                        //$("#chkStayF").attr("disabled", true);

                        //can stay with mom
                        //$("#chkStayM").attr("disabled", false);
                    }
                }
            }

            if (id == "rdoMotherStsYes") {
                if ($("#rdoMotherStsYes").is(':checked')) {
                    //dad alive checked
                    $('#rdoFatherStsYes').prop('checked', false);
                    $('#rdoFatherStsYes').prop('disabled', true);

                    $('#rdoFatherStsNo').prop('checked', true);
                    $('#rdoFatherStsNo').prop('disabled', false);

                    //can stay with mom
                    //$("#chkStayM").attr("disabled", false);

                    //can't stay with dad
                    //$("#chkStayF").prop('checked', false);
                    //$("#chkStayF").attr("disabled", true);
                }
            }
            else {
                if (id == "rdoMotherStsNo") {
                    if ($("#rdoFatherStsNo").is(':checked')) {
                        //dad died checked
                        $('#rdoFatherStsYes').prop('checked', true);
                        $('#rdoFatherStsYes').prop('disabled', false);

                        $('#rdoFatherStsNo').prop('disabled', true);
                        $('#rdoFatherStsNo').prop('checked', false);

                        //can't stay with mom
                        //$("#chkStayM").prop('checked', false);
                        //$("#chkStayM").attr("disabled", true);

                        //can stay with dad
                        //$("#chkStayF").attr("disabled", false);
                    }
                }
            }
        }
        /*
        }
        else {
            //dad died
            if (dadAlive == "2") {
                $("#chkStayF").prop('checked', false);
                $("#chkStayF").attr("disabled", true);
            }
            else {
                //dad alive
                if (dadAlive == "1") {
                    $("#chkStayF").attr("disabled", false);
                }

                //mom died
                if (momAlive == "2") { 
                    $("#chkStayM").prop('checked', false);
                    $("#chkStayM").attr("disabled", true);
                }
                else {
                    //mom alive
                    if (momAlive == "1") { 
                        $("#chkStayM").attr("disabled", false);
                    }
                }
            }
        }
        */
    }

    function onchangeStayWith(id) {
        var rdoMarried = $('input:radio[name=rdoMarried]:checked').val();
        var dadAlive = $('input:radio[name=rdoFatherSts]:checked').val();
        var momAlive = $('input:radio[name=rdoMotherSts]:checked').val();

        //หย่าร้างและแยกกันอยู่
        if (rdoMarried == "4" ||
            rdoMarried == "3") {
            if (id == "chkStayF") {
                if ($("#chkStayF").is(':checked')) {
                    $('#chkStayM').prop('checked', false);
                    $('#chkStayM').prop('disabled', true);
                    $('#chkStayO').prop('checked', false);
                    $('#chkStayO').prop('disabled', true);
                }
                else {
                    //dad alive
                    if (dadAlive == "1") {
                        $('#chkStayF').prop('disabled', false);
                    }
                    else {
                        //mom alive
                        if (momAlive == "1") {
                            $('#chkStayM').prop('disabled', false);
                        }
                    }

                    $('#chkStayO').prop('checked', false);
                    $('#chkStayO').prop('disabled', false);
                }
            }

            if (id == "chkStayM") {
                if ($("#chkStayM").is(':checked')) {
                    $('#chkStayF').prop('checked', false);
                    $('#chkStayF').prop('disabled', true);
                    $('#chkStayO').prop('checked', false);
                    $('#chkStayO').prop('disabled', true);
                }
                else {
                    //dad alive
                    if (dadAlive == "1") {
                        $('#chkStayF').prop('disabled', false);
                    }
                    else {
                        //mom alive
                        if (momAlive == "1") {
                            $('#chkStayM').prop('disabled', false);
                        }
                    }

                    $('#chkStayO').prop('checked', false);
                    $('#chkStayO').prop('disabled', false);
                }
            }

            if (id == "chkStayO") {
                if ($("#chkStayO").is(':checked')) {
                    $('#chkStayF').prop('checked', false);
                    $('#chkStayF').prop('disabled', true);
                    $('#chkStayM').prop('checked', false);
                    $('#chkStayM').prop('disabled', true);
                }
                else {
                    //dad alive
                    if (dadAlive == "1") {
                        $('#chkStayF').prop('disabled', false);
                    }
                    else {
                        //mom alive
                        if (momAlive == "1") {
                            $('#chkStayM').prop('disabled', false);
                        }
                    }
                }
            }
        }

        //หม้าย
        if (rdoMarried == "5") {
            if (id == "chkStayO") {
                if ($("#chkStayO").is(':checked')) {
                    //checked stay with other
                    $('#chkStayF').prop('checked', false);
                    $('#chkStayF').prop('disabled', true);
                    $('#chkStayM').prop('checked', false);
                    $('#chkStayM').prop('disabled', true);
                }
                else {
                    //uncheck stay with other
                    //dad alive
                    if (dadAlive == "1") { 
                        $('#chkStayF').prop('disabled', false);
                    }
                    else {
                        //mom alive
                        $('#chkStayM').prop('disabled', false);
                    }
                }
            }
        }

        //โสด
        if (rdoMarried == "6") { 
            if (id == "chkStayF") {
                if ($("#chkStayF").is(':checked')) {
                    $('#chkStayM').prop('checked', false);
                    $('#chkStayM').prop('disabled', true);
                    $('#chkStayO').prop('checked', false);
                    $('#chkStayO').prop('disabled', true);
                }
                else {
                    //mom alive
                    if (momAlive == "1") { 
                        $('#chkStayM').prop('disabled', false);
                        $('#chkStayM').prop('checked', false);
                    }

                    $('#chkStayO').prop('checked', false);
                    $('#chkStayO').prop('disabled', false);
                }
            }

            if (id == "chkStayM") {
                if ($("#chkStayM").is(':checked')) {
                    $('#chkStayF').prop('checked', false);
                    $('#chkStayF').prop('disabled', true);
                    $('#chkStayO').prop('checked', false);
                    $('#chkStayO').prop('disabled', true);
                }
                else {
                    //dad alive
                    if (dadAlive == "1") { 
                        $('#chkStayF').prop('disabled', false);
                        $('#chkStayF').prop('checked', false);
                    }

                    $('#chkStayO').prop('checked', false);
                    $('#chkStayO').prop('disabled', false);
                }
            }

            if (id == "chkStayO") {
                if ($("#chkStayO").is(':checked')) {
                    $('#chkStayF').prop('checked', false);
                    $('#chkStayF').prop('disabled', true);
                    $('#chkStayM').prop('checked', false);
                    $('#chkStayM').prop('disabled', true);
                }
                else {
                    //dad alive
                    if (dadAlive == "1") {
                        $('#chkStayF').prop('disabled', false);
                        $('#chkStayF').prop('checked', false);
                    }
                    else {
                        //mom alive
                        if (momAlive == "1") {
                            $('#chkStayM').prop('disabled', false);
                            $('#chkStayM').prop('checked', false);
                        }
                    }
                }
            }
        }
    }

    function uiSPWarrant(warrantBy) {
        var htmlW = "";
        var stsF = "";
        var stsM = "";
        var stsO = "";
        var styF = "";
        var styM = "";
        var styO = "";

        if (warrantBy == "mother_father") {
            stsO = " disabled ";
            stsM = " checked ";
            styO = " style='text-decoration: line-through;' "
        }
        else {
            if (warrantBy == "mother") {
                stsF = " disabled '";
                stsM = " checked ";
                stsO = " disabled ";
                styF = " style='text-decoration: line-through;' ";
                styO = " style='text-decoration: line-through;' ";
            }
            else {
                if (warrantBy == "father") {
                    stsF = " checked ";
                    stsM = " disabled ";
                    stsO = " disabled ";
                    styM = " style='text-decoration: line-through;' ";
                    styO = " style='text-decoration: line-through;' ";
                }
                else {
                    if (warrantBy == "other") {
                        stsF = " disabled ";
                        stsM = " disabled ";
                        stsO = " checked ";
                        styF = " style='text-decoration: line-through;' ";
                        styM = " style='text-decoration: line-through;' ";
                    }
                }
            }
        }

        htmlW = ("" +
            "<p>" +
            "   <input class='rdoWarrant' name='rdoWarrant' type='radio' id='rdoWF' value='F' " + stsF + " />" +
            "   <label for='rdoWF'>" +
            "       <span class='th' " + styF + ">บิดา</span>" +
            "       <span class='en hide'>Father</span>" +
            "   </label>&nbsp;&nbsp;" +
            "   <input class='rdoWarrant' name='rdoWarrant' type='radio' id='rdoWM' value='M' " + stsM + " />" +
            "   <label for='rdoWM'>" +
            "       <span class='th' " + styM + ">มารดา</span>" +
            "       <span class='en hide'>Mother</span>" +
            "   </label>" +
            "   <input class='rdoWarrant' name='rdoWarrant' type='radio' id='rdoWO' value='N' " + stsO + " />" +
            "   <label for='rdoWO'>" +
            "       <span class='th' " + styO + ">บุคคลอื่น</span>" +
            "       <span class='en hide'>Other</span>" +
            "   </label>&nbsp;&nbsp;" +
            "</p>"
        );

        $('.spWarrant').html(htmlW);
    }

    function onclickRdoWarrant(text) {
        $(".rdoWarrant").click(function () {
            //alert(text);
            var warVal = $(this).val();
            var guaTxt = "";
            var gVal2 = "";
            //alert(warVal);

            if (warVal == "F" &&
                (married == "1" || married == "2")) {
                guaTxt = "<p>มารดา</p>";
                gVal2 = "M";
            }
            else {
                //หย่าร้าง เลือกพ่อเป็นผู้ค้ำ
                if (warVal == "F" &&
                    married != "1" &&
                    married != "2") {
                    guaTxt = "<p>บิดา</p>";
                    gVal2 = "F";
                }
            }

            if (warVal == "M" &&
                (married == "1" || married == "2")) {
                guaTxt = "<p>บิดา</p>";
                gVal2 = "F";
            }
            else {
                //หย่าร้าง เลือกแม่เป็นผู้ค้ำ
                if (warVal == "M" &&
                    married != "1" &&
                    married != "2") {
                    guaTxt = "<p>มารดา</p>";
                    gVal2 = "M";
                }
            }

            $('.spConsent').html(guaTxt);
            $('#txtConsentBy').val(gVal2);
        });
    }
</script>