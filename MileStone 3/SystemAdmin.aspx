<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemAdmin.aspx.cs" Inherits="MileStone_3.SystemAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        SYSTEM ADMIN<div>
        </div>
        <p>
            Add Club</p>
        <p>
            Name:
            <asp:TextBox ID="clubnameadd" runat="server"></asp:TextBox>
        &nbsp;&nbsp; Location:
            <asp:TextBox ID="clublocationadd" runat="server" style="margin-bottom: 0px" ></asp:TextBox>
        &nbsp;
            <asp:Button ID="clubadd" runat="server" OnClick="clubadd_Click" Text="ADD" />
        </p>
        <p>
            Delete Club:
        </p>
        <p>
        &nbsp;
            Name:
            <asp:TextBox ID="clubnamedelete" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="clubdelete" runat="server" Text="Delete" OnClick="clubdelete_Click" />
        </p>
        <p>
            Add
            Stadium: </p>
        <p>
            Name:
            <asp:TextBox ID="stadiumnameadd" runat="server"></asp:TextBox>
&nbsp;Location:
            <asp:TextBox ID="stadiumlocationadd" runat="server"></asp:TextBox>
&nbsp;
            Capacity:&nbsp;
            <asp:TextBox ID="stadiumcapacityadd" runat="server"></asp:TextBox>
            <asp:Button ID="stadiumadd" runat="server" Text="ADD" OnClick="stadiumadd_Click" />
        </p>
        <p>
            Delete
            Stadium:
        </p>
        <p>
            Name:
            <asp:TextBox ID="stadiumnamedelete" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="stadiumdelete" runat="server" Text="Delete" OnClick="stadiumdelete_Click" />
        </p>
        <p>
            Block Fan:</p>
        <p>
            National ID:&nbsp;
            <asp:TextBox ID="fannationalid" runat="server" ></asp:TextBox>
&nbsp;<asp:Button ID="blockfan" runat="server" Text="Block" OnClick="blockfan_Click" />
        </p>
    </form>
</body>
</html>
