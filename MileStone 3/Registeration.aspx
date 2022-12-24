<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registeration.aspx.cs" Inherits="MileStone_3.Registeration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registeration</title>
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
		<div class="container-login100" style="background-image: url('images/bg-01.jpg'); background-color: rgba(0,0,0,0.65);">
			<div class="wrap-login100 p-t-30 p-b-50">
				<span class="login100-form-title p-b-41">
					Register AS
				</span>
				<form  id="form1" runat="server" class="login100-form validate-form p-b-33 p-t-5">
                    <div class="container-login100-form-btn m-t-32">
                         <asp:Button ID="registersportsassociationmanager" class="register100-form-btn" runat="server" Text="Sports Association Manager" OnClick="registersportsassociationmanager_Click"></asp:Button>
                    </div>
                    <div class="container-login100-form-btn m-t-32">
                        <asp:Button ID="registerclubrepresentative" class="register100-form-btn" runat="server" Text="Club Representative" OnClick="registerclubrepresentative_Click"></asp:Button>
                    </div>
                    <div class="container-login100-form-btn m-t-32">
                        <asp:Button ID="registerstadiummanager" class="register100-form-btn" runat="server" Text="Stadium Manager" OnClick="registerstadiummanager_Click"></asp:Button>
                    </div>
                    <div class="container-login100-form-btn m-t-32">
                         <asp:Button ID="resgisterfan" class="register100-form-btn" runat="server" Text="Fan " OnClick="resgisterfan_Click"></asp:Button>
                    </div>
				</form>
			</div>
		</div>
	</div>
</body>
</html>
