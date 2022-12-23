<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MileStone_3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Login
        <p>
            Username</p>
        <p>
            <asp:TextBox ID="username" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </p>
        Password<p>
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="signin" runat="server" Text="login" OnClick="login" />
        </p>
    </form>
</body>
</html>
