<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fan.aspx.cs" Inherits="MileStone_3.Fan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Fan</div>
    </form>
      <table id ="Table1" runat="server" cellspacing="1" width="75%" border=1> <tr>
            <th> Host Club Name </th>
            <th> Guest Club Name  </th>
            <th> Satdium </th>
            <th> Location </th>
          <th> Purchase Ticket </th>
           </tr>
            <tr>
            <td id ="Td6" runat="server" > ---</td>
            <td id ="Td7" runat="server">---</td>
            <td id ="Td8" runat="server">---</td>
            <td id="Td9" runat="server"> ---</td>
            <td id ="Td10" runat="server">
                <asp:Button ID="buyticket" runat="server" Text="Buy Ticket" />
                </td> 
            </tr>
        </table>
</body>
</html>
