<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fan.aspx.cs" Inherits="MileStone_3.Fan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FAN</title>
    <style>
         #purchase{
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>
            Fan</h2>

    <h3>
       <asp:Label ID="Label2" runat="server" Text="Available Matches To Attend"></asp:Label> &nbsp;&nbsp;&nbsp; 
    </h3>
<h4>
        <asp:Label ID="Label7" runat="server" Text="Starting from:"></asp:Label> &nbsp;&nbsp; 
          <input type="datetime-local" runat="server" id="matchdate" reuired="true"/>&nbsp;&nbsp; 
        <asp:Button ID="availablematches" runat="server" Text="Display" Height="27px" Width="122px" OnClick="availablematches_Click"/>
</h4>
      <table id ="matches" runat="server" cellspacing="1" width="75%" border="1"> <tr>
            <th> Host Club Name </th>
            <th> Guest Club Name  </th>
            <th> Satdium </th>
            <th> Location </th>
        </tr>
          </table>

        <p>
        &nbsp;</p>
        <div>
            <h3>
        <asp:Label ID="Label3" runat="server" Text="Purchase Tickets"></asp:Label>
            &nbsp;&nbsp;
                <asp:Button ID="showtickets" runat="server"  Text="More Info" OnClick="showtickets_Click"  />
                </h3>
           </div>
        <div id="purchase" runat="server">
                <asp:Label ID="Label4" runat="server" Text="Host Club"></asp:Label>
&nbsp;  
                <asp:DropDownList ID="hostclubs" runat="server" AutoPostBack="true" OnSelectedIndexChanged="hostclubs_SelectedIndexChanged" >
                    <asp:ListItem Value="Choose Host" hidden="True"></asp:ListItem>
                </asp:DropDownList>
&nbsp;
 <asp:Label ID="Label1" runat="server" Text="Guest Club"></asp:Label>
&nbsp;  
                <asp:DropDownList ID="guestclubs" runat="server" AutoPostBack="true" OnSelectedIndexChanged="guestclubs_SelectedIndexChanged" >
                    <asp:ListItem Value="Choose Guest" hidden="True"></asp:ListItem>
                </asp:DropDownList>
&nbsp;
                <asp:Label ID="Label5" runat="server" Text="Start time"></asp:Label>
&nbsp;
                <asp:DropDownList ID="starttime"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="starttime_SelectedIndexChanged" >
                    <asp:ListItem Value="Choose Start time" hidden="True"></asp:ListItem>
                </asp:DropDownList>
            &nbsp;
                <asp:Label ID="Label6" runat="server" Text="Stadium"></asp:Label>
&nbsp;
             <asp:DropDownList ID="stadium" runat="server">
                    <asp:ListItem Value="Choose Stadium" hidden="True"></asp:ListItem>
                </asp:DropDownList>

        &nbsp; <asp:Button ID="buyticket" runat="server" Text="Purchase" Width="213px" OnClick="buyticket_Click" />
        </div>
          </form>
</body>
</html>
