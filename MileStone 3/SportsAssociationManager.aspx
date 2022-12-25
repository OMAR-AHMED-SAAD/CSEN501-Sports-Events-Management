<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SportsAssociationManager.aspx.cs" Inherits="MileStone_3.SportsAssociationManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SPA</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>SportsAssociationManager
        </h2>
        <h3>Add/Delete Club
        </h3>
        <h4>Host Club Name:
            <asp:TextBox ID="hostclubname" runat="server"></asp:TextBox>
        </h4>
        <h4>Guest Club name:
            <asp:TextBox ID="guestclubname" runat="server"></asp:TextBox>
        </h4>
        <h4>Start Time:
  
            <input type="datetime-local" runat="server" id="starttime"
                name="start-time" />

            End Time:
           <input type="datetime-local" runat="server" id="endtime"
               name="end-time" />
        </h4>
        <p>
            <asp:Button ID="addmatch" runat="server" Text="Add Match" OnClick="addmatch_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="deletematch" runat="server" Text="Delete Match" OnClick="deletematch_Click" />
        </p>
        <p>
            &nbsp;
        </p>
        <h3>Upcoming Matches&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="upcoming" runat="server" Text="Display" OnClick="upcoming_Click" />
        </h3>
        <table id="upcomingmatches" runat="server" cellspacing="1" width="75%" border="1">
            <tr>
                <th>Host club name </th>
                <th>Guest Club name </th>
                <th>Start time </th>
                <th>End Time </th>
            </tr>
        </table>
        <p>
            &nbsp;
        </p>
        <h3>Played Matches&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
    <asp:Button ID="played_matches" runat="server" Text="Display" OnClick="played_matches_Click" />

        </h3>

        <table id="playedmatches" runat="server" cellspacing="1" width="75%" border="1">
            <tr>
                <th>Host club name </th>
                <th>Guest Club name </th>
                <th>Start time </th>
                <th>End Time </th>
            </tr>
        </table>
        <p>
            &nbsp;
        </p>
        <h3>Clubs that never played against eachother:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="neverplayed" runat="server" Text="Display" OnClick="neverplayed_Click" />

        </h3>

        <table id="clubsneverplayed" runat="server" cellspacing="1" width="75%" border="1">
            <tr>
                <th>Club 1 </th>
                <th>Club 2 </th>
            </tr>
        </table>

    </form>
</body>
</html>
