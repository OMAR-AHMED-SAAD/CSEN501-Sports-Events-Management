using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;

namespace MileStone_3
{
    public partial class SportsAssociationManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addmatch_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string hostclub = hostclubname.Text;
            string guestclub = guestclubname.Text;
            String start = starttime.Value;
            String end = endtime.Value;

            if (hostclub == "" || guestclub == "" || start == "" || end == "")
            {
                Response.Write("You must enter host club, guest club, start time and end time");
            }
            else
            {
                SqlCommand checkclub = new SqlCommand("checkclub", conn);
                checkclub.CommandType = CommandType.StoredProcedure;
                checkclub.Parameters.Add(new SqlParameter("name", hostclub));
                SqlParameter found = checkclub.Parameters.Add("@found", SqlDbType.Int);
                found.Direction = ParameterDirection.Output;

                conn.Open();
                checkclub.ExecuteNonQuery();
                conn.Close();
                if (found.Value.ToString() == "0")
                {
                    Response.Write("Invalid host club name");

                }
                else
                {
                    SqlCommand checkclub2 = new SqlCommand("checkclub", conn);
                    checkclub2.CommandType = CommandType.StoredProcedure;
                    checkclub2.Parameters.Add(new SqlParameter("name", guestclub));
                    SqlParameter found0 = checkclub2.Parameters.Add("@found", SqlDbType.Int);
                    found0.Direction = ParameterDirection.Output;

                    conn.Open();
                    checkclub2.ExecuteNonQuery();
                    conn.Close();
                    if (found0.Value.ToString() == "0")
                    {
                        Response.Write("Invalid guest club name");
                    }
                    else
                    {
                        SqlCommand checkmatch = new SqlCommand("checkmatch", conn);
                        checkmatch.CommandType = CommandType.StoredProcedure;
                        checkmatch.Parameters.Add(new SqlParameter("host", hostclub));
                        checkmatch.Parameters.Add(new SqlParameter("guest", guestclub));
                        checkmatch.Parameters.Add(new SqlParameter("start_time", Convert.ToDateTime(start)));
                        checkmatch.Parameters.Add(new SqlParameter("end_time", Convert.ToDateTime(end)));
                        SqlParameter found2 = checkmatch.Parameters.Add("@found", SqlDbType.Int);
                        found2.Direction = ParameterDirection.Output;

                        conn.Open();
                        checkmatch.ExecuteNonQuery();
                        conn.Close();

                        if (found2.Value.ToString() == "0")
                        {
                            SqlCommand addmatch = new SqlCommand("addNewMatch", conn);
                            addmatch.CommandType = CommandType.StoredProcedure;
                            addmatch.Parameters.Add(new SqlParameter("host", hostclub));
                            addmatch.Parameters.Add(new SqlParameter("guest", guestclub));
                            addmatch.Parameters.Add(new SqlParameter("start_time", Convert.ToDateTime(start)));
                            addmatch.Parameters.Add(new SqlParameter("end_time", Convert.ToDateTime(end)));

                            conn.Open();
                            addmatch.ExecuteNonQuery();
                            conn.Close();

                            hostclubname.Text = "";
                            guestclubname.Text = "";
                            starttime.Value = "";
                            endtime.Value = "";
                            Response.Write("Match added successfully");
                        }
                        else
                        {
                            Response.Write("Match already added");
                        }
                    }
                }
            }
        }

        protected void deletematch_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string hostclub = hostclubname.Text;
            string guestclub = guestclubname.Text;
            String start = starttime.Value;
            String end = endtime.Value;

            if (hostclub == "" || guestclub == "" || start == "" || end == "")
            {
                Response.Write("You must enter host club, guest club, start time and end time");
            }
            else
            {
                SqlCommand checkclub = new SqlCommand("checkclub", conn);
                checkclub.CommandType = CommandType.StoredProcedure;
                checkclub.Parameters.Add(new SqlParameter("name", hostclub));
                SqlParameter found = checkclub.Parameters.Add("@found", SqlDbType.Int);
                found.Direction = ParameterDirection.Output;

                conn.Open();
                checkclub.ExecuteNonQuery();
                conn.Close();
                if (found.Value.ToString() == "0")
                {
                    Response.Write("Invalid host club name");

                }
                else
                {
                    SqlCommand checkclub2 = new SqlCommand("checkclub", conn);
                    checkclub2.CommandType = CommandType.StoredProcedure;
                    checkclub2.Parameters.Add(new SqlParameter("name", guestclub));
                    SqlParameter found0 = checkclub2.Parameters.Add("@found", SqlDbType.Int);
                    found0.Direction = ParameterDirection.Output;

                    conn.Open();
                    checkclub2.ExecuteNonQuery();
                    conn.Close();
                    if (found0.Value.ToString() == "0")
                    {
                        Response.Write("Invalid guest club name");
                    }
                    else
                    {
                        SqlCommand checkmatch = new SqlCommand("checkmatch", conn);
                        checkmatch.CommandType = CommandType.StoredProcedure;
                        checkmatch.Parameters.Add(new SqlParameter("host", hostclub));
                        checkmatch.Parameters.Add(new SqlParameter("guest", guestclub));
                        checkmatch.Parameters.Add(new SqlParameter("start_time", Convert.ToDateTime(start)));
                        checkmatch.Parameters.Add(new SqlParameter("end_time", Convert.ToDateTime(end)));
                        SqlParameter found2 = checkmatch.Parameters.Add("@found", SqlDbType.Int);
                        found2.Direction = ParameterDirection.Output;

                        conn.Open();
                        checkmatch.ExecuteNonQuery();
                        conn.Close();

                        if (found2.Value.ToString() == "1")
                        {
                            SqlCommand deletematch = new SqlCommand("deletematch2", conn);
                            deletematch.CommandType = CommandType.StoredProcedure;
                            deletematch.Parameters.Add(new SqlParameter("host", hostclub));
                            deletematch.Parameters.Add(new SqlParameter("guest", guestclub));
                            deletematch.Parameters.Add(new SqlParameter("start_time", Convert.ToDateTime(start)));
                            deletematch.Parameters.Add(new SqlParameter("end_time", Convert.ToDateTime(end)));

                            conn.Open();
                            deletematch.ExecuteNonQuery();
                            conn.Close();

                            hostclubname.Text = "";
                            guestclubname.Text = "";
                            starttime.Value = "";
                            endtime.Value = "";
                            Response.Write("Match deleted successfully");
                        }
                        else
                        {
                            Response.Write("Match not found");
                        }
                    }
                }
            }
        }

        protected void upcoming_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            DateTime date1 = DateTime.Now;
            SqlCommand upcomingmatches1 = new SqlCommand(" SELECT * FROM dbo.availableMatchesToAttend2(@date);", conn);
            upcomingmatches1.CommandType = CommandType.Text;
            upcomingmatches1.Parameters.AddWithValue("@date", date1);

            conn.Open();
            SqlDataReader rdr = upcomingmatches1.ExecuteReader();
            while (rdr.Read())
            {
                String host = rdr[0].ToString();
                String guest = rdr.GetString(rdr.GetOrdinal("guest"));
                String start = rdr[2].ToString();
                String end = rdr[3].ToString();

                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell td = new HtmlTableCell();
                HtmlTableCell td1 = new HtmlTableCell();
                HtmlTableCell td2 = new HtmlTableCell();
                HtmlTableCell td3 = new HtmlTableCell();
                td.InnerText = host;
                td1.InnerText = guest;
                td2.InnerText = start;
                td3.InnerText = end;
                tr.Controls.Add(td);
                tr.Controls.Add(td1);
                tr.Controls.Add(td2);
                tr.Controls.Add(td3);
                upcomingmatches.Rows.Add(tr);

            }
            conn.Close();
        }

        protected void played_matches_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            DateTime date1 = DateTime.Now;
            SqlCommand alreadyplayed = new SqlCommand(" SELECT * FROM dbo.alreadyplayed(@date);", conn);
            alreadyplayed.CommandType = CommandType.Text;
            alreadyplayed.Parameters.AddWithValue("@date", date1);

            conn.Open();
            SqlDataReader rdr = alreadyplayed.ExecuteReader();
            while (rdr.Read())
            {
                String host = rdr[0].ToString();
                String guest = rdr.GetString(rdr.GetOrdinal("guest"));
                String start = rdr[2].ToString();
                String end = rdr[3].ToString();

                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell td = new HtmlTableCell();
                HtmlTableCell td1 = new HtmlTableCell();
                HtmlTableCell td2 = new HtmlTableCell();
                HtmlTableCell td3 = new HtmlTableCell();
                td.InnerText = host;
                td1.InnerText = guest;
                td2.InnerText = start;
                td3.InnerText = end;
                tr.Controls.Add(td);
                tr.Controls.Add(td1);
                tr.Controls.Add(td2);
                tr.Controls.Add(td3);
                playedmatches.Rows.Add(tr);

            }
            conn.Close();
        }

        protected void neverplayed_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["MileStone 3"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand neverplayedcmd = conn.CreateCommand();
            neverplayedcmd.CommandText = "SELECT * FROM clubsNeverMatched2";
            conn.Open();
            SqlDataReader rdr = neverplayedcmd.ExecuteReader();
            while (rdr.Read())
            {
                String club1 = rdr[0].ToString();
                String club2 = rdr[1].ToString();
                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell td = new HtmlTableCell();
                HtmlTableCell td1 = new HtmlTableCell();
                td.InnerText = club1;
                td1.InnerText = club2;
                tr.Controls.Add(td);
                tr.Controls.Add(td1);
                clubsneverplayed.Rows.Add(tr);

            }
            conn.Close();

        }
    }

}