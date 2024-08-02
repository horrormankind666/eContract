<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="faqContract.aspx.cs" Inherits="eContract.faqContract" %>

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
    <meta name="theme-color" content="#EE6E73" />
<style type="text/css">
/*@import url(https://fonts.googleapis.com/css?family=Roboto:400,400italic,600,600italic,700,700italic);
body {
		font-family: 'Roboto';
		background-color: #f9f9f9;
}

.container{
	height:500px;
	width:580px;
	padding:0;
	margin:10px;
	border-radius:5px;
	box-shadow: 0 2px 3px rgba(0,0,0,.3)
	
}

header {
		position: relative;
}*/

.hide {
		display: none;
}

.tab-content {
		padding:25px;
}

#material-tabs {
		position: relative;
		display: block;
	  padding:0;
		border-bottom: 1px solid #e0e0e0;
}

#material-tabs>a {
		position: relative;
	 display:inline-block;
		text-decoration: none;
		padding: 22px;
		text-transform: uppercase;
		font-size: 14px;
		font-weight: 600;
		color: #424f5a;
		text-align: center;
		outline:;
}

#material-tabs>a.active {
		font-weight: 700;
		outline:none;
}

#material-tabs>a:not(.active):hover {
		background-color: inherit;
		color: #7c848a;
}

@media only screen and (max-width: 520px) {
		.nav-tabs#material-tabs>li>a {
				font-size: 11px;
		}
}

.yellow-bar {
		position: absolute;
		z-index: 10;
		bottom: 0;
		height: 3px;
		background: #458CFF;
		display: block;
		left: 0;
		transition: left .2s ease;
		-webkit-transition: left .2s ease;
}

#tab1-tab.active ~ span.yellow-bar {
		left: 0;
		width: 160px;
}

#tab2-tab.active ~ span.yellow-bar {
		left:165px;
		width: 82px;
}

#tab3-tab.active ~ span.yellow-bar {
		left: 253px;
		width: 135px;
}

