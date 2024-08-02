<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="false" EnableEventValidation="false" CodeBehind="frmContract.aspx.cs" Inherits="eContract.frmContract" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang="th">
<head id="Head1" runat="server">
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
    <style type="text/css">
        .hoverMarital {
            display: none;
            width: 100px;
            height: 100px;
            color: #000;
            background: #ccc;
            position: absolute;
        }
    </style>
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
<body style="background-color: #F2F0EF;">
    <form id="form1" runat="server" method="post">
        <nav id="navBar" runat="server" class='' style="background-color: #253988" role='navigation'></nav>
        <div id="index-bannerx" class="parallax-container" style="height: 170px;">
            <!--Profile-->
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

<%--        <div class="container" id="divComplete" runat="server"></div>--%>
        <!-- footer banner -->
        <div class="page-footer" style="background-color: #A5802E;" id="divFooter" runat="server"></div>

        <!-- Modal Structure -->
        <div id="modalMsg" class="modal">
            <div class="modal-content">
                <h4 class="red-text lblTitle">Warning message.</h4>
                <p class="message red-text text-darken-3">
                </p>
            </div>
            <div class="modal-footer">
                <a href="javascript:void(0);" class="modal-action modal-close waves-effect waves-green btn-flat">
                    <span style='font-weight: bold; font-size: 16pt;' class='th'>ปิด</span>
                    <span style='font-weight: bold; font-size: 16pt;' class='en hide'>CLOSE</span></a>
            </div>
        </div>


        <!-- Modal Check Consent From e-Profile -->
        <div id="modalConsent" class="modal">
            <div class="modal-content">
                <h4 class="red-text lblTitle">Warning message.</h4>
                <p class="message red-text text-darken-3">
                </p>
            </div>
            <div class="modal-footer">
                <a href="javascript:void(0);" class="modal-action modal-close waves-effect waves-green btn-flat">
                    <span style='font-weight: bold; font-size: 16pt;' class='th'>ปิด</span>
                    <span style='font-weight: bold; font-size: 16pt;' class='en hide'>CLOSE</span></a>
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
                    <span style='font-weight: bold; font-size: 16pt;' class='en hide'>CLOSE</span></a>
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
                    <span style='font-weight: bold; font-size: 16pt;' class='en hide'>CLOSE</span></a>
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
    /// <summary>
    /// Auther : Odd.Nopparat
    /// Date   : 2015-11-20.
    /// Perpose: initial parameter
    /// Method : .
    /// </summary>
    $(function () {

        $('.parallax').parallax();
        // mobile display mini - message
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

        //$('#submit_confirmRequest').click(function () {
        //    $('form#form1').attr('action', 'confirmRequest.aspx');
        //    $('form#form1').submit();
        //});

        menuStd();
        //checkConsent();
        //onload 
        //disabledStayWith();
        disabledAlive();

        //resetWarrant();
        initialWarrant();

        //ปุ่มยืนยันข้อมูล page กรอกสถานะภาพ บิดา มารดา
        $('.btnConfirmInfo').click(function () {
            var _userType = $('#txtUserTypeActive').val();
            var warrantyBy = $('input:radio[name=rdoWarrant]:checked').val();
            var consentBy = $('#txtConsentBy').val();
            if (warrantyBy != "N" || consentBy != "N") {
                //Only In System
                var _post = "&userType=" + _userType + "&warranty=" + warrantyBy + "&consent=" + consentBy;
                $.ajax({
                    type: "POST",
                    url: "ContractHandler.ashx",
                    data: "action=CheckENFullNameParent" + _post,
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
                                //alert(data.enFirstName);
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
                        else if (data.Status == "True") {
                            uiPreviewStudentContract($(this));
                        }
                    }
                });
            } else if (warrantyBy == "N" && consentBy == "N") {
                //Contract Out
                uiPreviewStudentContract($(this));
            }


        });

        $('.rdoMarried').change(function () {
            enabledAlive();
            resetAlive();
            /*            resetStayWith();*/
            resetWarrant();
            //disabledWarrant();
            //showTextWarrant();
        });
        $('.rdoFatherSts').change(function () {
            var id = $(this).attr("id");
            /*            enabledStayWith();*/
            /*            resetStayWith();*/
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
        //$('.chkStay').change(function () {
        //    var id = $(this).attr("id");
        //    //ValidationInputData();
        //    onchangeAlive("");
        //    resetWarrant();
        //    onchangeStayWith(id);
        //    enabledWarrant();
        //    showTextWarrant();
        //    //enabledWarrant();

        //});

        //ปุ่ม confirmParent 2019-08-20
        $('.btnConfirmParent').click(function () {
            SetConfirmParent();
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

    // memory of language
    function memoryLanguage() {
        if ($('.lang-active').data('lang') == 'th') {
            thaiAcitive();
        }
        if ($('.lang-active').data('lang') == 'en') {
            engAcitive();
        }
    }


    /// <summary>
    /// Auther : Odd.Nopparat
    /// Date   : 2015-06-20.
    /// Perpose: เตือนข้อมูลไม่ครบ
    /// Method : myDialog.
    /// </summary>
    function myDialog(_message_th, _message_en) {

        if ($('.lang-active').data('lang') == 'th') {
            $('.message').html(_message_th);
        }
        if ($('.lang-active').data('lang') == 'en') {
            $('.message').html(_message_en);
        }
        $(".lblTitle").html("Warning message.");

        $(".lblTitle").removeClass("blue-text");

        if (!$(".lblTitle").hasClass("red-text"))
            $(".lblTitle").addClass("red-text");


        $('#modalMsg').openModal();

    }


    function myDialogMsg(_message_th, _message_en) {

        if ($('.lang-active').data('lang') == 'th') {
            $('.message').html(_message_th);
        }
        if ($('.lang-active').data('lang') == 'en') {
            $('.message').html(_message_en);
        }

        $(".lblTitle").html("Message Box");
        $(".lblTitle").removeClass("red-text");

        if (!$(".lblTitle").hasClass("blue-text")) {
            $(".lblTitle").addClass("blue-text");
        }



        $('#modalMsg').openModal();

    }

    function myDialogConsentMsg(_message_th, _message_en) {

        if ($('.lang-active').data('lang') == 'th') {
            $('.message').html(_message_th);
        }
        if ($('.lang-active').data('lang') == 'en') {
            $('.message').html(_message_en);
        }

        $(".lblTitle").html("Warning Message");
        $(".lblTitle").removeClass("red-text");

        $('#modalConsent').openModal();
    }

    //function checkConsent() {
    //    var _userType = $('#txtUserTypeActive').val();
    //    if (_userType == "STUDENT") {
    //        var _post = "&userType=" + _userType;
    //        $.ajax({
    //            type: "POST",
    //            url: "ContractHandler.ashx",
    //            data: "action=CheckConsent" + _post,
    //            charset: 'tis-620',
    //            beforeSend: function () {

    //            },
    //            error: function (err) {
    //                alert(err);
    //            },
    //            success: function (data) {
    //                //alert(data);
    //                if (data == "false") {
    //                    myDialogConsentMsg("<p style='font-size:20px'>ไม่สามารถดำเนินการได้ เนื่องจากยังไม่ได้ดำเนินการยินยอมให้ใช้ข้อมูลที่ระบบ e-Profile โปรดเข้าสู่ระบบ e-Profile เพื่อดำเนินการยินยอมให้ใช้ข้อมูล</p> <a href='https://smartedu.mahidol.ac.th/Authen/login.aspx'>คลิกที่นี่</a>", "<h3>Unable to perform Because the system has not yet consented to the use of information</h3> <a href='https://smartedu.mahidol.ac.th/Authen/login.aspx'>Click here</a>")
    //                } else {
    //                    $("#submit_frmContract").prop("disabled", false);
    //                }
    //            }
    //        });
    //    }
    //}


    function getParentStatusCondition() {

        var _married = $('input:radio[name=rdoMarried]:checked').val();
        var _fatherSts = $('input:radio[name=rdoFatherSts]:checked').val();
        var _motherSts = $('input:radio[name=rdoMotherSts]:checked').val();
        var _chkStay = $(".chkStay");
        var _stayFather = "0";
        var _stayMother = "0";
        var _stayOther = "0";
        var _contactLost = "0";

        var _arrSts = new Array();
        var _arrStay = new Array();


        if (typeof (_married) == "undefined")
            _married = null;
        if (typeof (_fatherSts) == "undefined")
            _fatherSts = null;
        if (typeof (_motherSts) == "undefined")
            _motherSts = null;



        _arrSts.push({
            married: _married
            , fatherSts: _fatherSts
            , motherSts: _motherSts

        });

        //if (_chkStay[0].checked)
        //    _stayFather = "1";

        //if (_chkStay[1].checked)
        //    _stayMother = "1";

        //if (_chkStay[2].checked)
        //    _stayOther = "1";

        //if (_chkStay[3].checked) {
        //    _contactLost = "1";
        //    //alert("AAAAA");
        //}

        if (_chkStay[0]) {
            _contactLost = "1";
        }

        _arrStay.push({
            father: null
            , mother: null
            , other: null
            , contactLost: _contactLost
        });


        //alert(JSON.stringify(_arrSts));
        //alert(JSON.stringify(_arrStay));

        var _arrData = new Array();
        _arrData.push({
            arrSts: _arrSts
            , arrStay: _arrStay

        });


        return _arrData;

    }


    function showTextWarrant() {

        $(".panelContactLost").hide();
        $(".panelContactTolaw").hide();
        var _arrData = getParentStatusCondition();
        var _arrSts = _arrData[0].arrSts[0];
        var _arrStay = _arrData[0].arrStay[0];
        var _married = _arrSts.married;
        var _fatherSts = _arrSts.fatherSts;
        var _motherSts = _arrSts.motherSts;
        //var _stayFather = _arrStay.father;
        //var _stayMother = _arrStay.mother;
        //var _stayOther = _arrStay.other;

        //Check Alredy Choose Status Father And Mother
        if (_fatherSts == null || _motherSts == null) {
            return
        }
        //if Uncheck All Stay With Then Reset Warrant
        //if (_stayFather == "0" && _stayMother == "0" && _stayOther == "0") {
        //    resetWarrant();
        //    return;
        //}

        //var _warrantBy = "ohter";
        //var _guaranteeBy = "other";

        var _chkStay = $(".chkStay");

        var _warrantBy = "";
        var _guaranteeBy = "";




        var _gVal = "";

        if (_married == "1") {//จดทะเบียน

            if (_fatherSts == "1" && _motherSts == "1") {//พ่อและแม่ มีชีวิต และอาศัยอยู่ด้วยกัน
                /*            if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather == "1" && _stayMother == "1")) {//พ่อและแม่ มีชีวิต และอาศัยอยู่ด้วยกัน*/
                _warrantBy = "mother_father";
                _guaranteeBy = "mother_father";
                _gVal = "F"; //set default เป็น แม่ค้ำ พ่อยินยอม

                $(".panelContactLost").show();
                //} else if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather == "1" && _stayMother != "1")) {//พ่อและแม่ มีชีวิต และอาศัยอยู่กับพ่อ
                //    _warrantBy = "father";
                //    _guaranteeBy = "mother";
                //    _gVal = "M";
                //    $(".panelContactLost").show();
                //} else if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather != "1" && _stayMother == "1")) {//พ่อและแม่ มีชีวิต และอาศัยอยู่กับแม่
                //    _warrantBy = "mother";
                //    _guaranteeBy = "father";
                //    _gVal = "F";
                //    $(".panelContactLost").show();
            } else if (_fatherSts == "1" && _motherSts != "1") {//พ่อมีชีวิต แม่ตาย
                /*            } else if ((_fatherSts == "1" && _motherSts != "1") && (_stayFather == "1")) {//พ่อมีชีวิต แม่ตาย*/
                _warrantBy = "father";
                _guaranteeBy = "";
                _gVal = "F";
                $(".panelContactLost").show();
            } else if (_fatherSts != "1" && _motherSts == "1") {//แม่มีชีวิต พ่อตาย
                /*            } else if ((_fatherSts != "1" && _motherSts == "1") && (_stayMother == "1")) {//แม่มีชีวิต พ่อตาย*/
                _warrantBy = "mother";
                _guaranteeBy = "";
                _gVal = "M";
                $(".panelContactLost").show();
            } else if (_fatherSts != "1" && _motherSts != "1") {
                _warrantBy = "other";
                _guaranteeBy = "ohter";
                _gVal = "N";
                $(".panelContactTolaw").show();
            }
            //} else if (_stayOther == "1") {
            //    _warrantBy = "other";
            //    _guaranteeBy = "ohter";
            //    _gVal = "N";
            //    $(".panelContactTolaw").show();
            //}
            //ไม่ต้องตรวจสอบเงื่อนไข อาศัยอยู่กับ

            //ห้าม check สถานะติดต่อ
            //_chkStay[3].checked = false;


        }

        if (_married == "2") {//ไม่จดทะเบียน
            //alert(_married);
            if (_fatherSts == "1" && _motherSts == "1") {//พ่อและแม่ มีชีวิต และอาศัยอยู่ด้วยกัน
                /*            if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather == "1" && _stayMother == "1")) {//พ่อและแม่ มีชีวิต และอาศัยอยู่ด้วยกัน*/
                //alert("พ่อและแม่ มีชีวิต และอาศัยอยู่ด้วยกัน");
                _warrantBy = "mother";
                _guaranteeBy = "";
                _gVal = "M";
                $(".panelContactLost").show();
                //} else if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather != "1" && _stayMother == "1")) {//พ่อและแม่ มีชีวิต และอาศัยอยู่กับแม่
                //    //alert("พ่อและแม่ มีชีวิต และอาศัยอยู่กับแม่");
                //    _warrantBy = "mother";
                //    _guaranteeBy = "";
                //    _gVal = "M";
                //    $(".panelContactLost").show();
                //} else if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather == "1" && _stayMother != "1")) {//พ่อและแม่ มีชีวิต และอาศัยอยู่กับพ่อ
                //    //alert("พ่อและแม่ มีชีวิต และอาศัยอยู่กับพ่อ");
                //    _warrantBy = "father";
                //    _guaranteeBy = "";
                //    _gVal = "-"; // 2020/12/14 ปรับจากค่าว่างเป็น "-" anussara.wan
                //    $(".panelContactTolaw").show();
            } else if (_fatherSts == "1" && _motherSts != "1") {//พ่อมีชีวิต แม่ตาย
                /*            } else if ((_fatherSts == "1" && _motherSts != "1") && (_stayFather == "1" && _stayMother != "1")) {//พ่อมีชีวิต แม่ตาย และอาศัยอยู่กับพ่อ*/
                //alert("พ่อมีชีวิต แม่ตาย และอาศัยอยู่กับพ่อ");
                //_warrantBy = "father";
                //_guaranteeBy = "";
                //_gVal = "-"; // 2020/12/14 ปรับจากค่าว่างเป็น "-" anussara.wan
                _warrantBy = "other";
                _guaranteeBy = "";
                _gVal = "-"; // 2020/12/14 ปรับจากค่าว่างเป็น "-" anussara.wan
                $(".panelContactTolaw").show();
            } else if (_fatherSts != "1" && _motherSts == "1") {//แม่มีชีวิต พ่อตาย
                /*            } else if ((_fatherSts != "1" && _motherSts == "1") && (_stayFather != "1" && _stayMother == "1")) {//แม่มีชีวิต พ่อตาย และอาศัยอยู่กับแม่*/
                //alert("แม่มีชีวิต พ่อตาย และอาศัยอยู่กับแม่");
                _warrantBy = "mother";
                _guaranteeBy = "";
                _gVal = "M";
                $(".panelContactLost").show();
            } else if (_fatherSts != "1" && _motherSts != "1") { //พ่อและแม่ตาย อาศัยอบู่กับบุคคลอื่น
                //alert("before last");
                _warrantBy = "other";
                _guaranteeBy = "other";
                _gVal = "N";
                $(".panelContactTolaw").show();
            }

        }

        if (_married == "3") {//หย่าร้าง 
            //alert("หย่าร้าง");
            if (_fatherSts == "1" && _motherSts == "1") {//พ่อและแม่ มีชีวิต 
                /*            if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather == "1" && _stayMother == "1")) {//พ่อและแม่ มีชีวิต อาศัยอยู่ด้วยกัน*/

                _warrantBy = "mother_father";
                _guaranteeBy = "mother_father";
                _gVal = "M";
                $(".panelContactLost").show();
                //} else if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather == "1" && _stayMother != "1")) {//พ่อและแม่ มีชีวิต อาศัยอยู่กับพ่อ
                //    _warrantBy = "father";
                //    _guaranteeBy = "";
                //    _gVal = "F";
                //    $(".panelContactLost").show();
                //} else if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather != "1" && _stayMother == "1")) {//พ่อและแม่ มีชีวิต อาศัยอยู่กับแม่
                //    _warrantBy = "mother";
                //    _guaranteeBy = "";
                //    _gVal = "M";
                //    $(".panelContactLost").show();
            } else if (_fatherSts == "1" && _motherSts != "1") {//พ่อมีชีวิต แม่ตาย 
                /*            } else if (_fatherSts == "1" && _motherSts != "1" && (_stayFather == "1" && _stayMother != "1")) {//พ่อมีชีวิต แม่ตาย อาศัยอยู่กับพ่อ*/
                _warrantBy = "father";
                _guaranteeBy = "";
                _gVal = "F";
                $(".panelContactLost").show();
            } else if (_fatherSts != "1" && _motherSts == "1") {//แม่มีชีวิต พ่อตาย 
                /*            } else if ((_fatherSts != "1" && _motherSts == "1") && (_stayFather != "1" && _stayMother == "1")) {//แม่มีชีวิต พ่อตาย อาศัยอยู่กับแม่*/
                _warrantBy = "mother";
                _guaranteeBy = "";
                _gVal = "M";
                $(".panelContactLost").show();
            } else {
                _warrantBy = "other";
                _guaranteeBy = "ohter";
                _gVal = "N";
                $(".panelContactTolaw").show();
            }

        }
        if (_married == "4") {//แยกกันอยู่ 
            //alert("แยกกันอยู่");
            if (_fatherSts == "1" && _motherSts == "1") {//พ่อและแม่ มีชีวิต 
                /*            if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather == "1" && _stayMother == "1")) {//พ่อและแม่ มีชีวิต อาศัยอยู่ด้วยกัน*/
                _warrantBy = "mother_father";
                _guaranteeBy = "mother_father";
                _gVal = "M";
                $(".panelContactLost").show();
                //} else if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather == "1" && _stayMother != "1")) {//พ่อและแม่ มีชีวิต อาศัยอยู่กับพ่อ
                //    _warrantBy = "father";
                //    _guaranteeBy = "mother";
                //    _gVal = "F";
                //    $(".panelContactLost").show();
                //} else if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather != "1" && _stayMother == "1")) {//พ่อและแม่ มีชีวิต อาศัยอยู่กับแม่
                //    _warrantBy = "mother";
                //    _guaranteeBy = "father";
                //    _gVal = "M";
                //    $(".panelContactLost").show();
            } else {
                _warrantBy = "other";
                _guaranteeBy = "ohter";
                _gVal = "N";
                $(".panelContactTolaw").show();
            }



        }
        if (_married == "5") {//หม้าย 
            if (_fatherSts == "1" && _motherSts != "1") {//พ่อมีชีวิต แม่ตาย
                /*            if ((_fatherSts == "1" && _motherSts != "1") && (_stayFather == "1" && _stayMother != "1")) {//พ่อมีชีวิต แม่ตาย และอาศัยอยู่กับพ่อ*/
                _warrantBy = "father";
                _guaranteeBy = "";
                _gVal = "F";
                $(".panelContactLost").show();
            } else if (_fatherSts != "1" && _motherSts == "1") {//แม่มีชีวิต พ่อตาย 
                /*            } else if (_fatherSts != "1" && _motherSts == "1" && (_stayFather != "1" && _stayMother == "1")) {//แม่มีชีวิต พ่อตาย และอาศัยอยู่กับแม่*/
                _warrantBy = "mother";
                _guaranteeBy = "";
                _gVal = "M";
                $(".panelContactLost").show();
            }
            //} else if (_stayFather != "1" && _stayMother != "1") { //อาศัยอยู่กับบุคคลอื่น
            //    _warrantBy = "other";
            //    _guaranteeBy = "ohter";
            //    _gVal = "N";
            //    $(".panelContactTolaw").show();
            //}
        }
        if (_married == "6") {//โสด 
            if (_fatherSts == "1" && _motherSts == "1") {//พ่อและแม่ มีชีวิต อาศัยอยู่ด้วยกัน
                /*            if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather == "1" && _stayMother == "1")) {//พ่อและแม่ มีชีวิต อาศัยอยู่ด้วยกัน*/

                _warrantBy = "mother";
                _guaranteeBy = "";
                _gVal = "M";
                //_warrantBy = "mother_father";
                //_guaranteeBy = "mother_father";
                //_gVal = "M";
                $(".panelContactLost").show();
                //} else if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather == "1" && _stayMother != "1")) {//พ่อและแม่ มีชีวิต อาศัยอยู่กับพ่อ
                //    _warrantBy = "father";
                //    _guaranteeBy = "";
                //    _gVal = "-"; // 2020/12/14 ปรับจากค่าว่างเป็น "-" anussara.wan
                //    $(".panelContactTolaw").show();
                //} else if ((_fatherSts == "1" && _motherSts == "1") && (_stayFather != "1" && _stayMother == "1")) {//พ่อและแม่ มีชีวิต อาศัยอยู่กับแม่
                //    _warrantBy = "mother";
                //    _guaranteeBy = "";
                //    _gVal = "M";
                //    $(".panelContactLost").show();
            } else if (_fatherSts == "1" && _motherSts != "1") {//พ่อมีชีวิต แม่ตาย 
                /*            } else if (_fatherSts == "1" && _motherSts != "1" && (_stayFather == "1" && _stayMother != "1")) {//พ่อมีชีวิต แม่ตาย อาศัยอยู่กับพ่อ*/
                _warrantBy = "father";
                _guaranteeBy = "";
                _gVal = "-"; // 2020/12/14 ปรับจากค่าว่างเป็น "-" anussara.wan
                $(".panelContactTolaw").show();
            } else if (_fatherSts != "1" && _motherSts == "1") {//แม่มีชีวิต พ่อตาย 
                /*            } else if ((_fatherSts != "1" && _motherSts == "1") && (_stayFather != "1" && _stayMother == "1")) {//แม่มีชีวิต พ่อตาย อาศัยอยู่กับแม่*/
                _warrantBy = "mother";
                _guaranteeBy = "";
                _gVal = "M";
                $(".panelContactLost").show();
            } else {
                _warrantBy = "other";
                _guaranteeBy = "ohter";
                _gVal = "N";
                $(".panelContactTolaw").show();
            }
        }

        var beforeCheckedStayLostWarrant = _warrantBy;
        var beforeCheckedStayLostGuarantee = _guaranteeBy;
        var beforeCheckedStayLostGVal = _gVal;

        //Start Event Check/Uncheck ไม่สามารถติดต่อผู้ค้ำประกันได้
        $("#chkStayLost").click(function () {
            if ($(this).is(':checked')) {
                $('chkStayLost').prop('checked', true);
                //alert("checked");
                _warrantBy = "other";
                _guaranteeBy = "ohter";
                _gVal = "N";

                UISPWarrant(_warrantBy);

                var _htmlG = "<p>บุคคลอื่น</p>";
                $('.spConsent').html(_htmlG);

                $('#txtConsentBy').val(_gVal);
                $(".panelContactTolaw").show();
            } else {
                $('chkStayLost').prop('checked', false);
                //alert("unchecked");
                _warrantBy = beforeCheckedStayLostWarrant;
                _guaranteeBy = beforeCheckedStayLostGuarantee;
                _gVal = beforeCheckedStayLostGVal;


                UISPWarrant(_warrantBy);
                var _htmlG = "";
                if (_guaranteeBy == "mother_father") {
                    if (_married == "3") {
                        _htmlG = "<p>มารดา</p>";
                    } else {
                        _htmlG = "<p>บิดา</p>";
                    }
                    // script when select father or mother After Event Click chkStayLost
                    $(".rdoWarrant").click(function () {
                        var _warVal = $(this).val();
                        var _guaTxt = "";
                        var _gVal2 = "";
                        /*                        alert("Click : " + _warVal);*/
                        //Check Status For Father
                        if (_warVal == "F" && (_married == "1" || _married == "2")) {

                            _guaTxt = "<p>มารดา</p>";
                            _gVal2 = "M";

                        } else if (_warVal == "F" && _married != "1" && _married != "2" && _married != "4") {//หย่าร้าง เลือกพ่อเป็นผู้ค้ำ
                            _guaTxt = "<p>บิดา</p>";
                            _gVal2 = "F";
                        } else if (_warVal == "F" && _married == "4") {//แยกกันอยู่ เลือกพ่อเป็นคนค้ำ
                            _guaTxt = "<p>มารดา</p>";
                            _gVal2 = "M";
                        }

                        //Check Status For Mother
                        if (_warVal == "M" && (_married == "1" || _married == "2")) {

                            _guaTxt = "<p>บิดา</p>";
                            _gVal2 = "F";
                        } else if (_warVal == "M" && _married != "1" && _married != "2" && _married != "4") {//หย่าร้าง เลือกแม่เป็นผู้ค้ำ
                            _guaTxt = "<p>มารดา</p>";
                            _gVal2 = "M";
                        } else if (_warVal == "M" && _married == "4") {//แยกกันอยู่ เลือกแม่เป็นคนค้ำ
                            _guaTxt = "<p>บิดา</p>";
                            _gVal2 = "F";
                        }
                        $('.spConsent').html(_guaTxt);

                        $('#txtConsentBy').val(_gVal2);

                    });
                } else if (_guaranteeBy == "mother") {
                    _htmlG = "<p>มารดา</p>";
                } else if (_guaranteeBy == "father") {
                    _htmlG = "<p>บิดา</p>";
                } else if (_guaranteeBy == "other") {
                    _htmlG = "<p>บุคคลอื่น</p>";
                } else {
                    _htmlG = "<p>-</p>";
                }

                $('.spConsent').html(_htmlG);
                $('#txtConsentBy').val(_gVal);
                $(".panelContactTolaw").hide();
            }
        });
        //End Event Check/Uncheck ไม่สามารถติดต่อผู้ค้ำประกันได้

        UISPWarrant(_warrantBy);

        var _htmlG = "";
        if (_guaranteeBy == "mother_father") {
            if (_married == "3") {
                _htmlG = "<p>มารดา</p>";
            } else {
                _htmlG = "<p>บิดา</p>";
            }

            // script when select father or mother Never Click chkStayLost
            $(".rdoWarrant").click(function () {
                var _warVal = $(this).val();
                var _guaTxt = "";
                var _gVal2 = "";
                /*                alert("Not Click : " + _warVal);*/

                //Check Status For Father
                if (_warVal == "F" && (_married == "1" || _married == "2")) {

                    _guaTxt = "<p>มารดา</p>";
                    _gVal2 = "M";

                } else if (_warVal == "F" && _married != "1" && _married != "2" && _married != "4") {//หย่าร้าง เลือกพ่อเป็นผู้ค้ำ
                    _guaTxt = "<p>บิดา</p>";
                    _gVal2 = "F";
                } else if (_warVal == "F" && _married == "4") {//แยกกันอยู่ เลือกพ่อเป็นคนค้ำ
                    _guaTxt = "<p>มารดา</p>";
                    _gVal2 = "M";
                }

                //Check Status For Mother
                if (_warVal == "M" && (_married == "1" || _married == "2")) {

                    _guaTxt = "<p>บิดา</p>";
                    _gVal2 = "F";
                } else if (_warVal == "M" && _married != "1" && _married != "2" && _married != "4") {//หย่าร้าง เลือกแม่เป็นผู้ค้ำ
                    _guaTxt = "<p>มารดา</p>";
                    _gVal2 = "M";
                } else if (_warVal == "M" && _married == "4") {//แยกกันอยู่ เลือกแม่เป็นคนค้ำ
                    _guaTxt = "<p>บิดา</p>";
                    _gVal2 = "F";
                }
                $('.spConsent').html(_guaTxt);

                $('#txtConsentBy').val(_gVal2);

            });
        } else if (_guaranteeBy == "mother") {
            _htmlG = "<p>มารดา</p>";
        } else if (_guaranteeBy == "father") {
            _htmlG = "<p>บิดา</p>";
        } else if (_guaranteeBy == "other") {
            _htmlG = "<p>บุคคลอื่น</p>";
        } else {
            _htmlG = "<p>-</p>";
        }

        $('.spConsent').html(_htmlG);
        $('#txtConsentBy').val(_gVal);

    }

    function uiPreviewStudentContract(_this) {

        //After Click btnConfirmInfo
        var _userType = $('#txtUserTypeActive').val();
        var warrantyBy = $('input:radio[name=rdoWarrant]:checked').val();
        var consentBy = $('#txtConsentBy').val();
        var _arrData = getParentStatusCondition();

        var _arrSts = _arrData[0].arrSts[0];
        /*        var _arrStay = _arrData[0].arrStay[0];*/
        var _errTh = "", _errEn = "";


        if (_arrSts.married == null || _arrSts.fatherSts == null || _arrSts.motherSts == null) {
            _errTh += "- กรุณาเลือกสถานะ บิดา/มารดา ให้ครบถ้วน<br><br>";
            _errEn += "- Please specify status info<br><br>";

        }


        //if (_arrStay.father == "0" && _arrStay.mother == "0" && _arrStay.other == "0") {
        //    _errTh += "- กรุณาเลือกข้อมูล อาศัยอยู่กับ<br><br>";
        //    _errEn += "- Please specify stay with<br><br>";
        //}

        // alert(_errEn);
        if (_errTh != "") {
            myDialog(_errTh, _errEn);
            return false;
        }

        //Gus Edited
        //if (_arrStay.contactLost == "1") {

        //    myDialog("นักศึกษาเลือก ไม่สามารติดต่อผู้ค้ำประกันตามเงื่อนไขได้<BR>- กรุณาติดต่อทำสัญญาที่กองกฏหมาย เพื่อให้ผู้อื่นค้ำประกัน", "Lost Contact");
        //}



        var _post = "&userType=" + _userType + "&warranty=" + warrantyBy + "&consent=" + consentBy;
        //alert(_post);
        $.ajax({
            type: "POST",
            url: "ContractHandler.ashx",
            data: "action=UiPreviewContrat" + _post,
            charset: 'tis-620',
            beforeSend: function () {
                _this.hide();
                //myDialog("กำลังดำเนินการ กรุณารอสักครู่...", "System Processing. Please Wait...");
            },
            error: function (err) {
                //alert(err);
                _btnLogin.show();
            },
            success: function (data) {
                //$('#modalMsg').Modal("hide");
                _this.show();
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

                //$('#submit_confirmRequest').click(function () {
                //    $('form#form1').attr('action', 'confirmRequest.aspx');
                //    $('form#form1').submit();
                //});

            }
        });


    }




    /// <summary>
    /// Auther : Odd.Nopparat
    /// Date   : 2015-11-20.
    /// Perpose: re login
    /// Method :
    /// </summary>

    function signLoginContract(_this) {
        // student login..
        //var _no = _this.data("options").no;
        //alert(_no);
        var _btnLogin = _this;
        var _userType = $('#txtUserTypeActive').val();
        var _username = $.trim($('#username').val());
        var _password = $.trim($('#password').val());
        var _arrData = new Array();
        var _arrInput = new Array();

        _arrData.push({
            username: _username
            , password: _password
            , userType: _userType
        });

        if (_userType == "STUDENT") {
            // get data form student contract
            var _arrInfo = getParentStatusCondition();
            //console.log(_arrInfo);
            var _arrSts = _arrInfo[0].arrSts[0];
            var _arrStay = _arrInfo[0].arrStay[0];
            var _warrantBy = $('input:radio[name=rdoWarrant]:checked').val();
            var _consentBy = $('#txtConsentBy').val();
            if (_warrantBy == null || _consentBy == null) {
                myDialog('ระบบไม่พบข้อมูลผู้ค้ำประกัน/ยินยอม<br>- กรุณาเลือกเงื่อนไขสถานะผู้ปกครองอีกครั้ง', 'Data Incorrect!!!<BR>Please Specify Status Again.');
                return false
            }
            _arrInput.push({
                warrantBy: _warrantBy
                , consentBy: _consentBy
                , marriage: _arrSts.married
                , aliveM: _arrSts.motherSts
                , aliveF: _arrSts.fatherSts
                //, liveWithM: _arrStay.mother
                //, liveWithF: _arrStay.father
                //, liveWithOther: _arrStay.other
                , liveWithM: null
                , liveWithF: null
                , liveWithOther: null
                , contactFm: _arrStay.contactLost //ไม่สามารติดต่อผู้ค้ำประกันตามเงื่อนไขได้
            });

        } else {
            // form parent not use this data
            _arrInput.push({
                warrantBy: null
                , consentBy: null
                , marriage: null
                , aliveM: null
                , aliveF: null
                , liveWithM: null
                , liveWithF: null
                , liveWithOther: null
                , contactFm: null
            });

        }



        if (_username === '' || (_password === '' && _userType == "PARENT")) {
            if (_userType == "PARENT") {
                myDialog('กรุณารหัสผู้ใช้ และรหัสผ่าน ให้ถูกต้อง', 'Please specify username and password');
            } else if (_userType == "STUDENT") {
                myDialog('กรุณาระบุรหัสนักศึกษา และรหัสผ่าน ให้ถูกต้อง', 'Please specify student ID and password');
            } else {
                myDialog('รูปแบบข้อมูลไม่ถูกต้อง!!! กรุณา log in ใหม่', 'Data Incorrect!!! Please log in');
            }
            return false;
        }
        else {
            //$('#form1').submit();
            var _post = "&strSign=" + JSON.stringify(_arrData) + "&strInput=" + JSON.stringify(_arrInput);
            //console.log(_post);
            //alert(_post);
            $.ajax({
                type: "POST",
                url: "ContractHandler.ashx",
                data: "action=SignLogin" + _post,
                charset: 'tis-620',
                beforeSend: function () {
                    _btnLogin.hide();
                    //myDialog("กำลังดำเนินการบันทึกสัญญา กรุณารอสักครู่", "System Processing. Please Wait.");
                },
                error: function (err) {
                    alert(err);
                    _btnLogin.show();
                },
                success: function (data) {
                    //console.log(data);
                    _btnLogin.show();
                    //$('.modal').closeModal();
                    $("#divResult").html(data);
                    //$("#divResult").show();
                    //$('#submit_confirmRequest').show();
                    var _txtProcess = $("#divResult .txtProcessStatus");
                    var _msgTh = "";
                    var _msgEn = "";
                    var _processStatus = "0";


                    if (typeof (_txtProcess) != "undefined") {
                        _processStatus = _txtProcess.val();
                        _msgEn = _txtProcess.data("msg_en");
                        _msgTh = _txtProcess.data("msg_th");
                        if (_processStatus == "1") {
                            $("#divContractView").html("");
                            $("#divComplete").html(data);
                            $("#divComplete").show();
                            $('#submit_confirmRequest').click(function () {
                                $('form#form1').attr('action', 'confirmRequest.aspx');
                                $('form#form1').submit();
                            });
                        }

                    } else {
                        _msgEn = "Transaction Error!!! Please Press F5 to Reprocees";
                        _msgTh = "การสื่อสารขัดข้อง!!! กรุณากดปุ่ม F5 เพื่อประมวลผลใหม่";


                    }

                    if (_processStatus == "0") {
                        myDialog(_msgTh, _msgEn);
                    }

                    //alert("res=" + _processStatus);
                    //alert(data);


                }
            });

        }



    }



    function menuStd() {
        $("#divParentStatus").hide();
        $("#divComplete").hide();
        $('#submit_frmContract').click(function () {
            //Hide Menu Student
            $('#divMenuStd').html("");
            if ($('#hidStatusViewComplete').val() == "1") {
                $("#divComplete").show();
                $('button#submit_confirmRequest').click(function () {
                    $('form#form1').attr('action', 'confirmRequest.aspx');
                    $('form#form1').submit();
                });
            } else {
                $("#divParentStatus").show();
            }
        });

        $('#submit_confirmRequest').click(function () {
            $('form#form1').attr('action', 'confirmRequest.aspx');
            $('form#form1').submit();
        });

    }

    /// <summary>
    /// Auther : anussara.wan
    /// Date   : 2019-08-20
    /// Perpose: สำหรับส่งค่าหน้า confirm Parent ไปบันทึกยังตาราง ectParentAndStaff
    /// Method : confirmParent
    /// </summary>
    function SetConfirmParent() {

        var _errTh1 = "", _errEn1 = "";
        var _userType = $('#txtUserTypeActive').val();
        var _post = "&userType=" + _userType;
        if ($('#chkConP').is(':checked')) {
            $.ajax({
                type: "POST",
                url: "ContractHandler.ashx",
                data: "action=SetConfirmParent" + _post,
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

        } else {
            _errTh1 += "- กรุณาทำเครื่องหมายถูกหน้าข้อความดังกล่าว<br><br>";
            _errEn1 += "- Please Checkbox status info<br><br>";
            if (_errTh1 != "") {
                myDialog(_errTh1, _errEn1);
                return false;
            }
        }
    }

    function disabledStayWith() {
        //Start Disable checkStay with Onload event
        $("#chkStayF").attr("disabled", true);
        $("#chkStayM").attr("disabled", true);
        $("#chkStayO").attr("disabled", true);
        //End Disable checkStay with Onload event
    }

    function enabledStayWith() {
        //Start Enabled checkStay with onchangeRdoMarried event
        $("#chkStayF").attr("disabled", false);
        $("#chkStayM").attr("disabled", false);
        $("#chkStayO").attr("disabled", false);
        //End Enabled checkStay with onchangeRdoMarried event
    }

    function disabledAlive() {
        //Start Disable Alive with Onload event
        $(".rdoFatherSts").attr("disabled", true);
        $(".rdoMotherSts").attr("disabled", true);
        //End Disable Alive with Onload event
    }

    function enabledAlive() {
        //Start Disable Alive with Onload event
        var rdoMarried = $('input:radio[name=rdoMarried]:checked').val();
        if (rdoMarried == "1") { //จดทะเบียน
            $("#rdoFatherStsNo").attr("disabled", true);
            $("#rdoMotherStsNo").attr("disabled", true);
            $("#rdoFatherStsYes").attr("disabled", false);
            $("#rdoMotherStsYes").attr("disabled", false);
        } else if (rdoMarried == "4") { //แยกกันอยู่
            $("#rdoFatherStsNo").attr("disabled", true);
            $("#rdoMotherStsNo").attr("disabled", true);
            $("#rdoFatherStsYes").attr("disabled", false);
            $("#rdoMotherStsYes").attr("disabled", false);
        } else { //ohter type
            $(".rdoFatherSts").attr("disabled", false);
            $(".rdoMotherSts").attr("disabled", false);
        }
        //End Disable Alive with Onload event
    }

    function disabledWarrant() {
        //Start Disable checkStay with Onload event
        $("#rdoWF").attr("disabled", true);
        $("#rdoWM").attr("disabled", true);
        $("#rdoWO").attr("disabled", true);
        //End Disable checkStay with Onload event
    }

    function enabledWarrant() {
        //Start Enabled checkStay with onchangeRdoMarried event
        $("#rdoWF").attr("disabled", false);
        $("#rdoWM").attr("disabled", false);
        $("#rdoWO").attr("disabled", false);
        //End Enabled checkStay with onchangeRdoMarried event
    }

    function resetAlive() {
        $(".rdoFatherSts").prop('checked', false);
        $(".rdoMotherSts").prop('checked', false);
    }

    function resetStayWith() {
        //Start reset checkStay with onchangeRdoMarried event
        $("#chkStayF").prop('checked', false);
        $("#chkStayM").prop('checked', false);
        $("#chkStayO").prop('checked', false);
        $("#chkStayF").prop('disabled', false);
        $("#chkStayM").prop('disabled', false);
        $("#chkStayO").prop('disabled', false);
        //Start reset checkStay with onchangeRdoMarried event
    }

    function initialWarrant() {
        var htmlForpPanelContactLost = "<span class='title'><span class='th red-text'>สถานะติดต่อ :&nbsp;" +
            "<input class='chkStay' name='chkStay' type='checkbox' id='chkStayLost' value='1' />" +
            "<label for='chkStayLost'>" +
            "<span class='th red-text'>ไม่สามารถติดต่อ ผู้ค้ำประกันได้</span><span class='en hide red-text'>Family not found</span>" +
            "</label>" +
            "</span>";
        $(".panelContactLost").html(htmlForpPanelContactLost);
        $(".spWarrant").html("");
        $(".panelContactLost").hide();
        $(".panelContactTolaw").hide();
    }

    function resetWarrant() {
        //Start reset Warrant with onchangeRdoMarried 
        var htmlForpPanelContactLost = "<span class='title'><span class='th red-text'>สถานะติดต่อ :&nbsp;" +
            "<input class='chkStay' name='chkStay' type='checkbox' id='chkStayLost' value='1' />" +
            "<label for='chkStayLost'>" +
            "<span class='th red-text'>ไม่สามารถติดต่อ ผู้ค้ำประกันได้</span><span class='en hide red-text'>Family not found</span>" +
            "</label>" +
            "</span>";
        $('.panelContactLost').html(htmlForpPanelContactLost);
        $('.spWarrant').html("");
        $('.spConsent').html("");
        $(".panelContactLost").hide();
        $(".panelContactTolaw").hide();
        //Start reset Warrant with onchangeRdoMarried event
    }

    function onchangeAlive(id) {
        var rdoMarried = $('input:radio[name=rdoMarried]:checked').val();
        var dadAlive = $('input:radio[name=rdoFatherSts]:checked').val();
        var momAlive = $('input:radio[name=rdoMotherSts]:checked').val();
        if (rdoMarried == "5") { //หม้าย
            if (id == "rdoFatherStsYes") {
                if ($("#rdoFatherStsYes").is(':checked')) {
                    //Dad Alive Checked
                    $('#rdoMotherStsYes').prop('checked', false);
                    $('#rdoMotherStsYes').prop('disabled', true);

                    $('#rdoMotherStsNo').prop('checked', true);
                    $('#rdoMotherStsNo').prop('disabled', false);

                    //Can Stay with Dad
                    /*                    $("#chkStayF").attr("disabled", false);*/

                    //Can't Stay with Mom
                    //$("#chkStayM").prop('checked', false);
                    //$("#chkStayM").attr("disabled", true);
                }
            } else if (id == "rdoFatherStsNo") {
                if ($("#rdoFatherStsNo").is(':checked')) {
                    //Dad Died Checked
                    $('#rdoMotherStsYes').prop('checked', true);
                    $('#rdoMotherStsYes').prop('disabled', false);

                    $('#rdoMotherStsNo').prop('disabled', true);
                    $('#rdoMotherStsNo').prop('checked', false);

                    //Can't Stay with Dad
                    //$("#chkStayF").prop('checked', false);
                    //$("#chkStayF").attr("disabled", true);

                    //Can Stay With Mom
                    /*                    $("#chkStayM").attr("disabled", false);*/
                }
            }
            if (id == "rdoMotherStsYes") {
                if ($("#rdoMotherStsYes").is(':checked')) {
                    //Dad Alive Checked
                    $('#rdoFatherStsYes').prop('checked', false);
                    $('#rdoFatherStsYes').prop('disabled', true);

                    $('#rdoFatherStsNo').prop('checked', true);
                    $('#rdoFatherStsNo').prop('disabled', false);

                    //Can Stay with Mom
                    /*                    $("#chkStayM").attr("disabled", false);*/

                    //Can't Stay with Dad
                    //$("#chkStayF").prop('checked', false);
                    //$("#chkStayF").attr("disabled", true);
                }
            } else if (id == "rdoMotherStsNo") {
                if ($("#rdoFatherStsNo").is(':checked')) {
                    //Dad Died Checked
                    $('#rdoFatherStsYes').prop('checked', true);
                    $('#rdoFatherStsYes').prop('disabled', false);

                    $('#rdoFatherStsNo').prop('disabled', true);
                    $('#rdoFatherStsNo').prop('checked', false);

                    //Can't Stay with Mom
                    //$("#chkStayM").prop('checked', false);
                    //$("#chkStayM").attr("disabled", true);

                    //Can Stay with Dad
                    /*                    $("#chkStayF").attr("disabled", false);*/
                }
            }
        }
        //} else {
        //    if (dadAlive == "2") { //Dad Died
        //        $("#chkStayF").prop('checked', false);
        //        $("#chkStayF").attr("disabled", true);

        //    } else if (dadAlive == "1") { //Dad Alive
        //        $("#chkStayF").attr("disabled", false);
        //    }
        //    if (momAlive == "2") { //Mom Died
        //        $("#chkStayM").prop('checked', false);
        //        $("#chkStayM").attr("disabled", true);
        //    } else if (momAlive == "1") { //Mom Alive
        //        $("#chkStayM").attr("disabled", false);
        //    }
        //}
    }

    function onchangeStayWith(id) {
        var rdoMarried = $('input:radio[name=rdoMarried]:checked').val();
        var dadAlive = $('input:radio[name=rdoFatherSts]:checked').val();
        var momAlive = $('input:radio[name=rdoMotherSts]:checked').val();
        if (rdoMarried == "4" || rdoMarried == "3") { //หย่าร้างและแยกกันอยู่
            if (id == "chkStayF") {
                if ($("#chkStayF").is(':checked')) {
                    $('#chkStayM').prop('checked', false);
                    $('#chkStayM').prop('disabled', true);
                    $('#chkStayO').prop('checked', false);
                    $('#chkStayO').prop('disabled', true);
                } else {
                    if (dadAlive == "1") { //Dad Alive
                        $('#chkStayF').prop('disabled', false);
                    } else if (momAlive == "1") { //Mom Alive
                        $('#chkStayM').prop('disabled', false);
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
                } else {
                    if (dadAlive == "1") { //Dad Alive
                        $('#chkStayF').prop('disabled', false);
                    } else if (momAlive == "1") { //Mom Alive
                        $('#chkStayM').prop('disabled', false);
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
                } else {
                    if (dadAlive == "1") { //Dad Alive
                        $('#chkStayF').prop('disabled', false);
                    } else if (momAlive == "1") { //Mom Alive
                        $('#chkStayM').prop('disabled', false);
                    }
                }
            }
        }
        if (rdoMarried == "5") {//หม้าย
            if (id == "chkStayO") {
                if ($("#chkStayO").is(':checked')) {
                    //Checked Stay with Other
                    $('#chkStayF').prop('checked', false);
                    $('#chkStayF').prop('disabled', true);
                    $('#chkStayM').prop('checked', false);
                    $('#chkStayM').prop('disabled', true);
                } else {
                    //Uncheck Stay with Other
                    if (dadAlive == "1") { //Dad Alive
                        $('#chkStayF').prop('disabled', false);
                    } else { //Mom Alive
                        $('#chkStayM').prop('disabled', false);
                    }
                }

            }

        }
        if (rdoMarried == "6") { //โสด
            if (id == "chkStayF") {
                if ($("#chkStayF").is(':checked')) {
                    $('#chkStayM').prop('checked', false);
                    $('#chkStayM').prop('disabled', true);
                    $('#chkStayO').prop('checked', false);
                    $('#chkStayO').prop('disabled', true);
                } else {
                    if (momAlive == "1") { //mom Alive
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
                } else {
                    if (dadAlive == "1") { //Dad Alive
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
                } else {
                    if (dadAlive == "1") { //Dad Alive
                        $('#chkStayF').prop('disabled', false);
                        $('#chkStayF').prop('checked', false);
                    } else if (momAlive == "1") { //Mom Alive
                        $('#chkStayM').prop('disabled', false);
                        $('#chkStayM').prop('checked', false);
                    }
                }
            }
        }
    }

    function UISPWarrant(_warrantBy) {
        var _htmlW = "";
        var _stsF = "";
        var _stsM = "";
        var _stsO = "";
        var _styF = "";
        var _styM = "";
        var _styO = "";


        //Change style By Select
        if (_warrantBy == "mother_father") {
            _stsO = " disabled ";
            _stsM = " checked ";
            _styO = " style='text-decoration: line-through;' "


        } else if (_warrantBy == "mother") {
            _stsF = " disabled '";
            _stsM = " checked ";
            _stsO = " disabled ";
            _styF = " style='text-decoration: line-through;' "
            _styO = " style='text-decoration: line-through;' "


        } else if (_warrantBy == "father") {
            _stsF = " checked ";
            _stsM = " disabled ";
            _stsO = " disabled ";
            _styM = " style='text-decoration: line-through;' "
            _styO = " style='text-decoration: line-through;' "


        } else if (_warrantBy == "other") {
            _stsF = " disabled ";
            _stsM = " disabled ";
            _stsO = " checked ";
            _styF = " style='text-decoration: line-through;' "
            _styM = " style='text-decoration: line-through;' "
        }




        _htmlW = "<p>" +
            "<input class='rdoWarrant' name='rdoWarrant' type='radio' id='rdoWF' value='F' " + _stsF + " />" +
            "<label for='rdoWF'>" +
            "<span class='th' " + _styF + ">บิดา</span><span class='en hide'>Father</span>" +
            "</label>&nbsp;&nbsp;" +
            "<input class='rdoWarrant' name='rdoWarrant' type='radio' id='rdoWM' value='M' " + _stsM + " />" +
            "<label for='rdoWM'>" +
            "<span class='th' " + _styM + ">มารดา</span><span class='en hide'>Mother</span>" +
            "</label>" +
            "<input class='rdoWarrant' name='rdoWarrant' type='radio' id='rdoWO' value='N' " + _stsO + " />" +
            "<label for='rdoWO'>" +
            "<span class='th' " + _styO + ">บุคคลอื่น</span><span class='en hide'>Other</span>" +
            "</label>&nbsp;&nbsp;" +
            "</p>";

        $('.spWarrant').html(_htmlW);
    }

    function onclickRdoWarrant(text) {

        $(".rdoWarrant").click(function () {
            //alert(text);
            var _warVal = $(this).val();
            var _guaTxt = "";
            var _gVal2 = "";
            //alert(_warVal);
            if (_warVal == "F" && (_married == "1" || _married == "2")) {

                _guaTxt = "<p>มารดา</p>";
                _gVal2 = "M";

            } else if (_warVal == "F" && _married != "1" && _married != "2") {//หย่าร้าง เลือกพ่อเป็นผู้ค้ำ

                _guaTxt = "<p>บิดา</p>";
                _gVal2 = "F";

            }

            if (_warVal == "M" && (_married == "1" || _married == "2")) {

                _guaTxt = "<p>บิดา</p>";
                _gVal2 = "F";
            } else if (_warVal == "M" && _married != "1" && _married != "2") {//หย่าร้าง เลือกแม่เป็นผู้ค้ำ

                _guaTxt = "<p>มารดา</p>";
                _gVal2 = "M";
            }
            $('.spConsent').html(_guaTxt);

            $('#txtConsentBy').val(_gVal2);

        });
    }


</script>
