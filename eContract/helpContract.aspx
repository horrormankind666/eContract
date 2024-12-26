<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="helpContract.aspx.cs" Inherits="eContract.HelpContract" %>

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
	<style type="text/css">
		.hide {
			display: none;
		}

		.tab-content {
			padding: 25px;
		}

		#material-tabs {
			position: relative;
			display: block;
			padding: 0;
			border-bottom: 1px solid #e0e0e0;
		}

		#material-tabs > a {
			position: relative;
			display: inline-block;
			text-decoration: none;
			padding: 22px;
			text-transform: uppercase;
			font-size: 14px;
			font-weight: 600;
			color: #424f5a;
			text-align: center;
			outline: none;
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
			.nav-tabs#material-tabs > li > a {
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
    <div id="divBanner" runat="server"></div>
    <!-- body panel -->
    <!-- container -->
    <div class="container">
		<header>
			<div id="material-tabs">
				<a id="tab1-tab" href="#tab1" class="active">คู่มือการใช้งานระบบ</a>
				<span class="yellow-bar"></span>
			</div>
		</header>
		<div class="tab-content">
			<div id="tab1">
                <iframe id="help" style="display: none;" height="700" frameborder="0" ></iframe>
			</div>				
		</div>
	</div>
    <!-- footer banner -->
    <div class="page-footer" style="background-color: #A5802E;" id="divFooter" runat="server"></div>    
</body>
</html>
<script type="text/javascript">
	helpPDF();

	$(document).ready(function() {
		$('#material-tabs').each(function() {
			var $active;
			var $content;
			var $links = $(this).find('a');

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

    function helpPDF() {
		var omyFrame1 = document.getElementById("help");

        omyFrame1.style.display = "block";
        omyFrame1.src = "help/help_e-Contract.pdf";
    }
    </script>