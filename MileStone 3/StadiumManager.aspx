<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadiumManager.aspx.cs" Inherits="MileStone_3.StadiumManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            StadiumManager</div>
    <p>
        Stadium Name:
    </p>
    <p>
        location:
    </p>
    <p>
        Capacity:
    </p>
    <p>
        &nbsp;</p>
    <p>
        Recieved Requests:
    </p>
    <table id ="requests" runat="server" cellspacing="1" width="75%" border=1> <tr>
            <th> Sending club representative </th>
            <th> Host club name </th>
            <th> Guest Club name </th>
            <th> Start time </th>
            <th> End Time </th>
            <th> Status </th>
            <th> Accept/reject </th>
           </tr>
            <tr>
            <td id ="td1" runat="server" > ---</td>
            <td id ="td2" runat="server">---</td>
            <td id ="td3" runat="server">---</td>
            <td id ="td4" runat="server">---</td>
            <td id="td5" runat="server">---</td>   
            <td id ="td6" runat="server">---</td>   
            <td id ="td7" runat="server">  
                <asp:Button ID="acceptrequest" runat="server" Text="Accept" />
&nbsp;<asp:Button ID="rejectrequest" runat="server" Text="Reject" />
                </td>       
            </tr>
        </table>
    </form>
    </body>
</html>