#tab4-tab.active ~ span.yellow-bar {
		left:392px;
		width: 163px;
}
</style>
</head>
<body class="" style="background-color: #F2F0EF">
     <!-- navigater bar -->
    <nav id="navBar" runat="server" style="background-color: #253988" role='navigation'></nav>
    <!-- parallax banner -->
    <div id="divBanner" runat="server">
    </div>
    <!-- body panel -->
    <!--container -->
    <div class="container">
		<header>
				<div id="material-tabs">
						<a id="tab1-tab" href="#tab1" class="active">เงื่อนไขการทำสัญญาในระบบ</a>
                        <a id="tab5-tab" href="#tab5">เงื่อนไขการทำสัญญานอกระบบ</a>
						<a id="tab2-tab" href="#tab2" onclick="openFAQ1();">สัญญาการเป็นนักศึกษา</a>
						<a id="tab3-tab" href="#tab3" onclick="openFAQ2();">สัญญาค้ำประกัน และหนังสือแสดงความยินยอม</a>
						<a id="tab4-tab" href="#tab4" onclick="openFAQ3();">ตรวจสอบ แก้ไขเพิ่มเติม ดาวน์โหลดสัญญา</a>
						<span class="yellow-bar"></span>
				</div>
		</header>

		<div class="tab-content">
				<div id="tab1">
                    <table class="table">
                        <caption style="font-size:12pt;font-family: courier;font-weight:bold;color:black">กรณีการค้ำประกันโดยบิดาโดยชอบด้วยกฎหมาย หรือมารดาโดยชอบด้วยกฎหมาย</caption>
                        <thead>
                            <tr>
                                <th scope="col" rowspan="2" style="background-color:darkseagreen;text-align:center;vertical-align:top">สถานภาพสมรส</th>
                                <th scope="col" rowspan="2" style="background-color:pink;text-align:center">เลือกผู้ค้ำประกัน</th>
                                <th scope="col" colspan="2" style="background-color:violet;text-align:center">รหัสผ่าน</th>
                                <th scope="col" colspan="2" style="background-color:pink;text-align:center">สัญญาค้ำประกัน</th>
                                <th scope="col" colspan="2" style="background-color:skyblue;text-align:center">หนังสือแสดงความยินยอม</th>
                                <th scope="col" rowspan="2" style="background-color:lightgray;text-align:center;vertical-align:top">หมายเหตุท้ายสัญญาค้ำประกัน</br>และหนังสือแสดงความยินยอม</th>
                            </tr>
                            <tr>
                                <th scope="col" style="background-color:violet;text-align:center">บิดา</th>
                                <th scope="col" style="background-color:violet;text-align:center">มารดา</th>
                                <th scope="col" style="background-color:pink;text-align:center">ผู้ค้ำประกัน</th>
                                <th scope="col" style="background-color:pink;text-align:center">ยินยอมโดย</th>
                                <th scope="col" style="background-color:skyblue;text-align:center">บิดา</th>
                                <th scope="col" style="background-color:skyblue;text-align:center">มารดา</th>
                            </tr>
                        </thead>
                        <tbody>
                            <!--สมรส-->
                            <tr>
                                <td rowspan="2" style="background-color:darkseagreen;text-align: left;vertical-align:top">1. สมรส<br/>(จดทะเบียน)</td>
                                <td style="background-color:pink;text-align: left">1.1 บิดา</td>
                                <td style="background-color:violet;text-align: center">&#10003;</td>
                                <td style="background-color:violet;text-align: center">&#10003;</td>
                                <td style="background-color:pink;text-align: center">บิดา</td>
                                <td style="background-color:pink;text-align: center">มารดา</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="text-align: center">-</td>
                            </tr>
                         <tr style="border-bottom:inset">
                                <td style="background-color:pink;text-align: left">1.2 มารดา</td>
                                <td style="background-color:violet;text-align: center">&#10003;</td>
                                <td style="background-color:violet;text-align: center">&#10003;</td>
                                <td style="background-color:pink;text-align: center">มารดา</td>
                                <td style="background-color:pink;text-align: center">บิดา</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="text-align: center">-</td>
                            </tr>           
                         <tr style="border-bottom:inset">
                                <td rowspan="1" style="background-color:darkseagreen;text-align:left;vertical-align:top">2. สมรส<br/>(ไม่จดทะเบียนสมรสแต่อยู่ด้วยกัน)</td>
                                <td style="background-color:pink;text-align: left">มารดา</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:violet;text-align: center">&#10003;</td>
                                <td style="background-color:pink;text-align: center">มารดา</td>
                                <td style="background-color:pink;text-align: center">&#x2718;</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="text-align: center">บิดาและมารดา<br/>มิได้จดทะเบียนสมรส</td>
                            </tr>
                            <!--จบสมรส (ไม่จดทะเบียน)-->
                            <!--หย่าร้าง-->
                              <tr>
                                <td rowspan="2" style="background-color:darkseagreen;text-align:left;vertical-align:top">3. หย่าร้าง<br/>(จดทะเบียนหย่า)</td>
                                <td style="background-color:pink;text-align: left">3.1 บิดา</td>
                                <td style="background-color:violet;text-align: center">&#10003;</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:pink;text-align: center">บิดา</td>
                                <td style="background-color:pink;text-align: center">&#x2718;</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                                <td style="text-align: center">บิดาและมารดา<br/>จดทะเบียนหย่า</td>
                            </tr>
                         <tr style="border-bottom:inset">
                                <td style="background-color:pink;text-align: left">3.2 มารดา</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:violet;text-align: center">&#10003;</td>
                                <td style="background-color:pink;text-align: center">มารดา</td>
                                <td style="background-color:pink;text-align: center">&#x2718;</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="text-align: center">บิดาและมารดา<br/>จดทะเบียนหย่า</td>
                            </tr>                           
                            <!--จบหย่าร้าง-->
                            <!--แยกกันอยู่-->
                              <tr>
                                <td rowspan="2" style="background-color:darkseagreen;text-align:left;vertical-align:top">4. แยกกันอยู่<br/>(จดทะเบียนสมรส<br/>แต่แยกกันอยู่)</td>
                                <td style="background-color:pink;text-align: left">4.1 บิดา</td>
                                <td style="background-color:violet;text-align: center">&#10003;</td>
                                <td style="background-color:violet;text-align: center">&#10003;</td>
                                <td style="background-color:pink;text-align: center">บิดา</td>
                                <td style="background-color:pink;text-align: center">มารดา</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="text-align: center">บิดาและมารดา<br/>จดทะเบียนสมรส<br/>แต่แยกกันอยู่</td>
                            </tr>
                         <tr style="border-bottom:inset">
                                <td style="background-color:pink;text-align: left">4.2 มารดา</td>
                                <td style="background-color:violet;text-align: center">&#10003;</td>
                                <td style="background-color:violet;text-align: center">&#10003;</td>
                                <td style="background-color:pink;text-align: center">มารดา</td>
                                <td style="background-color:pink;text-align: center">บิดา</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="text-align: center">บิดาและมารดา<br/>จดทะเบียนสมรส<br/>แต่แยกกันอยู่</td>

                            </tr>
                            <!--จบแยกกันอยู่-->
                            <!--หม้าย-->
                              <tr>
                                <td rowspan="2" style="background-color:darkseagreen;text-align:left;vertical-align:top">5. หม้าย<br/>(จดทะเบียนสมรส<br/>แต่ฝ่ายใดฝ่ายหนึ่ง<br/>เสียชีวิต)</td>
                                <td style="background-color:pink;text-align: left">5.1 บิดา</td>
                                <td style="background-color:violet;text-align: center">&#10003;</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:pink;text-align: center">บิดา</td>
                                <td style="background-color:pink;text-align: center">&#x2718;</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                                <td style="text-align: center">มารดาเสียชีวิต</td>
                            </tr>
                            <tr style="border-bottom:inset">
                                <td style="background-color:pink;text-align: left">5.2 มารดา</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:violet;text-align: center">&#10003;</td>
                                <td style="background-color:pink;text-align: center">มารดา</td>
                                <td style="background-color:pink;text-align: center">&#x2718;</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="text-align: center">บิดาเสียชีวิต</td>
                            </tr>
                            <!--จบหม้าย-->
                            <!--โสด-->
                            <tr>
                                <td style="background-color:darkseagreen;text-align:left;vertical-align:top">6. โสด<br/>(ไม่จดทะเบียน<br/>และแยกกันอยู่)</td>
                                <td style="background-color:pink;text-align: center">มารดา</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:violet;text-align: center">&#10003;</td>
                                <td style="background-color:pink;text-align: center">มารดา</td>
                                <td style="background-color:pink;text-align: center">&#x2718;</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="text-align: center">บิดาและมารดา<br/>มิได้จดทะเบียนสมรส<br/>และแยกกันอยู่</td>
                            </tr>                          
                            <!--จบโสด-->
                        </tbody>
                    </table>
				</div>
                <div id="tab5">
                    <table class="table">
                        <caption style="font-size:12pt;font-family: courier;font-weight:bold;color:black">กรณีที่ต้องติดต่อทำสัญญาภายนอกระบบ</caption>
                        <thead>
                            <tr>
                                <th scope="col" rowspan="2" style="text-align:center">ผู้ค้ำประกัน</th>
                                <th scope="col" colspan="2" style="background-color:violet;text-align:center">รหัสผ่าน</th>
                                <th scope="col" colspan="2" style="background-color:pink;text-align:center">สัญญาค้ำประกัน</th>
                                <th scope="col" colspan="2" style="background-color:skyblue;text-align:center">หนังสือแสดงความยินยอม</th>
                            </tr>
                            <tr>
                                <th scope="col" style="background-color:violet;text-align:center">ผู้ค้ำประกัน</th>
                                <th scope="col" style="background-color:violet;text-align:center">คู่สมรสของผู้ค้ำประกัน</th>
                                <th scope="col" style="background-color:pink;text-align:center">ผู้ค้ำประกัน</th>
                                <th scope="col" style="background-color:pink;text-align:center">ยินยอมโดย</th>
                                <th scope="col" style="background-color:skyblue;text-align:center">ผู้ค้ำประกัน</th>
                                <th scope="col" style="background-color:skyblue;text-align:center">คู่สมรสของผู้ค้ำประกัน</th>
                            </tr>
                        </thead>
                        <tbody>
                            <!--1. บิดาที่จดทะเบียนรับรองบุตร-->
                            <tr style="border-bottom:inset">
                                <td style="text-align: left">1. บิดาที่จดทะเบียนรับรองบุตร</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:pink;text-align: center">ผู้ค้ำประกัน</td>
                                <td style="background-color:pink;text-align: center">คู่สมรสของผู้ค้ำประกัน</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                            </tr>           
                            <!--จบ1. บิดาที่จดทะเบียนรับรองบุตร-->
                            <!--2. บุคคลที่จดทะเบียนรับนักศึกษาเป็นบุตรบุญธรรม-->
                              <tr style="border-bottom:inset">
                                <td style="text-align: left">2. บุคคลที่จดทะเบียนรับนักศึกษาเป็นบุตรบุญธรรม</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:pink;text-align: center">ผู้ค้ำประกัน</td>
                                <td style="background-color:pink;text-align: center">คู่สมรสของผู้ค้ำประกัน</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                            </tr>                        
                            <!--จบ2. บุคคลที่จดทะเบียนรับนักศึกษาเป็นบุตรบุญธรรม-->
                            <!--3. บุคคลอื่นที่ได้รับคำสั่งศาลให้เป็นผู้ปกครอง-->
                            <tr style="border-bottom:inset">
                                <td style="text-align: left">3. บุคคลอื่นที่ได้รับคำสั่งศาลให้เป็นผู้ปกครอง</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:pink;text-align: center">ผู้ค้ำประกัน</td>
                                <td style="background-color:pink;text-align: center">คู่สมรสของผู้ค้ำประกัน</td>
                                <td style="background-color:skyblue;text-align: center">&#10003;</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                            </tr>           
                            <!--จบ3. บุคคลอื่นที่ได้รับคำสั่งศาลให้เป็นผู้ปกครอง-->
                             <!--4. บุคคลอื่นที่ค้ำประกันโดยตำแหน่ง-->
                              <tr style="border-bottom:inset">
                                <td style="text-align: left">4. บุคคลอื่นที่ค้ำประกันโดยตำแหน่ง</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:pink;text-align: center">ผู้ค้ำประกัน</td>
                                <td style="background-color:pink;text-align: center">คู่สมรสของผู้ค้ำประกัน</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                            </tr>                        
                            <!--จบ4. บุคคลอื่นที่ค้ำประกันโดยตำแหน่ง-->
                            <!--5. บุคคลอื่นที่ค้ำประกันโดยหลักทรัพย์-->
                              <tr style="border-bottom:inset">
                                <td style="text-align: left">5. บุคคลอื่นที่ค้ำประกันโดยหลักทรัพย์</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:pink;text-align: center">ผู้ค้ำประกัน</td>
                                <td style="background-color:pink;text-align: center">คู่สมรสของผู้ค้ำประกัน</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                            </tr>                        
                            <!--จบ5. บุคคลอื่นที่ค้ำประกันโดยหลักทรัพย์-->
                            <!--6. นักศึกษาค้ำประกันโดยหนังสือค้ำประกันของธนาคาร (Bank Guarantees)-->
                              <tr style="border-bottom:inset">
                                <td style="text-align: left">6. นักศึกษาค้ำประกันโดยหนังสือค้ำประกันของธนาคาร (Bank Guarantees)</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:violet;text-align: center">&#x2718;</td>
                                <td style="background-color:pink;text-align: center">ผู้ค้ำประกัน</td>
                                <td style="background-color:pink;text-align: center">คู่สมรสของผู้ค้ำประกัน</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                                <td style="background-color:skyblue;text-align: center">&#x2718;</td>
                            </tr>                        
                            <!--จบ6. นักศึกษาค้ำประกันโดยหนังสือค้ำประกันของธนาคาร (Bank Guarantees)-->
                        </tbody>
                    </table>
				</div>
				<div id="tab2">
						<iframe id="FAQ1" style="display: none;" width="100%" height="700" frameborder="0" ></iframe>
				</div>
				<div id="tab3">
						<iframe id="FAQ2" style="display: none;" width="100%" height="700" frameborder="0" ></iframe>
				</div>
				<div id="tab4">
						<iframe id="FAQ3" style="display: none;" width="100%" height="700" frameborder="0" ></iframe>
				</div>
		</div>
