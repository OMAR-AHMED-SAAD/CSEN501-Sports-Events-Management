<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SportsAssociationManager.aspx.cs" Inherits="MileStone_3.SportsAssociationManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            SportsAssociationManager</div>
        <p>
            &nbsp;</p>
        <p>
            Add club</p>
        <p>
            Host Club Name:
            <asp:TextBox ID="hostclubname" runat="server"></asp:TextBox>
        </p>
        <p>
            Guest Club name:
            <asp:TextBox ID="guestclubname" runat="server"></asp:TextBox>
        </p>
        <p>
            Start Time:
  
            <input type="datetime-local" runat="server" id="starttime"
       name="start-time"/>

 End Time:
           <input type="datetime-local" runat="server" id="endtime"
       name="end-time"/>
        </p>
        <p>
					
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="addmatch" runat="server" Text="Add Match" OnClick="addmatch_Click" />
&nbsp;&nbsp;
            <asp:Button ID="deletematch" runat="server" Text="Delete Match" OnClick="deletematch_Click" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            Upcoming Matches&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="upcoming" runat="server" Height="33px" Text="Display" OnClick="upcoming_Click" />
        </p>
        <table id ="upcomingmatches" runat="server" cellspacing="1" width="75%" border="1"> <tr>
            <th> Host club name </th>
            <th> Guest Club name </th>
            <th> Start time </th>
            <th> End Time </th>
           </tr>
            </table>

    </form>
    <p>
        &nbsp;</p>
    <p>
        Played Matches</p>

    <table id ="playedmatches" runat="server" cellspacing="1" width="75%" border="1"> <tr>
            <th> Host club name </th>
            <th> Guest Club name </th>
            <th> Start time </th>
            <th> End Time </th>
           </tr>
            <tr>
            <td id ="Td1" runat="server" > ---</td>
            <td id ="Td2" runat="server">---</td>
            <td id ="Td3" runat="server">---</td>
            <td id ="Td4" runat="server">---</td> 
            </tr>
        </table>
    <p>
        &nbsp;</p>
    <p>
        Clubs that never played against eachother:
    </p>
</body>
</html>
