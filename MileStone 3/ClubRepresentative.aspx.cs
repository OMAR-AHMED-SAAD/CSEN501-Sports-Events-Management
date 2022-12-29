using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace MileStone_3
{
    public partial class ClubRepresentative : System.Web.UI.Page
    {
        static String club = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand myclub = new SqlCommand("SELECT c.name,c.location FROM ClubRepresentative cr JOIN Club c ON (cr.club_id=c.id) WHERE cr.username=@user", conn);
            myclub.CommandType = CommandType.Text;
            string user = Session["user"].ToString();
            myclub.Parameters.AddWithValue("@user", user);
            conn.Open();
            SqlDataReader rdr = myclub.ExecuteReader();
            while (rdr.Read())
            {
                string name = rdr[0].ToString();
                string location = rdr[1].ToString();
                clubname.Text = name;
                clublocation.Text = location;
                club = name;
            }
            conn.Close();
           
        }
        protected void displayupcoming_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand upcomingmatches1 = new SqlCommand(" SELECT * FROM dbo.upcomingMatchesOfClub2(@club)", conn);
            upcomingmatches1.CommandType = CommandType.Text;
            upcomingmatches1.Parameters.AddWithValue("@club", club);

            conn.Open();
            SqlDataReader rdr = upcomingmatches1.ExecuteReader();
            while (rdr.Read())
            {
                string host = rdr[0].ToString();
                string guest = rdr[1].ToString();
                string start = rdr[2].ToString();
                string end = rdr[3].ToString();
                string stadium = rdr[4].ToString();

                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell td = new HtmlTableCell();
                HtmlTableCell td1 = new HtmlTableCell();
                HtmlTableCell td2 = new HtmlTableCell();
                HtmlTableCell td3 = new HtmlTableCell();
                HtmlTableCell td4 = new HtmlTableCell();

                td.InnerText = host;
                td1.InnerText = guest;
                td2.InnerText = start;
                td3.InnerText = end;
                td4.InnerText = stadium;
                tr.Controls.Add(td);
                tr.Controls.Add(td1);
                tr.Controls.Add(td2);
                tr.Controls.Add(td3);
                tr.Controls.Add(td4);
                upcomingmatches.Rows.Add(tr);
            }
            conn.Close();
        }
        protected void availablestadiums_Click(object sender, EventArgs e)
        {
            string date1 = stadiumdate.Value;

            if (date1== "")
            {
                Response.Write("Must choose a date to start from");
                return;
            }
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand availablestadiums = new SqlCommand("SELECT s.name, s.location, s.capacity FROM Stadium S INNER JOIN StadiumManager sm ON (s.id=sm.stadium_id)  WHERE status=1 AND s.id NOT IN (SELECT stadium_id FROM Match WHERE start_time>=@date AND stadium_id IS NOT NULL)", conn);
            availablestadiums.CommandType = CommandType.Text;
            availablestadiums.Parameters.AddWithValue("@date", Convert.ToDateTime(date1));

            conn.Open();
            SqlDataReader rdr = availablestadiums.ExecuteReader();
            while (rdr.Read())
            {
                string stadium = rdr[0].ToString();
                string location = rdr[1].ToString();
                string capacity = rdr[2].ToString();

                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell td = new HtmlTableCell();
                HtmlTableCell td1 = new HtmlTableCell();
                HtmlTableCell td2 = new HtmlTableCell();
                td.InnerText = stadium;
                td1.InnerText = location;
                td2.InnerText = capacity;

                tr.Controls.Add(td);
                tr.Controls.Add(td1);
                tr.Controls.Add(td2);

                availablestad.Rows.Add(tr);

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



            string guest = guestclubs.SelectedValue;


            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand start = new SqlCommand(" SELECT m.start_time FROM Club c1 JOIN Match m ON(c1.id = m.host_id) JOIN  Club c2 ON(c2.id = m.guest_id) WHERE c1.name = @host AND c2.name=@guest AND m.stadium_id IS NULL AND m.start_time >CURRENT_TIMESTAMP", conn);
            start.CommandType = CommandType.Text;
            start.Parameters.AddWithValue("@host", club);
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
            string date1 = starttime.SelectedValue;
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand availablestadiums = new SqlCommand("SELECT S.name FROM Stadium S INNER JOIN StadiumManager sm ON (s.id=sm.stadium_id)  WHERE status=1 AND s.id NOT IN (SELECT stadium_id FROM Match WHERE start_time>=@date AND stadium_id IS NOT NULL)", conn);
            availablestadiums.CommandType = CommandType.Text;
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


        protected void SendRequest_Click(object sender, EventArgs e)
        {

            string guest = guestclubs.SelectedValue;
            string start_time = starttime.SelectedValue;
            string stadium1 = stadium.SelectedValue;
            if (guest == "Choose Guest" || start_time == "Choose Start time" || stadium1 == "Choose Stadium")
            {
                Response.Write("Must choose a guest,start time and a stadium to send a hosting request");
                return;
            }
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand addhr = new SqlCommand("addHostRequest", conn);
            addhr.CommandType = CommandType.StoredProcedure;
            addhr.Parameters.Add(new SqlParameter("@club", club));
            addhr.Parameters.Add(new SqlParameter("@stadium", stadium1));
            addhr.Parameters.Add(new SqlParameter("@start_time", Convert.ToDateTime(start_time)));


            conn.Open();
            try
            {
                addhr.ExecuteNonQuery();
                Response.Write("Hosting request added succesfully");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627: Response.Write("Hosting request already added"); ; break;
                    default: throw;
                }
            }
            finally
            {
                conn.Close();
                guestclubs.SelectedValue= "Choose Guest";
                starttime.SelectedValue= "Choose Start time";
                stadium.SelectedValue= "Choose Stadium";
            }
           

        }

        protected void sendrequests_Click(object sender, EventArgs e)
        {
            requests.Style.Add("display", "block");
           
            int i = guestclubs.Items.Count-1;
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
            SqlCommand getmyguests = new SqlCommand("SELECT DISTINCT c2.name FROM Club c1 JOIN Match m ON(c1.id = m.host_id) JOIN  Club c2 ON(c2.id = m.guest_id) WHERE c1.name = @name AND stadium_id IS NULL AND m.start_time >CURRENT_TIMESTAMP", conn);
            getmyguests.CommandType = CommandType.Text;
            getmyguests.Parameters.AddWithValue("@name", club);
             conn.Open();
            SqlDataReader rdr1 = getmyguests.ExecuteReader();
            while (rdr1.Read())
            {
                ListItem guest = new ListItem(rdr1[0].ToString());
                guestclubs.Items.Add(guest);
            }

            conn.Close();
        }

       

        
    }
}