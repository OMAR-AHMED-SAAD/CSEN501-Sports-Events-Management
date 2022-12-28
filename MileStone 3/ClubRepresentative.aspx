<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClubRepresentative.aspx.cs" Inherits="MileStone_3.ClubRepresentative" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Club Representative</title>
    <style type="text/css">
        .auto-style2 {
            width: 243px;
            height: 32px;
        }
        .auto-style3 {
            width: 247px;
            height: 32px;
        }
        .auto-style4 {
            width: 309px;
            height: 32px;
        }
        .auto-style5 {
            height: 31px;
        }
        .auto-style6 {
            height: 32px;
            width: 328px;
        }
        .auto-style7 {
            width: 85%;
        }
        #requests{
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>
            ClubRepresentative</h2>
        <h3>
            CLub Name:&nbsp;&nbsp;
            <asp:Label ID="clubname" runat="server" Text=""></asp:Label>
    </h3>
    <h3>
        Club Location:&nbsp;&nbsp;
        <asp:Label ID="clublocation" runat="server" Text=""></asp:Label>
    </h3>
    <div>
        <h3> 
            <asp:Label ID="Label1" runat="server" Text="Upcoming Matches"></asp:Label> &nbsp;&nbsp; 
            <asp:Button ID="displayupcoming" runat="server" Text="Display" OnClick="displayupcoming_Click" Height="27px" Width="122px" />
        </h3>
        
    <table id ="upcomingmatches" runat="server" cellspacing="1" border="1" class="auto-style7"> <tr>
            <th class="auto-style4"> Host Club </th>
            <th class="auto-style4"> Guest Club </th>
            <th class="auto-style3"> Start time </th>
            <th class="auto-style2"> End Time </th>
            <th class="auto-style6"> Stadium </th>
           </tr>
        </table>
    </div>

    <p>
        &nbsp;</p>
        <div>
    <h3>
       <asp:Label ID="Label2" runat="server" Text="Available Stadiums"></asp:Label> &nbsp;&nbsp;&nbsp; 
    </h3>
<h4>
        <asp:Label ID="Label7" runat="server" Text="Starting from:"></asp:Label> &nbsp;&nbsp; 
          <input type="datetime-local" runat="server" id="stadiumdate" reuired="true"/>&nbsp;&nbsp; 
        <asp:Button ID="availablestadiums" runat="server" Text="Display" Height="27px" Width="122px" OnClick="availablestadiums_Click" />
</h4>
      <table id ="availablestad" runat="server" cellspacing="1" width="75%" border="1"> <tr>
            <th class="auto-style5"> Stadium Name </th>
            <th class="auto-style5"> Location </th>
            <th class="auto-style5"> Capacity </th>
           </tr>
        </table>
              </div>
         <p>
        &nbsp;</p>
        <div>
            <h3>
        <asp:Label ID="Label3" runat="server" Text="Send Requests"></asp:Label>
            &nbsp;&nbsp;
                <asp:Button ID="sendrequests" runat="server"  Text="More Info" OnClick="sendrequests_Click" />
                </h3>
           </div>
        <div id="requests" runat="server">
                <asp:Label ID="Label4" runat="server" Text="Guest Club"></asp:Label>
&nbsp;  
                <asp:DropDownList ID="guestclubs" runat="server" AutoPostBack="true" OnSelectedIndexChanged="guestclubs_SelectedIndexChanged">
                    <asp:ListItem Value="Choose Guest" hidden="True"></asp:ListItem>
                </asp:DropDownList>
&nbsp;
                <asp:Label ID="Label5" runat="server" Text="Start time"></asp:Label>
&nbsp;
                <asp:DropDownList ID="starttime"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="starttime_SelectedIndexChanged">
                    <asp:ListItem Value="Choose Start time" hidden="True"></asp:ListItem>
                </asp:DropDownList>
&nbsp;
                <asp:Label ID="Label6" runat="server" Text="Stadium"></asp:Label>
&nbsp;
                <asp:DropDownList ID="stadium" runat="server">
                    <asp:ListItem Value="Choose Stadium" hidden="True"></asp:ListItem>
                </asp:DropDownList>
        &nbsp;<asp:Button ID="SendRequest" runat="server" OnClick="SendRequest_Click" Text="Send Request" Width="213px" />
        </div>
    </form>
    
</body>
</html>
