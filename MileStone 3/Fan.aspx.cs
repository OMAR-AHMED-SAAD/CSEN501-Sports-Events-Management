using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MileStone_3
{
    public partial class Fan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void availablematches_Click(object sender, EventArgs e)
        {
            string date1 = matchdate.Value;

            if (date1 == "")
            {
                Response.Write("Must choose a date to start from");
                return;
            }
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand availablematchesfx = new SqlCommand("SELECT * FROM dbo.availableMatchesToAttend3(@date)", conn);
            availablematchesfx.CommandType = CommandType.Text;
            availablematchesfx.Parameters.AddWithValue("@date", Convert.ToDateTime(date1));

            conn.Open();
            SqlDataReader rdr = availablematchesfx.ExecuteReader();
            while (rdr.Read())
            {
                string host = rdr[0].ToString();
                string guest = rdr[1].ToString();
                string stadium = rdr[2].ToString();
                string location = rdr[3].ToString();


                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell td = new HtmlTableCell();
                HtmlTableCell td1 = new HtmlTableCell();
                HtmlTableCell td2 = new HtmlTableCell();
                HtmlTableCell td3 = new HtmlTableCell();
                td.InnerText = host;
                td1.InnerText = guest;
                td2.InnerText = stadium;
                td3.InnerText = location;


                tr.Controls.Add(td);
                tr.Controls.Add(td1);
                tr.Controls.Add(td2);
                tr.Controls.Add(td3);
                matches.Rows.Add(tr);

            }
            conn.Close();

        }
        protected void showtickets_Click(object sender, EventArgs e)
        {
            purchase.Style.Add("display", "block");

            int i = hostclubs.Items.Count - 1;
            while (hostclubs.Items.Count > 1)
            {
                hostclubs.Items.RemoveAt(i);
                i--;
            }
            i = guestclubs.Items.Count - 1;
            while (guestclubs.Items.Count > 1)
            {
                guestclubs.Items.RemoveAt(i);
                i--;
            }
            i = starttime.Items.Count - 1;
            while (starttime.Items.Count > 1)
            {
                starttime.Items.RemoveAt(i);
                i--;
            }
            i = stadium.Items.Count - 1;
            while (stadium.Items.Count > 1)
            {
                stadium.Items.RemoveAt(i);
                i--;
            }

            
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand gethosts = new SqlCommand("SELECT host FROM dbo.availableMatchesToAttend4()", conn);
            gethosts.CommandType = CommandType.Text;
          
            conn.Open();
            SqlDataReader rdr1 = gethosts.ExecuteReader();
            while (rdr1.Read())
            {
                ListItem guest = new ListItem(rdr1[0].ToString());
                hostclubs.Items.Add(guest);
            }

            conn.Close();
        }
        protected void hostclubs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = guestclubs.Items.Count - 1;
            while (guestclubs.Items.Count > 1)
            {
                guestclubs.Items.RemoveAt(i);
                i--;
            }
            i = starttime.Items.Count - 1;
            while (starttime.Items.Count > 1)
            {
                starttime.Items.RemoveAt(i);
                i--;
            }
            i = stadium.Items.Count - 1;
            while (stadium.Items.Count > 1)
            {
                stadium.Items.RemoveAt(i);
                i--;
            }

            string host = hostclubs.SelectedValue;
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand getmyguests = new SqlCommand("SELECT guest FROM dbo.availableMatchesToAttend4() WHERE host=@host", conn);
            getmyguests.CommandType = CommandType.Text;
            getmyguests.Parameters.AddWithValue("@host", host);
            conn.Open();
            SqlDataReader rdr1 = getmyguests.ExecuteReader();
            while (rdr1.Read())
            {
                ListItem guest = new ListItem(rdr1[0].ToString());
                guestclubs.Items.Add(guest);
            }

            conn.Close();

        }

    

        protected void guestclubs_SelectedIndexChanged(object sender, EventArgs e)
        {
           int i = starttime.Items.Count - 1;
            while (starttime.Items.Count > 1)
            {
                starttime.Items.RemoveAt(i);
                i--;
            }
            i = stadium.Items.Count - 1;
            while (stadium.Items.Count > 1)
            {
                stadium.Items.RemoveAt(i);
                i--;
            }
            string host = hostclubs.SelectedValue;
            string guest = guestclubs.SelectedValue;
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand start = new SqlCommand("SELECT start_time FROM dbo.availableMatchesToAttend4() WHERE host=@host AND guest=@guest", conn);
            start.CommandType = CommandType.Text;
            start.Parameters.AddWithValue("@host", host);
            start.Parameters.AddWithValue("@guest", guest);

            conn.Open();
            SqlDataReader rdr = start.ExecuteReader();
            while (rdr.Read())
            {
                ListItem start1 = new ListItem(rdr[0].ToString());
                starttime.Items.Add(start1);
            }

            conn.Close();
        }

        protected void starttime_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = stadium.Items.Count - 1;
            while (stadium.Items.Count > 1)
            {
                stadium.Items.RemoveAt(i);
                i--;
            }
            string host = hostclubs.SelectedValue;
            string guest = guestclubs.SelectedValue;
            string date1 = starttime.SelectedValue;
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand availablestadiums = new SqlCommand("SELECT Stadium FROM dbo.availableMatchesToAttend4() WHERE host=@host AND guest=@guest AND start_time=@date", conn);
            availablestadiums.CommandType = CommandType.Text;
            availablestadiums.Parameters.AddWithValue("@host", host);
            availablestadiums.Parameters.AddWithValue("@guest", guest);
            availablestadiums.Parameters.AddWithValue("@date", Convert.ToDateTime(date1));
            conn.Open();
            SqlDataReader rdr2 = availablestadiums.ExecuteReader();
            while (rdr2.Read())
            {
                ListItem stadium1 = new ListItem(rdr2[0].ToString());
                stadium.Items.Add(stadium1);

            }
            conn.Close();
        }

        protected void buyticket_Click(object sender, EventArgs e)
        {
            string national_id = "";
            string status = "";
            string host = hostclubs.SelectedValue;
            string guest = guestclubs.SelectedValue;
            string start_time = starttime.SelectedValue;
            if (host== "Choose Host" || guest == "Choose Guest" || start_time == "Choose Start time" )
            {
                Response.Write("Must choose a host, a guest and match start time to purchase a ticket.");
                return;
            }
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand getnatonalid = new SqlCommand("SELECT national_id,status FROM Fan WHERE username=@user ", conn);
            string user = Session["user"].ToString();
            getnatonalid.Parameters.AddWithValue("@user", user);
            conn.Open();
            SqlDataReader rdr=getnatonalid.ExecuteReader();
            while (rdr.Read())
            {
                national_id = rdr[0].ToString();
                status = rdr[1].ToString();
            }
            conn.Close();
            if (status == "False")
            {
                purchase.Style.Add("display", "none");
                Response.Write("You are currently blocked");
                return;
            }

            SqlCommand buyticket1 = new SqlCommand("purchaseTicket", conn);
            buyticket1.CommandType = CommandType.StoredProcedure;
             buyticket1.Parameters.Add(new SqlParameter("@national_id", national_id));
            buyticket1.Parameters.Add(new SqlParameter("@host_name", host));
            buyticket1.Parameters.Add(new SqlParameter("@guest_name", guest));
            buyticket1.Parameters.Add(new SqlParameter("@start_time", Convert.ToDateTime(start_time)));
            conn.Open();
            buyticket1.ExecuteNonQuery();
            conn.Close();

            purchase.Style.Add("display", "none");
            Response.Write("Ticket purchased succesfully");
        }
    }
}