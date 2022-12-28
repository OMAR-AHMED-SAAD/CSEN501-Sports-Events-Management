<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadiumManager.aspx.cs" Inherits="MileStone_3.StadiumManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        .auto-style1 {
            width: 1246px;
        }
        .auto-style2 {
            width: 289px;
        }
        .auto-style3 {
            width: 190px;
        }
        .auto-style5 {
            width: 1203px;
        }
        #pen{
            display:none;
        }
        </style>
        
</head>
<body>
    <form id="form1" runat="server">
        <h2>
            StadiumManager</h2>
    <h3>
        Stadium Name:
                    <asp:Label ID="stadiumname" runat="server" Text=""></asp:Label>

    </h3>
    <h3>
        Location:
                    <asp:Label ID="stadiumlocation" runat="server" Text=""></asp:Label>

    </h3>
    <h3>
        Capacity:
                    <asp:Label ID="stadiumcapacity" runat="server" Text=""></asp:Label>

    </h3>
    <p>
        &nbsp;</p>
    <h3>
       All Recieved Requests:&nbsp;&nbsp;
        <asp:Button ID="allreq" runat="server" Text="Display" Width="75px" OnClick="allreq_Click" />

    </h3>
    <table id ="requests" runat="server" cellspacing="1" border="1" class="auto-style1"> <tr>
            <th class="auto-style2" > Sending Club Representative </th>
            <th > Host Club</th>
            <th class="auto-style3" > Guest Club</th>
            <th > Start time </th>
            <th > End Time </th>
            <th > Status </th>
           </tr>
        </table>
         <p>
             &nbsp;</p>
    <h3>
        Pending Requests:&nbsp;&nbsp;
        <asp:Button ID="pendingreq" runat="server" Text="Display" Width="75px" OnClick="pendingreq_Click" />
    </h3>
        <div id="pen" runat="server">
    <asp:Table id ="pending1" runat="server" cellspacing="1" border="1" class="auto-style5" Width="1215px"> 
       <asp:TableHeaderRow>
           <asp:TableHeaderCell>
                Sending Club Representative
           </asp:TableHeaderCell>
           <asp:TableHeaderCell>
                Host Club
           </asp:TableHeaderCell>
           <asp:TableHeaderCell>
                Guest Club
           </asp:TableHeaderCell>
<asp:TableHeaderCell>
                Start Time
           </asp:TableHeaderCell>
<asp:TableHeaderCell>
                End Time
           </asp:TableHeaderCell>
<asp:TableHeaderCell>
                Accept
           </asp:TableHeaderCell>
<asp:TableHeaderCell>
                Reject
           </asp:TableHeaderCell>

       </asp:TableHeaderRow>
        </asp:Table>
        </div>
    </form>
    </body>
</html>