</div>
<!-- end container -->
    <%--<div id="divBody" runat="server">
    </div>--%>

    <!-- footer banner -->
    <div class="page-footer" style="background-color: #A5802E;" id="divFooter" runat="server">
    </div>    
</body>
</html>
<script type="text/javascript">
$(document).ready(function() {
		$('#material-tabs').each(function() {

				var $active, $content, $links = $(this).find('a');

				$active = $($links[0]);
				$active.addClass('active');

				$content = $($active[0].hash);

				$links.not($active).each(function() {
						$(this.hash).hide();
				});

				$(this).on('click', 'a', function(e) {

						$active.removeClass('active');
						$content.hide();

						$active = $(this);
						$content = $(this.hash);

						$active.addClass('active');
						$content.show();

						e.preventDefault();
				});
		});
    });

    function openFAQ1() {
        var omyFrame1 = document.getElementById("FAQ1");
        omyFrame1.style.display = "block";
        omyFrame1.src = "FAQ/FAQ1.pdf";
    }
    function openFAQ2() {
        var omyFrame1 = document.getElementById("FAQ2");
        omyFrame1.style.display = "block";
        omyFrame1.src = "FAQ/FAQ2.pdf";
    }
    function openFAQ3() {
        var omyFrame1 = document.getElementById("FAQ3");
        omyFrame1.style.display = "block";
        omyFrame1.src = "FAQ/FAQ3.pdf";
    }
    </script>