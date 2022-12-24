<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClubRepresentative.aspx.cs" Inherits="MileStone_3.ClubRepresentative" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ClubRepresentative</div>
    <p>
        Club Name:
    </p>
    <p>
        Location:
    </p>

    <table id ="playedmatches" runat="server" cellspacing="1" width="75%" border=1> <tr>
            <th> Host club name </th>
            <th> Guest Club name </th>
            <th> Start time </th>
            <th> End Time </th>
            <th> Stadium </th>
           </tr>
            <tr>
            <td id ="Td1" runat="server" > ---</td>
            <td id ="Td2" runat="server">---</td>
            <td id ="Td3" runat="server">---</td>
            <td id ="Td4" runat="server">---</td> 
            <td id ="Td5" runat="server">---</td> 
            </tr>
        </table>


    <p>
        &nbsp;</p>
    <p>
        Available Stadiums :</p>

      <table id ="Table1" runat="server" cellspacing="1" width="75%" border=1> <tr>
            <th> stadium name </th>
            <th> Location </th>
            <th> Capacity </th>
            <th> Send Request </th>
           </tr>
            <tr>
            <td id ="Td6" runat="server" > ---</td>
            <td id ="Td7" runat="server">---</td>
            <td id ="Td8" runat="server">---</td>
            <td id ="Td9" runat="server">
                <asp:Button ID="SendRequest" runat="server" Text="Send Request" />
                </td> 
            </tr>
        </table>

    </form>
    
</body>
</html>
