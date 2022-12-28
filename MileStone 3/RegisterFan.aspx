<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterFan.aspx.cs" Inherits="MileStone_3.RegisterFan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register fan</title>
<meta charset="UTF-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="css/util.css"/>
	<link rel="stylesheet" type="text/css" href="css/main.css"/>
<!--===============================================================================================-->
</head>
<body>
	
	<div class="limiter">
		<div class="container-login100" style="background-image: url('images/fan.jpg');">
			<div class="wrap-login100 p-t-30 p-b-50">
				<span class="login100-form-title p-b-41">
					Register As a Fan
				</span>
				<div runat="server" id='loginalert' class="alert">
                    <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
                    <asp:label runat="server" ID="msg"></asp:label>
                </div>
				<form  id="form1" runat="server" class="login100-form validate-form p-b-33 p-t-5">
					<div class="wrap-input100">
							<asp:TextBox ID="name" runat="server" class="input100" type="text" name="name" placeholder="Name" required="True"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe82a;"></span>
					</div>
					<div class="wrap-input100">
							<asp:TextBox ID="username" runat="server" class="input100" type="text" name="username" placeholder="Username" required="True"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe82a;"></span>
					</div>

					<div class="wrap-input100">
						 <asp:TextBox ID="password" runat="server"  class="input100" type="password" name="pass" placeholder="Password" required="True"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe80f;"></span>
					</div>

					<div class="wrap-input100">
							<asp:TextBox ID="nationalid" runat="server" class="input100" type="text" name="nationalid" placeholder="National Id Number" required="True"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe82a;"></span>
					</div>
					<div class="wrap-input100">
							<asp:TextBox ID="phone" runat="server" class="input100" type="text" name="phone" placeholder="Phone Number"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe82a;"></span>
					</div>
					<div class="wrap-input100">
							<asp:TextBox ID="adress" runat="server" class="input100" type="text" name="adress" placeholder="Adress"></asp:TextBox>
						<span class="focus-input100" data-placeholder="&#xe82a;"></span>
					</div>
					<div class="wrap-input100">
							<asp:TextBox ID="birthdate" runat="server" class="input100" type="datetime-local" name="birthdate" placeholder="Birth Date"></asp:TextBox>
						<span class="focus-input100" ></span>
					</div>

					<div class="container-login100-form-btn m-t-32">
                        <asp:Button ID="signup" class="login100-form-btn" runat="server" Text="Sign UP" OnClick="signup_Click"></asp:Button>
					</div>
				</form>
			</div>
		</div>
	</div>
	</body>
</html>
